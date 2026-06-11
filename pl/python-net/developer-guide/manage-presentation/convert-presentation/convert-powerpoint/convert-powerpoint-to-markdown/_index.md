---
title: Konwertowanie prezentacji PowerPoint do Markdown w Pythonie
linktitle: PowerPoint do Markdown
type: docs
weight: 140
url: /pl/python-net/convert-powerpoint-to-markdown/
keywords:
- konwertuj PowerPoint do Markdown
- konwertuj OpenDocument do Markdown
- konwertuj prezentację do Markdown
- konwertuj slajd do Markdown
- konwertuj PPT do Markdown
- konwertuj PPTX do Markdown
- konwertuj ODP do Markdown
- konwertuj PowerPoint do MD
- konwertuj OpenDocument do MD
- konwertuj prezentację do MD
- konwertuj slajd do MD
- konwertuj PPT do MD
- konwertuj PPTX do MD
- konwertuj ODP do MD
- PowerPoint
- OpenDocument
- prezentacja
- Markdown
- Python
- Aspose.Slides
description: "Konwertuj slajdy PowerPoint i OpenDocument — PPT, PPTX, ODP — do czystego Markdown przy użyciu Aspose.Slides dla Pythona via .NET, automatyzuj dokumentację i zachowaj formatowanie."
---
## **Wprowadzenie**

Aspose.Slides umożliwia konwertowanie prezentacji PowerPoint do formatu Markdown, co może być przydatne w procesach dokumentacji, generowaniu statycznych witryn, migracji treści oraz publikacji tekstów kontrolowanych wersjami. API obsługuje bezpośredni eksport prezentacji PPT i PPTX do plików MD i zapewnia dodatkowe opcje kontrolujące sposób reprezentacji zawartości slajdów w wygenerowanym dokumencie Markdown.

Możesz eksportować prezentacje jako czysty Markdown, wybierać spośród wielu odmian Markdown, takich jak CommonMark i GitHub Flavored Markdown, oraz konfigurować sposób obsługi obrazów podczas eksportu. Dla prezentacji zawierających treść wizualną Aspose.Slides umożliwia także zapisywanie obrazów w oddzielnym folderze i odwoływanie się do nich z wygenerowanego pliku Markdown.

{{% alert color="warning" %}}
Eksport PowerPoint do Markdown jest domyślnie **bez obrazów**. Jeśli chcesz wyeksportować dokument PowerPoint zawierający obrazy, musisz ustawić `export_type = MarkdownExportType.VISUAL` i określić `base_path`, gdzie zostaną zapisane obrazy odwoływane w dokumencie Markdown.
{{% /alert %}}

## **Konwertowanie prezentacji do Markdown**

Poniższy przykład pokazuje najprostszy sposób konwersji prezentacji PowerPoint do Markdown przy użyciu Aspose.Slides dla Pythona via .NET z ustawieniami domyślnymi.

1. Utwórz instancję [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/), aby załadować prezentację.
1. Wywołaj `save`, aby wyeksportować ją jako plik Markdown.

Użyj poniższego fragmentu kodu Python, aby wykonać konwersję:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:  
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **Konwertowanie prezentacji do odmiany Markdown**

Aspose.Slides umożliwia konwertowanie prezentacji do formatów Markdown, w tym podstawowego Markdown, CommonMark, GitHub-flavored Markdown, Trello, XWiki, GitLab oraz 17 innych odmian Markdown.

Poniższy przykład w Pythonie pokazuje, jak przekonwertować prezentację PowerPoint do CommonMark:

```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, save_options)
```

23 obsługiwane odmiany Markdown są wymienione w wyliczeniu [Flavor](https://reference.aspose.com/slides/pl/python-net/aspose.slides.dom.export.markdown.saveoptions/flavor/) klasy [MarkdownSaveOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Konwertowanie prezentacji zawierających obrazy do Markdown**

Klasa [MarkdownSaveOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) udostępnia właściwości i wyliczenia, które pozwalają skonfigurować wynikowy plik Markdown. Na przykład wyliczenie [MarkdownExportType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) steruje sposobem obsługi obrazów: `SEQUENTIAL`, `TEXT_ONLY` lub `VISUAL`.

### **Konwertowanie obrazów sekwencyjnie**

Jeśli chcesz, aby obrazy pojawiały się kolejno — jeden po drugim — w wygenerowanym Markdownzie, wybierz opcję `SEQUENTIAL`. Poniższy przykład w Pythonie pokazuje, jak przekonwertować prezentację z obrazami do Markdown.

```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.show_hidden_slides = True
save_options.show_slide_number = True
save_options.flavor = slides.export.Flavor.GITHUB
save_options.export_type = slides.export.MarkdownExportType.SEQUENTIAL
save_options.new_line_type = slides.export.NewLineType.WINDOWS

slide_indices = [1, 3, 5]

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slide_indices, slides.export.SaveFormat.MD, save_options)
```

### **Konwertowanie obrazów wizualnie**

Jeśli chcesz, aby obrazy pojawiły się razem w wynikowym Markdownzie, wybierz opcję `VISUAL`. W tym trybie obrazy są zapisywane do bieżącego katalogu aplikacji (a dokument Markdown używa ścieżek względnych) lub możesz określić własną ścieżkę wyjściową oraz nazwę folderu.

Poniższy przykład w Pythonie demonstruje tę operację:

```python
import os
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.export_type = slides.export.MarkdownExportType.VISUAL
save_options.images_save_folder_name = "md-images"
save_options.base_path = "c:\\documents"

with slides.Presentation("presentation.pptx") as presentation:
    file_path = os.path.join(save_options.base_path, "presentation.md")
    presentation.save(file_path, slides.export.SaveFormat.MD, save_options)
```

## **FAQ**

**Czy hiperłącza przetrwają eksport do Markdown?**

Tak. Tekstowe [hiperlinki](/slides/pl/python-net/manage-hyperlinks/) są zachowane jako standardowe linki Markdown. [Przejścia](/slides/pl/python-net/slide-transition/) slajdów i [animacje](/slides/pl/python-net/powerpoint-animation/) nie są konwertowane.

**Czy mogę przyspieszyć konwersję uruchamiając ją w wielu wątkach?**

Możesz równolegle przetwarzać pliki, ale [nie udostępniaj](/slides/pl/python-net/multithreading/) tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) między wątkami. Używaj oddzielnych instancji/procesów dla każdego pliku, aby uniknąć konfliktów.

**Co się dzieje z obrazami — gdzie są zapisywane i czy ścieżki są względne?**

[Obrazy](/slides/pl/python-net/image/) są eksportowane do dedykowanego folderu, a plik Markdown odwołuje się do nich domyślnie za pomocą ścieżek względnych. Możesz skonfigurować podstawową ścieżkę wyjściową oraz nazwę folderu zasobów, aby utrzymać przewidywalną strukturę repozytorium.