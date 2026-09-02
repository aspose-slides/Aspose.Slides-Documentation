---
title: PHP'de PowerPoint Sunumlarında Hassasiyet Etiketlerini Yönetme
linktitle: Hassasiyet Etiketleri
type: docs
weight: 50
url: /tr/php-java/sensitivity-labels/
keywords:
  - hassasiyet etiketi
  - Microsoft Purview
  - Microsoft Information Protection
  - MIP meta verileri
  - içerik işaretleme
  - bilgi koruması
  - belge yönetimi
  - PowerPoint
  - PPTX
  - sunum güvenliği
  - PHP
  - Aspose.Slides
description: "PHP'de PowerPoint PPTX sunumlarında Microsoft Purview hassasiyet etiketlerini okuyun, ekleyin, güncelleyin, kaldırın ve taşıyın."
---
## **Genel Bakış**

Microsoft Purview hassasiyet etiketleri, kuruluşların belgeleri sınıflandırmasına ve yönetmesine yardımcı olur. Otomatik sunum işleme sırasında, bir uygulama mevcut bir etiketi korumak, bir politika tarafından seçilen bir etiketi uygulamak, durumunu güncellemek veya daha eski bir Microsoft Information Protection (MIP) iş akışı tarafından yazılmış etiket meta verilerini taşımak zorunda kalabilir.

Aspose.Slides for PHP via Java, modern hassasiyet etiketi meta verilerini [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getSensitivityLabels) aracılığıyla sunar. Bu yöntem, sunumu PPTX olarak kaydedilmeden önce incelenebilen ve değiştirilebilen bir [SensitivityLabelCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabelcollection/) döndürür.

{{% alert color="primary" title="Note" %}}
Hassasiyet etiketi tanımlayıcıları ve politika bilgileri, Microsoft Purview yapılandırmanız tarafından tanımlanır. Meta verileri eklemeden veya taşımanıza önce ortamınızdaki etiket kullanılabilirliğini ve politika gereksinimlerini doğrulayın. [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) değerleri, bir etiketle ilişkili içerik işaretlemelerini tanımlar; bunlar tek başına slaytlara görünür metin veya şekil eklemez.
{{% /alert %}}

## **Hassasiyet Etiketi Özelliklerini Anlama**

Her bir [SensitivityLabel](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabel/) aşağıdaki meta verilere sahiptir:

| Yöntemler | Amaç |
| --- | --- |
| [SensitivityLabel::getId](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabel/#getId) and [SensitivityLabel::setId](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabel/#setId) | Purview politikasındaki hassasiyet etiketi tanımlayıcısını alır veya ayarlar. |
| [SensitivityLabel::getSiteId](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabel/#getSiteId) and [SensitivityLabel::setSiteId](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabel/#setSiteId) | Etiket politikasına bağlı siteyi alır veya ayarlar. |
| [SensitivityLabel::isEnabled](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabel/#isEnabled) and [SensitivityLabel::setEnabled](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabel/#setEnabled) | Etiketin etkin olup olmadığını alır veya ayarlar. |
| [SensitivityLabel::isRemoved](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabel/#isRemoved) and [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabel/#setRemoved) | Etiketin kaldırılıp kaldırılmadığını alır veya ayarlar. Kaldırma durumunun meta veride korunması gerektiğinde değeri `true` olarak ayarlayın. |
| [SensitivityLabel::getAssignmentMethodType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) and [SensitivityLabel::setAssignmentMethodType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Etiketin otomatik olarak mı yoksa kullanıcı kararıyla mı uygulandığını alır veya ayarlar. |
| [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Etiketle ilişkili içerik işaretleme türlerini alır. |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabelassignmenttype/) sınıfı, bir etiketin nasıl atandığını tanımlar:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabelassignmenttype/) varsayılan veya otomatik olarak uygulanmış bir etiketi temsil eder.
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabelassignmenttype/) kullanıcı kararıyla uygulanan, manuel uygulanmış, önerilen ve zorunlu etiketler dahil olmak üzere bir etiketi temsil eder.

[SensitivityLabelContentType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabelcontenttype/) sınıfı, bir etiketle ilişkili işaretlemeyi tanımlar:

| Değer | Anlam |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabelcontenttype/) | Etiket varsayılan veya otomatik olarak uygulanmıştır. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabelcontenttype/) | Üstbilgi içerik işaretlemesi etiketle ilişkilendirilmiştir. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabelcontenttype/) | Altbilgi içerik işaretlemesi etiketle ilişkilendirilmiştir. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabelcontenttype/) | Filigran içerik işaretlemesi etiketle ilişkilendirilmiştir. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabelcontenttype/) | Şifreleme koruması etiketle ilişkilendirilmiştir. |

Bir etiketle birden fazla işaretleme türü ilişkilendirilebilir.

## **Mevcut Hassasiyet Etiketlerini Listeleme**

Modern etiket koleksiyonunu [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getSensitivityLabels) ile okuyun ve üzerinden döngü kurun. Aşağıdaki örnek, her etiket için saklanan tüm özellikleri ve içerik işaretlemelerini listeler:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    for ($labelIndex = 0; $labelIndex < $sensitivityLabelCount; $labelIndex++) {
        $sensitivityLabel = $sensitivityLabels->get_Item($labelIndex);

        echo "Label ID: " . java_values($sensitivityLabel->getId()) . PHP_EOL;
        echo "Site ID: " . java_values($sensitivityLabel->getSiteId()->toString()) . PHP_EOL;
        echo "Enabled: " . (java_values($sensitivityLabel->isEnabled()) ? "true" : "false") . PHP_EOL;
        echo "Removed: " . (java_values($sensitivityLabel->isRemoved()) ? "true" : "false") . PHP_EOL;
        echo "Assignment method: " . java_values($sensitivityLabel->getAssignmentMethodType()) . PHP_EOL;

        $contentMarkIterator = $sensitivityLabel->getContentMarkTypes()->iterator();
        while (java_values($contentMarkIterator->hasNext())) {
            $contentMarkType = java_values($contentMarkIterator->next());
            echo "Content marking: " . $contentMarkType . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **İçerik İşaretlemesiyle Hassasiyet Etiketi Ekleme**

[SensitivityLabelCollection::add](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabelcollection/#add) yöntemini etiket tanımlayıcısı, site tanımlayıcısı, etkin durumu ve atama yöntemi ile kullanın. Yöntem yeni bir [SensitivityLabel](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabel/) döndürdükten sonra, gerekli işaretleme değerlerini [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) tarafından döndürülen listeye ekleyin.

Aşağıdaki örnek, altbilgi ve filigran işaretlemeleriyle ilişkilendirilmiş, manuel olarak seçilmiş bir etiketi ekler ve ardından sonucu PPTX olarak kaydeder:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();

    $labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    $UUID = new JavaClass("java.util.UUID");
    $siteIdentifier = $UUID->fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    $isEnabled = true;
    $assignmentMethod = SensitivityLabelAssignmentType::Privileged;

    $sensitivityLabel = $sensitivityLabels->add(
        $labelIdentifier,
        $siteIdentifier,
        $isEnabled,
        $assignmentMethod
    );

    $contentMarkTypes = $sensitivityLabel->getContentMarkTypes();
    $contentMarkTypes->addItem(SensitivityLabelContentType::Footer);
    $contentMarkTypes->addItem(SensitivityLabelContentType::Watermark);

    $presentation->save("presentation_with_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Hassasiyet Etiketini Güncelleme**

[SensitivityLabel] değerleri okuma/yazma özelliktedir, ancak [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) tarafından döndürülen liste, liste işlemleri aracılığıyla değiştirilir. Gerekli etiketi bulduktan sonra, tanımlayıcısını, site tanımlayıcısını, etkin durumunu, atama yöntemini, kaldırma durumunu ve içerik işaretleme türlerini güncelleyebilirsiniz. Değişiklikleri kalıcılaştırmak için sunumu kaydedin.

Aşağıdaki örnek, ilk etiketin etkin durumunu ve atama yöntemini günceller:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    if ($sensitivityLabelCount > 0) {
        $sensitivityLabel = $sensitivityLabels->get_Item(0);
        $sensitivityLabel->setEnabled(true);
        $sensitivityLabel->setAssignmentMethodType(SensitivityLabelAssignmentType::Privileged);
    }

    $presentation->save("presentation_with_updated_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Bir Hassasiyet Etiketini Kaldırıldı Olarak İşaretleme**

Bir etiketin kaldırıldığını kaydetmek için, etiketi bulun ve [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabel/#setRemoved) yöntemini `true` ile çağırın. Bu, etiketi giriş olarak tutarken kaldırılmış durumunu kaydeder. Modern koleksiyondan bir girişi silmek istiyorsanız, [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabelcollection/#removeAt) yöntemini kullanın; tüm girişleri silmek için [SensitivityLabelCollection::clear](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabelcollection/#clear) yöntemini kullanın.

Aşağıdaki örnek, belirli bir etiketi kaldırıldı olarak işaretler ve güncellenmiş sunumu kaydeder:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    for ($labelIndex = 0; $labelIndex < $sensitivityLabelCount; $labelIndex++) {
        $sensitivityLabel = $sensitivityLabels->get_Item($labelIndex);
        $labelIdentifier = java_values($sensitivityLabel->getId());
        $isTargetLabel = strcasecmp($labelIdentifier, $targetLabelIdentifier) === 0;

        if ($isTargetLabel) {
            $sensitivityLabel->setRemoved(true);
            break;
        }
    }

    $presentation->save("presentation_with_removed_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Eski MIP Hassasiyet Etiketlerini Okuma ve Taşıma**

Eski MIP tabanlı iş akışları, hassasiyet etiketi meta verilerini modern etiket koleksiyonu yerine özel belge özelliklerinde saklayabilir. Bu meta verileri [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/tr/php-java/aspose.slides/documentproperties/#getSensitivityLabels) ile okuyun. Yöntem, eski özel özellikleri ayrıştırır ve bir Java dizisi olarak [SensitivityLabel](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabel/) nesnelerini döndürür.

Meta verileri taşımak için, her döndürülen etiketi modern [SensitivityLabelCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabelcollection/) içine [SensitivityLabelCollection::add](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabelcollection/#add) ile ekleyin. Çift etiket tanımlayıcısı eklenmesi bir istisna oluşturduğu için, örnek her etiketi kopyalamadan önce hedef koleksiyonu kontrol eder. Mevcut Purview politikasında her eski etiketin hâlâ mevcut olduğunu onaylamak için ek doğrulama ekleyebilirsiniz.

```php
$presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    $legacySensitivityLabels = $presentation->getDocumentProperties()->getSensitivityLabels();
    $modernSensitivityLabels = $presentation->getSensitivityLabels();

    $Array = new JavaClass("java.lang.reflect.Array");
    $legacyLabelCount = java_values($Array->getLength($legacySensitivityLabels));

    for ($legacyLabelIndex = 0; $legacyLabelIndex < $legacyLabelCount; $legacyLabelIndex++) {
        $legacySensitivityLabel = $legacySensitivityLabels[$legacyLabelIndex];
        $legacyLabelIdentifier = java_values($legacySensitivityLabel->getId());
        $labelAlreadyExists = false;
        $modernLabelCount = java_values($modernSensitivityLabels->getCount());

        for ($modernLabelIndex = 0; $modernLabelIndex < $modernLabelCount; $modernLabelIndex++) {
            $modernSensitivityLabel = $modernSensitivityLabels->get_Item($modernLabelIndex);
            $modernLabelIdentifier = java_values($modernSensitivityLabel->getId());
            $labelAlreadyExists = strcasecmp(
                $modernLabelIdentifier,
                $legacyLabelIdentifier
            ) === 0;

            if ($labelAlreadyExists) {
                break;
            }
        }

        if (!$labelAlreadyExists) {
            $modernSensitivityLabels->add($legacySensitivityLabel);
        }
    }

    $presentation->save("presentation_with_modern_labels.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Taşıma, ayrıştırılan etiket nesnelerini modern koleksiyona kopyalar. Tüm özel belge özelliklerini temizlemeyi gerektirmez, böylece ilgili olmayan belge meta verileri sağlam kalır. Modern etiket meta verilerini bir PPTX dosyasına yazmak için [Presentation::save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#save) ile [SaveFormat::Pptx](https://reference.aspose.com/slides/tr/php-java/aspose.slides/saveformat/) kullanın.

## **SSS**

**Bir içerik işaretleme türü eklemek, slaytlarda görünür bir üstbilgi, altbilgi veya filigran oluşturur mu?**

Hayır. [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) aracılığıyla listeye eklenen değerler, hassasiyet etiketiyle ilişkili işaretlemeleri tanımlar. Bunlar sunumda görünür metin veya şekil oluşturmaz. İş akışınız bu işaretlemeleri render etmesi gerekiyorsa, ilgili slayt içeriğini ayrı olarak ekleyin.

**Bir etiketi kaldırıldı olarak işaretlemek ile koleksiyondan silmek arasındaki fark nedir?**

`[SensitivityLabel::setRemoved](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabel/#setRemoved)` yöntemini `true` ile çağırmak, etiket girişini tutar ve kaldırılmış durumunu kaydeder. `[SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabelcollection/#removeAt)` yöntemi ise etiketi modern koleksiyondan siler. Organizasyonunuzun meta veri saklama gereksinimlerine uygun olan işlemi seçin.

**Bir sunum hem eski MIP meta verilerini hem de modern hassasiyet etiketlerini içerebilir mi?**

Evet. Eski etiketler özel belge özelliklerinde kalabilirken, modern etiketler [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getSensitivityLabels) aracılığıyla ulaşılabilir. Eski meta verileri okumak ve yalnızca modern koleksiyonda bulunmayan geçerli etiketleri taşımak için [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/tr/php-java/aspose.slides/documentproperties/#getSensitivityLabels) kullanın.

**Aynı tanımlayıcıya sahip bir etiket birden fazla eklendiğinde ne olur?**

`[SensitivityLabelCollection::add](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabelcollection/#add)` aynı tanımlayıcıya sahip bir etiket zaten koleksiyonda bulunuyorsa bir istisna oluşturur. Etiket eklemeden veya taşımadan önce `[SensitivityLabel::getId](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sensitivitylabel/#getId)` ile mevcut değerleri kontrol edin.

**Güncellenmiş hassasiyet etiketlerini korumak için hangi çıktı formatı kullanılmalıdır?**

Güncellenmiş hassasiyet etiketlerini korumak için sunumu **PPTX** formatında, `[Presentation::save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#save)` ile `[SaveFormat::Pptx](https://reference.aspose.com/slides/tr/php-java/aspose.slides/saveformat/)` çağırarak kaydedin; yukarıdaki örneklerde gösterildiği gibi.