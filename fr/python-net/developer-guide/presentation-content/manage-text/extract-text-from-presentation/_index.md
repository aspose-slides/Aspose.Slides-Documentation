---
title: Extraction avancée de texte à partir de présentations PowerPoint en Python
linktitle: Extraire le texte
type: docs
weight: 90
url: /fr/python-net/extract-text-from-presentation/
keywords:
- extraction de texte
- extraction de texte de diapositive
- extraction de texte de présentation
- extraction de texte de PowerPoint
- extraction de texte d'OpenDocument
- extraction de texte de PPT
- extraction de texte de PPTX
- extraction de texte de ODP
- récupérer le texte
- récupérer le texte de diapositive
- récupérer le texte de présentation
- récupérer le texte de PowerPoint
- récupérer le texte d'OpenDocument
- récupérer le texte de PPT
- récupérer le texte de PPTX
- récupérer le texte de ODP
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez à extraire rapidement et facilement du texte des présentations PowerPoint en utilisant Aspose.Slides pour Python via .NET. Suivez notre guide simple, étape par étape, pour gagner du temps et accéder efficacement au contenu des diapositives dans vos applications."
---

## **Vue d'ensemble**

L'extraction de texte à partir de présentations est une tâche courante mais essentielle pour les développeurs qui travaillent avec le contenu des diapositives. Que vous manipuliez des fichiers Microsoft PowerPoint au format PPT ou PPTX, ou des présentations OpenDocument (ODP), accéder et récupérer les données textuelles peut être crucial pour l'analyse, l'automatisation, l'indexation ou la migration de contenu.

Cet article fournit un guide complet sur la façon d'extraire efficacement du texte à partir de différents formats de présentation, y compris PPT, PPTX et ODP, en utilisant Aspose.Slides for Python. Vous apprendrez à itérer systématiquement sur les éléments d'une présentation afin de récupérer avec précision le texte dont vous avez besoin.

## **Extraire le texte d'une diapositive**

Aspose.Slides for Python fournit l'espace de noms [aspose.slides.util](https://reference.aspose.com/slides/python-net/aspose.slides.util/) qui comprend la classe [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/). Cette classe expose plusieurs méthodes statiques surchargées pour extraire tout le texte d'une présentation ou d'une diapositive. Pour extraire le texte d'une diapositive dans une présentation, utilisez la méthode [get_all_text_boxes](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/get_all_text_boxes/). Cette méthode accepte un objet de type [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) en paramètre. Lorsqu'elle est exécutée, la méthode parcourt l'intégralité de la diapositive à la recherche de texte et renvoie un tableau d'objets de type [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), en conservant le formatage du texte.

Le fragment de code suivant extrait tout le texte de la première diapositive de la présentation :
```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente un fichier PPTX.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Obtenir un tableau d'objets TextFrame à partir de toutes les diapositives du fichier PPTX.
    text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)
    # Parcourir le tableau des frames de texte.
    for text_frame in text_frames:
        # Parcourir les paragraphes du cadre de texte actuel.
        for paragraph in text_frame.paragraphs:
            # Parcourir les portions de texte du paragraphe actuel.
            for portion in paragraph.portions:
                # Afficher le texte de la portion actuelle.
                print(portion.text)
                # Afficher la hauteur de la police du texte.
                print(portion.portion_format.font_height)
                # Afficher le nom de la police du texte.
                if portion.portion_format.latin_font is not None:
                    print(portion.portion_format.latin_font.font_name)
```


## **Extraire le texte d'une présentation**

Pour balayer le texte de l'ensemble de la présentation, utilisez la méthode statique [get_all_text_frames](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/get_all_text_frames/) exposée par la classe [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/). Elle accepte deux paramètres :

1. Un objet [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) représentant une présentation PowerPoint ou OpenDocument dont le texte sera extrait.
2. Une valeur `Boolean` indiquant si les diapositives maîtres doivent être incluses lors du balayage du texte de la présentation.

La méthode renvoie un tableau d'objets de type [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), incluant les informations de formatage du texte. Le code ci‑dessous parcourt le texte et les détails de formatage d'une présentation, y compris les diapositives maîtres.
```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente un fichier PPTX.
with slides.Presentation("pres.pptx") as presentation:
    # Obtenir un tableau d'objets TextFrame à partir de toutes les diapositives du fichier PPTX.
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, True)
    # Parcourir le tableau des cadres de texte.
    for text_frame in text_frames:
        # Parcourir les paragraphes du cadre de texte actuel.
        for paragraph in text_frame.paragraphs:
            # Parcourir les portions de texte du paragraphe actuel.
            for portion in paragraph.portions:
                # Afficher le texte de la portion actuelle.
                print(portion.text)
                # Afficher la hauteur de police du texte.
                print(portion.portion_format.font_height)
                # Afficher le nom de la police du texte.
                if portion.portion_format.latin_font is not None:
                    print(portion.portion_format.latin_font.font_name)
```


## **Extraction de texte catégorisée et rapide**

La classe [PresentationFactory](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentationfactory/) propose également des méthodes statiques pour extraire tout le texte des présentations :
```py
PresentationFactory.get_presentation_text(stream, mode)
PresentationFactory.get_presentation_text(file, mode)
PresentationFactory.get_presentation_text(stream, mode, options)
```


L'argument d'énumération [TextExtractionArrangingMode](https://reference.aspose.com/slides/python-net/aspose.slides/textextractionarrangingmode/) indique le mode d'organisation du résultat d'extraction du texte et peut être défini sur les valeurs suivantes :
- `UNARRANGED` – Le texte brut sans tenir compte de sa position sur la diapositive.
- `ARRANGED` – Le texte est organisé dans le même ordre que sur la diapositive.

Le mode `UNARRANGED` peut être utilisé lorsque la vitesse est cruciale ; il est plus rapide que le mode `ARRANGED`.

[PresentationText](https://reference.aspose.com/slides/python-net/aspose.slides/presentationtext/) représente le texte brut extrait de la présentation. Il contient la propriété `slides_text`, qui renvoie un tableau d'objets de type [ISlideText](https://reference.aspose.com/slides/python-net/aspose.slides/islidetext/). Chaque objet représente le texte de la diapositive correspondante. L'objet de type [ISlideText](https://reference.aspose.com/slides/python-net/aspose.slides/islidetext/) possède les propriétés suivantes :

- `text` – Le texte présent dans les formes de la diapositive.
- `master_text` – Le texte présent dans les formes de la diapositive maîtresse associée à cette diapositive.
- `layout_text` – Le texte présent dans les formes de la diapositive modèle associée à cette diapositive.
- `notes_text` – Le texte présent dans les formes de la diapositive de notes associée à cette diapositive.
- `comments_text` – Le texte présent dans les commentaires associés à cette diapositive.
```py
import aspose.slides as slides

arranging_mode = slides.TextExtractionArrangingMode.UNARRANGED
presentation_text = slides.PresentationFactory().get_presentation_text("sample.pptx", arranging_mode)
slide_text = presentation_text.slides_text[0]
print(slide_text.text)
print(slide_text.layout_text)
print(slide_text.master_text)
print(slide_text.notes_text)
```


## **FAQ**

**Quelle rapidité Aspose.Slides offre‑t‑il pour le traitement de présentations volumineuses lors de l'extraction de texte ?**

Aspose.Slides est optimisé pour des performances élevées et traite efficacement même les [grandes présentations](/slides/fr/python-net/open-presentation/), ce qui le rend adapté aux scénarios de traitement en temps réel ou en masse.

**Aspose.Slides peut‑il extraire le texte des tableaux et des graphiques au sein des présentations ?**

Oui, Aspose.Slides prend pleinement en charge l'extraction de texte à partir de tableaux, de graphiques et d'autres éléments de diapositive complexes, vous permettant d'accéder et d'analyser facilement tout le contenu textuel.

**Ai‑je besoin d'une licence spéciale Aspose.Slides pour extraire le texte des présentations ?**

Vous pouvez extraire le texte en utilisant la version d'essai gratuite d'Aspose.Slides, bien qu'elle comporte [certaines limitations](/slides/fr/python-net/licensing/), comme le traitement d'un nombre limité de diapositives. Pour une utilisation illimitée et afin de gérer des présentations plus volumineuses, l'achat d'une licence complète est recommandé.