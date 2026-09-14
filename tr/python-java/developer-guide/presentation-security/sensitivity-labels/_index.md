---
title: Python'da PowerPoint Sunumlarında Duyarlılık Etiketlerini Yönet
linktitle: Duyarlılık Etiketleri
type: docs
weight: 50
url: /tr/python-java/sensitivity-labels/
keywords:
- duyarlılık etiketi
- Microsoft Purview
- Microsoft Information Protection
- MIP üst verileri
- içerik işaretlemesi
- bilgi koruması
- belge yönetimi
- PowerPoint
- PPTX
- sunum güvenliği
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak PowerPoint PPTX sunumlarında Microsoft Purview duyarlılık etiketlerini oku, ekle, güncelle, kaldır ve taşı."
---
## **Genel Bakış**

Microsoft Purview duyarlılık etiketleri, kuruluşların belgeleri sınıflandırmasına ve yönetmesine yardımcı olur. Otomatik sunum işleme sırasında, bir uygulama mevcut bir etiketi korumak, bir politika tarafından seçilen etiketi uygulamak, durumunu güncellemek veya eski bir Microsoft Information Protection (MIP) iş akışı tarafından yazılan etiket üst verilerini taşımak zorunda kalabilir.

Aspose.Slides, modern duyarlılık etiketi üst verilerini [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getSensitivityLabels) aracılığıyla sunar. Bu yöntem, sunum PPTX olarak kaydedilmeden önce incelenebilen ve değiştirilebilen bir [SensitivityLabelCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabelcollection/) döndürür.

{{% alert color="info" title="Note" %}}
Duyarlılık etiketi kimlikleri ve politika bilgileri, Microsoft Purview yapılandırmanız tarafından tanımlanır. Üst verileri eklemeden veya taşıma işlemine başlamadan önce ortamınızda etiket kullanılabilirliğini ve politika gereksinimlerini doğrulayın. [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) değerleri, bir etiketle ilişkili içerik işaretlemelerini açıklar; bunlar tek başına slaytlara görülebilir metin veya şekil eklemez.
{{% /alert %}}

## **Duyarlılık Etiketi Özelliklerini Anlayın**

Her bir [SensitivityLabel](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabel/) aşağıdaki üst verileri içerir:

| Yöntemler | Amaç |
| --- | --- |
| [getId](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabel/#getId) and [setId](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabel/#setId) | Purview politikasındaki duyarlılık etiketi kimliğini alır veya ayarlar. |
| [getSiteId](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabel/#getSiteId) and [setSiteId](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabel/#setSiteId) | Etiket politikasına bağlı siteyi alır veya ayarlar. |
| [isEnabled](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabel/#isEnabled) and [setEnabled](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabel/#setEnabled) | Etiketin etkin olup olmadığını alır veya ayarlar. |
| [isRemoved](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabel/#isRemoved) and [setRemoved](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabel/#setRemoved) | Etiketin kaldırılmış olup olmadığını alır veya ayarlar. Kaldırma durumu üst veride tutulmalıysa değeri `True` olarak ayarlayın. |
| [getAssignmentMethodType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) and [setAssignmentMethodType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Etiketin otomatik mi yoksa kullanıcı kararıyla mı uygulandığını alır veya ayarlar. |
| [getContentMarkTypes](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Etiketle ilişkili içerik işaretleme türlerini alır. |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabelassignmenttype/) sınıfı, bir etiketin nasıl atandığını tanımlar:

- [Standard](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabelassignmenttype/) varsayılan veya otomatik olarak uygulanmış bir etiketi temsil eder.
- [Privileged](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabelassignmenttype/) kullanıcı kararıyla uygulanan bir etiketi temsil eder; manuel olarak uygulanmış, önerilen ve zorunlu etiketler dahil.

[SensitivityLabelContentType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabelcontenttype/) sınıfı, bir etiketle ilişkili işaretlemeyi tanımlar:

| Değer | Anlam |
| --- | --- |
| [None](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabelcontenttype/) | Etiket varsayılan olarak veya otomatik olarak uygulanmıştır. |
| [Header](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabelcontenttype/) | Başlık içerik işaretlemesi etiketle ilişkilendirilir. |
| [Footer](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabelcontenttype/) | Altbilgi içerik işaretlemesi etiketle ilişkilendirilir. |
| [Watermark](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabelcontenttype/) | Filigran içerik işaretlemesi etiketle ilişkilendirilir. |
| [Encryption](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabelcontenttype/) | Şifreleme koruması etiketle ilişkilendirilir. |

Bir etikete birden fazla işaretleme türü ilişkilendirilebilir.

## **Mevcut Duyarlılık Etiketlerini Listele**

[Presentation.getSensitivityLabels](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getSensitivityLabels) kullanarak modern etiket koleksiyonunu okuyun ve üzerinde yineleme yapın. Aşağıdaki örnek, her etiket için saklanan tüm özellikleri ve içerik işaretlemelerini listeler:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.getId())
        print("Site ID:", sensitivity_label.getSiteId())
        print("Enabled:", sensitivity_label.isEnabled())
        print("Removed:", sensitivity_label.isRemoved())
        print("Assignment method:", sensitivity_label.getAssignmentMethodType())

        for content_mark_type in sensitivity_label.getContentMarkTypes():
            print("Content marking:", content_mark_type)
finally:
    presentation.dispose()
```

## **İçerik İşaretlemesiyle Bir Duyarlılık Etiketi Ekle**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabelcollection/#add) yöntemini etiket kimliği, site kimliği, etkin durumu ve atama yöntemiyle kullanın. Yöntem yeni bir [SensitivityLabel](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabel/) döndürdükten sonra, gerekli işaretleme değerlerini [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) tarafından döndürülen listeye ekleyin.

İşte aşağıdaki örnek, altbilgi ve filigran işaretlemeleriyle ilişkili, manuel olarak seçilmiş bir etiketi ekler ve ardından sonucu PPTX olarak kaydeder:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType, SensitivityLabelContentType
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = SensitivityLabelAssignmentType.Privileged

    sensitivity_label = sensitivity_labels.add(label_identifier, site_identifier, is_enabled, assignment_method)

    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Footer))
    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Watermark))

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bir Duyarlılık Etiketini Güncelle**

[SensitivityLabel](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabel/) değerleri okuma/yazma özelliktedir, ancak [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) tarafından döndürülen liste, liste işlemleriyle değiştirilir. Gerekli etiketi bulduktan sonra kimliğini, site kimliğini, etkin durumunu, atama yöntemini, kaldırma durumunu ve içerik işaretleme türlerini güncelleyebilirsiniz. Değişiklikleri kalıcı kılmak için sunumu kaydedin.

Aşağıdaki örnek, ilk etiketin etkin durumunu ve atama yöntemini günceller:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    if sensitivity_labels.getCount() > 0:
        sensitivity_label = sensitivity_labels.get_Item(0)
        sensitivity_label.setEnabled(True)
        sensitivity_label.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged)

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bir Duyarlılık Etiketini Kaldırılmış Olarak İşaretle**

Bir etiketin kaldırıldığını korumak için, etiketi bulup [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabel/#setRemoved) metodunu `True` ile çağırın. Bu, etiketi kaldırılmış durumunu kaydederek girişini tutar. Bunun yerine modern koleksiyondan bir girişi silmek isterseniz, [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabelcollection/#removeAt) kullanın; tüm girişleri silmek için [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabelcollection/#clear) kullanın.

Aşağıdaki örnek, belirli bir etiketi kaldırılmış olarak işaretler ve güncellenmiş sunumu kaydeder:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        is_target_label = str(sensitivity_label.getId()).casefold() == target_label_identifier.casefold()

        if is_target_label:
            sensitivity_label.setRemoved(True)
            break

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Eski MIP Duyarlılık Etiketlerini Oku ve Taşı**

Eski MIP tabanlı iş akışları, duyarlılık etiketi üst verilerini modern etiket koleksiyonu yerine özel belge özelliklerinde depolayabilir. Bu üst verileri [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/#getSensitivityLabels) ile okuyun. Yöntem eski özel özellikleri ayrıştırır ve bir [SensitivityLabel](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabel/) nesneleri dizisi döndürür.

Üst verileri taşımak için, döndürülen her etiketi modern [SensitivityLabelCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabelcollection/) içine [SensitivityLabelCollection.add](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabelcollection/#add) ile ekleyin. Aynı etiket kimliğini eklemek bir istisna oluşturduğundan, örnek her etiketi kopyalamadan önce hedef koleksiyonu kontrol eder. Her eski etiketin hâlâ geçerli Purview politikasında bulunduğunu doğrulamak için ek kontrol ekleyebilirsiniz.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation_with_legacy_labels.pptx")
try:
    legacy_sensitivity_labels = presentation.getDocumentProperties().getSensitivityLabels()
    modern_sensitivity_labels = presentation.getSensitivityLabels()

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = str(modern_sensitivity_label.getId()).casefold() == str(legacy_sensitivity_label.getId()).casefold()

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Taşıma, ayrıştırılmış etiket nesnelerini modern koleksiyona kopyalar. Tüm özel belge özelliklerini temizlemeyi gerektirmez, böylece alakasız belge üst verileri aynı kalır. Modern etiket üst verilerini bir PPTX dosyasına yazmak için [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) metodunu [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/) ile kullanın.

## **SSS**

**Bir içerik işaretleme türü eklemek slaytlarda görünür bir başlık, altbilgi veya filigran oluşturur mu?**

Hayır. [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) tarafından döndürülen listeye eklenen değerler, duyarlılık etiketiyle ilişkilendirilen işaretlemeleri açıklar. Bunlar sunumda görünür metin veya şekil oluşturmaz. İş akışınız bu işaretlemeleri görüntülemesi gerekiyorsa ilgili slayt içeriğini ayrı olarak ekleyin.

**Bir etiketi kaldırılmış olarak işaretlemek ile koleksiyondan silmek arasındaki fark nedir?**

[SensitivityLabel.setRemoved](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabel/#setRemoved) metodunu `True` ile çağırmak etiket girdisini tutar ve kaldırılmış durumunu kaydeder. [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabelcollection/#removeAt) metodunu çağırmak ise girdiyi modern koleksiyondan siler. Kuruluşunuzun üst veri saklama gereksinimlerine uygun işlemi seçin.

**Bir sunum hem eski MIP üst verilerini hem de modern duyarlılık etiketlerini içerebilir mi?**

Evet. Eski etiketler özel belge özelliklerinde kalabilirken modern etiketler [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getSensitivityLabels) aracılığıyla erişilebilir. Eski üst verileri okumak için [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/#getSensitivityLabels) kullanın ve modern koleksiyonda hâlihazırda bulunmayan geçerli etiketleri taşıyın.

**Aynı kimliğe sahip bir etiket birden fazla kez eklendiğinde ne olur?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabelcollection/#add) aynı kimliğe sahip bir etiket zaten koleksiyonda bulunduğunda bir istisna fırlatır. Etiket eklemeden veya taşıma işlemine başlamadan önce [SensitivityLabel.getId](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sensitivitylabel/#getId) tarafından döndürülen mevcut değerleri kontrol edin.

**Güncellenmiş duyarlılık etiketlerini korumak için hangi çıktı formatı kullanılmalıdır?**

Yukarıdaki örneklerde gösterildiği gibi, sunumu [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) metodunu [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/) ile çağırarak PPTX formatında kaydedin.