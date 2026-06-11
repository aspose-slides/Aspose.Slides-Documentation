---
title: Konwertuj ODP do PPTX w .NET
linktitle: ODP do PPTX
type: docs
weight: 10
url: /pl/net/convert-odp-to-pptx/
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
- .NET
- C#
- Aspose.Slides
description: "Konwertuj ODP do PPTX za pomocą Aspose.Slides dla .NET. Czyste przykłady kodu C#, wskazówki dotyczące przetwarzania wsadowego i wysokiej jakości wyniki — nie wymaga PowerPointa."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak przekonwertować prezentację ODP na format PPTX przy użyciu Aspose.Slides.

## **Konwersja ODP do PPTX**

Aspose.Slides dla .NET oferuje klasę Presentation, która reprezentuje plik prezentacji. Klasa [**Presentation**](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) może teraz również uzyskać dostęp do ODP poprzez konstruktor Presentation podczas tworzenia obiektu. Poniższy przykład pokazuje, jak przekonwertować prezentację ODP na prezentację PPTX.

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>Kroki: konwersja ODP do PPTX w C#</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>Kroki: konwersja ODP do PowerPoint w C#</strong></a>

```c#
// Otwórz plik ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");

// Zapisywanie prezentacji ODP w formacie PPTX
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```

## **Przykład na żywo**

Możesz odwiedzić aplikację internetową [**Aspose.Slides Conversion**](https://products.aspose.app/slides/pl/conversion/), zbudowaną przy użyciu **Aspose.Slides API.** Aplikacja pokazuje, jak można zaimplementować konwersję ODP do PPTX przy użyciu Aspose.Slides API.

## **FAQ**

**Czy muszę zainstalować Microsoft PowerPoint lub LibreOffice, aby przekształcić ODP do PPTX?**

Nie. Aspose.Slides działa samodzielnie i nie wymaga aplikacji innych firm do odczytu lub zapisu ODP/PPTX.

**Czy slajdy główne, układy i motywy są zachowywane podczas konwersji?**

Tak. Biblioteka używa pełnego modelu obiektowego prezentacji i zachowuje strukturę, w tym slajdy główne i układy, dzięki czemu projekt pozostaje prawidłowy po konwersji.

**Czy mogę konwertować pliki ODP chronione hasłem?**

Tak. Aspose.Slides obsługuje wykrywanie ochrony, otwieranie i pracę z [chronionymi prezentacjami](/slides/pl/net/password-protected-presentation/) (w tym ODP), gdy podasz hasło, a także konfigurowanie szyfrowania i dostęp do właściwości dokumentu.

**Czy Aspose.Slides jest odpowiedni do usług konwersji w chmurze lub opartych na REST?**

Tak. Możesz używać lokalnej biblioteki w swoim własnym backendzie lub [Aspose.Slides Cloud](https://products.aspose.cloud/slides/pl/family/) (REST API); obie opcje obsługują konwersję ODP → PPTX.