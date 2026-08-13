---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro .NET 14.8.0
linktitle: Aspose.Slides pro .NET 14.8.0
type: docs
weight: 100
url: /cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
keywords:
- migrace
- starý kód
- moderní kód
- starý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Prohlédněte si aktualizace veřejného API a breaking changes v Aspose.Slides pro .NET a snadno migrujte své řešení pro PowerPoint PPT, PPTX a ODP prezentace."
---
{{% alert color="info" %}} 

Tato stránka uvádí všechny [added](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) nebo [removed](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) třídy, metody, vlastnosti a podobně a další změny zavedené v rozhraní Aspose.Slides for .NET 14.8.0 API.

{{% /alert %}} 
## **Public API Changes**
### **Changed Properties**
#### **Added the IVbaProject Interface, Changed the Presentation.VbaProject Property**
Vlastnost VbaProject třídy Presentation byla nahrazena. Místo surové bajtové reprezentace VBA projektu byla přidána nová implementace rozhraní IVbaProject.

Použijte vlastnost IVbaProject k řízení VBA projektů vložených do prezentace. Můžete přidávat nové odkazy na projekty, upravovat existující moduly a vytvářet nové.

Také můžete vytvořit nový VBA projekt pomocí třídy VbaProject, která implementuje rozhraní IVbaProject.

Níže uvedený příklad ukazuje vytvoření jednoduchého VBA projektu obsahujícího jeden modul a přidání dvou požadovaných odkazů na knihovny.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;


 using (Presentation pres = new Presentation())

{

    // Vytvořit nový VBA projekt

    pres.VbaProject = new VbaProject();

    // Přidat prázdný modul do VBA projektu

    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");

    // Nastavit zdrojový kód modulu

    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // Vytvořit odkaz na <stdole>

    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Vytvořit odkaz na Office

    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Přidat odkazy do VBA projektu

    pres.VbaProject.References.Add(stdoleReference);

    pres.VbaProject.References.Add(officeReference);

    pres.Save("test.pptm", SaveFormat.Pptm);

}
``` 

Tento příklad ukazuje, jak zkopírovat VBA projekt z existující prezentace do nové.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Vba;


 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}
``` 
### **Added Interfaces, Properties and Enumeration Options**
#### **Added the Aspose.Slides.Charts.IChartSeries.Overlap Property**
Vlastnost Aspose.Slides.Charts.IChartSeries.Overlap určuje, jak moc se mají sloupce a pruhy překrývat v 2D grafech (v rozmezí od -100 do 100).

Tato vlastnost se vztahuje nejen na tuto řadu, ale i na všechny řady v nadřazené skupině řad – jedná se o projekci odpovídající skupinové vlastnosti. Tato vlastnost je pouze pro čtení.

- Použijte vlastnost ParentSeriesGroup pro přístup k nadřazené skupině řad.
- Použijte vlastnost ParentSeriesGroup.Overlap pro čtení/zápis a změnu hodnoty.

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
#### **Added the Aspose.Slides.Charts.IChartSeriesGroup.Overlap Property**
Vlastnost Aspose.Slides.Charts.IChartSeriesGroup.Overlap určuje, jak moc se mají sloupce a pruhy překrývat v 2D grafech (od -100 do 100).

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
#### **Added the ShapeThumbnailBounds.Appearance Enum Value**
Tato metoda vytváření miniatury tvaru umožňuje vygenerovat miniaturu tvaru v mezích jeho vzhledu. Bere v úvahu všechny efekty tvaru. Vygenerovaná miniatura tvaru je omezena mezemi snímku.

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