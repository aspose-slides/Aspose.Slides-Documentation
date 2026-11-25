---
title: Interrompre les opérations de présentation de longue durée sur Android
linktitle: Interrompre les opérations de présentation
type: docs
weight: 120
url: /fr/androidjava/support-for-interruptable-library/
keywords:
- opérations interruptibles
- jeton d'interruption
- jeton d'annulation
- tâche de longue durée
- interrompre la tâche
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez comment annuler les opérations de présentation de longue durée dans Aspose.Slides pour Android via Java et retourner un résultat partiel lors de l'exportation des diapositives dans une boucle."
---
## **Aperçu**

Aspose.Slides for Android via Java peut interrompre les opérations longues telles que le chargement, l’enregistrement et le rendu des présentations. Votre application peut utiliser le même jeton d’interruption pour arrêter une boucle avant qu’elle ne commence à traiter la diapositive suivante.

## **Interrompre une opération de présentation**

Créez un [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/), obtenez son jeton avec [getToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#getToken--), et transmettez le jeton à [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Passez les options de chargement au [Presentation constructor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-). Pour demander l’annulation, appelez [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) sur la source. Une opération interrompable s’arrête lorsqu’elle prend connaissance de la demande.

L’exemple convertit `sample.pptx` en `sample.ppt` sur un thread d’arrière‑plan. Le thread appelant attend jusqu’à 10 secondes que la conversion se termine. Si la conversion est toujours en cours, il demande l’annulation et attend que le travailleur se termine.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.io.File;

public class InterruptConversion {
    // Appeler depuis un thread d'arrière-plan et passer context.getFilesDir(), qui contient sample.pptx.
    public static void run(File directory) throws InterruptedException {
        File input = new File(directory, "sample.pptx");
        File output = new File(directory, "sample.ppt");
        InterruptionTokenSource source = new InterruptionTokenSource();
        Thread worker = new Thread(() -> {
            LoadOptions options = new LoadOptions();
            options.setInterruptionToken(source.getToken());
            try {
                Presentation presentation = new Presentation(input.getAbsolutePath(), options);
                try {
                    presentation.save(output.getAbsolutePath(), SaveFormat.Ppt);
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
    }
}
```

## **Connecter une temporisation Java à Aspose.Slides**

Pour définir une limite de temps sur une opération de présentation, utilisez un [ScheduledExecutorService](https://developer.android.com/reference/java/util/concurrent/ScheduledExecutorService) pour appeler [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) lorsque le délai expire. L’exemple autorise 20 secondes pour charger `sample.pptx` et l’exporter en `sample.pdf`. Si l’export se termine plus tôt, l’application annule la demande planifiée.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;
import java.io.File;

public class TimedPdfExport {
    // Appeler depuis un thread d'arrière-plan et passer context.getFilesDir(), qui contient sample.pptx.
    public static void run(File directory) {
        File input = new File(directory, "sample.pptx");
        File output = new File(directory, "sample.pdf");
        InterruptionTokenSource source = new InterruptionTokenSource();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(source.getToken());

        ScheduledExecutorService timer = Executors.newSingleThreadScheduledExecutor();
        ScheduledFuture<?> timeout = timer.schedule(source::interrupt, 20, TimeUnit.SECONDS);
        try {
            Presentation presentation = new Presentation(input.getAbsolutePath(), options);
            try {
                presentation.save(output.getAbsolutePath(), SaveFormat.Pdf);
            } finally {
                presentation.dispose();
            }
        } catch (OperationCanceledException canceled) {
            System.out.println("Presentation processing was canceled");
        } finally {
            timeout.cancel(false);
            timer.shutdown();
        }
    }
}
```

## **Arrêter avant de traiter la diapositive suivante**

Utilisez le même [IInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/) pour la présentation et la boucle qui exporte ses diapositives. Vérifiez [isInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) avant chaque export. Si l’appelant peut se contenter d’un résultat partiel, renvoyez les numéros de diapositive des exports qui ont réussi.

Utilisez une présentation nommée `sample.pptx` contenant au moins deux diapositives. La surcharge de [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int---int-) qui accepte un tableau de numéros de diapositives compte à partir de 1. L’exemple enregistre chaque diapositive dans un PDF distinct et demande l’annulation immédiatement après le premier export réussi.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.ArrayList;
import java.util.List;
import java.io.File;

public class SlideExporter {
    private static List<Integer> exportSlides(File directory, InterruptionTokenSource source) {
        List<Integer> completed = new ArrayList<>();
        IInterruptionToken token = source.getToken();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(token);
        File input = new File(directory, "sample.pptx");
        Presentation presentation = new Presentation(input.getAbsolutePath(), options);
        try {
            for (int number = 1; number <= presentation.getSlides().size(); number++) {
                if (token.isInterruptionRequested()) {
                    break;
                }

                System.out.println("Starting slide " + number);
                try {
                    File output = new File(directory, "slide-" + number + ".pdf");
                    presentation.save(output.getAbsolutePath(), new int[] { number }, SaveFormat.Pdf);
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

    // Appeler depuis un thread d'arrière-plan et passer context.getFilesDir(), qui contient sample.pptx.
    public static void run(File directory) {
        InterruptionTokenSource source = new InterruptionTokenSource();
        List<Integer> completed = exportSlides(directory, source);
        System.out.println("Completed: " + completed);
    }
}
```

L’exemple écrit `slide-1.pdf` et affiche `Starting slide 1` suivi de `Completed: [1]`. La boucle observe la demande avant de démarrer la diapositive 2. Si l’annulation survient pendant un enregistrement, la boucle sort avant de marquer cette diapositive comme terminée.

Si l’appelant doit gérer l’annulation, remplacez la vérification et son `break` en tête de boucle par `token.throwIfInterruptionRequested()`. Supprimez le `try`/`catch` autour de l’enregistrement afin que l’annulation pendant un export remonte à l’appelant. Avec les mêmes entrées, l’exemple n’affiche que `Starting slide 1` et crée `slide-1.pdf`. Au début de la deuxième itération, [throwIfInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) lève `com.aspose.slides.exceptions.OperationCanceledException` avant le prochain export. La méthode ne renvoie aucune liste.

## **FAQ**

**Quand dois-je demander l’annulation ?**

Demandez l’annulation lorsqu’une opération dépasse votre limite de temps ou lorsque votre application n’a plus besoin du résultat.

**Quelle est la différence entre [InterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontoken/) et [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/)?**

La source permet à votre application de demander l’annulation. Le jeton permet à Aspose.Slides et à votre application de vérifier cette demande.

**Puis‑je annuler une opération depuis un minuteur Java ?**

Oui. Planifiez un appel à [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) sur la source associée à la présentation.

**Quelles opérations puis‑je interrompre ?**

Vous pouvez interrompre le chargement, l’enregistrement et le rendu. Transmettez le jeton au [Presentation constructor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) via [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). La présentation pourra alors détecter l’annulation lors d’opérations ultérieures, comme l’enregistrement en PDF.

**L’opération s’arrête‑t‑elle immédiatement ?**

L’annulation est coopérative. Une opération vérifie périodiquement le jeton et s’arrête lorsqu’elle détecte la demande.

**Que se passe‑t‑il si j’appelle [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) après la fin d’une opération ?**

L’opération terminée conserve son résultat.

**Plusieurs opérations peuvent‑elles partager un [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/)?**

Oui. Appeler [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) demande l’annulation pour chaque opération utilisant un jeton provenant de cette source. Utilisez une source distincte pour chaque opération que vous souhaitez annuler indépendamment.