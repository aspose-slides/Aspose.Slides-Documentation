---
title: Beheer lettertypen in presentaties op Android
linktitle: Lettertypen beheren
type: docs
weight: 10
url: /nl/androidjava/manage-fonts/
keywords:
- lettertypen beheren
- lettertype-eigenschappen
- alinea
- tekstopmaak
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Beheer lettertypen in Java met Aspose.Slides for Android: voeg in, vervang en laad aangepaste lettertypen om PPT, PPTX en ODP-presentaties duidelijk, merksveilig en consistent te houden."
---
## **Overzicht**

Aspose.Slides stelt u in staat om lettertype‑eigenschappen in de presentatie‑tekst rechtstreeks vanuit uw code te beheren. U kunt de tekst in dia's benaderen via vormen, tekstkaders, alinea's en porties, en vervolgens opmaak toepassen op de geselecteerde tekst.

In dit artikel wordt uitgelegd hoe u lettertype‑gerelateerde eigenschappen voor bestaande tekst in een presentatie kunt configureren, waaronder lettertypefamilie, vet‑ en cursief stijlen, alinea‑uitlijning en letterkleur. Het laat ook zien hoe u een tekstvak maakt, er tekst aan toevoegt en lettertype‑eigenschappen zoals lettertypefamilie, vet, cursief, onderstrepen, lettergrootte en kleur instelt voordat u het resultaat opslaat als een PPTX‑bestand.

## **Lettertype‑gerelateerde eigenschappen beheren**
{{% alert color="primary" %}} 

Presentaties bevatten doorgaans zowel tekst als afbeeldingen. De tekst kan op verschillende manieren worden opgemaakt, bijvoorbeeld om specifieke secties en woorden te accentueren of om te voldoen aan bedrijfsstijlen. Tekstopmaak helpt gebruikers het uiterlijk en de uitstraling van de presentatie‑inhoud te variëren. In dit artikel wordt getoond hoe u Aspose.Slides for Android via Java gebruikt om de lettertype‑eigenschappen van tekstalinea's op dia's te configureren.

{{% /alert %}} 

Om lettertype‑eigenschappen van een alinea te beheren met Aspose.Slides for Android via Java:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation) klasse aan.
1. Verkrijg een referentie naar een dia door zijn index te gebruiken.
1. Benader de [Placeholder](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/placeholder/) vormen in de dia en cast ze naar [AutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/autoshape/).
1. Haal de [Paragraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/paragraph/) op uit het [TextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textframe/) dat wordt blootgesteld door [AutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/autoshape/).
1. Stel de alinea uitlijnen in op justification.
1. Benader de tekst [Portion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/portion/) van een [Paragraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/paragraph/).
1. Definieer het lettertype met [FontData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontdata/) en stel de **Font** van de tekst [Portion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/portion/) overeenkomstig in.
   1. Stel het lettertype in op vet.
   1. Stel het lettertype in op cursief.
1. Stel de letterkleur in met behulp van de [FillFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fillformat/) die wordt blootgesteld door het [Portion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/portion/) object.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De implementatie van de bovenstaande stappen wordt hieronder gegeven. Het neemt een onbewerkte presentatie en formatteert de lettertypen op een van de dia's. De volgende screenshots tonen het invoerbestand en hoe de codefragmenten dit wijzigen. De code wijzigt het lettertype, de kleur en de stijl van het lettertype.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figuur: De tekst in het invoerbestand**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figuur: Dezelfde tekst met bijgewerkte opmaak**|

```java
// Maak een Presentation‑object aan dat een PPTX‑bestand representeert
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Toegang tot een dia via zijn positie
	ISlide slide = pres.getSlides().get_Item(0);

	// Toegang tot de eerste en tweede placeholder in de dia en casten naar AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// Toegang tot de eerste alinea
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// Stel de alinea uitlijnen in (justify)
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// Toegang tot de eerste portie
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Definieer nieuwe lettertypen
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Ken nieuwe lettertypen toe aan de portie
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Zet het lettertype op vet
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Zet het lettertype op cursief
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// Stel de letterkleur in
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// Sla het PPTX‑bestand op naar schijf
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Tekstlettertype‑eigenschappen instellen**
{{% alert color="primary" %}} 

Zoals vermeld in **Lettertype‑gerelateerde eigenschappen beheren**, wordt een [Portion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/portion/) gebruikt om tekst met een vergelijkbare opmaakstijl in een alinea vast te houden. In dit artikel wordt getoond hoe u Aspose.Slides for Android via Java gebruikt om een tekstvak met enige tekst te maken en vervolgens een specifiek lettertype en verschillende andere eigenschappen van de lettertypefamilie te definiëren.

{{% /alert %}} 

Om een tekstvak te maken en lettertype‑eigenschappen van de tekst erin in te stellen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation) klasse aan.
1. Verkrijg de referentie van een dia door zijn index te gebruiken.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/autoshape/) van het type **Rectangle** toe aan de dia.
1. Verwijder de vulstijl die gekoppeld is aan de [AutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/autoshape/).
1. Benader het [TextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textframe/) van de [AutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/autoshape/).
1. Voeg enige tekst toe aan het [TextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textframe/).
1. Benader het [Portion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/portion/) object dat is gekoppeld aan het [TextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textframe/).
1. Definieer het lettertype dat voor de [Portion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/portion/) moet worden gebruikt.
1. Stel andere lettertype‑eigenschappen in, zoals vet, cursief, onderstrepen, kleur en grootte, met behulp van de relevante eigenschappen die door het [Portion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/portion/) object worden blootgesteld.
1. Schrijf de aangepaste presentatie naar een PPTX‑bestand.

De implementatie van de bovenstaande stappen wordt hieronder gegeven.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figuur: Tekst met enkele lettertype‑eigenschappen ingesteld door Aspose.Slides for Android via Java**|

```java
// Maak een Presentation‑object aan dat een PPTX‑bestand representeert
Presentation pres = new Presentation();
try {
	// Haal de eerste dia op
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Voeg een AutoShape van het type Rectangle toe
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Verwijder eventuele vulstijl die aan de AutoShape gekoppeld is
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Benader het TextFrame dat aan de AutoShape is gekoppeld
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// Benader de Portion die aan het TextFrame is gekoppeld
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Stel het lettertype in voor de Portion
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Stel de vet‑eigenschap van het lettertype in
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Stel de cursief‑eigenschap van het lettertype in
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Stel de onderstrepen‑eigenschap van het lettertype in
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Stel de hoogte van het lettertype in
	port.getPortionFormat().setFontHeight(25);
	
	// Stel de kleur van het lettertype in
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// Sla de presentatie op naar schijf
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```
