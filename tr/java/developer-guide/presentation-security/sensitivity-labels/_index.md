---
title: PowerPoint Sunumlarında Java ile Duyarlılık Etiketlerini Yönetme
linktitle: Duyarlılık Etiketleri
type: docs
weight: 50
url: /tr/java/sensitivity-labels/
keywords:
- duyarlılık etiketi
- Microsoft Purview
- Microsoft Information Protection
- MIP meta verileri
- içerik işaretleme
- bilgi koruması
- belge yönetimi
- PowerPoint
- PPTX
- sunum güvenliği
- Java
- Aspose.Slides
description: "Microsoft Purview duyarlılık etiketlerini PowerPoint PPTX sunumlarında Aspose.Slides for Java ile okuyun, ekleyin, güncelleyin, kaldırın ve taşıyın."
---
## **Genel Bakış**

Microsoft Purview duyarlılık etiketleri, kuruluşların belgeleri sınıflandırmasına ve yönetmesine yardımcı olur. Otomatik sunum işleme sırasında bir uygulama mevcut etiketi korumak, bir politika tarafından seçilen bir etiketi uygulamak, durumunu güncellemek veya eski bir Microsoft Information Protection (MIP) iş akışı tarafından oluşturulan etiket meta verilerini taşımak isteyebilir.

Aspose.Slides, modern duyarlılık etiketi meta verilerini [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) aracılığıyla sunar. Bu yöntem, sunum PPTX olarak kaydedilmeden önce incelenebilen ve değiştirilebilen bir [ISensitivityLabelCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabelcollection/) döndürür.

{{% alert color="info" title="Not" %}}
Duyarlılık etiketi kimlikleri ve politika bilgileri, Microsoft Purview yapılandırmanız tarafından tanımlanır. Meta verileri eklemeden veya taşımadan önce ortamınızda etiketin kullanılabilirliğini ve politika gereksinimlerini doğrulayın. [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) değerleri, bir etiketle ilişkilendirilen içerik işaretlemelerini tanımlar; bunlar tek başına slaytlara görünür metin veya şekil eklemez.
{{% /alert %}}

## **Duyarlılık Etiketi Özelliklerini Anlamak**

Her bir [ISensitivityLabel](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/) aşağıdaki meta verilere sahiptir:

| Yöntemler | Amaç |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#getId--) ve [ISensitivityLabel.setId](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Purview politikasındaki duyarlılık etiketi kimliğini alır veya ayarlar. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#getSiteId--) ve [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | Etiket politikasına bağlı siteyi alır veya ayarlar. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#isEnabled--) ve [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | Etiketin etkin olup olmadığını alır veya ayarlar. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#isRemoved--) ve [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | Etiketin kaldırılıp kaldırılmadığını alır veya ayarlar. Kaldırma durumu meta veride tutulmalıysa değeri `true` olarak ayarlayın. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) ve [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | Etiketin otomatik olarak mı yoksa bir kullanıcı kararıyla mı uygulandığını alır veya ayarlar. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | Etiketle ilişkilendirilen içerik işaretleme türlerini alır. |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/sensitivitylabelassignmenttype/) sınıfı, bir etiketin nasıl atandığını tanımlar:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/tr/java/com.aspose.slides/sensitivitylabelassignmenttype/) varsayılan veya otomatik olarak uygulanan bir etiketi temsil eder.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/tr/java/com.aspose.slides/sensitivitylabelassignmenttype/) bir kullanıcı kararıyla uygulanan etiketi temsil eder; manuel uygulanmış, önerilen ve zorunlu etiketler bu gruba girer.

[SensitivityLabelContentType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/sensitivitylabelcontenttype/) sınıfı, bir etiketle ilişkili işaretlemeyi tanımlar:

| Değer | Anlam |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/tr/java/com.aspose.slides/sensitivitylabelcontenttype/) | Etiket varsayılan veya otomatik olarak uygulanmıştır. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/tr/java/com.aspose.slides/sensitivitylabelcontenttype/) | Başlık içerik işaretlemesi etikete ilişkilidir. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/tr/java/com.aspose.slides/sensitivitylabelcontenttype/) | Alt bilgi içerik işaretlemesi etikete ilişkilidir. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/tr/java/com.aspose.slides/sensitivitylabelcontenttype/) | Filigran içerik işaretlemesi etikete ilişkilidir. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/tr/java/com.aspose.slides/sensitivitylabelcontenttype/) | Şifreleme koruması etikete ilişkilidir. |

Bir etiket birden fazla işaretleme türüyle ilişkilendirilebilir.

## **Mevcut Duyarlılık Etiketlerini Listele**

Modern etiket koleksiyonunu [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) ile okuyun ve döngüye alın. Aşağıdaki örnek, her etiket için depolanan tüm özellikleri ve içerik işaretlemelerini listeler:

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

## **İçerik İşaretlemesiyle Bir Duyarlılık Etiketi Ekle**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) yöntemini etiket kimliği, site kimliği, etkin durumu ve atama yöntemiyle kullanın. Yöntem yeni bir [ISensitivityLabel](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/) döndürdükten sonra, gerekli işaretleme değerlerini [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) tarafından döndürülen listeye ekleyin.

Aşağıdaki örnek, alt bilgi ve filigran işaretlemeleriyle ilişkili manuel olarak seçilen bir etiketi ekler ve sonucu PPTX olarak kaydeder:

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

## **Bir Duyarlılık Etiketini Güncelle**

[ISensitivityLabel](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/) değerleri okuma/yazma özelliktedir; sadece [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) tarafından döndürülen liste, liste operasyonlarıyla değiştirilir. Gerekli etiketi bulduktan sonra kimliğini, site kimliğini, etkin durumunu, atama yöntemini, kaldırma durumunu ve içerik işaretleme türlerini güncelleyebilirsiniz. Değişiklikleri kalıcı hâle getirmek için sunumu kaydedin.

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

## **Bir Duyarlılık Etiketini Kaldırıldı Olarak İşaretle**

Bir etiketin kaldırıldığını kaydetmek için etiketi bulun ve [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) yöntemini `true` ile çağırın. Bu, etiket girişini tutar ve kaldırma durumunu kaydeder. Modern koleksiyondan bir girişi tamamen silmeniz gerekiyorsa, [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) yöntemini kullanın; tüm girişleri silmek için ise [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabelcollection/#clear--) yöntemini uygulayın.

Aşağıdaki örnek, belirli bir etiketi kaldırıldı olarak işaretler ve güncellenmiş sunumu kaydeder:

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

## **Eski MIP Duyarlılık Etiketlerini Oku ve Taşı**

Eski MIP tabanlı iş akışları, duyarlılık etiketi meta verilerini modern etiket koleksiyonu yerine özel belge özelliklerinde saklayabilir. Bu meta verileri [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) ile okuyun. Yöntem, eski özel özellikleri ayrıştırır ve bir dizi [ISensitivityLabel](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/) nesnesi döndürür.

Meta verileri taşımak için, döndürülen her etiketi modern [ISensitivityLabelCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabelcollection/) içine [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-) ile ekleyin. Aynı kimliğe sahip bir etiketi eklemek bir istisna oluşturduğundan, örnek her etiketi kopyalamadan önce hedef koleksiyonu kontrol eder. Ayrıca, her eski etiketin hâlâ geçerli Purview politikasında bulunduğunu doğrulamak için ek doğrulama ekleyebilirsiniz.

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

Taşıma işlemi, ayrıştırılmış etiket nesnelerini modern koleksiyona kopyalar. Tüm özel belge özelliklerini temizlemeyi gerektirmez; böylece ilgili olmayan belge meta verileri aynı kalır. Modern etiket meta verilerini bir PPTX dosyasına yazmak için [IPresentation.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) yöntemini [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/java/com.aspose.slides/saveformat/) ile kullanın.

## **SSS**

**Bir içerik işaretleme türü eklemek slaytlara görünür bir başlık, alt bilgi veya filigran oluşturur mu?**

Hayır. [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) tarafından döndürülen listeye eklenen değerler, duyarlılık etiketiyle ilişkili işaretlemeleri tanımlar. Bunlar sunumda görünür metin veya şekil oluşturmaz. İş akışınız bu işaretlemeleri görüntülemek zorundaysa ilgili slayt içeriğini ayrı olarak ekleyin.

**Bir etiketi kaldırıldı olarak işaretlemek ile koleksiyondan silmek arasındaki fark nedir?**

[ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) yöntemini `true` ile çağırmak, etiketi tutar ve kaldırma durumunu kaydeder. [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) yöntemini kullanmak ise etiketi modern koleksiyondan tamamen siler. Organizasyonunuzun meta veri saklama gereksinimlerine uygun işlemi seçin.

**Bir sunum hem eski MIP meta verilerini hem de modern duyarlılık etiketlerini içerebilir mi?**

Evet. Eski etiketler özel belge özelliklerinde kalabilirken, modern etiketler [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) aracılığıyla erişilebilir. Eski meta verileri okumak ve yalnızca modern koleksiyonda hâlâ bulunmayan geçerli etiketleri taşımak için [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) yöntemini kullanın.

**Aynı kimliğe sahip bir etiket birden fazla kez eklenirse ne olur?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) koleksiyon zaten aynı kimliğe sahip bir etiket içeriyorsa bir istisna fırlatır. Etiket eklemeden veya taşımadan önce [ISensitivityLabel.getId](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#getId--) tarafından döndürülen mevcut değerleri kontrol edin.

**Güncellenen duyarlılık etiketlerini korumak için hangi çıktı formatı kullanılmalıdır?**

Yukarıdaki örneklerde gösterildiği gibi, sunumu [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/java/com.aspose.slides/saveformat/) ile [IPresentation.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) çağırarak PPTX olarak kaydedin.