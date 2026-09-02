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
- dış tema
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
description: "Aspose.Slides for Android via Java ile tutarlı marka kimliği sağlayarak PowerPoint dosyalarını oluşturma, özelleştirme ve dönüştürme amacıyla ana sunum temalarını yönetin."
---
## **Giriş**

Bir sunum teması, koordineli bir renk, yazı tipi, arka plan stili, doldurma, çizgi ve efekt seti tanımlar. Tema‑bilgili nesneler, her görsel özelliği sabit bir değer olarak depolamak yerine bu ortak tanımlara başvurur; böylece tema değişikliği birçok nesneyi bir anda güncelleyebilir.

Aspose.Slides içinde, sunum‑seviyesindeki tema [Presentation.getMasterTheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) aracılığıyla kullanılabilir. Bir sunum ayrıca alt seviyelerde tema geçersizlikleri (override) içerebilir. Bir master, [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/masterthememanager/) ile sunum temasını geçersiz kılabilir; bir layout veya bireysel slayt ise [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/baseoverridethememanager/) ile devralınan temayı geçersiz kılabilir. Pratikte, bir slayt için etkili tema şu kalıtım zinciri üzerinden çözülür: sunum teması, master geçersizliği, layout geçersizliği ve slayt geçersizliği.

![Tema bileşenleri: renkler, yazı tipleri, arka plan stilleri ve efektler](theme-constituents.png)

Aşağıdaki bölümler en yaygın tema iş akışlarını gösterir: bir temayı inceleme, renk ve yazı tiplerini değiştirme, bir temayı kopyalama veya uygulama, arka plan ve efekt stillerini güncelleme ve kalıtım ile geçersizlikler çözüldükten sonra etkili değerleri okuma.

## **Bir Temayı İnceleme**

[MasterTheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mastertheme/) nesnesi, temanın renk şeması, yazı tipi şeması ve format şemasını sırasıyla [MasterTheme.getColorScheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mastertheme/) ve [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mastertheme/) aracılığıyla açığa çıkar. Bu koleksiyonları değiştirmeden önce incelemek, bir sunum dış bir kaynaktan geldiğinde stil girişlerinin sayısı ve içeriği değişebileceği için özellikle faydalıdır.

Aşağıdaki örnek ana tema özelliklerini okur ve temada kaç adet arka plan, doldurma, çizgi ve efekt stilinin depolandığını raporlar:

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

Bir dosya birden çok master içeriyorsa, her slaytın aynı etkili temaya sahip olduğunu varsaymayın. Slaytla ilişkili masterı inceleyin ve layout veya slayt geçersizlikleri mevcut olduğunda bu makalenin ilerleyen kısmında gösterilen etkili‑tema iş akışını kullanın.

## **Tema Renklerini Değiştirme**

Tema‑bilgili doldurma, çizgi ve metinler, [SchemeColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/schemecolor/) enum'undan mantıksal bir renge başvurabilir. [IColorScheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icolorscheme/) içindeki ilgili girdiyi değiştirdiğinizde, hâlâ o tema rengini başvuran tüm nesneler yeni değere göre çözülür. Doğrudan RGB rengi kullanan nesneler, tema‑rengi güncellemesinden etkilenmez.

Aşağıdaki uç‑uç örnek, `Accent4` kullanan bir şekil oluşturur, temanın `Accent4` rengini kırmızıya değiştirir, sunumu kaydeder, yeniden açar ve etkili doldurma rengini yazdırır:

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

Dikdörtgen `Accent4`e bağlı kaldığı için tema değiştirildiğinde görünen rengi kırmızı olur. Şekildeki şema rengini doğrudan bir renkle değiştirirseniz, sonraki `Accent4` değişiklikleri bu doldurmayı etkilemez.

### **Ek Paletten Renkleri Kullanma**

PowerPoint, bir tema renginden daha açık ve daha koyu varyantlar üretmek için renk dönüşümleri uygular. Aspose.Slides bu dönüşümleri [ColorTransformOperation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/colortransformoperation/) enum'ı üzerinden sunar.

![Ana tema renkleri ve ek paletten üretilen daha açık ve daha koyu renkler](additional-palette-colors.png)

**1** - Ana tema renkleri.

**2** - Ana tema renklerinden üretilen daha açık ve daha koyu varyantlar.

Aşağıdaki örnek, `Accent4` temelinde altı dikdörtgen oluşturur, bunların beşine parlaklık dönüşümleri uygular ve sonucu kaydeder:

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

Bu varyantlar tema rengine dayanır. `Accent4` daha sonra değişirse, dönüştürülmüş renkler yeni `Accent4` değerine göre yeniden hesaplanır.

### **`SchemeColor` Değerlerini `IColorScheme` Yuvalarına Eşleme**

[SchemeColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/schemecolor/) enum'ı `Text1`, `Background1`, `Text2` ve `Background2` kullanırken, [IColorScheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icolorscheme/) aynı tema yuvalarını `Dark1`, `Light1`, `Dark2` ve `Light2` olarak sunar. Eşleme sabittir:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Bunlar aynı tema yuvalarının alternatif adlarıdır; bir formdan diğerine dinamik dönüşüm yapılmaz.

## **Tema Yazı Tiplerini Değiştirme**

Bir tema yazı tipi şeması, başlıklar için bir ana (major) yazı tipi kümesi ve gövde metni için bir yan (minor) yazı tipi kümesi içerir. [IFontScheme.getMajor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifontscheme/) ve [IFontScheme.getMinor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifontscheme/) yöntemleri bu kümeleri açığa çıkar.

PowerPoint‑uyumlu tema yazı tipi tanımlayıcıları metin biçimlendirmesinde kullanılabilir:

* `+mn-lt` - Body Font Latin (Minor Latin Font)
* `+mj-lt` - Heading Font Latin (Major Latin Font)
* `+mn-ea` - Body Font East Asian (Minor East Asian Font)
* `+mj-ea` - Heading Font East Asian (Major East Asian Font)

Aşağıdaki örnek, ana Latin tema yazı tipini kullanan bir başlık ve yan Latin tema yazı tipini kullanan bir gövde satırı oluşturur. Ardından tema yazı tiplerini değiştirir ve sonucu kaydeder:

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

Başlık ana yazı tipini, gövde metni ise yan yazı tipini izler. Açık bir yazı tipi adıyla belirtilen metin, tema yazı tipi şeması değiştiğinde otomatik olarak değişmez.

Ana ve yan yazı tipi koleksiyonları, Kiril, Arapça, Japonca, Gürcüce ve Thaana gibi bireysel yazı sistemleri için yazı tipi eşlemeleri de içerebilir. Bu eşlemeleri incelemek, eklemek, değiştirmek veya kaldırmak için [Script-Specific Theme Fonts](/slides/tr/androidjava/script-specific-font-mappings/) bölümüne bakın.

{{% alert color="info" title="İpucu" %}}

Sunum yazı tipleri hakkında daha fazla bilgi için [PowerPoint Fonts](/slides/tr/androidjava/powerpoint-fonts/) sayfasına bakın.

{{% /alert %}}

## **Bir Temayı Kopyalama veya Uygulama**

Aşağıdaki iş akışları farklı tema‑ile ilgili sorunları çözer.

### **Bir Master’a Bağlı Slaytlara Dış Tema Uygulama**

Bir PowerPoint tema dosyanız (`.thmx`) varsa ve belirli bir master’a bağlı tüm slaytların stilini yeniden uygulamak istiyorsanız [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterslide/) kullanın. [Presentation.getMasters](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) koleksiyonundan masterı seçin (bu koleksiyon [IMasterSlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterslidecollection/) uygular) ve tema dosyası yolunu metoda geçirin.

Metod şu adımları gerçekleştirir:

1. Seçilen master baz alınarak yeni bir master slayt oluşturur.
1. Dış temayı yeni master’a uygular.
1. Yeni master’ı, daha önce seçilen master’a bağlı tüm slaytlara atar.
1. Yeni oluşturulan [IMasterSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterslide/) nesnesini döndürür.

Aşağıdaki örnek, ilk master’a bağlı slaytlara dış tema uygular ve sunumu kaydeder:

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

Yalnızca seçilen master’a bağlı slaytlar yeniden atanır. Diğer master’larla ilişkili slaytlar mevcut master ve temalarını korur. Tema‑bilgili renkler, yazı tipleri, doldurular, çizgiler, arka planlar ve efektler dış tema üzerinden çözülür. Doğrudan atanmış renkler, yazı tipleri, doldurmalar ve diğer açık biçimlendirmeler değişmemiş kalabilir. Layout‑seviyesindeki ve slayt‑seviyesindeki geçersizlikler yeni master’dan miras alınan değerlerin üzerine gelebilir.

Tema, çalışma zamanında bulunmayan yazı tiplerine referans verebilir. Tutarlı görüntüleme ve dışa aktarma için gerekli yazı tiplerini kurun, [özel yazı tipi kaynakları](/slides/tr/androidjava/custom-font/) aracılığıyla sağlayın veya [yazı tipi ikamesi](/slides/tr/androidjava/font-substitution/) yapılandırın.

Bu doğrudan master‑seviyesi bir iş akışıdır: metod bir `.thmx` dosya yolu alır ve slayt‑seviyesi ya da layout‑seviyesi tema geçersizlikleri manuel olarak oluşturulmasını gerektirmez.

### **Çok‑Masterlı Bir Sunumda Farklı Dış Temalar Uygulama**

İlgili master önceden bilinmiyorsa, bir temsilci slayttan [ISlide.getLayoutSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/) ve [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutslide/) ile master alın. Tema uygulamadan önce orijinal master referanslarını saklayın; çünkü her çağrı sunumda yeni bir master oluşturur.

Aşağıdaki örnek, iki bölümden slaytları alarak masterlarını bulur ve her grup için farklı bir dış tema uygular:

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

İlk çağrı yalnızca `firstGroupMaster`a bağlı slaytları etkiler, ikinci çağrı ise yalnızca `secondGroupMaster`a bağlı slaytları etkiler. Diğer master’lara bağlı slaytlar yeniden stil verilmez.

### **Slayt Taşıma Sırasında Kaynak Temasını Korumak**

Bir slaytı başka bir sunuma taşımak ve orijinal tasarımını korumak istiyorsanız, kaynak master’ı hedef sunuma [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterslidecollection/) ile klonlayın, ardından slaytı [ISlideCollection.addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidecollection/) ve klonlanmış master ile klonlayın. Böylece master, layout’ları ve ilişkili tema birlikte taşınır.

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

Bu, kaynak slaytın hedefte aynı görünümde olmasını istediğinizde tercih edilen iş akışıdır. İçeriği yalnızca ilişkili olmayan bir hedef master’a klonlamak, tema‑tabanlı renkler, yazı tipleri, arka planlar ve efektlerde değişikliklere yol açabilir.

### **Mevcut Bir Slayta Tema Değerleri Uygulama**

Hedef slayt mevcut master ve layout’da kalmalıysa, kaynak temadan slayt‑seviyesi bir geçersizlik başlatın. [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/overridetheme/) ve [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/overridetheme/) yöntemleri üç ana tema bileşenini geçersizliğe kopyalar.

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

Bu, diğer slaytların miras aldığı temayı değiştirmeden yalnızca bu slaytın temasını değiştirir. Yerel geçersizliği kaldırıp miras alınan değerlere dönmek için [OverrideTheme.clear](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/overridetheme/) çağırın.

### **Bir Layout’a Tema Geçersizliği Uygulama**

Layout‑seviyesi bir geçersizlik, o layout’u kullanan slaytlara uygulanır; fakat belirli bir slayt kendi geçersizliğine sahipse, o slayt bunun üzerine yazar. Aynı başlatma yöntemleri, [LayoutSlideThemeManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/layoutslidethememanager/) üzerinden kullanılabilir:

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

Birçok layout ve slayt aynı temel tasarımı paylaşmalıysa master ya da sunum‑seviyesi tema kullanın; bir layout ailesi farklı bir stil isterse layout geçersizliği, sadece gerçek istisnalar için slayt geçersizliği tercih edin. Aşırı slayt‑seviyesi geçersizlikler, sonradan yapılan küresel tema değişikliklerini tahmin etmeyi zorlaştırır.

## **Tema Arka Plan Stillerini Güncelleme**

Tema arka plan doldurmaları, [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iformatscheme/) içinde depolanır. PowerPoint, kullanıcı arayüzünde bu koleksiyonda fiziksel olarak saklanan doldurma tanımlarının sayısından daha fazla arka plan seçeneği sunabilir; çünkü UI tema doldurmalarını tema renkleri ve diğer stil referanslarıyla birleştirebilir.

![PowerPoint arka plan stil galerisinde bir sunum temasına ait stiller](presentation-design_8.png)

Bir arka plan stilini kullanmadan önce saklanan koleksiyonu ve mevcut [Background.getStyleIndex](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/background/) değerini inceleyin. `0` indeksi, temalı bir doldurma olmadığını, pozitif değerler ise tema arka plan‑stil referanslarını gösterir. Bu, Java koleksiyonundaki indeksleme (`get_Item(0)` ilk öğeyi verir) ile aynı şey değildir. Her sunumun aynı sayıda arka plan doldurma stiline sahip olduğunu varsaymayın.

Aşağıdaki örnek, mevcut arka plan doldurma sayısını raporlar, ilk master’a temalı bir arka plan referansı atar ve sunumu kaydeder:

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

Görünüm, master’ın referans verdiği tema girişine ve layout ya da slayt seviyesindeki olası arka plan geçersizliklerine bağlıdır. Bir slayt kendi arka planını kullanıyorsa, yalnızca master arka planını değiştirmek o slaytı etkilemez. Kalıtım uygulanmış nihai arka planı öğrenmek için [Background.getEffective](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/background/) kullanın.

{{% alert color="warning" title="Uyarı" %}}

Stil indeksini sıfır‑tabanlı bir koleksiyon indeksi gibi işlemeyin. Ayrıca bir dosyadan bir stil numarasını sabit kodlamaktan ve başka bir dosyada aynı görünüme sahip olacağını varsaymaktan kaçının; tema stil tanımlamaları sunuma özgüdür.

{{% /alert %}}

{{% alert color="info" title="İpucu" %}}

Doğrudan arka plan biçimlendirmesi ve arka plan kalıtımı için [Presentation Background](/slides/tr/androidjava/presentation-background/) bölümüne bakın.

{{% /alert %}}

## **Tema Efektlerini Güncelleme**

Bir tema format şeması, [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iformatscheme/) ve [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iformatscheme/) aracılığıyla ayrı doldurma, çizgi ve efekt stil koleksiyonları sunar. Tipik Office temaları genellikle görsel olarak hafif, orta ve yoğun biçimlendirmelere karşılık gelen üç ana stil girişine sahiptir, ancak kod sabit bir sayıya dayanmak yerine her koleksiyonu incelemelidir.

![Aynı şekle uygulanmış hafif, orta ve yoğun tema efektleri](presentation-design_10.png)

Java’da bu koleksiyonlara erişirken indeks sıfır‑tabanlıdır: `get_Item(0)` ilk depolanmış stil, `get_Item(2)` ise üçüncüdür. Bir şeklin stil‑referans indeksleri ayrı bir kavramdır ve [IShapeStyle](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapestyle/) aracılığıyla açığa çıkar. Bir tema stilini değiştirmek, o temayı referans eden şekilleri etkiler; doğrudan biçimlendirilmiş şekiller değişmez.

Aşağıdaki örnek, gereken stil girişlerinin mevcut olduğunu kontrol eder, ilk çizgi stilini değiştirir, üçüncü doldurma stilini değiştirir, üçüncü efekt stilinde dış gölgeyi etkinleştirir ve sonucu kaydeder:

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

Bu yuvalara referans veren şekiller için ilk tema çizgi stili kırmızı, üçüncü tema doldurma stili katı orman yeşili ve üçüncü efekt stili 10 puan mesafede bir dış gölge kazanır. Tam görsel sonuç, hangi stil yuvalarının hangi şekil tarafından referans alındığına ve doğrudan biçimlendirme tarafından temanın üzerine yazılıp yazılmadığına bağlıdır.

![Çizgi, doldurma ve gölge ayarları değiştirildikten sonra tema efekt stilleri](presentation-design_11.png)

## **Etkili Katı Doldurmanın Tema Rengini Kullanıp Kullanmadığını Belirleme**

Bir doldurma, nesne üzerinde doğrudan depolanabilir veya bir paragraftan, layout’tan, master’dan, tema stilinden ya da başka bir biçimlendirme seviyesinden kalıtılabilir. Bu hiyerarşiyi değişmez bir [IFillFormatEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifillformateffectivedata/) nesnesine dönüştürmek için [IFillFormat.getEffective](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifillformat/) çağırın. İlk önce [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifillformateffectivedata/) kontrol edin. `FillType.Solid` olduğunda katı doldurma özelliklerini okuyabilirsiniz.

Katı doldurma için [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifillformateffectivedata/) kalıtım, tema araması ve renk dönüşümleri uygulandıktan sonraki nihai RGB değerini döndürür. [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifillformateffectivedata/) ise `Text1` veya `Accent6` gibi ilgili mantıksal [SchemeColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/schemecolor/) yuvasını verir. `SchemeColor.NotDefined` değeri, etkili katı doldurmanın bir şema rengine dayanmadığını gösterir. Tema renkleriyle ya da doğrudan RGB renkleriyle çalışan bir iş akışında bu değer doğrudan RGB doldurmayı tanımlar.

Yerel [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icolorformat/) değerine tek başına bakarak bir doldurmayı sınıflandırmayın. Örneğin, bir metin parçasının yerel şema rengi tanımlı olmayabilir (`NotDefined`), ancak etkili doldurması bir tema rengine miras alıp `Text1` ya da `Accent6` olarak çözülür. Öte yandan, `getSolidFillSchemeColor` hangi mantıksal tema yuvasının etkili rengi ürettiğini söyler, ancak bu yuvanın nesneden, paragraftan, layout’tan, master’dan ya da başka bir seviyeden gelip gelmediğini belirtmez.

Aşağıdaki örnek bir sunumu yükler, şekil doldurmalarını ve metin‑parça doldurmalarını denetler, her bir nihai RGB değerini ve ilişkili şema rengini yazdırır, ve tema rengi değişikliklerini takip etmeyecek katı doldurmaları işaretler:

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

`NotDefined` dalı, tema renk yuvalarındaki değişikliklere yanıt vermeyecek katı doldurmaların bir denetim listesini sağlar. Bu nesneleri, bir sunumun yeni bir marka paletine uyması gerektiğinde gözden geçirin. Raporlanan RGB değeri hâlâ mevcut görünümü gösterirken, şema değeri bu görünümün tema ile bağlantılı olup olmadığını açıklar.

Etkili‑format nesneleri anlık görüntüdür. Sunum temasını, bir tema geçersizliğini veya kalıtılan biçimlendirmeyi değiştirdikten sonra, renkleri karşılaştırmadan ya da raporlamadan önce `getEffective` tekrar çağırıp yeni bir `IFillFormatEffectiveData` nesnesi alın.

## **Etkili Tema Değerlerini Okuma**

Ham tema nesneleri, belirli bir seviyede neyin tanımlandığını gösterir. Etkili değerler, kalıtım ve yerel geçersizlikler çözüldükten sonra bir slayt ya da şeklin gerçekte ne kullandığını gösterir. Bir slayt için [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/baseoverridethememanager/) çağırın. Bir arka plan için [Background.getEffective](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/background/), bir doldurma için [FillFormat.getEffective](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fillformat/) kullanın.

Aşağıdaki örnek bir slayttan etkili temayı, arka planı ve ilk şekil doldurmasını okur:

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

Renkleme, doğrulama ve karşılaştırmalar için etkili verileri kullanın. Yalnızca [Presentation.getMasterTheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) incelerseniz, master, layout, slayt veya şekil geçersizliklerinin final görünümü değiştirebileceğini kaçırabilirsiniz.

## **SSS**

**Dış bir tema uygulamak, sunumdaki her slaytı etkiler mi?**

Hayır. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterslide/) yalnızca seçilen master’a bağlı slaytları yeniden atar. Diğer master’ları kullanan slaytlar mevcut temalarını korur.

**Bir slayta master’ı değiştirmeden tema uygulayabilir miyim?**

Evet. Slaytın [SlideThemeManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slidethememanager/) kullanın ve geçersizlik temasını başlatın. Değişiklik yalnızca o slayta yerel olarak uygulanır; diğer slaytlar mevcut temalarını miras almaya devam eder.

**Bir temayı bir sunumdan diğerine taşımak için en güvenli yol nedir?**

Bir slaytı taşırken kaynak görünümünü korumak istiyorsanız, kaynak master’ı hedefe klonlayın ve ardından slaytı o master ile birlikte [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterslidecollection/) ve [ISlideCollection.addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidecollection/) kullanarak klonlayın. Böylece master, layout’lar ve tema birlikte taşınır.

**Kalıtım ve geçersizliklerden sonra etkili değerleri nasıl görebilirim?**

Bir slayt veya layout teması için [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/baseoverridethememanager/) ve format nesneleri için ilgili etkili‑veri metodlarını (ör. [Background.getEffective](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/background/) ve [FillFormat.getEffective](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fillformat/)) kullanın. Bu API’ler, kalıtım ve geçersizlikler uygulandıktan sonra çözülmüş değerleri döndürür.