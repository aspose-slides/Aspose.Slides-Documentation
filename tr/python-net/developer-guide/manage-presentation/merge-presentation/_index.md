---
title: Python ile Sunumları Verimli Bir Şekilde Birleştirme
linktitle: Sunumları Birleştir
type: docs
weight: 40
url: /tr/python-net/merge-presentation/
keywords:
- PowerPoint'i birleştir
- sunumları birleştir
- slaytları birleştir
- PPT'yi birleştir
- PPTX'i birleştir
- ODP'yi birleştir
- PowerPoint'i birleştir
- sunumları birleştir
- slaytları birleştir
- PPT'yi birleştir
- PPTX'i birleştir
- ODP'yi birleştir
- Python
- Aspose.Slides
description: "Python'da slaytları klonlayarak, master ve layout'ları kontrol ederek, slayt içeriğini yeniden boyutlandırarak, bölümleri koruyarak ve korumalı ya da büyük dosyalarla başa çıkarak PowerPoint ve OpenDocument sunumlarını nasıl birleştireceğinizi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Python via .NET, bir sunumu bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) içinden diğerine slaytları klonlayarak birleştirir. Ana işlem [SlideCollection.add_clone](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/add_clone/) olup, kaynak slaydın biçimlendirmesini koruyabilir veya klonlanan slaytı hedef sunumdaki bir master veya layout'a ekleyebilir.

Bu makale en yaygın birleştirme iş akışlarını kapsar:

- tüm slaytları kaynak biçimlendirmeleri korunarak birleştir;
- seçili slaytları birleştir;
- hedef sunumdaki bir master uygula;
- hedef sunumdaki belirli bir layout uygula;
- birleştirmeden önce farklı slayt boyutlarını normalize et;
- klonlanan slaytları bir bölüme ekle;
- birden çok sunumu uçtan uca bir iş akışında birleştir;
- masterlar, kaynaklar, notlar, yorumlar, medya, yazı tipleri, parolalar, büyük dosyalar ve çok iş parçacıklı durumları yönet.

## **Slayt Klonlamanın Master ve Layout’ları Nasıl Etkilediği**

Bir slayt görünümünün çoğunu layout ve master’dan devralır. Bu nedenle seçtiğiniz klonlama aşırı yüklemesi, birleştirilen slaydın hedef sunuma nasıl entegre edileceğini belirler.

[SlideCollection.add_clone](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/add_clone/) yöntemini şu şekillerde kullanın:

- `add_clone(source_slide)` — kaynak slaydın layout ve biçimlendirmesini korur. Gerektiğinde, kaynak master otomatik olarak hedef sunuma klonlanabilir. Aspose.Slides, aynı kaynak master’ı kullanan tekrarlanan slaytların master’ı tekrar klonlamasını önlemek için otomatik klonlanan master’ları izler.
- `add_clone(source_slide, destination_master, allow_clone_missing_layout)` — klonlanan slaytı belirli bir hedef [IMasterSlide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imasterslide/)’a bağlar. Aspose.Slides, o master altında layout tipine veya adına göre eşleşen bir layout arar.
- `add_clone(source_slide, destination_layout)` — klonlanan slaytı doğrudan belirli bir hedef [ILayoutSlide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ilayoutslide/)’a bağlar.

`add_clone` aşırı yüklemesine geçirilen master veya layout **hedef** sunuma ait olmalıdır, kaynak sunuma ait olmamalıdır.

## **Tüm Sunumları Birleştir ve Kaynak Biçimlendirmesini Koru**

En basit birleştirme, kaynak sunumdaki her slaytı hedef sunuma kopyalar. Bu, içe aktarılan slaytların orijinal tema, master ve layout ilişkilerini koruması gerektiğinde uygun bir seçenektir.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

Kaynak ve hedef farklı tasarımlar kullandığında sonuç sunum birden çok master içerebilir. Kaynak biçimlendirmesinin kasıtlı olarak korunması durumunda bu beklenen bir durumdur.

## **Seçili Slaytları Birleştir**

Her slaytı klonlamanız gerekmez. Aşağıdaki örnek, kaynak sunumdan yalnızca seçili slayt indekslerini içe aktarır.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        slide_indexes = [0, 2, 4]

        for index in slide_indexes:
            destination.slides.add_clone(source.slides[index])

        destination.save("merged-selected-slides.pptx", slides.export.SaveFormat.PPTX)
```

Kullanıcı girişi veya harici yapılandırmadan gelen indeksler klonlamadan önce doğrulanmalıdır.

## **Hedef Master Kullanarak Slaytları Birleştir**

İçe aktarılan slaytların zaten hedef sunuma ait bir master’ı izlemesi gerektiğinde [add_clone(source_slide, destination_master, allow_clone_missing_layout)](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/add_clone/) aşırı yüklemesini kullanın.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_master = destination.masters[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_master, True)

        destination.save("merged-with-destination-master.pptx", slides.export.SaveFormat.PPTX)
```

Aspose.Slides, kaynak layout tipine veya adına göre belirtilen master altında uygun bir layout seçer. Uygun bir layout bulunmaz ve `allow_clone_missing_layout` `True` ise, kaynak layout klonlanarak slayt eklenebilir. `False` ise bir [PptxEditException](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pptxeditexception/) fırlatılır.

Ek bir layout eklenmesini istemiyorsanız birleştirmenin başarısız olmasını sağlamak için `False` kullanın.

## **Belirli Bir Hedef Layout Kullanarak Slaytları Birleştir**

İçe aktarılan slaytların kesin olarak hangi hedef layout’u kullanması gerektiğini bildiğinizde [add_clone(source_slide, destination_layout)](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/add_clone/) aşırı yüklemesini kullanın.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_layout = destination.layout_slides[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_layout)

        destination.save("merged-with-destination-layout.pptx", slides.export.SaveFormat.PPTX)
```

Bir hedef layout uygulamak, devralınan layout ilişkisini değiştirir; kaynak slayt içeriğini yeniden tasarlamaz. Kaynak ve hedef layout’ların farklı yer tutucu yapıları varsa, devralınan biçimlendirme ve yer tutucu davranışının uygun olduğundan emin olmak için sonucu inceleyin.

## **Farklı Slayt Boyutlarına Sahip Sunumları Birleştir**

Farklı slayt boyutlarına sahip sunumlar birleştirilebilir, ancak bir slaytı başka bir slayt boyutuna sahip bir sunuma klonlamak, içeriği yeni kanvas için otomatik olarak yeniden tasarlamaz. Şekiller bu nedenle kaydırılmış, beklenmedik şekilde ölçeklenmiş veya görünür slayt alanının dışına çıkmış görünebilir.

Pratik bir yaklaşım, klonlamadan önce kaynak sunumu yeniden boyutlandırmaktır. [SlideSize.set_size](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidesize/set_size/) yöntemi, slayt boyutlarını değiştirirken mevcut içeriği ölçeklendirebilir. [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidesizescaletype/) istenen boyuta sığacak şekilde içeriği ölçeklendirir.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        if (
            source.slide_size.size.width != destination.slide_size.size.width
            or source.slide_size.size.height != destination.slide_size.size.height
        ):
            source.slide_size.set_size(
                destination.slide_size.size.width,
                destination.slide_size.size.height,
                slides.SlideSizeScaleType.ENSURE_FIT)

        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged-same-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

Yeniden boyutlandırma, kaynak sunum nesnesini bellekte değiştirir. Orijinal kaynak sunumun diğer işlemler için değişmeden kalması gerekiyorsa, birleştirme için ayrı bir örnek açın.

## **Slaytları Bir Sunum Bölümüne Birleştir**

Temel slayt klonlama döngüsü, kaynak sunumun bölüm hiyerarşisini yeniden oluşturmaz. Bölümler çıktıda önemliyse, hedef sunumda bölümler oluşturup veya seçip slaytları açıkça [SlideCollection.add_clone](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/add_clone/) ile bu bölümlere klonlayın.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        imported_section = destination.sections.append_empty_section("Imported slides")

        for slide in source.slides:
            destination.slides.add_clone(slide, imported_section)

        destination.save("merged-with-section.pptx", slides.export.SaveFormat.PPTX)
```

Klonlanan slaytlar belirtilen hedef bölüme eklenir. Birden çok kaynak bölümü korumak için, [SectionCollection.append_empty_section](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sectioncollection/append_empty_section/) ile hedefte bu bölümleri yeniden oluşturun ve her kaynak slaytı ilgili hedef bölüme eşleyin.

## **Birden Çok Sunumu Güvenli Bir Şekilde Birleştir**

Aşağıdaki uçtan uca örnek, ilk sunumu hedef olarak kullanır, her ek kaynak için slayt boyutunu normalleştirir, her kaynağı yalnızca kopyalanırken açık tutar ve son dosyayı bir kez kaydeder.

```python
import aspose.slides as slides

input_files = ["part1.pptx", "part2.pptx", "part3.pptx"]

with slides.Presentation(input_files[0]) as merged:
    for file_index in range(1, len(input_files)):
        with slides.Presentation(input_files[file_index]) as source:
            if (
                source.slide_size.size.width != merged.slide_size.size.width
                or source.slide_size.size.height != merged.slide_size.size.height
            ):
                source.slide_size.set_size(
                    merged.slide_size.size.width,
                    merged.slide_size.size.height,
                    slides.SlideSizeScaleType.ENSURE_FIT)

            for slide in source.slides:
                merged.slides.add_clone(slide)

    merged.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

Bu, içe aktarılan slaytların kaynak biçimlendirmesini korumak için yararlı bir temel sağlar. Çıktınız tek bir hedef tema kullanmalıysa, basit `add_clone(slide)` çağrısını önceki bölümlerde gösterilen uygun hedef‑master veya hedef‑layout aşırı yüklemesiyle değiştirin.

## **Pratik Hususlar**

### **Master’lar, Layout’lar ve Biçimlendirme Sadakati**

Varsayılan slayt klonlaması, gerekli bir kaynak master’ı otomatik olarak hedef sunuma getirebilir. Aspose.Slides, aynı master’ın tekrarlı klonlanmasını önlemek için otomatik klonlanan master’ları içsel bir kayıt defterinde tutar. Manuel klonlanan master’lar bu kayıt defteri tarafından izlenmez; bu yüzden master’ları önceden klonlamaktan kaçının, sadece master yapısı üzerinde açık kontrol gerektiğinde bunu yapın.

Aynı ada sahip iki master veya layout’un görsel olarak eşdeğer olduğunu varsamayın. Kurumsal bir şablon nihai görünümü kontrol ediyorsa, hedef master veya layout’u açıkça seçin ve birleştirme sonrası sonucu doğrulayın.

### **Notlar ve Yorumlar**

Konuşmacı notları ve slayt yorumları slayt içeriğiyle ilişkilidir ve bir slayt klonlandığında kopyalanır. Aspose.Slides ayrıca [presentation notes](https://docs.aspose.com/slides/tr/python-net/presentation-notes/) ve [presentation comments](https://docs.aspose.com/slides/tr/python-net/presentation-comments/) için özel API’ler sunar.

Not sayfası biçimlendirmesi önemliyse, birleştirilmiş sunumu doğrulayın; çünkü not master’ları sunum‑seviyesinde nesnelerdir ve kaynak dosyalar arasında farklılık gösterebilir. İnceleme iş akışları için, farklı yazarlar veya şablonlardan birleştirilen dosyaların yorum yazarlarını ve dizili yorumları da doğrulayın.

### **Görseller, Ses, Video, OLE Nesneleri ve Harici Bağlantılar**

Slaytlar, görseller, gömülü ses, gömülü video ve OLE verileri gibi sunum‑seviyesi kaynaklara referans verebilir. Sadece görünür şekilleri kopyalamak yerine slaytı klonlayın; böylece Aspose.Slides, slaydın kaynaklarla ilişkisini korur.

Gömülü ve bağlantılı kaynaklar farklı şekilde ele alınmalıdır. Bağlantılı bir ses, video, OLE nesnesi veya köprü, dış hedefe bağımlı kalır; bir slaytı klonlamak harici bir bağlantıyı gömme içeriğe dönüştürmez. Bağlantılı kaynak yollarını ve URL’leri, birleştirilen sunumun açılacağı ortamda test edin.

Aspose.Slides otomatik klonlanan master’ları izlese de, bu farklı kaynak sunumlardan gelen aynı ikili kaynakların her zaman ayrıştırılacağına dair genel bir garanti değildir. Çıktı dosya boyutu önemliyse, birleştirilmiş paketi inceleyin ve sonucu ölçün; örtük ayrıştırmaya güvenmeyin.

### **Gömülü Yazı Tipleri ve Yazı Tipi Kullanılabilirliği**

Yazı tipleri sunum düzeyinde yönetilir. Tipografi makineler arasında tutarlı kalmalıysa, yalnızca slaytları klonlamak, gerekli tüm yazı tiplerinin hedef ortamda bulunacağını garanti etmez. Gömülü yazı tiplerini [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) ile inceleyebilir ve [Embed Fonts in Presentations](https://docs.aspose.com/slides/tr/python-net/embedded-font/)’ta açıklandığı gibi açıkça yönetebilirsiniz.

Ayrıca, kaynak dosyalarda kullanılan yazı tiplerini gömmek için izinlerinizin olup olmadığını doğrulayın. Yazı tipi lisansları gömmeyi kısıtlayabilir.

### **Parola Korumalı Sunumlar**

Parola korumalı bir kaynağı slaytları klonlamadan önce başarıyla açmanız gerekir. Parolayı [LoadOptions.password](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/password/) aracılığıyla sağlayın.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("protected.pptx", load_options) as source:
    print(len(source.slides))
```

Şifreli bir kaynağı açmak, hedef sunuma aynı korumayı otomatik olarak uygulamaz. Gerekirse çıktı korumasını ayrı olarak yapılandırın.

### **Büyük Sunumlar ve Bellek Kullanımı**

Yüksek çözünürlüklü görseller, ses, video veya diğer büyük ikili nesneler içeren büyük sunumlar önemli bellek tüketebilir. [LoadOptions.blob_management_options](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/blob_management_options/) BLOB yönetimi ve geçici dosya kullanımını kontrol eder. Büyük dosya stratejileri için [Manage Presentation BLOBs](https://docs.aspose.com/slides/tr/python-net/manage-blob/)’a bakın.

Büyük dosyalar için mümkün olduğunca dosya yollarından yüklemeyi tercih edin, her kaynak sunumu birleştirildikten hemen sonra kapatın ve ara sonuçları tekrar tekrar kaydetmekten kaçının; iş akışı kontrol noktaları gerektirmiyorsa. `with slides.Presentation(...)` kullanmak, bağlam sonlandığında sunum kaynaklarının serbest bırakılmasını sağlar.

### **İş Parçacığı Güvenliği**

[Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneklerini birden çok iş parçacığından aynı anda yüklemeyin, kaydetmeyin veya klonlamayın. Her bir birleştirme işlemine tek iş parçacığıyla yaklaşın. Bağımsız birleştirme işleri paralelleştiriliyorsa, ayrı tek‑iş‑parçacıklı süreçler ve bağımsız sunum örnekleri kullanın; detaylar için [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/tr/python-net/multithreading/) bölümü incelenebilir.

## **SSS**

**Kaynak sunumların orijinal tasarımını nasıl korurum?**

Hedef master veya layout sağlamadan [`add_clone(source_slide)`](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/add_clone/) kullanın. Aspose.Slides, içe aktarılan slayt ihtiyaç duyduğunda kaynak master’ı otomatik olarak klonlayabilir.

**İçe aktarılan slaytların hedef temayı kullanmasını nasıl sağlarım?**

Hedef master kabul eden aşırı yüklemeyi kullanın. Master’ı kaynak sunumdan değil, hedef sunumdan seçin. Aspose.Slides, her kaynak slaytı o master altında uygun bir layout’a eşlemeye çalışır.

**Bir hedef layout yerine hedef master ne zaman kullanılmalı?**

Her içe aktarılmış slaydın aynı bilinen layout’u kullanması gerekiyorsa belirli bir layout kullanın. Layout tipine veya adına göre master altındaki layout’ların seçilmesi isteniyorsa master kullanın.

**Farklı slayt boyutlarına sahip sunumlar birleştirilebilir mi?**

Evet, ancak slayt içeriği hedef boyutlara otomatik olarak yeniden tasarlanmamaktadır. Öngörülebilir yerleşim için önce [SlideSize.set_size](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidesize/set_size/) ve [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidesizescaletype/) ile kaynak sunumu yeniden boyutlandırın.

**PPT, PPTX ve ODP sunumlarını tek bir dosyada birleştirebilir miyim?**

Evet. Her kaynak sunumu yükleyin, gerekli slaytları tek bir hedefe klonlayın ve hedefi desteklenen bir çıktı formatında kaydedin. Sunum formatları aynı özellik kümesini tam olarak desteklemediği için, formatlar arası birleştirmeler sonrası karmaşık içeriği doğrulayın. [Supported File Formats](https://docs.aspose.com/slides/tr/python-net/supported-file-formats/) incelenebilir.

**Kaynak bölümler otomatik olarak korunur mu?**

Sadece slaytları klonlayan temel bir döngü bölümleri korumaz. Gerekli bölümleri hedefte yeniden oluşturun ve bölüm yapısının korunması gerektiğinde [add_clone](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/add_clone/) bölüm aşırı yüklemesini kullanın.

**Konuşmacı notları ve yorumlar korunur mu?**

Klonlanan slaytla birlikte kopyalanır. Not‑master stilizasyonu, yorum yazarları veya dizili inceleme verileri gibi senaryolar için birleştirilmiş sonucu doğrulayın; çünkü bu durumlar hem sunum‑seviyesi hem de slayt‑seviyesi yapıları içerir.

**Ses, video, OLE nesneleri ve köprüler ne olur?**

Gömülü içerik, klonlanan slaydın kaynak ilişkileri içinde taşınır. Harici bağlantılar dışarıda kalır; bu nedenle hedef ortamda bağlantıların hedef dosyaları veya URL’leri hâlâ mevcut olmalıdır.

**Her kaynaktan gömülü yazı tipleri birleşik sunumda garanti edilir mi?**

Yalnızca slayt klonlamaya güvenmeyin. Hedefteki gömülü yazı tiplerini inceleyin ve tipografi önemliyse yazı tipi gömmeyi veya harici yazı tipi kullanılabilirliğini açıkça yönetin.

**Parola korumalı bir dosyayı nasıl birleştiririm?**

Doğru [LoadOptions.password](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/password/) ile açın, ardından slaytlarını normal şekilde klonlayın. Çıktı koruması ayrı olarak yapılandırılır.

**Çok büyük sunumları nasıl yönetirim?**

Büyük ikili nesneler bellek kullanımını hâkimiyetle etkiliyorsa BLOB yönetimini kullanın, çok büyük dosyalar için dosya‑yolu yüklemeyi tercih edin, kaynak sunumları birleştirildikten hemen sonra kapatın ve son sonucu yalnızca gerektiğinde kaydedin.

**Slaytları birden fazla iş parçacığından birleştirebilir miyim?**

[Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneklerini birden çok iş parçacığından aynı anda yüklemeyin, kaydetmeyin veya klonlamayın. Her bir birleştirme işlemine tek iş parçacıklı yaklaşın; bağımsız birleştirme işleri paralel yapılacaksa ayrı tek‑iş‑parçacıklı süreçler ve bağımsız sunum örnekleri kullanın.