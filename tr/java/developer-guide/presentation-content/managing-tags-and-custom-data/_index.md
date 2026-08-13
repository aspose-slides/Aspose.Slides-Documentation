---
title: Java Kullanarak Sunumlarda Etiketleri ve Özel Verileri Yönetme
linktitle: Etiketler ve Özel Veri
type: docs
weight: 300
url: /tr/java/managing-tags-and-custom-data/
keywords:
- belge özellikleri
- etiket
- özel veri
- özel XML
- özel XML bölümü
- XML üst verileri
- ItemId
- etiket ekle
- çift değerler
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint sunumlarında etiketleri ve özel XML verilerini yönetmeyi, ekleme, okuma, güncelleme, denetleme ve özel XML bölümlerini kaldırma dahil olmak üzere öğrenin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ın PowerPoint sunumlarında etiketler ve özel veri ile nasıl çalıştığını açıklar. Sunuma özgü veriler etiketler veya özel XML bölümleri olarak depolanabilir. Etiketler basit anahtar‑değer dize çiftleridir, özel XML bölümleri ise yapılandırılmış üst veri ve uygulamaya özgü XML yüklerini depolayabilir.

Aspose.Slides, sunum, slayt ve şekil düzeylerinde özel XML bölümlerini ekleme, okuma, güncelleme, denetleme ve kaldırma için API'ler sunar. Özel XML bölümleri, belge yönetimi tanımlayıcıları, iş akışı durumu, uyumluluk üst verileri, şablon bağlama verileri veya sunum içinde başka yapılandırılmış uygulama verileri gibi bilgileri depolayan entegrasyonlar için yararlıdır.

## **Sunum Dosyalarında Veri Depolama**

`PPTX` dosyaları—`.pptx` uzantılı dosyalar—PresentationML formatında depolanır ve bu, Office Open XML (OOXML) spesifikasyonunun bir parçasıdır. Office Open XML, sunum içeriği ve ilgili verileri depolamak için kullanılan paket yapısını ve ilişkileri tanımlar.

Bir sunum, ilişkilerle bağlanan birden çok bölüm içerir. Örneğin, bir slayt bölümü tek bir slaytın içeriğini barındırır ve ISO/IEC 29500 tarafından tanımlanan diğer bölümlerle açık ilişkiler kurabilir.

Özel veriler etiketler ([ITagCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITagCollection)) veya özel XML bölümleri ([ICustomXmlPartCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICustomXmlPartCollection)) olarak depolanabilir. Her ikisi de [`ICustomData`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICustomData/) arabirimi üzerinden kullanılabilir.

{{% alert color="info" %}}
Etiketler basit dize anahtar‑değer çiftlerini saklar. Özel XML bölümleri yapılandırılmış XML verilerini saklar ve bir sunum, slayt veya şekil ile ilişkilendirilebilir.
{{% /alert %}}

## **Özel XML Bölümleriyle Çalışma**

[`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICustomData#getCustomXmlParts--) yöntemi, belirli bir sunum nesnesiyle ilişkili özel XML bölümleri koleksiyonunu döndürür. Örneğin:

- `presentation.getCustomData().getCustomXmlParts()` sunumun kendisiyle ilişkili özel XML bölümlerini içerir.
- `slide.getCustomData().getCustomXmlParts()` belirli bir slaytla ilişkili özel XML bölümlerini içerir.
- `shape.getCustomData().getCustomXmlParts()` belirli bir şekille ilişkili özel XML bölümlerini içerir.

[`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) metodunu, özel XML bölümlerinin nerede ilişkilendirildiğine bakılmaksızın tümünü incelemeniz gerektiğinde kullanın.

### **Bir Sunuma Özel XML Bölümü Ekleme**

[`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) metodunu, XML verisini bir özel XML bölümü koleksiyonuna eklemek için kullanın. XML geçerli ve boş olmamalıdır.

Aşağıdaki örnek, sunum düzeyindeki özel veri koleksiyonuna yapılandırılmış üst veri ekler:

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

`add` yöntemi ayrıca XML'i bayt dizisi veya giriş akışı olarak da kabul edebilir; bu, XML içeriği zaten ikili biçimde mevcut olduğunda faydalıdır.

### **Bir Slayt veya Şekle Özel XML Bölümü Ekleme**

Özel XML verileri, tüm sunum yerine belirli bir slayt veya şekil ile ilişkilendirilebilir. Bu, üst verinin yalnızca bir nesneyi (örneğin bir şablon anahtarı, dış kayıt tanımlayıcısı veya bağlama bilgisi) tanımladığı durumlarda yararlıdır.

Aşağıdaki örnek, bir slayta bir özel XML bölümü ve bir şekle başka bir bölüm ekler:

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

Bir bölümün eklenme düzeyi, hangi nesnenin `getCustomData().getCustomXmlParts()` koleksiyonunun o bölüme ilişkin ilişkiyi içerdiğini belirler. Sunum düzeyindeki veri, belge çapında üst veri için uygundur; slayt düzeyindeki veri, belirli bir slayta ait bilgi için; şekil düzeyindeki veri ise tek bir şekle bağlı üst veri için uygundur.

### **Tüm Özel XML Bölümlerini Listeleme ve Denetleme**

[`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) metodunu, bir sunumdan tüm özel XML bölümlerini almak için kullanın. Her [`ICustomXmlPart`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICustomXmlPart/) kimliğini, XML içeriğini ve ilişkili ad alanı şemalarını gösterir.

Aşağıdaki örnek, tüm özel XML bölümlerini ve bunların ad alanı şemalarını listeler:

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

[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) özel XML bölümüyle ilişkili XML şemalarını döndürür. Bu bilgi, dış sistemler tarafından üretilen XML içeren sunumları denetlerken yararlı olabilir.

### **XML İçeriğini ve ItemId'yi Okuma ve Güncelleme**

[`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICustomXmlPart#getXmlAsString--) ve [`setXmlAsString()`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) yöntemlerini XML'i UTF-8 dizesi olarak işlemek için, ya da [`getXmlData()`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICustomXmlPart#getXmlData--) ve [`setXmlData()`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) yöntemlerini ham XML baytlarıyla çalışmak için kullanın.

[`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICustomXmlPart#getItemId--) yöntemi, Office Open XML belgesindeki özel XML bölümünü tanımlayan UUID'yi döndürür. Bir entegrasyon yeni bir tanımlayıcı gerektirdiğinde [`setItemId()`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) kullanın.

Aşağıdaki örnek, XML içeriğini ve tanımlayıcıyı günceller:

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPart customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Mevcut XML'i metin olarak okuyun.
    String currentXmlContent = customXmlPart.getXmlAsString();
    System.out.println(currentXmlContent);

    // XML'i UTF-8 dizesi olarak güncelleyin.
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // getXmlData, aynı XML içeriğini ham baytlar olarak sağlar.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // Entegrasyon gerektirdiğinde tanımlayıcıyı değiştirin.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`setXmlAsString` veya `setXmlData` çağrılırken, geçerli ve boş olmayan XML sağlayın. Uygulamanın çoğunlukla dize mi yoksa bayt verisiyle mi çalıştığına bağlı olarak bir temsil biçimini kullanın.

### **Bir Özel XML Bölümünü Kaldırma**

Aspose.Slides, özel XML verisini kaldırmak için birkaç yol sunar:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICustomXmlPart#remove--) özel XML bölümünü sunumdan kaldırır.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) özel XML bölümü koleksiyonundan belirli bir bölümü kaldırır.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICustomXmlPartCollection#removeAt-int--) belirtilen koleksiyon indeksindeki bölümü kaldırır.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICustomXmlPartCollection#clear--) belirli bir koleksiyondaki tüm bölümleri kaldırır.

Aşağıdaki örnek, referansla bir sunum düzeyindeki özel XML bölümünü kaldırır:

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

Zaten bir `ICustomXmlPart` nesneniz varsa ve belirli bir koleksiyon yerine sunumdan bu bölümü kaldırmak istiyorsanız, `customXmlPart.remove()` çağırın.

Ayrıca bir öğeyi indeksle kaldırabilirsiniz:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Bir Koleksiyondaki Tüm Özel XML Bölümlerini Temizleme**

Belirli bir sunum nesnesiyle ilişkili tüm özel XML bölümleri kaldırılacaksa `clear` kullanın.

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

`clear` yalnızca seçilen koleksiyonu etkiler. Örneğin, bir slaytın koleksiyonunu temizlemek, sunum düzeyindeki veya şekil düzeyindeki koleksiyonları temizlemez.

Sunumdaki her özel XML bölümünü kaldırmak için `getAllCustomXmlParts()` üzerinde yineleme yapın ve her bölümü kaldırın:

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

### **Bağlantılı veya Paylaşımlı Özel XML Bölümlerini İşleme**

Office Open XML bir sunumda aynı özel XML bölümü birden fazla sunum nesnesinden referans alınabilir. Örneğin, mevcut bir dosya birden çok slayt veya şekilden aynı temel özel XML bölümüne ilişkiler içerebilir.

Paylaşılan bir bölüm, birden fazla referansa sahip tek bir veri nesnesi olarak ele alınmalıdır:

- `setXmlAsString`, `setXmlData` veya `setItemId` ile güncellemek, temel özel XML bölümünü değiştirir; bu değişiklik bölümün referans alındığı her yerde uygulanır.
- `getItemId()` nesne düzeyindeki koleksiyonları denetlerken aynı özel XML bölümünü tanımlamak için kullanılabilir.
- Belirli bir `getCustomXmlParts()` koleksiyonundan bir bölümü kaldırmak, onu o koleksiyondan siler. Bölümün kendisinin sunumdan kaldırılması gerektiğinde `ICustomXmlPart.remove()` kullanın.
- Paylaşımlı bir bölümü silmeden veya değiştirmeden önce, diğer slaytların veya şekillerin hala ona referans verip vermediğini belirlemek için nesne düzeyindeki koleksiyonları inceleyin.

`add` aşırı yüklemeleri XML içeriğinden yeni bir özel XML bölümü oluşturur; mevcut bir `ICustomXmlPart` kabul etmez. Bu nedenle, paylaşımlı ilişkiler genellikle zaten bu bölümleri içeren sunumlar yüklendiğinde görülür.

Aşağıdaki örnek, `ItemId` ile sunum, slayt ve şekil düzeyindeki koleksiyonları denetler ve birden fazla yerden referans verilen bölümleri rapor eder:

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

Bu tür bir denetim, dış sistemler tarafından oluşturulan sunumlardaki özel XML verisini değiştirmeden veya silmeden önce yararlıdır; aynı üst veri bölümü birden fazla ilişkiye katılabilir.

## **Etiket Değerlerini Alma**

Slaytlarda, bir etiket `IDocumentProperties.getKeywords()` yöntemine karşılık gelir. Bu örnek kod, Aspose.Slides for Java ile bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) için etiket değerinin nasıl alınacağını gösterir:

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

Aspose.Slides, sunumlara etiket eklemenizi sağlar. Bir etiket genellikle iki öğeden oluşur:

- özel bir özelliğin adı, örneğin `MyTag`;
- özelliğin değeri, örneğin `My Tag Value`.

Sunumları belirli bir kural veya özelliğe göre sınıflandırmanız gerekiyorsa, bu amaçla etiket ekleyebilirsiniz. Örneğin, Kuzey Amerika ülkelerinden gelen sunumları sınıflandırmak istiyorsanız, bir Kuzey Amerika etiketi oluşturup ilgili ülkeyi değer olarak atayabilirsiniz.

Bu örnek kod, Aspose.Slides for Java kullanarak bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) üzerine etiket eklemenin yolunu gösterir:

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

Etiketler ayrıca bir [Slide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlide) için de ayarlanabilir:

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

Veya tek bir [Shape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IAutoShape) için:

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

`getCustomData().getTags()` koleksiyonu aracılığıyla eklenen etiketler yalnızca PowerPoint dosyasında depolanır. Sunum PDF olarak dışa aktarıldığında bu etiketler PDF etiket yapısına **aktarılmaz**. Sonuç olarak, bir etiket olarak atanmış özel tanımlayıcı, etiketli PDF'den alınamaz.

**Geçici Çözüm**: Özel bir tanımlayıcıyı nesnenin **Alt Text** özelliğinde (örneğin `shape.setAlternativeText("MyId")`) saklayabilirsiniz. PDF'ye dışa aktarıldıktan sonra Alt Text, PDF etiket yapısında görünebilir.

## **SSS**

**Bir sunum, slayt veya şekilden tüm etiketleri tek bir işlemle kaldırabilir miyim?**

Evet. [tag collection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tagcollection/) koleksiyonu, tüm anahtar‑değer çiftlerini bir anda silen bir [clear](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tagcollection/#clear--) işlemini destekler.

**Tüm koleksiyonu dolaşmadan, adını bilerek tek bir etiketi nasıl silebilirim?**

Etiketi anahtarıyla silmek için [tag collection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tagcollection/) üzerindeki [remove(name)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) yöntemini kullanın.

**Analitik veya filtreleme için etiket adlarının tam listesini nasıl alabilirim?**

[tag collection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tagcollection/) üzerindeki [getNamesOfTags](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tagcollection/#getNamesOfTags--) yöntemini kullanın; tüm etiket adlarını içeren bir dizi döndürür.

**Özel XML bölümlerinin nerede depolandığına bakılmaksızın hepsini nasıl bulabilirim?**

Sunumdaki tüm özel XML bölümlerini almak için [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) kullanın.

**Bir özel XML bölümünü güncellemek için `getXmlAsString`/`setXmlAsString` mi yoksa `getXmlData`/`setXmlData` mi kullanmalıyım?**

Uygulama UTF-8 XML metniyle çalışıyorsa `getXmlAsString` ve `setXmlAsString` kullanın. XML zaten bir bayt dizisi olarak mevcutsa veya ikili odaklı işleme daha uygun ise `getXmlData` ve `setXmlData` kullanın. Her iki temsil de aynı özel XML bölümünün XML içeriğine yöneliktir.