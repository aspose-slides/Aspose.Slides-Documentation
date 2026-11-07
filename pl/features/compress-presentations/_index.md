---
title: Kompresja prezentacji
description: Zmniejsz rozmiar prezentacji poprzez kompresję obrazów i usuwanie nieużywanej zawartości.
type: docs
url: /pl/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **Przegląd**

Kompresuj obrazy, usuń przycięte fragmenty obrazów, gdy nie są już potrzebne, oraz wybierz ustawienia kompresji prezentacji przed zapisaniem. Jest to przydatne w zestawach z dużymi fotografiami lub powtarzającymi się mediami. Oszczędność zależy od treści i wybranych ustawień.

## **Przykład użycia**

Ten przykład w C# ładuje `input.pptx`, kompresuje prezentację i zapisuje ją jako `compressed.pptx`.

Użyj Aspose.Slides for .NET 26.11 lub nowszej wersji. Aby skonfigurować, zobacz [Zainstaluj Aspose.Slides for .NET](/slides/pl/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Czy jest to pojedynczy przełącznik optymalizacji całego pliku?**

Aspose.Slides for .NET 26.11 dodaje [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/), który łączy usuwanie nieużywanych układów/mistrzów, podzbiory osadzonych czcionek oraz kompresję obrazów 150 DPI. Trwale usuwa przycięte fragmenty obrazów. Do przetwarzania wyłącznie obrazów użyj [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/); aby uzyskać większą kontrolę, zobacz [przykład kompresji pojedynczych obrazów](/slides/pl/net/examples/optimization-batch/compression/). Te nowe pomocnice są specyficzne dla podanej wersji .NET; sprawdź odpowiedni przewodnik dla innych SDK.

### **Czy kompresja obrazu zmienia edytowalny tekst lub wykresy?**

Kompresja obrazów dotyczy danych obrazów, a nie edytowalnego tekstu ani danych wykresów. Przejrzyj obrazy, ponieważ zmiana rozmiaru lub ponowna kompresja może zmniejszyć ich szczegółowość.

### **Jak wybrać rozdzielczość obrazów w prezentacji?**

Wybierz docelową rozdzielczość w oparciu o wyświetlany rozmiar obrazu oraz zamierzone użycie na ekranie lub w druku. Zachowaj większą rozdzielczość dla dużych wyświetlaczy, drukowania i szczegółowych diagramów oraz porównaj wynik renderowania przed odrzuceniem oryginału.

## **Przewodniki**

- [Kompresja całej prezentacji w .NET](/slides/pl/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [Optymalizacja zarządzania obrazami w prezentacjach w .NET](/slides/pl/net/image/)

Powiązana funkcja: [Usuwanie nieużywanych mistrzów, układów i mediów](/slides/pl/features/remove-unused-content/).

## **Przykłady .NET do uruchomienia**

- [Zmniejsz rozmiar prezentacji](/slides/pl/net/examples/optimization-batch/compression/)