---
title: Android'de Sunum Özelliklerini Yönetme
linktitle: Sunum Özellikleri
type: docs
weight: 70
url: /tr/androidjava/presentation-properties/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile sunum özelliklerini yönetin ve PowerPoint ve OpenDocument dosyalarınızda aramayı, markalaşmayı ve iş akışını kolaylaştırın."
---
## **Giriş**

Aspose.Slides iki tür belge özelliğini destekler: **Yerleşik** ve **Özel**. Bu özellik türlerinin her ikisi de Aspose.Slides API'si kullanılarak kolayca erişilebilir ve yönetilebilir.

Aspose.Slides, sunum belge özellikleriyle [IDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idocumentproperties/) arabirimi üzerinden çalışmanıza olanak tanır. Bu arabirimin bir örneği, [Presentation.getDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getDocumentProperties--) yöntemi tarafından döndürülür. Aşağıdaki örnekler, bu özelliklerin nasıl okunacağını, değiştirileceğini ve yönetileceğini gösterir.

{{% alert color="primary" %}} 
Lütfen **Application** ve **Producer** alanlarının değiştirilemeyeceğini unutmayın; bu alanlar her zaman "Aspose Ltd." ve "Aspose.Slides for Android via Java x.x.x" olarak görüntülenecektir.
{{% /alert %}} 

## **PowerPoint'taki Belge Özellikleri**

Microsoft PowerPoint 2007, sunum dosyalarının belge özelliklerini yönetmeye olanak tanır. Tek yapmanız gereken, aşağıda gösterildiği gibi Office simgesine tıklamak ve ardından Microsoft PowerPoint 2007'de **Prepare | Properties | Advanced Properties** menü öğesini seçmektir:

|**Gelişmiş Özellikler menü öğesini seçme**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

**Advanced Properties** menü öğesini seçtikten sonra, aşağıdaki şekilde gösterilen PowerPoint dosyasının belge özelliklerini yönetmenizi sağlayan bir iletişim kutusu açılır:

|**Özellikler İletişim Kutusu**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Yukarıdaki **Properties Dialog** içinde, **General**, **Summary**, **Statistics**, **Contents** ve **Custom** gibi birçok sekme sayfası olduğunu görebilirsiniz. Bu sekme sayfalarının tümü PowerPoint dosyalarıyla ilgili çeşitli bilgiler yapılandırmaya olanak tanır. **Custom** sekmesi, PowerPoint dosyalarının özel özelliklerini yönetmek için kullanılır.

Aspose.Slides for Android via Java ile Belge Özellikleriyle Çalışma

Daha önce açıkladığımız gibi Aspose.Slides for Android via Java iki tür belge özelliğini destekler: **Built-in** ve **Custom** özellikler. Bu nedenle geliştiriciler, Aspose.Slides for Android via Java API'si ile her iki tür özelliğe de erişebilir. Aspose.Slides for Android via Java, bir sunum dosyasıyla ilişkili belge özelliklerini **Presentation.DocumentProperties** özelliği aracılığıyla temsil eden bir sınıf olan [IDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idocumentproperties) sağlar.

Geliştiriciler, aşağıda açıklandığı gibi sunum dosyalarının belge özelliklerine erişmek için [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) nesnesi tarafından sunulan **IDocumentProperties** özelliğini kullanabilirler:

## **Yerleşik Özelliklere Erişim**

Bu özellikler, [IDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idocumentproperties) nesnesi tarafından sunulan: **Creator** (Yazar), **Description**, **Keywords**, **Created** (Oluşturma Tarihi), **Modified** (Değiştirme Tarihi), **Printed** (Son Yazdırma Tarihi), **LastModifiedBy**, **Keywords**, **SharedDoc** (Farklı üreticiler arasında paylaşılıyor mu?), **PresentationFormat**, **Subject** ve **Title** içerir.

```java
// Sunumu temsil eden Presentation sınıfını örnekleyin
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation ile ilişkili IDocumentProperties nesnesine bir referans oluşturun
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Yerleşik özellikleri gösterin
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

## **Yerleşik Özellikleri Değiştirme**

Sunum dosyalarının yerleşik özelliklerini değiştirmek, onlara erişmek kadar kolaydır. İstediğiniz herhangi bir özelliğe basitçe bir dize değeri atayabilirsiniz ve özellik değeri değiştirilecektir. Aşağıdaki örnekte, Aspose.Slides for Android via Java kullanarak sunum dosyasının yerleşik belge özelliklerini nasıl değiştirebileceğimizi gösterdik.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation ile ilişkili IDocumentProperties nesnesine bir referans oluşturun
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Yerleşik özellikleri ayarlayın
    dp.setAuthor("Aspose.Slides for Android via Java");
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

Bu örnek, aşağıda gösterildiği gibi sunumun yerleşik özelliklerini değiştirir:

|**Değişiklikten Sonra Yerleşik Belge Özellikleri**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Özel Belge Özellikleri Ekleme**

Aspose.Slides for Android via Java, geliştiricilerin sunum belge özellikleri için özel değerler eklemesine de olanak tanır. Aşağıda bir sunum için özel özelliklerin nasıl ayarlanacağını gösteren bir örnek verilmiştir.

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

|**Eklenen Özel Belge Özellikleri**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Özel Özelliklere Erişim ve Değiştirme**

Aspose.Slides for Android via Java, geliştiricilerin özel özelliklerin değerlerine erişmesine de izin verir. Aşağıda, bir sunum için bu özel özelliklerin tümüne nasıl erişileceği ve değiştirileceği gösteren bir örnek verilmiştir.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation ile ilişkili DocumentProperties nesnesine bir referans oluşturun
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

Bu örnek, [PPTX ](https://docs.fileformat.com/presentation/pptx/) sunumunun özel özelliklerini değiştirir. Aşağıdaki görseller, değişiklik öncesi ve sonrası sunumun özel özelliklerini gösterir:

|**Değişiklik Öncesi Özel Özellikler**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Değişiklik Sonrası Özel Özellikler**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Gelişmiş Belge Özellikleri**

{{% alert color="primary" %}} 
Yeni yöntemler [ReadDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), ve [WriteBindedPresentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) [IPresentationInfo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPresentationInfo) e eklenmiştir, [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) özellik ayarlayıcısının mantığı değiştirilmiştir.
{{% /alert %}} 

İki yeni yöntem [ReadDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) ve [UpdateDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) [IPresentationInfo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPresentationInfo) arabirimine eklenmiştir. Bu yöntemler, belge özelliklerine hızlı erişim sağlar ve tüm bir sunumu yüklemeden özellikleri değiştirme ve güncelleme imkanı tanır.

Tipik senaryo, özellikleri yüklemek, bir değeri değiştirmek ve belgeyi güncellemek aşağıdaki şekilde uygulanabilir:

```java
// sunumun bilgilerini oku
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// geçerli özellikleri al
IDocumentProperties props = info.readDocumentProperties();

// Yazar ve Başlık alanlarının yeni değerlerini ayarla
props.setAuthor("New Author");
props.setTitle("New Title");

// sunumu yeni değerlerle güncelle
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Belirli bir sunumun özelliklerini bir şablon olarak kullanarak diğer sunumların özelliklerini güncellemenin başka bir yolu da vardır:

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

## **Düzeltme Dilini Ayarlama**

Aspose.Slides, bir PowerPoint belgesi için düzeltme dilini ayarlamanıza olanak tanıyan LanguageId özelliğini (PortionFormat sınıfı tarafından sunulur) sağlar. Düzeltme dili, PowerPoint'teki yazım ve dilbilgisinin denetlendiği dildir.

Bu Java kodu, bir PowerPoint için düzeltme dilinin nasıl ayarlanacağını gösterir: xxx LanguageId'nin Java PortionFormat sınıfından neden eksik olduğu?

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

    portionFormat.setLanguageId("zh-CN"); // düzeltme dilinin kimliğini ayarla

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Varsayılan Dil Ayarlama**

Bu Java kodu, tüm bir PowerPoint sunumu için varsayılan dilin nasıl ayarlanacağını gösterir:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Yeni bir dikdörtgen şekli ve metin ekler
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // İlk bölümün dilini kontrol eder
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Canlı Örnek**

Belge özellikleriyle Aspose.Slides API'si üzerinden nasıl çalışılacağını görmek için çevrimiçi uygulama [**Aspose.Slides Metadata**](https://products.aspose.app/slides/tr/metadata) deneyin:

[![PowerPoint Meta Verilerini Görüntüle ve Düzenle](slides-metadata.png)](https://products.aspose.app/slides/tr/metadata)

## ***SSS**

**Sunumdan bir yerleşik özelliği nasıl kaldırabilirim?**

Yerleşik özellikler, sunumun ayrılmaz bir parçasıdır ve tamamen kaldırılamaz. Ancak, ilgili özellik izin veriyorsa, değerlerini değiştirebilir veya boş olarak ayarlayabilirsiniz.

**Zaten var olan bir özel özellik eklerseniz ne olur?**

Eğer zaten var olan bir özel özellik eklerseniz, mevcut değeri yeni değerle üzerine yazılır. Özelliği önceden kaldırmanıza veya kontrol etmenize gerek yoktur; Aspose.Slides, özelliğin değerini otomatik olarak günceller.

**Sunumu tamamen yüklemeden sunum özelliklerine erişebilir miyim?**

Evet, [PresentationFactory](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentationfactory/) sınıfının `getPresentationInfo` yöntemini kullanarak sunumu tamamen yüklemeden sunum özelliklerine erişebilirsiniz. Ardından, [IPresentationInfo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationinfo/) arabirimi tarafından sağlanan `readDocumentProperties` yöntemini kullanarak özellikleri verimli bir şekilde okuyabilir, bellek tasarrufu sağlayabilir ve performansı artırabilirsiniz.