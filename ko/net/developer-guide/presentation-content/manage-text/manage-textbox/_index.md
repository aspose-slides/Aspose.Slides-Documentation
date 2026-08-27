---
title: .NET에서 프레젠테이션의 텍스트 상자 관리
linktitle: 텍스트 상자 관리
type: docs
weight: 20
url: /ko/net/manage-textbox/
keywords:
- 텍스트 상자
- 텍스트 프레임
- 텍스트 추가
- 텍스트 업데이트
- 텍스트 상자 생성
- 텍스트 상자 확인
- 텍스트 열 추가
- 하이퍼링크 추가
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: ".NET용 Aspose.Slides를 사용하면 PowerPoint 및 OpenDocument 파일에서 텍스트 상자를 쉽게 생성, 편집 및 복제할 수 있어 프레젠테이션 자동화가 향상됩니다."
---
## **소개**

슬라이드의 텍스트는 일반적으로 텍스트 상자 또는 도형에 존재합니다. 따라서 슬라이드에 텍스트를 추가하려면 먼저 텍스트 상자를 추가하고 그 안에 텍스트를 넣어야 합니다.

텍스트를 담을 수 있는 도형을 추가할 수 있도록 Aspose.Slides for .NET은 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape) 인터페이스를 제공합니다.

{{% alert title="Note" color="warning" %}} 

Aspose.Slides는 또한 슬라이드에 도형을 추가할 수 있도록 [IShape](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape) 인터페이스를 제공합니다. 그러나 `IShape` 인터페이스를 통해 추가된 모든 도형이 텍스트를 담을 수 있는 것은 아닙니다. [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape) 인터페이스를 통해 추가된 도형은 일반적으로 텍스트를 포함합니다.

따라서 텍스트를 추가하려는 기존 도형을 다룰 때는 해당 도형이 `IAutoShape` 인터페이스를 통해 캐스팅되었는지 확인하고 싶을 수 있습니다. 그래야만 `IAutoShape` 아래의 속성인 [TextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/properties/textframe)을 사용할 수 있습니다. 이 페이지의 [Update Text](https://docs.aspose.com/slides/ko/net/manage-textbox/#update-text) 섹션을 참조하세요.

{{% /alert %}}

## **슬라이드에 텍스트 상자 만들기**

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 첫 번째 슬라이드의 참조를 가져옵니다.  
3. 슬라이드의 지정된 위치에 [ShapeType](https://reference.aspose.com/slides/ko/net/aspose.slides/igeometryshape/properties/shapetype)을 `Rectangle`으로 설정한 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape) 객체를 추가하고 새로 추가된 `IAutoShape` 객체에 대한 참조를 얻습니다.  
4. `IAutoShape` 객체에 텍스트를 포함할 `TextFrame` 속성을 추가합니다. 아래 예제에서는 이 텍스트를 추가했습니다: *Aspose TextBox*  
5. 마지막으로 `Presentation` 객체를 통해 PPTX 파일을 저장합니다.  

위 단계들을 구현한 이 C# 코드는 슬라이드에 텍스트를 추가하는 방법을 보여줍니다:

```c#
using Aspose.Slides;

// PresentationEx 인스턴스 생성
using (Presentation pres = new Presentation())
{

    // 프레젠테이션의 첫 번째 슬라이드 가져오기
    ISlide sld = pres.Slides[0];

    // 유형을 Rectangle로 설정한 AutoShape 추가
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Rectangle에 TextFrame 추가
    ashp.AddTextFrame(" ");

    // 텍스트 프레임에 접근
    ITextFrame txtFrame = ashp.TextFrame;

    // 텍스트 프레임용 Paragraph 객체 생성
    IParagraph para = txtFrame.Paragraphs[0];

    // Paragraph용 Portion 객체 생성
    IPortion portion = para.Portions[0];

    // 텍스트 설정
    portion.Text = "Aspose TextBox";

    // 프레젠테이션을 디스크에 저장
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **텍스트 상자 도형 확인**

Aspose.Slides는 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/) 인터페이스에서 제공하는 [IsTextBox](https://reference.aspose.com/slides/ko/net/aspose.slides/autoshape/istextbox/) 속성을 통해 도형을 검사하고 텍스트 상자를 식별할 수 있게 합니다.

![텍스트 상자와 도형](istextbox.png)

이 C# 코드는 도형이 텍스트 상자로 생성되었는지 확인하는 방법을 보여줍니다:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    Aspose.Slides.LowCode.ForEach.Shape(presentation, (shape, slide, index) =>
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "shape is a text box" : "shape is not a text box");
        }
    });
}
```

`AddAutoShape` 메서드를 사용해 [IShapeCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/) 인터페이스에서 자동 도형을 단순히 추가하면 해당 자동 도형의 `IsTextBox` 속성은 `false`를 반환합니다. 그러나 `AddTextFrame` 메서드나 `Text` 속성을 사용해 자동 도형에 텍스트를 추가하면 `IsTextBox` 속성은 `true`를 반환합니다.

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    // shape1.IsTextBox 은 false
    shape1.AddTextFrame("shape 1");
    // shape1.IsTextBox 은 true

    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
    // shape2.IsTextBox 은 false
    shape2.TextFrame.Text = "shape 2";
    // shape2.IsTextBox 은 true

    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
    // shape3.IsTextBox 은 false
    shape3.AddTextFrame("");
    // shape3.IsTextBox 은 false

    IAutoShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
    // shape4.IsTextBox 은 false
    shape4.TextFrame.Text = "";
    // shape4.IsTextBox 은 false
}
```

## **텍스트 프레임을 소유한 도형 찾기**

일반적인 텍스트 처리 코드에서는 [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/)을 받을 때 이를 포함하고 있는 프레젠테이션 객체를 미리 알지 못할 수 있습니다. 소유자 [IShape](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/) 로 돌아가기 위해 [ITextFrame.ParentShape](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/parentshape/) 속성을 사용합니다.

[IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/) 또는 다른 텍스트를 포함하는 도형에 속한 텍스트 프레임의 경우, [ITextFrame.ParentShape](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/parentshape/)은 설정되어 있고 [ITextFrame.ParentCell](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/parentcell/)은 `null`입니다. 두 속성은 읽기 전용 탐색 속성이므로 읽어도 소유권이 변경되지 않습니다. 도형에 접근하기 전에 반환값이 `null`인지 항상 확인하십시오.

SmartArt 노드와 연결된 도형을 포함하여 도형 및 테이블 셀 소유자를 식별하는 전체 예제는 [Search and Replace Text](/slides/ko/net/search-and-replace-text/)를 참고하십시오.

## **텍스트 상자에 열 추가**

Aspose.Slides는 텍스트 상자에 열을 추가할 수 있도록 [ITextFrameFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframeformat) 인터페이스와 [TextFrameFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/textframeformat) 클래스에서 제공하는 [ColumnCount](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframeformat/properties/columncount) 및 [ColumnSpacing](https://reference.aspose.com/slides/ko/net/aspose.slides/textframeformat/properties/columnspacing) 속성을 제공합니다. 텍스트 상자의 열 수와 열 사이의 포인트 단위 간격을 지정할 수 있습니다.

C# 코드 예제는 위에서 설명한 동작을 보여줍니다:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
	// 프레젠테이션의 첫 번째 슬라이드 가져오기
	ISlide slide = presentation.Slides[0];

	// 유형을 Rectangle로 설정한 AutoShape 추가
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// Rectangle에 TextFrame 추가
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// TextFrame의 텍스트 형식 가져오기
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// TextFrame의 열 수 지정
	format.ColumnCount = 3;

	// 열 사이의 간격 지정
	format.ColumnSpacing = 10;

	// 프레젠테이션 저장
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```

## **텍스트 프레임에 열 추가**

Aspose.Slides for .NET은 [ITextFrameFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframeformat) 인터페이스에서 제공하는 [ColumnCount](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframeformat/properties/columncount) 속성을 통해 텍스트 프레임에 열을 추가할 수 있게 합니다. 이 속성을 사용해 텍스트 프레임의 원하는 열 수를 지정할 수 있습니다.

다음 C# 코드는 텍스트 프레임 안에 열을 추가하는 방법을 보여줍니다:

```c#
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;

string outPptxFileName = "ColumnsTest.pptx";
using (Presentation pres = new Presentation())
{
    IAutoShape shape1 = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.TextFrame.TextFrameFormat;

    format.ColumnCount = 2;
    shape1.TextFrame.Text = "All these columns are forced to stay within a single text container -- " +
                                "you can add or delete text - and the new or remaining text automatically adjusts " +
                                "itself to stay within the container. You cannot have text spill over from one container " +
                                "to other, though -- because PowerPoint's column options for text are limited!";
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(double.IsNaN(((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing));
    }

    format.ColumnSpacing = 20;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(20 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }

    format.ColumnCount = 3;
    format.ColumnSpacing = 15;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(3 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(15 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }
}
```

## **텍스트 업데이트**

Aspose.Slides를 사용하면 텍스트 상자에 포함된 텍스트나 프레젠테이션 전체에 포함된 모든 텍스트를 변경하거나 업데이트할 수 있습니다.

다음 C# 코드는 프레젠테이션의 모든 텍스트를 업데이트하거나 변경하는 작업을 보여줍니다:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) // shape이 텍스트 프레임(IAutoShape)을 지원하는지 확인합니다.
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) // 텍스트 프레임의 단락을 순회합니다.
               {
                   foreach (IPortion portion in paragraph.Portions) // 단락의 각 포션을 순회합니다.
                   {
                       portion.Text = portion.Text.Replace("years", "months"); // 텍스트를 변경합니다.
                       portion.PortionFormat.FontBold = NullableBool.True; // 서식을 변경합니다.
                   }
               }
           }
       }
   }
  
   // 수정된 프레젠테이션을 저장합니다.
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```

## **하이퍼링크가 있는 텍스트 상자 추가**

텍스트 상자 안에 링크를 삽입할 수 있습니다. 텍스트 상자를 클릭하면 사용자가 해당 링크를 열게 됩니다.

1. `Presentation` 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 첫 번째 슬라이드의 참조를 가져옵니다.  
3. 슬라이드의 지정된 위치에 `ShapeType`을 `Rectangle`으로 설정한 `AutoShape` 객체를 추가하고 새로 추가된 AutoShape 객체에 대한 참조를 얻습니다.  
4. `AutoShape` 객체에 기본 텍스트로 *Aspose TextBox*를 포함하는 `TextFrame`을 추가합니다.  
5. `IHyperlinkManager` 클래스를 인스턴스화합니다.  
6. 선택한 `TextFrame` 부분에 연결된 [HyperlinkClick](https://reference.aspose.com/slides/ko/net/aspose.slides/shape/properties/hyperlinkclick) 속성에 `IHyperlinkManager` 객체를 할당합니다.  
7. 마지막으로 `Presentation` 객체를 통해 PPTX 파일을 저장합니다.  

위 단계들을 구현한 이 C# 코드는 슬라이드에 하이퍼링크가 포함된 텍스트 상자를 추가하는 방법을 보여줍니다:

```c#
using Aspose.Slides;

// PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pptxPresentation = new Presentation();

// 프레젠테이션에서 첫 번째 슬라이드를 가져옵니다
ISlide slide = pptxPresentation.Slides[0];

// 유형을 Rectangle로 설정한 AutoShape 객체를 추가합니다
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// 도형을 AutoShape으로 캐스팅합니다
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// AutoShape에 연결된 ITextFrame 속성에 접근합니다
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// 프레임에 텍스트를 추가합니다
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// 포션 텍스트에 하이퍼링크를 설정합니다
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// PPTX 프레젠테이션을 저장합니다
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **FAQ**

**마스터 슬라이드 작업 시 텍스트 상자와 텍스트 자리표시자(Placeholder)의 차이점은 무엇인가요?**

[placeholder](/slides/ko/net/manage-placeholder/)는 [master](https://reference.aspose.com/slides/ko/net/aspose.slides/masterslide/)에서 스타일/위치를 상속받으며 [layouts](https://reference.aspose.com/slides/ko/net/aspose.slides/layoutslide/)에서 재정의될 수 있지만, 일반 텍스트 상자는 특정 슬라이드에 독립적인 객체이므로 레이아웃을 전환해도 변경되지 않습니다.

**차트, 표, SmartArt 내부의 텍스트는 건드리지 않고 프레젠테이션 전체에서 텍스트를 일괄 교체하려면 어떻게 해야 하나요?**

텍스트 프레임이 있는 자동 도형만 반복하도록 제한하고, 포함된 객체([charts](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/ko/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/ko/net/aspose.slides.smartart/smartart/))는 별도의 컬렉션을 순회하거나 해당 객체 유형을 건너뛰어 제외합니다.