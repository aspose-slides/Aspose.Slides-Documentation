---
title: Java'da Sunum Slaytlarındaki Şekilleri Yeniden Boyutlandırma
type: docs
weight: 130
url: /tr/java/resizing-shapes-on-slide/
aliases:
  - /tr/java/re-sizing-shapes-on-slide/
keywords:
- şekli yeniden boyutlandır
- şekil boyutunu değiştir
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint ve OpenDocument slaytlarındaki şekilleri kolayca yeniden boyutlandırın—slayt düzeni ayarlamalarını otomatikleştirin ve üretkenliği artırın."
---
## **Genel Bakış**

Bir sunumun slayt boyutunu değiştirdiğinizde, şekillerin yeni boyutlara uyması için yeniden boyutlandırılması ve konumlandırılması gerekebilir. Bu makale, şekilleri manuel olarak nasıl ölçeklendireceğinizi ve slaytlarda, ana slaytlarda ve düzenlerdeki tabloları nasıl yöneteceğinizi gösterir.

## **Şekilleri Yeniden Boyutlandırma**

Her şeklin göreceli konumunu ve boyutunu korumak için, yatay koordinatlarını ve genişliğini yeni slayt genişliğinin orijinal genişliğe oranı ile çarpın. Dikey koordinatları ve yüksekliğini ise ilgili yükseklik oranı ile uygulayın.

İlk örnek, slaytlarında tablo bulunmayan bir sunumu yükler, slayt boyutunu A4 olarak değiştirir ve sonucu kaydeder. Sonraki döngünün ölçeklendirmeyi kontrol etmesi için [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-int-int-) ile [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/#DoNotScale) kullanır. Oranlar birimsizdir; şekil konumları ve boyutları puan cinsinden ölçülür. Farklı genişlik ve yükseklik oranları şekilleri bozulmaya neden olabilir ve bir şeklin boyutlarını değiştirmek yazı tipi boyutlarını ölçeklendirmez.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Bağımsız yatay ve dikey ölçek faktörlerini hesaplayın.
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
Tablolar ayrı bir işlem gerektirir: tablonun toplam genişlik ve yüksekliğini atamak yerine sütun genişliklerini ve satır yüksekliklerini ölçeklendirin. Hücre içeriği daha fazla alan gerektiriyorsa satır yükseklikleri istenenden daha büyük kalabilir.
{{% /alert %}}

İkinci örnek tabloları destekler ve yeniden boyutlandırılmış sunumu kaydetmeden önce ana slaytlardaki, düzenlerdeki ve tek tek slaytlardaki şekilleri işler. Yardımcısı, her [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) öğesini sütun genişliklerini [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) ve minimum satır yüksekliklerini [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-) ile ölçeklendirerek işler. Daha sonra tablonun konumunu, toplam boyutlarını ayrı ayrı ölçeklendirmeden ölçeklendirir.
```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // Tablo boyutları sütun genişlikleri ve satır yükseklikleriyle kontrol edilir.
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
    // Bağımsız yatay ve dikey ölçek faktörlerini hesaplayın.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    ShapeResizer resizer = new ShapeResizer();

    // Ana slaytlarda ve düzenlerde tanımlı şekilleri ve bireysel slaytları yeniden boyutlandırın.
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

**Slaytı yeniden boyutlandırdıktan sonra şekiller neden bozuluyor veya kesiliyor?**  
Slayt boyutunu şekilleri ölçeklendirmeden değiştirirseniz, şekiller orijinal konumlarını ve boyutlarını korur ve slayt dışına taşabilir. Genişlik ve yüksekliği farklı oranlarla ölçeklendirmek de şekilleri bozabilir.

**Sağlanan kod tüm şekil türleri için çalışır mı?**  
İlk örnek şekil sınırlarını doğrudan değiştirir ve tablo içermeyen slaytlar için tasarlanmıştır. İkinci örnek tabloları ayrı olarak ele alır. Sonuçtaki düzeni, özellikle metin ve tabloları kontrol edin; çünkü bu örnekler yazı tipi boyutlarını ölçeklendirmez ve tablo içeriği satır yüksekliğini kısıtlayabilir.

**Bir slaytı yeniden boyutlandırırken tabloları nasıl yeniden boyutlandırırım?**  
Sütun genişliklerini genişlik oranı, minimum satır yüksekliklerini yükseklik oranı ile ölçeklendirin, ardından tablonun konumunu ölçeklendirin; bu, ikinci örnekte gösterilmiştir.

**Bu yeniden boyutlandırma ana slaytlar ve düzen slaytları için çalışır mı?**  
Evet. İkinci örnek, [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) ve her bir ana slaydın [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/#getLayoutSlides--) üzerinden döner ve şekillerine aynı yeniden boyutlandırma mantığını uygular.

**Yeniden boyutlandırmayla birlikte bir slaytın yönünü (dikey/yatay) değiştirebilir miyim?**  
Evet. Slayt boyutunu değiştirdikten ve hedef boyutları okumadan önce [SlideSize.setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setOrientation-int-) metodunu çağırın; böylece ölçek çarpanları son yönelime göre ayarlanır.

**Ayarlayabileceğim slayt boyutu için bir limit var mı?**  
[SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-float-float-int-) ile özel slayt boyutları belirleyebilirsiniz. Desteklenen boyutlar ayrıca sunum formatına ve dosyayı açmak için kullanılan uygulamaya bağlıdır.

**Sabit en‑boy oranına sahip şekillerin bozulmasını nasıl önleyebilirim?**  
Genişlik ve yükseklik için aynı ölçek çarpanını kullanın. Orijinal düzeni yeni slayt boyutlarına sığdırmak için, hem boyutlar hem de konumlar için genişlik ve yükseklik oranlarından en küçüğünü kullanın. Bu, oranları korur ancak bir kenarda kullanılmayan boşluk bırakabilir.