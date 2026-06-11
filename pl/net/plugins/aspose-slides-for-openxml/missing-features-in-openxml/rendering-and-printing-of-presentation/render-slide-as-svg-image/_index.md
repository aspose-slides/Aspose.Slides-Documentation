---
title: Renderuj slajd jako obraz SVG
type: docs
weight: 50
url: /pl/net/render-slide-as-svg-image/
---
SVG — skrót od Scalable Vector Graphics — to standardowy typ lub format grafiki używany do renderowania dwuwymiarowych obrazów. SVG przechowuje obrazy jako wektory w XML z detalami definiującymi ich zachowanie lub wygląd.  

SVG jest jednym z niewielu formatów obrazów, które spełniają bardzo wysokie standardy w następujących aspektach: skalowalność, interaktywność, wydajność, dostępność, programowalność i inne. Z tych powodów jest powszechnie używany w tworzeniu stron internetowych.  

Możesz chcieć używać plików SVG w następujących sytuacjach:

- gdy planujesz wydrukować swoją prezentację w bardzo dużym formacie. Obrazy SVG mogą skalować się do dowolnej rozdzielczości lub poziomu. Możesz zmieniać rozmiar obrazów SVG tyle razy, ile potrzebujesz, nie tracąc jakości.  
- gdy zamierzasz wykorzystać wykresy i diagramy ze swoich slajdów w różnych mediach lub platformach. Większość czytników potrafi interpretować pliki SVG.  
- gdy potrzebujesz jak najmniejszych rozmiarów obrazów. Pliki SVG są zazwyczaj mniejsze od ich wysokiej rozdzielczości odpowiedników w innych formatach, szczególnie w formatach opartych na bitmapie (JPEG lub PNG).  

Aspose.Slides for .NET umożliwia eksportowanie slajdów w twoich prezentacjach jako obrazy **SVG**. Aby wygenerować obraz SVG z dowolnego slajdu, wykonaj następujące kroki:

- Utwórz instancję klasy Presentation.  
- Przejdź przez wszystkie slajdy w prezentacji.  
- Zapisz każdy slajd do osobnego pliku SVG przy użyciu FileStream.  

{{% alert color="primary" %}} 

Możesz wypróbować naszą [bezpłatną aplikację internetową](https://products.aspose.app/slides/pl/conversion/ppt-to-svg), w której zaimplementowaliśmy funkcję konwersji PPT do SVG z Aspose.Slides for .NET.  

{{% /alert %}} 

Ten przykładowy kod w C# pokazuje, jak przekonwertować PPT do SVG przy użyciu Aspose.Slides:  

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (FileStream fileStream = new FileStream($"slide-{index}.svg", FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsSvg(fileStream);   
        }
    }
}
```