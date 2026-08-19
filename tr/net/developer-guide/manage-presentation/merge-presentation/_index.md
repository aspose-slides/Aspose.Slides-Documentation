---
title: .NET'te Sunumları Verimli Şekilde Birleştirme
linktitle: Sunumları Birleştir
type: docs
weight: 40
url: /tr/net/merge-presentation/
keywords:
- PowerPoint birleştirme
- sunumları birleştirme
- slaytları birleştirme
- PPT birleştirme
- PPTX birleştirme
- ODP birleştirme
- PowerPoint birleştir
- sunumları birleştir
- slaytları birleştir
- PPT birleştir
- PPTX birleştir
- ODP birleştir
- .NET
- C#
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını .NET'te slaytları klonlayarak, master ve düzenleri kontrol ederek, slayt içeriğini yeniden boyutlandırarak, bölümleri koruyarak ve korumalı ya da büyük dosyalarla başa çıkarak nasıl birleştireceğinizi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for .NET, slaytları bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/)’dan diğerine klonlayarak sunumları birleştirir. Ana işlem, kaynak slaydın biçimlendirmesini koruyabilen veya klonlanan slaytı hedef sunumdaki bir mastera veya düzene ekleyebilen [ISlideCollection.AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection/addclone/) metodudur.

Bu makale en yaygın birleştirme akışlarını kapsar:

- tüm slaytları kaynak biçimlendirmelerini koruyarak birleştirme;
- seçili slaytları birleştirme;
- hedef sunumun bir masterını uygulama;
- hedef sunumun belirli bir düzenini uygulama;
- birleştirmeden önce farklı slayt boyutlarını normalleştirme;
- klonlanan slaytları bir bölüme ekleme;
- birden fazla sunumu uçtan uca bir akışta birleştirme;
- masterlar, kaynaklar, notlar, yorumlar, medya, yazı tipleri, parolalar, büyük dosyalar ve çoklu iş parçacığı konularını ele alma.

## **Slayt Klonlamanın Masterlar ve Düzenler Üzerindeki Etkisi**

Bir slayt görünümünün büyük bir kısmını düzeni ve masterı belirler. Bu nedenle, seçtiğiniz klonlama aşırı yüklemesi, birleştirilen slaydın hedef sunuma nasıl entegre edileceğini belirler.

[ISlideCollection.AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection/addclone/) metodunu şu şekillerde kullanın:

- `AddClone(sourceSlide)` — kaynak slaydın düzenini ve biçimlendirmesini korur. Gerekirse, kaynak master otomatik olarak hedef sunuma klonlanır. Aspose.Slides, aynı kaynak masterı kullanan yinelenen slaytların masterının tekrar tekrar klonlanmasını önlemek için otomatik klonlanan masterları izler.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — klonlanan slaytı belirli bir hedef [IMasterSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterslide/) üzerine ekler. Aspose.Slides, bu master altında düzen tipine veya adına göre eşleşen bir düzen arar.
- `AddClone(sourceSlide, destinationLayout)` — klonlanan slaytı doğrudan belirli bir hedef [ILayoutSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/ilayoutslide/) üzerine ekler.

`AddClone` aşırı yüklemesine geçirilen master veya düzen, **hedef** sunuma ait olmalı, kaynak sunuma ait olmamalıdır.

## **Tüm Sunumları Birleştir ve Kaynak Biçimlendirmesini Koru**

En basit birleştirme, kaynak sunumdaki tüm slaytları hedef sunuma kopyalar. Bu, içe aktarılan slaydların orijinal temalarını, masterlarını ve düzen ilişkilerini koruması gerektiğinde uygun bir seçimdir.

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

Kaynak ve hedef farklı tasarımlar kullandığında ortaya çıkan sunum birden çok master içerebilir. Kaynak biçimlendirmesinin kasıtlı olarak korunması durumunda bu beklenen bir davranıştır.

## **Seçili Slaytları Birleştir**

Her slaytı klonlamak zorunda değilsiniz. Aşağıdaki örnek, kaynak sunumdan yalnızca seçili slayt dizinlerini içe aktarır.

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

Kullanıcı girişi veya dış yapılandırmadan gelen dizinler klonlanmadan önce doğrulanmalıdır.

## **Hedef Master Kullanarak Slaytları Birleştir**

İçe aktarılan slaydların zaten hedef sunuma ait bir masterı izlemesi gerektiğinde [AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection/addclone/) aşırı yüklemesini kullanın.

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

Aspose.Slides, kaynak düzenin tipine veya adına göre belirtilen master altında uygun bir düzen seçer. Uygun bir düzen bulunmazsa ve `allowCloneMissingLayout` **true** ise kaynak düzen klonlanır ve slayt eklenebilir. **false** ise bir [PptxEditException](https://reference.aspose.com/slides/tr/net/aspose.slides/pptxeditexception/) atılır.

Birleştirmenin başarısız olmasını ve hedef mastera ek bir düzen eklenmemesini istiyorsanız **false** kullanın.

## **Belirli Bir Hedef Düzeni Kullanarak Slaytları Birleştir**

İçe aktarılan slaydların kesin olarak hangi hedef düzeni kullanması gerektiğini bildiğinizde [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection/addclone/) aşırı yüklemesini kullanın.

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

Hedef düzenin uygulanması, kalıtlama düzen ilişkisini değiştirir; kaynak slayt içeriğini yeniden tasarlamaz. Kaynak ve hedef düzenlerin yer tutucu yapıları farklıysa, kalıtlama biçimlendirme ve yer tutucu davranışının uygun olduğunu doğrulamak için sonucu inceleyin.

## **Farklı Slayt Boyutlarına Sahip Sunumları Birleştir**

Farklı slayt boyutlarına sahip sunumlar birleştirilebilir, ancak bir slaytı başka bir slayt boyutuna sahip bir sunuma klonlamak, içeriği yeni kanvas için otomatik olarak yeniden tasarlamaz. Bu nedenle şekiller kaymış, beklenmedik şekilde ölçeklenmiş veya görünür slayt alanının dışına taşmış görünebilir.

Pratik bir yaklaşım, klonlamadan önce kaynak sunumu yeniden boyutlandırmaktır. [SlideSize.SetSize](https://reference.aspose.com/slides/tr/net/aspose.slides/slidesize/setsize/) yöntemi, slayt boyutlarını değiştirirken mevcut içeriği ölçeklendirebilir. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/tr/net/aspose.slides/slidesizescaletype/) içerikleri isteğe bağlı boyuta sığacak şekilde ölçeklendirir.

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

Yeniden boyutlandırma, kaynak sunum nesnesini bellekte değiştirir. Orijinal kaynak sunumun başka işlemler için değişmeden kalması gerekiyorsa, birleştirme sırasında ayrı bir örnek açın.

## **Slaytları Bir Sunum Bölümüne Birleştir**

Temel slayt klonlama döngüsü, kaynak sunumun bölüm hiyerarşisini yeniden oluşturmaz. Çıktıda bölümler önemliyse, hedef sunumda bölümler oluşturun veya seçin ve slaytları açıkça [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection/addclone/) ile bölümlere klonlayın.

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

Klonlanan slaytlar belirtilen hedef bölüme eklenir. Birkaç kaynak bölümü korumak istiyorsanız, bu bölümleri hedefte yeniden oluşturun ve her kaynak slaytı ilgili hedef bölümüne eşleyin.

## **Birden Fazla Sunumu Güvenli Bir Şekilde Birleştir**

Aşağıdaki uçtan uca örnek, ilk sunumu hedef olarak kullanır, ek her bir kaynak için slayt boyutunu normalleştirir, her kaynağı yalnızca kopyalanırken açık tutar ve sonunda tek bir dosya olarak kaydeder.

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

Bu, içe aktarılan slaytların kaynak biçimlendirmesini korumak için faydalı bir temel sunar. Çıktınız tek bir hedef teması kullanmalıysa, basit `AddClone(slide)` çağrısını daha önce gösterilen uygun hedef‑master veya hedef‑düzen aşırı yüklemesiyle değiştirin.

## **Pratik Hususlar**

### **Masterlar, Düzenler ve Biçim Korunumu**

Varsayılan slayt klonlaması, gereken bir kaynak masterını otomatik olarak hedef sunuma getirebilir. Aspose.Slides, aynı masterın tekrar tekrar klonlanmasını önlemek için otomatik klonlanan masterları içsel bir kayıt defterinde tutar. Manuel olarak klonlanan masterlar bu kayıt defterinde izlenmez; bu nedenle, master yapısı üzerinde açık kontrol gerekmiyorsa önceden klonlamaktan kaçının.

Aynı ada sahip iki masterın veya düzenin görsel olarak eşdeğer olduğunu varsaymayın. Kurumsal bir şablon nihai görünüme hükmediyorsa, hedef masterı veya düzeni açıkça seçin ve birleştirme sonrası sonucu doğrulayın.

### **Notlar ve Yorumlar**

Sunucu notları ve slayt yorumları slayt içeriğiyle ilişkilidir ve bir slayt klonlandığında kopyalanır. Aspose.Slides ayrıca [presentation notes](https://docs.aspose.com/slides/tr/net/presentation-notes/) ve [presentation comments](https://docs.aspose.com/slides/tr/net/presentation-comments/) için özel API’ler sunar.

Not‑sayfası biçimlendirmesi önemliyse, birleştirilmiş sunumu doğrulayın; çünkü not masterları sunum‑seviyesi nesnelerdir ve kaynak dosyalar arasında farklılık gösterebilir. İnceleme süreçlerinde, farklı yazarların veya şablonların birleşiminden sonra yorum yazarlarını ve zincirleme yorumları da kontrol edin.

### **Görseller, Ses, Video, OLE Nesneleri ve Harici Bağlantılar**

Slaytlar, sunum‑seviyesi kaynaklar (görseller, gömülü ses, gömülü video, OLE verileri) referans gösterebilir. Sadece görünen şekilleri kopyalamak yerine slaytı tamamen klonlayın; böylece Aspose.Slides, slaydın bu kaynaklarla ilişkisini korur.

Gömülü ve bağlanmış kaynaklar farklı şekilde ele alınmalıdır. Bağlı bir ses, video, OLE nesnesi veya köprü, dış hedefine bağımlı kalır; slaytı klonlamak dış bir bağlantıyı gömülü içeriğe dönüştürmez. Bağlantılı kaynak yollarını ve URL’leri, birleştirilmiş sunumun açılacağı ortamda test edin.

Aspose.Slides otomatik klonlanan masterları izlese de, bu durum, ilişkisiz kaynak sunumlardan gelen aynı ikili kaynakların her zaman tekilleştirileceği anlamına gelmez. Çıktı dosya boyutu önemliyse, birleştirilmiş paketi inceleyin ve sonucu ölçün; örtük tekilleştirmeye güvenmeyin.

### **Gömülü Yazı Tipleri ve Yazı Tipi Kullanılabilirliği**

Yazı tipleri sunum düzeyinde yönetilir. Tipografi makineler arasında tutarlı kalmalıysa, yalnızca slayt klonlamanın her gerekli yazı tipinin hedef ortamda mevcut olacağını varsaymayın. Gömülü yazı tiplerini [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsmanager/getembeddedfonts/) ile inceleyebilir ve [Embed Fonts in Presentations](https://docs.aspose.com/slides/tr/net/embedded-font/)’ta açıklandığı gibi açıkça yönetebilirsiniz.

Ayrıca, kaynak dosyalarda kullanılan yazı tiplerini gömmeye izin verilip verilmediğini doğrulayın. Yazı tipi lisansları gömme işlemini kısıtlayabilir.

### **Parola Koruması Altındaki Sunumlar**

Parola korumalı bir kaynağın slaytları klonlanmadan önce başarıyla açılmalıdır. Parolayı [LoadOptions.Password](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/password/) aracılığıyla sağlayın.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

Şifrelenmiş bir kaynağın açılması, aynı korumanın otomatik olarak hedef sunuma uygulanacağı anlamına gelmez. Gerektiğinde çıkış korumasını ayrı olarak yapılandırın.

### **Büyük Sunumlar ve Bellek Kullanımı**

Yüksek çözünürlüklü görseller, ses, video veya diğer büyük ikili nesneler içeren büyük sunumlar önemli miktarda bellek tüketebilir. [LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/blobmanagementoptions/) BLOB yönetimi ve geçici dosya kullanımını kontrol eder. Büyük dosya stratejileri için [Manage Presentation BLOBs](https://docs.aspose.com/slides/tr/net/manage-blob/) sayfasına bakın.

Büyük dosyalar için mümkün olduğunca dosya yollarından yüklemeyi tercih edin, bir kaynak sunumu birleştirildikten hemen sonra serbest bırakın ve iş akışı ara kaydetme gerektirmiyorsa ara sonuçları tekrar tekrar kaydetmekten kaçının.

### **İş Parçacığı Güvenliği**

Aynı [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) örneğini birden fazla iş parçacığından aynı anda yüklemeyin, değiştirmeyin, kaydetmeyin veya klonlamayın. Her sunum örneğini tek bir birleştirme işlemiyle sınırlı tutun. Bağımsız işleri paralelleştiriyorsanız, bağımsız sunum örnekleri kullanın ve [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/tr/net/multithreading/) izleyin.

## **SSS**

**Her kaynak sunumun orijinal tasarımını nasıl korurum?**

Hedef master veya düzen belirtmeden `AddClone(sourceSlide)` kullanın. Aspose.Slides, içe aktarılan slayt için gerekli olduğunda kaynak masterı otomatik olarak klonlayabilir.

**İçe aktarılan slaydların hedef temayı kullanmasını nasıl sağlarım?**

Hedef master kabul eden aşırı yüklemeyi kullanın. Masterı kaynak sunumdan değil, hedef sunumdan alın. Aspose.Slides, her kaynak slaytı o master altındaki uygun bir düzene eşlemeye çalışır.

**Ne zaman belirli bir hedef düzeni, hedef master yerine tercih etmeliyim?**

Her içe aktarılan slaydın bilinen tek bir düzen kullanması gerektiğinde belirli bir düzen kullanın. Slave slaytların kaynak düzen tipi veya adına göre master altındaki düzenler arasından seçim yapmasını isterseniz master kullanın.

**Farklı slayt boyutlarına sahip sunumlar birleştirilebilir mi?**

Evet, ancak slayt içeriği hedef boyutlar için otomatik olarak yeniden tasarlanmaz. Öngörülebilir konumlandırma için önce kaynak sunumu, örneğin [SlideSize.SetSize](https://reference.aspose.com/slides/tr/net/aspose.slides/slidesize/setsize/) ve [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/tr/net/aspose.slides/slidesizescaletype/) ile yeniden boyutlandırın.

**PPT, PPTX ve ODP sunumlarını tek bir dosyada birleştirebilir miyim?**

Evet. Her kaynak sunumu yükleyin, gerekli slaytları tek bir hedefe klonlayın ve hedefi desteklenen bir çıktı biçiminde kaydedin. Sunum biçimleri aynı özellik setini tam olarak desteklemediği için, çapraz‑biçim birleştirmelerden sonra karmaşık içeriği doğrulayın. [Supported File Formats](https://docs.aspose.com/slides/tr/net/supported-file-formats/) sayfasına bakın.

**Kaynak bölümler otomatik olarak korunur mu?**

Yalnızca slaytları klonlayan temel bir döngü bölümleri korumaz. Gerekli bölümleri hedefte yeniden oluşturun ve bölüm yapısının korunması gerektiğinde [AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection/addclone/) bölüm aşırı yüklemesini kullanın.

**Konuşmacı notları ve yorumlar korunur mu?**

Klonlanan slaytla birlikte kopyalanırlar. Not‑master stili, yorum yazarları veya zincirleme inceleme verileri gibi yapılar sunum‑seviyesinde olduğu için, birleşik sonucu doğrulamak önemlidir.

**Ses, video, OLE nesneleri ve köprüler ne olur?**

Gömülü içerik, klonlanan slaydın kaynak ilişkileriyle birlikte taşınır. Dış bağlantılar dışda kalır; bu nedenle hedefte yine erişilebilir olmaları gerekir.

**Her kaynaktan gelen gömülü yazı tipleri birleşik sunumda mevcut olur mu?**

Sadece slayt klonlamasına güvenerek yazı tiplerinin dağıtılmasını varsaymayın. Hedefteki gömülü yazı tiplerini inceleyin ve tipografi önemliyse yazı tipi gömme veya dış yazı tipi kullanılabilirliğini açıkça yönetin.

**Parola korumalı bir dosyayı nasıl birleştiririm?**

Doğru [LoadOptions.Password](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/password/) ile açın, ardından slaytlarını normal şekilde klonlayın. Çıktı koruması ayrı olarak yapılandırılır.

**Çok büyük sunumları nasıl yönetirim?**

Büyük ikili nesneler belleği domine ettiğinde BLOB yönetimini kullanın, çok büyük dosyalar için dosya‑yolu yüklemeyi tercih edin, kaynak sunumları hızlıca serbest bırakın ve yalnızca gerektiğinde nihai sonucu kaydedin.

**Slaytları birden çok iş parçacığından birleştirebilir miyim?**

Aynı [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) örneğini birden çok iş parçacığından aynı anda kullanmayın. Her birleştirme işlemini kendi sunum örnekleriyle izole tutun.