---
title: 슬라이드의 모든 텍스트 가져오기
type: docs
weight: 110
url: /ko/net/get-all-the-text-in-a-slide/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// 슬라이드의 모든 텍스트 가져오기.

public static string[] GetAllTextInSlide(string presentationFile, int slideIndex)

{

    // 프레젠테이션을 읽기 전용으로 엽니다.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // 프레젠테이션과 슬라이드 인덱스를 전달합니다
        // 다음 GetAllTextInSlide 메서드에 전달하고,
        // 그리고 반환된 문자열 배열을 반환합니다. 
        return GetAllTextInSlide(presentationDocument, slideIndex);

    }

}

public static string[] GetAllTextInSlide(PresentationDocument presentationDocument, int slideIndex)

{

    // 프레젠테이션 문서가 존재하는지 확인합니다.
    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // 슬라이드 인덱스가 범위를 벗어나지 않았는지 확인합니다.
    if (slideIndex < 0)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // 프레젠테이션 문서의 프레젠테이션 부분을 가져옵니다.
    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // 프레젠테이션 부분과 프레젠테이션이 존재하는지 확인합니다.
    if (presentationPart != null && presentationPart.Presentation != null)

    {

        // 프레젠테이션 부분에서 Presentation 객체를 가져옵니다.
        Presentation presentation = presentationPart.Presentation;

        // 슬라이드 ID 목록이 존재하는지 확인합니다.
        if (presentation.SlideIdList != null)

        {

            // 슬라이드 ID 목록에서 슬라이드 ID 컬렉션을 가져옵니다.
            DocumentFormat.OpenXml.OpenXmlElementList slideIds =

                presentation.SlideIdList.ChildElements;

            // 슬라이드 ID가 범위 내에 있는 경우...
            if (slideIndex < slideIds.Count)

            {

                // 슬라이드의 관계 ID를 가져옵니다.
                string slidePartRelationshipId = (slideIds[slideIndex] as SlideId).RelationshipId;

                // 관계 ID에서 지정된 슬라이드 파트를 가져옵니다.
                SlidePart slidePart =

                    (SlidePart)presentationPart.GetPartById(slidePartRelationshipId);

                // 슬라이드 파트를 다음 메서드에 전달하고,
                // 그 메서드가 반환하는 문자열 배열을 반환하고
                // 이전 메서드로 반환합니다.
                return GetAllTextInSlide(slidePart);

            }

        }

    }

    // 그렇지 않으면 null을 반환합니다.
    return null;

}

public static string[] GetAllTextInSlide(SlidePart slidePart)

{

    // 슬라이드 파트가 존재하는지 확인합니다.
    if (slidePart == null)

    {

        throw new ArgumentNullException("slidePart");

    }

    // 문자열의 새로운 연결 리스트를 생성합니다.
    LinkedList<string> texts = new LinkedList<string>();

    // 슬라이드가 존재하는 경우...
    if (slidePart.Slide != null)

    {

        // 슬라이드의 모든 단락을 순회합니다.
        foreach (DocumentFormat.OpenXml.Drawing.Paragraph paragraph in

            slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Paragraph>())

        {

            // 새로운 문자열 빌더를 생성합니다.                    
            StringBuilder paragraphText = new StringBuilder();

            // 단락의 모든 텍스트를 순회합니다.
            foreach (DocumentFormat.OpenXml.Drawing.Text text in

                paragraph.Descendants<DocumentFormat.OpenXml.Drawing.Text>())

            {

                // 각 줄을 이전 줄에 추가합니다.
                paragraphText.Append(text.Text);

            }

            if (paragraphText.Length > 0)

            {

                // 각 단락을 연결 리스트에 추가합니다.
                texts.AddLast(paragraphText.ToString());

            }

        }

    }

    if (texts.Count > 0)

    {

        // 문자열 배열을 반환합니다.
        return texts.ToArray();

    }

    else

    {

        return null;

    }

}

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// 슬라이드의 모든 텍스트 가져오기.

public static List<string> GetAllTextInSlide(string presentationFile, int slideIndex)

{

// 문자열의 새로운 연결 리스트를 생성합니다.

List<string> texts = new List<string>();

// PPTX를 나타내는 PresentationEx 클래스를 인스턴스화합니다.

using (Presentation pres = new Presentation(presentationFile))

{

    // 슬라이드에 접근합니다.
    ISlide sld = pres.Slides[slideIndex];

    // 자리 표시자를 찾기 위해 도형을 순회합니다.
    foreach (Shape shp in sld.Shapes)

        if (shp.Placeholder != null)

        {

            // 각 자리 표시자의 텍스트를 가져옵니다.
            texts.Add(((AutoShape)shp).TextFrame.Text);

        }

}

// 문자열 배열을 반환합니다.
return texts;

}

``` 
## **샘플 코드 다운로드**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide/)