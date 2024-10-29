---
title: Gérer la forme SmartArt
type: docs
weight: 20
url: /fr/python-net/manage-smartart-shape/
keywords: "forme SmartArt, style de forme SmartArt, style de couleur de forme SmartArt, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Gérer SmartArt dans les présentations PowerPoint en Python"
---

## **Créer une forme SmartArt**
Aspose.Slides pour Python via .NET facilite désormais l'ajout de formes SmartArt personnalisées dans leurs diapositives depuis le début. Aspose.Slides pour Python via .NET a fourni l'API la plus simple pour créer des formes SmartArt de la manière la plus facile. Pour créer une forme SmartArt dans une diapositive, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Obtenez la référence d'une diapositive en utilisant son index.
- Ajoutez une forme SmartArt en définissant son LayoutType.
- Écrivez la présentation modifiée en tant que fichier PPTX.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# Instancier la présentation
with slides.Presentation() as pres:
    # Accéder à la diapositive de la présentation
    slide = pres.slides[0]

    # Ajouter une forme Smart Art
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.BASIC_BLOCK_LIST)

    # Sauvegarder la présentation
    pres.save("SimpleSmartArt_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Accéder à la forme SmartArt dans la diapositive**
Le code suivant sera utilisé pour accéder aux formes SmartArt ajoutées dans la diapositive de présentation. Dans le code d'exemple, nous parcourrons chaque forme à l'intérieur de la diapositive et vérifierons si c'est une forme SmartArt. Si la forme est de type SmartArt, nous ferons un typage de celle-ci en instance de SmartArt.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# Charger la présentation souhaitée
with slides.Presentation(path + "SmartArt.pptx") as pres:

    # Parcourir chaque forme à l'intérieur de la première diapositive
    for shape in pres.slides[0].shapes:
        # Vérifier si la forme est de type SmartArt
        if type(shape) is art.SmartArt:
            # Typage de la forme en SmartArtEx
            print("Nom de la forme:" + shape.name)
```



## **Accéder à la forme SmartArt avec un type de mise en page particulier**
Le code d'exemple suivant aidera à accéder à la forme SmartArt avec un LayoutType particulier. Veuillez noter que vous ne pouvez pas changer le LayoutType de la SmartArt car il est en lecture seule et est défini uniquement lors de l'ajout de la forme SmartArt.

- Créez une instance de la classe `Presentation` et chargez la présentation avec la forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son index.
- Parcourez chaque forme à l'intérieur de la première diapositive.
- Vérifiez si la forme est de type SmartArt et faites le typage de la forme sélectionnée en SmartArt si elle est SmartArt.
- Vérifiez la forme SmartArt avec un LayoutType particulier et effectuez ce qui est nécessaire par la suite.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation(path + "SmartArt.pptx") as presentation:
    # Parcourir chaque forme à l'intérieur de la première diapositive
    for shape in presentation.slides[0].shapes:
        # Vérifier si la forme est de type SmartArt
        if type(shape) is art.SmartArt:
            # Vérifier le Layout de SmartArt
            if shape.layout == art.SmartArtLayoutType.BASIC_BLOCK_LIST:
                print("Faire quelque chose ici....")
```



## **Changer le style de la forme SmartArt**
Le code d'exemple suivant aidera à accéder à la forme SmartArt avec un LayoutType particulier.

- Créez une instance de la classe `Presentation` et chargez la présentation avec la forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son index.
- Parcourez chaque forme à l'intérieur de la première diapositive.
- Vérifiez si la forme est de type SmartArt et faites le typage de la forme sélectionnée en SmartArt si elle est SmartArt.
- Trouvez la forme SmartArt avec un Style particulier.
- Définissez le nouveau Style pour la forme SmartArt.
- Sauvegardez la Présentation.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation(path + "SmartArt.pptx") as presentation:
    # Parcourir chaque forme à l'intérieur de la première diapositive
    for shape in presentation.slides[0].shapes:
        # Vérifier si la forme est de type SmartArt
        if type(shape) is art.SmartArt:
            # Vérifier le style de SmartArt
            if shape.quick_style == art.SmartArtQuickStyleType.SIMPLE_FILL:
                # Changer le style de SmartArt
                smart.quick_style = art.SmartArtQuickStyleType.CARTOON

    # Sauvegarder la Présentation
    presentation.save("ChangeSmartArtStyle_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Changer le style de couleur de la forme SmartArt**
Dans cet exemple, nous allons apprendre à changer le style de couleur pour toute forme SmartArt. Dans le code d'exemple suivant, nous accéderons à la forme SmartArt avec un style de couleur particulier et changerons son style.

- Créez une instance de la classe `Presentation` et chargez la présentation avec la forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son index.
- Parcourez chaque forme à l'intérieur de la première diapositive.
- Vérifiez si la forme est de type SmartArt et faites le typage de la forme sélectionnée en SmartArt si elle est SmartArt.
- Trouvez la forme SmartArt avec un style de couleur particulier.
- Définissez le nouveau style de couleur pour la forme SmartArt.
- Sauvegardez la Présentation.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation(path + "SmartArt.pptx") as presentation:
    # Parcourir chaque forme à l'intérieur de la première diapositive
    for shape in presentation.slides[0].shapes:
        # Vérifier si la forme est de type SmartArt
        if type(shape) is art.SmartArt:
            # Vérifier le type de couleur de SmartArt
            if shape.color_style == art.SmartArtColorType.COLORED_FILL_ACCENT1:
                # Changer le type de couleur de SmartArt
                shape.color_style = art.SmartArtColorType.COLORFUL_ACCENT_COLORS

    # Sauvegarder la Présentation
    presentation.save("ChangeSmartArtColorStyle_out.pptx", slides.export.SaveFormat.PPTX)
```