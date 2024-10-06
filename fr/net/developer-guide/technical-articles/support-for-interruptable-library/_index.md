---
title: Support pour la bibliothèque interrompable
type: docs
weight: 150
url: /net/support-for-interruptable-library/

---

## **Bibliothèque interrompable**

Dans [Aspose.Slides 18.4](https://docs.aspose.com/slides/net/aspose-slides-for-net-18-4-release-notes/), nous avons ajouté la classe [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken) et la classe [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource). Elles fournissent un support pour l'interruption de tâches de longue durée, telles que la désérialisation, la sérialisation ou le rendu.

- InterruptionTokenSource représente la source du token ou plusieurs tokens passés à **ILoadOptions.InterruptionToken**.
- Lorsque l'ILoadOptions.InterruptionToken est défini et que l'instance de LoadOptions est passée au constructeur Presentation, invoquer la méthode InterruptionTokenSource.Interrupt provoque l'interruption de toute tâche de longue durée liée à la Présentation.

Ce code ci-dessous démontre l'interruption d'une tâche en cours d'exécution :

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
    Run(action, tokenSource.Token); // exécuter l'action dans un thread séparé
    Thread.Sleep(10000);            // délai d'attente
    tokenSource.Interrupt();        // arrêter la conversion
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **.NET CancellationToken et bibliothèque interrompable**

Lorsque vous devez utiliser le [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) avec la bibliothèque interrompable Slides, vous pouvez encapsuler le traitement de la Présentation et interrompre [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken) si [cancellationToken.IsCancellationRequested](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) est défini sur vrai.

Ce code C# démontre l'opération décrite :

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
    Task task = Run(action, tokenSource.Token); // exécuter l'action dans un thread séparé

    while (!task.Wait(500)) // attendre pour surveiller si cancellationToken.IsCancellationRequested est défini.
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Le traitement de la présentation a été annulé");
            tokenSource.Interrupt(); // interrompre le traitement de la Présentation
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