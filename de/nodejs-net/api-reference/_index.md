---
title: API-Referenz
type: docs
weight: 50
url: /de/nodejs-net/api-reference/
description: "Aspose.Slides für Node.js via .NET wird durch die Aspose.Slides für .NET API-Referenz dokumentiert. Sehen Sie, wie .NET-Klassen- und Membernamen auf JavaScript abgebildet werden."
---
## **Überblick**

Aspose.Slides for Node.js via .NET verfügt über keine eigene API‑Referenz. Das Paket stellt die Klassen von Aspose.Slides for .NET JavaScript unter denselben Namen zur Verfügung, wobei die Mitgliedsnamen in camelCase vorliegen, sodass die [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/) ihre Klassen, Member und Aufzählungen dokumentiert.

## **Zuordnung von .NET-Namen zu JavaScript**

Um ein Mitglied zu verwenden, das Sie in der .NET‑API‑Referenz finden, wenden Sie folgende Regeln an:

- **Klassen und Aufzählungen behalten ihre .NET-Namen bei**, und das gilt auch für Aufzählungswerte: `Presentation`, `ShapeType.Rectangle`, `SaveFormat.Pdf`. Importieren Sie sie aus dem Paket: `const { Presentation, SaveFormat } = require("aspose.slides.via.net");`.
- **Eigenschaften und Methoden beginnen mit einem Kleinbuchstaben.** `Presentation.Slides` wird zu `presentation.slides` und `ShapeCollection.AddAutoShape` zu `shapes.addAutoShape`. Eigenschaften bleiben Eigenschaften: Sie lesen und setzen sie ohne Klammern.
- **Sammlungselemente werden mit `get(index)` gelesen**, und die Anzahl der Elemente mit `count`: `presentation.slides.get(0)` anstelle von `presentation.Slides[0]`.
- **Einige Überladungen erhalten separate Namen.** Zum Beispiel lautet die Überladung `Slide.GetImage(Size)` `slide.getImageWithImageSize({ width, height })`. Andere teilen sich eine Methode mit optionalen nachfolgenden Argumenten: `presentation.save(path, format, options, slides)` deckt mehrere `Presentation.Save`‑Überladungen ab, und `new Presentation(null, buffer)` öffnet eine Präsentation aus einem `Buffer`. Jede Klasse ist eine Datei im `lib`‑Ordner des Pakets (z. B. `node_modules/aspose.slides.via.net/lib/Slide.js`), wo Sie die genauen Namen nachschlagen können.
- **Freigeben von Präsentationen mit `dispose`**, wenn Sie sie nicht mehr benötigen; JavaScript hat keine `using`‑Anweisung.

Das Paket kapselt nicht jedes .NET‑Mitglied. Fehlt ein Mitglied aus der .NET‑API‑Referenz in der Klassendatei, ist es in JavaScript nicht verfügbar.

## **Beispiel**

Das folgende Skript verwendet die oben genannten Regeln. Jeder Kommentar zeigt den .NET‑Aufruf, dem die nächste Zeile entspricht. Es fügt der ersten Folie ein Rechteck mit Text hinzu, rendert die Folie als 960 × 540‑Pixel‑PNG‑Bild und speichert die Präsentation als PDF. Führen Sie es aus einem Projektordner aus, in dem das Paket wie in [Installation](/slides/de/nodejs-net/installation/) beschrieben installiert ist.

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

Das Skript schreibt `slide.png` und `slide.pdf` in den aktuellen Ordner. Beide zeigen das Rechteck mit seinem Text. Ohne Lizenz wird zudem ein Evaluations‑Wasserzeichen angezeigt; siehe [Licensing](/slides/de/nodejs-net/licensing/).

Für Details zu den hier verwendeten Mitgliedern siehe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/), [TextFrame.Text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/) und [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) in der Aspose.Slides for .NET API reference.