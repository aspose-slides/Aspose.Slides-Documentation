---
title: Yazı Tipi İkamesi için Uyarı Geri Çağrılarını Alın
type: docs
weight: 90
url: /tr/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- uyarı geri çağrısı
- yazı tipi ikamesi
- renderleme süreci
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da yazı tipi ikamesi için uyarı geri çağrılarını almayı öğrenin ve PowerPoint ve OpenDocument sunumlarını doğru bir şekilde görüntüleyin."
---
## **Giriş**

Aspose.Slides for Java, gerekli bir yazı tipinin işleme sırasında makinede bulunmadığı durumlarda yazı tipi ikamesi için uyarı geri çağrıları almanıza olanak tanır. Bu geri çağrılar, eksik veya erişilemeyen yazı tipleriyle ilgili sorunları teşhis etmenize yardımcı olur.

## **Uyarı Geri Çağrımlarını Etkinleştirme**

Aspose.Slides for Java, sunum slaytlarını işlerken uyarı geri çağrıları almanız için kolay API'ler sunar. Uyarı geri çağrılarını yapılandırmak için şu adımları izleyin:

1. Uyarıları işlemek için [IWarningCallback](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iwarningcallback/) arayüzünü uygulayan özel bir geri çağrı sınıfı oluşturun.
1. [RenderingOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/htmloptions/) ve diğer seçenek sınıflarını kullanarak uyarı geri çağrısını ayarlayın.
1. Hedef makinede bulunmayan bir yazı tipi kullanan bir sunumu yükleyin.
1. Etkisini görmek için bir slayt küçük resmi oluşturun veya sunumu dışa aktarın.

**Özel Uyarı Geri Çağrı Sınıfı:**

```java
class FontWarningHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss) {
            System.out.println(warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

// Örnek çıktı:
//
// Yazı tipi XYZ'den {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}'a ikame edilecektir
```

**Slayt Küçük Resmi Oluştur:**

```java
// Slayt renderleme sırasında yazı tipiyle ilgili uyarıları işlemek için bir uyarı geri çağrısı ayarlayın.
RenderingOptions options = new RenderingOptions();
options.setWarningCallback(new FontWarningHandler());

// Belirtilen dosya yolundan sunumu yükleyin.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Sunumdaki her slayt için bir küçük resim oluşturun.
    for (ISlide slide : presentation.getSlides()) {
        // Belirtilen renderleme seçeneklerini kullanarak slayt küçük resmi görüntüsünü alın.
        IImage image = slide.getImage(options);
        // ...

        image.dispose();
    }
}
finally {
    presentation.dispose();
}
```

**PDF Formatına Dışa Aktar:**

```java
// PDF dışa aktarma sırasında yazı tipiyle ilgili uyarıları işlemek için bir uyarı geri çağrısı ayarlayın.
SaveOptions options = new PdfOptions();
options.setWarningCallback(new FontWarningHandler());

// Belirtilen dosya yolundan sunumu yükleyin.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Sunumu PDF olarak dışa aktarın.
    ByteArrayOutputStream stream = new ByteArrayOutputStream();
    presentation.save(stream, SaveFormat.Pdf, options);
    // ...
}
finally {
    presentation.dispose();    
}
```

**HTML Formatına Dışa Aktar:**

```java
// HTML dışa aktarma sırasında yazı tipiyle ilgili uyarıları işlemek için bir uyarı geri çağrısı ayarlayın.
SaveOptions options = new HtmlOptions();
options.setWarningCallback(new FontWarningHandler());

// Belirtilen dosya yolundan sunumu yükleyin.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Sunumu HTML formatında dışa aktarın.
    ByteArrayOutputStream stream = new ByteArrayOutputStream();
    presentation.save(stream, SaveFormat.Html, options);
    // ...
}
finally {
    presentation.dispose();
}
```