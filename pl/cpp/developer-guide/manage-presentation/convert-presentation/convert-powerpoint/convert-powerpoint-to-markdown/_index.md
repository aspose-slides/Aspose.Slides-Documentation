---
title: Konwertuj prezentacje PowerPoint do Markdown w C++
linktitle: PowerPoint do Markdown
type: docs
weight: 140
url: /pl/cpp/convert-powerpoint-to-markdown/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do MD
- prezentacja do MD
- slajd do MD
- PPT do MD
- PPTX do MD
- zapisz PowerPoint jako Markdown
- zapisz prezentację jako Markdown
- zapisz slajd jako Markdown
- zapisz PPT jako MD
- zapisz PPTX jako MD
- eksportuj PPT do MD
- eksportuj PPTX do MD
- PowerPoint
- prezentacja
- Markdown
- C++
- Aspose.Slides
description: "Konwertuj slajdy PowerPoint — PPT, PPTX — do czystego Markdown przy użyciu Aspose.Slides dla C++, automatyzuj dokumentację i zachowaj formatowanie."
---
## **Wprowadzenie**

Aspose.Slides umożliwia konwersję prezentacji PowerPoint do formatu Markdown, co może być przydatne w przepływach dokumentacji, generowaniu statycznych stron, migracji treści oraz publikacji tekstu kontrolowanej wersjami. API obsługuje bezpośredni eksport z prezentacji PPT i PPTX do plików MD i zapewnia dodatkowe opcje kontrolowania sposobu reprezentacji treści slajdów w powstającym dokumencie Markdown.

Możesz eksportować prezentacje jako czysty Markdown, wybierać spośród wielu odmian Markdown, takich jak CommonMark i GitHub Flavored Markdown, oraz konfigurować sposób obsługi obrazów podczas eksportu. Dla prezentacji zawierających treść wizualną Aspose.Slides pozwala również zapisać obrazy w osobnym folderze i odwoływać się do nich z wygenerowanego pliku Markdown.

{{% alert color="warning" %}} 
Eksport PowerPoint do formatu markdown jest domyślnie **bez obrazów**. Jeśli chcesz wyeksportować dokument PowerPoint zawierający obrazy, musisz ustawić `SaveOptions::MarkdownExportType::Visual)` oraz określić `BasePath`, w którym obrazy odwoływane w dokumencie markdown zostaną zapisane.
{{% /alert %}} 

## **Konwertuj PowerPoint do Markdown**

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) reprezentującej obiekt prezentacji.  
2. Użyj metody [Zapisz ](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method)metodą, aby zapisać obiekt jako plik markdown.

Ten kod C++ pokazuje, jak konwertować PowerPoint do markdown:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```

## **Konwertuj PowerPoint do odmiany Markdown**

Aspose.Slides umożliwia konwersję PowerPoint do markdown (z podstawową składnią), CommonMark, markdown w stylu GitHub, Trello, XWiki, GitLab oraz 17 innych odmian markdown.

Ten kod C++ pokazuje, jak konwertować PowerPoint do CommonMark:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```

23 obsługiwane odmiany markdown są [wymienione w wyliczeniu Flavor](https://reference.aspose.com/slides/pl/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) z klasy [MarkdownSaveOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Konwertuj prezentację zawierającą obrazy do Markdown**

Klasa [MarkdownSaveOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) udostępnia właściwości i wyliczenia, które pozwalają używać określonych opcji lub ustawień dla powstającego pliku markdown. Enum [MarkdownExportType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) może być ustawiony na wartości określające, jak obrazy są renderowane lub obsługiwane: `Sequential`, `TextOnly`, `Visual`.

### **Konwertuj obrazy kolejno**

Jeśli chcesz, aby obrazy pojawiały się kolejno jeden po drugim w powstającym markdown, musisz wybrać opcję kolejności. Ten kod C++ pokazuje, jak konwertować prezentację zawierającą obrazy do markdown:

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

### **Konwertuj obrazy wizualnie**

Jeśli chcesz, aby obrazy pojawiały się razem w powstającym markdown, musisz wybrać opcję wizualną. W tym przypadku obrazy zostaną zapisane w bieżącym katalogu aplikacji (a w dokumencie markdown zostanie utworzona względna ścieżka do nich) lub możesz podać własną ścieżkę i nazwę folderu.

Ten kod C++ demonstruje operację:

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

**Czy hiperłącza przeżywają eksport do Markdown?**

Tak. Tekstowe [hiperłącza](/slides/pl/cpp/manage-hyperlinks/) są zachowywane jako standardowe odnośniki Markdown. [Przejścia](/slides/pl/cpp/slide-transition/) i [animacje](/slides/pl/cpp/powerpoint-animation/) slajdów nie są konwertowane.

**Czy mogę przyspieszyć konwersję uruchamiając ją w wielu wątkach?**

Możesz równolegle przetwarzać pliki, ale [nie udostępniaj](/slides/pl/cpp/multithreading/) tej samej [Prezentacja](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) między wątkami. Używaj oddzielnych instancji/procesów dla każdego pliku, aby uniknąć konfliktów.

**Co dzieje się z obrazami — gdzie są zapisywane i czy ścieżki są względne?**

[Obrazy](/slides/pl/cpp/image/) są eksportowane do dedykowanego folderu, a plik Markdown odwołuje się do nich domyślnie przy użyciu względnych ścieżek. Możesz skonfigurować podstawową ścieżkę wyjściową i nazwę folderu zasobów, aby zachować przewidywalną strukturę repozytorium.