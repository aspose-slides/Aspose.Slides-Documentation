---
title: Konwertuj PPTX na PPT w Androidzie
linktitle: PPTX na PPT
type: docs
weight: 21
url: /pl/androidjava/convert-pptx-to-ppt/
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
- Android
- Java
- Aspose.Slides
description: "Łatwo konwertuj PPTX na PPT za pomocą Aspose.Slides dla Androida w Javie — zapewnij płynną kompatybilność z formatami PowerPoint, zachowując układ i jakość prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentację PowerPoint w formacie PPTX na format PPT przy użyciu Javy. Omówiony jest następujący temat.

- Konwertuj PPTX na PPT w Javie

## **Konwertuj PPTX na PPT w systemie Android**

Aby uzyskać przykładowy kod w Javie do konwersji PPTX na PPT, zobacz sekcję poniżej, tj. [Convert PPTX to PPT](#convert-pptx-to-ppt). Ładuje on po prostu plik PPTX i zapisuje w formacie PPT. Określając różne formaty zapisu, możesz również zapisać plik PPTX w wielu innych formatach, takich jak PDF, XPS, ODP, HTML itp., jak opisano w tych artykułach. 

- [Konwertuj PPTX na PDF w systemie Android](/slides/pl/androidjava/convert-powerpoint-to-pdf/)
- [Konwertuj PPTX na XPS w systemie Android](/slides/pl/androidjava/convert-powerpoint-to-xps/)
- [Konwertuj PPTX na HTML w systemie Android](/slides/pl/androidjava/convert-powerpoint-to-html/)
- [Konwertuj PPTX na ODP w systemie Android](/slides/pl/androidjava/save-presentation/)
- [Konwertuj PPTX na PNG w systemie Android](/slides/pl/androidjava/convert-powerpoint-to-png/)

## **Konwertuj PPTX na PPT**
Aby skonwertować PPTX do PPT, wystarczy przekazać nazwę pliku i format zapisu do metody **Save** klasy [**Presentation**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation). Poniższy przykład kodu w Javie konwertuje prezentację z PPTX na PPT przy użyciu domyślnych opcji.

```java
// utwórz obiekt Presentation, który reprezentuje plik PPTX
Presentation presentation = new Presentation("template.pptx");

// zapisz prezentację jako PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```

## **FAQ**

**Czy wszystkie efekty i funkcje PPTX zachowują się przy zapisie w starszym formacie PPT (97–2003)?**

Nie zawsze. Format PPT nie obsługuje niektórych nowszych funkcji (np. niektóre efekty, obiekty i zachowania), więc funkcje mogą być uproszczone lub zrastrowane podczas konwersji.

**Czy mogę konwertować tylko wybrane slajdy do PPT zamiast całej prezentacji?**

Bezpośrednie zapisanie obejmuje całą prezentację. Aby przekonwertować określone slajdy, utwórz nową prezentację zawierającą jedynie te slajdy i zapisz ją jako PPT; ewentualnie skorzystaj z usługi/interfejsu API, który obsługuje parametry konwersji dla poszczególnych slajdów.

**Czy obsługiwane są prezentacje zabezpieczone hasłem?**

Tak. Możesz wykryć, czy plik jest zabezpieczony, otworzyć go przy użyciu hasła, a także [skonfigurować ustawienia ochrony/szyfrowania](/slides/pl/androidjava/password-protected-presentation/) dla zapisanego pliku PPT.