---
title: Konwertuj slajdy prezentacji na obrazy w Node.js via .NET
linktitle: Slajd na obraz
type: docs
weight: 40
url: /pl/nodejs-net/convert-slide/
keywords:
- konwertuj slajd
- slajd na obraz
- slajd na PNG
- zapisz slajd jako obraz
- renderuj slajd
- miniatura slajdu
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Renderuj slajdy z prezentacji PPTX, PPT i ODP jako obrazy PNG w JavaScript przy użyciu Aspose.Slides dla Node.js via .NET, z uwzględnieniem współczynnika skalowania lub dokładnego rozmiaru w pikselach."
---
## **Przegląd**

Aspose.Slides for Node.js via .NET renderuje slajdy z prezentacji PowerPoint i OpenDocument jako obrazy, na przykład aby wyświetlać podglądy slajdów na stronie internetowej. Ten artykuł pokazuje dwa sposoby wyboru rozmiaru obrazu: współczynnik skalowania względem rozmiaru slajdu oraz dokładny rozmiar w pikselach. Oba przykłady zapisują pliki PNG.

Przykłady zakładają, że w folderze projektu znajduje się prezentacja o nazwie `sample.pptx`, którą utworzyłeś zgodnie z [Installation](/slides/pl/nodejs-net/installation/). Każda prezentacja PowerPoint się nada. Zapisz każdy przykład jako plik `.js` w folderze projektu i uruchom go z tego folderu przy użyciu `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET nie posiada własnej dokumentacji API. Odzwierciedla API Aspose.Slides dla .NET, używając nazw w stylu camelCase, więc odnośniki do API w tym artykule prowadzą do odpowiadających klas i członków w [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/).
{{% /alert %}}

Aby przekonwertować slajd na obraz, wykonaj następujące kroki:

1. Otwórz prezentację przy użyciu konstruktora [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/).
2. Pobierz slajd z kolekcji [slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) za pomocą `get(index)`. Indeksy zaczynają się od 0.
3. Renderuj slajd przy użyciu `getImageWithScale` lub `getImageWithImageSize`. W dokumentacji API .NET oba są przeciążeniami metody [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/). Zwracają obiekt obrazu odpowiadający [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/).
4. Zapisz obraz przy użyciu jego metody [save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) oraz wartości [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/), a następnie wywołaj jego metodę `dispose`.

## **Konwertuj każdy slajd na obraz PNG**

`getImageWithScale` przyjmuje poziomy i pionowy współczynnik skalowania. Przy skali 1, jeden punkt slajdu staje się jednym pikselem obrazu. Poniższy przykład renderuje każdy slajd przy skali 2:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

// Skala 1 renderuje jeden piksel na punkt; 2 podwaja szerokość i wysokość.
const scaleX = 2;
const scaleY = scaleX;

const presentation = new Presentation("sample.pptx");
try {
    const slideCount = presentation.slides.count;
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.slides.get(index);
        const image = slide.getImageWithScale(scaleX, scaleY);
        try {
            image.save(`slide_${index + 1}.png`, ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
    console.log(`Saved ${slideCount} images`);
} finally {
    presentation.dispose();
}
```

Skrypt zapisuje po jednym pliku dla każdego slajdu, `slide_1.png`, `slide_2.png` i tak dalej, numerując od 1. Dla prezentacji w formacie 16:9 z slajdami o wymiarach 960 × 540 punktów, każdy obraz ma 1920 × 1080 pikseli. Ukryte slajdy również są renderowane; aby je pominąć, sprawdź właściwość [hidden](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/) slajdu. Każdy obraz jest zwalniany w oddzielnym bloku `finally`, który zwalnia go przed renderowaniem kolejnego slajdu. Bez licencji obrazy również zawierają znak wodny oceny; zobacz [Licensing](/slides/pl/nodejs-net/licensing/).

## **Konwertuj slajd na obraz o określonym rozmiarze**

`getImageWithImageSize` przyjmuje obiekt z `width` i `height` w pikselach. Poniższy przykład renderuje pierwszy slajd o szerokości 1280 pikseli i wylicza wysokość na podstawie rozmiaru slajdu, tak aby obraz zachował proporcje slajdu:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

const imageWidth = 1280;

const presentation = new Presentation("sample.pptx");
try {
    const slideSize = presentation.slideSize.size;
    const imageHeight = Math.round(imageWidth * slideSize.height / slideSize.width);

    const slide = presentation.slides.get(0);
    const image = slide.getImageWithImageSize({ width: imageWidth, height: imageHeight });
    try {
        image.save("slide_1_1280px.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
    console.log(`Saved a ${imageWidth} x ${imageHeight} image`);
} finally {
    presentation.dispose();
}
```

Właściwość [slideSize.size](https://reference.aspose.com/slides/net/aspose.slides/slidesize/size/) zwraca szerokość i wysokość slajdu w punktach. Dla prezentacji 16:9 skrypt wypisuje `Saved a 1280 x 720 image` i zapisuje `slide_1_1280px.png`; dla prezentacji 4:3 obraz ma 1280 × 960 pikseli.

## **FAQ**

**Dlaczego obraz zwrócony przez `getImage` bez argumentów jest tak mały?**

Bez argumentów `getImage` renderuje slajd w 20 % jego rozmiaru w punktach, więc slajd 960 × 540 punktów staje się obrazem 192 × 108 pikseli. Użyj `getImageWithScale` lub `getImageWithImageSize`, aby wybrać rozmiar.

**Jak zapisać obraz w formacie JPEG lub innym?**

Przekaż inną wartość `ImageFormat` do metody `save` obrazu, na przykład `image.save("slide_1.jpg", ImageFormat.Jpeg)`. Format pochodzi z wartości `ImageFormat`, a nie z rozszerzenia pliku, więc zachowaj ich spójność.

**Dlaczego tekst na obrazach wygląda inaczej w systemie Linux?**

Aspose.Slides może używać tylko czcionek zainstalowanych na maszynie renderującej slajdy. Gdy prezentacja używa czcionki, której brakuje, np. Calibri na typowym serwerze Linux, Aspose.Slides używa zainstalowanej czcionki zamiast niej, co może zmienić wygląd tekstu i miejsce podziału linii. Zainstaluj czcionki używane w prezentacjach, aby uzyskać takie same obrazy jak w systemie Windows.

**Dlaczego `getThumbnailWithImageSize` kończy się TypeError?**

README pakietu używa `getThumbnailWithImageSize`, ale pakiet nie posiada metod `getThumbnail`. Użyj zamiast tego `getImageWithImageSize`; przyjmuje on ten sam argument `{ width, height }`.