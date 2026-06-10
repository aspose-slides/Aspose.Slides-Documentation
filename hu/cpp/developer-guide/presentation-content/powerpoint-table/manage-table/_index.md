---
title: PowerPoint-táblázatok kezelése C++-ban
linktitle: Táblázat kezelése
type: docs
weight: 10
url: /hu/cpp/manage-table/
keywords:
- táblázat hozzáadása
- táblázat létrehozása
- táblázathoz hozzáférés
- képarány
- szöveg igazítása
- szövegformázás
- táblázat stílus
- PowerPoint
- bemutató
- C++
- Aspose.Slides
description: "Hozzon létre és szerkesszen táblázatokat PowerPoint-diákon az Aspose.Slides for C++ segítségével. Fedezzen fel egyszerű kódrészleteket, amelyek leegyszerűsítik a táblázati munkafolyamatokat."
---
## **Bevezetés**

A táblázat a PowerPointban hatékony módja az információ megjelenítésének és ábrázolásának. Az információ egy cellákból álló rácsban (sorokba és oszlopokba rendezve) egyértelmű és könnyen érthető.

Az Aspose.Slides a [Table](https://reference.aspose.com/slides/hu/cpp/aspose.slides/table/) osztályt, [ITable](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itable/) interfészt, [Cell](https://reference.aspose.com/slides/hu/cpp/aspose.slides/cell/) osztályt, [ICell](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icell/) interfészt és további típusokat biztosít, amelyek lehetővé teszik táblázatok létrehozását, frissítését és kezelését mindenféle bemutatóban. 

## **Táblázat létrehozása az alapoktól**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.  
2. Szerezze meg egy dia referenciáját az indexén keresztül.  
3. Határozzon meg egy `columnWidth` tömböt.  
4. Határozzon meg egy `rowHeight` tömböt.  
5. Adjon egy [ITable](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itable/) objektumot a diára a [AddTable()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/addtable/) metódus segítségével.  
6. Iteráljon minden [ICell](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icell/) objektumon, hogy alkalmazza a formázást a felső, alsó, jobb és bal szegélyeken.  
7. Egyesítse a táblázat első sorának első két celláját.  
8. Hozzon hozzá egy [ICell](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icell/)'s [TextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/textframe/) objektumához.  
9. Adjon szöveget a [TextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/textframe/).  
10. Mentse el a módosított bemutatót.

Ez a C++ kód megmutatja, hogyan hozhat létre egy táblázatot egy bemutatóban:

```c++
// Létrehozza a Presentation osztály egy példányát, amely egy PPTX fájlt képvisel
auto pres = System::MakeObject<Presentation>();

// Eléri az első diát
auto sld = pres->get_Slides()->idx_get(0);

// Definiálja az oszlopok szélességét és a sorok magasságát
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// Táblázat alakzatot ad hozzá a diához
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Beállítja a szegély formátumot minden cellához
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
// Egyesíti az 1. sor 1. és 2. celláját
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// Szöveget ad hozzá az egyesített cellához
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Merged Cells");

// Mentse a bemutatót a lemezre
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Számozás egy szabványos táblázatban**

Egy szabványos táblázatban a cellák számozása egyszerű és nullától kezdődik. Az első cella a táblázatban 0,0 indexű (oszlop 0, sor 0).

Például egy 4 oszlopos és 4 soros táblázat cellái így vannak számozva:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ez a C++ kód megmutatja, hogyan adhatja meg a cellák számozását egy táblázatban:

```c++
// Létrehozza a Presentation osztály egy példányát, amely egy PPTX fájlt képvisel
auto pres = System::MakeObject<Presentation>();

// Eléri az első diát
auto sld = pres->get_Slides()->idx_get(0);

// Definiálja az oszlopok szélességét és a sorok magasságát
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// Táblázat alakzatot ad hozzá a diához
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Beállítja a szegély formátumot minden cellához
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

// Mentse a bemutatót a lemezre
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **Meglévő táblázat elérése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.  
2. Szerezze meg a táblázatot tartalmazó dia referenciáját az indexén keresztül.  
3. Hozzon létre egy [ITable](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itable/) objektumot, és állítsa null-ra.  
4. Iteráljon az összes [IShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/) objektumon, amíg meg nem találja a táblázatot.  

   Ha úgy véli, hogy a kezelt dia egyetlen táblázatot tartalmaz, egyszerűen ellenőrizheti az összes benne lévő alakzatot. Ha egy alakzatot táblázatként azonosítanak, típuskonvertálhatja azt [Table](https://reference.aspose.com/slides/hu/cpp/aspose.slides/table/) objektummá. Ha azonban a dia több táblázatot tartalmaz, érdemes a kívánt táblázatot a [set_AlternativeText()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/set_alternativetext/) metódus segítségével keresni.  

5. Használja a [ITable](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itable/) objektumot a táblázattal való munkához. Az alábbi példában új sort adtunk a táblázathoz.  
6. Mentse el a módosított bemutatót.

Ez a C++ kód megmutatja, hogyan érheti el és dolgozhat egy meglévő táblázattal:

```c++
// Létrehozza a Presentation osztály egy példányát, amely egy PPTX fájlt képvisel
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// Eléri az első diát
auto sld = pres->get_Slides()->idx_get(0);

// null táblát inicializál
System::SharedPtr<ITable> tbl;

// Végig iterál a alakzatokon és beállítja a megtalált táblázatra a hivatkozást
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Beállítja a szöveget a második sor első oszlopához
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// Mentse a módosított bemutatót a lemezre
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **Szöveg igazítása táblázatban**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.  
2. Szerezze meg egy dia referenciáját az indexén keresztül.  
3. Adjon egy [ITable](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itable/) objektumot a diára.  
4. Hozzon hozzá egy [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) objektumot a táblázatból.  
5. Hozzon hozzá az [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/) objektumához.  
6. Igazítsa a szöveget függőlegesen.  
7. Mentse el a módosított bemutatót.

Ez a C++ kód megmutatja, hogyan igazítható a szöveg egy táblázatban:

```c++
// Létrehoz egy példányt a Presentation osztályból
auto presentation = System::MakeObject<Presentation>();

// Első diát kap meg 
auto slide = presentation->get_Slides()->idx_get(0);

// Definiálja az oszlopok szélességét és a sorok magasságát
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// A táblázat alakzatot hozzáadja a diához
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// Hozzáfér a szövegkerethez
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// Létrehozza a Paragraph objektumot a szövegkerethez
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Létrehozza a Portion objektumot a bekezdéshez
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Függőlegesen igazítja a szöveget
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// Mentse a bemutatót a lemezre
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Szövegformázás beállítása táblázati szinten**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.  
2. Szerezze meg egy dia referenciáját az indexén keresztül.  
3. Hozzon hozzá egy [ITable](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itable/) objektumot a diáról.  
4. Állítsa be a szöveg [set_FontHeight()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/baseportionformat/set_fontheight/) értékét.  
5. Állítsa be a [set_Alignment()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_alignment/) és a [set_MarginRight()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_marginright/) értékeket.  
6. Állítsa be a [set_TextVerticalType()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/textframeformat/set_textverticaltype/) értéket.  
7. Mentse el a módosított bemutatót.  

Ez a C++ kód megmutatja, hogyan alkalmazhatja a kedvenc formázási beállításait a táblázat szövegére:

```c++
// Létrehozza a Presentation osztály egy példányát
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// Tegyük fel, hogy az első dia első alakzata egy táblázat
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// Beállítja a táblázat celláinak betűmagasságát
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// Egy hívással beállítja a táblázat celláinak szövegigazítását és jobb margóját
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// Beállítja a táblázat celláinak szöveg függőleges típusát
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Táblázat stílus tulajdonságainak lekérése**

Aspose.Slides lehetővé teszi, hogy lekérje egy táblázat stílus tulajdonságait, hogy ezeket a részleteket egy másik táblázathoz vagy más helyen felhasználhassa. Ez a C++ kód megmutatja, hogyan lehet a táblázat előre beállított stílusából lekérni a stílus tulajdonságait:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **A táblázat képarányának zárolása**

Egy geometriai alakzat képaránya a méretei aránya különböző dimenziókban. Az Aspose.Slides biztosítja az `AspectRatioLocked()` tulajdonságot, amely lehetővé teszi a táblázatok és más alakzatok képarányának zárolását. 

Ez a C++ kód megmutatja, hogyan zárolható a táblázat képaránya:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **GYIK**

**Engedélyezhetem a jobbról balra (RTL) olvasási irányt egy egész táblázatban és a cellák szövegében?**

Igen. A táblázat rendelkezik egy [set_RightToLeft](https://reference.aspose.com/slides/hu/cpp/aspose.slides/table/set_righttoleft/) metódussal, a bekezdéseknek pedig [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/hu/cpp/aspose.slides/paragraphformat/set_righttoleft/) metódusa van. Mindkettő használata biztosítja a helyes RTL sorrendet és megjelenítést a cellákon belül.

**Hogyan akadályozhatom meg, hogy a felhasználók áthelyezzék vagy átméretezzék a táblázatot a végleges fájlban?**

Használja a [shape locks](/slides/hu/cpp/applying-protection-to-presentation/) lehetőséget a mozgatás, átméretezés, kijelölés stb. letiltásához. Ezek a zárolások a táblázatokra is érvényesek.

**Támogatott-e egy kép cellába háttérként történő beszúrása?**

Igen. Beállíthat egy [picture fill](https://reference.aspose.com/slides/hu/cpp/aspose.slides/picturefillformat/) kitöltést egy cellához; a kép a választott módnak (nyújtás vagy ismétlés) megfelelően lefedi a cellaterületet.