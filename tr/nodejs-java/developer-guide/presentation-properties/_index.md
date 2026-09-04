---
title: JavaScript'te Sunum Özelliklerini Yönetme
linktitle: Sunum Özellikleri
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
description: "Aspose.Slides for Node.js via Java'da sunum özelliklerini yönetin ve PowerPoint ve OpenDocument dosyalarınızda aramayı, marka oluşturmayı ve iş akışını kolaylaştırın."
---
## **Giriş**

Aspose.Slides iki tür belge özelliğini destekler: **Yerleşik** ve **Özel**. Bu özellik türlerine Aspose.Slides API'si ile kolayca erişebilir ve yönetebilirsiniz.

Aspose.Slides, sunum belge özellikleriyle **[DocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/)** sınıfı aracılığıyla çalışmanıza olanak tanır. Bu sınıfın bir örneği **[Presentation.getDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#getDocumentProperties)** yöntemiyle döndürülür. Aşağıdaki örnekler, bu özelliklerin nasıl okunacağını, değiştirileceğini ve yönetileceğini gösterir.

{{% alert color="info" title="Not" %}}

**Application** ve **AppVersion** alanlarının değiştirilemeyeceğini unutmayın. Aspose.Slides her kaydetmede bu alanları yeniden yazar; bu nedenle kaydedilen bir sunum her zaman “Aspose.Slides for Node.js via Java” ve onu oluşturan kütüphanenin sürümünü rapor eder. `setNameOfApplication` yöntemine geçirilen değer, sunum yazılırken atılır.

{{% /alert %}} 

## **Sunum Özelliklerini Yönetme**

Microsoft PowerPoint, sunum dosyalarına bazı özellikler ekleme özelliği sunar. Bu belge özellikleri, belgelerle (sunum dosyaları) birlikte faydalı bilgilerin saklanmasını sağlar. Aşağıdaki iki tür belge özelliği bulunur:

- Sistem Tanımlı (Yerleşik) Özellikler
- Kullanıcı Tanımlı (Özel) Özellikler

**Yerleşik** özellikler, belge başlığı, yazar adı, belge istatistikleri gibi genel bilgileri içerir. **Özel** özellikler ise kullanıcılar tarafından **Ad/Değer** çifti şeklinde tanımlanan, hem adın hem de değerin kullanıcı tarafından belirlendiği özelliklerdir. Aspose.Slides for Node.js via Java kullanılarak, yerleşik ve özel özelliklerin değerlerine erişilip değiştirilebilir.

## **PowerPoint’te Belge Özellikleri**

Microsoft PowerPoint 2007, sunum dosyalarının belge özelliklerini yönetmeye izin verir. Tek yapmanız gereken Office simgesine tıklayıp **Prepare | Properties | Advanced Properties** menü öğesini seçmektir (aşağıda gösterildiği gibi):

|**Gelişmiş Özellikler menüsü seçimi**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

**Advanced Properties** menü öğesini seçtiğinizde, PowerPoint dosyasının belge özelliklerini yönetmenizi sağlayan bir iletişim kutusu açılır (aşağıdaki gibi):

|**Özellikler İletişim Kutusu**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Yukarıdaki **Properties Dialog** içinde **General**, **Summary**, **Statistics**, **Contents** ve **Custom** gibi birçok sekme sayfası görebilirsiniz. Bu sekmeler, PowerPoint dosyalarıyla ilgili farklı bilgi türlerini yapılandırmaya olanak tanır. **Custom** sekmesi, PowerPoint dosyalarının özel özelliklerini yönetmek için kullanılır.

### Aspose.Slides for Node.js via Java ile Belge Özellikleriyle Çalışma

Daha önce belirttiğimiz gibi Aspose.Slides for Node.js via Java, **Yerleşik** ve **Özel** olmak üzere iki tür belge özelliğini destekler. Böylece geliştiriciler, Aspose.Slides for Node.js via Java API'sı ile her iki tür özelliğe de erişebilir. Aspose.Slides for Node.js via Java, sunum dosyasıyla ilişkili belge özelliklerini temsil eden **[DocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties)** sınıfını **Presentation.DocumentProperties** özelliği aracılığıyla sunar.

Geliştiriciler, **[Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation)** nesnesinin **DocumentProperties** özelliğini kullanarak sunum dosyalarının belge özelliklerine aşağıdaki gibi ulaşabilir:

## **Şifreli Bir Sunumdan Genel Özellikleri Okuma**

Açma parolası genellikle hem sunum içeriğini hem de belge özelliklerini korur. `[ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties)` yöntemine `false` geçirilerek bir sunum şifrelenirse, belge özellikleri genel (public) kalır. Daha sonra uygulama, **[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties)** yöntemine `true` geçirerek açma parolası sağlamadan sadece genel meta verileri okuyabilir.

`document-properties-only` seçeneği, Aspose.Slides’ın neyi yükleyeceğini denetler; hiçbir şeyi şifre çözmez. Özellikler şifrelemeye dahil edilmişse, parola olmadan yükleme başarısız olur. Sunum şifrelenmemişse, seçenek yok sayılır ve tam sunum yüklenir.

Aşağıdaki örnek, **[ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded)** yöntemiyle yükleme modunu doğrular ve ardından **[Presentation.getDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#getDocumentProperties)** yöntemiyle yerleşik özellikleri okur:

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const properties = presentation.getDocumentProperties();

        console.log("Author: " + properties.getAuthor());
        console.log("Title: " + properties.getTitle());
        console.log("Keywords: " + properties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

Bu modda, slayt içeriği yüklenmez. Slaytlar, ana şablonlar, düzenler, şekiller, medya ve diğer sunum nesneleri kullanılamaz. Uygulamalar, tam sunum nesne modelini gerektiren bir işlem yapmadan önce her zaman **[ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded)** metodunu kontrol etmelidir.

{{% alert color="warning" title="Uyarı" %}}
Genel meta veriler yazar adları, başlıklar, konu, anahtar kelimeler, şirket bilgileri, yorumlar ve özel değerler gibi bilgileri ortaya çıkarabilir. Hassas özellikleri sunumla birlikte şifreleyin. Yalnızca indeksleme, sınıflandırma, arama veya belge‑yönetim sistemlerinin parola olmadan erişim gerektirdiği durumlarda genel tutun.
{{% /alert %}}

## **Şifreli Bir Sunumu Güncelleme**

Şifreli bir PPTX dosyası için belge‑özellikleri‑yalnızca modunda yüklenen bir sunum, genel meta verileri okuma amacı taşır. Aspose.Slides, bu meta veri‑yalnızca nesnesinden değiştirilen özellikleri kaydedemez; çünkü genel özelliklerin şifreli sunum içindeki karşılık gelen verilerle tutarlı kalması gerekir. Bu nedenle güncelleme, doğru açma parolası ve tam yükleme gerektirir.

Aşağıdaki örnek, **[LoadOptions.setPassword](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#setPassword)** yöntemiyle sunumu açar, genel yerleşik özellikleri günceller ve sonucu kaydeder. Ardından **[PresentationInfo.isEncrypted](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/#isEncrypted)** yöntemiyle şifrelemenin korunduğunu doğrular ve yeni değerleri kontrol etmek için parolasız genel meta verileri tekrar açar:

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
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

Uygulama sunum içeriğini şifreleyemez veya yükleyemezse, şifreli bir PPTX dosyasının genel özelliklerini yalnızca okunabilir olarak kabul etmelidir.

## **Yerleşik Özelliklere Erişim**

**[DocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties)** nesnesi tarafından sunulan bu özellikler şunları içerir: **Creator** (Yazar), **Description**, **Keywords**, **Created** (Oluşturulma Tarihi), **Modified** (Değiştirilme Tarihi), **Printed** (Son Yazdırma Tarihi), **LastModifiedBy**, **SharedDoc** (Farklı üreticiler arasında paylaşılıyor mu?), **PresentationFormat**, **Subject** ve **Title**.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Sunumu temsil eden Presentation sınıfını örnekleyin
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Presentation ile ilişkili IDocumentProperties nesnesine bir referans oluştur
    var dp = pres.getDocumentProperties();
    // Yerleşik özellikleri görüntüle
    console.log("Category : " + dp.getCategory());
    console.log("Current Status : " + dp.getContentStatus());
    console.log("Creation Date : " + dp.getCreatedTime());
    console.log("Author : " + dp.getAuthor());
    console.log("Description : " + dp.getComments());
    console.log("KeyWords : " + dp.getKeywords());
    console.log("Last Modified By : " + dp.getLastSavedBy());
    console.log("Supervisor : " + dp.getManager());
    console.log("Modified Date : " + dp.getLastSavedTime());
    console.log("Presentation Format : " + dp.getPresentationFormat());
    console.log("Last Print Date : " + dp.getLastPrinted());
    console.log("Is Shared between producers : " + dp.getSharedDoc());
    console.log("Subject : " + dp.getSubject());
    console.log("Title : " + dp.getTitle());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Yerleşik Özellikleri Değiştirme**

Sunum dosyalarının yerleşik özelliklerini değiştirmek, onlara erişmek kadar basittir. İstediğiniz özelliğe bir dize değeri atayabilir ve özellik değeri güncellenir. Aşağıdaki örnekte, Aspose.Slides for Node.js via Java kullanarak sunum dosyasının yerleşik belge özelliklerini nasıl değiştirebileceğimiz gösterilmiştir.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Presentation ile ilişkili IDocumentProperties nesnesine bir referans oluştur
    var dp = pres.getDocumentProperties();
    // Yerleşik özellikleri ayarla
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // Sunumunuzu bir dosyaya kaydedin
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Bu örnek, aşağıda gösterildiği gibi değiştirilen yerleşik özellikleri sunar:

|**Değiştirilmiş yerleşik belge özellikleri**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Özel Belge Özellikleri Ekleme**

Aspose.Slides for Node.js via Java, geliştiricilerin sunum Belge özellikleri için özel değerler eklemesine de izin verir. Aşağıdaki örnek, bir sunuma özel özelliklerin nasıl ayarlanacağını gösterir.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // Belge Özelliklerini Alma
    var dProps = pres.getDocumentProperties();
    // Özel Özellikler Ekleniyor
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // Belirli bir indeksdeki özellik adını alma
    var getPropertyName = dProps.getCustomPropertyName(2);
    // Seçilen özelliği kaldırma
    dProps.removeCustomProperty(getPropertyName);
    // Sunumu kaydetme
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**Eklenen Özel Belge Özellikleri**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Özel Özelliklere Erişim ve Değiştirme**

Aspose.Slides for Node.js via Java, geliştiricilerin özel özellik değerlerine erişmesine de olanak tanır. Aşağıdaki örnek, bir sunum için tüm bu özel özelliklere nasıl erişileceğini ve değiştirileceğini gösterir.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Presentation ile ilişkili DocumentProperties nesnesine bir referans oluştur
    var dp = pres.getDocumentProperties();
    // Özel özelliklere eriş ve değiştir
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Özel özelliklerin adlarını ve değerlerini görüntüle
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // Özel özelliklerin değerlerini değiştir
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // Sunumunuzu bir dosyaya kaydedin
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Bu örnek, **[PPTX](https://docs.fileformat.com/presentation/pptx/)** sunumunun özel özelliklerini değiştirir. Aşağıdaki görseller, değişiklik öncesi ve sonrası özel özellikleri gösterir:

|**Değişiklik Öncesi Özel Özellikler**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Değişiklik Sonrası Özel Özellikler**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Gelişmiş Belge Özellikleri**

{{% alert color="info" title="Not" %}}

Yeni yöntemler **[ReadDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--)**, **[UpdateDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-)** ve **[WriteBindedPresentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-)**, **[PresentationInfo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PresentationInfo)** sınıfına eklenmiştir; **[DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-)** özelliğinin ayarlayıcı mantığı değiştirilmiştir.

{{% /alert %}} 

Yeni eklenen iki yöntem **[ReadDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--)** ve **[UpdateDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-)**, **[PresentationInfo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PresentationInfo)** sınıfına eklenmiştir. Bu yöntemler belge özelliklerine hızlı erişim sağlar ve tüm sunumu yüklemeden özellikleri değiştirme ve güncelleme imkanı sunar.

Tipik senaryo: özellikleri yükle, bir değeri değiştir ve belgeyi güncelle; aşağıdaki şekilde uygulanabilir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// sunumun bilgilerini oku
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// mevcut özellikleri al
var props = info.readDocumentProperties();
// Yazar ve Başlık alanlarının yeni değerlerini ayarla
props.setAuthor("New Author");
props.setTitle("New Title");
// sunumu yeni değerlerle güncelle
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Belirli bir sunumun özelliklerini şablon olarak kullanıp diğer sunumlardaki özellikleri güncellemenin başka bir yolu da vardır:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("template.pptx");
var template = info.readDocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Sıfırdan yeni bir şablon oluşturulabilir ve ardından birden fazla sunumu güncellemek için kullanılabilir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var template = new aspose.slides.DocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Düzeltme Dili Ayarlama**

Aspose.Slides, PowerPoint belgesi için düzeltme dilini ayarlamanıza olanak tanıyan **LanguageId** özelliğini (**PortionFormat** sınıfı tarafından sunulur) sağlar. Düzeltme dili, PowerPoint’te yazım ve dil bilgisi denetiminin yapıldığı dildir.

Bu JavaScript kodu, bir PowerPoint için düzeltme dilinin nasıl ayarlanacağını gösterir: xxx Why is LanguageId missing from JavaScript PortionFormat class?

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();
    var newPortion = new aspose.slides.Portion();
    var font = new aspose.slides.FontData("SimSun");
    var portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);
    portionFormat.setLanguageId("zh-CN");// düzeltme dilinin kimliğini ayarla
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Varsayılan Dil Ayarlama**

Bu JavaScript kodu, bir PowerPoint sunumunun tümü için varsayılan dilin nasıl ayarlanacağını gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // Metin içeren yeni bir dikdörtgen şekil ekler
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // İlk parçanın dilini kontrol eder
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Canlı Örnek**

Belge özellikleriyle Aspose.Slides API üzerinden nasıl çalışılacağını görmek için **[Aspose.Slides Metadata](https://products.aspose.app/slides/tr/metadata)** çevrimiçi uygulamasını deneyin:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/tr/metadata)

## **SSS**

**Bir sunumdan yerleşik bir özelliği nasıl kaldırabilirim?**

Yerleşik özellikler sunumun ayrılmaz bir parçasıdır ve tamamen kaldırılamaz. Ancak, belirli özellik izin veriyorsa değerlerini değiştirebilir veya boş bir değere ayarlayabilirsiniz.

**Zaten var olan bir özel özelliği eklersem ne olur?**

Zaten var olan bir özel özellik eklenirse, mevcut değeri yeni değerle üzerine yazılır. Özelliği önceden kaldırmanıza veya kontrol etmenize gerek yoktur; Aspose.Slides otomatik olarak özelliğin değerini günceller.

**Sunumu tamamen yüklemeden sunum özelliklerine erişebilir miyim?**

Evet. **[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/)** metodunu ardından **[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/)** metodunu kullanarak bir **[Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/)** örneği oluşturmadığınız halde saklanan belge meta verilerini okuyabilirsiniz. Tam raporlama örneği ve format‑spesifik sınırlamalar için **[Build a Lightweight Presentation Inventory](/slides/tr/nodejs-java/examine-presentation/)** sayfasına bakın.

**Şifreli bir sunumun genel özelliklerini, açma parolası olmadan okuyabilir miyim?**

Evet. Belge‑özelliği şifrelemesi, sunum şifrelenmeden önce devre dışı bırakılmış olmalı ve sunum belge‑özellikleri‑yalnızca modunda yüklenmiş olmalıdır.

**Şifreli bir PPTX dosyasını belge‑özellikleri‑yalnızca modunda güncelleyebilir miyim?**

Hayır. Genel ve şifreli özellik verileri tutarlı olmalıdır; bu yüzden şifreli bir PPTX dosyasını güncellemek, doğru açma parolasıyla tam sunumu yüklemeyi gerektirir.