---
title: .NET에서 프레젠테이션 고급 텍스트 추출
linktitle: 텍스트 추출
type: docs
weight: 90
url: /ko/net/extract-text-from-presentation/
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
description: "Aspose.Slides for .NET를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트를 빠르게 추출합니다. 시간을 절약할 수 있는 간단하고 단계별 가이드를 따라 보세요."
---
## **개요**

프레젠테이션에서 텍스트를 추출하는 것은 슬라이드 내용을 다루는 개발자에게 흔하면서도 필수적인 작업입니다. Microsoft PowerPoint 파일(PPT 또는 PPTX 형식)이나 OpenDocument 프레젠테이션(ODP)을 다루든, 텍스트 데이터를 접근하고 추출하는 것은 분석, 자동화, 인덱싱 또는 콘텐츠 마이그레이션 등에 매우 중요할 수 있습니다.

이 문서에서는 Aspose.Slides for .NET을 사용하여 PPT, PPTX 및 ODP 등 다양한 프레젠테이션 형식에서 텍스트를 효율적으로 추출하는 방법을 포괄적으로 안내합니다. 프레젠테이션 요소를 체계적으로 순회하여 필요한 텍스트 내용을 정확히 가져오는 방법을 배울 수 있습니다.

## **슬라이드에서 텍스트 추출**

Aspose.Slides for .NET은 [Aspose.Slides.Util](https://reference.aspose.com/slides/ko/net/aspose.slides.util/) 네임스페이스를 제공하며, 여기에는 [SlideUtil](https://reference.aspose.com/slides/ko/net/aspose.slides.util/slideutil/) 클래스가 포함됩니다. 이 클래스는 프레젠테이션 또는 슬라이드 전체의 텍스트를 추출하는 여러 오버로드된 정적 메서드를 제공합니다. 프레젠테이션의 슬라이드에서 텍스트를 추출하려면 [GetAllTextBoxes](https://reference.aspose.com/slides/ko/net/aspose.slides.util/slideutil/getalltextboxes/) 메서드를 사용합니다. 이 메서드는 [IBaseSlide](https://reference.aspose.com/slides/ko/net/aspose.slides/ibaseslide/) 유형의 객체를 매개변수로 받습니다. 실행 시 메서드는 슬라이드 전체를 스캔하여 텍스트를 찾고, 텍스트 서식을 보존한 채 [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/) 유형의 객체 배열을 반환합니다.

다음 코드 스니펫은 프레젠테이션 첫 번째 슬라이드의 모든 텍스트를 추출합니다:

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

전체 프레젠테이션의 텍스트를 스캔하려면 [SlideUtil](https://reference.aspose.com/slides/ko/net/aspose.slides.util/slideutil/) 클래스가 제공하는 [GetAllTextFrames](https://reference.aspose.com/slides/ko/net/aspose.slides.util/slideutil/getalltextframes/) 정적 메서드를 사용합니다. 이 메서드는 두 개의 매개변수를 받습니다.

1. 첫 번째는 텍스트를 추출할 PowerPoint 또는 OpenDocument 프레젠테이션을 나타내는 [IPresentation](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentation/) 객체입니다.  
2. 두 번째는 마스터 슬라이드를 포함하여 텍스트를 스캔할지를 결정하는 `Boolean` 값입니다.

메서드는 텍스트 서식 정보를 포함한 [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/) 객체 배열을 반환합니다. 아래 코드는 프레젠테이션(마스터 슬라이드 포함)에서 텍스트와 서식 세부 정보를 스캔합니다.

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

## **카테고리별 및 빠른 텍스트 추출**

[PresentationFactory](https://reference.aspose.com/slides/ko/net/aspose.slides/presentationfactory/) 클래스 역시 프레젠테이션 전체에서 텍스트를 추출하는 메서드를 제공합니다:

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/ko/net/aspose.slides/textextractionarrangingmode/) 열거형 인자는 텍스트 추출 결과를 정렬하는 방식을 지정하며 다음 값으로 설정할 수 있습니다.
- `Unarranged` - 슬라이드상의 위치와 관계없이 원시 텍스트만 반환합니다.  
- `Arranged` - 슬라이드에 표시된 순서대로 텍스트를 정렬합니다.

속도가 중요한 경우에는 `Unarranged` 모드를 사용할 수 있으며, 이는 `Arranged` 모드보다 빠릅니다.

[IPresentationText](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentationtext/)은 프레젠테이션에서 추출된 원시 텍스트를 나타냅니다. 이 인터페이스의 `SlidesText` 속성은 [ISlideText](https://reference.aspose.com/slides/ko/net/aspose.slides/islidetext/) 유형 객체 배열을 반환합니다. 각 객체는 해당 슬라이드의 텍스트를 나타냅니다. [ISlideText](https://reference.aspose.com/slides/ko/net/aspose.slides/islidetext/) 유형 객체는 다음 속성을 가집니다.

- `Text` - 슬라이드의 도형에 포함된 텍스트.  
- `MasterText` - 해당 슬라이드와 연결된 마스터 슬라이드 도형의 텍스트.  
- `LayoutText` - 해당 슬라이드와 연결된 레이아웃 슬라이드 도형의 텍스트.  
- `NotesText` - 노트 슬라이드 도형에 포함된 텍스트.  
- `CommentsText` - 해당 슬라이드와 연결된 주석에 포함된 텍스트.

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

Aspose.Slides는 고성능을 위해 최적화되어 있어 [대용량 프레젠테이션](/slides/ko/net/open-presentation/)도 실시간 혹은 대량 처리 시나리오에 적합하게 처리할 수 있습니다.

**Aspose.Slides가 프레젠테이션 내 표와 차트에서 텍스트를 추출할 수 있나요?**

네. Aspose.Slides는 표와 차트 관련 개체를 포함한 다양한 슬라이드 요소에서 텍스트를 추출할 수 있으므로 일반적인 프레젠테이션 구조에 있는 텍스트 콘텐츠를 접근하고 분석할 수 있습니다.

**프레젠테이션에서 텍스트를 추출하려면 특별한 Aspose.Slides 라이선스가 필요한가요?**

무료 체험 버전으로도 텍스트를 추출할 수 있지만, [일부 제한](/slides/ko/net/licensing/)이 있어 슬라이드 수가 제한됩니다. 무제한 사용 및 대용량 프레젠테이션 처리를 위해서는 정식 라이선스를 구매하는 것이 권장됩니다.