---
title: Formater le texte PowerPoint en JavaScript
linktitle: Mise en forme du texte
type: docs
weight: 50
url: /fr/nodejs-java/text-formatting/
keywords:
- surligner le texte
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
- ancre du cadre de texte
- tabulation du texte
- langue par défaut
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Formatez et stylisez le texte dans les présentations PowerPoint et OpenDocument en utilisant JavaScript et Aspose.Slides pour Node.js. Personnalisez les polices, les couleurs, l'alignement et plus encore."
---

## **Surligner le texte**

La méthode [highlightText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#highlightText-java.lang.String-java.awt.Color-) a été ajoutée à la classe [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) et à la classe [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame).

Elle permet de surligner une partie du texte avec une couleur de fond en utilisant un échantillon de texte, similaire à l'outil de couleur de surbrillance du texte dans PowerPoint 2019.

L'extrait de code ci-dessous montre comment utiliser cette fonctionnalité :
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var textHighlightingOptions = new aspose.slides.TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightText("title", java.getStaticFieldValue("java.awt.Color", "BLUE"));// mise en surbrillance de tous les mots 'important'
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightText("to", java.getStaticFieldValue("java.awt.Color", "MAGENTA"), textHighlightingOptions);// mise en surbrillance de toutes les occurrences séparées de 'the'
    pres.save("OutputPresentation-highlight.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 
Aspose propose un service simple d'[édition en ligne gratuite de PowerPoint](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **Surligner le texte à l'aide d'une expression régulière**

La méthode [highlightRegex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#highlightRegex-java.lang.String-java.awt.Color-aspose.slides.ITextHighlightingOptions-) a été ajoutée à la classe [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) et à la classe [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame).

Elle permet de surligner une partie du texte avec une couleur de fond en utilisant une expression régulière, similaire à l'outil de couleur de surbrillance du texte dans PowerPoint 2019.

L'extrait de code ci-dessous montre comment utiliser cette fonctionnalité :
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var options = new aspose.slides.TextHighlightingOptions();
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.getStaticFieldValue("java.awt.Color", "YELLOW"), options);// mise en surbrillance de tous les mots de 10 caractères ou plus
    pres.save("OutputPresentation-highlight.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Définir la couleur d'arrière-plan du texte**

Aspose.Slides vous permet de spécifier la couleur de votre choix pour l'arrière‑plan d'un texte.

Ce code JavaScript montre comment définir la couleur d'arrière‑plan pour un texte entier :
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


Ce code JavaScript montre comment définir la couleur d'arrière‑plan pour seulement une partie d'un texte :
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

Le formatage du texte est l'un des éléments clés lors de la création de tout type de document ou de présentation. Nous savons qu'Aspose.Slides for Node.js via Java prend en charge l'ajout de texte aux diapositives, mais dans ce sujet, nous verrons comment contrôler l'alignement des paragraphes de texte dans une diapositive. Veuillez suivre les étapes ci-dessous pour aligner les paragraphes de texte à l'aide d'Aspose.Slides for Node.js via Java :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenir la référence d'une diapositive en utilisant son index.
3. Accéder aux formes Placeholder présentes dans la diapositive et les convertir en [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
4. Obtenir le paragraphe (à aligner) depuis le [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#getTextFrame--) exposé par [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. Aligner le paragraphe. Un paragraphe peut être aligné à droite, à gauche, au centre ou justifié.
6. Enregistrer la présentation modifiée en tant que fichier PPTX.

L'implémentation des étapes ci‑dessus est fournie ci‑dessous.
```javascript
// Instancier un objet Presentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation("ParagraphsAlignment.pptx");
try {
    // Accéder à la première diapositive
    var slide = pres.getSlides().get_Item(0);
    // Accéder au premier et au deuxième espace réservé dans la diapositive et le convertir en AutoShape
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
    // Enregistrer la présentation sous forme de fichier PPTX
    pres.save("Centeralign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Définir la transparence du texte**

Cet article montre comment définir la propriété de transparence sur n'importe quelle forme de texte en utilisant Aspose.Slides for Node.js via Java. Pour définir la transparence du texte, veuillez suivre les étapes ci‑dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenir la référence d'une diapositive.
3. Définir la couleur de l'ombre
4. Enregistrer la présentation en tant que fichier PPTX.
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

Aspose.Slides vous permet de définir l'espace entre les lettres dans une zone de texte. Ainsi, vous pouvez ajuster la densité visuelle d'une ligne ou d'un bloc de texte en augmentant ou en réduisant l'espacement entre les caractères.

Ce code JavaScript montre comment élargir l'espacement pour une ligne de texte et réduire l'espacement pour une autre ligne :
```javascript
var presentation = new aspose.slides.Presentation("in.pptx");
var textBox1 = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var textBox2 = presentation.getSlides().get_Item(0).getShapes().get_Item(1);
textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20);// élargir
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2);// condenser
presentation.save("out.pptx", aspose.slides.SaveFormat.Pptx);
```


## **Gérer les propriétés de police d'un paragraphe**

Les présentations contiennent généralement à la fois du texte et des images. Le texte peut être formaté de différentes manières, soit pour mettre en évidence des sections et des mots spécifiques, soit pour se conformer aux styles d'entreprise. Le formatage du texte aide les utilisateurs à varier l'apparence du contenu de la présentation.

Cet article montre comment utiliser Aspose.Slides for Node.js via Java pour configurer les propriétés de police des paragraphes de texte sur les diapositives.

Pour gérer les propriétés de police d'un paragraphe à l'aide d'Aspose.Slides for Node.js via Java :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenir la référence d'une diapositive en utilisant son index.
3. Accéder aux formes Placeholder dans la diapositive et les convertir en [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
4. Obtenir le [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) depuis le [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) exposé par [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. Justifier le paragraphe.
6. Accéder à la portion de texte d'un paragraphe.
7. Définir la police à l'aide de FontData et définir la police de la portion de texte en conséquence.
   - Mettre la police en gras.
   - Mettre la police en italique.
8. Définir la couleur de la police en utilisant la méthode [getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BasePortionFormat#getFillFormat--) exposée par l'objet [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion).
9. Enregistrer la présentation modifiée dans un fichier [PPTX](https://docs.fileformat.com/presentation/pptx/).

L'implémentation des étapes ci‑dessus est donnée ci‑dessous. Elle prend une présentation non modifiée et formate les polices sur l'une des diapositives.
```javascript
// Instancier un objet Presentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation("FontProperties.pptx");
try {
    // Accéder à une diapositive en utilisant sa position
    var slide = pres.getSlides().get_Item(0);
    // Accéder au premier et au deuxième espace réservé dans la diapositive et le convertir en AutoShape
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
    // Attribuer les nouvelles polices à la portion
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
    // Enregistrer le PPTX sur le disque
    pres.save("WelcomeFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Gérer la famille de polices du texte**

Une portion est utilisée pour contenir du texte avec un style de formatage similaire dans un paragraphe. Cet article montre comment utiliser Aspose.Slides for Node.js via Java pour créer une zone de texte contenant du texte, puis définir une police particulière ainsi que diverses autres propriétés de la catégorie de famille de polices.

Pour créer une zone de texte et définir les propriétés de police du texte qu'elle contient :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenir la référence d'une diapositive en utilisant son index.
3. Ajouter un [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) de type [Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType#Rectangle) à la diapositive.
4. Supprimer le style de remplissage associé au [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. Accéder au TextFrame du AutoShape.
6. Ajouter du texte au TextFrame.
7. Accéder à l'objet Portion associé au [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
8. Définir la police à utiliser pour la [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion).
9. Définir d'autres propriétés de police comme gras, italique, souligné, couleur et taille en utilisant les propriétés pertinentes exposées par l'objet Portion.
10. Enregistrer la présentation modifiée en tant que fichier PPTX.
```javascript
// Instancier la présentation
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
    // Écrire le PPTX sur le disque
    pres.save("SetTextFontProperties_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Définir la taille de police du texte**

Aspose.Slides vous permet de choisir la taille de police souhaitée pour le texte existant dans un paragraphe ainsi que pour d'autres textes qui pourraient être ajoutés ultérieurement au paragraphe.

Ce code JavaScript montre comment définir la taille de police pour les textes contenus dans un paragraphe :
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

Aspose.Slides for Node.js via Java permet aux développeurs de faire pivoter le texte. Le texte peut être affiché comme [Horizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Horizontal), [Vertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Vertical), [Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Vertical270), [WordArtVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#WordArtVertical), [EastAsianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#EastAsianVertical), [MongolianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#MongolianVertical) ou [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#WordArtVerticalRightToLeft).

Pour faire pivoter le texte de n'importe quel TextFrame, veuillez suivre les étapes ci‑dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Accéder à la première diapositive.
3. Ajouter n'importe quelle forme à la diapositive.
4. Accéder au [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. [Rotate the text](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setTextVerticalType-byte-).
6. Enregistrer le fichier sur le disque.
```javascript
// Créer une instance de la classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Obtenir la première diapositive
    var slide = pres.getSlides().get_Item(0);
    // Ajouter une AutoShape de type Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // Ajouter un TextFrame au rectangle
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Accéder au cadre de texte
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(aspose.slides.TextVerticalType.Vertical270);
    // Créer l'objet Paragraph pour le cadre de texte
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

Aspose.Slides for Node.js via Java prend désormais en charge la définition d'un angle de rotation personnalisé pour TextFrame. Dans ce sujet, nous verrons, à l'aide d'un exemple, comment définir la propriété RotationAngle dans Aspose.Slides. Les nouvelles méthodes [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setRotationAngle-float-) et [getRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#getRotationAngle--) ont été ajoutées à la classe [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) permettant de définir un angle de rotation personnalisé pour TextFrame. Pour définir RotationAngle, veuillez suivre les étapes ci‑dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Ajouter un graphique sur la diapositive.
3. [Set RotationAngle property](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setRotationAngle-float-).
4. Enregistrer la présentation en tant que fichier PPTX.

Dans l'exemple ci‑dessous, nous définissons la propriété RotationAngle.
```javascript
// Créer une instance de la classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Obtenir la première diapositive
    var slide = pres.getSlides().get_Item(0);
    // Ajouter une AutoShape de type Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // Ajouter un TextFrame au rectangle
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Accéder au cadre de texte
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);
    // Créer l'objet Paragraph pour le cadre de texte
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


## **Interligne d'un paragraphe**

Les propriétés sous [`ParagraphFormat`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ParagraphFormat)—`SpaceAfter`, `SpaceBefore` et `SpaceWithin`—permettent de gérer l'interligne d'un paragraphe. Les trois propriétés sont utilisées ainsi :

* Pour spécifier l'interligne d'un paragraphe en pourcentage, utilisez une valeur positive. 
* Pour spécifier l'interligne d'un paragraphe en points, utilisez une valeur négative.

Par exemple, vous pouvez appliquer un interligne de 16 pt à un paragraphe en définissant la propriété `SpaceBefore` à -16.

Voici comment spécifier l'interligne pour un paragraphe spécifique :

1. Charger une présentation contenant un AutoShape avec du texte.
2. Obtenir la référence d'une diapositive via son index.
3. Accéder au TextFrame.
4. Accéder au Paragraph.
5. Définir les propriétés du Paragraph.
6. Enregistrer la présentation.

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

Dans ce sujet, nous explorerons les différentes propriétés de formatage d'un cadre de texte. Cet article explique comment définir la propriété AutofitType d'un cadre de texte, l'ancrage du texte et la rotation du texte dans une présentation. Aspose.Slides for Node.js via Java permet aux développeurs de définir la propriété AutofitType de n'importe quel cadre de texte. AutofitType peut être défini sur [Normal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Normal) ou [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Shape). Si elle est définie sur [Normal], la forme reste inchangée tandis que le texte est ajusté sans modifier la forme ; si AutofitType est définie sur [Shape], la forme est modifiée de façon à ne contenir que le texte requis. Pour définir la propriété AutofitType d'un cadre de texte, veuillez suivre les étapes ci‑dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Accéder à la première diapositive.
3. Ajouter n'importe quelle forme à la diapositive.
4. Accéder au [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. [Set the AutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType-byte-).
6. Enregistrer le fichier sur le disque.
```javascript
// Créer une instance de la classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Accéder à la première diapositive
    var slide = pres.getSlides().get_Item(0);
    // Ajouter une AutoShape de type Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 150);
    // Ajouter un TextFrame au rectangle
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Accéder au cadre de texte
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAutofitType(aspose.slides.TextAutofitType.Shape);
    // Créer l'objet Paragraph pour le cadre de texte
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


## **Définir l'ancre de TextFrame**

Aspose.Slides for Node.js via Java permet aux développeurs d'ancrer n'importe quel TextFrame. TextAnchorType indique où le texte est placé dans la forme. L'ancre peut être définie sur [Top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Top), [Center](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Center), [Bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Bottom), [Justified](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Justified) ou [Distributed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Distributed). Pour définir l'ancre d'un TextFrame, veuillez suivre les étapes ci‑dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Accéder à la première diapositive.
3. Ajouter n'importe quelle forme à la diapositive.
4. Accéder au [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. [Set TextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAnchoringType-byte-).
6. Enregistrer le fichier sur le disque.
```javascript
    // Créer une instance de la classe Presentation
    var pres = new aspose.slides.Presentation();
    try {
        // Obtenir la première diapositive
        var slide = pres.getSlides().get_Item(0);
        // Ajouter une AutoShape de type Rectangle
        var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
        // Ajouter un TextFrame au rectangle
        ashp.addTextFrame("");
        ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        // Accéder au cadre de texte
        var txtFrame = ashp.getTextFrame();
        txtFrame.getTextFrameFormat().setAnchoringType(aspose.slides.TextAnchorType.Bottom);
        // Créer l'objet Paragraph pour le cadre de texte
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

Toutes les tabulations de texte sont exprimées en pixels.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Figure : 2 Tabulations explicites et 2 Tabulations par défaut**|

- La propriété EffectiveTabs.ExplicitTabCount (2 dans notre cas) est égale à Tabs.Count.  
- La collection EffectiveTabs comprend toutes les tabulations (provenant de la collection Tabs et des tabulations par défaut).  
- La propriété EffectiveTabs.ExplicitTabCount (2 dans notre cas) est égale à Tabs.Count.  
- La propriété EffectiveTabs.DefaultTabSize (294) indique la distance entre les tabulations par défaut (3 et 4 dans notre exemple).  
- EffectiveTabs.GetTabByIndex(index) avec index = 0 renvoie la première tabulation explicite (Position = 731), index = 1 la deuxième (Position = 1241). Si vous demandez l’index = 2, cela renvoie la première tabulation par défaut (Position = 1470), etc.  
- EffectiveTabs.GetTabAfterPosition(pos) est utilisé pour obtenir la tabulation suivante après un texte. Par exemple, vous avez le texte : « Hello World! ». Pour rendre ce texte, vous devez savoir où commencer à dessiner « world! ». D'abord, calculez la longueur de « Hello » en pixels puis appelez GetTabAfterPosition avec cette valeur. Vous obtiendrez la prochaine position de tabulation pour dessiner « world! ».

## **Définir le style de texte par défaut**

Si vous devez appliquer le même formatage de texte par défaut à tous les éléments de texte d'une présentation en une fois, vous pouvez utiliser la méthode `getDefaultTextStyle` de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) et définir le formatage préféré. L'exemple de code ci‑dessous montre comment définir la police en gras par défaut (14 pt) pour le texte sur toutes les diapositives d'une nouvelle présentation.
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Obtenir le format de paragraphe de niveau supérieur.
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

Dans PowerPoint, l'application de l'effet de police **All Caps** fait apparaître le texte en majuscules sur la diapositive même s'il a été tapé initialement en minuscules. Lors de la récupération de cette portion de texte avec Aspose.Slides, la bibliothèque renvoie le texte exactement tel qu'il a été saisi. Pour gérer cela, vérifiez [TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/) — si elle indique `All`, convertissez simplement la chaîne renvoyée en majuscules afin que votre sortie corresponde à ce que les utilisateurs voient sur la diapositive.

Imaginons que nous ayons la zone de texte suivante sur la première diapositive du fichier sample2.pptx.

![The All Caps effect](all_caps_effect.png)

L'exemple de code ci‑dessous montre comment extraire le texte avec l'effet **All Caps** appliqué :
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


Résultat :
```text
Texte original: Hello, Aspose!
Effet tout en majuscules: HELLO, ASPOSE!
```


## **FAQ**

**Comment modifier le texte dans un tableau sur une diapositive ?**

Pour modifier le texte dans un tableau sur une diapositive, vous devez utiliser l'objet [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/). Vous pouvez parcourir toutes les cellules du tableau et modifier le texte de chaque cellule en accédant à ses propriétés `TextFrame` et `ParagraphFormat` à l'intérieur de chaque cellule.

**Comment appliquer un dégradé de couleur au texte dans une diapositive PowerPoint ?**

Pour appliquer un dégradé de couleur au texte, utilisez la propriété Fill Format dans [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/). Définissez le Fill Format sur `Gradient`, où vous pouvez définir les couleurs de début et de fin du dégradé, ainsi que d'autres propriétés telles que la direction et la transparence pour créer l'effet de dégradé sur le texte.