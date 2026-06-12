---
title: Správa písem v prezentacích pomocí JavaScriptu
linktitle: Správa písem
type: docs
weight: 10
url: /cs/nodejs-java/manage-fonts/
keywords:
- spravovat písma
- vlastnosti písma
- odstavec
- formátování textu
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Ovládejte písma pomocí Aspose.Slides pro Node.js přes Java: vkládejte, nahrazujte a načítejte vlastní písma, aby prezentace PPT, PPTX a ODP zůstaly jasné a konzistentní."
---
## **Úvod**

Prezentace obvykle obsahují jak text, tak obrázky. Text lze formátovat různými způsoby, ať už k zvýraznění konkrétních částí a slov nebo aby odpovídal firemním stylům. Formátování textu pomáhá uživatelům měnit vzhled a pocit obsahu prezentace. Tento článek ukazuje, jak pomocí Aspose.Slides pro Node.js přes Java nakonfigurovat vlastnosti písma odstavců textu na snímcích.

## **Správa vlastností souvisejících s písmem**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation).
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přistupte k tvarům [Placeholder](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/placeholder/) na snímku a přetypujte je na [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/).
1. Získejte [Paragraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraph/) z [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/), který je vystavený pomocí [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/).
1. Zarovnejte odstavec do bloku.
1. Získejte [Portion](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/) textu [Paragraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraph/).
1. Definujte písmo pomocí [FontData](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontdata/) a nastavte **Font** textové [Portion](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/) odpovídajícím způsobem.
   1. Nastavte písmo na tučné.
   1. Nastavte písmo na kurzívu.
1. Nastavte barvu písma pomocí [FillFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fillformat/) vystaveného objektem [Portion](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/).
1. Uložte upravenou prezentaci do souboru PPTX.

Implementace výše uvedených kroků je uvedena níže. Přijme neozvláštěnou prezentaci a na jednom ze snímků naformátuje písma. Následující snímky obrazovky ukazují vstupní soubor a jak kódové úryvky mění jeho obsah. Kód mění písmo, barvu a styl písma.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Obrázek: Text ve vstupním souboru**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Obrázek: Stejný text s aktualizovaným formátováním**|

```javascript
// Vytvořte objekt Presentation, který představuje soubor PPTX
var pres = new aspose.slides.Presentation("FontProperties.pptx");
try {
    // Přístup k snímku pomocí jeho pozice
    var slide = pres.getSlides().get_Item(0);
    // Přístup k prvnímu a druhému placeholderu na snímku a přetypování na AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // Přístup k prvnímu odstavci
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // Zarovnat odstavec do bloku
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.JustifyLow);
    // Přístup k prvnímu úseku
    var port1 = para1.getPortions().get_Item(0);
    var port2 = para2.getPortions().get_Item(0);
    // Definovat nová písma
    var fd1 = new aspose.slides.FontData("Elephant");
    var fd2 = new aspose.slides.FontData("Castellar");
    // Přiřadit nová písma k úseku
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);
    // Nastavit písmo na tučné
    port1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Nastavit písmo na kurzívu
    port1.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Nastavit barvu písma
    port1.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    port2.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // Uložit PPTX na disk
    pres.save("WelcomeFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Nastavení vlastností písma textu**
{{% alert color="primary" %}} 

Jak bylo zmíněno v **Správa vlastností souvisejících s písmem**, se [Portion](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/) používá k uchování textu se stejným stylem formátování v odstavci. Tento článek ukazuje, jak pomocí Aspose.Slides pro Node.js přes Java vytvořit textové pole s textem a poté definovat konkrétní písmo a různé další vlastnosti kategorie rodiny písem.

{{% /alert %}} 

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation).
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte do snímku [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) typu **Rectangle**.
1. Odstraňte výplňový styl spojený s [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/).
1. Přistupte k [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) objektu [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/).
1. Přidejte nějaký text do [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/).
1. Získejte objekt [Portion](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/) spojený s [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/).
1. Definujte písmo, které má být použito pro [Portion](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/).
1. Nastavte další vlastnosti písma, jako tučné, kurzíva, podtržení, barvu a velikost, pomocí příslušných vlastností vystavených objektem [Portion](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/).
1. Uložte upravenou prezentaci jako soubor PPTX.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Obrázek: Text s některými nastavenými vlastnostmi písma pomocí Aspose.Slides pro Node.js přes Java**|

```javascript
// Vytvořte objekt Presentation, který představuje soubor PPTX
var pres = new aspose.slides.Presentation();
try {
    // Získat první snímek
    var sld = pres.getSlides().get_Item(0);
    // Přidat AutoShape typu Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // Odebrat jakýkoli výplňový styl spojený s AutoShape
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Přístup k TextFrame spojenému s AutoShape
    var tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");
    // Přístup k Portion spojenému s TextFrame
    var port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
    // Nastavit písmo pro Portion
    port.getPortionFormat().setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Nastavit vlastnost tučného písma
    port.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Nastavit vlastnost kurzívy písma
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Nastavit vlastnost podtržení písma
    port.getPortionFormat().setFontUnderline(aspose.slides.TextUnderlineType.Single);
    // Nastavit výšku písma
    port.getPortionFormat().setFontHeight(25);
    // Nastavit barvu písma
    port.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // Uložit prezentaci na disk
    pres.save("pptxFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```