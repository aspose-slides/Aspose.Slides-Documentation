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
- özellikleri yönetme
- özellikleri değiştirme
- belge üst verileri
- üst verileri düzenleme
- düzeltme dili
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da sunum özelliklerini yöneterek PowerPoint ve OpenDocument dosyalarınızda aramayı, markalaşmayı ve iş akışını düzene sokun."
---
## **Giriş**

Aspose.Slides iki tür belge özelliğini destekler: **Yerleşik** ve **Özel**. Bu özellik türlerinin her ikisine de Aspose.Slides API'si kullanılarak kolayca erişilebilir ve yönetilebilir.

Aspose.Slides, sunum belge özellikleriyle [IDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idocumentproperties/) arabirimi aracılığıyla çalışmanıza olanak tanır. Bu arabirimin bir örneği, [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentation/#getDocumentProperties--) tarafından döndürülür. Aşağıdaki örnekler bu özelliklerin nasıl okunacağını, değiştirileceğini ve yönetileceğini gösterir.

{{% alert color="info" title="Not" %}}
Lütfen **Application** ve **AppVersion** alanlarının değiştirilemeyeceğini unutmayın. Aspose.Slides her kaydetmede bu alanları yeniden yazar, bu yüzden kaydedilen bir sunum her zaman "Aspose.Slides for Java" ve onu oluşturan kütüphanenin sürümünü raporlar. `setNameOfApplication` metoduna geçirilen herhangi bir değer, sunum yazıldığında göz ardı edilir.
{{% /alert %}} 

## **PowerPoint'teki Belge Özellikleri**

Microsoft PowerPoint 2007, sunum dosyalarının belge özelliklerini yönetmenize olanak tanır. Tek yapmanız gereken, aşağıda gösterildiği gibi Office simgesine tıklamak ve ardından Microsoft PowerPoint 2007'de **Prepare | Properties | Advanced Properties** menü öğesini seçmektir:

|**Advanced Properties menü öğesini seçme**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
**Advanced Properties** menü öğesini seçtikten sonra, aşağıdaki şekilde gösterilen PowerPoint dosyasının belge özelliklerini yönetmenize izin veren bir iletişim kutusu açılır:

|**Özellikler İletişim Kutusu**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Yukarıdaki **Özellikler İletişim Kutusu**'nda **General**, **Summary**, **Statistics**, **Contents** ve **Custom** gibi birçok sekme sayfası olduğunu görebilirsiniz. Bu sekme sayfaları PowerPoint dosyalarıyla ilgili farklı bilgi türlerini yapılandırmaya izin verir. **Custom** sekmesi PowerPoint dosyalarının özel özelliklerini yönetmek için kullanılır.

## **Aspose.Slides for Java Kullanarak Belge Özellikleriyle Çalışma**

Daha önce belirttiğimiz gibi Aspose.Slides for Java iki tür belge özelliğini destekler: **Yerleşik** ve **Özel** özellikler. Bu sayede geliştiriciler Aspose.Slides for Java API'si sayesinde her iki tür özelliğe de erişebilir. Aspose.Slides for Java, **Presentation.DocumentProperties** özelliği aracılığıyla bir sunum dosyasıyla ilişkili belge özelliklerini temsil eden [IDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idocumentproperties) sınıfını sağlar.

Geliştiriciler, aşağıda açıklandığı gibi sunum dosyalarının belge özelliklerine erişmek için [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) nesnesi tarafından sunulan **IDocumentProperties** özelliğini kullanabilirler:

## **Şifreli Sunumdan Genel Özellikleri Okuma**

Açma parolası genellikle hem sunum içeriğini hem de belge özelliklerini korur. Bir sunum, [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-)’ye `false` geçirilerek şifrelenirse, belge özellikleri hâlâ genel olur. Uygulama daha sonra [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-)’ye `true` geçirerek açma parolası sağlamadan genel üst verileri okuyabilir.

Belge‑özellikleri‑yalnızca seçeneği Aspose.Slides’ın neyi yüklediğini kontrol eder; hiçbir şeyi şifre çözmez. Özellikler şifreleme içinde dahil edilmişse, parolasız yükleme başarısız olur. Sunum şifrelenmemişse, seçenek yok sayılır ve tam sunum yüklenir.

Aşağıdaki örnek, [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) aracılığıyla yükleme modunu doğrular ve ardından [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentation/#getDocumentProperties--) ile yerleşik özellikleri okur:

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

Bu modda slayt içeriği yüklenmez. Slaytlar, ana şablonlar, yerleşimler, şekiller, medya ve diğer sunum nesneleri kullanılamaz. Uygulamalar, tam sunum nesne modelini gerektiren bir işlem yapmadan önce her zaman [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) kontrol etmelidir.

{{% alert color="warning" title="Uyarı" %}}
Genel üst veriler yazar adları, başlıklar, konular, anahtar kelimeler, şirket bilgileri, yorumlar ve özel değerleri ifşa edebilir. Hassas özellikleri sunumla birlikte şifreleyin. Yalnızca indeksleme, sınıflandırma, arama veya belge‑yönetim sistemlerinin şifre olmadan erişim gerektirdiği durumlarda genelde tutun.
{{% /alert %}}

## **Şifreli Sunumun Özelliklerini Güncelleme**

Şifreli bir PPTX dosyası için belge‑özellikleri‑yalnızca modunda yüklenen bir sunum, genel üst verileri okumak için tasarlanmıştır. Aspose.Slides bu yalnızca‑metadata nesnesinden değiştirilen özellikleri kaydedemez çünkü genel özellikler şifreli sunum içindeki ilgili verilerle tutarlı olmalıdır. Bu nedenle güncelleme doğru açma parolası ve tam yükleme gerektirir.

Aşağıdaki örnek, [LoadOptions.setPassword](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) ile sunumu açar, genel yerleşik özellikleri günceller ve sonucu kaydeder. Ardından [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationinfo/#isEncrypted--) ile şifrelemenin korunduğunu doğrular ve yeni değerleri kontrol etmek için genel üst verileri parolasız yeniden açar:

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

Bir uygulama sunum içeriğini çözümleyemez veya yükleyemezse, şifreli bir PPTX dosyasının genel özelliklerini yalnızca‑okunur olarak ele almalıdır.

## **Yerleşik Özelliklere Erişim**

[IDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idocumentproperties) nesnesi tarafından sunulan bu özellikler şunlardır: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (Farklı üreticiler arasında paylaşılıyor mu?), **PresentationFormat**, **Subject** ve **Title**.

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

Sunum dosyalarının yerleşik özelliklerini değiştirmek, onlara erişmek kadar basittir. İstediğiniz herhangi bir özelliğe bir dize değeri atayabilirsiniz; özellik değeri değişir. Aşağıdaki örnekte, Aspose.Slides for Java kullanarak sunum dosyasının yerleşik belge özelliklerini nasıl değiştirebileceğimizi gösterdik.

```java
import com.aspose.slides.*;

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

Bu örnek, aşağıdaki gibi görüntülenebilen yerleşik özellikleri değiştirir:

|**Değiştirme Sonrası Yerleşik Belge Özellikleri**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Özel Belge Özellikleri Ekleme**

Aspose.Slides for Java ayrıca geliştiricilerin sunum belge özelliklerine özel değerler eklemesine olanak tanır. Aşağıdaki örnek üç özel özellik ekler, ardından 2. indeksdeki adı arar ve bu özelliği kaldırır; böylece kaydedilen sunum iki özelliği tutar. Özel özellikler alfabetik sıraya göre indekslenir, eklenme sırasına göre değil.

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

|**Eklenmiş Özel Belge Özellikleri**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Özel Özelliklere Erişim ve Değiştirme**

Aspose.Slides for Java ayrıca geliştiricilerin özel özellik değerlerine erişmesine olanak tanır. Aşağıdaki örnek, bir sunum için bu özel özelliklerin tümüne nasıl erişileceğini ve değiştirileceğini göstermektedir.

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

Bu örnek, [PPTX](https://docs.fileformat.com/presentation/pptx/) sunumunun özel özelliklerini değiştirir. Aşağıdaki figürler, değiştirmeden önce ve sonra sunum özel özelliklerini gösterir:

|**Değiştirmeden Önce Özel Özellikler**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Değiştirmeden Sonra Özel Özellikler**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Gelişmiş Belge Özellikleri**

{{% alert color="info" title="Not" %}}
Yeni yöntemler [ReadDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), ve [WriteBindedPresentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) [IPresentationInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPresentationInfo) aracılığıyla eklendi, [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) özelliğinin ayarlayıcısının mantığı değiştirildi.
{{% /alert %}} 

Yeni eklenen iki yöntem [ReadDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) ve [UpdateDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) [IPresentationInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPresentationInfo) arayüzüne eklenmiştir. Bu yöntemler belge özelliklerine hızlı erişim sağlar ve tüm sunumu yüklemeden özellikleri değiştirmeye ve güncellemeye izin verir.

Tipik senaryo, özellikleri yüklemek, bazı değerleri değiştirmek ve belgeyi güncellemek aşağıdaki şekilde uygulanabilir:

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

Belirli bir sunumun özelliklerini başka sunumlarda güncellemek için şablon olarak kullanmanın başka bir yolu vardır:

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

Aspose.Slides, PowerPoint belgesi için düzeltme dili ayarlamanıza izin veren LanguageId özelliğini (PortionFormat sınıfı tarafından sunulur) sağlar. Düzeltme dili, PowerPoint’te imla ve dilbilgisi kontrolünün yapılacağı dildir.

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

Belge özellikleriyle Aspose.Slides API'si aracılığıyla nasıl çalışılacağını görmek için çevrimiçi uygulamayı deneyin:

[![PowerPoint Metaverisini Görüntüle ve Düzenle](slides-metadata.png)](https://products.aspose.app/slides/tr/metadata)

## **SSS**

**Bir sunumdan yerleşik bir özelliği nasıl kaldırabilirim?**

Yerleşik özellikler sunumun ayrılmaz bir parçasıdır ve tamamen kaldırılamaz. Ancak, izin verilen durumlarda değerlerini değiştirebilir veya boş bir değere ayarlayabilirsiniz.

**Zaten var olan bir özel özelliği eklersem ne olur?**

Zaten var olan bir özel özellik eklenirse, mevcut değeri yeni değerle üzerine yazılır. Özelliği önceden kaldırıp kontrol etmenize gerek yoktur; Aspose.Slides otomatik olarak değeri günceller.

**Sunumu tamamen yüklemeden sunum özelliklerine erişebilir miyim?**

Evet. Önce [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) kullanın, ardından [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) ile bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) örneği oluşturmadan depolanmış belge üst verilerini okuyun. Tam raporlama örneği ve format‑spesifik sınırlamalar için [Build a Lightweight Presentation Inventory](/slides/tr/java/examine-presentation/) sayfasına bakın.

**Şifreli bir sunumun genel özelliklerini açma parolası olmadan okuyabilir miyim?**

Evet. Belge‑özelliği şifrelemesi, sunum şifrelenmeden önce devre dışı bırakılmış olmalı ve sunum belge‑özellikleri‑yalnızca modunda yüklenmelidir.

**Şifreli bir PPTX dosyasını belge‑özellikleri‑yalnızca modunda güncelleyebilir miyim?**

Hayır. Genel ve şifreli özellik verileri tutarlı olmalıdır; bu nedenle şifreli bir PPTX dosyasını güncellemek, doğru açma parolasıyla tam sunumu yüklemeyi gerektirir.