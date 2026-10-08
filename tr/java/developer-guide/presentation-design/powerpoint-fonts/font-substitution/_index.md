---
title: Java Kullanarak Sunumlarda Yazı Tipi İkamesini Yapılandırma
linktitle: Yazı Tipi İkamesi
type: docs
weight: 70
url: /tr/java/font-substitution/
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
- Java
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını oluştururken veya dönüştürürken, Aspose.Slides for Java’da yazı tipi ikame kurallarını yapılandırın ve ikame edilen yazı tiplerini inceleyin."
---
## **Genel Bakış**

Yazı tipi ikamesi, Aspose.Slides’ın bir sunum oluşturulurken veya dönüştürülürken erişilemeyen bir yazı tipinin yerine mevcut bir yazı tipini kullanmasını sağlar. İkame, oluşturulan çıktıyı etkiler; sunum içeriğine atanmış yazı tipini değiştirmez.

Belirli bir yazı tipi kullanılabilir olmadığında kullanılacak yazı tipini tanımlayabilir ve Aspose.Slides’ın oluşturma sırasında yapacağı ikameleri inceleyebilirsiniz. Bu, farklı yüklü yazı tiplerine sahip ortamlar arasında çıktının tutarlı kalmasına yardımcı olur.

Bir yazı tipi mevcut ancak özel bir kalın yazı tipi yoksa, [Özel Kalın Yazı Tipi Olmadan Yazı Tiplerini İşleme](/slides/tr/java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface) bölümüne bakın. Bu bölüm, PDF dışa aktarımı sırasında etkilenen metnin rasterleştirilmesi ve metin seçimi, arama ve ölçekleme üzerindeki sonuçları açıklar.

## **Yazı Tipi İkame Alımı**

[IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) yöntemini kullanarak sunum oluşturulurken hangi yazı tiplerinin ikame edileceğini belirleyin. Yöntem, orijinal ve ikame edilen yazı tipi adlarını tanımlayan [FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/) nesnelerini döndürür.

Aşağıdaki Java örneği bir sunum için tüm yazı tipi ikamelerini listeler:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **Seçili Slaytlar İçin Yazı Tipi İkame Alımı**

`int[] slides` argümanı ile [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) aşırı yüklemesini kullanarak yalnızca belirli slaytları oluşturmak için gereken ikameleri inceleyin. Bu, bir sunumun yalnızca bir bölümünü oluştururken veya dışa aktarırken, büyük bir sunumu artımlı olarak kontrol ederken, kullanılmayan yazı tiplerine bağımlı slaytları bulurken, bir sunucu veya konteyner için minimum bir yazı tipi paketi hazırlarken veya ilgisiz slaytları işlemadan oluşturma farklarını teşhis ederken yararlıdır.

`slides` dizisi bir‑tabanlı slayt indeksleri içerir: `1` ilk slaytı tanımlar. Buna karşılık, [Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) koleksiyon erişicisi sıfır‑tabanlı indeksleme kullanır; aynı slayt `presentation.getSlides().get_Item(0)` şeklinde erişilir. Dizi oluştururken bu farkı akılda tutarak bir‑off‑by‑one hatasından kaçının.

Aşırı yüklemeyi [Presentation.getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getFontsManager--) yöntemiyle çağırın. Bu, yalnızca seçili slaytlar oluşturulurken belirlenen ikameleri döndürür. Her sonuç, orijinal ve ikame edilen yazı tipi adlarını içeren bir [FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/) nesnesidir. Sonuç, geçerli yazı tipi ortamını, yapılandırılmış geri dönüş kurallarını ve [dış yazı tiplerini](/slides/tr/java/custom-font/) yansıtır. [IFontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsubstrulecollection/) içinde depolanan ikame kuralları sunum oluşturulurken uygulanır, ancak sonuçta listelenmez; bunun yerine çıkış dosyasındaki yazı tiplerini kontrol edin.

Aynı ikame birden fazla seçili slayt tarafından gerekebilir. Yazı tipi envanteri veya ön uç raporu oluştururken sonuçları tekilleştirin. Aşağıdaki örnek her döndürülen ikameyi rapor eder ve ardından benzersiz yazı tipi eşlemelerinin sıralı bir listesini oluşturur:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;
import java.util.TreeSet;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int[] selectedSlides = { 1, 3, 5 };
    List<FontSubstitutionInfo> substitutions = new ArrayList<>();
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions(selectedSlides)) {
        substitutions.add(substitution);
    }

    System.out.println("Substitutions for the selected slides:");
    for (FontSubstitutionInfo substitution : substitutions) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }

    Set<String> sortedPreflightEntries = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
    for (FontSubstitutionInfo substitution : substitutions) {
        String entry = substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
        sortedPreflightEntries.add(entry);
    }

    System.out.println("Deduplicated font preflight report:");
    for (String entry : sortedPreflightEntries) {
        System.out.println(entry);
    }
} finally {
    presentation.dispose();
}
```

[IFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/) arabirimi her iki aşırı yüklemeyi de sağlar. Oluşturma işleminin kapsamına göre birini seçin:

| Aşırı Yükleme | Ne zaman kullanılır |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) parametresiz | Tüm sunum için ikameler gerekirken. |
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) `int[] slides` ile | Seçili bir aralık, artımlı kontrol veya kısmi dışa aktarım gerekirken. |

## **Yazı Tipi İkame Kurallarını Belirleme**

Kaynak bir yazı tipi mevcut olmadığında Aspose.Slides’ın hangi yazı tipini kullanması gerektiğini belirtmek için:

1. Sunumu yükleyin.
2. Kaynak ve ikame yazı tipleri için yazı tipi tanımları oluşturun.
3. [WhenInaccessible](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstcondition/) koşuluyla bir [FontSubstRule](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrule/) oluşturun.
4. Kuralı bir [FontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrulecollection/) içine ekleyin.
5. Koleksiyonu [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) yöntemiyle atayın.
6. Sunumu oluşturun veya dönüştürün.

Aşağıdaki Java örneği, `SomeRareFont` mevcut olmadığında `Arial` ile ikame eder ve ardından ilk slaytı oluşturup sonucu doğrular. İkame yazı tipinin Aspose.Slides tarafından erişilebilir olması gerekir.

```java
import com.aspose.slides.FontData;
import com.aspose.slides.FontSubstCondition;
import com.aspose.slides.FontSubstRule;
import com.aspose.slides.FontSubstRuleCollection;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontSubstRule;
import com.aspose.slides.IFontSubstRuleCollection;
import com.aspose.slides.IImage;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData substituteFont = new FontData("Arial");
    IFontSubstRule substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection substitutionRules = new FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    IImage image = presentation.getSlides().get_Item(0).getImage(1f, 1f);
    try {
        image.save("slide.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Tamamen sunum boyunca kullanılan yazı tiplerinde koşulsuz bir değişiklik için, [Yazı Tipi Değiştirme](/slides/tr/java/font-replacement/) bölümüne bakın.
{{% /alert %}}

## **Matematik Denklemi Yazı Tipleri İçin Sınırlamalar**

Yazı tipi ikame kuralları, oluşturma ve dönüştürme sırasında kullanılan standart yazı tipi seçim sürecinin bir parçasıdır. Aspose.Slides bir erişilemeyen yazı tipini kuralda belirtilen mevcut bir yazı tipiyle değiştirebildiğinde normal metin için çalışırlar.

Office Math denklemleri ek bir gereksinime sahiptir. Bir denklem **Cambria Math** kullanıyorsa, Aspose.Slides denklemin düzenini hesaplamak ve oluşturmak için tam olarak bu yazı tipine ihtiyaç duyabilir. **STIX Two Math** gibi başka bir matematik yazı tipini ikame eden bir kural, bu amaçla **Cambria Math** yerine geçemez ve oluşturma hâlâ **Cambria Math**’in gerektiğini rapor edebilir.

Böyle bir sunumu oluşturmak veya dönüştürmek için **Cambria Math**’i Aspose.Slides’a erişilebilir hâle getirin. İşletim sistemine kurun veya bir [dış yazı tipi](/slides/tr/java/custom-font/) olarak yükleyin.

Bu sınırlama yalnızca denklem düzeni için geçerlidir. Yukarıda açıklanan ikame kuralları normal sunum metni için hâlâ geçerlidir.

## **SSS**

**Yazı tipi değiştirme ile yazı tipi ikamesi arasındaki fark nedir?**  
[Yazı Tipi Değiştirme](/slides/tr/java/font-replacement/) sunum boyunca bir yazı tipini bir diğeriyle kasıtlı olarak değiştirir. Yazı tipi ikamesi, orijinal yazı tipi mevcut olmadığında, oluşturulan çıktı için bir yazı tipi seçer.

**İkame kuralları ne zaman uygulanır?**  
Kurallar, oluşturma ve dönüştürme sırasında [yazı tipi seçme sırası](/slides/tr/java/font-selection-sequence/) içinde yer alır. `WhenInaccessible` koşulu ile bir kural yalnızca Aspose.Slides kaynak yazı tipine erişemediğinde kullanılır.

**Bir yazı tipi eksik olduğunda ve hiçbir ikame kuralı yapılandırılmadığında ne olur?**  
Aspose.Slides, yazı tipi seçim sürecine göre en yakın mevcut yazı tipini seçer. Sonuç, çalışma zamanı ortamında mevcut olan yazı tiplerine bağlıdır.

**İkameyi önlemek için dış yazı tipleri yükleyebilir miyim?**  
Evet. Aspose.Slides’ın oluşturma ve dönüştürme sırasında kullanabilmesi için [dış yazı tiplerini yükleyebilirsiniz](/slides/tr/java/custom-font/).

**Aspose kütüphane ile birlikte yazı tiplerini dağıtıyor mu?**  
Hayır. Yazı tiplerini siz sağlamalısınız ve lisanslarına uymalısınız.

**İkame sonuçları Windows, Linux ve macOS arasında farklılık gösterebilir mi?**  
Evet. Yüklü yazı tipleri ve yazı tipi arama konumları işletim sistemine göre değişir; bir makinede mevcut olan bir yazı tipi, başka bir makinede ikame gerektirebilir.

**Toplu dönüştürmelerde yazı tipi seçimimini tutarlı nasıl yaparım?**  
Her makine veya konteynerde aynı yazı tipi dosyalarını ve sürümlerini kullanın, [gerekli dış yazı tiplerini yükleyin](/slides/tr/java/custom-font/), ve lisans izin veriyorsa [yazı tiplerini gömün](/slides/tr/java/embedded-font/). Ayrıca dışa aktarmadan önce [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) metodunu çağırarak beklenmeyen ikameleri belirleyebilirsiniz.