---
title: "Reference API"
type: docs
weight: 50
url: /cs/nodejs-net/api-reference/
description: "Aspose.Slides pro Node.js přes .NET je dokumentováno pomocí referenčního API Aspose.Slides pro .NET. Podívejte se, jak se názvy tříd a členů .NET mapují na JavaScript."
---
## **Přehled**

Aspose.Slides for Node.js via .NET nemá vlastní referenci API. Balíček zpřístupňuje třídy Aspose.Slides pro .NET v JavaScriptu pod stejnými názvy, s názvy členů v camelCase, takže [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/) dokumentuje jeho třídy, členy a výčty.

## **Mapování názvů .NET na JavaScript**

Pro použití členu, který najdete v referenci API .NET, použijte tato pravidla:

- **Třídy a výčty si zachovávají své názvy .NET**, stejně jako hodnoty výčtů: `Presentation`, `ShapeType.Rectangle`, `SaveFormat.Pdf`. Importujte je z balíčku: `const { Presentation, SaveFormat } = require("aspose.slides.via.net");`.
- **Vlastnosti a metody začínají malým písmenem.** `Presentation.Slides` se mění na `presentation.slides` a `ShapeCollection.AddAutoShape` na `shapes.addAutoShape`. Vlastnosti zůstávají vlastnostmi: čtete je a přiřazujete bez závorek.
- **Položky kolekcí se čtou pomocí `get(index)`**, a počet položek pomocí `count`: `presentation.slides.get(0)` místo `presentation.Slides[0]`.
- **Některé přetížení mají samostatné názvy.** Například přetížení `Slide.GetImage(Size)` je `slide.getImageWithImageSize({ width, height })`. Ostatní sdílejí jednu metodu s volitelnými koncovými argumenty: `presentation.save(path, format, options, slides)` pokrývá několik přetížení `Presentation.Save` a `new Presentation(null, buffer)` otevře prezentaci z `Buffer`. Každá třída je v jednom souboru ve složce `lib` balíčku (například `node_modules/aspose.slides.via.net/lib/Slide.js`), kde můžete najít přesné názvy.
- **Uvolněte prezentace pomocí `dispose`**, až s nimi skončíte; JavaScript nemá `using` příkaz.

Balíček neobaluje každý člen .NET. Pokud chybí člen z reference API .NET v souboru třídy, není v JavaScriptu k dispozici.

## **Příklad**

Následující skript používá výše uvedená pravidla. Každý komentář ukazuje volání .NET, ke kterému odpovídá následující řádek. Přidá obdélník s textem na první snímek, vykreslí snímek jako PNG obrázek o rozměrech 960 × 540 pixelů a uloží prezentaci jako PDF. Spusťte jej z adresáře projektu, kde je balíček nainstalován podle [Installation](/slides/cs/nodejs-net/installation/).

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

Skript zapíše `slide.png` a `slide.pdf` do aktuálního adresáře. Oba zobrazí obdélník s jeho textem. Bez licence také zobrazí vodotisk hodnocení; viz [Licensing](/slides/cs/nodejs-net/licensing/).

Podrobnosti o zde použitých členech najdete v [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/), [TextFrame.Text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/) a [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) v referenci API Aspose.Slides pro .NET.