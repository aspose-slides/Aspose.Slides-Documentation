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
  - belge üstverileri
  - üstverileri düzenle
  - düzeltme dili
  - varsayılan dil
  - PowerPoint
  - OpenDocument
  - sunum
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Aspose.Slides for Node.js via Java'da sunum özelliklerini yönetin ve PowerPoint ile OpenDocument dosyalarınızda aramayı, markalamayı ve iş akışını kolaylaştırın."
---
## **Giriş**

Aspose.Slides, belgelerin iki tür özelliğini destekler: **Yerleşik** ve **Özel**. Bu iki özellik türüne Aspose.Slides API kullanılarak kolayca erişilebilir ve yönetilebilir.

Aspose.Slides, sunum belge özellikleriyle [DocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/) sınıfı aracılığıyla çalışmanıza olanak tanır. Bu sınıfın bir örneği, [Presentation.getDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#getDocumentProperties) yöntemiyle döndürülür. Aşağıdaki örnekler, bu özelliklerin nasıl okunacağını, değiştirileceğini ve yönetileceğini gösterir.

{{% alert color="primary" %}} 
Lütfen **Application** ve **Producer** alanlarına değer atayamayacağınızı unutmayın; çünkü Aspose Ltd. ve Aspose.Slides for Node.js via Java x.x.x bu alanlarda görüntülenecektir.
{{% /alert %}} 

## **Sunum Özelliklerini Yönetme**

Microsoft PowerPoint, sunum dosyalarına bazı özellikler ekleme özelliği sunar. Bu belge özellikleri, belgeler (sunum dosyaları) ile birlikte bazı faydalı bilgilerin saklanmasını sağlar. Aşağıdaki iki tür belge özelliği vardır:

- Sistem Tanımlı (Yerleşik) Özellikler
- Kullanıcı Tanımlı (Özel) Özellikler

**Yerleşik** özellikler, belge başlığı, yazar adı, belge istatistikleri vb. gibi genel belge bilgilerini içerir. **Özel** özellikler ise kullanıcılar tarafından **Ad/Değer** çifti olarak tanımlanan, hem adın hem de değerin kullanıcı tarafından belirlendiği özelliklerdir. Aspose.Slides for Node.js via Java kullanarak, geliştiriciler yerleşik özelliklerin yanı sıra özel özelliklerin değerlerine de erişebilir ve bunları değiştirebilir.

## **PowerPoint'te Belge Özellikleri**

Microsoft PowerPoint 2007, sunum dosyalarının belge özelliklerini yönetmeye olanak tanır. Tek yapmanız gereken, Office simgesine tıklamak ve ardından Microsoft PowerPoint 2007'deki **Prepare | Properties | Advanced Properties** menü öğesini aşağıdaki gibi seçmektir:

|**Gelişmiş Özellikler menü öğesini seçme**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

**Advanced Properties** menü öğesini seçtikten sonra, aşağıdaki şekilde gösterilen bir iletişim kutusu açılır ve PowerPoint dosyasının belge özelliklerini yönetmenize izin verir:

|**Özellikler İletişim Kutusu**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Yukarıdaki **Özellikler İletişim Kutusu**'nda, **General**, **Summary**, **Statistics**, **Contents** ve **Custom** gibi birçok sekme sayfası gördüğünüz gibi. Bu sekme sayfaları, PowerPoint dosyalarıyla ilgili çeşitli bilgi türlerini yapılandırmaya izin verir. **Custom** sekmesi, PowerPoint dosyalarının özel özelliklerini yönetmek için kullanılır.

### Aspose.Slides for Node.js via Java Kullanarak Belge Özellikleriyle Çalışma

İlk başta belirttiğimiz gibi, Aspose.Slides for Node.js via Java, **Yerleşik** ve **Özel** olmak üzere iki tür belge özelliğini destekler. Bu sayede geliştiriciler, Aspose.Slides for Node.js via Java API'sini kullanarak her iki özelliğe de erişebilir. Aspose.Slides for Node.js via Java, bir sunum dosyasıyla ilişkili belge özelliklerini **Presentation.DocumentProperties** özelliği aracılığıyla temsil eden [DocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties) sınıfını sağlar.

Geliştiriciler, [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) nesnesi tarafından sunulan **DocumentProperties** özelliğini kullanarak, aşağıdaki gibi sunum dosyalarının belge özelliklerine erişebilirler:

## **Yerleşik Özelliklere Erişim**

[DocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties) nesnesi tarafından sunulan bu özellikler şunlardır: **Creator** (Yazar), **Description**, **Keywords**, **Created** (Oluşturma Tarihi), **Modified** (Değiştirme Tarihi), **Printed** (Son Yazdırma Tarihi), **LastModifiedBy**, **SharedDoc** (Farklı üreticiler arasında paylaşılıyor mu?), **PresentationFormat**, **Subject** ve **Title**

```javascript
// Sunumu temsil eden Presentation sınıfını örnekleyin
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Presentation ile ilişkili IDocumentProperties nesnesine bir referans oluşturun
    var dp = pres.getDocumentProperties();
    // Yerleşik özellikleri gösterin
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

Sunum dosyalarının yerleşik özelliklerini değiştirmek, onlara erişmek kadar kolaydır. İstediğiniz herhangi bir özelliğe bir dize değeri atayabilir ve özellik değeri değişir. Aşağıdaki örnekte, Aspose.Slides for Node.js via Java kullanarak sunum dosyasının yerleşik belge özelliklerini nasıl değiştirebileceğimizi gösterdik.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Presentation ile ilişkili IDocumentProperties nesnesine bir referans oluşturun
    var dp = pres.getDocumentProperties();
    // Yerleşik özellikleri ayarlayın
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

Bu örnek, aşağıdaki gibi gösterilen yerleşik özellikleri değiştirir:

|**Değişiklikten Sonra Yerleşik belge özellikleri**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Özel Belge Özellikleri Ekleme**

Aspose.Slides for Node.js via Java, geliştiricilerin sunum belge özellikleri için özel değerler eklemesine de izin verir. Aşağıda, bir sunum için özel özelliklerin nasıl ayarlanacağını gösteren bir örnek verilmiştir.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Belge Özelliklerini Alma
    var dProps = pres.getDocumentProperties();
    // Özel özellikler ekleme
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // Belirli bir indeksteki özellik adını alma
    var getPropertyName = dProps.getCustomPropertyName(2);
    // Seçili özelliği kaldırma
    dProps.removeCustomProperty(getPropertyName);
    // Sunumu kaydetme
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**Eklenen Özel Belge Özellikleri**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Özel Özelliklere Erişim ve Değiştirme**

Aspose.Slides for Node.js via Java, geliştiricilerin özel özellik değerlerine erişmesine de izin verir. Aşağıda, bir sunum için bu özel özelliklerin nasıl erişilip değiştirileceğini gösteren bir örnek bulunmaktadır.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Presentation ile ilişkili DocumentProperties nesnesine bir referans oluşturun
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

Bu örnek, [PPTX](https://docs.fileformat.com/presentation/pptx/) sunumunun özel özelliklerini değiştirir. Aşağıdaki görseller, özelleştirilmiş özelliklerin değişiklik öncesi ve sonrası durumunu gösterir:

|**Değişiklik Öncesi Özel Özellikler**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Değişiklik Sonrası Özel Özellikler**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Gelişmiş Belge Özellikleri**

{{% alert color="primary" %}} 
Yeni yöntemler [ReadDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), ve [WriteBindedPresentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) [PresentationInfo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PresentationInfo) sınıfına eklenmiştir, [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) özelliğinin ayarlayıcısının mantığı değiştirilmiştir.
{{% /alert %}} 

İki yeni yöntem [ReadDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) ve [UpdateDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) [PresentationInfo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PresentationInfo) sınıfına eklenmiştir. Bu yöntemler belge özelliklerine hızlı erişim sağlar ve tüm bir sunumu yüklemeden özellikleri değiştirme ve güncelleme imkanı tanır.

Tipik senaryo, özellikleri yüklemek, bir değeri değiştirmek ve belgeyi güncellemek aşağıdaki şekilde uygulanabilir:

```javascript
// sunumun bilgisini oku
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
var props = info.readDocumentProperties();
props.setAuthor("New Author");
props.setTitle("New Title");
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Belirli bir sunumun özelliklerini şablon olarak kullanarak diğer sunumlardaki özellikleri güncellemenin başka bir yolu da vardır:

```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Sıfırdan yeni bir şablon oluşturulabilir ve ardından birden fazla sunumu güncellemek için kullanılabilir:

```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Düzeltme Dilini Ayarla**

Aspose.Slides, PowerPoint belgesi için düzeltme dili ayarlamanıza olanak tanıyan LanguageId özelliğini (PortionFormat sınıfı tarafından sunulur) sağlar. Düzeltme dili, PowerPoint içinde yazım ve dilbilgisi denetiminin yapılacağı dildir.

Bu JavaScript kodu, PowerPoint için düzeltme dilinin nasıl ayarlanacağını göstermektedir: xxx LanguageId'in JavaScript PortionFormat sınıfında neden eksik olduğu?

```javascript
var pres = new aspose.slides.Presentation(pptxFileName);
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

## **Varsayılan Dili Ayarla**

Bu JavaScript kodu, tüm bir PowerPoint sunumu için varsayılan dilin nasıl ayarlanacağını gösterir:

```javascript
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

[**Aspose.Slides Metadata**](https://products.aspose.app/slides/tr/metadata) çevrimiçi uygulamasını deneyin ve belge özellikleriyle nasıl çalışılacağını görün:

[![PowerPoint Metadatasını Görüntüle ve Düzenle](slides-metadata.png)](https://products.aspose.app/slides/tr/metadata)

## ***SSS**

**Bir sunumdan yerleşik bir özelliği nasıl kaldırabilirim?**

Yerleşik özellikler sunumun ayrılmaz bir parçasıdır ve tamamen kaldırılamaz. Ancak, belirli özelliğin izin verdiği ölçüde değerlerini değiştirebilir veya boş bir değere ayarlayabilirsiniz.

**Zaten var olan bir özel özelliği eklersem ne olur?**

Zaten var olan bir özel özellik eklenirse, mevcut değeri yeni değerle üzerine yazılır. Özelliği önceden kaldırmanıza veya kontrol etmenize gerek yoktur; Aspose.Slides özelliğin değerini otomatik olarak günceller.

**Sunumu tamamen yüklemeden sunum özelliklerine erişebilir miyim?**

Evet, sunumu tamamen yüklemeden sunum özelliklerine erişmek için [PresentationFactory](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationfactory/) sınıfının `getPresentationInfo` yöntemini kullanabilirsiniz. Ardından, [PresentationInfo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/) sınıfının `readDocumentProperties` yöntemini kullanarak özellikleri verimli bir şekilde okuyabilir, bellek tasarrufu yapabilir ve performansı artırabilirsiniz.