---
title: Python üzerinden Java ile Sunum Görünüm Özelliklerini Getirme ve Güncelleme
linktitle: Görünüm Özellikleri
type: docs
weight: 80
url: /tr/python-java/presentation-view-properties/
keywords:
- görünüm özellikleri
- normal görünüm
- anahat içeriği
- anahat simgeleri
- dikey bölücüyü yakala
- tek görünüm
- çubuk durumu
- boyut ölçüsü
- otomatik ayarlama
- varsayılan yakınlaştırma
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java görünüm özelliklerini keşfedin, PPT, PPTX ve ODP slaytlarını özelleştirin—yerleşimleri, yakınlaştırma seviyelerini ve görüntü ayarlarını ayarlayın."
---
## **Giriş**

Normal görünüm üç içerik bölgesinden oluşur: slayt kendisi, yan içerik bölgesi ve alt içerik bölgesi. Normal görünüm özellikleri bu içerik bölgelerinin konumlandırılmasını tanımlar. Bu bilgi, uygulamanın görünüm durumunu dosyaya kaydetmesini sağlar; böylece yeniden açıldığında görünüm, sunum son kaydedildiği zamanki durumuyla aynı olur.

Sunumun normal görünüm özelliklerine erişim sağlamak için [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/#getNormalViewProperties) yöntemi eklenmiştir.

[NormalViewProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/) ve [NormalViewRestoredProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewrestoredproperties/) sınıfları ve [SplitterBarStateType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/splitterbarstatetype/) enum'ı eklenmiştir.

## **NormalViewProperties Hakkında**

Normal görünüm özelliklerini temsil eder.

[getShowOutlineIcons](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) ve [setShowOutlineIcons](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) yöntemleri, normal görünüm modundaki içerik bölgelerinden birinde anahat içeriği gösterildiğinde uygulamanın simgeleri gösterip göstermeyeceğini belirtir.

[getSnapVerticalSplitter](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) ve [setSnapVerticalSplitter](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) yöntemleri, yan bölge yeterince küçük olduğunda dikey bölücünün küçültülmüş duruma kilitlenip kilitlenmeyeceğini belirler.

[getPreferSingleView](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) ve [setPreferSingleView](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) yöntemleri, kullanıcının üç içerik bölgesi bulunan standart normal görünüm yerine tam pencere tek içerik bölgesi görmeyi tercih edip etmediğini belirtir. Etkinleştirildiğinde, uygulama içerik bölgelerinden birini tüm pencere içinde gösterebilir.

[getVerticalBarState](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) ve [getHorizontalBarState](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) yöntemleri, yatay veya dikey bölünme çubuğunun hangi durumda gösterileceğini belirler. Yatay bölme çubuğu slaytı slaytın altındaki içerik bölgesinden ayırır; dikey bölme çubuğu slaytı yan içerik bölgesinden ayırır. Olabilecek değerler: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/tr/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/tr/python-java/aspose.slides/splitterbarstatetype/#Maximized) ve [SplitterBarStateType.Restored](https://reference.aspose.com/slides/tr/python-java/aspose.slides/splitterbarstatetype/#Restored).

[getRestoredLeft](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) ve [getRestoredTop](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#getRestoredTop) yöntemleri, sırasıyla [SplitterBarStateType.Restored] değeri [getVerticalBarState] ve [getHorizontalBarState] yöntemlerine uygulandığında normal görünümün üst veya yan slayt bölgesinin boyutlandırılmasını belirtir.

## **NormalViewProperties Geri Yüklenmesi Hakkında**

Normal görünümde bölgenin değişken geri yüklenmiş bir boyutta (küçültülmüş ya da büyütülmüş olmaması) olduğunda slayt bölgesinin ([getRestoredTop] çocuğu ise genişlik, [getRestoredLeft] çocuğu ise yükseklik) boyutlandırılmasını belirtir.

[getDimensionSize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) yöntemi, slayt bölgesinin ([getRestoredTop] çocuğu ise genişlik, [getRestoredLeft] çocuğu ise yükseklik) boyutunu belirtir.

[getAutoAdjust](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) yöntemi, pencere içinde görünümü yeniden boyutlandırırken yan içerik bölgesinin yeni boyuta uyum sağlayıp sağlamayacağını belirtir.

Aşağıdaki örnek, bir sunum için [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/#getNormalViewProperties) yöntemine nasıl erişileceğini gösterir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation()
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    # Sunumun görünüm özelliklerini geri yükle.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Varsayılan Yakınlaştırma Değerini Ayarlama**

{{% alert color="info" title="Not" %}}
Aspose.Slides for Python via Java, sunum açıldığında zaten uygulanacak şekilde varsayılan yakınlaştırma değerinin ayarlanmasını destekler. Bu, bir sunumun [ViewProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/) ayarlanarak yapılabilir. [getSlideViewProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/#getSlideViewProperties) ve [getNotesViewProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/#getNotesViewProperties) programmatically yapılandırılabilir. Bu konuda, bir örnekle [Aspose.Slides](/slides/tr/) içinde [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) öğesinin [Görünüm Özellikleri](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/) nasıl ayarlanacağını göreceğiz.
{{% /alert %}}

Görünüm özelliklerini ayarlamak için aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) için [Görünüm Özellikleri](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/) ayarlayın.
1. Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak yazın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Sunumun görünüm özelliklerini ayarla.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # Slayt görünümü için yakınlaştırma yüzdesi.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # Notlar görünümü için yakınlaştırma yüzdesi.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**Farklı bölüm için farklı görünüm ayarları belirleyebilir miyim?**

[Görünüm ayarları](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getViewProperties) sunum seviyesinde ([Normal Görünüm](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slayt Görünümü](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/#getSlideViewProperties)) tanımlanır, bölüm bazında değil; bu nedenle belge açıldığında tek bir parametre seti tüm belgeye uygulanır.

**Farklı kullanıcılar için farklı görünüm durumlarını önceden tanımlayabilir miyim?**

Hayır. Ayarlar dosyada saklanır ve paylaşıldır. Görüntüleyici uygulamalar kullanıcı tercihlerine saygı gösterebilir, ancak dosya kendisi yalnızca bir görünüm özelliği kümesi içerir.

**Önceden tanımlı Görünüm Özellikleriyle bir şablon hazırlayarak yeni sunumların aynı şekilde açılmasını sağlayabilir miyim?**

Evet. [Görünüm Özellikleri](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getViewProperties) sunum seviyesinde depolandığı için, bunları bir şablona gömebilir ve aynı başlangıç görünüm yapılandırmasıyla yeni belgeler oluşturabilirsiniz.