---
title: Mise en forme du texte
type: docs
weight: 50
url: /androidjava/text-formatting/
keywords:
- surligner du texte
- expression régulière
- aligner des paragraphes de texte
- transparence du texte
- propriétés de police de paragraphe
- famille de polices
- rotation du texte
- rotation d'angle personnalisée
- cadre de texte
- interligne
- propriété d'ajustement automatique
- ancrage du cadre de texte
- tabulation de texte
- style de texte par défaut
- Java
- Aspose.Slides pour Android via Java
description: "Gérer et manipuler les propriétés du texte et du cadre de texte en Java"
---

## **Surligner du texte**
La méthode [highlightText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) a été ajoutée à l'interface [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) et à la classe [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame).

Elle permet de surligner une partie du texte avec une couleur de fond en utilisant un échantillon de texte, semblable à l'outil de couleur de surlignement du texte dans PowerPoint 2019.

L'extrait de code ci-dessous montre comment utiliser cette fonctionnalité :

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions textHighlightingOptions = new TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("title", Color.BLUE); // surligner tous les mots 'important'
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("to", Color.MAGENTA, textHighlightingOptions);// surligner toutes les occurrences séparées de 'le'
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

Aspose fournit un simple [service de modification de PowerPoint en ligne gratuit](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Surligner du texte à l'aide d'expressions régulières**

La méthode [highlightRegex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) a été ajoutée à l'interface [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) et à la classe [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame).

Elle permet de surligner une partie du texte avec une couleur de fond en utilisant des regex, semblable à l'outil de couleur de surlignement du texte dans PowerPoint 2019.

L'extrait de code ci-dessous montre comment utiliser cette fonctionnalité :

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions options = new TextHighlightingOptions();
    
    ((AutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.awt.Color.YELLOW, options); // surligner tous les mots de 10 symboles ou plus
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir la couleur de fond du texte**

Aspose.Slides vous permet de spécifier votre couleur préférée pour l'arrière-plan d'un texte.

Ce code Java vous montre comment définir la couleur de fond pour un texte entier :

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

Ce code Java vous montre comment définir la couleur de fond uniquement pour une portion d'un texte :

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

## **Aligner des paragraphes de texte**

La mise en forme du texte est l'un des éléments clés lors de la création de tout type de documents ou de présentations. Nous savons qu'Aspose.Slides pour Android via Java prend en charge l'ajout de texte aux diapositives, mais dans ce sujet, nous allons voir comment nous pouvons contrôler l'alignement des paragraphes de texte dans une diapositive. Veuillez suivre les étapes ci-dessous pour aligner les paragraphes de texte à l'aide d'Aspose.Slides pour Android via Java :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive en utilisant son index.
3. Accédez aux formes de remplacement présentes dans la diapositive et castées-les en tant que [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape).
4. Obtenez le paragraphe (qui doit être aligné) à partir du [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#getTextFrame--) exposé par [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape).
5. Alignez le paragraphe. Un paragraphe peut être aligné à droite, à gauche, au centre et justifié.
6. Écrivez la présentation modifiée en tant que fichier PPTX.

L'implémentation des étapes ci-dessus est donnée ci-dessous.

```java
// Instancier un objet Presentation qui représente un fichier PPTX
Presentation pres = new Presentation("ParagraphsAlignment.pptx");
try {
    // Accéder à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);

    // Accéder à la première et à la deuxième forme de remplacement dans la diapositive et les castées en tant qu'AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // Changer le texte dans les deux espaces réservés
    tf1.setText("Alignement au centre par Aspose");
    tf2.setText("Alignement au centre par Aspose");

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
Cet article montre comment définir la propriété de transparence pour n'importe quelle forme de texte en utilisant Aspose.Slides pour Android via Java. Pour définir la transparence sur le texte, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive.
3. Définir la couleur de l'ombre.
4. Écrivez la présentation en tant que fichier PPTX.

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

Ce code Java vous montre comment élargir l'espacement pour une ligne de texte et condenser l'espacement pour une autre ligne :

```java
Presentation presentation = new Presentation("in.pptx");

IAutoShape textBox1 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
IAutoShape textBox2 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(1);

textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20); // élargir
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2); // condenser

presentation.save("out.pptx", SaveFormat.Pptx);
```

## **Gérer les propriétés de police des paragraphes**

Les présentations contiennent généralement à la fois du texte et des images. Le texte peut être formaté de différentes manières, soit pour mettre en évidence des sections et des mots spécifiques, soit pour se conformer aux styles d'entreprise. La mise en forme du texte aide les utilisateurs à varier l'apparence et l'atmosphère du contenu de la présentation. Cet article montre comment utiliser Aspose.Slides pour Android via Java pour configurer les propriétés de police des paragraphes de texte sur les diapositives. Pour gérer les propriétés de police d'un paragraphe en utilisant Aspose.Slides pour Android via Java :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive en utilisant son index.
3. Accédez aux formes de remplacement dans la diapositive et castées-les en tant que [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
4. Obtenez le [Paragraphe](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) de l'[ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) exposé par [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
5. Justifiez le paragraphe.
6. Accédez à la portion de texte d'un paragraphe.
7. Définissez la police en utilisant FontData et réglez la police de la portion de texte en conséquence.
   1. Définissez la police en gras.
   2. Définissez la police en italique.
8. Définissez la couleur de la police en utilisant le [getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--) exposé par l'objet [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion).
9. Écrivez la présentation modifiée dans un fichier [PPTX](https://docs.fileformat.com/presentation/pptx/).

L'implémentation des étapes ci-dessus est donnée ci-dessous. Elle prend une présentation sans décor et formate les polices sur l'une des diapositives.

```java
// Instancier un objet Presentation qui représente un fichier PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
    // Accéder à une diapositive à l'aide de sa position de diapositive
    ISlide slide = pres.getSlides().get_Item(0);

    // Accéder à la première et à la deuxième forme de remplacement dans la diapositive et les castées en tant qu'AutoShape
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

    // Attribuer de nouvelles polices à la portion
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);

    // Définir la police en Gras
    port1.getPortionFormat().setFontBold(NullableBool.True);
    port2.getPortionFormat().setFontBold(NullableBool.True);

    // Définir la police en Italique
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
Une portion est utilisée pour contenir du texte avec un style de formatage similaire dans un paragraphe. Cet article montre comment utiliser Aspose.Slides pour Android via Java pour créer une zone de texte avec du texte et définir une police particulière, ainsi que diverses autres propriétés de la catégorie de famille de polices. Pour créer une zone de texte et définir les propriétés de police du texte qui s'y trouve :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive en utilisant son index.
3. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) de type [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) à la diapositive.
4. Supprimez le style de remplissage associé à l'[IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
5. Accédez au TextFrame de l'AutoShape.
6. Ajoutez du texte au TextFrame.
7. Accédez à l'objet Portion associé à l'[ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
8. Définissez la police à utiliser pour la [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion).
9. Définissez d'autres propriétés de police comme gras, italique, souligné, couleur et hauteur en utilisant les propriétés pertinentes exposées par l'objet Portion.
10. Écrivez la présentation modifiée comme un fichier PPTX.

L'implémentation des étapes ci-dessus est donnée ci-dessous.

```java
// Instancier Presentation
Presentation pres = new Presentation();
try {

    // Obtenir la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajouter un AutoShape de type Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);

    // Supprimer tout style de remplissage associé à l'AutoShape
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Accéder au TextFrame associé à l'AutoShape
    ITextFrame tf = ashp.getTextFrame();
    tf.setText("Zone de texte Aspose");

    // Accéder à la Portion associée au TextFrame
    IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);

    // Définir la police pour la Portion
    port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));

    // Définir la propriété Grasse de la police
    port.getPortionFormat().setFontBold(NullableBool.True);

    // Définir la propriété Italique de la police
    port.getPortionFormat().setFontItalic(NullableBool.True);

    // Définir la propriété Soulignée de la police
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
    // Obtenir la première forme, par exemple.
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape )
    {
        IAutoShape autoShape = (AutoShape) shape;
        // Obtenir le premier paragraphe, par exemple.
        IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

        // Définir la taille de police par défaut à 20 pt pour toutes les portions de texte dans le paragraphe. 
        paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);

        // Définir la taille de police à 20 pt pour les portions de texte actuelles dans le paragraphe. 
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

Aspose.Slides pour Android via Java permet aux développeurs de faire pivoter le texte. Le texte peut être défini pour apparaître en [Horizontal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Horizontal), [Vertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Vertical), [Vertical270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Vertical270), [WordArtVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#WordArtVertical), [EastAsianVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#EastAsianVertical), [MongolianVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#MongolianVertical) ou [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). Pour faire pivoter le texte de n'importe quel TextFrame, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Accédez à la première diapositive.
3. Ajoutez n'importe quelle forme à la diapositive.
4. Accédez au [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
5. [Faites pivoter le texte](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-).
6. Enregistrez le fichier sur le disque.

```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Obtenir la première diapositive 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajouter un AutoShape de type Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // Ajouter un TextFrame au Rectangle
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // Accéder au cadre de texte
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);
    
    // Créer l'objet Paragraphe pour le cadre de texte
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

## **Définir un angle de rotation personnalisée pour le TextFrame**
Aspose.Slides pour Android via Java prend désormais en charge la définition d'un angle de rotation personnalisé pour le cadre de texte. Dans ce sujet, nous allons voir avec un exemple comment définir la propriété RotationAngle dans Aspose.Slides. Les nouvelles méthodes [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) et [getRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#getRotationAngle--) ont été ajoutées aux interfaces [IChartTextBlockFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartTextBlockFormat) et [ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat), permettant de définir l'angle de rotation personnalisé pour le cadre de texte. Pour définir l'angle de rotation, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Ajoutez un graphique sur la diapositive.
3. [Définissez la propriété RotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-).
4. Écrivez la présentation comme un fichier PPTX.

Dans l'exemple ci-dessous, nous définissons la propriété RotationAngle.

```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Obtenir la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajouter un AutoShape de type Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

    // Ajouter un TextFrame au Rectangle
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Accéder au cadre de texte
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);

    // Créer l'objet Paragraphe pour le cadre de texte
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Créer l'objet Portion pour le paragraphe
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Exemple de rotation du texte.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Enregistrer la présentation
    pres.save(resourcesOutputPath+"RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Espacement des lignes dans un paragraphe**
Aspose.Slides propose des propriétés sous [`ParagraphFormat`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IParagraphFormat)—`SpaceAfter`, `SpaceBefore` et `SpaceWithin`—qui vous permettent de gérer l'espacement des lignes pour un paragraphe. Les trois propriétés sont utilisées de cette manière :

* Pour spécifier l'espacement des lignes d'un paragraphe en pourcentage, utilisez une valeur positive. 
* Pour spécifier l'espacement des lignes d'un paragraphe en points, utilisez une valeur négative.

Par exemple, vous pouvez appliquer un espacement de lignes de 16 pt à un paragraphe en définissant la propriété `SpaceBefore` à -16.

Voici comment vous spécifiez l'espacement des lignes pour un paragraphe spécifique :

1. Chargez une présentation contenant un AutoShape avec du texte dedans.
2. Obtenez la référence d'une diapositive par son index.
3. Accédez au TextFrame.
4. Accédez au Paragraphe.
5. Définissez les propriétés du Paragraphe.
6. Enregistrez la présentation.

Ce code Java vous montre comment spécifier l'espacement des lignes pour un paragraphe :

```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Obtenir la référence d'une diapositive par son index
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Accéder au TextFrame
    ITextFrame tf1 = ((IAutoShape)sld.getShapes().get_Item(0)).getTextFrame();
    
    // Accéder au Paragraphe
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

## **Définir la propriété AutofitType pour le TextFrame**
Dans ce sujet, nous allons explorer les différentes propriétés de formatage du cadre de texte. Cet article couvre comment définir la propriété AutofitType du cadre de texte, l'ancrage du texte et la rotation du texte dans la présentation. Aspose.Slides pour Android via Java permet aux développeurs de définir la propriété AutofitType de n'importe quel cadre de texte. AutofitType peut être défini sur [Normal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Normal) ou [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Shape). S'il est défini sur [Normal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Normal), alors la forme restera la même tandis que le texte sera ajusté sans provoquer de changement dans la forme elle-même, tandis que si AutofitType est défini sur [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Shape), alors la forme sera modifiée de telle manière qu'elle contienne uniquement le texte requis. Pour définir la propriété AutofitType d'un cadre de texte, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Accédez à la première diapositive.
3. Ajoutez n'importe quelle forme à la diapositive.
4. Accédez au [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
5. [Définissez le AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) du TextFrame.
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

    // Accédez au cadre de texte
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    // Créez l'objet Paragraphe pour le cadre de texte
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Créez l'objet Portion pour le paragraphe
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

## **Définir l'ancrage du TextFrame**
Aspose.Slides pour Android via Java permet aux développeurs de définir l'ancrage de n'importe quel TextFrame. TextAnchorType spécifie où du texte est placé dans la forme. AnchorType peut être défini sur [Top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Top), [Center](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Center), [Bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Bottom), [Justified](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Justified) ou [Distributed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Distributed). Pour définir l'ancrage de n'importe quel TextFrame, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Accédez à la première diapositive.
3. Ajoutez n'importe quelle forme à la diapositive.
4. Accédez au [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
5. [Définissez le TextAnchorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) du TextFrame.
6. Enregistrez le fichier sur le disque.

```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Obtenir la première diapositive 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajouter un AutoShape de type Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // Ajouter un TextFrame au Rectangle
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // Accéder au cadre de texte
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);
    
    // Créer l'objet Paragraphe pour le cadre de texte
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

## **Tabs et EffectiveTabs dans la présentation**
Toutes les tabulations de texte sont données en pixels.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Figure : 2 Tabs explicites et 2 Tabs par défaut**|
- La propriété EffectiveTabs.ExplicitTabCount (2 dans notre cas) est égale à Tabs.Count.
- La collection EffectiveTabs inclut toutes les tabs (de la collection Tabs et des tabs par défaut).
- La propriété EffectiveTabs.ExplicitTabCount (2 dans notre cas) est égale à Tabs.Count.
- La propriété EffectiveTabs.DefaultTabSize (294) montre la distance entre les tabs par défaut (3 et 4 dans notre exemple).
- EffectiveTabs.GetTabByIndex(index) avec index = 0 renverra le premier tab explicite (Position = 731), index = 1 - deuxième tab (Position = 1241). Si vous essayez d'obtenir le prochain tab avec index = 2, il renverra le premier tab par défaut (Position = 1470) et ainsi de suite.
- EffectiveTabs.GetTabAfterPosition(pos) utilisé pour obtenir la prochaine tabulation après un certain texte. Par exemple, vous avez le texte : "Bonjour le monde !". Pour rendre ce texte, vous devez savoir où commencer à dessiner "le monde !". Tout d'abord, vous devez calculer la longueur de "Bonjour" en pixels et appeler GetTabAfterPosition avec cette valeur. Vous obtiendrez la prochaine position de tabulation pour dessiner "le monde !".

## **Définir le style de texte par défaut**

Si vous avez besoin d'appliquer le même formatage de texte par défaut à tous les éléments de texte d'une présentation à la fois, vous pouvez utiliser la méthode `getDefaultTextStyle` de l'interface [IPresentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/) et définir le formatage préféré. L'exemple de code ci-dessous montre comment définir la police en gras par défaut (14 pt) pour le texte sur toutes les diapositives d'une nouvelle présentation.

```java
Presentation presentation = new Presentation();
try {
    // Obtenir le format de paragraphe supérieur.
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