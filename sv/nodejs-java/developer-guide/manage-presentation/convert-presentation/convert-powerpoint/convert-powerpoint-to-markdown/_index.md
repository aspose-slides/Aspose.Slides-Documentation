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
- PowerPoint
- presentation
- Markdown
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertera PowerPoint-bilder i JavaScript—PPT, PPTX—till ren Markdown med Aspose.Slides för Node.js via Java, automatisera dokumentation och behåll formatering."
---
## **Introduktion**

Aspose.Slides låter dig konvertera PowerPoint-presentationer till Markdown, vilket kan vara användbart för dokumentationsarbetsflöden, statisk webbplatsgenerering, innehållsmigrering och versionskontrollerad textpublicering. API:et stöder direkt export från PPT- och PPTX-presentationer till MD-filer och erbjuder ytterligare alternativ för att styra hur bildinnehåll representeras i det resulterande Markdown-dokumentet.

Du kan exportera presentationer som ren Markdown, välja mellan flera Markdown-varianter såsom CommonMark och GitHub Flavored Markdown, och konfigurera hur bilder hanteras under export. För presentationer som innehåller visuellt innehåll låter Aspose.Slides dig även spara bilder i en separat mapp och referera till dem från den genererade Markdown-filen.

{{% alert color="warning" %}} 
PowerPoint‑till‑Markdown‑export är **utan bilder** som standard. Om du vill exportera ett PowerPoint‑dokument som innehåller bilder måste du anropa `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` och även ange `BasePath` där bilderna som refereras i Markdown‑dokumentet kommer att sparas.
{{% /alert %}} 

## **Konvertera PowerPoint till Markdown**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) för att representera ett presentationsobjekt.
2. Använd metoden [save](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#save-aspose.slides.IXamlOptions-) för att spara objektet som en markdown‑fil.

JavaScript‑koden visar hur du konverterar PowerPoint till markdown:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.md", aspose.slides.SaveFormat.Md);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Konvertera PowerPoint till Markdown‑variant**

Aspose.Slides låter dig konvertera PowerPoint till markdown (med grundläggande syntax), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab och 17 andra markdown‑varianter.

JavaScript‑koden visar hur du konverterar PowerPoint till CommonMark:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.CommonMark);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

De 23 stödda markdown‑varianterna är [listade under Flavor‑enumerationen](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/flavor/) från klassen [MarkdownSaveOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/markdownsaveoptions/).

## **Konvertera presentation med bilder till Markdown**

Klassen [MarkdownSaveOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/markdownsaveoptions/) tillhandahåller egenskaper och enumerationer som låter dig använda vissa alternativ eller inställningar för den resulterande markdown‑filen. Enumerationen [MarkdownExportType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/markdownexporttype/) kan t.ex. sättas till värden som bestämmer hur bilder renderas eller hanteras: `Sequential`, `TextOnly`, `Visual`.

### **Konvertera bilder sekventiellt**

Om du vill att bilderna ska visas individuellt, en efter en, i den resulterande markdown‑filen måste du välja det sekventiella alternativet. Denna JavaScript‑kod visar hur du konverterar en presentation med bilder till markdown:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.Github);
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(aspose.slides.NewLineType.Windows);
    pres.save("doc.md", java.newArray("int", [1, 2, 3, 4, 5, 6, 7, 8, 9]), aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Konvertera bilder visuellt**

Om du vill att bilderna ska visas tillsammans i den resulterande markdown‑filen måste du välja det visuella alternativet. I så fall sparas bilderna i applikationens aktuella katalog (och en relativ sökväg byggs för dem i markdown‑dokumentet), eller så kan du ange en egen sökväg och mappnamn.

Denna JavaScript‑kod demonstrerar operationen:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    final var outPath = "c:/documents";
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Vanliga frågor**

**Behåller hyperlänkar exporten till Markdown?**

Ja. Text-[hyperlänkar](/slides/sv/nodejs-java/manage-hyperlinks/) bevaras som vanliga Markdown‑länkar. Bild-[övergångar](/slides/sv/nodejs-java/slide-transition/) och [animationer](/slides/sv/nodejs-java/powerpoint-animation/) konverteras inte.

**Kan jag påskynda konverteringen genom att köra den i flera trådar?**

Du kan parallellisera över filer, men [dela inte](/slides/sv/nodejs-java/multithreading/) samma [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/)‑instans över trådar. Använd separata instanser/processer per fil för att undvika konkurrens.

**Vad händer med bilder—var sparas de och är sökvägarna relativa?**

[Bilder](/slides/sv/nodejs-java/image/) exporteras till en dedikerad mapp, och Markdown‑filen refererar till dem med relativa sökvägar som standard. Du kan konfigurera bas‑utdata‑sökväg och tillgångsmappens namn för att behålla en förutsägbar lagringsstruktur.