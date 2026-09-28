---
title: Python üzerinden Java ile Sunum Slide Master'larını Yönet
linktitle: Slayt Master
type: docs
weight: 70
url: /tr/python-java/slide-master/
keywords:
- slayt master
- master slayt
- PPT master slayt
- birden fazla master slayt
- master slaytları karşılaştır
- arka plan
- yer tutucu
- master slaytı kopyala
- master slaytı çoğalt
- master slaytı yinela
- kullanılmayan master slayt
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java'da slayt master'larını yönetin: PowerPoint ve OpenDocument sunumlarında master slaytları erişin, düzenleyin, kopyalayın, karşılaştırın ve kaldırın."
---
## **Genel Bakış**

Bir **slide master**, bir grup slayt için ortak tasarım ayarlarını tanımlar. Ortak şekiller, logolar, arka planlar, metin stilleri, tema ayarları ve altbilgi ayarları içerebilir. PowerPoint’te slide master’ı düzenlemek, aynı biçimlendirmeyi her slaytta tekrar etmeksizin sunumu tutarlı tutmanın yaygın yoludur.

Aspose.Slides for Python via Java aynı modeli destekler. Bir sunum bir veya daha fazla master slayt içerebilir ve her master slayt birkaç layout slaytı barındırabilir. Normal slaytlar doğrudan bir master slayta başvurmaz. Bunun yerine, normal bir slayt bir layout slaytını kullanır ve bu layout slayt bir master slayta aittir.

Hiyerarşi şudur:

1. **Slide master** – ortak tasarımı ve temayı tanımlar.
1. **Layout slayt** – yer tutucuların ve layout‑seviye biçimlendirmelerin belirli bir düzenini tanımlar.
1. **Normal slayt** – gerçek sunum içeriğini içerir ve bir layout slaytını kullanır.

![master slaytların, layout slaytların ve normal slaytların hiyerarşisi](slide-master_2.jpg)

Aspose.Slides’ta bir slide master, [MasterSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslide/) sınıfı ile temsil edilir. Bir sunumdaki tüm master slaytlar, [Presentation.getMasters](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getMasters) koleksiyonu aracılığıyla elde edilir; bu koleksiyon ise [MasterSlideCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslidecollection/) ile temsil edilir.

{{% alert color="info" title="Kalıtım" %}}
Aynı özellik birden fazla seviyede tanımlandığında, daha spesifik seviye önceliklidir. Örneğin, bir master slayt ve bir layout slayt her ikisi de bir arka plan tanımlıyorsa, o layout’a dayalı slaytlar layout arka planını kullanır. Layout slaytlarıyla ilgili daha fazla bilgi için [Slide Layoutlarını Uygulama veya Değiştirme](/slides/tr/python-java/slide-layout/) bölümüne bakın.
{{% /alert %}}

## **Slide Master’lara Erişim**

PowerPoint’te **View** > **Slide Master** menüsünden Slide Master görünümünü açabilirsiniz.

![PowerPoint Görünüm sekmesindeki Slide Master komutu](slide-master_3.jpg)

Aspose.Slides’ta master slaytlara erişmek için [Presentation.getMasters](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getMasters) koleksiyonunu kullanın:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    master_slide_count = presentation.getMasters().size()
    first_master_layout_slide_count = first_master_slide.getLayoutSlides().size()

    print(f"Master slides: {master_slide_count}")
    print(f"Layouts in the first master: {first_master_layout_slide_count}")
finally:
    presentation.dispose()
```

Ayrıca, bir normal slaytın kullandığı layout aracılığıyla o slaytın master slaytını alabilirsiniz:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    layout_slide = slide.getLayoutSlide()
    master_slide = layout_slide.getMasterSlide()
    master_slide_name = master_slide.getName()

    print(master_slide_name)
finally:
    presentation.dispose()
```

## **Bir Slide Master Ne İçerir**

Bir master slayt, slayt benzeri bir nesnedir. [BaseSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslide/) sınıfından türediği için normal ve layout slaytlarda kullanılan birçok slayt özelliğine sahiptir. Master‑özel üyeler [MasterSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslide/) API sayfasında listelenmiştir.

Yaygın kullanılan master slayt üyeleri şunlardır:

| Üye | Açıklama |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslide/#getBackground) | Master‑seviye slayt arka planını ayarlar. |
| [getShapes](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslide/#getShapes) | Logolar, resim çerçeveleri ve ortak metin gibi master’da bulunan şekilleri depolar. |
| [getLayoutSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslide/#getLayoutSlides) | Master’a ait layout slaytları depolar. |
| [getThemeManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslide/#getThemeManager) | Master tema API’lerine erişim sağlar. |
| [getHeaderFooterManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | Master ve alt layoutları için başlık, altbilgi, tarih ve slayt numaralarını kontrol eder. |
| [getDependingSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslide/#getDependingSlides) | Layoutları aracılığıyla master’a bağımlı normal slaytları döndürür. |

## **Slide Master’a Görüntü Ekleme**

Bir master slayta bir görüntü eklendiğinde, o master’ın layoutlarını kullanan tüm slaytlarda görüntülenir. Bu, logolar, filigranlar, dekoratif bantlar ve diğer tekrarlanan görsel öğeler için kullanışlıdır.

Aşağıdaki örnek, ilk master slayta bir logo ekler:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    logo = Images.fromFile("logo.png")
    try:
        logo_image = presentation.getImages().addImage(logo)
        master_slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 80, 80, logo_image)
    finally:
        logo.dispose()

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Resim çerçeveleri hakkında daha fazla bilgi için [Picture Frame](/slides/tr/python-java/picture-frame/) bölümüne bakın.

## **Master Grafiklerinin Görünürlüğünü Kontrol Etme**

Miras alınan master grafiklerini (ör. logolar veya dekoratif şekiller) silmeden gizlemek için [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslide/#setShowMasterShapes) kullanılabilir. Bu grafikleri gizlemesi gereken slaytta [Slide.setShowMasterShapes](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#setShowMasterShapes) metoduna `False` geçirilirken, görüntülenmesi gereken slaytlarda `True` bırakılmalıdır.

Aşağıdaki bağımsız örnek, bir master’da mavi bir dekoratif bant oluşturur ve aynı boş layout’u kullanan iki slaytta bu bandı gösterir/gizler. İlk slaytta bant görünür, ikinci slaytta gizlidir. Girdi sunumu veya resim gerekmez.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    layout_slide.setShowMasterShapes(True)

    slide_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    band = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slide_height)
    band_color = Color(70, 130, 180)
    band.getFillFormat().setFillType(FillType.Solid)
    band.getFillFormat().getSolidFillColor().setColor(band_color)
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    visible_slide = presentation.getSlides().get_Item(0)
    visible_slide.setLayoutSlide(layout_slide)
    visible_slide.getShapes().clear()

    hidden_slide = presentation.getSlides().addEmptySlide(layout_slide)

    visible_slide.setShowMasterShapes(True)
    hidden_slide.setShowMasterShapes(False)

    presentation.save("master-graphics.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Örnek, yeni bir sunumla birlikte sağlanan **Blank** layout’unu kullanır ve ilk slayttaki yer tutucuları kaldırır.

### **Ayarın Kapsamını Seçme**

Normal bir slayt, masterını [Slide.getLayoutSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#getLayoutSlide) ve [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutslide/#getMasterSlide) aracılığıyla kullanır. Özelliği bireysel bir slayta uygulamak yalnızca o slaytı etkiler. [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutslide/#setShowMasterShapes) metoduna `False` geçirilmesi, aynı ortak layout’u kullanan diğer slaytlarda master grafiklerini gizler; kendi ayarları `True` olsa bile. Sadece bir slaytta grafikleri gizlemek için slayt özelliğini değiştirin ve ortak layout’u olduğu gibi bırakın.

Bu ayar master slaytın kendisinde bir görünürlük kontrolü olarak desteklenmez. Bir master’da [getShowMasterShapes](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslide/#getShowMasterShapes) her zaman `False` döndürür ve [setShowMasterShapes](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslide/#setShowMasterShapes) metoduna `True` geçirilmesi bir istisna fırlatır. Bunu normal bir slayt ya da layout üzerine uygulayın.

### **Grafikleri Arka Plandan Ayırma**

| İşlem | Etki |
| --- | --- |
| Master grafiklerini gizle | Miras alınan master şekillerinin silinmeden veya slaytın kendi şekilleri değiştirilmeden görünürlüğünü kontrol eder. |
| Slayt arka plan doldurmasını değiştir | Arka plan rengini, geçişini veya resmini değiştirir. Master grafikleri ayrı şekiller olduğundan bu arka planın üzerinde görünmeye devam edebilir. [Presentation Background](/slides/tr/python-java/presentation-background/) bölümüne bakın. |
| Master’dan bir şekli sil | Paylaşılan kaynak şekli kaldırır; böylece o master’ı kullanan hiçbir slayt artık o şekle erişemez. |

## **Yer Tutucularla Çalışma**

Yer tutucular genellikle layout slaytlarda tanımlanır. Master slayt, bu layoutların miras aldığı ortak stil ve temayı sağlar; her layout ise hangi yer tutucuların mevcut olduğunu ve nerede konumlandırılacağını belirler.

PowerPoint’te yer tutucu komutları Slide Master görünümünde bulunur.

![PowerPoint Slide Master görünümünde Insert Placeholder komutu](slide-master_5.png)

Aspose.Slides ile yeni yer tutucular eklemek için master’a ait layout slaytıyla çalışın:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    blank_layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout_slide is None:
        blank_layout_slide = master_slide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank")

    blank_layout_slide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80)

    presentation.getSlides().addEmptySlide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ayrıca, bir master slaytta zaten var olan yer tutucu şekillerini biçimlendirebilirsiniz. Aşağıdaki örnek, başlık yer tutucusunu bulur ve doğrusal bir geçiş doldurması uygular:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, GradientShape, PlaceholderType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    title_placeholder = None

    for shape in master_slide.getShapes():
        if isinstance(shape, AutoShape):
            if shape.getPlaceholder() is not None and shape.getPlaceholder().getType() == PlaceholderType.Title:
                title_placeholder = shape
                break

    if title_placeholder is not None:
        red_gradient_color = Color(255, 0, 0)
        purple_gradient_color = Color(128, 0, 128)

        title_placeholder.getFillFormat().setFillType(FillType.Gradient)
        title_placeholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(0.0), red_gradient_color)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(1.0), purple_gradient_color)

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Normal slaytlara miras geçen biçimlendirilmiş başlık yer tutucusu](slide-master_8.png)

Daha fazla yer tutucu ve metin biçimlendirme seçeneği için [Placeholder’da İstemdeki Metni Ayarlama](/slides/tr/python-java/manage-placeholder/) ve [Metin Biçimlendirme](/slides/tr/python-java/text-formatting/) bölümlerine bakın.

## **Slide Master Arka Planını Değiştirme**

Bir master arka planı, üzerine yazılmadıkça layoutlar ve slaytlar tarafından miras alınır. Aşağıdaki örnek, ilk master slayt için katı bir arka plan rengi ayarlar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    master_background_color = Color.GREEN

    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(master_background_color)

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

İlgili konular için [Presentation Background](/slides/tr/python-java/presentation-background/) ve [Presentation Theme](/slides/tr/python-java/presentation-theme/) bölümlerine göz atın.

## **Bir Slide Master’ı Başka Bir Sunuma Kopyalama**

[MasterSlideCollection.addClone](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslidecollection/#addClone) metodunu kullanarak bir master slaytı başka bir sunuma kopyalayabilirsiniz. Kopyalanan master, hedef sunumdaki layoutlar ve slaytlar tarafından kullanılabilir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source_presentation = Presentation("source.pptx")
destination_presentation = Presentation("destination.pptx")
try:
    source_master_slide = source_presentation.getMasters().get_Item(0)
    cloned_master_slide = destination_presentation.getMasters().addClone(source_master_slide)

    destination_presentation.save("destination-with-master.pptx", SaveFormat.Pptx)
finally:
    source_presentation.dispose()
    destination_presentation.dispose()
```

Normal slaytları ve onların masterlarını birlikte kopyalamanız gerekirse, [Clone Slides](/slides/tr/python-java/clone-slides/) bölümüne bakın.

## **Birden Çok Slide Master Ekleme**

Bir sunum birden fazla master slayt içerebilir. Bu, farklı bölümlerin farklı marka, sayfa yapısı veya tema ayarları gerektirdiği durumlarda faydalıdır.

![PowerPoint’te master slayt ekleme ve yönetme komutları](slide-master_9.jpg)

Aşağıdaki örnek, varsayılan master’ı klonlar, klona farklı bir arka plan verir, bu klon master altında bir layout oluşturur ve o layout’a dayalı yeni bir slayt ekler:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    section_master_slide = presentation.getMasters().addClone(default_master_slide)
    section_master_background_color = Color.LIGHT_GRAY

    section_master_slide.getBackground().setType(BackgroundType.OwnBackground)
    section_master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    section_master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(section_master_background_color)

    source_blank_layout = default_master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    if source_blank_layout is None:
        source_blank_layout = default_master_slide.getLayoutSlides().get_Item(0)

    section_blank_layout = section_master_slide.getLayoutSlides().addClone(source_blank_layout)

    presentation.getSlides().addEmptySlide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Slide Master’ları Karşılaştırma**

Master slaytlar, [BaseSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslide/) sınıfından miras alınan [equals](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslide/#equals) yöntemi ile karşılaştırılabilir. Karşılaştırma, şekiller, metin, biçimlendirme, animasyonlar ve diğer slayt ayarları gibi yapı ve statik içeriği kontrol eder. Slayt kimlikleri gibi benzersiz tanımlayıcılar veya mevcut tarih gibi dinamik yer tutucu değerleri karşılaştırılmaz.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

first_presentation = Presentation("first.pptx")
second_presentation = Presentation("second.pptx")
try:
    first_presentation_master_count = first_presentation.getMasters().size()
    second_presentation_master_count = second_presentation.getMasters().size()

    for first_master_index in range(first_presentation_master_count):
        for second_master_index in range(second_presentation_master_count):
            first_master_slide = first_presentation.getMasters().get_Item(first_master_index)
            second_master_slide = second_presentation.getMasters().get_Item(second_master_index)
            are_master_slides_equal = first_master_slide.equals(second_master_slide)

            if are_master_slides_equal:
                print(f"first.pptx master #{first_master_index} equals second.pptx master #{second_master_index}")
finally:
    first_presentation.dispose()
    second_presentation.dispose()
```

Daha fazla bilgi için [Presentation Slaytlarını Karşılaştırma](/slides/tr/python-java/compare-slides/) bölümüne bakın.

## **Slide Master Görünümünü Varsayılan Görünüm Olarak Ayarlama**

[ViewProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/) sınıfındaki [setLastView](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/#setLastView) metodunu kullanarak PowerPoint’in ilk açtığında hangi görünümde olacağını kontrol edebilirsiniz. Aşağıdaki örnek sunumu Slide Master görünümünde açar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation("presentation.pptx")
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Daha fazla görüntü ayarı için [Save Presentation](/slides/tr/python-java/save-presentation/) bölümüne bakın.

## **Kullanılmayan Master Slaytları Kaldırma**

Bazen bir sunumda, hiç normal slayt tarafından kullanılmayan master slaytlar bulunur. Kullanılmayan master’ları kaldırmak dosya boyutunu azaltabilir ve şablon bakımını basitleştirebilir.

Kullanılmayan master’ları, [Presentation.getMasters](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getMasters) koleksiyonundan kaldırmak için [removeUnused](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslidecollection/#removeUnused) metodunu kullanın:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getMasters().removeUnused(True)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ayrıca düşük‑kodlu [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/compress/#removeUnusedMasterSlides) metodunu da kullanabilirsiniz:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    Compress.removeUnusedMasterSlides(presentation)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**Slide master ile layout slayt arasındaki fark nedir?**

Slide master, tema, arka plan, ortak şekiller ve metin stilleri gibi ortak tasarım ayarlarını tanımlar. Layout slayt ise bir master slayta aittir ve yer tutucuların belirli bir düzenini tanımlar. Normal bir slayt bir layout slayt kullanır, dolayısıyla hem layout hem de master’dan miras alır.

**Bir sunum birden fazla slide master içerebilir mi?**

Evet. Bir sunum birden fazla slide master barındırabilir. Farklı bölümlerin farklı görsel sistemler veya marka kimliği gerektirdiği durumlarda birden çok master kullanın.

**Yer tutucuları master slayta mı yoksa layout slayta mı eklemeliyim?**

Çoğu durumda yer tutucuları layout slaytlara ekleyin. Paylaşılan görsel öğeleri ve ortak biçimlendirmeyi master slayta, içerik yer tutucularını ise normal slaytların kullanacağı layout slaytlara yerleştirin.

**Kullanımda olan bir master slaytı silebilir miyim?**

Hayır. Bağımlı slaytları olan bir master slayt doğrudan güvenli bir şekilde silinemez. Önce bu slaytları başka bir master altındaki layout’lara taşıyın veya yalnızca kullanılmayan master’ları temizleyen bir yöntem kullanın.