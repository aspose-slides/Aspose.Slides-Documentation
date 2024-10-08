---
title: 可中断库支持
type: docs
weight: 150
url: /net/support-for-interruptable-library/

---

## **可中断库**

在 [Aspose.Slides 18.4](https://docs.aspose.com/slides/net/aspose-slides-for-net-18-4-release-notes/) 中，我们添加了 [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken) 类和 [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource) 类。它们为长时间运行的任务提供了中断支持，例如反序列化、序列化或渲染。

- InterruptionTokenSource 表示传递给 **ILoadOptions.InterruptionToken** 的令牌或多个令牌的来源。
- 当设置 ILoadOptions.InterruptionToken 并将 LoadOptions 实例传递给 Presentation 构造函数时，调用 InterruptionTokenSource.Interrupt 方法会中断与 Presentation 相关的任何长时间运行的任务。

下面的代码片段演示了一个正在运行的任务的中断：

```c#
public static void Run()
{
    Action<IInterruptionToken> action = (IInterruptionToken token) =>
    {
        LoadOptions options = new LoadOptions { InterruptionToken = token };
        using (Presentation presentation = new Presentation("pres.pptx", options))
        {
            presentation.Save("pres.ppt", SaveFormat.Ppt);
        }
    };

    InterruptionTokenSource tokenSource = new InterruptionTokenSource();
    Run(action, tokenSource.Token); // 在单独的线程中运行操作
    Thread.Sleep(10000);            // 超时
    tokenSource.Interrupt();        // 停止转换
}
private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **.NET CancellationToken 和可中断库**

当需要在 Slides 可中断库中使用 [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) 时，如果 [cancellationToken.IsCancellationRequested](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) 设置为 true，您可以包装 Presentation 处理并中断 [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken)。

以下 C# 代码演示了所描述的操作：

```csharp
public static void Main()
{
    CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
    ProcessPresentation("pres.pptx", "pres.pdf", tokenSource.Token);
}

static void ProcessPresentation(string path, string outPath, CancellationToken cancellationToken)
{
    Action<IInterruptionToken> action = (IInterruptionToken token) =>
    {
        LoadOptions options = new LoadOptions {InterruptionToken = token};
        using (Presentation presentation = new Presentation(path, options))
        {
            presentation.Save(outPath, SaveFormat.Pdf);
        }
    };
    
    InterruptionTokenSource tokenSource = new InterruptionTokenSource();
    Task task = Run(action, tokenSource.Token); // 在单独的线程中运行操作

    while (!task.Wait(500)) // 等待以监控是否设置了 cancellationToken.IsCancellationRequested。
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("演示文稿处理已被取消");
            tokenSource.Interrupt(); // 中断演示文稿处理
        }
    }
}

private static Task Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    return Task.Run(() =>
    {
        action(token);
    });
}
```