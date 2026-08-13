---
title: Beheer OLE in presentaties met C++
linktitle: OLE beheren
type: docs
weight: 40
url: /nl/cpp/manage-ole/
keywords:
- OLE-object
- "Objectkoppeling & insluiting"
- OLE toevoegen
- OLE insluiten
- object toevoegen
- object insluiten
- bestand toevoegen
- bestand insluiten
- gelinkt object
- gelinkt bestand
- OLE wijzigen
- OLE-pictogram
- OLE-titel
- OLE extraheren
- object extraheren
- bestand extraheren
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Optimaliseer het beheer van OLE-objecten in PowerPoint- en OpenDocument-bestanden met Aspose.Slides voor C++. Voeg OLE-inhoud in, werk het bij en exporteer het naadloos."
---
## **Inleiding**

{{% alert title="Info" color="info" %}}
OLE (Object Linking & Embedding) is een Microsoft‑technologie die het mogelijk maakt gegevens en objecten die in één applicatie zijn gemaakt, te plaatsen in een andere applicatie via koppeling of insluiting. 
{{% /alert %}}

Stel je een grafiek voor die is gemaakt in MS Excel. De grafiek wordt vervolgens in een PowerPoint‑dia geplaatst. Die Excel‑grafiek wordt beschouwd als een OLE‑object. 

- Een OLE‑object kan verschijnen als een pictogram. In dat geval wordt bij een dubbelklik op het pictogram de grafiek geopend in de bijbehorende applicatie (Excel), of wordt je gevraagd een applicatie te kiezen voor het openen of bewerken van het object. 
- Een OLE‑object kan zijn daadwerkelijke inhoud weergeven, bijvoorbeeld de inhoud van een grafiek. In dat geval wordt de grafiek geactiveerd in PowerPoint, laadt de grafiekomgeving, en kun je de gegevens van de grafiek binnen PowerPoint aanpassen. 

[Aspose.Slides for C++](https://products.aspose.com/slides/nl/cpp/) stelt je in staat OLE‑objecten in dia's in te voegen als OLE‑objectframes ([OleObjectFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/oleobjectframe/)).

## **OLE‑objectframes toevoegen aan dia's**

Aangenomen dat je al een grafiek hebt gemaakt in Microsoft Excel en deze wilt insluiten in een dia als OLE‑objectframe met Aspose.Slides for C++, kun je dit op de volgende manier doen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation) klasse.  
2. Haal de referentie van een dia op via de index.  
3. Lees het Excel‑bestand in als een byte‑array.  
4. Voeg het [OleObjectFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/oleobjectframe/) toe aan de dia met de byte‑array en andere informatie over het OLE‑object.  
5. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.  

In het onderstaande voorbeeld hebben we een grafiek uit een Excel‑bestand toegevoegd aan een dia als een [OleObjectFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/oleobjectframe/) met Aspose.Slides for C++.  
**Opmerking** dat de [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nl/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) constructor een uitbreidbaar object‑extensie als tweede parameter accepteert. Deze extensie stelt PowerPoint in staat het bestandstype correct te interpreteren en de juiste applicatie te kiezen om dit OLE‑object te openen.

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

### **Gelinkte OLE‑objectframes toevoegen**

Aspose.Slides for C++ maakt het mogelijk een [OleObjectFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/oleobjectframe/) toe te voegen zonder data in te sluiten, maar alleen met een koppeling naar het bestand.

Deze C++‑code laat zien hoe je een [OleObjectFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/oleobjectframe/) met een gelinkte Excel‑file aan een dia toevoegt:

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

// Voeg een OLE-objectframe toe met een gelinkte Excel-file.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **OLE‑objectframes benaderen**

Als een OLE‑object al is ingesloten in een dia, kun je het op deze manier eenvoudig vinden of benaderen:

1. Laad een presentatie met het ingesloten OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation) klasse te maken.  
2. Haal de referentie van de dia op via de index.  
3. Benader de [OleObjectFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/oleobjectframe/)‑shape. In ons voorbeeld gebruikten we de eerder aangemaakte PPTX die slechts één shape op de eerste dia bevat. We *casten* dat object vervolgens naar een [IOleObjectFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ioleobjectframe/). Dit was het gewenste OLE‑objectframe om te benaderen.  
4. Zodra het OLE‑objectframe benaderd is, kun je er elke bewerking op uitvoeren.  

In het onderstaande voorbeeld wordt een OLE‑objectframe (een Excel‑grafiekobject ingesloten in een dia) en de bijbehorende bestandsdata benaderd.

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

    // Haal de gegevens van het ingesloten bestand op.
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // Haal de extensie van het ingesloten bestand op.
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

    // ...
}
```

### **Eigenschappen van gelinkte OLE‑objectframes benaderen**

Aspose.Slides maakt het mogelijk de eigenschappen van gelinkte OLE‑objectframes te benaderen.

Deze C++‑code laat zien hoe je kunt controleren of een OLE‑object gelinkt is en vervolgens het pad naar het gelinkte bestand verkrijgt:

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

    // Controleer of het OLE‑object gelinkt is.
    if (oleFrame->get_IsObjectLink())
    {
        // Geef het volledige pad naar het gelinkte bestand weer.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // Geef het relatieve pad naar het gelinkte bestand weer indien aanwezig.
        // Alleen PPT‑presentaties kunnen het relatieve pad bevatten.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **OLE‑objectgegevens wijzigen**

{{% alert color="info" %}} 
In deze sectie gebruikt het onderstaande code‑voorbeeld [Aspose.Cells for C++](/cells/cpp/). 
{{% /alert %}}

Als een OLE‑object al is ingesloten in een dia, kun je dat object eenvoudig benaderen en de gegevens wijzigen op deze manier:

1. Laad een presentatie met het ingesloten OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation) klasse te maken.  
2. Haal de referentie van de dia op via de index.  
3. Benader de [OLEObjectFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/oleobjectframe/)‑shape. In ons voorbeeld gebruikten we de eerder aangemaakte PPTX die één shape op de eerste dia heeft. We *casten* dat object vervolgens naar een [IOleObjectFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ioleobjectframe/). Dit was het gewenste OLE‑objectframe om te benaderen.  
4. Zodra het OLE‑objectframe benaderd is, kun je er elke bewerking op uitvoeren.  
5. Creëer een `Workbook`‑object en benader de OLE‑gegevens.  
6. Benader het gewenste `Worksheet` en wijzig de gegevens.  
7. Sla het bijgewerkte `Workbook` op in een stream.  
8. Wijzig de OLE‑objectgegevens vanuit de stream.  

In het onderstaande voorbeeld wordt een OLE‑objectframe (een Excel‑grafiekobject ingesloten in een dia) benaderd, en wordt de bestandsdata aangepast om de grafiekgegevens bij te werken.

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

// Aspose.Cells for C++ moet worden gestart voordat een van de types wordt gebruikt.
Aspose::Cells::Startup();

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// Get the first shape as an OLE object frame.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // Lees de OLE‑objectgegevens als een Workbook‑object.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // Wijzig de gegevens van de workbook.
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

    // Verander de OLE‑frame‑objectgegevens.
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);

Aspose::Cells::Cleanup();
```

## **Andere bestandstypen insluiten in dia's**

Naast Excel‑grafieken maakt Aspose.Slides for C++ het mogelijk andere soorten bestanden in dia's in te sluiten. Je kunt bijvoorbeeld HTML‑, PDF‑ en ZIP‑bestanden als objecten invoegen. Wanneer een gebruiker dubbelklikt op het ingevoegde object, wordt dit automatisch geopend in het bijbehorende programma, of de gebruiker krijgt een prompt om een geschikt programma te kiezen.

Deze C++‑code laat zien hoe je HTML en ZIP in een dia kunt insluiten:

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

## **Bestandstypen instellen voor ingesloten objecten**

Bij het werken met presentaties moet je soms oude OLE‑objecten vervangen door nieuwe of een niet‑ondersteund OLE‑object vervangen door een ondersteund object. Aspose.Slides for C++ maakt het mogelijk het bestandstype voor een ingesloten object in te stellen, zodat je de OLE‑framedata of de extensie kunt bijwerken.

Deze C++‑code laat zien hoe je het bestandstype voor een ingesloten OLE‑object instelt op `zip`:

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

// Verander het bestandstype naar ZIP.
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Pictogram‑afbeeldingen en titels instellen voor ingesloten objecten**

Na het insluiten van een OLE‑object wordt er automatisch een preview met een pictogramafbeelding toegevoegd. Deze preview is wat gebruikers zien voordat ze het OLE‑object benaderen of openen. Als je een specifieke afbeelding en tekst wilt gebruiken in de preview, kun je via Aspose.Slides for C++ het pictogram en de titel instellen.

Deze C++‑code laat zien hoe je de pictogramafbeelding en de titel voor een ingesloten object instelt: 

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

// Voeg een afbeelding toe aan de presentatieresources.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Stel een titel en de afbeelding in voor de OLE‑preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Voorkom dat een OLE‑objectframe wordt aangepast in grootte en positie**

Nadat je een gelinkt OLE‑object aan een presentatiedia hebt toegevoegd, kun je bij het openen van de presentatie in PowerPoint een bericht zien dat vraagt de koppelingen bij te werken. Klikken op de knop “Update Links” kan de grootte en positie van het OLE‑objectframe wijzigen, omdat PowerPoint de data van het gelinkte OLE‑object bijwerkt en de preview ververst. Om te voorkomen dat PowerPoint vraagt om de data bij te werken, stel je de `set_UpdateAutomatic`‑methode van de [IOleObjectFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ioleobjectframe/)‑interface in op `false`:

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

## **Ingesloten bestanden extraheren**

Aspose.Slides for C++ maakt het mogelijk de bestanden die in dia's als OLE‑objecten zijn ingesloten op deze manier te extraheren:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation)‑klasse die de OLE‑objecten bevat die je wilt extraheren.  
2. Loop door alle shapes in de presentatie en benader de [OLEObjectFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/oleobjectframe/)‑shapes.  
3. Benader de data van de ingesloten bestanden uit OLE‑objectframes en schrijf ze naar schijf.  

Deze C++‑code laat zien hoe je bestanden die in een dia als OLE‑objecten zijn ingesloten, kunt extraheren:

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

### Wordt de OLE‑inhoud gerenderd bij het exporteren van dia's naar PDF/beelden?

Wat zichtbaar is op de dia wordt gerenderd – het pictogram/ vervangende beeld (preview). De “live” OLE‑inhoud wordt niet uitgevoerd tijdens het renderen. Indien nodig, stel je een eigen preview‑afbeelding in om de verwachte weergave in de geëxporteerde PDF te garanderen.

### Hoe kan ik een OLE‑object vergrendelen op een dia zodat gebruikers het niet kunnen verplaatsen/bewerken in PowerPoint?

Vergrendel de shape: Aspose.Slides biedt [shape‑level locks](/slides/nl/cpp/applying-protection-to-presentation/). Dit is geen encryptie, maar voorkomt effectief onbedoelde bewerkingen en verplaatsingen.

### Waarom “springt” of verandert een gelinkte Excel‑object van grootte wanneer ik de presentatie open?

PowerPoint kan de preview van het gelinkte OLE vernieuwen. Voor een stabiele weergave, volg de richtlijnen van de [Working Solution for Worksheet Resizing](/slides/nl/cpp/working-solution-for-worksheet-resizing/) – pas het frame aan op het bereik, of schaal het bereik naar een vast frame en stel een geschikt vervangend beeld in.

### Worden relatieve paden voor gelinkte OLE‑objecten behouden in het PPTX‑formaat?

In PPTX is informatie over “relatieve paden” niet beschikbaar – alleen het volledige pad. Relatieve paden komen voor in het oudere PPT‑formaat. Voor draagbaarheid geldt: gebruik bij voorkeur betrouwbare absolute paden/toegankelijke URI’s of insluiten.