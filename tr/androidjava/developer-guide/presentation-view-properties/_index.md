---
title: Android'de Sunum Görünüm Özelliklerini Al ve Güncelle
linktitle: Görünüm Özellikleri
type: docs
weight: 80
url: /tr/androidjava/presentation-view-properties/
keywords:
- görünüm özellikleri
- normal görünüm
- taslak içeriği
- taslak simgeleri
- dikey bölücü yakalama
- tek görünüm
- çubuk durumu
- boyut ölçüsü
- otomatik ayar
- varsayılan yakınlaştırma
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java kullanarak PowerPoint sunumlarında normal görünüm düzenini, slayt ve not yakınlaştırmasını, ızgara aralığını ve yorum görünürlüğünü yapılandırın."
---
## **Giriş**

PowerPoint'in normal görünümünde, slayt, küçük resimler veya bir taslak için yan panel ile altında notlar paneli arasında görünür. Aspose.Slides for Android via Java, sunumun kaydedilmiş düzenleme tercihlerini [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) aracılığıyla sunar. Bunlar arasında panel düzeni, yaklaştırma seviyeleri, ızgara aralığı ve yorum görünürlüğü bulunur.

## **INormalViewProperties hakkında**

Sunumun [getNormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNormalViewProperties--) aracılığıyla [INormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/) arayüzüne erişilir. [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) taslakta slayt başlıklarının yanında simgelerin görünmesini kontrol eder. [setSnapVerticalSplitter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) yan panelin, kullanıcı daralttığında küçültülmüş durumuna yapışmasını sağlar. [setPreferSingleView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) tüm pencere içinde tek bir panelin gösterilmesine tercih olduğunu belirtir.

[setVerticalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) yan panel ile slayt arasındaki bölücüyü kontrol eder. [setHorizontalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) notlar panelinin üstündeki bölücüyü kontrol eder. Her ikisi de `Minimized`, `Maximized` veya `Restored` değerlerinden birini alan bir [SplitterBarStateType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/splitterbarstatetype/) değerini kabul eder.

## **INormalViewProperties geri yükleme hakkında**

Bir bölücü geri yüklendiğinde, [getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) yan panelin kaydedilmiş boyutunu ve [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) üst slayt alanının kaydedilmiş boyutunu sağlar. Her ikisi de [INormalViewRestoredProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/) sunar. Bunun [setDimensionSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) yöntemi %0 ile %100 arasında bir yüzde alır ve [setAutoAdjust](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) pencere yeniden boyutlandırıldığında editörün boyutu ayarlayıp ayarlamayacağını kontrol eder.

Bu örnek mevcut bir sunumu günceller. Yatay bölücüyü geri yükler, [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) tarafından döndürülen boyutu otomatik ayarlama etkinleştirilmiş şekilde %80 olarak ayarlar ve dikey bölücüyü maksimize eder. Ayrıca taslak görünümünde simgeleri göstermek için [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) çağrılır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    INormalViewProperties normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(SplitterBarStateType.Restored);
    normalView.setVerticalBarState(SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **Varsayılan Yakınlaştırma Değerini Ayarlama**

[getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getSlideViewProperties--) ve [getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNotesViewProperties--) editör için bağımsız yakınlaştırma ayarlarını depolar. Bu ayarlar slayt boyutlarını, slayt gösterisi oynatımını veya görüntü dışa aktarım çözünürlüğünü etkilemez.

Bu örnek mevcut bir sunumu açar ve slaytı düzenleme penceresine sığdırmak için [setVariableScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-) çağırır. Notlar sayfası için otomatik ölçeklemeyi devre dışı bırakır ve sabit %80 yakınlaştırma ayarlamak için [setScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setScale-int-) çağırır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **Izgara Aralığını Ayarlama**

[setGridSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) sunum boyunca düzenleme ızgara çizgileri arasındaki mesafeyi ayarlar. İnç başına 72 puan olmak üzere pozitif bir değer alır. Bu örnek mevcut bir sunumdaki mevcut aralığı yazdırır ve aralığı 18 puan olarak ayarlayarak çeyrek inçlik bir ızgara kaydeder.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18f);

    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
Izgara sabit bir aralıkla tekrar eder. [Çizim kılavuzları](/slides/tr/androidjava/drawing-guides/) bireysel yatay veya dikey konumları işaretler. Her ikisi de düzenleme yardımcılarıdır ve yalnızca bunları gösteren editörlerde görünür. Slayt gösterileri ve PDF, görüntü veya SVG dışa aktarımları bunları çıkartır.

## **Sunum Açarken Yorumları Gösterme veya Gizleme**

[setShowComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) uyumlu editörlerin sunumu açarken kullandığı bir tercih kaydeder. Yorumlu mevcut bir sunum için bu örnek mevcut ayarı yazdırır ve yorumları gizli bir kopya kaydeder. Ayrıca kopyanın slayt görünümünde açılması için [setLastView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) ile [ViewType.SlideView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewtype/#SlideView) çağrılır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("comments.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current comment visibility: " + viewProperties.getShowComments());

    viewProperties.setShowComments(NullableBool.False);
    viewProperties.setLastView(ViewType.SlideView);

    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
Yorumların gizlenmesi, metinlerini, yazarlarını, konumlarını, yanıtlarını ve durumlarını korur. Yorumları kendilerini değiştirmek için [Sunum Yorumları](/slides/tr/androidjava/presentation-comments/) bölümüne bakın. Dışa aktarma ayarları, yorumların PDF, HTML, görüntüler, notlar veya el ilanlarında görünüp görünmeyeceğini kontrol eder.

## **SSS**

**Sunumu yeniden açtığımda ızgara neden gizleniyor?**  
Sunum ızgara aralığını kaydeder. Izgarayı görmek için editörde ızgara görünürlüğünü etkinleştirin.

**Çizim kılavuzlarını temizlemek ızgara aralığını değiştirir mi?**  
Hayır. Bir kılavuz eklemek, taşımak veya temizlemek ızgara aralığını değiştirmez.

**Bir sunumun farklı bölümleri farklı görünüm ayarlarına sahip olabilir mi?**  
Hayır. [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) tüm sunuma uygulanır.

**Farklı kullanıcılar için farklı görünüm ayarları kaydedebilir miyim?**  
Dosya herkes için tek bir görünüm özelliği seti saklar. Bir editör ayrıca kullanıcının yerel tercihlerini uygulayabilir.

**Bir şablonda görünüm ayarlarını kaydedebilir miyim?**  
Evet. Şablondan oluşturulan sunumlar, kaydedilmiş görünüm ayarlarını devralır.