---
title: Gérer TextBox
type: docs
weight: 20
url: /androidjava/manage-textbox/
description: Créer une zone de texte sur des diapositives PowerPoint en utilisant Java. Ajouter une colonne dans une zone de texte ou un cadre de texte dans des diapositives PowerPoint en utilisant Java. Ajouter une zone de texte avec un lien hypertexte dans des diapositives PowerPoint en utilisant Java.
---

Les textes sur les diapositives existent généralement dans des zones de texte ou des formes. Par conséquent, pour ajouter un texte à une diapositive, vous devez ajouter une zone de texte et ensuite mettre du texte à l'intérieur de la zone de texte. Aspose.Slides pour Android via Java fournit l'interface [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) qui vous permet d'ajouter une forme contenant du texte.

{{% alert title="Info" color="info" %}}

Aspose.Slides fournit également l'interface [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) qui vous permet d'ajouter des formes aux diapositives. Cependant, toutes les formes ajoutées via l'interface `IShape` ne peuvent pas contenir de texte. Mais les formes ajoutées via l'interface [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) peuvent contenir du texte.

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Par conséquent, lorsque vous traitez avec une forme à laquelle vous souhaitez ajouter du texte, vous devrez vérifier et confirmer qu'elle a été convertie via l'interface `IAutoShape`. Ce n'est qu'alors que vous pourrez travailler avec [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame), qui est une propriété sous `IAutoShape`. Consultez la section [Mettre à jour le texte](https://docs.aspose.com/slides/androidjava/manage-textbox/#update-text) sur cette page.

{{% /alert %}}

## **Créer une zone de texte sur la diapositive**

Pour créer une zone de texte sur une diapositive, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenez une référence pour la première diapositive de la présentation nouvellement créée. 
3. Ajoutez un objet [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) avec [ShapeType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#setShapeType-int-) défini comme `Rectangle` à une position spécifiée sur la diapositive et obtenez la référence de l'objet `IAutoShape` nouvellement ajouté.
4. Ajoutez une propriété `TextFrame` à l'objet `IAutoShape` qui contiendra un texte. Dans l'exemple ci-dessous, nous avons ajouté ce texte : *Aspose TextBox*
5. Enfin, écrivez le fichier PPTX via l'objet `Presentation`.

Ce code Java - une implémentation des étapes ci-dessus - vous montre comment ajouter du texte à une diapositive :

```java
// Instancie la présentation
Presentation pres = new Presentation();
try {
    // Obtient la première diapositive dans la présentation
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajoute une AutoShape avec le type défini comme Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Ajoute TextFrame au Rectangle
    ashp.addTextFrame(" ");

    // Accède au cadre de texte
    ITextFrame txtFrame = ashp.getTextFrame();

    // Crée l'objet Paragraph pour le cadre de texte
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Crée un objet Portion pour le paragraphe
    IPortion portion = para.getPortions().get_Item(0);

    // Définit le texte
    portion.setText("Aspose TextBox");

    // Sauvegarde la présentation sur le disque
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vérifier la forme de la zone de texte**

Aspose.Slides fournit la propriété [isTextBox()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/#isTextBox--) (de la classe [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/)) pour vous permettre d'examiner les formes et de trouver des zones de texte.

![Boîte de texte et forme](istextbox.png)

Ce code Java vous montre comment vérifier si une forme a été créée comme une zone de texte : 

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ForEach.shape(pres, (shape, slide, index) ->
    {
        if (shape instanceof AutoShape)
        {
            AutoShape autoShape = (AutoShape)shape;
            System.out.println(autoShape.isTextBox() ? "la forme est une zone de texte" : "la forme n'est pas une zone de texte");
        }
    });
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ajouter une colonne dans la zone de texte**

Aspose.Slides fournit les propriétés [ColumnCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) et [ColumnSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (de l'interface [ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat) et de la classe [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) qui vous permettent d'ajouter des colonnes à des zones de texte. Vous pouvez spécifier le nombre de colonnes dans une zone de texte et définir l'espacement entre les colonnes en points.

Ce code en Java démontre l'opération décrite : 

```java
Presentation pres = new Presentation();
try {
    // Obtient la première diapositive dans la présentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajoute une AutoShape avec le type défini comme Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Ajoute TextFrame au Rectangle
    aShape.addTextFrame("Toutes ces colonnes sont limitées à être à l'intérieur d'un seul conteneur de texte -- " +
            "vous pouvez ajouter ou supprimer du texte et le nouveau texte ou le texte restant s'ajuste automatiquement " +
            "pour s'écouler à l'intérieur du conteneur. Vous ne pouvez pas avoir de texte s'écoulant d'un conteneur " +
            "à un autre cependant -- nous vous avons dit que les options de colonnes de PowerPoint pour le texte sont limitées !");

    // Obtient le format de texte de TextFrame
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // Spécifie le nombre de colonnes dans TextFrame
    format.setColumnCount(3);

    // Spécifie l'espacement entre les colonnes
    format.setColumnSpacing(10);

    // Sauvegarde la présentation
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ajouter une colonne dans le cadre de texte**
Aspose.Slides pour Android via Java fournit la propriété [ColumnCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (de l'interface [ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat)) qui vous permet d'ajouter des colonnes dans des cadres de texte. Grâce à cette propriété, vous pouvez spécifier votre nombre de colonnes préféré dans un cadre de texte.

Ce code Java vous montre comment ajouter une colonne à l'intérieur d'un cadre de texte :

```java
String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("Toutes ces colonnes sont contraintes de rester à l'intérieur d'un unique conteneur de texte -- " +
            "vous pouvez ajouter ou supprimer du texte - et le nouveau texte ou le texte restant s'ajuste automatiquement " +
            "pour rester à l'intérieur du conteneur. Vous ne pouvez pas avoir de texte débordant d'un conteneur " +
            "à un autre, cependant -- car les options de colonnes de PowerPoint pour le texte sont limitées !");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(Double.NaN == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Mettre à jour le texte**

Aspose.Slides vous permet de modifier ou de mettre à jour le texte contenu dans une zone de texte ou tous les textes contenus dans une présentation.

Ce code Java démontre une opération où tous les textes d'une présentation sont mis à jour ou changés :

```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) // Vérifie si la forme supporte le cadre de texte (IAutoShape). 
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) // Itère à travers les paragraphes dans le cadre de texte
                {
                    for (IPortion portion : paragraph.getPortions()) // Itère à travers chaque portion dans le paragraphe
                    {
                        portion.setText(portion.getText().replace("years", "months")); // Change le texte
                        portion.getPortionFormat().setFontBold(NullableBool.True); // Change le formatage
                    }
                }
            }
        }
    }

    // Sauvegarde la présentation modifiée
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ajouter une zone de texte avec un lien hypertexte** 

Vous pouvez insérer un lien à l'intérieur d'une zone de texte. Lorsque la zone de texte est cliquée, les utilisateurs sont dirigés pour ouvrir le lien.

Pour ajouter une zone de texte contenant un lien, suivez ces étapes :

1. Créez une instance de la classe `Presentation`. 
2. Obtenez une référence pour la première diapositive de la présentation nouvellement créée. 
3. Ajoutez un objet `AutoShape` avec `ShapeType` défini comme `Rectangle` à une position spécifiée sur la diapositive et obtenez une référence de l'objet AutoShape nouvellement ajouté.
4. Ajoutez un `TextFrame` à l'objet `AutoShape` qui contient *Aspose TextBox* comme texte par défaut. 
5. Instanciez la classe `IHyperlinkManager`. 
6. Assignez l'objet `IHyperlinkManager` à la propriété [HyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape#getHyperlinkClick--) associée à votre portion préférée du `TextFrame`.
7. Enfin, écrivez le fichier PPTX via l'objet `Presentation`. 

Ce code Java - une implémentation des étapes ci-dessus - vous montre comment ajouter une zone de texte avec un lien hypertexte à une diapositive :

```java
// Instancie une classe Presentation qui représente un PPTX
Presentation pres = new Presentation();
try {
    // Obtient la première diapositive dans la présentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajoute un objet AutoShape avec le type défini comme Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Cast la forme à AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Accède à la propriété ITextFrame associée à l'AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Ajoute du texte au cadre
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Définit le lien hypertexte pour le texte de la portion
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // Sauvegarde la présentation PPTX
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```