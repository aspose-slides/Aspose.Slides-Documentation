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
- belge üst verileri
- üst verileri düzenleme
- denetim dili
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java'da sunum özelliklerini yönetin ve PowerPoint ve OpenDocument dosyalarınızda aramayı, markalaşmayı ve iş akışını kolaylaştırın."
---
## **Giriş**

Aspose.Slides iki tür belge özelliğini destekler: **Yerleşik** ve **Özel**. Bu iki özellik türüne Aspose.Slides API'si ile kolayca erişilebilir ve yönetilebilir.

Aspose.Slides, sunum belge özellikleriyle [IDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idocumentproperties/) arayüzü üzerinden çalışmanıza olanak tanır. Bu arayüzün bir örneği, [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) tarafından döndürülür. Aşağıdaki örnekler, bu özellikleri nasıl okuyacağınızı, değiştireceğinizi ve yöneteceğinizi gösterir.

{{% alert color="info" title="Not" %}}
Lütfen **Application** ve **AppVersion** alanlarının değiştirilemediğini unutmayın. Aspose.Slides her kaydetmede bu alanları yeniden yazar, bu nedenle kaydedilmiş bir sunum her zaman Aspose.Slides ürün adını ve onu üreten kütüphanenin sürümünü raporlar. `setNameOfApplication`'a geçirilen herhangi bir değer, sunum yazıldığında yoksayılır.
{{% /alert %}} 

## **PowerPoint'ta Belge Özellikleri**

Microsoft PowerPoint 2007, sunum dosyalarının belge özelliklerini yönetmeye olanak tanır. Tek yapmanız gereken, aşağıda gösterildiği gibi Office simgesine tıklayıp **Prepare | Properties | Advanced Properties** menü öğesini seçmektir:

|**Gelişmiş Özellikler menüsü öğesini seçme**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Advanced Properties menüsü seçildikten sonra, PowerPoint dosyasının belge özelliklerini yönetmenizi sağlayan bir iletişim kutusu aşağıdaki şekilde görüntülenir:

|**Özellikler İletişim Kutusu**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Yukarıdaki **Properties Dialog** içinde **General**, **Summary**, **Statistics**, **Contents** ve **Custom** gibi birçok sekme sayfası olduğunu görebilirsiniz. Bu sekme sayfaları, PowerPoint dosyalarına ilişkin farklı bilgi türlerini yapılandırmanıza izin verir. **Custom** sekmesi, PowerPoint dosyalarının özel özelliklerini yönetmek için kullanılır.

## **Aspose.Slides for Android via Java ile Belge Özellikleri Kullanma**

Daha önce açıkladığımız gibi Aspose.Slides for Android via Java, **Built-in** ve **Custom** olmak üzere iki tür belge özelliğini destekler. Böylece geliştiriciler, Aspose.Slides for Android via Java API'si ile her iki özelliğe de erişebilir. Aspose.Slides for Android via Java, bir sunum dosyasıyla ilişkili belge özelliklerini **Presentation.DocumentProperties** özelliği aracılığıyla temsil eden bir sınıf olan [IDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idocumentproperties) sağlar.

Geliştiriciler, [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) nesnesi tarafından sunulan **IDocumentProperties** özelliğini kullanarak sunum dosyalarının belge özelliklerine aşağıda açıklandığı gibi erişebilirler:

## **Şifreli Sunumdan Genel Özellikleri Okuma**

Bir açma şifresi genellikle sunum içeriğini ve belge özelliklerini korur. Sunum, [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) metoduna `false` geçirilerek şifrelenirse, belge özellikleri hâlâ genel kalır. Bir uygulama daha sonra [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) metoduna `true` geçirerek açma şifresi sağlamadan genel üst veriyi okuyabilir.

document-properties-only seçeneği, Aspose.Slides'in neyi yüklediğini kontrol eder; hiçbir şeyi çözmez. Özellikler şifrelemeye dahil edilmişse, şifre olmadan yükleme başarısız olur. Sunum şifrelenmemişse, seçenek yoksayılır ve tam sunum yüklenir.

Sonraki örnek, [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) aracılığıyla yükleme modunu doğrular ve ardından [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) üzerinden yerleşik özellikleri okur:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties properties = presentation.getDocumentProperties();

        System.out.println("Author: " + properties.getAuthor());
        System.out.println("Title: " + properties.getTitle());
        System.out.println("Keywords: " + properties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

Bu modda, slayt içeriği yüklenmez. Slaytlar, ana tasarımlar, düzenler, şekiller, medya ve diğer sunum nesneleri kullanılamaz. Uygulamalar, tam sunum nesne modelini gerektiren bir işlem yapmadan önce her zaman [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) metodunu kontrol etmelidir.

{{% alert color="warning" title="Uyarı" %}}
Genel üst veri, yazar adlarını, başlıkları, konuları, anahtar kelimeleri, şirket bilgilerini, yorumları ve özel değerleri ortaya çıkarabilir. Hassas özellikleri sunumla birlikte şifreleyin. Yalnızca indeksleme, sınıflandırma, arama veya belge yönetim sistemlerinin şifre gerektirmeden erişim ihtiyacı olduğunda genel bırakın.
{{% /alert %}}

## **Şifreli Sunumun Özelliklerini Güncelleme**

Şifreli bir PPTX dosyası için, belge özellikleri yalnızca modunda yüklü bir sunum, genel üst veriyi okumak amacıyla kullanılır. Aspose.Slides, bu yalnızca üst veri nesnesinden değiştirilen özellikleri kaydedemez çünkü genel özellikler şifreli sunum içindeki karşılık gelen verilerle tutarlı kalmalıdır. Bu nedenle güncelleme, doğru açma şifresi ve tam bir yükleme gerektirir.

Sonraki örnek, [LoadOptions.setPassword](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) ile sunumu açar, genel yerleşik özellikleri günceller ve sonucu kaydeder. Ardından [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--) kullanarak şifrelemenin korunduğunu doğrular ve yeni değerleri kontrol etmek için şifre olmadan genel üst veriyi yeniden açar:

```java
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
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
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

Bir uygulama sunum içeriğini çözmesine veya yüklemesine izin verilmiyorsa, şifreli PPTX dosyasının genel özelliklerini yalnızca okuma izniyle ele almalıdır.

## **Yerleşik Özelliklere Erişim**

Bu özellikler, [IDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idocumentproperties) nesnesi tarafından sunulan: **Creator** (Yazar), **Description**, **Keywords**, **Created** (Oluşturulma Tarihi), **Modified** (Değiştirilme Tarihi), **Printed** (Son Yazdırma Tarihi), **LastModifiedBy**, **SharedDoc** (Farklı üreticiler arasında paylaşılıyor mu?), **PresentationFormat**, **Subject** ve **Title**

```java
import com.aspose.slides.*;

// Sunumu temsil eden Presentation sınıfının bir örneğini oluşturun
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

Yerleşik sunum dosyası özelliklerini değiştirmek, onlara erişmek kadar kolaydır. İstediğiniz herhangi bir özelliğe bir metin değeri atayabilir ve özellik değeri değişir. Aşağıdaki örnekte, Aspose.Slides for Android via Java kullanarak sunum dosyasının yerleşik belge özelliklerini nasıl değiştirebileceğimizi gösterdik.

```java
import com.aspose.slides.*;

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

Bu örnek, aşağıda gösterildiği gibi, değiştirilen yerleşik belge özelliklerini gösterir:

|**Değiştirme sonrası yerleşik belge özellikleri**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Özel Belge Özellikleri Ekleme**

Aspose.Slides for Android via Java, geliştiricilerin sunum belge özelliklerine özel değerler eklemesine de izin verir. Aşağıdaki örnek üç özel özellik ekler, ardından indeks 2'de saklanan adı bulur ve bu özelliği kaldırır; böylece kaydedilen sunum iki özelliği tutar. Özel özellikler, eklenme sırasına değil alfabetik sıraya göre indekslenir.

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
    
    // Belirli indeksdeki özellik adını alma
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Seçilen özelliği kaldırma
    dProps.removeCustomProperty(getPropertyName);
    
    // Sunumu kaydetme
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Eklenmiş Özel Belge Özellikleri**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Özel Özelliklere Erişim ve Değiştirme**

Aspose.Slides for Android via Java, geliştiricilerin özel özellik değerlerine erişmesine de izin verir. Aşağıdaki örnek, bir sunum için bu özel özelliklerin tümüne nasıl erişileceğini ve değiştirileceğini gösterir.

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

Bu örnek, [PPTX](https://docs.fileformat.com/presentation/pptx/) sunumunun özel özelliklerini değiştirir. Aşağıdaki görseller, özelleştirilmiş özelliklerin değişiklik öncesi ve sonrası durumunu gösterir:

|**Değişiklik Öncesi Özel Özellikler**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Değişiklik Sonrası Özel Özellikler**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Gelişmiş Belge Özellikleri**

{{% alert color="info" title="Not" %}}
Yeni yöntemler [ReadDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), ve [WriteBindedPresentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) [IPresentationInfo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPresentationInfo)'a eklenmiştir; [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) özelliğinin ayarlayıcı mantığı değiştirilmiştir.
{{% /alert %}} 

İki yeni yöntem [ReadDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) ve [UpdateDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) [IPresentationInfo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPresentationInfo) arayüzüne eklenmiştir. Bu yöntemler belge özelliklerine hızlı erişim sağlar ve tüm bir sunumu yüklemeden özellikleri değiştirmeye ve güncellemeye izin verir.

Tipik senaryo, özellikleri yüklemek, bir değeri değiştirmek ve belgeyi güncellemek aşağıdaki şekilde uygulanabilir:

```java
import com.aspose.slides.*;

// sunumun bilgilerini oku
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// mevcut özellikleri elde et
IDocumentProperties props = info.readDocumentProperties();

// Yazar ve Başlık alanlarının yeni değerlerini ayarla
props.setAuthor("New Author");
props.setTitle("New Title");

// sunumu yeni değerlerle güncelle
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Belirli bir sunumun özelliklerini şablon olarak kullanarak diğer sunumların özelliklerini güncellemenin başka bir yolu daha bulunmaktadır:

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

Sıfırdan yeni bir şablon oluşturulabilir ve ardından birden çok sunumu güncellemek için kullanılabilir:

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

## **Denetim Dili Ayarlama**

Aspose.Slides, PowerPoint belgesi için denetim dilini ayarlamanıza izin veren LanguageId özelliğini (PortionFormat sınıfı tarafından sunulur) sağlar. Denetim dili, PowerPoint'te yazım ve dilbilgisi denetiminin yapıldığı dildir.

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

    portionFormat.setLanguageId("zh-CN"); // denetim dili kimliğini ayarla

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Varsayılan Dil Ayarlama**

Bu Java kodu, bir PowerPoint sunumunun tamamı için varsayılan dili nasıl ayarlayacağınızı gösterir:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Yeni bir dikdörtgen şekil ekleyip metin ekler
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // İlk bölümün dilini kontrol eder
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Canlı Örnek**

[**Aspose.Slides Metadata**](https://products.aspose.app/slides/tr/metadata) çevrimiçi uygulamasını deneyin ve Aspose.Slides API'si üzerinden belge özellikleriyle nasıl çalışılacağını görün:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/tr/metadata)

## **SSS**

**Bir sunumdan yerleşik bir özelliği nasıl kaldırabilirim?**

Yerleşik özellikler, sunumun ayrılmaz bir parçasıdır ve tamamen kaldırılamaz. Ancak, çoğu durumda değerlerini değiştirebilir veya özellik izin veriyorsa boş bir değer atayabilirsiniz.

**Zaten var olan bir özel özelliği eklersem ne olur?**

Var olan bir özel özelliği eklerseniz, mevcut değeri yeni değerle üzerine yazılır. Özelliği önceden kaldırmanıza veya kontrol etmenize gerek yoktur; Aspose.Slides otomatik olarak özelliğin değerini günceller.

**Sunumu tamamen yüklemeden sunum özelliklerine erişebilir miyim?**

Evet. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) kullanın ve ardından [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) ile bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) örneği oluşturmadan saklanan belge üst veri bilgilerini okuyun. Tam raporlama örneği ve format‑spesifik sınırlamalar için [Build a Lightweight Presentation Inventory](/slides/tr/androidjava/examine-presentation/) sayfasına bakın.

**Şifreli bir sunumun genel özelliklerini açma şifresi olmadan okuyabilir miyim?**

Evet. Belge‑özelliği şifrelemesi, sunum şifrelenmeden önce devre dışı bırakılmış olmalı ve sunum belge‑özellikleri‑yalnızca modunda yüklenmelidir.

**Belge‑özellikleri‑yalnızca modunda şifreli bir PPTX dosyasını güncelleyebilir miyim?**

Hayır. Genel ve şifreli özellik verileri tutarlı olmalıdır; bu yüzden şifreli bir PPTX dosyasını güncellemek, doğru açma şifresiyle tam sunumu yüklemeyi gerektirir.