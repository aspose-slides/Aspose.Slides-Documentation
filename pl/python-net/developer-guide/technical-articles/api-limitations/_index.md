---
title: Ograniczenia API
type: docs
weight: 210
url: /pl/python-net/api-limitations/
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
- Python
- Aspose.Slides
description: "Poznaj ograniczenia Aspose.Slides for Python: eksporty ustalają stałe metadane Application/Producer w plikach PPT, PPTX, ODP i PDF — pomagając zaplanować integracje bez niespodzianek."
---
## **Przegląd**

Gdy prezentacje są tworzone lub eksportowane przy użyciu Aspose.Slides, określone dane techniczne są zapisywane w pliku wyjściowym. Ten artykuł wyjaśnia ograniczenia związane z polami metadanych `Application`, `Creator` i `Producer` w plikach PPTX i PDF.

## **Aplikacja i Producent**

Gdy tworzysz lub eksportujesz prezentacje przy użyciu Aspose.Slides for Python via .NET, niektóre dane techniczne są zapisywane w pliku. Dwa pola często budzą pytania:

**Application** identyfikuje program, który utworzył lub ostatnio zapisał prezentację **PPTX**. W Aspose.Slides for Python via .NET ta wartość jest stała i pokazuje dostawcę biblioteki zamiast nazwy Twojej aplikacji, nawet jeśli ustawisz [DocumentProperties.name_of_application](https://reference.aspose.com/slides/pl/python-net/aspose.slides/documentproperties/name_of_application/).

**Producer** identyfikuje silnik renderujący, który wygenerował ostateczny plik podczas eksportu. W eksportach **PDF** metadane używają pól **Creator** i **Producer**. W Aspose.Slides for Python via .NET oba te pola są stałe i odzwierciedlają bibliotekę oraz jej wersję.

**Co jest ograniczone**

Nie możesz nadpisać tych pól za pomocą API dla wymienionych formatów. Dla **PPTX** właściwość Application jest zapisywana jako "Aspose.Slides for Python via .NET". Dla **PDF** właściwości Creator i Producer są zapisywane jako "Aspose.Slides for Python via .NET x.x.x". To zachowanie jest zaprojektowane i obowiązuje niezależnie od tego, jak wczytujesz lub zapisujesz plik, oraz niezależnie od wartości przypisanych do [DocumentProperties.name_of_application](https://reference.aspose.com/slides/pl/python-net/aspose.slides/documentproperties/name_of_application/).