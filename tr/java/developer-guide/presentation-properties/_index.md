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
- dahili özellikler
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
description: "Aspose.Slides for Java'da sunum özelliklerini yönetin ve PowerPoint ve OpenDocument dosyalarınızda aramayı, markayı ve iş akışını kolaylaştırın."
---
## **Giriş**

Aspose.Slides iki tür belge özelliğini destekler: **Dahili** ve **Özel**. Bu özellik türlerine Aspose.Slides API'si aracılığıyla kolayca erişilebilir ve yönetilebilir.

Aspose.Slides, sunum belge özellikleriyle **[IDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idocumentproperties/)** arabirimi üzerinden çalışmanıza olanak tanır. Bu arabirimin bir örneği **[Presentation.getDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getDocumentProperties--)** yöntemiyle döndürülür. Aşağıdaki örnekler, bu özelliklerin nasıl okunacağını, değiştirileceğini ve yönetileceğini gösterir.

{{% alert color="info" title="Not" %}}
Lütfen **Application** ve **AppVersion** alanlarının değiştirilemeyeceğini unutmayın. Aspose.Slides her kaydetmede bu alanları yeniden yazar; bu yüzden kaydedilen bir sunum her zaman “Aspose.Slides for Java” ve onu üreten kütüphane sürümünü rapor eder. `setNameOfApplication` metoduna geçirilen herhangi bir değer sunum yazıldığında göz ardı edilir.
{{% /alert %}} 

## **PowerPoint'ta Belge Özellikleri**

Microsoft PowerPoint 2007, sunum dosyalarının belge özelliklerini yönetmeye izin verir. Tek yapmanız gereken Office simgesine tıklayıp **Prepare | Properties | Advanced Properties** menü öğesini seçmektir; aşağıda gösterildiği gibi:

|**Gelişmiş Özellikler menü öğesini seçme**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
**Advanced Properties** menü öğesini seçtikten sonra, aşağıdaki şekilde PowerPoint dosyasının belge özelliklerini yönetmenizi sağlayan bir iletişim kutusu açılır:

|**Özellikler İletişim Kutusu**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Yukarıdaki **Özellikler İletişim Kutusu**'nda **General**, **Summary**, **Statistics**, **Contents** ve **Custom** gibi birçok sekme sayfası görebilirsiniz. Bu sekmeler, PowerPoint dosyalarıyla ilgili farklı bilgi türlerini yapılandırmanıza olanak tanır. **Custom** sekmesi, PowerPoint dosyalarının özel özelliklerini yönetmek için kullanılır.

## **Aspose.Slides for Java ile Belge Özellikleriyle Çalışma**

Daha önce belirttiğimiz gibi Aspose.Slides for Java, **Dahili** ve **Özel** olmak üzere iki tür belge özelliğini destekler. Bu sayede geliştiriciler, Aspose.Slides for Java API’si kullanarak her iki tür özelliğe de erişebilir. Aspose.Slides for Java, **Presentation.DocumentProperties** özelliği aracılığıyla bir sunum dosyasıyla ilişkili belge özelliklerini temsil eden **[IDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idocumentproperties)** sınıfını sunar.

Geliştiriciler, aşağıda açıklandığı gibi **[Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation)** nesnesi tarafından sunulan **IDocumentProperties** özelliğini kullanarak sunum dosyalarının belge özelliklerine erişebilir:

## **Dahili Özelliklere Erişim**

[IDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idocumentproperties) nesnesi tarafından açığa çıkarılan bu özellikler şunlardır: **Creator** (Yazar), **Description**, **Keywords**, **Created** (Oluşturulma Tarihi), **Modified** (Değiştirilme Tarihi), **Printed** (Son Yazdırma Tarihi), **LastModifiedBy**, **SharedDoc** (Farklı üreticiler arasında paylaşılıyor mu?), **PresentationFormat**, **Subject** ve **Title**.

```java
import com.aspose.slides.*;

// Sunumu temsil eden Presentation sınıfının bir örneğini oluşturun
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation ile ilişkili IDocumentProperties nesnesine bir referans oluşturun
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Dahili özellikleri görüntüle
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

## **Dahili Özellikleri Değiştirme**

Sunum dosyalarının dahili özelliklerini değiştirmek, erişmek kadar basittir. İstediğiniz herhangi bir özelliğe bir dize değeri atayabilir ve özellik değeri güncellenir. Aşağıdaki örnek, Aspose.Slides for Java kullanarak bir sunum dosyasının dahili belge özelliklerinin nasıl değiştirileceğini gösterir.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation ile ilişkili IDocumentProperties nesnesine bir referans oluşturun
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Dahili özellikleri ayarlayın
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

Bu örnek, aşağıda gösterildiği gibi değiştirilen dahili özellikleri içerir:

|**Değişiklikten Sonra Dahili Belge Özellikleri**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Özel Belge Özellikleri Ekleme**

Aspose.Slides for Java, geliştiricilerin sunum belge özellikleri için özel değerler eklemesine de izin verir. Aşağıdaki örnek üç özel özellik ekler, ardından 2. indeksde saklanan adı bulur ve bu özelliği kaldırır; böylece kaydedilen sunum iki özelliği tutar. Özel özellikler alfabetik sıraya göre indekslenir, eklenme sırasına göre değil.

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

|**Eklenen Özel Belge Özellikleri**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Özel Özelliklere Erişme ve Değiştirme**

Aspose.Slides for Java, geliştiricilerin özel özelliklerin değerlerine erişmesine de olanak tanır. Aşağıdaki örnek, bir sunum için bu özel özelliklerin tümüne nasıl erişileceğini ve değiştirileceğini gösterir.

```java
import com.aspose.slides.*;

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

Bu örnek, [PPTX](https://docs.fileformat.com/presentation/pptx/) sunumunun özel özelliklerini değiştirir. Aşağıdaki şekiller, değişiklik öncesi ve sonrası sunum özel özelliklerini gösterir:

|**Değişiklik Öncesi Özel Özellikler**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Değişiklik Sonrası Özel Özellikler**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Gelişmiş Belge Özellikleri**

{{% alert color="info" title="Not" %}}
Yeni yöntemler **[ReadDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--)**, **[UpdateDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)** ve **[WriteBindedPresentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-)**, **[IPresentationInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPresentationInfo)** arayüzüne eklendi; **[IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-)** özelliğinin ayarlayıcısının mantığı değiştirildi.
{{% /alert %}} 

Yeni eklenen iki yöntem **[ReadDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--)** ve **[UpdateDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)**, **[IPresentationInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPresentationInfo)** arayüzüne eklenmiştir. Bu yöntemler belge özelliklerine hızlı erişim sağlar ve tüm bir sunumu yüklemeden özellikleri değiştirmeye ve güncellemeye olanak tanır.

Tipik senaryo: özellikleri yükleyin, bir değeri değiştirin ve belgeyi güncelleyin; bu aşağıdaki şekilde uygulanabilir:

```java
import com.aspose.slides.*;

// sunumun bilgilerini oku
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// obtain the current properties
IDocumentProperties props = info.readDocumentProperties();

// set the new values of Author and Title fields
props.setAuthor("New Author");
props.setTitle("New Title");

// update the presentation with a new values
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Belirli bir sunumun özelliklerini bir şablon olarak kullanarak diğer sunumlardaki özellikleri güncellemenin başka bir yolu da vardır:

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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Düzeltme Dili Ayarlama**

Aspose.Slides, PowerPoint belgesi için düzeltme dilini ayarlamanıza olanak tanıyan **PortionFormat** sınıfı tarafından açığa çıkarılan **LanguageId** özelliğini sağlar. Düzeltme dili, PowerPoint'te yazım ve dilbilgisi denetiminin yapılacağı dildir.

Bu Java kodu, bir PowerPoint için düzeltme dilinin nasıl ayarlanacağını gösterir:

```java
import com.aspose.slides.*;

String pptxFileName = "presentation.pptx";

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
import com.aspose.slides.*;

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

Belge özellikleriyle Aspose.Slides API'si üzerinden nasıl çalışılacağını görmek için çevrimiçi **[Aspose.Slides Metadata](https://products.aspose.app/slides/tr/metadata)** uygulamasını deneyin:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/tr/metadata)

## **SSS**

**Bir dahili özelliği bir sunumdan nasıl kaldırabilirim?**

Dahili özellikler sunumun bütünleşik bir parçasıdır ve tamamen kaldırılamaz. Ancak, izin veriliyorsa değerlerini değiştirebilir veya boş bırakabilirsiniz.

**Zaten var olan bir özel özellik eklersem ne olur?**

Zaten var olan bir özel özellik eklerseniz, mevcut değeri yeni değerle üzerine yazılır. Özelliği önceden kaldırmanıza veya kontrol etmenize gerek yoktur; Aspose.Slides otomatik olarak değerini günceller.

**Sunumu tamamen yüklemeden sunum özelliklerine erişebilir miyim?**

Evet. **[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-)** metodunu kullanın ve ardından **[IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--)** ile bir **[Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/)** örneği oluşturmadan depolanmış belge meta verilerini okuyun. Tam bir raporlama örneği ve format‑spesifik sınırlamalar için **[Build a Lightweight Presentation Inventory](/slides/tr/java/examine-presentation/)** sayfasına bakın.