---
title: PHP'de Uzun Süreli Sunum İşlemlerini Kesintiye Uğratma
linktitle: Sunum İşlemlerini Kesintiye Uğrat
type: docs
weight: 120
url: /tr/php-java/support-for-interruptable-library/
keywords:
- kesinti tokeni
- iptal
- dönüştürme zaman aşımı
- slayt dışa aktarımı
- PowerPoint
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile bir zamanlayıcı üzerinden sunum dönüşümünü nasıl iptal edeceğinizi ve iptaldan önce dışa aktarılan slaytları nasıl geri alacağınızı öğrenin."
---
## **Genel Bakış**

Aspose.Slides for PHP via Java, uzun süren yükleme, kaydetme ve sunum renderleme gibi işlemleri kesintiye uğratabilir. Her seferinde tek bir slaytı dışa aktaran bir döngüde, aynı token uygulamanızın bir sonraki slayttan önce durmasını ve tamamlanan dışa aktarımların bir listesini döndürmesini sağlar.

Her iki PHP örneği de köprü (bridge) dosyası `Java.inc` yüklemeden önce `define("JAVA_PREFER_VALUES", 1);` çağırıldığını varsayar, ardından `aspose.slides.php` dosyasını yükler. Bu ayar, PHP’nin çağrı sırasında Java istisnalarını yakalamasını sağlar. Örnekler, sarmalanmış istisnanın nedenini inceleyerek diğer dönüşüm hatalarının çağırıcıya ulaşmasını sağlar.

## **Sunum İşlemini Kesintiye Uğratma**

Bir [InterruptionTokenSource](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/) oluşturun, tokenını [InterruptionTokenSource::getToken](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#getToken) ile alın ve [LoadOptions::setInterruptionToken](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setInterruptionToken) metoduna iletin. Bu seçenekleri [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) nesnesi oluşturulurken sağlayın. [InterruptionTokenSource::interrupt](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#interrupt) çağrısı iptal isteği gönderir. Çalışan bir işlem, isteği algıladığında durur.

### **Dönüştürme Zaman Aşımını Ayarla**

PHP, PHP/Java Bridge üzerinden senkron bir yükleme veya kaydetme işlemini beklerken, ayrı bir iş parçacığında iptal isteği gönderebilecek bir Java zamanlayıcısı kullanılabilir. Aşağıdaki yardımcı sınıfı `ConversionTimeout.java` adıyla kaydedin, sınıf yolunda Aspose.Slides JAR dosyası bulunacak şekilde derleyin ve derlenmiş sınıfı köprünün paket adı `example.ConversionTimeout` altında erişilebilir hâle getirin.

```java
package example;

import com.aspose.slides.InterruptionTokenSource;
import java.util.Timer;
import java.util.TimerTask;

public class ConversionTimeout {
    public static Timer start(InterruptionTokenSource source, long milliseconds) {
        Timer timer = new Timer(true);
        timer.schedule(new TimerTask() {
            @Override
            public void run() {
                source.interrupt();
            }
        }, milliseconds);
        return timer;
    }
}
```

Köprü ve Aspose.Slides PHP sarmalayıcısı yüklüyken, Java işlemindeki çalışma dizininde `sample.pptx` bulunacak şekilde ya da o işleme erişilebilen mutlak yollarla aşağıdaki örneği çalıştırın. 20 saniyelik sınır, hem yüklemeyi hem de PDF dışa aktarımını kapsar. Dönüştürme erken biterse, PHP zamanlayıcıyı iptal eder. Daha eski PowerPoint formatına 10 saniyelik bir sınırla dönüştürmek isterseniz, `sample.ppt`, `SaveFormat::Ppt` ve `10000` milisaniyeyi kullanın.

```php
use aspose\slides\InterruptionTokenSource;
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new InterruptionTokenSource();
$token = $source->getToken();
$options = new LoadOptions();
$options->setInterruptionToken($token);
$timer = java("example.ConversionTimeout")->start($source, 20000);
try {
    $presentation = new Presentation("sample.pptx", $options);
    try {
        $token->throwIfInterruptionRequested();
        $presentation->save("sample.pdf", SaveFormat::Pdf);
        $token->throwIfInterruptionRequested();
        echo "Conversion completed\n";
    } finally {
        $presentation->dispose();
    }
} catch (JavaException $error) {
    if (!java_instanceof($error->getCause(), java("com.aspose.slides.exceptions.OperationCanceledException"))) {
        throw $error;
    }
    echo "Conversion canceled\n";
} finally {
    $timer->cancel();
}
```

## **Sonraki Slaytı İşleme Almadan Durdur**

Her dışa aktarmadan önce [InterruptionToken::isInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#isInterruptionRequested) metodunu kontrol edin. Seçili slaytlar için olan [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) aşırı yüklemesi, 1’den başlayan slayt numaralarını alır. Her slayt için ayrı bir PDF oluşturmak üzere tek elemanlı bir dizi geçirin.

En az iki slaytı olan bir `sample.pptx` kullanın. İptali dışa aktarmalar arasında göstermek için örnek, ilk slaytı kaydettikten hemen sonra isteği gönderir.

```php
use aspose\slides\InterruptionTokenSource;
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function exportSlides($path, $source) {
    $completed = [];
    $token = $source->getToken();
    $options = new LoadOptions();
    $options->setInterruptionToken($token);
    $presentation = new Presentation($path, $options);
    try {
        $count = java_values($presentation->getSlides()->size());
        for ($number = 1; $number <= $count; $number++) {
            if (java_values($token->isInterruptionRequested())) {
                break;
            }

            try {
                $presentation->save("slide-$number.pdf", [$number], SaveFormat::Pdf);
                $token->throwIfInterruptionRequested();
            } catch (JavaException $error) {
                if (java_instanceof($error->getCause(), java("com.aspose.slides.exceptions.OperationCanceledException"))) {
                    break;
                }
                throw $error;
            }

            $completed[] = $number;
            if ($number === 1) {
                $source->interrupt();
            }
        }
        return $completed;
    } finally {
        $presentation->dispose();
    }
}

$source = new InterruptionTokenSource();
$completed = exportSlides("sample.pptx", $source);
echo "Completed: " . json_encode($completed) . "\n";
```

Örnek `slide-1.pdf` dosyasını yazar ve `Completed: [1]` mesajını verir. İkinci yineleme, bir dışa aktarma daha başlamadan önce isteği görür. Kaydetme sırasında iptal gerçekleşirse, liste yalnızca daha önce onaylanmış dışa aktarımları içerir. Kesintiye uğrayan bir kaydetme, diskte eksik bir dosya bırakabilir.

İptalin çağırıcıya iletilmesini sağlamak için döngünün başındaki kontrolü `$token->throwIfInterruptionRequested();` ile değiştirin ve içteki `try`/`catch` bloklarını kaldırın; kaydetme ve ardından gelen kontrolü tutun. Aynı girdiyle, [InterruptionToken::throwIfInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) ikinci slayttan önce bir istisna atar ve çağırıcı hiçbir liste almaz.

## **SSS**

**İptal isteği ne zaman gönderilmeli?**  
Bir zaman aşımı gerçekleştiğinde ya da çağırıcı artık sonuca ihtiyaç duymadığında iptal isteği gönderin. İşlem tamamlandıktan sonra gönderilen bir istek, sonucun değişmeden kalmasını sağlar.

**Kaynak ve token arasındaki fark nedir?**  
Kaynak, bir uygulamanın iptal isteği oluşturmasına olanak tanır. Token ise Aspose.Slides ve uygulama kodunun bu isteği gözlemlemesini sağlar.

**Birden fazla işlem aynı kaynağı paylaşabilir mi?**  
Evet. Bir istek, o kaynağa ait token kullanan tüm işlemlere uygulanır. Bağımsız iptaller gerektiren işlemler için ayrı kaynaklar oluşturun.