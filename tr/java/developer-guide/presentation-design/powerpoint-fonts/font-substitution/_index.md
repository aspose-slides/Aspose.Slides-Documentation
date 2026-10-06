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
- yazı tipini değiştir
- yazı tipi değiştirme
- ikame kuralı
- değiştirme kuralı
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını render ederken veya dönüştürürken, Java için Aspose.Slides içinde yazı tipi ikame kurallarını yapılandırın ve ikame edilen yazı tiplerini inceleyin."
---
## **Genel Bakış**

Yazı tipi ikamesi, Aspose.Slides'ın bir sunum render edildiğinde veya dönüştürüldüğünde erişilemeyen bir yazı tipinin yerine mevcut bir yazı tipini kullanmasını sağlar. İkame, render edilen çıktıyı etkiler; sunum içeriğine atanan yazı tipini değiştirmez.

Belirli bir yazı tipi kullanılamadığında kullanılacak yazı tipini tanımlayabilirsiniz ve Aspose.Slides'ın render sırasında yapacağı ikameleri inceleyebilirsiniz. Bu, farklı yüklü yazı tiplerine sahip ortamlar arasında çıktının tutarlı olmasına yardımcı olur.

## **Yazı Tipi İkamelelerini Al**

Sunum render edildiğinde hangi yazı tiplerinin ikame edileceğini belirlemek için [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) yöntemini kullanın. Yöntem, orijinal ve ikame edilen yazı tipi adlarını belirten [FontSubstitutionInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsubstitutioninfo/) nesnelerini döndürür.

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

## **Seçili Slaytlar İçin Yazı Tipi İkamelelerini Al**

Belirli slaytların render edilmesi için gerekli ikameleri yalnızca incelemek üzere `int[] slides` argümanıyla [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) aşırı yüklemesini kullanın. Bu, bir sunumun bir kısmını render ederken veya dışa aktarırken, büyük bir sunumu artımlı olarak kontrol ederken, kullanılabilir olmayan yazı tiplerine bağımlı slaytları bulurken, sunucu veya konteyner için minimal bir yazı tipi paketi hazırlarken ya da ilgili olmayan slaytları işlemeden render farklarını tanıdiagnostik ederken faydalıdır.

`slides` dizisi bir‑tabanlı slayt indeksleri içerir: `1` ilk slaytı tanımlar. Buna karşılık, [Presentation.getSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getSlides--) koleksiyon erişicisi sıfır‑tabanlı indeksleme kullanır, bu nedenle aynı slayt `presentation.getSlides().get_Item(0)` şeklinde erişilir. Dizi oluştururken bu farkı akılda tutarak bir‑off hatasından kaçının.

Aşırı yüklemeyi [Presentation.getFontsManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getFontsManager--) yöntemiyle çağırın. Yalnızca seçili slaytların render edilmesi sırasında belirlenen ikameleri döndürür. Her sonuç, orijinal ve ikame edilen yazı tipi adlarını içeren bir [FontSubstitutionInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsubstitutioninfo/) nesnesidir. Sonuç, mevcut yazı tipi ortamını, yapılandırılmış geri dönüş kurallarını ve [externally loaded fonts](/slides/tr/java/custom-font/) yansıtır. Bir [IFontSubstRuleCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontsubstrulecollection/) içinde depolanan ikame kuralları sunum render edildiğinde uygulanır, ancak sonuçta listelenmez; bunun yerine çıktı dosyasındaki yazı tiplerini kontrol edin.

Aynı ikame birden fazla seçili slayt tarafından istenebilir. Bir yazı tipi envanteri veya ön uç raporu oluştururken sonuçları tekilleştirin. Aşağıdaki örnek her döndürülen ikameyi raporlar ve ardından benzersiz yazı tipi eşlemelerinin sıralı bir listesini oluşturur:

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

[IFontsManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontsmanager/) arabirimi her iki aşırı yüklemeyi de sağlar. Render işleminin kapsamına göre birini seçin:

| Aşırı Yükleme | Ne Zaman Kullanılır |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) argümansız | Sunumun tamamı için ikameler gerekir. |
| [getSubstitutions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) `int[] slides` ile | Seçili bir aralık, artımlı kontrol veya kısmi dışa aktarım için ikameler gerekir. |

## **Yazı Tipi İkame Kurallarını Ayarla**

Kaynak bir yazı tipi kullanılamadığında Aspose.Slides'ın kullanması gereken yazı tipini belirtmek için:

1. Sunumu yükleyin.
2. Kaynak ve ikame yazı tipleri için yazı tipi tanımlamaları oluşturun.
3. [WhenInaccessible](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsubstcondition/) koşulu ile bir [FontSubstRule](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsubstrule/) oluşturun.
4. Kuralı bir [FontSubstRuleCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsubstrulecollection/) koleksiyonuna ekleyin.
5. Koleksiyonu [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) yöntemini kullanarak atayın.
6. Sunumu render edin veya dönüştürün.

Aşağıdaki Java örneği `SomeRareFont` kullanılamadığında `Arial` ile ikame eder ve ardından sonucu doğrulamak için ilk slaytı render eder. İkame yazı tipi Aspose.Slides tarafından kullanılabilir olmalıdır.

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
Bir sunum boyunca kullanılan yazı tiplerinde koşulsuz bir değişiklik için, [Font Replacement](/slides/tr/java/font-replacement/) bölümüne bakın.
{{% /alert %}}

## **Matematik Denklem Yazı Tipleri İçin Sınırlamalar**

Yazı tipi ikame kuralları, render ve dönüşüm sırasında kullanılan standart yazı tipi seçim sürecinin bir parçasıdır. Bir kural tarafından belirtilen mevcut bir yazı tipiyle erişilemeyen bir yazı tipini değiştirebildikleri sürece normal metinlerde çalışırlar.

Office Math denklemlerinin ek bir gereksinimi vardır. Bir denklem **Cambria Math** kullanıyorsa, Aspose.Slides denklemin düzenini hesaplamak ve render etmek için o tam yazı tipine ihtiyaç duyabilir. **STIX Two Math** gibi başka bir matematik yazı tipini ikame eden bir kural, bu amaçla **Cambria Math**'i değiştiremez ve render hâlâ **Cambria Math**'in gerekli olduğunu bildirebilir.

Böyle bir sunumu render etmek veya dönüştürmek için **Cambria Math**'i Aspose.Slides'a kullanılabilir hâle getirin. İşletim sistemine kurun veya bir [external font](/slides/tr/java/custom-font/) olarak yükleyin.

Bu sınırlama sadece denklem düzeni için geçerlidir. Yukarıda açıklanan ikame kuralları normal sunum metni için hâlâ geçerlidir.

## **SSS**

**Yazı tipi değişimi ile yazı tipi ikamesi arasındaki fark nedir?**  
[Font replacement](/slides/tr/java/font-replacement/) sunum boyunca bir yazı tipini başka birine kasıtlı olarak değiştirir. Yazı tipi ikamesi, yapılandırılmış koşul karşılandığında (örneğin orijinal yazı tipi mevcut değilse) render edilen çıktıya bir yazı tipi seçer.

**İkame kuralları ne zaman uygulanır?**  
Kurallar, render ve dönüşüm sırasında [font selection sequence](/slides/tr/java/font-selection-sequence/) içinde yer alır. `WhenInaccessible` koşulu ile bir kural yalnızca Aspose.Slides kaynak yazı tipine erişemediğinde kullanılır.

**Bir yazı tipi eksik olduğunda ve hiçbir ikame kuralı yapılandırılmadığında ne olur?**  
Aspose.Slides, font seçim sürecine göre mevcut en yakın yazı tipini seçer. Sonuç, çalışma zaman ortamında bulunan yazı tiplerine bağlıdır.

**İkameyi önlemek için harici yazı tipleri yükleyebilir miyim?**  
Evet. Render ve dönüşüm sırasında kullanabilmesi için [external fonts](/slides/tr/java/custom-font/) yükleyebilirsiniz.

**Aspose, kütüphane ile birlikte yazı tipleri dağıtıyor mu?**  
Hayır. Yazı tiplerini sağlamaktan ve lisans koşullarına uymaktan siz sorumlusunuz.

**İkame sonuçları Windows, Linux ve macOS arasında farklılık gösterebilir mi?**  
Evet. Yüklü yazı tipleri ve arama konumları işletim sistemine göre değişir; bir makinede mevcut olan bir yazı tipi başka bir makinada ikame gerektirebilir.

**Toplu dönüşümlerde font seçimlerini tutarlı nasıl yapabilirim?**  
Her makine veya konteynerde aynı yazı tipi dosyalarını ve sürümlerini kullanın, gerekli harici yazı tiplerini [load required external fonts](/slides/tr/java/custom-font/) ile yükleyin ve lisans izin veriyorsa [embed fonts](/slides/tr/java/embedded-font/) kullanın. İhracattan önce beklenmedik ikameleri tespit etmek için [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) yöntemini çağırabilirsiniz.