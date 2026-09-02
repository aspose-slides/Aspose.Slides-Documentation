---
title: Java'da PowerPoint Sunumlarında Hassasiyet Etiketlerini Yönetme
linktitle: Hassasiyet Etiketleri
type: docs
weight: 50
url: /tr/java/sensitivity-labels/
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
- Java
- Aspose.Slides
description: "Java için Aspose.Slides ile PowerPoint PPTX sunumlarında Microsoft Purview hassasiyet etiketlerini okuyun, ekleyin, güncelleyin, kaldırın ve taşıyın."
---
## **Genel Bakış**

Microsoft Purview hassasiyet etiketleri, kuruluşların belgeleri sınıflandırmasına ve yönetmesine yardımcı olur. Otomatik sunum işleme sırasında, bir uygulama mevcut bir etiketi korumak, bir politika tarafından seçilen bir etiketi uygulamak, durumunu güncellemek veya daha eski bir Microsoft Information Protection (MIP) iş akışı tarafından yazılmış etiket meta verilerini taşımak isteyebilir.

Aspose.Slides, modern hassasiyet etiketi meta verilerini [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) aracılığıyla sağlar. Bu yöntem, sunum PPTX olarak kaydedilmeden önce incelenip değiştirilebilecek bir [ISensitivityLabelCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabelcollection/) döndürür.

{{% alert color="primary" title="Not" %}}

Hassasiyet etiketi tanımlayıcıları ve politika bilgileri Microsoft Purview yapılandırmanız tarafından tanımlanır. Metaveriyi eklemeden veya taşımadan önce ortamınızdaki etiket kullanılabilirliğini ve politika gereksinimlerini doğrulayın. [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) değerleri, bir etiketle ilişkili içerik işaretlemelerini tanımlar; bunlar tek başına slaytlara görünür metin veya şekil eklemez.

{{% /alert %}}

## **Hassasiyet Etiketi Özelliklerini Anlayın**

Her [ISensitivityLabel](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/) aşağıdaki meta verileri içerir:

| Yöntemler | Amaç |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#getId--) ve [ISensitivityLabel.setId](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Purview politikasındaki hassasiyet etiketi tanımlayıcısını alır veya ayarlar. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#getSiteId--) ve [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | Etiket politikasına bağlı siteyi alır veya ayarlar. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#isEnabled--) ve [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | Etiketin etkin olup olmadığını alır veya ayarlar. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#isRemoved--) ve [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | Etiketin kaldırılıp kaldırılmadığını alır veya ayarlar. Kaldırma durumu meta veride tutulmalıysa değeri `true` olarak ayarlayın. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) ve [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | Etiketin otomatik olarak mı yoksa bir kullanıcı kararıyla mı uygulandığını alır veya ayarlar. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | Etiketle ilişkili içerik işaretleme türlerini alır. |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/sensitivitylabelassignmenttype/) sınıfı, bir etiketin nasıl atandığını tanımlar:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/tr/java/com.aspose.slides/sensitivitylabelassignmenttype/) varsayılan veya otomatik olarak uygulanmış bir etiketi temsil eder.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/tr/java/com.aspose.slides/sensitivitylabelassignmenttype/) kullanıcı kararıyla uygulanmış bir etiketi temsil eder; manuel, önerilen ve zorunlu etiketleri kapsar.

[SensitivityLabelContentType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/sensitivitylabelcontenttype/) sınıfı, bir etiketle ilişkili işaretlemeyi tanımlar:

| Değer | Anlam |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/tr/java/com.aspose.slides/sensitivitylabelcontenttype/) | Etiket varsayılan olarak veya otomatik şekilde uygulanmıştır. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/tr/java/com.aspose.slides/sensitivitylabelcontenttype/) | Etiketle ilişkili bir başlık içerik işaretlemesi vardır. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/tr/java/com.aspose.slides/sensitivitylabelcontenttype/) | Etiketle ilişkili bir altbilgi içerik işaretlemesi vardır. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/tr/java/com.aspose.slides/sensitivitylabelcontenttype/) | Etiketle ilişkili bir filigran içerik işaretlemesi vardır. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/tr/java/com.aspose.slides/sensitivitylabelcontenttype/) | Etiketle ilişkili bir şifreleme koruması vardır. |

Bir etiket birden fazla işaretleme türüyle ilişkilendirilebilir.

## **Varolan Hassasiyet Etiketlerini Listele**

[IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) yönteminden modern etiket koleksiyonunu okuyun ve yineleyin. Aşağıdaki örnek, her etiket için depolanmış tüm özellikleri ve içerik işaretlemelerini listeler:

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

## **İçerik İşaretlemesiyle Hassasiyet Etiketi Ekle**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) yöntemini etiket tanımlayıcısı, site tanımlayıcısı, etkin durumu ve atama yöntemi ile kullanın. Yöntem yeni bir [ISensitivityLabel](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/) döndürdükten sonra, gerekli işaretleme değerlerini [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) tarafından döndürülen listeye ekleyin.

Aşağıdaki örnek, altbilgi ve filigran işaretlemeleriyle ilişkili manuel seçilmiş bir etiketi ekler ve ardından sonucu PPTX olarak kaydeder:

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

## **Hassasiyet Etiketini Güncelle**

[ISensitivityLabel](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/) değerleri okuma/yazma özelliktedir; yalnızca [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) tarafından döndürülen liste, liste işlemleriyle değiştirilir. Gerekli etiketi bulduktan sonra tanımlayıcısını, site tanımlayıcısını, etkin durumunu, atama yöntemini, kaldırma durumunu ve içerik işaretleme türlerini güncelleyebilirsiniz. Değişiklikleri kalıcı hâle getirmek için sunumu kaydedin.

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

## **Hassasiyet Etiketini Kaldırıldı Olarak İşaretle**

Bir etiketin kaldırıldığını korumak için etiketi bulup [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) metodunu `true` ile çağırın. Bu, etiket girişini tutarken kaldırıldı durumunu kaydeder. Modern koleksiyondan bir girişi tamamen silmek isterseniz, [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) yöntemini kullanın; tüm girdileri silmek için [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabelcollection/#clear--) metodunu kullanın.

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

## **Eski MIP Hassasiyet Etiketlerini Oku ve Taşı**

Eski MIP tabanlı iş akışları, hassasiyet etiketi meta verilerini modern etiket koleksiyonu yerine özel belge özelliklerinde saklayabilir. Bu meta veriyi [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) ile okuyun. Yöntem, eski özel özellikleri ayrıştırır ve bir dizi [ISensitivityLabel](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/) nesnesi döndürür.

Meta veriyi taşımak için, döndürülen her etiketi modern [ISensitivityLabelCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabelcollection/) içine [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-) yöntemiyle ekleyin. Çift etiket tanımlayıcısı eklemek bir istisna fırlattığından, örnek hedef koleksiyonu kontrol ettikten sonra her etiketi kopyalar. Her eski etiketin hâlâ geçerli Purview politikasında mevcut olduğunu doğrulamak için ek doğrulama ekleyebilirsiniz.

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

Taşıma işlemi, ayrıştırılmış etiket nesnelerini modern koleksiyona kopyalar. Tüm özel belge özelliklerini temizlemeyi gerektirmez; ilişkili olmayan belge meta verileri olduğu gibi kalır. Modern etiket meta verilerini bir PPTX dosyasına yazmak için [IPresentation.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) metodunu [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/java/com.aspose.slides/saveformat/) ile kullanın.

## **SSS**

**Bir içerik işaretleme türü eklemek slaytlarda görünür bir başlık, altbilgi veya filigran oluşturur mu?**

Hayır. [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) tarafından döndürülen listeye eklenen değerler, hassasiyet etiketiyle ilişkili işaretlemeleri tanımlar. Bunlar sunumda görünür metin veya şekil oluşturmaz. İş akışınız bu işaretlemeleri görsel olarak göstermek zorundaysa ilgili slayt içeriğini ayrı olarak ekleyin.

**Bir etiketi kaldırıldı olarak işaretlemek ile koleksiyondan silmek arasındaki fark nedir?**

[ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) metodunu `true` ile çağırmak, etiket girişini tutar ve kaldırıldı durumunu kaydeder. [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) metodunu çağırmak ise modern koleksiyondan girdiyi siler. Kuruluşunuzun meta veri saklama gereksinimlerine uygun işlemi seçin.

**Bir sunum hem eski MIP meta verilerini hem de modern hassasiyet etiketlerini içerebilir mi?**

Evet. Eski etiketler özel belge özelliklerinde kalabilirken, modern etiketler [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) aracılığıyla erişilebilir. Eski meta veriyi okumak ve hâlen modern koleksiyonda bulunmayan geçerli etiketleri taşımak için [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) metodunu kullanın.

**Aynı tanımlayıcıya sahip bir etiket birden fazla kez eklendiğinde ne olur?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) koleksiyon zaten aynı tanımlayıcıya sahip bir etiket içeriyorsa bir istisna fırlatır. Etiket eklemeden veya taşıma işlemine başlamadan önce [ISensitivityLabel.getId](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isensitivitylabel/#getId--) tarafından döndürülen mevcut değerleri kontrol edin.

**Güncellenmiş hassasiyet etiketlerini korumak için hangi çıktı formatı kullanılmalıdır?**

Yukarıdaki örneklerde gösterildiği gibi, sunumu [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/java/com.aspose.slides/saveformat/) ile [IPresentation.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) metodunu çağırarak PPTX olarak kaydedin.