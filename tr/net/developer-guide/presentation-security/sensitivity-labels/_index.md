---
title: .NET'te PowerPoint Sunumlarında Duyarlılık Etiketlerini Yönetme
linktitle: Duyarlılık Etiketleri
type: docs
weight: 50
url: /tr/net/sensitivity-labels/
keywords:
- duyarlılık etiketi
- Microsoft Purview
- Microsoft Information Protection
- MIP üst verileri
- içerik işaretleme
- bilgi koruması
- belge yönetimi
- PowerPoint
- PPTX
- sunum güvenliği
- .NET
- C#
- Aspose.Slides
description: "PowerPoint PPTX sunumlarında Aspose.Slides for .NET ile Microsoft Purview duyarlılık etiketlerini okuyun, ekleyin, güncelleyin, kaldırın ve taşıyın."
---
## **Genel Bakış**

Microsoft Purview duyarlılık etiketleri, kuruluşların belgeleri sınıflandırmasına ve yönetmesine yardımcı olur. Otomatik sunum işleme sırasında, bir uygulama mevcut bir etiketi korumak, bir politika tarafından seçilen bir etiketi uygulamak, durumunu güncellemek veya daha eski bir Microsoft Information Protection (MIP) akışı tarafından yazılan etiket üst verilerini taşımak zorunda kalabilir.

Aspose.Slides, modern duyarlılık etiketi üst verilerini [Presentation.SensitivityLabels](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/sensitivitylabels/) aracılığıyla ortaya koyar. Bu özellik, [ISensitivityLabelCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabelcollection/) döndürür; bu koleksiyon, sunum PPTX olarak kaydedilmeden önce incelenebilir ve değiştirilebilir.

{{% alert color="primary" title="Note" %}}
Duyarlılık etiketi tanımlayıcıları ve politika bilgileri, Microsoft Purview yapılandırmanız tarafından tanımlanır. Üst verileri eklemeden veya taşımadan önce ortamınızda etiket kullanılabilirliğini ve politika gereksinimlerini doğrulayın. [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabel/contentmarktypes/) değerleri, bir etiketle ilişkilendirilen içerik işaretlemelerini açıklar; bunlar tek başına slaytlara görünür metin veya şekil eklemez.
{{% /alert %}}

## **Duyarlılık Etiketi Özelliklerini Anlama**

Her [ISensitivityLabel](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabel/) aşağıdaki üst verileri içerir:

| Özellik | Amaç |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabel/id/) | Purview politikasındaki duyarlılık etiketini tanımlar. |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabel/siteid/) | Etiket politikasıyla ilişkili siteyi tanımlar. |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabel/isenabled/) | Etiketin etkin olup olmadığını gösterir. |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabel/isremoved/) | Etiketin kaldırıldığını gösterir. Kaldırma durumu meta veride tutulmalıysa bu özelliği `true` olarak ayarlayın. |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | Etiketin otomatik olarak mı yoksa kullanıcı kararıyla mı uygulandığını belirtir. |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabel/contentmarktypes/) | Etiketle ilişkili içerik işaretleme türlerini listeler. |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/tr/net/aspose.slides/sensitivitylabelassignmenttype/) sayımı, bir etiketin nasıl atandığını açıklar:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/tr/net/aspose.slides/sensitivitylabelassignmenttype/) varsayılan veya otomatik olarak uygulanan etiketi temsil eder.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/tr/net/aspose.slides/sensitivitylabelassignmenttype/) kullanıcı kararıyla uygulanan etiketi temsil eder; bunlar manuel olarak uygulanan, önerilen ve zorunlu etiketleri içerir.

[SensitivityLabelContentType](https://reference.aspose.com/slides/tr/net/aspose.slides/sensitivitylabelcontenttype/) sayımı, bir etiketle ilişkili işaretlemeyi tanımlar:

| Değer | Anlam |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/tr/net/aspose.slides/sensitivitylabelcontenttype/) | Etiket varsayılan olarak veya otomatik olarak uygulanmıştır. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/tr/net/aspose.slides/sensitivitylabelcontenttype/) | Üst bilgi (header) içerik işaretlemesi etiketle ilişkilidir. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/tr/net/aspose.slides/sensitivitylabelcontenttype/) | Alt bilgi (footer) içerik işaretlemesi etiketle ilişkilidir. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/tr/net/aspose.slides/sensitivitylabelcontenttype/) | Filigran (watermark) içerik işaretlemesi etiketle ilişkilidir. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/tr/net/aspose.slides/sensitivitylabelcontenttype/) | Şifreleme koruması etiketle ilişkilidir. |

Bir etiketle birden fazla işaretleme türü ilişkilendirilebilir.

## **Mevcut Duyarlılık Etiketlerini Listeleme**

Modern etiket koleksiyonunu [Presentation.SensitivityLabels](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/sensitivitylabels/) üzerinden okuyun ve listeleyin. Aşağıdaki örnek, her etiket için saklanan tüm özellikleri ve içerik işaretlemelerini listeler:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

foreach (var sensitivityLabel in sensitivityLabels)
{
    Console.WriteLine("Label ID: " + sensitivityLabel.Id);
    Console.WriteLine("Site ID: " + sensitivityLabel.SiteId);
    Console.WriteLine("Enabled: " + sensitivityLabel.IsEnabled);
    Console.WriteLine("Removed: " + sensitivityLabel.IsRemoved);
    Console.WriteLine("Assignment method: " + sensitivityLabel.AssignmentMethodType);

    foreach (var contentMarkType in sensitivityLabel.ContentMarkTypes)
    {
        Console.WriteLine("Content marking: " + contentMarkType);
    }
}
```

## **İçerik İşaretleme ile Duyarlılık Etiketi Ekleme**

[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabelcollection/add/) yöntemini etiket tanımlayıcısı, site tanımlayıcısı, etkin durumu ve atama yöntemi ile kullanın. Yöntem yeni bir [ISensitivityLabel](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabel/) döndürdükten sonra, gerekli işaretleme değerlerini [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabel/contentmarktypes/) aracılığıyla ekleyin.

Aşağıdaki örnek, alt bilgi ve filigran işaretlemeleriyle ilişkili manuel olarak seçilmiş bir etiket ekler ve ardından sonucu PPTX olarak kaydeder:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

var labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
var siteIdentifier = Guid.Parse("{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
var isEnabled = true;
var assignmentMethod = SensitivityLabelAssignmentType.Privileged;

var sensitivityLabel = sensitivityLabels.Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Footer);
sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Watermark);

presentation.Save("presentation_with_label.pptx", SaveFormat.Pptx);
```

## **Duyarlılık Etiketini Güncelleme**

[ISensitivityLabel](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabel/) özellikleri okunabilir/yazılabilir, ancak [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabel/contentmarktypes/) tarafından döndürülen koleksiyon, liste operasyonlarıyla değiştirilir. Gerekli etiketi bulduktan sonra, tanımlayıcısını, site tanımlayıcısını, etkin durumunu, atama yöntemini, kaldırma durumunu ve içerik işaretleme türlerini güncelleyebilirsiniz. Değişiklikleri kalıcılaştırmak için sunumu kaydedin.

Aşağıdaki örnek, ilk etiketin etkin durumunu ve atama yöntemini günceller:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

if (sensitivityLabels.Count > 0)
{
    var sensitivityLabel = sensitivityLabels[0];
    sensitivityLabel.IsEnabled = true;
    sensitivityLabel.AssignmentMethodType = SensitivityLabelAssignmentType.Privileged;
}

presentation.Save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
```

## **Duyarlılık Etiketini Kaldırıldı Olarak İşaretleme**

Bir etiketin kaldırılmış olduğunu korumak için, etiketi bulun ve [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabel/isremoved/) özelliğini `true` olarak ayarlayın. Bu, etiket girişini kaldırılmış durumunu kaydederek tutar. Modern koleksiyondan bir girişi silmeniz gerekiyorsa, [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabelcollection/removeat/) kullanın; tüm girişleri silmek için [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabelcollection/clear/) kullanın.

Aşağıdaki örnek, belirli bir etiketi kaldırıldı olarak işaretler ve güncellenmiş sunumu kaydeder:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;
var targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

foreach (var sensitivityLabel in sensitivityLabels)
{
    var isTargetLabel = string.Equals(
        sensitivityLabel.Id,
        targetLabelIdentifier,
        StringComparison.OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel.IsRemoved = true;
        break;
    }
}

presentation.Save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
```

## **Eski MIP Duyarlılık Etiketlerini Okuma ve Taşıma**

Daha eski MIP tabanlı iş akışları, modern etiket koleksiyonu yerine özel belge özelliklerinde duyarlılık etiketi üst verilerini depolayabilir. Bu üst verileri [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/tr/net/aspose.slides/idocumentproperties/getsensitivitylabels/) ile okuyun. Yöntem, eski özel özellikleri ayrıştırır ve bir dizi [ISensitivityLabel](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabel/) nesnesi döndürür.

Üst verileri taşımak için, döndürülen her etiketi modern [ISensitivityLabelCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabelcollection/) [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabelcollection/add/) aracılığıyla ekleyin. Yinelenen bir etiket tanımlayıcısı eklemek bir istisna fırlattığından, örnek her etiketi kopyalamadan önce hedef koleksiyonu kontrol eder. Her eski etiketin hâlâ mevcut Purview politikasında mevcut olduğunu doğrulamak için ek doğrulama ekleyebilirsiniz.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation_with_legacy_labels.pptx");
var legacySensitivityLabels = presentation.DocumentProperties.GetSensitivityLabels();
var modernSensitivityLabels = presentation.SensitivityLabels;

foreach (var legacySensitivityLabel in legacySensitivityLabels)
{
    var labelAlreadyExists = false;

    foreach (var modernSensitivityLabel in modernSensitivityLabels)
    {
        labelAlreadyExists = string.Equals(
            modernSensitivityLabel.Id,
            legacySensitivityLabel.Id,
            StringComparison.OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels.Add(legacySensitivityLabel);
    }
}

presentation.Save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
```

Taşıma, ayrıştırılan etiket nesnelerini modern koleksiyona kopyalar. Tüm özel belge özelliklerini temizlemeye gerek yoktur, bu nedenle alakasız belge üst verileri olduğu gibi kalır. Modern etiket üst verilerini bir PPTX dosyasına yazmak için [IPresentation.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentation/save/) ile [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/net/aspose.slides.export/saveformat/) kullanın.

## **FAQ**

**Bir içerik işaretleme türü eklemek slaytlarda görünür bir üst bilgi, alt bilgi veya filigran oluşturur mu?**

Hayır. [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabel/contentmarktypes/) aracılığıyla eklenen değerler, duyarlılık etiketiyle ilişkili işaretlemeleri tanımlar. Bunlar sunumda görünür metin veya şekil oluşturmaz. İş akışınız bu işaretlemeleri göstermek zorundaysa ilgili slayt içeriğini ayrı olarak ekleyin.

**Bir etiketi kaldırıldı olarak işaretlemek ile koleksiyondan silmek arasındaki fark nedir?**

[ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabel/isremoved/) özelliğini `true` olarak ayarlamak, etiket girişini tutar ve kaldırılmış durumunu kaydeder. [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabelcollection/removeat/) çağrısı, modern koleksiyondan girişi siler. Kuruluşunuzun üst veri saklama gereksinimlerine uygun işlemi seçin.

**Bir sunum hem eski MIP üst verilerini hem de modern duyarlılık etiketlerini içerebilir mi?**

Evet. Eski etiketler özel belge özelliklerinde kalabilirken, modern etiketler [Presentation.SensitivityLabels](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/sensitivitylabels/) aracılığıyla erişilebilir. Eski üst verileri okumak için [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/tr/net/aspose.slides/idocumentproperties/getsensitivitylabels/) kullanın ve modern koleksiyonda hâlihazırda bulunmayan geçerli etiketleri taşıyın.

**Aynı tanımlayıcıya sahip bir etiket birden fazla eklendiğinde ne olur?**

[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabelcollection/add/) aynı tanımlayıcıya sahip bir etiket zaten koleksiyonda bulunuyorsa bir `ArgumentException` fırlatır. Etiket eklemeden veya taşımadan önce mevcut [ISensitivityLabel.Id](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabel/id/) değerlerini kontrol edin.

**Güncellenmiş duyarlılık etiketlerini korumak için hangi çıktı formatı kullanılmalıdır?**

Yukarıdaki örneklerde gösterildiği gibi, sunumu PPTX olarak kaydetmek için [IPresentation.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentation/save/) ile [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/net/aspose.slides.export/saveformat/) çağırın.