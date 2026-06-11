---
title: Konwertuj prezentacje PowerPoint do Markdown w .NET
linktitle: PowerPoint do Markdown
type: docs
weight: 140
url: /pl/net/convert-powerpoint-to-markdown/
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
- .NET
- C#
- Aspose.Slides
description: "Konwertuj slajdy PowerPoint - PPT, PPTX - do czystego Markdown za pomocą Aspose.Slides dla .NET, automatyzuj dokumentację i zachowaj formatowanie."
---
## **Wprowadzenie**

Aspose.Slides umożliwia konwersję prezentacji PowerPoint do formatu Markdown, co może być przydatne w procesach dokumentacji, generowaniu statycznych stron, migracji treści oraz publikacji tekstu kontrolowanego wersjami. API obsługuje bezpośredni eksport z prezentacji PPT i PPTX do plików MD i zapewnia dodatkowe opcje kontrolujące sposób, w jaki zawartość slajdów jest przedstawiana w wynikowym dokumencie Markdown.

Możesz eksportować prezentacje jako zwykły Markdown, wybierać spośród wielu odmian Markdown, takich jak CommonMark i GitHub Flavored Markdown, oraz konfigurować sposób obsługi obrazów podczas eksportu. Dla prezentacji zawierających treści wizualne Aspose.Slides umożliwia także zapisanie obrazów do osobnego folderu i odwołanie się do nich w wygenerowanym pliku Markdown.

{{% alert color="warning" %}}
Eksport PowerPoint do Markdown jest domyślnie **bez obrazów**. Jeśli chcesz wyeksportować dokument PowerPoint zawierający obrazy, musisz ustawić `ExportType = MarkdownExportType.Visual` i określić `BasePath`, gdzie zostaną zapisane obrazy odwoływane w dokumencie Markdown.
{{% /alert %}}

## **Konwertuj PowerPoint do Markdown**

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation), aby reprezentować obiekt prezentacji.  
2. Użyj metody [Zapisz](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/methods/save), aby zapisać obiekt jako plik markdown.

Ten kod C# pokazuje, jak skonwertować PowerPoint do Markdown:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```

## **Konwertuj PowerPoint do Odmiany Markdown**

Aspose.Slides umożliwia konwersję PowerPoint do markdown (z podstawową składnią), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab i 17 innych odmian markdown.

Ten kod C# pokazuje, jak skonwertować PowerPoint do CommonMark:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```

23 obsługiwane odmiany markdown są [wymienione w wyliczeniu Flavor](https://reference.aspose.com/slides/pl/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) klasy [MarkdownSaveOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Konwertuj prezentację zawierającą obrazy do Markdown**

Klasa [MarkdownSaveOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) udostępnia właściwości i wyliczenia, które umożliwiają użycie określonych opcji lub ustawień dla wynikowego pliku markdown. Wyliczenie [MarkdownExportType](https://reference.aspose.com/slides/pl/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) może być ustawione na wartości określające sposób renderowania lub obsługi obrazów: `Sequential`, `TextOnly`, `Visual`.

### **Konwertuj obrazy kolejno**

Jeśli chcesz, aby obrazy pojawiały się kolejno, pojedynczo jeden po drugim w wynikowym markdown, musisz wybrać opcję kolejności. Ten kod C# pokazuje, jak skonwertować prezentację zawierającą obrazy do markdown:

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

### **Konwertuj obrazy wizualnie**

Jeśli chcesz, aby obrazy pojawiały się razem w wynikowym markdown, musisz wybrać opcję wizualną.   W tym przypadku obrazy zostaną zapisane w bieżącym katalogu aplikacji (a w dokumencie markdown zostanie utworzona względna ścieżka), lub możesz określić własną ścieżkę i nazwę folderu.

Ten kod C# demonstruje tę operację:

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

**Czy hiperłącza przetrwają eksport do Markdown?**

Tak. Tekstowe [hiperłącza](/slides/pl/net/manage-hyperlinks/) są zachowane jako standardowe linki Markdown. [Przejścia](/slides/pl/net/slide-transition/) i [animacje](/slides/pl/net/powerpoint-animation/) slajdów nie są konwertowane.

**Czy mogę przyspieszyć konwersję, uruchamiając ją w wielu wątkach?**

Możesz równolegle przetwarzać pliki, ale [nie udostępniaj](/slides/pl/net/multithreading/) tej samej instancji [Prezentacja](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) pomiędzy wątkami. Używaj osobnych instancji/procesów dla każdego pliku, aby uniknąć konfliktów.

**Co się dzieje z obrazami — gdzie są zapisywane i czy ścieżki są względne?**

[Obrazy](/slides/pl/net/image/) są eksportowane do dedykowanego folderu, a plik Markdown odwołuje się do nich domyślnie ścieżkami względnymi. Możesz skonfigurować podstawową ścieżkę wyjściową i nazwę folderu zasobów, aby zachować przewidywalną strukturę repozytorium.