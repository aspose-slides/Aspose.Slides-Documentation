---
title: Android'de Sunumları XAML'e Dışa Aktarma
linktitle: Sunumu XAML'e
type: docs
weight: 30
url: /tr/androidjava/export-to-xaml/
keywords:
- PowerPoint dışa aktar
- OpenDocument dışa aktar
- sunum dışa aktar
- PowerPoint dönüştür
- OpenDocument dönüştür
- sunum dönüştür
- PowerPoint'ten XAML'e
- OpenDocument'ten XAML'e
- sunumdan XAML'e
- PPT'den XAML'e
- PPTX'den XAML'e
- ODP'den XAML'e
- PPT'yi XAML olarak kaydet
- PPTX'i XAML olarak kaydet
- ODP'yi XAML olarak kaydet
- PPT'yi XAML'e dışa aktar
- PPTX'i XAML'e dışa aktar
- ODP'yi XAML'e dışa aktar
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'ı Java'da kullanarak PowerPoint ve OpenDocument slaytlarını XAML'e dönüştürün—düzeninizi bozmayan hızlı, Office gerektirmeyen bir çözüm."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Android via Java kullanarak PowerPoint sunumlarını XAML'e nasıl dışa aktaracağınızı açıklar. XAML'e kısa bir giriş içerir, sunumu varsayılan ayarlarla XAML'e nasıl kaydedeceğinizi gösterir ve dışa aktarımı [XamlOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/xamloptions/) aracılığıyla nasıl özelleştireceğinizi, gizli slaytların dışa aktarımını da içerecek şekilde gösterir. Makale ayrıca yedek yazı tipleri, XAML yığını uyumluluğu ve gizli slayt dışa aktarma davranışıyla ilgili birkaç yaygın soruya yanıt verir.

## **XAML Hakkında**

XAML, WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) ve Xamarin.Forms gibi çerçevelerde kullanıcı arabirimlerini tanımlamak için kullanılan XML tabanlı bir işaretleme dilidir.

XAML dosyalarıyla görsel bir tasarımcıda çalışabilir veya işaretlemeyi doğrudan yazıp düzenleyebilirsiniz.

## **Varsayılan Seçeneklerle Sunumları XAML'e Dışa Aktarma**

Aşağıdaki Java örneği, bir sunumu varsayılan ayarlarla XAML'e nasıl dışa aktarılacağını gösterir:

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

Varsayılan olarak, dışa aktarılan slaytlar işlemin geçerli çalışma dizininde bir `pres` alt klasörüne kaydedilir. Klasör otomatik olarak oluşturulur ve gereken tüm görüntüler de buraya kaydedilir.

Çıktı klasörünün adı, kaynak dosyanın uzantısız adından alınır. `pres.pptx` için çıktı dosyaları `pres/Slide_1.xaml`, `pres/Slide_2.xaml` vb. şeklinde adlandırılır. Giriş sunumuna mutlak bir yol verirseniz bile, çıktı klasörü geçerli çalışma dizinine göre oluşturulur, giriş dosyasının yanına değil.

Android'de, uygulamanızın erişebileceği bir giriş dosyası kullanın. Geçerli çalışma dizini yazılabilir olmayabilir; dışa aktarmayı bellekte tutmak veya uygulama depolamasına yazmak için özel bir çıktı kaydedici kullanın, aşağıda gösterildiği gibi. Oluşturulan WPF XAML'i uyumlu bir tüketici için tasarlanmıştır ve bir Android düzen kaynağı değildir.

## **Özel Seçeneklerle Sunumları XAML'e Dışa Aktarma**

Aspose.Slides'in bir sunumu XAML'e nasıl dışa aktardığını kontrol etmek için [IXamlOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ixamloptions/) arayüzünü kullanın.

Çıktıyı özel bir konuma kaydetmek için [IXamlOutputSaver](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ixamloutputsaver/) uygulayın ve uygulamanızın örneğini [XamlOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/xamloptions/) sınıfının [setOutputSaver](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) metoduna aktarın.

XAML çıktısına gizli slaytları dahil etmek için aşağıdaki Java örneğinde gösterildiği gibi `true` ile [setExportHiddenSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) yöntemini çağırın:

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

## **Oluşturulan Tüm XAML Artefaktlarını Yakalama**

Bir XAML dışa aktarımı, dışa aktarılan her slayt için bir XAML belgesi ve ayrı görüntüler ile destekleyici kaynaklar üretebilir. Varsayılan dosya sistemi kaydedicisini kullanmak yerine bu artefaktları almak için [IXamlOutputSaver](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ixamloutputsaver/) özel bir örnek atayın ve [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) metoduna bağlayın. Dışa aktarmayı, XAML‑özel [Presentation.save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) aşırı yüklemesiyle başlatın.

### **Geri Çağırım Yaşam Döngüsünü Anlamak**

Dışa aktarıcı, oluşturulan her artefakt için ayrı ayrı [IXamlOutputSaver.save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) yöntemini çağırır:

- `path` artefaktı tanımlar ve göreli dizinler içerebilir. XAML'in kaynaklara göreli yollarla başvurabileceği için bu bilgiyi koruyun.
- `data` artefaktın baytlarını içerir. Görüntüler ve diğer ikili kaynaklar metin olarak çözülmemelidir.
- Kaydedici, döndürmeden önce veriyi saklamaktan veya kalıcı hale getirmekten sorumludur. Örneklerde her bayt dizisi uygulama tarafından sahip olunan belleğe kopyalanır.
- Sunum kaydetme işlemi geri döndüğünde ve tüm geri çağrılar başarıyla tamamlandığında dışa aktarımı başarılı kabul edin. Depolama hatalarını gizlemeyin veya gözlemlenmeyen arka plan yazmalarını başlatmayın. Kalıcılık daha sonra gerçekleşirse, genel başarıyı yalnızca o adım da başarılı olduğunda raporlayın.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) aynı zamanda özel kaydediciye de uygulanır. Varsayılan ayar `false` gizli slayt XAML belgelerini hariç tutar. `true` geçirilmesi durumunda bunlar ve ihracatları için gerekli tüm kaynaklar dahil olur. Kaynak sayısı sunuma bağlıdır; slayt başına bir geri çağrı veya sabit bir sıralama varsaymayın.

### **Belleğe Dışa Aktarma ve Artefaktları İnceleme**

Bu tam örnek `pres.pptx` dosyasını yükler, her artefaktı bir [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html) içinde toplar ve adını, türünü ve bayt sayısını yazdırır. Sağlanan adları tam olarak korur. Çift adlar koleksiyonu geçersiz olarak işaretler ve bir artefaktı sessizce üzerine yazmaz. Örnek, sonuçları kullanmadan önce bunu kontrol eder.

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

Uzantı kontrolleri inceleme için yararlıdır; bilinmeyen kaynak türleri de dahil olmak üzere tüm artefaktları koruyun. Depolarken veya iletirken baytları değiştirmeyin. Yalnızca metin işleme gerektiren XAML için UTF-8 ile [String constructor](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) kullanın.

### **Toplanan Artefaktları ZIP Arşivinde Paketleme**

Bu bağımsız örnek dışa aktarımı toplar, adlarını doğrular ve orijinal baytları bir ZIP arşivine yazar. `/path/to/app/files` ifadesini Android bağlamınızın [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()) metodundan dönen yol ile değiştirin. Benzersiz bir arşiv adı aynı anda çalışan dışa aktarma işlerini ayırır. ZIP girdileri ileri eğik çizgi (`/`) kullanır ve göreli dizinleri korur. Normalleştirmeden sonra çakışan veya güvensiz adlar, paketleme aşamasında tüm paketi reddeder.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;
import java.util.Set;
import java.util.TreeSet;
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

File exportDirectory = new File("/path/to/app/files");
try {
    File archiveFile = File.createTempFile("xaml-", ".zip", exportDirectory);
    try (FileOutputStream archiveOutput = new FileOutputStream(archiveFile); ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // ZIP dizini, başarı raporlanmadan önce kapatılarak sonlandırıldı.
    System.out.println("Saved " + entries.size() + " artifacts to " + archiveFile);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

Örnek, tek bir yerel arşiv yazmak için [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) kullanır; dışa aktarıcı kendisi gevşek XAML veya görüntü dosyaları yazmaz. Uzaktan depolama için, arşiv yazma aşamasını toplanan bayt dizilerinin yüklemeleriyle değiştirin. Bir dışa aktarma işi tanımlayıcısı ile tam göreli artefakt adını blob anahtarı olarak kullanın veya iş tanımlayıcısını, göreli adı ve ikili veriyi bir veritabanı satırında saklayın. Tüm yüklemeler tamamlandığında veya veritabanı işlemi onaylandığında işi yayınlayın. Kalıcılık başarısız olursa kısmi çıktıyı temizleyin.

Büyük sunumlar için, bir özel kaydedici her artefaktı doğrudan uygulama depolamasına kalıcı hale getirerek tüm dışa aktarmanın ek bir kopyasını uygulama belleğinde tutmaktan kaçınabilir. Dışa aktarıcının bakış açısından her geri çağırmayı senkron tutun: hedef baytları kabul ettikten sonra sadece geri dönün ve hataların çağırıcıya ulaşmasına izin verin.

### **Kaynak İsimlerini Koruma ve Referansları Doğrulama**

- Hedef gerektirdiğinde yol ayırıcılarını normalleştirin, ancak göreli dizinleri koruyun. Tüm oluşturulan adların benzersiz olduğu ve kaynak referanslarının geçerli olduğu kesin değilse sadece [File.getName](https://developer.android.com/reference/java/io/File#getName()) kullanmayın.
- Hedefe özgü ad doğrulaması uygulayın. Gevşek dosyalar yazılırken, köklü yolları ve geçiş bölümlerini reddedin, hedefi [File.getCanonicalPath](https://developer.android.com/reference/java/io/File#getCanonicalPath()) ile çözün ve istenen dışa aktarma dizini altında kaldığından emin olun; denetim kontrolünde dizin ayırıcıyı da dahil edin. Yazma yönlendirmelerine neden olabilecek sembolik bağlar içermeyen, uygulama kontrolündeki bir dizin kullanın.
- Her dışa aktarma işi için ayrı bir kaydedici ve depolama ad alanı kullanın. Ayırıcı normalleştirmesinden sonra ve hedefin büyük/küçük harf duyarlılığı kurallarına göre çakışmaları tespit edin.
- Yayınlamadan önce, her XAML belgesini XML olarak ayrıştırın ve görüntü `Source` veya `ImageSource` gibi dosya tabanlı kaynak referanslarını inceleyin. Her göreli URI'yi içeren XAML artefaktının dizinine göre çözün, oluşan depolama adını normalleştirin ve karşılık gelen harita anahtarının, ZIP girdisinin veya saklanan nesnenin mevcut olduğunu doğrulayın. Dış URI'leri ve XAML işaretleme ifadelerini göreli dosya adlarından ayrı ele alın.

Örneğin, `pres/Slide_1.xaml` dosası `images/image1.png` adresine başvuruyorsa, saklanan kaynak `pres/images/image1.png` olarak mevcut olmalıdır. Sadece `image1.png` tutmak bu ilişkiyi bozar. Nesne depolama için, iş önekinin altında aynı düzeni koruyun ve bu kaynak URL'lerini XAML tüketicisinin erişebileceği şekilde yapın. Tamamlanmış ZIP'i yeniden açarak giriş adı ve kaynak baytlarını doğrulayın ve hedef XAML ortamında temsilci slaytları yükleyerek görüntülerin doğru çözüldüğünden emin olun.

## **SSS**

**Orijinal yazı tipi makinede mevcut değilse, öngörülebilir yazı tiplerini nasıl sağlayabilirim?**

[XamlOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/xamloptions/) içinde [setDefaultRegularFont](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) metodunu çağırın — bu, orijinal yazı tipi eksik olduğunda dışa aktarım sırasında bir yedek yazı tipi olarak kullanılır. Bu, oluşturulan XAML'in yedek yazı tipine başvurduğu veya hedef makinede yazı tipinin bulunduğu anlamına gelmez. XAML'in başvurduğu yazı tiplerinin görüntülendiği ortamda mevcut olduğundan emin olun.

**Dışa aktarılan XAML sadece WPF için mi tasarlanmıştır, yoksa diğer XAML yığınlarında da kullanılabilir mi?**

Aspose.Slides, WPF XAML'i genel API'si aracılığıyla dışa aktarır. UWP ve Xamarin.Forms gibi diğer XAML yığınlarıyla uyumluluğu garanti edilmez. Oluşturulan işaretlemeyi hedef ortamınızda test edin.

**Gizli slaytlar destekleniyor mu ve varsayılan olarak dışa aktarılmalarını nasıl engelleyebilirim?**

Varsayılan olarak gizli slaytlar dahil edilmez. Bu davranışı [XamlOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/xamloptions/) içindeki [setExportHiddenSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) ile kontrol edebilirsiniz — eğer dışa aktarmanıza gerek yoksa devre dışı bırakın.