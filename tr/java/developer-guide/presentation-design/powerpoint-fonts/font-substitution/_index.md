---
title: Java Kullanarak Sunumlarda Yazı Tipi İkamesi Yapılandırma
linktitle: Yazı Tipi İkamesi
type: docs
weight: 70
url: /tr/java/font-substitution/
keywords:
- yazı tipi
- ikame yazı tipi
- yazı tipi ikamesi
- yazı tipini değiştir
- yazı tipi değişimi
- ikame kuralı
- değişim kuralı
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını renderlarken veya dönüştürürken Java için Aspose.Slides'te yazı tipi ikamesi kurallarını yapılandırın ve ikame edilen yazı tiplerini inceleyin."
---
## **Genel Bakış**

Yazı tipi ikamesi, Aspose.Slides'in bir sunum renderlandığında veya dönüştürüldüğünde erişilemeyen bir yazı tipinin yerine kullanılabilir bir yazı tipini kullanmasını sağlar. İkame, renderlanan çıktıyı etkiler; sunum içeriğine atanmış yazı tipini değiştirmez.

Belirli bir yazı tipi mevcut olmadığında kullanılacak yazı tipini tanımlayabilir ve Aspose.Slides'in render sırasında yapacağı ikameleri inceleyebilirsiniz. Bu, farklı yüklü yazı tiplerine sahip ortamlarda çıktının tutarlı kalmasına yardımcı olur.

## **Yazı Tipi İkame İşlemlerini Alın**

Render sırasında hangi yazı tiplerinin ikame edileceğini belirlemek için [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) yöntemini kullanın. Yöntem, orijinal ve ikame yazı tipi adlarını tanımlayan [FontSubstitutionInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsubstitutioninfo/) nesnelerini döndürür.

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

## **Seçili Slaytlar İçin Yazı Tipi İkamesi Alın**

`int[] slides` argümanı ile [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) aşırı yüklemesini kullanarak yalnızca belirli slaytları renderlemek için gereken ikameleri inceleyin. Bu, bir sunumun bir kısmını renderlarken veya dışa aktarırken, büyük bir sunumu artımlı olarak kontrol ederken, mevcut olmayan yazı tiplerine bağımlı slaytları bulurken, bir sunucu veya konteyner için minimum bir yazı tipi paketi hazırlarken veya ilgisiz slaytları işlemeden render farklarını teşhis ederken faydalıdır.

`slides` dizisi bir‑bazlı slayt dizinleri içerir: `1` ilk slaytı belirtir. Buna karşılık, [Presentation.getSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getSlides--) koleksiyon erişicisi sıfır‑bazlı indeksleme kullanır; bu nedenle aynı slayt `presentation.getSlides().get_Item(0)` olarak erişilir. Dizi oluştururken bu farkı akılda tutun, aksi takdirde bir‑birlik hatası oluşabilir.

Aşırı yüklemeyi [Presentation.getFontsManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getFontsManager--) yöntemiyle çağırın. Yalnızca seçili slaytların render edilmesi sırasında belirlenen ikameleri döndürür. Her sonuç, orijinal ve ikame yazı tipi adlarını içeren bir [FontSubstitutionInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsubstitutioninfo/) nesnesidir. Sonuç, mevcut yazı tipi ortamını, yapılandırılmış geri dönüş kurallarını, bir [IFontSubstRuleCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontsubstrulecollection/) içinde depolanan ikame kurallarını ve [dışarıdan yüklenen yazı tiplerini](/slides/tr/java/custom-font/) yansıtır.

Aynı ikame birden fazla seçili slayt tarafından istenebilir. Bir yazı tipi envanteri veya ön uç raporu oluştururken sonuçları tekilleştirin. Aşağıdaki örnek, döndürülen her ikameyi raporlar ve ardından eşsiz yazı tipi eşlemelerinin sıralı bir listesini oluşturur:

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

[IFontsManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontsmanager/) arayüzü her iki aşırı yüklemeyi de sağlar. Renderleme işleminin kapsamına göre birini seçin:

| Aşırı Yükleme | Ne Zaman Kullanılır |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) parametresiz | Tüm sunum için ikameler gerekirken. |
| [getSubstitutions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) `int[] slides` ile | Seçili bir aralık, artımlı kontrol veya kısmi dışa aktarım için ikameler gerekirken. |

## **Yazı Tipi İkame Kurallarını Ayarlama**

Kaynak bir yazı tipi mevcut olmadığında Aspose.Slides'in kullanması gereken yazı tipini belirtmek için:

1. Sunumu yükleyin.
2. Kaynak ve ikame yazı tipleri için yazı tipi tanımları oluşturun.
3. [WhenInaccessible](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsubstcondition/) koşuluyla bir [FontSubstRule](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsubstrule/) oluşturun.
4. Kuralı bir [FontSubstRuleCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsubstrulecollection/) içine ekleyin.
5. Koleksiyonu [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) yöntemiyle atayın.
6. Sunumu renderleyin veya dönüştürün.

Aşağıdaki Java örneği, `SomeRareFont` mevcut olmadığında `Arial` ile ikame eder ve sonucu doğrulamak için ilk slaytı renderler. İkame yazı tipinin Aspose.Slides tarafından erişilebilir olması gerekir.

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

{{% alert color="info" title="Not" %}}
Sunum boyunca kullanılan yazı tiplerinde koşulsuz bir değişiklik yapmak için [Yazı Tipi Değiştirme](/slides/tr/java/font-replacement/) bölümüne bakın.
{{% /alert %}}

## **Matematik Denklemi Yazı Tipleri İçin Kısıtlamalar**

Yazı tipi ikame kuralları, render ve dönüşüm sırasında kullanılan standart yazı tipi seçim sürecinin bir parçasıdır. Aspose.Slides, bir kural tarafından belirtilen mevcut bir yazı tipine erişilemeyen bir yazı tipini yerine koyabildiğinde normal metin için çalışır.

Office Math denklemlerinin ek bir gereksinimi vardır. Bir denklem **Cambria Math** kullanıyorsa, Aspose.Slides denklemin düzenini hesaplamak ve renderlemek için tam olarak bu yazı tipine ihtiyaç duyabilir. **STIX Two Math** gibi başka bir matematik yazı tipine ikame eden bir kural, bu amaçla **Cambria Math**'i değiştiremez ve render hâlâ **Cambria Math** gerektiğini bildirebilir.

Böyle bir sunumu renderlemek veya dönüştürmek için **Cambria Math**'i Aspose.Slides'e sunmanız gerekir. İşletim sistemine kurun veya bir [dış yazı tipi](/slides/tr/java/custom-font/) olarak yükleyin.

Bu kısıtlama yalnızca denklem düzeni içindir. Yukarıda açıklanan ikame kuralları normal sunum metni için hâlâ geçerlidir.

## **SSS**

**Yazı tipi değişimi ile yazı tipi ikamesi arasındaki fark nedir?**

[Font replacement](/slides/tr/java/font-replacement/) bir sunum boyunca bir yazı tipini başka birine kasıtlı olarak değiştirir. Yazı tipi ikamesi, yapılandırılmış koşul karşılandığında (ör. orijinal yazı tipi mevcut olmadığında) render çıktısı için bir yazı tipi seçer.

**İkame kuralları ne zaman uygulanır?**

Kurallar, render ve dönüşüm sırasında [font selection sequence](/slides/tr/java/font-selection-sequence/) sürecine katılır. `WhenInaccessible` ile bir kural, Aspose.Slides kaynak yazı tipine erişemediğinde yalnızca o zaman kullanılır.

**Bir yazı tipi eksik ve ikame kuralı yapılandırılmamışsa ne olur?**

Aspose.Slides, font seçim sürecine göre en yakın mevcut yazı tipini seçer. Sonuç, çalışma zaman ortamında bulunan yazı tiplerine bağlıdır.

**İkameyi önlemek için dış yazı tipleri yükleyebilir miyim?**

Evet. Render ve dönüşüm sırasında Aspose.Slides'in kullanabilmesi için [dış yazı tipleri yükleyebilir](/slides/tr/java/custom-font/) siz.

**Aspose kütüphane ile birlikte yazı tiplerini dağıtıyor mu?**

Hayır. Yazı tiplerini siz temin etmeli ve lisans koşullarına uymalısınız.

**İkame sonuçları Windows, Linux ve macOS arasında farklılık gösterebilir mi?**

Evet. Yüklü yazı tipleri ve arama konumları işletim sistemine göre değişir; bir makinede mevcut olan bir yazı tipi başka bir makinede ikame gerektirebilir.

**Toplu dönüşümlerde yazı tipi seçimlerini tutarlı nasıl tutarım?**

Her makine veya konteynerde aynı yazı tipi dosyalarını ve sürümlerini kullanın, [gerekli dış yazı tiplerini yükleyin](/slides/tr/java/custom-font/) ve lisans izin veriyorsa [yazı tiplerini gömün](/slides/tr/java/embedded-font/). Ayrıca, beklenmeyen ikameleri belirlemek için dışa aktarmadan önce [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) yöntemini çağırabilirsiniz.