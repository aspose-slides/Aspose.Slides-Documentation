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
- 외부 테마
- THMX
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
description: "Aspose.Slides for .NET에서 프레젠테이션 테마를 마스터하여 일관된 브랜딩으로 PowerPoint 파일을 만들고, 사용자 지정하며, 변환합니다."
---
## **소개**

프레젠테이션 테마는 색상, 글꼴, 배경 스타일, 채우기, 선, 효과 등으로 구성된 조정된 세트를 정의합니다. 테마 인식 객체는 모든 시각 속성을 고정값으로 저장하는 대신 이러한 공유 정의를 참조하므로 테마를 변경하면 여러 객체를 한 번에 업데이트할 수 있습니다.

Aspose.Slides에서 프레젠테이션 수준의 테마는 [Presentation.MasterTheme](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/mastertheme/) 속성을 통해 사용할 수 있습니다. 프레젠테이션은 하위 수준에서도 테마 오버라이드를 포함할 수 있습니다. 마스터는 [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/masterthememanager/overridetheme/)을 통해 프레젠테이션 테마를 오버라이드할 수 있고, 레이아웃은 [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/baseoverridethememanager/overridetheme/)을 통해 상속된 테마를 오버라이드할 수 있으며, 개별 슬라이드도 동일하게 동작합니다. 실제로 슬라이드에 적용되는 유효 테마는 다음과 같은 상속 체인을 통해 결정됩니다: 프레젠테이션 테마 → 마스터 오버라이드 → 레이아웃 오버라이드 → 슬라이드 오버라이드.

![테마 구성 요소: 색상, 글꼴, 배경 스타일 및 효과](theme-constituents.png)

아래 섹션에서는 가장 일반적인 테마 작업 흐름을 보여줍니다: 테마 검사, 색상 및 글꼴 변경, 테마 복사 또는 적용, 배경 및 효과 스타일 업데이트, 그리고 상속과 오버라이드가 적용된 후의 유효 값 읽기.

## **테마 검사**

[MasterTheme](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/mastertheme/) 객체는 테마의 [ColorScheme](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/mastertheme/fontscheme/), 그리고 [FormatScheme](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/mastertheme/formatscheme/)을 노출합니다. 변경하기 전에 이러한 컬렉션을 검사하는 것은 프레젠테이션이 외부 소스에서 온 경우 특히 유용합니다. 스타일 항목의 수와 내용이 다를 수 있기 때문입니다.

다음 예제는 주요 테마 속성을 읽고 테마에 저장된 배경, 채우기, 선 및 효과 스타일의 개수를 보고합니다:

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

파일에 여러 마스터가 사용된 경우 모든 슬라이드가 동일한 유효 테마를 가진다고 가정하지 마세요. 슬라이드와 연결된 마스터를 검사하고, 레이아웃이나 슬라이드 오버라이드가 존재할 수 있는 경우 이 문서 뒷부분에 표시된 유효 테마 작업 흐름을 사용하세요.

## **테마 색상 변경**

테마 인식 채우기, 선 및 텍스트는 [SchemeColor](https://reference.aspose.com/slides/ko/net/aspose.slides/schemecolor/) 열거형의 논리 색상을 참조할 수 있습니다. 테마의 [IColorScheme](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/icolorscheme/)에서 해당 항목을 변경하면 여전히 해당 테마 색상을 참조하는 모든 객체가 새로운 값으로 해석됩니다. 직접 RGB 색상을 사용하는 객체는 테마 색상 업데이트의 영향을 받지 않습니다.

다음 엔드‑투‑엔드 예제는 `Accent4`를 사용하는 도형을 만들고, 테마의 `Accent4` 색상을 빨간색으로 변경한 뒤 프레젠테이션을 저장하고 다시 열어 유효 채우기 색상을 출력합니다:

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

사각형이 `Accent4`와 연결되어 있기 때문에 테마가 변경된 후 보이는 색상이 빨간색으로 바뀝니다. 도형에 직접 색상을 지정하면 이후 `Accent4`가 변경되어도 해당 채우기는 영향을 받지 않습니다.

### **추가 팔레트의 색상 사용**

PowerPoint는 테마 색상에 색상 변환을 적용하여 밝은 변형과 어두운 변형을 만들어냅니다. Aspose.Slides는 이러한 변환을 [ColorTransformOperation](https://reference.aspose.com/slides/ko/net/aspose.slides/colortransformoperation/)을 통해 노출합니다.

![주 테마 색상과 추가 팔레트에서 생성된 밝고 어두운 색상](additional-palette-colors.png)

**1** - 주 테마 색상.  
**2** - 주 테마 색상에서 파생된 밝고 어두운 변형.

다음 예제는 `Accent4`를 기반으로 여섯 개의 사각형을 만들고, 그 중 다섯 개에 밝기 변환을 적용한 뒤 결과를 저장합니다:

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

이 변형들은 여전히 테마 색상을 기반으로 합니다. `Accent4`가 나중에 변경되면 변환된 색상은 새로운 `Accent4` 값으로 다시 계산됩니다.

### **`SchemeColor` 값을 `IColorScheme` 슬롯에 매핑**

[SchemeColor](https://reference.aspose.com/slides/ko/net/aspose.slides/schemecolor/) 열거형은 `Text1`, `Background1`, `Text2`, `Background2`를 사용하고, [IColorScheme](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/icolorscheme/)은 동일한 테마 슬롯을 `Dark1`, `Light1`, `Dark2`, `Light2`로 노출합니다. 매핑은 고정됩니다:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

이들은 동일한 테마 슬롯에 대한 다른 이름일 뿐이며, 동적으로 변환되는 값이 아닙니다.

## **테마 글꼴 변경**

테마 글꼴 스킴은 제목용 주요 글꼴 세트와 본문용 부수 글꼴 세트를 포함합니다. [FontScheme.Major](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/fontscheme/major/) 및 [FontScheme.Minor](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/fontscheme/minor/) 속성이 해당 세트를 노출합니다.

PowerPoint 호환 테마 글꼴 식별자는 텍스트 서식에 사용할 수 있습니다:

* `+mn‑lt` - 본문 글꼴 라틴어 (Minor Latin Font)
* `+mj‑lt` - 제목 글꼴 라틴어 (Major Latin Font)
* `+mn‑ea` - 본문 글꼴 동아시아어 (Minor East Asian Font)
* `+mj‑ea` - 제목 글꼴 동아시아어 (Major East Asian Font)

다음 예제는 주요 라틴 테마 글꼴을 사용하는 제목 하나와 부수 라틴 테마 글꼴을 사용하는 본문 라인 하나를 만든 뒤 테마 글꼴을 변경하고 결과를 저장합니다:

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

제목은 주요 글꼴을 따르고 본문 텍스트는 부수 글꼴을 따릅니다. 명시적으로 글꼴 이름을 지정한 텍스트는 테마 글꼴 스킴이 변경되어도 자동으로 전환되지 않습니다.

주요 및 부수 글꼴 컬렉션에는 키릴문자, 아라비아 문자, 일본어, 그루지아 문자, 타아나 문자와 같은 개별 쓰기 시스템에 대한 글꼴 매핑도 포함될 수 있습니다. 이러한 매핑을 검사, 추가, 교체 또는 제거하려면 [Script‑Specific Theme Fonts](/slides/ko/net/script-specific-font-mappings/)를 참조하세요.

{{% alert color="info" title="Tip" %}}
프레젠테이션 글꼴에 대한 자세한 내용은 [PowerPoint Fonts](/slides/ko/net/powerpoint-fonts/)를 확인하세요.
{{% /alert %}}

## **테마 복사 또는 적용**

아래 작업 흐름은 서로 다른 테마 관련 문제를 해결합니다.

### **외부 테마를 마스터에 종속된 슬라이드에 적용**

PowerPoint 테마 파일(`.thmx`)이 있고 해당 마스터에 종속된 모든 슬라이드의 스타일을 변경하려면 [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ko/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/)를 사용하세요. [Presentation.Masters](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/masters/) 컬렉션에서 마스터를 선택하고(이 컬렉션은 [IMasterSlideCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/imasterslidecollection/)을 구현함) 테마 파일 경로를 메서드에 전달합니다.

메서드는 다음 작업을 수행합니다:

1. 선택한 마스터를 기반으로 새 마스터 슬라이드를 생성합니다.
1. 외부 테마를 새 마스터에 적용합니다.
1. 이전에 선택한 마스터에 종속되었던 모든 슬라이드에 새 마스터를 할당합니다.
1. 새로 생성된 [IMasterSlide](https://reference.aspose.com/slides/ko/net/aspose.slides/imasterslide/)을 반환합니다.

다음 예제는 첫 번째 마스터에 종속된 슬라이드에 외부 테마를 적용하고 프레젠테이션을 저장한 뒤 결과를 다시 엽니다:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var selectedMaster = presentation.Masters[0];
var themedMaster = selectedMaster.ApplyExternalThemeToDependingSlides("corporate-theme.thmx");

Console.WriteLine($"Created master: {themedMaster.Name}");
presentation.Save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
```

잘못되었거나 손상되었거나 지원되지 않는 테마는 [PptxException](https://reference.aspose.com/slides/ko/net/aspose.slides/pptxexception/) 또는 해당 서브클래스를 발생시킬 수 있습니다. 사용자가 제공한 경로를 검증하고 파일 시스템 액세스 실패를 처리하며 테마 적용이 성공적으로 완료된 후에만 프레젠테이션을 저장하세요.

선택한 마스터에 종속된 슬라이드만 다시 할당됩니다. 다른 마스터와 연결된 슬라이드는 기존 마스터와 테마를 유지합니다. 테마 인식 색상, 글꼴, 채우기, 선, 배경 및 효과는 외부 테마에 따라 해석됩니다. 직접 할당된 색상, 글꼴, 채우기 및 기타 명시적 서식은 변경되지 않을 수 있습니다. 레이아웃 수준 및 슬라이드 수준 오버라이드는 새 마스터에서 상속된 값보다 우선할 수 있습니다.

테마는 런타임 환경에 없는 글꼴을 참조할 수 있습니다. 일관된 렌더링 및 내보내기를 위해 필요한 글꼴을 설치하거나 [맞춤 글꼴 소스](/slides/ko/net/custom-font/)를 통해 제공하거나 [글꼴 대체](/slides/ko/net/font-substitution/)를 구성하세요.

이는 직접적인 마스터 수준 작업 흐름입니다. 메서드는 `.thmx` 파일 경로를 받아들이며 슬라이드 수준이나 레이아웃 수준 테마 오버라이드를 수동으로 만들 필요가 없습니다.

### **다중 마스터 프레젠테이션에서 서로 다른 외부 테마 적용**

관련 마스터를 사전에 알 수 없을 때는 [ISlide.LayoutSlide](https://reference.aspose.com/slides/ko/net/aspose.slides/islide/layoutslide/)와 [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/ko/net/aspose.slides/ilayoutslide/masterslide/)를 통해 대표 슬라이드에서 마스터를 얻으세요. 테마를 적용하기 전에 원본 마스터 참조를 저장하세요. 각 호출은 프레젠테이션에 새 마스터를 추가합니다.

다음 예제는 두 섹션의 슬라이드를 사용해 각각의 마스터를 찾고, 각 그룹에 서로 다른 외부 테마를 적용합니다:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("multi-master-presentation.pptx");

if (presentation.Slides.Count < 5)
{
    Console.WriteLine("The presentation does not contain the expected representative slides.");
}
else
{
    var firstGroupMaster = presentation.Slides[0].LayoutSlide.MasterSlide;
    var secondGroupMaster = presentation.Slides[4].LayoutSlide.MasterSlide;

    if (ReferenceEquals(firstGroupMaster, secondGroupMaster))
    {
        Console.WriteLine("The representative slides use the same master.");
    }
    else
    {
        var firstThemedMaster = firstGroupMaster.ApplyExternalThemeToDependingSlides("blue-theme.thmx");
        var secondThemedMaster = secondGroupMaster.ApplyExternalThemeToDependingSlides("green-theme.thmx");

        Console.WriteLine($"First themed master: {firstThemedMaster.Name}");
        Console.WriteLine($"Second themed master: {secondThemedMaster.Name}");
        presentation.Save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
    }
}
```

첫 번째 호출은 `firstGroupMaster`에 종속된 슬라이드에만 영향을 주며, 두 번째 호출은 `secondGroupMaster`에 종속된 슬라이드에만 영향을 줍니다. 다른 마스터에 속한 슬라이드는 스타일이 변경되지 않습니다.

### **슬라이드 이동 시 원본 테마 유지**

슬라이드를 다른 프레젠테이션으로 이동하면서 원래 디자인을 유지하려면 [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/ko/net/aspose.slides/imasterslidecollection/addclone/)으로 원본 마스터를 대상 프레젠테이션에 복제한 뒤, [ISlideCollection.AddClone](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection/addclone/)와 복제된 마스터를 사용해 슬라이드를 복제하세요. 이렇게 하면 마스터와 레이아웃, 연관된 테마가 함께 복사됩니다.

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

대상 프레젠테이션에서 소스 슬라이드가 동일하게 보이도록 해야 할 때 권장되는 작업 흐름입니다. 관련 없는 대상 마스터에만 콘텐츠를 복제하면 테마 기반 색상, 글꼴, 배경 및 효과가 변경될 수 있습니다.

### **기존 슬라이드에 테마 값 적용**

대상 슬라이드가 현재 마스터와 레이아웃을 유지해야 할 경우, 소스 테마에서 슬라이드 수준 오버라이드를 초기화합니다. [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/overridetheme/initfontschemefrom/), [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/overridetheme/initformatschemefrom/) 메서드가 세 가지 주요 테마 구성 요소를 오버라이드에 복사합니다.

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

이렇게 하면 해당 슬라이드에만 적용되는 테마가 변경되고, 다른 슬라이드가 상속받는 테마는 그대로 유지됩니다. 로컬 오버라이드를 제거하고 상속값으로 되돌리려면 [OverrideTheme.Clear](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/overridetheme/clear/)를 호출하세요.

### **레이아웃에 테마 오버라이드 적용**

레이아웃 수준 오버라이드는 해당 레이아웃을 사용하는 슬라이드에 적용되며, 개별 슬라이드에 자체 오버라이드가 있지 않은 경우에만 적용됩니다. 동일한 초기화 메서드는 레이아웃의 [LayoutSlideThemeManager](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/layoutslidethememanager/)를 통해 사용할 수 있습니다.

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

많은 레이아웃과 슬라이드가 동일한 기본 디자인을 공유해야 할 때는 마스터 또는 프레젠테이션 수준 테마를 사용하고, 특정 레이아웃 패밀리만 다른 스타일이 필요할 때는 레이아웃 오버라이드를, 실제 예외가 있을 때만 슬라이드 오버라이드를 사용하세요. 과도한 슬라이드 수준 오버라이드는 이후 전역 테마 변경을 예측하기 어렵게 만들 수 있습니다.

## **테마 배경 스타일 업데이트**

테마의 배경 채우기는 [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/formatscheme/backgroundfillstyles/)에 저장됩니다. PowerPoint UI에서는 실제 컬렉션에 저장된 채우기 정의보다 더 많은 배경 옵션을 표시할 수 있습니다. UI는 테마 채우기와 테마 색상 및 기타 스타일 참조를 조합하기 때문입니다.

![프레젠테이션 테마에 대한 PowerPoint 배경 스타일 갤러리](presentation-design_8.png)

배경 스타일을 사용하기 전에 저장된 컬렉션과 현재 [Background.StyleIndex](https://reference.aspose.com/slides/ko/net/aspose.slides/background/styleindex/)를 검사하세요. `StyleIndex`가 `0`이면 테마 채우기가 없음을 의미하고, 양수 값은 테마 배경‑스타일 참조를 나타냅니다. 이는 .NET 컬렉션을 직접 인덱싱할 때와 달리 `[0]`이 첫 번째 저장 항목을 의미함을 유의하세요. 모든 프레젠테이션에 동일한 배경 채우기 스타일 수가 있다고 가정하지 마세요.

다음 예제는 사용 가능한 배경 채우기 개수를 보고하고, 첫 번째 마스터에 테마 배경 참조를 할당한 뒤 프레젠테이션을 저장합니다:

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

시각적인 결과는 마스터가 참조하는 테마 항목과 레이아웃 또는 슬라이드 수준에서 적용된 배경 오버라이드에 따라 달라집니다. 슬라이드에 자체 배경이 있는 경우 마스터 배경만 변경해도 해당 슬라이드에는 영향을 주지 않을 수 있습니다. 최종 배경을 알고 싶을 때는 상속이 적용된 후의 값을 반환하는 [Background.GetEffective](https://reference.aspose.com/slides/ko/net/aspose.slides/background/geteffective/)를 사용하세요.

{{% alert color="warning" title="Warning" %}}
`StyleIndex`를 0부터 시작하는 컬렉션 인덱스로 오해하지 마세요. 또한 하나의 파일에서 스타일 번호를 하드코딩하고 다른 파일에서도 동일한 모습을 기대하지 마세요. 테마 스타일 정의는 프레젠테이션마다 다릅니다.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
직접적인 배경 서식 및 배경 상속에 대해서는 [Presentation Background](/slides/ko/net/presentation-background/)를 참고하세요.
{{% /alert %}}

## **테마 효과 업데이트**

테마 포맷 스킴에는 별도의 [FillStyles](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/formatscheme/linestyles/), 그리고 [EffectStyles](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/formatscheme/effectstyles/) 컬렉션이 포함됩니다. 일반적인 Office 테마에는 미묘, 보통, 강렬 형식에 시각적으로 대응되는 세 개의 주요 스타일 항목이 포함되는 경우가 많지만, 코드는 고정된 개수를 가정하지 말고 각 컬렉션을 검사해야 합니다.

![같은 도형에 적용된 미묘, 보통, 강렬 테마 효과](presentation-design_10.png)

C#에서 이러한 컬렉션에 접근하면 컬렉션 인덱스는 0부터 시작합니다: `[0]`이 첫 번째 저장 스타일이고 `[2]`가 세 번째 스타일입니다. 도형의 스타일‑참조 인덱스는 별개의 개념이며, [IShapeStyle](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapestyle/)를 통해 노출됩니다. 테마 스타일을 수정하면 해당 테마 스타일을 참조하는 도형에 영향을 주며, 직접 서식이 적용된 도형은 변하지 않을 수 있습니다.

다음 예제는 필요한 스타일 항목이 존재하는지 확인하고, 첫 번째 선 스타일을 변경하고, 세 번째 채우기 스타일을 변경하며, 세 번째 효과 스타일에 외부 그림자를 적용하고 결과를 저장합니다:

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

해당 슬롯을 참조하는 도형에 대해 첫 번째 테마 선 스타일은 빨간색이 되고, 세 번째 테마 채우기 스타일은 단단한 포레스트 그린이 되며, 세 번째 효과 스타일은 거리 10포인트의 외부 그림자를 얻게 됩니다. 정확한 시각적 결과는 각 도형이 어떤 스타일 슬롯을 참조하고 직접 서식이 테마를 오버라이드하는지에 따라 달라집니다.

![선, 채우기 및 그림자 설정을 변경한 후의 테마 효과 스타일](presentation-design_11.png)

## **유효 단색 채우기가 테마 색상을 사용하는지 판단**

채우기는 객체에 직접 저장되거나 단락, 레이아웃, 마스터, 테마 스타일 또는 다른 서식 수준에서 상속될 수 있습니다. [IFillFormat.GetEffective](https://reference.aspose.com/slides/ko/net/aspose.slides/ifillformat/geteffective/)를 호출해 계층 구조를 불변의 [IFillFormatEffectiveData](https://reference.aspose.com/slides/ko/net/aspose.slides/ifillformateffectivedata/)로 해결하세요. 먼저 [IFillFormatEffectiveData.FillType](https://reference.aspose.com/slides/ko/net/aspose.slides/ifillformateffectivedata/filltype/)을 확인합니다. `FillType.Solid`인 경우에만 단색 채우기 속성을 읽어야 합니다.

단색 채우기의 경우 [IFillFormatEffectiveData.SolidFillColor](https://reference.aspose.com/slides/ko/net/aspose.slides/ifillformateffectivedata/solidfillcolor/)는 상속, 테마 조회 및 색상 변환이 적용된 후 최종 렌더링된 RGB 값을 반환합니다. [IFillFormatEffectiveData.SolidFillSchemeColor](https://reference.aspose.com/slides/ko/net/aspose.slides/ifillformateffectivedata/solidfillschemecolor/)는 `Text1` 또는 `Accent6`과 같은 대응 논리 [SchemeColor](https://reference.aspose.com/slides/ko/net/aspose.slides/schemecolor/) 슬롯을 반환합니다. `SchemeColor.NotDefined` 값은 유효 단색 채우기가 스킴 색상을 기반으로 하지 않음을 의미합니다. 채우기가 테마 색상인지 직접 RGB 색상인지 구분하는 워크플로에서는 이 값이 직접 RGB 채우기를 나타냅니다.

로컬 [IColorFormat.SchemeColor](https://reference.aspose.com/slides/ko/net/aspose.slides/icolorformat/schemecolor/) 값만으로 채우기를 분류하지 마세요. 예를 들어 텍스트 일부는 로컬에 스킴 색상이 정의되지 않아 `NotDefined`일 수 있지만, 유효 채우기는 테마 색상을 상속받아 `Text1` 또는 `Accent6`으로 해결될 수 있습니다. 반대로 `SolidFillSchemeColor`는 어떤 논리 테마 슬롯이 유효 색상을 생성했는지 알려 주지만, 해당 슬롯이 객체, 단락, 레이아웃, 마스터 또는 다른 서식 수준에서 왔는지는 알려 주지 않습니다.

다음 예제는 프레젠테이션을 로드하고, 도형 채우기와 텍스트 부분 채우기를 모두 감사하여 각 최종 RGB 값과 연결된 스킴 색상을 출력하고, 테마 색상 변경을 추적하지 않을 단색 채우기를 표시합니다:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

var slideCount = presentation.Slides.Count;
for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];

    var shapeCount = slide.Shapes.Count;
    for (var shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        var shapeName = $"Slide {slideIndex + 1}, shape {shapeIndex + 1}";
        AuditFill(shapeName, shape.FillFormat);

        if (shape is IAutoShape autoShape)
        {
            var paragraphCount = autoShape.TextFrame.Paragraphs.Count;
            for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
            {
                var paragraph = autoShape.TextFrame.Paragraphs[paragraphIndex];

                var portionCount = paragraph.Portions.Count;
                for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
                {
                    var portion = paragraph.Portions[portionIndex];
                    var portionName = $"{shapeName}, paragraph {paragraphIndex + 1}, portion {portionIndex + 1}";
                    AuditFill(portionName, portion.PortionFormat.FillFormat);
                }
            }
        }
    }
}

static void AuditFill(string objectName, IFillFormat localFill)
{
    var effectiveFill = localFill.GetEffective();

    if (effectiveFill.FillType != FillType.Solid)
    {
        Console.WriteLine($"{objectName}: fill type = {effectiveFill.FillType}; not a solid fill.");
        return;
    }

    var rgb = effectiveFill.SolidFillColor;
    var effectiveSchemeColor = effectiveFill.SolidFillSchemeColor;
    var localSchemeColor = localFill.SolidFillColor.SchemeColor;

    Console.WriteLine($"{objectName}: RGB = #{rgb.R:X2}{rgb.G:X2}{rgb.B:X2}");
    Console.WriteLine($"{objectName}: local scheme = {localSchemeColor}, effective scheme = {effectiveSchemeColor}");

    if (effectiveSchemeColor == SchemeColor.NotDefined)
    {
        Console.WriteLine($"{objectName}: direct RGB or another non-scheme fill; audit as theme-independent.");
    }
    else
    {
        Console.WriteLine($"{objectName}: theme-dependent through {effectiveSchemeColor}.");
    }
}
```

`NotDefined` 분기는 테마 색상 슬롯 변경에 반응하지 않는 단색 채우기의 감사 목록을 제공합니다. 새로운 브랜드 팔레트를 적용해야 할 때 이러한 객체를 검토하세요. 보고된 RGB 값은 현재 모습을 보여 주고, 스킴 값은 해당 모습이 테마와 연결되어 있는지 여부를 설명합니다.

유효 형식 객체는 스냅샷입니다. 프레젠테이션 테마, 테마 오버라이드 또는 상속된 서식을 변경한 후에는 `GetEffective`를 다시 호출하고 새로운 `IFillFormatEffectiveData` 객체를 읽어 색상을 비교하거나 보고하세요.

## **유효 테마 값 읽기**

원시 테마 객체는 특정 수준에서 정의된 내용을 알려 주지만, 유효 값은 상속 및 로컬 오버라이드가 적용된 후 슬라이드나 도형이 실제로 사용하는 값을 알려 줍니다. 슬라이드의 경우 [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/)를 호출합니다. 배경은 [Background.GetEffective](https://reference.aspose.com/slides/ko/net/aspose.slides/background/geteffective/)를, 채우기는 [FillFormat.GetEffective](https://reference.aspose.com/slides/ko/net/aspose.slides/fillformat/geteffective/)를 사용하세요.

다음 예제는 슬라이드에서 유효 테마, 배경 및 첫 번째 도형 채우기를 읽습니다:

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

렌더링 진단, 검증 및 비교를 위해 유효 데이터를 사용하세요. [Presentation.MasterTheme](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/mastertheme/)만 검사하면 마스터, 레이아웃, 슬라이드 또는 도형 오버라이드로 인해 최종 모습이 변경된 경우를 놓칠 수 있습니다.

## **FAQ**

**외부 테마를 적용하면 프레젠테이션의 모든 슬라이드가 영향을 받나요?**

아니요. [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ko/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/)는 선택한 마스터에 종속된 슬라이드만 재할당합니다. 다른 마스터를 사용하는 슬라이드는 기존 테마를 유지합니다.

**마스터를 변경하지 않고 단일 슬라이드에 테마를 적용할 수 있나요?**

예. 슬라이드의 [SlideThemeManager](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/slidethememanager/)를 사용하고 오버라이드 테마를 초기화하세요. 변경은 해당 슬라이드에만 적용되며, 다른 슬라이드는 기존 테마를 계속 상속합니다.

**한 프레젠테이션에서 다른 프레젠테이션으로 테마를 전달하는 가장 안전한 방법은?**

슬라이드를 이동하면서 원본 모습을 보존하려면 소스 마스터를 대상에 복제하고, 해당 마스터와 함께 슬라이드를 [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/ko/net/aspose.slides/imasterslidecollection/addclone/)와 [ISlideCollection.AddClone](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection/addclone/)로 복제하세요. 이렇게 하면 마스터, 레이아웃 및 테마가 함께 유지됩니다.

**상속 및 오버라이드 후의 유효 값을 어떻게 확인할 수 있나요?**

슬라이드 또는 레이아웃 테마에 대해 [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/)를 사용하고, [Background.GetEffective](https://reference.aspose.com/slides/ko/net/aspose.slides/background/geteffective/) 및 [FillFormat.GetEffective](https://reference.aspose.com/slides/ko/net/aspose.slides/fillformat/geteffective/)와 같은 형식 객체의 유효 데이터 메서드를 사용하세요. 이러한 API는 상속 및 오버라이드가 적용된 후 해결된 값을 반환합니다.