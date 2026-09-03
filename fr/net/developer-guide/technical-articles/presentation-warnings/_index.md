---
title: Gérer les avertissements de présentation en .NET
type: docs
weight: 120
url: /fr/net/presentation-warnings/
aliases:
- /net/obtenir-des-callbacks-d-avertissement-pour-la-substitution-de-polices-dans-aspose-slides/
keywords:
- callback d'avertissement
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
- .NET
- C#
- Aspose.Slides
description: "Apprenez à collecter, classer et agir sur les avertissements lors du chargement, du rendu, de la conversion et de l'enregistrement des présentations avec Aspose.Slides pour .NET."
---
## **Vue d'ensemble**

Aspose.Slides peut signaler des problèmes récupérables lorsqu'il charge, rend, convertit ou enregistre une présentation. Les exemples incluent des enregistrements source endommages, du contenu qui ne peut pas être conserve, la substitution de polices et les limitations d'un format cible. Un rappel d'avertissement permet a une application d'enregistrer ces conditions et de décider si l'opération en cours peut se poursuivre.

Implémentez l'interface [IWarningCallback](https://reference.aspose.com/slides/fr/net/aspose.slides.warnings/iwarningcallback/) et examinez les proprietes [WarningType](https://reference.aspose.com/slides/fr/net/aspose.slides.warnings/iwarninginfo/warningtype/) et [Description](https://reference.aspose.com/slides/fr/net/aspose.slides.warnings/iwarninginfo/description/) fournissees via [IWarningInfo](https://reference.aspose.com/slides/fr/net/aspose.slides.warnings/iwarninginfo/). Retournez [ReturnAction.Continue](https://reference.aspose.com/slides/fr/net/aspose.slides.warnings/returnaction/) pour accepter l'avertissement ou `ReturnAction.Abort` pour arreter l'operation.

Utilisez [LoadOptions.WarningCallback](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/warningcallback/) pour les avertissements generes lors de l'ouverture d'une presentation. Les classes d'options de rendu et d'exportation heritent de [SaveOptions.WarningCallback](https://reference.aspose.com/slides/fr/net/aspose.slides.export/saveoptions/warningcallback/), qui recoivent les avertissements du rendu des diapositives, de la conversion et de l'enregistrement. Comme l'avertissement lui-meme n'identifie pas l'operation de l'application, associez chaque instance de rappel a une etape d'operation lors de la creation d'un rapport combine.

## **Avertissements et Exceptions**

Un avertissement décrit une condition dont Aspose.Slides peut se remettre si le rappel retourne `ReturnAction.Continue`. Une exception signifie que l'operation demandee ne peut pas s'achever normalement ; les exceptions ne sont pas converties en avertissements et ne peuvent pas etre gerees par une politique d'avertissement.

Le retour de `ReturnAction.Abort` demande au distributeur d'avertissements de terminer l'operation en cours en levant une exception. L'exception publique depend de l'operation et du format de la presentation. Par exemple, le chargement peut generer une [PptxReadException](https://reference.aspose.com/slides/fr/net/aspose.slides/pptxreadexception/) ou une [PptReadException](https://reference.aspose.com/slides/fr/net/aspose.slides/pptreadexception/), tandis que l'enregistrement ou l'exportation peut generer une [PptxException](https://reference.aspose.com/slides/fr/net/aspose.slides/pptxexception/). Gerer l'exception a la limite de l'operation et utilisez le rapport d'avertissement pour determiner si la politique de l'application a cause la terminaison au lieu de se fier a un sous-type d'exception ou a un message. Le rappel enregistre l'avertissement avant de retourner `ReturnAction.Abort`, garantissant que la raison reste disponible pour l'application.

## **Catégories d'avertissement**

L'énumération [WarningType](https://reference.aspose.com/slides/fr/net/aspose.slides.warnings/warningtype/) fournit les catégories suivantes :

| Type d'avertissement | Signification | Politique typique |
| --- | --- | --- |
| `SourceFileCorruption` | La presentation source contient une corruption qui peut rendre un document enregistre dans son format original inutilisable. | Abort. |
| `DataLoss` | Du texte, des graphiques, des images ou d'autres donnees peuvent etre absents apres le chargement ou l'enregistrement. | Abort. |
| `MajorFormattingLoss` | La presentation peut perdre un formatage important. | Abort en mode validation stricte ; sinon enregistrer et continuer. |
| `MinorFormattingLoss` | Une difference de formatage limitee peut se produire. | Enregistrer pour le diagnostic et continuer. |
| `CompatibilityIssue` | Le resultat peut ne pas s'ouvrir ou se comporter correctement dans certaines applications ou versions anterieures. | Journaliser et continuer sauf si la compatibilite est obligatoire. |
| `UnexpectedContent` | La source contient du contenu non supporte ou non reconnu dont l'effet peut ne pas etre encore connu. | Enregistrer et continuer, ou traiter comme une erreur dans une politique stricte. |

La catégorie doit guider la decision de politique. Conservez `Description` pour le diagnostic, mais ne dependiez pas de sa formulation pour la logique de l'application car le texte du message peut varier entre les scenarios d'avertissement et les versions du produit.

## **Collecter et Classifier les Avertissements**

L'exemple suivant utilise un rapport au niveau de l'application pour l'ensemble du pipeline de traitement. Une instance de rappel distincte etiquette les avertissements provenant du chargement, du rendu, de la conversion PDF et de l'enregistrement PPTX. La politique interrompt en cas de corruption de la source ou de perte de donnees, interrompt eventuellement en cas de perte de formatage majeure, et continue pour les autres avertissements.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

internal static class PresentationWarningExample
{
    public static void Main()
    {
        var report = new WarningReport();
        var policy = new WarningPolicy(abortOnMajorFormattingLoss: true);
        var completed = ProcessPresentation("input.pptx", report, policy);

        Console.WriteLine(completed ? "Processing completed." : "Processing stopped.");

        foreach (var entry in report.Entries)
        {
            Console.WriteLine($"[{entry.Stage}] {entry.Type}: {entry.Description}");
        }
    }

    private static bool ProcessPresentation(string inputPath, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var loadOptions = new LoadOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Loading, report, policy)
            };

            using var presentation = new Presentation(inputPath, loadOptions);

            if (!RenderFirstSlide(presentation, report, policy))
            {
                return false;
            }

            if (!ConvertToPdf(presentation, report, policy))
            {
                return false;
            }

            return SaveValidatedCopy(presentation, report, policy);
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Loading stopped: {exception.Message}");
            return false;
        }
    }

    private static bool RenderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new RenderingOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Rendering, report, policy)
            };

            using var image = presentation.Slides[0].GetImage(options);
            image.Save("slide-1.png", ImageFormat.Png);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Rendering stopped: {exception.Message}");
            return false;
        }
    }

    private static bool ConvertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PdfOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Conversion, report, policy)
            };

            presentation.Save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Conversion stopped: {exception.Message}");
            return false;
        }
    }

    private static bool SaveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PptxOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Saving, report, policy)
            };

            presentation.Save("validated-output.pptx", SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Saving stopped: {exception.Message}");
            return false;
        }
    }

    private enum OperationStage
    {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private sealed class WarningEntry
    {
        public WarningEntry(OperationStage stage, WarningType type, string description)
        {
            Stage = stage;
            Type = type;
            Description = description;
        }

        public OperationStage Stage { get; }

        public WarningType Type { get; }

        public string Description { get; }
    }

    private sealed class WarningReport
    {
        private readonly List<WarningEntry> _entries = new List<WarningEntry>();

        public IReadOnlyList<WarningEntry> Entries => _entries;

        public void Add(OperationStage stage, IWarningInfo warning)
        {
            _entries.Add(new WarningEntry(stage, warning.WarningType, warning.Description));
        }
    }

    private sealed class WarningPolicy
    {
        private readonly bool _abortOnMajorFormattingLoss;

        public WarningPolicy(bool abortOnMajorFormattingLoss)
        {
            _abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        public ReturnAction GetAction(WarningType warningType)
        {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss)
            {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && _abortOnMajorFormattingLoss)
            {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private sealed class ReportingWarningCallback : IWarningCallback
    {
        private readonly OperationStage _stage;
        private readonly WarningReport _report;
        private readonly WarningPolicy _policy;

        public ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy)
        {
            _stage = stage;
            _report = report;
            _policy = policy;
        }

        public ReturnAction Warning(IWarningInfo warning)
        {
            _report.Add(_stage, warning);
            return _policy.GetAction(warning.WarningType);
        }
    }
}
```

Definissez `abortOnMajorFormattingLoss` à `false` lorsque les differences de formatage majeures sont acceptables. Les problemes de compatibilite, la perte de formatage mineure et le contenu inattendu sont toujours conserves dans le rapport meme si l'operation continue. Etendez `WarningPolicy.GetAction` si l'application doit rejeter l'une de ces categories.

## **Scenarios Courants d'Avertissement**

Les avertissements peuvent apparaître à differentes etapes d'un flux de travail :

- **Signatures numeriques :** Une presentation signee peut generer un avertissement lors du chargement indiquant que sa signature sera perdue pendant le traitement. Aspose.Slides signale cette condition `DataLoss` via [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/fr/net/aspose.slides.warnings/ipresentationsignedwarninginfo/). Un rappel au stade de chargement permet a l'application de rejeter le fichier ou d'accepter explicitement la perte signalee.
- **Substitution de police :** Une police indisponible peut etre remplacee pendant le rendu ou l'exportation d'une diapositive. Les avertissements de substitution de police sont signales comme `DataLoss`, ainsi la politique stricte ci-dessus interrompt meme si l'application considererait un remplacement particulier comme visuellement acceptable. Pour observer ce comportement, utilisez une presentation d'entree contenant du texte avec une police indisponible a l'execution. La description de l'avertissement identifie la substitution ; configurez les polices requises ou les [font substitution rules](/slides/fr/net/font-substitution/) avant de reessayer.
- **Contenu non supporte ou inattendu :** Un chargeur peut rencontrer des enregistrements ou des fonctions de presentation qu'il ne reconnait pas. De tels avertissements peuvent utiliser `UnexpectedContent`, ou une categorie plus severe lorsque des donnees ou du formatage sont connus pour etre affects.
- **Compatibilite de format :** Enregistrer dans un autre format de presentation peut omettre des fonctionnalites ou produire un resultat qui se comporte différemment dans certaines applications. Par exemple, enregistrer une presentation contenant plus de huit guides de dessin horizontaux ou verticaux dans le format PPT heritage genere un `CompatibilityIssue`. Le rappel au stade d'enregistrement peut consigner la perte et continuer, ou la rejeter si la preservation de tous les guides est requise.
- **Comportement de chargement :** Les options de chargement et les comportements herites peuvent également generer des avertissements. Par exemple, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/fr/net/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) identifie l'utilisation d'un comportement de verrouillage de presentation obsolete comme un `CompatibilityIssue`.

Les avertissements dependent du document source, du format cible, de l'operation et de la version d'Aspose.Slides. Ne supposez pas que chaque fichier genere un avertissement ou qu'un scenario corresponde toujours a une seule categorie.

## **Gerer En Toute Securite les Operations Interrompues**

Lorsque un rappel retourne `ReturnAction.Abort`, n'utilisez pas un objet qui n'a pas pu etre charge et ne supposez pas qu'un rendu ou un resultat d'enregistrement soit complet. L'operation peut se terminer apres la creation d'un fichier de sortie mais avant son achevement.

Enregistrez les resultats validates dans un chemin separe tel que `validated-output.pptx`. Remplacez une presentation existante uniquement après que l'operation se soit terminee avec succes, que le rapport d'avertissement satisfasse la politique de l'application, et que la sortie puisse etre ouverte et verifiee. Cela evite d'ecraser un fichier source valide avec un resultat partiel ou rejete.

Un rapport d'avertissement vide ne garantit pas que chaque fonctionnalite source a ete conservee. Appliquez toutes les verifications de contenu et visuelles supplementaires requises par l'application. Voir egalement [Open Presentations](/slides/fr/net/open-presentation/) et [Save Presentations](/slides/fr/net/save-presentation/).

## **FAQ**

**Un rappel d'avertissement peut-il gérer chaque erreur Aspose.Slides ?**

Non. Il gere les conditions recuperables signalees comme avertissements. Les exceptions qui surviennent independamment du rappel doivent etre gerees par l'application autour de l'appel de chargement, de rendu, de conversion ou d'enregistrement.

**Le retour de `ReturnAction.Continue` garantit-il une sortie identique ?**

Non. Il ne fait que permettre la poursuite du traitement. La condition signalee peut toujours entraîner des differences de donnees, de formatage ou de compatibilite, il faut donc examiner les types d'avertissement et les descriptions collectes.

**Comment une application peut-elle identifier l'operation qui a produit un avertissement ?**

Creez une instance de rappel pour chaque operation et stockez une etape définie par l'application avec `WarningType` et `Description`, comme illustre dans l'exemple.