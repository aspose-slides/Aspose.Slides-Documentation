---
title: Vylepšete své prezentace pomocí AutoFit v JavaScriptu
linktitle: Nastavení AutoFit
type: docs
weight: 30
url: /cs/nodejs-java/manage-autofit-settings/
keywords:
- textové pole
- autofit
- neautofit
- přizpůsobit text
- zmenšit text
- zalamovat text
- změnit velikost tvaru
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Spravujte nastavení AutoFit v Aspose.Slides pro Node.js, abyste optimalizovali zobrazení textu ve svých prezentacích PowerPoint a OpenDocument a zlepšili čitelnost obsahu."
---
## **Úvod**

Ve výchozím nastavení, když přidáte textové pole, Microsoft PowerPoint používá nastavení **Resize shape to fix text** pro textové pole — automaticky mění velikost textového pole, aby se jeho text vždy vešel. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Když se text v textovém poli prodlouží nebo zvětší, PowerPoint automaticky zvětší textové pole — zvýší jeho výšku — aby pojmul více textu. 
* Když se text v textovém poli zkrátí nebo zmenší, PowerPoint automaticky zmenší textové pole — sníží jeho výšku — aby odstranil nadbytečný prostor. 

V PowerPointu jsou to následující 4 důležité parametry nebo možnosti, které řídí chování automatického přizpůsobení pro textové pole: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides pro Node.js přes Java poskytuje podobné možnosti — některé vlastnosti ve třídě [TextFrameFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/TextFrameFormat), které vám umožní řídit chování automatického přizpůsobení pro textová pole v prezentacích.

## **Resize Shape to Fit Text**

Pokud chcete, aby text v poli vždy zapadal do tohoto pole po provedení změn, musíte použít možnost **Resize shape to fix text**. Pro nastavení tohoto chování zavolejte metodu [setAutofitType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) ze třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/TextFrameFormat) s hodnotou `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Tento JavaScriptový kód ukazuje, jak určit, že text se vždy musí vejít do svého pole v prezentaci PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Shape);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Pokud se text prodlouží nebo zvětší, textové pole bude automaticky změněno (zvýší se výška), aby se do něj vešel celý text. Pokud se text zkrátí, nastane opačný efekt. 

## **Do Not Autofit**

Pokud chcete, aby textové pole nebo tvar zachoval své rozměry bez ohledu na změny textu, musíte použít možnost **Do not Autofit**. Pro nastavení tohoto chování zavolejte metodu [setAutofitType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) ze třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/TextFrameFormat) s hodnotou `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Tento JavaScriptový kód ukazuje, jak určit, že textové pole musí vždy zachovat své rozměry v prezentaci PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.None);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Když se text stane příliš dlouhým pro své pole, přeteče ven. 

## **Shrink Text on Overflow**

Pokud se text stane příliš dlouhým pro své pole, pomocí možnosti **Shrink text on overflow** můžete určit, že velikost a mezery textu se zmenší, aby se vešel do pole. Pro nastavení tohoto chování zavolejte metodu [setAutofitType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) ze třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/TextFrameFormat) s hodnotou `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Tento JavaScriptový kód ukazuje, jak určit, že text se má při přetečení zmenšit v prezentaci PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Normal);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Info" color="info" %}}
Když je použita možnost **Shrink text on overflow**, nastavení se použije pouze v případě, že text přesáhne rozměry pole. 
{{% /alert %}}

## **Wrap Text**

Pokud chcete, aby se text v tvaru zalomil uvnitř tvaru, když přesáhne jeho šířku, musíte použít parametr **Wrap text in shape**. Pro nastavení tohoto chování zavolejte metodu [setWrapText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/TextFrameFormat#setWrapText) ze třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/TextFrameFormat) s hodnotou `true`.

Tento JavaScriptový kód ukazuje, jak použít nastavení Wrap Text v prezentaci PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(aspose.slides.NullableBool.True);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}} 
Pokud zavoláte metodu `setWrapText` s hodnotou `False` pro tvar, když text uvnitř tvaru přesáhne jeho šířku, text se rozšíří mimo hranice tvaru v jedné řadě. 
{{% /alert %}}

## **FAQ**

**Ovlivňují vnitřní okraje textového rámečku AutoFit?**

Ano. Výplň (vnitřní okraje) snižuje použitelnou oblast pro text, takže AutoFit se aktivuje dříve — zmenší písmo nebo změní velikost tvaru dříve. Zkontrolujte a upravte okraje před laděním AutoFit.

**Jak AutoFit spolupracuje s ručními a měkkými zalomeními řádků?**

Vynucená zalomení zůstávají na místě a AutoFit přizpůsobuje velikost písma a mezery okolo nich. Odstranění zbytečných zalomení často snižuje agresivitu, s jakou AutoFit musí text zmenšovat.

**Ovlivňuje změna písma motivu nebo nahrazení písma výsledky AutoFit?**

Ano. Nahrazení písma fontem s odlišnými metrikami změní šířku/výšku textu, což může změnit finální velikost písma a zalomení řádků. Po jakékoli změně nebo nahrazení písma znovu zkontrolujte snímky.