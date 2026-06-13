---
title: HTML 변환
type: docs
weight: 20
url: /ko/net/conversion-to-html/
---
**HTML**은 데이터 교환을 위해 널리 사용되는 여러 형식 중 하나입니다. **Aspose.Slides for .NET**은 프레젠테이션을 HTML로 변환하는 기능을 제공합니다. 아래는 이를 보여주는 코드 스니펫입니다.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to HTML.html";

//프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다

Presentation pres = new Presentation(srcFileName);

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Saving the presentation to HTML

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **샘플 코드 다운로드**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20HTML%20%28Aspose.Slides%29.zip)