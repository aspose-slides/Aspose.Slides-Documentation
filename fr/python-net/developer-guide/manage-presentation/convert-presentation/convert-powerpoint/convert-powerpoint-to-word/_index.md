---
title: Convertir des présentations PowerPoint en documents Word en Python
linktitle: PowerPoint vers Word
type: docs
weight: 110
url: /fr/python-net/convert-powerpoint-to-word/
keywords:
- PowerPoint vers DOCX
- OpenDocument vers DOCX
- présentation vers DOCX
- diapositive vers DOCX
- PPT vers DOCX
- PPTX vers DOCX
- ODP vers DOCX
- PowerPoint vers DOC
- OpenDocument vers DOC
- présentation vers DOC
- diapositive vers DOC
- PPT vers DOC
- PPTX vers DOC
- ODP vers DOC
- PowerPoint vers Word
- OpenDocument vers Word
- présentation vers Word
- diapositive vers Word
- PPT vers Word
- PPTX vers Word
- ODP vers Word
- convertir PowerPoint
- convertir OpenDocument
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- convertir ODP
- Python
- Aspose.Slides
description: "Découvrez comment convertir facilement des présentations PowerPoint et OpenDocument en documents Word avec Aspose.Slides for Python via .NET. Notre guide étape par étape, avec des exemples de code Python, propose une solution aux développeurs souhaitant rationaliser leurs flux de documents."
---

Si vous envisagez d'utiliser du contenu textuel ou des informations d'une présentation (PPT ou PPTX) de nouvelles manières, vous pourriez bénéficier de la conversion de la présentation en Word (DOC ou DOCX).

* Comparé à Microsoft PowerPoint, l'application Microsoft Word est mieux équipée avec des outils ou des fonctionnalités pour le contenu.
* En plus des fonctions d'édition dans Word, vous pouvez également bénéficier de fonctionnalités améliorées de collaboration, d'impression et de partage.

{{% alert color="primary" %}} 

Vous voudrez peut-être essayer notre [**Convertisseur en ligne de Présentation à Word**](https://products.aspose.app/slides/conversion/ppt-to-word) pour voir ce que vous pourriez gagner en travaillant avec le contenu textuel des diapositives.

{{% /alert %}} 

## **Aspose.Slides et Aspose.Words**

Pour convertir un fichier PowerPoint (PPTX ou PPT) en Word (DOCX ou DOC), vous avez besoin à la fois de [Aspose.Slides pour Python via .NET](https://products.aspose.com/slides/python-net/) et de [Aspose.Words pour Python via .NET](https://products.aspose.com/words/python-net/).

En tant qu'API autonome, [Aspose.Slides](https://products.aspose.com/slides/python-net/) pour Python via .NET fournit des fonctions qui vous permettent d'extraire des textes des présentations.

[Aspose.Words](https://products.aspose.com/words/python-net/) est une API avancée de traitement de documents qui permet aux applications de générer, modifier, convertir, rendre, imprimer des fichiers, et d'effectuer d'autres tâches avec des documents sans utiliser Microsoft Word.

## **Convertir PowerPoint en Word en Python**

1. Ajoutez ces espaces de noms à votre fichier program.py :

```py
import aspose.slides as slides
import aspose.words as words
```

2. Utilisez ce code pour convertir PowerPoint en Word :

```py
with slides.Presentation("sample.pptx") as presentation:
    doc = words.Document()
    builder = words.DocumentBuilder(doc)

    for index in range(presentation.slides.length):
        slide = presentation.slides[index]

        file_name = "slide_{i}.png".format(i=index)

        # génère une image de la diapositive
        with slide.get_image(1, 1) as image:
            image.save(file_name, slides.ImageFormat.PNG)

        builder.insert_image(file_name)

        for shape in slide.shapes:
            # insère les textes de la diapositive
            if type(shape) is slides.AutoShape:
                builder.writeln(shape.text_frame.text)

        builder.insert_break(words.BreakType.PAGE_BREAK)
    doc.save("output.docx")
```