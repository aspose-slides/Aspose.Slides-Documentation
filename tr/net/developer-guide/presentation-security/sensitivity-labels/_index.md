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
description: ".NET için Aspose.Slides kullanarak PowerPoint PPTX sunumlarındaki Microsoft Purview duyarlılık etiketlerini okuyun, ekleyin, güncelleyin, kaldırın ve taşıyın."
---
## **Genel Bakış**

Microsoft Purview duyarlılık etiketleri, kuruluşların belgeleri sınıflandırmasına ve yönetmesine yardımcı olur. Otomatik sunum işleme sırasında, bir uygulama mevcut bir etiketi korumak, bir politika tarafından seçilen bir etiketi uygulamak, durumunu güncellemek veya daha eski bir Microsoft Information Protection (MIP) iş akışı tarafından yazılan etiket üst verilerini taşımak isteyebilir.

Aspose.Slides, modern duyarlılık etiketi üst verilerini [Presentation.SensitivityLabels](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/sensitivitylabels/) aracılığıyla sunar. Bu özellik, sunum PPTX olarak kaydedilmeden önce incelenebilen ve değiştirilebilen bir [ISensitivityLabelCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabelcollection/) döndürür.

{{% alert color="info" title="Not" %}}
Duyarlılık etiketi kimlikleri ve politika bilgileri, Microsoft Purview yapılandırmanız tarafından tanımlanır. Metaveri eklemeden veya taşımadan önce ortamınızda etiket kullanılabilirliğini ve politika gereksinimlerini doğrulayın. [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabel/contentmarktypes/) değerleri, bir etiketle ilişkili içerik işaretlemelerini açıklar; bunlar tek başına slaytlara görünür metin veya şekil eklemez.
{{% /alert %}}

## **Duyarlılık Etiketi Özelliklerini Anlayın**

Her bir [ISensitivityLabel](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabel/) şu üst verileri içerir:

| Özellik | Amaç |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabel/id/) | Purview politikasındaki duyarlılık etiketini tanımlar. |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabel/siteid/) | Etiket politikasına bağlı siteyi tanımlar. |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabel/isenabled/) | Etiketin etkin olup olmadığını gösterir. |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabel/isremoved/) | Etiketin kaldırıldığını gösterir. Kaldırma durumunun üst veride tutulması gerektiğinde bu özelliği `true` olarak ayarlayın. |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | Etiketin otomatik olarak mı yoksa bir kullanıcı kararıyla mı uygulandığını belirtir. |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabel/contentmarktypes/) | Etiketle ilişkili içerik işaretleme türlerini listeler. |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/tr/net/aspose.slides/sensitivitylabelassignmenttype/) enumarasyonu, bir etiketin nasıl atandığını tanımlar:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/tr/net/aspose.slides/sensitivitylabelassignmenttype/) varsayılan veya otomatik olarak uygulanan bir etiketi temsil eder.  
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/tr/net/aspose.slides/sensitivitylabelassignmenttype/) bir kullanıcı kararıyla uygulanan etiketi temsil eder; manuel uygulanmış, önerilen ve zorunlu etiketleri içerir.

[SensitivityLabelContentType](https://reference.aspose.com/slides/tr/net/aspose.slides/sensitivitylabelcontenttype/) enumarasyonu, bir etiketle ilişkili işaretlemeyi tanımlar:

| Değer | Anlam |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/tr/net/aspose.slides/sensitivitylabelcontenttype/) | Etiket varsayılan olarak veya otomatik olarak uygulanmıştır. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/tr/net/aspose.slides/sensitivitylabelcontenttype/) | Başlık içerik işaretlemesi etiketle ilişkilidir. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/tr/net/aspose.slides/sensitivitylabelcontenttype/) | Alt bilgi içerik işaretlemesi etiketle ilişkilidir. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/tr/net/aspose.slides/sensitivitylabelcontenttype/) | Filigran içerik işaretlemesi etiketle ilişkilidir. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/tr/net/aspose.slides/sensitivitylabelcontenttype/) | Şifreleme koruması etiketle ilişkilidir. |

Bir etikete birden fazla işaretleme türü atanabilir.

## **Mevcut Duyarlılık Etiketlerini Listeleyin**

Modern etiket koleksiyonunu [Presentation.SensitivityLabels](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/sensitivitylabels/) üzerinden okuyun ve yineleyin. Aşağıdaki örnek, her etiket için depolanan tüm özellikleri ve içerik işaretlemelerini listeler:

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

## **İçerik İşaretlemesiyle Duyarlılık Etiketi Ekleyin**

Etiket kimliği, site kimliği, etkin durumu ve atama yöntemini belirterek [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabelcollection/add/) metodunu kullanın. Metod yeni bir [ISensitivityLabel](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabel/) döndürdükten sonra, gerekli işaretleme değerlerini [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabel/contentmarktypes/) aracılığıyla ekleyin.

Aşağıdaki örnek, alt bilgi ve filigran işaretlemeleriyle ilişkilendirilmiş, manuel olarak seçilmiş bir etiket ekler ve ardından sonucu PPTX olarak kaydeder:

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

## **Bir Duyarlılık Etiketini Güncelleyin**

[ISensitivityLabel](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabel/) özellikleri okuma/yazma yapılabilir; yalnızca [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabel/contentmarktypes/) tarafından döndürülen koleksiyon, liste işlemleriyle değiştirilir. Gerekli etiketi bulduktan sonra kimliğini, site kimliğini, etkin durumunu, atama yöntemini, kaldırma durumunu ve içerik işaretleme türlerini güncelleyebilirsiniz. Değişiklikleri kalıcı kılmak için sunumu kaydedin.

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

## **Bir Duyarlılık Etiketini Kaldırılmış Olarak İşaretleyin**

Bir etiketin kaldırıldığını korumak için etiketi bulun ve [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabel/isremoved/) özelliğini `true` olarak ayarlayın. Bu, etiketi kaldırılmış durumunda tutar. Modern koleksiyondan bir girişi tamamen silmek isterseniz, [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabelcollection/removeat/) kullanın; tüm girişleri silmek için [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabelcollection/clear/) kullanın.

Aşağıdaki örnek, belirli bir etiketi kaldırılmış olarak işaretler ve güncellenmiş sunumu kaydeder:

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

## **Eski MIP Duyarlılık Etiketlerini Oku ve Taşı**

Eski MIP tabanlı iş akışları, duyarlılık etiketi üst verilerini modern etiket koleksiyonu yerine özel belge özelliklerinde saklayabilir. Bu üst veriyi [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/tr/net/aspose.slides/idocumentproperties/getsensitivitylabels/) ile okuyun. Metod, eski özel özellikleri ayrıştırır ve bir dizi [ISensitivityLabel](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabel/) nesnesi döndürür.

Üst veriyi taşımak için, döndürülen her etiketi modern [ISensitivityLabelCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabelcollection/) içine [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabelcollection/add/) ile ekleyin. Aynı kimliğe sahip bir etiketi eklemek bir istisna fırlattığından, örnek her etiketi kopyalamadan önce hedef koleksiyonun mevcut olup olmadığını denetler. Geçerli Purview politikasında hâlâ mevcut olan eski etiketleri doğrulamak için ek denetimler ekleyebilirsiniz.

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

Taşıma işlemi, ayrıştırılan etiket nesnelerini modern koleksiyona kopyalar. Tüm özel belge özelliklerini temizlemeye gerek yoktur; böylece ilişkili olmayan belge üst verileri bozulmadan kalır. Modern etiket üst verilerini PPTX dosyasına yazmak için [IPresentation.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentation/save/) metodunu [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/net/aspose.slides.export/saveformat/) ile kullanın.

## **SSS**

**İçerik işaretleme türü eklemek, slaytlara görünür bir başlık, alt bilgi veya filigran oluşturur mu?**

Hayır. [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabel/contentmarktypes/) aracılığıyla eklenen değerler, duyarlılık etiketiyle ilişkili işaretlemeleri tanımlar. Sunumda görünür metin veya şekil oluşturmazlar. İş akışınız bu işaretlemeleri render etmesi gerekiyorsa, ilgili slayt içeriğini ayrı olarak ekleyin.

**Bir etiketi “kaldırılmış” olarak işaretlemek ile koleksiyondan silmek arasındaki fark nedir?**

[ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabel/isremoved/) özelliğini `true` olarak ayarlamak, etiket girişini tutar ve kaldırılmış durumunu kaydeder. [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabelcollection/removeat/) metodunu çağırmak, modern koleksiyondan girişi siler. Organizasyonunuzun üst veri saklama gereksinimlerine uygun işlemi seçin.

**Bir sunum, hem eski MIP metaverisini hem de modern duyarlılık etiketlerini içerebilir mi?**

Evet. Eski etiketler özel belge özelliklerinde kalabilirken, modern etiketler [Presentation.SensitivityLabels](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/sensitivitylabels/) üzerinden erişilebilir. Eski metaveriyi okumak ve yalnızca modern koleksiyonda hâlâ bulunmayan geçerli etiketleri taşımak için [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/tr/net/aspose.slides/idocumentproperties/getsensitivitylabels/) kullanın.

**Aynı kimliğe sahip bir etiket birden fazla kez eklenirse ne olur?**

[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabelcollection/add/) metodu, koleksiyon zaten aynı kimliğe sahip bir etiket içeriyorsa bir `ArgumentException` fırlatır. Etiket eklemeden veya taşımadan önce mevcut [ISensitivityLabel.Id](https://reference.aspose.com/slides/tr/net/aspose.slides/isensitivitylabel/id/) değerlerini kontrol edin.

**Güncellenen duyarlılık etiketlerini korumak için hangi çıktı formatı kullanılmalıdır?**

Yukarıdaki örneklerde gösterildiği gibi, sunumu [IPresentation.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentation/save/) metodunu [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/net/aspose.slides.export/saveformat/) ile çağırarak PPTX olarak kaydedin.