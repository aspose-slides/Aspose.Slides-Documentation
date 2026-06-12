---
title: Zlepšete své prezentace pomocí AutoFit na Androidu
linktitle: Nastavení Autofit
type: docs
weight: 30
url: /cs/androidjava/manage-autofit-settings/
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
- Android
- Java
- Aspose.Slides
description: "Spravujte nastavení AutoFit v Aspose.Slides pro Android pomocí Javy, abyste optimalizovali zobrazení textu ve svých PowerPoint a OpenDocument prezentacích a zlepšili čitelnost obsahu."
---
## **Úvod**

Ve výchozím nastavení, když přidáte textové pole, Microsoft PowerPoint používá pro textové pole nastavení **Resize shape to fix text** – automaticky mění velikost textového pole, aby jeho text vždy do něj pasoval. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Když text v textovém poli se prodlouží nebo zvětší, PowerPoint automaticky zvětší textové pole — zvýší jeho výšku — aby pojmul více textu. 
* Když text v textovém poli se zkrátí nebo zmenší, PowerPoint automaticky zmenší textové pole — sníží jeho výšku — aby odstranil přebytečný prostor. 

V PowerPointu jsou to 4 důležité parametry nebo možnosti, které řídí chování autofit pro textové pole: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Android via Java poskytuje podobné možnosti — některé vlastnosti ve třídě [TextFrameFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/TextFrameFormat) — které vám umožní řídit chování autofitu pro textová pole v prezentacích.

## **Změna velikosti tvaru tak, aby text odpovídal**

Pokud chcete, aby text v rámečku vždy po úpravách textu do něj pasoval, musíte použít možnost **Resize shape to fix text**. Pro nastavení této volby nastavte vlastnost [AutofitType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/TextFrameFormat)) na hodnotu `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Tento kód v jazyce Java vám ukazuje, jak určit, že text musí vždy pasovat do svého rámečku v prezentaci PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Shape);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Pokud se text prodlouží nebo zvětší, textové pole bude automaticky změněno (zvýší se výška), aby se do něj vešel celý text. Pokud se text zkrátí, nastane opačný efekt. 

## **Do Not Autofit**

Pokud chcete, aby textové pole nebo tvar zachovalo své rozměry bez ohledu na změny textu, který obsahuje, musíte použít možnost **Do not Autofit**. Pro nastavení této volby nastavte vlastnost [AutofitType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/TextFrameFormat)) na `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Tento kód v jazyce Java vám ukazuje, jak určit, že textové pole musí v prezentaci PowerPoint vždy zachovat své rozměry:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.None);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Když se text stane příliš dlouhým pro své pole, vyteče ven. 

## **Shrink Text on Overflow**

Pokud se text stane příliš dlouhým pro své pole, pomocí možnosti **Shrink text on overflow** můžete určit, že velikost a mezery textu musí být zmenšeny, aby se vešel do pole. Pro nastavení této volby nastavte vlastnost [AutofitType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/TextFrameFormat)) na `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Tento kód v jazyce Java vám ukazuje, jak určit, že text má být v případě přeplnění zmenšen v prezentaci PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Normal);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
Když je použita možnost **Shrink text on overflow**, nastavení se použije pouze tehdy, když se text stane příliš dlouhým pro své pole. 
{{% /alert %}}

## **Wrap Text**

Pokud chcete, aby se text v tvaru zalamoval uvnitř tohoto tvaru, když text přesáhne okraj tvaru (pouze šířka), musíte použít parametr **Wrap text in shape**. Pro nastavení této volby musíte nastavit vlastnost [WrapText](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/TextFrameFormat#getWrapText--) (třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/TextFrameFormat)) na `true`.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(NullableBool.True);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Pokud pro tvar nastavíte vlastnost `WrapText` na `False`, když text uvnitř tvaru přesáhne šířku tvaru, text se rozšíří za hranice tvaru v jedné řádce. 
{{% /alert %}}

## **Často kladené otázky**

**Ovlivňují vnitřní okraje textového rámce AutoFit?**

Ano. Odsazení (vnitřní okraje) snižuje použitelné místo pro text, takže AutoFit se spustí dříve — zmenší písmo nebo dříve změní velikost tvaru. Před laděním AutoFitu zkontrolujte a upravte okraje.

**Jak AutoFit spolupracuje s ručními a měkkými konci řádků?**

Vynucené zalomení zůstávají na svém místě a AutoFit upravuje velikost písma a mezery kolem nich. Odstranění zbytečných zalomení často snižuje agresivitu, s jakou AutoFit musí text zmenšovat.

**Mění změna fontu motivu nebo vyvolání náhrady písma výsledky AutoFitu?**

Ano. Náhrada za font s odlišnými metrikami glyfů mění šířku/výšku textu, což může změnit finální velikost písma a zalomení řádků. Po každé změně fontu nebo jeho náhradě znovu zkontrolujte snímky.