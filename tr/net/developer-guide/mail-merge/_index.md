---
title: Mail Birleştirme ile Sunum Kişiselleştirmeyi Otomatikleştirin
linktitle: Mail Birleştirme
type: docs
weight: 233
url: /tr/net/mail-merge/
keywords:
- Mail Birleştirme
- sunum kişiselleştirme
- sunum şablonu
- metin yer tutucular
- veri kaynağı
- CSV
- Excel
- XLSX
- JSON
- XML
- veri birleştirme
- sunum oluşturma
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te Mail Birleştirme'yi kullanarak sunum şablonlarını veriyle doldurmayı ve CSV, Excel, JSON ve XML kaynaklarından kişiselleştirilmiş PowerPoint sunumları oluşturmayı öğrenin."
---
# PowerPoint Sunumlarında Posta Birleştirme

Aspose.Slides for .NET, bir şablon ve veri kaynağı kullanarak PowerPoint sunumlarını otomatik olarak oluşturmanıza olanak tanır. Posta Birleştirme, şablon yer tutucularını veri ile doldurur ve ya her veri kümesi için tekrarlanan şablon slaytlarını içeren tek bir sunum ya da her veri kümesi için ayrı bir sunum oluşturur.

Bu işlevsellik, ürün katalogları, kişiselleştirilmiş sunumlar, raporlar, sertifikalar, teklifler, fiyat listeleri ve sunum yapısı aynı kalırken içeriğin değiştiği diğer belgelerin oluşturulması için kullanışlıdır.

![Posta Birleştirme: önce ve sonra](mail-merge-before-after.png)


## Posta Birleştirme Nasıl Çalışır

Posta Birleştirme, bir PowerPoint sunumunu şablon olarak kullanır ve yer tutucuları veri kaynağından gelen değerlerle değiştirir.

![Posta Birleştirme iş akışı](mail-merge-workflow.png)

Yer tutucu, çift süslü parantez içinde bir alan adıdır; örneğin `{{title}}` veya `{{price}}`. Yer tutucular, şekillerdeki metinlerde, tablo hücrelerinde, gruplanmış şekillerde ve konuşmacı notlarında bulunabilir.

Örneğin, bir şablon slaytı aşağıdaki metni içerebilir:

- `Product: {{title}}`
- `Price: {{price}}`
- `Description: {{description}}`

Veri kaynağı aşağıdaki değerleri içerdiğinde:

| Alan | Değer |
|---|---|
| title | Laptop X1 |
| price | $999 |
| description | 14-inch display, 16 GB RAM |

Posta Birleştirme, yer tutucuları karşılık gelen değerlerle değiştirir ve gerçek ürün bilgilerini içeren bir slayt üretir.

Alan adları büyük/küçük harfe duyarsızdır; bu nedenle `{{title}}` ve `{{Title}}` aynı alanı gösterir.

Yer tutucuların değiştirilmesiyle ilgili kurallar:

- Yer tutucular slaytlarda, gruplanmış şekillerde, tablo hücrelerinde ve konuşmacı notlarında değiştirilir.
- Ana slaytlarda ve yerleşim slaytlarında yer tutucular değiştirilmez.
- Alan veri kümesinde bulunmayan bir yer tutucu değişmeden kalır.
- Boş bir alan değeri, yer tutucuyu boş bir dizeyle değiştirir.
- Eklenen metin, yer tutucunun ilk karakterinin biçimlendirmesini devralır.
- Değerler, yer tutucu metni içermemelidir; çünkü eklenen metin tekrar işlenip başka bir alanla değiştirilebilir.

Birleştirme işlemi sırasında orijinal şablon sunumu değiştirilmez ve en az bir slayt içermelidir.

## Desteklenen Veri Kaynakları

Posta Birleştirme, veriyi iki şekilde sağlamayı destekler:

- `IMailMergeDataSource` kullanarak veri kaynağını programlı olarak oluşturma.
- CSV, XLSX, JSON veya XML dosyasından veya akışından veri okuma.

Veri formatı, dosya uzantısına değil içeriğine göre belirlenir. Arama (seeking) desteklemeyen akışlar da desteklenir.

Veri kaynağı en az bir veri kümesi içermelidir. Her veri kümesi, değerleriyle doldurulacak bir şablon kopyasını temsil eder.

Veri içeriği desteklenen bir format olarak tanınamazsa `NotSupportedException` fırlatılır. İçerik tanınır ancak format gereksinimlerine uymuyorsa `InvalidDataException` fırlatılır. İstisna mesajı, verideki hatanın konumunu belirtir.

### JSON

JSON veri kaynağının, bir `sets` dizisi içeren bir kök nesnesi olması gerekir. Dizi içinde her eleman bir veri kümesini temsil eder ve bir `fields` dizisi içermelidir. Her alan bir `name` ve bir `value` dizesi içermelidir.

Opsiyonel `version` özelliği `"1.0"` olmalı, bir alanın opsiyonel `type` özelliği `"text"` olmalıdır. Özellik adları büyük/küçük harfe duyarlıdır. Bilinmeyen özellikler yok sayılır.

JSON verisi UTF‑8 olarak okunur; veri bir bayt sırası işareti (BOM) ile başlıyorsa UTF‑16 olarak okunur.

Aşağıdaki örnek iki veri kümesi içerir:

```json
{
  "version": "1.0",
  "sets": [
    {
      "fields": [
        { "name": "title", "value": "Laptop X1" },
        { "name": "price", "value": "$999" }
      ]
    },
    {
      "fields": [
        { "name": "title", "value": "Tablet S2" },
        { "name": "price", "value": "$499" }
      ]
    }
  ]
}
```

### XML

XML veri kaynağının, `sets` öğesini içeren bir `template` kök öğesi olması gerekir. Her `set` öğesi `field` öğeleri içerir ve her alan `name` ve `value` öğeleri bulundurmalıdır.

Boş bir `value` öğesi boş bir dize olarak değerlendirilir. Öğe adları büyük/küçük harfe duyarlıdır. Bilinmeyen öğeler ve yorumlar yok sayılır. Kodlamayı XML bildirimi belirler. Belge türü tanımları (DTD) izin verilmez.

```xml
<?xml version="1.0" encoding="utf-8"?>
<template>
  <sets>
    <set>
      <field>
        <name>title</name>
        <value>Laptop X1</value>
      </field>
      <field>
        <name>price</name>
        <value>$999</value>
      </field>
    </set>
    <set>
      <field>
        <name>title</name>
        <value>Tablet S2</value>
      </field>
      <field>
        <name>price</name>
        <value>$499</value>
      </field>
    </set>
  </sets>
</template>
```

### CSV

CSV verisi, değer ayırıcı olarak noktalı virgül (;) kullanır.

İlk satır alan adlarını içerir ve ilk boş alan adında sona erer. Her sonraki satır bir veri kümesini temsil eder. Veri, ilk boş satırda sona erer.

Uygulanan kurallar:

- Bir satırın sonunda eksik değerler boş dize olarak kabul edilir.
- Tanımlı alan adları dışındaki değerler yok sayılır.
- Noktalı virgül, çift tırnak veya satır sonu içeren bir değer çift tırnak içinde olmalıdır.
- Çift tırnak içinde bir değer içindeki çift tırnaklar iki kez yazılmalıdır.
- Veri UTF‑8 olarak okunur; veri bir BOM ile başlıyorsa UTF‑16 olarak okunur.

Örnek:

```csv
title;price;description
Laptop X1;$999;"14"" display; 16 GB RAM"
Tablet S2;$499;
```

### XLSX

XLSX verisi, ilk çalışma sayfasından okunur.

Çalışma sayfası, CSV ile aynı kuralları izler:

- İlk satır alan adlarını içerir ve ilk boş hücrede sona erer.
- Her sonraki satır bir veri kümesini temsil eder.
- Veri, ilk boş satırda sona erer.
- Boş hücreler boş dize olarak değerlendirilir.
- Sayısal değerler, değişmez kültür (invariant culture) kullanılarak metne dönüştürülür.

## Tek Bir Sunum Oluşturma

`MergeToSinglePresentation` yöntemi, her veri kümesi için şablon slaytlarının bir kopyasını içeren tek bir sunum oluşturur. Her kopya, ilgili verilerle doldurulur.

Veri kümesi sırası, sonuç sunumundaki slayt gruplarının sırasını belirler.

### Dosyadan Veri Birleştirme

Aşağıdaki örnek, bir şablon ve bir JSON veri dosyası yükler, tüm veri kümeleri için slaytları içeren tek bir sunum oluşturur ve sonucu kaydeder.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, "products.json"))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

Veri ayrıca bir akıştan da okunabilir. Akış, mevcut konumundan itibaren okunur ve Posta Birleştirme işlemi tarafından kapatılmaz.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Stream data = File.OpenRead("products.xml"))
using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, data))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

### Kod içinde Veri Kaynağı Oluşturma

`MailMergeDataSource` ve `MailMergeDataSet` kullanarak veri kaynağını programlı olarak oluşturabilirsiniz. Her kayıt için bir veri kümesi ekleyin ve alanlarını `AddText` yöntemiyle tanımlayın.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet laptop = source.AddDataSet();
laptop.AddText("title", "Laptop X1");
laptop.AddText("price", "$999");

IMailMergeDataSet tablet = source.AddDataSet();
tablet.AddText("title", "Tablet S2");
tablet.AddText("price", "$499");

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, source))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

Bu örnekte şablon slaytları iki kez tekrarlanır: bir kez laptop için, bir kez tablet için. Yer tutucular, her veri kümesinde tanımlı değerlerle doldurulur.

## Çoka Sunum Oluşturma

Her veri kümesi için ayrı bir sunum gerekiyorsa `MergeToMultiplePresentations` yöntemini kullanın.

Bu yöntem, veri kümelerini tek tek işler, şablondan bir sunum oluşturur, mevcut veri ile doldurur ve sonuç sunumu bir işleyiciye (handler) verir.

İşleyici, orijinal veri sırasına göre her veri kümesi için bir kez tetiklenir.

### Her Sunumu Kaydetme

Aşağıdaki örnek, bir CSV dosyasından veri okur ve oluşturulan her sunumu ayrı bir dosya olarak kaydeder.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.csv",
        (presentation, args) =>
        {
            presentation.Save(
                "product_" + (args.Index + 1) + ".pptx",
                SaveFormat.Pptx);
        });
}
```

`args.Index` özelliği, mevcut veri kümesinin sıfır tabanlı indeksini sağlar. Örnekte, bu indeks `product_1.pptx` gibi ardışık dosya adları oluşturmak için kullanılır.

Veri ayrıca bir akıştan da okunabilir:

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Stream data = File.OpenRead("products.xlsx"))
using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        data,
        (presentation, args) =>
        {
            presentation.Save(
                "product_" + (args.Index + 1) + ".pptx",
                SaveFormat.Pptx);
        });
}
```

### Dosya Adı Oluşturmak için Veri Kümesi Değerlerini Kullanma

İşleyici, oluşturulan sunumu ve onu oluşturmak için kullanılan veri kümesi bilgilerini alır. Veri kümesi değerlerini kullanarak anlamlı dosya adları oluşturabilirsiniz.

Aşağıdaki kod, her sunumu ürün başlığıyla kaydeder:

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.json",
        (presentation, args) =>
        {
            string title = args.DataSet.GetText("title");
            string fileName = title != null
                ? title
                : "product_" + (args.Index + 1);

            presentation.Save(fileName + ".pptx", SaveFormat.Pptx);
        });
}
```

`DataSet` özelliği, mevcut sunumu dolduran veri kümesini döndürür. `GetText` yöntemi, belirtilen alanın değerini alır; alan yoksa `null` döner.

Bu sayede dosya adları oluşturma, çıktı düzenleme veya işleyicide ek işlemler uygulama gibi senaryoları gerçekleştirebilirsiniz.

## Oluşturulan Sunumların İşlenmesi

`MergeToMultiplePresentations`, her oluşturulan sunumu işlemek için `MailMergedPresentationHandler` temsilcisini kullanır.

İşleyici iki parametre alır:

- `presentation` — şablondan oluşturulmuş ve mevcut veri kümesi ile doldurulmuş sunum.
- `args` — oluşturulan sunum hakkında veri kümesi indeksi ve veri kümesi gibi bilgileri içeren nesne.

Oluşturulan sunum, Posta Birleştirme işlemi tarafından sahiplenilir ve işleyici döndükten hemen sonra serbest bırakılır. Bu nedenle, işleyici içinde kaydetmeniz veya ihtiyacınız olan verileri kopyalamanız gerekir; işleyici döndükten sonra sunuma bir referans tutmayın ve elle serbest bırakmayın.

İşleyici, çağıran iş parçacığında, bir seferde bir sunum olacak şekilde, veri kümesi sırasına göre çalıştırılır. Aynı anda yalnız bir oluşturulan sunum bellek içinde tutulur; bu, büyük veri kaynaklarını tüm sunumları aynı anda bellekte tutmadan işlemek için uygundur.

İşleyici bir istisna fırlatırsa, Posta Birleştirme işlemi durur ve istisna değişmeden çağırana iletilir. Halihazırda işlenmiş sunumlar etkilenmez; kalan veri kümeleri işlenmez.

Aşağıdaki örnek, oluşturulan sunumları özel bir klasöre kaydeder:

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

string outputFolder = "output";
Directory.CreateDirectory(outputFolder);

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.json",
        (presentation, args) =>
        {
            string path = Path.Combine(
                outputFolder,
                "product_" + (args.Index + 1) + ".pptx");

            presentation.Save(path, SaveFormat.Pptx);
        });
}
```

## Posta Birleştirme Verileriyle Çalışma

`MailMergeDataSource` sınıfı, sıralı bir veri kümesi koleksiyonunu temsil eder. Kod içinde veri oluşturmak, veri kümesi sayısını incelemek ve belirli bir indeksle veri kümesine erişmek için kullanılabilir.

### Veri Kümesi Sayısını Alma

`Count` özelliği, kaynakta bulunan veri kümesi sayısını döndürür.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine("Presentations to create: " + source.Count);
```

### İndekse Göre Veri Kümesine Erişim

`Item(int)` özelliği, belirtilen sıfır tabanlı indeksdeki veri kümesine erişim sağlar.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine(source[1].GetText("title"));
```

Bu örnek, ikinci veri kümesinin başlığını alır.

### Metin Alanları Ekleme

`AddText` yöntemi, bir veri kümesine adlandırılmış bir metin alanı ekler. Alan değeri, şablondaki eşleşen tüm yer tutucuları değiştirir.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet dataSet = source.AddDataSet();
dataSet.AddText("title", "Laptop X1");
dataSet.AddText("subtitle", string.Empty);
```

Boş bir değer, sonuç metinden ilgili yer tutucuyu kaldırır. Alan veri kümesine eklenmemişse, yer tutucu değişmeden kalır.

### Metin Alanlarını Okuma

`GetText` yöntemi, bir alanın değerini ad ile getirir. Alan adları büyük/küçük harfe duyarsızdır.

```csharp
IMailMergeDataSet dataSet = source[0];

string title = dataSet.GetText("title");
string price = dataSet.GetText("price");
```

Alan bulunamazsa veya belirtilen alan adı `null` ise, `GetText` `null` döndürür.

## Özet

Aspose.Slides for .NET’te Posta Birleştirme, yeniden kullanılabilir bir şablondan veri odaklı sunumlar oluşturmanın pratik bir yolunu sunar.

Bunu şunlar için kullanabilirsiniz:

- Sunum şablonlarını veri kaynaklarındaki değerlerle doldurmak.
- Birden çok veri kümesi için tekrarlanan şablon slaytlarını içeren tek bir sunum üretmek.
- Her veri kümesi için ayrı bir sunum oluşturmak.
- CSV, XLSX, JSON ve XML dosyalarından veya akışlarından veri okumak.
- Veri kaynaklarını doğrudan kod içinde inşa etmek.
- Oluşturulan sunumları bir işleyici kullanarak sıralı şekilde işlemek ve kaydetmek.

Yeniden kullanılabilir şablonları yapılandırılmış veriyle birleştirerek, şablon tasarımını ve veri işleme mantığını ayrı tutarak büyük sayıda sunumu otomatikleştirebilirsiniz.

## Sık Sorulan Sorular

### Aynı yer tutucuyu bir şablonda birden çok kez kullanabilir miyim?

Evet. Aynı alan adına sahip her yer tutucu, mevcut veri kümesindeki karşılık gelen değerle değiştirilir.

### Alan adları büyük/küçük harfe duyarlı mı?

Hayır. Yer tutucu ve veri alan adları büyük/küçük harfe duyarsızdır. Örneğin `{{title}}`, `{{Title}}` ve `{{TITLE}}` aynı alanı ifade eder.

### Bir alan veri kümesinde eksikse ne olur?

Bir veri kümesi, yer tutucu tarafından başvurulan bir alanı içermiyorsa, o yer tutucu oluşturulan sunumda değişmeden kalır.

### Bir alanın değeri boş ise ne olur?

Boş bir alan değeri, yer tutucuyu boş bir dizeyle değiştirir. Yer tutucu metni kaldırılır ve yerine hiçbir metin yer almaz.

### Yer tutucunun biçimlendirmesini koruyabilir miyim?

Değiştirilen metin, yer tutucunun ilk karakterinin biçimlendirmesini devralır. Birleştirme işleminden önce şablondaki yer tutucu metnine istediğiniz biçimlendirmeyi uygulayın.

### Posta Birleştirme, ana slaytlarda veya yerleşim slaytlarında yer tutucuları değiştirir mi?

Hayır. Posta Birleştirme, desteklenen içeriklerde (şekiller, gruplanmış şekiller, tablo hücreleri ve konuşmacı notları) yer tutucuları değiştirir. Ana ve yerleşim slaytlarındaki yer tutucular değiştirilmez.

### Şablon sunumu birleştirme sırasında değiştiriliyor mu?

Hayır. Orijinal şablon birleştirme işlemi tarafından değiştirilmez. Aynı veya farklı veri kaynaklarıyla birden çok sunum üretmek için tekrar kullanılabilir.

### Her veri kümesi için ayrı bir sunum oluşturabilir miyim?

Evet. `MergeToMultiplePresentations` yöntemini kullanın ve her oluşturulan sunumu işleyicide kaydedin. İşleyici, her veri kümesi için sırasıyla çağrılır.

### Tüm veri kümelerini tek bir sunumda birleştirebilir miyim?

Evet. `MergeToSinglePresentation` yöntemini kullanın. Bu yöntem, veri kaynağı sırasına göre her veri kümesi için şablon slaytlarının bir kopyasını içeren tek bir çıktı sunumu oluşturur.

### Veri kaynağını dosyaya kaydetmeden kullanabilir miyim?

Evet. `MailMergeDataSource` nesnesini kod içinde yaratabilir, veri kümeleri ekleyebilir ve `AddText` ile alanları doldurabilirsiniz. Bu, veriniz zaten uygulamanızda mevcut olduğunda faydalıdır.

### Veri formatı dosya uzantısından mı belirleniyor?

Hayır. Veri formatı, içeriğe göre tespit edilir; bu nedenle desteklenen bir veri kaynağı belirli bir dosya uzantısına sahip olmak zorunda değildir.

### Arama (seeking) desteklemeyen bir akışı okuyabilir miyim?

Evet. Posta Birleştirme, arama desteklemeyen akışları da destekler.

### Veri kaynağı boş veya veri kümesi içermiyorsa ne olur?

Veri kaynağı en az bir veri kümesi içermelidir. Birleştirme işlemine başlamadan önce en az bir kayıt eklediğinizden emin olun.

### Veri kaynağının formatı geçersizse ne olur?

İçerik, desteklenen veri formatlarından biri olarak tanınmazsa `NotSupportedException` fırlatılır. Tanınır ancak biçim hatalıysa `InvalidDataException` fırlatılır. İstisna mesajı, hatanın konumuyla ilgili bilgileri içerir.

### Oluşturulan sunumu işleyici döndükten sonra kullanabilir miyim?

`MergeToMultiplePresentations` işleyicisine verilen sunum, Posta Birleştirme tarafından sahiplenilir ve işleyici döndükten sonra serbest bırakılır. Sunumu kaydedin veya ihtiyaç duyduğunuz veriyi işleyici içinde kopyalayın; işleyici döndükten sonra sunuma bir referans tutmayın ve elle serbest bırakmayın.

### İşleyici paralel olarak çalıştırılıyor mu?

Hayır. Oluşturulan sunumlar, çağıran iş parçacığında, sırayla, bir seferde bir sunum olacak şekilde işlenir. Bu işlem, aynı anda yalnız bir oluşturulan sunumun bellekte tutulmasını sağlar.

### İşleyici içinde bir istisna oluşursa ne olur?

Birleştirme işlemi durur ve istisna değişmeden çağırana iletilir. Halihazırda işlenmiş sunumlar etkilenmez; kalan veri kümeleri işlenmez.

### Alan değerlerini çıktı dosya adları oluşturmak için kullanabilir miyim?

Evet. İşleyici, mevcut veri kümesini argümanlarıyla sağlar. `GetText` ile alanları alıp her oluşturulan sunum için bir dosya adı oluşturabilirsiniz. Değerlerin hedef ortamda dosya adı için geçerli olduğundan emin olun.