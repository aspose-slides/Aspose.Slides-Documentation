---
title: Táblacellák kezelése prezentációkban C++ használatával
linktitle: Cellák kezelése
type: docs
weight: 30
url: /hu/cpp/manage-cells/
keywords:
- táblacella
- cellák összevonása
- szegély eltávolítása
- cella felosztása
- kép a cellában
- háttérszín
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Könnyedén kezelje a táblacellákat PowerPointban az Aspose.Slides for C++ segítségével. Gyorsan megtanulhatja a cellák elérését, módosítását és formázását a zökkenőmentes diák automatizálásához."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi a táblacellák elérését és módosítását PowerPoint‑prezentációkban. Ez a cikk bemutatja, hogyan lehet azonosítani az összevont táblacellákat, eltávolítani a cellaszegélyeket, kezelni a cellaszámozást az összevonás vagy felosztás után, megváltoztatni egy cella háttérszínét, és képet elhelyezni egy táblacellában. A példák azt mutatják, hogyan hozhatunk létre vagy nyithatunk meg egy prezentációt, hogyan szerezhetünk be egy táblát egy diáról, hogyan frissíthetjük a cella formázását a cella tulajdonságain keresztül, és hogyan menthetjük el a módosított prezentációt PPTX fájlként.

## **Összevont cella azonosítása**
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
2. Szerezze be a táblát az első diáról. 
3. Iteráljon a tábla sorain és oszlopain, hogy megtalálja az összevont cellákat.
4. Írjon ki egy üzenetet, ha összevont cellákat talál.

Ez a C++ kód megmutatja, hogyan azonosíthatók az összevont táblacellák egy prezentációban:

``` cpp
auto pres = System::MakeObject<Presentation>(u"SomePresentationWithTable.pptx");
auto table = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// feltételezve, hogy a Slide#0.Shape#0 egy táblázat
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

## **Táblacella szegélyek eltávolítása**
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
2. Szerezzen meg egy dia hivatkozását a indexén keresztül. 
3. Definiáljon egy oszlopsorozatot szélességgel.
4. Definiáljon egy sorcsövet magassággal.
5. Adjon hozzá egy táblát a diára az `AddTable` metódussal.
6. Iteráljon minden cellán, hogy eltávolítsa a felső, alsó, jobb és bal szegélyeket.
7. Mentse el a módosított prezentációt PPTX fájlként.

Ez a C++ kód megmutatja, hogyan távolíthatók el a szegélyek a táblacellákból:

``` cpp
// Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel
auto pres = MakeObject<Presentation>();
// Eléri az első diát
auto sld = pres->get_Slides()->idx_get(0);

// Meghatározza az oszlopokat szélességekkel és a sorokat magasságokkal
auto dblCols = MakeArray<double>({ 50, 50, 50, 50 });
auto dblRows = MakeArray<double>({ 50, 30, 30, 30, 30 });

// Táblázat alakzatot ad hozzá a diára
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Beállítja a szegélyformátumot minden cellához
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

// A PPTX fájlt leírja a lemezre
pres->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **Számozás összevont cellákban**
Ha 2 cellapárt (1, 1) x (2, 1) és (1, 2) x (2, 2) vonunk össze, a kapott tábla számozott lesz. Ez a C# kód demonstrálja a folyamatot:

```c++
const String outPath = u"../out/MergeCells_out.pptx";

// Betölti a kívánt prezentációt
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Eléri az első diát
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Meghatározza az oszlopokat szélességekkel és a sorokat magasságokkal
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Táblázat alakzatot ad hozzá a diához
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Beállítja a szegélyformátumot minden cellához
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
// Egyesíti a cellákat (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Egyesíti a cellákat (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Mentse a PPTX fájlt a lemezre
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Ezután további összevonást hajtunk végre, összevonva a (1, 1) és (1, 2) cellákat. Az eredmény egy középen egy nagy összevont cellát tartalmazó tábla: 

```c++
// A dokumentumok könyvtárának elérési útja.
const String outPath = u"../out/MergeCells_out.pptx";

// Betölti a kívánt prezentációt
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Eléri az első diát
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Meghatározza az oszlopokat szélességekkel és a sorokat magasságokkal
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Táblázat alakzatot ad hozzá a diára
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Beállítja a szegélyformátumot minden cellához
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

// Egyesíti a cellákat (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Egyesíti a cellákat (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Elmenti a PPTX fájlt a lemezre
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Számozás egy felosztott cellában**
Az előző példákban, amikor a táblacellákat összevonták, a többi cella számozása nem változott. 

Ezúttal egy szabályos táblát (azaz egy, az összevonás nélküli táblát) veszünk, és megpróbáljuk felosztani a (1,1) cellát, hogy egy speciális táblát kapjunk. Érdemes figyelni a tábla számozására, amely elsőre furcsának tűnhet. Azonban ez a módja annak, ahogyan a Microsoft PowerPoint számozza a táblacellákat, és az Aspose.Slides is ugyanígy működik. 

Ez a C++ kód demonstrálja a leírt folyamatot:

```c++
// A dokumentumok könyvtárának elérési útja.
const String outPath = u"../out/CellSplit_out.pptx";

// Betölti a kívánt prezentációt
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Eléri az első diát
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Meghatározza az oszlopokat szélességekkel és a sorokat magasságokkal
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Táblázat alakzatot ad hozzá a diához
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Beállítja a szegélyformátumot minden cellához
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

// Egyesíti a cellákat (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Egyesíti a cellákat (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);

// Felosztja a cellát (1, 1). 
table->idx_get(1, 1)->SplitByWidth(table->idx_get(2, 1)->get_Width() / 2);

// Elmenti a PPTX fájlt a lemezre
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **A táblacella háttérszínének módosítása**

Ez a C++ kód megmutatja, hogyan változtatható meg egy táblacella háttérszíne:

``` cpp

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
auto dblCols = System::MakeArray<double>({150, 150, 150, 150});
auto dblRows = System::MakeArray<double>({50, 50, 50, 50, 50});
        
// új táblát hoz létre
auto table = slide->get_Shapes()->AddTable(50.0f, 50.0f, dblCols, dblRows);
        
// beállítja a cella háttérszínét
System::SharedPtr<ICell> cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        
presentation->Save(u"cell_background_color.pptx", Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Kép hozzáadása egy táblacellába**
1. Hozzon létre egy példányt a `Presentation` osztályból.
2. Szerezzen meg egy dia hivatkozását az indexén keresztül.
3. Definiáljon egy oszlopsorozatot szélességgel.
4. Definiáljon egy sorcsövet magassággal.
5. Adjon hozzá egy táblát a diára az `AddTable` metódussal. 
6. Hozzon létre egy `Bitmap` objektumot a képfájl tárolására.
7. Adja hozzá a bitmap képet az `IPPImage` objektumhoz.
8. Állítsa be a táblacella `FillFormat` értékét `Picture`‑re.
9. Adja hozzá a képet a táblázat első cellájához.
10. Mentse el a módosított prezentációt PPTX fájlként

Ez a C# kód megmutatja, hogyan helyezhet el egy képet egy táblacellában egy tábla létrehozásakor:

```c++
// A dokumentumok könyvtárának elérési útja.
const String outPath = u"../out/Image_In_TableCell_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// Betölti a kívánt prezentációt
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Eléri az első diát
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Meghatározza az oszlopokat szélességekkel és a sorokat magasságokkal
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 150);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 100);
System::ArrayPtr<double> total_for_Cat = System::MakeObject<System::Array<double>>(5, 0);

// Táblázat alakzatot ad hozzá a diára
auto tbl = islide->get_Shapes()->AddTable(50, 50, dblCols, dblRows);

// Lekéri a képet
auto img = Images::FromFile(ImagePath);

// Képet ad a prezentáció képgyűjteményéhez
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(img);


// Hozzáadja a képet az első táblacellához
tbl->idx_get(0, 0)->get_FillFormat()->set_FillType(FillType::Picture);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// Elmenti a PPTX fájlt a lemezre
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **GyIK**

**Beállíthatok különböző vonalvastagságokat és stílusokat a cella egyes oldalain?**

Igen. A [top](https://reference.aspose.com/slides/hu/cpp/aspose.slides/cellformat/get_bordertop/)/[bottom](https://reference.aspose.com/slides/hu/cpp/aspose.slides/cellformat/get_borderbottom/)/[left](https://reference.aspose.com/slides/hu/cpp/aspose.slides/cellformat/get_borderleft/)/[right](https://reference.aspose.com/slides/hu/cpp/aspose.slides/cellformat/get_borderright/) szegélyeknek különálló tulajdonságaik vannak, így az egyes oldalak vastagsága és stílusa eltérő lehet. Ez logikusan következik a cellára vonatkozó oldalankénti szegélyvezérlésből, amelyet a cikk bemutat.

**Mi történik a képpel, ha a oszlop/sor méretét megváltoztatom, miután képet állítottam be a cella háttérként?**

Az viselkedés a [fill mode](https://reference.aspose.com/slides/hu/cpp/aspose.slides/picturefillmode/) (nyúlás/csempézés) beállításától függ. Nyújtás esetén a kép a új cellához igazodik; csempézésnél a csempéket újraszámolják. A cikk említi a képek megjelenítési módjait egy cellában.

**Hozzá lehet adni hiperhivatkozást a cella teljes tartalmához?**

A [Hyperlinks](/slides/hu/cpp/manage-hyperlinks/) beállítható a cella szövegkeretén belül a szöveg (részlet) szintjén vagy az egész táblázat/forma szintjén. Gyakorlatban a hivatkozást egy részlethez vagy a cella összes szövegéhez lehet hozzárendelni.

**Beállíthatok különböző betűtípusokat egyetlen cellán belül?**

Igen. A cella szövegkerete támogatja a [portions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/portion/) (futás) független formázású részeit – betűcsalád, stílus, méret és szín.