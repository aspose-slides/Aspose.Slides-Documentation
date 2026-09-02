---
title: Java'da Sunuları Kaydet
linktitle: Sunuyu Kaydet
type: docs
weight: 80
url: /tr/java/save-presentation/
keywords:
- PowerPoint'i kaydet
- OpenDocument'i kaydet
- sunuyu kaydet
- slaytı kaydet
- PPT'yi kaydet
- PPTX'i kaydet
- ODP'yi kaydet
- sunuyu dosyaya
- sunuyu akışa
- önceden tanımlı görünüm türü
- Katı Office Open XML Formatı
- Zip64 modu
- küçük resmi yenileme
- kaydetme ilerlemesi
- Java
- Aspose.Slides
description: "Aspose.Slides kullanarak Java'da sunuları nasıl kaydedeceğinizi keşfedin—düzenleri, yazı tiplerini ve efektleri koruyarak PowerPoint veya OpenDocument formatına aktarın."
---
## **Genel Bakış**

[Java’da Sunuları Aç](/slides/tr/java/open-presentation/) açıklıyor, bir sunuyu açmak için [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının nasıl kullanılacağını. Bu makale, sunuların nasıl oluşturulacağını ve kaydedileceğini anlatır. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfı bir sununun içeriğini tutar. Sıfırdan bir sunu oluşturuyor ya da var olanı değiştiriyor olun, işiniz bittiğinde kaydetmek isteyeceksiniz. Aspose.Slides for Java ile bir **dosya**ya ya da **akışa** kaydedebilirsiniz. Bu makale, bir sunuyu kaydetmenin farklı yollarını açıklar.

## **Sunuları Dosyalara Kaydet**

Bir sunuyu dosyaya kaydetmek için Presentation sınıfının `save` yöntemini çağırın. Yönteme dosya adını ve kaydetme formatını geçirin. Aşağıdaki örnek, Aspose.Slides ile bir sununun nasıl kaydedileceğini gösterir.

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
Presentation presentation = new Presentation();
try {
    // Burada bir takım işlemler yapın...

    // Sunuyu bir dosyaya kaydedin.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sunuları Akışlara Kaydet**

Bir sunuyu akışa kaydetmek için Presentation sınıfının `save` yöntemine bir çıktı akışı geçirebilirsiniz. Sunu birçok akış türüne yazılabilir. Aşağıdaki örnekte yeni bir sunu oluşturup onu bir dosya akışına kaydediyoruz.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // Sunuyu akışa kaydedin.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Önceden Tanımlı Görünüm Türüyle Sunuları Kaydet**

Aspose.Slides, oluşturulan sunu açıldığında PowerPoint’in kullandığı başlangıç görünümünü [ViewProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/viewproperties/) sınıfı aracılığıyla ayarlamanıza izin verir. [ViewType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/viewtype/) enum’undan bir değerle `setLastView` yöntemini kullanın.

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

## **Sunuları Katı Office Open XML Formatında Kaydet**

Aspose.Slides, bir sunuyu Katı Office Open XML formatında kaydetmenize olanak tanır. Kaydederken [PptxOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pptxoptions/) sınıfını kullanın ve `conformance` özelliğini ayarlayın. `Conformance.Iso29500_2008_Strict` değerini ayarlarsanız çıktı dosyası Katı Office Open XML formatında kaydedilir.

Aşağıdaki örnek bir sunu oluşturur ve Katı Office Open XML formatında kaydeder.

```java
import com.aspose.slides.*;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
Presentation presentation = new Presentation();
try {
    // Sunuyu Katı Office Open XML formatında kaydedin.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Sunuları Office Open XML Formatında Zip64 Modunda Kaydet**

Office Open XML dosyası, herhangi bir dosyanın sıkıştırılmamış boyutu, sıkıştırılmış boyutu ve arşivin toplam boyutu için 4 GB (2^32 bayt) sınırı koyan bir ZIP arşividir ve aynı zamanda arşivi 65 535 (2^16‑1) dosyayla sınırlar. Zip64 format uzantıları bu sınırlamaları 2^64’e yükseltir.

[IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) yöntemi, bir Office Open XML dosyası kaydedilirken Zip64 format uzantılarının ne zaman kullanılacağını seçmenizi sağlar.

Bu yöntem aşağıdaki modlarla kullanılabilir:

- [IfNecessary](https://reference.aspose.com/slides/tr/java/com.aspose.slides/zip64mode/#IfNecessary) sadece sunu yukarıdaki sınırlamaları aştığında Zip64 uzantılarını kullanır. Varsayılan moddur.
- [Never](https://reference.aspose.com/slides/tr/java/com.aspose.slides/zip64mode/#Never) Zip64 uzantılarını asla kullanmaz.
- [Always](https://reference.aspose.com/slides/tr/java/com.aspose.slides/zip64mode/#Always) her zaman Zip64 uzantılarını kullanır.

Aşağıdaki kod, Zip64 format uzantıları etkinleştirilmiş bir PPTX dosyası olarak sununun nasıl kaydedileceğini gösterir:

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

{{% alert title="NOT" color="warning" %}}
[Zip64Mode.Never](https://reference.aspose.com/slides/tr/java/com.aspose.slides/zip64mode/#Never) ile kaydettiğinizde, sunu ZIP32 formatında kaydedilemezse bir [PptxException](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pptxexception/) fırlatılır.
{{% /alert %}}

## **Sunuları Office Open XML Formatında Sıkıştırma Düzeyleriyle Kaydet**

Büyük sunularla çalışırken dosya boyutu ve işleme süresi arasında denge kurmak için sıkıştırma düzeyini ayarlayabilirsiniz. Gereksinimlerinize bağlı olarak daha hızlı işleme ya da daha küçük çıktı dosyaları tercih edebilirsiniz.

Aspose.Slides, Office Open XML formatında bir sunu kaydederken kullanılan sıkıştırma düzeyini belirlemenizi sağlayan [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-) yöntemini sunar.

Aşağıdaki sıkıştırma düzeyleri mevcuttur:

- [**None**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compressionlevel/#None): Sıkıştırma uygulanmaz. Dosyalar olduğu gibi saklanır.
- [**Level1**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compressionlevel/#Level1): En düşük sıkıştırma oranı ile en hızlı sıkıştırma.
- [**Level2**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compressionlevel/#Level2): **Level1**’e göre biraz daha iyi sıkıştırma oranı, hâlâ hızlı.
- [**Level3**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compressionlevel/#Level3): **Level2**’ye göre daha iyi sıkıştırma, işlem süresi orta seviyede.
- [**Level4**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compressionlevel/#Level4): **Level3**’ten daha iyi sıkıştırma.
- [**Level5**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compressionlevel/#Level5): **Level4**’e göre iyileştirilmiş sıkıştırma, ek işlem süresi.
- [**Level6**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compressionlevel/#Level6): İşleme hızı ve dosya boyutu arasında iyi bir denge sunan standart sıkıştırma. *Varsayılan sıkıştırma düzeyidir*.
- [**Level7**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compressionlevel/#Level7): **Level6**’dan daha iyi sıkıştırma, daha yavaş işleme.
- [**Level8**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compressionlevel/#Level8): **Level7**’den daha iyi sıkıştırma.
- [**Level9**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compressionlevel/#Level9): Azami sıkıştırma. En küçük dosya boyutunu üretir, ancak en uzun işlem süresine sahiptir.

Aşağıdaki örnek, sıkıştırma **kullanılmadan** bir PPTX dosyası olarak sununun nasıl kaydedileceğini gösterir:

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

Bu örnek, **azami sıkıştırma** ile bir PPTX dosyası olarak sununun nasıl kaydedileceğini gösterir:

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

## **Küçük Resmi Yenilemeden Sunuları Kaydet**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) yöntemi, bir sunuyu PPTX olarak kaydederken küçük resim oluşturulmasını kontrol eder:

- `true` olarak ayarlanırsa, kaydetme sırasında küçük resim yenilenir. Bu varsayılan değerdir.
- `false` olarak ayarlanırsa, mevcut küçük resim korunur. Sununun küçük resmi yoksa hiç oluşturulmaz.

Aşağıdaki kod, sununun küçük resmini yenilemeden PPTX olarak kaydedilmesini gösterir.

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

{{% alert title="Bilgi" color="info" %}}
Bu seçenek, PPTX formatında bir sunuyu kaydederken harcanan zamanı azaltmaya yardımcı olur.
{{% /alert %}}

## **Kaydetme İlerlemesini Yüzde Olarak Güncelle**

[IProgressCallback](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iprogresscallback/) arabirimi, [ISaveOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isaveoptions/) arabirimi tarafından sunulan `setProgressCallback` yöntemi ve soyut [SaveOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/saveoptions/) sınıfı aracılığıyla kullanılır. `setProgressCallback` ile bir [IProgressCallback](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iprogresscallback/) uygulaması atanır ve kaydetme ilerlemesi yüzde olarak alınır.

Aşağıdaki kod parçacığı, `IProgressCallback` kullanımını gösterir:

```java
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // İlerleme yüzde değerini burada kullanın.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}

ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Bilgi" color="info" %}}
Aspose, kendi API’sini kullanarak ücretsiz bir **PowerPoint Splitter** uygulaması geliştirdi. Bu uygulama, seçilen slaytları yeni PPTX ya da PPT dosyaları olarak kaydederek bir sunuyu birden çok dosyaya bölmenizi sağlar.
{{% /alert %}}

## **SSS**

**“Hızlı kaydet” (artımlı kaydet) destekleniyor mu, sadece değişiklikler mi yazılıyor?**

Hayır. Kaydetme her seferinde tam hedef dosyasını oluşturur; artımlı “hızlı kaydet” desteklenmez.

**Aynı Presentation örneğini birden çok thread’ten kaydetmek güvenli mi?**

Hayır. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) örneği **thread‑safe** değildir; tek bir thread’den kaydedilmelidir.

**Kaydederken köprüler ve dışa bağlı dosyalar ne olur?**

[Hyperlinks](/slides/tr/java/manage-hyperlinks/) korunur. Dışa bağlı dosyalar (ör. göreceli yollarla eklenen videolar) otomatik olarak kopyalanmaz—referans verilen yolların erişilebilir olduğundan emin olun.

**Belge meta verilerini (Yazar, Başlık, Şirket, Tarih) ayarlayıp kaydedebilir miyim?**

Evet. Standart [belge özellikleri](/slides/tr/java/presentation-properties/) desteklenir ve kaydetme sırasında dosyaya yazılır.