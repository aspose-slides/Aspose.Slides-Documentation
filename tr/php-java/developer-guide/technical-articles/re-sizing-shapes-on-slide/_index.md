---
title: PHP ile Sunum Slaytlarında Şekilleri Yeniden Boyutlandırma
type: docs
weight: 130
url: /tr/php-java/resizing-shapes-on-slide/
aliases:
  - /php-java/sekil-boyutunu-degistirme-slide/
  - /tr/php-java/re-sizing-shapes-on-slide/
keywords:
- şekil yeniden boyutlandırma
- şekil boyutunu değiştirme
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile PowerPoint ve OpenDocument slaytlarındaki şekilleri kolayca yeniden boyutlandırın—slayt düzeni ayarlamalarını otomatikleştirin ve üretkenliği artırın."
---
## **Genel Bakış**

Bir sunumun slayt boyutunu değiştirdiğinizde, şekillerini yeni boyutlara uydurmak için yeniden boyutlandırmanız ve konumlarını değiştirmeniz gerekebilir. Bu makale, şekilleri manuel olarak nasıl ölçeklendireceğinizi ve slaytlardaki, ana slaytlardaki ve düzenlerdeki tabloları nasıl ele alacağınızı gösterir.

## **Şekilleri Yeniden Boyutlandır**

Her şeklin göreceli konum ve boyutunu korumak için, yatay koordinatlarını ve genişliğini yeni slayt genişliği ile orijinal genişliğin oranıyla çarpın. Dikey koordinatları ve yüksekliği ise ilgili yükseklik oranı ile uygulayın.

İlk örnek, slaytları tablolar içermeyen bir sunumu yükler, slayt boyutunu A4 olarak değiştirir ve sonucu kaydeder. Sonraki döngünün ölçeklemeyi kontrol etmesi için [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) metodunu [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/) ile kullanır. Oranlar birimsizdir; şekil konumları ve boyutları puan cinsinden ölçülür. Farklı genişlik ve yükseklik oranları şekilleri bozabilir ve bir şeklin boyutlarını değiştirmek yazı tipi boyutlarını ölçeklendirmez.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

$presentation = new Presentation("sample.pptx");
try {
    // Bağımsız yatay ve dikey ölçek faktörlerini hesaplayın.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
            $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Tablolar ayrı bir işlem gerektirir: tablonun genel genişlik ve yüksekliğini atamak yerine sütun genişliklerini ve satır yüksekliklerini ölçeklendirin. Hücre içeriği daha fazla alan gerektiriyorsa satır yükseklikleri istenenden büyük kalabilir.
{{% /alert %}}

İkinci örnek, tabloları destekler ve yeniden boyutlandırılmış sunumu kaydetmeden önce ana slaytlardaki, düzenlerdeki ve bireysel slaytlardaki şekilleri işler. Yardımcısı, her [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) öğesini [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) ile sütun genişliklerini ve [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) ile minimum satır yüksekliklerini ölçeklendirerek ele alır. Ardından, tablonun genel boyutlarını ayrı ayrı ölçeklendirmeden konumunu ölçeklendirir.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

class ShapeResizer {
    public function resizeShapes($shapes, $widthRatio, $heightRatio) {
        $tableClass = new JavaClass("com.aspose.slides.Table");
        for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
            $shape = $shapes->get_Item($shapeIndex);
            if (java_instanceof($shape, $tableClass)) {
                $table = $shape;
                // Tablo boyutları sütun genişlikleri ve satır yükseklikleriyle kontrol edilir.
                for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
                    $column = $table->getColumns()->get_Item($columnIndex);
                    $column->setWidth(java_values($column->getWidth()) * $widthRatio);
                }

                for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
                    $row = $table->getRows()->get_Item($rowIndex);
                    $row->setMinimalHeight(java_values($row->getMinimalHeight()) * $heightRatio);
                }
            }
            else {
                $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
                $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            }

            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    // Bağımsız yatay ve dikey ölçek faktörlerini hesaplayın.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    $resizer = new ShapeResizer();

    // Ana slaytlarda ve düzenlerde tanımlı şekilleri ayrıca bireysel slaytlarda yeniden boyutlandırın.
    for ($masterIndex = 0; $masterIndex < java_values($presentation->getMasters()->size()); $masterIndex++) {
        $master = $presentation->getMasters()->get_Item($masterIndex);
        $resizer->resizeShapes($master->getShapes(), $widthRatio, $heightRatio);

        for ($layoutSlideIndex = 0; $layoutSlideIndex < java_values($master->getLayoutSlides()->size()); $layoutSlideIndex++) {
            $layoutSlide = $master->getLayoutSlides()->get_Item($layoutSlideIndex);
            $resizer->resizeShapes($layoutSlide->getShapes(), $widthRatio, $heightRatio);
        }
    }

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $resizer->resizeShapes($slide->getShapes(), $widthRatio, $heightRatio);
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **SSS**

**Şekiller bir slaytı yeniden boyutlandırdıktan sonra neden bozuluyor veya kesiliyor?**

Eğer slayt boyutunu şekilleri ölçeklendirmeden değiştirirseniz, şekiller orijinal konum ve boyutlarını korur ve slayt dışına taşabilir. Genişlik ve yüksekliği farklı oranlarla ölçeklendirmek de şekilleri bozabilir.

**Sağlanan kod tüm şekil türleri için çalışıyor mu?**

İlk örnek şekil sınırlarını doğrudan değiştirir ve tablolar içermeyen slaytlar için tasarlanmıştır. İkinci örnek tabloları ayrı olarak ele alır. Bu örnekler yazı tipi boyutlarını ölçeklendirmediği ve tablo içeriği satır yüksekliğini kısıtlayabileceği için sonuç düzenini, özellikle metin ve tabloları kontrol edin.

**Bir slaytı yeniden boyutlandırırken tabloları nasıl yeniden boyutlandırırım?**

İkinci örnekte gösterildiği gibi, sütun genişliklerini genişlik oranı ile, minimum satır yüksekliklerini ise yükseklik oranı ile ölçeklendirin ve ardından tablonun konumunu ölçeklendirin.

**Bu yeniden boyutlandırma ana slaytlar ve düzen slaytları için çalışır mı?**

Evet. İkinci örnek, [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) ve her bir ana slaydın [MasterSlide::getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/getlayoutslides/) üzerinden döner ve şekillerine aynı yeniden boyutlandırma mantığını uygular.

**Yeniden boyutlandırmayla birlikte bir slaydın yönünü (dikey/yatay) değiştirebilir miyim?**

Evet. Slayt boyutunu değiştirdikten ve hedef boyutları okumadan önce [SlideSize::setOrientation](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setorientation/) metodunu çağırın; böylece ölçek faktörleri son yönelime göre ayarlanır.

**Ayarlayabileceğim slayt boyutu için bir limit var mı?**

[SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) ile özel slayt boyutları belirleyebilirsiniz. Desteklenen boyutlar ayrıca sunum formatına ve dosyayı açan uygulamaya bağlıdır.

**Sabit en‑boy oranına sahip şekillerin bozulmasını nasıl önleyebilirim?**

Genişlik ve yükseklik için aynı ölçek faktörünü kullanın. Orijinal düzeni yeni slayt boyutlarına sığdırmak için, hem boyutlar hem de konumlar için genişlik ve yükseklik oranlarından daha küçük olanı kullanın. Bu, oranı korur ancak bir kenarda kullanılmayan boşluk kalabilir.