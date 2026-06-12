---
title: Ekspor File Media ke File HTML
type: docs
weight: 40
url: /id/net/export-media-files-to-html-file/
---
Untuk mengekspor file media ke HTML, ikuti langkah‑langkah berikut:

- Buat sebuah instance dari kelas Presentation
- Dapatkan referensi slide
- Atur efek transisi
- Tuliskan presentasi sebagai file PPTX

Pada contoh di bawah ini, kami telah mengekspor file media ke HTML.
## **Example**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName =  "video.html";

//Memuat presentasi

using (Presentation pres = new Presentation(srcFileName))

{

    const string baseUri = "http://www.example.com/";

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: FilePath, fileName: destFileName, baseUri: baseUri);

    //Mengatur opsi HTML

    HtmlOptions htmlOptions = new HtmlOptions(controller);

    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    //Menyimpan file

    pres.Save(destFileName, SaveFormat.Html, htmlOptions);

}

``` 
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Download Running Example**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Export%20media%20files%20into%20html)

{{% alert color="primary" %}} 

Untuk detail lebih lanjut, kunjungi [Mengekspor file media ke file html](/slides/id/net/cloning-commenting-and-manipulating-slides/#extracting-video-from-a-slide).

{{% /alert %}}