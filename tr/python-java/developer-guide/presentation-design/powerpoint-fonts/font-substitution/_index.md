---
title: Python üzerinden Java ile Sunumlarda Yazı Tipi İkametini Yapılandırma
linktitle: Yazı Tipi İkameti
type: docs
weight: 70
url: /tr/python-java/font-substitution/
keywords:
- yazı tipi
- ikamet edilen yazı tipi
- yazı tipi ikameti
- yazı tipini değiştir
- yazı tipi değiştirme
- ikamet kuralı
- değiştirme kuralı
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını render ederken veya dönüştürürken, Python üzerinden Java ile Aspose.Slides’da yazı tipi ikamet kurallarını yapılandırın ve ikamet edilen yazı tiplerini inceleyin."
---
## **Genel Bakış**

Yazı tipi ikameti, Aspose.Slides'ın bir sunum render edildiğinde veya dönüştürüldüğünde erişilemeyen bir yazı tipinin yerine kullanılabilir bir yazı tipini kullanmasına olanak tanır. İkamet, oluşturulan çıktıyı etkiler; sunum içeriğine atanmış yazı tipini değiştirmez.

Belirli bir yazı tipi kullanılamadığında hangi yazı tipinin kullanılacağını tanımlayabilir ve Aspose.Slides’ın render sırasında yapacağı ikameleri inceleyebilirsiniz. Bu, farklı yüklü yazı tiplerine sahip ortamlar arasında çıkışın tutarlı kalmasına yardımcı olur.

## **Yazı Tipi İkamelerini Alın**

[FontsManager.getSubstitutions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsmanager/#getSubstitutions) yöntemini kullanarak sunum render edildiğinde hangi yazı tiplerinin ikamet edileceğini belirleyin. Yöntem, orijinal ve ikamet edilen yazı tipi adlarını tanımlayan [FontSubstitutionInfo](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsubstitutioninfo/) nesnelerini döndürür.

Aşağıdaki Python örneği bir sunum için tüm yazı tipi ikamelerini listeler:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    for substitution in presentation.getFontsManager().getSubstitutions():
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")
finally:
    presentation.dispose()
```

## **Seçili Slaytlar İçin Yazı Tipi İkamelerini Alın**

[FontsManager.getSubstitutions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsmanager/#getSubstitutions) aşırı yüklemesini bir Java tam sayı dizisi argümanıyle kullanarak yalnızca belirli slaytları render etmek için gereken ikameleri inceleyin. Bu, bir sunumun bir kısmını render ederken veya dışa aktarırken, büyük bir sunumu artımlı olarak kontrol ederken, kullanılabilir olmayan yazı tiplerine bağımlı slaytları bulurken, bir sunucu veya konteyner için minimal bir yazı tipi paketi hazırlarken veya ilgisiz slaytları işlemeye gerek kalmadan render farklarını teşhis ederken faydalıdır.

`slides` dizisi bir‑tabanlı slayt indeksleri içerir: `1` ilk slaytı tanımlar. Buna karşılık, [Presentation.getSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getSlides) koleksiyon erişicisi sıfır‑tabanlı indeksleme kullanır; bu yüzden aynı slayt `presentation.getSlides().get_Item(0)` şeklinde erişilir. Dizi oluştururken bu farkı akılda tutun, aksi takdirde bir‑off‑by‑one hatası alabilirsiniz.

Aşırı yüklemeyi [Presentation.getFontsManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getFontsManager) yöntemiyle çağırın. Bu, yalnızca seçili slaytlar render edilirken belirlenen ikameleri döndürür. Her sonuç, orijinal ve ikamet edilen yazı tipi adlarını içeren bir [FontSubstitutionInfo](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsubstitutioninfo/) nesnesidir. Sonuç, geçerli yazı tipi ortamını, yapılandırılmış yedekleme kurallarını, bir [FontSubstRuleCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsubstrulecollection/) içinde depolanan ikamet kurallarını ve [dışarıdan yüklenen yazı tiplerini](/slides/tr/python-java/custom-font/) yansıtır.

Aynı ikamet birden fazla seçili slayt tarafından istenebilir. Bir yazı tipi envanteri veya ön uç raporu oluştururken sonuçları tekilleştirin. Aşağıdaki örnek, döndürülen her ikameti raporlar ve ardından benzersiz yazı tipi eşlemelerinin sıralı bir listesini oluşturur:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    selected_slides = jpype.JArray(jpype.JInt)([1, 3, 5])
    substitutions = list(presentation.getFontsManager().getSubstitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")

    unique_entries = {}
    for substitution in substitutions:
        entry = f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}"
        unique_entries.setdefault(entry.casefold(), entry)

    print("Deduplicated font preflight report:")
    for key in sorted(unique_entries):
        print(unique_entries[key])
finally:
    presentation.dispose()
```

[FontsManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsmanager/) sınıfı her iki aşırı yüklemeyi de sağlar. Render işleminin kapsamına göre birisini seçin:

| Aşırı Yükleme | Ne zaman kullanılır |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsmanager/#getSubstitutions) parametresiz | Tüm sunum için ikameler gerekirken. |
| [getSubstitutions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsmanager/#getSubstitutions) Java tam sayı dizisi ile | Seçili bir aralık, artımlı kontrol veya kısmi dışa aktarım gerektiğinde. |

## **Yazı Tipi İkamet Kurallarını Ayarlama**

Kaynak bir yazı tipi kullanılamadığında Aspose.Slides’ın hangi yazı tipini kullanacağını belirtmek için:

1. Sunumu yükleyin.  
2. Kaynak ve ikamet yazı tipleri için yazı tipi tanımları oluşturun.  
3. [WhenInaccessible](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible) koşuluyla bir [FontSubstRule](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsubstrule/) oluşturun.  
4. Kuralı bir [FontSubstRuleCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsubstrulecollection/) içine ekleyin.  
5. Koleksiyonu [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList) yöntemiyle atayın.  
6. Sunumu render edin veya dönüştürün.

Aşağıdaki Python örneği, `SomeRareFont` kullanılamadığında `Arial` ile ikamet eder ve ardından sonucu doğrulamak için ilk slaytı render eder. İkamet edilen yazı tipinin Aspose.Slides tarafından erişilebilir olması gerekir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, FontSubstCondition, FontSubstRule, FontSubstRuleCollection, ImageFormat, Presentation

presentation = Presentation("Fonts.pptx")
try:
    source_font = FontData("SomeRareFont")
    substitute_font = FontData("Arial")
    substitution_rule = FontSubstRule(source_font, substitute_font, FontSubstCondition.WhenInaccessible)

    substitution_rules = FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.getFontsManager().setFontSubstRuleList(substitution_rules)

    image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        image.save("slide.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Not" %}}
Tüm sunum boyunca kullanılan yazı tiplerinde koşulsuz bir değişiklik yapmak için [Yazı Tipi Değiştirme](/slides/tr/python-java/font-replacement/) bölümüne bakın.
{{% /alert %}}

## **Matematik Denklemi Yazı Tipleri İçin Kısıtlamalar**

Yazı tipi ikamet kuralları, render ve dönüşüm sırasında kullanılan standart yazı tipi seçim sürecinin bir parçasıdır. Aspose.Slides bir erişilemez yazı tipini kuralda belirtilen kullanılabilir bir yazı tipiyle değiştirebildiği sürece normal metin için çalışırlar.

Office Math denklemlerinin ek bir gereksinimi vardır. Bir denklem **Cambria Math** kullanıyorsa, Aspose.Slides denklemin düzenini hesaplamak ve renderlamak için tam olarak bu yazı tipine ihtiyaç duyabilir. **STIX Two Math** gibi başka bir matematik yazı tipine ikamet eden bir kural, bu amaçla **Cambria Math** i değiştiremez ve render hâlâ **Cambria Math**’in gerektiğini raporlayabilir.

Böyle bir sunumu render ya da dönüştürmek için **Cambria Math**’i Aspose.Slides’a sunun. İşletim sistemine kurun veya bir [dış yazı tipi](/slides/tr/python-java/custom-font/) olarak yükleyin.

Bu kısıtlama yalnızca denklem düzeni için geçerlidir. Yukarıda açıklanan ikamet kuralları normal sunum metni için hâlâ uygulanır.

## **SSS**

**Yazı tipi değiştirme ile yazı tipi ikameti arasındaki fark nedir?**

[Font replacement](/slides/tr/python-java/font-replacement/) sunum boyunca bir yazı tipini bilinçli olarak başka bir yazı tipine değiştirir. Yazı tipi ikameti, yapılandırılmış koşul karşılandığında (ör. orijinal yazı tipi kullanılamadığında) render çıktısı için bir yazı tipi seçer.

**İkamet kuralları ne zaman uygulanır?**

Kurallar, render ve dönüşüm sırasında [/font selection sequence](/slides/tr/python-java/font-selection-sequence/) içinde yer alır. `WhenInaccessible` ile bir kural yalnızca Aspose.Slides kaynak yazı tipine erişemediğinde kullanılır.

**Bir yazı tipi eksik olduğunda ve ikamet kuralı yapılandırılmadığında ne olur?**

Aspose.Slides, yazı tipi seçim sürecine göre en yakın mevcut yazı tipini seçer. Sonuç, çalışma zaman ortamında bulunan yazı tiplerine bağlıdır.

**İkameti önlemek için dış yazı tipleri yükleyebilir miyim?**

Evet. Render ve dönüşüm sırasında Aspose.Slides’ın kullanabilmesi için [dış yazı tipleri yükleyebilirsiniz](/slides/tr/python-java/custom-font/).

**Aspose, kütüphane ile birlikte yazı tipleri dağıtıyor mu?**

Hayır. Yazı tiplerini sağlamaktan ve lisanslarına uymaktan siz sorumlusunuz.

**İkamet sonuçları Windows, Linux ve macOS arasında farklılık gösterebilir mi?**

Evet. Yüklü yazı tipleri ve arama konumları işletim sistemine göre değişir; bir makinede mevcut olan bir yazı tipi başka bir makinede ikamet gerektirebilir.

**Toplu dönüşümlerde yazı tipi seçiminde tutarlılığı nasıl sağlarım?**

Her makine veya konteynerde aynı yazı tipi dosyalarını ve sürümlerini kullanın, [gerekli dış yazı tiplerini yükleyin](/slides/tr/python-java/custom-font/) ve lisans izin veriyorsa [yazı tiplerini gömün](/slides/tr/python-java/embedded-font/). Ayrıca beklenmeyen ikameleri tanımlamak için dışa aktarmadan önce [FontsManager.getSubstitutions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsmanager/#getSubstitutions) yöntemini çalıştırabilirsiniz.