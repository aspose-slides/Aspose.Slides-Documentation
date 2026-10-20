---
title: PowerPoint Sunum Slaytlarında Şekilleri .NET ile Yeniden Boyutlandırma
type: docs
weight: 130
url: /tr/net/resizing-shapes-on-slide/
aliases:
  - /tr/net/re-sizing-shapes-on-slide/
keywords:
  - şekil yeniden boyutlandırma
  - şekil boyutunu değiştir
  - PowerPoint
  - OpenDocument
  - sunum
  - .NET
  - C#
  - Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint ve OpenDocument slaytlarındaki şekilleri kolayca yeniden boyutlandırın—slayt düzeni ayarlamalarını otomatikleştirin ve verimliliği artırın."
---
## **Genel Bakış**

Bir sunumun slayt boyutunu değiştirdiğinizde, şekilleri yeni boyutlara sığdırmak için yeniden boyutlandırmanız ve konumlarını yeniden ayarlamanız gerekebilir. Bu makale, şekilleri manuel olarak nasıl ölçeklendireceğinizi ve slaytlarda, ana slaytlarda ve düzenlerdeki tabloları nasıl ele alacağınızı gösterir.

## **Şekilleri Yeniden Boyutlandırma**

Her şeklin göreceli konumunu ve boyutunu korumak için, yatay koordinatlarını ve genişliğini yeni slayt genişliğinin orijinal genişliğe oranı ile çarpın. İlgili yükseklik oranını da dikey koordinatlarına ve yüksekliğine uygulayın.

İlk örnek, slaytlarında tablo bulunmayan bir sunumu yükler, slayt boyutunu A4 olarak değiştirir ve sonucu kaydeder. Ölçeklemeyi sonraki döngünün kontrol etmesi için [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) ile [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/) kullanır. Oranlar birimsizdir; şekil konumları ve boyutları nokta cinsinden ölçülür. Farklı genişlik ve yükseklik oranları şekilleri bozabilir ve bir şeklin boyutlarını değiştirmek yazı tipi boyutlarını ölçeklendirmez.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Bağımsız yatay ve dikey ölçek faktörlerini hesaplayın.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        shape.Width *= widthRatio;
        shape.Height *= heightRatio;
        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
Tablolar ayrı bir işlem gerektirir: tablo genişliği ve yüksekliği yerine sütun genişliklerini ve satır yüksekliklerini ölçeklendirin. Hücre içeriği daha fazla alan gerektiriyorsa satır yükseklikleri istenenden büyük kalabilir.
{{% /alert %}}

İkinci örnek tabloları destekler ve yeniden boyutlandırılmış sunumu kaydetmeden önce ana slaytlardaki ve düzenlerdeki şekilleri ve bireysel slaytları işler. Yardımcısı, her [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) öğesini [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) ve [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) ölçeklendirerek işler. Daha sonra tablonun konumunu, genel boyutlarını ayrı ayrı ölçeklendirmeden ölçeklendirir.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Bağımsız yatay ve dikey ölçek faktörlerini hesaplayın.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

// Ana slaytlar ve düzenlerde tanımlı şekilleri ve bireysel slaytları yeniden boyutlandırın.
foreach (var master in presentation.Masters)
{
    ResizeShapes(master.Shapes, widthRatio, heightRatio);

    foreach (var layoutSlide in master.LayoutSlides)
    {
        ResizeShapes(layoutSlide.Shapes, widthRatio, heightRatio);
    }
}

foreach (var slide in presentation.Slides)
{
    ResizeShapes(slide.Shapes, widthRatio, heightRatio);
}

presentation.Save("output.pptx", SaveFormat.Pptx);

static void ResizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio)
{
    foreach (var shape in shapes)
    {
        if (shape is ITable table)
        {
            // Tablo boyutları sütun genişlikleri ve satır yükseklikleriyle kontrol edilir.
            foreach (var column in table.Columns)
            {
                column.Width *= widthRatio;
            }

            foreach (var row in table.Rows)
            {
                row.MinimalHeight *= heightRatio;
            }
        }
        else
        {
            shape.Width *= widthRatio;
            shape.Height *= heightRatio;
        }

        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}
```

## **SSS**

**Slayt yeniden boyutlandırıldıktan sonra şekiller neden bozuluyor veya kesiliyor?**

Şekilleri ölçeklendirmeden slayt boyutunu değiştirirseniz, şekiller orijinal konumlarını ve boyutlarını korur ve slayt dışına çıkabilir. Genişlik ve yüksekliği farklı oranlarla ölçeklemek de şekilleri bozabilir.

**Sağlanan kod tüm şekil türleri için çalışıyor mu?**

İlk örnek şekil sınırlarını doğrudan değiştirir ve tabloları olmayan slaytlar için tasarlanmıştır. İkinci örnek tabloları ayrı olarak işler. Son düzeni, özellikle metin ve tabloları kontrol edin; çünkü bu örnekler yazı tipi boyutlarını ölçeklendirmez ve tablo içeriği satır yüksekliklerini kısıtlayabilir.

**Bir slaytı yeniden boyutlandırırken tabloları nasıl yeniden boyutlandırırım?**

Sütun genişliklerini genişlik oranı ile, minimum satır yüksekliğini ise yükseklik oranı ile ölçeklendirin, ardından tablonun konumunu ölçeklendirin; bu ikinci örnekte gösterilmiştir.

**Bu yeniden boyutlandırma ana slaytlar ve düzen slaytları için çalışacak mı?**

Evet. İkinci örnek [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) ve her bir ana slaytın [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/layoutslides/) üzerinden döner ve şekillerine aynı yeniden boyutlandırma mantığını uygular.

**Yeniden boyutlandırma sırasında bir slaytın yönünü (dikey/yatay) değiştirebilir miyim?**

Evet. Slayt boyutunu değiştirdikten ve hedef boyutları okumadan önce [SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/slidesize/orientation/) ayarlayın, böylece ölçek faktörleri son yönelimi yansıtır.

**Ayarlayabileceğim slayt boyutu için bir sınırlama var mı?**

[SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) ile özel slayt boyutları belirleyebilirsiniz. Desteklenen boyutlar ayrıca sunum biçimine ve dosyayı açmak için kullanılan uygulamaya bağlıdır.

**Sabit en-boy oranına sahip şekillerin bozulmasını nasıl önleyebilirim?**

Genişlik ve yükseklik için aynı ölçek faktörünü kullanın. Orijinal yerleşimi yeni slayt boyutlarına sığdırmak için, her iki boyut ve konum için genişlik ve yükseklik oranlarından daha küçük olanı kullanın. Bu, oranları korur ancak bir kenarda kullanılmayan boşluk bırakabilir.