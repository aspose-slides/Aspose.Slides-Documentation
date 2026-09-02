---
title: Android'de PowerPoint Sunumlarında Duyarlılık Etiketlerini Yönetme
linktitle: Duyarlılık Etiketleri
type: docs
weight: 50
url: /tr/androidjava/sensitivity-labels/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile PowerPoint PPTX sunumlarında Microsoft Purview duyarlılık etiketlerini okuma, ekleme, güncelleme, kaldırma ve taşıma."
---
## **Genel Bakış**

Microsoft Purview duyarlılık etiketleri, kuruluşların belgeleri sınıflandırmasına ve yönetmesine yardımcı olur. Otomatik sunum işleme sırasında, bir uygulama mevcut bir etiketi korumak, bir politika tarafından seçilen bir etiketi uygulamak, durumunu güncellemek veya eski bir Microsoft Information Protection (MIP) iş akışı tarafından yazılmış etiket üst verilerini taşımak isteyebilir.

Aspose.Slides for Android via Java, modern duyarlılık etiketi üst verilerini [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) aracılığıyla sunar. Bu yöntem, sunum PPTX olarak kaydedilmeden önce incelenebilen ve değiştirilebilen bir [ISensitivityLabelCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isensitivitylabelcollection/) döndürür.

{{% alert color="primary" title="Note" %}}
Duyarlılık etiketi tanımlayıcıları ve politika bilgileri Microsoft Purview yapılandırmanız tarafından tanımlanır. Üst verileri eklemeden veya taşımadan önce ortamınızdaki etiket kullanılabilirliğini ve politika gereksinimlerini doğrulayın. [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) değerleri, bir etiketle ilişkilendirilen içerik işaretlemelerini açıklar; bunlar tek başına slaytlara görünür metin veya şekil eklemez.
{{% /alert %}}

## **Duyarlılık Etiketi Özelliklerini Anlama**

Her bir [ISensitivityLabel](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isensitivitylabel/) aşağıdaki üst verileri içerir:

| Yöntemler | Amaç |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isensitivitylabel/#getId--) ve [ISensitivityLabel.setId](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Purview politikasındaki duyarlılık etiketi tanımlayıcısını alır veya ayarlar. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isensitivitylabel/#getSiteId--) ve [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | Etiket politikasına ilişkili siteyi alır veya ayarlar. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isensitivitylabel/#isEnabled--) ve [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | Etiketin etkin olup olmadığını alır veya ayarlar. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isensitivitylabel/#isRemoved--) ve [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | Etiketin kaldırılmış olup olmadığını alır veya ayarlar. Kaldırma durumunun üst veride tutulması gerektiğinde değeri `true` olarak ayarlayın. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) ve [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | Etiketin otomatik olarak mı yoksa kullanıcı kararıyla mı uygulandığını alır veya ayarlar. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | Etiketle ilişkili içerik işaretleme türlerini alır. |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) sınıfı, bir etiketin nasıl atandığını tanımlar:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) varsayılan veya otomatik olarak uygulanmış bir etiketi temsil eder.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) kullanıcı kararıyla, manuel olarak uygulanmış, önerilen ve zorunlu etiketler dahil olmak üzere uygulanan bir etiketi temsil eder.

[SensitivityLabelContentType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) sınıfı, bir etiketle ilişkili işaretlemeyi tanımlar:

| Değer | Anlam |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Etiket varsayılan olarak veya otomatik olarak uygulanmıştır. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Başlık içerik işaretlemesi etiketle ilişkilidir. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Altbilgi içerik işaretlemesi etiketle ilişkilidir. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Filigran içerik işaretlemesi etiketle ilişkilidir. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Şifreleme koruması etiketle ilişkilidir. |

Bir etiket birden çok işaretleme türüyle ilişkilendirilebilir.

## **Mevcut Duyarlılık Etiketlerini Listeleme**

[IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) üzerinden modern etiket koleksiyonunu okuyun ve enumerate edin. Aşağıdaki örnek, her etiket için saklanan tüm özellikleri ve içerik işaretlemelerini listeler:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        System.out.println("Label ID: " + sensitivityLabel.getId());
        System.out.println("Site ID: " + sensitivityLabel.getSiteId());
        System.out.println("Enabled: " + sensitivityLabel.isEnabled());
        System.out.println("Removed: " + sensitivityLabel.isRemoved());
        System.out.println("Assignment method: " + sensitivityLabel.getAssignmentMethodType());

        for (Integer contentMarkType : sensitivityLabel.getContentMarkTypes()) {
            System.out.println("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **İçerik İşaretleme ile Duyarlılık Etiketi Ekleme**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) yöntemini etiket tanımlayıcısı, site tanımlayıcısı, etkin durumu ve atama yöntemiyle kullanın. Yöntem yeni bir [ISensitivityLabel](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isensitivitylabel/) döndürdükten sonra, gereken işaretleme değerlerini [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) tarafından döndürülen listeye ekleyin.

Aşağıdaki örnek, altbilgi ve filigran işaretlemeleriyle ilişkilendirilmiş manuel seçilmiş bir etiket ekler ve ardından sonucu PPTX olarak kaydeder:

```java
import com.aspose.slides.*;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    String labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    UUID siteIdentifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    boolean isEnabled = true;
    int assignmentMethod = SensitivityLabelAssignmentType.Privileged;

    ISensitivityLabel sensitivityLabel = sensitivityLabels.add(
            labelIdentifier,
            siteIdentifier,
            isEnabled,
            assignmentMethod);

    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Footer);
    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Duyarlılık Etiketini Güncelleme**

[ISensitivityLabel](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isensitivitylabel/) değerleri okuma/yazma özelliktedir; ancak [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) tarafından döndürülen liste, liste operasyonları aracılığıyla değiştirilir. Gerekli etiketi bulduktan sonra, tanımlayıcısını, site tanımlayıcısını, etkin durumunu, atama yöntemini, kaldırma durumunu ve içerik işaretleme türlerini güncelleyebilirsiniz. Değişiklikleri kalıcı kılmak için sunumu kaydedin.

Aşağıdaki örnek, ilk etiketin etkin durumunu ve atama yöntemini günceller:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    if (sensitivityLabels.getCount() > 0) {
        ISensitivityLabel sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bir Duyarlılık Etiketini Kaldırılmış Olarak İşaretleme**

Bir etiketin kaldırıldığını korumak için etiketi bulun ve [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) yöntemini `true` ile çağırın. Bu, etiket girişini tutarken kaldırılmış durumunu kaydeder. Modern koleksiyondan bir girişi tamamen silmek isterseniz, [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) kullanın; tüm girişleri silmek için [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isensitivitylabelcollection/#clear--) kullanın.

Aşağıdaki örnek, belirli bir etiketi kaldırılmış olarak işaretler ve güncellenmiş sunumu kaydeder:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();
    String targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        boolean isTargetLabel = sensitivityLabel.getId().equalsIgnoreCase(targetLabelIdentifier);

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Eski MIP Duyarlılık Etiketlerini Okuma ve Taşıma**

Eski MIP tabanlı iş akışları, duyarlılık etiketi üst verilerini modern etiket koleksiyonu yerine özel belge özelliklerinde saklayabilir. Bu üst verileri [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) ile okuyun. Yöntem, eski özel özellikleri ayrıştırır ve bir dizi [ISensitivityLabel](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isensitivitylabel/) nesnesi döndürür.

Üst verileri taşımak için, her döndürülen etiketi modern [ISensitivityLabelCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isensitivitylabelcollection/) içine [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-) ile ekleyin. Çift etiket tanımlayıcısının eklenmesi bir istisna fırlattığından, örnek her etiketi kopyalamadan önce hedef koleksiyonu kontrol eder. Her eski etiketin hâlâ geçerli Purview politikasında bulunup bulunmadığını doğrulamak için ek kontroller ekleyebilirsiniz.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    ISensitivityLabel[] legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    ISensitivityLabelCollection modernSensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel legacySensitivityLabel : legacySensitivityLabels) {
        boolean labelAlreadyExists = false;

        for (ISensitivityLabel modernSensitivityLabel : modernSensitivityLabels) {
            labelAlreadyExists = modernSensitivityLabel.getId().equalsIgnoreCase(
                    legacySensitivityLabel.getId());

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Taşıma, ayrıştırılan etiket nesnelerini modern koleksiyona kopyalar. Tüm özel belge özelliklerinin temizlenmesini gerektirmez; böylece ilgili olmayan belge üst verileri bozulmaz. Modern etiket üst verilerini bir PPTX dosyasına yazmak için [IPresentation.save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) ile [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/saveformat/) kullanın.

## **SSS**

**Bir içerik işaretleme türü eklemek slaytlarda görünen bir başlık, altbilgi veya filigran oluşturur mu?**

Hayır. [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) aracılığıyla eklenen değerler, duyarlılık etiketiyle ilişkili işaretlemeleri tanımlar. Sunumda görünür metin veya şekil oluşturmazlar. İş akışınız bu işaretlemeleri göstermek zorundaysa, ilgili slayt içeriğini ayrı olarak ekleyin.

**Bir etiketi kaldırılmış olarak işaretlemek ile koleksiyondan silmek arasındaki fark nedir?**

[ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) yöntemini `true` ile çağırmak, etiketi tutar ve kaldırılmış durumunu kaydeder. [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) yöntemi ise etiketi modern koleksiyondan tamamen siler. Organizasyonunuzun üst veri saklama gereksinimlerine uygun olan işlemi seçin.

**Bir sunum hem eski MIP üst verilerini hem de modern duyarlılık etiketlerini içerebilir mi?**

Evet. Eski etiketler özel belge özelliklerinde kalabilirken, modern etiketler [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) aracılığıyla erişilebilir. Eski üst verileri okumak ve hâlâ modern koleksiyonda olmayan geçerli etiketleri taşımak için [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) kullanın.

**Aynı tanımlayıcıya sahip bir etiket birden çok kez eklendiğinde ne olur?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) yöntemi, koleksiyon zaten aynı tanımlayıcıya sahip bir etiket içeriyorsa bir istisna fırlatır. Etiket eklemeden veya taşımadan önce mevcut değerleri [ISensitivityLabel.getId](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isensitivitylabel/#getId--) ile kontrol edin.

**Güncellenen duyarlılık etiketlerini korumak için hangi çıktı formatı kullanılmalıdır?**

Sunumu, yukarıdaki örneklerde gösterildiği gibi, [IPresentation.save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) yöntemini [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/saveformat/) ile çağırarak PPTX formatında kaydedin.