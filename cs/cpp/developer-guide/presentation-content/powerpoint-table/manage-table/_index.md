---
title: Správa tabulek v prezentacích v C++
linktitle: Spravovat tabulku
type: docs
weight: 10
url: /cs/cpp/manage-table/
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
- C++
- Aspose.Slides
description: "Vytvářejte a upravujte tabulky v PowerPoint snímcích pomocí Aspose.Slides pro C++. Objevte jednoduché ukázky kódu, které zjednoduší vaše pracovní postupy s tabulkami."
---
## **Úvod**

Tabulka v PowerPointu je efektivní způsob, jak zobrazit a představit informace. Informace v mřížce buněk (uspořádané v řádcích a sloupcích) jsou přímé a snadno pochopitelné.

Aspose.Slides poskytuje třídu [Table](https://reference.aspose.com/slides/cs/cpp/aspose.slides/table/) , rozhraní [ITable](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itable/) , třídu [Cell](https://reference.aspose.com/slides/cs/cpp/aspose.slides/cell/) , rozhraní [ICell](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icell/) a další typy, které vám umožňují vytvářet, aktualizovat a spravovat tabulky ve všech druzích prezentací. 

## **Vytvoření tabulky od začátku**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Definujte pole `columnWidth`.
4. Definujte pole `rowHeight`.
5. Přidejte objekt [ITable](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itable/) na snímek pomocí metody [AddTable()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/addtable/) .
6. Procházejte každou [ICell](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icell/) , abyste aplikovali formátování na horní, spodní, pravý a levý okraj.
7. Sloučte první dvě buňky první řádky tabulky. 
8. Získejte přístup k [TextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/textframe/) buňky [ICell](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icell/) .
9. Přidejte nějaký text do [TextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/textframe/) .
10. Uložte upravenou prezentaci.

```c++
// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
auto pres = System::MakeObject<Presentation>();

// Přistupuje k prvnímu snímku
auto sld = pres->get_Slides()->idx_get(0);

// Definuje sloupce s šířkami a řádky s výškami
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// Přidává tvar tabulky na snímek
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Nastavuje formát okrajů pro každou buňku
for (int32_t row = 0; row < tbl->get_Rows()->get_Count(); row++)
{
    for (int32_t cell = 0; cell < tbl->get_Rows()->idx_get(row)->get_Count(); cell++)
    {
        auto cellFormat = tbl->get_Rows()->idx_get(row)->idx_get(cell)->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType((FillType::Solid));
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}
// Sloučí buňky 1 a 2 v řádku 1
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// Přidá text do sloučené buňky
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Merged Cells");

// Uloží prezentaci na disk
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Číslování ve standardní tabulce**

Ve standardní tabulce je číslování buněk jednoduché a začíná od nuly. První buňka v tabulce má index 0,0 (sloupec 0, řádek 0). 

Například buňky v tabulce se 4 sloupci a 4 řádky jsou číslovány takto:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Tento C++ kód ukazuje, jak určit číslování buněk v tabulce:

```c++
// Vytváří instanci třídy Presentation, která představuje soubor PPTX
auto pres = System::MakeObject<Presentation>();

// Získává první snímek
auto sld = pres->get_Slides()->idx_get(0);

// Definuje sloupce s šířkami a řádky s výškami
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// Přidává tvar tabulky na snímek
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Nastavuje formát okrajů pro každou buňku
for (const auto& row : tbl->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();
        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

// Ukládá prezentaci na disk
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **Přístup k existující tabulce**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) .
2. Získejte odkaz na snímek obsahující tabulku pomocí jeho indexu. 
3. Vytvořte objekt [ITable](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itable/) a nastavte jej na null.
4. Procházejte všechny objekty [IShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/) , dokud nenajdete tabulku.

   Pokud máte podezření, že snímek, se kterým pracujete, obsahuje jedinou tabulku, můžete jednoduše zkontrolovat všechny tvary, které obsahuje. Když je tvar rozpoznán jako tabulka, můžete jej přetypovat na objekt [Table](https://reference.aspose.com/slides/cs/cpp/aspose.slides/table/) . Pokud však snímek obsahuje několik tabulek, je lepší hledat požadovanou tabulku pomocí jejího [set_AlternativeText()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/set_alternativetext/) .

5. Použijte objekt [ITable](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itable/) , abyste pracovali s tabulkou. V níže uvedeném příkladu jsme přidali nový řádek do tabulky.
6. Uložte upravenou prezentaci.

```c++
// Vytváří instanci třídy Presentation, která představuje soubor PPTX
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// Získává první snímek
auto sld = pres->get_Slides()->idx_get(0);

// Inicializuje nulovou tabulku
System::SharedPtr<ITable> tbl;

// Prochází tvary a nastavuje odkaz na nalezenou tabulku
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Nastavuje text pro první sloupec ve druhém řádku
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// Ukládá upravenou prezentaci na disk
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **Zarovnání textu v tabulce**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Přidejte objekt [ITable](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itable/) na snímek. 
4. Získejte přístup k objektu [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/) z tabulky. 
5. Získejte přístup k [IParagraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraph/) objektu [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/) .
6. Zarovnejte text vertikálně.
7. Uložte upravenou prezentaci.

```c++
// Vytvoří instanci třídy Presentation
auto presentation = System::MakeObject<Presentation>();

// Získá první snímek 
auto slide = presentation->get_Slides()->idx_get(0);

// Definuje sloupce s šířkami a řádky s výškami
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// Přidá tvar tabulky na snímek
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// Získá přístup k textovému rámci
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// Vytvoří objekt Paragraph pro textový rámec
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Vytvoří objekt Portion pro odstavec
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Zarovnává text vertikálně
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// Uloží prezentaci na disk
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Nastavení formátování textu na úrovni tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Získejte přístup k objektu [ITable](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itable/) ze snímku.
4. Nastavte [set_FontHeight()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/baseportionformat/set_fontheight/) pro text. 
5. Nastavte [set_Alignment()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/set_alignment/) a [set_MarginRight()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/set_marginright/) . 
6. Nastavte [set_TextVerticalType()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/textframeformat/set_textverticaltype/) .
7. Uložte upravenou prezentaci. 

```c++
// Vytvoří instanci třídy Presentation
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// Předpokládejme, že první tvar na první snímku je tabulka
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// Nastavuje výšku písma buněk tabulky
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// Nastavuje zarovnání textu buněk tabulky a pravý okraj v jednom volání
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// Nastavuje vertikální typ textu buněk tabulky
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Získání vlastností stylu tabulky**

Aspose.Slides vám umožňuje načíst vlastnosti stylu tabulky, abyste je mohli použít pro jinou tabulku nebo jinde. Tento C++ kód ukazuje, jak získat vlastnosti stylu z předdefinovaného stylu tabulky:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Uzamčení poměru stran tabulky**

Poměr stran geometrického tvaru je poměr jeho rozměrů v různých dimenzích. Aspose.Slides poskytuje vlastnost `AspectRatioLocked()` , která vám umožňuje uzamknout nastavení poměru stran pro tabulky a další tvary. 

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **Často kladené otázky**

**Mohu povolit směr čtení zprava doleva (RTL) pro celou tabulku a text v jejích buňkách?**

Ano. Tabulka nabízí metodu [set_RightToLeft](https://reference.aspose.com/slides/cs/cpp/aspose.slides/table/set_righttoleft/) , a odstavce mají [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/cs/cpp/aspose.slides/paragraphformat/set_righttoleft/) . Použití obou zajišťuje správné pořadí RTL a vykreslení uvnitř buněk.

**Jak mohu zabránit uživatelům v přesouvání nebo měnění velikosti tabulky v konečném souboru?**

Použijte [shape locks](/slides/cs/cpp/applying-protection-to-presentation/) , abyste zakázali přesouvání, změnu velikosti, výběr atd. Tyto zámky se vztahují i na tabulky.

**Je podporováno vkládání obrázku do buňky jako pozadí?**

Ano. Pro buňku můžete nastavit [picture fill](https://reference.aspose.com/slides/cs/cpp/aspose.slides/picturefillformat/) , obrázek pak pokryje oblast buňky podle zvoleného režimu (roztažení nebo dlaždice).