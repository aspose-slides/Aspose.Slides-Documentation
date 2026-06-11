---
title: Konwertuj prezentacje PowerPoint do Markdown w PHP
linktitle: PowerPoint do Markdown
type: docs
weight: 140
url: /pl/php-java/convert-powerpoint-to-markdown/
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
- PHP
- Aspose.Slides
description: "Konwertuj slajdy PowerPoint — PPT, PPTX — na czysty Markdown przy użyciu Aspose.Slides dla PHP przez Java, automatyzuj dokumentację i zachowaj formatowanie."
---
## **Wprowadzenie**

Aspose.Slides umożliwia konwersję prezentacji PowerPoint do formatu Markdown, co może być przydatne w przepływach pracy dokumentacji, generowaniu statycznych stron, migracji treści oraz publikacji tekstu kontrolowanego wersjami. API obsługuje bezpośredni eksport prezentacji PPT i PPTX do plików MD oraz oferuje dodatkowe opcje kontrolujące sposób reprezentacji treści slajdów w powstałym dokumencie Markdown.

Możesz eksportować prezentacje jako zwykły Markdown, wybrać spośród wielu wariantów Markdown, takich jak CommonMark i GitHub Flavored Markdown, oraz skonfigurować sposób obsługi obrazów podczas eksportu. W przypadku prezentacji zawierających treści wizualne, Aspose.Slides umożliwia zapisanie obrazów w oddzielnym folderze i odwoływanie się do nich z wygenerowanego pliku Markdown.

{{% alert color="warning" %}}

Eksport z PowerPoint do Markdown domyślnie **bez obrazów**. Jeśli chcesz wyeksportować dokument PowerPoint zawierający obrazy, musisz ustawić `ExportType = MarkdownExportType::Visual` i określić `BasePath`, gdzie zostaną zapisane obrazy odwoływane w dokumencie Markdown.

{{% /alert %}}

## **Konwertuj prezentację do Markdown**

Ta sekcja wyjaśnia, jak Aspose.Slides konwertuje prezentacje PowerPoint i OpenDocument (PPT, PPTX, ODP) do czystego Markdown, zachowując oryginalną hierarchię slajdów, tekst i podstawowe formatowanie, aby można było ponownie wykorzystać treść w dokumentacji lub w przepływach pracy kontrolowanych wersjami bez dodatkowego ręcznego wysiłku.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) reprezentującą prezentację.
1. Użyj metody [save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#save) aby wyeksportować ją jako plik Markdown.

Poniższy kod PHP pokazuje, jak skonwertować prezentację PowerPoint do Markdown:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.md", SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **Konwertuj prezentację do wybranego wariantu Markdown**

Aspose.Slides umożliwia konwersję prezentacji PowerPoint do Markdown z podstawową składnią, a także do CommonMark, GitHub‑flavored Markdown, Trello, XWiki, GitLab i siedemnastu innych wariantów Markdown.

Poniższy kod PHP demonstruje, jak skonwertować prezentację PowerPoint do CommonMark:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setFlavor(Flavor->CommonMark);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

23 obsługiwane warianty Markdown są wymienione w [enumeracji Flavor](https://reference.aspose.com/slides/pl/php-java/aspose.slides/flavor/).

## **Konwertuj prezentację zawierającą obrazy do Markdown**

Klasa [MarkdownSaveOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/markdownsaveoptions/) udostępnia właściwości i wyliczenia, które pozwalają skonfigurować wynikowy plik Markdown. Na przykład wyliczenie [MarkdownExportType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/markdownexporttype/) określa, jak obsługiwane są obrazy: `Sequential`, `TextOnly` lub `Visual`.

{{% alert color="warning" %}}

Domyślnie eksport z PowerPoint do Markdown **nie zawiera obrazów**. Aby osadzić obrazy, wywołaj `markdownSaveOptions.setExportType(MarkdownExportType::Visual)` i ustaw `BasePath`, który określa, gdzie zostaną zapisane obrazy odwoływane w pliku Markdown.

{{% /alert %}}

### **Konwertuj obrazy kolejno**

Jeśli chcesz, aby obrazy pojawiały się pojedynczo, jeden po drugim, w wynikowym Markdown, musisz wybrać opcję `Sequential`. Poniższy kod PHP pokazuje, jak skonwertować prezentację zawierającą obrazy do Markdown:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setShowHiddenSlides(true);
    $saveOptions->setShowSlideNumber(true);
    $saveOptions->setFlavor(Flavor->Github);
    $saveOptions->setExportType(MarkdownExportType::Sequential);
    $saveOptions->setNewLineType(NewLineType::Windows);

    $slideIndices = array(1, 2, 3, 4);
    $presentation->save("presentation.md", $slideIndices, SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

### **Konwertuj obrazy wizualnie**

Jeśli chcesz, aby obrazy pojawiały się razem w wynikowym Markdown, musisz wybrać opcję `Visual`. W tym przypadku obrazy są zapisywane w bieżącym katalogu aplikacji (i w dokumencie Markdown generowana jest względna ścieżka), lub możesz określić własny katalog i nazwę folderu.

Poniższy kod PHP demonstruje tę operację:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $outPath = "c:/documents";

    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setExportType(MarkdownExportType::Visual);
    $saveOptions->setImagesSaveFolderName("md-images");
    $saveOptions->setBasePath($outPath);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Czy hiperłącza przetrwają eksport do Markdown?**

Tak. Tekstowe [hyperlinki](/slides/pl/php-java/manage-hyperlinks/) są zachowane jako standardowe linki Markdown. [Przejścia](/slides/pl/php-java/slide-transition/) i [animacje](/slides/pl/php-java/powerpoint-animation/) slajdów nie są konwertowane.

**Czy mogę przyspieszyć konwersję, uruchamiając ją w wielu wątkach?**

Możesz równolegle przetwarzać pliki, ale [nie udostępniaj](/slides/pl/php-java/multithreading/) tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) między wątkami. Używaj oddzielnych instancji/procesów dla każdego pliku, aby uniknąć konfliktów.

**Co się dzieje z obrazami — gdzie są zapisywane i czy ścieżki są względne?**

[Obrazy](/slides/pl/php-java/image/) są eksportowane do dedykowanego folderu, a plik Markdown odwołuje się do nich domyślnie za pomocą względnych ścieżek. Możesz skonfigurować bazową ścieżkę wyjściową oraz nazwę folderu zasobów, aby utrzymać przewidywalną strukturę repozytorium.