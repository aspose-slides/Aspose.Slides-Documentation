---
title: JavaScript'te Sunum Görünüm Özelliklerini Al ve Güncelle
linktitle: Görünüm Özellikleri
type: docs
weight: 80
url: /tr/nodejs-java/presentation-view-properties/
keywords:
- görünüm özellikleri
- normal görünüm
- taslak içerik
- taslak simgeler
- dikey bölücüyü yakala
- tek görünüm
- çubuk durumu
- boyut ölçüsü
- otomatik ayar
- varsayılan yakınlaştırma
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java görünüm özelliklerini keşfedin; PPT, PPTX ve ODP slayt formatlarını özelleştirin—düzenleri, yakınlaştırma seviyelerini ve görüntüleme ayarlarını ayarlayın."
---
## **Giriş**

Normal görünüm üç içerik bölgesinden oluşur: slayt kendisi, bir yan içerik bölgesi ve bir alt içerik bölgesi. Farklı içerik bölgelerinin konumlandırmasıyla ilgili özellikler. Bu bilgiler uygulamanın görünüm durumunu dosyaya kaydetmesini sağlar, böylece yeniden açıldığında görünüm, sunumun en son kaydedildiği durumla aynı olur.

Sunumun normal görünüm özelliklerine erişim sağlamak için [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) yöntemi eklenmiştir.  

[NormalViewProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewRestoredProperties) sınıfları ve bunların türevleri, [SplitterBarStateType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SplitterBarStateType) enumu eklenmiştir.

## **NormalViewProperties Hakkında**

Normal görünüm özelliklerini temsil eder.

[getShowOutlineIcons](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) ve [setShowOutlineIcons](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) yöntemleri, normal görünüm modunda içerik bölgelerinden birinde taslak içerik gösteriliyorsa uygulamanın simgeleri gösterip göstermeyeceğini belirtir.

[getSnapVerticalSplitter](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) ve [setSnapVerticalSplitter](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) yöntemleri, yan bölge yeterince küçük olduğunda dikey bölücünün küçültülmüş bir duruma yapışıp yapışmayacağını belirtir.

[getPreferSingleView](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) ve [setPreferSingleView](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean--) özellikleri, kullanıcının standart üç içerik bölgesiyle normal görünüm yerine tam pencere tek içerik bölgesi görmeyi tercih edip etmediğini belirtir. Etkinleştirildiğinde, uygulama içerik bölgelerinden birini tüm pencere içinde göstermeyi seçebilir.

[getVerticalBarState](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) ve [getHorizontalBarState](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) yatay veya dikey bölücü çubuğunun gösterilmesi gereken durumu belirtir. Yatay bölücü çubuk slaytı slaytın altındaki içerik bölgesinden ayırır, dikey bölücü çubuk slaytı yan içerik bölgesinden ayırır. Olası değerler: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) ve [SplitterBarStateType.Restored](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

[getRestoredLeft](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) ve [getRestoredTop](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) normal görünümde üst veya yan slayt bölgesinin boyutlandırılmasını, [SplitterBarStateType.Restored](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SplitterBarStateType#Restored) değeri [getVerticalBarState](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) ve [getHorizontalBarState](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) için uygulandığında belirtir.

## **NormalViewProperties Geri Yükleme Hakkında**

Normal görünümde bölgenin değişken geri yüklenmiş boyutta (ne küçültülmüş ne de büyütülmüş) olduğunda slayt bölgesinin (üstteki [getRestoredTop](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) çocuğu olduğunda genişlik, yan [getRestoredLeft](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) çocuğu olduğunda yükseklik) boyutlandırılmasını belirtir.

[getDimensionSize](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) yöntemi, slayt bölgesinin (restoredTop çocuğu olduğunda genişlik, restoredLeft çocuğu olduğunda yükseklik) boyutunu belirtir.

[getAutoAdjust](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) yöntemi, uygulama içinde görünümü içeren pencere yeniden boyutlandırıldığında yan içerik bölgesinin yeni boyuta göre ayarlanıp ayarlanmayacağını belirtir.

Aşağıda verilen bir örnek, bir sunum için [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) özelliklerine nasıl erişileceğini göstermektedir.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // Sunumun görünüm özelliklerini geri yükle
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Varsayılan Yakınlaştırma Değerini Ayarlama**

{{% alert color="info" %}} 

Aspose.Slides for Node.js via Java artık sunum için varsayılan yakınlaştırma değerini ayarlamayı destekliyor, böylece sunum açıldığında yakınlaştırma zaten ayarlanmış oluyor. Bu, bir sunumun [ViewProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ViewProperties) ayarlanarak yapılabilir. [getSlideViewProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) ve [getNotesViewProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) programlı olarak ayarlanabilir. Bu konuda, Aspose.Slides içinde bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) nesnesinin [View Properties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ViewProperties) nasıl ayarlanır, bir örnekle göreceğiz.

{{% /alert %}} 

Görünüm özelliklerini ayarlamak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) nesnesinin [View Properties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ViewProperties) ayarını yapın.
3. Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak kaydedin.
   Aşağıda verilen örnekte, slayt görünümü ve not görünümü için yakınlaştırma değeri ayarlanmıştır.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    // Sunumun görünüm özelliklerini ayarlama
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Slayt görünümü için yüzde olarak yakınlaştırma değeri
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Not görünümü için yüzde olarak yakınlaştırma değeri
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Izgara Aralığını Ayarlama**

[Presentation.getViewProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#getViewProperties--) yöntemini kullanarak sunum geneli görünüm ayarlarına erişin. [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) ve [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) yöntemleri temel düzenleme ızgarasının aralığını okur veya değiştirir. Bu ayar tüm sunuma uygulanır, tek bir slayta değil. Izgara aralığı nokta cinsinden belirtilir; 72 nokta bir inçe eşittir. API belgelerinde belirtildiği gibi pozitif bir değer kullanın.

Aşağıdaki örnek mevcut bir `demo.pptx` dosyasını açar, mevcut ızgara aralığını yazdırır, çeyrek inçlik bir aralık ayarlar ve sonucu kaydeder.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("demo.pptx");
try {
    var gridSpacing = presentation.getViewProperties().getGridSpacing();
    console.log("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18);
    presentation.save("grid-spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Izgara, [çizim kılavuzlarından](/slides/tr/nodejs-java/drawing-guides/) farklıdır. Izgara aralığı düzenli bir aralığı kontrol ederken, çizim kılavuzları yatay veya dikey hizalama çizgileri olarak bireysel konumlandırılır. Çizim kılavuzları eklemek, taşımak veya temizlemek ızgara aralığını değiştirmez.

Izgaralar ve çizim kılavuzları her ikisi de düzenleme yardımcılarıdır. PDF, görüntüler, SVG veya slayt gösterisinde slayt içeriği olarak işlenmezler. Izgara aralığının dosyada saklanması, bir düzenleyicinin ızgarayı göstereceğini garanti etmez; görünürlüğü ayrıca izleyici veya düzenleyicinin tercihine bağlıdır.

## **SSS**

**Sunumu yeniden açtıktan sonra ızgara neden görünmüyor?**

Dosya ızgara aralığını saklar, ancak düzenleyici ızgaranın gösterilip gösterilmeyeceğini kontrol eder. Düzenleyicinin ızgara görünürlük ayarlarını kontrol edin.

**Çizim kılavuzlarını temizlemek ızgara aralığını değiştirir mi?**

Hayır. Çizim kılavuzları ve ızgara aralığı bağımsız ayarlardır. Kılavuzları temizlemek saklanan ızgara aralığını değiştirmez.

**Sunumun farklı bölümleri için farklı görünüm ayarları belirleyebilir miyim?**

[View settings](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/getviewproperties/) sunum seviyesinde tanımlanır (Normal Görünüm/Slayt Görünümü), bölüm bazında değil, bu yüzden tek bir parametre seti belge açıldığında tüm belgeye uygulanır.

**Farklı kullanıcılar için farklı görünüm durumları önceden tanımlayabilir miyim?**

Hayır. Ayarlar dosyada saklanır ve paylaşımlıdır. Görüntüleyici uygulamalar kullanıcı tercihlerine saygı gösterebilir, ancak dosyanın kendisi tek bir görünüm özelliği seti içerir.

**Yeni sunumların aynı şekilde açılması için önceden tanımlı View Properties içeren bir şablon hazırlayabilir miyim?**

Evet. Çünkü [view properties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/getviewproperties/) sunum seviyesinde saklanır, bunları bir şablona gömebilir ve yeni belgeler oluşturduğunuzda aynı başlangıç görünüm yapılandırmasını alabilirsiniz.