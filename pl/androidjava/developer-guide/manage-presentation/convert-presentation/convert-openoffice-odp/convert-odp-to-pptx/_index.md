---
title: Przekształć ODP na PPTX na Androidzie
linktitle: ODP na PPTX
type: docs
weight: 10
url: /pl/androidjava/convert-odp-to-pptx/
keywords:
- konwertuj OpenDocument
- konwertuj prezentację
- konwertuj slajd
- konwertuj ODP
- OpenDocument na PPTX
- ODP na PPTX
- zapisz ODP jako PPTX
- eksportuj ODP do PPTX
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Konwertuj ODP na PPTX przy użyciu Aspose.Slides dla Androida. Czyste przykłady kodu Java, wskazówki dotyczące przetwarzania wsadowego i wysokiej jakości wyniki — PowerPoint nie jest wymagany."
---
## **Overview**

Ten artykuł wyjaśnia, jak przekonwertować prezentację ODP na format PPTX przy użyciu Aspose.Slides.

## **Convert ODP to PPTX/PPT Presentation**
Aspose.Slides dla Androida za pośrednictwem Java udostępnia klasę [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) reprezentującą plik prezentacji. Klasa [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) może teraz również uzyskiwać dostęp do ODP poprzez konstruktor [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#Presentation-java.lang.String-) kiedy obiekt jest tworzony. Poniższy przykład pokazuje, jak przekonwertować prezentację ODP na prezentację PPTX.

```java
// Otwórz plik ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// Zapisanie prezentacji ODP w formacie PPTX
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Live Example**
Możesz odwiedzić aplikację internetową [**Aspose.Slides Conversion**](https://products.aspose.app/slides/pl/conversion/), która została zbudowana przy użyciu **Aspose.Slides API**. Aplikacja demonstruje, jak konwersję ODP na PPTX można zaimplementować przy użyciu Aspose.Slides API.

## **FAQ**

**Do I need to install Microsoft PowerPoint or LibreOffice to convert ODP to PPTX?**

Nie. Aspose.Slides działa samodzielnie i nie wymaga aplikacji firm trzecich do odczytu lub zapisu ODP/PPTX.

**Are master slides, layouts, and themes preserved during conversion?**

Tak. Biblioteka używa pełnego modelu obiektowego prezentacji i zachowuje strukturę, w tym slajdy główne i układy, dzięki czemu projekt pozostaje prawidłowy po konwersji.

**Can I convert password-protected ODP files?**

Tak. Aspose.Slides obsługuje wykrywanie ochrony, otwieranie i pracę z [protected presentations](/slides/pl/androidjava/password-protected-presentation/) (w tym ODP) po podaniu hasła, a także konfigurowanie szyfrowania i dostęp do właściwości dokumentu.

**Is Aspose.Slides suitable for cloud or REST-based conversion services?**

Tak. Możesz używać lokalnej biblioteki w własnym backendzie lub [Aspose.Slides Cloud](https://products.aspose.cloud/slides/pl/family/) (REST API); oba rozwiązania obsługują konwersję ODP → PPTX.