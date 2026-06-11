---
title: Renderowanie slajdów prezentacji jako obrazy SVG w C++
linktitle: Slajd do SVG
type: docs
weight: 50
url: /pl/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint do SVG
- prezentacja do SVG
- slajd do SVG
- PPT do SVG
- PPTX do SVG
- zapisz PPT jako SVG
- zapisz PPTX jako SVG
- eksportuj PPT do SVG
- eksportuj PPTX do SVG
- renderuj slajd
- konwertuj slajd
- eksportuj slajd
- obraz wektorowy
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak renderować slajdy PowerPoint jako obrazy SVG przy użyciu Aspose.Slides dla C++. Wysokiej jakości wizualizacje z prostymi przykładami kodu."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak renderować slajdy prezentacji jako obrazy SVG przy użyciu Aspose.Slides. Opisuje format SVG i jego zalety, w tym skalowalność, dostępność i przydatność w rozwoju stron internetowych.

Nauczysz się, jak załadować plik prezentacji, przeiterować jej slajdy i zapisać każdy slajd jako osobny plik SVG. Artykuł obejmuje formaty prezentacji PowerPoint i OpenDocument, w tym PPT, PPTX, ODP i PPS, oraz pokazuje, jak wykonać konwersję programowo przy użyciu klasy `Presentation` i metody `WriteAsSvg`.

## **Format SVG**

SVG — skrót od Scalable Vector Graphics — jest standardowym typem grafiki lub formatem używanym do renderowania dwuwymiarowych obrazów. SVG przechowuje obrazy jako wektory w XML z detalami definiującymi ich zachowanie lub wygląd. 

SVG jest jednym z niewielu formatów obrazów, które spełniają bardzo wysokie standardy w następujących aspektach: skalowalność, interaktywność, wydajność, dostępność, programowalność i inne. Z tych powodów jest powszechnie używany w tworzeniu witryn internetowych. 

Możesz chcieć używać plików SVG, gdy potrzebujesz

- **wydrukować prezentację w *bardzo dużym formacie*.** Obrazy SVG mogą być skalowane do dowolnej rozdzielczości lub poziomu. Możesz zmieniać rozmiar obrazów SVG tak wiele razy, jak to konieczne, nie tracąc jakości.
- **używać wykresów i diagramów ze swoich slajdów w *różnych mediach lub platformach*.** Większość czytników potrafi interpretować pliki SVG. 
- **używać *najmniejszych możliwych rozmiarów obrazów***. Pliki SVG są zazwyczaj mniejsze niż ich wysokiej rozdzielczości odpowiedniki w innych formatach, szczególnie w formatach opartych na bitmapie (JPEG lub PNG).

## **Renderowanie slajdu jako obrazu SVG**

Aspose.Slides for C++ umożliwia eksportowanie slajdów w prezentacjach jako obrazy SVG. Przejdź przez następujące kroki, aby wygenerować obrazy SVG:

1. Utwórz instancję klasy Presentation.
2. Przejdź przez wszystkie slajdy w prezentacji.
3. Zapisz każdy slajd w osobnym pliku SVG przy użyciu FileStream.

{{% alert color="primary" %}} 

Możesz wypróbować naszą [bezpłatną aplikację internetową](https://products.aspose.app/slides/pl/conversion/ppt-to-svg), w której zaimplementowaliśmy funkcję konwersji PPT do SVG z Aspose.Slides for C++.

{{% /alert %}} 

Poniższy przykładowy kod w C++ pokazuje, jak przekonwertować PPT na SVG przy użyciu Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
        
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto fileName = String::Format(u"slide-{0}.svg", index);
    auto fileStream = System::MakeObject<FileStream>(fileName, FileMode::Create, FileAccess::Write);

    auto slide = pres->get_Slides()->idx_get(index);
    slide->WriteAsSvg(fileStream);
}
```

## **FAQ**

**Dlaczego wygenerowany SVG może wyglądać inaczej w przeglądarkach?**

Obsługa konkretnych funkcji SVG jest realizowana inaczej przez silniki przeglądarek. Parametry [SVGOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/svgoptions/) pomagają wygładzić niezgodności.

**Czy można eksportować nie tylko slajdy, ale także pojedyncze kształty do SVG?**

Tak. Każdy [kształt może być zapisany jako oddzielny SVG](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/writeassvg/), co jest wygodne w przypadku ikon, piktogramów i ponownego użycia grafiki.

**Czy wiele slajdów można połączyć w jeden SVG (strip/dokument)?**

Standardowy scenariusz to jeden slajd → jeden SVG. Łączenie kilku slajdów w jedną płaszczyznę SVG jest krokiem przetwarzania końcowego wykonywanym na poziomie aplikacji.