---
title: Gérer les polices - API Java PowerPoint
linktitle: Gérer les polices
type: docs
weight: 10
url: /fr/java/manage-fonts/
description: Les présentations contiennent généralement à la fois du texte et des images. Cet article montre comment utiliser l'API Java PowerPoint pour configurer les propriétés de police des paragraphes de texte sur les diapositives.
---

## **Gérer les propriétés liées aux polices**
{{% alert color="primary" %}} 

Les présentations contiennent généralement à la fois du texte et des images. Le texte peut être formaté de diverses manières, soit pour mettre en évidence des sections et des mots spécifiques, soit pour se conformer aux styles d'entreprise. La mise en forme du texte aide les utilisateurs à varier l'apparence et la sensation du contenu de la présentation. Cet article montre comment utiliser Aspose.Slides pour Java pour configurer les propriétés de police des paragraphes de texte sur les diapositives.

{{% /alert %}} 

Pour gérer les propriétés de police d'un paragraphe à l'aide d'Aspose.Slides pour Java :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Obtenez une référence à la diapositive en utilisant son index.
1. Accédez aux formes [Placeholder](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Placeholder) dans la diapositive et convertissez-les en [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape).
1. Obtenez le [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Paragraph) du [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame) exposé par [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape).
1. Justifiez le paragraphe.
1. Accédez au texte [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion) d'un [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Paragraph).
1. Définissez la police à l'aide de [FontData](https://reference.aspose.com/slides/java/com.aspose.slides/classes/FontData) et définissez la **Font** de la [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion) en conséquence.
   1. Réglez la police en gras.
   1. Réglez la police en italique.
1. Définissez la couleur de la police en utilisant le [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/classes/FillFormat) exposé par l'objet [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion).
1. Enregistrez la présentation modifiée dans un fichier PPTX.

L'implémentation des étapes ci-dessus est donnée ci-dessous. Elle prend une présentation simple et formate les polices sur l'une des diapositives. Les captures d'écran qui suivent montrent le fichier d'entrée et comment les extraits de code le modifient. Le code change la police, la couleur et le style de police.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figure : Le texte dans le fichier d'entrée**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figure : Le même texte avec une mise en forme mise à jour**|

```java
// Instancier un objet Presentation qui représente un fichier PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Accéder à une diapositive en utilisant sa position de diapositive
	ISlide slide = pres.getSlides().get_Item(0);

	// Accéder au premier et au deuxième espace réservé dans la diapositive et le convertir en AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// Accéder au premier paragraphe
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// Justifier le paragraphe
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// Accéder à la première portion
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Définir les nouvelles polices
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Attribuer de nouvelles polices à la portion
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
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// Enregistrer le PPTX sur le disque
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Définir les propriétés de police du texte**
{{% alert color="primary" %}} 

Comme mentionné dans **Gérer les propriétés liées aux polices**, une [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion) est utilisée pour contenir du texte avec un style de formatage similaire dans un paragraphe. Cet article montre comment utiliser Aspose.Slides pour Java pour créer une zone de texte avec du texte, puis définir une police particulière et diverses autres propriétés de la famille de polices.

{{% /alert %}} 

Pour créer une zone de texte et définir les propriétés de police du texte qui s'y trouve :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Obtenez la référence d'une diapositive en utilisant son index.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape) de type **Rectangle** à la diapositive.
1. Supprimez le style de remplissage associé à l'[AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape).
1. Accédez au [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame) associé à l'[AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape).
1. Ajoutez du texte au [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame).
1. Accédez à l'objet [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion) associé au [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame).
1. Définissez la police à utiliser pour le [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion).
1. Définissez d'autres propriétés de police comme le gras, l'italique, le soulignement, la couleur et la taille en utilisant les propriétés pertinentes exposées par l'objet [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion).
1. Écrivez la présentation modifiée en tant que fichier PPTX.

L'implémentation des étapes ci-dessus est donnée ci-dessous.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figure : Texte avec certaines propriétés de police définies par Aspose.Slides pour Java**|

```java
// Instancier un objet Presentation qui représente un fichier PPTX
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
	
	// Définir la propriété Soulignée de la police
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Définir la hauteur de la police
	port.getPortionFormat().setFontHeight(25);
	
	// Définir la couleur de la police
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// Enregistrer la présentation sur le disque
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```