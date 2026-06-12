---
title: Beheer OLE in presentaties met C++
linktitle: Beheer OLE
type: docs
weight: 40
url: /nl/cpp/manage-ole/
keywords:
- OLE-object
- Objectkoppeling en insluiting
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
description: "Optimaliseer het beheer van OLE-objecten in PowerPoint- en OpenDocument-bestanden met Aspose.Slides voor C++. Sluit OLE-inhoud in, werk bij en exporteer deze moeiteloos."
---
## **Inleiding**

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) is een Microsoft‑technologie die het mogelijk maakt gegevens en objecten die in één toepassing zijn gemaakt, in een andere toepassing te plaatsen via koppeling of insluiting. 

{{% /alert %}} 

Beschouw een diagram dat in MS Excel is gemaakt. Het diagram wordt vervolgens in een PowerPoint‑dia geplaatst. Dat Excel‑diagram wordt beschouwd als een OLE‑object. 

- Een OLE‑object kan verschijnen als een pictogram. In dat geval wordt, wanneer u dubbelklikt op het pictogram, het diagram geopend in de bijbehorende toepassing (Excel), of wordt u gevraagd een toepassing te kiezen voor het openen of bewerken van het object. 
- Een OLE‑object kan zijn daadwerkelijke inhoud weergeven, zoals de inhoud van een diagram. In dat geval wordt het diagram geactiveerd in PowerPoint, de diagram‑interface wordt geladen en kunt u de diagram‑gegevens binnen PowerPoint aanpassen.

[Aspose.Slides for C++](https://products.aspose.com/slides/nl/cpp/) stelt u in staat OLE‑objecten in dia’s in te voegen als OLE‑objectframes ([OleObjectFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/oleobjectframe/)).

## **OLE‑objectframes aan dia’s toevoegen**

Ga ervan uit dat u al een diagram in Microsoft Excel hebt gemaakt en dit als OLE‑objectframe in een dia wilt insluiten met Aspose.Slides for C++. Dan kunt u dit als volgt doen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation) klasse.
2. Verkrijg een referentie naar een dia via de index.
3. Lees het Excel‑bestand in als een byte‑array.
4. Voeg het [OleObjectFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/oleobjectframe/) toe aan de dia met de byte‑array en andere informatie over het OLE‑object.
5. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een diagram uit een Excel‑bestand aan een dia toegevoegd als een [OleObjectFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/oleobjectframe/) met behulp van Aspose.Slides for C++.
**Let op** dat de constructor van [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nl/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) een extensie van het in te sluiten object als tweede parameter ontvangt. Deze extensie stelt PowerPoint in staat het bestandstype correct te interpreteren en de juiste toepassing te kiezen om dit OLE‑object te openen.

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

### **Gekoppelde OLE‑objectframes toevoegen**

Aspose.Slides for C++ maakt het mogelijk een [OleObjectFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/oleobjectframe/) toe te voegen zonder data in te sluiten, maar alleen met een koppeling naar het bestand.

Deze C++‑code toont hoe u een [OleObjectFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/oleobjectframe/) met een gekoppeld Excel‑bestand aan een dia kunt toevoegen:

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Voeg een OLE-objectframe toe met een gekoppeld Excel-bestand.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **OLE‑objectframes benaderen**

Als een OLE‑object al in een dia is ingesloten, kunt u het eenvoudig vinden of benaderen als volgt:

1. Laad een presentatie met het ingesloten OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation) klasse te maken.
2. Verkrijg de referentie van de dia via de index.
3. Benader de [OleObjectFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/oleobjectframe/)‑vorm.
   In ons voorbeeld hebben we de eerder gemaakte PPTX gebruikt die slechts één vorm op de eerste dia bevat.  Vervolgens *casten* we dat object naar een [IOleObjectFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ioleobjectframe/). Dit was het gewenste OLE‑objectframe dat benaderd moest worden.
4. Zodra het OLE‑objectframe is benaderd, kunt u er elke bewerking op uitvoeren.

In het onderstaande voorbeeld wordt een OLE‑objectframe (een Excel‑diagramobject ingesloten in een dia) en de bijbehorende bestandsdata benaderd.

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{ 
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Haal de ingesloten bestandsdata op.
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // Haal de extensie van het ingesloten bestand op.
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

    // ...
}
```

### **Eigenschappen van gekoppelde OLE‑objectframes benaderen**

Aspose.Slides maakt het mogelijk de eigenschappen van gekoppelde OLE‑objectframes te benaderen.

Deze C++‑code toont hoe u kunt controleren of een OLE‑object gekoppeld is en vervolgens het pad naar het gekoppelde bestand kunt verkrijgen:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.ppt");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Controleer of het OLE-object gekoppeld is.
    if (oleFrame->get_IsObjectLink())
    {
        // Print het volledige pad naar het gekoppelde bestand.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // Print het relatieve pad naar het gekoppelde bestand indien aanwezig.
        // Alleen PPT-presentaties kunnen het relatieve pad bevatten.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **OLE‑objectdata wijzigen**

{{% alert color="primary" %}} 

In dit gedeelte maakt het onderstaande code‑voorbeeld gebruik van [Aspose.Cells for C++](/cells/cpp/).

{{% /alert %}}

Als een OLE‑object al in een dia is ingesloten, kunt u dat object eenvoudig benaderen en de gegevens ervan als volgt wijzigen:

1. Laad een presentatie met het ingesloten OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation) klasse te maken.
2. Verkrijg de referentie van de dia via de index. 
3. Benader de [OLEObjectFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/oleobjectframe/)‑vorm.
   In ons voorbeeld hebben we de eerder gemaakte PPTX gebruikt die één vorm op de eerste dia bevat.  Vervolgens *casten* we dat object naar een [IOleObjectFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ioleobjectframe/). Dit was het gewenste OLE‑objectframe dat benaderd moest worden.
4. Zodra het OLE‑objectframe is benaderd, kunt u er elke bewerking op uitvoeren.
5. Maak een `Workbook`‑object en benader de OLE‑data.
6. Benader het gewenste `Worksheet` en wijzig de gegevens.
7. Sla het bijgewerkte `Workbook` op in een stream.
8. Wijzig de OLE‑objectdata vanuit de stream.

In het onderstaande voorbeeld wordt een OLE‑objectframe (een Excel‑diagramobject ingesloten in een dia) benaderd en wordt de bestandsdata aangepast om de diagramgegevens bij te werken.

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// Haal de eerste vorm op als een OLE-objectframe.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // Lees de OLE-objectdata in als een Workbook-object.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // Wijzig de workbook-data.
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

    // Wijzig de OLE-frame-objectdata.
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Andere bestandstypen insluiten in dia’s**

Naast Excel‑diagrammen maakt Aspose.Slides for C++ het mogelijk andere bestandstypen in dia’s in te sluiten. U kunt bijvoorbeeld HTML‑, PDF‑ en ZIP‑bestanden als objecten invoegen. Wanneer een gebruiker dubbelklikt op het ingevoegde object, wordt het automatisch geopend in het bijbehorende programma, of krijgt de gebruiker de mogelijkheid om een geschikt programma te selecteren.

Deze C++‑code toont hoe u HTML en ZIP in een dia kunt insluiten:

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

## **Bestandstypen voor ingesloten objecten instellen**

Bij het werken met presentaties kan het nodig zijn oude OLE‑objecten te vervangen door nieuwe, of een niet‑ondersteund OLE‑object te vervangen door een ondersteund exemplaar. Aspose.Slides for C++ stelt u in staat het bestandstype voor een ingesloten object in te stellen, zodat u de OLE‑frame‑data of extensie kunt bijwerken.

Deze C++‑code toont hoe u het bestandstype voor een ingesloten OLE‑object op `zip` zet:

``` cpp
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

## **Pictogrammen en titels voor ingesloten objecten instellen**

Na het insluiten van een OLE‑object wordt er automatisch een voorbeeld met een pictogramafbeelding toegevoegd. Dit voorbeeld is wat gebruikers zien voordat ze het OLE‑object benaderen of openen. Als u een specifieke afbeelding en tekst als elementen in het voorbeeld wilt gebruiken, kunt u het pictogram en de titel instellen met Aspose.Slides for C++.

Deze C++‑code toont hoe u de pictogramafbeelding en titel voor een ingesloten object instelt: 

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Voeg een afbeelding toe aan de presentatiebronnen.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Stel een titel en de afbeelding in voor de OLE-voorbeeld.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Voorkomen dat een OLE‑objectframe van formaat of positie verandert**

Nadat u een gekoppeld OLE‑object aan een presentatiedia heeft toegevoegd, kunt u bij het openen van de presentatie in PowerPoint een melding zien die vraagt de koppelingen bij te werken. Het klikken op de knop “Update Links” kan de grootte en positie van het OLE‑objectframe wijzigen omdat PowerPoint de gegevens van het gekoppelde OLE‑object bijwerkt en de voorvertoning ververst. Om te voorkomen dat PowerPoint vraagt de gegevens van het object bij te werken, stelt u de `set_UpdateAutomatic`‑methode van de [IOleObjectFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ioleobjectframe/)‑interface in op `false`:

```cpp
oleFrame->set_UpdateAutomatic(false);
```

## **Ingesloten bestanden extraheren**

Aspose.Slides for C++ maakt het mogelijk bestanden die als OLE‑objecten in dia’s zijn ingesloten, als volgt te extraheren:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation)‑klasse die de OLE‑objecten bevat die u wilt extraheren.
2. Loop door alle vormen in de presentatie en benader de [OLEObjectFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/oleobjectframe/)‑vormen.
3. Haal de data van ingesloten bestanden op uit OLE‑objectframes en schrijf deze naar schijf.

Deze C++‑code toont hoe u bestanden die als OLE‑objecten in een dia zijn ingesloten, kunt extraheren:

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

## **FAQ**

**Wordt de OLE‑inhoud gerenderd bij het exporteren van dia’s naar PDF/afbeeldingen?**

Wat zichtbaar is op de dia wordt gerenderd — het pictogram/substituut‑beeld (preview). De “live” OLE‑inhoud wordt niet uitgevoerd tijdens het renderen. Indien nodig, stel een eigen preview‑afbeelding in om de verwachte weergave in de geëxporteerde PDF te garanderen.

**Hoe kan ik een OLE‑object op een dia vergrendelen zodat gebruikers het niet kunnen verplaatsen/bewerken in PowerPoint?**

Vergrendel de vorm: Aspose.Slides biedt [shape-level locks](/slides/nl/cpp/applying-protection-to-presentation/). Dit is geen encryptie, maar voorkomt effectief onbedoelde bewerkingen en verplaatsingen.

**Waarom “springt” een gekoppeld Excel‑object of verandert van grootte wanneer ik de presentatie open?**

PowerPoint kan de preview van het gekoppelde OLE‑object verversen. Voor een stabiele weergave volgt u de richtlijnen van de [Working Solution for Worksheet Resizing](/slides/nl/cpp/working-solution-for-worksheet-resizing/) — ofwel het frame aanpassen aan het bereik, of het bereik schalen naar een vaste frame en een passend substituut‑beeld instellen.

**Worden relatieve paden voor gekoppelde OLE‑objecten behouden in het PPTX‑formaat?**

In PPTX is informatie over “relatief pad” niet beschikbaar — alleen het volledige pad. Relatieve paden komen voor in het oudere PPT‑formaat. Voor draagbaarheid geeft u de voorkeur aan betrouwbare absolute paden/toegankelijke URI's of aan insluiting.