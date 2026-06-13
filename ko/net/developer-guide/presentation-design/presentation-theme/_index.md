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
description: "Aspose.Slides for .NET에서 마스터 프레젠테이션 테마를 사용하여 PowerPoint 파일을 일관된 브랜딩으로 생성, 사용자 정의 및 변환합니다."
---
## **소개**

프레젠테이션 테마는 디자인 요소의 속성을 정의합니다. 프레젠테이션 테마를 선택하면 기본적으로 특정 시각 요소와 해당 속성 집합을 선택하는 것입니다.

PowerPoint에서는 테마가 색상, [fonts](/slides/ko/net/powerpoint-fonts/), [background styles](/slides/ko/net/presentation-background/), 및 효과로 구성됩니다.

![테마 구성 요소](theme-constituents.png)

## **테마 색상 변경**

PowerPoint 테마는 슬라이드의 다양한 요소에 대해 특정 색상 집합을 사용합니다. 색상이 마음에 들지 않으면 테마에 새 색상을 적용하여 색상을 변경합니다. 새 테마 색상을 선택할 수 있도록 Aspose.Slides는 [SchemeColor](https://reference.aspose.com/slides/ko/net/aspose.slides/schemecolor/) 열거형에 값을 제공합니다.

이 C# 코드는 테마의 강조 색상을 변경하는 방법을 보여줍니다:

```c#
using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

다음과 같이 결과 색상의 실제 값을 확인할 수 있습니다:

```c#
var fillEffective = shape.FillFormat.GetEffective();

Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (색상 [A=255, R=128, G=100, B=162])
```

색상 변경 작업을 더 자세히 보여주기 위해 다른 요소를 만들고 초기 작업에서 얻은 강조 색상을 할당합니다. 그런 다음 테마에서 색상을 다시 변경합니다:

```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```

새 색상이 두 요소에 자동으로 적용됩니다.

### **추가 팔레트에서 테마 색상 설정**

주 테마 색상(1)에 휘도 변환을 적용하면 추가 팔레트(2) 색상이 형성됩니다. 그런 다음 해당 테마 색상을 설정하고 가져올 수 있습니다.

![추가 팔레트 색상](additional-palette-colors.png)

**1** - 주 테마 색상  
**2** - 추가 팔레트의 색상.

이 C# 코드는 메인 테마 색상에서 추가 팔레트 색상을 가져와 도형에 사용하는 작업을 보여줍니다:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 강조 색상 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // 강조 색상 4, 밝게 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // 강조 색상 4, 밝게 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // 강조 색상 4, 밝게 40%
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // 강조 색상 4, 어둡게 25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // 강조 색상 4, 어둡게 50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```

### **`SchemeColor`를 `IColorScheme` 색상에 매핑**

[SchemeColor](https://reference.aspose.com/slides/ko/net/aspose.slides/schemecolor/)를 사용할 때 다음과 같은 테마 색상 값을 포함하고 있음을 알 수 있습니다:

`Background1`, `Background2`, `Text1`, `Text2`.

하지만 `Presentation.MasterTheme.ColorScheme`은 [IColorScheme](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/icolorscheme/)을 반환하며, 해당 색상은 다음과 같이 노출됩니다:

`Dark1`, `Dark2`, `Light1`, `Light2`.

이 차이는 명명 방식만 다를 뿐입니다. 이 값들은 동일한 테마 색상 슬롯을 가리키며 매핑은 고정되어 있습니다:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background`와 `Dark`/`Light` 사이에 동적 변환은 없습니다. 동일한 테마 색상의 대체 이름일 뿐입니다.

이 명명 차이는 Microsoft Office 용어에서 비롯되었습니다. 오래된 Office 버전에서는 `Dark 1`, `Light 1`, `Dark 2`, `Light 2`를 사용했으며, 최신 UI 버전에서는 동일한 슬롯을 `Text 1`, `Background 1`, `Text 2`, `Background 2`로 표시합니다.

## **테마 글꼴 변경**

테마 및 기타 용도로 글꼴을 선택할 수 있도록 Aspose.Slides는 PowerPoint와 유사한 다음 특수 식별자를 사용합니다:

* **+mn-lt** - 본문 글꼴 라틴어 (Minor Latin Font)
* **+mj-lt** - 제목 글꼴 라틴어 (Major Latin Font)
* **+mn-ea** - 본문 글꼴 동아시아 (Minor East Asian Font)
* **+mj-ea** - 본문 글꼴 동아시아 (Minor East Asian Font)

이 C# 코드는 라틴어 글꼴을 테마 요소에 할당하는 방법을 보여줍니다:

```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```

이 C# 코드는 프레젠테이션 테마 글꼴을 변경하는 방법을 보여줍니다:

```c#
pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
```

모든 텍스트 상자의 글꼴이 업데이트됩니다.

{{% alert color="primary" title="팁" %}} 
PowerPoint 글꼴을 확인하고 싶다면 [PowerPoint fonts](/slides/ko/net/powerpoint-fonts/)를 보세요. 
{{% /alert %}}

## **테마 배경 스타일 변경**

기본적으로 PowerPoint 앱은 12개의 사전 정의 배경을 제공하지만, 일반적인 프레젠테이션에서는 그 중 3개만 저장됩니다.

![todo:image_alt_text](presentation-design_8.png)

예를 들어 PowerPoint 앱에서 프레젠테이션을 저장한 후 다음 C# 코드를 실행하면 프레젠테이션에 포함된 사전 정의 배경 수를 확인할 수 있습니다:

```c#
using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 
[BackgroundFillStyles](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) 속성을 [FormatScheme](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/formatscheme/) 클래스에서 사용하면 PowerPoint 테마의 배경 스타일을 추가하거나 액세스할 수 있습니다. 
{{% /alert %}}

이 C# 코드는 프레젠테이션의 배경을 설정하는 방법을 보여줍니다:

```c#
pres.Masters[0].Background.StyleIndex = 2;
```

**인덱스 안내**: 0은 채우기 없음에 사용됩니다. 인덱스는 1부터 시작합니다.

{{% alert color="primary" title="팁" %}} 
PowerPoint 배경을 확인하고 싶다면 [PowerPoint Background](/slides/ko/net/presentation-background/)를 보세요. 
{{% /alert %}}

## **테마 효과 변경**

PowerPoint 테마는 일반적으로 각 스타일 배열에 대해 3개의 값을 포함합니다. 이러한 배열은 미묘함, 중간, 강렬이라는 3가지 효과로 결합됩니다. 예를 들어 특정 도형에 효과를 적용한 결과는 다음과 같습니다:

![todo:image_alt_text](presentation-design_10.png)

[FillStyles](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/formatscheme/effectstyles)이라는 3가지 속성을 [FormatScheme](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/formatscheme) 클래스에서 사용하면 PowerPoint 옵션보다 더 유연하게 테마 요소를 변경할 수 있습니다.

이 C# 코드는 요소의 일부를 변형하여 테마 효과를 변경하는 방법을 보여줍니다:

```c#
using (Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx"))
{
    pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

    pres.MasterTheme.FormatScheme.FillStyles[2].FillType = FillType.Solid;

    pres.MasterTheme.FormatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;

    pres.MasterTheme.FormatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

    pres.Save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
}
```

채우기 색, 채우기 유형, 그림자 효과 등에서 발생하는 변경 결과:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**테마를 마스터에 적용하지 않고 단일 슬라이드에만 적용할 수 있나요?**  
예. Aspose.Slides는 슬라이드 수준 테마 재정의를 지원하므로 [SlideThemeManager](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/slidethememanager/)를 통해 마스터 테마를 그대로 유지하면서 해당 슬라이드에만 로컬 테마를 적용할 수 있습니다.

**한 프레젠테이션에서 다른 프레젠테이션으로 테마를 전달하는 가장 안전한 방법은 무엇인가요?**  
[Clone slides](/slides/ko/net/clone-slides/)를 마스터와 함께 대상 프레젠테이션으로 복사하면 원본 마스터, 레이아웃 및 연관된 테마가 보존되어 외관이 일관됩니다.

**모든 상속 및 재정의 후 “실제(effective)” 값을 어떻게 확인할 수 있나요?**  
API의 ["effective" views](/slides/ko/net/shape-effective-properties/)를 사용하여 테마/색상/글꼴/효과의 최종 해결된 속성을 확인할 수 있습니다.