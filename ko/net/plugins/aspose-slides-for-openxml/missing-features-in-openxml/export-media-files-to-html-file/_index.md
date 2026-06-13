---
title: HTML 파일로 미디어 파일 내보내기
type: docs
weight: 40
url: /ko/net/export-media-files-to-html-file/
---
미디어 파일을 HTML로 내보내려면 아래 단계를 따라 주세요:

- Presentation 클래스의 인스턴스를 생성합니다.
- 슬라이드에 대한 참조를 가져옵니다.
- 전환 효과를 설정합니다.
- 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 미디어 파일을 HTML로 내보냈습니다.
## **예제**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName =  "video.html";

//프레젠테이션 로드 중

using (Presentation pres = new Presentation(srcFileName))

{

    const string baseUri = "http://www.example.com/";

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: FilePath, fileName: destFileName, baseUri: baseUri);

    //HTML 옵션 설정

    HtmlOptions htmlOptions = new HtmlOptions(controller);

    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    //파일 저장 중

    pres.Save(destFileName, SaveFormat.Html, htmlOptions);

}
``` 
## **샘플 코드 다운로드**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **실행 예제 다운로드**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Export%20media%20files%20into%20html)

{{% alert color="primary" %}} 
자세한 내용은 [HTML 파일로 미디어 파일 내보내기](/slides/ko/net/cloning-commenting-and-manipulating-slides/#extracting-video-from-a-slide)를 방문하세요.
{{% /alert %}}