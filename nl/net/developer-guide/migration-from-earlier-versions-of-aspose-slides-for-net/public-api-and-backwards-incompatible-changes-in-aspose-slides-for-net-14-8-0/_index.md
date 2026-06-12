---
title: Publieke API en terugwaartse incompatibele wijzigingen in Aspose.Slides voor .NET 14.8.0
linktitle: Aspose.Slides voor .NET 14.8.0
type: docs
weight: 100
url: /nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
keywords:
- migratie
- oude code
- moderne code
- oude aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Bekijk de updates van de publieke API en brekende wijzigingen in Aspose.Slides voor .NET om soepel uw PowerPoint PPT, PPTX en ODP presentatiesoplossingen te migreren."
---
{{% alert color="primary" %}} 

Deze pagina vermeldt alle [added](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) of [removed](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) klassen, methoden, eigenschappen enzovoort, en andere wijzigingen die zijn geïntroduceerd met de Aspose.Slides for .NET 14.8.0 API.

{{% /alert %}} 
## **Public API Changes**
### **Changed Properties**
#### **Added the IVbaProject Interface, Changed the Presentation.VbaProject Property**
De VbaProject‑eigenschap van de Presentation‑klasse is vervangen. In plaats van h3. Toegevoegde interfaces, eigenschappen en enumeratiewaarden is de ruwe byte‑representatie van het VBA‑project van de VbaProject‑eigenschap vervangen door een implementatie van de nieuwe IVbaProject‑interface.

Gebruik de IVbaProject‑eigenschap om VBA‑projecten die in een presentatie zijn ingebed te beheren. Je kunt nieuwe projectreferenties toevoegen, bestaande modules bewerken en nieuwe maken.

Je kunt ook een nieuw VBA‑project aanmaken met de VbaProject‑klasse die de IVbaProject‑interface implementeert.

Het volgende voorbeeld toont het aanmaken van een eenvoudig VBA‑project met één module en het toevoegen van twee vereiste referenties naar de bibliotheken.

``` csharp

 using (Presentation pres = new Presentation())

{

    // Maak nieuw VBA-project
    pres.VbaProject = new VbaProject();

    // Voeg leeg module toe aan het VBA-project
    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");

    // Stel broncode van module in
    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // Maak referentie naar <stdole>
    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Maak referentie naar Office
    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Voeg referenties toe aan het VBA-project
    pres.VbaProject.References.Add(stdoleReference);

    pres.VbaProject.References.Add(officeReference);

    pres.Save("test.pptm", SaveFormat.Pptm);

}
``` 

Dit voorbeeld laat zien hoe je een VBA‑project van een bestaande presentatie naar een nieuwe kopieert.

``` csharp

 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}

``` 
### **Added Interfaces, Properties and Enumeration Options**
#### **Added the Aspose.Slides.Charts.IChartSeries.Overlap Property**
De Aspose.Slides.Charts.IChartSeries.Overlap‑eigenschap geeft aan hoeveel staaf‑ en kolomdiagrammen op 2D‑grafieken overlappen (variërend van -100 tot 100).

Dit is niet alleen de eigenschap van deze reeks, maar van alle reeksen in de bovenliggende reeksgroep – het is een projectie van de bijbehorende groepeigenschap. Daarom is deze eigenschap alleen‑lezen.

- Gebruik de ParentSeriesGroup‑eigenschap om toegang te krijgen tot de bovenliggende reeksgroep.
- Gebruik de ParentSeriesGroup.Overlap‑eigenschap (lezen/schrijven) om de waarde te wijzigen.

``` csharp

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
#### **Added the Aspose.Slides.Charts.IChartSeriesGroup.Overlap Property**
De Aspose.Slides.Charts.IChartSeriesGroup.Overlap‑eigenschap geeft aan hoeveel staaf‑ en kolomdiagrammen moeten overlappen op 2D‑grafieken (van -100 tot 100).

``` csharp



using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}

``` 
#### **Added the ShapeThumbnailBounds.Appearance Enum Value**
Deze methode voor het maken van een miniatuur van een vorm stelt je in staat een miniatuur te genereren binnen de grenzen van de weergave van de vorm. Hierbij worden alle vormeffecten meegenomen. De gegenereerde vormminiatuur wordt beperkt door de grenzen van de dia.

``` csharp



using (Presentation p = new Presentation("Presentation.pptx"))

{

    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

    st.Save("ShapeThumbnail.png", ImageFormat.Png);

}
```