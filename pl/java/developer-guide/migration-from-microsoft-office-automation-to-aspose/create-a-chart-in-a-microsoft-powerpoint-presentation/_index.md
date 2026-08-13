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
description: "Dowiedz się, jak automatyzować tworzenie wykresów PowerPoint w Javie. Ten przewodnik krok po kroku pokazuje, dlaczego Aspose.Slides for Java jest szybszą i bardziej wydajną alternatywą dla Microsoft.Office.Interop."
---
{{% alert color="info" %}} 

Wykresy są wizualną reprezentacją danych, które są szeroko stosowane w prezentacjach. Ten artykuł pokazuje kod tworzący wykres w programie Microsoft PowerPoint programowo przy użyciu [VSTO](/slides/pl/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) i [Aspose.Slides for Java](/slides/pl/java/create-a-chart-in-a-microsoft-powerpoint-presentation/).

{{% /alert %}} 
## **Tworzenie wykresu**
Poniższe przykłady kodu opisują proces dodawania prostego wykresu słupkowego 3D grupowanego przy użyciu VSTO. Tworzysz instancję prezentacji Microsoft PowerPoint, dodajesz do niej domyślny wykres. Następnie używasz skoroszytu Microsoft Excel, aby uzyskać dostęp do danych wykresu i je modyfikować oraz ustawiać właściwości wykresu. Na końcu zapisujesz prezentację.
### **Przykład VSTO**
Przy użyciu VSTO wykonuje się następujące kroki:

1. Utwórz instancję prezentacji Microsoft PowerPoint.  
2. Dodaj pusty slajd do prezentacji.  
3. Dodaj wykres **3D clustered column** i uzyskaj do niego dostęp.  
4. Utwórz nową instancję skoroszytu Microsoft Excel i wczytaj dane wykresu.  
5. Uzyskaj dostęp do arkusza danych wykresu przy użyciu instancji Microsoft Excel Workbook instancefromworkbook.  
6. Ustaw zakres wykresu w arkuszu i usuń serie 2 i 3 z wykresu.  
7. Modyfikuj dane kategorii wykresu w arkuszu danych wykresu.  
8. Modyfikuj dane serii 1 wykresu w arkuszu danych wykresu.  
9. Teraz uzyskaj dostęp do tytułu wykresu i setthefontrelatedproperties.  
10. Uzyskaj dostęp do osi wartości wykresu i ustaw jednostkę główną, jednostki pomocnicze, wartość maksymalną oraz minimalną.  
11. Uzyskaj dostęp do głębokości wykresu lub osi serii i usuń ją, ponieważ w tym przykładzie używana jest tylko jedna seria (onlyoneserieisused).  
12. Teraz ustaw kąty obrotu wykresu w kierunkach X i Y.  
13. Zapisz prezentację.  
14. Zamknij instancje Microsoft Excel i PowerPoint.  

**Prezentacja wyjściowa, utworzona przy użyciu VSTO** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **Przykład Aspose.Slides for Java**
Przy użyciu Aspose.Slides for Java wykonywane są następujące kroki:

1. Utwórz instancję prezentacji Microsoft PowerPoint.  
2. Dodaj pusty slajd do prezentacji.  
3. Dodaj wykres **3D clustered column** i uzyskaj do niego dostęp.  
4. Uzyskaj dostęp do arkusza danych wykresu przy użyciu instancji Microsoft Excel Workbook instancefromworkbook.  
5. Usuń nieużywane serie 2 i 3.  
6. Uzyskaj dostęp do kategorii wykresu i zmodyfikuj etykiety.  
7. Uzyskaj dostęp do Accesseries1 i zmodyfikuj wartości serii.  
8. Teraz uzyskaj dostęp do tytułu wykresu i ustaw właściwości czcionki.  
9. Uzyskaj dostęp do osi wartości wykresu i ustaw jednostkę główną, jednostki pomocnicze, wartość maksymalną oraz minimalną.  
10. Teraz ustaw kąty obrotu wykresu w kierunkach X i Y.  
11. Zapisz prezentację w formacie PPTX.  

**Prezentacja wyjściowa, utworzona przy użyciu Aspose.Slides** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}

## **FAQ**

### Czy mogę tworzyć inne typy wykresów, takie jak kołowe, liniowe lub słupkowe, z użyciem Aspose.Slides?

Tak. Aspose.Slides obsługuje szeroką gamę [chart types](/slides/pl/java/create-chart/), w tym wykresy kołowe, liniowe, słupkowe, wykresy punktowe, wykresy bąbelkowe i wiele innych. Możesz określić żądany typ wykresu, używając klasy [ChartType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/charttype/) podczas dodawania wykresu.

### Czy mogę zastosować własne style lub motywy do wykresu?

Tak. Możesz w pełni dostosować wygląd wykresu, w tym kolory, czcionki, wypełnienia, kontury, linie siatki i układ. Jednak zastosowanie motywów Office dokładnie tak, jak są widoczne w PowerPoint, wymaga ręcznego ustawiania poszczególnych stylów.

### Czy mogę wyeksportować wykres jako osobny obraz, oddzielnie od slajdu?

Tak, Aspose.Slides umożliwia wyeksportowanie dowolnego kształtu — w tym wykresów — jako osobny obraz (np. PNG, JPEG) przy użyciu metody `getImage` na [shape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/).