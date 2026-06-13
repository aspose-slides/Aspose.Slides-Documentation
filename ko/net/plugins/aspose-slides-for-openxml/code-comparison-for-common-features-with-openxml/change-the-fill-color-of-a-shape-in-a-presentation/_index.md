---
title: 프레젠테이션에서 도형의 채우기 색상 변경
type: docs
weight: 40
url: /ko/net/change-the-fill-color-of-a-shape-in-a-presentation/
---
## **OpenXML 프레젠테이션**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

SetPPTShapeColor(FileName);

// 도형의 채우기 색상을 변경합니다.

// 테스트 파일은 첫 슬라이드의 첫 번째 도형이 채워진 도형이어야 합니다.

public static void SetPPTShapeColor(string docName)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, true))

    {

        // 첫 번째 슬라이드의 관계 ID를 가져옵니다.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[0] as SlideId).RelationshipId;

        // 관계 ID로부터 슬라이드 파트를 가져옵니다.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        if (slide != null)

        {

            // 변경할 도형을 포함하는 ShapeTree을 가져옵니다.

            ShapeTree tree = slide.Slide.CommonSlideData.ShapeTree;

            // ShapeTree에서 첫 번째 도형을 가져옵니다.

            Shape shape = tree.GetFirstChild<Shape>();

            if (shape != null)

            {

                // 도형의 스타일을 가져옵니다.

                ShapeStyle style = shape.ShapeStyle;

                // 채우기 참조를 가져옵니다.

                Drawing.FillReference fillRef = style.FillReference;

                // 채우기 색상을 SchemeColor Accent 6으로 설정합니다;

                fillRef.SchemeColor = new Drawing.SchemeColor();

                fillRef.SchemeColor.Val = Drawing.SchemeColorValues.Accent6;

                // 수정된 슬라이드를 저장합니다.

                slide.Slide.Save();

            }

        }

    }

}

``` 
## **Aspose.Slides**
프레젠테이션에서 도형을 채우려면 다음 단계를 따라야 합니다:

- Presentation 클래스의 인스턴스를 생성합니다.
- 인덱스를 사용하여 슬라이드의 참조를 얻습니다.
- 슬라이드에 IShape을 추가합니다.
- 도형의 채우기 유형을 Solid(단색)로 설정합니다.
- 도형의 색상을 설정합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

//PresentationEx 클래스를 인스턴스화하여 PPTX를 나타냅니다

using (Presentation pres = new Presentation())

{

    //첫 번째 슬라이드를 가져옵니다

    ISlide sld = pres.Slides[0];

    //사각형 타입의 자동 도형을 추가합니다

    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    //채우기 유형을 Solid(단색)로 설정합니다

    shp.FillFormat.FillType = FillType.Solid;

    //사각형의 색상을 설정합니다

    shp.FillFormat.SolidFillColor.Color = Color.Yellow;

    //PPTX 파일을 디스크에 저장합니다

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **실행 코드 예제 다운로드**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **샘플 코드**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Fill%20Color%20of%20a%20Shape)