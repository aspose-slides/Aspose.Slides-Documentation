---
title: Java'da Sunum Özelliklerini Yönetme
linktitle: Sunum Özellikleri
type: docs
weight: 70
url: /tr/java/presentation-properties/
keywords:
- PowerPoint özellikleri
- sunum özellikleri
- belge özellikleri
- yerleşik özellikler
- özel özellikler
- gelişmiş özellikler
- özellikleri yönetme
- özellikleri değiştirme
- belge meta verileri
- meta verileri düzenleme
- düzeltme dili
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da sunum özelliklerini yönetin ve PowerPoint ve OpenDocument dosyalarınızda aramayı, markalaşmayı ve iş akışını kolaylaştırın."
---
## **Giriş**

Aspose.Slides for Java, **yerleşik** ve **özel** belge özelliklerini destekler. Bu özellikleri, yazar, başlık ve kullanıcı tanımlı değerler gibi sunum meta verilerini okumak ve güncellemek için kullanın.

Aspose.Slides, sunum belge özellikleriyle [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) arayüzü üzerinden çalışmanıza olanak tanır. Bu arayüzün bir örneği, [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) tarafından döndürülür. Aşağıdaki örnekler, bu özelliklerin nasıl okunacağını, değiştirileceğini ve yönetileceğini gösterir.

{{% alert color="info" title="Note" %}}
Aspose.Slides, sunumları kaydederken uygulama ve üretici meta verilerini yönetir; bu alanlar çıktıyı oluşturan yazılımı tanımlar.
{{% /alert %}}

## **Sunum Özelliklerini Yönetme**

Belge özellikleri, sunum içeriğiyle birlikte tanımlayıcı bilgileri depolar. İki kategoriye ayrılırlar:

- **Yerleşik özellikler** standart meta verileri içerir, örneğin başlık, yazar ve belge istatistikleri.
- **Özel özellikler** kullanıcı tarafından tanımlanan ad/değer çiftlerini saklar.

Aspose.Slides for Java, her iki kategoriye de erişim sağlar. PowerPoint'ta belge meta verilerini incelemek için **File → Info → Properties → Advanced Properties** seçeneğini seçin. İleti penceresi bilgileri **Summary**, **Statistics**, **Contents** ve **Custom** gibi sekmelere ayırır. Kullanıcı tanımlı özellikleri yönetmek için **Custom** sekmesini kullanın.

## **Şifrelenmiş Bir Sunumdan Genel Özellikleri Okuma**

Açılış şifresi genellikle hem sunum içeriğini hem de belge özelliklerini korur. Bir sunum, [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) `false` ile çağrıldıktan sonra şifrelenirse, belge özellikleri açık kalır. Uygulama daha sonra [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) `true` ile çağırarak açılış şifresi vermeden genel meta verileri okuyabilir.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) Aspose.Slides'ın neyi yüklediğini kontrol eder; hiçbir şeyi çözmez. Özellikler şifreleme içine alınmışsa, şifre olmadan yükleme başarısız olur. Sunum şifrelenmemişse, seçenek yok sayılır ve tam sunum yüklenir.

Örnek, belge özellikleri açık bırakılmış şifreli bir sunum gerektirir. Yükleme modunu [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) ile doğrular ve ardından [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) aracılığıyla yerleşik özellikleri okur:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties documentProperties = presentation.getDocumentProperties();

        System.out.println("Author: " + documentProperties.getAuthor());
        System.out.println("Title: " + documentProperties.getTitle());
        System.out.println("Keywords: " + documentProperties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

Bu modda, slayt içeriği yüklenmez. Slaytlar, masterlar, düzenler, şekiller, medya ve diğer sunum nesneleri kullanılamaz. Uygulamalar, tam sunum nesne modelini gerektiren bir işlem yapmadan önce her zaman [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) kontrol etmelidir.

{{% alert color="warning" title="Warning" %}}
Genel meta veriler yazar adlarını, başlıkları, konuları, anahtar kelimeleri, şirket bilgilerini, yorumları ve özel değerleri ortaya çıkarabilir. Hassas özellikleri sunumla birlikte şifreleyin. Bunları yalnızca indeksleme, sınıflandırma, arama veya belge‑yönetim sistemlerinin şifre olmadan erişim gerektirdiği durumlarda açık bırakın.
{{% /alert %}}

## **Şifrelenmiş Bir Sunumun Özelliklerini Güncelleme**

Şifreli bir PPTX dosyası için, [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) `true` ile çağrıldıktan sonra yüklenen bir sunum, genel meta verileri okumak için tasarlanmıştır. Aspose.Slides, bu yalnızca meta veri nesnesindeki değiştirilen özellikleri kaydedemez çünkü genel özellikler şifreli sunumdaki karşılık gelen verilerle tutarlı olmalıdır. Bu nedenle güncelleme, doğru açılış şifresini ve tam bir yüklemeyi gerektirir.

Örnek, genel belge özelliklerine sahip şifreli bir PPTX sunumu ve bilinen bir açılış şifresi gerektirir. Tam sunumu [LoadOptions.setPassword](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) ile açar, genel yerleşik özellikleri günceller ve sonucu kaydeder. Ardından, şifrelemenin korunduğunu doğrulamak için [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#isEncrypted--) kullanır ve yeni değerleri doğrulamak için şifre olmadan genel meta verileri yeniden açar:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import com.aspose.slides.SaveFormat;

final String inputPath = "public-properties-encrypted.pptx";
final String outputPath = "updated-public-properties-encrypted.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation(inputPath, loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");

    presentation.save(outputPath, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(outputPath);
System.out.println("The presentation is encrypted: " + presentationInfo.isEncrypted());

LoadOptions metadataLoadOptions = new LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

Presentation metadataPresentation = new Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        System.out.println("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        System.out.println("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

Bir uygulama, sunum içeriğini çözmeye veya yüklemeye izin verilmiyorsa, şifreli bir PPTX dosyasının genel özelliklerini yalnızca‑okunur olarak ele almalıdır.

## **Yerleşik Özelliklere Erişim**

[IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) arayüzü, [getAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getAuthor--) , [getTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getTitle--) ve [getCreatedTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCreatedTime--) gibi getter metodlarıyla yerleşik meta verileri sunar. Bu örnek, mevcut bir sunumu açar ve saklanan meta verileri konsola yazdırır. Değerler giriş sunumuna bağlıdır; bazı alanlar boş olabilir.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    System.out.println("Category: " + documentProperties.getCategory());
    System.out.println("Content status: " + documentProperties.getContentStatus());
    System.out.println("Creation date: " + documentProperties.getCreatedTime());
    System.out.println("Author: " + documentProperties.getAuthor());
    System.out.println("Comments: " + documentProperties.getComments());
    System.out.println("Keywords: " + documentProperties.getKeywords());
    System.out.println("Last modified by: " + documentProperties.getLastSavedBy());
    System.out.println("Manager: " + documentProperties.getManager());
    System.out.println("Modified date: " + documentProperties.getLastSavedTime());
    System.out.println("Presentation format: " + documentProperties.getPresentationFormat());
    System.out.println("Last print date: " + documentProperties.getLastPrinted());
    System.out.println("Is shared between producers: " + documentProperties.getSharedDoc());
    System.out.println("Subject: " + documentProperties.getSubject());
    System.out.println("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

## **Yerleşik Özellikleri Değiştirme**

Yerleşik meta verileri güncellemek için, [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) tarafından döndürülen nesnedeki setter metodlarını kullanın. Bu örnek, mevcut bir sunumu açar, [setAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-), [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-), [setSubject](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-), [setComments](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-), ve [setManager](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-) metodlarını çağırır, ardından güncellenmiş sunumu [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) ile kaydeder. Kaydedilen PPTX yeni meta verileri içerir.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Köprü Temelini Yönetme**

[IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) göreceli köprüler için belge düzeyindeki temeli döndürür. Bunu değiştirmek veya temizlemek için [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) kullanın. Bu, bir sunumu ve bağlantılı dosyalarını başka bir konuma taşırken yararlıdır. Bireysel bir köprünün [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrl--) öğesinden ayrıktır: temeli değiştirmek, saklanan köprü adreslerini yeniden yazmaz veya mutlak hedefleri değiştirmez.

Örnek, `target.html` gibi bir göreceli köprü ve `https://example.org/absolute.html` gibi bir mutlak köprü içeren bir sunum gerektirir. Mevcut temeli okur, yeni bir temel adresi atar ve değeri kontrol etmek için sunumu kaydedip yeniden açar. Ardından, temeli boş bir dizeyle temizler ve ayrı bir kaydedilmiş dosyada boş değeri doğrular. Örnek temel adresini, bağlantılı dosyalarınızın konumu ile değiştirin.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    System.out.println("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    final String newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx);

    Presentation updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        System.out.println("Base preserved: " + newBase.equals(updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

        Presentation clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            System.out.println("Base cleared: " + "".equals(clearedPresentation.getDocumentProperties().getHyperlinkBase()));
        } finally {
            clearedPresentation.dispose();
        }
    } finally {
        updatedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

İki doğrulama mesajı `true` yazdırmalıdır. Temelin temizlenmesi, bireysel köprü adreslerini bozulmuş bırakmaz.

`target.pptx` için bir göreceli köprü, temel `old` klasörüne işaret ettiğinde `old/target.pptx` dosyasını açtı. Temel `new` klasörüne değiştirildikten, kaydedildikten ve sunum yeniden açıldıktan sonra aynı köprü `new/target.pptx` dosyasını açtı. Mutlak bir köprü aynı dosyayı açmaya devam etti. Sunumu taşıdıktan veya temelini değiştirdikten önce ve sonra PowerPoint'te göreceli köprülerinizi test edin.

## **Özel Sunum Özellikleri Ekleme**

Özel özellikler, karşılık gelen yerleşik bir alanı olmayan meta verileri saklar. [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) yöntemi, özellik adını kullanarak bir değer atamanıza izin verir. Bu örnek bir sunum oluşturur, iki metin değeri ve bir tam sayı sürüm değeri ekler ve sunumu [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) ile kaydeder. Mevcut bir isme değer atamak, o özelliğin değerini değiştirir.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Özel Özelliklere Erişim ve Değiştirme**

Bu örnek, özel özellikler içeren bir sunumu açar ve [getCountOfCustomProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) ile bunlar üzerinde döner. [getCustomPropertyName](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) sıfır‑tabanlı bir indeks kabul eder ve [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) tarafından kullanılan adı döndürür. Örnek, her özgün adı ve değeri yazdırır, her değeri orijinal tipine bakılmaksızın numaralı bir dizeyle değiştirir ve değişiklikleri kaydeder. Özel özellik yoksa, döngü hiçbir değişiklik yapmaz.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    for (int i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        String propertyName = documentProperties.getCustomPropertyName(i);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println("Custom property name: " + propertyName);
        System.out.println("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Canlı Örnek**

[**PowerPoint Meta Verilerini Görüntüle & Düzenle**](https://products.aspose.app/slides/metadata) çevrimiçi uygulamasını deneyerek Aspose.Slides API'sı ile belge özellikleriyle nasıl çalışılacağını görebilirsiniz:

[![PowerPoint Meta Verilerini Görüntüle & Düzenle](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **SSS**

**Bir sunumdan yerleşik bir özelliği nasıl kaldırabilirim?**

Yerleşik özellikler, sunumun ayrılmaz bir parçasıdır ve tamamen kaldırılamaz. Ancak, belirli özellik izin veriyorsa, değerlerini değiştirebilir veya boş olarak ayarlayabilirsiniz.

**Zaten mevcut bir özel özellik eklersem ne olur?**

Eğer zaten mevcut bir özel özellik eklerseniz, mevcut değeri yeni değerle üzerine yazılır. Özelliği önceden kaldırmanıza veya kontrol etmenize gerek yoktur; Aspose.Slides otomatik olarak özelliğin değerini günceller.

**Sunumu tamamen yüklemeden sunum özelliklerine erişebilir miyim?**

Evet. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) ve ardından [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) kullanarak bir [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) örneği oluşturmadan saklanan belge meta verilerini okuyabilirsiniz. Tam bir raporlama örneği ve format‑özgü sınırlamalar için [Hafif Sunum Envanteri Oluşturma](/slides/tr/java/examine-presentation/) sayfasına bakın.

**Şifreli bir sunumun genel özelliklerini açılış şifresi olmadan okuyabilir miyim?**

Evet. Sunum, [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) `false` ile çağrıldıktan sonra şifrelenmiş olmalı ve [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) `true` ile çağrıldıktan sonra yüklenmiş olmalıdır.

**Belge‑özellikleri‑sadece modunda şifreli bir PPTX dosyasını güncelleyebilir miyim?**

Hayır. Genel ve şifreli özellik verileri tutarlı olmalı, bu yüzden şifreli bir PPTX dosyasını güncellemek, doğru açılış şifresi ile tam sunumu yüklemeyi gerektirir.