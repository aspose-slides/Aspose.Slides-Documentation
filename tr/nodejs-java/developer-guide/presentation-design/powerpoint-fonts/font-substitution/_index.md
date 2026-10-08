---
title: JavaScript Kullanarak Sunularda Font İkamesini Yapılandırma
linktitle: Font İkamesi
type: docs
weight: 70
url: /tr/nodejs-java/font-substitution/
keywords:
- "yazı tipi"
- "ikame font"
- "font ikamesi"
- "font değiştirme"
- "font değişimi"
- "ikame kuralı"
- "değişim kuralı"
- "PowerPoint"
- "OpenDocument"
- "sunum"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "PowerPoint ve OpenDocument sunumlarını render ederken veya dönüştürürken, Node.js için Aspose.Slides'te font ikamesi kurallarını yapılandırın ve ikame edilen fontları inceleyin."
---
## **Genel Bakış**

Font ikamesi, Aspose.Slides'in bir sunumu render ederken veya dönüştürürken erişilemeyen bir fontun yerine mevcut bir font kullanmasını sağlar. İkame, oluşturulan çıktıyı etkiler; sunum içeriğine atanan fontu değiştirmez.

Belirli bir font bulunamadığında kullanılacak fontu tanımlayabilir ve Aspose.Slides'in render sırasında yapacağı ikameleri inceleyebilirsiniz. Bu, farklı yüklü fontlara sahip ortamlar arasında çıktının tutarlı kalmasına yardımcı olur.

Eğer bir font mevcut ama ayrı bir kalın tipface'i yoksa, [Dedicated Bold Typeface Olmadan Fontları İşleme](/slides/tr/nodejs-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface) bölümüne bakın. Bu bölüm, PDF dışa aktarımı sırasında etkilenen metnin rasterleştirilmesi ve bunun metin seçimi, arama ve ölçekleme üzerindeki etkilerini açıklar.

## **Font İkamesini Al**

Render sırasında hangi fontların ikame edileceğini belirlemek için [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) yöntemini kullanın. Yöntem, orijinal ve ikame edilen font adlarını tanımlayan [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/) nesnelerini döndürür.

Aşağıdaki JavaScript örneği, bir sunum için tüm font ikamelerini listeler:

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

## **Seçili Slaytlar İçin Font İkamesini Al**

Sadece belirli slaytları render etmek veya dışa aktarmak istediğinizde, slayt indeksleri dizisi ile [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) aşırı yüklemesini kullanarak yalnızca bu slaytlar için gerekli ikameleri inceleyebilirsiniz. Bu, büyük bir sunumu kademeli olarak kontrol ederken, kullanılmayan fontlara bağımlı slaytları bulurken, bir sunucu veya konteyner için minimal bir font paketi hazırlarken veya ilgisiz slaytları işlemeye gerek kalmadan render farklarını teşhis ederken yararlıdır.

Aşırı yükleme, bir Java ilkel tipi `int[]` bekler. Bunu `java.newArray("int", [...])` ile oluşturun; düz bir JavaScript dizisi `Integer[]`'e dönüştürülür ve bu aşırı yükleme ile eşleşmez.

Dizi, bir‑bazlı slayt indeksleri içerir: `1` ilk slaytı tanımlar. Buna karşılık, [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslides/) koleksiyon erişicisi sıfır‑bazlı indeksleme kullanır, bu yüzden aynı slayt `presentation.getSlides().get_Item(0)` ile erişilir. Dizi oluştururken bu farkı aklınızda tutun, aksi takdirde bir‑off‑by‑one hatası ortaya çıkar.

Aşırı yüklemeyi [Presentation.getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getfontsmanager/) üzerinden çağırın. Bu, yalnızca seçili slaytlar render edilirken belirlenen ikameleri döndürür. Her sonuç, orijinal ve ikame edilen font adlarını içeren bir [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/) nesnesidir. Sonuç, geçerli font ortamını, yapılandırılmış yedekleme kurallarını, bir [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/) içinde depolanan ikame kurallarını ve [dışarıdan yüklenen fontları](/slides/tr/nodejs-java/custom-font/) yansıtır.

Aynı ikame birden fazla seçili slayt tarafından istenebilir. Bir font envanteri veya ön‑uç raporu oluştururken sonuçları tekilleştirin. Aşağıdaki örnek, her döndürülen ikameyi raporlar ve ardından benzersiz font eşlemelerinin sıralı bir listesini oluşturur:

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

[FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/) sınıfı her iki aşırı yüklemeyi de sağlar. Render işleminin kapsamına göre birini seçin:

| Aşırı Yükleme | Ne Zaman Kullanılır |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) parametresiz | Tüm sunum için ikameler gerekirken. |
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) bir Java `int[]` slayt indeksleri ile | Belirli bir aralık, kademeli kontrol veya kısmi dışa aktarma için ikameler gerekirken. |

## **Font İkame Kurallarını Ayarla**

Kaynak bir font erişilemez olduğunda Aspose.Slides'in kullanmasını istediğiniz fontu belirtmek için:

1. Sunumu yükleyin.  
2. Kaynak ve ikame fontlar için font tanımları oluşturun.  
3. [WhenInaccessible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstcondition/) koşulu ile bir [FontSubstRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrule/) oluşturun.  
4. Kuralı bir [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/) içine ekleyin.  
5. Koleksiyonu [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/) yöntemiyle atayın.  
6. Sunumu render edin veya dönüştürün.

Aşağıdaki JavaScript örneği, `SomeRareFont` bulunamadığında `Arial` ile ikame eder ve ardından ilk slaytı render ederek sonucu doğrular. İkame fontunun Aspose.Slides tarafından erişilebilir olması gerekir.

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
Sunum boyunca kullanılan fontları koşulsuz olarak değiştirmek için [Font Değiştirme](/slides/tr/nodejs-java/font-replacement/) bölümüne bakın.
{{% /alert %}}

## **Matematik Denklemi Fontları İçin Kısıtlamalar**

Font ikame kuralları, render ve dönüşüm sırasında kullanılan standart font seçme sürecinin bir parçasıdır. Aspose.Slides bir erişilemez fontu, kuralda belirtilen mevcut fontla değiştirebildiğinde düzenli metin için çalışırlar.

Office Math denklemlerinin ek bir gereksinimi vardır. Bir denklem **Cambria Math** kullanıyorsa, Aspose.Slides denklemin yerleşimini hesaplamak ve render etmek için tam olarak bu fonta ihtiyaç duyabilir. **STIX Two Math** gibi başka bir matematik fontunu ikame eden bir kural, bu amaçla **Cambria Math**'i değiştiremez ve render hâlâ **Cambria Math**'in gerekli olduğunu bildirebilir.

Böyle bir sunumu render ya da dönüştürmek için **Cambria Math**'i Aspose.Slides'e sunun. İşletim sistemine kurun veya bir [external font](/slides/tr/nodejs-java/custom-font/) olarak yükleyin.

Bu sınırlama yalnızca denklemlerin yerleşimini etkiler. Yukarıda açıklanan ikame kuralları normal sunum metni için hâlâ geçerlidir.

## **SSS**

**Font değiştirme ile font ikamesi arasındaki fark nedir?**

[Font replacement](/slides/tr/nodejs-java/font-replacement/) sunum boyunca bir fontu başka bir fontla kasıtlı olarak değiştirir. Font ikamesi ise, konfigüre edilmiş koşul (ör. kaynak font mevcut değil) karşılandığında render çıktısı için bir font seçer.

**İkame kuralları ne zaman uygulanır?**

Kurallar, render ve dönüşüm sırasında [font selection sequence](/slides/tr/nodejs-java/font-selection-sequence/) içinde yer alır. `WhenInaccessible` kullanıldığında, kural yalnızca Aspose.Slides kaynak fonta erişemediğinde devreye girer.

**Bir font eksik ve ikame kuralı tanımlı değilse ne olur?**

Aspose.Slides, font seçim sürecine göre en yakın mevcut fontu seçer. Sonuç, çalışma zamanındaki mevcut fontlara bağlıdır.

**İkameyi önlemek için dış fontlar yükleyebilir miyim?**

Evet. Aspose.Slides'in render ve dönüşüm sırasında kullanabilmesi için [external fontları yükleyebilirsiniz](/slides/tr/nodejs-java/custom-font/).

**Aspose kütüphaneyle birlikte fontları dağıtıyor mu?**

Hayır. Fontları temin etmek ve lisans şartlarına uymak sizin sorumluluğunuzdadır.

**İkame sonuçları Windows, Linux ve macOS arasında farklılık gösterebilir mi?**

Evet. Yüklü fontlar ve font arama konumları işletim sistemine göre değişir; bir makinede mevcut olan bir font, başka bir makinede ikame gerektirebilir.

**Toplu dönüşümlerde font seçiminin tutarlı olmasını nasıl sağlayabilirim?**

Her makine veya konteynerde aynı font dosyalarını ve sürümlerini kullanın, [gereken dış fontları yükleyin](/slides/tr/nodejs-java/custom-font/) ve lisans izin veriyorsa [fontları gömün](/slides/tr/nodejs-java/embedded-font/). Ayrıca, beklenmeyen ikameleri önceden belirlemek için dışa aktarmadan önce [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) yöntemini çağırabilirsiniz.