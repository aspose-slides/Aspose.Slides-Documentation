---
title: Python'da Sunum Slayt Master'larını Yönet
linktitle: Slayt Master
type: docs
weight: 80
url: /tr/python-net/slide-master/
keywords:
- slayt master
- master slayt
- PPT master slaytı
- çoklu master slaytlar
- master slaytları karşılaştır
- arka plan
- yer tutucu
- master slaytı klonla
- master slaytı kopyala
- master slaytı çoğalt
- kullanılmayan master slayt
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET'de slayt master'larını yönetin: PowerPoint ve OpenDocument sunumlarında master slaytları erişin, düzenleyin, klonlayın, karşılaştırın ve kaldırın."
---
## **Genel Bakış**

Bir **slayt master'ı**, bir grup slayt için ortak tasarım ayarlarını tanımlar. Ortak şekiller, logolar, arka planlar, metin stilleri, tema ayarları ve altbilgi ayarları içerebilir. PowerPoint’te bir slayt master'ını düzenlemek, aynı biçimlendirmeyi her slaytta tekrarlamadan sunumu tutarlı tutmanın yaygın yoludur.

Aspose.Slides for Python via .NET aynı modeli destekler. Bir sunum bir veya daha fazla master slayt içerebilir ve her master slayt birden fazla yerleşim slaytı barındırabilir. Normal slaytlar doğrudan bir master slayta başvurmaz. Bunun yerine, bir normal slayt bir yerleşim slaytı kullanır ve bu yerleşim slaytı bir master slayta aittir.

Hiyerarşi şudur:

1. **Slide master** - ortak tasarımı ve temayı tanımlar.  
1. **Layout slide** - yer tutucuların ve yerleşim düzeyinde biçimlendirmenin belirli bir düzenini tanımlar.  
1. **Normal slide** - gerçek sunum içeriğini içerir ve bir layout slaytı kullanır.

![Master slaytların, yerleşim slaytların ve normal slaytların hiyerarşisi](slide-master_2.jpg)

Aspose.Slides’te bir slide master, [MasterSlide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslide/) sınıfı ile temsil edilir. Bir sunumdaki tüm master slaytlar `Presentation.masters` koleksiyonu üzerinden erişilebilir.

{{% alert color="info" title="Inheritance" %}}
Aynı özellik birden fazla seviyede tanımlandığında, daha spesifik seviye geçerli olur. Örneğin, bir master slayt ve bir layout slayt aynı arka planı tanımlarsa, o layout’a dayalı slaytlar layout arka planını kullanır. Yerleşim slaytları hakkında daha fazla bilgi için [Kaydırma Yerleşimlerini Uygula veya Değiştir](/slides/tr/python-net/slide-layout/) bölümüne bakın.
{{% /alert %}}

## **Slide Master’lara Erişim**

PowerPoint’te **View** > **Slide Master** menüsüyle Slide Master görünümünü açabilirsiniz.

![PowerPoint Görünüm sekmesindeki Slide Master komutu](slide-master_3.jpg)

Aspose.Slides’te master slaytlara erişmek için `masters` koleksiyonunu kullanın:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

Ayrıca bir normal slaytın kullandığı master slaytı, slaytının layout’u üzerinden alabilirsiniz:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **Bir Slide Master’ı Neler İçerir**

Bir master slayt, slayt benzeri bir nesnedir. Ortak slayt davranışını [BaseSlide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseslide/) sınıfından devralır; bu sayede normal ve layout slaytlarda kullanılan birçok aynı slayt özelliğine sahiptir. Master‑özel üyeler [MasterSlide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslide/) API sayfasında listelenir.

Sık kullanılan master slayt üyeleri şunlardır:

| Üye | Amaç |
| --- | --- |
| `background` | Master düzeyinde slayt arka planını ayarlar. |
| `shapes` | Master üzerine yerleştirilen şekilleri (logolar, resim çerçeveleri ve ortak metin gibi) depolar. |
| `layout_slides` | Mastera ait yerleşim slaytlarını depolar. |
| `theme_manager` | Master tema API'lerine erişim sağlar. |
| `header_footer_manager` | Master ve ona bağlı yerleşim slaytları için üstbilgi, altbilgi, tarih ve slayt numaralarını kontrol eder. |
| `get_depending_slides` | Yerleşimleri aracılığıyla mastera bağlı normal slaytları döndürür. |

## **Bir Slide Master’a Görüntü Ekleme**

Bir master slayta bir görüntü eklediğinizde, bu görüntü o master’dan türetilen layout’ları kullanan slaytlarda görünür. Logo, filigran, süs bantları ve diğer tekrarlanan görsel öğeler için kullanışlıdır.

Aşağıdaki örnek, ilk master slayta bir logo ekler:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    with open("logo.png", "rb") as logo_stream:
        logo_bytes = logo_stream.read()

    logo_image = presentation.images.add_image(logo_bytes)

    master_slide.shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE,
        20,
        20,
        80,
        80,
        logo_image)

    presentation.save("presentation-with-logo.pptx", slides.export.SaveFormat.PPTX)
```

Resim çerçeveleri hakkında daha fazla bilgi için [Picture Frame](/slides/tr/python-net/picture-frame/) bölümüne bakın.

## **Master Grafiklerinin Görünürlüğünü Kontrol Etme**

[Miras alınan master grafiklerini (logo veya süs şekilleri gibi) silmeden gizlemek] için [BaseSlide.show_master_shapes](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseslide/show_master_shapes/) özelliğini kullanın. Bu grafikleri gizlemek istediğiniz slaytta `Slide.show_master_shapes` özelliğini `False` olarak ayarlayın; gösterilmesini istediğiniz slaytlarda ise `True` bırakın.

Aşağıdaki bağımsız örnek, bir master’da mavi süs bandı oluşturur ve aynı boş layout’u kullanan iki slaytta farklı görünürlük ayarları uygular. İlk slaytta bant görünür, ikinci slaytta gizlenir. Giriş sunumu veya görüntüsü gerekmez.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]
    layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_slide.show_master_shapes = True

    slide_height = presentation.slide_size.size.height
    band = master_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 60, slide_height)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.steel_blue
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    visible_slide = presentation.slides[0]
    visible_slide.layout_slide = layout_slide
    visible_slide.shapes.clear()

    hidden_slide = presentation.slides.add_empty_slide(layout_slide)

    visible_slide.show_master_shapes = True
    hidden_slide.show_master_shapes = False

    presentation.save("master-graphics.pptx", slides.export.SaveFormat.PPTX)
```

Örnek, yeni bir sunumla birlikte gelen **Blank** layout’u kullanır ve ilk slayttaki yer tutucuları kaldırır.

### **Ayarın Kapsamını Seçin**

Normal bir slayt, masterına `[Slide.layout_slide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/layout_slide/)` ve `[LayoutSlide.master_slide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutslide/master_slide/)` aracılığıyla bağlanır. Özelliği bireysel bir slaytta ayarlamak yalnız o slaytı etkiler. `[LayoutSlide.show_master_shapes](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutslide/show_master_shapes/)` özelliğini `False` yapmak, aynı layout’u kullanan tüm slaytlarda master grafiklerini gizler; kendi ayarı `True` olsa bile. Tek bir slaytta grafikleri gizlemek istiyorsanız, slayt özelliğini değiştirin ve paylaşılan layout’u aynı bırakın.

Bu ayar, master slayt üzerinde bir görünürlük kontrolü olarak desteklenmez. Master üzerinde her zaman `False` döner ve `True` atanması bir istisna fırlatır. Bunun yerine normal slaytta veya layout’da kullanın.

### **Grafikleri Arka Plandan Ayırma**

| İşlem | Etki |
| --- | --- |
| Master grafiklerini gizle | Miras alınan master şekillerinin görünürlüğünü, slaytın kendi şekillerini silmeden veya değiştirmeden kontrol eder. |
| Slayt arka plan doldurmasını değiştir | Arka plan rengini, gradyanını veya görüntüsünü değiştirir. Master grafikleri ayrı şekiller olduğundan bu arka planın üstünde görünmeye devam eder. [Presentation Background](/slides/tr/python-net/presentation-background/) bölümüne bakın. |
| Master’dan bir şekil sil | Paylaşılan kaynak şekli kaldırır; bu şekilde master’ı kullanan hiçbir slayt artık o şekle erişemez. |

## **Yer Tutucularla Çalışma**

Yer tutucular genellikle layout slaytlarda tanımlanır. Master slayt, bu layout’ların miras aldığı ortak stil ve temayı sağlar; her layout ise hangi yer tutucuların bulunacağını ve nerede konumlanacağını belirler.

PowerPoint’te yer tutucu komutları Slide Master görünümünde bulunur.

![PowerPoint Slide Master görünümündeki Insert Placeholder komutu](slide-master_5.png)

Aspose.Slides ile yeni yer tutucular eklemek için master’a ait layout slaytıyla çalışın:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    blank_layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout_slide is None:
        blank_layout_slide = presentation.layout_slides.add(
            master_slide,
            slides.SlideLayoutType.BLANK,
            "Blank")

    blank_layout_slide.placeholder_manager.add_text_placeholder(60, 120, 600, 80)

    presentation.slides.add_empty_slide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", slides.export.SaveFormat.PPTX)
```

Ayrıca master slayt üzerinde zaten var olan yer tutucu şekillerini biçimlendirebilirsiniz. Aşağıdaki örnek, başlık yer tutucusunu bulur ve lineer bir gradyan doldurma uygular:

```python
import aspose.pydrawing as draw
import aspose.slides as slides


def find_placeholder(master_slide, placeholder_type):
    for shape in master_slide.shapes:
        if isinstance(shape, slides.AutoShape) and shape.placeholder is not None:
            if shape.placeholder.type == placeholder_type:
                return shape

    return None


with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    title_placeholder = find_placeholder(master_slide, slides.PlaceholderType.TITLE)

    if title_placeholder is not None:
        red_gradient_color = draw.Color.from_argb(255, 0, 0)
        purple_gradient_color = draw.Color.from_argb(128, 0, 128)

        title_placeholder.fill_format.fill_type = slides.FillType.GRADIENT
        title_placeholder.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
        title_placeholder.fill_format.gradient_format.gradient_stops.add(0, red_gradient_color)
        title_placeholder.fill_format.gradient_format.gradient_stops.add(1, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![Normal slaytlar tarafından miras alınan biçimlendirilmiş başlık yer tutucusu](slide-master_8.png)

Daha fazla yer tutucu ve metin biçimlendirme seçeneği için [Set Prompt Text in Placeholder](/slides/tr/python-net/manage-placeholder/) ve [Text Formatting](/slides/tr/python-net/text-formatting/) bölümlerine bakın.

## **Bir Slide Master Arka Planını Değiştirme**

Master arka planı, üzerine yazılmadığı sürece layout ve slaytlar tarafından miras alınır. Aşağıdaki örnek, ilk master slayta katı bir arka plan rengi atar:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    presentation.save("presentation-master-background.pptx", slides.export.SaveFormat.PPTX)
```

İlgili konular için [Presentation Background](/slides/tr/python-net/presentation-background/) ve [Presentation Theme](/slides/tr/python-net/presentation-theme/) bölümlerine bakın.

## **Bir Slide Master’ı Başka Bir Sunuma Kopyalama**

[MasterSlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslidecollection/) sınıfındaki `add_clone` metodunu kullanarak bir master slaytı başka bir sunuma kopyalayabilirsiniz. Kopyalanan master, hedef sunumdaki layout ve slaytlar tarafından kullanılabilir.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Normal slaytları ve onların masterlarını birlikte kopyalamanız gerekiyorsa, [Clone Slides](/slides/tr/python-net/clone-slides/) bölümüne bakın.

## **Birden Fazla Slide Master Ekleme**

Bir sunum birden fazla master slayt içerebilir. Bu, farklı bölümlerin farklı marka, sayfa yapısı veya tema ayarları gerektirdiği durumlarda kullanışlıdır.

![Master slayt ekleme ve yönetme için PowerPoint komutları](slide-master_9.jpg)

Aşağıdaki örnek, varsayılan master’ı kopyalar, kopyaya farklı bir arka plan verir, o kopya master altındaki boş bir layout alır ve bu layout’a dayalı yeni bir slayt ekler:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    default_master_slide = presentation.masters[0]
    section_master_slide = presentation.masters.add_clone(default_master_slide)

    section_master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    section_master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    section_master_slide.background.fill_format.solid_fill_color.color = draw.Color.light_steel_blue

    section_blank_layout = section_master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if section_blank_layout is None:
        section_blank_layout = presentation.layout_slides.add(
            section_master_slide,
            slides.SlideLayoutType.BLANK,
            "Section Blank")

    presentation.slides.add_empty_slide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", slides.export.SaveFormat.PPTX)
```

## **Slide Master’ları Karşılaştırma**

Master slaytlar, [BaseSlide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseslide/) sınıfından devralınan `equals` metodu ile karşılaştırılabilir. Karşılaştırma, şekiller, metin, biçimlendirme, animasyonlar ve diğer slayt ayarları gibi yapı ve statik içeriği inceler. Slayt kimlikleri gibi benzersiz tanımlayıcıları veya geçerli tarih gibi dinamik yer tutucu değerlerini karşılaştırmaz.

```python
import aspose.slides as slides

with slides.Presentation("first.pptx") as first_presentation:
    with slides.Presentation("second.pptx") as second_presentation:
        first_presentation_master_count = len(first_presentation.masters)
        second_presentation_master_count = len(second_presentation.masters)

        for first_master_index in range(first_presentation_master_count):
            for second_master_index in range(second_presentation_master_count):
                first_master_slide = first_presentation.masters[first_master_index]
                second_master_slide = second_presentation.masters[second_master_index]
                are_master_slides_equal = first_master_slide.equals(second_master_slide)

                if are_master_slides_equal:
                    print(
                        "first.pptx master #{} equals second.pptx master #{}".format(
                            first_master_index,
                            second_master_index))
```

Daha fazla bilgi için [Compare Presentation Slides](/slides/tr/python-net/compare-slides/) bölümüne bakın.

## **Slide Master Görünümünü Varsayılan Görünüm Olarak Ayarlama**

Sunumun [ViewProperties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/viewproperties/) üzerindeki `last_view` özelliği, PowerPoint’in ilk açtığı görünümü kontrol eder. Aşağıdaki örnek, sunumu Slide Master görünümünde açar:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

Daha fazla görünüm ayarı için [Save Presentation](/slides/tr/python-net/save-presentation/) bölümüne bakın.

## **Kullanılmayan Master Slaytları Kaldırma**

Bazen bir sunum, hiçbir normal slayt tarafından kullanılmayan master slaytlar içerir. Kullanılmayan masterları kaldırmak, dosya boyutunu azaltabilir ve şablon bakımını basitleştirir.

Kullanılmayan masterları `masters` koleksiyonundan kaldırmak için `remove_unused` yöntemini kullanın:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

Ayrıca düşük‑kodlu `remove_unused_master_slides` metodunu [Compress](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/compress/) sınıfından da kullanabilirsiniz:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Slide master ile layout slide arasındaki fark nedir?**

Slide master, tema, arka plan, ortak şekiller ve metin stilleri gibi ortak tasarım ayarlarını tanımlar. Layout slide, bir master slayta aittir ve yer tutucuların belirli bir düzenini tanımlar. Normal bir slayt bir layout slide kullanır; bu sayede hem layout hem de master’dan miras alır.

**Bir sunum birden fazla slide master içerebilir mi?**

Evet. Bir sunum birden fazla slide master içerebilir. Farklı bölümlerin farklı görsel sistemlere veya marka kimliklerine ihtiyaç duyduğu durumlarda birden fazla master kullanın.

**Yer tutucuları master slayta mı yoksa layout slidela mı eklemeliyim?**

Genellikle yer tutucuları layout slaytlara ekleyin. Paylaşılan görsel öğeleri ve ortak biçimlendirmeyi master slayta koyun, ardından normal slaytların kullanacağı layout’larda içerik yer tutucularını oluşturun.

**Kullanımda olan bir master slaytı silebilir miyim?**

Hayır. Bağlı slaytları olan bir master slaytı doğrudan güvenli bir şekilde kaldırılamaz. Önce bu slaytları başka bir master altındaki layout’lara taşıyın veya yalnızca kullanılmayan masterları temizleyen bir yöntem kullanın.