---
title: Konvertera PowerPoint-presentationer till Markdown i .NET
linktitle: PowerPoint till Markdown
type: docs
weight: 140
url: /sv/net/convert-powerpoint-to-markdown/
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
- .NET
- C#
- Aspose.Slides
description: "Konvertera PowerPoint-bilder—PPT, PPTX—till ren Markdown med Aspose.Slides för .NET, automatisera dokumentation och behåll formateringen."
---
## **Introduktion**

Aspose.Slides låter dig konvertera PowerPoint-presentationer till Markdown, vilket kan vara användbart för dokumentationsarbetsflöden, statisk webbplatsgenerering, innehållsmigrering och versionskontrollerad textpublicering. API:et stöder direkt export från PPT- och PPTX-presentationer till MD-filer och erbjuder ytterligare alternativ för att styra hur bildinnehåll representeras i det resulterande Markdown-dokumentet.

Du kan exportera presentationer som ren Markdown, välja mellan flera Markdown-varianter såsom CommonMark och GitHub Flavored Markdown, samt konfigurera hur bilder hanteras under export. För presentationer som innehåller visuellt innehåll låter Aspose.Slides dig också spara bilder i en separat mapp och referera till dem från den genererade Markdown-filen.

{{% alert color="warning" %}}
PowerPoint‑till‑Markdown‑export är **utan bilder** som standard. Om du vill exportera ett PowerPoint‑dokument som innehåller bilder måste du sätta `ExportType = MarkdownExportType.Visual` och ange `BasePath`, där bilderna som refereras i Markdown‑dokumentet kommer att sparas.
{{% /alert %}}

## **Konvertera PowerPoint till Markdown**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) för att representera ett presentationsobjekt.  
2. Använd [Save ](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/methods/save)method för att spara objektet som en markdown‑fil.

Denna C#‑kod visar hur du konverterar PowerPoint till markdown:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```

## **Konvertera PowerPoint till Markdown‑variant**

Aspose.Slides låter dig konvertera PowerPoint till markdown (med grundläggande syntax), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab och 17 andra markdown‑varianter.

Denna C#‑kod visar hur du konverterar PowerPoint till CommonMark:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```

De 23 stödjade markdown‑varianterna är [listade under Flavor‑enumerationen](https://reference.aspose.com/slides/sv/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) från klassen [MarkdownSaveOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Konvertera en presentation som innehåller bilder till Markdown**

[MarkdownSaveOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/)-klassen tillhandahåller egenskaper och enumerationer som låter dig använda vissa alternativ eller inställningar för den resulterande markdown‑filen. [MarkdownExportType](https://reference.aspose.com/slides/sv/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/)-enumerationen kan exempelvis sättas till värden som bestämmer hur bilder renderas eller hanteras: `Sequential`, `TextOnly`, `Visual`.

### **Konvertera bilder sekventiellt**

Om du vill att bilderna ska visas en för sig i följd i den resulterande markdown‑filen måste du välja det sekventiella alternativet. Denna C#‑kod visar hur du konverterar en presentation som innehåller bilder till markdown:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions
    {
        ShowHiddenSlides = true,
        ShowSlideNumber = true,
        Flavor = Flavor.Github,
        ExportType = MarkdownExportType.Sequential,
        NewLineType = NewLineType.Windows
    };
    
    pres.Save("doc.md", new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
}
```

### **Konvertera bilder visuellt**

Om du vill att bilderna ska visas tillsammans i den resulterande markdown‑filen måste du välja det visuella alternativet. I detta fall sparas bilderna till applikationens aktuella katalog (och en relativ sökväg byggs för dem i markdown‑dokumentet), eller så kan du ange en egen sökväg och mappnamn.

Denna C#‑kod demonstrerar operationen:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    const string outPath = "c:\\documents";
    pres.Save(Path.Combine(outPath, "pres.md"), SaveFormat.Md, new MarkdownSaveOptions
    { 
        ExportType = MarkdownExportType.Visual,
        ImagesSaveFolderName = "md-images",
        BasePath = outPath
    });
}
```

## **FAQ**

**Behåller hyperlänkar exporten till Markdown?**  
Ja. Text‑[hyperlinks](/slides/sv/net/manage-hyperlinks/) bevaras som standard‑Markdown‑länkar. Bild‑[transitions](/slides/sv/net/slide-transition/) och [animations](/slides/sv/net/powerpoint-animation/) konverteras inte.

**Kan jag snabba upp konverteringen genom att köra den i flera trådar?**  
Du kan parallellisera per fil, men [don’t share](/slides/sv/net/multithreading/) samma [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)‑instans över trådar. Använd separata instanser/processer per fil för att undvika konkurrens.

**Vad händer med bilderna — var sparas de och är sökvägarna relativa?**  
[Images](/slides/sv/net/image/) exporteras till en dedikerad mapp, och Markdown‑filen refererar till dem med relativa sökvägar som standard. Du kan konfigurera den grundläggande utsökvägen och resursmappens namn för att behålla en förutsägbar repository‑struktur.