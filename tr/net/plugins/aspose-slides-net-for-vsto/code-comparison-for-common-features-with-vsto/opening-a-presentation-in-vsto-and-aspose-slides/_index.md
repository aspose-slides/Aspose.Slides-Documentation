---
title: VSTO ve Aspose.Slides ile Sunum Açma
type: docs
weight: 120
url: /tr/net/opening-a-presentation-in-vsto-and-aspose-slides/
---
## **VSTO**
Aşağıda sunumu açmak için kod parçacığı bulunmaktadır:

``` csharp

  string FileName = "Open Presentation.pptx";

 Application.Presentations.Open(FileName);


``` 
## **Aspose.Slides**
Aspose.Slides for .NET, mevcut bir sunumu açmak için kullanılan **Presentation** sınıfını sağlar. Birkaç aşırı yüklenmiş yapıcıya sahiptir ve mevcut bir sunuma dayalı olarak **Presentation** sınıfının uygun bir yapıcısını kullanarak nesnesini oluşturabiliriz. Aşağıdaki örnekte, sunum dosyasının (açılacak) adını Presentation sınıfının yapıcısına geçirdik. Dosya açıldıktan sonra, ekranda yazdırmak için sunumdaki toplam slayt sayısını alırız.

``` csharp

  string FileName = "Open Presentation.pptx";

 Presentation MyPresentation = new Presentation(FileName);

``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Opening%20a%20Presentation)