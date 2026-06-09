---
title: Slayt Geçişleri
type: docs
weight: 80
url: /tr/net/slide-transitions/
---
Daha kolay anlaşılması için, basit slayt geçişlerini yönetmek amacıyla Aspose.Slides for .NET kullanımını gösterdik. Geliştiriciler yalnızca slaytlara farklı slayt geçiş efektleri uygulamakla kalmaz, aynı zamanda bu geçiş efektlerinin davranışını da özelleştirebilir. Basit bir slayt geçiş efekti oluşturmak için aşağıdaki adımları izleyin:

- Presentation sınıfının bir örneğini oluşturun
- Aspose.Slides for .NET tarafından sunulan geçiş efektlerinden birini **TransitionType** enumu aracılığıyla slayta bir Slide Transition Type uygulayın
- Değiştirilmiş sunum dosyasını yazın.
## **Örnek**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Managing Slides Transitions.pptx";

//Bir sunum dosyasını temsil eden Presentation sınıfını örnekleyin

using (Presentation pres = new Presentation(FileName))

{

    //1. slayta daire tipi geçiş uygula

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    //2. slayta tarak tipi geçiş uygula

    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    //3. slayta yakınlaştırma tipi geçiş uygula

    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;

    //Sunumu diske kaydet

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Örnek Kodu İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Çalışan Örneği İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Managing%20Slides%20Transitions)

{{% alert color="primary" %}} 
Daha fazla ayrıntı için, [Slayt Geçişlerini Yönetme](/slides/tr/net/slide-transition/) sayfasını ziyaret edin.
{{% /alert %}}