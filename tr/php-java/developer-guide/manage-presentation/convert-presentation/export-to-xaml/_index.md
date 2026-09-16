---
title: PHP'de Sunumları XAML'e Dışa Aktarma
linktitle: Sunumu XAML'e
type: docs
weight: 30
url: /tr/php-java/export-to-xaml/
keywords:
- PowerPoint dışa aktar
- OpenDocument dışa aktar
- sunumu dışa aktar
- PowerPoint dönüştür
- OpenDocument dönüştür
- sunumu dönüştür
- PowerPoint'tan XAML'e
- OpenDocument'ten XAML'e
- sunumdan XAML'e
- PPT'den XAML'e
- PPTX'ten XAML'e
- ODP'den XAML'e
- PPT'yi XAML olarak kaydet
- PPTX'i XAML olarak kaydet
- ODP'yi XAML olarak kaydet
- PPT'yi XAML'e dışa aktar
- PPTX'i XAML'e dışa aktar
- ODP'yi XAML'e dışa aktar
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP aracılığıyla Java üzerinden PowerPoint ve OpenDocument slaytlarını XAML'e dönüştürün — düzeninizi koruyan hızlı, Office gerektirmeyen bir çözüm."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarını XAML'e nasıl dışa aktarılacağını açıklar. XAML'e kısa bir giriş içerir, varsayılan ayarlarla bir sunumu XAML olarak nasıl kaydedileceğini gösterir ve gizli slaytların dışa aktarımını da kapsayan dışa aktarmayı [XamlOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/xamloptions/) aracılığıyla nasıl özelleştireceğinizi gösterir. Makale ayrıca yedek yazı tipleri, XAML yığını uyumluluğu ve gizli slayt dışa aktarma davranışıyla ilgili birkaç yaygın soruyu yanıtlar.

## **XAML Hakkında**

XAML, WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) ve Xamarin.Forms gibi çerçevelerde kullanıcı arabirimlerini tanımlamak için kullanılan XML tabanlı bir işaretleme dilidir.

XAML dosyalarıyla görsel bir tasarımcıda çalışabilir veya işaretlemeyi doğrudan yazıp düzenleyebilirsiniz.

## **Sunumları XAML'e Varsayılan Seçeneklerle Dışa Aktarma**

Aşağıdaki PHP örneği, bir sunumu varsayılan ayarlarla XAML'e nasıl dışa aktaracağınızı gösterir. Bu makaledeki örnekleri çalıştırmadan önce PHP Java Bridge'i başlatın ve `aspose.slides.php` dosyasını yükleyin. `pres.pptx` dosyasını Java Bridge sunucusunun çalışma dizinine yerleştirin veya bu sunucu tarafından erişilebilen mutlak bir yol sağlayın.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

Varsayılan olarak, dışa aktarılmış slaytlar Java Bridge sunucusunun geçerli çalışma dizinindeki `pres` alt klasörüne kaydedilir. Klasör otomatik olarak oluşturulur ve gerekli tüm görüntüler de oraya kaydedilir.

Çıktı klasörü adı, kaynak dosya adının uzantısı çıkarılarak alınır. `pres.pptx` için çıktı dosyaları `pres/Slide_1.xaml`, `pres/Slide_2.xaml` vb. olarak adlandırılır. Giriş sunumuna mutlak bir yol geçirseniz bile, çıktı klasörü Java Bridge sunucusunun geçerli çalışma dizinine göre oluşturulur; giriş dosyasının yanına değil.

## **Sunumları XAML'e Özel Seçeneklerle Dışa Aktarma**

Aspose.Slides'in bir sunumu XAML'e nasıl dışa aktaracağını kontrol etmek için [IXamlOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ixamloptions/) arayüzünü kullanın.

Çıktıyı özel bir konuma kaydetmek için [IXamlOutputSaver](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ixamloutputsaver/) arayüzünü uygulayan bir Java vekil nesnesi sağlayın ve bu uygulama örneğini [XamlOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/xamloptions/) sınıfının [setOutputSaver](https://reference.aspose.com/slides/tr/php-java/aspose.slides/xamloptions/#setOutputSaver) metoduna geçirin.

XAML çıktısına gizli slaytları dahil etmek için, aşağıdaki PHP örneğinde gösterildiği gibi `true` ile [setExportHiddenSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) metodunu çağırın:

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

## **Oluşturulan Tüm XAML Ürünlerini Yakalama**

Bir XAML dışa aktarımı, dışa aktarılan her slayt için bir XAML belgesi ile ayrı görüntüler ve destekleyici kaynaklar üretebilir. Bu ürünleri varsayılan dosya sistemi kaydedicisi yerine almak için bir özel [IXamlOutputSaver](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ixamloutputsaver/) atayın ve [XamlOptions::setOutputSaver](https://reference.aspose.com/slides/tr/php-java/aspose.slides/xamloptions/#setOutputSaver) metoduna verin. Dışa aktarmayı, XAML seçeneklerini kabul eden XAML‑özel [Presentation::save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#save) aşırı yüklemesiyle başlatın.

PHP Java Bridge `java_closure` işlevi, bir PHP nesnesini Java arayüzü olarak ortaya çıkarır. PHP kaydedicisi ve vekil nesnesi dışa aktarım tamamlanana kadar yaşamını sürdürmelidir. Arayüz bağlantıları, vekil tarafından uygulanmış Java API’sine işaret eder.

### **Geri Çağrı Yaşam Döngüsünü Anlamak**

Dışa aktarıcı, her oluşturulan ürün için ayrı ayrı [IXamlOutputSaver::save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) metodunu şu şekilde çağırır:

- `path` ürünün kimliğini belirtir ve göreli dizinler içerebilir. XAML, kaynakları göreli yollarla referanslayabileceği için bu bilgiyi saklayın.
- `data` ürünün baytlarını içerir. Görüntüler ve diğer ikili kaynaklar metin olarak çözümlenmemelidir.
- Kaydedici, verileri döndürmeden önce saklamaktan veya kalıcı hale getirmekten sorumludur. Örneklerde her Java bayt dizisi, uygulama tarafından sahip olunan bir PHP ikili dizesine dönüştürülür.
- Sunum kaydetme işlemi döndüğünde ve tüm geri çağrılar sorunsuz tamamlandığında dışa aktarma başarılı kabul edilir. Depolama hatalarını göz ardı etmeyin veya gözlemlenmeyen arka plan yazımlarına başlamayın. Kalıcı işlem daha sonra gerçekleşirse, genel başarı yalnızca bu adım da başarılı olduğunda raporlanmalıdır.

[XamlOptions::setExportHiddenSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) aynı zamanda özel bir kaydedici için de geçerlidir. Varsayılan ayar `false` olduğundan gizli‑slayt XAML belgeleri dışarı çıkmaz. `true` gönderildiğinde hem belgeler hem de dışa aktarım için gereken tüm kaynaklar dahil edilir. Kaynak sayısı sunuma bağlıdır; slayt başına bir geri çağrı olduğu ya da sabit bir geri çağrı sırası olduğu varsayımı yapılmamalıdır.

### **Belleğe Dışa Aktar ve Ürünleri İncele**

Bu tam örnek, `pres.pptx` dosyasını yükler, her ürünü bir PHP ilişkisel dizisinde ikili dize olarak toplar ve adını, türünü ve bayt sayısını yazdırır. Sağlanan adlar tam olarak korunur. Aynı ada sahip bir ürün bulunursa koleksiyon geçersiz kabul edilir ve sessizce üzerine yazılmaz; örnek bu durumu kontrol eder.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$inspectXamlText = false;
foreach ($saver->artifacts as $name => $bytes) {
    $extension = strtolower(pathinfo($name, PATHINFO_EXTENSION));
    $isXaml = $extension === "xaml";
    $isImage = in_array($extension, ["png", "jpg", "jpeg", "gif", "bmp", "tif", "tiff", "svg"], true);
    $kind = $isXaml ? "slide XAML" : ($isImage ? "image" : "supporting resource");
    echo $name . ": " . strlen($bytes) . " bytes (" . $kind . ")" . PHP_EOL;

    // Sadece XAML, isteğe bağlı inceleme için UTF-8 metin olarak ele alınır.
    if ($isXaml && $inspectXamlText) {
        echo $bytes . PHP_EOL;
    }
}
```

Uzantı kontrolleri inceleme sırasında yararlıdır; tüm ürünleri, bilinmeyen kaynak türleri dahil, tutun. Baytları saklarken veya aktarırken değiştirmeyin. PHP dizeleri ikili veriyi, sıfır baytları da içerecek şekilde tutabilir. Dizeyi yalnızca XAML incelerken UTF‑8 metin olarak ele alın; görüntü veya kaynak baytlarını dönüştürmeyin.

### **Toplanan Ürünleri ZIP Arşivi Olarak Paketle**

Bu bağımsız örnek dışa aktarmayı toplar, adları doğrular ve orijinal baytları bir ZIP arşivine yazar. Özel bir iş dizini, eş zamanlı dışa aktarma işleri arasında ayrım sağlar. Örnek, ZIP desteği olan PHP Phar uzantısını gerektirir. ZIP girdileri ileri eğik çizgi (`/`) kullanır ve göreli dizinleri korur. Normalleştirme sonrası çakışan ya da tehlikeli adlar, arşivin yazılmasından önce tüm paketi reddeder.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(false);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$entries = [];
$entryNames = [];
foreach ($saver->artifacts as $name => $bytes) {
    $entryName = str_replace("\\", "/", $name);
    $unsafeName = substr($entryName, 0, 1) === "/" || strpos($entryName, ":") !== false;
    foreach (explode("/", $entryName) as $segment) {
        $unsafeName = $unsafeName || trim($segment) === "" || $segment === "." || $segment === "..";
    }
    $key = strtolower($entryName);
    if ($unsafeName || isset($entryNames[$key])) {
        echo "Export rejected: unsafe or duplicate artifact name: " . $name . PHP_EOL;
        return;
    }
    $entryNames[$key] = true;
    $entries[$entryName] = $bytes;
}

$jobDirectory = "xaml-" . bin2hex(random_bytes(16));
if (!mkdir($jobDirectory, 0700)) {
    echo "Cannot create the export directory." . PHP_EOL;
    return;
}
$archivePath = $jobDirectory . "/export.zip";
try {
    $archive = new PharData($archivePath, 0, null, Phar::ZIP);
    foreach ($entries as $name => $bytes) {
        $archive->addFromString($name, $bytes);
    }
    unset($archive);
    echo "Saved " . count($entries) . " artifacts to " . $archivePath . PHP_EOL;
} catch (Throwable $exception) {
    unset($archive);
    echo "Archive persistence failed: " . $exception->getMessage() . PHP_EOL;
}
```

Örnek, PHP sürecinin çalışma dizininde tek bir yerel ZIP arşivi oluşturmak için [PharData](https://www.php.net/manual/en/class.phardata.php) kullanır; dışa aktarıcı kendi başına gevşek XAML veya görüntü dosyaları yazmaz. Uzaktan depolama için, arşiv‑yazma aşamasını toplanan ikili dizelerin yüklenmesiyle değiştirin. Bir dışa aktarma‑iş kimliği ile tam göreli ürün adını blob anahtarı olarak kullanabilir veya iş kimliği, göreli ad ve ikili veriyi bir veritabanı satırında saklayabilirsiniz. Tüm yüklemeler tamamlandığında ya da veritabanı işlemi onaylandığında işi yayımlayın. Kalıcılık başarısız olursa kısmi çıktıyı temizleyin.

Büyük sunumlar için, özel bir kaydedici her ürünü doğrudan uygulama depolamasına kaydedebilir; bu şekilde bütün dışa aktarmanın bir kopyasını bellek içinde tutmaya gerek kalmaz. Dışa aktarıcının bakış açısından her geri çağrıyı senkron tutun: baytlar hedefe kabul edildiğinde dönüş yapın ve hataların çağırıcıya ulaşmasını sağlayın.

### **Kaynak Adlarını Koru ve Referansları Doğrula**

- Hedef gerektiriyorsa yol ayırıcılarını normalleştirin, ancak göreli dizinleri koruyun. Her üretimin adının benzersiz olduğu ve kaynak referanslarının geçerli kalacağı kesin olduğunda dışarıdan sadece [basename](https://www.php.net/manual/en/function.basename.php) kullanılmasından kaçının.
- Hedefe özgü ad doğrulaması uygulayın. Gevşek dosyalar yazılırken kök yolları ve dizin geçişi segmentlerini reddedin, hedefi mutlak bir yola çözün ve izin verilen dışa aktarım dizininin altında kalıp kalmadığını (dizin ayırıcı dahil) kontrol edin. Sembolik bağları olmayan, yeniden yönlendirme riski taşımayan bir uygulama‑kontrolü dizin kullanın.
- Her dışa aktarma işi için ayrı bir kaydedici ve depolama ad alanı kullanın. Ayırıcı normalleştirmesinden ve hedefin büyük/küçük harf duyarlılığı kurallarından kaynaklanan çakışmaları tespit edin.
- Yayınlamadan önce her XAML belgesini XML olarak ayrıştırın ve `Source` veya `ImageSource` gibi dosya‑tabanlı kaynak referanslarını inceleyin. Her göreli URI’yı ilgili XAML ürününün dizinine göre çözün, elde edilen depolama adını normalleştirin ve karşılık gelen harita anahtarı, ZIP girişi ya da saklanmış nesnenin varlığını doğrulayın. Dış URI’ları ve XAML işaretleme ifadelerini göreli dosya adlarından ayrı değerlendirin.

Örneğin, `pres/Slide_1.xaml` içinde `images/image1.png` referans ediliyorsa, depolanan kaynak `pres/images/image1.png` konumunda bulunmalıdır. Yalnızca `image1.png` saklamak bu ilişkiyi bozar. Nesne depolama kullanıyorsanız, aynı dizin yapısını iş‑önek altında koruyun ve bu kaynak URL’lerini XAML tüketicisinin erişebileceği şekilde sunun. ZIP’i yeniden açarak giriş adlarını ve kaynak baytlarını doğrulayın ve temsili slaytları hedef XAML ortamında yükleyerek görsellerin doğru çözümlendiğini kontrol edin.

## **SSS**

**Orijinal yazı tipi makinede mevcut değilse, öngörülebilir yazı tiplerini nasıl sağlayabilirim?**

[XamlOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/xamloptions/) içinde [setDefaultRegularFont](https://reference.aspose.com/slides/tr/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) metodunu çağırın — dışa aktarım sırasında eksik olduğunda yedek bir yazı tipi olarak kullanılır. Bu, oluşturulan XAML’in yedek yazı tipine referans vereceği ya da hedef makinede bu yazı tipinin bulunacağı garantisini vermez. XAML’in referans verdiği yazı tiplerinin görüntüleneceği ortamda mevcut olduğundan emin olun.

**Dışa aktarılan XAML sadece WPF için mi tasarlanmıştır, yoksa diğer XAML yığınlarında da kullanılabilir mi?**

Aspose.Slides, WPF XAML’ini halka açık API’si aracılığıyla dışa aktarır. UWP, Xamarin.Forms gibi diğer XAML yığınlarıyla uyumluluk garanti edilmez. Oluşturulan işaretlemeyi hedef ortamınızda test edin.

**Gizli slaytlar destekleniyor mu ve varsayılan olarak dışa aktarılmalarını nasıl önleyebilirim?**

Varsayılan olarak gizli slaytlar dahil edilmez. Bu davranışı [XamlOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/xamloptions/) içinde [setExportHiddenSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) metodunu devre dışı bırakarak kontrol edebilirsiniz. Gizli slaytları dışa aktarmanıza gerek yoksa bu ayarı kapalı tutun.