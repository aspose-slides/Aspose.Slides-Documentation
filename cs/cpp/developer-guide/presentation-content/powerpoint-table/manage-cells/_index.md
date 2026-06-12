---
title: Správa buněk tabulky v prezentacích pomocí C++
linktitle: Správa buněk
type: docs
weight: 30
url: /cs/cpp/manage-cells/
keywords:
- buňka tabulky
- sloučení buněk
- odstranění okraje
- rozdělení buňky
- obrázek v buňce
- barva pozadí
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Jednoduše spravujte buňky tabulky v PowerPoint pomocí Aspose.Slides pro C++. Ovládněte přístup, úpravu a stylování buněk rychle pro plynulou automatizaci snímků."
---
## **Přehled**

Aspose.Slides vám umožňuje přistupovat k buňkám tabulek a upravovat je v prezentacích PowerPoint. Tento článek vysvětluje, jak identifikovat sloučené buňky tabulky, odstranit okraje buněk, pracovat s číslováním buněk po sloučení nebo rozdělení buněk, změnit barvu pozadí buňky a přidat obrázek do buňky tabulky. Příklady ukazují, jak vytvořit nebo otevřít prezentaci, získat tabulku ze snímku, aktualizovat formátování buněk pomocí vlastností buňky a uložit upravenou prezentaci jako soubor PPTX.

## **Identifikace sloučené buňky**
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
2. Získejte tabulku z prvního snímku. 
3. Procházejte řádky a sloupce tabulky, abyste našli sloučené buňky.
4. Vytiskněte zprávu, když jsou nalezeny sloučené buňky.

``` cpp
auto pres = System::MakeObject<Presentation>(u"SomePresentationWithTable.pptx");
auto table = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// assuming that Slide#0.Shape#0 is a table
for (int32_t i = 0; i < table->get_Rows()->get_Count(); i++)
{
    for (int32_t j = 0; j < table->get_Columns()->get_Count(); j++)
    {
        auto currentCell = table->get_Rows()->idx_get(i)->idx_get(j);
        if (currentCell->get_IsMergedCell())
        {
            Console::WriteLine(String::Format(u"Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.", 
                i, j, currentCell->get_RowSpan(), currentCell->get_ColSpan(), currentCell->get_FirstRowIndex(), currentCell->get_FirstColumnIndex()));
        }
    }
}
```

## **Odstranění okrajů buněk tabulky**
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
2. Získejte referenci na snímek pomocí jeho indexu. 
3. Definujte pole sloupců s šířkou.
4. Definujte pole řádků s výškou.
5. Přidejte tabulku do snímku pomocí metody `AddTable`.
6. Procházejte každou buňku a vymažte horní, dolní, pravý a levý okraj.
7. Uložte upravenou prezentaci jako soubor PPTX.

``` cpp
// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
auto pres = MakeObject<Presentation>();
// Přistupuje k prvnímu snímku
auto sld = pres->get_Slides()->idx_get(0);

// Definuje sloupce se šířkami a řádky s výškami
auto dblCols = MakeArray<double>({ 50, 50, 50, 50 });
auto dblRows = MakeArray<double>({ 50, 30, 30, 30, 30 });

// Přidá tvar tabulky do snímku
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Nastaví formát okrajů pro každou buňku
for (const auto& row : System::IterateOver(tbl->get_Rows()))
{
    for (const auto& cell : System::IterateOver(row))
    {
        cell->get_CellFormat()->get_BorderTop()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderRight()->get_FillFormat()->set_FillType(FillType::NoFill);
    }
}

// Zapíše soubor PPTX na disk
pres->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **Číslování ve sloučených buňkách**
Pokud sloučíme 2 páry buněk (1, 1) x (2, 1) a (1, 2) x (2, 2), výsledná tabulka bude číslovaná. Tento C# kód demonstruje proces:

```c++
const String outPath = u"../out/MergeCells_out.pptx";

// Načte požadovanou prezentaci
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Přistupuje k prvnímu snímku
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Definuje sloupce se šířkami a řádky s výškami
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Přidá tvar tabulky do snímku
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Nastaví formát okraje pro každou buňku
for (int x = 0; x < table->get_Rows()->get_Count(); x++)
{
    SharedPtr<IRow> row = table->get_Rows()->idx_get(x);
    for (int y = 0; y < row->get_Count(); y++)
    {
        SharedPtr<ICell> cell = row->idx_get(y);

        cell->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderTop()->set_Width(5);

        cell->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderBottom()->set_Width(5);

        cell->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderLeft()->set_Width(5);

        cell->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderRight()->set_Width(5);

    }

}
// Sloučí buňky (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Sloučí buňky (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Uloží soubor PPTX na disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Poté buňky dále sloučíme sloučením (1, 1) a (1, 2). Výsledkem je tabulka obsahující velkou sloučenou buňku uprostřed: 

```c++
// Cesta k adresáři dokumentů.
const String outPath = u"../out/MergeCells_out.pptx";

// Načte požadovanou prezentaci
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Přistupuje k prvnímu snímku
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Definuje sloupce se šířkami a řádky s výškami
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Přidá tvar tabulky do snímku
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Nastaví formát okraje pro každou buňku
for (int x = 0; x < table->get_Rows()->get_Count(); x++)
{
    SharedPtr<IRow> row = table->get_Rows()->idx_get(x);
    for (int y = 0; y < row->get_Count(); y++)
    {
        SharedPtr<ICell> cell = row->idx_get(y);

        cell->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderTop()->set_Width(5);

        cell->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderBottom()->set_Width(5);

        cell->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderLeft()->set_Width(5);

        cell->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderRight()->set_Width(5);

    }

}

// Sloučí buňky (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Sloučí buňky (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Uloží soubor PPTX na disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Číslování v rozdělené buňce**
V předchozích příkladech, když byly buňky tabulky sloučeny, číslování nebo číselný systém v ostatních buňkách se nezměnil. 

Tentokrát vezmeme běžnou tabulku (tabulku bez sloučených buněk) a pak se pokusíme rozdělit buňku (1,1), abychom získali zvláštní tabulku. Měli byste věnovat pozornost číslování této tabulky, které může působit podivně. Přesto je to způsob, jakým Microsoft PowerPoint čísluje buňky tabulky, a Aspose.Slides dělá totéž. 

Tento C++ kód demonstruje popsaný proces:

```c++
// Cesta k adresáři dokumentů.
const String outPath = u"../out/CellSplit_out.pptx";

// Načte požadovanou prezentaci
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Přistupuje k prvnímu snímku
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Definuje sloupce se šířkami a řádky s výškami
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Přidá tvar tabulky do snímku
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Nastaví formát okraje pro každou buňku
for (int x = 0; x < table->get_Rows()->get_Count(); x++)
{
    SharedPtr<IRow> row = table->get_Rows()->idx_get(x);
    for (int y = 0; y < row->get_Count(); y++)
    {
        SharedPtr<ICell> cell = row->idx_get(y);

        cell->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderTop()->set_Width(5);

        cell->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderBottom()->set_Width(5);

        cell->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderLeft()->set_Width(5);

        cell->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderRight()->set_Width(5);

    }

}

// Sloučí buňky (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Sloučí buňky (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);

// Rozdělí buňku (1, 1). 
table->idx_get(1, 1)->SplitByWidth(table->idx_get(2, 1)->get_Width() / 2);

// Uloží soubor PPTX na disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Změna barvy pozadí buňky tabulky**

Tento C++ kód ukazuje, jak změnit barvu pozadí buňky tabulky:

``` cpp

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
auto dblCols = System::MakeArray<double>({150, 150, 150, 150});
auto dblRows = System::MakeArray<double>({50, 50, 50, 50, 50});
        
// vytvoří novou tabulku
auto table = slide->get_Shapes()->AddTable(50.0f, 50.0f, dblCols, dblRows);
        
// nastaví barvu pozadí buňky 
System::SharedPtr<ICell> cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        
presentation->Save(u"cell_background_color.pptx", Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Přidání obrázku do buňky tabulky**
1. Vytvořte instanci třídy `Presentation`.
2. Získejte referenci na snímek pomocí jeho indexu.
3. Definujte pole sloupců s šířkou.
4. Definujte pole řádků s výškou.
5. Přidejte tabulku do snímku pomocí metody `AddTable`. 
6. Vytvořte objekt `Bitmap` pro uložení souboru obrázku.
7. Přidejte bitmapový obrázek do objektu `IPPImage`.
8. Nastavte `FillFormat` buňky tabulky na `Picture`.
9. Přidejte obrázek do první buňky tabulky.
10. Uložte upravenou prezentaci jako soubor PPTX

Tento C# kód ukazuje, jak umístit obrázek do buňky tabulky při vytváření tabulky:

```c++
// Cesta k adresáři dokumentů.
const String outPath = u"../out/Image_In_TableCell_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// Načte požadovanou prezentaci
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Přistupuje k prvnímu snímku
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Definuje sloupce se šířkami a řádky s výškami
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 150);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 100);
System::ArrayPtr<double> total_for_Cat = System::MakeObject<System::Array<double>>(5, 0);

// Přidá tvar tabulky do snímku
auto tbl = islide->get_Shapes()->AddTable(50, 50, dblCols, dblRows);

// Načte obrázek
auto img = Images::FromFile(ImagePath);

// Přidá obrázek do kolekce obrázků prezentace
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(img);


// Přidá obrázek do první buňky tabulky
tbl->idx_get(0, 0)->get_FillFormat()->set_FillType(FillType::Picture);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// Uloží soubor PPTX na disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **FAQ**

**Mohu nastavit různé tloušťky a styly čar pro různé strany jedné buňky?**

Ano. Okraje [top](https://reference.aspose.com/slides/cs/cpp/aspose.slides/cellformat/get_bordertop/)/[bottom](https://reference.aspose.com/slides/cs/cpp/aspose.slides/cellformat/get_borderbottom/)/[left](https://reference.aspose.com/slides/cs/cpp/aspose.slides/cellformat/get_borderleft/)/[right](https://reference.aspose.com/slides/cs/cpp/aspose.slides/cellformat/get_borderright/) mají samostatné vlastnosti, takže tloušťka a styl každé strany se mohou lišit. To logicky vyplývá z řízení okrajů jednotlivých stran buňky, jak je ukázáno v článku.

**Co se stane s obrázkem, pokud po nastavení obrázku jako pozadí buňky změníte velikost sloupce/řádku?**

Chování závisí na [fill mode](https://reference.aspose.com/slides/cs/cpp/aspose.slides/picturefillmode/) (stretch/tile). Při roztažení se obrázek přizpůsobí nové buňce; při dlaždicování se dlaždice přepočítají. Článek zmiňuje režimy zobrazení obrázku v buňce.

**Mohu přiřadit hypertextový odkaz k celému obsahu buňky?**

[Hyperlinks](/slides/cs/cpp/manage-hyperlinks/) jsou nastaveny na úrovni textu (části) uvnitř textového rámce buňky nebo na úrovni celé tabulky/objektu. V praxi přiřadíte odkaz buď k části, nebo ke všemu textu v buňce.

**Mohu nastavit různé písma v jedné buňce?**

Ano. Textový rámec buňky podporuje [portions](https://reference.aspose.com/slides/cs/cpp/aspose.slides/portion/) (běhy) s nezávislým formátováním – rodinu písma, styl, velikost a barvu.