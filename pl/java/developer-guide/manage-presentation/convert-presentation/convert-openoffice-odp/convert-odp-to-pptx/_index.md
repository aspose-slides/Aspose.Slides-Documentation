---
title: Konwertuj ODP do PPTX w Javie
linktitle: ODP do PPTX
type: docs
weight: 10
url: /pl/java/convert-odp-to-pptx/
keywords:
- konwertuj OpenDocument
- konwertuj prezentację
- konwertuj slajd
- konwertuj ODP
- OpenDocument do PPTX
- ODP do PPTX
- zapisz ODP jako PPTX
- wyeksportuj ODP do PPTX
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Konwertuj ODP do PPTX przy użyciu Aspose.Slides for Java. Czyste przykłady kodu w Javie, wskazówki dotyczące przetwarzania wsadowego i wysokiej jakości wyniki - nie wymaga PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak przekonwertować prezentację ODP do formatu PPTX przy użyciu Aspose.Slides.

## **Konwertuj ODP do prezentacji PPTX/PPT**
Aspose.Slides for Java udostępnia klasę [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation), która reprezentuje plik prezentacji. Klasa [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation) może teraz również uzyskać dostęp do ODP poprzez konstruktor [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation#Presentation-java.lang.String-) przy tworzeniu obiektu. Poniższy przykład pokazuje, jak przekonwertować prezentację ODP na prezentację PPTX.

```java
// Otwórz plik ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// Zapisywanie prezentacji ODP w formacie PPTX
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Przykład na żywo**
Możesz odwiedzić [**Aspose.Slides Conversion**](https://products.aspose.app/slides/pl/conversion/) aplikację internetową, zbudowaną przy użyciu **Aspose.Slides API.** Aplikacja demonstruje, jak można zaimplementować konwersję ODP do PPTX przy użyciu Aspose.Slides API.

## **FAQ**

**Czy muszę zainstalować Microsoft PowerPoint lub LibreOffice, aby konwertować ODP do PPTX?**

Nie. Aspose.Slides działa samodzielnie i nie wymaga aplikacji firm trzecich do odczytu lub zapisu ODP/PPTX.

**Czy slajdy master, układy i motywy są zachowywane podczas konwersji?**

Tak. Biblioteka używa pełnego modelu obiektu prezentacji i zachowuje strukturę, w tym slajdy master i układy, więc projekt pozostaje prawidłowy po konwersji.

**Czy mogę konwertować pliki ODP chronione hasłem?**

Tak. Aspose.Slides obsługuje wykrywanie zabezpieczeń, otwieranie i pracę z [chronionymi prezentacjami](/slides/pl/java/password-protected-presentation/) (w tym ODP), gdy podasz hasło, a także konfigurowanie szyfrowania i dostęp do właściwości dokumentu.

**Czy Aspose.Slides nadaje się do usług konwersji w chmurze lub opartych na REST?**

Tak. Możesz używać lokalnej biblioteki w własnym backendzie lub [Aspose.Slides Cloud](https://products.aspose.cloud/slides/pl/family/) (REST API); obie opcje obsługują konwersję ODP → PPTX.