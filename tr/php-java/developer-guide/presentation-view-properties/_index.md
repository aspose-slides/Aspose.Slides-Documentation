---
title: PHP'de Sunum Görünüm Özelliklerini Al ve Güncelle
linktitle: Görünüm Özellikleri
type: docs
weight: 80
url: /tr/php-java/presentation-view-properties/
keywords:
- görünüm özellikleri
- normal görünüm
- taslak içeriği
- taslak simgeleri
- dikey bölücüyü yakala
- tek görünüm
- çubuk durumu
- boyut ölçüsü
- otomatik ayar
- varsayılan yakınlaştırma
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "PowerPoint sunumlarında normal görünüm düzenini, slayt ve not yakınlaştırmasını, ızgara aralığını ve yorum görünürlüğünü yapılandırmak için Java aracılığıyla PHP için Aspose.Slides kullanın."
---
## **Giriş**

PowerPoint'in normal görünümünde, slayt küçük resimler veya bir taslak için yan panel ile altta bir notlar paneli arasında görünür. Aspose.Slides for PHP via Java, sunumun kaydedilmiş düzenleme tercihlerine [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) aracılığıyla erişim sağlar. Bu tercihler panel düzeni, yakınlaştırma seviyeleri, ızgara aralığı ve yorum görünürlüğünü içerir.

## **NormalViewProperties hakkında**

[getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnormalviewproperties/) kullanarak [NormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/) sınıfına erişin. [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) taslakta slayt başlıklarının yanındaki simgelerin görünüp görünmediğini kontrol eder. [setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setsnapverticalsplitter/) kullanıcı yan paneli daralttığında panelin küçültülmüş durumuna yapışmasını sağlar. [setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setprefersingleview/) tam pencerede bir panelin gösterilmesini tercih ettiğini gösterir.

[setVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setverticalbarstate/) yan panel ile slayt arasındaki bölücüyü kontrol eder. [setHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/sethorizontalbarstate/) notlar panelinin üzerindeki bölücüyü kontrol eder. Her ikisi de `Minimized`, `Maximized` veya `Restored` değerlerinden birini alan bir [SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/splitterbarstatetype/) alır.

## **NormalViewProperties'i Geri Yükleme Hakkında**

Bir bölücü geri yüklendiğinde, [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredleft/) yan panelin kaydedilmiş boyutunu, [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) ise üst slayt alanının kaydedilmiş boyutunu sağlar. İkisi de [NormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/) nesnesini ortaya çıkarır. Bunun [setDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setdimensionsize/) yöntemi 0 ile 100 arasında bir yüzde alır ve [setAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setautoadjust/) pencere yeniden boyutlandırıldığında düzenleyicinin boyutu ayarlayıp ayarlamayacağını kontrol eder.

Bu örnek mevcut bir sunumu günceller. Yatay bölücüyü geri yükler, [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) tarafından döndürülen boyutu otomatik ayarlama etkinleştirilmiş şekilde %80'e ayarlar ve dikey bölücüyü büyütür. Ayrıca taslak görünümünde simgeleri göstermek için [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) metodunu çağırır.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SplitterBarStateType;

$presentation = new Presentation("demo.pptx");
try {
    $normalView = $presentation->getViewProperties()->getNormalViewProperties();
    $normalView->setHorizontalBarState(SplitterBarStateType::Restored);
    $normalView->setVerticalBarState(SplitterBarStateType::Maximized);
    $normalView->getRestoredTop()->setAutoAdjust(true);
    $normalView->getRestoredTop()->setDimensionSize(80);
    $normalView->setShowOutlineIcons(true);

    $presentation->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Varsayılan Yakınlaştırma Değerini Ayarlama**

[getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getslideviewproperties/) ve [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnotesviewproperties/) düzenleyici için bağımsız yakınlaştırma ayarları saklar. Bu ayarlar slayt boyutlarını, slayt gösterisi çalma hızını veya görüntü dışa aktarma çözünürlüğünü etkilemez.

Bu örnek mevcut bir sunumu açar ve slaytı düzenleme penceresine sığdırmak için [setVariableScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setvariablescale/) metodunu çağırır. Notlar sayfası için otomatik ölçeklemeyi devre dışı bırakır ve sabit %80 yakınlaştırma ayarlamak üzere [setScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setscale/) metodunu kullanır.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    $viewProperties->getSlideViewProperties()->setVariableScale(true);
    $viewProperties->getNotesViewProperties()->setVariableScale(false);
    $viewProperties->getNotesViewProperties()->setScale(80);

    $presentation->save("zoom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Izgara Aralığını Ayarlama**

[ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/)'in `setGridSpacing` yöntemi, sunum boyunca düzenleme ızgara çizgileri arasındaki mesafeyi ayarlar. Yöntem, inç başına 72 nokta olmak üzere pozitif bir nokta değeri alır. Bu örnek mevcut bir sunumdaki mevcut aralığı yazdırır ve aralığı 18 noktaya (çeyrek inç) ayarlayarak bir çeyrek inç ızgara kaydeder.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current grid spacing: " . java_values($viewProperties->getGridSpacing()) . " points" . PHP_EOL;

    $viewProperties->setGridSpacing(18.0);
    
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Izgara sabit bir aralıkta tekrarlanır. [Çizim kılavuzları](/slides/tr/php-java/drawing-guides/) bireysel yatay veya dikey konumları işaretler. İkisi de düzenleme yardımcılarıdır ve yalnızca bunları gösteren editörlerde görünür. Slayt gösterileri ve PDF, görüntü veya SVG dışa aktarımları bunları içermez.

## **Sunum Açılırken Yorumları Göster veya Gizle**

[setShowComments](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setshowcomments/) uyumlu editörlerin sunumu açarken kullandığı bir tercih saklar. Yorumları olan mevcut bir sunum için bu örnek mevcut ayarı yazdırır ve yorumları gizli bir kopya kaydeder. Ayrıca kopyanın slayt görünümünde açılmasını sağlamak için [setLastView](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setlastview/) metodunu [ViewType::SlideView](https://reference.aspose.com/slides/php-java/aspose.slides/viewtype/#SlideView) ile birlikte çağırır.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current comment visibility: " . java_values($viewProperties->getShowComments()) . PHP_EOL;

    $viewProperties->setShowComments(NullableBool::False);
    $viewProperties->setLastView(ViewType::SlideView);

    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Yorumların gizlenmesi, metinlerini, yazarlarını, konumlarını, yanıtlarını ve durumlarını korur. Yorumları kendisini değiştirmek için [Sunum Yorumları](/slides/tr/php-java/presentation-comments/) bölümüne bakın. Dışa aktarma ayarları, yorumların PDF, HTML, görüntüler, notlar veya el ilanlarında görünüp görünmeyeceğini kontrol eder.

## **SSS**

**Sunumu yeniden açtığımda ızgara neden gizleniyor?**  
Sunum, ızgara aralığını depolar. Izgarayı görmek için editörde ızgara görünürlüğünü etkinleştirin.

**Çizim kılavuzlarını temizlemek ızgara aralığını değiştirir mi?**  
Hayır. Bir kılavuzu eklemek, taşımak veya temizlemek ızgara aralığını değiştirmez.

**Bir sunumun farklı bölümleri farklı görünüm ayarlarına sahip olabilir mi?**  
Hayır. [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) tüm sunuma uygulanır.

**Farklı kullanıcılar için farklı görünüm ayarlarını kaydedebilir miyim?**  
Dosya herkes için tek bir görünüm özelliği seti saklar. Bir editör ayrıca kullanıcının yerel tercihlerini uygulayabilir.

**Şablonda görünüm ayarlarını kaydedebilir miyim?**  
Evet. Şablondan oluşturulan sunumlar, kaydedilmiş görünüm ayarlarını devralır.