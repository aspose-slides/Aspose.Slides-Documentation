---
title: Konvertera PowerPoint-presentationer till Markdown i Java
linktitle: PowerPoint till Markdown
type: docs
weight: 140
url: /sv/java/convert-powerpoint-to-markdown/
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
- Markdown bildexport
- CDN bildlänkar
- PowerPoint
- presentation
- Markdown
- Java
- Aspose.Slides
description: "Konvertera PPT- och PPTX-presentationer till Markdown i Java och kontrollera var exporterade bitmap-, metafil- och SVG-bilder sparas och refereras."
---
## **Översikt**

Aspose.Slides for Java kan konvertera PPT- och PPTX-presentationer till Markdown för dokumentation, statiska webbplatser, innehållsmigration och versionskontrollarbetsflöden. Du kan välja en Markdown‑variant, styra hur bildinnehåll renderas och bestämma var exporterade bilder sparas samt hur den genererade Markdown‑referenser dem.

Som standard använder Markdown‑export text‑endast output. För att exportera visuellt innehåll, ange exporttypen med metoden [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/markdownsaveoptions/) till värdet `Sequential` eller `Visual` från uppräkningen [MarkdownExportType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/markdownexporttype/). `Sequential` renderar bildobjekt separat och i ordning, medan `Visual` behåller grupperade objekt tillsammans för att bevara deras visuella relation. Värdet `TextOnly` skickar inte med bildresurser, så bild‑sparnings‑callback‑funktionerna anropas inte i det läget.

## **Konvertera en presentation till Markdown**

Läs in källfilen med klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/), och anropa sedan metoden [Presentation.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/) med värdet `Md` från uppräkningen [SaveFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/saveformat/).

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Välj en Markdown‑variant**

Metoden [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/sv/java/com.aspose.slides/markdownsaveoptions/) styr vilken Markdown‑specifikation som används för utdata. Uppräkningen [Flavor](https://reference.aspose.com/slides/sv/java/com.aspose.slides/flavor/) innehåller CommonMark, GitHub Flavored Markdown och andra stödda varianter.

Följande exempel exporterar en presentation som CommonMark:

```java
import com.aspose.slides.Flavor;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setFlavor(Flavor.CommonMark);

    presentation.save("presentation.md", SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **Exportera bilder med standard lokala sparningsbeteendet**

Klassen [MarkdownSaveOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/markdownsaveoptions/) tillhandahåller två metoder för att konfigurera lokalt sparade bilder:

- [setBasePath](https://reference.aspose.com/slides/sv/java/com.aspose.slides/markdownsaveoptions/) anger baskatalogen för Markdown‑dokumentet och dess resurser.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/sv/java/com.aspose.slides/markdownsaveoptions/) anger bildundermappen. Standardvärdet är `Images`.

Följande exempel renderar visuellt innehåll, skriver bilder till `output/assets` och skapar relativa bildreferenser i Markdown‑dokumentet:

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path outputDirectory = Paths.get("output");
Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("assets");

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Detta beteende fungerar även som reserv när en anpassad bild‑sparnings‑handler returnerar `false`.

## **Anpassa bildsparning och Markdown‑länkar**

Använd metoden [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/sv/java/com.aspose.slides/markdownsaveoptions/) för att registrera en callback för icke‑SVG bitmap‑ och metafilresurser som genereras under Markdown‑export. Dess `MarkdownImageSavingHandler`‑callback får objektet [IImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimage/), dess [ImageFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imageformat/)-värde och den genererade Markdown‑länken som en en‑element `String[]`‑parameter. Spara eller ladda upp bilden med det angivna formatet och ersätt `link[0]` med referensen som ska finnas i Markdown‑utdata.

Resurser som skickas i SVG‑format hanteras separat. Registrera en callback med metoden [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/sv/java/com.aspose.slides/markdownsaveoptions/). Dess `MarkdownSvgImageSavingHandler`‑callback får ett [ISvgImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isvgimage/)-objekt och den en‑element `String[] link`‑parametern. En SVG har inget `ImageFormat`‑argument; skriv eller ladda upp dess XML‑data med metoden [ISvgImage.getSvgData](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isvgimage/) istället. Beroende på exportläge och visuell gruppering kan en SVG i källpresentationen rasteriseras eller kombineras med annat innehåll; den resulterande icke‑SVG‑resursen skickas då till bild‑sparnings‑callbacken. Registrera båda callbacks när varje exporterad visuell resurs kräver anpassad bearbetning.

Handlerns returvärde bestämmer vem som bearbetar bilden:

- Returnera `true` efter att handlern har sparat, laddat upp, transformerat eller på annat sätt bearbetat bilden och tilldelat ett giltigt värde till `link[0]`. Aspose.Slides skriver det värdet till Markdown‑dokumentet och utför inte den standardmässiga lokala sparningen.
- Returnera `false` för att låta Aspose.Slides spara bilden lokalt och generera dess länk enligt de värden som satts med [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/sv/java/com.aspose.slides/markdownsaveoptions/) och [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/sv/java/com.aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Viktigt" %}}
En handler som returnerar `true` tar ansvar för bilden. Om den returnerar `true` utan att tilldela en giltig, icke‑tom länk, misslyckas exporten med ett `InvalidOperationException`.
{{% /alert %}}

### **Spara bilder till en CDN‑ursprungs‑katalog och använd externa URL:er**

Följande exempel behandlar `cdn-origin/presentations/quarterly-report` som en monterad eller synkroniserad CDN‑ursprungs‑katalog. Varje handler extraherar det genererade filnamnet, sparar bilden i den anpassade katalogen och ersätter den genererade lokala referensen med en offentlig CDN‑URL. Exemplet utför ingen nätverksuppladdning: URL:en blir giltig först när katalogen är monterad som CDN‑ursprung eller dess filer har publicerats till CDN. För objektlagring, ersätt filsystem‑skrivningen med lagrings‑SDK:ns uppladdningsoperation och tilldela `link[0]` först efter att uppladdningen lyckats.

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.function.Function;

Path outputDirectory = Paths.get("output");
String publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
Path storageDirectory = Paths.get("cdn-origin", "presentations", "quarterly-report");
Files.createDirectories(outputDirectory);
Files.createDirectories(storageDirectory);

Function<String, String> getFileNameFromLink = generatedLink -> {
    String urlCompatibleLink = generatedLink.replace('\\', '/');
    return urlCompatibleLink.substring(urlCompatibleLink.lastIndexOf('/') + 1);
};
Function<String, String> buildPublicUrl = fileName -> {
    try {
        String encodedFileName = URLEncoder.encode(fileName, "UTF-8").replace("+", "%20");
        return publicBaseUrl + "/" + encodedFileName;
    } catch (UnsupportedEncodingException exception) {
        System.err.println("Could not encode the image file name: " + exception.getMessage());
        return null;
    }
};

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("fallback-images");

    options.setImageSaving((image, format, link) -> {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        image.save(storagePath.toString(), format);
        link[0] = publicUrl;
        return true;
    });

    options.setSvgImageSaving((svgImage, link) -> {
        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        try {
            Files.write(storagePath, svgImage.getSvgData());
        } catch (IOException exception) {
            System.err.println("Could not save the SVG image: " + exception.getMessage());
            return false;
        }
        link[0] = publicUrl;
        return true;
    });

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Bitmap‑handlern returnerar avsiktligt `false` för bilder mindre än 128 × 128 pixlar, så Aspose.Slides sparar dessa bilder till `output/fallback-images` med standardbeteendet. Större bitmap‑ och metafilresurser, liksom SVG‑resurser, hanteras av den anpassade koden. Till exempel blir en genererad lokal referens som `fallback-images/image1.png` till `https://cdn.example.com/presentations/quarterly-report/image1.png`. Handlers använder operativsystemets sökvägar endast när de skriver filer; länkar skrivna till Markdown använder snedstreck och URL‑kodade filnamn. Tillämpa samma regel när du bygger relativa länkar: använd `/`, inte plattforms‑specifika katalogseparatorer.

## **FAQ**

**Kan en handler bearbeta både rasterbilder och SVG‑bilder?**

Nej. Använd [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/sv/java/com.aspose.slides/markdownsaveoptions/) för bitmap‑ och metafilresurser som genereras och [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/sv/java/com.aspose.slides/markdownsaveoptions/) för resurser som genereras som SVG. Den förra tillhandahåller ett [IImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimage/)‑objekt och ett [ImageFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imageformat/)‑värde; den senare ger ett [ISvgImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isvgimage/)‑objekt vars SVG‑data kan läsas med [ISvgImage.getSvgData](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isvgimage/). En käll‑SVG som rasteriseras under export behandlas av bild‑sparnings‑callbacken istället.

**Vad händer när en bild‑sparnings‑handler returnerar `false`?**

Aspose.Slides använder sitt standardmässiga lokala sparningsbeteende. Bildens plats och den genererade referensen styrs av de värden som satts med [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/sv/java/com.aspose.slides/markdownsaveoptions/) och [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/sv/java/com.aspose.slides/markdownsaveoptions/).

**Kan en handler tillhandahålla en URL utan att spara bilden lokalt?**

Ja. Handlern kan ladda upp bilden till objektlagring eller skicka den till en annan tjänst, tilldela den resulterande URL:en till `link[0]` och returnera `true`. Handlern måste slutföra bearbetningen själv; att returnera `true` förhindrar den standardmässiga lokala sparningen.

**Varför kastar Markdown‑export ett `InvalidOperationException` från en handler?**

Detta undantag uppstår när handlern returnerar `true` men inte tillhandahåller en giltig länk. Tilldela den relativa sökvägen eller externa URL:en som ska skrivas till Markdown innan du returnerar `true`.

**Vilken sökvägsseparator bör bildlänkar använda?**

Använd snedstreck (`/`) i Markdown‑länkar och URL:er. Använd `Path.resolve` endast för filsystem‑sökvägar och bygg eller normalisera sedan Markdown‑referensen separat.

**Bevaras hyperlänkar under Markdown‑export?**

Ja. Text [hyperlänkar](/slides/sv/java/manage-hyperlinks/) bevaras som standard‑Markdown‑länkar. Bild [övergångar](/slides/sv/java/slide-transition/) och [animationer](/slides/sv/java/powerpoint-animation/) konverteras inte.

**Kan presentationer konverteras till Markdown parallellt?**

Du kan bearbeta olika presentationsfiler parallellt, men dela inte samma [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/)‑instans mellan trådar. Följ [multitrådningsriktlinjer](/slides/sv/java/multithreading/) och använd en separat instans för varje fil.