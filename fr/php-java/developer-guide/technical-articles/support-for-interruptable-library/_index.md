---
title: Interrompre les opérations de présentation de longue durée en PHP
linktitle: Interrompre les opérations de présentation
type: docs
weight: 120
url: /fr/php-java/support-for-interruptable-library/
keywords:
- jeton d'interruption
- annulation
- délai d'expiration de conversion
- exportation de diapositives
- PowerPoint
- PHP
- Aspose.Slides
description: "Apprenez comment annuler une conversion de présentation à l'aide d'un minuteur et renvoyer les diapositives exportées avant l'annulation avec Aspose.Slides pour PHP via Java."
---
## **Aperçu**

Aspose.Slides for PHP via Java peut interrompre les opérations longues telles que le chargement, l'enregistrement et le rendu des présentations. Dans une boucle qui exporte une diapositive à la fois, le même jeton permet à votre application de s'arrêter avant la diapositive suivante et de renvoyer une liste des exportations terminées.

Les deux exemples PHP supposent que votre bootstrap exécute `define("JAVA_PREFER_VALUES", 1);` avant de charger le pont `Java.inc`, puis charge `aspose.slides.php`. Ce paramètre permet à PHP d'intercepter les exceptions Java pendant l'appel. Les exemples examinent la cause de l'exception enveloppée afin que d'autres erreurs de conversion atteignent l'appelant.

## **Interrompre une opération de présentation**

Créez une [InterruptionTokenSource](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/), obtenez son jeton avec [InterruptionTokenSource::getToken](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#getToken) et transmettez‑le à [LoadOptions::setInterruptionToken](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setInterruptionToken). Fournissez ces options lors de la construction du [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Appeler [InterruptionTokenSource::interrupt](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#interrupt) demande l'annulation. Une opération en cours s'arrête lorsqu'elle constate la demande.

### **Définir un délai d'expiration de conversion**

Pendant que PHP attend un chargement ou un enregistrement synchronisé via le PHP/Java Bridge, un minuteur Java peut demander l'annulation sur un thread séparé. Enregistrez l'assistant suivant sous le nom `ConversionTimeout.java`, compilez‑le avec le JAR Aspose.Slides dans le classpath, et rendez la classe compilée disponible pour le pont sous son nom de paquet, `example.ConversionTimeout`.

```java
package example;

import com.aspose.slides.InterruptionTokenSource;
import java.util.Timer;
import java.util.TimerTask;

public class ConversionTimeout {
    public static Timer start(InterruptionTokenSource source, long milliseconds) {
        Timer timer = new Timer(true);
        timer.schedule(new TimerTask() {
            @Override
            public void run() {
                source.interrupt();
            }
        }, milliseconds);
        return timer;
    }
}
```

Avec le pont et le wrapper PHP d'Aspose.Slides chargés, exécutez l'exemple suivant avec `sample.pptx` dans le répertoire de travail du processus Java, ou utilisez des chemins absolus accessibles à ce processus. La limite de 20 secondes couvre à la fois le chargement et l'exportation PDF. Si la conversion se termine tôt, PHP annule le minuteur. Pour convertir vers le format PowerPoint plus ancien avec une limite de 10 secondes, utilisez `sample.ppt`, `SaveFormat::Ppt` et `10000` millisecondes.

```php
use aspose\slides\InterruptionTokenSource;
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new InterruptionTokenSource();
$token = $source->getToken();
$options = new LoadOptions();
$options->setInterruptionToken($token);
$timer = java("example.ConversionTimeout")->start($source, 20000);
try {
    $presentation = new Presentation("sample.pptx", $options);
    try {
        $token->throwIfInterruptionRequested();
        $presentation->save("sample.pdf", SaveFormat::Pdf);
        $token->throwIfInterruptionRequested();
        echo "Conversion completed\n";
    } finally {
        $presentation->dispose();
    }
} catch (JavaException $error) {
    if (!java_instanceof($error->getCause(), java("com.aspose.slides.exceptions.OperationCanceledException"))) {
        throw $error;
    }
    echo "Conversion canceled\n";
} finally {
    $timer->cancel();
}
```

## **Arrêter avant de traiter la diapositive suivante**

Vérifiez [InterruptionToken::isInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#isInterruptionRequested) avant chaque exportation. La surcharge de [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) pour les diapositives sélectionnées accepte des numéros de diapositive commençant à 1. Passez un tableau à un élément pour générer un PDF distinct pour chaque diapositive.

Utilisez un `sample.pptx` contenant au moins deux diapositives. Pour démontrer l'annulation entre les exportations, l'exemple la demande immédiatement après l'enregistrement de la première diapositive.

```php
use aspose\slides\InterruptionTokenSource;
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function exportSlides($path, $source) {
    $completed = [];
    $token = $source->getToken();
    $options = new LoadOptions();
    $options->setInterruptionToken($token);
    $presentation = new Presentation($path, $options);
    try {
        $count = java_values($presentation->getSlides()->size());
        for ($number = 1; $number <= $count; $number++) {
            if (java_values($token->isInterruptionRequested())) {
                break;
            }

            try {
                $presentation->save("slide-$number.pdf", [$number], SaveFormat::Pdf);
                $token->throwIfInterruptionRequested();
            } catch (JavaException $error) {
                if (java_instanceof($error->getCause(), java("com.aspose.slides.exceptions.OperationCanceledException"))) {
                    break;
                }
                throw $error;
            }

            $completed[] = $number;
            if ($number === 1) {
                $source->interrupt();
            }
        }
        return $completed;
    } finally {
        $presentation->dispose();
    }
}

$source = new InterruptionTokenSource();
$completed = exportSlides("sample.pptx", $source);
echo "Completed: " . json_encode($completed) . "\n";
```

L'exemple écrit `slide-1.pdf` et affiche `Completed: [1]`. La deuxième itération voit la demande avant de commencer une autre exportation. Si l'annulation se produit pendant un enregistrement, la liste ne contient que les exportations confirmées précédemment. Un enregistrement interrompu peut laisser un fichier incomplet sur le disque.

Pour propager l'annulation à l'appelant, remplacez la vérification au début de la boucle par `$token->throwIfInterruptionRequested();` et supprimez le `try`/`catch` interne, en conservant l'enregistrement et la vérification qui le suit. Avec la même entrée, [InterruptionToken::throwIfInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) lève une exception avant la diapositive 2 et l'appelant ne reçoit aucune liste.

## **FAQ**

**Quand devrais-je demander l'annulation ?**

Demandez l'annulation lorsqu'une échéance expire ou que l'appelant n'a plus besoin du résultat. Une demande faite après la fin d'une opération laisse son résultat intact.

**Comment la source et le jeton diffèrent-ils ?**

La source permet à une application de demander l'annulation. Le jeton permet à Aspose.Slides et au code de l'application d'observer cette demande.

**Plusieurs opérations peuvent-elles partager une même source ?**

Oui. Une demande s'applique à toutes les opérations utilisant des jetons provenant de cette source. Créez des sources séparées pour les opérations qui nécessitent une annulation indépendante.