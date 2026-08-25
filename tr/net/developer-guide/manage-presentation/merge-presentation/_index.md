---
title: .NET'te Sunumları Verimli Bir Şekilde Birleştirin
linktitle: Sunumları Birleştir
type: docs
weight: 40
url: /tr/net/merge-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Slaytları kopyalayarak, master ve layout'ları kontrol ederek, slayt içeriğini yeniden boyutlandırarak, bölümleri koruyarak ve korumalı ya da büyük dosyalarla başa çıkarak .NET'te PowerPoint ve OpenDocument sunumlarını nasıl birleştireceğinizi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for .NET, slaytları bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/)'dan diğerine çoğaltarak sunumları birleştirir. Ana işlem [ISlideCollection.AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection/addclone/) dir; bu işlem kaynak slaytın biçimlendirmesini koruyabilir veya kopyalanan slaytı hedef sunumdaki bir master veya layoute ekleyebilir.

Bu makale en yaygın birleştirme iş akışlarını kapsar:
- tüm slaytları kaynak biçimlendirmesini koruyarak birleştir;
- seçili slaytları birleştir;
- hedef sunumdan bir master uygula;
- hedef sunumdan belirli bir layout uygula;
- birleştirmeden önce farklı slayt boyutlarını normalleştir;
- kopyalanan slaytları bir bölüme ekle;
- birden fazla sunumu uçtan uca bir iş akışında birleştir;
- master'ları, kaynakları, notları, yorumları, medyayı, yazı tiplerini, parolaları, büyük dosyaları ve çoklu iş parçacığı konularını ele al.

## **Slayt Kopyalamanın Master ve Layout'ları Nasıl Etkilediği**

Bir slayt, görünümünün büyük bir kısmını layout ve master'ından devralır. Bu nedenle, seçtiğiniz kopyalama aşırı yüklemesi, birleştirilen slaytın hedef sunuma nasıl entegre edileceğini belirler.

Bu yöntemlerden biriyle [ISlideCollection.AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection/addclone/) kullanın:
- `AddClone(sourceSlide)` — kaynak slaytın layout ve formatlamasını korur. Gerekirse, kaynak master otomatik olarak hedef sunuma kopyalanabilir. Aspose.Slides, otomatik kopyalanan master'ları izleyerek aynı kaynak master'ını kullanan tekrarlanan slaytların master'ı tekrar kopyalamasını önler.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — kopyalanan slaytı belirli bir hedef [IMasterSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterslide/)'a ekler. Aspose.Slides, o master altında layout tipi ya da adıyla eşleşen bir layout arar.
- `AddClone(sourceSlide, destinationLayout)` — kopyalanan slaytı doğrudan belirli bir hedef [ILayoutSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/ilayoutslide/)'a ekler.

Bir `AddClone` aşırı yüklemesine geçirilen master veya layout, **hedef** sunuma ait olmalı, kaynak sunuma ait olmamalıdır.

## **Tüm Sunumları Birleştir ve Kaynak Biçimlendirmesini Koru**

En basit birleştirme, kaynak sunumdaki her slaytı hedef sunuma kopyalar. Bu, içe aktarılan slaytların orijinal tema, master ve layout ilişkilerini koruması gerektiğinde uygun bir tercihtir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged.pptx", SaveFormat.Pptx);
```

Kaynak ve hedef farklı tasarımlar kullandığında, ortaya çıkan sunum birden fazla master içerebilir. Bu, kaynak biçimlendirmesinin kasıtlı olarak korunması durumunda beklenen bir durumdur.

## **Seçili Slaytları Birleştir**

Her slaytı kopyalamanız gerekmiyor. Aşağıdaki örnek, kaynak sunumdan yalnızca seçili slayt indekslerini içe aktarır.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var slideIndexes = new[] { 0, 2, 4 };

foreach (var index in slideIndexes)
{
    destination.Slides.AddClone(source.Slides[index]);
}

destination.Save("merged-selected-slides.pptx", SaveFormat.Pptx);
```

Kullanıcı girişi veya harici yapılandırmadan gelen slayt indekslerini kopyalamadan önce doğrulayın.

## **Hedef Master Kullanarak Slaytları Birleştir**

İçe aktarılan slaytların zaten hedef sunuma ait bir master'ı takip etmesi gerektiğinde, [AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection/addclone/) aşırı yüklemesini kullanın.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationMaster = destination.Masters[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationMaster, allowCloneMissingLayout: true);
}

destination.Save("merged-with-destination-master.pptx", SaveFormat.Pptx);
```

Aspose.Slides, belirtilen master altında kaynak layout'un tipini veya adını eşleştirerek uygun bir layout seçer. Uygun bir layout bulunmazsa ve `allowCloneMissingLayout` `true` ise, kaynak layout kopyalanarak slayt eklenebilir. `false` ise bir [PptxEditException](https://reference.aspose.com/slides/tr/net/aspose.slides/pptxeditexception/) fırlatılır.

Birleştirmenin başarısız olmasını ve hedef master'a ek bir layout eklenmesini istemediğinizde `false` kullanın.

## **Belirli Bir Hedef Layout Kullanarak Slaytları Birleştir**

İçe aktarılan slaytların hangi hedef layout'u kullanacağını kesin olarak bildiğinizde, [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection/addclone/) aşırı yüklemesini kullanın.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationLayout = destination.LayoutSlides[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationLayout);
}

destination.Save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
```

Bir hedef layout uygulamak, devralınan layout ilişkisini değiştirir; kaynak slayt içeriğini yeniden tasarlamaz. Kaynak ve hedef layout'ların farklı placeholder yapılarına sahip olması durumunda, devralınan biçimlendirme ve placeholder davranışının uygun olduğunu doğrulamak için sonucu inceleyin.

## **Farklı Slayt Boyutlarına Sahip Sunumları Birleştir**

Farklı slayt boyutlarına sahip sunumlar birleştirilebilir, ancak bir slaytı farklı bir slayt boyutuna sahip bir sunuya kopyalamak, içeriği yeni tuval için otomatik olarak yeniden tasarlamaz. Bu nedenle şekiller kaymış, beklenmedik şekilde ölçeklenmiş veya görünür slayt alanı dışına çıkmış görünebilir.

Pratik bir yaklaşım, kopyalamadan önce kaynak sunumun boyutunu yeniden ayarlamaktır. [SlideSize.SetSize](https://reference.aspose.com/slides/tr/net/aspose.slides/slidesize/setsize/) yöntemi, slayt boyutlarını değiştirirken mevcut içeriği ölçeklendirebilir. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/tr/net/aspose.slides/slidesizescaletype/) ise içeriği istenen boyuta sığacak şekilde ölçeklendirir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

if (source.SlideSize.Size.Width != destination.SlideSize.Size.Width || 
    source.SlideSize.Size.Height != destination.SlideSize.Size.Height)
{
    source.SlideSize.SetSize(
        destination.SlideSize.Size.Width, 
        destination.SlideSize.Size.Height, 
        SlideSizeScaleType.EnsureFit);
}

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged-same-slide-size.pptx", SaveFormat.Pptx);
```

Yeniden boyutlandırma, kaynak sunum nesnesini bellek içinde değiştirir. Diğer işlemler için orijinal kaynak sunumun değiştirilmemiş olmasına ihtiyaç duyuyorsanız, birleştirme için ayrı bir örnek açın.

## **Slaytları Bir Sunum Bölümüne Birleştir**

Temel slayt kopyalama döngüsü, kaynak sunumun bölüm hiyerarşisini yeniden oluşturmaz. Çıktıda bölümler önemliyse, hedef sunumda bölümler oluşturun veya seçin ve slaytları açıkça [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection/addclone/) kullanarak kopyalayın.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var importedSection = destination.Sections.AppendEmptySection("Imported slides");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, importedSection);
}

destination.Save("merged-with-section.pptx", SaveFormat.Pptx);
```

Kopyalanan slaytlar belirtilen hedef bölüme eklenir. Birden fazla kaynak bölümünü korumak için [Presentation.Sections](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/sections/) 'ı dolaşın, her kaynak bölümünün mevcut slaytlarını [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/tr/net/aspose.slides/isection/getslideslistofsection/) ile alın, bölümleri hedefte yeniden oluşturun ve dönen her slaytı ilgili hedef bölümüne kopyalayın. Boş bölümler ve yapısal değişiklikleri içeren tam bir bölüm enumerasyon örneği için [Manage Slide Sections](/slides/tr/net/slide-section/) sayfasına bakın.

## **Birden Çok Sunumu Güvenli Bir Şekilde Birleştir**

Aşağıdaki uçtan uca örnek, ilk sunumu hedef olarak kullanır, ek her kaynak için slayt boyutunu normalleştirir, her kaynağı yalnızca kopyalanırken açık tutar ve sonunda dosyayı bir kez kaydeder.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var inputFiles = new[] { "part1.pptx", "part2.pptx", "part3.pptx" };

using var merged = new Presentation(inputFiles[0]);

for (var fileIndex = 1; fileIndex < inputFiles.Length; fileIndex++)
{
    using var source = new Presentation(inputFiles[fileIndex]);

    if (source.SlideSize.Size.Width != merged.SlideSize.Size.Width || 
        source.SlideSize.Size.Height != merged.SlideSize.Size.Height)
    {
        source.SlideSize.SetSize(
            merged.SlideSize.Size.Width, 
            merged.SlideSize.Size.Height, 
            SlideSizeScaleType.EnsureFit);
    }

    foreach (var slide in source.Slides)
    {
        merged.Slides.AddClone(slide);
    }
}

merged.Save("merged.pptx", SaveFormat.Pptx);
```

Bu, içe aktarılan slaytların kaynak biçimlendirmesini korumak için yararlı bir temel oluşturur. Çıktınızın tek bir hedef tema kullanması gerekiyorsa, basit `AddClone(slide)` çağrısını önceki örneklerde gösterilen uygun hedef-master veya hedef-layout aşırı yüklemesiyle değiştirin.

## **Pratik Düşünceler**

### **Master'lar, Layout'lar ve Biçimlendirme Doğruluğu**

Varsayılan slayt kopyalama, gerekli bir kaynak master'ı otomatik olarak hedef sunuma getirebilir. Aspose.Slides, aynı master'ın tekrar tekrar kopyalanmasını önlemek için otomatik kopyalanan master'ları içeren bir dahili kayıt tutar. Elle kopyalanan master'lar bu kayıt tarafından izlenmez; bu nedenle master yapısı üzerinde açık kontrol gerekmiyorsa master'ları önceden kopyalamaktan kaçının.

Aynı ada sahip iki master veya layout'un görsel olarak eşdeğer olduğunu varsaymayın. Kurumsal bir şablon son görünümü kontrol etmeliyse, hedef master veya layout'u açıkça seçin ve birleştirmeden sonra sonucu doğrulayın.

### **Notlar ve Yorumlar**

Sunucu notları ve slayt yorumları slayt içeriğiyle ilişkilidir ve bir slayt kopyalandığında kopyalanır. Aspose.Slides ayrıca [presentation notes](/slides/tr/net/presentation-notes/) ve [presentation comments](/slides/tr/net/presentation-comments/) için özel API'lar sunar.

Not sayfası biçimlendirmesi önemliyse, not master'ları sunum seviyesinde nesneler olduğundan ve kaynak dosyalar arasında farklılık gösterebileceğinden birleştirilmiş sunumu doğrulayın. İnceleme iş akışları için, farklı yazarlar veya şablonlardan gelen dosyaları birleştirdikten sonra yorum yazarlarını ve zincirli yorumları da doğrulayın.

### **Görseller, Ses, Video, OLE Nesneleri ve Harici Bağlantılar**

Slaytlar, görseller, gömülü ses, gömülü video ve OLE verileri gibi sunum seviyesindeki kaynaklara referans verebilir. Aspose.Slides'in slaytın kaynaklarla ilişkisini koruyabilmesi için yalnızca görünür şekilleri kopyalamak yerine slaytı tamamen kopyalayın.

Gömülü ve bağlanmış kaynaklar farklı muamele görmelidir. Bağlı bir ses, video, OLE nesnesi veya hiperlink dış hedefine bağımlı kalır; bir slaytı kopyalamak harici bir bağlantıyı gömülü içeriğe dönüştürmez. Bağlantılı kaynak yollarını ve URL'leri birleştirilmiş sunumun açılacağı ortamda test edin.

Aspose.Slides otomatik kopyalanan master'ları açıkça izler, ancak bu, ilişkili olmayan kaynak sunumlardan gelen aynı ikili kaynakların her zaman tekilleştirileceği anlamına gelmez. Çıktı dosya boyutu önemliyse, örtülü tekilleştirmeye güvenmek yerine birleştirilmiş paketi inceleyin ve sonucu ölçün.

### **Gömülü Yazı Tipleri ve Yazı Tipi Kullanılabilirliği**

Yazı tipleri sunum seviyesinde yönetilir. Tipografinin makineler arasında tutarlı kalması gerekiyorsa, yalnızca slayt kopyalamanın hedef ortamda gerekli tüm yazı tiplerinin bulunacağını varsaymayın. Gömülü yazı tiplerini [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsmanager/getembeddedfonts/) ile inceleyebilir ve [Embed Fonts in Presentations](/slides/tr/net/embedded-font/) bölümünde açıklandığı gibi gömme işlemini açıkça yönetebilirsiniz.

Ayrıca kaynak dosyalarda kullanılan yazı tiplerini gömmeye izin verilip verilmediğini doğrulayın. Yazı tipi lisansları gömmeyi sınırlayabilir.

### **Parola Koruması Olan Sunumlar**

Parola korumalı bir kaynak, slaytları kopyalanmadan önce başarılı bir şekilde açılmalıdır. Parolayı [LoadOptions.Password](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/password/) aracılığıyla sağlayın.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

Şifrelenmiş bir kaynağın açılması, aynı korumayı hedef sunuma otomatik olarak uygulamaz. Gerekli olduğunda çıktı korumasını ayrı olarak yapılandırın.

### **Büyük Sunumlar ve Bellek Kullanımı**

Yüksek çözünürlüklü görseller, ses, video veya diğer büyük ikili nesneler içeren büyük sunumlar önemli miktarda bellek tüketebilir. [LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/blobmanagementoptions/) BLOB yönetimi ve geçici dosya kullanımına yönelik kontroller sağlar. Büyük dosya stratejileri için [Manage Presentation BLOBs](/slides/tr/net/manage-blob/) sayfasına bakın.

Büyük dosyalar için mümkün olduğunda dosya yollarından yüklemeyi tercih edin, bir kaynak sunumu birleştirildiği anda serbest bırakın ve iş akışı kontrol noktaları gerektirmediği sürece ara sonuçları tekrarlı olarak kaydetmekten kaçının.

### **İş Parçacığı Güvenliği**

Aynı [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) örneğini birden çok iş parçacığından aynı anda yüklemeyin, değiştirmeyin, kaydetmeyin veya kopyalamayın. Her sunum örneğini tek bir birleştirme işlemiyle sınırlı tutun. Bağımsız işleri paralelleştiriyorsanız, bağımsız sunum örnekleri kullanın ve [Aspose.Slides multithreading guidance](/slides/tr/net/multithreading/) yönergelerini izleyin.

## **FAQ**

**Kaynak sunumların orijinal tasarımını nasıl korurum?**

[AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection/addclone/)'i hedef master veya layout sağlamadan kullanın. Aspose.Slides, içe aktarılan slayt tarafından gerektiğinde kaynak master'ı otomatik olarak kopyalayabilir.

**İçe aktarılan slaytların hedef temayı kullanmasını nasıl sağlarım?**

Hedef master kabul eden aşırı yüklemeyi kullanın. Kaynak değil, hedef sunumdan bir master gönderin. Aspose.Slides, her kaynak slaytı o master altında uygun bir layout'a eşlemeye çalışacaktır.

**Bir hedef master yerine belirli bir hedef layout ne zaman kullanılmalı?**

Her içe aktarılan slaytın bilinen bir layout kullanması gerektiğinde belirli bir layout kullanın. Kaynak layout tipi veya adına göre Aspose.Slides'in master'ın layout'ları arasından seçim yapmasını istediğinizde master kullanın.

**Farklı slayt boyutlarına sahip sunumlar birleştirilebilir mi?**

Evet, ancak slayt içeriği hedef boyutlar için otomatik olarak yeniden tasarlanmamaktadır. Öngörülebilir yerleşim gerektiğinde, önce kaynak sunumu yeniden boyutlandırın; örneğin [SlideSize.SetSize](https://reference.aspose.com/slides/tr/net/aspose.slides/slidesize/setsize/) ve [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/tr/net/aspose.slides/slidesizescaletype/) ile.

**PPT, PPTX ve ODP sunumlarını tek bir dosyada birleştirebilir miyim?**

Evet. Her kaynak sunumu yükleyin, gereken slaytları tek bir hedefe kopyalayın ve hedefi desteklenen bir çıktı formatında kaydedin. Sunum formatları aynı özellik setini tam olarak desteklemediği için, çapraz format birleştirmelerinden sonra karmaşık içeriği doğrulayın. [Supported File Formats](/slides/tr/net/supported-file-formats/) sayfasına bakın.

**Kaynak bölümler otomatik olarak korunur mu?**

Yalnızca slaytları kopyalayan temel bir döngüyle korunmaz. Gerekli bölümleri hedefte yeniden oluşturun ve bölüm yapısı korunmalıysa [AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection/addclone/)'in bölüm aşırı yüklemesini kullanın.

**Sunucu notları ve yorumlar korunur mu?**

Kopyalanan slaytla birlikte kopyalanırlar. Not-master stiline, yorum yazarlarına veya zincirli inceleme verilerine bağlı iş akışları için, bu senaryolar sunum seviyesindeki yapıların ve slayt seviyesindeki içeriğin birleşimini içerdiğinden birleştirilmiş sonucu doğrulayın.

**Ses, video, OLE nesneleri ve hiperlink'lerle ne olur?**

Gömülü içerik, kopyalanan slaytın kaynak ilişkilerinin bir parçası olarak taşınır. Harici bağlantılar dışarıda kalır; bu nedenle birleştirmeden sonra hedef dosya veya URL'lerin hâlâ erişilebilir olması gerekir.

**Her kaynaktan gelen gömülü yazı tiplerinin birleştirilmiş sunumda bulunacağı garanti edilir mi?**

Yazı tipi dağıtımı için yalnızca slayt kopyalamaya güvenmeyin. Tipografi önemliyse, hedefteki gömülü yazı tiplerini inceleyin ve yazı tipi gömmeyi veya dış yazı tipi kullanılabilirliğini açıkça yönetin.

**Parola korumalı bir dosyayı nasıl birleştiririm?**

Doğru [LoadOptions.Password](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/password/) ile açın, ardından slaytlarını normal şekilde kopyalayın. Çıktı koruması ayrı olarak yapılandırılır.

**Çok büyük sunumları nasıl yönetmeliyim?**

Büyük ikili nesneler bellek kullanımını domine ettiğinde BLOB yönetimini kullanın, çok büyük dosyalar için dosya yolu üzerinden yüklemeyi tercih edin, kaynak sunumları hemen serbest bırakın ve yalnızca gerektiğinde son sonucu kaydedin.

**Birden çok iş parçacığından slaytları birleştirebilir miyim?**

Aynı [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) örneğini birden çok iş parçacığından aynı anda kullanmayın. Her bir birleştirme işlemini kendi sunum örnekleriyle izole tutun.