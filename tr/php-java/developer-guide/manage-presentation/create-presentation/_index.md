---
title: PHP'de Sunumlar Oluşturma
linktitle: Sunum Oluştur
type: docs
weight: 10
url: /tr/php-java/create-presentation/
keywords:
- sunum oluştur
- yeni sunum
- PPT oluştur
- yeni PPT
- PPTX oluştur
- yeni PPTX
- ODP oluştur
- yeni ODP
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Java üzerinden PHP için Aspose.Slides ile sunumlar oluşturun — PPT, PPTX ve ODP dosyaları üretin ve bunları programlı olarak kaydederek güvenilir sonuçlar elde edin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde bir sunum nasıl oluşturulur, ilk slaytına nasıl bir metin kutusu eklenir ve sonucun bir dosya olarak nasıl kaydedilir gösterir. Ayrıca boş bir sunumun nasıl oluşturulup kaydedileceği ve desteklenen bir formatta mevcut bir sunumun nasıl açılarak başka bir formatta kaydedileceği de anlatılır. Sonunda yer alan kısa SSS bölümü, formatlar, şablonlar, slayt boyutlandırması, birimler, bellek kullanımı, çoklu iş parçacığı, lisanslama, dijital imzalar ve VBA desteği gibi yaygın soruları kapsar.

Başlamadan önce, Composer ile Java üzerinden Aspose.Slides for PHP'yi kurun ve Apache Tomcat'ta PHP/Java Bridge'i başlatın. Tam kurulum için [Installation](/slides/tr/php-java/installation/) sayfasına bakın. Aşağıdaki örnekler Tomcat'in `localhost:8080` adresinde çalıştığını ve Composer `vendor` klasörünün betiğin yanında olduğunu varsayar.

## **PowerPoint Sunumu Oluşturma**

Bir sunum oluşturup ilk slaytına bir metin kutusu eklemek için şu adımları izleyin:

1. **[Presentation]**(https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun. Yeni bir sunum zaten bir boş slayt içerir.  
2. **[Presentation::getSlides]**(https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/) tarafından döndürülen koleksiyondan, indeksi 0 olan slaytı alın.  
3. **[ShapeCollection::addAutoShape]**(https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addautoshape/) yöntemiyle bir dikdörtgen ekleyin ve **[TextFrame::setText]**(https://reference.aspose.com/slides/php-java/aspose.slides/textframe/settext/) ile metnini ayarlayın.  
4. **[Presentation::save]**(https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) yöntemiyle sunumu bir PPTX dosyası olarak kaydedin.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/tr/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

İki `require_once` satırı, Tomcat'tan PHP/Java Bridge istemcisini ve Composer paketinden Aspose.Slides sınıflarını yükler. Dikdörtgenin sol‑üst köşesi slaytın sol kenarından 50 puan, üst kenarından 50 puan uzakta olup, genişliği 400 puan ve yüksekliği 100 puandır. Kaydedilen dosya, bu dikdörtgen ve metni içeren bir slayt içerir. Lisans olmadan, Aspose.Slides kaydettiği her slayta bir değerlendirme filigranı ekler; ayrıntılar için [Licensing](/slides/tr/php-java/licensing/) sayfasına bakın.

{{% alert color="info" title="Note" %}}
Aspose.Slides dosyaları Tomcat içinde okur ve yazar, PHP sürecinizde değil; bu yüzden `"hello.pptx"` gibi bir göreli yol Tomcat'in çalışma klasörüne göre çözülür. Bu sayfadaki örnekler `__DIR__` ile mutlak yollar oluşturur, böylece dosyalar betiğin yanında okunur ve kaydedilir.
{{% /alert %}}

## **Sunum Oluşturma ve Kaydetme**

Boş bir sunum oluşturup kaydetmek için **[Presentation]**(https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun ve **[SaveFormat]**(https://reference.aspose.com/slides/php-java/aspose.slides/saveformat/) enum'undan istediğiniz herhangi bir formatta kaydedin. Sonuç, bir boş slayt içeren bir sunum olur.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/tr/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Sunumu Açma ve Kaydetme**

Bir sunumu bir formattan başka bir formata dönüştürmek için, yolunu **[Presentation]**(https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) yapıcısına geçirerek açın ve hedef formatta kaydedin. Aspose.Slides, dosyanın kendisinden PPT, PPTX veya ODP gibi giriş formatını algılar.

Aşağıdaki örnek, betiğin yanında bulunan *Sample.odp* adlı bir OpenDocument sunumunu PPTX olarak kaydeder.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/tr/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation(__DIR__ . "/Sample.odp");
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **SSS**

### Yeni bir sunumu hangi formatlara kaydedebilirim?

[PPTX, PPT ve ODP](/slides/tr/php-java/save-presentation/) formatlarına kaydedebilir ve ayrıca [PDF](/slides/tr/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/tr/php-java/convert-powerpoint-to-xps/), [HTML](/slides/tr/php-java/convert-powerpoint-to-html/), [SVG](/slides/tr/php-java/render-a-slide-as-an-svg-image/) ve [görseller](/slides/tr/php-java/convert-powerpoint-to-png/) gibi diğer formatlara dışa aktarabilirsiniz.

### Şablondan (POTX/POTM) başlayıp normal bir PPTX olarak kaydedebilir miyim?

Evet. Şablonu yükleyin ve istediğiniz formata kaydedin; POTX/POTM/PPTM ve benzeri formatlar [desteklenir](/slides/tr/php-java/supported-file-formats/).

### Sunum oluştururken slayt boyutunu/ en‑boy oranını nasıl kontrol ederim?

[Slayt boyutunu](/slides/tr/php-java/slide-size/) (4:3, 16:9 gibi hazır ayarlar veya özel boyutlar) ayarlayın ve içeriğin nasıl ölçekleneceğini seçin.

### Boyutlar ve koordinatlar hangi birimlerde ölçülür?

Puan olarak: 1 inç 72 birime eşittir.

### Çok büyük sunumlarda (çok sayıda medya dosyası) bellek kullanımını nasıl azaltırım?

[BLOB yönetim stratejileri](/slides/tr/php-java/manage-blob/) kullanın, geçici dosyalardan yararlanarak bellek içi depolamayı sınırlayın ve mümkün olduğunca dosya‑tabanlı iş akışlarını tercih edin.

### Sunumları paralel olarak oluşturup/kaydedebilir miyim?

Aynı **[Presentation]**(https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) örneğine [birden fazla iş parçacığından](/slides/tr/php-java/multithreading/) erişemezsiniz. Her iş parçacığı veya süreç için ayrı, izole örnekler çalıştırın.

### Deneme filigranı ve kısıtlamaları nasıl kaldırırım?

Her süreçte bir kez **[lisans uygulayın](/slides/tr/php-java/licensing/)**. Lisans XML dosyası değiştirilmeden kalmalı ve birden fazla iş parçacığı kullanıyorsanız lisans ayarları senkronize edilmelidir.

### Oluşturduğum PPTX dosyasını dijital olarak imzalayabilir miyim?

Evet. Sunumlar için **[dijital imzalar]**(/slides/tr/php-java/digital-signature-in-powerpoint/) (ekleme ve doğrulama) desteklenir.

### Oluşturulan sunumlarda makrolar (VBA) destekleniyor mu?

Evet. **[VBA projeleri oluşturabilir/düzenleyebilir]**(/slides/tr/php-java/presentation-via-vba/) ve PPTM/PPSM gibi makro‑etkin dosyaları kaydedebilirsiniz.