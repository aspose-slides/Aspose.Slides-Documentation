---
title: Konvertera PowerPoint-presentationer till Markdown i C++
linktitle: PowerPoint till Markdown
type: docs
weight: 140
url: /sv/cpp/convert-powerpoint-to-markdown/
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
- C++
- Aspose.Slides
description: "Konvertera PowerPoint-bilder—PPT, PPTX—till ren Markdown med Aspose.Slides för C++, automatisera dokumentation och behåll formatering."
---
## **Introduktion**

Aspose.Slides låter dig konvertera PowerPoint‑presentationer till Markdown, vilket kan vara användbart för dokumentationsarbetsflöden, statisk webbplatsgenerering, innehållsmigrering och versionskontrollerad textpublicering. API:et stöder direktexport från PPT‑ och PPTX‑presentationer till MD‑filer och erbjuder ytterligare alternativ för att styra hur bildinnehåll representeras i det resulterande Markdown‑dokumentet.

Du kan exportera presentationer som ren Markdown, välja mellan flera Markdown‑varianter såsom CommonMark och GitHub Flavored Markdown, samt konfigurera hur bilder hanteras under export. För presentationer som innehåller visuellt innehåll låter Aspose.Slides dig också spara bilder till en separat mapp och referera till dem från den genererade Markdown‑filen.

{{% alert color="warning" %}} 

Export av PowerPoint till markdown är **utan bilder** som standard. Om du vill exportera ett PowerPoint‑dokument som innehåller bilder måste du sätta `SaveOptions::MarkdownExportType::Visual)` och också ange `BasePath` där bilderna som refereras i markdown‑dokumentet kommer att sparas.

{{% /alert %}} 

## **Konvertera PowerPoint till Markdown**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) för att representera ett presentationsobjekt.
2. Använd metoden [Save](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method) för att spara objektet som en markdown‑fil.

Den här C++‑koden visar hur du konverterar PowerPoint till markdown:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```

## **Konvertera PowerPoint till Markdown‑variant**

Aspose.Slides låter dig konvertera PowerPoint till markdown (med grundläggande syntax), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab och 17 andra markdown‑varianter.

Den här C++‑koden visar hur du konverterar PowerPoint till CommonMark: 

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```

De 23 stödda markdown‑varianterna är [listade under Flavor‑enumerationen](https://reference.aspose.com/slides/sv/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) från klassen [MarkdownSaveOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Konvertera en presentation som innehåller bilder till Markdown**

Klassen [MarkdownSaveOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) tillhandahåller egenskaper och enumerationer som låter dig använda vissa alternativ eller inställningar för den resulterande markdown‑filen. Enumerationen [MarkdownExportType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) kan exempelvis sättas till värden som bestämmer hur bilder renderas eller hanteras: `Sequential`, `TextOnly`, `Visual`.

### **Konvertera bilder sekventiellt**

Om du vill att bilderna ska visas en efter en i den resulterande markdown‑filen måste du välja det sekventiella alternativet. Den här C++‑koden visar hur du konverterar en presentation som innehåller bilder till markdown:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<MarkdownSaveOptions> markdownSaveOptions = System::MakeObject<MarkdownSaveOptions>();

markdownSaveOptions->set_ShowHiddenSlides(true);
markdownSaveOptions->set_ShowSlideNumber(true);
markdownSaveOptions->set_Flavor(Flavor::Github);
markdownSaveOptions->set_ExportType(MarkdownExportType::Sequential);
markdownSaveOptions->set_NewLineType(NewLineType::Windows);

pres->Save(u"doc.md", System::MakeArray<int32_t>({1, 2, 3, 4, 5, 6, 7, 8, 9}), SaveFormat::Md, markdownSaveOptions);
```

### **Konvertera bilder visuellt**

Om du vill att bilderna ska visas tillsammans i den resulterande markdown‑filen måste du välja det visuella alternativet. I så fall sparas bilderna i programmets aktuella katalog (och en relativ sökväg byggs för dem i markdown‑dokumentet), eller så kan du ange en egen sökväg och mappnamn.

Den här C++‑koden demonstrerar operationen: 

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
const System::String outPath = u"x:\\documents";
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_ExportType(Aspose::Slides::DOM::Export::Markdown::SaveOptions::MarkdownExportType::Visual);
opt->set_ImagesSaveFolderName(u"md-images");
opt->set_BasePath(outPath);
pres->Save(System::IO::Path::Combine(outPath, u"pres.md"), Aspose::Slides::Export::SaveFormat::Md, opt);
```

## **Vanliga frågor**

**Fungerar hyperlänkar efter export till Markdown?**

Ja. Text [hyperlänkar](/slides/sv/cpp/manage-hyperlinks/) bevaras som standard‑Markdown‑länkar. Bild [övergångar](/slides/sv/cpp/slide-transition/) och [animationer](/slides/sv/cpp/powerpoint-animation/) konverteras inte.

**Kan jag påskynda konverteringen genom att köra den i flera trådar?**

Du kan parallellisera över filer, men [dela inte](/slides/sv/cpp/multithreading/) samma [Presentation]‑instans över trådar. Använd separata instanser/processer per fil för att undvika konkurrens.

**Vad händer med bilder—var sparas de och är sökvägarna relativa?**

[Bilder](/slides/sv/cpp/image/) exporteras till en dedikerad mapp, och Markdown‑filen refererar till dem med relativa sökvägar som standard. Du kan konfigurera den grundläggande utmatningssökvägen och asset‑mappnamnet för att behålla en förutsägbar arkivstruktur.