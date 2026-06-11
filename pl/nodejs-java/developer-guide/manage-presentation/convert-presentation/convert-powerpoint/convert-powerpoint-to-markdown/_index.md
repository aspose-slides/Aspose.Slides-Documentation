---
title: Konwertuj prezentacje PowerPoint do Markdown w JavaScript
linktitle: PowerPoint do Markdown
type: docs
weight: 140
url: /pl/nodejs-java/convert-powerpoint-to-markdown/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Konwertuj slajdy PowerPoint w JavaScript—PPT, PPTX—do czystego Markdown przy użyciu Aspose.Slides dla Node.js via Java, automatyzuj dokumentację i zachowaj formatowanie."
---
## **Wprowadzenie**

Aspose.Slides umożliwia konwertowanie prezentacji PowerPoint do formatu Markdown, co może być przydatne w przepływach dokumentacji, generowaniu statycznych witryn, migracji treści oraz publikacji tekstu kontrolowanej wersjami. API obsługuje bezpośredni eksport z prezentacji PPT i PPTX do plików MD i zapewnia dodatkowe opcje kontrolowania, jak zawartość slajdów jest reprezentowana w powstałym dokumencie Markdown.

Możesz eksportować prezentacje jako czysty Markdown, wybierać spośród wielu odmian Markdown, takich jak CommonMark i GitHub Flavored Markdown, oraz konfigurować sposób obsługi obrazów podczas eksportu. Dla prezentacji zawierających treści wizualne, Aspose.Slides umożliwia również zapisywanie obrazów do oddzielnego folderu i odwoływanie się do nich z wygenerowanego pliku Markdown.

{{% alert color="warning" %}} 
Eksport PowerPoint do markdown jest domyślnie **bez obrazów**. Jeśli chcesz wyeksportować dokument PowerPoint zawierający obrazy, musisz wywołać `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` oraz ustawić `BasePath`, w którym zostaną zapisane obrazy odwoływane w dokumencie markdown.
{{% /alert %}} 

## **Konwertuj PowerPoint do Markdown**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) reprezentującej obiekt prezentacji.
2. Użyj metody [save](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#save-aspose.slides.IXamlOptions-) aby zapisać obiekt jako plik markdown.

Ten kod JavaScript pokazuje, jak skonwertować PowerPoint do markdown:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.md", aspose.slides.SaveFormat.Md);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Konwertuj PowerPoint do odmiany Markdown**

Aspose.Slides umożliwia konwersję PowerPoint do markdown (zawierającego podstawową składnię), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab oraz 17 innych odmian markdown.

Ten kod JavaScript pokazuje, jak skonwertować PowerPoint do CommonMark:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.CommonMark);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

23 obsługiwane odmiany markdown są [wymienione w wyliczeniu Flavor](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/flavor/) z klasy [MarkdownSaveOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/markdownsaveoptions/).

## **Konwertuj prezentację zawierającą obrazy do Markdown**

Klasa [MarkdownSaveOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/markdownsaveoptions/) udostępnia właściwości i wyliczenia pozwalające na wykorzystanie określonych opcji lub ustawień dla powstałego pliku markdown. Enum [MarkdownExportType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/markdownexporttype/) można na przykład ustawić na wartości określające, jak obrazy są renderowane lub obsługiwane: `Sequential`, `TextOnly`, `Visual`.

### **Konwertuj obrazy kolejno**

Jeśli chcesz, aby obrazy pojawiały się kolejno, jeden po drugim w powstałym markdown, musisz wybrać opcję sequential. Ten kod JavaScript pokazuje, jak skonwertować prezentację zawierającą obrazy do markdown:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.Github);
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(aspose.slides.NewLineType.Windows);
    pres.save("doc.md", java.newArray("int", [1, 2, 3, 4, 5, 6, 7, 8, 9]), aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Konwertuj obrazy wizualnie**

Jeśli chcesz, aby obrazy pojawiały się razem w powstałym markdown, musisz wybrać opcję visual. W tym przypadku obrazy zostaną zapisane w bieżącym katalogu aplikacji (a w dokumencie markdown zostanie utworzona względna ścieżka do nich) lub możesz określić własną ścieżkę i nazwę folderu.

Ten kod JavaScript demonstruje tę operację:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    final var outPath = "c:/documents";
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Czy hiperłącza przetrwają eksport do Markdown?**

Tak. Tekstowe [hiperłącza](/slides/pl/nodejs-java/manage-hyperlinks/) są zachowane jako standardowe linki Markdown. Przejścia slajdów [przejścia](/slides/pl/nodejs-java/slide-transition/) i [animacje](/slides/pl/nodejs-java/powerpoint-animation/) nie są konwertowane.

**Czy mogę przyspieszyć konwersję uruchamiając ją w wielu wątkach?**

Możesz równolegle przetwarzać pliki, ale [nie dziel](/slides/pl/nodejs-java/multithreading/) tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) między wątkami. Używaj oddzielnych instancji/procesów na plik, aby uniknąć rywalizacji.

**Co się dzieje z obrazami — gdzie są zapisywane i czy ścieżki są względne?**

[Obrazy](/slides/pl/nodejs-java/image/) są eksportowane do dedykowanego folderu, a plik Markdown odwołuje się do nich domyślnie za pomocą ścieżek względnych. Możesz skonfigurować podstawową ścieżkę wyjściową i nazwę folderu zasobów, aby zachować przewidywalną strukturę repozytorium.