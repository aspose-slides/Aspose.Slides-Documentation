---
title: OLE kezelése prezentációkban C++ használatával
linktitle: OLE kezelése
type: docs
weight: 40
url: /hu/cpp/manage-ole/
keywords:
- OLE objektum
- Objektum összekapcsolás és beágyazás
- OLE hozzáadása
- OLE beágyazása
- objektum hozzáadása
- objektum beágyazása
- fájl hozzáadása
- fájl beágyazása
- kapcsolt objektum
- kapcsolt fájl
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
description: "Optimalizálja az OLE objektumkezelést a PowerPoint és OpenDocument fájlokban az Aspose.Slides for C++ segítségével. Beágyazza, frissítse és exportálja az OLE tartalmat zökkenőmentesen."
---
## **Bevezetés**

{{% alert color="info" title="Note" %}}

Az OLE (Object Linking & Embedding) egy Microsoft technológia, amely lehetővé teszi, hogy egy alkalmazásban létrehozott adatokat és objektumokat egy másik alkalmazásba helyezzük el linkelés vagy beágyazás útján.

{{% /alert %}}

Tekintsd meg a Microsoft Excelben létrehozott diagramot. A diagramot aztán egy PowerPoint diára helyezik. Ez az Excel-diagram OLE objektumnak számít.

- Egy OLE objektum megjelenhet ikonként. Ebben az esetben, ha duplán rákattintasz az ikonra, a diagram megnyílik a kapcsolódó alkalmazásban (Excel), vagy felkérnek, hogy válassz egy alkalmazást az objektum megnyitásához vagy szerkesztéséhez.  
- Egy OLE objektum megjelenítheti a tényleges tartalmát, például egy diagram tartalmát. Ebben az esetben a diagram aktiválódik a PowerPointban, betöltődik a diagram felülete, és a PowerPointon belül módosíthatod a diagram adatait.

Az [Aspose.Slides for C++](https://products.aspose.com/slides/cpp/) lehetővé teszi, hogy OLE objektumokat illessz be a diákba OLE objektumkeretként ([OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/)).

## **OLE objektumkeretek hozzáadása a diákhoz**

Feltételezve, hogy már létrehoztál egy diagramot a Microsoft Excelben, és Aspose.Slides for C++ használatával egy OLE objektumkeretként szeretnéd beágyazni egy diára, ezt a módon teheted meg:

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) osztályból.  
2. Szerezz be egy dia hivatkozást az indexe alapján.  
3. Olvasd be az Excel fájlt bájttömbként.  
4. Add hozzá a [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) a bájttömböt és az OLE objektum egyéb adatait tartalmazó diához.  
5. Írd ki a módosított prezentációt PPTX fájlként.

Az alábbi példában egy Excel fájlból származó diagramot adtunk hozzá egy diára [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) segítségével, az Aspose.Slides for C++-ot használva. **Megjegyzés** hogy az [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) konstruktor második paraméterként egy beágyazható objektum kiterjesztést vár. Ez a kiterjesztés lehetővé teszi a PowerPoint számára, hogy helyesen értelmezze a fájltípust és kiválassza a megfelelő alkalmazást az OLE objektum megnyitásához.

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

// Prepare data for the OLE object.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// Add the OLE object frame to the slide.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Kapcsolt OLE objektumkeretek hozzáadása**

Az Aspose.Slides for C++ lehetővé teszi, hogy egy [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) adat beágyazása nélkül, csak egy fájlra mutató hivatkozással adjon hozzá.

Ez a C++ kód megmutatja, hogyan lehet egy [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) egy kapcsolt Excel fájllal hozzáadni egy diához:

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

// Olyan OLE objektumkeret hozzáadása egy kapcsolt Excel fájllal.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **OLE objektumkeretek elérése**

Ha egy OLE objektum már be van ágyazva egy diára, egyszerűen megtalálhatod vagy elérheted a következő módon:

1. Tölts be egy prezentációt a beágyazott OLE objektummal, egy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) osztály példányosításával.  
2. Szerezd meg a dia hivatkozását az indexének használatával.  
3. Érd el a [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) alakzatot.  
   Példánkban a korábban létrehozott PPTX-et használtuk, amelynek az első dián csak egy alakzata van. Ezután *cast*-oltuk azt az objektumot egy [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) típusra. Ez volt a kívánt OLE objektumkeret, amelyet el szeretnénk érni.  
4. Miután az OLE objektumkeret elérhető, bármilyen műveletet végrehajthatsz rajta.

Az alábbi példában egy OLE objektumkeret (egy beágyazott Excel-diagram objektum) és a fájladatai elérhetők.

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

    // A beágyazott fájl adatait kérjük le.
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // A beágyazott fájl kiterjesztését kérjük le.
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

    // ...
}
```

### **Kapcsolt OLE objektumkeret tulajdonságainak elérése**

Az Aspose.Slides lehetővé teszi a kapcsolt OLE objektumkeret tulajdonságainak elérését.

Ez a C++ kód megmutatja, hogyan ellenőrizheted, hogy egy OLE objektum kapcsolt-e, majd hogyan szerezheted meg a kapcsolt fájl elérési útját:

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

    // Ellenőrizze, hogy az OLE objektum linkelt-e.
    if (oleFrame->get_IsObjectLink())
    {
        // Kiírja a linkelt fájl teljes útvonalát.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // Kiírja a linkelt fájl relatív útvonalát, ha létezik.
        // Csak a PPT prezentációk tartalmazhatják a relatív útvonalat.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **OLE objektum adatának módosítása**

{{% alert color="info" title="Note" %}}

Ebben a szakaszban az alábbi kódrészlet a [Aspose.Cells for C++](https://docs.aspose.com/cells/cpp/) használatával készül.

{{% /alert %}}

Ha egy OLE objektum már be van ágyazva egy diára, egyszerűen elérheted azt az objektumot és módosíthatod az adatait a következő módon:

1. Tölts be egy prezentációt a beágyazott OLE objektummal, egy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) osztály példányosításával.  
2. Szerezd meg a dia hivatkozását az indexe alapján.  
3. Érd el a [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) alakzatot.  
   Példánkban a korábban létrehozott PPTX-et használtuk, amelynek az első dián egy alakzata van. Ezután *cast*-oltuk azt az objektumot egy [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) típusra. Ez volt a kívánt OLE objektumkeret, amelyet el szeretnénk érni.  
4. Miután az OLE objektumkeret elérhető, bármilyen műveletet végrehajthatsz rajta.  
5. Hozz létre egy `Workbook` objektumot és férj hozzá az OLE adatokhoz.  
6. Érd el a kívánt `Worksheet`-et és módosítsd az adatokat.  
7. Mentse a frissített `Workbook`-ot egy streambe.  
8. Módosítsd az OLE objektum adatait a streamből.

Az alábbi példában egy OLE objektumkeret (egy beágyazott Excel-diagram objektum) elérhető, és a fájladatai módosítva vannak a diagram adatok frissítéséhez.

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

    // Olvasd be az OLE objektum adatát Workbook objektumként.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // Módosítsd a munkafüzet adatait.
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

    // Módosítsd az OLE keret objektum adatait.
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);

Aspose::Cells::Cleanup();
```

## **Más fájltípusok beágyazása a diákba**

Az Excel diagramok mellett az Aspose.Slides for C++ lehetővé teszi más fájltípusok beágyazását is a diákba. Például HTML, PDF és ZIP fájlokat illeszthetsz be objektumként. Amikor a felhasználó duplán rákattint a beillesztett objektumra, az automatikusan megnyílik a megfelelő programban, vagy a felhasználót felszólítják, hogy válasszon egy megfelelő programot a megnyitáshoz.

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

Prezentációk dolgozása közben előfordulhat, hogy régi OLE objektumokat újakkal kell helyettesíteni, vagy egy nem támogatott OLE objektumot támogatottal kell cserélni. Az Aspose.Slides for C++ lehetővé teszi a beágyazott objektum fájltípusának beállítását, így frissítheted az OLE keret adatait vagy annak kiterjesztését.

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

// Change the file type to ZIP.
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ikonképek és címek beállítása beágyazott objektumokhoz**

OLE objektum beágyazása után automatikusan hozzáadódik egy előnézet, amely egy ikonképből áll. Ez az előnézet jelenik meg a felhasználóknak, mielőtt hozzáférnének vagy megnyitnák az OLE objektumot. Ha egy konkrét képet és szöveget szeretnél használni az előnézet elemként, beállíthatod az ikonképet és a címet az Aspose.Slides for C++ segítségével.

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

## **Megakadályozni, hogy egy OLE objektumkeret mérete vagy elhelyezése megváltozzon**

Miután egy kapcsolt OLE objektumot hozzáadsz egy prezentációs diára, a PowerPoint megnyitásakor előfordulhat, hogy egy üzenet jelenik meg a linkek frissítéséről. Az „Update Links” gombra kattintva az OLE objektumkeret mérete és pozíciója megváltozhat, mivel a PowerPoint frissíti a linkelt OLE objektum adatait és újratölti az objektum előnézetét. Ahhoz, hogy a PowerPoint ne kérje az objektum adatainak frissítését, hívd a [set_UpdateAutomatic](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/set_updateautomatic/) metódust a [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) interfészen `false` értékkel:

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

Az Aspose.Slides for C++ lehetővé teszi a diákba beágyazott OLE objektumokként tárolt fájlok kinyerését a következő módon:

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) osztályból, amely tartalmazza a kinyerni kívánt OLE objektumokat.  
2. Iterate (ciklus) át a prezentáció összes alakzatán, és érj el minden [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) alakzatot.  
3. Érd el a beágyazott fájlok adatait az OLE objektumkeretekből, és írd őket lemezre.

Ez a C++ kód megmutatja, hogyan lehet egy diában beágyazott fájlokat OLE objektumként kinyerni:

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

**Megjelenik-e az OLE tartalom, amikor a diák PDF/képek formátumba exportálódnak?**

A dián látható elem kerül renderelésre – az ikon/helyettesítő kép (előnézet). Az „élő” OLE tartalom nem hajtódik végre a renderelés során. Szükség esetén állíts be saját előnézeti képet, hogy a várt megjelenés legyen az exportált PDF-ben.

A beágyazott fájl PDF‑mellékletként való megőrzéséhez hívd a [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) metódust `true` értékkel. Ez a beállítás alapértelmezés szerint le van tiltva. Példáért és az ellenőrzési útmutatóért lásd a [Beágyazott OLE fájlok megőrzése PDF mellékletként](/slides/hu/cpp/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments) oldalt.

**Hogyan zárhatok le egy OLE objektumot egy dián, hogy a felhasználók ne mozgathassák/szerkesszék PowerPointban?**

Zárolhatod az alakzatot: az Aspose.Slides [alkalmazás‑szintű zárolásokat](/slides/hu/cpp/applying-protection-to-presentation/) kínál. Ez nem titkosítás, de hatékonyan megakadályozza a véletlen szerkesztéseket és áthelyezéseket.

**Miért "ugrik" vagy változik meg a mérete egy kapcsolt Excel objektumnak, amikor megnyitom a prezentációt?**

A PowerPoint frissítheti a kapcsolt OLE előnézetét. A stabil megjelenés érdekében kövesd a [Működő megoldás a munkalap átméretezéséhez](/slides/hu/cpp/working-solution-for-worksheet-resizing/) irányelveit – vagy illeszd a keretet a tartományra, vagy méretezd a tartományt egy rögzített kerethez, és állíts be megfelelő helyettesítő képet.

**Megmaradnak-e a kapcsolt OLE objektumok relatív útvonalai a PPTX formátumban?**

A PPTX-ben nem tárolódik a „relatív útvonal” információ – csak a teljes útvonal. Relatív útvonalak a régebbi PPT formátumban találhatók. A hordozhatóság érdekében részesítsd előnyben a megbízható abszolút útvonalakat/közvetlen URI‑kat vagy a beágyazást.