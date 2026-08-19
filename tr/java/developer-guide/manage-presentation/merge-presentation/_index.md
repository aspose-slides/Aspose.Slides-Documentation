---
title: Java'da Sunumları Verimli Bir Şekilde Birleştirme
linktitle: Sunumları Birleştir
type: docs
weight: 40
url: /tr/java/merge-presentation/
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
- Java
- Aspose.Slides
description: "Java'da slaytları klonlayarak, ana ve düzenleri kontrol ederek, slayt içeriğini yeniden boyutlandırarak, bölümleri koruyarak ve korumalı veya büyük dosyalarla başa çıkarak PowerPoint ve OpenDocument sunumlarını nasıl birleştireceğinizi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Java, slaytları bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/)‘den diğerine klonlayarak sunumları birleştirir. Ana işlem, [ISlideCollection.addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), kaynak slaydın biçimlendirmesini koruyabilir veya klonlanan slaytı hedef sunumdaki bir ana (master) veya düzen (layout) ile ilişkilendirebilir.

Bu makale en yaygın birleştirme iş akışlarını kapsar:
- tüm slaytları kaynak biçimlendirmelerini koruyarak birleştir;
- seçili slaytları birleştir;
- hedef sunumdan bir ana (master) uygula;
- hedef sunumdan belirli bir düzen (layout) uygula;
- birleştirmeden önce farklı slayt boyutlarını normalleştir;
- klonlanan slaytları bir bölüme ekle;
- birden fazla sunumu uçtan uca bir iş akışında birleştir;
- ana (master), kaynaklar, notlar, yorumlar, medya, yazı tipleri, parolalar, büyük dosyalar ve çoklu iş parçacığı konularını ele al.

## **Slayt Klonlamasının Ana ve Düzenlere Etkisi**

Bir slayt, görünümünün büyük bölümünü düzeninden ve ana (master)ından miras alır. Bu nedenle, seçtiğiniz klonlama aşırı yüklemesi, birleştirilen slaydın hedef sunuma nasıl entegre edileceğini belirler.

[ISlideCollection.addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidecollection/) metodunu şu şekillerde kullanabilirsiniz:
- `addClone(sourceSlide)` — kaynak slaydın düzenini ve biçimlendirmesini korur. Gerektiğinde, kaynak ana otomatik olarak hedef sunuma klonlanabilir. Aspose.Slides, otomatik klonlanan anaları izler, böylece aynı kaynak ana kullanan tekrar eden slaytlar bu anaı birden çok kez klonlamaz.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — klonlanan slaytı belirli bir hedef [IMasterSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterslide/) üzerine ekler. Aspose.Slides, o ana altında düzen türüne veya adına göre eşleşen bir düzen arar.
- `addClone(sourceSlide, destinationLayout)` — klonlanan slaytı doğrudan belirli bir hedef [ILayoutSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutslide/) üzerine ekler.

`addClone` aşırı yüklemesine geçirilen ana veya düzen, **hedef** sunuma ait olmalıdır, kaynak sunuma ait olmamalıdır.

## **Tüm Sunumları Birleştir ve Kaynak Biçimlendirmesini Koru**

En basit birleştirme, kaynak sunumdaki tüm slaytları hedef sunuma kopyalar. Bu, içe aktarılan slaytların orijinal tema, ana ve düzen ilişkilerini koruması gerektiğinde uygun bir tercihtir.

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

Kaynak ve hedef farklı tasarımlar kullandığında, oluşan sunum birden fazla ana içerebilir. Kaynak biçimlendirmesi bilinçli olarak korunduğunda bu beklenen bir durumdur.

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

Kullanıcı girişi veya dış yapılandırmadan gelen slayt indekslerini klonlamadan önce doğrulayın.

## **Hedef Ana Kullanarak Slaytları Birleştir**

İçe aktarılan slaytların zaten hedef sunuma ait bir ana (master)ı takip etmesi gerektiğinde, [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISSlide-com.aspose.slides.IMasterSlide-boolean-) aşırı yüklemesini kullanın.

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

Aspose.Slides, belirtilen ana altında kaynak düzenin türü veya adına göre uygun bir düzen seçer. Uygun bir düzen yoksa ve `allowCloneMissingLayout` `true` ise, slayt eklenebilmesi için kaynak düzen klonlanır. `false` ise bir [PptxEditException](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pptxeditexception/) fırlatılır.

Ek bir düzenin hedef ana içine eklenmesini istemiyor ve birleştirmenin başarısız olmasını tercih ediyorsanız `false` kullanın.

## **Belirli Bir Hedef Düzeni Kullanarak Slaytları Birleştir**

[addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISSlide-com.aspose.slides.ILayoutSlide-) aşırı yüklemesini, içe aktarılan slaytların hangi hedef düzeni kullanacağını kesin olarak bildiğinizde kullanın.

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

Hedef düzenin uygulanması, kalıtılan düzen ilişkisinde değişiklik yapar; kaynak slayt içeriğini yeniden tasarlamaz. Kaynak ve hedef düzenlerin yer tutucu yapıları farklıysa, kalıtılan biçimlendirme ve yer tutucu davranışının uygun olduğunu doğrulamak için sonucu inceleyin.

## **Farklı Slayt Boyutlarına Sahip Sunumları Birleştir**

Farklı slayt boyutlarına sahip sunumlar birleştirilebilir, ancak bir slaytı farklı bir slayt boyutuna sahip bir sunuma klonlamak, içeriği yeni kanvas için otomatik olarak yeniden tasarlamaz. Bu nedenle şekiller kaymış, beklenmedik şekilde ölçeklenmiş veya görünür slayt alanının dışına çıkmış görünebilir.

Pratik bir yaklaşım, klonlamadan önce kaynak sunumun boyutunu yeniden ayarlamaktır. [SlideSize.setSize](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slidesize/#setSize-float-float-int-) yöntemi, slayt boyutlarını değiştirirken mevcut içeriği ölçeklendirebilir. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slidesizescaletype/) istenen boyuta sığdırmak için içeriği ölçeklendirir.

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

Boyutlandırma, kaynak sunum nesnesini bellek içinde değiştirir. Başka işlemler için orijinal kaynak sunumun değiştirilmemiş olmasını istiyorsanız, birleştirme için ayrı bir örnek açın.

## **Slaytları Sunum Bölümüne Birleştir**

Temel slayt klonlama döngüsü, kaynak sunumun bölüm hiyerarşisini yeniden oluşturmaz. Çıktıda bölümler önemliyse, hedef sunumda bölümler oluşturun veya seçin ve slaytları açıkça [addClone(ISlide, ISection)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISSlide-com.aspose.slides.ISection-) ile o bölümlere klonlayın.

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

Klonlanan slaytlar belirtilen hedef bölüme eklenir. Birden fazla kaynak bölümü korumak için, bu bölümleri hedefte yeniden oluşturun ve her kaynak slaytı karşılık gelen hedef bölüme eşleyin.

## **Birden Fazla Sunumu Güvenli Bir Şekilde Birleştir**

Aşağıdaki uçtan uca örnek, ilk sunumu hedef olarak kullanır, her ek kaynağın slayt boyutunu normalleştirir, her kaynağı sadece kopyalanırken açık tutar ve nihai dosyayı bir kez kaydeder.

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

Bu, içe aktarılan slaytların kaynak biçimlendirmesini korumak için yararlı bir temel oluşturur. Çıktınızın tek bir hedef tema kullanması gerekiyorsa, basit `addClone(slide)` çağrısını daha önce gösterilen uygun hedef-anamaster ya da hedef-düzen aşırı yüklemesiyle değiştirin.

## **Pratik Hususlar**

### **Ana, Düzen ve Biçimlendirme Doğruluğu**

Varsayılan slayt klonlaması, gerekli kaynak anayı otomatik olarak hedef sunuma getirebilir. Aspose.Slides, aynı ananın tekrar tekrar klonlanmasını önlemek için otomatik klonlanan anaları içeren bir iç kayıt tutar. Manuel olarak klonlanan analar bu kayıt tarafından izlenmez, bu yüzden ananın yapısına açıkça müdahale etmeniz gerekmedikçe önceden klonlamaktan kaçının.

Aynı ada sahip iki ana veya düzenin görsel olarak eşdeğer olduğunu varsımayın. Kurumsal bir şablonun nihai görünümü kontrol etmesi gerekiyorsa, hedef anayı veya düzeni açıkça seçin ve birleştirme sonrası sonucu doğrulayın.

### **Notlar ve Yorumlar**

Konuşmacı notları ve slayt yorumları slayt içeriğiyle ilişkilidir ve bir slayt klonlandığında kopyalanır. Aspose.Slides ayrıca [presentation notes](https://docs.aspose.com/slides/tr/java/presentation-notes/) ve [presentation comments](https://docs.aspose.com/slides/tr/java/presentation-comments/) için özel API'ler sunar.

Not sayfası biçimlendirmesi önemliyse, not anaları sunum seviyesinde nesneler olduğu ve kaynak dosyalar arasında farklı olabileceği için birleştirilmiş sunumu doğrulayın. İnceleme iş akışları için, farklı yazarlar veya şablonlardan gelen dosyaları birleştirdikten sonra yorum yazarlarını ve zincirleme yorumları da doğrulayın.

### **Görseller, Ses, Video, OLE Nesneleri ve Harici Bağlantılar**

Slaytlar, görseller, gömülü ses, gömülü video ve OLE verileri gibi sunum seviyesindeki kaynaklara başvurabilir. Aspose.Slides, slaydın kaynaklarla ilişkisini koruyabilmesi için yalnızca görünen şekilleri kopyalamak yerine slaytı kendisini klonlayın.

Gömülü ve bağlantılı kaynaklar farklı şekilde ele alınmalıdır. Bağlantılı bir ses, video, OLE nesnesi veya köprü, dış hedefine bağımlı kalır; slaytı klonlamak dış bağlantıyı gömülü içeriğe dönüştürmez. Bağlantılı kaynak yollarını ve URL'leri birleştirilmiş sunumun açılacağı ortamda test edin.

Aspose.Slides, otomatik olarak klonlanan anaları açıkça izlese de, bu, ilişkili olmayan kaynak sunumlardan gelen aynı ikili kaynakların her zaman tekilleştirileceği garantisi olarak görülmemelidir. Çıktı dosya boyutu önemliyse, örtülü tekilleştirmeye güvenmek yerine birleştirilmiş paketi inceleyin ve sonucu ölçün.

### **Gömülü Yazı Tipleri ve Yazı Tipi Kullanılabilirliği**

Yazı tipleri sunum seviyesinde yönetilir. Tipografinin makineler arasında tutarlı kalması gerekiyorsa, yalnızca slaytları klonlamanın gereken her yazı tipinin hedef ortamda mevcut olacağını varsımayın. Gömülü yazı tiplerini [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) ile inceleyebilir ve [Embed Fonts in Presentations](https://docs.aspose.com/slides/tr/java/embedded-font/) bölümünde açıklandığı gibi gömme işlemini açıkça yönetebilirsiniz.

Ayrıca, kaynak dosyalarda kullanılan yazı tiplerini gömmeye izin verilip verilmediğini doğrulayın. Yazı tipi lisansları gömme işlemini kısıtlayabilir.

### **Parola Korumalı Sunumlar**

Parola korumalı bir kaynağın slaytları klonlanmadan önce başarılı bir şekilde açılması gerekir. Parolayı [LoadOptions.setPassword](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) aracılığıyla sağlayın.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // Şifre çözülmüş sunumla çalışın.
} finally {
    source.dispose();
}
```

Şifreli bir kaynağın açılması, aynı korumanın hedef sunuma otomatik olarak uygulanması anlamına gelmez. Gerektiğinde çıktı korumasını ayrı olarak yapılandırın.

### **Büyük Sunumlar ve Bellek Kullanımı**

Yüksek çözünürlüklü görseller, ses, video veya diğer büyük ikili nesneler içeren büyük sunumlar önemli miktarda bellek tüketebilir. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) BLOB yönetimi ve geçici dosya kullanımını kontrol eder. Büyük dosya stratejileri için [Manage Presentation BLOBs](https://docs.aspose.com/slides/tr/java/manage-blob/) sayfasına bakın.

Büyük dosyalar için mümkün olduğunca dosya yollarından yüklemeyi tercih edin, her kaynak sunumu birleştirildikten hemen sonra serbest bırakın ve iş akışı ara noktalar gerektirmediği sürece ara sonuçları tekrar tekrar kaydetmekten kaçının.

### **İş Parçacığı Güvenliği**

Aynı [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) örneğini birden çok iş parçacığından aynı anda yüklemeyin, değiştirmeyin, kaydetmeyin veya klonlamayın. Her sunum örneğini tek bir birleştirme işlemiyle sınırlı tutun. Bağımsız işleri paralelleştiriyorsanız, bağımsız sunum örnekleri kullanın ve [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/tr/java/multithreading/) yönergelerini izleyin.

## **SSS**

**Kaynak sunumların orijinal tasarımını nasıl korurum?**

`addClone(sourceSlide)` metodunu hedef ana veya düzen belirtmeden kullanın. Aspose.Slides, içe aktarılan slaytın ihtiyacı olduğunda kaynak anayı otomatik olarak klonlayabilir.

**İçe aktarılan slaytları hedef temayı kullanacak şekilde nasıl ayarlarım?**

Hedef ana kabul eden aşırı yüklemeyi kullanın. Ana, kaynak sunumdan değil hedef sunumdan alınmalıdır. Aspose.Slides, her kaynak slaytı o ana altında uygun bir düzene eşlemeye çalışır.

**Ne zaman belirli bir hedef düzeni, hedef ana yerine kullanmalıyım?**

Her içe aktarılan slaytın bilinen bir düzeni kullanması gerektiğinde belirli bir düzen kullanın. Kaynak düzenin türüne veya adına göre Aspose.Slides'in o ana altındaki düzenler arasından seçim yapmasını istediğinizde ana kullanın.

**Farklı slayt boyutlarına sahip sunumlar birleştirilebilir mi?**

Evet, ancak slayt içeriği hedef boyutlara otomatik olarak yeniden tasarlanmaz. Öngörülebilir konumlandırma gerektiğinde, örneğin [SlideSize.setSize](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slidesize/#setSize-float-float-int-) ve [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slidesizescaletype/) kullanarak önce kaynak sunumun boyutunu yeniden ayarlayın.

**PPT, PPTX ve ODP sunumlarını tek bir dosyada birleştirebilir miyim?**

Evet. Her kaynak sunumu yükleyin, gerekli slaytları tek bir hedefe klonlayın ve hedefi desteklenen bir çıktı formatında kaydedin. Sunum formatları aynı özellik setini tam olarak desteklemediği için, çapraz format birleştirmelerinden sonra karmaşık içeriği doğrulayın. [Supported File Formats](https://docs.aspose.com/slides/tr/java/supported-file-formats/) sayfasına bakın.

**Kaynak bölümler otomatik olarak korunur mu?**

Sadece slaytları klonlayan temel bir döngüyle otomatik korunmaz. Gerekli bölümleri hedefte yeniden oluşturun ve [addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISSlide-com.aspose.slides.ISection-) bölüm aşırı yüklemesini kullanın.

**Konuşmacı notları ve yorumlar korunur mu?**

Klonlanan slaytla birlikte kopyalanırlar. Not‑ana stiline, yorum yazarlarına veya zincirleme inceleme verilerine bağlı iş akışları için, bu senaryolar sunum‑seviyesi yapıların yanı sıra slayt‑seviyesi içeriği de içerdiğinden birleştirilmiş sonucu doğrulayın.

**Ses, video, OLE nesneleri ve köprüler ne olur?**

Gömülü içerik, klonlanan slaydın kaynak ilişkilerinin bir parçası olarak taşınır. Dış bağlantılar dışta kalır; bu yüzden birleştirmeden sonra hedef dosyaları veya URL'leri hâlâ kullanılabilir olmalıdır.

**Her kaynaktan gelen gömülü yazı tiplerinin birleştirilmiş sunumda bulunacağı garanti edilir mi?**

Sadece slayt klonlamasına güvenerek yazı tipi dağıtımını sağlamaya çalışmayın. Tipografi önemliyse, hedefteki gömülü yazı tiplerini inceleyin ve yazı tipi gömme ya da dış yazı tipi kullanılabilirliğini açıkça yönetin.

**Parola korumalı bir dosyayı nasıl birleştiririm?**

Doğru [LoadOptions.setPassword](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) ile açın, ardından slaytlarını normal şekilde klonlayın. Çıktı koruması ayrı olarak yapılandırılır.

**Çok büyük sunumları nasıl yönetmeliyim?**

Büyük ikili nesneler bellek kullanımını domine ediyorsa BLOB yönetimini kullanın, çok büyük dosyalar için dosya yolu üzerinden yüklemeyi tercih edin, kaynak sunumları hızlıca serbest bırakın ve nihai sonucu yalnızca gerektiğinde kaydedin.

**Birden fazla iş parçacığından slaytları birleştirebilir miyim?**

Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) örneğini birden çok iş parçacığından aynı anda kullanmayın. Her birleştirme işlemini kendi sunum örnekleriyle izole tutun.