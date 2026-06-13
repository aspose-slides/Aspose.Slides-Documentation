---
title: 프레젠테이션에서 찾기 및 바꾸기
type: docs
weight: 20
url: /ko/net/find-and-replace-in-presentation/
---
다음은 따라야 할 단계입니다:

1. 프레젠테이션을 엽니다.
1. 텍스트를 검색합니다.
1. 텍스트를 교체합니다.
1. 프레젠테이션을 작성합니다.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

//프레젠테이션을 엽니다

Presentation pres = new Presentation(FilePath + "Find and Replace.pptx");

//프레젠테이션의 모든 텍스트 상자를 가져옵니다

ITextFrame[] tb = SlideUtil.GetAllTextBoxes(pres.Slides[0]);

for (int i = 0; i < tb.Length; i++)

foreach (Paragraph para in tb[i].Paragraphs)

    foreach (Portion port in para.Portions)

        //교체할 텍스트를 찾습니다

        if (port.Text.Contains(strToFind))

        //기존 텍스트를 새 텍스트로 교체합니다

        {

            string str = port.Text;

            int idx = str.IndexOf(strToFind);

            string strStartText = str.Substring(0, idx);

            string strEndText = str.Substring(idx + strToFind.Length, str.Length - 1 - (idx + strToFind.Length - 1));

            port.Text = strStartText + strToReplaceWith + strEndText;

        }

pres.Save(FilePath + "Find and Replace.pptx",Aspose.Slides.Export.SaveFormat.Pptx);


``` 
## **샘플 코드 다운로드**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Find%20and%20Replace%20%28Aspose.Slides%29.zip)