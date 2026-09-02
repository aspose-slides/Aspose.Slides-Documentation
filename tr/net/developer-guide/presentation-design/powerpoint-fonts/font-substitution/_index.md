---
title: .NET'te Sunumlarda Yazı Tipi İkamesini Yapılandırma
linktitle: Yazı Tipi İkamesi
type: docs
weight: 70
url: /tr/net/font-substitution/
keywords:
- yazı tipi
- ikame yazı tipi
- yazı tipi ikamesi
- yazı tipi değiştirme
- yazı tipi değişimi
- ikame kuralı
- değiştirme kuralı
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: ".NET için Aspose.Slides'ta PowerPoint ve OpenDocument sunumlarını render ederken veya dönüştürürken yazı tipi ikame kurallarını yapılandırın ve ikame edilen yazı tiplerini inceleyin."
---
## **Genel Bakış**

Yazı tipi ikamesi, Aspose.Slides'ın bir sunum render edildiğinde veya dönüştürüldüğünde erişilemeyen bir yazı tipinin yerine kullanılabilir bir yazı tipini kullanmasını sağlar. İkame, oluşturulan çıktıyı etkiler; sunum içeriğine atanan yazı tipini değiştirmez.

Belirli bir yazı tipi mevcut olmadığında kullanılacak yazı tipini tanımlayabilir ve Aspose.Slides'ın render sırasında yapacağı ikameleri inceleyebilirsiniz. Bu, farklı kurulu yazı tiplerine sahip ortamlar arasında çıktının tutarlı kalmasına yardımcı olur.

## **Yazı Tipi İkamesi Al**

Sunum render edildiğinde hangi yazı tiplerinin ikame edileceğini belirlemek için [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/tr/net/aspose.slides/ifontsmanager/getsubstitutions/) yöntemini kullanın. Bu yöntem, orijinal ve ikame edilen yazı tipi adlarını tanımlayan [FontSubstitutionInfo](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsubstitutioninfo/) nesnelerini döndürür.

Aşağıdaki C# örneği, bir sunum için tüm yazı tipi ikamelerini listeler:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **Seçili Slaytlar İçin Yazı Tipi İkamesi Al**

Belirli slaytların render edilmesi için gereken ikameleri yalnızca incelemek amacıyla `int[] slides` argümanına sahip [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/tr/net/aspose.slides/ifontsmanager/getsubstitutions/) aşırı yüklemesini kullanın. Bu, bir sunumun bir bölümünü render ederken veya dışa aktarırken, büyük bir sunumu artımlı olarak kontrol ederken, mevcut olmayan yazı tiplerine bağımlı slaytları bulurken, bir sunucu veya konteyner için minimal bir yazı tipi paketi hazırlarken veya ilgisiz slaytları işlemeye gerek kalmadan render farklarını teşhis ederken faydalıdır.

`slides` dizisi tek‑bazlı slayt indeksleri içerir: `1` ilk slaytı tanımlar. Buna karşılık, [Presentation.Slides](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/slides/tr/) koleksiyon indisleyicisi sıfır‑bazlıdır; bu aynı slayta `presentation.Slides[0]` ile erişilir. Dizi oluştururken bu farkı aklınızda bulundurun ki bir‑bir hatasından kaçının.

Aşırı yüklemeyi [Presentation.FontsManager](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/fontsmanager/) özelliği üzerinden çağırın. Bu, yalnızca seçili slaytların render edilmesi sırasında belirlenen ikameleri döndürür. Her sonuç, orijinal ve ikame edilen yazı tipi adlarını içeren bir [FontSubstitutionInfo](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsubstitutioninfo/) nesnesidir. Sonuç, geçerli yazı tipi ortamını, yapılandırılmış geri dönüş kurallarını, bir [IFontSubstRuleCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/ifontsubstrulecollection/) içinde depolanan ikame kurallarını ve [externally loaded fonts](/slides/tr/net/custom-font/) öğesini yansıtır.

Aynı ikame birden fazla seçili slayt tarafından istenebilir. Bir yazı tipi envanteri veya ön uç raporu oluştururken sonuçları tekilleştirin. Aşağıdaki örnek, döndürülen her ikameyi raporlar ve ardından benzersiz yazı tipi eşlemelerinin sıralı bir listesini oluşturur:

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

int[] selectedSlides = { 1, 3, 5 };
var substitutions = presentation.FontsManager.GetSubstitutions(selectedSlides).ToList();

Console.WriteLine("Substitutions for the selected slides:");
foreach (var substitution in substitutions)
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

var preflightEntries = substitutions.Select(substitution => $"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
var uniquePreflightEntries = preflightEntries.Distinct(StringComparer.OrdinalIgnoreCase);
var sortedPreflightEntries = uniquePreflightEntries.OrderBy(entry => entry, StringComparer.OrdinalIgnoreCase).ToList();

Console.WriteLine("Deduplicated font preflight report:");
foreach (var entry in sortedPreflightEntries)
{
    Console.WriteLine(entry);
}
```

[IFontsManager](https://reference.aspose.com/slides/tr/net/aspose.slides/ifontsmanager/) arabirimi her iki aşırı yüklemeyi de sağlar. Render işleminin kapsamına göre birini seçin:

| Aşırı Yükleme | Kullanması Gereken Durum |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/tr/net/aspose.slides/ifontsmanager/getsubstitutions/) with no arguments | Tüm sunum için ikameler gerektiğinde. |
| [GetSubstitutions](https://reference.aspose.com/slides/tr/net/aspose.slides/ifontsmanager/getsubstitutions/) with `int[] slides` | Seçili bir aralık, artımlı kontrol veya kısmi dışa aktarım için ikameler gerektiğinde. |

## **Yazı Tipi İkame Kurallarını Ayarla**

Bir kaynak yazı tipi mevcut olmadığında Aspose.Slides'ın kullanması gereken yazı tipini belirtmek için:

1. Sunumu yükleyin.  
2. Kaynak ve ikame yazı tipleri için yazı tipi tanımları oluşturun.  
3. Bir [FontSubstRule](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsubstrule/) nesnesini [WhenInaccessible](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsubstcondition/) koşulu ile oluşturun.  
4. Kuralı bir [FontSubstRuleCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsubstrulecollection/) içine ekleyin.  
5. Koleksiyonu [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsmanager/fontsubstrulelist/) özelliğine atayın.  
6. Sunumu render edin veya dönüştürün.

Aşağıdaki C# örneği, `SomeRareFont` mevcut olmadığında `Arial` ile ikame eder ve ardından sonucu doğrulamak için ilk slaytı render eder. İkame yazı tipi Aspose.Slides tarafından erişilebilir olmalıdır.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("Fonts.pptx");

var sourceFont = new FontData("SomeRareFont");
var substituteFont = new FontData("Arial");
var substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

var substitutionRules = new FontSubstRuleCollection();
substitutionRules.Add(substitutionRule);
presentation.FontsManager.FontSubstRuleList = substitutionRules;

using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("slide.jpg", ImageFormat.Jpeg);
```

{{% alert color="info" title="Note" %}}
Bir sunum boyunca kullanılan yazı tiplerinde koşulsuz bir değişiklik için, [Font Replacement](/slides/tr/net/font-replacement/) bölümüne bakın.
{{% /alert %}}

## **Matematik Denklem Yazı Tipleri İçin Sınırlamalar**

Yazı tipi ikame kuralları, render ve dönüştürme sırasında kullanılan standart yazı tipi seçim sürecinin bir parçasıdır. Aspose.Slides bir erişilemeyen yazı tipini kuralda belirtilen mevcut bir yazı tipiyle değiştirebildiğinde, normal metin için çalışırlar.

Office Math denklemlerinin ek bir gereksinimi vardır. Bir denklem **Cambria Math** kullanıyorsa, Aspose.Slides bu denklemin düzenini hesaplamak ve render etmek için **Cambria Math** yazı tipine tam olarak ihtiyaç duyabilir. **STIX Two Math** gibi başka bir matematik yazı tipini ikame eden bir kural, bu amaç için **Cambria Math**'ı değiştiremez ve render hâlâ **Cambria Math**'ın gerekli olduğunu bildirebilir.

Böyle bir sunumu render etmek veya dönüştürmek için **Cambria Math**'ı Aspose.Slides'a erişilebilir hâle getirin. İşletim sistemine kurun ya da bir [external font](/slides/tr/net/custom-font/) olarak yükleyin.

Bu sınırlama yalnızca denklem düzeni için geçerlidir. Yukarıda açıklanan ikame kuralları, normal sunum metni için hâlâ geçerlidir.

## **SSS**

**Yazı tipi değişimi ile yazı tipi ikamesi arasındaki fark nedir?**

[Font replacement](/slides/tr/net/font-replacement/) bir sunum boyunca bir yazı tipini başka birine kasıtlı olarak değiştirir. Yazı tipi ikamesi, orijinal yazı tipi mevcut olmadığında ya da koşul karşılandığında render edilen çıktı için bir yazı tipi seçer.

**İkame kuralları ne zaman uygulanır?**

Kurallar, render ve dönüştürme sırasında [font selection sequence](/slides/tr/net/font-selection-sequence/) içinde yer alır. `WhenInaccessible` kullanıldığında, kural yalnızca Aspose.Slides kaynak yazı tipine erişemediğinde devreye girer.

**Bir yazı tipi eksik olduğunda ve hiçbir ikame kuralı yapılandırılmadığında ne olur?**

Aspose.Slides, font seçim sürecine göre en yakın mevcut yazı tipini seçer. Sonuç, çalışma zaman ortamında bulunan yazı tiplerine bağlıdır.

**İkameyi önlemek için harici yazı tipleri yükleyebilir miyim?**

Evet. Render ve dönüştürme sırasında Aspose.Slides’ın kullanabilmesi için [harici yazı tipleri yükleyebilirsiniz](/slides/tr/net/custom-font/).

**Aspose, kütüphane ile birlikte yazı tiplerini dağıtıyor mu?**

Hayır. Yazı tiplerini temin etmek ve lisans şartlarına uymak sizin sorumluluğunuzdadır.

**İkame sonuçları Windows, Linux ve macOS arasında farklılık gösterebilir mi?**

Evet. Yüklü yazı tipleri ve yazı tipi arama konumları işletim sistemine göre değişir; bir makinede mevcut olan bir yazı tipi, diğer bir makinede ikame gerektirebilir.

**Toplu dönüşümlerde yazı tipi seçimini nasıl tutarlı hâle getirebilirim?**

Her makine veya konteynerde aynı yazı tipi dosyalarını ve sürümlerini kullanın, [gerekli harici yazı tiplerini yükleyin](/slides/tr/net/custom-font/), ve lisans izin veriyorsa [yazı tiplerini gömün](/slides/tr/net/embedded-font/). Ayrıca dışa aktarmadan önce beklenmeyen ikameleri belirlemek için [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/tr/net/aspose.slides/ifontsmanager/getsubstitutions/) yöntemini çağırabilirsiniz.