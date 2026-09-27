---
title: Referencja API
type: docs
weight: 50
url: /pl/nodejs-net/api-reference/
description: "Aspose.Slides for Node.js via .NET jest udokumentowany w dokumentacji API Aspose.Slides for .NET. Zobacz, jak nazwy klas i członków .NET mapują się na JavaScript."
---
## **Przegląd**

Aspose.Slides for Node.js via .NET nie posiada własnej dokumentacji API. Pakiet udostępnia klasy Aspose.Slides for .NET w JavaScript pod takimi samymi nazwami, z członkami w stylu camelCase, więc [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/) opisuje jego klasy, członków i wyliczenia.

## **Mapowanie nazw .NET na JavaScript**

Aby używać członka, którego znajdziesz w dokumentacji API .NET, zastosuj następujące zasady:

- **Klasy i wyliczenia zachowują swoje nazwy .NET**, podobnie jak wartości wyliczeń: `Presentation`, `ShapeType.Rectangle`, `SaveFormat.Pdf`. Importuj je z pakietu: `const { Presentation, SaveFormat } = require("aspose.slides.via.net");`.
- **Właściwości i metody zaczynają się małą literą.** `Presentation.Slides` staje się `presentation.slides`, a `ShapeCollection.AddAutoShape` staje się `shapes.addAutoShape`. Właściwości pozostają właściwościami: odczytujesz i przypisujesz je bez nawiasów.
- **Elementy kolekcji odczytuje się metodą `get(index)`,** a liczbę elementów uzyskuje `count`: `presentation.slides.get(0)` zamiast `presentation.Slides[0]`.
- **Niektóre przeciążenia mają oddzielne nazwy.** Na przykład przeciążenie `Slide.GetImage(Size)` to `slide.getImageWithImageSize({ width, height })`. Inne współdzielą jedną metodę z opcjonalnymi argumentami: `presentation.save(path, format, options, slides)` obejmuje kilka przeciążeń `Presentation.Save`, a `new Presentation(null, buffer)` otwiera prezentację z `Buffer`. Każda klasa znajduje się w osobnym pliku w folderze `lib` pakietu (np. `node_modules/aspose.slides.via.net/lib/Slide.js`), gdzie możesz sprawdzić dokładne nazwy.
- **Zwolnij prezentacje za pomocą `dispose`**, gdy już nie są potrzebne; w JavaScript nie ma instrukcji `using`.

Pakiet nie opakowuje każdego członka .NET. Jeśli członek z dokumentacji API .NET nie znajduje się w pliku klasy, nie jest dostępny w JavaScript.

## **Przykład**

Poniższy skrypt wykorzystuje powyższe zasady. Każdy komentarz pokazuje wywołanie .NET, które odpowiada kolejnej linii. Skrypt dodaje prostokąt z tekstem do pierwszego slajdu, renderuje slajd jako obraz PNG o rozdzielczości 960 × 540 pikseli i zapisuje prezentację jako PDF. Uruchom go z katalogu projektu, w którym pakiet jest zainstalowany zgodnie z opisem w [Installation](/slides/pl/nodejs-net/installation/).

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat, ImageFormat } = asposeSlides;

const presentation = new Presentation();
try {
    // .NET: presentation.Slides[0]
    const slide = presentation.slides.get(0);

    // .NET: slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100)
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);

    // .NET: rectangle.TextFrame.Text = "..."
    rectangle.textFrame.text = "Names follow the .NET API in camelCase.";

    // .NET: slide.GetImage(new Size(960, 540))
    const slideImage = slide.getImageWithImageSize({ width: 960, height: 540 });
    slideImage.save("slide.png", ImageFormat.Png);
    slideImage.dispose();

    // .NET: presentation.Save("slide.pdf", SaveFormat.Pdf)
    presentation.save("slide.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

Skrypt zapisuje `slide.png` i `slide.pdf` w bieżącym folderze. Oba pliki pokazują prostokąt z tekstem. Bez licencji wyświetlają także znak wodny oceny; zobacz [Licensing](/slides/pl/nodejs-net/licensing/).

Po szczegółowe informacje o użytych członkach znajdziesz w [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/), [TextFrame.Text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/) oraz [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) w dokumentacji Aspose.Slides for .NET API reference.