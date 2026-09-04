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
- doğrulama dili
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te sunum özelliklerini yöneterek PowerPoint ve OpenDocument dosyalarınızda aramayı, markalaştırmayı ve iş akışını kolaylaştırın."
---
## **Giriş**

Aspose.Slides for .NET iki tür belge özelliğini destekler: **Built-in** ve **Custom**. Bu özellik türlerinin her ikisine de Aspose.Slides for .NET API'si kullanılarak kolayca erişilebilir ve yönetilebilir.

Aspose.Slides, sunum belge özellikleriyle [IDocumentProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/idocumentproperties/) arabirimi aracılığıyla çalışmanıza olanak tanır. Bu arabirimin bir örneği, [IPresentation.DocumentProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentation/documentproperties/) aracılığıyla döndürülür. Aşağıdaki örnekler, bu özelliklerin nasıl okunacağını, değiştirileceğini ve yönetileceğini gösterir.

{{% alert color="info" title="Note" %}}
Lütfen **Application** ve **Producer** alanlarının değiştirilemeyeceğini unutmayın; bu alanlar her zaman "Aspose Ltd." ve "Aspose.Slides for .NET x.x.x" olarak görüntülenecektir.
{{% /alert %}} 

## **Sunum Özelliklerini Yönet**

Microsoft PowerPoint, sunum dosyalarına özellik ekleme özelliği sunar. Bu belge özellikleri, dosyalarla birlikte yararlı bilgilerin saklanmasını sağlar. İki tür belge özelliği vardır:

- Sistem tanımlı (built-in) özellikler
- Kullanıcı tanımlı (custom) özellikler

**Built-in** özellikler, belge başlığı, yazar adı, belge istatistikleri ve daha fazlası gibi belge hakkında genel bilgiler içerir.

**Custom** özellikler, kullanıcılar tarafından **Ad/Değer** çiftleri şeklinde tanımlanır; burada hem ad hem değer kullanıcı tarafından belirlenir.

Aspose.Slides for .NET kullanarak, geliştiriciler hem built-in hem de custom özelliklere erişebilir ve bunları değiştirebilir.

Microsoft PowerPoint, kullanıcıların belge özelliklerini Office simgesine tıklayıp **File → Info → Properties** seçeneğini seçerek yönetmelerine izin verir. **Advanced Properties** seçildikten sonra, sunum dosyasının tüm belge özelliklerini yönetebileceğiniz bir iletişim kutusu açılır.

**Properties** iletişim kutusunda, **General**, **Summary**, **Statistics**, **Contents** ve **Custom** gibi çeşitli sekmeler bulunur. Her sekme, PowerPoint dosyasıyla ilgili belirli bilgi türlerini yapılandırma seçenekleri sunar. **Custom** sekmesi, kullanıcı tanımlı özellikleri yönetmek için kullanılır.

## **Şifrelenmiş Bir Sunumdan Genel Özellikleri Okuma**

Bir açma parolası genellikle hem sunum içeriğini hem de belge özelliklerini korur. Bir sunum, [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) `false` olarak ayarlandığında şifrelenirse, belge özellikleri genel olarak kalır. Bir uygulama daha sonra [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) `true` olarak ayarlayarak açma parolasını sağlamadan genel meta verileri okuyabilir.

`OnlyLoadDocumentProperties`, Aspose.Slides'ın neyi yükleyeceğini kontrol eder; herhangi bir şeyi çözümler. Özellikler şifrelemeye dahil edilmişse, parolasız yükleme başarısız olur. Sunum şifrelenmemişse, seçenek yoksayılır ve tam sunum yüklenir.

Aşağıdaki örnek, [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/tr/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) aracılığıyla yükleme modunu doğrular ve ardından [IPresentation.DocumentProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentation/documentproperties/) kullanarak built-in özellikleri okur:

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var properties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + properties.Author);
    Console.WriteLine("Title: " + properties.Title);
    Console.WriteLine("Keywords: " + properties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

Bu modda, slayt içeriği yüklenmez. Slaytlar, masterlar, düzenler, şekiller, medya ve diğer sunum nesneleri kullanılamaz. Uygulamalar, tam sunum nesne modelini gerektiren bir işlem yapmadan önce her zaman `IsOnlyDocumentPropertiesLoaded` kontrol etmelidir.

{{% alert color="warning" title="Security" %}}
Genel meta veriler, yazar adları, başlıklar, konular, anahtar kelimeler, şirket bilgileri, yorumlar ve özel değerler gibi bilgileri ortaya çıkarabilir. Hassas özellikleri sunumla birlikte şifreleyin. Yalnızca indeksleme, sınıflandırma, arama ya da belge yönetim sistemlerinin şifre olmadan erişim gerektirdiği durumlarda genel olarak bırakın.
{{% /alert %}}

## **Şifrelenmiş Bir Sunumun Özelliklerini Güncelleme**

Şifrelenmiş bir PPTX dosyası için, `OnlyLoadDocumentProperties` ile yüklü bir sunum, genel meta verileri okumak için tasarlanmıştır. Aspose.Slides, bu yalnızca meta veri nesnesinden değiştirilen özellikleri kaydedemez çünkü genel özellikler, şifreli sunum içindeki ilgili verilerle tutarlı olmalıdır. Bu nedenle güncelleme için doğru açma parolası ve tam yükleme gerekir.

Aşağıdaki örnek, sunumu [LoadOptions.Password](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/password/) ile açar, genel built-in özellikleri günceller ve sonucu kaydeder. Ardından, şifrelemenin korunduğunu doğrulamak için [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationinfo/isencrypted/) kullanır ve yeni değerleri doğrulamak üzere parolasız olarak genel meta verileri yeniden açar:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

{
    var loadOptions = new LoadOptions { Password = "open_password" };
    using var presentation = new Presentation(inputPath, loadOptions);

    presentation.DocumentProperties.Title = "Updated Product Roadmap";
    presentation.DocumentProperties.Keywords = "roadmap, planning, indexed";
    presentation.Save(outputPath, SaveFormat.Pptx);
}

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

Bir uygulamanın sunum içeriğini çözmesi veya yüklemesi izin verilmiyorsa, şifreli bir PPTX dosyasının genel özelliklerini yalnızca okunabilir olarak ele almalıdır.

## **Built-in Özelliklere Erişim**

Bu özellikler, [IDocumentProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/idocumentproperties/) arabirimi tarafından sunulur ve şunları içerir: **Creator** (Yazar), **Description**, **Keywords**, **Created** (Oluşturulma Tarihi), **Modified** (Değiştirilme Tarihi), **Printed** (Son Yazdırma Tarihi), **LastModifiedBy**, **SharedDoc** (belgenin farklı üreticiler arasında paylaşılıp paylaşılmadığını gösterir), **PresentationFormat**, **Subject**, **Title** ve daha fazlası.

```cs
using Aspose.Slides;

// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Sunumla ilişkilendirilmiş IDocumentProperties türündeki nesneye bir referans al.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Yerleşik (built-in) özellikleri göster.
Console.WriteLine("Category : " + documentProperties.Category);
Console.WriteLine("Content status : " + documentProperties.ContentStatus);
Console.WriteLine("Creation date : " + documentProperties.CreatedTime);
Console.WriteLine("Author : " + documentProperties.Author);
Console.WriteLine("Comments : " + documentProperties.Comments);
Console.WriteLine("Key words : " + documentProperties.Keywords);
Console.WriteLine("Last modified by : " + documentProperties.LastSavedBy);
Console.WriteLine("Manager : " + documentProperties.Manager);
Console.WriteLine("Modified date : " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format : " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date : " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers : " + documentProperties.SharedDoc);
Console.WriteLine("Subject : " + documentProperties.Subject);
Console.WriteLine("Title : " + documentProperties.Title);
```

## **Built-in Özellikleri Değiştirme**

Sunum dosyalarının built-in özelliklerini değiştirmek, onlara erişmek kadar kolaydır. İstediğiniz herhangi bir özelliğe sadece bir string değer atayabilirsiniz ve özelliğin değeri güncellenir. Aşağıdaki örnekte, bir sunum dosyasının built-in belge özelliklerini nasıl değiştireceğimizi gösteriyoruz.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Sunumla ilişkilendirilmiş IDocumentProperties türündeki nesneye bir referans al.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Yerleşik özellikleri ayarla.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// Sunumu bir dosyaya kaydet.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Özel Sunum Özellikleri Ekleme**

Özel sunum özellikleri, geliştiricilerin bir sunum dosyası içinde ek meta veri veya belirli bilgiler saklamasını sağlar. Aspose.Slides, bu özel özellikleri programlı olarak oluşturmayı ve yönetmeyi kolaylaştırır. Aşağıdaki örnekler, sunumlarınıza özel özellik eklemenin nasıl yapılacağını gösterir.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation sınıfının bir örneğini oluştur.
using Presentation presentation = new Presentation();

// Sunumla ilişkilendirilmiş IDocumentProperties türündeki nesneye bir referans al.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Özel özellikleri ekle.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Sunumu bir dosyaya kaydet.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Özel Özelliklere Erişim ve Değiştirme**

Aspose.Slides, geliştiricilerin mevcut özel özelliklere erişmesini ve değerlerini kolayca değiştirmesini de sağlar. Bu işlevsellik, doğru meta verinin korunmasına yardımcı olur ve kullanıcı girişi ya da iş mantığına dayalı dinamik güncellemeleri destekler. Aşağıdaki örnekler, bir sunum içinde özel özellik değerlerini nasıl alıp güncelleyeceğinizi gösterir.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// PPTX dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Sunumla ilişkilendirilmiş IDocumentProperties türündeki nesneye bir referans al.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Özel özelliklere eriş ve değiştir.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // Özel özelliğin adını ve değerini göster.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // Özel özelliğin değerini değiştir.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// Sunumu bir dosyaya kaydet.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Canlı Örnek**

Aspose.Slides API'si ile belge özellikleriyle nasıl çalışılacağını görmek için çevrimiçi uygulama olan [**PowerPoint Meta Verilerini Görüntüle ve Düzenle**](https://products.aspose.app/slides/tr/metadata) deneyin:

[![PowerPoint Meta Verilerini Görüntüle ve Düzenle](slides-metadata.png)](https://products.aspose.app/slides/tr/metadata)

## **SSS**

**Bir sunumdan built-in bir özelliği nasıl kaldırabilirim?**

Built-in özellikler, sunumun ayrılmaz bir parçasıdır ve tamamen kaldırılamaz. Ancak, izin verilen durumlarda değerlerini değiştirebilir veya boş bir değere ayarlayabilirsiniz.

**Zaten var olan bir custom özellik eklersem ne olur?**

Eğer zaten var olan bir custom özelliği eklerseniz, mevcut değeri yeniyle üzerine yazılır. Özelliği önceden kaldırmanıza veya kontrol etmenize gerek yoktur; Aspose.Slides, özelliğin değerini otomatik olarak günceller.

**Sunumun tamamını yüklemeden sunum özelliklerine erişebilir miyim?**

Evet. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/tr/net/aspose.slides/presentationfactory/getpresentationinfo/) ve ardından [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationinfo/readdocumentproperties/) kullanarak bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) örneği oluşturmadan saklanan belge meta verilerini okuyabilirsiniz. Tam bir raporlama örneği ve format‑spesifik sınırlamalar için [Build a Lightweight Presentation Inventory](/slides/tr/net/examine-presentation/) bölümüne bakın.

**Şifrelenmiş bir sunumun genel özelliklerini açma parolası olmadan okuyabilir miyim?**

Evet. Sunum, `EncryptDocumentProperties` `false` olarak ayarlanmış şekilde şifrelenmiş olmalı ve `OnlyLoadDocumentProperties` `true` olarak ayarlanmış şekilde yüklenmiş olmalıdır.

**Belge‑özellikleri‑yalnızca modunda şifreli bir PPTX dosyasını güncelleyebilir miyim?**

Hayır. Genel ve şifreli özellik verileri tutarlı olmalıdır; bu nedenle şifreli bir PPTX dosyasını güncellemek, doğru açma parolasıyla tam sunumu yüklemeyi gerektirir.