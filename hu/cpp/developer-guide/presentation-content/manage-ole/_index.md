---
title: OLE kezelése prezentációkban C++ segítségével
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
- hivatkozott objektum
- hivatkozott fájl
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
description: "Optimalizálja az OLE objektumok kezelését PowerPoint és OpenDocument fájlokban az Aspose.Slides for C++ segítségével. Beágyazhat, frissíthet és exportálhat OLE tartalmat zökkenőmentesen."
---
## **Bevezetés**

{{% alert title="Info" color="info" %}}
Az OLE (Object Linking & Embedding) egy Microsoft technológia, amely lehetővé teszi, hogy egy alkalmazásban létrehozott adatokat és objektumokat egy másik alkalmazásban helyezzük el hivatkozás vagy beágyazás útján. 
{{% /alert %}} 

Vegyünk egy a MS Excelben létrehozott diagramot. A diagramot ezután egy PowerPoint-diára helyezzük. Ez az Excel-diagram OLE objektumnak tekinthető. 

- Egy OLE objektum ikonként jelenhet meg. Ebben az esetben, ha duplán kattintunk az ikonra, a diagram a kapcsolódó alkalmazásban (Excel) nyílik meg, vagy felkérik, hogy válasszunk egy alkalmazást az objektum megnyitásához vagy szerkesztéséhez. 
- Egy OLE objektum megjelenítheti saját tartalmát, például egy diagram adatait. Ebben az esetben a diagram a PowerPointban aktiválódik, a diagram felület betöltődik, és a PowerPointon belül módosíthatjuk a diagram adatait. 

[Aspose.Slides for C++](https://products.aspose.com/slides/hu/cpp/) lehetővé teszi OLE objektumok beillesztését a diákba OLE objektumkeretként (OleObjectFrame).

## **OLE objektumkeretek hozzáadása a diákhoz**

Tegyük fel, hogy már létrehoztál egy diagramot a Microsoft Excelben, és azt egy OLE objektumkeretként szeretnéd beágyazni egy diára az Aspose.Slides for C++ segítségével, ezt a következőképpen teheted meg:

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.  
2. Szerezz egy hivatkozást a diára az indexe alapján.  
3. Olvasd be az Excel-fájlt bájt tömbként.  
4. Add hozzá a [OleObjectFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/oleobjectframe/) keretet a diához, amely tartalmazza a bájt tömböt és egyéb információkat az OLE objektumról.  
5. Írd ki a módosított prezentációt PPTX fájlként.  

Az alábbi példában egy Excel-fájlból származó diagramot adtunk hozzá a diához [OleObjectFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/oleobjectframe/) keretként az Aspose.Slides for C++ segítségével. **Megjegyzés** hogy a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/hu/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) konstruktor második paraméterként egy beágyazható objektum kiterjesztést vesz át. Ez a kiterjesztés lehetővé teszi a PowerPoint számára, hogy helyesen értelmezze a fájltípust, és a megfelelő alkalmazást válassza az OLE objektum megnyitásához. 

``` cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/size_f.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);

// Előkészíti az OLE objektum adatait.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// Add the OLE object frame to the slide.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Hivatkozott OLE objektumkeretek hozzáadása**

Az Aspose.Slides for C++ lehetővé teszi egy [OleObjectFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/oleobjectframe/) hozzáadását adat beágyazása nélkül, csak a fájlra mutató hivatkozással.

Ez a C++ kód bemutatja, hogyan adhatunk hozzá egy [OleObjectFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/oleobjectframe/) keretet hivatkozott Excel-fájllal egy diához: 

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// OLE objektumkeret hozzáadása hivatkozott Excel-fájllal.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **OLE objektumkeretek elérése**

Ha egy OLE objektum már be van ágyazva egy dián, egyszerűen megtalálhatod vagy elérheted a következő módon:

1. Tölts be egy prezentációt, amely tartalmazza a beágyazott OLE objektumot, úgy, hogy létrehozod a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztály egy példányát.  
2. Szerezz egy hivatkozást a diára az indexének használatával.  
3. Érj el a [OleObjectFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/oleobjectframe/) alakzatot. A példánkban a korábban létrehozott PPTX-et használtuk, amelyen az első dián csak egy alakzat van. Ezután *cast*-oltuk az objektumot [IOleObjectFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ioleobjectframe/) típussá. Ez volt a kívánt OLE objektumkeret, amelyet el szerettünk érni.  
4. Miután elérted az OLE objektumkeretet, bármilyen műveletet végrehajthatsz rajta.  

Az alábbi példában egy OLE objektumkeret (egy beágyazott Excel-diagram objektum) és a hozzá tartozó fájl adat elérhető. 

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{ 
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Lekérdezi a beágyazott fájl adatait.
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // Lekérdezi a beágyazott fájl kiterjesztését.
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

    // ...
}
```

### **Hivatkozott OLE objektumkeret tulajdonságainak elérése**

Az Aspose.Slides lehetővé teszi a hivatkozott OLE objektumkeret tulajdonságainak elérését. 

Ez a C++ kód megmutatja, hogyan ellenőrizheted, hogy egy OLE objektum hivatkozott‑e, és hogyan nyerheted ki a hivatkozott fájl elérési útját: 

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.ppt");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Ellenőrzi, hogy az OLE objektum hivatkozott-e.
    if (oleFrame->get_IsObjectLink())
    {
        // Kiírja a hivatkozott fájl teljes útvonalát.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // Kiírja a hivatkozott fájl relatív útvonalát, ha létezik.
        // Csak a PPT prezentációk tartalmazhatják a relatív útvonalat.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **OLE objektum adatának módosítása**

{{% alert color="info" %}} 
Ebben a szakaszban az alábbi kódpélda a [Aspose.Cells for C++](/cells/cpp/) használja. 
{{% /alert %}}

Ha egy OLE objektum már be van ágyazva egy dián, a következő módon könnyedén elérheted és módosíthatod annak adatait:

1. Tölts be egy prezentációt, amely tartalmazza a beágyazott OLE objektumot, úgy, hogy létrehozod a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztály egy példányát.  
2. Szerezz egy hivatkozást a diára az indexe alapján.  
3. Érj el a [OLEObjectFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/oleobjectframe/) alakzatot. A példánkban a korábban létrehozott PPTX-et használtuk, amelyen az első dián egy alakzat van. Ezután *cast*-oltuk az objektumot [IOleObjectFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ioleobjectframe/) típussá. Ez volt a kívánt OLE objektumkeret, amelyet el szerettünk érni.  
4. Miután elérted az OLE objektumkeretet, bármilyen műveletet végrehajthatsz rajta.  
5. Hozz létre egy `Workbook` objektumot, és férj hozzá az OLE adatokhoz.  
6. Érj el a kívánt `Worksheet`-et, és módosítsd az adatokat.  
7. Mentsd el a frissített `Workbook`-ot egy streambe.  
8. Módosítsd az OLE objektum adatait a streamből.  

Az alábbi példában egy OLE objektumkeret (egy beágyazott Excel-diagram objektum) elérhető, és a fájl adatai módosítva vannak, hogy frissítsék a diagram adatait. 

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/OoxmlSaveOptions.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Az Aspose.Cells for C++-t el kell indítani, mielőtt bármely típusát használnánk.
Aspose::Cells::Startup();

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// Get the first shape as an OLE object frame.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // Olvassa be az OLE objektum adatát Workbook objektumként.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // Módosítsa a Workbook adatait.
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

    // Cserélje le az OLE keret objektum adatait.
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);

Aspose::Cells::Cleanup();
```

## **Más fájltípusok beágyazása diákba**

Az Excel-diagramokon kívül az Aspose.Slides for C++ lehetővé teszi más fájltípusok beágyazását a diákba. Például HTML, PDF és ZIP fájlokat is beilleszthetsz objektumként. Amikor a felhasználó duplán kattint a beillesztett objektumra, az automatikusan megnyílik a megfelelő programban, vagy a felhasználót felszólítják, hogy válasszon egy megfelelő programot a megnyitáshoz. 

Ez a C++ kód bemutatja, hogyan ágyazhatod be a HTML-t és a ZIP-et egy diára: 

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

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

## **Beágyazott objektumok fájltípusának beállítása**

Prezentációk kezelése közben előfordulhat, hogy régi OLE objektumokat újakkal kell helyettesíteni, vagy nem támogatott OLE objektumot támogatottal. Az Aspose.Slides for C++ lehetővé teszi a beágyazott objektum fájltípusának beállítását, így frissítheted az OLE keret adatait vagy annak kiterjesztését. 

Ez a C++ kód bemutatja, hogyan állíthatod be a beágyazott OLE objektum fájltípusát `zip`‑re: 

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();
auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

std::wcout << L"Current embedded file extension is: " << fileExtension << std::endl;

// A fájltípus módosítása ZIP-re.
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ikonképek és címek beállítása beágyazott objektumokhoz**

Egy OLE objektum beágyazása után automatikusan hozzáadódik egy előnézet, amely ikonképből áll. Ez az előnézet látható a felhasználók számára, mielőtt a OLE objektumot megnyitnák vagy elérnék. Ha egy adott képet és szöveget szeretnél használni az előnézet elemeiként, az Aspose.Slides for C++ segítségével beállíthatod az ikonképet és a címet. 

Ez a C++ kód bemutatja, hogyan állíthatod be az ikonképet és a címet egy beágyazott objektumhoz: 

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Kép hozzáadása a prezentáció erőforrásaihoz.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Az OLE objektumkeret átméretezésének és áthelyezésének megakadályozása**

Miután egy hivatkozott OLE objektumot hozzáadsz egy prezentációs diára, a PowerPoint megnyitásakor megjelenhet egy üzenet, amely a hivatkozások frissítését kéri. Az “Update Links” gomb megnyomása megváltoztathatja az OLE objektumkeret méretét és pozícióját, mivel a PowerPoint frissíti a hivatkozott OLE objektum adatait, és újratölti az előnézetet. Ahhoz, hogy a PowerPoint ne kérje az objektum adatainak frissítését, állítsd a [IOleObjectFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ioleobjectframe/) interfész `set_UpdateAutomatic` metódusát `false`‑ra: 

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

oleFrame->set_UpdateAutomatic(false);
```

## **Beágyazott fájlok kinyerése**

Az Aspose.Slides for C++ lehetővé teszi a diákba beágyazott, OLE objektumként tárolt fájlok kinyerését a következő módon:

1. Hozz létre egy [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztály példányt, amely a kinyerni kívánt OLE objektumokat tartalmazza.  
2. Járd be a prezentáció összes alakzatát, és érj hozzá az [OLEObjectFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/oleobjectframe/) alakzatokhoz.  
3. Férj hozzá a beágyazott fájlok adataihoz az OLE objektumkeretekből, és írd őket le a lemezre.  

Ez a C++ kód bemutatja, hogyan nyerheted ki a diában beágyazott fájlokat OLE objektumokként: 

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

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

### **Az OLE tartalom megjelenik‑e a diák PDF‑ vagy képexportálásakor?**

A dián látható elem kerül renderelésre – az ikon/helyettesítő kép (előnézet). Az „élő” OLE tartalom nem kerül végrehajtásra a renderelés során. Szükség esetén állíts be saját előnézeti képet, hogy a várt megjelenés megjelenjen az exportált PDF‑ben.  

### **Hogyan zárolhatok egy OLE objektumot a dián, hogy a felhasználók ne mozgassák vagy szerkesszék PowerPointban?**

Zárolhatod az alakzatot: az Aspose.Slides [alakzatszintű zárolásokat](/slides/hu/cpp/applying-protection-to-presentation/) biztosít. Ez nem titkosítás, de hatékonyan megakadályozza a véletlen szerkesztéseket és az áthelyezést.  

### **Miért ugrál vagy változik mérete egy hivatkozott Excel‑objektum, amikor megnyitom a prezentációt?**

A PowerPoint frissítheti a hivatkozott OLE előnézetét. A stabil megjelenés érdekében kövesd a [Működő megoldást a munkalap átméretezéséhez](/slides/hu/cpp/working-solution-for-worksheet-resizing/) ajánlásait – vagy illeszd a keretet a tartományhoz, vagy méretezd a tartományt egy fix kerethez, és állíts be megfelelő helyettesítő képet.  

### **A hivatkozott OLE objektumok relatív útvonalai megmaradnak‑e a PPTX formátumban?**

A PPTX‑ben nincs relatív útvonal‑információ – csak a teljes útvonal tárolódik. A relatív útvonalak a régebbi PPT formátumban érhetők el. A hordozhatóság érdekében használj megbízható abszolút útvonalakat vagy elérhető URI‑kat, vagy ágyazd be a fájlokat.