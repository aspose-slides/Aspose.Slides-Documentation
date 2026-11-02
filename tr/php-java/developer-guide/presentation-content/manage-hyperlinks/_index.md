---
title: PHP'de Sunum Hiperlinklerini Yönet
linktitle: Hiperlinkleri Yönet
type: docs
weight: 20
url: /tr/php-java/manage-hyperlinks/
keywords:
- URL ekle
- hiperlink ekle
- hiperlink oluştur
- hiperlink biçimlendir
- hiperlink kaldır
- hiperlink güncelle
- metin hiperlinki
- slayt hiperlinki
- şekil hiperlinki
- resim hiperlinki
- video hiperlinki
- değiştirilebilir hiperlink
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PHP örnekleriyle PowerPoint ve OpenDocument sunumlarında hiperlinkleri ekleyin, biçimlendirin, güncelleyin ve kaldırın."
---
## **Giriş**

Bir köprü (hiperlink), sunum içeriğini bir web sitesine ya da sunum içindeki bir konuma bağlar. PowerPoint'te hiperlinkler genellikle iki amaçla kullanılır:

* Metinden, bir şekilden ya da bir medya çerçevesinden bir web sitesini açmak.
* Başka bir slayta gitmek, örneğin bir içerik tablosundan.

Aspose.Slides for PHP via Java, bu bağlantıları eklemenize, görünüm ve sesini kontrol etmenize, özelliklerini güncellemenize ve kaldırmanıza olanak tanır. Aşağıdaki örnekler, bireysel öğelerdeki hiperlinklerle nasıl çalışılacağını ve sunum, slayt veya metin çerçevesi düzeyinde hiperlinklere nasıl erişileceğini gösterir. PHP/Java Bridge ve Aspose.Slides PHP sarmalayıcısının başlatıldığını varsayar. PHP referans sayfası bağlantısı olmayan API üyeleri, altında yatan Java API'sine yönlendirilir.

{{% alert color="info" title="Note" %}}
Sunumları ayrıca [ücretsiz çevrimiçi Aspose PowerPoint düzenleyicisi](https://products.aspose.app/slides/editor) ile düzenleyebilirsiniz.
{{% /alert %}} 

## **URL Hiperlinkleri Ekle**

Bir web sitesi URL'sini metne, bir şekle veya bir medya çerçevesine atayabilirsiniz. Hiperlinki atadığınız öğe, tıklanabilir alanı belirler: bir metin bölümü seçilen metni, şekil veya çerçeve ise slayt nesnesini bağlar.

For presentations containing relative hyperlinks, see [Hyperlink Temelini Yönet](/slides/tr/php-java/presentation-properties/#manage-the-hyperlink-base) to read, change, or clear the document-level base.

### **Metne URL Hiperlinkleri Ekle**

Metni bir web sitesine bağlamak için, aşağıda gösterildiği gibi bir [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) nesnesini metin bölümünün [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/sethyperlinkclick/) metoduna iletin. Yalnızca o metin bölümü tıklanabilir olur.

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

### **Şekillere ve Medya Çerçevelerine URL Hiperlinkleri Ekle**

Bir şekli ya da çerçeveyi tıklanabilir yapmak için, onun [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/shape/sethyperlinkclick/) metodunu çağırın. Hiperlink, içindeki bir metin bölümüne değil, nesnenin kendisine aittir.

Aynı yaklaşım resim, ses ve video çerçevelerine de uygulanır: hiperlinki çerçeveye atayın ve gerekirse [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) metodunu çağırın.

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

## **İçindekiler Tablosu Oluşturmak İçin Hiperlinkleri Kullan**

Dahili hiperlinkler, okuyucuların içindekiler tablosundan belirli bir slayta atlamasını sağlar. Aşağıdaki örnek, ilk slaydın “Sayfa 2” metnini ikinci slayta bağlamak için [setInternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) metodunu kullanır.

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

## **Hiperlinkleri Biçimlendir**

### **Renk**

[Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) sınıfının [setColorSource](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setcolorsource/) metodu, bir hiperlinkin sunumun hiperlink rengini mi yoksa metin bölümünün biçimlendirmesini mi kullanacağını belirler. Özel bir metin rengi uygulamak için [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkcolorsource/) seçin ve bölümün dolgu rengini ayarlayın. Bu özellik PowerPoint 2019'da tanıtıldı; eski sürümler bu ayarı uygulamaz.

Aşağıdaki örnek aynı slayta iki metin hiperlinki ekler. İlkinde kırmızı bir metin dolgu rengi kullanılırken, ikincisi varsayılan hiperlink rengini korur.

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

Bir hiperlink etkinleştirildiğinde ses çalabilir ya da halihazırda çalan bir sesi durdurabilir. Bu davranışları yapılandırmak için aşağıdaki yöntemleri kullanın:

- [Hyperlink::setSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setsound/) hiperlinke bağlı ses dosyasını belirler.
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setstopsoundonclick/) hiperlinkin etkinleştirilmesinin önceki sesi durdurup durdurmayacağını kontrol eder.

#### **Bir Hiperlink Sesini Ekle**

Aşağıdaki örnek `sampleaudio.wav` dosyasını yükler ve ilk slaydın üzerindeki bir düğmeye atar. Düğmeye tıklamak sesi çalar ve bir sonraki slayta geçer. Aynı slayttaki ikinci bir şekil, tıklandığında önceki sesi durdurur ve herhangi bir gezinme işlemi yapmaz.

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

#### **Bir Hiperlink Sesini Çıkar**

Aşağıdaki örnek, yukarıda oluşturulan sunumu açar ve ilk şeklin hiperlink sesini, [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getsound/) ve [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/) metodlarıyla belleğe okur.

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

### **Araç İpucu ve Etkileşim Ayarları**

Metne veya bir şekle hiperlink atadıktan sonra aşağıdaki [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) metodlarını çağırabilirsiniz:

- [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) bir izleyicinin bağlantı için ipucu olarak gösterebileceği metni ayarlar.
- [setTargetFrame](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settargetframe/) uygulanabilir olduğunda, bir üst HTML çerçeve kümesindeki hedef çerçeveyi belirtir.
- [setHistory](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethistory/) bağlantıyı etkinleştirmenin, hedefini görüntülenen hiperlinkler listesine ekleyip eklemeyeceğini kontrol eder.
- [setHighlightClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethighlightclick/) tıklandığında hiperlinkin vurgulanıp vurgulanmayacağını kontrol eder.

## **Sunumlardan Hiperlinkleri Kaldır**

[getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) metodunu, değiştirmeden önce metin bölümü bağlantıları da dahil olmak üzere hiperlink kapsayıcıları toplamak için kullanın. Aşağıdaki örnek, ilk slayttan her iki etkinleştirme türünü de kaldırır. Yalnızca bir türü kaldırmak için sadece [removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) ya da [removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/) metodunu çağırın; bir tıklama eylemini kaldırmak, onun fare üzeri eylemini kaldırmaz.

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

Koşulsuz kaldırma için, [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) seçilen kapsamda her iki etkinleştirme türünü tek bir çağrıda kaldırır. Seçici temizlik ve ana slaytlar, düzenler ve notlar için kapsamı görmek için [Hiperlinkleri Raporla, Temizle ve Doğrula](#report-sanitize-and-verify-hyperlinks) bölümüne bakın.

## **Tam Bir Hiperlink Envanteri Oluştur**

Bir sunumu dağıtmadan önce, etkileşimli eylemlerini ve web bağlantılarını envantere almanız gerekir. [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) metodu, URL dizileri yerine [IHyperlinkContainer](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/) nesnelerini döndürür. Her kapsayıcıda hem [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) hem de [getHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) yöntemlerini inceleyin. Bunlar bağımsızdır: aynı kapsayıcı her iki eylemi de ortaya çıkarabilir, bu yüzden tam bir rapor için kapsayıcı başına iki satıra kadar gerek duyulabilir.

Sadece şekil düzeyindeki hiperlinkleri taramak, metin bölümlerine eklenen bağlantıları kaçırabilir. Bunun yerine uygun kapsamı sorgulayın ve daha sonra eylemlerini güncelleyebilmek veya kaldırabilmek için döndürülen kapsayıcıları saklayın.

### **Sunum, Slayt ve Metin-Çerçeve Kapsamlarını Sorgula**

[HyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/) sınıfı, [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/gethyperlinkqueries/), [IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) ve [TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/gethyperlinkqueries/) aracılığıyla kullanılabilir. Her kapsam aynı sorguları destekler:

- [getHyperlinkClicks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) tıklama eylemi olan kapsayıcıları döndürür.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) fare üzeri eylemi olan kapsayıcıları döndürür.
- [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) bir veya her iki eylemi de olan kapsayıcıları döndürür.

Aşağıdaki örnek, dış bir tıklama bağlantısı, dosya fare üzeri bağlantısı, iç slayt gezinmesi, metin fare üzeri bağlantısı ve bir makro eylemi içeren `hyperlink-audit-input.pptx` dosyasını oluşturur. Bu eylemler çalıştırılmaz. Aynı üç sorgu her kapsamda çalışır; sayılar kapsayıcıları tanımlar, eylem toplamlarını değil. Metin-çerçeve kapsamı, içinde bulunduğu şeklin kendi bağlantılarını dışarıda bırakır.

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

Bu örnek için, sunum ve slayt sorguları sırasıyla üç tıklama kapsayıcısı, iki fare üzeri kapsayıcısı ve bir eylemi olan üç kapsayıcı raporlar. Metin-çerçeve sorgusu her kategoride bir kapsayıcı raporlar.

### **Eylemleri ve Hedefleri Sınıflandır**

[Hyperlink::getActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getactiontype/) metodunu, bir eylemi hedefi yorumlamadan önce yorumlamak için kullanın. [HyperlinkActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkactiontype/) değerleri web gezinmesinden daha fazlasını kapsar:

| Değerler | Denetim için Anlamı |
| --- | --- |
| `Hyperlink` | Harici hiperlink; URL ve şemasını inceleyin. |
| `JumpSpecificSlide` | Belirli bir slayta iç gezinme. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Yerleşik slayt gösterisi gezinmesi, slayt gösterisi bağlamında çözülür. |
| `JumpEndShow`, `StartCustomSlideShow` | Mevcut gösteriyi sonlandırır veya özel bir gösteri başlatır. |
| `StartMacro` | Bir makroyu çalıştırır. |
| `StartProgram` | Bir program başlatır. |
| `OpenFile`, `OpenPresentation` | Bir dosya veya başka bir sunumu açar; web URL'lerinden ayrı olarak incelenmelidir. |
| `StartStopMedia` | Medya oynatımını başlatır veya durdurur. |
| `NoAction`, `Unknown` | Gezinti eylemi yok veya gözden geçirme gerektiren tanınmayan bir eylem. |

[getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/) ile dış hedefleri, [getTargetSlide](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettargetslide/) ile belirli iç hedefleri okuyun. İç eylemler ve yerleşik komutlar dış URL içermeyebilir; boş bir URL, kapsayıcının eylemi olmadığı anlamına gelmez. Normalleştirilmiş URL'den farklı olduğunda [getExternalUrlOriginal](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) tarafından döndürülen değeri koruyun ve mevcut olduğunda [getTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettooltip/) tarafından döndürülen araç ipucunu ekleyin.

### **Hiperlinkleri Raporla, Temizle ve Doğrula**

Aşağıdaki PHP örneği, mevcut bir sunumu okur (yukarıda oluşturulan dosyayı kullanın), `hyperlink-audit.json` dosyasını yazar, bir politika uygular, `hyperlink-sanitized.pptx` olarak kaydeder ve her iki etkinleştirme türünü tekrar kontrol etmek üzere yeniden açar. Kapsayıcıları değiştirmeden önce toplar ve aynı kapsayıcının iki kez işlenmesini önlemek için referans eşitliğini kullanır. Sunum sorguları normal slaytları kapsar; paket genelinde bir envanter için ayrıca ana slaytları, düzenleri, notları ve mevcut olduğunda not ve el ilanı ana slaytlarını açıkça sorgular.

Rapor, mevcut olduğunda bir‑bazlı slayt indeksini ve [getSlideId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideId--) değerini kaydeder. [ISlideComponent::getSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islidecomponent/#getSlide--) desteklenen kapsayıcıların sahip olduğu slaytı sağlar. Ana slaytlar, düzenler ve notlar normal bir slayt indeksine sahip değildir ve kapsamlarıyla tanımlanır. Şekil kapsayıcıları ve metin bölümü biçimlendirme kapsayıcıları ayrı ayrı etiketlenir; diğer kapsayıcı türleri çalışma zamanı tip adını korur. Her kapsayıcı, iki eylemini ilişkilendirmek için rapor içinde yerel bir kimlik alır. Rapor, eylem türlerini PHP enum'ı tarafından tanımlanan tamsayı sabitleri olarak saklar.

Bu bilinçli şekilde kısıtlayıcı uygulama politikası, yalnızca mutlak HTTPS URL'lerini ve geçerli iç slayt hedeflerini kabul eder. Makroları, programları, dosya eylemlerini, diğer slayt gösterisi eylemlerini, bilinmeyen eylemleri ve diğer URL şemalarını reddeder. Bu reddetmeler politika kararlarıdır, Aspose.Slides güvenlik kararı değildir. Tek başına HTTPS güven oluşturmaz: uygulamanız için sunucu beyaz listeleri ve diğer kontroller ekleyin. Hem orijinal hem de normalleştirilmiş dış URL'ler kontrol edilir. Örnek, bağlantıları takip etmeden veya eylemleri çalıştırmadan meta verileri denetler.

Kurtarma için, kapsayıcının [getHyperlinkManager](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) metodu, [setExternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/), [removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) ve [removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/) yöntemlerini destekler. Burada, yasaklanan dış tıklama bağlantıları sabit bir HTTPS hedef sayfası ile değiştirilir; diğer yasak tıklama ve yasak fare üzeri eylemleri bağımsız olarak kaldırılır. Tüm politika ihlallerini kaldırmak için `$replaceExternalClicks` değerini `false` olarak ayarlayın. Dağıtıma geçmeden önce uygulamaya ait bir değiştirme sayfası seçin.

Raporun dışa aktarma bayrağı, temkinli bir PDF gözden geçirme politikası kullanır: fare üzeri eylemler ve harici bağlantı veya belirli slayt atlaması olmayan her şeyi potansiyel olarak desteklenmeyen olarak işaretler. Bu bir inceleme ipucudur, yetenek testi ya da işaretsiz bağlantıların dışa aktarımda kalacağı garantisi değildir. Desteklenen [PDF](/slides/tr/php-java/convert-powerpoint-to-pdf/) ve [HTML](/slides/tr/php-java/convert-powerpoint-to-html/) dışa aktarımları, eyleme, dışa aktarma seçeneklerine ve görüntüleyiciye bağlı olarak hiperlinkleri koruyabilir. Raster [görüntüler](/slides/tr/php-java/convert-powerpoint-to-png/) ve [video](/slides/tr/php-java/convert-powerpoint-to-video/) etkileşimli hiperlinkleri koruyamaz; bu çıktıların denetimi sırasında her eylemi işaretleyin.

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

Yukarıda oluşturulan girdi ile rapor beş eylem satırı içerir. Dosya fare üzeri bağlantısı ve makro tıklaması kaldırılır, HTTPS bağlantıları ve iç slayt gezinmesi kalır. Doğrulama, sıfır yasak eylem yazdırır. Yasak bir dış tıklama URL'si içeren bir girdi, değiştirme dalını da çalıştırır. İzin verilen bir tıklama ve yasak bir fare üzeri içeren bir kapsayıcı, tıklama eylemini korur.

Bu seçici temizlik, politikadan bağımsız olarak seçilen kapsamda her iki etkinleştirme türünü de kaldıran [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) yönteminden farklıdır. Buradaki doğrulama yalnızca hiperlink eylemlerini denetler; gömülü VBA projelerini, OLE nesnelerini veya diğer aktif içeriği kaldırmaz ve dışa aktarılmış bir PDF veya HTML dosyasını doğrulamaz.

## **SSS**

**Bir bölüme ya da onun ilk slaytına nasıl bağlanabilirim?**

PowerPoint'teki bölümler slaytları gruplar, ancak iç hiperlink bir bireysel slaytı hedef alır. Bir bölüme gezinme oluşturmak için, o bölümün ilk slaytına bağlanın.

**Ana slayt unsurlarına bir hiperlink ekleyebilir miyim, böylece tüm slaytlarda çalışır?**

Evet. Ana slayt ve düzen unsurları hiperlinkleri destekler. Bu unsurlardaki bağlantılar, ilgili ana slaytı ya da düzeni kullanan slayt gösterisi sırasında kullanılabilir.

**PDF, HTML, görüntüler ya da video olarak dışa aktarırken hiperlinkler korunacak mı?**

Desteklenen PDF ve HTML dışa aktarımları hiperlinkleri koruyabilir; raster görüntüler ve video bunu yapamaz. Dışa aktarma hususlarını [Hiperlinkleri Raporla, Temizle ve Doğrula](#report-sanitize-and-verify-hyperlinks) bölümünde inceleyin.