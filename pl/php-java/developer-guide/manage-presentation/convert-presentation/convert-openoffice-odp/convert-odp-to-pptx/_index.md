---
title: Konwertuj ODP do PPTX w PHP
linktitle: ODP do PPTX
type: docs
weight: 10
url: /pl/php-java/convert-odp-to-pptx/
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
- PHP
- Aspose.Slides
description: "Konwertuj ODP do PPTX przy użyciu Aspose.Slides dla PHP przez Java. Czyste przykłady kodu, porady dotyczące przetwarzania wsadowego i wyniki wysokiej jakości — nie wymaga PowerPointa."
---
## **Overview**

Ten artykuł wyjaśnia, jak przekonwertować prezentację ODP na format PPTX przy użyciu Aspose.Slides.

## **Convert ODP to PPTX/PPT Presentation**
Aspose.Slides for PHP via Java oferuje klasę [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation) reprezentującą plik prezentacji. Klasa [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation) może teraz również uzyskać dostęp do ODP poprzez konstruktor [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation#Presentation-java.lang.String-) kiedy obiekt jest tworzony. Poniższy przykład pokazuje, jak przekonwertować prezentację ODP na prezentację PPTX.

```php
// Otwórz plik ODP
  $pres = new Presentation("AccessOpenDoc.odp");
  try {
  } finally {
  }
  # Zapisywanie prezentacji ODP do formatu PPTX
  $pres->save("AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```

## **Live Example**
Możesz odwiedzić aplikację internetową [**Aspose.Slides Conversion**](https://products.aspose.app/slides/pl/conversion/) zbudowaną przy użyciu **Aspose.Slides API**. Aplikacja demonstruje, jak można zaimplementować konwersję ODP do PPTX przy użyciu Aspose.Slides API.

## **FAQ**

**Do I need to install Microsoft PowerPoint or LibreOffice to convert ODP to PPTX?**

Nie. Aspose.Slides działa samodzielnie i nie wymaga aplikacji firm trzecich do odczytu lub zapisu ODP/PPTX.

**Are master slides, layouts, and themes preserved during conversion?**

Tak. Biblioteka używa pełnego modelu obiektowego prezentacji i zachowuje strukturę, w tym slajdy główne i układy, więc projekt pozostaje prawidłowy po konwersji.

**Can I convert password-protected ODP files?**

Tak. Aspose.Slides obsługuje wykrywanie zabezpieczeń, otwieranie i pracę z [protected presentations](/slides/pl/php-java/password-protected-presentation/) (w tym ODP), gdy podasz hasło, a także konfigurowanie szyfrowania i dostęp do właściwości dokumentu.

**Is Aspose.Slides suitable for cloud or REST-based conversion services?**

Tak. Możesz używać lokalnej biblioteki w własnym backendzie lub [Aspose.Slides Cloud](https://products.aspose.cloud/slides/pl/family/) (REST API); oba rozwiązania obsługują konwersję ODP → PPTX.