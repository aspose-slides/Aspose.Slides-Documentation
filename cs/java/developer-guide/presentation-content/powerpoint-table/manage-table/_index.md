---
title: Správa tabulek v prezentaci v Java
linktitle: Spravovat tabulku
type: docs
weight: 10
url: /cs/java/manage-table/
keywords:
- přidat tabulku
- vytvořit tabulku
- přístup k tabulce
- poměr stran
- zarovnat text
- formátování textu
- styl tabulky
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Vytvářejte a upravujte tabulky v prezentacích PowerPoint pomocí Aspose.Slides pro Java. Objevte jednoduché ukázky kódu, které zjednoduší vaše pracovní postupy s tabulkami."
---
## **Úvod**

Tabulky v PowerPointu organizují informace do řádků a sloupců, což usnadňuje čtení a porovnávání hodnot.

Aspose.Slides poskytuje třídu [Table](https://reference.aspose.com/slides/java/com.aspose.slides/table/) , rozhraní [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) , třídu [Cell](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) , rozhraní [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) a další typy, které vám umožňují vytvářet, aktualizovat a spravovat tabulky v prezentacích.

## **Vytvoření tabulky od začátku**

Vytvořte tabulku zadáním její polohy, šířek sloupců a výšek řádků. Po přidání na snímek můžete formátovat okraje buněk, sloučit buňky a vložit text.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. Získejte odkaz na snímek podle jeho indexu.
3. Definujte pole šířek sloupců v bodech.
4. Definujte pole výšek řádků v bodech.
5. Přidejte objekt [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) na snímek pomocí metody [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) .
6. Procházejte každou [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) , abyste použili formátování na horní, spodní, pravý a levý okraj.
7. Sloučte první dvě buňky v prvním řádku tabulky.
8. Získejte přístup ke sloučené buňce pomocí její metody [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) .
9. Nastavte text ve sloučené buňce.
10. Uložte upravenou prezentaci.

Níže uvedený příklad vytvoří tabulku se třemi sloupci a pěti řádky na souřadnicích (100, 50) bodů. Použije červené okraje o šířce 5 bodů, sloučí první dvě buňky v prvním řádku a výsledek uloží jako `table.pptx`.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Číslování ve standardní tabulce**

Ve standardní tabulce jsou indexy buněk založeny na nule a používají pořadí (sloupec, řádek). První buňka má index (0, 0).

Například buňky v tabulce se 4 sloupci a 4 řádky jsou číslovány takto:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Tento příklad vytvoří výše ilustrovanou tabulku 4 × 4 se šířkami sloupců a výškami řádků 70 bodů a červenými okraji buněk o šířce 5 bodů. Souřadnice ukazují indexy buněk; příklad nechá buňky prázdné a uloží tabulku jako `StandardTables_out.pptx`.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Přístup k existující tabulce**

Tabulky jsou uloženy v kolekci tvarů snímku. Procházejte tvary a najděte tabulku, poté použijte rozhraní [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) , abyste mohli číst nebo aktualizovat její buňky.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. Získejte odkaz na snímek obsahující tabulku podle jeho indexu.
3. Procházejte objekty [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) a zastavte se, když najdete tabulku. Pokud snímek obsahuje několik tabulek, použijte [getAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getAlternativeText--) , abyste identifikovali tu, kterou potřebujete.
4. Aktualizujte text v cílové buňce.
5. Uložte upravenou prezentaci.

Níže uvedený příklad otevře `UpdateExistingTable.pptx` a najde první tabulku na prvním snímku. Nastaví buňku ve sloupci 0, řádek 1 na `New` a výsledek uloží jako `table1_out.pptx`. Vstup musí obsahovat alespoň jeden snímek a první tabulka na tomto snímku musí mít alespoň jeden sloupec a dva řádky.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("UpdateExistingTable.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof ITable) {
            table = (ITable) shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Pro změnu velikosti řádku v existující tabulce a pochopení, proč může skutečná výška přesáhnout požadovaný minimum, viz [Control Row Height](/slides/cs/java/manage-rows-and-columns/#control-row-height).

## **Najděte buňku, která vlastní textový rámec**

Když obecný kód pro zpracování textu získá [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) z tabulky, použijte metodu [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) k získání vlastnické [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) . Pro textový rámec buňky tabulky metoda [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) vrací vlastníka a [ITextFrame.getParentShape](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentShape--) vrací `null`, i když samotná tabulka je tvar.

Souřadnice buňky jsou dostupné pomocí jen pro čtení metod [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) a [ICell.getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) . [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) také poskytuje jen pro čtení navigaci: vrací vlastníka, ale nemění vlastnictví. Vždy před použitím zkontrolujte, zda vrácená buňka není `null`.

Pro kompletní příklad, který identifikuje vlastníky buněk tabulky a tvarů, včetně tvarů spojených s uzly SmartArt, viz [Search and Replace Text](/slides/cs/java/search-and-replace-text/).

## **Zarovnání textu v tabulce**

Můžete ovládat vertikální ukotvení a směr textu jednotlivých buněk tabulky. Příklad v této sekci zarovná text ve středu první buňky a otočí jej o 270 stupňů.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte objekt [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) na snímek.
4. Získejte přístup k objektu [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) z tabulky.
5. Získejte první [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) a nastavte jeho text a barvu.
6. Nastavte vertikální ukotvení buňky a směr textu pomocí [setTextAnchorType](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setTextAnchorType-byte-) a [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setTextVerticalType-byte-) .
7. Uložte upravenou prezentaci.

Tento příklad vytvoří tabulku 4 × 4 se šířkami sloupců 120 bodů a výškami řádků 100 bodů. Naformátuje text v buňce (0, 0), přidá hodnoty do zbývajících buněk v prvním řádku a výsledek uloží jako `Vertical_Align_Text_out.pptx`.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 120, 120, 120, 120 };
    double[] rowHeights = { 100, 100, 100, 100 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    ITextFrame textFrame = table.get_Item(0, 0).getTextFrame();
    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);

    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ICell cell = table.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavení formátování textu na úrovni tabulky**

Použijte [setTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulktextformattable/#setTextFormat-com.aspose.slides.IPortionFormat-) , abyste aplikovali formátování textu na všechny buňky v tabulce. Jeho přetížení přijímají formátování úseku, odstavce a textového rámce, takže můžete nastavit tyto vlastnosti bez procházení jednotlivých buněk.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. Získejte odkaz na snímek podle jeho indexu.
3. Získejte objekt [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) ze snímku.
4. Nastavte velikost písma pomocí [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) pro text.
5. Nastavte zarovnání odstavce a pravý okraj pomocí [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) a [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) .
6. Nastavte směr textu pomocí [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) .
7. Uložte upravenou prezentaci.

Níže uvedený příklad otevře `table.pptx`, který musí obsahovat alespoň jeden snímek s tabulkou jako jejím prvním tvarem. Nastaví velikost písma na 25 bodů, zarovná odstavce vpravo s pravým okrajem 20 bodů a nastaví text vertikální. Formátovaná prezentace je uložena jako `result.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Získání vlastností stylu tabulky**

Použijte [getStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getStylePreset--) , abyste načetli předdefinovaný styl tabulky, a [setStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#setStylePreset-int-) , abyste jej přiřadili. Tento příklad použije [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/java/com.aspose.slides/tablestylepreset/) na jednu tabulku, vypíše hodnotu předvolby a přiřadí stejnou předvolbu druhé tabulce. Obě tabulky jsou uloženy v `table-style.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 100, 150 };
    double[] rowHeights = { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    ITable anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Uzamčení poměru stran tabulky**

Poměr stran tabulky je poměr její šířky k výšce. Použijte [setAspectRatioLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/#setAspectRatioLocked-boolean-) , abyste tento poměr pro tabulku uzamkli.

Níže uvedený příklad otevře `pres.pptx`, který musí obsahovat alespoň jeden snímek s tabulkou jako jejím prvním tvarem. Vytiskne aktuální stav uzamčení, zapne uzamčení poměru stran, vytiskne aktualizovaný stav (`true`) a výsledek uloží jako `pres-out.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable) slide.getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Mohu povolit směr čtení zprava doleva (RTL) pro celou tabulku a text v jejích buňkách?**

Ano. Tabulka poskytuje metodu [setRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/table/#setRightToLeft-boolean-) , a odstavce mají [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) . Použití obou zajišťuje správné RTL pořadí a vykreslení uvnitř buněk.

**Jak mohu zabránit uživatelům v přesunu nebo změně velikosti tabulky v konečném souboru?**

Použijte [shape locks](/slides/cs/java/applying-protection-to-presentation/) , abyste zakázali přesun, změnu velikosti, výběr atd. Tato zamknutí se vztahují i na tabulky.

**Je podporováno vložení obrázku do buňky jako pozadí?**

Ano. Můžete nastavit [picture fill](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) pro buňku; obrázek pokryje oblast buňky podle zvoleného režimu (roztažení nebo dlaždice).