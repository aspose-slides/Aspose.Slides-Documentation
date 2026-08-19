---
title: Android'de Sunumları Verimli Bir Şekilde Birleştirme
linktitle: Sunumları Birleştir
type: docs
weight: 40
url: /tr/androidjava/merge-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Android'de slaytları klonlayarak, ana sürücüleri ve düzenleri kontrol ederek, slayt içeriğini yeniden boyutlandırarak, bölümleri koruyarak ve korumalı veya büyük dosyalarla başa çıkarak PowerPoint ve OpenDocument sunumlarını nasıl birleştirileceğini öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Android via Java, slaytları bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) kaynağından başka birine klonlayarak sunuları birleştirir. Temel işlem, [ISlideCollection.addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-)'dır; bu işlem kaynak slaytın biçimini koruyabilir veya klonlanan slaytı hedef sunumdaki bir ana sürücüye ya da düzene bağlayabilir.

Bu makale en yaygın birleştirme iş akışlarını kapsar:

- tüm slaytları, kaynak biçimlendirmesini koruyarak birleştir;
- seçili slaytları birleştir;
- hedef sunumun bir ana sürücüsünü uygula;
- hedef sunumdan belirli bir düzeni uygula;
- birleştirmeden önce farklı slayt boyutlarını normalleştir;
- klonlanan slaytları bir bölüme ekle;
- birden fazla sunumu tek bir uçtan uca iş akışında birleştir;
- ana sürücüler, kaynaklar, notlar, yorumlar, medya, yazı tipleri, parolalar, büyük dosyalar ve çok iş parçacıklı kullanım durumlarını ele al.

## **Kaydır Kopyalamanın Ana Sürücüler ve Düzenler Üzerindeki Etkisi**

Bir slayt, görünümünün çoğunu düzeni ve ana sürücüsünden devralır. Bu nedenle seçtiğiniz kopyalama aşırı yüklemesi, birleştirilen slaytın hedef sunuma nasıl entegre edileceğini belirler.

[ISlideCollection.addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidecollection/) yöntemini şu şekillerde kullanın:

- `addClone(sourceSlide)` — kaynak slaytın düzenini ve biçimini korur. Gerektiğinde, kaynak ana sürücü hedef sunuma otomatik olarak klonlanabilir. Aspose.Slides, aynı kaynak ana sürücüyü kullanan yinelenen slaytların aynı ana sürücüyü tekrar klonlamasını önlemek için otomatik klonlanan ana sürücüleri izler.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — klonlanan slaytı belirli bir hedef [IMasterSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterslide/) üzerine bağlar. Aspose.Slides, bu ana sürücünün altında düzen türüne veya adına göre eşleşen bir düzen arar.
- `addClone(sourceSlide, destinationLayout)` — klonlanan slaytı doğrudan belirli bir hedef [ILayoutSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutslide/) üzerine bağlar.

`addClone` aşırı yüklemesine geçirilen ana sürücü veya düzen, **hedef** sunuma ait olmalı, kaynak sunuma ait olmamalıdır.

## **Tam Sunuları Birleştir ve Kaynak Biçimlendirmesini Koru**

En basit birleştirme, kaynak sunumdaki her slaytı hedef sunuma kopyalar. Bu seçenek, içe aktarılan slaytların özgün tema, ana sürücü ve düzen ilişkilerini koruması gerektiğinde uygundur.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Kaynak ve hedef farklı tasarımlar kullandığında ortaya çıkan sunu birden fazla ana sürücü içerebilir. Bu, kaynak biçimlendirmesi bilerek korunduğunda beklenen bir durumdur.

## **Seçili Slaytları Birleştir**

Her slaytı klonlamanız gerekmez. Aşağıdaki örnek, kaynak sunudan yalnızca seçili slayt dizinlerini içe aktarır.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    int[] slideIndexes = { 0, 2, 4 };

    for (int index : slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Kullanıcı girişi veya dış yapılandırmadan gelen slayt dizinlerini klonlamadan önce doğrulayın.

## **Bir Hedef Ana Sürücü Kullanarak Slaytları Birleştir**

İçe aktarılan slaytların zaten hedef sunuma ait bir ana sürücüye göre düzenlenmesi gerekiyorsa, [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) aşırı yüklemesini kullanın.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    IMasterSlide destinationMaster = destination.getMasters().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides, kaynak düzenin türü veya adına göre belirtilen ana sürücü altında uygun bir düzen seçer. Uygun bir düzen bulunmazsa ve `allowCloneMissingLayout` **true** ise, kaynak düzen klonlanır ve slayt eklenebilir. **false** ise bir [PptxEditException](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pptxeditexception/) fırlatılır.

Ek bir düzeni hedef ana sürücüye eklemek istemiyorsanız, birleştirmenin başarısız olmasını sağlamak için **false** kullanın.

## **Belirli Bir Hedef Düzeni Kullanarak Slaytları Birleştir**

İçe aktarılan slaytların kesin olarak hangi hedef düzeni kullanması gerektiğini biliyorsanız, [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) aşırı yüklemesini kullanın.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ILayoutSlide destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Bir hedef düzenin uygulanması, kalıtılan düzen ilişkisini değiştirir; kaynak slayt içeriğini yeniden tasarlamaz. Kaynak ve hedef düzenlerin yer tutucu yapıları farklıysa, kalıtılan biçimlendirme ve yer tutucu davranışının uygun olduğundan emin olmak için sonucu inceleyin.

## **Farklı Slayt Boyutlarına Sahip Sunuları Birleştir**

Farklı slayt boyutlarına sahip sunular birleştirilebilir, ancak bir slaytı farklı bir slayt boyutuna sahip bir sunuya klonlamak, içeriği yeni tuval için otomatik olarak yeniden tasarlamaz. Bu yüzden şekiller kaymış, beklenmedik şekilde ölçeklenmiş ya da görünür slayt alanının dışına çıkmış görünebilir.

Pratik bir yaklaşım, klonlamadan önce kaynak sununun boyutunu değiştirmektir. [SlideSize.setSize](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) yöntemi, slayt boyutlarını değiştirirken mevcut içeriği ölçeklendirebilir. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slidesizescaletype/) içeriği istenen boyuta sığdırmak için ölçeklendirir.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    SizeF sourceSize = source.getSlideSize().getSize();
    SizeF destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
            SlideSizeScaleType.EnsureFit);
    }

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged-same-slide-size.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Yeniden boyutlandırma, kaynak sunu nesnesini bellekte değiştirir. Orijinal kaynak sununun diğer işlemler için değişmeden kalması gerekiyorsa, birleştirme için ayrı bir örnek açın.

## **Slaytları Bir Sunu Bölümüne Birleştir**

Temel slayt‑klonlama döngüsü, kaynak sununun bölüm hiyerarşisini yeniden oluşturmaz. Çıktıda bölümler önemliyse, hedef sunuda bölümler oluşturun veya seçin ve slaytları açıkça [addClone(ISlide, ISection)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) aşırı yüklemesiyle bölümlere klonlayın.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ISection importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, importedSection);
    }

    destination.save("merged-with-section.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Klonlanan slaytlar belirtilen hedef bölüme eklenir. Birden çok kaynak bölümü korumak istiyorsanız, bu bölümleri hedefte yeniden oluşturun ve her kaynak slaytı ilgili hedef bölümüne eşleyin.

## **Birden Çok Sunuyu Güvenli Şekilde Birleştir**

Aşağıdaki uçtan uca örnek, ilk sunuyu hedef olarak alır, ek her bir kaynak sununun slayt boyutunu normalleştirir, her bir kaynağı yalnızca kopyalanırken açık tutar ve sonunda tek bir dosyayı kaydeder.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    SizeF mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            SizeF sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
                    SlideSizeScaleType.EnsureFit);
            }

            for (ISlide slide : source.getSlides()) {
                merged.getSlides().addClone(slide);
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

Bu, içe aktarılan slaytların kaynak biçimlendirmesini korumak için faydalı bir temel örnektir. Çıktının tek bir hedef teması kullanması gerekiyorsa, basit `addClone(slide)` çağrısını daha önce gösterilen uygun hedef‑ana sürücü ya da hedef‑düzen aşırı yüklemesiyle değiştirin.

## **Pratik Düşünceler**

### **Ana Sürücüler, Düzenler ve Biçimlendirme Sadakati**

Varsayılan slayt klonlaması, gerek duyulan bir kaynak ana sürücüyü hedef sunuya otomatik olarak getirebilir. Aspose.Slides, aynı ana sürücünün tekrar tekrar klonlanmasını önlemek için otomatik klonlanan ana sürücüler için dahili bir kayıt tutar. Manuel olarak klonlanan ana sürücüler bu kayıt tarafından izlenmez; bu yüzden ana sürücü yapısı üzerinde kesin kontrol ihtiyacınız yoksa ön‑klonlamaktan kaçının.

Aynı ada sahip iki ana sürücü veya düzenin görsel olarak eşdeğer olduğunu varsamamalısınız. Kurumsal bir şablon son görünümü kontrol ediyorsa, hedef ana sürücüyü veya düzeni açıkça seçin ve birleştirmeden sonra sonucu doğrulayın.

### **Notlar ve Yorumlar**

Konuşmacı notları ve slayt yorumları slayt içeriğiyle ilişkilidir ve bir slayt klonlandığında kopyalanır. Aspose.Slides ayrıca [presentation notes](https://docs.aspose.com/slides/tr/androidjava/presentation-notes/) ve [presentation comments](https://docs.aspose.com/slides/tr/androidjava/presentation-comments/) için özel API’ler sunar.

Not sayfası biçimlendirmesi önemliyse, birleştirilmiş sunuyu kontrol edin; not ana sürücüleri sunum‑seviyesi nesnelerdir ve kaynak dosyalar arasında farklılık gösterebilir. İnceleme iş akışları için, farklı yazarların ya da şablonların dosyalarını birleştirirken yorum yazarlarını ve sınıflı yorumları da doğrulayın.

### **Görseller, Ses, Video, OLE Nesneleri ve Harici Bağlantılar**

Slaytlar, görseller, gömülü ses, gömülü video ve OLE verileri gibi sunum‑seviyesi kaynaklara referans verebilir. Sadece görünür şekilleri kopyalamak yerine slaytı tamamen klonlayın; böylece Aspose.Slides, slaytın bu kaynaklarla ilişkisini korur.

Gömülü ve bağlantılı kaynaklar farklı şekilde ele alınmalıdır. Bağlantılı bir ses, video, OLE nesnesi ya da köprü, dış hedefine bağımlı kalır; bir slaytı klonlamak harici bir bağlantıyı gömülü içeriğe dönüştürmez. Bağlantılı kaynak yollarını ve URL’leri, birleştirilen sununun açılacağı ortamda test edin.

Aspose.Slides otomatik klonlanan ana sürücüleri izler, ancak bu, farklı kaynak sunulardan gelen aynı ikili kaynakların her zaman yinelenmediği anlamına gelmez. Çıktı dosya boyutu önemliyse, birleştirilmiş paketi inceleyin ve sonucu ölçün; örtük yinelenme varsayımına güvenmeyin.

### **Gömülü Yazı Tipleri ve Yazı Tipi Kullanılabilirliği**

Yazı tipleri sunum‑seviyesinde yönetilir. Tipografi farklı makinelerde tutarlı kalmalıysa, sadece slaytları klonlamak, gerekli tüm yazı tiplerinin hedef ortamda bulunacağını garanti etmez. Gömülü yazı tiplerini [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) ile inceleyebilir ve [Embed Fonts in Presentations](https://docs.aspose.com/slides/tr/androidjava/embedded-font/) belgesinde açıklandığı gibi açıkça yönetebilirsiniz.

Ayrıca, kaynak dosyalarda kullanılan yazı tiplerini gömme izninizin olup olmadığını doğrulayın. Yazı tipi lisansları gömme işlemini kısıtlayabilir.

### **Parola‑Koruması Olan Sunular**

Parola korumalı bir kaynak, slaytları klonlanmadan önce başarılı bir şekilde açılmalıdır. Parola, [LoadOptions.setPassword](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) aracılığıyla sağlanır.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // Şifrelenmiş sunum ile çalış.
} finally {
    source.dispose();
}
```

Şifreli bir kaynağı açmak, aynı korumayı otomatik olarak hedef sunuya uygulamaz. Gerektiğinde çıktı korumasını ayrı olarak yapılandırın.

### **Büyük Sunular ve Bellek Kullanımı**

Yüksek çözünürlüklü görseller, ses, video veya diğer büyük ikili nesneler içeren büyük sunular önemli miktarda bellek tüketebilir. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) BLOB yönetimi ve geçici dosya kullanımını kontrol eden ayarlar sunar. Büyük dosya stratejileri için [Manage Presentation BLOBs](https://docs.aspose.com/slides/tr/androidjava/manage-blob/) bölümüne bakın.

Büyük dosyalar için mümkün olduğunca dosya yolu üzerinden yükleme yapın, her bir kaynak sunuyu birleştirme tamamlandığında hemen serbest bırakın ve iş akışı kontrol noktaları gerektirmedikçe ara sonuçları tekrarlı olarak kaydetmekten kaçının.

### **İş Parçacığı Güvenliği**

Aynı [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) örneğini birden çok iş parçacığından aynı anda yüklemeyin, değiştirmeyin, kaydetmeyin veya klonlamayın. Her sunu örneğini tek bir birleştirme işlemiyle sınırlı tutun. Bağımsız işleri paralelleştiriyorsanız, bağımsız sunu örnekleri kullanın ve [Aspose.Slides çok iş parçacıklı kılavuzunu](https://docs.aspose.com/slides/tr/androidjava/multithreading/) izleyin.

## **SSS**

**Kaynak her bir sununun orijinal tasarımını nasıl korurum?**

Hedef ana sürücü ya da düzen sağlamadan, [`addClone(sourceSlide)`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) kullanın. Aspose.Slides, içe aktarılan slayt için gerektiğinde kaynak ana sürücüyü otomatik olarak klonlayabilir.

**İçe aktarılan slaytların hedef temayı kullanmasını nasıl sağlarım?**

Hedef ana sürücü kabul eden aşırı yüklemeyi kullanın. Ana sürücüyü kaynak sunudan değil, hedef sunudan alın. Aspose.Slides, her kaynak slaytı o ana sürücünün uygun bir düzeniyle eşleştirmeye çalışır.

**Ne zaman hedef ana sürücü yerine belirli bir hedef düzen kullanmalıyım?**

Her içe aktarılan slaytın tek bir bilinen düzeni kullanması gerektiğinde belirli bir düzen kullanın. Kaynak slaytların düzen türü veya adına göre birden fazla seçenek varsa ana sürücüyü tercih edin.

**Farklı slayt boyutlarına sahip sunular birleştirilebilir mi?**

Evet, ancak slayt içeriği hedef boyutlar için otomatik olarak yeniden tasarlanmamaktadır. Öngörülebilir yerleşim gerekiyorsa, [SlideSize.setSize](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) ve [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slidesizescaletype/) kullanarak kaynak sunuyu önceden yeniden boyutlandırın.

**PPT, PPTX ve ODP sunularını tek bir dosyada birleştirebilir miyim?**

Evet. Her kaynak sunuyu yükleyin, gereken slaytları bir hedefe klonlayın ve hedefi desteklenen bir çıktı formatında kaydedin. Sunu formatları aynı özellik setini tam olarak desteklemediğinden, çapraz‑format birleştirmelerden sonra karmaşık içeriği doğrulayın. [Supported File Formats](https://docs.aspose.com/slides/tr/androidjava/supported-file-formats/) bölümüne bakın.

**Kaynak bölümler otomatik olarak korunur mu?**

Sadece slaytları klonlayan temel bir döngü bölümleri korumaz. Bölüm yapısı korunmalıysa, hedefte gerekli bölümleri yeniden oluşturun ve [addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) bölüm aşırı yüklemesini kullanın.

**Konuşmacı notları ve yorumlar korunur mu?**

Klonlanan slaytla birlikte kopyalanırlar. Not‑ana sürücü stili, yorum yazarları veya sınıflı değerlendirme verileri gibi yapıların doğruluğunu sağlamak için birleştirilmiş sonucu kontrol edin.

**Ses, video, OLE nesneleri ve köprüler ne olur?**

Gömülü içerikler klonlanmış slaytın kaynak ilişkileriyle birlikte taşınır. Harici bağlantılar dışarıda kalır; hedef dosyalar ya da URL’ler birleştirmeden sonra da erişilebilir olmalıdır.

**Her kaynaktaki gömülü yazı tipleri birleştirilmiş sunuda mevcut olur mu?**

Sadece slayt klonlaması, yazı tiplerinin dağıtılması için yeterli değildir. Hedefteki gömülü yazı tiplerini inceleyin ve tipografi önemliyse gömme ya da dış yazı tipi erişimini açıkça yönetin.

**Şifre korumalı bir dosyayı nasıl birleştiririm?**

Doğru [LoadOptions.setPassword](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) ile açın, ardından slaytlarını normal şekilde klonlayın. Çıktı koruması ayrı olarak yapılandırılır.

**Çok büyük sunularla nasıl başa çıkılır?**

BLOB yönetimini kullanın, mümkün olduğunca dosya yolu üzerinden yükleyin, kaynak sunuları birleştirme tamamlandığında hemen serbest bırakın ve ara sonuçları yalnızca iş akışı kontrol noktaları gerektirdiğinde kaydedin.

**Slaytları birden çok iş parçacığından birleştirebilir miyim?**

Aynı [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) örneğini birden çok iş parçacığından aynı anda kullanmayın. Her birleştirme işlemini kendi bağımsız sunu örnekleriyle izole tutun.