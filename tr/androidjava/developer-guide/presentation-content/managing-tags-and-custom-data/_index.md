---
title: Android'de Sunumlarda Etiketleri ve Özel Verileri Yönetme
linktitle: Etiketler ve Özel Veri
type: docs
weight: 300
url: /tr/androidjava/managing-tags-and-custom-data
keywords:
- doküman özellikleri
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile PowerPoint sunumlarında etiketleri ve özel XML verilerini yönetmeyi, ekleme, okuma, güncelleme, denetleme ve özel XML bölümlerini kaldırmayı öğrenin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ın PowerPoint sunumlarında etiketler ve özel verilerle nasıl çalıştığını açıklar. Sunum özgü veriler etiketler veya özel XML bölümleri olarak saklanabilir. Etiketler basit anahtar‑değer dize çiftleridir, özel XML bölümleri ise yapılandırılmış üst veri ve uygulama özgü XML yüklerini saklayabilir.

Aspose.Slides, sunum, slayt ve şekil düzeylerinde özel XML bölümlerini eklemek, okumak, güncellemek, denetlemek ve kaldırmak için API'ler sağlar. Özel XML bölümleri, belge yönetimi tanımlayıcıları, iş akışı durumu, uyumluluk üst verileri, şablon bağlama verileri veya bir sunum içinde bulunan diğer yapılandırılmış uygulama verileri gibi bilgileri depolayan entegrasyonlar için yararlıdır.

## **Sunum Dosyalarında Veri Depolama**

PPTX dosyaları—`.pptx` uzantılı dosyalar—PresentationML formatında saklanır ve bu, Office Open XML spesifikasyonunun bir parçasıdır. Office Open XML, sunum içeriği ve ilgili verileri depolamak için kullanılan paket yapısını ve ilişkileri tanımlar.

Bir sunum, ilişkilerle bağlanmış birden çok parçayı içerir. Örneğin, bir slayt parçası tek bir slaytın içeriğini barındırır ve ISO/IEC 29500 tarafından tanımlanan diğer parçalara açık ilişkiler içerebilir.

Özel veriler etiketler ([ITagCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ITagCollection)) veya özel XML bölümleri ([ICustomXmlPartCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICustomXmlPartCollection)) olarak saklanabilir. Her ikisi de [`ICustomData`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICustomData/) arayüzü üzerinden kullanılabilir.

{{% alert color="info" %}}
Etiketler basit dize anahtar‑değer çiftlerini saklar. Özel XML bölümleri yapılandırılmış XML verilerini saklar ve bir sunum, slayt veya şekille ilişkilendirilebilir.
{{% /alert %}}

## **Özel XML Bölümleriyle Çalışma**

[`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICustomData#getCustomXmlParts--) yöntemi, belirli bir sunum nesnesiyle ilişkili özel XML bölümü koleksiyonunu döndürür. Örneğin:

- `presentation.getCustomData().getCustomXmlParts()` sunumun kendisiyle ilişkili özel XML bölümlerini içerir.
- `slide.getCustomData().getCustomXmlParts()` belirli bir slaytla ilişkili özel XML bölümlerini içerir.
- `shape.getCustomData().getCustomXmlParts()` belirli bir şekille ilişkili özel XML bölümlerini içerir.

Sunumda nerede ilişkilendirildiğine bakılmaksızın tüm özel XML bölümlerini incelemeniz gerektiğinde [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) yöntemini kullanın.

### **Bir Sunuma Özel XML Bölümü Ekleme**

[`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) yöntemini kullanarak XML verisini bir özel XML bölüm koleksiyonuna ekleyin. XML geçerli ve boş olmamalıdır.

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

    // add otomatik olarak bir tanımlayıcı atar. Gerektiğinde yalnızca belirli bir UUID ayarlayın.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`add` yöntemi ayrıca XML'i bir bayt dizisi veya giriş akışı olarak da kabul edebilir; bu, XML içeriği zaten ikili biçimde mevcut olduğunda faydalıdır.

### **Bir Slayt veya Şekle Özel XML Bölümü Ekleme**

Özel XML verisi, tüm sunuma yerine belirli bir slayt veya şekille ilişkilendirilebilir. Bu, üst verinin yalnızca bir nesneyi tanımlaması gerektiğinde (örneğin bir şablon anahtarı, dış kayıt tanımlayıcısı veya bağlama bilgisi) kullanışlıdır.

Aşağıdaki örnek bir slayta bir özel XML bölümü, bir şekle başka bir bölüm ekler:

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

Bir bölümün eklendiği düzey, hangi nesnenin `getCustomData().getCustomXmlParts()` koleksiyonunun bu bölümle ilişkili olduğunu belirler. Sunum‑düzeyindeki veri belge‑geneli üst veri için, slayt‑düzeyindeki veri belirli bir slayta ait bilgi için ve şekil‑düzeyindeki veri bireysel bir şekille bağlantılı üst veri için uygundur.

### **Tüm Özel XML Bölümlerini Listeleme ve Denetleme**

[`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) yöntemini kullanarak bir sunumdaki tüm özel XML bölümlerini alın. Her [`ICustomXmlPart`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICustomXmlPart/) kimliğini, XML içeriğini ve ilişkili ad alanı şemalarını gösterir.

Aşağıdaki örnek tüm özel XML bölümlerini ve ad alanı şemalarını listeler:

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

[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) yöntemi, özel XML bölümüyle ilişkili XML şemalarını döndürür. Bu bilgi, dış sistemler tarafından üretilen XML içeren sunumları denetlerken yararlı olabilir.

### **XML İçeriğini ve ItemId'yi Okuma ve Güncelleme**

[`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICustomXmlPart#getXmlAsString--) ve [`setXmlAsString()`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) yöntemlerini kullanarak XML'i UTF‑8 dizesi olarak işleyebilir, ya da [`getXmlData()`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICustomXmlPart#getXmlData--) ve [`setXmlData()`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) ile ham XML baytlarını işleyebilirsiniz.

[`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICustomXmlPart#getItemId--) yöntemi, özel XML bölümünü Office Open XML belgesinde tanımlayan UUID'yi döndürür. Bir bütünleşme yeni bir tanımlayıcı gerektirdiğinde [`setItemId()`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) kullanılmalıdır.

Aşağıdaki örnek XML içeriğini ve tanımlayıcıyı günceller:

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

    // Entegrasyon tarafından gerektiğinde tanımlayıcıyı değiştirin.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`setXmlAsString` veya `setXmlData` çağrılırken geçerli, boş olmayan XML sağlayın. Uygulamanın çoğunlukla dize mi yoksa bayt verisiyle mi çalıştığına bağlı olarak bir temsil biçimini tercih edin.

### **Bir Özel XML Bölümünü Kaldırma**

Aspose.Slides, özel XML verisini kaldırmanın birkaç yolunu sunar:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICustomXmlPart#remove--) özel XML bölümünü sunumdan kaldırır.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) belirli bir bölümü bir özel XML bölüm koleksiyonundan kaldırır.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICustomXmlPartCollection#removeAt-int--) belirtilen koleksiyon indeksindeki bölümü kaldırır.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICustomXmlPartCollection#clear--) belirli bir koleksiyondan tüm bölümleri kaldırır.

Aşağıdaki örnek, referans yoluyla bir sunum‑düzeyindeki özel XML bölümünü kaldırır:

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

Zaten bir `ICustomXmlPart` nesneniz varsa ve belirli bir koleksiyona yönelmek yerine bölümü sunumdan kaldırmak istiyorsanız `customXmlPart.remove()` çağrısı yapın.

Bir öğeyi indeks yoluyla da kaldırabilirsiniz:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Bir Koleksiyondan Tüm Özel XML Bölümlerini Temizleme**

Bir sunum nesnesiyle ilişkili tüm özel XML bölümlerinin kaldırılması gerektiğinde `clear` yöntemi kullanın.

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

`clear` yalnızca seçili koleksiyonu etkiler. Örneğin, bir slaytın koleksiyonunu temizlemek, sunum‑düzeyindeki veya şekil‑düzeyindeki koleksiyonları temizlemez.

Sunumdaki her özel XML bölümünü kaldırmak için `getAllCustomXmlParts()` üzerinde döngü kurup her bölümü kaldırın:

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

### **Bağlantılı veya Paylaşılan Özel XML Bölümlerini İşleme**

Office Open XML bir sunumunda aynı özel XML bölümü birden çok sunum nesnesi tarafından referans alınabilir. Örneğin, mevcut bir dosya birden çok slayt veya şekilden aynı temel özel XML bölümüne ilişki içerebilir.

Paylaşılan bir bölüm, birden çok referansa sahip tek bir veri nesnesi gibi ele alınmalıdır:

- `setXmlAsString`, `setXmlData` veya `setItemId` ile güncellemek, temel özel XML bölümünü değiştirir; bu değişiklik bölümün referans alındığı her yerde görülür.
- `getItemId()` nesne‑düzeyindeki koleksiyonları denetlerken aynı özel XML bölümü tanımlamak için kullanılabilir.
- Belirli bir `getCustomXmlParts()` koleksiyonundan bir bölümü kaldırmak, sadece o koleksiyonu etkiler. Bölümün sunumdan tamamen kaldırılması isteniyorsa `ICustomXmlPart.remove()` kullanın.
- Paylaşılan bir bölümü silmeden veya değiştirmeden önce, diğer slayt veya şekillerin hâlâ referans verip vermediğini belirlemek için nesne‑düzeyindeki koleksiyonları inceleyin.

`add` aşırı yüklemeleri, XML içeriğinden yeni bir özel XML bölümü oluşturur; mevcut bir `ICustomXmlPart` kabul etmez. Bu nedenle, paylaşılan ilişkiler genellikle zaten bu bölümleri içeren sunumları yüklerken ortaya çıkar.

Aşağıdaki örnek, `ItemId` ile sunum‑, slayt‑ ve şekil‑düzeyindeki koleksiyonları denetler ve birden fazla yerden referans alınan bölümleri raporlar:

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

Bu tip denetim, dış sistemler tarafından oluşturulan sunumlarda özel XML verisini değiştirmeden veya silmeden önce yararlıdır; çünkü aynı üst veri bölümü birden çok ilişki içinde yer alabilir.

## **Etiket Değerlerini Alma**

Slaytlarda bir etiket, `IDocumentProperties.getKeywords()` yöntemine karşılık gelir. Aşağıdaki örnek kod, [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) için Android Java Aspose.Slides kullanarak bir etiket değerinin nasıl alınacağını gösterir:

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

Aspose.Slides, sunumlara etiket eklemenizi sağlar. Bir etiket tipik olarak iki öğeden oluşur:

- özel bir özelliğin adı, örneğin `MyTag`;
- özel özelliğin değeri, örneğin `My Tag Value`.

Belirli bir kural veya özellik temelinde sunumları sınıflandırmanız gerektiğinde bu amaçla etiket ekleyebilirsiniz. Örneğin, Kuzey Amerika ülkelerinden gelen sunumları sınıflandırmak istiyorsanız bir “North American” etiketi oluşturup ilgili ülkeyi değeri olarak atayabilirsiniz.

Aşağıdaki örnek kod, Aspose.Slides for Android via Java kullanarak bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) üzerine etiket eklemeyi gösterir:

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

Ya da tek bir [Shape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IAutoShape) için:

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

`getCustomData().getTags()` koleksiyonu aracılığıyla eklenen etiketler yalnızca PowerPoint dosyasında saklanır. Sunum PDF’ye dışa aktarıldığında etiket yapısına **aktarılmaz**. Sonuç olarak, etiket olarak atanan özel tanımlayıcı PDF’deki etiketli yapıda bulunamaz.

**Geçici Çözüm**: Özel tanımlayıcıyı nesnenin **Alt Text** özelliğinde saklayabilirsiniz (örneğin `shape.setAlternativeText("MyId")`). PDF’ye dışa aktarıldıktan sonra Alt Text PDF etiket yapısında görünebilir.

## **SSS**

**Bir sunum, slayt veya şekilden tüm etiketleri tek bir işlemle kaldırabilir miyim?**  
Evet. Etiket koleksiyonu ([tag collection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tagcollection/)) bir defada tüm anahtar‑değer çiftlerini silen bir **clear** işlemini destekler.

**Tüm koleksiyonu yinelemeye gerek kalmadan adıyla tek bir etiketi nasıl silebilirim?**  
Etiket koleksiyonunda (`[tag collection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tagcollection/)`) `remove(name)` yöntemiyle etiketi anahtarıyla silebilirsiniz.

**Analiz veya filtreleme için etiket adlarının tam listesini nasıl alabilirim?**  
Etiket koleksiyonunda `getNamesOfTags` yöntemi, tüm etiket adlarının bir dizisini döndürür.

**Özel XML bölümlerinin nerede depolandığından bağımsız olarak hepsini nasıl bulabilirim?**  
Sunumdaki tüm özel XML bölümlerini almak için [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) yöntemini kullanın.

**Bir özel XML bölümünü güncellemek için `getXmlAsString`/`setXmlAsString` mı yoksa `getXmlData`/`setXmlData` mı kullanmalıyım?**  
Uygulama UTF‑8 XML metniyle çalışıyorsa `getXmlAsString` ve `setXmlAsString` kullanın. XML zaten bir bayt dizisi olarak varsa veya ikili‑odaklı işleme daha uygunsa `getXmlData` ve `setXmlData` kullanın. Her iki temsil de aynı özel XML bölümünün içeriğine işaret eder.