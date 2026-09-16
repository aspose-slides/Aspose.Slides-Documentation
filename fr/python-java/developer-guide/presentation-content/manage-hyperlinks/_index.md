---
title: Gérer les hyperliens de présentation en Python via Java
linktitle: Gérer les hyperliens
type: docs
weight: 20
url: /fr/python-java/manage-hyperlinks/
keywords:
- ajouter URL
- ajouter un hyperlien
- créer un hyperlien
- formater l'hyperlien
- supprimer hyperlien
- mettre à jour hyperlien
- hyperlien texte
- hyperlien diapositive
- hyperlien forme
- hyperlien image
- hyperlien vidéo
- hyperlien modifiable
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Ajouter, formater, mettre à jour et supprimer des hyperliens dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour Python via Java, à l'aide d'exemples Python."
---
## **Introduction**

Un hyperlien relie le contenu d'une présentation à un site Web ou à un emplacement au sein de la présentation. Dans PowerPoint, les hyperliens servent généralement à deux fins :

* Ouvrir un site Web à partir d'un texte, d'une forme ou d'un cadre multimédia.
* Naviguer vers une autre diapositive, par exemple depuis une table des matières.

Aspose.Slides for Python via Java vous permet d'ajouter ces liens, de contrôler leur apparence et leur son, de mettre à jour leurs propriétés et de les supprimer. Les exemples ci‑dessous montrent comment travailler avec les hyperliens sur des éléments individuels et comment accéder aux hyperliens au niveau de la présentation, de la diapositive ou du cadre de texte.

{{% alert color="info" title="Note" %}}
Vous pouvez également modifier des présentations avec le [éditeur PowerPoint en ligne gratuit d'Aspose](https://products.aspose.app/slides/fr/editor).
{{% /alert %}} 

## **Ajouter des hyperliens URL**

Vous pouvez affecter une URL de site Web à du texte, une forme ou un cadre multimédia. L'élément auquel vous attribuez l'hyperlien détermine la zone cliquable : une portion de texte lie le texte sélectionné, tandis qu'une forme ou un cadre lie l'objet de la diapositive.

### **Ajouter des hyperliens URL au texte**

Pour lier du texte à un site Web, transmettez un [Hyperlink](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlink/) à la méthode [setHyperlinkClick](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portionformat/#setHyperlinkClick) de la portion de texte, comme illustré ci‑dessous. Seule cette portion de texte devient cliquable.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ajouter des hyperliens URL aux formes et aux cadres multimédia**

Pour rendre une forme ou un cadre cliquable, appelez sa méthode [setHyperlinkClick](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#setHyperlinkClick). L'hyperlien appartient à l'objet lui‑même plutôt qu'à une portion de texte qu'il contient.

La même approche s'applique aux cadres d'image, audio et vidéo : attribuez l'hyperlien au cadre et appelez [setTooltip](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlink/#setTooltip) si nécessaire.

L'exemple suivant rend un rectangle cliquable :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50)

    shape.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Utiliser les hyperliens pour créer une table des matières**

Les hyperliens internes permettent aux lecteurs de passer d'une table des matières à une diapositive spécifique. L'exemple suivant utilise [setInternalHyperlinkClick](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick) pour lier le texte « Page 2 » de la première diapositive à la deuxième diapositive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())

    table_of_contents = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    table_of_contents.getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    table_of_contents.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Formatage des hyperliens**

### **Couleur**

La méthode [setColorSource](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlink/#setColorSource) de [Hyperlink](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlink/) détermine si un hyperlien utilise la couleur d'hyperlien de la présentation ou le formatage de la portion de texte. Pour appliquer une couleur de texte personnalisée, sélectionnez [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlinkcolorsource/) et définissez la couleur de remplissage de la portion. Cette fonctionnalité a été introduite dans PowerPoint 2019 ; les versions antérieures n'appliquent pas ce paramètre.

L'exemple suivant ajoute deux hyperliens texte à la même diapositive. Le premier utilise un remplissage de texte rouge, tandis que le second conserve la couleur d'hyperlien par défaut.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Hyperlink, HyperlinkColorSource, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    colored_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, False)
    colored_link_shape.addTextFrame("This hyperlink uses a custom color.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This hyperlink uses the default color.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Son**

Un hyperlien peut jouer un son lorsqu'il est activé ou arrêter un son déjà en cours de lecture. Utilisez les méthodes suivantes pour configurer ces comportements :

- [Hyperlink.setSound](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlink/#setSound) spécifie l'audio associé à l'hyperlien.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) contrôle si l'activation de l'hyperlien arrête le son précédent.

#### **Ajouter un son d'hyperlien**

L'exemple suivant charge `sampleaudio.wav` et l'associe à un bouton sur la première diapositive. Cliquer sur le bouton joue le son et navigue vers la diapositive suivante. Une deuxième forme sur cette diapositive arrête le son précédent lorsqu'elle est cliquée, sans effectuer d'action de navigation.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    audio_data = Path("sampleaudio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    hyperlink_sound = presentation.getAudios().addAudio(java_audio_data)
    first_slide = presentation.getSlides().get_Item(0)
    play_button = first_slide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50)
    play_button.setHyperlinkClick(Hyperlink.getNextSlide())
    if not play_button.getHyperlinkClick().getStopSoundOnClick() and play_button.getHyperlinkClick().getSound() is None:
        play_button.getHyperlinkClick().setSound(hyperlink_sound)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    stop_button = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50)
    stop_button.setHyperlinkClick(Hyperlink.getNoAction())
    stop_button.getHyperlinkClick().setStopSoundOnClick(True)
    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx)
except OSError as exception:
    print(f"Unable to read the audio file: {exception}")
finally:
    presentation.dispose()
```

#### **Extraire le son d'un hyperlien**

L'exemple suivant ouvre la présentation créée ci‑dessus et lit l'audio d'hyperlien de la première forme en mémoire via [getSound](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlink/#getSound) et [getBinaryData](https://reference.aspose.com/slides/fr/python-java/aspose.slides/audio/#getBinaryData).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("hyperlink-sound.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick()
        sound = hyperlink.getSound() if hyperlink is not None else None
        if sound is not None:
            audio_data = bytes(sound.getBinaryData())
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
finally:
    presentation.dispose()
```

### **Infobulle et paramètres d'interaction**

Vous pouvez appeler les méthodes [Hyperlink](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlink/) suivantes après avoir attribué un hyperlien à du texte ou à une forme :

- [setTooltip](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlink/#setTooltip) définit le texte qu'un utilisateur peut afficher comme indication pour le lien.
- [setTargetFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlink/#setTargetFrame) spécifie le cadre cible au sein d'un frameset HTML parent, le cas échéant.
- [setHistory](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlink/#setHistory) contrôle si l'activation du lien ajoute sa destination à la liste des hyperliens consultés.
- [setHighlightClick](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlink/#setHighlightClick) contrôle si l'hyperlien est mis en surbrillance lorsqu'il est cliqué.

## **Supprimer les hyperliens des présentations**

Utilisez [getAnyHyperlinks](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) pour collecter les conteneurs d'hyperliens, y compris les liens de portions de texte, avant de les modifier. L'exemple suivant supprime les deux types d'activation de la première diapositive. Pour supprimer uniquement un type, appelez uniquement [removeHyperlinkClick](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) ou [removeHyperlinkMouseOver](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver) ; la suppression d'une action de clic ne supprime pas son équivalent au survol.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        containers = list(presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks())
        for container in containers:
            container.getHyperlinkManager().removeHyperlinkClick()
            container.getHyperlinkManager().removeHyperlinkMouseOver()
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
    else:
        print("The presentation has no slides to process.")
finally:
    presentation.dispose()
```

Pour une suppression inconditionnelle, [removeAllHyperlinks](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) supprime les deux types d'activation dans la portée sélectionnée en un seul appel. Pour un nettoyage sélectif et la couverture des masques, des dispositions et des notes, voir [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Construire un inventaire complet des hyperliens**

Avant de distribuer une présentation, répertoriez ses actions interactives ainsi que ses liens Web. [getAnyHyperlinks](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) renvoie des conteneurs d'hyperliens, tels que des objets [Shape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/) et [PortionFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portionformat/), et non une liste aplatie de chaînes URL. Inspectez à la fois [getHyperlinkClick](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getHyperlinkClick) et [getHyperlinkMouseOver](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getHyperlinkMouseOver) sur chaque conteneur. Ils sont indépendants : le même conteneur peut exposer les deux actions, ainsi un rapport complet nécessite jusqu'à deux lignes par conteneur.

Analyser uniquement les hyperliens au niveau des formes peut manquer les liens attachés aux portions de texte. Interrogez plutôt la portée appropriée et conservez les conteneurs retournés afin de pouvoir mettre à jour ou supprimer leurs actions ultérieurement.

### **Interroger les portées de présentation, de diapositive et de cadre de texte**

La classe [HyperlinkQueries](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlinkqueries/) est disponible via [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseslide/#getHyperlinkQueries) et [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/#getHyperlinkQueries). Chaque portée prend en charge les mêmes requêtes :

- [getHyperlinkClicks](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) renvoie les conteneurs avec une action de clic.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) renvoie les conteneurs avec une action de survol.
- [getAnyHyperlinks](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) renvoie les conteneurs avec l'une ou les deux actions.

L'exemple suivant crée `hyperlink-audit-input.pptx` avec un lien de clic externe, un lien de survol de fichier, une navigation interne de diapositive, un lien de survol de texte et une action macro. Il n'exécute aucune de ces actions. Les mêmes trois requêtes fonctionnent à chaque portée ; les décomptes décrivent les conteneurs, pas le total des actions. La portée du cadre de texte exclut les propres liens de la forme enveloppante.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType


def print_counts(scope, queries):
    click_count = queries.getHyperlinkClicks().size()
    mouse_over_count = queries.getHyperlinkMouseOvers().size()
    any_count = queries.getAnyHyperlinks().size()
    print(f"{scope}: click={click_count}, mouse-over={mouse_over_count}, any={any_count}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide())
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60)
    shape.getTextFrame().setText("Click the text to go to slide 2")
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/")
    shape.getHyperlinkClick().setTooltip("Public website")
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx")
    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.getHyperlinkManager().setInternalHyperlinkClick(destination)
    portion_format.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help")
    macro_button = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60)
    macro_button.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation")
    print_counts("Presentation", presentation.getHyperlinkQueries())
    print_counts("Slide 1", slide.getHyperlinkQueries())
    print_counts("Text frame", shape.getTextFrame().getHyperlinkQueries())
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pour cet exemple, les requêtes de présentation et de diapositive rapportent chacune trois conteneurs de clic, deux conteneurs de survol et trois conteneurs avec l'une ou l'autre action. La requête du cadre de texte rapporte un conteneur dans chaque catégorie.

### **Classer les actions et les destinations**

Utilisez [Hyperlink.getActionType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlink/#getActionType) pour interpréter une action avant d'interpréter sa destination. Les valeurs de [HyperlinkActionType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlinkactiontype/) couvrent plus que la navigation Web :

| Valeurs | Signification pour un audit |
| --- | --- |
| `Hyperlink` | Hyperlien externe ; inspectez l'URL et son schéma. |
| `JumpSpecificSlide` | Navigation interne vers une diapositive particulière. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Navigation de diaporama intégrée, résolue dans le contexte du diaporama. |
| `JumpEndShow`, `StartCustomSlideShow` | Met fin au diaporama actuel ou démarre un diaporama personnalisé. |
| `StartMacro` | Exécuter une macro. |
| `StartProgram` | Lancer un programme. |
| `OpenFile`, `OpenPresentation` | Ouvrir un fichier ou une autre présentation ; examiner séparément des URLs Web. |
| `StartStopMedia` | Démarrer ou arrêter la lecture d’un média. |
| `NoAction`, `Unknown` | Aucune action de navigation, ou une action non reconnue nécessitant un examen. |

Lisez les destinations externes avec [getExternalUrl](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlink/#getExternalUrl) et les destinations internes spécifiques avec [getTargetSlide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlink/#getTargetSlide). Les actions internes et les commandes intégrées peuvent ne pas avoir d'URL externe ; une URL vide ne signifie pas que le conteneur n'a aucune action. Conservez la valeur renvoyée par [getExternalUrlOriginal](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal) lorsqu'elle diffère de l'URL normalisée, et incluez l'infobulle renvoyée par [getTooltip](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlink/#getTooltip) lorsqu'elle est disponible.

### **Rapporter, assainir et vérifier les hyperliens**

L'exemple Python suivant lit une présentation existante (utilisez le fichier créé ci‑dessus), écrit `hyperlink-audit.json`, applique une politique, enregistre `hyperlink-sanitized.pptx` et la rouvre pour vérifier à nouveau les deux types d'activation. Il collecte les conteneurs avant de les modifier et utilise l'égalité de référence pour éviter de traiter deux fois le même conteneur. Les requêtes de présentation couvrent les diapositives ordinaires ; pour un inventaire à l'échelle du package, il interroge également explicitement les masques, les dispositions, les notes et les masques de notes et de fascicules lorsqu'ils sont présents.

Le rapport enregistre un indice de diapositive basé à 1 et [getSlideId](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseslide/#getSlideId) lorsque disponible. [getSlide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getSlide) fournit la diapositive propriétaire pour les conteneurs pris en charge. Les masques, les dispositions et les notes n'ont pas d'indice de diapositive ordinaire et sont identifiés par leur portée. Les conteneurs de forme et les conteneurs de format de portion de texte sont étiquetés séparément ; les autres types de conteneurs conservent leur nom de type d'exécution. Chaque conteneur reçoit un ID local au rapport afin que ses deux actions puissent être corrélées. Le rapport stocke les types d'action sous forme de constantes entières définies par l'énumération Java.

Cette politique d'application délibérément restrictive n'autorise que les URLs HTTPS absolues et les cibles de diapositive internes valides. Elle rejette les macros, programmes, actions de fichiers, autres actions de diaporama, actions inconnues et d'autres schémas d'URL. Ces rejets sont des décisions de politique, et non un verdict de sécurité d'Aspose.Slides. HTTPS seul n'établit pas la confiance : ajoutez des listes d'hôtes autorisés et d'autres vérifications pour votre application. Les URLs externes originales et normalisées sont toutes deux vérifiées. L'exemple audite les métadonnées sans suivre les liens ni exécuter d'actions.

Pour la remédiation, le [getHyperlinkManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getHyperlinkManager) du conteneur prend en charge [setExternalHyperlinkClick](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) et [removeHyperlinkMouseOver](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver). Ici, les liens de clic externes interdits sont remplacés par une page d'atterrissage HTTPS fixe ; les autres clics interdits et les actions de survol interdites sont supprimés indépendamment. Définissez `replace_external_clicks` sur `False` pour supprimer toutes les violations de politique à la place. Choisissez une page de remplacement appartenant à l'application avant le déploiement.

Le drapeau d'exportation du rapport utilise une politique de révision PDF conservatrice : signalez les actions de survol et tout ce qui n'est pas un lien externe ou un saut de diapositive spécifique comme potentiellement non pris en charge. Il s'agit d'une indication de révision, pas d'un test de capacité ou d'une garantie que les liens non signalés survivront à l'exportation. Les exportations PDF et HTML prises en charge [/slides/fr/python-java/convert-powerpoint-to-pdf/](/slides/fr/python-java/convert-powerpoint-to-pdf/) et [/slides/fr/python-java/convert-powerpoint-to-html/](/slides/fr/python-java/convert-powerpoint-to-html/) peuvent préserver les hyperliens, selon l'action, les options d'exportation et le visualiseur. Les [images](/slides/fr/python-java/convert-powerpoint-to-png/) et [vidéos](/slides/fr/python-java/convert-powerpoint-to-video/) raster ne peuvent pas préserver les hyperliens interactifs ; signalez chaque action lors de l'audit pour ces sorties.

```python
import json
from pathlib import Path
from urllib.parse import urlsplit

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HyperlinkActionType, PortionFormat, Presentation, SaveFormat, Shape

IdentityHashMap = jpype.JClass("java.util.IdentityHashMap")


def slide_index(presentation, slide):
    for index, candidate in enumerate(presentation.getSlides(), start=1):
        if candidate == slide:
            return index
    return None


def is_https(value):
    if not value:
        return False
    value = str(value)
    if any(character.isspace() or ord(character) < 32 for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.getActionType() == HyperlinkActionType.JumpSpecificSlide:
        return "Missing target slide" if link.getTargetSlide() is None else None
    if link.getActionType() != HyperlinkActionType.Hyperlink:
        return "Action is not allowed"
    if not is_https(link.getExternalUrl()):
        return "Normalized URL is not absolute HTTPS"
    original = link.getExternalUrlOriginal()
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def collect_containers(presentation):
    found = list(presentation.getHyperlinkQueries().getAnyHyperlinks())
    scopes = list(presentation.getMasters()) + list(presentation.getLayoutSlides())
    for slide in presentation.getSlides():
        scopes.append(slide.getNotesSlideManager().getNotesSlide())
    scopes.append(presentation.getMasterNotesSlideManager().getMasterNotesSlide())
    scopes.append(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide())
    for scope in scopes:
        if scope is not None:
            found.extend(scope.getHyperlinkQueries().getAnyHyperlinks())
    seen = IdentityHashMap()
    unique = []
    for container in found:
        if not seen.containsKey(container):
            seen.put(container, True)
            unique.append(container)
    return unique


def text_or_none(value):
    return str(value) if value is not None else None


def add_row(rows, presentation, link, activation, container, container_id):
    if link is None:
        return
    owner_slide = container.getSlide() if hasattr(container, "getSlide") else None
    target_slide = link.getTargetSlide()
    violation = policy_violation(link)
    if isinstance(container, Shape):
        owner_type = "Shape"
    elif isinstance(container, PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = str(container.getClass().getSimpleName())
    ordinary_action = link.getActionType() in (HyperlinkActionType.Hyperlink, HyperlinkActionType.JumpSpecificSlide)
    original = link.getExternalUrlOriginal()
    rows.append({
        "ContainerId": container_id,
        "SlideIndex": slide_index(presentation, owner_slide),
        "SlideId": int(owner_slide.getSlideId()) if owner_slide is not None else None,
        "Scope": str(owner_slide.getClass().getSimpleName()) if owner_slide is not None else None,
        "OwnerType": owner_type,
        "Activation": activation,
        "ActionType": int(link.getActionType()),
        "ExternalUrl": text_or_none(link.getExternalUrl()),
        "TargetSlideIndex": slide_index(presentation, target_slide),
        "TargetSlideId": int(target_slide.getSlideId()) if target_slide is not None else None,
        "Tooltip": text_or_none(link.getTooltip()),
        "OriginalExternalUrl": text_or_none(original) if original != link.getExternalUrl() else None,
        "PotentiallyUnsafe": violation is not None,
        "PolicyViolation": violation,
        "TargetExport": "PDF",
        "PotentiallyUnsupportedByExport": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"
presentation = Presentation("hyperlink-audit-input.pptx")
try:
    containers = collect_containers(presentation)
    rows = []
    for container_id, container in enumerate(containers, start=1):
        add_row(rows, presentation, container.getHyperlinkClick(), "click", container, container_id)
        add_row(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, container_id)
    report = json.dumps(rows, indent=2)
    Path("hyperlink-audit.json").write_text(report, encoding="utf-8")

    for container in containers:
        click = container.getHyperlinkClick()
        if policy_violation(click) is not None:
            if replace_external_clicks and click.getActionType() == HyperlinkActionType.Hyperlink:
                container.getHyperlinkManager().setExternalHyperlinkClick(replacement_url)
            else:
                container.getHyperlinkManager().removeHyperlinkClick()
        if policy_violation(container.getHyperlinkMouseOver()) is not None:
            container.getHyperlinkManager().removeHyperlinkMouseOver()
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx)

    reopened = Presentation("hyperlink-sanitized.pptx")
    try:
        remaining_containers = collect_containers(reopened)
        violations = 0
        for container in remaining_containers:
            if policy_violation(container.getHyperlinkClick()) is not None:
                violations += 1
            if policy_violation(container.getHyperlinkMouseOver()) is not None:
                violations += 1
        print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
        if violations != 0:
            print("Verification failed: do not distribute the saved presentation.")
    finally:
        reopened.dispose()
except OSError as exception:
    print(f"Unable to write the audit report: {exception}")
finally:
    presentation.dispose()
```

Avec l'entrée créée ci‑dessus, le rapport contient cinq lignes d'action. Le lien de survol de fichier et le clic macro sont supprimés, tandis que les liens HTTPS et la navigation interne de diapositive restent. La vérification affiche zéro action interdite. Une entrée contenant une URL de clic externe interdite teste également la branche de remplacement. Un conteneur avec un clic autorisé et un survol interdit conserve son action de clic.

Ce nettoyage sélectif diffère de [removeAllHyperlinks](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks), qui supprime les deux types d'activation dans toute la portée sélectionnée, quelle que soit la politique. La vérification ici ne contrôle que les actions d'hyperlien ; elle ne supprime pas les projets VBA embarqués, les objets OLE ou autre contenu actif, et elle ne valide pas un fichier PDF ou HTML exporté.

## **FAQ**

**Comment puis-je créer un lien vers une section ou sa première diapositive ?**

Les sections dans PowerPoint regroupent les diapositives, mais un hyperlien interne cible une diapositive individuelle. Pour créer une navigation vers une section, liez à la première diapositive de cette section.

**Puis-je attacher un hyperlien aux éléments du masque de diapositive afin qu'il fonctionne sur toutes les diapositives ?**

Oui. Les éléments du masque de diapositive et des dispositions prennent en charge les hyperliens. Les liens sur ces éléments sont disponibles pendant le diaporama sur les diapositives qui utilisent le masque ou la disposition correspondante.

**Les hyperliens seront-ils conservés lors de l'exportation vers PDF, HTML, images ou vidéo ?**

Les exportations PDF et HTML prises en charge peuvent conserver les hyperliens ; les images raster et la vidéo ne le peuvent pas. Voir les considérations d'exportation dans [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).