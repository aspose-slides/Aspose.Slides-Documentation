---
title: Java'da Sunumları Kaydet
linktitle: Sunumu Kaydet
type: docs
weight: 80
url: /tr/java/save-presentation/
keywords:
- PowerPoint kaydet
- OpenDocument kaydet
- sunum kaydet
- slayt kaydet
- PPT kaydet
- PPTX kaydet
- ODP kaydet
- sunumu dosyaya
- sunumu akışa
- önceden tanımlı görünüm türü
- Katı Office Open XML Biçimi
- Zip64 modu
- küçük resmi yenileme
- kaydetme ilerlemesi
- Java
- Aspose.Slides
description: "Aspose.Slides ile Java'da PowerPoint ve OpenDocument sunumlarını dosyalara veya akışlara kaydedin ve PPTX çıktısını ve ilerleme raporlamasını yapılandırın."
---
## **Genel Bakış**

Sunum oluşturduktan sonra veya [var olan bir tanesini aç](/slides/tr/java/open-presentation/), sonucu yazmak için [Presentation.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#save-java.lang.String-int-) yöntemini kullanın. Aspose.Slides for Java, bir sunumu PowerPoint, OpenDocument, PDF ve diğer formatlarda bir dosyaya veya akışa kaydedebilir. Aşağıdaki bölümler standart kaydetme işlemlerini ve PPTX çıktısı için mevcut seçenekleri kapsar.

## **Sunumları Dosyalara Kaydet**

Bir sunumu bir dosyaya kaydetmek için, çıktı yolunu ve bir [SaveFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/saveformat/) değerini [Presentation.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#save-java.lang.String-int-) yöntemine geçirin. Format değeri, Aspose.Slides'in oluşturacağı dosya türünü belirler.

Aşağıdaki örnek bir sunum oluşturur ve PPTX dosyası olarak kaydeder:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    // Sunum içeriğini burada ekleyin veya değiştirin.

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sunumları Orijinal Biçimlerinde Kaydet**

Dosya ve akış tespiti örnekleri, yeni oluşturulan sunumların davranışı ve kaynak ile çıktı formatları arasındaki ayrım için, [Orijinal Sunum Formatını Belirleme](/slides/tr/java/detect-presentation-source-format/) bölümüne bakın.

Bir toplu işleme uygulamasında, giriş formatı önceden bilinmeyebilir. Bir dosya yüklendikten sonra, orijinal formatını [IPresentation.getSourceFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentation/#getSourceFormat--) yönteminden okuyun. Elde edilen [SourceFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/sourceformat/) değerini [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slideutil/#toSaveFormat-int-) metoduna geçirerek karşılık gelen [SaveFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/saveformat/) değerini alın ve ardından [Presentation.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#save-java.lang.String-int-) yöntemini kullanarak değiştirilmiş sunumu yazın.

Aşağıdaki tam örnek bir giriş dizinindeki her dosyayı işler, başlığını günceller ve yüklendiği formatta bir çıktı dizinine kaydeder:

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

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slideutil/#toSaveFormat-int-) PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP ve PowerPoint XML dosyalarını ilgili sunum kaydetme formatlarına eşler. Yalnızca sunum kaynak formatlarını eşler; PDF, HTML, TIFF veya görüntüler gibi dışa aktarma formatlarını seçmek için tasarlanmamıştır. Desteklenmeyen veya geçersiz bir [SourceFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/sourceformat/) değeri geçirilirse bir [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html) oluşur.

Eski PPT, PPS ve POT dosyaları aynı ikili kapsayıcıyı kullanır. Böyle bir sunum, dosya uzantısı olmadan bir akıştan yüklendiğinde bir PPS veya POT dosyası PPT olarak tanımlanabilir. Bu eski alt türlerin korunması gerekiyorsa, orijinal dosya adını veya format meta verisini ayrı olarak tutun ve çıktı dosya adı ve formatı seçilirken bunu kullanın.

## **Sunumları Akışlara Kaydet**

Bir sunumu son bir dosya yoluna ihtiyaç duymadan yazmak için, yazılabilir bir akış ve bir [SaveFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/saveformat/) değerini [Presentation.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) yöntemine geçirin. Bu yöntem, çıktının bir web hizmetinden döndürülmesi, bir veritabanında depolanması veya bellekte işlenmesi gerektiğinde kullanışlıdır.

Aşağıdaki örnek yeni bir sunumu bir dosya akışına kaydeder:

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

## **Önceden Tanımlı Görünüm Türü ile Sunumları Kaydet**

PowerPoint'in kaydedilen bir sunumu ilk açtığında kullanılacak görünümü belirtebilirsiniz. Kaydetmeden önce bir [ViewType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/viewtype/) değeriyle [ViewProperties.setLastView](https://reference.aspose.com/slides/tr/java/com.aspose.slides/viewproperties/#setLastView-int-) yöntemini kullanın.

Aşağıdaki örnek Slide Master görünümünü ilk görünüm olarak ayarlar:

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

## **Sunumları Katı Office Open XML Biçiminde Kaydet**

Office Open XML’in Katı profiline uygun bir PPTX dosyası oluşturmak için bir [PptxOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pptxoptions/) örneği oluşturun ve [setConformance](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pptxoptions/#setConformance-int-) yöntemini [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/tr/java/com.aspose.slides/conformance/#Iso29500-2008-Strict) ile kullanın. Ardından seçenekleri [Presentation.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) yöntemine geçirin.

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

## **Sunumları Office Open XML Biçiminde Zip64 Modunda Kaydet**

Standart bir ZIP arşivi, her girişin sıkıştırılmış ve sıkıştırılmamış boyutunu, toplam arşiv boyutunu ve giriş sayısını sınırlar. PPTX dosyası bir ZIP arşivi olduğundan, çok büyük bir sunum bu sınırlamaları aşabilir. ZIP64 uzantıları uygulanabilir boyut ve giriş sayısı limitlerini artırır.

[SlideUtil.toSaveFormat] örneğinde görüldüğü gibi, ZIP64 uzantılarını yazdırıp yazdırmayacağınızı kontrol etmek için [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pptxoptions/#setZip64Mode-int-) yöntemini kullanın:

- [IfNecessary](https://reference.aspose.com/slides/tr/java/com.aspose.slides/zip64mode/#IfNecessary) sunum standart ZIP limitlerini aştığında ZIP64'ü kullanır. Varsayılan moddur.
- [Never](https://reference.aspose.com/slides/tr/java/com.aspose.slides/zip64mode/#Never) ZIP64 uzantılarını devre dışı bırakır.
- [Always](https://reference.aspose.com/slides/tr/java/com.aspose.slides/zip64mode/#Always) çıktı sunumu için her zaman ZIP64 uzantılarını yazar.

Aşağıdaki örnek çıktı sunumu için ZIP64 uzantılarını her zaman etkinleştirir:

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
Eğer [Zip64Mode.Never](https://reference.aspose.com/slides/tr/java/com.aspose.slides/zip64mode/#Never) kullanılırsa ve sunum standart ZIP limitlerine sığamazsa, kaydetme işlemi bir [PptxException](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pptxexception/) fırlatır.
{{% /alert %}}

## **Sunumları Office Open XML Biçiminde Sıkıştırma Seviyeleriyle Kaydet**

PPTX çıktısı için [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pptxoptions/#setCompressionLevel-int-) yöntemini kullanarak kaydetme hızını dosya boyutuna göre dengeleyebilirsiniz. [CompressionLevel](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compressionlevel/) sınıfı aşağıdaki değerleri sağlar:

- [None](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compressionlevel/#None) veriyi sıkıştırma olmadan saklar.
- [Level1](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compressionlevel/#Level1) en hızlı sıkıştırmayı ve en büyük sıkıştırılmış çıktıyı sağlar.
- [Level2](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compressionlevel/#Level2) – [Level5](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compressionlevel/#Level5) daha küçük çıktıyı, kaydetme hızına tercih eder.
- [Level6](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compressionlevel/#Level6) kaydetme hızı ve dosya boyutunu dengeler. Bu varsayılan seviyedir.
- [Level7](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compressionlevel/#Level7) ve [Level8](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compressionlevel/#Level8) kaydetme hızına göre daha küçük çıktıyı tercih eder.
- [Level9](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compressionlevel/#Level9) en güçlü sıkıştırmayı sağlar ve en fazla işleme süresi gerektirir.

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

## **Sunumları Küçük Resmi Yenilemeden Kaydet**

Bir sunum PPTX olarak kaydedildiğinde, [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) yöntemi belge küçük resmini kontrol eder:

- `true` kaydetme sırasında küçük resmi yeniden oluşturur. Varsayılan değerdir.
- `false` mevcut küçük resmi korur. Sunumun küçük resmi yoksa Aspose.Slides bir tane oluşturmaz.

Aşağıdaki örnek bir sunumu küçük resmi yenilemeden kaydeder:

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
Küçük resim yenilemeyi devre dışı bırakmak, bir PPTX dosyasının kaydedilme süresini azaltabilir.
{{% /alert %}}

## **Kaydetme İlerleme Güncellemelerini Yüzde Olarak Al**

Bir kaydetme işlemini izlemek için [IProgressCallback](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iprogresscallback/) arayüzünü uygulayın ve uygulamayı [ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-) yöntemine geçirin. Aspose.Slides, dışa aktarma sırasında ilerleme değerleriyle [IProgressCallback.reporting](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iprogresscallback/#reporting-double-) yöntemini çağırır.

Aşağıdaki örnek PDF dışa aktarımının ilerlemesini konsola raporlar:

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
Aspose, Aspose.Slides API’sı ile oluşturulmuş ücretsiz bir [PowerPoint Splitter](https://products.aspose.app/slides/tr/splitter) sunar. Seçilen slaytları ayrı PPT veya PPTX dosyaları olarak kaydeder.
{{% /alert %}}

## **FAQ**

**Aspose.Slides artımlı veya “hızlı kaydetme”yi destekliyor mu?**

Hayır. Her kaydetme işlemi, yalnızca değişen bölümleri güncellemek yerine tam bir çıktı dosyası yazar.

**Birden fazla iş parçacığı aynı Presentation örneğini kaydedebilir mi?**

Hayır. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) örneği [thread‑safe değildir](/slides/tr/java/multithreading/). Her örneğe aynı anda yalnızca bir iş parçacığından erişin ve kaydedin.

**Bir sunumu kaydettiğimde hiperlinkler ve harici bağlı dosyalar ne olur?**

[Hyperlinkler](/slides/tr/java/manage-hyperlinks/) sunumda kalır. Aspose.Slides harici bağlı dosyaları kopyalamaz, bu yüzden kaydedilen sunum bunların konumlarına hâlâ erişebilmelidir.

**Yazar, başlık, şirket ve oluşturulma tarihi gibi belge üst verilerini kaydedebilir miyim?**

Evet. Kaydetmeden önce uygun [belge özelliklerini](/slides/tr/java/presentation-properties/) ayarlayın ve Aspose.Slides bunları çıktı dosyasına yazar.