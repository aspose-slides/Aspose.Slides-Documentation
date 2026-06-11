---
title: Ograniczenia API
type: docs
weight: 320
url: /pl/php-java/api-limitations/
keywords:
- Ograniczenia API
- format eksportu
- aplikacja
- producent
- właściwości dokumentu
- metadane
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Poznaj ograniczenia Aspose.Slides for PHP: eksporty ustawiają stałe metadane Application/Producer w plikach PPT, PPTX, ODP i PDF — pomagając zaplanować integracje bez niespodzianek."
---
## **Przegląd**

Kiedy prezentacje są tworzone lub eksportowane przy użyciu Aspose.Slides, pewne techniczne metadane są zapisywane w pliku wyjściowym. Ten artykuł wyjaśnia ograniczenia związane z polami metadanych `Application`, `Creator` i `Producer` w plikach PPTX i PDF.

## **Application i Producer**

Kiedy tworzysz lub eksportujesz prezentacje przy użyciu Aspose.Slides for PHP via Java, niektóre techniczne metadane są zapisywane w pliku. Dwa pola często budzą pytania:

**Application** identyfikuje program, który utworzył lub ostatnio zapisał prezentację **PPTX**. W Aspose.Slides for PHP via Java wartość ta jest stała i wyświetla dostawcę biblioteki zamiast nazwy twojej aplikacji, nawet jeśli używasz [DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/pl/php-java/aspose.slides/documentproperties/setnameofapplication/).

**Producer** identyfikuje silnik renderujący, który wygenerował ostateczny plik podczas eksportu. W eksportach **PDF** metadane używają pól **Creator** i **Producer**. W Aspose.Slides for PHP via Java oba te pola są stałe i odzwierciedlają bibliotekę oraz jej wersję.

**Co jest ograniczone**

Nie możesz nadpisać tych pól za pomocą API dla wymienionych formatów. Dla **PPTX** właściwość Application jest zapisywana jako "Aspose.Slides for PHP via Java". Dla **PDF** właściwości Creator i Producer są zapisywane jako "Aspose.Slides for PHP via Java x.x.x." To zachowanie jest zamierzone i obowiązuje niezależnie od tego, w jaki sposób ładowany lub zapisywany jest plik, oraz niezależnie od wartości przypisanych przy użyciu [DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/pl/php-java/aspose.slides/documentproperties/setnameofapplication/).