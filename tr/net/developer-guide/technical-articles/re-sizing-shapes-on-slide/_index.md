---
title: Sunum Slaytlarındaki Şekilleri .NET'te Yeniden Boyutlandırma
type: docs
weight: 130
url: /tr/net/re-sizing-shapes-on-slide/
keywords:
- şekil yeniden boyutlandırma
- şekil boyutunu değiştirme
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint ve OpenDocument slaytlarındaki şekilleri kolayca yeniden boyutlandırın—slayt düzeni ayarlamalarını otomatikleştirin ve verimliliği artırın."
---
## **Genel Bakış**

Aspose.Slides for .NET müşterilerinin en sık sorduğu sorulardan biri, slayt boyutu değiştiğinde verinin kesilmemesi için şekillerin nasıl yeniden boyutlandırılacağıdır. Bu kısa teknik makale bunu nasıl yapacağınızı gösterir.

## **Şekilleri Yeniden Boyutlandır**

Slayt boyutu değiştiğinde şekillerin hizalanmış kalmasını sağlamak için, her şeklin konumunu ve boyutlarını yeni slayt düzenine göre güncelleyin.

```c#
// Sunum dosyasını yükle.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Orijinal slayt boyutunu al.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Mevcut şekilleri ölçeklemeden slayt boyutunu değiştir.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Yeni slayt boyutunu al.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Her slayttaki şekilleri yeniden boyutlandır ve yeniden konumlandır.
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // Şekil boyutunu ölçekle.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Şekil konumunu ölçekle.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}
Bir slayt bir tablo içeriyorsa, yukarıdaki kod doğru çalışmaz. Bu durumda tablodaki her hücre yeniden boyutlandırılmalıdır.
{{% /alert %}}

Tabloları içeren slaytları yeniden boyutlandırmak için aşağıdaki kodu kullanın. Tablolar için genişlik veya yüksekliği ayarlamak özel bir durumdur: tablonun genel boyutunu değiştirmek adına satır yüksekliklerini ve sütun genişliklerini ayrı ayrı ayarlamanız gerekir.

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Orijinal slayt boyutunu al.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Mevcut şekilleri ölçeklemeden slayt boyutunu değiştir.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.SlideSize.Orientation = SlideOrienation.Portrait;

    // Yeni slayt boyutunu al.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    foreach (IMasterSlide master in presentation.Masters)
    {
        foreach (IShape shape in master.Shapes)
        {
            // Şekil boyutunu ölçekle.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Şekil konumunu ölçekle.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }

        foreach (ILayoutSlide layoutSlide in master.LayoutSlides)
        {
            foreach (IShape shape in layoutSlide.Shapes)
            {
                // Şekil boyutunu ölçekle.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;

                // Şekil konumunu ölçekle.
                shape.Y *= heightRatio;
                shape.X *= widthRatio;
            }
        }
    }

    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // Şekil boyutunu ölçekle.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Şekil konumunu ölçekle.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;

            if (shape is ITable)
            {
                ITable table = (ITable)shape;
                foreach (IRow row in table.Rows)
                {
                    row.MinimalHeight *= heightRatio;
                }
                foreach (IColumn column in table.Columns)
                {
                    column.Width *= widthRatio;
                }
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **SSS**

**Bir slaytı yeniden boyutlandırdıktan sonra şekiller neden bozuluyor ya da kesiliyor?**

Bir slaytı yeniden boyutlandırdığınızda, ölçek açıkça değiştirilmediyse şekiller orijinal konum ve boyutlarını korur. Bu, içeriğin kesilmesine veya şekillerin hizalanmamasına neden olabilir.

**Sağlanan kod tüm şekil türleri için çalışıyor mu?**

Temel örnek çoğu şekil türü (metin kutuları, resimler, grafikler vb.) için çalışır. Ancak, tablolar için satır ve sütunları ayrı ayrı ele almanız gerekir; çünkü bir tablonun yüksekliği ve genişliği bireysel hücrelerin boyutlarıyla belirlenir.

**Bir slaytı yeniden boyutlandırırken tabloları nasıl yeniden boyutlandırırım?**

Tablonun tüm satır ve sütunlarını dolaşarak yüksekliğini ve genişliğini orantılı olarak yeniden boyutlandırmanız gerekir; bu ikinci kod örneğinde gösterildiği gibi.

**Bu yeniden boyutlandırma, master slaytlar ve layout slaytları için de geçerli mi?**

Evet, aynı ölçeklendirme mantığını uygulamak için [Masters](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/masters/) ve [LayoutSlides](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/layoutslides/) üzerinden de dolaşmalı ve şekillerine aynı işlemi uygulamalısınız; böylece sunum genelinde tutarlılık sağlanır.

**Slayt yönünü (portre/landscape) yeniden boyutlandırma ile birlikte değiştirebilir miyim?**

Evet. Yönü değiştirmek için [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/tr/net/aspose.slides/islidesize/orientation/) ayarlayabilirsiniz. Düzeni korumak için ölçeklendirme mantığını buna göre ayarladığınızdan emin olun.

**Ayarlayabileceğim slayt boyutu için bir sınırlama var mı?**

Aspose.Slides özel boyutları destekler, ancak çok büyük boyutlar performansı etkileyebilir veya bazı PowerPoint sürümleriyle uyumluluk sorunları yaratabilir.

**Sabit en-boy oranına sahip şekillerin bozulmasını nasıl önleyebilirim?**

Şekli ölçeklendirmeden önce `AspectRatioLocked` özelliğini kontrol edebilirsiniz. Eğer kilitliyse, genişliği veya yüksekliği ayrı ayrı değil, orantılı olarak ayarlayın.