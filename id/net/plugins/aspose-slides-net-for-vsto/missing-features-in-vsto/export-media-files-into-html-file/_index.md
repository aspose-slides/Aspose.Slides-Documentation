---
title: Ekspor file media ke file HTML
type: docs
weight: 80
url: /id/net/export-media-files-into-html-file/
---
Untuk mengekspor file media ke HTML, ikuti langkah-langkah berikut:

- Buat instance kelas Presentation
- Dapatkan referensi slide
- Atur efek transisi
- Tulis presentasi sebagai file PPTX

Pada contoh di bawah ini, kami telah mengekspor file media ke HTML.
## **Contoh**
``` 

 //Memuat presentasi

using (Presentation pres = new Presentation("example.pptx"))

{

   const string path = "path";

   const string fileName = "video.html";

   const string baseUri = "http://www.example.com/";

   VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: path, fileName: fileName, baseUri: baseUri);

   //Mengatur opsi HTML

   HtmlOptions htmlOptions = new HtmlOptions(controller);

   SVGOptions svgOptions = new SVGOptions(controller);

   htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

   htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

   //Menyimpan file

   pres.Save(path + fileName, SaveFormat.Html, htmlOptions);

}

``` 
## **Unduh Contoh Berjalan**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Export%20media%20files%20into%20html)
## **Unduh Kode Contoh**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)