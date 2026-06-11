---
title: Konwertowanie PPTX do PPT w PHP
linktitle: PPTX do PPT
type: docs
weight: 21
url: /pl/php-java/convert-pptx-to-ppt/
keywords:
- konwertowanie PowerPoint
- konwertowanie prezentacji
- konwertowanie slajdu
- konwertowanie PPTX
- PPTX do PPT
- zapisz PPTX jako PPT
- eksportuj PPTX do PPT
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Łatwo konwertuj PPTX do PPT przy użyciu Aspose.Slides — zapewnij płynną kompatybilność z formatami PowerPoint, zachowując układ i jakość swojej prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentację PowerPoint w formacie PPTX do formatu PPT przy użyciu PHP. Omówiony jest następujący temat.

- Konwertowanie PPTX na PPT

## **Konwertowanie PPTX na PPT w PHP**

Przykładowy kod w Javie do konwersji PPTX na PPT znajdziesz w sekcji poniżej, tj. [Convert PPTX to PPT](#convert-pptx-to-ppt). Po prostu ładuje plik PPTX i zapisuje go w formacie PPT. Określając różne formaty zapisu, możesz także zapisać plik PPTX w wielu innych formatach, takich jak PDF, XPS, ODP, HTML itp., jak omówiono w tych artykułach.

- [Konwertowanie PPTX do PDF w PHP](/slides/pl/php-java/convert-powerpoint-to-pdf/)
- [Konwertowanie PPTX do XPS w PHP](/slides/pl/php-java/convert-powerpoint-to-xps/)
- [Konwertowanie PPTX do HTML w PHP](/slides/pl/php-java/convert-powerpoint-to-html/)
- [Konwertowanie PPTX do ODP w PHP](/slides/pl/php-java/save-presentation/)
- [Konwertowanie PPTX do PNG w PHP](/slides/pl/php-java/convert-powerpoint-to-png/)

## **Konwertowanie PPTX na PPT**
Aby skonwertować PPTX na PPT, po prostu przekaż nazwę pliku i format zapisu do metody **Save** klasy [**Presentation**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation). Poniższy przykład kodu PHP konwertuje prezentację z PPTX na PPT przy użyciu domyślnych opcji.

```php
  # utwórz obiekt Presentation, który reprezentuje plik PPTX
  $presentation = new Presentation("template.pptx");
  # zapisz prezentację jako PPT
  $presentation->save("output.ppt", SaveFormat::Ppt);
```

## **FAQ**

**Czy wszystkie efekty i funkcje PPTX zachowują się przy zapisie do starszego formatu PPT (97–2003)?**

Nie zawsze. Format PPT nie posiada niektórych nowszych możliwości (np. określonych efektów, obiektów i zachowań), dlatego funkcje mogą być uproszczone lub zamienione na raster przy konwersji.

**Czy mogę konwertować tylko wybrane slajdy do PPT zamiast całej prezentacji?**

Bezpośredni zapis dotyczy całej prezentacji. Aby konwertować konkretne slajdy, utwórz nową prezentację zawierającą tylko te slajdy i zapisz ją jako PPT; alternatywnie, użyj usługi/API obsługującej parametry konwersji dla poszczególnych slajdów.

**Czy obsługiwane są prezentacje zabezpieczone hasłem?**

Tak. Możesz wykryć, czy plik jest zabezpieczony, otworzyć go przy użyciu hasła, a także [skonfiguruj ustawienia ochrony/szyfrowania](/slides/pl/php-java/password-protected-presentation/) dla zapisanego PPT.