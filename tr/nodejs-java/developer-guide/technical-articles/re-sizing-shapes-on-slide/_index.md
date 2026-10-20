---
title: Node.js'te Sunum Slaytlarındaki Şekilleri Yeniden Boyutlandırma
type: docs
weight: 130
url: /tr/nodejs-java/resizing-shapes-on-slide/
aliases:
  /nodejs-java/re-sizing-shapes-on-slide/
keywords:
- şekil yeniden boyutlandırma
- şekil boyutunu değiştirme
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js aracılığıyla Java kullanarak PowerPoint ve OpenDocument slaytlarındaki şekilleri kolayca yeniden boyutlandırın—slayt düzeni ayarlamalarını otomatikleştirin ve verimliliği artırın."
---
## **Genel Bakış**

Bir sunumun slayt boyutunu değiştirdiğinizde, şekillerin yeni boyutlara uyması için yeniden boyutlandırılması ve konumlarının ayarlanması da gerekebilir. Bu makale, şekilleri manuel olarak nasıl ölçeklendireceğinizi ve slaytlarda, master slaytlarda ve düzenlerde tabloları nasıl ele alacağınızı gösterir.

## **Şekilleri Yeniden Boyutlandırma**

Her bir şeklin relatif konum ve boyutunu korumak için, yatay koordinatlarını ve genişliğini yeni slayt genişliği ile orijinal genişlik arasındaki oranla çarpın. Aynı şekilde, dikey koordinatlarını ve yüksekliğini de yüksekliğe ilişkin oranla çarpın.

İlk örnek, slaytlarında tablo bulunmayan bir sunumu yükler, slayt boyutunu A4 olarak değiştirir ve sonucu kaydeder. [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) metodunu [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/#DoNotScale) ile kullanır; böylece sonraki döngü ölçeklendirmeyi kontrol eder. Oranlar birimsizdir; şekil konumları ve boyutları nokta biriminde ölçülür. Farklı genişlik ve yükseklik oranları şekilleri bozabilir ve bir şeklin boyutlarını değiştirmek yazı tipi boyutlarını ölçeklendirmez.

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
Tablolar ayrı olarak ele alınmalıdır: tablo genişliği ve yüksekliği yerine sütun genişliklerini ve satır yüksekliklerini ölçeklendirin. Hücre içeriği daha fazla alan gerektiriyorsa satır yükseklikleri istenenden daha büyük kalabilir.
{{% /alert %}}

İkinci örnek tabloları destekler ve master ve düzenlerdeki şekilleri, ayrıca bireysel slaytları işleyerek yeniden boyutlandırılmış sunumu kaydeder. Yardımcısı, her bir [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) öğesini [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth) ile sütun genişliklerini ve [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight) ile minimum satır yüksekliğini ölçeklendirir. Ardından, tablonun genel boyutlarını ayrı ayrı ölçeklendirmeden konumunu ölçeklendirir.
```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function resizeShapes(shapes, widthRatio, heightRatio) {
    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        const shape = shapes.get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            const table = shape;
            // Tablo boyutları, sütun genişlikleri ve satır yükseklikleri tarafından kontrol edilir.
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

    // Master ve düzenlerde tanımlı şekilleri, ayrıca ayrı slaytları da yeniden boyutlandırın.
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

**Slayt boyutu yeniden boyutlandırıldıktan sonra şekiller neden bozulur ya da kesilir?**  
Şekilleri ölçeklendirmeden slayt boyutunu değiştirirseniz, şekiller orijinal konum ve boyutlarını korur ve slayt dışına taşabilir. Genişlik ve yüksekliği farklı oranlarla ölçeklendirmek de şekilleri bozabilir.

**Sağlanan kod tüm şekil türleri için çalışır mı?**  
İlk örnek şekil sınırlarını doğrudan değiştirir ve tabloları içermeyen slaytlar için tasarlanmıştır. İkinci örnek tabloları ayrı olarak ele alır. Sonuçta oluşan düzeni, özellikle metin ve tabloları kontrol edin; çünkü bu örnekler yazı tipi boyutlarını ölçeklendirmez ve tablo içeriği satır yüksekliğini sınırlayabilir.

**Bir slaytı yeniden boyutlandırırken tabloları nasıl yeniden boyutlandırırım?**  
İkinci örnekte gösterildiği gibi, sütun genişliklerini genişlik oranı ile, minimum satır yüksekliğini ise yükseklik oranı ile ölçeklendirin ve ardından tablo konumunu ölçeklendirin.

**Bu yeniden boyutlandırma master slaytlar ve düzen slaytları için çalışır mı?**  
Evet. İkinci örnek [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) ve her bir master'ın [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getLayoutSlides) üzerinden döner ve şekillerine aynı yeniden boyutlandırma mantığını uygular.

**Yeniden boyutlandırma sırasında slaytın yönünü (dikey/yatay) değiştirebilir miyim?**  
Evet. Slayt boyutunu değiştirdikten ve hedef boyutları okumadan önce [SlideSize.setOrientation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setOrientation) metodunu çağırın, böylece ölçek faktörleri son yönelime göre ayarlanır.

**Ayarlayabileceğim slayt boyutu için bir sınırlama var mı?**  
[SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) ile özel slayt boyutları belirleyebilirsiniz. Desteklenen boyutlar, sunum formatına ve dosyayı açan uygulamaya da bağlıdır.

**Sabit en‑boy oranına sahip şekillerin bozulmasını nasıl önleyebilirim?**  
Genişlik ve yükseklik için aynı ölçek faktörünü kullanın. Orijinal düzeni yeni slayt boyutlarına sığdırmak için, genişlik ve yükseklik oranlarından daha küçük olanını hem boyutlar hem de konumlar için kullanın. Bu, oranları korur ancak bir kenarda kullanılmamış alan bırakabilir.