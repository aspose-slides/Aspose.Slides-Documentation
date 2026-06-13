---
title: HTML 파일로 미디어 파일 내보내기
type: docs
weight: 80
url: /ko/net/export-media-files-into-html-file/
---
HTML로 미디어 파일을 내보내려면 아래 단계를 따르세요:

- Presentation 클래스의 인스턴스를 생성합니다
- 슬라이드의 참조를 가져옵니다
- 전환 효과를 설정합니다
- 프레젠테이션을 PPTX 파일로 저장합니다

아래 예시에서는 미디어 파일을 HTML로 내보냈습니다.
## **예제**
``` 

 //프레젠테이션 로드

using (Presentation pres = new Presentation("example.pptx"))

{

   const string path = "path";

   const string fileName = "video.html";

   const string baseUri = "http://www.example.com/";

   VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: path, fileName: fileName, baseUri: baseUri);

   //HTML 옵션 설정

   HtmlOptions htmlOptions = new HtmlOptions(controller);

   SVGOptions svgOptions = new SVGOptions(controller);

   htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

   htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

   //파일 저장

   pres.Save(path + fileName, SaveFormat.Html, htmlOptions);

}

``` 
## **실행 예제 다운로드**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Export%20media%20files%20into%20html)
## **샘플 코드 다운로드**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)