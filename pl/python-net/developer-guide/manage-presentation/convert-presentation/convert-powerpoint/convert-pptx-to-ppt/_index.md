---
title: Konwertuj PPTX na PPT w Pythonie
linktitle: PPTX na PPT
type: docs
weight: 21
url: /pl/python-net/convert-pptx-to-ppt/
keywords:
- PPTX na PPT
- konwertuj PPTX na PPT
- konwertuj PowerPoint
- konwertuj prezentację
- Python
- Aspose.Slides
description: "Łatwo konwertuj PPTX na PPT przy użyciu Aspose.Slides for Python via .NET—zapewnij płynną kompatybilność z formatami PowerPoint, zachowując układ i jakość prezentacji."
---
## **Przegląd**

Aspose.Slides for Python umożliwia konwertowanie nowoczesnych prezentacji PPTX do starszego formatu PPT całkowicie w kodzie. Otwórz plik PPTX i wyeksportuj go jako PPT, zachowując zawartość i układ prezentacji, dzięki czemu wynik jest kompatybilny ze starszymi wersjami programu PowerPoint. Ten sam przepływ pracy może generować inne formaty wyjściowe — takie jak PDF, XPS, ODP, HTML lub obrazy — co sprawia, że doskonale wpasowuje się w skrypty, potoki CI i przetwarzanie wsadowe.

## **Konwertuj PPTX do PPT**

Aby przekonwertować PPTX na PPT, wystarczy przekazać nazwę pliku i format zapisu do metody [save](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/save/) klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/). Przykład w języku Python poniżej konwertuje prezentację z PPTX na PPT przy użyciu domyślnych opcji.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, która reprezentuje plik PPTX.
presentation = slides.Presentation("presentation.pptx")

# Zapisz prezentację jako plik PPT.
presentation.save("presentation.ppt", slides.export.SaveFormat.PPT)
```

## **FAQ**

**Czy wszystkie efekty i funkcje PPTX są zachowywane przy zapisywaniu w starszym formacie PPT (97‑2003)?**

Nie zawsze. Format PPT nie obsługuje niektórych nowszych możliwości (np. niektórych efektów, obiektów i zachowań), więc funkcje mogą być uproszczone lub zamienione na raster przy konwersji.

**Czy mogę konwertować tylko wybrane slajdy do PPT zamiast całej prezentacji?**

Bezpośrednie zapisywanie obejmuje całą prezentację. Aby przekonwertować wybrane slajdy, utwórz nową prezentację zawierającą tylko te slajdy i zapisz ją jako PPT; alternatywnie użyj usługi/API, które obsługuje parametry konwersji per‑slajd.

**Czy obsługiwane są prezentacje chronione hasłem?**

Tak. Można wykryć, czy plik jest zabezpieczony, otworzyć go przy użyciu hasła oraz również [konfiguruj ustawienia ochrony/szyfrowania](/slides/pl/python-net/password-protected-presentation/) dla zapisanego PPT.

**Zobacz także:**
- [Konwertuj PPT i PPTX do PDF w Python | Opcje zaawansowane](/slides/pl/python-net/convert-powerpoint-to-pdf/)
- [Konwertuj prezentacje PowerPoint do XPS w Python](/slides/pl/python-net/convert-powerpoint-to-xps/)
- [Konwertuj prezentacje PowerPoint do HTML w Python](/slides/pl/python-net/convert-powerpoint-to-html/)
- [Konwertuj slajdy PowerPoint do PNG w Python](/slides/pl/python-net/convert-powerpoint-to-png/)