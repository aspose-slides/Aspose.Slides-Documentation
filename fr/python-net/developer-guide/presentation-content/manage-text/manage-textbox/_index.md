---
title: Gérer TextBox
type: docs
weight: 20
url: /python-net/manage-textbox/
keywords: "Textbox, Cadre de texte, Ajouter textbox, Textbox avec lien hypertexte, Python, Aspose.Slides pour Python via .NET"
description: "Ajouter un textbox ou un cadre de texte aux présentations PowerPoint en Python ou .NET"
---

Les textes sur les diapositives existent généralement dans des zones de texte ou des formes. Par conséquent, pour ajouter un texte à une diapositive, vous devez ajouter une zone de texte et ensuite mettre un texte à l'intérieur de la zone de texte. Aspose.Slides pour Python via .NET fournit l'interface [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) qui vous permet d'ajouter une forme contenant du texte.

{{% alert title="Info" color="info" %}}

Aspose.Slides fournit également l'interface [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) qui permet d'ajouter des formes aux diapositives. Cependant, toutes les formes ajoutées via l'interface `IShape` ne peuvent pas contenir de texte. Mais les formes ajoutées via l'interface [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) peuvent contenir du texte.

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Par conséquent, lorsque vous traitez avec une forme à laquelle vous souhaitez ajouter du texte, vous voudrez peut-être vérifier et confirmer qu'elle a été castée via l'interface `IAutoShape`. Ce n'est qu'alors que vous pourrez travailler avec [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/), qui est une propriété sous `IAutoShape`. Consultez la section [Mettre à jour le texte](https://docs.aspose.com/slides/python-net/manage-textbox/#update-text) sur cette page.

{{% /alert %}}

## **Créer une zone de texte sur la diapositive**

Pour créer une zone de texte sur une diapositive, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une référence pour la première diapositive de la présentation nouvellement créée.
3. Ajoutez un objet [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) avec [ShapeType](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/) défini comme `RECTANGLE` à une position spécifiée sur la diapositive et obtenez la référence pour le nouvel objet `IAutoShape` ajouté.
4. Ajoutez une propriété `text_frame` à l'objet `IAutoShape` qui contiendra un texte. Dans l'exemple ci-dessous, nous avons ajouté ce texte : *Aspose TextBox*.
5. Enfin, écrivez le fichier PPTX via l'objet `Presentation`.

Ce code Python — une implémentation des étapes ci-dessus — vous montre comment ajouter du texte à une diapositive :

```py
import aspose.slides as slides

# Instancie PresentationEx
with slides.Presentation() as pres:

    # Obtient la première diapositive de la présentation
    sld = pres.slides[0]

    # Ajoute une AutoShape avec le type défini comme Rectangle
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # Ajoute TextFrame au Rectangle
    ashp.add_text_frame(" ")

    # Accède au cadre de texte
    txtFrame = ashp.text_frame

    # Crée l'objet Paragraph pour le cadre de texte
    para = txtFrame.paragraphs[0]

    # Crée un objet Portion pour le paragraphe
    portion = para.portions[0]

    # Définit le texte
    portion.text = "Aspose TextBox"

    # Enregistre la présentation sur le disque
    pres.save("TextBox_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Vérifier si la forme est une zone de texte**

Aspose.Slides fournit la propriété `is_text_box` (de la classe [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)) pour vous permettre d'examiner les formes et de trouver des zones de texte.

![Zone de texte et forme](istextbox.png)

Ce code Python vous montre comment vérifier si une forme a été créée comme une zone de texte : xxx

```python
from aspose.slides import Presentation, AutoShape

with Presentation("pres.pptx") as pres:
    for slide in pres.slides:
        for shape in slide.shapes:
            if (type(shape) is AutoShape):
                print("la forme est une zone de texte" if shape.is_text_box else "la forme n'est pas une zone de texte")
```

## **Ajouter une colonne dans la zone de texte**

Aspose.Slides fournit les propriétés [column_count](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformat/) et [column_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) (de l'interface [ITextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformat/) et de la classe [text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)) qui vous permettent d'ajouter des colonnes aux zones de texte. Vous pouvez spécifier le nombre de colonnes dans une zone de texte et définir l'espacement en points entre les colonnes.

Ce code en Python démontre l'opération décrite :

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Obtient la première diapositive de la présentation
    slide = presentation.slides[0]

    # Ajoute une AutoShape avec le type défini comme Rectangle
    aShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

    # Ajoute TextFrame au Rectangle
    aShape.add_text_frame("Toutes ces colonnes sont limitées à être à l'intérieur d'un seul conteneur de texte -- " +
    "vous pouvez ajouter ou supprimer du texte et le nouveau texte ou le texte restant s'ajuste automatiquement " +
    "pour s'écouler à l'intérieur du conteneur. Vous ne pouvez pas faire couler du texte d'un conteneur " +
    "à un autre cependant -- nous vous avons dit que les options de colonnes de PowerPoint pour le texte sont limitées!")

    # Obtient le format de texte de TextFrame
    format = aShape.text_frame.text_frame_format

    # Spécifie le nombre de colonnes dans TextFrame
    format.column_count = 3

    # Spécifie l'espacement entre les colonnes
    format.column_spacing = 10

    # Enregistre la présentation
    presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajouter une colonne dans le cadre de texte**
Aspose.Slides pour Python via .NET fournit la propriété [ColumnCount](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformat/) (de l'interface [ITextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformat/)) qui vous permet d'ajouter des colonnes dans les cadres de texte. Grâce à cette propriété, vous pouvez spécifier votre nombre de colonnes préféré dans un cadre de texte.

Ce code Python vous montre comment ajouter une colonne dans un cadre de texte :

```py
import aspose.slides as slides

outPptxFileName = "ColumnsTest.pptx"
with slides.Presentation() as pres:
    shape1 = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)
    format = shape1.text_frame.text_frame_format

    format.column_count = 2
    shape1.text_frame.text = """Toutes ces colonnes sont forcées de rester à l'intérieur d'un seul conteneur de texte -- 
        vous pouvez ajouter ou supprimer du texte - et le nouveau texte ou le texte restant s'ajuste automatiquement 
        pour rester à l'intérieur du conteneur. Vous ne pouvez pas faire couler du texte d'un conteneur 
        à un autre, cependant -- parce que les options de colonnes de PowerPoint pour le texte sont limitées!
        pres.save(outPptxFileName, slides.export.SaveFormat.PPTX)"""

    with slides.Presentation(path + outPptxFileName) as test:
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_count)
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_spacing)

    format.column_spacing = 20
    pres.save(path + outPptxFileName, slides.export.SaveFormat.PPTX)

    with slides.Presentation(path + outPptxFileName) as test:
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_count)
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_spacing)

    format.column_count = 3
    format.column_spacing = 15
    pres.save(path + outPptxFileName, slides.export.SaveFormat.PPTX)

    with slides.Presentation(path + outPptxFileName) as test:
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_count)
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_spacing)
```

## **Mettre à jour le texte**

Aspose.Slides vous permet de changer ou de mettre à jour le texte contenu dans une zone de texte ou tous les textes contenus dans une présentation.

Ce code Python démontre une opération où tous les textes dans une présentation sont mis à jour ou changés :

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    for slide in pres.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = 1
  
    # Enregistre la présentation modifiée
    pres.save("text-changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajouter une zone de texte avec un lien hypertexte**

Vous pouvez insérer un lien à l'intérieur d'une zone de texte. Lorsque la zone de texte est cliquée, les utilisateurs sont dirigés pour ouvrir le lien.

Pour ajouter une zone de texte contenant un lien, suivez ces étapes :

1. Créez une instance de la classe `Presentation`.
2. Obtenez une référence pour la première diapositive de la présentation nouvellement créée.
3. Ajoutez un objet `AutoShape` avec `ShapeType` défini comme `RECTANGLE` à une position spécifiée sur la diapositive et obtenez une référence de l'objet AutoShape nouvellement ajouté.
4. Ajoutez un `text_frame` à l'objet `AutoShape` qui contient *Aspose TextBox* comme texte par défaut.
5. Instanciez la classe `hyperlink_manager`.
6. Assignez l'objet `hyperlink_manager` à la propriété [HyperlinkClick](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) associée à votre portion préférée du `TextFrame`.
7. Enfin, écrivez le fichier PPTX via l'objet `Presentation`.

Ce code Python — une implémentation des étapes ci-dessus — vous montre comment ajouter une zone de texte avec un lien hypertexte à une diapositive :

```py
import aspose.slides as slides

# Instancie une classe Presentation qui représente un PPTX
with slides.Presentation() as pptxPresentation:
    # Obtient la première diapositive de la présentation
    slide = pptxPresentation.slides[0]

    # Ajoute un objet AutoShape avec le type défini comme Rectangle
    pptxShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    # Accède à la propriété ITextFrame associée à l'AutoShape
    pptxShape.add_text_frame("")

    textFrame = pptxShape.text_frame

    # Ajoute du texte au cadre
    textFrame.paragraphs[0].portions[0].text = "Aspose.Slides"

    # Définit le lien hypertexte pour le texte de la portion
    hm = textFrame.paragraphs[0].portions[0].portion_format.hyperlink_manager
    hm.set_external_hyperlink_click("http://www.aspose.com")
    # Enregistre la présentation PPTX
    pptxPresentation.save("hLinkPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```