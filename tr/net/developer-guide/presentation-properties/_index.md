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
- özellikleri yönetme
- özellikleri değiştirme
- belge meta verileri
- meta verileri düzenleme
- düzeltme dili
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te sunum özelliklerini yönetin ve PowerPoint ve OpenDocument dosyalarınızda aramayı, markalaşmayı ve iş akışını kolaylaştırın."
---
## **Giriş**

Aspose.Slides for .NET **yerleşik** ve **özel** belge özelliklerini destekler. Bu özellikleri yazar, başlık ve kullanıcı tanımlı değerler gibi sunum meta verilerini okumak ve güncellemek için kullanın.

Aspose.Slides, sunum belge özellikleriyle çalışmanıza izin verir; bunu [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) arayüzü üzerinden yapabilirsiniz. Bu arayüzün bir örneği [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) tarafından döndürülür. Aşağıdaki örnekler bu özellikleri nasıl okuyacağınızı, değiştireceğinizi ve yöneteceğinizi gösterir.

{{% alert color="info" title="Not" %}}

Aspose.Slides, sunumları kaydederken uygulama ve üretici meta verilerini yönetir; bu alanlar çıktıyı oluşturan yazılımı tanımlar.

{{% /alert %}}

## **Sunum Özelliklerini Yönet**

Belge özellikleri, sunum içeriğiyle birlikte tanımlayıcı bilgiler depolar. İki kategoriye ayrılırlar:

- **Yerleşik özellikler** başlık, yazar ve belge istatistikleri gibi standart meta verileri içerir.
- **Özel özellikler** kullanıcı tanımlı ad/değer çiftlerini depolar.

Aspose.Slides for .NET her iki kategoriye de erişim sağlar. PowerPoint’te **File → Info → Properties → Advanced Properties** seçeneğini seçerek belge meta verilerini inceleyebilirsiniz. İletişim kutusu bilgileri **Summary**, **Statistics**, **Contents** ve **Custom** sekmelerine ayırır. Kullanıcı tanımlı özellikleri yönetmek için **Custom** sekmesini kullanın.

## **Şifreli Sunumdan Genel Özellikleri Okuma**

Açma şifresi genellikle hem sunum içeriğini hem de belge özelliklerini korur. Bir sunum, [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) `false` olarak ayarlandığında şifrelenirse, belge özellikleri genel kalır. Uygulama daha sonra [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) `true` olarak ayarlayabilir ve açma şifresi sağlamadan genel meta verileri okuyabilir.

[LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) Aspose.Slides’ın neyi yükleyeceğini kontrol eder; hiçbir şeyi çözmez. Özellikler şifrelemeye dahil edilmişse, şifre olmadan yükleme başarısız olur. Sunum şifrelenmemişse, seçenek yok sayılır ve tam sunum yüklenir.

Örnek, belge özellikleri genel bırakılmış bir şifreli sunum gerektirir. Yükleme modunu [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) ile doğrular ve ardından [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) üzerinden yerleşik özellikleri okur:

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

Bu modda slayt içeriği yüklenmez. Slaytlar, ana şablonlar, yerleşimler, şekiller, medya ve diğer sunum nesneleri kullanılamaz. Uygulamalar, tam sunum nesne modelini gerektiren bir işlem yapmadan önce her zaman [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) kontrol etmelidir.

{{% alert color="warning" title="Güvenlik" %}}
Genel meta veriler yazar adları, başlıklar, konular, anahtar kelimeler, şirket bilgileri, yorumlar ve özel değerleri ifşa edebilir. Hassas özellikleri sunumla birlikte şifreleyin. Yalnızca indeksleme, sınıflandırma, arama veya belge yönetim sistemlerinin şifresiz erişim gereksinimi olduğunda genel bırakın.
{{% /alert %}}

## **Şifreli Sunumun Özelliklerini Güncelleme**

Şifrelenmiş bir PPTX dosyası için, [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) ile yüklenen bir sunum yalnızca genel meta verileri okumak içindir. Aspose.Slides, bu yalnızca meta veri nesnesinden değiştirilen özellikleri kaydedemez çünkü genel özellikler şifreli sunum içindeki ilgili verilerle tutarlı kalmalıdır. Bu nedenle güncelleme, doğru açma şifresi ve tam yükleme gerektirir.

Örnek, genel belge özelliklerine sahip şifreli bir PPTX sunumu ve bilinen bir açma şifresi gerektirir. Tam sunumu [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) ile açar, genel yerleşik özellikleri günceller ve sonucu kaydeder. Ardından [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/isencrypted/) ile şifrelemenin korunduğunu doğrular ve yeni değerleri teyit etmek için şifresiz olarak genel meta verileri yeniden açar:

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

Bir uygulama sunum içeriğini çözmeye ya da yüklemeye izin verilmemişse, şifreli bir PPTX dosyasının genel özelliklerini yalnızca okuma‑yazma gibi davranmak zorundadır.

## **Yerleşik Özelliklere Erişim**

[IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) arayüzü, [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/) ve [CreatedTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/createdtime/) gibi tiplenmiş özellikler aracılığıyla yerleşik meta verileri ortaya çıkarır. Bu örnek, mevcut bir sunumu açar ve depolanmış meta verilerini konsola yazar. Değerler giriş sunumuna bağlıdır; bazı alanlar boş olabilir.

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

### **Revizyon Numarasını ve Düzenleme Süresini Raporla**

`presentations` klasöründeki her PPTX dosyası için bir satır raporlamak amacıyla, slaytları düzenleme için yüklemeden [ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) çağırarak [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) alınır. `TimeSpan` için standart `c` biçimi, süre 24 saate ulaştığında gün sayısını da içerir.

```csharp
using System;
using System.IO;
using Aspose.Slides;

Console.WriteLine("File | RevisionNumber | TotalEditingTime");
foreach (var path in Directory.EnumerateFiles("presentations", "*.pptx"))
{
    var info = PresentationFactory.Instance.GetPresentationInfo(path);
    var properties = info.ReadDocumentProperties();
    Console.WriteLine($"{Path.GetFileName(path)} | {properties.RevisionNumber} | {properties.TotalEditingTime:c}");
}
```

1 gün, 2 saat ve 5 dakikalık kayıtlı düzenleme süresine sahip bir sunumun örnek çıktısı:

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[RevisionNumber](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/revisionnumber/) yazılabilir meta veridir. Tek başına değeri, sunumun kaç kez kaydedildiğini veya sürüm geçmişini belirleyemez.

[TotalEditingTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/totaleditingtime/) dosyada kaydedilen düzenleme süresidir. `00:00:00` değeri saklanan sürenin sıfır olduğunu gösterir. Bu, kimsenin sunumu düzenlemediğini kanıtlamaz.

## **Yerleşik Özellikleri Değiştir**

Yerleşik meta verileri güncellemek için, [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) tarafından sunulan yazılabilir özelliklere değer atayın. Bu örnek, mevcut bir sunumu açar, [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/), [Subject](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/subject/), [Comments](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/comments/) ve [Manager](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/manager/) ayarlar, ardından güncellenmiş sunumu [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) ile kaydeder. Kaydedilen PPTX yeni meta verileri içerir.

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

## **Köprü Temelini Yönet**

[IDocumentProperties.HyperlinkBase](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/hyperlinkbase/) göreli köprüler için belge‑düzeyinde bir temel depolar. Sunumu ve bağlı dosyalarını başka bir konuma taşırken bu yararlıdır. Bireysel bir köprünün [IHyperlink.ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) adresinden ayrı bir şeydir; temeli değiştirmek saklanan köprü adreslerini yeniden yazmaz ya da mutlak hedefleri değiştirmez.

Örnek, `target.html` gibi bir göreli köprü ve `https://example.org/absolute.html` gibi bir mutlak köprü içeren bir sunum gerektirir. Mevcut temeli okur, yeni bir temel adresi atar ve değeri kontrol etmek için sunumu kaydedip yeniden açar. Ardından temeli `string.Empty` ile temizler ve ayrı bir kaydedilmiş dosyada boş değeri doğrular. Örnek temel adresini bağlı dosyalarınızın konumuyla değiştirin.

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

İki doğrulama mesajı `True` yazdırmalıdır. Temelin temizlenmesi, bireysel köprü adreslerini bozulmaz.

`target.pptx` adlı göreli bir köprü, temel `old` klasörüne işaret ettiğinde `old/target.pptx` dosyasını açtı. Temel `new` klasörüne değiştirildikten, kaydedildikten ve sunum yeniden açıldıktan sonra aynı köprü `new/target.pptx` dosyasını açtı. Mutlak köprü aynı dosyayı açmaya devam etti. Sunumu taşıdıktan veya temelini değiştirdikten sonra göreli köprülerinizi PowerPoint’te test edin.

## **Özel Sunum Özellikleri Ekle**

Özel özellikler, karşılık gelen bir yerleşik alanı olmayan meta verileri depolar. [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) adla bir değer atamanızı sağlar. Bu örnek bir sunum oluşturur, iki metin değeri ve bir tam sayı sürüm değeri ekler ve sunumu [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) ile kaydeder. Mevcut bir ada değer atamak, o özelliğin değerini değiştirir.

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

## **Özel Özelliklere Eriş ve Değiştir**

Bu örnek, özel özellikler içeren bir sunumu açar ve bunlar üzerinde gezinmek için [CountOfCustomProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/countofcustomproperties/) kullanır. [GetCustomPropertyName](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/getcustompropertyname/) sıfır‑tabanlı bir indeks alır ve [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) tarafından kullanılan adı döndürür. Örnek, her orijinal adı ve değeri yazdırır, her değeri türünden bağımsız olarak numaralı bir dizeyle değiştirir ve değişiklikleri kaydeder. Özel özellik yoksa, döngü hiçbir değişiklik yapmaz.

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

[**PowerPoint Metaveri Görüntüle ve Düzenle**](https://products.aspose.app/slides/metadata) çevrimiçi uygulamasını deneyin; Aspose.Slides API’sı ile belge özelliklerini nasıl kullanacağınızı görebilirsiniz:

[![PowerPoint Metaveri Görüntüle ve Düzenle](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **SSS**

**Sunumdan yerleşik bir özelliği nasıl kaldırabilirim?**

Yerleşik özellikler sunumun ayrılmaz bir parçasıdır ve tamamen kaldırılamaz. Ancak, belirli bir özellik izin veriyorsa değerlerini değiştirebilir veya boş olarak ayarlayabilirsiniz.

**Zaten var olan bir özel özellik eklersem ne olur?**

Zaten var olan bir özel özellik eklediğinizde, mevcut değeri yeniyle üzerine yazılır. Özelliği önceden kaldırmanıza veya kontrol etmenize gerek yoktur; Aspose.Slides otomatik olarak değeri günceller.

**Sunum özelliklerine tamamen yüklemeden erişebilir miyim?**

Evet. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) kullanın ve ardından [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) ile bir [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) örneği oluşturulmadan depolanmış belge meta verilerini okuyun. Tam raporlama örneği ve biçim‑spesifik sınırlamalar için [Hafif Sunum Envanteri Oluştur](/slides/tr/net/examine-presentation/) sayfasına bakın.

**Şifreli bir sunumun genel özelliklerini açma şifresi olmadan okuyabilir miyim?**

Evet. Sunum, [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) `false` olarak ayarlanmış şekilde şifrelenmiş olmalı ve [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) `true` olarak yüklenmiş olmalıdır.

**Belge‑özellikleri‑yalnızca modu içinde şifreli bir PPTX dosyasını güncelleyebilir miyim?**

Hayır. Genel ve şifreli özellik verileri tutarlı kalmak zorundadır; bu nedenle şifreli bir PPTX dosyasını güncellemek doğru açma şifresiyle tam sunumu yüklemeyi gerektirir.