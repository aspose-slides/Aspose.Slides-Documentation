---
title: Sunum Slaytlarındaki Şekilleri Yeniden Boyutlandırma
type: docs
weight: 110
url: /tr/java/re-sizing-shapes-on-slide/
keywords:
- şekil yeniden boyutlandır
- şekil boyutunu değiştirme
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint ve OpenDocument slaytlarındaki şekilleri kolayca yeniden boyutlandırın—slayt düzeni ayarlamalarını otomatikleştirin ve üretkenliği artırın."
---
## **Genel Bakış**

Aspose.Slides for Java müşterilerinin en sık sorduğu sorulardan biri, slayt boyutu değiştiğinde şekillerin yeniden boyutlandırılması ve verinin kesilmemesidir. Bu kısa teknik makale bu işlemin nasıl yapılacağını gösterir.

## **Şekilleri Yeniden Boyutlandır**

Slayt boyutu değiştiğinde şekillerin kaymasını önlemek için her şeklin konum ve boyutlarını yeni slayt düzenine uygun şekilde güncelleyin.

```java
import com.aspose.slides.*;

// Sunum dosyasını yükle.
Presentation presentation = new Presentation("sample.ppt");
try {
    // Orijinal slayt boyutunu al.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Mevcut şekilleri ölçeklendirmeden slayt boyutunu değiştir.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Yeni slayt boyutunu al.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Her slayttaki şekilleri yeniden boyutlandır ve yeniden konumlandır.
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
            // Şekil boyutunu ölçeklendir.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Şekil konumunu ölçeklendir.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" %}} 
Tabloların özel bir işleme ihtiyacı yoktur: bir tablonun genişlik ve yüksekliğini ayarlamak, sütun ve satırlarını orantılı olarak yeniden ölçeklendirir, bu yüzden satır yüksekliklerini ve sütun genişliklerini tekrar ölçeklendirmek oranı iki kez uygulamış olur.
{{% /alert %}} 

Yukarıdaki kod yalnızca slaytlardaki şekilleri değiştirir. Ana slaytlar ve düzen slaytları kendi şekillerini tutar, bu nedenle tüm sunumun yeni slayt boyutuna uyması için onları da ölçeklendirin:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Orijinal slayt boyutunu al.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Mevcut şekilleri ölçeklendirmeden slayt boyutunu değiştir.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // Yeni slayt boyutunu al.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    for (IMasterSlide master : presentation.getMasters()) {
        for (IShape shape : master.getShapes()) {
            // Şekil boyutunu ölçeklendir.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Şekil konumunu ölçeklendir.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // Şekil boyutunu ölçeklendir.
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // Şekil konumunu ölçeklendir.
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // Şekil boyutunu ölçeklendir.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Şekil konumunu ölçeklendir.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **SSS**

### Bir slaytı yeniden boyutlandırdıktan sonra şekiller neden bozulur veya kesilir?

Bir slaytı yeniden boyutlandırdığınızda, ölçek açıkça değiştirilmedikçe şekiller orijinal konum ve boyutlarını korur. Bu, içeriğin kırpılmasına veya şekillerin hizalanmamasına neden olabilir.

### Sağlanan kod tüm şekil türleri için çalışıyor mu?

Evet. Yükseklik ve genişlik ayarı metin kutuları, görüntüler, grafikler ve tablolar için aynı şekilde çalışır.

### Bir slaytı yeniden boyutlandırırken tabloları nasıl ölçeklendiririm?

Tablo şeklinin kendisini, diğer tüm şekiller gibi ölçeklendirin. Satır ve sütunlar orantılı olarak izler, bu yüzden onları daha sonra tekrar ölçeklendirmeyin.

### Bu yeniden boyutlandırma ana slaytlar ve düzen slaytları için de işe yarar mı?

Evet, ancak tutarlılığı sağlamak için [Ustalar](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getMasters--) ve [Düzen slaytları](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getLayoutSlides--) üzerinden de döngü yapıp şekillerine aynı ölçekleme mantığını uygulamalısınız.

### Bir slaytın yönünü (dikey/yatay) yeniden boyutlandırma ile birlikte değiştirebilir miyim?

Evet. Yönü değiştirmek için [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidesize/#setOrientation-int-) yöntemini kullanabilirsiniz. Düzeni korumak için ölçekleme mantığını buna göre ayarladığınızdan emin olun.

### Ayarlayabileceğim slayt boyutu için bir sınırlama var mı?

Aspose.Slides özelleştirilmiş boyutları destekler, ancak çok büyük boyutlar performansı etkileyebilir veya bazı PowerPoint sürümleriyle uyumluluğu zorlayabilir.

### Sabit en-boy oranına sahip şekillerin bozulmasını nasıl önleyebilirim?

Şekli ölçeklendirmeden önce `getAspectRatioLocked` metodunu kontrol edebilirsiniz. Oran kilitli ise, genişlik ve yüksekliği ayrı ayrı ölçeklendirmek yerine orantılı olarak ayarlayın.