---
title: Sunum Özelliklerini .NET'te Yönet
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

Aspose.Slides for .NET iki tür belge özelliğini destekler: **Yerleşik** ve **Özel**. Bu özellik türlerinin her ikisi de Aspose.Slides for .NET API'si kullanılarak kolayca erişilebilir ve yönetilebilir.

Aspose.Slides, sunum belge özellikleriyle [IDocumentProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/idocumentproperties/) arabirimi aracılığıyla çalışmanıza olanak tanır. Bu arabirimin bir örneği, [Presentation.DocumentProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/documentproperties/) özelliği tarafından döndürülür. Aşağıdaki örnekler, bu özelliklerin nasıl okunacağını, değiştirileceğini ve yönetileceğini gösterir.

{{% alert color="info" %}} 
Lütfen **Application** ve **Producer** alanlarının değiştirilemeyeceğini, bu alanların her zaman "Aspose Ltd." ve "Aspose.Slides for .NET x.x.x" göstereceğini unutmayın.
{{% /alert %}} 

## **Sunum Özelliklerini Yönet**

Microsoft PowerPoint, sunum dosyalarına özellik ekleme özelliği sağlar. Bu belge özellikleri, dosyalarla birlikte faydalı bilgilerin depolanmasına olanak tanır. İki tür belge özelliği vardır:

- Sistem tanımlı (yerleşik) özellikler
- Kullanıcı tanımlı (özel) özellikler

**Yerleşik** özellikler belge hakkında genel bilgiler içerir, örneğin belge başlığı, yazarın adı, belge istatistikleri ve daha fazlası.

**Özel** özellikler, kullanıcılar tarafından **Ad/Değer** çiftleri olarak tanımlanır; burada hem ad hem de değer kullanıcı tarafından belirlenir.

Aspose.Slides for .NET kullanarak, geliştiriciler hem yerleşik hem de özel özelliklere erişebilir ve bunları değiştirebilir.

Microsoft PowerPoint, kullanıcıların Office simgesine tıklayıp **File → Info → Properties** seçeneğini seçerek belge özelliklerini yönetmelerine izin verir. **Advanced Properties** seçildikten sonra, sunum dosyasının tüm belge özelliklerini yönetebileceğiniz bir iletişim kutusu açılır.

**Properties** iletişim kutusunda, **General**, **Summary**, **Statistics**, **Contents** ve **Custom** gibi çeşitli sekmeler bulunur.
Her sekme, PowerPoint dosyasıyla ilgili belirli bilgi türlerini yapılandırma seçenekleri sunar. **Custom** sekmesi, kullanıcı tanımlı özellikleri yönetmek için kullanılır.

## **Yerleşik Özelliklere Erişim**

Bu özellikler, [IDocumentProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/idocumentproperties/) arabirimi tarafından sağlandığı gibi, **Creator** (Yazar), **Description**, **Keywords**, **Created** (Oluşturulma Tarihi), **Modified** (Değiştirilme Tarihi), **Printed** (Son Yazdırma Tarihi), **LastModifiedBy**, **SharedDoc** (belgenin farklı üreticiler arasında paylaşılıp paylaşılmadığını gösterir), **PresentationFormat**, **Subject**, **Title** ve daha fazlasını içerir.

```cs
using Aspose.Slides;

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

Sunum dosyalarının yerleşik özelliklerini değiştirmek, onlara erişmek kadar kolaydır. İstediğiniz herhangi bir özelliğe basitçe bir dize değeri atayabilir ve özelliğin değeri güncellenir. Aşağıdaki örnekte, bir sunum dosyasının yerleşik belge özelliklerini nasıl değiştireceğimizi gösteriyoruz.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Sunumla ilişkili IDocumentProperties türündeki nesneye bir referans alın.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Yerleşik özellikleri ayarla.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// Sunumu bir dosyaya kaydedin.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Özel Sunum Özellikleri Ekleme**

Özel sunum özellikleri, geliştiricilerin bir sunum dosyasında ek meta veri veya belirli bilgiler depolamasını sağlar. Aspose.Slides, bu özel özellikleri programlı olarak oluşturmayı ve yönetmeyi kolaylaştırır. Aşağıdaki örnekler, sunumlarınıza özel özellikleri nasıl ekleyeceğinizi gösterir.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation sınıfını örnekleyin.
using Presentation presentation = new Presentation();

// Sunumla ilişkili IDocumentProperties türündeki nesneye bir referans alın.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Özel özellikler ekleyin.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Sunumu bir dosyaya kaydedin.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Özel Özelliklere Erişim ve Değiştirme**

Aspose.Slides ayrıca geliştiricilerin mevcut özel özelliklere erişmesini ve değerlerini kolayca değiştirmesini sağlar. Bu işlevsellik, doğru meta verinin korunmasına yardımcı olur ve kullanıcı girişi ya da iş mantığına dayalı dinamik güncellemeleri destekler. Aşağıdaki örnekler, bir sunum içinde özel özellik değerlerini nasıl alıp güncelleyebileceğinizi gösterir.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// PPTX dosyasını temsil eden Presentation sınıfını örnekleyin.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Sunumla ilişkili IDocumentProperties türündeki nesneye bir referans alın.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Access and modify the custom properties.
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

// Sunumu bir dosyaya kaydedin.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Canlı Örnek**

Aspose.Slides API'sini kullanarak belge özellikleriyle nasıl çalışılacağını görmek için çevrimiçi [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/tr/metadata) uygulamasını deneyin:

[![PowerPoint Meta Verilerini Görüntüle ve Düzenle](slides-metadata.png)](https://products.aspose.app/slides/tr/metadata)

## ***SSS**

### Bir sunumdan yerleşik bir özelliği nasıl kaldırabilirim?

Yerleşik özellikler, sunumun ayrılmaz bir parçasıdır ve tamamen kaldırılamaz. Ancak, belirli özellik izin veriyorsa, değerlerini değiştirebilir veya boş olarak ayarlayabilirsiniz.

### Zaten var olan bir özel özellik eklersem ne olur?

Zaten var olan bir özel özellik eklerseniz, mevcut değeri yeni değerle üzerine yazılır. Özelliği önceden kaldırmanıza veya kontrol etmenize gerek yoktur; Aspose.Slides özelliğin değerini otomatik olarak günceller.

### Sunumu tamamen yüklemeden sunum özelliklerine erişebilir miyim?

Evet, [PresentationFactory](https://reference.aspose.com/slides/tr/net/aspose.slides/presentationfactory/) sınıfının `GetPresentationInfo` metodunu kullanarak sunumu tamamen yüklemeden sunum özelliklerine erişebilirsiniz. Ardından, [IPresentationInfo](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationinfo/) arabiriminin sağladığı `ReadDocumentProperties` metodunu kullanarak özellikleri verimli bir şekilde okuyabilir, bellek tasarrufu sağlayabilir ve performansı artırabilirsiniz.