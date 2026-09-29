---
title: Ograniczenia metadanych wyjściowych
type: docs
weight: 320
url: /pl/java/api-limitations/
keywords:
- Ograniczenia API
- format eksportu
- aplikacja
- producent
- właściwości dokumentu
- metadane
- generator
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Aspose.Slides for Java zapisuje stałe metadane aplikacji, twórcy i producenta w zapisanych plikach PPTX, PDF i ODP, niezależnie od nazwy aplikacji, którą ustawisz."
---
## **Przegląd**

Podczas tworzenia lub eksportowania prezentacji przy użyciu Aspose.Slides do pliku wyjściowego zapisywane są pewne techniczne metadane. Ten artykuł wyjaśnia ograniczenia dotyczące pól metadanych `Application`, `Creator`, `Producer` oraz generator w plikach PPTX, PDF i ODP.

## **Aplikacja i producent**

Podczas tworzenia lub eksportowania prezentacji przy użyciu Aspose.Slides for Java niektóre techniczne metadane są zapisywane w pliku. Dwa pola często budzą pytania:

**Application** identyfikuje program, który utworzył lub ostatnio zapisał prezentację **PPTX**. W Aspose.Slides for Java wartość ta jest stała i pokazuje nazwę biblioteki, a nie nazwę Twojej aplikacji, nawet jeśli używasz [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/pl/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

**Producer** identyfikuje silnik renderujący, który wygenerował ostateczny plik podczas eksportu. W eksportach **PDF** metadane używają pól **Creator** i **Producer**. W Aspose.Slides for Java oba te pola są stałe i odzwierciedlają bibliotekę oraz jej wersję.

**Co jest ograniczone**

Nie możesz nadpisać tych pól za pomocą API dla wymienionych formatów. Dla **PPTX** właściwość Application jest zapisywana jako „Aspose.Slides for Java”. Dla **PDF** właściwości Creator i Producer są zapisywane jako „Aspose.Slides for Java” z dopiskiem wersji biblioteki. Dla **ODP** pole generator jest zapisywane jako „Aspose.Slides for Java” z dopiskiem wersji biblioteki. To zachowanie jest zamierzone i obowiązuje niezależnie od sposobu wczytywania lub zapisywania pliku oraz niezależnie od wartości przypisanych za pomocą [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/pl/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

To ograniczenie nie dotyczy plików **PPT**: w pliku PPT nazwa aplikacji ustawiona za pomocą [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/pl/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) jest zapisywana.