---
title: Riferimento API
type: docs
weight: 50
url: /it/nodejs-net/api-reference/
description: "Aspose.Slides per Node.js via .NET è documentato dal riferimento API di Aspose.Slides per .NET. Scopri come i nomi di classi e membri .NET vengono mappati a JavaScript."
---
## **Panoramica**

Aspose.Slides for Node.js via .NET non dispone di un proprio riferimento API. Il pacchetto espone le classi di Aspose.Slides per .NET a JavaScript con gli stessi nomi, ma con nomi dei membri in camelCase, quindi il [Riferimento API Aspose.Slides per .NET](https://reference.aspose.com/slides/net/) documenta classi, membri ed enumerazioni.

## **Mappa i nomi .NET a JavaScript**

Per utilizzare un membro trovato nel riferimento API .NET, applica queste regole:

- **Le classi e le enumerazioni mantengono i loro nomi .NET**, così come i valori delle enumerazioni: `Presentation`, `ShapeType.Rectangle`, `SaveFormat.Pdf`. Importali dal pacchetto: `const { Presentation, SaveFormat } = require("aspose.slides.via.net");`.
- **Le proprietà e i metodi iniziano con una lettera minuscola.** `Presentation.Slides` diventa `presentation.slides`, e `ShapeCollection.AddAutoShape` diventa `shapes.addAutoShape`. Le proprietà rimangono proprietà: le leggi e le assegni senza parentesi.
- **Gli elementi delle collezioni si leggono con `get(index)`, e il numero di elementi con `count`**: `presentation.slides.get(0)` invece di `presentation.Slides[0]`.
- **Alcuni overload hanno nomi separati.** Per esempio, l'overload `Slide.GetImage(Size)` è `slide.getImageWithImageSize({ width, height })`. Altri condividono un unico metodo con argomenti opzionali finali: `presentation.save(path, format, options, slides)` copre diversi overload di `Presentation.Save`, e `new Presentation(null, buffer)` apre una presentazione da un `Buffer`. Ogni classe è un file nella cartella `lib` del pacchetto (ad esempio, `node_modules/aspose.slides.via.net/lib/Slide.js`), dove puoi cercare i nomi esatti.
- **Rilascia le presentazioni con `dispose`** quando hai finito; JavaScript non ha l'istruzione `using`.

Il pacchetto non avvolge ogni membro .NET. Se un membro del riferimento API .NET manca dal file della classe, non è disponibile in JavaScript.

## **Esempio**

Lo script seguente utilizza le regole sopra. Ogni commento mostra la chiamata .NET corrispondente alla riga successiva. Aggiunge un rettangolo con testo alla prima diapositiva, rende la diapositiva come immagine PNG 960 × 540 pixel e salva la presentazione come PDF. Eseguilo da una cartella di progetto dove il pacchetto è installato come descritto in [Installazione](/slides/it/nodejs-net/installation/).

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

Lo script scrive `slide.png` e `slide.pdf` nella cartella corrente. Entrambi mostrano il rettangolo con il suo testo. Senza licenza, mostrano anche una filigrana di valutazione; vedi [Licenza](/slides/it/nodejs-net/licensing/).

Per dettagli sui membri usati qui, consulta [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/), [TextFrame.Text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/) e [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) nel Riferimento API Aspose.Slides per .NET.