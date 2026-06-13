---
title: HTML फ़ाइल में मीडिया फ़ाइलें निर्यात करें
type: docs
weight: 40
url: /hi/net/export-media-files-to-html-file/
---
HTML में मीडिया फ़ाइलों को निर्यात करने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

- Presentation क्लास का एक इंस्टेंस बनाएं
- स्लाइड का रेफ़रेंस प्राप्त करें
- ट्रांज़िशन इफ़ेक्ट सेट करें
- प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें

नीचे दिए गए उदाहरण में, हमने मीडिया फ़ाइलों को HTML में निर्यात कर दिया है।
## **उदाहरण**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName =  "video.html";

//प्रस्तुति लोड करना

using (Presentation pres = new Presentation(srcFileName))

{

    const string baseUri = "http://www.example.com/";

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: FilePath, fileName: destFileName, baseUri: baseUri);

    //HTML विकल्प सेट करना

    HtmlOptions htmlOptions = new HtmlOptions(controller);

    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    //फ़ाइल सहेजना

    pres.Save(destFileName, SaveFormat.Html, htmlOptions);

}
``` 
## **नमूना कोड डाउनलोड करें**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **चल रहा उदाहरण डाउनलोड करें**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Export%20media%20files%20into%20html)

{{% alert color="primary" %}} 
अधिक विवरण के लिए, देखें [HTML फ़ाइल में मीडिया फ़ाइलें निर्यात करना](/slides/hi/net/cloning-commenting-and-manipulating-slides/#extracting-video-from-a-slide).
{{% /alert %}}