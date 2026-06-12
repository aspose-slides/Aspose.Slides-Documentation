---
title: Grafiektabellen aanpassen in presentaties in .NET
linktitle: Datatabel
type: docs
url: /nl/net/chart-data-table/
keywords:
- grafiekgegevens
- datatabel
- lettertype-eigenschappen
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Pas grafiektabellen aan in .NET voor PPT en PPTX met Aspose.Slides om de efficiëntie en aantrekkelijkheid van presentaties te verhogen."
---
## **Overzicht**

Dit artikel legt uit hoe u met grafiektabellen in Aspose.Slides werkt. Het laat zien hoe u een datatabel voor een diagram weergeeft en de tekstopmaak aanpast door font‑eigenschappen zoals vette stijl en letterhoogte in te stellen. Het voorbeeld toont het laden van een presentatie, het toevoegen van een diagram, het inschakelen van de grafiektabel, het toepassen van font‑instellingen en het opslaan van de bijgewerkte presentatie.

Het bevat ook korte antwoorden op veelgestelde vragen over het weergeven van legenda‑sleutels in een grafiektabel, het behouden van de tabel tijdens export, werken met diagrammen die geladen zijn uit bestaande presentaties of sjablonen, en het identificeren van diagrammen waarbij de tabel is ingeschakeld.

## **Lettertype‑eigenschappen instellen voor een grafiektabel**
Aspose.Slides for .NET biedt ondersteuning voor het wijzigen van de kleur van categorieën in een serie‑kleur.  

1. Instantiseer een Presentation‑klasse‑object.
1. Voeg een diagram toe aan de dia.
1. Stel de grafiektabel in.
1. Stel de letterhoogte in.
1. Sla de gewijzigde presentatie op.

Hieronder staat een voorbeeld.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.HasDataTable = true;

	chart.ChartDataTable.TextFormat.PortionFormat.FontBold = NullableBool.True;
	chart.ChartDataTable.TextFormat.PortionFormat.FontHeight = 20;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Veelgestelde vragen**

**Kan ik kleine legenda‑sleutels naast de waarden in de grafiektabel weergeven?**

Ja. De tabel ondersteunt [legenda‑sleutels](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/datatable/showlegendkey/), en u kunt ze in- of uitschakelen.

**Wordt de tabel behouden bij het exporteren van de presentatie naar PDF, HTML of afbeeldingen?**

Ja. Aspose.Slides rendert het diagram als onderdeel van de dia, zodat de geëxporteerde [PDF](/slides/nl/net/convert-powerpoint-to-pdf/)/[HTML](/slides/nl/net/convert-powerpoint-to-html/)/[afbeelding](/slides/nl/net/convert-powerpoint-to-png/) het diagram met zijn tabel bevat.

**Worden tabellen ondersteund voor diagrammen die uit een sjabloonbestand komen?**

Ja. Voor elk diagram dat geladen is uit een bestaande presentatie of sjabloon, kunt u controleren en wijzigen of een datatabel [wordt weergegeven](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chart/hasdatatable/) is met behulp van de diagram‑eigenschappen.

**Hoe kan ik snel vinden welke diagrammen in een bestand de tabel hebben ingeschakeld?**

Inspecteer de eigenschap van elk diagram die aangeeft of de tabel [wordt weergegeven](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chart/hasdatatable/) is en doorloop de dia's om de diagrammen te identificeren waarvoor deze is ingeschakeld.