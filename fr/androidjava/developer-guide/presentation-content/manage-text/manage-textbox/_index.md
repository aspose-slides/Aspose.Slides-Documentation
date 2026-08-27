---
title: Gérer les zones de texte dans les présentations sur Android
linktitle: Gérer la zone de texte
type: docs
weight: 20
url: /fr/androidjava/manage-textbox/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java facilite la création, la modification et le clonage des zones de texte dans les fichiers PowerPoint et OpenDocument, améliorant ainsi l'automatisation de vos présentations."
---
## **Introduction**

Les textes sur les diapositives se trouvent généralement dans des zones de texte ou des formes. Ainsi, pour ajouter du texte à une diapositive, vous devez ajouter une zone de texte puis y placer du texte. Aspose.Slides for Android via Java fournit l’interface [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IAutoShape) qui permet d’ajouter une forme contenant du texte.

{{% alert title="Info" color="info" %}}
Aspose.Slides fournit également l’interface [IShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IShape) qui permet d’ajouter des formes aux diapositives. Cependant, toutes les formes ajoutées via l’interface `IShape` ne peuvent pas contenir du texte. En revanche, les formes ajoutées via l’interface [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IAutoShape) peuvent contenir du texte.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Par conséquent, lorsque vous travaillez avec une forme à laquelle vous souhaitez ajouter du texte, vous devez vérifier et confirmer qu’elle a été convertie via l’interface `IAutoShape`. Ce n’est qu’alors que vous pourrez travailler avec [TextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/TextFrame), qui est une propriété de `IAutoShape`. Consultez la section [Mettre à jour le texte](https://docs.aspose.com/slides/fr/androidjava/manage-textbox/#update-text) de cette page.
{{% /alert %}}

## **Créer une zone de texte sur une diapositive**

Pour créer une zone de texte sur une diapositive, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation).
2. Obtenez une référence de la première diapositive de la présentation nouvellement créée. 
3. Ajoutez un objet [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IAutoShape) avec [ShapeType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IGeometryShape#setShapeType-int-) défini sur `Rectangle` à une position spécifiée sur la diapositive et obtenez la référence de l’objet `IAutoShape` ajouté.
4. Ajoutez une propriété `TextFrame` à l’objet `IAutoShape` qui contiendra du texte. Dans l’exemple ci‑dessous, nous avons ajouté ce texte : *Aspose TextBox*
5. Enfin, écrivez le fichier PPTX à l’aide de l’objet `Presentation`. 

Ce code Java — une implémentation des étapes ci‑dessus — montre comment ajouter du texte à une diapositive :

```java
import com.aspose.slides.*;

// Instancie la présentation
Presentation pres = new Presentation();
try {
    // Obtient la première diapositive de la présentation
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajoute une AutoShape avec le type défini comme Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Ajoute un TextFrame au rectangle
    ashp.addTextFrame(" ");

    // Accède au cadre de texte
    ITextFrame txtFrame = ashp.getTextFrame();

    // Crée l’objet Paragraph pour le cadre de texte
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

## **Vérifier la présence d’une forme de zone de texte**

Aspose.Slides fournit la méthode [isTextBox](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/#isTextBox--) de l’interface [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/), vous permettant d’examiner les formes et d’identifier les zones de texte.

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

Notez que si vous ajoutez simplement une forme automatique avec la méthode `addAutoShape` de l’interface [IShapeCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishapecollection/), la méthode `isTextBox` de la forme renverra `false`. En revanche, après avoir ajouté du texte à la forme en utilisant la méthode `addTextFrame` ou la méthode `setText`, la propriété `isTextBox` renvoie `true`.

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

## **Trouver la forme propriétaire d’un cadre de texte**

Dans un code de traitement de texte générique, vous pouvez recevoir un [ITextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/) sans connaître à l’avance l’objet de présentation qui le contient. Utilisez la méthode [ITextFrame.getParentShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/#getParentShape--) pour revenir à la [IShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/) propriétaire.

Pour un cadre de texte appartenant à une [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) ou à une autre forme contenant du texte, [ITextFrame.getParentShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/#getParentShape--) renvoie le propriétaire et [ITextFrame.getParentCell](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/#getParentCell--) renvoie `null`. Les deux méthodes offrent une navigation en lecture seule, ainsi les appeler ne modifie pas la propriété. Vérifiez toujours que la valeur renvoyée n’est pas `null` avant d’accéder à la forme.

Pour un exemple complet qui identifie les propriétaires de formes et de cellules de tableau, y compris les formes associées aux nœuds SmartArt, consultez [Search and Replace Text](/slides/fr/androidjava/search-and-replace-text/).

## **Ajouter des colonnes à une zone de texte**

Aspose.Slides fournit les propriétés [ColumnCount](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) et [ColumnSpacing](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (issues de l’interface [ITextFrameFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ITextFrameFormat) et de la classe [TextFrameFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/TextFrameFormat)) qui permettent d’ajouter des colonnes aux zones de texte. Vous pouvez spécifier le nombre de colonnes dans une zone de texte et définir l’espacement en points entre les colonnes.

Ce code Java illustre l’opération décrite :

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Obtient la première diapositive de la présentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajoute une AutoShape avec le type défini comme Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Ajoute un TextFrame au rectangle
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // Obtient le format de texte du TextFrame
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

## **Ajouter des colonnes à un cadre de texte**
Aspose.Slides for Android via Java fournit la propriété [ColumnCount](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (issue de l’interface [ITextFrameFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ITextFrameFormat)) qui permet d’ajouter des colonnes dans les cadres de texte. Grâce à cette propriété, vous pouvez spécifier le nombre de colonnes souhaité dans un cadre de texte.

Ce code Java montre comment ajouter une colonne dans un cadre de texte :

```java
import com.aspose.slides.*;

String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0));
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
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
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Mettre à jour le texte**

Aspose.Slides vous permet de modifier ou de mettre à jour le texte contenu dans une zone de texte ou dans l’ensemble des textes d’une présentation. 

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

## **Ajouter une zone de texte avec un hyperlien** 

Vous pouvez insérer un lien dans une zone de texte. Lorsque la zone de texte est cliquée, les utilisateurs sont dirigés vers le lien. 

Pour ajouter une zone de texte contenant un lien, suivez ces étapes :

1. Créez une instance de la classe `Presentation`. 
2. Obtenez une référence de la première diapositive de la présentation nouvellement créée. 
3. Ajoutez un objet `AutoShape` avec `ShapeType` défini sur `Rectangle` à une position spécifiée sur la diapositive et obtenez la référence de l’objet AutoShape ajouté.
4. Ajoutez un `TextFrame` à l’objet `AutoShape` et définissez le texte de sa première portion. Dans l’exemple ci‑dessous, nous avons utilisé ce texte : *Aspose.Slides*
5. Obtenez l’objet [IHyperlinkManager](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlinkmanager/) à partir du `PortionFormat` de la portion souhaitée du `TextFrame`.
6. Appelez [setExternalHyperlinkClick](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) sur cet objet pour définir le lien qui s’ouvre lorsqu’on clique sur le texte.
7. Enfin, écrivez le fichier PPTX à l’aide de l’objet `Presentation`. 

Ce code Java — une implémentation des étapes ci‑dessus — montre comment ajouter une zone de texte avec un hyperlien à une diapositive :

```java
import com.aspose.slides.*;

// Instancie une classe Presentation qui représente un PPTX
Presentation pres = new Presentation();
try {
    // Obtient la première diapositive de la présentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajoute un objet AutoShape avec le type défini comme Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Convertit la forme en AutoShape
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

    // Enregistre la présentation PPTX
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Quelle est la différence entre une zone de texte et un espace réservé de texte lorsqu’on travaille avec les diapositives maîtres ?**

Un [placeholder](/slides/fr/androidjava/manage-placeholder/) hérite du style/position de la [master](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/masterslide/) et peut être remplacé sur les [layouts](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/layoutslide/), tandis qu’une zone de texte ordinaire est un objet indépendant sur une diapositive spécifique et ne change pas lorsque vous changez de mise en page.

**Comment effectuer un remplacement massif de texte dans toute la présentation sans toucher au texte à l’intérieur des graphiques, des tableaux et de SmartArt ?**

Limitez votre itération aux formes automatiques qui possèdent des cadres de texte et excluez les objets intégrés ([charts](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/chart/), [tables](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/smartart/)) en parcourant leurs collections séparément ou en ignorant ces types d’objets.