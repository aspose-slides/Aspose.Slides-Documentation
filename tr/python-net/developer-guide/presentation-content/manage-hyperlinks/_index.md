---
title: Python'da Sunum Hiperlinklerini Yönetme
linktitle: Hiperlinkleri Yönet
type: docs
weight: 20
url: /tr/python-net/manage-hyperlinks/
keywords:
- URL ekle
- hiperlink ekle
- hiperlink oluştur
- hiperlink biçimlendir
- hiperlink kaldır
- hiperlink güncelle
- metin hiperlinki
- slayt hiperlinki
- şekil hiperlinki
- görsel hiperlinki
- video hiperlinki
- değiştirilebilir hiperlink
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak, Python örnekleriyle PowerPoint ve OpenDocument sunumlarında hiperlink ekleme, biçimlendirme, güncelleme ve kaldırma."
---
## **Giriş**

Bir köprü (hiperlink), sunum içeriğini bir web sitesine veya sunum içindeki bir konuma bağlar. PowerPoint'te hiperlinkler genellikle iki amaç için kullanılır:

- Metinden, şekilden veya bir medya çerçevesinden bir web sitesini açmak.
- Başka bir slayta gitmek, örneğin bir içindekiler tablosundan.

Aspose.Slides for Python via .NET, bu bağlantıları eklemenize, görünüm ve seslerini kontrol etmenize, özelliklerini güncellemenize ve kaldırmanıza olanak tanır. Aşağıdaki örnekler, hiperlinklerle bireysel öğeler üzerinde nasıl çalışılacağını ve hiperlinklere sunum, slayt veya metin çerçevesi düzeyinde nasıl erişileceğini gösterir.

{{% alert color="info" title="Note" %}}
Sunumları ayrıca [ücretsiz çevrimiçi Aspose PowerPoint editörü](https://products.aspose.app/slides/editor) ile düzenleyebilirsiniz.
{{% /alert %}}

## **URL Hiperlinkleri Ekle**

Web sitesi URL'sini metne, şekle veya bir medya çerçevesine atayabilirsiniz. Hiperlinki atadığınız öğe tıklanabilir alanı belirler: bir metin bölümü seçili metni bağlarken, bir şekil ya da çerçeve slayt nesnesini bağlar.

Sunumlarda göreli hiperlinkler varsa, belge‑düzeyindeki temel URL'yi okumak, değiştirmek veya temizlemek için [Manage the Hyperlink Base](/slides/tr/python-net/presentation-properties/#manage-the-hyperlink-base) bölümüne bakın.

### **Metne URL Hiperlinkleri Ekle**

Metni bir web sitesine bağlamak için, metin bölümünün [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/hyperlink_click/) özelliğine bir [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) atayın. Aşağıda gösterildiği gibi. Yalnızca o metin bölümü tıklanabilir olur.

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

### **Şekillere ve Medya Çerçevelerine URL Hiperlinkleri Ekle**

Bir şekli ya da çerçeveyi tıklanabilir hâle getirmek için, onun [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/shape/hyperlink_click/) özelliğini ayarlayın. Hiperlink, içinde metin bulunduran bir nesne yerine nesnenin kendisine aittir.

Aynı yaklaşım resim, ses ve video çerçevelerine de uygulanır: hiperlinki çerçeveye atayın ve gerekirse linkin [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) özelliğini ayarlayın.

Aşağıdaki örnek bir dikdörtgeni tıklanabilir hâle getirir:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **Hiperlinkleri Kullanarak İçindekiler Tablosu Oluşturma**

İç içe hiperlinkler, okuyucuların içindekiler tablosundan belirli bir slayta atlamasını sağlar. Aşağıdaki örnek, ilk slayttaki “Page 2” metnini ikinci slayta bağlamak için [set_internal_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/) yöntemini kullanır.

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

## **Hiperlinkleri Biçimlendirme**

### **Renk**

[Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) sınıfının [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) özelliği, bir hiperlinkin sunumun genel hiperlink rengi mi yoksa metin bölümünün biçimlendirmesi mi kullanılacağını belirler. Özel bir metin rengi uygulamak için [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkcolorsource/) seçin ve bölümün doldurma rengini ayarlayın. Bu özellik PowerPoint 2019’da tanıtıldı; daha eski sürümler bu ayarı uygulamaz.

Aşağıdaki örnek aynı slayta iki metin hiperlinki ekler. İlki kırmızı bir metin doldurması kullanırken, ikincisi varsayılan hiperlink rengini korur.

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

Bir hiperlink, etkinleştirildiğinde ses çalabilir veya hâlihazırda çalan bir sesi durdurabilir. Bu davranışları yapılandırmak için aşağıdaki özellikleri kullanın:

- [Hyperlink.sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) hiperlinke ilişkilendirilen ses dosyasını belirler.
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/) tıklama ile önceki sesin durdurulup durdurulmayacağını denetler.

#### **Bir Hiperlink Ses'i Ekle**

Aşağıdaki örnek `sampleaudio.wav` dosyasını yükler ve ilk slayttaki bir düğmeye bağlar. Düğmeye tıklamak sesi çalar ve bir sonraki slayta gider. Aynı slayttaki ikinci şekil, tıklamayla bir gezinme işlemi yapmadan önceki sesi durdurur.

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

#### **Bir Hiperlink Sesini Çıkar**

Aşağıdaki örnek, yukarıda oluşturulan sunumu açar ve ilk şeklin hiperlink sesini [sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) ve [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/) aracılığıyla belleğe okur.

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

Metne ya da şekle bir hiperlink atadıktan sonra aşağıdaki [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) özelliklerini güncelleyebilirsiniz:

- [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) izleyicinin bağ için bir ipucu olarak gösterebileceği metni ayarlar.
- [target_frame](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_frame/) uygulanabilir olduğunda, üst HTML çerçeve setindeki hedef çerçeveyi belirtir.
- [history](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/history/) bağın etkinleştirilmesinin, hedefini görüntülenmiş hiperlinkler listesine ekleyip eklemeyeceğini denetler.
- [highlight_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/highlight_click/) tıklandığında hiperlinkin vurgulanıp vurgulanmayacağını kontrol eder.

## **Sunumlardan Hiperlinkleri Kaldırma**

[get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) kullanarak, değiştirmeden önce metin‑bölümü bağlantıları da dahil olmak üzere hiperlink kapsayıcılarını toplayın. Aşağıdaki örnek, ilk slayttaki iki etkinleştirme tipini (tıklama ve fare‑üzerine) kaldırır. Yalnızca bir tip kaldırmak isterseniz, sadece [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) ya da [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/) çağırın; bir tıklama eylemini kaldırmak, fare‑üzerine karşılığını kaldırmaz.

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

Koşulsuz kaldırma için, [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) seçilen kapsamda iki etkinleştirme tipini tek bir çağrıyla siler. Ustalar, yerleşimler ve notlar dahil olmak üzere seçici temizlik ve kapsamlı kapsama için, [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) bölümüne bakın.

## **Tam Bir Hiperlink Envanteri Oluşturma**

Bir sunumu dağıtmadan önce, etkileşimli eylemlerini ve web bağlantılarını envantere alın. [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) [IHyperlinkContainer](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/) nesnelerini döndürür, düz bir URL listesi değil. Her kapsayıcıdaki [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) ve [hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) öğelerini inceleyin. Bağımsızdırlar: aynı kapsayıcı iki eylemi de sunabilir, bu yüzden tam bir rapor her kapsayıcı için iki satıra kadar ihtiyaç duyabilir.

Sadece şekil‑düzeyindeki hiperlinkleri taramak, metin bölümlerine eklenmiş bağlantıları kaçırabilir. Bunun yerine uygun kapsamı sorgulayın ve döndürülen kapsayıcıları saklayın; böylece daha sonra eylemlerini güncelleyebilir ya da kaldırabilirsiniz.

### **Sunum, Slayt ve Metin-Çerçeve Kapsamlarını Sorgulama**

[HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) sınıfı, [Presentation.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/hyperlink_queries/), [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/hyperlink_queries/) ve [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/) üzerinden erişilebilir. Her kapsam aynı sorguları destekler:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) tıklama eylemi içeren kapsayıcıları döndürür.
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) fare‑üzerine eylemi içeren kapsayıcıları döndürür.
- [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) bir veya iki eylemi olan kapsayıcıları döndürür.

Aşağıdaki örnek, dış tıklama bağlantısı, dosya fare‑üzerine bağlantısı, iç slayt navigasyonu, metin fare‑üzerine bağlantısı ve bir makro eylemi içeren `hyperlink-audit-input.pptx` dosyasını oluşturur. Bu eylemlerden hiçbiri yürütülmez. Aynı üç sorgu her kapsamda çalışır; sayılar kapsayıcı sayısını, eylem toplamını değil, gösterir. Metin‑çerçeve kapsamı, içindeki şeklin kendi bağlantılarını dışarıda bırakır.

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

Bu örnek için, sunum ve slayt sorguları üç tıklama kapsayıcısı, iki fare‑üzerine kapsayıcısı ve her iki eylemi de içeren üç kapsayıcı rapor eder. Metin‑çerçeve sorgusu her kategori için bir kapsayıcı raporlar.

### **Eylemleri ve Hedefleri Sınıflandırma**

[Hyperlink.action_type](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/action_type/) kullanarak bir eylemi yorumlamadan önce hedefini yorumlayın. [HyperlinkActionType](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkactiontype/) değerleri yalnızca web gezinmesini değil, aşağıdaki gibi daha fazlasını kapsar:

| Değerler | Denetim İçin Anlamı |
| --- | --- |
| `HYPERLINK` | Harici hiperlink; URL ve şemasını inceleyin. |
| `JUMP_SPECIFIC_SLIDE` | Belirli bir slayta iç navigasyon. |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | Slayt gösterisi içinde yerleşik gezinme, slayt gösterisi bağlamında çözülür. |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | Mevcut gösteriyi sonlandır veya özel bir gösteri başlat. |
| `START_MACRO` | Bir makro çalıştır. |
| `START_PROGRAM` | Bir program başlat. |
| `OPEN_FILE`, `OPEN_PRESENTATION` | Bir dosya ya da başka bir sunum aç; web URL'lerinden ayrı olarak incelenir. |
| `START_STOP_MEDIA` | Medya oynatımını başlat veya durdur. |
| `NO_ACTION`, `UNKNOWN` | Navigasyon eylemi yok veya tanınmayan bir eylem; gözden geçirilmesi gerekir. |

Harici hedefleri [external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) özelliğinden, belirli iç hedefleri ise [target_slide](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_slide/) özelliğinden okuyun. İç eylemler ve yerleşik komutlar dış URL içermeyebilir; boş bir URL, kapsayıcının eylemi olmadığı anlamına gelmez. Normalleştirilmiş URL'den farklıysa [external_url_original](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url_original/) değerini koruyun ve mevcutsa [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) ekleyin.

### **Hiperlinkleri Raporla, Temizle ve Doğrula**

Aşağıdaki Python örneği, mevcut bir sunumu (yukarıda oluşturulan dosyayı) okur, `hyperlink-audit.json` yazar, bir politika uygular, `hyperlink-sanitized.pptx` kaydeder ve ardından her iki etkinleştirme tipini tekrar kontrol eder. Değişiklikten önce kapsayıcıları toplar ve her slayt kapsamında tek bir sorgu yapar; böylece yinelenen işleme girmez. Sunum sorguları normal slaytları kapsar; paket‑geneli envanter için örnek, normal slaytlar, ustalar, yerleşimler, notlar ve varsa not ve el ilanı ustalarını da sorgular.

Rapor bir‑bazlı slayt indeksini ve mümkünse [slide_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/slide_id/) bilgisini kaydeder. Toplayıcı, her döndürülen kapsayıcıyla birlikte sahip slaytı ve kapsamı tutar. Ustalar, yerleşimler ve notlar normal slayt indeksi taşımaz; kapsamlarıyla tanımlanırlar. Şekil kapsayıcıları ve metin‑bölümü biçimleme kapsayıcıları ayrı ayrı etiketlenir; diğer kapsayıcı tipleri çalışma zamanı tip adını korur. Her kapsayıcı, iki eylemini birbirine bağlamak için rapor‑yerel bir kimlik alır.

Bu kısıtlayıcı uygulama politikası, yalnızca mutlak HTTPS URL'leri ve geçerli iç slayt hedeflerine izin verir. Makroları, programları, dosya eylemlerini, diğer slayt gösterisi eylemlerini, bilinmeyen eylemleri ve diğer URL şemalarını reddeder. Bu reddetmeler politika kararlarıdır, Aspose.Slides güvenlik kararı değildir. HTTPS tek başına güven sağlar diyemezsiniz: uygulamanız için host beyaz listeleri ve ek denetimler ekleyin. Hem orijinal hem de normalleştirilmiş dış URL'ler denetlenir. Örnek, bağlantıları takip etmeden ya da eylemleri çalıştırmadan meta verileri denetler.

Düzeltme için, kapsayıcının [hyperlink_manager](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) [set_external_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/), [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) ve [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/) yöntemlerini destekler. Burada, yasak dış tıklama linkleri sabit bir HTTPS landing sayfası ile değiştirilir; diğer yasak tıklamalar ve yasak fare‑üzerine eylemler bağımsız olarak kaldırılır. `replace_external_clicks` değerini `False` yaparak tüm politika ihlallerini kaldırabilirsiniz. Dağıtıma hazırlık sırasında uygulamanızın sahip olduğu bir değiştirme sayfası seçin.

Raporun dışa aktarma bayrağı, tutumlu bir PDF inceleme politikası kullanır: fare‑üzerine eylemleri ve dış link olmayan ya da belirli slayt atlaması olmayan her şeyi potansiyel olarak desteklenmeyen olarak işaretler. Bu bir inceleme ipucudur, yetenek testi ya da işaretlenmemiş linklerin dışa aktarımda hayatta kalacağı garantisi değildir. Desteklenen [PDF](/slides/tr/python-net/convert-powerpoint-to-pdf/) ve [HTML](/slides/tr/python-net/convert-powerpoint-to-html/) dışa aktarımları, eyleme, dışa aktarma seçeneklerine ve görüntüleyiciye bağlı olarak hiperlinkleri koruyabilir. Raster [images](/slides/tr/python-net/convert-powerpoint-to-png/) ve [video](/slides/tr/python-net/convert-powerpoint-to-video/) interaktif hiperlinkleri koruyamaz; bu çıktılar için denetim yaparken her eylemi işaretleyin.

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
    # Her slayt kapsamını bir kez sorgulayın, her kapsayıcının sahibini koruyarak.
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

Yukarıda oluşturulan girdiyle rapor beş eylem satırı içerir. Dosya fare‑üzerine linki ve makro tıklaması kaldırılırken, HTTPS linkleri ve iç slayt navigasyonu kalır. Doğrulama, sıfır yasak eylem çıktılar. Yasak bir dış tıklama URL'si içeren bir girdi, değiştirme dalını da çalıştırır. İzinli bir tıklama ve yasak bir fare‑üzerine eylemi olan bir kapsayıcı, tıklama eylemini tutar.

Bu seçici temizlik, [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) yönteminin aksine, politika göz önüne alınmadan seçilen kapsamda her iki etkinleştirme tipini de kaldırmaz. Buradaki doğrulama yalnızca hiperlink eylemlerini kontrol eder; gömülü VBA projelerini, OLE nesnelerini ya da diğer aktif içeriği kaldırmaz ve dışa aktarılmış PDF ya da HTML dosyasını doğrulamaz.

## **SSS**

**Bir bölüme veya o bölümün ilk slaytına nasıl bağlanabilirim?**

PowerPoint’te bölümler slaytları gruplar, ancak bir iç hiperlink bireysel bir slaytı hedef alır. Bir bölüme navigasyon oluşturmak için, o bölümün ilk slaytına bağlayın.

**Usta slayt (master slide) öğelerine hiperlink ekleyebilir miyim, böylece tüm slaytlarda çalışır?**

Evet. Usta slayt ve yerleşim öğeleri hiperlinkleri destekler. Bu öğelere eklenen linkler, ilgili usta ya da yerleşimi kullanan slayt gösterisi sırasında erişilebilir olur.

**Hiperlinkler PDF, HTML, görüntüler veya video dışa aktarılırken korunur mu?**

Desteklenen PDF ve HTML dışa aktarımları hiperlinkleri koruyabilir; raster görüntüler ve video bunları koruyamaz. Ayrıntılar için [Hiperlinkleri Raporla, Temizle ve Doğrula](#report-sanitize-and-verify-hyperlinks) bölümündeki dışa aktarma değerlendirmelerine bakın.