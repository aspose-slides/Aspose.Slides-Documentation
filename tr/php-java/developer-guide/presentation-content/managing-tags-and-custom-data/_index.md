---
title: PHP Kullanarak Sunumlarda Etiketleri ve Özel Verileri Yönetme
linktitle: Etiketler ve Özel Veri
type: docs
weight: 300
url: /tr/php-java/managing-tags-and-custom-data/
keywords:
- belge özellikleri
- etiket
- özel veri
- özel XML
- özel XML bölümü
- XML meta verileri
- ItemId
- etiket ekle
- çift değerler
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint sunumlarında etiketleri ve özel XML verilerini yönetmeyi, ekleme, okuma, güncelleme, denetleme ve özel XML bölümlerini kaldırma dahil öğrenin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ın PowerPoint sunumlarında etiketler ve özel verilerle nasıl çalıştığını açıklar. Sunuma özgü veriler etiketler veya özel XML bölümleri olarak depolanabilir. Etiketler basit anahtar‑değer dize çiftleridir, özel XML bölümleri ise yapılandırılmış meta verileri ve uygulamaya özgü XML yüklerini saklayabilir.

Aspose.Slides, sunum, slayt ve şekil seviyelerinde özel XML bölümlerini ekleme, okuma, güncelleme, denetleme ve kaldırma için API’ler sunar. Özel XML bölümleri, belge‑yönetim kimlikleri, iş akışı durumu, uyumluluk meta verileri, şablon bağlama verileri veya sunum içinde saklanacak diğer yapılandırılmış uygulama verileri gibi bilgileri depolamak için entegrasyonlarda faydalıdır.

{{% alert color="primary" %}}
Etiketler basit dize anahtar‑değer çiftlerini saklar. Özel XML bölümleri yapılandırılmış XML verilerini saklar ve bir sunuma, slayta veya şekle ilişkilendirilebilir.
{{% /alert %}}

## **Sunum Dosyalarında Veri Depolama**

PPTX dosyaları—`.pptx` uzantılı dosyalar—PresentationML biçiminde, Office Open XML (OOXML) standardının bir parçası olarak depolanır. OOXML, sunum içeriği ve ilgili verilerin paket yapısını ve ilişkilerini tanımlar.

Bir sunum, ilişkilerle bağlanmış birden çok parçadan oluşur. Örneğin, bir slayt parçası tek bir slaytın içeriğini barındırır ve ISO/IEC 29500 tarafından tanımlanan diğer parçalara açık ilişkiler içerebilir.

Özel veriler, etiketler ([TagCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tagcollection/)) veya özel XML bölümleri ([CustomXmlPartCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/customxmlpartcollection/)) olarak depolanabilir. İkisi de [`CustomData`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/customdata/) sınıfı aracılığıyla kullanılabilir.

## **Özel XML Bölümleriyle Çalışma**

[`CustomData::getCustomXmlParts()`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/customdata/#getCustomXmlParts) yöntemi, belirli bir sunum nesnesine bağlı özel XML bölümleri koleksiyonunu döndürür. Örneğin:

- `$presentation->getCustomData()->getCustomXmlParts()` sunuma özgü özel XML bölümlerini içerir.
- `$slide->getCustomData()->getCustomXmlParts()` belirli bir slayta özgü özel XML bölümlerini içerir.
- `$shape->getCustomData()->getCustomXmlParts()` belirli bir şekle özgü özel XML bölümlerini içerir.

Sunumda nerede bulunduğu önemli olmaksızın tüm özel XML bölümlerini incelemeniz gerektiğinde [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getAllCustomXmlParts) kullanın.

### **Sunuma Özel XML Bölümü Ekleme**

[`CustomXmlPartCollection::add`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/customxmlpartcollection/#add) kullanarak bir özel XML bölümü koleksiyonuna XML veri ekleyin. XML geçerli ve boş olmamalıdır.

Aşağıdaki örnek, sunum‑seviyesindeki özel veri koleksiyonuna yapılandırılmış meta veriler ekler:

```php
$customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' .
    '<metadata xmlns="urn:example:metadata">' .
        '<documentId>DOC-1001</documentId>' .
        '<workflowState>Draft</workflowState>' .
    '</metadata>';

$presentation = new Presentation();
try {
    $customXmlPart = $presentation->getCustomData()->getCustomXmlParts()->add($customXmlContent);

    // add otomatik olarak bir tanımlayıcı atar. Belirli bir UUID yalnızca gerektiğinde ayarlanır.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("presentation_with_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`add` yöntemi XML’i bayt dizisi ya da giriş akışı olarak da kabul eder; bu, XML içeriği zaten ikili biçimde mevcut olduğunda yararlıdır.

### **Bir Slayta veya Şekle Özel XML Bölümü Ekleme**

Özel XML verisi, tüm sunum yerine belirli bir slayt veya şekle ilişkilendirilebilir. Bu, meta verinin yalnızca bir nesneyi (ör. şablon anahtarı, dış kayıt kimliği veya bağlama bilgisi) tanımladığı durumlarda faydalıdır.

Aşağıdaki örnek, bir slayta bir özel XML bölümü ve bir şekle bir tane daha ekler:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getCustomData()->getCustomXmlParts()->add(
        '<slideMetadata xmlns="urn:example:slides">' .
            '<templateKey>TitleSlide</templateKey>' .
        '</slideMetadata>'
    );

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 250, 80);

    $shape->getTextFrame()->setText("Customer data");
    $shape->getCustomData()->getCustomXmlParts()->add(
        '<shapeMetadata xmlns="urn:example:shapes">' .
            '<recordId>CRM-4281</recordId>' .
        '</shapeMetadata>'
    );

    $presentation->save("object_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Bir parçanın eklendiği seviye, hangi nesnenin `getCustomData()->getCustomXmlParts()` koleksiyonunun bu parçaya ilişkin ilişkiyi içerdiğini belirler. Sunum‑seviyesi veri belge‑geneli meta veri için, slayt‑seviyesi veri belirli bir slayta ait bilgi için ve şekil‑seviyesi veri tek bir şekle bağlı meta veri için uygundur.

### **Tüm Özel XML Bölümlerini Listeleme ve Denetleme**

[`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getAllCustomXmlParts) kullanarak bir sunumdan tüm özel XML bölümlerini alın. Her [`CustomXmlPart`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/customxmlpart/) kimliğini, XML içeriğini ve ilişkili ad alanı şemalarını sunar.

Aşağıdaki örnek, tüm özel XML bölümlerini ve bunların ad alanı şemalarını listeler:

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        echo "ItemId: " . $customXmlPart->getItemId() . PHP_EOL;
        echo "XML:" . PHP_EOL;
        echo $customXmlPart->getXmlAsString() . PHP_EOL;

        foreach ($customXmlPart->getNamespaceSchemas() as $namespaceSchema) {
            echo "Namespace schema: " . $namespaceSchema . PHP_EOL;
        }

        echo PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

[`CustomXmlPart::getNamespaceSchemas()`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/customxmlpart/#getNamespaceSchemas) yöntemi, özel XML bölümüne ait XML şemalarını döndürür. Bu bilgi, dış sistemler tarafından üretilen XML içeren sunumları denetlerken faydalı olabilir.

### **XML İçeriğini ve ItemId'yi Okuma ve Güncelleme**

XML içeriğiyle UTF‑8 dize olarak çalışmak için [`CustomXmlPart::getXmlAsString()`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/customxmlpart/#getXmlAsString) ve [`setXmlAsString()`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/customxmlpart/#setXmlAsString) kullanın; ham XML baytlarıyla çalışmak için [`getXmlData()`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/customxmlpart/#getXmlData) ve [`setXmlData()`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/customxmlpart/#setXmlData) kullanın.

[`CustomXmlPart::getItemId()`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/customxmlpart/#getItemId) yöntemi, Office Open XML belgesinde özel XML bölümünü tanımlayan UUID’yi döndürür. Entegrasyon yeni bir kimlik gerektiriyorsa [`setItemId()`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/customxmlpart/#setItemId) kullanın.

Aşağıdaki örnek, XML içeriğini ve kimliği günceller:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlPart = $presentation->getAllCustomXmlParts()[0];

    // Mevcut XML'i metin olarak oku.
    $currentXmlContent = $customXmlPart->getXmlAsString();
    echo $currentXmlContent . PHP_EOL;

    // XML'i UTF-8 dizesi olarak güncelle.
    $customXmlPart->setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' .
            '<documentId>DOC-1001</documentId>' .
            '<workflowState>Approved</workflowState>' .
        '</metadata>'
    );

    // getXmlData aynı XML içeriğini ham baytlar olarak sağlar.
    $customXmlData = $customXmlPart->getXmlData();

    // Entegrasyon tarafından gerektiğinde tanımlayıcıyı değiştir.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("updated_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`setXmlAsString` ya da `setXmlData` çağırırken geçerli, boş olmayan XML sağlayın. Uygulamanız daha çok dizeyle mi yoksa bayt verisiyle mi çalışıyorsa uygun temsil biçimini seçin.

### **Bir Özel XML Bölümünü Kaldırma**

Aspose.Slides, özel XML verisini kaldırmak için çeşitli yollar sunar:

- [`CustomXmlPart::remove`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/customxmlpart/#remove) özel XML bölümünü sunumdan kaldırır.
- [`CustomXmlPartCollection::remove`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/customxmlpartcollection/#remove) belirli bir bölümü koleksiyondan kaldırır.
- [`CustomXmlPartCollection::removeAt`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/customxmlpartcollection/#removeAt) belirtilen koleksiyon indeksindeki bölümü kaldırır.
- [`CustomXmlPartCollection::clear`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/customxmlpartcollection/#clear) belirli bir koleksiyondaki tüm bölümleri kaldırır.

Aşağıdaki örnek, referans yoluyla bir sunum‑seviyesi özel XML bölümünü kaldırır:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlParts = $presentation->getCustomData()->getCustomXmlParts();

    if (java_values($customXmlParts->size()) > 0) {
        $customXmlPart = $customXmlParts->get_Item(0);
        $customXmlParts->remove($customXmlPart);
    }

    $presentation->save("custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Zaten bir `CustomXmlPart` nesneniz varsa ve belirli bir koleksiyona başvurmadan bu bölümü sunumdan kaldırmak istiyorsanız `$customXmlPart->remove()` çağırın.

İndeks üzerinden bir öğe de kaldırılabilir:

```php
$presentation->getCustomData()->getCustomXmlParts()->removeAt(0);
```

### **Bir Koleksiyondan Tüm Özel XML Bölümlerini Temizleme**

Belirli bir sunum nesnesine bağlı tüm özel XML bölümleri kaldırılacaksa `clear` kullanın.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getSlides()->get_Item(0)->getCustomData()->getCustomXmlParts()->clear();

    $presentation->save("slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`clear` yalnızca seçili koleksiyonu etkiler. Örneğin, bir slaytın koleksiyonunu temizlemek, sunum‑seviyesi ya da şekil‑seviyesi koleksiyonlarını temizlemez.

Sunumdaki tüm özel XML bölümlerini kaldırmak için `getAllCustomXmlParts()` üzerinden döngü yapıp her bölümü kaldırın:

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        $customXmlPart->remove();
    }

    $presentation->save("all_custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Bağlantılı veya Paylaşılan Özel XML Bölümlerini Yönetme**

Office Open XML bir sunumunda aynı özel XML bölümü birden fazla nesne tarafından referans alınabilir. Örneğin, mevcut bir dosya birden çok slayt ya da şekilden aynı temel özel XML bölümüne ilişki içerebilir.

Paylaşılan bir bölüm, birden çok referansı olan tek bir veri nesnesi olarak ele alınmalıdır:

- `setXmlAsString`, `setXmlData` veya `setItemId` ile güncellemek, temel özel XML bölümünü değiştirir; böylece bölümün referans edildiği tüm yerlerde değişiklik yansır.
- `getItemId()` aynı özel XML bölümünü nesne‑seviyesi koleksiyonları denetlerken tanımlamak için kullanılabilir.
- Belirli bir `getCustomXmlParts()` koleksiyonundan bir bölümü kaldırmak, sadece o koleksiyonu etkiler. Bölümün sunumdan tamamen kaldırılması isteniyorsa `CustomXmlPart::remove()` kullanın.
- Paylaşılan bir bölümü silmeden ya da değiştirmeden önce, diğer slayt veya şekillerin hâlâ ona referans verip vermediğini anlamak için nesne‑seviyesi koleksiyonları inceleyin.

`add` aşırı yüklemeleri, XML içeriğinden yeni bir özel XML bölümü oluşturur; mevcut bir `CustomXmlPart` kabul etmez. Bu nedenle, paylaşılan ilişkiler genellikle zaten bu ilişkileri içeren sunumlar yüklendiğinde ortaya çıkar.

Aşağıdaki örnek, `ItemId` üzerinden sunum‑, slayt‑ ve şekil‑seviyesi koleksiyonları denetler ve birden fazla konumda referans verilen bölümleri raporlar:

```php
function registerCustomXmlParts($ownerName, $customXmlParts, &$referencesByItemId) {
    $partCount = java_values($customXmlParts->size());

    for ($i = 0; $i < $partCount; $i++) {
        $customXmlPart = $customXmlParts->get_Item($i);
        $itemId = java_values($customXmlPart->getItemId()->toString());

        if (!isset($referencesByItemId[$itemId])) {
            $referencesByItemId[$itemId] = [];
        }

        $referencesByItemId[$itemId][] = $ownerName;
    }
}

$presentation = new Presentation("presentation.pptx");
try {
    $referencesByItemId = [];

    registerCustomXmlParts(
        "Presentation",
        $presentation->getCustomData()->getCustomXmlParts(),
        $referencesByItemId
    );

    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        registerCustomXmlParts(
            "Slide " . ($slideIndex + 1),
            $slide->getCustomData()->getCustomXmlParts(),
            $referencesByItemId
        );

        $shapeCount = java_values($slide->getShapes()->size());
        for ( $shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            registerCustomXmlParts(
                "Slide " . ($slideIndex + 1) . ", shape " . $shapeIndex,
                $shape->getCustomData()->getCustomXmlParts(),
                $referencesByItemId
            );
        }
    }

    foreach ($referencesByItemId as $itemId => $owners) {
        if (count($owners) > 1) {
            echo "Shared custom XML part: " . $itemId . PHP_EOL;

            foreach ($owners as $ownerName) {
                echo "  Referenced by: " . $ownerName . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Bu tür bir denetim, dış sistemler tarafından oluşturulan sunumlarda özellikle birden çok ilişki içinde bulunabilecek aynı meta veri parçasını değiştirmeden veya silmeden önce faydalıdır.

## **Etiket Değerlerini Almak**

Slaytlarda bir etiket, `DocumentProperties::getKeywords()` yöntemine karşılık gelir. Aşağıdaki örnek kod, Aspose.Slides for PHP via Java kullanarak bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) için etiket değerinin nasıl alınacağını gösterir:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $keywords = $presentation->getDocumentProperties()->getKeywords();
} finally {
    $presentation->dispose();
}
```

## **Sunumlara Etiket Ekleme**

Aspose.Slides, sunumlara etiket eklemenize olanak tanır. Bir etiket tipik olarak iki öğeden oluşur:

- özel bir özelliğin adı, örneğin `MyTag`;
- özel özelliğin değeri, örneğin `My Tag Value`.

Sunumları belirli bir kural veya özelliğe göre sınıflandırmanız gerekiyorsa bu amaçla etiketler ekleyebilirsiniz. Örneğin, Kuzey Amerika ülkelerinden gelen sunumları sınıflandırmak isterseniz bir “NorthAmerican” etiketi oluşturup ilgili ülkeyi değer olarak atayabilirsiniz.

Aşağıdaki örnek, Aspose.Slides for PHP via Java kullanarak bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) üzerine etiket eklemeyi gösterir:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $tags = $presentation->getCustomData()->getTags();
    $tags->set_Item("MyTag", "My Tag Value");
} finally {
    $presentation->dispose();
}
```

Etiketler bir [Slide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/) için de ayarlanabilir:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

Ya da tek bir [Shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) için:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

### **Sınırlamalar**

`getCustomData()->getTags()` koleksiyonu aracılığıyla eklenen etiketler yalnızca PowerPoint dosyasında saklanır. Sunum PDF’ye dışa aktarıldığında bu etiketler PDF etiket yapısına **aktarılmaz**. Dolayısıyla, bir etiket olarak atanmış özel kimlik PDF’den elde edilemez.

**Çözüm**: Kimliği nesnenin **Alt Metni** içinde saklayabilirsiniz (ör. `$shape->setAlternativeText("MyId")`). PDF’ye dışa aktarıldıktan sonra Alt Metin PDF etiket yapısında görünebilir.

## **SSS**

**Bir sunum, slayt veya şekilden tüm etiketleri tek bir işlemle kaldırabilir miyim?**  
Evet. [tag collection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tagcollection/) [clear](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tagcollection/#clear) işlemini destekler; bu, tüm anahtar‑değer çiftlerini bir seferde siler.

**Tüm koleksiyonu dolaşmadan, adını bilerek tek bir etiketi nasıl silebilirim?**  
[tag collection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tagcollection/) üzerindeki [remove(name)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tagcollection/#remove) metodunu kullanarak etiketi anahtarıyla silebilirsiniz.

**Analiz veya filtreleme için etiket adlarının tam listesini nasıl alabilirim?**  
[tag collection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tagcollection/) üzerindeki [getNamesOfTags](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tagcollection/#getNamesOfTags) metodunu kullanın; bu, tüm etiket adlarını bir dizi olarak döndürür.

**Özel XML bölümlerini nerede depolandığını düşünmeden hepsini nasıl bulabilirim?**  
Tüm özel XML bölümlerini almak için [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getAllCustomXmlParts) kullanın.

**Bir özel XML bölümünü güncellemek için `getXmlAsString`/`setXmlAsString` mi yoksa `getXmlData`/`setXmlData` mi kullanılmalı?**  
Uygulama UTF‑8 XML metniyle çalışıyorsa `getXmlAsString` ve `setXmlAsString` kullanın. XML zaten bayt dizisi olarak mevcutsa ya da ikili‑odaklı işlem daha uygun ise `getXmlData` ve `setXmlData` kullanın. Her iki temsil de aynı özel XML bölümünün içeriğine işaret eder.