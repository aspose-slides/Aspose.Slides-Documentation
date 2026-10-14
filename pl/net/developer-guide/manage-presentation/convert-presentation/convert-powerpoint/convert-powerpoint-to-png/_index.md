---
title: Konwertuj slajdy PowerPoint na PNG w .NET
linktitle: PowerPoint do PNG
type: docs
weight: 30
url: /pl/net/convert-powerpoint-to-png/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do PNG
- prezentacja do PNG
- slajd do PNG
- PPT do PNG
- PPTX do PNG
- zapisz PPT jako PNG
- zapisz PPTX jako PNG
- eksportuj PPT do PNG
- eksportuj PPTX do PNG
- .NET
- C#
- Aspose.Slides
description: "Szybko konwertuj prezentacje PowerPoint na wysokiej jakości obrazy PNG przy użyciu Aspose.Slides dla .NET, zapewniając precyzyjne, zautomatyzowane wyniki."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować slajdy prezentacji na obrazy PNG przy użyciu Aspose.Slides for .NET. Można wczytywać prezentacje w formatach takich jak PPT, PPTX i ODP, renderować każdy slajd i zapisywać go jako osobny obraz PNG.

Poniższe przykłady demonstrują renderowanie miniatur, ustawianie czynników skalowania, określanie wymiarów wyjściowych w pikselach oraz wybór stylu renderowania gradientu.

## **Konwertuj PowerPoint na PNG**

Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) i uzyskaj dostęp do jej slajdów poprzez kolekcję [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/). Przykład renderuje każdy slajd za pomocą [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) bez parametrów, aby utworzyć miniaturę. Następnie wywołuje [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) z [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/), aby zapisać każdy wyrenderowany slajd jako obraz PNG.

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage();
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

{{% alert color="info" title="Note" %}}
Przeciążenie [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) bez parametrów renderuje w skali 0,2. Na przykład slajd o wymiarach 720 × 540 punktów tworzy miniaturę o rozmiarze 144 × 108 pikseli. Aby kontrolować wymiary wyjściowe, użyj przeciążeń z czynnikami skalowania lub explicite określonego rozmiaru obrazu, jak pokazano poniżej.
{{% /alert %}}

## **Konwertuj PowerPoint na PNG z własnymi wymiarami**

Przekaż poziome i pionowe czynniki skalowania do [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) aby kontrolować wymiar renderowanego obrazu. W tym przykładzie oba czynniki wynoszą 2, więc slajd o wymiarach 720 × 540 punktów daje obraz 1440 × 1080 pikseli. Równe czynniki skalowania zachowują proporcje slajdu. Każdy obraz jest zapisywany w formacie PNG przy użyciu [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/).

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var scaleX = 2f;
var scaleY = scaleX;

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **Konwertuj PowerPoint na PNG z własnym rozmiarem**

Aby określić wymiary wyjściowe w pikselach, przekaż rozmiar do [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) zamiast czynników skalowania. Ten przykład renderuje każdy slajd w rozdzielczości 960 × 720 pikseli i zapisuje wynik przy użyciu [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/). Wybierz wymiary pasujące do proporcji slajdu, aby uniknąć rozciągania obrazu.

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var imageSize = new Size(960, 720);

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(imageSize);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **Wybierz styl renderowania gradientu**

Załóżmy, że slajd zawiera wypełnienia gradientowe, ale przejścia w wyeksportowanym pliku PNG wyglądają jaśniej lub inaczej niż w PowerPoint. Można użyć właściwości [GradientStyle](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/gradientstyle/) klasy [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/), aby wybrać sposób renderowania gradientów.

Pobierz [gradient-styles.pptx](gradient-styles.pptx) i umieść go w katalogu roboczym aplikacji. Jej pierwszy slajd zawiera dwa gradienty liniowe: od cyjanu do pomarańczu u góry i od niebieskiego do żółci u dołu. Każdy gradient ma dwa przystanki, przy 0 % i 100 %.

Poniższy przykład wczytuje tę prezentację i renderuje ten sam pierwszy slajd w obu trybach przy użyciu [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("gradient-styles.pptx");
var slide = presentation.Slides[0];

var gradientStyles = new[] { GradientStyle.Default, GradientStyle.PowerPointUI };
foreach (var style in gradientStyles)
{
    var options = new RenderingOptions { GradientStyle = style };
    using var image = slide.GetImage(options, 1f, 1f);
    image.Save($"gradient-{style}.png", ImageFormat.Png);
}
```

Poniższe obrazy pokazują wynik tego samego slajdu, z oboma gradientami w każdym obrazie:

| Domyślny | PowerPointUI |
| --- | --- |
| ![Gradienty od cyjanu do pomarańczy i od niebieskiego do żółci renderowane w trybie Domyślny](gradient-Default.png) | ![Te same gradienty renderowane w trybie PowerPointUI](gradient-PowerPointUI.png) |

W tym przykładzie `Default` generuje jaśniejsze kolory pośrednie, podczas gdy `PowerPointUI` generuje ciemniejsze kolory pośrednie. Różnica zależy od kolorów i przystanków w gradiencie.

Wybierz `Default`, gdy standardowy wynik Aspose.Slides spełnia Twoje potrzeby. Wypróbuj `PowerPointUI`, gdy priorytetem jest dopasowanie wyglądu do PowerPoint. Porównaj oba wyniki z zamierzonym rezultatem; żaden tryb nie jest ogólnie lepszy.

## **FAQ**

**Jak mogę wyeksportować określony kształt, taki jak wykres lub obraz, zamiast całego slajdu?**  
Aspose.Slides obsługuje [generowanie miniatur dla poszczególnych kształtów](/slides/pl/net/create-shape-thumbnails/), umożliwiając renderowanie kształtu jako obrazu PNG.

**Czy konwersja równoległa jest obsługiwana na serwerze?**  
Tak. Używaj osobnej instancji prezentacji dla każdego wątku lub procesu; [nie udostępniaj jednej instancji pomiędzy wątkami](/slides/pl/net/multithreading/).

**Jakie są ograniczenia wersji ewaluacyjnej przy eksporcie do PNG?**  
Tryb ewaluacyjny dodaje znak wodny do wyjściowych obrazów i stosuje [inne ograniczenia](/slides/pl/net/licensing/), dopóki nie zostanie zastosowana licencja.