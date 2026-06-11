---
title: Konwertuj prezentacje PowerPoint do Markdown w Javie
linktitle: PowerPoint do Markdown
type: docs
weight: 140
url: /pl/java/convert-powerpoint-to-markdown/
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
- Java
- Aspose.Slides
description: "Konwertuj slajdy PowerPoint—PPT, PPTX—na czysty Markdown przy użyciu Aspose.Slides dla Javy, automatyzuj dokumentację i zachowaj formatowanie."
---
## **Wprowadzenie**

Aspose.Slides pozwala konwertować prezentacje PowerPoint do formatu Markdown, co może być przydatne w przepływach dokumentacji, generowaniu statycznych stron, migracji treści oraz publikacji tekstu w systemie kontroli wersji. API obsługuje bezpośredni eksport z prezentacji PPT i PPTX do plików MD oraz oferuje dodatkowe opcje kontrolujące, jak zawartość slajdów jest reprezentowana w powstałym dokumencie Markdown.

Można eksportować prezentacje jako zwykły Markdown, wybierać spośród wielu odmian Markdown, takich jak CommonMark i GitHub Flavored Markdown, oraz konfigurować sposób obsługi obrazów podczas eksportu. Dla prezentacji zawierających treści wizualne, Aspose.Slides umożliwia również zapisanie obrazów w osobnym folderze i odwoływanie się do nich z wygenerowanego pliku Markdown.

{{% alert color="warning" %}}
Eksport PowerPoint do markdown jest **bez obrazów** domyślnie. Jeśli chcesz wyeksportować dokument PowerPoint zawierający obrazy, musisz użyć `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` oraz `setBasePath`, w którym obrazy odwoływane w dokumencie markdown zostaną zapisane.
{{% /alert %}}

## **Konwersja PowerPoint do Markdown**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) reprezentującej obiekt prezentacji.
2. Użyj metody [Save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) aby zapisać obiekt jako plik markdown.

Ten kod Java pokazuje, jak skonwertować PowerPoint do markdown:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Konwersja PowerPoint do odmiany Markdown**

Aspose.Slides pozwala konwertować PowerPoint do markdown (z podstawową składnią), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab oraz 17 innych odmian markdown.

Ten kod Java pokazuje, jak skonwertować PowerPoint do CommonMark:

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

23 obsługiwane odmiany markdown są [wymienione w wyliczeniu Flavor](https://reference.aspose.com/slides/pl/java/com.aspose.slides/flavor/) klasy [MarkdownSaveOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/markdownsaveoptions/).

## **Konwersja prezentacji zawierającej obrazy do Markdown**

Klasa [MarkdownSaveOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/markdownsaveoptions/) udostępnia właściwości i wyliczenia, które pozwalają stosować określone opcje lub ustawienia dla powstałego pliku markdown. Enum [MarkdownExportType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/markdownexporttype/) może być ustawiony na wartości określające, jak obrazy są renderowane lub obsługiwane: `Sequential`, `TextOnly`, `Visual`.

### **Konwersja obrazów kolejno**

Jeśli chcesz, aby obrazy pojawiały się pojedynczo jeden po drugim w wynikowym markdown, musisz wybrać opcję sequential. Ten kod Java pokazuje, jak skonwertować prezentację zawierającą obrazy do markdown:

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

### **Konwersja obrazów wizualnie**

Jeśli chcesz, aby obrazy pojawiały się razem w wynikowym markdown, musisz wybrać opcję visual. W tym przypadku obrazy zostaną zapisane w bieżącym katalogu aplikacji (a względna ścieżka zostanie w nich utworzona w dokumencie markdown) lub możesz podać własną ścieżkę i nazwę folderu.

Ten kod Java demonstruje tę operację:

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

**Czy hiperłącza przeżywają eksport do Markdown?**

Tak. Tekstowe [hiperłącza](/slides/pl/java/manage-hyperlinks/) są zachowane jako standardowe linki Markdown. [Przejścia](/slides/pl/java/slide-transition/) slajdów i [animacje](/slides/pl/java/powerpoint-animation/) nie są konwertowane.

**Czy mogę przyspieszyć konwersję, uruchamiając ją w wielu wątkach?**

Możesz równolegle przetwarzać pliki, ale [nie udostępniaj](/slides/pl/java/multithreading/) tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) pomiędzy wątkami. Używaj oddzielnych instancji/procesów dla każdego pliku, aby uniknąć konfliktów.

**Co się dzieje z obrazami — gdzie są zapisywane i czy ścieżki są względne?**

[Obrazy](/slides/pl/java/image/) są eksportowane do dedykowanego folderu, a plik Markdown odwołuje się do nich domyślnie ze względnymi ścieżkami. Możesz skonfigurować bazową ścieżkę wyjściową i nazwę folderu zasobów, aby zachować przewidywalną strukturę repozytorium.