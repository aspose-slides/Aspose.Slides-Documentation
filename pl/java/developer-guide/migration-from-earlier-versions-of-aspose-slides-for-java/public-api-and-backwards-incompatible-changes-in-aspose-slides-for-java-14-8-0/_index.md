---
title: Publiczne API i zmiany niekompatybilne wstecz w Aspose.Slides for Java 14.8.0
linktitle: Aspose.Slides dla Java 14.8.0
type: docs
weight: 70
url: /pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
keywords:
- migracja
- kod legacy
- nowoczesny kod
- podejście legacy
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Przeglądaj aktualizacje publicznego API oraz zmiany łamiące w Aspose.Slides for Java, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="primary" %}} 

Ta strona wymienia wszystkie [dodane](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) klasy, metody, właściwości i tak dalej, wszystkie nowe ograniczenia oraz inne [zmiany](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) wprowadzone w API Aspose.Slides for Java 14.8.0.

{{% /alert %}} 
## **Zmiany w publicznym API**
### **Dodano metody Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap() oraz setOverlap(byte)**
Metoda Aspose.Slides.Charts.IChartSeries.getOverlap() określa, jak bardzo słupki i kolumny powinny nachodzić na wykresach 2D (w przedziale od -100 do 100).  
Ta metoda nie dotyczy tylko konkretnej serii, ale wszystkich serii w grupie serii nadrzędnej – jest to projekcja odpowiedniej własności grupy.

- Użyj metody IChartSeries.getParentSeriesGroup() w celu uzyskania dostępu do grupy serii nadrzędnej.  
- Użyj metod IChartSeriesGroup.getOverlap() oraz setOverlap(byte) do zarządzania wartością.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap(-30);

}

```
### **Dodano wartość wyliczenia ShapeThumbnailBounds.Appearance**
Ta metoda tworzenia miniaturek kształtów umożliwia programistom wygenerowanie miniatury kształtu w granicach jego wyglądu. Uwzględnia wszystkie efekty kształtu. Wygenerowana miniatura kształtu jest ograniczona granicami slajdu.

``` java

 Presentation pres = new Presentation();

BufferedImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **Dodano klasę VbaProject i interfejs IVbaProject, zmieniono metody Presentation.getVbaProject() oraz setVbaProject(VbaProject)**
Nowa funkcja umożliwia programistom tworzenie i edytowanie projektów VBA w prezentacji.

``` java

 Presentation pres = new Presentation();

// Utwórz nowy projekt VBA

pres.setVbaProject(new VbaProject());

// Dodaj pusty moduł do projektu VBA

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

// Ustaw kod źródłowy modułu

module.setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");

// Utwórz odwołanie do <stdole>

VbaReferenceOleTypeLib stdoleReference =

  new VbaReferenceOleTypeLib("stdole",

    "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Utwórz odwołanie do Office

VbaReferenceOleTypeLib officeReference =

  new VbaReferenceOleTypeLib("Office",

    "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Dodaj odwołania do projektu VBA

pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("data\\test.pptm", SaveFormat.Pptm);

```