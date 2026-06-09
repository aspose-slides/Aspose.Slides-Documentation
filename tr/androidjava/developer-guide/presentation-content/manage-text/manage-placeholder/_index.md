---
title: Android'de Sunum Yer Tutucularını Yönetme
linktitle: Yer Tutucuları Yönet
type: docs
weight: 10
url: /tr/androidjava/manage-placeholder/
keywords:
- yer tutucu
- metin yer tutucu
- resim yer tutucu
- grafik yer tutucu
- talep metni
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile yer tutucuları zahmetsizce yönetin: PowerPoint ve OpenDocument'te metni değiştirin, istemleri özelleştirin ve resim şeffaflığını ayarlayın."
---
## **Genel Bakış**

Aspose.Slides, sunum yer tutucularını programlı olarak yönetmenizi sağlar. Bu makale, slaytlarda yer tutucuları nasıl bulacağınızı ve metinlerini nasıl değiştireceğinizi, yer tutucu düzenleri için özel talep metni nasıl ayarlayacağınızı ve yer tutucu arka planı olarak kullanılan bir resmin şeffaflığını nasıl ayarlayacağınızı açıklar. Ayrıca, temel yer tutucular ile yerel şekiller arasındaki farkı açıklayan, yer tutucu değişikliklerinin düzenler veya ana sunum üzerinden nasıl uygulanabileceğini gösteren ve başlık ve altbilgi yer tutucu yönetimine işaret eden kısa bir SSS içerir.

## **Yer Tutucuda Metni Değiştirme**
[Aspose.Slides for Android via Java](/slides/tr/androidjava/) kullanarak sunumlardaki slaytlarda yer tutucuları bulabilir ve değiştirebilirsiniz. Aspose.Slides, bir yer tutucunun metninde değişiklik yapmanıza olanak tanır.

**Önkoşul**: Bir yer tutucu içeren bir sunuma ihtiyacınız var. Böyle bir sunumu standart Microsoft PowerPoint uygulamasında oluşturabilirsiniz.

Aspose.Slides'ı kullanarak bu sunumdaki yer tutucunun metnini nasıl değiştireceğiniz aşağıda gösterilmiştir:

1. [`Presentation`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun ve sunumu argüman olarak geçirin.
2. İndeks aracılığıyla bir slayt referansı alın.
3. Yer tutucuyu bulmak için şekiller arasında dolaşın.
4. Yer tutucu şeklini bir [`AutoShape`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/AutoShape) tipine dönüştürün ve [`AutoShape`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/AutoShape) ile ilişkilendirilmiş [`TextFrame`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/TextFrame) kullanarak metni değiştirin.
5. Değiştirilmiş sunumu kaydedin.

Bu Java kodu, bir yer tutucunun metnini nasıl değiştireceğinizi gösterir:

```java
// Bir Presentation sınıfını örnekler
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // İlk slayta erişir
    ISlide sld = pres.getSlides().get_Item(0);

    // Yer tutucuyu bulmak için şekiller arasında döner
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // Her bir yer tutucudaki metni değiştirir
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // Sunumu diske kaydeder
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Yer Tutucuda Talep Metni Ayarlama**
Standart ve önceden oluşturulmuş düzenler, ***Başlık eklemek için tıklayın*** veya ***Alt başlık eklemek için tıklayın*** gibi yer tutucu talep metinlerini içerir. Aspose.Slides kullanarak tercih ettiğiniz talep metinlerini yer tutucu düzenlerine ekleyebilirsiniz.

Bu Java kodu, bir yer tutucuda talep metnini nasıl ayarlayacağınızı gösterir:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // Slayt içinde yineleme yapar
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPoint "Başlık eklemek için tıklayın" mesajını gösterir 
            {
                text = "Add Title";
            }
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // Alt başlık ekler
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).getTextFrame().setText(text);
            System.out.println("Placeholder with text: " + text);
        }
    }

    pres.save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Yer Tutucu Görüntü Şeffaflığını Ayarlama**

Aspose.Slides, metin yer tutucusundaki arka plan resminin şeffaflığını ayarlamanıza izin verir. Bu çerçevedeki resmin şeffaflığını ayarlayarak, metni veya resmi (metin ve resim renklerine bağlı olarak) öne çıkarabilirsiniz.

Bu Java kodu, bir şekil içindeki resim arka planının şeffaflığını nasıl ayarlayacağınızı gösterir:

```java
Presentation presentation = new Presentation("example.pptx");

IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

IImageTransformOperationCollection operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (int i = 0; i < operationCollection.size(); i++)
{
    if(operationCollection.get_Item(i) instanceof AlphaModulateFixed)
    {
        AlphaModulateFixed alphaModulate = (AlphaModulateFixed)operationCollection.get_Item(i);
        float currentValue = 100 - alphaModulate.getAmount();
        System.out.println("Current transparency value: " + currentValue);

        int alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}

presentation.save("example_out.pptx", SaveFormat.Pptx);
```

## **SSS**

**Temel yer tutucu nedir ve slayttaki yerel şekilden nasıl farklıdır?**  
Temel yer tutucu, slaytın şeklinin miras aldığı bir düzen veya ana sayfadaki orijinal şekildir—tipi, konumu ve bazı biçimlendirmeleri ondan gelir. Yerel şekil bağımsızdır; temel yer tutucu yoksa miras uygulanmaz.

**Bir sunumdaki tüm başlıkları veya alt başlıkları, her slaytı dolaşmadan nasıl güncelleyebilirim?**  
Düzen veya ana sayfadaki ilgili yer tutucuyu düzenleyin. Bu düzenlerden/ana sayfadan oluşturulan slaytlar, değişikliği otomatik olarak miras alır.

**Standart başlık/altbilgi yer tutucularını—tarih & saat, slayt numarası ve altbilgi metni—nasıl kontrol edebilirim?**  
Uygun kapsamda (normal slaytlar, düzenler, ana sayfa, notlar/dağıtımlar) HeaderFooter yöneticilerini kullanarak bu yer tutucuları açıp kapatabilir ve içeriklerini ayarlayabilirsiniz.