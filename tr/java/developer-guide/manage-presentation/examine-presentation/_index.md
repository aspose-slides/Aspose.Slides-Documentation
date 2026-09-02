---
title: Java'da Sunum Bilgilerini Al ve Güncelle
linktitle: Sunum Bilgileri
type: docs
weight: 30
url: /tr/java/examine-presentation/
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
- Java
- Aspose.Slides
description: "Java kullanarak PowerPoint ve OpenDocument sunumlarında slaytları, yapıyı ve meta verileri keşfedin, daha hızlı içgörüler ve daha akıllı içerik denetimleri sağlayın."
---
## **Genel Bakış**

Aspose.Slides, bir sunumun formatını belirleyebilir ve tam bir sunum nesne modeli oluşturmadan belge meta verilerini okuyabilir. Bu, dosyaları sınıflandırmanız, bir envanter oluşturmanız veya sunum içeriğini yükleyip işleme almaya karar vermeden önce özellikleri incelemeniz gerektiğinde faydalıdır.

Bu makale, hafif denetimi [PresentationFactory](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentationfactory/) ve [IPresentationInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationinfo/) aracılığıyla, ayrıca hedeflenmiş güncellemeleri [IDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idocumentproperties/) üzerinden göstermektedir.

## **Sunum Formatını Kontrol Et**

Bir dosyayı [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) örneği oluşturmadan incelemek için [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) kullanın. [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) yöntemi, PPTX, PPT veya ODP gibi tespit edilen formatı raporlar.

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

Birçok sunum dosyasını işlerken, doğrulama, indeksleme veya bir belge yönetim sistemi için kompakt bir envantere ihtiyaç duyabilirsiniz. Bu senaryoda, [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) kullanarak bir [IPresentationInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationinfo/) nesnesi elde edin ve ardından [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) yöntemini çağırarak belge meta verilerini okuyun. Bu yaklaşım bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) örneği oluşturmaz ve tam sunum nesne modelinde gezinmenizi gerektirmez.

[IDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idocumentproperties/) tarafından sağlanan genişletilmiş özellikler aşağıdaki envanter değerlerini sunar:

| Yöntem | Envanter değeri |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idocumentproperties/#getSlides--) | Toplam slayt sayısı. |
| [getHiddenSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | Gizli slayt sayısı. |
| [getNotes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idocumentproperties/#getNotes--) | Not içeren slayt sayısı. |
| [getParagraphs](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idocumentproperties/#getParagraphs--) | Mevcut olduğunda toplam paragraf sayısı. |
| [getWords](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idocumentproperties/#getWords--) | Toplam kelime sayısı. |
| [getMultimediaClips](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | Toplam ses ve video klip sayısı. |

Aşağıdaki örnek bu değerleri bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) nesnesi oluşturmadan okur ve kompakt bir envanter yazdırır. Ayrıca [getHeadingPairs](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idocumentproperties/#getHeadingPairs--) ile [getTitlesOfParts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) kombinasyonunu kullanarak yazı tipleri, temalar ve slayt başlıkları gibi içerik gruplarını gösterir.

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

Her [IHeadingPair](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iheadingpair/) bir grup adı ve o gruptaki öğe sayısını sağlar. [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) düz, sıralı bir dizi döndürür, bu yüzden her başlık çiftinin belirttiği ardışık başlık sayısını tüketin.

### **Depolanmış Meta Veriler ve Biçim Kısıtlamaları**

[IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) tarafından döndürülen envanter özellikleri, kaynak belgede bulunan meta verileri yansıtır. Aspose.Slides bu çağrı için bu değerleri yeniden hesaplamak amacıyla sunum nesne modelini yükleyip gezinmez. Eksik özellikler varsayılan değerlerle temsil edilir ve saklanan değerler, dosyayı en son kaydeden uygulama belge özelliklerini güncellemediyse eski olabilir.

- **PPTX:** Biçim, slayt, not, gizli‑slayt, paragraf, kelime ve multimedya sayılarını, ayrıca başlık çiftlerini ve bölüm başlıklarını içeren genişletilmiş belge özellikleri sağlar. Kullanılabilirlik, belge üreticisinin hangi özellikleri yazdığına bağlıdır.
- **PPT:** İkili biçim, karşılık gelen belge‑özet özelliklerini depolayabilir. Bir özellik yoksa veya belge üreticisi tarafından güncellenmemişse, Aspose.Slides bu özelliğin depolanmış ya da varsayılan değerini döndürür, slaytlardan yeniden hesaplamaz.
- **ODP:** OpenDocument meta verileri, sayfa, paragraf ve kelime sayısı gibi genel belge istatistikleri sağlar, ancak bu değerler her PowerPoint‑özel genişletilmiş özelliğe karşılık gelmez. Gizli‑slayt, not‑slayt, multimedya, başlık‑çifti ve bölüm‑başlığı meta verileri mevcut olmayabilir ve envanter özellikleri varsayılan değerleri döndürebilir. Sıfır değeri ya da boş dizi, ilgili içeriğin yok olduğuna kesin kanıt olarak kabul edilmemelidir.

Hafif meta veri yaklaşımını envanterler ve ön kontrol amaçları için kullanın. Sonucun bellek içi değişiklikleri yansıtması gerektiğinde veya gerçek sunum içeriğini doğrulamanız gerektiğinde sunumu yükleyip canlı nesne modelini inceleyin.

## **Sunum Özelliklerini Güncelleme**

[IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) tarafından döndürülen özellikler, bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) örneği oluşturmadan da değiştirilebilir. Değişiklikleri [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) ile uygulayın ve ardından bağlı sunumu [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-) ile yazın.

Aşağıdaki resim, orijinal belge özelliklerini gösterir.

![PowerPoint sunumunun orijinal belge özellikleri](input_properties.png)

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

Aşağıdaki resim, güncellenmiş belge özelliklerini gösterir.

![PowerPoint sunumunun değiştirilmiş belge özellikleri](output_properties.png)

## **Yararlı Bağlantılar**

İlgili güvenlik kontrolleri ve koruma ayarları için aşağıdaki makalelere bakın:

- [Sunumları Parola ile Koruma](/slides/tr/java/password-protected-presentation/)
- [Sunumları Yazma Koruması ile Koruma](/slides/tr/java/write-protected-presentation/)

## **SSS**

**Yazı tiplerinin gömülü olup olmadığını ve hangileri olduğunu nasıl kontrol edebilirim?**

Sunumu yükleyin ve [Presentation.getFontsManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getFontsManager--) yöntemini kullanın. Gömülü yazı tiplerini elde etmek için [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) ve sunum tarafından kullanılan yazı tiplerini almak için [IFontsManager.getFonts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontsmanager/#getFonts--) çağırın. İki sonucu karşılaştırarak render için gerekli ancak gömülmemiş yazı tiplerini bulun.

**Dosyanın gizli slaytları olup olmadığını ve kaç tane olduğunu hızlıca nasıl öğrenebilirim?**

Depolanmış belge meta verileri yeterli olduğunda, [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) ve [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) aracılığıyla [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) okuyun. Bu, hafif bir envanter için uygundur. Sunum bellek içinde değiştirilmişse, depolanmış meta veriler eksik ya da eski olabilir; bu durumda canlı değerleri doğrulamak için [Presentation.getSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getSlides--) üzerinden gezinip her slaytın [ISlide.getHidden](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islide/#getHidden--) yöntemini inceleyin.

**Özel slayt boyutu ve yönünün kullanılıp kullanılmadığını ve varsayılanlardan farklı olup olmadığını tespit edebilir miyim?**

Evet. Sunumu yükleyin ve [Presentation.getSlideSize](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getSlideSize--) yöntemini çağırın. Mevcut ayarları beklenen ön ayar ve boyutlarla karşılaştırmak için [ISlideSize.getType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidesize/#getType--), [ISlideSize.getSize](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidesize/#getSize--) ve [ISlideSize.getOrientation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidesize/#getOrientation--) kullanın.

**Grafiklerin dış veri kaynaklarına başvurup başvurmadığını hızlı bir şekilde görmenin bir yolu var mı?**

Evet. Her [Chart](https://reference.aspose.com/slides/tr/java/com.aspose.slides/chart/) bulun ve [IChartData.getDataSourceType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdata/#getDataSourceType--) yöntemini çağırın. Dış bir çalışma kitabı için [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) yöntemini kullanın. Veri kaynağı tipi ve yolu dış referansı tanımlar, ancak hedefin mevcut olup olmadığını doğrulamak ayrı bir kaynak kontrolü gerektirir.

**Renderlama veya PDF dışa aktarmayı yavaşlatabilecek 'ağır' slaytları nasıl değerlendirebilirim?**

Tek bir karmaşıklık özelliği yoktur. [Presentation.getSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getSlides--) ve her slaytın [IBaseSlide.getShapes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibaseslide/#getShapes--) koleksiyonunu gezerek şekil sayısını, büyük görüntüleri, efektleri, animasyonları veya multimedyaları inceleyin. Bu sinyaller bir ön eleme sağlar; ardından temsili bir render veya dışa aktarma ölçümü yaparak bir slaytı kesin bir performans darboğazı olarak sınıflandırın.