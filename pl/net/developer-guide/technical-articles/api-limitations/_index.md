---
title: Ograniczenia metadanych wyjściowych
type: docs
weight: 320
url: /pl/net/api-limitations/
keywords:
- ograniczenia API
- format eksportu
- aplikacja
- producent
- właściwości dokumentu
- metadane
- generator
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides dla .NET zapisuje stałe metadane aplikacji, twórcy i producenta w zapisanych plikach PPTX, PDF i ODP, niezależnie od ustawionej nazwy aplikacji."
---
## **Przegląd**

Podczas tworzenia lub eksportowania prezentacji przy użyciu Aspose.Slides, pewne techniczne metadane są zapisywane w pliku wyjściowym. Ten artykuł wyjaśnia ograniczenia dotyczące pól metadanych `Application`, `Creator`, `Producer` oraz generator w plikach PPTX, PDF i ODP.

## **Aplikacja i Producent**

Podczas tworzenia lub eksportowania prezentacji przy użyciu Aspose.Slides for .NET, niektóre techniczne metadane są zapisywane w pliku. Dwa pola często budzą pytania:

**Application** określa program, który utworzył lub ostatnio zapisał prezentację **PPTX**. W Aspose.Slides for .NET ta wartość jest stała i wyświetla nazwę biblioteki zamiast nazwy Twojej aplikacji, nawet jeśli ustawisz [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/pl/net/aspose.slides/documentproperties/nameofapplication/).

**Producer** określa silnik renderujący, który wygenerował ostateczny plik podczas eksportu. W eksportach **PDF** metadane używają pól **Creator** i **Producer**. W Aspose.Slides for .NET oba te pola są stałe i odzwierciedlają bibliotekę oraz jej wersję.

**Co jest ograniczone**

Nie możesz nadpisać tych pól za pomocą API dla wymienionych formatów. Dla **PPTX** właściwość Application jest zapisywana jako „Aspose.Slides for .NET”. Dla **PDF** właściwości Creator i Producer są zapisywane jako „Aspose.Slides for .NET” z wersją biblioteki. Dla **ODP** pole generator jest zapisywane jako „Aspose.Slides for .NET” z wersją biblioteki. Takie zachowanie jest zamierzone i obowiązuje niezależnie od tego, jak wczytujesz lub zapisujesz plik, oraz niezależnie od wartości przypisanych do [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/pl/net/aspose.slides/documentproperties/nameofapplication/).

To ograniczenie nie dotyczy plików **PPT**: w pliku PPT nazwa aplikacji, którą ustawiłeś w [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/pl/net/aspose.slides/documentproperties/nameofapplication/), jest zapisywana.