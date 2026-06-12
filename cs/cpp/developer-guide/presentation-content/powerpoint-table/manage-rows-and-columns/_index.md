---
title: Spravovat řádky a sloupce v tabulkách PowerPoint pomocí C++
linktitle: Řádky a sloupce
type: docs
weight: 20
url: /cs/cpp/manage-rows-and-columns/
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
- C++
- Aspose.Slides
description: "Spravujte řádky a sloupce tabulky v PowerPointu pomocí Aspose.Slides pro C++ a urychlete úpravy prezentací a aktualizace dat."
---
## **Úvod**

Aby vám umožnil spravovat řádky a sloupce tabulky v prezentaci PowerPoint, Aspose.Slides poskytuje třídu [Table](https://reference.aspose.com/slides/cs/cpp/aspose.slides/table/) a rozhraní [ITable](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itable/) a mnoho dalších typů. 

## **Nastavit první řádek jako záhlaví**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation) a načtěte prezentaci. 
2. Získejte referenci na snímek podle jeho indexu. 
3. Vytvořte objekt [ITable](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itable/) a nastavte jej na null. 
4. Projděte všechny objekty [IShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/) a najděte požadovanou tabulku. 
5. Nastavte první řádek tabulky jako její záhlaví. 

Tento kód v C++ vám ukazuje, jak nastavit první řádek tabulky jako záhlaví:

```c++
// Vytvoří instanci třídy Presentation 
auto pres = System::MakeObject<Presentation>(u"table.pptx");

// Získá první snímek
auto sld = pres->get_Slides()->idx_get(0);

// Inicializuje nulový TableEx
SharedPtr<ITable> tbl;

// Iteruje přes tvary a nastaví referenci na tabulku
for (const auto& shp : sld->get_Shapes())
{
    if (ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Nastaví první řádek tabulky jako její záhlaví 
tbl->set_FirstRow(true);
```

## **Klonovat řádek nebo sloupec tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation) a načtěte prezentaci, 
2. Získejte referenci na snímek podle jeho indexu. 
3. Definujte pole `columnWidth`. 
4. Definujte pole `rowHeight`. 
5. Přidejte objekt [ITable](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itable/) na snímek pomocí metody [AddTable()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/addtable/). 
6. Zklonujte řádek tabulky. 
7. Zklonujte sloupec tabulky. 
8. Uložte upravenou prezentaci. 

Tento kód v C++ vám ukazuje, jak klonovat řádek nebo sloupec tabulky v PowerPointu:

```c++
 // Cesta k adresáři dokumentů.
const String outPath = u"../out/CloningInTable_out.pptx";

// Vytváří instanci třídy Presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Získá první snímek
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Definuje sloupce s šířkami a řádky s výškami
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Přidá tvar tabulky na snímek
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Nastaví formát ohraničení pro každou buňku
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

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"00");
table->idx_get(0, 1)->get_TextFrame()->set_Text(u"01");
table->idx_get(0, 2)->get_TextFrame()->set_Text(u"02");
table->idx_get(0, 3)->get_TextFrame()->set_Text(u"03");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"11");
table->idx_get(2, 1)->get_TextFrame()->set_Text(u"21");

//AddClone přidá řádek na konec tabulky
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

//InsertClone přidá řádek na konkrétní pozici v tabulce
table->get_Rows()->InsertClone(2, table->get_Rows()->idx_get(0), false);

//AddClone přidá sloupec na konec tabulky
table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);

//InsertClone přidá sloupec na konkrétní pozici v tabulce
table->get_Columns()->InsertClone(2, table->get_Columns()->idx_get(0), false);


// Uloží prezentaci na disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Odstranit řádek nebo sloupec z tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation) a načtěte prezentaci, 
2. Získejte referenci na snímek podle jeho indexu. 
3. Definujte pole `columnWidth`. 
4. Definujte pole `rowHeight`. 
5. Přidejte objekt [ITable](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itable/) na snímek pomocí metody [AddTable()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/addtable/). 
6. Odstraňte řádek tabulky. 
7. Odstraňte sloupec tabulky. 
8. Uložte upravenou prezentaci. 

Tento kód v C++ vám ukazuje, jak odstranit řádek nebo sloupec z tabulky:

```c++
// Cesta k adresáři dokumentů.
const String outPath = u"../out/RemovingRowColumn_out.pptx";

// Vytvoří instanci třídy Presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Získá první snímek
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Definuje sloupce s šířkami a řádky s výškami
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Přidá tvar tabulky na snímek
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);


// Spojí buňky (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Spojí buňky (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);

// Uloží prezentaci na disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Nastavit formátování textu na úrovni řádku tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation) a načtěte prezentaci, 
2. Získejte referenci na snímek podle jeho indexu. 
3. Získejte přístup k požadovanému objektu [ITable](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itable/) ze snímku. 
4. Nastavte výšku písma buněk v prvním řádku pomocí [set_FontHeight()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/baseportionformat/set_fontheight/). 
5. Nastavte zarovnání buněk v prvním řádku pomocí [set_Alignment()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/set_alignment/) a pravý okraj pomocí [set_MarginRight()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/set_marginright/). 
6. Nastavte svislý typ textu buněk ve druhém řádku pomocí [set_TextVerticalType()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/textframeformat/set_textverticaltype/). 
7. Uložte upravenou prezentaci. 

Tento kód v C++ demonstruje operaci.

```c++
// Vytvoří instanci třídy Presentation
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// Předpokládejme, že první tvar na prvním snímku je tabulka
// Nastaví výšku písma buněk v prvním řádku
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

// Nastaví zarovnání textu buněk v prvním řádku a pravý okraj
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

// Nastaví svislý typ textu buněk ve druhém řádku
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

// Uloží prezentaci na disk
presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Nastavit formátování textu na úrovni sloupce tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation) a načtěte prezentaci, 
2. Získejte referenci na snímek podle jeho indexu. 
3. Získejte přístup k požadovanému objektu [ITable](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itable/) ze snímku. 
4. Nastavte výšku písma buněk v prvním sloupci pomocí [set_FontHeight()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/baseportionformat/set_fontheight/). 
5. Nastavte zarovnání buněk v prvním sloupci pomocí [set_Alignment()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/set_alignment/) a pravý okraj pomocí [set_MarginRight()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/set_marginright/). 
6. Nastavte svislý typ textu buněk ve druhém sloupci pomocí [set_TextVerticalType()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/textframeformat/set_textverticaltype/). 
7. Uložte upravenou prezentaci. 

Tento kód v C++ demonstruje operaci: 

```c++
// Vytvoří instanci třídy Presentation
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// Předpokládejme, že první tvar na prvním snímku je tabulka

// Nastaví výšku písma buněk v prvním sloupci
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

// Nastaví zarovnání textu buněk v prvním sloupci a pravý okraj v jednom volání
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

// Nastaví svislý typ textu buněk ve druhém sloupci
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

pres->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Získat vlastnosti stylu tabulky**

Aspose.Slides vám umožňuje získat vlastnosti stylu tabulky, abyste je mohli použít pro jinou tabulku nebo jinde. Tento kód v C++ vám ukazuje, jak získat vlastnosti stylu z předdefinovaného stylu tabulky:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Často kladené otázky**

**Mohu použít motivy/styly PowerPointu na již vytvořenou tabulku?**

Ano. Tabulka dědí motiv snímku/vzhledu/mistra a můžete nad tímto motivem stále přepsat výplně, okraje a barvy textu.

**Mohu řadit řádky tabulky jako v Excelu?**

Ne, tabulky Aspose.Slides nemají vestavěné řazení ani filtry. Seřaďte data v paměti nejprve a pak znovu naplňte řádky tabulky v tomto pořadí.

**Mohu mít pruhované (stripované) sloupce a přitom zachovat vlastní barvy ve specifických buňkách?**

Ano. Zapněte pruhované sloupce a poté přepište konkrétní buňky lokálním formátováním; formátování na úrovni buňky má přednost před stylem tabulky.