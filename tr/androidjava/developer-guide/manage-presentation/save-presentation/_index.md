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
- sunumu dosyaya
- sunumu akışa
- önceden tanımlı görünüm türü
- Katı Office Open XML Biçimi
- Zip64 modu
- küçük resmi yenileme
- kaydetme ilerlemesi
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android kullanarak Java'da sunumları nasıl kaydedeceğinizi keşfedin—düzenleri, yazı tiplerini ve efektleri koruyarak PowerPoint veya OpenDocument olarak dışa aktarın."
---
## **Genel Bakış**

[Open Presentations on Android](/slides/tr/androidjava/open-presentation/) bir sunumu açmak için [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının nasıl kullanılacağını açıklamaktadır. Bu makale, bir sunumu nasıl oluşturup kaydedeceğinizi açıklar. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfı bir sunumun içeriğini barındırır. Sıfırdan bir sunum oluşturuyor ya da var olanı değiştiriyor olun, işiniz bittiğinde onu kaydetmek isteyeceksiniz. Aspose.Slides for Android ile bir **dosyaya** veya **akışa** kaydedebilirsiniz. Bu makale, bir sunumu kaydetmenin farklı yollarını açıklamaktadır.

## **Sunumları Dosyalara Kaydet**

Bir sunumu dosyaya kaydetmek için [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının `save` metodunu çağırın. Metoda dosya adını ve kaydetme biçimini geçirin. Aşağıdaki örnek, Aspose.Slides ile bir sunumu nasıl kaydedeceğinizi gösterir.

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden Presentation sınıfını oluştur.
Presentation presentation = new Presentation();
try {
    // Burada bazı işlemler yapın...

    // Sunumu bir dosyaya kaydedin.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sunumları Akışlara Kaydet**

Bir sunumu bir akışa, [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının `save` metoduna bir çıktı akışı geçirerek kaydedebilirsiniz. Sunum birçok akış türüne yazılabilir. Aşağıdaki örnekte, yeni bir sunum oluşturup onu bir dosya akışına kaydediyoruz.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

// Sunum dosyasını temsil eden Presentation sınıfını oluştur.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // Sunumu akışa kaydedin.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Önceden Tanımlı Görünüm Türü ile Sunumları Kaydet**

Aspose.Slides, oluşturulan sunum açıldığında PowerPoint'in kullandığı ilk görünümü [ViewProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/viewproperties/) sınıfı aracılığıyla ayarlamanıza izin verir. [setLastView](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) metodunu [ViewType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/viewtype/) enumerasyonundaki bir değerle kullanın.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sunumları Katı Office Open XML Biçiminde Kaydet**

Aspose.Slides, bir sunumu Katı Office Open XML biçiminde kaydetmenizi sağlar. Kaydederken [PptxOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pptxoptions/) sınıfını kullanın ve onun conformance özelliğini ayarlayın. [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict) değerini ayarlarsanız, çıktı dosyası Katı Office Open XML biçiminde kaydedilir.

Aşağıdaki örnek bir sunum oluşturur ve onu Katı Office Open XML biçiminde kaydeder.

```java
import com.aspose.slides.*;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Sunum dosyasını temsil eden Presentation sınıfını oluştur.
Presentation presentation = new Presentation();
try {
    // Sunumu Katı Office Open XML biçiminde kaydedin.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Sunumları Office Open XML Biçiminde Zip64 Modunda Kaydet**

Bir Office Open XML dosyası, herhangi bir dosyanın sıkıştırılmamış boyutu, sıkıştırılmış boyutu ve arşivin toplam boyutu için 4 GB (2^32 bayt) sınırları koyan bir ZIP arşividir ve ayrıca arşivi 65 535 (2^16‑1) dosyayla sınırlar. ZIP64 biçim uzantıları bu sınırları 2^64’e yükseltir.

[IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) metodu, bir Office Open XML dosyası kaydedilirken ZIP64 biçim uzantılarını ne zaman kullanacağınızı seçmenizi sağlar.

Bu yöntem aşağıdaki modlarla kullanılabilir:

- [IfNecessary](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/zip64mode/#IfNecessary) yalnızca sunum yukarıdaki sınırlamaları aşarsa ZIP64 biçim uzantılarını kullanır. Bu varsayılan moddur.
- [Never](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/zip64mode/#Never) ZIP64 biçim uzantılarını asla kullanmaz.
- [Always](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/zip64mode/#Always) her zaman ZIP64 biçim uzantılarını kullanır.

Aşağıdaki kod, ZIP64 biçim uzantıları etkinleştirilmiş bir PPTX dosyası olarak bir sunumu nasıl kaydedeceğinizi gösterir:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setZip64Mode(Zip64Mode.Always);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
ZIP64Mode.Never ile kaydettiğinizde, sunum ZIP32 biçiminde kaydedilemezse bir [PptxException](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pptxexception/) istisnası fırlatılır.
{{% /alert %}}

## **Sunumları Office Open XML Biçiminde Sıkıştırma Seviyeleriyle Kaydet**

Büyük sunumlarla çalışırken, dosya boyutu ve işleme süresi dengesini ayarlamak için sıkıştırma seviyesini ayarlayabilirsiniz. Gereksinimlerinize bağlı olarak, daha hızlı işleme ya da daha küçük çıktı dosyalarını tercih edebilirsiniz.

Aspose.Slides, Office Open XML biçiminde bir sunumu kaydederken kullanılan sıkıştırma seviyesini belirlemenizi sağlayan [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-) metodunu sunar.

Aşağıdaki sıkıştırma seviyeleri kullanılabilir:

- [**None**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compressionlevel/#None): Sıkıştırma uygulanmaz. Dosyalar olduğu gibi depolanır.
- [**Level1**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compressionlevel/#Level1): En düşük sıkıştırma oranı ile en hızlı sıkıştırma.
- [**Level2**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compressionlevel/#Level2): **Level1**'e göre biraz daha iyi sıkıştırma oranı ile daha hızlı sıkıştırma.
- [**Level3**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compressionlevel/#Level3): **Level2**'den daha iyi sıkıştırma sağlar ve işlem süresi üzerinde orta seviyede bir etki yapar.
- [**Level4**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compressionlevel/#Level4): **Level3**'ten daha iyi sıkıştırma sağlar.
- [**Level5**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compressionlevel/#Level5): **Level4**'ün üzerinde geliştirilmiş sıkıştırma sunar ancak ek işlem süresi gerektirir.
- [**Level6**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compressionlevel/#Level6): İşleme hızı ve dosya boyutu arasında iyi bir denge sunan standart sıkıştırma. Bu *varsayılan sıkıştırma seviyesidir*.
- [**Level7**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compressionlevel/#Level7): **Level6**'dan daha iyi sıkıştırma sağlar ancak daha yavaş işlem.
- [**Level8**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compressionlevel/#Level8): **Level7**'den daha iyi sıkıştırma sağlar.
- [**Level9**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compressionlevel/#Level9): Azami sıkıştırma. En uzun işlem süresi karşılığında en küçük dosya boyutunu üretir.

Aşağıdaki örnek, bir sunumu *sıkıştırma olmadan* PPTX dosyası olarak nasıl kaydedeceğinizi gösterir:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.None);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

Bu örnek, bir sunumu *azami sıkıştırma* ile PPTX dosyası olarak nasıl kaydedeceğinizi gösterir:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.Level9);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **Küçük Resmi Yenilemeden Sunumları Kaydet**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) metodu, bir sunumu PPTX olarak kaydederken küçük resim oluşturulmasını kontrol eder:

- `true` olarak ayarlanırsa, kaydetme sırasında küçük resim yenilenir. Bu varsayılandır.
- `false` olarak ayarlanırsa, mevcut küçük resim korunur. Sunumun küçük resmi yoksa, hiç oluşturulmaz.

Aşağıdaki kodda, sunum küçük resmi yenilenmeden PPTX olarak kaydedilir.

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setRefreshThumbnail(false);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Bu seçenek, PPTX formatında bir sunumu kaydetmek için gereken süreyi azaltmaya yardımcı olur.
{{% /alert %}}

## **Kaydetme İlerleme Güncellemelerini Yüzde Olarak Al**

[IProgressCallback](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iprogresscallback/) arayüzü, [ISaveOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isaveoptions/) arayüzü ve soyut [SaveOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/saveoptions/) sınıfı tarafından sunulan `setProgressCallback` metodu aracılığıyla kullanılır. `setProgressCallback` ile bir [IProgressCallback](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iprogresscallback/) uygulaması atayarak kaydetme ilerlemesi güncellemelerini yüzde olarak alabilirsiniz.

Aşağıdaki kod snippet'leri, `IProgressCallback` kullanımını gösterir:

```java
import com.aspose.slides.*;

ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```
```java
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Burada ilerleme yüzde değerini kullan.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose, kendi API'sını kullanarak ücretsiz bir PowerPoint Splitter uygulaması geliştirdi. Uygulama, seçilen slaytları yeni PPTX veya PPT dosyaları olarak kaydederek bir sunumu birden fazla dosyaya bölmenizi sağlar.
{{% /alert %}}

## **SSS**

**"Hızlı kaydet" (artımlı kaydetme) yalnızca değişikliklerin yazılması destekleniyor mu?**

Hayır. Kaydetme her seferinde tam hedef dosyasını oluşturur; artımlı "hızlı kaydet" desteklenmez.

**Aynı Presentation örneğini birden fazla iş parçacığından kaydetmek güvenli mi?**

Hayır. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) örneği [thread‑safe değildir](/slides/tr/androidjava/multithreading/); tek bir iş parçacığından kaydedin.

**Kaydetme sırasında köprüler ve harici bağlı dosyalar ne olur?**

[Hyperlinks](/slides/tr/androidjava/manage-hyperlinks/) korunur. Harici bağlı dosyalar (ör. göreceli yollarla videolar) otomatik olarak kopyalanmaz—referans verilen yolların erişilebilir olduğundan emin olun.

**Belge meta verilerini (Yazar, Başlık, Şirket, Tarih) ayarlayıp/kaydedebilir miyim?**

Evet. Standart [document properties](/slides/tr/androidjava/presentation-properties/) desteklenir ve kaydetme sırasında dosyaya yazılır.