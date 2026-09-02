---
title: Java'da Sunumları Verimli Bir Şekilde Birleştirme
linktitle: Sunumları Birleştir
type: docs
weight: 40
url: /tr/java/merge-presentation/
keywords:
- PowerPoint'i birleştir
- sunumları birleştir
- slaytları birleştir
- PPT'yi birleştir
- PPTX'i birleştir
- ODP'yi birleştir
- PowerPoint'i bir araya getir
- sunumları bir araya getir
- slaytları bir araya getir
- PPT'yi bir araya getir
- PPTX'i bir araya getir
- ODP'yi bir araya getir
- Java
- Aspose.Slides
description: "Java'da slaytları klonlayarak, master ve layoutları kontrol ederek, slayt içeriğini yeniden boyutlandırarak, bölümleri koruyarak ve korumalı ya da büyük dosyaları yöneterek PowerPoint ve OpenDocument sunumlarını nasıl birleştireceğinizi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Java, bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) dan diğerine slaytları klonlayarak sunumları birleştirir. Ana işlem, kaynak slaydın biçimlendirmesini koruyabilen veya klonlanan slaytı hedef sunumdaki bir master veya layouta ekleyebilen [ISlideCollection.addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) metodudur.

Bu makale en yaygın birleştirme senaryolarını kapsar:

- tüm slaytları, kaynak biçimlendirmeleri korunarak birleştirme;
- seçili slaytları birleştirme;
- hedef sunumdan bir master uygulama;
- hedef sunumdan belirli bir layout uygulama;
- birleştirmeden önce farklı slayt boyutlarını normalleştirme;
- klonlanan slaytları bir bölüme ekleme;
- birden fazla sunumu uçtan uca bir iş akışında birleştirme;
- masterlar, kaynaklar, notlar, yorumlar, medya, fontlar, parolalar, büyük dosyalar ve çoklu iş parçacığı konularını ele alma.

## **Slayt Klonlamanın Master ve Layoutlara Etkisi**

Bir slayt, görünümünün büyük bir kısmını layout ve masterdan devralır. Bu yüzden seçtiğiniz klonlama aşırı yüklemesi, birleştirilen slaydın hedef sunum içinde nasıl entegre edileceğini belirler.

[ISlideCollection.addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidecollection/) metodunu aşağıdaki şekillerde kullanın:

- `addClone(sourceSlide)` — kaynak slaydın layout ve biçimlendirmesini korur. Gerektiğinde, kaynak master otomatik olarak hedef sunuma klonlanabilir. Aspose.Slides, otomatik klonlanan masterları izler; aynı kaynak masterı kullanan tekrar eden slaytlar bu masterın birden çok kez klonlanmasını önler.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — klonlanan slaytı belirli bir hedef [IMasterSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterslide/) e ekler. Aspose.Slides, o master altında layout tipine veya adına göre eşleşen bir layout arar.
- `addClone(sourceSlide, destinationLayout)` — klonlanan slaytı doğrudan belirli bir hedef [ILayoutSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutslide/) e ekler.

`addClone` aşırı yüklemesine verilen master ya da layout, **hedef** sunuma ait olmalı, kaynak sunuma ait olmamalıdır.

## **Tüm Sunumları Birleştir ve Kaynak Biçimlendirmesini Koru**

En basit birleştirme, kaynak sunumdaki tüm slaytları hedef sunuma kopyalar. Bu, içe aktarılan slaytların orijinal tema, master ve layout ilişkilerini koruması gerektiğinde uygun bir seçimdir.

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

Kaynak ve hedef farklı tasarımlar kullandığında sonuç sunum birden çok master içerebilir. Bu, kaynak biçimlendirmesinin bilinçli olarak korunması durumunda beklenen bir durumdur.

## **Seçili Slaytları Birleştir**

Tüm slaytları klonlamanız gerekmez. Aşağıdaki örnek, kaynak sunumdan yalnızca seçili slayt indekslerini içe aktarır.

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

Kullanıcı girdisi ya da dış yapılandırmadan gelen indeksler klonlanmadan önce doğrulanmalıdır.

## **Hedef Master Kullanarak Slaytları Birleştir**

İçe aktarılan slaytların zaten hedef sunuma ait bir masterı takip etmesi gerektiğinde [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) aşırı yüklemesini kullanın.

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

Aspose.Slides, kaynak layoutun tipine veya adına göre belirtilen master altında uygun bir layout seçer. Uygun bir layout bulunmazsa ve `allowCloneMissingLayout` `true` ise, kaynak layout klonlanır ve slayt eklenebilir. `false` ise bir [PptxEditException](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pptxeditexception/) fırlatılır.

Ek bir layout eklenmesini istemiyorsanız birleştirmenin başarısız olmasını sağlamak için `false` kullanın.

## **Belirli Bir Hedef Layout Kullanarak Slaytları Birleştir**

İçe aktarılacak slaytların kesinlikle hangi hedef layoutu kullanması gerektiğini bildiğinizde [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) aşırı yüklemesini kullanın.

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

Hedef layoutun uygulanması, kalıtılan layout ilişkisinin değişmesini sağlar; kaynak slayt içeriğini yeniden tasarlamaz. Kaynak ve hedef layoutların yer tutucu yapıları farklı ise, kalıtılan biçimlendirme ve yer tutucu davranışının uygun olduğundan emin olmak için sonucu inceleyin.

## **Farklı Slayt Boyutlarına Sahip Sunumları Birleştir**

Farklı slayt boyutlarına sahip sunumlar birleştirilebilir, ancak bir slaytı başka bir boyuta sahip bir sunuma klonlamak, içeriği yeni kanvas için otomatik olarak yeniden tasarlamaz. Şekiller bu yüzden kaymış, beklenmedik şekilde ölçeklenmiş ya da görünür slayt alanının dışına çıkmış görünebilir.

Pratik bir yaklaşım, klonlamadan önce kaynak sunumu yeniden boyutmaktır. [SlideSize.setSize](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slidesize/#setSize-float-float-int-) metodu, slayt boyutlarını değiştirirken mevcut içeriği ölçeklendirebilir. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slidesizescaletype/) ise içeriği istenen boyuta sığdırmak için ölçeklendirir.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    Dimension2D sourceSize = source.getSlideSize().getSize();
    Dimension2D destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            (float) destinationSize.getWidth(), 
            (float) destinationSize.getHeight(), 
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

Yeniden boyutlandırma, kaynak sunum nesnesini bellek içinde değiştirir. Orijinal kaynak sunumun diğer işlemler için değişmeden kalması gerekiyorsa, birleştirme sırasında ayrı bir örnek açın.

## **Slaytları Bir Sunum Bölümüne Birleştir**

Temel slayt-klonlama döngüsü, kaynak sunumun bölüm hiyerarşisini yeniden oluşturmaz. Çıktıda bölümler önemliyse, hedef sunumda bölümler oluşturup slaytları açıkça [addClone(ISlide, ISection)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) ile klonlayın.

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

Klonlanan slaytlar belirtilen hedef bölüme eklenir. Birden çok kaynak bölümünü korumak için [Presentation.getSections](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getSections--) döngüsüyle bölümleri enumerate edin, her kaynak bölümün mevcut slaytlarını [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isection/#getSlidesListOfSection--) ile alın, hedefte bölümleri yeniden oluşturun ve her dönen slaytı ilgili hedef bölümüne klonlayın. Boş bölümler ve yapısal değişiklikleri içeren tam bir örnek için [Slide Bölümlerini Yönet](/slides/tr/java/slide-section/) sayfasına bakın.

## **Birden Çok Sunumu Güvenli Bir Şekilde Birleştir**

Aşağıdaki uçtan uca örnek, ilk sunumu hedef olarak kullanır, her ek kaynak için slayt boyutunu normalleştirir, her kaynağı yalnızca kopyalanırken açık tutar ve sonunda dosyayı bir kez kaydeder.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    Dimension2D mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            Dimension2D sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    (float) mergedSize.getWidth(), 
                    (float) mergedSize.getHeight(), 
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

Bu, içe aktarılan slaytların kaynak biçimlendirmesini korumak için kullanışlı bir temel oluşturur. Çıktınız tek bir hedef teması kullanmalıysa, basit `addClone(slide)` çağrısını önceki örneklerde gösterilen uygun hedef‑master veya hedef‑layout aşırı yüklemesiyle değiştirin.

## **Pratik Hususlar**

### **Masterlar, Layoutlar ve Biçimlendirme Doğruluğu**

Varsayılan slayt klonlama, gereken kaynak masterı otomatik olarak hedef sunuma getirebilir. Aspose.Slides, aynı masterın tekrarlı klonlanmasını önlemek için otomatik klonlanan masterları içsel bir kayıt defterinde tutar. Manuel olarak klonlanan masterlar bu kayıt defterine eklenmez; bu yüzden masterları önceden klonlarken, yapı üzerinde açık kontrol ihtiyacınız yoksa kaçının.

Aynı ada sahip iki master veya layoutun görsel olarak eşdeğer olduğunu varsaymayın. Kurumsal bir şablon nihai görünümü kontrol etmeli ise, hedef masterı veya layoutu açıkça seçin ve birleştirme sonrası sonucu doğrulayın.

### **Notlar ve Yorumlar**

Konuşmacı notları ve slayt yorumları, slayt içeriğiyle ilişkilidir ve bir slayt klonlandığında kopyalanır. Aspose.Slides ayrıca [sunum notları](/slides/tr/java/presentation-notes/) ve [sunum yorumları](/slides/tr/java/presentation-comments/) için özel API’ler sunar.

Not sayfası biçimlendirmesi önemliyse, birleştirilmiş sunumu kontrol edin; çünkü not masterları sunum‑seviyesinde nesnelerdir ve kaynak dosyalar arasında farklılık gösterebilir. İnceleme iş akışları için, farklı yazar ya da şablonlardan gelen dosyaları birleştirdikten sonra yorum yazarlarını ve iş parçacıklı yorumları da doğrulayın.

### **Görseller, Ses, Video, OLE Nesneleri ve Dış Bağlantılar**

Slaytlar, sunum‑seviyesinde görseller, gömülü ses, gömülü video ve OLE verileri gibi kaynaklara referans verebilir. Sadece görünür şekilleri kopyalamak yerine slaytı tamamen klonlayın; böylece Aspose.Slides slaydın kaynaklarla ilişkisini korur.

Gömülü ve bağlantılı kaynaklar farklı şekilde işlenmelidir. Bağlantılı bir ses, video, OLE nesnesi ya da hiperlink, dış hedefine bağımlı kalır; slaytı klonlamak bir dış bağlantıyı gömülü içeriğe dönüştürmez. Bağlantılı kaynak yollarını ve URL’leri, birleştirilen sunumun açılacağı ortamda test edin.

Aspose.Slides otomatik klonlanan masterları izler, ancak bu, farklı kaynak sunumlardan gelen aynı ikili kaynakların her zaman ayıklanacağı anlamına gelmez. Çıktı dosya boyutu önemliyse, birleştirilmiş paketi inceleyin ve sonucu ölçün; örtülü deduplikasyona güvenmeyin.

### **Gömülü Fontlar ve Font Kullanılabilirliği**

Fontlar sunum‑seviyesinde yönetilir. Tipografi farklı makinelerde tutarlı kalmalıysa, yalnızca slayt klonlamanın gerekli tüm fontların hedef ortamda mevcut olduğunu garantilemediğini varsayın. Gömülü fontları [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) ile inceleyebilir ve [Sunumlarda Fontları Gömme](/slides/tr/java/embedded-font/) bölümünde açıklanan şekilde açıkça yönetebilirsiniz.

Ayrıca, kaynak dosyalarda kullanılan fontları gömmek için lisans izninizin olup olmadığını doğrulayın. Font lisansları gömme işlemine kısıtlama getirebilir.

### **Parola Korumalı Sunumlar**

Parola korumalı bir kaynağı, slaytları klonlamadan önce başarıyla açmanız gerekir. Parolayı [LoadOptions.setPassword](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) ile sağlayın.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // Şifresi çözülmüş sunumla çalış.
} finally {
    source.dispose();
}
```

Şifreli bir kaynağı açmak, aynı korumanın hedef sunuma otomatik olarak uygulanacağı anlamına gelmez. Gerektiğinde çıktı korumasını ayrı olarak yapılandırın.

### **Büyük Sunumlar ve Bellek Kullanımı**

Yüksek çözünürlüklü görseller, ses, video veya diğer büyük ikili nesneler içeren büyük sunumlar önemli miktarda bellek tüketebilir. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) BLOB yönetimi ve geçici dosya kullanımını kontrol eder. Büyük‑dosya stratejileri için [Sunum BLOB’larını Yönet](/slides/tr/java/manage-blob/) sayfasına bakın.

Büyük dosyalar için mümkün olduğunca dosya yollarından yükleme tercih edin, her kaynak sunumu birleştirildikten hemen sonra serbest bırakın ve iş akışı kontrol noktaları gerektirmiyorsa ara sonuçları tekrarlamalı olarak kaydetmekten kaçının.

### **İş Parçacığı Güvenliği**

Aynı [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) örneğini birden çok iş parçacığından aynı anda yüklemeyin, değiştirmeyin, kaydetmeyin veya klonlamayın. Her bir sunum örneğini tek bir birleştirme işlemiyle sınırlı tutun. Bağımsız işleri paralelleştiriyorsanız, bağımsız sunum örnekleri kullanın ve [Aspose.Slides çok iş parçacıklı kullanım rehberi](/slides/tr/java/multithreading/)ni izleyin.

## **SSS**

**Her bir kaynak sunumun orijinal tasarımını nasıl korurum?**

Bir hedef master veya layout sağlamadan [addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) kullanın. Aspose.Slides, gerektiğinde kaynak masterı otomatik olarak klonlayabilir.

**İçe aktarılan slaytların hedef temayı kullanmasını nasıl sağlarım?**

Hedef masterı kabul eden aşırı yüklemeyi kullanın. Masterı kaynak sunumdan değil, hedef sunumdan alın. Aspose.Slides, her kaynak slaytı o masterın uygun bir layoutuna eşlemeye çalışır.

**Ne zaman belirli bir hedef layout kullanmalı, master yerine?**

Her içe aktarılan slaydın aynı bilinen layoutu kullanması gerektiğinde belirli bir layout kullanın. Master, kaynak layout tipine veya adına göre o masterın layoutları arasından seçim yapmasını istediğinizde tercih edilir.

**Farklı slayt boyutlarına sahip sunumlar birleştirilebilir mi?**

Evet, ancak slayt içeriği hedef boyutlara otomatik olarak yeniden tasarlanmamaktadır. Öngörülebilir yerleşim için önce [SlideSize.setSize](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slidesize/#setSize-float-float-int-) ve [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slidesizescaletype/) ile kaynak sunumu yeniden boyutlandırın.

**PPT, PPTX ve ODP sunumlarını tek bir dosyada birleştirebilir miyim?**

Evet. Her kaynak sunumu yükleyin, gerekli slaytları tek bir hedefe klonlayın ve hedefi desteklenen bir çıktı formatında kaydedin. Sunum formatları aynı özellik setini tam olarak desteklemediğinden, çapraz‑format birleştirmelerden sonra karmaşık içeriği doğrulayın. [Desteklenen Dosya Biçimleri](/slides/tr/java/supported-file-formats/) sayfasına bakın.

**Kaynak bölümler otomatik olarak korunur mu?**

Sadece slaytları klonlayan temel bir döngü bölümleri korumaz. Bölüm yapısını korumanız gerekiyorsa, hedefte gerekli bölümleri yeniden oluşturun ve [addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISSlide-com.aspose.slides.ISection-) section aşırı yüklemesini kullanın.

**Konuşmacı notları ve yorumlar korunur mu?**

Klonlanan slaytla birlikte kopyalanırlar. Not‑master stili, yorum yazarları veya iş parçacıklı inceleme verileri gibi sunum‑seviyesi yapılar da dahil olmak üzere, birleştirilmiş sonucun doğrulanması gerekir.

**Ses, video, OLE nesneleri ve hiperlinkler ne olur?**

Gömülü içerikler, klonlanan slaydın kaynak ilişkileriyle birlikte taşınır. Dış bağlantılar dışarıda kalır; bu yüzden hedef ortamda hâlâ erişilebilir olmaları gerekir.

**Her kaynaktan gelen gömülü fontlar birleştirilmiş sunumda mevcut olur mu?**

Sadece slayt klonlamaya güvenmeyin; hedefte gömülü fontları inceleyin ve tipografi önemliyse font gömme veya harici font kullanılabilirliğini açıkça yönetin.

**Parola korumalı bir dosyayı nasıl birleştiririm?**

Doğru [LoadOptions.setPassword](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) ile açın, ardından slaytlarını normal şekilde klonlayın. Çıktı koruması ayrı olarak yapılandırılır.

**Çok büyük sunumları nasıl yönetirim?**

BLOB yönetimini kullanın, çok büyük dosyalar için dosya‑yolu yüklemeyi tercih edin, kaynak sunumları hızla serbest bırakın ve final dosyasını yalnızca gerektiğinde kaydedin.

**Slaytları çoklu iş parçacığından birleştirebilir miyim?**

Aynı [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) örneğini birden fazla iş parçacığından aynı anda kullanmayın. Her bir birleştirme işlemini kendi sunum örnekleriyle izole tutun.