---
title: Android'de Sunumları Verimli Bir Şekilde Birleştir
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
description: "Android'de slaytları kopyalayarak, master ve layout'ları kontrol ederek, slayt içeriğini yeniden boyutlandırarak, bölümleri koruyarak ve korumalı ya da büyük dosyalarla çalışarak PowerPoint ve OpenDocument sunumlarını nasıl birleştireceğinizi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Android via Java, bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) içindeki slaytları başka birine kopyalayarak sunumları birleştirir. Ana işlem, kaynak slaydın biçimlendirmesini koruyabilir veya kopyalanan slaytı hedef sunumdaki bir master veya layout’a ekleyebilir.

Bu makale en yaygın birleştirme iş akışlarını kapsar:

- tüm slaytları kaynak biçimlendirmesini koruyarak birleştirme;
- seçili slaytları birleştirme;
- hedef sunumdan bir master uygulama;
- hedef sunumdan belirli bir layout uygulama;
- birleştirmeden önce farklı slayt boyutlarını normalleştirme;
- kopyalanan slaytları bir bölüme ekleme;
- birden fazla sunumu uçtan uca bir iş akışında birleştirme;
- master’lar, kaynaklar, notlar, yorumlar, medya, yazı tipleri, şifreler, büyük dosyalar ve çok iş parçacıklı senaryoları yönetme.

## **Slayt Kopyalamanın Master ve Layout’ları Nasıl Etkilediği**

Bir slayt, görünümünün büyük bir kısmını layout ve master’ından devralır. Bu yüzden seçtiğiniz kopyalama aşırı yüklemesi, birleştirilmiş slaydın hedef sunuma nasıl entegre edileceğini belirler.

[ISlideCollection.addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidecollection/) yöntemini şu şekillerde kullanın:

- `addClone(sourceSlide)` — kaynak slaydın layout ve biçimlendirmesini korur. Gerekirse kaynak master, hedef sunuma otomatik olarak kopyalanabilir. Aspose.Slides, aynı kaynak master’ı kullanan tekrarlanan slaytların master’ını tekrar kopyalamamasını sağlamak için otomatik kopyalanan master’ları izler.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — kopyalanan slaytı belirli bir hedef [IMasterSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterslide/)’a bağlar. Aspose.Slides, bu master altında layout tipine veya adına göre eşleşen bir layout arar.
- `addClone(sourceSlide, destinationLayout)` — kopyalanan slaytı doğrudan belirli bir hedef [ILayoutSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutslide/)’a bağlar.

`addClone` aşırı yüklemesine geçirilen master veya layout, **hedef** sunuma ait olmalı, kaynak sunuma ait olmamalıdır.

## **Tüm Sunumları Birleştir ve Kaynak Biçimlendirmesini Koruyun**

En basit birleştirme, kaynak sunumdaki tüm slaytları hedef sunuma kopyalar. Bu, içe aktarılan slaytların özgün tema, master ve layout ilişkilerini koruması gerektiğinde uygundur.

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

Kaynak ve hedef farklı tasarımlar kullandığında sonuç sunum birden çok master içerebilir. Bu, kaynak biçimlendirmesinin kasıtlı olarak korunması durumunda beklenen bir durumdur.

## **Seçili Slaytları Birleştir**

Tüm slaytları kopyalamanız gerekmez. Aşağıdaki örnek, kaynak sunumdan yalnızca seçili slayt indekslerini içe aktarır.

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

Kullanıcı girdisinden veya harici yapılandırmadan gelen indeksleri kopyalamadan önce doğrulayın.

## **Hedef Master Kullanarak Slaytları Birleştir**

İçe aktarılan slaytların zaten hedef sunuma ait bir master’ı takip etmesi gerektiğinde, [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) aşırı yüklemesini kullanın.

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

Aspose.Slides, kaynak layout’un tipine veya adına göre belirtilen master altında uygun bir layout seçer. Uygun bir layout bulunmazsa ve `allowCloneMissingLayout` `true` ise, kaynak layout kopyalanarak slayt eklenebilir. `false` ise bir [PptxEditException](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pptxeditexception/) fırlatılır.

Ek bir layout eklenmesini istemiyorsanız, birleştirmenin başarısız olmasını sağlamak için `false` kullanın.

## **Belirli Bir Hedef Layout Kullanarak Slaytları Birleştir**

İçe aktarılan slaytların tam olarak hangi hedef layout’u kullanması gerektiğini biliyorsanız, [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) aşırı yüklemesini kullanın.

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

Hedef layout’u uygulamak, devralınan layout ilişkisini değiştirir; kaynak slayt içeriğini yeniden tasarlamaz. Kaynak ve hedef layout’ların yer tutucu yapıları farklıysa, devralınan biçimlendirme ve yer tutucu davranışının uygun olduğunu doğrulamak için sonucu inceleyin.

## **Farklı Slayt Boyutlarına Sahip Sunumları Birleştir**

Farklı slayt boyutlarına sahip sunumlar birleştirilebilir, ancak bir slaytı farklı bir boyuttaki sunuma kopyalamak, içeriği yeni tuval için otomatik olarak yeniden tasarlamaz. Bu yüzden şekiller kaymış, beklenmedik şekilde ölçeklenmiş veya görünür slayt alanının dışına çıkmış görünebilir.

Pratik bir yaklaşım, kopyalamadan önce kaynak sunumu yeniden boyutlandırmaktır. [SlideSize.setSize](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) yöntemi, slayt boyutlarını değiştirirken mevcut içeriği ölçekleyebilir. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slidesizescaletype/) içeriği istenen boyuta sığdırmak için ölçekler.

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

Yeniden boyutlandırma, kaynak sunum nesnesini bellek içinde değiştirir. Orijinal kaynak sunumun diğer işlemler için değiştirilmemiş kalması gerekiyorsa, birleştirme için ayrı bir örnek açın.

## **Slaytları Bir Sunum Bölümüne Birleştir**

Temel slayt‑kopyalama döngüsü, kaynak sunumun bölüm hiyerarşisini yeniden oluşturmaz. Çıktıda bölümler önemliyse, hedef sunumda bölümler oluşturun veya seçin ve slaytları açıkça [addClone(ISlide, ISection)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) ile bölümlere kopyalayın.

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

Kopyalanan slaytlar belirtilen hedef bölüme eklenir. Birden fazla kaynak bölümü korumak için, [Presentation.getSections](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getSections--) metodunu yineleyin, her kaynak bölümün slaytlarını [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) ile alın, bölümleri hedefte yeniden oluşturun ve her döndürülen slaytı ilgili hedef bölümüne kopyalayın. Boş bölümler ve yapısal değişiklikler dahil tam bir bölüm‑yineleme örneği için [Manage Slide Sections](/slides/tr/androidjava/slide-section/) sayfasına bakın.

## **Birden Çok Sunumu Güvenli Bir Şekilde Birleştir**

Aşağıdaki uçtan‑uç örnek, ilk sunumu hedef olarak kullanır, ek her bir kaynağın slayt boyutunu normalleştirir, her kaynağı sadece kopyalanırken açık tutar ve sonunda tek bir dosya olarak kaydeder.

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

Bu, içe aktarılan slaytların kaynak biçimlendirmesini korumak için yararlı bir temeldir. Çıktınız tek bir hedef teması kullanmalıysa, basit `addClone(slide)` çağrısını önceki örneklerde gösterilen uygun hedef‑master veya hedef‑layout aşırı yüklemesiyle değiştirin.

## **Pratik Hususlar**

### **Master’lar, Layout’lar ve Biçimlendirme Sadakati**

Varsayılan slayt kopyalama, gereken kaynak master’ı otomatik olarak hedef sunuma getirebilir. Aspose.Slides, aynı master’ın tekrarlı kopyalanmasını önlemek için otomatik kopyalanan master’ları içsel bir kayıt defterinde tutar. Manuel olarak kopyalanan master’lar bu kayıt defterinde izlenmez; bu yüzden master yapısı üzerinde kesin kontrol ihtiyacınız yoksa ön‑kopyalamaktan kaçının.

Aynı ada sahip iki master veya layout’un görsel olarak eşdeğer olduğunu varsamayın. Kurumsal bir şablon nihai görünüme hâkim olacaksa, hedef master veya layout’u açıkça seçin ve birleştirme sonrası sonucu doğrulayın.

### **Notlar ve Yorumlar**

Sunucu notları ve slayt yorumları slayt içeriğiyle ilişkilidir ve bir slayt kopyalandığında kopyalanır. Aspose.Slides ayrıca [presentation notes](/slides/tr/androidjava/presentation-notes/) ve [presentation comments](/slides/tr/androidjava/presentation-comments/) için özel API’ler sunar.

Not‑sayfası biçimlendirmesi önemliyse, birleştirilmiş sunumu doğrulayın; çünkü not master’ları sunum‑seviyesinde nesnelerdir ve kaynak dosyalar arasında farklılık gösterebilir. İnceleme süreçlerinde, farklı yazarların veya şablonların dosyalarından birleştirilen dosyalar sonrasında yorum yazarlarını ve zincirleme yorumları da kontrol edin.

### **Görseller, Ses, Video, OLE Nesneleri ve Dış Bağlantılar**

Slaytlar, sunum‑seviyesinde görseller, gömülü ses, gömülü video ve OLE verileri gibi kaynaklara referans verebilir. Sadece görünen şekilleri kopyalamak yerine slaytı tamamen kopyalayın; böylece Aspose.Slides, slaydın kaynaklarıyla olan ilişkisini korur.

Gömülü ve bağlanmış kaynaklar farklı şekilde ele alınmalıdır. Bağlantılı bir ses, video, OLE nesnesi veya köprü, dış hedefine bağımlı kalır; bir slaytı kopyalamak dış bağlantıyı gömülü içeriğe dönüştürmez. Bağlantılı kaynak yollarını ve URL’leri, birleştirilen sunumun açılacağı ortamda test edin.

Aspose.Slides otomatik kopyalanan master’ları izler, ancak bu, birbirinden bağımsız kaynak sunumlardan gelen aynı ikili kaynakların her zaman tekilleştirileceği anlamına gelmez. Çıktı dosya boyutu önemliyse, birleştirilmiş paketi inceleyin ve sonucu ölçün; örtülü tekilleştirmeye güvenmeyin.

### **Gömülü Yazı Tipleri ve Yazı Tipi Erişilebilirliği**

Yazı tipleri sunum‑seviyesinde yönetilir. Tipografi farklı makinelerde tutarlı kalmalıysa, yalnızca slaytları kopyalamanın, gerekli tüm yazı tiplerinin hedef ortamda bulunacağını garanti etmediğini varsamayın. Gömülü yazı tiplerini [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) ile inceleyebilir ve [Embed Fonts in Presentations](/slides/tr/androidjava/embedded-font/) bölümünde açıklandığı gibi açıkça yönetebilirsiniz.

Ayrıca, kaynak dosyalarda kullanılan yazı tiplerini gömmek için izinlerinizin olup olmadığını doğrulayın. Yazı tipi lisansları gömme işlemini kısıtlayabilir.

### **Şifre Korumalı Sunumlar**

Şifre korumalı bir kaynağı, slaytları kopyalamadan önce başarılı bir şekilde açmanız gerekir. Şifreyi [LoadOptions.setPassword](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) ile sağlayın.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // Şifre çözülmüş sunumla çalış.
} finally {
    source.dispose();
}
```

Şifreli bir kaynağı açmak, aynı korumanın otomatik olarak hedef sunuma uygulanacağı anlamına gelmez. Gerekli olduğunda çıkış korumasını ayrı olarak yapılandırın.

### **Büyük Sunumlar ve Bellek Kullanımı**

Yüksek çözünürlüklü görseller, ses, video veya diğer büyük ikili nesneler içeren büyük sunumlar önemli bellek tüketebilir. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) BLOB yönetimi ve geçici dosya kullanımını kontrol eder. Büyük‑dosya stratejileri için [Manage Presentation BLOBs](/slides/tr/androidjava/manage-blob/) sayfasına bakın.

Büyük dosyalar için mümkün olduğunca dosya yolu üzerinden yükleme tercih edin, her kaynak sunumu birleştirme tamamlandıktan hemen sonra serbest bırakın ve ara sonuçları sık sık kaydetmekten kaçının; yalnızca iş akışı kontrol noktaları gerektiriyorsa kaydedin.

### **İş Parçacığı Güvenliği**

Aynı [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) örneğini birden fazla iş parçacığından aynı anda yüklemeyin, değiştirmeyin, kaydetmeyin veya kopyalamayın. Her sunum örneğini bir birleştirme işlemiyle sınırlı tutun. Bağımsız işleri paralelleştiriyorsanız, bağımsız sunum örnekleri kullanın ve [Aspose.Slides çok iş parçacıklı kılavuzu](/slides/tr/androidjava/multithreading/) izleyin.

## **SSS**

**Her kaynak sunumun orijinal tasarımını nasıl korurum?**

Hedef master veya layout sağlamadan `[addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-)` kullanın. Aspose.Slides, içe aktarılan slayt için ihtiyaç duyulduğunda kaynak master’ı otomatik olarak kopyalayabilir.

**İçe aktarılan slaytların hedef temayı kullanmasını nasıl sağlarım?**

Hedef master kabul eden aşırı yüklemeyi kullanın. Master’ı kaynak değil, hedef sunumdan alın. Aspose.Slides, her kaynak slaytı o master’ın uygun layout’una eşleştirmeye çalışır.

**Ne zaman belirli bir hedef layout’u, bir hedef master’dan tercih etmeliyim?**

Her içe aktarılan slayt aynı bilinen layout’u kullanmalıysa belirli bir layout kullanın. Master kullanın when Aspose.Slides’in, kaynak layout tipine veya adına göre master’ın layout’ları arasından seçim yapmasını istiyorsanız.

**Farklı slayt boyutlarına sahip sunumlar birleştirilebilir mi?**

Evet, ancak slayt içeriği hedef boyutlara otomatik olarak yeniden tasarlanmamaktadır. Predictable placement (öngörülebilir konum) için önce kaynak sunumu yeniden boyutlandırın; örneğin `[SlideSize.setSize](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-)` ve `[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slidesizescaletype/)` kullanın.

**PPT, PPTX ve ODP sunumlarını tek bir dosyada birleştirebilir miyim?**

Evet. Her kaynak sunumu yükleyin, gerekli slaytları tek bir hedefe kopyalayın ve hedefi desteklenen bir çıktı formatında kaydedin. Sunum formatları aynı özellik setini tam olarak desteklemediğinden, çapraz‑format birleştirmelerden sonra karmaşık içeriği doğrulayın. [Supported File Formats](/slides/tr/androidjava/supported-file-formats/) sayfasına bakın.

**Kaynak bölümler otomatik olarak korunur mu?**

Yalnızca slaytları kopyalayan temel bir döngü bunu yapmaz. Bölüm yapısını korumanız gerekiyorsa, hedefte gerekli bölümleri yeniden oluşturun ve bölüm‑yapısı korunmalıysa `[addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-)` aşırı yüklemesini kullanın.

**Sunucu notları ve yorumlar korunur mu?**

Kopyalanan slaytla birlikte kopyalanırlar. Not‑master stili, yorum yazarları veya zincirleme inceleme verileri gibi sunum‑seviyesindeki yapılarla ilgilenen iş akışları için birleştirilmiş sonucu doğrulayın.

**Ses, video, OLE nesneleri ve köprüler ne olur?**

Gömülü içerik, kopyalanan slaydın kaynak ilişkileri kapsamında taşınır. Dış bağlantılar dış bağımlı kalır; bu yüzden hedef ortamda ilgili dosyaların veya URL’lerin erişilebilir olduğundan emin olun.

**Her kaynaktan gelen gömülü yazı tipleri birleştirilmiş sunumda garanti edilir mi?**

Sadece slayt kopyalamaya güvenmeyin; hedefteki gömülü yazı tiplerini inceleyin ve tipografi önemliyse yazı tiplerini açıkça yönetin.

**Şifre korumalı bir dosyayı nasıl birleştiririm?**

Doğru `[LoadOptions.setPassword](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-)` ile açın, ardından slaytlarını normal şekilde kopyalayın. Çıktı koruması ayrı olarak yapılandırılır.

**Çok büyük sunumları nasıl yönetmeliyim?**

BLOB yönetimini kullanın, çok büyük dosyalar için dosya‑yolu üzerinden yüklemeyi tercih edin, kaynak sunumları birleştirme tamamlandıktan hemen sonra serbest bırakın ve ara sonuçları yalnızca iş akışı kontrol noktaları gerektiğinde kaydedin.

**Slaytları birden çok iş parçacığından birleştirebilir miyim?**

Aynı `[Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/)` örneğini birden çok iş parçacığıyla aynı anda kullanmayın. Her birleştirme işlemi için ayrı sunum örnekleri tutun.