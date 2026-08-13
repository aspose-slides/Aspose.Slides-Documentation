---
title: Správa fontů v prezentacích na Androidu
linktitle: Správa fontů
type: docs
weight: 10
url: /cs/androidjava/manage-fonts/
keywords:
- správa fontů
- vlastnosti písma
- odstavec
- formátování textu
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Řízení fontů v Javě pomocí Aspose.Slides pro Android: vložte, nahraďte a načtěte vlastní fonty, aby prezentace PPT, PPTX a ODP byly čisté, bezpečné pro značku a konzistentní."
---
## **Přehled**

Aspose.Slides vám umožňuje spravovat vlastnosti písma v textu prezentace přímo z kódu. Přístup k textu na slidech je možný prostřednictvím tvarů, textových rámců, odstavců a částí, a následně můžete aplikovat formátování na vybraný text.

Tento článek vysvětluje, jak nastavit vlastnosti související s písmem pro existující text v prezentaci, včetně rodiny písma, tučného a kurzívního stylu, zarovnání odstavce a barvy písma. Také ukazuje, jak vytvořit textové pole, přidat do něj text a nastavit vlastnosti písma, jako je rodina písma, tučné, kurzíva, podtržení, velikost písma a barva, před uložením výsledku jako soubor PPTX.

## **Správa vlastností souvisejících s písmem**
{{% alert color="info" %}} 

Prezentace obvykle obsahují jak text, tak obrázky. Text lze formátovat různými způsoby, ať už pro zdůraznění konkrétních částí a slov, nebo aby odpovídal firemním stylům. Formátování textu pomáhá uživatelům měnit vzhled a pocit obsahu prezentace. Tento článek ukazuje, jak použít Aspose.Slides for Android via Java k nastavení vlastností písma odstavců textu na slidech.

{{% /alert %}} 

Pro správu vlastností písma odstavce pomocí Aspose.Slides for Android via Java:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation).
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přistupte k tvarům [Placeholder](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/placeholder/) na snímku a přetypujte je na [AutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/autoshape/).
1. Získáte [Paragraph](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/paragraph/) z [TextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/textframe/), který je vystaven [AutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/autoshape/).
1. Zarovnejte odstavec do bloku.
1. Přistupte k textu [Paragraph](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/paragraph/) pomocí [Portion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/portion/).
1. Definujte písmo pomocí [FontData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontdata/) a nastavte **Font** textu [Portion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/portion/) podle toho.
   1. Nastavte písmo na tučné.
   1. Nastavte písmo na kurzívu.
1. Nastavte barvu písma pomocí [FillFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fillformat/) vystaveného objektem [Portion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/portion/).
1. Uložte upravenou prezentaci do souboru PPTX.

Implementace výše uvedených kroků je uvedena níže. Vezme neformátovanou prezentaci a formátuje písma na jednom ze snímků. Následující snímky ukazují vstupní soubor a jak kódové úryvky mění jeho vzhled. Kód mění písmo, barvu a styl písma.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Obrázek: Text ve vstupním souboru**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Obrázek: Stejný text s aktualizovaným formátováním**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Vytvořte objekt Presentation, který představuje soubor PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Přístup k snímku pomocí jeho pozice
	ISlide slide = pres.getSlides().get_Item(0);

	// Přístup k prvnímu a druhému placeholderu na snímku a přetypování na AutoShape
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

	// Definovat nová písma
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Přiřadit nová písma k části
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Nastavit písmo na tučné
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Nastavit písmo na kurzívu
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// Nastavit barvu písma
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// Uložit PPTX na disk
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Nastavení vlastností písma textu**
{{% alert color="info" %}} 

Jak bylo zmíněno v **Správa vlastností souvisejících s písmem**, [Portion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/portion/) se používá k uchování textu se stejným stylem formátování v odstavci. Tento článek ukazuje, jak použít Aspose.Slides for Android via Java k vytvoření textového pole s nějakým textem a pak definovat konkrétní písmo a různé další vlastnosti kategorie rodiny písma.

{{% /alert %}} 

Pro vytvoření textového pole a nastavení vlastností písma textu v něm:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation).
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/autoshape/) typu **Rectangle** na snímek.
1. Odeberte výplňový styl přiřazený [AutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/autoshape/).
1. Přistupte k [TextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/textframe/) tvaru [AutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/autoshape/).
1. Přidejte nějaký text do [TextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/textframe/).
1. Přistupte k objektu [Portion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/portion/) spojenému s [TextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/textframe/).
1. Definujte písmo, které bude použito pro [Portion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/portion/).
1. Nastavte další vlastnosti písma, jako jsou tučné, kurzíva, podtržení, barva a výška pomocí příslušných vlastností vystavených objektem [Portion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/portion/).
1. Uložte upravenou prezentaci jako soubor PPTX.

Implementace výše uvedených kroků je uvedena níže.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Obrázek: Text s některými nastavenými vlastnostmi písma pomocí Aspose.Slides for Android via Java**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Vytvořte objekt Presentation, který představuje soubor PPTX
Presentation pres = new Presentation();
try {
	// Získat první snímek
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Přidat AutoShape typu Rectangle
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Odstranit jakýkoli výplňový styl spojený s AutoShape
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Přístup k TextFrame spojenému s AutoShape
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// Přístup k Portion spojenému s TextFrame
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Nastavit písmo pro Portion
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Nastavit vlastnost tučné u písma
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Nastavit vlastnost kurzíva u písma
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Nastavit vlastnost podtržení u písma
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Nastavit výšku písma
	port.getPortionFormat().setFontHeight(25);
	
	// Nastavit barvu písma
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// Uložit prezentaci na disk
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```