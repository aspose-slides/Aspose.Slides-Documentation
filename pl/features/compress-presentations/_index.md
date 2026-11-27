---
title: Kompresja prezentacji
description: Zredukuj rozmiar prezentacji poprzez kompresję obrazów i usuwanie nieużywanej zawartości.
type: docs
url: /pl/features/compress-presentations/
weight: 250
feature_id: kompresja-prezentacji
feature_group: operacje
translationKey: slides-feature-kompresja-prezentacji
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **Przegląd**

Komprymuj obrazy, usuwaj obszary przyciętych obrazów, gdy nie są już potrzebne, i wybieraj ustawienia kompresji prezentacji przed zapisaniem. Jest to przydatne w prezentacjach zawierających duże zdjęcia lub powtarzające się multimedia. Ilość zaoszczędzonych danych zależy od treści i wybranych ustawień.

## **Przykład użycia**

Ten przykład w C# ładuje `input.pptx`, kompresuje prezentację i zapisuje ją jako `compressed.pptx`.

Użyj Aspose.Slides for .NET 26.11 lub późniejszej wersji. Aby skonfigurować, zobacz [Zainstaluj Aspose.Slides dla .NET](/slides/pl/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```


<!-- visual-explanation:compress-presentations:start -->
[![Obrazy o identycznej skali przed i po kompresji, po których następują mierzone paski rozmiaru pliku PPTX oraz wymiary przechowywanego obrazu.](visual-compress-presentations-1adbf86268a5.svg)](visual-compress-presentations-1adbf86268a5.svg)

*Zmierzono na jednym syntetycznym zestawie siatek szczegółowych: 584 030 → 128 323 bajtów. Oba renderingi używają tej samej skali i ramki 252 × 336 punktów. Kompresja usuwa przycięte marginesy i zmniejsza przechowywany obraz do 525 × 700 pikseli; oszczędność rozmiaru zależy od danych wejściowych.*
<!-- visual-explanation:compress-presentations:end -->

## **FAQ**

### **Czy jest to pojedynczy przełącznik optymalizacji całego pliku?**

Aspose.Slides for .NET 26.11 dodaje [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/), który łączy usuwanie nieużywanych układów/mistrzów, podzestawianie osadzonych czcionek i kompresję obrazów 150 DPI. Trwale usuwa przycięte obszary obrazów. Do przetwarzania wyłącznie obrazów użyj [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/); dla dokładniejszej kontroli zobacz [przykład kompresji pojedynczego obrazu](/slides/pl/net/examples/optimization-batch/compression/). Od wersji 26.11 ten sam wywołanie całej prezentacji jest dostępne także w Javie, Node.js poprzez Javę, Pythonie poprzez .NET i C++. Przykład oraz linki na tej stronie dotyczą .NET.

### **Czy kompresja obrazów zmienia edytowalny tekst lub wykresy?**

Kompresja obrazów dotyczy danych obrazowych, a nie edytowalnego tekstu ani danych wykresów. Przejrzyj obrazy, ponieważ zmiana rozmiaru lub ponowna kompresja może obniżyć ich szczegółowość.

### **Jak wybrać rozdzielczość obrazów w prezentacji?**

Wybierz docelową rozdzielczość w zależności od wyświetlanego rozmiaru obrazu oraz zamierzonego użycia na ekranie lub w druku. Zachowaj większą rozdzielczość dla dużych wyświetlaczy, druku i szczegółowych diagramów oraz porównaj wygenerowany wynik przed odrzuceniem oryginału.

## **Przewodniki**

- [Kompresuj całą prezentację w .NET](/slides/pl/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [Optymalizuj zarządzanie obrazami w prezentacjach w .NET](/slides/pl/net/image/)

Powiązana funkcja: [Usuń nieużywane szablony, układy i multimedia](/slides/pl/features/remove-unused-content/).

## **Przykłady .NET do uruchomienia**

- [Zredukuj rozmiar prezentacji](/slides/pl/net/examples/optimization-batch/compression/)