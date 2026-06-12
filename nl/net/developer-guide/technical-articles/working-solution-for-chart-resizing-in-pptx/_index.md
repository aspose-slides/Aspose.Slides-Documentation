---
title: Werkende oplossing voor het herschalen van grafieken in PPTX
type: docs
weight: 60
url: /nl/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- grafiek herschalen
- Excel-grafiek
- OLE-object
- grafiek insluiten
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Los onverwacht herschalen van grafieken in PPTX op bij gebruik van ingebedde Excel OLE-objecten met Aspose.Slides voor .NET. Leer twee methoden met code om de afmetingen consistent te houden."
---
## **Achtergrond**

Er is geconstateerd dat Excel‑grafieken die als OLE‑objecten in een PowerPoint‑presentatie via Aspose‑componenten zijn ingebed, na hun eerste activatie naar een onbepaalde schaal worden herschaald. Dit gedrag veroorzaakt een duidelijk visueel verschil in de presentatie tussen de staat vóór en ná de activatie van de grafiek. Het Aspose‑team heeft het probleem grondig onderzocht en een oplossing gevonden. Dit artikel beschrijft de oorzaken van het probleem en de bijbehorende oplossing.

In het[vorige artikel](/slides/nl/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) hebben we uitgelegd hoe je een Excel‑grafiek maakt met Aspose.Cells voor .NET en deze in een PowerPoint‑presentatie verwerkt met Aspose.Slides voor .NET. Om het[objectvoorvertoningsprobleem](/slides/nl/net/object-preview-issue-when-adding-oleobjectframe/) op te lossen, hebben we de grafiekafbeelding toegewezen aan het OLE‑objectframe van de grafiek. In de geproduceerde presentatie wordt, wanneer je dubbelklikt op het OLE‑objectframe dat de grafiekafbeelding toont, de Excel‑grafiek geactiveerd. Eindgebruikers kunnen gewenste wijzigingen aanbrengen in de onderliggende Excel‑werkmap en vervolgens terugkeren naar de bijbehorende dia door buiten de geactiveerde werkmap te klikken. De grootte van het OLE‑objectframe verandert wanneer de gebruiker terugkeert naar de dia, en de herschaalfactor varieert afhankelijk van de oorspronkelijke afmetingen van zowel het OLE‑objectframe als de ingebedde Excel‑werkmap.

## **Oorzaak van het herschalen**

Omdat de Excel‑werkmap een eigen venstergrootte heeft, probeert deze bij de eerste activatie zijn oorspronkelijke grootte te behouden. Het OLE‑objectframe heeft echter zijn eigen afmetingen. Volgens Microsoft onderhandelen Excel en PowerPoint bij activatie van de werkmap over de grootte en behouden ze de juiste verhoudingen als onderdeel van het insluitingsproces. Afhankelijk van de verschillen tussen de grootte van het Excel‑venster en de grootte of positie van het OLE‑objectframe, vindt het herschalen plaats.

## **Werkende oplossing**

Er zijn twee mogelijke scenario’s voor het maken van PowerPoint‑presentaties met Aspose.Slides voor .NET.

**Scenario 1:** Een presentatie maken op basis van een bestaand sjabloon.

**Scenario 2:** Een presentatie vanaf nul maken.

De oplossing die we hier bieden, is toepasbaar op beide scenario’s. De basis van alle oplossingsmethoden is dezelfde: **de venstergrootte van het ingebedde OLE‑object moet overeenkomen met het OLE‑objectframe in de PowerPoint‑dia**. We bespreken nu de twee benaderingen van deze oplossing.

## **Eerste benadering**

In deze benadering leren we hoe we de venstergrootte van de ingebedde Excel‑werkmap kunnen instellen zodat deze overeenkomt met de grootte van het OLE‑objectframe in de PowerPoint‑dia.

**Scenario 1**

Stel dat we een sjabloon hebben gedefinieerd en presentaties op basis daarvan willen maken. Neem aan dat er een vorm op index 2 in het sjabloon staat waar we een OLE‑frame met een ingebedde Excel‑werkmap willen plaatsen. In dit scenario is de grootte van het OLE‑objectframe vooraf gedefinieerd — deze komt overeen met de grootte van de vorm op index 2 in het sjabloon. Het enige wat we hoeven te doen is de venstergrootte van de werkmap gelijk te maken aan die vormgrootte. Het volgende codefragment dient dit doel:

```cs
// Definieer de grafiekgrootte met een venster. 
chart.SizeWithWindow = true;

// Stel de breedte van het werkmapvenster in inches in (gedeeld door 72 aangezien PowerPoint 72 pixels per inch gebruikt).
workbook.Worksheets.WindowWidthInch = slide.Shapes[2].Width / 72f;

// Stel de hoogte van het werkmapvenster in inches in.
workbook.Worksheets.WindowHeightInch = slide.Shapes[2].Height / 72f;

// Sla de werkmap op naar een geheugenstroom.
MemoryStream workbookStream = workbook.SaveToStream();

// Maak een OLE-objectframe met de ingebedde Excel-gegevens.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

**Scenario 2**

Stel dat we een presentatie vanaf nul willen maken en een OLE‑objectframe van willekeurige grootte met een ingebedde Excel‑werkmap willen opnemen. In het onderstaande codefragment maken we een OLE‑objectframe van 4 inch hoog en 9,5 inch breed op x = 0,5 inch en y = 1 inch op de dia. Vervolgens stellen we het Excel‑werkmapvenster in op dezelfde afmetingen — 4 inch hoog en 9,5 inch breed.

```cs
// Onze gewenste hoogte.
int desiredHeight = 288; // 4 inch (4 * 72)

// Onze gewenste breedte.
int desiredWidth = 684;//9.5 inch (9.5 * 72)

// Definieer de grafiekgrootte met een venster.
chart.SizeWithWindow = true;

// Stel de breedte van het werkmapvenster in inches in.
workbook.Worksheets.WindowWidthInch = desiredWidth / 72f;

// Stel de hoogte van het werkmapvenster in inches in.
workbook.Worksheets.WindowHeightInch = desiredHeight / 72f;

// Sla de werkmap op naar een geheugenstroom.
MemoryStream workbookStream = workbook.SaveToStream();

// Maak een OLE-objectframe met de ingebedde Excel-gegevens.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

## **Tweede benadering**

In deze benadering leren we hoe we de grootte van de grafiek in de ingebedde Excel‑werkmap kunnen instellen zodat deze overeenkomt met de grootte van het OLE‑objectframe in de PowerPoint‑dia. Deze benadering is nuttig wanneer de grafiekgrootte van tevoren bekend is en nooit zal veranderen.

**Scenario 1**

Stel dat we een sjabloon hebben gedefinieerd en presentaties op basis daarvan willen maken. Neem aan dat er een vorm op index 2 in het sjabloon staat waar we een OLE‑frame met een ingebedde Excel‑werkmap willen plaatsen. In dit scenario is de grootte van het OLE‑frame vooraf gedefinieerd — deze komt overeen met de grootte van de vorm op index 2 in het sjabloon. Het enige wat we hoeven te doen is de grafiekgrootte in de werkmap gelijk te maken aan de vormgrootte. Het volgende codefragment dient dit doel:

```cs
// Definieer de grafiekgrootte zonder venster.
chart.SizeWithWindow = false;

// Stel de breedte van de grafiek in pixels in (vermenigvuldig met 96 aangezien Excel 96 pixels per inch gebruikt).    
chart.ChartObject.Width = (int)((slide.Shapes[2].Width / 72f) * 96f);

// Stel de hoogte van de grafiek in pixels in.
chart.ChartObject.Height = (int)((slide.Shapes[2].Height / 72f) * 96f);

// Definieer de afdrukgrootte van de grafiek.
chart.PrintSize = PrintSizeType.Custom;

// Sla de werkmap op naar een geheugenstroom.
MemoryStream workbookStream = workbook.SaveToStream();

// Maak een OLE-objectframe met de ingebedde Excel-gegevens.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

**Scenario 2**

Stel dat we een presentatie vanaf nul willen maken en een OLE‑objectframe van willekeurige grootte met een ingebedde Excel‑werkmap willen opnemen. In het onderstaande codefragment maken we een OLE‑objectframe met een hoogte van 4 inch en een breedte van 9,5 inch op de dia op x = 0,5 inch en y = 1 inch. Daarnaast stellen we de overeenkomstige grafiekgrootte in op dezelfde afmetingen: een hoogte van 4 inch en een breedte van 9,5 inch.

```cs
 // Onze gewenste hoogte.
int desiredHeight = 288; // 4 inch (4 * 576)

// Onze gewenste breedte.
int desiredWidth = 684; // 9.5 inch (9.5 * 576)

// Definieer de grafiekgrootte zonder venster. 
chart.SizeWithWindow = false;

// Stel de breedte van de grafiek in pixels in.   
chart.ChartObject.Width = (int)((desiredWidth / 72f) * 96f);

// Stel de hoogte van de grafiek in pixels in.    
chart.ChartObject.Height = (int)((desiredHeight / 72f) * 96f);

// Sla de werkmap op naar een geheugenstroom.
MemoryStream workbookStream = workbook.SaveToStream();

// Maak een OLE-objectframe met de ingebedde Excel-gegevens.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

## **Conclusie**

Er zijn twee benaderingen om het probleem van het herschalen van de grafiek op te lossen. De keuze van benadering hangt af van de eisen en het gebruiksscenario. Beide benaderingen werken op dezelfde manier, ongeacht of de presentaties van een sjabloon of van nul worden gemaakt. Bovendien is er geen limiet aan de grootte van het OLE‑objectframe in deze oplossing.

## **FAQ**

**Waarom verandert de grootte van mijn ingebedde Excel‑grafiek na activatie in PowerPoint?**  
Dit gebeurt omdat Excel bij de eerste activatie probeert de oorspronkelijke venstergrootte te herstellen, terwijl het OLE‑objectframe in PowerPoint zijn eigen afmetingen heeft. PowerPoint en Excel onderhandelen over de grootte om de beeldverhouding te behouden, wat kan leiden tot herschaling.

**Is het mogelijk om dit herschalingsprobleem volledig te voorkomen?**  
Ja. Door de venstergrootte van de Excel‑werkmap of de grafiekgrootte af te stemmen op de grootte van het OLE‑objectframe vóór het insluiten, kun je de grafiekgroottes consistent houden.

**Welke benadering moet ik kiezen, venstergrootte van de werkmap of grafiekgrootte?**  
Gebruik **Benadering 1 (venstergrootte)** als je de beeldverhouding van de werkmap wilt behouden en eventueel later wilt kunnen schalen.  
Gebruik **Benadering 2 (grafiekgrootte)** als de grafiekafmetingen vaststaan en niet zullen veranderen na het insluiten.

**Werken deze methoden zowel voor sjabloongebaseerde presentaties als voor nieuwe presentaties?**  
Ja. Beide benaderingen werken op dezelfde manier voor presentaties die van sjablonen of vanaf nul zijn gemaakt.

**Is er een limiet aan de grootte van het OLE‑objectframe?**  
Nee. Je kunt het OLE‑frame op elke gewenste grootte instellen, zolang het passend wordt geschaald naar de werkmap of grafiek.

**Kan ik deze methoden gebruiken met grafieken die zijn gemaakt in andere spreadsheet‑programma’s?**  
De voorbeelden zijn ontworpen voor Excel‑grafieken gemaakt met Aspose.Cells, maar de principes gelden ook voor andere OLE‑compatibele spreadsheet‑programma’s, mits zij vergelijkbare dimensioneringsopties ondersteunen.

## **Gerelateerde secties**

- [Excel‑grafieken maken en insluiten als OLE‑objecten in presentaties](/slides/nl/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [OLE‑objecten automatisch bijwerken met een PowerPoint‑add‑in](/slides/nl/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)