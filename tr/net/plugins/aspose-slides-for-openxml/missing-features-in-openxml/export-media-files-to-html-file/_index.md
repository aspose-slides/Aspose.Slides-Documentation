---
title: Ortam dosyalarını HTML dosyasına dışa aktar
type: docs
weight: 40
url: /tr/net/export-media-files-to-html-file/
---
Ortam dosyalarını HTML'ye aktarmak için aşağıdaki adımları izleyin:

- Presentation sınıfının bir örneğini oluşturun
- Slaytın referansını alın
- Geçiş efektini ayarlayın
- Sunumu PPTX dosyası olarak yazın

Aşağıdaki örnekte, ortam dosyalarını HTML'ye aktardık.
## **Örnek**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName =  "video.html";

//Sunumu yüklüyor

using (Presentation pres = new Presentation(srcFileName))

{

    const string baseUri = "http://www.example.com/";

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: FilePath, fileName: destFileName, baseUri: baseUri);

    //HTML seçeneklerini ayarlama

    HtmlOptions htmlOptions = new HtmlOptions(controller);

    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    //Dosyayı kaydetme

    pres.Save(destFileName, SaveFormat.Html, htmlOptions);

}

``` 
## **Örnek Kodu İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Çalışan Örneği İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Export%20media%20files%20into%20html)

{{% alert color="primary" %}} 
Daha fazla ayrıntı için, [HTML dosyasına ortam dosyalarını aktarma](/slides/tr/net/cloning-commenting-and-manipulating-slides/#extracting-video-from-a-slide) adresini ziyaret edin.
{{% /alert %}}