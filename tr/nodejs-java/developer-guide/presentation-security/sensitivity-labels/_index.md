---
title: PowerPoint Sunumlarında JavaScript ile Duyarlılık Etiketlerini Yönetme
linktitle: Duyarlılık Etiketleri
type: docs
weight: 50
url: /tr/nodejs-java/sensitivity-labels/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java kullanarak PowerPoint PPTX sunumlarında Microsoft Purview duyarlılık etiketlerini okuyun, ekleyin, güncelleyin, kaldırın ve taşıyın."
---
## **Genel Bakış**

Microsoft Purview duyarlılık etiketleri, kuruluşların belgeleri sınıflandırmasına ve yönetmesine yardımcı olur. Otomatik sunum işleme sırasında, bir uygulama mevcut bir etiketi korumak, bir politika tarafından seçilen bir etiketi uygulamak, durumunu güncellemek veya eski bir Microsoft Information Protection (MIP) iş akışı tarafından yazılmış etiket üst verilerini taşımak zorunda kalabilir.

Aspose.Slides for Node.js via Java, modern duyarlılık etiketi üst verilerini [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) aracılığıyla sunar. Bu yöntem, sunum PPTX olarak kaydedilmeden önce incelenebilen ve değiştirilebilen bir [SensitivityLabelCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabelcollection/) döndürür.

{{% alert color="primary" title="Note" %}}
Duyarlılık etiketi tanımlayıcıları ve politika bilgileri, Microsoft Purview yapılandırmanız tarafından tanımlanır. Üst verileri eklemeden veya taşımadan önce ortamınızdaki etiket kullanılabilirliğini ve politika gereksinimlerini doğrulayın. [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) değerleri, bir etiketle ilişkilendirilen içerik işaretlemelerini tanımlar; bunlar tek başına slaytlara görünür metin veya şekil eklemez.
{{% /alert %}}

## **Duyarlılık Etiketi Özelliklerini Anlamak**

Her [SensitivityLabel](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabel/) aşağıdaki üst verileri içerir:

| Yöntemler | Amaç |
| --- | --- |
| [SensitivityLabel.getId](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabel/#getId) ve [SensitivityLabel.setId](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabel/#setId) | Purview politikasındaki duyarlılık etiketi tanımlayıcısını alır veya ayarlar. |
| [SensitivityLabel.getSiteId](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabel/#getSiteId) ve [SensitivityLabel.setSiteId](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabel/#setSiteId) | Etiket politikasına ilişkilendirilen siteyi alır veya ayarlar. |
| [SensitivityLabel.isEnabled](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabel/#isEnabled) ve [SensitivityLabel.setEnabled](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabel/#setEnabled) | Etiketin etkin olup olmadığını alır veya ayarlar. |
| [SensitivityLabel.isRemoved](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabel/#isRemoved) ve [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) | Etiketin kaldırılmış olup olmadığını alır veya ayarlar. Kaldırma durumunun üst veride tutulması gerektiğinde değeri `true` olarak ayarlayın. |
| [SensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) ve [SensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Etiketin otomatik olarak mı yoksa kullanıcı kararıyla mı uygulandığını alır veya ayarlar. |
| [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Etiketle ilişkilendirilmiş içerik işaretleme tiplerini alır. |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) sınıfı, bir etiketin nasıl atandığını tanımlar:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) varsayılan veya otomatik olarak uygulanmış bir etiketi temsil eder.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) kullanıcı kararıyla uygulanmış bir etiketi temsil eder; manuel olarak uygulanmış, önerilen ve zorunlu etiketleri içerir.

[SensitivityLabelContentType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) sınıfı, bir etiketle ilişkili işaretlemeyi tanımlar:

| Değer | Anlam |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Etiket varsayılan olarak veya otomatik şekilde uygulanmıştır. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Üstbilgi içerik işaretlemesi etiketle ilişkilendirilmiştir. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Altbilgi içerik işaretlemesi etiketle ilişkilendirilmiştir. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Filigran içerik işaretlemesi etiketle ilişkilendirilmiştir. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Şifreleme koruması etiketle ilişkilendirilmiştir. |

Bir etiketle birden çok işaretleme türü ilişkilendirilebilir.

## **Mevcut Duyarlılık Etiketlerini Listeleme**

Modern etiket koleksiyonunu [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) ile okuyun ve enumerate edin. Aşağıdaki örnek, her etiket için saklanan tüm özellikleri ve içerik işaretlemelerini listeler:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const siteIdentifier = sensitivityLabel.getSiteId();
        const isEnabled = sensitivityLabel.isEnabled();
        const isRemoved = sensitivityLabel.isRemoved();
        const assignmentMethod = sensitivityLabel.getAssignmentMethodType();

        console.log("Label ID: " + labelIdentifier);
        console.log("Site ID: " + siteIdentifier);
        console.log("Enabled: " + isEnabled);
        console.log("Removed: " + isRemoved);
        console.log("Assignment method: " + assignmentMethod);

        const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
        const contentMarkCount = contentMarkTypes.size();

        for (let contentMarkIndex = 0; contentMarkIndex < contentMarkCount; contentMarkIndex++) {
            const contentMarkType = contentMarkTypes.get_Item(contentMarkIndex);
            console.log("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **İçerik İşaretlemesiyle Duyarlılık Etiketi Ekleme**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) yöntemini etiket tanımlayıcısı, site tanımlayıcısı, etkin durumu ve atama yöntemiyle kullanın. Yöntem yeni bir [SensitivityLabel](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabel/) döndürdükten sonra, gerekli işaretleme değerlerini [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) tarafından döndürülen listeye ekleyin.

Aşağıdaki örnek, altbilgi ve filigran işaretlemeleriyle ilişkilendirilmiş manuel seçilmiş bir etiket ekler ve ardından sonucu PPTX olarak kaydeder:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();

    const labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const siteIdentifier = java.callStaticMethodSync(
        "java.util.UUID",
        "fromString",
        "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    const isEnabled = true;
    const assignmentMethod = aspose.slides.SensitivityLabelAssignmentType.Privileged;

    const sensitivityLabel = sensitivityLabels.add(
        labelIdentifier,
        siteIdentifier,
        isEnabled,
        assignmentMethod);

    const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Footer);
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Duyarlılık Etiketini Güncelleme**

[SensitivityLabel](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabel/) değerleri okuma/yazma özelliğine sahiptir; ancak [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) tarafından döndürülen liste, liste işlemleriyle değiştirilir. Gerekli etiketi bulduktan sonra, tanımlayıcısını, site tanımlayıcısını, etkin durumunu, atama yöntemini, kaldırma durumunu ve içerik işaretleme türlerini güncelleyebilirsiniz. Değişiklikleri kalıcı kılmak için sunumu kaydedin.

Aşağıdaki örnek, ilk etiketin etkin durumunu ve atama yöntemini günceller:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    if (labelCount > 0) {
        const sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(
            aspose.slides.SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Duyarlılık Etiketini Kaldırılmış Olarak İşaretleme**

Bir etiketin kaldırıldığını korumak için, etiketi bulun ve [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) yöntemini `true` ile çağırın. Bu, etiket kaydını tutar ve kaldırma durumunu kaydeder. Bunun yerine modern koleksiyondan bir girişi silmeniz gerekiyorsa, [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt) kullanın; tüm girişleri silmek için [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabelcollection/#clear) kullanın.

Aşağıdaki örnek, belirli bir etiketi kaldırılmış olarak işaretler ve güncellenmiş sunumu kaydeder:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const isTargetLabel = labelIdentifier.toLowerCase() === targetLabelIdentifier.toLowerCase();

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Eski MIP Duyarlılık Etiketlerini Okuma ve Taşıma**

Daha eski MIP tabanlı iş akışları, modern etiket koleksiyonu yerine özelleştirilmiş belge özelliklerinde duyarlılık etiketi üst verilerini depolayabilir. Bu üst verileri [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels) ile okuyun. Yöntem, eski özelleştirilmiş özellikleri ayrıştırır ve bir [SensitivityLabel](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabel/) nesneleri dizisi döndürür.

Üst verileri taşımak için, dönen her etiketi modern [SensitivityLabelCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabelcollection/) içine [SensitivityLabelCollection.add](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) ile ekleyin. Aynı etiket tanımlayıcısını eklemek bir istisna oluşturduğundan, örnek her etiketi kopyalamadan önce hedef koleksiyonu kontrol eder. Her eski etiketin hâlâ geçerli Purview politikasında mevcut olduğunu doğrulamak için ek doğrulama ekleyebilirsiniz.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation_with_legacy_labels.pptx");
try {
    const legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    const modernSensitivityLabels = presentation.getSensitivityLabels();

    for (let legacyLabelIndex = 0; legacyLabelIndex < legacySensitivityLabels.length; legacyLabelIndex++) {
        const legacySensitivityLabel = legacySensitivityLabels[legacyLabelIndex];
        const legacyLabelIdentifier = legacySensitivityLabel.getId();
        const modernLabelCount = modernSensitivityLabels.getCount();
        let labelAlreadyExists = false;

        for (let modernLabelIndex = 0; modernLabelIndex < modernLabelCount; modernLabelIndex++) {
            const modernSensitivityLabel = modernSensitivityLabels.get_Item(modernLabelIndex);
            const modernLabelIdentifier = modernSensitivityLabel.getId();

            labelAlreadyExists =
                modernLabelIdentifier.toLowerCase() === legacyLabelIdentifier.toLowerCase();

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Taşıma, ayrıştırılmış etiket nesnelerini modern koleksiyona kopyalar. Tüm özelleştirilmiş belge özelliklerini temizlemeye gerek yoktur; böylece ilgili olmayan belge üst verileri korunur. Modern etiket üst verilerini bir PPTX dosyasına yazmak için [Presentation.save](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#save) ile [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/saveformat/) kullanın.

## **SSS**

**Bir içerik işaretleme türü eklemek, slaytlarda görünür bir üstbilgi, altbilgi veya filigran oluşturur mu?**

Hayır. [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) tarafından döndürülen listeye eklenen değerler, duyarlılık etiketiyle ilişkilendirilen işaretlemeleri tanımlar. Bunlar sunumda görünür metin veya şekil oluşturmaz. İş akışınız bu işaretlemeleri göstermek zorundaysa, ilgili slayt içeriğini ayrı olarak ekleyin.

**Bir etiketi kaldırılmış olarak işaretlemek ile koleksiyondan silmek arasındaki fark nedir?**

[SensitivityLabel.setRemoved](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) yöntemini `true` ile çağırmak, etiket kaydını tutar ve kaldırma durumunu kaydeder. [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt) yöntemini çağırmak, modern koleksiyondan kaydı siler. Kuruluşunuzun üst veri saklama gereksinimlerine uygun işlemi seçin.

**Bir sunum hem eski MIP üst verilerini hem de modern duyarlılık etiketlerini içerebilir mi?**

Evet. Eski etiketler özelleştirilmiş belge özelliklerinde kalabilirken, modern etiketler [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) aracılığıyla erişilebilir. Eski üst verileri okumak ve modern koleksiyonda hâlâ bulunmayan geçerli etiketleri taşımak için [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels) kullanın.

**Aynı tanımlayıcıya sahip bir etiket birden çok kez eklenirse ne olur?**

Koleksiyon aynı tanımlayıcıya sahip bir etiketi zaten içeriyorsa, [SensitivityLabelCollection.add](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) bir istisna oluşturur. Etiket eklemeden veya taşımadan önce mevcut değerleri [SensitivityLabel.getId](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sensitivitylabel/#getId) ile kontrol edin.

**Güncellenmiş duyarlılık etiketlerini korumak için hangi çıktı formatı kullanılmalıdır?**

Yukarıdaki örneklerde gösterildiği gibi, [Presentation.save](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#save) ile [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/saveformat/) kullanarak sunumu PPTX olarak kaydedin.