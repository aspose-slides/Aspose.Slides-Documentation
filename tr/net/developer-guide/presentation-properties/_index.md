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
description: "Aspose.Slides for .NET içinde sunum özelliklerini yönetin ve PowerPoint ile OpenDocument dosyalarınızda aramayı, markalaşmayı ve iş akışını kolaylaştırın."
---
## **Giriş**

Aspose.Slides for .NET iki tür belge özelliğini destekler: **Built-in** ve **Custom**. Bu özellik türlerinin her ikisine de Aspose.Slides for .NET API'si kullanılarak kolayca erişilebilir ve yönetilebilir.

Aspose.Slides, sunum belge özellikleriyle [IDocumentProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/idocumentproperties/) arayüzü üzerinden çalışmanıza olanak tanır. Bu arayüzün bir örneği [Presentation.DocumentProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/documentproperties/) özelliğiyle döndürülür. Aşağıdaki örnekler bu özellikleri nasıl okuyacağınızı, değiştireceğinizi ve yöneteceğinizi gösterir.

{{% alert color="info" title="Note" %}}
Lütfen **Application** ve **Producer** alanlarının değiştirilemeyeceğini unutmayın; bu alanlar her zaman "Aspose Ltd." ve "Aspose.Slides for .NET x.x.x" değerlerini gösterecektir.
{{% /alert %}} 

## **Sunum Özelliklerini Yönetme**

Microsoft PowerPoint, sunum dosyalarına özellik ekleme özelliği sağlar. Bu belge özellikleri, dosyalarla birlikte faydalı bilgilerin depolanmasına olanak tanır. İki tür belge özelliği vardır:

- Sistem tanımlı (built-in) özellikler
- Kullanıcı tanımlı (custom) özellikler

**Built-in** özellikler, belge başlığı, yazar adı, belge istatistikleri vb. gibi genel bilgi içerir.

**Custom** özellikler, kullanıcılar tarafından **Name/Value** çiftleri şeklinde tanımlanır; ad ve değer her ikisi de kullanıcı tarafından belirtilir.

Aspose.Slides for .NET kullanarak geliştiriciler hem built-in hem de custom özelliklere erişebilir ve bunları değiştirebilir.

Microsoft PowerPoint, kullanıcıların Office simgesine tıklayıp **File → Info → Properties** seçeneğini izleyerek belge özelliklerini yönetmelerine olanak tanır. **Advanced Properties** seçildikten sonra, sunum dosyasının tüm belge özelliklerini yönetebileceğiniz bir iletişim kutusu açılır.

**Properties** iletişim kutusunda, **General**, **Summary**, **Statistics**, **Contents** ve **Custom** gibi çeşitli sekmeler bulunur. Her sekme, PowerPoint dosyasıyla ilgili belirli bilgi türlerini yapılandırma seçenekleri sunar. **Custom** sekmesi, kullanıcı tanımlı özellikleri yönetmek için kullanılır.

## **Built-in Özelliklere Erişim**

Bu özellikler, [IDocumentProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/idocumentproperties/) arayüzü aracılığıyla sunulmuş olup şunları içerir: **Creator** (Yazar), **Description**, **Keywords**, **Created** (Oluşturma Tarihi), **Modified** (Değiştirme Tarihi), **Printed** (Son Yazdırma Tarihi), **LastModifiedBy**, **SharedDoc** (belgenin farklı üreticiler arasında paylaşılıp paylaşılmadığını gösterir), **PresentationFormat**, **Subject**, **Title** ve daha fazlası.

```cs
using Aspose.Slides;

// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Display the Built-in properties.
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

Sunum dosyalarının built-in özelliklerini değiştirmek, onlara erişmek kadar kolaydır. İstediğiniz herhangi bir özelliğe bir dize değeri atamanız yeterlidir ve özelliğin değeri güncellenir. Aşağıdaki örnekte, bir sunum dosyasının built-in belge özelliklerini nasıl değiştireceğimizi gösteriyoruz.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Sunumla ilişkili IDocumentProperties tipindeki nesneye bir referans al.
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

Özel sunum özellikleri, geliştiricilerin bir sunum dosyasında ek meta veriler veya belirli bilgiler depolamasını sağlar. Aspose.Slides, bu özel özellikleri programlı olarak oluşturmayı ve yönetmeyi kolaylaştırır. Aşağıdaki örnekler, sunumlarınıza özel özellikler eklemenizi gösterir.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation sınıfının bir örneğini oluştur.
using Presentation presentation = new Presentation();

// Sunumla ilişkili IDocumentProperties tipindeki nesneye bir referans al.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Özel özellikler ekle.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Sunumu bir dosyaya kaydet.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Özel Özelliklere Erişim ve Değiştirme**

Aspose.Slides ayrıca geliştiricilerin mevcut özel özelliklere erişmesini ve değerlerini kolayca değiştirmesini sağlar. Bu işlevsellik, doğru meta verilerin korunmasına yardımcı olur ve kullanıcı girişi veya iş mantığına dayalı dinamik güncellemeleri destekler. Aşağıdaki örnekler, bir sunum içinde özel özellik değerlerini nasıl alıp güncelleyeceğinizi gösterir.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// PPTX dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Sunumla ilişkili IDocumentProperties tipindeki nesneye bir referans al.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Özel özelliklere eriş ve onları değiştir.
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

Aspose.Slides API'sı kullanarak belge özellikleriyle nasıl çalışılacağını görmek için çevrimiçi uygulama olan [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/tr/metadata)'yi deneyin:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/tr/metadata)

## **SSS**

**Bir sunumdan built-in özelliği nasıl kaldırabilirim?**  
Built-in özellikler, sunumun ayrılmaz bir parçasıdır ve tamamen kaldırılamaz. Ancak, değerlerini değiştirebilir veya ilgili özellik izin veriyorsa boş bir değer atayabilirsiniz.

**Zaten var olan bir özel özelliği eklersem ne olur?**  
Zaten var olan bir özel özellik eklenirse, mevcut değeri yeni değerle üzerine yazılır. Özelliği önceden kaldırmanıza veya kontrol etmenize gerek yoktur; Aspose.Slides özelliğin değerini otomatik olarak günceller.

**Sunumun tümü yüklenmeden sunum özelliklerine erişebilir miyim?**  
Evet. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/tr/net/aspose.slides/presentationfactory/getpresentationinfo/) kullanıp ardından [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationinfo/readdocumentproperties/) ile bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) örneği oluşturmadan depolanan belge meta verilerini okuyabilirsiniz. Tam bir raporlama örneği ve format‑özel sınırlamalar için [Build a Lightweight Presentation Inventory](/slides/tr/net/examine-presentation/) sayfasına bakın.