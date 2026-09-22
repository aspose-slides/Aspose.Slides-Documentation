---
title: Android'de Sunumları Kaydet
linktitle: Sunumu Kaydet
type: docs
weight: 80
url: /tr/androidjava/save-presentation/
keywords:
- PowerPoint kaydet
- OpenDocument kaydet
- sunumu kaydet
- slaytı kaydet
- PPT kaydet
- PPTX kaydet
- ODP kaydet
- dosyaya sunum
- akışa sunum
- önceden tanımlı görünüm türü
- Katı Office Open XML Formatı
- Zip64 modu
- küçük resmi yenileme
- kaydetme ilerlemesi
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides ile Android'de PowerPoint ve OpenDocument sunumlarını dosyalara veya akışlara kaydedin ve PPTX çıktısını ve ilerleme raporlamasını yapılandırın."
---
## **Genel Bakış**

Bir sunum oluşturduktan veya [var olan birini açtıktan](/slides/tr/androidjava/open-presentation/), sonucu yazmak için [Presentation.save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) yöntemini kullanın. Java üzerinden Aspose.Slides for Android, bir sunumu PowerPoint, OpenDocument, PDF ve diğer formatlarda dosya veya akışa kaydedebilir. Aşağıdaki bölümler standart kaydetme işlemlerini ve PPTX çıktısı için mevcut seçenekleri kapsar.

## **Dosyalara Sunum Kaydetme**

Bir sunumu dosyaya kaydetmek için, çıktı yolunu ve bir [SaveFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/saveformat/) değerini [Presentation.save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) yöntemine gönderin. Format değeri, Aspose.Slides'in oluşturacağı dosya türünü belirler.

Aşağıdaki örnek bir sunum oluşturur ve onu PPTX dosyası olarak kaydeder:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    // Burada sunum içeriğini ekleyin veya değiştirin.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sunumları Orijinal Formatlarında Kaydetme**

Dosya ve akış tespiti örnekleri, yeni oluşturulan sunumların davranışı ve kaynak ile çıktı formatları arasındaki ayrım için [Determine the Original Presentation Format](/slides/tr/androidjava/detect-presentation-source-format/) sayfasına bakın.

Bir toplu işleme uygulamasında, giriş formatı önceden bilinmeyebilir. Bir dosya yüklendikten sonra, orijinal formatını [IPresentation.getSourceFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--) yönteminden okuyun. Elde edilen [SourceFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/sourceformat/) değerini [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) yöntemine geçirerek karşılık gelen [SaveFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/saveformat/) değerini alın ve ardından [Presentation.save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) yöntemiyle değiştirilmiş sunumu yazın.

Aşağıdaki tam örnek, giriş dizinindeki her dosyayı işler, başlığını günceller ve yüklendiği formatta çıkış dizinine kaydeder:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SlideUtil;
import java.io.File;

File inputDirectory = new File("Input");
File outputDirectory = new File("Output");

if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    System.err.println("Cannot create the output directory.");
}

File[] inputFiles = inputDirectory.listFiles(File::isFile);
if (inputFiles != null && outputDirectory.isDirectory()) {
    for (File inputFile : inputFiles) {
        try {
            Presentation presentation = new Presentation(inputFile.getPath());
            try {
                int saveFormat = SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                File outputFile = new File(outputDirectory, inputFile.getName());
                presentation.save(outputFile.getPath(), saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (IllegalArgumentException exception) {
            System.err.println("Cannot map the source format of '" + inputFile.getPath() + "': " + exception.getMessage());
        } catch (Exception exception) {
            System.err.println("Cannot process '" + inputFile.getPath() + "': " + exception.getMessage());
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP ve PowerPoint XML'i karşılık gelen sunum kaydetme formatlarına eşler. Yalnızca sunum kaynak formatlarını eşler; PDF, HTML, TIFF veya görseller gibi dışa aktarım formatlarını seçmek amacıyla kullanılmaz. Desteklenmeyen veya geçersiz bir [SourceFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/sourceformat/) değeri gönderildiğinde bir [IllegalArgumentException](https://developer.android.com/reference/java/lang/IllegalArgumentException) ortaya çıkar.

Eski PPT, PPS ve POT dosyaları aynı ikili konteyneri kullanır. Böyle bir sunum dosya uzantısı olmadan bir akıştan yüklendiğinde, bir PPS veya POT dosyası PPT olarak tanımlanabilir. Bu eski alt tiplerin korunması gerekiyorsa, orijinal dosya adını veya format meta verisini ayrı olarak tutun ve çıktı dosya adı ve formatını seçerken kullanın.

## **Akışlara Sunum Kaydetme**

Son bir dosya yoluna bağlı kalmadan bir sunumu yazmak için, yazılabilir bir akış ve bir [SaveFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/saveformat/) değerini [Presentation.save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) yöntemine gönderin. Bu yaklaşım, çıktının bir web hizmetinden döndürülmesi, bir veritabanında saklanması veya bellekte işlenmesi gerektiğinde faydalıdır.

Aşağıdaki örnek yeni bir sunumu dosya akışına kaydeder:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileOutputStream;
import java.io.OutputStream;

Presentation presentation = new Presentation();
try {
    OutputStream outputStream = new FileOutputStream("Output.pptx");
    try {
        presentation.save(outputStream, SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Önceden Tanımlı Görünüm Türü ile Sunum Kaydetme**

PowerPoint'in kaydedilen bir sunumu ilk açtığı görünümü belirtebilirsiniz. Kaydetmeden önce bir [ViewType] değeriyle [ViewProperties.setLastView](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) yöntemini kullanın.

Aşağıdaki örnek, Slide Master görünümünü başlangıç görünümü olarak yapılandırır:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sunumları Katı Office Open XML Formatında Kaydetme**

Office Open XML'in Katı (Strict) profiline uyan bir PPTX dosyası oluşturmak için bir [PptxOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pptxoptions/) örneği oluşturun ve onun [setConformance](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pptxoptions/#setConformance-int-) yöntemini [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict) değeriyle kullanın. Ardından seçenekleri [Presentation.save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) yöntemine aktarın.

```java
import com.aspose.slides.Conformance;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

Presentation presentation = new Presentation();
try {
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Sunumları Office Open XML Formatında Zip64 Modunda Kaydetme**

Standart bir ZIP arşivi, her girişin sıkıştırılmış ve sıkıştırılmamış boyutunu, toplam arşiv boyutunu ve giriş sayısını sınırlamaktadır. PPTX dosyası bir ZIP arşivi olduğundan, çok büyük bir sunum bu sınırlamaları aşabilir. ZIP64 uzantıları uygulanabilir boyut ve giriş sayısı sınırlarını artırır.

[​PptxOptions.setZip64Mode](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pptxoptions/#setZip64Mode-int-) yöntemini kullanarak Aspose.Slides'in ZIP64 uzantıları yazıp yazmayacağını kontrol edebilirsiniz:

- [IfNecessary](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/zip64mode/#IfNecessary) yalnızca sunum standart ZIP sınırlamalarını aştığında ZIP64 kullanır. Bu, varsayılan moddur.
- [Never](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/zip64mode/#Never) ZIP64 uzantılarını devre dışı bırakır.
- [Always](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/zip64mode/#Always) her zaman ZIP64 uzantılarını yazar.

Aşağıdaki örnek, çıktı sunumu için ZIP64 uzantılarını her zaman etkinleştirir:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.Zip64Mode;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setZip64Mode(Zip64Mode.Always);

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Eğer [Zip64Mode.Never](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/zip64mode/#Never) kullanılır ve sunum standart ZIP sınırları içinde sığmazsa, kaydetme işlemi bir [PptxException](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pptxexception/) atar.
{{% /alert %}}

## **Sunumları Office Open XML Formatında Sıkıştırma Düzeyleriyle Kaydetme**

PPTX çıktısı için, [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pptxoptions/#setCompressionLevel-int-) yöntemini kullanarak kaydetme hızı ile dosya boyutu arasında denge kurabilirsiniz. [CompressionLevel](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compressionlevel/) sınıfı şu değerleri sunar:

- [None](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compressionlevel/#None) verileri sıkıştırma olmadan depolar.
- [Level1](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compressionlevel/#Level1) en hızlı sıkıştırmayı ve en büyük sıkıştırılmış çıktıyı sağlar.
- [Level2](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compressionlevel/#Level2) ila [Level5](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compressionlevel/#Level5) arasındaki seviyeler, kaydetme hızından daha küçük çıktıyı tercih eder.
- [Level6](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compressionlevel/#Level6) kaydetme hızı ile dosya boyutunu dengeleyerek varsayılan seviyedir.
- [Level7](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compressionlevel/#Level7) ve [Level8](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compressionlevel/#Level8) daha da küçük çıktıyı, kaydetme hızından önce tercih eder.
- [Level9](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compressionlevel/#Level9) en güçlü sıkıştırmayı sağlar ve en uzun işlem süresine ihtiyaç duyar.

Aşağıdaki örnek bir sunumu sıkıştırma olmadan kaydeder:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.None);

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

Aşağıdaki örnek maksimum sıkıştırma seviyesini kullanır:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.Level9);

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Küçük Resmi Yenilemeden Sunum Kaydetme**

Bir sunum PPTX olarak kaydedildiğinde, [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) yöntemi belge küçük resmini kontrol eder:

- `true` kaydetme sırasında küçük resmi yeniden oluşturur. Bu varsayılan değerdir.
- `false` mevcut küçük resmi korur. Sunumun küçük resmi yoksa, Aspose.Slides bir tane oluşturmaz.

Aşağıdaki örnek bir sunumu küçük resmini yenilemeden kaydeder:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("Output.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Küçük resim yenilemesini devre dışı bırakmak, bir PPTX dosyasının kaydedilme süresini azaltabilir.
{{% /alert %}}

## **Kaydetme İlerleme Güncellemelerini Yüzde Olarak Almak**

Bir kaydetme işlemini izlemek için, [IProgressCallback](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iprogresscallback/) arayüzünü uygulayın ve bu uygulamayı [ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-) yöntemine iletin. Aspose.Slides, dışa aktarma sırasında ilerleme değerleriyle [IProgressCallback.reporting](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iprogresscallback/#reporting-double-) yöntemini çağırır.

Aşağıdaki örnek bir PDF dışa aktarımının ilerlemesini konsola raporlar:

```java
import com.aspose.slides.IProgressCallback;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        int progress = (int) progressValue;
        System.out.println(progress + "% of the file has been converted.");
    }
}

PdfOptions options = new PdfOptions();
options.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose, Aspose.Slides API'siyle oluşturulmuş ücretsiz bir [PowerPoint Splitter](https://products.aspose.app/slides/tr/splitter) sunar. Bu araç, bir sunumdan seçilen slaytları ayrı PPT veya PPTX dosyaları olarak kaydeder.
{{% /alert %}}

## **SSS**

**Aspose.Slides artımlı veya “hızlı kaydetme” özelliğini destekliyor mu?**

Hayır. Her kaydetme işlemi yalnızca değişen kısımları güncellemek yerine tam bir çıktı dosyası yazar.

**Birden çok iş parçacığı aynı Presentation örneğini kaydedebilir mi?**

Hayır. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) örneği [iş parçacığı güvenli değildir](/slides/tr/androidjava/multithreading/). Her örüntüye aynı anda sadece bir iş parçacığından erişilip kaydedilmelidir.

**Sunumu kaydettiğimde köprüler ve dışa bağlı dosyalar ne olur?**

[Hyperlinks](/slides/tr/androidjava/manage-hyperlinks/) sunumda kalır. Aspose.Slides dışarıdan bağlanan dosyaları kopyalamaz, bu nedenle kaydedilen sunumun bunların konumlarına hâlâ erişebilmesi gerekir.

**Yazar, başlık, şirket ve oluşturulma tarihi gibi belge meta verilerini kaydedebilir miyim?**

Evet. Kaydetmeden önce uygun [document properties](/slides/tr/androidjava/presentation-properties/) ayarlayın; Aspose.Slides bunları çıktı dosyasına yazar.