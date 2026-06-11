---
title: Konvertera PowerPoint-presentationer till Markdown i PHP
linktitle: PowerPoint till Markdown
type: docs
weight: 140
url: /sv/php-java/convert-powerpoint-to-markdown/
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
- PHP
- Aspose.Slides
description: "Konvertera PowerPoint-bilder — PPT, PPTX — till ren Markdown med Aspose.Slides för PHP via Java, automatisera dokumentation och behåll formatering."
---
## **Introduktion**

Aspose.Slides låter dig konvertera PowerPoint‑presentationer till Markdown, vilket kan vara användbart för dokumentationsarbetsflöden, statisk webbplatsgenerering, innehållsmigrering och versionskontrollerad textpublicering. API:et stöder direkt export från PPT‑ och PPTX‑presentationer till MD‑filer och erbjuder ytterligare alternativ för att kontrollera hur bildinnehåll representeras i det resulterande Markdown‑dokumentet.

Du kan exportera presentationer som ren Markdown, välja mellan flera Markdown‑varianter såsom CommonMark och GitHub Flavored Markdown, samt konfigurera hur bilder hanteras under export. För presentationer som innehåller visuellt innehåll låter Aspose.Slides även dig spara bilder i en separat mapp och referera till dem från den genererade Markdown‑filen.

{{% alert color="warning" %}}
PowerPoint‑till‑Markdown‑export är **utan bilder** som standard. Om du vill exportera ett PowerPoint‑dokument som innehåller bilder måste du ange `ExportType = MarkdownExportType::Visual` och specificera `BasePath`, där bilderna som refereras i Markdown‑dokumentet kommer att sparas.
{{% /alert %}}

## **Konvertera en presentation till Markdown**

Detta avsnitt förklarar hur Aspose.Slides konverterar PowerPoint‑ och OpenDocument‑presentationer (PPT, PPTX, ODP) till ren Markdown, samtidigt som den ursprungliga bildhierarkin, texten och den grundläggande formateringen bevaras så att du kan återanvända innehållet i dokumentation eller versionskontrollerade arbetsflöden utan extra manuellt arbete.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) för att representera presentationen.
1. Använd metoden [save](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#save) för att exportera den som en Markdown‑fil.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.md", SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **Konvertera en presentation till Markdown‑variant**

Aspose.Slides låter dig konvertera PowerPoint‑presentationer till Markdown med grundläggande syntax, samt till CommonMark, GitHub‑flavored Markdown, Trello, XWiki, GitLab och sjutton andra Markdown‑varianter.

Följande PHP‑kod demonstrerar hur man konverterar en PowerPoint‑presentation till CommonMark:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setFlavor(Flavor->CommonMark);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

De 23 stödda Markdown‑varianterna listas i [Flavor‑enumerationen](https://reference.aspose.com/slides/sv/php-java/aspose.slides/flavor/).

## **Konvertera en presentation som innehåller bilder till Markdown**

Klassen [MarkdownSaveOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/markdownsaveoptions/) exponerar egenskaper och enumerationer som låter dig konfigurera den resulterande Markdown‑filen. Till exempel specificerar enumerationen [MarkdownExportType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/markdownexporttype/) hur bilder hanteras: `Sequential`, `TextOnly` eller `Visual`.

{{% alert color="warning" %}}
Som standard inkluderar PowerPoint‑till‑Markdown‑export **inte bilder**. För att bädda in bilder, anropa `markdownSaveOptions.setExportType(MarkdownExportType::Visual)` och ange `BasePath` som specificerar var bilderna som refereras i Markdown‑filen kommer att sparas.
{{% /alert %}}

### **Konvertera bilder sekventiellt**

Om du vill att bilderna ska visas individuellt, en efter en, i den resulterande Markdown‑filen måste du välja alternativet `Sequential`. Följande PHP‑kod visar hur du konverterar en presentation som innehåller bilder till Markdown:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setShowHiddenSlides(true);
    $saveOptions->setShowSlideNumber(true);
    $saveOptions->setFlavor(Flavor->Github);
    $saveOptions->setExportType(MarkdownExportType::Sequential);
    $saveOptions->setNewLineType(NewLineType::Windows);

    $slideIndices = array(1, 2, 3, 4);
    $presentation->save("presentation.md", $slideIndices, SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

### **Konvertera bilder visuellt**

Om du vill att bilderna ska visas tillsammans i den resulterande Markdown‑filen måste du välja alternativet `Visual`. I så fall sparas bilderna i applikationens aktuella katalog (och en relativ sökväg genereras för dem i Markdown‑dokumentet), eller så kan du ange den föredragna katalogen och mappnamnet.

Följande PHP‑kod demonstrerar operationen:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $outPath = "c:/documents";

    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setExportType(MarkdownExportType::Visual);
    $saveOptions->setImagesSaveFolderName("md-images");
    $saveOptions->setBasePath($outPath);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Behåller hyperlänkar exporten till Markdown?**

Ja. Text [hyperlinks](/slides/sv/php-java/manage-hyperlinks/) bevaras som standard‑Markdown‑länkar. Bild[transitions](/slides/sv/php-java/slide-transition/) och [animations](/slides/sv/php-java/powerpoint-animation/) konverteras inte.

**Kan jag påskynda konverteringen genom att köra den i flera trådar?**

Du kan parallellisera över filer, men [don’t share](/slides/sv/php-java/multithreading/) samma [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/)‑instans över trådar. Använd separata instanser/processer per fil för att undvika konkurrens.

**Vad händer med bilder—var sparas de och är sökvägarna relativa?**

[Images](/slides/sv/php-java/image/) exporteras till en dedikerad mapp, och Markdown‑filen refererar till dem med relativa sökvägar som standard. Du kan konfigurera den grundläggande utmatningssökvägen och mappnamnet för resurser för att behålla en förutsägbar repositoriesstruktur.