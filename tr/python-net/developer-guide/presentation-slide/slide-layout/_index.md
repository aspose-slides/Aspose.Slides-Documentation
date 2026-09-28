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
- altbilgi görünürlüğü
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
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET içinde slayt düzenlerini uygula, oluştur ve değiştir, yer tutucuları ekle, kullanılmayan düzenleri kaldır ve altbilgi görünürlüğünü kontrol et."
---
## **Genel Bakış**

Bir slayt düzeni, başlıklar, metin, resimler, grafikler ve tablolar gibi yer tutucuların konumlarını ve biçimlendirmesini tanımlar. Bir düzenin uygulanması, slaytlara tutarlı bir yapı kazandırır ve her slaytın kendi içeriğini barındırmasına izin verir.

En yaygın düzenler şunlardır:

- **Başlık Slaytı**: Başlık ve alt başlık yer tutucularını içerir.
- **Başlık ve İçerik**: Bir başlık yer tutucu ve genel amaçlı bir içerik yer tutucusunu içerir.
- **Boş**: İçerik yer tutucusu içermez ve her şeklin manuel olarak konumlandırılacağı durumlarda kullanışlıdır.

## **Düzen Kalıtımını Anlayın**

Bir sunum üç ilgili seviyeye sahiptir:

1. A [ana slayt](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslide/) tema, ortak biçimlendirme, arka planlar ve ortak nesneleri tanımlar.
2. A [düzen slaytı](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutslide/) bir ana slayta aittir ve yer tutucuların belirli bir düzenini tanımlar.
3. A [normal slayt](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/) bir düzen kullanır ve o slayt için girilen içeriği depolar.

Bir normal slayt, düzeninden tema ve biçimlendirmeyi miras alır ve düzen, ana slayttan miras alır. Normal slayta doğrudan ayarlanan bir değer, o seviyedeki miras alınan değeri geçersiz kılar. Normal bir slayt oluşturulduğunda, yer tutucu şekilleri seçilen düzen üzerinden üretilir; bu yer tutuculara girilen içerik ise normal slayta aittir.

Bir düzenden slayt oluşturmadan önce gerekli yer tutucuları ekleyin. Daha sonra aynı düzene başka bir yer tutucu eklemek, mevcut normal slaytlara otomatik olarak ilgili yer tutucu şekli eklemez.

Bu ilişkinin iki önemli sonucu vardır:

- Bir düzen üzerindeki kalıtılmış biçimlendirmeyi veya mevcut yer tutucu geometrisini değiştirmek, ona bağımlı tüm slaytları güncelleyebilir. Zaten kullanılan bir düzeni düzenlemeden önce, bağlı slaytlarını inceleyin ve ortaya çıkan sunumu gözden geçirin.
- Bir slayt tarafından hâlâ kullanılan bir düzen kaldırılamaz. Önce bağımlı slaytlarını başka bir düzene atayın veya yalnızca kullanılmayan düzenleri kaldırın.

Bu hiyerarşinin üst seviyesi hakkında daha fazla bilgi için [Slayt Ana](/slides/tr/python-net/slide-master/) bölümüne bakın.

Bir slaytta veya ortak bir düzen aracılığıyla kalıtılmış logoları veya dekoratif ana şekilleri gizlemek için, [Ana Grafiklerin Görünürlüğünü Kontrol Et](/slides/tr/python-net/slide-master/) bölümüne bakın. Örnek, aynı ana slaytı kullanan iki slaytı karşılaştırır.

## **Slayt Düzeni Seç ve Uygula**

Sunum standart PowerPoint düzen tanımlarını izlediğinde bir düzen türü kullanın. Düzen adları kullanıcı tarafından düzenlenebilir ve yerelleştirilebilir, bu yüzden kaynak şablonu kontrol etmiyorsanız isim tabanlı seçim daha az güvenilirdir.

Aşağıdaki örnek, ilk ana slaytta **Başlık ve İçerik** düzenini arar. Bu düzen bulunamazsa, kasıtlı olarak **Boş** düzenine geçer. İkinci null kontrolü, bir sunumun yalnızca özel düzenler içerebileceği durumlarda gereklidir. Seçilen düzen, ardından [Slide.layout_slide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/layout_slide/) özelliği aracılığıyla ilk normal slayta uygulanır.

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

Bir slaytın düzenini değiştirmek, slayta doğrudan eklenen sıradan şekilleri kaldırmaz. Ancak yer tutucu konumları, kalıtılmış biçimlendirme ve mevcut yer tutucular ile yeni düzen arasındaki eşleşme değişebilir; bu yüzden farklı düzenler arasında geçiş yaparken çıktıyı inceleyin.

## **Bir Düzen Slaytı Ekle**

Seçim ve oluşturma ayrı işlemlerdir. Önceki örnek mevcut bir düzeni seçer; bir tane oluşturmaz. Bir düzen oluşturmak için hedef ana slaydın düzen koleksiyonunda [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterlayoutslidecollection/add/) metodunu çağırın.

Aşağıdaki örnek her zaman **Başlık ve İçerik** adlı `Report Title and Content` adlı yeni bir düzen ekler, ardından bu düzene dayalı bir normal slayt ekler. Düzen adları koleksiyon içinde benzersiz olmalıdır.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

Şablon gerçekten başka bir yeniden kullanılabilir yapıya ihtiyacı olduğunda bir düzen ekleyin. Uygun bir düzen zaten varsa, kopya oluşturmak yerine onu seçip tekrar kullanın.

## **Bir Düzen Slaytına Yer Tutucular Ekle**

[LayoutSlide.placeholder_manager] özelliği, bir düzene yer tutucu şekilleri eklemek için bir [LayoutPlaceholderManager] sağlar.

| PowerPoint Yer Tutucu | `LayoutPlaceholderManager` Yöntemi |
| --------------------- | ---------------------------------- |
| ![İçerik](content.png) | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![İçerik (Dikey)](contentV.png) | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![Metin](text.png) | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![Metin (Dikey)](textV.png) | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![Resim](picture.png) | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![Grafik](chart.png) | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![Tablo](table.png) | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png) | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![Medya](media.png) | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![Çevrimiçi Resim](onlineImage.png) | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

Aşağıdaki örnek, **Boş** düzeninin varlığını doğrular, ona dört yer tutucu ekler ve ardından değiştirilmiş düzeni kullanan bir normal slayt oluşturur. Sıranın kasıtlı olması gerekir: yer tutucular normal slayt oluşturulmadan önce eklenir, böylece Aspose.Slides o slaytta ilgili yer tutucu şekillerini üretebilir.

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

![Düzen slaydındaki yer tutucular](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Kalıtılmış biçimlendirmeyi veya mevcut düzen yer tutucularının geometrisini değiştirmek, bağlı slaytları etkileyebilir. Yeni eklenen bir düzen yer tutucusu, mevcut normal slaytlara otomatik olarak eklenmez. Düzen değişikliklerini sunumun bir kopyasında test edin ve her bağlı slaytı inceleyin.
{{% /alert %}}

## **Kullanılmayan Düzen Slaytlarını Kaldır**

[Compress.remove_unused_layout_slides] metodunu kullanarak hiçbir normal slayt tarafından referans edilmeyen düzenleri kaldırın. Metod, hâlâ kullanılan düzenleri olduğu gibi bırakır.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

Belirli bir düzeni kaldırmak için önce onun [has_depending_slides] özelliğini veya [get_depending_slides] metodunu kullanın. Bağlı slaytları başka bir düzene atadıktan sonra [LayoutSlide.remove]() metodunu çağırın. Kullanılan bir düzeni kaldırmaya çalışmak bir [PptxEditException]() hatasına neden olur.

## **Düzen Slaytında Altbilgi Görünürlüğünü Kontrol Et**

Bir düzenin kendi altbilgi, slayt numarası ve tarih‑saat yer tutucuları vardır. Bu yer tutucuları tek bir düzen için kontrol etmek üzere [LayoutSlide.header_footer_manager] özelliğini kullanın. Bu, örneğin içerik düzenlerinin altbilgi göstermesi, başlık düzenlerinin göstermemesi gerektiği durumlarda faydalıdır.

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

## **Ana Slayt ve Çocuk Düzenlerde Altbilgi Görünürlüğünü Kontrol Et**

Bir ana slayt hiyerarşisi boyunca tutarlı altbilgi ayarları uygulamak için [MasterSlide.header_footer_manager] özelliğini kullanın. [MasterSlideHeaderFooterManager] sınıfının yayılım metodları, ana slayt ve ona bağlı düzen slaytları ile normal slaytlar üzerinde çalışır; yalnızca tek bir normal slaytı hedeflemez.

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

**Ana Slayt ile Düzen Slaytı Arasındaki Fark Nedir?**

Ana slayt, sunumun temasını ve ortak biçimlendirmesini tanımlar. Düzen slaytı bir ana slayta aittir ve yer tutucuların yeniden kullanılabilir bir düzenini tanımlar. Normal slaytlar bu düzenleri kullanır ve slayta özgü içeriği depolar.

**Bir Düzen Slaytını Bir Sunumdan Başkasına Kopyalayabilir miyim?**

Evet. Hedef koleksiyona bir kopya eklemek için [add_clone] metodunu kullanın. Sunumlar arasında kopyalama yaparken, kaynak düzenin kullandığı yazı tiplerini, temaları, resimleri ve diğer kaynakları da doğrulayın.

**Zaten Kullanımda Olan Bir Düzeni Değiştirdiğimde Ne Olur?**

Bağlı slaytlar, yerel olarak etkilenmiş biçimlendirmeyi veya nesneleri geçersiz kılmadıkları sürece düzen değişikliklerini miras alır. Yer tutucu geometrisi ve kalıtılmış stil birçok slaytta aynı anda değişebilir. Düzeni düzenlemeden önce etkilenebilecek slaytları belirlemek için [get_depending_slides] metodunu kullanın.

**Hâlâ Kullanımda Olan Bir Düzeni Kaldırırsam Ne Olur?**

Aspose.Slides bir [PptxEditException] hatası üretir. Önce bağlı slaytları başka bir düzene atayın veya yalnızca referans edilmeyen düzenleri kaldırmak için [remove_unused_layout_slides] metodunu kullanın.