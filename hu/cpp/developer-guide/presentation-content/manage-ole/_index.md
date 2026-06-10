---
title: OLE kezelése prezentációkban C++-ban
linktitle: OLE kezelése
type: docs
weight: 40
url: /hu/cpp/manage-ole/
keywords:
- OLE objektum
- Objektum hivatkozás és beágyazás
- OLE hozzáadása
- OLE beágyazása
- objektum hozzáadása
- objektum beágyazása
- fájl hozzáadása
- fájl beágyazása
- linkelt objektum
- linkelt fájl
- OLE módosítása
- OLE ikon
- OLE cím
- OLE kinyerése
- objektum kinyerése
- fájl kinyerése
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Optimalizálja az OLE objektumok kezelését PowerPoint és OpenDocument fájlokban az Aspose.Slides for C++ segítségével. Az OLE tartalmat zökkenőmentesen ágyazza be, frissíti és exportálja."
---
## **Bevezetés**

{{% alert title="Info" color="info" %}}

Az OLE (Object Linking & Embedding) egy Microsoft technológia, amely lehetővé teszi, hogy egy alkalmazásban létrehozott adatokat és objektumokat egy másik alkalmazásban helyezzük el hivatkozás vagy beágyazás útján.

{{% /alert %}} 

Tekintsünk egy MS Excelben létrehozott diagramot. A diagramot ezután egy PowerPoint diára helyezzük. Ez az Excel-diagram OLE objektumnak minősül.

- Egy OLE objektum ikonként jelenhet meg. Ebben az esetben, ha duplán kattintunk az ikonra, a diagram a hozzárendelt alkalmazásban (Excel) nyílik meg, vagy felkérik a felhasználót, hogy válasszon egy alkalmazást az objektum megnyitásához vagy szerkesztéséhez.  
- Egy OLE objektum megjelenítheti a tényleges tartalmát, például egy diagram adatait. Ebben az esetben a diagram a PowerPointban aktiválódik, betöltődik a diagram interfésze, és a diagram adatait a PowerPointon belül módosíthatja.

[Aspose.Slides for C++](https://products.aspose.com/slides/hu/cpp/) lehetővé teszi OLE objektumok beszúrását a diákba OLE objektumkeretként ([OleObjectFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/oleobjectframe/)).

## **OLE Objektumkeretek Hozzáadása a Diákhoz**

Tegyük fel, hogy már létrehozott egy diagramot a Microsoft Excelben, és azt OLE objektumkeretként szeretné beágyazni egy diára az Aspose.Slides for C++ segítségével, ezt a következőképpen teheti meg:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.  
2. Szerezze meg a dia referencia‑jét az indexe alapján.  
3. Olvassa be az Excel‑fájlt bájt­tömbként.  
4. Adja hozzá a [OleObjectFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/oleobjectframe/) objektumot a diához, a bájt­tömbbel és az OLE objektumhoz tartozó egyéb információkkal.  
5. Írja ki a módosított prezentációt PPTX‑fájlként.

Az alábbi példában egy Excel‑fájlból származó diagramot adtunk hozzá egy diához [OleObjectFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/oleobjectframe/) használatával az Aspose.Slides for C++‑ban.  
**Megjegyzés**: a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/hu/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) konstruktor második paramétereként egy beágyazható objektum kiterjesztést vár. Ez a kiterjesztés lehetővé teszi a PowerPoint számára, hogy helyesen értelmezze a fájltípust, és kiválassza a megfelelő alkalmazást az OLE objektum megnyitásához.

``` cpp
auto presentation = MakeObject<Presentation>();
auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);

// Prepare data for the OLE object.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// Add the OLE object frame to the slide.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Linkelt OLE Objektumkeretek Hozzáadása**

Az Aspose.Slides for C++ lehetővé teszi egy [OleObjectFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/oleobjectframe/) hozzáadását anélkül, hogy beágyazná az adatokat, csupán a fájlra mutató hivatkozásként.

Ez a C++ kód megmutatja, hogyan adhat hozzá egy [OleObjectFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/oleobjectframe/) objektumot egy linkelt Excel‑fájllal egy diához:

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Olyan OLE objektumkeret hozzáadása, amely egy linkelt Excel fájlra mutat.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **OLE Objektumkeretek Elérése**

Ha egy OLE objektum már be van ágyazva egy diára, a következő módon könnyedén megtalálhatja vagy elérheti azt:

1. Töltse be a prezentációt a beágyazott OLE objektummal úgy, hogy példányosítja a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályt.  
2. Szerezze meg a dia referencia‑jét az indexe alapján.  
3. Hozzáférés a [OleObjectFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/oleobjectframe/) alakzathoz.  
   A példánkban a korábban létrehozott PPTX‑et használtuk, amelynek az első diáján csak egy alakzat van. Ezt az alakzatot *cast*-oltuk egy [IOleObjectFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ioleobjectframe/) típusú objektummá, amely a kívánt OLE objektumkeret.  
4. Miután az OLE objektumkeret elérhető, bármilyen műveletet végrehajthat rajta.

Az alábbi példában egy OLE objektumkeret (egy Excel‑diagram, amely egy diára van beágyazva) és annak fájladatát férünk hozzá.

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{ 
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // A beágyazott fájl adatok lekérése.
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // A beágyazott fájl kiterjesztésének lekérése.
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

    // ...
}
```

### **Linkelt OLE Objektumkeret Tulajdonságainak Elérése**

Az Aspose.Slides lehetővé teszi a linkelt OLE objektumkeret tulajdonságainak elérését.

Ez a C++ kód megmutatja, hogyan ellenőrizheti, hogy egy OLE objektum linkelt‑e, majd hogyan szerezheti meg a linkelt fájl elérési útját:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.ppt");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Ellenőrizze, hogy az OLE objektum linkelt-e.
    if (oleFrame->get_IsObjectLink())
    {
        // Írja ki a linkelt fájl teljes elérési útját.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // Írja ki a linkelt fájl relatív útvonalát, ha létezik.
        // Csak a PPT prezentációk tartalmazhatják a relatív útvonalat.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **OLE Objektum Adatainak Módosítása**

{{% alert color="primary" %}} 

Ebben a szakaszban az alábbi kódrészlet a [Aspose.Cells for C++](/cells/cpp/) használatát mutatja be.

{{% /alert %}}

Ha egy OLE objektum már be van ágyazva egy diára, a következő módon könnyedén hozzáférhet az objektumhoz és módosíthatja annak adatait:

1. Töltse be a prezentációt a beágyazott OLE objektummal úgy, hogy példányosítja a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályt.  
2. Szerezze meg a dia referencia‑jét az indexe alapján.  
3. Hozzáférés a [OLEObjectFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/oleobjectframe/) alakzathoz.  
   A példánkban a korábban létrehozott PPTX‑et használtuk, amelynek az első diáján egy alakzat található. Ezt az alakzatot *cast*-oltuk egy [IOleObjectFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ioleobjectframe/) típusú objektummá, amely a kívánt OLE objektumkeret.  
4. Miután az OLE objektumkeret elérhető, bármilyen műveletet végrehajthat rajta.  
5. Hozzon létre egy `Workbook` objektumot, és férjen hozzá az OLE adatához.  
6. Hozzáférés a kívánt `Worksheet`‑hez, és módosítsa az adatokat.  
7. Mentse a frissített `Workbook`‑ot egy adatfolyamban.  
8. Cserélje le az OLE objektum adatát a folyamattal.

Az alábbi példában egy OLE objektumkeretet (egy Excel‑diagram, amely egy diára van beágyazva) érünk el, majd a fájladatot módosítjuk a diagram adatai frissítéséhez.

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// Az első alakzat lekérése OLE objektumkeretként.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // Olvassa be az OLE objektum adatait Workbook objektumként.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // Módosítsa a workbook adatait.
    auto worksheet = workbook.GetWorksheets().Get(0);
    worksheet.GetCells().Get(0, 4).PutValue(Aspose::Cells::U16String("E"));
    worksheet.GetCells().Get(1, 4).PutValue(12);
    worksheet.GetCells().Get(2, 4).PutValue(14);
    worksheet.GetCells().Get(3, 4).PutValue(15);

    Aspose::Cells::OoxmlSaveOptions fileOptions(Aspose::Cells::SaveFormat::Xlsx);
    auto newWorkbookData = workbook.Save(fileOptions);

    auto newOleStream = MakeObject<MemoryStream>();
    newOleStream->Write(
        MakeArray<uint8_t>(std::vector<uint8_t>(newWorkbookData.GetData(), newWorkbookData.GetData() + newWorkbookData.GetLength())),
        0, newWorkbookData.GetLength());

    // Módosítsa az OLE keret objektum adatait.
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Egyéb Fájltípusok Beágyazása a Diákba**

Az Excel‑diagramok mellett az Aspose.Slides for C++ lehetővé teszi más típusú fájlok beágyazását a diákba. Például HTML, PDF és ZIP fájlokat is beszúrhat objektumként. Amikor a felhasználó duplán kattint a beszúrt objektumra, az automatikusan megnyílik a megfelelő programban, vagy a felhasználót felkérik, hogy válasszon egy megfelelő programot a megnyitáshoz.

Ez a C++ kód megmutatja, hogyan ágyazhat be HTML‑t és ZIP‑et egy diára:

``` cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto htmlData = File::ReadAllBytes(u"sample.html");
auto htmlDataInfo = MakeObject<OleEmbeddedDataInfo>(htmlData, u"html");
auto htmlOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame->set_IsObjectIcon(true);

auto zipData = File::ReadAllBytes(u"sample.zip");
auto zipDataInfo = MakeObject<OleEmbeddedDataInfo>(zipData, u"zip");
auto zipOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Beágyazott Objektumok Fájltípusának Beállítása**

Prezentációk kezelésekor előfordulhat, hogy régi OLE objektumokat újakkal kell helyettesíteni, vagy egy nem támogatott OLE objektumot támogatottal cserélni. Az Aspose.Slides for C++ lehetővé teszi, hogy beállítsa a beágyazott objektum fájltípusát, így frissítheti az OLE keret adatait vagy annak kiterjesztését.

Ez a C++ kód megmutatja, hogyan állíthatja be egy beágyazott OLE objektum fájltípusát `zip`‑re:

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();
auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

std::wcout << L"Current embedded file extension is: " << fileExtension << std::endl;

// Change the file type to ZIP.
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ikonképek és Címek Beállítása a Beágyazott Objektumokhoz**

Az OLE objektum beágyazása után automatikusan hozzáadódik egy előnézet, amely egy ikonképből áll. Ez az előnézet az, amit a felhasználók látnak, mielőtt hozzáférnének vagy megnyitnák az OLE objektumot. Ha egy konkrét képet és szöveget szeretne használni az előnézet elemeiként, beállíthatja az ikonképet és a címet az Aspose.Slides for C++‑ban.

Ez a C++ kód megmutatja, hogyan állíthatja be az ikonképet és a címet egy beágyazott objektumhoz:

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Képet ad hozzá a prezentáció erőforrásaihoz.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Cím és kép beállítása az OLE előnézethez.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Az OLE Objektumkeret Átméretezésének és Újrapozicionálásának Megakadályozása**

Miután egy linkelt OLE objektumot hozzáadott egy prezentációs diára, a PowerPoint megnyitásakor megjelenhet egy üzenet, amely a hivatkozások frissítését kéri. A „Frissítse a hivatkozásokat” gomb megnyomása megváltoztathatja az OLE objektumkeret méretét és pozícióját, mert a PowerPoint frissíti a linkelt OLE objektum adatát és újrarajzolja az előnézetet. Ahhoz, hogy a PowerPoint ne kérje az objektum adatának frissítését, állítsa a [IOleObjectFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ioleobjectframe/) interfész `set_UpdateAutomatic` metódusát **false**‑ra:

```cpp
oleFrame->set_UpdateAutomatic(false);
```

## **Beágyazott Fájlok Kivonása**

Az Aspose.Slides for C++ lehetővé teszi a diákba beágyazott OLE objektumként tárolt fájlok kivonását a következő módon:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból, amely tartalmazza a kivonni kívánt OLE objektumokat.  
2. Járja be a prezentáció összes alakzatát, és érje el a [OLEObjectFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/oleobjectframe/) alakzatokat.  
3. Hozzáférés a beágyazott fájlok adatához az OLE objektumkeretekből, majd írja ki őket a lemezre.

Ez a C++ kód megmutatja, hogyan vonhat ki fájlokat, amelyeket egy diában OLE objektumként ágyaztak be:

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (int index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto shape = slide->get_Shape(index);

    if (ObjectExt::Is<IOleObjectFrame>(shape))
    { 
        auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

        auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();
        auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

        auto fileName = String::Format(u"OLE_object_{0}{1}", index, fileExtension);
        File::WriteAllBytes(fileName, fileData);
    }
}

presentation->Dispose();
```

## **GYIK**

**Az OLE tartalom megjelenik, amikor a diákat PDF‑be/képekbe exportálják?**

A dián látható elemek kerülnek renderelésre – a ikon/helyettesítő kép (előnézet). Az „élő” OLE tartalom nincs végrehajtva a renderelés során. Szükség esetén állítson be saját előnézeti képet, hogy a várt megjelenés megjelenjen az exportált PDF‑ben.

**Hogyan zárhatok le egy OLE objektumot a dián, hogy a felhasználók ne tudják mozgatni/szerkeszteni PowerPointban?**

Zárolja az alakzatot: az Aspose.Slides [alakzat‑szintű zárolásokat](/slides/hu/cpp/applying-protection-to-presentation/) biztosít. Ez nem titkosítás, de hatékonyan megakadályozza a véletlen szerkesztéseket és mozgatásokat.

**Miért „ugrik” vagy változik mérete egy linkelt Excel objektum, amikor megnyitom a prezentációt?**

A PowerPoint frissítheti a linkelt OLE előnézetét. Stabil megjelenésért kövesse a [Működő megoldást a munkalap átméretezéséhez](/slides/hu/cpp/working-solution-for-worksheet-resizing/) irányelveket – vagy illessze a keretet a tartományhoz, vagy skálázza a tartományt egy rögzített keretre, és állítson be megfelelő helyettesítő képet.

**A linkelt OLE objektumok relatív útvonalai megmaradnak a PPTX formátumban?**

A PPTX‑ben a „relatív útvonal” információ nem érhető el – csak a teljes útvonal szerepel. Relatív útvonalak a régebbi PPT formátumban találhatók. A hordozhatóság érdekében részesítse előnyben a megbízható abszolút útvonalakat/elérhető URI‑kat vagy a beágyazást.