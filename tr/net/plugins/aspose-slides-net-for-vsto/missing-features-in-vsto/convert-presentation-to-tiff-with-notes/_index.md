---
title: Sunumu Notlarla Tiff'e Dönüştür
type: docs
weight: 50
url: /tr/net/convert-presentation-to-tiff-with-notes/
---
TIFF, Aspose.Slides for .NET'in notları olan bir sunumu görüntülere dönüştürmek için desteklediği birkaç yaygın kullanılan görüntü formatından biridir. Ayrıca Not Slaytı görünümünde slayt küçük resimleri oluşturabilirsiniz. Aşağıda, Not Slaytı görünümünde bir sunumun TIFF görüntülerini nasıl oluşturacağınızı gösteren iki kod parçacığı bulunuyor.

[Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/methods/save) yöntemi, [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfı tarafından sunulur ve Not Slaytı görünümündeki tüm sunumu TIFF'e dönüştürmek için kullanılabilir. Ayrıca bireysel slaytlar için Not Slaytı görünümünde bir slayt küçük resmi oluşturabilirsiniz.
## **Örnek**

``` 
  //Bir sunum dosyasını temsil eden Presentation nesnesi oluşturun

 Presentation pres = new Presentation("Conversion.pptx");

 //Sunumu TIFF notlarıyla kaydetme

 pres.Save("ConvertedwithNotes.tiff", SaveFormat.TiffNotes);
``` 
## **Çalışan Örneği İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Tiff%20conversion%20with%20note)
## **Örnek Kodu İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Daha fazla ayrıntı için, [PowerPoint Sunumlarını Notlarla .NET'te TIFF'e Dönüştür](/slides/tr/net/convert-powerpoint-to-tiff-with-notes/).

{{% /alert %}}