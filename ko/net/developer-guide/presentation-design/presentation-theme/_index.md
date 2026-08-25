---
title: .NET에서 프레젠테이션 테마 관리
linktitle: 프레젠테이션 테마
type: docs
weight: 10
url: /ko/net/presentation-theme/
keywords:
- PowerPoint 테마
- 프레젠테이션 테마
- 슬라이드 테마
- 테마 설정
- 테마 변경
- 테마 관리
- 테마 색상
- 추가 팔레트
- 테마 글꼴
- 테마 스타일
- 테마 효과
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 마스터 프레젠테이션 테마를 사용하여 일관된 브랜딩으로 PowerPoint 파일을 만들고, 커스터마이즈하고, 변환합니다."
---
## **소개**

프레젠테이션 테마는 색상, 글꼴, 배경 스타일, 채우기, 선 및 효과의 조정된 집합을 정의합니다. 테마 인식 객체는 모든 시각 속성을 고정값으로 저장하는 대신 이러한 공유 정의를 참조하므로 테마를 변경하면 여러 객체를 한 번에 업데이트할 수 있습니다.

Aspose.Slides에서 프레젠테이션 수준 테마는 [Presentation.MasterTheme](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/mastertheme/) 속성을 통해 사용할 수 있습니다. 프레젠테이션은 하위 수준에서도 테마 재정의를 포함할 수 있습니다. 마스터는 [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/masterthememanager/overridetheme/)를 통해 프레젠테이션 테마를 재정의할 수 있고, 레이아웃은 [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/baseoverridethememanager/overridetheme/)를 통해 상속된 테마를 재정의할 수 있으며, 개별 슬라이드도 동일하게 할 수 있습니다. 실제로 슬라이드에 적용되는 테마는 다음과 같은 상속 체인을 통해 결정됩니다: 프레젠테이션 테마 → 마스터 재정의 → 레이아웃 재정의 → 슬라이드 재정의.

![테마 구성 요소: 색상, 글꼴, 배경 스타일 및 효과](theme-constituents.png)

아래 섹션에서는 가장 일반적인 테마 작업 흐름을 보여줍니다: 테마 검사, 색상 및 글꼴 변경, 테마 복사 또는 적용, 배경 및 효과 스타일 업데이트, 상속 및 재정의가 해결된 후 실제 값을 읽기 등.

## **테마 검사**

[MasterTheme](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/mastertheme/) 객체는 테마의 [ColorScheme](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/mastertheme/fontscheme/), 및 [FormatScheme](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/mastertheme/formatscheme/)을 노출합니다. 변경하기 전에 이러한 컬렉션을 검사하면 프레젠테이션이 외부 소스에서 온 경우 스타일 항목의 수와 내용이 다양할 수 있기 때문에 특히 유용합니다.

다음 예제는 주요 테마 속성을 읽고 테마에 저장된 배경, 채우기, 선 및 효과 스타일이 각각 몇 개 있는지 보고합니다:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var theme = presentation.MasterTheme;

Console.WriteLine($"Theme name: {theme.Name}");
Console.WriteLine($"Accent 1: {theme.ColorScheme.Accent1.Color}");
Console.WriteLine($"Major Latin font: {theme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Minor Latin font: {theme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Background fill styles: {theme.FormatScheme.BackgroundFillStyles.Count}");
Console.WriteLine($"Fill styles: {theme.FormatScheme.FillStyles.Count}");
Console.WriteLine($"Line styles: {theme.FormatScheme.LineStyles.Count}");
Console.WriteLine($"Effect styles: {theme.FormatScheme.EffectStyles.Count}");
```

파일에 마스터가 여러 개 사용되는 경우 모든 슬라이드가 동일한 실제 테마를 가진다고 가정하지 마십시오. 슬라이드와 연결된 마스터를 검사하고 레이아웃 또는 슬라이드 재정의가 있을 수 있는 경우 이 문서에서 나중에 보여줄 실제 테마 작업 흐름을 사용하십시오.

## **테마 색상 변경**

테마 인식 채우기, 선 및 텍스트는 [SchemeColor](https://reference.aspose.com/slides/ko/net/aspose.slides/schemecolor/) 열거형의 논리 색상을 참조할 수 있습니다. 테마의 [IColorScheme](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/icolorscheme/)에서 해당 항목을 변경하면 여전히 해당 테마 색상을 참조하는 모든 객체가 새로운 값으로 해결됩니다. 직접 RGB 색상을 사용하는 객체는 테마 색상 업데이트의 영향을 받지 않습니다.

다음 엔드 투 엔드 예제는 `Accent4`를 사용하는 도형을 만든 다음 테마의 `Accent4` 색상을 빨간색으로 변경하고 프레젠테이션을 저장한 뒤 다시 열어 실제 채우기 색상을 출력합니다:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
presentation.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
presentation.Save("theme-color.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("theme-color.pptx");
var savedSlide = savedPresentation.Slides[0];
var savedShape = savedSlide.Shapes[0];
var effectiveFill = savedShape.FillFormat.GetEffective();
Console.WriteLine($"Effective fill color: {effectiveFill.SolidFillColor}");
```

사각형이 `Accent4`에 계속 연결되어 있기 때문에 테마가 변경된 후 보이는 색상이 빨간색이 됩니다. 도형에 직접 색상을 지정하여 스킴 색상을 교체하면 이후 `Accent4` 변경이 해당 채우기에 영향을 주지 않습니다.

### **추가 팔레트의 색상 사용**

PowerPoint는 테마 색상에 색상 변환을 적용하여 밝고 어두운 변형을 생성합니다. Aspose.Slides는 이러한 변환을 [ColorTransformOperation](https://reference.aspose.com/slides/ko/net/aspose.slides/colortransformoperation/)을 통해 노출합니다.

![주 테마 색상 및 추가 팔레트에서 생성된 밝고 어두운 색상](additional-palette-colors.png)

**1** – 주 테마 색상.

**2** – 주 테마 색상에서 파생된 밝고 어두운 변형.

다음 예제는 `Accent4`를 기반으로 여섯 개의 사각형을 만들고 그 중 다섯 개에 명도 변환을 적용한 뒤 결과를 저장합니다:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
shape1.FillFormat.FillType = FillType.Solid;
shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
shape2.FillFormat.FillType = FillType.Solid;
shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
shape3.FillFormat.FillType = FillType.Solid;
shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
shape4.FillFormat.FillType = FillType.Solid;
shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

var shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
shape5.FillFormat.FillType = FillType.Solid;
shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

var shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
shape6.FillFormat.FillType = FillType.Solid;
shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

presentation.Save("theme-color-palette.pptx", SaveFormat.Pptx);
```

이 변형은 여전히 테마 색상을 기반으로 합니다. `Accent4`가 나중에 변경되면 변환된 색상은 새로운 `Accent4` 값으로 다시 계산됩니다.

### **`SchemeColor` 값을 `IColorScheme` 슬롯에 매핑**

[SchemeColor](https://reference.aspose.com/slides/ko/net/aspose.slides/schemecolor/) 열거형은 `Text1`, `Background1`, `Text2`, `Background2`를 사용하고, [IColorScheme](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/icolorscheme/)은 동일한 테마 슬롯을 `Dark1`, `Light1`, `Dark2`, `Light2`로 노출합니다. 매핑은 고정됩니다:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

이들은 동일한 테마 슬롯에 대한 대체 이름이며, 한 형태에서 다른 형태로 동적으로 변환되는 값이 아닙니다.

## **테마 글꼴 변경**

테마 글꼴 스키마는 제목용 주요 글꼴 집합과 본문용 보조 글꼴 집합을 포함합니다. [FontScheme.Major](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/fontscheme/major/) 및 [FontScheme.Minor](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/fontscheme/minor/) 속성이 해당 집합을 노출합니다.

PowerPoint 호환 테마 글꼴 식별자는 텍스트 서식에 사용할 수 있습니다:

* `+mn-lt` – 본문 글꼴 라틴어 (Minor Latin Font)
* `+mj-lt` – 제목 글꼴 라틴어 (Major Latin Font)
* `+mn-ea` – 본문 글꼴 동아시아어 (Minor East Asian Font)
* `+mj-ea` – 제목 글꼴 동아시아어 (Major East Asian Font)

다음 예제는 주요 라틴 테마 글꼴을 사용하는 제목 하나와 보조 라틴 테마 글꼴을 사용하는 본문 라인 하나를 만든 뒤 테마 글꼴을 변경하고 결과를 저장합니다:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var heading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
heading.TextFrame.Text = "Theme heading";
heading.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mj-lt");

var body = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
body.TextFrame.Text = "Theme body text";
body.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mn-lt");

presentation.MasterTheme.FontScheme.Major.LatinFont = new FontData("Aptos Display");
presentation.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");

presentation.Save("theme-fonts.pptx", SaveFormat.Pptx);
```

제목은 주요 글꼴을 따르고 본문 텍스트는 보조 글꼴을 따릅니다. 테마 식별자가 아닌 명시적인 글꼴 이름을 가진 텍스트는 테마 글꼴 스키마가 변경되어도 자동으로 전환되지 않습니다.

주요 및 보조 글꼴 컬렉션에는 키릴 문자, 아랍어, 일본어, 그루지야어, 타나어 등 개별 작문 체계에 대한 글꼴 매핑도 포함될 수 있습니다. 이러한 매핑을 검사, 추가, 교체 또는 제거하려면 [Script‑Specific Theme Fonts](/slides/ko/net/script-specific-font-mappings/) 를 참조하십시오.

{{% alert color="info" title="Tip" %}}
프레젠테이션 글꼴에 대한 자세한 내용은 [PowerPoint Fonts](/slides/ko/net/powerpoint-fonts/) 를 확인하십시오.
{{% /alert %}}

## **테마 복사 또는 적용**

두 가지 일반적인 작업 흐름이 있으며, 각각 다른 문제를 해결합니다.

### **슬라이드 이동 시 원본 테마 보존**

슬라이드를 다른 프레젠테이션으로 이동하면서 원래 디자인을 보존하려면 [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/ko/net/aspose.slides/imasterslidecollection/addclone/) 로 소스 마스터를 대상 프레젠테이션에 복제한 다음 [ISlideCollection.AddClone](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection/addclone/) 로 슬라이드와 복제된 마스터를 복제하십시오. 이렇게 하면 마스터, 레이아웃 및 연관된 테마가 함께 이동됩니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var sourceSlide = source.Slides[0];
var sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
var clonedMaster = target.Masters.AddClone(sourceMaster);
target.Slides.AddClone(sourceSlide, clonedMaster, true);

target.Save("theme-preserved.pptx", SaveFormat.Pptx);
```

대상 슬라이드가 동일하게 보이도록 해야 할 때 권장되는 작업 흐름입니다. 무관한 대상 마스터에 콘텐츠만 복제하면 테마 기반 색상, 글꼴, 배경 및 효과가 변경될 수 있습니다.

### **기존 슬라이드에 테마 값 적용**

대상 슬라이드가 현재 마스터와 레이아웃을 유지해야 하는 경우 소스 테마에서 슬라이드 수준 재정의를 초기화합니다. [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/overridetheme/initfontschemefrom/), 및 [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/overridetheme/initformatschemefrom/) 메서드는 세 가지 주요 테마 구성 요소를 재정의에 복사합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetSlide = target.Slides[0];
var overrideTheme = targetSlide.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
```

이렇게 하면 해당 슬라이드에만 테마가 변경되고 다른 슬라이드가 상속받는 테마는 그대로 유지됩니다. 로컬 재정을 제거하고 상속값으로 돌아가려면 [OverrideTheme.Clear](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/overridetheme/clear/) 를 호출하십시오.

### **레이아웃에 테마 재정의 적용**

레이아웃 수준 재정의는 해당 레이아웃을 사용하는 슬라이드에 적용되며, 특정 슬라이드가 자체 재정의를 가지고 있지 않은 한 적용됩니다. 동일한 초기화 메서드를 레이아웃의 [LayoutSlideThemeManager](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/layoutslidethememanager/) 를 통해 사용할 수 있습니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetLayout = target.Slides[0].LayoutSlide;
var overrideTheme = targetLayout.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
```

많은 레이아웃과 슬라이드가 동일한 기본 디자인을 공유해야 할 경우 마스터나 프레젠테이션 수준 테마를 사용하고, 하나의 레이아웃 패밀리만 다른 스타일이 필요할 경우 레이아웃 재정의를, 진정한 예외에만 슬라이드 재정의를 사용하십시오. 과도한 슬라이드 수준 재정의는 이후 전역 테마 변경을 예측하기 어렵게 만들 수 있습니다.

## **테마 배경 스타일 업데이트**

테마의 배경 채우기는 [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) 에 저장됩니다. PowerPoint UI는 테마 채우기와 테마 색상 및 기타 스타일 참조를 결합할 수 있기 때문에 실제 컬렉션에 물리적으로 저장된 채우기 정의보다 더 많은 배경 선택지를 UI에 표시할 수 있습니다.

![프레젠테이션 테마에 대한 PowerPoint 배경 스타일 갤러리](presentation-design_8.png)

배경 스타일을 사용하기 전에 저장된 컬렉션과 현재 [Background.StyleIndex](https://reference.aspose.com/slides/ko/net/aspose.slides/background/styleindex/) 를 검사하십시오. `StyleIndex` 가 `0`이면 테마 채우기가 없으며, 양수 값은 테마 배경 스타일 참조를 의미합니다. 이는 .NET 컬렉션을 직접 인덱싱할 때 `[0]`이 첫 번째 저장 항목을 의미하는 것과 다릅니다. 모든 프레젠테이션에 동일한 배경 채우기 스타일 수가 있다고 가정하지 마십시오.

다음 예제는 사용 가능한 배경 채우기 개수를 보고, 첫 번째 마스터에 테마 배경 참조를 할당하고 프레젠테이션을 저장합니다:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var backgroundStyles = presentation.MasterTheme.FormatScheme.BackgroundFillStyles;
Console.WriteLine($"Background fill styles: {backgroundStyles.Count}");

if (backgroundStyles.Count == 0)
{
    throw new InvalidOperationException("The presentation theme does not contain background fill styles.");
}

presentation.Masters[0].Background.Type = BackgroundType.Themed;
presentation.Masters[0].Background.StyleIndex = 1;

presentation.Save("theme-background.pptx", SaveFormat.Pptx);
```

보이는 결과는 마스터가 참조하는 테마 항목과 레이아웃 또는 슬라이드 수준의 배경 재정의 여부에 따라 달라집니다. 슬라이드가 자체 배경을 사용하는 경우 마스터 배경만 변경해도 해당 슬라이드에는 영향을 주지 않을 수 있습니다. 상속이 적용된 최종 배경을 알아야 할 경우 [Background.GetEffective](https://reference.aspose.com/slides/ko/net/aspose.slides/background/geteffective/) 를 사용하십시오.

{{% alert color="warning" title="Warning" %}}
`StyleIndex` 를 0 기반 컬렉션 인덱스로 취급하지 마십시오. 또한 한 파일에서 스타일 번호를 하드 코딩하고 다른 파일에서도 동일한 모양을 기대하지 마십시오. 테마 스타일 정의는 프레젠테이션마다 다릅니다.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
직접 배경 서식 및 배경 상속에 대해서는 [Presentation Background](/slides/ko/net/presentation-background/) 를 참조하십시오.
{{% /alert %}}

## **테마 효과 업데이트**

테마 포맷 스키마에는 별도의 [FillStyles](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/formatscheme/linestyles/), 및 [EffectStyles](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/formatscheme/effectstyles/) 컬렉션이 포함됩니다. 일반적인 Office 테마에는 미묘함, 보통, 강렬한 서식을 시각적으로 대응시키는 세 개의 주요 스타일 항목이 포함되는 경우가 많지만, 코드는 고정된 개수를 가정하지 말고 각 컬렉션을 검사해야 합니다.

![같은 도형에 적용된 미묘함, 보통, 강렬함 테마 효과](presentation-design_10.png)

C#에서 이러한 컬렉션에 접근할 때 컬렉션 인덱스는 0 기반입니다: `[0]` 은 첫 번째 저장 스타일이고 `[2]` 은 세 번째 스타일입니다. 도형의 스타일‑참조 인덱스는 별개의 개념으로, [IShapeStyle](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapestyle/) 를 통해 노출됩니다. 테마 스타일을 수정하면 해당 테마 스타일을 참조하는 도형에 영향을 주며, 직접 서식을 적용한 도형은 변경되지 않을 수 있습니다.

다음 예제는 필요한 스타일 항목이 존재하는지 확인하고, 첫 번째 선 스타일을 변경하고, 세 번째 채우기 스타일을 변경하고, 세 번째 효과 스타일에 외부 그림자를 적용한 뒤 결과를 저장합니다:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Subtle_Moderate_Intense.pptx");
var formatScheme = presentation.MasterTheme.FormatScheme;

if (formatScheme.LineStyles.Count < 1 || formatScheme.FillStyles.Count < 3 || formatScheme.EffectStyles.Count < 3)
{
    throw new InvalidOperationException("The theme does not contain the style entries required by this example.");
}

formatScheme.LineStyles[0].FillFormat.FillType = FillType.Solid;
formatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;
formatScheme.FillStyles[2].FillType = FillType.Solid;
formatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;
formatScheme.EffectStyles[2].EffectFormat.EnableOuterShadowEffect();
formatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

presentation.Save("theme-effects.pptx", SaveFormat.Pptx);
```

해당 슬롯을 참조하는 도형의 경우 첫 번째 테마 선 스타일이 빨간색이 되고, 세 번째 테마 채우기 스타일이 단색 숲 녹색이 되며, 세 번째 효과 스타일에 거리 10포인트의 외부 그림자가 추가됩니다. 정확한 시각 결과는 각 도형이 어떤 스타일 슬롯을 참조하는지와 직접 서식이 테마를 오버라이드하는지에 따라 달라집니다.

![선, 채우기 및 그림자 설정을 변경한 후의 테마 효과 스타일](presentation-design_11.png)

## **실제 테마 값 읽기**

원시 테마 객체는 특정 수준에서 정의된 내용을 알려줍니다. 실제 값은 상속 및 로컬 재정의가 해결된 후 슬라이드나 도형이 실제로 사용하는 값을 알려줍니다. 슬라이드에 대해서는 [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) 를 호출합니다. 배경에 대해서는 [Background.GetEffective](https://reference.aspose.com/slides/ko/net/aspose.slides/background/geteffective/) 를, 채우기에 대해서는 [FillFormat.GetEffective](https://reference.aspose.com/slides/ko/net/aspose.slides/fillformat/geteffective/) 를 사용하십시오.

다음 예제는 슬라이드에서 실제 테마, 배경 및 첫 번째 도형 채우기를 읽습니다:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];
var effectiveTheme = slide.ThemeManager.CreateThemeEffective();
var effectiveBackground = slide.Background.GetEffective();

Console.WriteLine($"Effective major Latin font: {effectiveTheme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Effective minor Latin font: {effectiveTheme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Effective background fill type: {effectiveBackground.FillFormat.FillType}");

if (slide.Shapes.Count > 0)
{
    var effectiveFill = slide.Shapes[0].FillFormat.GetEffective();
    Console.WriteLine($"First shape effective fill type: {effectiveFill.FillType}");
    if (effectiveFill.FillType == FillType.Solid)
    {
        Console.WriteLine($"First shape effective fill color: {effectiveFill.SolidFillColor}");
    }
}
```

렌더링 진단, 검증 및 비교를 위해 실제 데이터를 사용하십시오. [Presentation.MasterTheme](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/mastertheme/) 만 검사하면 최종 모양을 변경하는 마스터, 레이아웃, 슬라이드 또는 도형 재정의를 놓칠 수 있습니다.

## **FAQ**

**단일 슬라이드에만 테마를 적용하고 마스터는 변경하지 않을 수 있나요?**

예. 슬라이드의 [SlideThemeManager](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/slidethememanager/) 를 사용하고 재정의 테마를 초기화하십시오. 변경 사항은 해당 슬라이드에만 로컬하게 적용되며, 다른 슬라이드는 기존 테마를 계속 상속합니다.

**한 프레젠테이션에서 다른 프레젠테이션으로 테마를 안전하게 이동하는 방법은?**

슬라이드를 이동하면서 원본 모양을 보존하려면 소스 마스터를 대상에 복제하고 [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/ko/net/aspose.slides/imasterslidecollection/addclone/) 와 [ISlideCollection.AddClone](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection/addclone/) 을 사용하여 해당 마스터와 함께 슬라이드를 복제하십시오. 이렇게 하면 마스터, 레이아웃 및 테마가 함께 유지됩니다.

**상속 및 재정의 후 실제 값을 어떻게 확인할 수 있나요?**

슬라이드 또는 레이아웃 테마에 대해서는 [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) 를 사용하고, 포맷 객체에 대해서는 [Background.GetEffective](https://reference.aspose.com/slides/ko/net/aspose.slides/background/geteffective/) 와 [FillFormat.GetEffective](https://reference.aspose.com/slides/ko/net/aspose.slides/fillformat/geteffective/) 등 해당 실제‑데이터 메서드를 사용하십시오. 이러한 API는 상속 및 재정의가 적용된 후 해결된 값을 반환합니다.