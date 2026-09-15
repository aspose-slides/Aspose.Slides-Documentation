---
title: Gérer les avertissements de présentation en Python via Java
type: docs
weight: 90
url: /fr/python-java/presentation-warnings/
aliases:
- /python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- Python
- Java
- Aspose.Slides
description: "Apprenez comment collecter, classer et agir sur les avertissements lors du chargement, du rendu, de la conversion et de l'enregistrement de présentations avec Aspose.Slides pour Python via Java."
---
## **Vue d'ensemble**

Aspose.Slides peut signaler des problèmes récupérables lors du chargement, du rendu, de la conversion ou de l'enregistrement d'une présentation. Les exemples incluent des enregistrements source endommagés, du contenu qui ne peut pas être préservé, la substitution de polices et les limitations d'un format cible. Un rappel d'avertissement permet à une application d'enregistrer ces conditions et de décider si l'opération en cours peut se poursuivre.

Implémentez l'interface `IWarningCallback` via `jpype.JProxy` et examinez les valeurs `getWarningType` et `getDescription` fournies via `IWarningInfo`. Retournez [ReturnAction.Continue](https://reference.aspose.com/slides/fr/python-java/aspose.slides/returnaction/#Continue) pour accepter l'avertissement ou [ReturnAction.Abort](https://reference.aspose.com/slides/fr/python-java/aspose.slides/returnaction/#Abort) pour arrêter l'opération.

Utilisez [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/#setWarningCallback) pour les avertissements déclenchés lors de l'ouverture d'une présentation. Les classes d'options de rendu et d'exportation héritent de [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveoptions/#setWarningCallback), qui reçoit les avertissements du rendu des diapositives, de la conversion et de l'enregistrement. Comme l'avertissement lui-même n'identifie pas l'opération de l'application, associez chaque instance de rappel à une étape d'opération lorsque vous construisez un rapport combiné.

## **Avertissements et exceptions**

Un avertissement décrit une condition dont Aspose.Slides peut se remettre si le rappel renvoie `ReturnAction.Continue`. Une exception signifie que l'opération demandée ne peut pas se terminer normalement; les exceptions ne sont pas converties en avertissements et ne peuvent pas être gérées par une politique d'avertissement.

Le retour de `ReturnAction.Abort` demande au répartiteur d'avertissements de terminer l'opération en cours en levant une exception. L'exception publique dépend de l'opération et du format de la présentation. Par exemple, le chargement peut générer une [PptxReadException](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pptxreadexception/) ou une [PptReadException](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pptreadexception/), tandis que l'enregistrement ou l'exportation peut générer une [PptxException](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pptxexception/). Gérez l'exception à la frontière de l'opération et utilisez le rapport d'avertissement pour déterminer si la politique de l'application a causé l'arrêt plutôt que de vous fier à un sous-type d'exception ou à un message. Le rappel enregistre l'avertissement avant de renvoyer `ReturnAction.Abort`, garantissant que la raison reste disponible pour l'application.

## **Catégories d'avertissement**

La classe [WarningType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/warningtype/) fournit des constantes entières pour les catégories suivantes:

| Type d'avertissement | Signification | Politique typique |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/fr/python-java/aspose.slides/warningtype/#SourceFileCorruption) | La présentation source contient des corruptions pouvant rendre un document enregistré dans son format original inutilisable. | Abandonner. |
| [DataLoss](https://reference.aspose.com/slides/fr/python-java/aspose.slides/warningtype/#DataLoss) | Le texte, les graphiques, les images ou d'autres données peuvent être absents après le chargement ou l'enregistrement. | Abandonner. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/fr/python-java/aspose.slides/warningtype/#MajorFormattingLoss) | La présentation peut perdre un formatage important. | Interrompre en mode de validation stricte ; sinon enregistrer et continuer. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/fr/python-java/aspose.slides/warningtype/#MinorFormattingLoss) | Une différence de formatage limitée peut se produire. | Enregistrer pour le diagnostic et continuer. |
| [CompatibilityIssue](https://reference.aspose.com/slides/fr/python-java/aspose.slides/warningtype/#CompatibilityIssue) | Le résultat peut ne pas s'ouvrir ou se comporter correctement dans certaines applications ou versions plus anciennes. | Consigner et continuer sauf si la compatibilité est obligatoire. |
| [UnexpectedContent](https://reference.aspose.com/slides/fr/python-java/aspose.slides/warningtype/#UnexpectedContent) | La source contient du contenu non pris en charge ou non reconnu dont l'effet peut encore être inconnu. | Enregistrer et continuer, ou traiter comme une erreur dans une politique stricte. |

La catégorie doit guider la décision de politique. Conservez la valeur renvoyée par `getDescription` pour le diagnostic, mais ne vous fiez pas à sa formulation pour la logique de l'application, car le texte du message peut varier selon les scénarios d'avertissement et les versions du produit.

## **Collecter et classer les avertissements**

L'exemple suivant utilise un rapport au niveau de l'application pour l'ensemble du pipeline de traitement. Une instance de rappel distincte étiquette les avertissements provenant du chargement, du rendu, de la conversion PDF et de l'enregistrement PPTX. La politique interrompt en cas de corruption de la source ou de perte de données, interrompt éventuellement en cas de perte de formatage majeur, et continue pour les autres avertissements.

```python
import sys
from dataclasses import dataclass
from enum import Enum

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, LoadOptions, PdfOptions, PptxOptions, Presentation, RenderingOptions, ReturnAction, SaveFormat, WarningType


class OperationStage(Enum):
    Loading = "Loading"
    Rendering = "Rendering"
    Conversion = "Conversion"
    Saving = "Saving"


@dataclass(frozen=True)
class WarningEntry:
    stage: OperationStage
    type: int
    description: str


class WarningReport:
    def __init__(self):
        self._entries = []

    def get_entries(self):
        return tuple(self._entries)

    def add(self, stage, warning):
        entry = WarningEntry(stage, warning.getWarningType(), str(warning.getDescription()))
        self._entries.append(entry)


class WarningPolicy:
    def __init__(self, abort_on_major_formatting_loss):
        self.abort_on_major_formatting_loss = abort_on_major_formatting_loss

    def get_action(self, warning_type):
        if warning_type in (WarningType.SourceFileCorruption, WarningType.DataLoss):
            return ReturnAction.Abort
        if warning_type == WarningType.MajorFormattingLoss and self.abort_on_major_formatting_loss:
            return ReturnAction.Abort
        return ReturnAction.Continue


class ReportingWarningCallback:
    def __init__(self, stage, report, policy):
        self.stage = stage
        self.report = report
        self.policy = policy

    def warning(self, warning):
        self.report.add(self.stage, warning)
        return self.policy.get_action(warning.getWarningType())


def process_presentation(input_path, report, policy):
    try:
        load_options = LoadOptions()
        handler = ReportingWarningCallback(OperationStage.Loading, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        load_options.setWarningCallback(callback)
        presentation = Presentation(input_path, load_options)
        try:
            if not render_first_slide(presentation, report, policy):
                return False
            if not convert_to_pdf(presentation, report, policy):
                return False
            return save_validated_copy(presentation, report, policy)
        finally:
            presentation.dispose()
    except Exception as exception:
        print(f"Loading stopped: {exception}", file=sys.stderr)
        return False


def render_first_slide(presentation, report, policy):
    if presentation.getSlides().size() == 0:
        print("Rendering stopped: the presentation has no slides.", file=sys.stderr)
        return False
    try:
        options = RenderingOptions()
        handler = ReportingWarningCallback(OperationStage.Rendering, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        image = presentation.getSlides().get_Item(0).getImage(options)
        try:
            image.save("slide-1.png", ImageFormat.Png)
            return True
        finally:
            image.dispose()
    except Exception as exception:
        print(f"Rendering stopped: {exception}", file=sys.stderr)
        return False


def convert_to_pdf(presentation, report, policy):
    try:
        options = PdfOptions()
        handler = ReportingWarningCallback(OperationStage.Conversion, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("converted.pdf", SaveFormat.Pdf, options)
        return True
    except Exception as exception:
        print(f"Conversion stopped: {exception}", file=sys.stderr)
        return False


def save_validated_copy(presentation, report, policy):
    try:
        options = PptxOptions()
        handler = ReportingWarningCallback(OperationStage.Saving, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("validated-output.pptx", SaveFormat.Pptx, options)
        return True
    except Exception as exception:
        print(f"Saving stopped: {exception}", file=sys.stderr)
        return False


def warning_type_name(warning_type):
    names = {
        WarningType.SourceFileCorruption: "SourceFileCorruption",
        WarningType.DataLoss: "DataLoss",
        WarningType.MajorFormattingLoss: "MajorFormattingLoss",
        WarningType.MinorFormattingLoss: "MinorFormattingLoss",
        WarningType.CompatibilityIssue: "CompatibilityIssue",
        WarningType.UnexpectedContent: "UnexpectedContent",
    }
    return names.get(warning_type, f"Unknown ({warning_type})")


report = WarningReport()
policy = WarningPolicy(True)
completed = process_presentation("input.pptx", report, policy)

print("Processing completed." if completed else "Processing stopped.")
for entry in report.get_entries():
    type_name = warning_type_name(entry.type)
    print(f"[{entry.stage.value}] {type_name}: {entry.description}")
```

Passez `False` à `abort_on_major_formatting_loss` lors de la construction de `WarningPolicy` si les différences de formatage majeures sont acceptables. Les problèmes de compatibilité, la perte de formatage mineur et le contenu inattendu sont toujours conservés dans le rapport même si l'opération continue. Prolongez `WarningPolicy.get_action` si l'application doit rejeter l'une de ces catégories.

## **Scénarios courants d'avertissement**

Les avertissements peuvent apparaître à différentes étapes d'un flux de travail:

- **Signatures numériques :** Une présentation signée peut produire un avertissement lors du chargement indiquant que sa signature sera perdue pendant le traitement. Aspose.Slides signale cette condition `DataLoss` via `IPresentationSignedWarningInfo`. Un rappel au stade de chargement permet à l'application de rejeter le fichier ou d'accepter explicitement la perte signalée.
- **Substitution de police :** Une police indisponible peut être remplacée lors du rendu ou de l'exportation d'une diapositive. Les avertissements de substitution de police sont signalés comme `DataLoss`, ainsi la politique stricte ci-dessous interrompt même si l'application considérerait un remplacement particulier comme visuellement acceptable. Pour observer ce comportement, utilisez une présentation d'entrée contenant du texte dans une police non disponible pour le runtime. La description de l'avertissement identifie la substitution ; configurez les polices requises ou les [font substitution rules](/slides/fr/python-java/font-substitution/) avant de réessayer.
- **Contenu non pris en charge ou inattendu :** Un chargeur peut rencontrer des enregistrements ou des fonctionnalités de présentation qu'il ne reconnaît pas. De tels avertissements peuvent utiliser `UnexpectedContent`, ou une catégorie plus sévère lorsque des données ou un formatage sont connus pour être affectés.
- **Compatibilité de format :** L'enregistrement dans un autre format de présentation peut omettre des fonctionnalités ou produire un résultat qui se comporte différemment dans certaines applications. Par exemple, enregistrer une présentation avec plus de huit guides de dessin horizontaux ou verticaux dans le PPT hérité signale un `CompatibilityIssue`. Le rappel au stade d'enregistrement peut enregistrer la perte et continuer, ou la rejeter si la conservation de tous les guides est requise.
- **Comportement de chargement :** Les options de chargement et les comportements hérités peuvent également produire des avertissements. Par exemple, `IObsoletePresLockingBehaviorWarningInfo` identifie l'utilisation d'un comportement de verrouillage de présentation obsolète comme un `CompatibilityIssue`.

Les avertissements dépendent du document source, du format cible, de l'opération et de la version d'Aspose.Slides. Ne supposez pas que chaque fichier génère un avertissement ou qu'un scénario corresponde toujours à une seule catégorie.

## **Gérer en toute sécurité les opérations interrompues**

Lorsqu'un rappel renvoie `ReturnAction.Abort`, n'utilisez pas un objet qui n'a pas pu être chargé et ne supposez pas qu'une sortie de rendu ou d'enregistrement est complète. L'opération peut se terminer après la création d'un fichier de sortie mais avant son achèvement.

Enregistrez les résultats validés dans un chemin distinct tel que `validated-output.pptx`. Remplacez une présentation existante uniquement après que l'opération se soit terminée avec succès, que le rapport d'avertissement satisfasse la politique de l'application et que la sortie puisse être ouverte et vérifiée. Cela évite d'écraser un fichier source valide avec un résultat partiel ou rejeté.

Un rapport d'avertissement vide ne garantit pas que chaque fonctionnalité source a été préservée. Appliquez toutes les vérifications de contenu et visuelles supplémentaires requises par l'application. Voir également [Open Presentations](/slides/fr/python-java/open-presentation/) et [Save Presentations](/slides/fr/python-java/save-presentation/).

## **FAQ**

**Un rappel d'avertissement peut-il gérer chaque erreur d'Aspose.Slides ?**

Non. Il gère les conditions récupérables signalées comme des avertissements. Les exceptions qui surviennent indépendamment du rappel doivent être gérées par l'application autour de l'appel de chargement, de rendu, de conversion ou d'enregistrement.

**Le retour de `ReturnAction.Continue` garantit-il une sortie identique ?**

Non. Il ne fait que permettre la poursuite du traitement. La condition signalée peut toujours entraîner des différences de données, de formatage ou de compatibilité, il faut donc examiner les types d'avertissements et les descriptions collectés.

**Comment une application peut-elle identifier l'opération qui a produit un avertissement ?**

Créez une instance de rappel pour chaque opération et stockez une étape définie par l'application avec les valeurs renvoyées par `getWarningType` et `getDescription`, comme illustré dans l'exemple.