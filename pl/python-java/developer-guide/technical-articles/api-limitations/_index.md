---
title: Ograniczenia API
type: docs
weight: 320
url: /pl/python-java/api-limitations/
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
- Java
- Aspose.Slides
description: "Dowiedz się o ograniczeniach Aspose.Slides dla Pythona via Java: stałe metadane Application, Creator i Producer w plikach PPTX i PDF."
---
## **Przegląd**

Gdy prezentacje są tworzone lub eksportowane przy użyciu Aspose.Slides, pewne techniczne metadane są zapisywane w pliku wyjściowym. Ten artykuł wyjaśnia ograniczenia związane z polami metadanych `Application`, `Creator` i `Producer` w plikach PPTX i PDF.

## **Application i Producer**

Gdy tworzysz lub eksportujesz prezentacje przy użyciu Aspose.Slides dla Pythona via Java, pewne techniczne metadane są zapisywane w pliku. Dwa pola często budzą pytania:

**Application** określa program, który utworzył lub ostatnio zapisał prezentację **PPTX**. W Aspose.Slides dla Pythona via Java ta wartość jest stała i pokazuje dostawcę biblioteki zamiast nazwy Twojej aplikacji, nawet jeśli używasz [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/pl/python-java/aspose.slides/documentproperties/#setnameofapplication).

**Producer** określa silnik renderujący, który wygenerował ostateczny plik podczas eksportu. W eksportach **PDF** metadane używają pól **Creator** i **Producer**. W Aspose.Slides dla Pythona via Java oba te pola są stałe i odzwierciedlają bibliotekę oraz jej wersję.

**Co jest ograniczone**

Nie możesz nadpisać tych pól przy użyciu API dla wymienionych formatów. Dla **PPTX** właściwość Application jest zapisywana jako "Aspose.Slides for Java". Dla **PDF** właściwości Creator i Producer są zapisywane jako "Aspose.Slides for Java x.x.x." To zachowanie jest zaprojektowane i obowiązuje niezależnie od tego, jak wczytujesz lub zapisujesz plik, oraz niezależnie od wartości przypisanych przy użyciu [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/pl/python-java/aspose.slides/documentproperties/#setnameofapplication).

## **FAQ**

**Czy mogę zastąpić wartość Application w pliku PPTX nazwą mojej aplikacji?**

Nie. Wartość jest stała, nawet jeśli używasz [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/pl/python-java/aspose.slides/documentproperties/#setnameofapplication).

**Czy mogę nadpisać pola Creator i Producer w eksportach PDF?**

Nie. Oba pola są stałe i odzwierciedlają bibliotekę oraz jej wersję, niezależnie od tego, jak wczytujesz lub zapisujesz prezentację.