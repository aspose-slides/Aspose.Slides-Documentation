---
title: PowerPoint Sunumlarında .NET ile Metin Alanlarını Yönetme
linktitle: Metin Alanları
type: docs
weight: 52
url: /tr/net/text-fields/
keywords:
- metin alanı
- otomatik metin
- slayt numarası
- tarih ve saat
- üst bilgi
- alt bilgi
- metin bölümü
- PowerPoint
- PPT
- PPTX
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint sunumlarında metin alanlarını oluşturun, inceleyin, değiştirin ve kaldırın. Biçimlendirmeyi koruyun ve kaydedilen PPTX ve PPT dosyalarını doğrulayın."
---
## **Genel Bakış**

Bir metin paragrafı bölümlerden oluşur. Normal bir [IPortion](https://reference.aspose.com/slides/tr/net/aspose.slides/iportion/) düz metin içerir; bir alan bölümü ayrıca bir [IField](https://reference.aspose.com/slides/tr/net/aspose.slides/ifield/) içerir ve bu alanın türü slayt numarası veya tarih gibi otomatik güncellenen bir değeri tanımlar. İki bölüm aynı karakterleri gösterebilir ancak yalnızca birinde alan bulunur.

Bunları ayırt etmek için [IPortion.Field](https://reference.aspose.com/slides/tr/net/aspose.slides/iportion/field/) kullanın: normal metin için `null` olur. [IPortion.AddField](https://reference.aspose.com/slides/tr/net/aspose.slides/iportion/addfield/) mevcut bir bölümü alana dönüştürür. Etiketi ve dinamik değerini ayrı bölümlerde tutun, böylece değeri dönüştürmek etiketin de değiştirilmesine yol açmaz.

Bu kılavuz, metin içindeki alanları, biçimlendirmelerini ve PPTX ve PPT olarak kaydedilmesini ele alır. Metin çerçeveleri ve paragraflar için [Manage Text](/slides/tr/net/manage-text/) bölümüne bakın.

## **Slayt Numarası Alanı Oluşturma**

Aşağıdaki tam örnek, `Slide ` etiketiyle başlayan ve ardından otomatik güncellenen bir sayı içeren bir metin kutusu oluşturur. Alanı eklemeden önce sayının boyutunu, kalınlığını ve rengini ayarlar, ardından kaydedilen sunumu yeniden açar ve alan türünü, metni ve biçimlendirmeyi kontrol eder. Giriş dosyası gerekmez.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
shape.AddTextFrame("Slide ");
var paragraph = shape.TextFrame.Paragraphs[0];

var numberPortion = new Portion();
numberPortion.PortionFormat.FontHeight = 24;
numberPortion.PortionFormat.FontBold = NullableBool.True;
numberPortion.PortionFormat.FillFormat.FillType = FillType.Solid;
numberPortion.PortionFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
paragraph.Portions.Add(numberPortion);
numberPortion.AddField(FieldType.SlideNumber);

presentation.Save("slide_number.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("slide_number.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedNumber = savedShape.TextFrame.Paragraphs[0].Portions[1];
var hasNumberField = savedNumber.Field?.Type.InternalString == FieldType.SlideNumber.InternalString;
var format = savedNumber.PortionFormat;
var formattingPreserved = format.FontHeight == 24 && format.FontBold == NullableBool.True;
formattingPreserved &= format.FillFormat.SolidFillColor.Color.ToArgb() == Color.DarkBlue.ToArgb();

Console.WriteLine($"Text: {savedShape.TextFrame.Text}");
Console.WriteLine($"Slide number field: {hasNumberField}");
Console.WriteLine($"Formatting preserved: {formattingPreserved}");
```

Yeni sunum slayt numarası 1 ile başlar, bu yüzden metin `Slide 1` olur ve iki kontrol de `True` yazar. Sayı yeniden açıldıktan sonra da alan olarak kalır; düz `1` değildir. Doğrulamadaki dönüşümler ve indeksler, bu örnek tarafından oluşturulan şekil ve bölümlere referans verir.

## **Bir Alan Türü Seçme**

[FieldType](https://reference.aspose.com/slides/tr/net/aspose.slides/fieldtype/) [IFieldType](https://reference.aspose.com/slides/tr/net/aspose.slides/ifieldtype/) uygular ve aşağıdaki önceden tanımlı değerleri sağlar. [AddField](https://reference.aspose.com/slides/tr/net/aspose.slides/iportion/addfield/) yöntemine uygun değeri geçirin.

| Değer | Amaç |
|---|---|
| [SlideNumber](https://reference.aspose.com/slides/tr/net/aspose.slides/fieldtype/slidenumber/) | Mevcut slayt numarası. |
| [DateTime](https://reference.aspose.com/slides/tr/net/aspose.slides/fieldtype/datetime/) | İşleme uygulamasının varsayılan biçimindeki tarih/saat. |
| [DateTime1](https://reference.aspose.com/slides/tr/net/aspose.slides/fieldtype/datetime1/)–[DateTime9](https://reference.aspose.com/slides/tr/net/aspose.slides/fieldtype/datetime9/) | Önceden tanımlı tarih veya birleştirilmiş tarih/saat biçimleri. |
| [DateTime10](https://reference.aspose.com/slides/tr/net/aspose.slides/fieldtype/datetime10/)–[DateTime13](https://reference.aspose.com/slides/tr/net/aspose.slides/fieldtype/datetime13/) | Önceden tanımlı saat biçimleri, saniye ve 12‑saatli saat seçenekleriyle. |
| [Header](https://reference.aspose.com/slides/tr/net/aspose.slides/fieldtype/header/) | Üst bilgi alanı; aşağıdaki yer tutucu ve biçim sınırlamalarına bakın. |
| [Footer](https://reference.aspose.com/slides/tr/net/aspose.slides/fieldtype/footer/) | Alt bilgi alanı. |

Örneğin, [DateTime3](https://reference.aspose.com/slides/tr/net/aspose.slides/fieldtype/datetime3/) bir günü, tam ay adını ve yılı İngilizce olarak temsil eder. Bunlar önceden tanımlı alan biçimleridir, rastgele .NET tarih‑biçim dizgeleri değildir. Bölümün [LanguageId](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseportionformat/languageid/) ve sunumu işleyen uygulama gösterilen sonucu etkileyebilir.

## **Dahili Bir Dizeyle Alan Oluşturma**

[AddField](https://reference.aspose.com/slides/tr/net/aspose.slides/iportion/addfield/) yönteminin dize aşırı yüklemesi dahili bir alan tanımlayıcısı alır. Başka bir uygulama tarafından sağlanan ve önceden tanımlı bir değeri olmayan bir tanımlayıcıyı korurken kullanın. Ayrıca tanımlayıcıdan bir [FieldType](https://reference.aspose.com/slides/tr/net/aspose.slides/fieldtype/fieldtype/) oluşturabilirsiniz. [IFieldType.InternalString](https://reference.aspose.com/slides/tr/net/aspose.slides/ifieldtype/internalstring/) bu tanımlayıcıyı inceleme amaçlı ortaya çıkarır.

Bu örnek, geri dönüş metni `Report-042` olan uygulamaya özgü bir `custom-report-id` alanını depolar. Tanımlayıcı bir hesaplama kaydetmez: Aspose.Slides bilinmeyen bir tür için rapor kimliği oluşturmaz. Bu tanımlayıcıyı anlayan uygulama, anlamını ve değer güncellemesini sağlamalıdır.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
shape.AddTextFrame("Report-042");
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.AddField("custom-report-id");

presentation.Save("custom_field.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom_field.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedPortion = savedShape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine($"Type: {savedPortion.Field?.Type.InternalString}");
Console.WriteLine($"Text: {savedPortion.Text}");
```

Bu PPTX turundan sonra tür `custom-report-id` ve metin `Report-042` olur. `yyyy-MM-dd` gibi bir dize geçirirseniz bir alan türü adlandırılır; özel bir tarih biçimi yapılandırmaz. Rastgele bir biçimde sabit bir tarih için düz metin kullanın.

## **Tarih/Saat Alanlarını İnceleme, Değiştirme ve Kaldırma**

Mevcut bir alana [IField.Type](https://reference.aspose.com/slides/tr/net/aspose.slides/ifield/type/) aracılığıyla erişip değiştirin. Alanın var olduğunu kontrol ettikten sonra türüne erişin. Otomatik güncellemeleri durdurmak için [IPortion.RemoveField](https://reference.aspose.com/slides/tr/net/aspose.slides/iportion/removefield/) metodunu çağırın. Bu, alan ilişkisini kaldırırken bölümü ve mevcut metni korur. Sabit bir değer gerekiyorsa, alanı kaldırdıktan sonra o metni atayın.

Tarih/saat alanı işleme ile ilgili API ayarı için [Presentation.CurrentDateTime](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/currentdatetime/) bölümüne bakın. Aşağıdaki örnek, bir alanı düz metne dönüştürürken belirli bir onay tarihini kullanır.

[Download sample.pptx](sample.pptx) ve çalışma dizinine yerleştirin. Dosya, `UpdatedAt` ve `ApprovedDate` adlı iki adlandırılmış metin şekli içerir; her ikisi de bir tarih/saat alanına sahiptir ve ayrıca düz metin etiketleri bulunur. Aşağıdaki örnek, normal slaytlardaki üst‑seviye metin şekillerinde dolaşır. Tarih/saat alanlarını uzun tarih biçimine çevirir ve eğik yapar, diğer biçimlendirmelerini korur. Yalnızca `ApprovedDate` alanı sabit metne dönüşür.

Yerleşik dahili tanımlayıcılar `datetime` ile `datetime13` arasında tanınır. Gruplar, tablolar, notlar, yerleşimler ve ana temalar kendi metin kapsayıcılarının taranmasını gerektirir ve bu örnek kapsamı dışındadır.

```cs
using System;
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var approvalDate = new DateTime(2030, 4, 5);
var culture = CultureInfo.GetCultureInfo("en-US");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape textShape || textShape.TextFrame == null)
            continue;

        foreach (var paragraph in textShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                var field = portion.Field;
                if (field == null)
                    continue;

                var typeName = field.Type.InternalString;
                var isDateTime = typeName == "datetime";
                if (typeName.StartsWith("datetime", StringComparison.Ordinal))
                {
                    var hasFormatNumber = int.TryParse(typeName.Substring(8), out var formatNumber);
                    isDateTime |= hasFormatNumber && formatNumber >= 1 && formatNumber <= 13;
                }
                if (!isDateTime)
                    continue;

                field.Type = FieldType.DateTime3;
                portion.PortionFormat.LanguageId = "en-US";
                portion.PortionFormat.FontItalic = NullableBool.True;

                if (textShape.Name == "ApprovedDate")
                {
                    portion.RemoveField();
                    portion.Text = approvalDate.ToString("dd MMMM yyyy", culture);
                }
            }
        }
    }
}

presentation.Save("updated_dates.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("updated_dates.pptx");
foreach (var shape in reopened.Slides[0].Shapes)
{
    if (shape is not IAutoShape textShape || textShape.TextFrame == null)
        continue;
    if (textShape.Name != "UpdatedAt" && textShape.Name != "ApprovedDate")
        continue;

    var portion = textShape.TextFrame.Paragraphs[0].Portions[0];
    var typeName = portion.Field?.Type.InternalString ?? "ordinary text";
    Console.WriteLine($"{textShape.Name}: {typeName}; {portion.Text}");
    Console.WriteLine($"Italic: {portion.PortionFormat.FontItalic}");
}
```

Yeniden açtıktan sonra `UpdatedAt` türü `datetime3` olur ve dinamik kalır. `ApprovedDate` alanı yoktur ve `05 April 2030` içerir. Her iki tarih bölümü de eğiktir ve orijinal punto, kalınlık ve renk ayarları korunur. Normal metin etiketleri değişmez. Doğrulama, sağlanan örnek içindeki iki bilinen şeklin ilk bölümünü okur.

## **Metin Biçimlendirmesini Korumak**

Bir alan eklerken, türünü değiştirirken veya kaldırırken mevcut bölümü kullanın. Bu işlemler bölümün biçimlendirmesini korur. Renk ya da eğik gibi yalnızca gerekli özellikleri değiştirmek için [IPortion.PortionFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/iportion/portionformat/) kullanın; örneklerde olduğu gibi.

Bir alanı güncellemek için tüm metin çerçevesini yeniden oluşturmayın: bu, bölüm sınırlarının ve bireysel biçimlendirmelerinin kaybolmasına yol açabilir. Ayrıca, doğrudan ayarlanmış biçimlendirme ile paragraf, yerleşim veya tema tarafından devralınan biçimlendirmeyi ayırın. Daha geniş biçimlendirme seçenekleri için [Text Formatting](/slides/tr/net/text-formatting/) bölümüne bakın.

## **Alanlar ve Üst Bilgi/Alt Bilgi Yer Tutucuları**

Bir alan bir metin bölümünün parçasıdır. Bir yer tutucu, alt bilgi veya slayt numarası gibi bir sunum rolüne sahip bir şekildir. Normal bir metin kutusuna alan eklemek, şekli bir yer tutucuya dönüştürmez.

Üst bilgi/alt bilgi yöneticileri, slaytlar, yerleşimler ve ana temalar üzerindeki yer tutucu metni ve görünürlüğü kontrol eder, bağımlı slaytlara da yayar. Özel bir metin kutusundaki bir sayı alanı, slayt‑numarası yer tutucusunu kullanmasanız bile faydalı olabilir. Öte yandan, yer tutucu görünürlüğünü değiştirmek, alakasız bir metin kutusundaki alanı kaldırmaz.

Önceden tanımlı üst bilgi ve alt bilgi türleri, ilgili yer tutucuları oluşturmaz veya içerik sağlamaz. Özellikle, normal bir PowerPoint slaytında üst bilgi yer tutucusu bulunmaz; üst bilgiler not sayfalarına ve el ilanlarına aittir. Rastgele bir şekildeki üst bilgi veya alt bilgi alanının, yer tutucu yöneticisi aracılığıyla yapılandırılmış metni otomatik alacağını varsamamalısınız. Bu iş akışı için [Presentation Headers and Footers](/slides/tr/net/presentation-header-and-footer/) bölümüne bakın.

## **PPTX ve PPT Kısıtlamaları**

Kaydedip yeniden açtıktan sonra hem alan türünü hem de ortaya çıkan metni kontrol edin. Bir tanımlayıcının korunması, bir uygulamanın değerini hesaplayabileceği veya görüntüleyebileceği anlamına gelmez.

| Biçim | Alan davranışı ve kısıtlamalar |
|---|---|
| PPTX | İç alan tanımlayıcılarını metinle birlikte saklar. Tur‑kontrollerinde, yukarıda kullanılan önceden tanımlı türler ve özel tanımlayıcı kaydedilip yeniden açıldıktan sonra da varlığını korur. Bilinmeyen özel tür geri dönüş metnini korur; otomatik hesaplama mantığı eklemez. Başka bir uygulama, desteklenmeyen tanımlayıcıları farklı işleyebilir. |
| PPT | Eski alan temsillerini kullanır ve daha sınırlı uyumluluğa sahiptir. Tur‑kontrollerinde slayt‑numarası ve önceden tanımlı tarih/saat alanları kaydedilip yeniden açıldıktan sonra da varlığını korur. Normal bir slayt metin kutusundaki özel alan, tanımlayıcıyla açılır ancak metni `*` olur; aynı bağlamdaki bir üst bilgi alanı da `*` üretir. Özel alanların veya desteklenmeyen alan bağlamlarının görünür metinlerini koruyacağını varsamıyın. |

Taşınabilir, sabit çıktı için desteklenmeyen alanları düz metne dönüştürün ve kaydetmeden önce istediğiniz değeri açıkça atayın. Bu, seçilen metni korur ancak otomatik güncellemeleri kasıtlı olarak durdurur. Kendi alan yeniden hesaplamasının iş akışınızın bir parçası olduğu durumlarda hedef uygulamayı da test edin.

## **SSS**

**Görüntülenen bir sayı ya da tarihin alan olup olmadığını nasıl anlayabilirim?**

[IPortion.Field](https://reference.aspose.com/slides/tr/net/aspose.slides/iportion/field/) inceleyin. Null olmayan bir değer alan olduğunu gösterir; yalnızca görüntülenen metin bunu söylemez.

**Bir alanı kaldırmak metni ya da biçimlendirmeyi kaldırır mı?**

Hayır. [RemoveField](https://reference.aspose.com/slides/tr/net/aspose.slides/iportion/removefield/) mevcut bölümü düz metne dönüştürür. Belirli bir dondurulmuş tarih ya da geri dönüş değeri gerekiyorsa, kaldırdıktan sonra açıkça atayın.

**Bir dahili dize yeni bir tarih biçimi ya da formül tanımlayabilir mi?**

Hayır. Bu sadece bir alan türünü tanımlar. Bilinmeyen bir tanımlayıcı bir değerlendirici ya da .NET tarih‑biçim kalıbı sağlamaz. Desteklenen önceden tanımlı bir tür kullanın veya değeri kendiniz düz metin olarak biçimlendirin.

**Kaydettikten sonra sunumu tekrar kontrol etmemin nedeni nedir?**

Alan tanımlayıcıları, hesaplanan metin ve biçimlendirme ayrı ayrı doğrulanması gereken şeylerdir. Biçim dönüşümü, alan tanımlayıcısı hâlâ mevcut olsa bile görünür sonucu değiştirebilir.