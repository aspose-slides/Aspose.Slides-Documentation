---
title: 프레젠테이션에서 모든 외부 하이퍼링크 가져오기
type: docs
weight: 90
url: /ko/net/get-all-the-external-hyperlinks-in-a-presentation/
---
## **OpenXML 프레젠테이션**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

foreach (string s in GetAllExternalHyperlinksInPresentation(FileName))

Console.WriteLine(s);

// 프레젠테이션 슬라이드에서 모든 외부 하이퍼링크를 반환합니다.

public static IEnumerable<String> GetAllExternalHyperlinksInPresentation(string fileName)

{

// 문자열 리스트를 선언합니다.

List<string> ret = new List<string>();

// 프레젠테이션 파일을 읽기 전용으로 엽니다.

using (PresentationDocument document = PresentationDocument.Open(fileName, false))

{

    // 프레젠테이션 파트의 모든 슬라이드 파트를 순회합니다.

    foreach (SlidePart slidePart in document.PresentationPart.SlideParts)

    {

        IEnumerable<Drawing.HyperlinkType> links = slidePart.Slide.Descendants<Drawing.HyperlinkType>();

        // 슬라이드 파트의 모든 링크를 순회합니다.

        foreach (Drawing.HyperlinkType link in links)

        {

            // 슬라이드 파트의 모든 외부 관계를 순회합니다. 

            foreach (HyperlinkRelationship relation in slidePart.HyperlinkRelationships)

            {

                // 관계 ID가 링크 ID와 일치하면...

                if (relation.Id.Equals(link.Id))

                {

                    // 외부 관계의 URI를 문자열 리스트에 추가합니다.

                    ret.Add(relation.Uri.AbsoluteUri);

                }

            }

        }

    }

}

// 문자열 리스트를 반환합니다.

return ret;

}


```
## **Aspose.Slides**
Aspose.Slides for .NET은 개발자가 프레젠테이션, 슬라이드 및 텍스트 프레임 수준에서 하이퍼링크를 관리할 수 있도록 합니다. **IHyperlinkQueries** 클래스는 프레젠테이션에서 하이퍼링크를 관리하는 데 도움이 됩니다.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

// PPTX 파일을 나타내는 Presentation 객체를 생성합니다

Presentation pres = new Presentation(FileName);

//Get the hyperlinks from presentation

IList<IHyperlinkContainer> links = pres.HyperlinkQueries.GetAnyHyperlinks();

foreach (IHyperlinkContainer link in links)

    Console.WriteLine(link.HyperlinkClick.ExternalUrl);

```
## **실행 코드 예제 다운로드**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **샘플 코드**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Get%20all%20the%20External%20Hyperlinks)