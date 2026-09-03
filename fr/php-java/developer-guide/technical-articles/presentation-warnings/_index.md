---
title: Gérer les avertissements de présentation en PHP
type: docs
weight: 90
url: /fr/php-java/presentation-warnings/
aliases:
- /php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- rappel d'avertissement
- politique d'avertissement
- perte de données
- corruption de la source
- problème de compatibilité
- substitution de police
- signature numérique
- chargement de la présentation
- rendu de la présentation
- conversion de la présentation
- enregistrement de la présentation
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Apprenez à collecter, classer et gérer les avertissements lors du chargement, du rendu, de la conversion et de l’enregistrement de présentations avec Aspose.Slides pour PHP via Java."
---
## **Vue d'ensemble**

Aspose.Slides peut signaler des problèmes récupérables lorsqu’il charge, rend, convertit ou enregistre une présentation. Les exemples incluent des enregistrements source endommagés, du contenu qui ne peut pas être préservé, la substitution de polices et les limitations d’un format cible. Un rappel d’avertissement permet à une application d’enregistrer ces conditions et de décider si l’opération en cours peut se poursuivre.

Créez une classe PHP avec une méthode publique `warning` et exposez-la via PHP Java Bridge comme l’interface Java [IWarningCallback](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iwarningcallback/) en utilisant `java_closure`. Examinez les valeurs [getWarningType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iwarninginfo/#getWarningType--) et [getDescription](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iwarninginfo/#getDescription--) fournies via [IWarningInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iwarninginfo/). Retournez [ReturnAction::Continue](https://reference.aspose.com/slides/fr/php-java/aspose.slides/returnaction/#Continue) pour accepter l’avertissement ou [ReturnAction::Abort](https://reference.aspose.com/slides/fr/php-java/aspose.slides/returnaction/#Abort) pour arrêter l’opération.

Utilisez [LoadOptions::setWarningCallback](https://reference.aspose.com/slides/fr/php-java/aspose.slides/loadoptions/#setWarningCallback) pour les avertissements générés lors de l’ouverture d’une présentation. Les classes d’options de rendu et d’exportation héritent de [SaveOptions::setWarningCallback](https://reference.aspose.com/slides/fr/php-java/aspose.slides/saveoptions/#setWarningCallback), qui reçoit les avertissements du rendu des diapositives, de la conversion et de l’enregistrement. Comme l’avertissement lui‑même n’identifie pas l’opération de l’application, associez chaque instance de rappel à une étape d’opération lors de la création d’un rapport combiné.

## **Avertissements et Exceptions**

Les exceptions Java sont exposées à PHP via PHP Java Bridge ; capturez‑les à la frontière de l’opération, comme le montre l’exemple ci‑dessus. Les liens d’interface Java dans cet article décrivent le contrat de rappel utilisé par le pont.

Un avertissement décrit une condition dont Aspose.Slides peut se remettre si le rappel renvoie `ReturnAction::Continue`. Une exception signifie que l’opération demandée ne peut pas se terminer normalement ; les exceptions ne sont pas converties en avertissements et ne peuvent pas être gérées par une politique d’avertissement.

Retourner `ReturnAction::Abort` demande au répartiteur d’avertissements de terminer l’opération en cours en levant une exception. L’exception publique dépend de l’opération et du format de la présentation. Par exemple, le chargement peut générer une [PptxReadException](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pptxreadexception/) ou une [PptReadException](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pptreadexception/), tandis que l’enregistrement ou l’exportation peut générer une [PptxException](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pptxexception/). Gérez l’exception à la frontière de l’opération et utilisez le rapport d’avertissement pour déterminer si la politique de l’application a causé la terminaison au lieu de vous fier à un sous‑type ou à un message d’exception. Le rappel enregistre l’avertissement avant de renvoyer `ReturnAction::Abort`, garantissant que la raison reste disponible pour l’application.

## **Catégories d’avertissement**

La classe [WarningType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/warningtype/) fournit des constantes entières pour les catégories suivantes :

| Type d'avertissement | Signification | Politique typique |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/fr/php-java/aspose.slides/warningtype/#SourceFileCorruption) | La présentation source contient une corruption qui peut rendre un document enregistré dans son format original inutilisable. | Abandonner. |
| [DataLoss](https://reference.aspose.com/slides/fr/php-java/aspose.slides/warningtype/#DataLoss) | Du texte, des graphiques, des images ou d’autres données peuvent être absents après le chargement ou l’enregistrement. | Abandonner. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/fr/php-java/aspose.slides/warningtype/#MajorFormattingLoss) | La présentation peut perdre un formatage important. | Abandonner en mode de validation stricte ; sinon enregistrer et continuer. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/fr/php-java/aspose.slides/warningtype/#MinorFormattingLoss) | Une différence de formatage limitée peut se produire. | Enregistrer pour le diagnostic et continuer. |
| [CompatibilityIssue](https://reference.aspose.com/slides/fr/php-java/aspose.slides/warningtype/#CompatibilityIssue) | Le résultat peut ne pas s’ouvrir ou se comporter correctement dans certaines applications ou versions anciennes. | Journaliser et continuer sauf si la compatibilité est obligatoire. |
| [UnexpectedContent](https://reference.aspose.com/slides/fr/php-java/aspose.slides/warningtype/#UnexpectedContent) | La source contient du contenu non pris en charge ou non reconnu dont l’effet n’est pas encore connu. | Enregistrer et continuer, ou traiter comme une erreur en politique stricte. |

La catégorie doit guider la décision de politique. Conservez la valeur retournée par [getDescription](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iwarninginfo/#getDescription--) pour le diagnostic, mais ne vous fiez pas à sa formulation pour la logique de l’application car le texte du message peut varier selon les scénarios d’avertissement et les versions du produit.

## **Collecter et classer les avertissements**

L’exemple suivant utilise un seul rapport au niveau de l’application pour l’ensemble du pipeline de traitement. Une instance de rappel distincte étiquette les avertissements provenant du chargement, du rendu, de la conversion PDF et de l’enregistrement PPTX. La politique abandonne en cas de corruption de la source ou de perte de données, abort optionnellement en cas de perte de formatage majeur, et continue pour les autres avertissements. Le rappel convertit les valeurs d’avertissement en valeurs PHP natives avec `java_values` avant de les enregistrer et de les comparer.

```php
use aspose\slides\ImageFormat;
use aspose\slides\LoadOptions;
use aspose\slides\PdfOptions;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class WarningReport {
    private $entries = [];

    public function getEntries() {
        return $this->entries;
    }

    public function add($stage, $type, $description) {
        $this->entries[] = [
            "stage" => $stage,
            "type" => $type,
            "description" => $description
        ];
    }
}

class WarningPolicy {
    private $abortOnMajorFormattingLoss;

    public function __construct($abortOnMajorFormattingLoss) {
        $this->abortOnMajorFormattingLoss = $abortOnMajorFormattingLoss;
    }

    public function getAction($warningType) {
        if ($warningType === WarningType::SourceFileCorruption || $warningType === WarningType::DataLoss) {
            return ReturnAction::Abort;
        }

        if ($warningType === WarningType::MajorFormattingLoss && $this->abortOnMajorFormattingLoss) {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }
}

class ReportingWarningCallback {
    private $stage;
    private $report;
    private $policy;

    public function __construct($stage, WarningReport $report, WarningPolicy $policy) {
        $this->stage = $stage;
        $this->report = $report;
        $this->policy = $policy;
    }

    public function warning($warning) {
        $type = (int) java_values($warning->getWarningType());
        $description = (string) java_values($warning->getDescription());
        $this->report->add($this->stage, $type, $description);
        return $this->policy->getAction($type);
    }
}

function createWarningCallback($stage, WarningReport $report, WarningPolicy $policy) {
    $handler = new ReportingWarningCallback($stage, $report, $policy);
    $warningInterface = java("com.aspose.slides.IWarningCallback");
    return java_closure($handler, null, $warningInterface);
}

function processPresentation($inputPath, WarningReport $report, WarningPolicy $policy) {
    try {
        $loadOptions = new LoadOptions();
        $callback = createWarningCallback("Loading", $report, $policy);
        $loadOptions->setWarningCallback($callback);

        $presentation = new Presentation($inputPath, $loadOptions);
        try {
            if (!renderFirstSlide($presentation, $report, $policy)) {
                return false;
            }

            if (!convertToPdf($presentation, $report, $policy)) {
                return false;
            }

            return saveValidatedCopy($presentation, $report, $policy);
        } finally {
            $presentation->dispose();
        }
    } catch (Throwable $exception) {
        echo "Loading stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function renderFirstSlide($presentation, WarningReport $report, WarningPolicy $policy) {
    if ((int) java_values($presentation->getSlides()->size()) === 0) {
        echo "Rendering stopped: the presentation has no slides." . PHP_EOL;
        return false;
    }

    try {
        $options = new RenderingOptions();
        $callback = createWarningCallback("Rendering", $report, $policy);
        $options->setWarningCallback($callback);

        $image = $presentation->getSlides()->get_Item(0)->getImage($options);
        try {
            $image->save("slide-1.png", ImageFormat::Png);
            return true;
        } finally {
            $image->dispose();
        }
    } catch (Throwable $exception) {
        echo "Rendering stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function convertToPdf($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PdfOptions();
        $callback = createWarningCallback("Conversion", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("converted.pdf", SaveFormat::Pdf, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Conversion stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function saveValidatedCopy($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PptxOptions();
        $callback = createWarningCallback("Saving", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("validated-output.pptx", SaveFormat::Pptx, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Saving stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function warningTypeName($warningType) {
    switch ($warningType) {
        case WarningType::SourceFileCorruption:
            return "SourceFileCorruption";
        case WarningType::DataLoss:
            return "DataLoss";
        case WarningType::MajorFormattingLoss:
            return "MajorFormattingLoss";
        case WarningType::MinorFormattingLoss:
            return "MinorFormattingLoss";
        case WarningType::CompatibilityIssue:
            return "CompatibilityIssue";
        case WarningType::UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" . $warningType . ")";
    }
}

$report = new WarningReport();
$policy = new WarningPolicy(true);
$completed = processPresentation("input.pptx", $report, $policy);

echo ($completed ? "Processing completed." : "Processing stopped.") . PHP_EOL;

foreach ($report->getEntries() as $entry) {
    $typeName = warningTypeName($entry["type"]);
    echo "[" . $entry["stage"] . "] " . $typeName . ": " . $entry["description"] . PHP_EOL;
}
```

Passez `false` à `abortOnMajorFormattingLoss` lors de la construction de `WarningPolicy` si les différences de formatage majeures sont acceptables. Les problèmes de compatibilité, la perte de formatage mineur et le contenu inattendu sont toujours conservés dans le rapport même lorsque l’opération continue. Étendez `WarningPolicy::getAction` si l’application doit rejeter l’une de ces catégories.

## **Scénarios d’avertissement courants**

Les avertissements peuvent apparaître à différentes étapes d’un flux de travail :

- **Signatures numériques :** Une présentation signée peut générer un avertissement lors du chargement indiquant que sa signature sera perdue pendant le traitement. Aspose.Slides signale cette condition `DataLoss` via [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentationsignedwarninginfo/). Un rappel au stade du chargement permet à l’application de rejeter le fichier ou d’accepter explicitement la perte signalée.
- **Substitution de police :** Une police indisponible peut être remplacée lors du rendu ou de l’exportation d’une diapositive. Les avertissements de substitution de police sont signalés comme `DataLoss`, de sorte que la politique stricte ci‑dessus abandonne même si l’application considérerait un remplacement particulier comme visuellement acceptable. Pour observer ce comportement, utilisez une présentation d’entrée contenant du texte dans une police non disponible à l’exécution. La description de l’avertissement identifie la substitution ; configurez les polices requises ou les [règles de substitution de police](/slides/fr/php-java/font-substitution/) avant de réessayer.
- **Contenu non pris en charge ou inattendu :** Un chargeur peut rencontrer des enregistrements de présentation ou des fonctionnalités qu’il ne reconnaît pas. De tels avertissements peuvent utiliser `UnexpectedContent`, ou une catégorie plus sévère lorsque des données ou un formatage sont connus pour être affectés.
- **Compatibilité de format :** L’enregistrement dans un autre format de présentation peut omettre des fonctionnalités ou produire un résultat qui se comporte différemment dans certaines applications. Par exemple, enregistrer une présentation contenant plus de huit repères de dessin horizontaux ou verticaux dans le PPT hérité signale un `CompatibilityIssue`. Le rappel au stade de l’enregistrement peut enregistrer la perte et continuer, ou la rejeter si la conservation de tous les repères est requise.
- **Comportement de chargement :** Les options de chargement et les comportements hérités peuvent également produire des avertissements. Par exemple, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) identifie l’utilisation d’un comportement de verrouillage de présentation obsolète comme un `CompatibilityIssue`.

Les avertissements dépendent du document source, du format cible, de l’opération et de la version d’Aspose.Slides. Ne supposez pas que chaque fichier génère un avertissement ou qu’un scénario corresponde toujours à une seule catégorie.

## **Gérer correctement les opérations interrompues**

Lorsque un rappel renvoie `ReturnAction::Abort`, n’utilisez pas un objet qui a échoué à charger et ne supposez pas qu’une sortie de rendu ou d’enregistrement soit complète. L’opération peut se terminer après la création d’un fichier de sortie mais avant son achèvement.

Enregistrez les résultats validés dans un chemin séparé tel que `validated-output.pptx`. Remplacez une présentation existante uniquement après que l’opération se soit terminée avec succès, que le rapport d’avertissement satisfasse la politique de l’application et que la sortie puisse être ouverte et vérifiée. Cela évite d’écraser un fichier source valide avec un résultat partiel ou rejeté.

Un rapport d’avertissement vide ne garantit pas que chaque fonctionnalité source ait été préservée. Appliquez toutes les vérifications de contenu et visuelles supplémentaires requises par l’application. Voir également [Open Presentations](/slides/fr/php-java/open-presentation/) et [Save Presentations](/slides/fr/php-java/save-presentation/).

## **FAQ**

**Une fonction de rappel d’avertissement peut‑elle gérer chaque erreur Aspose.Slides ?**

Non. Elle gère les conditions récupérables signalées comme avertissements. Les exceptions qui surviennent indépendamment du rappel doivent être gérées par l’application autour de l’appel de chargement, de rendu, de conversion ou d’enregistrement.

**Le fait de renvoyer `ReturnAction::Continue` garantit‑il une sortie identique ?**

Non. Elle ne fait que permettre la poursuite du traitement. La condition signalée peut encore entraîner des différences de données, de formatage ou de compatibilité, il faut donc examiner les types d’avertissement et les descriptions collectés.

**Comment une application peut‑elle identifier l’opération qui a produit un avertissement ?**

Créez une instance de rappel pour chaque opération et stockez une étape définie par l’application ainsi que les valeurs retournées par [getWarningType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iwarninginfo/#getWarningType--) et [getDescription](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iwarninginfo/#getDescription--), comme illustré dans l’exemple.