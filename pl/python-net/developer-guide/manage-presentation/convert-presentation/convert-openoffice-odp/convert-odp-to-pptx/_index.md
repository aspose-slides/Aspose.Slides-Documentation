---
title: "Konwertuj ODP do PPTX w Pythonie"
linktitle: "ODP do PPTX"
type: docs
weight: 10
url: /pl/python-net/convert-odp-to-pptx/
keywords:
- "konwertuj OpenDocument"
- "konwertuj ODP"
- "OpenDocument do PPTX"
- "ODP do PPTX"
- "OpenDocument"
- "prezentacja"
- "Python"
- "Aspose.Slides"
description: "Konwertuj ODP do PPTX przy użyciu Aspose.Slides dla Pythona via .NET. Czyste przykłady kodu, wskazówki dotyczące przetwarzania wsadowego i wyniki wysokiej jakości — nie wymaga PowerPointa."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak przekonwertować prezentację ODP do formatu PPTX przy użyciu Aspose.Slides.

## **Eksport ODP do PPTX**

Aspose.Slides dla Pythona via .NET udostępnia klasę Presentation, która reprezentuje plik prezentacji. [**Presentation**](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) klasa może teraz również uzyskać dostęp do ODP poprzez konstruktor Presentation, gdy obiekt jest tworzony. Poniższy przykład pokazuje, jak przekonwertować prezentację ODP do prezentacji PPTX.

```py
# Importuj Aspose.Slides dla Pythona via .NET
import aspose.slides as slides

# Otwórz plik ODP
pres = slides.Presentation("AccessOpenDoc.odp")

# Zapis prezentacji ODP do formatu PPTX
pres.save("AccessOpenDoc_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Przykład na żywo**

Możesz odwiedzić aplikację internetową [**Konwersja Aspose.Slides**](https://products.aspose.app/slides/pl/conversion/), która została zbudowana przy użyciu **API Aspose.Slides**. Aplikacja demonstruje, jak konwersję ODP do PPTX można zaimplementować przy użyciu API Aspose.Slides.

## **FAQ**

**Czy muszę instalować Microsoft PowerPoint lub LibreOffice, aby przekonwertować ODP do PPTX?**

Nie. Aspose.Slides działa samodzielnie i nie wymaga aplikacji firm trzecich do odczytu lub zapisu ODP/PPTX.

**Czy slajdy główne, układy i motywy są zachowywane podczas konwersji?**

Tak. Biblioteka używa pełnego modelu obiektowego prezentacji i zachowuje strukturę, w tym slajdy główne i układy, dzięki czemu projekt pozostaje poprawny po konwersji.

**Czy mogę konwertować pliki ODP chronione hasłem?**

Tak. Aspose.Slides obsługuje wykrywanie ochrony, otwieranie i pracę z [chronionymi prezentacjami](/slides/pl/python-net/password-protected-presentation/) (w tym ODP), gdy podasz hasło, a także konfigurowanie szyfrowania i dostęp do właściwości dokumentu.

**Czy Aspose.Slides nadaje się do usług konwersji w chmurze lub opartych na REST?**

Tak. Możesz używać lokalnej biblioteki we własnym backendzie lub [Aspose.Slides Cloud](https://products.aspose.cloud/slides/pl/family/) (REST API); obie opcje obsługują konwersję ODP → PPTX.