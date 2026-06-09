---
title: Python’da Sunum Slide Master’larını Yönet
linktitle: Slayt Master
type: docs
weight: 80
url: /tr/python-net/slide-master/
keywords:
- slayt master
- master slayt
- PPT master slayt
- birden fazla master slayt
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
description: "Aspose.Slides for Python via .NET içinde slayt masterlarını yönetin: PowerPoint ve OpenDocument sunumlarındaki master slaytları erişin, düzenleyin, klonlayın, karşılaştırın ve kaldırın."
---
## **Genel Bakış**

Bir **slide master**, bir grup slayt için ortak tasarım ayarlarını tanımlar. Ortak şekiller, logolar, arka planlar, metin stilleri, tema ayarları ve alt bilgi ayarları içerebilir. PowerPoint’te bir slide master’ı düzenlemek, aynı biçimlendirmeyi her slaytta tekrarlamadan sunumu tutarlı tutmanın yaygın yoludur.

Aspose.Slides for Python via .NET aynı modeli destekler. Bir sunum bir veya daha fazla master slayt içerebilir ve her master slayt birden çok layout slaytı barındırabilir. Normal slaytlar doğrudan bir master slayta başvurmaz. Bunun yerine, normal bir slayt bir layout slaytını kullanır ve bu layout slayt bir master slayta aittir.

Hiyerarşi şudur:

1. **Slide master** – ortak tasarımı ve temayı tanımlar.  
1. **Layout slayt** – yer tutucuların ve layout‑seviyesi biçimlendirmelerin özel düzenini tanımlar.  
1. **Normal slayt** – gerçek sunum içeriğini barındırır ve bir layout slaytı kullanır.

![Master slaytların, layout slaytların ve normal slaytların hiyerarşisi](slide-master_2.jpg)

Aspose.Slides’ta bir slide master, [MasterSlide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslide/) sınıfı ile temsil edilir. Bir sunumdaki tüm master slaytlar `Presentation.masters` koleksiyonu üzerinden erişilebilir.

{{% alert color="info" title="Inheritance" %}}
Aynı özellik birden çok seviyede tanımlandığında, daha spesifik seviye geçerli olur. Örneğin, bir master slayt ve bir layout slayt aynı arka planı tanımlarsa, o layout’a dayanan slaytlar layout arka planını kullanır. Layout slaytları hakkında daha fazla bilgi için [Apply or Change Slide Layouts](/python-net/slide-layout/) sayfasına bakın.
{{% /alert %}}

## **Slide Master’lara Erişim**

PowerPoint’te **View** > **Slide Master** menüsünden Slide Master görünümünü açabilirsiniz.

![PowerPoint Görünüm sekmesindeki Slide Master komutu](slide-master_3.jpg)

Aspose.Slides’ta master slaytlara erişmek için `masters` koleksiyonunu kullanın:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

Ayrıca bir normal slaytın kullandığı master slaytı, o slaytın layout’u üzerinden elde edebilirsiniz:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **Bir Slide Master’ın İçeriği**

Bir master slayt, slayt benzeri bir nesnedir. Ortak slayt davranışını [BaseSlide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseslide/) sınıfından kalıtır; bu sayede normal ve layout slaytlarda kullanılan birçok slayt özelliğine erişebilir. Master‑özel üyeler [MasterSlide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslide/) API sayfasında listelenir.

Sık kullanılan master slayt üyeleri şunlardır:

| Üye | Amaç |
| --- | --- |
| `background` | Master‑seviyesi slayt arka planını ayarlar. |
| `shapes` | Master üzerine yerleştirilen şekilleri (logolar, resim çerçeveleri, ortak metin vb.) depolar. |
| `layout_slides` | Master’a ait layout slaytları saklar. |
| `theme_manager` | Master tema API’lerine erişim sağlar. |
| `header_footer_manager` | Master ve onun alt layoutları için başlık, alt bilgi, tarih ve slayt numaralarını kontrol eder. |
| `get_depending_slides` | Layoutları aracılığıyla master’a bağımlı olan normal slaytları döndürür. |

## **Slide Master’a Görüntü Ekleme**

Bir master slayta resim eklediğinizde, o master’dan layout kullanan slaytlarda görünür. Logolar, filigranlar, dekoratif şeritler ve diğer tekrarlanan görsel öğeler için faydalıdır.

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

Resim çerçeveleri hakkında daha fazla bilgi için [Picture Frame](/python-net/picture-frame/) sayfasına bakın.

## **Yer Tutucularla Çalışma**

Yer tutucular genellikle layout slaytlarda tanımlanır. Master slayt, bu layoutların devraldığı ortak stil ve temayı sağlar; her layout ise hangi yer tutucuların mevcut olduğunu ve nerede konumlanacağını belirler.

PowerPoint’te yer tutucu komutları Slide Master görünümünde bulunur.

![PowerPoint Slide Master görünümündeki Insert Placeholder komutu](slide-master_5.png)

Aspose.Slides’ta yeni yer tutucular eklemek için master’a ait layout slayt üzerinde çalışın:

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

Mevcut yer tutucu şekillerini de biçimlendirebilirsiniz. Aşağıdaki örnek, başlık yer tutucusunu bulur ve doğrusal bir degrade doldurma uygular:

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
        title_placeholder.fill_format.gradient_format.gradient_stops.add(255, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![Normal slaytlar tarafından devralınan biçimlendirilmiş başlık yer tutucusu](slide-master_8.png)

Daha fazla yer tutucu ve metin biçimlendirme seçeneği için [Set Prompt Text in Placeholder](/python-net/manage-placeholder/) ve [Text Formatting](/python-net/text-formatting/) sayfalarına bakın.

## **Slide Master Arka Planını Değiştirme**

Bir master arka planı, üzerine değişiklik yapılmayan layout ve slaytlar tarafından devralınır. Aşağıdaki örnek, ilk master slayt için katı bir arka plan rengi ayarlar:

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

İlgili konular için [Presentation Background](/python-net/presentation-background/) ve [Presentation Theme](/python-net/presentation-theme/) sayfalarına göz atın.

## **Slide Master’ı Başka Bir Sunuma Kopyalama**

[MasterSlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslidecollection/) sınıfındaki `add_clone` metodunu kullanarak bir master slaytı başka bir sunuma kopyalayabilirsiniz. Kopyalanan master, hedef sunumdaki layout ve slaytlar tarafından kullanılabilir.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Normal slaytları ve bağlı masterlarını bir arada klonlamak isterseniz [Clone Slides](/python-net/clone-slides/) sayfasına bakın.

## **Birden Çok Slide Master Ekleme**

Bir sunum birden fazla master slayt içerebilir. Bu, farklı bölümlerin farklı marka, sayfa yapısı veya tema ayarları gerektirdiği durumlarda kullanışlıdır.

![Master slayt ekleme ve yönetme için PowerPoint komutları](slide-master_9.jpg)

Aşağıdaki örnek, varsayılan master’ı klonlar, klona farklı bir arka plan verir, bu klon master’ın altına boş bir layout oluşturur ve bu layout üzerinden yeni bir slayt ekler:

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

Master slaytlar, [BaseSlide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseslide/) sınıfından miras alınan `equals` metodu ile karşılaştırılabilir. Karşılaştırma, şekiller, metin, biçimlendirme, animasyonlar ve diğer slayt ayarları gibi yapısal ve statik içeriği kontrol eder. Slayt ID’leri gibi benzersiz tanımlayıcılar veya geçerli tarih gibi dinamik yer tutucu değerleri karşılaştırılmaz.

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

Daha fazla bilgi için [Compare Presentation Slides](/python-net/compare-slides/) sayfasına bakın.

## **Slide Master Görünümünü Varsayılan Görünüm Olarak Ayarlama**

Sunumun [ViewProperties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/viewproperties/) üzerindeki `last_view` özelliğini kullanarak PowerPoint’in ilk açtığında hangi görünümü göstereceğini kontrol edebilirsiniz. Aşağıdaki örnek, sunumu Slide Master görünümünde açar:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

Daha fazla görünüm ayarı için [Save Presentation](/python-net/save-presentation/) sayfasına bakın.

## **Kullanılmayan Master Slaytları Kaldırma**

Bazen bir sunum, hiçbir normal slayt tarafından kullanılmayan master slaytlar içerir. Kullanılmayan master’ları kaldırmak dosya boyutunu azaltabilir ve şablon bakımını basitleştirebilir.

`remove_unused` metodunu kullanarak `masters` koleksiyonundan kullanılmayan master’ları kaldırabilirsiniz:

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

**Slide master ile layout slayt arasındaki fark nedir?**

Slide master, tema, arka plan, ortak şekiller ve metin stilleri gibi ortak tasarım ayarlarını tanımlar. Layout slayt bir master’a aittir ve yer tutucuların belirli bir düzenini tanımlar. Normal bir slayt bir layout slayt kullanır; böylece hem layout hem de master’dan miras alır.

**Bir sunum birden çok slide master içerebilir mi?**

Evet. Bir sunum birden fazla slide master barındırabilir. Farklı bölümlerin farklı görsel sistemler veya marka ihtiyaçları olduğunda birden fazla master kullanın.

**Yer tutucuları master slayta mı yoksa layout slayta mı eklemeliyim?**

Çoğu durumda yer tutucuları layout slaytlara ekleyin. Paylaşılan görsel öğeleri ve ortak biçimlendirmeyi master slayta koyun, ardından normal slaytların kullanacağı içerik yer tutucularını layout slaytlara yerleştirin.

**Kullanımda olan bir master slaytı silebilir miyim?**

Hayır. Bağımlı slaytları olan bir master slayt doğrudan güvenli şekilde kaldırılamaz. Önce bu slaytları başka bir master altındaki layoutlara taşıyın veya yalnızca kullanılmayan master’ları temizleyen bir yöntem kullanın.