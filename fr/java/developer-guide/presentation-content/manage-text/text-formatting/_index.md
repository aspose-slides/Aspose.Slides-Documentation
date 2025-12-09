---
title: Formater le texte PowerPoint en Java
linktitle: Formatage du texte
type: docs
weight: 50
url: /fr/java/text-formatting/
keywords:
- mettre en surbrillance le texte
- expression régulière
- aligner le paragraphe
- style de texte
- arrière-plan du texte
- transparence du texte
- espacement des caractères
- propriétés de police
- famille de police
- rotation du texte
- angle de rotation
- cadre de texte
- interligne
- propriété autofit
- ancrage du cadre de texte
- tabulation du texte
- langue par défaut
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Formatez et stylisez le texte dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Java. Personnalisez les polices, les couleurs, l'alignement, et plus encore."
---

## **Mettre en surbrillance le texte**
La méthode [highlightText](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) a été ajoutée à l'interface [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) et à la classe [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame).

Elle permet de mettre en surbrillance une partie du texte avec une couleur d'arrière‑plan en utilisant un échantillon de texte, similaire à l'outil Couleur de surbrillance du texte dans PowerPoint 2019.

L'extrait de code ci‑dessous montre comment utiliser cette fonctionnalité :
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions textHighlightingOptions = new TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("title", Color.BLUE); // mise en évidence de tous les mots 'important'
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("to", Color.MAGENTA, textHighlightingOptions);// mise en évidence de toutes les occurrences distinctes de 'the'
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 

Aspose propose un service simple, [service d'édition PowerPoint en ligne gratuit](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Mettre en surbrillance le texte avec expression régulière**
La méthode [highlightRegex](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) a été ajoutée à l'interface [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) et à la classe [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame).

Elle permet de mettre en surbrillance une partie du texte avec une couleur d'arrière‑plan en utilisant une expression régulière, similaire à l'outil Couleur de surbrillance du texte dans PowerPoint 2019.

L'extrait de code ci‑dessous montre comment utiliser cette fonctionnalité :
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions options = new TextHighlightingOptions();
    
    ((AutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.awt.Color.YELLOW, options); // mise en évidence de tous les mots de 10 symboles ou plus
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Définir la couleur d'arrière‑plan du texte**
Aspose.Slides permet de spécifier la couleur souhaitée pour l'arrière‑plan d'un texte.

Ce code Java montre comment définir la couleur d'arrière‑plan pour un texte complet :
```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();

    Paragraph para = new Paragraph();

    Portion portion1 = new Portion("Black");
    portion1.getPortionFormat().setFontBold(NullableBool.True);

    Portion portion2 = new Portion(" Red ");

    Portion portion3 = new Portion("Black");
    portion3.getPortionFormat().setFontBold(NullableBool.True);

    para.getPortions().add(portion1);
    para.getPortions().add(portion2);
    para.getPortions().add(portion3);
    autoShape.getTextFrame().getParagraphs().add(para);

    pres.save("text.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

Presentation presentation = new Presentation("text.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    StreamSupport.stream(autoShape.getTextFrame().getParagraphs().spliterator(), false)
            .map(p -> p.getPortions())
            .forEach(c -> c.forEach(ic -> ic.getPortionFormat().getHighlightColor().setColor(Color.BLUE)));

    presentation.save("text-red.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


Ce code Java montre comment définir la couleur d'arrière‑plan pour une seule portion de texte :
```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();
    
    Paragraph para = new Paragraph();

    Portion portion1 = new Portion("Black");
    portion1.getPortionFormat().setFontBold(NullableBool.True);

    Portion portion2 = new Portion(" Red ");

    Portion portion3 = new Portion("Black");
    portion3.getPortionFormat().setFontBold(NullableBool.True);
    
    para.getPortions().add(portion1);
    para.getPortions().add(portion2);
    para.getPortions().add(portion3);
    autoShape.getTextFrame().getParagraphs().add(para);
    
    pres.save("text.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

Presentation presentation = new Presentation("text.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    Optional<IPortion> redPortion = StreamSupport.stream(autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().spliterator(), false)
            .filter(p -> p.getText().contains("Red"))
            .findFirst();

    if(redPortion.isPresent())
        redPortion.get().getPortionFormat().getHighlightColor().setColor(Color.RED);

    presentation.save("text-red.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Aligner les paragraphes de texte**
Le formatage du texte est l'un des éléments clés lors de la création de documents ou de présentations. Nous savons qu'Aspose.Slides for Java prend en charge l'ajout de texte aux diapositives, mais dans ce sujet, nous verrons comment contrôler l'alignement des paragraphes de texte dans une diapositive. Veuillez suivre les étapes ci‑dessous pour aligner les paragraphes de texte à l'aide d'Aspose.Slides for Java :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive en utilisant son index.
3. Accédez aux formes d’espace réservé présentes dans la diapositive et castpez‑les en [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape).
4. Récupérez le paragraphe (à aligner) depuis le [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape#getTextFrame--) exposé par [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape).
5. Alignez le paragraphe. Un paragraphe peut être aligné à droite, à gauche, centré ou justifié.
6. Enregistrez la présentation modifiée sous forme de fichier PPTX.

L’implémentation des étapes ci‑dessus est présentée ci‑dessous.
```java
// Instancier un objet Presentation qui représente un fichier PPTX
Presentation pres = new Presentation("ParagraphsAlignment.pptx");
try {
    // Accéder à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);

    // Accéder au premier et au deuxième espace réservé dans la diapositive et le convertir en AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // Modifier le texte dans les deux espaces réservés
    tf1.setText("Center Align by Aspose");
    tf2.setText("Center Align by Aspose");

    // Obtenir le premier paragraphe des espaces réservés
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // Aligner le paragraphe de texte au centre
    para1.getParagraphFormat().setAlignment(TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(TextAlignment.Center);

    //Enregistrer la présentation au format PPTX
    pres.save("Centeralign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Définir la transparence du texte**
Cet article montre comment définir la propriété de transparence sur n’importe quelle forme de texte à l’aide d’Aspose.Slides for Java. Pour définir la transparence du texte, veuillez suivre les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive.
3. Définissez la couleur de l’ombre.
4. Enregistrez la présentation sous forme de fichier PPTX.

L’implémentation des étapes ci‑dessus est présentée ci‑dessous.
```java
Presentation pres = new Presentation("transparency.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IEffectFormat effects = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getEffectFormat();

    IOuterShadow outerShadowEffect = effects.getOuterShadowEffect();

    Color shadowColor = outerShadowEffect.getShadowColor().getColor();
    System.out.println(shadowColor.toString() + " - transparency is: "+ (shadowColor.getAlpha() / 255f) * 100);

    // définir la transparence à zéro pour cent
    outerShadowEffect.getShadowColor().setColor(new Color(shadowColor.getRed(), shadowColor.getGreen(), shadowColor.getBlue(), 255));

    pres.save("transparency-2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Définir l'espacement des caractères pour le texte**
Aspose.Slides permet de définir l’espace entre les lettres dans une zone de texte. Ainsi, vous pouvez ajuster la densité visuelle d’une ligne ou d’un bloc de texte en augmentant ou en réduisant l’espacement entre les caractères.

Ce code Java montre comment augmenter l’espacement pour une ligne de texte et le réduire pour une autre ligne :
```java
Presentation presentation = new Presentation("in.pptx");

IAutoShape textBox1 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
IAutoShape textBox2 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(1);

textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20); // étendre
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2); // condenser

presentation.save("out.pptx", SaveFormat.Pptx);
```


## **Gérer les propriétés de police d’un paragraphe**
Les présentations contiennent généralement à la fois du texte et des images. Le texte peut être mis en forme de différentes manières, que ce soit pour mettre en évidence des sections spécifiques ou pour se conformer aux styles d’entreprise. Le formatage du texte aide les utilisateurs à varier l’aspect du contenu de la présentation. Cet article montre comment utiliser Aspose.Slides for Java pour configurer les propriétés de police des paragraphes de texte sur les diapositives. Pour gérer les propriétés de police d’un paragraphe avec Aspose.Slides for Java :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Obtenez la référence d’une diapositive en utilisant son index.
1. Accédez aux formes d’espace réservé dans la diapositive et castpez‑les en [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
1. Récupérez le [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) depuis le [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) exposé par [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
1. Justifiez le paragraphe.
1. Accédez à la portion de texte du paragraphe.
1. Définissez la police à l’aide de FontData et affectez‑la à la portion de texte correspondante.
   1. Appliquez le gras.
   1. Appliquez l’italique.
1. Définissez la couleur de la police en utilisant la méthode [getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#getFillFormat--) exposée par l’objet [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion).
1. Enregistrez la présentation modifiée dans un fichier [PPTX](https://docs.fileformat.com/presentation/pptx/).

L’implémentation des étapes ci‑dessus est présentée ci‑dessous. Elle prend une présentation brute et formate les polices sur l’une des diapositives.
```java
// Instancier un objet Presentation qui représente un fichier PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
    // Accéder à une diapositive en utilisant sa position
    ISlide slide = pres.getSlides().get_Item(0);

    // Accéder aux premier et deuxième espaces réservés dans la diapositive et les convertir en AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // Accéder au premier paragraphe
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // Accéder à la première portion
    IPortion port1 = para1.getPortions().get_Item(0);
    IPortion port2 = para2.getPortions().get_Item(0);

    // Définir de nouvelles polices
    FontData fd1 = new FontData("Elephant");
    FontData fd2 = new FontData("Castellar");

    // Assigner de nouvelles polices à la portion
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);

    // Mettre la police en gras
    port1.getPortionFormat().setFontBold(NullableBool.True);
    port2.getPortionFormat().setFontBold(NullableBool.True);

    // Mettre la police en italique
    port1.getPortionFormat().setFontItalic(NullableBool.True);
    port2.getPortionFormat().setFontItalic(NullableBool.True);

    // Définir la couleur de la police
    port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    //Écrire le PPTX sur le disque
    pres.save("WelcomeFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Gérer la famille de polices du texte**
Une portion sert à regrouper du texte avec un style de mise en forme similaire dans un paragraphe. Cet article montre comment utiliser Aspose.Slides for Java pour créer une zone de texte contenant du texte, puis définir une police particulière ainsi que diverses autres propriétés de la catégorie famille de polices. Pour créer une zone de texte et définir les propriétés de police du texte qu’elle contient :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive en utilisant son index.
3. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) de type [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) à la diapositive.
4. Supprimez le style de remplissage associé à la [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. Accédez au TextFrame de l’AutoShape.
6. Ajoutez du texte au TextFrame.
7. Accédez à l’objet Portion associé au [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
8. Définissez la police à utiliser pour la [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion).
9. Définissez d’autres propriétés de police telles que gras, italique, souligné, couleur et taille en utilisant les propriétés appropriées de l’objet Portion.
10. Enregistrez la présentation modifiée sous forme de fichier PPTX.

L’implémentation des étapes ci‑dessus est présentée ci‑dessous.
```java
// Instancier un objet Presentation
Presentation pres = new Presentation();
try {

    // Obtenir la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajouter une AutoShape de type Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);

    // Supprimer tout style de remplissage associé à l'AutoShape
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Accéder au TextFrame associé à l'AutoShape
    ITextFrame tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");

    // Accéder à la Portion associée au TextFrame
    IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);

    // Définir la police pour la Portion
    port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));

    // Définir la propriété gras de la police
    port.getPortionFormat().setFontBold(NullableBool.True);

    // Définir la propriété italique de la police
    port.getPortionFormat().setFontItalic(NullableBool.True);

    // Définir la propriété soulignement de la police
    port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);

    // Définir la taille de la police
    port.getPortionFormat().setFontHeight(25);

    // Définir la couleur de la police
    port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Écrire le PPTX sur le disque 
    pres.save("SetTextFontProperties_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Définir la taille de police du texte**
Aspose.Slides permet de choisir la taille de police souhaitée pour le texte existant dans un paragraphe ainsi que pour les textes qui pourront être ajoutés ultérieurement au paragraphe.

Ce code Java montre comment définir la taille de police pour les textes contenus dans un paragraphe :
```java
Presentation presentation = new Presentation("example.pptx");
try {
    // Obtient la première forme, par exemple.
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape )
    {
        IAutoShape autoShape = (AutoShape) shape;
        // Obtient le premier paragraphe, par exemple.
        IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

        // Définit la taille de police par défaut à 20 pt pour toutes les portions de texte du paragraphe. 
        paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);

        // Définit la taille de police à 20 pt pour les portions de texte actuelles du paragraphe. 
        for(IPortion portion : paragraph.getPortions())
        {
            portion.getPortionFormat().setFontHeight(20);
        }
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Définir la rotation du texte**
Aspose.Slides for Java permet aux développeurs de faire pivoter le texte. Le texte peut être affiché comme [Horizontal](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Horizontal), [Vertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Vertical), [Vertical270](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Vertical270), [WordArtVertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#WordArtVertical), [EastAsianVertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#EastAsianVertical), [MongolianVertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#MongolianVertical) ou [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). Pour faire pivoter le texte d’un TextFrame, suivez les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Accédez à la première diapositive.
3. Ajoutez une forme quelconque à la diapositive.
4. Accédez au [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. [Faire pivoter le texte](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-).
6. Enregistrez le fichier sur le disque.
```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Obtenir la première diapositive 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajouter une AutoShape de type Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // Ajouter un TextFrame au Rectangle
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // Accéder au TextFrame
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);
    
    // Créer l'objet Paragraph pour le TextFrame
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // Créer l'objet Portion pour le paragraphe
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Enregistrer la présentation
    pres.save("RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Définir un angle de rotation personnalisé pour TextFrame**
Aspose.Slides for Java prend désormais en charge la définition d’un angle de rotation personnalisé pour TextFrame. Dans ce sujet, nous verrons, à l’aide d’un exemple, comment définir la propriété RotationAngle dans Aspose.Slides. Les nouvelles méthodes [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) et [getRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#getRotationAngle--) ont été ajoutées aux interfaces [IChartTextBlockFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IChartTextBlockFormat) et [ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat), permettant de définir un angle de rotation personnalisé pour TextFrame. Pour définir RotationAngle, veuillez suivre les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Ajoutez un graphique à la diapositive.
3. [Définir la propriété RotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-).
4. Enregistrez la présentation sous forme de fichier PPTX.

Dans l’exemple ci‑dessous, nous définissons la propriété RotationAngle.
```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Obtenir la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajouter une AutoShape de type Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

    // Ajouter un TextFrame au Rectangle
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Accéder au TextFrame
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);

    // Créer l'objet Paragraph pour le TextFrame
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Créer l'objet Portion pour le paragraphe
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Text rotation example.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Enregistrer la présentation
    pres.save(resourcesOutputPath+"RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Interligne du paragraphe**
Aspose.Slides propose des propriétés sous [`ParagraphFormat`](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraphFormat) — `SpaceAfter`, `SpaceBefore` et `SpaceWithin` — qui permettent de gérer l’interligne d’un paragraphe. Les trois propriétés s’utilisent ainsi :

* Pour spécifier l’interligne d’un paragraphe en pourcentage, utilisez une valeur positive.  
* Pour spécifier l’interligne d’un paragraphe en points, utilisez une valeur négative.

Par exemple, vous pouvez appliquer un interligne de 16 pt à un paragraphe en définissant la propriété `SpaceBefore` à ‑16.

Voici comment spécifier l’interligne pour un paragraphe donné :

1. Chargez une présentation contenant une AutoShape avec du texte.
2. Récupérez la référence d’une diapositive via son index.
3. Accédez au TextFrame.
4. Accédez au Paragraph.
5. Définissez les propriétés du paragraphe.
6. Enregistrez la présentation.

Ce code Java montre comment spécifier l’interligne d’un paragraphe :
```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Obtenir la référence d'une diapositive par son indice
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Accéder au TextFrame
    ITextFrame tf1 = ((IAutoShape)sld.getShapes().get_Item(0)).getTextFrame();
    
    // Accéder au paragraphe
    IParagraph para = tf1.getParagraphs().get_Item(0);
    
    // Définir les propriétés du paragraphe
    para.getParagraphFormat().setSpaceWithin(80);
    para.getParagraphFormat().setSpaceBefore(40);
    para.getParagraphFormat().setSpaceAfter(40);
    
    // Enregistrer la présentation
    pres.save("LineSpacing_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Définir la propriété AutofitType pour TextFrame**
Dans ce sujet, nous explorerons les différentes propriétés de formatage du cadre de texte. Cet article explique comment définir la propriété AutofitType du cadre de texte, l’ancrage du texte et la rotation du texte dans une présentation. Aspose.Slides for Java permet aux développeurs de définir la propriété AutofitType de n’importe quel cadre de texte. AutofitType peut être défini sur [Normal](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Normal) ou [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Shape). Si la valeur est [Normal](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Normal), la forme reste inchangée tandis que le texte est ajusté sans modifier la forme ; si AutofitType est [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Shape), la forme est modifiée pour ne contenir que le texte nécessaire. Pour définir la propriété AutofitType d’un cadre de texte, veuillez suivre les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Accédez à la première diapositive.
3. Ajoutez une forme quelconque à la diapositive.
4. Accédez au [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. [Définir la propriété AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) du TextFrame.
6. Enregistrez le fichier sur le disque.
```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Accéder à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajouter une AutoShape de type Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 150);

    // Ajouter un TextFrame au rectangle
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Accéder au TextFrame
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    // Créer l'objet Paragraph pour le TextFrame
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Créer l'objet Portion pour le paragraphe
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Enregistrer la présentation
    pres.save(resourcesOutputPath + "formatText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Définir l’ancrage du TextFrame**
Aspose.Slides for Java permet aux développeurs de définir l’ancrage de n’importe quel TextFrame. TextAnchorType indique où le texte est placé dans la forme. Le type d’ancrage peut être défini sur [Top](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Top), [Center](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Center), [Bottom](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Bottom), [Justified](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Justified) ou [Distributed](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Distributed). Pour définir l’ancrage d’un TextFrame, veuillez suivre les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Accédez à la première diapositive.
3. Ajoutez une forme quelconque à la diapositive.
4. Accédez au [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. [Définir TextAnchorType](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) du TextFrame.
6. Enregistrez le fichier sur le disque.
```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Obtenir la première diapositive 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajouter une AutoShape de type Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // Ajouter un TextFrame au Rectangle
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // Accéder au TextFrame
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);
    
    // Créer l'objet Paragraph pour le TextFrame
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // Créer l'objet Portion pour le paragraphe
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Enregistrer la présentation
    pres.save("AnchorText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Tabulations et EffectiveTabs dans la présentation**
Toutes les tabulations de texte sont exprimées en pixels.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Figure : 2 tabulations explicites et 2 tabulations par défaut**|
- La propriété EffectiveTabs.ExplicitTabCount (2 dans notre cas) est égale à Tabs.Count.  
- La collection EffectiveTabs comprend toutes les tabulations (celles de la collection Tabs et les tabulations par défaut).  
- La propriété EffectiveTabs.ExplicitTabCount (2 dans notre cas) est égale à Tabs.Count.  
- La propriété EffectiveTabs.DefaultTabSize (294) indique la distance entre les tabulations par défaut (3 et 4 dans notre exemple).  
- EffectiveTabs.GetTabByIndex(index) avec index = 0 renvoie la première tabulation explicite (Position = 731), index = 1 la seconde (Position = 1241). Si vous demandez l’index = 2, la première tabulation par défaut (Position = 1470) est renvoyée, etc.  
- EffectiveTabs.GetTabAfterPosition(pos) permet d’obtenir la tabulation suivante après un texte donné. Par exemple, pour le texte « Hello World! », il faut d’abord calculer la longueur de « Hello » en pixels, puis appeler GetTabAfterPosition avec cette valeur afin d’obtenir la position de la prochaine tabulation pour dessiner « world! ».

## **Définir le style de texte par défaut**
Si vous devez appliquer le même formatage de texte par défaut à tous les éléments textuels d’une présentation en une fois, vous pouvez utiliser la méthode `getDefaultTextStyle` de l’interface [IPresentation](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/) et définir le formatage souhaité. L’exemple de code ci‑dessus montre comment définir la police par défaut en gras (14 pt) pour le texte de toutes les diapositives d’une nouvelle présentation.
```java
Presentation presentation = new Presentation();
try {
    // Obtenir le format du paragraphe de niveau supérieur.
    IParagraphFormat paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(NullableBool.True);
    }

    presentation.save("DefaultTextStyle.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Extraire le texte avec l’effet Tout en Majuscules**
Dans PowerPoint, l’application de l’effet de police **All Caps** fait apparaître le texte en majuscules sur la diapositive même s’il a été tapé en minuscules. Lorsque vous récupérez une telle portion de texte avec Aspose.Slides, la bibliothèque renvoie le texte exactement tel qu’il a été saisi. Pour gérer cela, vérifiez [TextCapType](https://reference.aspose.com/slides/java/com.aspose.slides/textcaptype/) — s’il indique `All`, convertissez simplement la chaîne renvoyée en majuscules afin que votre sortie corresponde à ce que les utilisateurs voient sur la diapositive.

Supposons que nous ayons la zone de texte suivante sur la première diapositive du fichier sample2.pptx.

![The All Caps effect](all_caps_effect.png)

L’exemple de code ci‑dessus montre comment extraire le texte avec l’effet **All Caps** appliqué :
```java
Presentation presentation = new Presentation("sample2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    IPortion textPortion = paragraph.getPortions().get_Item(0);

    System.out.println("Original text: " + textPortion.getText());

    IPortionFormatEffectiveData textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == TextCapType.All) {
        String text = textPortion.getText().toUpperCase();
        System.out.println("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```


Sortie :
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **FAQ**

**Comment modifier le texte dans un tableau sur une diapositive ?**

Pour modifier le texte dans un tableau sur une diapositive, vous devez utiliser l’interface [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/). Vous pouvez parcourir toutes les cellules du tableau et changer le texte de chaque cellule en accédant à ses propriétés `TextFrame` et `ParagraphFormat`.

**Comment appliquer une couleur dégradée au texte dans une diapositive PowerPoint ?**

Pour appliquer une couleur dégradée au texte, utilisez la méthode `getFillFormat` de [BasePortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/). Définissez le `FilFormat` sur `Gradient`, où vous pouvez spécifier les couleurs de départ et d’arrivée du dégradé, ainsi que d’autres propriétés comme la direction et la transparence afin de créer l’effet dégradé sur le texte.