---
title: "Sorok és oszlopok kezelése PowerPoint táblázatokban C++ segítségével"
linktitle: "Sorok és oszlopok"
type: docs
weight: 20
url: /hu/cpp/manage-rows-and-columns/
keywords:
- "táblázat sor"
- "táblázat oszlop"
- "első sor"
- "táblázat fejléc"
- "sor klónozása"
- "oszlop klónozása"
- "sor másolása"
- "oszlop másolása"
- "sor eltávolítása"
- "oszlop eltávolítása"
- "sor szövegformázás"
- "oszlop szövegformázás"
- "táblázat stílus"
- "PowerPoint"
- "prezentáció"
- "C++"
- "Aspose.Slides"
description: "Kezelje a táblázat sorait és oszlopait PowerPointban az Aspose.Slides for C++ segítségével, és gyorsítsa fel a prezentációk szerkesztését és az adatok frissítését."
---
## **Bevezetés**

Az Aspose.Slides lehetővé teszi, hogy egy PowerPoint‑prezentáció táblázatának sorait és oszlopait kezelje, a [Table](https://reference.aspose.com/slides/hu/cpp/aspose.slides/table/) osztályt, az [ITable](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itable/) interfészt és sok más típust biztosít. 

## **Az első sor beállítása fejlécnek**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból, és töltse be a prezentációt. 
2. Szerezze meg a dia hivatkozását az indexe alapján. 
3. Hozzon létre egy [ITable](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itable/) objektumot, és állítsa null értékre. 
4. Iteráljon az összes [IShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/) objektumon, hogy megtalálja a megfelelő táblázatot. 
5. Állítsa be a táblázat első sorát fejlécnek. 

Ez a C++ kód megmutatja, hogyan állítható be a táblázat első sora fejlécnek:

```c++
// Példányosítja a Presentation osztályt 
auto pres = System::MakeObject<Presentation>(u"table.pptx");

// Eléri az első diát
auto sld = pres->get_Slides()->idx_get(0);

// Inicializálja a null TableEx-et
SharedPtr<ITable> tbl;

// Végigiterál a formákon és beállít egy hivatkozást a táblázatra
for (const auto& shp : sld->get_Shapes())
{
    if (ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Beállítja egy táblázat első sorát fejlécnek 
tbl->set_FirstRow(true);
```

## **Táblázat sor vagy oszlop klónozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból, és töltse be a prezentációt, 
2. Szerezze meg a dia hivatkozását az indexe alapján. 
3. Határozzon meg egy `columnWidth` tömböt. 
4. Határozzon meg egy `rowHeight` tömböt. 
5. Adjon hozzá egy [ITable](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itable/) objektumot a diára a [AddTable()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/addtable/) metódus segítségével. 
6. Klónozza a táblázat sorát. 
7. Klónozza a táblázat oszlopát. 
8. Mentse el a módosított prezentációt. 

Ez a C++ kód megmutatja, hogyan lehet klónozni egy PowerPoint‑táblázat sorát vagy oszlopát:

```c++
 // A dokumentumok könyvtárának elérési útja.
const String outPath = u"../out/CloningInTable_out.pptx";

// Példányosítja a Presentation osztályt
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Eléri az első diát
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Meghatározza az oszlopok szélességét és a sorok magasságát
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Táblázat alakzatot ad a diára
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Beállítja a szegély formátumát minden cellához
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

// Az AddClone egy sort ad a táblázat végéhez
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

// Az InsertClone egy sort ad a táblázat adott pozíciójába
table->get_Rows()->InsertClone(2, table->get_Rows()->idx_get(0), false);

// Az AddClone egy oszlopot ad a táblázat végéhez
table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);

// Az InsertClone egy oszlopot ad a táblázat adott pozíciójába
table->get_Columns()->InsertClone(2, table->get_Columns()->idx_get(0), false);


// Mentés a prezentációt a lemezre
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Sor vagy oszlop eltávolítása a táblázatból**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból, és töltse be a prezentációt, 
2. Szerezze meg a dia hivatkozását az indexe alapján. 
3. Határozzon meg egy `columnWidth` tömböt. 
4. Határozzon meg egy `rowHeight` tömböt. 
5. Adjon hozzá egy [ITable](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itable/) objektumot a diára a [AddTable()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/addtable/) metódus segítségével. 
6. Távolítsa el a táblázat sorát. 
7. Távolítsa el a táblázat oszlopát. 
8. Mentse el a módosított prezentációt. 

Ez a C++ kód megmutatja, hogyan távolítható el egy sor vagy oszlop a táblázatból:

```c++
// A dokumentumok könyvtárának elérési útja.
const String outPath = u"../out/RemovingRowColumn_out.pptx";

// Példányosítja a Presentation osztályt
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Eléri az első diát
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Meghatározza az oszlopok szélességét és a sorok magasságát
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Táblázat alakzatot ad a diára
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);


// Egyesíti a (1, 1) és (2, 1) cellákat
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Egyesíti a (1, 2) és (2, 2) cellákat
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Mentés a prezentációt a lemezre
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Szövegformázás beállítása a táblázat sor szintjén**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból, és töltse be a prezentációt, 
2. Szerezze meg a dia hivatkozását az indexe alapján. 
3. Érje el a megfelelő [ITable](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itable/) objektumot a diáról. 
4. Állítsa be az első sor celláinak [set_FontHeight()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/baseportionformat/set_fontheight/). 
5. Állítsa be az első sor celláinak [set_Alignment()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_alignment/) és [set_MarginRight()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_marginright/). 
6. Állítsa be a második sor celláinak [set_TextVerticalType()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/textframeformat/set_textverticaltype/). 
7. Mentse el a módosított prezentációt. 

Ez a C++ kód bemutatja a műveletet.

```c++
// Példányosítja a Presentation osztályt
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// Tegyük fel, hogy az első dia első alakzata egy táblázat
// Beállítja az első sor celláinak betűmagasságát
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

// Beállítja az első sor celláinak szövegigazítását és jobb margóját
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

// Beállítja a második sor celláinak függőleges szövegtípust
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

// Mentés a prezentációt a lemezre
presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Szövegformázás beállítása a táblázat oszlop szintjén**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból, és töltse be a prezentációt, 
2. Szerezze meg a dia hivatkozását az indexe alapján. 
3. Érje el a megfelelő [ITable](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itable/) objektumot a diáról. 
4. Állítsa be az első oszlop celláinak [set_FontHeight()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/baseportionformat/set_fontheight/). 
5. Állítsa be az első oszlop celláinak [set_Alignment()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_alignment/) és [set_MarginRight()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_marginright/). 
6. Állítsa be a második oszlop celláinak [set_TextVerticalType()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/textframeformat/set_textverticaltype/). 
7. Mentse el a módosított prezentációt. 

Ez a C++ kód bemutatja a műveletet: 

```c++
// Példányosítja a Presentation osztályt
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// Tegyük fel, hogy az első dia első alakzata egy táblázat

// Beállítja az első oszlop celláinak betűmagasságát
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

// Beállítja az első oszlop celláinak szövegigazítását és jobb margóját egy hívásban
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

// Beállítja a második oszlop celláinak függőleges szövegtípusát
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

pres->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Táblázat stílus tulajdonságainak lekérése**

Aspose.Slides lehetővé teszi, hogy lekérje egy táblázat stílus tulajdonságait, hogy ezeket az adatokat egy másik táblázathoz vagy máshová felhasználhassa. Ez a C++ kód megmutatja, hogyan kell lekérni a stílus tulajdonságokat egy táblázat előre beállított stílusából:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **GYIK**

**Alkalmazhatok PowerPoint témákat/stílusokat egy már létrehozott táblázatra?**

Igen. A táblázat örökli a dia/layout/mester témát, és továbbra is felülírhatja a kitöltéseket, szegélyeket és szövegszíneket a téma felett.

**Rendezhetem a táblázat sorait, mint Excelben?**

Nem, az Aspose.Slides táblázatok nem rendelkeznek beépített rendezéssel vagy szűrőkkel. Először rendezze az adatokat a memóriában, majd töltse újra a táblázat sorait ebben a sorrendben.

**Lehetnek csíkatmintás oszlopok, miközben egyedi színeket tartok meg bizonyos cellákban?**

Igen. Kapcsolja be a csíkatmintás oszlopokat, majd felülírja a konkrét cellákat helyi formázással; a cellaszintű formázás precedálja a táblázat stílusát.