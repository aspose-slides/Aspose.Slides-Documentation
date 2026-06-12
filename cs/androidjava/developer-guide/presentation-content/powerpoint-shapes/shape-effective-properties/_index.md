---
title: Získání efektivních vlastností tvaru z prezentací na Androidu
linktitle: Efektivní vlastnosti
type: docs
weight: 50
url: /cs/androidjava/shape-effective-properties/
keywords:
- vlastnosti tvaru
- vlastnosti kamery
- světelné zařízení
- zkosený tvar
- textový rámec
- textový styl
- výška písma
- formát výplně
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Objevte, jak Aspose.Slides pro Android pomocí Javy vypočítává a aplikuje efektivní vlastnosti tvaru pro přesné vykreslování v PowerPointu."
---
## **Přehled**

Toto téma vysvětluje rozdíl mezi **lokálními** a **efektivními** vlastnostmi. Lokální hodnoty jsou hodnoty, které jsou nastaveny přímo na konkrétní úrovni formátování, například:

1. Vlastnosti úseku na snímku.  
1. Prototypové textové styly tvaru na rozložení nebo hlavním snímku, pokud má tvar textového rámečku úseku.  
1. Globální nastavení textu v prezentaci.

Lokální hodnoty mohou být na jakékoli úrovni definovány nebo vynechány. Když Aspose.Slides potřebuje finální „jak je vykresleno“ formátování, vyřeší řetězec dědičnosti a vrátí **efektivní** hodnoty. Získáte je voláním metody `getEffective()` na objektu lokálního formátu.

Následující příklad ukazuje, jak získat efektivní hodnoty. Předpokládá, že první tvar na prvním snímku je [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/) s textovým rámečkem a alespoň jedním úsekem.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrame textFrame = shape.getTextFrame();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrame.getTextFrameFormat().getEffective();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormatEffectiveData effectivePortionFormat = portion.getPortionFormat().getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Data efektivního formátování představují aktuální vypočítané formátování po aplikaci dědičnosti. V současné implementaci mohou být některé objekty efektivních dat, například [IPortionFormatEffectiveData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iportionformateffectivedata/), uloženy v mezipaměti interně. Opětovné volání `getEffective()` po změně nadřazeného nebo zděděného formátování může mezipaměť aktualizovat a dříve získaný objekt již nemusí představovat předchozí stav. Pokud potřebujete efektivní hodnoty zachovat pro pozdější použití, zkopírujte požadované vlastnosti, jako je výška písma, barva výplně, styl písma nebo zarovnání, do vlastního datového objektu.
{{% /alert %}}

## **Získání efektivních vlastností kamery**

Aspose.Slides umožňuje získat efektivní vlastnosti kamery. Rozhraní [ICameraEffectiveData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icameraeffectivedata/) představuje neměnný objekt, který obsahuje efektivní vlastnosti kamery. Instance [ICameraEffectiveData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icameraeffectivedata/) je vystavena prostřednictvím [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformateffectivedata/), která poskytuje efektivní hodnoty pro [IThreeDFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/).

Následující ukázkový kód ukazuje, jak získat efektivní vlastnosti kamery. Předpokládá, že první tvar na prvním snímku má 3D formátování.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraEffectiveData.getCameraType());
    System.out.println("Field of view: " + cameraEffectiveData.getFieldOfViewAngle());
    System.out.println("Zoom: " + cameraEffectiveData.getZoom());
} finally {
    presentation.dispose();
}
```

## **Získání efektivních vlastností světelného zařízení**

Aspose.Slides umožňuje získat efektivní vlastnosti světelného zařízení. Rozhraní [ILightRigEffectiveData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilightrigeffectivedata/) představuje neměnný objekt, který obsahuje efektivní vlastnosti světelného zařízení. Instance [ILightRigEffectiveData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilightrigeffectivedata/) je vystavena prostřednictvím [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformateffectivedata/), která poskytuje efektivní hodnoty pro [IThreeDFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/).

Následující ukázkový kód ukazuje, jak získat efektivní vlastnosti světelného zařízení. Předpokládá, že první tvar na prvním snímku má 3D formátování.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightRigEffectiveData.getLightType());
    System.out.println("Direction: " + lightRigEffectiveData.getDirection());
} finally {
    presentation.dispose();
}
```

## **Získání efektivních vlastností zkoseného tvaru**

Aspose.Slides umožňuje získat efektivní vlastnosti zkoseného tvaru. Rozhraní [IShapeBevelEffectiveData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapebeveleffectivedata/) představuje neměnný objekt, který obsahuje efektivní vlastnosti reliéfu pro tvar. Instance [IShapeBevelEffectiveData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapebeveleffectivedata/) je vystavena prostřednictvím [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformateffectivedata/), která poskytuje efektivní hodnoty pro [IThreeDFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/).

Následující ukázkový kód ukazuje, jak získat efektivní vlastnosti horního zkosení tvaru. Předpokládá, že první tvar na prvním snímku má 3D formátování.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTopEffectiveData = threeDEffectiveData.getBevelTop();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelTopEffectiveData.getBevelType());
    System.out.println("Width: " + bevelTopEffectiveData.getWidth());
    System.out.println("Height: " + bevelTopEffectiveData.getHeight());
} finally {
    presentation.dispose();
}
```

## **Získání efektivních vlastností textového rámce**

Pomocí Aspose.Slides můžete získat efektivní vlastnosti textového rámce. Rozhraní [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframeformateffectivedata/) obsahuje efektivní vlastnosti formátování textového rámce.

Následující ukázkový kód ukazuje, jak získat efektivní vlastnosti formátování textového rámce. Předpokládá, že první tvar na prvním snímku je [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/) s textovým rámcem.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormatEffectiveData effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();

    System.out.println("Anchoring type: " + effectiveTextFrameFormat.getAnchoringType());
    System.out.println("Autofit type: " + effectiveTextFrameFormat.getAutofitType());
    System.out.println("Text vertical type: " + effectiveTextFrameFormat.getTextVerticalType());
    System.out.println("Margins");
    System.out.println("   Left: " + effectiveTextFrameFormat.getMarginLeft());
    System.out.println("   Top: " + effectiveTextFrameFormat.getMarginTop());
    System.out.println("   Right: " + effectiveTextFrameFormat.getMarginRight());
    System.out.println("   Bottom: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    presentation.dispose();
}
```

## **Získání efektivních vlastností textového stylu**

Pomocí Aspose.Slides můžete získat efektivní vlastnosti textového stylu. Rozhraní [ITextStyleEffectiveData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextstyleeffectivedata/) obsahuje efektivní vlastnosti textového stylu.

Následující ukázkový kód ukazuje, jak získat efektivní vlastnosti textového stylu. Předpokládá, že první tvar na prvním snímku je [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/) s textovým rámcem.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);

        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + effectiveStyleLevel.getDepth());
        System.out.println("Indent: " + effectiveStyleLevel.getIndent());
        System.out.println("Alignment: " + effectiveStyleLevel.getAlignment());
        System.out.println("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    presentation.dispose();
}
```

## **Získání hodnoty efektivní výšky písma**

Pomocí Aspose.Slides můžete získat efektivní výšku písma. Následující kód ukazuje, jak se efektivní výška písma úseku mění po nastavení lokálních hodnot výšky písma na různých úrovních struktury prezentace.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    IPortion firstPortion = new Portion("Sample text with first portion");
    IPortion secondPortion = new Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    IPortionFormatEffectiveData firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    IPortionFormatEffectiveData secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height just after creation:");
    double firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    double secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting the presentation default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting paragraph default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting portion #0 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height after setting portion #1 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Získání efektivního formátu výplně pro tabulku**

Pomocí Aspose.Slides můžete získat efektivní formátování výplně pro různé části tabulky. Rozhraní [IFillFormatEffectiveData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifillformateffectivedata/) obsahuje efektivní vlastnosti formátování výplně. Formátování buňky má vyšší prioritu než formátování řádku, formátování řádku má vyšší prioritu než formátování sloupce a formátování sloupce má vyšší prioritu než formátování celé tabulky.

Výsledkem je, že vlastnosti [ICellFormatEffectiveData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icellformateffectivedata/) jsou použity při vykreslování buňky tabulky. Následující ukázkový kód ukazuje, jak získat efektivní formátování výplně pro různé části tabulky. Předpokládá, že první tvar na prvním snímku je [ITable](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itable/).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);

    IRow row = table.getRows().get_Item(0);
    IColumn column = table.getColumns().get_Item(0);
    ICell cell = table.get_Item(0, 0);

    IFillFormatEffectiveData tableFillFormatEffective = table.getTableFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = row.getRowFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = column.getColumnFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cell.getCellFormat().getEffective().getFillFormat();
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Vrací `getEffective()` snímek?**

Ne vždy. Efektivní data představují vypočítané formátování po aplikaci dědičnosti, ale některé objekty efektivních dat mohou být uloženy v mezipaměti interně. Následující volání `getEffective()` může formátování přepočítat a aktualizovat mezipaměť, takže dříve získaný objekt by neměl být považován za trvalý snímek.

**Kdy bych měl znovu načíst efektivní vlastnosti?**

Zavolejte `getEffective()` znovu po změně lokálního formátování, nadřazených stylů, formátování rozložení, hlavního formátování nebo výchozích nastavení na úrovni prezentace. Další volání přehodnotí hierarchii formátování a vrátí aktuální efektivní výsledek.

**Ovlivní změna nebo odebrání rozložení/hlavního snímku efektivní vlastnosti, které již byly načteny?**

Ano, ale změna se projeví při příštím volání `getEffective()`. Pokud je změněn nebo odebrán nadřazený zdroj formátování, dříve získaná efektivní data mohou být zastaralá. Po opětovném volání `getEffective()` Aspose.Slides přehodnotí strom formátování a výsledná písma, barvy, velikosti nebo jiné hodnoty se mohou změnit.

**Mohu měnit hodnoty přes objekty efektivních dat?**

Ne. Objekty efektivních dat poskytují pouze vypočítané hodnoty. Změny provádějte v objektech lokálního formátování a poté znovu získávejte efektivní hodnoty.

**Co se stane, pokud není vlastnost nastavena na úrovni tvaru, rozložení/hlavního snímku ani v globálním nastavení?**

Efektivní hodnota je určena výchozím mechanismem, který zahrnuje výchozí nastavení PowerPointu a Aspose.Slides. Tato získaná hodnota se stane součástí aktuálních efektivních dat.

**Z efektivní hodnoty písma mohu zjistit, která úroveň poskytla velikost nebo typ písma?**

Ne přímo. Efektivní data vracejí finální hodnotu. Pro zjištění zdroje zkontrolujte lokální hodnoty v úseku, odstavci, textovém rámečku a textových stylech na úrovních rozložení, hlavního snímku a prezentace, abyste zjistili, kde se objevila první explicitní definice.

**Proč se efektivní hodnoty někdy shodují s lokálními?**

Protože lokální hodnota se stala finální (nebyla zapotřebí žádná vyšší úroveň dědičnosti). V takových případech se efektivní hodnota shoduje s lokální.

**Kdy mám používat efektivní vlastnosti a kdy pracovat pouze s lokálními?**

Používejte efektivní data, když potřebujete výsledek „jak je vykresleno“ po aplikaci veškeré dědičnosti, například pro sladění barev, odsazení nebo velikostí. Pokud potřebujete tyto hodnoty zachovat bez ohledu na pozdější změny formátování, zkopírujte požadované vlastnosti do vlastního objektu. Pokud chcete změnit formátování na konkrétní úrovni, upravte lokální vlastnosti a poté, pokud je to nutné, znovu načtěte efektivní data k ověření výsledku.