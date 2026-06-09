---
title: .NET'te Sunum Slaytlarını Klonla
linktitle: Slaytları Klonla
type: docs
weight: 40
url: /tr/net/clone-slides/
keywords:
- slayt klonlama
- slayt kopyalama
- slayt kaydetme
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint slaytlarını hızlı bir şekilde çoğaltın. Saniyeler içinde PPT oluşturmayı otomatikleştirmek ve manuel çalışmayı ortadan kaldırmak için açık ve anlaşılır kod örneklerimizi izleyin."
---
## **Giriş**

Klonlama, bir şeyin tam bir kopyasını veya replikasını oluşturma işlemidir. Aspose.Slides, herhangi bir slaytı kopyalamanıza (klonlamanıza) ve ardından klonlanan slaytı mevcut sunuma veya başka bir açık sunuma eklemenize de izin verir. Slayt klonlama, geliştiricilerin orijinal slaytı etkilemeden değiştirebilecekleri yeni bir slayt oluşturur. Bir slaytı klonlamanın birkaç yolu vardır:

- Sunumun sonuna klonla.
- Sunum içinde başka bir konuma klonla.
- Başka bir sunumun sonuna klonla.
- Başka bir sunumda başka bir konuma klonla.
- Başka bir sunumda belirli bir konuma klonla.

Aspose.Slides for .NET'te, [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) nesnesi tarafından sunulan slayt koleksiyonu (bir [ISlide](https://reference.aspose.com/slides/tr/net/aspose.slides/islide/) nesnesi koleksiyonu) yukarıda açıklanan slayt klonlama işlemlerini gerçekleştirmek için [AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection/addclone/) ve [InsertClone](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/insertclone/) yöntemlerini sağlar.

## **Bir Sunumun Sonunda Slaytı Klonla**

Bir slaytı klonlamak ve ardından aynı sunum dosyasında mevcut slaytların sonuna eklemek istiyorsanız, aşağıda listelenen adımlara göre [AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection/methods/addclone/index) yöntemini kullanın:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) nesnesi tarafından sağlanan Slides koleksiyonuna referans vererek [ISlideCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection) sınıfını başlatın.
1. [ISlideCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection) nesnesinin sunduğu [AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection/methods/addclone/index) yöntemini çağırın ve klonlanacak slaytı [AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection/methods/addclone/index) metoduna parametre olarak geçin.
1. Değiştirilmiş sunum dosyasını yazın.

Aşağıdaki örnekte, sunumun birinci konumunda (sıfır indeksi) bulunan bir slaytı sunumun sonuna klonladık.

```c#
// Sunum dosyasını temsil eden Presentation sınıfını örnekle
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // İstenen slaytı aynı sunumdaki slayt koleksiyonunun sonuna klonla
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // Değiştirilmiş sunumu diske yaz
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```

## **Sunum İçinde Başka Bir Konuma Slaytı Klonla**
Bir slaytı klonlamak ve aynı sunum dosyasında farklı bir konuma eklemek istiyorsanız, [InsertClone](https://reference.aspose.com/slides/tr/net/aspose.slides.ishapecollection/insertclone/methods/1) yöntemini kullanın:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. **Slides** koleksiyonuna referans vererek [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) nesnesi üzerinden sınıfı başlatın.
1. [ISlideCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection) nesnesinin sunduğu [InsertClone](https://reference.aspose.com/slides/tr/net/aspose.slides.ishapecollection/insertclone/methods/1) yöntemini çağırın ve klonlanacak slaytı, yeni konumun indeksiyle birlikte [InsertClone](https://reference.aspose.com/slides/tr/net/aspose.slides.ishapecollection/insertclone/methods/1) metoduna parametre olarak geçin.
1. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Aşağıdaki örnekte, sunumun sıfır indeksi (konum 1) konumunda bulunan bir slaytı indeks 1 – konum 2 –'ye klonladık.

```c#
// Sunum dosyasını temsil eden Presentation sınıfını örnekle
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // İstenen slaytı aynı sunumdaki slayt koleksiyonunun sonuna klonla
    ISlideCollection slds = pres.Slides;

    // İstenen slaytı aynı sunumda belirtilen indekse klonla
    slds.InsertClone(2, pres.Slides[1]);

    // Değiştirilmiş sunumu diske kaydet
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```

## **Başka Bir Sunumun Sonunda Slaytı Klonla**
Bir sunumdan bir slaytı klonlayıp, başka bir sunum dosyasında mevcut slaytların sonuna eklemeniz gerektiğinde:

1. Slaytın klonlanacağı kaynak sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) örneği oluşturun.
1. Slaytın ekleneceği hedef sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) örneği oluşturun.
1. Hedef sunumun Presentation nesnesi tarafından sağlanan **Slides** koleksiyonuna referans vererek [ISlideCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection) sınıfını başlatın.
1. [ISlideCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection) nesnesinin sunduğu [AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection/methods/addclone/index) yöntemini çağırın ve kaynak sunumdan alınan slaytı [AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection/methods/addclone/index) metoduna parametre olarak geçin.
1. Değiştirilmiş hedef sunum dosyasını yazın.

Aşağıdaki örnekte, kaynak sunumun birinci indeksindeki bir slaytı hedef sunumun sonuna klonladık.

```c#
// Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekle
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Hedef PPTX (slaytın klonlanacağı yer) için Presentation sınıfını örnekle
    using (Presentation destPres = new Presentation())
    {
        // İstenen slaytı kaynak sunumdan hedef sunumdaki slayt koleksiyonunun sonuna klonla
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // Hedef sunumu diske kaydet
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Başka Bir Sunumda Başka Bir Konuma Slaytı Klonla**
Bir sunumdan bir slaytı klonlayıp başka bir sunum dosyasında belirli bir konuma eklemeniz gerektiğinde:

1. Slaytın klonlanacağı kaynak sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) örneği oluşturun.
1. Slaytın ekleneceği hedef sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) örneği oluşturun.
1. Hedef sunumun Presentation nesnesi tarafından sağlanan Slides koleksiyonuna referans vererek [ISlideCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection) sınıfını başlatın.
1. [ISlideCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection) nesnesinin sunduğu [InsertClone](https://reference.aspose.com/slides/tr/net/aspose.slides.ishapecollection/insertclone/methods/1) yöntemini çağırın ve kaynak sunumdan alınan slaytı, istenen konumla birlikte [InsertClone](https://reference.aspose.com/slides/tr/net/aspose.slides.ishapecollection/insertclone/methods/1) metoduna parametre olarak geçin.
1. Değiştirilmiş hedef sunum dosyasını yazın.

Aşağıdaki örnekte, kaynak sunumun sıfır indeksindeki bir slaytı hedef sunumun indeks 1 (konum 2) konumuna klonladık.

```c#
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

## **Başka Bir Sunumda Belirli Bir Konuma Slaytı Klonla**
Bir master slaytı olan bir slaytı bir sunumdan alıp başka bir sunuma eklemeniz gerektiğinde, önce kaynak sunumdan hedef sunuma istenen master slaytı klonlamanız gerekir. Ardından bu master slaytı, master slaytıyla birlikte slaytı klonlamak için kullanmalısınız. **AddClone(ISlide, IMasterSlide)**, kaynak sunumdan değil, hedef sunumdan bir master slayt bekler. Master slaytıyla birlikte slaytı klonlamak için aşağıdaki adımları izleyin:

1. Slaytı klonlayacağınız kaynak sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) örneği oluşturun.
1. Slaytı klonlayacağınız hedef sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) örneği oluşturun.
1. Klonlanacak slaytı ve master slaytı erişin.
1. Hedef sunumun Presentation nesnesi tarafından sağlanan Masters koleksiyonuna referans vererek [IMasterSlideCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterslidecollection) sınıfını başlatın.
1. [IMasterSlideCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterslidecollection) nesnesinin sunduğu [AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection/methods/addclone/index) yöntemini çağırın ve kaynak PPTX'ten klonlanacak master slaytı parametre olarak geçin.
1. Hedef sunumun Presentation nesnesi tarafından sağlanan Slides koleksiyonuna referans vererek [ISlideCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection) sınıfını başlatın.
1. [ISlideCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection) nesnesinin sunduğu [AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection/methods/addclone/index) yöntemini çağırın ve kaynak sunumdan klonlanacak slaytı ve master slaytı parametre olarak geçin.
1. Değiştirilmiş hedef sunum dosyasını yazın.

Aşağıdaki örnekte, kaynak sunumun sıfır indeksindeki bir master slaytı içeren bir slaytı, kaynak slayttan alınan master kullanılarak hedef sunumun sonuna klonladık.

```c#
// Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekle

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Hedef sunum (slaytın klonlanacağı yer) için Presentation sınıfını örnekle
    using (Presentation destPres = new Presentation())
    {

        // Kaynak sunumdaki slayt koleksiyonundan ISlide'ı ve
        // Master slaytı
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // İstenen master slaytı kaynak sunumdan master koleksiyonuna klonla
        // Hedef sunum
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // İstenen master slaytı kaynak sunumdan master koleksiyonuna klonla
        // Hedef sunum
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // İstenen master ile kaynak sunumdan istenen slaytı hedef sunumdaki slayt koleksiyonunun sonuna klonla
        // Hedef sunumdaki slayt koleksiyonu
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // Kaynak sunumdan istenen master slaytı hedef sunumdaki master koleksiyonuna klonla // Hedef sunum
        // Hedef sunumu diske kaydet
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## **Belirtilen Bir Bölümün Sonunda Slaytı Klonla**

Aspose.Slides for .NET ile bir sunumun bir bölümünden slaytı klonlayıp aynı sunum içinde başka bir bölüme ekleyebilirsiniz. Bu durumda, [ISlideCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection) arayüzünden [AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection/methods/addclone/index) yöntemini kullanmanız gerekir.

Aşağıdaki C# kodu, bir slaytı klonlayıp klonlanan slaytı belirtilen bir bölüme nasıl ekleyeceğinizi gösterir:

```c#
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

## **SSS**

**Konuşmacı notları ve inceleme yorumları da klonlanır mı?**

Evet. Not sayfası ve inceleme yorumları klona dahil edilir. İstemiyorsanız, eklemeden sonra [kaldırın](/slides/tr/net/presentation-notes/).

**Grafikler ve veri kaynakları nasıl ele alınır?**

Grafik nesnesi, biçimlendirme ve gömülü veri kopyalanır. Grafik harici bir kaynağa (örneğin OLE gömülü çalışma kitabı) bağlanmışsa, bu bağlantı bir [OLE nesnesi](/slides/tr/net/manage-ole/) olarak korunur. Dosyalar arasında taşındıktan sonra veri kullanılabilirliğini ve yenileme davranışını doğrulayın.

**Klonun ekleme konumunu ve bölümlerini kontrol edebilir miyim?**

Evet. Klonu belirli bir slayt indeksine ekleyebilir ve seçtiğiniz bir [bölüm](/slides/tr/net/slide-section/) içine yerleştirebilirsiniz. Hedef bölüm mevcut değilse, önce oluşturun ve ardından slaytı o bölüme taşıyın.