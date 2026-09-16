---
title: Java'da Sunumları XAML Olarak Dışa Aktarma
linktitle: Sunumu XAML'a
type: docs
weight: 30
url: /tr/java/export-to-xaml/
keywords:
- PowerPoint dışa aktar
- OpenDocument dışa aktar
- Sunumu dışa aktar
- PowerPoint dönüştür
- OpenDocument dönüştür
- Sunumu dönüştür
- PowerPoint'tan XAML'e
- OpenDocument'tan XAML'e
- Sunumdan XAML'e
- PPT'den XAML'e
- PPTX'den XAML'e
- ODP'den XAML'e
- PPT'yi XAML olarak kaydet
- PPTX'i XAML olarak kaydet
- ODP'yi XAML olarak kaydet
- PPT'yi XAML'e dışa aktar
- PPTX'i XAML'e dışa aktar
- ODP'yi XAML'e dışa aktar
- Java
- Aspose.Slides
description: "Aspose.Slides kullanarak Java'da PowerPoint ve OpenDocument slaytlarını XAML'e dönüştürün—düzeninizi koruyan hızlı, Office'siz bir çözüm."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarını XAML olarak dışa aktarmanın nasıl yapılacağını açıklar. Kısa bir XAML tanıtımı içerir, varsayılan ayarlarla bir sunumun XAML olarak nasıl kaydedileceğini gösterir ve gizli slaytların dışa aktarılması dahil olmak üzere [XamlOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/xamloptions/) aracılığıyla dışa aktarmanın nasıl özelleştirileceğini gösterir. Makale ayrıca yedek yazı tipleri, XAML yığını uyumluluğu ve gizli slayt dışa aktarım davranışıyla ilgili birkaç yaygın soruyu yanıtlar.

## **XAML Hakkında**

XAML, WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) ve Xamarin.Forms gibi çerçevelerde kullanıcı arayüzlerini tanımlamak için kullanılan XML tabanlı bir işaretleme dilidir.

XAML dosyalarıyla görsel tasarımcıda çalışabilir veya işaretlemeyi doğrudan yazıp düzenleyebilirsiniz.

## **Varsayılan Seçeneklerle Sunumları XAML Olarak Dışa Aktarma**

İşte aşağıdaki Java örneği, bir sunumu varsayılan ayarlarla XAML olarak dışa aktarmayı gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

Varsayılan olarak, dışa aktarılan slaytlar, boş bir yoldan [Paths.get](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Paths.html#get-java.lang.String-java.lang.String...-) ile çözümlenen süreçin geçerli çalışma dizininin içinde `pres` adlı bir alt klasöre kaydedilir. Klasör otomatik olarak oluşturulur ve gerekli olan tüm görseller de oraya kaydedilir.

Çıktı klasörü adı, kaynak dosya adından uzantısı olmadan alınır. `pres.pptx` için çıktı dosyaları `pres/Slide_1.xaml`, `pres/Slide_2.xaml` gibi adlandırılır. Girdi sunumuna mutlak bir yol geçseniz bile, çıktı klasörü geçerli çalışma dizinine göre oluşturulur, girdi dosyasının yanına değil.

## **Özel Seçeneklerle Sunumları XAML Olarak Dışa Aktarma**

[IXamlOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ixamloptions/) arabirimini kullanarak Aspose.Slides’ın bir sunumu XAML olarak nasıl dışa aktaracağını kontrol edebilirsiniz.

Çıktıyı özel bir konuma kaydetmek için [IXamlOutputSaver](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ixamloutputsaver/) arayüzünü uygulayın ve uygulamanızın bir örneğini [XamlOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/xamloptions/) sınıfının [setOutputSaver](https://reference.aspose.com/slides/tr/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) metoduna iletin.

XAML çıktısına gizli slaytları dahil etmek için, aşağıdaki Java örneğinde gösterildiği gibi `true` ile [setExportHiddenSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) metodunu çağırın:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **Oluşturulan Tüm XAML Sanat Nesnelerini Yakalama**

Bir XAML dışa aktarımı, dışa aktarılan her slayt için bir XAML belgesi ve ayrıca ayrı görseller ve destek kaynakları üretebilir. Bu sanat nesnelerini varsayılan dosya sistemi kaydedicisi yerine almak için bir özel [IXamlOutputSaver](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ixamloutputsaver/) nesnesini [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/tr/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) metoduna atayın. Dışa aktarmayı, XAML seçeneklerini kabul eden XAML‑özel [Presentation.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) aşırı yüklemesiyle başlatın.

### **Geri Arama Yaşam Döngüsünü Anlamak**

Dışa aktarıcı, üretilen her sanat nesnesi için ayrı ayrı [IXamlOutputSaver.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) metodunu çağırır:

- `path`, sanat nesnesini tanımlar ve göreceli dizinler içerebilir. XAML'in kaynakları göreceli yollarla referanslayabileceği için bu bilgiyi koruyun.
- `data`, sanat nesnesinin baytlarını içerir. Görseller ve diğer ikili kaynaklar metin olarak çözümlenmemelidir.
- Kaydedici, dönüş yapmadan önce veriyi tutmak veya kalıcı hale getirmekle sorumludur. Örneklerde her bayt dizisi uygulama tarafından sahip olunan belleğe kopyalanır.
- Dışa aktarma, yalnızca sunum kaydetme işlemi döndüğünde ve her geri arama başarıyla tamamlandığında başarılı kabul edilmelidir. Depolama hatalarını görmezden gelmeyin veya gözlenmeyen arka plan yazmalarını başlatmayın. Kalıcı kaydetme daha sonra gerçekleşirse, bütün başarının yalnızca bu adım da başarılı olduğunda raporlanması gerekir.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) aynı zamanda özel bir kaydediciye de uygulanır. Varsayılan ayar `false`, gizli slayt XAML belgelerini hariç tutar. `true` geçirilmesi, bunları ve dışa aktarımları için gerekli tüm kaynakları içerir. Kaynak sayısı sunuma bağlıdır; slayt başına bir geri arama veya sabit bir geri arama sırası olduğunu varsaymayın.

### **Belleğe Dışa Aktarma ve Sanat Nesnelerini İnceleme**

Bu tam örnek, `pres.pptx` dosyasını yükler, tüm sanat nesnelerini bir [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html) içinde toplar ve adını, türünü ve bayt sayısını yazdırır. Sağlanan adlar tam olarak korunur. Çift adlar, bir sanat nesnesini sessizce üzerine yazmak yerine koleksiyonu geçersiz olarak işaretler. Örnek, sonuçları kullanmadan önce bunu kontrol eder.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.nio.charset.StandardCharsets;
import java.util.Locale;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

boolean inspectXamlText = false;
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String name = artifact.getKey().toLowerCase(Locale.ROOT);
    boolean isXaml = name.endsWith(".xaml");
    boolean isImage = name.matches(".*\\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$");
    String kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
    System.out.println(artifact.getKey() + ": " + artifact.getValue().length + " bytes (" + kind + ")");

    // Yalnızca XAML'i çöz, ve yalnızca metinsel inceleme gerektiğinde.
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

Uzantı kontrolleri inceleme için faydalıdır; tanıdık olmayan kaynak tipleri dahil tüm sanat nesnelerini koruyun. Baytları saklarken veya iletirken değiştirmeyin. Yalnızca metin işleme gerektiren XAML için UTF‑8 ile [String yapıcısını](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) kullanın.

### **Toplanan Sanat Nesnelerini ZIP Arşivine Paketleme**

Bu bağımsız örnek, dışa aktarmayı toplar, adlarını doğrular ve orijinal baytları bir ZIP arşivine yazar. Benzersiz bir arşiv adı, eşzamanlı dışa aktarma görevlerini ayırır. ZIP girdileri ileri eğik çizgileri kullanır ve göreceli dizinleri korur. Normalizasyon sonrası çakışan veya güvenli olmayan adlar, paket yazılmadan önce tüm paketi reddeder.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.OutputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardOpenOption;
import java.util.Set;
import java.util.TreeSet;
import java.util.UUID;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

Map<String, byte[]> entries = new LinkedHashMap<>();
Set<String> entryNames = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String entryName = artifact.getKey().replace('\\', '/');
    String[] segments = entryName.split("/", -1);
    boolean unsafeName = entryName.startsWith("/") || entryName.contains(":");
    for (String segment : segments) {
        unsafeName |= segment.trim().isEmpty() || segment.equals(".") || segment.equals("..");
    }

    if (unsafeName || !entryNames.add(entryName)) {
        System.err.println("Export rejected: unsafe or duplicate artifact name: " + artifact.getKey());
        return;
    }
    entries.put(entryName, artifact.getValue());
}

Path archivePath = Paths.get("xaml-" + UUID.randomUUID() + ".zip");
try {
    OutputStream output = Files.newOutputStream(archivePath, StandardOpenOption.CREATE_NEW, StandardOpenOption.WRITE);
    try (OutputStream archiveOutput = output; ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // ZIP dizini, başarı raporlanmadan önce kapanarak sonlandırıldı.
    System.out.println("Saved " + entries.size() + " artifacts to " + archivePath);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

Örnek, bir yerel arşiv yazmak için [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) kullanır; dışa aktarıcı kendi başına gevşek XAML veya görsel dosyaları yazmaz. Uzaktan depolama için, arşiv‑yazma aşamasını toplanan bayt dizilerinin yüklemeleriyle değiştirin. Bir dışa aktarma‑görevi kimliğiyle tam göreceli sanat nesnesi adını blob anahtarı olarak kullanın veya görev kimliğini, göreceli adı ve ikili veriyi bir veritabanı satırında saklayın. Tüm yüklemeler tamamlandığında veya veritabanı işlemi onaylandığında görevi yayınlayın. Kalıcı kaydetme başarısız olursa kısmi çıktıyı temizleyin.

Büyük sunumlar için, özel bir kaydedici, tüm dışa aktarmanın uygulama belleğinde ek bir kopyasını tutmaktan kaçınmak amacıyla her sanat nesnesini doğrudan uygulama depolamasına kalıcı olarak kaydedebilir. Dışa aktarıcı açısından her geri aramayı eşzamanlı tutun: hedef baytları kabul ettiğinde yalnızca o anda geri dönün ve hataların çağırıcıya ulaşmasına izin verin.

### **Kaynak Adlarını Koruma ve Referansları Doğrulama**

- Hedef gerektiriyorsa yol ayırıcılarını normalleştirin, ancak göreceli dizinleri koruyun. Her üretilecek adın benzersiz olduğu ve kaynak referanslarının geçerli kaldığı kesin değilse yalnızca [Path.getFileName](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#getFileName--) kullanılmasın.
- Hedefe özgü ad doğrulamasını uygulayın. Gevşek dosyalar yazılırken köklenmiş yolları ve geçiş bölümlerini reddedin, hedefi [Path.toAbsolutePath](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#toAbsolutePath--) ile çözümlendirin ve içermesi gereken klasör ayırıcıyı da dahil ederek hedefin, amaçlanan dışa aktarma dizini altında kaldığını doğrulayın. Yazma yönlendirebilecek sembolik bağlantılar içermeyen, uygulama tarafından kontrol edilen bir dizin kullanın.
- Her dışa aktarma görevi için ayrı bir kaydedici ve depolama ad alanı kullanın. Ayırıcı normalizasyonundan ve hedefin büyük/küçük harf duyarlılığı kurallarına göre çakışmaları tespit edin.
- Yayınlamadan önce, her XAML belgesini XML olarak ayrıştırın ve görüntü `Source` ya da `ImageSource` nitelikleri gibi dosya tabanlı kaynak referanslarını inceleyin. Her göreceli URI’yı içinde bulunduğu XAML sanat nesnesinin dizinine göre çözümleyin, ortaya çıkan depolama adını normalleştirin ve ilgili harita anahtarının, ZIP girdisinin veya saklanan nesnenin mevcut olduğunu doğrulayın. Harici URI’ları ve XAML işaretleme ifadelerini göreceli dosya adlarından ayrı olarak ele alın.

Örneğin, `pres/Slide_1.xaml` dosyası `images/image1.png` dosyasına referans veriyorsa, saklanan kaynak `pres/images/image1.png` olarak mevcut olmalıdır. Yalnızca `image1.png` tutmak bu ilişkiyi bozar. Nesne depolamada, görev önekinin altında aynı dizini koruyun ve bu kaynak URL’lerini XAML tüketicisinin erişebileceği şekilde yapın. Tamamlanmış ZIP’i yeniden açarak giriş adlarını ve kaynak baytlarını doğrulayın ve hedef XAML ortamında temsilci slaytları yükleyerek görsellerin doğru çözüldüğünü onaylayın.

## **SSS**

**Orijinal yazı tipi makinede bulunmuyorsa öngörülebilir yazı tiplerini nasıl sağlayabilirim?**

[XamlOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/xamloptions/) içinde [setDefaultRegularFont](https://reference.aspose.com/slides/tr/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) metodunu çağırın — bu, orijinal yazı tipi eksik olduğunda dışa aktarma sırasında yedek bir yazı tipi olarak kullanılır. Bu, oluşturulan XAML’in yedek yazı tipine başvurduğunu veya yazı tipinin hedef makinede mevcut olduğunu garanti etmez. XAML’in başvurduğu yazı tiplerinin görüntülendiği ortamda bulunmasını sağlayın.

**Dışa aktarılan XAML yalnızca WPF için mi tasarlandı, yoksa diğer XAML yığınlarında da kullanılabilir mi?**

Aspose.Slides, kamu API’si aracılığıyla WPF XAML dışa aktarır. UWP ve Xamarin.Forms gibi diğer XAML yığınlarıyla uyumluluk garanti edilmez. Oluşturulan işaretlemenin hedef ortamınızda test edilmesi gerekir.

**Gizli slaytlar destekleniyor mu ve varsayılan olarak dışa aktarılmalarını nasıl engelleyebilirim?**

Varsayılan olarak, gizli slaytlar dahil edilmez. Bu davranışı [XamlOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/xamloptions/) içindeki [setExportHiddenSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) ile kontrol edebilirsiniz — eğer dışa aktarmanıza gerek yoksa devre dışı bırakın.