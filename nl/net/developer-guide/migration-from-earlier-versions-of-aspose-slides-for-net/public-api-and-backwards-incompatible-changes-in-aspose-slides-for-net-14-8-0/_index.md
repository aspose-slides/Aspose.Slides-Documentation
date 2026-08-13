---
title: Openbare API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor .NET 14.8.0
linktitle: Aspose.Slides voor .NET 14.8.0
type: docs
weight: 100
url: /nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
keywords:
- migratie
- legacy‑code
- moderne code
- legacy‑aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Bekijk de openbare API‑updates en breaking changes in Aspose.Slides voor .NET om uw PowerPoint‑PPT, PPTX‑ en ODP‑presentatie‑oplossingen soepel te migreren."
---
{{% alert color="info" %}} 

Deze pagina geeft een overzicht van alle [toegevoegde](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) of [verwijderde](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) klassen, methoden, eigenschappen enzovoort, en andere wijzigingen die geïntroduceerd zijn met de Aspose.Slides for .NET 14.8.0 API.

{{% /alert %}} 
## **Openbare API-wijzigingen**
### **Gewijzigde eigenschappen**
#### **Toegevoegde IVbaProject-interface, Gewijzigde Presentation.VbaProject‑eigenschap**
De VbaProject‑eigenschap van de Presentation‑klasse is vervangen. In plaats van h3. Toegevoegde interfaces, eigenschappen en enumeratie‑opties de ruwe byte‑representatie van het VBA‑project, is de nieuwe IVbaProject‑interface‑implementatie toegevoegd.

Gebruik de IVbaProject‑eigenschap om VBA‑projecten die in een presentatie zijn ingebed te beheren. U kunt nieuwe projectreferenties toevoegen, bestaande modules bewerken en nieuwe aanmaken.

U kunt ook een nieuw VBA‑project aanmaken met de VbaProject‑klasse die de IVbaProject‑interface implementeert.

Het volgende voorbeeld toont de creatie van een eenvoudig VBA‑project met één module en het toevoegen van twee vereiste referenties aan de bibliotheken.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;


 using (Presentation pres = new Presentation())

{

    // Maak een nieuw VBA-project aan
    pres.VbaProject = new VbaProject();
    // Voeg een lege module toe aan het VBA-project
    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");
    // Stel de broncode van de module in
    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // Maak referentie naar <stdole> aan
    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Maak referentie naar Office aan
    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Voeg referenties toe aan het VBA-project
    pres.VbaProject.References.Add(stdoleReference);
    pres.VbaProject.References.Add(officeReference);
    pres.Save("test.pptm", SaveFormat.Pptm);

}
``` 

Dit voorbeeld laat zien hoe u een VBA‑project van een bestaande presentatie naar een nieuwe kopieert.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Vba;


 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}
``` 
### **Toegevoegde interfaces, eigenschappen en enumeratie‑opties**
#### **Toegevoegde Aspose.Slides.Charts.IChartSeries.Overlap‑eigenschap**
De Aspose.Slides.Charts.IChartSeries.Overlap‑eigenschap geeft aan hoeveel balken en kolommen elkaar overlappen op 2D‑diagrammen (variërend van -100 tot 100).

Dit is niet alleen de eigenschap van deze serie, maar van alle series in de bovenliggende seriesgroep – het is een projectie van de overeenkomstige groepseigenschap. Daarom is deze eigenschap alleen-lezen.

- Gebruik de ParentSeriesGroup‑eigenschap om toegang te krijgen tot de bovenliggende seriesgroep.
- Gebruik de ParentSeriesGroup.Overlap‑eigenschap (lezen/schrijven) om de waarde te wijzigen.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;


 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   if (series[0].Overlap == 0)

      {

            series[0].ParentSeriesGroup.Overlap = -30;

      }

}
``` 
#### **Toegevoegde Aspose.Slides.Charts.IChartSeriesGroup.Overlap‑eigenschap**
De Aspose.Slides.Charts.IChartSeriesGroup.Overlap‑eigenschap geeft aan hoeveel balken en kolommen elkaar moeten overlappen op 2D‑diagrammen (van -100 tot 100).

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;




using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}
``` 
#### **Toegevoegde ShapeThumbnailBounds.Appearance‑enumwaarde**
Deze methode voor het maken van een vorm‑thumbnail stelt u in staat om een thumbnail van een vorm te genereren binnen de grenzen van zijn weergave. Hierbij worden alle vorm‑effecten meegenomen. De gegenereerde vorm‑thumbnail wordt begrensd door de slide‑grenzen.

``` csharp
using Aspose.Slides;

using (Presentation p = new Presentation("Presentation.pptx"))
{
    using (IImage image = p.Slides[0].Shapes[0].GetImage(ShapeThumbnailBounds.Appearance, 1, 1))
    {
        image.Save("ShapeThumbnail.png", ImageFormat.Png);
    }
}
```