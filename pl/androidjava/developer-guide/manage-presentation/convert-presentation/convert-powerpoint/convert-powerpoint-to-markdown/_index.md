---
title: Konwertuj prezentacje PowerPoint do Markdown na Androidzie
linktitle: PowerPoint do Markdown
type: docs
weight: 140
url: /pl/androidjava/convert-powerpoint-to-markdown/
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
- Android
- Java
- Aspose.Slides
description: "Konwertuj slajdy PowerPoint - PPT, PPTX - do czystego Markdown przy użyciu Aspose.Slides dla Androida w Java, automatyzuj dokumentację i zachowaj formatowanie."
---
## **Wprowadzenie**

Aspose.Slides pozwala konwertować prezentacje PowerPoint do formatu Markdown, co może być przydatne w przepływach pracy dokumentacji, generowaniu statycznych witryn, migracji treści oraz publikacji tekstu pod kontrolą wersji. API obsługuje bezpośredni eksport z prezentacji PPT i PPTX do plików MD i zapewnia dodatkowe opcje kontrolujące sposób reprezentacji treści slajdów w powstałym dokumencie Markdown.

Możesz eksportować prezentacje jako czysty Markdown, wybierać spośród wielu odmian Markdown, takich jak CommonMark i GitHub Flavored Markdown, oraz konfigurować sposób przetwarzania obrazów podczas eksportu. Dla prezentacji zawierających treści wizualne Aspose.Slides umożliwia także zapis obrazów w osobnym folderze i odwoływanie się do nich z wygenerowanego pliku Markdown.

Aspose.Slides obsługuje konwersję prezentacji na Markdown.

{{% alert color="warning" %}} 

Eksport PowerPoint do Markdown jest domyślnie **bez obrazów**. Jeśli chcesz wyeksportować dokument PowerPoint zawierający obrazy, musisz ustawić `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` oraz określić `BasePath`, w którym będą zapisywane obrazy odwoływane w dokumencie markdown.

{{% /alert %}} 

## **Konwertuj PowerPoint na Markdown**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/), aby reprezentować obiekt prezentacji.  
2. Użyj metody [Zapisz](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-), aby zapisać obiekt jako plik markdown.

Poniższy kod Java pokazuje, jak przekonwertować PowerPoint na markdown:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Konwertuj PowerPoint na wybraną odmianę Markdown**

Aspose.Slides umożliwia konwersję PowerPoint do markdown (z podstawową składnią), CommonMark, GitHub Flavored Markdown, Trello, XWiki, GitLab oraz 17 innych odmian markdown.

Poniższy kod Java pokazuje, jak przekonwertować PowerPoint na CommonMark:

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

23 obsługiwane odmiany markdown są [wypisane w wyliczeniu Flavor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/flavor/) klasy [MarkdownSaveOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/markdownsaveoptions/).

## **Konwertuj prezentację zawierającą obrazy na Markdown**

Klasa [MarkdownSaveOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/markdownsaveoptions/) udostępnia własności i wyliczenia, które pozwalają skonfigurować określone opcje dla wynikowego pliku markdown. Enum [MarkdownExportType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/markdownexporttype/) może być ustawiony na wartości określające sposób renderowania lub obsługi obrazów: `Sequential`, `TextOnly`, `Visual`.

### **Konwertuj obrazy sekwencyjnie**

Jeśli chcesz, aby obrazy pojawiały się kolejno, jeden po drugim, w wynikowym markdown, wybierz opcję sekwencyjną. Poniższy kod Java pokazuje, jak przekonwertować prezentację zawierającą obrazy na markdown:

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

### **Konwertuj obrazy wizualnie**

Jeśli chcesz, aby obrazy były umieszczone razem w wynikowym markdown, wybierz opcję wizualną. W tym przypadku obrazy zostaną zapisane w bieżącym katalogu aplikacji (a w dokumencie markdown zostanie utworzona względna ścieżka), lub możesz podać własną ścieżkę i nazwę folderu.

Poniższy kod Java demonstruje tę operację:

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

**Czy hiperłącza zostają zachowane po eksporcie do Markdown?**

Tak. Tekstowe [hiperłącza](/slides/pl/androidjava/manage-hyperlinks/) są zachowane jako standardowe linki Markdown. [Przejścia](/slides/pl/androidjava/slide-transition/) i [animacje](/slides/pl/androidjava/powerpoint-animation/) slajdów nie są konwertowane.

**Czy mogę przyspieszyć konwersję, uruchamiając ją w wielu wątkach?**

Można równolegle przetwarzać pliki, ale [nie udostępniaj](/slides/pl/androidjava/multithreading/) tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) w wielu wątkach. Używaj oddzielnych instancji lub procesów dla każdego pliku, aby uniknąć rywalizacji o zasoby.

**Co się dzieje z obrazami — gdzie są zapisywane i czy ścieżki są względne?**

[Obrazy](/slides/pl/androidjava/image/) są eksportowane do dedykowanego folderu, a plik Markdown odwołuje się do nich domyślnie przy użyciu względnych ścieżek. Możesz skonfigurować bazową ścieżkę wyjściową oraz nazwę folderu zasobów, aby utrzymać przewidywalną strukturę repozytorium.