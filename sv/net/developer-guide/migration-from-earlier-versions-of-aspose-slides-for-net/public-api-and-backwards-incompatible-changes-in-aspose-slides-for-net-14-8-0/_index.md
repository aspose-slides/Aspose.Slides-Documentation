---
title: Offentligt API och bakåtinkompatibla förändringar i Aspose.Slides för .NET 14.8.0
linktitle: Aspose.Slides för .NET 14.8.0
type: docs
weight: 100
url: /sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
keywords:
- migrering
- gammal kod
- modern kod
- gammalt tillvägagångssätt
- modernt tillvägagångssätt
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Granska offentliga API-uppdateringar och brytande förändringar i Aspose.Slides för .NET för att smidigt migrera dina PowerPoint PPT, PPTX och ODP presentationslösningar."
---
{{% alert color="info" %}} 

Den här sidan listar alla [tillagda](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) eller [borttagna](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) klasser, metoder, egenskaper osv., samt andra förändringar som införts med Aspose.Slides för .NET 14.8.0 API.

{{% /alert %}} 
## **Offentliga API-ändringar**
### **Ändrade egenskaper**
#### **Lade till IVbaProject-gränssnittet, ändrade Presentation.VbaProject-egenskapen**
Presentation-klassens VbaProject-egenskap har ersatts. Istället för VbaProject-egenskapens råa byte-representation av VBA-projekt har den nya IVbaProject-granssnittsimplementationen lagts till.

Använd IVbaProject-egenskapen för att hantera VBA-projekt som är inbäddade i en presentation. Du kan lägga till nya projektreferenser, redigera befintliga moduler och skapa nya.

Du kan också skapa ett nytt VBA-projekt med VbaProject-klassen som implementerar IVbaProject-granssnittet.

Följande exempel visar skapandet av ett enkelt VBA-projekt som innehåller en modul och lägger till två nödvändiga referenser till biblioteken.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;


 using (Presentation pres = new Presentation())
{
    // Skapa nytt VBA-projekt
    pres.VbaProject = new VbaProject();
    // Lägg till en tom modul i VBA-projektet
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
    // Lägg till referenser till VBA-projektet
    pres.VbaProject.References.Add(stdoleReference);
    pres.VbaProject.References.Add(officeReference);
    pres.Save("test.pptm", SaveFormat.Pptm);
}
``` 

Detta exempel visar hur man kopierar ett VBA-projekt från en befintlig presentation till en ny.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Vba;


 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())
{
    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());
}
``` 
### **Tillagda gränssnitt, egenskaper och uppräkningalternativ**
#### **Lade till Aspose.Slides.Charts.IChartSeries.Overlap-egenskapen**
Aspose.Slides.Charts.IChartSeries.Overlap-egenskapen anger hur mycket staplar och kolumner ska överlappa i 2D-diagram (från -100 till 100).

Detta är egenskapen inte bara för denna serie utan för alla serier i den överordnade seriegruppen - den är en projektion av den motsvarande gruppens egenskap. Därför är egenskapen skrivskyddad.

- Använd ParentSeriesGroup-egenskapen för att komma åt den överordnade seriegruppen.
- Använd ParentSeriesGroup.Overlap las-/skriv-egenskapen för att ändra värdet.

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
#### **Lade till Aspose.Slides.Charts.IChartSeriesGroup.Overlap-egenskapen**
Aspose.Slides.Charts.IChartSeriesGroup.Overlap-egenskapen anger hur mycket staplar och kolumner ska överlappa i 2D-diagram (från -100 till 100).

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
#### **Lade till ShapeThumbnailBounds.Appearance Enum-värdet**
Denna metod för skapande av form-miniatyrer låter dig generera en form-miniatyr inom dess utseendes gränser. Den tar hänsyn till alla formeffekter. Den genererade form-miniatyren begränsas av bildens gränser.

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