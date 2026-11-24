---
title: Android'de Sunum Temalarını Yönetme
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
description: "Aspose.Slides for Android'de Java aracılığıyla ana sunum temalarını yöneterek, tutarlı marka kimliğiyle PowerPoint dosyaları oluşturun, özelleştirin ve dönüştürün."
---
## **Giriş**

Bir sunum teması, koordineli bir renk, yazı tipi, arka plan stili, dolgu, çizgi ve efekt kümesini tanımlar. Tema‑bilgili nesneler, her görsel özelliği sabit bir değer olarak depolamak yerine bu ortak tanımlara başvurur; böylece bir tema değişikliği, birçok nesneyi aynı anda güncelleyebilir.

Aspose.Slides içinde sunum‑seviyesi tema, [Presentation.getMasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) aracılığıyla erişilebilir. Bir sunum ayrıca daha alt seviyelerde tema geçersizlikleri içerebilir. Bir master, [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterthememanager/) üzerinden sunum temasını geçersiz kılabilir; bir düzen ya da bireysel slayt ise [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/) aracılığıyla devralınan temayı geçersiz kılabilir. Pratikte, bir slayt için etkili tema, şu miras zinciri aracılığıyla çözülür: sunum teması, master geçersizliği, düzen geçersizliği ve slayt geçersizliği.

![Tema bileşenleri: renkler, yazı tipleri, arka plan stilleri ve efektler](theme-constituents.png)

Aşağıdaki bölümler en yaygın tema iş akışlarını gösterir: bir temayı inceleme, renk ve yazı tiplerini değiştirme, temayı kopyalama veya uygulama, arka plan ve efekt stillerini güncelleme ve miras ve geçersizlikler çözüldükten sonra etkili değerleri okuma.

## **Bir Temayı İnceleme**

[MasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/) nesnesi, temanın renk şemasını, yazı tipi şemasını ve biçim şemasını [MasterTheme.getColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/) ve [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/) üzerinden sunar. Bu koleksiyonları değiştirmeden önce incelemek, özellikle dış bir kaynaktan gelen bir sunumda stil giriş sayısı ve içeriği değişebildiği için faydalıdır.

Aşağıdaki örnek ana tema özelliklerini okur ve temada kaç tane arka plan, dolgu, çizgi ve efekt stilinin saklandığını raporlar:

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

Bir dosya birden çok master kullanıyorsa, her slaytın aynı etkili temaya sahip olduğunu varsaymayın. Slayt ile ilişkilendirilmiş masterʼı inceleyin ve düzen veya slayt geçersizlikleri mevcut olduğunda bu makalede daha sonra gösterilen etkili‑tema iş akışını kullanın.

## **Tema Renklerini Değiştirme**

Tema‑bilgili dolgular, çizgiler ve metinler, [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/) enumʼundan mantıksal bir renge başvurabilir. [IColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorscheme/) içindeki ilgili girişi değiştirince, hâlâ o tema rengini referans eden tüm nesneler yeni değere göre çözülür. Doğrudan RGB rengi kullanan nesneler tema‑rengi güncellemesinden etkilenmez.

Aşağıdaki uçtan uca örnek, `Accent4` kullanan bir şekil oluşturur, temanın `Accent4` rengini kırmızıya değiştirir, sunumu kaydeder, yeniden açar ve etkili dolgu rengini yazdırır:

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

Dikdörtgen `Accent4`ʼe bağlı kaldığı için tema değiştirildiğinde görünür rengi kırmızı olur. Şekildeki şema rengini doğrudan bir renk ile değiştirirseniz, sonradan `Accent4` değişiklikleri o dolguyu etkilemez.

### **Ek Paletten Renk Kullanma**

PowerPoint, bir tema renginden daha açık ve daha koyu varyantları renk dönüşümleri uygulayarak türetir. Aspose.Slides bu dönüşümleri [ColorTransformOperation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/colortransformoperation/) enumʼu aracılığıyla sunar.

![Ana tema renkleri ve ek paletten türetilen daha açık ve daha koyu renkler](additional-palette-colors.png)

**1** – Ana tema renkleri.

**2** – Ana tema renklerinden türetilen daha açık ve daha koyu varyantlar.

Aşağıdaki örnek, `Accent4` temelli altı dikdörtgen oluşturur, beşine parlaklık dönüşümleri uygular ve sonucu kaydeder:

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

Bu varyantlar tema rengine dayalıdır. `Accent4` ileride değişirse, dönüştürülmüş renkler yeni `Accent4` değerinden yeniden hesaplanır.

### **`SchemeColor` Değerlerini `IColorScheme` Slotlarına Eşleme**

[SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/) enumʼu `Text1`, `Background1`, `Text2` ve `Background2` kullanırken, [IColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorscheme/) aynı tema slotlarını `Dark1`, `Light1`, `Dark2` ve `Light2` olarak sunar. Eşleme sabittir:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Bunlar aynı tema slotlarının alternatif adlarıdır; bir formdan diğerine dinamik olarak dönüştürülen değerler değildir.

## **Tema Yazı Tiplerini Değiştirme**

Bir tema yazı tipi şeması, başlıklar için büyük bir yazı tipi kümesi ve gövde metni için küçük bir yazı tipi kümesi içerir. [IFontScheme.getMajor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontscheme/) ve [IFontScheme.getMinor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontscheme/) yöntemleri bu kümeleri ortaya çıkarır.

PowerPoint‑uyumlu tema yazı tipi tanımlayıcıları metin biçimlendirmesinde kullanılabilir:

* `+mn‑lt` – Gövde Yazı Tipi Latin (Minor Latin Font)
* `+mj‑lt` – Başlık Yazı Tipi Latin (Major Latin Font)
* `+mn‑ea` – Gövde Yazı Tipi Doğu Asya (Minor East Asian Font)
* `+mj‑ea` – Başlık Yazı Tipi Doğu Asya (Major East Asian Font)
* `+mn‑cs` – Gövde Yazı Tipi Karmaşık Betik (Minor Complex Script Font)
* `+mj‑cs` – Başlık Yazı Tipi Karmaşık Betik (Major Complex Script Font)

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

Başlık büyük yazı tipini, gövde metni ise küçük yazı tipini izler. Açıkça bir yazı tipi adı verilen metin, tema yazı tipi şeması değiştiğinde otomatik olarak değişmez.

Büyük ve küçük yazı tipi koleksiyonları ayrıca Kiril, Arapça, Japonca, Gürcüce ve Thaana gibi bireysel yazı sistemleri için yazı tipi eşlemeleri içerebilir. Bu eşlemeleri incelemek, eklemek, değiştirmek veya kaldırmak için [Script‑Specific Theme Fonts](/slides/tr/androidjava/script-specific-font-mappings/) bölümüne bakın.

{{% alert color="info" title="İpucu" %}}
Sunum yazı tipleri hakkında daha fazla bilgi için [PowerPoint Fonts](/slides/tr/androidjava/powerpoint-fonts/) sayfasına bakın.
{{% /alert %}}

### **Tema Yazı Tipi Referanslarını Çözümleme**

Metin incelerken, [IFontData.getFontName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontdata/#getFontName--) tema referansı olarak `+mn‑lt` gibi bir değer döndürebilir. Bu referansı çözmek için uygun [IThemeEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithemeeffectivedata/) ile [IFontData.getFontName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontdata/#getFontName-com.aspose.slides.IThemeEffectiveData-) çağırın. `+mj` ve `+mn` ön ekleri büyük ve küçük yazı tipi kümelerini, `-lt`, `-ea` ve `-cs` son ekleri ise Latin, Doğu Asya ve Karmaşık Betik yazı tiplerini seçer.

Tema, incelenen metnin üzerine uygulandığı nesne üzerinden [IThemeable.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithemeable/#createThemeEffective--) ile elde edilir. Normal bir slayt üzerindeki metin için bu yöntemi slayt üzerinde çağırın; böylece bağlam, o slaydın devralınan teması ve yerel geçersizliklerini içerir. Bir düzen ya da masterʼı incelerken kendi etkili temasını kullanın. İlk masterʼın temasının her slayta uygulandığını varsaymayın.

Aşağıdaki örnek, küçük Latin yazı tipine açıkça başvuran bir metin parçası oluşturur. [IOverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioverridetheme/#initFontSchemeFromInherited--) ile bir slayt yazı tipi şeması başlatır ve büyük ve küçük Latin ailelerini `Arial` ve `Calibri` olarak ayarlar; böylece girdi dosyası olmadan sonuç yineleme yapılabilir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IOverrideTheme theme = slide.getThemeManager().getOverrideTheme();
    theme.initFontSchemeFromInherited();
    theme.getFontScheme().getMajor().setLatinFont(new FontData("Arial"));
    theme.getFontScheme().getMinor().setLatinFont(new FontData("Calibri"));

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Text using the minor theme font");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    IFontData font = portion.getPortionFormat().getLatinFont();
    IThemeEffectiveData effectiveTheme = slide.createThemeEffective();
    System.out.println(font.getFontName() + " -> " + font.getFontName(effectiveTheme));

    FontData explicitFont = new FontData("Verdana");
    System.out.println(explicitFont.getFontName() + " -> " + explicitFont.getFontName(effectiveTheme));
} finally {
    presentation.dispose();
}
```

Çıktı `+mn‑lt -> Calibri` ardından `Verdana -> Verdana` olur. Saklanan referans değişmeden kalır, açıkça belirtilen aile adı olduğu gibi döndürülür. Parça `+mj‑lt` kullanmış olsaydı, bu tema içinde `Arial`ʼe çözülürdü.

Tema referansını çözmek, temanın belirttiği yazı tipi ailesini ortaya çıkarır. Bu, yazı tipinin kullanılabilirliğini kontrol etmez ya da render sırasında değişim ya da glif geri dönüşü sonrasında kullanılan dosyayı belirlemez. Bu ayrı adımlar için [Font Selection Sequence](/slides/tr/androidjava/font-selection-sequence/) ve [Font Substitution](/slides/tr/androidjava/font-substitution/) bölümlerine bakın.

## **Bir Temayı Kopyalama veya Uygulama**

Aşağıdaki iş akışları farklı tema‑ile ilgili sorunları çözer.

### **Bir Masterʼın Bağlı Slaytlarına Dış Tema Uygulama**

Bir PowerPoint tema dosyası (`.thmx`) elinizde ve belirli bir masterʼa bağlı tüm slaytların stilini değiştirmek istiyorsanız [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) kullanın. [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) koleksiyonundan, [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) uygulayan masterʼı seçin ve tema dosya yolunu metoda iletin.

Metodun yaptığı işlemler:

1. Seçilen masterʼa dayanarak yeni bir master slayt oluşturur.
1. Dış temayı yeni masterʼa uygular.
1. Daha önce seçilen masterʼa bağlı tüm slaytlara yeni masterʼı atar.
1. Yeni oluşturulan [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) nesnesini döndürür.

Aşağıdaki örnek, ilk masterʼa bağlı slaytlara dış tema uygular ve sunumu kaydeder:

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

Geçersiz, bozuk ya da desteklenmeyen bir tema, [PptxReadException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxreadexception/) oluşturabilir. Kullanıcıların sağladığı yolları doğrulayın, dosya sistemi erişim hatalarını yönetin ve temayı başarıyla uyguladıktan sonra sunumu kaydedin.

Yalnızca seçilen masterʼa bağlı slaytlar yeniden atanır. Diğer masterʼlara ait slaytlar mevcut master ve temalarını korur. Tema‑bilgili renkler, yazı tipleri, dolgular, çizgiler, arka planlar ve efektler dış tema ile çözülür. Doğrudan atanmış renkler, yazı tipleri, dolgular ve diğer açık biçimlendirmeler değişmeden kalabilir. Düzen‑seviyesi ve slayt‑seviyesi geçersizlikler, yeni masterʼdan devralınan değerlerden daha öncelikli olabilir.

Tema, çalışma ortamında bulunmayan yazı tiplerine başvurabilir. Tutarlı render ve dışa aktarma için gerekli yazı tiplerini kurun, [özel yazı tipi kaynakları](/slides/tr/androidjava/custom-font/) aracılığıyla sağlayın veya [yazı tipi ikamesi](/slides/tr/androidjava/font-substitution/) yapılandırın.

Bu, doğrudan master‑seviyesi bir iş akışıdır: metod bir `.thmx` dosya yolunu alır ve slayt‑seviyesi ya da düzen‑seviyesi tema geçersizlikleri oluşturmayı gerektirmez.

### **Çok‑Masterlı Sunumda Farklı Dış Temalar Uygulama**

İlgili master önceden bilinmiyorsa, [ISlide.getLayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) ve [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslide/) aracılığıyla temsilci bir slayttan alın. Tema uygulamadan önce özgün master referanslarını saklayın; her çağrı sunumda yeni bir master oluşturur.

Aşağıdaki örnek, iki bölümden slaytları alır, masterlarını bulur ve her grup için farklı bir dış tema uygular:

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

İlk çağrı yalnızca `firstGroupMaster`ʼa bağlı slaytları etkiler, ikinci çağrı yalnızca `secondGroupMaster`ʼa bağlı slaytları etkiler. Diğer masterʼa ait slaytlar yeniden stilize edilmez.

### **Slayt Taşıma Sırasında Kaynak Temayı Korumak**

Bir slaytı başka bir sunuma taşıyıp özgün tasarımını korumak istiyorsanız, kaynak masterʼı hedef sunuma [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) ile klonlayın, ardından slaytı ve klonlanmış masterʼı [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) ile klonlayın. Böylece master, düzenleri ve ilişkili tema birlikte taşınır.

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

Bu, kaynağın hedefte aynı görünmesi gerektiğinde tercih edilen iş akışıdır. İçeriği ilgisiz bir hedef master üzerine klonlamak, tema‑güdümlü renk, yazı tipi, arka plan ve efektlerin değişmesine yol açabilir.

### **Mevcut Bir Slayta Tema Değerleri Uygulama**

Hedef slayt mevcut master ve düzenini korumalıysa, kaynak temadan bir slayt‑seviyesi geçersizlik başlatın. [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/) ve [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/) yöntemleri üç ana tema bileşenini geçersizliğe kopyalar.

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

Bu, diğer slaytların devraldığı temayı değiştirmeden yalnızca o slaytın temasını değiştirir. Yerel geçersizliği kaldırıp devralınan değerlere dönmek için [OverrideTheme.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/) çağırın.

### **Bir Düzeni Tema Geçersizliğiyle Uygulama**

Düzen‑seviyesi geçersizlik, o düzeni kullanan slaytlara uygulanır; yalnızca bir slaytın kendi geçersizliği varsa o geçerli olur. Aynı başlatma yöntemleri, [LayoutSlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslidethememanager/) aracılığıyla kullanılabilir:

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

Birden çok düzen ve slayt aynı temel tasarımı paylaşmalıysa master veya sunum‑seviyesi tema kullanın; bir düzen ailesi farklı stil gerektiriyorsa düzen geçersizliği, yalnızca gerçek istisnalar için slayt geçersizliği kullanın. Aşırı slayt‑seviyesi geçersizlikler, sonraki küresel tema değişikliklerini tahmin etmeyi zorlaştırır.


<!-- visual-explanation:presentation-theme:start -->
[![Bir master tema iki düzeni besler; bir düzen geçersizliği, daha yerel bir geçersizliği olan slayt hariç, slaytlarını etkiler.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*Bir düzen geçersizliği, o düzeni kullanan slaytlara uygulanır; bir slayt kendi geçersizliğini sağlamazsa. Tema‑bazlı değerler, çözümlenen şemalarını izler; açıkça biçimlendirilmiş nesneler yerel görünümlerini korur. Geçersizlikleri, amaçlanan tasarım istisnası kadar dar tutun.* 
<!-- visual-explanation:presentation-theme:end -->

## **Tema Arka Plan Stillerini Güncelleme**

Temanın arka plan dolguları, [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/) içinde saklanır. PowerPoint, UIʼsinde temanın dolgu tanımlarını tema renkleri ve diğer stil referanslarıyla birleştirerek, fiziksel olarak bu koleksiyonda saklanan dolgu tanımlarından daha fazla arka plan seçeneği sunabilir.

![PowerPoint arka plan stil galerisinde bir sunum teması](presentation-design_8.png)

Bir arka plan stilini kullanmadan önce, saklanan koleksiyonu ve geçerli [Background.getStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) değerini inceleyin. `0` stil indeksi tema dolgu olmadığını, pozitif değerlerin tema arka plan‑stil referansları olduğunu gösterir. Bu, Java koleksiyonundaki indekslemeyle karıştırılmamalıdır; `get_Item(0)` ilk saklanan öğeyi ifade eder. Her sunumun aynı sayıda arka plan dolgu stiline sahip olduğunu varsaymayın.

Aşağıdaki örnek, mevcut arka plan dolgu sayısını raporlar, ilk masterʼa temalı bir arka plan referansı atar ve sunumu kaydeder:

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

Görünür sonuç, masterʼın referans verdiği tema girişine ve düzen ya da slayt seviyesindeki arka plan geçersizliklerine bağlıdır. Bir slayt kendi arka planını kullandığında, yalnızca master arka planını değiştirmek o slaytı etkilemez. Miras uygulandığında nihai arka planı öğrenmek için [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) kullanın.

{{% alert color="warning" title="Uyarı" %}}
Stil indeksini sıfır‑tabanlı bir koleksiyon indeksi gibi işlemeyin. Ayrıca bir dosyadan stil numarasını sabit kodlayıp başka bir dosyada aynı görünüm olduğunu varsamayın; tema stil tanımları sunuma özgüdür.
{{% /alert %}}

{{% alert color="info" title="İpucu" %}}
Doğrudan arka plan biçimlendirme ve arka plan mirası için [Presentation Background](/slides/tr/androidjava/presentation-background/) bölümüne bakın.
{{% /alert %}}

## **Tema Efektlerini Güncelleme**

Bir tema biçim şeması, ayrı dolgu, çizgi ve efekt stil koleksiyonlarını [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/) ve [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/) aracılığıyla sunar. Tipik Office temaları, görsel olarak hafif, orta ve yoğun biçimlendirmelere karşılık gelen üç ana stil girişine sahiptir; ancak kod, sabit bir sayıyı varsaymak yerine her koleksiyonu incelemelidir.

![Aynı şekle uygulanan hafif, orta ve yoğun tema efektleri](presentation-design_10.png)

Java’da bu koleksiyonlara eriştiğinizde, koleksiyon indeksi sıfır‑tabanlıdır: `get_Item(0)` ilk saklanan stili, `get_Item(2)` üçüncüyü gösterir. Bir şeklin stil‑referans indeksleri ayrı bir kavramdır ve [IShapeStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/) aracılığıyla sunulur. Bir tema stilini değiştirmek, o tema stilini referans eden şekilleri etkiler; doğrudan biçimlendirilmiş şekiller değişmeden kalabilir.

Aşağıdaki örnek, gerekli stil girişlerinin mevcut olduğunu kontrol eder, ilk çizgi stilini, üçüncü dolgu stilini değiştirir, üçüncü efekt stiline dış gölge ekler ve sonucu kaydeder:

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

Bu slotları referans eden şekillerde, ilk tema çizgi stili kırmızı, üçüncü tema dolgu stili yoğun orman yeşili ve üçüncü efekt stili 10 puan mesafede dış gölge kazanır. Tam görsel sonuç, hangi stil slotlarının hangi şekiller tarafından referans alındığına ve doğrudan biçimlendirmelerin temayı geçersiz kılıp kılmadığına bağlıdır.

![Çizgi, dolgu ve gölge ayarları değiştirildikten sonra tema efekt stilleri](presentation-design_11.png)

## **Bir Şekil İçin Tema Dolgu ve Çizgi Stillerini Seçme**

Bir şekil, doldurmasını ve konturunu bağımsız olarak [IShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/#setFillStyleIndex-short-) ve [IShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/#setLineStyleIndex-int-) ile seçebilir. Her iki yöntemde de `1` indeksi, ilgili tema koleksiyonundaki ilk girişi (`get_Item(0)`) seçerken, `2` indeksi ikinci girişi (`get_Item(1)`) seçer.

Aşağıdaki örnek, yeni bir sunumun varsayılan temasında iki dolgu stili (altın ve gökyüzü mavisi) ve iki çizgi stili (6 pt içinde koyu mavi ve 12 pt içinde koyu kırmızı) ayarlar. Sonucu üç aşamada slayta kaydeder, böylece PowerPoint’te karşılaştırabilirsiniz.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IFormatScheme styles = presentation.getMasterTheme().getFormatScheme();

    IFillFormat goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(FillType.Solid);
    goldFill.getSolidFillColor().setColor(Color.rgb(255, 215, 0));
    IFillFormat blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(FillType.Solid);
    blueFill.getSolidFillColor().setColor(Color.rgb(135, 206, 235));

    ILineFormat thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(FillType.Solid);
    thinLine.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
    thinLine.setWidth(6);
    ILineFormat thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(FillType.Solid);
    thickLine.getFillFormat().getSolidFillColor().setColor(Color.rgb(139, 0, 0));
    thickLine.setWidth(12);

    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    IAutoShape left = shapes.addAutoShape(ShapeType.Rectangle, 100, 205, 200, 130);
    IAutoShape right = shapes.addAutoShape(ShapeType.Rectangle, 420, 205, 200, 130);
    left.getShapeStyle().setFillStyleIndex((short) 1);
    right.getShapeStyle().setFillStyleIndex((short) 2);
    left.getShapeStyle().setLineStyleIndex(1);
    right.getShapeStyle().setLineStyleIndex(1);
    presentation.save("01-initial.pptx", SaveFormat.Pptx);

    right.getShapeStyle().setLineStyleIndex(2);
    presentation.save("02-line-changed.pptx", SaveFormat.Pptx);

    goldFill.getSolidFillColor().setColor(Color.rgb(46, 139, 87));
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| İlk stiller | Sağ konturu değiştir | İlk tema dolgusunu düzenle |
|:---:|:---:|:---:|
| ![Altın ve gökyüzü‑mavi dikdörtgenler, eşleşen ince koyu mavi konturlar](theme-style-initial.png) | ![Gökyüzü‑mavi dikdörtgen artık kalın koyu kırmızı bir kontura sahip](theme-style-line-changed.png) | ![Sol dikdörtgen şimdi yeşil, iki kontur değişmemiş](theme-style-fill-changed.png) |

Farklı bir çizgi stili seçmek yalnızca sağ dikdörtgenin konturunu değiştirir. İlk tema dolgusunu düzenlemek, onu kullanan tüm şekilleri günceller; bu örnekte yalnızca sol dikdörtgen yeşile döner.

Mevcut bir şekil üzerinde, yerel bir dolgu rengi, çizgi rengi veya çizgi kalınlığı tema stilinin o kısmını geçersiz kılabilir. Stil indeksi değişikliği görünür bir etki yapmazsa, şeklin [doğrudan biçimlendirmesine](/slides/tr/androidjava/shape-formatting/) bakın.

## **Etkili Katı Dolgunun Tema Rengi Kullanıp Kullanmadığını Belirleme**

Bir dolgu, nesne üzerinde doğrudan saklanabilir ya da paragraf, düzen, master, tema stili veya başka bir biçimlendirme seviyesinden miras alınabilir. Bu hiyerarşiyi değişmez bir [IFillFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) nesnesine çözümlemek için [IFillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/) çağırın. İlk olarak [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) kontrol edin. `FillType.Solid` ise katı dolgu özelliklerini okuyun.

Katı bir dolgu için, [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) kalıtım, tema araması ve renk dönüşümleri sonrasında nihai RGB değerini verir. [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) ise ilgili mantıksal [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/) slotunu döndürür; ör. `Text1` ya da `Accent6`. `SchemeColor.NotDefined` değeri, etkili katı dolgunun bir şema rengine dayanmadığını gösterir. Tema renkleri veya doğrudan RGB renkleri arasında bir iş akışı varsa, bu değer doğrudan RGB dolgu olduğunu belirtir.

Yalnızca yerel [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/) değerine dayanarak bir dolguyu sınıflandırmayın. Örneğin, bir metin parçasının yerel şema rengi tanımlı olmayabilir, dolayısıyla yerel değeri `NotDefined` olur; ancak etkili dolgu tema rengini devralır ve `Text1` ya da `Accent6` olarak çözülür. Öte yandan, `getSolidFillSchemeColor` hangi mantıksal tema slotunun etkili rengi ürettiğini söyler, fakat bu slotun nesneden, paragraftan, düzenden, masterʼdan veya başka bir seviyeden geldiğini söylemez.

Aşağıdaki örnek bir sunumu yükler, şekil dolgularını ve metin‑parça dolgularını denetler, her bir nihai RGB değerini ve ilişkili şema rengini yazar ve tema rengi değişikliklerine yanıt vermeyecek katı dolguları işaretler:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    int rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, Color.red(rgb), Color.green(rgb), Color.blue(rgb));
    System.out.println(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor.NotDefined) {
        System.out.println(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        System.out.println(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
};

Presentation presentation = new Presentation("input.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);

        int shapeCount = slide.getShapes().size();
        for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            String shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill.accept(shapeName, shape.getFillFormat());

            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                int paragraphCount = autoShape.getTextFrame().getParagraphs().getCount();
                for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    int portionCount = paragraph.getPortions().getCount();
                    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        IPortion portion = paragraph.getPortions().get_Item(portionIndex);
                        String portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill.accept(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

`NotDefined` dalı, tema rengi slotlarındaki değişikliklere yanıt vermeyecek katı dolguların bir denetim listesini sağlar. Yeni bir marka paleti uygulandığında bu nesneleri gözden geçirin. Raporlanan RGB değeri hâlâ mevcut görünümü gösterirken, şema değeri bu görünümün tema ile bağlantılı olup olmadığını açıklar.

Etkili‑format nesneleri anlık görüntüdür. Sunum temasını, bir tema geçersizliğini ya da herhangi bir devralınan biçimlendirmeyi değiştirdikten sonra, tekrar `getEffective` çağırın ve yeni bir `IFillFormatEffectiveData` nesnesi okuyarak renkleri karşılaştırın ya da raporlayın.

## **Etkili Tema Değerlerini Okuma**

Ham tema nesneleri, belirli bir seviyede neyin tanımlı olduğunu anlatır. Etkili değerler ise miras ve yerel geçersizlikler çözüldükten sonra bir slayt ya da şeklin gerçekte ne kullandığını gösterir. Bir slayt için [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/) çağırın. Bir arka plan için [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/), bir dolgu için ise [FillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/) kullanın.

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

Etkili verileri, render tanılama, doğrulama ve karşılaştırmalar için kullanın. Yalnızca [Presentation.getMasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) incelerseniz, bir master, düzen, slayt ya da şekil geçersizliğinin final görünümü değiştirdiğini gözden kaçırabilirsiniz.

## **SSS**

**Harici bir tema uygulanması sunumdaki her slaytı etkiler mi?**

Hayır. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) yalnızca seçilen masterʼa bağlı slaytları yeniden atar. Diğer masterʼları kullanan slaytlar mevcut temalarını korur.

**Bir slayta master değiştirilmeden tema uygulayabilir miyim?**

Evet. Slaytın [SlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidethememanager/) kullanın ve geçersiz tema başlatın. Değişiklik yalnızca o slayta yerel kalır; diğer slaytlar mevcut temalarını devralmaya devam eder.

**Bir temayı bir sunumdan diğerine taşımanın en güvenli yolu nedir?**

Bir slaytı taşırken ve kaynak görünümünü korurken, kaynak masterʼı hedefe klonlayın ve [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) ve [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) kullanarak slaytı o master ile klonlayın. Böylece master, düzenler ve tema birlikte korunur.

**Miras ve geçersizliklerden sonra etkili değerleri nasıl görebilirim?**

Bir slayt veya düzen teması için [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/) ve format nesneleri için ilgili etkili‑veri yöntemlerini (ör. [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) ve [FillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/)) kullanın. Bu API’ler, miras ve geçersizliklerin uygulanmasından sonra çözülmüş değerleri döndürür.