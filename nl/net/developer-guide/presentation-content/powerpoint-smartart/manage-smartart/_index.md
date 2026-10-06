---
title: Beheer SmartArt in PowerPoint-presentaties in .NET
linktitle: Beheer SmartArt
type: docs
weight: 10
url: /nl/net/manage-smartart/
keywords:
- SmartArt
- SmartArt-tekst
- lay-outtype
- verborgen eigenschap
- organigram
- afbeelding‑organigram
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer PowerPoint SmartArt te bouwen en bewerken met Aspose.Slides voor .NET met duidelijke C#-codevoorbeelden die het ontwerp en de automatisering van dia's versnellen."
---
## **Overzicht**

SmartArt is een PowerPoint-diagram dat bestaat uit knooppunten, knooppunt‑vormen en een layout. Met Aspose.Slides voor .NET kunt u SmartArt maken, tekst uit de knooppunten lezen, de layout wijzigen, verborgen knooppunten inspecteren, de layout van organigrammen configureren en afbeelding‑organigrammen maken.

## **Tekst ophalen uit een SmartArt-object**

Een SmartArt‑knooppunt kan één of meerdere vormen bevatten. Om tekst uit de knooppunt‑vormen te lezen, doorloop [ISmartArt.AllNodes](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/allnodes/), lees vervolgens het [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) dat wordt geretourneerd door [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartshape/textframe/).

Het voorbeeld vereist een presentatie met ten minste één dia en een SmartArt‑object als de eerste vorm op die dia. Het drukt elk beschikbaar tekstframe af naar de console.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt) slide.Shapes[0];
foreach (var node in smartArt.AllNodes)
{
    foreach (var nodeShape in node.Shapes)
    {
        if (nodeShape.TextFrame != null)
        {
            Console.WriteLine(nodeShape.TextFrame.Text);
        }
    }
}
```
## **Lay-outtype van een SmartArt-object wijzigen**

De SmartArt‑layout bepaalt hoe knooppunten worden gerangschikt en verbonden. Het volgende voorbeeld maakt een SmartArt‑object met de [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList`‑waarde, wijzigt deze naar de `BasicProcess`‑waarde en slaat de presentatie op. De positie en grootte die worden doorgegeven aan [IShapeCollection.AddSmartArt](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addsmartart/) worden gemeten in punten. Stel [ISmartArt.Layout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/layout/) in om de layout te wijzigen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
smartArt.Layout = SmartArtLayoutType.BasicProcess;

presentation.Save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
```
## **Controleren of een SmartArt‑knooppunt verborgen is**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/ishidden/) geeft aan of het knooppunt verborgen is in het SmartArt‑datamodel. Verborgen knooppunten kunnen bestaan in de structuur, zelfs wanneer de geselecteerde layout ze niet als zichtbare diagramonderdelen toont.

Het volgende voorbeeld voegt een knooppunt toe aan een SmartArt‑object dat de [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `RadialCycle`‑waarde gebruikt en controleert de verborgen status van het toegevoegde knooppunt. Het drukt een bericht af als het knooppunt verborgen is en slaat het diagram op.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
var node = smartArt.AllNodes.AddNode();
var isHidden = node.IsHidden;

if (isHidden)
{
    Console.WriteLine("The node is hidden in the SmartArt data model.");
}

presentation.Save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
```
## **Organigramlayout ophalen of instellen**

Voor SmartArt‑diagrammen die een organigram‑layout gebruiken, definieert [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) hoe kindknooppunten onder een ouderknooppunt worden gerangschikt. U kunt bijvoorbeeld kindknooppunten laten hangen aan de linker-, rechter- of beide zijden, afhankelijk van de geselecteerde [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/).

Het volgende voorbeeld maakt een organigram en stelt de layout voor het eerste knooppunt in op de [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging`‑waarde. De nul‑gebaseerde index `0` selecteert het eerste top‑level knooppunt; de kindknooppunten gebruiken de gekozen indeling. De gewijzigde presentatie wordt vervolgens opgeslagen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
var rootNode = smartArt.Nodes[0];
rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

presentation.Save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
```
## **Een afbeelding‑organigram maken**

Een afbeelding‑organigram is een SmartArt‑layout die is ontworpen voor hiërarchiediagrammen met afbeeldings‑plaatsaanduidingen. Gebruik de [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart`‑waarde bij het toevoegen van het SmartArt‑object aan een dia. Dit voorbeeld slaat een diagram op met afbeeldings‑plaatsaanduidingen; het vult de plaatsaanduidingen niet met afbeeldingen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

presentation.Save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
```
## **Legacy-diagrammen omzetten naar groepen vormen**

Bij het moderniseren van een bestaande presentatie moet u mogelijk een organigram bijwerken dat oorspronkelijk is gemaakt in PowerPoint 97–2003. Aspose.Slides vertegenwoordigt deze legacy‑diagrammen als [ILegacyDiagram](https://reference.aspose.com/slides/net/aspose.slides/ilegacydiagram/)‑objecten. Gebruik [LegacyDiagram.ConvertToGroupShape](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/converttogroupshape/) om een diagram om te zetten naar een groep vormen zodat u afzonderlijke visuele elementen kunt bewerken. Zie de [LegacyDiagram API Reference](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/) voor details.

Conversie voegt een nieuwe groep toe aan de vormcollectie zonder het originele diagram te verwijderen. Na een geslaagde conversie verwijdert u het origineel met [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) om dubbele inhoud te voorkomen. Verzamel de legacy‑diagrammen in een array voordat u ze converteert, zodat het toevoegen en verwijderen van vormen de iteratie niet verstoort.

Het volgende voorbeeld opent een presentatie, doorzoekt elke dia, zet de diagrammen om naar groepen vormen en slaat de bijgewerkte presentatie op als PPTX.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("legacy-diagrams.ppt");

foreach (var slide in presentation.Slides)
{
    var legacyDiagrams = slide.Shapes.OfType<ILegacyDiagram>().ToArray();
    foreach (var legacyDiagram in legacyDiagrams)
    {
        var groupShape = legacyDiagram.ConvertToGroupShape();

        if (groupShape != null)
        {
            slide.Shapes.Remove(legacyDiagram);
        }
    }
}

presentation.Save("modernized.pptx", SaveFormat.Pptx);
```

De opgeslagen presentatie bevat bewerkbare groepen vormen ter vervanging van de geconverteerde legacy‑diagrammen, zonder dat er originele diagrammen naast blijven staan. Open de PPTX in PowerPoint om individuele elementen binnen elke groep te bewerken, zoals de tekst, vulling of positie.

## **FAQ**

**Ondersteunt SmartArt spiegelen of omkeren voor RTL-talen?**

Ja. De [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/)‑eigenschap schakelt de diagramrichting van links‑naar‑rechts naar rechts‑naar‑links, of terug, wanneer de geselecteerde SmartArt‑layout omkering ondersteunt.

**Hoe kan ik SmartArt kopiëren naar dezelfde dia of naar een andere presentatie terwijl de opmaak behouden blijft?**

U kunt de [de SmartArt‑vorm klonen](/slides/nl/net/shape-manipulations/) met [ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/) of de hele dia [de hele dia klonen](/slides/nl/net/clone-slides/) die de SmartArt bevat. Beide methoden behouden grootte, positie en opmaak.

**Hoe render ik SmartArt naar een rasterafbeelding voor voorbeeld of webexport?**

[Render de dia](/slides/nl/net/convert-powerpoint-to-png/) of de hele presentatie naar PNG of JPEG. SmartArt wordt als onderdeel van de dia gerenderd.

**Hoe kan ik een specifiek SmartArt‑object vinden op een dia als er meerdere zijn?**

Stel een onderscheidende [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) of [Name](https://reference.aspose.com/slides/net/aspose.slides/shape/name/)‑waarde in op de SmartArt‑vorm, zoek die waarde in [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/), en controleer vervolgens of de overeenkomende vorm een [ISmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/) is.