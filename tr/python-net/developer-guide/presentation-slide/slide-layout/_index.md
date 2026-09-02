---
title: Python'da Slayt Düzenlerini Uygulama veya Değiştirme
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
- yalnızca başlık
- boş düzen
- başlıklı içerik
- başlıklı resim
- başlık ve dikey metin
- dikey başlık ve metin
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile slayt düzenlerini uygulayın, oluşturun ve değiştirin, yer tutucular ekleyin, kullanılmayan düzenleri kaldırın ve alt bilgi görünürlüğünü kontrol edin."
---
## **Genel Bakış**

Bir slayt düzeni, başlıklar, metin, resimler, grafikler ve tablolar gibi yer tutucuların konumlarını ve biçimlendirmesini tanımlar. Bir düzen uygulandığında slaytlara tutarlı bir yapı kazandırılır ve her slayt kendi içeriğini barındırabilir.

En yaygın düzenler şunlardır:

- **Başlık Slaytı**: Başlık ve alt başlık yer tutucularını içerir.
- **Başlık ve İçerik**: Bir başlık yer tutucusu ve genel amaçlı bir içerik yer tutucusu içerir.
- **Boş**: İçerik yer tutucusu bulunmaz ve her şeklin manuel olarak konumlandırılacağı durumlarda kullanışlıdır.

## **Düzen Kalıtımını Anlamak**

Bir sunum üç ilişkili seviyeye sahiptir:

1. Bir [master slayt](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslide/) temayı, ortak biçimlendirmeyi, arka planları ve ortak nesneleri tanımlar.
1. Bir [düzen slayt](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutslide/) bir master’a aittir ve belirli bir yer tutucu düzenini tanımlar.
1. Bir [normal slayt](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/) bir düzeni kullanır ve o slayt için girilen içeriği depolar.

Bir normal slayt temayı ve biçimlendirmeyi düzeninden kalıtır, düzen ise master’dan kalıtır. Normal bir slaytta doğrudan ayarlanan bir değer, o seviyedeki kalıtılan değeri geçersiz kılar. Bir normal slayt oluşturulduğunda, seçilen düzenten yer tutucu şekilleri oluşturulur; bu yer tutuculara girilen içerik ise normal slayta aittir.

Kaydırılardan slayt oluşturulmadan önce bir düzene gerekli yer tutucular eklenmelidir. Daha sonra bir düzene yeni bir yer tutucu eklemek, mevcut normal slaytlara otomatik olarak bir yer tutucu şekli eklemez.

Bu ilişkinin iki önemli sonucu vardır:

- Bir düzen üzerindeki kalıtılan biçimlendirmeyi veya mevcut yer tutucu geometrisini değiştirmek, ona bağlı olan tüm slaytları güncelleyebilir. Kullanımda olan bir düzeni düzenlemeden önce, bağımlı slaytlarını inceleyin ve ortaya çıkan sunumu gözden geçirin.
- Bir slayt hâlâ bir düzeni kullanıyorsa o düzen kaldırılamaz. Önce bağımlı slaytlarını başka bir düzene atayın veya yalnızca kullanılmayan düzenleri kaldırın.

Bu hiyerarşinin üst düzeyi hakkında daha fazla bilgi için [Slide Master](/slides/tr/python-net/slide-master/) sayfasına bakın.

## **Bir Slayt Düzeni Seçme ve Uygulama**

Sunum standart PowerPoint düzen tanımlarını izliyorsa bir düzen türü kullanın. Düzen adları kullanıcı tarafından düzenlenebilir ve yerelleştirilebilir, bu nedenle ad temelli seçim, kaynak şablon üzerindeki kontrolünüz yoksa daha az güvenilirdir.

Aşağıdaki örnek, ilk master’da **Başlık ve İçerik** düzenini arar. Bu düzen bulunamazsa kasıtlı olarak **Boş** düzenine geri döner. İkinci null kontrolü, bir sunumun yalnızca özel düzenler içerebileceği durumlar için gereklidir. Seçilen düzen daha sonra ilk normal slayta [Slide.layout_slide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/layout_slide/) özelliğiyle uygulanır.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slides = presentation.masters[0].layout_slides
    target_layout = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if target_layout is None:
        target_layout = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if target_layout is None:
        raise RuntimeError("The first master does not contain a suitable layout slide.")

    presentation.slides[0].layout_slide = target_layout
    presentation.save("output-with-new-layout.pptx", slides.export.SaveFormat.PPTX)
```

Bir slaytın düzenini değiştirmek, doğrudan slayta eklenen sıradan şekilleri kaldırmaz. Ancak yer tutucu konumları, kalıtılan biçimlendirme ve mevcut yer tutucular ile yeni düzen arasındaki eşleşme değişebilir; bu nedenle çok farklı düzenler arasında geçiş yaparken çıktıyı inceleyin.

## **Bir Düzen Slaytı Ekleme**

Seçim ve oluşturma ayrı işlemlerdir. Önceki örnek mevcut bir düzeni seçer; bir tane oluşturmaz. Bir düzen oluşturmak için hedef master’ın düzen koleksiyonunda [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterlayoutslidecollection/add/) yöntemini çağırın.

Aşağıdaki örnek her zaman `Rapor Başlığı ve İçeriği` adında yeni bir **Başlık ve İçerik** düzeni ekler, ardından ona dayalı bir normal slayt ekler. Düzen adları koleksiyon içinde benzersiz olmalıdır.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

Bir şablon gerçekten başka bir yeniden kullanılabilir yapıya ihtiyaç duyduğunda bir düzen ekleyin. Uygun bir düzen zaten varsa, bir kopya oluşturmaktansa onu seçip yeniden kullanın.

## **Bir Düzen Slaytına Yer Tutucular Ekleme**

[LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutslide/placeholder_manager/) özelliği, bir düzene yer tutucu şekilleri eklemek için bir [LayoutPlaceholderManager](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutplaceholdermanager/) sunar.

| PowerPoint Yer Tutucu               | `LayoutPlaceholderManager` Metodu |
| ----------------------------------- | --------------------------------- |
| ![İçerik](content.png)              | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![İçerik (Dikey)](contentV.png)    | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![Metin](text.png)                  | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![Metin (Dikey)](textV.png)        | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![Resim](picture.png)               | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![Grafik](chart.png)                | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![Tablo](table.png)                 | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png)           | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![Medya](media.png)                 | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![Çevrimiçi Görüntü](onlineImage.png) | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

Aşağıdaki örnek, **Boş** düzeninin var olduğunu doğrular, ona dört yer tutucu ekler ve ardından değiştirilmiş düzeni kullanan bir normal slayt oluşturur. Sıra kasıtlıdır: yer tutucular normal slayt oluşturulmadan önce eklenir, böylece Aspose.Slides o slaytta karşılık gelen yer tutucu şekillerini üretebilir.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout is None:
        raise RuntimeError("The presentation does not contain a Blank layout slide.")

    placeholder_manager = blank_layout.placeholder_manager
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    presentation.slides.add_empty_slide(blank_layout)
    presentation.save("output-with-placeholders.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Düzen slaytındaki yer tutucular](add_placeholders.png)

{{% alert color="warning" title="Uyarı" %}}

Kalıtılan biçimlendirmeyi veya mevcut düzen yer tutucularının geometrisini değiştirmek, bağımlı slaytları etkileyebilir. Yeni eklenen bir düzen yer tutucusu mevcut normal slaytlara otomatik olarak eklenmez. Düzen değişikliklerini bir sunum kopyası üzerinde test edin ve her bağımlı slaytı inceleyin.

{{% /alert %}}

## **Kullanılmayan Düzen Slaytlarını Kaldırma**

[Kullanılmayan düzen slaytlarını kaldır](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) yöntemi, hiçbir normal slayt tarafından referans edilmeyen düzenleri siler. Yöntem, hâlâ kullanılan düzenleri aynı bırakır.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

Belirli bir düzeni kaldırmak için önce onun [has_depending_slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutslide/has_depending_slides/) özelliğini veya [get_depending_slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutslide/get_depending_slides/) yöntemini kullanın. Bağımlı slaytları yeniden atadıktan sonra [LayoutSlide.remove](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutslide/remove/) metodunu çağırın. Kullanılan bir düzeni kaldırmaya çalışmak bir [PptxEditException](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pptxeditexception/) hatası oluşturur.

## **Bir Düzen Slaytında Alt Bilgi Görünürlüğünü Kontrol Etme**

Bir düzenin kendi alt bilgi, slayt numarası ve tarih‑saat yer tutucuları vardır. Bu yer tutucuları tek bir düzen için kontrol etmek üzere [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutslide/header_footer_manager/) özelliğini kullanın. Örneğin, içerik düzenlerinin alt bilgi göstermesi, başlık düzenlerinin göstermemesi gerektiğinde bu yararlıdır.

Aşağıdaki örnek bir düzeni güvenli bir şekilde seçer ve alt bilgi öğelerini görünür kılar:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if layout_slide is None:
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if layout_slide is None:
        raise RuntimeError("The presentation does not contain a suitable layout slide.")

    header_footer_manager = layout_slide.header_footer_manager
    header_footer_manager.set_footer_visibility(True)
    header_footer_manager.set_slide_number_visibility(True)
    header_footer_manager.set_date_time_visibility(True)
    header_footer_manager.set_footer_text("Footer text")
    header_footer_manager.set_date_time_text("Date and time text")

    presentation.save("output-with-layout-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **Bir Master ve Alt Düzenlerinde Alt Bilgi Görünürlüğünü Kontrol Etme**

Tutarlı alt bilgi ayarlarını bir master hiyerarşisi boyunca uygulamak için [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslide/header_footer_manager/) özelliğini kullanın. [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslideheaderfootermanager/) sınıfının yayılım yöntemleri master, ona bağlı düzen slaytları ve normal slaytlar üzerinde çalışır; yalnızca tek bir normal slaytı hedeflemez.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager
    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)
    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output-with-master-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Master Slayt ile Düzen Slaytı Arasındaki Fark Nedir?**

Bir master slayt, sunumun temasını ve ortak biçimlendirmesini tanımlar. Bir düzen slaytı bir master’a aittir ve yeniden kullanılabilir bir yer tutucu düzeni tanımlar. Normal slaytlar bu düzenleri kullanır ve slayta özgü içeriği saklar.

**Bir Düzen Slaytını Bir Sunumdan Başka Bir Sunuma Kopyalayabilir miyim?**

Evet. Hedef koleksiyona bir kopya eklemek için [add_clone](https://reference.aspose.com/slides/tr/python-net/aspose.slides/globallayoutslidecollection/add_clone/) yöntemini kullanın. Sunumlar arasında kopyalama yaparken, kaynak düzenin kullandığı yazı tiplerini, temaları, görüntüleri ve diğer kaynakları da doğrulayın.

**Kullanımda Olan Bir Düzeni Değiştirirsem Ne Olur?**

Bağımlı slaytlar, yerel olarak etkilenmiş biçimlendirme veya nesneleri geçersiz kılmadıkları sürece düzen değişikliklerini kalıtır. Yer tutucu geometrisi ve kalıtılan stil, bir anda birçok slaytta değişebilir. Düzeni düzenlemeden önce etkilenen slaytları belirlemek için [get_depending_slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutslide/get_depending_slides/) yöntemini kullanın.

**Hâlâ Kullanımda Olan Bir Düzeni Kaldırırsam Ne Olur?**

Aspose.Slides bir [PptxEditException](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pptxeditexception/) hatası fırlatır. Önce bağımlı slaytları yeniden atayın veya yalnızca referans edilmeyen düzenleri kaldırmak için [remove_unused_layout_slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) yöntemini kullanın.