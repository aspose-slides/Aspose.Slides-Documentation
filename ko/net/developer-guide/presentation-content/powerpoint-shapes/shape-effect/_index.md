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
- 광채 효과
- 부드러운 가장자리 효과
- 효과 형식
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 고급 도형 효과로 PPT 및 PPTX 파일을 변환하고, 몇 초 만에 눈에 띄고 전문적인 슬라이드를 만들 수 있습니다."
---
## **소개**

PowerPoint에서 효과는 도형을 돋보이게 할 수 있지만, [채우기](/slides/ko/net/shape-formatting/#gradient-fill)나 외곽선과는 다릅니다. PowerPoint 효과를 사용하면 도형에 사실적인 반사 효과를 만들거나, 도형의 광채를 퍼뜨리는 등 다양한 연출이 가능합니다.

![Shape effect](shape-effect.png)

PowerPoint는 도형에 적용할 수 있는 여섯 가지 효과를 제공합니다. 하나 이상의 효과를 도형에 적용할 수 있습니다.

효과 조합에 따라 결과가 다르게 보입니다. 이러한 이유로 PowerPoint는 **Preset** 아래에 옵션을 제공합니다. 프리셋 옵션은 두 개 이상의 효과를 조합한 미리 보기 좋은 조합을 의미합니다. 프리셋을 선택하면 다양한 효과를 시험하거나 조합하는 데 시간을 낭비하지 않아도 됩니다.

Aspose.Slides는 [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) 클래스에 속성 및 메서드를 제공하여 PowerPoint 프레젠테이션의 도형에 동일한 효과를 적용할 수 있게 합니다.

## **그림자 효과 적용**

Aspose.Slides for .NET은 도형에 외부 그림자와 내부 그림자를 지원합니다. 색상, 방향, 거리 및 흐림 반경을 사용자 지정하여 프레젠테이션 디자인에 맞출 수 있습니다.

### **외부 그림자 적용**

외부 그림자를 사용하면 카드나 패널을 슬라이드 배경과 구별되게 만들 수 있습니다. 그림자는 도형 가장자리를 넘어 확장되어 도형이 슬라이드 위에 띄워진 듯한 인상을 줍니다. 색상, 방향, 거리 및 흐림 반경을 조정하여 템플릿의 조명 및 스타일에 맞춥니다.

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

![Shadow effect](shadow_effect.png)

### **내부 그림자 적용**

템플릿의 시각적 스타일을 재현할 때는 내부 그림자를 사용하여 카드나 패널에 움푹 들어간 느낌을 줄 수 있습니다. 외부 그림자는 도형 외부에 그림자를 만들어 띄워진 듯 보이게 하고, 내부 그림자는 가장자리 안쪽을 어둡게 만들어 들어간 효과를 줍니다.

[EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/)를 호출한 뒤 [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/)를 구성합니다. 값이 클수록 가장자리가 부드러워집니다.

다음 C# 예제는 연한 파란색 카드를 어두운 회색 내부 그림자와 함께 만들고 PPTX 파일로 저장합니다:

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

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

내부 그림자를 제거하려면 도형의 EffectFormat에서 [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/)를 호출합니다.

## **반사 효과 적용**

Aspose.Slides for .NET에서 반사 효과를 적용하려면 도형에 거울 같은 반사를 추가하고 거리, 투명도, 크기와 같은 매개 변수를 조정하면 됩니다. 이 효과는 도형에 보다 세련되고 정교한 외관을 부여하여 프레젠테이션의 미감을 높여 줍니다. 간단한 코드로 손쉽게 구현할 수 있어 여러 요소에 일관된 디자인을 빠르게 적용할 수 있습니다.

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

![Reflection effect](reflection_effect.png)

## **광채 효과 적용**

Aspose.Slides for .NET에서 도형에 광채 효과를 적용하려면 부드럽고 빛나는 아우라를 추가하고 색상 및 크기와 같은 속성을 조정하면 됩니다. 이 효과는 도형을 돋보이게 하고 프레젠테이션에 매력적인 시각 요소를 더합니다. 최소한의 코드로 구현할 수 있어 슬라이드 전체의 외관을 향상시킵니다.

다음 C# 코드는 도형에 [광채 효과](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/)를 적용하는 방법을 보여줍니다:

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

![Glow effect](glow_effect.png)

## **부드러운 가장자리 효과 적용**

Aspose.Slides for .NET에서 부드러운 가장자리 효과를 적용하면 도형 가장자리 주변에 부드럽고 흐릿한 전환을 만들 수 있습니다. 이 효과는 보다 미묘하고 정교한 모습을 부여해 부드러운 외관이 필요한 디자인에 적합합니다. 반경과 같은 매개 변수를 쉽게 조정하여 프레젠테이션 내 다양한 도형에 원하는 효과를 적용할 수 있습니다.

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

![Soft edges effect](soft_edges_effect.png)

## **블러 효과 적용**

도형 블러를 사용하면 도형의 채우기와 외곽선을 부드럽게 만들면서도 도형 자체는 편집 가능하게 유지할 수 있습니다. 도형의 EffectFormat에서 [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/)를 호출합니다. 반경은 포인트(1/72인치) 단위이며, 음수가 아닌 값을 사용합니다. 값이 클수록 블러 강도가 강해집니다. 반경이 0이면 외관이 변하지 않습니다.

[Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) 설정은 효과의 가시적 경계를 제어합니다. `false`인 경우 블러가 원래 그린 경계(외곽선 포함) 안에 제한되고, `true`인 경우 블러가 그 경계를 넘어 확장될 수 있습니다. 두 설정 모두 도형의 위치나 크기를 바꾸지는 않습니다.

아래 비교에서는 동일한 채우기, 외곽선 및 도형 크기를 사용했습니다. 상단 행은 `grow = false`; 하단 행은 `grow = true`입니다.

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

다음 C# 예제는 주황색 사각형에 짙은 파란색 외곽선을 적용하고 5포인트 블러를 적용한 뒤, 다시 [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/)를 호출해 15포인트 블러로 업데이트합니다. 두 블러 상태를 저장한 뒤 [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/)를 호출해 블러가 없는 도형을 저장합니다.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
shape.LineFormat.Width = 8;

shape.EffectFormat.SetBlurEffect(5, false);
presentation.Save("shape_blur_5.pptx", SaveFormat.Pptx);

shape.EffectFormat.SetBlurEffect(15, true);
presentation.Save("shape_blur_15.pptx", SaveFormat.Pptx);

shape.EffectFormat.DisableBlurEffect();
presentation.Save("shape_blur_removed.pptx", SaveFormat.Pptx);
```

도형 블러는 채우기와 외곽선을 함께 영향을 주며, 부드러운 가장자리 효과는 도형 가장자리를 흐리게 하고, 그림자 블러는 그림자만 부드럽게 만듭니다. 이미지 변환 효과는 이미지 내용에 적용되지만, 이 예제는 도형을 이미지로 변환하지 않고 직접 도형의 EffectFormat에 블러를 적용합니다.

## **FAQ**

**같은 도형에 여러 효과를 적용할 수 있나요?**

예, 그림자, 반사, 광채 등 다양한 효과를 하나의 도형에 결합하여 보다 역동적인 외관을 만들 수 있습니다.

**어떤 도형에 효과를 적용할 수 있나요?**

자동 도형, 차트, 표, 사진, SmartArt 개체, OLE 개체 등 다양한 도형에 효과를 적용할 수 있습니다.

**그룹화된 도형에 효과를 적용할 수 있나요?**

예, 그룹화된 도형 전체에 효과를 적용할 수 있으며, 효과는 전체 그룹에 적용됩니다.