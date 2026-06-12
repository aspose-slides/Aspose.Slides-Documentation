---
title: Beheer lettertypen in presentaties met Java
linktitle: Beheer lettertypen
type: docs
weight: 10
url: /nl/java/manage-fonts/
keywords:
- lettertypen beheren
- lettertype-eigenschappen
- alinea
- tekstopmaak
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Beheer lettertypen in Java met Aspose.Slides: integreer, vervang en laad aangepaste lettertypen om PPT, PPTX en ODP‑presentaties duidelijk, merkveilig en consistent te houden."
---
## **Overzicht**

Aspose.Slides stelt u in staat om lettertype‑eigenschappen in presentatietekst rechtstreeks vanuit uw code te beheren. U kunt tekst in dia’s benaderen via vormen, tekstkaders, alinea’s en gedeelten, en vervolgens opmaak toepassen op de geselecteerde tekst.

Dit artikel legt uit hoe u font‑gerelateerde eigenschappen voor bestaande tekst in een presentatie kunt configureren, inclusief lettertypefamilie, vet‑ en cursief‑stijlen, alinea‑uitlijning en letterkleur. Het toont ook hoe u een tekstvak maakt, er tekst aan toevoegt en lettertype‑eigenschappen zoals lettertypefamilie, vet, cursief, onderstrepen, grootte en kleur instelt voordat u het resultaat opslaat als een PPTX‑bestand.

## **Lettertype‑gerelateerde eigenschappen beheren**
{{% alert color="primary" %}} 

Presentaties bevatten doorgaans zowel tekst als afbeeldingen. Tekst kan op verschillende manieren worden opgemaakt, bijvoorbeeld om specifieke secties en woorden te benadrukken of om te voldoen aan bedrijfsstijlen. Tekstopmaak helpt gebruikers om de uitstraling van de presentatieweer te variëren. Dit artikel laat zien hoe u Aspose.Slides for Java gebruikt om de lettertype‑eigenschappen van alinea‑teksten op dia’s te configureren.

{{% /alert %}} 

Om lettertype‑eigenschappen van een alinea te beheren met Aspose.Slides for Java:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation)‑klasse aan.
1. Verkrijg een verwijzing naar een dia door het indexnummer te gebruiken.
1. Benader de [Placeholder](https://reference.aspose.com/slides/nl/java/com.aspose.slides/placeholder/)‑vormen in de dia en cast ze naar [AutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/autoshape/).
1. Haal de [Paragraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/paragraph/) op uit het [TextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textframe/) dat door [AutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/autoshape/) wordt blootgesteld.
1. Lijn de alinea uit.
1. Benader de tekst-[Portion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/portion/) van een [Paragraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/paragraph/).
1. Definieer het lettertype met behulp van [FontData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontdata/) en stel de **Font** van de tekst‑[Portion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/portion/) dienovereenkomstig in.
   1. Stel het lettertype in op vet.
   1. Stel het lettertype in op cursief.
1. Stel de letterkleur in met behulp van de [FillFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fillformat/) die door het [Portion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/portion/)‑object wordt blootgesteld.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De implementatie van de bovenstaande stappen staat hieronder. Het neemt een onbewerkte presentatie en formatteert de lettertypen op een van de dia’s. De schermafbeeldingen die volgen tonen het invoerbestand en hoe de codefragmenten dit aanpassen. De code wijzigt het lettertype, de kleur en de stijl.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figuur: De tekst in het invoerbestand**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figuur: Dezelfde tekst met bijgewerkte opmaak**|

```java
// Instantieer een Presentation-object dat een PPTX‑bestand vertegenwoordigt
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Een dia benaderen via zijn positie
	ISlide slide = pres.getSlides().get_Item(0);

	// De eerste en tweede placeholder in de dia benaderen en casten naar AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// De eerste alinea benaderen
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// De alinea uitlijnen
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// Het eerste gedeelte benaderen
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Nieuwe lettertypen definiëren
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Nieuwe lettertypen toewijzen aan het gedeelte
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Lettertype vet maken
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Lettertype cursief maken
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// Letterkleur instellen
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// De PPTX opslaan op schijf
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Tekstlettertype‑eigenschappen instellen**
{{% alert color="primary" %}} 

Zoals vermeld in **Lettertype‑gerelateerde eigenschappen beheren**, wordt een [Portion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/portion/) gebruikt om tekst met vergelijkbare opmaakstijl binnen een alinea te bewaren. Dit artikel laat zien hoe u Aspose.Slides for Java gebruikt om een tekstvak met wat tekst te maken en vervolgens een specifiek lettertype en diverse andere eigenschappen van de lettertypefamilie te definiëren.

{{% /alert %}} 

Om een tekstvak te maken en de lettertype‑eigenschappen van de tekst erin in te stellen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation)‑klasse aan.
1. Verkrijg de verwijzing naar een dia door het indexnummer te gebruiken.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/autoshape/) van het type **Rectangle** toe aan de dia.
1. Verwijder de opvul‑stijl die aan de [AutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/autoshape/) is gekoppeld.
1. Benader het [TextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textframe/) van de [AutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/autoshape/).
1. Voeg wat tekst toe aan het [TextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textframe/).
1. Benader het [Portion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/portion/)‑object dat bij het [TextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textframe/) hoort.
1. Definieer het lettertype dat voor de [Portion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/portion/) moet worden gebruikt.
1. Stel andere lettertype‑eigenschappen in, zoals vet, cursief, onderstrepen, kleur en hoogte, met behulp van de relevante eigenschappen die door het [Portion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/portion/)‑object worden blootgesteld.
1. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

De implementatie van de bovenstaande stappen staat hieronder.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figuur: Tekst met enkele lettertype‑eigenschappen ingesteld door Aspose.Slides for Java**|

```java
// Instantieer een Presentation-object dat een PPTX‑bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
	// Eerste dia ophalen
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Een AutoShape van het type Rectangle toevoegen
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Alle opvulstijl verwijderen die aan de AutoShape is gekoppeld
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Het TextFrame benaderen dat bij de AutoShape hoort
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// Het Portion benaderen dat bij het TextFrame hoort
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Lettertype voor het Portion instellen
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Vet‑eigenschap van het lettertype instellen
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Cursief‑eigenschap van het lettertype instellen
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Onderstrepen‑eigenschap van het lettertype instellen
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Hoogte van het lettertype instellen
	port.getPortionFormat().setFontHeight(25);
	
	// Kleur van het lettertype instellen
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// De presentatie opslaan op schijf
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```