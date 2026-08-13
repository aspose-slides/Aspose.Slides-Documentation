---
title: Lettertypen beheren in presentaties met Java
linktitle: Lettertypen beheren
type: docs
weight: 10
url: /nl/java/manage-fonts/
keywords:
- lettertypen beheren
- lettertype‑eigenschappen
- paragraaf
- tekstopmaak
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Beheer lettertypen in Java met Aspose.Slides: insluiten, vervangen en aangepaste lettertypen laden om PPT-, PPTX- en ODP‑presentaties helder, merkveilig en consistent te houden."
---
## **Overzicht**

Aspose.Slides stelt je in staat om lettertype‑eigenschappen in presentatietekst rechtstreeks vanuit je code te beheren. Je kunt tekst in dia's benaderen via shapes, tekstframes, alinea’s en portions, en vervolgens de opmaak toepassen op de geselecteerde tekst.

Dit artikel legt uit hoe je lettertype‑gerelateerde eigenschappen voor bestaande tekst in een presentatie kunt configureren, inclusief lettertypefamilie, vet‑ en cursief‑stijlen, alinea‑uitlijning en letterkleur. Het laat ook zien hoe je een tekstvak maakt, er tekst aan toevoegt en lettertype‑eigenschappen zoals lettertypefamilie, vet, cursief, onderstrepen, lettergrootte en kleur instelt voordat je het resultaat opslaat als een PPTX‑bestand.

## **Beheer van lettertypegerelateerde eigenschappen**
{{% alert color="info" %}} 

Presentaties bevatten meestal zowel tekst als afbeeldingen. De tekst kan op verschillende manieren worden opgemaakt, bijvoorbeeld om specifieke secties en woorden te accentueren of om te voldoen aan de corporate‑stijl. Tekstopmaak helpt gebruikers het uiterlijk en gevoel van de presentatie‑inhoud te variëren. Dit artikel laat zien hoe je Aspose.Slides for Java gebruikt om de lettertype‑eigenschappen van alinea‑teksten op dia’s te configureren.

{{% /alert %}} 

Om de lettertype‑eigenschappen van een alinea te beheren met Aspose.Slides for Java:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation)‑klasse.
1. Verkrijg een referentie naar een dia door zijn index te gebruiken.
1. Benader de [Placeholder](https://reference.aspose.com/slides/nl/java/com.aspose.slides/placeholder/)‑shapes in de dia en cast ze naar [AutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/autoshape/).
1. Haal de [Paragraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/paragraph/) op uit het [TextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textframe/) dat wordt blootgesteld door de [AutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/autoshape/).
1. Uitvullen (justify) van de alinea.
1. Benader de tekst‑[Portion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/portion/) van een [Paragraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/paragraph/).
1. Definieer het lettertype met [FontData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontdata/) en stel de **Font** van de tekst‑[Portion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/portion/) dienovereenkomstig in.
   1. Stel het lettertype in op vet.
   1. Stel het lettertype in op cursief.
1. Stel de letterkleur in met behulp van de [FillFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fillformat/) die door het [Portion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/portion/)‑object wordt blootgesteld.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De implementatie van de bovenstaande stappen wordt hieronder gegeven. Het neemt een onbewerkte presentatie en formatteert de lettertypen op één van de dia’s. De schermafbeeldingen die volgen tonen het invoerbestand en hoe de code‑fragmenten het wijzigen. De code verandert het lettertype, de kleur en de stijl van het lettertype.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figuur: De tekst in het invoerbestand**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figuur: Dezelfde tekst met bijgewerkte opmaak**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Maak een Presentation‑object aan dat een PPTX‑bestand voorstelt
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Een dia benaderen via de positie in de presentatie
	ISlide slide = pres.getSlides().get_Item(0);

	// De eerste en tweede placeholder in de dia benaderen en casten naar AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// De eerste alinea benaderen
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// De alinea uitvullen (justify)
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// Het eerste gedeelte (portion) benaderen
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Nieuwe lettertypen definiëren
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Nieuwe lettertypen aan het gedeelte toewijzen
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Lettertype vet (bold) maken
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Lettertype cursief (italic) maken
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// Letterkleur instellen
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// De PPTX naar schijf opslaan
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Stel tekstlettertype‑eigenschappen in**
{{% alert color="info" %}} 

Zoals vermeld in **Beheer van lettertypegerelateerde eigenschappen**, wordt een [Portion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/portion/) gebruikt om tekst met een vergelijkbare opmaakstijl in een alinea vast te houden. Dit artikel toont hoe je Aspose.Slides for Java gebruikt om een tekstvak met wat tekst te maken en vervolgens een specifiek lettertype en verschillende andere eigenschappen van de lettertype‑familiecategorie te definiëren.

{{% /alert %}} 

Om een tekstvak te maken en de lettertype‑eigenschappen van de tekst erin in te stellen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation)‑klasse.
1. Verkrijg de referentie van een dia door zijn index te gebruiken.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/autoshape/) van het type **Rectangle** toe aan de dia.
1. Verwijder de opvulstijl die is verbonden met de [AutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/autoshape/).
1. Benader het [TextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textframe/) van de [AutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/autoshape/).
1. Voeg wat tekst toe aan het [TextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textframe/).
1. Benader het [Portion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/portion/)‑object dat is gekoppeld aan het [TextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textframe/).
1. Definieer het lettertype dat moet worden gebruikt voor de [Portion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/portion/).
1. Stel andere lettertype‑eigenschappen in, zoals vet, cursief, onderstrepen, kleur en hoogte, via de relevante eigenschappen die door het [Portion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/portion/)‑object worden blootgesteld.
1. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

De implementatie van de bovenstaande stappen wordt hieronder gegeven.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figuur: Tekst met enkele lettertype‑eigenschappen ingesteld door Aspose.Slides for Java**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Maak een Presentation‑object aan dat een PPTX‑bestand voorstelt
Presentation pres = new Presentation();
try {
	// Haal de eerste dia op
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Voeg een AutoShape van het type Rectangle toe
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Verwijder eventuele opvulstijl die aan de AutoShape is gekoppeld
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Benader het TextFrame dat bij de AutoShape hoort
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// Benader het Portion dat bij het TextFrame hoort
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Stel het lettertype in voor het Portion
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Stel de vet‑eigenschap van het lettertype in
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Stel de cursief‑eigenschap van het lettertype in
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Stel de onderstreping‑eigenschap van het lettertype in
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