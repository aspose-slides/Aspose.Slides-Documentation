---
title: PHP'de Sunumları Verimli Bir Şekilde Birleştirin
linktitle: Sunumları Birleştir
type: docs
weight: 40
url: /tr/php-java/merge-presentation/
keywords:
- PowerPoint'ı birleştir
- sunumları birleştir
- slaytları birleştir
- PPT'yi birleştir
- PPTX'i birleştir
- ODP'yi birleştir
- PowerPoint'ı bir araya getir
- sunumları bir araya getir
- slaytları bir araya getir
- PPT'yi bir araya getir
- PPTX'i bir araya getir
- ODP'yi bir araya getir
- PHP
- Aspose.Slides
description: "PHP'de slaytları kopyalayarak, master ve düzenleri kontrol ederek, slayt içeriğini yeniden boyutlandırarak, bölümleri koruyarak ve korumalı veya büyük dosyaları işleyerek PowerPoint ve OpenDocument sunumlarını nasıl birleştireceğinizi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for PHP via Java, bir [Sunum](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) içindeki slaytları başka birine kopyalayarak sunumları birleştirir. Ana işlem, [SlideCollection::addClone()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/addclone/) metodudur; bu metod kaynak slaytın biçimlendirmesini koruyabilir veya kopyalanan slaytı hedef sunumdaki bir master ya da düzene ekleyebilir.

Bu makale en yaygın birleştirme senaryolarını kapsar:

- kaynak biçimlendirmesi korunarak tüm slaytların birleştirilmesi;
- seçili slaytların birleştirilmesi;
- hedef sunumdan bir master uygulanması;
- hedef sunumdan belirli bir düzen uygulanması;
- birleştirme öncesi farklı slayt boyutlarının normalleştirilmesi;
- kopyalanan slaytların bir bölüme eklenmesi;
- birden çok sunumun uçtan uca bir iş akışında birleştirilmesi;
- master’lar, kaynaklar, notlar, yorumlar, medya, yazı tipleri, parolalar, büyük dosyalar ve çoklu iş parçacığı konularının ele alınması.

## **Kaydırak Kopyalamanın Master ve Düzen Üzerindeki Etkileri**

Bir slayt görünümünün büyük bir kısmını düzeni ve master’ı belirler. Bu nedenle, seçtiğiniz kopyalama aşırı yüklemesi, birleştirilen slaytın hedef sunumda nasıl bütünleştirileceğini belirler.

[SlideCollection::addClone()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/addclone/) metodunu şu şekillerde kullanın:

- `addClone(sourceSlide)` — kaynak slaytın düzenini ve biçimlendirmesini korur. Gerekirse, kaynak master otomatik olarak hedef sunuma kopyalanabilir. Aspose.Slides, otomatik olarak kopyalanan master’ları izler; aynı kaynak master’ı kullanan tekrarlı slaytlar bu master’ın tekrar kopyalanmasına neden olmaz.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — kopyalanan slaytı belirli bir hedef [MasterSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslide/) üzerine ekler. Aspose.Slides, bu master altında düzen tipine veya adına göre eşleşen bir düzen arar.
- `addClone(sourceSlide, destinationLayout)` — kopyalanan slaytı doğrudan belirli bir hedef [LayoutSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslide/) üzerine ekler.

`addClone` aşırı yüklemesine verilen master veya düzen, **hedef** sunuma ait olmalıdır; kaynak sunuma ait olmamalıdır.

## **Tüm Sunumları Birleştir ve Kaynak Biçimlendirmesini Koru**

En basit birleştirme, kaynak sunumdaki her slaytı hedef sunuma kopyalar. Bu, içe aktarılan slaytların özgün tema, master ve düzen ilişkilerini koruması gerektiğinde uygundur.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Kaynak ve hedef farklı tasarımlar kullandığında ortaya çıkan sunum birden çok master içerebilir. Bu, kaynak biçimlendirmesinin kasıtlı olarak korunduğu durumlarda beklenen bir davranıştır.

## **Seçili Slaytları Birleştir**

Her slaytı kopyalamanız gerekmez. Aşağıdaki örnek, kaynak sunumdan yalnızca seçili slayt indekslerini içe aktarır.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $slideIndexes = [0, 2, 4];

        foreach ($slideIndexes as $index) {
            $destination->getSlides()->addClone($source->getSlides()->get_Item($index));
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-selected-slides.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Kullanıcı girişi veya dış yapılandırmadan gelen indeksleri kopyalamadan önce doğrulayın.

## **Hedef Master Kullanarak Slaytları Birleştir**

İçe aktarılan slaytların zaten hedef sunuma ait bir master’ı takip etmesi gerektiğinde, [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/addclone/) aşırı yüklemesini kullanın.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationMaster = $destination->getMasters()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationMaster, true);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-master.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Aspose.Slides, belirtilen master altında kaynak düzenin tipine veya adına göre uygun bir düzen seçer. Uygun bir düzen bulunmazsa ve `allowCloneMissingLayout` **true** ise, kaynak düzen kopyalanır ve slayt eklenebilir. **false** ise bir [PptxEditException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pptxeditexception/) fırlatılır.

Ek bir düzenin hedef master’a eklenmesini istemiyorsanız, birleştirmenin başarısız olmasını sağlamak için **false** değerini kullanın.

## **Belirli Bir Hedef Düzen Kullanarak Slaytları Birleştir**

İçe aktarılan slaytların kesinlikle belirli bir hedef düzeni kullanması gerektiğinde, [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/addclone/) aşırı yüklemesini kullanın.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationLayout = $destination->getLayoutSlides()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationLayout);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-layout.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Hedef düzenin uygulanması, kalıtılan düzen ilişkisini değiştirir; kaynak slayt içeriğini yeniden tasarlamaz. Kaynak ve hedef düzenlerin yer tutucu yapıları farklıysa, kalıtılan biçimlendirme ve yer tutucu davranışının uygun olduğunu doğrulamak için sonucu inceleyin.

## **Farklı Slayt Boyutlarına Sahip Sunumları Birleştir**

Farklı slayt boyutlarına sahip sunumlar birleştirilebilir, ancak bir slaytı farklı bir boyuta sahip bir sunuma kopyalamak, içeriği yeni tuval için otomatik olarak yeniden tasarlamaz. Şekiller bu nedenle kaydırılmış, beklenmedik şekilde ölçeklenmiş veya görünür slayt alanının dışına çıkmış görünebilir.

Pratik bir yaklaşım, kopyalamadan önce kaynak sunumun boyutunu yeniden ayarlamaktır. [SlideSize::setSize()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidesize/setsize/) yöntemi, slayt boyutlarını değiştirirken mevcut içeriği ölçeklendirebilir. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidesizescaletype/) ise içeriği istenen boyuta sığdıracak şekilde ölçeklendirir.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
        $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());
        $destinationWidth = java_values($destination->getSlideSize()->getSize()->getWidth());
        $destinationHeight = java_values($destination->getSlideSize()->getSize()->getHeight());

        if ($sourceWidth != $destinationWidth || $sourceHeight != $destinationHeight) {
            $source->getSlideSize()->setSize($destinationWidth, $destinationHeight, SlideSizeScaleType::EnsureFit);
        }

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-same-slide-size.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Yeniden boyutlandırma, bellek içindeki kaynak sunum nesnesini değiştirir. Orijinal kaynak sunumu başka işlemler için değiştirilmemiş olarak tutmanız gerekiyorsa, birleştirme için ayrı bir örnek açın.

## **Slaytları Bir Sunum Bölümüne Birleştir**

Temel slayt kopyalama döngüsü, kaynak sunumun bölüm hiyerarşisini yeniden oluşturmaz. Çıktıda bölümler önemliyse, hedef sunumda bölümler oluşturun veya seçin ve slaytları açıkça [addClone(Slide, Section)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/addclone/) ile bu bölümlere kopyalayın.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $importedSection = $destination->getSections()->appendEmptySection("Imported slides");

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $importedSection);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-section.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Kopyalanan slaytlar belirtilen hedef bölüme eklenir. Birkaç kaynak bölümünü korumak için, [Presentation::getSections](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation/#getSections) metoduyla bölümleri dolaşın, her kaynak bölümün mevcut slaytlarını [Section::getSlidesListOfSection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Section/#getSlidesListOfSection) ile alın, bölümleri hedefte yeniden oluşturun ve her dönen slaytı karşılık gelen hedef bölümüne kopyalayın. Boş bölümler ve yapısal değişiklikleri içeren tam bölüm‑enumerasyon örneği için [Slide Sections’ı Yönet](/slides/tr/php-java/slide-section/) sayfasına bakın.

## **Birden Çok Sunumu Güvenli Bir Şekilde Birleştir**

Aşağıdaki uçtan uca örnek, ilk sunumu hedef olarak kullanır, ek her bir kaynağın slayt boyutunu normalleştirir, her kaynağı yalnızca kopyalanırken açık tutar ve sonunda dosyayı bir kez kaydeder.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

$merged = new Presentation($inputFiles[0]);
try {
    $mergedWidth = java_values($merged->getSlideSize()->getSize()->getWidth());
    $mergedHeight = java_values($merged->getSlideSize()->getSize()->getHeight());

    for ($fileIndex = 1; $fileIndex < count($inputFiles); $fileIndex++) {
        $source = new Presentation($inputFiles[$fileIndex]);
        try {
            $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
            $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());

            if ($sourceWidth != $mergedWidth || $sourceHeight != $mergedHeight) {
                $source->getSlideSize()->setSize($mergedWidth, $mergedHeight, SlideSizeScaleType::EnsureFit);
            }

            foreach ($source->getSlides() as $slide) {
                $merged->getSlides()->addClone($slide);
            }
        } finally {
            $source->dispose();
        }
    }

    $merged->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $merged->dispose();
}
```

Bu, içe aktarılan slaytların kaynak biçimlendirmesini korumak için faydalı bir temel oluşturur. Çıktınız tek bir hedef tema kullanmalıysa, basit `addClone($slide)` çağrısını daha önce gösterilen uygun hedef‑master veya hedef‑düzen aşırı yüklemesiyle değiştirin.

## **Pratik Hususlar**

### **Master’lar, Düzenler ve Biçimlendirme Sadakati**

Varsayılan slayt kopyalama, gerekli bir kaynak master’ı otomatik olarak hedef sunuma getirebilir. Aspose.Slides, aynı master’ın tekrar tekrar kopyalanmasını önlemek için otomatik kopyalanan master’ları izleyen iç bir kayıt tutar. Manuel olarak kopyalanan master’lar bu kayıt tarafından izlenmez; bu nedenle master yapısı üzerinde kesin kontrol ihtiyacınız yoksa ön‑kopyalamaktan kaçının.

Aynı ada sahip iki master veya düzenin görsel olarak aynı olduğunu varsamamalısınız. Kurumsal bir şablon nihai görünümü kontrol ediyorsa, hedef master veya düzeni açıkça seçin ve birleştirmeden sonra sonucu doğrulayın.

### **Notlar ve Yorumlar**

Sunucu notları ve slayt yorumları slayt içeriğiyle ilişkilidir ve bir slayt kopyalandığında kopyalanır. Aspose.Slides ayrıca [sunum notları](/slides/tr/php-java/presentation-notes/) ve [sunum yorumları](/slides/tr/php-java/presentation-comments/) için özel API’ler sunar.

Not sayfası biçimlendirmesi önemliyse, birleştirilmiş sunumu doğrulayın; çünkü not master’ları sunum‑düzeyinde nesnelerdir ve kaynak dosyalar arasında farklılık gösterebilir. İnceleme iş akışları için, farklı yazarların veya şablonların dosyalarını birleştirdikten sonra yorum yazarlarını ve işlenmiş yorumları da kontrol edin.

### **Görüntüler, Ses, Video, OLE Nesneleri ve Dış Bağlantılar**

Slaytlar, görüntüler, gömülü ses, gömülü video ve OLE verileri gibi sunum‑düzeyinde kaynaklara referans verebilir. Sadece görünen şekilleri kopyalamak yerine slaytı tamamen kopyalayın; böylece Aspose.Slides, slaytın bu kaynaklarla ilişkisini korur.

Gömülü ve bağlanmış kaynakları farklı şekilde ele alın. Bağlanmış bir ses, video, OLE nesnesi veya köprü, dış hedefe bağımlı kalır; bir slaytı kopyalamak, dış bağlantıyı gömülü içeriğe dönüştürmez. Bağlantılı kaynak yollarını ve URL’leri, birleştirilen sunumun açılacağı ortamda test edin.

Aspose.Slides otomatik kopyalanan master’ları izlese de, bu farklı kaynak sunumlardan gelen aynı ikili kaynakların her zaman ayrıştırılacağı anlamına gelmez. Çıktı dosya boyutu önemliyse, birleştirilmiş paketi inceleyin ve sonucu ölçün; örtük ayrıştırmaya güvenmeyin.

### **Gömülü Yazı Tipleri ve Yazı Tipi Kullanılabilirliği**

Yazı tipleri sunum‑düzeyinde yönetilir. Tipografi farklı makinelerde tutarlı kalmalıysa, sadece slaytları kopyalamanın her gerekli yazı tipinin hedef ortamda mevcut olmasını garanti etmediğini varsamayın. Gömülü yazı tiplerini [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsmanager/getembeddedfonts/) ile inceleyebilir ve [Sunumlarda Yazı Tipi Gömme](/slides/tr/php-java/embedded-font/) bölümünde açıklandığı gibi gömme işlemini açıkça yönetebilirsiniz.

Ayrıca, kaynak dosyalarda kullanılan yazı tiplerini gömmek için izin verilip verilmediğini kontrol edin. Yazı tipi lisansları gömme hakkını kısıtlayabilir.

### **Parola Korumalı Sunumlar**

Parola korumalı bir kaynağın slaytları kopyalanmadan önce başarıyla açılması gerekir. Parolayı [LoadOptions::setPassword()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/setpassword/) ile sağlayın.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$source = new Presentation("protected.pptx", $loadOptions);
try {
    // Şifrelenmiş sunum üzerinde çalış.
} finally {
    $source->dispose();
}
```

Şifreli bir kaynağı açmak, aynı korumanın otomatik olarak hedef sunuma uygulanacağı anlamına gelmez. Gerekirse çıktının korumasını ayrı olarak yapılandırın.

### **Büyük Sunumlar ve Bellek Kullanımı**

Yüksek çözünürlüklü görüntüler, ses, video veya diğer büyük ikili nesneler içeren büyük sunumlar önemli miktarda bellek tüketebilir. [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) BLOB yönetimi ve geçici dosya kullanımını kontrol eder. PHP via Java’da büyük‑dosya örneği için [Sunumları Aç](/slides/tr/php-java/open-presentation/#open-large-presentations) sayfasına bakın.

Büyük dosyalar için mümkün olduğunca dosya yolu üzerinden yükleme tercih edin, her kaynak sunumu birleştirilince hemen serbest bırakın ve iş akışı kontrol noktaları gerektirmiyorsa ara sonuçları tekrar tekrar kaydetmekten kaçının.

### **İş Parçacığı Güvenliği**

[Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) örneklerini birden çok iş parçacığında aynı anda yüklemeyin, değiştirmeyin, kaydetmeyin veya kopyalamayın. Bu işlemler PHP via Java’da çok iş parçacıklı kullanım için desteklenmez. Paralel birleştirme işleri gerekiyorsa, her birini ayrı tek‑iş‑parçacıklı süreçlerde çalıştırın; her süreç kendi sunum örneklerini kullansın ve [Aspose.Slides çok‑iş‑parçacıklı rehberi](/slides/tr/php-java/multithreading/) izlesin.

## **SSS**

**Kaynak sunumların orijinal tasarımını nasıl korurum?**

[SlideCollection::addClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/addclone/) metodunu, hedef master veya düzen belirtmeden kullanın. Aspose.Slides, içe aktarılan slayt için gerekirse kaynak master’ı otomatik olarak kopyalayabilir.

**İçe aktarılan slaytların hedef temayı kullanmasını nasıl sağlarım?**

Hedef master kabul eden aşırı yüklemeyi kullanın. Master’ı kaynak değil, hedef sunumdan seçin. Aspose.Slides, her kaynak slaytı o master’ın uygun bir düzeniyle eşleştirmeye çalışır.

**Belirli bir hedef düzeni, bir hedef master yerine ne zaman kullanmalıyım?**

Her içe aktarılan slaytın bilinen tek bir düzen kullanması gerektiğinde belirli bir düzen kullanın. Master kullanıldığında, Aspose.Slides kaynak düzen tipine veya adına göre master‑daki düzenler arasından seçim yapar.

**Farklı slayt boyutlarına sahip sunumlar birleştirilebilir mi?**

Evet, ancak slayt içeriği hedef boyutlara otomatik olarak yeniden tasarlanmaz. Öngörülebilir yerleşim gerekiyorsa, önce [SlideSize::setSize()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidesize/setsize/) ve [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidesizescaletype/) ile kaynağı yeniden boyutlandırın.

**PPT, PPTX ve ODP sunumlarını tek bir dosyada birleştirebilir miyim?**

Evet. Her kaynak sunumu yükleyin, gerekli slaytları tek bir hedefe kopyalayın ve hedefi desteklenen bir çıktı formatında kaydedin. Sunum formatları aynı özellik kümesini tam olarak desteklemediğinden, çapraz‑format birleştirmelerden sonra karmaşık içeriği doğrulayın. Desteklenen dosya formatları için [Desteklenen Dosya Formatları](/slides/tr/php-java/supported-file-formats/) sayfasına bakın.

**Kaynak bölümler otomatik olarak korunur mu?**

Sadece slaytları kopyalayan temel bir döngü bölümleri korumaz. Bölüm yapısını korumanız gerekiyorsa, hedefte bölümleri yeniden oluşturun ve [addClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/addclone/)’ın bölüm aşırı yüklemesini kullanın.

**Sunucu notları ve yorumlar korunur mu?**

Evet, kopyalanan slaytla birlikte kopyalanır. Not‑master stilizasyonu, yorum yazarları veya işlenmiş yorum verileri gibi yapıların doğrulanması gereken iş akışları için birleştirilmiş sonucu kontrol edin; çünkü bu senaryolar slayt‑düzeyinin yanı sıra sunum‑düzeyinde de yapılar içerir.

**Ses, video, OLE nesneleri ve köprülerle ne olur?**

Gömülü içerik, kopyalanan slaytın kaynak ilişkileriyle birlikte taşınır. Dış bağlantılar dış bağlantı olarak kalır; hedef dosyalar veya URL’ler birleştirmeden sonra hâlâ erişilebilir olmalıdır.

**Her kaynaktan gelen gömülü yazı tipleri birleştirilmiş sunumda bulunur mu?**

Yalnızca slayt kopyalama, yazı tipi dağıtımı için yeterli değildir. Hedefte gömülü yazı tiplerini inceleyin ve tipografi önemliyse yazı tiplerini açıkça yönetin veya dış yazı tipi kullanılabilirliğini sağlayın.

**Parola korumalı bir dosyayı nasıl birleştiririm?**

Doğru [LoadOptions::setPassword()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/setpassword/) ile açın, ardından slaytlarını normal şekilde kopyalayın. Çıktı koruması ayrı olarak yapılandırılır.

**Çok büyük sunumları nasıl yönetmeliyim?**

Büyük ikili nesneler belleği hâkim olduğunda BLOB yönetimini kullanın, çok büyük dosyalar için dosya yolu üzerinden yüklemeyi tercih edin, kaynak sunumları birleştirildikçe hemen serbest bırakın ve final sonucu yalnızca gerektiğinde kaydedin.

**Slaytları birden çok iş parçacığından birleştirebilir miyim?**

PHP via Java’da sunumları yüklemek, kaydetmek, değiştirmek veya kopyalamak çok iş parçacıklı olarak desteklenmez. Paralel birleştirme işleri gerekiyorsa, her işi ayrı tek‑iş‑parçacıklı süreçlerde yürütün ve her sürecin kendi sunum örneklerini kullanmasını sağlayın.