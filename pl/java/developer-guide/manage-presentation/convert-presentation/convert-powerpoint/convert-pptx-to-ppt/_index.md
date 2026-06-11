---
title: Konwertuj PPTX na PPT w Javie
linktitle: PPTX na PPT
type: docs
weight: 21
url: /pl/java/convert-pptx-to-ppt/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPTX
- PPTX na PPT
- zapisz PPTX jako PPT
- eksportuj PPTX do PPT
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Łatwo konwertuj PPTX na PPT przy użyciu Aspose.Slides for Java — zapewnij płynną zgodność z formatami PowerPoint, zachowując układ i jakość prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentację PowerPoint w formacie PPTX na format PPT przy użyciu języka Java. Omówiony zostanie następujący temat.

- Konwertuj PPTX na PPT w Javie

## **Konwertuj PPTX na PPT w Javie**

Aby zobaczyć przykładowy kod Javy konwertujący PPTX na PPT, przejdź do sekcji poniżej, tj. [Convert PPTX to PPT](#convert-pptx-to-ppt). Kod po prostu ładuje plik PPTX i zapisuje go w formacie PPT. Określając różne formaty zapisu, możesz także zapisać plik PPTX w wielu innych formatach, takich jak PDF, XPS, ODP, HTML itp., jak opisano w tych artykułach.

- [Konwertuj PPTX na PDF w Javie](/slides/pl/java/convert-powerpoint-to-pdf/)
- [Konwertuj PPTX na XPS w Javie](/slides/pl/java/convert-powerpoint-to-xps/)
- [Konwertuj PPTX na HTML w Javie](/slides/pl/java/convert-powerpoint-to-html/)
- [Konwertuj PPTX na ODP w Javie](/slides/pl/java/save-presentation/)
- [Konwertuj PPTX na PNG w Javie](/slides/pl/java/convert-powerpoint-to-png/)

## **Konwertuj PPTX na PPT**
Aby skonwertować PPTX na PPT, po prostu przekaż nazwę pliku i format zapisu do metody **Save** klasy [**Presentation**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation). Poniższy przykładowy kod Javy konwertuje prezentację z PPTX na PPT przy użyciu domyślnych opcji.

```java
// utwórz obiekt Presentation reprezentujący plik PPTX
Presentation presentation = new Presentation("template.pptx");

// save the presentation as PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```

## **Najczęściej zadawane pytania**

**Czy wszystkie efekty i funkcje PPTX zachowują się przy zapisywaniu w starszym formacie PPT (97–2003)?**

Nie zawsze. Format PPT nie obsługuje niektórych nowszych możliwości (np. niektórych efektów, obiektów i zachowań), więc funkcje mogą zostać uproszczone lub zamienione na raster podczas konwersji.

**Czy mogę skonwertować tylko wybrane slajdy na PPT zamiast całej prezentacji?**

Bezpośrednie zapisywanie obejmuje całą prezentację. Aby skonwertować wybrane slajdy, utwórz nową prezentację zawierającą tylko te slajdy i zapisz ją jako PPT; alternatywnie użyj usługi/API, które obsługują parametry konwersji per‑slajd.

**Czy obsługiwane są prezentacje chronione hasłem?**

Tak. Możesz wykryć, czy plik jest chroniony, otworzyć go przy użyciu hasła oraz [skonfigurować ustawienia ochrony/szyfrowania](/slides/pl/java/password-protected-presentation/) dla zapisywanego pliku PPT.