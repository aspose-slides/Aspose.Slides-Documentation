---
title: PHP ile Sunumlardan Şekil Etkili Özelliklerini Almak
linktitle: Etkili Özellikler
type: docs
weight: 50
url: /tr/php-java/shape-effective-properties/
keywords:
- şekil özellikleri
- kamera özellikleri
- ışık donanımı
- kırmızıçık şekil
- metin çerçevesi
- metin stili
- yazı tipi yüksekliği
- dolgu biçimi
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java'in, kesin PowerPoint render'ı için şekil etkili özelliklerini nasıl hesapladığını ve uyguladığını keşfedin."
---
## **Genel Bakış**

Bu konu, **yerel** ve **etkili** özellikler arasındaki farkı açıklar. Yerel değerler, doğrudan belirli bir biçimlendirme seviyesinde ayarlanan değerlerdir; örnekler:

1. Bir slayttaki bölüm (portion) özellikleri.
1. Bir düzenleme veya ana slaytta prototip şekil metin stilleri, bölümün metin çerçevesi şekli bir taneye sahipse.
1. Sunumdaki genel metin ayarları.

Yerel değerler herhangi bir seviyede tanımlanabilir veya atlanabilir. Aspose.Slides son “görüntülendiği gibi” biçimlendirmeyi gerektiğinde, kalıtım zincirini çözer ve **etkili** değerleri döndürür. Bu değerlere, yerel format nesnesi üzerindeki `getEffective` metodunu çağırarak ulaşabilirsiniz.

Aşağıdaki örnek, etkili değerlerin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) olduğunu, bir metin çerçevesi ve en az bir bölüm içerdiğini varsayar.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $localTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $effectiveTextFrameFormat = $localTextFrameFormat->getEffective();

    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $localPortionFormat = $portion->getPortionFormat();
    $effectivePortionFormat = $localPortionFormat->getEffective();
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}
Etkili biçimlendirme verileri, kalıtım uygulandıktan sonra hesaplanan mevcut biçimlendirmeyi temsil eder. Mevcut uygulamada, [PortionFormat.getEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portionformat/geteffective/) gibi yöntemler tarafından döndürülen bazı etkili veri nesneleri dahili olarak önbelleğe alınabilir. Üst ya da kalıtılmış biçimlendirme değiştirildikten sonra `getEffective` tekrar çağrıldığında önbellek yenilenir ve daha önce alınan nesne artık önceki durumu yansıtmaz. Etkili değerleri ileride yeniden kullanmak istiyorsanız, gerekli özellikleri (örneğin yazı tipi yüksekliği, dolgu rengi, yazı tipi stili veya hizalama) kendi veri nesnenize kopyalayın.
{{% /alert %}}

## **Bir Kamera İçin Etkili Özellikleri Almak**

Aspose.Slides, bir kameranın etkili özelliklerini almanıza olanak tanır. [ThreeDFormat.getEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/geteffective/) tarafından döndürülen etkili veri, bir [ThreeDFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/) için son kamera özelliklerini içerir.

Aşağıdaki kod örneği, kamera için etkili özelliklerin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin 3D biçimlendirmeye sahip olduğunu varsayar.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $camera = $threeDEffectiveData->getCamera();
    $cameraType = $camera->getCameraType();
    $fieldOfViewAngle = $camera->getFieldOfViewAngle();
    $zoom = $camera->getZoom();

    echo "= Effective camera properties =" . PHP_EOL;
    echo "Type: " . $cameraType . PHP_EOL;
    echo "Field of view: " . $fieldOfViewAngle . PHP_EOL;
    echo "Zoom: " . $zoom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Bir Işık Donanımı İçin Etkili Özellikleri Almak**

Aspose.Slides, bir ışık donanımının etkili özelliklerini almanıza olanak tanır. [ThreeDFormat.getEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/geteffective/) tarafından döndürülen etkili veri, bir [ThreeDFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/) için son ışık donanımı özelliklerini içerir.

Aşağıdaki kod örneği, ışık donanımı için etkili özelliklerin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin 3D biçimlendirmeye sahip olduğunu varsayar.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $lightRig = $threeDEffectiveData->getLightRig();
    $lightType = $lightRig->getLightType();
    $direction = $lightRig->getDirection();

    echo "= Effective light rig properties =" . PHP_EOL;
    echo "Type: " . $lightType . PHP_EOL;
    echo "Direction: " . $direction . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Bir Kırmızıçık Şekil İçin Etkili Özellikleri Almak**

Aspose.Slides, bir şekil kırmızıçığının (bevel) etkili özelliklerini almanıza olanak tanır. [ThreeDFormat.getEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/geteffective/) tarafından döndürülen etkili veri, bir [ThreeDFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/) için son yüzey kabartması özelliklerini içerir.

Aşağıdaki kod örneği, bir şeklin üst kırmızıçığı için etkili özelliklerin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin 3D biçimlendirmeye sahip olduğunu varsayar.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $bevelTop = $threeDEffectiveData->getBevelTop();
    $bevelType = $bevelTop->getBevelType();
    $bevelWidth = $bevelTop->getWidth();
    $bevelHeight = $bevelTop->getHeight();

    echo "= Effective shape's top face relief properties =" . PHP_EOL;
    echo "Type: " . $bevelType . PHP_EOL;
    echo "Width: " . $bevelWidth . PHP_EOL;
    echo "Height: " . $bevelHeight . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Bir Metin Çerçevesi İçin Etkili Özellikleri Almak**

Aspose.Slides kullanarak bir metin çerçevesinin etkili özelliklerini alabilirsiniz. [TextFrameFormat.getEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/geteffective/) tarafından döndürülen etkili veri, metin çerçevesi biçimlendirme özelliklerini içerir.

Aşağıdaki kod örneği, etkili metin çerçevesi biçimlendirme özelliklerinin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) olduğunu ve bir metin çerçevesi içerdiğini varsayar.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    $anchoringType = $effectiveTextFrameFormat->getAnchoringType();
    $autofitType = $effectiveTextFrameFormat->getAutofitType();
    $textVerticalType = $effectiveTextFrameFormat->getTextVerticalType();
    $marginLeft = $effectiveTextFrameFormat->getMarginLeft();
    $marginTop = $effectiveTextFrameFormat->getMarginTop();
    $marginRight = $effectiveTextFrameFormat->getMarginRight();
    $marginBottom = $effectiveTextFrameFormat->getMarginBottom();

    echo "Anchoring type: " . $anchoringType . PHP_EOL;
    echo "Autofit type: " . $autofitType . PHP_EOL;
    echo "Text vertical type: " . $textVerticalType . PHP_EOL;
    echo "Margins" . PHP_EOL;
    echo "   Left: " . $marginLeft . PHP_EOL;
    echo "   Top: " . $marginTop . PHP_EOL;
    echo "   Right: " . $marginRight . PHP_EOL;
    echo "   Bottom: " . $marginBottom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Bir Metin Stili İçin Etkili Özellikleri Almak**

Aspose.Slides kullanarak bir metin stilinin etkili özelliklerini alabilirsiniz. [TextStyle.getEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textstyle/geteffective/) tarafından döndürülen etkili veri, metin stili özelliklerini içerir.

Aşağıdaki kod örneği, etkili metin stili özelliklerinin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) olduğunu ve bir metin çerçevesi içerdiğini varsayar.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textStyle = $textFrameFormat->getTextStyle();
    $effectiveTextStyle = $textStyle->getEffective();
    $levelCount = 9;

    for ($levelIndex = 0; $levelIndex < $levelCount; $levelIndex++) {
        $effectiveStyleLevel = $effectiveTextStyle->getLevel($levelIndex);
        $depth = $effectiveStyleLevel->getDepth();
        $indent = $effectiveStyleLevel->getIndent();
        $alignment = $effectiveStyleLevel->getAlignment();
        $fontAlignment = $effectiveStyleLevel->getFontAlignment();

        echo "= Effective paragraph formatting for style level #" . $levelIndex . " =" . PHP_EOL;

        echo "Depth: " . $depth . PHP_EOL;
        echo "Indent: " . $indent . PHP_EOL;
        echo "Alignment: " . $alignment . PHP_EOL;
        echo "Font alignment: " . $fontAlignment . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Etkili Yazı Tipi Yüksekliği Değerini Almak**

Aspose.Slides kullanarak etkili yazı tipi yüksekliğini alabilirsiniz. Aşağıdaki kod, bir bölümün etkili yazı tipi yüksekliğinin, farklı sunum yapısı seviyelerinde yerel yazı tipi yüksekliği değerleri ayarlandığında nasıl değiştiğini gösterir.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $autoShape->addTextFrame("");

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $firstPortion = new Portion("Sample text with first portion");
    $secondPortion = new Portion(" and second portion.");

    $paragraph->getPortions()->add($firstPortion);
    $paragraph->getPortions()->add($secondPortion);

    $firstEffectivePortionFormat = $firstPortion->getPortionFormat()->getEffective();
    $secondEffectivePortionFormat = $secondPortion->getPortionFormat()->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height just after creation:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $defaultStyleLevel = $presentation->getDefaultTextStyle()->getLevel(0);
    $defaultPortionFormat = $defaultStyleLevel->getDefaultPortionFormat();
    $defaultPortionFormat->setFontHeight(24);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting the presentation default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $paragraphDefaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $paragraphDefaultPortionFormat->setFontHeight(40);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting paragraph default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $firstPortionFormat->setFontHeight(55);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #0 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $secondPortionFormat->setFontHeight(18);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #1 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $presentation->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Bir Tablo İçin Etkili Dolgu Biçimini Almak**

Aspose.Slides, farklı tablo bölümleri için etkili dolgu biçimlendirmesini almanıza olanak tanır. Biçim nesneleri tarafından döndürülen etkili veri, [FillFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fillformat/) özelliklerini içerir. Hücre biçimlendirmesi, satır biçimlendirmesinden, satır biçimlendirmesi sütun biçimlendirmesinden ve sütun biçimlendirmesi tüm tablo biçimlendirmesinden daha yüksek önceliğe sahiptir.

Sonuç olarak, tablo hücresini çizerken etkili [CellFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/cellformat/) özellikleri kullanılır. Aşağıdaki kod örneği, farklı tablo bölümleri için etkili dolgu biçimlendirmesinin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin bir [Table](https://reference.aspose.com/slides/tr/php-java/aspose.slides/table/) olduğunu varsayar.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $tableFormatEffective = $table->getTableFormat()->getEffective();

    $row = $table->getRows()->get_Item(0);
    $rowFormatEffective = $row->getRowFormat()->getEffective();

    $column = $table->getColumns()->get_Item(0);
    $columnFormatEffective = $column->getColumnFormat()->getEffective();

    $cell = $table->get_Item(0, 0);
    $cellFormatEffective = $cell->getCellFormat()->getEffective();

    $tableFillFormatEffective = $tableFormatEffective->getFillFormat();
    $rowFillFormatEffective = $rowFormatEffective->getFillFormat();
    $columnFillFormatEffective = $columnFormatEffective->getFillFormat();
    $cellFillFormatEffective = $cellFormatEffective->getFillFormat();
} finally {
    $presentation->dispose();
}
```

## **SSS**

**`getEffective` bir anlık görüntü (snapshot) döndürür mü?**

Her zaman değil. Etkili veri, kalıtım uygulandıktan sonra hesaplanan biçimlendirmeyi temsil eder, ancak bazı etkili veri nesneleri dahili olarak önbelleğe alınabilir. Sonraki bir `getEffective` çağrısı biçimlendirmeyi yeniden hesaplayabilir ve önbelleği yenileyebilir; bu nedenle daha önce alınan nesne kalıcı bir anlık görüntü olarak ele alınmamalıdır.

**Etkili özellikleri tekrar ne zaman okumalıyım?**

Yerel biçimlendirme, üst stil, düzenleme biçimlendirmesi, ana biçimlendirme veya sunum düzeyindeki varsayılanlar değiştirildikten sonra `getEffective` tekrar çağrılmalıdır. Bir sonraki çağrı biçimlendirme hiyerarşisini yeniden değerlendirir ve mevcut etkili sonucu döndürür.

**Bir düzenleme/ana slayt değiştirildiğinde veya kaldırıldığında, zaten alınmış etkili özellikler etkilenir mi?**

Evet, ancak değişiklik bir sonraki `getEffective` çağrısında yansır. Bir üst biçim kaynağı değiştirildiğinde veya kaldırıldığında, daha önce alınan etkili veri eski (stale) olabilir. `getEffective` tekrar çağrıldığında Aspose.Slides biçimleme ağacını yeniden değerlendirir ve ortaya çıkan yazı tipleri, renkler, boyutlar veya diğer değerler değişebilir.

**Etkili veri nesneleri üzerinden değerleri değiştirebilir miyim?**

Hayır. Etkili veri nesneleri yalnızca hesaplanmış değerleri gösterir. Değişiklikleri yerel biçimlendirme nesnelerinde yapın ve ardından etkili değerleri tekrar alın.

**Bir özellik şekil seviyesinde, düzenleme/ana slaytta ve genel ayarlarda hiç ayarlanmamışsa ne olur?**

Etkili değer, PowerPoint ve Aspose.Slides varsayılanlarını içeren varsayılan mekanizma tarafından belirlenir. Çözülen bu değer, mevcut etkili verinin bir parçası haline gelir.

**Etkili bir yazı tipi değerinden, boyutu veya yazı tipini hangi seviyenin sağladığını söyleyebilir miyim?**

Doğrudan değil. Etkili veri son değeri döndürür. Kaynağı bulmak için bölüm, paragraf, metin çerçevesi ve düzenleme, ana ve sunum seviyelerindeki metin stillerindeki yerel değerlere bakarak ilk açık tanımın nerede yapıldığını kontrol etmeniz gerekir.

**Neden bazen etkili değerler yerel değerlerle aynı görünüyor?**

Çünkü yerel değer, son değer haline gelmiştir (daha üst seviyelerden kalıtım gerekmemiştir). Bu durumlarda etkili değer, yerel değerle aynı olur.

**Etkili özellikleri ne zaman, yerel özelliklerle ne zaman kullanmalıyım?**

Tüm kalıtım uygulandıktan sonra “görüntülendiği gibi” sonucu elde etmeniz gerektiğinde etkili verileri kullanın; örneğin renk, girinti veya boyutları hizalamak için. Bu değerleri ilerideki değişikliklerden bağımsız olarak saklamanız gerektiğinde, gerekli özellikleri kendi nesnenize kopyalayın. Belirli bir seviyede biçimlendirme değişikliği yapmanız gerektiğinde, yerel özellikleri değiştirin ve gerekirse etkili verileri tekrar okuyarak sonucu doğrulayın.