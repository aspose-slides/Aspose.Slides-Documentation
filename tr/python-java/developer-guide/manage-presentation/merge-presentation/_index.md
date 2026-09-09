---
title: Python üzerinden Java kullanarak Sunumları Verimli Bir Şekilde Birleştirme
linktitle: Sunumları Birleştir
type: docs
weight: 40
url: /tr/python-java/merge-presentation/
keywords:
- PowerPoint birleştir
- Sunumları birleştir
- Slaytları birleştir
- PPT birleştir
- PPTX birleştir
- ODP birleştir
- PowerPoint birleştir
- Sunumları birleştir
- Slaytları birleştir
- PPT birleştir
- PPTX birleştir
- ODP birleştir
- Python
- Java
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını Python üzerinden Java ile slaytları klonlayarak, master ve yerleşimleri kontrol ederek, slayt içeriğini yeniden boyutlandırarak, bölümleri koruyarak ve korumalı ya da büyük dosyalarla başa çıkarak nasıl birleştireceğinizi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Python via Java, bir sunumu başka bir sunuma slaytları klonlayarak birleştirir. Ana işlem [SlideCollection.addClone](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#addClone) olup, kaynak slaydın biçimlendirmesini koruyabilir ya da klonlanan slaytı hedef sunumdaki bir mastera veya yerleşime ekleyebilir.

Bu makale en yaygın birleştirme iş akışlarını kapsar:

- tüm slaytları kaynak biçimlendirmesini koruyarak birleştir;
- seçili slaytları birleştir;
- hedef sunumdan bir master uygula;
- hedef sunumdan belirli bir yerleşim uygula;
- birleştirmeden önce farklı slayt boyutlarını normalleştir;
- klonlanan slaytları bir bölüme ekle;
- birden fazla sunumu uçtan uca bir iş akışında birleştir;
- masterları, kaynakları, notları, yorumları, medyaları, yazı tiplerini, parolaları, büyük dosyaları ve çoklu iş parçacığı sorunlarını yönet.

## **Slayt Klonlamanın Masterlar ve Yerleşimler Üzerindeki Etkisi**

Bir slayt, görünümünün büyük bir kısmını yerleşim ve masterından miras alır. Bu nedenle, seçtiğiniz klonlama aşırı yüklemesi, birleştirilen slaydın hedef sunuma nasıl bütünleştirileceğini belirler.

Bu yöntemlerden birinde [SlideCollection.addClone](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#addClone) kullanın:

- `addClone(source_slide)` — kaynak slaydın yerleşimini ve biçimlendirmesini korur. Gerektiğinde, kaynak master otomatik olarak hedef sunuma klonlanabilir. Aspose.Slides, otomatik klonlanan masterları izler, böylece aynı kaynak masterı kullanan tekrar eden slaytlar masterın tekrar klonlanmasına neden olmaz.
- `addClone(source_slide, destination_master, allow_clone_missing_layout)` — klonlanan slaytı belirli bir hedef [MasterSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslide/) içine ekler. Aspose.Slides, bu master altında yerleşim tipine ya da adına göre eşleşen bir yerleşim arar.
- `addClone(source_slide, destination_layout)` — klonlanan slaytı doğrudan belirli bir hedef [LayoutSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutslide/) içine ekler.

Bir `addClone` aşırı yüklemesine geçirilen master veya yerleşim, **hedef** sunuma ait olmalıdır, kaynak sunuma değil.

## **Tüm Sunumları Birleştir ve Kaynak Biçimlendirmesini Koru**

En basit birleştirme, kaynak sunumdaki her slaytı hedef sunuma kopyalar. Bu, içe aktarılan slaydların özgün temalarını, masterlarını ve yerleşim ilişkilerini koruması gerektiğinde uygun seçimdir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        for slide in source.getSlides():
            destination.getSlides().addClone(slide)
    finally:
        source.dispose()

    destination.save("merged.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Kaynak ve hedef farklı tasarımlar kullandığında ortaya çıkan sunum birden fazla master içerebilir. Kaynak biçimlendirmesinin kasıtlı olarak korunması durumunda bu beklenen bir durumdur.

## **Seçili Slaytları Birleştir**

Her slaytı klonlamak zorunda değilsiniz. Aşağıdaki örnek, kaynak sunumdan yalnızca seçili slayt indekslerini içe aktarır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        slide_indexes = [0, 2, 4]
        for index in slide_indexes:
            if 0 <= index < source.getSlides().size():
                destination.getSlides().addClone(source.getSlides().get_Item(index))
            else:
                print(f"Skipping invalid slide index: {index}")
    finally:
        source.dispose()

    destination.save("merged-selected-slides.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Kullanıcı girdisi ya da dış yapılandırmadan gelen slayt indekslerini klonlamadan önce doğrulayın.

## **Bir Hedef Master Kullanarak Slaytları Birleştir**

İçe aktarılan slaydların zaten hedef sunuma ait bir masterı takip etmesi gerektiğinde [SlideCollection.addClone](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#addClone) aşırı yüklemesini kullanın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        destination_master = destination.getMasters().get_Item(0)
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, destination_master, True)
    finally:
        source.dispose()

    destination.save("merged-with-destination-master.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Aspose.Slides, kaynak yerleşimin tipine ya da adına göre belirtilen master altında uygun bir yerleşim seçer. Uygun bir yerleşim bulunmaz ve `allow_clone_missing_layout` `True` ise, slayt eklenebilmesi için kaynak yerleşim klonlanır. `False` ise bir [PptxEditException](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pptxeditexception/) fırlatılır.

Ek bir yerleşim eklemek yerine birleştirmenin başarısız olmasını istiyorsanız `False` kullanın.

## **Belirli Bir Hedef Yerleşim Kullanarak Slaytları Birleştir**

İçe aktarılan slaytların kesinlikle belirli bir hedef yerleşimini kullanması gerektiğinde [SlideCollection.addClone](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#addClone) aşırı yüklemesini kullanın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        destination_layout = destination.getLayoutSlides().get_Item(0)
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, destination_layout)
    finally:
        source.dispose()

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Bir hedef yerleşim uygulanması, kalıtılmış yerleşim ilişkisini değiştirir; kaynak slayt içeriğini yeniden tasarlamaz. Kaynak ve hedef yerleşimlerin yer tutucu yapıları farklıysa, kalıtılmış biçimlendirme ve yer tutucu davranışının uygun olduğunu doğrulamak için sonucu inceleyin.

## **Farklı Slayt Boyutlarına Sahip Sunumları Birleştir**

Farklı slayt boyutlarına sahip sunumlar birleştirilebilir, ancak bir slaytı farklı bir slayt boyutuna sahip bir sunuma klonlamak içeriklerini yeni tuval için otomatik olarak yeniden tasarlamaz. Şekiller bu nedenle kaymış, beklenmedik ölçekte ölçeklenmiş veya görünür slayt alanının dışına çıkmış görünebilir.

Pratik bir yaklaşım, klonlamadan önce kaynak sunumu yeniden boyutlandırmaktır. [SlideSize.setSize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidesize/#setSize) yöntemi, slayt boyutlarını değiştirirken mevcut içeriği ölçeklendirebilir. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidesizescaletype/) içeriği istenen boyuta sığdırmak için ölçeklendirir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        source_size = source.getSlideSize().getSize()
        destination_size = destination.getSlideSize().getSize()
        width = jpype.JFloat(destination_size.getWidth())
        height = jpype.JFloat(destination_size.getHeight())
        if source_size.getWidth() != width or source_size.getHeight() != height:
            source.getSlideSize().setSize(width, height, SlideSizeScaleType.EnsureFit)

        for slide in source.getSlides():
            destination.getSlides().addClone(slide)
    finally:
        source.dispose()

    destination.save("merged-same-slide-size.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Yeniden boyutlandırma, kaynak sunum nesnesini bellekte değiştirir. Orijinal kaynak sunumun diğer işlemler için değişmeden kalması gerekiyorsa, birleştirme için ayrı bir örnek açın.

## **Slaytları Bir Sunum Bölümüne Birleştir**

Temel slayt‑klonlama döngüsü, kaynak sunumun bölüm hiyerarşisini yeniden oluşturmaz. Bölümler çıktıda önemliyse, hedef sunumda bölümler oluşturun veya seçin ve slaytları açıkça [SlideCollection.addClone](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#addClone) ile bu bölümlere klonlayın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        imported_section = destination.getSections().appendEmptySection("Imported slides")
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, imported_section)
    finally:
        source.dispose()

    destination.save("merged-with-section.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Klonlanan slaytlar belirtilen hedef bölüme eklenir. Birden fazla kaynak bölümü korumak için [Presentation.getSections](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getSections) döngüsüyle bölümleri sayın, her kaynak bölümün mevcut slaytlarını [Section.getSlidesListOfSection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/section/#getSlidesListOfSection) ile alın, hedefte bölümleri yeniden oluşturun ve her döndürülen slaytı karşılık gelen hedef bölümüne klonlayın. Boş bölümler ve yapısal değişiklikler dahil olmak üzere tam bölüm‑sayma örneği için [Manage Slide Sections](/slides/tr/python-java/slide-section/) sayfasına bakın.

## **Birden Çoq Sunumu Güvenli Bir Şekilde Birleştir**

Aşağıdaki uçtan uca örnek, ilk sunumu hedef olarak kullanır, her ek kaynak için slayt boyutunu normalleştirir, her kaynağı yalnızca kopyalanırken açık tutar ve sonunda dosyayı bir kez kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

input_files = ["part1.pptx", "part2.pptx", "part3.pptx"]

merged = Presentation(input_files[0])
try:
    merged_size = merged.getSlideSize().getSize()
    width = jpype.JFloat(merged_size.getWidth())
    height = jpype.JFloat(merged_size.getHeight())

    for input_file in input_files[1:]:
        source = Presentation(input_file)
        try:
            source_size = source.getSlideSize().getSize()
            if source_size.getWidth() != width or source_size.getHeight() != height:
                source.getSlideSize().setSize(width, height, SlideSizeScaleType.EnsureFit)

            for slide in source.getSlides():
                merged.getSlides().addClone(slide)
        finally:
            source.dispose()

    merged.save("merged.pptx", SaveFormat.Pptx)
finally:
    merged.dispose()
```

Bu, içe aktarılan slaytların kaynak biçimlendirmesini korumak için faydalı bir temel sunar. Çıktınız tek bir hedef teması kullanmalıysa, basit `addClone(slide)` çağrısını daha önce gösterilen uygun hedef‑master veya hedef‑layout aşırı yüklemesiyle değiştirin.

## **Pratik Hususlar**

### **Masterlar, Yerleşimler ve Biçimlendirme Doğruluğu**

Varsayılan slayt klonlaması, gereken bir kaynak masterı otomatik olarak hedef sunuma getirebilir. Aspose.Slides, aynı masterın tekrarlı klonlanmasını önlemek için otomatik klonlanan masterları içsel bir kayıt defterinde tutar. Manuel olarak klonlanan masterlar bu kayıt defterine eklenmez; bu nedenle master yapısı üzerinde kesin kontrol ihtiyacınız yoksa ön‑klonlamaktan kaçının.

Aynı ada sahip iki master veya yerleşimin görsel olarak eşdeğer olduğunu varsaymayın. Bir kurumsal şablon nihai görünümü denetlemesi gerekiyorsa, hedef masterı veya yerleşimi açıkça seçin ve birleştirmeden sonra sonucu doğrulayın.

### **Notlar ve Yorumlar**

Sunucu notları ve slayt yorumları slayt içeriğiyle ilişkilidir ve slayt klonlandığında kopyalanır. Aspose.Slides ayrıca [sunum notları](/slides/tr/python-java/presentation-notes/) ve [sunum yorumları](/slides/tr/python-java/presentation-comments/) için özel API’ler sunar.

Not sayfası biçimlendirmesi önemliyse, not masterlarının sunum‑seviyesi nesneler olduğunu ve kaynak dosyalar arasında farklılık gösterebileceğini unutmayın; birleştirilmiş sunumu doğrulayın. İnceleme iş akışları için, farklı yazarların veya şablonların birleştirilmesinden sonra yorum yazarlarını ve zincirli yorumları da kontrol edin.

### **Görseller, Ses, Video, OLE Nesneleri ve Dış Bağlantılar**

Slaytlar, görüntüler, gömülü ses, gömülü video ve OLE verileri gibi sunum‑seviyesi kaynaklara referans verebilir. Yalnızca görünen şekilleri kopyalamak yerine slaytı tamamen klonlayın; böylece Aspose.Slides, slaydın bu kaynaklarla ilişkisini korur.

Gömülü ve bağlantılı kaynaklar farklı şekilde ele alınmalıdır. Bağlantılı bir ses, video, OLE nesnesi veya köprü, dış hedefine bağımlı kalır; slaytı klonlamak dış bağlantıyı gömülü içeriğe dönüştürmez. Bağlantılı kaynak yollarını ve URL’leri, birleştirilmiş sunumun açılacağı ortamda test edin.

Aspose.Slides otomatik klonlanan masterları izler, ancak bu, ilişkili olmayan kaynak sunumlardan gelen aynı ikili dosyaların her zaman deduplikasyon yapılacağı anlamına gelmez. Çıktı dosya boyutu önemliyse, birleştirilmiş paketi inceleyin ve sonucu ölçün; örtük deduplikasyona güvenmeyin.

### **Gömülü Yazı Tipleri ve Yazı Tipi Kullanılabilirliği**

Yazı tipleri sunum‑seviyesinde yönetilir. Tipografi farklı makinelerde tutarlı kalmalıysa, sadece slayt klonlamanın her gerekli yazı tipinin hedef ortamda bulunmasını garanti etmediğini varsamayın. Gömülü yazı tiplerini [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) ile inceleyebilir ve [Presentasyonlarda Yazı Tipi Gömme](/slides/tr/python-java/embedded-font/) bölümünde açıklandığı gibi gömme işlemini açıkça yönetebilirsiniz.

Ayrıca, kaynak dosyalarda kullanılan yazı tiplerini gömmeye izin verilip verilmediğini doğrulayın. Yazı tipi lisansları gömme hakkını kısıtlayabilir.

### **Parola Koruması Olan Sunumlar**

Parola korumalı bir kaynak, slaytları klonlamadan önce başarıyla açılmalıdır. Parolayı [LoadOptions.setPassword](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setPassword) aracılığıyla sağlayın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions

load_options = LoadOptions()
load_options.setPassword("YOUR_PASSWORD")

source = Presentation("protected.pptx", load_options)
try:
    # Şifrelenmiş sunumla çalış.
    print(f"Loaded {source.getSlides().size()} slides.")
finally:
    source.dispose()
```

Şifreli bir kaynağı açmak, aynı korumayı otomatik olarak hedef sunuma uygulamaz. Gerekirse çıktı korumasını ayrı olarak yapılandırın.

### **Büyük Sunumlar ve Bellek Kullanımı**

Yüksek çözünürlüklü görüntüler, ses, video veya diğer büyük ikili nesneler içeren büyük sunumlar önemli bellek tüketebilir. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) BLOB yönetimi ve geçici dosya kullanımını kontrol etme imkanı sağlar. Büyük‑dosya stratejileri için [Sunum BLOBlarını Yönet](/slides/tr/python-java/manage-blob/) sayfasına bakın.

Büyük dosyalar için mümkün olduğunca dosya yolu üzerinden yüklemeyi tercih edin, her kaynak sunumu birleştirildikten hemen sonra serbest bırakın ve iş akışı kontrol noktaları gerektirmedikçe ara sonuçları tekrar tekrar kaydetmekten kaçının.

### **İş Parçacığı Güvenliği**

Aynı [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örneğini birden çok iş parçacığından aynı anda yüklemeyin, değiştirmeyin, kaydetmeyin veya klonlamayın. Her sunum örneğini tek bir birleştirme işlemiyle sınırlı tutun. Bağımsız işleri paralelleştiriyorsanız, bağımsız sunum örnekleri kullanın ve [Aspose.Slides çoklu iş parçacığı rehberi](/slides/tr/python-java/multithreading/) izleyin.

## **SSS**

**Kaynak sunumların orijinal tasarımını nasıl korurum?**

Hedef master ya da yerleşim sağlamadan `addClone` kullanın. Aspose.Slides, içe aktarılan slayt tarafından ihtiyaç duyulduğunda kaynak masterı otomatik olarak klonlayabilir.

**İçe aktarılan slaytların hedef temayı kullanmasını nasıl sağlarım?**

Hedef master kabul eden aşırı yüklemeyi kullanın. Masterı kaynak sunumdan değil, hedef sunumdan seçin. Aspose.Slides, her kaynak slaytı o master altında uygun bir yerleşime eşlemeye çalışır.

**Belirli bir hedef yerleşim yerine bir hedef master ne zaman kullanılmalı?**

Her içe aktarılan slaydın aynı bilinen yerleşimi kullanması gerektiğinde belirli bir yerleşim seçin. Bir master, kaynak yerleşim tipine veya adına göre master’ın yerleşimleri arasından seçim yapılmasını istediğinizde kullanılır.

**Farklı slayt boyutlarına sahip sunumlar birleştirilebilir mi?**

Evet, ancak slayt içeriği hedef boyutlar için otomatik olarak yeniden tasarlanmamaktadır. Öngörülebilir konumlandırma için önce [SlideSize.setSize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidesize/#setSize) ve [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidesizescaletype/) ile kaynak sunumu yeniden boyutlandırın.

**PPT, PPTX ve ODP sunumlarını tek bir dosyada birleştirebilir miyim?**

Evet. Her kaynak sunumu yükleyin, gerekli slaytları tek bir hedefe klonlayın ve hedefi desteklenen bir çıktı formatında kaydedin. Sunum formatları aynı özellik setini tam olarak desteklemediği için çapraz‑format birleştirmelerden sonra karmaşık içeriği doğrulayın. Desteklenen dosya formatları için [Supported File Formats](/slides/tr/python-java/supported-file-formats/) sayfasına bakın.

**Kaynak bölümler otomatik olarak korunur mu?**

Sadece slaytları klonlayan temel döngü bölümleri otomatik olarak korumaz. Hedefte gerekli bölümleri yeniden oluşturun ve bölüm yapısı korunmalıysa [addClone](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#addClone) bölüm aşırı yüklemesini kullanın.

**Sunucu notları ve yorumlar korunur mu?**

Klonlanan slaytla birlikte kopyalanır. Not‑master stilizasyonu, yorum yazarları veya zincirli inceleme verileri gibi sunum‑seviyesi yapılarla ilişkili senaryolar için birleştirilmiş sonucu doğrulayın.

**Ses, video, OLE nesneleri ve köprüler ne olur?**

Gömülü içerik, klonlanan slaydın kaynak ilişkileriyle birlikte taşınır. Dış bağlantılar dış hedeflerine bağımlı kalır; slaytı klonlamak dış bağlantıyı gömülü içeriğe dönüştürmez. Bağlantılı kaynak yollarını ve URL’leri, birleştirilmiş sunumun açılacağı ortamda test edin.

**Her kaynaktan gelen gömülü yazı tiplerinin birleştirilmiş sunumda mevcut olması garantilenir mi?**

Sadece slayt klonlamaya dayanarak tüm gerekli yazı tiplerinin hedef ortamda bulunacağını varsaymayın. Hedefteki gömülü yazı tiplerini inceleyin ve tipografi önemliyse yazı tiplerini açıkça gömme ya da dış yazı tiplerinin erişilebilirliğini yönetin.

**Parola korumalı bir dosyayı nasıl birleştiririm?**

Doğru [LoadOptions.setPassword](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setPassword) ile dosyayı açın, ardından slaytlarını normal şekilde klonlayın. Çıktı koruması ayrı olarak yapılandırılır.

**Çok büyük sunumları nasıl yönetmeliyim?**

BLOB yönetimi kullanın, mümkün olduğunca dosya yolu üzerinden yükleyin, her kaynak sunumu birleştirildikten hemen sonra serbest bırakın ve iş akışı gerektirmedikçe ara sonuçları sık sık kaydetmeyin.

**Birden fazla iş parçacığından slaytları birleştirebilir miyim?**

Aynı [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örneğini birden çok iş parçacığında aynı anda yüklemeyin, değiştirmeyin, kaydetmeyin veya klonlamayın. Her birleştirme işlemini kendi bağımsız sunum örnekleriyle izole tutun.