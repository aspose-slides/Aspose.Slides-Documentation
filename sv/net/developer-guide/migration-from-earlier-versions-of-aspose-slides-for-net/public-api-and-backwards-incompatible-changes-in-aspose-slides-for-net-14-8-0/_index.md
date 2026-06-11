---
title: Offentligt API och bakåtinkompatibla förändringar i Aspose.Slides för .NET 14.8.0
linktitle: Aspose.Slides för .NET 14.8.0
type: docs
weight: 100
url: /sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
keywords:
- migration
- gammal kod
- modern kod
- gammal metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Granska offentliga API‑uppdateringar och brytande förändringar i Aspose.Slides för .NET för att smidigt migrera dina PowerPoint PPT, PPTX och ODP‑presentationslösningar."
---
{{% alert color="primary" %}} 

Denna sida listar alla [tillagda](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) eller [borttagna](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) klasser, metoder, egenskaper med mera, samt andra ändringar som införts med Aspose.Slides för .NET 14.8.0 API.

{{% /alert %}} 
## **Offentliga API-ändringar**
### **Ändrade egenskaper**
#### **Lagt till IVbaProject-gränssnittet, ändrat Presentation.VbaProject-egenskapen**
Presentation-klassens VbaProject‑egenskap har ersatts. Istället för VbaProject‑egenskapens råa byte‑representation av ett VBA‑projekt har en ny implementation av IVbaProject‑gränssnittet lagts till.

Använd IVbaProject‑egenskapen för att hantera VBA‑projekt som är inbäddade i en presentation. Du kan lägga till nya projektreferenser, redigera befintliga moduler och skapa nya.

Du kan också skapa ett nytt VBA‑projekt med VbaProject‑klassen som implementerar IVbaProject‑gränssnittet.

Följande exempel visar hur man skapar ett enkelt VBA‑projekt som innehåller en modul och lägger till två nödvändiga referenser till biblioteken.

``` csharp

 using (Presentation pres = new Presentation())

{

    // Skapa nytt VBA‑projekt

    pres.VbaProject = new VbaProject();

    // Lägg till tom modul i VBA‑projektet

    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");

    // Ange modulens källkod

    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // Skapa referens till <stdole>

    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Skapa referens till Office

    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Lägg till referenser till VBA‑projektet

    pres.VbaProject.References.Add(stdoleReference);

    pres.VbaProject.References.Add(officeReference);

    pres.Save("test.pptm", SaveFormat.Pptm);

}
``` 

Detta exempel visar hur man kopierar ett VBA‑projekt från en befintlig presentation till en ny.

``` csharp

 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}

``` 
### **Tillagda gränssnitt, egenskaper och enumerationsalternativ**
#### **Tillagd Aspose.Slides.Charts.IChartSeries.Overlap-egenskap**
Aspose.Slides.Charts.IChartSeries.Overlap‑egenskapen anger hur mycket staplar och kolumner ska överlappa i 2D‑diagram (från -100 till 100).

Detta är egenskapen inte bara för denna serie utan för alla serier i den överordnade seriesgruppen – det är en projektion av den lämpliga grupp‑egenskapen. Därför är denna egenskap skrivskyddad.

- Använd ParentSeriesGroup‑egenskapen för att komma åt den överordnade seriesgruppen.
- Använd ParentSeriesGroup.Overlap läs/skriv‑egenskap för att ändra värdet.

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
#### **Tillagd Aspose.Slides.Charts.IChartSeriesGroup.Overlap-egenskap**
Aspose.Slides.Charts.IChartSeriesGroup.Overlap‑egenskapen anger hur mycket staplar och kolumner ska överlappa i 2D‑diagram (från -100 till 100).

``` csharp



using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}

``` 
#### **Tillagt ShapeThumbnailBounds.Appearance-enumvärde**
Denna metod för att skapa miniatyrbilder av former låter dig generera en form‑miniatyr inom dess utseendes gränser. Den tar hänsyn till alla formeffekter. Den genererade miniatyren begränsas av bildens gränser.

``` csharp



using (Presentation p = new Presentation("Presentation.pptx"))

{

    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

    st.Save("ShapeThumbnail.png", ImageFormat.Png);

}

```