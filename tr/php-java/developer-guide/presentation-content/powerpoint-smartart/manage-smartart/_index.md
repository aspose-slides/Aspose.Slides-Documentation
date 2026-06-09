---
title: PHP Kullanarak PowerPoint Sunumlarında SmartArt Yönetimi
linktitle: SmartArt Yönetimi
type: docs
weight: 10
url: /tr/php-java/manage-smartart/
keywords:
- SmartArt
- SmartArt metni
- yerleşim türü
- gizli özelliği
- organizasyon şeması
- resimli organizasyon şeması
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint SmartArt oluşturmayı ve düzenlemeyi, slayt tasarımını ve otomasyonu hızlandıran net kod örnekleriyle öğrenin."
---
## **Genel Bakış**

SmartArt, düğümler, düğüm şekilleri ve bir yerleşimden oluşan bir PowerPoint diyagramıdır. Aspose.Slides for PHP via Java ile SmartArt oluşturabilir, düğümlerindeki metni okuyabilir, yerleşimini değiştirebilir, gizli düğümleri inceleyebilir, organizasyon şeması yerleşimlerini yapılandırabilir ve resimli organizasyon şemaları oluşturabilirsiniz.

## **SmartArt Nesnesinden Metin Almak**

Bir SmartArt düğümü bir veya daha fazla şekil içerebilir. Görünür metni okumak için [SmartArt::getAllNodes](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartart/#getAllNodes) üzerinden yineleme yapın, ardından [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartartshape/#getTextFrame) tarafından döndürülen [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/)’i okuyun.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.ISmartArt"))) {
        $smartArt = $shape;

        foreach ($smartArt->getAllNodes() as $smartArtNode) {
            foreach ($smartArtNode->getShapes() as $smartArtShape) {
                if (!java_is_null($smartArtShape->getTextFrame())) {
                    echo($smartArtShape->getTextFrame()->getText());
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **SmartArt Nesnesinin Yerleşim Türünü Değiştirmek**

SmartArt yerleşimi, düğümlerin nasıl düzenlendiğini ve bağlandığını kontrol eder. Aşağıdaki örnek, [SmartArtLayoutType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartartlayouttype/) `BasicBlockList` değerine sahip bir SmartArt nesnesi oluşturur, bunu `BasicProcess` değerine değiştirir ve sunumu kaydeder.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);

    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Bir SmartArt Düğümünün Gizli Olup Olmadığını Kontrol Etmek**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartartnode/ishidden/) düğümün SmartArt veri modelinde gizli olup olmadığını gösterir. Seçilen yerleşim bu düğümleri görünür diyagram öğeleri olarak göstermese bile gizli düğümler yapıda bulunabilir.

Aşağıdaki örnek, [SmartArtLayoutType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartartlayouttype/) `RadialCycle` değerini kullanan bir SmartArt nesnesine bir düğüm ekler ve düğümün gizli durumunu kontrol eder.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::RadialCycle);

    $smartArtNode = $smartArt->getAllNodes()->addNode();
    $isHidden = $smartArtNode->isHidden();

    if ($isHidden) {
        echo("The node is hidden in the SmartArt data model.");
    }

    $presentation->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Organizasyon Şeması Yerleşimini Almak veya Ayarlamak**

Bir organizasyon şeması yerleşimi kullanan SmartArt diyagramları için, [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) ve [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) çocuk düğümlerin bir üst düğüm altında nasıl düzenleneceğini tanımlar. Örneğin, seçilen [OrganizationChartLayoutType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/organizationchartlayouttype/)’a bağlı olarak çocuk düğümleri soldan, sağdan veya her iki taraftan sarkıtacak şekilde ayarlayabilirsiniz.

Aşağıdaki örnek bir organizasyon şeması oluşturur ve ilk düğümün yerleşimini [OrganizationChartLayoutType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` değerine ayarlar.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);

    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Resimli Organizasyon Şeması Oluşturmak**

Resimli organizasyon şeması, resim yer tutucuları içeren hiyerarşi diyagramları için tasarlanmış bir SmartArt yerleşimidir. SmartArt nesnesini bir slayta eklerken [SmartArtLayoutType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` değerini kullanın.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **SSS**

**SmartArt, RTL dilleri için yansıtma veya tersine çevirme destekliyor mu?**

Evet. [SmartArt::setReversed](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartart/setreversed/) yöntemi, seçilen SmartArt yerleşimi tersine çevirmeyi desteklediğinde diyagram yönünü soldan-sağa’dan sağdan-sola (veya geri) değiştirir.

**SmartArt'ı aynı slayta ya da başka bir sunuma biçimlendirmeyi koruyarak nasıl kopyalayabilirim?**

[SmartArt şekilini klonlayın](/slides/tr/php-java/shape-manipulations/) [ShapeCollection::addClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/addclone/) ile ya da SmartArt içeren slaytı tamamını [klonlayın](/slides/tr/php-java/clone-slides/) [clone the whole slide](/slides/tr/php-java/clone-slides/). Her iki yaklaşım da boyut, konum ve biçimlendirmeyi korur.

**SmartArt'ı önizleme veya web dışa aktarımı için raster görüntüye nasıl render edebilirim?**

[Slaytı renderlayın](/slides/tr/php-java/convert-powerpoint-to-png/) ya da tüm sunumu PNG veya JPEG formatına dönüştürün. SmartArt slaytın bir parçası olarak renderlanır.

**Bir slaytta birden fazla SmartArt nesnesi varsa, belirli bir SmartArt nesnesini nasıl bulabilirim?**

SmartArt şekli üzerinde ayırt edici bir [Shape::getAlternativeText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/getalternativetext/) ya da [Shape::getName](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/getname/) değeri belirleyin, bu değeri [BaseSlide::getShapes](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseslide/#getShapes) içinde arayın ve ardından eşleşen şeklin bir [SmartArt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartart/) olduğunu kontrol edin.