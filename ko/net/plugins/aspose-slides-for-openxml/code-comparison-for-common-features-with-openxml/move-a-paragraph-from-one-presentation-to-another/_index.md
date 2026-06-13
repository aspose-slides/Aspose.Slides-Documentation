---
title: 하나의 프레젠테이션에서 다른 프레젠테이션으로 단락 이동
type: docs
weight: 130
url: /ko/net/move-a-paragraph-from-one-presentation-to-another/
---
## **OpenXML 프레젠테이션**
``` csharp

  string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a Paragraph from One Presentation to Another 1.pptx";

string DestFileName = FilePath + "Move a Paragraph from One Presentation to Another 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

}

// 소스 문서의 TextBody 도형에서 단락 범위를 이동합니다
// 대상 문서의 다른 TextBody 도형으로 이동합니다.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

// 소스 파일을 읽기/쓰기 모드로 엽니다.

using (PresentationDocument sourceDoc = PresentationDocument.Open(sourceFile, true))

{

    // 대상 파일을 읽기/쓰기 모드로 엽니다.

    using (PresentationDocument targetDoc = PresentationDocument.Open(targetFile, true))

    {

        // 소스 프레젠테이션에서 첫 번째 슬라이드를 가져옵니다.

        SlidePart slide1 = GetFirstSlide(sourceDoc);

        // 그 안에서 첫 번째 TextBody 도형을 가져옵니다.

        TextBody textBody1 = slide1.Slide.Descendants<TextBody>().First();

        // TextBody 도형에서 첫 번째 단락을 가져옵니다.

        // 참고: "Drawing"은 DocumentFormat.OpenXml.Drawing 네임스페이스의 별칭입니다

        Drawing.Paragraph p1 = textBody1.Elements<Drawing.Paragraph>().First();

        // 대상 프레젠테이션에서 첫 번째 슬라이드를 가져옵니다.

        SlidePart slide2 = GetFirstSlide(targetDoc);

        // 그 안에서 첫 번째 TextBody 도형을 가져옵니다.

        TextBody textBody2 = slide2.Slide.Descendants<TextBody>().First();

        // 소스 단락을 복제하고 복제된 단락을 대상 TextBody 도형에 삽입합니다.

        // "true"를 전달하면 깊은 복제가 생성되어

        // Paragraph 객체와 그 객체가 직접 또는 간접적으로 참조하는 모든 것을 복사합니다.

        textBody2.Append(p1.CloneNode(true));

        // 소스 파일에서 소스 단락을 제거합니다.

        textBody1.RemoveChild<Drawing.Paragraph>(p1);

        // 제거된 단락을 자리표시자로 교체합니다.

        textBody1.AppendChild<Drawing.Paragraph>(new Drawing.Paragraph());

        // 소스 파일에서 슬라이드를 저장합니다.

        slide1.Slide.Save();

        // 대상 파일에서 슬라이드를 저장합니다.

        slide2.Slide.Save();

    }

}

}

// 첫 번째 슬라이드의 관계 ID를 가져옵니다

public static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// 첫 번째 슬라이드의 관계 ID를 가져옵니다

PresentationPart part = presentationDocument.PresentationPart;

SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

string relId = slideId.RelationshipId;

// 관계 ID를 통해 슬라이드 파트를 가져옵니다.

SlidePart slidePart = (SlidePart)part.GetPartById(relId);

return slidePart;

}


``` 
## **Aspose.Slides**
개발자가 프레젠테이션에서 텍스트를 추출해야 하는 경우는 드물지 않습니다. 이렇게 하려면 프레젠테이션의 모든 슬라이드에 있는 모든 도형에서 텍스트를 추출해야 합니다. 이 문서에서는 Aspose.Slides를 사용하여 Microsoft PowerPoint PPTX 프레젠테이션에서 텍스트를 추출하는 방법을 설명합니다. 하나의 슬라이드이든 전체 프레젠테이션이든 텍스트를 추출할 때 Aspose.Slides는 PresentationScanner 클래스와 해당 클래스가 제공하는 정적 메서드를 사용합니다. 이들은 모두 [Aspose.Slides.Util](https://reference.aspose.com/slides/ko/net/aspose.slides.util/slideutil) 네임스페이스에 포함되어 있습니다.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a Paragraph from One Presentation to Another 1.pptx";

string DestFileName = FilePath + "Move a Paragraph from One Presentation to Another 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

// 소스 문서의 TextBody 도형에서 단락 범위를 이동합니다
// 대상 문서의 다른 TextBody 도형으로 이동합니다.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

    string Text = "";

    //PPTX를 나타내는 Presentation 클래스를 인스턴스화//PPTX를 나타내는 Presentation 클래스를 인스턴스화

    Presentation sourcePres = new Presentation(sourceFile);

    //첫 번째 슬라이드에서 첫 번째 도형에 접근합니다

    IShape shp = sourcePres.Slides[0].Shapes[0];

    if (shp.Placeholder != null)

    {

        //플레이스홀더에서 텍스트를 가져옵니다

        Text = ((IAutoShape)shp).TextFrame.Text;

        ((IAutoShape)shp).TextFrame.Text = "";

    }

    Presentation destPres = new Presentation(targetFile);

    //첫 번째 슬라이드에서 첫 번째 도형에 접근합니다

    IShape destshp = sourcePres.Slides[0].Shapes[0];

    if (destshp.Placeholder != null)

    {

        //플레이스홀더에서 텍스트를 가져옵니다

        ((IAutoShape)destshp).TextFrame.Text += Text;

    }

    sourcePres.Save(sourceFile, Aspose.Slides.Export.SaveFormat.Pptx);

    destPres.Save(targetFile, Aspose.Slides.Export.SaveFormat.Pptx);

}

}   
``` 
## **실행 코드 예제 다운로드**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **샘플 코드**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Move%20a%20Paragraph)