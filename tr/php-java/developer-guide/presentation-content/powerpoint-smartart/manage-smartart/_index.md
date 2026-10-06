---
title: PHP Kullanarak PowerPoint Sunumlarında SmartArt Yönetimi
linktitle: SmartArt Yönetimi
type: docs
weight: 10
url: /tr/php-java/manage-smartart/
keywords:
- SmartArt
- SmartArt metni
- düzen türü
- gizli özelliği
- organizasyon şeması
- resim organizasyon şeması
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Açık kod örnekleriyle, slayt tasarımı ve otomasyonu hızlandıran, Aspose.Slides for PHP via Java kullanarak PowerPoint SmartArt oluşturmayı ve düzenlemeyi öğrenin."
---
## **Genel Bakış**

SmartArt, düğümler, düğüm şekilleri ve bir düzen kullanılarak oluşturulan bir PowerPoint diyagramıdır. Aspose.Slides for PHP via Java ile SmartArt oluşturabilir, düğümlerinden metin okuyabilir, düzenini değiştirebilir, gizli düğümleri inceleyebilir, organizasyon şeması düzenlerini yapılandırabilir ve resim organizasyon şemaları oluşturabilirsiniz.

## **SmartArt Nesnesinden Metin Almak**

Bir SmartArt düğümü bir veya daha fazla şekil içerebilir. Düğüm şekillerinden metin okumak için [SmartArt::getAllNodes](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/getallnodes/) üzerinden döngü oluşturun, ardından [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/smartartshape/gettextframe/) tarafından döndürülen [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) öğesini okuyun.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->get_Item(0);
    for ($i = 0; $i < java_values($smartArt->getAllNodes()->size()); $i++) {
        $node = $smartArt->getAllNodes()->get_Item($i);
        for ($j = 0; $j < java_values($node->getShapes()->size()); $j++) {
            $nodeShape = $node->getShapes()->get_Item($j);
            if (!java_is_null($nodeShape->getTextFrame())) {
                echo $nodeShape->getTextFrame()->getText() . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **SmartArt Nesnesinin Düzen Türünü Değiştirmek**

SmartArt düzeni, düğümlerin nasıl düzenlendiğini ve bağlandığını kontrol eder. Aşağıdaki örnek, [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `BasicBlockList` değerine sahip bir SmartArt nesnesi oluşturur, bunu `BasicProcess` değerine değiştirir ve sunumu kaydeder. [ShapeCollection::addSmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/)’a gönderilen konum ve boyut noktalar cinsindendir. Düzeni değiştirmek için [SmartArt::setLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setlayout/) kullanın.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Bir SmartArt Düğümünün Gizli Olup Olmadığını Kontrol Etmek**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/) düğümün SmartArt veri modelinde gizli olup olmadığını gösterir. Gizli düğümler, seçilen düzen onları görünür diyagram öğeleri olarak göstermese bile yapıda bulunabilir.

Aşağıdaki örnek, [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `RadialCycle` değerini kullanan bir SmartArt nesnesine bir düğüm ekler ve eklenen düğümün gizli durumunu kontrol eder. Düğüm gizliyse bir mesaj yazdırır ve diyagramı kaydeder.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    $node = $smartArt->getAllNodes()->addNode();
    $isHidden = java_values($node->isHidden());

    if ($isHidden) {
        echo "The node is hidden in the SmartArt data model." . PHP_EOL;
    }

    $presentation->save("CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Organizasyon Şeması Düzenini Almak veya Ayarlamak**

Organizasyon şeması düzeni kullanan SmartArt diyagramları için [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) ve [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) çocuk düğümlerin bir üst düğüm altında nasıl düzenleneceğini tanımlar. Örneğin, seçilen [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/) değerine bağlı olarak çocuk düğümleri soldan, sağdan veya her iki taraftan sarkıtacak şekilde ayarlayabilirsiniz.

Aşağıdaki örnek bir organizasyon şeması oluşturur ve ilk düğümün düzenini [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` değerine ayarlar. Sıfır tabanlı indeks `0` ilk üst düzey düğümü seçer; onun çocuk düğümleri seçilen düzeni kullanır. Değiştirilmiş sunum daha sonra kaydedilir.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;
use aspose\slides\OrganizationChartLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Resim Organizasyon Şeması Oluşturmak**

Resim organizasyon şeması, görüntü yer tutucuları içeren hiyerarşi diyagramları için tasarlanmış bir SmartArt düzenidir. SmartArt nesnesini bir slayta eklerken [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` değerini kullanın. Bu örnek, görüntü yer tutucularıyla bir diyagramı kaydeder; yer tutucuları görüntülerle doldurmaz.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Eski Diyagramları Şekil Gruplarına Dönüştürmek**

Mevcut bir sunumu modernleştirirken, PowerPoint 97–2003’te oluşturulmuş bir organizasyon şemasını güncellemeniz gerekebilir. Aspose.Slides, bu eski diyagramları [LegacyDiagram](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/) nesneleri olarak temsil eder. Bir diyagramı, bireysel görsel öğeleri düzenleyebilmek için bir şekil grubuna dönüştürmek üzere [LegacyDiagram::convertToGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/converttogroupshape/) kullanın. Ayrıntılar için [LegacyDiagram API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/) bölümüne bakın.

Dönüştürme, orijinal diyagramı kaldırmadan şekil koleksiyonuna yeni bir grup ekler. Başarılı dönüşümden sonra, yinelenen içeriği önlemek için orijinali [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) ile kaldırın. Şekil ekleme ve kaldırma işlemlerinin yinelemeyi bozmasını önlemek için dönüştürmeden önce eski diyagramları bir listeye toplayın.

Aşağıdaki örnek bir sunumu açar, her slaytı tarar, diyagramları şekil gruplarına dönüştürür ve güncellenmiş sunumu PPTX olarak kaydeder.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("legacy-diagrams.ppt");
try {
    $legacyDiagramType = new JavaClass("com.aspose.slides.ILegacyDiagram");
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $legacyDiagrams = [];
        for ($j = 0; $j < java_values($slide->getShapes()->size()); $j++) {
            $shape = $slide->getShapes()->get_Item($j);
            if (java_instanceof($shape, $legacyDiagramType)) {
                $legacyDiagrams[] = $shape;
            }
        }

        foreach ($legacyDiagrams as $legacyDiagram) {
            $groupShape = $legacyDiagram->convertToGroupShape();

            if (!java_is_null($groupShape)) {
                $slide->getShapes()->remove($legacyDiagram);
            }
        }
    }

    $presentation->save("modernized.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kaydedilen sunum, dönüştürülmüş eski diyagramların yerine düzenlenebilir şekil grupları içerir ve yanlarında orijinal diyagram kalmaz. PPTX dosyasını PowerPoint’te açıp her grup içindeki metin, dolgu veya konum gibi bireysel öğeleri düzenleyebilirsiniz.

## **SSS**

**SmartArt, RTL dilleri için yansıtma veya tersine çevirme desteği sunuyor mu?**

Evet. Seçili SmartArt düzeni tersine çevirmeyi destekliyorsa, [SmartArt::setReversed](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) yöntemi diyagram yönünü soldan sağa’dan sağdan sola’ya değiştirir veya geri alır.

**SmartArt'ı aynı slayta veya başka bir sunuya biçimlendirmeyi koruyarak nasıl kopyalarım?**

SmartArt şekli [SmartArt şekli kopyala](/slides/tr/php-java/shape-manipulations/) bağlantısı ile [ShapeCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addclone/) kullanarak ya da SmartArt'ı içeren slaytı [tüm slaytı kopyala](/slides/tr/php-java/clone-slides/) ile kopyalayabilirsiniz. Her iki yöntem de boyut, konum ve biçimlendirmeyi korur.

**SmartArt'ı önizleme veya web dışa aktarımı için raster görüntüye nasıl render ederim?**

[Slaytı render edin](/slides/tr/php-java/convert-powerpoint-to-png/) veya tüm sunumu PNG ya da JPEG formatına dönüştürün. SmartArt slaytın bir parçası olarak render edilir.

**Bir slaytta birden fazla SmartArt nesnesi varsa, belirli bir SmartArt nesnesini nasıl bulabilirim?**

SmartArt şekline ayırt edici bir alternatif metin veya ad atamak için [Shape::setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) veya [Shape::setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setname/) kullanın, bu değeri [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) içinde arayın ve ardından eşleşen şeklin bir [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) olduğunu kontrol edin.