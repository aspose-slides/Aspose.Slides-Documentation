---
title: Android'de Sunumları Kaydet
linktitle: Sunumu Kaydet
type: docs
weight: 80
url: /tr/androidjava/save-presentation/
keywords:
- PowerPoint kaydet
- OpenDocument kaydet
- sunum kaydet
- slayt kaydet
- PPT kaydet
- PPTX kaydet
- ODP kaydet
- dosyaya sunum
- akışa sunum
- önceden tanımlı görünüm türü
- Katı Office Open XML Biçimi
- Zip64 modu
- küçük resim yenileme
- kaydetme ilerlemesi
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'ı kullanarak Java'da sunumları nasıl kaydedeceğinizi keşfedin—layoutları, yazı tiplerini ve efektleri koruyarak PowerPoint veya OpenDocument olarak dışa aktarın."
---
## **Genel Bakış**

[Android'de Sunumları Aç](/slides/tr/androidjava/open-presentation/) bir sunumu açmak için [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının nasıl kullanılacağını açıkladı. Bu makale, sunumları nasıl oluşturup kaydedeceğinizi açıklıyor. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfı bir sunumun içeriğini tutar. Sıfırdan bir sunum oluşturuyor ya da mevcut bir sunumu değiştiriyor olun, işiniz bittiğinde kaydetmek isteyeceksiniz. Aspose.Slides for Android ile **dosya**ya ya da **akışa** kaydedebilirsiniz. Bu makale, bir sunumu kaydetmenin farklı yollarını açıklıyor.

## **Sunumları Dosyalara Kaydet**

Bir sunumu, [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının `save` metodunu çağırarak dosyaya kaydedin. Metoda dosya adını ve kaydetme biçimini aktarın. Aşağıdaki örnek, Aspose.Slides ile bir sunumu nasıl kaydedeceğinizi gösterir.

```java
// Bir sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
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

[Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının `save` metoduna bir çıktı akışı aktararak bir sunumu akışa kaydedebilirsiniz. Bir sunum birçok akış türüne yazılabilir. Aşağıdaki örnekte yeni bir sunum oluşturup bir dosya akışına kaydediyoruz.

```java
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
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

## **Önceden Tanımlı Görünüm Türüyle Sunumları Kaydet**

Aspose.Slides, oluşturulan sunum açıldığında PowerPoint'in kullandığı başlangıç görünümünü [ViewProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/viewproperties/) sınıfı aracılığıyla ayarlamanıza izin verir. [ViewType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/viewtype/)枚举inden bir değerle `setLastView` metodunu kullanın.

```java
Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sunumları Katı Office Open XML Biçiminde Kaydet**

Aspose.Slides, bir sunumu Katı Office Open XML biçiminde kaydetmenize olanak tanır. Kaydederken `PptxOptions` sınıfını kullanın ve uygun conformance özelliğini ayarlayın. `[Conformance.Iso29500_2008_Strict]`(https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict) ayarlanırsa çıktı dosyası Katı Office Open XML biçiminde kaydedilir.

Aşağıdaki örnek bir sunum oluşturup Katı Office Open XML biçiminde kaydeder.

```java
PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation();
try {
    // Sunumu Katı Office Open XML biçiminde kaydedin.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Sunumları Office Open XML Biçiminde Zip64 Modunda Kaydet**

Bir Office Open XML dosyası, sıkıştırılmamış herhangi bir dosyanın, sıkıştırılmış herhangi bir dosyanın ve arşivin toplam boyutunun 4 GB (2^32 bayt) sınırını ve arşivin 65 535 (2^16‑1) dosyaya kadar olmasını zorunlu kılan bir ZIP arşividir. Zip64 biçim uzantıları bu sınırları 2^64’e yükseltir.

`IPptxOptions.setZip64Mode` yöntemi, bir Office Open XML dosyası kaydedilirken ZIP64 uzantılarının ne zaman kullanılacağını seçmenizi sağlar.

Bu yöntem aşağıdaki modlarla kullanılabilir:

- `IfNecessary` (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/zip64mode/#IfNecessary) yalnızca sunum yukarıdaki sınırlamaları aştığında ZIP64 uzantılarını kullanır. Varsayılan moddur.
- `Never` (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/zip64mode/#Never) ZIP64 uzantılarını asla kullanmaz.
- `Always` (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/zip64mode/#Always) her zaman ZIP64 uzantılarını kullanır.

Aşağıdaki kod, ZIP64 uzantıları etkinleştirilmiş bir PPTX olarak sunumu nasıl kaydedeceğinizi gösterir:

```java
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
`Zip64Mode.Never` ile kaydettiğinizde, sunum ZIP32 biçiminde kaydedilemezse bir `PptxException` (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pptxexception/) fırlatılır.
{{% /alert %}}

## **Küçük Resmi Yenilemeden Sunumları Kaydet**

`PptxOptions.setRefreshThumbnail` yöntemi, bir sunumu PPTX olarak kaydederken küçük resim oluşturulmasını kontrol eder:

- `true` olarak ayarlanırsa kaydetme sırasında küçük resim yenilenir. Varsayılandır.
- `false` olarak ayarlanırsa mevcut küçük resim korunur. Sunumun küçük resmi yoksa hiç oluşturulmaz.

Aşağıdaki kod, sunumu küçük resmi yenilemeden PPTX olarak kaydeder.

```java
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
Bu seçenek, PPTX biçiminde bir sunumu kaydetme süresini azaltmaya yardımcı olur.
{{% /alert %}}

## **Kaydetme İlerlemesini Yüzde Olarak Güncelle**

`IProgressCallback` arayüzü, `ISaveOptions` (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isaveoptions/) arayüzünün `setProgressCallback` yöntemi ve soyut `SaveOptions` (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/saveoptions/) sınıfı aracılığıyla kullanılır. `setProgressCallback` ile bir `IProgressCallback` uygulaması atayarak kaydetme ilerlemesini yüzde olarak alabilirsiniz.

Aşağıdaki kod parçacıkları `IProgressCallback` nasıl kullanılacağını gösterir.

```java
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
class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Burada ilerleme yüzde değeri kullanın.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose, kendi API'sini kullanan bir [ücretsiz PowerPoint Splitter uygulaması](https://products.aspose.app/slides/tr/splitter) geliştirdi. Uygulama, seçilen slaytları yeni PPTX veya PPT dosyaları olarak kaydederek bir sunumu birden çok dosyaya bölmenizi sağlar.
{{% /alert %}}

## **SSS**

**"Hızlı kaydetme" (artımlı kaydetme) sadece değişikliklerin yazılması için destekleniyor mu?**

Hayır. Kaydetme her seferinde tam hedef dosyayı oluşturur; artımlı “hızlı kaydetme” desteklenmez.

**Aynı Presentation örneğini birden fazla thread'den kaydetmek thread‑safe mi?**

Hayır. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) örneği [thread‑safe değildir](/slides/tr/androidjava/multithreading/); tek bir thread'den kaydedin.

**Kaydederken hiperlinkler ve harici bağlı dosyalar ne olur?**

[Hiperlinkler](/slides/tr/androidjava/manage-hyperlinks/) korunur. Harici bağlı dosyalar (ör. göreceli yollarla eklenen videolar) otomatik olarak kopyalanmaz—referans verilen yolların erişilebilir olduğundan emin olun.

**Belge meta verilerini (Yazar, Başlık, Şirket, Tarih) ayarlayıp/kaydedebilir miyim?**

Evet. Standart [belge özellikleri](/slides/tr/androidjava/presentation-properties/) desteklenir ve kaydetme sırasında dosyaya yazılır.