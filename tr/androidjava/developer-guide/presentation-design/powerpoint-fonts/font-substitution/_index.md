---
title: Android'de Sunumlarda Yazı Tipi İkamesini Yapılandırma
linktitle: Yazı Tipi İkamesi
type: docs
weight: 70
url: /tr/androidjava/font-substitution/
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
- Android
- Java
- Aspose.Slides
description: "Sunumları oluştururken veya dönüştürürken Java aracılığıyla Aspose.Slides for Android'de yazı tipi ikame kurallarını yapılandırın ve ikame edilen yazı tiplerini inceleyin."
---
## **Genel Bakış**

Yazı tipi ikamesi, Aspose.Slides'in bir sunum oluşturulurken veya dönüştürülürken erişilemeyen bir yazı tipinin yerine mevcut bir yazı tipini kullanmasını sağlar. İkame, oluşturulan çıktıyı etkiler; sunum içeriğine atanmış yazı tipini değiştirmez.

Belirli bir yazı tipi kullanılamadığında kullanılacak yazı tipini tanımlayabilir ve Aspose.Slides'in oluşturma sırasında yapacağı ikameleri inceleyebilirsiniz. Bu, farklı Android cihazları ve çeşitli mevcut yazı tiplerine sahip ortamlar arasında çıktının tutarlı kalmasına yardımcı olur.

## **Yazı Tipi İkamelarını Al**

Sunum oluşturulurken hangi yazı tiplerinin ikame edileceğini belirlemek için [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) metodunu kullanın. Metod, orijinal ve ikame edilen yazı tipi adlarını tanımlayan [FontSubstitutionInfo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsubstitutioninfo/) nesnelerini döndürür.

Aşağıdaki Java örneği, bir sunum için tüm yazı tipi ikamelarını listeler:

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

## **Seçili Slaytlar İçin Yazı Tipi İkamelarını Al**

Belirli slaytları oluşturmak için gerekli ikameleri yalnızca incelemek üzere `int[] slides` parametresiyle [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) aşırı yüklemesini kullanın. Bu, bir sunumun bir kısmını oluştururken veya dışa aktarırken, büyük bir sunumu artımlı olarak kontrol ederken, kullanılabilir olmayan yazı tiplerine bağımlı slaytları bulurken, bir Android uygulaması için minimal bir yazı tipi paketi hazırlarken veya ilgisiz slaytları işlemeden oluşturma farklarını teşhis ederken faydalıdır.

`slides` dizisi bir‑tabanlı slayt indeksleri içerir: `1` ilk slaytı tanımlar. Buna karşılık, [Presentation.getSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getSlides--) koleksiyon erişicisi sıfır‑tabanlı indeksleme kullanır, bu yüzden aynı slayt `presentation.getSlides().get_Item(0)` şeklinde erişilir. Dizi oluştururken bu farkı akılda tutarak bir‑bir hatasından kaçının.

Bu aşırı yüklemeyi [Presentation.getFontsManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getFontsManager--) metodu aracılığıyla çağırın. Yalnızca seçili slaytların oluşturulması sırasında belirlenen ikameleri döndürür. Her sonuç, orijinal ve ikame edilen yazı tipi adlarını içeren bir [FontSubstitutionInfo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsubstitutioninfo/) nesnesidir. Sonuç, geçerli yazı tipi ortamını, yapılandırılmış geri dönüş kurallarını, bir [IFontSubstRuleCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifontsubstrulecollection/) içinde depolanan ikame kurallarını ve [externally loaded fonts](/slides/tr/androidjava/custom-font/) yansıtır.

Aynı ikame, birden fazla seçili slayt tarafından istenebilir. Yazı tipi envanteri veya ön uç raporu oluştururken sonuçları tekilleştirin. Aşağıdaki örnek, döndürülen her ikameyi raporlar ve ardından benzersiz yazı tipi eşleştirmelerinin sıralı bir listesini oluşturur:

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

[IFontsManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifontsmanager/) arabirimi her iki aşırı yüklemeyi de sağlar. Oluşturma işleminin kapsamına göre birini seçin:

| Overload | Use it when |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) with no arguments | Sunumun tamamı için ikameler gerektiğinde. |
| [getSubstitutions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) with `int[] slides` | Seçili bir aralık, artımlı kontrol veya kısmi dışa aktarım gerektiğinde. |

## **Yazı Tipi İkame Kurallarını Ayarla**

Kaynak bir yazı tipi kullanılamadığında Aspose.Slides'in kullanması gereken yazı tipini belirtmek için:

1. Sunumu yükleyin.  
2. Kaynak ve ikame yazı tipleri için yazı tipi tanımlamaları oluşturun.  
3. [WhenInaccessible](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsubstcondition/) koşulu ile bir [FontSubstRule](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsubstrule/) oluşturun.  
4. Kuralı bir [FontSubstRuleCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsubstrulecollection/)’a ekleyin.  
5. Koleksiyonu, [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) metodunu kullanarak atayın.  
6. Sunumu oluşturun veya dönüştürün.

Aşağıdaki Java örneği, `SomeRareFont` kullanılamadığında `Arial` ile ikame eder ve ardından sonucu doğrulamak için ilk slaytı oluşturur. İkame yazı tipi Aspose.Slides tarafından kullanılabilir olmalıdır.

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
Bir sunum boyunca kullanılan yazı tiplerinde koşulsuz bir değişiklik için, [Font Replacement](/slides/tr/androidjava/font-replacement/) bölümüne bakın.
{{% /alert %}}

## **Matematik Denklemi Yazı Tipleri İçin Sınırlamalar**

Yazı tipi ikame kuralları, oluşturma ve dönüştürme sırasında kullanılan standart yazı tipi seçme sürecinin bir parçasıdır. Aspose.Slides, erişilemeyen bir yazı tipini kural tarafından belirtilen mevcut bir yazı tipi ile değiştirebildiğinde, bu kurallar normal metin için çalışır.

Office Math denklemleri ek bir gereksinime sahiptir. Bir denklem **Cambria Math** kullanıyorsa, Aspose.Slides bu denklemin düzenini hesaplamak ve oluşturmak için tam olarak bu yazı tipine ihtiyaç duyabilir. **STIX Two Math** gibi başka bir matematik yazı tipini ikame eden bir kural, bu amaçla **Cambria Math**'i değiştiremez ve oluşturma hâlâ **Cambria Math**'in gerekli olduğunu bildirebilir.

Bu tür bir sunumu oluşturmak veya dönüştürmek için **Cambria Math**'i Aspose.Slides'e kullanılabilir hâle getirin. Uygulamanın oluşturma ve dönüştürme sırasında kullanabilmesi için onu bir [external font](/slides/tr/androidjava/custom-font/) olarak yükleyin.

Bu sınırlama denklem düzeni için geçerlidir. Yukarıda açıklanan ikame kuralları normal sunum metinlerine hâlâ uygulanır.

## **SSS**

**Yazı Tipi Değiştirme ile Yazı Tipi İkamesi arasındaki fark nedir?**

[Font replacement](/slides/tr/androidjava/font-replacement/) sunum boyunca bir yazı tipini kasıtlı olarak başka birine değiştirir. Yazı tipi ikamesi, yapılandırılmış koşul sağlandığında (örneğin, orijinal yazı tipi kullanılamadığında) oluşturulan çıktı için bir yazı tipi seçer.

**İkame kuralları ne zaman uygulanır?**

Kurallar, oluşturma ve dönüştürme sırasında [font selection sequence](/slides/tr/androidjava/font-selection-sequence/) sürecine katılır. `WhenInaccessible` ile bir kural, yalnızca Aspose.Slides kaynak yazı tipine erişemediğinde kullanılır.

**Bir yazı tipi eksik olduğunda ve hiçbir ikame kuralı yapılandırılmadığında ne olur?**

Aspose.Slides, yazı tipi seçim sürecine göre en yakın kullanılabilir yazı tipini seçer. Sonuç, çalışma zaman ortamında mevcut olan yazı tiplerine bağlıdır.

**İkame etmeyi önlemek için dış yazı tipleri yükleyebilir miyim?**

Evet. Aspose.Slides'in oluşturma ve dönüştürme sırasında kullanabilmesi için [external fonts](/slides/tr/androidjava/custom-font/) yükleyebilirsiniz.

**Aspose kütüphane ile birlikte yazı tipleri dağıtıyor mu?**

Hayır. Yazı tiplerini temin etmek ve lisanslarına uymak sizin sorumluluğunuzdadır.

**İkame sonuçları Android cihazlar arasında farklılık gösterebilir mi?**

Evet. Mevcut sistem yazı tipleri Android sürümleri, cihazlar ve üreticiler arasında değişebilir; bu yüzden bir ortamda mevcut olan bir yazı tipi başka bir ortamda ikame gerektirebilir.

**Android cihazlar arasında yazı tipi seçimini tutarlı nasıl yapabilirim?**

Gerekli aynı yazı tipi dosyalarını uygulama ile paketleyin, [external fonts](/slides/tr/androidjava/custom-font/) olarak yükleyin ve lisans izin veriyorsa [embed fonts](/slides/tr/androidjava/embedded-font/) kullanın. Ayrıca, beklenmeyen ikameleri belirlemek için dışa aktarmadan önce [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) metodunu çağırabilirsiniz.