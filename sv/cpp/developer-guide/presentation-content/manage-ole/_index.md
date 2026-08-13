---
title: Hantera OLE i presentationer med C++
linktitle: Hantera OLE
type: docs
weight: 40
url: /sv/cpp/manage-ole/
keywords:
- OLE-objekt
- Objektlänkning och inbäddning
- lägga till OLE
- bädda in OLE
- lägga till objekt
- bädda in objekt
- lägga till fil
- bädda in fil
- länkat objekt
- länkat fil
- ändra OLE
- OLE-ikon
- OLE-titel
- extrahera OLE
- extrahera objekt
- extrahera fil
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Optimera hanteringen av OLE-objekt i PowerPoint- och OpenDocument-filer med Aspose.Slides för C++. Bädda in, uppdatera och exportera OLE-innehåll sömlöst."
---
## **Introduktion**

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) är en Microsoft‑teknik som gör att data och objekt som skapats i ett program kan placeras i ett annat program genom länkning eller inbäddning. 

{{% /alert %}} 

Tänk på ett diagram som skapats i MS Excel. Diagrammet placeras sedan i en PowerPoint‑bild. Det Excel‑diagrammet betraktas som ett OLE‑objekt. 

- Ett OLE‑objekt kan visas som en ikon. I så fall öppnas diagrammet i den associerade applikationen (Excel) när du dubbelklickar på ikonen, eller så blir du ombedd att välja en applikation för öppning eller redigering av objektet. 
- Ett OLE‑objekt kan visa sitt faktiska innehåll, till exempel ett diagram. I så fall aktiveras diagrammet i PowerPoint, diagramgränssnittet laddas och du kan ändra diagrammets data i PowerPoint.

[Aspose.Slides for C++](https://products.aspose.com/slides/sv/cpp/) gör det möjligt att infoga OLE‑objekt i bilder som OLE‑objektramar ([OleObjectFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/oleobjectframe/)).

## **Lägg till OLE‑objektramar i bilder**

Om du redan har skapat ett diagram i Microsoft Excel och vill bädda in det i en bild som en OLE‑objektram med Aspose.Slides for C++, kan du göra så här:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation). 
2. Hämta en referens till bilden via dess index. 
3. Läs Excel‑filen som en byte‑array. 
4. Lägg till [OleObjectFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/oleobjectframe/) på bilden och ange byte‑arrayen samt annan information om OLE‑objektet. 
5. Spara den modifierade presentationen som en PPTX‑fil.

I exemplet nedan har vi lagt till ett diagram från en Excel‑fil på en bild som ett [OleObjectFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/oleobjectframe/) med hjälp av Aspose.Slides for C++.  
**Obs** att konstruktorn för [OleEmbeddedDataInfo](https://reference.aspose.com/slides/sv/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) tar en inbäddningsbar objekt‑filändelse som andra parameter. Denna filändelse gör att PowerPoint korrekt kan tolka filtypen och välja rätt program för att öppna OLE‑objektet.

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

// Förbered data för OLE-objektet.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// Lägg till OLE-objektramen på bilden.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Lägg till länkade OLE‑objektramar**

Aspose.Slides for C++ gör det möjligt att lägga till ett [OleObjectFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/oleobjectframe/) utan att bädda in data, utan bara med en länk till filen.

Denna C++‑kod visar hur du lägger till ett [OleObjectFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/oleobjectframe/) med en länkad Excel‑fil på en bild:

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

// Lägg till en OLE-objektram med en länkad Excel-fil.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Åtkomst till OLE‑objektramar**

Om ett OLE‑objekt redan är inbäddat i en bild kan du enkelt hitta eller nå det på följande sätt:

1. Ladda en presentation med det inbäddade OLE‑objektet genom att skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation). 
2. Hämta referensen till bilden med hjälp av dess index. 
3. Åtkomst till [OleObjectFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/oleobjectframe/)-formen. I vårt exempel använde vi den tidigare skapade PPTX‑filen som bara har en form på den första bilden. Vi *castade* sedan det objektet till en [IOleObjectFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ioleobjectframe/). Detta var den önskade OLE‑objektramen som skulle nås. 
4. När OLE‑objektramen har nåtts kan du utföra vilken operation som helst på den.

I exemplet nedan nås ett OLE‑objektram (ett inbäddat Excel‑diagram i en bild) och dess fildata.

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

    // Hämta den inbäddade filens data.
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // Hämta filändelsen för den inbäddade filen.
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

    // ...
}
```

### **Åtkomst till egenskaper för länkad OLE‑objektram**

Aspose.Slides gör det möjligt att läsa egenskaper för länkade OLE‑objektramar.

Denna C++‑kod visar hur du kontrollerar om ett OLE‑objekt är länkat och sedan får sökvägen till den länkade filen:

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

    // Kontrollera om OLE-objektet är länkat.
    if (oleFrame->get_IsObjectLink())
    {
        // Skriv ut hela sökvägen till den länkade filen.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // Skriv ut den relativa sökvägen till den länkade filen om den finns.
        // Endast PPT-presentationer kan innehålla den relativa sökvägen.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **Ändra OLE‑objektdata**

{{% alert color="info" %}} 

I detta avsnitt använder kodexemplet nedan [Aspose.Cells for C++](/cells/cpp/).

{{% /alert %}}

Om ett OLE‑objekt redan är inbäddat i en bild kan du enkelt nå objektet och ändra dess data på följande sätt:

1. Ladda en presentation med det inbäddade OLE‑objektet genom att skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation). 
2. Hämta bildens referens via dess index. 
3. Åtkomst till [OLEObjectFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/oleobjectframe/)-formen. I vårt exempel använde vi den tidigare skapade PPTX‑filen som har en form på den första bilden. Vi *castade* sedan det objektet till en [IOleObjectFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ioleobjectframe/). Detta var den önskade OLE‑objektramen som skulle nås. 
4. När OLE‑objektramen har nåtts kan du utföra vilken operation som helst på den. 
5. Skapa ett `Workbook`‑objekt och nå OLE‑datan. 
6. Åtkomst till önskat `Worksheet` och ändra datan. 
7. Spara det uppdaterade `Workbook` i ett flöde. 
8. Ändra OLE‑objektdatan från flödet.

I exemplet nedan nås ett OLE‑objektram (ett inbäddat Excel‑diagram i en bild) och dess fildata modifieras för att uppdatera diagrammets data.

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

// Aspose.Cells för C++ måste startas innan någon av dess typer används.
Aspose::Cells::Startup();

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// Get the first shape as an OLE object frame.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // Läs OLE-objektdatan som ett Workbook-objekt.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // Modifiera arbetsbokens data.
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

    // Ändra OLE-ramobjektets data.
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);

Aspose::Cells::Cleanup();
```

## **Bädda in andra filtyper i bilder**

Förutom Excel‑diagram gör Aspose.Slides for C++ det möjligt att bädda in andra typer av filer i bilder. Du kan till exempel infoga HTML-, PDF- och ZIP‑filer som objekt. När en användare dubbelklickar på det infogade objektet öppnas det automatiskt i det relevanta programmet, eller så blir användaren ombedd att välja ett lämpligt program för att öppna det.

Denna C++‑kod visar hur du bäddar in HTML och ZIP i en bild:

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

## **Ange filtyper för inbäddade objekt**

När du arbetar med presentationer kan det vara nödvändigt att ersätta gamla OLE‑objekt med nya eller att ersätta ett ej‑stödd OLE‑objekt med ett stödd. Aspose.Slides for C++ gör det möjligt att ange filtyp för ett inbäddat objekt, så att du kan uppdatera OLE‑ramens data eller dess filändelse.

Denna C++‑kod visar hur du sätter filtypen för ett inbäddat OLE‑objekt till `zip`:

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

// Ändra filtypen till ZIP.
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ange ikonbilder och titlar för inbäddade objekt**

Efter att ha bäddat in ett OLE‑objekt läggs automatiskt en förhandsgranskning bestående av en ikonbild till. Denna förhandsgranskning är vad användarna ser innan de öppnar eller får åtkomst till OLE‑objektet. Om du vill använda en specifik bild och text som element i förhandsgranskningen kan du ange ikonbild och titel med Aspose.Slides for C++.

Denna C++‑kod visar hur du anger ikonbild och titel för ett inbäddat objekt: 

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

// Lägg till en bild i presentationens resurser.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Förhindra att en OLE‑objektram ändras i storlek och position**

Efter att du har lagt till ett länkat OLE‑objekt i en presentationsbild kan du, när du öppnar presentationen i PowerPoint, få ett meddelande som ber dig uppdatera länkarna. Om du klickar på knappen **Uppdatera länkar** kan storleken och positionen på OLE‑objektramen ändras eftersom PowerPoint uppdaterar data från det länkade OLE‑objektet och uppdaterar förhandsgranskningen. För att förhindra att PowerPoint frågar om att uppdatera objektets data, sätt `set_UpdateAutomatic`‑metoden på [IOleObjectFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ioleobjectframe/)‑gränssnittet till `false`:

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

## **Extrahera inbäddade filer**

Aspose.Slides for C++ gör det möjligt att extrahera filer som är inbäddade i bilder som OLE‑objekt på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation) som innehåller de OLE‑objekt du vill extrahera. 
2. Loop igenom alla former i presentationen och nå [OLEObjectFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/oleobjectframe/)-formerna. 
3. Läs data från inbäddade filer i OLE‑objektramarna och skriv dem till disk.

Denna C++‑kod visar hur du extraherar filer som är inbäddade i en bild som OLE‑objekt:

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

## **FAQ**

### Kommer OLE‑innehållet att renderas när man exporterar bilder till PDF/bilder?

Det som är synligt på bilden renderas – ikonen/ersättningsbilden (förhandsgranskning). Det ”levande” OLE‑innehållet körs inte under rendering. Vid behov, ange en egen förhandsgranskningsbild för att säkerställa önskat utseende i den exporterade PDF‑filen.

### Hur kan jag låsa ett OLE‑objekt på en bild så att användare inte kan flytta/redigera det i PowerPoint?

Lås formen: Aspose.Slides tillhandahåller [form‑nivå låsning](/slides/sv/cpp/applying-protection-to-presentation/). Detta är ingen kryptering, men det förhindrar i praktiken oavsiktliga ändringar och förflyttningar.

### Varför “hoppar” ett länkat Excel‑objekt eller ändrar storlek när jag öppnar presentationen?

PowerPoint kan uppdatera förhandsgranskningen av det länkade OLE‑objektet. För ett stabilt utseende, följ bästa praxis i [Working Solution for Worksheet Resizing](/slides/sv/cpp/working-solution-for-worksheet-resizing/) – antingen anpassa ramen till området eller skala området till en fast ram och ange en lämplig ersättningsbild.

### Bevaras relativa sökvägar för länkade OLE‑objekt i PPTX‑formatet?

I PPTX finns ingen information om “relativ sökväg” – endast den fullständiga sökvägen. Relativa sökvägar finns bara i det äldre PPT‑formatet. För portabilitet, föredra pålitliga absoluta sökvägar/åtkomliga URI‑er eller inbäddning.