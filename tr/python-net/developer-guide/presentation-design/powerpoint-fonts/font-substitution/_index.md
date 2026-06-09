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
- yazı tipi değiştirme
- yazı tipi yerine koyma
- ikame kuralı
- yerine koyma kuralı
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: ".NET üzerinden Python için Aspose.Slides'te optimal yazı tipi ikamesini etkinleştirin; PowerPoint ve OpenDocument sunumlarını diğer dosya formatlarına dönüştürürken."
---
## **Genel Bakış**

Yazı tipi ikamesi, Aspose.Slides'ın orijinal sunum yazı tipi render veya dönüşüm sırasında mevcut olmadığında başka bir yazı tipini kullanmasını sağlar. `FontsManager` sınıfındaki `get_substitutions` yöntemini kullanarak hangi yazı tiplerinin ikame edildiğini kontrol edebilirsiniz.

Aspose.Slides ayrıca yazı tipi ikame kurallarını tanımlamanıza izin verir. Örneğin, erişilemeyen bir yazı tipinin başka bir mevcut yazı tipiyle değiştirilmesi gerektiğini belirtebilir ve bu kuralları sunumun yazı tipi yöneticisi aracılığıyla uygulayabilirsiniz.

## **İkame Kurallarını Ayarlama**

Aspose.Slides, belirli koşullarda (örneğin bir yazı tipine erişilemediğinde) ne yapılacağını belirleyen kuralları şu şekilde ayarlamanıza olanak tanır:

1. İlgili sunumu yükleyin.
2. Yerine konulacak yazı tipini yükleyin.
3. Yeni yazı tipini yükleyin.
4. Yerine koyma için bir kural ekleyin.
5. Kuralı sunumun yazı tipi yerini koyma kural koleksiyonuna ekleyin.
6. Etkiyi görmek için slayt görüntüsü oluşturun.

Bu Python kodu, yazı tipi ikame sürecini gösterir:

```python
import aspose.slides as slides

# Sunumu yükler
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Yerine konulacak kaynak yazı tipini yükler
    sourceFont = slides.FontData("SomeRareFont")

    # Yeni yazı tipini yükler
    destFont = slides.FontData("Arial")

    # Yazı tipi değişimi için bir kural ekler
    fontSubstRule = slides.FontSubstRule(sourceFont, destFont, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    # Kuralı yazı tipi ikame kuralları koleksiyonuna ekler
    fontSubstRuleCollection = slides.FontSubstRuleCollection()
    fontSubstRuleCollection.add(fontSubstRule)

    # Yazı tipi kural koleksiyonunu kural listesine ekler
    presentation.fonts_manager.font_subst_rule_list = fontSubstRuleCollection

    # Arial yazı tipi, SomeRareFont erişilemez olduğunda onun yerine kullanılacaktır
    with presentation.slides[0].get_image(1, 1) as bmp:
        # Görüntüyü JPEG formatında diske kaydeder
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```

{{%  alert title="NOTE"  color="warning"   %}} 

Görmek isteyebileceğiniz [**Yazı Tipi Yerine Koyma**](/slides/tr/python-net/font-replacement/). 

{{% /alert %}}

## **Matematik Denklemi Yazı Tipleri İçin Sınırlamalar**

Yazı tipi ikame kuralları, render ve dönüşüm sırasında kullanılan standart yazı tipi seçimi sürecine katılır. Aspose.Slides'ın yapılandırılmış kurala göre erişilemeyen bir yazı tipini başka bir mevcut yazı tipiyle değiştirebildiği normal metin senaryoları için uygundur.

Ancak Office matematik denklemleri önemli bir sınırlamaya sahiptir. Bir denklem **Cambria Math** ile oluşturulmuşsa, Aspose.Slides denklemin düzenini doğru şekilde hesaplamak ve renderlamak için hâlâ orijinal **Cambria Math** yazı tipine ihtiyaç duyabilir. Bu nedenle **Cambria Math**'i **STIX Two Math** gibi başka bir matematik yazı tipine ikame etmek, denklem renderlaması için desteklenmez ve hâlâ **Cambria Math**'in gerekli olduğuna dair bir istisna ortaya çıkabilir.

Bu tür sunumları başarılı bir şekilde dönüştürmek için **Cambria Math**'in çalışma zamanında Aspose.Slides tarafından erişilebilir olduğundan emin olun. Yazı tipini işletim sistemine kurabilir veya bir [harici yazı tipi](/slides/tr/python-net/custom-font/) olarak sağlayarak render ve dönüşüm sırasında normal yazı tipi seçimi sürecine katılmasını sağlayabilirsiniz.

Bu sınırlama yalnızca denklem renderlamasına özgüdür. Yukarıda açıklanan standart yazı tipi ikame kuralları, orijinal yazı tipi erişilemez olduğunda normal sunum metnine hâlâ uygulanır.

## **SSS**

**Yazı tipi yerini koyma ile yazı tipi ikamesi arasındaki fark nedir?**

[Yerine Koyma](/slides/tr/python-net/font-replacement/) tüm sunum boyunca bir yazı tipinin zorunlu olarak başka bir yazı tipiyle değiştirilmesidir. İkame, belirli bir koşul altında (örneğin orijinal yazı tipi kullanılamadığında) tetiklenen ve atanmış bir yedek yazı tipinin kullanıldığı bir kuraldır.

**İkame kuralları tam olarak ne zaman uygulanır?**

Kurallar, yükleme, render ve dönüşüm sırasında değerlendirilen standart [yazı tipi seçimi](/slides/tr/python-net/font-selection-sequence/) sürecine katılır; seçilen yazı tipi mevcut değilse yerine koyma veya ikame uygulanır.

**Ne yazı tipi hem yerini koyma ne de ikame yapılandırılmamış ve sistemde yazı tipi eksikse, varsayılan davranış nedir?**

Kütüphane, PowerPoint'in davranışına benzer şekilde en yakın mevcut sistem yazı tipini seçmeye çalışır.

**İkameyi önlemek için çalışma zamanında özel harici yazı tipleri ekleyebilir miyim?**

Evet. Çalışma zamanında [harici yazı tipleri ekleyebilir](/slides/tr/python-net/custom-font/) ve kütüphane bunları seçim ve renderlama için dikkate alır, sonraki dönüşümler dahil.

**Aspose, kütüphane ile birlikte herhangi bir yazı tipi dağıtıyor mu?**

Hayır. Aspose ücretli ya da ücretsiz yazı tipleri dağıtmaz; yazı tiplerini kendi takdiriniz ve sorumluluğunuzla ekler ve kullanırsınız.

**Windows, Linux ve macOS'ta ikame davranışı farklı mıdır?**

Evet. Yazı tipi keşfi, işletim sisteminin yazı tipi dizinlerinden başlar. Varsayılan olarak mevcut yazı tipleri ve arama yolları platformlar arasında farklıdır; bu da erişilebilirliği ve ikame ihtiyacını etkiler.

**Toplu dönüşümler sırasında beklenmedik ikameleri en aza indirmek için ortamı nasıl hazırlamalıyım?**

Makineler veya konteynerler arasında yazı tipi setini senkronize edin, çıktı belgeleri için gereken [harici yazı tiplerini ekleyin](/slides/tr/python-net/custom-font/) ve mümkün olduğunda sunumlara [yazı tiplerini gömün](/slides/tr/python-net/embedded-font/) ki seçilen yazı tipleri render sırasında mevcut olsun.