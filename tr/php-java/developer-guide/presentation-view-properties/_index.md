---
title: PHP'de Sunum Görünüm Özelliklerini Al ve Güncelle
linktitle: Görünüm Özellikleri
type: docs
weight: 80
url: /tr/php-java/presentation-view-properties/
keywords:
- görünüm özellikleri
- normal görünüm
- taslak içerik
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
description: "Aspose.Slides for PHP via Java görünüm özelliklerini keşfedin ve PPT, PPTX ve ODP slayt formatlarını özelleştirin — düzenleri, yakınlaştırma seviyelerini ve görüntü ayarlarını ayarlayın."
---
## **Giriş**

Normal görünüm üç içerik bölgesinden oluşur: slayt kendisi, bir yan içerik bölgesi ve bir alt içerik bölgesi. Farklı içerik bölgelerinin konumlandırılmasıyla ilgili özellikler. Bu bilgi, uygulamanın görünüm durumunu dosyaya kaydetmesini sağlar, böylece yeniden açıldığında görünüm, sunum son kaydedildiği zamanki durumla aynı olur.

Sunumun normal görünüm özelliklerine erişim sağlamak için [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) yöntemi eklenmiştir.

[NormalViewProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewRestoredProperties) sınıfları ve onun türevleri, [SplitterBarStateType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SplitterBarStateType) enumu eklendi.

## **INormalViewProperties Hakkında**

Normal görünüm özelliklerini temsil eder.

[getShowOutlineIcons](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) ve [setShowOutlineIcons](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) yöntemleri, normal görünüm modunda içerik bölgelerinden birinde taslak içeriği görüntüleniyorsa uygulamanın simgeleri gösterip göstermeyeceğini belirler.

[getSnapVerticalSplitter](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) ve [setSnapVerticalSplitter](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) yöntemleri, yan bölge yeterince küçük olduğunda dikey bölücünün küçültülmüş bir duruma kilitlenip kilitlenmeyeceğini belirler.

[getPreferSingleView](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) ve [setPreferSingleView](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) özellikleri, kullanıcının üç içerik bölgesiyle standart normal görünüm yerine tam pencere tek içerik bölgesi görmeyi tercih edip etmediğini belirler. Etkinleştirilirse, uygulama içerik bölgelerinden birini tüm pencerede görüntülemeyi seçebilir.

[getVerticalBarState](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) ve [getHorizontalBarState](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) yöntemleri, yatay veya dikey bölücü çubuğunun gösterilmesi gereken durumu belirtir. Yatay bölücü çubuğu, slaytı slaytın altındaki içerik bölgesinden ayırırken, dikey bölücü çubuğu slaytı yan içerik bölgesinden ayırır. Olası değerler: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SplitterBarStateType/#Maximized) ve [SplitterBarStateType::Restored](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SplitterBarStateType/#Restored).

[getRestoredLeft](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) ve [getRestoredTop](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties#getRestoredTop) yöntemleri, normal görünümde üst veya yan slayt bölgesinin boyutlandırılmasını, [SplitterBarStateType::Restored](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SplitterBarStateType/#Restored) değerinin [getVerticalBarState](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) ve [getHorizontalBarState](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) için uygulanması durumunda belirtir.

## **INormalViewProperties Geri Yüklenmesi Hakkında**

Normal görünümde bölge değişken bir geri yüklenmiş boyuta (ne küçültülmüş ne de genişletilmiş) sahip olduğunda, slayt bölgesinin ([getRestoredTop](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#getRestoredTop) altıysa genişlik, [getRestoredLeft](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) altıysa yükseklik) boyutlandırmasını belirtir.

[getDimensionSize](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) yöntemi, slayt bölgesinin (restoredTop altıysa genişlik, restoredLeft altıysa yükseklik) boyutunu belirtir.

[getAutoAdjust](https://reference.aspose.com/slides/tr/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) yöntemi, uygulama içinde görünümü içeren pencere yeniden boyutlandırıldığında yan içerik bölgesinin boyutunun yeni boyuta göre ayarlanıp ayarlanmayacağını belirtir.

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
{{% alert color="primary" %}} 
Aspose.Slides for PHP via Java artık sunum için varsayılan yakınlaştırma değerinin ayarlanmasını destekliyor; böylece sunum açıldığında yakınlaştırma zaten ayarlanmış olur. Bu, bir sunumun [ViewProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ViewProperties) ayarlanarak yapılabilir. [getSlideViewProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) ve [getNotesViewProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) programlı olarak ayarlanabilir. Bu konuda, bir örnekle [Aspose.Slides](/slides/tr/) içinde [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) için [View Properties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ViewProperties) nasıl ayarlanır gösterilecektir.
{{% /alert %}} 

Görünüm özelliklerini ayarlamak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) için [View Properties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ViewProperties) ayarlayın.
3. Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak yazın.  
   Aşağıda verilen örnekte, slayt görünümü ve not görünümü için yakınlaştırma değerini ayarladık.

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

## **SSS**

**Bir sunumun farklı bölümleri için farklı görünüm ayarları belirleyebilir miyim?**

[View settings](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/getviewproperties/) sunum düzeyinde ([Normal View](https://reference.aspose.com/slides/tr/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/tr/php-java/aspose.slides/viewproperties/getslideviewproperties/)) tanımlanır, bölüm bazında değil; bu nedenle sunum açıldığında tüm belgeye tek bir parametre seti uygulanır.

**Farklı kullanıcılar için farklı görünüm durumları önceden tanımlayabilir miyim?**

Hayır. Ayarlar dosyada depolanır ve paylaşılır. Görüntüleyici uygulamalar kullanıcı tercihlerini dikkate alabilir, ancak dosya kendisi tek bir görünüm özelliği seti içerir.

**Önceden tanımlanmış View Properties ile bir şablon hazırlayabilir miyim, böylece yeni sunumlar aynı şekilde açılır?**

Evet. [view properties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/getviewproperties/) sunum düzeyinde depolandığı için, bunları bir şablona gömebilir ve aynı başlangıç görünüm yapılandırmasıyla yeni belgeler oluşturabilirsiniz.