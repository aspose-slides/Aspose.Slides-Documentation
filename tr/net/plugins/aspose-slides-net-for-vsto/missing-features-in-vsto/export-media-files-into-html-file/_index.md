---
title: HTML dosyasına medya dosyalarını dışa aktar
type: docs
weight: 80
url: /tr/net/export-media-files-into-html-file/
---
HTML'ye medya dosyalarını dışa aktarmak için aşağıdaki adımları izleyin:

- Presentation sınıfının bir örneğini oluşturun
- Slaytın referansını alın
- Geçiş efektini ayarlayın
- Sunumu PPTX dosyası olarak yazın

Aşağıda verilen örnekte, medya dosyalarını HTML'ye dışa aktardık.
## **Örnek**
``` 

 //Sunumu yüklüyor

using (Presentation pres = new Presentation("example.pptx"))

{

   const string path = "path";

   const string fileName = "video.html";

   const string baseUri = "http://www.example.com/";

   VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: path, fileName: fileName, baseUri: baseUri);

   //HTML seçeneklerini ayarlama

   HtmlOptions htmlOptions = new HtmlOptions(controller);

   SVGOptions svgOptions = new SVGOptions(controller);

   htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

   htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

   //Dosyayı kaydetme

   pres.Save(path + fileName, SaveFormat.Html, htmlOptions);

}

``` 
## **Çalışan Örneği İndir**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Export%20media%20files%20into%20html)
## **Örnek Kodu İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)