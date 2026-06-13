---
title: 모든 슬라이드의 제목 가져오기
type: docs
weight: 120
url: /ko/net/get-the-titles-of-all-the-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get the titles of all the slides.pptx";

foreach (string s in GetSlideTitles(FileName))

Console.WriteLine(s);

Console.ReadKey();

// 프레젠테이션에서 모든 슬라이드의 제목 목록을 가져옵니다.

public static IList<string> GetSlideTitles(string presentationFile)

{

    // 프레젠테이션을 읽기 전용으로 엽니다.

    using (PresentationDocument presentationDocument =

        PresentationDocument.Open(presentationFile, false))

    {

        return GetSlideTitles(presentationDocument);

    }

}

// 프레젠테이션에서 모든 슬라이드의 제목 목록을 가져옵니다.

public static IList<string> GetSlideTitles(PresentationDocument presentationDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // PresentationDocument 객체에서 PresentationPart 객체를 가져옵니다.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    if (presentationPart != null &&

        presentationPart.Presentation != null)

    {

        // PresentationPart 객체에서 Presentation 객체를 가져옵니다.

        Presentation presentation = presentationPart.Presentation;

        if (presentation.SlideIdList != null)

        {

            List<string> titlesList = new List<string>();

            // 슬라이드 순서대로 각 슬라이드의 제목을 가져옵니다.

            foreach (var slideId in presentation.SlideIdList.Elements<SlideId>())

            {

                SlidePart slidePart = presentationPart.GetPartById(slideId.RelationshipId) as SlidePart;

                // 슬라이드 제목을 가져옵니다.

                string title = GetSlideTitle(slidePart);

                // 빈 제목도 추가될 수 있습니다.

                titlesList.Add(title);

            }

            return titlesList;

        }

    }

    return null;

}

// 슬라이드의 제목 문자열을 반환합니다.

public static string GetSlideTitle(SlidePart slidePart)

{

    if (slidePart == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // 문단 구분자를 선언합니다.

    string paragraphSeparator = null;

    if (slidePart.Slide != null)

    {

        // 모든 제목 모양을 찾습니다.

        var shapes = from shape in slidePart.Slide.Descendants<Shape>()

                     where IsTitleShape(shape)

                     select shape;

        StringBuilder paragraphText = new StringBuilder();

        foreach (var shape in shapes)

        {

            // 이 모양의 각 문단에서 텍스트를 가져옵니다.

            foreach (var paragraph in shape.TextBody.Descendants<D.Paragraph>())

            {

                // 줄 바꿈을 추가합니다.

                paragraphText.Append(paragraphSeparator);

                foreach (var text in paragraph.Descendants<D.Text>())

                {

                    paragraphText.Append(text.Text);

                }

                paragraphSeparator = "\n";

            }

        }

        return paragraphText.ToString();

    }

    return string.Empty;

}

// 모양이 제목 모양인지 판단합니다.

private static bool IsTitleShape(Shape shape)

{

    var placeholderShape = shape.NonVisualShapeProperties.ApplicationNonVisualDrawingProperties.GetFirstChild<PlaceholderShape>();

    if (placeholderShape != null && placeholderShape.Type != null && placeholderShape.Type.HasValue)

    {

        switch ((PlaceholderValues)placeholderShape.Type)

        {

            // 어떤 제목 모양이든.

            case PlaceholderValues.Title:

            // 가운데 정렬된 제목.

            case PlaceholderValues.CenteredTitle:

                return true;

            default:

                return false;

        }

    }

    return false;

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

        // 그리고 슬라이드 수를 반환합니다.

        return CountSlides(presentationDocument);

    }

}

// 프레젠테이션의 슬라이드 수를 셉니다.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // null 문서 개체를 확인합니다.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // 문서의 프레젠테이션 파트를 가져옵니다.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // SlideParts에서 슬라이드 수를 가져옵니다.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // 슬라이드 수를 이전 메서드에 반환합니다.

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

        // StringBuilder 객체를 만듭니다.

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
## **샘플 코드 다운로드**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20the%20titles%20of%20all%20the%20slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20the%20titles%20of%20all%20the%20slides/)