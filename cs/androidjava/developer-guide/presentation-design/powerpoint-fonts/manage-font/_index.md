---
title: Správa fontů v prezentacích na Androidu
linktitle: Správa fontů
type: docs
weight: 10
url: /cs/androidjava/manage-fonts/
keywords:
- spravovat fonty
- vlastnosti fontu
- odstavec
- formátování textu
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Ovládejte fonty v Javě pomocí Aspose.Slides pro Android: vkládejte, nahrazujte a načítejte vlastní fonty, aby byly prezentace PPT, PPTX a ODP přehledné, v souladu se značkou a konzistentní."
---
## **Přehled**

Aspose.Slides vám umožňuje spravovat vlastnosti fontu v textu prezentace přímo z kódu. Můžete získat přístup k textu na snímcích prostřednictvím tvarů, textových rámců, odstavců a částí a poté na vybraný text použít formátování.

Tento článek vysvětluje, jak nakonfigurovat vlastnosti související s fontem pro existující text v prezentaci, včetně rodiny fontu, tučného a kurzívního stylu, zarovnání odstavce a barvy fontu. Také ukazuje, jak vytvořit textové pole, přidat do něj text a nastavit vlastnosti fontu, jako je rodina fontu, tučné, kurzíva, podtržení, velikost a barva, před uložením výsledku jako soubor PPTX.

## **Správa vlastností souvisejících s fontem**
{{% alert color="primary" %}} 

Prezentace obvykle obsahují jak text, tak obrázky. Text lze formátovat různými způsoby, ať už pro zvýraznění konkrétních částí a slov nebo pro dodržení firemních stylů. Formátování textu pomáhá uživatelům měnit vzhled a dojem z obsahu prezentace. Tento článek ukazuje, jak pomocí Aspose.Slides pro Android přes Java nakonfigurovat vlastnosti fontu odstavců textu na snímcích.

{{% /alert %}} 

Pro správu vlastností fontu odstavce pomocí Aspose.Slides pro Android přes Java:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation).
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přistupte k tvarům [Placeholder](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/placeholder/) na snímku a přetypujte je na [AutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/autoshape/).
1. Získejte [Paragraph](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/paragraph/) z [TextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/textframe/) poskytovaného objektem [AutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/autoshape/).
1. Zarovnejte odstavec.
1. Přistupte k textové [Portion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/portion/) odstavce.
1. Definujte font pomocí [FontData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontdata/) a nastavte **Font** textové [Portion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/portion/) podle toho.
   1. Nastavte font na tučný.
   1. Nastavte font na kurzívu.
1. Nastavte barvu fontu pomocí [FillFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fillformat/) poskytovaného objektem [Portion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/portion/).
1. Uložte upravenou prezentaci do souboru PPTX.

Implementace výše uvedených kroků je uvedena níže. Bere nepřizpůsobenou prezentaci a formátuje fonty na jednom ze snímků. Následující snímky obrazovky ukazují vstupní soubor a to, jak jej kódy mění. Kód mění font, barvu a styl fontu.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Obrázek: Text ve vstupním souboru**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Obrázek: Ten samý text s aktualizovaným formátováním**|

```java
// Vytvořte objekt Presentation, který představuje soubor PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Přístup k snímku pomocí jeho pozice
	ISlide slide = pres.getSlides().get_Item(0);

	// Přístup k prvnímu a druhému zástupci ve snímku a převod na AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// Přístup k prvnímu odstavci
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// Zarovnat odstavec do bloku
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// Přístup k první části
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Definujte nové fonty
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Přiřaďte nové fonty k části
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

## **Nastavení vlastností fontu textu**
{{% alert color="primary" %}} 

Jak je zmíněno v **Správa vlastností souvisejících s fontem**, [Portion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/portion/) se používá k držení textu s podobným stylem formátování v odstavci. Tento článek ukazuje, jak pomocí Aspose.Slides pro Android přes Java vytvořit textové pole s nějakým textem a pak definovat konkrétní font a různé další vlastnosti kategorie rodiny fontu.

{{% /alert %}} 

Pro vytvoření textového pole a nastavení vlastností fontu textu v něm:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation).
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/autoshape/) typu **Rectangle** na snímek.
1. Odstraňte výplňový styl spojený s [AutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/autoshape/).
1. Přistupte k [TextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/textframe/) objektu [AutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/autoshape/).
1. Přidejte nějaký text do [TextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/textframe/).
1. Přistupte k objektu [Portion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/portion/) spojenému s [TextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/textframe/).
1. Definujte font, který bude použit pro [Portion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/portion/).
1. Nastavte další vlastnosti fontu, jako jsou tučný, kurzíva, podtržení, barva a výška, pomocí příslušných vlastností poskytovaných objektem [Portion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/portion/).
1. Uložte upravenou prezentaci jako soubor PPTX.

Implementace výše uvedených kroků je uvedena níže.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Obrázek: Text s některými nastavenými vlastnostmi fontu pomocí Aspose.Slides pro Android přes Java**|

```java
// Vytvořte objekt Presentation, který představuje soubor PPTX
Presentation pres = new Presentation();
try {
	// Získejte první snímek
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Přidejte AutoShape typu Rectangle
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Odstraňte jakýkoli výplňový styl spojený s AutoShape
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