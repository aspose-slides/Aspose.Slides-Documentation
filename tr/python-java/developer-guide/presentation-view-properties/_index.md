---
title: "Python aracılığıyla Java'da Sunum Görünüm Özelliklerini Alın ve Güncelleyin"
linktitle: "Görünüm Özellikleri"
type: docs
weight: 80
url: /tr/python-java/presentation-view-properties/
keywords:
- görünüm özellikleri
- normal görünüm
- anahat içeriği
- anahat simgeleri
- dikey ayırıcı çubuğu yakala
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
description: "Aspose.Slides for Python via Java görünüm özelliklerini keşfedin; PPT, PPTX ve ODP slaytlarını özelleştirin—düzenleri, yakınlaştırma seviyelerini ve görüntü ayarlarını ayarlayın."
---
## **Giriş**

Normal görünüm üç içerik bölgesinden oluşur: slayt kendisi, bir yan içerik bölgesi ve bir alt içerik bölgesi. Normal görünüm özellikleri bu içerik bölgelerinin konumlandırılmasını açıklar. Bu bilgi, uygulamanın görünüm durumunu dosyaya kaydetmesini sağlar; böylece yeniden açıldığında görünüm, sunum en son kaydedildiği sıradaki aynı durumda olur.

Sunumun normal görünüm özelliklerine erişim sağlamak için [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/#getNormalViewProperties) yöntemi eklenmiştir.

[NormalViewProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/) ve [NormalViewRestoredProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewrestoredproperties/) sınıfları ve [SplitterBarStateType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/splitterbarstatetype/) enum değeri eklenmiştir.

## **NormalViewProperties Hakkında**

Normal görünüm özelliklerini temsil eder.

Normal görünüm modundaki herhangi bir içerik bölgesinde anahat içeriği görüntüleniyorsa, uygulamanın simgeleri gösterip göstermeyeceğini [getShowOutlineIcons](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) ve [setShowOutlineIcons](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) yöntemleri belirler.

Yöntemler [getSnapVerticalSplitter](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) ve [setSnapVerticalSplitter](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) yan bölge yeterince küçük olduğunda dikey ayırıcı çubuğun küçültülmüş bir duruma yapışıp yapışmayacağını belirler.

Yöntemler [getPreferSingleView](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) ve [setPreferSingleView](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) kullanıcının üç içerik bölgesi olan standart normal görünüme göre tam pencere tek içerik bölgesi görmeyi tercih edip etmediğini belirler. Etkinleştirilirse, uygulama içerik bölgelerinden birini tüm pencerede görüntümeyi seçebilir.

Yöntemler [getVerticalBarState](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) ve [getHorizontalBarState](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) yatay veya dikey ayırıcı çubuğun hangi durumda gösterileceğini belirler. Yatay ayırıcı çubuk slaytı slaytın altında bulunan içerik bölgesinden ayırır; dikey ayırıcı çubuk slaytı yan içerik bölgesinden ayırır. Olası değerler: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/tr/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/tr/python-java/aspose.slides/splitterbarstatetype/#Maximized) ve [SplitterBarStateType.Restored](https://reference.aspose.com/slides/tr/python-java/aspose.slides/splitterbarstatetype/#Restored).

Yöntemler [getRestoredLeft](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) ve [getRestoredTop](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#getRestoredTop) normal görünümdeki yan veya üst slayt bölgesinin boyutlandırmasını, sırasıyla [SplitterBarStateType.Restored](https://reference.aspose.com/slides/tr/python-java/aspose.slides/splitterbarstatetype/#Restored) değeri [getVerticalBarState](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) ve [getHorizontalBarState](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) üzerine uygulandığında belirtir.

## **NormalViewProperties Yeniden Yükleme Hakkında**

Normal görünümde, bölge değişken bir yeniden yüklenmiş boyuta (ne küçültülmüş ne de büyütülmüş) sahip olduğunda, slayt bölgesinin ([getRestoredTop](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#getRestoredTop) çocuğu olduğunda genişlik, [getRestoredLeft](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) çocuğu olduğunda yükseklik) boyutlandırmasını belirtir.

Yöntem [getDimensionSize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) slayt bölgesinin ( [getRestoredTop](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#getRestoredTop) çocuğu olduğunda genişlik, [getRestoredLeft](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) çocuğu olduğunda yükseklik) boyutunu belirtir.

Yöntem [getAutoAdjust](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) yan içerik bölgesinin boyutunun, uygulama içinde görünümü içeren pencereyi yeniden boyutlandırırken yeni boyuta göre telafi edip etmeyeceğini belirler.

Aşağıdaki örnek, bir sunum için [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/#getNormalViewProperties) nasıl erişileceğini gösterir.

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

{{% alert color="info" title="Note" %}}

Aspose.Slides for Python via Java, sunum açıldığında zaten uygulanacak şekilde varsayılan yakınlaştırma değerini ayarlamayı destekler. Bu, bir sunumun [ViewProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/) ayarlanarak yapılabilir. [getSlideViewProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/#getSlideViewProperties) ve [getNotesViewProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/#getNotesViewProperties) programlı olarak yapılandırılabilir. Bu konuda, Aspose.Slides içinde [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) nin [View Properties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/) nasıl ayarlanacağını bir örnekle göreceğiz.

{{% /alert %}}

Görünüm özelliklerini ayarlamak için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) nin [View Properties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/) ayarlayın.
3. Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak yazın.

Aşağıdaki örnekte, hem slayt görünümü hem de notlar görünümü için yakınlaştırma değerini ayarlıyoruz.

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

## **Izgara Aralığını Ayarlama**

[Presentation.getViewProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getViewProperties) kullanarak sunum genelindeki görünüm ayarlarına erişin. [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/#getGridSpacing) ve [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/#setGridSpacing) yöntemleri temel düzenleme ızgarasının aralığını okur veya değiştirir. Bu ayar tüm sunuma uygulanır, tek bir slayta değil. Izgara aralığı nokta cinsinden belirtilir; 72 nokta bir inçtir. API belgelerinde belirtildiği gibi pozitif bir değer kullanın.

Aşağıdaki örnek, mevcut bir `demo.pptx` dosyasını açar, mevcut ızgara aralığını yazdırır, çeyrek inçlik bir aralık ayarlar ve sonucu kaydeder.

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

Izgara, [çizim kılavuzlarından](/slides/tr/python-java/drawing-guides/) farklıdır. Izgara aralığı düzenli bir aralığı kontrol ederken, çizim kılavuzları bireysel olarak konumlandırılmış yatay veya dikey hizalama çizgileridir. Çizim kılavuzlarını eklemek, taşımak veya temizlemek ızgara aralığını değiştirmez.

Izgaralar ve çizim kılavuzları her ikisi de düzenleme yardımcılarıdır. PDF, görüntüler, SVG veya slayt gösterisinde slayt içeriği olarak işlenmezler. Izgara aralığının dosyada saklanması, bir düzenleyicinin ızgarayı göstereceğini garanti etmez; görünürlüğü ayrıca görüntüleyicinin veya düzenleyicinin tercihine bağlıdır.

## **SSS**

**Sunumu yeniden açtığımda ızgara neden görünmüyor?**

Dosya ızgara aralığını saklar, ancak düzenleyici ızgaranın gösterilip gösterilmeyeceğini kontrol eder. Düzenleyicinin ızgara görünürlük ayarlarını kontrol edin.

**Çizim kılavuzlarını temizlemek ızgara aralığını değiştirir mi?**

Hayır. Çizim kılavuzları ve ızgara aralığı bağımsız ayarlardır. Kılavuzları temizlemek saklanan ızgara aralığını değiştirmez.

**Sunumun farklı bölümleri için farklı görünüm ayarları belirleyebilir miyim?**

[View settings](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getViewProperties) sunum seviyesinde ([Normal View](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/#getSlideViewProperties)) tanımlanır, bölüm bazında değil; bu nedenle bir tek parametre kümesi belgenin tamamına uygulanır ve açıldığında geçerli olur.

**Farklı kullanıcılar için farklı görünüm durumlarını önceden tanımlayabilir miyim?**

Hayır. Ayarlar dosyada saklanır ve paylaşılır. Görüntüleyici uygulamalar kullanıcı tercihlerine saygı gösterebilir, ancak dosya kendisi yalnızca bir görünüm özelliği seti içerir.

**Yeni sunumların aynı şekilde açılması için önceden tanımlı View Properties içeren bir şablon hazırlayabilir miyim?**

Evet. [view properties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getViewProperties) sunum seviyesinde saklandığı için, bunları bir şablona gömebilir ve yeni belgeleri aynı başlangıç görünüm yapılandırmasıyla oluşturabilirsiniz.