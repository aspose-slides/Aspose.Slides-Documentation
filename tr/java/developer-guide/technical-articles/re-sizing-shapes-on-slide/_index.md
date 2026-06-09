---
title: Sunum Slaytlarında Şekilleri Yeniden Boyutlandırma
type: docs
weight: 110
url: /tr/java/re-sizing-shapes-on-slide/
keywords:
- şekli yeniden boyutlandır
- şekil boyutunu değiştirme
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint ve OpenDocument slaytlarındaki şekilleri kolayca yeniden boyutlandırın—slayt düzeni ayarlamalarını otomatikleştirin ve verimliliği artırın."
---
## **Genel Bakış**

Aspose.Slides for Java müşterilerinden en sık gelen sorulardan biri, slayt boyutu değiştiğinde verilerin kesilmemesi için şekillerin nasıl yeniden boyutlandırılacağıdır. Bu kısa teknik makale bunu nasıl yapacağınızı gösterir.

## **Şekilleri Yeniden Boyutlandırma**

Slayt boyutu değiştiğinde şekillerin hizalanmasının bozulmasını önlemek için, her şeklin konum ve boyutlarını yeni slayt düzenine uygun şekilde güncelleyin.

```java
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

    // Her slaytta şekilleri yeniden boyutlandır ve konumlarını değiştir.
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
            // Şekil boyutunu ölçekle.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Şekil konumunu ölçekle.
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

{{% alert color="primary" %}} 
Eğer bir slayt bir tablo içeriyorsa, yukarıdaki kod doğru çalışmaz. Bu durumda tablodaki her hücre yeniden boyutlandırılmalıdır.
{{% /alert %}} 

Tablolar içeren slaytları yeniden boyutlandırmak için aşağıdaki kodu kullanın. Tablolar için genişlik veya yükseklik ayarlamak özel bir durumdur: tablonun genel boyutunu değiştirmek amacıyla her satır yüksekliğini ve sütun genişliğini ayrı ayrı ayarlamanız gerekir.

```java
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
            // Şekil boyutunu ölçekle.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Şekil konumunu ölçekle.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // Şekil boyutunu ölçekle.
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // Şekil konumunu ölçekle.
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // Şekil boyutunu ölçekle.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Şekil konumunu ölçekle.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                for (int i = 0; i < table.getRows().size(); i++) {
                    IRow row = table.getRows().get_Item(i);
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
                for (int j = 0; j < table.getColumns().size(); j++) {
                    IColumn column = table.getColumns().get_Item(j);
                    column.setWidth(column.getWidth() * widthRatio);
                }
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **SSS**

**Bir slaytı yeniden boyutlandırdıktan sonra şekiller neden bozuluyor veya kesiliyor?**

Bir slaytı yeniden boyutlandırdığınızda, ölçek açıkça değiştirilmedikçe şekiller orijinal konum ve boyutlarını korur. Bu durum içeriğin kırpılmasına veya şekillerin hizalanmasının bozulmasına neden olabilir.

**Sağlanan kod tüm şekil türleri için çalışıyor mu?**

Temel örnek çoğu şekil türü (metin kutuları, resimler, grafikler vb.) için çalışır. Ancak tablolar için satır ve sütunları ayrı ayrı ele almanız gerekir; çünkü bir tablonun yüksekliği ve genişliği bireysel hücrelerin boyutlarıyla belirlenir.

**Bir slaytı yeniden boyutlandırırken tabloları nasıl yeniden boyutlandırırım?**

Tablonun tüm satır ve sütunlarını dolaşmalı ve ikinci kod örneğinde gösterildiği gibi yüksekliğini ve genişliğini orantılı olarak yeniden boyutlandırmalısınız.

**Bu yeniden boyutlandırma, ana slaytlar ve yerleşim slaytları için de işe yarar mı?**

Evet, ancak tutarlılığı sağlamak için [Üst slaytlar](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getMasters--) ve [Yerleşim slaytları](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getLayoutSlides--) üzerinden de döngü yapmalı ve şekillerine aynı ölçekleme mantığını uygulamalısınız.

**Bir slaytın yönünü (dikey/yatay) yeniden boyutlandırma ile birlikte değiştirebilir miyim?**

Evet. Yönü değiştirmek için [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidesize/#setOrientation-int-) yöntemini kullanabilirsiniz. Düzeni korumak için ölçekleme mantığını buna göre ayarladığınızdan emin olun.

**Ayarlayabileceğim bir slayt boyutu sınırı var mı?**

Aspose.Slides özel boyutları destekler, ancak çok büyük boyutlar performansı etkileyebilir veya bazı PowerPoint sürümleriyle uyumluluğu azaltabilir.

**Sabitleştirilmiş en-boy oranına sahip şekillerin bozulmasını nasıl önleyebilirim?**

Ölçeklendirmeden önce şeklin `getAspectRatioLocked` metodunu kontrol edebilirsiniz. Eğer oran kilitli ise, genişliği ve yüksekliği ayrı ayrı ölçeklendirmek yerine orantılı olarak ayarlayın.