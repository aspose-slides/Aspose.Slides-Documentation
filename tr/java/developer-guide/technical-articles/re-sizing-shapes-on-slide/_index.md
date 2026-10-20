---
title: Java'da Sunum Slaytlarındaki Şekilleri Yeniden Boyutlandır
type: docs
weight: 130
url: /tr/java/resizing-shapes-on-slide/
aliases:
  - /java/re-sizing-shapes-on-slide/
  - /tr/java/re-sizing-shapes-on-slide/
keywords:
- şekil yeniden boyutlandır
- şekil boyutunu değiştirme
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint ve OpenDocument slaytlarındaki şekilleri kolayca yeniden boyutlandırın—slayt düzeni ayarlamalarını otomatikleştirin ve verimliliği artırın."
---
## **Genel Bakış**

Bir sunumun slayt boyutunu değiştirdiğinizde, şekilleri yeni boyutlara sığdırmak için yeniden boyutlandırmanız ve konumlandırmanız gerekebilir. Bu makale, şekilleri manuel olarak nasıl ölçeklendireceğinizi ve slaytlardaki, ana slaytlardaki ve düzen slaytlardaki tabloları nasıl işleyeceğinizi gösterir.

## **Şekilleri Yeniden Boyutlandır**

Her şeklin göreceli konum ve boyutunu korumak için, yatay koordinatlarını ve genişliğini yeni slayt genişliği ile orijinal genişliğin oranı ile çarpın. Aynı şekilde yüksekliğe ilişkin oranı dikey koordinatları ve yüksekliği için uygulayın.

İlk örnek, slaytlarında tablo olmayan bir sunumu yükler, slayt boyutunu A4 olarak değiştirir ve sonucu kaydeder. [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-int-int-) metodunu [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/#DoNotScale) ile kullanır; böylece sonraki döngü ölçeklemeyi kontrol eder. Oranlar birimsizdir; şekil konumları ve boyutları puan cinsindendir. Farklı genişlik ve yükseklik oranları şekilleri bozabilir ve bir şeklin boyutlarını değiştirmek yazı tipi boyutlarını ölçeklendirmez.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Bağımsız yatay ve dikey ölçek faktörlerini hesapla.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

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
Tablolar ayrı bir işlem gerektirir: tablonun genel genişlik ve yüksekliğini atamak yerine sütun genişliklerini ve satır yüksekliklerini ölçeklendirin. Hücre içeriği daha fazla alan gerektiriyorsa satır yükseklikleri istenenden büyük kalabilir.
{{% /alert %}}

İkinci örnek tabloları destekler ve yeniden boyutlandırılmış sunumu kaydetmeden önce ana slaytlardaki, düzen slaytlardaki ve tek tek slaytlardaki şekilleri işler. Yardımcısı, her [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) ögesini [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) ile sütun genişliklerini ve [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-) ile minimum satır yüksekliklerini ölçeklendirerek işler. Daha sonra tablonun konumunu, genel boyutlarını ayrı ayrı ölçeklendirmeden ölçeklendirir.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // Tablo boyutları sütun genişlikleri ve satır yükseklikleri tarafından kontrol edilir.
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
    // Bağımsız yatay ve dikey ölçek faktörlerini hesapla.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    ShapeResizer resizer = new ShapeResizer();

    // Ana slaytlarda ve düzenlerde tanımlı şekilleri ve bireysel slaytları yeniden boyutlandır.
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

Şekilleri ölçeklendirmeden slayt boyutunu değiştirirseniz, şekiller orijinal konum ve boyutlarını korur ve slayt alanının dışına taşabilir. Genişlik ve yüksekliği farklı oranlarla ölçeklendirmek de şekilleri bozabilir.

**Sağlanan kod tüm şekil türleri için çalışır mı?**

İlk örnek şekil sınırlarını doğrudan değiştirir ve tabloları olmayan slaytlar için tasarlanmıştır. İkinci örnek tabloları ayrı olarak işler. Bu örnekler yazı tipi boyutlarını ölçeklendirmediği ve tablo içeriği satır yüksekliklerini kısıtlayabileceği için, özellikle metin ve tabloları içeren sonuç düzenini kontrol edin.

**Bir slaytı yeniden boyutlandırırken tabloları nasıl yeniden boyutlandırırım?**

Sütun genişliklerini genişlik oranı ile, minimum satır yüksekliklerini ise yükseklik oranı ile ölçeklendirin, ardından tablo konumunu ölçeklendirin; bu ikinci örnekte gösterilmiştir.

**Bu yeniden boyutlandırma ana slaytlar ve düzen slaytları için çalışır mı?**

Evet. İkinci örnek [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) ve her bir ana slaytın [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/#getLayoutSlides--) üzerinden geçerek şekillerine aynı yeniden boyutlandırma mantığını uygular.

**Bir slaytın yönünü (dikey/yatay) yeniden boyutlandırma ile birlikte değiştirebilir miyim?**

Evet. Slayt boyutunu değiştirdikten ve hedef boyutları okumadan önce [SlideSize.setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setOrientation-int-) metodunu çağırın; böylece ölçek faktörleri son yönelime göre ayarlanır.

**Ayarlayabileceğim slayt boyutu için bir sınırlama var mı?**

Özel slayt boyutlarını [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-float-float-int-) ile belirtebilirsiniz. Desteklenen boyutlar, sunum biçimine ve dosyayı açan uygulamaya da bağlıdır.

**Sabit en‑boy oranına sahip şekillerin bozulmasını nasıl önleyebilirim?**

Genişlik ve yükseklik için aynı ölçek faktörünü kullanın. Orijinal düzeni yeni slayt boyutlarına sığdırmak için genişlik ve yüksekli­k oranlarından daha küçüğünü her iki boyut ve konum için uygulayın. Bu orantıyı korur ancak bir kenarda kullanılmayan boşluk bırakabilir.