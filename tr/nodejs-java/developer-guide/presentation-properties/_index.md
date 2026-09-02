---
title: JavaScript'te Sunum Özelliklerini Yönet
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
- özellikleri yön

- özellikleri değiştir
- belge üst verileri
- üst verileri düzenle
- denetleme dili
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java'da sunum özelliklerini yönetin ve PowerPoint ve OpenDocument dosyalarınızda arama, markalaşma ve iş akışını kolaylaştırın."
---
## **Giriş**

Aspose.Slides iki tür belge özelliğini destekler: **Yerleşik** ve **Özel**. Bu özellik tiplerine Aspose.Slides API'si kullanılarak kolayca erişilebilir ve yönetilebilir.

Aspose.Slides, [DocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/) sınıfı aracılığıyla sunum belge özellikleriyle çalışmanıza olanak tanır. Bu sınıfın bir örneği, [Presentation.getDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#getDocumentProperties) yöntemi tarafından döndürülür. Aşağıdaki örnekler, bu özelliklerin nasıl okunacağını, değiştirileceğini ve yönetileceğini gösterir.

{{% alert color="info" title="Not" %}}
Lütfen **Application** ve **AppVersion** alanlarının değiştirilemeyeceğini unutmayın. Aspose.Slides her kaydetmede bu alanları yeniden yazar, bu yüzden kaydedilen bir sunum her zaman "Aspose.Slides for Node.js via Java" ve onu üreten kütüphane sürümünü rapor eder. `setNameOfApplication` metoduna geçirilen herhangi bir değer, sunum yazıldığında göz ardı edilir.
{{% /alert %}}

## **Sunum Özelliklerini Yönet**

Microsoft PowerPoint, sunum dosyalarına bazı özellikler ekleme özelliği sunar. Bu belge özellikleri, belgelerle (sunum dosyalarıyla) birlikte faydalı bilgiler depolanmasını sağlar. İki tür belge özelliği vardır:

- Sistem Tanımlı (Yerleşik) Özellikler
- Kullanıcı Tanımlı (Özel) Özellikler

**Yerleşik** özellikler, belge başlığı, yazar adı, belge istatistikleri gibi genel bilgileri içerir. **Özel** özellikler ise kullanıcı tarafından **Ad/Değer** çiftleri olarak tanımlanan, hem ad hem de değerin kullanıcı tarafından belirlendiği özelliklerdir. Aspose.Slides for Node.js via Java kullanarak, geliştiriciler yerleşik ve özel özelliklerin değerlerine erişebilir ve bunları değiştirebilir.

## **PowerPoint’te Belge Özellikleri**

Microsoft PowerPoint 2007, sunum dosyalarının belge özelliklerini yönetmeye olanak tanır. Tek yapmanız gereken Office simgesine tıklamak ve ardından **Prepare | Properties | Advanced Properties** menü öğesini seçmektir, aşağıda gösterildiği gibi:

|**Gelişmiş Özellikler menü öğesini seçme**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

**Advanced Properties** menü öğesini seçtikten sonra, aşağıdaki şekilde PowerPoint dosyasının belge özelliklerini yönetmenize izin veren bir iletişim kutusu açılır:

|**Özellikler İletişim Kutusu**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Yukarıdaki **Özellikler İletişim Kutusu**'nda **Genel**, **Özet**, **İstatistikler**, **İçindekiler** ve **Özel** gibi birçok sekme sayfası gördüğünüzü fark edeceksiniz. Bu sekme sayfaları, PowerPoint dosyalarıyla ilgili çeşitli bilgileri yapılandırmaya izin verir. **Özel** sekmesi, PowerPoint dosyalarının özel özelliklerini yönetmek için kullanılır.

Aspose.Slides for Node.js via Java Kullanarak Belge Özellikleriyle Çalışma

Daha önce belirttiğimiz gibi Aspose.Slides for Node.js via Java, **Yerleşik** ve **Özel** olmak üzere iki tür belge özelliğini destekler. Bu sayede geliştiriciler Aspose.Slides for Node.js via Java API'si ile her iki tür özelliğe de erişebilir. Aspose.Slides for Node.js via Java, **Presentation.DocumentProperties** özelliği aracılığıyla bir sunum dosyasıyla ilişkili belge özelliklerini temsil eden bir [DocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties) sınıfı sağlar.

Geliştiriciler, aşağıda açıklandığı gibi sunum dosyalarının belge özelliklerine erişmek için [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) nesnesi tarafından sunulan **DocumentProperties** özelliğini kullanabilir:

## **Yerleşik Özelliklere Erişme**

[DocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties) nesnesi tarafından sunulan bu özellikler şunları içerir: **Creator** (Yazar), **Description**, **Keywords**, **Created** (Oluşturulma Tarihi), **Modified** (Değiştirilme Tarihi), **Printed** (Son Yazdırma Tarihi), **LastModifiedBy**, **SharedDoc** (Farklı üreticiler arasında paylaşılıyor mu?), **PresentationFormat**, **Subject** ve **Title**.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Sunumu temsil eden Presentation sınıfını örnekle
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Presentation ile ilişkili IDocumentProperties nesnesine bir referans oluştur
    var dp = pres.getDocumentProperties();
    // Yerleşik özellikleri göster
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

Sunum dosyalarının yerleşik özelliklerini değiştirmek, onları okumak kadar kolaydır. İstediğiniz herhangi bir özelliğe bir dize değeri atayabilir ve özellik değeri değiştirilecektir. Aşağıdaki örnekte, Aspose.Slides for Node.js via Java kullanarak sunum dosyasının yerleşik belge özelliklerini nasıl değiştirebileceğimizi gösterdik.

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

|**Değişiklikten Sonra Yerleşik Belge Özellikleri**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Özel Belge Özellikleri Ekleme**

Aspose.Slides for Node.js via Java, geliştiricilerin sunum Belge özellikleri için özel değerler eklemesine de izin verir. Aşağıdaki örnek, bir sunum için özel özelliklerin nasıl ayarlanacağını gösterir.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // Belge Özelliklerini Alıyor
    var dProps = pres.getDocumentProperties();
    // Özel Özellikler Ekleniyor
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // Belirli bir indeksteki özellik adını alıyor
    var getPropertyName = dProps.getCustomPropertyName(2);
    // Seçilen özellik kaldırılıyor
    dProps.removeCustomProperty(getPropertyName);
    // Sunumu kaydediyor
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**Eklenmiş Özel Belge Özellikleri**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Özel Özelliklere Erişme ve Değiştirme**

Aspose.Slides for Node.js via Java, geliştiricilerin özel özelliklerin değerlerine erişmesine de olanak tanır. Aşağıdaki örnek, bir sunum için bu özel özelliklerin tümüne nasıl erişilip değiştirilebileceğini gösterir.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Presentation ile ilişkili DocumentProperties nesnesine bir referans oluştur
    var dp = pres.getDocumentProperties();
    // Özel özelliklere eriş ve değiştir
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Özel özelliklerin adlarını ve değerlerini göster
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

Bu örnek, [PPTX](https://docs.fileformat.com/presentation/pptx/) sunumunun özel özelliklerini değiştirir. Aşağıdaki şekiller, değişiklik öncesi ve sonrası sunum özel özelliklerini gösterir:

|**Değişiklik Öncesi Özel Özellikler**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Değişiklik Sonrası Özel Özellikler**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Gelişmiş Belge Özellikleri**

{{% alert color="info" title="Not" %}}
Yeni yöntemler [ReadDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), ve [WriteBindedPresentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) [PresentationInfo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PresentationInfo) sınıfına eklenmiştir; [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) özellik ayarlayıcısının mantığı değiştirilmiştir.
{{% /alert %}}

Yeni eklenen iki yöntem [ReadDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) ve [UpdateDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) [PresentationInfo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PresentationInfo) sınıfına eklenmiştir. Bu yöntemler, belge özelliklerine hızlı erişim sağlar ve tüm bir sunumu yüklemeden özellikleri değiştirmeye ve güncellemeye olanak tanır.

Tipik senaryo, özellikleri yüklemek, bazı değerleri değiştirmek ve belgeyi güncellemek aşağıdaki şekilde uygulanabilir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// sunumun bilgilerini oku
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
var props = info.readDocumentProperties();
props.setAuthor("New Author");
props.setTitle("New Title");
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Belirli bir sunumun özelliklerini şablon olarak kullanarak diğer sunumlardaki özellikleri güncellemenin başka bir yolu da vardır:

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

Sıfırdan yeni bir şablon oluşturulabilir ve ardından birden çok sunumu güncellemek için kullanılabilir:

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

## **Denetleme Dilini Ayarlama**

Aspose.Slides, PowerPoint belgesinin denetleme dilini ayarlamanıza olanak tanıyan LanguageId özelliğini (PortionFormat sınıfı tarafından sunulur) sağlar. Denetleme dili, PowerPoint'te yazım ve dilbilgisi denetiminin yapılacağı dildir.

Bu JavaScript kodu, PowerPoint için denetleme dilinin nasıl ayarlanacağını gösterir: xxx JavaScript PortionFormat sınıfında LanguageId neden yok?

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
    portionFormat.setLanguageId("zh-CN");// denetleme dilinin kimliğini ayarla
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Varsayılan Dili Ayarlama**

Bu JavaScript kodu, tüm bir PowerPoint sunumu için varsayılan dilin nasıl ayarlanacağını gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // Yeni bir dikdörtgen şekli ve metin ekler
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // İlk bölümün dilini kontrol eder
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Canlı Örnek**

Belge özellikleriyle Aspose.Slides API'si üzerinden nasıl çalışılacağını görmek için çevrimiçi uygulama **[Aspose.Slides Metadata](https://products.aspose.app/slides/tr/metadata)** deneyin:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/tr/metadata)

## **SSS**

**Yerleşik bir özelliği bir sunumdan nasıl kaldırabilirim?**

Yerleşik özellikler sunumun ayrılmaz bir parçasıdır ve tamamen kaldırılamaz. Ancak, belirli bir özellik izin veriyorsa değerlerini değiştirebilir veya boş bırakabilirsiniz.

**Zaten var olan bir özel özellik eklersem ne olur?**

Zaten var olan bir özel özellik eklerseniz, mevcut değeri yeni değerle üzerine yazılır. Özelliği önceden kaldırmanıza veya kontrol etmenize gerek yoktur; Aspose.Slides özelliğin değerini otomatik olarak günceller.

**Sunum özelliklerine sunumu tamamen yüklemeden erişebilir miyim?**

Evet. Önce [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) metodunu, ardından [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) metodunu kullanarak bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) örneği oluşturmadan saklanan belge üst verilerini okuyabilirsiniz. Tam bir raporlama örneği ve format‑spesifik sınırlamalar için [Build a Lightweight Presentation Inventory](/slides/tr/nodejs-java/examine-presentation/) bölümüne bakın.