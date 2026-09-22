---
title: "PHP'de Sunum Görünüm Özelliklerini Alma ve Güncelleme"
linktitle: "Görünüm Özellikleri"
type: docs
weight: 80
url: /tr/php-java/presentation-view-properties/
keywords:
- "görünüm özellikleri"
- "normal görünüm"
- "taslak içerik"
- "taslak simgeler"
- "dikey ayırıcıyı yakala"
- "tek görünüm"
- "çubuk durumu"
- "boyut ölçüsü"
- "otomatik ayar"
- "varsayılan yakınlaştırma"
- "PowerPoint"
- "OpenDocument"
- "sunum"
- "PHP"
- "Aspose.Slides"
description: "Aspose.Slides for PHP via Java görünüm özelliklerini keşfedin; PPT, PPTX ve ODP slayt formatlarını özelleştirin — düzenleri, yakınlaştırma seviyelerini ve gösterim ayarlarını ayarlayın."
---
## **Giriş**

Normal görünüm üç içerik bölgesinden oluşur: slayt kendisi, bir yan içerik bölgesi ve bir alt içerik bölgesi. Farklı içerik bölgelerinin konumlandırılmasıyla ilgili özellikler. Bu bilgi, uygulamanın görünüm durumunu dosyaya kaydetmesini sağlar; böylece açıldığında görünüm, sunum en son kaydedildiğinde olduğu durumla aynı olur.

Sunumun normal görünüm özelliklerine erişim sağlamak için [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) yöntemi eklenmiştir.  

[NormalViewProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewRestoredProperties) sınıfları ve bunların türevleri, [SplitterBarStateType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SplitterBarStateType) enumu eklenmiştir.

## **INormalViewProperties Hakkında**

Normal görünüm özelliklerini temsil eder.

[getShowOutlineIcons](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) ve [setShowOutlineIcons](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) yöntemleri, normal görünüm modunda içerik bölgelerinden birinde taslak içeriği görüntüleniyorsa uygulamanın simge gösterip göstermeyeceğini belirtir.

[getSnapVerticalSplitter](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) ve [setSnapVerticalSplitter](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) yöntemleri, yan bölge yeterince küçük olduğunda dikey ayırıcı çubuğun küçültülmüş bir duruma kilitlenip kilitlenmeyeceğini belirtir.

[getPreferSingleView](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) ve [setPreferSingleView](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) özellikleri, kullanıcının üç içerik bölgesi bulunan standart normal görünüm yerine tam pencere tek içerik bölgesi görmeyi tercih edip etmediğini belirtir. Etkinleştirildiğinde, uygulama içerik bölgelerinden birini tüm pencerede gösterebilir.

[getVerticalBarState](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) ve [getHorizontalBarState](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) yöntemleri, yatay ya da dikey ayırıcı çubuğun hangi durumda gösterileceğini belirler. Yatay ayırıcı çubuk, slaytı slaytın altındaki içerik bölgesinden ayırırken, dikey ayırıcı çubuk slaytı yan içerik bölgesinden ayırır. Olası değerler: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SplitterBarStateType/#Maximized) ve [SplitterBarStateType::Restored](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SplitterBarStateType/#Restored).

[getRestoredLeft](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) ve [getRestoredTop](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties#getRestoredTop) yöntemleri, [SplitterBarStateType::Restored](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SplitterBarStateType/#Restored) değeri [getVerticalBarState](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) ve [getHorizontalBarState](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) için uygulandığında normal görünümde üst ya da yan slayt bölgesinin boyutlandırmasını belirler.

## **INormalViewProperties’i Geri Yükleme Hakkında**

Normal görünümde bölge değişken bir geri yüklenmiş boyuta (ne küçültülmüş ne de büyütülmüş) sahip olduğunda, slayt bölgesinin (üst bölge çocuğu olduğunda genişlik, yan bölge çocuğu olduğunda yükseklik) boyutlandırmasını belirtir.  

[getDimensionSize](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) yöntemi, slayt bölgesinin (restoredTop çocuğu ise genişlik, restoredLeft çocuğu ise yükseklik) boyutunu belirtir.  

[getAutoAdjust](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) yöntemi, uygulama içinde görünümü içeren pencere yeniden boyutlandırıldığında yan içerik bölgesinin yeni boyuta göre ayarlanıp ayarlanmayacağını belirtir.  

Aşağıda verilen örnek, bir sunum için [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) özelliklerine nasıl erişileceğini gösterir.

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

## **Varsayılan Yakınlaştırma Değerini Ayarlama**
{{% alert color="info" %}} 

Aspose.Slides for PHP via Java artık bir sunum için varsayılan yakınlaştırma değerinin ayarlanmasını destekliyor; böylece sunum açıldığında yakınlaştırma zaten ayarlanmış olur. Bu, bir sunumun [ViewProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ViewProperties) ayarlanarak yapılabilir. [getSlideViewProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) ve [getNotesViewProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) programatik olarak ayarlanabilir. Bu bölümde, Aspose.Slides içinde bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) için [View Properties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ViewProperties) nasıl ayarlanır, bir örnekle göreceğiz.

{{% /alert %}} 

Görünüm özelliklerini ayarlamak için aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının örneğini oluşturun.
1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) için [View Properties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ViewProperties) ayarlayın.
1. Sunumu bir [PPTX ](https://docs.fileformat.com/presentation/pptx/) dosyası olarak kaydedin. Aşağıda verilen örnekte, slayt görünümü ve not görünümü için yakınlaştırma değerini ayarladık.

```php
  $presentation = new Presentation();
  try {
    # Sunumun görünüm özelliklerini ayarlama
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // Slayt görünümü için yüzde cinsinden yakınlaştırma değeri
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // Not görünümü için yüzde cinsinden yakınlaştırma değeri

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Izgara Boşluğunu Ayarlama**

[Presentation::getViewProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getViewProperties) yöntemini kullanarak sunum genelindeki görünüm ayarlarına erişin. [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/tr/php-java/aspose.slides/viewproperties/#getGridSpacing) ve [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/tr/php-java/aspose.slides/viewproperties/#setGridSpacing) yöntemleri temel düzenleme ızgarasının aralığını okur veya değiştirir. Bu ayar tüm sunuma uygulanır, tek bir slayta değil. Izgara boşluğu point cinsinden belirtilir; 72 point bir inç eşittir. API belgelerinde belirtildiği gibi pozitif bir değer kullanın.

Aşağıdaki örnek mevcut bir `demo.pptx` dosyasını açar, mevcut ızgara boşluğunu yazar, çeyrek inçlik bir aralık ayarlar ve sonucu kaydeder.

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

Izgara, [drawing guides](/slides/tr/php-java/drawing-guides/) öğesinden farklıdır. Izgara boşluğu düzenli bir aralığı kontrol ederken, çizim kılavuzları yatay veya dikey hizalama çizgileri olarak ayrı ayrı konumlandırılır. Çizim kılavuzlarını eklemek, taşımak veya temizlemek ızgara boşluğunu değiştirmez.

Izgara ve çizim kılavuzları her ikisi de düzenleme yardımıdır. PDF, görüntüler, SVG veya bir slayt gösterisinde slayt içeriği olarak işlenmezler. Izgara boşluğunu saklamak, bir düzenleyicinin ızgarayı göstereceğini garanti etmez; görünürlüğü ayrıca görüntüleyici veya düzenleyicinin tercihlerine bağlıdır.

## **SSS**

**Sunumu tekrar açtığımda ızgara neden görünmüyor?**

Dosya ızgara boşluğunu saklar, ancak düzenleyici ızgaranın gösterilip gösterilmeyeceğini kontrol eder. Düzenleyicinin ızgara görünürlük ayarlarını kontrol edin.

**Çizim kılavuzlarını temizlemek ızgara boşluğunu değiştirir mi?**

Hayır. Çizim kılavuzları ve ızgara boşluğu bağımsız ayarlardır. Kılavuzları temizlemek saklanan ızgara aralığını değiştirmez.

**Bir sunumun farklı bölümleri için farklı görünüm ayarları belirleyebilir miyim?**

[View settings](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/getviewproperties/) sunum seviyesinde ([Normal View](https://reference.aspose.com/slides/tr/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/tr/php-java/aspose.slides/viewproperties/getslideviewproperties/)) tanımlanır, bölüm bazında değil; böylece bir kez tanımlanan parametreler belge açıldığında tüm belgeye uygulanır.

**Farklı kullanıcılar için önceden tanımlı farklı görünüm durumları belirleyebilir miyim?**

Hayır. Ayarlar dosyada saklanır ve paylaşılır. Görüntüleyici uygulamalar kullanıcı tercihlerini uygulayabilir, ancak dosyada yalnızca tek bir görünüm özelliği kümesi bulunur.

**Yeni sunumların aynı şekilde açılması için önceden tanımlı Görünüm Özellikleriyle bir şablon hazırlayabilir miyim?**

Evet. [View properties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/getviewproperties/) sunum seviyesinde saklandığı için bunları bir şablona gömebilir ve aynı başlangıç görünüm yapılandırmasıyla yeni belgeler oluşturabilirsiniz.