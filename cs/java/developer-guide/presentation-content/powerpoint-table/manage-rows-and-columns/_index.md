---
title: Správa řádků a sloupců v tabulkách PowerPoint pomocí Java
linktitle: Řádky a sloupce
type: docs
weight: 20
url: /cs/java/manage-rows-and-columns/
keywords:
- řádek tabulky
- sloupec tabulky
- první řádek
- hlavička tabulky
- klonovat řádek
- klonovat sloupec
- kopírovat řádek
- kopírovat sloupec
- odstranit řádek
- odstranit sloupec
- formátování textu řádku
- formátování textu sloupce
- styl tabulky
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Spravujte řádky a sloupce tabulky v PowerPointu pomocí Aspose.Slides pro Java a urychlete úpravy prezentací a aktualizace dat."
---
## **Úvod**

Aspose.Slides for Java vám umožňuje spravovat strukturu tabulky a formátování v prezentacích PowerPoint prostřednictvím třídy [Table](https://reference.aspose.com/slides/java/com.aspose.slides/table/) a rozhraní [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/). Můžete určit řádek hlavičky, klonovat nebo odstraňovat řádky a sloupce a aplikovat formátování textu na celý řádek nebo sloupec.

Tento článek vysvětluje tyto operace na příkladech v jazyce Java. Také ukazuje, jak získat přednastavený styl tabulky, abyste jej mohli znovu použít. Indexy řádků a sloupců tabulky jsou nulové‑základní.

## **Ovládání výšky řádku**

Použijte [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-) k nastavení minimální výšky řádku v bodech. Jedná se o spodní mez, ne o pevnou výšku. [IRow.getHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#getHeight--) vrací skutečnou výšku. Přístup k řádku získáte přes [ITable.getRows](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getRows--).

Příklad načte soubor [row-height-input.pptx](row-height-input.pptx), který má tabulku jako první tvar na první snímku. Jeho první řádek začíná ve výšce 70 bodů. Buňky používají text Arial 18 bodů, zalomení řádku a okraje 6 bodů nahoře i dole; delší text ve druhém sloupci se zalamuje do více řádků. Příklad zvýší minimum na 100 bodů, potom ho sníží na 20 bodů, po každé změně vytiskne skutečnou výšku a uloží oba výsledky.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("row-height-input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    IRow row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    System.out.printf("Increased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx);

    row.setMinimalHeight(20);
    System.out.printf("Decreased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Se dodanou prezentací přidává zvýšení minima prostor do řádku. Snížení ho odebere, ale skutečná výška zůstane vyšší než 20 bodů, protože text a okraje buňky vyžadují více místa. Pouhé snížení minima nedokáže přinutit řádek podmínit výšku menší než prostor potřebný pro jeho obsah.

Několik faktorů ovlivňuje skutečnou výšku:

- **Text a velikost písma:** delší text, výslovné zalomení řádku nebo větší písmo může vyžadovat více svislého prostoru.
- **Zalamování a šířka sloupce:** při zapnutém zalamování může snížení šířky sloupce pomocí [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) vytvořit více řádků. Širší sloupec může svislý prostor snížit.
- **Okraje buňky:** [ICell.setMarginTop](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginTop-double-) a [ICell.setMarginBottom](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginBottom-double-) přidávají svislý prostor. [ICell.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginLeft-double-) a [ICell.setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginRight-double-) snižují šířku dostupnou pro text a mohou způsobit další zalamování.

U této tabulky bez sloučených buněk určuje buňka, která potřebuje nejvíce svislého místa, dolní limit pro celý řádek. Pro zkrácení řádku možná také musíte zkrátit text, snížit velikost písma nebo okraje, případně zvětšit sloupec.

Obrázky níže ukazují stejnou tabulku ve stejném měřítku. V ilustrovaných výsledcích byly skutečné výšky 70, 100 a 55,2 bodu: poslední řádek zůstal vyšší než jeho minimum 20 bodů. Přesná měření textu se mohou lišit podle fontů dostupných ve vašem prostředí. Stáhněte si uložené výsledky: [zvýšené minimum](row-height-increased.pptx) a [snížené minimum](row-height-decreased.pptx).

| Původní: minimum 70 pt, skutečná 70 pt | Zvýšené: minimum 100 pt, skutečná 100 pt | Snížené: minimum 20 pt, skutečná 55.2 pt |
| --- | --- | --- |
| ![Původní tabulka s prvním řádkem 70 bodů.](row-height-before.png) | ![Tabulka po zvýšení minimální výšky prvního řádku na 100 bodů.](row-height-increased.png) | ![Tabulka po snížení minimální výšky prvního řádku na 20 bodů; zalomený text udržuje řádek vyšší než minimum.](row-height-decreased.png) |

## **Nastavit první řádek jako hlavičku**

Použijte metodu [setFirstRow](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#setFirstRow-boolean-) k označení prvního řádku pro formátování hlavičky. Jeho vzhled závisí na stylu tabulky použitým na tabulku.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Přistupte k prvnímu snímku.
3. Přistupte k tabulce uložené jako první tvar na snímku.
4. Zapněte formátování hlavičky pro její první řádek.
5. Uložte upravenou prezentaci.

Příklad vyžaduje soubor `table.pptx` s tabulkou jako první tvar na první snímku. Zapíná formátování hlavičky pro první řádek a ukládá `First_row_header.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Klonovat řádek nebo sloupec tabulky**

Klonujte řádky nebo sloupce pro opětovné použití jejich obsahu a formátování. Můžete kopii připojit na konec tabulky nebo ji vložit na konkrétní pozici.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Přistupte k prvnímu snímku.
3. Definujte šířky sloupců a výšky řádků.
4. Přidejte tabulku metodou [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
5. Klonujte požadované řádky.
6. Klonujte požadované sloupce.
7. Uložte upravenou prezentaci.

Příklad vyžaduje soubor `Test.pptx` s alespoň jedním snímkem. Vytváří tabulku se třemi sloupci a pěti řádky, rozměry jsou uvedeny v bodech. Připojuje kopie prvního řádku a sloupce, potom vkládá kopie druhého řádku a sloupce na index 3 (čtvrtá pozice). Výsledná tabulka má sedm řádků a pět sloupců. Argument `false` zakazuje klonování do sousedních sloučených řádků nebo sloupců; tato tabulka nemá sloučené buňky.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 50, 50, 50 };
    double[] rowHeights = new double[] { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Odstranit řádek nebo sloupec z tabulky**

Odstraňte řádky nebo sloupce, které už v tabulce nejsou potřebné. Odstranění položky posune indexy řádků nebo sloupců, které po ní následují.

1. Vytvořte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Přistupte k prvnímu snímku.
3. Definujte šířky sloupců a výšky řádků.
4. Přidejte tabulku metodou [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
5. Odstraňte druhý řádek a druhý sloupec.
6. Uložte upravenou prezentaci.

Tento příklad vytváří tabulku tři × tři a odstraňuje řádek a sloupec na indexu 1, zůstává tak tabulka dvou × dvou v souboru `TestTable_out.pptx`. Rozměry jsou v bodech. Argument `false` zakazuje odstranění sousedních sloučených řádků nebo sloupců; tato tabulka nemá sloučené buňky.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 50, 30 };
    double[] rowHeights = new double[] { 30, 50, 30 };
    ITable table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavit formátování textu na úrovni řádku tabulky**

Aplikujte formátování textu na celý řádek, aby buňky zůstaly konzistentní. Můžete nastavit vlastnosti písma, formát odstavců a směr textu, aniž byste formátovali každou buňku zvlášť.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Přistupte k tabulce na první snímku.
3. Použijte [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) pro první řádek.
4. Použijte [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) a [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) pro první řádek.
5. Použijte [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) pro druhý řádek.
6. Uložte upravenou prezentaci.

Příklad vyžaduje soubor `table.pptx` s tabulkou jako první tvar na první snímku a alespoň dvěma řádky. Používá text 25 bodů, pravé zarovnání a pravý okraj odstavce 20 bodů pro první řádek, poté nastaví svislý text ve druhém řádku.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavit formátování textu na úrovni sloupce tabulky**

Aplikujte formátování textu na celý sloupec, aby buňky zůstaly konzistentní. Můžete nastavit vlastnosti písma, formát odstavců a směr textu, aniž byste formátovali každou buňku zvlášť.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Přistupte k tabulce na první snímku.
3. Použijte [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) pro první sloupec.
4. Použijte [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) a [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) pro první sloupec.
5. Použijte [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) pro druhý sloupec.
6. Uložte upravenou prezentaci.

Příklad vyžaduje soubor `table.pptx` s tabulkou jako první tvar na první snímku a alespoň dvěma sloupci. Používá text 25 bodů, pravé zarovnání a pravý okraj odstavce 20 bodů pro první sloupec, poté nastaví svislý text ve druhém sloupci.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Získat vlastnosti stylu tabulky**

Použijte metodu [getStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getStylePreset--) k načtení přednastaveného stylu aplikovaného na tabulku a jeho opětovnému použití na jiné tabulce. Tento metod identifikuje přednastavení místo individuálních přepisů formátování buněk.

Příklad vytvoří tabulku, použije [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/java/com.aspose.slides/tablestylepreset/#DarkStyle1) a načte zpět přednastavení. Vypíše celočíselnou hodnotu odpovídající `DarkStyle1` a uloží tabulku v souboru `table.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 150 };
    double[] rowHeights = new double[] { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println(stylePreset);

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Mohu na již vytvořenou tabulku použít motivy/styly PowerPointu?**

Ano. Tabulka dědí motiv snímku/podkladu/mistra a můžete i nad tímto motivem přepsat výplně, ohraničení a barvy textu.

**Mohu řadit řádky tabulky jako v Excelu?**

Ne, tabulky Aspose.Slides nemají vestavěné řazení ani filtry. Seřaďte data v paměti nejprve a poté znovu naplňte řádky tabulky v požadovaném pořadí.

**Mohu mít pruhované (pruhované) sloupce a zároveň zachovat vlastní barvy u konkrétních buněk?**

Ano. Zapněte pruhované sloupce a poté přepište konkrétní buňky místním formátováním; formátování na úrovni buňky má přednost před stylem tabulky.