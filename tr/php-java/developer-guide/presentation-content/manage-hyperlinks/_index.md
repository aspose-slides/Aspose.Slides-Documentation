---
title: PHP'de Sunum Köprülerini Yönetme
linktitle: Köprüleri Yönet
type: docs
weight: 20
url: /tr/php-java/manage-hyperlinks/
keywords:
- URL ekle
- Köprü ekle
- Köprü oluştur
- Köprüyü biçimlendir
- Köprü kaldır
- Köprüyü güncelle
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
description: "Aspose.Slides for PHP via Java kullanarak, PHP örnekleriyle PowerPoint ve OpenDocument sunumlarında köprü ekleme, biçimlendirme, güncelleme ve kaldırma."
---
## **Giriş**

Bir köprü, sunum içeriğini bir web sitesine ya da sunum içinde bir konuma bağlar. PowerPoint'te köprüler genellikle iki amaçla kullanılır:

* Metin, şekil ya da medya çerçevesinden bir web sitesini açmak.
* Örneğin bir içerik tablosundan diğer bir slayta geçiş yapmak.

Aspose.Slides for PHP via Java, bu bağlantıları eklemenize, görünüm ve seslerini kontrol etmenize, özelliklerini güncellemenize ve kaldırmanıza olanak tanır. Aşağıdaki örnekler, bireysel öğelerde köprülerle nasıl çalışılacağını ve köprülere sunum, slayt ya da metin‑çerçevesi seviyesinde nasıl erişileceğini gösterir. PHP/Java Bridge ve Aspose.Slides PHP sarmalayıcısının başlatıldığını varsayar. PHP referans sayfası olmayan API üyeleri, altındaki Java API'sine bağlanır.

{{% alert color="info" title="Note" %}}
Sunumları ayrıca [ücretsiz çevrimiçi Aspose PowerPoint düzenleyicisi](https://products.aspose.app/slides/tr/editor) ile düzenleyebilirsiniz.
{{% /alert %}} 

## **URL Köprüleri Ekleme**

Bir web sitesi URL'sini metne, bir şekle ya da bir medya çerçevesine atayabilirsiniz. Köprüyü atadığınız öğe, tıklanabilir alanı belirler: bir metin bölümü seçili metni, bir şekil ya da çerçeve ise slayt nesnesini bağlar.

### **Metne URL Köprüsü Ekleme**

Metni bir web sitesine bağlamak için, aşağıda gösterildiği gibi metin bölümünün [setHyperlinkClick](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portionformat/sethyperlinkclick/) yöntemine bir [Hyperlink](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlink/) geçirin. Yalnızca o metin bölümü tıklanabilir hâle gelir.

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

### **Şekillere ve Medya Çerçevelerine URL Köprüsü Ekleme**

Bir şekli ya da çerçeveyi tıklanabilir hâle getirmek için onun [setHyperlinkClick](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/sethyperlinkclick/) metodunu çağırın. Köprü, içinde metin bölümü bulunmasa dahi nesnenin kendisine aittir.

Aynı yaklaşım resim, ses ve video çerçevelerine de uygulanır: köprüyü çerçeveye atayın ve gerekirse [setTooltip](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlink/settooltip/) metodunu çağırın.

Aşağıdaki örnek bir dikdörtgeni tıklanabilir hâle getirir:

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

## **Köprüleri Kullanarak İçindekiler Tablosu Oluşturma**

İçindekiler tablosundan belirli bir slayta atlamak için dahili köprüler kullanılır. Aşağıdaki örnek, ilk slayttaki “Page 2” metnini ikinci slayta bağlamak için [setInternalHyperlinkClick](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) metodunu kullanır.

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

## **Köprüleri Biçimlendirme**

### **Renk**

[Hyperlink](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlink/) nesnesinin [setColorSource](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlink/setcolorsource/) yöntemi, köprünün sunumun köprü rengi mi yoksa metin bölümünün biçimlendirmesi mi kullanacağını belirler. Özel bir metin rengi uygulamak için [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlinkcolorsource/) seçilir ve bölümün dolgu rengi ayarlanır. Bu özellik PowerPoint 2019’da tanıtıldı; eski sürümler bu ayarı uygulamaz.

Aşağıdaki örnek aynı slayta iki metin köprüsü ekler. İlki kırmızı dolgu rengine, ikincisi ise varsayılan köprü rengine sahiptir.

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

Bir köprü etkinleştirildiğinde ses çalabilir ya da hâlihazırda çalmakta olan bir sesi durdurabilir. Bu davranışları yapılandırmak için aşağıdaki yöntemleri kullanın:

- [Hyperlink::setSound](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlink/setsound/) köprüye ilişkilendirilecek sesi belirtir.
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlink/setstopsoundonclick/) köprünün etkinleştirilmesinin önceki sesi durdurup durdurmayacağını denetler.

#### **Köprüye Ses Ekleme**

Aşağıdaki örnek `sampleaudio.wav` dosyasını yükler ve ilk slayttaki bir düğmeye ilişkilendirir. Düğmeye tıklandığında ses çalar ve sonraki slayta geçiş yapılır. Aynı slayttaki ikinci bir şekil, tıklandığında önceki sesi durdurur; ancak bir geçiş işlemi yapmaz.

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

#### **Köprü Sesini Çıkarma**

Aşağıdaki örnek, yukarıda oluşturulan sunumu açar ve ilk şeklin köprü sesini [getSound](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlink/getsound/) ve [getBinaryData](https://reference.aspose.com/slides/tr/php-java/aspose.slides/audio/getbinarydata/) yöntemleriyle belleğe okur.

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

Bir köprüyü metne veya şekle atadıktan sonra aşağıdaki [Hyperlink](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlink/) yöntemlerini çağırabilirsiniz:

- [setTooltip](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlink/settooltip/) izleyicinin bağlantı için ipucu olarak gösterebileceği metni ayarlar.
- [setTargetFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlink/settargetframe/) uygulanabildiğinde, ebeveyn HTML çerçeve kümesindeki hedef çerçeveyi belirtir.
- [setHistory](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlink/sethistory/) bağlantının etkinleştirilmesinin, görüntülenen köprüler listesine eklenip eklenmeyeceğini kontrol eder.
- [setHighlightClick](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlink/sethighlightclick/) köprünün tıklandığında vurgulanıp vurgulanmayacağını denetler.

## **Sunumlardan Köprüleri Kaldırma**

[getAnyHyperlinks](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) yöntemini kullanarak, değiştirmeden önce metin‑bölümü bağlantıları da dahil olmak üzere köprü kapsayıcılarını toplayın. Aşağıdaki örnek, ilk slayttan her iki etkinleştirme türünü de kaldırır. Yalnızca bir türü kaldırmak isterseniz, sadece [removeHyperlinkClick](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) ya da [removeHyperlinkMouseOver](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/) metodunu çağırın; bir tıklama eylemini kaldırmak, fare‑üzerine gelme eşdeğerini kaldırmaz.

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

Koşulsuz kaldırma için, [removeAllHyperlinks](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) yöntemi seçili kapsam içinde her iki etkinleştirme türünü tek bir çağrıyla temizler. Ustalar, yerleşimler ve notlar dahil olmak üzere kapsamlı temizleme ve kapsama için **[Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)** bölümüne bakın.

## **Tam Bir Köprü Envanteri Oluşturma**

Bir sunumu dağıtmadan önce, etkileşimli eylemlerini ve web bağlantılarını envantere alın. [getAnyHyperlinks](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) yöntemi, URL dizesi listesi yerine [IHyperlinkContainer](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlinkcontainer/) nesnelerini döndürür. Her kapsayıcıda hem [getHyperlinkClick](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) hem de [getHyperlinkMouseOver](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) incelenmelidir. Bunlar bağımsızdır: aynı kapsayıcı iki eylemi de barındırabilir; bu yüzden tam rapor, kapsayıcı başına iki satır gerektirebilir.

Yalnızca şekil‑seviyesindeki köprüleri taramak, metin bölümlerine eklenmiş bağlantıları kaçırabilir. Uygun kapsamı sorgulayın ve ardından dönen kapsayıcıları saklayarak daha sonra eylemlerini güncelleyebilir ya da kaldırabilirsiniz.

### **Sunum, Slayt ve Metin Çerçevesi Kapsamlarını Sorgulama**

[HyperlinkQueries](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlinkqueries/) sınıfı, [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/gethyperlinkqueries/), [IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) ve [TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/gethyperlinkqueries/) aracılığıyla kullanılabilir. Her kapsam aynı sorguları destekler:

- [getHyperlinkClicks](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) tıklama eylemi olan kapsayıcıları döndürür.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) fare‑üzerine gelme eylemi olan kapsayıcıları döndürür.
- [getAnyHyperlinks](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) bir veya iki eylemi de barındıran kapsayıcıları döndürür.

Aşağıdaki örnek, dış tıklama bağlantısı, dosya fare‑üzerine gelme bağlantısı, dahili slayt navigasyonu, metin fare‑üzerine gelme bağlantısı ve bir makro eylemi içeren `hyperlink-audit-input.pptx` dosyasını oluşturur. Bu eylemler yürütülmez. Aynı üç sorgu her kapsamda çalışır; sayılar kapsayıcıları, toplam eylem sayısını göstermez. Metin‑çerçeve kapsamı, içinde bulunulan şeklin kendi bağlantılarını dışarıda bırakır.

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

Bu örnek için, sunum ve slayt sorguları üç tıklama kapsayıcısı, iki fare‑üzerine gelme kapsayıcısı ve her iki eylemi de barındıran üç kapsayıcı raporlar. Metin‑çerçeve sorgusu her kategoride bir kapsayıcı raporlar.

### **Eylemleri ve Hedefleri Sınıflandırma**

Bir eylemi yorumlamadan önce hedefini yorumlamak için [Hyperlink::getActionType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlink/getactiontype/) yöntemini kullanın. [HyperlinkActionType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlinkactiontype/) değerleri web yönlendirmesinin ötesinde birçok durumu kapsar:

| Değerler | Denetim için Anlamı |
| --- | --- |
| `Hyperlink` | Harici köprü; URL ve şemasını inceleyin. |
| `JumpSpecificSlide` | Belirli bir slayta dahili yönlendirme. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Slayt gösterisi içinde yerleşik gezinme, slayt gösterisi bağlamında çözülür. |
| `JumpEndShow`, `StartCustomSlideShow` | Mevcut gösteriyi sonlandır veya özel bir gösteri başlat. |
| `StartMacro` | Bir makroyu çalıştır. |
| `StartProgram` | Bir program başlat. |
| `OpenFile`, `OpenPresentation` | Bir dosya ya da başka bir sunumu aç; web URL'lerinden ayrı olarak incelenir. |
| `StartStopMedia` | Medya oynatımını başlat veya durdur. |
| `NoAction`, `Unknown` | Navigasyon eylemi yok veya tanınmayan bir eylem; inceleme gerektirir. |

Harici hedefleri [getExternalUrl](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlink/getexternalurl/) ile, belirli dahili hedefleri ise [getTargetSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlink/gettargetslide/) ile alın. Dahili eylemler ve yerleşik komutlar harici bir URL içermeyebilir; boş bir URL, kapsayıcının eylemi olmadığı anlamına gelmez. Normalleştirilmiş URL'den farklıysa, [getExternalUrlOriginal](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) tarafından döndürülen değeri koruyun ve mevcutsa [getTooltip](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlink/gettooltip/) tarafından dönen ipucunu da ekleyin.

### **Köprüleri Raporla, Temizle ve Doğrula**

Aşağıdaki PHP örneği, varolan bir sunumu (yukarıda oluşturulan dosyayı) okur, `hyperlink-audit.json` yazar, bir politika uygular, `hyperlink-sanitized.pptx` olarak kaydeder ve ardından iki etkinleştirme türünü tekrar denetlemek için yeniden açar. Değiştirmeden önce kapsayıcıları toplar ve aynı kapsayıcıyı iki kez işlememek için referans eşitliğini kullanır. Sunum sorguları normal slaytları kapsar; paket çapında envanter için ayrıca ustalar, yerleşimler, notlar ve mevcut olduğunda not ve dağıtım ustaları da açıkça sorgulanır.

Rapor, bir‑bazlı slayt indeksini ve mümkünse [getSlideId](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibaseslide/#getSlideId--) değerini kaydeder. [ISlideComponent::getSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidecomponent/#getSlide--) desteklenen kapsayıcılar için sahip slaytı sağlar. Ustalar, yerleşimler ve notlar normal bir slayt indeksine sahip değildir ve kapsamlarıyla tanımlanır. Şekil kapsayıcıları ve metin‑bölümü biçimlendirme kapsayıcıları ayrı ayrı etiketlenir; diğer kapsayıcı tipleri çalışma zamanı tip adılarını korur. Her kapsayıcı, iki eylemin ilişkilendirilebilmesi için rapor‑yerel bir kimlik alır. Rapor, eylem türlerini PHP sayımının tanımladığı tam sayı sabitleri olarak saklar.

Bu kısıtlayıcı uygulama politikası yalnızca mutlak HTTPS URL'lerini ve geçerli dahili slayt hedeflerini kabul eder. Makroları, programları, dosya eylemlerini, diğer slayt gösterisi eylemlerini, bilinmeyen eylemleri ve diğer URL şemalarını reddeder. Bu reddetmeler politika kararlarıdır, Aspose.Slides güvenlik kararı değildir. HTTPS yalnız başına güvenilirlik sağlamaz: uygulamanız için host beyaz listeleri ve ek kontroller ekleyin. Hem orijinal hem de normalleştirilmiş dış URL'ler kontrol edilir. Örnek, bağlantıları takip etmeksizin veya eylemleri çalıştırmaksızın meta verileri denetler.

Düzeltme için, kapsayıcının [getHyperlinkManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) metodu, [setExternalHyperlinkClick](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/), [removeHyperlinkClick](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) ve [removeHyperlinkMouseOver](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/) yöntemlerini destekler. Burada, yasak dış tıklama bağlantıları sabit bir HTTPS giriş sayfası ile değiştirilir; diğer yasak tıklama ve yasak fare‑üzerine gelme eylemleri bağımsız olarak kaldırılır. Tüm politika ihlallerini kaldırmak için `$replaceExternalClicks` değişkenini `false` yapın. Dağıtıma almadan önce uygulamanıza ait bir değiştirme sayfası seçin.

Raporun dışa aktarım bayrağı, temkinli bir PDF inceleme politikası uygular: fare‑üzerine gelme eylemlerini ve dış bağlantı dışındaki her türlü eylemi potansiyel olarak desteklenmez olarak işaretler. Bu bir inceleme ipucu olup, bir yetenek testi ya da işaretlenmemiş bağlantıların dışa aktarımda korunacağı garantisi değildir. Desteklenen [PDF](/slides/tr/php-java/convert-powerpoint-to-pdf/) ve [HTML](/slides/tr/php-java/convert-powerpoint-to-html/) dışa aktarımları, eyleme, dışa aktarım seçeneklerine ve görüntüleyiciye bağlı olarak köprüleri koruyabilir. Raster [görüntüler](/slides/tr/php-java/convert-powerpoint-to-png/) ve [videolar](/slides/tr/php-java/convert-powerpoint-to-video/) etkileşimli köprüleri koruyamaz; bu çıktılar için denetim sırasında her eylemi işaretleyin.

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

Yukarıda oluşturulan girdiyi kullandığınızda, rapor beş eylem satırı içerir. Dosya fare‑üzerine gelme bağlantısı ve makro tıklaması kaldırılır, HTTPS bağlantıları ve dahili slayt navigasyonu ise korunur. Doğrulama sıfır yasaklı eylem yazdırır. Yasak bir dış tıklama URL'si içeren bir girdi, değiştirme dalını da çalıştırır. İzin verilen bir tıklama ve yasak bir fare‑üzerine gelme içeren bir kapsayıcı, tıklama eylemini korur.

Bu seçici temizlik, **[removeAllHyperlinks](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/)** yönteminin aksine, politika dikkate alınmadan seçili kapsam içinde her iki etkinleştirme türünü de kaldırmaz. Buradaki doğrulama yalnızca köprü eylemlerini kontrol eder; gömülü VBA projelerini, OLE nesnelerini veya diğer aktif içerikleri kaldırmaz ve dışa aktarılan PDF ya da HTML dosyasını doğrulamaz.

## **SSS**

**Bir bölüme ya da onun ilk slaytına nasıl bağlanabilirim?**

PowerPoint'te bölümler slaytları gruplar, ancak dahili bir köprü yalnızca tek bir slayta hedeflenir. Bir bölüme navigasyon oluşturmak için o bölümün ilk slaytına bağlayın.

**Usta slayt öğelerine köprü ekleyebilir miyim, böylece tüm slaytlarda çalışır?**

Evet. Usta slayt ve yerleşim öğeleri köprüleri destekler. Bu öğeler üzerindeki bağlantılar, ilgili ustayı ya da yerleşimi kullanan slayt gösterisi sırasında kullanılabilir.

**Köprüler PDF, HTML, görüntüler ya da video olarak dışa aktarıldığında korunur mu?**

Desteklenen PDF ve HTML dışa aktarımları köprüleri tutabilir; raster görüntüler ve videolar tutamaz. Ayrıntılar için **[Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)** bölümündeki dışa aktarma hususlarına bakın.