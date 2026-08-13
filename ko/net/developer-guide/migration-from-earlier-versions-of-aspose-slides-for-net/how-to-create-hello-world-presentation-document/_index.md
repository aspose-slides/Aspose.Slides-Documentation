---
title: .NET에서 Hello World 프레젠테이션 만들기
linktitle: Hello World 프레젠테이션
type: docs
weight: 10
url: /ko/net/how-to-create-hello-world-presentation-document/
keywords:
- 마이그레이션
- Hello World
- 레거시 코드
- 현대 코드
- 레거시 접근 방식
- 현대 접근 방식
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
- description: "Aspose.Slides와 함께 .NET에서 레거시 및 현대 API를 모두 사용하여 Hello World PowerPoint PPT, PPTX 및 ODP 프레젠테이션을 하나의 간단한 가이드로 만드는 방법."
---
{{% alert color="info" %}} 
새로운 [Aspose.Slides for .NET API](/slides/ko/net/)가 출시되었으며, 이제 이 단일 제품이 처음부터 PowerPoint 문서를 생성하고 기존 문서를 편집하는 기능을 지원합니다.
{{% /alert %}} 
## **레거시 코드 지원**
13.x 이전 Aspose.Slides for .NET 버전으로 개발된 레거시 코드를 사용하려면 코드에 약간의 변경만 하면 이전과 동일하게 작동합니다. 이전 Aspose.Slides for .NET에서 Aspose.Slide 및 Aspose.Slides.Pptx 네임스페이스에 있던 모든 클래스가 이제 단일 Aspose.Slides 네임스페이스로 통합되었습니다. 레거시 Aspose.Slides API를 사용하여 Hello World 프레젠테이션 문서를 생성하는 간단한 코드 스니펫을 아래에서 확인하고, 새로운 통합 API로 마이그레이션하는 단계에 따라 진행하십시오.
## **레거시 Aspose.Slides for .NET 접근 방식**
```c#
using System.Drawing;
using Aspose.Slides;

//Instantiate a Presentation object that represents a PPT file
//=> PPT 파일을 나타내는 Presentation 객체를 인스턴스화합니다
Presentation pres = new Presentation();

//Create a License object
//=> License 객체를 생성합니다
License license = new License();

//Set the license of Aspose.Slides for .NET to avoid the evaluation limitations
//=> 평가 제한을 피하기 위해 Aspose.Slides for .NET 라이선스를 설정합니다
license.SetLicense("Aspose.Slides.lic");

//Adding an empty slide to the presentation and getting the reference of
//=> 프레젠테이션에 빈 슬라이드를 추가하고 해당 슬라이드의 참조를 가져옵니다
//that empty slide
//=> 그 빈 슬라이드
Slide slide = pres.AddEmptySlide();

//Adding a rectangle (X=2400, Y=1800, Width=1000 & Height=500) to the slide
//=> 슬라이드에 사각형을 추가합니다 (X=2400, Y=1800, Width=1000 & Height=500)
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Hiding the lines of rectangle
//=> 사각형의 선을 숨깁니다
rect.LineFormat.ShowLines = false;

//Adding a text frame to the rectangle with "Hello World" as a default text
//=> 사각형에 기본 텍스트 "Hello World"가 포함된 텍스트 프레임을 추가합니다
rect.AddTextFrame("Hello World");

//Removing the first slide of the presentation which is always added by
//=> 프레젠테이션의 첫 번째 슬라이드를 제거합니다. 이 슬라이드는 항상 추가되는
//Aspose.Slides for .NET by default while creating the presentation
//=> Aspose.Slides for .NET이 기본적으로 프레젠테이션을 생성할 때 추가하는 슬라이드입니다
pres.Slides.RemoveAt(0);

//Writing the presentation as a PPT file
//=> 프레젠테이션을 PPT 파일로 저장합니다
pres.Write("C:\\hello.ppt");
```



## **새 Aspose.Slides for .NET 13.x 접근 방식**
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantiate Presentation
//=> Presentation 객체를 인스턴스화합니다
Presentation pres = new Presentation();

// Get the first slide
//=> 첫 번째 슬라이드를 가져옵니다
ISlide sld = (ISlide)pres.Slides[0];

// Add an AutoShape of Rectangle type
//=> Rectangle 유형의 AutoShape을 추가합니다
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Add ITextFrame to the Rectangle
//=> Rectangle에 ITextFrame을 추가합니다
ashp.AddTextFrame("Hello World");

// Change the text color to Black (which is White by default)
 //=> 텍스트 색상을 검정으로 변경합니다 (기본값은 흰색입니다)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Change the line color of the rectangle to White
//=> 사각형의 선 색상을 흰색으로 변경합니다
ashp.ShapeStyle.LineColor.Color = Color.White;

// Remove any fill formatting in the shape
//=> 모양의 모든 채우기 서식을 제거합니다
ashp.FillFormat.FillType = FillType.NoFill;

// Save the presentation to disk
//=> 프레젠테이션을 디스크에 저장합니다
pres.Save("HelloWorld.pptx", SaveFormat.Pptx);
```