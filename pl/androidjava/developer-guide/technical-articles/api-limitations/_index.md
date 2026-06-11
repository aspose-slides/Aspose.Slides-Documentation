---
title: Ograniczenia API
type: docs
weight: 320
url: /pl/androidjava/api-limitations/
keywords:
- ograniczenia API
- format eksportu
- aplikacja
- producent
- właściwości dokumentu
- metadane
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Poznaj ograniczenia Aspose.Slides for Android: eksporty ustawiają stałe metadane Application/Producer w plikach PPT, PPTX, ODP i PDF—pomagając zaplanować integracje bez niespodzianek."
---
## **Przegląd**

Gdy prezentacje są tworzone lub eksportowane przy użyciu Aspose.Slides, określone metadane techniczne są zapisywane w pliku wyjściowym. Ten artykuł wyjaśnia ograniczenia związane z polami metadanych `Application`, `Creator` i `Producer` w plikach PPTX i PDF.

## **Application i Producer**

Gdy tworzysz lub eksportujesz prezentacje za pomocą Aspose.Slides for Android via Java, niektóre metadane techniczne są zapisywane w pliku. Dwa pola często budzą pytania:

**Application** identyfikuje program, który utworzył lub ostatnio zapisał prezentację **PPTX**. W Aspose.Slides for Android via Java wartość ta jest stała i pokazuje dostawcę biblioteki zamiast nazwy Twojej aplikacji, nawet jeśli używasz [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

**Producer** identyfikuje silnik renderujący, który wygenerował ostateczny plik podczas eksportu. W eksportach **PDF** metadane używają pól **Creator** i **Producer**. W Aspose.Slides for Android via Java oba te pola są stałe i odzwierciedlają bibliotekę oraz jej wersję.

**Co jest ograniczone**

Nie możesz nadpisać tych pól za pomocą API dla wymienionych formatów. Dla **PPTX** właściwość Application jest zapisywana jako "Aspose.Slides for Android via Java". Dla **PDF** właściwości Creator i Producer są zapisywane jako "Aspose.Slides for Android via Java x.x.x.". To zachowanie jest zaprojektowane i obowiązuje niezależnie od tego, jak załadujesz lub zapiszesz plik, oraz niezależnie od wartości przypisanych przy użyciu [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).