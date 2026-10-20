---
title: Android'de Sunum Slaytlarındaki Şekilleri Yeniden Boyutlandır
type: docs
weight: 130
url: /tr/androidjava/resizing-shapes-on-slide/
aliases:
  /androidjava/re-sizing-shapes-on-slide/
keywords:
- şekil yeniden boyutlandır
- şekil boyutunu değiştir
- PowerPoint
- OpenDocument
- sunum
- Android
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile PowerPoint ve OpenDocument slaytlarında şekilleri kolayca yeniden boyutlandırın—slayt düzeni ayarlamalarını otomatikleştirin ve verimliliği artırın."
---
## **Genel Bakış**

Bir sunumun slayt boyutunu değiştirdiğinizde, şekilleri yeni boyutlara uydurmak için yeniden boyutlandırmanız ve konumlarını yeniden ayarlamanız gerekebilir. Bu makale, şekilleri manuel olarak nasıl ölçeklendireceğinizi ve slaytlardaki, ana slaytlardaki ve düzenlerdeki tabloları nasıl işleyeceğinizi gösterir.

## **Şekilleri Yeniden Boyutlandır**

Her bir şeklin göreli konumunu ve boyutunu korumak için, yatay koordinatlarını ve genişliğini yeni slayt genişliğinin orijinal genişliğe oranı ile çarpın. Aynı şekilde, dikey koordinatlarını ve yüksekliğini ilgili yükseklik oranı ile çarpın.

İlk örnek, slaytlarında tablo bulunmayan bir sunumu yükler, slayt boyutunu A4 olarak değiştirir ve sonucu kaydeder. Ölçeklemeyi sonraki döngünün kontrol etmesi için [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-int-int-) ile [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/#DoNotScale) kullanır. Oranlar birimsizdir; şekil konumları ve boyutları puan cinsinden ölçülür. Farklı genişlik ve yükseklik oranları şekilleri bozabilir ve bir şeklin boyutlarını değiştirmek yazı tipi boyutlarını ölçeklendirmez.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Bağımsız yatay ve dikey ölçek faktörlerini hesaplayın.
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
Tablolar ayrı bir işlem gerektirir: tablonun genel genişlik ve yüksekliğini atamak yerine sütun genişliklerini ve satır yüksekliklerini ölçeklendirin. Hücre içeriği daha fazla alan gerektiriyorsa satır yükseklikleri istenenden daha büyük kalabilir.
{{% /alert %}}

İkinci örnek, tabloları destekler ve yeniden boyutlandırılmış sunumu kaydetmeden önce ana slaytlardaki, düzenlerdeki ve bireysel slaytlardaki şekilleri işler. Yardımcısı, her bir [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) öğesini sütun genişliklerini [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) ile ve minimum satır yüksekliğini [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-) ile ölçeklendirerek işler. Ardından, tablonun genel boyutlarını ayrı ayrı ölçeklendirmeden konumunu ölçeklendirir.
```java
import com.aspose.slides.*;

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
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    ShapeResizer resizer = new ShapeResizer();

    // Ana slaytlarda ve düzenlerde tanımlı şekilleri ve ayrıca bireysel slaytları yeniden boyutlandırın.
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

**Bir slaytı yeniden boyutlandırdıktan sonra şekiller neden bozuluyor veya kesiliyor?**

Şekilleri ölçeklendirmeden slayt boyutunu değiştirirseniz, şekiller orijinal konum ve boyutlarını korur ve slayt dışına taşabilir. Genişlik ve yüksekliği farklı oranlarla ölçeklemek de şekilleri bozabilir.

**Sağlanan kod tüm şekil tipleri için çalışır mı?**

İlk örnek, şekil sınırlarını doğrudan değiştirir ve tabloları olmayan slaytlar için tasarlanmıştır. İkinci örnek ise tabloları ayrı olarak işler. Sonuçta ortaya çıkan düzeni, özellikle metin ve tabloları kontrol edin; çünkü bu örnekler yazı tipi boyutlarını ölçeklendirmez ve tablo içeriği satır yüksekliğini sınırlayabilir.

**Bir slaytı yeniden boyutlandırırken tabloları nasıl yeniden boyutlandırabilirim?**

Sütun genişliklerini genişlik oranı ile, minimum satır yüksekliklerini ise yükseklik oranı ile ölçeklendirin, ardından tablonun genel boyutlarını ayrı ayrı ölçeklendirmeden konumunu ölçeklendirin; bu, ikinci örnekte gösterildiği gibidir.

**Bu yeniden boyutlandırma ana slaytlar ve düzen slaytları için de çalışır mı?**

Evet. İkinci örnek, [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) ve her bir ana slaydın [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/#getLayoutSlides--) üzerinden döner ve şekillerine aynı yeniden boyutlandırma mantığını uygular.

**Bir slaydın yönünü (dikey/yatay) yeniden boyutlandırma ile birlikte değiştirebilir miyim?**

Evet. Slayt boyutunu değiştirdikten ve hedef boyutları okumadan önce [SlideSize.setOrientation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setOrientation-int-) çağırın; böylece ölçek faktörleri son yönelime göre ayarlanır.

**Ayarlayabileceğim slayt boyutu için bir sınırlama var mı?**

[SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) ile özel slayt boyutları belirtebilirsiniz. Desteklenen boyutlar, sunum formatına ve dosyayı açan uygulamaya da bağlıdır.

**Sabit en‑boy oranına sahip şekillerin bozulmasını nasıl önleyebilirim?**

Genişlik ve yükseklik için aynı ölçek faktörünü kullanın. Orijinal düzeni yeni slayt boyutlarına sığdırmak için, her iki boyut ve konum için genişlik ve yükseklik oranlarından daha küçük olanı kullanın. Bu, oranları korur ancak bir kenarda kullanılmayan boşluk bırakabilir.