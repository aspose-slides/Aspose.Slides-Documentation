---
title: Android'de Sunum Özelliklerini Yönet
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
- özellikleri yönet
- özellikleri değiştir
- belge üst verileri
- üst verileri düzenle
- düzeltme dili
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java'da sunum özelliklerini yönetin ve PowerPoint ve OpenDocument dosyalarınızda arama, markalaşma ve iş akışını kolaylaştırın."
---
## **Giriş**

Aspose.Slides iki tür belge özelliğini destekler: **Yerleşik** ve **Özel**. Bu özellik türlerinin her ikisi de Aspose.Slides API'si kullanılarak kolaylıkla erişilebilir ve yönetilebilir.

Aspose.Slides, sunum belge özellikleriyle [IDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idocumentproperties/) arayüzü üzerinden çalışmanıza olanak tanır. Bu arayüzün bir örneği, [Presentation.getDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getDocumentProperties--) yöntemiyle döndürülür. Aşağıdaki örnekler, bu özelliklerin nasıl okunacağını, değiştirileceğini ve yönetileceğini gösterir.

{{% alert color="info" %}} 

Lütfen **Application** ve **AppVersion** alanlarının değiştirilemeyeceğini unutmayın. Aspose.Slides, her kaydetmede bu alanları yeniden yazar, böylece kaydedilen bir sunum her zaman Aspose.Slides ürün adını ve onu oluşturan kütüphane sürümünü rapor eder. `setNameOfApplication` yöntemine verilen herhangi bir değer, sunum yazıldığında göz ardı edilir.

{{% /alert %}} 

## **PowerPoint'te Belge Özellikleri**

Microsoft PowerPoint 2007, sunum dosyalarının belge özelliklerini yönetmeye olanak tanır. Tek yapmanız gereken, aşağıda gösterildiği gibi Office simgesine tıklayıp **Prepare | Properties | Advanced Properties** menü öğesini seçmektir:

|**Advanced Özellikler Menüsü Öğesini Seçme**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

**Advanced Properties** menü öğesini seçtikten sonra, aşağıdaki şekilde gösterilen PowerPoint dosyasının belge özelliklerini yönetmenizi sağlayan bir iletişim kutusu açılır:

|**Özellikler Dialogu**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Yukarıdaki **Özellikler Dialogu**'nda **General**, **Summary**, **Statistics**, **Contents** ve **Custom** gibi birçok sekme sayfası görebilirsiniz. Bu sekme sayfaları, PowerPoint dosyalarıyla ilgili farklı bilgi türlerini yapılandırmaya izin verir. **Custom** sekmesi, PowerPoint dosyalarının özel özelliklerini yönetmek için kullanılır.



Aspose.Slides for Android via Java Kullanarak Belge Özellikleriyle Çalışma

Daha önce belirttiğimiz gibi Aspose.Slides for Android via Java, **Yerleşik** ve **Özel** olmak üzere iki çeşit belge özelliğini destekler. Bu sayede geliştiriciler, Aspose.Slides for Android via Java API'si ile her iki tür özelliğe de erişebilir. Aspose.Slides for Android via Java, **Presentation.DocumentProperties** özelliği aracılığıyla bir sunum dosyasına ilişkin belge özelliklerini temsil eden bir [IDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idocumentproperties) sınıfı sunar.

Geliştiriciler, aşağıda açıklandığı gibi sunum dosyalarının belge özelliklerine erişmek için [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) nesnesi tarafından ortaya çıkarılan **IDocumentProperties** özelliğini kullanabilir:

## **Yerleşik Özelliklere Erişim**

Bu özellikler, [IDocumentProperties] nesnesi tarafından sunulan: **Creator** (Yazar), **Description**, **Keywords**, **Created** (Oluşturma Tarihi), **Modified** (Değiştirme Tarihi), **Printed** (Son Yazdırma Tarihi), **LastModifiedBy**, **SharedDoc** (Farklı üreticiler arasında paylaşılıyor mu?), **PresentationFormat**, **Subject** ve **Title**.

```java
import com.aspose.slides.*;

// Sunumu temsil eden Presentation sınıfını oluştur
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation ile ilişkili IDocumentProperties nesnesine bir referans oluştur
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Yerleşik özellikleri görüntüle
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

Yerleşik özellikleri değiştirmek, onlara erişmek kadar kolaydır. İstediğiniz herhangi bir özelliğe bir metin değeri atayabilirsiniz ve özellik değeri değişecektir. Aşağıdaki örnekte, Aspose.Slides for Android via Java kullanarak bir sunum dosyasının yerleşik belge özelliklerini nasıl değiştirebileceğimizi gösteriyoruz.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation ile ilişkili IDocumentProperties nesnesine bir referans oluştur
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Yerleşik özellikleri ayarla
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

Bu örnek, aşağıda gösterildiği gibi değiştirilen yerleşik özellikleri içerir:

|**Değiştirme Sonrası Yerleşik Belge Özellikleri**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Özel Belge Özellikleri Ekleme**

Aspose.Slides for Android via Java, geliştiricilerin sunum belge özelliklerine özel değerler eklemesine de izin verir. Aşağıdaki örnek üç özel özellik ekler, ardından 2. indekste saklanan adı bulur ve bu özelliği kaldırır; böylece kaydedilen sunum iki özelliği tutar. Özel özellikler alfabetik sıraya göre indekslenir, eklenme sırasına göre değil.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Belge Özelliklerini Alma
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Özel özellikler ekleme
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Belirli bir indeksteki özellik adını alma
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Seçilen özelliği kaldırma
    dProps.removeCustomProperty(getPropertyName);
    
    // Sunumu kaydetme
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Eklenen Özel Belge Özellikleri**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Özel Özelliklere Erişim ve Değiştirme**

Aspose.Slides for Android via Java, geliştiricilerin özel özelliklerin değerlerine erişmesine de olanak tanır. Aşağıdaki örnek, bir sunum için bu özel özelliklerin tümüne nasıl erişileceğini ve değiştirileceğini gösterir.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation ile ilişkili DocumentProperties nesnesine bir referans oluştur
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Özel özelliklere eriş ve değiştir
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Özel özelliklerin adlarını ve değerlerini görüntüle
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

Bu örnek, [PPTX](https://docs.fileformat.com/presentation/pptx/) sunumunun özel özelliklerini değiştirir. Aşağıdaki şekiller, değişiklik öncesi ve sonrası sunumun özel özelliklerini gösterir:

|**Değiştirmeden Önce Özel Özellikler**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Değiştirmeden Sonra Özel Özellikler**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Gelişmiş Belge Özellikleri**

{{% alert color="info" %}} 

Yeni yöntemler [ReadDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), ve [WriteBindedPresentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) [IPresentationInfo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPresentationInfo) arayüzüne eklendi; [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) özelliğinin ayarlayıcı mantığı değiştirildi.

{{% /alert %}} 

Yeni eklenen iki yöntem, belge özelliklerine hızlı erişim sağlar ve tüm bir sunumu yüklemeden özellikleri değiştirme ve güncelleme imkanı sunar.

Tipik senaryoda özellikler yüklenir, bir değer değiştirilir ve belge güncellenir; bu aşağıdaki şekilde uygulanabilir:

```java
import com.aspose.slides.*;

// sunumun bilgilerini oku
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// mevcut özellikleri al
IDocumentProperties props = info.readDocumentProperties();

// Author ve Title alanlarının yeni değerlerini ayarla
props.setAuthor("New Author");
props.setTitle("New Title");

// sunumu yeni değerlerle güncelle
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Belirli bir sunumun özelliklerini şablon olarak kullanarak diğer sunumlardaki özellikleri güncellemenin başka bir yolu da vardır:

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Sıfırdan yeni bir şablon oluşturulabilir ve ardından birden fazla sunumu güncellemek için kullanılabilir:

```java
import com.aspose.slides.*;

DocumentProperties template = new DocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" })
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Düzeltme Dilini Ayarla**

Aspose.Slides, PortionFormat sınıfı tarafından sunulan LanguageId özelliği sayesinde PowerPoint belgesinin düzeltme dilini ayarlamanıza olanak tanır. Düzeltme dili, PowerPoint'te imla ve dilbilgisi denetiminin yapılacağı dildir.

Bu Java kodu, bir PowerPoint için düzeltme dilinin nasıl ayarlanacağını gösterir:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
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

## **Varsayılan Dilini Ayarla**

Bu Java kodu, tüm bir PowerPoint sunumu için varsayılan dilin nasıl ayarlanacağını gösterir:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Yeni bir dikdörtgen şekil ekler ve metin ayarlar
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // İlk bölümün dilini kontrol eder
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Canlı Örnek**

Aspose.Slides API'si aracılığıyla belge özellikleriyle nasıl çalışılacağını görmek için çevrimiçi uygulama olan [**Aspose.Slides Metadata**](https://products.aspose.app/slides/tr/metadata)'yi deneyin:

[![PowerPoint Üst Verisini Görüntüle ve Düzenle](slides-metadata.png)](https://products.aspose.app/slides/tr/metadata)

## ***SSS**

### Bir yerleşik özelliği bir sunumdan nasıl kaldırabilirim?

Yerleşik özellikler sunumun ayrılmaz bir parçasıdır ve tamamen kaldırılamaz. Ancak, belirli özellik izin veriyorsa değerlerini değiştirebilir veya boş bırakabilirsiniz.

### Zaten var olan bir özel özelliği eklersem ne olur?

Zaten var olan bir özel özelliği eklerseniz, mevcut değeri yeni değerle üzerine yazılır. Özelliği önceden kaldırmaya veya kontrol etmeye gerek yoktur; Aspose.Slides otomatik olarak özelliğin değerini günceller.

### Sunumu tamamen yüklemeden sunum özelliklerine erişebilir miyim?

Evet, sunumu tamamen yüklemeden [PresentationFactory](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentationfactory/) sınıfının `getPresentationInfo` yöntemini kullanarak sunum özelliklerine erişebilirsiniz. Ardından, [IPresentationInfo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationinfo/) arayüzünün `readDocumentProperties` metodunu kullanarak özellikleri verimli bir şekilde okuyabilir, bellek tasarrufu sağlayabilir ve performansı artırabilirsiniz.