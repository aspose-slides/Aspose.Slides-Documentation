---
title: Java Kullanarak Sunumlarda Etiketleri ve Özel Verileri Yönetme
linktitle: Etiketler ve Özel Veri
type: docs
weight: 300
url: /tr/java/managing-tags-and-custom-data/
keywords:
- doküman özellikleri
- etiket
- özel veri
- özel XML
- özel XML parçası
- XML üst verisi
- ItemId
- etiket ekle
- çift değerler
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint sunumlarında etiketleri ve özel XML verilerini nasıl yöneteceğinizi, ekleme, okuma, güncelleme, denetleme ve özel XML parçalarını kaldırma dahil olmak üzere öğrenin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'in PowerPoint sunumlarında etiketler ve özel verilerle nasıl çalıştığını açıklar. Sunum‑özel veriler etiketler veya özel XML parçaları olarak depolanabilir. Etiketler basit anahtar‑değer dizge çiftleridir, özel XML parçaları ise yapılandırılmış üst veri ve uygulama‑özel XML yüklerini depolayabilir.

Aspose.Slides, sunum, slayt ve şekil düzeylerinde özel XML parçalarını ekleme, okuma, güncelleme, denetleme ve kaldırma için API'ler sunar. Özel XML parçaları, belge‑yönetimi tanımlayıcıları, iş akışı durumu, uyumluluk üst verileri, şablon‑bağlama verileri veya bir sunum içinde bulunan diğer yapılandırılmış uygulama verileri gibi bilgileri depolayan entegrasyonlar için faydalıdır.

## **Sunum Dosyalarında Veri Depolama**

PPTX dosyaları—`.pptx` uzantılı dosyalar—PresentationML biçiminde depolanır ve bu, Office Open XML spesifikasyonunun bir parçasıdır. Office Open XML, sunum içeriği ve ilgili verileri depolamak için kullanılan paket yapısını ve ilişkileri tanımlar.

Bir sunum, ilişkilerle bağlanan birden çok parçadan oluşur. Örneğin, bir slayt parçası tek bir slaytın içeriğini barındırır ve ISO/IEC 29500 tarafından tanımlanan diğer parçalara açık ilişkiler içerebilir.

Özel veriler etiketler ([ITagCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITagCollection)) veya özel XML parçaları ([ICustomXmlPartCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICustomXmlPartCollection)) olarak depolanabilir. Her ikisi de [`ICustomData`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICustomData/) arayüzü üzerinden kullanılabilir.

{{% alert color="primary" %}}
Etiketler basit dizge anahtar‑değer çiftlerini depolar. Özel XML parçaları yapılandırılmış XML verilerini depolar ve bir sunum, slayt veya şekil ile ilişkilendirilebilir.
{{% /alert %}}

## **Özel XML Parçalarıyla Çalışma**

[`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICustomData#getCustomXmlParts--) yöntemi, belirli bir sunum nesnesiyle ilişkili özel XML parçalarının koleksiyonunu döndürür. Örneğin:

- `presentation.getCustomData().getCustomXmlParts()` sunumun kendisiyle ilişkili özel XML parçalarını içerir.
- `slide.getCustomData().getCustomXmlParts()` belirli bir slaytla ilişkili özel XML parçalarını içerir.
- `shape.getCustomData().getCustomXmlParts()` belirli bir şekille ilişkili özel XML parçalarını içerir.

İlişkilendirilme yerine bakılmaksızın sunumdaki tüm özel XML parçalarını incelemeniz gerektiğinde [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) kullanın.

### **Bir Sunuma Özel XML Parçası Ekleme**

[`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) yöntemiyle bir özel XML parça koleksiyonuna XML verisi ekleyin. XML geçerli ve boş olmamalıdır.

Aşağıdaki örnek, sunum‑düzeyindeki özel veri koleksiyonuna yapılandırılmış üst veri ekler:

```java
import com.aspose.slides.*;
import java.util.UUID;

String customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

Presentation presentation = new Presentation();
try {
    ICustomXmlPart customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // add otomatik olarak bir tanımlayıcı atar. Belirli bir UUID yalnızca gerektiğinde ayarlayın.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`add` yöntemi, XML'i bayt dizisi ya da giriş akışı olarak da kabul edebilir; bu, XML içeriği zaten ikili biçimde mevcut olduğunda faydalıdır.

### **Bir Slayta veya Şekle Özel XML Parçası Ekleme**

Özel XML verileri tüm sunum yerine belirli bir slayt veya şekil ile ilişkilendirilebilir. Bu, üst verinin yalnızca bir nesneyi (örneğin bir şablon anahtarı, dış kayıt tanımlayıcısı veya bağlama bilgisi) tanımladığı durumlarda faydalıdır.

Aşağıdaki örnek, bir slayta bir özel XML parçası ve bir şekle bir başka özel XML parçası ekler:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        "<slideMetadata xmlns=\"urn:example:slides\">" +
            "<templateKey>TitleSlide</templateKey>" +
        "</slideMetadata>");

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        "<shapeMetadata xmlns=\"urn:example:shapes\">" +
            "<recordId>CRM-4281</recordId>" +
        "</shapeMetadata>");

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bir parçanın eklendiği düzey, hangi nesnenin `getCustomData().getCustomXmlParts()` koleksiyonunun bu parçaya ilişkinliği içerdiğini belirler. Sunum‑düzeyindeki veriler belge‑geneli üst veriler için, slayt‑düzeyindeki veriler belirli bir slayta ait bilgiler için ve şekil‑düzeyindeki veriler ise bireysel bir şekle bağlı üst veriler için uygundur.

### **Tüm Özel XML Parçalarını Listeleme ve Denetleme**

Bir sunumdan tüm özel XML parçalarını almak için [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) kullanın. Her [`ICustomXmlPart`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICustomXmlPart/) kimliğini, XML içeriğini ve ilişkili ad alanı şemalarını ortaya çıkarır.

Aşağıdaki örnek, tüm özel XML parçalarını ve bunların ad alanı şemalarını listeler:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        System.out.println("ItemId: " + customXmlPart.getItemId());
        System.out.println("XML:");
        System.out.println(customXmlPart.getXmlAsString());

        for (String namespaceSchema : customXmlPart.getNamespaceSchemas()) {
            System.out.println("Namespace schema: " + namespaceSchema);
        }

        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) özel XML parçası ile ilişkili XML şemalarını döndürür. Bu bilgi, dış sistemler tarafından üretilen XML içeren sunumları denetlerken faydalı olabilir.

### **XML İçeriğini ve ItemId'yi Okuma ve Güncelleme**

XML'i UTF-8 dizgesi olarak işlemek için [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICustomXmlPart#getXmlAsString--) ve [`setXmlAsString()`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) yöntemlerini, ham XML baytlarıyla çalışmak için ise [`getXmlData()`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICustomXmlPart#getXmlData--) ve [`setXmlData()`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) yöntemlerini kullanın.

[`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICustomXmlPart#getItemId--) yöntemi, Office Open XML belgesindeki özel XML parçasını tanımlayan UUID'yi döndürür. Bir entegrasyon yeni bir tanımlayıcı gerektirdiğinde [`setItemId()`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) kullanın.

Aşağıdaki örnek, XML içeriğini ve tanımlayıcıyı günceller:

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPart customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Mevcut XML'i metin olarak oku.
    String currentXmlContent = customXmlPart.getXmlAsString();
    System.out.println(currentXmlContent);

    // XML'i UTF-8 dizgesi olarak güncelle.
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // getXmlData, aynı XML içeriğini ham baytlar olarak sağlar.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // Entegrasyon gerektirdiğinde tanımlayıcıyı değiştir.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`setXmlAsString` veya `setXmlData` çağrılırken geçerli ve boş olmayan XML sağlayın. Uygulamanın ağırlıklı olarak dizgelerle mi yoksa bayt verileriyle mi çalıştığına bağlı olarak bir temsili diğerine tercih edin.

### **Bir Özel XML Parçasını Kaldırma**

Aspose.Slides, özel XML verilerini kaldırmanın birkaç yolunu sunar:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICustomXmlPart#remove--) özel XML parçasını sunumdan kaldırır.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) belirli bir parçayı özel XML parça koleksiyonundan kaldırır.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICustomXmlPartCollection#removeAt-int-) belirtilen koleksiyon indeksindeki parçayı kaldırır.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICustomXmlPartCollection#clear--) belirli bir koleksiyondaki tüm parçaları kaldırır.

Aşağıdaki örnek, referansla bir sunum‑düzeyindeki özel XML parçasını kaldırır:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPartCollection customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        ICustomXmlPart customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Eğer zaten bir `ICustomXmlPart` nesneniz varsa ve belirli bir koleksiyona yönelmek yerine parçayı sunumdan kaldırmak istiyorsanız, `customXmlPart.remove()` çağırın.

Bir öğeyi indeksle de kaldırabilirsiniz:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Bir Koleksiyondan Tüm Özel XML Parçalarını Temizleme**

Belirli bir sunum nesnesiyle ilişkili tüm özel XML parçaları kaldırılacaksa `clear` kullanın.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` yalnızca seçilen koleksiyonu etkiler. Örneğin, bir slaytın koleksiyonunu temizlemek, sunum‑düzeyindeki veya şekil‑düzeyindeki koleksiyonları temizlemez.

Sunumdaki tüm özel XML parçalarını kaldırmak için `getAllCustomXmlParts()` üzerinden döngü yapın ve her parçayı kaldırın:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        customXmlPart.remove();
    }

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Bağlantılı veya Paylaşılan Özel XML Parçalarını İşleme**

Bir Office Open XML sunumunda aynı özel XML parçası birden fazla sunum nesnesinden referans alınabilir. Örneğin, mevcut bir dosya, aynı temel özel XML parçasına birden çok slayt veya şekilden ilişkiler içerebilir.

Paylaşılan bir parça, birden çok referansa sahip tek bir veri nesnesi olarak ele alınmalıdır:

- `setXmlAsString`, `setXmlData` veya `setItemId` ile güncelleme, temel özel XML parçasını değiştirir; bu nedenle değişiklik, parçanın referans alındığı her yerde uygulanır.
- `getItemId()` nesne düzeyindeki koleksiyonları denetlerken aynı özel XML parçasını tanımlamak için kullanılabilir.
- Belirli bir `getCustomXmlParts()` koleksiyonundan bir parçanın kaldırılması, o koleksiyondan kaldırır. Parçanın kendisinin sunumdan kaldırılması gerektiğinde `ICustomXmlPart.remove()` kullanın.
- Paylaşılan bir parçayı silmeden veya değiştirmeden önce, diğer slaytların veya şekillerin hâlâ ona referans verip vermediğini belirlemek için nesne‑düzeyindeki koleksiyonları inceleyin.

`add` aşırı yüklemeleri, XML içeriğinden yeni bir özel XML parçası oluşturur; mevcut bir `ICustomXmlPart` kabul etmez. Bu nedenle, paylaşılan ilişkiler genellikle zaten bu ilişkileri içeren sunumlar yüklendiğinde ortaya çıkar.

Aşağıdaki örnek, `ItemId` ile sunum, slayt ve şekil düzeyindeki koleksiyonları denetler ve birden çok yerden referans verilen parçaları raporlar:

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.UUID;
import java.util.function.BiConsumer;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Map<UUID, List<String>> referencesByItemId = new HashMap<>();

    BiConsumer<String, ICustomXmlPartCollection> registerCustomXmlParts =
        (ownerName, customXmlParts) -> {
            for (int i = 0; i < customXmlParts.size(); i++) {
                ICustomXmlPart customXmlPart = customXmlParts.get_Item(i);
                UUID itemId = customXmlPart.getItemId();

                if (!referencesByItemId.containsKey(itemId)) {
                    referencesByItemId.put(itemId, new ArrayList<>());
                }

                referencesByItemId.get(itemId).add(ownerName);
            }
        };

    registerCustomXmlParts.accept("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (int slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        registerCustomXmlParts.accept("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (int shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            registerCustomXmlParts.accept("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (Map.Entry<UUID, List<String>> referenceEntry : referencesByItemId.entrySet()) {
        if (referenceEntry.getValue().size() > 1) {
            System.out.println("Shared custom XML part: " + referenceEntry.getKey());

            for (String ownerName : referenceEntry.getValue()) {
                System.out.println("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Bu tür bir denetim, dış sistemler tarafından oluşturulan sunumlardaki özel XML verilerini değiştirmeden veya silmeden önce faydalıdır; çünkü aynı üst veri parçası birden çok ilişkide yer alabilir.

## **Etiket Değerlerini Alma**

Slaytlarda bir etiket, `IDocumentProperties.getKeywords()` yöntemine karşılık gelir. Bu örnek kod, Aspose.Slides for Java ile bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) için etiket değerinin nasıl alınacağını gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Sunumlara Etiket Ekleme**

Aspose.Slides, sunumalara etiket eklemenizi sağlar. Bir etiket tipik olarak iki öğeden oluşur:

- özel bir özelliğin adı, örneğin `MyTag`;
- özel özelliğin değeri, örneğin `My Tag Value`.

Sunumları belirli bir kural veya özelliğe göre sınıflandırmanız gerekiyorsa, bu amaçla etiket ekleyebilirsiniz. Örneğin, Kuzey Amerika ülkelerinden gelen sunumları sınıflandırmak istiyorsanız, bir Kuzey Amerika etiketi oluşturup ilgili ülkeleri değer olarak atayabilirsiniz.

Bu örnek kod, Aspose.Slides for Java kullanarak bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) üzerine etiket eklemeyi gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ITagCollection tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

Etiketler bir [Slide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlide) için de ayarlanabilir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

Veya ayrı bir [Shape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IAutoShape) için:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **Sınırlamalar**

`getCustomData().getTags()` koleksiyonu aracılığıyla eklenen etiketler yalnızca PowerPoint dosyasında depolanır. Sunum PDF'ye dışa aktarılırken PDF etiket yapısına **aktarılmaz**. Sonuç olarak, etiket olarak atanan özel bir tanımlayıcı etiketli PDF'den alınamaz.

**Çözüm**: Özel bir tanımlayıcıyı nesnenin **Alt Text** (alternatif metni) içinde depolayabilirsiniz (örneğin, `shape.setAlternativeText("MyId")`). PDF'ye dışa aktardıktan sonra Alt Text PDF etiket yapısında görünebilir.

## **SSS**

**Bir sunum, slayt veya şekilden tüm etiketleri tek bir işlemle kaldırabilir miyim?**

Evet. [tag collection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tagcollection/) koleksiyonu, tüm anahtar‑değer çiftlerini bir kerede silen bir [clear](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tagcollection/#clear--) işlemini destekler.

**Bir etiketi adını kullanarak, tüm koleksiyonu döngüye almadan nasıl silebilirim?**

[tag collection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tagcollection/) üzerindeki [remove(name)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) yöntemiyle etiketi anahtarına göre silebilirsiniz.

**Analiz veya filtreleme için etiket adlarının tam listesini nasıl alabilirim?**

[tag collection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tagcollection/) üzerindeki [getNamesOfTags](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tagcollection/#getNamesOfTags--) yöntemini kullanın; bu, tüm etiket adlarının bir dizisini döndürür.

**Parçaların nerede depolandığına bakılmaksızın tüm özel XML parçalarını nasıl bulabilirim?**

Sunumdaki tüm özel XML parçalarını almak için [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) kullanın.

**Bir özel XML parçasını güncellemek için `getXmlAsString`/`setXmlAsString` mı yoksa `getXmlData`/`setXmlData` mi kullanmalıyım?**

Uygulama UTF-8 XML metniyle çalışıyorsa `getXmlAsString` ve `setXmlAsString` kullanın. XML zaten bir bayt dizisi olarak mevcutsa veya ikili‑odaklı işleme daha uygun ise `getXmlData` ve `setXmlData` kullanın. Her iki temsili de aynı özel XML parçasının XML içeriğine işaret eder.