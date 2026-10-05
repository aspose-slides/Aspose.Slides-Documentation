---
title: OLE beheren in presentaties met C++
linktitle: OLE beheren
type: docs
weight: 40
url: /nl/cpp/manage-ole/
keywords:
- OLE-object
- Objectkoppeling & insluiting
- OLE toevoegen
- OLE insluiten
- object toevoegen
- object insluiten
- bestand toevoegen
- bestand insluiten
- gekoppeld object
- gekoppeld bestand
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
description: "Optimaliseer het beheer van OLE-objecten in PowerPoint- en OpenDocument-bestanden met Aspose.Slides voor C++. Voeg OLE-inhoud in, werk deze bij en exporteer ze naadloos."
---
## **Introductie**

{{% alert color="info" title="Opmerking" %}}

OLE (Object Linking & Embedding) is een Microsoft‑technologie die het mogelijk maakt om gegevens en objecten die in één toepassing zijn gemaakt, in een andere toepassing te plaatsen via koppeling of insluiting. 

{{% /alert %}} 

Stel een diagram voor dat in MS Excel is gemaakt. Het diagram wordt vervolgens in een PowerPoint‑dia geplaatst. Dat Excel‑diagram wordt beschouwd als een OLE‑object. 

- Een OLE‑object kan verschijnen als een pictogram. In dat geval wordt, wanneer u dubbelklikt op het pictogram, het diagram geopend in de bijbehorende toepassing (Excel), of wordt u gevraagd een toepassing te selecteren voor het openen of bewerken van het object. 
- Een OLE‑object kan de feitelijke inhoud weergeven, zoals de inhoud van een diagram. In dat geval wordt het diagram geactiveerd in PowerPoint, laadt de diagraminterface en kunt u de gegevens van het diagram binnen PowerPoint aanpassen.

[Aspose.Slides voor C++](https://products.aspose.com/slides/cpp/) maakt het mogelijk OLE‑objecten in dia's in te voegen als OLE‑objectframes ([OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/)).

## **OLE‑objectframes aan dia's toevoegen**

Als u al een diagram in Microsoft Excel hebt gemaakt en het wilt insluiten in een dia als een OLE‑objectframe met Aspose.Slides voor C++, kunt u dit op de volgende manier doen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) klasse.  
2. Haal de referentie van een dia op via de index.  
3. Lees het Excel‑bestand als een byte‑array.  
4. Voeg het [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) toe aan de dia met de byte‑array en andere informatie over het OLE‑object.  
5. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een diagram uit een Excel‑bestand aan een dia toegevoegd als een [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) met Aspose.Slides voor C++. **Opmerking** dat de [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) constructor een extensie van een in te sluiten object als tweede parameter neemt. Deze extensie stelt PowerPoint in staat het bestandstype correct te interpreteren en de juiste toepassing te kiezen om dit OLE‑object te openen.

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

### **Gekoppelde OLE‑objectframes toevoegen**

Aspose.Slides voor C++ maakt het mogelijk een [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) toe te voegen zonder data in te sluiten, maar alleen met een koppeling naar het bestand.

Deze C++‑code laat zien hoe u een [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) met een gekoppeld Excel‑bestand aan een dia kunt toevoegen:

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

// Voeg een OLE-objectframe toe met een gekoppeld Excel-bestand.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Toegang tot OLE‑objectframes**

Als een OLE‑object al in een dia is ingesloten, kunt u het gemakkelijk vinden of benaderen op deze manier:

1. Laad een presentatie met het ingesloten OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) klasse te maken.  
2. Haal de referentie van de dia op door de index te gebruiken.  
3. Benader de [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/)‑vorm. In ons voorbeeld gebruikten we de eerder gemaakte PPTX die slechts één vorm heeft op de eerste dia. We *casten* dat object vervolgens naar een [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/). Dit was het gewenste OLE‑objectframe dat benaderd moest worden.  
4. Zodra het OLE‑objectframe is benaderd, kunt u er elke bewerking op uitvoeren.

In het onderstaande voorbeeld wordt een OLE‑objectframe (een Excel‑diagramobject dat in een dia is ingesloten) en de bestandsgegevens ervan benaderd.

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

    // Haal de ingebedde bestandsgegevens op.
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // Haal de extensie van het ingebedde bestand op.
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

    // ...
}
```

### **Gekoppelde OLE‑objectframe‑eigenschappen benaderen**

Aspose.Slides maakt het mogelijk gekoppelde OLE‑objectframe‑eigenschappen te benaderen.

Deze C++‑code laat zien hoe u kunt controleren of een OLE‑object gekoppeld is en vervolgens het pad naar het gekoppelde bestand kunt verkrijgen:

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

    // Controleer of het OLE object is gekoppeld.
    if (oleFrame->get_IsObjectLink())
    {
        // Print het volledige pad naar het gekoppelde bestand.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // Print het relatieve pad naar het gekoppelde bestand indien aanwezig.
        // Alleen PPT presentaties kunnen het relatieve pad bevatten.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **OLE‑objectgegevens wijzigen**

{{% alert color="info" title="Opmerking" %}}

In dit gedeelte maakt het onderstaande code‑voorbeeld gebruik van [Aspose.Cells for C++](https://docs.aspose.com/cells/cpp/).

{{% /alert %}}

Als een OLE‑object al in een dia is ingesloten, kunt u dat object gemakkelijk benaderen en de gegevens ervan op deze manier wijzigen:

1. Laad een presentatie met het ingesloten OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) klasse te maken.  
2. Haal de referentie van de dia op via de index.  
3. Benader de [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/)‑vorm. In ons voorbeeld gebruikten we de eerder gemaakte PPTX die één vorm heeft op de eerste dia. We *casten* dat object vervolgens naar een [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/). Dit was het gewenste OLE‑objectframe dat benaderd moest worden.  
4. Zodra het OLE‑objectframe is benaderd, kunt u er elke bewerking op uitvoeren.  
5. Maak een `Workbook`‑object aan en benader de OLE‑gegevens.  
6. Benader het gewenste `Worksheet` en pas de gegevens aan.  
7. Sla de bijgewerkte `Workbook` op in een stream.  
8. Wijzig de OLE‑objectgegevens vanuit de stream.

In het onderstaande voorbeeld wordt een OLE‑objectframe (een Excel‑diagramobject dat in een dia is ingesloten) benaderd, en worden de bestandsgegevens ervan gewijzigd om de diagramgegevens bij te werken.

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

// Aspose.Cells for C++ moet gestart worden voordat een van zijn types wordt gebruikt.
Aspose::Cells::Startup();

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// Get the first shape as an OLE object frame.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // Lees de OLE-objectgegevens als een Workbook-object.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // Pas de workbook-gegevens aan.
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

    // Wijzig de OLE-frame objectgegevens.
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);

Aspose::Cells::Cleanup();
```


## **Andere bestandstypen in dia's insluiten**

Naast Excel‑diagrammen maakt Aspose.Slides voor C++ het mogelijk andere soorten bestanden in dia's in te sluiten. U kunt bijvoorbeeld HTML-, PDF- en ZIP‑bestanden als objecten invoegen. Wanneer een gebruiker dubbelklikt op het ingevoegde object, wordt dit automatisch geopend in het relevante programma, of wordt de gebruiker gevraagd een geschikt programma te kiezen om het te openen.

Deze C++‑code laat zien hoe u HTML en ZIP in een dia kunt insluiten:

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

## **Bestandstypen voor ingesloten objecten instellen**

Wanneer u met presentaties werkt, moet u mogelijk oude OLE‑objecten vervangen door nieuwe of een niet‑ondersteund OLE‑object vervangen door een ondersteund. Aspose.Slides voor C++ maakt het mogelijk het bestandstype voor een ingesloten object in te stellen, zodat u de OLE‑framedata of de extensie kunt updaten.

Deze C++‑code laat zien hoe u het bestandstype voor een ingesloten OLE‑object kunt instellen op `zip`:

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

// Wijzig het bestandstype naar ZIP.
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Pictogramafbeeldingen en titels voor ingesloten objecten instellen**

Na het insluiten van een OLE‑object wordt er automatisch een voorbeeld‑preview toegevoegd bestaande uit een pictogramafbeelding. Deze preview is wat gebruikers zien voordat ze het OLE‑object benaderen of openen. Als u een specifieke afbeelding en tekst als elementen in de preview wilt gebruiken, kunt u de pictogramafbeelding en titel instellen met Aspose.Slides voor C++.

Deze C++‑code laat zien hoe u de pictogramafbeelding en titel voor een ingesloten object kunt instellen: 

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

// Set a title and the image for the OLE preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Voorkomen dat een OLE‑objectframe wordt vergroot/verplaatst**

Na het toevoegen van een gekoppeld OLE‑object aan een presentatiedia, kunt u bij het openen van de presentatie in PowerPoint een bericht zien dat vraagt de koppelingen bij te werken. Als u op de knop “Update Links” klikt, kan de grootte en positie van het OLE‑objectframe wijzigen omdat PowerPoint de gegevens van het gekoppelde OLE‑object bijwerkt en de preview ververst. Om te voorkomen dat PowerPoint vraagt de gegevens van het object bij te werken, roept u de [set_UpdateAutomatic](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/set_updateautomatic/)‑methode van de [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/)‑interface aan met `false`:

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

Aspose.Slides voor C++ maakt het mogelijk de in dia's ingesloten bestanden als OLE‑objecten op deze manier te extraheren:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑klasse die de OLE‑objecten bevat die u wilt extraheren.  
2. Loop door alle vormen in de presentatie en benader de [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/)‑vormen.  
3. Benader de gegevens van ingesloten bestanden vanuit OLE‑objectframes en schrijf ze naar schijf.

Deze C++‑code laat zien hoe u bestanden die in een dia zijn ingesloten als OLE‑objecten kunt extraheren:

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

**Wordt de OLE‑inhoud gerenderd bij het exporteren van dia's naar PDF/afbeeldingen?**

Wat zichtbaar is op de dia wordt gerenderd — het pictogram/alternatieve afbeelding (preview). De “live” OLE‑inhoud wordt niet uitgevoerd tijdens het renderen. Indien nodig stelt u uw eigen preview‑afbeelding in om de verwachte weergave in de geëxporteerde PDF te waarborgen.

Om het ingesloten bestand ook te behouden als PDF‑bijlage, roept u [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) aan met `true`. Deze optie is standaard uitgeschakeld. Voor een voorbeeld en instructies om de bijlage te controleren, zie [Ingesloten OLE‑bestanden behouden als PDF‑bijlagen](/slides/nl/cpp/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Hoe kan ik een OLE‑object op een dia vergrendelen zodat gebruikers het niet kunnen verplaatsen/bewerken in PowerPoint?**

Vergrendel de vorm: Aspose.Slides biedt [vormvergrendelingen](/slides/nl/cpp/applying-protection-to-presentation/). Dit is geen versleuteling, maar voorkomt effectief accidentele bewerkingen en verplaatsingen.

**Waarom springt een gekoppeld Excel‑object of verandert van grootte wanneer ik de presentatie open?**

PowerPoint kan de preview van het gekoppelde OLE vernieuwen. Voor een stabiele weergave volgt u de [Werkende oplossing voor werkbladschaling](/slides/nl/cpp/working-solution-for-worksheet-resizing/)‑praktijken — pas het frame aan op het bereik, of schaal het bereik naar een vast frame en stel een geschikt vervangende afbeelding in.

**Worden relatieve paden voor gekoppelde OLE‑objecten behouden in het PPTX‑formaat?**

In PPTX is informatie over “relative path” niet beschikbaar — alleen het volledige pad. Relatieve paden komen voor in het oudere PPT‑formaat. Voor draagbaarheid geeft u de voorkeur aan betrouwbare absolute paden/toegankelijke URI's of aan insluiting.