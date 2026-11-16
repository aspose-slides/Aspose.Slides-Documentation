---
title: JavaScript'te Sunum Görünüm Özelliklerini Getirme ve Güncelleme
linktitle: Görünüm Özellikleri
type: docs
weight: 80
url: /tr/nodejs-java/presentation-view-properties/
keywords:
- görünüm özellikleri
- normal görünüm
- taslak içeriği
- taslak simgeleri
- dikey bölücü yakalama
- tek görüntü
- çubuk durumu
- boyut boyutu
- otomatik ayarlama
- varsayılan yakınlaştırma
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint sunumlarında normal görünüm düzenini, slayt ve not yakınlaştırmasını, ızgara aralığını ve yorum görünürlüğünü yapılandırmak için Java aracılığıyla Node.js için Aspose.Slides'ı kullanın."
---
## **Introduction**

PowerPoint'in normal görünümünde, slayt, küçük resimler veya bir taslak için yan panel ile alttaki notlar paneli arasında görüntülenir. Aspose.Slides for Node.js via Java, sunumu kaydedilmiş düzenleme tercihlerini [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties) aracılığıyla ortaya çıkarır. Bunlar arasında panel düzeni, yakınlaştırma seviyeleri, ızgara aralığı ve yorum görünürlüğü bulunur.

## **About NormalViewProperties**

[getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNormalViewProperties) metodunu kullanarak [NormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/) sınıfına erişin. [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) özelliği, taslakta slayt başlıklarının yanında simgelerin görünüp görünmeyeceğini kontrol eder. [setSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) yöntemi, kullanıcı yan paneli daralttığında panelin küçültülmüş hâline kilitlenmesini sağlar. [setPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setPreferSingleView) tam pencere içinde tek bir panel gösterilmesi tercihini belirtir.

[setVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setVerticalBarState) yan panel ile slayt arasındaki bölücüyü kontrol eder. [setHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setHorizontalBarState) notlar panelinin üzerindeki bölücüyü kontrol eder. Her ikisi de `Minimized`, `Maximized` veya `Restored` değerlerinden birini alan [SplitterBarStateType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/splitterbarstatetype/) tipini kabul eder.

## **About Restoring NormalViewProperties**

Bir bölücü geri yüklendiğinde, [getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredLeft) yan panelin kaydedilmiş boyutunu, [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) ise üst slayt alanının kaydedilmiş boyutunu sağlar. Her ikisi de [NormalViewRestoredProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/) sınıfını ortaya çıkarır. [setDimensionSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) metodu %0 ile %100 arasında bir yüzde alır ve [setAutoAdjust](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) pencere yeniden boyutlandırıldığında düzenleyicinin boyutu ayarlayıp ayarlamayacağını kontrol eder.

Bu örnek mevcut bir sunumu günceller. Yatay bölücüyü geri yükler, [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) tarafından döndürülen boyutu %80 olarak ayarlar ve otomatik ayarlamayı etkinleştirir, ayrıca dikey bölücüyü büyütür. Ayrıca taslak görünümünde simgelerin gösterilmesi için [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) çağrılır.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(slides.SplitterBarStateType.Restored);
    normalView.setVerticalBarState(slides.SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Set the Default Zoom Value**

[getSlideViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getSlideViewProperties) ve [getNotesViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNotesViewProperties) düzenleyici için bağımsız yakınlaştırma ayarlarını depolar. Bu ayarlar slayt boyutlarını, slayt gösterisi oynatımını veya görüntü dışa aktarım çözünürlüğünü etkilemez.

Bu örnek mevcut bir sunumu açar ve slaytı düzenleme penceresine sığdırmak için [setVariableScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setVariableScale) metodunu çağırır. Notlar sayfası için otomatik ölçeklendirmeyi devre dışı bırakır ve sabit %80 yakınlaştırma ayarlamak üzere [setScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setScale) metodunu çağırır.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Set the Grid Spacing**

[setGridSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setGridSpacing) sunum boyunca düzenleme ızgara çizgileri arasındaki mesafeyi ayarlar. İnç başına 72 puan olmak üzere pozitif bir değer alır. Bu örnek mevcut bir sunumdaki mevcut aralığı yazdırır ve aralığı 18 puana ayarlayarak çeyrek inçlik bir ızgara kaydeder.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18);

    presentation.save("grid-spacing.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Izgara sabit bir aralıkta tekrarlanır. [Çizim kılavuzları](/slides/tr/nodejs-java/drawing-guides/) bireysel yatay veya dikey konumları işaretler. Her ikisi de düzenleme yardımcılarıdır ve yalnızca bunları gösteren düzenleyicilerde görünür. Slayt gösterileri ve PDF, görüntü ya da SVG dışa aktarımları bunları içermez.

## **Show or Hide Comments When Opening a Presentation**

[setShowComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setShowComments) sunumu açarken uyumlu düzenleyicilerin kullandığı bir tercih saklar. Yorumları olan mevcut bir sunum için bu örnek mevcut ayarı yazdırır ve yorumları gizli bir kopya kaydeder. Ayrıca kopyanın slayt görünümünde açılması için [setLastView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setLastView) metodunu [ViewType.SlideView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewtype/#SlideView) ile çağırır.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current comment visibility: " + viewProperties.getShowComments());

    const hideComments = java.newByte(slides.NullableBool.False);
    viewProperties.setShowComments(hideComments);
    viewProperties.setLastView(slides.ViewType.SlideView);

    presentation.save("comments-hidden.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Yorumları gizlemek, metinlerini, yazarlarını, konumlarını, yanıtlarını ve durumlarını korur. Yorumları kendisini değiştirmek için [Sunum Yorumları](/slides/tr/nodejs-java/presentation-comments/) bölümüne bakın. Dışa aktarma ayarları, yorumların PDF, HTML, görüntüler, notlar veya el ilanlarında görünüp görünmeyeceğini kontrol eder.

## **FAQ**

**Sunumu tekrar açtığımda ızgara neden gizleniyor?**

Sunum ızgara aralığını depolar. Izgarayı görmek için düzenleyicide ızgara görünürlüğünü etkinleştirin.

**Çizim kılavuzlarını silmek ızgara aralığını değiştirir mi?**

Hayır. Bir kılavuz eklemek, taşımak veya silmek ızgara aralığını değiştirmez.

**Bir sunumun farklı bölümleri farklı görünüm ayarlarına sahip olabilir mi?**

Hayır. [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties) tüm sunuma uygulanır.

**Farklı kullanıcılar için farklı görünüm ayarları kaydedebilir miyim?**

Dosya herkes için tek bir görünüm özelliği seti saklar. Bir düzenleyici ayrıca kullanıcının yerel tercihlerine de uygulayabilir.

**Bir şablonda görünüm ayarlarını kaydedebilir miyim?**

Evet. Şablondan oluşturulan sunumlar, kaydedilmiş görünüm ayarlarını devralır.