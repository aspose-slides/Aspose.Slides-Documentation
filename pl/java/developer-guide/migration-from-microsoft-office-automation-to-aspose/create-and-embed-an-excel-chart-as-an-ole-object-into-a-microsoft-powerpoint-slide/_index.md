---
title: Utwórz i osadź wykresy Excel jako obiekty OLE przy użyciu VSTO i Aspose.Slides for Java
linktitle: Utwórz i osadź wykresy Excel jako obiekty OLE
type: docs
weight: 60
url: /pl/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- tworzenie wykresu
- osadzanie wykresu Excel
- obiekt OLE
- migracja
- VSTO
- automatyzacja Office
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Migracja z automatyzacji Microsoft Office do Aspose.Slides for Java i osadzanie wykresów Excel jako obiekty OLE w slajdach PowerPoint (PPT, PPTX) w języku Java."
---
{{% alert color="primary" %}} 

Wykresy są wizualnym przedstawieniem danych i są powszechnie używane w slajdach prezentacji. Ten artykuł pokaże kod, który tworzy i osadza wykres Excel jako obiekt OLE w slajdzie programu PowerPoint przy użyciu [VSTO](/slides/pl/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) oraz [Aspose.Slides for Java](/slides/pl/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **Tworzenie i osadzanie wykresu Excel**
Poniższe dwa przykłady kodu są długie i szczegółowe, ponieważ opisują złożone zadanie. Tworzysz skoroszyt Microsoft Excel, tworzysz wykres, a następnie tworzysz prezentację Microsoft PowerPoint, w której osadzisz wykres. Obiekty OLE zawierają odnośniki do oryginalnego dokumentu, więc użytkownik, który dwukrotnie kliknie osadzony plik, uruchomi ten plik oraz jego aplikację.
### **Przykład VSTO**
Przy użyciu VSTO, wykonywane są następujące kroki:

1. Utwórz instancję obiektu Microsoft Excel ApplicationClass.
1. Utwórz nowy skoroszyt z jedną arkuszem.
1. Dodaj wykres do arkusza.
1. Zapisz skoroszyt.
1. Otwórz skoroszyt Excel zawierający arkusz z danymi wykresu.
1. Pobierz kolekcję ChartObjects dla arkusza.
1. Pobierz wykres do skopiowania.
1. Utwórz prezentację Microsoft PowerPoint.
1. Dodaj pusty slajd do prezentacji.
1. Skopiuj wykres z arkusza Excel do schowka.
1. Wklej wykres do prezentacji PowerPoint.
1. Ustaw pozycję wykresu na slajdzie.
1. Zapisz prezentację.



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Przykład Aspose.Slides for Java**
Przy użyciu Aspose.Slides for Java, wykonywane są następujące kroki:

1. Utwórz skoroszyt przy użyciu Aspose.Cells for Java.
1. Utwórz wykres Microsoft Excel.
1. Ustaw rozmiar OLE wykresu Excel.
1. Pobierz obraz wykresu.
1. Osadź wykres Excel jako obiekt OLE w prezentacji PPTX przy użyciu Aspose.Slides for Java.
1. Zastąp zmieniony obraz obiektu obrazem uzyskanym w kroku 3, aby rozwiązać problem zmiany obiektu.
1. Zapisz wynikową prezentację na dysku w formacie PPTX.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}