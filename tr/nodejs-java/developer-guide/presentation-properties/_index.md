---
title: "JavaScript'te Sunum Özelliklerini Yönet"
linktitle: "Sunum Özellikleri"
type: docs
weight: 70
url: /tr/nodejs-java/presentation-properties/
keywords:
- PowerPoint özellikleri
- sunum özellikleri
- belge özellikleri
- yerleşik özellikler
- özel özellikler
- gelişmiş özellikler
- özellikleri yönet
- özellikleri değiştir
- belge meta verileri
- meta verileri düzenle
- düzeltme dili
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java'da sunum özelliklerini yönetin ve PowerPoint ve OpenDocument dosyalarınızda aramayı, markalamayı ve iş akışını kolaylaştırın."
---
## **Giriş**

Aspose.Slides for Node.js via Java **yerleşik** ve **özel** belge özelliklerini destekler. Bu özellikleri yazar, başlık ve kullanıcı tanımlı değerler gibi sunum meta verilerini okumak ve güncellemek için kullanın.

Aspose.Slides, sunum belge özellikleriyle [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) sınıfı aracılığıyla çalışmanıza olanak tanır. Bu sınıfın bir örneği [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) tarafından döndürülür. Aşağıdaki örnekler bu özellikleri nasıl okuyacağınızı, değiştireceğinizi ve yöneteceğinizi gösterir.

{{% alert color="info" title="Note" %}}
Aspose.Slides, sunumları kaydederken uygulama ve üretici meta verilerini yönetir; bu alanlar çıktıyı oluşturan yazılımı tanımlar.
{{% /alert %}}

## **Sunum Özelliklerini Yönet**

Belge özellikleri, sunum içeriğiyle birlikte tanımlayıcı bilgiler depolar. İki kategoriye ayrılırlar:

- **Yerleşik özellikler** başlık, yazar ve belge istatistikleri gibi standart meta verileri içerir.
- **Özel özellikler** kullanıcı tanımlı ad/değer çiftlerini depolar.

Aspose.Slides for Node.js via Java, her iki kategoriye de erişim sağlar. PowerPoint'ta belge meta verilerini incelemek için **File → Info → Properties → Advanced Properties**'i seçin. İletişim kutusu bilgileri **Summary**, **Statistics**, **Contents** ve **Custom** gibi sekmelere gruplar. Kullanıcı tanımlı özellikleri yönetmek için **Custom** sekmesini kullanın.

## **Şifrelenmiş Bir Sunumdan Genel Özellikleri Okuma**

Açma şifresi genellikle hem sunum içeriğini hem de belge özelliklerini korur. Bir sunum, [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) metodunu `false` ile çağırdıktan sonra şifrelenirse, belge özellikleri genel olarak kalır. Bir uygulama daha sonra [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) metodunu `true` ile çağırarak açma şifresini vermeden genel meta verileri okuyabilir.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) Aspose.Slides'in neyi yükleyeceğini kontrol eder; hiçbir şeyi şifre çözmez. Özellikler şifreleme içine dahil edilmişse, şifre olmadan yükleme başarısız olur. Sunum şifrelenmemişse, seçenek yoksayılır ve tam sunum yüklenir.

Örnek, belge özellikleri genel olarak bırakılmış şifreli bir sunum gerektirir. Yükleme modunu [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) aracılığıyla doğrular ve ardından [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) üzerinden yerleşik özellikleri okur:

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const documentProperties = presentation.getDocumentProperties();

        console.log("Author: " + documentProperties.getAuthor());
        console.log("Title: " + documentProperties.getTitle());
        console.log("Keywords: " + documentProperties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

Bu modda, slayt içeriği yüklenmez. Slaytlar, masterlar, düzenler, şekiller, medya ve diğer sunum nesneleri erişilemez. Uygulamalar, tam sunum nesne modelini gerektiren bir işlem yapmadan önce her zaman [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) kontrol etmelidir.

{{% alert color="warning" title="Warning" %}}
Genel meta veriler, yazar adları, başlıklar, konular, anahtar sözcükler, şirket bilgileri, yorumlar ve özel değerleri ifşa edebilir. Hassas özellikleri sunumla birlikte şifreleyin. Yalnızca indeksleme, sınıflandırma, arama veya belge‑yönetim sistemlerinin şifre olmadan erişim gereksinimi olduğunda genel olarak bırakın.
{{% /alert %}}

## **Şifrelenmiş Bir Sunumun Özelliklerini Güncelleme**

Şifreli bir PPTX dosyası için, [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) `true` ile çağrıldıktan sonra yüklenen bir sunum, yalnızca genel meta verileri okumak amacıyla yüklenir. Aspose.Slides, bu sadece‑meta‑veri nesnesindeki değiştirilen özellikleri kaydedemez çünkü genel özelliklerin, şifreli sunum içindeki ilgili verilerle tutarlı kalması gerekir. Bu nedenle güncelleme doğru açma şifresini ve tam bir yüklemeyi gerektirir.

Örnek, genel belge özelliklerine sahip şifreli bir PPTX sunumu ve bilinen bir açma şifresi gerektirir. Tam sunumu [LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setPassword) ile açar, genel yerleşik özellikleri günceller ve sonucu kaydeder. Ardından [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#isEncrypted) kullanarak şifrelemenin korunduğunu doğrular ve yeni değerleri kontrol etmek için genel meta verileri şifresiz olarak yeniden açar:

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");
    
    presentation.save(outputPath, slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(outputPath);
console.log("The presentation is encrypted: " + presentationInfo.isEncrypted());

const metadataLoadOptions = new slides.LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

const metadataPresentation = new slides.Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        console.log("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        console.log("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

Bir uygulama sunum içeriğini şifre çözmeye veya yüklemeye izin verilmiyorsa, şifreli bir PPTX dosyasının genel özelliklerini yalnızca‑okunur olarak ele almalıdır.

## **Yerleşik Özelliklere Erişim**

[DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) sınıfı, [getAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getAuthor), [getTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getTitle) ve [getCreatedTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCreatedTime) gibi getter metodları aracılığıyla yerleşik meta verileri ortaya çıkarır. Bu örnek mevcut bir sunumu açar ve saklanan meta verilerini konsola yazdırır. Değerler giriş sunumuna bağlıdır; bazı alanlar boş olabilir.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    console.log("Category: " + documentProperties.getCategory());
    console.log("Content status: " + documentProperties.getContentStatus());
    console.log("Creation date: " + documentProperties.getCreatedTime());
    console.log("Author: " + documentProperties.getAuthor());
    console.log("Comments: " + documentProperties.getComments());
    console.log("Keywords: " + documentProperties.getKeywords());
    console.log("Last modified by: " + documentProperties.getLastSavedBy());
    console.log("Manager: " + documentProperties.getManager());
    console.log("Modified date: " + documentProperties.getLastSavedTime());
    console.log("Presentation format: " + documentProperties.getPresentationFormat());
    console.log("Last print date: " + documentProperties.getLastPrinted());
    console.log("Is shared between producers: " + documentProperties.getSharedDoc());
    console.log("Subject: " + documentProperties.getSubject());
    console.log("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

## **Yerleşik Özellikleri Değiştir**

Yerleşik meta verileri güncellemek için, [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) tarafından döndürülen nesnedeki setter metodlarını kullanın. Bu örnek mevcut bir sunumu açar, [setAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setAuthor), [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setTitle), [setSubject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setSubject), [setComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setComments) ve [setManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setManager) metodlarını çağırır, ardından güncellenen sunumu [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save) ile kaydeder. Kaydedilen PPTX yeni meta verileri içerir.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ModifyBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Node.js via Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hipermetin Temelini Yönet**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getHyperlinkBase) göreli hipermetinler için belge‑düzeyinde bir temel döndürür. [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setHyperlinkBase) kullanarak bunu değiştirebilir veya temizleyebilirsiniz. Bu, bir sunumu ve bağlı dosyalarını başka bir konuma taşırken faydalıdır. Bu, bireysel bir hipermetnin [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) metodundan ayrıktır: temelin değiştirilmesi, saklanan link adreslerini yeniden yazmaz veya mutlak hedefleri değiştirmez.

Örnek, `target.html` gibi bir göreli link ve `https://example.org/absolute.html` gibi bir mutlak link içeren bir sunum gerektirir. Mevcut temeli okur, yeni bir temel adresi atar ve değeri kontrol etmek için sunumu kaydedip yeniden açar. Ardından temeli boş bir dizeyle temizler ve ayrı bir kaydedilmiş dosyada boş değeri doğrular. Örnek temel adresini bağlı dosyalarınızın konumuyla değiştirin.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("hyperlinks.pptx");
try {
    console.log("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    const newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", slides.SaveFormat.Pptx);

    const updatedPresentation = new slides.Presentation("hyperlinks-updated.pptx");
    try {
        console.log("Base preserved: " + (newBase === updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", slides.SaveFormat.Pptx);

        const clearedPresentation = new slides.Presentation("hyperlinks-cleared.pptx");
        try {
            console.log("Base cleared: " + ("" === clearedPresentation.getDocumentProperties().getHyperlinkBase()));
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

İki doğrulama mesajı `true` yazdırmalıdır. Temelin temizlenmesi, bireysel hipermetin adreslerini aynı tutar.

`target.pptx` göreli bir link, temel `old` klasörüne işaret ettiğinde `old/target.pptx` dosyasını açtı. Temel `new` klasörüne değiştirildikten, kaydedildikten ve sunum yeniden açıldıktan sonra aynı link `new/target.pptx` dosyasını açtı. Mutlak bir link aynı dosyayı açmaya devam etti. Sunumu taşıdıktan veya temelini değiştirdikten önce ve sonra PowerPoint'te göreli linklerinizi test edin.

## **Özel Sunum Özellikleri Ekle**

Özel özellikler, karşılığı olan yerleşik alanı olmayan meta verileri depolar. [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) metodu, özellik adını kullanarak bir değer atamanızı sağlar. Bu örnek bir sunum oluşturur, iki metin değeri ve bir tam sayı sürüm değeri ekler ve sunumu [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save) ile kaydeder. Mevcut bir isme değer atamak, o özelliğin değerini değiştirir.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Özel Özelliklere Eriş ve Değiştir**

Bu örnek, özel özellikler içeren bir sunumu açar ve [getCountOfCustomProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCountOfCustomProperties) kullanarak bunlar üzerinde döner. [getCustomPropertyName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCustomPropertyName) sıfır tabanlı bir dizin alır ve [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) tarafından kullanılan adı döndürür. Örnek, her orijinal adı ve değeri yazdırır, her değeri özgün tipine bakılmaksızın numaralı bir dizeyle değiştirir ve değişiklikleri kaydeder. Eğer özel özellik yoksa, döngü hiçbir değişiklik yapmaz.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessAndModifyProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    for (let i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        const propertyName = documentProperties.getCustomPropertyName(i);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log("Custom property name: " + propertyName);
        console.log("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Canlı Örnek**

[**PowerPoint Meta Verilerini Görüntüle ve Düzenle**](https://products.aspose.app/slides/metadata) çevrimiçi uygulamasını deneyin ve Aspose.Slides API'siyle belge özellikleriyle nasıl çalışılacağını görün:

[![PowerPoint Meta Verilerini Görüntüle ve Düzenle](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **SSS**

**Sunumdan yerleşik bir özelliği nasıl kaldırabilirim?**

Yerleşik özellikler, sunumun ayrılmaz bir parçasıdır ve tamamen kaldırılamaz. Ancak, belirli özelliğin izin verdiği durumlarda değerlerini değiştirebilir veya boş olarak ayarlayabilirsiniz.

**Zaten var olan bir özel özelliği eklersem ne olur?**

Zaten var olan bir özel özellik eklenirse, mevcut değeri yeni değerle üzerine yazılır. Özelliği önceden kaldırmanıza veya kontrol etmenize gerek yoktur; Aspose.Slides otomatik olarak özelliğin değerini günceller.

**Sunum özelliklerine, sunumu tamamen yüklemeden erişebilir miyim?**

Evet. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationFactory#getPresentationInfo) kullanın ve ardından [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties) ile bir [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) örneği oluşturmadan saklanan belge meta verilerini okuyun. Tam bir raporlama örneği ve format‑spesifik sınırlamalar için [Build a Lightweight Presentation Inventory](/slides/tr/nodejs-java/examine-presentation/) sayfasına bakın.

**Şifreli bir sunumun genel özelliklerini açma şifresi olmadan okuyabilir miyim?**

Evet. Sunum, [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) `false` ile çağrıldıktan sonra şifrelenmiş olmalı ve [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) `true` ile çağrıldıktan sonra yüklenmiş olmalıdır.

**Belge‑özellikleri‑sadece modunda şifreli bir PPTX dosyasını güncelleyebilir miyim?**

Hayır. Genel ve şifreli özellik verileri tutarlı olmalıdır, bu nedenle şifreli bir PPTX dosyasını güncellemek, doğru açma şifresiyle tam sunumu yüklemeyi gerektirir.