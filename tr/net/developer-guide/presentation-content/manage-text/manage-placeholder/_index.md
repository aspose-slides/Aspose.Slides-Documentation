---
title: .NET'te Sunum Yer Tutucularını Yönetme
linktitle: Yer Tutucuları Yönet
type: docs
weight: 10
url: /tr/net/manage-placeholder/
keywords:
- yer tutucu
- metin yer tutucu
- resim yer tutucu
- grafik yer tutucu
- istem metni
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te yer tutucuları zahmetsizce yönetin: metni değiştirin, istemleri özelleştirin ve PowerPoint ve OpenDocument'te resim şeffaflığını ayarlayın."
---
## **Genel Bakış**

Aspose.Slides, sunum yer tutucularını programlı olarak yönetmenizi sağlar. Bu makalede slaytlardaki yer tutucuların nasıl bulunacağı ve metinlerinin nasıl değiştirileceği, yer tutucu düzenleri için özel istem metni (prompt text) ayarlama ve bir yer tutucu arka planı olarak kullanılan resmin şeffaflığının nasıl ayarlanacağı açıklanır. Ayrıca temel yer tutucular ile yerel şekiller arasındaki farkı açıklayan kısa bir SSS bölümü, yer tutucu değişikliklerinin düzenler veya ana şablonlar aracılığıyla nasıl uygulanabileceği ve başlık ve alt bilgi yer tutucu yönetimine yönelik yönlendirmeler bulunur.

## **Bir Yer Tutucunun Metnini Değiştirme**
[Aspose.Slides for .NET](/slides/tr/net/), sunumlardaki slaytlarda yer tutucuları bulup değiştirebilmenizi sağlar. Aspose.Slides, bir yer tutucunun metninde değişiklik yapmanıza imkan tanır.

**Önkoşul**: Yer tutucu içeren bir sunuma ihtiyacınız var. Bu tür bir sunumu standart Microsoft PowerPoint uygulamasında oluşturabilirsiniz.

Aspose.Slides kullanarak o sunumdaki yer tutucunun metnini değiştirmek için şu adımları izleyin:

1. [`Presentation`](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun ve sunumu argüman olarak iletin.
2. İndeksi aracılığıyla bir slayt referansı alın.
3. Şekilleri döngüyle gezerek yer tutucuyu bulun.
4. Yer tutucu şekli bir [`AutoShape`](https://reference.aspose.com/slides/tr/net/aspose.slides/autoshape/) olarak tip dönüştürün ve [`AutoShape`](https://reference.aspose.com/slides/tr/net/aspose.slides/autoshape/) ile ilişkili [`TextFrame`](https://reference.aspose.com/slides/tr/net/aspose.slides/textframe/) üzerinden metni değiştirin.
5. Değiştirilmiş sunumu kaydedin.

Bu C# kodu, bir yer tutucunun metninin nasıl değiştirileceğini gösterir:

```c#
 // Bir Presentation sınıfı örnekler
 using (Presentation pres = new Presentation("ReplacingText.pptx"))
 {
 
     // İlk slayta erişir
     ISlide sld = pres.Slides[0];
 
     // Yer tutucuyu bulmak için şekilleri iterasyonla dolaşır
     foreach (IShape shp in sld.Shapes)
         if (shp.Placeholder != null)
         {
             // Her yer tutucunun metnini değiştirir
             ((IAutoShape)shp).TextFrame.Text = "This is a Placeholder";
         }
 
     // Sunumu diske kaydeder
     pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```

## **Bir Yer Tutucuda İstem Metni Ayarlama**
Standart ve önceden oluşturulmuş düzenler, ***Click to add a title*** veya ***Click to add a subtitle*** gibi yer tutucu istem metinleri içerir. Aspose.Slides kullanarak yer tutucu düzenlerine tercih ettiğiniz istem metinlerini ekleyebilirsiniz.

Bu C# kodu, bir yer tutucuda istem metninin nasıl ayarlanacağını gösterir:

```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // Slaytı iterasyonla dolaşır
    {
        if (shape.Placeholder != null && shape is AutoShape)
        {
            string text = "";
            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle) // PowerPoint "Click to add title" gösterir
            {
                text = "Add Title";
            }
            else if (shape.Placeholder.Type == PlaceholderType.Subtitle) // Alt başlık ekler
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).TextFrame.Text = text;

            Console.WriteLine($"Placeholder with text: {text}");
        }
    }

    pres.Save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
}
```

## **Yer Tutucu Resim Şeffaflığı Ayarlama**

Aspose.Slides, bir metin yer tutucusundaki arka plan resminin şeffaflığını ayarlamanıza izin verir. Böyle bir çerçevedeki resmin şeffaflığını düzenleyerek, metnin ya da resmin öne çıkmasını sağlayabilirsiniz (metnin ve resmin renklerine bağlı olarak).

Bu C# kodu, bir şekil içindeki resim arka planının şeffaflığının nasıl ayarlanacağını gösterir:

```c#
using (var presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    
    autoShape.FillFormat.FillType = FillType.Picture;
    autoShape.FillFormat.PictureFillFormat.Picture.Image = presentation.Images.AddImage(File.ReadAllBytes("image.png"));
    autoShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    autoShape.FillFormat.PictureFillFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(75);
}
```

## **SSS**

**Temel bir yer tutucu nedir ve bir slayttaki yerel şekilden nasıl farklıdır?**

Temel yer tutucu, slaytın şeklinin kalıtım aldığı düzen veya ana şablondaki (master) orijinal şekildir—tipi, konumu ve bazı biçimlendirmeler ondan gelir. Yerel şekil bağımsızdır; temel bir yer tutucu yoksa kalıtım uygulanmaz.

**Tüm başlıkları veya alt yazıları, her slaytı tek tek döngüye sokmadan sunum genelinde nasıl güncelleyebilirim?**

İlgili yer tutucuyu düzenin (layout) ya da ana şablonun (master) üzerinde güncelleyin. Bu düzen/ana şablona dayanan slaytlar değişikliği otomatik olarak devralır.

**Standart başlık/alt bilgi yer tutucularını—tarih & saat, slayt numarası ve alt bilgi metni—nasıl kontrol edebilirim?**

Uygun kapsamda (normal slaytlar, düzenler, ana şablon, notlar/çıkartmalar) HeaderFooter yöneticilerini kullanarak bu yer tutucuları açıp kapatabilir ve içeriklerini ayarlayabilirsiniz.