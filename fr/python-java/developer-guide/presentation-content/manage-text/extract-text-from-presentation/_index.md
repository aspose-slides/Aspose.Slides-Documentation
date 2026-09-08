---
title: Extraction avancée de texte des présentations en Python via Java
linktitle: Extraire le texte
type: docs
weight: 90
url: /fr/python-java/extract-text-from-presentation/
keywords:
- extraire du texte
- extraire du texte d'une diapositive
- extraire du texte d'une présentation
- extraire du texte de PowerPoint
- extraire du texte d'OpenDocument
- extraire du texte de PPT
- extraire du texte de PPTX
- extraire du texte de ODP
- récupérer le texte
- récupérer le texte d'une diapositive
- récupérer le texte d'une présentation
- récupérer le texte de PowerPoint
- récupérer le texte d'OpenDocument
- récupérer le texte de PPT
- récupérer le texte de PPTX
- récupérer le texte de ODP
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Extrayez rapidement du texte des présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Python via Java. Suivez notre guide simple, étape par étape, pour gagner du temps."
---
## **Vue d'ensemble**

Extraire du texte des présentations est une tâche courante mais essentielle pour les développeurs qui travaillent avec du contenu de diapositives. Que vous manipuliez des fichiers Microsoft PowerPoint au format PPT ou PPTX, ou des présentations OpenDocument (ODP), accéder et récupérer les données textuelles peut être crucial pour l'analyse, l'automatisation, l'indexation ou la migration de contenu.

Cet article fournit un guide complet sur la façon d'extraire efficacement du texte de divers formats de présentation, y compris PPT, PPTX et ODP, en utilisant Aspose.Slides for Python via Java. Vous apprendrez comment itérer systématiquement à travers les éléments d'une présentation pour récupérer avec précision le texte dont vous avez besoin.

## **Extraire du texte d'une diapositive**

Aspose.Slides for Python via Java fournit la classe [SlideUtil](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideutil/) . Cette classe expose plusieurs méthodes statiques surchargées pour extraire tout le texte d'une présentation ou d'une diapositive. Pour extraire du texte d'une diapositive dans une présentation, utilisez la méthode [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideutil/#getAllTextBoxes) . Cette méthode accepte un objet de type [BaseSlide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseslide/) comme paramètre. Lorsqu'elle est exécutée, la méthode parcourt toute la diapositive à la recherche de texte et renvoie un tableau d'objets de type [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/), en conservant toute la mise en forme du texte.

Le fragment de code suivant extrait tout le texte de la première diapositive de la présentation :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

slide_index = 0

presentation = Presentation("demo.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    text_frames = SlideUtil.getAllTextBoxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **Extraire du texte d'une présentation**

Pour analyser le texte de l'ensemble de la présentation, utilisez la méthode statique [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideutil/#getAllTextFrames) exposée par la classe [SlideUtil](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideutil/) . Elle accepte deux paramètres :

1. Tout d'abord, un objet [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) représentant une présentation PowerPoint ou OpenDocument à partir de laquelle le texte sera extrait.
1. Deuxièmement, une valeur `bool` indiquant si les diapositives maîtres doivent être incluses lors de l'analyse du texte de la présentation.

La méthode renvoie un tableau d'objets de type [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/), incluant les informations de mise en forme du texte. Le code ci‑dessous parcourt le texte et les détails de mise en forme d'une présentation, y compris les diapositives maîtres.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

presentation = Presentation("demo.pptx")
try:
    include_master_slides = True
    text_frames = SlideUtil.getAllTextFrames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **Extraction de texte catégorisée et rapide**

La classe [PresentationFactory](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationfactory/) fournit également des méthodes pour extraire tout le texte des présentations :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationFactory, TextExtractionArrangingMode
from java.io import FileInputStream

mode = TextExtractionArrangingMode.Unarranged
load_options = LoadOptions()

# Extraire le texte d'un fichier.
file_text = PresentationFactory.getInstance().getPresentationText("presentation.pptx", mode)

# Extraire le texte d'un flux.
stream = FileInputStream("presentation.pptx")
try:
    stream_text = PresentationFactory.getInstance().getPresentationText(stream, mode)
finally:
    stream.close()

# Extraire le texte d'un flux en utilisant les options de chargement.
stream_with_options = FileInputStream("presentation.pptx")
try:
    stream_text_with_options = PresentationFactory.getInstance().getPresentationText(stream_with_options, mode, load_options)
finally:
    stream_with_options.close()
```

L'argument d'énumération [TextExtractionArrangingMode](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textextractionarrangingmode/) indique le mode d'organisation du résultat d'extraction de texte et peut être défini sur les valeurs suivantes :

- [Unarranged](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textextractionarrangingmode/#Unarranged) - Le texte brut sans tenir compte de sa position sur la diapositive.
- [Arranged](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textextractionarrangingmode/#Arranged) - Le texte est organisé dans le même ordre que sur la diapositive.

Le mode non organisé peut être utilisé lorsque la vitesse est critique ; il est plus rapide que le mode organisé.

[PresentationText](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationtext/) représente le texte brut extrait de la présentation. Sa méthode [getSlidesText](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationtext/#getSlidesText) renvoie un tableau d'objets de type `SlideText`. Chaque objet représente le texte de la diapositive correspondante. L'objet de type `SlideText` possède les méthodes suivantes :

- `getText` - Le texte contenu dans les formes de la diapositive.
- `getMasterText` - Le texte contenu dans les formes de la diapositive maîtresse associée à cette diapositive.
- `getLayoutText` - Le texte contenu dans les formes de la diapositive de mise en page associée à cette diapositive.
- `getNotesText` - Le texte contenu dans les formes de la diapositive de notes associée à cette diapositive.
- `getCommentsText` - Le texte contenu dans les commentaires associés à cette diapositive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, TextExtractionArrangingMode

presentation_path = "presentation.ppt"
arranging_mode = TextExtractionArrangingMode.Unarranged
presentation_text = PresentationFactory.getInstance().getPresentationText(presentation_path, arranging_mode)
first_slide_text = presentation_text.getSlidesText()[0]

print(first_slide_text.getText())
print(first_slide_text.getLayoutText())
print(first_slide_text.getMasterText())
print(first_slide_text.getNotesText())
print(first_slide_text.getCommentsText())
```

## **FAQ**

**À quelle vitesse Aspose.Slides traite-t-il les grandes présentations lors de l'extraction de texte ?**

Aspose.Slides est optimisé pour des performances élevées et peut traiter même [grandes présentations](/slides/fr/python-java/open-presentation/), ce qui le rend adapté aux scénarios de traitement en temps réel ou en masse.

**Aspose.Slides peut-il extraire du texte des tableaux et des graphiques dans les présentations ?**

Oui. Aspose.Slides peut extraire du texte de nombreux éléments de diapositive, y compris les tableaux et les objets liés aux graphiques, afin que vous puissiez accéder et analyser le contenu textuel des structures de présentation courantes.

**Ai-je besoin d'une licence spéciale Aspose.Slides pour extraire du texte des présentations ?**

Vous pouvez extraire du texte en utilisant la version d'essai gratuite d'Aspose.Slides, bien qu'elle comporte [certaines limitations](/slides/fr/python-java/licensing/), comme le traitement d'un nombre limité de diapositives. Pour une utilisation illimitée et pour gérer de plus grandes présentations, l'achat d'une licence complète est recommandé.