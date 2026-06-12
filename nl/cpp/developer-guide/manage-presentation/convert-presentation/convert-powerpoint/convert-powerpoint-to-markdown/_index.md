---
title: PowerPoint-presentaties omzetten naar Markdown in C++
linktitle: PowerPoint naar Markdown
type: docs
weight: 140
url: /nl/cpp/convert-powerpoint-to-markdown/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar MD
- presentatie naar MD
- dia naar MD
- PPT naar MD
- PPTX naar MD
- PowerPoint opslaan als Markdown
- presentatie opslaan als Markdown
- dia opslaan als Markdown
- PPT opslaan als MD
- PPTX opslaan als MD
- PPT exporteren naar MD
- PPTX exporteren naar MD
- PowerPoint
- presentatie
- Markdown
- C++
- Aspose.Slides
description: "Converteer PowerPoint-dia's—PPT, PPTX—naar heldere Markdown met Aspose.Slides voor C++, automatiseer documentatie en behoud de opmaak."
---
## **Introductie**

Aspose.Slides stelt u in staat PowerPoint‑presentaties naar Markdown te converteren, wat nuttig kan zijn voor documentatieworkflows, het genereren van statische sites, contentmigratie en versie‑gecontroleerde tekstpublicatie. De API ondersteunt directe export van PPT‑ en PPTX‑presentaties naar MD‑bestanden en biedt extra opties om te bepalen hoe de inhoud van dia's wordt weergegeven in het resulterende Markdown‑document.

U kunt presentaties exporteren als platte Markdown, kiezen uit meerdere Markdown‑varianten zoals CommonMark en GitHub Flavored Markdown, en configureren hoe afbeeldingen worden behandeld tijdens de export. Voor presentaties met visuele inhoud stelt Aspose.Slides u ook in staat afbeeldingen op te slaan in een aparte map en deze te refereren vanuit het gegenereerde Markdown‑bestand.

{{% alert color="warning" %}} 
PowerPoint‑naar‑Markdown‑export gebeurt standaard **zonder afbeeldingen**. Als u een PowerPoint‑document met afbeeldingen wilt exporteren, moet u `SaveOptions::MarkdownExportType::Visual)` instellen en ook de `BasePath` opgeven waar de afbeeldingen die in het Markdown‑document worden gerefereerd, worden opgeslagen.
{{% /alert %}} 

## **PowerPoint naar Markdown converteren**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse om een presentatie‑object te vertegenwoordigen.
2. Gebruik de [Save ](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method)‑methode om het object op te slaan als een markdown‑bestand.

Deze C++‑code laat zien hoe u PowerPoint naar markdown converteert:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```

## **PowerPoint naar Markdown‑variant converteren**

Aspose.Slides stelt u in staat PowerPoint naar markdown (met basale syntaxis), CommonMark, GitHub‑flavored markdown, Trello, XWiki, GitLab en 17 andere markdown‑varianten te converteren.

Deze C++‑code laat zien hoe u PowerPoint naar CommonMark converteert:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```

De 23 ondersteunde markdown‑varianten staan [vermeld onder de Flavor‑enumeratie](https://reference.aspose.com/slides/nl/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) van de [MarkdownSaveOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/)‑klasse.

## **Een presentatie met afbeeldingen naar Markdown converteren**

De [MarkdownSaveOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/)‑klasse biedt eigenschappen en enumeraties waarmee u bepaalde opties of instellingen voor het resulterende markdown‑bestand kunt gebruiken. De [MarkdownExportType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/)‑enum kan bijvoorbeeld worden ingesteld op waarden die bepalen hoe afbeeldingen worden weergegeven of verwerkt: `Sequential`, `TextOnly`, `Visual`.

### **Afbeeldingen opeenvolgend converteren**

Als u wilt dat de afbeeldingen afzonderlijk één voor één verschijnen in het resulterende markdown, moet u de opeenvolgende optie kiezen. Deze C++‑code laat zien hoe u een presentatie met afbeeldingen naar markdown converteert:

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

### **Afbeeldingen visueel converteren**

Als u wilt dat de afbeeldingen gezamenlijk verschijnen in het resulterende markdown, moet u de visuele optie kiezen. In dat geval worden de afbeeldingen opgeslagen in de huidige map van de applicatie (en wordt er een relatieve pad voor hen opgebouwd in het markdown‑document), of u kunt uw gewenste pad en mapnaam opgeven.

Deze C++‑code demonstreert de bewerking:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
const System::String outPath = u"x:\\documents";
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_ExportType(Aspose::Slides::DOM::Export::Markdown::SaveOptions::MarkdownExportType::Visual);
opt->set_ImagesSaveFolderName(u"md-images");
opt->set_BasePath(outPath);
pres->Save(System::IO::Path::Combine(outPath, u"pres.md"), Aspose::Slides::Export::SaveFormat::Md, opt);
```

## **FAQ**

**Blijven hyperlinks behouden bij export naar Markdown?**

Ja. Tekst-[hyperlinks](/slides/nl/cpp/manage-hyperlinks/) blijven behouden als standaard Markdown‑links. Dia-[overgangen](/slides/nl/cpp/slide-transition/) en -[animaties](/slides/nl/cpp/powerpoint-animation/) worden niet omgezet.

**Kan ik de conversie versnellen door deze in meerdere threads uit te voeren?**

U kunt paralleliseren per bestand, maar [deel niet](/slides/nl/cpp/multithreading/) dezelfde [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑instantie niet over threads. Gebruik afzonderlijke instanties/processen per bestand om conflicten te voorkomen.

**Wat gebeurt er met afbeeldingen—waar worden ze opgeslagen en zijn de paden relatief?**

[Afbeeldingen](/slides/nl/cpp/image/) worden geëxporteerd naar een aparte map, en het Markdown‑bestand verwijst standaard naar hen met relatieve paden. U kunt het basisondervoerpads en de naam van de asset‑map configureren om een voorspelbare repository‑structuur te behouden.