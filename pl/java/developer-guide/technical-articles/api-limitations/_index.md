---
title: Ograniczenia API
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
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Poznaj ograniczenia Aspose.Slides for Java: eksporty ustawiają stałe metadane Application/Producer w plikach PPT, PPTX, ODP i PDF — pomagając w planowaniu integracji bez niespodzianek."
---
## **Przegląd**

Podczas tworzenia lub eksportowania prezentacji przy użyciu Aspose.Slides do pliku zapisywane są pewne techniczne metadane. Ten artykuł wyjaśnia ograniczenia związane z polami metadanych `Application`, `Creator` i `Producer` w plikach PPTX i PDF.

## **Application i Producer**

Podczas tworzenia lub eksportowania prezentacji przy użyciu Aspose.Slides for Java do pliku zapisywane są niektóre techniczne metadane. Dwa pola często budzą pytania:

**Application** identyfikuje program, który utworzył lub ostatnio zapisał prezentację **PPTX**. W Aspose.Slides for Java wartość ta jest stała i pokazuje dostawcę biblioteki zamiast nazwy Twojej aplikacji, nawet jeśli używasz [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/pl/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

**Producer** identyfikuje silnik renderujący, który wygenerował ostateczny plik podczas eksportu. W eksportach **PDF** metadane używają pól **Creator** i **Producer**. W Aspose.Slides for Java oba te pola są stałe i odzwierciedlają bibliotekę oraz jej wersję.

**Co jest ograniczone**

Nie możesz nadpisać tych pól za pomocą API dla wymienionych formatów. Dla **PPTX** właściwość Application jest zapisywana jako „Aspose.Slides for Java”. Dla **PDF** właściwości Creator i Producer są zapisywane jako „Aspose.Slides for Java x.x.x.”. Takie zachowanie jest zamierzone i obowiązuje niezależnie od tego, jak wczytujesz lub zapisujesz plik, oraz niezależnie od wartości przypisanych przy użyciu [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/pl/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).