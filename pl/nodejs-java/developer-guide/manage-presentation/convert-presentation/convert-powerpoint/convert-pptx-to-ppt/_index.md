---
title: Konwertuj PPTX do PPT w JavaScript
linktitle: PPTX do PPT
type: docs
weight: 21
url: /pl/nodejs-java/convert-pptx-to-ppt/
keywords:
- konwertować PowerPoint
- konwertować prezentację
- konwertować slajd
- konwertować PPTX
- PPTX do PPT
- zapisz PPTX jako PPT
- eksportuj PPTX do PPT
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Łatwo konwertuj PPTX do PPT za pomocą Aspose.Slides - zapewnij płynną zgodność z formatami PowerPoint, zachowując układ i jakość swojej prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentację PowerPoint w formacie PPTX do formatu PPT przy użyciu JavaScript. Omówiony jest następujący temat.

- Konwersja PPTX do PPT w JavaScript

## **Java konwersja PPTX do PPT**

Aby uzyskać przykładowy kod JavaScript konwertujący PPTX do PPT, zobacz sekcję poniżej, tj. [Convert PPTX to PPT](#convert-pptx-to-ppt). Ładuje on po prostu plik PPTX i zapisuje w formacie PPT. Określając różne formaty zapisu, możesz także zapisać plik PPTX w wielu innych formatach, takich jak PDF, XPS, ODP, HTML itp., jak opisano w tych artykułach. 

- [Konwersja PPTX do PDF w JavaScript](/slides/pl/nodejs-java/convert-powerpoint-to-pdf/)
- [Konwersja PPTX do XPS w JavaScript](/slides/pl/nodejs-java/convert-powerpoint-to-xps/)
- [Konwersja PPTX do HTML w JavaScript](/slides/pl/nodejs-java/convert-powerpoint-to-html/)
- [Konwersja PPTX do ODP w JavaScript](/slides/pl/nodejs-java/save-presentation/)
- [Konwersja PPTX do PNG w JavaScript](/slides/pl/nodejs-java/convert-powerpoint-to-png/)

## **Konwersja PPTX do PPT**

Aby przekonwertować PPTX do PPT, wystarczy przekazać nazwę pliku i format zapisu do metody **Save** klasy [**Presentation**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation). Poniższy przykład kodu JavaScript konwertuje prezentację z PPTX na PPT przy użyciu domyślnych opcji.

```javascript
// utwórz obiekt Presentation reprezentujący plik PPTX
var presentation = new aspose.slides.Presentation("template.pptx");
// zapisz prezentację jako PPT
presentation.save("output.ppt", aspose.slides.SaveFormat.Ppt);
```

## **FAQ**

**Czy wszystkie efekty i funkcje PPTX są zachowywane przy zapisywaniu w starszym formacie PPT (97–2003)?**

Nie zawsze. Format PPT nie obsługuje niektórych nowszych możliwości (np. niektórych efektów, obiektów i zachowań), dlatego funkcje mogą być uproszczone lub zrastrowane podczas konwersji.

**Czy mogę przekonwertować tylko wybrane slajdy do PPT zamiast całej prezentacji?**

Bezpośrednie zapisanie dotyczy całej prezentacji. Aby przekonwertować konkretne slajdy, utwórz nową prezentację zawierającą tylko te slajdy i zapisz ją jako PPT; alternatywnie użyj usługi/API, które obsługuje parametry konwersji na poziomie slajdu.

**Czy obsługiwane są prezentacje zabezpieczone hasłem?**

Tak. Możesz wykryć, czy plik jest zabezpieczony, otworzyć go przy użyciu hasła oraz także [skonfigurować ustawienia ochrony/szyfrowania](/slides/pl/nodejs-java/password-protected-presentation/) dla zapisanego pliku PPT.