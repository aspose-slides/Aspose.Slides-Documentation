---
title: Java'da Sunumları Kaydet
linktitle: Sunumu Kaydet
type: docs
weight: 80
url: /tr/java/save-presentation/
keywords:
- PowerPoint'i kaydet
- OpenDocument'i kaydet
- sunumu kaydet
- slaytı kaydet
- PPT'yi kaydet
- PPTX'i kaydet
- ODP'yi kaydet
- sunumu dosyaya
- sunumu akışa
- önceden tanımlı görünüm türü
- Katı Office Open XML Biçimi
- Zip64 modu
- küçük resmi yenileme
- kaydetme ilerlemesi
- Java
- Aspose.Slides
description: "Aspose.Slides kullanarak Java'da sunumları nasıl kaydedeceğinizi keşfedin—düzenleri, yazı tiplerini ve efektleri koruyarak PowerPoint veya OpenDocument olarak dışa aktarın."
---
## **Genel Bakış**

[Java'da Sunumları Açma](/slides/tr/java/open-presentation/) bir sunumu açmak için [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının nasıl kullanılacağını açıkladı. Bu makale, sunumların nasıl oluşturulacağını ve kaydedileceğini açıklar. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfı bir sunumun içeriğini içerir. Sıfırdan bir sunum oluşturuyor ya da mevcut bir sunumu değiştiriyor olun, işiniz bittiğinde onu kaydetmek isteyeceksiniz. Aspose.Slides for Java ile bir **dosyaya** ya da **akışa** kaydedebilirsiniz. Bu makale, bir sunumu kaydetmenin farklı yollarını açıklar.

## **Sunumları Dosyalara Kaydetme**

Presentation sınıfının `save` metodunu çağırarak bir sunumu dosyaya kaydedin. Metoda dosya adını ve kaydetme formatını geçin. Aşağıdaki örnek, Aspose.Slides ile bir sunumu nasıl kaydedeceğinizi gösterir.

```java
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation();
try {
    // Burada bazı işlemler yapın...

    // Sunumu bir dosyaya kaydedin.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sunumları Akışlara Kaydetme**

Presentation sınıfının `save` metoduna bir çıktı akışı geçirerek bir sunumu akışa kaydedebilirsiniz. Bir sunum birçok akış tipine yazılabilir. Aşağıdaki örnekte yeni bir sunum oluşturuyor ve onu bir dosya akışına kaydediyoruz.

```java
// Sunum dosyasını temsil eden Presentation sınıfını oluşturun.
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

## **Önceden Tanımlı Görünüm Türüyle Sunumları Kaydetme**

Aspose.Slides, oluşturulan sunum açıldığında PowerPoint'in kullandığı ilk görünümü ViewProperties sınıfı aracılığıyla ayarlamanıza izin verir. setLastView metodunu, ViewType (GörünümTürü) enumundan bir değerle kullanın.

```java
Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sunumları Katı Office Open XML Biçiminde Kaydetme**

Aspose.Slides, bir sunumu Katı Office Open XML biçiminde kaydetmenizi sağlar. Kaydederken PptxOptions sınıfını kullanın ve onun conformance (uyumluluk) özelliğini ayarlayın. Conformance.Iso29500_2008_Strict değerini ayarlarsanız, çıktı dosyası Katı Office Open XML biçiminde kaydedilir.

Aşağıdaki örnek bir sunum oluşturur ve onu Katı Office Open XML biçiminde kaydeder.

```java
PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Sunum dosyasını temsil eden Presentation sınıfını oluşturun.
Presentation presentation = new Presentation();
try {
    // Sunumu Katı Office Open XML biçiminde kaydedin.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Sunumları Office Open XML Biçiminde Zip64 Modunda Kaydetme**

Office Open XML dosyası, herhangi bir dosyanın sıkıştırılmamış boyutu, sıkıştırılmış boyutu ve arşivin toplam boyutu için 4 GB (2^32 bayt) sınırları getiren bir ZIP arşividir ve ayrıca arşivi 65.535 (2^16‑1) dosyayla sınırlamaktadır. ZIP64 format uzantıları bu sınırları 2^64'e yükseltir.

IPptxOptions.setZip64Mode metodu, bir Office Open XML dosyasını kaydederken ZIP64 format uzantılarını ne zaman kullanacağınızı seçmenizi sağlar.

Bu metod aşağıdaki modlarla kullanılabilir:

- IfNecessary, yalnızca sunum yukarıdaki sınırlamaları aşıyorsa ZIP64 format uzantılarını kullanır. Bu varsayılan moddur.
- Never, ZIP64 format uzantılarını asla kullanmaz.
- Always, ZIP64 format uzantılarını her zaman kullanır.

Aşağıdaki kod, ZIP64 format uzantıları etkinleştirilmiş bir PPTX olarak bir sunumu nasıl kaydedeceğinizi gösterir:

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
Zip64Mode.Never ile kaydettiğinizde, sunum ZIP32 formatında kaydedilemezse bir PptxException fırlatılır.
{{% /alert %}}

## **Sunumları Küçük Resmi Yenilemeden Kaydetme**

PptxOptions.setRefreshThumbnail metodu, bir sunumu PPTX olarak kaydederken küçük resim oluşturulmasını kontrol eder:

- `true` olarak ayarlanırsa, kaydetme sırasında küçük resim yenilenir. Bu varsayılandır.
- `false` olarak ayarlanırsa, mevcut küçük resim korunur. Sunumun küçük resmi yoksa, hiç oluşturulmaz.

Aşağıdaki kodda, sunum küçük resmi yenilenmeden PPTX olarak kaydedilir.

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
Bu seçenek, PPTX formatında bir sunumu kaydetme süresini azaltmaya yardımcı olur.
{{% /alert %}}

## **Kaydetme İlerleme Güncellemelerini Yüzde Olarak Almak**

IProgressCallback arayüzü, ISaveOptions arayüzü ve soyut SaveOptions sınıfı tarafından sunulan setProgressCallback metodu aracılığıyla kullanılır. setProgressCallback ile bir IProgressCallback uygulaması atayarak kaydetme ilerlemesi güncellemelerini yüzde olarak alabilirsiniz.

Aşağıdaki kod parçacıkları, IProgressCallback kullanımı gösterir.

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
        // Burada ilerleme yüzde değerini kullanın.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose, kendi API'sini kullanarak ücretsiz bir PowerPoint Splitter uygulaması geliştirdi. Uygulama, seçilen slaytları yeni PPTX veya PPT dosyaları olarak kaydederek bir sunumu birden fazla dosyaya bölmenizi sağlar.
{{% /alert %}}

## **SSS**

**"Hızlı kaydet" (artımlı kaydet) sadece değişikliklerin yazılması için destekleniyor mu?**

Hayır. Kaydetme her seferinde hedef dosyanın tamamını oluşturur; artımlı "hızlı kaydet" desteklenmez.

**Aynı Presentation örneğini birden çok thread'ten kaydetmek güvenli mi?**

Hayır. Presentation örneği thread‑güvenli değildir; kaydetmeyi tek bir thread'den yapın.

**Kaydederken köprüler ve harici bağlantılı dosyalar ne olur?**

[Köprüler](/slides/tr/java/manage-hyperlinks/) korunur. Harici bağlantılı dosyalar (ör. göreli yollarla videolar) otomatik olarak kopyalanmaz—referans verilen yolların erişilebilir olduğundan emin olun.

**Belge meta verilerini (Yazar, Başlık, Şirket, Tarih) ayarlayabilir/kaydedebilir miyim?**

Evet. Standart belge özellikleri desteklenir ve kaydetme sırasında dosyaya yazılır.