---
title: JavaScript Kullanarak Sunumlarda Yazı Tipi İkamesini Yapılandırma
linktitle: Yazı Tipi İkamesi
type: docs
weight: 70
url: /tr/nodejs-java/font-substitution/
keywords:
- yazı tipi
- ikame yazı tipi
- yazı tipi ikamesi
- yazı tipi değiştirme
- yazı tipi değiştirme
- ikame kuralı
- değiştirme kuralı
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını render ederken veya dönüştürürken, Node.js için Aspose.Slides'te yazı tipi ikame kurallarını yapılandırın ve ikame edilen yazı tiplerini inceleyin."
---
## **Genel Bakış**

Yazı tipi ikamesi, Aspose.Slides'in bir sunum render edildiğinde veya dönüştürüldüğünde erişilemeyen bir yazı tipinin yerine mevcut bir yazı tipini kullanmasını sağlar. İkame, oluşturulan çıktı üzerinde etkili olur; sunum içeriğine atanmış yazı tipini değiştirmez.

Belirli bir yazı tipi bulunamadığında kullanılacak yazı tipini tanımlayabilir ve Aspose.Slides'in render sırasında yapacağı ikameleri inceleyebilirsiniz. Bu, farklı yüklü yazı tiplerine sahip ortamlar arasında çıktının tutarlı kalmasına yardımcı olur.

## **Yazı Tipi İkamesini Alın**

Sunum render edildiğinde hangi yazı tiplerinin ikame edileceğini belirlemek için [FontsManager.getSubstitutions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) yöntemini kullanın. Yöntem, orijinal ve ikame edilen yazı tipi adlarını belirten [FontSubstitutionInfo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsubstitutioninfo/) nesnelerini döndürür.

Aşağıdaki JavaScript örneği, bir sunum için tüm yazı tipi ikamelerini listeler:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var substitutions = presentation.getFontsManager().getSubstitutions().iterator();
    while (substitutions.hasNext()) {
        var substitution = substitutions.next();
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **Seçili Slaytlar İçin Yazı Tipi İkamesini Alın**

Yalnızca belirli slaytların render edilmesi için gereken ikameleri incelemek üzere, slayt indeksleri dizisiyle [FontsManager.getSubstitutions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) aşırı yüklü yöntemini kullanın. Bu, bir sunumun bir bölümünü render ederken veya dışa aktarırken, büyük bir sunumu Artımlı olarak kontrol ederken, erişilemeyen yazı tiplerine bağımlı slaytları bulurken, bir sunucu ya da konteyner için minimal bir yazı tipi paketi hazırlarken veya ilgisiz slaytları işlemeye almadan render farklarını teşhis ederken faydalıdır.

Aşırı yük, bir Java primitive `int[]` bekler. Bunu `java.newArray("int", [...])` ile oluşturun; düz bir JavaScript dizisi `Integer[]`'e dönüştürülür ve bu aşırı yüklü yönteme eşleşmez.

Dizi, bir‑tabanlı slayt indeksleri içerir: `1` ilk slaytı tanımlar. Buna karşılık, [Presentation.getSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/getslides/) koleksiyon erişicisi sıfır‑tabanlı indeksleme kullanır, bu yüzden aynı slayt `presentation.getSlides().get_Item(0)` ile erişilir. Dizi oluştururken bu farkı akılda tutarak tek‑bir‑hata hatalarından kaçının.

Aşırı yükü [Presentation.getFontsManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/getfontsmanager/) üzerinden çağırın. Bu, yalnızca seçili slaytlar render edilirken belirlenen ikameleri döndürür. Her sonuç, orijinal ve ikame edilen yazı tipi adlarını içeren bir [FontSubstitutionInfo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsubstitutioninfo/) nesnesidir. Sonuç, mevcut yazı tipi ortamını, yapılandırılmış geri dönüş kurallarını, bir [FontSubstRuleCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsubstrulecollection/) içinde depolanan ikame kurallarını ve [harici yüklenmiş yazı tiplerini](/slides/tr/nodejs-java/custom-font/) yansıtır.

Aynı ikame birden fazla seçili slayt tarafından istenebilir. Bir yazı tipi envanteri ya da ön uç raporu oluştururken sonuçları tekilleştirin. Aşağıdaki örnek, döndürülen her ikameyi raporlar ve ardından benzersiz yazı tipi eşlemelerinin sıralı bir listesini oluşturur:

```javascript
var aspose = aspose || {};
const java = require("java");
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var selectedSlides = java.newArray("int", [1, 3, 5]);
    var substitutions = [];
    var substitutionIterator = presentation.getFontsManager().getSubstitutions(selectedSlides).iterator();
    while (substitutionIterator.hasNext()) {
        substitutions.push(substitutionIterator.next());
    }

    console.log("Substitutions for the selected slides:");
    substitutions.forEach(function (substitution) {
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    });

    var preflightEntries = substitutions.map(function (substitution) {
        return substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
    });
    var sortedPreflightEntries = Array.from(new Set(preflightEntries)).sort(function (first, second) {
        return first.localeCompare(second, undefined, { sensitivity: "base" });
    });

    console.log("Deduplicated font preflight report:");
    sortedPreflightEntries.forEach(function (entry) {
        console.log(entry);
    });
} finally {
    presentation.dispose();
}
```

[FontsManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsmanager/) sınıfı her iki aşırı yükü de sağlar. Render operasyonunun kapsamına göre birini seçin:

| Aşırı Yük | Ne zaman kullanılır |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) parametresiz | Tüm sunum için ikameler gerektiğinde. |
| [getSubstitutions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) slayt indekslerinin Java `int[]`'i | Seçili bir aralık, artımlı kontrol veya kısmi dışa aktarım gerektiğinde. |

## **Yazı Tipi İkame Kurallarını Ayarlama**

Kaynak bir yazı tipi erişilemez olduğunda Aspose.Slides'in hangi yazı tipini kullanacağını belirtmek için:

1. Sunumu yükleyin.  
2. Kaynak ve ikame yazı tipleri için tanımlar oluşturun.  
3. [WhenInaccessible](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsubstcondition/) koşuluyla bir [FontSubstRule](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsubstrule/) oluşturun.  
4. Kuralı bir [FontSubstRuleCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsubstrulecollection/) içine ekleyin.  
5. Koleksiyonu [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/) yöntemiyle atayın.  
6. Sunumu render edin veya dönüştürün.

Aşağıdaki JavaScript örneği, `SomeRareFont` erişilemez olduğunda `Arial` ile ikame eder ve ardından sonucu doğrulamak için ilk slaytı render eder. İkame yazı tipi Aspose.Slides tarafından erişilebilir olmalıdır.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    var substituteFont = new aspose.slides.FontData("Arial");
    var substitutionRule = new aspose.slides.FontSubstRule(sourceFont, substituteFont, aspose.slides.FontSubstCondition.WhenInaccessible);

    var substitutionRules = new aspose.slides.FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    var image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0);
    try {
        image.save("slide.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Sunum boyunca kullanılan yazı tiplerinde koşulsuz bir değişiklik yapmak için [Yazı Tipi Değiştirme](/slides/tr/nodejs-java/font-replacement/) bölümüne bakın.
{{% /alert %}}

## **Matematik Denklemi Yazı Tipleri İçin Sınırlamalar**

Yazı tipi ikame kuralları, render ve dönüşüm sırasında kullanılan standart yazı tipi seçim sürecinin bir parçasıdır. Aspose.Slides'in erişilemeyen bir yazı tipini kuralda belirtilen mevcut yazı tipine değiştirebildiği sürece normal metin için çalışır.

Office Math denklemlerinin ek bir gereksinimi vardır. Bir denklem **Cambria Math** kullanıyorsa, Aspose.Slides denklemin düzenini hesaplamak ve render etmek için tam olarak bu yazı tipine ihtiyaç duyabilir. **STIX Two Math** gibi başka bir matematik yazı tipini ikame eden bir kural, bu amaç için **Cambria Math**'ı değiştiremez ve render hâlâ **Cambria Math**'ın gerekli olduğunu bildirebilir.

Böyle bir sunumu render ya da dönüştürmek için **Cambria Math**'ı Aspose.Slides'e sunun. İşletim sistemine yükleyin veya bir [harici yazı tipi](/slides/tr/nodejs-java/custom-font/) olarak yükleyin.

Bu sınırlama yalnızca denklem düzeni için geçerlidir. Yukarıda açıklanan ikame kuralları normal sunum metni için hâlâ geçerlidir.

## **SSS**

**Yazı tipi değişimi ile yazı tipi ikamesi arasındaki fark nedir?**

[Font replacement](/slides/tr/nodejs-java/font-replacement/) sunum boyunca bir yazı tipini bilinçli olarak başka bir yazı tipine değiştirir. Yazı tipi ikamesi, yapılandırılmış koşul karşılandığında (örneğin orijinal yazı tipi mevcut değilse) render edilen çıkış için bir yazı tipi seçer.

**İkame kuralları ne zaman uygulanır?**

Kurallar, render ve dönüşüm sırasında [font selection sequence](/slides/tr/nodejs-java/font-selection-sequence/) içinde yer alır. `WhenInaccessible` koşulu, yalnızca Aspose.Slides kaynak yazı tipine erişemediğinde kuralın kullanıldığını belirtir.

**Bir yazı tipi eksik olduğunda ve ikame kuralı yapılandırılmamışsa ne olur?**

Aspose.Slides, font seçim sürecine göre en yakın mevcut yazı tipini seçer. Sonuç, çalışma zaman ortamında mevcut olan yazı tiplerine bağlıdır.

**İkameyi önlemek için harici yazı tipleri yükleyebilir miyim?**

Evet. Aspose.Slides'in render ve dönüşüm sırasında kullanabilmesi için [harici yazı tipleri](/slides/tr/nodejs-java/custom-font/) yükleyebilirsiniz.

**Aspose kitaplık ile birlikte yazı tipleri dağıtıyor mu?**

Hayır. Yazı tiplerini sağlamak ve lisanslarına uymak sizin sorumluluğunuzdadır.

**İkame sonuçları Windows, Linux ve macOS arasında farklılık gösterebilir mi?**

Evet. Yüklü yazı tipleri ve yazı tipi arama konumları işletim sistemine göre değişir; bu yüzden bir makinede mevcut olan bir yazı tipi başka bir makinede ikame gerektirebilir.

**Toplu dönüşümlerde yazı tipi seçiminde tutarlılık nasıl sağlanır?**

Her makine veya konteynerde aynı yazı tipi dosyalarını ve sürümlerini kullanın, [gerekli harici yazı tiplerini](/slides/tr/nodejs-java/custom-font/) yükleyin ve lisans izin veriyorsa [yazı tiplerini gömün](/slides/tr/nodejs-java/embedded-font/). Ayrıca dışa aktarım öncesinde beklenmeyen ikameleri belirlemek için [FontsManager.getSubstitutions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) çağırabilirsiniz.