---
title: Správa fontů v prezentacích pomocí Java
linktitle: Správa fontů
type: docs
weight: 10
url: /cs/java/manage-fonts/
keywords:
- správa fontů
- vlastnosti fontu
- odstavec
- formátování textu
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Ovládejte fonty v Javě s Aspose.Slides: vložte, nahraďte a načtěte vlastní fonty, aby prezentace PPT, PPTX a ODP byly čisté, bezpečné pro značku a konzistentní."
---
## **Přehled**

Aspose.Slides vám umožňuje spravovat vlastnosti fontu v textu prezentace přímo z vašeho kódu. K textu na snímcích můžete přistupovat přes tvary, textové rámy, odstavce a úseky a následně aplikovat formátování na vybraný text.

Tento článek vysvětluje, jak konfigurovat vlastnosti související s fontem pro existující text v prezentaci, včetně rodiny písma, tučného a kurzívního stylu, zarovnání odstavce a barvy písma. Také ukazuje, jak vytvořit textové pole, přidat do něj text a nastavit vlastnosti písma, jako je rodina písma, tučný, kurzíva, podtržení, velikost písma a barva, před uložením výsledku jako souboru PPTX.

## **Správa vlastností souvisejících s fontem**
{{% alert color="primary" %}} 

Prezentace obvykle obsahují jak text, tak obrázky. Text může být formátován různými způsoby, buď pro zvýraznění konkrétních částí a slov, nebo aby odpovídal firemním stylům. Formátování textu pomáhá uživatelům měnit vzhled a pocit obsahu prezentace. Tento článek ukazuje, jak použít Aspose.Slides pro Java k nastavení vlastností písma odstavců textu na snímcích.
{{% /alert %}} 

Jak spravovat vlastnosti písma odstavce pomocí Aspose.Slides pro Java:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation).
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přistupte k tvarům [Placeholder](https://reference.aspose.com/slides/cs/java/com.aspose.slides/placeholder/) na snímku a přetypujte je na [AutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/autoshape/).
1. Získejte [Paragraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/paragraph/) z [TextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textframe/) vystaveného [AutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/autoshape/).
1. Zarovnejte odstavec.
1. Přistupte k textu [Paragraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/paragraph/) – [Portion](https://reference.aspose.com/slides/cs/java/com.aspose.slides/portion/).
1. Definujte font pomocí [FontData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontdata/) a nastavte **Font** textu [Portion](https://reference.aspose.com/slides/cs/java/com.aspose.slides/portion/) odpovídajícím způsobem.
   1. Nastavte font na tučný.
   1. Nastavte font na kurzívu.
1. Nastavte barvu fontu pomocí [FillFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fillformat/) vystaveného objektem [Portion](https://reference.aspose.com/slides/cs/java/com.aspose.slides/portion/).
1. Uložte upravenou prezentaci do souboru PPTX.

Implementace výše uvedených kroků je uvedena níže. Používá nepodloženou prezentaci a formátuje fonty na jednom ze snímků. Následující snímky obrazovky ukazují vstupní soubor a jak ho kódy upravují. Kód mění font, barvu a styl písma.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Obrázek: Text ve vstupním souboru**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Obrázek: Stejný text s aktualizovaným formátováním**|

```java
// Vytvořte objekt Presentation, který představuje soubor PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Přístup k snímku pomocí jeho pozice
	ISlide slide = pres.getSlides().get_Item(0);

	// Přístup k prvnímu a druhému placeholderu na snímku a jejich přetypování na AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// Přístup k prvnímu odstavci
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// Zarovnat odstavec do bloku
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// Přístup k prvnímu úseku
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Definujte nové fonty
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Přiřaďte nové fonty k úseku
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Nastavte font na tučný
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Nastavte font na kurzívu
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// Nastavte barvu fontu
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// Uložte PPTX na disk
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Nastavit vlastnosti fontu textu**
{{% alert color="primary" %}} 

Jak bylo zmíněno v **Správa vlastností souvisejících s fontem**, [Portion](https://reference.aspose.com/slides/cs/java/com.aspose.slides/portion/) se používá k uchování textu se stejným stylem formátování v odstavci. Tento článek ukazuje, jak použít Aspose.Slides pro Java k vytvoření textového pole s nějakým textem a následně definovat konkrétní font a různé další vlastnosti kategorie rodiny písma.
{{% /alert %}} 

Jak vytvořit textové pole a nastavit vlastnosti fontu textu v něm:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation).
1. Získejte referenci na snímek pomocí jeho indexu.
1. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/autoshape/) typu **Rectangle**.
1. Odstraňte styl výplně spojený s [AutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/autoshape/).
1. Získejte [TextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textframe/) [AutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/autoshape/).
1. Přidejte nějaký text do [TextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textframe/).
1. Přistupte k objektu [Portion](https://reference.aspose.com/slides/cs/java/com.aspose.slides/portion/) spojenému s [TextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textframe/).
1. Definujte font, který bude použit pro [Portion](https://reference.aspose.com/slides/cs/java/com.aspose.slides/portion/).
1. Nastavte další vlastnosti fontu, jako tučný, kurzíva, podtržení, barva a výška, pomocí příslušných vlastností vystavených objektem [Portion](https://reference.aspose.com/slides/cs/java/com.aspose.slides/portion/).
1. Zapište upravenou prezentaci jako soubor PPTX.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Obrázek: Text s některými vlastnostmi fontu nastavenými pomocí Aspose.Slides pro Java**|

```java
// Vytvořte objekt Presentation, který představuje soubor PPTX
Presentation pres = new Presentation();
try {
	// Získejte první snímek
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Přidejte AutoShape typu Rectangle
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Odstraňte jakýkoli styl výplně spojený s AutoShape
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Přístup k TextFrame spojenému s AutoShape
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// Přístup k Portion spojenému s TextFrame
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Nastavte font pro Portion
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Nastavte tučný styl fontu
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Nastavte kurzívní styl fontu
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Nastavte podtržení fontu
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Nastavte výšku fontu
	port.getPortionFormat().setFontHeight(25);
	
	// Nastavte barvu fontu
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// Uložte prezentaci na disk
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```