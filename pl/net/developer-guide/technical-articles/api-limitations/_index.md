---
title: Ograniczenia API
type: docs
weight: 320
url: /pl/net/api-limitations/
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
- .NET
- C#
- Aspose.Slides
description: "Poznaj ograniczenia Aspose.Slides for .NET: eksporty ustawiają stałe metadane Application/Producer w plikach PPT, PPTX, ODP i PDF—pomagając planować integracje bez niespodzianek."
---
## **Przegląd**

Kiedy prezentacje są tworzone lub eksportowane przy użyciu Aspose.Slides, pewne techniczne metadane są zapisywane w pliku wyjściowym. Ten artykuł wyjaśnia ograniczenia dotyczące pól metadanych `Application`, `Creator` i `Producer` w plikach PPTX i PDF.

## **Application i Producer**

Kiedy tworzysz lub eksportujesz prezentacje przy użyciu Aspose.Slides for .NET, niektóre techniczne metadane są zapisywane w pliku. Dwa pola często budzą pytania:

**Application** identyfikuje program, który utworzył lub ostatnio zapisał prezentację **PPTX**. W Aspose.Slides for .NET wartość ta jest stała i pokazuje dostawcę biblioteki, a nie nazwę Twojej aplikacji, nawet jeśli ustawisz [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/pl/net/aspose.slides/documentproperties/nameofapplication/).

**Producer** identyfikuje silnik renderujący, który wygenerował finalny plik podczas eksportu. W eksportach **PDF** metadane używają pól **Creator** i **Producer**. W Aspose.Slides for .NET oba te pola są stałe i odzwierciedlają bibliotekę oraz jej wersję.

**Co jest ograniczone**

Nie możesz nadpisać tych pól za pomocą API dla powyższych formatów. Dla **PPTX** właściwość Application jest zapisywana jako "Aspose.Slides for .NET". Dla **PDF** właściwości Creator i Producer są zapisywane jako "Aspose.Slides for .NET x.x.x". To zachowanie jest zamierzone i obowiązuje niezależnie od tego, w jaki sposób wczytujesz lub zapisujesz plik oraz niezależnie od wartości przypisanych do [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/pl/net/aspose.slides/documentproperties/nameofapplication/).