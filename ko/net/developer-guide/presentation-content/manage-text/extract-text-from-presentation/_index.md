---
title: .NET에서 프레젠테이션에 대한 고급 텍스트 추출
linktitle: 텍스트 추출
type: docs
weight: 90
url: /ko/net/extract-text-from-presentation/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/overview/
  - /net/slides-on-cloud-platforms/extracting-text/slides/ko/
keywords:
- 텍스트 추출
- 슬라이드에서 텍스트 추출
- 프레젠테이션에서 텍스트 추출
- PowerPoint에서 텍스트 추출
- OpenDocument에서 텍스트 추출
- PPT에서 텍스트 추출
- PPTX에서 텍스트 추출
- ODP에서 텍스트 추출
- 텍스트 가져오기
- 슬라이드에서 텍스트 가져오기
- 프레젠테이션에서 텍스트 가져오기
- PowerPoint에서 텍스트 가져오기
- OpenDocument에서 텍스트 가져오기
- PPT에서 텍스트 가져오기
- PPTX에서 텍스트 가져오기
- ODP에서 텍스트 가져오기
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트를 빠르게 추출하세요. 시간을 절약할 수 있는 간단하고 단계별 가이드를 따라 보세요."
---
## **개요**

프레젠테이션에서 텍스트를 추출하는 것은 슬라이드 콘텐츠를 다루는 개발자에게 흔하면서도 필수적인 작업입니다. Microsoft PowerPoint 파일(PPT 또는 PPTX 형식)이나 OpenDocument 프레젠테이션(ODP)을 다루든, 텍스트 데이터를 접근하고 추출하는 것은 분석, 자동화, 인덱싱 또는 콘텐츠 마이그레이션 등에 매우 중요할 수 있습니다.

본 문서는 Aspose.Slides for .NET을 사용하여 PPT, PPTX 및 ODP 등 다양한 프레젠테이션 형식에서 텍스트를 효율적으로 추출하는 방법에 대한 포괄적인 가이드를 제공합니다. 프레젠테이션 요소를 체계적으로 순회하여 필요한 텍스트 콘텐츠를 정확히 가져오는 방법을 배울 수 있습니다.

## **슬라이드에서 텍스트 추출**

Aspose.Slides for .NET은 [Aspose.Slides.Util](https://reference.aspose.com/slides/ko/net/aspose.slides.util/) 네임스페이스를 제공하며, 여기에는 [SlideUtil](https://reference.aspose.com/slides/ko/net/aspose.slides.util/slideutil/) 클래스가 포함됩니다. 이 클래스는 프레젠테이션 또는 슬라이드에서 모든 텍스트를 추출하기 위한 여러 오버로드된 정적 메서드를 제공합니다. 프레젠테이션의 슬라이드에서 텍스트를 추출하려면 [GetAllTextBoxes](https://reference.aspose.com/slides/ko/net/aspose.slides.util/slideutil/getalltextboxes/) 메서드를 사용합니다. 이 메서드는 [IBaseSlide](https://reference.aspose.com/slides/ko/net/aspose.slides/ibaseslide/) 유형의 객체를 매개변수로 받습니다. 실행 시 메서드는 슬라이드 전체를 스캔하여 텍스트를 찾고, 텍스트 형식을 보존한 채 [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/) 유형 객체 배열을 반환합니다.

다음 코드 조각은 프레젠테이션 첫 번째 슬라이드의 모든 텍스트를 추출합니다:

```cs
int slideIndex = 0;

using var presentation = new Presentation("demo.pptx");

var slide = presentation.Slides[slideIndex];

var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **프레젠테이션에서 텍스트 추출**

전체 프레젠테이션에서 텍스트를 스캔하려면 [SlideUtil](https://reference.aspose.com/slides/ko/net/aspose.slides.util/slideutil/) 클래스가 제공하는 [GetAllTextFrames](https://reference.aspose.com/slides/ko/net/aspose.slides.util/slideutil/getalltextframes/) 정적 메서드를 사용합니다. 이 메서드는 두 개의 매개변수를 받습니다.

1. 첫 번째는 텍스트를 추출할 PowerPoint 또는 OpenDocument 프레젠테이션을 나타내는 [IPresentation](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentation/) 객체입니다.  
2. 두 번째는 프레젠테이션에서 텍스트를 스캔할 때 마스터 슬라이드를 포함할지 여부를 나타내는 `Boolean` 값입니다.

이 메서드는 텍스트 형식 정보를 포함한 [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/) 유형 객체 배열을 반환합니다. 아래 코드는 마스터 슬라이드를 포함하여 프레젠테이션의 텍스트와 형식 세부 정보를 스캔합니다.

```cs
using var presentation = new Presentation("demo.pptx");

var includeMasterSlides = true;
var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, includeMasterSlides);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **구분된 빠른 텍스트 추출**

[PresentationFactory](https://reference.aspose.com/slides/ko/net/aspose.slides/presentationfactory/) 클래스 역시 프레젠테이션에서 모든 텍스트를 추출하는 메서드를 제공합니다:

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/ko/net/aspose.slides/textextractionarrangingmode/) 열거형 인자는 텍스트 추출 결과를 정리하는 방식을 나타내며 다음 값으로 설정할 수 있습니다.
- `Unarranged` - 슬라이드상의 위치와 무관한 원시 텍스트.
- `Arranged` - 슬라이드에 표시된 순서대로 정렬된 텍스트.

속도가 중요한 경우 정리되지 않은 모드(`Unarranged`)를 사용할 수 있으며, 정리된 모드(`Arranged`)보다 빠릅니다.

[IPresentationText](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentationtext/) 은 프레젠테이션에서 추출된 원시 텍스트를 나타냅니다. 이 인터페이스의 `SlidesText` 속성은 [ISlideText](https://reference.aspose.com/slides/ko/net/aspose.slides/islidetext/) 유형 객체 배열을 반환합니다. 각 객체는 해당 슬라이드에 포함된 텍스트를 나타냅니다. [ISlideText](https://reference.aspose.com/slides/ko/net/aspose.slides/islidetext/) 유형 객체는 다음과 같은 속성을 가집니다.

- `Text` - 슬라이드 내 도형에 포함된 텍스트.
- `MasterText` - 해당 슬라이드와 연결된 마스터 슬라이드 도형에 포함된 텍스트.
- `LayoutText` - 해당 슬라이드와 연결된 레이아웃 슬라이드 도형에 포함된 텍스트.
- `NotesText` - 해당 슬라이드의 노트 슬라이드 도형에 포함된 텍스트.
- `CommentsText` - 해당 슬라이드에 연결된 댓글에 포함된 텍스트.

```cs
var presentationPath = "presentation.ppt";
var arrangingMode = TextExtractionArrangingMode.Unarranged;
var presentationText = PresentationFactory.Instance.GetPresentationText(presentationPath, arrangingMode);
var firstSlideText = presentationText.SlidesText[0];

Console.WriteLine(firstSlideText.Text);
Console.WriteLine(firstSlideText.LayoutText);
Console.WriteLine(firstSlideText.MasterText);
Console.WriteLine(firstSlideText.NotesText);
Console.WriteLine(firstSlideText.CommentsText);
```

## **FAQ**

**Aspose.Slides가 대용량 프레젠테이션을 텍스트 추출할 때 얼마나 빠른가요?**

Aspose.Slides는 고성능을 위해 최적화되어 있어 [대용량 프레젠테이션](/slides/ko/net/open-presentation/)도 실시간 또는 대량 처리 시나리오에 적합하게 처리할 수 있습니다.

**Aspose.Slides가 프레젠테이션 내 테이블 및 차트에서 텍스트를 추출할 수 있나요?**

예. Aspose.Slides는 테이블 및 차트 관련 객체를 포함한 다양한 슬라이드 요소에서 텍스트를 추출할 수 있으므로 일반적인 프레젠테이션 구조에서 텍스트 콘텐츠를 접근하고 분석할 수 있습니다.

**프레젠테이션에서 텍스트를 추출하려면 특별한 Aspose.Slides 라이선스가 필요한가요?**

무료 체험판으로도 텍스트를 추출할 수 있지만, [특정 제한](/slides/ko/net/licensing/)이 있어 슬라이드 수가 제한됩니다. 제한 없이 사용하고 더 큰 프레젠테이션을 처리하려면 정식 라이선스를 구매하는 것이 권장됩니다.