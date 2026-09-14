---
title: Python üzerinden Java ile Sunum Slayt Ana Şablonlarını Yönet
linktitle: Slayt Ana Şablonu
type: docs
weight: 70
url: /tr/python-java/slide-master/
keywords:
- slayt ana şablonu
- ana slayt
- PPT ana slaytı
- çoklu ana slaytlar
- ana slaytları karşılaştır
- arkaplan
- yer tutucu
- ana slaytı klonla
- ana slaytı kopyala
- ana slaytı çoğalt
- kullanılmayan ana slayt
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile slayt ana şablonlarını yönetin: PowerPoint ve OpenDocument sunumlarında ana şablonları erişin, düzenleyin, kopyalayın, karşılaştırın ve kaldırın."
---
## **Genel Bakış**

Bir **slayt ana şablonu**, bir grup slayt için ortak tasarım ayarlarını tanımlar. Ortak şekiller, logolar, arka planlar, metin stilleri, tema ayarları ve alt bilgi ayarları içerebilir. PowerPoint’te, bir slayt ana şablonunu düzenlemek, aynı biçimlendirmeyi her slaytta tekrarlamadan sunumu tutarlı tutmanın yaygın yoludur.

Aspose.Slides for Python via Java aynı modeli destekler. Bir sunum bir veya daha fazla ana şablon içerebilir ve her ana şablon birden çok düzen slaytı barındırabilir. Normal slaytlar genellikle doğrudan bir ana şablona başvurmaz. Bunun yerine bir normal slayt bir düzen slaytı kullanır ve bu düzen slaytı bir ana şablona aittir.

Hiyerarşi şu şekildedir:

1. **Slayt ana şablonu** – ortak tasarımı ve temayı tanımlar.  
1. **Düzen slaytı** – yer tutucuların ve düzen‑seviyesi biçimlendirmelerin belirli bir düzenini tanımlar.  
1. **Normal slayt** – gerçek sunum içeriğini içerir ve bir düzen slaytı kullanır.

![Ana slaytlar, düzen slaytları ve normal slaytların hiyerarşisi](slide-master_2.jpg)

Aspose.Slides’te bir slayt ana şablonu, [MasterSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslide/) sınıfı ile temsil edilir. Bir sunumdaki tüm ana şablonlar, [Presentation.getMasters](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getMasters) koleksiyonu aracılığıyla erişilebilir ve bu koleksiyon [MasterSlideCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslidecollection/) olarak temsil edilir.

{{% alert color="info" title="Kalıtım" %}}
Aynı özellik birden fazla seviyede tanımlandığında, daha spesifik seviye kazanır. Örneğin, bir ana şablon ve bir düzen slaytı aynı arka planı tanımlıyorsa, o düzen temel alınan slaytlar düzen arka planını kullanır. Düzen slaytları hakkında daha fazla bilgi için [Apply or Change Slide Layouts](/slides/tr/python-java/slide-layout/) bölümüne bakın.
{{% /alert %}}

## **Slayt Ana Şablonlarına Erişim**

PowerPoint’te **Görünüm** > **Slayt Ana Şablonu** menüsünden Slayt Ana Şablonu görünümünü açabilirsiniz.

![PowerPoint Görünüm sekmesindeki Slayt Ana Şablonu komutu](slide-master_3.jpg)

Aspose.Slides’te, ana şablonlara erişmek için [Presentation.getMasters](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getMasters) koleksiyonunu kullanın:

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

Ayrıca bir normal slaytın kullandığı ana şablonu, onun düzeni aracılığıyla alabilirsiniz:

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

## **Bir Slayt Ana Şablonu Neler İçerir**

Bir ana şablon, slayt benzeri bir nesnedir. [BaseSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslide/) sınıfından türediği için normal ve düzen slaytları tarafından kullanılan birçok slayt özelliğini sunar. Ana şablona özgü üyeler [MasterSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslide/) API sayfasında listelenmiştir.

Sık kullanılan ana şablon üyeleri şunlardır:

| Üye | Amaç |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslide/#getBackground) | Ana‑seviye slayt arka planını ayarlar. |
| [getShapes](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslide/#getShapes) | Logolar, resim çerçeveleri ve ortak metin gibi ana şablona yerleştirilen şekilleri saklar. |
| [getLayoutSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslide/#getLayoutSlides) | Ana şablona ait düzen slaytlarını saklar. |
| [getThemeManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslide/#getThemeManager) | Ana tema API’lerine erişim sağlar. |
| [getHeaderFooterManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | Ana şablon ve alt düzenleri için başlık, alt bilgi, tarih ve slayt numaralarını kontrol eder. |
| [getDependingSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslide/#getDependingSlides) | Düzenleri aracılığıyla ana şablona bağlı olan normal slaytları döndürür. |

## **Bir Slayt Ana Şablonuna Görüntü Ekleme**

Bir ana şablona bir görüntü eklendiğinde, o ana şablondan türetilen düzenleri kullanan slaytlarda görüntülenir. Bu, logolar, filigranlar, dekoratif bantlar ve diğer tekrarlanan görsel öğeler için yararlıdır.

Aşağıdaki örnek, ilk ana şablona bir logo ekler:

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

## **Yer Tutucularla Çalışma**

Yer tutucular genellikle düzen slaytlarında tanımlanır. Ana şablon, bu düzenlerin miras aldığı ortak stil ve temayı sağlar; her düzen ise hangi yer tutucuların mevcut olduğunu ve nerede konumlandırıldığını belirler.

PowerPoint’te yer tutucu komutları Slayt Ana Şablonu görünümünde bulunur.

![PowerPoint Slayt Ana Şablonu görünümündeki Yer Tutucu Ekle komutu](slide-master_5.png)

Aspose.Slides ile yeni yer tutucular eklemek için, ana şablona ait düzen slaytıyla çalışın:

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

Ayrıca bir ana şablonda zaten var olan yer tutucu şekillerini biçimlendirebilirsiniz. Aşağıdaki örnek, başlık yer tutucusunu bulur ve doğrusal bir degrade doldurma uygular:

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

![Normal slaytlar tarafından miras alınan biçimlendirilmiş başlık yer tutucusu](slide-master_8.png)

Daha fazla yer tutucu ve metin biçimlendirme seçeneği için [Set Prompt Text in Placeholder](/slides/tr/python-java/manage-placeholder/) ve [Text Formatting](/slides/tr/python-java/text-formatting/) bölümlerine bakın.

## **Bir Slayt Ana Şablonu Arka Planını Değiştirme**

Ana şablon arka planı, üzerine bir şey yazılmadığı sürece düzenler ve slaytlar tarafından miras alınır. Aşağıdaki örnek, ilk ana şablon için katı bir arka plan rengi ayarlar:

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

İlgili konular için [Presentation Background](/slides/tr/python-java/presentation-background/) ve [Presentation Theme](/slides/tr/python-java/presentation-theme/) bölümlerine bakın.

## **Bir Slayt Ana Şablonunu Başka Bir Sunuma Kopyalama**

Bir ana şablonu başka bir sunuma kopyalamak için [MasterSlideCollection.addClone](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslidecollection/#addClone) yöntemini kullanın. Kopyalanan ana şablon, hedef sunumdaki düzenler ve slaytlar tarafından kullanılabilir.

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

Normal slaytları ve ana şablonlarını birlikte kopyalamanız gerekiyorsa, [Clone Slides](/slides/tr/python-java/clone-slides/) bölümüne bakın.

## **Birden Çok Slayt Ana Şablonu Ekleme**

Bir sunum birden fazla ana şablon içerebilir. Bu, farklı bölümlerin farklı marka, sayfa yapısı veya tema ayarları gerektirdiği durumlarda faydalıdır.

![Ana şablon ekleme ve yönetme komutları (PowerPoint)](slide-master_9.jpg)

Aşağıdaki örnek, varsayılan ana şablonu kopyalar, klona farklı bir arka plan verir, o kopyalanan ana şablon altında bir düzen oluşturur ve bu düzene dayalı yeni bir slayt ekler:

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

## **Slayt Ana Şablonlarını Karşılaştırma**

Ana şablonlar, [BaseSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslide/) sınıfından miras alınan [equals](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslide/#equals) yöntemi ile karşılaştırılabilir. Karşılaştırma, şekiller, metin, biçimlendirme, animasyonlar ve diğer slayt ayarları gibi yapı ve statik içeriği denetler. Slayt kimlikleri gibi benzersiz tanımlayıcıları veya geçerli tarih gibi dinamik yer tutucu değerlerini karşılaştırmaz.

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

Daha fazla bilgi için [Compare Presentation Slides](/slides/tr/python-java/compare-slides/) bölümüne bakın.

## **Slayt Ana Şablonu Görünümünü Varsayılan Görünüm Olarak Ayarlama**

PowerPoint’in ilk açtığı görünümü kontrol etmek için [ViewProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/) üzerindeki [setLastView](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/#setLastView) metodunu kullanın. Aşağıdaki örnek, sunumu Slayt Ana Şablonu görünümünde açar:

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

Daha fazla görünüm ayarı için [Save Presentation](/slides/tr/python-java/save-presentation/) bölümüne bakın.

## **Kullanılmayan Ana Şablonları Kaldırma**

Bazen bir sunumda normal slaytlar tarafından artık kullanılmayan ana şablonlar bulunur. Kullanılmayan ana şablonları kaldırmak dosya boyutunu azaltabilir ve şablon bakımını basitleştirebilir.

Kullanılmayan ana şablonları, [Presentation.getMasters](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getMasters) koleksiyonundan kaldırmak için [removeUnused](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslidecollection/#removeUnused) metodunu kullanın:

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

**Slayt ana şablonu ile düzen slaytı arasındaki fark nedir?**  
Slayt ana şablonu tema, arka plan, ortak şekiller ve metin stilleri gibi ortak tasarım ayarlarını tanımlar. Bir düzen slaytı bir ana şablona aittir ve yer tutucuların belirli bir düzenini tanımlar. Normal bir slayt bir düzen slaytı kullanır, böylece hem düzen hem de ana şablondan miras alır.

**Bir sunum birden fazla slayt ana şablonu içerebilir mi?**  
Evet. Bir sunum birden fazla slayt ana şablonu içerebilir. Farklı bölümlerin farklı görsel sistemler veya marka kimliği gerektirdiği durumlarda birden çok ana şablon kullanın.

**Yer tutucuları ana şablona mı yoksa düzen slaytına mı eklemeliyim?**  
Çoğu durumda yer tutucuları düzen slaytlarına ekleyin. Ortak görsel öğeleri ve ortak biçimlendirmeyi ana şablona koyun, ardından normal slaytların kullanacağı içerik yer tutucularını düzenlerde tanımlayın.

**Kullanımda olan bir ana şablonu silebilir miyim?**  
Hayır. Bağımlı slaytları olan bir ana şablon doğrudan güvenli bir şekilde kaldırılamaz. Önce bu slaytları başka bir ana şablonun düzenlerine taşıyın veya yalnızca kullanılmayan ana şablonları kaldıran temizlik yöntemini kullanın.