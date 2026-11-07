---
title: Kompresuj prezentacje
description: Zmniejsz rozmiar prezentacji poprzez kompresję obrazów i zapis ustawień.
type: docs
url: /pl/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/image/
---
## **Przegląd**

Kompresuj obrazy, usuń wycięte fragmenty obrazów, gdy nie są już potrzebne, i wybierz ustawienia kompresji prezentacji przed zapisaniem. Jest to przydatne w zestawach z dużymi fotografiami lub powtarzającymi się mediami. Zaoszczędzona ilość zależy od treści i wybranych ustawień.

## **Przykład użycia**

Ten przykład w C# używa Aspose.Slides for .NET. Widocznie generuje gradientowy plik PNG o wymiarach 1600 × 900 pikseli, wstawia go do małej ramki obrazu i zapisuje *before.pptx*. Następnie kompresuje ten obraz do docelowej rozdzielczości 96 DPI i zapisuje *compressed.pptx*. Porównaj rozmiary obu plików i podglądy: oszczędności zależą od wejściowego obrazu i wyświetlanego rozmiaru.

Aby skonfigurować, zobacz [Zainstaluj Aspose.Slides for .NET](/slides/pl/net/installation/).

```csharp
using System;
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var bitmap = new Bitmap(1600, 900))
{
    for (var y = 0; y < bitmap.Height; y++)
        for (var x = 0; x < bitmap.Width; x++)
            bitmap.SetPixel(x, y, Color.FromArgb(x % 256, y % 256, (x + y) % 256));
    bitmap.Save("large.png", System.Drawing.Imaging.ImageFormat.Png);
}
using var presentation = new Presentation();
var title = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 500, 60);
title.TextFrame.Text = "Photo";
var bytes = File.ReadAllBytes("large.png");
var image = presentation.Images.AddImage(bytes);
var picture = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 40, 120, 240, 135, image);
presentation.Save("before.pptx", SaveFormat.Pptx);
var compressed = picture.PictureFormat.CompressImage(true, 96f);
Console.WriteLine($"Picture compressed: {compressed}");
presentation.Save("compressed.pptx", SaveFormat.Pptx);
using var preview = presentation.Slides[0].GetImage(1f, 1f);
preview.Save("compressed.png", ImageFormat.Png);
```

## **FAQ**

### **Czy jest to pojedynczy przełącznik optymalizacji całego pliku?**

Aspose.Slides for .NET 26.11 dodaje [Compress.CompressPresentation](/slides/pl/net/low-code-presentation-operations/#compress-the-whole-presentation), które łączy usuwanie nieużywanych układów/mistrzów, podzbiory osadzonych czcionek oraz kompresję obrazów przy 150 DPI. Trwale usuwa wycięte fragmenty obrazów. Do przetwarzania tylko obrazów użyj Compress.CompressImages; aby uzyskać większą kontrolę, zachowaj opisany wyżej przepływ pracy per‑obraz. Te nowe pomocnicze są specyficzne dla podanej wersji .NET; sprawdź odpowiedni przewodnik dla innych SDK.

### **Czy kompresja obrazu zmienia edytowalny tekst lub wykresy?**

Kompresja obrazu dotyczy danych obrazu, a nie edytowalnego tekstu ani danych wykresów. Przejrzyj obrazy, ponieważ zmiana rozmiaru lub ponowna kompresja może zmniejszyć ich szczegóły.

### **Jak powinienem wybrać rozdzielczość dla obrazów w prezentacji?**

Wybierz docelową rozdzielczość w oparciu o wyświetlany rozmiar obrazu oraz zamierzone użycie na ekranie lub w druku. Zachowaj większą rozdzielczość dla dużych wyświetlaczy, drukowania i szczegółowych diagramów oraz porównaj wyjście renderowane przed odrzuceniem oryginału.

## **Poradniki**

- [Optymalizuj zarządzanie obrazami w prezentacjach w .NET](/slides/pl/net/image/)

Powiązana funkcja: [Usuń nieużywane szablony, układy i multimedia](/slides/pl/features/remove-unused-content/).

## Przykłady .NET, które można uruchomić

- [Zmniejsz rozmiar prezentacji](/slides/pl/net/examples/optimization-batch/compression/)