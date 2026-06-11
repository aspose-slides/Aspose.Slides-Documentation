---
title: Ograniczenia API
type: docs
weight: 320
url: /pl/cpp/api-limitations/
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
- C++
- Aspose.Slides
description: "Poznaj ograniczenia Aspose.Slides for C++: eksporty ustawiają stałe metadane Application/Producer w formatach PPT, PPTX, ODP i PDF — pomagając Ci planować integracje bez niespodzianek."
---
## **Przegląd**

Kiedy prezentacje są tworzone lub eksportowane przy użyciu Aspose.Slides, do pliku wyjściowego zapisywane są pewne techniczne metadane. Ten artykuł wyjaśnia ograniczenia związane z polami metadanych `Application`, `Creator` i `Producer` w plikach PPTX i PDF.

## **Application i Producer**

Kiedy tworzysz lub eksportujesz prezentacje przy użyciu Aspose.Slides for C++, pewne techniczne metadane są zapisywane w pliku. Dwa pola często budzą pytania:

**Application** identyfikuje program, który utworzył lub ostatnio zapisał prezentację **PPTX**. W Aspose.Slides for C++ ta wartość jest stała i wskazuje dostawcę biblioteki, a nie nazwę Twojej aplikacji, nawet jeśli używasz [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/pl/cpp/aspose.slides/documentproperties/set_nameofapplication/).

**Producer** identyfikuje silnik renderujący, który wygenerował ostateczny plik podczas eksportu. W eksportach **PDF** metadane używają pól **Creator** i **Producer**. W Aspose.Slides for C++ oba te pola są stałe i odzwierciedlają bibliotekę oraz jej wersję.

**Co jest ograniczone**

Nie możesz nadpisać tych pól za pomocą API dla wymienionych formatów. Dla **PPTX** właściwość Application jest zapisywana jako "Aspose.Slides for C++". Dla **PDF** właściwości Creator i Producer są zapisywane jako "Aspose.Slides for C++ x.x.x". To zachowanie jest zamierzone i obowiązuje niezależnie od tego, w jaki sposób wczytujesz lub zapisujesz plik, oraz niezależnie od wartości przypisanych przy użyciu [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/pl/cpp/aspose.slides/documentproperties/set_nameofapplication/).