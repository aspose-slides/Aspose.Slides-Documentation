---
title: Tworzenie i stosowanie efektów WordArt w .NET
linktitle: WordArt
type: docs
weight: 110
url: /pl/net/wordart/
keywords:
- WordArt
- tworzenie WordArt
- szablon WordArt
- efekt WordArt
- efekt cienia
- efekt wyświetlania
- efekt poświaty
- transformacja WordArt
- efekt 3D
- efekt zewnętrznego cienia
- efekt wewnętrznego cienia
- .NET
- C#
- Aspose.Slides
description: "Tworzenie i dostosowywanie efektów WordArt w Aspose.Slides for .NET. Ten przewodnik krok po kroku pomaga programistom ulepszyć prezentacje profesjonalnym tekstem w C#."
---
## **Przegląd**

Efekty WordArt umożliwiają dodawanie wizualnie atrakcyjnego, stylizowanego tekstu do prezentacji PowerPoint. Dzięki Aspose.Slides for .NET programiści mogą programowo tworzyć, dostosowywać i zarządzać WordArt tak jak w Microsoft PowerPoint — bez konieczności instalacji Office. Ten artykuł przedstawia przegląd pracy z WordArt w .NET, w tym jak stosować przekształcenia tekstu, style wypełnień, kontury, cienie i inne opcje formatowania, aby treść prezentacji była bardziej wyrazista i angażująca. WordArt pozwala traktować tekst jako obiekt graficzny. Składa się z efektów lub specjalnych modyfikacji stosowanych do tekstu, aby uczynić go bardziej atrakcyjnym lub widocznym.

## **Utwórz prosty szablon WordArt i zastosuj go do tekstu**

W tej sekcji zbadamy, jak utworzyć prosty szablon WordArt i zastosować go do tekstu przy użyciu Aspose.Slides for .NET. WordArt oferuje prosty sposób na ulepszenie wyglądu tekstu dzięki wyrazistym efektom wizualnym i stylom. Poznając podstawowe kroki tworzenia i używania WordArt, możesz łatwo dostosować te techniki do dowolnego projektu, czyniąc swoje prezentacje bardziej żywymi i zapadającymi w pamięć.

Najpierw tworzymy prosty tekst przy użyciu następującego kodu C#:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;

    IPortion portion = textFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
}
```

Teraz ustawiamy wysokość czcionki tekstu na większą wartość, aby efekt był bardziej widoczny, używając następującego kodu:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";

    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;
}
```

Tutaj stosujemy wypełnienie wzorem SmallGrid do tekstu oraz dodajemy czarną obwódkę tekstu o szerokości 1, używając następującego kodu:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;

    portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
}
```

Powstały tekst:

![Prosty szablon WordArt](WordArt_template.png)

## **Zastosuj inne efekty WordArt**

Oprócz podstawowych przekształceń, Aspose.Slides for .NET pozwala zastosować różnorodne zaawansowane efekty WordArt, aby poprawić wygląd tekstu. Obejmują one kontury, wypełnienia, cienie, odbicia oraz efekty poświaty. Łącząc te funkcje, możesz tworzyć przyciągające uwagę style tekstu, które wyróżniają się w prezentacjach. Ta sekcja demonstruje, jak programowo zastosować te efekty za pomocą prostych, przejrzystych przykładów kodu.

### **Zastosuj efekty zewnętrznego cienia**

Efekty zewnętrznego cienia pomagają wyróżnić tekst, dodając cień za jego konturem, co tworzy wrażenie głębi i oddzielenia od tła. Aspose.Slides for .NET umożliwia łatwe zastosowanie i dostosowanie zewnętrznych cieni w tekście WordArt. W tej sekcji dowiesz się, jak ustawić kolor cienia, kierunek, odległość, promień rozmycia i inne, aby uzyskać pożądany efekt wizualny.

Poniższy fragment kodu C# nakłada efekt cienia na wcześniej utworzony tekst.

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.EffectFormat.EnableOuterShadowEffect();
    portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.Black;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleHorizontal = 100;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleVertical = 100;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.BlurRadius = 4;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.Direction = 230;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.Distance = 30;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewHorizontal = 20;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewVertical = 0;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.32f);
}
```

Powstały tekst:

![Efekt zewnętrznego cienia](outer_shadow_effect.png)

{{% alert color="info" %}} 
- Gdy OuterShadow i PresetShadow są używane jednocześnie, stosowany jest tylko efekt OuterShadow.
- Jeśli OuterShadow i InnerShadow są używane jednocześnie, wynikowy efekt zależy od wersji PowerPointa. Na przykład w PowerPoint 2013 efekt jest podwojony, natomiast w PowerPoint 2007 stosowany jest tylko efekt OuterShadow.
{{% /alert %}}

### **Zastosuj efekty odbicia**

W tej sekcji zbadamy, jak zastosować efekty odbicia w swoich slajdach przy użyciu Aspose.Slides for .NET. Efekty odbicia mogą być skutecznym sposobem na nadanie tekstowi lub kształtom stylowego i nowoczesnego wyglądu, pomagając kluczowym elementom się wyróżnić i dodając głębię prezentacji. Rozumiejąc proces aplikacji i dostosowywania tych efektów, możesz łatwo dopasować je do potrzeb projektowych i wymagań brandingowych.

Dodaj efekt odbicia do tekstu przy użyciu tego przykładu kodu C#:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.EffectFormat.EnableReflectionEffect();
    portion.PortionFormat.EffectFormat.ReflectionEffect.BlurRadius = 0.5;
    portion.PortionFormat.EffectFormat.ReflectionEffect.Distance = 4.72;
    portion.PortionFormat.EffectFormat.ReflectionEffect.StartPosAlpha = 0f;
    portion.PortionFormat.EffectFormat.ReflectionEffect.EndPosAlpha = 60f;
    portion.PortionFormat.EffectFormat.ReflectionEffect.Direction = 90;
    portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleHorizontal = 100;
    portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleVertical = -100;
    portion.PortionFormat.EffectFormat.ReflectionEffect.StartReflectionOpacity = 60f;
    portion.PortionFormat.EffectFormat.ReflectionEffect.EndReflectionOpacity = 0.9f;
    portion.PortionFormat.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.BottomLeft;
}
```

Powstały tekst:

![Efekt odbicia](reflection_effect.png)

### **Zastosuj efekty poświaty**

W tej sekcji zbadamy, jak zastosować efekt poświaty do tekstu przy użyciu Aspose.Slides for .NET. Efekt poświaty może sprawić, że tekst wyróżnia się dzięki świetlistej obwódce, zwiększając atrakcyjność wizualną slajdów. Regulując ustawienia takie jak kolor i intensywność, możesz łatwo dopasować poświatę do swojego projektu i wymagań brandingowych, zapewniając, że kluczowe punkty w prezentacji przyciągną uwagę odbiorców.

Zastosuj efekt poświaty do tekstu, aby go rozświetlić lub wyróżnić, używając poniższego kodu:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.EffectFormat.EnableGlowEffect();
    portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
    portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
}
```

Powstały tekst:

![Efekt poświaty](glow_effect.png)

### **Zastosuj przekształcenia WordArt**

W tej sekcji zbadamy, jak używać przekształceń w WordArt przy użyciu Aspose.Slides for .NET. Przekształcenia pozwalają zginać, rozciągać lub deformować tekst, tworząc unikalne i wizualnie efektowne rezultaty. Opanowując te techniki, możesz łatwo dopasować kształty i style tekstu do swojej marki lub wizji kreatywnej, zapewniając przekonującą i dopracowaną prezentację.

Użyj właściwości `Transform` (która dotyczy całego bloku tekstu) przy użyciu następującego kodu:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "Aspose.Slides";

    textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
}
```

Powstały tekst:

![Przekształcenie WordArt](transform_effect.png)

{{% alert color="info" %}} 
Aspose.Slides for .NET udostępnia zestaw zdefiniowanych typów [przekształceń](https://reference.aspose.com/slides/pl/net/aspose.slides/textshapetype/).
{{% /alert %}} 

### **Zastosuj efekty 3D do kształtów i tekstu**

Tworzenie realistycznych, przyciągających uwagę elementów wizualnych może znacząco wzmocnić oddziaływanie Twoich prezentacji. W tej sekcji przyjrzymy się, jak zastosować efekty trójwymiarowe (3D) do kształtów przy użyciu Aspose.Slides for .NET. Manipulując parametrami takimi jak głębokość, kąt i oświetlenie, możesz uzyskać imponujące przekształcenia 3D, które od razu przyciągają uwagę odbiorców. Niezależnie od tego, czy dążysz do subtelnych podkreśleń, czy dramatycznych iluzji, te funkcje oferują elastyczne sposoby podniesienia jakości projektu i przekazania pomysłów w bardziej fascynujący sposób.

Użyj poniższego przykładowego kodu, aby ustawić efekt 3D dla kształtu:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.TextFrame.Text = "Aspose.Slides";

    autoShape.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
    autoShape.ThreeDFormat.BevelBottom.Height = 10.5;
    autoShape.ThreeDFormat.BevelBottom.Width = 10.5;

    autoShape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    autoShape.ThreeDFormat.BevelTop.Height = 12.5;
    autoShape.ThreeDFormat.BevelTop.Width = 11;

    autoShape.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
    autoShape.ThreeDFormat.ExtrusionHeight = 6;

    autoShape.ThreeDFormat.ContourColor.Color = Color.DarkRed;
    autoShape.ThreeDFormat.ContourWidth = 1.5;

    autoShape.ThreeDFormat.Depth = 3;

    autoShape.ThreeDFormat.Material = MaterialPresetType.Plastic;

    autoShape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    autoShape.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
}
```

Efekt 3D kształtu:

![Efekt 3D kształtu](shape_3D_effect.png)

Użyj poniższego przykładowego kodu, aby ustawić efekt 3D dla tekstu:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "Aspose.Slides";

    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Height = 3.5;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Width = 3.5;

    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Height = 4;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Width = 4;

    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight = 6;

    textFrame.TextFrameFormat.ThreeDFormat.ContourColor.Color = Color.DarkRed;
    textFrame.TextFrameFormat.ThreeDFormat.ContourWidth = 1.5;

    textFrame.TextFrameFormat.ThreeDFormat.Depth = 3;

    textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;

    textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

    textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
}
```

Efekt 3D tekstu:

![Efekt 3D tekstu](text_3D_effect.png)

{{% alert color="info" %}} 
Zastosowanie efektów 3D do tekstu lub ich kształtów — oraz interakcja między tymi efektami — regulowane jest przez określone zasady. Rozważ scenę obejmującą zarówno tekst, jak i kształt zawierający ten tekst. Efekt 3D obejmuje trójwymiarową reprezentację obiektu oraz scenę, na której jest on umieszczony.

- Jeśli scena jest ustawiona zarówno dla kształtu, jak i tekstu, scena kształtu ma pierwszeństwo, a scena tekstu zostaje zignorowana.
- Jeśli kształt nie ma własnej sceny, ale posiada reprezentację 3D, używana jest scena tekstu.
- Jeśli kształt nie ma żadnego efektu 3D, traktowany jest jako płaski, a efekt 3D jest stosowany wyłącznie do tekstu.

Zachowania te dotyczą właściwości [ThreeDFormat.LightRig](https://reference.aspose.com/slides/pl/net/aspose.slides/threedformat/lightrig/) i [ThreeDFormat.Camera](https://reference.aspose.com/slides/pl/net/aspose.slides/threedformat/camera/).
{{% /alert %}} 

## **FAQ**

### Czy mogę używać efektów WordArt z różnymi czcionkami lub skryptami (np. arabski, chiński)?

Tak, Aspose.Slides for .NET obsługuje Unicode i działa ze wszystkimi głównymi czcionkami i skryptami. Efekty WordArt, takie jak cień, wypełnienie i kontur, można stosować niezależnie od języka, choć dostępność czcionek i renderowanie mogą zależeć od czcionek systemowych.

### Czy mogę zastosować efekty WordArt do elementów master‑slajdu?

Tak, możesz zastosować efekty WordArt do kształtów na slajdach master, w tym do pól zastępczych tytułu, stopek lub tekstu tła. Zmiany wprowadzone w układzie mastera będą odzwierciedlane na wszystkich powiązanych slajdach.

### Czy efekty WordArt wpływają na rozmiar pliku prezentacji?

Trochę. Efekty WordArt, takie jak cienie, poświaty i wypełnienia gradientowe, mogą nieznacznie zwiększyć rozmiar pliku ze względu na dodatkowe metadane formatowania, ale różnica zazwyczaj jest pomijalna.

### Czy mogę podglądnąć wynik efektów WordArt bez zapisywania prezentacji?

Tak, możesz renderować slajdy zawierające WordArt do obrazów (np. PNG, JPEG) przy użyciu metody `GetImage` z interfejsów [IShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/) lub [ISlide](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/). Pozwala to na podgląd wyniku w pamięci lub na ekranie przed zapisaniem lub eksportem całej prezentacji.