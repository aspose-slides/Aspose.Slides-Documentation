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
description: "PowerPoint ve OpenDocument sunumlarını render ederken veya dönüştürürken .NET için Aspose.Slides'de yazı tipi ikamesi kurallarını yapılandırın ve ikâmelenen yazı tiplerini inceleyin."
---
## **Genel Bakış**

Yazı tipi ikamesi, Aspose.Slides'in bir sunum render edildiğinde veya dönüştürüldüğünde erişilemeyen bir yazı tipi yerine kullanılabilir bir yazı tipini kullanmasını sağlar. İkame, oluşturulan çıktıyı etkiler; sunum içeriğine atanmış yazı tipini değiştirmez.

Belirli bir yazı tipi kullanılabilir olmadığında kullanılacak yazı tipini tanımlayabilir ve Aspose.Slides'in render sırasında yapacağı ikameleri inceleyebilirsiniz. Bu, farklı yüklü yazı tiplerine sahip ortamlar arasında çıktının tutarlı kalmasına yardımcı olur.

## **Yazı Tipi Değiştiricilerini Al**

Render sırasında hangi yazı tiplerinin ikâmeleneceğini belirlemek için [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/tr/net/aspose.slides/ifontsmanager/getsubstitutions/) metodunu kullanın. Metot, orijinal ve ikâmelenen yazı tipi adlarını belirten [FontSubstitutionInfo](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsubstitutioninfo/) nesneleri döndürür.

Aşağıdaki C# örneği bir sunum için tüm yazı tipi ikamelerini listeler:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **Seçili Slaytlar İçin Yazı Tipi Değiştiricilerini Al**

Belirli slaytları render etmek için gereken ikameleri yalnızca incelemek amacıyla, `int[] slides` parametresiyle birlikte [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/tr/net/aspose.slides/ifontsmanager/getsubstitutions/) aşırı yüklemesini kullanın. Bu, bir sunumun bir kısmını render ederken veya dışa aktarırken, büyük bir sunumu artımlı olarak kontrol ederken, erişilemeyen yazı tiplerine bağlı slaytları bulurken, bir sunucu ya da konteyner için minimal bir yazı tipi paketi hazırlarken veya ilgili olmayan slaytları işlemeye gerek kalmadan render farklarını teşhis ederken kullanışlıdır.

`slides` dizisi bir‑tabanlı slayt indeksleri içerir: `1` ilk slaytı gösterir. Buna karşılık, [Presentation.Slides](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/slides/tr/) koleksiyon indisleyicisi sıfır‑tabanlıdır; aynı slayta `presentation.Slides[0]` ile erişilir. Tek‑off‑by‑one hataları önlemek için dizi oluştururken bu farkı aklınızda bulundurun.

Aşırı yüklemeyi [Presentation.FontsManager](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/fontsmanager/) özelliği üzerinden çağırın. Seçili slaytlar render edilirken belirlenen ikameler döndürülür. Her sonuç, orijinal ve ikâmelenen yazı tipi adlarını içeren bir [FontSubstitutionInfo](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsubstitutioninfo/) nesnesidir. Sonuç, geçerli yazı tipi ortamını ve [dışarıdan yüklenen yazı tiplerini](/slides/tr/net/custom-font/) yansıtır. [IFontSubstRuleCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/ifontsubstrulecollection/) içinde depolanan ikame kuralları render çıktısını değiştirir ancak sonuçta gösterilmez.

Aynı ikame birden çok seçili slayt tarafından istenebilir. Bir yazı tipi envanteri ya da ön uç raporu oluştururken sonuçları tekilleştirin. Aşağıdaki örnek, dönen her ikameyi raporlar ve ardından benzersiz yazı tipi eşlemelerinin sıralı bir listesini oluşturur:

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

| Aşırı Yükleme | Ne zaman kullanılır |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/tr/net/aspose.slides/ifontsmanager/getsubstitutions/) parametresiz | Tüm sunum için ikameler gerekirken. |
| [GetSubstitutions](https://reference.aspose.com/slides/tr/net/aspose.slides/ifontsmanager/getsubstitutions/) `int[] slides` ile | Seçili bir aralık, artımlı kontrol veya kısmi dışa aktarım için ikameler gerekirken. |

## **Yazı Tipi İkame Kurallarını Belirleme**

Kaynak bir yazı tipi kullanılamadığında Aspose.Slides'in hangi yazı tipini kullanması gerektiğini belirtmek için:

1. Sunumu yükleyin.  
2. Kaynak ve ikâmelenecek yazı tipleri için tanımlar oluşturun.  
3. [WhenInaccessible](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsubstcondition/) koşuluyla bir [FontSubstRule](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsubstrule/) oluşturun.  
4. Kuralı bir [FontSubstRuleCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsubstrulecollection/) içine ekleyin.  
5. Koleksiyonu [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsmanager/fontsubstrulelist/) özelliğine atayın.  
6. Sunumu render edin veya dönüştürün.

Aşağıdaki C# örneği, `SomeRareFont` kullanılamadığında `Arial` ile ikâmelendirir ve ardından ilk slaytı render ederek sonucu doğrular. İkâmel yazı tipinin Aspose.Slides tarafından erişilebilir olması gerekir.

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
Bir sunum boyunca kullanılan tüm yazı tiplerini koşulsuz olarak değiştirmek için [Yazı Tipi Değiştirme](/slides/tr/net/font-replacement/) bölümüne bakın.
{{% /alert %}}

## **Matematik Denklemi Yazı Tipleri İçin Sınırlamalar**

Yazı tipi ikame kuralları, render ve dönüştürme sırasında kullanılan standart yazı tipi seçim sürecinin bir parçasıdır. Bir kural, erişilemeyen bir yazı tipini belirtilen başka bir yazı tipi ile değiştirebildiğinde, normal metin için çalışır.

Office Math denklemlerinin ek bir gereksinimi vardır. Bir denklem **Cambria Math** kullandığında, Aspose.Slides denklemin düzenini hesaplamak ve render etmek için tam olarak bu yazı tipine ihtiyaç duyabilir. **STIX Two Math** gibi başka bir matematik yazı tipiyle ikâmelenen bir kural, bu amaçla **Cambria Math** yerine geçemez; render hâlâ **Cambria Math**'in gerekli olduğunu raporlayabilir.

Böyle bir sunumu render ya da dönüştürmek için **Cambria Math**'i Aspose.Slides'e erişilebilir kılın. İşletim sistemine kurun ya da bir [dış yazı tipi](/slides/tr/net/custom-font/) olarak yükleyin.

Bu sınırlama yalnızca denklem düzeni için geçerlidir. Yukarıda açıklanan ikame kuralları, normal sunum metni için hâlâ uygulanır.

## **SSS**

**Yazı tipi değiştirme ile ikame arasındaki fark nedir?**

[Font replacement](/slides/tr/net/font-replacement/) sunum boyunca bir yazı tipini kasıtlı olarak başka birine değiştirir. Yazı tipi ikamesi, orijinal yazı tipi erişilemez olduğunda gibi, yapılandırılan koşul gerçekleştiğinde render çıktısı için bir yazı tipi seçer.

**İkame kuralları ne zaman uygulanır?**

Kurallar, render ve dönüştürme sırasında [font selection sequence](/slides/tr/net/font-selection-sequence/) sürecine katılır. `WhenInaccessible` kullanıldığında, kural yalnızca Aspose.Slides kaynak yazı tipine erişemediğinde devreye girer.

**Bir yazı tipi eksik ve ikame kuralı yapılandırılmamışsa ne olur?**

Aspose.Slides, font seçim sürecine göre en uygun mevcut yazı tipini seçer. Sonuç, çalışma zaman ortamında bulunan yazı tiplerine bağlıdır.

**İkameyi önlemek için dış yazı tipleri yükleyebilir miyim?**

Evet. Render ve dönüştürme sırasında Aspose.Slides'in kullanabilmesi için [dış yazı tipleri yükleyebilirsiniz](/slides/tr/net/custom-font/).

**Aspose, kütüphane ile birlikte yazı tipleri dağıtıyor mu?**

Hayır. Yazı tiplerini sağlamaktan ve lisans koşullarına uymaktan siz sorumlusunuz.

**İkame sonuçları Windows, Linux ve macOS arasında farklılık gösterebilir mi?**

Evet. Yüklü yazı tipleri ve arama konumları işletim sistemine göre değişir; bir makinede mevcut olan bir yazı tipi, diğerinde ikame gerektirebilir.

**Toplu dönüşümlerde yazı tipi seçimini tutarlı nasıl yapabilirim?**

Her makine veya konteynerde aynı yazı tipi dosyalarını ve sürümlerini kullanın, [gerekli dış yazı tiplerini yükleyin](/slides/tr/net/custom-font/), ve lisans izin veriyorsa [yazı tiplerini gömün](/slides/tr/net/embedded-font/). Ayrıca dışa aktarmadan önce beklenmeyen ikameleri tespit etmek için [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/tr/net/aspose.slides/ifontsmanager/getsubstitutions/) metodunu çağırabilirsiniz.