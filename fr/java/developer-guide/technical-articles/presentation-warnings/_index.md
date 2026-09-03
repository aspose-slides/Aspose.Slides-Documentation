---
title: Gérer les avertissements de présentation en Java
type: docs
weight: 90
url: /fr/java/presentation-warnings/
aliases:
- /java/obtenir-des-rappels-d-avertissement-pour-la-substitution-de-polices-dans-aspose-slides/
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
- Java
- Aspose.Slides
description: "Apprenez à collecter, classer et traiter les avertissements lors du chargement, du rendu, de la conversion et de l’enregistrement des présentations avec Aspose.Slides pour Java."
---
## **Vue d'ensemble**

Aspose.Slides peut signaler des problèmes récupérables lors du chargement, du rendu, de la conversion ou de l’enregistrement d’une présentation. Les exemples incluent des enregistrements source endommagés, du contenu qui ne peut pas être conservé, la substitution de police et les limitations d’un format cible. Un rappel d’avertissement permet à une application d’enregistrer ces conditions et de décider si l’opération en cours peut se poursuivre.

Implémentez l’interface [IWarningCallback](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iwarningcallback/) et examinez les valeurs [getWarningType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iwarninginfo/#getWarningType--) et [getDescription](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iwarninginfo/#getDescription--) fournies via [IWarningInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iwarninginfo/). Retournez [ReturnAction.Continue](https://reference.aspose.com/slides/fr/java/com.aspose.slides/returnaction/#Continue) pour accepter l’avertissement ou [ReturnAction.Abort](https://reference.aspose.com/slides/fr/java/com.aspose.slides/returnaction/#Abort) pour arrêter l’opération.

Utilisez [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/fr/java/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) pour les avertissements générés lors de l’ouverture d’une présentation. Les classes d’options de rendu et d’exportation héritent de [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/fr/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-), qui reçoit les avertissements du rendu de diapositives, de la conversion et de l’enregistrement. Comme l’avertissement lui‑même ne identifie pas l’opération de l’application, associez chaque instance de rappel à une étape d’opération lorsque vous créez un rapport combiné.

## **Avertissements et exceptions**

Un avertissement décrit une condition dont Aspose.Slides peut se remettre si le rappel renvoie `ReturnAction.Continue`. Une exception signifie que l’opération demandée ne peut pas s’achever normalement ; les exceptions ne sont pas converties en avertissements et ne peuvent pas être gérées par une politique d’avertissement.

Retourner `ReturnAction.Abort` demande au répartiteur d’avertissement de terminer l’opération en cours en levant une exception. L’exception publique dépend de l’opération et du format de la présentation. Par exemple, le chargement peut déclencher une [PptxReadException](https://reference.aspose.com/slides/fr/java/com.aspose.slides/pptxreadexception/) ou une [PptReadException](https://reference.aspose.com/slides/fr/java/com.aspose.slides/pptreadexception/), tandis que l’enregistrement ou l’exportation peut déclencher une [PptxException](https://reference.aspose.com/slides/fr/java/com.aspose.slides/pptxexception/). Gérez l’exception à la frontière de l’opération et utilisez le rapport d’avertissement pour déterminer si la politique de l’application a provoqué la terminaison au lieu de vous fier à un sous‑type d’exception ou à un message. Le rappel enregistre l’avertissement avant de renvoyer `ReturnAction.Abort`, garantissant que la raison reste disponible pour l’application.

## **Catégories d’avertissement**

La classe [WarningType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/warningtype/) fournit des constantes entières pour les catégories suivantes :

| Type d'avertissement | Signification | Politique typique |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/fr/java/com.aspose.slides/warningtype/#SourceFileCorruption) | La présentation source contient des corruptions qui peuvent rendre un document enregistré dans son format original inutilisable. | Abort. |
| [DataLoss](https://reference.aspose.com/slides/fr/java/com.aspose.slides/warningtype/#DataLoss) | Le texte, les graphiques, les images ou d’autres données peuvent être absents après le chargement ou l’enregistrement. | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/fr/java/com.aspose.slides/warningtype/#MajorFormattingLoss) | La présentation peut perdre un formatage important. | Abort en mode de validation stricte ; sinon enregistrer et continuer. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/fr/java/com.aspose.slides/warningtype/#MinorFormattingLoss) | Une différence de formatage limitée peut survenir. | Enregistrer pour le diagnostic et continuer. |
| [CompatibilityIssue](https://reference.aspose.com/slides/fr/java/com.aspose.slides/warningtype/#CompatibilityIssue) | Le résultat peut ne pas s’ouvrir ou fonctionner correctement dans certaines applications ou versions antérieures. | Consigner et continuer sauf si la compatibilité est obligatoire. |
| [UnexpectedContent](https://reference.aspose.com/slides/fr/java/com.aspose.slides/warningtype/#UnexpectedContent) | La source contient du contenu non pris en charge ou non reconnu dont l’effet peut ne pas être encore connu. | Enregistrer et continuer, ou traiter comme une erreur dans une politique stricte. |

La catégorie doit guider la décision de politique. Conservez la valeur renvoyée par [getDescription](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iwarninginfo/#getDescription--) pour le diagnostic, mais ne vous fiez pas à sa formulation dans la logique de l’application, car le texte du message peut varier selon les scénarios d’avertissement et les versions du produit.

## **Collecter et classer les avertissements**

L’exemple suivant utilise un rapport au niveau de l’application pour l’ensemble du pipeline de traitement. Une instance de rappel séparée étiquette les avertissements provenant du chargement, du rendu, de la conversion PDF et de l’enregistrement PPTX. La politique interrompt en cas de corruption de la source ou de perte de données, interrompt éventuellement en cas de perte de formatage majeure, et continue pour les autres avertissements.

```java
import com.aspose.slides.IImage;
import com.aspose.slides.IWarningCallback;
import com.aspose.slides.IWarningInfo;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import com.aspose.slides.ReturnAction;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.WarningType;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

class PresentationWarningExample {
    public static void main(String[] args) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        boolean completed = processPresentation("input.pptx", report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, report, policy);
            }
            finally {
                presentation.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Loading stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean renderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy) {
        if (presentation.getSlides().size() == 0) {
            System.err.println("Rendering stopped: the presentation has no slides.");
            return false;
        }

        try {
            RenderingOptions options = new RenderingOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Rendering, report, policy);
            options.setWarningCallback(callback);

            IImage image = presentation.getSlides().get_Item(0).getImage(options);
            try {
                image.save("slide-1.png", ImageFormat.Png);
                return true;
            }
            finally {
                image.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Rendering stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean convertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            presentation.save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            presentation.save("validated-output.pptx", SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Saving stopped: " + exception.getMessage());
            return false;
        }
    }

    private static String warningTypeName(int warningType) {
        switch (warningType) {
            case WarningType.SourceFileCorruption:
                return "SourceFileCorruption";
            case WarningType.DataLoss:
                return "DataLoss";
            case WarningType.MajorFormattingLoss:
                return "MajorFormattingLoss";
            case WarningType.MinorFormattingLoss:
                return "MinorFormattingLoss";
            case WarningType.CompatibilityIssue:
                return "CompatibilityIssue";
            case WarningType.UnexpectedContent:
                return "UnexpectedContent";
            default:
                return "Unknown (" + warningType + ")";
        }
    }

    private enum OperationStage {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private static final class WarningEntry {
        final OperationStage stage;
        final int type;
        final String description;

        WarningEntry(OperationStage stage, int type, String description) {
            this.stage = stage;
            this.type = type;
            this.description = description;
        }
    }

    private static final class WarningReport {
        private final List<WarningEntry> entries = new ArrayList<WarningEntry>();

        List<WarningEntry> getEntries() {
            return Collections.unmodifiableList(entries);
        }

        void add(OperationStage stage, IWarningInfo warning) {
            WarningEntry entry = new WarningEntry(stage, warning.getWarningType(), warning.getDescription());
            entries.add(entry);
        }
    }

    private static final class WarningPolicy {
        private final boolean abortOnMajorFormattingLoss;

        WarningPolicy(boolean abortOnMajorFormattingLoss) {
            this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        int getAction(int warningType) {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss) {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && abortOnMajorFormattingLoss) {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private static final class ReportingWarningCallback implements IWarningCallback {
        private final OperationStage stage;
        private final WarningReport report;
        private final WarningPolicy policy;

        ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy) {
            this.stage = stage;
            this.report = report;
            this.policy = policy;
        }

        @Override
        public int warning(IWarningInfo warning) {
            report.add(stage, warning);
            return policy.getAction(warning.getWarningType());
        }
    }
}
```

Passez `false` à `abortOnMajorFormattingLoss` lors de la création de `WarningPolicy` si les différences de formatage majeures sont acceptables. Les problèmes de compatibilité, les pertes de formatage mineures et le contenu inattendu sont toujours conservés dans le rapport même lorsque l’opération continue. Étendez `WarningPolicy.getAction` si l’application doit rejeter l’une de ces catégories.

## **Scénarios d’avertissement courants**

Les avertissements peuvent apparaître à différentes étapes d’un flux de travail :

- **Signatures numériques :** Une présentation signée peut générer un avertissement lors du chargement indiquant que sa signature sera perdue pendant le traitement. Aspose.Slides signale cette condition `DataLoss` via [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentationsignedwarninginfo/). Un rappel au stade de chargement permet à l’application de rejeter le fichier ou d’accepter explicitement la perte signalée.
- **Substitution de police :** Une police indisponible peut être remplacée pendant le rendu ou l’exportation d’une diapositive. Les avertissements de substitution de police sont signalés comme `DataLoss`, ainsi la politique stricte ci‑dessus interrompt même si l’application considérerait un remplacement particulier comme visuellement acceptable. Pour observer ce comportement, utilisez une présentation d’entrée contenant du texte dans une police non disponible à l’exécution. La description de l’avertissement identifie la substitution ; configurez les polices requises ou les [règles de substitution de police](/slides/fr/java/font-substitution/) avant de réessayer.
- **Contenu non pris en charge ou inattendu :** Un chargeur peut rencontrer des enregistrements ou des fonctionnalités de présentation qu’il ne reconnaît pas. De tels avertissements peuvent utiliser `UnexpectedContent`, ou une catégorie plus sévère lorsque des données ou un formatage sont connus pour être affectés.
- **Compatibilité de format :** Enregistrer dans un autre format de présentation peut omettre des fonctionnalités ou produire un résultat qui se comporte différemment dans certaines applications. Par exemple, enregistrer une présentation contenant plus de huit repères de dessin horizontaux ou verticaux dans le format PPT hérité signale un `CompatibilityIssue`. Le rappel au stade d’enregistrement peut enregistrer la perte et continuer, ou la rejeter si la préservation de tous les repères est requise.
- **Comportement de chargement :** Les options de chargement et les comportements hérités peuvent également générer des avertissements. Par exemple, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) identifie l’utilisation d’un comportement de verrouillage de présentation obsolète comme un `CompatibilityIssue`.

Les avertissements dépendent du document source, du format cible, de l’opération et de la version d’Aspose.Slides. Ne supposez pas que chaque fichier génère un avertissement ou qu’un scénario correspond toujours à une seule catégorie.

## **Gérer en toute sécurité les opérations interrompues**

Lorsque un rappel renvoie `ReturnAction.Abort`, n’utilisez pas un objet qui n’a pas pu être chargé et ne supposez pas qu’une sortie de rendu ou d’enregistrement soit complète. L’opération peut se terminer après la création d’un fichier de sortie mais avant son achèvement.

Enregistrez les résultats validés dans un chemin séparé tel que `validated-output.pptx`. Remplacez une présentation existante uniquement après que l’opération se soit terminée avec succès, que le rapport d’avertissement respecte la politique de l’application, et que la sortie puisse être ouverte et vérifiée. Cela évite d’écraser un fichier source valide avec un résultat partiel ou rejeté.

Un rapport d’avertissement vide ne garantit pas que chaque fonctionnalité source a été conservée. Appliquez les vérifications de contenu et visuelles supplémentaires requises par l’application. Voir aussi [Open Presentations](/slides/fr/java/open-presentation/) et [Save Presentations](/slides/fr/java/save-presentation/).

## **FAQ**

**Un rappel d’avertissement peut‑il gérer chaque erreur d’Aspose.Slides ?**

Non. Il gère les conditions récupérables signalées comme avertissements. Les exceptions qui se produisent indépendamment du rappel doivent être gérées par l’application autour de l’appel de chargement, de rendu, de conversion ou d’enregistrement.

**Le fait de renvoyer `ReturnAction.Continue` garantit‑il une sortie identique ?**

Non. Cela ne fait que permettre la poursuite du traitement. La condition signalée peut encore entraîner des différences de données, de formatage ou de compatibilité, il faut donc examiner les types d’avertissements et les descriptions collectés.

**Comment une application peut‑elle identifier l’opération qui a généré un avertissement ?**

Créez une instance de rappel pour chaque opération et stockez une étape définie par l’application avec les valeurs renvoyées par [getWarningType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iwarninginfo/#getWarningType--) et [getDescription](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iwarninginfo/#getDescription--), comme illustré dans l’exemple.