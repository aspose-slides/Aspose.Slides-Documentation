---
title: Node.js'te Sunum Slaytlarındaki Şekilleri Yeniden Boyutlandır
type: docs
weight: 130
url: /tr/nodejs-java/resizing-shapes-on-slide/
aliases:
  - /nodejs-java/re-sizing-shapes-on-slide/
  - /tr/nodejs-java/re-sizing-shapes-on-slide/
keywords:
- şekil yeniden boyutlandırma
- şekil boyutunu değiştir
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Java aracılığıyla Node.js için Aspose.Slides ile PowerPoint ve OpenDocument slaytlarındaki şekilleri kolayca yeniden boyutlandırın—slayt düzeni ayarlamalarını otomatikleştirin ve verimliliği artırın."
---
## **Genel Bakış**

Bir sunumun slayt boyutunu değiştirdiğinizde, şekilleri yeni boyutlara sığdırmak için yeniden boyutlandırmanız ve konumlarını yeniden ayarlamanız gerekebilir. Bu makale, şekilleri manuel olarak nasıl ölçeklendireceğinizi ve slaytlar, ana slaytlar ve yerleşimler üzerindeki tablolarla nasıl başa çıkılacağını gösterir.

## **Şekilleri Yeniden Boyutlandır**

Her şeklin göreceli konumunu ve boyutunu korumak için, yatay koordinatlarını ve genişliğini yeni slayt genişliği ile orijinal genişlik arasındaki oranla çarpın. Dikey koordinatları ve yüksekliğini ise buna karşılık gelen yükseklik oranıyla çarpın.

İlk örnek, slaytlarında tablo bulunmayan bir sunumu yükler, slayt boyutunu A4 olarak değiştirir ve sonucu kaydeder. Ölçeklemeyi sonraki döngünün kontrol etmesi için [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) yöntemini [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/#DoNotScale) ile birlikte kullanır. Oranlar birimsizdir; şekil konumları ve boyutları puan cinsinden ölçülür. Farklı genişlik ve yükseklik oranları şekilleri bozabilir ve bir şeklin boyutlarını değiştirmek yazı tipi boyutlarını ölçeklendirmez.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("sample.pptx");
try {
    // Bağımsız yatay ve dikey ölçek faktörlerini hesaplayın.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
            shape.setX(java.newFloat(shape.getX() * widthRatio));
            shape.setY(java.newFloat(shape.getY() * heightRatio));
        }
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Tablolar ayrı bir işlem gerektirir: tablonun toplam genişlik ve yüksekliğini atamak yerine sütun genişliklerini ve satır yüksekliklerini ölçeklendirin. Hücre içeriği daha fazla alan gerektiriyorsa satır yüksekliği istenenden daha büyük kalabilir.
{{% /alert %}}

İkinci örnek tabloları destekler ve yeniden boyutlandırılmış sunumu kaydetmeden önce ana slaytlarda, yerleşimlerde ve bireysel slaytlarda şekilleri işler. Yardımcısı, her [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) öğesini sütun genişliklerini [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth) ve minimum satır yüksekliklerini [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight) ile ölçeklendirerek ele alır. Ardından, tablonun genel boyutlarını ayrı ayrı ölçeklendirmeden konumunu ölçeklendirir.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function resizeShapes(shapes, widthRatio, heightRatio) {
    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        const shape = shapes.get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            const table = shape;
            // Tablo boyutları sütun genişlikleri ve satır yükseklikleri ile kontrol edilir.
            for (let columnIndex = 0; columnIndex < table.getColumns().size(); columnIndex++) {
                const column = table.getColumns().get_Item(columnIndex);
                column.setWidth(column.getWidth() * widthRatio);
            }

            for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
                const row = table.getRows().get_Item(rowIndex);
                row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
            }
        }
        else {
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
        }

        shape.setX(java.newFloat(shape.getX() * widthRatio));
        shape.setY(java.newFloat(shape.getY() * heightRatio));
    }
}

const presentation = new slides.Presentation("sample.pptx");
try {
    // Bağımsız yatay ve dikey ölçek faktörlerini hesaplayın.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    // Ana slaytlarda ve yerleşimlerde tanımlı şekilleri ve ayrıca bireysel slaytları yeniden boyutlandırın.
    for (let masterIndex = 0; masterIndex < presentation.getMasters().size(); masterIndex++) {
        const master = presentation.getMasters().get_Item(masterIndex);
        resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (let layoutSlideIndex = 0; layoutSlideIndex < master.getLayoutSlides().size(); layoutSlideIndex++) {
            const layoutSlide = master.getLayoutSlides().get_Item(layoutSlideIndex);
            resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **SSS**

**Slaytı yeniden boyutlandırdıktan sonra şekiller neden bozulur veya kesilir?**

Eğer slayt boyutunu şekilleri ölçeklendirmeden değiştirirseniz, şekiller orijinal konum ve boyutlarını korur ve slayt dışına taşabilir. Genişlik ve yüksekliği farklı oranlarla ölçeklendirmek de şekilleri bozabilir.

**Sağlanan kod tüm şekil türleri için çalışıyor mu?**

İlk örnek şekil sınırlarını doğrudan değiştirir ve tabloları olmayan slaytlar için tasarlanmıştır. İkinci örnek tabloları ayrı olarak işler. Sonuç düzenini, özellikle metin ve tabloları kontrol edin; çünkü bu örnekler yazı tipi boyutlarını ölçeklendirmez ve tablo içeriği satır yüksekliklerini kısıtlayabilir.

**Bir slaytı yeniden boyutlandırırken tabloları nasıl yeniden boyutlandırırım?**

Sütun genişliklerini genişlik oranı ile, minimum satır yüksekliklerini ise yükseklik oranı ile ölçeklendirin ve ardından tablonun konumunu ölçeklendirin; bu ikinci örnekte gösterilmiştir.

**Bu yeniden boyutlandırma ana slaytlar ve yerleşim slaytları için de çalışır mı?**

Evet. İkinci örnek, [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) ve her bir ana slaydın [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getLayoutSlides) üzerinden döner ve şekillerine aynı yeniden boyutlandırma mantığını uygular.

**Yeniden boyutlandırma sırasında bir slaydın yönünü (dikey/yatay) değiştirebilir miyim?**

Evet. Slayt boyutunu değiştirdikten ve hedef boyutları okumadan önce [SlideSize.setOrientation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setOrientation) metodunu çağırın; böylece ölçek faktörleri son yönelimi yansıtır.

**Ayarlayabileceğim slayt boyutu için bir sınırlama var mı?**

[SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) ile özel slayt boyutları belirtebilirsiniz. Desteklenen boyutlar ayrıca sunum formatına ve dosyayı açmak için kullanılan uygulamaya bağlıdır.

**Sabit en-boy oranına sahip şekillerin bozulmasını nasıl önleyebilirim?**

Genişlik ve yükseklik için aynı ölçek faktörünü kullanın. Orijinal düzeni yeni slayt boyutlarına sığdırmak için, hem boyutlar hem de konumlar için genişlik ve yükseklik oranlarından daha küçüğünü kullanın. Bu, oranları korur ancak bir kenarda kullanılmayan boşluk bırakabilir.