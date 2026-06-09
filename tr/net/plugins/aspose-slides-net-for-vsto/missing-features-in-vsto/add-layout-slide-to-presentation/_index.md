---
title: Sunuma Layout Slaytı Ekle
type: docs
weight: 10
url: /tr/net/add-layout-slide-to-presentation/
---
Aspose.Slides for .NET, geliştiricilerin sunumda yeni Layout slaytları eklemesine olanak tanır. Bir Layout Slaytı eklemek için, lütfen aşağıdaki adımları izleyin:

- Presentation sınıfının bir örneğini oluşturun
- Master Slide koleksiyonuna erişin
- Mevcut Layout slaytlarını bulmaya çalışın ve gerekli slaytın Layout Slide koleksiyonunda zaten mevcut olup olmadığını kontrol edin
- İstenen düzen mevcut değilse yeni bir Layout slaytı ekleyin
- Yeni eklenen Layout slaytı ile boş bir slayt ekleyin
- Son olarak, Presentation nesnesini kullanarak sunum dosyasını yazın.
## **Örnek**
``` csharp

 //Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur

using (Presentation p = new Presentation("Test.pptx"))
{
   //Düzen slayt tipine göre aramayı deneyin
   IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;
   ILayoutSlide layoutSlide =
   layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??
   layoutSlides.GetByType(SlideLayoutType.Title);
   if (layoutSlide == null)
   {
     //Bir sunumun bazı düzen tiplerini içermediği durum.
     //Technographics.pptx sunumu yalnızca Boş ve Özel düzen tiplerini içerir.
     //Ancak Özel tipteki düzen slaytlarının farklı slayt adları vardır,
     //"Title", "Title and Content" gibi ve bu adları düzen slaytı seçimi için kullanmak mümkündür.
     //Ayrıca yer tutucu şekil tiplerinin setini kullanmak da mümkündür. Örneğin,
     //Başlık slaytı yalnızca Başlık yer tutucu tipine sahip olmalıdır, vb.
     foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)
     {
       if (titleAndObjectLayoutSlide.Name == "Title and Object")
       {
          layoutSlide = titleAndObjectLayoutSlide;
          break;
       }
      }
      if (layoutSlide == null)
      {
         foreach (ILayoutSlide titleLayoutSlide in layoutSlides)
         {
            if (titleLayoutSlide.Name == "Title")
            {
                layoutSlide = titleLayoutSlide;
                break;
            }
          }
          if (layoutSlide == null)
          {
             layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);
             if (layoutSlide == null)
             {
                  layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");
             }
          }
      }
  }
  //Eklenen düzen slaytı ile boş slayt ekleme
  p.Slides.InsertEmptySlide(0, layoutSlide);
  //Sunumu kaydet
  p.Save("Output.pptx", SaveFormat.Pptx);
}
``` 
## **Çalışan Örneği İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Adding%20Layout%20Slides)
## **Örnek Kodu İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Daha fazla ayrıntı için, [Slide Düzenlerini .NET'te Uygulama veya Değiştirme](/slides/tr/net/slide-layout/) adresini ziyaret edin.

{{% /alert %}}