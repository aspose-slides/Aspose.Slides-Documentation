---
title: Python ile Sunumlarda Yazı Tipi İkamesini Yapılandırma
linktitle: Yazı Tipi İkamesi
type: docs
weight: 70
url: /tr/python-net/font-substitution/
keywords:
- yazı tipi
- ikame yazı tipi
- yazı tipi ikamesi
- yazı tipini değiştirme
- yazı tipi değiştirme
- ikame kuralı
- değiştirme kuralı
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Python için .NET üzerinden Aspose.Slides'ta PowerPoint ve OpenDocument sunumlarını render ederken veya dönüştürürken yazı tipi ikame kurallarını yapılandırın ve ikame edilen yazı tiplerini inceleyin."
---
## **Genel Bakış**

Yazı tipi ikamesi, Aspose.Slides'ın bir sunum render edildiğinde veya dönüştürüldüğünde erişilemeyen bir yazı tipinin yerine kullanılabilir bir yazı tipini kullanmasını sağlar. İkame, render edilen çıktıyı etkiler; sunum içeriğine atanmış yazı tipini değiştirmez.

Belirli bir yazı tipi kullanılamadığında kullanılacak yazı tipini tanımlayabilir ve Aspose.Slides'ın render sırasında yapacağı ikameleri inceleyebilirsiniz. Bu, farklı yüklü yazı tiplerine sahip ortamlar arasında çıktının tutarlı kalmasına yardımcı olur.

## **Yazı Tipi İkamesini Al**

Yazı tiplerinin sunum render edildiğinde hangi ikameler yapılacağını belirlemek için [FontsManager.get_substitutions](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/get_substitutions/) yöntemini kullanın. Yöntem, özgün ve ikame edilen yazı tipi adlarını tanımlayan [FontSubstitutionInfo](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsubstitutioninfo/) nesnelerini döndürür.

İşte bir sunum için tüm yazı tipi ikamelerini listeleyen Python örneği:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **Seçili Slaytlar İçin Yazı Tipi İkamesini Al**

Belirli slaytları render etmek için gereken ikameleri yalnızca incelemek amacıyla bir slayt indeks listesiyle [FontsManager.get_substitutions](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/get_substitutions/) yöntemini kullanın. Bu, bir sunumun bir kısmını render ederken veya dışa aktarırken, büyük bir sunumu artımlı olarak kontrol ederken, mevcut olmayan yazı tiplerine bağımlı slaytları bulurken, bir sunucu veya konteyner için minimal bir yazı tipi paketi hazırlarken ya da alakasız slaytları işlemeden render farklarını teşhis ederken faydalıdır.

Liste, bir‑tabanlı slayt indeksleri içerir: `1` ilk slaytı gösterir. Buna karşılık, [Presentation.slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/slides/tr/) koleksiyonu sıfır‑tabanlıdır, bu yüzden aynı slayt `presentation.slides[0]` şeklinde erişilir. Tek‑off‑by‑one hatalarını önlemek için listeyi oluştururken bu farkı akılda tutun.

Yöntemi, [Presentation.fonts_manager](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/fonts_manager/) özelliği üzerinden çağırın. Yalnızca seçili slaytların render edilmesi sırasında belirlenen ikameleri döndürür. Her sonuç, özgün ve ikame edilen yazı tipi adlarını içeren bir [FontSubstitutionInfo](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsubstitutioninfo/) nesnesidir. Sonuç, mevcut yazı tipi ortamını, yapılandırılmış geri dönüş kurallarını, bir [IFontSubstRuleCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ifontsubstrulecollection/) içinde saklanan ikame kurallarını ve [harici olarak yüklenen yazı tiplerini](/slides/tr/python-net/custom-font/) yansıtır.

Aynı ikame birden fazla seçili slayt tarafından gerekebilir. Yazı tipi envanteri ya da ön uç raporu oluştururken sonuçları tekilleştirin. Aşağıdaki örnek, döndürülen her ikameyi raporlar ve ardından benzersiz yazı tipi eşlemelerinin sıralı bir listesini oluşturur:

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

[FontsManager](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/) sınıfı, yöntemin her iki biçimini de sağlar. Render işleminin kapsamına göre birini seçin:

| Metod çağrısı | Ne zaman kullanılır |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/get_substitutions/) hiçbir argüman olmadan | Tüm sunum için ikamelere ihtiyacınız olduğunda. |
| [get_substitutions](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/get_substitutions/) slayt indekslerinin bir listesiyle | Seçili bir aralık, artımlı kontrol veya kısmi dışa aktarım için ikamelere ihtiyacınız olduğunda. |

## **Yazı Tipi İkame Kurallarını Ayarla**

Bir kaynak yazı tipi mevcut olmadığında Aspose.Slides'ın kullanması gereken yazı tipini belirtmek için:

1. Sunumu yükleyin.
2. Kaynak ve ikame yazı tipleri için yazı tipi tanımları oluşturun.
3. [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsubstcondition/) koşuluyla bir [FontSubstRule](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsubstrule/) oluşturun.
4. Kuralı bir [FontSubstRuleCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsubstrulecollection/) içine ekleyin.
5. Koleksiyonu [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/font_subst_rule_list/) özelliğine atayın.
6. Sunumu render edin veya dönüştürün.

Aşağıdaki Python örneği, `SomeRareFont` mevcut olmadığında `Arial` ile ikame eder ve ardından sonucu doğrulamak için ilk slaytı render eder. İkame yazı tipi Aspose.Slides için kullanılabilir olmalıdır.

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

{{% alert color="info" title="Note" %}}
Bir sunum boyunca kullanılan yazı tiplerinde koşulsuz bir değişiklik için, [Font Replacement](/slides/tr/python-net/font-replacement/) bölümüne bakın.
{{% /alert %}}

## **Matematik Denklemi Yazı Tipleri için Sınırlamalar**

Yazı tipi ikame kuralları, render ve dönüşüm sırasında kullanılan standart yazı tipi seçim sürecinin bir parçasıdır. Bir kural tarafından belirtilen kullanılabilir bir yazı tipiyle erişilemeyen bir yazı tipi değiştirilebildiğinde, kurallar normal metin için çalışır.

Office Math denklemlerinin ek bir gereksinimi vardır. Bir denklem **Cambria Math** kullanıyorsa, Aspose.Slides denklemin düzenini hesaplamak ve render etmek için o kesin yazı tipine ihtiyaç duyabilir. **STIX Two Math** gibi başka bir matematik yazı tipini ikame eden bir kural, bu amaçla **Cambria Math**'i değiştiremez ve render hâlâ **Cambria Math**'in gerekli olduğunu bildirebilir.

Bu tür bir sunumu render etmek veya dönüştürmek için **Cambria Math**'i Aspose.Slides için kullanılabilir hâle getirin. İşletim sistemine kurun ya da bir [harici yazı tipi](/slides/tr/python-net/custom-font/) olarak yükleyin.

Bu sınırlama denklem düzeni için geçerlidir. Yukarıda açıklanan ikame kuralları normal sunum metni için hâlâ geçerlidir.

## **SSS**

**Yazı Tipi Değiştirme ile Yazı Tipi İkamesi arasındaki fark nedir?**  
[Font replacement](/slides/tr/python-net/font-replacement/) sunum boyunca bir yazı tipini başka birine kasıtlı olarak değiştirir. Yazı tipi ikamesi, yapılandırılmış koşul karşılandığında (örneğin, özgün yazı tipi mevcut olmadığında) render edilen çıktı için bir yazı tipi seçer.

**İkame kuralları ne zaman uygulanır?**  
Kurallar, render ve dönüşüm sırasında [font selection sequence](/slides/tr/python-net/font-selection-sequence/) sürecine katılır. `WHEN_INACCESSIBLE` ile bir kural, yalnızca Aspose.Slides kaynak yazı tipine erişemediğinde kullanılır.

**Bir yazı tipi eksik olduğunda ve hiçbir ikame kuralı yapılandırılmadığında ne olur?**  
Aspose.Slides, font seçim sürecine göre en yakın mevcut yazı tipini seçer. Sonuç, çalışma zamanındaki mevcut yazı tiplerine bağlıdır.

**Harici yazı tipleri yükleyerek ikameyi önleyebilir miyim?**  
Evet. Aspose.Slides'ın render ve dönüşüm sırasında kullanabilmesi için [harici yazı tipleri](/slides/tr/python-net/custom-font/) yükleyebilirsiniz.

**Aspose kütüphane ile birlikte yazı tipleri dağıtıyor mu?**  
Hayır. Yazı tiplerini sağlamak ve lisanslarına uymak sizin sorumluluğunuzdadır.

**İkame sonuçları Windows, Linux ve macOS arasında farklılık gösterebilir mi?**  
Evet. Yüklü yazı tipleri ve yazı tipi arama konumları işletim sistemine göre değişir, bu yüzden bir makinede mevcut olan bir yazı tipi diğerinde ikame gerektirebilir.

**Toplu dönüşümlerde yazı tipi seçiminde tutarlılığı nasıl sağlayabilirim?**  
Aynı yazı tipi dosyalarını ve sürümlerini her makine ya da konteynerde kullanın, gerekli [harici yazı tiplerini](/slides/tr/python-net/custom-font/) yükleyin ve lisans izin veriyorsa [yazı tiplerini gömmeyi](/slides/tr/python-net/embedded-font/) yapın. Ayrıca, beklenmeyen ikameleri tespit etmek için dışa aktarmadan önce [FontsManager.get_substitutions](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/get_substitutions/) çağırabilirsiniz.