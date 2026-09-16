---
title: Python'da Sunum Köprülerini Yönetme
linktitle: Köprüleri Yönet
type: docs
weight: 20
url: /tr/python-net/manage-hyperlinks/
keywords:
- URL ekle
- köprü ekle
- köprü oluştur
- köprüyü biçimlendir
- köprüyü kaldır
- köprüyü güncelle
- metin köprüsü
- slayt köprüsü
- şekil köprüsü
- resim köprüsü
- video köprüsü
- değiştirilebilir köprü
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak, Python örnekleriyle PowerPoint ve OpenDocument sunumlarında köprüleri ekleyin, biçimlendirin, güncelleyin ve kaldırın."
---
## **Giriş**

Bir köprü, sunum içeriğini bir web sitesine veya sunum içinde bir konuma bağlar. PowerPoint'te köprüler genellikle iki amaçla kullanılır:

* Metin, şekil veya medya çerçevesinden bir web sitesini açmak.
* Örneğin, bir içerik tablosundan başka bir slayta geçiş yapmak.

Aspose.Slides for Python via .NET, bu bağlantıları eklemenize, görünümünü ve sesini kontrol etmenize, özelliklerini güncellemenize ve kaldırmanıza olanak sağlar. Aşağıdaki örnekler, tek tek öğeler üzerindeki köprülerle nasıl çalışılacağını ve sunum, slayt veya metin‑çerçevesi düzeyinde köprülere nasıl erişileceğini gösterir.

{{% alert color="info" title="Not" %}}
Ayrıca sunumları [ücretsiz çevrimiçi Aspose PowerPoint düzenleyicisi](https://products.aspose.app/slides/tr/editor) ile düzenleyebilirsiniz.
{{% /alert %}}

## **URL Köprüleri Ekleme**

Bir web sitesi URL'sini metne, şekle veya medya çerçevesine atayabilirsiniz. Köprüyü atadığınız öğe, tıklanabilir alanı belirler: bir metin bölümü seçili metni, bir şekil veya çerçeve ise slayt nesnesini bağlar.

### **Metne URL Köprüsü Ekleme**

Metni bir web sitesine bağlamak için, metin bölümünün [hyperlink_click](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portionformat/hyperlink_click/) özelliğine bir [Köprü](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlink/) atayın. Aşağıda gösterildiği gibi yalnızca o metin bölümü tıklanabilir olur.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    text_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    text_shape.add_text_frame("Aspose: File Format APIs")
    portion_format = text_shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    portion_format.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    portion_format.font_height = 32
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

### **Şekillere ve Medya Çerçevelerine URL Köprüsü Ekleme**

Bir şekil veya çerçeveyi tıklanabilir yapmak için, onun [hyperlink_click](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/hyperlink_click/) özelliğini ayarlayın. Köprü, nesnenin kendisine aittir; içinde bulunan bir metin bölümüne değil.

Aynı yaklaşım resim, ses ve video çerçevelerine de uygulanır: köprüyü çerçeveye atayın ve gerekirse bağlantının [tooltip](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlink/tooltip/) özelliğini ayarlayın.

Aşağıdaki örnek bir dikdörtgeni tıklanabilir hâle getirir:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **Köprüleri Kullanarak İçindekiler Tablosu Oluşturma**

Dahili köprüler, okuyucuların içindekiler tablosundan belirli bir slayta atlamasını sağlar. Aşağıdaki örnek, ilk slaydın “Sayfa 2” metnini ikinci slayta bağlamak için [set_internal_hyperlink_click](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/) metodunu kullanır.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    table_of_contents = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    table_of_contents.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.text_frame.paragraphs.clear()
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "
    link_portion = slides.Portion()
    link_portion.text = "Page 2"
    link_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)
    paragraph.portions.add(link_portion)
    table_of_contents.text_frame.paragraphs.add(paragraph)
    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **Köprüleri Biçimlendirme**

### **Renk**

[Hyperlink](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlink/) nesnesinin [color_source](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlink/color_source/) özelliği, köprünün sunumun köprü rengine mi yoksa metin bölümünün biçimlendirmesine mi göre renginin belirleneceğini tanımlar. Özel bir metin rengi uygulamak için [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlinkcolorsource/) seçilir ve bölümün dolgu rengi ayarlanır. Bu özellik PowerPoint 2019’da tanıtıldı; eski sürümler bu ayarı uygulamaz.

Aşağıdaki örnek aynı slayta iki metin köprüsü ekler. İlkinde kırmızı bir metin dolgusu kullanılır, ikincisi ise varsayılan köprü rengini korur.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    colored_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 450, 50, False)
    colored_shape.add_text_frame("This hyperlink uses a custom color.")
    colored_portion_format = colored_shape.text_frame.paragraphs[0].portions[0].portion_format
    colored_portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    colored_portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    colored_portion_format.fill_format.fill_type = slides.FillType.SOLID
    colored_portion_format.fill_format.solid_fill_color.color = draw.Color.red
    default_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    default_shape.add_text_frame("This hyperlink uses the default color.")
    default_shape.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    presentation.save("presentation-out-hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

### **Ses**

Bir köprü, etkinleştirildiğinde bir ses çalabilir veya hâlihazırda çalan bir sesi durdurabilir. Bu davranışları yapılandırmak için aşağıdaki özellikleri kullanın:

- [Hyperlink.sound](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlink/sound/) köprüye ilişkilendirilen ses dosyasını belirtir.
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlink/stop_sound_on_click/) köprünün etkinleştirilmesinin önceki sesi durdurup durdurmayacağını kontrol eder.

#### **Köprülü Ses Ekleme**

Aşağıdaki örnek `sampleaudio.wav` dosyasını yükler ve ilk slayttaki bir düğmeye ilişkilendirir. Düğmeye tıklandığında ses çalar ve bir sonraki slayta geçiş yapılır. Aynı slayttaki ikinci bir şekil, tıklandığında önceki sesi durdurur; bir geçiş eylemi gerçekleştirmez.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("sampleaudio.wav", "rb") as audio_file:
        audio_data = audio_file.read()
    hyperlink_sound = presentation.audios.add_audio(audio_data)
    first_slide = presentation.slides[0]
    play_button = first_slide.shapes.add_auto_shape(slides.ShapeType.SOUND_BUTTON, 100, 100, 100, 50)
    play_button.hyperlink_click = slides.Hyperlink.next_slide
    if not play_button.hyperlink_click.stop_sound_on_click and play_button.hyperlink_click.sound is None:
        play_button.hyperlink_click.sound = hyperlink_sound

    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    stop_button = second_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 100, 50)
    stop_button.hyperlink_click = slides.Hyperlink.no_action
    stop_button.hyperlink_click.stop_sound_on_click = True
    presentation.save("hyperlink-sound.pptx", slides.export.SaveFormat.PPTX)
```

#### **Köprü Sesini Çıkarma**

Aşağıdaki örnek, yukarıda oluşturulan sunumu açar ve ilk şeklin köprü sesini [sound](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlink/sound/) ve [binary_data](https://reference.aspose.com/slides/tr/python-net/aspose.slides/audio/binary_data/) aracılığıyla belleğe okur.

```python
import aspose.slides as slides

with slides.Presentation("hyperlink-sound.pptx") as presentation:
    if len(presentation.slides) > 0 and len(presentation.slides[0].shapes) > 0:
        hyperlink = presentation.slides[0].shapes[0].hyperlink_click
        sound = hyperlink.sound if hyperlink is not None else None
        if sound is not None:
            audio_data = sound.binary_data
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
```

### **İpucu ve Etkileşim Ayarları**

Bir köprüyü metne veya şekle atadıktan sonra aşağıdaki [Hyperlink](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlink/) özelliklerini güncelleyebilirsiniz:

- [tooltip](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlink/tooltip/) izleyicinin bağlantı için ipucu olarak gösterebileceği metni belirler.
- [target_frame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlink/target_frame/) geçerli olduğunda, bir üst HTML çerçeve kümesindeki hedef çerçeveyi belirtir.
- [history](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlink/history/) bağlantının etkinleştirilmesinin hedefini görüntülenen köprüler listesine ekleyip eklemeyeceğini kontrol eder.
- [highlight_click](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlink/highlight_click/) bağlantının tıklandığında vurgulanıp vurgulanmayacağını belirler.

## **Sunumlardan Köprüleri Kaldırma**

Köprü kapsayıcılarını (metin‑parça bağlantıları dahil) toplamak için [get_any_hyperlinks](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) yöntemini kullanın; ardından bunları değiştirin. Aşağıdaki örnek, ilk slayttan her iki etkinleştirme türünü de kaldırır. Yalnızca bir türü kaldırmak isterseniz, yalnızca [remove_hyperlink_click](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) veya [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/) yöntemini çağırın; bir tıklama eylemini kaldırmak, fare‑üzerinde eylemi kaldırmaz.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    if len(presentation.slides) > 0:
        containers = list(presentation.slides[0].hyperlink_queries.get_any_hyperlinks())
        for container in containers:
            container.hyperlink_manager.remove_hyperlink_click()
            container.hyperlink_manager.remove_hyperlink_mouse_over()
        presentation.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The presentation has no slides to process.")
```

Koşulsuz kaldırma için, [remove_all_hyperlinks](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) seçilen kapsam içinde her iki etkinleştirme türünü tek bir çağrıyla siler. Ustalar, düzenler ve notlar dahil olmak üzere seçici temizlik ve kapsamlı kapsama için **[Raporla, Temizle ve Köprüleri Doğrula](#report-sanitize-and-verify-hyperlinks)** bölümüne bakın.

## **Tam Bir Köprü Envanteri Oluşturma**

Bir sunumu dağıtmadan önce, etkileşimli eylemlerini ve web bağlantılarını envantere alın. [get_any_hyperlinks](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) yöntemi, URL dizesi listesi yerine [IHyperlinkContainer](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ihyperlinkcontainer/) nesnelerini döndürür. Her kapsayıcıda hem [hyperlink_click](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) hem de [hyperlink_mouse_over](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) incelenmelidir. Bunlar bağımsızdır; aynı kapsayıcı iki eylemi de sunabilir, bu yüzden tam bir rapor her kapsayıcı için iki satır gerektirebilir.

Yalnızca şekil‑seviyesindeki köprüleri taramak, metin bölümlerine eklenmiş bağlantıları kaçırabilir. Bunun yerine uygun kapsamı sorgulayın ve döndürülen kapsayıcıları saklayarak daha sonra eylemlerini güncelleyebilir veya kaldırabilirsiniz.

### **Sunum, Slayt ve Metin‑Çerçeve Kapsamlarını Sorgulama**

[HyperlinkQueries](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlinkqueries/) sınıfına, [Presentation.hyperlink_queries](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/hyperlink_queries/), [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseslide/hyperlink_queries/) ve [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/hyperlink_queries/) üzerinden erişilir. Her kapsam aynı sorguları destekler:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) tıklama eylemi içeren kapsayıcıları döndürür.
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) fare‑üzerinde eylemi olan kapsayıcıları döndürür.
- [get_any_hyperlinks](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) bir veya iki eylemi içeren kapsayıcıları döndürür.

Aşağıdaki örnek, dış bağlantılı bir tıklama, dosya fare‑üzerinde bağlantısı, dahili slayt navigasyonu, metin fare‑üzerinde bağlantısı ve bir makro eylemi içeren `hyperlink-audit-input.pptx` dosyasını oluşturur. Bu eylemler hiçbir zaman çalıştırılmaz. Aynı üç sorgu her kapsamda çalışır; sayımlar eylem toplamı değil, kapsayıcı sayısını verir. Metin‑çerçeve kapsamı, içinde bulunduğu şeklin kendi bağlantılarını dışarıda bırakır.

```python
import aspose.slides as slides


def print_counts(scope, queries):
    click_containers = queries.get_hyperlink_clicks()
    mouse_over_containers = queries.get_hyperlink_mouse_overs()
    all_containers = queries.get_any_hyperlinks()
    print(f"{scope}: click={len(click_containers)}, mouse-over={len(mouse_over_containers)}, any={len(all_containers)}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    destination = presentation.slides.add_empty_slide(slide.layout_slide)
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Click the text to go to slide 2"
    shape.hyperlink_manager.set_external_hyperlink_click("https://example.com/")
    shape.hyperlink_click.tooltip = "Public website"
    shape.hyperlink_manager.set_external_hyperlink_mouse_over("file:///C:/private/report.xlsx")

    portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_manager.set_internal_hyperlink_click(destination)
    portion_format.hyperlink_manager.set_external_hyperlink_mouse_over("https://example.com/help")
    macro_button = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 120, 200, 60)
    macro_button.hyperlink_manager.set_macro_hyperlink_click("ReviewPresentation")

    print_counts("Presentation", presentation.hyperlink_queries)
    print_counts("Slide 1", slide.hyperlink_queries)
    print_counts("Text frame", shape.text_frame.hyperlink_queries)
    presentation.save("hyperlink-audit-input.pptx", slides.export.SaveFormat.PPTX)
```

Bu örnek için, sunum ve slayt sorguları üç tıklama kapsayıcısı, iki fare‑üzerinde kapsayıcısı ve her iki eylemden birini içeren üç kapsayıcı raporlar. Metin‑çerçeve sorgusu ise her kategori için bir kapsayıcı raporlar.

### **Eylemleri ve Hedefleri Sınıflandırma**

Bir eylemi yorumlamadan önce, hedefini yorumlamak için [Hyperlink.action_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlink/action_type/) özelliğini kullanın. [HyperlinkActionType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlinkactiontype/) değerleri sadece web navigasyonundan daha fazlasını kapsar:

| Değerler | Denetim için anlamı |
| --- | --- |
| `HYPERLINK` | Dış köprü; URL ve şemasını inceleyin. |
| `JUMP_SPECIFIC_SLIDE` | Belirli bir slayta dahili geçiş. |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | Slayt gösterisi içinde yerleşik gezinme, slayt gösterisi bağlamında çözülür. |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | Mevcut gösteriyi sonlandır veya özel bir gösteri başlat. |
| `START_MACRO` | Bir makro çalıştır. |
| `START_PROGRAM` | Bir program başlat. |
| `OPEN_FILE`, `OPEN_PRESENTATION` | Bir dosya veya başka bir sunum aç; web URL'lerinden ayrı değerlendir. |
| `START_STOP_MEDIA` | Medya oynatımını başlat veya durdur. |
| `NO_ACTION`, `UNKNOWN` | Navigasyon eylemi yok veya tanınmayan eylem; inceleme gerektirir. |

Dış hedefleri [external_url](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlink/external_url/) üzerinden, belirli dahili hedefleri ise [target_slide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlink/target_slide/) üzerinden okuyun. Dahili eylemler ve yerleşik komutlar dış URL içermeyebilir; boş bir URL, kapsayıcının eylemi olmadığı anlamına gelmez. Normalleştirilmiş URL'den farklıysa [external_url_original](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlink/external_url_original/) değerini koruyun ve mevcutsa [tooltip](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlink/tooltip/) ekleyin.

### **Köprüleri Raporla, Temizle ve Doğrula**

Aşağıdaki Python örneği, mevcut bir sunumu (yukarıda oluşturulan dosyayı) okur, `hyperlink-audit.json` dosyasına yazar, bir politika uygular, `hyperlink-sanitized.pptx` olarak kaydeder ve ardından hem tıklama hem de fare‑üzerinde eylemlerini tekrar kontrol eder. Değiştirmeden önce kapsayıcıları toplar ve her slayt kapsamını yalnızca bir kez sorgular; böylece tekrarlı işleme engel olur. Sunum sorguları normal slaytları kapsar; paket‑geneli envanter için örnek, normal slaytların yanı sıra ustaları, düzenleri, notları ve mevcutsa not ve el ilanı ustalarını da sorgular.

Rapor, bir‑tabanlı slayt indeksini ve mevcutsa [slide_id](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseslide/slide_id/) değerini kaydeder. Toplayıcı, her döndürülen kapsayıcı için sahip slaytı ve kapsamı tutar. Ustalar, düzenler ve notlar normal slayt indeksi taşımadığından kapsamlarıyla tanımlanır. Şekil kapsayıcıları ve metin‑parça biçimlendirme kapsayıcıları ayrı ayrı etiketlenir; diğer kapsayıcı türleri çalışma zamanı tip adını korur. Her kapsayıcı, iki eylemin ilişkilendirilebilmesi için rapor‑yerel bir ID alır.

Bu kısıtlayıcı uygulama politikası yalnızca mutlak HTTPS URL'lerini ve geçerli dahili slayt hedeflerini kabul eder. Makrolar, programlar, dosya eylemleri, diğer slayt gösterisi eylemleri, bilinmeyen eylemler ve diğer URL şemaları reddedilir. Bu reddetmeler politika kararlarıdır, Aspose.Slides güvenlik kararı değildir. HTTPS tek başına güvenilirlik sağlamaz; uygulamanıza host izin listeleri ve ek kontroller ekleyin. Hem orijinal hem de normalleştirilmiş dış URL'ler kontrol edilir. Örnek, bağları takip etmeden veya eylemleri çalıştırmadan meta verileri denetler.

Düzeltme için, kapsayıcının [hyperlink_manager](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) aşağıdaki yöntemleri destekler: [set_external_hyperlink_click](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/), [remove_hyperlink_click](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) ve [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/). Burada, izin
verilmeyen dış tıklama bağlantıları sabit bir HTTPS açılış sayfası ile değiştirilir; diğer yasaklı tıklama ve fare‑üzerinde eylemler bağımsız olarak kaldırılır. Tüm politika ihlallerini kaldırmak için `replace_external_clicks` değerini `False` yapın. Dağıtıma almadan önce uygulama‑sahibi bir değiştirme sayfası seçin.

Raporun dışa aktarma işareti, temkinli bir PDF inceleme politikası kullanır: fare‑üzerinde eylemler ve dış bağlantı olmayan veya belirli slayt atlaması olmayan her şey potansiyel olarak desteklenmez olarak işaretlenir. Bu bir inceleme ipucu olup, işaretlenmemiş bağlantıların dışa aktarımda hayatta kalacağını garanti etmez. Desteklenen [PDF](/slides/tr/python-net/convert-powerpoint-to-pdf/) ve [HTML](/slides/tr/python-net/convert-powerpoint-to-html/) dışa aktarmaları, eyleme, dışa aktarım seçeneklerine ve görüntüleyiciye bağlı olarak köprüleri koruyabilir; raster [görseller](/slides/tr/python-net/convert-powerpoint-to-png/) ve [videolar](/slides/tr/python-net/convert-powerpoint-to-video/) etkileşimli köprüleri saklayamaz; bu çıktılar için denetim sırasında her eylemi işaretleyin.

```python
import json
import sys
from urllib.parse import urlsplit
import aspose.slides as slides


def is_https(value):
    if not value or any(character.isspace() for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.action_type == slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE:
        return "Missing target slide" if link.target_slide is None else None
    if link.action_type != slides.HyperlinkActionType.HYPERLINK:
        return "Action is not allowed"
    if not is_https(link.external_url):
        return "Normalized URL is not absolute HTTPS"
    original = link.external_url_original
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def slide_index(presentation, slide):
    if slide is not None:
        for index, candidate in enumerate(presentation.slides, start=1):
            if candidate.slide_id == slide.slide_id:
                return index
    return None


def collect_containers(presentation):
    # Her slayt kapsamını bir kez sorgula, her kapsayıcıyla birlikte sahibini tut.
    scopes = [("Slide", slide) for slide in presentation.slides]
    scopes.extend(("Master", master) for master in presentation.masters)
    scopes.extend(("Layout", layout) for layout in presentation.layout_slides)
    scopes.extend(("Notes", slide.notes_slide_manager.notes_slide) for slide in presentation.slides)
    scopes.append(("Notes master", presentation.master_notes_slide_manager.master_notes_slide))
    scopes.append(("Handout master", presentation.master_handout_slide_manager.master_handout_slide))
    found = []
    for scope, owner in scopes:
        if owner is not None:
            containers = list(owner.hyperlink_queries.get_any_hyperlinks())
            found.extend((container, scope, owner) for container in containers)
    return found


def add_row(rows, presentation, link, activation, container, container_id, scope, owner):
    if link is None:
        return
    target_slide = link.target_slide
    violation = policy_violation(link)
    if isinstance(container, slides.Shape):
        owner_type = "Shape"
    elif isinstance(container, slides.PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = type(container).__name__
    ordinary_action = link.action_type in (slides.HyperlinkActionType.HYPERLINK, slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE)
    original_url = link.external_url_original if link.external_url_original != link.external_url else None
    rows.append({
        "container_id": container_id,
        "slide_index": slide_index(presentation, owner) if scope == "Slide" else None,
        "slide_id": owner.slide_id,
        "scope": scope,
        "owner_type": owner_type,
        "activation": activation,
        "action_type": link.action_type.name,
        "external_url": link.external_url,
        "target_slide_index": slide_index(presentation, target_slide),
        "target_slide_id": target_slide.slide_id if target_slide is not None else None,
        "tooltip": link.tooltip,
        "original_external_url": original_url,
        "potentially_unsafe": violation is not None,
        "policy_violation": violation,
        "target_export": "PDF",
        "potentially_unsupported_by_export": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"

with slides.Presentation("hyperlink-audit-input.pptx") as presentation:
    containers = collect_containers(presentation)
    rows = []
    for container_id, (container, scope, owner) in enumerate(containers, start=1):
        add_row(rows, presentation, container.hyperlink_click, "click", container, container_id, scope, owner)
        add_row(rows, presentation, container.hyperlink_mouse_over, "mouse-over", container, container_id, scope, owner)

    with open("hyperlink-audit.json", "w", encoding="utf-8") as report_file:
        json.dump(rows, report_file, indent=2)

    for container, scope, owner in containers:
        click = container.hyperlink_click
        if policy_violation(click) is not None:
            if replace_external_clicks and click.action_type == slides.HyperlinkActionType.HYPERLINK:
                container.hyperlink_manager.set_external_hyperlink_click(replacement_url)
            else:
                container.hyperlink_manager.remove_hyperlink_click()
        if policy_violation(container.hyperlink_mouse_over) is not None:
            container.hyperlink_manager.remove_hyperlink_mouse_over()

    presentation.save("hyperlink-sanitized.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlink-sanitized.pptx") as reopened:
    remaining_containers = collect_containers(reopened)
    violations = 0
    for container, scope, owner in remaining_containers:
        if policy_violation(container.hyperlink_click) is not None:
            violations += 1
        if policy_violation(container.hyperlink_mouse_over) is not None:
            violations += 1
    print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
    if violations != 0:
        print("Verification failed: do not distribute the saved presentation.")
        sys.exit(1)
```

Yukarıda oluşturulan giriş ile rapor beş eylem satırı içerir. Dosya fare‑üzerinde bağlantısı ve makro tıklaması kaldırılır, HTTPS bağlantıları ve dahili slayt navigasyonu kalır. Doğrulama, sıfır yasaklı eylem gösterir. Yasaklı bir dış tıklama URL'si içeren bir giriş, değiştirme dalını da çalıştırır. İzin verilen bir tıklama ve yasaklı bir fare‑üzerinde eylemi olan bir kapsayıcı, tıklama eylemini tutar.

Bu seçici temizlik, **[remove_all_hyperlinks](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/)** yönteminden farklıdır; bu yöntem, politika göz önüne alınmaksızın seçilen kapsam içindeki her iki etkinleştirme türünü de kaldırır. Buradaki doğrulama yalnızca köprü eylemlerini kontrol eder; gömülü VBA projelerini, OLE nesnelerini veya diğer aktif içeriği kaldırmaz ve dışa aktarılmış bir PDF veya HTML dosyasını doğrulamaz.

## **SSS**

**Bir bölüme ya da onun ilk slaytına nasıl bağlanabilirim?**

PowerPoint’te bölümler slaytları gruplar, ancak dahili bir köprü sadece tek bir slaytı hedef alır. Bir bölüme geçiş oluşturmak için, o bölümün ilk slaytına bağlanın.

**Usta slayt öğelerine köprü ekleyebilir miyim, böylece tüm slaytlarda çalışır?**

Evet. Usta slayt ve düzen öğeleri köprüleri destekler. Bu öğelere eklenen bağlantılar, ilgili ustayı veya düzeni kullanan slayt gösterisi sırasında erişilebilir olur.

**Köprüler PDF, HTML, görseller veya video olarak dışa aktarılırken korunur mu?**

Desteklenen PDF ve HTML dışa aktarmaları köprüleri koruyabilir; raster görseller ve videolar koruyamaz. Detaylı dışa aktarım bilgileri için **[Raporla, Temizle ve Köprüleri Doğrula](#report-sanitize-and-verify-hyperlinks)** bölümüne bakın.