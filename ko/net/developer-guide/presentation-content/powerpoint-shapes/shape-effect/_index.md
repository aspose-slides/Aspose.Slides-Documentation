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
description: "Aspose.Slides for .NET를 사용하여 고급 도형 효과로 PPT 및 PPTX 파일을 변환—몇 초 만에 강렬하고 전문적인 슬라이드를 만들 수 있습니다."
---
## **소개**

PowerPoint의 효과는 도형을 돋보이게 할 때 사용할 수 있지만, [채우기](/slides/ko/net/shape-formatting/#gradient-fill) 또는 윤곽선과는 다릅니다. PowerPoint 효과를 사용하면 도형에 사실적인 반사 효과를 만들고, 도형의 글로우를 퍼뜨리는 등 다양한 효과를 구현할 수 있습니다.

![도형 효과](shape-effect.png)

PowerPoint는 도형에 적용할 수 있는 6가지 효과를 제공합니다. 하나 이상의 효과를 도형에 적용할 수 있습니다.

일부 효과 조합은 다른 조합보다 더 보기 좋습니다. 이러한 이유로 PowerPoint에는 **프리셋** 옵션이 있습니다. 프리셋 옵션은 기본적으로 두 개 이상 효과의 잘 어울리는 조합을 의미합니다. 따라서 프리셋을 선택하면 다양한 효과를 시험하거나 조합하여 좋은 조합을 찾는 데 시간을 들일 필요가 없습니다.

Aspose.Slides는 PowerPoint 프레젠테이션의 도형에 동일한 효과를 적용할 수 있도록 [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) 클래스를 통해 속성 및 메서드를 제공합니다.

## **그림자 효과 적용**

Aspose.Slides for .NET는 도형에 대한 외부 그림자와 내부 그림자를 지원합니다. 색상, 방향, 거리 및 블러 반경을 프레젠테이션 디자인에 맞게 사용자 지정할 수 있습니다.

### **외부 그림자 적용**

외부 그림자를 사용하면 카드나 패널이 슬라이드 배경에 대비되어 돋보이게 할 수 있습니다. 그림자는 도형 가장자리를 넘어 확장되어 도형이 슬라이드 위로 떠 있는 듯한 인상을 줍니다. 색상, 방향, 거리 및 블러 반경을 템플릿의 조명과 스타일에 맞게 조정하십시오.

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

템플릿의 시각적 스타일을 재현할 때는 내부 그림자를 사용하여 카드나 패널에 오목한 모습을 부여합니다. 외부 그림자는 도형 외부로 확장되어 떠 있는 듯한 효과를 주는 반면, 내부 그림자는 가장자리 내부를 그림자로 처리합니다.

먼저 [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/)를 호출하고, 그런 다음 [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/)를 구성합니다. 높은 값일수록 부드러운 가장자리를 만듭니다.

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

![내부 그림자가 있는 연한 파란 사각형](inner_shadow_effect.png)

내부 그림자를 제거하려면 도형의 EffectFormat에서 [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/)를 호출합니다.

### **프리셋 그림자 적용, 변경 및 제거**

먼저 [EnablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/enablepresetshadoweffect/)를 호출하고, [Preset](https://reference.aspose.com/slides/net/aspose.slides.effects/ipresetshadow/preset/)을 지정된 [PresetShadowType](https://reference.aspose.com/slides/net/aspose.slides/presetshadowtype/)으로 설정합니다. 스타일을 전환하려면 같은 도형에서 프리셋을 변경합니다. 그림자를 제거하면서 채우기와 윤곽선을 유지하려면 [DisablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disablepresetshadoweffect/)를 호출합니다.

이 예제는 각 단계에서 사각형 사본을 유지합니다. 두 그림자는 모두 10포인트만큼 오프셋됩니다. 225° 방향은 첫 번째 그림자를 사각형의 위쪽 왼쪽에 배치하고, 45° 방향은 두 번째 그림자를 아래쪽 오른쪽에 배치합니다.
```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(800, 120, SlideSizeScaleType.DoNotScale);
var shapes = presentation.Slides[0].Shapes;

var shape = shapes.AddAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.SteelBlue;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
shape.TextFrame.Text = "No shadow";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 14;
shapes.AddClone(shape);

shape.X += 200;
shape.EffectFormat.EnablePresetShadowEffect();
var shadow = shape.EffectFormat.PresetShadowEffect;
shadow.Preset = PresetShadowType.TopLeftDropShadow;
shadow.Distance = 10;
shadow.Direction = 225;
shape.TextFrame.Text = shadow.Preset.ToString();
shapes.AddClone(shape);

shape.X += 200;
shadow.Preset = PresetShadowType.BottomRightDropShadow;
shadow.Direction = 45;
shape.TextFrame.Text = shadow.Preset.ToString();
shapes.AddClone(shape);

shape.X += 200;
shape.EffectFormat.DisablePresetShadowEffect();
shape.TextFrame.Text = "No shadow";

presentation.Save("preset_shadows.pptx", SaveFormat.Pptx);
```

| 원본 | 첫 번째 프리셋 | 두 번째 프리셋 | 제거 후 |
| :---: | :---: | :---: | :---: |
| ![그림자 없음](preset_shadow_original.png) | ![왼쪽 위 그림자](preset_shadow_top_left.png) | ![오른쪽 아래 그림자](preset_shadow_bottom_right.png) | ![제거 후 그림자 없음](preset_shadow_removed.png) |

## **반사 효과 적용**

Aspose.Slides for .NET에서 반사 효과를 적용하려면 도형에 거울과 같은 반사를 추가하고 거리, 투명도 및 크기와 같은 매개변수를 조정하면 됩니다. 이 효과는 도형에 보다 세련되고 정교한 모습을 부여하여 프레젠테이션의 미적 가치를 높입니다. 간단한 코드로 쉽게 구현할 수 있어 여러 요소에 빠르게 적용하여 일관된 디자인을 구현할 수 있습니다.

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

Aspose.Slides for .NET에서 도형에 글로우 효과를 적용하려면 색상 및 크기와 같은 속성을 조정하면서 부드럽고 빛나는 광환을 도형 주위에 추가할 수 있습니다. 이 효과는 도형을 돋보이게 하고 프레젠테이션에 매력적이고 눈에 띄는 시각 요소를 추가합니다. 최소한의 코드로 쉽게 구현할 수 있어 슬라이드 전체의 외관을 향상시킵니다.

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

Aspose.Slides for .NET에서 부드러운 가장자리 효과를 적용하려면 도형의 가장자리 주변에 부드럽고 흐릿한 전환을 만들 수 있습니다. 이 효과는 보다 미묘하고 정교한 외관을 제공하여 부드럽고 섬세한 디자인에 적합합니다. 반경과 같은 매개변수를 쉽게 조정하여 프레젠테이션의 다양한 도형에 원하는 효과를 적용할 수 있습니다.

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

## **블러 효과 적용**

도형 블러를 사용하면 도형을 편집 가능하게 유지하면서 채우기와 윤곽선을 부드럽게 만들 수 있습니다. 도형의 EffectFormat에서 [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/)를 호출합니다. 반경은 포인트(1/72 인치) 단위이며, 음수가 아닌 값을 사용하고 값이 클수록 블러가 강해집니다. 반경이 0이면 외관이 그대로 유지됩니다.

[Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) 설정은 효과의 보이는 경계를 제어합니다. `false`인 경우 블러가 윤곽선을 포함한 원래 그려진 경계에 클리핑됩니다. `true`인 경우 블러가 해당 경계를 넘어 확장될 수 있습니다. 두 설정 모두 도형의 위치나 크기를 변경하지 않습니다.

아래 비교에서는 동일한 채우기, 윤곽선 및 도형 크기가 전체에 걸쳐 사용됩니다. 상단 행은 `grow = false`를 사용하고, 하단 행은 `grow = true`를 사용합니다.

![grow 비활성화 및 활성화 시 5포인트와 15포인트 블러 반경을 가진 원본 사각형 비교](shape_blur_comparison.png)

다음 C# 예제는 주황색 사각형에 어두운 파란색 윤곽선을 적용하고, 5포인트 블러를 적용한 뒤 다시 [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/)를 호출하여 15포인트 블러로 업데이트합니다. 두 블러 효과가 적용된 상태를 저장한 다음 [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/)를 호출하여 블러가 없는 도형을 저장합니다.
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

도형 블러는 채우기와 윤곽선을 함께 영향을 줍니다. 부드러운 가장자리 효과는 도형의 가장자리를 페이드 처리하는 반면, 그림자 블러는 그림자만 부드럽게 합니다. 이미지 변환 효과는 이미지 콘텐츠에 적용되며, 이 예제는 도형을 이미지로 변환하지 않고 도형의 EffectFormat에 직접 블러를 적용합니다.

## **FAQ**

**같은 도형에 여러 효과를 적용할 수 있나요?**  
예, 그림자, 반사, 글로우와 같은 다양한 효과를 하나의 도형에 결합하여 보다 역동적인 모습을 만들 수 있습니다.

**어떤 도형에 효과를 적용할 수 있나요?**  
자동 도형, 차트, 표, 그림, SmartArt 개체, OLE 개체 등 다양한 도형에 효과를 적용할 수 있습니다.

**그룹화된 도형에 효과를 적용할 수 있나요?**  
예, 그룹화된 도형에도 효과를 적용할 수 있습니다. 효과는 전체 그룹에 적용됩니다.