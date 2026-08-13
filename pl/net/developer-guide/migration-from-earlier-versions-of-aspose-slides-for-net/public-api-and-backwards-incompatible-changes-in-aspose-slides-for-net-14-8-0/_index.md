---
title: Publiczne API oraz zmiany niekompatybilne wstecz w Aspose.Slides dla .NET 14.8.0
linktitle: Aspose.Slides dla .NET 14.8.0
type: docs
weight: 100
url: /pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
keywords:
- migracja
- kod przestarzały
- nowoczesny kod
- przestarzałe podejście
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Przeglądaj aktualizacje publicznego API oraz zmiany łamiące kompatybilność w Aspose.Slides dla .NET, aby płynnie migrować swoje rozwiązania prezentacji PowerPoint (PPT, PPTX) i ODP."
---
{{% alert color="info" %}}

Ta strona wymienia wszystkie [dodane](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) lub [usunięte](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) klasy, metody, właściwości itp., oraz inne zmiany wprowadzone w API Aspose.Slides for .NET 14.8.0.

{{% /alert %}} 
## **Zmiany publicznego API**
### **Zmienione właściwości**
#### **Dodano interfejs IVbaProject, zmieniono właściwość Presentation.VbaProject**
Właściwość VbaProject klasy Presentation została zastąpiona. Zamiast surowej reprezentacji bajtowej projektu VBA w właściwości VbaProject, dodano nową implementację interfejsu IVbaProject.

Użyj właściwości IVbaProject do zarządzania projektami VBA osadzonymi w prezentacji. Możesz dodawać nowe referencje projektów, edytować istniejące moduły i tworzyć nowe.

Możesz także utworzyć nowy projekt VBA przy użyciu klasy VbaProject, która implementuje interfejs IVbaProject.

Poniższy przykład pokazuje tworzenie prostego projektu VBA zawierającego jeden moduł oraz dodanie dwóch wymaganych referencji do bibliotek.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;


 using (Presentation pres = new Presentation())

{

    // Utwórz nowy projekt VBA
    pres.VbaProject = new VbaProject();

    // Dodaj pusty moduł do projektu VBA
    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");

    // Ustaw kod źródłowy modułu
    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // Utwórz referencję do <stdole>
    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Utwórz referencję do Office
    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Dodaj referencje do projektu VBA
    pres.VbaProject.References.Add(stdoleReference);

    pres.VbaProject.References.Add(officeReference);

    pres.Save("test.pptm", SaveFormat.Pptm);

}
``` 

Ten przykład pokazuje, jak skopiować projekt VBA z istniejącej prezentacji do nowej.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Vba;


 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}
``` 
### **Dodane interfejsy, właściwości i opcje wyliczeń**
#### **Dodano właściwość Aspose.Slides.Charts.IChartSeries.Overlap**
Właściwość Aspose.Slides.Charts.IChartSeries.Overlap określa, jak bardzo słupki i kolumny mają się nachodzić na wykresach 2‑D (zakres od -100 do 100).

Jest to właściwość nie tylko tej serii, ale wszystkich serii w grupie nadrzędnej – jest to projekcja odpowiedniej właściwości grupy. Dlatego właściwość jest tylko do odczytu.

- Użyj właściwości ParentSeriesGroup, aby uzyskać dostęp do grupy serii nadrzędnej.
- Użyj właściwości ParentSeriesGroup.Overlap z możliwością odczytu i zapisu, aby zmienić wartość.

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
#### **Dodano właściwość Aspose.Slides.Charts.IChartSeriesGroup.Overlap**
Właściwość Aspose.Slides.Charts.IChartSeriesGroup.Overlap określa, jak bardzo słupki i kolumny mają się nachodzić na wykresach 2‑D (od -100 do 100).

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
#### **Dodano wartość wyliczenia ShapeThumbnailBounds.Appearance**
Ta metoda tworzenia miniatury kształtu pozwala wygenerować miniaturę kształtu w granicach jego wyglądu. Uwzględnia wszystkie efekty kształtu. Wygenerowana miniatura kształtu jest ograniczona granicami slajdu.

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