---
title: Konwertuj ODP do PPTX w C++
linktitle: ODP do PPTX
type: docs
weight: 10
url: /pl/cpp/convert-odp-to-pptx/
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
- C++
- Aspose.Slides
description: "Konwertuj ODP do PPTX przy użyciu Aspose.Slides dla C++. Czyste przykłady kodu, wskazówki dotyczące wsadowego przetwarzania i wysokiej jakości rezultaty - nie wymaga PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak przekonwertować prezentację ODP do formatu PPTX przy użyciu Aspose.Slides.

## **Konwersja ODP do PPTX**

Aspose.Slides dla .NET udostępnia klasę Presentation, która reprezentuje plik prezentacji. [**Presentation**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation) klasa może teraz także uzyskać dostęp do ODP poprzez konstruktor Presentation podczas tworzenia obiektu. Poniższy przykład pokazuje, jak przekonwertować prezentację ODP na prezentację PPTX.

``` cpp
// Ścieżka do katalogu dokumentów.
String dataDir = GetDataPath();

// Otwórz plik ODP
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// Zapisywanie prezentacji ODP w formacie PPTX
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```

## **Przykład na żywo**

Możesz odwiedzić aplikację webową [**Aspose.Slides Conversion**](https://products.aspose.app/slides/pl/conversion/), która została zbudowana przy użyciu **Aspose.Slides API.** Aplikacja demonstruje, jak można zaimplementować konwersję ODP do PPTX przy użyciu Aspose.Slides API.

## **Najczęściej zadawane pytania**

**Czy muszę zainstalować Microsoft PowerPoint lub LibreOffice, aby przekonwertować ODP na PPTX?**

Nie. Aspose.Slides działa samodzielnie i nie wymaga aplikacji firm trzecich do odczytu lub zapisu ODP/PPTX.

**Czy slajdy master, układy i motywy są zachowywane podczas konwersji?**

Tak. Biblioteka używa pełnego modelu obiektu prezentacji i zachowuje strukturę, w tym slajdy master i układy, dzięki czemu projekt pozostaje prawidłowy po konwersji.

**Czy mogę konwertować pliki ODP chronione hasłem?**

Tak. Aspose.Slides obsługuje wykrywanie ochrony, otwieranie i pracę z [chronionymi prezentacjami](/slides/pl/cpp/password-protected-presentation/) (w tym ODP), gdy podasz hasło, a także konfigurowanie szyfrowania i dostęp do właściwości dokumentu.

**Czy Aspose.Slides jest odpowiedni do usług konwersji w chmurze lub opartych na REST?**

Tak. Możesz używać lokalnej biblioteki w własnym backendzie lub [Aspose.Slides Cloud](https://products.aspose.cloud/slides/pl/family/) (REST API); obie opcje obsługują konwersję ODP → PPTX.