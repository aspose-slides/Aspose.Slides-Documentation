---
title: API-referens
type: docs
weight: 50
url: /sv/nodejs-net/api-reference/
description: "Aspose.Slides för Node.js via .NET dokumenteras av Aspose.Slides för .NET API-referensen. Se hur .NET-klass- och medlemsnamn mappar till JavaScript."
---
## **Översikt**

Aspose.Slides för Node.js via .NET har ingen egen API‑referens. Paketet exponerar klasserna i Aspose.Slides för .NET till JavaScript under samma namn, med camelCase‑medlemmar, så [Aspose.Slides för .NET API‑referens](https://reference.aspose.com/slides/sv/net/) dokumenterar dess klasser, medlemmar och uppräkningar.

## **Mappa .NET‑namn till JavaScript**

- **Klasser och uppräkningar behåller sina .NET‑namn**, och detsamma gäller uppräkningsvärden: `Presentation`, `ShapeType.Rectangle`, `SaveFormat.Pdf`. Importera dem från paketet: `const { Presentation, SaveFormat } = require("aspose.slides.via.net");`.
- **Egenskaper och metoder börjar med en liten bokstav.** `Presentation.Slides` blir `presentation.slides`, och `ShapeCollection.AddAutoShape` blir `shapes.addAutoShape`. Egenskaper förblir egenskaper: du läser och tilldelar dem utan parenteser.
- **Samlingsobjekt läses med `get(index)`**, och antalet objekt med `count`: `presentation.slides.get(0)` istället för `presentation.Slides[0]`.
- **Vissa överlagringar får separata namn.** Till exempel är `Slide.GetImage(Size)`‑överlagringen `slide.getImageWithImageSize({ width, height })`. Andra delar en metod med valfria efterföljande argument: `presentation.save(path, format, options, slides)` täcker flera `Presentation.Save`‑överlagringar, och `new Presentation(null, buffer)` öppnar en presentation från en `Buffer`. Varje klass är en fil under paketets `lib`‑mapp (t.ex. `node_modules/aspose.slides.via.net/lib/Slide.js`), där du kan slå upp de exakta namnen.
- **Frigör presentationer med `dispose`** när du är klar med dem; JavaScript har ingen `using`‑sats.

Paketet omsluter inte varje .NET‑medlem. Om en medlem från .NET‑API‑referensen saknas i klassfilen är den inte tillgänglig i JavaScript.

## **Exempel**

Följande skript använder reglerna ovan. Varje kommentar visar .NET‑anropet som nästa rad motsvarar. Det lägger till en rektangel med text på den första bilden, renderar bilden som en 960 × 540‑pixel PNG‑bild och sparar presentationen som PDF. Kör det från en projektmapp där paketet är installerat enligt [Installation](/slides/sv/nodejs-net/installation/).

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

Skriptet skriver `slide.png` och `slide.pdf` till den aktuella mappen. Båda visar rektangeln med dess text. Utan licens visar de också ett evaluerings‑vattenstämpel; se [Licensiering](/slides/sv/nodejs-net/licensing/).

För detaljer om de medlemmar som används här, se [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/), [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/shapecollection/addautoshape/), [TextFrame.Text](https://reference.aspose.com/slides/sv/net/aspose.slides/textframe/text/) och [Slide.GetImage](https://reference.aspose.com/slides/sv/net/aspose.slides/slide/getimage/) i Aspose.Slides för .NET API‑referensen.