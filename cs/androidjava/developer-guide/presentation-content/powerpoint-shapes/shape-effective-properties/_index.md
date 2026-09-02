---
title: Získání efektivních vlastností tvaru z prezentací na Androidu
linktitle: Efektivní vlastnosti
type: docs
weight: 50
url: /cs/androidjava/shape-effective-properties/
keywords:
- vlastnosti tvaru
- vlastnosti kamery
- osvětlení
- tvar s úkosy
- textový rámec
- textový styl
- výška písma
- formát výplně
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Naučte se, jak pomocí Aspose.Slides pro Android v Javě rozlišovat místní, zděděné a efektivní formátování tvarů v prezentacích PowerPoint."
---
## **Pochopte místní, zděděné a efektivní vlastnosti**

Formátování PowerPointu může pocházet z několika míst. Hodnota uložená přímo na objektu je jeho **místní hodnota**. Pokud tato hodnota není nastavena, PowerPoint se podívá na nadřazené zdroje formátování, jako je výchozí nastavení odstavce, textový styl, rozvržení nebo hlavní snímek, motiv nebo výchozí nastavení na úrovni celé prezentace. Tyto hodnoty jsou **zděděné hodnoty**. Hodnota, která zůstane po vyřešení celé hierarchie, je **efektivní hodnota** — hodnota použitá k vykreslení objektu.

Například textová část nemusí definovat svou vlastní výšku písma. Její místní [getFontHeight](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibaseportionformat/#getFontHeight--) hodnota je pak `Float.NaN`, což znamená „není zde nastaveno“. Část může zdědit výšku ze svého odstavce, výchozího textového stylu prezentace nebo jiného relevantního zdroje. Voláním [getEffective](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iportionformat/#getEffective--) na formát části získáte finální vyřešenou výšku.

Používejte oba typy formátovacích dat pro různé účely:

- Čtěte nebo měňte místní objekt formátu, například [IPortionFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iportionformat/), když potřebujete řídit, kde je hodnota definována.
- Čtěte efektivní datový objekt, například [IPortionFormatEffectiveData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iportionformateffectivedata/), když potřebujete konečný, vykreslený výsledek. Efektivní data jsou jen pro čtení.

## **Porovnejte místní, zděděné a efektivní hodnoty**

Následující úplný příklad vytvoří tvar a aplikuje výšky písma na úrovni prezentace, odstavce a části. Každý krok vytiskne hodnoty definované na těchto úrovních a výslednou efektivní hodnotu pro stejnou textovou část. Také ukazuje, proč je třeba po změnách formátování znovu načíst efektivní data.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
            ITextFrame textFrame = shape.addTextFrame("Effective formatting");
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            // Definujte zděděné hodnoty na dvou různých úrovních.
            presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

            printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

            // Místní hodnota v části přepisuje obě zděděné hodnoty.
            portion.getPortionFormat().setFontHeight(36);
            printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

            // Změna zděděné hodnoty nepřepíše existující místní hodnotu.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
            printFontHeights("The local value still has priority", presentation, paragraph, portion);

            // Vymažte místní hodnotu. Část nyní opět zdědí hodnotu z odstavce.
            portion.getPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The local value is cleared", presentation, paragraph, portion);

            // Vymažte hodnotu odstavce. Výchozí nastavení prezentace nyní poskytuje výsledek.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

            presentation.save("effective-properties.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }

    private static void printFontHeights(String caption, Presentation presentation, IParagraph paragraph, IPortion portion) {
        float presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
        float paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
        float localValue = portion.getPortionFormat().getFontHeight();

        // Přečtěte efektivní data po předchozích změnách.
        float effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

        System.out.println(caption);
        System.out.println("  Presentation default: " + formatLocalValue(presentationValue));
        System.out.println("  Paragraph default:    " + formatLocalValue(paragraphValue));
        System.out.println("  Portion local:        " + formatLocalValue(localValue));
        System.out.println("  Portion effective:    " + effectiveValue);
    }

    private static String formatLocalValue(float value) {
        return Float.isNaN(value) ? "<not set>" : Float.toString(value);
    }
}
```

Prioritou v tomto příkladu je místní formátování části, pak formátování odstavce a nakonec výchozí nastavení prezentace. Ostatní objekty mohou mít odlišné řetězce dědičnosti, ale princip je stejný: konkrétnější explicitní hodnota vyhrává a [getEffective](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iportionformat/#getEffective--) vrací finální výsledek.

## **Získání efektivních textových vlastností**

Formátování textu je rozděleno mezi několik objektů:

- [ITextFrameFormat.getEffective()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframeformat/#getEffective--) řeší vlastnosti textového rámce, jako jsou okraje, ukotvení, automatické přizpůsobení a svislý směr textu.
- [ITextStyle.getEffective()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextstyle/#getEffective--) řeší formátování odstavce pro každou úroveň textového stylu.
- [IParagraphFormat.getEffective()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iparagraphformat/#getEffective--) řeší vlastnosti odstavce, jako jsou zarovnání, odsazení a odrážky.
- [IPortionFormat.getEffective()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iportionformat/#getEffective--) řeší vlastnosti znaků, jako jsou výška písma, typ písma, barva, tučnost a kurzíva.

Pro další příklad musí `text-formatting.pptx` obsahovat alespoň jeden snímek a jednu [AutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/autoshape/) s neprázdným textovým rámcem. AutoShape může být umístěna na libovolné pozici ve sbírce tvarů; kód hledá vhodný objekt a před použitím jej ověří.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("text-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            IAutoShape shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
            if (shape == null) {
                throw new IllegalStateException("The first slide must contain an AutoShape with non-empty text.");
            }

            ITextFrame textFrame = shape.getTextFrame();
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            ITextFrameFormatEffectiveData textFrameEffective = textFrame.getTextFrameFormat().getEffective();
            IParagraphFormatEffectiveData paragraphEffective = paragraph.getParagraphFormat().getEffective();
            IPortionFormatEffectiveData portionEffective = portion.getPortionFormat().getEffective();

            System.out.println("Text frame margins:");
            System.out.println("  Left: " + textFrameEffective.getMarginLeft());
            System.out.println("  Top: " + textFrameEffective.getMarginTop());
            System.out.println("  Right: " + textFrameEffective.getMarginRight());
            System.out.println("  Bottom: " + textFrameEffective.getMarginBottom());
            System.out.println("Paragraph alignment: " + paragraphEffective.getAlignment());
            System.out.println("Font height: " + portionEffective.getFontHeight());
            System.out.println("Bold: " + portionEffective.getFontBold());

            ITextStyleEffectiveData effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
            for (int level = 0; level < 9; level++) {
                IParagraphFormatEffectiveData levelEffective = effectiveTextStyle.getLevel(level);
                System.out.println("Level " + level + " indent: " + levelEffective.getIndent());
            }
        } finally {
            presentation.dispose();
        }
    }

    private static IAutoShape findAutoShapeWithText(ISlide slide) {
        for (IShape candidate : slide.getShapes()) {
            if (candidate instanceof IAutoShape && hasNonEmptyText((IAutoShape)candidate)) {
                return (IAutoShape)candidate;
            }
        }
        return null;
    }

    private static boolean hasNonEmptyText(IAutoShape shape) {
        if (shape.getTextFrame() == null) {
            return false;
        }
        if (shape.getTextFrame().getParagraphs().getCount() == 0) {
            return false;
        }
        return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
    }
}
```

## **Získání efektivních 3D vlastností**

[IThreeDFormat.getEffective()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformat/#getEffective--) vrací jeden objekt [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformateffectivedata/) , který seskupuje všechna vyřešená 3D nastavení. Jeho metody [getCamera](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformateffectivedata/#getCamera--) , [getLightRig](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformateffectivedata/#getLightRig--) , [getBevelTop](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformateffectivedata/#getBevelTop--) a [getBevelBottom](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ithreedformateffectivedata/#getBevelBottom--) poskytují odpovídající efektivní data. Čtení těchto souvisejících nastavení dohromady usnadňuje pochopení konečného 3D vzhledu tvaru.

Pro tento příklad musí `shape-3d.pptx` obsahovat alespoň jeden tvar na svém prvním snímku. Pokud chcete, aby výstup obsahoval hodnoty odlišné od výchozích, aplikujte na tento tvar 3D kameru, osvětlení nebo nastavení sklonu.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("shape-3d.pptx");
        try {
            if (presentation.getSlides().size() == 0 || presentation.getSlides().get_Item(0).getShapes().size() == 0) {
                throw new IllegalStateException("The first slide must contain a shape.");
            }

            IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
            IThreeDFormatEffectiveData threeDEffective = shape.getThreeDFormat().getEffective();

            System.out.println("Camera:");
            System.out.println("  Type: " + threeDEffective.getCamera().getCameraType());
            System.out.println("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
            System.out.println("  Zoom: " + threeDEffective.getCamera().getZoom());

            System.out.println("Light rig:");
            System.out.println("  Type: " + threeDEffective.getLightRig().getLightType());
            System.out.println("  Direction: " + threeDEffective.getLightRig().getDirection());

            System.out.println("Top bevel:");
            System.out.println("  Type: " + threeDEffective.getBevelTop().getBevelType());
            System.out.println("  Width: " + threeDEffective.getBevelTop().getWidth());
            System.out.println("  Height: " + threeDEffective.getBevelTop().getHeight());
        } finally {
            presentation.dispose();
        }
    }
}
```

## **Získání efektivního formátování tabulky**

Formátování tabulky může pocházet ze stylu tabulky a z formátů aplikovaných na celou tabulku, sloupec, řádek nebo jednotlivou buňku. V případě konfliktů mezi explicitně definovanými výplněmi je prioritou buňka, řádek, sloupec a pak celá tabulka. Efektivní formát buňky je konečný formát použitý k vykreslení této buňky.

Pro tento příklad musí `table-formatting.pptx` obsahovat alespoň jednu tabulku na svém prvním snímku. Tabulka musí mít alespoň jeden řádek a jeden sloupec. Kód hledá [ITable](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itable/) místo aby předpokládal, že `getShapes().get_Item(0)` je tabulka.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("table-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            ITable table = findTable(presentation.getSlides().get_Item(0));
            if (table == null) {
                throw new IllegalStateException("The first slide must contain a table.");
            }
            if (table.getRows().size() == 0 || table.getColumns().size() == 0) {
                throw new IllegalStateException("The table must contain at least one cell.");
            }

            ITableFormatEffectiveData tableEffective = table.getTableFormat().getEffective();
            IRowFormatEffectiveData rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
            IColumnFormatEffectiveData columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
            ICellFormatEffectiveData cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

            System.out.println("Table fill: " + tableEffective.getFillFormat().getFillType());
            System.out.println("Row fill: " + rowEffective.getFillFormat().getFillType());
            System.out.println("Column fill: " + columnEffective.getFillFormat().getFillType());
            System.out.println("Final cell fill: " + cellEffective.getFillFormat().getFillType());
        } finally {
            presentation.dispose();
        }
    }

    private static ITable findTable(ISlide slide) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ITable) {
                return (ITable)shape;
            }
        }
        return null;
    }
}
```

Pokud potřebujete barvu místo pouze typu výplně, nejdříve zkontrolujte efektivní [getFillType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifillformateffectivedata/#getFillType--) , a potom přečtěte metodu, která odpovídá tomuto typu — například [getSolidFillColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifillformateffectivedata/#getSolidFillColor--) pro pevnou výplň.

## **Znovu načíst efektivní data po změnách**

Efektivní data popisují hierarchii formátování v okamžiku, kdy jsou vyřešena. Zavolejte `getEffective` znovu po změně čehokoli, co může v této hierarchii participovat, včetně:

- místního formátování objektu;
- výchozích nastavení odstavce nebo textového rámce;
- stylu tabulky, tabulky, sloupce, řádku nebo formátu buňky;
- formátování rozvržení nebo hlavního snímku;
- dat motivu nebo výchozích nastavení na úrovni prezentace;
- rozvržení nebo hlavního snímku přiřazeného ke snímku.

Neponechávejte objekt efektivních dat jako trvalý snímek. Aspose.Slides může interně některá efektivní data kešovat a pozdější volání `getEffective` může tato data aktualizovat. Pokud potřebujete porovnat hodnoty před a po změně, zkopírujte skalární hodnoty, které potřebujete — například výšku písma, barvu, zarovnání nebo šířku sklonu — do vlastních proměnných před provedením změny.

Chcete-li hodnotu změnit, aktualizujte příslušný místní objekt formátu a poté zavolejte `getEffective` pro ověření výsledku. Objektů efektivních dat jsou samy o sobě jen pro čtení.

## **Často kladené otázky**

**Jak zjistit, která úroveň poskytla efektivní hodnotu?**

Efektivní data obsahují finální hodnotu, nikoli její zdroj. Prohlédněte si příslušné místní objekty od nejkonkrétnější úrovně směrem ven. Pro text to může zahrnovat část, odstavec, textový rámec, rozvržení, hlavní snímek, motiv a výchozí nastavení prezentace. Nedefinované hodnoty jako `Float.NaN` nebo `null` naznačují, že vyhledávání pokračuje na další úrovni.

**Co se stane, když žádná úroveň nedefinuje vlastnost?**

Aspose.Slides vyřeší příslušnou výchozí hodnotu PowerPointu nebo knihovny. Tato vyřešená hodnota se objeví v efektivních datech, i když žádný místní objekt ji explicitně nedefinuje.

**Proč se efektivní hodnota někdy rovná místní hodnotě?**

Místní hodnota vyhrála výpočet dědičnosti. To je očekávané, když je vlastnost explicitně nastavena na objektu a žádné specifičtější pravidlo ji nepřepíše.

**Kdy mám používat místní data místo efektivních dat?**

Používejte místní data k inspekci nebo úpravě konkrétní úrovně formátování. Používejte efektivní data, když potřebujete finální vzhled po aplikaci dědičnosti, pravidel motivu a příslušných stylů. [Kompletní příklad srovnání](#compare-local-inherited-and-effective-values) demonstruje obojí ve stejném pracovním postupu.