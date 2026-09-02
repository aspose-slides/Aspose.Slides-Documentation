---
title: Python ile Sunumları Verimli Bir Şekilde Birleştirme
linktitle: Sunumları Birleştir
type: docs
weight: 40
url: /tr/python-net/merge-presentation/
keywords:
- PowerPoint birleştir
- sunumları birleştir
- slaytları birleştir
- PPT birleştir
- PPTX birleştir
- ODP birleştir
- PowerPoint birleştir
- sunumları birleştir
- slaytları birleştir
- PPT birleştir
- PPTX birleştir
- ODP birleştir
- Python
- Aspose.Slides
description: "Python'da slaytları klonlayarak, master ve layout'ları kontrol ederek, slayt içeriğini yeniden boyutlandırarak, bölümleri koruyarak ve korumalı ya da büyük dosyaları yöneterek PowerPoint ve OpenDocument sunumlarını nasıl birleştirileceğini öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Python via .NET, bir sunumu başka birine kopyalanan slaytları klonlayarak birleştirir. Ana işlem, [SlideCollection.add_clone](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/add_clone/) olup, kaynak slaytın biçimlendirmesini koruyabilir veya klonlanan slaytı hedef sunumdaki bir mastera ya da düzene (layout) ekleyebilir.

Bu makale en yaygın birleştirme iş akışlarını kapsar:

- tüm slaytları, kaynak biçimlendirmesini koruyarak birleştir;
- seçili slaytları birleştir;
- hedef sunumdan bir master uygula;
- hedef sunumdan belirli bir layout uygula;
- birleştirmeden önce farklı slayt boyutlarını normalleştir;
- klonlanan slaytları bir bölümde ekle;
- birden fazla sunumu tek uçtan‑ucu iş akışında birleştir;
- masterlar, kaynaklar, notlar, yorumlar, medya, yazı tipleri, şifreler, büyük dosyalar ve çoklu iş parçacığı konularını yönet.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç sunumu, kaynak ve hedef farklı tasarımlara sahipse birden çok master içerebilir. Bu, kaynak biçimin kasıtlı olarak korunduğu durumlarda beklenen bir durumdur.

## **Seçili Slaytları Birleştir**

Her slaytı klonlamak zorunda değilsiniz. Aşağıdaki örnek, kaynak sunumdan yalnızca seçili slayt indekslerini içe aktarır.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        slide_indexes = [0, 2, 4]

        for index in slide_indexes:
            destination.slides.add_clone(source.slides[index])

        destination.save("merged-selected-slides.pptx", slides.export.SaveFormat.PPTX)
```

Kullanıcı girdisinden veya harici yapılandırmadan gelen indeksleri klonlamadan önce doğrulayın.

## **Hedef Master Kullanarak Slaytları Birleştir**

İçe aktarılan slaytların zaten hedef sunuma ait bir mastera uyması gerektiğinde, [add_clone(source_slide, destination_master, allow_clone_missing_layout)](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/add_clone/) aşırı yüklemesini kullanın.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_master = destination.masters[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_master, True)

        destination.save("merged-with-destination-master.pptx", slides.export.SaveFormat.PPTX)
```

Aspose.Slides, belirtilen master altında kaynak layoutun türü veya adı ile eşleşen uygun bir layout seçer. Uygun bir layout bulunmazsa ve `allow_clone_missing_layout` **True** ise, kaynak layout klonlanır ve slayt eklenebilir. **False** olduğunda ise bir [PptxEditException](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pptxeditexception/) fırlatılır.

Ek bir layout eklemek istemiyorsanız **False** kullanın; böylece birleştirme başarısız olur.

## **Belirli Bir Hedef Layout Kullanarak Slaytları Birleştir**

İçe aktarılan slaytların kesin olarak hangi hedef layoutu kullanması gerektiğini biliyorsanız, [add_clone(source_slide, destination_layout)](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/add_clone/) aşırı yüklemesini kullanın.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_layout = destination.layout_slides[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_layout)

        destination.save("merged-with-destination-layout.pptx", slides.export.SaveFormat.PPTX)
```

Bir hedef layout uygulamak, kalıtılmış layout ilişkisinde değişiklik yapar; kaynak slayt içeriğini yeniden tasarlamaz. Kaynak ve hedef layoutların yer tutucu yapıları farklıysa, kalıtılmış biçimlemenin ve yer tutucu davranışının uygun olduğunu doğrulamak için sonucu inceleyin.

## **Farklı Slayt Boyutlarına Sahip Sunumları Birleştir**

Farklı slayt boyutlarına sahip sunumlar birleştirilebilir, ancak bir slaytı başka bir slayt boyutuna sahip bir sunuma klonlamak, içeriği yeni tuval için otomatik olarak yeniden tasarlamaz. Şekiller bu nedenle kaymış, beklenmedik şekilde ölçeklenmiş ya da görünür slayt alanının dışına çıkmış görünebilir.

Pratik bir yaklaşım, klonlamadan önce kaynak sunumu yeniden boyutmaktır. [SlideSize.set_size](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidesize/set_size/) yöntemi, slayt boyutlarını değiştirirken mevcut içeriği ölçeklendirebilir. [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidesizescaletype/) ise içeriği istenen boyuta sığdırmak için ölçeklendirir.

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

Temel slayt‑klonlama döngüsü, kaynak sunumun bölüm hiyerarşisini yeniden oluşturmaz. Çıktıda bölümler önemliyse, hedef sunumda bölümler oluşturun veya seçin ve slaytları açıkça [SlideCollection.add_clone](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/add_clone/) ile bu bölümlere klonlayın.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        imported_section = destination.sections.append_empty_section("Imported slides")

        for slide in source.slides:
            destination.slides.add_clone(slide, imported_section)

        destination.save("merged-with-section.pptx", slides.export.SaveFormat.PPTX)
```

Klonlanan slaytlar belirtilen hedef bölüme eklenir. Birden fazla kaynak bölümü korumak için, [Presentation.sections](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/sections/) üzerinden yineleme yapın, her kaynak bölümün mevcut slaytlarını [Section.get_slides_list_of_section](https://reference.aspose.com/slides/tr/python-net/aspose.slides/section/get_slides_list_of_section/) ile alın, bölümleri hedefte yeniden oluşturun ve her dönen slaytı ilgili hedef bölümüne klonlayın. Boş bölümler ve yapısal değişiklikler dahil tam bir bölüm‑yineleme örneği için [Slayt Bölümlerini Yönet](/slides/tr/python-net/slide-section/) sayfasına bakın.

## **Birden Çok Sunumu Güvenli Bir Şekilde Birleştir**

Aşağıdaki uçtan‑uca örnek, ilk sunumu hedef olarak kullanır, ek her kaynak sunumun slayt boyutunu normalleştirir, her kaynağı yalnızca kopyalanırken açık tutar ve sonunda tek bir dosyayı kaydeder.

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

Bu, içe aktarılan slaytların kaynak biçimlendirmesini korumak için yararlı bir temel oluşturur. Çıktınızın tek bir hedef teması olması gerekiyorsa, basit `add_clone(slide)` çağrısını daha önce gösterilen uygun hedef‑master veya hedef‑layout aşırı yüklemesiyle değiştirin.

## **Pratik Hususlar**

### **Masterlar, Layoutlar ve Biçimlendirme Doğruluğu**

Varsayılan slayt klonlaması, gerekli bir kaynak masterı otomatik olarak hedef sunuma getirebilir. Aspose.Slides, aynı masterın tekrar tekrar klonlanmasını önlemek için otomatik klonlanan masterları içeren bir iç kayıt tutar. Manuel klonlanan masterlar bu kayıt tarafından izlenmez; bu yüzden master yapısını açıkça kontrol etmeniz gerekiyorsa önceden klonlamaktan kaçının.

Aynı ada sahip iki master veya layoutun görsel olarak eşdeğer olduğunu varsaymayın. Kurumsal bir şablon nihai görünümü yönetiyorsa, hedef masterı veya layoutu açıkça seçin ve birleştirme sonrası sonucu doğrulayın.

### **Notlar ve Yorumlar**

Sunucu notları ve slayt yorumları slayt içeriğiyle ilişkilidir ve bir slayt klonlandığında kopyalanır. Aspose.Slides ayrıca [sunum notları](/slides/tr/python-net/presentation-notes/) ve [sunum yorumları](/slides/tr/python-net/presentation-comments/) için özel API’ler sunar.

Not sayfası biçimlendirmesi önemliyse, not masterlarının sunum‑seviyesinde nesneler olduğunu ve kaynak dosyalar arasında farklılık gösterebileceğini unutmayın; birleştirilmiş sunumu bu yüzden doğrulayın. Gözden geçirme iş akışlarında, farklı yazarların ya da şablonların birleştirildiği dosyalarda yorum yazarlarını ve dizili yorumları da kontrol edin.

### **Resimler, Ses, Video, OLE Nesneleri ve Harici Bağlantılar**

Slaytlar, resimler, gömülü ses, gömülü video ve OLE verileri gibi sunum‑seviyesi kaynaklara başvurabilir. Sadece görünür şekilleri kopyalamak yerine slaytı bütün olarak klonlayın; böylece Aspose.Slides, slaytın kaynaklarla olan ilişkilerini korur.

Gömülü ve bağlantılı kaynaklar farklı şekilde ele alınmalıdır. Bağlantılı bir ses, video, OLE nesnesi ya da köprü, harici hedefine bağımlı kalır; slaytı klonlamak harici bir bağlantıyı gömülü içeriğe dönüştürmez. Bağlantılı kaynak yollarını ve URL’leri, birleştirilmiş sunumun açılacağı ortamda test edin.

Aspose.Slides otomatik klonlanan masterları izlese de, ilişkili olmayan kaynak sunumlardan gelen aynı ikili kaynakların her zaman otomatik olarak tekilleştirileceği garantisi yoktur. Çıktı dosya boyutu önemliyse, birleştirilmiş paketi inceleyin ve sonucu ölçün; örtük tekilleştirmeye güvenmeyin.

### **Gömülü Yazı Tipleri ve Yazı Tipi Kullanılabilirliği**

Yazı tipleri sunum seviyesinde yönetilir. Tipografi farklı makinelerde tutarlı kalmalıysa, yalnızca slayt klonlamanın gerekli tüm yazı tiplerinin hedef ortamda bulunacağını varsamayın. Gömülü yazı tiplerini [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) ile inceleyebilir ve [Sunumlarda Yazı Tipi Gömme](/slides/tr/python-net/embedded-font/) bölümünde açıklandığı gibi gömme işlemini açıkça yönetebilirsiniz.

Ayrıca, kaynak dosyalarda kullanılan yazı tiplerini gömmeye izin verilip verilmediğini doğrulayın. Yazı tipi lisansları gömme hakkını kısıtlayabilir.

### **Şifre Koruması Altındaki Sunumlar**

Şifre korumalı bir kaynağın slaytları klonlanmadan önce başarıyla açılmalıdır. Şifreyi [LoadOptions.password](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/password/) aracılığıyla sağlayın.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("protected.pptx", load_options) as source:
    print(len(source.slides))
```

Şifreli bir kaynağı açmak, aynı korumanın hedef sunuma otomatik olarak uygulanmasını sağlamaz. Gerekirse çıktı korumasını ayrı olarak yapılandırın.

### **Büyük Sunumlar ve Bellek Kullanımı**

Yüksek çözünürlüklü resimler, ses, video veya diğer büyük ikili nesneler içeren büyük sunumlar önemli miktarda bellek tüketebilir. [LoadOptions.blob_management_options](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/blob_management_options/) BLOB yönetimi ve geçici dosya kullanımını kontrol eder. Büyük‑dosya stratejileri için [Sunum BLOB’larını Yönet](/slides/tr/python-net/manage-blob/) sayfasına bakın.

Büyük dosyalar için mümkün olduğunca dosya yollarından yükleme tercih edin, her kaynak sunumu birleştirme tamamlandığında hemen kapatın ve iş akışı kontrol noktaları gerektirmiyorsa ara sonuçları tekrar tekrar kaydetmekten kaçının. `with slides.Presentation(...)` kullanmak, bağlam sona erdiğinde sunum kaynaklarının serbest bırakılmasını sağlar.

### **İş Parçacığı Güvenliği**

Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneğini aynı anda birden çok iş parçacığından yüklemeyin, kaydetmeyin veya klonlamayın. Her bir birleştirme işlemini tek iş parçacığında tutun. Bağımsız birleştirme görevlerini paralelleştiriyorsanız, ayrı tek‑iş parçacıklı süreçler ve bağımsız sunum örnekleri kullanın; bunun için [Aspose.Slides çoklu iş parçacığı yönergeleri](/slides/tr/python-net/multithreading/) sayfasına bakın.

## **SSS**

**Kaynak her bir sunumun orijinal tasarımını nasıl korurum?**

Hedef master veya layout sağlamadan [add_clone](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/add_clone/) kullanın. Aspose.Slides, içe aktarılan slayt tarafından ihtiyaç duyulduğunda kaynak masterı otomatik olarak klonlayabilir.

**İçe aktarılan slaytların hedef temayı kullanmasını nasıl sağlarım?**

Hedef masterı kabul eden aşırı yüklemeyi kullanın. Masterı kaynak sunucudan değil, hedef sunucudan alın. Aspose.Slides, her kaynak slaytı o masterın uygun bir layoutu ile eşleştirmeye çalışır.

**Bir hedef master yerine belirli bir hedef layout ne zaman kullanılmalı?**

Her içe aktarılan slaytın aynı bilinen layoutu kullanması gerektiğinde belirli bir layout kullanın. Bir master kullanıldığında, Aspose.Slides kaynak layoutun türü veya adına göre o masterın layoutları arasından seçim yapar.

**Farklı slayt boyutlarına sahip sunumlar birleştirilebilir mi?**

Evet, ancak slayt içeriği hedef boyutlar için otomatik olarak yeniden tasarlanmamıştır. Öngörülebilir yerleşim gerekiyorsa, önce [SlideSize.set_size](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidesize/set_size/) ve [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidesizescaletype/) ile kaynak sunumu yeniden boyutlandırın.

**PPT, PPTX ve ODP sunumlarını tek bir dosyada birleştirebilir miyim?**

Evet. Her kaynak sunumu yükleyin, gerekli slaytları tek bir hedefe klonlayın ve hedefi desteklenen bir çıktı formatında kaydedin. Sunum formatları aynı özellik setini tam olarak desteklemediğinden, farklı formatlar arasında birleştirme yaptıktan sonra karmaşık içeriği doğrulayın. [Desteklenen Dosya Biçimleri](/slides/tr/python-net/supported-file-formats/) sayfasına bakın.

**Kaynak bölümler otomatik olarak korunur mu?**

Sadece slaytları klonlayan temel bir döngü bunun için yeterli değildir. Bölüm yapısını hedefte yeniden oluşturun ve bölüm yapısının korunması gerektiğinde [add_clone](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/add_clone/) aşırı yüklemesini kullanın.

**Sunucu notları ve yorumlar korunur mu?**

Klonlanan slaytla birlikte kopyalanır. Not‑master stilizasyonu, yorum yazarları veya dizili inceleme verileri gibi yapılar sunum‑seviyesinde bulunduğundan, birleştirilmiş sonucu bu senaryolar için doğrulayın.

**Ses, video, OLE nesneleri ve köprüler ne olur?**

Gömülü içerik, klonlanan slaytın kaynak ilişkileriyle birlikte taşınır. Harici köprüler harici kalır; hedef dosyalar veya URL’ler birleştirme sonrasında hâlâ erişilebilir olmalıdır.

**Her kaynaktan gelen gömülü yazı tipleri birleşik sunumda bulunur mu?**

Sadece slayt klonlamasıyla yazı tipi dağıtımına güvenmeyin. Hedefteki gömülü yazı tiplerini inceleyin ve tipografi önemliyse yazı tipi gömmeyi veya harici yazı tipi kullanılabilirliğini açıkça yönetin.

**Şifre korumalı bir dosyayı nasıl birleştiririm?**

Doğru [LoadOptions.password](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/password/) ile açın, ardından slaytlarını normal şekilde klonlayın. Çıktı koruması ayrı olarak yapılandırılır.

**Çok büyük sunumları nasıl yönetirim?**

Büyük ikili nesneler bellek kullanımını domine ettiğinde BLOB yönetimini kullanın, çok büyük dosyalar için dosya‑yolu yüklemeyi tercih edin, kaynak sunumları birleştirme tamamlandığında hemen kapatın ve yalnızca gerektiğinde nihai sonucu kaydedin.

**Slaytları birden çok iş parçacığından birleştirebilir miyim?**

[Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneklerini aynı anda birden çok iş parçacığından yüklemeyin, kaydetmeyin veya klonlamayın. Her bir birleştirme işleminde tek iş parçacığı tutun; ayrı birleştirme görevlerini paralel bir şekilde çalıştırmanız gerekiyorsa, bağımsız tek‑iş parçacıklı süreçler ve bağımsız sunum örnekleri kullanın.