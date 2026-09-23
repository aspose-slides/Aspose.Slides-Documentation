---
title: PHP'de Sunum Görünüm Özelliklerini Getir ve Güncelle
linktitle: Görünüm Özellikleri
type: docs
weight: 80
url: /tr/php-java/presentation-view-properties/
keywords:
- görünüm özellikleri
- normal görünüm
- ana hat içeriği
- ana hat simgeleri
- dikey ayırıcının kilitlenmesi
- tek görünüm
- çubuk durumu
- boyut ölçüsü
- otomatik ayarlama
- varsayılan yakınlaştırma
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java görünüm özelliklerini keşfedin; PPT, PPTX ve ODP slayt formatlarını özelleştirin — düzenleri, yakınlaştırma seviyelerini ve görüntü ayarlarını ayarlayın."
---
## **Giriş**

Normal görünüm üç içerik bölgesinden oluşur: slayt kendisi, yan içerik bölgesi ve alt içerik bölgesi. Farklı içerik bölgelerinin konumlandırmasıyla ilgili özellikler. Bu bilgiler uygulamanın görünüm durumunu dosyaya kaydetmesini sağlar, böylece yeniden açıldığında görünüm sunum son kaydedildiği zamanki aynı durumda olur.

Sunumun normal görünüm özelliklerine erişim sağlamak için [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) yöntemi eklenmiştir.

[NormalViewProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewRestoredProperties) sınıfları ve bunların alt sınıfları, [SplitterBarStateType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SplitterBarStateType) enumı eklenmiştir.

## **INormalViewProperties hakkında**

Normal görünüm özelliklerini temsil eder.

[getShowOutlineIcons](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) ve [setShowOutlineIcons](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) yöntemleri, normal görünüm modundaki içerik bölgelerinden birinde anahat içeriği görüntüleniyorsa uygulamanın simge gösterip göstermeyeceğini belirtir.

[getSnapVerticalSplitter](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) ve [setSnapVerticalSplitter](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) yöntemleri, yan bölge yeterince küçük olduğunda dikey ayırıcı çubuğun küçültülmüş duruma otomatik yapışıp yapmayacağını belirtir.

[getPreferSingleView](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) ve [setPreferSingleView](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) özellikleri, kullanıcının üç içerik bölgesi olan standart normal görünüm yerine tam pencere tek içerik bölgesi görmeyi tercih edip etmediğini belirtir. Etkinleştirildiğinde, uygulama içerik bölgelerinden birini tüm pencerede gösterebilir.

[getVerticalBarState](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) ve [getHorizontalBarState](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) yöntemleri, yatay veya dikey ayırıcı çubuğun hangi durumda gösterileceğini belirtir. Yatay ayırıcı çubuk slaytı slaytın altındaki içerik bölgesinden ayırırken, dikey ayırıcı çubuk slaytı yan içerik bölgesinden ayırır. Olası değerler: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SplitterBarStateType/#Maximized) ve [SplitterBarStateType::Restored](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SplitterBarStateType/#Restored).

[getRestoredLeft](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) ve [getRestoredTop](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties#getRestoredTop) yöntemleri, [SplitterBarStateType::Restored](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SplitterBarStateType/#Restored) değeri [getVerticalBarState](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) ve [getHorizontalBarState](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) için uygulandığında normal görünümde üst veya yan slayt bölgesinin boyutlamasını belirtir.

## **INormalViewProperties geri yükleme hakkında**

Normal görünümde, bölge değişken bir geri yüklenmiş boyuta (ne küçültülmüş ne de büyütülmüş) sahip olduğunda slayt bölgesinin (üst bölge çocuğu olduğunda genişlik, sol bölge çocuğu olduğunda yükseklik) boyutlamasını belirtir.

[getDimensionSize](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) yöntemi, slayt bölgesinin (restoredTop çocuğu olduğunda genişlik, restoredLeft çocuğu olduğunda yükseklik) boyutunu belirtir.

[getAutoAdjust](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) yöntemi, uygulama içinde görünümü içeren pencere yeniden boyutlandırıldığında yan içerik bölgesinin yeni boyuta uyum sağlayıp sağlamayacağını belirtir.

Aşağıda verilen bir örnek, bir sunum için [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) özelliklerine nasıl erişileceğini gösterir.

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # Sunumun görünüm özelliklerini geri yükle
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Varsayılan Yakınlaştırma Değerini Ayarla**
{{% alert color="info" %}} 

Aspose.Slides for PHP via Java artık sunum için varsayılan yakınlaştırma değerinin ayarlanmasını destekliyor; böylece sunum açıldığında yakınlaştırma zaten ayarlanmış olur. Bu, bir sunumun [ViewProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ViewProperties) özelliği ayarlanarak yapılabilir. [getSlideViewProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) ve [getNotesViewProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) programlı olarak ayarlanabilir. Bu konuda, Aspose.Slides içinde bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) için [View Properties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ViewProperties) nasıl ayarlanır bir örnekle göreceğiz.

{{% /alert %}} 

Görünüm özelliklerini ayarlamak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) için [View Properties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ViewProperties) ayarlayın.
1. Sunumu bir [PPTX ](https://docs.fileformat.com/presentation/pptx/) dosyası olarak kaydedin.
   Aşağıda verilen örnekte, slayt görünümü ve not görünümü için yakınlaştırma değeri ayarlanmıştır.

```php
  $presentation = new Presentation();
  try {
    # Sunumun görünüm özelliklerini ayarlama
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // Slayt görünümü için yüzde cinsinden yakınlaştırma değeri
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // Notlar görünümü için yüzde cinsinden yakınlaştırma değeri

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Izgara Aralığını Ayarla**

[Presentation::getViewProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getViewProperties) kullanarak tüm sunuma ait görünüm ayarlarına erişin. [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/tr/php-java/aspose.slides/viewproperties/#getGridSpacing) ve [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/tr/php-java/aspose.slides/viewproperties/#setGridSpacing) yöntemleri temel düzenleme ızgarasının aralığını okur veya değiştirir. Bu ayar tüm sunuma uygulanır, tek bir slayta değil. Izgara aralığı nokta cinsinden belirtilir; 72 nokta bir inçtir. API belgelerinde belirtildiği gibi pozitif bir değer kullanın.

Aşağıdaki örnek, mevcut bir `demo.pptx` dosyasını açar, mevcut ızgara aralığını yazdırır, çeyrek inçlik bir aralık ayarlar ve sonucu kaydeder.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $gridSpacing = $presentation->getViewProperties()->getGridSpacing();
    echo "Current grid spacing: " . $gridSpacing . " points\n";

    $presentation->getViewProperties()->setGridSpacing(18.0);
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Izgara, [çizim kılavuzlarından](/slides/tr/php-java/drawing-guides/) farklıdır. Izgara aralığı düzenli bir aralığı kontrol eder, çizim kılavuzları ise ayrı ayrı konumlandırılmış yatay veya dikey hizalama çizgileridir. Çizim kılavuzlarını eklemek, taşımak veya temizlemek ızgara aralığını değiştirmez.

Izgara ve çizim kılavuzları her ikisi de düzenleme yardımcılarıdır. PDF, görüntüler, SVG veya slayt gösterisi içinde slayt içeriği olarak işlenmezler. Izgara aralığını depolamak, bir düzenleyicinin ızgarayı göstereceğini garanti etmez; görünürlüğü ayrıca görüntüleyici veya düzenleyicinin tercihlerine bağlıdır.

## **Sunum Açılırken Yorumları Gösterme veya Gizleme**

[Presentation::getViewProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/getviewproperties/) kullanarak tüm sunuma ait görünüm ayarlarına erişin. [ViewProperties::getShowComments](https://reference.aspose.com/slides/tr/php-java/aspose.slides/viewproperties/getshowcomments/) ve [ViewProperties::setShowComments](https://reference.aspose.com/slides/tr/php-java/aspose.slides/viewproperties/setshowcomments/) kullanarak yorumların PowerPoint ya da başka bir uyumlu düzenleyicide sunum açıldığında gösterilip gösterilmeyeceğiyle ilgili saklanan tercihi okuyabilir veya değiştirebilirsiniz.

Bu ayar yalnızca saklanan görünüm tercihini kontrol eder. Yorum ekleme, kaldırma, düzenleme veya çözümleme yapmaz. Yorumların gizlenmesi, içeriklerini, yazarlarını, konumlarını, yanıtlarını ve durumlarını korur. Yorumları değiştiren işlemler için [Presentation Comments](/slides/tr/php-java/presentation-comments/) bölümüne bakın.

Aşağıdaki örnek, yorum içeren mevcut bir `comments.pptx` dosyasına ihtiyaç duyar. Mevcut görünürlük ayarını yazdırır, yorumların gizlenmesini talep eder ve yorumları kaldırmadan yeni bir PPTX dosyası olarak kaydeder. Ayrıca yorum görünürlüğüyle birlikte ilk düzenleme görünümünü yapılandırmak için [ViewProperties::setLastView](https://reference.aspose.com/slides/tr/php-java/aspose.slides/viewproperties/setlastview/) ve [ViewType::SlideView](https://reference.aspose.com/slides/tr/php-java/aspose.slides/viewtype/#SlideView) kullanır.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $showComments = $presentation->getViewProperties()->getShowComments();
    echo "Current comment visibility: " . java_values($showComments) . PHP_EOL;

    $presentation->getViewProperties()->setShowComments(NullableBool::False);
    $presentation->getViewProperties()->setLastView(ViewType::SlideView);
    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Bu ayar, yorumların PDF, HTML, görüntü, notlar veya el ilanı dışa aktarmalarına dahil edilip edilmediğini belirlemez. İlgili dışa aktarım seçeneklerini ayrı ayrı yapılandırın.

## **SSS**

**Sunumu yeniden açtığımda ızgara neden görünmüyor?**  
Dosya ızgara aralığını depolar, ancak ızgaranın görüntülenip görüntülenmeyeceğini düzenleyici kontrol eder. Düzenleyicinin ızgara görünürlük ayarlarını kontrol edin.

**Çizim kılavuzlarını temizlemek ızgara aralığını değiştirir mi?**  
Hayır. Çizim kılavuzları ve ızgara aralığı bağımsız ayarlardır. Kılavuzları temizlemek, depolanan ızgara aralığını değiştirmez.

**Bir sunumun farklı bölümleri için farklı görünüm ayarları belirleyebilir miyim?**  
[View settings](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/getviewproperties/) sunum seviyesinde tanımlanır ([Normal View](https://reference.aspose.com/slides/tr/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/tr/php-java/aspose.slides/viewproperties/getslideviewproperties/)), bölüm bazında değil; bu nedenle tek bir parametre kümesi açıldığında tüm belgeye uygulanır.

**Farklı kullanıcılar için farklı görünüm durumlarını önceden tanımlayabilir miyim?**  
Hayır. Ayarlar dosyada depolanır ve paylaşımlıdır. Görüntüleyici uygulamalar kullanıcı tercihlerini dikkate alabilir, ancak dosya kendisi sadece bir görünüm özelliği kümesi içerir.

**Yeni sunumların aynı şekilde açılması için önceden tanımlı View Properties içeren bir şablon hazırlayabilir miyim?**  
Evet. [view properties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/getviewproperties/) sunum seviyesinde depolandığı için bunları bir şablona gömebilir ve aynı başlangıç görünüm yapılandırmasıyla yeni belgeler oluşturabilirsiniz.