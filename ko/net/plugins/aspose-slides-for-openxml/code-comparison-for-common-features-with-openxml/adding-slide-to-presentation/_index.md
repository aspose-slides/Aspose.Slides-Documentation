---
title: 프레젠테이션에 슬라이드 추가
type: docs
weight: 20
url: /ko/net/adding-slide-to-presentation/
---
## **OpenXML Presentation**
아래 기능에서는 기본적으로 슬라이드가 프레젠테이션에 추가됩니다. 여기서는 인덱스 2에 텍스트가 포함된 새 슬라이드를 추가합니다.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Adding Slide to Presentation.pptx";

InsertNewSlide(FileName, 1, "My new slide");

// 지정된 프레젠테이션에 슬라이드를 삽입합니다.

public static void InsertNewSlide(string presentationFile, int position, string slideTitle)

{

    // 소스 문서를 읽기/쓰기 모드로 엽니다. 

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // 삽입할 슬라이드의 소스 문서와 위치 및 제목을 다음 메서드에 전달합니다.

        InsertNewSlide(presentationDocument, position, slideTitle);

    }

}

// 지정된 위치에 지정된 슬라이드를 프레젠테이션에 삽입합니다.

public static void InsertNewSlide(PresentationDocument presentationDocument, int position, string slideTitle)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    if (slideTitle == null)

    {

        throw new ArgumentNullException("slideTitle");

    }

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // 프레젠테이션이 비어 있지 않은지 확인합니다.

    if (presentationPart == null)

    {

        throw new InvalidOperationException("The presentation document is empty.");

    }

    // 새로운 슬라이드를 선언하고 인스턴스를 생성합니다.

    Slide slide = new Slide(new CommonSlideData(new ShapeTree()));

    uint drawingObjectId = 1;

    // 슬라이드 내용을 구성합니다.            

    // 새로운 슬라이드의 비시각적 속성을 지정합니다.

    NonVisualGroupShapeProperties nonVisualProperties = slide.CommonSlideData.ShapeTree.AppendChild(new NonVisualGroupShapeProperties());

    nonVisualProperties.NonVisualDrawingProperties = new NonVisualDrawingProperties() { Id = 1, Name = "" };

    nonVisualProperties.NonVisualGroupShapeDrawingProperties = new NonVisualGroupShapeDrawingProperties();

    nonVisualProperties.ApplicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

    // 새로운 슬라이드의 그룹 형태 속성을 지정합니다.

    slide.CommonSlideData.ShapeTree.AppendChild(new GroupShapeProperties());

    // 새로운 슬라이드의 제목 형태를 선언하고 인스턴스를 생성합니다.

    Shape titleShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // 제목 형태에 필요한 속성을 지정합니다. 

    titleShape.NonVisualShapeProperties = new NonVisualShapeProperties

        (new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Title" },

        new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

        new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Type = PlaceholderValues.Title }));

    titleShape.ShapeProperties = new ShapeProperties();

    // 제목 형태의 텍스트를 지정합니다.

    titleShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph(new Drawing.Run(new Drawing.Text() { Text = slideTitle })));

    // 새로운 슬라이드의 본문 형태를 선언하고 인스턴스를 생성합니다.

    Shape bodyShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // 본문 형태에 필요한 속성을 지정합니다.

    bodyShape.NonVisualShapeProperties = new NonVisualShapeProperties(new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Content Placeholder" },

            new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

            new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Index = 1 }));

    bodyShape.ShapeProperties = new ShapeProperties();

    // 본문 형태의 텍스트를 지정합니다.

    bodyShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph());

    // 새로운 슬라이드에 대한 슬라이드 파트를 생성합니다.

    SlidePart slidePart = presentationPart.AddNewPart<SlidePart>();

    // 새로운 슬라이드 파트를 저장합니다.

    slide.Save(slidePart);

    // 프레젠테이션 파트의 슬라이드 ID 목록을 수정합니다.

    // 슬라이드 ID 목록은 null이면 안 됩니다.

    SlideIdList slideIdList = presentationPart.Presentation.SlideIdList;

    // 현재 목록에서 가장 높은 슬라이드 ID를 찾습니다.

    uint maxSlideId = 1;

    SlideId prevSlideId = null;

    foreach (SlideId slideId in slideIdList.ChildElements)

    {

        if (slideId.Id > maxSlideId)

        {

            maxSlideId = slideId.Id;

        }

        position--;

        if (position == 0)

        {

            prevSlideId = slideId;

        }

    }

    maxSlideId++;

    // 이전 슬라이드의 ID를 가져옵니다.

    SlidePart lastSlidePart;

    if (prevSlideId != null)

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(prevSlideId.RelationshipId);

    }

    else

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(((SlideId)(slideIdList.ChildElements[0])).RelationshipId);

    }

    // 이전 슬라이드와 동일한 슬라이드 레이아웃을 사용합니다.

    if (null != lastSlidePart.SlideLayoutPart)

    {

        slidePart.AddPart(lastSlidePart.SlideLayoutPart);

    }

    // 이전 슬라이드 뒤에 새로운 슬라이드를 슬라이드 리스트에 삽입합니다.

    SlideId newSlideId = slideIdList.InsertAfter(new SlideId(), prevSlideId);

    newSlideId.Id = maxSlideId;

    newSlideId.RelationshipId = presentationPart.GetIdOfPart(slidePart);

    // 수정된 프레젠테이션을 저장합니다.

    presentationPart.Presentation.Save();

}

}
``` 
## **Aspose.Slides**
각 PowerPoint 프레젠테이션 파일에는 하나의 **Main Master slide**와 다른 **Normal slides**가 포함됩니다. 이는 프레젠테이션 파일에 하나 이상의 슬라이드가 포함된다는 의미입니다. 슬라이드가 없는 프레젠테이션 파일은 Aspose.Slides for .NET에서 지원되지 않음을 알아두세요. 각 슬라이드는 고유한 위치와 **unique Id**를 가집니다. **slide Id**는 마스터 슬라이드의 경우 0에서 255까지, 일반 슬라이드의 경우 256에서 65535까지 범위가 가능합니다.

Aspose.Slides for .NET은 개발자가 **Presentation** 객체가 제공하는 **AddEmptySlide** 메서드를 사용하여 프레젠테이션에 빈 슬라이드를 추가할 수 있도록 합니다. 프레젠테이션에 빈 슬라이드를 추가하려면 다음 단계에 따라 주세요:

- Presentation 클래스의 인스턴스를 생성합니다
- Presentation 객체가 제공하는 AddEmptySlide 메서드를 호출합니다
- 새로 추가된 빈 슬라이드로 작업을 수행합니다
- 다른 슬라이드를 추가하고 텍스트를 삽입합니다
- 마지막으로 Presentation 객체가 제공하는 Write 메서드를 사용하여 PPT 파일을 저장합니다

``` csharp

 string FileName = FilePath + "Adding Slide to Presentation.pptx";

//PPT 파일을 나타내는 PresentationEx 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
//프레젠테이션을 기본 생성자로 만들면 기본적으로 빈 슬라이드가 추가됩니다
//기본 생성자를 사용한 프레젠테이션
//프레젠테이션에 빈 슬라이드를 추가하고 해당 빈 슬라이드의 참조를 가져옵니다
//그 빈 슬라이드
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
//출력을 디스크에 기록합니다
pres.Save(FileName,Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/)