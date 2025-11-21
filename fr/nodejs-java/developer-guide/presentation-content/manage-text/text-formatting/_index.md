---
title: Formater le texte PowerPoint en JavaScript
linktitle: Mise en forme du texte
type: docs
weight: 50
url: /fr/nodejs-java/text-formatting/
keywords:
- mise en surbrillance du texte
- expression régulière
- aligner le paragraphe
- style du texte
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
- ancre du cadre de texte
- tabulation du texte
- langue par défaut
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez à mettre en forme et à styliser le texte dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Node.js via Java. Personnalisez les polices, les couleurs, l'alignement et bien plus encore grâce à des exemples de code JavaScript puissants."
---

## **Mettre en surbrillance le texte**

La méthode [highlightText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#highlightText-java.lang.String-java.awt.Color-) a été ajoutée à la classe [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) et à la classe [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame).

Elle permet de mettre en surbrillance une partie du texte avec une couleur de fond à l'aide d'un exemple de texte, similaire à l'outil de couleur de surbrillance du texte dans PowerPoint 2019.

L'extrait de code ci‑dessous montre comment utiliser cette fonctionnalité :
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var textHighlightingOptions = new aspose.slides.TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightText("title", java.getStaticFieldValue("java.awt.Color", "BLUE"));// mise en évidence de tous les mots 'important'
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightText("to", java.getStaticFieldValue("java.awt.Color", "MAGENTA"), textHighlightingOptions);// mise en évidence de toutes les occurrences séparées de 'the'
    pres.save("OutputPresentation-highlight.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 

Aspose propose un service simple, [gratuit d'édition en ligne de PowerPoint](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Mettre en surbrillance le texte à l'aide d'expressions régulières**

La méthode [highlightRegex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#highlightRegex-java.lang.String-java.awt.Color-aspose.slides.ITextHighlightingOptions-) a été ajoutée à la classe [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) et à la classe [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame).

Elle permet de mettre en surbrillance une partie du texte avec une couleur de fond à l'aide d'expressions régulières, similaire à l'outil de couleur de surbrillance du texte dans PowerPoint 2019.

L'extrait de code ci‑dessous montre comment utiliser cette fonctionnalité :
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var options = new aspose.slides.TextHighlightingOptions();
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.getStaticFieldValue("java.awt.Color", "YELLOW"), options);// mise en évidence de tous les mots de 10 caractères ou plus
    pres.save("OutputPresentation-highlight.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Définir la couleur d'arrière‑plan du texte**

Aspose.Slides vous permet de spécifier votre couleur préférée pour l'arrière‑plan d'un texte.

Ce code JavaScript vous montre comment définir la couleur d'arrière‑plan pour tout le texte :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();
    var para = new aspose.slides.Paragraph();
    var portion1 = new aspose.slides.Portion("Black");
    portion1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    var portion2 = new aspose.slides.Portion(" Red ");
    var portion3 = new aspose.slides.Portion("Black");
    portion3.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    para.getPortions().add(portion1);
    para.getPortions().add(portion2);
    para.getPortions().add(portion3);
    autoShape.getTextFrame().getParagraphs().add(para);
    pres.save("text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
const pres = new aspose.slides.Presentation("text.pptx");
try {
    const slide = pres.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    if (autoShape.getTextFrame() != null) {
        const paragraphs = autoShape.getTextFrame().getParagraphs();
        const paragraphCount = paragraphs.size();
        for (let i = 0; i < paragraphCount; i++) {
            const portions = paragraphs.get_Item(i).getPortions();
            const portionCount = portions.size();
            for (let j = 0; j < portionCount; j++) {
                const portion = portions.get_Item(j);
                portion.getPortionFormat().getHighlightColor().setColor(Color.BLUE);
            }
        }
    }
    pres.save("text-red.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


Ce code JavaScript vous montre comment définir la couleur d'arrière‑plan pour seulement une partie du texte :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();
    var para = new aspose.slides.Paragraph();
    var portion1 = new aspose.slides.Portion("Black");
    portion1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    var portion2 = new aspose.slides.Portion(" Red ");
    var portion3 = new aspose.slides.Portion("Black");
    portion3.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    para.getPortions().add(portion1);
    para.getPortions().add(portion2);
    para.getPortions().add(portion3);
    autoShape.getTextFrame().getParagraphs().add(para);
    pres.save("text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
var presentation = new aspose.slides.Presentation("text.pptx");
try {
    var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var redPortion = java.callStaticMethodSync("StreamSupport", "stream", autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().spliterator(), false).filter(p -> p.getText().contains("Red")).findFirst();
    if (redPortion.isPresent()) {
        redPortion.get().getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    }
    presentation.save("text-red.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Aligner les paragraphes de texte**

Le formatage du texte est l'un des éléments clés lors de la création de tout type de documents ou de présentations. Nous savons qu'Aspose.Slides for Node.js via Java prend en charge l'ajout de texte aux diapositives, mais dans ce sujet, nous verrons comment contrôler l'alignement des paragraphes de texte dans une diapositive. Veuillez suivre les étapes ci‑dessous pour aligner les paragraphes de texte à l'aide d'Aspose.Slides for Node.js via Java :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive en utilisant son index.
3. Accédez aux formes Placeholder présentes dans la diapositive et convertissez‑les en tant que [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
4. Récupérez le paragraphe (qui doit être aligné) depuis le [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#getTextFrame--) exposé par [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. Alignez le paragraphe. Un paragraphe peut être aligné à Droite, Gauche, Centre ou Justifié.
6. Enregistrez la présentation modifiée sous forme de fichier PPTX.

L'implémentation des étapes ci‑above est donnée ci‑dessous.
```javascript
// Instancier un objet Presentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation("ParagraphsAlignment.pptx");
try {
    // Accéder à la première diapositive
    var slide = pres.getSlides().get_Item(0);
    // Accéder au premier et au deuxième espace réservé dans la diapositive et les convertir en AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // Modifier le texte dans les deux espaces réservés
    tf1.setText("Center Align by Aspose");
    tf2.setText("Center Align by Aspose");
    // Récupérer le premier paragraphe des espaces réservés
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // Aligner le paragraphe de texte au centre
    para1.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);
    // Enregistrer la présentation au format PPTX
    pres.save("Centeralign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Définir la transparence du texte**

Cet article montre comment définir la propriété de transparence pour toute forme de texte à l'aide d'Aspose.Slides for Node.js via Java. Pour définir la transparence du texte, veuillez suivre les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive.
3. Définissez la couleur de l'ombre.
4. Enregistrez la présentation sous forme de fichier PPTX.

```javascript
var pres = new aspose.slides.Presentation("transparency.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var effects = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getEffectFormat();
    var outerShadowEffect = effects.getOuterShadowEffect();
    var shadowColor = outerShadowEffect.getShadowColor().getColor();
    console.log((shadowColor.toString() + " - transparency is: ") + ((shadowColor.getAlpha() / 255.0) * 100));
    // définir la transparence à zéro pour cent
    outerShadowEffect.getShadowColor().setColor(java.newInstanceSync("java.awt.Color", shadowColor.getRed(), shadowColor.getGreen(), shadowColor.getBlue(), 255));
    pres.save("transparency-2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Définir l'espacement des caractères pour le texte**

Aspose.Slides vous permet de définir l'espace entre les lettres dans une zone de texte. Ainsi, vous pouvez ajuster la densité visuelle d'une ligne ou d'un bloc de texte en élargissant ou en condensant l'espacement entre les caractères.

Ce code JavaScript montre comment élargir l'espacement pour une ligne de texte et condenser l'espacement pour une autre ligne :
```javascript
var presentation = new aspose.slides.Presentation("in.pptx");
var textBox1 = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var textBox2 = presentation.getSlides().get_Item(0).getShapes().get_Item(1);
textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20);// étendre
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2);// condenser
presentation.save("out.pptx", aspose.slides.SaveFormat.Pptx);
```


## **Gérer les propriétés de police du paragraphe**

Les présentations contiennent généralement à la fois du texte et des images. Le texte peut être formaté de diverses manières, soit pour mettre en évidence des sections et des mots spécifiques, soit pour se conformer aux styles d'entreprise. Le formatage du texte aide les utilisateurs à varier l'aspect du contenu de la présentation. Cet article montre comment utiliser Aspose.Slides for Node.js via Java pour configurer les propriétés de police des paragraphes de texte sur les diapositives.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive en utilisant son index.
3. Accédez aux formes Placeholder dans la diapositive et convertissez‑les en [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
4. Récupérez le [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) depuis le [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) exposé par [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. Justifiez le paragraphe.
6. Accédez à la portion de texte du paragraphe.
7. Définissez la police à l'aide de FontData et attribuez la police à la portion de texte en conséquence.
   1. Mettez la police en gras.
   2. Mettez la police en italique.
8. Définissez la couleur de la police en utilisant la méthode [getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BasePortionFormat#getFillFormat--) exposée par l'objet [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion).
9. Enregistrez la présentation modifiée dans un fichier [PPTX](https://docs.fileformat.com/presentation/pptx/).

```javascript
// Instancier un objet Presentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation("FontProperties.pptx");
try {
    // Accéder à une diapositive en utilisant sa position
    var slide = pres.getSlides().get_Item(0);
    // Accéder au premier et au deuxième espace réservé dans la diapositive et les convertir en AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // Accéder au premier paragraphe
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // Accéder à la première portion
    var port1 = para1.getPortions().get_Item(0);
    var port2 = para2.getPortions().get_Item(0);
    // Définir de nouvelles polices
    var fd1 = new aspose.slides.FontData("Elephant");
    var fd2 = new aspose.slides.FontData("Castellar");
    // Assigner les nouvelles polices à la portion
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);
    // Définir la police en gras
    port1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Définir la police en italique
    port1.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Définir la couleur de la police
    port1.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    port2.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // Écrire le PPTX sur le disque
    pres.save("WelcomeFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Gérer la famille de polices du texte**

Une portion est utilisée pour contenir du texte avec un style de formatage similaire dans un paragraphe. Cet article montre comment utiliser Aspose.Slides for Node.js via Java pour créer une zone de texte avec du texte, puis définir une police particulière ainsi que diverses autres propriétés de la catégorie famille de polices. Pour créer une zone de texte et définir les propriétés de police du texte qu'elle contient :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive en utilisant son index.
3. Ajoutez un [AutoShape] de type [Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType#Rectangle) à la diapositive.
4. Supprimez le style de remplissage associé au [AutoShape].
5. Accédez au TextFrame du AutoShape.
6. Ajoutez du texte au TextFrame.
7. Accédez à l'objet Portion associé au [TextFrame].
8. Définissez la police à utiliser pour la [Portion].
9. Définissez d'autres propriétés de police telles que gras, italique, souligné, couleur et taille en utilisant les propriétés pertinentes exposées par l'objet Portion.
10. Enregistrez la présentation modifiée sous forme de fichier PPTX.

```javascript
// Instancier une présentation
var pres = new aspose.slides.Presentation();
try {
    // Obtenir la première diapositive
    var sld = pres.getSlides().get_Item(0);
    // Ajouter une AutoShape de type Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // Supprimer tout style de remplissage associé à l'AutoShape
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Accéder au TextFrame associé à l'AutoShape
    var tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");
    // Accéder à la Portion associée au TextFrame
    var port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
    // Définir la police pour la Portion
    port.getPortionFormat().setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Définir la propriété gras de la police
    port.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Définir la propriété italique de la police
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Définir la propriété soulignement de la police
    port.getPortionFormat().setFontUnderline(aspose.slides.TextUnderlineType.Single);
    // Définir la hauteur de la police
    port.getPortionFormat().setFontHeight(25);
    // Définir la couleur de la police
    port.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // Enregistrer le PPTX sur le disque
    pres.save("SetTextFontProperties_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Définir la taille de police du texte**

Aspose.Slides vous permet de choisir la taille de police souhaitée pour le texte existant dans un paragraphe ainsi que pour d’autres textes qui peuvent être ajoutés ultérieurement au paragraphe. Ce code JavaScript montre comment définir la taille de police pour les textes contenus dans un paragraphe :
```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // Obtient la première forme, par exemple.
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        var autoShape = shape;
        // Obtient le premier paragraphe, par exemple.
        var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
        // Définit la taille de police par défaut à 20 pt pour toutes les portions de texte du paragraphe.
        paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
        // Définit la taille de police à 20 pt pour les portions de texte actuelles du paragraphe.
        for (let i = 0; i < paragraph.getPortions().getCount(); i++) {
            let portion = paragraph.getPortions().get_Item(i);
            portion.getPortionFormat().setFontHeight(20);
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Définir la rotation du texte**

Aspose.Slides for Node.js via Java permet aux développeurs de faire pivoter le texte. Le texte peut être affiché comme [Horizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Horizontal), [Vertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Vertical), [Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Vertical270), [WordArtVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#WordArtVertical), [EastAsianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#EastAsianVertical), [MongolianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#MongolianVertical) ou [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). Pour faire pivoter le texte d'un TextFrame, veuillez suivre les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Accédez à la première diapositive.
3. Ajoutez n'importe quelle forme à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. [Faire pivoter le texte](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setTextVerticalType-byte-).
6. Enregistrez le fichier sur le disque.
```javascript
// Créer une instance de la classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Obtenir la première diapositive
    var slide = pres.getSlides().get_Item(0);
    // Ajouter une AutoShape de type Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // Ajouter un TextFrame au Rectangle
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Accéder au TextFrame
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(aspose.slides.TextVerticalType.Vertical270);
    // Créer l'objet Paragraph pour le TextFrame
    var para = txtFrame.getParagraphs().get_Item(0);
    // Créer l'objet Portion pour le paragraphe
    var portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Enregistrer la présentation
    pres.save("RotateText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Définir un angle de rotation personnalisé pour TextFrame**

Aspose.Slides for Node.js via Java prend désormais en charge la définition d'un angle de rotation personnalisé pour le TextFrame. Dans ce sujet, nous verrons avec un exemple comment définir la propriété RotationAngle dans Aspose.Slides. Les nouvelles méthodes [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setRotationAngle-float-) et [getRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#getRotationAngle--) ont été ajoutées aux classes [ChartTextBlockFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartTextBlockFormat) et [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) , permettant de définir un angle de rotation personnalisé pour le TextFrame. Pour définir RotationAngle, veuillez suivre les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Ajoutez un graphique sur la diapositive.
3. [Définir la propriété RotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setRotationAngle-float-).
4. Enregistrez la présentation sous forme de fichier PPTX.

Dans l'exemple ci‑dessous, nous définissons la propriété RotationAngle.
```javascript
// Créer une instance de la classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Obtenir la première diapositive
    var slide = pres.getSlides().get_Item(0);
    // Ajouter une AutoShape de type Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // Ajouter un TextFrame au Rectangle
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Accéder au TextFrame
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);
    // Créer l'objet Paragraph pour le TextFrame
    var para = txtFrame.getParagraphs().get_Item(0);
    // Créer l'objet Portion pour le paragraphe
    var portion = para.getPortions().get_Item(0);
    portion.setText("Text rotation example.");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Enregistrer la présentation
    pres.save(resourcesOutputPath + "RotateText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Interligne du paragraphe**

Aspose.Slides fournit des propriétés sous [`ParagraphFormat`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ParagraphFormat)—`SpaceAfter`, `SpaceBefore` et `SpaceWithin`—qui permettent de gérer l'interligne d'un paragraphe. Les trois propriétés sont utilisées de la manière suivante :

* Pour spécifier l'interligne d'un paragraphe en pourcentage, utilisez une valeur positive.  
* Pour spécifier l'interligne d'un paragraphe en points, utilisez une valeur négative.

Par exemple, vous pouvez appliquer un interligne de 16 pt à un paragraphe en définissant la propriété `SpaceBefore` à -16.

Voici comment spécifier l'interligne pour un paragraphe spécifique :

1. Chargez une présentation contenant un AutoShape avec du texte.
2. Obtenez la référence d’une diapositive via son index.
3. Accédez au TextFrame.
4. Accédez au Paragraph.
5. Définissez les propriétés du Paragraph.
6. Enregistrez la présentation.

Ce code JavaScript montre comment spécifier l'interligne d'un paragraphe :
```javascript
// Créer une instance de la classe Presentation
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // Obtenir la référence d'une diapositive par son index
    var sld = pres.getSlides().get_Item(0);
    // Accéder au TextFrame
    var tf1 = sld.getShapes().get_Item(0).getTextFrame();
    // Accéder au paragraphe
    var para = tf1.getParagraphs().get_Item(0);
    // Définir les propriétés du paragraphe
    para.getParagraphFormat().setSpaceWithin(80);
    para.getParagraphFormat().setSpaceBefore(40);
    para.getParagraphFormat().setSpaceAfter(40);
    // Enregistrer la présentation
    pres.save("LineSpacing_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Définir la propriété AutofitType pour TextFrame**

Dans ce sujet, nous explorerons les différentes propriétés de formatage du cadre de texte. Cet article couvre la façon de définir la propriété AutofitType du cadre de texte, l’ancrage du texte et la rotation du texte dans une présentation. Aspose.Slides for Node.js via Java permet aux développeurs de définir la propriété AutofitType de n'importe quel cadre de texte. AutofitType peut être défini sur [Normal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Normal) ou [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Shape). Si elle est définie sur [Normal], la forme reste la même tandis que le texte est ajusté sans modifier la forme ; si AutofitType est défini sur [Shape], la forme est modifiée de façon à ne contenir que le texte requis. Pour définir la propriété AutofitType d'un cadre de texte, veuillez suivre les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)class.
2. Accédez à la première diapositive.
3. Ajoutez n'importe quelle forme à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. [Définir l'AutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType-byte-) du TextFrame.
6. Enregistrez le fichier sur le disque.
```javascript
// Créer une instance de la classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Accéder à la première diapositive
    var slide = pres.getSlides().get_Item(0);
    // Ajouter une AutoShape de type Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 150);
    // Ajouter un TextFrame au Rectangle
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Accéder au TextFrame
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAutofitType(aspose.slides.TextAutofitType.Shape);
    // Créer l'objet Paragraph pour le TextFrame
    var para = txtFrame.getParagraphs().get_Item(0);
    // Créer l'objet Portion pour le paragraphe
    var portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Enregistrer la présentation
    pres.save(resourcesOutputPath + "formatText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Définir l'ancre du TextFrame**

Aspose.Slides for Node.js via Java permet aux développeurs d'ancrer n'importe quel TextFrame. TextAnchorType indique où le texte est placé dans la forme. AnchorType peut être défini sur [Top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Top), [Center](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Center), [Bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Bottom), [Justified](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Justified) ou [Distributed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Distributed). Pour définir l'ancre d'un TextFrame, veuillez suivre les étapes ci‑dessus :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Accédez à la première diapositive.
3. Ajoutez n'importe quelle forme à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. [Définir TextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAnchoringType-byte-) du TextFrame.
6. Enregistrez le fichier sur le disque.
```javascript
// Créer une instance de la classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Obtenir la première diapositive
    var slide = pres.getSlides().get_Item(0);
    // Ajouter une AutoShape de type Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // Ajouter un TextFrame au Rectangle
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Accéder au TextFrame
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAnchoringType(aspose.slides.TextAnchorType.Bottom);
    // Créer l'objet Paragraph pour le TextFrame
    var para = txtFrame.getParagraphs().get_Item(0);
    // Créer l'objet Portion pour le paragraphe
    var portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Enregistrer la présentation
    pres.save("AnchorText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Tabulations et EffectiveTabs dans la présentation**

Toutes les tabulations de texte sont données en pixels.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Figure : 2 Tabulations explicites et 2 Tabulations par défaut**|

- La propriété EffectiveTabs.ExplicitTabCount (2 dans notre cas) est égale à Tabs.Count.  
- La collection EffectiveTabs inclut toutes les tabulations (de la collection Tabs et les tabulations par défaut).  
- La propriété EffectiveTabs.ExplicitTabCount (2 dans notre cas) est égale à Tabs.Count.  
- La propriété EffectiveTabs.DefaultTabSize (294) indique la distance entre les tabulations par défaut (3 et 4 dans notre exemple).  
- EffectiveTabs.GetTabByIndex(index) avec index = 0 renvoie la première tabulation explicite (Position = 731), index = 1 la deuxième (Position = 1241). Si vous demandez l'index = 2, cela renvoie la première tabulation par défaut (Position = 1470), etc.  
- EffectiveTabs.GetTabAfterPosition(pos) sert à obtenir la prochaine tabulation après un texte. Par exemple, pour le texte « Hello World! », il faut connaître la longueur de « Hello » en pixels puis appeler GetTabAfterPosition avec cette valeur pour obtenir la position de la prochaine tabulation afin de dessiner « world! ».

## **Définir le style de texte par défaut**

Si vous devez appliquer le même formatage de texte par défaut à tous les éléments texte d'une présentation en une fois, vous pouvez utiliser la méthode `getDefaultTextStyle` de la classe [Presentation] et définir le formatage souhaité. L'exemple de code ci‑dessus montre comment définir la police en gras par défaut (14 pt) pour le texte de toutes les diapositives d'une nouvelle présentation.
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Obtenir le format de paragraphe du niveau supérieur.
    var paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);
    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    }
    presentation.save("DefaultTextStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Extraire le texte avec l'effet Tout en majuscules**

Dans PowerPoint, appliquer l'effet de police **All Caps** rend le texte affiché en majuscules sur la diapositive même s'il a été tapé initialement en minuscules. Lorsque vous récupérez une telle portion de texte avec Aspose.Slides, la bibliothèque renvoie le texte exactement tel qu'il a été saisi. Pour gérer cela, vérifiez [TextCapType] — si elle indique `All`, convertissez simplement la chaîne renvoyée en majuscules afin que votre sortie corresponde à ce que voient les utilisateurs sur la diapositive.

Supposons que nous ayons la zone de texte suivante sur la première diapositive du fichier sample2.pptx.

![The All Caps effect](all_caps_effect.png)

L'exemple de code ci‑dessus montre comment extraire le texte avec l'effet **All Caps** appliqué :
```js
var presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    var autoShape = slide.getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    var textPortion = paragraph.getPortions().get_Item(0);

    console.log("Original text:", textPortion.getText());

    var textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == aspose.slides.TextCapType.All) {
        var text = textPortion.getText().toUpperCase();
        console.log("All-Caps effect:", text);
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

Pour modifier le texte d'un tableau sur une diapositive, vous devez utiliser l'objet [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/). Vous pouvez parcourir toutes les cellules du tableau et modifier le texte de chaque cellule en accédant à ses propriétés `TextFrame` et `ParagraphFormat`.

**Comment appliquer une couleur dégradée au texte dans une diapositive PowerPoint ?**

Pour appliquer une couleur dégradée au texte, utilisez la propriété Fill Format dans [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/). Définissez le Fill Format sur `Gradient`, où vous pouvez définir les couleurs de départ et de fin du dégradé, ainsi que d'autres propriétés telles que la direction et la transparence pour créer l'effet dégradé sur le texte.