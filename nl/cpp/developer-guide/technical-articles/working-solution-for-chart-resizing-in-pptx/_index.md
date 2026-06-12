---
title: Werkende oplossing voor grafiekverkleining in PPTX
type: docs
weight: 60
url: /nl/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- grafiekverkleining
- Excel-grafiek
- OLE-object
- grafiek insluiten
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Los onverwachte grafiekverkleining in PPTX op bij het gebruik van ingebedde Excel OLE-objecten met Aspose.Slides voor C++. Leer twee methoden met code om de afmetingen consistent te houden."
---
## **Achtergrond**

Er is geconstateerd dat Excel‑grafieken die als OLE‑objecten in een PowerPoint‑presentatie zijn ingebed via Aspose‑componenten, na hun eerste activering worden geschaald naar een onbepaalde grootte. Dit gedrag leidt tot een duidelijk visueel verschil tussen de voor‑ en na‑activeringsstatus van de grafiek in de presentatie. Het Aspose‑team heeft het probleem grondig onderzocht en een oplossing gevonden. Dit artikel beschrijft de oorzaken van het probleem en de bijbehorende correctie.

In het [vorig artikel](/slides/nl/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) legden we uit hoe je met Aspose.Cells voor C++ een Excel‑grafiek maakt en deze via Aspose.Slides voor C++ in een PowerPoint‑presentatie embedt. Om het [object‑preview‑probleem](/slides/nl/cpp/object-preview-issue-when-adding-oleobjectframe/) te verhelpen, hebben we de grafiekafbeelding toegewezen aan het OLE‑objectframe van de grafiek. In de gegenereerde presentatie wordt, wanneer je dubbelklikt op het OLE‑objectframe dat de grafiekafbeelding weergeeft, de Excel‑grafiek geactiveerd. Eindgebruikers kunnen dan gewenste wijzigingen aanbrengen in de onderliggende Excel‑werkmap en daarna terugkeren naar de betreffende dia door buiten de geactiveerde werkmap te klikken. De grootte van het OLE‑objectframe verandert wanneer de gebruiker terugkeert naar de dia, en de schaalfactor varieert afhankelijk van de oorspronkelijke afmetingen van zowel het OLE‑objectframe als de ingebedde Excel‑werkmap.

## **Oorzaak van de schaalverandering**

Omdat de Excel‑werkmap haar eigen venstergrootte heeft, probeert zij bij de eerste activering haar oorspronkelijke grootte te behouden. Het OLE‑objectframe heeft echter een eigen afmeting. Volgens Microsoft onderhandelen Excel en PowerPoint, zodra de werkmap wordt geactiveerd, over de grootte en behouden ze de juiste verhoudingen als onderdeel van het embed‑proces. Afhankelijk van de verschillen tussen de Excel‑venstergrootte en de grootte of positie van het OLE‑objectframe treedt er een schaalverandering op.

## **Werkende oplossing**

Er zijn twee mogelijke scenario's voor het maken van PowerPoint‑presentaties met Aspose.Slides voor C++.

**Scenario 1:** Een presentatie maken op basis van een bestaande sjabloon.

**Scenario 2:** Een presentatie vanaf nul maken.

De oplossing die we hier bieden, is van toepassing op beide scenario's. De basis van alle oplossingsrichtingen is hetzelfde: **de venstergrootte van het ingebedde OLE‑object moet overeenkomen met het OLE‑objectframe in de PowerPoint‑dia**. We bespreken nu de twee benaderingen van deze oplossing.

## **Eerste benadering**

In deze benadering leren we hoe we de venstergrootte van de ingebedde Excel‑werkmap kunnen instellen zodat deze overeenkomt met de afmeting van het OLE‑objectframe in de PowerPoint‑dia.

**Scenario 1**  

Stel dat we een sjabloon hebben gedefinieerd en presentaties willen maken op basis daarvan. Veronderstel dat er in het sjabloon een vorm op index 2 staat waarin we een OLE‑frame met een ingebedde Excel‑werkmap willen plaatsen. In dit scenario is de grootte van het OLE‑objectframe vooraf bepaald — ze komt overeen met de grootte van de vorm op index 2 in het sjabloon. Het enige wat we hoeven te doen is de venstergrootte van de werkmap gelijkstellen aan die vormgrootte. De volgende code‑fragmenten dienen dit doel:

```cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    auto outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

```cpp
// Definieer de grootte van de grafiek met een venster.
chart->SetSizeWithWindow(true);

auto shape = slide->get_Shape(2);

// Stel de vensterbreedte van de werkmap in inches in (gedeeld door 72 omdat PowerPoint 72 pixels per inch gebruikt).
workbook->GetISettings()->SetWindowWidthInch(shape->get_Width() / 72.f);

// Stel de vensterhoogte van de werkmap in inches in.
workbook->GetISettings()->SetWindowHeightInch(shape->get_Height() / 72.f);

// Sla de werkmap op naar een geheugenstroom.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream3(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Maak een OLE objectframe met de ingebedde Excel gegevens.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(), 
    shape->get_Height(),
    dataInfo);
```

**Scenario 2**  

Stel dat we een presentatie vanaf nul willen maken en een OLE‑objectframe van willekeurige grootte met een ingebedde Excel‑werkmap willen opnemen. In het onderstaande code‑fragment maken we een OLE‑objectframe van 4 inch hoog en 9,5 inch breed op x = 0,5 inch en y = 1 inch op de dia. Vervolgens stellen we het Excel‑werkmapvenster in op dezelfde afmetingen — 4 inch hoog en 9,5 inch breed.

```cpp
// Onze gewenste hoogte.
int32_t desiredHeight = 288; // 4 inch (4 * 72)

// Onze gewenste breedte.
int32_t desiredWidth = 684; // 9.5 inch (9.5 * 72)

// Definieer de grootte van de grafiek met een venster. 
chart->SetSizeWithWindow(true);

// Stel de vensterbreedte van de werkmap in inches in.
workbook->GetISettings()->SetWindowWidthInch(desiredWidth / 72.f);

// Stel de vensterhoogte van de werkmap in inches in.
workbook->GetISettings()->SetWindowHeightInch(desiredHeight / 72.f);

// Sla de werkmap op naar een geheugenstroom.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Maak een OLE objectframe met de ingebedde Excel‑gegevens.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f,
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```

## **Tweede benadering**

In deze benadering leren we hoe we de grootte van de grafiek in de ingebedde Excel‑werkmap kunnen instellen zodat deze overeenkomt met de afmeting van het OLE‑objectframe in de PowerPoint‑dia. Deze aanpak is handig wanneer de grafiekgrootte van tevoren bekend is en nooit zal veranderen.

**Scenario 1**  

Stel dat we een sjabloon hebben gedefinieerd en presentaties willen maken op basis daarvan. Veronderstel dat er in het sjabloon een vorm op index 2 staat waarin we een OLE‑frame met een ingebedde Excel‑werkmap willen plaatsen. In dit scenario is de grootte van het OLE‑frame vooraf bepaald — gelijk aan de grootte van de vorm op index 2 in het sjabloon. Het enige wat we hoeven te doen is de grafiekgrootte in de werkmap gelijkstellen aan die vormgrootte. Het volgende code‑fragment dient dit doel:

```cpp
// Definieer de grootte van de grafiek zonder venster. 
chart->SetSizeWithWindow(false);

auto shape = slide->get_Shape(2);

// Stel de breedte van de grafiek in pixels in (vermenigvuldig met 96 omdat Excel 96 pixels per inch gebruikt).    
chart->GetIChartObject()->SetWidth((int32_t)(shape->get_Width() / 72.f * 96.f));

// Stel de hoogte van de grafiek in pixels in.
chart->GetIChartObject()->SetHeight((int32_t)(shape->get_Height() / 72.f) * 96.f);

// Definieer de afdrukgrootte van de grafiek.
chart->SetPrintSize(Aspose::Cells::PrintSizeType::PrintSizeType_Custom);

// Sla de werkmap op naar een geheugenstroom.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Maak een OLE objectframe met de ingebedde Excel gegevens.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(),
    shape->get_Height(),
    dataInfo);
```

**Scenario 2**  

Stel dat we een presentatie vanaf nul willen maken en een OLE‑objectframe van willekeurige grootte met een ingebedde Excel‑werkmap willen opnemen. In het onderstaande code‑fragment maken we een OLE‑objectframe met een hoogte van 4 inch en een breedte van 9,5 inch op x = 0,5 inch en y = 1 inch op de dia. We stellen ook de bijbehorende grafiekgrootte in op dezelfde afmetingen: een hoogte van 4 inch en een breedte van 9,5 inch.

```cpp
// Onze gewenste hoogte.
int32_t desiredHeight = 288; // 4 inch (4 * 576)

// Onze gewenste breedte.
int32_t desiredWidth = 684; // 9.5 inch (9.5 * 576)

// Definieer de grootte van de grafiek zonder venster. 
chart->SetSizeWithWindow(false);

// Stel de breedte van de grafiek in pixels in.    
chart->GetIChartObject()->SetWidth((int32_t)((desiredWidth / 72.f) * 96.f));

// Stel de hoogte van de grafiek in pixels in.
chart->GetIChartObject()->SetHeight((int32_t)((desiredHeight / 72.f) * 96.f));

// Sla de werkmap op naar een geheugenstroom.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Maak een OLE objectframe met de ingebedde Excel‑gegevens.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f, 
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```

## **Conclusie**

Er bestaan twee benaderingen om het probleem met het schalen van grafieken op te lossen. De keuze voor een benadering hangt af van de eisen en het gebruiksscenario. Beide benaderingen werken op dezelfde manier, of de presentaties nu uit een sjabloon worden gegenereerd of vanaf nul worden opgebouwd. Bovendien is er geen limiet aan de grootte van het OLE‑objectframe in deze oplossing.

## **FAQ**

**Waarom verandert de grootte van mijn ingebedde Excel‑grafiek nadat deze in PowerPoint is geactiveerd?**

Dit gebeurt omdat Excel bij de eerste activering probeert de oorspronkelijke venstergrootte te herstellen, terwijl het OLE‑objectframe in PowerPoint eigen afmetingen heeft. PowerPoint en Excel onderhandelen over de grootte om de beeldverhouding te behouden, waardoor de schaalverandering kan optreden.

**Is het mogelijk dit schaalprobleem volledig te voorkomen?**

Ja. Door de venstergrootte van de Excel‑werkmap of de grafiekgrootte af te stemmen op de afmetingen van het OLE‑objectframe vóór het embedden, kun je consistente grafiekgroottes behouden.

**Welke benadering moet ik kiezen, venstergrootte instellen of grafiekgrootte instellen?**

Gebruik **Benadering 1 (venstergrootte)** als je de aspect‑ratio van de werkmap wilt behouden en eventueel later wilt kunnen schalen.  
Gebruik **Benadering 2 (grafiekgrootte)** als de grafiekafmetingen vaststaan en niet zullen veranderen na het embedden.

**Werken deze methoden zowel voor sjabloongebaseerde presentaties als voor nieuwe presentaties?**

Ja. Beide benaderingen werken op dezelfde manier voor presentaties die uit sjablonen worden gemaakt en voor presentaties die vanaf nul worden opgebouwd.

**Is er een limiet aan de grootte van het OLE‑objectframe?**

Nee. Je kunt het OLE‑frame op elke gewenste grootte instellen, zolang het passend wordt geschaald naar de werkmap‑ of grafiekgrootte.

**Kan ik deze methoden gebruiken met grafieken die zijn gemaakt in andere spreadsheet‑programma’s?**

De voorbeelden zijn bedoeld voor Excel‑grafieken die zijn gecreëerd met Aspose.Cells, maar de principes zijn ook toepasbaar op andere OLE‑compatibele spreadsheet‑programma’s, mits zij vergelijkbare opties voor grootte‑instelling ondersteunen.

## **Gerelateerde secties**

- [Maak Excel‑grafieken en embed ze als OLE‑objecten in presentaties](/slides/nl/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)