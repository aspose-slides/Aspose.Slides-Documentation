---
title: Java'da Sunum Görünüm Özelliklerini Getirme ve Güncelleme
linktitle: Görünüm Özellikleri
type: docs
weight: 80
url: /tr/java/presentation-view-properties/
keywords:
- görünüm özellikleri
- normal görünüm
- taslak içeriği
- taslak simgeleri
- dikey bölücü yakalama
- tek görünüm
- çubuk durumu
- boyut ölçüsü
- otomatik ayarlama
- varsayılan yakınlaştırma
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Java için Aspose.Slides kullanarak PowerPoint sunumlarında normal görünüm düzenini, slayt ve not yakınlaştırmasını, ızgara aralığını ve yorum görünürlüğünü yapılandırın."
---
## **Giriş**

PowerPoint'in normal görünümünde, slayt, küçük resimler veya bir taslak için yan panel ile alttaki notlar paneli arasında görünür. Aspose.Slides for Java, sunumun kaydedilmiş düzenleme tercihlerini [Presentation.getViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--) aracılığıyla ortaya çıkar. Bunlar panel yerleşimi, yakınlaştırma seviyeleri, ızgara aralığı ve yorum görünürlüğünü içerir.

## **INormalViewProperties Hakkında**

[getNormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getNormalViewProperties--) kullanarak [INormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/) arabirimine erişin. [setShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) taslakta slayt başlıklarının yanında simgelerin görünüp görünmeyeceğini kontrol eder. [setSnapVerticalSplitter](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) kullanıcı yan paneli daralttığında panelin küçültülmüş durumuna yapışmasını sağlar. [setPreferSingleView](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) tam pencerede tek bir panelin gösterilmesini tercih eder.

[setVerticalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) yan panel ile slayt arasındaki bölücüyü kontrol eder. [setHorizontalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) notlar panelinin üzerindeki bölücüyü kontrol eder. İkisi de `Minimized`, `Maximized` veya `Restored` değerlerinden birini alan [SplitterBarStateType](https://reference.aspose.com/slides/java/com.aspose.slides/splitterbarstatetype/) değerini kabul eder.

## **INormalViewProperties Geri Yükleme Hakkında**

Bir bölücü geri yüklendiğinde, [getRestoredLeft](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) yan panelin kaydedilmiş boyutunu ve [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredTop--) üst slayt alanının kaydedilmiş boyutunu sağlar. İkisi de [INormalViewRestoredProperties](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/) sunar. Bu arayüzün [setDimensionSize](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) yöntemi 0 ile 100 arasında bir yüzde kabul eder ve [setAutoAdjust](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) pencere yeniden boyutlandırıldığında editörün boyutu ayarlayıp ayarlamayacağını kontrol eder.

Bu örnek mevcut bir sunumu günceller. Yatay bölücüyü geri yükler, [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredTop--) tarafından döndürülen boyutu otomatik ayarlama etkinleştirerek %80'e ayarlar ve dikey bölücüyü en çok büyütür. Ayrıca outline görünümünde simgelerin görüntülenmesi için [setShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) çağrılır.

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

[getSlideViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getSlideViewProperties--) ve [getNotesViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getNotesViewProperties--) editör için bağımsız yakınlaştırma ayarları saklar. Bu ayarlar slayt boyutlarını, slayt gösterisi oynatımını veya görüntü dışa aktarım çözünürlüğünü etkilemez.

Bu örnek mevcut bir sunumu açar ve slaytı düzenleme penceresine sığdırmak için [setVariableScale](https://reference.aspose.com/slides/java/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-) çağırır. Notlar sayfası için otomatik ölçeklemeyi devre dışı bırakır ve sabit %80 yakınlaştırma ayarlamak üzere [setScale](https://reference.aspose.com/slides/java/com.aspose.slides/icommonslideviewproperties/#setScale-int-) yöntemini kullanır.

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

[setGridSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) sunum boyunca düzenleme ızgara çizgileri arasındaki mesafeyi ayarlar. Pozitif bir değer alır; bir inç başına 72 nokta vardır. Bu örnek mevcut bir sunumda mevcut aralığı yazdırır ve aralığı 18 noktaya ayarlayarak çeyrek inçlik bir ızgara kaydeder.

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

Izgara sabit bir aralıkla tekrarlanır. [Çizim kılavuzları](/slides/tr/java/drawing-guides/) bireysel yatay veya dikey konumları işaretler. İkisi de düzenleme yardımıdır ve yalnızca bunları gösteren editörlerde görünür. Slayt gösterileri ve PDF, görüntü ya da SVG dışa aktarmaları bunları içermez.

## **Sunum Açılırken Yorumları Gösterme veya Gizleme**

[setShowComments](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setShowComments-byte-) uyumlu editörlerin sunumu açarken kullandığı bir tercih kaydeder. Yorumları olan mevcut bir sunum için bu örnek mevcut ayarı yazdırır ve yorumları gizlenmiş bir kopya kaydeder. Ayrıca kopyanın slayt görünümünde açılması için [setLastView](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setLastView-int-) yöntemini [ViewType.SlideView](https://reference.aspose.com/slides/java/com.aspose.slides/viewtype/#SlideView) ile birlikte çağırır.

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

Yorumları gizlemek metinlerini, yazarlarını, konumlarını, yanıtlarını ve durumlarını korur. Yorumları kendiniz değiştirmek için [Sunum Yorumları](/slides/tr/java/presentation-comments/) bölümüne bakın. Dışa aktarma ayarları yorumların PDF, HTML, görüntüler, notlar ya da el ilanlarında görünüp görünmeyeceğini kontrol eder.

## **SSS**

**Sunumu yeniden açtığımda ızgara neden gizleniyor?**

Sunum ızgara aralığını depolar. Izgarayı görmek için editörde ızgara görünürlüğünü etkinleştirin.

**Çizim kılavuzlarını temizlemek ızgara aralığını değiştirir mi?**

Hayır. Bir kılavuz eklemek, taşımak veya temizlemek ızgara aralığını değiştirmez.

**Bir sunumun farklı bölümleri farklı görünüm ayarlarına sahip olabilir mi?**

Hayır. [Presentation.getViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--) bütün sunuma uygulanır.

**Farklı kullanıcılar için farklı görünüm ayarları kaydedebilir miyim?**

Dosya herkes için tek bir görünüm özelliği seti saklar. Bir editör ayrıca kullanıcının yerel tercihlerini uygulayabilir.

**Bir şablonda görünüm ayarlarını kaydedebilir miyim?**

Evet. Şablondan oluşturulan sunumlar, kaydedilmiş görünüm ayarlarını miras alır.