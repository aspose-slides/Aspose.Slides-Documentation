---
title: Android'de Sunum Slaytlarında Şekilleri Yeniden Boyutlandır
type: docs
weight: 130
url: /tr/androidjava/resizing-shapes-on-slide/
aliases:
  - /androidjava/sekil-boyutlandirma-slide/
  - /tr/androidjava/re-sizing-shapes-on-slide/
keywords:
- şekil boyutlandırma
- şekil boyutunu değiştirme
- PowerPoint
- OpenDocument
- sunum
- Android
- Aspose.Slides
description: "Aspose.Slides for Android via Java kullanarak PowerPoint ve OpenDocument slaytlarındaki şekilleri kolayca yeniden boyutlandırın—slayt düzeni ayarlamalarını otomatikleştirin ve verimliliği artırın."
---
## **Genel Bakış**

Bir sunumun slayt boyutunu değiştirdiğinizde, yeni ölçülere sığması için şekilleri yeniden boyutlandırmanız ve konumlandırmanız da gerekebilir. Bu makale, şekilleri manuel olarak nasıl ölçekleyeceğinizi ve slaytlar, ana slaytlar ve düzenlerdeki tablolarla nasıl başa çıkacağınızı gösterir.

## **Şekilleri Yeniden Boyutlandır**

Her şeklin göreceli konumunu ve boyutunu korumak için, yatay koordinatlarını ve genişliğini yeni slayt genişliği ile orijinal genişlik arasındaki orana çarpın. Aynı şekilde, dikey koordinatlarını ve yüksekliğini yükseklik oranı ile çarpın.

İlk örnek, slaytlarında tablo bulunmayan bir sunumu yükler, slayt boyutunu A4 olarak değiştirir ve sonucu kaydeder. Sonraki döngünün ölçeklemeyi kontrol etmesi için [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-int-int-) ve [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/#DoNotScale) kullanır. Oranlar birimsizdir; şekil konumları ve boyutları puan cinsinden ölçülür. Farklı genişlik ve yükseklik oranları şekilleri bozabilir ve bir şeklin boyutlarını değiştirmek yazı tipi boyutlarını ölçeklemez.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Bağımsız yatay ve düşey ölçek faktörlerini hesaplayın.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            shape.setWidth(shape.getWidth() * widthRatio);
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Tablolar ayrı bir işlem gerektirir: tablonun genel genişlik ve yüksekliğini atamak yerine sütun genişliklerini ve satır yüksekliklerini ölçekleyin. Hücre içeriği daha fazla alana ihtiyaç duyarsa satır yüksekliği istenenden daha büyük kalabilir.
{{% /alert %}}

İkinci örnek tabloları destekler ve yeniden boyutlandırılmış sunumu kaydetmeden önce hem ana slaytlarda ve düzenlerde hem de bireysel slaytlarda şekilleri işler. Yardımcısı, her [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) öğesini sütun genişliklerini [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) ve minimum satır yüksekliklerini [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-) ile ölçekleyerek işler. Ardından, tablonun genel boyutlarını ayrı ayrı ölçeklendirmeden konumunu ölçeklendirir.
```java
import com.aspose.slides.*;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // Tablonun boyutları sütun genişlikleri ve satır yükseklikleri tarafından kontrol edilir.
                for (IColumn column : table.getColumns()) {
                    column.setWidth(column.getWidth() * widthRatio);
                }

                for (IRow row : table.getRows()) {
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
            }
            else {
                shape.setWidth(shape.getWidth() * widthRatio);
                shape.setHeight(shape.getHeight() * heightRatio);
            }

            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }
}

Presentation presentation = new Presentation("sample.pptx");
try {
    // Bağımsız yatay ve düşey ölçek faktörlerini hesaplayın.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    ShapeResizer resizer = new ShapeResizer();

    // Ana slaytlarda ve düzenlerde tanımlı şekilleri, ayrıca bireysel slaytlardaki şekilleri yeniden boyutlandırın.
    for (IMasterSlide master : presentation.getMasters()) {
        resizer.resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            resizer.resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        resizer.resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **SSS**

**Bir slayt yeniden boyutlandırıldıktan sonra şekiller neden bozulur veya kesilir?**

Slayt boyutunu şekilleri ölçeklendirmeden değiştirirseniz, şekiller orijinal konum ve boyutlarını korur ve slayt dışına taşabilir. Genişlik ve yüksekliği farklı oranlarla ölçeklemek de şekilleri bozabilir.

**Sağlanan kod tüm şekil türleri için çalışır mı?**

İlk örnek şekil sınırlarını doğrudan değiştirir ve tablosuz slaytlar için tasarlanmıştır. İkinci örnek tabloları ayrı olarak işler. Özellikle metin ve tabloları kontrol edin, çünkü bu örnekler yazı tipi boyutlarını ölçeklendirmez ve tablo içeriği satır yüksekliğini kısıtlayabilir.

**Bir slaytı yeniden boyutlandırırken tabloları nasıl yeniden boyutlandırırım?**

Sütun genişliklerini genişlik oranıyla, minimum satır yüksekliklerini yükseklik oranıyla ölçekleyin, ardından tablonun konumunu ölçeklendirin; bu, ikinci örnekte gösterildiği gibidir.

**Bu yeniden boyutlandırma ana slaytlar ve düzen slaytları için çalışır mı?**

Evet. İkinci örnek, [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) ve her bir ana slaydın [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/#getLayoutSlides--) üzerinden geçerek şekillerine aynı yeniden boyutlandırma mantığını uygular.

**Yeniden boyutlandırma ile birlikte bir slaydın yönünü (dikey/yatay) değiştirebilir miyim?**

Evet. Slayt boyutunu değiştirdikten ve hedef ölçüleri okumadan önce [SlideSize.setOrientation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setOrientation-int-) çağırın, böylece ölçek faktörleri nihai yönelime göre ayarlanır.

**Ayarlayabileceğim slayt boyutu için bir limit var mı?**

Özel slayt boyutlarını [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) ile belirtebilirsiniz. Desteklenen boyutlar ayrıca sunum formatına ve dosyayı açan uygulamaya bağlıdır.

**Sabit en‑boy oranına sahip şekillerin bozulmasını nasıl önleyebilirim?**

En ve yükseklik için aynı ölçek faktörünü kullanın. Orijinal düzeni yeni slayt boyutlarına sığdırmak için genişlik ve yükseklik oranlarından daha küçüğünü her iki boyut ve konum için kullanın. Bu, oranları korur ancak bir kenarda kullanılmayan boşluk bırakabilir.