---
title: Gérer les polices dans les présentations avec Java
linktitle: Gérer les polices
type: docs
weight: 10
url: /fr/java/manage-fonts/
keywords:
- gérer les polices
- propriétés de police
- paragraphe
- formatage du texte
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Contrôlez les polices en Java avec Aspose.Slides : intégrez, substituez et chargez des polices personnalisées pour que les présentations PPT, PPTX et ODP restent claires, conformes à la marque et cohérentes."
---
## **Vue d'ensemble**

Aspose.Slides vous permet de gérer les propriétés de police du texte d’une présentation directement depuis votre code. Vous pouvez accéder au texte des diapositives via les formes, les cadres de texte, les paragraphes et les portions, puis appliquer le formatage au texte sélectionné.

Cet article explique comment configurer les propriétés liées à la police pour du texte existant dans une présentation, notamment la famille de police, le gras et l’italique, l’alignement des paragraphes et la couleur de la police. Il montre également comment créer une zone de texte, y ajouter du texte et définir les propriétés de police telles que la famille, le gras, l’italique, le soulignement, la taille et la couleur avant d’enregistrer le résultat au format PPTX.

## **Gérer les propriétés liées à la police**
{{% alert color="info" %}} 

Les présentations contiennent généralement du texte et des images. Le texte peut être formaté de différentes manières, soit pour mettre en évidence des sections et des mots spécifiques, soit pour se conformer aux styles d’entreprise. Le formatage du texte aide les utilisateurs à varier l’aspect du contenu de la présentation. Cet article montre comment utiliser Aspose.Slides for Java pour configurer les propriétés de police des paragraphes de texte sur les diapositives.

{{% /alert %}} 

Pour gérer les propriétés de police d’un paragraphe avec Aspose.Slides for Java :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation).
1. Obtenez la référence d’une diapositive en utilisant son index.
1. Accédez aux formes [Placeholder](https://reference.aspose.com/slides/fr/java/com.aspose.slides/placeholder/) de la diapositive et convertissez‑les en [AutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/autoshape/).
1. Récupérez le [Paragraph](https://reference.aspose.com/slides/fr/java/com.aspose.slides/paragraph/) à partir du [TextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/textframe/) exposé par l’[AutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/autoshape/).
1. Justifiez le paragraphe.
1. Accédez au texte du [Paragraph](https://reference.aspose.com/slides/fr/java/com.aspose.slides/paragraph/) via la [Portion](https://reference.aspose.com/slides/fr/java/com.aspose.slides/portion/).
1. Définissez la police avec [FontData](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fontdata/) et affectez le **Font** de la [Portion](https://reference.aspose.com/slides/fr/java/com.aspose.slides/portion/) en conséquence.
   1. Mettez la police en gras.
   1. Mettez la police en italique.
1. Appliquez la couleur de la police à l’aide du [FillFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fillformat/) exposé par l’objet [Portion](https://reference.aspose.com/slides/fr/java/com.aspose.slides/portion/).
1. Enregistrez la présentation modifiée au format PPTX.

L’implémentation des étapes ci‑dessus est présentée ci‑après. Elle prend une présentation non modifiée et formate les polices sur l’une des diapositives. Les captures d’écran suivantes montrent le fichier d’entrée et la façon dont les extraits de code le modifient. Le code modifie la police, la couleur et le style de la police.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figure : Le texte dans le fichier d’entrée**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figure : Le même texte avec le formatage mis à jour**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanciez un objet Presentation qui représente un fichier PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Accéder à une diapositive en utilisant sa position
	ISlide slide = pres.getSlides().get_Item(0);

	// Accéder aux premier et deuxième espaces réservés dans la diapositive et les convertir en AutoShape
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

	// Définir de nouvelles polices
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Attribuer les nouvelles polices à la portion
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
{{% alert color="info" %}} 

Comme indiqué dans **Gestion des propriétés liées à la police**, une [Portion](https://reference.aspose.com/slides/fr/java/com.aspose.slides/portion/) est utilisée pour contenir du texte avec un style de formatage similaire dans un paragraphe. Cet article montre comment utiliser Aspose.Slides for Java pour créer une zone de texte contenant du texte, puis définir une police particulière ainsi que diverses autres propriétés de la catégorie de famille de police.

{{% /alert %}} 

Pour créer une zone de texte et définir les propriétés de police du texte qu’elle contient :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation).
1. Obtenez la référence d’une diapositive en utilisant son index.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/autoshape/) de type **Rectangle** à la diapositive.
1. Supprimez le style de remplissage associé à l’[AutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/autoshape/).
1. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/textframe/) de l’[AutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/autoshape/).
1. Ajoutez du texte au [TextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/textframe/).
1. Accédez à l’objet [Portion](https://reference.aspose.com/slides/fr/java/com.aspose.slides/portion/) associé au [TextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/textframe/).
1. Définissez la police à utiliser pour la [Portion](https://reference.aspose.com/slides/fr/java/com.aspose.slides/portion/).
1. Définissez d’autres propriétés de police telles que le gras, l’italique, le soulignement, la couleur et la taille à l’aide des propriétés correspondantes exposées par l’objet [Portion](https://reference.aspose.com/slides/fr/java/com.aspose.slides/portion/).
1. Enregistrez la présentation modifiée au format PPTX.

L’implémentation des étapes ci‑dessus est présentée ci‑après.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figure : Texte avec certaines propriétés de police définies par Aspose.Slides for Java**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanciez un objet Presentation qui représente un fichier PPTX
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
	
	// Définir la propriété Soulignement de la police
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Définir la taille de la police
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