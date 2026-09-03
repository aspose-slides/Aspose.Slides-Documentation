---
title: Gérer les avertissements de présentation sur Android
type: docs
weight: 90
url: /fr/androidjava/presentation-warnings/
aliases:
- /androidjava/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- rappel d'avertissement
- politique d'avertissement
- perte de données
- corruption de la source
- problème de compatibilité
- substitution de police
- signature numérique
- chargement de présentation
- rendu de présentation
- conversion de présentation
- enregistrement de présentation
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Apprenez à collecter, classer et gérer les avertissements lors du chargement, du rendu, de la conversion et de l'enregistrement de présentations avec Aspose.Slides pour Android via Java."
---
## **Aperçu**

Aspose.Slides peut signaler des problèmes récupérables lors du chargement, du rendu, de la conversion ou de l’enregistrement d’une présentation. Par exemple, des enregistrements source endommagés, du contenu qui ne peut être préservé, la substitution de police et les limitations d’un format cible. Un rappel d’avertissement permet à une application d’enregistrer ces conditions et de décider si l’opération en cours peut se poursuivre.

Implémentez l’interface [IWarningCallback](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iwarningcallback/) et examinez les valeurs [getWarningType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) et [getDescription](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) renvoyées via [IWarningInfo](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iwarninginfo/). Retournez [ReturnAction.Continue](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/returnaction/#Continue) pour accepter l’avertissement ou [ReturnAction.Abort](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/returnaction/#Abort) pour interrompre l’opération.

Utilisez [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) pour les avertissements déclenchés lors de l’ouverture d’une présentation. Les classes d’options de rendu et d’exportation héritent de [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-), qui reçoivent les avertissements provenant du rendu de diapositives, de la conversion et de l’enregistrement. Comme l’avertissement ne permet pas d’identifier l’opération de l’application, associez chaque instance de rappel à une étape d’opération lors de la création d’un rapport combiné.

## **Avertissements et Exceptions**

Un avertissement décrit une condition dont Aspose.Slides peut se remettre si le rappel renvoie `ReturnAction.Continue`. Une exception signifie que l’opération demandée ne peut pas se terminer normalement ; les exceptions ne sont pas converties en avertissements et ne peuvent pas être gérées par une politique d’avertissement.

Le fait de retourner `ReturnAction.Abort` demande au répartiteur d’avertissements de terminer l’opération en cours en levant une exception. L’exception publique dépend de l’opération et du format de la présentation. Par exemple, le chargement peut déclencher une [PptxReadException](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pptxreadexception/) ou une [PptReadException](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pptreadexception/), tandis que l’enregistrement ou l’exportation peut déclencher une [PptxException](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pptxexception/). Gérez l’exception à la limite de l’opération et utilisez le rapport d’avertissement pour déterminer si la politique de l’application a causé la terminaison au lieu de se fier à un sous‑type d’exception ou à un message. Le rappel enregistre l’avertissement avant de retourner `ReturnAction.Abort`, garantissant que la raison reste disponible pour l’application.

## **Catégories d’avertissement**

La classe [WarningType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/warningtype/) fournit des constantes entières pour les catégories suivantes :

| Type d’avertissement | Signification | Politique typique |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/warningtype/#SourceFileCorruption) | La présentation source contient des corruptions pouvant rendre un document enregistré dans son format original inutilisable. | Abandonner. |
| [DataLoss](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/warningtype/#DataLoss) | Le texte, les graphiques, les images ou d’autres données peuvent être absents après le chargement ou l’enregistrement. | Abandonner. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/warningtype/#MajorFormattingLoss) | La présentation peut perdre un formatage important. | Abandonner en mode de validation strict ; sinon enregistrer et continuer. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/warningtype/#MinorFormattingLoss) | Une différence de formatage limitée peut survenir. | Enregistrer à des fins de diagnostic et continuer. |
| [CompatibilityIssue](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/warningtype/#CompatibilityIssue) | Le résultat peut ne pas s’ouvrir ou ne pas se comporter correctement dans certaines applications ou versions antérieures. | Journaliser et continuer sauf si la compatibilité est obligatoire. |
| [UnexpectedContent](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/warningtype/#UnexpectedContent) | La source contient du contenu non pris en charge ou non reconnu dont l’effet peut ne pas être encore connu. | Enregistrer et continuer, ou considérer comme une erreur dans une politique stricte. |

La catégorie doit guider la décision de politique. Conservez la valeur renvoyée par [getDescription](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) à des fins de diagnostic, mais ne vous fiez pas à sa formulation pour la logique de l’application car le texte du message peut varier selon les scénarios d’avertissement et les versions du produit.

## **Collecter et classer les avertissements**

L’exemple suivant utilise un rapport au niveau de l’application pour l’ensemble du pipeline de traitement. Une instance de rappel distincte étiquette les avertissements provenant du chargement, du rendu, de la conversion PDF et de l’enregistrement PPTX. La politique interrompt en cas de corruption de la source ou de perte de données, interrompt éventuellement en cas de perte de formatage majeure, et continue pour les autres avertissements.

Placez `input.pptx` dans un répertoire d’application accessible en écriture et transmettez ce répertoire à `PresentationWarningExample.run`. L’exemple enregistre ses sorties dans le même répertoire. Exécutez le traitement de la présentation sur un thread d’arrière‑plan pour garder l’interface utilisateur Android réactive.

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
import java.io.File;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class PresentationWarningExample {
    public static void run(File dataDirectory) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        File inputFile = new File(dataDirectory, "input.pptx");
        boolean completed = processPresentation(inputFile.getAbsolutePath(), dataDirectory, report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, dataDirectory, report, policy);
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

    private static boolean renderFirstSlide(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
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
                File outputFile = new File(dataDirectory, "slide-1.png");
                image.save(outputFile.getAbsolutePath(), ImageFormat.Png);
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

    private static boolean convertToPdf(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "converted.pdf");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "validated-output.pptx");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx, options);
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

Passez `false` pour `abortOnMajorFormattingLoss` lors de la construction de `WarningPolicy` si les différences de formatage majeures sont acceptables. Les problèmes de compatibilité, la perte de formatage mineure et le contenu inattendu restent néanmoins consignés dans le rapport même si l’opération continue. Étendez `WarningPolicy.getAction` si l’application doit rejeter l’une de ces catégories.

## **Scénarios d’avertissement courants**

Les avertissements peuvent apparaître à différentes étapes d’un flux de travail :

- **Signatures numériques :** Une présentation signée peut produire un avertissement lors du chargement indiquant que sa signature sera perdue pendant le traitement. Aspose.Slides signale cette condition `DataLoss` via [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentationsignedwarninginfo/). Un rappel au stade de chargement permet à l’application de rejeter le fichier ou d’accepter explicitement la perte signalée.
- **Substitution de police :** Une police indisponible peut être remplacée pendant le rendu ou l’exportation d’une diapositive. Les avertissements de substitution de police sont signalés comme `DataLoss`, ainsi la politique stricte ci‑dessus interrompt même si l’application considérerait un remplacement particulier comme visuellement acceptable. Pour observer ce comportement, utilisez une présentation d’entrée contenant du texte dans une police indisponible à l’exécution. La description de l’avertissement identifie la substitution ; configurez les polices requises ou [règles de substitution de police](/slides/fr/androidjava/font-substitution/) avant de réessayer.
- **Contenu non pris en charge ou inattendu :** Un chargeur peut rencontrer des enregistrements de présentation ou des fonctionnalités qu’il ne reconnaît pas. De tels avertissements peuvent utiliser `UnexpectedContent`, ou une catégorie plus sévère lorsque des données ou du formatage sont connus pour être affectés.
- **Compatibilité de format :** L’enregistrement dans un autre format de présentation peut omettre des fonctionnalités ou produire un résultat qui se comporte différemment dans certaines applications. Par exemple, enregistrer une présentation avec plus de huit repères de dessin horizontaux ou verticaux dans une PPT legacy signale un `CompatibilityIssue`. Le rappel au stade d’enregistrement peut consigner la perte et continuer, ou la rejeter si la préservation de tous les repères est requise.
- **Comportement de chargement :** Les options de chargement et les comportements hérités peuvent également produire des avertissements. Par exemple, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) identifie l’utilisation d’un comportement de verrouillage de présentation obsolète comme un `CompatibilityIssue`.

Les avertissements dépendent du document source, du format cible, de l’opération et de la version d’Aspose.Slides. Ne supposez pas que chaque fichier produit un avertissement ou qu’un scénario correspond toujours à une seule catégorie.

## **Gérer en toute sécurité les opérations interrompues**

Lorsque un rappel renvoie `ReturnAction.Abort`, n’utilisez pas un objet qui n’a pas pu être chargé et ne supposez pas qu’une sortie de rendu ou d’enregistrement est complète. L’opération peut se terminer après la création d’un fichier de sortie mais avant son achèvement.

Enregistrez les résultats validés dans un chemin distinct tel que `validated-output.pptx`. Remplacez une présentation existante uniquement après que l’opération se soit terminée avec succès, que le rapport d’avertissement satisfasse la politique de l’application et que la sortie puisse être ouverte et vérifiée. Cela évite d’écraser un fichier source valide avec un résultat partiel ou rejeté.

Un rapport d’avertissement vide ne garantit pas que chaque fonctionnalité source a été conservée. Appliquez les contrôles de contenu et visuels supplémentaires requis par l’application. Voir également [Ouvrir des présentations](/slides/fr/androidjava/open-presentation/) et [Enregistrer des présentations](/slides/fr/androidjava/save-presentation/).

## **FAQ**

**Un rappel d’avertissement peut‑il gérer chaque erreur d’Aspose.Slides ?**

Non. Il gère les conditions récupérables signalées sous forme d’avertissements. Les exceptions qui surviennent indépendamment du rappel doivent être traitées par l’application autour de l’appel de chargement, de rendu, de conversion ou d’enregistrement.

**Le fait de retourner `ReturnAction.Continue` garantit‑il une sortie identique ?**

Non. Cela ne fait que permettre la poursuite du traitement. La condition signalée peut toujours entraîner des différences de données, de formatage ou de compatibilité, il faut donc examiner les types d’avertissements et leurs descriptions collectés.

**Comment une application peut‑elle identifier l’opération qui a généré un avertissement ?**

Créez une instance de rappel pour chaque opération et stockez une étape définie par l’application ainsi que les valeurs renvoyées par [getWarningType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) et [getDescription](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iwarninginfo/#getDescription--), comme indiqué dans l’exemple.