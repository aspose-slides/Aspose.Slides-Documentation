---
title: Publiczne API i zmiany niekompatybilne wstecz w Aspose.Slides dla .NET 14.8.0
linktitle: Aspose.Slides dla .NET 14.8.0
type: docs
weight: 100
url: /pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
keywords:
- migracja
- kod legacy
- nowoczesny kod
- podejście legacy
- podejście nowoczesne
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Przeglądaj aktualizacje publicznego API oraz zmiany łamiące w Aspose.Slides dla .NET, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="primary" %}} 

Ta strona wymienia wszystkie [dodane](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) lub [usunięte](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) klasy, metody, właściwości itp., oraz inne zmiany wprowadzone w API Aspose.Slides for .NET 14.8.0.

{{% /alert %}} 
## **Zmiany w publicznym API**
### **Zmienione właściwości**
#### **Dodano interfejs IVbaProject, zmieniono właściwość Presentation.VbaProject**
Właściwość VbaProject klasy Presentation została zastąpiona. Zamiast surowej reprezentacji bajtowej projektu VBA, dodano implementację nowego interfejsu IVbaProject.

Użyj właściwości IVbaProject do zarządzania projektami VBA osadzonymi w prezentacji. Możesz dodać nowe odwołania do projektów, edytować istniejące moduły i tworzyć nowe.

Możesz także utworzyć nowy projekt VBA przy użyciu klasy VbaProject, która implementuje interfejs IVbaProject.

Poniższy przykład pokazuje utworzenie prostego projektu VBA zawierającego jeden moduł oraz dodanie dwóch wymaganych odwołań do bibliotek.

``` csharp

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

    // Utwórz odwołanie do <stdole>

    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Utwórz odwołanie do Office

    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Dodaj odwołania do projektu VBA

    pres.VbaProject.References.Add(stdoleReference);

    pres.VbaProject.References.Add(officeReference);

    pres.Save("test.pptm", SaveFormat.Pptm);

}
``` 

Ten przykład pokazuje, jak skopiować projekt VBA z istniejącej prezentacji do nowej.

``` csharp

 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}

``` 
### **Dodano interfejsy, właściwości i opcje wyliczeń**
#### **Dodano właściwość Aspose.Slides.Charts.IChartSeries.Overlap**
Właściwość Aspose.Slides.Charts.IChartSeries.Overlap określa, o ile słupki i kolumny mają się nakładać na wykresach 2D (zakres od -100 do 100).

Jest to właściwość nie tylko tej serii, ale wszystkich serii w grupie nadrzędnej – jest to projekcja odpowiedniej właściwości grupy. Dlatego właściwość jest tylko do odczytu.

- Użyj właściwości ParentSeriesGroup, aby uzyskać dostęp do grupy serii nadrzędnej.
- Użyj właściwości ParentSeriesGroup.Overlap (odczyt/zapis), aby zmienić wartość.

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
#### **Dodano właściwość Aspose.Slides.Charts.IChartSeriesGroup.Overlap**
Właściwość Aspose.Slides.Charts.IChartSeriesGroup.Overlap określa, o ile słupki i kolumny powinny się nakładać na wykresach 2D (od -100 do 100).

``` csharp



using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}

``` 
#### **Dodano wartość wyliczeniową ShapeThumbnailBounds.Appearance**
Ta metoda tworzenia miniatury kształtu pozwala wygenerować miniaturę w granicach jego wyglądu. Uwzględnia wszystkie efekty kształtu. Wygenerowana miniatura jest ograniczona do granic slajdu.

``` csharp



using (Presentation p = new Presentation("Presentation.pptx"))

{

    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

    st.Save("ShapeThumbnail.png", ImageFormat.Png);

}

```