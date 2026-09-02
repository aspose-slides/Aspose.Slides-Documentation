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
description: "Aspose.Slides for Android via Java içinde sunum özelliklerini yönetin ve PowerPoint ve OpenDocument dosyalarınızda aramayı, marka oluşturmayı ve iş akışını kolaylaştırın."
---
## **Giriş**

Aspose.Slides iki tür belge özelliğini destekler: **Built-in** ve **Custom**. Bu özellik türlerinin ikisi de Aspose.Slides API'si kullanılarak kolayca erişilebilir ve yönetilebilir.

Aspose.Slides, sunum belge özellikleriyle [IDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idocumentproperties/) arayüzü üzerinden çalışmanıza olanak tanır. Bu arayüzün bir örneği, [Presentation.getDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getDocumentProperties--) yöntemi tarafından döndürülür. Aşağıdaki örnekler bu özellikleri okuma, değiştirme ve yönetme yöntemlerini göstermektedir.

{{% alert color="info" title="Note" %}}
Lütfen **Application** ve **AppVersion** alanlarının değiştirilemeyeceğini unutmayın. Aspose.Slides, her kaydetmede bu alanları yeniden yazar, bu nedenle kaydedilen bir sunum her zaman Aspose.Slides ürün adını ve onu üreten kütüphane sürümünü rapor eder. `setNameOfApplication` yöntemine geçirilen herhangi bir değer, sunum yazıldığında göz ardı edilir.
{{% /alert %}} 

## **PowerPoint'ta Belge Özellikleri**

Microsoft PowerPoint 2007, sunum dosyalarının belge özelliklerini yönetmenize izin verir. Tek yapmanız gereken, aşağıda gösterildiği gibi Office simgesine tıklamak ve ardından Microsoft PowerPoint 2007'de **Prepare | Properties | Advanced Properties** menü öğesini seçmektir:

|**Gelişmiş Özellikler menü öğesini seçme**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
After you select **Advanced Properties** menu item, a dialog would appear allowing you to manage the document properties of the PowerPoint file as shown below in the figure:

|**Özellikler İletişim Kutusu**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Yukarıdaki **Özellikler İletişim Kutusu**'nda, **General**, **Summary**, **Statistics**, **Contents** ve **Custom** gibi bir çok sekme olduğunu görebilirsiniz. Bu sekmeler, PowerPoint dosyalarıyla ilgili çeşitli bilgiler yapılandırılmasına izin verir. **Custom** sekmesi, PowerPoint dosyalarının özel özelliklerini yönetmek için kullanılır.

## **Android için Java ile Aspose.Slides Kullanarak Belge Özellikleriyle Çalışma**

Daha önce belirttiğimiz gibi, Android için Java ile Aspose.Slides iki tür belge özelliğini destekler: **Built-in** ve **Custom** özellikler. Bu nedenle geliştiriciler, Android için Java ile Aspose.Slides API'sini kullanarak her iki özelliğe de erişebilir. Android için Java ile Aspose.Slides, **Presentation.DocumentProperties** özelliği aracılığıyla bir sunum dosyasıyla ilişkili belge özelliklerini temsil eden bir [IDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idocumentproperties) sınıfı sunar.

**IDocumentProperties** özelliğini, [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) nesnesi aracılığıyla sunum dosyalarının belge özelliklerine aşağıda açıklandığı gibi erişmek için geliştiriciler kullanabilir.

## **Yerleşik Özelliklere Erişim**

Bu özellikler, [IDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idocumentproperties) nesnesi tarafından sunulduğu gibi: **Creator** (Yazar), **Description**, **Keywords**, **Created** (Oluşturma Tarihi), **Modified** (Değiştirme Tarihi), **Printed** (Son Yazdırma Tarihi), **LastModifiedBy**, **Keywords**, **SharedDoc** (Farklı üreticiler arasında paylaşılıyor mu?), **PresentationFormat**, **Subject** ve **Title**.

```java
import com.aspose.slides.*;

// Sunumu temsil eden Presentation sınıfını örnekleyin
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation ile ilişkili IDocumentProperties nesnesine bir referans oluşturun
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

## **Yerleşik Özellikleri Değiştirme**

Sunum dosyalarının yerleşik özelliklerini değiştirmek, bunlara erişmek kadar kolaydır. İstediğiniz herhangi bir özelliğe bir dize değeri atayarak özellik değeri değiştirilebilir. Aşağıdaki örnekte, Android için Java ile Aspose.Slides kullanarak sunum dosyasının yerleşik belge özelliklerini nasıl değiştirebileceğimizi gösterdik.

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

Bu örnek, aşağıda gösterildiği gibi sunumun yerleşik özelliklerini değiştirir:

|**Değişiklikten Sonra Yerleşik Belge Özellikleri**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Özel Belge Özellikleri Ekleme**

Android için Java ile Aspose.Slides, geliştiricilerin sunum belge özelliklerine özel değerler eklemesine de olanak tanır. Aşağıdaki örnek üç özel özellik ekler, ardından 2. indekste saklanan adı bulur ve bu özelliği kaldırır; böylece kaydedilen sunum iki özelliği tutar. Özel özellikler alfabetik sıraya göre indekslenir, eklenme sırasına göre değil.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Belge Özelliklerini Alıyor
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Özel özellikler ekleniyor
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Belirli bir indekste özellik adını alıyor
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

Android için Java ile Aspose.Slides, geliştiricilerin özel özelliklerin değerlerine erişmesine de izin verir. Aşağıda bir örnek, bir sunum için bu özel özelliklerin tümüne nasıl erişileceğini ve değiştirileceğini göstermektedir.

```java
import com.aspose.slides.*;

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

|**Değişiklik Öncesi Özel Özellikler**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Değişiklik Sonrası Özel Özellikler**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Gelişmiş Belge Özellikleri**

{{% alert color="info" title="Note" %}}
Yeni [ReadDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), ve [WriteBindedPresentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) yöntemleri [IPresentationInfo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPresentationInfo) arayüzüne eklendi, [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) özellik ayarlayıcısının mantığı değiştirildi.
{{% /alert %}} 

İki yeni yöntem, belge özelliklerine hızlı erişim sağlar ve tüm bir sunumu yüklemeden özelliklerin değiştirilip güncellenmesine imkan tanır.

Tipik senaryo, özellikleri yüklemek, bazı değerleri değiştirmek ve belgeyi güncellemek aşağıdaki şekilde uygulanabilir:

```java
import com.aspose.slides.*;

// sunumun bilgilerini oku
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// mevcut özellikleri al
IDocumentProperties props = info.readDocumentProperties();

// Yazar ve Başlık alanlarının yeni değerlerini ayarla
props.setAuthor("New Author");
props.setTitle("New Title");

// sunumu yeni değerlerle güncelle
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Başka bir yöntem, belirli bir sunumun özelliklerini şablon olarak kullanarak diğer sunumlardaki özellikleri güncellemektir:

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

## **Düzeltme Dili Ayarlama**

Aspose.Slides, PowerPoint belgesi için düzeltme dilini ayarlamanıza olanak tanıyan LanguageId özelliğini (PortionFormat sınıfı tarafından sunulur) sağlar. Düzeltme dili, PowerPoint'te yazım ve dilbilgisinin kontrol edildiği dildir.

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

## **Varsayılan Dil Ayarlama**

Bu Java kodu, bir PowerPoint sunumunun tamamı için varsayılan dilin nasıl ayarlanacağını gösterir:

```java
import com.aspose.slides.*;

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

Belge özellikleriyle Aspose.Slides API'si üzerinden nasıl çalışılacağını görmek için çevrimiçi [**Aspose.Slides Metadata**](https://products.aspose.app/slides/tr/metadata) uygulamasını deneyin:

[![PowerPoint Üstverisini Görüntüle ve Düzenle](slides-metadata.png)](https://products.aspose.app/slides/tr/metadata)

## **SSS**

**Bir sunumdan yerleşik bir özelliği nasıl kaldırabilirim?**

Yerleşik özellikler, sunumun bütünleyici bir parçasıdır ve tamamen kaldırılamaz. Ancak, belirli bir özellik izin veriyorsa, değerlerini değiştirebilir veya boş bırakabilirsiniz.

**Zaten var olan bir özel özellik eklersem ne olur?**

Eğer zaten var olan bir özel özellik eklerseniz, mevcut değeri yeni değerle üzerine yazılır. Özelliği önceden kaldırmanıza veya kontrol etmenize gerek yoktur; Aspose.Slides otomatik olarak özelliğin değerini günceller.

**Sunumu tamamen yüklemeden sunum özelliklerine erişebilir miyim?**

Evet. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) yöntemini ardından [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) yöntemini kullanarak bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) örneği oluşturmadan depolanmış belge üst verilerini okuyabilirsiniz. Tam bir raporlama örneği ve format‑özelliği sınırlamaları için [Build a Lightweight Presentation Inventory](/slides/tr/androidjava/examine-presentation/) sayfasına bakın.