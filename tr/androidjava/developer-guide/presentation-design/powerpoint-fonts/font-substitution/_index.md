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
description: "Android için Aspose.Slides'te sunumları render ederken veya dönüştürürken Java aracılığıyla yazı tipi ikame kurallarını yapılandırın ve ikame edilen yazı tiplerini inceleyin."
---
## **Overview**

Yazı tipi ikamesi, Aspose.Slides'in bir sunum render edildiğinde veya dönüştürüldüğünde erişilemeyen bir yazı tipinin yerine kullanılabilir bir yazı tipini kullanmasına olanak tanır. İkame, render edilen çıktıyı etkiler; sunum içeriğine atanmış yazı tipini değiştirmez.

Belirli bir yazı tipi kullanılamadığında kullanılacak yazı tipini tanımlayabilir ve Aspose.Slides'in render sırasında yapacağı ikameleri inceleyebilirsiniz. Bu, farklı kullanılabilir yazı tiplerine sahip Android cihazları ve ortamları arasında çıktının tutarlı kalmasına yardımcı olur.

Bir yazı tipi mevcut ancak ayrı bir kalın tip yoksa, [Ayrı Bir Kalın Yazı Tipi Olmayan Yazı Tiplerini İşleme](/slides/tr/androidjava/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface) bölümüne bakın. Bu bölüm, PDF dışa aktarımı sırasında etkilenen metnin nasıl rasterleştirileceğini ve metin seçimi, arama ve ölçeklendirme üzerindeki sonuçları açıklar.

## **Get Font Substitutions**

Sunum render edildiğinde hangi yazı tiplerinin ikame edileceğini belirlemek için [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) metodunu kullanın. Metod, orijinal ve ikame edilen yazı tipi adlarını tanımlayan [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/) nesnelerini döndürür.

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

## **Get Font Substitutions for Selected Slides**

Belirli slaytların render edilmesi için gereken ikameleri yalnızca incelemek amacıyla `int[] slides` argümanıyla [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) aşırı yüklemesini kullanın. Bu, bir sunumun bir kısmını render ederken veya dışa aktarırken, büyük bir sunumu kademeli olarak kontrol ederken, kullanılamayan yazı tiplerine bağımlı slaytları bulurken, bir Android uygulaması için minimal bir yazı tipi paketi hazırlar iken veya ilgisiz slaytları işlemeye gerek kalmadan render farklarını teşhis ederken faydalıdır.

`slides` dizisi bir‑tabanlı slayt indeksleri içerir: `1` ilk slaytı tanımlar. Buna karşılık, [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) koleksiyon erişicisi sıfır‑tabanlı indeksleme kullanır, bu yüzden aynı slayt `presentation.getSlides().get_Item(0)` şeklinde erişilir. Tek farkı akılda tutarak dizi oluştururken bir‑bir hatasından kaçının.

[Presentation.getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getFontsManager--) metodunu üzerinden aşırı yüklemeyi çağırın. Bu, sadece seçili slaytların render edilmesi sırasında belirlenen ikameleri döndürür. Her sonuç, orijinal ve ikame edilen yazı tipi adlarını içeren bir [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/) nesnesidir. Sonuç, mevcut yazı tipi ortamını, yapılandırılmış yedekleme kurallarını, bir [IFontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsubstrulecollection/) içinde depolanan ikame kurallarını ve [dış yazı tipi](/slides/tr/androidjava/custom-font/) yansıtır.

Aynı ikame, birden fazla seçili slayt tarafından da gerekli olabilir. Bir yazı tipi envanteri veya ön inceleme raporu oluştururken sonuçları tekilleştirin. Aşağıdaki örnek, her döndürülen ikameyi raporlar ve ardından benzersiz yazı tipi eşlemelerinin sıralı bir listesini oluşturur:

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

[IFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/) arayüzü her iki aşırı yüklemeyi de sağlar. Render işleminin kapsamına göre birini seçin:

| Aşırı Yükleme | Ne Zaman Kullanılır |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) with no arguments | Sunumun tamamı için ikameler gerekirken. |
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) with `int[] slides` | Seçili bir aralık, kademeli kontrol veya kısmi dışa aktarma için ikameler gerekirken. |

## **Set Font Substitution Rules**

Kaynak bir yazı tipi kullanılamadığında Aspose.Slides'in kullanması gereken yazı tipini belirtmek için:

1. Sunumu yükleyin.
2. Kaynak ve ikame yazı tipleri için yazı tipi tanımlamaları oluşturun.
3. [FontSubstRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrule/) nesnesini [WhenInaccessible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstcondition/) koşulu ile oluşturun.
4. Kuralı bir [FontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrulecollection/)’a ekleyin.
5. Koleksiyonu, [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) metodunu kullanarak atayın.
6. Sunumu render edin veya dönüştürün.

Aşağıdaki Java örneği, `SomeRareFont` kullanılamadığında `Arial` yerine geçer ve ardından sonucu doğrulamak için ilk slaytı render eder. İkame yazı tipi Aspose.Slides tarafından kullanılabilir olmalıdır.

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
Bir sunum boyunca kullanılan yazı tiplerinde koşulsuz bir değişiklik için, [Yazı Tipi Değiştirme](/slides/tr/androidjava/font-replacement/) bölümüne bakın.
{{% /alert %}}

## **Limitations for Math Equation Fonts**

Yazı tipi ikame kuralları, render ve dönüşüm sırasında kullanılan standart yazı tipi seçme sürecinin bir parçasıdır. Aspose.Slides, erişilemeyen bir yazı tipini kural tarafından belirtilen kullanılabilir bir yazı tipiyle değiştirebildiğinde, bu kurallar normal metin için çalışır.

Office Math denklemlerinin ek bir gereksinimi vardır. Bir denklem **Cambria Math** kullanıyorsa, Aspose.Slides bu denklemin yerleşimini hesaplamak ve render etmek için tam olarak bu yazı tipine ihtiyaç duyabilir. **STIX Two Math** gibi başka bir matematik yazı tipini ikame eden bir kural, bu amaçla **Cambria Math**'i değiştiremez ve render hâlâ **Cambria Math**'in gerekli olduğunu bildirebilir.

Böyle bir sunumu render etmek veya dönüştürmek için, **Cambria Math**'i Aspose.Slides için kullanılabilir hâle getirin. Uygulamanın render ve dönüşüm sırasında kullanabilmesi için bunu bir [dış yazı tipi](/slides/tr/androidjava/custom-font/) olarak yükleyin.

Bu sınırlama denklem yerleşimine uygulanır. Yukarıda açıklanan ikame kuralları normal sunum metnine hâlâ uygulanır.

## **Sık Sorulan Sorular**

**Yazı tipi değiştirme ile yazı tipi ikamesi arasındaki fark nedir?**  
[Yazı tipi değiştirme](/slides/tr/androidjava/font-replacement/) sunum boyunca bir yazı tipini bilinçli olarak başka bir yazı tipine değiştirir. Yazı tipi ikamesi, yapılandırılmış koşul karşılandığında (örneğin orijinal yazı tipi kullanılamadığında) render edilen çıktı için bir yazı tipi seçer.

**İkame kuralları ne zaman uygulanır?**  
Kurallar, render ve dönüşüm sırasında [yazı tipi seçim sırası](/slides/tr/androidjava/font-selection-sequence/) içine katılır. `WhenInaccessible` ile bir kural yalnızca Aspose.Slides kaynak yazı tipine erişemediğinde kullanılır.

**Bir yazı tipi eksik olduğunda ve ikame kuralı yapılandırılmadığında ne olur?**  
Aspose.Slides, yazı tipi seçim sürecine göre en yakın kullanılabilir yazı tipini seçer. Sonuç, çalışma zamanı ortamında mevcut olan yazı tiplerine bağlıdır.

**İkameyi önlemek için dış yazı tipleri yükleyebilir miyim?**  
Evet. Aspose.Slides'in render ve dönüşüm sırasında kullanabilmesi için [dış yazı tipleri yüklemek](/slides/tr/androidjava/custom-font/) yapabilirsiniz.

**Aspose kütüphane ile birlikte yazı tipleri dağıtıyor mu?**  
Hayır. Yazı tiplerini temin etmek ve lisanslarına uymak sizin sorumluluğunuzdadır.

**İkame sonuçları Android cihazları arasında farklılık gösterebilir mi?**  
Evet. Mevcut sistem yazı tipleri Android sürümleri, cihazlar ve üreticiler arasında farklılık gösterebilir; bu nedenle bir ortamda mevcut olan bir yazı tipi başka bir ortamda ikame gerektirebilir.

**Android cihazları arasında yazı tipi seçimini nasıl tutarlı hale getirebilirim?**  
Uygulama ile aynı gerekli yazı tipi dosyalarını paketleyin, [dış yazı tipleri olarak yükleyin](/slides/tr/androidjava/custom-font/) ve lisans izin veriyorsa [yazı tiplerini gömün](/slides/tr/androidjava/embedded-font/). Ayrıca dışa aktarma öncesinde beklenmeyen ikameleri tespit etmek için [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) metodunu çağırabilirsiniz.