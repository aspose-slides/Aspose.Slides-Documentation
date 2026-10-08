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
- yazı tipi yer değiştirme
- ikame kuralı
- değiştirme kuralı
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint ve OpenDocument sunumlarını oluştururken veya dönüştürürken yazı tipi ikame kurallarını yapılandırın ve ikame edilen yazı tiplerini inceleyin."
---
## **Overview**

Yazı tipi ikamesi, Aspose.Slides'in bir sunum oluşturulurken veya dönüştürülürken erişilemeyen bir yazı tipinin yerine kullanılabilir bir yazı tipini kullanmasını sağlar. İkame, oluşturulan çıktıyı etkiler; sunum içeriğine atanan yazı tipini değiştirmez.

Belirli bir yazı tipi kullanılamadığında kullanılacak yazı tipini tanımlayabilir ve Aspose.Slides'in oluşturma sırasında yapacağı ikameleri inceleyebilirsiniz. Bu, farklı yüklü yazı tiplerine sahip ortamlar arasında çıktının tutarlı kalmasına yardımcı olur.

Bir yazı tipi mevcut ancak özel bir kalın yazı tipi yoksa, [Yüksek Kaliteli Bir Bold Yazı Tipi Olmayan Yazı Tiplerini Yönet](/slides/tr/net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface) bölümüne bakın. Bu bölüm, PDF dışa aktarımı sırasında etkilenen metnin nasıl rasterleştirileceğini ve metin seçimi, arama ve ölçeklendirme üzerindeki sonuçları açıklar.

## **Get Font Substitutions**

Sunum oluşturulduğunda hangi yazı tiplerinin ikame edileceğini belirlemek için [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) yöntemini kullanın. Yöntem, orijinal ve ikame edilen yazı tipi adlarını tanımlayan [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) nesnelerini döndürür.

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

## **Get Font Substitutions for Selected Slides**

[IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) aşırı yüklemesini `int[] slides` argümanı ile kullanarak yalnızca belirli slaytların oluşturulması için gereken ikameleri inceleyebilirsiniz. Bu, bir sunumun bir bölümünü oluştururken veya dışa aktarırken, büyük bir sunumu aşamalı olarak kontrol ederken, kullanılamayan yazı tiplerine bağımlı slaytları bulurken, bir sunucu veya konteyner için minimal bir yazı tipi paketi hazırlarken veya ilgili olmayan slaytları işlemadan oluşturma farklarını teşhis ederken faydalıdır.

`slides` dizisi bir‑bazlı slayt indeksleri içerir: `1` ilk slaytı tanımlar. Buna karşılık, [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) koleksiyon indeksleyicisi sıfır‑bazlıdır, bu nedenle aynı slayt `presentation.Slides[0]` olarak erişilir. Dizi oluştururken bu farkı akılda tutun ve bir‑bir hatasından kaçının.

Bu aşırı yüklemeyi [Presentation.FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) özelliği üzerinden çağırın. Yalnızca seçilen slaytların oluşturulması sırasında belirlenen ikameleri döndürür. Her sonuç, orijinal ve ikame edilen yazı tipi adlarını içeren bir [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) nesnesidir. Sonuç, mevcut yazı tipi ortamını ve [dışarıdan yüklenen yazı tipleri](/slides/tr/net/custom-font/) yansıtıyor. [IFontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontsubstrulecollection/) içinde depolanan ikame kuralları oluşturulan çıktıyı değiştirir ancak sonuçta yansıtılmaz.

Aynı ikame, birden fazla seçili slayt tarafından gerekli olabilir. Bir yazı tipi envanteri veya ön uç raporu oluştururken sonuçları tekilleştirin. Aşağıdaki örnek her dönen ikameyi raporlar ve ardından benzersiz yazı tipi eşlemelerinin sıralı bir listesini oluşturur:
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

[IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) arayüzü her iki aşırı yüklemeyi de sağlar. Oluşturma işleminin kapsamına göre birini seçin:

| Aşırı Yükleme | Ne zaman kullanılır |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) with no arguments | Sunumun tamamı için ikamelere ihtiyacınız varsa. |
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) with `int[] slides` | Seçili bir aralık, aşamalı kontrol veya kısmi dışa aktarma için ikamelere ihtiyacınız varsa. |

## **Set Font Substitution Rules**

Kaynak bir yazı tipi kullanılamadığında Aspose.Slides'in kullanması gereken yazı tipini belirtmek için:
1. Sunumu yükleyin.
2. Kaynak ve ikame yazı tipleri için yazı tipi tanımları oluşturun.
3. [WhenInaccessible](https://reference.aspose.com/slides/net/aspose.slides/fontsubstcondition/) koşulu ile bir [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) oluşturun.
4. Kuralı bir [FontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrulecollection/) içine ekleyin.
5. Koleksiyonu [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/fontsubstrulelist/) özelliğine atayın.
6. Sunumu oluşturun veya dönüştürün.

Aşağıdaki C# örneği, `SomeRareFont` kullanılamadığında `Arial`ı ikame eder ve ardından sonucu doğrulamak için ilk slaytı oluşturur. İkame yazı tipi Aspose.Slides için mevcut olmalıdır.
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
Bir sunum boyunca kullanılan yazı tiplerinde koşulsuz bir değişiklik için, [Yazı Tipi Değiştirme](/slides/tr/net/font-replacement/) bölümüne bakın.
{{% /alert %}}

## **Limitations for Math Equation Fonts**

Yazı tipi ikame kuralları, oluşturma ve dönüştürme sırasında kullanılan standart yazı tipi seçim sürecinin bir parçasıdır. Aspose.Slides, erişilemeyen bir yazı tipini kural tarafından belirtilen mevcut yazı tipi ile değiştirebildiğinde, bu kurallar normal metin için çalışır.

Office Math denklemlerinin ek bir gereksinimi vardır. Bir denklem **Cambria Math** kullanıyorsa, Aspose.Slides bu denklemin yerleşimini hesaplamak ve oluşturmak için tam olarak bu yazı tipine ihtiyaç duyabilir. **STIX Two Math** gibi başka bir matematik yazı tipini ikame eden bir kural, bu amaçla **Cambria Math**'i değiştiremez ve oluşturma hâlâ **Cambria Math** gerektiğini bildirebilir.

Böyle bir sunumu oluşturmak veya dönüştürmek için, **Cambria Math**'i Aspose.Slides için kullanılabilir hâle getirin. İşletim sistemine yükleyin veya bir [dış yazı tipi](/slides/tr/net/custom-font/) olarak yükleyin.

Bu sınırlama denklem yerleşimine uygulanır. Yukarıda açıklanan ikame kuralları normal sunum metni için hâlâ geçerlidir.

## **SSS**

**Yazı tipi değiştirme ile yazı tipi ikamesi arasındaki fark nedir?**  
[Yazı tipi değiştirme](/slides/tr/net/font-replacement/) sunum boyunca bir yazı tipini bilinçli olarak başka birine değiştirir. Yazı tipi ikamesi, yapılandırılmış koşul karşılandığında, örneğin orijinal yazı tipi kullanılamadığında, oluşturulan çıktı için bir yazı tipi seçer.

**İkame kuralları ne zaman uygulanır?**  
Kurallar, oluşturma ve dönüştürme sırasında [yazı tipi seçim sırası](/slides/tr/net/font-selection-sequence/) içinde yer alır. `WhenInaccessible` ile bir kural yalnızca Aspose.Slides kaynak yazı tipine erişemediğinde kullanılır.

**Bir yazı tipi eksik olduğunda ve hiçbir ikame kuralı yapılandırılmadığında ne olur?**  
Aspose.Slides, yazı tipi seçim sürecine göre en yakın mevcut yazı tipini seçer. Sonuç, çalışma zamanı ortamında mevcut olan yazı tiplerine bağlıdır.

**İkameyi önlemek için dış yazı tipleri yükleyebilir miyim?**  
Evet. Aspose.Slides'in oluşturma ve dönüştürme sırasında kullanabilmesi için [dış yazı tipleri yükleyin](/slides/tr/net/custom-font/).

**Aspose kütüphane ile birlikte yazı tiplerini dağıtıyor mu?**  
Hayır. Yazı tiplerini sağlamaktan ve lisanslarına uymaktan siz sorumlusunuz.

**İkame sonuçları Windows, Linux ve macOS arasında farklılık gösterebilir mi?**  
Evet. Yüklü yazı tipleri ve yazı tipi arama konumları işletim sistemine göre değişir, bu nedenle bir makinede mevcut olan bir yazı tipi diğerinde ikame gerekebilir.

**Toplu dönüşümlerde yazı tipi seçimini tutarlı nasıl yapabilirim?**  
Her makine veya konteynerde aynı yazı tipi dosyalarını ve sürümlerini kullanın, [gerekli dış yazı tiplerini yükleyin](/slides/tr/net/custom-font/) ve lisans izin veriyorsa [yazı tiplerini göm](/slides/tr/net/embedded-font/). Ayrıca dışa aktarmadan önce beklenmeyen ikameleri belirlemek için [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) yöntemini çağırabilirsiniz.