---
title: Tworzenie wykresów przy użyciu VSTO i Aspose.Slides for Java
linktitle: Utwórz wykres
type: docs
weight: 70
url: /pl/java/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- tworzenie wykresu
- migracja
- VSTO
- automatyzacja Office
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak automatyzować tworzenie wykresów PowerPoint w Javie. Ten przewodnik krok po kroku pokazuje, dlaczego Aspose.Slides for Java jest szybszą i bardziej potężną alternatywą dla Microsoft.Office.Interop."
---
{{% alert color="primary" %}} 

Diagramy są wizualnymi reprezentacjami danych, które są szeroko stosowane w prezentacjach. Ten artykuł pokazuje kod tworzenia wykresu w programie Microsoft PowerPoint programowo przy użyciu [VSTO](/slides/pl/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) oraz [Aspose.Slides for Java](/slides/pl/java/create-a-chart-in-a-microsoft-powerpoint-presentation/).

{{% /alert %}} 
## **Tworzenie wykresu**
Poniższe przykłady kodu opisują proces dodawania prostego wykresu słupkowego 3D grupowanego przy użyciu VSTO. Tworzysz instancję prezentacji Microsoft PowerPoint, dodajesz do niej domyślny wykres. Następnie używasz skoroszytu Microsoft Excel, aby uzyskać dostęp i zmodyfikować dane wykresu oraz ustawić właściwości wykresu. Na koniec zapisujesz prezentację.
### **Przykład VSTO**
Przy użyciu VSTO wykonywane są następujące kroki:

1. Utwórz instancję prezentacji Microsoft PowerPoint.
1. Dodaj pusty slajd do prezentacji.
1. Dodaj wykres **3D clustered column** i uzyskaj do niego dostęp.
1. Utwórz nową instancję skoroszytu Microsoft Excel i załaduj dane wykresu.
1. Uzyskaj dostęp do arkusza danych wykresu przy użyciu Microsoft Excel Workbook instancefromworkbook.
1. Ustaw zakres wykresu w arkuszu i usuń serie 2 i 3 z wykresu.
1. Zmodyfikuj dane kategorii wykresu w arkuszu danych wykresu.
1. Zmodyfikuj dane serii 1 wykresu w arkuszu danych wykresu.
1. Teraz uzyskaj dostęp do tytułu wykresu i setthefontrelatedproperties.
1. Uzyskaj dostęp do osi wartości wykresu i ustaw jednostkę główną, jednostki podrzędne, maksymalną wartość oraz minimalne wartości.
1. Uzyskaj dostęp do osi głębokości wykresu lub osi serii i usuń ją, ponieważ w tym przykładzie używana jest tylko jedna seria onlyoneserieisused.
1. Teraz ustaw kąty obrotu wykresu w kierunku X i Y.
1. Zapisz prezentację.
1. Zamknij instancje Microsoft Excel i PowerPoint.

**Prezentacja wyjściowa, utworzona przy użyciu VSTO** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **Przykład Aspose.Slides for Java**
Przy użyciu Aspose.Slides for Java wykonywane są następujące kroki:

1. Utwórz instancję prezentacji Microsoft PowerPoint.
1. Dodaj pusty slajd do prezentacji.
1. Dodaj wykres **3D clustered column** i uzyskaj do niego dostęp.
1. Uzyskaj dostęp do arkusza danych wykresu przy użyciu Microsoft Excel Workbook instancefromworkbook.
1. Usuń nieużywane serie 2 i 3.
1. Uzyskaj dostęp do kategorii wykresu i zmodyfikuj etykiety.
1. Accesseries1 i zmodyfikuj wartości serii.
1. Teraz uzyskaj dostęp do tytułu wykresu i ustaw właściwości czcionki.
1. Uzyskaj dostęp do osi wartości wykresu i ustaw jednostkę główną, jednostki podrzędne, maksymalną wartość oraz minimalne wartości.
1. Teraz ustaw kąty obrotu wykresu w kierunku X i Y.
1. Zapisz prezentację w formacie PPTX.

**Prezentacja wyjściowa, utworzona przy użyciu Aspose.Slides** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}

## **FAQ**

**Czy mogę tworzyć inne typy wykresów, takie jak wykresy kołowe, liniowe lub słupkowe, przy użyciu Aspose.Slides?**

Tak. Aspose.Slides obsługuje szeroką gamę [typów wykresów](/slides/pl/java/create-chart/), w tym wykresy kołowe, liniowe, słupkowe, wykresy punktowe, wykresy bąbelkowe i wiele innych. Możesz określić żądany typ wykresu, używając klasy [ChartType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/charttype/) podczas dodawania wykresu.

**Czy mogę zastosować własne style lub motywy do wykresu?**

Tak. Możesz w pełni dostosować wygląd wykresu, w tym kolory, czcionki, wypełnienia, kontury, linie siatki i układ. Jednak zastosowanie motywów Office dokładnie tak, jak w PowerPoint, wymaga ręcznego ustawiania poszczególnych stylów.

**Czy mogę wyeksportować wykres jako oddzielny obraz poza slajdem?**

Tak, Aspose.Slides umożliwia eksport dowolnego kształtu — w tym wykresów — jako oddzielny obraz (np. PNG, JPEG) przy użyciu metody `getImage` na [kształcie](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/) wykresu.