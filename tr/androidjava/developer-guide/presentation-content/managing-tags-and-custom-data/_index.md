---
title: Android'de Sunumlarda Etiketleri ve Özel Verileri Yönetme
linktitle: Etiketler ve Özel Veri
type: docs
weight: 300
url: /tr/androidjava/managing-tags-and-custom-data
keywords:
- belge özellikleri
- etiket
- özel veri
- özel XML
- özel XML bölümü
- XML meta verisi
- ItemId
- etiket ekle
- çift değerler
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile PowerPoint sunumlarında etiketleri ve özel XML verilerini yönetmeyi, özel XML bölümlerini ekleme, okuma, güncelleme, denetleme ve kaldırma dahil öğrenin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ın PowerPoint sunumlarında etiketler ve özel verilerle nasıl çalıştığını açıklar. Sunuma özgü veriler etiketler veya özel XML bölümleri olarak depolanabilir. Etiketler basit anahtar‑değer dize çiftleridir, özel XML bölümleri ise yapılandırılmış meta verileri ve uygulamaya özgü XML yüklerini depolayabilir.

Aspose.Slides, sunum, slayt ve şekil düzeylerinde özel XML bölümlerini ekleme, okuma, güncelleme, denetleme ve kaldırma için API'ler sunar. Özel XML bölümleri, belge yönetimi tanımlayıcıları, iş akışı durumu, uyumluluk meta verileri, şablon bağlama verileri veya bir sunum içinde saklanan diğer yapılandırılmış uygulama verileri gibi bilgileri depolayan entegrasyonlar için yararlıdır.

## **Sunum Dosyalarında Veri Depolama**

PPTX dosyaları—`.pptx` uzantılı dosyalar—PresentationML formatında depolanır ve bu, Office Open XML (OOXML) spesifikasyonunun bir parçasıdır. Office Open XML, sunum içeriği ve ilişkili verileri depolamak için kullanılan paket yapısını ve ilişkileri tanımlar.

Bir sunum, ilişkilerle bağlanmış birden çok bölüm içerir. Örneğin, bir slayt bölümü tek bir slaydın içeriğini barındırır ve ISO/IEC 29500 tarafından tanımlanan diğer bölümlere açık ilişkiler içerebilir.

Özel veriler etiketler ([ITagCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ITagCollection)) veya özel XML bölümleri ([ICustomXmlPartCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICustomXmlPartCollection)) olarak depolanabilir. Her ikisi de [`ICustomData`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICustomData/) arayüzü aracılığıyla kullanılabilir.

{{% alert color="primary" %}}
Etiketler basit dize anahtar‑değer çiftleri depolar. Özel XML bölümleri yapılandırılmış XML verileri depolar ve bir sunum, slayt veya şekil ile ilişkilendirilebilir.
{{% /alert %}}

## **Özel XML Bölümleriyle Çalışma**

[`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICustomData#getCustomXmlParts--) yöntemi belirli bir sunum nesnesiyle ilişkili özel XML bölümlerinin koleksiyonunu döndürür. Örneğin:

- `presentation.getCustomData().getCustomXmlParts()` sunumun kendisiyle ilişkili özel XML bölümlerini içerir.
- `slide.getCustomData().getCustomXmlParts()` belirli bir slaytla ilişkili özel XML bölümlerini içerir.
- `shape.getCustomData().getCustomXmlParts()` belirli bir şekille ilişkili özel XML bölümlerini içerir.

`[`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) metodunu, sunumda ilişkilendirilme yerinden bağımsız olarak tüm özel XML bölümlerini incelemeniz gerektiğinde kullanın.

### **Bir Sunuma Özel XML Bölümü Ekleme**

[`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) yöntemini, bir özel XML bölüm koleksiyonuna XML veri eklemek için kullanın. XML geçerli ve boş olmamalıdır.

Aşağıdaki örnek, sunum düzeyindeki özel veri koleksiyonuna yapılandırılmış meta verileri ekler:

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

    // add otomatik olarak bir tanımlayıcı atar. Gerektiğinde yalnızca belirli bir UUID ayarlayın.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`add` yöntemi, XML'i bayt dizisi veya giriş akışı olarak da kabul edebilir; bu, XML içeriği zaten ikili biçimde mevcut olduğunda faydalıdır.

### **Bir Slayt veya Şekle Özel XML Bölümü Ekleme**

Özel XML verileri, tüm sunum yerine belirli bir slayt veya şekille ilişkilendirilebilir. Bu, meta verilerin yalnızca bir nesneyi (örneğin bir şablon anahtarı, dış kayıt tanımlayıcısı veya bağlama bilgisi) tanımladığı durumlarda faydalıdır.

Aşağıdaki örnek, bir slayta bir özel XML bölümü ve bir şekle bir başka özel XML bölümü ekler:

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

Bir bölümün eklendiği seviye, hangi nesnenin `getCustomData().getCustomXmlParts()` koleksiyonunun bu bölüme ilişkin ilişkiyi içerdiğini belirler. Sunum düzeyindeki veri, belge geneli meta veriler için uygundur; slayt düzeyindeki veri belirli bir slayta ait bilgi için; şekil düzeyindeki veri ise tek bir şekille bağlantılı meta veri için uygundur.

### **Tüm Özel XML Bölümlerini Listeleme ve Denetleme**

[`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) metodunu kullanarak bir sunumdan tüm özel XML bölümlerini alın. Her [`ICustomXmlPart`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICustomXmlPart/) kimliğini, XML içeriğini ve ilişkili ad alanı şemalarını gösterir.

Aşağıdaki örnek, tüm özel XML bölümlerini ve ad alanı şemalarını listeler:

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

`[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--)` yöntemi, özel XML bölümüyle ilişkili XML şemalarını döndürür. Bu bilgi, dış sistemler tarafından üretilen XML içeren sunumları denetlerken faydalı olabilir.

### **XML İçeriğini ve ItemId'yi Okuma ve Güncelleme**

[`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICustomXmlPart#getXmlAsString--) ve `[`setXmlAsString()`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) yöntemlerini XML'i UTF-8 dizesi olarak, `[`getXmlData()`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICustomXmlPart#getXmlData--) ve `[`setXmlData()`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) yöntemlerini ise ham XML baytlarıyla çalışmak için kullanın.

[`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICustomXmlPart#getItemId--) yöntemi, Office Open XML belgesinde özel XML bölümünü tanımlayan UUID'yi döndürür. Bir entegrasyon yeni bir tanımlayıcı gerektirdiğinde `[`setItemId()`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-)` kullanın.

Aşağıdaki örnek XML içeriğini ve tanımlayıcıyı günceller:

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPart customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Mevcut XML'yi metin olarak oku.
    String currentXmlContent = customXmlPart.getXmlAsString();
    System.out.println(currentXmlContent);

    // XML'yi UTF-8 dizesi olarak güncelle.
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // getXmlData, aynı XML içeriğini ham baytlar olarak sağlar.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // Entegrasyon tarafından gerektiğinde tanımlayıcıyı değiştir.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`setXmlAsString` veya `setXmlData` çağrılırken geçerli ve boş olmayan XML sağlayın. Uygulama öncelikle dize ya da bayt verisiyle çalışıyorsa, uygun temsili kullanın.

### **Bir Özel XML Bölümünü Kaldırma**

Aspose.Slides, özel XML verilerini kaldırmak için çeşitli yollar sunar:

- `[`ICustomXmlPart.remove`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICustomXmlPart#remove--)` özel XML bölümünü sunumdan kaldırır.
- `[`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-)` özel XML bölüm koleksiyonundan belirli bir bölümü kaldırır.
- `[`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICustomXmlPartCollection#removeAt-int-)` belirtilen koleksiyon indeksindeki bölümü kaldırır.
- `[`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICustomXmlPartCollection#clear--)` belirli bir koleksiyondaki tüm bölümleri kaldırır.

Aşağıdaki örnek, referansla bir sunum düzeyinde özel XML bölümü kaldırır:

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

Eğer zaten bir `ICustomXmlPart`'a sahipseniz ve belirli bir koleksiyona yönelmek yerine bu bölümü sunumdan kaldırmak istiyorsanız, `customXmlPart.remove()` çağırın.

Bir öğeyi indeksle de kaldırabilirsiniz:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Bir Koleksiyondan Tüm Özel XML Bölümlerini Temizleme**

`clear` komutunu, belirli bir sunum nesnesiyle ilişkili tüm özel XML bölümleri kaldırılmak istendiğinde kullanın.

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

`clear` yalnızca seçilen koleksiyonu etkiler. Örneğin, bir slaydın koleksiyonunu temizlemek, sunum düzeyindeki veya şekil düzeyindeki koleksiyonları temizlemez.

Sunumdaki tüm özel XML bölümlerini kaldırmak için `getAllCustomXmlParts()` üzerinden döngü yapın ve her bölümü kaldırın:

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

### **Bağlantılı veya Paylaşılan Özel XML Bölümlerini Yönetme**

Office Open XML bir sunumda, aynı özel XML bölümü birden fazla sunum nesnesinden başvurulabilir. Örneğin, mevcut bir dosya birden çok slayt veya şekilden aynı temel özel XML bölümüne ilişkiler içerebilir.

Paylaşılan bir bölüm, birden fazla referansı olan tek bir veri nesnesi gibi ele alınmalıdır:

- `setXmlAsString`, `setXmlData` veya `setItemId` ile güncellemek, temel özel XML bölümü değiştirir; böylece değişiklik bu bölüme başvuran her yerde uygulanır.
- `getItemId()` nesne‑düzeyi koleksiyonları denetlerken aynı özel XML bölümünü tanımlamak için kullanılabilir.
- Belirli bir `getCustomXmlParts()` koleksiyonundan bir bölümü kaldırmak, o koleksiyondan kaldırır. Bölümün kendisi sunumdan kaldırılacaksa `ICustomXmlPart.remove()` kullanın.
- Paylaşılan bir bölümü silmeden veya değiştirmeden önce, diğer slayt veya şekillerin hala başvurup başvurmadığını belirlemek için nesne‑düzeyi koleksiyonları inceleyin.

`add` aşırı yüklemeleri, XML içeriğinden yeni bir özel XML bölümü oluşturur; mevcut bir `ICustomXmlPart` kabul etmez. Bu nedenle, paylaşılan ilişkiler genellikle zaten bu ilişkileri içeren sunumlar yüklendiğinde görülür.

Aşağıdaki örnek, `ItemId` ile sunum, slayt ve şekil düzeyindeki koleksiyonları denetler ve birden fazla yerden başvurulan bölümleri raporlar:

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

Bu tür bir denetim, dış sistemler tarafından oluşturulan sunumlarda özel XML verilerini değiştirmeden veya silmeden önce faydalıdır; çünkü aynı meta veri bölümü birden fazla ilişkide bulunabilir.

## **Etiket Değerlerini Alma**

Slaytlarda bir etiket, `IDocumentProperties.getKeywords()` yöntemine karşılık gelir. Bu örnek kod, [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) için Java üzerinden Aspose.Slides for Android ile bir etiket değerinin nasıl alınacağını gösterir:

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

Aspose.Slides, sunumlara etiket eklemenize olanak tanır. Bir etiket genellikle iki öğeden oluşur:

- özel bir özelliğin adı, örneğin `MyTag`;
- özel özelliğin değeri, örneğin `My Tag Value`.

Sunumları belirli bir kural veya özelliğe göre sınıflandırmanız gerektiğinde, bu amaçla etiketler ekleyebilirsiniz. Örneğin, Kuzey Amerika ülkelerinden gelen sunumları sınıflandırmak istiyorsanız, bir Kuzey Amerika etiketi oluşturup ilgili ülkeyi değer olarak atayabilirsiniz.

Bu örnek kod, Aspose.Slides for Android via Java kullanarak bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation)’a etiket eklemenin nasıl yapılacağını gösterir:

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

Etiketler ayrıca bir [Slide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlide) için de ayarlanabilir:

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

Veya tek bir [Shape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IAutoShape) için:

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

`getCustomData().getTags()` koleksiyonu aracılığıyla eklenen etiketler yalnızca PowerPoint dosyasında depolanır. Sunum PDF'ye dışa aktarıldığında, bu etiketler PDF etiket yapısına **aktarılmaz**. Dolayısıyla, etiket olarak atanmış bir özel tanımlayıcı, etiketli PDF'den alınamaz.

**Geçici çözüm**: Özel bir tanımlayıcıyı nesnenin **Alt Text**'inde (örneğin, `shape.setAlternativeText("MyId")`) saklayabilirsiniz. PDF'ye dışa aktarıldıktan sonra Alt Text PDF etiket yapısında görünebilir.

## **SSS**

**Bir sunum, slayt veya şekilden tüm etiketleri tek bir işlemle kaldırabilir miyim?**  
Evet. [tag collection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tagcollection/) **clear**([clear](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tagcollection/#clear--)) işlemini destekler ve tüm anahtar‑değer çiftlerini bir seferde siler.

**Tüm koleksiyonu dolaşmadan, ismiyle tek bir etiketi nasıl silebilirim?**  
`[remove(name)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-)` metodunu [tag collection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tagcollection/) üzerinde kullanarak etiketi anahtarıyla silebilirsiniz.

**Analiz veya filtreleme için etiket adlarının tam listesini nasıl alabilirim?**  
`[getNamesOfTags](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--)` metodunu [tag collection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tagcollection/) üzerinde kullanın; tüm etiket adlarını içeren bir dizi döndürür.

**Özel XML bölümlerinin tümünü, nerede depolandıklarına bakılmaksızın nasıl bulabilirim?**  
`[Presentation.getAllCustomXmlParts()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--)` metodunu kullanarak sunumdaki tüm özel XML bölümlerini alabilirsiniz.

**Bir özel XML bölümünü güncellemek için `getXmlAsString`/`setXmlAsString` mı yoksa `getXmlData`/`setXmlData` mı kullanmalıyım?**  
Uygulama UTF‑8 XML metniyle çalışıyorsa `getXmlAsString` ve `setXmlAsString` kullanın. XML zaten bir bayt dizisi olarak mevcutsa veya ikili odaklı işlem daha uygun ise `getXmlData` ve `setXmlData` kullanın. Her iki temsil de aynı özel XML bölümünün XML içeriğine işaret eder.