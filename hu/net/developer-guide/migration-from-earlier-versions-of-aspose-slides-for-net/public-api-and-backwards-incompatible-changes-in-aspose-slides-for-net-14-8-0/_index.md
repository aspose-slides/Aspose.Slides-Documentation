---
title: "Nyilvános API és visszafelé nem kompatibilis változások az Aspose.Slides for .NET 14.8.0 verzióban"
linktitle: "Aspose.Slides for .NET 14.8.0"
type: docs
weight: 100
url: /hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
keywords:
- migráció
- régi kód
- modern kód
- régi megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Áttekintés a nyilvános API frissítéseiről és a breaking változásokról az Aspose.Slides for .NET-ben, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="info" %}} 

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) vagy [eltávolított](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) osztályt, metódust, tulajdonságot és így tovább, valamint az Aspose.Slides for .NET 14.8.0 API-val bevezetett egyéb változásokat.

{{% /alert %}} 
## **Nyilvános API változások**
### **Módosított tulajdonságok**
#### **Hozzáadott IVbaProject interfész, módosított Presentation.VbaProject tulajdonság**
A Presentation osztály VbaProject tulajdonságát lecserélték. A VbaProject tulajdonság nyers bájtábrázolása a VBA projektről helyett az új IVbaProject interfész megvalósítása lett hozzáadva.

Használd az IVbaProject tulajdonságot a prezentációba ágyazott VBA projektek kezelésére. Új projektreferenciákat adhat hozzá, meglévő modulokat szerkeszthet és újat hozhat létre.

Továbbá új VBA projektet hozhatsz létre a VbaProject osztály használatával, amely megvalósítja az IVbaProject interfészt.

A következő példa egy egyszerű VBA projekt létrehozását mutatja, amely egy modult tartalmaz, és két szükséges hivatkozást ad hozzá a könyvtárakhoz.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;


 using (Presentation pres = new Presentation())

{

    // Új VBA projekt létrehozása

    pres.VbaProject = new VbaProject();

    // Üres modul hozzáadása a VBA projekthez

    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");

    // Modul forráskód beállítása

    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // Hivatkozás létrehozása a <stdole>-ra

    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Hivatkozás létrehozása az Office-ra

    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Hivatkozások hozzáadása a VBA projekthez

    pres.VbaProject.References.Add(stdoleReference);

    pres.VbaProject.References.Add(officeReference);

    pres.Save("test.pptm", SaveFormat.Pptm);

}
``` 

Ez a példa azt mutatja, hogyan másolhatunk VBA projektet egy meglévő prezentációból egy újba.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Vba;


 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}

``` 
### **Hozzáadott interfészek, tulajdonságok és enumerációs opciók**
#### **Hozzáadott Aspose.Slides.Charts.IChartSeries.Overlap tulajdonság**
Az Aspose.Slides.Charts.IChartSeries.Overlap tulajdonság meghatározza, hogy a sávok és oszlopok mennyire fedjék egymást 2D diagramokon (tartomány: -100–100).

Ez a tulajdonság nem csak ezen sorozatra, hanem a szülő sorozatcsoport minden sorozatára vonatkozik – ez a megfelelő csoporttulajdonság projekciója. Így ez a tulajdonság csak olvasható.

- Használd a ParentSeriesGroup tulajdonságot a szülő sorozatcsoport eléréséhez.
- Használd a ParentSeriesGroup.Overlap írás/olvasás tulajdonságot az érték módosításához.

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
#### **Hozzáadott Aspose.Slides.Charts.IChartSeriesGroup.Overlap tulajdonság**
Az Aspose.Slides.Charts.IChartSeriesGroup.Overlap tulajdonság meghatározza, hogy a sávok és oszlopok mennyire fedjék egymást 2D diagramokon (tartomány: -100–100).

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
#### **Hozzáadott ShapeThumbnailBounds.Appearance enum érték**
Ez a forma bélyegkép létrehozási módszer lehetővé teszi, hogy a forma megjelenésének határain belül generálj egy bélyegképet. Figyelembe veszi az összes formaeffektet. A generált forma bélyegkép a dia határaival van korlátozva.

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