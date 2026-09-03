---
title: Gérer les avertissements de présentation dans Node.js
type: docs
weight: 90
url: /fr/nodejs-java/presentation-warnings/
aliases:
- /nodejs-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- JavaScript
- Node.js
- Aspose.Slides
description: "Apprenez comment collecter, classer et gérer les avertissements lors du chargement, du rendu, de la conversion et de l'enregistrement de présentations avec Aspose.Slides pour Node.js via Java."
---
## **Vue d'ensemble**

Aspose.Slides peut signaler des problèmes récupérables lors du chargement, du rendu, de la conversion ou de l'enregistrement d'une présentation. Les exemples incluent des enregistrements source endommagés, du contenu qui ne peut pas être préservé, la substitution de polices et les limitations d'un format cible. Un rappel d'avertissement permet à une application d'enregistrer ces conditions et de décider si l'opération en cours peut se poursuivre.

Utilisez `java.newProxy` pour implémenter l'interface Java [IWarningCallback](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iwarningcallback/) en JavaScript et examiner les valeurs [getWarningType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iwarninginfo/#getWarningType--) et [getDescription](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iwarninginfo/#getDescription--) fournies via [IWarningInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iwarninginfo/). Retournez [ReturnAction.Continue](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/returnaction/#Continue) pour accepter l'avertissement ou [ReturnAction.Abort](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/returnaction/#Abort) pour arrêter l'opération.

Utilisez [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/loadoptions/#setWarningCallback) pour les avertissements générés lors de l'ouverture d'une présentation. Les classes d'options de rendu et d'exportation héritent de [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/saveoptions/#setWarningCallback), qui reçoit les avertissements du rendu des diapositives, de la conversion et de l'enregistrement. Comme l'avertissement lui-même n'identifie pas l'opération de l'application, associez chaque instance de rappel à une étape d'opération lorsque vous créez un rapport combiné.

## **Avertissements et Exceptions**

Un avertissement décrit une condition dont Aspose.Slides peut se remettre si le rappel renvoie `ReturnAction.Continue`. Une exception signifie que l'opération demandée ne peut pas se terminer normalement; les exceptions ne sont pas converties en avertissements et ne peuvent pas être gérées par une politique d'avertissement.

Le fait de renvoyer `ReturnAction.Abort` demande au répartiteur d'avertissements de terminer l'opération en cours en levant une exception. L'exception publique dépend de l'opération et du format de la présentation. Par exemple, le chargement peut déclencher une [PptxReadException](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pptxreadexception/) ou une [PptReadException](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pptreadexception/), tandis que l'enregistrement ou l'exportation peut déclencher une [PptxException](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pptxexception/). Capturez l'erreur provenant du pont Java à la frontière de l'opération et utilisez le rapport d'avertissement pour déterminer si la politique de l'application a provoqué l'arrêt au lieu de vous fier à un sous-type d'exception ou à un message. Le rappel enregistre l'avertissement avant de renvoyer `ReturnAction.Abort`, garantissant que la raison reste disponible pour l'application.

## **Catégories d'avertissement**

La classe [WarningType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/warningtype/) fournit des constantes entières pour les catégories suivantes :

| Type d'avertissement | Signification | Politique typique |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/warningtype/#SourceFileCorruption) | La présentation source contient une corruption pouvant rendre un document enregistré dans son format d'origine inutilisable. | Abort. |
| [DataLoss](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/warningtype/#DataLoss) | Le texte, les graphiques, les images ou d'autres données peuvent être absents après le chargement ou l'enregistrement. | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/warningtype/#MajorFormattingLoss) | La présentation peut perdre un formatage important. | Abort en mode de validation strict ; sinon enregistrer et continuer. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/warningtype/#MinorFormattingLoss) | Une différence de formatage limitée peut se produire. | Enregistrer pour diagnostics et continuer. |
| [CompatibilityIssue](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/warningtype/#CompatibilityIssue) | Le résultat peut ne pas s'ouvrir ou se comporter correctement dans certaines applications ou versions plus anciennes. | Consigner et continuer sauf si la compatibilité est obligatoire. |
| [UnexpectedContent](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/warningtype/#UnexpectedContent) | La source contient du contenu non pris en charge ou non reconnu dont l'effet peut ne pas être encore connu. | Enregistrer et continuer, ou traiter comme une erreur dans une politique stricte. |

La catégorie doit guider la décision de politique. Conservez la valeur renvoyée par [getDescription](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iwarninginfo/#getDescription--) pour le diagnostic, mais ne vous fiez pas à sa formulation pour la logique de l'application, car le texte du message peut varier selon les scénarios d'avertissement et les versions du produit.

## **Collecter et classer les avertissements**

L'exemple JavaScript suivant utilise un rapport au niveau de l'application pour l'ensemble du pipeline de traitement. Une instance de rappel séparée étiquette les avertissements provenant du chargement, du rendu, de la conversion PDF et de l'enregistrement PPTX. La politique annule en cas de corruption de la source ou de perte de données, annule éventuellement en cas de perte de formatage majeure, et continue pour les autres avertissements.

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

class WarningPolicy {
    constructor(abortOnMajorFormattingLoss) {
        this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
    }

    getAction(warningType) {
        if (warningType === aspose.slides.WarningType.SourceFileCorruption || warningType === aspose.slides.WarningType.DataLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        if (warningType === aspose.slides.WarningType.MajorFormattingLoss && this.abortOnMajorFormattingLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        return aspose.slides.ReturnAction.Continue;
    }
}

function createReportingWarningCallback(stage, report, policy) {
    return java.newProxy("com.aspose.slides.IWarningCallback", {
        warning: function (warning) {
            const type = warning.getWarningType();
            const description = warning.getDescription();
            report.push({ stage, type, description });
            return policy.getAction(type);
        }
    });
}

function processPresentation(inputPath, report, policy) {
    try {
        const loadOptions = new aspose.slides.LoadOptions();
        const callback = createReportingWarningCallback("Loading", report, policy);
        loadOptions.setWarningCallback(callback);

        const presentation = new aspose.slides.Presentation(inputPath, loadOptions);
        try {
            if (!renderFirstSlide(presentation, report, policy)) {
                return false;
            }

            if (!convertToPdf(presentation, report, policy)) {
                return false;
            }

            return saveValidatedCopy(presentation, report, policy);
        } finally {
            presentation.dispose();
        }
    } catch (error) {
        console.error("Loading stopped: " + error.message);
        return false;
    }
}

function renderFirstSlide(presentation, report, policy) {
    if (presentation.getSlides().size() === 0) {
        console.error("Rendering stopped: the presentation has no slides.");
        return false;
    }

    try {
        const options = new aspose.slides.RenderingOptions();
        const callback = createReportingWarningCallback("Rendering", report, policy);
        options.setWarningCallback(callback);

        const image = presentation.getSlides().get_Item(0).getImage(options);
        try {
            image.save("slide-1.png", aspose.slides.ImageFormat.Png);
            return true;
        } finally {
            image.dispose();
        }
    } catch (error) {
        console.error("Rendering stopped: " + error.message);
        return false;
    }
}

function convertToPdf(presentation, report, policy) {
    try {
        const options = new aspose.slides.PdfOptions();
        const callback = createReportingWarningCallback("Conversion", report, policy);
        options.setWarningCallback(callback);

        presentation.save("converted.pdf", aspose.slides.SaveFormat.Pdf, options);
        return true;
    } catch (error) {
        console.error("Conversion stopped: " + error.message);
        return false;
    }
}

function saveValidatedCopy(presentation, report, policy) {
    try {
        const options = new aspose.slides.PptxOptions();
        const callback = createReportingWarningCallback("Saving", report, policy);
        options.setWarningCallback(callback);

        presentation.save("validated-output.pptx", aspose.slides.SaveFormat.Pptx, options);
        return true;
    } catch (error) {
        console.error("Saving stopped: " + error.message);
        return false;
    }
}

function warningTypeName(warningType) {
    switch (warningType) {
        case aspose.slides.WarningType.SourceFileCorruption:
            return "SourceFileCorruption";
        case aspose.slides.WarningType.DataLoss:
            return "DataLoss";
        case aspose.slides.WarningType.MajorFormattingLoss:
            return "MajorFormattingLoss";
        case aspose.slides.WarningType.MinorFormattingLoss:
            return "MinorFormattingLoss";
        case aspose.slides.WarningType.CompatibilityIssue:
            return "CompatibilityIssue";
        case aspose.slides.WarningType.UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" + warningType + ")";
    }
}

const report = [];
const policy = new WarningPolicy(true);
const completed = processPresentation("input.pptx", report, policy);

console.log(completed ? "Processing completed." : "Processing stopped.");

for (const entry of report) {
    const typeName = warningTypeName(entry.type);
    console.log("[" + entry.stage + "] " + typeName + ": " + entry.description);
}
```

Passez `false` à `abortOnMajorFormattingLoss` lors de la construction de `WarningPolicy` si les différences de formatage majeures sont acceptables. Les problèmes de compatibilité, la perte de formatage mineur et le contenu inattendu restent enregistrés dans le rapport même lorsque l'opération continue. Étendez `WarningPolicy.getAction` si l'application doit rejeter l'une de ces catégories.

## **Scénarios d'avertissement courants**

Les avertissements peuvent apparaître à différentes étapes d'un flux de travail :

- **Signatures numériques** : Une présentation signée peut générer un avertissement lors du chargement indiquant que sa signature sera perdue pendant le traitement. Aspose.Slides signale cette condition `DataLoss` via [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentationsignedwarninginfo/). Un rappel au stade de chargement permet à l'application de rejeter le fichier ou d'accepter explicitement la perte signalée.
- **Substitution de police** : Une police indisponible peut être remplacée lors du rendu ou de l'exportation d'une diapositive. Les avertissements de substitution de police sont signalés comme `DataLoss`, de sorte que la politique stricte ci-dessus annule même si l'application considérerait un remplacement particulier comme visuellement acceptable. Pour observer ce comportement, utilisez une présentation d’entrée contenant du texte dans une police non disponible pour le runtime. La description de l’avertissement identifie la substitution ; configurez les polices requises ou les [règles de substitution de police](/slides/fr/nodejs-java/font-substitution/) avant de réessayer.
- **Contenu non pris en charge ou inattendu** : Un chargeur peut rencontrer des enregistrements ou des fonctionnalités de présentation qu'il ne reconnaît pas. De tels avertissements peuvent utiliser `UnexpectedContent`, ou une catégorie plus sévère lorsque des données ou un formatage sont connus pour être affectés.
- **Compatibilité de format** : L'enregistrement dans un autre format de présentation peut omettre des fonctionnalités ou produire un résultat qui se comporte différemment dans certaines applications. Par exemple, enregistrer une présentation contenant plus de huit repères de dessin horizontaux ou verticaux dans le format PPT hérité génère un `CompatibilityIssue`. Le rappel au stade d’enregistrement peut enregistrer la perte et continuer, ou la rejeter si la conservation de tous les repères est requise.
- **Comportement de chargement** : Les options de chargement et les comportements hérités peuvent également générer des avertissements. Par exemple, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) identifie l'utilisation d'un comportement de verrouillage de présentation obsolète comme un `CompatibilityIssue`.

Les avertissements dépendent du document source, du format cible, de l'opération et de la version d'Aspose.Slides. Ne supposez pas que chaque fichier génère un avertissement ou qu'un scénario correspond toujours à une seule catégorie.

## **Gérer en toute sécurité les opérations interrompues**

Lorsque un rappel renvoie `ReturnAction.Abort`, n'utilisez pas un objet qui n'a pas pu être chargé et ne supposez pas qu'une sortie de rendu ou d'enregistrement soit complète. L'opération peut se terminer après la création d'un fichier de sortie mais avant son achèvement.

Enregistrez les résultats validés dans un chemin distinct, par exemple `validated-output.pptx`. Remplacez une présentation existante uniquement après que l'opération se soit terminée avec succès, que le rapport d'avertissement satisfasse la politique de l'application et que la sortie puisse être ouverte et vérifiée. Cela évite d'écraser un fichier source valide avec un résultat partiel ou rejeté.

Un rapport d'avertissement vide ne garantit pas que chaque fonctionnalité source a été préservée. Appliquez toutes les vérifications de contenu et visuelles supplémentaires requises par l'application. Voir également [Open Presentations](/slides/fr/nodejs-java/open-presentation/) et [Save Presentations](/slides/fr/nodejs-java/save-presentation/).

## **FAQ**

**Un rappel d'avertissement peut‑il gérer chaque erreur Aspose.Slides ?**

Non. Il gère les conditions récupérables signalées comme avertissements. Les exceptions qui surviennent indépendamment du rappel doivent être gérées par l'application autour de l'appel de chargement, de rendu, de conversion ou d'enregistrement.

**Le retour de `ReturnAction.Continue` garantit‑il une sortie identique ?**

Non. Il ne fait que permettre la poursuite du traitement. La condition signalée peut encore entraîner des différences de données, de formatage ou de compatibilité, il faut donc examiner les types d'avertissement et les descriptions collectés.

**Comment une application peut‑elle identifier l'opération qui a produit un avertissement ?**

Créez une instance de rappel pour chaque opération et stockez une étape définie par l'application ainsi que les valeurs renvoyées par [getWarningType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iwarninginfo/#getWarningType--) et [getDescription](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iwarninginfo/#getDescription--), comme illustré dans l'exemple.