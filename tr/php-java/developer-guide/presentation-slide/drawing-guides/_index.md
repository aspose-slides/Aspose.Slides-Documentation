---
title: PHP ile Sunumlarda Çizim Kılavuzlarını Yönet
linktitle: Çizim Kılavuzları
type: docs
weight: 85
url: /tr/php-java/drawing-guides/
keywords:
- çizim kılavuzu
- yatay kılavuz
- dikey kılavuz
- hizalama kılavuzu
- slayt görünümü
- master slayt
- düzen slaytı
- not master
- el yayını master
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint sunumlarında yatay ve dikey çizim kılavuzlarını ekleyin, erişin ve temizleyin."
---
## **Genel Bakış**

Çizim kılavuzları, PowerPoint’te bir sunumu düzenlerken kullanıcıların şekilleri tutarlı bir şekilde hizalamasına yardımcı olan ayarlanabilir yatay ve dikey çizgilerdir. Uygulamanın daha sonra manuel olarak iyileştirilecek bir sunum oluşturduğu durumlarda özellikle faydalıdır: uygulama, yazarların içerik eklerken veya taşırken takip etmesi gereken aynı hizalama yardımcılarını kaydedebilir.

Çizim kılavuzları, slayt içeriği değil, düzenleme yardımcılarıdır. Bir slayt gösterisinde veya renderlanmış çıktıda görünmezler. Aspose.Slides for PHP via Java, bunları [DrawingGuidesCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/drawingguidescollection/) sınıfı aracılığıyla sunar. Bir kılavuz, [DrawingGuide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/drawingguide/) tarafından temsil edilir ve bir yönelim, konum ve renk içerir.

Pozisyon, ilgili slayt ya da master'ın sol üst köşesinden itibaren puan cinsinden ölçülür. Dikey bir kılavuz, genellikle sıfır ile slayt genişliği arasında değişen bir yatay koordinat kullanır. Yatay bir kılavuz, genellikle sıfır ile slayt yüksekliği arasında değişen bir dikey koordinat kullanır.

## **Slayt Görünümüne Kılavuz Ekle**

Normal slaytları düzenlerken görüntülenen kılavuzları yönetmek için [CommonSlideViewProperties::getDrawingGuides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) kullanın. Bir [Orientation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/orientation/) değeri ve puan cinsinden bir konum ile [DrawingGuidesCollection::add](https://reference.aspose.com/slides/tr/php-java/aspose.slides/drawingguidescollection/#add) çağırın.

Aşağıdaki örnek, slayt ortasının sağ tarafına bir dikey kılavuz ve altında bir yatay kılavuz ekler:
```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();

    $guides->add(Orientation::Vertical, $slideWidth / 2 + 12.5);
    $guides->add(Orientation::Horizontal, $slideHeight / 2 + 12.5);

    $presentation->save("drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Çizim Kılavuzlarına Erişim**

Mevcut kılavuzlara erişim sağlamak için [DrawingGuidesCollection::getCount](https://reference.aspose.com/slides/tr/php-java/aspose.slides/drawingguidescollection/#getCount) ve [DrawingGuidesCollection::get_Item](https://reference.aspose.com/slides/tr/php-java/aspose.slides/drawingguidescollection/#get_Item) yöntemleri kullanılır. [DrawingGuide::getOrientation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide::getPosition](https://reference.aspose.com/slides/tr/php-java/aspose.slides/drawingguide/#getPosition) ve [DrawingGuide::getColor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/drawingguide/#getColor) yöntemleri değerleri döndürür ve bunlar ilgili ayarlayıcı (setter) yöntemleriyle değiştirilebilir.

Aşağıdaki örnek, yukarıda oluşturulan sunumdan slayt görünümü kılavuzlarını okur:
```php
use aspose\slides\Presentation;

$presentation = new Presentation("drawing-guides.pptx");
try {
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();
    $guideCount = java_values($guides->getCount());

    for ($index = 0; $index < $guideCount; $index++) {
        $guide = $guides->get_Item($index);
        $orientation = java_values($guide->getOrientation());
        $position = java_values($guide->getPosition());
        $color = java_values($guide->getColor()->toString());
        echo sprintf("Guide %d: orientation = %d, position = %.2f, color = %s", $index, $orientation, $position, $color) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Master ve Layout Slaytlarına Kılavuz Ekle**

Bir slayt master'ı ve her bir layout slaytı, kendi çizim kılavuzu koleksiyonlarına sahip olabilir. Master slayt için [MasterSlide::getDrawingGuides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslide/#getDrawingGuides), layout slaytı için ise [LayoutSlide::getDrawingGuides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslide/#getDrawingGuides) kullanın.

Aşağıdaki örnek, ilk master slayta bir dikey kılavuz ve ilk layout slayta bir yatay kılavuz ekler:
```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $masterGuides = $presentation->getMasters()->get_Item(0)->getDrawingGuides();
    $layoutGuides = $presentation->getLayoutSlides()->get_Item(0)->getDrawingGuides();

    $masterGuides->add(Orientation::Vertical, $slideWidth / 2 - 20);
    $layoutGuides->add(Orientation::Horizontal, $slideHeight / 2 + 20);

    $presentation->save("master-layout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Not ve El Yayını Master'larına Kılavuz Ekle**

Not master'ları ve el yayını master'ları da çizim kılavuzlarını destekler. Koleksiyonlarına erişmek için [MasterNotesSlide::getDrawingGuides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masternotesslide/#getDrawingGuides) ve [MasterHandoutSlide::getDrawingGuides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterhandoutslide/#getDrawingGuides) kullanın. Bir sunum bu master'lardan birini içermiyorsa, uygun yöneticiyi [Presentation::getMasterNotesSlideManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getMasterNotesSlideManager) veya [Presentation::getMasterHandoutSlideManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getMasterHandoutSlideManager) ile alın ve ardından `setDefaultMasterNotesSlide` veya `setDefaultMasterHandoutSlide` ile varsayılan master'ı oluşturun.

Aşağıdaki örnek, bir not master'ına yatay bir kılavuz ve bir el yayını master'ına dikey bir kılavuz ekler:
```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $notesSize = $presentation->getNotesSize()->getSize();
    $notesWidth = java_values($notesSize->getWidth());
    $notesHeight = java_values($notesSize->getHeight());
    $notesMaster = $presentation->getMasterNotesSlideManager()->setDefaultMasterNotesSlide();
    $handoutMaster = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();

    $notesMaster->getDrawingGuides()->add(Orientation::Horizontal, $notesHeight / 2 + 50);
    $handoutMaster->getDrawingGuides()->add(Orientation::Vertical, $notesWidth / 2 - 50);

    $presentation->save("notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Çizim Kılavuzlarını Temizle**

[DrawingGuidesCollection::clear](https://reference.aspose.com/slides/tr/php-java/aspose.slides/drawingguidescollection/#clear) metodunu çağırarak belirli bir koleksiyondaki tüm kılavuzları kaldırabilirsiniz. Bir koleksiyonun temizlenmesi, başka bir kapsamda depolanan kılavuzları etkilemez.

Aşağıdaki örnek, eksik master'lar oluşturulmadan slayt görünümü kılavuzlarını ve slayt master'ları, layout slaytları, not master'ı ve el yayını master'ındaki tüm kılavuzları temizler:
```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation-with-guides.pptx");
try {
    $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides()->clear();

    $masterCount = java_values($presentation->getMasters()->size());
    for ($index = 0; $index < $masterCount; $index++) {
        $presentation->getMasters()->get_Item($index)->getDrawingGuides()->clear();
    }

    $layoutCount = java_values($presentation->getLayoutSlides()->size());
    for ($index = 0; $index < $layoutCount; $index++) {
        $presentation->getLayoutSlides()->get_Item($index)->getDrawingGuides()->clear();
    }

    $notesMaster = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
        $notesMaster->getDrawingGuides()->clear();
    }

    $handoutMaster = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();
    if (!java_is_null($handoutMaster)) {
        $handoutMaster->getDrawingGuides()->clear();
    }

    $presentation->save("presentation-without-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **SSS**

**Çizim kılavuzları bir slayt gösterisinde veya dışa aktarılan görsellerde görünür mü?**  
Hayır. Çizim kılavuzları düzenleme için hizalama yardımcılarıdır ve sunum içeriği olarak renderlanmaz.

**Bir çizim kılavuzu doğrudan bireysel normal slayta eklenebilir mi?**  
Normal slayt düzenleme kılavuzları, sunumun slayt‑görünüm özelliklerinde depolanır. Slide master'ları, layout slaytları, not master'ları ve el yayını master'ları için ayrı kılavuz koleksiyonları mevcuttur.

**Kılavuz konumları için hangi birimler kullanılır?**  
Konumlar, 72 noktanın bir inçe eşit olduğu puan cinsinden belirtilir. Dikey konumlar sol kenardan, yatay konumlar ise üst kenardan ölçülür.

**Çizim kılavuzlarını temizlemek şekilleri kaldırır veya slayt içeriğini değiştirir mi?**  
Hayır. [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/tr/php-java/aspose.slides/drawingguidescollection/#clear) yöntemi yalnızca seçilen koleksiyondaki kılavuzları kaldırır. Şekiller ve diğer slayt içeriği değişmeden kalır.