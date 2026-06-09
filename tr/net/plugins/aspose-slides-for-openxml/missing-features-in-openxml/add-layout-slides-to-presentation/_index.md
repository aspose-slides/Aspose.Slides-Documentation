---
title: Sunuma Düzen Slaytları Ekle
type: docs
weight: 20
url: /tr/net/add-layout-slides-to-presentation/
---
Aspose.Slides for .NET, geliştiricilerin sunumda yeni Düzen slaytları eklemesine olanak tanır. Bir Düzen Slaytı eklemek için, lütfen aşağıdaki adımları izleyin:

- Presentation sınıfının bir örneğini oluşturun
- Master Slayt koleksiyonuna erişin
- Mevcut Düzen slaytlarını bulmaya çalışın ve gerekli slaytın Düzen Slayt koleksiyonunda zaten mevcut olup olmadığını kontrol edin
- İstenen düzen mevcut değilse yeni bir Düzen slaytı ekleyin
- Yeni eklenen Düzen slaytı ile boş bir slayt ekleyin
- Son olarak, Presentation nesnesini kullanarak sunum dosyasını yazın

## **Örnek**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Adding Layout Slides.pptx";

//Sunum dosyasını temsil eden Presentation sınıfını örnekle
using (Presentation p = new Presentation(FileName))
{
    //Düzen slaytı türüne göre aramayı dene
    IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide =
        layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??
        layoutSlides.GetByType(SlideLayoutType.Title);
    if (layoutSlide == null)
    {
        //Sunumun bazı düzen türlerini içermediği durum.
        //Technographics.pptx sunumu sadece Boş ve Özel düzen türlerini içerir.
        //Ancak Özel türlerdeki düzen slaytlarının farklı slayt adları vardır,
        //"Title", "Title and Content" gibi. Ve bu adları düzen slaytı seçimi için kullanmak mümkündür.
        //Ayrıca yer tutucu şekil türlerinin kümesini kullanmak da mümkündür. Örneğin,
        //Başlık slaytı sadece Başlık yer tutucu türüne sahip olmalıdır, vb.
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
    //Eklenen düzen slaytı ile boş bir slayt ekleme
    p.Slides.InsertEmptySlide(0, layoutSlide);
    //Sunumu kaydet    
    p.Save(FileName, SaveFormat.Pptx);
}
``` 
## **Örnek Kodu İndir**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Çalışan Örneği İndir**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Adding%20Layout%20Slides)

{{% alert color="primary" %}} 

Daha fazla detay için, [Uygulama veya Slayt Düzenlerini Değiştirme .NET'te](/slides/tr/net/slide-layout/).

{{% /alert %}}