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
- efekt odbicia
- efekt poświaty
- przekształcenie WordArt
- efekt 3D
- efekt zewnętrznego cienia
- efekt wewnętrznego cienia
- .NET
- C#
- Aspose.Slides
description: "Tworzenie i dostosowywanie efektów WordArt w Aspose.Slides dla .NET. Ten przewodnik krok po kroku pomaga programistom ulepszyć prezentacje profesjonalnym tekstem w C#."
---
## **Przegląd**

Efekty WordArt pozwalają stylizować tekst przy użyciu wypełnień, konturów, cieni, odbić, poświaty, przekształceń i formatowania 3D. Ten artykuł wyjaśnia, jak tworzyć i dostosowywać te efekty w prezentacjach PowerPoint przy użyciu Aspose.Slides dla .NET, bez zainstalowanego programu Microsoft Office.

## **Utwórz prosty szablon WordArt i zastosuj go do tekstu**

Poniższe przykłady budują prosty styl WordArt, ustawiając tekst, czcionkę, wypełnienie wzorcem i kontur.

Każdy przykład tworzy nową prezentację i dodaje prostokąt do pierwszego slajdu; nie jest wymagany plik wejściowy. Pierwszy przykład ustawia tekst na „Aspose.Slides”. Pozycja i wymiary kształtu są mierzone w punktach:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;

var portion = textFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
```

Ustaw czcionkę na Arial Black o rozmiarze 36 punktów, aby formatowanie było bardziej widoczne:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;
```

Zastosuj wzorzec [SmallGrid](https://reference.aspose.com/slides/pl/net/aspose.slides/patternstyle/) z ciemnopomarańczowym pierwszym planem i białym tłem, a następnie dodaj czarny kontur tekstu o szerokości 1 punktu:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;

portion.PortionFormat.LineFormat.Width = 1;
portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```

Wynikowy tekst:

![The simple WordArt template](WordArt_template.png)

## **Zastosuj inne efekty WordArt**

Poniższe przykłady pokazują, jak zastosować cienie, odbicia, poświatę, przekształcenia i efekty 3D do tekstu.

### **Zastosuj zewnętrzne efekty cienia**

Zewnętrzny cień dodaje głębi, umieszczając cień za tekstem. Możesz dostosować jego kolor, kierunek, odległość, promień rozmycia, skalę i pochylenie.

Ten przykład wywołuje [EnableOuterShadowEffect](https://reference.aspose.com/slides/pl/net/aspose.slides/effectformat/enableoutershadoweffect/) i ustawia czarny cień o promieniu rozmycia 4 punkty, kierunku 230 stopni i odległości 30 punktów. Wartość skali 100 zachowuje rozmiar cienia, a poziome pochylenie przechyla go o 20 stopni. Transformacja alfa ustawia jego krycie na 32 %:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
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
```

Wynikowy tekst:

![The Outer Shadow effect](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Gdy jednocześnie używane są cienie zewnętrzne i wstępnie ustawione, zastosowany jest tylko cień zewnętrzny.
- Jeśli jednocześnie używane są cienie zewnętrzne i wewnętrzne, otrzymany efekt zależy od wersji PowerPointa. Na przykład w PowerPoint 2013 efekt jest podwojony, natomiast w PowerPoint 2007 zastosowany jest tylko cień zewnętrzny.
{{% /alert %}}

### **Zastosuj efekty odbicia**

Odbicie tworzy lustrzane odbicie tekstu. Dostosuj jego pozycję, skalę, rozmycie i krycie, aby kontrolować wygląd.

Ten przykład wywołuje [EnableReflectionEffect](https://reference.aspose.com/slides/pl/net/aspose.slides/effectformat/enablereflectioneffect/) i odwraca odbicie pionowo ze skalą –100 %. Używa promienia rozmycia 0,5 punktu i odległości 4,72 punktu. Krycie spada z 60 % do 0,9 % między pozycjami 0 % a 60 % wzdłuż odbicia:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
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
```

Wynikowy tekst:

![The Reflection effect](reflection_effect.png)

### **Zastosuj efekty poświaty**

Poświata dodaje miękki, kolorowy obrys wokół tekstu. Dostosuj kolor, krycie i promień, aby kontrolować efekt.

Ten przykład wywołuje [EnableGlowEffect](https://reference.aspose.com/slides/pl/net/aspose.slides/effectformat/enablegloweffect/) i stosuje czerwoną poświatę z kryciem 54 % i promieniem 7 punktów:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableGlowEffect();
portion.PortionFormat.EffectFormat.GlowEffect.Color.Color = System.Drawing.Color.Red;
portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```

Wynikowy tekst:

![The Glow effect](glow_effect.png)

### **Zastosuj przekształcenia WordArt**

Przekształcenia WordArt wyginają, rozciągają lub deformują blok tekstu.

Ustaw [Transform](https://reference.aspose.com/slides/pl/net/aspose.slides/textframeformat/transform/) na [ArchUpPour](https://reference.aspose.com/slides/pl/net/aspose.slides/textshapetype/), aby zakrzywić cały ramek tekstu w górę:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var textFrame = autoShape.TextFrame;
textFrame.Text = "Aspose.Slides";
textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

Wynikowy tekst:

![The WordArt transformation](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides dla .NET udostępnia zestaw wbudowanych [typów przekształceń](https://reference.aspose.com/slides/pl/net/aspose.slides/textshapetype/).
{{% /alert %}}

### **Zastosuj efekty 3D do kształtów i tekstu**

Efekty 3D można zastosować zarówno do kształtu, jak i do jego tekstu. Fazety, ekstruzja, oświetlenie i ustawienia kamery kontrolują ostateczny wygląd.

Poniższy przykład używa [ThreeDFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/threedformat/), aby dodać okrągłe fazety, pomarańczową ekstruzję i ciemnoczerwony kontur do prostokąta. Wymiary fazet, wysokość ekstruzji, szerokość konturu i głębokość są mierzone w punktach. Materiał plastikowy, zrównoważone oświetlenie obrócone o 40 stopni wokół osi Z oraz perspektywiczna kamera definiują jego wygląd:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
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
```

Wynikowy kształt:

![The shape 3D effect](shape_3D_effect.png)

Ten przykład stosuje podobne formatowanie 3D do tekstu przy użyciu [TextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/textframeformat/threedformat/). Mniejsze fazety kształtują krawędzie liter, a ekstruzja i oświetlenie nadają tekstowi głębię:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;
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
```

Wynikowy tekst:

![The text 3D effect](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Zastosowanie efektów 3D do tekstu lub jego kształtu – oraz interakcja między tymi efektami – podlega określonym regułom. Rozważ scenę obejmującą zarówno tekst, jak i zawierający go kształt. Efekt 3D obejmuje reprezentację 3D obiektu oraz scenę, w której jest umieszczony.

- Jeśli scena jest ustawiona zarówno dla kształtu, jak i dla tekstu, scenę kształtu ma pierwszeństwo, a scena tekstu jest ignorowana.
- Jeśli kształt nie ma własnej sceny, ale posiada reprezentację 3D, używana jest scena tekstu.
- Jeśli kształt nie posiada żadnego efektu 3D, traktowany jest jako płaski, a efekt 3D jest stosowany wyłącznie do tekstu.

Zachowania te dotyczą właściwości [ThreeDFormat.LightRig](https://reference.aspose.com/slides/pl/net/aspose.slides/threedformat/lightrig/) i [ThreeDFormat.Camera](https://reference.aspose.com/slides/pl/net/aspose.slides/threedformat/camera/).
{{% /alert %}}

Aby zachować płaskość i czytelność tekstu przy jednoczesnym zachowaniu formatowania 3D kształtu, zobacz [Keep Text Flat on a 3D Shape](/slides/pl/net/3d-presentation/) – porównanie obu ustawień oraz pełny przykład w języku C#.

## **FAQ**

**Czy mogę używać efektów WordArt z różnymi czcionkami lub skryptami (np. arabski, chiński)?**

Tak, Aspose.Slides dla .NET obsługuje Unicode i współpracuje ze wszystkimi głównymi czcionkami i skryptami. Efekty WordArt, takie jak cień, wypełnienie i kontur, mogą być stosowane niezależnie od języka, choć dostępność czcionek i renderowanie mogą zależeć od czcionek systemowych.

**Czy mogę zastosować efekty WordArt do elementów w szablonie slajdu?**

Tak, możesz stosować efekty WordArt do kształtów na slajdach mistrzowskich, w tym do pól tekstowych tytułu, stopek lub tekstu tła. Zmiany w układzie mistrza będą odzwierciedlane we wszystkich powiązanych slajdach.

**Czy efekty WordArt wpływają na rozmiar pliku prezentacji?**

Nieznacznie. Efekty WordArt, takie jak cienie, poświaty i wypełnienia gradientowe, mogą nieco zwiększyć rozmiar pliku ze względu na dodatkowe metadane formatowania, ale różnica zazwyczaj jest pomijalna.

**Czy mogę podglądnąć rezultat efektów WordArt bez zapisywania prezentacji?**

Tak, możesz renderować slajdy zawierające WordArt do obrazów (np. PNG, JPEG) przy użyciu [ISlide.GetImage](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/getimage/), lub renderować poszczególne kształty przy użyciu [IShape.GetImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/getimage/). Pozwala to na podgląd wyniku w pamięci lub na ekranie przed zapisaniem lub wyeksportowaniem pełnej prezentacji.