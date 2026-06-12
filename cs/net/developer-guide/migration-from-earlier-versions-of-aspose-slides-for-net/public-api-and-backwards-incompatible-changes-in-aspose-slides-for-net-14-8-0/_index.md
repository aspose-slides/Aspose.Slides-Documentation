---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro .NET 14.8.0
linktitle: Aspose.Slides pro .NET 14.8.0
type: docs
weight: 100
url: /cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
keywords:
- migrace
- zastaralý kód
- moderní kód
- zastaralý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Prohlédněte si aktualizace veřejného API a nepřetržité změny v Aspose.Slides pro .NET, abyste mohli plynule migrovat svá řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="primary" %}}

Tato stránka uvádí všechny [přidané](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) nebo [odstraněné](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) třídy, metody, vlastnosti a podobně, a další změny zavedené v API Aspose.Slides pro .NET 14.8.0.

{{% /alert %}} 
## **Změny veřejného API**
### **Změněné vlastnosti**
#### **Přidáno rozhraní IVbaProject, změněna vlastnost Presentation.VbaProject**
Vlastnost VbaProject třídy Presentation byla nahrazena. Místo surové bajtové reprezentace VBA projektu byla přidána nová implementace rozhraní IVbaProject.

Použijte vlastnost IVbaProject k správě VBA projektů vložených do prezentace. Můžete přidávat nové odkazy na projekty, upravovat existující moduly a vytvářet nové.

Také můžete vytvořit nový VBA projekt pomocí třídy VbaProject, která implementuje rozhraní IVbaProject.

Následující příklad ukazuje vytvoření jednoduchého VBA projektu obsahujícího jeden modul a přidání dvou požadovaných odkazů na knihovny.

``` csharp

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

Tento příklad ukazuje, jak zkopírovat VBA projekt ze stávající prezentace do nové.

``` csharp

 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}

``` 
### **Přidány rozhraní, vlastnosti a hodnoty výčtů**
#### **Přidána vlastnost Aspose.Slides.Charts.IChartSeries.Overlap**
Vlastnost Aspose.Slides.Charts.IChartSeries.Overlap určuje, jak moc se mají sloupce a pruhy překrývat v 2D grafech (rozsah od -100 do 100).

Tato vlastnost se týká nejen této řady, ale všech řad v nadřazené skupině řad – jedná se o projekci příslušné vlastnosti skupiny. Tato vlastnost je tedy pouze pro čtení.

- Použijte vlastnost ParentSeriesGroup k přístupu k nadřazené skupině řad.
- Použijte vlastnost ParentSeriesGroup.Overlap pro čtení/zápis k změně hodnoty.

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
#### **Přidána vlastnost Aspose.Slides.Charts.IChartSeriesGroup.Overlap**
Vlastnost Aspose.Slides.Charts.IChartSeriesGroup.Overlap určuje, jak moc se mají sloupce a pruhy překrývat v 2D grafech (od -100 do 100).

``` csharp



using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}

``` 
#### **Přidána hodnota výčtu ShapeThumbnailBounds.Appearance**
Tato metoda vytváření náhledů tvarů vám umožňuje generovat náhled tvaru v mezích jeho vzhledu. Zohledňuje všechny efekty tvaru. Vytvořený náhled tvaru je ohraničen mezemi snímku.

``` csharp



using (Presentation p = new Presentation("Presentation.pptx"))

{

    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

    st.Save("ShapeThumbnail.png", ImageFormat.Png);

}
```