---
title: Konvertera PowerPoint-presentationer till Markdown i JavaScript
linktitle: PowerPoint till Markdown
type: docs
weight: 140
url: /sv/nodejs-java/convert-powerpoint-to-markdown/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- konvertera PPTX
- PowerPoint till MD
- presentation till MD
- bild till MD
- PPT till MD
- PPTX till MD
- spara PowerPoint som Markdown
- spara presentation som Markdown
- spara bild som Markdown
- spara PPT som MD
- spara PPTX som MD
- exportera PPT till MD
- exportera PPTX till MD
- Markdown-bildexport
- CDN-bildlänkar
- PowerPoint
- presentation
- Markdown
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertera PPT- och PPTX-presentationer till Markdown i JavaScript och kontrollera var exporterade bitmap-, metafil- och SVG-bilder sparas och refereras."
---
## **Översikt**

Aspose.Slides för Node.js via Java kan konvertera PPT‑ och PPTX‑presentationer till Markdown för dokumentation, statiska webbplatser, innehållsmigration och versionskontroll‑arbetsflöden. Du kan välja en Markdown‑smak, styra hur bildinnehåll renderas och bestämma var exporterade bilder lagras samt hur den genererade Markdownen refererar till dem.

Som standard använder Markdown‑exporten text‑endast‑utdata. För att exportera visuellt innehåll, ange exporttypen med metoden [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/markdownsaveoptions/) till `Sequential` eller `Visual` från enumen [MarkdownExportType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/markdownexporttype/). `Sequential` renderar bildobjekt separat och i ordning, medan `Visual` behåller grupperade objekt tillsammans för att bevara deras visuella relation. Värdet `TextOnly` avger inte bildresurser, så bild‑sparande‑återuppringningar anropas inte i det läget.

## **Konvertera en presentation till Markdown**

Ladda källfilen med klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) och anropa sedan metoden [Presentation.save](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) med värdet `Md` från enumen [SaveFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/saveformat/).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", aspose.slides.SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Välj en Markdown‑smak**

Metoden [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/markdownsaveoptions/) styr vilken Markdown‑specifikation som används för utdata. Enumen [Flavor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/flavor/) innehåller CommonMark, GitHub Flavored Markdown och andra stödda varianter.

Följande exempel exporterar en presentation som CommonMark:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setFlavor(aspose.slides.Flavor.CommonMark);

    presentation.save("presentation.md", aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **Exportera bilder med standardbeteende för lokalt sparande**

Klassen [MarkdownSaveOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/markdownsaveoptions/) tillhandahåller två metoder för att konfigurera lokalt sparade bilder:

- [setBasePath](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/markdownsaveoptions/) anger baskatalogen för Markdown‑dokumentet och dess resurser.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/markdownsaveoptions/) anger bildundersökatalogen. Standardvärdet är `Images`.

Följande exempel renderar visuellt innehåll, skriver bilder till `output/assets` och skapar relativa bildreferenser i Markdown‑dokumentet:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("assets");

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Detta beteende fungerar även som reserv när en anpassad bild‑sparande‑hanterare returnerar `false`.

## **Anpassa bildsparande och Markdown‑länkar**

Använd metoden [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/markdownsaveoptions/) för att registrera en återuppringning för icke‑SVG‑bitmap‑ och metafilresurser som avges under Markdown‑export. Dess `MarkdownImageSavingHandler`‑återuppringning får objektet [IImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/iimage/), dess [ImageFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imageformat/)-värde och den genererade Markdown‑länken som en en‑element‑strängarray. Spara eller ladda upp bilden med det angivna formatet och ersätt `link[0]` med den referens som ska visas i Markdown‑utdata.

Resurser som avges i SVG‑format hanteras separat. Registrera en återuppringning med metoden [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/markdownsaveoptions/). Dess `MarkdownSvgImageSavingHandler`‑återuppringning får ett `ISvgImage`‑objekt och den en‑element‑`link`‑arrayen. En SVG har inget `ImageFormat`‑argument; skriv eller ladda upp dess XML‑data via metoden `ISvgImage.getSvgData` istället. Beroende på exportläge och visuell gruppering kan en SVG i källpresentationen rasteriseras eller kombineras med annat innehåll; den resulterande icke‑SVG‑resursen skickas sedan till bild‑sparande‑återuppringningen. Registrera båda återuppringningarna när varje exporterad visuell resurs kräver egen behandling.

I Node.js skapar du implementationer av dessa återuppringnings‑gränssnitt med `java.newProxy`.

Handlerns returvärde bestämmer vem som bearbetar bilden:

- Returnera `true` när handlern har sparat, laddat upp, transformerat eller på annat sätt behandlat bilden och tilldelat ett giltigt värde till `link[0]`. Aspose.Slides skriver då det värdet till Markdown‑dokumentet och utför inte standard‑lokal‑sparning.
- Returnera `false` för att låta Aspose.Slides spara bilden lokalt och generera dess länk enligt de värden som satts med [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/markdownsaveoptions/) och [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Viktigt" %}}
En handler som returnerar `true` tar ansvar för bilden. Om den returnerar `true` utan att tilldela en giltig, icke‑tom länk, misslyckas exporten med ett `InvalidOperationException`.
{{% /alert %}}

### **Spara bilder till en CDN‑ursprungs‑katalog och använd externa URL:er**

Följande exempel behandlar `cdn-origin/presentations/quarterly-report` som en monterad eller synkroniserad CDN‑ursprungs‑katalog. Varje handler extraherar det genererade filnamnet, sparar bilden i den anpassade katalogen och ersätter den lokala referensen med en publik CDN‑URL. Själva exemplet utför ingen nätverksuppladdning: URL:en blir giltig först när katalogen är monterad som CDN‑ursprung eller dess filer publiceras till CDN. För objektlagring ersätt filsystem‑skrivet med lagrings‑SDK:ns uppladdnings‑operation och tilldela `link[0]` först efter att uppladdningen lyckats.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
const publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
const storageDirectory = path.join("cdn-origin", "presentations", "quarterly-report");
fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(storageDirectory, { recursive: true });

const getFileNameFromLink = generatedLink => {
    const urlCompatibleLink = String(generatedLink).replace(/\\/g, "/");
    return path.posix.basename(urlCompatibleLink);
};
const buildPublicUrl = fileName => publicBaseUrl + "/" + encodeURIComponent(fileName);

const imageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", {
    invoke: function(image, format, link) {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        image.save(storagePath, format);
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

const svgImageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", {
    invoke: function(svgImage, link) {
        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        fs.writeFileSync(storagePath, svgImage.getSvgData());
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("fallback-images");
    options.setImageSaving(imageSavingHandler);
    options.setSvgImageSaving(svgImageSavingHandler);

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Bitmap‑handlern returnerar avsiktligt `false` för bilder mindre än 128 × 128 pixlar, så Aspose.Slides sparar dessa bilder till `output/fallback-images` med standardbeteendet. Större bitmap‑ och metafilresurser samt SVG‑resurser hanteras av den anpassade koden. Till exempel blir en genererad lokal referens som `fallback-images/image1.png` till `https://cdn.example.com/presentations/quarterly-report/image1.png`. Handlers använder bara operativsystemets sökvägar vid filskrivning; länkar skrivna till Markdown använder framåtsnedstreck och URL‑kodade filnamn. Applicera samma regel när du bygger relativa länkar: använd `/`, inte plattforms‑specifika katalogseparatorer.

## **Vanliga frågor**

**Kan en handler behandla både raster‑bilder och SVG‑bilder?**

Nej. Använd [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/markdownsaveoptions/) för bitmap‑ och metafilresurser samt [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/markdownsaveoptions/) för resurser som avges som SVG. Den förstnämnda levererar ett [IImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/iimage/)-objekt och ett [ImageFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imageformat/)-värde; den senare levererar ett `ISvgImage`‑objekt vars SVG‑data kan läsas med `ISvgImage.getSvgData`. En käll‑SVG som rasteriseras under export behandlas av bild‑sparande‑återuppringningen istället.

**Vad händer när en bild‑sparande‑handler returnerar `false`?**

Aspose.Slides använder sitt standard‑beteende för lokalt sparande. Bildens plats och den genererade referensen styrs av de värden som satts med [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/markdownsaveoptions/) och [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/markdownsaveoptions/).

**Kan en handler tillhandahålla en URL utan att spara bilden lokalt?**

Ja. Handlern kan ladda upp bilden till objektlagring eller vidarebefordra den till en annan tjänst, tilldela den resulterande URL:en till `link[0]` och returnera `true`. Handlern måste själv slutföra bearbetningen; att returnera `true` hindrar den standard‑lokala sparningen.

**Varför kastar Markdown‑export ett `InvalidOperationException` från en handler?**

Detta undantag uppstår när handlern returnerar `true` men inte tillhandahåller en giltig länk. Tilldela den relativa sökvägen eller externa URL:en som ska skrivas till Markdown innan du returnerar `true`.

**Vilken sökvägsseparator ska bild‑länkar använda?**

Använd framåtsnedstreck i Markdown‑länkar och URL:er. Använd `path.join` endast för filsystem‑sökvägar och bygg eller normalisera Markdown‑referensen separat.

**Bevaras hyperlänkar under Markdown‑export?**

Ja. Text‑[hyperlänkar](/slides/sv/nodejs-java/manage-hyperlinks/) bevaras som vanliga Markdown‑länkar. Bild‑[övergångar](/slides/sv/nodejs-java/slide-transition/) och [animationer](/slides/sv/nodejs-java/powerpoint-animation/) konverteras inte.

**Kan presentationer konverteras till Markdown parallellt?**

Du kan bearbeta olika presentationsfiler parallellt, men dela inte samma [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/)‑instans mellan trådar. Följ [multithreading guidelines](/slides/sv/nodejs-java/multithreading/) och använd en separat instans för varje fil.