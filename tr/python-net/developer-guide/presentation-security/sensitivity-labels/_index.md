---
title: PowerPoint Sunumlarında Python ile Duyarlılık Etiketlerini Yönet
linktitle: Duyarlılık Etiketleri
type: docs
weight: 50
url: /tr/python-net/sensitivity-labels/
keywords:
- duyarlılık etiketi
- Microsoft Purview
- Microsoft Information Protection
- MIP üst verileri
- içerik işaretleme
- bilgi koruması
- belge yönetişimi
- PowerPoint
- PPTX
- sunum güvenliği
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint PPTX sunumlarında Microsoft Purview duyarlılık etiketlerini okuyun, ekleyin, güncelleyin, kaldırın ve taşıyın."
---
## **Genel Bakış**

Microsoft Purview duyarlılık etiketleri, kuruluşların belgeleri sınıflandırmasına ve yönetmesine yardımcı olur. Otomatik sunum işleme sırasında, bir uygulama mevcut bir etiketi korumak, bir politika tarafından seçilen bir etiketi uygulamak, durumunu güncellemek veya daha eski bir Microsoft Information Protection (MIP) iş akışı tarafından yazılmış etiket üst verilerini taşımak zorunda kalabilir.

Aspose.Slides for Python via .NET, modern duyarlılık etiketi üst verilerini [Presentation.sensitivity_labels](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/sensitivity_labels/) aracılığıyla sunar. Bu özellik, sunum PPTX olarak kaydedilmeden önce incelenebilen ve değiştirilebilen bir [SensitivityLabelCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sensitivitylabelcollection/) döndürür.

{{% alert color="primary" title="Not" %}}
Duyarlılık etiketi tanımlayıcıları ve politika bilgileri Microsoft Purview yapılandırmanız tarafından tanımlanır. Etiket kullanılabilirliğini ve ortamınızdaki politika gereksinimlerini, üst verileri eklemeden veya taşımadan önce doğrulayın. [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sensitivitylabel/content_mark_types/) değerleri, bir etiketle ilişkili içerik işaretlemelerini tanımlar; kendileri slaytlara görünür metin veya şekil eklemez.
{{% /alert %}}

## **Duyarlılık Etiketi Özelliklerini Anlayın**

Her [SensitivityLabel](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sensitivitylabel/) aşağıdaki üst verileri içerir:

| Özellik | Amaç |
| --- | --- |
| [SensitivityLabel.id](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sensitivitylabel/id/) | Purview politikasındaki duyarlılık etiketini tanımlar. |
| [SensitivityLabel.site_id](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sensitivitylabel/site_id/) | Etiket politikasına bağlı siteyi tanımlar. |
| [SensitivityLabel.is_enabled](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sensitivitylabel/is_enabled/) | Etiketin etkin olup olmadığını gösterir. |
| [SensitivityLabel.is_removed](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sensitivitylabel/is_removed/) | Etiketin kaldırıldığını gösterir. Kaldırma durumu üst veride tutulmalıysa bu özelliği `True` olarak ayarlayın. |
| [SensitivityLabel.assignment_method_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sensitivitylabel/assignment_method_type/) | Etiketin otomatik olarak mı yoksa bir kullanıcı kararıyla mı uygulandığını belirler. |
| [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sensitivitylabel/content_mark_types/) | Etiketle ilişkili içerik işaretleme türlerini listeler. |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sensitivitylabelassignmenttype/) sayımı, bir etiketin nasıl atandığını açıklar:

- [SensitivityLabelAssignmentType.STANDARD](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sensitivitylabelassignmenttype/) varsayılan veya otomatik olarak uygulanan bir etiketi temsil eder.
- [SensitivityLabelAssignmentType.PRIVILEGED](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sensitivitylabelassignmenttype/) bir kullanıcı kararıyla uygulanan etiketi temsil eder; bunlar manuel uygulanan, önerilen ve zorunlu etiketlerdir.

[SensitivityLabelContentType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sensitivitylabelcontenttype/) sayımı, bir etiketle ilişkili işaretlemeyi belirler:

| Değer | Anlam |
| --- | --- |
| [SensitivityLabelContentType.NONE](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sensitivitylabelcontenttype/) | Etiket varsayılan veya otomatik olarak uygulanmıştır. |
| [SensitivityLabelContentType.HEADER](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sensitivitylabelcontenttype/) | Üst bilgi içerik işaretlemesi etiketle ilişkilendirilir. |
| [SensitivityLabelContentType.FOOTER](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sensitivitylabelcontenttype/) | Alt bilgi içerik işaretlemesi etiketle ilişkilendirilir. |
| [SensitivityLabelContentType.WATERMARK](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sensitivitylabelcontenttype/) | Filigran içerik işaretlemesi etiketle ilişkilendirilir. |
| [SensitivityLabelContentType.ENCRYPTION](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sensitivitylabelcontenttype/) | Şifreleme koruması etiketle ilişkilendirilir. |

Bir etikete birden fazla işaretleme türü ilişkilendirilebilir.

## **Mevcut Duyarlılık Etiketlerini Listele**

[Presentation.sensitivity_labels](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/sensitivity_labels/) üzerinden modern etiket koleksiyonunu okuyun ve yineleyin. Aşağıdaki örnek, her etiket için depolanan tüm özellikleri ve içerik işaretlemelerini listeler:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.id)
        print("Site ID:", sensitivity_label.site_id)
        print("Enabled:", sensitivity_label.is_enabled)
        print("Removed:", sensitivity_label.is_removed)
        print("Assignment method:", sensitivity_label.assignment_method_type)

        for content_mark_type in sensitivity_label.content_mark_types:
            print("Content marking:", content_mark_type)
```

## **İçerik İşaretlemesiyle Bir Duyarlılık Etiketi Ekle**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sensitivitylabelcollection/add/) yöntemini etiket tanımlayıcısı, site tanımlayıcısı, etkin durumu ve atama yöntemiyle kullanın. Site tanımlayıcısını bir Python `uuid.UUID` nesnesi olarak gönderin. Yöntem yeni bir [SensitivityLabel](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sensitivitylabel/) döndürdükten sonra, gerekli işaretleme değerlerini [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sensitivitylabel/content_mark_types/) listesine ekleyin.

Aşağıdaki örnek, alt bilgi ve filigran işaretlemeleriyle ilişkili manuel seçilmiş bir etiket ekler ve ardından sonucu PPTX olarak kaydeder:

```python
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = uuid.UUID("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = slides.SensitivityLabelAssignmentType.PRIVILEGED

    sensitivity_label = sensitivity_labels.add(
        label_identifier,
        site_identifier,
        is_enabled,
        assignment_method
    )

    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.FOOTER)
    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.WATERMARK)

    presentation.save("presentation_with_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Bir Duyarlılık Etiketini Güncelle**

[SensitivityLabel](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sensitivitylabel/) özellikleri okuma/yazma yapılabilir; ancak [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sensitivitylabel/content_mark_types/) tarafından döndürülen liste, liste işlemleriyle değiştirilir. Gerekli etiketi bulduktan sonra, tanımlayıcısını, site tanımlayıcısını, etkin durumunu, atama yöntemini, kaldırma durumunu ve içerik işaretleme türlerini güncelleyebilirsiniz. Değişiklikleri kalıcı kılmak için sunumu kaydedin.

Aşağıdaki örnek, ilk etiketin etkin durumunu ve atama yöntemini günceller:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    if sensitivity_labels.count > 0:
        sensitivity_label = sensitivity_labels[0]
        sensitivity_label.is_enabled = True
        sensitivity_label.assignment_method_type = (
            slides.SensitivityLabelAssignmentType.PRIVILEGED
        )

    presentation.save("presentation_with_updated_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Bir Duyarlılık Etiketini Kaldırıldı Olarak İşaretle**

Bir etiketin kaldırıldığını korumak için etiketi bulun ve [SensitivityLabel.is_removed](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sensitivitylabel/is_removed/) özelliğini `True` olarak ayarlayın. Bu, etiket girişini tutarken kaldırılmış durumunu kaydeder. Modern koleksiyondan bir girişi tamamen silmek isterseniz, [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sensitivitylabelcollection/remove_at/) yöntemini kullanın; tüm girişleri silmek için [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sensitivitylabelcollection/clear/) yöntemini kullanın.

Aşağıdaki örnek, belirli bir etiketi kaldırıldı olarak işaretler ve güncellenen sunumu kaydeder:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        identifiers_match = (
            sensitivity_label.id.casefold() == target_label_identifier.casefold()
        )

        if identifiers_match:
            sensitivity_label.is_removed = True
            break

    presentation.save("presentation_with_removed_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Eski MIP Duyarlılık Etiketlerini Oku ve Taşı**

Eski MIP tabanlı iş akışları, duyarlılık etiketi üst verilerini modern etiket koleksiyonu yerine özel belge özelliklerinde saklayabilir. Bu üst verileri [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/tr/python-net/aspose.slides/documentproperties/get_sensitivity_labels/) yöntemiyle okuyun. Yöntem, eski özel özellikleri ayrıştırır ve [SensitivityLabel](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sensitivitylabel/) nesneleri döndürür.

Üst verileri taşımak için, döndürülen her etiketi modern [SensitivityLabelCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sensitivitylabelcollection/) içine [SensitivityLabelCollection.add](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sensitivitylabelcollection/add/) ile ekleyin. Aynı etiket tanımlayıcısının eklenmesi bir istisna oluşturduğundan, örnek her etiketi kopyalamadan önce hedef koleksiyonun mevcut olup olmadığını kontrol eder. Her eski etiketin hâlâ geçerli Purview politikanızda bulunup bulunmadığını doğrulamak için ek kontroller ekleyebilirsiniz.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_legacy_labels.pptx") as presentation:
    legacy_sensitivity_labels = (
        presentation.document_properties.get_sensitivity_labels()
    )
    modern_sensitivity_labels = presentation.sensitivity_labels

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = (
                modern_sensitivity_label.id.casefold()
                == legacy_sensitivity_label.id.casefold()
            )

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", slides.export.SaveFormat.PPTX)
```

Taşıma işlemi, ayrıştırılan etiket nesnelerini modern koleksiyona kopyalar. Tüm özel belge özelliklerini temizlemeye gerek yoktur; bu sayede ilgili olmayan belge üst verileri korunur. Modern etiket üst verilerini bir PPTX dosyasına yazmak için [Presentation.save](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/save/) yöntemini [SaveFormat.PPTX](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/saveformat/) ile kullanın.

## **SSS**

**Bir içerik işaretleme türü eklemek slaytlara görünür bir üst bilgi, alt bilgi veya filigran oluşturur mu?**

Hayır. [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sensitivitylabel/content_mark_types/) üzerinden eklenen değerler, duyarlılık etiketiyle ilişkili işaretlemeleri tanımlar. Sunumda görünür metin veya şekil oluşturmazlar. İş akışınız bu işaretlemeleri görsel olarak sunmak zorundaysa, ilgili slayt içeriğini ayrı olarak ekleyin.

**Bir etiketi kaldırıldı olarak işaretlemek ile koleksiyondan silmek arasındaki fark nedir?**

[SensitivityLabel.is_removed](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sensitivitylabel/is_removed/) özelliğini `True` olarak ayarlamak, etiket girişini tutar ve kaldırılmış durumunu kaydeder. [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sensitivitylabelcollection/remove_at/) yöntemi ise etiketi modern koleksiyondan tamamen siler. Kuruluşunuzun üst veri saklama gereksinimlerine uygun olan işlemi seçin.

**Bir sunum hem eski MIP üst verilerini hem de modern duyarlılık etiketlerini içerebilir mi?**

Evet. Eski etiketler özel belge özelliklerinde kalabilirken, modern etiketler [Presentation.sensitivity_labels](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/sensitivity_labels/) üzerinden erişilebilir. Eski üst verileri okumak ve yalnızca modern koleksiyonda hâlâ bulunmayan geçerli etiketleri taşımak için [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/tr/python-net/aspose.slides/documentproperties/get_sensitivity_labels/) yöntemini kullanın.

**Aynı tanımlayıcıya sahip bir etiket birden fazla kez eklendiğinde ne olur?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sensitivitylabelcollection/add/) yöntemi, koleksiyon zaten aynı tanımlayıcıya sahip bir etiket içeriyorsa bir istisna fırlatır. Etiket eklemeden veya taşımadan önce mevcut [SensitivityLabel.id](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sensitivitylabel/id/) değerlerini kontrol edin.

**Güncellenen duyarlılık etiketlerini korumak için hangi çıktı formatı kullanılmalıdır?**

Yukarıdaki örneklerde gösterildiği gibi, [Presentation.save](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/save/) yöntemini [SaveFormat.PPTX](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/saveformat/) ile çağırarak sunumu PPTX olarak kaydedin.