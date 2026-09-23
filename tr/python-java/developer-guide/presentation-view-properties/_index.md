---
title: Python üzerinden Java ile Sunum Görünüm Özelliklerini Getirme ve Güncelleme
linktitle: Görünüm Özellikleri
type: docs
weight: 80
url: /tr/python-java/presentation-view-properties/
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
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java görünüm özelliklerini keşfedin ve PPT, PPTX ve ODP slaytlarını özelleştirin—düzenleri, yakınlaştırma seviyelerini ve görüntü ayarlarını ayarlayın."
---
## **Giriş**

Normal görünüm üç içerik bölgesinden oluşur: slaytın kendisi, bir yan içerik bölgesi ve bir alt içerik bölgesi. Normal görünüm özellikleri bu içerik bölgelerinin konumlandırılmasını açıklar. Bu bilgi uygulamanın görünüm durumunu dosyaya kaydetmesini sağlar, böylece yeniden açıldığında görünüm sunum en son kaydedildiği zamanki aynı durumda olur.

Sunumun normal görünüm özelliklerine erişim sağlamak için [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/#getNormalViewProperties) yöntemi eklenmiştir.

[NormalViewProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/) ve [NormalViewRestoredProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewrestoredproperties/) sınıfları ve [SplitterBarStateType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/splitterbarstatetype/) sayımı eklenmiştir.

## **NormalViewProperties Hakkında**

Normal görünüm özelliklerini temsil eder.

[getShowOutlineIcons](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) ve [setShowOutlineIcons](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) yöntemleri, normal görünüm modunda herhangi bir içerik bölgesinde taslak içeriği görüntüleniyorsa uygulamanın simgeleri gösterip göstermeyeceğini belirtir.

[getSnapVerticalSplitter](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) ve [setSnapVerticalSplitter](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) yöntemleri, yan bölge yeterince küçük olduğunda dikey bölücünün küçültülmüş bir duruma kilitlenip kilitlenmeyeceğini belirler.

[getPreferSingleView](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) ve [setPreferSingleView](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) yöntemleri, kullanıcının standart üç içerik bölgesine sahip normal görünüm yerine tam pencere tek içerik bölgesi görmeyi tercih edip etmeyeceğini belirtir. Etkinleştirilirse, uygulama içerik bölgelerinden birini tüm pencere içinde görüntülemeyi seçebilir.

[getVerticalBarState](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) ve [getHorizontalBarState](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) yöntemleri, yatay veya dikey bölücü çubuğunun hangi durumda gösterileceğini belirtir. Yatay bölücü çubuğu slaytı slaytın altındaki içerik bölgesinden ayırır; dikey bölücü çubuğu slaytı yan içerik bölgesinden ayırır. Olası değerler şunlardır: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/tr/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/tr/python-java/aspose.slides/splitterbarstatetype/#Maximized) ve [SplitterBarStateType.Restored](https://reference.aspose.com/slides/tr/python-java/aspose.slides/splitterbarstatetype/#Restored).

[getRestoredLeft](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) ve [getRestoredTop](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#getRestoredTop) yöntemleri, [SplitterBarStateType.Restored](https://reference.aspose.com/slides/tr/python-java/aspose.slides/splitterbarstatetype/#Restored) değeri [getVerticalBarState](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) ve [getHorizontalBarState](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) yöntemlerine uygulandığında normal görünümün üst veya yan slayt bölgesinin boyutlandırılmasını belirtir.

## **NormalViewProperties Geri Yüklenmesi Hakkında**

Normal görünümde, bölge değişken bir geri yüklenmiş boyutta (ne küçültülmüş ne de büyütülmüş) olduğunda, slayt bölgesinin ([getRestoredTop](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#getRestoredTop) çocuğu olduğunda genişlik, [getRestoredLeft](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) çocuğu olduğunda yükseklik) boyutlandırılmasını belirtir.

[getDimensionSize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) yöntemi, slayt bölgesinin ([getRestoredTop](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#getRestoredTop) çocuğu olduğunda genişlik, [getRestoredLeft](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) çocuğu olduğunda yükseklik) boyutunu belirtir.

[getAutoAdjust](https://reference.aspose.com/slides/tr/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) yöntemi, pencere yeniden boyutlandırıldığında yan içerik bölgesinin yeni boyuta göre telafi edilip edilmemesi gerektiğini belirtir.

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

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java, sunum açıldığında zaten uygulanmış olacak şekilde varsayılan yakınlaştırma değerini ayarlamayı destekler. Bu, bir sunumun [ViewProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/) ayarlanarak yapılabilir. [getSlideViewProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/#getSlideViewProperties) ve [getNotesViewProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/#getNotesViewProperties) programatik olarak yapılandırılabilir. Bu konuda, Aspose.Slides içinde bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) için [View Properties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/) nasıl ayarlanacağını bir örnekle göreceğiz.
{{% /alert %}}

Görünüm özelliklerini ayarlamak için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının örneğini oluşturun.
2. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) için [View Properties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/) ayarlayın.
3. Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak yazın.

Aşağıdaki örnekte, slayt görünümü ve not görünümü için yakınlaştırma değerini ayarlıyoruz.

```python
import jpage
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Sunumun görünüm özelliklerini ayarla.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # Slayt görünümü için yakınlaştırma yüzdesi.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # Not görünümü için yakınlaştırma yüzdesi.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Izgara Aralığını Ayarlama**

Sunum genelindeki görünüm ayarlarına erişmek için [Presentation.getViewProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getViewProperties) kullanın. [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/#getGridSpacing) ve [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/#setGridSpacing) yöntemleri temel düzenleme ızgarasının aralığını okur veya değiştirir. Bu ayar tek bir slayta değil, tüm sunuma uygulanır. Izgara aralığı puan cinsinden belirtilir; 72 puan bir inç eder. API belgelerinde belirtildiği gibi pozitif bir değer kullanın.

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

Izgara, [drawing guides](/slides/tr/python-java/drawing-guides/) öğesinden farklıdır. Izgara aralığı düzenli bir aralığı kontrol eder, çizim kılavuzları ise ayrı ayrı konumlandırılmış yatay veya dikey hizalama çizgileridir. Çizim kılavuzlarını eklemek, taşımak veya temizlemek ızgara aralığını değiştirmez.

Izgara ve çizim kılavuzları her ikisi de düzenleme yardımcılarıdır. PDF, görüntüler, SVG veya slayt gösterisinde slayt içeriği olarak işlenmezler. Izgara aralığının saklanması, bir düzenleyicinin ızgarayı göstereceğini garanti etmez; görünürlüğü ayrıca görüntüleyicinin veya düzenleyicinin tercihine bağlıdır.

## **Sunum Açılırken Yorumları Gösterme veya Gizleme**

Sunum genelindeki görünüm ayarlarına erişmek için [Presentation.getViewProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getViewProperties) kullanın. PowerPoint veya başka bir uyumlu düzenleyicide sunum açıldığında yorumların gösterilip gösterilmeyeceğine ilişkin saklanan tercihi okumak veya değiştirmek için [ViewProperties.getShowComments](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/#getShowComments) ve [ViewProperties.setShowComments](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/#setShowComments) kullanın.

Bu ayar yalnızca saklanan görünüm tercihini kontrol eder. Yorumları eklemez, kaldırmaz, düzenlemez veya çözüme kavuşturmaz. Yorumların gizlenmesi, içeriklerini, yazarlarını, konumlarını, yanıtlarını ve durumlarını korur. Yorumları doğrudan değiştiren işlemler için [Presentation Comments](/slides/tr/python-java/presentation-comments/) bölümüne bakın.

Aşağıdaki örnek, yorumlar içeren mevcut bir `comments.pptx` dosyasına ihtiyaç duyar. Mevcut görünürlük ayarını yazdırır, yorumların gizlenmesini talep eder ve yorumları kaldırmadan yeni bir PPTX kaydeder. Ayrıca, yorum görünürlüğüyle birlikte ilk düzenleme görünümünü yapılandırmak için [ViewProperties.setLastView](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/#setLastView) ve [ViewType.SlideView](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewtype/#SlideView) kullanır.

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

Bu ayar, yorumların PDF, HTML, görüntü, not veya el kitabı dışa aktarımlarına dahil edilip edilmeyeceğini belirlemez. İlgili dışa aktarma seçeneklerini ayrı ayrı yapılandırın.

## **SSS**

**Sunumu yeniden açtığımda ızgara neden görünmüyor?**

Dosya ızgara aralığını saklar, ancak editör ızgaranın gösterilip gösterilmeyeceğini kontrol eder. Editörün ızgara görünürlük ayarlarını kontrol edin.

**Çizim kılavuzlarını temizlemek ızgara aralığını değiştirir mi?**

Hayır. Çizim kılavuzları ve ızgara aralığı bağımsız ayarlardır. Kılavuzları temizlemek, saklanan ızgara aralığını değiştirmez.

**Bir sunumun farklı bölümleri için farklı görünüm ayarları belirleyebilir miyim?**

[View settings](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getViewProperties) sunum seviyesinde ([Normal View]/[Slide View]) tanımlanır, bölüme göre değil; bu nedenle bir tek parametre seti belgenin tamamına uygulanır.

**Farklı kullanıcılar için farklı görünüm durumları önceden tanımlayabilir miyim?**

Hayır. Ayarlar dosyada saklanır ve paylaşılır. Görüntüleyici uygulamalar kullanıcı tercihlerine saygı gösterebilir, ancak dosya tek bir görünüm özelliği seti içerir.

**Yeni sunumların aynı şekilde açılması için önceden tanımlı View Properties içeren bir şablon hazırlayabilir miyim?**

Evet. [view properties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getViewProperties) sunum seviyesinde saklandığından, bunları bir şablona gömebilir ve aynı başlangıç görünüm yapılandırmasıyla yeni belgeler oluşturabilirsiniz.