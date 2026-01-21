---
title: Gérer les polices dans les présentations avec Java
linktitle: Gestion des polices
type: docs
weight: 10
url: /fr/java/manage-fonts/
keywords:
- gérer les polices
- propriétés des polices
- paragraphe
- mise en forme du texte
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Contrôlez les polices en Java avec Aspose.Slides: intégrez, remplacez et chargez des polices personnalisées pour que les présentations PPT, PPTX et ODP restent claires, conformes à la marque et cohérentes."
---

## **Gérer les propriétés liées aux polices**
{{% alert color="primary" %}} 

Les présentations contiennent généralement à la fois du texte et des images. Le texte peut être formaté de diverses manières, soit pour mettre en évidence des sections et des mots spécifiques, soit pour se conformer aux styles d’entreprise. Le formatage du texte aide les utilisateurs à varier l’aspect du contenu de la présentation. Cet article montre comment utiliser Aspose.Slides for Java pour configurer les propriétés de police des paragraphes de texte sur les diapositives.

{{% /alert %}} 

Pour gérer les propriétés de police d’un paragraphe à l’aide d’Aspose.Slides for Java :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
2. Obtenir la référence d’une diapositive en utilisant son index.
3. Accéder aux formes [Placeholder](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) de la diapositive et les convertir en [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/).
4. Obtenir le [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) depuis le [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) exposé par [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/).
5. Justifier le paragraphe.
6. Accéder à la [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) de texte d’un [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/).
7. Définir la police à l’aide de [FontData](https://reference.aspose.com/slides/java/com.aspose.slides/fontdata/) et définir la **Font** de la [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) de texte en conséquence.
   1. Mettre la police en gras.
   2. Mettre la police en italique.
8. Définir la couleur de la police en utilisant le [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/) exposé par l’objet [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/).
9. Enregistrer la présentation modifiée dans un fichier PPTX.

L’implémentation des étapes ci‑dessus est fournie ci‑dessous. Elle prend une présentation non modifiée et formate les polices sur l’une des diapositives. Les captures d’écran suivantes montrent le fichier d’entrée et la façon dont les extraits de code le modifient. Le code modifie la police, la couleur et le style de la police.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figure : Le texte dans le fichier d'entrée**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figure : Le même texte avec un formatage mis à jour**|
```java
// Instancier un objet Presentation qui représente un fichier PPTX
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

Comme indiqué dans **Gérer les propriétés liées aux polices**, une [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) est utilisée pour contenir du texte avec un style de formatage similaire dans un paragraphe. Cet article montre comment utiliser Aspose.Slides for Java pour créer une zone de texte contenant du texte, puis définir une police particulière ainsi que diverses autres propriétés de la catégorie de famille de police.

{{% /alert %}} 

Pour créer une zone de texte et définir les propriétés de police du texte qu’elle contient :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
2. Obtenir la référence d’une diapositive en utilisant son index.
3. Ajouter un [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/) du type **Rectangle** à la diapositive.
4. Supprimer le style de remplissage associé à l’[AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/).
5. Accéder au [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) de l’[AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/).
6. Ajouter du texte au [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/).
7. Accéder à l’objet [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) associé au [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/).
8. Définir la police à utiliser pour la [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/).
9. Définir d’autres propriétés de police telles que gras, italique, souligné, couleur et hauteur en utilisant les propriétés pertinentes exposées par l’objet [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/).
10. Enregistrer la présentation modifiée dans un fichier PPTX.

L’implémentation des étapes ci‑dessus est fournie ci‑dessous.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figure : Texte avec certaines propriétés de police définies par Aspose.Slides for Java**|
```java
// Instancier un objet Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
	// Récupérer la première diapositive
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
	
	// Enregistrer la présentation sur le disque
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```
