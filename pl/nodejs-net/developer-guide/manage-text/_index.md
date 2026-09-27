---
title: Zarządzanie tekstem prezentacji w Node.js via .NET
linktitle: Zarządzaj tekstem
type: docs
weight: 50
url: /pl/nodejs-net/manage-text/
keywords:
- tekst
- pole tekstowe
- dodaj tekst
- zmień tekst
- formatuj tekst
- rozmiar czcionki
- pogrubiony tekst
- ramka tekstowa
- akapit
- fragment
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dodaj pole tekstowe do slajdu, a następnie zmień jego tekst, rozmiar czcionki i styl pogrubienia w JavaScript przy użyciu Aspose.Slides dla Node.js via .NET."
---
## **Przegląd**

W Aspose.Slides tekst na slajdzie należy do kształtu. Automatyczny kształt, taki jak prostokąt, posiada ramkę tekstową; ramka tekstowa zawiera akapity, a każdy akapit zawiera fragmenty, które są ciągami tekstu o jednolitym formatowaniu. Tekst zmieniasz poprzez ramkę tekstową, a czcionkę poprzez format fragmentu.

Ten artykuł dodaje pole tekstowe do slajdu i zapisuje prezentację. Następnie otwiera zapisany plik i zmienia tekst pola, rozmiar czcionki oraz styl pogrubienia.

Przykłady wymagają projektu skonfigurowanego zgodnie z opisem w [Installation](/slides/pl/nodejs-net/installation/). Zapisz każdy przykład jako plik `.js` w folderze projektu i uruchom go z tego folderu poleceniem `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides dla Node.js via .NET nie posiada własnej dokumentacji API. Odzwierciedla API Aspose.Slides dla .NET przy użyciu nazw w stylu camelCase, więc linki do API w tym artykule prowadzą do odpowiadających klas i członków w [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/).
{{% /alert %}}

## **Dodaj pole tekstowe**

Aby dodać pole tekstowe, dodaj automatyczny kształt do slajdu metodą [addAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/) i nadaj mu tekst metodą [addTextFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/addtextframe/). Poniższy przykład dodaje prostokąt do pierwszego slajdu nowej prezentacji i zapisuje prezentację jako `text-box.pptx`:

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Pozycja (x, y) i rozmiar (szerokość, wysokość) są podane w punktach.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80);
    textBox.addTextFrame("Quarterly report");

    presentation.save("text-box.pptx", SaveFormat.Pptx);
    console.log("Saved text-box.pptx");
} finally {
    presentation.dispose();
}
```

Slajd w `text-box.pptx` zawiera prostokąt o szerokości 500 punktów i wysokości 80 punktów, z tekstem „Quarterly report” w domyślnej czcionce i rozmiarze. Następny przykład zmienia to pole tekstowe.

## **Zmień tekst i jego formatowanie**

Poniższy przykład otwiera `text-box.pptx`, utworzony w poprzednim przykładzie, i pobiera pierwszy kształt na pierwszym slajdzie. Kształty takie jak obrazy i tabele nie mają ramki tekstowej, więc przykład sprawdza, czy kształt jest [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) zanim użyje jego [textFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/textframe/). Następnie wykonuje następujące czynności:

1. Zastępuje tekst poprzez właściwość [text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/) ramki tekstowej. Po tym ramka tekstowa zawiera jeden akapit z jednym fragmentem.  
2. Pobiera ten fragment z kolekcji [paragraphs](https://reference.aspose.com/slides/net/aspose.slides/textframe/paragraphs/) i [portions](https://reference.aspose.com/slides/net/aspose.slides/paragraph/portions/) oraz odczytuje jego [portionFormat](https://reference.aspose.com/slides/net/aspose.slides/portion/portionformat/).  
3. Ustawia [fontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/), rozmiar czcionki w punktach, oraz [fontBold](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontbold/), które przyjmuje wartość [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/).

```javascript
const { Presentation, AutoShape, NullableBool, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("text-box.pptx");
try {
    const shape = presentation.slides.get(0).shapes.get(0);
    if (shape instanceof AutoShape) {
        const textFrame = shape.textFrame;
        textFrame.text = "Quarterly report: third quarter";

        const portionFormat = textFrame.paragraphs.get(0).portions.get(0).portionFormat;
        portionFormat.fontHeight = 32;
        portionFormat.fontBold = NullableBool.True;

        presentation.save("text-box-updated.pptx", SaveFormat.Pptx);
        console.log("Saved text-box-updated.pptx");
    } else {
        console.log("The first shape on the first slide is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

W `text-box-updated.pptx` pole tekstowe wyświetla „Quarterly report: third quarter” pogrubioną czcionką o rozmiarze 32 punkty. Ponieważ nowy tekst jest jednym fragmentem, dwie właściwości formatowania odnoszą się do całego tekstu. Bez licencji każdy zapis dodaje znak wodny ewaluacyjny. Ponieważ `text-box.pptx` został zapisany w trybie ewaluacyjnym, `text-box-updated.pptx` zawiera dwa; zobacz [Evaluate Aspose.Slides](/slides/pl/nodejs-net/evaluate-aspose-slides/).

## **FAQ**

**Dlaczego `fontBold` przyjmuje wartość `NullableBool` zamiast `true` lub `false`?**

Fragment może pozostawić właściwość niezdefiniowaną i odziedziczyć ją z akapitu, kształtu lub układu i szablonu slajdu. `NullableBool.NotDefined` oznacza „dziedzicz”, natomiast `NullableBool.True` i `NullableBool.False` nadpisują odziedziczoną wartość. Przypisanie `true` lub `false` powoduje błąd. Z tego samego powodu `fontHeight` zwraca `NaN`, gdy fragment dziedziczy rozmiar czcionki.

**Jak zmienić kolor tekstu?**

Ustaw wypełnienie formatu fragmentu: przypisz `FillType.Solid` do `portionFormat.fillFormat.fillType`, a następnie przypisz kolor, np. `"#FF0000"` do `portionFormat.fillFormat.solidFillColor.color`. Dodaj `FillType` do nazw importowanych z pakietu.

**Jak sformatować tylko część tekstu?**

Formatowanie dotyczy fragmentów, więc umieść tę część tekstu w osobnym fragmencie. Utwórz fragment za pomocą `Portion.CreatePortionFromText`, dołącz go do akapitu metodą `add` w kolekcji `portions` akapitu, a następnie ustaw `portionFormat` nowego fragmentu. Dodaj `Portion` do nazw importowanych z pakietu.

**Dlaczego odczyt tekstu zwraca "... text has been truncated due to evaluation version limitation"?**

Bez licencji Aspose.Slides zwraca tylko pierwsze pięć znaków dłuższego tekstu, który odczytujesz, np. `textFrame.text`, a następnie ten komunikat. Tekst, który zapisujesz, jest zapisywany w całości. Zastosuj licencję, jak opisano w [Licensing](/slides/pl/nodejs-net/licensing/), aby odczytać pełny tekst.