---
title: Python ile Sunumlarda Yazı Tipi İkamesi Yapılandırma
linktitle: Yazı Tipi İkamesi
type: docs
weight: 70
url: /tr/python-net/font-substitution/
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
- Aspose.Slides
description: ".NET üzerinden Python için Aspose.Slides'te PowerPoint ve OpenDocument sunumlarını oluştururken veya dönüştürürken yazı tipi ikame kurallarını yapılandırın ve ikame edilen yazı tiplerini inceleyin."
---
## **Genel Bakış**

Yazı tipi ikamesi, Aspose.Slides'in bir sunum oluşturulurken veya dönüştürülürken erişilemeyen bir yazı tipinin yerine mevcut bir yazı tipini kullanmasını sağlar. İkame, oluşturulan çıktıyı etkiler; sunum içeriğine atanmış yazı tipini değiştirmez.

Belirli bir yazı tipi kullanılamadığında hangi yazı tipinin kullanılacağını tanımlayabilir ve Aspose.Slides'in oluşturma sırasında yapacağı ikameleri inceleyebilirsiniz. Bu, farklı kurulmuş yazı tiplerine sahip ortamlar arasında çıktının tutarlı kalmasına yardımcı olur.

Eğer bir yazı tipi mevcut ancak ayrı bir kalın yazı tipi yoksa, [Ayırdedilmiş Kalın Yazı Tipi Olmayan Yazı Tiplerini İşleme](/slides/tr/python-net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface) bölümüne bakın. Bu bölüm, PDF dışa aktarımı sırasında etkilenen metnin rasterleştirilmesini ve metin seçimi, arama ve ölçeklendirme üzerindeki sonuçlarını açıklar.

## **Yazı Tipi İkamesi Al**

Sunum oluşturulduğunda hangi yazı tiplerinin ikame edileceğini belirlemek için [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) metodunu kullanın. Metod, orijinal ve ikame edilen yazı tipi adlarını tanımlayan [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/) nesnelerini döndürür.

Aşağıdaki Python örneği bir sunum için tüm yazı tipi ikamelerini listeler:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **Seçili Slaytlar İçin Yazı Tipi İkamesi Al**

[FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) metodunu slayt indeksleri listesiyle kullanarak yalnızca belirli slaytların oluşturulması için gerekli ikameleri inceleyebilirsiniz. Bu, bir sunumun bir kısmını oluştururken veya dışa aktarırken, büyük bir sunumu artırımlı olarak kontrol ederken, kullanılmayan yazı tiplerine bağımlı slaytları bulurken, bir sunucu veya konteyner için minimal bir yazı tipi paketi hazırlarken veya ilgili olmayan slaytları işlemeye gerek kalmadan oluşturma farklarını teşhis ederken faydalıdır.

Liste, bir‑tabanlı slayt indeksleri içerir: `1` ilk slaytı gösterir. Buna karşılık, [Presentation.slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) koleksiyonu sıfır‑tabanlıdır, bu yüzden aynı slayta `presentation.slides[0]` ile erişilir. Tek bir kaydırma hatasını önlemek için listeyi oluştururken bu farkı aklınızda tutun.

Metodu [Presentation.fonts_manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/) özelliği üzerinden çağırın. Yalnızca seçili slaytların oluşturulması sırasında belirlenen ikameleri döndürür. Her sonuç, orijinal ve ikame edilen yazı tipi adlarını içeren bir [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/) nesnesidir. Sonuç, mevcut yazı tipi ortamını, yapılandırılmış geri dönüş kurallarını, bir [IFontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontsubstrulecollection/) içinde depolanan ikame kurallarını ve [harici yüklenmiş yazı tipleri](/slides/tr/python-net/custom-font/) içermektedir.

Aynı ikame birden fazla seçili slayt tarafından talep edilebilir. Bir yazı tipi envanteri veya önkontrol raporu oluştururken sonuçları tekilleştirin. Aşağıdaki örnek her döndürülen ikameyi raporlar ve ardından benzersiz yazı tipi eşlemelerinin sıralı bir listesini oluşturur:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    selected_slides = [1, 3, 5]
    substitutions = list(presentation.fonts_manager.get_substitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")

    preflight_entries = [f"{substitution.original_font_name} -> {substitution.substituted_font_name}" for substitution in substitutions]
    unique_preflight_entries = {entry.casefold(): entry for entry in preflight_entries}
    sorted_preflight_entries = sorted(unique_preflight_entries.values(), key=str.casefold)

    print("Deduplicated font preflight report:")
    for entry in sorted_preflight_entries:
        print(entry)
```

[FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) sınıfı her iki metod biçimini de sağlar. Oluşturma işleminin kapsamına göre birini seçin:

| Metod çağrısı | Ne zaman kullanılır |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) argümansız | Sunumun tamamı için ikameler gerekirken |
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) slayt indeks listesiyle | Seçili bir aralık, artımlı kontrol veya kısmi dışa aktarım gerektiğinde |

## **Yazı Tipi İkame Kurallarını Belirleme**

Kaynak bir yazı tipi kullanılamadığında Aspose.Slides'in hangi yazı tipini kullanması gerektiğini belirtmek için:

1. Sunumu yükleyin.
2. Kaynak ve ikame yazı tipleri için yazı tipi tanımları oluşturun.
3. [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstcondition/) koşuluyla bir [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/) oluşturun.
4. Kuralı bir [FontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrulecollection/) içine ekleyin.
5. Koleksiyonu [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/font_subst_rule_list/) özelliğine atayın.
6. Sunumu oluşturun veya dönüştürün.

Aşağıdaki Python örneği `SomeRareFont` kullanılamadığında `Arial` ile ikame eder ve ardından ilk slaytı oluşturup sonucu doğrular. İkame edilen yazı tipinin Aspose.Slides tarafından erişilebilir olması gerekir.

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    source_font = slides.FontData("SomeRareFont")
    substitute_font = slides.FontData("Arial")
    substitution_rule = slides.FontSubstRule(source_font, substitute_font, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    substitution_rules = slides.FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.fonts_manager.font_subst_rule_list = substitution_rules

    with presentation.slides[0].get_image(1, 1) as image:
        image.save("slide.jpg", slides.ImageFormat.JPEG)
```

{{% alert color="info" title="Not" %}}
Sunum boyunca kullanılan yazı tiplerinde koşulsuz bir değişiklik için, [Yazı Tipi Değiştirme](/slides/tr/python-net/font-replacement/) bölümüne bakın.
{{% /alert %}}

## **Matematik Denklemi Yazı Tipleri İçin Sınırlamalar**

Yazı tipi ikame kuralları, oluşturma ve dönüştürme sırasında kullanılan standart yazı tipi seçim sürecinin bir parçasıdır. Aspose.Slides bir erişilemeyen yazı tipini kural tarafından belirtilen mevcut yazı tipiyle değiştirebildiğinde, normal metin için çalışırlar.

Office Math denklemlerinin ek bir gereksinimi vardır. Bir denklem **Cambria Math** kullanıyorsa, Aspose.Slides denklemin düzenini hesaplamak ve oluşturmak için o tam yazı tipine ihtiyaç duyabilir. **STIX Two Math** gibi başka bir matematik yazı tipini ikame eden bir kural **Cambria Math**'ı bu amaçla değiştiremez ve oluşturma hâlâ **Cambria Math**'ın gerekli olduğunu bildirebilir.

Böyle bir sunumu oluşturmak veya dönüştürmek için **Cambria Math**'ı Aspose.Slides'e erişilebilir kılın. İşletim sistemine yükleyin veya bir [harici yazı tipi](/slides/tr/python-net/custom-font/) olarak yükleyin.

Bu sınırlama yalnızca denklem düzeni için geçerlidir. Yukarıda açıklanan ikame kuralları normal sunum metni için hâlâ geçerlidir.

## **SSS**

**Yazı tipi değiştirme ile yazı tipi ikamesi arasındaki fark nedir?**

[Font replacement](/slides/tr/python-net/font-replacement/) sunum boyunca bir yazı tipini bilinçli olarak başka birine değiştirir. Yazı tipi ikamesi, orijinal yazı tipi kullanılamadığında yapılandırılmış koşul karşılandığında oluşturulan çıktı için bir yazı tipi seçer.

**İkame kuralları ne zaman uygulanır?**

Kurallar, oluşturma ve dönüştürme sırasında [font selection sequence](/slides/tr/python-net/font-selection-sequence/) içinde yer alır. `WHEN_INACCESSIBLE` koşulu, Aspose.Slides kaynak yazı tipine erişemediğinde sadece o zaman kullanılır.

**Bir yazı tipi eksik ve ikame kuralı yapılandırılmamışsa ne olur?**

Aspose.Slides, yazı tipi seçim sürecine göre mevcut en yakın yazı tipini seçer. Sonuç, çalışma zaman ortamındaki mevcut yazı tiplerine bağlıdır.

**İkameyi önlemek için harici yazı tipleri yükleyebilir miyim?**

Evet. Aspose.Slides'in oluşturma ve dönüştürme sırasında kullanabilmesi için [harici yazı tipleri yükleyebilir](/slides/tr/python-net/custom-font/) gibi.

**Aspose, kütüphane ile birlikte yazı tipleri dağıtıyor mu?**

Hayır. Yazı tiplerini temin etmek ve lisanslarına uymak sizin sorumluluğunuzdadır.

**İkame sonuçları Windows, Linux ve macOS arasında farklılık gösterebilir mi?**

Evet. Yüklü yazı tipleri ve yazı tipi arama konumları işletim sistemine göre değişir; bir makinede mevcut bir yazı tipi başka birinde ikame gerektirebilir.

**Toplu dönüşümlerde yazı tipi seçiminde tutarlılık nasıl sağlanır?**

Her makine veya konteynerde aynı yazı tipi dosyalarını ve sürümlerini kullanın, [gerekli harici yazı tiplerini yükleyin](/slides/tr/python-net/custom-font/) ve lisans izin veriyorsa [yazı tiplerini gömün](/slides/tr/python-net/embedded-font/). Export öncesinde beklenmedik ikameleri belirlemek için [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) metodunu çağırabilirsiniz.