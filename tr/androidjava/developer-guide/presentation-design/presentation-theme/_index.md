---
title: Android'de Sunum Temalarını Yönet
linktitle: Sunum Teması
type: docs
weight: 10
url: /tr/androidjava/presentation-theme/
keywords:
- PowerPoint teması
- sunum teması
- slayt teması
- tema ayarla
- temayı değiştir
- temayı yönet
- harici tema
- THMX
- tema rengi
- ek palet
- tema yazı tipi
- tema stili
- tema efekti
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Java üzerinden Android için Aspose.Slides kullanarak tutarlı marka kimliği ile PowerPoint dosyaları oluşturma, özelleştirme ve dönüştürme."
---
## **Giriş**

Bir sunum teması, koordineli bir renk, yazı tipi, arka plan stili, dolgu, çizgi ve efekt kümesi tanımlar. Tema‑duyarlı nesneler, her görsel özelliği sabit bir değer olarak saklamak yerine bu ortak tanımlara başvurur, bu sayede bir tema değişikliği birden çok nesneyi aynı anda güncelleyebilir.

Aspose.Slides’ta sunum‑seviyesi tema, [Presentation.getMasterTheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) aracılığıyla erişilebilir. Bir sunum ayrıca daha düşük seviyelerde tema geçersiz kılmalarını içerebilir. Bir master, [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/masterthememanager/) ile sunum temasını geçersiz kılabilir; bir düzen ya da tek bir slayt ise [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/baseoverridethememanager/) ile devralınan temayı geçersiz kılabilir. Pratikte, bir slayt için etkili tema şu kalıtım zinciri aracılığıyla çözülür: sunum teması, master geçersiz kılma, düzen geçersiz kılma ve slayt geçersiz kılma.

![Tema bileşenleri: renkler, yazı tipleri, arka plan stilleri ve efektler](theme-constituents.png)

Aşağıdaki bölümler en yaygın tema iş akışlarını gösterir: bir temayı inceleme, renk ve yazı tiplerini değiştirme, temayı kopyalama veya uygulama, arka plan ve efekt stillerini güncelleme ve kalıtım ve geçersiz kılmalar çözüldükten sonra etkili değerleri okuma.

## **Bir Temayı İnceleme**

[MasterTheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mastertheme/) nesnesi, tema’nın renk şemasını, yazı tipi şemasını ve biçim şemasını sırasıyla [MasterTheme.getColorScheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mastertheme/) ve [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mastertheme/) aracılığıyla ortaya koyar. Bu koleksiyonları değiştirmeden önce incelemek, sunum dış bir kaynaktan geldiğinde stil girdilerinin sayısı ve içeriği değişebileceği için özellikle faydalıdır.

Aşağıdaki örnek, ana tema özelliklerini okur ve temada kaç adet arka plan, dolgu, çizgi ve efekt stilinin depolandığını raporlar:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    int accent1 = theme.getColorScheme().getAccent1().getColor();
    System.out.println("Theme name: " + theme.getName());
    System.out.println(String.format("Accent 1: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(accent1), Color.red(accent1), Color.green(accent1), Color.blue(accent1)));
    System.out.println("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    System.out.println("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    System.out.println("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    System.out.println("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

Bir dosya birden fazla master kullanıyorsa, her slaytın aynı etkili temaya sahip olduğunu varsaymayın. Slayt ile ilişkili master’ı inceleyin ve düzen veya slayt geçersiz kılmaları mevcut olduğunda bu makalede daha sonra gösterilen etkili‑tema iş akışını kullanın.

## **Tema Renklerini Değiştirme**

Tema‑duyarlı dolgular, çizgiler ve metin, [SchemeColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/schemecolor/) enum’undan mantıksal bir renge başvurabilir. [IColorScheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icolorscheme/)’deki ilgili girdiyi değiştirdiğinizde, hâlâ o tema rengine başvuran tüm nesneler yeni değerle çözülür. Doğrudan bir RGB rengi kullanan nesneler tema‑rengi güncellemesinden etkilenmez.

Aşağıdaki uç‑uç örnek, `Accent4` kullanan bir şekil oluşturur, temanın `Accent4` rengini kırmızıya değiştirir, sunumu kaydeder, yeniden açar ve etkili dolgu rengini yazdırır:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
    presentation.save("theme-color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("theme-color.pptx");
try {
    ISlide savedSlide = savedPresentation.getSlides().get_Item(0);
    IShape savedShape = savedSlide.getShapes().get_Item(0);
    IFillFormatEffectiveData effectiveFill = savedShape.getFillFormat().getEffective();
    int effectiveColor = effectiveFill.getSolidFillColor();
    System.out.println(String.format("Effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
} finally {
    savedPresentation.dispose();
}
```

Dikdörtgen `Accent4`’e bağlı kaldığı için tema değiştirildiğinde görünür rengi kırmızı olur. Şekildeki şema rengini doğrudan bir renkle değiştirirseniz, sonraki `Accent4` değişiklikleri o dolguyu etkilemez.

### **Ek Paletten Renk Kullanma**

PowerPoint, bir tema renginden daha açık ve daha koyu varyantlar türetmek için renk dönüşümleri uygular. Aspose.Slides bu dönüşümleri [ColorTransformOperation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/colortransformoperation/) enum’u aracılığıyla sunar.

![Ana tema renkleri ve ek paletten türetilen daha açık ve daha koyu renkler](additional-palette-colors.png)

**1** – Ana tema renkleri.

**2** – Ana tema renklerinden üretilen daha açık ve daha koyu varyantlar.

Aşağıdaki örnek, `Accent4` temelinde altı dikdörtgen oluşturur, beş tanesine parlaklık dönüşümleri uygular ve sonucu kaydeder:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bu varyantlar tema rengine dayalı kalır. `Accent4` daha sonra değişirse, dönüştürülmüş renkler yeni `Accent4` değerinden yeniden hesaplanır.

### **`SchemeColor` Değerlerini `IColorScheme` Yuvalarına Eşleme**

[SchemeColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/schemecolor/) enum’u `Text1`, `Background1`, `Text2` ve `Background2` kullanırken, [IColorScheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icolorscheme/) aynı tema yuvalarını `Dark1`, `Light1`, `Dark2` ve `Light2` olarak sunar. Eşleme sabittir:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Bunlar aynı tema yuvalarının alternatif adlarıdır; bir formdan diğerine dinamik olarak dönüştürülen değerler değildir.

## **Tema Yazı Tiplerini Değiştirme**

Bir tema yazı tipi şeması, başlıklar için büyük bir yazı tipi seti ve gövde metni için küçük bir yazı tipi seti içerir. [IFontScheme.getMajor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifontscheme/) ve [IFontScheme.getMinor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifontscheme/) metodları bu setleri ortaya koyar.

PowerPoint‑uyumlu tema yazı tipi tanımlayıcıları metin biçimlendirmede kullanılabilir:

* `+mn-lt` – Gövde Yazı Tipi Latin (Küçük Latin Yazı Tipi)
* `+mj-lt` – Başlık Yazı Tipi Latin (Büyük Latin Yazı Tipi)
* `+mn-ea` – Gövde Yazı Tipi Doğu Asya (Küçük Doğu Asya Yazı Tipi)
* `+mj-ea` – Başlık Yazı Tipi Doğu Asya (Büyük Doğu Asya Yazı Tipi)

Aşağıdaki örnek, büyük Latin tema yazı tipini kullanan bir başlık ve küçük Latin tema yazı tipini kullanan bir gövde satırı oluşturur. Ardından tema yazı tiplerini değiştirir ve sonucu kaydeder:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mj-lt"));

    IAutoShape body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Başlık büyük yazı tipini, gövde metni ise küçük yazı tipini izler. Açık bir yazı tipi adıyla belirtilen metin, tema yazı tipi şeması değiştiğinde otomatik olarak değişmez.

Büyük ve küçük yazı tipi koleksiyonları ayrıca Kiril, Arapça, Japonca, Gürcüce ve Thaana gibi bireysel yazı sistemleri için yazı tipi eşlemeleri içerebilir. Bu eşlemeleri incelemek, eklemek, değiştirmek veya kaldırmak için [Script‑Specific Theme Fonts](/slides/tr/androidjava/script-specific-font-mappings/) bölümüne bakın.

{{% alert color="info" title="İpucu" %}}
Sunum yazı tipleri hakkında daha fazla bilgi için [PowerPoint Fonts](/slides/tr/androidjava/powerpoint-fonts/) sayfasına bakın.
{{% /alert %}}

## **Bir Temayı Kopyalama veya Uygulama**

Aşağıdaki iş akışları farklı tema‑ile ilişkili problemleri çözer.

### **Harici Bir Temayı Master’a Bağlı Slaytlara Uygulama**

Bir PowerPoint tema dosyanız (`.thmx`) varsa ve belirli bir master’a bağlı her slaytı yeniden stillendirmek istiyorsanız, [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterslide/) kullanın. [Presentation.getMasters](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) koleksiyonundan, [IMasterSlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterslidecollection/) uygulayan master’ı seçin ve dosya yolunu metoda geçirin.

Metod aşağıdaki işlemleri yapar:

1. Seçilen master’a dayanarak yeni bir master slayt oluşturur.
1. Harici temayı yeni master’a uygular.
1. Önceden seçilen master’a bağlı tüm slaytlara yeni master’ı atar.
1. Yeni oluşturulan [IMasterSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterslide/) nesnesini döndürür.

Aşağıdaki örnek, ilk master’a bağlı slaytlara harici bir tema uygular ve sunumu kaydeder:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide selectedMaster = presentation.getMasters().get_Item(0);
    IMasterSlide themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    System.out.println("Created master: " + themedMaster.getName());
    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Geçersiz, bozuk veya desteklenmeyen bir tema, [PptxReadException](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pptxreadexception/) oluşturabilir. Kullanıcı tarafından sağlanan yolları doğrulayın, dosya sistemi erişim hatalarını yönetin ve tema başarıyla uygulandıktan sonra sunumu kaydedin.

Yalnızca seçilen master’a bağımlı slaytlar yeniden atanır. Diğer master’larla ilişkili slaytlar var olan master ve temalarını korur. Tema‑duyarlı renkler, yazı tipleri, dolgular, çizgiler, arka planlar ve efektler harici temaya göre çözülür. Doğrudan atanmış renkler, yazı tipleri, dolgular ve diğer açık biçimlendirmeler değişmemiş kalabilir. Düzen‑seviyesi ve slayt‑seviyesi geçersiz kılmalar, yeni master’dan miras alınan değerlerin üzerine geçebilir.

Tema, çalışma zaman ortamında bulunmayan yazı tiplerine başvurabilir. Tutarlı render ve dışa aktarma için gerekli yazı tiplerini kurun, [özel yazı tipi kaynakları](/slides/tr/androidjava/custom-font/) aracılığıyla sağlayın veya [yazı tipi ikamesi](/slides/tr/androidjava/font-substitution/) yapılandırın.

Bu doğrudan master‑seviyesi bir iş akışıdır: metod bir `.thmx` dosya yolu alır ve slayt‑seviyesi veya düzen‑seviyesi tema geçersiz kılmaları manuel olarak oluşturmayı gerektirmez.

### **Çok‑Masterlı Bir Sunumda Farklı Harici Temalar Uygulama**

İlgili master önceden bilinmiyorsa, [ISlide.getLayoutSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/) ve [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutslide/) aracılığıyla temsilci bir slayttan elde edin. Her temayı uygulamadan önce orijinal master referanslarını saklayın; çünkü her çağrı sunumda yeni bir master oluşturur.

Aşağıdaki örnek, iki bölümden slaytları kullanarak master’larını bulur ve her grup için farklı bir harici tema uygular:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        System.out.println("The presentation does not contain the expected representative slides.");
    } else {
        IMasterSlide firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        IMasterSlide secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() == secondGroupMaster.getSlideId()) {
            System.out.println("The representative slides use the same master.");
        } else {
            IMasterSlide firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            IMasterSlide secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            System.out.println("First themed master: " + firstThemedMaster.getName());
            System.out.println("Second themed master: " + secondThemedMaster.getName());
            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

İlk çağrı yalnızca `firstGroupMaster`’a bağlı slaytları etkiler, ikinci çağrı ise yalnızca `secondGroupMaster`’a bağlı slaytları etkiler. Başka bir master’a bağlı slaytlar yeniden stillendirilmez.

### **Slayt Taşırken Kaynak Temasını Korumak**

Bir slaytı başka bir sunuma taşımak ve özgün tasarımını korumak istiyorsanız, kaynak master’ı hedef sunuma [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterslidecollection/) ile klonlayın, ardından slaytı [ISlideCollection.addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidecollection/) ve klonlanmış master ile klonlayın. Bu, master, düzenleri ve ilişkili temayı birlikte taşır.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide sourceSlide = source.getSlides().get_Item(0);
        IMasterSlide sourceMaster = sourceSlide.getLayoutSlide().getMasterSlide();
        IMasterSlide clonedMaster = target.getMasters().addClone(sourceMaster);
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Bu, kaynak slaytın hedefte aynı görünmesi gerektiğinde tercih edilen iş akışıdır. İçeriği bağımsız bir hedef master’a klonlamak, tema‑türü renkler, yazı tipleri, arka planlar ve efektlerde değişikliklere yol açabilir.

### **Mevcut Bir Slayta Tema Değerlerini Uygulama**

Hedef slayt mevcut master ve düzenini korumalıysa, kaynağın temasından bir slayt‑seviyesi geçersiz kılma başlatın. [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/overridetheme/) ve [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/overridetheme/) metodları üç ana tema bileşenini geçersiz kılamaya kopyalar.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
        IOverrideTheme overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Bu, diğer slaytların devraldığı temayı değiştirmeden yalnızca o slaytın temasını değiştirir. Yerel geçersiz kılmayı kaldırıp devralınan değerlere dönmek için [OverrideTheme.clear](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/overridetheme/) çağırın.

### **Bir Düzen İçin Tema Geçersiz Kılaması Uygulama**

Düzen‑seviyesi bir geçersiz kılma, o düzeni kullanan slaytlara uygulanır; ancak belirli bir slayt kendi geçersiz kılamasına sahipse bu geçersiz kılma üstünlük sağlar. Aynı başlatma metodları, [LayoutSlideThemeManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/layoutslidethememanager/) aracılığıyla da kullanılabilir:

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
        ILayoutSlide targetLayout = targetSlide.getLayoutSlide();
        IOverrideTheme overrideTheme = targetLayout.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Birçok düzen ve slayt aynı temel tasarımı paylaşacaksa master veya sunum‑seviyesi tema kullanın; bir düzen ailesi farklı stil gerektiriyorsa düzen geçersiz kılması, yalnızca gerçek istisnalar için slayt geçersiz kılması tercih edin. Aşırı slayt‑seviyesi geçersiz kılmalar, daha sonraki küresel tema değişikliklerini öngörmeyi zorlaştırır.

## **Tema Arka Plan Stilini Güncelleme**

Tema’nın arka plan dolguları, [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iformatscheme/) aracılığıyla depolanır. PowerPoint, kullanıcı arayüzünde bu koleksiyonda fiziksel olarak tanımlı dolgu sayısından daha fazla arka plan seçeneği sunabilir; çünkü UI tema dolgularını tema renkleri ve diğer stil referanslarıyla birleştirir.

![Sunum temasına ait PowerPoint arka plan stil galerisini gösterir](presentation-design_8.png)

Bir arka plan stilini kullanmadan önce, depolanmış koleksiyonu ve mevcut [Background.getStyleIndex](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/background/) değerini inceleyin. `0` stil indeksi temalı bir dolgu olmadığını; pozitif değerler tema arka plan‑stil referanslarıdır. Bu, Java koleksiyonunda `get_Item(0)` ilk öğe anlamına gelen doğrudan indeksle aynı şey değildir. Her sunumun aynı sayıda arka plan dolgu stiline sahip olduğunu varsaymayın.

Aşağıdaki örnek, mevcut arka plan dolgu sayısını raporlar, ilk master’a temalı bir arka plan referansı atar ve sunumu kaydeder:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IFillFormatCollection backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    System.out.println("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() == 0) {
        throw new IllegalStateException("The presentation theme does not contain background fill styles.");
    }

    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(BackgroundType.Themed);
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Görünür sonuç, master’ın başvurduğu tema girdisine ve düzen ya da slayt seviyesindeki olası arka plan geçersiz kılmalarına bağlıdır. Bir slayt kendi arka planını kullanıyorsa, yalnızca master arka planını değiştirmek o slaytı etkilemez. Kalıtım uygulandıktan sonraki nihai arka planı öğrenmek için [Background.getEffective](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/background/) kullanın.

{{% alert color="warning" title="Uyarı" %}}
Stil indeksini sıfır‑tabanlı bir koleksiyon indeksi gibi ele almayın. Ayrıca bir dosyadan sabit bir stil numarası kodlayıp başka bir dosyada aynı görünümü beklemekten kaçının; tema stil tanımları sunuma özeldir.
{{% /alert %}}

{{% alert color="info" title="İpucu" %}}
Doğrudan arka plan biçimlendirmesi ve arka plan kalıtımı için [Presentation Background](/slides/tr/androidjava/presentation-background/) bölümüne bakın.
{{% /alert %}}

## **Tema Efektlerini Güncelleme**

Bir tema biçim şeması, ayrı dolgu, çizgi ve efekt stil koleksiyonlarını [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iformatscheme/) ve [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iformatscheme/) aracılığıyla ortaya koyar. Tipik Office temaları, görsel olarak hafif, orta ve yoğun biçimlendirmelere karşılık gelen üç temel stil girdisi içerir; ancak kod sabit bir sayıyı varsaymak yerine her koleksiyonu incelemelidir.

![Aynı şekle uygulanmış hafif, orta ve yoğun tema efektleri](presentation-design_10.png)

Bu koleksiyonlara Java’da erişirken, koleksiyon indeksi sıfır‑tabanlıdır: `get_Item(0)` ilk depolanmış stil, `get_Item(2)` üçüncü stildir. Bir şeklin stil‑referans indeksleri ayrı bir kavramdır ve [IShapeStyle](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapestyle/) aracılığıyla ortaya konur. Bir tema stilini değiştirmek, o temaya başvuran şekilleri etkiler; doğrudan biçimlendirilmiş şekiller değişmez.

Aşağıdaki örnek, gerekli stil girdilerinin mevcut olduğunu kontrol eder, ilk çizgi stilini, üçüncü dolgu stilini değiştirir, üçüncü efekt stilinde dış gölgeyi etkinleştirir ve sonucu kaydeder:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.rgb(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bu yuvalara başvuran şekiller için, ilk tema çizgi stili kırmızı, üçüncü tema dolgu stili katı orman yeşili ve üçüncü efekt stili 10 puan uzaklıkta bir dış gölge alır. Kesin görsel sonuç, her şeklin hangi stil yuvalarına başvurduğuna ve doğrudan biçimlendirme temayı geçersiz kılıp kılmadığına bağlıdır.

![Satır, dolgu ve gölge ayarları değiştirildikten sonra tema efekt stilleri](presentation-design_11.png)

## **Etkili Tema Değerlerini Okuma**

Ham tema nesneleri, belirli bir seviyede neyin tanımlandığını gösterir. Etkili değerler, kalıtım ve yerel geçersiz kılmalar çözüldükten sonra bir slayt veya şeklin gerçekte ne kullandığını gösterir. Bir slayt için [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/baseoverridethememanager/) çağırın. Bir arka plan için [Background.getEffective](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/background/), bir dolgu için ise [FillFormat.getEffective](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fillformat/) kullanın.

Aşağıdaki örnek, bir slayttan etkili temayı, arka planı ve ilk şekil dolgusunu okur:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IThemeEffectiveData effectiveTheme = slide.getThemeManager().createThemeEffective();
    IBackgroundEffectiveData effectiveBackground = slide.getBackground().getEffective();
    System.out.println("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        IFillFormatEffectiveData effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        System.out.println("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() == FillType.Solid) {
            int effectiveColor = effectiveFill.getSolidFillColor();
            System.out.println(String.format("First shape effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
        }
    }
} finally {
    presentation.dispose();
}
```

Etkili verileri, render teşhisleri, doğrulama ve karşılaştırmalar için kullanın. Yalnızca [Presentation.getMasterTheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) incelerseniz, bir master, düzen, slayt veya şekil geçersiz kılmasının nihai görünümü değiştirdiğini kaçırabilirsiniz.

## **SSS**

**Harici bir tema uygulamak sunumdaki her slaytı etkiler mi?**

Hayır. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterslide/) yalnızca seçilen master’a bağımlı slaytları yeniden atar. Diğer master’ları kullanan slaytlar mevcut temalarını korur.

**Bir master’ı değiştirmeden tek bir slayta tema uygulayabilir miyim?**

Evet. Slaytın [SlideThemeManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slidethememanager/) kullanın ve geçersiz kılma temasını başlatın. Değişiklik yalnızca o slayta yerel kalır; diğer slaytlar mevcut temalarını miras almaya devam eder.

**Bir temayı bir sunumdan diğerine taşırken en güvenli yol nedir?**

Bir slaytı taşırken ve kaynak görünümünü korurken, kaynak master’ı hedefe klonlayın ve slaytı o master ile birlikte [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterslidecollection/) ve [ISlideCollection.addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidecollection/) kullanarak klonlayın. Bu, master, düzenler ve temayı birlikte tutar.

**Kalıtım ve geçersiz kılmalardan sonra etkili değerleri nasıl görebilirim?**

Bir slayt veya düzen teması için [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/baseoverridethememanager/) ve [Background.getEffective](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/background/) ve [FillFormat.getEffective](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fillformat/) gibi ilgili etkili‑veri metodlarını kullanın. Bu API’ler, kalıtım ve geçersiz kılmalar uygulandıktan sonra çözülen değerleri döndürür.