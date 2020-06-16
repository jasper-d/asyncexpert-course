namespace Fibonacci.Fs

open System.Runtime.CompilerServices

module Fibonacci =
    let private memoize fn =
      let cache = new System.Collections.Generic.Dictionary<_,_>()
      (fun x ->
        match cache.TryGetValue x with
        | true, v -> v
        | false, _ -> let v = fn (x)
                      cache.Add(x,v)
                      v)
    [<MethodImpl(MethodImplOptions.NoInlining)>]
    let fib n = 
        let rec r_fib x prev curr =
            match x with
               | 2UL -> prev + curr
               | _ ->
                   r_fib (x - 1UL) curr (prev + curr)

        match n with
            | 0UL -> 0UL
            | 1UL -> 1UL
            | _ ->  r_fib n 0UL 1UL

    let memoized =
        memoize fib
