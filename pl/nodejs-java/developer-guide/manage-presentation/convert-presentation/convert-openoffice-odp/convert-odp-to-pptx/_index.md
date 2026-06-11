---
title: Konwertuj ODP do PPTX w JavaScript
linktitle: ODP do PPTX
type: docs
weight: 10
url: /pl/nodejs-java/convert-odp-to-pptx/
keywords:
- konwertuj OpenDocument
- konwertuj prezentację
- konwertuj slajd
- konwertuj ODP
- OpenDocument do PPTX
- ODP do PPTX
- zapisz ODP jako PPTX
- eksportuj ODP do PPTX
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Konwertuj ODP do PPTX przy użyciu Aspose.Slides dla Node.js. Czyste przykłady kodu JavaScript, wskazówki dotyczące wsadowego przetwarzania i wysokiej jakości wyniki — nie potrzebujesz PowerPointa."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak przekonwertować prezentację ODP do formatu PPTX przy użyciu Aspose.Slides.

## **Konwersja prezentacji ODP do PPTX/PPT**
Aspose.Slides dla Node.js via Java oferuje klasę [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation), która reprezentuje plik prezentacji. Klasa [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) może teraz również uzyskać dostęp do ODP poprzez konstruktor [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#Presentation-java.lang.String-), gdy obiekt jest tworzony. Poniższy przykład pokazuje, jak przekonwertować prezentację ODP do prezentacji PPTX.

```javascript
// Otwórz plik ODP
var pres = new aspose.slides.Presentation("AccessOpenDoc.odp");
// Zapis prezentacji ODP w formacie PPTX
pres.save("AccessOpenDoc_out.pptx", aspose.slides.SaveFormat.Pptx);
```

## **Przykład na żywo**
Możesz odwiedzić aplikację webową [**Aspose.Slides Conversion**](https://products.aspose.app/slides/pl/conversion/), która została zbudowana przy użyciu **Aspose.Slides API**. Aplikacja demonstruje, jak można zaimplementować konwersję ODP do PPTX przy użyciu Aspose.Slides API.

## **FAQ**

**Czy muszę zainstalować Microsoft PowerPoint lub LibreOffice, aby przekonwertować ODP do PPTX?**

Nie. Aspose.Slides działa samodzielnie i nie wymaga aplikacji firm trzecich do odczytu lub zapisu ODP/PPTX.

**Czy slajdy główne, układy i motywy są zachowywane podczas konwersji?**

Tak. Biblioteka używa pełnego modelu obiektu prezentacji i zachowuje strukturę, w tym slajdy główne i układy, dzięki czemu projekt pozostaje poprawny po konwersji.

**Czy mogę konwertować pliki ODP zabezpieczone hasłem?**

Tak. Aspose.Slides obsługuje wykrywanie ochrony, otwieranie i pracę z [chronionymi prezentacjami](/slides/pl/nodejs-java/password-protected-presentation/) (w tym ODP), gdy podasz hasło, a także konfigurowanie szyfrowania i dostęp do właściwości dokumentu.

**Czy Aspose.Slides nadaje się do usług konwersji w chmurze lub opartych na REST?**

Tak. Możesz używać lokalnej biblioteki w własnym backendzie lub [Aspose.Slides Cloud](https://products.aspose.cloud/slides/pl/family/) (REST API); oba rozwiązania obsługują konwersję ODP → PPTX.