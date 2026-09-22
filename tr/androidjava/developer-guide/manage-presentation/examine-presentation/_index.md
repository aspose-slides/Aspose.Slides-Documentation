---
title: Android'de Sunum Bilgilerini Al ve Güncelle
linktitle: Sunum Bilgileri
type: docs
weight: 30
url: /tr/androidjava/examine-presentation/
keywords:
- sunum formatı
- sunum özellikleri
- belge özellikleri
- özellikleri al
- özellikleri oku
- özellikleri değiştir
- özellikleri düzenle
- özellikleri güncelle
- PPTX incele
- PPT incele
- ODP incele
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarında slaytları, yapıyı ve meta verileri Java kullanarak keşfedin; daha hızlı içgörüler ve daha akıllı içerik denetimleri sağlayın."
---
## **Genel Bakış**

Aspose.Slides, bir sunumun formatını tanımlayabilir ve tam bir sunum nesne modeli oluşturmadan belge meta verilerini okuyabilir. Bu, dosyaları sınıflandırmanız, bir envanter oluşturmanız veya sunum içeriğini yükleyip işlemeye karar vermeden önce özellikleri incelemeniz gerektiğinde faydalıdır.

Bu makale, [PresentationFactory](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentationfactory/) ve [IPresentationInfo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationinfo/) aracılığıyla hafif incelemeyi, ayrıca [IDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idocumentproperties/) yoluyla hedeflenmiş güncellemeleri göstermektedir.

## **Sunum Biçimini Kontrol Et**

Eğer zaten yüklenmiş bir sunumunuz varsa, yükleme sonrası algılama ve eski PPT, PPS ve POT akışlarının sınırlamaları için [Determine the Original Presentation Format](/slides/tr/androidjava/detect-presentation-source-format/) bölümüne bakın.

Dosyayı bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) örneği oluşturmadan incelemek için [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) kullanın. [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) yöntemi, PPTX, PPT veya ODP gibi algılanan formatı raporlar.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;

String[] fileNames = { "pres.pptx", "pres.ppt", "pres.odp" };

for (String fileName : fileNames) {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(fileName);
    int loadFormat = presentationInfo.getLoadFormat();
    String formatName = "Other (" + loadFormat + ")";

    if (loadFormat == LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat == LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat == LoadFormat.Odp) {
        formatName = "ODP";
    }

    System.out.println(fileName + ": " + formatName);
}
```

## **Hafif Bir Sunum Envanteri Oluşturma**

Çok sayıda sunum dosyasını işlerken, doğrulama, indeksleme veya belge yönetim sistemi için kompakt bir envantere ihtiyacınız olabilir. Bu senaryoda, bir [IPresentationInfo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationinfo/) nesnesi elde etmek için [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) kullanın ve ardından belge meta verilerini okumak için [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) çağırın. Bu yaklaşım bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) örneği oluşturmaz veya tam sunum nesne modelini gezmenizi gerektirmez.

[IDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idocumentproperties/) tarafından sunulan genişletilmiş özellikler aşağıdaki envanter değerlerini sağlar:

| Yöntem | Envanter değeri |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idocumentproperties/#getSlides--) | Toplam slayt sayısı. |
| [getHiddenSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | Gizli slayt sayısı. |
| [getNotes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idocumentproperties/#getNotes--) | Not içeren slayt sayısı. |
| [getParagraphs](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idocumentproperties/#getParagraphs--) | Mevcut olduğunda toplam paragraf sayısı. |
| [getWords](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idocumentproperties/#getWords--) | Toplam kelime sayısı. |
| [getMultimediaClips](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | Toplam ses ve video klip sayısı. |

Aşağıdaki örnek, bu değerleri bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) nesnesi oluşturmadan okur ve kompakt bir envanter yazdırır. Ayrıca, fontlar, temalar ve slayt başlıkları gibi içerik gruplarını göstermek için [getHeadingPairs](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idocumentproperties/#getHeadingPairs--) ile [getTitlesOfParts](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) kombinasyonunu kullanır.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IHeadingPair;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;
import java.nio.file.Paths;

String filePath = "sample.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

int loadFormat = presentationInfo.getLoadFormat();
String formatName = "Other (" + loadFormat + ")";

if (loadFormat == LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat == LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat == LoadFormat.Odp) {
    formatName = "ODP";
}

System.out.println("File: " + Paths.get(filePath).getFileName());
System.out.println("Format: " + formatName);
System.out.println("Title: " + documentProperties.getTitle());
System.out.println("Author: " + documentProperties.getAuthor());
System.out.println("Statistics:");
System.out.println("  Slides: " + documentProperties.getSlides());
System.out.println("  Hidden slides: " + documentProperties.getHiddenSlides());
System.out.println("  Slides with notes: " + documentProperties.getNotes());
System.out.println("  Paragraphs: " + documentProperties.getParagraphs());
System.out.println("  Words: " + documentProperties.getWords());
System.out.println("  Multimedia clips: " + documentProperties.getMultimediaClips());

IHeadingPair[] headingPairs = documentProperties.getHeadingPairs();
String[] titlesOfParts = documentProperties.getTitlesOfParts();
headingPairs = headingPairs != null ? headingPairs : new IHeadingPair[0];
titlesOfParts = titlesOfParts != null ? titlesOfParts : new String[0];
int partIndex = 0;

if (headingPairs.length == 0 || titlesOfParts.length == 0) {
    System.out.println("Content groups: not available");
} else {
    System.out.println("Content groups:");

    for (IHeadingPair headingPair : headingPairs) {
        System.out.println("  " + headingPair.getName() + " (" + headingPair.getCount() + ")");

        for (int partOffset = 0; partOffset < headingPair.getCount() && partIndex < titlesOfParts.length; partOffset++) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        System.out.println("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }
}
```

Her [IHeadingPair](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iheadingpair/) bir grup adı ve o gruptaki öğe sayısını sağlar. [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) düz, sıralı bir dizi döndürür, bu yüzden her başlık çiftinin belirttiği ardışık başlık sayısını tüketin.

### **Depolanmış Meta Veriler ve Biçim Sınırlamaları**

[IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) tarafından döndürülen envanter özellikleri, kaynak belgede mevcut meta verileri yansıtır. Aspose.Slides bu çağrı için bu değerleri yeniden hesaplamak amacıyla sunum nesne modelini yükleyip dolaşmaz. Eksik özellikler varsayılan değerlerle temsil edilir ve son kaydetme işlemini yapan uygulama belge özelliklerini güncellemediyse depolanmış değerler eski olabilir.

- **PPTX:** Biçim, slayt, not, gizli slayt, paragraf, kelime ve multimedya sayımları için genişletilmiş belge özellikleri, ayrıca başlık çiftleri ve parça başlıkları sağlar. Kullanılabilirlik, belge üreticisinin hangi özellikleri yazdığına bağlıdır.
- **PPT:** İkili biçim, ilgili belge-özet özelliklerini depolayabilir. Bir özellik yoksa veya belge üreticisi tarafından yenilenmemişse, Aspose.Slides bu özelliği slaytlardan hesaplamak yerine depolanmış ya da varsayılan değerini döndürür.
- **ODP:** OpenDocument meta verileri, sayfa, paragraf ve kelime sayısı gibi genel belge istatistikleri sağlar, ancak bu değerler her PowerPoint‑özel genişletilmiş özelliğe karşılık gelmez. Gizli slayt, not slaytı, multimedya, başlık çifti ve parça başlığı meta verileri mevcut olmayabilir ve envanter özellikleri varsayılan değerler döndürebilir. Sıfır değerini veya boş bir diziyi, ilgili içeriğin yok olduğunun kesin kanıtı olarak değerlendirmeyin.

Hafif meta veri yaklaşımını envanterler ve ön kontroller için kullanın. Sonucun bellek içi değişiklikleri yansıtması gerektiğinde veya gerçek sunum içeriğini doğrulamanız gerektiğinde sunumu yükleyin ve canlı nesne modelini inceleyin.

## **Sunum Özelliklerini Güncelleme**

[IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) tarafından döndürülen özellikler, bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) örneği oluşturmadan da değiştirilebilir. Değişiklikleri [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) ile uygulayın ve ardından bağlanmış sunumu [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-) ile yazın.

Aşağıdaki görsel, orijinal belge özelliklerini gösterir.

![PowerPoint sunumunun orijinal belge özellikleri](input_properties.png)

Aşağıdaki örnek, başlığı ve son kaydetme zamanını değiştirir ve sonucu yeni bir dosyaya yazar:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.io.FileOutputStream;
import java.io.OutputStream;
import java.util.Date;

String sourceFile = "sample.pptx";
String outputFile = "sample_with_updated_properties.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(sourceFile);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(new Date());

presentationInfo.updateDocumentProperties(documentProperties);
try (OutputStream outputStream = new FileOutputStream(outputFile)) {
    presentationInfo.writeBindedPresentation(outputStream);
}
```

Aşağıdaki görsel, güncellenmiş belge özelliklerini gösterir.

![PowerPoint sunumunun güncellenmiş belge özellikleri](output_properties.png)

## **Faydalı Bağlantılar**

İlgili güvenlik kontrolleri ve koruma ayarları için aşağıdaki makalelere bakın:

- [Sunumları Parola ile Korumak](/slides/tr/androidjava/password-protected-presentation/)
- [Sunumları Yazma Koruması ile Korumak](/slides/tr/androidjava/write-protected-presentation/)

## **SSS**

**Fontların gömülü olup olmadığını ve hangi fontların gömülü olduğunu nasıl kontrol edebilirim?**

Sunumu yükleyin ve [Presentation.getFontsManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getFontsManager--) kullanın. Gömülü fontları almak için [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) , sunum tarafından kullanılan fontları almak için [IFontsManager.getFonts](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) çağırın. İki sonucu karşılaştırarak, render için gerekli ancak gömülmemiş fontları bulun.

**Dosyanın gizli slaytları olup olmadığını ve sayısını nasıl hızlıca öğrenebilirim?**

Depolanan belge meta verileri yeterli olduğunda, [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) metodunu [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) ve [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) aracılığıyla okuyun. Bu, hafif bir envanter için uygundur. Sunum bellek içinde değiştirilmişse, depolanmış meta veriler eksik ya da eski olabilir veya canlı değerleri doğrulamanız gerekiyorsa, [Presentation.getSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getSlides--) üzerinden döngü yapıp her slaytın [ISlide.getHidden](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/#getHidden--) metodunu inceleyin.

**Özel slayt boyutu ve yönünün kullanılıp kullanılmadığını ve varsayılanlardan farklı olup olmadığını nasıl tespit edebilirim?**

Evet. Sunumu yükleyin ve [Presentation.getSlideSize](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getSlideSize--) metodunu çağırın. Mevcut ayarları beklenen ön ayar ve boyutlarla karşılaştırmak için [ISlideSize.getType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidesize/#getType--), [ISlideSize.getSize](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidesize/#getSize--) ve [ISlideSize.getOrientation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidesize/#getOrientation--) kullanın.

**Grafiklerin dış veri kaynaklarına başvurup başvurmadığını hızlıca görmek mümkün mü?**

Evet. Her bir [Chart](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/chart/) bulun ve [IChartData.getDataSourceType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--) metodunu çağırın. Dış bir çalışma kitabı için [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) metodunu kullanın. Veri kaynağı türü ve yol, dış referansı gösterir, ancak hedefin mevcut olup olmadığını doğrulamak ayrı bir kaynak kontrolü gerektirir.

**Render'ı veya PDF dışa aktarımını yavaşlatabilecek 'ağır' slaytları nasıl değerlendirebilirim?**

Tek bir karmaşıklık özelliği yoktur. [Presentation.getSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getSlides--) ve her slaytın [IBaseSlide.getShapes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibaseslide/#getShapes--) koleksiyonunu dolaşın. Şekil sayısı, büyük resimler, efektler, animasyonlar veya multimedya varlığı gibi sinyalleri tarama işareti olarak kullanın ve bir slaydı kesin bir performans darboğazı olarak sınıflandırmadan önce temsilci bir render veya dışa aktarım ölçümü yapın.