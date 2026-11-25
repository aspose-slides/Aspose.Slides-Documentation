---
title: Interrompre les opérations de présentation longues en Java
linktitle: Interrompre les opérations de présentation
type: docs
weight: 120
url: /fr/java/support-for-interruptable-library/
keywords:
- opérations interrompables
- jeton d'interruption
- jeton d'annulation
- tâche de longue durée
- interrompre la tâche
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Apprenez comment annuler les opérations de présentation longues dans Aspose.Slides for Java et renvoyer un résultat partiel lors de l'exportation des diapositives dans une boucle."
---
## **Vue d'ensemble**

Aspose.Slides for Java peut interrompre les opérations longues telles que le chargement, l'enregistrement et le rendu des présentations. Votre application peut utiliser le même jeton d'interruption pour arrêter une boucle avant qu'elle ne commence à traiter la diapositive suivante.

## **Interrompre une opération de présentation**

Créez un [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/), obtenez son jeton avec [getToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#getToken--), et transmettez le jeton à [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Passez les options de chargement au [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-). Pour demander l'annulation, appelez [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) sur la source. Une opération interrompable s'arrête lorsqu'elle remarque la demande.

L'exemple convertit `sample.pptx` en `sample.ppt` sur un thread d'arrière-plan. Le thread appelant attend jusqu'à 10 seconds que la conversion se termine. Si la conversion est toujours en cours, il demande l'annulation et attend que le travailleur se termine.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;

InterruptionTokenSource source = new InterruptionTokenSource();
Thread worker = new Thread(() -> {
    LoadOptions options = new LoadOptions();
    options.setInterruptionToken(source.getToken());
    try {
        Presentation presentation = new Presentation("sample.pptx", options);
        try {
            presentation.save("sample.ppt", SaveFormat.Ppt);
        } finally {
            presentation.dispose();
        }
    } catch (OperationCanceledException canceled) {
        System.out.println("Conversion canceled");
    }
});

worker.start();
worker.join(10000);
if (worker.isAlive()) {
    source.interrupt();
    worker.join();
}
```

## **Connecter un délai d'attente Java à Aspose.Slides**

Pour définir une limite de temps sur une opération de présentation, utilisez un [ScheduledExecutorService](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/util/concurrent/ScheduledExecutorService.html) pour appeler [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) lorsque le délai expire. L'exemple autorise 20 seconds pour charger `sample.pptx` et l'exporter vers `sample.pdf`. Si l'exportation se termine tôt, l'application annule la requête programmée.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;

InterruptionTokenSource source = new InterruptionTokenSource();
LoadOptions options = new LoadOptions();
options.setInterruptionToken(source.getToken());

ScheduledExecutorService timer = Executors.newSingleThreadScheduledExecutor();
ScheduledFuture<?> timeout = timer.schedule(source::interrupt, 20, TimeUnit.SECONDS);
try {
    Presentation presentation = new Presentation("sample.pptx", options);
    try {
        presentation.save("sample.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
    }
} catch (OperationCanceledException canceled) {
    System.out.println("Presentation processing was canceled");
} finally {
    timeout.cancel(false);
    timer.shutdown();
}
```

## **Arrêter avant de traiter la diapositive suivante**

Utilisez le même [IInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/) pour la présentation et la boucle qui exporte ses diapositives. Vérifiez [isInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) avant chaque exportation. Si l'appelant peut utiliser un résultat partiel, renvoyez les numéros de diapositive pour les exportations qui ont abouti avec succès.

Utilisez une présentation nommée `sample.pptx` contenant au moins deux diapositives. La surcharge [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int---int-) qui accepte un tableau de numéros de diapositives commence à compter à partir de 1. L'exemple enregistre chaque diapositive dans un PDF séparé et demande l'annulation immédiatement après avoir enregistré le premier export réussi.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.ArrayList;
import java.util.List;

class SlideExporter {
    List<Integer> exportSlides(String path, InterruptionTokenSource source) {
        List<Integer> completed = new ArrayList<>();
        IInterruptionToken token = source.getToken();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(token);
        Presentation presentation = new Presentation(path, options);
        try {
            for (int number = 1; number <= presentation.getSlides().size(); number++) {
                if (token.isInterruptionRequested()) {
                    break;
                }

                System.out.println("Starting slide " + number);
                try {
                    presentation.save("slide-" + number + ".pdf", new int[] { number }, SaveFormat.Pdf);
                } catch (OperationCanceledException canceled) {
                    if (token.isInterruptionRequested()) {
                        break;
                    }
                    throw canceled;
                }

                completed.add(number);
                if (number == 1) {
                    source.interrupt();
                }
            }
            return completed;
        } finally {
            presentation.dispose();
        }
    }
}

InterruptionTokenSource source = new InterruptionTokenSource();
SlideExporter exporter = new SlideExporter();
List<Integer> completed = exporter.exportSlides("sample.pptx", source);
System.out.println("Completed: " + completed);
```

L'exemple écrit `slide-1.pdf` et affiche `Starting slide 1` suivi de `Completed: [1]`. La boucle remarque la demande avant de commencer la diapositive 2. Si l'annulation arrive pendant un enregistrement, la boucle se termine avant d'enregistrer cette diapositive comme terminée.

Si l'appelant doit gérer l'annulation, remplacez la vérification et son `break` en haut de la boucle par `token.throwIfInterruptionRequested()`. Supprimez le `try`/`catch` autour de l'enregistrement afin que l'annulation pendant un export atteigne également l'appelant. Avec la même entrée, l'exemple n'affiche que `Starting slide 1` et écrit `slide-1.pdf`. Au début de la deuxième itération, [throwIfInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) lève `com.aspose.slides.exceptions.OperationCanceledException` avant que l'export suivant ne commence. La méthode ne renvoie aucune liste.

## **FAQ**

**Quand dois-je demander l'annulation ?**

Demandez l'annulation lorsqu'une opération dépasse votre limite de temps ou lorsque votre application n'a plus besoin du résultat.

**Quelle est la différence entre [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) et [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)?**

La source permet à votre application de demander l'annulation. Le jeton permet à Aspose.Slides et à votre application de vérifier cette demande.

**Puis-je annuler une opération depuis un minuteur Java ?**

Oui. Planifiez un appel à [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) sur la source associée à la présentation.

**Quelles opérations puis-je interrompre ?**

Vous pouvez interrompre le chargement, l'enregistrement et le rendu. Transmettez le jeton au [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) via [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). La présentation pourra alors observer l'annulation lors d'opérations ultérieures telles que l'enregistrement en PDF.

**Une opération s'arrête-t-elle immédiatement ?**

L'annulation est coopérative. Une opération vérifie périodiquement le jeton et s'arrête lorsqu'elle remarque la demande.

**Que se passe-t-il si j'appelle [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) après qu'une opération soit terminée ?**

L'opération terminée conserve son résultat.

**Plusieurs opérations peuvent-elles partager un [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)?**

Oui. Appeler [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) demande l'annulation pour chaque opération qui utilise un jeton provenant de cette source. Utilisez une source distincte pour chaque opération que vous souhaitez annuler indépendamment.