---
title: Formatage du texte
type: docs
weight: 50
url: /fr/java/text-formatting/
keywords:
- texte surligné
- expression régulière
- alignement des paragraphes de texte
- transparence du texte
- propriétés de police du paragraphe
- famille de polices
- rotation du texte
- rotation d'angle personnalisée
- cadre de texte
- espacement des lignes
- propriété d'ajustement automatique
- ancre de cadre de texte
- tabulation de texte
- style de texte par défaut
- Java
- Aspose.Slides pour Java
description: "Gérer et manipuler les propriétés du texte et du cadre de texte en Java"
---

## **Surligner du texte**
La méthode [highlightText](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) a été ajoutée à l'interface [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) et à la classe [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame).

Elle permet de surligner une partie du texte avec une couleur de fond en utilisant un échantillon de texte, similaire à l'outil de couleur de surlignage de texte dans PowerPoint 2019.

Le code ci-dessous montre comment utiliser cette fonctionnalité :

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions textHighlightingOptions = new TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("title", Color.BLUE); // surligner tous les mots 'important'
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("to", Color.MAGENTA, textHighlightingOptions);// surligner toutes les occurrences séparées de 'the'
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

Aspose propose un service simple de [édition de PowerPoint en ligne gratuit](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Surligner du texte à l'aide d'expressions régulières**

La méthode [highlightRegex](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) a été ajoutée à l'interface [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) et à la classe [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame).

Elle permet de surligner une partie du texte avec une couleur de fond à l'aide d'une expression régulière, similaire à l'outil de couleur de surlignage de texte dans PowerPoint 2019.

Le code ci-dessous montre comment utiliser cette fonctionnalité :

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions options = new TextHighlightingOptions();
    
    ((AutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.awt.Color.YELLOW, options); // surligner tous les mots ayant 10 symboles ou plus
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir la couleur d'arrière-plan du texte**

Aspose.Slides vous permet de spécifier votre couleur préférée pour l'arrière-plan d'un texte.

Ce code Java vous montre comment définir la couleur d'arrière-plan pour un texte entier :

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();

    Paragraph para = new Paragraph();

    Portion portion1 = new Portion("Noir");
    portion1.getPortionFormat().setFontBold(NullableBool.True);

    Portion portion2 = new Portion(" Rouge ");

    Portion portion3 = new Portion("Noir");
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

Ce code Java vous montre comment définir la couleur d'arrière-plan pour seulement une portion d'un texte :

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();
    
    Paragraph para = new Paragraph();

    Portion portion1 = new Portion("Noir");
    portion1.getPortionFormat().setFontBold(NullableBool.True);

    Portion portion2 = new Portion(" Rouge ");

    Portion portion3 = new Portion("Noir");
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
            .filter(p -> p.getText().contains("Rouge"))
            .findFirst();

    if(redPortion.isPresent())
        redPortion.get().getPortionFormat().getHighlightColor().setColor(Color.RED);

    presentation.save("text-red.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Aligner les paragraphes de texte**

Le formatage du texte est l'un des éléments clés lors de la création de tout type de documents ou de présentations. Nous savons qu'Aspose.Slides pour Java permet d'ajouter du texte aux diapositives, mais dans ce sujet, nous allons voir comment contrôler l'alignement des paragraphes de texte dans une diapositive. Veuillez suivre les étapes ci-dessous pour aligner les paragraphes de texte en utilisant Aspose.Slides pour Java :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive en utilisant son index.
3. Accédez aux formes de remplacement présentes dans la diapositive et castées-les en tant que [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape).
4. Obtenez le paragraphe (qui doit être aligné) à partir du [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape#getTextFrame--) exposé par [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape).
5. Alignez le paragraphe. Un paragraphe peut être aligné à droite, à gauche, au centre et justifié.
6. Enregistrez la présentation modifiée en tant que fichier PPTX.

L'implémentation des étapes ci-dessus est donnée ci-dessous.

```java
// Instanciez un objet Presentation représentant un fichier PPTX
Presentation pres = new Presentation("ParagraphsAlignment.pptx");
try {
    // Accéder à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);

    // Accéder au premier et au second espace réservé dans la diapositive et castés-les en tant qu'AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // Changer le texte dans les deux espaces réservés
    tf1.setText("Aligné au centre par Aspose");
    tf2.setText("Aligné au centre par Aspose");

    // Obtenir le premier paragraphe des espaces réservés
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // Aligner le paragraphe de texte au centre
    para1.getParagraphFormat().setAlignment(TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(TextAlignment.Center);

    // Écrire la présentation en tant que fichier PPTX
    pres.save("Centeralign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir la transparence du texte**
Cet article montre comment définir la propriété de transparence pour n'importe quelle forme de texte en utilisant Aspose.Slides pour Java. Pour définir la transparence sur du texte, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive.
3. Définissez la couleur de l'ombre.
4. Enregistrez la présentation en tant que fichier PPTX.

L'implémentation des étapes ci-dessus est donnée ci-dessous.

```java
Presentation pres = new Presentation("transparency.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IEffectFormat effects = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getEffectFormat();

    IOuterShadow outerShadowEffect = effects.getOuterShadowEffect();

    Color shadowColor = outerShadowEffect.getShadowColor().getColor();
    System.out.println(shadowColor.toString() + " - transparence est : "+ (shadowColor.getAlpha() / 255f) * 100);

    // définir la transparence à zéro pour cent
    outerShadowEffect.getShadowColor().setColor(new Color(shadowColor.getRed(), shadowColor.getGreen(), shadowColor.getBlue(), 255));

    pres.save("transparency-2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir l'espacement des caractères pour le texte**

Aspose.Slides vous permet de définir l'espace entre les lettres dans une zone de texte. De cette manière, vous pouvez ajuster la densité visuelle d'une ligne ou d'un bloc de texte en élargissant ou en condensant l'espacement entre les caractères.

Ce code Java vous montre comment étendre l'espacement pour une ligne de texte et condenser l'espacement pour une autre ligne :

```java
Presentation presentation = new Presentation("in.pptx");

IAutoShape textBox1 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
IAutoShape textBox2 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(1);

textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20); // élargir
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2); // condenser

presentation.save("out.pptx", SaveFormat.Pptx);
```

## **Gérer les propriétés de police des paragraphes**

Les présentations contiennent généralement à la fois du texte et des images. Le texte peut être formaté de diverses manières, soit pour mettre en avant des sections et des mots spécifiques, soit pour se conformer aux styles d'entreprise. Le formatage du texte aide les utilisateurs à varier l'apparence du contenu de la présentation. Cet article montre comment utiliser Aspose.Slides pour Java pour configurer les propriétés de police des paragraphes de texte sur les diapositives. Pour gérer les propriétés de police d'un paragraphe à l'aide d'Aspose.Slides pour Java :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Obtenez la référence d'une diapositive en utilisant son index.
1. Accédez aux formes de remplacement dans la diapositive et castés-les en [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
1. Obtenez le [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) à partir de [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) exposé par [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
1. Justifiez le paragraphe.
1. Accédez à la portion de texte du paragraphe.
1. Définissez la police à l'aide de FontData et définissez la police de la portion de texte en conséquence.
   1. Définissez la police en gras.
   2. Définissez la police en italique.
1. Définissez la couleur de la police à l'aide de [getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#getFillFormat--) exposé par l'objet [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion).
1. Écrivez la présentation modifiée dans un fichier [PPTX](https://docs.fileformat.com/presentation/pptx/).

L'implémentation des étapes ci-dessus est donnée ci-dessous. Elle prend une présentation simple et formate les polices sur l'une des diapositives.

```java
// Instanciez un objet Presentation représentant un fichier PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
    // Accéder à une diapositive en utilisant sa position
    ISlide slide = pres.getSlides().get_Item(0);

    // Accéder au premier et au second espace réservé dans la diapositive et castés-les en tant qu'AutoShape
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

    // Assigner les nouvelles polices à la portion
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);

    // Définir la police en gras
    port1.getPortionFormat().setFontBold(NullableBool.True);
    port2.getPortionFormat().setFontBold(NullableBool.True);

    // Définir la police en italique
    port1.getPortionFormat().setFontItalic(NullableBool.True);
    port2.getPortionFormat().setFontItalic(NullableBool.True);

    // Définir la couleur de la police
    port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // Écrire le PPTX sur le disque
    pres.save("WelcomeFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gérer la famille de polices du texte**
Une portion est utilisée pour contenir du texte avec un style de formatage similaire dans un paragraphe. Cet article montre comment utiliser Aspose.Slides pour Java pour créer une zone de texte avec du texte, puis définir une police particulière et diverses autres propriétés de la catégorie de famille de polices. Pour créer une zone de texte et définir les propriétés de police du texte qu'elle contient :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive en utilisant son index.
3. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) de type [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) à la diapositive.
4. Supprimez le style de remplissage associé à [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. Accédez au TextFrame de l'AutoShape.
6. Ajoutez du texte au TextFrame.
7. Accédez à l'objet Portion associé à [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
8. Définissez la police à utiliser pour la [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion).
9. Définissez d'autres propriétés de police comme le gras, l'italique, le soulignement, la couleur et la hauteur à l'aide des propriétés pertinentes exposées par l'objet Portion.
10. Écrivez la présentation modifiée en tant que fichier PPTX.

L'implémentation des étapes ci-dessus est donnée ci-dessous.

```java
// Instanciez Presentation
Presentation pres = new Presentation();
try {

    // Obtenez la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajoutez un AutoShape de type Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);

    // Supprimez tout style de remplissage associé à l'AutoShape
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Accédez au TextFrame associé à l'AutoShape
    ITextFrame tf = ashp.getTextFrame();
    tf.setText("Zone de texte Aspose");

    // Accédez à la Portion associée au TextFrame
    IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);

    // Définir la police pour la Portion
    port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));

    // Définir la propriété gras de la police
    port.getPortionFormat().setFontBold(NullableBool.True);

    // Définir la propriété italique de la police
    port.getPortionFormat().setFontItalic(NullableBool.True);

    // Définir la propriété soulignement de la police
    port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);

    // Définir la hauteur de la police
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

## **Définir la taille de police pour le texte**

Aspose.Slides vous permet de choisir la taille de police préférée pour le texte existant dans un paragraphe et d'autres textes qui peuvent être ajoutés au paragraphe ultérieurement.

Ce code Java vous montre comment définir la taille de police pour les textes contenus dans un paragraphe :

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

        // Définit la taille de police par défaut à 20 pt pour toutes les portions de texte dans le paragraphe. 
        paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);

        // Définit la taille de police à 20 pt pour les portions de texte actuelles dans le paragraphe. 
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

Aspose.Slides pour Java permet aux développeurs de faire pivoter le texte. Le texte peut être défini pour apparaître comme [Horizontal](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Horizontal), [Vertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Vertical), [Vertical270](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Vertical270), [WordArtVertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#WordArtVertical), [EastAsianVertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#EastAsianVertical), [MongolianVertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#MongolianVertical) ou [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). Pour faire pivoter le texte de n'importe quel TextFrame, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Accédez à la première diapositive.
3. Ajoutez une forme à la diapositive.
4. Accédez à [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. [Faites pivoter le texte](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-).
6. Enregistrez le fichier sur le disque.

```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Obtenez la première diapositive 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajoutez un AutoShape de type Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // Ajoutez un TextFrame au Rectangle
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // Accéder au cadre de texte
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);
    
    // Créer l'objet Paragraph pour le cadre de texte
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // Créer l'objet Portion pour le paragraphe
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Un renard brun rapide saute par-dessus le chien paresseux. Un renard brun rapide saute par-dessus le chien paresseux.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Enregistrer la présentation
    pres.save("RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir un angle de rotation personnalisé pour le TextFrame**
Aspose.Slides pour Java prend désormais en charge la définition de l'angle de rotation personnalisé pour le cadre de texte. Dans ce sujet, nous allons voir avec un exemple comment définir la propriété RotationAngle dans Aspose.Slides. Les nouvelles méthodes [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) et [getRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#getRotationAngle--) ont été ajoutées aux interfaces [IChartTextBlockFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IChartTextBlockFormat) et [ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat), permettant de définir l'angle de rotation personnalisé pour le cadre de texte. Pour définir le RotationAngle, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Ajoutez un graphique sur la diapositive.
3. [Définissez la propriété RotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-).
4. Écrivez la présentation en tant que fichier PPTX.

Dans l'exemple ci-dessous, nous définissons la propriété RotationAngle.

```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Obtenez la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajoutez un AutoShape de type Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

    // Ajoutez un TextFrame au Rectangle
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Accéder au cadre de texte
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);

    // Créer l'objet Paragraph pour le cadre de texte
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Créer l'objet Portion pour le paragraphe
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Exemple de rotation de texte.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Enregistrer la présentation
    pres.save(resourcesOutputPath+"RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Espacement des lignes d'un paragraphe**
Aspose.Slides fournit des propriétés sous [`ParagraphFormat`](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraphFormat)—`SpaceAfter`, `SpaceBefore` et `SpaceWithin`—qui vous permettent de gérer l'espacement des lignes pour un paragraphe. Les trois propriétés sont utilisées de la manière suivante :

* Pour spécifier l'espacement des lignes pour un paragraphe en pourcentage, utilisez une valeur positive. 
* Pour spécifier l'espacement des lignes pour un paragraphe en points, utilisez une valeur négative.

Par exemple, vous pouvez appliquer un espacement de ligne de 16pt pour un paragraphe en définissant la propriété `SpaceBefore` à -16.

Voici comment spécifier l'espacement des lignes pour un paragraphe spécifique :

1. Chargez une présentation contenant un AutoShape avec du texte dedans.
2. Obtenez la référence d'une diapositive à travers son index.
3. Accédez au TextFrame.
4. Accédez au Paragraphe.
5. Définissez les propriétés du Paragraphe.
6. Enregistrez la présentation.

Ce code Java vous montre comment spécifier l'espacement des lignes pour un paragraphe :

```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Obtenez la référence d'une diapositive par son index
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Accédez au TextFrame
    ITextFrame tf1 = ((IAutoShape)sld.getShapes().get_Item(0)).getTextFrame();
    
    // Accédez au Paragraphe
    IParagraph para = tf1.getParagraphs().get_Item(0);
    
    // Définir les propriétés du Paragraphe
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
Dans ce sujet, nous allons explorer les différentes propriétés de formatage du cadre de texte. Cet article traite de la façon de définir la propriété AutofitType du cadre de texte, l'ancre du texte et la rotation du texte dans la présentation. Aspose.Slides pour Java permet aux développeurs de définir la propriété AutofitType de n'importe quel cadre de texte. AutofitType peut être défini sur [Normal](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Normal) ou [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Shape). S'il est défini sur [Normal](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Normal), alors la forme restera la même tandis que le texte sera ajusté sans modifier la forme elle-même, tandis que si AutofitType est défini sur [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Shape), alors la forme sera modifiée de manière à ne contenir que le texte nécessaire. Pour définir la propriété AutofitType d'un cadre de texte, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation ](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Accédez à la première diapositive.
3. Ajoutez n'importe quelle forme à la diapositive.
4. Accédez à [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. [Définissez le AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) du TextFrame.
6. Enregistrez le fichier sur le disque.

```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Accédez à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajoutez un AutoShape de type Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 150);

    // Ajoutez un TextFrame au Rectangle
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Accéder au cadre de texte
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    // Créer l'objet Paragraph pour le cadre de texte
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Créer l'objet Portion pour le paragraphe
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Un renard brun rapide saute par-dessus le chien paresseux. Un renard brun rapide saute par-dessus le chien paresseux.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Enregistrer la présentation
    pres.save(resourcesOutputPath + "formatText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir l'ancre du TextFrame**
Aspose.Slides pour Java permet aux développeurs de définir l'ancre de n'importe quel TextFrame. TextAnchorType spécifie où le texte est placé dans la forme. AnchorType peut être défini sur [Haut](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Top), [Centre](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Center), [Bas](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Bottom), [Justifié](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Justified) ou [Distribué](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Distributed). Pour définir l'ancre de n'importe quel TextFrame, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Accédez à la première diapositive.
3. Ajoutez n'importe quelle forme à la diapositive.
4. Accédez à [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. [Définissez le TextAnchorType](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) du TextFrame.
6. Enregistrez le fichier sur le disque.

```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Obtenez la première diapositive 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajoutez un AutoShape de type Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // Ajoutez un TextFrame au Rectangle
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // Accéder au cadre de texte
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);
    
    // Créer l'objet Paragraph pour le cadre de texte
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // Créer l'objet Portion pour le paragraphe
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Un renard brun rapide saute par-dessus le chien paresseux. Un renard brun rapide saute par-dessus le chien paresseux.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Enregistrer la présentation
    pres.save("AnchorText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tabulations et EffectiveTabs dans la présentation**
Toutes les tabulations de texte sont données en pixels.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Figure : 2 Tabulations explicites et 2 Tabulations par défaut**|
- La propriété EffectiveTabs.ExplicitTabCount (2 dans notre cas) est égale à Tabs.Count.
- La collection EffectiveTabs comprend toutes les tabulations (de la collection Tabs et des tabulations par défaut).
- La propriété EffectiveTabs.ExplicitTabCount (2 dans notre cas) est égale à Tabs.Count.
- La propriété EffectiveTabs.DefaultTabSize (294) montre la distance entre les tabulations par défaut (3 et 4 dans notre exemple).
- EffectiveTabs.GetTabByIndex(index) avec index = 0 renverra la première tabulation explicite (Position = 731), index = 1 - la deuxième tabulation (Position = 1241). Si vous essayez de récupérer la prochaine tabulation avec index = 2, cela renverra la première tabulation par défaut (Position = 1470) et ainsi de suite.
- EffectiveTabs.GetTabAfterPosition(pos) est utilisé pour obtenir la prochaine tabulation après un certain texte. Par exemple, vous avez le texte : "Bonjour le monde !". Pour rendre ce texte, vous devez savoir où commencer à dessiner "monde !". Au départ, vous devez calculer la longueur de "Bonjour" en pixels et appeler GetTabAfterPosition avec cette valeur. Vous obtiendrez la position de la prochaine tabulation pour dessiner "monde !".

## **Définir le style de texte par défaut**

Si vous devez appliquer le même formatage de texte par défaut à tous les éléments de texte d'une présentation en même temps, alors vous pouvez utiliser la méthode `getDefaultTextStyle` de l'interface [IPresentation](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/) et définir le formatage préféré. L'exemple de code ci-dessous montre comment définir la police en gras par défaut (14 pt) pour le texte sur toutes les diapositives d'une nouvelle présentation.

```java
Presentation presentation = new Presentation();
try {
    // Obtenez le format de paragraphe de niveau supérieur.
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