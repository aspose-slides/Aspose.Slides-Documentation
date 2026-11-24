---
title: Java'da Sunum Temalarını Yönet
linktitle: Sunum Teması
type: docs
weight: 10
url: /tr/java/presentation-theme/
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
- tema etkisi
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da tutarlı bir marka ile PowerPoint dosyalarını oluşturmak, özelleştirmek ve dönüştürmek için ana sunum temaları."
---
## **Giriş**

Sunum teması, renkler, yazı tipleri, arka plan stilleri, doldurular, çizgiler ve efektlerden oluşan koordineli bir küme tanımlar. Tema farkında nesneler, her görsel özelliği sabit değer olarak depolamak yerine bu ortak tanımlara başvurur, böylece bir tema değişikliği birçok nesneyi aynı anda güncelleyebilir.

Aspose.Slides içinde, sunum düzeyindeki tema, [Presentation.getMasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) aracılığıyla kullanılabilir. Bir sunum, daha düşük düzeylerde tema geçersiz kılmaları da içerebilir. Bir master, [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/java/com.aspose.slides/masterthememanager/) aracılığıyla sunum temasını geçersiz kılabilir, bir düzen veya tek bir slayt ise kalıtılan temasını [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/) aracılığıyla geçersiz kılabilir. Pratikte, bir slayt için etkili tema, şu kalıtım zinciri üzerinden çözülür: sunum teması, master geçersiz kılması, düzen geçersiz kılması ve slayt geçersiz kılması.

![Tema bileşenleri: renkler, yazı tipleri, arka plan stilleri ve efektler](theme-constituents.png)

Aşağıdaki bölümler en yaygın tema iş akışlarını gösterir: bir temayı inceleme, renk ve yazı tiplerini değiştirme, bir temayı kopyalama veya uygulama, arka plan ve efekt stillerini güncelleme ve kalıtım ve geçersiz kılmalar çözüldükten sonra etkili değerleri okuma.

## **Bir Temayı İnceleme**

[MasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/) nesnesi, temanın renk şemasını, yazı tipi şemasını ve format şemasını [MasterTheme.getColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/) ve [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/) aracılığıyla ortaya çıkarır. Bu koleksiyonları değiştirmeden önce incelemek, bir sunum harici bir kaynaktan geldiğinde özellikle faydalıdır çünkü stil girişlerinin sayısı ve içeriği değişebilir.

Aşağıdaki örnek, ana tema özelliklerini okur ve temada kaç adet arka plan, doldurma, çizgi ve efekt stilinin depolandığını raporlar:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    System.out.println("Theme name: " + theme.getName());
    System.out.println("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
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

Bir dosya birden çok master kullanıyorsa, her slaytın aynı etkili temaya sahip olduğunu varsaymayın. Slayt ile ilişkili master'ı inceleyin ve düzen veya slayt geçersiz kılmaları mevcut olduğunda bu makalenin ilerleyen kısmında gösterilen etkili tema iş akışını kullanın.

## **Tema Renklerini Değiştirme**

Tema farkında doldurmalar, çizgiler ve metinler, [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/) enumerasyonundaki mantıksal bir renge başvurabilir. [IColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/icolorscheme/) içindeki ilgili girişi değiştirdiğinizde, hâlâ o tema rengine başvuran tüm nesneler yeni değerle çözümlenir. Doğrudan RGB rengi kullanan nesneler tema rengi güncellemesinden etkilenmez.

Aşağıdaki uçtan uca örnek, `Accent4` kullanan bir şekil oluşturur, temanın `Accent4` rengini kırmızıya değiştirir, sunumu kaydeder, yeniden açar ve etkili doldurma rengini yazdırır:

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    System.out.println("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

Dikdörtgen `Accent4`'e bağlı kalmaya devam ettiğinden, tema değiştirildikten sonra görünen rengi kırmızı olur. Şekilde şema rengini doğrudan bir renkle değiştirirseniz, sonraki `Accent4` değişiklikleri artık bu doldurmayı etkilemez.

### **Ek Paletten Renkleri Kullanma**

PowerPoint, bir tema renginden renk dönüşümleri uygulayarak daha açık ve daha koyu varyantlar türetir. Aspose.Slides bu dönüşümleri [ColorTransformOperation](https://reference.aspose.com/slides/java/com.aspose.slides/colortransformoperation/) enumerasyonu aracılığıyla ortaya çıkarır.

![Ana tema renkleri ve ek paletten oluşturulan daha açık ve daha koyu renkler](additional-palette-colors.png)

**1** - Ana tema renkleri.

**2** - Ana tema renklerinden üretilen daha açık ve daha koyu varyantlar.

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

Bu varyantlar tema rengine dayalı kalır. `Accent4` daha sonra değişirse, dönüştürülmüş renkler yeni `Accent4` değerinden yeniden hesaplanır.

### **`SchemeColor` Değerlerini `IColorScheme` Yuvalarına Eşleme**

[SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/) enumerasyonu `Text1`, `Background1`, `Text2` ve `Background2` değerlerini kullanırken, [IColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/icolorscheme/) aynı tema yuvalarını `Dark1`, `Light1`, `Dark2` ve `Light2` olarak ortaya çıkarır. Eşleme sabittir:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Bunlar aynı tema yuvalarının alternatif adlarıdır; bir biçimden diğerine dinamik olarak dönüştürülen değerler değildir.

## **Tema Yazı Tiplerini Değiştirme**

Bir tema yazı tipi şeması, başlıklar için büyük bir yazı tipi seti ve gövde metni için küçük bir yazı tipi seti içerir. [IFontScheme.getMajor](https://reference.aspose.com/slides/java/com.aspose.slides/ifontscheme/) ve [IFontScheme.getMinor](https://reference.aspose.com/slides/java/com.aspose.slides/ifontscheme/) yöntemleri bu setleri ortaya çıkarır.

PowerPoint uyumlu tema yazı tipi tanımlayıcıları metin biçimlendirmesinde kullanılabilir:

* `+mn-lt` - Gövde Yazı Tipi Latin (Küçük Latin Yazı Tipi)
* `+mj-lt` - Başlık Yazı Tipi Latin (Büyük Latin Yazı Tipi)
* `+mn-ea` - Gövde Yazı Tipi Doğu Asya (Küçük Doğu Asya Yazı Tipi)
* `+mj-ea` - Başlık Yazı Tipi Doğu Asya (Büyük Doğu Asya Yazı Tipi)
* `+mn-cs` - Gövde Yazı Tipi Karmaşık Betik (Küçük Karmaşık Betik Yazı Tipi)
* `+mj-cs` - Başlık Yazı Tipi Karmaşık Betik (Büyük Karmaşık Betik Yazı Tipi)

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

Başlık büyük yazı tipini, gövde metni ise küçük yazı tipini izler. Tema tanımlayıcısı yerine açık bir yazı tipi adı verilen metin, tema yazı tipi şeması değiştiğinde otomatik olarak değişmez.

Büyük ve küçük yazı tipi koleksiyonları ayrıca Kiril, Arapça, Japonca, Gürcüce ve Thaana gibi bireysel yazı sistemleri için yazı tipi eşlemeleri içerebilir. Bu eşlemeleri incelemek, eklemek, değiştirmek veya kaldırmak için [Script-Specific Theme Fonts](/slides/tr/java/script-specific-font-mappings/) bölümüne bakın.

{{% alert color="info" title="Tip" %}}
Sunum yazı tipleri hakkında daha fazla bilgi için [PowerPoint Fonts](/slides/tr/java/powerpoint-fonts/) sayfasına bakın.
{{% /alert %}}

### **Tema Yazı Tipi Referanslarını Çözme**

Metni incelerken, [IFontData.getFontName](https://reference.aspose.com/slides/java/com.aspose.slides/ifontdata/#getFontName--) bir yazı tipi aile adı yerine `+mn-lt` gibi bir tema referansı döndürebilir. Bu referansı çözmek için uygun [IThemeEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ithemeeffectivedata/) ile [IFontData.getFontName](https://reference.aspose.com/slides/java/com.aspose.slides/ifontdata/#getFontName-com.aspose.slides.IThemeEffectiveData-) çağırın. `+mj` ve `+mn` önekleri büyük ve küçük yazı tipi setlerini seçer; `-lt`, `-ea` ve `-cs` soneki ise sırasıyla Latin, Doğu Asya ve Karmaşık Betik yazı tiplerini seçer.

Etkili temayı, incelenen metne temasını uygulayan nesne üzerinde [IThemeable.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ithemeable/#createThemeEffective--) aracılığıyla alın. Bir slayttaki normal metin için, bu yöntemi slayt üzerinde çağırın, böylece bağlam o slaydın kalıtılan teması ve yerel geçersiz kılmalarını içerir. Bir düzen veya master'ı incelerken, onun kendi etkili temasını kullanın. İlk master'ın temasının her slayta uygulandığını varsaymayın.

Aşağıdaki örnek, küçük Latin yazı tipine açıkça referans veren bir metin bölümü oluşturur. [IOverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridetheme/#initFontSchemeFromInherited--) aracılığıyla bir slayt yazı tipi şeması başlatır ve büyük ve küçük Latin ailelerini `Arial` ve `Calibri` olarak ayarlar, böylece sonuç girdi dosyası olmadan yeniden üretilebilir:

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

Çıktı, `+mn-lt -> Calibri` ve ardından `Verdana -> Verdana` şeklindedir. Depolanan referans değişmeden kalır, açık bir aile adı olduğu gibi döner. Bölüm `+mj-lt` kullansaydı, bu temada `Arial` olarak çözülürdü.

Bir tema referansını çözmek, tema tarafından belirtilen yazı tipi ailesini tanımlar. Bu, yazı tipinin kullanılabilirliğini kontrol etmez veya render sırasında ikame veya glif geri dönüşü sonrası kullanılan yazı tipi dosyasını belirlemez. Bu ayrı adımlar için [Font Selection Sequence](/slides/tr/java/font-selection-sequence/) ve [Font Substitution](/slides/tr/java/font-substitution/) bölümlerine bakın.

## **Bir Temayı Kopyalama veya Uygulama**

Aşağıdaki iş akışları farklı tema ile ilgili sorunları çözer.

### **Harici Bir Temayı Master'ın Bağlı Slaytlarına Uygulama**

Bir PowerPoint tema dosyanız (`.thmx`) olduğunda ve belirli bir master'a bağlı tüm slaytların stilini yeniden uygulamak istediğinizde, [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) metodunu kullanın. [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) koleksiyonundan master'ı seçin; bu koleksiyon [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) uygular ve tema dosya yolunu metoda iletin.

Metod aşağıdaki işlemleri yapar:

1. Seçilen master'a dayanarak yeni bir master slaytı oluşturur.
1. Harici temayı yeni master'a uygular.
1. Yeni master'ı, daha önce seçilen master'a bağlı olan tüm slaytlara atar.
1. Yeni oluşturulan [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) nesnesini döndürür.

Aşağıdaki örnek, ilk master'a bağlı slaytlara harici bir tema uygular ve sunumu kaydeder:

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

Geçersiz, bozuk ya da desteklenmeyen bir tema, [PptxReadException](https://reference.aspose.com/slides/java/com.aspose.slides/pptxreadexception/) oluşturabilir. Kullanıcıların sağladığı yolları doğrulayın, dosya sistemi erişim hatalarını ele alın ve temanın başarıyla uygulandığından emin olduktan sonra sunumu kaydedin.

Yalnızca seçilen master'a bağlı slaytlar yeniden atanır. Diğer master'larla ilişkili slaytlar mevcut master ve temalarını korur. Tema farkında renkler, yazı tipleri, doldurmalar, çizgiler, arka planlar ve efektler harici temaya göre çözülür. Doğrudan atanmış renkler, yazı tipleri, doldurmalar ve diğer açık biçimlendirmeler değişmeden kalabilir. Düzen düzeyindeki ve slayt düzeyindeki geçersiz kılmalar da yeni master'dan kalıtılan değerler üzerine geçebilir.

Tema, çalışma zamanı ortamında bulunmayan yazı tiplerine referans verebilir. Tutarlı render ve dışa aktarım için gerekli yazı tiplerini kurun, onları [custom font sources](/slides/tr/java/custom-font/) aracılığıyla sağlayın veya [font substitution](/slides/tr/java/font-substitution/) yapılandırın.

Bu doğrudan master düzeyinde bir iş akışıdır: metod bir `.thmx` dosya yolunu kabul eder ve slayt düzeyinde veya düzen düzeyinde tema geçersiz kılmaları manuel olarak oluşturmayı gerektirmez.

### **Çok Masterlı Sunumda Farklı Harici Temalar Uygulama**

İlgili master önceden bilinmediğinde, temsilci bir slayttan [ISlide.getLayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) ve [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslide/) aracılığıyla elde edin. Her çağrı sunumda yeni bir master oluşturduğundan, tema uygulamadan önce orijinal master referanslarını saklayın.

Aşağıdaki örnek, iki bölümden slaytları kullanarak master'larını bulur ve her grup için farklı bir harici tema uygular:

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

İlk çağrı yalnızca `firstGroupMaster`'a bağlı slaytları etkiler, ikinci çağrı yalnızca `secondGroupMaster`'a bağlı slaytları etkiler. Başka bir master'a ait slaytlar yeniden stilize edilmez.

### **Kaynak Temasını Slayt Taşıma Sırasında Korumak**

Bir slaytı başka bir sunuma taşımak ve özgün tasarımını korumak istiyorsanız, kaynak master'ı hedef sunuma [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) ile klonlayın, ardından slaytı [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/) ve klonlanmış master ile klonlayın. Bu, master'ı, düzenlerini ve ilişkili temayı birlikte taşır.

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

Bu, kaynak slaytın hedefte aynı görüneceği durumda tercih edilen iş akışıdır. İçeriği ilgisiz bir hedef master'a klonlamak, tema tabanlı renk, yazı tipi, arka plan ve efektleri değiştirebilir.

### **Mevcut Bir Slayta Tema Değerlerini Uygulama**

Hedef slayt mevcut master ve düzeninde kalmalıysa, kaynak temadan bir slayt düzeyinde geçersiz kılma başlatın. [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/) , [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/) ve [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/) yöntemleri üç ana tema bileşenini geçersiz kılamaya kopyalar.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);

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

Bu, o slaytın kullandığı temayı diğer slaytların kalıtılan temasını değiştirmeden değiştirir. Yerel geçersiz kılmayı kaldırmak ve kalıtılan değerlere dönmek için [OverrideTheme.clear](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/) çağırın.

### **Bir Düzen'e Tema Geçersiz Kılma Uygulama**

Bir düzen düzeyindeki geçersiz kılma, o düzeni kullanan slaytlara uygulanır; belirli bir slayt kendi geçersiz kılmasını sahip değilse. Aynı başlatma yöntemleri [LayoutSlideThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslidethememanager/) aracılığıyla kullanılabilir:

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);

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

Birçok düzen ve slayt aynı temel tasarımı paylaşacaksa master veya sunum düzeyinde tema kullanın, bir düzen ailesi farklı stil gerektiriyorsa düzen geçersiz kılmasını ve yalnızca gerçek istisnalar için slayt geçersiz kılmasını kullanın. Aşırı slayt düzeyinde geçersiz kılmalar, sonraki global tema değişikliklerini tahmin etmeyi zorlaştırır.

<!-- visual-explanation:presentation-theme:start -->
[![Bir master tema iki düzeni besler; bir düzen geçersiz kılması, daha yerel bir geçersiz kılmaya sahip bir slayt hariç, onun slaytlarını etkiler.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*Bir düzen geçersiz kılması, o düzeni kullanan slaytlara uygulanır; bir slayt kendi geçersiz kılmasını sağlamazsa. Tema tabanlı değerler çözülen şemalarını izler; açıkça biçimlendirilmiş nesneler yerel görünümlerini koruyabilir. Geçersiz kılmaları, tasarım istisnasının amacına uygun olarak dar tutun.*
<!-- visual-explanation:presentation-theme:end -->

## **Tema Arka Plan Stillerini Güncelleme**

Temanın arka plan doldurmaları, [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/) içinde depolanır. PowerPoint, UI'de bu koleksiyonda fiziksel olarak depolanan doldurma tanımlarından daha fazla arka plan seçeneği gösterebilir; çünkü UI tema doldurmalarını tema renkleri ve diğer stil referanslarıyla birleştirebilir.

![Bir sunum teması için PowerPoint arka plan stil galerisi](presentation-design_8.png)

Bir arka plan stili kullanmadan önce, depolanmış koleksiyonu ve mevcut [Background.getStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/background/) değerini inceleyin. `0` stil indeksi, temalı doldurma olmadığını; pozitif değerler tema arka plan-stil referansları olduğunu gösterir. Bu, Java koleksiyonunu doğrudan indekslemekten farklıdır; `get_Item(0)` ilk depolanmış öğedir. Her sunumun aynı sayıda arka plan doldurma stiline sahip olduğunu varsaymayın.

Aşağıdaki örnek, mevcut arka plan doldurma sayısını raporlar, ilk master'a temalı bir arka plan referansı atar ve sunumu kaydeder:

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

Görünür sonuç, master tarafından referans edilen tema girdisine ve düzen ya da slayt düzeyindeki herhangi bir arka plan geçersiz kılmasına bağlıdır. Bir slayt kendi arka planını kullanıyorsa, yalnızca master arka planını değiştirmek o slaytı etkilemeyebilir. Kalıtım uygulandıktan sonra son arka planı öğrenmeniz gerektiğinde [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/) kullanın.

{{% alert color="warning" title="Warning" %}}
Stil indeksini sıfır tabanlı bir koleksiyon indeksi gibi ele almayın. Ayrıca bir dosyadan stil numarasını sabit kodlamaktan ve başka bir dosyada aynı görünümde olacağını varsaymaktan kaçının; tema stil tanımları sunuma özeldir.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Doğrudan arka plan biçimlendirme ve arka plan kalıtımı için [Presentation Background](/slides/tr/java/presentation-background/) sayfasına bakın.
{{% /alert %}}

## **Tema Efektlerini Güncelleme**

Bir tema format şeması, [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/) ve [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/) aracılığıyla ortaya konan ayrı doldurma, çizgi ve efekt stil koleksiyonlarını içerir. Tipik Office temaları genellikle görsel olarak hafif, orta ve yoğun biçimlendirmeye karşılık gelen üç ana stil girdisi içerir; ancak kod sabit bir sayı varsaymak yerine her koleksiyonu incelemelidir.

![Aynı şekle uygulanan hafif, orta ve yoğun tema efektleri](presentation-design_10.png)

Bu koleksiyonlara Java'da eriştiğinizde, koleksiyon indeksi sıfır tabanlıdır: `get_Item(0)` ilk depolanmış stil, `get_Item(2)` üçüncüdür. Bir şeklin stil-referans indeksleri ayrı bir kavramdır ve [IShapeStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/) aracılığıyla ortaya konur. Bir tema stilini değiştirmek, o tema stiline başvuran şekilleri etkiler; doğrudan biçimlendirilmiş şekiller değişmeden kalabilir.

Aşağıdaki örnek, gerekli stil girdilerinin mevcut olduğunu kontrol eder, ilk çizgi stilini değiştirir, üçüncü doldurma stilini değiştirir, üçüncü efekt stilinde dış gölgeyi etkinleştirir ve sonucu kaydeder:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(new Color(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);

    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bu yuvalara başvuran şekiller için, ilk tema çizgi stili kırmızı olur, üçüncü tema doldurma stili katı orman yeşili olur ve üçüncü efekt stiline 10 puan mesafeli bir dış gölge eklenir. Kesin görsel sonuç, her şeklin hangi stil yuvalarına başvurduğuna ve doğrudan biçimlendirmenin temayı geçersiz kılıp kılmadığına bağlıdır.

![Çizgi, doldurma ve gölge ayarları değiştirildikten sonra tema efekt stilleri](presentation-design_11.png)

## **Bir Şekil İçin Tema Doldurma ve Çizgi Stillerini Seçme**

Bir şekil, doldurma ve konturunu [IShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/#setFillStyleIndex-short-) ve [IShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/#setLineStyleIndex-int-) aracılığıyla bağımsız olarak seçebilir. Her iki yöntem için, indeks `1` ilgili tema koleksiyonundaki ilk girişi (`get_Item(0)`) seçer, indeks `2` ise ikincisini (`get_Item(1)`) seçer.

Aşağıdaki örnek, yeni bir sunumun varsayılan temasında iki doldurma stili (altın ve gökyüzü mavisi) ve iki çizgi stili (6 pt koyu mavi ve 12 pt koyu kırmızı) ayarlar. Slaytı üç aşamada kaydeder, böylece sonuçları PowerPoint'te karşılaştırabilirsiniz:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IFormatScheme styles = presentation.getMasterTheme().getFormatScheme();

    IFillFormat goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(FillType.Solid);
    goldFill.getSolidFillColor().setColor(new Color(255, 215, 0));
    IFillFormat blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(FillType.Solid);
    blueFill.getSolidFillColor().setColor(new Color(135, 206, 235));

    ILineFormat thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(FillType.Solid);
    thinLine.getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    thinLine.setWidth(6);
    ILineFormat thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(FillType.Solid);
    thickLine.getFillFormat().getSolidFillColor().setColor(new Color(139, 0, 0));
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

    goldFill.getSolidFillColor().setColor(new Color(46, 139, 87));
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| İlk stiller | Sağ konturu değiştir | İlk tema doldurmasını düzenle |
|:---:|:---:|:---:|
| ![Altın ve gökyüzü mavi dikdörtgenler, ince koyu mavi konturlarla eşleşmiş](theme-style-initial.png) | ![Gökyüzü mavi dikdörtgen artık kalın koyu kırmızı bir kontura sahip](theme-style-line-changed.png) | ![Sol dikdörtgen artık yeşil ve her iki kontur da değişmemiş](theme-style-fill-changed.png) |

Farklı bir çizgi stili seçmek yalnızca sağ dikdörtgenin konturunu değiştirir. İlk tema doldurmasını düzenlemek onu kullanan her şekli günceller. Burada sadece sol dikdörtgen yeşile döner.

Mevcut bir şekilde, yerel doldurma rengi, çizgi rengi veya çizgi genişliği tema stilinin o kısmını geçersiz kılabilir. Bir stil indeksini değiştirmek görünür bir etki yaratmazsa, şeklin [direct formatting](/slides/tr/java/shape-formatting/) özelliğini kontrol edin.

## **Etkili Katı Doldurmanın Tema Rengi Kullanıp Kullandığını Belirleme**

Bir doldurma, doğrudan bir nesne üzerine depolanabilir veya bir paragraftan, düzenden, master'dan, tema stilinden veya başka bir biçimlendirme seviyesinden kalıtılabilir. Bu hiyerarşiyi değişmez bir [IFillFormatEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) nesnesine çözmek için [IFillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/) çağırın. Önce [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) kontrol edin. Yalnızca `FillType.Solid` olduğunda katı doldurma özelliklerini okumalısınız.

Katı bir doldurma için, [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) kalıtım, tema araması ve renk dönüşümleri uygulandıktan sonra nihai render edilmiş RGB değerini döndürür. [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) ilgili mantıksal [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/) yuvasını, örneğin `Text1` veya `Accent6` döndürür. `SchemeColor.NotDefined` değeri, etkili katı doldurmanın bir şema rengine dayanmadığını gösterir. Doldurmaların tema renkleri veya doğrudan RGB renkleri olduğu bir iş akışında bu değer doğrudan RGB doldurmayı tanımlar.

Bir doldurmayı sınıflandırmak için yalnızca yerel [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/) değerini kullanmayın. Örneğin, bir metin bölümü yerel olarak tanımlı bir şema rengine sahip olmayabilir, bu yüzden yerel değeri `NotDefined` olur, ancak etkili doldurma bir tema rengini kalıtabilir ve `Text1` veya `Accent6` olarak çözülür. Öte yandan, `getSolidFillSchemeColor` etkili rengi hangi mantıksal tema yuvasının ürettiğini söyler, ancak bu yuvanının nesneden, paragraftan, düzenden, master'dan veya başka bir biçimlendirme seviyesinden gelip gelmediğini söylemez.

Aşağıdaki örnek bir sunumu yükler, hem şekil doldurmalarını hem de metin bölümü doldurmalarını denetler, her bir nihai RGB değerini ve ilişkili şema rengini yazdırır ve tema rengi değişikliklerini izleyecek olmayan katı doldurmaları işaretler:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    Color rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, rgb.getRed(), rgb.getGreen(), rgb.getBlue());
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

`NotDefined` dalı, tema renk yuvalarındaki değişikliklere yanıt vermeyecek katı doldurmaların denetim listesini sağlar. Bir sunumun yeni bir marka paletini takip etmesi gerektiğinde bu nesneleri gözden geçirin. Raporlanan RGB değeri hâlâ mevcut görünümü gösterir, şema değeri ise bu görünümün temaya bağlı olup olmadığını açıklar.

Etkili biçim nesneleri anlık görüntülerdir. Sunum temasını, bir tema geçersiz kılmasını veya herhangi bir kalıtılan biçimlendirmeyi değiştirdikten sonra, karşılaştırma veya raporlama yapmadan önce `getEffective` tekrar çağırın ve yeni bir `IFillFormatEffectiveData` nesnesi okuyun.

## **Etkili Tema Değerlerini Okuma**

Saf tema nesneleri, belirli bir düzeyde neyin tanımlandığını söyler. Etkili değerler, bir slayt veya şeklin kalıtım ve yerel geçersiz kılmalar çözüldükten sonra gerçekte ne kullandığını gösterir. Bir slayt için, [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/) çağırın. Bir arka plan için, [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/) kullanın ve bir doldurma için [FillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/) kullanın.

Aşağıdaki örnek bir slayttan etkili tema, arka plan ve ilk şekil doldurmasını okur:

```java
import com.aspose.slides.*;

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
            System.out.println("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

Etkili verileri render teşhisi, doğrulama ve karşılaştırmalar için kullanın. Yalnızca [Presentation.getMasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) incelerseniz, son görünümü değiştiren bir master, düzen, slayt veya şekil geçersiz kılmasını kaçırabilirsiniz.

## **SSS**

**Harici bir tema uygulamak sunumdaki her slaytı etkiler mi?**

Hayır. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) yalnızca seçilen master'a bağlı slaytları yeniden atar. Diğer master'ları kullanan slaytlar mevcut temalarını korur.

**Master'ı değiştirmeden tek bir slayta tema uygulayabilir miyim?**

Evet. Slaytın [SlideThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/slidethememanager/) kullanın ve geçersiz kılma temasını başlatın. Değişiklik yalnızca o slayta yerel kalır; diğer slaytlar mevcut temalarını kalıtmaya devam eder.

**Bir temayı bir sunumdan diğerine taşımak için en güvenli yol nedir?**

Bir slaytı taşırken ve kaynak görünümünü korurken, kaynak master'ı hedefe klonlayın ve [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) ve [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/) kullanarak o master ile slaytı klonlayın. Bu, master'ı, düzenleri ve temayı birlikte tutar.

**Kalıtım ve geçersiz kılmalardan sonra etkili değerleri nasıl görebilirim?**

[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/) bir slayt veya düzen teması için ve [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/) ve [FillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/) gibi format nesneleri için ilgili etkili veri yöntemlerini kullanın. Bu API'ler kalıtım ve geçersiz kılmalar uygulandıktan sonra çözülmüş değerleri döndürür.