---
title: JavaScript'te Sunumları Verimli Bir Şekilde Birleştirme
linktitle: Sunumları Birleştir
type: docs
weight: 40
url: /tr/nodejs-java/merge-presentation/
keywords:
- PowerPoint'u Birleştir
- Sunumları Birleştir
- Slaytları Birleştir
- PPT'yi Birleştir
- PPTX'i Birleştir
- ODP'yi Birleştir
- PowerPoint'u Kombine Et
- Sunumları Kombine Et
- Slaytları Kombine Et
- PPT'yi Kombine Et
- PPTX'i Kombine Et
- ODP'yi Kombine Et
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript'te slaytları klonlayarak, master ve layout'ları kontrol ederek, slayt içeriğini yeniden boyutlandırarak, bölümleri koruyarak ve korumalı ya da büyük dosyalarla çalışarak PowerPoint ve OpenDocument sunumlarını nasıl birleştireceğinizi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Node.js via Java, bir sunumu bir [Sunum](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) üzerinden bir diğerine slaytları klonlayarak birleştirir. Ana işlem, [SlideCollection.addClone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) olup, kaynak slaytının biçimlendirmesini koruyabilir veya klonlanan slaytı hedef sunumdaki bir master veya layout’a ekleyebilir.

Bu makale en yaygın birleştirme iş akışlarını kapsar:

- kaynak biçimlendirmesini koruyarak tüm slaytları birleştir;
- seçili slaytları birleştir;
- hedef sunumdan bir master uygula;
- hedef sunumdan belirli bir layout uygula;
- birleştirmeden önce farklı slayt boyutlarını normalleştir;
- klonlanan slaytları bir bölüme ekle;
- birkaç sunumu uçtan uca bir iş akışında birleştir;
- masterları, kaynakları, notları, yorumları, medyayı, yazı tiplerini, şifreleri, büyük dosyaları ve çok iş parçacıklı (multithreading) endişeleri ele al.

## **Slayt Klonlamanın Masterlar ve Düzlemlere Etkisi**

Bir slayt görünümünün çoğunu düzeni ve masterından devralır. Bu nedenle, seçtiğiniz klonlama aşırı yüklemesi, birleştirilen slaytın hedef sunuma nasıl entegre edileceğini belirler.

Bu yollarla [SlideCollection.addClone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidecollection/) kullanın:

- `addClone(sourceSlide)` — kaynak slaytın düzenini ve biçimlendirmesini korur. Gerektiğinde, kaynak master otomatik olarak hedef sunuma klonlanabilir. Aspose.Slides, otomatik olarak klonlanan masterları izler, böylece aynı kaynak masterı kullanan tekrar eden slaytlar masterın tekrar klonlanmasını önler.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — klonlanan slaytı belirli bir hedef [MasterSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterslide/) üzerine ekler. Aspose.Slides, o master altında düzen tipine veya adına göre eşleşen bir düzen arar.
- `addClone(sourceSlide, destinationLayout)` — klonlanan slaytı doğrudan belirli bir hedef [LayoutSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutslide/) üzerine ekler.

`addClone` aşırı yüklemesine geçirilen master veya layout, kaynak sunumdan değil, **hedef** sunuma ait olmalıdır.

## **Tüm Sunumları Birleştir ve Kaynak Biçimlendirmesini Koru**

En basit birleştirme, kaynak sunumdaki tüm slaytları hedef sunuma kopyalar. Bu, içe aktarılan slaytların orijinal temalarını, masterlarını ve düzen ilişkilerini koruması gerektiğinde uygun bir seçenektir.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Sonuç sunum, kaynak ve hedef farklı tasarımlar kullandığında birden fazla master içerebilir. Bu, kaynak biçimlendirmesinin kasıtlı olarak korunduğu durumlarda beklenir.

## **Seçili Slaytları Birleştir**

Her slaytı klonlamak zorunda değilsiniz. Aşağıdaki örnek, kaynak sunumdan yalnızca seçili slayt indekslerini içe aktarır.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const slideIndexes = [0, 2, 4];

    for (const index of slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Kullanıcı girişi veya dış yapılandırmadan geldiğinde slayt indekslerini klonlamadan önce doğrulayın.

## **Hedef Master Kullanarak Slaytları Birleştir**

İçe aktarılan slaytların zaten hedef sunuma ait bir master'ı takip etmesi gerektiğinde [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) aşırı yüklemesini kullanın.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationMaster = destination.getMasters().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides, belirtilen master altında kaynak düzenin tipine veya adına göre uygun bir düzen seçer. Uygun bir düzen yoksa ve `allowCloneMissingLayout` `true` ise, slayt eklenebilmesi için kaynak düzen klonlanır. `false` ise bir [PptxEditException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pptxeditexception/) fırlatılır.

Ek bir düzenin hedef mastera eklenmesini istemediğinizde ve birleştirmenin başarısız olmasını istediğinizde `false` kullanın.

## **Belirli Bir Hedef Düzen Kullanarak Slaytları Birleştir**

İçe aktarılan slaytların kullanması gereken hedef düzeni tam olarak bildiğinizde [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) aşırı yüklemesini kullanın.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Bir hedef düzen uygulamak, kalıtsal düzen ilişkisini değiştirir; kaynak slayt içeriğini yeniden tasarlamaz. Kaynak ve hedef düzenlerin farklı yer tutucu yapıları varsa, kalıtsal biçimlendirme ve yer tutucu davranışının uygun olduğunu doğrulamak için sonucu inceleyin.

## **Farklı Slayt Boyutlarına Sahip Sunumları Birleştir**

Farklı slayt boyutlarına sahip sunumlar birleştirilebilir, ancak bir slaytı farklı bir slayt boyutuna sahip bir sunuma klonlamak, içeriği yeni tuval için otomatik olarak yeniden tasarlamaz. Bu nedenle şekiller kaymış, beklenmedik şekilde ölçeklenmiş veya görünür slayt alanının dışına çıkmış görünebilir.

Pratik bir yaklaşım, klonlamadan önce kaynak sunumun boyutunu yeniden ayarlamaktır. [SlideSize.setSize](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) yöntemi, slayt boyutlarını değiştirirken mevcut içeriği ölçeklendirebilir. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidesizescaletype/) içeriği istenen boyuta sığacak şekilde ölçeklendirir.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const sourceSize = source.getSlideSize().getSize();
    const destinationSize = destination.getSlideSize().getSize();
    const sizesDiffer = sourceSize.getWidth() !== destinationSize.getWidth() || 
                        sourceSize.getHeight() !== destinationSize.getHeight();

    if (sizesDiffer) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
            aspose.slides.SlideSizeScaleType.EnsureFit);
    }

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged-same-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Yeniden boyutlandırma, bellek içindeki kaynak sunum nesnesini değiştirir. Diğer işlemler için orijinal kaynak sunumun değiştirilmemiş olmasına ihtiyaç duyarsanız, birleştirme için ayrı bir örnek açın.

## **Slaytları Bir Sunum Bölümüne Birleştir**

Temel slayt klonlama döngüsü, kaynak sunumun bölüm hiyerarşisini yeniden oluşturmaz. Çıktıda bölümler önemliyse, hedef sunumda bölümler oluşturun veya seçin ve slaytları açıkça [addClone(Slide, Section)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-) ile klonlayın.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), importedSection);
    }

    destination.save("merged-with-section.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Klonlanan slaytlar belirtilen hedef bölümün sonuna eklenir. Birden fazla kaynak bölümünü korumak için [Presentation.getSections](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#getSections) listesini alın, her kaynak bölümünün mevcut slaytlarını [Section.getSlidesListOfSection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/section/#getSlidesListOfSection) ile alın, hedefte bölümleri yeniden oluşturun ve her alınan slaytı ilgili hedef bölümüne klonlayın. Boş bölümler ve yapısal değişiklikler dahil tam bir bölüm listesi örneği için [Manage Slide Sections](/slides/tr/nodejs-java/slide-section/) bölümüne bakın.

## **Birden Çok Sunumu Güvenli Bir Şekilde Birleştir**

Aşağıdaki uçtan uca örnek, ilk sunumu hedef olarak kullanır, ek her bir kaynağın slayt boyutunu normalleştirir, her kaynağı yalnızca kopyalanırken açık tutar ve sonunda dosyayı bir kez kaydeder.

```javascript
const aspose = require("aspose.slides.via.java");

const inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

const merged = new aspose.slides.Presentation(inputFiles[0]);
try {
    const mergedSize = merged.getSlideSize().getSize();

    for (let fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        const source = new aspose.slides.Presentation(inputFiles[fileIndex]);
        try {
            const sourceSize = source.getSlideSize().getSize();
            const sizesDiffer = sourceSize.getWidth() !== mergedSize.getWidth() || 
                                sourceSize.getHeight() !== mergedSize.getHeight();

            if (sizesDiffer) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
                    aspose.slides.SlideSizeScaleType.EnsureFit);
            }

            for (let slideIndex = 0; slideIndex < source.getSlides().size(); slideIndex++) {
                merged.getSlides().addClone(source.getSlides().get_Item(slideIndex));
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

Bu, içe aktarılan slaytların kaynak biçimlendirmesini korumak için yararlı bir temel sağlar. Çıktınızın tek bir hedef tema kullanması gerekiyorsa, basit `addClone(sourceSlide)` çağrısını daha önce gösterilen uygun hedef-master veya hedef-düzen aşırı yüklemesi ile değiştirin.

## **Pratik Düşünceler**

### **Masterlar, Düzlemler ve Biçimlendirme Doğruluğu**

Varsayılan slayt klonlama, gerekli kaynak masterı otomatik olarak hedef sunuma getirebilir. Aspose.Slides, aynı masterın tekrar tekrar klonlanmasını önlemek için otomatik klonlanan masterlar için dahili bir kayıt tutar. Manuel olarak klonlanan masterlar bu kayıt tarafından izlenmez, bu yüzden master yapısı üzerinde açık kontrol ihtiyacınız yoksa önceden klonlamaktan kaçının.

Aynı ada sahip iki masterın veya düzenin görsel olarak eşdeğer olduğunu varsaymayın. Kurumsal bir şablonun nihai görünümü kontrol etmesi gerekiyorsa, hedef masterı veya düzeni açıkça seçin ve birleştirmeden sonra sonucu doğrulayın.

### **Notlar ve Yorumlar**

Sunucu notları ve slayt yorumları slayt içeriğiyle ilişkilidir ve bir slayt klonlandığında kopyalanır. Aspose.Slides ayrıca [presentation notes](/slides/tr/nodejs-java/presentation-notes/) ve [presentation comments](/slides/tr/nodejs-java/presentation-comments/) için özel API'ler sunar.

Not sayfasının biçimlendirmesi önemliyse, not masterlarının sunum seviyesinde nesneler olduğu ve kaynak dosyalar arasında farklı olabileceği için birleştirilmiş sunumu doğrulayın. Gözden geçirme iş akışları için, farklı yazarlar veya şablonlardan dosyalar birleştirildikten sonra yorum yazarlarını ve zincirleme yorumları da doğrulayın.

### **Görseller, Ses, Video, OLE Nesneleri ve Harici Bağlantılar**

Slaytlar, görseller, gömülü ses, gömülü video ve OLE verileri gibi sunum seviyesindeki kaynaklara referans verebilir. Aspose.Slides'in slaytın kaynaklarla ilişkisini koruyabilmesi için yalnızca görünür şekilleri kopyalamak yerine slaytı kendisini klonlayın.

Gömülü ve bağlantılı kaynaklar farklı şekilde ele alınmalıdır. Bağlantılı bir ses, video, OLE nesnesi veya hiperlink, dış hedefine bağımlı kalır; bir slaytı klonlamak, dış bağlantıyı gömülü içeriğe dönüştürmez. Bağlantılı kaynak yollarını ve URL'lerini birleştirilmiş sunumun açılacağı ortamda test edin.

Aspose.Slides otomatik klonlanan masterları açıkça izler, ancak bu, alakasız kaynak sunumlardan gelen aynı ikili kaynakların her zaman tekrarsız (deduplicate) olacağına dair genel bir garanti olarak görülmemelidir. Çıktı dosya boyutu önemliyse, gizli tekrarsızlığa güvenmek yerine birleştirilmiş paketi inceleyin ve sonucu ölçün.

### **Gömülü Yazı Tipleri ve Yazı Tipi Kullanılabilirliği**

Yazı tipleri sunum seviyesinde yönetilir. Tipografinin makineler arasında tutarlı kalması gerekiyorsa, yalnızca slaytları klonlamanın her gerekli yazı tipinin hedef ortamda mevcut olacağını varsaymayın. Gömülü yazı tiplerini [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) ile inceleyebilir ve [Embed Fonts in Presentations](/slides/tr/nodejs-java/embedded-font/) bölümünde açıklandığı gibi gömme işlemini açıkça yönetebilirsiniz.

Ayrıca, kaynak dosyalarda kullanılan yazı tiplerini gömmeye izin verilip verilmediğini doğrulayın. Yazı tipi lisansları gömme işlemini kısıtlayabilir.

### **Şifre Koruması Olan Sunumlar**

Şifre korumalı bir kaynak, slaytları klonlanmadan önce başarıyla açılmalıdır. Parolayı [LoadOptions.setPassword](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#setPassword-String-) aracılığıyla sağlayın.

```javascript
const aspose = require("aspose.slides.via.java");

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

const source = new aspose.slides.Presentation("protected.pptx", loadOptions);
try {
    // Şifre çözülmüş sunumla çalışın.
} finally {
    source.dispose();
}
```

Şifreli bir kaynağın açılması, aynı korumayı otomatik olarak hedef sunuma uygulamaz. Gerektiğinde çıkış korumasını ayrı olarak yapılandırın.

### **Büyük Sunumlar ve Bellek Kullanımı**

Yüksek çözünürlüklü görseller, ses, video veya diğer büyük ikili nesneler içeren büyük sunumlar önemli miktarda bellek tüketebilir. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--) BLOB yönetimi ve geçici dosya kullanımını kontrol eder. Büyük dosya stratejileri için [Manage Presentation BLOBs](/slides/tr/nodejs-java/manage-blob/) bölümüne bakın.

Büyük dosyalar için mümkün olduğunda dosya yollarından yüklemeyi tercih edin, her kaynak sunumu birleştirildikten hemen sonra serbest bırakın ve iş akışı kontrol noktaları gerektirmiyorsa ara sonuçları tekrar tekrar kaydetmekten kaçının.

### **İş Parçacığı Güvenliği**

Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) örneğini birden çok iş parçacığında yüklemeyin, kaydetmeyin veya klonlamayın. Bu işlemler çok iş parçacıklı kullanım için desteklenmez. Bağımsız birleştirme görevlerini paralelleştirmeniz gerekiyorsa, her biri kendi sunum örneklerine sahip birkaç tek iş parçacıklı süreç kullanın ve [Aspose.Slides multithreading guidance](/slides/tr/nodejs-java/multithreading/) yönergelerini izleyin.

## **SSS**

**Her kaynak sunumun orijinal tasarımını nasıl korurum?**

[addClone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) kullanın, hedef master veya layout sağlamadan. Aspose.Slides, içe aktarılan slayt tarafından gerektiğinde kaynak masterı otomatik olarak klonlayabilir.

**İçe aktarılan slaytların hedef temayı kullanmasını nasıl sağlarım?**

Hedef master kabul eden aşırı yüklemeyi kullanın. Kaynaktan değil, hedef sunumdan bir master geçin. Aspose.Slides, her kaynak slaytı o master altındaki uygun bir düzene eşlemeye çalışacaktır.

**Her içe aktarılan slaytın bilinen bir düzene sahip olması gerektiğinde belirli bir hedef düzen kullanmalı mıyım, yoksa hedef master mı?**

Her içe aktarılan slaytın bilinen bir düzeni kullanması gerektiğinde belirli bir düzen kullanın. Kaynak düzen tipine veya adına göre Aspose.Slides'in o masterın düzenleri arasından seçim yapmasını istiyorsanız master kullanın.

**Farklı slayt boyutlarına sahip sunumlar birleştirilebilir mi?**

Evet, ancak slayt içeriği hedef boyutlar için otomatik olarak yeniden tasarlanmaz. Öngörülebilir yerleşim gerektiğinde, örneğin [SlideSize.setSize](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) ve [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidesizescaletype/) ile önce kaynak sunumu yeniden boyutlandırın.

**PPT, PPTX ve ODP sunumlarını tek bir dosyada birleştirebilir miyim?**

Evet. Her kaynak sunumu yükleyin, gerekli slaytları tek bir hedefe klonlayın ve hedefi desteklenen bir çıktı biçiminde kaydedin. Sunum biçimleri tam olarak aynı özellik setini desteklemediği için, formatlar arası birleştirmelerden sonra karmaşık içeriği doğrulayın. [Supported File Formats](/slides/tr/nodejs-java/supported-file-formats/) bölümüne bakın.

**Kaynak bölümler otomatik olarak korunur mu?**

Sadece slaytları klonlayan temel bir döngü tarafından otomatik olarak korunmaz. Gereken bölümleri hedefte yeniden oluşturun ve bölüm yapısı korunmalıysa [addClone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-) bölüm aşırı yüklemesini kullanın.

**Sunucu notları ve yorumlar korunur mu?**

Klonlanan slaytla birlikte kopyalanırlar. Not-master stiline, yorum yazarlarına veya zincirleme inceleme verilerine bağımlı iş akışları için, bu senaryoların sunum seviyesindeki yapıların yanı sıra slayt seviyesindeki içeriği de içerdiği için birleştirilmiş sonucu doğrulayın.

**Ses, video, OLE nesneleri ve hiperlinklerle ne olur?**

Gömülü içerik, klonlanan slaytın kaynak ilişkilerinin bir parçası olarak taşınır. Harici bağlantılar harici kalır, bu nedenle hedef dosyaları veya URL'leri birleştirmeden sonra hâlâ erişilebilir olmalıdır.

**Her kaynak için gömülü yazı tiplerinin birleştirilmiş sunumda bulunması garanti mi?**

Yazı tipi dağıtımı için yalnızca slayt klonlamasına güvenmeyin. Tipografi önemliyse, hedefin gömülü yazı tiplerini inceleyin ve yazı tipi gömme veya dış yazı tipi kullanılabilirliğini açıkça yönetin.

**Şifre korumalı bir dosyayı nasıl birleştiririm?**

Doğru [LoadOptions.setPassword](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#setPassword-String-) ile açın, ardından slaytlarını normal şekilde klonlayın. Çıktı koruması ayrı olarak yapılandırılır.

**Çok büyük sunumları nasıl yönetmeliyim?**

Büyük ikili nesneler bellek kullanımını domine ettiğinde BLOB yönetimini kullanın, çok büyük dosyalar için dosya yolu yüklemeyi tercih edin, kaynak sunumları hızlıca serbest bırakın ve nihai sonucu yalnızca gerektiğinde kaydedin.

**Birden çok iş parçacığından slaytları birleştirebilir miyim?**

Sunum örneklerini birden çok iş parçacığında yüklemeyin, kaydetmeyin veya klonlamayın. Paralel birleştirme görevleri için ayrı tek iş parçacıklı süreçler ve bağımsız sunum örnekleri kullanın.