---
title: Python aracılığıyla Java kullanarak Sunumlarda Yazı Tipi İkamesi Yapılandırma
linktitle: Yazı Tipi İkamesi
type: docs
weight: 70
url: /tr/python-java/font-substitution/
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
- Python
- Java
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını oluştururken veya dönüştürürken, Python için Java aracılığıyla Aspose.Slides'de yazı tipi ikamesi kurallarını yapılandırın ve ikame edilen yazı tiplerini inceleyin."
---
## **Genel Bakış**

Yazı tipi ikamesi, Aspose.Slides'in bir sunum oluşturulurken veya dönüştürülürken erişilemeyen bir yazı tipi yerine mevcut bir yazı tipini kullanmasını sağlar. İkame, oluşturulan çıktıyı etkiler; sunum içeriğine atanmış yazı tipini değiştirmez.

Belirli bir yazı tipi kullanılamadığında kullanılacak yazı tipini tanımlayabilir ve Aspose.Slides'in oluşturma sırasında yapacağı ikameleri inceleyebilirsiniz. Bu, farklı yüklü yazı tiplerine sahip ortamlar arasında çıktının tutarlı kalmasına yardımcı olur.

Eğer bir yazı tipi mevcut ancak ayrı bir kalın yazı tipi yoksa, [Ayrı Bir Kalın Yazı Tipi Olmadan Yazı Tiplerini İşleme](/slides/tr/python-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface) bölümüne bakın. Bu bölüm, PDF dışa aktarımı sırasında etkilenen metni rasterleştirmenin ve metin seçimi, arama ve ölçekleme üzerindeki sonuçların nasıl olduğunu açıklar.

## **Yazı Tipi İkamesi Al**

Sunum oluşturulduğunda hangi yazı tiplerinin ikame edileceğini belirlemek için [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) metodunu kullanın. Metod, orijinal ve ikame edilmiş yazı tipi adlarını tanımlayan [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/) nesnelerini döndürür.

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

## **Seçili Slaytlar İçin Yazı Tipi İkamesi Al**

Belirli slaytların oluşturulması için gerekli ikameleri yalnızca incelemek amacıyla bir Java tamsayı dizisi argümanı ile [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) metodunun aşırı yüklemesini kullanın. Bu, bir sunumun bir bölümünü oluştururken veya dışa aktarırken, büyük bir sunumu artımlı olarak kontrol ederken, kullanılamayan yazı tiplerine bağımlı slaytları bulurken, bir sunucu veya konteyner için minimal bir yazı tipi paketi hazırlarken veya ilgisiz slaytları işlemeksizin oluşturma farklarını teşhis ederken faydalıdır.

`slides` dizisi bir‑tabanlı slayt indekslerini içerir: `1` ilk slaytı tanımlar. Buna karşılık, [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) koleksiyon erişicisi sıfır‑tabanlı indeksleme kullanır; aynı slayt `presentation.getSlides().get_Item(0)` şeklinde erişilir. Dizi oluştururken bu farkı akılda tutun ve bir‑bir hatasından kaçının.

Aşırı yüklemeyi [Presentation.getFontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getFontsManager) yöntemiyle çağırın. Bu, yalnızca seçili slaytların oluşturulması sırasında belirlenen ikameleri döndürür. Her sonuç, orijinal ve ikame edilmiş yazı tipi adlarını içeren bir [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/) nesnesidir. Sonuç, geçerli yazı tipi ortamını, yapılandırılmış yedekleme kurallarını, bir [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/) içinde depolanan ikame kurallarını ve [dışarıdan yüklenen yazı tiplerini](/slides/tr/python-java/custom-font/) yansıtır.

Aynı ikame, birden fazla seçili slayt tarafından gerekebilir. Yazı tipi envanteri veya ön uç raporu oluştururken sonuçları tekilleştirin. Aşağıdaki örnek her döndürülen ikameyi raporlar ve ardından benzersiz yazı tipi eşlemelerinin sıralı bir listesini oluşturur:

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

[FontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/) sınıfı her iki aşırı yüklemeyi de sağlar. Oluşturma işleminin kapsamına göre birini seçin:

| Overload | Use it when |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) argüman olmadan | Sunumun tamamı için ikameler gerektiğinde. |
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) Java tamsayı dizisi ile | Seçili bir aralık, artımlı kontrol veya kısmi dışa aktarım için ikameler gerektiğinde. |

## **Yazı Tipi İkame Kurallarını Ayarlama**

1. Sunumu yükleyin.
2. Kaynak ve ikame yazı tipleri için yazı tipi tanımları oluşturun.
3. [FontSubstRule](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrule/) nesnesini [WhenInaccessible](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible) koşuluyla oluşturun.
4. Kuralı bir [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/) içine ekleyin.
5. Koleksiyonu [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList) metodunu kullanarak atayın.
6. Sunumu oluşturun veya dönüştürün.

Aşağıdaki Python örneği `SomeRareFont` kullanılamadığında `Arial` yazı tipini ikame eder ve ardından sonucu doğrulamak için ilk slaytı oluşturur. İkame edilen yazı tipi Aspose.Slides tarafından kullanılabilir olmalıdır.

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

{{% alert color="info" title="Note" %}}
Bir sunum boyunca kullanılan yazı tiplerinde koşulsuz bir değişiklik için, [Yazı Tipi Değiştirme](/slides/tr/python-java/font-replacement/) bölümüne bakın.
{{% /alert %}}

## **Matematik Denklem Yazı Tipleri İçin Sınırlamalar**

Yazı tipi ikame kuralları, oluşturma ve dönüştürme sırasında kullanılan standart yazı tipi seçim sürecinin bir parçasıdır. Kurallar, erişilemeyen bir yazı tipini bir kural tarafından belirtilen mevcut yazı tipine değiştirebildiğinde normal metinler için çalışır.

Office Math denklemlerinin ek bir gereksinimi vardır. Bir denklem **Cambria Math** kullanıyorsa, Aspose.Slides denklemin düzenini hesaplamak ve oluşturmak için tam olarak bu yazı tipine ihtiyaç duyabilir. **STIX Two Math** gibi başka bir matematik yazı tipini ikame eden bir kural, bu amaçla **Cambria Math**'i değiştiremez ve oluşturma hâlâ **Cambria Math**'in gerekli olduğunu raporlayabilir.

Böyle bir sunumu oluşturmak veya dönüştürmek için **Cambria Math**'i Aspose.Slides'e sunun. İşletim sistemine kurun veya bir [dış font](/slides/tr/python-java/custom-font/) olarak yükleyin.

Bu sınırlama denklem düzeni için geçerlidir. Yukarıda açıklanan ikame kuralları normal sunum metni için hâlâ geçerlidir.

## **FAQ**

**Yazı Tipi Değiştirme ile Yazı Tipi İkamesi Arasındaki Fark Nedir?**

[Font replacement](/slides/tr/python-java/font-replacement/) sunum boyunca bir yazı tipini bilinçli olarak başka bir yazı tipiyle değiştirir. Yazı tipi ikamesi, yapılandırılmış koşul karşılandığında (örneğin orijinal yazı tipi kullanılamadığında) oluşturulan çıktı için bir yazı tipi seçer.

**İkame kuralları ne zaman uygulanır?**

Kurallar, oluşturma ve dönüştürme sırasında [font selection sequence](/slides/tr/python-java/font-selection-sequence/) sürecine katılır. `WhenInaccessible` ile bir kural yalnızca Aspose.Slides kaynak yazı tipine erişemediğinde kullanılır.

**Bir yazı tipi eksik olduğunda ve hiçbir ikame kuralı yapılandırılmadığında ne olur?**

Aspose.Slides, font seçim sürecine göre en yakın mevcut yazı tipini seçer. Sonuç, çalışma zamanındaki mevcut yazı tiplerine bağlıdır.

**İkameyi önlemek için dış fontları yükleyebilir miyim?**

Evet. Aspose.Slides'in oluşturma ve dönüştürme sırasında kullanabilmesi için [load external fonts](/slides/tr/python-java/custom-font/) yükleyebilirsiniz.

**Aspose kütüphane ile birlikte fontları dağıtıyor mu?**

Hayır. Fontları sağlamaktan ve lisanslarına uymaktan siz sorumlusunuz.

**İkame sonuçları Windows, Linux ve macOS arasında farklılık gösterebilir mi?**

Evet. Yüklü yazı tipleri ve yazı tipi arama konumları işletim sistemine göre değişir; bir makinede mevcut olan bir yazı tipi diğerinde ikame gerektirebilir.

**Toplu dönüştürmelerde font seçimini tutarlı nasıl yapabilirim?**

Her makine veya konteynerde aynı font dosyalarını ve sürümlerini kullanın, [load required external fonts](/slides/tr/python-java/custom-font/) yükleyin ve lisans izin veriyorsa [embed fonts](/slides/tr/python-java/embedded-font/) gömün. Dışa aktarmadan önce beklenmeyen ikameleri belirlemek için ayrıca [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) metodunu çağırabilirsiniz.