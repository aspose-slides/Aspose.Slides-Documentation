---
title: Convertir les présentations PowerPoint en documents Word en Python
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
description: "Apprenez comment convertir facilement les présentations PowerPoint et OpenDocument en documents Word à l’aide d’Aspose.Slides pour Python via .NET. Notre guide étape par étape avec du code Python d’exemple offre la solution aux développeurs souhaitant rationaliser leurs flux de travail documentaires."
---

## **Vue d'ensemble**

Cet article propose une solution aux développeurs pour convertir les présentations PowerPoint et OpenDocument en documents Word en utilisant Aspose.Slides for Python via .NET et Aspose.Words for Python via .NET. Le guide étape par étape vous accompagne à chaque étape du processus de conversion.

## **Convertir une présentation en document Word**

Suivez les instructions ci-dessous pour convertir une présentation PowerPoint ou OpenDocument en document Word :

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et chargez un fichier de présentation.  
2. Instanciez les classes [Document](https://reference.aspose.com/words/python-net/aspose.words/document/) et [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/) pour générer un document Word.  
3. Définissez la taille de page du document Word pour qu’elle corresponde à celle de la présentation en utilisant la propriété [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/).  
4. Définissez les marges du document Word en utilisant la propriété [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/).  
5. Parcourez toutes les diapositives de la présentation en utilisant la propriété [Presentation.slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) :  
    - Générez une image de diapositive en utilisant la méthode `get_image` de la classe [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) puis enregistrez‑la dans un flux mémoire.  
    - Ajoutez l’image de la diapositive au document Word en utilisant la méthode `insert_image` de la classe [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/) .  
6. Enregistrez le document Word dans un fichier.

Supposons que nous ayons une présentation "sample.pptx" qui ressemble à ceci :

![Présentation PowerPoint](PowerPoint.png)

L’exemple de code Python suivant montre comment convertir la présentation PowerPoint en document Word :
```py
import aspose.slides as slides
import aspose.words as words

# Charger un fichier de présentation.
with slides.Presentation("sample.pptx") as presentation:

    # Créer les objets Document et DocumentBuilder.
    document = words.Document()
    builder = words.DocumentBuilder(document)

    # Définir la taille de la page dans le document Word.
    slide_size = presentation.slide_size.size
    builder.page_setup.page_width = slide_size.width
    builder.page_setup.page_height = slide_size.height

    # Définir les marges dans le document Word.
    builder.page_setup.left_margin = 0
    builder.page_setup.right_margin = 0
    builder.page_setup.top_margin = 0
    builder.page_setup.bottom_margin = 0

    scale_x = 2
    scale_y = 2

    # Parcourir toutes les diapositives de la présentation.
    for slide in presentation.slides:

        # Générer une image de diapositive et l'enregistrer dans un flux mémoire.
        with slide.get_image(scale_x, scale_y) as image:
            image_stream = BytesIO()
            image.save(image_stream, slides.ImageFormat.PNG)

        # Ajouter l'image de la diapositive au document Word.
        image_stream.seek(0)
        image_width = builder.page_setup.page_width
        image_height = builder.page_setup.page_height
        builder.insert_image(image_stream.read(), image_width, image_height)

        builder.insert_break(words.BreakType.PAGE_BREAK)

    # Enregistrer le document Word dans un fichier.
    document.save("output.docx")
```


Le résultat :

![Document Word](Word.png)

{{% alert color="primary" %}} 

Essayez notre [**Convertisseur PPT en Word en ligne**](https://products.aspose.app/slides/conversion/ppt-to-word) pour voir ce que vous pourriez gagner en convertissant les présentations PowerPoint et OpenDocument en documents Word. 

{{% /alert %}}

## **FAQ**

**Quels composants doivent être installés pour convertir des présentations PowerPoint et OpenDocument en documents Word ?**

Vous devez uniquement ajouter les packages respectifs pour [Aspose.Slides pour Python via .NET](https://pypi.org/project/Aspose.Slides/) et [Aspose.Words pour Python .NET](https://pypi.org/project/aspose-words/) à votre projet Python. Les deux packages fonctionnent comme des API autonomes et il n’est pas nécessaire d’installer Microsoft Office.

**Tous les formats de présentation PowerPoint et OpenDocument sont-ils pris en charge ?**

Aspose.Slides for Python .NET [prend en charge tous les formats de présentation](/slides/fr/python-net/supported-file-formats/), y compris PPT, PPTX, ODP et d’autres types de fichiers courants. Cela garantit que vous pouvez travailler avec des présentations créées dans différentes versions de Microsoft PowerPoint.