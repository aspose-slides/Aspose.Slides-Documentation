---
title: Renderowanie slajdu jako obraz SVG
type: docs
weight: 50
url: /pl/net/render-slide-as-svg-image/
---
SVG — skrót od Scalable Vector Graphics — jest standardowym typem grafiki lub formatem używanym do renderowania dwuwymiarowych obrazów. SVG przechowuje obrazy jako wektory w XML z detalami definiującymi ich zachowanie lub wygląd.

SVG jest jednym z niewielu formatów obrazów, które spełniają bardzo wysokie standardy pod względem skalowalności, interaktywności, wydajności, dostępności, programowalności i innych. Z tych powodów jest powszechnie używany w tworzeniu stron internetowych.

Możesz chcieć używać plików SVG w następujących scenariuszach:

- gdy planujesz wydrukować swoją prezentację w bardzo dużym formacie. Obrazy SVG mogą skalować się do dowolnej rozdzielczości lub poziomu. Możesz zmieniać rozmiar obrazów SVG dowolną ilość razy bez utraty jakości.
- gdy zamierzasz używać wykresów i diagramów ze swoich slajdów w różnych mediach lub platformach. Większość czytników może interpretować pliki SVG.
- gdy potrzebujesz najmniejszych możliwych rozmiarów obrazów. Pliki SVG są zazwyczaj mniejsze niż ich odpowiedniki w wysokiej rozdzielczości w innych formatach, szczególnie w formatach opartych na bitmapie (JPEG lub PNG).

Aspose.Slides for .NET umożliwia eksportowanie slajdów w prezentacjach jako obrazy **SVG**. Aby wygenerować obraz SVG z dowolnego slajdu, wykonaj następujące kroki:

- Utwórz instancję klasy Presentation.
- Przejdź przez wszystkie slajdy w prezentacji.
- Zapisz każdy slajd do osobnego pliku SVG przy użyciu FileStream.

{{% alert color="info" %}} 
Możesz wypróbować naszą [darmową aplikację internetową](https://products.aspose.app/slides/pl/conversion/ppt-to-svg), w której zaimplementowaliśmy funkcję konwersji PPT do SVG z Aspose.Slides for .NET.
{{% /alert %}} 

Ten przykładowy kod w C# pokazuje, jak skonwertować PPT do SVG za pomocą Aspose.Slides:

``` csharp
using Aspose.Slides;

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