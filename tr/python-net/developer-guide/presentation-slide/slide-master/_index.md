---
title: "Python'da Sunum Slayt Ana Taslaklarını Yönetme"
linktitle: "Slayt Ana Taslağı"
type: docs
weight: 80
url: /tr/python-net/slide-master/
keywords:
- slayt ana taslağı
- ana slayt
- PPT ana slaytı
- çoklu ana slaytlar
- ana slaytları karşılaştırma
- arka plan
- yer tutucu
- ana slaytı klonla
- ana slaytı kopyala
- ana slaytı çoğalt
- kullanılmayan ana slayt
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET içinde slayt ana taslaklarını yönetin: PowerPoint ve OpenDocument sunumlarında ana slaytları erişin, düzenleyin, klonlayın, karşılaştırın ve kaldırın."
---
## **Genel Bakış**

Bir **slayt ana taslağı**, bir grup slayt için ortak tasarım ayarlarını tanımlar. Ortak şekiller, logolar, arka planlar, metin stilleri, tema ayarları ve alt bilgi ayarları içerebilir. PowerPoint'te bir slayt ana taslağını düzenlemek, aynı biçimlendirmeyi her slaytta tekrarlamadan sunumu tutarlı tutmanın yaygın yoludur.

Aspose.Slides for Python via .NET aynı modeli destekler. Bir sunum bir veya daha fazla ana slayt içerebilir ve her ana slayt birkaç yerleşim slaytı içerebilir. Normal slaytlar genellikle doğrudan bir ana slayta başvurmaz. Bunun yerine, normal bir slayt bir yerleşim slaytı kullanır ve bu yerleşim slaytı bir ana slayta aittir.

Hiyerarşi şu şekildedir:

1. **Slide master** - ortak tasarım ve temayı tanımlar.
1. **Layout slide** - yer tutucuların belirli düzenini ve yerleşim‑seviyesindeki biçimlendirmeyi tanımlar.
1. **Normal slide** - gerçek sunum içeriğini içerir ve bir yerleşim slaytı kullanır.

![Ana slaytların, yerleşim slaytlarının ve normal slaytların hiyerarşisi](slide-master_2.jpg)

Aspose.Slides'te bir slayt ana taslağı, [MasterSlide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslide/) sınıfı ile temsil edilir. Bir sunumdaki tüm ana slaytlar `Presentation.masters` koleksiyonu aracılığıyla erişilebilir.

{{% alert color="info" title="Inheritance" %}}

Aynı özellik birden fazla seviyede tanımlandığında, daha spesifik seviye geçerli olur. Örneğin, bir ana slayt ve bir yerleşim slaytı aynı arka planı tanımlarsa, o yerleşime dayanan slaytlar yerleşim arka planını kullanır. Yerleşim slaytları hakkında daha fazla bilgi için [Apply or Change Slide Layouts](/slides/tr/python-net/slide-layout/) bölümüne bakın.

{{% /alert %}}

## **Slide Ana Taslaklarına Erişim**

PowerPoint'te **View** > **Slide Master** menüsünden Slide Master görünümünü açabilirsiniz.

![PowerPoint Görünüm sekmesindeki Slide Master komutu](slide-master_3.jpg)

Aspose.Slides'te ana slaytlara erişmek için `masters` koleksiyonunu kullanın:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

Ayrıca, bir normal slaytın kullandığı ana slaytı, onun yerleşimi üzerinden alabilirsiniz:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **Bir Slide Ana Taslağı Ne İçerir**

Bir ana slayt, slayt benzeri bir nesnedir. [BaseSlide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseslide/) sınıfından ortak slayt davranışını devralır, bu yüzden normal ve yerleşim slaytlarıyla aynı birçok slayt özelliğini sunar. Ana slayta özgü üyeler [MasterSlide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslide/) API sayfasında listelenmiştir.

Sıklıkla kullanılan ana slayt üyeleri şunlardır:

| Üye | Açıklama |
| --- | --- |
| `background` | Ana‑seviye slayt arka planını ayarlar. |
| `shapes` | Logolar, resim çerçeveleri ve ortak metin gibi ana slayta yerleştirilen şekilleri depolar. |
| `layout_slides` | Ana slayta ait yerleşim slaytlarını depolar. |
| `theme_manager` | Ana temanın API'lerine erişim sağlar. |
| `header_footer_manager` | Ana ve ona bağlı yerleşimler için başlık, alt bilgi, tarih ve slayt numaralarını kontrol eder. |
| `get_depending_slides` | Yerleşimleri aracılığıyla ana slayta bağımlı olan normal slaytları döndürür. |

## **Slide Ana Taslağına Resim Ekleme**

Bir ana slayta resim eklendiğinde, o ana slayttan yerleşim kullanan tüm slaytlarda görünür. Bu, logo, filigran, süs bandı ve diğer tekrar eden görsel öğeler için faydalıdır.

Aşağıdaki örnek, ilk ana slayta bir logo ekler:

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

## **Yer Tutucularla Çalışma**

Yer tutucular normalde yerleşim slaytlarında tanımlanır. Ana slayt, bu yerleşimlerin devraldığı ortak stil ve temayı sağlar; her yerleşim ise hangi yer tutucuların mevcut olduğunu ve nerede konumlandırılacağını belirler.

PowerPoint'te yer tutucu komutları Slide Master görünümünde bulunur.

![PowerPoint Slide Master görünümündeki Insert Placeholder komutu](slide-master_5.png)

Aspose.Slides ile yeni yer tutucular eklemek için ana slayta ait yerleşim slaytıyla çalışın:

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

Ayrıca, bir ana slaytta zaten bulunan yer tutucu şekillerini biçimlendirebilirsiniz. Aşağıdaki örnek, başlık yer tutucusunu bulur ve lineer bir degrade dolgu uygular:

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

![Normal slaytlar tarafından devralınan biçimlendirilmiş başlık yer tutucusu](slide-master_8.png)

Daha fazla yer tutucu ve metin biçimlendirme seçeneği için [Set Prompt Text in Placeholder](/slides/tr/python-net/manage-placeholder/) ve [Text Formatting](/slides/tr/python-net/text-formatting/) bölümlerine bakın.

## **Slide Ana Taslağı Arka Planını Değiştirme**

Ana arka plan, üzerine yazılmadığı sürece yerleşimler ve slaytlar tarafından devralınır. Aşağıdaki örnek, ilk ana slayt için katı bir arka plan rengi ayarlar:

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

İlgili konular için [Presentation Background](/slides/tr/python-net/presentation-background/) ve [Presentation Theme](/slides/tr/python-net/presentation-theme/) bölümlerine göz atın.

## **Bir Slide Ana Taslağını Başka Bir Sunuma Kopyalama**

[MasterSlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslidecollection/) sınıfındaki `add_clone` yöntemiyle bir ana slaytı başka bir sunuma kopyalayabilirsiniz. Kopyalanan ana, hedef sunumdaki yerleşimler ve slaytlar tarafından kullanılabilir.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Normal slaytları, onların ana slaytlarıyla birlikte kopyalamanız gerekiyorsa, [Clone Slides](/slides/tr/python-net/clone-slides/) bölümüne bakın.

## **Birden Çok Slide Ana Taslağı Ekleme**

Bir sunum birden fazla ana slayt içerebilir. Bu, farklı bölümlerin farklı marka, sayfa yapısı veya tema ayarları gerektirdiği durumlarda yararlıdır.

![Ana slayt ekleme ve yönetme için PowerPoint komutları](slide-master_9.jpg)

Aşağıdaki örnek, varsayılan ana slaytı kopyalar, kopyaya farklı bir arka plan verir, bu kopyalanmış ana altında boş bir yerleşim alır ve bu yerleşime dayalı yeni bir slayt ekler:

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

## **Slide Ana Taslaklarını Karşılaştırma**

Ana slaytlar, [BaseSlide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseslide/) sınıfından miras alınan `equals` yöntemiyle karşılaştırılabilir. Karşılaştırma, şekiller, metin, biçimlendirme, animasyonlar ve diğer slayt ayarları gibi yapı ve statik içeriği inceler. Slayt kimlikleri gibi benzersiz tanımlayıcıları veya geçerli tarih gibi dinamik yer tutucu değerlerini karşılaştırmaz.

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

## **Slide Ana Taslağı Görünümünü Varsayılan Görünüm Olarak Ayarlama**

Sunumun [ViewProperties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/viewproperties/) üzerindeki `last_view` özelliği, PowerPoint'in ilk açtığı görünümü kontrol eder. Aşağıdaki örnek, sunumu Slide Master görünümünde açar:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

Daha fazla görünüm ayarı için [Save Presentation](/slides/tr/python-net/save-presentation/) bölümüne bakın.

## **Kullanılmayan Ana Slaytları Kaldırma**

Sunumlar bazen hiçbir normal slayt tarafından kullanılmayan ana slaytlar içerebilir. Kullanılmayan ana slaytların kaldırılması dosya boyutunu azaltabilir ve şablon bakımını basitleştirebilir.

Kullanılmayan ana slaytları `masters` koleksiyonundan kaldırmak için `remove_unused` yöntemi kullanın:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

Ayrıca, [Compress](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/compress/) sınıfındaki düşük‑kodlu `remove_unused_master_slides` yöntemini de kullanabilirsiniz:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

### Slide ana taslağı ile yerleşim slaytı arasındaki fark nedir?

Slide ana taslağı tema, arka plan, ortak şekiller ve metin stilleri gibi ortak tasarım ayarlarını tanımlar. Yerleşim slaytı bir ana taslağa aittir ve yer tutucuların belirli bir düzenini tanımlar. Normal bir slayt bir yerleşim slaytı kullanır, bu yüzden hem yerleşimden hem de ana taslaktan devralır.

### Bir sunum birden fazla slide ana taslağı içerebilir mi?

Evet. Bir sunum birden fazla slide ana taslağı içerebilir. Farklı bölümlerin farklı görsel sistemler veya markalaşma ihtiyaçları olduğunda birden çok ana kullanın.

### Yer tutucuları ana slayta mı yoksa yerleşim slaytına mı eklemeliyim?

Çoğu durumda yer tutucuları yerleşim slaytlarına ekleyin. Ortak görsel öğeleri ve ortak biçimlendirmeyi ana slayta, içerik yer tutucularını ise normal slaytların kullanacağı yerleşimlere koyun.

### Hâlâ kullanılan bir ana slaytı silebilir miyim?

Hayır. Bağımlı slaytları olan bir ana slaytı doğrudan kaldırmak güvenli değildir. Önce bu slaytları başka bir ana altında yerleşimlere taşıyın veya yalnızca kullanılmayan ana slaytları temizleyen bir yöntem kullanın.