---
title: .NET'te Sunum Özelliklerini Yönet
linktitle: Sunum Özellikleri
type: docs
weight: 70
url: /tr/net/presentation-properties/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te sunum özelliklerini yönetin ve PowerPoint ve OpenDocument dosyalarınızda aramayı, markalamayı ve iş akışını kolaylaştırın."
---
## **Giriş**

Aspose.Slides for .NET **yerleşik** ve **özel** belge özelliklerini destekler. Sunum meta verilerini, yazar, başlık ve kullanıcı tanımlı değerler gibi, okumak ve güncellemek için bu özellikleri kullanın.

Aspose.Slides, sunum belge özellikleriyle [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) arayüzü aracılığıyla çalışmanıza olanak tanır. Bu arayüzün bir örneği [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) tarafından döndürülür. Aşağıdaki örnekler, bu özellikleri nasıl okuyacağınızı, değiştireceğinizi ve yöneteceğinizi gösterir.

{{% alert color="info" title="Note" %}}
Aspose.Slides, sunumları kaydederken uygulama ve üretici meta verilerini yönetir; bu alanlar çıktıyı oluşturan yazılımı tanımlar.
{{% /alert %}}

## **Sunum Özelliklerini Yönet**

Belge özellikleri, sunum içeriğiyle birlikte tanımlayıcı bilgiler depolar. İki kategoriye ayrılırlar:

- **Yerleşik özellikler** başlık, yazar ve belge istatistikleri gibi standart meta verileri içerir.
- **Özel özellikler** kullanıcı tanımlı ad/değer çiftlerini depolar.

Aspose.Slides for .NET her iki kategoriye de erişim sağlar. PowerPoint'te belge meta verilerini incelemek için **File → Info → Properties → Advanced Properties** seçeneğini seçin. İletişim kutusu bilgileri **Summary**, **Statistics**, **Contents** ve **Custom** gibi sekmelere ayırır. Kullanıcı tanımlı özellikleri yönetmek için **Custom** sekmesini kullanın.

## **Şifrelenmiş Bir Sunumdan Genel Özellikleri Okuma**

Bir açma şifresi genellikle sunum içeriğini ve belge özelliklerini korur. Bir sunum, [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) `false` olarak ayarlandığında şifrelenirse, belge özellikleri genel kalır. Bir uygulama daha sonra [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) `true` olarak ayarlayıp açma şifresi vermeden genel meta verileri okuyabilir.

[LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) Aspose.Slides'ın neyi yükleyeceğini kontrol eder; hiçbir şeyi şifre çözmez. Özellikler şifreleme içine dahil edilmişse, şifre olmadan yükleme başarısız olur. Sunum şifrelenmemişse, seçenek yok sayılır ve tam sunum yüklenir.

Örnek, belge özellikleri genel bırakılmış şifreli bir sunum gerektirir. Yükleme modunu [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) aracılığıyla doğrular ve ardından [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) üzerinden yerleşik özellikleri okur:

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var documentProperties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + documentProperties.Author);
    Console.WriteLine("Title: " + documentProperties.Title);
    Console.WriteLine("Keywords: " + documentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

Bu modda slayt içeriği yüklenmez. Slaytlar, masterlar, düzenler, şekiller, medya ve diğer sunum nesneleri erişilemez. Uygulamalar, tam sunum nesne modelini gerektiren bir işlem yapmadan önce her zaman [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) kontrol etmelidir.

{{% alert color="warning" title="Security" %}}
Genel meta veriler, yazar adları, başlıklar, konular, anahtar kelimeler, şirket bilgileri, yorumlar ve özel değerleri ortaya çıkarabilir. Hassas özellikleri sunumla birlikte şifreleyin. Yalnızca indeksleme, sınıflandırma, arama veya belge yönetim sistemlerinin şifre olmadan erişim gerektirdiği durumlarda genel bırakın.
{{% /alert %}}

## **Şifreli Bir Sunumun Özelliklerini Güncelleme**

Şifreli bir PPTX dosyası için, [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) ile yüklenen bir sunum, genel meta verileri okumak içindir. Aspose.Slides, bu yalnızca meta veri nesnesindeki değiştirilen özellikleri kaydedemez çünkü genel özellikler şifreli sunum içindeki karşılık gelen verilerle tutarlı olmalıdır. Bu nedenle güncelleme, doğru açma şifresi ve tam bir yükleme gerektirir.

Örnek, genel belge özelliklerine sahip şifreli bir PPTX sunumu ve bilinen bir açma şifresi gerektirir. Tam sunumu [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) ile açar, genel yerleşik özellikleri günceller ve sonucu kaydeder. Ardından şifrelemenin korunduğunu doğrulamak için [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/isencrypted/) kullanır ve yeni değerleri doğrulamak amacıyla şifre olmadan genel meta verileri yeniden açar:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation(inputPath, loadOptions);

var documentProperties = presentation.DocumentProperties;
documentProperties.Title = "Updated Product Roadmap";
documentProperties.Keywords = "roadmap, planning, indexed";

presentation.Save(outputPath, SaveFormat.Pptx);

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(outputPath);
Console.WriteLine("The presentation is encrypted: " + presentationInfo.IsEncrypted);

var metadataLoadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var metadataPresentation = new Presentation(outputPath, metadataLoadOptions);

if (metadataPresentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    Console.WriteLine("Title: " + metadataPresentation.DocumentProperties.Title);
    Console.WriteLine("Keywords: " + metadataPresentation.DocumentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

Bir uygulamanın sunum içeriğini şifre çözer veya yükler izni yoksa, şifreli bir PPTX dosyasının genel özelliklerini yalnızca okunabilir olarak ele almalıdır.

## **Yerleşik Özelliklere Erişim**

[IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) arayüzü, [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/), [CreatedTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/createdtime/) gibi tiplenmiş özellikler aracılığıyla yerleşik meta verileri ortaya çıkarır. Bu örnek mevcut bir sunumu açar ve depolanmış meta verilerini konsola yazdırır. Değerler giriş sunumuna bağlıdır; bazı alanlar boş olabilir.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AccessBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

Console.WriteLine("Category: " + documentProperties.Category);
Console.WriteLine("Content status: " + documentProperties.ContentStatus);
Console.WriteLine("Creation date: " + documentProperties.CreatedTime);
Console.WriteLine("Author: " + documentProperties.Author);
Console.WriteLine("Comments: " + documentProperties.Comments);
Console.WriteLine("Keywords: " + documentProperties.Keywords);
Console.WriteLine("Last modified by: " + documentProperties.LastSavedBy);
Console.WriteLine("Manager: " + documentProperties.Manager);
Console.WriteLine("Modified date: " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format: " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date: " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers: " + documentProperties.SharedDoc);
Console.WriteLine("Subject: " + documentProperties.Subject);
Console.WriteLine("Title: " + documentProperties.Title);
```

## **Yerleşik Özellikleri Değiştirme**

Yerleşik meta verileri güncellemek için, [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) tarafından sunulan yazılabilir özelliklere değer atayın. Bu örnek mevcut bir sunumu açar, [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/), [Subject](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/subject/), [Comments](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/comments/), ve [Manager](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/manager/) ayarlar, ardından güncellenmiş sunumu [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) ile kaydeder. Kaydedilen PPTX yeni meta verileri içerir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ModifyBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Hipermetin Temelini Yönetme**

[IDocumentProperties.HyperlinkBase](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/hyperlinkbase/) belge düzeyinde göreceli hipermetinler için temel adresi saklar. Bu, bir sunumu ve ona bağlı dosyaları başka bir konuma taşırken faydalıdır. Bu, tek bir hipermetnin [IHyperlink.ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) öğesinden ayrı bir özelliktir; temeli değiştirmek saklanan bağlantı adreslerini yeniden yazmaz veya mutlak hedefleri değiştirmez.

Örnek, `target.html` gibi bir göreceli bağlantı ve `https://example.org/absolute.html` gibi bir mutlak bağlantı içeren bir sunum gerektirir. Mevcut temeli okur, yeni bir temel adres atar ve değeri kontrol etmek için sunumu kaydedip yeniden açar. Ardından temeli `string.Empty` ile temizler ve ayrı bir kaydedilmiş dosyada boş değeri doğrular. Örnek temel adresini bağlantılı dosyalarınızın konumuyla değiştirin.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("hyperlinks.pptx");
Console.WriteLine("Original base: " + presentation.DocumentProperties.HyperlinkBase);

const string newBase = "https://example.com/new/";
presentation.DocumentProperties.HyperlinkBase = newBase;
presentation.Save("hyperlinks-updated.pptx", SaveFormat.Pptx);

using var updatedPresentation = new Presentation("hyperlinks-updated.pptx");
Console.WriteLine("Base preserved: " + (updatedPresentation.DocumentProperties.HyperlinkBase == newBase));

updatedPresentation.DocumentProperties.HyperlinkBase = string.Empty;
updatedPresentation.Save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

using var clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
Console.WriteLine("Base cleared: " + (clearedPresentation.DocumentProperties.HyperlinkBase == string.Empty));
```

İki doğrulama mesajı `True` yazdırmalıdır. Temelin temizlenmesi, tek tek hipermetin adreslerini bozulmadan bırakır.

Bir göreceli bağlantı `target.pptx` `old/target.pptx` dosyasını, temel `old` klasörüne işaret ettiğinde açtı. Temel `new` klasörüne değiştirildikten, kaydedilip sunum yeniden açıldığında aynı bağlantı `new/target.pptx` dosyasını açtı. Mutlak bir bağlantı aynı dosyayı açmaya devam etti. Göreceli bağlantılarınızı PowerPoint'te sunumu taşımadan önce ve sonra test edin.

## **Sunuma Özel Özellikler Ekleme**

Özel özellikler, karşılık gelen bir yerleşik alanı olmayan meta verileri depolar. [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) bir özellik adına değer atamanıza izin verir. Bu örnek bir sunum oluşturur, iki metin değeri ve bir tamsayı sürüm değeri ekler ve sunumu [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) ile kaydeder. Mevcut bir ada değer atamak, o özelliğin değerini değiştirir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var documentProperties = presentation.DocumentProperties;

documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Özel Özelliklere Erişim ve Değiştirme**

Bu örnek, özel özellikler içeren bir sunumu açar ve [CountOfCustomProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/countofcustomproperties/) kullanarak bunlar üzerinde döner. [GetCustomPropertyName](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/getcustompropertyname/) sıfır tabanlı bir indeks alır ve [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) tarafından kullanılan adı döndürür. Örnek, her özgün adı ve değeri yazdırır, her değeri orijinal türünden bağımsız olarak numaralı bir metinle değiştirir ve değişiklikleri kaydeder. Özel özellik yoksa, döngü herhangi bir değişiklik yapmaz.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AccessAndModifyProperties.pptx");

var documentProperties = presentation.DocumentProperties;

for (var i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    var propertyName = documentProperties.GetCustomPropertyName(i);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine("Custom property name: " + propertyName);
    Console.WriteLine("Custom property value: " + propertyValue);

    documentProperties[propertyName] = "New Value " + (i + 1);
}

presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Canlı Örnek**

[Try the **View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) online app to see how to work with document properties using the Aspose.Slides API:

[![Görüntüle & Düzenle PowerPoint Meta Verileri](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **SSS**

**Bir sunumdan yerleşik bir özelliği nasıl kaldırabilirim?**

Yerleşik özellikler, sunumun bütünleyici bir parçasıdır ve tamamen kaldırılamaz. Ancak, değerlerini değiştirebilir veya ilgili özellik izin veriyorsa boş olarak ayarlayabilirsiniz.

**Zaten mevcut olan bir özel özellik eklersem ne olur?**

Zaten var olan bir özel özellik eklenirse, mevcut değeri yeni değerle üzerine yazılır. Özelliği önceden kaldırmanıza veya kontrol etmenize gerek yoktur; Aspose.Slides özelliğin değerini otomatik olarak günceller.

**Sunumu tamamen yüklemeden sunum özelliklerine erişebilir miyim?**

Evet. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) kullanın ve ardından [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) aracılığıyla bir [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) örneği oluşturmadan depolanmış belge meta verilerini okuyun. Tam raporlama örneği ve format‑spesifik sınırlamalar için [**Hafif Sunum Envanteri Oluşturma**](/slides/tr/net/examine-presentation/) sayfasına bakın.

**Şifreli bir sunumun açma şifresi olmadan genel özelliklerini okuyabilir miyim?**

Evet. Sunum, [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) `false` olarak ayarlanmış şekilde şifrelenmiş olmalı ve [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) `true` olarak ayarlanarak yüklenmelidir.

**Belge‑özellikleri‑sadece modunda şifreli bir PPTX dosyasını güncelleyebilir miyim?**

Hayır. Genel ve şifreli özellik verileri tutarlı olmalıdır; bu yüzden şifreli bir PPTX dosyasını güncellemek, doğru açma şifresiyle tam sunumu yüklemeyi gerektirir.