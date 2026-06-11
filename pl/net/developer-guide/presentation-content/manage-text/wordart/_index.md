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
description: "Tworzenie i dostosowywanie efektów WordArt w Aspose.Slides dla .NET. Ten przewodnik krok po kroku pomaga programistom ulepszyć prezentacje profesjonalnym tekstem w C#."
---
## **Przegląd**

Efekty WordArt pozwalają dodawać atrakcyjny wizualnie, stylizowany tekst do prezentacji PowerPoint. Dzięki Aspose.Slides for .NET programiści mogą programowo tworzyć, dostosowywać i zarządzać WordArt tak, jak w Microsoft PowerPoint — bez konieczności instalowania Office. Ten artykuł przedstawia przegląd pracy z WordArt w .NET, w tym zastosowanie transformacji tekstu, stylów wypełnienia, konturów, cieni i innych opcji formatowania, aby treść prezentacji była bardziej ekspresyjna i angażująca. WordArt umożliwia traktowanie tekstu jako obiektu graficznego. Składa się z efektów lub specjalnych modyfikacji nakładanych na tekst, aby uczynić go bardziej atrakcyjnym lub zauważalnym.

## **Utwórz prosty szablon WordArt i zastosuj go do tekstu**

W tej sekcji przyjrzymy się, jak utworzyć prosty szablon WordArt i zastosować go do tekstu przy użyciu Aspose.Slides for .NET. WordArt oferuje prosty sposób na ulepszenie wyglądu tekstu dzięki efektom wizualnym i stylom. Poznając podstawowe kroki tworzenia i używania WordArt, możesz łatwo dostosować te techniki do dowolnego projektu, sprawiając, że Twoje prezentacje będą bardziej żywe i niezapomniane.

Najpierw tworzymy prosty tekst przy użyciu następującego kodu C#:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;

    IPortion portion = textFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
}
```

Teraz ustawiamy wysokość czcionki tekstu na większą wartość, aby efekt był bardziej widoczny, używając poniższego kodu:

```cs
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;
```

Tutaj stosujemy wypełnienie wzorem SmallGrid do tekstu i dodajemy czarną obwódkę tekstu o szerokości 1, używając poniższego kodu:

```cs
    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;
                
    portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```

Rezultujący tekst:

![The simple WordArt template](WordArt_template.png)

## **Zastosuj inne efekty WordArt**

Oprócz podstawowych transformacji, Aspose.Slides for .NET umożliwia zastosowanie różnorodnych zaawansowanych efektów WordArt, aby poprawić wygląd tekstu. Są to m.in. kontury, wypełnienia, cienie, odbicia i efekty poświaty. Łącząc te funkcje, możesz tworzyć przyciągające wzrok style tekstu, które wyróżniają się w prezentacjach. Poniżej znajduje się demonstracja, jak programowo zastosować te efekty przy użyciu prostych, przejrzystych przykładów kodu.

### **Zastosuj efekty zewnętrznego cienia**

Efekty zewnętrznego cienia pomagają tekstowi wyróżnić się, dodając cień za jego konturem, co tworzy wrażenie głębi i odseparowania od tła. Aspose.Slides for .NET umożliwia łatwe zastosowanie i dostosowanie zewnętrznych cieni w tekście WordArt. W tej sekcji dowiesz się, jak ustawić kolor cienia, kierunek, odległość, promień rozmycia i inne, aby uzyskać pożądany efekt wizualny.

Poniższy fragment kodu C# stosuje efekt cienia do tekstu utworzonego powyżej.

```cs
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

Rezultujący tekst:

![The Outer Shadow effect](outer_shadow_effect.png)

{{% alert color="primary" %}} 

- Gdy OuterShadow i PresetShadow są używane razem, zastosowany jest tylko efekt OuterShadow.
- Jeśli OuterShadow i InnerShadow są używane jednocześnie, wynikowy efekt zależy od wersji PowerPoint. Na przykład w PowerPoint 2013 efekt jest podwójny, natomiast w PowerPoint 2007 stosowany jest tylko efekt OuterShadow.

{{% /alert %}}

### **Zastosuj efekty odbicia**

W tej sekcji przyjrzymy się, jak zastosować efekty odbicia w slajdach przy użyciu Aspose.Slides for .NET. Efekty odbicia mogą być skutecznym sposobem na nadanie tekstowi lub kształtom stylowego, nowoczesnego wyglądu, pomagając kluczowym elementom się wyróżnić i dodając głębi prezentacji. Rozumiejąc proces stosowania i dostosowywania tych efektów, możesz łatwo dopasować je do potrzeb projektowych i wymagań brandingu.

Dodaj efekt odbicia do tekstu, korzystając z tego przykładu kodu C#:

```cs
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

Rezultujący tekst:

![The Reflection effect](reflection_effect.png)

### **Zastosuj efekty poświaty**

W tej sekcji przyjrzymy się, jak zastosować efekt poświaty do tekstu przy użyciu Aspose.Slides for .NET. Efekt poświaty może sprawić, że Twój tekst wyróżni się dzięki świetlistej obwódce, zwiększając atrakcyjność wizualną slajdów. Regulując ustawienia, takie jak kolor i intensywność, możesz łatwo dopasować poświatę do projektu i potrzeb brandingu, zapewniając, że kluczowe punkty prezentacji przyciągną uwagę odbiorców.

Zastosuj efekt poświaty do tekstu, aby błysnął lub wyróżnił się, używając następującego kodu:

```cs
    portion.PortionFormat.EffectFormat.EnableGlowEffect();
    portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
    portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```

Rezultujący tekst:

![The Glow effect](glow_effect.png)

### **Zastosuj transformacje WordArt**

W tej sekcji przyjrzymy się, jak używać transformacji w WordArt przy pomocy Aspose.Slides for .NET. Transformacje pozwalają wyginać, rozciągać lub deformować tekst, tworząc unikalne i wizualnie uderzające efekty. Opanowując te techniki, możesz łatwo dopasować kształty i style tekstu do swojej marki lub wizji kreatywnej, zapewniając spójną i dopracowaną prezentację.

Użyj właściwości `Transform` (która dotyczy całego bloku tekstu) przy pomocy poniższego kodu:

```cs
    textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

Rezultujący tekst:

![The WordArt transformation](transform_effect.png)

{{% alert color="primary" %}} 

Aspose.Slides for .NET udostępnia zestaw predefiniowanych [typów transformacji](https://reference.aspose.com/slides/pl/net/aspose.slides/textshapetype/).

{{% /alert %}} 

### **Zastosuj efekty 3D do kształtów i tekstu**

Tworzenie realistycznych, przyciągających wzrok wizualizacji może znacznie zwiększyć oddziaływanie Twoich prezentacji. W tej sekcji omówimy, jak zastosować trójwymiarowe (3D) efekty do kształtów przy użyciu Aspose.Slides for .NET. Manipulując parametrami takimi jak głębokość, kąt i oświetlenie, możesz uzyskać imponujące transformacje 3D, które od razu przyciągają uwagę publiki. Niezależnie od tego, czy dążysz do subtelnych podkreśleń, czy dramatycznych iluzji, te funkcje oferują elastyczne sposoby na podniesienie jakości projektu i przekazywanie pomysłów w bardziej fascynujący sposób.

Użyj poniższego przykładu kodu, aby ustawić efekt 3D na kształcie:

```cs
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

Rezultujący kształt:

![The shape 3D effect](shape_3D_effect.png)

Użyj poniższego przykładu kodu, aby ustawić efekt 3D na tekście:

```cs
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Height = 3.5;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Width = 3.5;

    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Height = 4;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Width = 4;

    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight= 6;

    textFrame.TextFrameFormat.ThreeDFormat.ContourColor.Color = Color.DarkRed;
    textFrame.TextFrameFormat.ThreeDFormat.ContourWidth = 1.5;

    textFrame.TextFrameFormat.ThreeDFormat.Depth= 3;

    textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;

    textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

    textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

Rezultujący tekst:

![The text 3D effect](text_3D_effect.png)

{{% alert color="primary" %}} 

Stosowanie efektów 3D do tekstu lub ich kształtów — oraz interakcja między tymi efektami — podlega określonym regułom. Rozważmy scenę obejmującą zarówno tekst, jak i kształt zawierający ten tekst. Efekt 3D zawiera trójwymiarową reprezentację obiektu oraz scenę, na której jest umieszczony.

- Jeśli scena jest ustawiona zarówno dla kształtu, jak i tekstu, priorytet ma scena kształtu, a scena tekstu jest ignorowana.
- Jeśli kształt nie ma własnej sceny, ale posiada trójwymiarową reprezentację, używana jest scena tekstu.
- Jeśli kształt nie ma w ogóle efektu 3D, traktowany jest jako płaski, a efekt 3D stosowany jest wyłącznie do tekstu.

Zachowania te odnoszą się do właściwości [ThreeDFormat.LightRig](https://reference.aspose.com/slides/pl/net/aspose.slides/threedformat/lightrig/) i [ThreeDFormat.Camera](https://reference.aspose.com/slides/pl/net/aspose.slides/threedformat/camera/).

{{% /alert %}} 

## **FAQ**

**Czy mogę używać efektów WordArt z różnymi czcionkami lub skryptami (np. arabski, chiński)?**

Tak, Aspose.Slides for .NET obsługuje Unicode i działa ze wszystkimi głównymi czcionkami i skryptami. Efekty WordArt, takie jak cień, wypełnienie i kontur, mogą być stosowane niezależnie od języka, choć dostępność czcionek i renderowanie mogą zależeć od czcionek systemowych.

**Czy mogę zastosować efekty WordArt do elementów mastera slajdów?**

Tak, możesz zastosować efekty WordArt do kształtów na slajdach macierzystych, w tym do pól zastępczych tytułu, stopki lub tekstu w tle. Zmiany w układzie mastera będą odzwierciedlone we wszystkich powiązanych slajdach.

**Czy efekty WordArt wpływają na rozmiar pliku prezentacji?**

Nieznacznie. Efekty WordArt, takie jak cienie, poświaty i gradientowe wypełnienia, mogą nieco zwiększyć rozmiar pliku ze względu na dodatkowe metadane formatowania, ale różnica jest zazwyczaj pomijalna.

**Czy mogę podglądać wynik efektów WordArt bez zapisywania prezentacji?**

Tak, możesz renderować slajdy zawierające WordArt do obrazów (np. PNG, JPEG) przy użyciu metody `GetImage` z interfejsów [IShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/) lub [ISlide](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/). Dzięki temu możesz podglądać rezultat w pamięci lub na ekranie przed zapisaniem lub wyeksportowaniem pełnej prezentacji.