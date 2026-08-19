---
title: JavaScript'te Sunumları Verimli Şekilde Birleştirme
linktitle: Sunumları Birleştir
type: docs
weight: 40
url: /tr/nodejs-java/merge-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript'te slaytları kopyalayarak, ana temasını ve yerleşimlerini kontrol ederek, slayt içeriğini yeniden boyutlandırarak, bölümleri koruyarak ve korumalı ya da büyük dosyalarla başa çıkarak PowerPoint ve OpenDocument sunumlarını nasıl birleştireceğinizi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Node.js via Java, slaytları bir [Sunum](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/)'dan diğerine kopyalayarak birleştirir. Temel işlem, kaynak slaydın biçimlendirmesini koruyabilen veya kopyalanan slaytı hedef sunumdaki bir ana ya da yerleşimle ilişkilendirebilen [SlideCollection.addClone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) metodudur.

Bu makale en yaygın birleştirme iş akışlarını kapsar:

- kaynak biçimlendirmesini koruyarak tüm slaytları birleştir;
- seçili slaytları birleştir;
- hedef sunumun bir ana temasını uygula;
- hedef sunumdan belirli bir yerleşim uygula;
- birleştirmeden önce farklı slayt boyutlarını normalleştir;
- kopyalanan slaytları bir bölüme ekle;
- birden fazla sunumu uçtan uca bir iş akışında birleştir;
- ana temalar, kaynaklar, notlar, yorumlar, medya, yazı tipleri, parolalar, büyük dosyalar ve çoklu iş parçacığı konularını yönet.

## **Slayt Kopyalamanın Ana Temalar ve Yerleşimler Üzerindeki Etkisi**

Bir slayt, görünümünün büyük bir kısmını yerleşim ve anasünden (master) alır. Bu yüzden seçtiğiniz kopyalama aşırı yüklemesi, birleştirilen slaydın hedef sunuma nasıl entegre edileceğini belirler.

[SlideCollection.addClone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidecollection/) metodunu şu şekillerde kullanın:

- `addClone(sourceSlide)` — kaynak slaydın yerleşimini ve biçimlendirmesini korur. Gerekirse, kaynak ana otomatik olarak hedef sunuma kopyalanabilir. Aspose.Slides, aynı kaynak ana teması kullanan tekrarlı slaytların aynı ana temayı yeniden kopyalamasını önlemek için otomatik kopyalanan ana temaları izler.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — kopyalanan slaytı belirli bir hedef [MasterSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterslide/)'e bağlar. Aspose.Slides, bu ana temanın altında yerleşim tipine ya da adına göre eşleşen bir yerleşim arar.
- `addClone(sourceSlide, destinationLayout)` — kopyalanan slaytı doğrudan belirli bir hedef [LayoutSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutslide/)'e bağlar.

`addClone` aşırı yüklemesine geçirilen ana ya da yerleşim, **hedef** sunuma ait olmalı, kaynak sunuma ait olmamalıdır.

## **Tüm Sunumları Birleştir ve Kaynak Biçimlendirmesini Koruyun**

En basit birleştirme, kaynak sunumdaki her slaytı hedef sunuma kopyalar. Bu, içe aktarılan slaytların özgün temalarını, ana temalarını ve yerleşim ilişkilerini koruması gerektiğinde uygun seçimdir.

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

Kaynak ve hedef farklı tasarımlar kullandığında sonuç sunum birden fazla ana tema içerebilir. Kaynak biçiminin kasıtlı olarak korunması durumunda bu beklenen bir davranıştır.

## **Seçili Slaytları Birleştir**

Her slaytı kopyalamanız gerekmez. Aşağıdaki örnek, kaynak sunumdan yalnızca seçili slayt indekslerini içe aktarır.

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

Kullanıcı girişi ya da dış yapılandırmadan gelen indeksleri kopyalamadan önce doğrulayın.

## **Hedef Ana Kullanarak Slaytları Birleştir**

İçe aktarılan slaytların zaten hedef sunuma ait bir ana temayı takip etmesi gerektiğinde, [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) aşırı yüklemesini kullanın.

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

Aspose.Slides, kaynak yerleşimin tipine ya da adına göre belirtilen ana temanın altında uygun bir yerleşim seçer. Uygun bir yerleşim bulunmazsa ve `allowCloneMissingLayout` `true` ise, kaynak yerleşim kopyalanır ve slayt eklenebilir. `false` ise bir [PptxEditException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pptxeditexception/) fırlatılır.

Ek bir yerleşim eklemek yerine birleştirmenin başarısız olmasını istiyorsanız `false` kullanın.

## **Belirli Bir Hedef Yerleşim Kullanarak Slaytları Birleştir**

İçe aktarılan slaytların tam olarak hangi hedef yerleşimi kullanması gerektiğini bildiğinizde, [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) aşırı yüklemesini kullanın.

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

Bir hedef yerleşim uygulamak, kalıtılan yerleşim ilişkisini değiştirir; kaynak slayt içeriğini yeniden tasarlamaz. Kaynak ve hedef yerleşimlerin yer tutucu yapıları farklıysa, kalıtılan biçimlendirme ve yer tutucu davranışının uygun olup olmadığını doğrulamak için sonucu inceleyin.

## **Farklı Slayt Boyutlarına Sahip Sunumları Birleştir**

Farklı slayt boyutlarına sahip sunumlar birleştirilebilir, ancak bir slaytı başka bir slayt boyutuna kopyalamak, içeriği yeni tuval boyutuna otomatik yeniden tasarlamaz. Bu nedenle şekiller kaymış, beklenmedik şekilde ölçeklenmiş ya da görünür slayt alanının dışına çıkmış görünebilir.

Pratik bir yaklaşım, kopyalamadan önce kaynak sunumu yeniden boyutlandırmaktır. [SlideSize.setSize](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) yöntemi, slayt boyutlarını değiştirirken mevcut içeriği ölçeklendirebilir. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidesizescaletype/) içeriği isteğe bağlı boyuta sığdırmak için ölçeklendirir.

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

Yeniden boyutlandırma, kaynak sunum nesnesini bellekte değiştirir. Orijinal kaynak sunumun diğer işlemler için değişmeden kalmasını istiyorsanız, birleştirme için ayrı bir örnek açın.

## **Slaytları Bir Sunum Bölümüne Birleştir**

Temel slayt kopyalama döngüsü, kaynak sunumun bölüm hiyerarşisini yeniden oluşturmaz. Çıktıda bölümler önemliyse, hedef sunumda bölümler oluşturun ya da seçin ve slaytları açıkça [addClone(Slide, Section)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-) ile bu bölümlere kopyalayın.

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

Kopyalanan slaytlar belirtilen hedef bölüme eklenir. Birden fazla kaynak bölümü korumak için, bu bölümleri hedefte yeniden oluşturun ve her kaynak slaytı karşılık gelen hedef bölüme eşleyin.

## **Birden Çok Sunumu Güvenli Bir Şekilde Birleştir**

Aşağıdaki uçtan uca örnek, ilk sunumu hedef olarak kullanır, her ek kaynak için slayt boyutunu normalleştirir, her kaynağı yalnızca kopyalanırken açık tutar ve sonunda tek bir dosya olarak kaydeder.

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

Bu, içe aktarılan slaytların kaynak biçimlendirmesini korumak için yararlı bir temel sunar. Çıktınız tek bir hedef teması kullanacaksa, basit `addClone(sourceSlide)` çağrısını önceki örneklerde gösterilen uygun hedef‑ana ya da hedef‑yerleşim aşırı yüklemesiyle değiştirin.

## **Pratik Hususlar**

### **Ana Temalar, Yerleşimler ve Biçimlendirme Sadakati**

Varsayılan slayt kopyalama, gerektiğinde kaynak ana temayı hedef sunuma otomatik olarak getirebilir. Aspose.Slides, aynı ana temanın tekrar tekrar kopyalanmasını önlemek için otomatik kopyalanan ana temaları içsel bir kayıt defterinde tutar. Manuel kopyalanan ana temalar bu kayıt defteri tarafından izlenmez; bu yüzden ana temaları önceden kopyalamaktan kaçının, aksi takdirde yapı üzerinde kesin kontrol gerekmediği sürece.

Aynı ada sahip iki ana tema ya da yerleşimin görsel olarak eşdeğer olduğunu varsaymayın. Kurumsal bir şablon son görünümü kontrol ediyorsa, hedef bir ana tema ya da yerleşim seçin ve birleştirme sonrası sonucu doğrulayın.

### **Notlar ve Yorumlar**

Sunucu notları ve slayt yorumları slayt içeriğiyle ilişkilidir ve bir slayt kopyalandığında da kopyalanır. Aspose.Slides ayrıca [sunum notları](https://docs.aspose.com/slides/tr/nodejs-java/presentation-notes/) ve [sunum yorumları](https://docs.aspose.com/slides/tr/nodejs-java/presentation-comments/) için özel API'ler sunar.

Not sayfası biçimlendirmesi önemliyse, birleştirilmiş sunumu kontrol edin; çünkü not ana temaları sunum seviyesinde nesnelerdir ve kaynak dosyalar arasında farklılık gösterebilir. İnceleme iş akışları için, farklı yazarlar ya da şablonlardan gelen dosyaları birleştirirken yorum yazarlarını ve zincirleme yorumları da doğrulayın.

### **Görseller, Ses, Video, OLE Nesneleri ve Dış Bağlantılar**

Slaytlar, görseller, gömülü ses, gömülü video ve OLE verileri gibi sunum‑seviyesi kaynaklara referans verebilir. Sadece görünür şekilleri kopyalamak yerine slaytı tamamen kopyalayın; böylece Aspose.Slides, slaydın bu kaynaklarla ilişkisini korur.

Gömülü ve bağlı kaynakların farklı şekilde ele alınması gerekir. Bağlı bir ses, video, OLE nesnesi ya da köprü, dış hedefe bağımlı kalır; slaytı kopyalamak bir dış bağlantıyı gömülü içeriğe dönüştürmez. Bağlı kaynak yollarını ve URL'leri, birleştirilmiş sunumun açılacağı ortamda test edin.

Aspose.Slides otomatik kopyalanan ana temaları izler, ancak bu, farklı kaynak sunumlardan aynı ikili (binary) kaynakların her zaman tekilleştirileceği garantisi değildir. Çıktı dosya boyutu önemliyse, birleştirilmiş paketi inceleyin ve sonucu ölçün; gizli tekilleştirmeye güvenmeyin.

### **Gömülü Yazı Tipleri ve Yazı Tipi Kullanılabilirliği**

Yazı tipleri sunum seviyesinde yönetilir. Tipografi farklı makinelerde tutarlı kalmalıysa, yalnızca slayt kopyalamanın gerekli tüm yazı tiplerinin hedef ortamda bulunacağını varsaymayın. Gömülü yazı tiplerini [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) ile inceleyebilir ve [Sunumlara Yazı Tipi Gömme](https://docs.aspose.com/slides/tr/nodejs-java/embedded-font/) bölümünde açıklandığı gibi gömme işlemini açıkça yönetebilirsiniz.

Ayrıca, kaynak dosyalarda kullanılan yazı tiplerini gömme izniniz olduğundan emin olun. Yazı tipi lisansları gömmeyi kısıtlayabilir.

### **Parola Korumalı Sunumlar**

Parola korumalı bir kaynak, slaytları kopyalamadan önce başarılı bir şekilde açılmalıdır. Parolayı [LoadOptions.setPassword](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#setPassword-String-) ile sağlayın.

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

Şifreli bir kaynağı açmak, aynı korumanın hedef sunuma otomatik uygulanacağı anlamına gelmez. Gerektiğinde çıktı korumasını ayrı olarak yapılandırın.

### **Büyük Sunumlar ve Bellek Kullanımı**

Yüksek çözünürlüklü görseller, ses, video ya da diğer büyük ikili nesneler içeren büyük sunumlar önemli miktarda bellek tüketebilir. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--) BLOB yönetimi ve geçici dosya kullanımını kontrol etmenizi sağlar. Büyük dosyalar için [Sunum BLOB'larını Yönetme](https://docs.aspose.com/slides/tr/nodejs-java/manage-blob/) sayfasına bakın.

Büyük dosyalarla çalışırken mümkün olduğunca dosya yollarından yükleme yapın, bir kaynak sunumu birleştirme tamamlandığında hemen serbest bırakın ve iş akışı kontrol noktaları gerektirmiyorsa ara sonuçları tekrar tekrar kaydetmekten kaçının.

### **İş Parçacığı Güvenliği**

Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) örneğini birden çok iş parçacığında yüklemeyin, kaydetmeyin ya da kopyalamayın. Bu işlemler çok iş parçacıklı kullanım için desteklenmez. Bağımsız birleştirme görevlerini paralelleştirmeniz gerekiyorsa, her biri kendi sunum örneklerine sahip birden çok tek iş parçacıklı süreç kullanın ve [Aspose.Slides çok iş parçacığı rehberi](https://docs.aspose.com/slides/tr/nodejs-java/multithreading/)ni izleyin.

## **SSS**

**Kaynak sunumların orijinal tasarımını nasıl korurum?**

Bir hedef ana tema ya da yerleşim sağlamadan [`addClone(sourceSlide)`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) kullanın. Aspose.Slides, içe aktarılan slayt tarafından ihtiyaç duyulduğunda kaynak anayı otomatik olarak kopyalayabilir.

**İçe aktarılan slaytların hedef temayı kullanmasını nasıl sağlarım?**

Hedef bir ana tema kabul eden aşırı yüklemeyi kullanın. Kaynak değil, hedef sunumdan bir ana tema geçin. Aspose.Slides, her kaynak slaytı o ana temanın uygun bir yerleşimine eşlemeye çalışacaktır.

**Belirli bir hedef yerleşim ne zaman tercih edilmeli, hedef ana tema ne zaman?**

Her içe aktarılan slaydın aynı bilinen yerleşimi kullanması gerektiğinde belirli bir yerleşim kullanın. Kaynak slaytların yerleşim tipi ya da adını temel alarak uygun bir yerleşim seçilmesi isteniyorsa ana tema kullanın.

**Farklı slayt boyutlarına sahip sunumlar birleştirilebilir mi?**

Evet, ancak slayt içeriği hedef boyutlara otomatik olarak yeniden tasarlanmamış olur. Öngörülebilir konumlandırma için önce kaynak sunumu yeniden boyutlandırın; örneğin [SlideSize.setSize](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) ve [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidesizescaletype/) kullanabilirsiniz.

**PPT, PPTX ve ODP sunumlarını tek bir dosyada birleştirebilir miyim?**

Evet. Her kaynak sunumu yükleyin, gereken slaytları tek bir hedefe kopyalayın ve hedefi desteklenen bir çıktı formatında kaydedin. Sunum formatları aynı özellik setini tam olarak desteklemediği için, farklı format birleşimlerinden sonra karmaşık içerikleri doğrulayın. [Desteklenen Dosya Biçimleri](https://docs.aspose.com/slides/tr/nodejs-java/supported-file-formats/) sayfasına bakın.

**Kaynak bölümler otomatik olarak korunur mu?**

Sadece slaytları kopyalayan temel bir döngü bölümleri korumaz. Bölüm yapısı korunmalıysa, hedefte gerekli bölümleri yeniden oluşturun ve bölüm aşırı yüklemesiyle `[addClone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-)` kullanın.

**Sunucu notları ve yorumlar korunur mu?**

Kopyalanan slaytla birlikte kopyalanırlar. Not‑ana tasarımları, yorum yazarları veya zincirleme inceleme verileri gibi öğeler sunum‑seviyesi yapıları da içerdiği için birleştirilmiş sonucu doğrulayın.

**Ses, video, OLE nesneleri ve köprüler ne olur?**

Gömülü içerik, kopyalanan slaydın kaynak ilişkileri içinde taşınır. Dış bağlantılar dış kalır; hedef dosyalar ya da URL'ler birleştirmeden sonra hâlâ erişilebilir olmalıdır.

**Her kaynağın gömülü yazı tipleri birleştirilmiş sunumda garanti edilir mi?**

Yalnızca slayt kopyalamaya güvenmeyin. Hedefte gömülü yazı tiplerini inceleyin ve tipografi önemliyse yazı tiplerini açıkça yönetin ya da dış yazı tiplerinin kullanılabilirliğini sağlayın.

**Parola korumalı bir dosyayı nasıl birleştiririm?**

Doğru [LoadOptions.setPassword](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#setPassword-String-) ile açın, ardından slaytlarını normal şekilde kopyalayın. Çıktı koruması ayrı olarak yapılandırılır.

**Çok büyük sunumları nasıl yönetirim?**

Büyük ikili nesneler belleği domine ediyorsa BLOB yönetimini kullanın, çok büyük dosyalar için dosya yolu üzerinden yüklemeyi tercih edin, kaynak sunumları derhal serbest bırakın ve nihai sonucu yalnızca gerektiğinde kaydedin.

**Slaytları birden çok iş parçacığından birleştirebilir miyim?**

Sunum örneklerini birden çok iş parçacığında yüklemeyin, kaydetmeyin ya da kopyalamayın. Paralel birleştirme işleri için ayrı tek‑iş‑parçacıklı süreçler ve bağımsız sunum örnekleri kullanın.