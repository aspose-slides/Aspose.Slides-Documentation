---
title: Python'da Slayt Düzenlerini Uygula veya Değiştir
linktitle: Slayt Düzeni
type: docs
weight: 60
url: /tr/python-net/slide-layout/
keywords:
- slayt düzeni
- içerik düzeni
- yer tutucu
- sunum tasarımı
- slayt tasarımı
- kullanılmayan düzen
- alt bilgi görünürlüğü
- başlık slaytı
- başlık ve içerik
- bölüm başlığı
- iki içerik
- karşılaştırma
- sadece başlık
- boş düzen
- altyazılı içerik
- altyazılı resim
- başlık ve dikey metin
- dikey başlık ve metin
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile slayt düzenlerini nasıl yöneteceğinizi ve özelleştireceğinizi öğrenin. Layout türlerini, yer tutucu kontrolünü, alt bilgi görünürlüğünü ve Python kod örnekleriyle düzen manipülasyonunu keşfedin."
---
## **Giriş**

Bir slayt düzeni, slayttaki içeriğin yer tutucu kutularının ve biçimlendirmesinin düzenini tanımlar. Hangi yer tutucuların mevcut olduğunu ve nerede görüneceklerini kontrol eder. Slayt düzenleri, basit ya da daha karmaşık bir şey oluştururken sunumları hızlı ve tutarlı bir şekilde tasarlamanıza yardımcı olur. PowerPoint'te en yaygın slayt düzenlerinden bazıları şunlardır:

**Başlık Slaytı düzeni** – Başlık ve alt başlık için iki metin yer tutucusu içerir.

**Başlık ve İçerik düzeni** – Üstte daha küçük bir başlık yer tutucusu ve altında metin, madde işaretleri, grafikler, resimler vb. ana içerik için daha büyük bir yer tutucu bulundurur.

**Boş düzen** – Yer tutucu bulunmaz; slaytı sıfırdan tasarlama konusunda tam kontrol sağlar.

Slayt düzenleri, sunumun stillerini tanımlayan en üst düzey slayt olan slayt ana sayfasının bir parçasıdır. Düzen slaytlarına, türüne, adına veya benzersiz kimliğine göre slayt ana sayfası üzerinden erişebilir ve bunları değiştirebilirsiniz. Alternatif olarak, belirli bir düzen slaytını doğrudan sunum içinde düzenleyebilirsiniz.

Aspose.Slides for Python'da slayt düzenleriyle çalışmak için şunları kullanabilirsiniz:

- [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfı altındaki [layout_slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/layout_slides/) ve [masters](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/masters/) gibi özellikler
- [LayoutSlide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutplaceholdermanager/) ve [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutslideheaderfootermanager/) gibi tipler

{{% alert title="Info" color="info" %}}
Ana slaytlarla çalışmayı öğrenmek için [Manage PowerPoint Slide Masters in Python](/slides/tr/python-net/slide-master/) makalesine göz atın.
{{% /alert %}}

## **Sunumalara Slayt Düzenleri Ekleme**

Slaytlarınızın görünümünü ve yapısını özelleştirmek için sunuma yeni düzen slaytları eklemeniz gerekebilir. Aspose.Slides for Python, belirli bir düzenin zaten var olup olmadığını kontrol etmenize, gerekirse yeni bir düzen eklemenize ve bu düzeni temel alarak slayt eklemenize olanak tanır.

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. [MasterLayoutSlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterlayoutslidecollection/) erişin.  
1. İstenen düzen slaytının koleksiyonda zaten olup olmadığını kontrol edin. Yoksa ihtiyacınız olan düzen slaytını ekleyin.  
1. Yeni düzen slaytına dayalı boş bir slayt ekleyin.  
1. Sunumu kaydedin.

Aşağıdaki Python kodu bir PowerPoint sunumuna slayt düzeni eklemeyi gösterir:

```python
import aspose.slides as slides

# Sunum dosyasını açmak için Presentation sınıfını örnekleyin.
with slides.Presentation("sample.pptx") as presentation:
    # Bir düzen slaytı seçmek için düzen slaytı türlerini dolaşın.
    layout_slides = presentation.masters[0].layout_slides
    layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)
    if layout_slide is None:
         layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE)

    if layout_slide is None:
        # Sunumun tüm düzen türlerini içermediği bir durum.
        # Sunum dosyası yalnızca Boş ve Özel düzen türlerini içerir.
        # Ancak, özel türlere sahip düzen slaytları tanınabilir isimlere sahip olabilir,
        # örneğin "Title", "Title and Content", vb., bu isimler düzen slaytı seçiminde kullanılabilir.
        # Ayrıca bir dizi yer tutucu şekil türüne dayanabilirsiniz.
        # Örneğin, bir Başlık slaytı yalnızca Başlık yer tutucu tipine sahip olmalıdır, vb.
        for title_and_object_layout_slide in layout_slides:
            if title_and_object_layout_slide.name == "Title and Object":
                layout_slide = title_and_object_layout_slide
                break

        if layout_slide is None:
            for title_layout_slide in layout_slides:
                if title_layout_slide.name == "Title":
                    layout_slide = title_layout_slide
                    break

            if layout_slide is None:
                layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
                if layout_slide is None:
                    layout_slide = layout_slides.Add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Title and Object")

    # Eklenen düzen slaytını kullanarak boş bir slayt ekleyin.
    presentation.slides.insert_empty_slide(0, layout_slide)

    # Sunumu diske kaydedin.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Kullanılmayan Düzen Slaytlarını Kaldırma**

Aspose.Slides, kullanılmayan ve istenmeyen düzen slaytlarını silmenize olanak tanıyan [Compress](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/compress/) sınıfındaki [remove_unused_layout_slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) yöntemini sağlar.

Aşağıdaki Python kodu bir PowerPoint sunumundan düzen slaytını kaldırmayı gösterir:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Slayt Düzenlerine Yer Tutucu Ekleme**

Aspose.Slides, bir düzen slaytına yeni yer tutucular eklemenizi sağlayan [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutslide/placeholder_manager/) özelliğini sunar.

Bu yönetici aşağıdaki yer tutucu türleri için yöntemler içerir:

| PowerPoint Yer Tutucu              | [LayoutPlaceholderManager](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutplaceholdermanager/) Yöntemi |
| ----------------------------------- | ------------------------------------------------------------ |
| ![İçerik](content.png)             | add_content_placeholder(x: float, y: float, width: float, height: float) |
| ![İçerik (Dikey)](contentV.png)    | add_vertical_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Metin](text.png)                 | add_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Metin (Dikey)](textV.png)        | add_vertical_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Resim](picture.png)              | add_picture_placeholder(x: float, y: float, width: float, height: float) |
| ![Grafik](chart.png)               | add_chart_placeholder(x: float, y: float, width: float, height: float) |
| ![Tablo](table.png)                | add_table_placeholder(x: float, y: float, width: float, height: float) |
| ![SmartArt](smartart.png)          | add_smart_art_placeholder(x: float, y: float, width: float, height: float) |
| ![Medya](media.png)                | add_media_placeholder(x: float, y: float, width: float, height: float) |
| ![Çevrimiçi Görüntü](onlineimage.png) | add_online_image_placeholder(x: float, y: float, width: float, height: float) |

Aşağıdaki Python kodu Boş düzen slaytına yeni yer tutucu şekilleri eklemeyi gösterir:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Boş düzen slaydını alın.
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # Düzen slaydının yer tutucu yöneticisini alın.
    placeholder_manager = layout.placeholder_manager

    # Boş düzen slaydına farklı yer tutucular ekleyin.
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    # Boş düzenle yeni bir slayt ekleyin.
    new_slide = presentation.slides.add_empty_slide(layout)

    presentation.save("placeholders.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Yer tutucular yerleşim slaytında](add_placeholders.png)

## **Bir Düzen Slaytı İçin Alt Bilgi Görünürlüğünü Ayarlama**

PowerPoint sunumlarında tarih, slayt numarası ve özelleştirilmiş metin gibi alt bilgi öğeleri slayt düzenine göre gösterilebilir veya gizlenebilir. Aspose.Slides for Python, bu alt bilgi yer tutucularının görünürlüğünü kontrol etmenizi sağlar. Bu özellik, belirli düzenlerin alt bilgi bilgilerini göstermesini, diğerlerinin ise temiz kalmasını istediğinizde kullanışlıdır.

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre bir düzen slaytı referansı alın.  
1. Slayt alt bilgi yer tutucusunu görünür yapın.  
1. Slayt numarası yer tutucusunu görünür yapın.  
1. Tarih‑zaman yer tutucusunu görünür yapın.  
1. Sunumu kaydedin.

Aşağıdaki Python kodu bir slayt alt bilgisinin görünürlüğünü ayarlamayı ve ilgili görevleri göstermektedir:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    header_footer_manager = presentation.layout_slides[0].header_footer_manager

    if not header_footer_manager.is_footer_visible: 
        header_footer_manager.set_footer_visibility(True) 

    if not header_footer_manager.is_slide_number_visible:  
        header_footer_manager.set_slide_number_visibility(True) 

    if not header_footer_manager.is_date_time_visible: 
        header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_footer_text("Footer text") 
    header_footer_manager.set_date_time_text("Date and time text") 

    presentation.save("output.ppt", slides.export.SaveFormat.PPT)
```

## **Bir Slayt İçin Çocuk Alt Bilgi Görünürlüğünü Ayarlama**

PowerPoint sunumlarında tarih, slayt numarası ve özelleştirilmiş metin gibi alt bilgi öğeleri, tüm düzen slaytları arasında tutarlılığı sağlamak için ana slayt düzeyinde kontrol edilebilir. Aspose.Slides for Python, bu alt bilgi yer tutucularının görünürlüğünü ve içeriğini ana slaytta ayarlamanıza ve bu ayarları tüm alt düzen slaytlarına yaymanıza izin verir. Bu yaklaşım, sunumunuz boyunca tutarlı alt bilgi bilgileri sağlar.

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre ana slayta bir referans alın.  
1. Ana slaytın ve tüm alt slaytların alt bilgi yer tutucularını görünür yapın.  
1. Ana slaytın ve tüm alt slaytların slayt numarası yer tutucularını görünür yapın.  
1. Ana slaytın ve tüm alt slaytların tarih‑zaman yer tutucularını görünür yapın.  
1. Sunumu kaydedin.

Aşağıdaki Python kodu bu işlemi göstermektedir:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager

    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)

    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Bir ana slayt ile bir düzen slaytı arasındaki fark nedir?**

Ana slayt, genel temayı ve varsayılan biçimlendirmeyi tanımlarken, düzen slaytları farklı içerik tipleri için yer tutucuların belirli düzenlemelerini tanımlar.

**Bir düzen slaytını bir sunumdan diğerine kopyalayabilir miyim?**

Evet, bir sunumun [layout_slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/layout_slides/) koleksiyonundan bir düzen slaytını klonlayabilir ve `add_clone` yöntemiyle başka birine ekleyebilirsiniz.

**Bir düzen slaytı hâlâ bir slayt tarafından kullanılıyorken silerseniz ne olur?**

Bir düzen slaytı, sunumda en az bir slayt tarafından hâlâ referans alınıyorsa silmeye çalıştığınızda Aspose.Slides bir [PptxEditException](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pptxeditexception/) fırlatır. Bunu önlemek için, yalnızca kullanılmayan düzen slaytlarını güvenle kaldıran [remove_unused_layout_slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) yöntemini kullanın.