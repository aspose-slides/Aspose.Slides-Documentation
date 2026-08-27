---
title: Gérer les zones de texte dans les présentations avec Java
linktitle: Gérer la zone de texte
type: docs
weight: 20
url: /fr/java/manage-textbox/
keywords:
- zone de texte
- cadre de texte
- ajouter du texte
- mettre à jour le texte
- créer une zone de texte
- vérifier la zone de texte
- ajouter une colonne de texte
- ajouter un hyperlien
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Aspose.Slides for Java facilite la création, la modification et le clonage des zones de texte dans les fichiers PowerPoint et OpenDocument, améliorant ainsi l’automatisation de vos présentations."
---
## **Introduction**

Les textes sur les diapositives se trouvent généralement dans des zones de texte ou des formes. Par conséquent, pour ajouter du texte à une diapositive, vous devez ajouter une zone de texte puis y insérer du texte. Aspose.Slides for Java fournit l'interface [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IAutoShape) qui vous permet d’ajouter une forme contenant du texte.

{{% alert title="Info" color="info" %}}

Aspose.Slides fournit également l'interface [IShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IShape) qui permet d’ajouter des formes aux diapositives. Cependant, toutes les formes ajoutées via l’interface `IShape` ne peuvent pas contenir du texte. En revanche, les formes ajoutées via l’interface [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IAutoShape) peuvent contenir du texte. 

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Par conséquent, lorsqu’il s’agit d’une forme à laquelle vous voulez ajouter du texte, il est recommandé de vérifier et de confirmer qu’elle a été castée via l’interface `IAutoShape`. Ce n’est qu’alors que vous pourrez travailler avec [TextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/TextFrame), qui est une propriété de `IAutoShape`. Voir la section [Update Text](https://docs.aspose.com/slides/fr/java/manage-textbox/#update-text) de cette page. 

{{% /alert %}}

## **Create a Text Box on a Slide**

Créer une zone de texte sur une diapositive

Pour créer une zone de texte sur une diapositive, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation). 
2. Obtenez une référence à la première diapositive de la présentation nouvellement créée. 
3. Ajoutez un objet [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IAutoShape) avec [ShapeType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IGeometryShape#setShapeType-int-) défini sur `Rectangle` à une position spécifiée sur la diapositive et obtenez la référence de l’objet `IAutoShape` nouvellement ajouté. 
4. Ajoutez une propriété `TextFrame` à l’objet `IAutoShape` qui contiendra du texte. Dans l’exemple ci‑dessous, nous avons ajouté ce texte : *Aspose TextBox*  
5. Enfin, écrivez le fichier PPTX via l’objet `Presentation`. 

Ce code Java — une implémentation des étapes ci‑dessus — montre comment ajouter du texte à une diapositive :

```java
import com.aspose.slides.*;

// Instancie la présentation
Presentation pres = new Presentation();
try {
    // Récupère la première diapositive de la présentation
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajoute une AutoShape dont le type est défini sur Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Ajoute un TextFrame au rectangle
    ashp.addTextFrame(" ");

    // Accède au cadre de texte
    ITextFrame txtFrame = ashp.getTextFrame();

    // Crée l'objet Paragraph pour le cadre de texte
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Crée un objet Portion pour le paragraphe
    IPortion portion = para.getPortions().get_Item(0);

    // Définit le texte
    portion.setText("Aspose TextBox");

    // Enregistre la présentation sur le disque
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Check for a Text Box Shape**

Vérifier la présence d’une forme de zone de texte

Aspose.Slides fournit la méthode [isTextBox](https://reference.aspose.com/slides/fr/java/com.aspose.slides/autoshape/#isTextBox--) de l’interface [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/) qui vous permet d’examiner les formes et d’identifier les zones de texte.

![Text box and shape](istextbox.png)

Ce code Java montre comment vérifier si une forme a été créée en tant que zone de texte : 

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ForEach.shape(presentation, (shape, slide, index) -> {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            System.out.println(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```

Notez que si vous ajoutez simplement une auto‑forme à l’aide de la méthode `addAutoShape` de l’interface [IShapeCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishapecollection/), la méthode `isTextBox` de l’auto‑forme renverra `false`. En revanche, après avoir ajouté du texte à l’auto‑forme à l’aide de la méthode `addTextFrame` ou de la méthode `setText`, la propriété `isTextBox` renvoie `true`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() renvoie false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() renvoie true

IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() renvoie false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() renvoie true

IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() renvoie false
shape3.addTextFrame("");
// shape3.isTextBox() renvoie false

IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() renvoie false
shape4.getTextFrame().setText("");
// shape4.isTextBox() renvoie false
```

## **Find the Shape That Owns a Text Frame**

Trouver la forme qui possède un TextFrame

Dans un code de traitement de texte générique, vous pouvez recevoir un objet [ITextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/) sans connaître à l’avance quel objet de présentation le contient. Utilisez la méthode [ITextFrame.getParentShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/#getParentShape--) pour revenir à l’[IShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/) propriétaire.

Pour un texte‑frame appartenant à une [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/) ou à une autre forme contenant du texte, [ITextFrame.getParentShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/#getParentShape--) renvoie le propriétaire et [ITextFrame.getParentCell](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/#getParentCell--) renvoie `null`. Les deux méthodes offrent une navigation en lecture seule, de sorte que les appeler ne modifie pas la propriété. Vérifiez toujours que la valeur renvoyée n’est pas `null` avant d’accéder à la forme.

Pour un exemple complet identifiant les propriétaires de formes et de cellules de tableau, y compris les formes associées aux nœuds SmartArt, consultez [Rechercher et remplacer du texte](/slides/fr/java/search-and-replace-text/).

## **Add Columns to a Text Box**

Ajouter des colonnes à une zone de texte

Aspose.Slides fournit les propriétés [ColumnCount](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) et [ColumnSpacing](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (issues de l’interface [ITextFrameFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ITextFrameFormat) et de la classe [TextFrameFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/TextFrameFormat)) qui permettent d’ajouter des colonnes aux zones de texte. Vous pouvez spécifier le nombre de colonnes dans une zone de texte et définir l’espacement en points entre les colonnes. 

Ce code Java illustre l’opération décrite : 

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Récupère la première diapositive de la présentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajoute une AutoShape dont le type est défini sur Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Ajoute un TextFrame au rectangle
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // Récupère le format du texte du TextFrame
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // Spécifie le nombre de colonnes dans le TextFrame
    format.setColumnCount(3);

    // Spécifie l'espacement entre les colonnes
    format.setColumnSpacing(10);

    // Enregistre la présentation
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Add Columns to a Text Frame**

Ajouter des colonnes à un TextFrame

Aspose.Slides for Java fournit la propriété [ColumnCount](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (issues de l’interface [ITextFrameFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ITextFrameFormat)) qui permet d’ajouter des colonnes dans les TextFrames. Grâce à cette propriété, vous pouvez spécifier le nombre de colonnes souhaité dans un TextFrame. 

Ce code Java montre comment ajouter une colonne à l’intérieur d’un TextFrame :

```java
import com.aspose.slides.*;

String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    ITextFrameFormat format = shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Update Text**

Mettre à jour le texte

Aspose.Slides vous permet de modifier ou mettre à jour le texte contenu dans une zone de texte ou tous les textes d’une présentation. 

Ce code Java montre une opération où tous les textes d’une présentation sont mis à jour ou modifiés :

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //Vérifie si la forme prend en charge le cadre de texte (IAutoShape).
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //Itère à travers les paragraphes du cadre de texte
                {
                    for (IPortion portion : paragraph.getPortions()) //Itère à travers chaque portion du paragraphe
                    {
                        portion.setText(portion.getText().replace("years", "months")); //Modifie le texte
                        portion.getPortionFormat().setFontBold(NullableBool.True); //Modifie le formatage
                    }
                }
            }
        }
    }

    //Enregistre la présentation modifiée
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Add a Text Box with a Hyperlink** 

Ajouter une zone de texte avec un hyperlien

Vous pouvez insérer un lien à l’intérieur d’une zone de texte. Lorsque la zone de texte est cliquée, les utilisateurs sont dirigés vers le lien. 

Pour ajouter une zone de texte contenant un lien, suivez ces étapes :

1. Créez une instance de la classe `Presentation`. 
2. Obtenez une référence à la première diapositive de la présentation nouvellement créée. 
3. Ajoutez un objet `AutoShape` avec `ShapeType` défini sur `Rectangle` à une position spécifiée sur la diapositive et obtenez une référence de l’objet AutoShape nouvellement ajouté. 
4. Ajoutez un `TextFrame` à l’objet `AutoShape` qui contient *Aspose TextBox* comme texte par défaut. 
5. Instanciez la classe `IHyperlinkManager`. 
6. Assignez l’objet `IHyperlinkManager` à la propriété [HyperlinkClick](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Shape#getHyperlinkClick--) associée à la portion de texte souhaitée du `TextFrame`. 
7. Enfin, écrivez le fichier PPTX via l’objet `Presentation`. 

Ce code Java — une implémentation des étapes ci‑dessus — montre comment ajouter une zone de texte avec un hyperlien à une diapositive :

```java
import com.aspose.slides.*;

// Instancie une classe Presentation qui représente un PPTX
Presentation pres = new Presentation();
try {
    // Récupère la première diapositive de la présentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajoute un objet AutoShape dont le type est défini sur Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Convertit la forme en AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Accède à la propriété ITextFrame associée à l'AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Ajoute du texte au cadre
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Définit l'hyperlien pour le texte de la portion
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // Enregistre la présentation PPTX
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Quelle est la différence entre une zone de texte et un espace réservé de texte lors du travail avec les diapositives maîtres ?**

Un [placeholder](/slides/fr/java/manage-placeholder/) hérite du style/position de la [master](https://reference.aspose.com/slides/fr/java/com.aspose.slides/masterslide/) et peut être écrasé sur les [layouts](https://reference.aspose.com/slides/fr/java/com.aspose.slides/layoutslide/), tandis qu’une zone de texte ordinaire est un objet indépendant sur une diapositive précise et ne change pas lorsque vous changez de mise en page.

**Comment effectuer un remplacement massif de texte dans toute la présentation sans toucher au texte à l’intérieur des graphiques, tableaux et SmartArt ?**

Limitez votre itération aux auto‑formes qui possèdent des TextFrames et excluez les objets incorporés ([charts](https://reference.aspose.com/slides/fr/java/com.aspose.slides/chart/), [tables](https://reference.aspose.com/slides/fr/java/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/fr/java/com.aspose.slides/smartart/)) en parcourant leurs collections séparément ou en ignorant ces types d’objets.