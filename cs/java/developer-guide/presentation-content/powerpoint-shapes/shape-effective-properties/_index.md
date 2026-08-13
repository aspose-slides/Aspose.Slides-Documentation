---
title: Získání efektivních vlastností tvaru z prezentací v Javě
linktitle: Efektivní vlastnosti
type: docs
weight: 50
url: /cs/java/shape-effective-properties/
keywords:
- vlastnosti tvaru
- vlastnosti kamery
- světelný rig
- zkosení tvaru
- textový rámec
- textový styl
- výška písma
- formát výplně
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Objevte, jak Aspose.Slides pro Java vypočítává a aplikuje efektivní vlastnosti tvarů pro přesné vykreslení PowerPointu."
---
## **Přehled**

Tato kapitola vysvětluje rozdíl mezi **lokálními** a **efektivními** vlastnostmi. Lokální hodnoty jsou hodnoty nastavené přímo na konkrétní úrovni formátování, například:

1. Vlastnosti úseku na snímku.  
1. Styly textu prototypového tvaru na rozvržení nebo hlavním snímku, pokud má tvar textového rámečku úseku takový styl.  
1. Globální nastavení textu v prezentaci.

Lokální hodnoty mohou být na jakékoli úrovni definovány nebo vynechány. Když Aspose.Slides potřebuje finální „zobrazené“ formátování, rozřeší řetězec dědičnosti a vrátí **efektivní** hodnoty. Získáte je zavoláním metody `getEffective` na objekt lokálního formátu.

Následující příklad ukazuje, jak získat efektivní hodnoty. Předpokládá, že první tvar na prvním snímku je [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IAutoShape) s textovým rámečkem a alespoň jedním úsekem.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = paragraph.getPortions().get_Item(0);
    IPortionFormat localPortionFormat = portion.getPortionFormat();
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="info" %}}
Efektivní data formátování představují aktuální vypočtené formátování po aplikaci dědičnosti. V současné implementaci mohou být některé objekty efektivních dat, například [IPortionFormatEffectiveData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPortionFormatEffectiveData), uloženy v interní mezipaměti. Opětovné volání `getEffective` po změně nadřazeného nebo zděděného formátování může mezipaměť obnovit a dříve získaný objekt již nemusí představovat předchozí stav. Pokud potřebujete efektivní hodnoty zachovat pro pozdější použití, zkopírujte požadované vlastnosti, jako je výška písma, barva výplně, styl písma nebo zarovnání, do vlastního datového objektu.
{{% /alert %}}

## **Získání efektivních vlastností kamery**

Aspose.Slides vám umožňuje získat efektivní vlastnosti kamery. Rozhraní [ICameraEffectiveData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ICameraEffectiveData) představuje neměnný objekt, který obsahuje efektivní vlastnosti kamery. Instance [ICameraEffectiveData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ICameraEffectiveData) je zpřístupněna prostřednictvím [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IThreeDFormatEffectiveData), který poskytuje efektivní hodnoty pro [IThreeDFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IThreeDFormat).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();
    int cameraType = cameraEffectiveData.getCameraType();
    double fieldOfViewAngle = cameraEffectiveData.getFieldOfViewAngle();
    double zoom = cameraEffectiveData.getZoom();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraType);
    System.out.println("Field of view: " + fieldOfViewAngle);
    System.out.println("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **Získání efektivních vlastností osvětlení**

Aspose.Slides vám umožňuje získat efektivní vlastnosti osvětlení. Rozhraní [ILightRigEffectiveData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ILightRigEffectiveData) představuje neměnný objekt, který obsahuje efektivní vlastnosti osvětlení. Instance [ILightRigEffectiveData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ILightRigEffectiveData) je zpřístupněna prostřednictvím [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IThreeDFormatEffectiveData), který poskytuje efektivní hodnoty pro [IThreeDFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IThreeDFormat).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();
    int lightType = lightRigEffectiveData.getLightType();
    int direction = lightRigEffectiveData.getDirection();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightType);
    System.out.println("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **Získání efektivních vlastností zkosení tvaru**

Aspose.Slides vám umožňuje získat efektivní vlastnosti zkosení tvaru. Rozhraní [IShapeBevelEffectiveData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShapeBevelEffectiveData) představuje neměnný objekt, který obsahuje efektivní vlastnosti povrchového reliéfu pro tvar. Instance [IShapeBevelEffectiveData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShapeBevelEffectiveData) je zpřístupněna prostřednictvím [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IThreeDFormatEffectiveData), který poskytuje efektivní hodnoty pro [IThreeDFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IThreeDFormat).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTop = threeDEffectiveData.getBevelTop();
    int bevelType = bevelTop.getBevelType();
    double bevelWidth = bevelTop.getWidth();
    double bevelHeight = bevelTop.getHeight();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelType);
    System.out.println("Width: " + bevelWidth);
    System.out.println("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **Získání efektivních vlastností textového rámce**

Pomocí Aspose.Slides můžete získat efektivní vlastnosti textového rámce. Rozhraní [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITextFrameFormatEffectiveData) obsahuje efektivní vlastnosti formátování textového rámce.

Následující ukázkový kód ukazuje, jak získat efektivní vlastnosti formátování textového rámce. Předpokládá, že první tvar na prvním snímku je [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IAutoShape) s textovým rámcem.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrameFormat.getEffective();
    int anchoringType = effectiveTextFrameFormat.getAnchoringType();
    int autofitType = effectiveTextFrameFormat.getAutofitType();
    int textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    double marginLeft = effectiveTextFrameFormat.getMarginLeft();
    double marginTop = effectiveTextFrameFormat.getMarginTop();
    double marginRight = effectiveTextFrameFormat.getMarginRight();
    double marginBottom = effectiveTextFrameFormat.getMarginBottom();

    System.out.println("Anchoring type: " + anchoringType);
    System.out.println("Autofit type: " + autofitType);
    System.out.println("Text vertical type: " + textVerticalType);
    System.out.println("Margins");
    System.out.println("   Left: " + marginLeft);
    System.out.println("   Top: " + marginTop);
    System.out.println("   Right: " + marginRight);
    System.out.println("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **Získání efektivních vlastností textového stylu**

Pomocí Aspose.Slides můžete získat efektivní vlastnosti textového stylu. Rozhraní [ITextStyleEffectiveData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITextStyleEffectiveData) obsahuje efektivní vlastnosti textového stylu.

Následující ukázkový kód ukazuje, jak získat efektivní vlastnosti textového stylu. Předpokládá, že první tvar na prvním snímku je [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IAutoShape) s textovým rámcem.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);
    
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        int depth = effectiveStyleLevel.getDepth();
        double indent = effectiveStyleLevel.getIndent();
        int alignment = effectiveStyleLevel.getAlignment();
        int fontAlignment = effectiveStyleLevel.getFontAlignment();
        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + depth);
        System.out.println("Indent: " + indent);
        System.out.println("Alignment: " + alignment);
        System.out.println("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **Získání efektivní výšky písma**

Pomocí Aspose.Slides můžete získat efektivní výšku písma. Následující kód ukazuje, jak se efektivní výška písma úseku mění po nastavení lokální výšky písma na různých úrovních struktury prezentace.

```java
import com.aspose.slides.*;

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

Pomocí Aspose.Slides můžete získat efektivní formátování výplně pro různé části tabulky. Rozhraní [IFillFormatEffectiveData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IFillFormatEffectiveData) obsahuje efektivní vlastnosti formátování výplně. Formátování buňky má vyšší prioritu než formátování řádku, formátování řádku má vyšší prioritu než formátování sloupce a formátování sloupce má vyšší prioritu než formátování celé tabulky.

V důsledku toho jsou k vykreslení buňky tabulky použity vlastnosti [ICellFormatEffectiveData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ICellFormatEffectiveData).

Následující ukázkový kód ukazuje, jak získat efektivní formátování výplně pro různé části tabulky. Předpokládá, že první tvar na prvním snímku je [ITable](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITable).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);
    
    ITableFormatEffectiveData tableFormatEffective = table.getTableFormat().getEffective();
    IRowFormatEffectiveData rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    IColumnFormatEffectiveData columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    ICellFormatEffectiveData cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Vrací metoda `getEffective` snímek?

Ne. Efektivní data představují vypočtené formátování po aplikaci dědičnosti, ale některé objekty efektivních dat mohou být uloženy v interní mezipaměti. Následující volání `getEffective` může znovu vypočítat formátování a obnovit mezipaměť, takže dříve získaný objekt by neměl být považován za trvalý snímek.

### Kdy by měl být efektivní vlastnosti znovu načteny?

Zavolejte `getEffective` znovu po změně lokálního formátování, nadřazených stylů, formátování rozvržení, hlavního formátování nebo výchozích nastavení na úrovni prezentace. Další volání přehodnotí hierarchii formátování a vrátí aktuální efektivní výsledek.

### Ovlivní změna nebo odebrání rozvržení/hlavního snímku efektivní vlastnosti, které byly již získány?

Ano, ale změna se projeví při dalším volání `getEffective`. Pokud je změněn nebo odebrán nadřazený zdroj formátování, dříve získaná efektivní data mohou být zastaralá. Po opětovném zavolání `getEffective` Aspose.Slides přehodnotí strom formátování a výsledná písma, barvy, velikosti či další hodnoty se mohou změnit.

### Mohu měnit hodnoty prostřednictvím objektů efektivních dat?

Ne. Objektům efektivních dat jsou pouze k dispozici vypočtené hodnoty. Změny provádějte v objektech lokálního formátování a poté znovu získávejte efektivní hodnoty.

### Co se stane, pokud není vlastnost nastavena na úrovni tvaru, rozvržení/hlavního snímku ani v globálním nastavení?

Efektivní hodnota je určena výchozím mechanismem, který zahrnuje výchozí hodnoty PowerPointu a Aspose.Slides. Tato vyřešená hodnota se stane součástí aktuálních efektivních dat.

### Z efektivní hodnoty písma lze zjistit, na které úrovni byla velikost nebo typ písma zadán?

Ne přímo. Efektivní data vrací finální hodnotu. Pro zjištění zdroje je třeba zkontrolovat lokální hodnoty na úrovních úseku, odstavce, textového rámce a textových stylů v rozvržení, hlavním snímku a úrovni prezentace, abyste zjistili, kde se objevila první explicitní definice.

### Proč vypadají efektivní hodnoty někdy shodně s lokálními?

Protože lokální hodnota se stala finální (nebyla potřeba žádná vyšší úroveň dědičnosti). V takových případech se efektivní hodnota shoduje s lokální.

### Kdy použít efektivní vlastnosti a kdy pracovat jen s lokálními?

Používejte efektivní data, když potřebujete výsledek „jak je zobrazeno“ po aplikaci veškeré dědičnosti, například pro sladění barev, odsazení nebo velikostí. Pokud chcete tyto hodnoty zachovat nezávisle na pozdějších změnách formátování, zkopírujte požadované vlastnosti do vlastního objektu. Pokud potřebujete změnit formátování na konkrétní úrovni, upravte lokální vlastnosti a poté, pokud je to nutné, znovu načtěte efektivní data pro ověření výsledku.