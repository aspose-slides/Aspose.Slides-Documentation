---
title: Interruption des opérations de présentation longues dans .NET
linktitle: Interrompre les opérations de présentation
type: docs
weight: 150
url: /fr/net/support-for-interruptable-library/
keywords:
- opérations interrompables
- jeton d'interruption
- jeton d'annulation
- tâche longue durée
- interrompre la tâche
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez comment annuler les opérations de présentation longues durée dans Aspose.Slides pour .NET et renvoyer un résultat partiel lors de l'exportation des diapositives dans une boucle."
---
## **Vue d'ensemble**

Aspose.Slides for .NET peut interrompre les opérations longues comme le chargement, l'enregistrement et le rendu des présentations. Votre application peut utiliser le même jeton d'interruption pour arrêter une boucle avant qu'elle ne commence à traiter la diapositive suivante.

## **Interrompre une opération de présentation**

Créez un [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/), affectez son [Token](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/token/) à [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/), puis transmettez les options de chargement au [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). Pour demander l'annulation, appelez [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) sur la source. Une opération interroptable s'arrête lorsqu'elle détecte la demande.

L'exemple démarre la conversion de `sample.pptx` en `sample.ppt` dans une tâche en arrière-plan et demande l'annulation après 10 seconds. Si la conversion se termine plus tôt, la sortie est déjà complète.

```c#
using System.Threading;
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Connecter l'annulation .NET à Aspose.Slides**

Si votre application utilise un [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken), transmettez sa demande d'annulation à Aspose.Slides. L'exemple démarre l'exportation de `sample.pptx` vers `sample.pdf` et définit un délai d'attente de 20 secondes. Pendant que l'exportation s'exécute, il vérifie [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) toutes les 500 milliseconds. Lorsque la propriété devient `true`, il appelle [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/).

```cs
using System.Threading;
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Arrêter avant de traiter la diapositive suivante**

Utilisez le même [IInterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/) pour la présentation et pour la boucle qui exporte ses diapositives. Vérifiez [IsInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/isinterruptionrequested/) avant de démarrer chaque exportation. Si l'appelant peut utiliser un résultat partiel, renvoyez les numéros de diapositives des exportations qui se sont terminées avec succès.

Utilisez une présentation nommée `sample.pptx` contenant au moins deux diapositives. L'exemple demande l'annulation immédiatement après avoir enregistré le premier export réussi.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

var source = new InterruptionTokenSource();
var completed = ExportSlides("sample.pptx", source);
Console.WriteLine($"Completed: [{string.Join(", ", completed)}]");

static List<int> ExportSlides(string path, IInterruptionTokenSource source)
{
    var completed = new List<int>();
    IInterruptionToken token = source.Token;
    var options = new LoadOptions { InterruptionToken = token };
    using var presentation = new Presentation(path, options);

    for (var number = 1; number <= presentation.Slides.Count; number++)
    {
        if (token.IsInterruptionRequested)
            break;

        Console.WriteLine($"Starting slide {number}");
        try
        {
            presentation.Save($"slide-{number}.pdf", new[] { number }, SaveFormat.Pdf);
        }
        catch (OperationCanceledException) when (token.IsInterruptionRequested)
        {
            break;
        }

        completed.Add(number);
        if (number == 1)
            source.Interrupt();
    }

    return completed;
}
```

L'exemple écrit `slide-1.pdf` et affiche `Starting slide 1` suivi de `Completed: [1]`. La boucle voit la demande avant de démarrer la diapositive 2. Si l'annulation interrompait à la place [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) pendant une exportation, le bloc `catch` sort de la boucle avant que le code n'enregistre la diapositive en cours comme terminée.

Si l'appelant doit gérer l'annulation, remplacez le test `if` et son `break` en haut de la boucle par un appel à [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) sur le jeton. Supprimez le `try`/`catch` autour de l'exportation afin que l'annulation pendant un enregistrement atteigne également l'appelant. Avec les mêmes entrées, l'exemple n'affiche que `Starting slide 1` et écrit `slide-1.pdf`. Au début de la deuxième itération, l'appelant reçoit une [OperationCanceledException](https://learn.microsoft.com/en-us/dotnet/api/system.operationcanceledexception) avant que l'exportation ne commence. La méthode ne renvoie aucune liste.

## **FAQ**

**Quand devrais-je demander l'annulation ?**

Demandez l'annulation lorsqu'une opération dépasse votre limite de temps ou lorsque votre application n'a plus besoin du résultat.

**Quelle est la différence entre [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) et [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/)?**

La source permet à votre application de demander l'annulation. Le jeton permet à Aspose.Slides et à votre application de vérifier cette demande.

**Puis-je utiliser un .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) avec Aspose.Slides ?**

Oui. Lorsque votre jeton .NET signale l'annulation, appelez [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) sur la source associée à la présentation.

**Quelles opérations puis-je interrompre ?**

Vous pouvez interrompre le chargement, l'enregistrement et le rendu. Transmettez le jeton au [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) via [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/). La présentation pourra alors observer l'annulation lors d'opérations ultérieures telles que [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/).

**Une opération s'arrête-t-elle immédiatement ?**

L'annulation est coopérative. Une opération vérifie le jeton périodiquement et s'arrête lorsqu'elle détecte la demande.

**Que se passe-t-il si j'appelle [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) après qu'une opération soit terminée ?**

L'opération terminée conserve son résultat.

**Plusieurs opérations peuvent-elles partager un [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/)?**

Oui. Appeler [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) demande l'annulation pour chaque opération qui utilise un jeton de cette source. Utilisez une source distincte pour chaque opération que vous souhaitez annuler indépendamment.