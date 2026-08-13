---
title: Získání efektivních vlastností tvaru z prezentací v Javě
linktitle: Efektivní vlastnosti
type: docs
weight: 50
url: /cs/java/shape-effective-properties/
keywords:
- vlastnosti tvaru
- vlastnosti kamery
- světelná sestava
- zkosený tvar
- textový rámec
- textový styl
- výška písma
- formát výplně
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Dozvíte se, jak pomocí Aspose.Slides pro Javu rozlišovat místní, zděděné a efektivní formátování tvarů v prezentacích PowerPoint."
---
## **Rozumět místním, zděděným a efektivním vlastnostem**

Formátování PowerPointu může pocházet z několika míst. Hodnota uložená přímo na objektu je jeho **místní hodnota**. Pokud tato hodnota není nastavena, PowerPoint se podívá na nadřazené zdroje formátování, jako je výchozí nastavení odstavce, textový styl, rozvržení nebo hlavní snímek, motiv nebo výchozí nastavení na úrovni prezentace. Tyto hodnoty jsou **zděděné hodnoty**. Hodnota, která zůstane po vyřešení celé hierarchie, je **efektivní hodnota**—hodnota použitá k vykreslení objektu.

Například textová část nemusí definovat vlastní výšku písma. Její místní [getFontHeight](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseportionformat/#getFontHeight--) hodnota je pak `Float.NaN`, což znamená "není zde nastavena". Část může zdědit výšku ze svého odstavce, výchozího textového stylu prezentace nebo jiného použitelného zdroje. Volání [getEffective](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iportionformat/#getEffective--) na formát části vrátí konečnou vyřešenou výšku.

Používejte oba typy formátovacích dat pro různé účely:

- Čtěte nebo změňte místní formátovací objekt, například [IPortionFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iportionformat/), pokud potřebujete kontrolovat, kde je hodnota definována.
- Čtěte objekt efektivních dat, například [IPortionFormatEffectiveData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iportionformateffectivedata/), pokud potřebujete konečný vykreslený výsledek. Efektivní data jsou pouze pro čtení.

## **Porovnat místní, zděděné a efektivní hodnoty**

Následující kompletní příklad vytvoří tvar a aplikuje výšky písma na úrovních prezentace, odstavce a části. Každý krok vypíše hodnoty definované na těchto úrovních a výslednou efektivní hodnotu pro stejnou textovou část. Také ukazuje, proč je nutné po změnách formátování znovu přečíst efektivní data.

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

            // Místní hodnota v části přepíše obě zděděné hodnoty.
            portion.getPortionFormat().setFontHeight(36);
            printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

            // Změna zděděné hodnoty nepřepisuje existující místní hodnotu.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
            printFontHeights("The local value still has priority", presentation, paragraph, portion);

            // Vymažte místní hodnotu. Část nyní znovu dědí od odstavce.
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

Priorita v tomto příkladu je místní formátování části, poté formátování odstavce a nakonec výchozí nastavení prezentace. Ostatní objekty mohou mít různé řetězce dědičnosti, ale princip je stejný: konkrétnější explicitní hodnota vyhrává a [getEffective](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iportionformat/#getEffective--) vrací konečný výsledek.

## **Získat efektivní textové vlastnosti**

Formátování textu je rozděleno mezi několik objektů:

- [ITextFrameFormat.getEffective()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframeformat/#getEffective--) řeší vlastnosti textového rámce, jako jsou okraje, ukotvení, automatické přizpůsobení a vertikální směr textu.
- [ITextStyle.getEffective()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextstyle/#getEffective--) řeší formátování odstavce pro každou úroveň textového stylu.
- [IParagraphFormat.getEffective()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#getEffective--) řeší vlastnosti odstavce, jako jsou zarovnání, odsazení a odrážky.
- [IPortionFormat.getEffective()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iportionformat/#getEffective--) řeší vlastnosti znaků, jako jsou výška písma, typ písma, barva, tučné a kurzíva.

Pro další příklad musí soubor `text-formatting.pptx` obsahovat alespoň jeden snímek a jednu [AutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/autoshape/) s nevyprázdněným textovým rámcem. AutoShape může být umístěna na libovolném místě ve sbírce tvarů; kód vyhledá vhodný objekt a před použitím jej ověří.

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

## **Získat efektivní 3D vlastnosti**

[IThreeDFormat.getEffective()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformat/#getEffective--) vrací jeden objekt [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformateffectivedata/) , který seskupuje všechna vyřešená 3D nastavení. Jeho metody [getCamera](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformateffectivedata/#getCamera--), [getLightRig](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformateffectivedata/#getLightRig--), [getBevelTop](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformateffectivedata/#getBevelTop--) a [getBevelBottom](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ithreedformateffectivedata/#getBevelBottom--) vystavují odpovídající efektivní data. Čtení těchto souvisejících nastavení dohromady usnadňuje pochopení konečného 3D vzhledu tvaru.

Pro tento příklad musí soubor `shape-3d.pptx` obsahovat alespoň jeden tvar na svém prvním snímku. Použijte 3D kameru, osvětlení nebo nastavení zkosení na tento tvar, pokud chcete, aby výstup obsahoval hodnoty odlišné od výchozích.

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

## **Získat efektivní formátování tabulky**

Formátování tabulky může pocházet ze stylu tabulky a z formátů aplikovaných na celou tabulku, sloupec, řádek nebo jednotlivou buňku. V případě konfliktů mezi explicitně definovanými výplněmi je prioritou buňka, řádek, sloupec a pak celá tabulka. Efektivní formát buňky je finální formát používaný pro vykreslení této buňky.

Pro tento příklad musí soubor `table-formatting.pptx` obsahovat alespoň jednu tabulku na svém prvním snímku. Tabulka musí mít alespoň jeden řádek a jeden sloupec. Kód vyhledá [ITable](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itable/) místo toho, aby předpokládal, že `getShapes().get_Item(0)` je tabulka.

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

Pokud potřebujete barvu místo pouhého typu výplně, nejprve zkontrolujte efektivní [getFillType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifillformateffectivedata/#getFillType--), a poté si přečtěte metodu, která odpovídá tomuto typu—například [getSolidFillColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifillformateffectivedata/#getSolidFillColor--) pro plnou výplň.

## **Znovu přečíst efektivní data po změnách**

Efektivní data popisují hierarchii formátování v okamžiku, kdy jsou vyřešena. Po změně čehokoli, co může v hierarchii participovat, zavolejte `getEffective` znovu, včetně:

- místního formátování objektu;
- výchozích nastavení odstavce nebo textového rámce;
- stylu tabulky, tabulky, sloupce, řádku nebo formátu buňky;
- formátování rozvržení nebo hlavního snímku;
- dat motivu nebo výchozích nastavení na úrovni prezentace;
- rozvržení nebo hlavního snímku přiřazeného ke snímku.

Neponechávejte objekt efektivních dat jako trvalý snímek. Aspose.Slides může interně cachovat některá efektivní data a pozdější volání `getEffective` může tato data obnovit. Pokud potřebujete porovnat hodnoty před a po změně, zkopírujte skalární hodnoty, které potřebujete — například výšku písma, barvu, zarovnání nebo šířku zkosení — do vlastních proměnných před provedením změny.

K změně hodnoty aktualizujte příslušný místní formátovací objekt a poté zavolejte `getEffective` k ověření výsledku. Objektová data efektivní jsou sama o sobě pouze pro čtení.

## **Často kladené otázky**

**Jak mohu zjistit, která úroveň poskytla efektivní hodnotu?**

Efektivní data obsahují konečnou hodnotu, nikoli její zdroj. Prozkoumejte příslušné místní objekty od nejkonkrétnější úrovně směrem ven. Pro text to může zahrnovat část, odstavec, textový rámec, rozvržení, hlavní snímek, motiv a výchozí nastavení prezentace. Nedefinované hodnoty jako `Float.NaN` nebo `null` naznačují, že hledání pokračuje na další úroveň.

**Co se stane, když žádná úroveň nedefinuje vlastnost?**

Aspose.Slides vyřeší příslušnou výchozí hodnotu PowerPointu nebo knihovny. Tato vyřešená hodnota se objeví v efektivních datech, i když ji žádný místní objekt explicitně nedefinuje.

**Proč se efektivní hodnota někdy rovná místní hodnotě?**

Místní hodnota vyhrála výpočet dědičnosti. To se očekává, když je vlastnost explicitně nastavena na objektu a žádné konkrétnější pravidlo ji nepřepíše.

**Kdy mám použít místní data místo efektivních dat?**

Používejte místní data k inspekci nebo úpravě konkrétní úrovně formátování. Používejte efektivní data, když potřebujete finální vzhled po vyřešení dědičnosti, pravidel motivu a příslušných stylů. [Kompletní příklad porovnání](#compare-local-inherited-and-effective-values) demonstruje obojí ve stejném postupu.