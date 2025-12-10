---
title: Support pour la bibliothèque Interruptable
type: docs
weight: 150
url: /fr/net/support-for-interruptable-library/
keywords:
- bibliothèque interruptable
- jeton d'interruption
- jeton d'annulation
- tâche de longue durée
- interruption de tâche
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Rendez les tâches de longue durée annulables avec Aspose.Slides pour .NET. Interrompez le rendu et les conversions de PowerPoint et OpenDocument en toute sécurité, avec des exemples."
---

## **Bibliothèque Interruptible**

Dans [Aspose.Slides 18.4](https://releases.aspose.com/slides/net/release-notes/2018/aspose-slides-for-net-18-4-release-notes/), nous avons introduit les classes [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) et [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/). Elles vous permettent d’interrompre des tâches longues telles que la désérialisation, la sérialisation et le rendu.

- [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/) est la source des jetons transmis à [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/interruptiontoken/).
- Lorsque [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/interruptiontoken/) est défini et que l’instance de [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) est transmise au constructeur de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), l’appel de [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) interrompt toute tâche longue associée à cette [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).

Le fragment de code suivant montre comment interrompre une tâche en cours d’exécution :
```c#
public static void Run()
{
    Action<IInterruptionToken> action = (IInterruptionToken token) =>
    {
        LoadOptions options = new LoadOptions { InterruptionToken = token };
        using (Presentation presentation = new Presentation("sample.pptx", options))
        {
            presentation.Save("sample.ppt", SaveFormat.Ppt);
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


## **CancellationToken .NET et Bibliothèque Interruptible**

Lorsque vous devez utiliser un [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) avec la bibliothèque Interruptible d’Aspose.Slides, encapsulez le traitement de la [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) et interrompez le [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) lorsque [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) est `true`.

Ce code C# illustre le fonctionnement :
```cs
public static void Main()
{
    CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
    ProcessPresentation("sample.pptx", "sample.pdf", tokenSource.Token);
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

    while (!task.Wait(500)) // attendre et surveiller si cancellationToken.IsCancellationRequested est défini
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // interrompre le traitement de la présentation
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


## **FAQ**

**Quel est le but de la bibliothèque d’interruption Aspose.Slides ?**

Elle fournit un mécanisme pour interrompre les opérations longues—comme le chargement, l’enregistrement ou le rendu de présentations—avant leur achèvement. Cela est utile lorsque le temps de traitement doit être limité ou que la tâche n’est plus nécessaire.

**Quelle est la différence entre [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) et [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/)?**

- `InterruptionToken` est transmis à l’API Aspose.Slides et vérifié pendant les opérations longues.
- `InterruptionTokenSource` est utilisé dans votre code pour créer des jetons et déclencher des interruptions en appelant `Interrupt()`.

**Puis‑je utiliser le [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) .NET avec la bibliothèque d’interruption ?**

Oui. Vous pouvez surveiller le [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) dans votre logique d’application et appeler [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/) lorsque l’annulation est demandée. Cela permet à Aspose.Slides de s’intégrer aux flux d’annulation standard de .NET.

**Quelles tâches peuvent être interrompues ?**

Toute tâche Aspose.Slides qui accepte un [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/)—comme le chargement d’une présentation avec `Presentation(path, loadOptions)` ou l’enregistrement avec `Presentation.Save(...)`—peut être interrompue.

**L’interruption se produit‑elle immédiatement ?**

Non. L’interruption est coopérative : l’opération vérifie périodiquement le jeton et s’arrête dès qu’elle détecte qu’un appel à [Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/) a été effectué.

**Que se passe‑t‑il si j’appelle [Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/) après qu’une tâche soit déjà terminée ?**

Rien — l’appel n’a aucun effet si la tâche correspondante est déjà terminée.

**Puis‑je réutiliser le même [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/) pour plusieurs tâches ?**

Oui—mais après avoir appelé [Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/) sur cette source, toutes les tâches utilisant ses jetons seront interrompues. Utilisez des sources de jetons distinctes pour gérer les tâches de manière indépendante.