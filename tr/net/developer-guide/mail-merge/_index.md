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
- metin yer tutucuları
- veri kaynağı
- CSV
- Excel
- XLSX
- JSON
- XML
- birleştirme verileri
- sunum oluşturma
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET içinde Mail Birleştirme'yi kullanarak sunum şablonlarını veriyle doldurmayı ve CSV, Excel, JSON ve XML kaynaklarından kişiselleştirilmiş PowerPoint sunumları oluşturmayı öğrenin."
---
## **PowerPoint Sunumlarında Mail Birleştirme**

Aspose.Slides for .NET, bir şablon ve veri kaynağı kullanarak PowerPoint sunumlarını otomatik olarak oluşturmanıza olanak tanır. Mail Birleştirme, şablon yer tutucularını veri ile doldurur ve her veri kümesi için şablon slaytlarının tekrarlı olduğu tek bir sunum ya da her veri kümesi için ayrı bir sunum oluşturur.

Bu işlevsellik, ürün katalogları, kişiselleştirilmiş sunumlar, raporlar, sertifikalar, tekliflerin, fiyat listelerinin ve içeriğin değiştiği ancak sunum yapısının aynı kaldığı diğer belgelerin oluşturulması için faydalıdır.

![Mail Birleştirme: önce ve sonra](mail-merge-before-after.png)


## **Mail Birleştirme Nasıl Çalışır**

Mail Birleştirme, bir PowerPoint sunumunu şablon olarak kullanır ve yer tutucuları veri kaynağından gelen değerlerle değiştirir.

![Mail Birleştirme iş akışı](mail-merge-workflow.png)

Yer tutucu, çift süslü parantez içinde bulunan bir alan adıdır; örneğin `{{title}}` veya `{{price}}`. Yer tutucular, şekillerdeki metinlerde, tablo hücrelerinde, gruplanmış şekillerde ve konuşmacı notlarında yer alabilir.

Örneğin bir şablon slaytı aşağıdaki metni içerebilir:

- `Ürün: {{title}}`
- `Fiyat: {{price}}`
- `Açıklama: {{description}}`

Veri kaynağı aşağıdaki değerleri içerdiğinde:

| Alan | Değer |
|---|---|
| title | Laptop X1 |
| price | $999 |
| description | 14 inç ekran, 16 GB RAM |

Mail Birleştirme, yer tutucuları karşılık gelen değerlerle değiştirir ve gerçek ürün bilgileriyle bir slayt oluşturur.

Alan adları büyük/küçük harfe duyarsızdır, bu nedenle `{{title}}` ve `{{Title}}` aynı alana işaret eder.

Yer tutucular değiştirildiğinde aşağıdaki kurallar geçerlidir:

- Yer tutucular, slaytlarda, gruplanmış şekillerde ve tablo hücrelerinde ve konuşmacı notlarında değiştirilir.
- Ana slaytlardaki ve yerleşim slaytlarındaki yer tutucular değiştirilmez.
- Veri kümesinde bulunmayan bir alanın yer tutucusu değişmeden kalır.
- Boş bir alan değeri, yer tutucusunu boş bir dizeyle değiştirir.
- Ekleilen metin, yer tutucunun ilk karakterinin biçimlendirmesini devralır.
- Değerler, yer tutucu metni içermemelidir; çünkü eklenen metin tekrar işlenip başka bir alanla değiştirilebilir.

Orijinal şablon sunumu, birleştirme işlemi sırasında değiştirilmez ve en az bir slayt içermelidir.

## **Desteklenen Veri Kaynakları**

Mail Birleştirme, veriyi sağlamak için iki yöntem destekler:

- Programmatically `IMailMergeDataSource` kullanarak bir veri kaynağı oluşturun.
- CSV, XLSX, JSON veya XML dosyasından ya da akışından verileri okuyun.

Veri formatı, dosya uzantısına değil, içeriğine göre tespit edilir. Arama (seek) desteklemeyen akışlar da desteklenir.

Veri kaynağı en az bir veri kümesi içermelidir. Her veri kümesi, şablonun değerleriyle doldurulacak bir kopyasını temsil eder.

Veri içeriği desteklenen bir format olarak tanımlanamazsa `NotSupportedException` istisnası fırlatılır. İçerik tanımlanır ancak format gereksinimlerine uymuyorsa `InvalidDataException` istisnası fırlatılır. İstisna mesajı, verideki hatanın konumunu içerir.

### **JSON**

JSON veri kaynağı, `sets` dizisini içeren bir kök nesneye sahip olmalıdır. Dizinin her öğesi bir veri kümesini temsil eder ve bir `fields` dizisi içermelidir. Her alanın bir `name` ve bir `value` dizesi olmalıdır.

Opsiyonel `version` özelliği `"1.0"` olmalı ve bir alanın opsiyonel `type` özelliği `"text"` olmalıdır. Özellik adları büyük/küçük harfe duyarlıdır. Bilinmeyen özellikler yoksayılır.

JSON verileri UTF-8 olarak okunur, veri bir bayt sırası işareti (BOM) ile başlıyorsa UTF-16 olarak okunur.

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

### **XML**

XML veri kaynağı, `sets` öğesini içeren bir `template` kök öğesine sahip olmalıdır. Her `set` öğesi `field` öğeleri içerir ve her alan `name` ve `value` öğelerini içermelidir.

Boş bir `value` öğesi boş bir dize olarak değerlendirilir. Öğenin adları büyük/küçük harfe duyarlıdır. Bilinmeyen öğeler ve yorumlar yoksayılır. Kodlama, XML deklarasyonu tarafından belirlenir. Belge türü tanımlamaları (DTD) izin verilmez.

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

### **CSV**

CSV verileri, değer ayırıcıları olarak noktalı virgül kullanır.

İlk satır alan adlarını içerir ve ilk boş alan adında sona erer. Her sonraki satır bir veri kümesini temsil eder. Veri, ilk boş satırda sona erer.

Aşağıdaki kurallar geçerlidir:

- Bir satırın sonunda eksik değerler boş dize olarak kabul edilir.
- Tanımlı alan adlarının ötesindeki değerler yoksayılır.
- Noktalı virgül, tırnak işareti veya satır sonu içeren bir değer tırnak işaretleri içinde olmalıdır.
- Tırnak içinde bir tırnak işareti iki kez yazılmalıdır.
- Veri UTF-8 olarak okunur, başlangıçta bir bayt sırası işareti (BOM) varsa UTF-16 olarak okunur.

Örnek:

```csv
title;price;description
Laptop X1;$999;"14"" display; 16 GB RAM"
Tablet S2;$499;
```

### **XLSX**

XLSX verileri ilk çalışma sayfasından okunur.

Çalışma sayfası, CSV ile aynı kuralları izler:

- İlk satır alan adlarını içerir ve ilk boş hücrede sona erer.
- Her sonraki satır bir veri kümesini temsil eder.
- Veri, ilk boş satırda sona erer.
- Boş hücreler boş dize olarak kabul edilir.
- Sayısal değerler, değişmez kültür kullanılarak metne dönüştürülür.

## **Tek Sunum Oluşturma**

`MergeToSinglePresentation` yöntemi, her veri kümesi için şablon slaytlarının bir kopyasını içeren tek bir sunum oluşturur. Her kopya, ilgili veri ile doldurulur.

Veri kümelerinin sırası, oluşturulan sunumdaki slayt gruplarının sırasını belirler.

### **Dosyadan Veri Birleştirme**

Aşağıdaki örnek bir şablon ve bir JSON veri dosyası yükler, tüm veri kümeleri için slaytları içeren tek bir sunum oluşturur ve sonucu kaydeder.

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

Veri ayrıca bir akıştan da okunabilir. Akış, mevcut konumundan itibaren okunur ve Mail Birleştirme işlemi tarafından kapatılmaz.

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

### **Kod İçinde Veri Kaynağı Oluşturma**

`MailMergeDataSource` ve `MailMergeDataSet` kullanarak programlı olarak bir veri kaynağı oluşturabilirsiniz. Her kayıt için bir veri kümesi ekleyin ve `AddText` yöntemiyle alanlarını tanımlayın.

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

Bu örnekte, şablon slaytları iki kez tekrarlanır: bir kez laptop için, bir kez tablet için. Yer tutucular, her veri kümesinde tanımlanan değerlerle doldurulur.

## **Birden Çok Sunum Oluşturma**

Her veri kümesi için ayrı bir sunuma ihtiyacınız varsa `MergeToMultiplePresentations` yöntemini kullanın.

Bu yöntem, veri kümelerini tek tek işler, şablondan bir sunum oluşturur, geçerli verilerle doldurur ve ortaya çıkan sunumu bir işleyiciye iletir.

İşleyici, orijinal veri sırasına göre her veri kümesi için bir kez çalıştırılır.

### **Her Sunumu Kaydetme**

Aşağıdaki örnek bir CSV dosyasından veri okur ve her oluşturulan sunumu ayrı bir dosya olarak kaydeder.

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

`args.Index` özelliği, geçerli veri kümesinin sıfır tabanlı dizinini sağlar. Örnekte, `product_1.pptx`'ten başlayarak sıralı dosya adları oluşturmak için kullanılır.

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

### **Dosya Adı İçin Veri Kümesi Değerlerini Kullanma**

İşleyici, oluşturulan sunumu ve onu oluşturmak için kullanılan veri kümesi hakkında bilgiyi alır. Veri kümesi değerlerini, anlamlı dosya adları oluşturmak için kullanabilirsiniz.

Örneğin, aşağıdaki kod her sunumu ürün başlığını kullanarak kaydeder:

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

`DataSet` özelliği, geçerli sunumu doldurmak için kullanılan veri kümesini döndürür. `GetText` yöntemi belirtilen alanın değerini alır; alan mevcut değilse `null` döner.

Bu, dosya adlandırma, çıktıyı düzenleme veya işleyicide ek işlem uygulama için veri değerlerini kullanmanıza olanak tanır.

## **Oluşturulan Sunumların İşlenmesi**

`MergeToMultiplePresentations`, her oluşturulan sunumu işlemek için `MailMergedPresentationHandler` temsilcisini kullanır.

İşleyici iki argüman alır:

- `presentation` — şablondan oluşturulan ve geçerli veri kümesiyle doldurulan sunum.
- `args` — oluşturulan sunumla ilgili bilgi, veri kümesi dizini ve veri kümesinin kendisini içerir.

Oluşturulan sunum, Mail Birleştirme işlemi tarafından sahiplenilir ve işleyici döndükten hemen sonra bellekten temizlenir. Bu nedenle, onu işleyici içinde kaydetmeli veya gerekli verileri kopyalamalısınız. İşleyici döndükten sonra bir referans tutmayın ve elle temizlemeyin.

İşleyici, çağıran iş parçacığında, veri kümeleri sırasına göre bir seferde bir sunum olarak yürütülür. Aynı anda yalnızca bir oluşturulan sunum bellek içinde tutulur; bu yaklaşım, tüm oluşturulan sunumları aynı anda bellekte tutmadan büyük veri kaynaklarını işlemek için uygundur.

İşleyici bir istisna fırlatırsa, Mail Birleştirme işlemi durur ve istisna değişmeden çağırana iletilir. Daha önce işlenen sunumlar etkilenmez ve kalan veri kümeleri işlenmez.

Aşağıdaki örnek oluşturulan sunumları özel bir dizine kaydeder:

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

## **Mail Birleştirme Verileriyle Çalışma**

`MailMergeDataSource` sınıfı, sıralı bir veri kümesi koleksiyonunu temsil eder. Kod içinde veri oluşturmak, veri kümesi sayısını incelemek ve indeksle bireysel veri kümelerine erişmek için kullanılabilir.

### **Veri Kümesi Sayısını Alma**

`Count` özelliği, kaynaktaki veri kümesi sayısını döndürür.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine("Presentations to create: " + source.Count);
```

### **İndeksle Veri Kümesine Erişme**

`Item(int)` özelliği, belirtilen sıfır tabanlı indeksteki veri kümesine erişim sağlar.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine(source[1].GetText("title"));
```

Bu örnek, ikinci veri kümesinin başlığını alır.

### **Metin Alanları Ekleme**

`AddText` yöntemi, bir veri kümesine adlandırılmış bir metin alanı ekler. Alan değeri, şablondaki eşleşen tüm yer tutucuları değiştirir.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet dataSet = source.AddDataSet();
dataSet.AddText("title", "Laptop X1");
dataSet.AddText("subtitle", string.Empty);
```

Boş bir değer, karşılık gelen yer tutucuyu sonuç metninden kaldırır. Alan veri kümesine eklenmemişse, yer tutucu değişmeden kalır.

### **Metin Alanlarını Okuma**

`GetText` yöntemi, bir alanın değerini adından alır. Alan adları büyük/küçük harfe duyarsızdır.

```csharp
IMailMergeDataSet dataSet = source[0];

string title = dataSet.GetText("title");
string price = dataSet.GetText("price");
```

Alan mevcut değilse veya belirtilen alan adı `null` ise, `GetText` `null` döndürür.

## **Özet**

Aspose.Slides for .NET içindeki Mail Birleştirme, yeniden kullanılabilir bir şablondan veri odaklı sunumlar oluşturmanın kullanışlı bir yolunu sunar.

- Sunum şablonlarını veri kaynaklarından gelen değerlerle doldurun.
- Birden çok veri kümesi için tekrarlanan şablon slaytlarını içeren tek bir sunum oluşturun.
- Her veri kümesi için ayrı bir sunum oluşturun.
- CSV, XLSX, JSON ve XML dosyalarından veya akışlarından veri okuyun.
- Veri kaynaklarını doğrudan kod içinde oluşturun.
- Oluşturulan sunumları bir işleyici kullanarak ardışık olarak işleyin ve kaydedin.

Yeniden kullanılabilir şablonları yapılandırılmış veriyle birleştirerek, şablon tasarımını ve veri işleme mantığını ayrı tutarken büyük sayıda sunumun oluşturulmasını otomatikleştirebilirsiniz.

## **Sık Sorulan Sorular**

**Aynı yer tutucuyu bir şablonda birden fazla kez kullanabilir miyim?**

Evet. Eşleşen alan adına sahip yer tutucunun her tekrarı, geçerli veri kümesindeki karşılık gelen değerle değiştirilir.

**Alan adları büyük/küçük harfe duyarlı mı?**

Hayır. Yer tutucu ve veri alan adları büyük/küçük harfe duyarsızdır. Örneğin, `{{title}}`, `{{Title}}` ve `{{TITLE}}` aynı alanı ifade eder.

**Bir alan veri kümesinde eksik olursa ne olur?**

Veri kümesi, bir yer tutucu tarafından referans edilen bir alanı içermiyorsa, o yer tutucu oluşturulan sunumda değişmeden kalır.

**Bir alanın değeri boş ise ne olur?**

Boş bir alan değeri, yer tutucuyu boş bir dizeyle değiştirir. Yer tutucu metni kaldırılır ve yerinde hiç metin kalmaz.

**Yer tutucuyu değiştirirken biçimini koruyabilir miyim?**

Değiştirilen metin, yer tutucunun ilk karakterinin biçimlendirmesini devralır. Birleştirmeyi yapmadan önce şablondaki yer tutucu metnine istediğiniz biçimlendirmeyi uygulayın.

**Mail Birleştirme, ana slaytlar veya yerleşim slaytlarındaki yer tutucuları değiştirir mi?**

Hayır. Mail Birleştirme, slaytlardaki desteklenen içeriklerde (şekiller, gruplanmış şekiller, tablo hücreleri ve konuşmacı notları) yer tutucuları değiştirir. Ana ve yerleşim slaytlarındaki yer tutucular değiştirilmez.

**Birleştirme sırasında şablon sunumu değiştirilir mi?**

Hayır. Orijinal şablon birleştirme işlemi tarafından değiştirilmez. Aynı ya da farklı veri kaynaklarından sunumlar oluşturmak için yeniden kullanılabilir.

**Her veri kümesi için ayrı bir sunum oluşturabilir miyim?**

Evet. `MergeToMultiplePresentations` yöntemini kullanın ve her oluşturulan sunumu işleyicinin içinde kaydedin. İşleyici, her veri kümesi için sıralı olarak çağrılır.

**Tüm veri kümelerini tek bir sunumda birleştirebilir miyim?**

Evet. `MergeToSinglePresentation` yöntemini kullanın. Bu, veri kaynağı sırasına göre her veri kümesi için şablon slaytlarının bir kopyasını içeren tek bir çıktı sunumu oluşturur.

**Veri kaynağını bir dosyaya kaydetmeden kullanabilir miyim?**

Evet. Kod içinde bir `MailMergeDataSource` oluşturabilir, veri kümeleri ekleyebilir ve `AddText` kullanarak alanları doldurabilirsiniz. Bu, veriniz uygulamanızda zaten mevcut olduğunda faydalıdır.

**Mail Birleştirme, dosya uzantısından veri formatını tespit eder mi?**

Hayır. Veri formatı içeriğe göre tespit edilir; bu nedenle desteklenen bir veri kaynağının belirli bir dosya uzantısı kullanması gerekmez.

**Arama (seek) desteklemeyen bir akıştan veri okuyabilir miyim?**

Evet. Mail Birleştirme, arama (seek) desteklemeyen akışları destekler.

**Veri kaynağı boş ya da veri kümesi içermiyorsa ne olur?**

Veri kaynağı en az bir veri kümesi içermelidir. Birleştirme işlemine başlamadan önce en az bir kayıt içerdiğinden emin olun.

**Veri kaynağının formatı geçersizse ne olur?**

İçerik, desteklenen veri formatlarından biri olarak tanımlanamazsa `NotSupportedException` istisnası fırlatılır. Tanımlanır ancak biçim hatalıysa `InvalidDataException` istisnası fırlatılır. İstisna mesajı, hatanın konumu hakkında bilgi içerir.

**İşleyici döndükten sonra oluşturulan sunumu kullanabilir miyim?**

`MergeToMultiplePresentations` işleyicisine geçirilen sunum, Mail Birleştirme tarafından sahiplenilir ve işleyici döndükten sonra bellekten temizlenir. İşleyici içinde kaydedin ya da ihtiyacınız olan içeriği kopyalayın; sunumu kendiniz tutmayın ya da elle temizlemeyin.

**İşleyici paralel olarak çağrılıyor mu?**

Hayır. Oluşturulan sunumlar, çağıran iş parçacığında, sıralı olarak işlenir. Bu işlem, aynı anda yalnızca bir oluşturulan sunumu bellek içinde tutar.

**İşleyici içinde bir istisna oluşursa ne olur?**

Birleştirme işlemi durur ve istisna değişmeden çağırana iletilir. Daha önce işlenen sunumlar etkilenmez ve sonraki veri kümeleri işlenmez.

**Alan değerlerini çıktı dosya adları oluşturmak için kullanabilir miyim?**

Evet. İşleyici, mevcut veri kümesini argümanları aracılığıyla sağlar. `GetText` kullanarak alanları alıp her oluşturulan sunum için bir dosya adı oluşturabilirsiniz. Değerlerin, hedef ortamınızda geçerli dosya adları olduğundan emin olun.