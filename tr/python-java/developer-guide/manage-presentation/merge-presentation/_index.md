---
title: Python üzerinden Java ile Sunumları Verimli Bir Şekilde Birleştir
linktitle: Sunumları Birleştir
type: docs
weight: 40
url: /tr/python-java/merge-presentation/
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
- Java
- Aspose.Slides
description: "Python üzerinden Java ile PowerPoint ve OpenDocument sunumlarını slayt kopyalayarak, master ve yerleşimleri kontrol ederek, slayt içeriğini yeniden boyutlandırarak, bölümleri koruyarak ve korumalı ya da büyük dosyaları işleyerek nasıl birleştireceğinizi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Python via Java, slaytları bir [Sunum](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/)‘dan diğerine kopyalayarak sunumları birleştirir. Ana işlem [SlideCollection.addClone](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#addClone) olup, kaynak slaytın biçimlendirmesini koruyabilir veya kopyalanan slaytı hedef sunumdaki bir master veya yerleşime ekleyebilir.

Bu makale en yaygın birleştirme iş akışlarını kapsar:

- tüm slaytları kaynak biçimlendirmesini koruyarak birleştir;
- seçili slaytları birleştir;
- hedef sunumdan bir master uygula;
- hedef sunumdan belirli bir yerleşim uygula;
- birleştirmeden önce farklı slayt boyutlarını normalize et;
- kopyalanan slaytları bir bölüme ekle;
- birden fazla sunumu uçtan uca bir iş akışında birleştir;
- master'ları, kaynakları, notları, yorumları, medyaları, yazı tiplerini, şifreleri, büyük dosyaları ve çoklu iş parçacığı konularını ele al.

## **Slayt Kopyalamanın Master ve Yerleşimlere Etkisi**

Bir slayt görünümünün çoğunu yerleşim ve master’dan miras alır. Bu nedenle, seçtiğiniz kopyalama aşırı yüklemesi, birleştirilen slaytın hedef sunuma nasıl bütünleştirileceğini belirler.

`addClone(source_slide)` — kaynak slaytın yerleşimini ve biçimlendirmesini koru. Gerekirse, kaynak master otomatik olarak hedef sunuma kopyalanabilir. Aspose.Slides, aynı kaynak master'ı kullanan tekrarlanan slaytların aynı master'ı tekrar tekrar kopyalamasını önlemek için otomatik kopyalanan master'ları izler.

`addClone(source_slide, destination_master, allow_clone_missing_layout)` — kopyalanan slaytı belirli bir hedef [MasterSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslide/)'a bağla. Aspose.Slides, o master altında yerleşim tipine veya adına göre eşleşen bir yerleşim arar.

`addClone(source_slide, destination_layout)` — kopyalanan slaytı doğrudan belirli bir hedef [LayoutSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutslide/)'a bağla.

Bir `addClone` aşırı yüklemesine geçirilen master veya yerleşim, kaynak sunumun değil, **hedef** sunumun bir parçası olmalıdır.

## **Tüm Sunumları Birleştir ve Kaynak Biçimlendirmesini Koru**

En basit birleştirme, kaynak sunumdaki her slaytı hedef sunuma kopyalar. Bu, içe aktarılan slaytların özgün temalarını, master'larını ve yerleşim ilişkilerini koruması gerektiğinde uygun bir seçimdir.

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

Kaynak ve hedef farklı tasarımlar kullandığında sonuç sunum birden fazla master içerebilir. Bu, kaynak biçimlendirmesinin kasıtlı olarak korunması durumunda beklenen bir durumdur.

## **Seçili Slaytları Birleştir**

Her slaytı kopyalamanıza gerek yok. Aşağıdaki örnek, kaynak sunumdan sadece seçili slayt indekslerini içe aktarır.

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

Kullanıcı girişi veya dış yapılandırmadan gelen slayt indekslerini kopyalamadan önce doğrulayın.

## **Hedef Master Kullanarak Slaytları Birleştir**

İçe aktarılan slaytların zaten hedef sunuma ait bir master'ı takip etmesi gerektiğinde [SlideCollection.addClone](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#addClone) aşırı yüklemesini kullanın.

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

Aspose.Slides, belirtilen master altında kaynak yerleşimin tipine veya adına göre uygun bir yerleşim seçer. Uygun bir yerleşim yoksa ve `allow_clone_missing_layout` `True` ise, slayt eklenebilmesi için kaynak yerleşim kopyalanır. `False` ise bir [PptxEditException](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pptxeditexception/) fırlatılır.

Ek bir yerleşim eklemek yerine birleştirmenin başarısız olmasını istiyorsanız `False` kullanın.

## **Belirli Bir Hedef Yerleşim Kullanarak Slaytları Birleştir**

Kaynak slaytların hangi hedef yerleşimi kullanması gerektiğini kesin olarak bildiğinizde [SlideCollection.addClone](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#addClone) aşırı yüklemesini kullanın.

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

Bir hedef yerleşim uygulamak, miras alınan yerleşim ilişkisini değiştirir; kaynak slayt içeriğini yeniden tasarlamaz. Kaynak ve hedef yerleşimlerin yer tutucu yapıları farklıysa, miras alınan biçimlendirme ve yer tutucu davranışının uygun olduğunu doğrulamak için sonucu inceleyin.

## **Farklı Slayt Boyutlarına Sahip Sunumları Birleştir**

Farklı slayt boyutlarına sahip sunumlar birleştirilebilir, ancak bir slaytı başka bir slayt boyutuna sahip bir sunuma kopyalamak, içeriği yeni kanvas için otomatik olarak yeniden tasarlamaz. Şekiller bu nedenle kaydırılmış, beklenmedik ölçekte veya görünür slayt alanının dışına çıkmış görünebilir.

Pratik bir yaklaşım, kopyalamadan önce kaynak sunumu yeniden boyutlandırmaktır. [SlideSize.setSize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidesize/#setSize) yöntemi, slayt boyutlarını değiştirirken mevcut içeriği ölçeklendirebilir. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidesizescaletype/) içerikleri istenen boyuta sığdırmak için ölçeklendirir.

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

Yeniden boyutlandırma, bellek içinde kaynak sunum nesnesini değiştirir. Diğer işlemler için orijinal kaynak sunumun değişmemesi gerekiyorsa, birleştirme için ayrı bir örnek açın.

## **Slaytları Bir Sunum Bölümüne Birleştir**

Temel slayt kopyalama döngüsü, kaynak sunumun bölüm hiyerarşisini yeniden oluşturmaz. Çıktıda bölümler önemliyse, hedef sunumda bölümler oluşturun veya seçin ve slaytları açıkça [SlideCollection.addClone](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#addClone) ile bu bölümlere kopyalayın.

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

Kopyalanan slaytlar belirtilen hedef bölüme eklenir. Birden fazla kaynak bölümü korumak için [Presentation.getSections](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getSections) listesini döngüye alın, her kaynak bölümün mevcut slaytlarını [Section.getSlidesListOfSection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/section/#getSlidesListOfSection) ile alın, bölümleri hedefte yeniden oluşturun ve her dönen slaytı ilgili hedef bölümüne kopyalayın. Boş bölümler ve yapısal değişiklikler dahil olmak üzere tam bölüm döngüsü örneği için [Manage Slide Sections](/slides/tr/python-java/slide-section/) sayfasına bakın.

## **Birden Çok Sunumu Güvenli Bir Şekilde Birleştir**

Aşağıdaki uçtan uca örnek, ilk sunumu hedef olarak kullanır, ek her kaynak için slayt boyutunu normalleştirir, her kaynağı yalnızca kopyalanırken açık tutar ve sonunda dosyayı bir kez kaydeder.

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

Bu, içe aktarılan slaytların kaynak biçimlendirmesini korumak için kullanışlı bir temeldir. Çıktınız tek bir hedef teması kullanmalıysa, basit `addClone(slide)` çağrısını önceki bölümde gösterilen uygun hedef‑master veya hedef‑yerleşim aşırı yüklemesiyle değiştirin.

## **Pratik Hususlar**

### **Master'lar, Yerleşimler ve Biçimlendirme Doğruluğu**

Varsayılan slayt kopyalama, gerekli bir kaynak master'ı otomatik olarak hedef sunuma getirebilir. Aspose.Slides, aynı master'ı tekrarlı olarak kopyalamamak için otomatik kopyalanan master'ları izleyen dahili bir kayıt tutar. Manuel olarak kopyalanan master'lar bu kayıt tarafından izlenmez; bu nedenle, master üzerindeki kontrol dışına çıkmanız gerekmedikçe önceden master kopyalamaktan kaçının.

Aynı isme sahip iki master veya yerleşimin görsel olarak eşit olduğunu varsaymayın. Kurumsal bir şablon nihai görünümü kontrol ediyorsa, hedef master veya yerleşimi açıkça seçin ve birleştirmeden sonra sonucu doğrulayın.

### **Notlar ve Yorumlar**

Konuşmacı notları ve slayt yorumları slayt içeriğiyle ilişkilidir ve slayt kopyalandığında kopyalanır. Aspose.Slides ayrıca [presentation notes](/slides/tr/python-java/presentation-notes/) ve [presentation comments](/slides/tr/python-java/presentation-comments/) için özel API'ler sunar.

Not sayfası biçimlendirmesi önemliyse, birleştirilmiş sunumu doğrulayın; çünkü not master'ları sunum‑seviyesinde nesnelerdir ve kaynak dosyalar arasında farklılık gösterebilir. Gözden geçirme iş akışları için, farklı yazarların veya şablonların dosyalarını birleştirdikten sonra yorum yazarlarını ve zincirlenmiş yorumları da doğrulayın.

### **Görseller, Ses, Video, OLE Nesneleri ve Dış Bağlantılar**

Slaytlar, görseller, gömülü ses, gömülü video ve OLE verileri gibi sunum‑seviyesindeki kaynaklara referans verebilir. Sadece görünür şekilleri kopyalamak yerine slaytı tamamıyle kopyalayın; böylece Aspose.Slides, slaytın kaynak ilişkilerini korur.

Gömülü ve bağlanmış kaynaklar farklı şekilde ele alınmalıdır. Bağlantılı bir ses, video, OLE nesnesi veya köprü, dış hedefe bağımlı kalır; slaytı kopyalamak bir dış bağlantıyı gömülü içeriğe dönüştürmez. Bağlantılı kaynak yollarını ve URL'leri, birleştirilmiş sunumun açılacağı ortamda test edin.

Aspose.Slides otomatik kopyalanan master'ları açıkça izler, ancak bu, birbirinden bağımsız kaynak sunumlardan gelen aynı ikili kaynakların her zaman tekrarsızlaştırılacağına dair genel bir garanti değildir. Çıktı dosya boyutu önemliyse, birleştirilmiş paketi inceleyin ve sonucu ölçün; örtük tekrarsızlaştırmaya dayanmaktan kaçının.

### **Gömülü Yazı Tipleri ve Yazı Tipi Kullanılabilirliği**

Yazı tipleri sunum‑seviyesinde yönetilir. Tipografi makineler arasında tutarlı kalmalıysa, yalnızca slaytları kopyalamanın, hedef ortamda gereken tüm yazı tiplerinin mevcut olduğunu garanti ettiğini varsaymayın. Gömülü yazı tiplerini [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) ile inceleyebilir ve [Embed Fonts in Presentations](/slides/tr/python-java/embedded-font/) sayfasında açıklandığı gibi gömme işlemini açıkça yönetin.

Ayrıca, kaynak dosyalarda kullanılan yazı tiplerini gömmeye izin verilip verilmediğini doğrulayın. Yazı tipi lisansları gömme işlemini kısıtlayabilir.

### **Şifre Koruması Olan Sunumlar**

Şifre korumalı bir kaynak, slaytları kopyalanmadan önce başarıyla açılmalıdır. Şifreyi [LoadOptions.setPassword](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setPassword) aracılığıyla sağlayın.

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
    # Çözülmüş sunumla çalış.
    print(f"Loaded {source.getSlides().size()} slides.")
finally:
    source.dispose()
```

Şifreli bir kaynağı açmak, aynı korumayı otomatik olarak hedef sunuma uygulamaz. Gerekli olduğunda çıkış korumasını ayrı olarak yapılandırın.

### **Büyük Sunumlar ve Bellek Kullanımı**

Yüksek çözünürlüklü görseller, ses, video veya diğer büyük ikili nesneler içeren büyük sunumlar önemli miktarda bellek tüketebilir. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) BLOB yönetimi ve geçici dosya kullanımını kontrol eder. Büyük dosya stratejileri için [Manage Presentation BLOBs](/slides/tr/python-java/manage-blob/) sayfasına bakın.

Büyük dosyalar için mümkün olduğunda dosya yollarından yüklemeyi tercih edin, her kaynak sunumu birleştirildikten hemen sonra serbest bırakın ve iş akışı kontrol noktaları gerektirmiyorsa ara sonuçları tekrar tekrar kaydetmekten kaçının.

### **İş Parçacığı Güvenliği**

Aynı [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örneğini birden çok iş parçacığından aynı anda yüklemeyin, değiştirmeyin, kaydetmeyin veya kopyalamayın. Her sunum örneğini yalnızca bir birleştirme işlemiyle sınırlı tutun. Bağımsız işleri paralelleştiriyorsanız, bağımsız sunum örneklerini kullanın ve [Aspose.Slides multithreading guidance](/slides/tr/python-java/multithreading/) kurallarına uyun.

## **SSS**

**Kaynak her sunumun orijinal tasarımını nasıl korurum?**  
[addClone](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#addClone) metodunu, hedef master veya yerleşim sağlamadan kullanın. Aspose.Slides, içe aktarılan slaytın ihtiyacı olduğunda kaynak master'ı otomatik olarak kopyalayabilir.

**İçe aktarılan slaytların hedef temayı kullanmasını nasıl sağlarım?**  
Hedef master kabul eden aşırı yüklemeyi kullanın. Hedef sunumdan bir master geçirin, kaynak sunumdan değil. Aspose.Slides, her kaynak slaytı o master altındaki uygun bir yerleşime eşleştirmeye çalışır.

**Belirli bir hedef yerleşimi, hedef master yerine ne zaman kullanmalıyım?**  
Her içe aktarılan slaytın bilinen tek bir yerleşim kullanması gerektiğinde belirli bir yerleşim kullanın. Master kullanınca, Aspose.Slides kaynak yerleşim tipine veya adına göre master'ın yerleşimleri arasından seçim yapar.

**Farklı slayt boyutlarına sahip sunumlar birleştirilebilir mi?**  
Evet, ancak slayt içeriği yeni boyutlar için otomatik olarak yeniden tasarlanmamaktadır. Öngörülebilir konumlandırma gerektiğinde, örneğin [SlideSize.setSize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidesize/#setSize) ve [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidesizescaletype/) ile kaynak sunumu önce yeniden boyutlandırın.

**PPT, PPTX ve ODP sunumlarını tek bir dosyada birleştirebilir miyim?**  
Evet. Her kaynak sunumu yükleyin, gerekli slaytları tek bir hedefe kopyalayın ve hedefi desteklenen bir çıktı formatında kaydedin. Sunum formatları aynı özellik setini tam olarak desteklemediğinden, çapraz‑format birleştirmelerden sonra karmaşık içeriği doğrulayın. [Supported File Formats](/slides/tr/python-java/supported-file-formats/) sayfasına bakın.

**Kaynak bölümler otomatik olarak korunur mu?**  
Sadece slaytları kopyalayan temel döngü bölümleri otomatik olarak korumaz. Hedefte gerekli bölümleri yeniden oluşturun ve bölüm yapısı korunmalıysa [addClone](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#addClone) bölüm aşırı yüklemesini kullanın.

**Konuşmacı notları ve yorumlar korunur mu?**  
Kopyalanan slaytla birlikte kopyalanırlar. Not‑master stiline, yorum yazarlarına veya zincirli inceleme verilerine bağlı iş akışları için, bu yapıların da sunum‑seviyesinde olduğu unutulmamalı; birleştirilmiş sonucu doğrulayın.

**Ses, video, OLE nesneleri ve köprüler ne olur?**  
Gömülü içerik, kopyalanan slaytın kaynak ilişkileriyle birlikte taşınır. Dış bağlantılar dışarıda kalır; hedef dosyalar veya URL'ler birleştirme sonrası hâlâ erişilebilir olmalıdır.

**Her kaynaktan gelen gömülü yazı tiplerinin birleştirilmiş sunumda bulunacağı garantilenir mi?**  
Yalnızca slayt kopyalama, yazı tipi dağıtımını garanti etmez. Hedefteki gömülü yazı tiplerini inceleyin ve tipografi önemliyse gömme işlemini açıkça yönetin veya dış yazı tipi kullanılabilirliğini sağlayın.

**Şifre korumalı bir dosyayı nasıl birleştiririm?**  
Doğru [LoadOptions.setPassword](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setPassword) ile açın, ardından slaytları normal şekilde kopyalayın. Çıktı koruması ayrı olarak yapılandırılır.

**Çok büyük sunumları nasıl yönetmeliyim?**  
BLOB yönetimi büyük ikili nesnelerin bellek kullanımını kontrol eder, mümkün olduğunda dosya yolu üzerinden yükleyin, kaynak sunumları birleştirildikten hemen sonra boşaltın ve iş akışı kontrol noktaları gerektirmiyorsa ara sonuçları tekrar tekrar kaydetmekten kaçının.

**Birden çok iş parçacığından slaytları birleştirebilir miyim?**  
Aynı [Presentation] örneğini birden çok iş parçacığından aynı anda yüklemeyin, değiştirmeyin, kaydetmeyin veya kopyalamayın. Her birleştirme işlemini kendi sunum örnekleriyle izole tutun.