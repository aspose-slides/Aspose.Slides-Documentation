---
title: Java'da Sunum Yer Tutucularını Yönet
linktitle: Yer Tutucuları Yönet
type: docs
weight: 10
url: /tr/java/manage-placeholder/
keywords:
- yer tutucu
- metin yer tutucu
- görsel yer tutucu
- grafik yer tutucu
- istem metni
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da yer tutucuları zahmetsizce yönetin: metni değiştirin, istemleri özelleştirin ve PowerPoint ile OpenDocument'ta görsel şeffaflığını ayarlayın."
---
## **Genel Bakış**

Aspose.Slides, sunum yer tutucularını programlı olarak yönetmenizi sağlar. Bu makale, slaytlarda yer tutucuları bulmayı ve metinlerini değiştirmeyi, yer tutucu düzenleri için özel istem metni ayarlamayı ve yer tutucu arka planı olarak kullanılan bir resmin şeffaflığını ayarlamayı açıklar. Ayrıca, temel yer tutucular ile yerel şekiller arasındaki farkı netleştiren kısa bir SSS içerir, yer tutucu değişikliklerinin düzenler veya ana tasarımlar aracılığıyla nasıl uygulanacağını açıklar ve üst bilgi ve alt bilgi yer tutucu yönetimine işaret eder.

## **Yer Tutucuda Metni Değiştirme**
[ Aspose.Slides for Java](/slides/tr/java/), kullanarak, sunumlardaki slaytlarda yer tutucuları bulabilir ve değiştirebilirsiniz. Aspose.Slides, bir yer tutucudaki metni değiştirmenizi sağlar.

**Ön Koşul**: Yer tutucu içeren bir sunuma ihtiyacınız var. Böyle bir sunumu standart Microsoft PowerPoint uygulamasında oluşturabilirsiniz.

Bu, Aspose.Slides'ı kullanarak o sunumdaki yer tutucunun metnini değiştirme şeklidir:

1. [`Presentation`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfını örnekleyin ve sunumu parametre olarak geçirin.
2. İndeks aracılığıyla bir slayt referansı alın.
3. Yer tutucuyu bulmak için şekiller arasında döngü yapın.
4. Yer tutucu şekli bir [`AutoShape`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/AutoShape) tipine dönüştürün ve [`AutoShape`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/AutoShape) ile ilişkili [`TextFrame`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/TextFrame) kullanarak metni değiştirin.
5. Değiştirilmiş sunumu kaydedin.

Bu Java kodu, yer tutucudaki metnin nasıl değiştirileceğini gösterir:

```java
// Bir Presentation sınıfını örnekler
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // İlk slaytı erişir
    ISlide sld = pres.getSlides().get_Item(0);

    // Yer tutucuyu bulmak için şekiller arasında döngü yapar
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // Her yer tutucudaki metni değiştirir
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // Sunumu diske kaydeder
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Yer Tutucuda İstem Metni Ayarlama**
Standart ve önceden oluşturulmuş düzenlerde ***Click to add a title*** veya ***Click to add a subtitle*** gibi yer tutucu istem metinleri bulunur. Aspose.Slides kullanarak tercih ettiğiniz istem metinlerini yer tutucu düzenlerine ekleyebilirsiniz.

Bu Java kodu, yer tutucuda istem metninin nasıl ayarlanacağını gösterir:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // Slayt içinde yineleme yapar
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPoint "Başlık eklemek için tıklayın" gösterir 
            {
                text = "Add Title";
            }
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // Altyazı ekler
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

## **Yer Tutucu Resim Şeffaflığını Ayarlama**

Aspose.Slides, metin yer tutucusundaki arka plan resminin şeffaflığını ayarlamanıza olanak tanır. Bu çerçevedeki resmin şeffaflığını ayarlayarak metni veya resmi öne çıkarabilirsiniz (metin ve resim renklerine bağlı olarak).

Bu Java kodu, bir şekil içindeki resim arka planının şeffaflığının nasıl ayarlanacağını gösterir:

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

**Temel yer tutucu nedir ve bir slayttaki yerel şekilden nasıl farklıdır?**

Temel yer tutucu, slayt şeklinin miras aldığı bir düzen veya ana tasarım üzerindeki orijinal şekildir—tipi, konumu ve bazı biçimlendirmeleri ondan gelir. Yerel şekil bağımsızdır; eğer temel bir yer tutucu yoksa miras uygulanmaz.

**Sunumdaki tüm başlıkları veya alt yazıları, her slaytı tek tek dolaşmadan nasıl güncelleyebilirim?**

Düzen veya ana tasarım üzerindeki ilgili yer tutucuyu düzenleyin. Bu düzenlere/ana tasarıma dayalı slaytlar değişikliği otomatik olarak miras alır.

**Standart üst bilgi/alt bilgi yer tutucularını—tarih & saat, slayt numarası ve alt bilgi metni—nasıl kontrol edebilirim?**

Bu yer tutucuları açıp kapatmak ve içeriklerini ayarlamak için uygun kapsamda (normal slaytlar, düzenler, ana tasarım, notlar/el ilanları) HeaderFooter yöneticilerini kullanın.