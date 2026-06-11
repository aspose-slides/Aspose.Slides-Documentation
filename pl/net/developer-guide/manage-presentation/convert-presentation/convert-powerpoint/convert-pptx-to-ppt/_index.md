---
title: Konwertuj PPTX na PPT w .NET
linktitle: PPTX na PPT
type: docs
weight: 21
url: /pl/net/convert-pptx-to-ppt/
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
- .NET
- C#
- Aspose.Slides
description: "Łatwo konwertuj PPTX na PPT za pomocą Aspose.Slides dla .NET — zapewnij płynną kompatybilność z formatami PowerPoint, zachowując układ i jakość prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak przekonwertować prezentację PowerPoint w formacie PPTX na format PPT przy użyciu C#. Omówiony zostanie następujący temat.

- Konwertuj PPTX na PPT w C#

## **Konwertuj PPTX na PPT w .NET**

Aby zobaczyć przykładowy kod C# konwertujący PPTX na PPT, przejdź do sekcji poniżej, czyli [Convert PPTX to PPT](#convert-pptx-to-ppt). Kod po prostu wczytuje plik PPTX i zapisuje go w formacie PPT. Określając różne formaty zapisu, możesz również zapisać plik PPTX w wielu innych formatach, takich jak PDF, XPS, ODP, HTML itp., jak opisano w tych artykułach. 

- [Konwertuj PPTX na PDF w .NET](/slides/pl/net/convert-powerpoint-to-pdf/)
- [Konwertuj PPTX na XPS w .NET](/slides/pl/net/convert-powerpoint-to-xps/)
- [Konwertuj PPTX na HTML w .NET](/slides/pl/net/convert-powerpoint-to-html/)
- [Konwertuj PPTX na ODP w .NET](/slides/pl/net/save-presentation/)
- [Konwertuj PPTX na PNG w .NET](/slides/pl/net/convert-powerpoint-to-png/)

## **Konwertuj PPTX na PPT**
Aby skonwertować PPTX na PPT, przekaż nazwę pliku i format zapisu do metody [**Save**](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/save/) klasy [**Presentation**](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/). Poniższy przykład kodu C# konwertuje prezentację z PPTX na PPT przy użyciu domyślnych opcji.

```c#
 // Utwórz obiekt Presentation, który reprezentuje plik PPTX
 Presentation pres = new Presentation("presentation.pptx");

 // Zapisywanie prezentacji PPTX w formacie PPT
 pres.Save("presentation.ppt", SaveFormat.Ppt);
```

## **FAQ**

**Czy wszystkie efekty i funkcje PPTX są zachowywane przy zapisie w starszym formacie PPT (97–2003)?**

Nie zawsze. Format PPT nie obsługuje niektórych nowszych funkcji (np. niektórych efektów, obiektów i zachowań), dlatego funkcje mogą zostać uproszczone lub zrastrowane podczas konwersji.

**Czy mogę przekonwertować tylko wybrane slajdy na PPT zamiast całej prezentacji?**

Bezpośredni zapis dotyczy całej prezentacji. Aby przekonwertować wybrane slajdy, utwórz nową prezentację zawierającą tylko te slajdy i zapisz ją jako PPT; alternatywnie użyj usługi/API, które obsługuje parametry konwersji dla poszczególnych slajdów.

**Czy obsługiwane są prezentacje zabezpieczone hasłem?**

Tak. Możesz wykryć, czy plik jest zabezpieczony, otworzyć go przy użyciu hasła oraz [skonfigurować ustawienia ochrony/szyfrowania](/slides/pl/net/password-protected-presentation/) dla zapisanego pliku PPT.