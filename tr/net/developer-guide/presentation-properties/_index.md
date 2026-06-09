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
description: "Aspose.Slides for .NET'te sunum özelliklerini yönetin ve PowerPoint ve OpenDocument dosyalarınızda arama, markalaşma ve iş akışını kolaylaştırın."
---
## **Giriş**

Aspose.Slides for .NET, iki tür belge özelliğini destekler: **Yerleşik** ve **Özel**. Bu özellik türlerinin her ikisi de Aspose.Slides for .NET API'si kullanılarak kolayca erişilebilir ve yönetilebilir.

Aspose.Slides, sunum belge özellikleriyle [IDocumentProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/idocumentproperties/) arabirimi aracılığıyla çalışmanıza olanak tanır. Bu arabirimin bir örneği, [Presentation.DocumentProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/documentproperties/) özelliği tarafından döndürülür. Aşağıdaki örnekler, bu özelliklerin nasıl okunacağını, değiştirileceğini ve yönetileceğini gösterir.

{{% alert color="primary" %}} 

Lütfen **Application** ve **Producer** alanlarının değiştirilemeyeceğini, bu alanların her zaman "Aspose Ltd." ve "Aspose.Slides for .NET x.x.x" göstereceğini unutmayın.

{{% /alert %}} 

## **Sunum Özelliklerini Yönet**

Microsoft PowerPoint, sunum dosyalarına özellik ekleme özelliği sağlar. Bu belge özellikleri, dosyalarla birlikte faydalı bilgilerin saklanmasına olanak tanır. İki tür belge özelliği vardır:

- Sistem tanımlı (yerleşik) özellikler
- Kullanıcı tanımlı (özel) özellikler

**Yerleşik** özellikler, belge başlığı, yazarın adı, belge istatistikleri ve daha fazlası gibi genel bilgileri içerir.

**Özel** özellikler, hem adın hem de değerin kullanıcı tarafından belirlendiği **Ad/Değer** çiftleri şeklinde kullanıcılar tarafından tanımlanır.

Aspose.Slides for .NET kullanarak, geliştiriciler hem yerleşik hem de özel özelliklere erişebilir ve bunları değiştirebilir.

Microsoft PowerPoint, kullanıcıların belge özelliklerini yönetmesine Office simgesine tıklayıp **File → Info → Properties** seçeneğini seçerek izin verir. **Advanced Properties** seçildikten sonra sunum dosyasının tüm belge özelliklerini yönetebileceğiniz bir iletişim kutusu açılır.

**Properties** iletişim kutusunda, **General**, **Summary**, **Statistics**, **Contents** ve **Custom** gibi çeşitli sekmeler bulunur.
Her sekme, PowerPoint dosyasıyla ilgili belirli bilgi türlerini yapılandırma seçenekleri sunar. **Custom** sekmesi, kullanıcı tanımlı özellikleri yönetmek için kullanılır.

## **Yerleşik Özelliklere Erişim**

Bu özellikler, [IDocumentProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/idocumentproperties/) arabirimi tarafından sunulan, şunları içerir: **Creator** (Yazar), **Description**, **Keywords**, **Created** (Oluşturma Tarihi), **Modified** (Değiştirme Tarihi), **Printed** (Son Yazdırma Tarihi), **LastModifiedBy**, **SharedDoc** (belgenin farklı üreticiler arasında paylaşılıp paylaşılmadığını gösterir), **PresentationFormat**, **Subject**, **Title** ve daha fazlası.

```cs
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
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

## **Yerleşik Özellikleri Değiştirme**

Sunum dosyalarının yerleşik özelliklerini değiştirmek, onlara erişmek kadar kolaydır. İstediğiniz herhangi bir özelliğe sadece bir metin değeri atayabilirsiniz ve özelliğin değeri güncellenir. Aşağıdaki örnekte, bir sunum dosyasının yerleşik belge özelliklerini nasıl değiştireceğinizi gösteriyoruz.

```cs
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Sunumla ilişkili IDocumentProperties tipindeki nesneye bir referans alın.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Yerleşik özellikleri ayarlayın.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// Sunumu bir dosyaya kaydedin.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Özel Sunum Özellikleri Ekleme**

Özel sunum özellikleri, geliştiricilerin bir sunum dosyasında ek meta veri veya belirli bilgiler depolamasını sağlar. Aspose.Slides, bu özel özellikleri programlı olarak oluşturmayı ve yönetmeyi kolaylaştırır. Aşağıdaki örnekler, sunumlarınıza özel özellikler nasıl ekleyeceğinizi gösterir.

```cs
// Presentation sınıfını örnekleyin.
using Presentation presentation = new Presentation();

// Sunumla ilişkili IDocumentProperties tipindeki nesneye bir referans alın.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Özel özellikleri ekleyin.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Sunumu bir dosyaya kaydedin.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Özel Özelliklere Erişim ve Değiştirme**

Aspose.Slides ayrıca geliştiricilerin mevcut özel özelliklere erişmesini ve değerlerini kolayca değiştirmesini sağlar. Bu işlevsellik, doğru meta verinin korunmasına yardımcı olur ve kullanıcı girişi ya da iş mantığına dayalı dinamik güncellemeleri destekler. Aşağıdaki örnekler, bir sunum içinde özel özellik değerlerini nasıl alıp güncelleyeceğinizi gösterir.

```cs
// PPTX dosyasını temsil eden Presentation sınıfını örnekleyin.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Özel özelliklere erişin ve değiştirin.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // Özel özelliğin adını ve değerini gösterin.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // Özel özelliğin değerini değiştirin.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// Sunumu bir dosyaya kaydedin.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Canlı Örnek**

Aspose.Slides API'sını kullanarak belge özellikleriyle nasıl çalışılacağını görmek için [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/tr/metadata) çevrimiçi uygulamasını deneyin:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/tr/metadata)

## ***SSS**

**Sunumdan yerleşik bir özelliği nasıl kaldırabilirim?**

Yerleşik özellikler, sunumun ayrılmaz bir parçasıdır ve tamamen kaldırılamaz. Ancak, belirli özellik izin veriyorsa değerlerini değiştirebilir veya boş olarak ayarlayabilirsiniz.

**Zaten var olan bir özel özellik eklersem ne olur?**

Zaten var olan bir özel özellik eklenirse, mevcut değeri yeni değerle üzerine yazılır. Özelliği önceden kaldırmanıza veya kontrol etmenize gerek yoktur; Aspose.Slides otomatik olarak özelliğin değerini günceller.

**Sunumu tamamen yüklemeden sunum özelliklerine erişebilir miyim?**

Evet, sunumu tamamen yüklemeden sunum özelliklerine, [PresentationFactory](https://reference.aspose.com/slides/tr/net/aspose.slides/presentationfactory/) sınıfındaki `GetPresentationInfo` yöntemini kullanarak erişebilirsiniz. Ardından, özellikleri verimli bir şekilde okumak, belleği tasarruf etmek ve performansı artırmak için [IPresentationInfo](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationinfo/) arabirimi tarafından sağlanan `ReadDocumentProperties` yöntemini kullanın.