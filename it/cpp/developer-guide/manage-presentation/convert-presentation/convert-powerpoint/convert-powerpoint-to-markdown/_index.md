---
title: Converti presentazioni PowerPoint in Markdown in C++
linktitle: PowerPoint in Markdown
type: docs
weight: 140
url: /it/cpp/convert-powerpoint-to-markdown/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- converti PPTX
- PowerPoint in MD
- presentazione in MD
- diapositiva in MD
- PPT in MD
- PPTX in MD
- salva PowerPoint come Markdown
- salva presentazione come Markdown
- salva diapositiva come Markdown
- salva PPT come MD
- salva PPTX come MD
- esporta PPT in MD
- esporta PPTX in MD
- PowerPoint
- presentazione
- Markdown
- C++
- Aspose.Slides
description: "Converti le diapositive PowerPoint—PPT, PPTX—in Markdown pulito con Aspose.Slides per C++, automatizza la documentazione e mantieni la formattazione."
---
## **Introduzione**

Aspose.Slides consente di convertire le presentazioni PowerPoint in Markdown, il che può essere utile per i flussi di lavoro della documentazione, la generazione di siti statici, la migrazione di contenuti e la pubblicazione di testi versionati. L'API supporta l'esportazione diretta dalle presentazioni PPT e PPTX in file MD e fornisce opzioni aggiuntive per controllare come il contenuto delle diapositive è rappresentato nel documento Markdown risultante.

Puoi esportare le presentazioni come Markdown grezzo, scegliere tra più varianti di Markdown come CommonMark e GitHub Flavored Markdown, e configurare come le immagini vengono gestite durante l'esportazione. Per le presentazioni che contengono contenuti visivi, Aspose.Slides ti permette anche di salvare le immagini in una cartella separata e riferirle dal file Markdown generato.

{{% alert color="warning" %}} 

L'esportazione da PowerPoint a markdown è **senza immagini** per impostazione predefinita. Se desideri esportare un documento PowerPoint contenente immagini, devi impostare `SaveOptions::MarkdownExportType::Visual)` e anche impostare il `BasePath` dove saranno salvate le immagini riportate nel documento markdown.

{{% /alert %}} 

## **Converti PowerPoint in Markdown**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) per rappresentare un oggetto presentazione.  
2. Usa il metodo [Save ](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method) per salvare l'oggetto come file markdown.

Questo codice C++ mostra come convertire PowerPoint in markdown:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```

## **Converti PowerPoint in un formato Markdown**

Aspose.Slides consente di convertire PowerPoint in markdown (contenente sintassi di base), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab e altri 17 formati markdown.

Questo codice C++ mostra come convertire PowerPoint in CommonMark: 

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```

I 23 formati markdown supportati sono [elencati sotto l'enumerazione Flavor](https://reference.aspose.com/slides/it/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) nella classe [MarkdownSaveOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Converti una presentazione contenente immagini in Markdown**

La classe [MarkdownSaveOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) fornisce proprietà ed enumerazioni che ti permettono di impostare opzioni specifiche per il file markdown risultante. L'enumerazione [MarkdownExportType](https://reference.aspose.com/slides/it/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) può, ad esempio, essere impostata su valori che determinano come le immagini vengono renderizzate o gestite: `Sequential`, `TextOnly`, `Visual`.

### **Converti le Immagini Sequenzialmente**

Se desideri che le immagini compaiano una alla volta nel markdown risultante, devi scegliere l'opzione sequenziale. Questo codice C++ mostra come convertire una presentazione contenente immagini in markdown:

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

### **Converti le Immagini Visivamente**

Se desideri che le immagini compaiano insieme nel markdown risultante, devi scegliere l'opzione visual. In questo caso, le immagini verranno salvate nella directory corrente dell'applicazione (e verrà creato un percorso relativo nel documento markdown), oppure puoi specificare il percorso e il nome della cartella preferiti.

Questo codice C++ dimostra l'operazione: 

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

**I collegamenti ipertestuali sopravvivono all'esportazione in Markdown?**

Sì. I [collegamenti ipertestuali](/slides/it/cpp/manage-hyperlinks/) nel testo sono preservati come normali collegamenti Markdown. Le [transizioni](/slides/it/cpp/slide-transition/) e le [animazioni](/slides/it/cpp/powerpoint-animation/) delle diapositive non vengono convertite.

**Posso velocizzare la conversione eseguendola su più thread?**

Puoi parallelizzare per file, ma non [condividere](/slides/it/cpp/multithreading/) la stessa istanza di [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) tra thread. Usa istanze o processi separati per file per evitare conflitti.

**Cosa succede alle immagini—dove vengono salvate e i percorsi sono relativi?**

Le [Immagini](/slides/it/cpp/image/) vengono esportate in una cartella dedicata e il file Markdown le riferisce con percorsi relativi per impostazione predefinita. Puoi configurare il percorso di output base e il nome della cartella delle risorse per mantenere una struttura di repository prevedibile.