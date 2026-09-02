---
title: ".NET'te Sunum Slaytlarını Kopyala"
linktitle: "Slaytları Kopyala"
type: docs
weight: 40
url: /tr/net/clone-slides/
keywords:
- "slaytı klonla"
- "slaytı kopyala"
- "slaytı kaydet"
- "PowerPoint"
- "OpenDocument"
- "sunum"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET ile PowerPoint slaytlarını hızlı bir şekilde çoğaltın. Açık kod örneklerimizi izleyerek saniyeler içinde PPT oluşturmayı otomatikleştirin ve manuel işleri ortadan kaldırın."
---
## **Giriş**

Klonlama, bir şeyin tam bir kopyasını veya replikasını oluşturma sürecidir. Aspose.Slides ayrıca herhangi bir slaytı kopyalamanıza (klonlamanıza) ve ardından klonlanan slaytı mevcut sunuma veya başka bir açık sunuma eklemenize olanak tanır. Slayt klonlama, geliştiricilerin orijinal slaytı etkilemeden değiştirebileceği yeni bir slayt oluşturur. Bir slaytı klonlamanın birkaç yolu vardır:

- Sunumun sonunda klonla.
- Sunum içinde başka bir konumda klonla.
- Başka bir sunumun sonunda klonla.
- Başka bir sunumda başka bir konumda klonla.
- Ana slaytıyla birlikte başka bir sunuma klonla.

Aspose.Slides for .NET'te, [Presentation] nesnesi tarafından sunulan slayt koleksiyonu (bir [ISlide] nesnesi koleksiyonu), yukarıda açıklanan slayt klonlama işlemlerini gerçekleştirmek için [AddClone] ve [InsertClone] metodlarını sağlar.

## **Bir Sunumun Sonunda Slaytı Klonla**

Aynı sunum dosyasında mevcut slaytların sonunda bir slaytı klonlamak ve ardından kullanmak istiyorsanız, aşağıdaki adımlara göre [AddClone] metodunu kullanın:

1. Bir [Presentation] sınıfının örneğini oluşturun.  
1. **Slides** koleksiyonuna başvurarak [ISlideCollection] sınıfını örnekleyin.  
1. [ISlideCollection] nesnesi tarafından sunulan [AddClone] metodunu çağırın ve klonlanacak slaytı [AddClone] metoduna parametre olarak geçin.  
1. Değiştirilmiş sunum dosyasını kaydedin.

Aşağıdaki örnekte, sunumun ilk konumundaki (sıfır indeksi) bir slaytı sunumun sonuna klonladık.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Sunum dosyasını temsil eden Presentation sınıfını örnekle
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // İstenen slaytı aynı sunumdaki slayt koleksiyonunun sonuna klonla
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // Değiştirilmiş sunumu diske kaydet
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```

## **Bir Sunum İçinde Başka Bir Konuma Slaytı Klonla**

Aynı sunum dosyasında farklı bir konuma bir slaytı klonlamak ve ardından kullanmak istiyorsanız, [InsertClone] metodunu kullanın:

1. Bir [Presentation] sınıfının örneğini oluşturun.  
1. **Slides** koleksiyonuna başvurarak sınıfı örnekleyin.  
1. [ISlideCollection] nesnesi tarafından sunulan [InsertClone] metodunu çağırın ve klonlanacak slaytı yeni konum indeksini de parametre olarak geçin.  
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki örnekte, sunumun 1. indeksindeki (2. konum) bir slaytı 2. indeks (3. konum) konumuna klonladık.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Sunum dosyasını temsil eden Presentation sınıfını örnekle
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // İstenen slaytı aynı sunumdaki slayt koleksiyonunun sonuna klonla
    ISlideCollection slds = pres.Slides;

    // İstenen slaytı aynı sunumdaki belirtilen indeks konumuna klonla
    slds.InsertClone(2, pres.Slides[1]);

    // Değiştirilmiş sunumu diske kaydet
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```

## **Başka Bir Sunumun Sonunda Slaytı Klonla**

Bir slaytı bir sunumdan alıp başka bir sunumda mevcut slaytların sonunda kullanmanız gerektiğinde:

1. Kaynak slaytın bulunduğu [Presentation] sınıfının örneğini oluşturun.  
1. Hedef sunumun bulunduğu [Presentation] sınıfının örneğini oluşturun.  
1. Hedef sunumun [Presentation] nesnesi tarafından sunulan **Slides** koleksiyonuna başvurarak [ISlideCollection] sınıfını örnekleyin.  
1. [ISlideCollection] nesnesi tarafından sunulan [AddClone] metodunu çağırın ve kaynak sunumdan alınan slaytı parametre olarak geçin.  
1. Değiştirilmiş hedef sunum dosyasını kaydedin.

Aşağıdaki örnekte, kaynak sunumun ilk indeksindeki bir slaytı hedef sunumun sonuna klonladık.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekle
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Hedef PPTX (slaytın klonlanacağı yer) için Presentation sınıfını örnekle
    using (Presentation destPres = new Presentation())
    {
        // İstenen slaytı kaynak sunumdan alıp hedef sunumdaki slayt koleksiyonunun sonuna klonla
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // Hedef sunumu diske kaydet
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Başka Bir Sunumda Başka Bir Konuma Slaytı Klonla**

Bir slaytı bir sunumdan alıp başka bir sunumda belirli bir konuma kullanmanız gerektiğinde:

1. Kaynak sunumu içeren [Presentation] sınıfının örneğini oluşturun.  
1. Hedef sunumu içeren [Presentation] sınıfının örneğini oluşturun.  
1. Hedef sunumun [Presentation] nesnesi tarafından sunulan **Slides** koleksiyonuna başvurarak [ISlideCollection] sınıfını örnekleyin.  
1. [ISlideCollection] nesnesi tarafından sunulan [InsertClone] metodunu çağırın ve kaynak sunumdan alınan slaytı istenen konumla birlikte parametre olarak geçin.  
1. Değiştirilmiş hedef sunum dosyasını kaydedin.

Aşağıdaki örnekte, kaynak sunumun sıfır indeksindeki bir slaytı hedef sunumun 1. indeksi (2. konum) konumuna klonladık.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekle
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Hedef PPTX (slaytın klonlanacağı yer) için Presentation sınıfını örnekle
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // Hedef sunumu diske kaydet
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Bir Slaytı Ana Slaytıyla Birlikte Başka Bir Sunuma Klonla**

Bir slaytı ve onun ana slaytını bir sunumdan alıp başka bir sunuma kullanmanız gerektiğinde, önce istenen ana slaytı kaynak sunumdan hedef sunuma klonlamanız gerekir. Ardından o ana slaytı kullanarak slaytı klonlamalısınız. **AddClone(ISlide, IMasterSlide)** hedef sunumdan bir ana slayt bekler, kaynak sunumdan değil. Slaytı ana slaytıyla birlikte klonlamak için aşağıdaki adımları izleyin:

1. Kaynak sunumu içeren [Presentation] sınıfının örneğini oluşturun.  
1. Hedef sunumu içeren [Presentation] sınıfının örneğini oluşturun.  
1. Klonlanacak slayta ve onun ana slaytına erişin.  
1. Hedef sunumun [Presentation] nesnesi tarafından sunulan **Masters** koleksiyonuna başvurarak [IMasterSlideCollection] sınıfını örnekleyin.  
1. [IMasterSlideCollection] nesnesi tarafından sunulan [AddClone] metodunu çağırın ve kaynak PPTX'ten klonlanacak ana slaytı parametre olarak geçin.  
1. Hedef sunumun [Presentation] nesnesi tarafından sunulan **Slides** koleksiyonuna başvurarak [ISlideCollection] sınıfını örnekleyin.  
1. [ISlideCollection] nesnesi tarafından sunulan [AddClone] metodunu çağırın ve kaynak sunumdan klonlanacak slaytı ve ana slaytı parametre olarak geçin.  
1. Değiştirilmiş hedef sunum dosyasını kaydedin.

Aşağıdaki örnekte, kaynak sunumun sıfır indeksindeki bir slaytı ve onun ana slaytını kullanarak hedef sunumun sonuna klonladık.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekle

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Hedef sunum (slaytın klonlanacağı yer) için Presentation sınıfını örnekle
    using (Presentation destPres = new Presentation())
    {

        // Kaynak sunumdaki slayt koleksiyonundan ISlide oluştur
        // Ana slayt
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // İstenen ana slaytı kaynak sunumdan
        // hedef sunumdaki ana slayt koleksiyonuna klonla
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // İstenen ana slaytı kaynak sunumdan
        // hedef sunumdaki ana slayt koleksiyonuna klonla
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // İstenen slaytı, istenen ana slaytıyla birlikte kaynak sunumdan
        // hedef sunumdaki slayt koleksiyonunun sonuna klonla
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // İstenen ana slaytı kaynak sunumdan ana slayt koleksiyonuna klonla // Hedef sunum
        // Hedef sunumu diske kaydet
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## **Belirli Bir Bölümün Sonunda Slaytı Klonla**

Aspose.Slides for .NET ile bir sunumun bir bölümünden bir slaytı klonlayıp aynı sunumda başka bir bölüme ekleyebilirsiniz. Bu durumda, [ISlideCollection] arayüzünden [AddClone] metodunu kullanmanız gerekir.

Bu C# kodu, bir slaytı klonlayıp klonlanan slaytı belirli bir bölüme eklemenizi gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // klonlamak için
    
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);

    pres.Slides.AddClone(slide, section);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Eşleşen Slayt Boyutunu Sağlayın**

Slaytları başka bir sunuma klonlarken, hedef sunumun slayt boyutunun kaynakla aynı olduğundan emin olun. Slayt boyutları farklıysa, Aspose.Slides klonlanan şekilleri otomatik olarak yeniden ölçeklendirmez; orijinal koordinat ve boyutları korunur, bu da içeriğin kaydırılmış veya slayt sınırlarının dışına çıkmış görünmesine yol açabilir.

Ana slaytı ve slaytı klonlamadan önce hedef sunumun slayt boyutunu kaynağa eşit olarak ayarlayabilirsiniz:

```cs
SizeF sourceSize = sourcePresentation.SlideSize.Size;

targetPresentation.SlideSize.SetSize(
    sourceSize.Width, sourceSize.Height, SlideSizeScaleType.DoNotScale);
```

Bunu ana slaytı ve slaytı klonlamadan önce yapın.

## **SSS**

**Sunum notları ve inceleme yorumları klonlanıyor mu?**

Evet. Not sayfası ve inceleme yorumları klona dahil edilir. İstemiyorsanız, ekledikten sonra [kaldırın](/slides/tr/net/presentation-notes/).

**Grafikler ve veri kaynakları nasıl işlenir?**

Grafik nesnesi, biçimlendirmesi ve gömülü verileri kopyalanır. Grafik harici bir kaynağa (ör. OLE gömülü bir çalışma kitabına) bağlanmışsa, bu bağlantı bir [OLE nesnesi](/slides/tr/net/manage-ole/) olarak korunur. Dosyalar arasında taşındıktan sonra veri erişilebilirliğini ve yenileme davranışını doğrulayın.

**Klonun ekleme konumunu ve bölümlerini kontrol edebilir miyim?**

Evet. Klonu belirli bir slayt indeksine ekleyebilir ve istediğiniz bir [bölüme](/slides/tr/net/slide-section/) yerleştirebilirsiniz. Hedef bölüm yoksa, önce oluşturun ve ardından slaytı ona taşıyın.