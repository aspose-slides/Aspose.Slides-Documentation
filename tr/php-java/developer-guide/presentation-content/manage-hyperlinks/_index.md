---
title: PHP'de Sunum Köprülerini Yönet
linktitle: Köprüleri Yönet
type: docs
weight: 20
url: /tr/php-java/manage-hyperlinks/
keywords:
- URL ekle
- Köprü ekle
- Köprü oluştur
- Köprü biçimlendir
- Köprü kaldır
- Köprü güncelle
- Metin köprüsü
- Slayt köprüsü
- Şekil köprüsü
- Görsel köprüsü
- Video köprüsü
- Değiştirilebilir köprü
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak, PHP örnekleriyle PowerPoint ve OpenDocument sunumlarında köprüleri ekleyin, biçimlendirin, güncelleyin ve kaldırın."
---
## **Giriş**

Bir köprü, sunum içeriğini bir web sitesine veya sunum içinde bir konuma bağlar. PowerPoint'te köprüler genellikle iki amaç için kullanılır:

* Metin, şekil veya medya çerçevesinden bir web sitesini açar.
* Örneğin bir içindekiler tablosundan başka bir slayta gider.

Aspose.Slides for PHP via Java, bu köprüleri eklemenizi, görünüm ve seslerini kontrol etmenizi, özelliklerini güncellemenizi ve kaldırmanızı sağlar. Aşağıdaki örneklerde bireysel öğelerde köprülerle nasıl çalışılacağını ve köprülere sunum, slayt veya metin‑çerçevesi seviyesinden nasıl erişileceğini gösterir. PHP/Java Bridge ve Aspose.Slides PHP sarmalayıcısının başlatıldığını varsayar. PHP referans sayfası olmayan API üyeleri, altındaki Java API'sine yönlendirilir.

{{% alert color="info" title="Note" %}}
Sunumları aynı zamanda [free online Aspose PowerPoint editor](https://products.aspose.app/slides/editor) ile düzenleyebilirsiniz.
{{% /alert %}}

## **URL Köprüleri Ekle**

Bir web sitesi URL'sini metne, şekle veya medya çerçevesine atayabilirsiniz. Köprüyü atadığınız öğe tıklanabilir alanı belirler: bir metin bölümü seçilen metni bağlarken, bir şekil veya çerçeve slayt nesnesini bağlar.

Göreceli köprüler içeren sunumlar için, belge‑seviyesindeki temeli okumak, değiştirmek veya temizlemek üzere [Manage the Hyperlink Base](/slides/tr/php-java/presentation-properties/#manage-the-hyperlink-base) bölümüne bakın.

### **Metne URL Köprüsü Ekle**

Metni bir web sitesine bağlamak için, aşağıda gösterildiği gibi, metin bölümünün [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/sethyperlinkclick/) metoduna bir [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) nesnesi geçirin. Sadece o metin bölümü tıklanabilir olur.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $textShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $textShape->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");
    $portionFormat->setFontHeight(32);

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Şekillere ve Medya Çerçevelerine URL Köprüsü Ekle**

Dikdörtgene tüm alanının tıklanabilir olması için [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/shape/sethyperlinkclick/) yöntemini çağırın. Kullanıcı dikdörtgenin üzerine geldiğinde hedef hakkında bir ipucu göstermek için [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) yöntemini kullanın. Her iki yöntem aynı zamanda resim, ses ve video çerçevelerine de uygulanır.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

    $shape->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $shape->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **İçindekiler Tablosu Oluşturmak için Köprüleri Kullan**

Dahili köprüler, okuyucuların bir içindekiler tablosundan belirli bir slayta atlamasını sağlar. Aşağıdaki örnek, “Page 2” metnini ilk slayttan ikinci slayta bağlamak için [setInternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) yöntemini kullanır.

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $tableOfContents = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
    $tableOfContents->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getTextFrame()->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $paragraph->setText("Title of slide 2 .......... ");

    $linkPortion = new Portion();
    $linkPortion->setText("Page 2");
    $linkPortion->getPortionFormat()->getHyperlinkManager()->setInternalHyperlinkClick($secondSlide);

    $paragraph->getPortions()->add($linkPortion);
    $tableOfContents->getTextFrame()->getParagraphs()->add($paragraph);

    $presentation->save("link_to_slide.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Köprüleri Biçimlendir**

Bağlantılı metnin rengini değiştirebilir, bir okuyucu köprüyü etkinleştirdiğinde ses çalabilir veya durdurabilir ve üzerine gelindiğinde görülen ipucu metnini ayarlayabilirsiniz.

### **Renk**

[Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) sınıfının [setColorSource](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setcolorsource/) yöntemi, köprünün sunumun köprü rengi mi yoksa metin bölümünün biçimlendirmesi mi kullanacağını belirler. Özel bir metin rengi uygulamak için [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkcolorsource/) seçin ve bölümün doldurma rengini ayarlayın. Bu özellik PowerPoint 2019’da tanıtıldı; eski sürümler bu ayarı uygulamaz.

Bu örnekte, [setColorSource](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setcolorsource/) ilk köprünün metin bölümünün kırmızı doldurmasını sağlar. İkinci köprü ise sunumun köprü rengini korur.

```php
use aspose\slides\FillType;
use aspose\slides\Hyperlink;
use aspose\slides\HyperlinkColorSource;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $coloredShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
    $coloredShape->addTextFrame("This hyperlink uses a custom color.");
    $coloredPortionFormat = $coloredShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $coloredPortionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $coloredPortionFormat->getHyperlinkClick()->setColorSource(HyperlinkColorSource::PortionFormat);
    $coloredPortionFormat->getFillFormat()->setFillType(FillType::Solid);
    $coloredPortionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $defaultShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
    $defaultShape->addTextFrame("This hyperlink uses the default color.");
    $defaultShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    $presentation->save("presentation-out-hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Ses**

Bir köprü etkinleştirildiğinde ses çalabilir veya zaten çalan bir sesi durdurabilir. Bu davranışları yapılandırmak için aşağıdaki yöntemleri kullanın:

- [Hyperlink::setSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setsound/) köprünün ilişkili sesini belirtir.
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setstopsoundonclick/) köprünün etkinleştirilmesi önceki sesi durdurup durdurmayacağını kontrol eder.

#### **Köprü Sesi Ekle**

İlk slayttaki düğme, okuyucu ilerlemek için tıkladığında `sampleaudio.wav` dosyasından ses çalmak üzere [Hyperlink::setSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setsound/) yöntemini kullanır. İkinci slaytta ayrı bir düğme, çalmayı durdurmak ve okuyucuyu aynı slaytta tutmak için [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setstopsoundonclick/) yöntemini kullanır.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $audioFile = new Java("java.io.File", "sampleaudio.wav");
    $audioPath = $audioFile->toPath();
    $audioData = java("java.nio.file.Files")->readAllBytes($audioPath);
    $hyperlinkSound = $presentation->getAudios()->addAudio($audioData);

    $firstSlide = $presentation->getSlides()->get_Item(0);

    $playButton = $firstSlide->getShapes()->addAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
    $playButton->setHyperlinkClick(Hyperlink::getNextSlide());

    if (!java_values($playButton->getHyperlinkClick()->getStopSoundOnClick()) && java_is_null($playButton->getHyperlinkClick()->getSound()))
    {
        $playButton->getHyperlinkClick()->setSound($hyperlinkSound);
    }

    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $stopButton = $secondSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
    $stopButton->setHyperlinkClick(Hyperlink::getNoAction());

    $stopButton->getHyperlinkClick()->setStopSoundOnClick(true);

    $presentation->save("hyperlink-sound.pptx", SaveFormat::Pptx);
} catch (JavaException $exception) {
    echo "Unable to read the audio file: " . $exception->getMessage() . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

#### **Köprü Sesini Çıkar**

Aşağıdaki örnek, yukarıda oluşturulan sunumu açar ve ilk şeklin köprü sesini [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getsound/) ve [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/) aracılığıyla belleğe okur.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0 && java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) > 0) {
        $hyperlink = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getHyperlinkClick();
        $sound = java_is_null($hyperlink) ? null : $hyperlink->getSound();
        if (!java_is_null($sound)) {
            $audioData = $sound->getBinaryData();
            echo "Extracted " . strlen(java_values($audioData)) . " bytes of hyperlink audio." . PHP_EOL;
        } else {
            echo "The first shape has no hyperlink sound." . PHP_EOL;
        }
    } else {
        echo "The presentation has no first slide or shape to inspect." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **İpucu ve Etkileşim Ayarları**

Bir metne veya şekle köprü atadıktan sonra aşağıdaki [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) yöntemlerini çağırabilirsiniz:

- [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) izleyicinin link hakkında bir ipucu gösterebileceği metni ayarlar.
- [setTargetFrame](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settargetframe/) uygulanabilir olduğunda üst HTML çerçeve kümesindeki hedef çerçeveyi belirtir.
- [setHistory](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethistory/) linkin etkinleştirilmesinin hedefini görüntülenen köprüler listesine ekleyip eklemeyeceğini kontrol eder.
- [setHighlightClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethighlightclick/) linkin tıklandığında vurgulanıp vurgulanmayacağını kontrol eder.

## **Sunumlardan Köprüleri Kaldır**

[Köprüleri toplamak] için [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) yöntemini kullanın; böylece metin‑bölümü köprüleri dahil tüm köprü kapsayıcılarını değiştirmeden önce toplayabilirsiniz. Aşağıdaki örnek, ilk slayttaki iki etkinleştirme türünü kaldırır. Yalnızca bir türü kaldırmak için sadece [removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) veya [removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/) yöntemini çağırın; bir tıklama eylemini kaldırmak, fare‑üzerinde eylemini kaldırmaz.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0) {
        $containers = [];
        foreach ($presentation->getSlides()->get_Item(0)->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $containers[] = $container;
        }
        foreach ($containers as $container) {
            $container->getHyperlinkManager()->removeHyperlinkClick();
            $container->getHyperlinkManager()->removeHyperlinkMouseOver();
        }
        $presentation->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
    } else {
        echo "The presentation has no slides to process." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Koşulsuz kaldırma için, [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) seçili kapsamda iki etkinleştirme türünü tek bir çağrıyla kaldırır. Seçici temizlik ve ana sayfa, düzen ve not kapsayıcılarını kapsamak için [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) bölümüne bakın.

### **Akıllı Sanat Metnini Değiştirmeden Önce Köprüleri Temizle**

Mevcut bir SmartArt düğümünde bir paragrafı değiştirdiğinizde, metin bölümlerini temizlemek eski bir köprünün etkili kalmasına neden olabilir. Paragrafı [SmartArtNode::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/gettextframe/) yöntemiyle alın. Bölümlerini temizlemeden önce düğüm şeklinin metin çerçevesinde [getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/gethyperlinkqueries/) çağırın ve dönen nesnede [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) yöntemiyle tüm köprüleri kaldırın. Böylece o çerçevedeki tüm köprüler, diğer paragraflardaki köprüler de dahil, silinmiş olur.

Örnek, `SmartArtHyperlink.pptx` dosyasının ilk slaydındaki üçüncü şeklin bir SmartArt grafiği olduğunu varsayar. Dördüncü düğümün ilk paragrafını değiştirir. Bu sunumda, düğümün ilk şekli o paragrafı gösterir.

Her iki bölümü ekledikten sonra örnek, [getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/geteffective/) yöntemiyle etkin biçimlendirmeyi okur. Bu biçimlendirmede, [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformateffectivedata/#getHyperlinkClick--) ilk bölüm için yeni köprüyü ve ikinci bölüm için `null` döndürür.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Portion;
use aspose\slides\Presentation;

$presentation = new Presentation("SmartArtHyperlink.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $smartArt = $slide->getShapes()->get_Item(2);
    $node = $smartArt->getAllNodes()->get_Item(3);
    $paragraph = $node->getTextFrame()->getParagraphs()->get_Item(0);

    $node->getShapes()->get_Item(0)->getTextFrame()->getHyperlinkQueries()->removeAllHyperlinks();
    $paragraph->getPortions()->clear();

    $link = new Portion("New reference");
    $link->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://example.com/new"));
    $paragraph->getPortions()->add($link);
    $text = new Portion(" (updated)");
    $paragraph->getPortions()->add($text);

    echo java_values($link->getPortionFormat()->getEffective()->getHyperlinkClick()->getExternalUrl()), PHP_EOL; // https://example.com/new
    var_dump(java_is_null($text->getPortionFormat()->getEffective()->getHyperlinkClick())); // bool(true): ikinci bölümde köprü yok.
} finally {
    $presentation->dispose();
}
```

## **Tam Bir Köprü Envanteri Oluştur**

Sunumu dağıtmadan önce, etkileşimli eylemlerini ve web bağlantılarını envantere alın. [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) yöntemi, düz bir URL listesi değil, [IHyperlinkContainer](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/) nesnelerini döndürür. Her kapsayıcı için hem [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) hem de [getHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) yöntemlerini inceleyin. Bunlar bağımsızdır: aynı kapsayıcı iki eylemi de içerebilir, bu yüzden tam rapor her kapsayıcı için iki satır gerektirebilir.

Sadece şekil‑seviyesindeki köprüleri taramak, metin bölümlerine eklenmiş köprüleri kaçırabilir. Bunun yerine uygun kapsamı sorgulayın ve dönen kapsayıcıları saklayarak daha sonra eylemlerini güncelleyebilir veya kaldırabilirsiniz.

### **Sunum, Slayt ve Metin‑Çerçeve Kapsamlarını Sorgula**

[HyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/) sınıfı, [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/gethyperlinkqueries/), [IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) ve [TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/gethyperlinkqueries/) aracılığıyla kullanılabilir. Her kapsam aynı sorguları destekler:

- [getHyperlinkClicks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) tıklama eylemi olan kapsayıcıları döndürür.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) fare‑üzerinde eylemi olan kapsayıcıları döndürür.
- [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) her iki eylemi de veya birini içeren kapsayıcıları döndürür.

Bu örnek, bir şekle ve metnine tıklama ve fare‑üzerinde eylemleri ile ayrı bir düğmeye makro eylemi atar. [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) tarafından döndürülen kapsayıcı sayısını her etkinleştirme türünün sayısıyla karşılaştırır. Metin‑çerçeve sorgusu sadece metindeki bağlantıları sayar. İçeren şeklin kendi eylemleri slayt ve sunum sorgularında görünür.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function printQueryCounts($scope, $queries) {
    $clickCount = java_values($queries->getHyperlinkClicks()->size());
    $mouseOverCount = java_values($queries->getHyperlinkMouseOvers()->size());
    $anyCount = java_values($queries->getAnyHyperlinks()->size());
    echo "$scope: click=$clickCount, mouse-over=$mouseOverCount, any=$anyCount" . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $destination = $presentation->getSlides()->addEmptySlide($slide->getLayoutSlide());
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Click the text to go to slide 2");
    $shape->getHyperlinkManager()->setExternalHyperlinkClick("https://example.com/");
    $shape->getHyperlinkClick()->setTooltip("Public website");
    $shape->getHyperlinkManager()->setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    $portionFormat = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->getHyperlinkManager()->setInternalHyperlinkClick($destination);
    $portionFormat->getHyperlinkManager()->setExternalHyperlinkMouseOver("https://example.com/help");
    $macroButton = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
    $macroButton->getHyperlinkManager()->setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", $presentation->getHyperlinkQueries());
    printQueryCounts("Slide 1", $slide->getHyperlinkQueries());
    printQueryCounts("Text frame", $shape->getTextFrame()->getHyperlinkQueries());
    $presentation->save("hyperlink-audit-input.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Bu örnek için, sunum ve slayt sorguları her biri üç tıklama kapsayıcısı, iki fare‑üzerinde kapsayıcısı ve toplam üç kapsayıcı rapor eder. Metin‑çerçeve sorgusu her kategori için bir kapsayıcı raporlar.

### **Eylemleri ve Hedefleri Sınıflandır**

Bir eylemi yorumlamadan önce hedefi yorumlamak için [Hyperlink::getActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getactiontype/) yöntemini kullanın. [HyperlinkActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkactiontype/) değerleri, sadece web gezinmesinden daha fazlasını kapsar:

| Değerler | Denetim için Anlam |
| --- | --- |
| `Hyperlink` | Harici köprü; URL'yi ve şemasını inceleyin. |
| `JumpSpecificSlide` | Belirli bir slayta iç içe gezinme. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Yerleşik slayt gösterisi gezinmesi, slayt gösterisi bağlamında çözülür. |
| `JumpEndShow`, `StartCustomSlideShow` | Mevcut gösteriyi sonlandır veya özel bir gösteri başlat. |
| `StartMacro` | Bir makroyu çalıştır. |
| `StartProgram` | Bir programı başlat. |
| `OpenFile`, `OpenPresentation` | Bir dosya veya başka bir sunumu aç; web URL'lerinden ayrı incele. |
| `StartStopMedia` | Medya oynatımını başlat veya durdur. |
| `NoAction`, `Unknown` | Gezİnme eylemi yok veya tanınmayan eylem; inceleme gerektirir. |

Harici hedefleri [getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/) ile, belirli iç hedefleri ise [getTargetSlide](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettargetslide/) ile okuyun. İç eylemler ve yerleşik komutlar dış URL içermeyebilir; boş bir URL, kapsayıcının eylemi olmadığı anlamına gelmez. Normalleştirilmiş URL'den farklıysa, [getExternalUrlOriginal](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) tarafından döndürülen değeri koruyun ve mevcutsa [getTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettooltip/) tarafından döndürülen ipucunu da ekleyin.

### **Raporla, Temizle ve Köprüleri Doğrula**

Bu örnek, bir önceki örnekten sunumu açar ve her eylem için bir JSON kaydı yazar. Normal slaytların yanı sıra ana sayfalar, düzenler ve notlar, varsa not ve el ilanı ana sayfaları dahil olmak üzere [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) ile kapsayıcıları toplar. Her kapsayıcıyı yalnızca bir kez saymak için referans eşitliğini kullanır, aşağıda açıklanan politikayı uygular ve kaydedilen sunumu yeniden açarak hem tıklama hem de fare‑üzerinde eylemleri kontrol eder.

Rapor, mevcut olduğunda bir‑tabanlı slayt indeksini ve [getSlideId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideId--) değerini kaydeder. [ISlideComponent::getSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islidecomponent/#getSlide--) desteklenen kapsayıcılar için sahip slaytı sağlar. Ana sayfalar, düzenler ve notlar normal slayt indeksine sahip değildir ve kapsamlarıyla tanımlanır. Şekil kapsayıcıları ve metin‑bölümü biçimlendirme kapsayıcıları ayrı ayrı etiketlenir; diğer kapsayıcı türleri çalışma zamanı tip adılarını korur. Her kapsayıcı, iki eylemin ilişkilendirilebilmesi için rapor‑yerel bir kimlik alır. Rapor, eylem türlerini PHP enum'unda tanımlı tam sayı sabitleri olarak saklar.

Bu kısıtlayıcı uygulama politikası, yalnızca mutlak HTTPS URL'lerini ve geçerli iç slayt hedeflerini kabul eder. Makroları, programları, dosya eylemlerini, diğer slayt gösterisi eylemlerini, bilinmeyen eylemleri ve diğer URL şemalarını reddeder. Bunlar politika kararlarıdır, Aspose.Slides güvenlik kararı değildir. HTTPS yalnız başına güven oluşturmaz: uygulamanız için host izin listeleri ve ek kontroller ekleyin. Hem orijinal hem de normalleştirilmiş dış URL'ler kontrol edilir. Örnek, bağlantıları takip etmeden veya eylemleri çalıştırmadan meta verileri denetler.

Düzeltme için, kapsayıcının [getHyperlinkManager](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) aşağıdaki yöntemleri destekler: [setExternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/), [removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/), ve [removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/). Burada, yasak dış tıklama linkleri sabit bir HTTPS açılış sayfasıyla değiştirilir; diğer yasak tıklamalar ve yasak fare‑üzerinde eylemler bağımsız olarak kaldırılır. `$replaceExternalClicks` değişkenini `false` yaparak tüm politika ihlallerini kaldırabilirsiniz. Dağıtımdan önce uygulama‑sahibi bir değiştirme sayfası seçin.

Raporun dışa aktarım bayrağı, temkinli bir PDF inceleme politikası kullanır: fare‑üzerinde eylemleri ve dış link olmayan ya da belirli slayt atlaması olmayan her şeyi potansiyel olarak desteklenmeyen olarak işaretler. Bu bir inceleme ipucu olup, bir yetenek testi ya da işaretlenmemiş linklerin dışa aktarımda hayatta kalacağı garantisi değildir. Desteklenen [PDF](/slides/tr/php-java/convert-powerpoint-to-pdf/) ve [HTML](/slides/tr/php-java/convert-powerpoint-to-html/) dışa aktarımları, eyleme, dışa aktarma seçeneklerine ve izleyiciye bağlı olarak köprüleri koruyabilir. Raster [images](/slides/tr/php-java/convert-powerpoint-to-png/) ve [video](/slides/tr/php-java/convert-powerpoint-to-video/) interaktif köprüleri koruyamaz; bu çıktılar için denetleme yaparken her eylemi işaretleyin.

```php
use aspose\slides\HyperlinkActionType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class HyperlinkAudit {
    public function slideIndex($presentation, $slide) {
        if (java_is_null($slide)) return null;
        for ($index = 0; $index < java_values($presentation->getSlides()->size()); $index++) {
            if (java_values($presentation->getSlides()->get_Item($index)->equals($slide))) return $index + 1;
        }
        return null;
    }

    public function isHttps($value) {
        if ($value === null || $value === '') return false;
        $parts = parse_url($value);
        return $parts !== false && isset($parts['scheme'], $parts['host']) && strcasecmp($parts['scheme'], 'https') === 0 && $parts['host'] !== '';
    }

    public function policyViolation($link) {
        if (java_is_null($link)) return null;
        $action = java_values($link->getActionType());
        if ($action === HyperlinkActionType::JumpSpecificSlide) {
            return java_is_null($link->getTargetSlide()) ? 'Missing target slide' : null;
        }
        if ($action !== HyperlinkActionType::Hyperlink) return 'Action is not allowed';
        if (!$this->isHttps(java_values($link->getExternalUrl()))) return 'Normalized URL is not absolute HTTPS';
        $original = java_values($link->getExternalUrlOriginal());
        if ($original !== null && $original !== '' && !$this->isHttps($original)) return 'Original URL is not absolute HTTPS';
        return null;
    }

    public function addScope(&$found, $slide) {
        if (!java_is_null($slide)) {
            foreach ($slide->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
                $found[] = $container;
            }
        }
    }

    public function collectContainers($presentation) {
        $found = [];
        foreach ($presentation->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $found[] = $container;
        }
        $masters = $presentation->getMasters();
        for ($index = 0; $index < java_values($masters->size()); $index++) {
            $this->addScope($found, $masters->get_Item($index));
        }
        $layouts = $presentation->getLayoutSlides();
        for ($index = 0; $index < java_values($layouts->size()); $index++) {
            $this->addScope($found, $layouts->get_Item($index));
        }
        $slides = $presentation->getSlides();
        for ($index = 0; $index < java_values($slides->size()); $index++) {
            $this->addScope($found, $slides->get_Item($index)->getNotesSlideManager()->getNotesSlide());
        }
        $this->addScope($found, $presentation->getMasterNotesSlideManager()->getMasterNotesSlide());
        $this->addScope($found, $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide());
        $seen = new Java('java.util.IdentityHashMap');
        $unique = [];
        foreach ($found as $container) {
            if (!java_values($seen->containsKey($container))) {
                $seen->put($container, true);
                $unique[] = $container;
            }
        }
        return $unique;
    }

    public function addRow(&$rows, $presentation, $link, $activation, $container, $containerId) {
        if (java_is_null($link)) return;
        $ownerSlide = java_instanceof($container, java('com.aspose.slides.ISlideComponent')) ? $container->getSlide() : null;
        $targetSlide = $link->getTargetSlide();
        $violation = $this->policyViolation($link);
        $ownerType = java_instanceof($container, java('com.aspose.slides.IShape')) ? 'Shape' : (java_instanceof($container, java('com.aspose.slides.IPortionFormat')) ? 'Text portion' : java_values($container->getClass()->getSimpleName()));
        $action = java_values($link->getActionType());
        $ordinaryAction = $action === HyperlinkActionType::Hyperlink || $action === HyperlinkActionType::JumpSpecificSlide;
        $externalUrl = java_values($link->getExternalUrl());
        $originalUrl = java_values($link->getExternalUrlOriginal());
        $rows[] = [
            'ContainerId' => $containerId,
            'SlideIndex' => $this->slideIndex($presentation, $ownerSlide),
            'SlideId' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getSlideId()),
            'Scope' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getClass()->getSimpleName()),
            'OwnerType' => $ownerType,
            'Activation' => $activation,
            'ActionType' => $action,
            'ExternalUrl' => $externalUrl,
            'TargetSlideIndex' => $this->slideIndex($presentation, $targetSlide),
            'TargetSlideId' => java_is_null($targetSlide) ? null : java_values($targetSlide->getSlideId()),
            'Tooltip' => java_values($link->getTooltip()),
            'OriginalExternalUrl' => $originalUrl === $externalUrl ? null : $originalUrl,
            'PotentiallyUnsafe' => $violation !== null,
            'PolicyViolation' => $violation,
            'TargetExport' => 'PDF',
            'PotentiallyUnsupportedByExport' => $activation === 'mouse-over' || !$ordinaryAction
        ];
    }
}

$replaceExternalClicks = true;
$replacementUrl = 'https://example.com/blocked-link';
$audit = new HyperlinkAudit();
$presentation = new Presentation('hyperlink-audit-input.pptx');
try {
    $containers = $audit->collectContainers($presentation);
    $rows = [];
    foreach ($containers as $index => $container) {
        $audit->addRow($rows, $presentation, $container->getHyperlinkClick(), 'click', $container, $index + 1);
        $audit->addRow($rows, $presentation, $container->getHyperlinkMouseOver(), 'mouse-over', $container, $index + 1);
    }
    $json = json_encode($rows, JSON_PRETTY_PRINT | JSON_UNESCAPED_SLASHES);
    if ($json === false) {
        echo 'Unable to encode the audit report: ' . json_last_error_msg() . PHP_EOL;
    } elseif (file_put_contents('hyperlink-audit.json', $json . PHP_EOL) === false) {
        echo 'Unable to write the audit report.' . PHP_EOL;
    } else {
        foreach ($containers as $container) {
            $click = $container->getHyperlinkClick();
            if ($audit->policyViolation($click) !== null) {
                if ($replaceExternalClicks && java_values($click->getActionType()) === HyperlinkActionType::Hyperlink) {
                    $container->getHyperlinkManager()->setExternalHyperlinkClick($replacementUrl);
                } else {
                    $container->getHyperlinkManager()->removeHyperlinkClick();
                }
            }
            if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) {
                $container->getHyperlinkManager()->removeHyperlinkMouseOver();
            }
        }
        $presentation->save('hyperlink-sanitized.pptx', SaveFormat::Pptx);

        $reopened = new Presentation('hyperlink-sanitized.pptx');
        try {
            $remainingContainers = $audit->collectContainers($reopened);
            $violations = 0;
            foreach ($remainingContainers as $container) {
                if ($audit->policyViolation($container->getHyperlinkClick()) !== null) $violations++;
                if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) $violations++;
            }
            echo 'Audit rows: ' . count($rows) . '; prohibited actions after reopening: ' . $violations . PHP_EOL;
            if ($violations !== 0) {
                echo 'Verification failed: do not distribute the saved presentation.' . PHP_EOL;
            }
        } finally {
            $reopened->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

Yukarıdaki girdiyle rapor beş eylem satırı içerir. Dosya fare‑üzerinde linki ve makro tıklaması kaldırılır, HTTPS linkleri ve iç slayt gezinmeleri kalır. Doğrulama, hiçbir yasak eylem olmadığını yazdırır. Yasak dış tıklama URL'si içeren bir girdi, değiştirme dalını da çalıştırır. İzin verilen bir tıklama ve yasak bir fare‑üzerinde eylemi olan bir kapsayıcı, tıklama eylemini tutar.

Bu seçici temizlik, [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) yönteminin politikadan bağımsız olarak seçili kapsamda iki etkinleştirme türünü de kaldırmasından farklıdır. Buradaki doğrulama yalnızca köprü eylemlerini kontrol eder; gömülü VBA projelerini, OLE nesnelerini veya diğer aktif içerikleri kaldırmaz ve dışa aktarılan PDF veya HTML dosyasını doğrulamaz.

## **SSS**

**Bir bölüme ya da bölümün ilk slaytına nasıl bağlanabilirim?**

PowerPoint bölümleri slaytları gruplayarak düzenler, ancak dahili bir köprü bireysel bir slayta hedeflenir. Bir bölüme gezinme oluşturmak için, o bölümün ilk slaytına bağlanın.

**Ana sayfa slayt öğelerine köprü ekleyebilir miyim, böylece tüm slaytlarda çalışır?**

Evet. Ana sayfa slaytı ve düzen öğeleri köprüleri destekler. Bu öğelerdeki köprüler, ilgili ana sayfa veya düzeni kullanan slayt gösterisi sırasında kullanılabilir.

**Köprüler PDF, HTML, görüntüler veya video olarak dışa aktarıldığında korunur mu?**

Desteklenen PDF ve HTML dışa aktarımları köprüleri koruyabilir; raster görüntüler ve video koruyamaz. Ayrıntılar için [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) bölümündeki dışa aktarma hususlarına bakın.