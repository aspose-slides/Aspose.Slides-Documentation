---
title: ".NET'te Sunum Slaytlarındaki Şekilleri Yeniden Boyutlandırma"
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

Aspose.Slides for .NET müşterilerinin en sık sorduğu sorulardan biri, slayt boyutu değiştiğinde verilerin kesilmemesi için şekillerin nasıl yeniden boyutlandırılacağıdır. Bu kısa teknik makale bunu nasıl yapacağınızı gösterir.

## **Şekilleri Yeniden Boyutlandırma**

Slayt boyutu değiştiğinde şekillerin hizalanmasının bozulmasını önlemek için, her şeklin konum ve boyutlarını yeni slayt düzenine uyacak şekilde güncelleyin.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

    // Her slayttaki şekilleri yeniden boyutlandır ve konumlarını yeniden ayarla.
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

{{% alert color="info" %}}
Bir slayt bir tablo içeriyorsa, yukarıdaki kod doğru çalışmaz. Bu durumda, tablodaki her hücre yeniden boyutlandırılmalıdır.
{{% /alert %}}

Tablo içeren slaytları yeniden boyutlandırmak için aşağıdaki kodu kendi tarafınızda kullanın. Tablolar için, şeklin genişlik ve yüksekliği yerine her bir satır yüksekliği ve sütun genişliğini ölçeklendirin—ikisini birden uygularsanız tablo iki kez ölçeklenir ve slayttan kayar.
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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
            if (shape is ITable)
            {
                // Tablo boyutunu satır ve sütunları aracılığıyla ölçekle.
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
            else
            {
                // Şekil boyutunu ölçekle.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;
            }

            // Şekil konumunu ölçekle.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **SSS**

### Bir slaytı yeniden boyutlandırdıktan sonra şekiller neden bozuluyor veya kesiliyor?

Bir slaytı yeniden boyutlandırdığınızda, ölçek açıkça değiştirilmedikçe şekiller orijinal konum ve boyutlarını korur. Bu, içeriğin kırpılmasına veya şekillerin hizalanmasının bozulmasına neden olabilir.

### Sağlanan kod tüm şekil türleri için çalışıyor mu?

Temel örnek çoğu şekil türü (metin kutuları, resimler, grafikler vb.) için çalışır. Ancak tablolar için satır ve sütunları ayrı ayrı ele almanız gerekir; çünkü bir tablonun yüksekliği ve genişliği bireysel hücrelerin boyutlarıyla belirlenir.

### Bir slaytı yeniden boyutlandırırken tabloları nasıl yeniden boyutlandırırım?

Tablonun tüm satır ve sütunlarını dolaşarak yüksekliğini ve genişliğini orantılı olarak yeniden boyutlandırmanız gerekir; bu ikinci kod örneğinde gösterildiği gibi.

### Bu yeniden boyutlandırma ana slaytlar ve düzen slaytları için de geçerli mi?

Evet, ancak tutarlılığı sağlamak için [Masters](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/masters/) ve [LayoutSlides](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/layoutslides/) üzerinden de dolaşmalı ve şekillerine aynı ölçekleme mantığını uygulamalısınız.

### Slaytı yeniden boyutlandırırken yönünü (dikey/yatay) değiştirebilir miyim?

Evet. Yönü değiştirmek için [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/tr/net/aspose.slides/islidesize/orientation/) ayarlayabilirsiniz. Düzeni korumak için ölçekleme mantığını buna göre ayarladığınızdan emin olun.

### Ayarlayabileceğim bir slayt boyutu sınırlaması var mı?

Aspose.Slides özel boyutları destekler, ancak çok büyük boyutlar performansı etkileyebilir veya bazı PowerPoint sürümleriyle uyumluluk sorunlarına yol açabilir.

### Sabit en-boy oranına sahip şekiller bozulmasın nasıl önleyebilirim?

Şeklin `AspectRatioLocked` özelliğini ölçeklemeden önce kontrol edebilirsiniz. Eğer kilitli ise, genişlik ve yüksekliği ayrı ayrı ölçeklemek yerine oranını koruyarak ayarlayın.