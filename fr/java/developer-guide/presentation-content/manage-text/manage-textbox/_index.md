---
title: Gérer TextBox
type: docs
weight: 20
url: /java/manage-textbox/
description: Créer une zone de texte sur des diapositives PowerPoint en utilisant Java. Ajouter une colonne dans une zone de texte ou un cadre de texte dans des diapositives PowerPoint en utilisant Java. Ajouter une zone de texte avec un lien hypertexte dans des diapositives PowerPoint en utilisant Java.
---


Les textes sur les diapositives existent généralement dans des zones de texte ou des formes. Par conséquent, pour ajouter un texte à une diapositive, vous devez ajouter une zone de texte et ensuite y mettre du texte. Aspose.Slides pour Java fournit l'interface [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) qui vous permet d'ajouter une forme contenant du texte.

{{% alert title="Info" color="info" %}}

Aspose.Slides fournit également l'interface [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) qui vous permet d'ajouter des formes aux diapositives. Cependant, toutes les formes ajoutées via l'interface `IShape` ne peuvent pas contenir de texte. Mais les formes ajoutées via l'interface [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) peuvent contenir du texte. 

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Par conséquent, lorsque vous manipulez une forme à laquelle vous souhaitez ajouter du texte, vous devez vérifier et confirmer qu'elle a été castée via l'interface `IAutoShape`. Ce n'est qu'alors que vous pourrez travailler avec [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame), qui est une propriété sous `IAutoShape`. Consultez la section [Mettre à jour le texte](https://docs.aspose.com/slides/java/manage-textbox/#update-text) sur cette page. 

{{% /alert %}}

## **Créer une zone de texte sur la diapositive**

Pour créer une zone de texte sur une diapositive, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). 
2. Obtenez une référence pour la première diapositive dans la présentation nouvellement créée. 
3. Ajoutez un objet [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) avec le [ShapeType](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryShape#setShapeType-int-) défini comme `Rectangle` à une position spécifiée sur la diapositive et obtenez la référence de l'objet `IAutoShape` nouvellement ajouté. 
4. Ajoutez une propriété `TextFrame` à l'objet `IAutoShape` qui contiendra un texte. Dans l'exemple ci-dessous, nous avons ajouté ce texte : *Aspose TextBox*
5. Enfin, écrivez le fichier PPTX via l'objet `Presentation`. 

Ce code Java—une implémentation des étapes ci-dessus—vous montre comment ajouter du texte à une diapositive :

```java
// Instantiates Presentation
Presentation pres = new Presentation();
try {
    // Gets the first slide in the presentation
    ISlide sld = pres.getSlides().get_Item(0);

    // Adds an AutoShape with type set as Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Adds TextFrame to the Rectangle
    ashp.addTextFrame(" ");

    // Accesses the text frame
    ITextFrame txtFrame = ashp.getTextFrame();

    // Creates the Paragraph object for text frame
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Creates a Portion object for paragraph
    IPortion portion = para.getPortions().get_Item(0);

    // Sets Text
    portion.setText("Aspose TextBox");

    // Saves the presentation to disk
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vérifier si c'est une forme de zone de texte**

Aspose.Slides fournit la propriété [isTextBox()](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/#isTextBox--) (de la classe [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/)) pour vous permettre d'examiner les formes et de trouver des zones de texte.

![Zone de texte et forme](istextbox.png)

Ce code Java vous montre comment vérifier si une forme a été créée en tant que zone de texte : 

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

## **Ajouter une colonne dans une zone de texte**

Aspose.Slides fournit les propriétés [ColumnCount](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) et [ColumnSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (de l'interface [ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat) et de la classe [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) qui vous permettent d'ajouter des colonnes aux zones de texte. Vous pouvez spécifier le nombre de colonnes dans une zone de texte et définir l'espacement en points entre les colonnes. 

Ce code en Java démontre l'opération décrite : 

```java
Presentation pres = new Presentation();
try {
    // Gets the first slide in the presentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Add an AutoShape with type set as Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Add TextFrame to the Rectangle
    aShape.addTextFrame("Toutes ces colonnes sont limitées à être à l'intérieur d'un seul conteneur de texte -- " +
            "vous pouvez ajouter ou supprimer du texte et le nouveau texte ou le texte restant s'ajuste automatiquement " +
            "pour s'écouler à l'intérieur du conteneur. Vous ne pouvez pas faire couler du texte d'un conteneur " +
            "à un autre -- nous vous avons dit que les options de colonnes de PowerPoint pour le texte sont limitées !");

    // Gets the text format of TextFrame
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // Specifies the number of columns in TextFrame
    format.setColumnCount(3);

    // Specifies the spacing between columns
    format.setColumnSpacing(10);

    // Saves the presentation
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ajouter une colonne dans un cadre de texte**
Aspose.Slides pour Java fournit la propriété [ColumnCount](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (de l'interface [ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat)) qui vous permet d'ajouter des colonnes dans des cadres de texte. Grâce à cette propriété, vous pouvez spécifier votre nombre de colonnes préféré dans un cadre de texte. 

Ce code Java vous montre comment ajouter une colonne à l'intérieur d'un cadre de texte :

```java
String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("Toutes ces colonnes sont forcées de rester à l'intérieur d'un seul conteneur de texte -- " +
            "vous pouvez ajouter ou supprimer du texte - et le nouveau texte ou le texte restant s'ajuste automatiquement " +
            "pour rester à l'intérieur du conteneur. Vous ne pouvez pas avoir du texte débordant d'un conteneur " +
            "à un autre, cependant -- parce que les options de colonnes de PowerPoint pour le texte sont limitées !");
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

Aspose.Slides vous permet de changer ou de mettre à jour le texte contenu dans une zone de texte ou tous les textes contenus dans une présentation. 

Ce code Java démontre une opération où tous les textes dans une présentation sont mis à jour ou changés :

```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //Vérifie si la forme supporte le cadre de texte (IAutoShape). 
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //Itère à travers les paragraphes dans le cadre de texte
                {
                    for (IPortion portion : paragraph.getPortions()) //Itère à travers chaque portion dans le paragraphe
                    {
                        portion.setText(portion.getText().replace("years", "months")); //Change le texte
                        portion.getPortionFormat().setFontBold(NullableBool.True); //Change la mise en forme
                    }
                }
            }
        }
    }

    //Sauvegarde la présentation modifiée
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ajouter une zone de texte avec un lien hypertexte** 

Vous pouvez insérer un lien à l'intérieur d'une zone de texte. Lorsque la zone de texte est cliquée, les utilisateurs sont redirigés pour ouvrir le lien. 

Pour ajouter une zone de texte contenant un lien, suivez ces étapes :

1. Créez une instance de la classe `Presentation`. 
2. Obtenez une référence pour la première diapositive dans la présentation nouvellement créée. 
3. Ajoutez un objet `AutoShape` avec `ShapeType` défini comme `Rectangle` à une position spécifiée sur la diapositive et obtenez une référence de l'objet AutoShape nouvellement ajouté.
4. Ajoutez un `TextFrame` à l'objet `AutoShape` qui contient *Aspose TextBox* comme texte par défaut. 
5. Instanciez la classe `IHyperlinkManager`. 
6. Assignez l'objet `IHyperlinkManager` à la propriété [HyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/Shape#getHyperlinkClick--) associée à la portion de votre choix du `TextFrame`. 
7. Enfin, écrivez le fichier PPTX via l'objet `Presentation`. 

Ce code Java—une implémentation des étapes ci-dessus—vous montre comment ajouter une zone de texte avec un lien hypertexte à une diapositive :

```java
// Instantiates a Presentation class that represents a PPTX
Presentation pres = new Presentation();
try {
    // Gets the first slide in the presentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Adds an AutoShape object with type set as Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Casts the shape to AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Accesses the ITextFrame property associated with the AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Adds some text to the frame
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Sets the Hyperlink for the portion text
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // Saves the PPTX Presentation
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```