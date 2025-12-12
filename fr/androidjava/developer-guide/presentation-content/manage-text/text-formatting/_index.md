---
title: Formater le texte PowerPoint sur Android
linktitle: Mise en forme du texte
type: docs
weight: 50
url: /fr/androidjava/text-formatting/
keywords:
- surlignage du texte
- expression régulière
- alignement du paragraphe
- style du texte
- arrière-plan du texte
- transparence du texte
- espacement des caractères
- propriétés de police
- famille de police
- rotation du texte
- angle de rotation
- cadre de texte
- interlignage
- propriété autofit
- ancre du cadre de texte
- tabulation du texte
- langue par défaut
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Formatez et stylisez le texte dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Android via Java. Personnalisez les polices, les couleurs, l'alignement, et plus encore."
---

## **Surligner le texte**
La méthode [highlightText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) a été ajoutée à l'interface [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) et à la classe [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame).

Elle permet de surligner une partie du texte avec une couleur d'arrière-plan en utilisant un échantillon de texte, similaire à l'outil Couleur de surbrillance du texte dans PowerPoint 2019.

Le fragment de code ci‑dessous montre comment utiliser cette fonctionnalité :
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions textHighlightingOptions = new TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("title", Color.BLUE); // mise en évidence de tous les mots 'important'
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("to", Color.MAGENTA, textHighlightingOptions);// mise en évidence de toutes les occurrences séparées de 'the'
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 
Aspose propose un [service gratuit d'édition PowerPoint en ligne](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **Surligner le texte à l'aide d'une expression régulière**
La méthode [highlightRegex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) a été ajoutée à l'interface [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) et à la classe [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame).

Elle permet de surligner une partie du texte avec une couleur d'arrière-plan en utilisant une expression régulière, similaire à l'outil Couleur de surbrillance du texte dans PowerPoint 2019.

Le fragment de code ci‑dessous montre comment utiliser cette fonctionnalité :
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


## **Définir la couleur d'arrière-plan du texte**
Aspose.Slides vous permet de spécifier la couleur de votre choix pour l'arrière‑plan d'un texte.

Ce code Java montre comment définir la couleur d'arrière‑plan pour l'ensemble d'un texte :
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


Ce code Java montre comment définir la couleur d'arrière‑plan pour seulement une partie d'un texte :
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
Le formatage du texte est l'un des éléments clés lors de la création de documents ou de présentations. Nous savons qu'Aspose.Slides for Android via Java prend en charge l'ajout de texte aux diapositives, mais dans ce sujet, nous verrons comment contrôler l'alignement des paragraphes de texte dans une diapositive. Veuillez suivre les étapes ci‑dessous pour aligner les paragraphes de texte à l'aide d'Aspose.Slides for Android via Java :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive en utilisant son indice.
3. Accédez aux formes d'espace réservé présentes dans la diapositive et convertissez‑les en [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape).
4. Récupérez le paragraphe (qui doit être aligné) depuis le [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#getTextFrame--) exposé par [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape).
5. Alignez le paragraphe. Un paragraphe peut être aligné à droite, à gauche, centré ou justifié.
6. Enregistrez la présentation modifiée en fichier PPTX.

L'implémentation des étapes ci‑dessus est donnée ci‑dessous.
```java
// Instancier un objet Presentation qui représente un fichier PPTX
Presentation pres = new Presentation("ParagraphsAlignment.pptx");
try {
    // Accéder à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);

    // Accéder au premier et au deuxième espace réservé de la diapositive et les convertir en AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // Modifier le texte des deux espaces réservés
    tf1.setText("Center Align by Aspose");
    tf2.setText("Center Align by Aspose");

    // Obtenir le premier paragraphe des espaces réservés
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // Aligner le paragraphe de texte au centre
    para1.getParagraphFormat().setAlignment(TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(TextAlignment.Center);

    //Enregistrement de la présentation au format PPTX
    pres.save("Centeralign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Définir la transparence du texte**
Cet article montre comment définir la propriété de transparence sur n'importe quelle forme de texte en utilisant Aspose.Slides for Android via Java. Pour définir la transparence du texte, suivez les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive.
3. Définissez la couleur de l'ombre
4. Enregistrez la présentation en fichier PPTX.

L'implémentation des étapes ci‑dessous est donnée ci‑dessous.
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


## **Définir l'espacement des caractères du texte**
Aspose.Slides vous permet de définir l'espace entre les lettres dans une zone de texte. De cette façon, vous pouvez ajuster la densité visuelle d'une ligne ou d'un bloc de texte en élargissant ou en condensant l'espacement entre les caractères.

Ce code Java montre comment élargir l'espacement d'une ligne de texte et condenser l'espacement d'une autre ligne :
```java
Presentation presentation = new Presentation("in.pptx");

IAutoShape textBox1 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
IAutoShape textBox2 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(1);

textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20); // élargir
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2); // réduire

presentation.save("out.pptx", SaveFormat.Pptx);
```


## **Gérer les propriétés de police d'un paragraphe**
Les présentations contiennent généralement du texte et des images. Le texte peut être formaté de diverses manières, soit pour mettre en évidence des sections spécifiques, soit pour respecter les styles d'entreprise. Le formatage du texte aide les utilisateurs à varier l'apparence du contenu de la présentation. Cet article montre comment, avec Aspose.Slides for Android via Java, configurer les propriétés de police des paragraphes de texte sur les diapositives.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Obtenez la référence d'une diapositive en utilisant son indice.
1. Accédez aux formes d'espace réservé dans la diapositive et convertissez‑les en [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
1. Récupérez le [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) depuis le [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) exposé par [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
1. Justifiez le paragraphe.
1. Accédez à la Portion de texte d'un paragraphe.
1. Définissez la police à l'aide de FontData et définissez la police de la Portion de texte en conséquence.
   1. Mettez la police en gras.
   1. Mettez la police en italique.
1. Définissez la couleur de la police à l'aide de la méthode [getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--) exposée par l'objet [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion).
1. Enregistrez la présentation modifiée dans un fichier [PPTX](https://docs.fileformat.com/presentation/pptx/).

L'implémentation des étapes ci‑dessus prend une présentation vierge et formate les polices sur l'une des diapositives.
```java
// Instancier un objet Presentation qui représente un fichier PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
    // Accéder à une diapositive en utilisant sa position
    ISlide slide = pres.getSlides().get_Item(0);

    // Accéder au premier et au deuxième espace réservé de la diapositive et le convertir en AutoShape
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
Une Portion est utilisée pour contenir du texte avec un style de mise en forme similaire dans un paragraphe. Cet article montre comment, avec Aspose.Slides for Android via Java, créer une zone de texte contenant du texte puis définir une police particulière ainsi que diverses autres propriétés de la catégorie de famille de police.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive en utilisant son indice.
3. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) de type [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) à la diapositive.
4. Supprimez le style de remplissage associé au [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
5. Accédez au TextFrame de l'AutoShape.
6. Ajoutez du texte au TextFrame.
7. Accédez à l'objet Portion associé au [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
8. Définissez la police à utiliser pour la [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion).
9. Définissez d'autres propriétés de police telles que gras, italique, souligné, couleur et taille en utilisant les propriétés correspondantes exposées par l'objet Portion.
10. Enregistrez la présentation modifiée en fichier PPTX.

L'implémentation des étapes ci‑dessus est donnée ci‑dessous.
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
    tf.setText("Aspose TextBox");

    // Accéder à la Portion associée au TextFrame
    IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);

    // Définir la police pour la Portion
    port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));

    // Définir la propriété Gras de la police
    port.getPortionFormat().setFontBold(NullableBool.True);

    // Définir la propriété Italique de la police
    port.getPortionFormat().setFontItalic(NullableBool.True);

    // Définir la propriété Souligné de la police
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


## **Définir la taille de police du texte**
Aspose.Slides vous permet de choisir la taille de police souhaitée pour le texte existant dans un paragraphe ainsi que pour d'autres textes qui pourraient être ajoutés au paragraphe ultérieurement.

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
Aspose.Slides pour Android via Java permet aux développeurs de faire pivoter le texte. Le texte peut être affiché comme [Horizontal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Horizontal), [Vertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Vertical), [Vertical270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Vertical270), [WordArtVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#WordArtVertical), [EastAsianVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#EastAsianVertical), [MongolianVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#MongolianVertical) ou [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). Pour faire pivoter le texte de n'importe quel TextFrame, suivez les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Accédez à la première diapositive.
3. Ajoutez n'importe quelle forme à la diapositive.
4. Accédez au [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
5. [Rotate the text](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-).
6. Enregistrez le fichier sur le disque.
```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Obtenir la première diapositive 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajouter un AutoShape de type Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // Ajouter un TextFrame au rectangle
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


## **Définir un angle de rotation personnalisé pour un TextFrame**
Aspose.Slides pour Android via Java prend désormais en charge la définition d'un angle de rotation personnalisé pour le TextFrame. Dans cet article, nous verrons avec un exemple comment définir la propriété RotationAngle dans Aspose.Slides. Les nouvelles méthodes [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) et [getRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#getRotationAngle--) ont été ajoutées aux interfaces [IChartTextBlockFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartTextBlockFormat) et [ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat), permettant de définir un angle de rotation personnalisé pour le TextFrame. Pour définir RotationAngle, suivez les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Ajoutez un graphique sur la diapositive.
3. [Set RotationAngle property](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-).
4. Enregistrez la présentation en fichier PPTX.
```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Obtenir la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajouter un AutoShape de type Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

    // Ajouter un TextFrame au rectangle
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


## **Interlignage d'un paragraphe**
Aspose.Slides fournit des propriétés sous [`ParagraphFormat`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IParagraphFormat)—`SpaceAfter`, `SpaceBefore` et `SpaceWithin`—qui vous permettent de gérer l’interlignage d’un paragraphe.

* Pour spécifier l’interlignage d’un paragraphe en pourcentage, utilisez une valeur positive. 
* Pour spécifier l’interlignage d’un paragraphe en points, utilisez une valeur négative.

Par exemple, vous pouvez appliquer un interligne de 16 pt à un paragraphe en définissant la propriété `SpaceBefore` à -16.

Voici comment spécifier l’interlignage pour un paragraphe spécifique :

1. Chargez une présentation contenant une AutoShape avec du texte.
2. Obtenez la référence d'une diapositive via son indice.
3. Accédez au TextFrame.
4. Accédez au Paragraph.
5. Définissez les propriétés du Paragraph.
6. Enregistrez la présentation.
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


## **Définir la propriété AutofitType pour un TextFrame**
Dans ce sujet, nous explorerons les différentes propriétés de mise en forme d’un texte frame. Cet article montre comment définir la propriété AutofitType d’un texte frame, ancrer le texte et le faire pivoter dans une présentation. Aspose.Slides pour Android via Java permet aux développeurs de définir la propriété AutofitType de tout texte frame. AutofitType peut être défini sur [Normal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Normal) ou [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Shape). Si défini sur [Normal], la forme reste la même tandis que le texte est ajusté sans modifier la forme, alors que si AutofitType est défini sur [Shape], la forme sera modifiée de sorte que seul le texte requis y soit contenu. Pour définir la propriété AutofitType d’un texte frame, suivez les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Accédez à la première diapositive.
3. Ajoutez n'importe quelle forme à la diapositive.
4. Accédez au [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
5. [Set the AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) du TextFrame.
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


## **Définir l'ancrage d'un TextFrame**
Aspose.Slides pour Android via Java permet aux développeurs d’ancrer n'importe quel TextFrame. TextAnchorType indique où le texte est placé dans la forme. AnchorType peut être défini sur [Top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Top), [Center](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Center), [Bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Bottom), [Justified](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Justified) ou [Distributed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Distributed). Pour définir l’ancrage d’un TextFrame, suivez les étapes ci‑dessus :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Accédez à la première diapositive.
3. Ajoutez n'importe quelle forme à la diapositive.
4. Accédez au [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
5. [Set TextAnchorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) du TextFrame.
6. Enregistrez le fichier sur le disque.
```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Obtenir la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajouter un AutoShape de type Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // Ajouter un TextFrame au rectangle
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


## **Tabulations et EffectiveTabs dans une présentation**
Toutes les tabulations de texte sont exprimées en pixels.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Figure : 2 tabulations explicites et 2 tabulations par défaut**|

- La propriété EffectiveTabs.ExplicitTabCount (2 dans notre cas) est égale à Tabs.Count.
- La collection EffectiveTabs inclut toutes les tabulations (de la collection Tabs et les tabulations par défaut).
- La propriété EffectiveTabs.ExplicitTabCount (2 dans notre cas) est égale à Tabs.Count.
- La propriété EffectiveTabs.DefaultTabSize (294) indique la distance entre les tabulations par défaut (3 et 4 dans notre exemple).
- EffectiveTabs.GetTabByIndex(index) avec index = 0 renvoie la première tabulation explicite (Position = 731), index = 1 la deuxième (Position = 1241). Si vous essayez d'obtenir la tabulation suivante avec index = 2, cela renverra la première tabulation par défaut (Position = 1470), etc.
- EffectiveTabs.GetTabAfterPosition(pos) sert à obtenir la prochaine tabulation après un texte. Par exemple, vous avez le texte : "Hello World !". Pour rendre ce texte, vous devez savoir où commencer à dessiner "World". D'abord, calculez la longueur de "Hello" en pixels et appelez GetTabAfterPosition avec cette valeur. Vous obtiendrez la position de la prochaine tabulation pour dessiner "World".

## **Définir le style de texte par défaut**
Si vous devez appliquer le même formatage de texte par défaut à tous les éléments texte d’une présentation en une fois, vous pouvez utiliser la méthode `getDefaultTextStyle` de l'interface [IPresentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/) et définir le formatage souhaité. L'exemple de code ci‑dessous montre comment définir la police en gras par défaut (14 pt) pour le texte de toutes les diapositives d'une nouvelle présentation.
```java
Presentation presentation = new Presentation();
try {
    // Obtenir le format de paragraphe de niveau supérieur.
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


## **Extraire le texte avec l'effet Majuscules**
Dans PowerPoint, l'application de l'effet de police **All Caps** rend le texte en majuscules sur la diapositive même s'il a été saisi en minuscules. Lorsque vous récupérez une telle portion de texte avec Aspose.Slides, la bibliothèque renvoie le texte tel qu'il a été saisi. Pour gérer cela, vérifiez [TextCapType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textcaptype/) — si elle indique `All`, convertissez simplement la chaîne renvoyée en majuscules afin que votre sortie corresponde à ce que l'utilisateur voit sur la diapositive.

Supposons que nous ayons la zone de texte suivante sur la première diapositive du fichier sample2.pptx.

![The All Caps effect](all_caps_effect.png)

L'exemple de code ci‑dessous montre comment extraire le texte avec l'effet **All Caps** appliqué :
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

Pour modifier le texte dans un tableau sur une diapositive, utilisez l'interface [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/). Vous pouvez parcourir toutes les cellules du tableau et modifier le texte de chaque cellule en accédant à leurs propriétés `TextFrame` et `ParagraphFormat`.

**Comment appliquer une couleur dégradée au texte dans une diapositive PowerPoint ?**

Pour appliquer une couleur dégradée au texte, utilisez la méthode `getFillFormat` de [BasePortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/). Définissez le `FillFormat` sur `Gradient`, où vous pouvez spécifier les couleurs de début et de fin du dégradé, ainsi que d'autres propriétés comme la direction et la transparence pour créer l'effet dégradé sur le texte.