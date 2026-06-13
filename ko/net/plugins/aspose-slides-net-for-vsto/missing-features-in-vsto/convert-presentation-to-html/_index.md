---
title: 프레젠테이션을 HTML로 변환
type: docs
weight: 40
url: /ko/net/convert-presentation-to-html/
---
**HTML**은 데이터 교환을 위해 널리 사용되는 여러 형식 중 하나입니다. **Aspose.Slides for .NET**은 프레젠테이션을 HTML로 변환하는 기능을 제공합니다. 아래는 이를 보여주는 코드 조각입니다.
## **예제**
``` 

 //프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다

Presentation pres = new Presentation("Conversion.ppt");

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//프레젠테이션을 HTML로 저장합니다

pres.Save("Converted.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **실행 예제 다운로드**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20HTML)
## **샘플 코드 다운로드**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

자세한 내용은 [PowerPoint 프레젠테이션을 HTML로 변환](/slides/ko/net/convert-powerpoint-to-html/)을 확인하십시오.

{{% /alert %}}