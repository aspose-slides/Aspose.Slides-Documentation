---
title: Java'da Sunum Oluşturma
linktitle: Sunum Oluştur
type: docs
weight: 10
url: /tr/java/create-presentation/
keywords:
- sunum oluştur
- yeni sunum
- PPT oluştur
- yeni PPT
- PPTX oluştur
- yeni PPTX
- ODP oluştur
- yeni ODP
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Java'da Aspose.Slides ile sunum oluşturun - PPT, PPTX ve ODP dosyaları üretin, OpenDocument desteğinden yararlanın ve güvenilir sonuçlar için programlı olarak kaydedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ta bir sunum nasıl oluşturulacağını, ilk slayta metinli bir şekil eklemeyi ve sonucu PPTX dosyası olarak kaydetmeyi gösterir. Mevcut bir sunumu açmak ve başka bir biçimde kaydetmek için [Open Presentations](/slides/tr/java/open-presentation/) ve [Save Presentations](/slides/tr/java/save-presentation/) bölümlerine bakın. Sondaki kısa SSS, biçimler, şablonlar, slayt boyutlandırma, birimler, bellek kullanımı, çoklu iş parçacığı, lisanslama, dijital imzalar ve VBA desteğiyle ilgili yaygın soruları kapsar.

Başlamadan önce, Aspose Slides for Java'yı projenize Aspose'nun Maven deposundan ekleyin. Maven kurulumu ve Linux için ek gereksinimler için [Installation](/slides/tr/java/installation/) bölümüne bakın.

## **Sunum Oluşturma**

Aspose.Slides for Java'da sıfırdan bir PowerPoint dosyası oluşturmak, [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) sınıfının bir örneğiyle başlar. Yapıcı, şekiller, metin, grafikler veya uygulamanızın ihtiyaç duyduğu diğer içerikler için hazır tek bir slayt içeren boş bir sunum sağlar. Bu slaytı düzenledikten veya yeni slaytlar ekledikten sonra sonucu PPTX, eski PPT veya OpenDocument biçimlerinde kaydedebilirsiniz.

Bir sunum oluşturmak ve ilk slayta metinli bir şekil eklemek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun. Yeni bir sunum zaten bir boş slayt içerir.  
2. [getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) metodunun döndürdüğü koleksiyondan, indeks 0 kullanarak o slaytı alın.  
3. `Cloud` tipinde bir [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) eklemek için [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) metodunu kullanın ve metnini [setText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#setText-java.lang.String-) ile ayarlayın.  
4. Sunumu, [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) metodu ile PPTX dosyası olarak kaydedin.

Aşağıdaki örnek tam bir programdır. [Installation](/slides/tr/java/installation/) bölümündeki Maven projesinde, *src/main/java/HelloSlides.java* olarak kaydedin ve `mvn compile exec:java` komutunu çalıştırın.

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // Bir sunum oluştur. zaten bir boş slayt içerir.
        Presentation presentation = new Presentation();
        try {
            // İlk slaytı al.
            ISlide slide = presentation.getSlides().get_Item(0);

            // Bir bulut şekli ekle ve içine metin koy.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // Sunumu PPTX dosyası olarak kaydet.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Bulut şeklinin sol üst köşesi, slaydın sol kenarından 20 puan ve üst kenarından 20 puan uzakta olup, şekil 200 puan genişliğinde ve 80 puan yüksekliğindedir. Program, bulutu ve metnini içeren tek bir slayta sahip *new_presentation.pptx* dosyasını kaydeder. Lisans olmadan, Aspose.Slides her kaydettiği slayta bir deneme filigranı ekler; ayrıntılar için [Licensing](/slides/tr/java/licensing/) bölümüne bakın.

Sonuç:

![The new presentation](new_presentation.png)

## **SSS**

### Yeni bir sunumu hangi biçimlerde kaydedebilirim?

Yeni bir sunumu [PPTX, PPT ve ODP](/slides/tr/java/save-presentation/) biçimlerinde kaydedebilir ve [PDF](/slides/tr/java/convert-powerpoint-to-pdf/), [XPS](/slides/tr/java/convert-powerpoint-to-xps/), [HTML](/slides/tr/java/convert-powerpoint-to-html/), [SVG](/slides/tr/java/render-a-slide-as-an-svg-image/) ve [görseller](/slides/tr/java/convert-powerpoint-to-png/) gibi diğer biçimlere aktarabilirsiniz.

### Şablondan (POTX/POTM) başlayıp normal bir PPTX olarak kaydedebilir miyim?

Evet. Şablonu yükleyip istediğiniz biçimde kaydedin; POTX/POTM/PPTM ve benzeri biçimler [desteklenir](/slides/tr/java/supported-file-formats/).

### Sunum oluştururken slayt boyutu/En‑boy oranını nasıl kontrol ederim?

Slayt boyutunu ([slide size](/slides/tr/java/slide-size/)) ayarlayın (4:3, 16:9 gibi ön ayarlar veya özel boyutlar) ve içeriğin nasıl ölçekleneceğini seçin.

### Boyutlar ve koordinatlar hangi birimlerde ölçülür?

Puan cinsinden: 1 inç 72 birime eşittir.

### Bellek kullanımını azaltmak için çok büyük (birçok medya dosyası içeren) sunumları nasıl yönetirim?

[BLOB yönetim stratejileri](/slides/tr/java/manage-blob/) kullanın, geçici dosyalarla bellek içi depolamayı sınırlayın ve tamamen bellek içi akışlar yerine dosya tabanlı iş akışlarını tercih edin.

### Sunumları paralel olarak oluşturabilir/kaydedebilir miyim?

Aynı [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) örneği üzerine [multiple threads](/slides/tr/java/multithreading/) üzerinden işlem yapamazsınız. Her iş parçacığı veya süreç için ayrı, izole örnekler çalıştırın.

### Deneme filigranı ve sınırlamaları nasıl kaldırırım?

[Apply a license](/slides/tr/java/licensing/) bir kez süreç başına uygulayın. Lisans XML'i değiştirilmemeli ve birden fazla iş parçacığı varsa lisans ayarı senkronize edilmelidir.

### Oluşturduğum PPTX'i dijital olarak imzalayabilir miyim?

Evet. [Digital signatures](/slides/tr/java/digital-signature-in-powerpoint/) (ekleme ve doğrulama) sunumlar için desteklenir.

### Oluşturulan sunumlarda makrolar (VBA) destekleniyor mu?

Evet. [create/edit VBA projects](/slides/tr/java/presentation-via-vba/) yapabilir ve PPTM/PPSM gibi makro etkin dosyaları kaydedebilirsiniz.