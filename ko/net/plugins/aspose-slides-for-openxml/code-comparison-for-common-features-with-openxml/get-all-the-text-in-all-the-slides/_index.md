---
title: 모든 슬라이드의 모든 텍스트 가져오기
type: docs
weight: 100
url: /ko/net/get-all-the-text-in-all-the-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("Number of slides = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

GetSlideIdAndText(out slideText, FileName, i);

System.Console.WriteLine("Slide #{0} contains: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    // 프레젠테이션을 읽기 전용으로 엽니다.
    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // 프레젠테이션을 다음 CountSlides 메서드에 전달합니다
        // 그리고 슬라이드 개수를 반환합니다.
        return CountSlides(presentationDocument);

    }

}

// 프레젠테이션의 슬라이드 수를 셉니다.
public static int CountSlides(PresentationDocument presentationDocument)

{

    // 문서 객체가 null인지 확인합니다.
    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // 문서의 프레젠테이션 파트를 가져옵니다.
    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // SlideParts에서 슬라이드 개수를 가져옵니다.
    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // 이전 메서드에 슬라이드 개수를 반환합니다.
    return slidesCount;

}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // 첫 번째 슬라이드의 관계 ID를 가져옵니다.
        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // 관계 ID에서 슬라이드 파트를 가져옵니다.
        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // StringBuilder 객체를 생성합니다.
        StringBuilder paragraphText = new StringBuilder();

        // 슬라이드의 내부 텍스트를 가져옵니다:
        IEnumerable<A.Text> texts = slide.Slide.Descendants<A.Text>();

        foreach (A.Text text in texts)

        {

            paragraphText.Append(text.Text);

        }

        sldText = paragraphText.ToString();

    }

}

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("Number of slides = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

slideText = GetSlideText(FileName, i);

System.Console.WriteLine("Slide #{0} contains: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    // PPTX를 나타내는 PresentationEx 클래스를 인스턴스화합니다
    using (Presentation pres = new Presentation(presentationFile))

    {

        return pres.Slides.Count;

    }

}

public static string GetSlideText(string docName, int index)

{

    string sldText = "";

    // PPTX를 나타내는 PresentationEx 클래스를 인스턴스화합니다
    using (Presentation pres = new Presentation(docName))

    {

        // 슬라이드에 접근합니다
        ISlide sld = pres.Slides[index];

        // 플레이스홀더를 찾기 위해 모양들을 순회합니다
        foreach (Shape shp in sld.Shapes)

            if (shp.Placeholder != null)

            {

                // 각 플레이스홀더의 텍스트를 가져옵니다
                sldText += ((AutoShape)shp).TextFrame.Text;

            }

    }

    return sldText;

}

``` 
## **샘플 코드 다운로드**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides/)