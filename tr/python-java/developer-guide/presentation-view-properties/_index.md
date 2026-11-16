---
title: Python üzerinden Java ile Sunum Görünüm Özelliklerini Getirme ve Güncelleme
linktitle: Görünüm Özellikleri
type: docs
weight: 80
url: /tr/python-java/presentation-view-properties/
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
- Python
- Java
- Aspose.Slides
description: "Java aracılığıyla Python için Aspose.Slides kullanarak PowerPoint sunumlarında normal görünüm düzenini, slayt ve not yakınlaştırmasını, ızgara aralığını ve yorum görünürlüğünü yapılandırın."
---
## **Giriş**

PowerPoint'in normal görünümünde, slayt küçük resimler veya bir taslak için yan panel ile altında bir not paneli arasında görünür. Aspose.Slides for Python via Java, sunumun kaydedilmiş düzenleme tercihlerini [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) aracılığıyla ortaya koyar. Bunlar panel düzeni, yakınlaştırma seviyeleri, ızgara aralığı ve yorum görünürlüğünü içerir.

## **NormalViewProperties Hakkında**

[getNormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNormalViewProperties) bağlantısını kullanarak [NormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/) sınıfına erişin. [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) taslakta slayt başlıklarının yanında simgelerin görünüp görünmeyeceğini kontrol eder. [setSnapVerticalSplitter](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) kullanıcı yan paneli daralttığında panelin küçültülmüş durumuna yapışmasını sağlar. [setPreferSingleView](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) tam pencerede tek bir panel gösterme tercihini gösterir.

[setVerticalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setVerticalBarState) yan panel ile slayt arasındaki bölücüyü kontrol eder. [setHorizontalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setHorizontalBarState) not panelinin üzerindeki bölücüyü kontrol eder. Her ikisi de `Minimized`, `Maximized` veya `Restored` değerlerinden birini kabul eden bir [SplitterBarStateType](https://reference.aspose.com/slides/python-java/aspose.slides/splitterbarstatetype/) alır.

## **NormalViewProperties Geri Yükleme Hakkında**

Bir bölücü geri yüklendiğinde, [getRestoredLeft](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) yan panelin kaydedilmiş boyutunu ve [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) üst slayt alanının kaydedilmiş boyutunu sağlar. İkisi de bir [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/) örneği döndürür. Bunun [setDimensionSize](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) yöntemi 0 ile 100 arasında bir yüzde alır ve [setAutoAdjust](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) pencere yeniden boyutlandırıldığında editörün boyutu ayarlayıp ayarlamadığını kontrol eder.

Bu örnek mevcut bir sunumu günceller. Yatay bölücüyü geri yükler, [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) tarafından döndürülen boyutu %80 olarak ayarlar ve otomatik ayarlama etkinleştirilir, ayrıca dikey bölücüyü maksimize eder. Ayrıca taslak görünümünde simgeleri göstermek için [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) çağrılır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation("demo.pptx")
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Varsayılan Yakınlaştırma Değerini Ayarla**

[getSlideViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getSlideViewProperties) ve [getNotesViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNotesViewProperties) editör için bağımsız yakınlaştırma ayarlarını saklar. Bu ayarlar slayt boyutlarını, slayt gösterisi oynatımını veya görüntü dışa aktarma çözünürlüğünü etkilemez.

Bu örnek mevcut bir sunumu açar ve slaytı düzenleme penceresine sığdırmak için [setVariableScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setVariableScale) çağırır. Not sayfası için otomatik ölçeklendirmeyi devre dışı bırakır ve sabit %80 yakınlaştırma ayarlamak için [setScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setScale) çağırır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    view_properties = presentation.getViewProperties()
    view_properties.getSlideViewProperties().setVariableScale(True)
    notes_view = view_properties.getNotesViewProperties()
    notes_view.setVariableScale(False)
    notes_view.setScale(80)

    presentation.save("zoom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Izgara Aralığını Ayarla**

[setGridSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setGridSpacing) sunum boyunca düzenleme ızgara çizgileri arasındaki mesafeyi ayarlar. İnç başına 72 puan olmak üzere pozitif bir değer alır. Bu örnek mevcut bir sunumdaki mevcut aralığı yazdırır ve aralığı 18 puana ayarlayarak çeyrek inçlik bir ızgara kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    grid_spacing = presentation.getViewProperties().getGridSpacing()
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.getViewProperties().setGridSpacing(18.0)

    presentation.save("grid-spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Izgara sabit bir aralıkta tekrar eder. [Drawing guides](/slides/tr/python-java/drawing-guides/) tek tek yatay veya dikey konumları işaretler. Her ikisi de düzenleme yardımcılarıdır ve yalnızca bu öğeleri gösteren editörlerde görünür. Slayt gösterileri ve PDF, görüntü veya SVG dışa aktarmaları bunları atlar.

## **Sunumu Açarken Yorumları Göster veya Gizle**

[setShowComments](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setShowComments) uyumlu editörlerin sunumu açarken kullandığı bir tercih saklar. Yorumları olan mevcut bir sunum için bu örnek mevcut ayarı yazdırır ve yorumları gizli bir kopya kaydeder. Ayrıca kopyanın slayt görünümünde açılması için [setLastView](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setLastView) ile [ViewType.SlideView](https://reference.aspose.com/slides/python-java/aspose.slides/viewtype/#SlideView) çağrılır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ViewType

presentation = Presentation("comments.pptx")
try:
    show_comments = presentation.getViewProperties().getShowComments()
    print(f"Current comment visibility: {show_comments}")

    presentation.getViewProperties().setShowComments(NullableBool.False_)
    presentation.getViewProperties().setLastView(ViewType.SlideView)
    
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Yorumları gizlemek metinlerini, yazarlarını, konumlarını, yanıtlarını ve durumlarını korur. Yorumları kendilerini değiştirmek için [Presentation Comments](/slides/tr/python-java/presentation-comments/) sayfasına bakın. Dışa aktarma ayarları yorumların PDF, HTML, görüntüler, notlar veya el ilanlarında görünüp görünmeyeceğini kontrol eder.

## **SSS**

**Sunumu yeniden açtığımda ızgara neden gizleniyor?**

Sunum ızgara aralığını saklar. Izgarayı görmek için editörde ızgara görünürlüğünü etkinleştirin.

**Çizim kılavuzlarını temizlemek ızgara aralığını değiştirir mi?**

Hayır. Bir kılavuz eklemek, taşımak veya temizlemek ızgara aralığını değiştirmez.

**Bir sunumun farklı bölümleri farklı görünüm ayarlarına sahip olabilir mi?**

Hayır. [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) tüm sunuma uygulanır.

**Farklı kullanıcılar için farklı görüş ayarlarını kaydedebilir miyim?**

Dosya herkes için tek bir görünüm özelliği seti saklar. Bir editör ayrıca kullanıcının yerel tercihlerini uygulayabilir.

**Bir şablonda görünüm ayarlarını kaydedebilir miyim?**

Evet. Şablondan oluşturulan sunumlar, kaydedilmiş görünüm ayarlarını devralır.