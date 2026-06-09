---
title: Slaytı SVG Resmi Olarak Oluştur
type: docs
weight: 70
url: /tr/net/create-slide-as-svg-image/
---
Aspose.Slides.Pptx for .NET ile istediğiniz herhangi bir slayttan SVG resmi oluşturmak için, lütfen aşağıdaki adımları izleyin:

- Presentation sınıfının bir örneğini oluşturun.
- İstenen slaytın referansını kimliği veya indeksiyle alın.
- SVG resmini bir bellek akışı içinde alın.
- Bellek akışını dosyaya kaydedin.
## **Örnek**

```

 //Sunum dosyasını temsil eden bir Presentation sınıfı örneği oluştur

using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))

{
   //İkinci slayta eriş
   ISlide sld = pres.Slides[1];
   //Bir bellek akışı nesnesi oluştur
   MemoryStream SvgStream = new MemoryStream();
   //Slaytın SVG resmini oluştur ve bellek akışına kaydet
   sld.WriteAsSvg(SvgStream);
   SvgStream.Position = 0;
   //Bellek akışını dosyaya kaydet
   using (Stream fileStream = System.IO.File.OpenWrite("PresentatoinTemplate.svg"))
   {
     byte[] buffer = new byte[8 * 1024];
     int len;
     while ((len = SvgStream.Read(buffer, 0, buffer.Length)) > 0)
     {
       fileStream.Write(buffer, 0, len);
     }
   }
}
SvgStream.Close();

``` 
## **Çalışan Örneği İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Creating%20Slide%20SVG%20Image)
## **Örnek Kodu İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Daha fazla ayrıntı için, [Sunum Slaytlarını .NET'te SVG Resimleri Olarak Render Et](/slides/tr/net/render-a-slide-as-an-svg-image/).

{{% /alert %}}