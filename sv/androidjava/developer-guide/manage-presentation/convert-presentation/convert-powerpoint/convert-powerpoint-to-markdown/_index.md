---
title: Konvertera PowerPoint-presentationer till Markdown på Android
linktitle: PowerPoint till Markdown
type: docs
weight: 140
url: /sv/androidjava/convert-powerpoint-to-markdown/
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
- Android
- Java
- Aspose.Slides
description: "Konvertera PowerPoint‑bilder—PPT, PPTX—till ren Markdown med Aspose.Slides för Android via Java, automatisera dokumentation och behålla formatering."
---
## **Introduktion**

Aspose.Slides låter dig konvertera PowerPoint-presentationer till Markdown, vilket kan vara användbart för dokumentationsarbetsflöden, generering av statiska webbplatser, innehållsmigrering och versionskontrollerad textpublicering. API:et stöder direkt export från PPT- och PPTX-presentationer till MD-filer och ger ytterligare alternativ för att styra hur bildinnehåll representeras i det resulterande Markdown-dokumentet.

Du kan exportera presentationer som ren Markdown, välja mellan flera Markdown-varianter såsom CommonMark och GitHub Flavored Markdown, och konfigurera hur bilder hanteras under export. För presentationer som innehåller visuellt innehåll låter Aspose.Slides dig också spara bilder i en separat mapp och referera till dem från den genererade Markdown-filen.

Aspose.Slides stöder konvertering från presentation till markdown.

{{% alert color="warning" %}} 

Export av PowerPoint till markdown är **utan bilder** som standard. Om du vill exportera ett PowerPoint-dokument som innehåller bilder måste du ange `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` och även ange `BasePath` där bilderna som refereras i markdown-dokumentet kommer att sparas.

{{% /alert %}} 

## **Konvertera PowerPoint till Markdown**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/) för att representera ett presentationsobjekt.
2. Använd metoden [Spara](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) för att spara objektet som en markdown-fil.

Denna Java‑kod visar hur du konverterar PowerPoint till markdown:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Konvertera PowerPoint till Markdown‑variant**

Aspose.Slides låter dig konvertera PowerPoint till markdown (med grundläggande syntax), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab och 17 andra markdown‑varianter.

Denna Java‑kod visar hur du konverterar PowerPoint till CommonMark:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(Flavor.CommonMark);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

De 23 stödda markdown‑varianterna är [listade under Flavor‑enumeration](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/flavor/) från klassen [MarkdownSaveOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/markdownsaveoptions/).

## **Konvertera en presentation som innehåller bilder till Markdown**

Klassen [MarkdownSaveOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/markdownsaveoptions/) tillhandahåller egenskaper och uppräkningar som låter dig använda vissa alternativ eller inställningar för den resulterande markdown‑filen. Enumerationen [MarkdownExportType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/markdownexporttype/) kan exempelvis sättas till värden som bestämmer hur bilder renderas eller hanteras: `Sequential`, `TextOnly`, `Visual`.

### **Konvertera bilder sekventiellt**

Om du vill att bilderna ska visas individuellt, en efter en, i den resulterande markdownen måste du välja det sekventiella alternativet. Denna Java‑kod visar hur du konverterar en presentation som innehåller bilder till markdown:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(Flavor.Github);
    markdownSaveOptions.setExportType(MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(NewLineType.Windows);
    pres.save("doc.md", new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Konvertera bilder visuellt**

Om du vill att bilderna ska visas tillsammans i den resulterande markdownen måste du välja det visuella alternativet. I så fall sparas bilderna i applikationens aktuella katalog (och en relativ sökväg byggs för dem i markdown‑dokumentet), eller så kan du ange en egen sökväg och mappnamn.

Denna Java‑kod demonstrerar operationen:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    final String outPath = "c:/documents";
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setExportType(MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Behåller hyperlänkar exporten till Markdown?**

Ja. Text‑[hyperlinks](/slides/sv/androidjava/manage-hyperlinks/) bevaras som vanliga Markdown‑länkar. Bild‑[transitions](/slides/sv/androidjava/slide-transition/) och [animations](/slides/sv/androidjava/powerpoint-animation/) konverteras inte.

**Kan jag påskynda konverteringen genom att köra den i flera trådar?**

Du kan parallellisera över filer, men [don’t share](/slides/sv/androidjava/multithreading/) samma [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/)‑instans över trådar. Använd separata instanser/processer per fil för att undvika konkurrens.

**Vad händer med bilderna—var sparas de och är sökvägarna relativa?**

[Images](/slides/sv/androidjava/image/) exporteras till en dedikerad mapp, och Markdown‑filen refererar dem med relativa sökvägar som standard. Du kan konfigurera den grundläggande utsökvägen och namn på tillgångsmappen för att behålla en förutsägbar repositorie‑struktur.