---
title: Renderowanie slajdów prezentacji jako obrazy SVG na Androidzie
linktitle: Slajd do SVG
type: docs
weight: 50
url: /pl/androidjava/render-a-slide-as-an-svg-image/
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
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak renderować slajdy PowerPoint jako obrazy SVG przy użyciu Aspose.Slides dla Androida. Wysokiej jakości grafika przy prostych przykładach kodu Java."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak renderować slajdy prezentacji jako obrazy SVG przy użyciu Aspose.Slides. Opisuje format SVG oraz jego zalety, w tym skalowalność, dostępność i przydatność w tworzeniu stron internetowych.

Dowiesz się, jak załadować plik prezentacji, przeiterować jej slajdy i zapisać każdy slajd jako oddzielny plik SVG. Artykuł obejmuje formaty prezentacji PowerPoint i OpenDocument, w tym PPT, PPTX, ODP i PPS, oraz pokazuje, jak programowo wykonać konwersję przy użyciu klasy `Presentation` i metody `writeAsSvg`.

## **Format SVG**

SVG — skrót od Scalable Vector Graphics — jest standardowym typem grafiki lub formatem używanym do renderowania dwuwymiarowych obrazów. SVG przechowuje obrazy jako wektory w XML, zawierające szczegóły definiujące ich zachowanie lub wygląd.

SVG jest jednym z niewielu formatów obrazów, które spełniają bardzo wysokie standardy w następujących aspektach: skalowalność, interaktywność, wydajność, dostępność, programowalność i inne. Z tych powodów jest powszechnie używany w tworzeniu stron internetowych.

Możesz chcieć używać plików SVG, gdy potrzebujesz

- **wydrukować swoją prezentację w *bardzo dużym formacie*.** Obrazy SVG mogą skalować się do dowolnej rozdzielczości lub poziomu. Możesz zmieniać rozmiar obrazów SVG dowolną liczbę razy bez utraty jakości.
- **używać wykresów i diagramów ze swoich slajdów w *różnych mediach lub platformach***. Większość czytników może interpretować pliki SVG.
- **używać *najmniejszych możliwych rozmiarów obrazów***. Pliki SVG są zazwyczaj mniejsze niż ich wysokiej rozdzielczości odpowiedniki w innych formatach, szczególnie w formatach opartych na bitmapie (JPEG lub PNG).

## **Renderowanie slajdu jako obrazu SVG**

Aspose.Slides for Android via Java umożliwia eksportowanie slajdów w Twoich prezentacjach jako obrazy SVG. Przejdź przez następujące kroki, aby wygenerować obrazy SVG:

1. Utwórz instancję klasy Presentation.
2. Iteruj przez wszystkie slajdy w prezentacji.
3. Zapisz każdy slajd do własnego pliku SVG przy użyciu FileOutputStream.

{{% alert color="primary" %}} 
Możesz wypróbować naszą [darmową aplikację internetową](https://products.aspose.app/slides/pl/conversion/ppt-to-svg), w której zaimplementowaliśmy funkcję konwersji PPT do SVG z Aspose.Slides for Android via Java.
{{% /alert %}} 

Poniższy przykładowy kod w Javie pokazuje, jak przekonwertować PPT na SVG przy użyciu Aspose.Slides:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);

        FileOutputStream fileStream = new FileOutputStream("slide-" + index + ".svg");
        try {
            slide.writeAsSvg(fileStream);
        } finally {
            fileStream.close();
        }
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Dlaczego wynikowy SVG może wyglądać inaczej w różnych przeglądarkach?**

Obsługa konkretnych funkcji SVG jest realizowana różnie przez silniki przeglądarek. Parametry [SVGOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/svgoptions/) pomagają wygładzić niezgodności.

**Czy można eksportować nie tylko slajdy, ale także pojedyncze kształty do SVG?**

Tak. Każdy [kształt można zapisać jako oddzielny SVG](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-), co jest wygodne dla ikon, piktogramów i ponownego użycia grafiki.

**Czy wiele slajdów można połączyć w jeden SVG (pasek/dokument)?**

Standardowy scenariusz to jeden slajd → jeden SVG. Połączenie kilku slajdów w jedno płótno SVG jest krokiem post‑processingowym wykonywanym na poziomie aplikacji.