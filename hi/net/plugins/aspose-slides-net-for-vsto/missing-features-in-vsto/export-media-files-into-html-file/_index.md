---
title: HTML फ़ाइल में मीडिया फ़ाइलें निर्यात करें
type: docs
weight: 80
url: /hi/net/export-media-files-into-html-file/
---
HTML में मीडिया फ़ाइलों को निर्यात करने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

- Presentation वर्ग का एक उदाहरण बनाएं
- स्लाइड का संदर्भ प्राप्त करें
- ट्रांज़िशन इफ़ेक्ट सेट करें
- प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में लिखें

नीचे दिए गए उदाहरण में, हमने मीडिया फ़ाइलों को HTML में निर्यात किया है।
## **उदाहरण**
``` 

 //प्रेजेंटेशन लोड कर रहे हैं

using (Presentation pres = new Presentation("example.pptx"))

{

   const string path = "path";

   const string fileName = "video.html";

   const string baseUri = "http://www.example.com/";

   VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: path, fileName: fileName, baseUri: baseUri);

   //HTML विकल्प सेट करना

   HtmlOptions htmlOptions = new HtmlOptions(controller);

   SVGOptions svgOptions = new SVGOptions(controller);

   htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

   htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

   //फ़ाइल सहेज रहे हैं

   pres.Save(path + fileName, SaveFormat.Html, htmlOptions);

}

``` 
## **चल रहा उदाहरण डाउनलोड करें**
- [गिटहब](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Export%20media%20files%20into%20html)
## **नमूना कोड डाउनलोड करें**
- [गिटहब](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)