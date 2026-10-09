---
title: .NET에서 프레젠테이션에 도형 효과 적용
linktitle: 도형 효과
type: docs
weight: 30
url: /ko/net/shape-effect/
keywords:
- 도형 효과
- 그림자 효과
- 반사 효과
- 글로우 효과
- 부드러운 가장자리 효과
- 효과 형식
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 고급 도형 효과로 PPT 및 PPTX 파일을 변환하고, 몇 초 만에 눈에 띄고 전문적인 슬라이드를 만들 수 있습니다."
---
## **소개**

PowerPoint에서 효과는 도형을 돋보이게 할 수 있지만, [채우기](/slides/ko/net/shape-formatting/#gradient-fill) 또는 외곽선과는 다릅니다. PowerPoint 효과를 사용하면 도형에 설득력 있는 반사 효과를 만들거나, 도형의 글로우를 확산시키는 등 다양한 연출을 할 수 있습니다.

![도형 효과](shape-effect.png)

PowerPoint는 도형에 적용할 수 있는 여섯 가지 효과를 제공합니다. 하나 이상의 효과를 도형에 적용할 수 있습니다.

일부 효과 조합은 다른 조합보다 더 보기 좋습니다. 이러한 이유로 PowerPoint에는 **Preset** 옵션이 있습니다. Preset 옵션은 본질적으로 두 개 이상의 효과를 조합한 보기 좋은 조합을 미리 정의한 것입니다. 따라서 프리셋을 선택하면 다양한 효과를 시험하거나 조합하여 멋진 조합을 찾는 데 시간을 낭비하지 않아도 됩니다.

Aspose.Slides는 PowerPoint 프레젠테이션의 도형에 동일한 효과를 적용할 수 있도록 [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) 클래스에 속성 및 메서드를 제공합니다.

## **그림자 효과 적용**

Aspose.Slides for .NET은 도형에 대한 외부 및 내부 그림자를 지원합니다. 색상, 방향, 거리 및 블러 반경을 사용자 지정하여 프레젠테이션 디자인에 맞출 수 있습니다.

### **외부 그림자 적용**

외부 그림자를 사용하면 카드나 패널이 슬라이드 배경에서 돋보이게 할 수 있습니다. 그림자는 도형 가장자리 밖으로 확장되어 도형이 슬라이드 위에 떠 있는 듯한 인상을 줍니다. 색상, 방향, 거리 및 블러 반경을 조정하여 템플릿의 조명 및 스타일에 맞출 수 있습니다.

다음 C# 코드는 사각형에 [외부 그림자 효과](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/)를 적용하는 방법을 보여줍니다:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableOuterShadowEffect();
shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.DarkGray;
shape.EffectFormat.OuterShadowEffect.Distance = 10;
shape.EffectFormat.OuterShadowEffect.Direction = 45;

presentation.Save("shadow_effect.pptx", SaveFormat.Pptx);
```

![그림자 효과](shadow_effect.png)

### **내부 그림자 적용**

템플릿의 시각 스타일을 재현할 때는 내부 그림자를 사용하여 카드나 패널에 들어갔듯한 외관을 부여합니다. 외부 그림자는 도형 외부에 확장되어 도형이 떠 있는 듯 보이게 하며, 내부 그림자는 가장자리 내부를 음영 처리합니다.

먼저 [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/)를 호출한 다음 [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/)를 구성합니다. 값이 클수록 가장자리가 부드러워집니다.

다음 C# 예제는 연한 파란색 카드에 짙은 회색 내부 그림자를 적용하고 PPTX 파일로 저장합니다:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.LightBlue;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;

shape.EffectFormat.EnableInnerShadowEffect();
var shadow = shape.EffectFormat.InnerShadowEffect;
shadow.ShadowColor.Color = Color.DimGray;
shadow.Direction = 225;
shadow.Distance = 7;
shadow.BlurRadius = 6;

presentation.Save("inner_shadow_effect.pptx", SaveFormat.Pptx);
```

![내부 그림자가 있는 연한 파란 사각형](inner_shadow_effect.png)

내부 그림자를 제거하려면 도형의 EffectFormat에서 [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/)을 호출합니다.

## **반사 효과 적용**

Aspose.Slides for .NET에서 반사 효과를 적용하려면 도형에 거울과 같은 반사를 추가하고 거리, 투명도 및 크기와 같은 매개변수를 조정하면 됩니다. 이 효과는 도형에 보다 세련되고 정교한 외관을 부여하여 프레젠테이션의 미적 품질을 향상시킵니다. 간단한 코드로 쉽게 구현할 수 있어 여러 요소에 빠르게 적용하여 일관된 디자인을 구현할 수 있습니다.

다음 C# 코드는 도형에 [반사 효과](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/)를 적용하는 방법을 보여줍니다:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableReflectionEffect();
shape.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.Bottom;
shape.EffectFormat.ReflectionEffect.Direction = 90;
shape.EffectFormat.ReflectionEffect.Distance = 40;
shape.EffectFormat.ReflectionEffect.BlurRadius = 2;

presentation.Save("reflection_effect.pptx", SaveFormat.Pptx);
```

![반사 효과](reflection_effect.png)

## **글로우 효과 적용**

Aspose.Slides for .NET에서 도형에 글로우 효과를 적용하려면 색상 및 크기와 같은 속성을 조정하여 부드럽고 빛나는 후광을 추가할 수 있습니다. 이 효과는 도형을 돋보이게 하고 프레젠테이션에 매력적이고 눈에 띄는 시각 요소를 더합니다. 최소한의 코드로 쉽게 구현할 수 있어 슬라이드 전체의 외관을 향상시킵니다.

다음 C# 코드는 도형에 [글로우 효과](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/)를 적용하는 방법을 보여줍니다:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableGlowEffect();
shape.EffectFormat.GlowEffect.Color.Color = Color.Magenta;
shape.EffectFormat.GlowEffect.Radius = 15;

presentation.Save("glow_effect.pptx", SaveFormat.Pptx);
```

![글로우 효과](glow_effect.png)

## **부드러운 가장자리 효과 적용**

Aspose.Slides for .NET에서 부드러운 가장자리 효과를 적용하면 도형의 가장자리 주변에 부드럽고 흐릿한 전환을 만들 수 있습니다. 이 효과는 보다 은은하고 정교한 외관을 제공하여 부드럽고 부드러운 모습을 필요로 하는 디자인에 적합합니다. 반경과 같은 매개변수를 쉽게 조정하여 프레젠테이션의 다양한 도형에 원하는 효과를 적용할 수 있습니다.

다음 C# 코드는 도형에 [부드러운 가장자리](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/)를 적용하는 방법을 보여줍니다:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```

![부드러운 가장자리 효과](soft_edges_effect.png)

## **자주 묻는 질문**

**동일한 도형에 여러 효과를 적용할 수 있나요?**

네, 그림자, 반사 및 글로우와 같은 다양한 효과를 단일 도형에 조합하여 보다 역동적인 외관을 만들 수 있습니다.

**어떤 도형에 효과를 적용할 수 있나요?**

자동 도형, 차트, 표, 그림, SmartArt 개체, OLE 개체 등 다양한 도형에 효과를 적용할 수 있습니다.

**그룹화된 도형에 효과를 적용할 수 있나요?**

네, 그룹화된 도형에도 효과를 적용할 수 있습니다. 효과는 전체 그룹에 적용됩니다.