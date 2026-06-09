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
- özellikleri yönet
- özellikleri değiştir
- belge üst verileri
- üst verileri düzenle
- düzeltme dili
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da sunum özelliklerini ustalaşın ve PowerPoint ve OpenDocument dosyalarınızda aramayı, marka oluşturmayı ve iş akışını kolaylaştırın."
---
## **Giriş**

Aspose.Slides iki tür belge özelliğini destekler: **Built-in** ve **Custom**. Bu özellik türlerinin her ikisi de Aspose.Slides API'si kullanılarak kolayca erişilebilir ve yönetilebilir.

Aspose.Slides, sunum belge özellikleriyle [IDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idocumentproperties/) arabirimi üzerinden çalışmanıza olanak tanır. Bu arabirimin bir örneği, [Presentation.getDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getDocumentProperties--) yöntemi tarafından döndürülür. Aşağıdaki örnekler, bu özelliklerin nasıl okunacağını, değiştirileceğini ve yönetileceğini gösterir.

{{% alert color="primary" %}} 

Lütfen **Application** ve **Producer** alanlarının değiştirilemeyeceğini unutmayın; bu alanlar her zaman "Aspose Ltd." ve "Aspose.Slides for Java x.x.x" olarak gösterilecektir.

{{% /alert %}} 

## **PowerPoint'te Belge Özellikleri**

Microsoft PowerPoint 2007, sunum dosyalarının belge özelliklerini yönetmeye izin verir. Tek yapmanız gereken, aşağıda gösterildiği gibi Office simgesine tıklayıp **Prepare | Properties | Advanced Properties** menü öğesini seçmektir:

|**Gelişmiş Özellikler menü öğesini seçme**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

**Advanced Properties** menü öğesini seçtikten sonra, aşağıdaki şekilde gösterilen bir iletişim kutusu açılır ve PowerPoint dosyasının belge özelliklerini yönetmenizi sağlar:

|**Özellikler İletişim Kutusu**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Yukarıdaki **Properties Dialog** içinde, **General**, **Summary**, **Statistics**, **Contents** ve **Custom** gibi birçok sekme sayfası olduğunu görebilirsiniz. Bu sekme sayfaları, PowerPoint dosyalarıyla ilgili farklı bilgi türlerini yapılandırmanıza izin verir. **Custom** sekmesi, PowerPoint dosyalarının özel özelliklerini yönetmek için kullanılır.

### Aspose.Slides for Java Kullanarak Belge Özellikleriyle Çalışma

Az önce belirttiğimiz gibi Aspose.Slides for Java, **Built-in** ve **Custom** olmak üzere iki tür belge özelliğini destekler. Bu nedenle geliştiriciler, Aspose.Slides for Java API'si kullanarak her iki tür özelliğe de erişebilir. Aspose.Slides for Java, bir sunum dosyasıyla ilişkili belge özelliklerini **Presentation.DocumentProperties** özelliği aracılığıyla temsil eden [IDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idocumentproperties) sınıfını sağlar.

Geliştiriciler, aşağıda açıklandığı gibi sunum dosyalarının belge özelliklerine erişmek için [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) nesnesi tarafından sunulan **IDocumentProperties** özelliğini kullanabilirler:

## **Built-in Özelliklere Erişim**

Bu özellikler, [IDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idocumentproperties) nesnesi tarafından sunulan: **Creator** (Yazar), **Description**, **Keywords**, **Created** (Oluşturulma Tarihi), **Modified** (Değiştirme Tarihi), **Printed** (Son Yazdırma Tarihi), **LastModifiedBy**, **Keywords**, **SharedDoc** (Farklı üreticiler arasında paylaşılıyor mu?), **PresentationFormat**, **Subject** ve **Title** içerir.

```java
// Sunumu temsil eden Presentation sınıfını oluştur
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation ile ilişkili IDocumentProperties nesnesine referans oluştur
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Yerleşik özellikleri göster
    System.out.println("Category : " + dp.getCategory());
    System.out.println("Current Status : " + dp.getContentStatus());
    System.out.println("Creation Date : " + dp.getCreatedTime());
    System.out.println("Author : " + dp.getAuthor());
    System.out.println("Description : " + dp.getComments());
    System.out.println("KeyWords : " + dp.getKeywords());
    System.out.println("Last Modified By : " + dp.getLastSavedBy());
    System.out.println("Supervisor : " + dp.getManager());
    System.out.println("Modified Date : " + dp.getLastSavedTime());
    System.out.println("Presentation Format : " + dp.getPresentationFormat());
    System.out.println("Last Print Date : " + dp.getLastPrinted());
    System.out.println("Is Shared between producers : " + dp.getSharedDoc());
    System.out.println("Subject : " + dp.getSubject());
    System.out.println("Title : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Built-in Özellikleri Değiştirme**

Sunum dosyalarının built-in özelliklerini değiştirmek, onlara erişmek kadar kolaydır. İstediğiniz herhangi bir özelliğe bir metin değeri atayabilir ve özellik değeri değişir. Aşağıdaki örnekte, Aspose.Slides for Java kullanarak sunum dosyasının built-in belge özelliklerini nasıl değiştirebileceğimizi gösterdik.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation ile ilişkili IDocumentProperties nesnesine bir referans oluştur
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Yerleşik özellikleri ayarla
    dp.setAuthor("Aspose.Slides for Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // Sunumunuzu bir dosyaya kaydedin
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Bu örnek, aşağıda gösterildiği gibi sunumun built-in özelliklerini değiştirir:

|**Değişiklikten Sonra Built-in Belge Özellikleri**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Özel Belge Özellikleri Ekleme**

Aspose.Slides for Java ayrıca geliştiricilerin sunum belge özellikleri için özel değerler eklemesine olanak tanır. Aşağıda bir sunum için özel özelliklerin nasıl ayarlandığını gösteren bir örnek verilmiştir.

```java
Presentation pres = new Presentation();
try {
    // Belge Özelliklerini Alıyor
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Özel özellikler ekleniyor
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Belirli bir indeksdeki özellik adını alıyor
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Seçilen özelliği kaldırıyor
    dProps.removeCustomProperty(getPropertyName);
    
    // Sunumu kaydediyor
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Eklenen Özel Belge Özellikleri**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Özel Özelliklere Erişim ve Değiştirme**

Aspose.Slides for Java ayrıca geliştiricilerin özel özellik değerlerine erişmesine izin verir. Aşağıda bir sunum için bu özel özelliklerin tümüne nasıl erişileceği ve değiştirileceği gösteren bir örnek verilmiştir.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation ile ilişkili DocumentProperties nesnesine bir referans oluştur
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Özel özelliklere eriş ve değiştir
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Özel özelliklerin adlarını ve değerlerini göster
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Özel özelliklerin değerlerini değiştir
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Sunumunuzu bir dosyaya kaydedin
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Bu örnek, [PPTX](https://docs.fileformat.com/presentation/pptx/) sunumunun özel özelliklerini değiştirir. Aşağıdaki görseller, değişiklik öncesi ve sonrası sunumun özel özelliklerini göstermektedir:

|**Değişiklik Öncesi Özel Özellikler**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Değişiklik Sonrası Özel Özellikler**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Gelişmiş Belge Özellikleri**

{{% alert color="primary" %}} 

Yeni yöntemler [ReadDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), ve [WriteBindedPresentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) [IPresentationInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPresentationInfo) arayüzüne eklenmiştir, [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) özelliği ayarlayıcısının mantığı değiştirilmiştir.

{{% /alert %}} 

Yeni iki yöntem [ReadDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) ve [UpdateDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) [IPresentationInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPPresentationInfo) arayüzüne eklenmiştir. Bu yöntemler, belge özelliklerine hızlı erişim sağlar ve tüm bir sunumu yüklemeden özellikleri değiştirme ve güncelleme imkanı verir.

Tipik senaryo, özellikleri yüklemek, bir değeri değiştirmek ve belgeyi güncellemek aşağıdaki şekilde uygulanabilir:

```java
// sunumun bilgisini oku
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// mevcut özellikleri al
IDocumentProperties props = info.readDocumentProperties();

// Author ve Title alanlarının yeni değerlerini ayarla
props.setAuthor("New Author");
props.setTitle("New Title");

// yeni değerlerle sunumu güncelle
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Başka bir yol, belirli bir sunumun özelliklerini şablon olarak kullanarak diğer sunumların özelliklerini güncellemektir:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

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

```java
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Sıfırdan yeni bir şablon oluşturulabilir ve ardından birden fazla sunumu güncellemek için kullanılabilir:

```java
DocumentProperties template = new DocumentProperties();\

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

```java
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Proofing Dilini Ayarlama**

Aspose.Slides, PowerPoint belgesi için proofing dilini ayarlamanıza olanak tanıyan LanguageId özelliğini (PortionFormat sınıfı tarafından sunulur) sağlar. Proofing dili, PowerPoint'te imla ve dilbilgisi denetiminin yapıldığı dildir.

Bu Java kodu, bir PowerPoint için proofing dilinin nasıl ayarlanacağını gösterir: xxx LanguageId'nin Java PortionFormat sınıfında neden bulunmadığı?

```java
Presentation pres = new Presentation(pptxFileName);
try {
    AutoShape autoShape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);

    portionFormat.setLanguageId("zh-CN"); // düzeltme dili kimliğini ayarla

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Varsayılan Dili Ayarlama**

Bu Java kodu, tüm bir PowerPoint sunumu için varsayılan dilin nasıl ayarlanacağını gösterir:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Metin içeren yeni bir dikdörtgen şekil ekler
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // İlk bölümün dilini kontrol eder
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Canlı Örnek**

[Aspose.Slides Metadata](https://products.aspose.app/slides/tr/metadata) çevrimiçi uygulamasını deneyerek Aspose.Slides API'si aracılığıyla belge özellikleriyle nasıl çalışılacağını görebilirsiniz:

[![Görünüm & Düzenle PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/tr/metadata)

## ***SSS**

**Bir sunumdan built-in bir özelliği nasıl kaldırabilirim?**

Built-in özellikler, sunumun ayrılmaz bir parçasıdır ve tamamen kaldırılamaz. Ancak, belirli özellik izin veriyorsa değerlerini değiştirebilir veya boş olarak ayarlayabilirsiniz.

**Zaten mevcut olan bir özel özellik eklersem ne olur?**

Zaten mevcut olan bir özel özellik eklerseniz, mevcut değeri yenisiyle üzerine yazılır. Özelliği önceden silmenize veya kontrol etmenize gerek yoktur; Aspose.Slides özelliğin değerini otomatik olarak günceller.

**Sunumu tamamen yüklemeden sunum özelliklerine erişebilir miyim?**

Evet, [PresentationFactory](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentationfactory/) sınıfının `getPresentationInfo` yöntemini kullanarak sunumu tamamen yüklemeden sunum özelliklerine erişebilirsiniz. Ardından, [IPresentationInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationinfo/) arayüzü tarafından sağlanan `readDocumentProperties` yöntemini kullanarak özellikleri verimli bir şekilde okuyabilir, bellek tasarrufu yapabilir ve performansı artırabilirsiniz.