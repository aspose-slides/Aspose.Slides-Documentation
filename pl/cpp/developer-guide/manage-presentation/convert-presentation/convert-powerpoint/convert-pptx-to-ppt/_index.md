---
title: Konwertuj PPTX na PPT w C++
linktitle: PPTX na PPT
type: docs
weight: 21
url: /pl/cpp/convert-pptx-to-ppt/
keywords:
- konwertować PowerPoint
- konwertować prezentację
- konwertować slajd
- konwertować PPTX
- PPTX na PPT
- zapisz PPTX jako PPT
- eksportuj PPTX do PPT
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Łatwo konwertuj PPTX na PPT przy użyciu Aspose.Slides dla C++ — zapewnij płynną kompatybilność z formatami PowerPoint, zachowując układ i jakość prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak przekonwertować prezentację PowerPoint w formacie PPTX na format PPT przy użyciu C++. Omówiony jest następujący temat.

- Konwersja PPTX do PPT w C++

## **Konwersja PPTX do PPT w C++**

Aby uzyskać przykładowy kod C++ konwertujący PPTX na PPT, zobacz sekcję poniżej, tj. [Konwersja PPTX do PPT](#convert-pptx-to-ppt). Po prostu ładuje plik PPTX i zapisuje go w formacie PPT. Określając różne formaty docelowe, możesz także zapisać plik PPTX w wielu innych formatach, takich jak PDF, XPS, ODP, HTML itp., jak opisano w tych artykułach.

- [Konwersja PPTX do PDF w C++](/slides/pl/cpp/convert-powerpoint-to-pdf/)
- [Konwersja PPTX do XPS w C++](/slides/pl/cpp/convert-powerpoint-to-xps/)
- [Konwersja PPTX do HTML w C++](/slides/pl/cpp/convert-powerpoint-to-html/)
- [Konwersja PPTX do ODP w C++](/slides/pl/cpp/save-presentation/)
- [Konwersja PPTX do PNG w C++](/slides/pl/cpp/convert-powerpoint-to-png/)

## **Konwersja PPTX do PPT**
Aby przekonwertować PPTX na PPT, wystarczy przekazać nazwę pliku i format zapisu do metody **Save** klasy [**Presentation**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation/). Poniższy przykładowy kod C++ konwertuje prezentację z PPTX na PPT przy użyciu domyślnych opcji.

```cpp
// Wczytaj plik PPTX.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// Zapisz w formacie PPT.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```

## **FAQ**

**Czy wszystkie efekty i funkcje PPTX są zachowywane przy zapisywaniu w starszym formacie PPT (97–2003)?**

Nie zawsze. Format PPT nie obsługuje niektórych nowszych możliwości (np. niektórych efektów, obiektów i zachowań), dlatego funkcje mogą być uproszczone lub zamienione na rastrowe podczas konwersji.

**Czy mogę przekonwertować tylko wybrane slajdy do PPT zamiast całej prezentacji?**

Bezpośrednie zapisanie obejmuje całą prezentację. Aby przekonwertować konkretne slajdy, należy utworzyć nową prezentację zawierającą tylko te slajdy i zapisać ją jako PPT; alternatywnie można użyć usługi/API obsługującej parametry konwersji dla poszczególnych slajdów.

**Czy obsługiwane są prezentacje zabezpieczone hasłem?**

Tak. Można wykryć, czy plik jest zabezpieczony, otworzyć go przy użyciu hasła oraz [skonfigurować ustawienia ochrony/szyfrowania](/slides/pl/cpp/password-protected-presentation/) dla zapisanego pliku PPT.