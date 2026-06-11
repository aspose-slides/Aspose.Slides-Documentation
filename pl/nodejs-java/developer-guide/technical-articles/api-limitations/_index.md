---
title: Ograniczenia API
type: docs
weight: 320
url: /pl/nodejs-java/api-limitations/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Znajdź ograniczenia Aspose.Slides for Node.js: eksporty ustawiają stałe metadane Application/Producer w PPT, PPTX, ODP i PDF — pomagając planować integracje bez niespodzianek."
---
## **Przegląd**

Podczas tworzenia lub eksportowania prezentacji przy użyciu Aspose.Slides, do pliku wyjściowego zapisywane są pewne techniczne metadane. Ten artykuł wyjaśnia ograniczenia dotyczące pól metadanych `Application`, `Creator` i `Producer` w plikach PPTX i PDF.

## **Application i Producer**

Podczas tworzenia lub eksportowania prezentacji przy użyciu Aspose.Slides for Node.js via Java, do pliku zapisywane są pewne techniczne metadane. Dwa pola często budzą pytania:

**Application** określa program, który utworzył lub ostatnio zapisał prezentację **PPTX**. W Aspose.Slides for Node.js via Java ta wartość jest stała i wyświetla dostawcę biblioteki zamiast nazwy Twojej aplikacji, nawet jeśli używasz [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/setnameofapplication/).

**Producer** identyfikuje silnik renderujący, który wygenerował ostateczny plik podczas eksportu. W eksportach **PDF** metadane używają pól **Creator** i **Producer**. W Aspose.Slides for Node.js via Java oba te pola są stałe i odzwierciedlają bibliotekę oraz jej wersję.

**Co jest ograniczone**

Nie możesz nadpisać tych pól za pomocą API dla wymienionych formatów. Dla **PPTX** właściwość Application jest zapisywana jako "Aspose.Slides for Node.js via Java". Dla **PDF** właściwości Creator i Producer są zapisywane jako "Aspose.Slides for Node.js via Java x.x.x." To zachowanie jest zamierzone i obowiązuje bez względu na sposób wczytania lub zapisu pliku oraz niezależnie od wartości przypisanych przy użyciu [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/setnameofapplication/).