---
title: PHP'de Sunumları Verimli Bir Şekilde Birleştirin
linktitle: Sunumları Birleştir
type: docs
weight: 40
url: /tr/php-java/merge-presentation/
keywords:
- PowerPoint birleştir
- sunumları birleştir
- slaytları birleştir
- PPT'yi birleştir
- PPTX'i birleştir
- ODP'yi birleştir
- PowerPoint birleştir
- sunumları birleştir
- slaytları birleştir
- PPT'yi birleştir
- PPTX'i birleştir
- ODP'yi birleştir
- PHP
- Aspose.Slides
description: "PHP'de slaytları kopyalayarak, master ve layoutları kontrol ederek, slayt içeriğini yeniden boyutlandırarak, bölümleri koruyarak ve korumalı ya da büyük dosyalarla başa çıkarak PowerPoint ve OpenDocument sunumlarını nasıl birleştireceğinizi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for PHP via Java, bir [Sunum](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) içindeki slaytları kopyalayarak bir başka sunumu birleştirir. Ana işlem, kaynağın slayt biçimlendirmesini koruyabilen veya kopyalanan slaytı hedef sunumdaki bir master veya layouta ekleyebilen [SlideCollection::addClone()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/addclone/) yöntemidir.

Bu makale en yaygın birleştirme iş akışlarını kapsar:

- tüm slaytları, kaynak biçimlendirmeleri korunarak birleştirme;
- seçili slaytları birleştirme;
- hedef sunumdan bir master uygulama;
- hedef sunumdan belirli bir layout uygulama;
- birleştirmeden önce farklı slayt boyutlarını normalleştirme;
- kopyalanan slaytları bir bölüme ekleme;
- birden fazla sunumu uçtan uca bir iş akışında birleştirme;
- masterlar, kaynaklar, notlar, yorumlar, medya, yazı tipleri, parolalar, büyük dosyalar ve çoklu iş parçacığı konularını yönetme.

## **Slide Kopyalamanın Master ve Layoutlar Üzerindeki Etkisi**

Bir slayt, görünümünün büyük bir kısmını layout ve masterından miras alır. Bu nedenle, seçtiğiniz kopyalama aşırı yüklemesi birleştirilen slaytın hedef sunuma nasıl entegre edileceğini belirler.

[SlideCollection::addClone()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/addclone/) yöntemini aşağıdaki şekillerde kullanın:

- `addClone(sourceSlide)` — kaynak slaytın layout ve biçimlendirmesini korur. Gerektiğinde, kaynak master otomatik olarak hedef sunuma kopyalanabilir. Aspose.Slides, aynı kaynak masterı kullanan tekrarlanan slaytların masterının tekrar tekrar kopyalanmasını önlemek için otomatik kopyalanan masterları izler.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — kopyalanan slaytı belirli bir hedef [MasterSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslide/) üzerine ekler. Aspose.Slides, bu master altında layout tipine veya adına göre eşleşen bir layout arar.
- `addClone(sourceSlide, destinationLayout)` — kopyalanan slaytı doğrudan belirli bir hedef [LayoutSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslide/) üzerine ekler.

`addClone` aşırı yüklemesine geçirilen master veya layout, **kaynak** sunuma değil **hedef** sunuma ait olmalıdır.

## **Tüm Sunumları Birleştir ve Kaynak Biçimlendirmesini Koruyun**

En basit birleştirme, kaynak sunumdaki tüm slaytları hedef sunuma kopyalar. Bu, içe aktarılan slaytların orijinal tema, master ve layout ilişkilerini koruması gerektiğinde uygun seçimdir.

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

Kaynak ve hedef farklı tasarımlar kullandığında, sonuç sunum birden fazla master içerebilir. Bu, kaynak biçimlendirmesinin kasıtlı olarak korunduğu durumlarda beklenendir.

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

Kullanıcı girdisi veya dış yapılandırmadan gelen slayt indekslerini kopyalamadan önce doğrulayın.

## **Hedef Master Kullanarak Slaytları Birleştir**

İçe aktarılan slaytların zaten hedef sunuma ait bir masterı takip etmesi gerekiyorsa, [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/addclone/) aşırı yüklemesini kullanın.

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

Aspose.Slides, kaynak layoutun tipine veya adına göre belirli master altında uygun bir layout seçer. Uygun bir layout mevcut değil ve `allowCloneMissingLayout` **true** ise, kaynak layout kopyalanarak slayt eklenebilir. **false** ise bir [PptxEditException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pptxeditexception/) hatası atılır.

Ek bir layoutın hedef mastera eklenmesini istemiyorsanız, birleştirmenin başarısız olmasını sağlamak için **false** kullanın.

## **Belirli Bir Hedef Layout Kullanarak Slaytları Birleştir**

İçe aktarılan slaytların kesinlikle belirli bir hedef layout kullanması gerektiğinde, [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/addclone/) aşırı yüklemesini kullanın.

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

Hedef layoutu uygulamak, kalıtılan layout ilişkisini değiştirir; kaynak slayt içeriğini yeniden tasarlamaz. Kaynak ve hedef layoutların yer tutucu yapıları farklıysa, kalıtılan biçimlendirme ve yer tutucu davranışının uygun olduğunu doğrulamak için sonucu inceleyin.

## **Farklı Slayt Boyutlarına Sahip Sunumları Birleştir**

Farklı slayt boyutlarına sahip sunumlar birleştirilebilir, ancak bir slaytı başka bir boyuta sahip bir sunuma kopyalamak, içeriği otomatik olarak yeni kanvas için yeniden tasarlamaz. Şekiller bu yüzden kaymış, beklenmedik şekilde ölçeklenmiş veya görünür slayt alanının dışında görünebilir.

Pratik bir yaklaşım, kopyalamadan önce kaynak sunumu yeniden boyutmaktır. [SlideSize::setSize()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidesize/setsize/) yöntemi, slayt boyutlarını değiştirirken mevcut içeriği ölçeklendirebilir. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidesizescaletype/) içerikleri istenen boyuta sığdıracak şekilde ölçeklendirir.

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

Yeniden boyutlandırma, kaynak sunum nesnesini bellekte değiştirir. Orijinal kaynak sunumu diğer işlemler için değiştirilmemiş olarak tutmanız gerekiyorsa, birleştirme için ayrı bir örnek açın.

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

Kopyalanan slaytlar belirtilen hedef bölüme eklenir. Birden fazla kaynak bölümü korumak istiyorsanız, bu bölümleri hedefte yeniden oluşturun ve her kaynak slaytı ilgili hedef bölüme eşleyin.

## **Birden Fazla Sunumu Güvenli Bir Şekilde Birleştir**

Aşağıdaki uçtan uca örnek, ilk sunumu hedef olarak kullanır, ek her kaynak için slayt boyutunu normalleştirir, her kaynağı yalnızca kopyalanırken açık tutar ve nihai dosyayı tek seferde kaydeder.

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

Bu, içe aktarılan slaytların kaynak biçimlendirmesini korumak için kullanışlı bir temel sağlar. Çıktınız tek bir hedef tema kullanmalıysa, basit `addClone($slide)` çağrısını önceki bölümlerde gösterilen uygun hedef‑master ya da hedef‑layout aşırı yüklemesiyle değiştirin.

## **Pratik Hususlar**

### **Masterlar, Layoutlar ve Biçimlendirme Sadakati**

Varsayılan slayt kopyalama, gereken bir kaynak masterı otomatik olarak hedef sunuma getirebilir. Aspose.Slides, aynı masterın tekrar tekrar kopyalanmasını önlemek için otomatik kopyalanan masterları içsel bir kayıt defterinde tutar. Manuel olarak kopyalanan masterlar bu kayıt defterine işlenmez; bu yüzden masterları önceden kopyalamaktan kaçının, aksi takdirde master yapısı üzerinde kesin kontrol gerekir.

Aynı ada sahip iki master veya layoutun görsel olarak eşdeğer olduğunu varsaymayın. Kurumsal bir şablon son görünümü kontrol ediyorsa, hedef bir master veya layoutu açıkça seçin ve birleştirme sonrası sonucu doğrulayın.

### **Notlar ve Yorumlar**

Konuşmacı notları ve slayt yorumları slayt içeriğiyle ilişkilidir ve slayt kopyalandığında kopyalanır. Aspose.Slides ayrıca [sunum notları](https://docs.aspose.com/slides/tr/php-java/presentation-notes/) ve [sunum yorumları](https://docs.aspose.com/slides/tr/php-java/presentation-comments/) için özel API’ler sunar.

Not sayfası biçimlendirmesi önemliyse, not masterlarının sunum‑seviyesinde nesneler olduğunu ve kaynak dosyalar arasında farklılık gösterebileceğini unutmayın; birleştirilmiş sunumu doğrulayın. İnceleme iş akışları için, farklı yazarların veya şablonların dosyalarını birleştirdikten sonra yorum yazarlarını ve zincirleme yorumları da kontrol edin.

### **Görüntüler, Ses, Video, OLE Nesneleri ve Harici Bağlantılar**

Slaytlar, sunum‑seviyesindeki kaynaklara (görüntüler, gömülü ses, gömülü video, OLE verileri) referans gösterebilir. Sadece görünür şekilleri kopyalamak yerine slaytı tamamen kopyalayın; böylece Aspose.Slides slaytın kaynak ilişkilerini korur.

Gömülü ve bağlanmış (linked) kaynakların ele alınışı farklıdır. Bağlantılı bir ses, video, OLE nesnesi veya köprü, dış hedefine bağımlı kalır; slayt kopyalanması dış bağlantıyı gömülü içeriğe dönüştürmez. Bağlantılı kaynak yollarını ve URL’leri, birleştirilen sunumun açılacağı ortamda test edin.

Aspose.Slides otomatik kopyalanan masterları izlese de, bu aynı kaynaktan gelen aynı ikili kaynakların her zaman tekrar edilmeyeceği garantisi değildir. Çıktı dosya boyutu önemliyse, birleştirilmiş paketi inceleyin ve sonucu ölçün; örtük deduplikasyona güvenmeyin.

### **Gömülü Yazı Tipleri ve Yazı Tipi Kullanılabilirliği**

Yazı tipleri sunum seviyesinde yönetilir. Tipografi farklı makinelerde tutarlı kalmalıysa, sadece slayt kopyalamanın gerekli tüm yazı tiplerinin hedef ortamda bulunduğunu varsaymayın. Gömülü yazı tiplerini [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsmanager/getembeddedfonts/) ile inceleyebilir ve [Sunumlarda Yazı Tipi Gömme](https://docs.aspose.com/slides/tr/php-java/embedded-font/) konusundaki yönergelerle gömme işlemini açıkça yönetebilirsiniz.

Ayrıca kaynak dosyalarda kullanılan yazı tiplerini gömmeye izin verilip verilmediğini doğrulayın; yazı tipi lisansları gömme hakkını kısıtlayabilir.

### **Parola Korumalı Sunumlar**

Parola korumalı bir kaynağı, slaytları kopyalamadan önce başarılı bir şekilde açmak gerekir. Parolayı [LoadOptions::setPassword()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/setpassword/) ile sağlayın.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$source = new Presentation("protected.pptx", $loadOptions);
try {
    // Şifre çözülmüş sunumla çalışın.
} finally {
    $source->dispose();
}
```

Şifreli bir kaynağı açmak, aynı korumanın hedef sunuma otomatik olarak uygulanacağı anlamına gelmez. Gerekirse çıktı korumasını ayrı olarak yapılandırın.

### **Büyük Sunumlar ve Bellek Kullanımı**

Yüksek çözünürlüklü görüntüler, ses, video veya diğer büyük ikili nesneler içeren büyük sunumlar önemli miktarda bellek tüketebilir. [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) BLOB yönetimi ve geçici dosya kullanımını kontrol eder. PHP via Java büyük‑dosya örneği için [Sunumları Açma](https://docs.aspose.com/slides/tr/php-java/open-presentation/#open-large-presentations) bölümüne bakın.

Büyük dosyalar için mümkün olduğunca dosya yolu üzerinden yükleme yapın, her kaynak sunumu birleştirildiğinde hemen serbest bırakın ve iş akışı kontrol noktaları gerektirmedikçe ara sonuçları tekrar tekrar kaydetmekten kaçının.

### **İş Parçacığı Güvenliği**

[Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) nesnelerini birden çok iş parçacığında yüklemeyin, değiştirmeyin, kaydetmeyin veya kopyalamayın. Bu işlemler PHP via Java’da çok iş parçacıklı kullanım için desteklenmez. Paralel birleştirme işleri gerekiyorsa, her bir işlemi ayrı tek‑iş‑parçacıklı süreçlerde çalıştırın; her süreç kendi sunum nesnelerini kullanmalı ve [Aspose.Slides çoklu iş parçacığı rehberi](https://docs.aspose.com/slides/tr/php-java/multithreading/) izlenmelidir.

## **SSS**

**Kaynak sunumların orijinal tasarımını nasıl korurum?**

Bir hedef master veya layout sağlamadan [`addClone(sourceSlide)`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/addclone/) kullanın. Aspose.Slides, içe aktarılan slayt tarafından ihtiyaç duyulduğunda kaynak masterı otomatik olarak kopyalayabilir.

**İçe aktarılan slaytların hedef temayı kullanmasını nasıl sağlarım?**

Hedef master kabul eden aşırı yüklemeyi kullanın. Masterı kaynak sunumdan değil hedef sunumdan alın. Aspose.Slides, her kaynak slaytı o masterın uygun bir layoutu ile eşleştirmeye çalışır.

**Belirli bir hedef layoutu, hedef master yerine ne zaman kullanmalıyım?**

Her içe aktarılan slaytın bilinen tek bir layout kullanması gerektiğinde belirli bir layout kullanın. Masterı, kaynak layout tipine veya adına göre masterın layoutları arasından seçim yapılmasını istediğinizde tercih edin.

**Farklı slayt boyutlarına sahip sunumlar birleştirilebilir mi?**

Evet, ancak slayt içeriği hedef boyutlara otomatik olarak yeniden tasarlanmamaktadır. Tahmin edilebilir konumlandırma için önce [SlideSize::setSize()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidesize/setsize/) ve [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidesizescaletype/) ile kaynak sunumu yeniden boyutlandırın.

**PPT, PPTX ve ODP sunumlarını tek bir dosyada birleştirebilir miyim?**

Evet. Her kaynak sunumu yükleyin, gerekli slaytları tek bir hedefe kopyalayın ve hedefi desteklenen bir çıktı formatında kaydedin. Sunum formatları aynı özellik setini tam olarak desteklemediği için, çapraz‑format birleştirmelerden sonra karmaşık içeriği doğrulayın. [Desteklenen Dosya Biçimleri](https://docs.aspose.com/slides/tr/php-java/supported-file-formats/) bölümüne bakın.

**Kaynak bölümler otomatik olarak korunur mu?**

Sadece slaytları kopyalayan temel bir döngü bölümleri korumaz. Gerekli bölümleri hedefte yeniden oluşturun ve bölüm yapısı korunmalıysa [addClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/addclone/) bölüm aşırı yüklemesini kullanın.

**Konuşmacı notları ve yorumlar korunur mu?**

Kopyalanan slaytlarla birlikte kopyalanırlar. Not‑master stilizasyonu, yorum yazarları veya zincirleme inceleme verileri gibi yapılar kullanılan iş akışları için birleştirilmiş sonucu doğrulayın; bu senaryolar sunum‑seviyesinde yapılar ve slayt‑seviyesinde içerik içerir.

**Ses, video, OLE nesneleri ve köprüler ne olur?**

Gömülü içerik, kopyalanan slaytın kaynak ilişkileriyle birlikte taşınır. Harici köprüler harici kalır; hedef dosyaları veya URL’ler birleştirmeden sonra da erişilebilir olmalıdır.

**Tüm kaynaklardan gelen gömülü yazı tipleri birleştirilmiş sunumda garanti eder mi?**

Yazı tipi dağıtımı için sadece slayt kopyalamaya güvenmeyin. Hedefteki gömülü yazı tiplerini inceleyin ve tipografi önemliyse yazı tipi gömme veya dış yazı tipi kullanılabilirliğini açıkça yönetin.

**Parola korumalı bir dosyayı nasıl birleştiririm?**

Doğru [LoadOptions::setPassword()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/setpassword/) ile açın, ardından slaytlarını normal şekilde kopyalayın. Çıktı koruması ayrı olarak yapılandırılır.

**Çok büyük sunumları nasıl yönetmeliyim?**

BLOB yönetimini, büyük ikili nesneler bellek kullanımını domine ettiğinde kullanın, çok büyük dosyalar için dosya‑yolu yüklemeyi tercih edin, kaynak sunumları birleştirildikten hemen sonra serbest bırakın ve nihai sonucu yalnızca gerektiğinde kaydedin.

**Slaytları birden çok iş parçacığından birleştirebilir miyim?**

Sunumları yüklemek, kaydetmek veya kopyalamak çoklu iş parçacığında desteklenmez. Paralel çalışma gerekiyorsa, her işlemi ayrı tek‑iş‑parçacıklı süreçlerde yürütün ve sunum nesnelerini süreçler arasında izole tutun.