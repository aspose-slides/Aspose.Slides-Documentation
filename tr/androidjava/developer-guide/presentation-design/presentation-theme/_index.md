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
description: "Aspose.Slides for Android'de Java ile tutarlı marka kimliği sağlayan PowerPoint dosyalarını oluşturmak, özelleştirmek ve dönüştürmek amacıyla ana sunum temalarını yönetin."
---
## **Giriş**

Bir sunum teması, renkler, yazı tipleri, arka plan stilleri, doldurulmalar, çizgiler ve efektlerin koordineli bir setini tanımlar. Tema farkında nesneler, her görsel özelliği sabit bir değer olarak depolamak yerine bu ortak tanımlara başvurur, böylece bir tema değişikliği birden fazla nesneyi aynı anda güncelleyebilir.

Aspose.Slides içinde, sunum düzeyindeki tema [Presentation.getMasterTheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) aracılığıyla kullanılabilir. Bir sunum ayrıca daha düşük düzeylerde tema geçersiz kılmaları içerebilir. Bir master, temayı [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/masterthememanager/) aracılığıyla geçersiz kılabilir, bir düzen veya tek bir slayt ise kalıtılan temasını [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/baseoverridethememanager/) aracılığıyla geçersiz kılabilir. Pratikte, bir slayt için geçerli tema, şu kalıtım zinciri üzerinden çözülür: sunum teması, master geçersiz kılma, düzen geçersiz kılma ve slayt geçersiz kılma.

![Tema bileşenleri: renkler, yazı tipleri, arka plan stilleri ve efektler](theme-constituents.png)

Aşağıdaki bölümler en yaygın tema iş akışlarını gösterir: bir temayı inceleme, renk ve yazı tiplerini değiştirme, bir temayı kopyalama veya uygulama, arka plan ve efekt stillerini güncelleme ve kalıtım ve geçersiz kılmalar çözüldükten sonra geçerli değerleri okuma.

## **Bir Temayı İnceleme**

[MasterTheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mastertheme/) nesnesi, temanın renk şemasını, yazı tipi şemasını ve format şemasını [MasterTheme.getColorScheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mastertheme/) ve [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mastertheme/) aracılığıyla ortaya koyar. Bu koleksiyonları değiştirmeden önce incelemek, dış bir kaynaktan gelen bir sunumda stil girişlerinin sayısı ve içeriği değişebileceği için özellikle faydalıdır.

Aşağıdaki örnek, ana tema özelliklerini okur ve temada kaç tane arka plan, doldurma, çizgi ve efekt stilinin saklandığını raporlar:

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

Bir dosya birden çok master kullanıyorsa, her slaytın aynı geçerli temaya sahip olduğunu varsaymayın. Slaytla ilişkili masterı inceleyin ve düzen veya slayt geçersiz kılmaları mevcut olduğunda bu makalenin ilerleyen bölümlerinde gösterilen geçerli tema iş akışını kullanın.

## **Tema Renklerini Değiştirme**

Tema farkında doldurulmalar, çizgiler ve metin, [SchemeColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/schemecolor/) enum'ından mantıksal bir renge başvurabilir. [IColorScheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icolorscheme/) içindeki ilgili girişi değiştirdiğinizde, hâlâ o tema rengini başvuran tüm nesneler yeni değere göre çözülür. Doğrudan bir RGB rengi kullanan nesneler tema rengi güncellemesinden etkilenmez.

Aşağıdaki uçtan uca örnek, `Accent4` kullanan bir şekil oluşturur, temanın `Accent4` rengini kırmızıya değiştirir, sunumu kaydeder, yeniden açar ve geçerli doldurma rengini yazdırır:

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

Dikdörtgen `Accent4` ile bağlantılı kaldığı için, tema değiştirildiğinde görünür rengi kırmızı olur. Şekilde şema rengini doğrudan bir renkle değiştirirseniz, ileride `Accent4` değişiklikleri artık bu doldurmayı etkilemez.

### **Ek Paletten Renk Kullanma**

PowerPoint, bir tema renginden daha açık ve daha koyu varyantları renk dönüşümleri uygulayarak türetir. Aspose.Slides bu dönüşümleri [ColorTransformOperation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/colortransformoperation/) enum'ı aracılığıyla sunar.

![Ana tema renkleri ve ek paletten üretilen daha açık ve daha koyu renkler](additional-palette-colors.png)

**1** - Ana tema renkleri.

**2** - Ana tema renklerinden üretilen daha açık ve daha koyu varyantlar.

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

### **`SchemeColor` Değerlerini `IColorScheme` Slotlarına Eşleme**

[SchemeColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/schemecolor/) enum'ı `Text1`, `Background1`, `Text2` ve `Background2` kullanırken, [IColorScheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icolorscheme/) aynı tema slotlarını `Dark1`, `Light1`, `Dark2` ve `Light2` olarak ortaya koyar. Eşleme sabittir:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Bunlar aynı tema slotları için alternatif adlardır; dinamik olarak bir formdan diğerine dönüştürülen değerler değildir.

## **Tema Yazı Tiplerini Değiştirme**

Bir tema yazı tipi şeması, başlıklar için bir ana (major) yazı tipi seti ve gövde metni için bir yan (minor) set içerir. [IFontScheme.getMajor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifontscheme/) ve [IFontScheme.getMinor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifontscheme/) metodları bu setleri ortaya koyar.

PowerPoint uyumlu tema yazı tipi tanımlayıcıları metin biçimlendirmede kullanılabilir:

* `+mn-lt` - Gövde Yazı Tipi Latin (Minor Latin Font)
* `+mj-lt` - Başlık Yazı Tipi Latin (Major Latin Font)
* `+mn-ea` - Gövde Yazı Tipi Doğu Asya (Minor East Asian Font)
* `+mj-ea` - Başlık Yazı Tipi Doğu Asya (Major East Asian Font)

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

Başlık ana yazı tipini, gövde metni ise yan yazı tipini izler. Tema tanımlayıcısı yerine açık bir yazı tipi adı kullanılmışsa, tema yazı tipi şeması değiştiğinde otomatik olarak geçiş yapmaz.

{{% alert color="info" title="Tip" %}}
Sunum yazı tipleri hakkında daha fazla bilgi için [PowerPoint Fonts](/slides/tr/androidjava/powerpoint-fonts/) sayfasına bakın.
{{% /alert %}}

## **Bir Temayı Kopyalama veya Uygulama**

İki yaygın iş akışı vardır ve farklı problemleri çözerler.

### **Kaynak Temayı Slaytları Taşırken Koruma**

Bir slaytı başka bir sunuma taşımak ve özgün tasarımını korumak istiyorsanız, kaynak masterı hedef sunuma [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterslidecollection/) ile kopyalayın, ardından slaytı [ISlideCollection.addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidecollection/) ve kopyalanmış master ile klonlayın. Bu, masterı, onun düzenlerini ve ilişkili temayı birlikte taşır.

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

Bu, kaynak slaytın hedefte aynı göründüğü durumlarda tercih edilen iş akışıdır. İçeriği alakasız bir hedef master üzerine klonlamak tema tabanlı renk, yazı tipi, arka plan ve efektleri değiştirebilir.

### **Mevcut Bir Slayta Tema Değerlerini Uygulama**

Hedef slayt mevcut master ve düzeninde kalmalıysa, kaynak temadan slayt düzeyinde bir geçersiz kılma başlatın. [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/overridetheme/) ve [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/overridetheme/) metodları üç ana tema bileşenini geçersiz kılmaya kopyalar.

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

Bu, diğer slaytların kalıtım aldığı temayı değiştirmeden, yalnızca bu slaytın kullandığı temayı değiştirir. Yerel geçersiz kılmayı kaldırıp kalıtılan değerlere dönmek için [OverrideTheme.clear](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/overridetheme/) çağırın.

### **Bir Düzen İçin Tema Geçersiz Kılamasını Uygulama**

Düzen düzeyindeki geçersiz kılma, o düzeni kullanan slaytlara uygulanır; ancak belirli bir slayt kendi geçersiz kılmasına sahipse o geçersiz kılma önceliklidir. Aynı başlatma metodları [LayoutSlideThemeManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/layoutslidethememanager/) aracılığıyla kullanılabilir:

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

Birden çok düzen ve slayt aynı temel tasarımı paylaşmalıysa master veya sunum düzeyinde tema kullanın, bir düzen ailesi farklı bir stil istiyorsa düzen geçersiz kılmasını, yalnızca gerçek istisnalar için slayt geçersiz kılmasını tercih edin. Aşırı slayt düzeyinde geçersiz kılmalar, sonraki küresel tema değişikliklerini tahmin etmeyi zorlaştırır.

## **Tema Arka Plan Stillerini Güncelleme**

Temanın arka plan doldurulmaları, [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iformatscheme/) içinde saklanır. PowerPoint, UI’da temalı doldurmaları tema renkleri ve diğer stil referanslarıyla birleştirerek, bu koleksiyonda fiziksel olarak tanımlı doldurma sayısından daha fazla arka plan seçeneği sunabilir.

![Sunum temasına ait PowerPoint arka plan stil galerisii](presentation-design_8.png)

Bir arka plan stilini kullanmadan önce, saklanan koleksiyonu ve mevcut [Background.getStyleIndex](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/background/) değerini inceleyin. `0` değeri temalı bir doldurma olmadığını, pozitif değerler tema arka plan-stil referanslarını gösterir. Bu, Java koleksiyonundaki `get_Item(0)` ifadesinin ilk saklanan öğeyi temsil ettiği indeksle aynı değildir. Her sunumun aynı sayıda arka plan doldurma stiline sahip olduğunu varsaymayın.

Aşağıdaki örnek, mevcut arka plan doldurma sayısını raporlar, ilk mastera temalı bir arka plan referansı atar ve sunumu kaydeder:

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

Görünür sonuç, master tarafından başvurulan tema girişine ve düzen ya da slayt düzeyindeki olası arka plan geçersiz kılmalarına bağlıdır. Sadece master arka planını değiştirirseniz, kendi arka planını kullanan slayt etkilenmez. Kalıtım uygulandıktan sonraki nihai arka planı öğrenmek için [Background.getEffective](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/background/) kullanın.

{{% alert color="warning" title="Uyarı" %}}
Stil indeksini sıfır tabanlı bir koleksiyon indeksi gibi işlemeyin. Ayrıca bir dosyadan stil numarasını sabit kodlayıp başka bir dosyada aynı görünüme sahip olacağını varsaymayın; tema stil tanımları sunuma özgüdür.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Doğrudan arka plan biçimlendirme ve arka plan kalıtımı için [Presentation Background](/slides/tr/androidjava/presentation-background/) sayfasına bakın.
{{% /alert %}}

## **Tema Efektlerini Güncelleme**

Bir tema format şeması, ayrı doldurma, çizgi ve efekt stil koleksiyonlarını [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iformatscheme/) ve [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iformatscheme/) aracılığıyla ortaya koyar. Tipik Office temaları, görsel olarak ince, orta ve yoğun formatlamayı temsil eden üç ana stil girişi içerir, ancak kod sabit bir sayıyı varsaymak yerine her koleksiyonu incelemelidir.

![Aynı şekle uygulanan ince, orta ve yoğun tema efektleri](presentation-design_10.png)

Java’da bu koleksiyonlara eriştiğinizde, koleksiyon indeksi sıfır tabanlıdır: `get_Item(0)` ilk saklanan stil, `get_Item(2)` üçüncüdür. Bir şeklin stil‑referans indeksleri ayrı bir kavramdır ve [IShapeStyle](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapestyle/) aracılığıyla ortaya konur. Bir tema stilini değiştirmek, o temayı başvuran şekilleri etkiler; doğrudan biçimlendirilmiş şekiller değişmeden kalabilir.

Aşağıdaki örnek, gerekli stil girişlerinin mevcut olduğunu doğrular, ilk çizgi stilini değiştirir, üçüncü doldurma stilini değiştirir, üçüncü efekt stilinde dış gölgeyi aktif eder ve sonucu kaydeder:

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

Bu slotları başvuran şekillerde, ilk tema çizgi stili kırmızı, üçüncü tema doldurma stili katı orman yeşili ve üçüncü efekt stili 10 puan mesafeli bir dış gölge kazanır. Tam görsel sonuç, her şeklin hangi stil slotlarını başvurduğuna ve doğrudan biçimlemenin temayı geçersiz kılıp kılmadığına bağlıdır.

![Çizgi, doldurma ve gölge ayarları değiştirildikten sonraki tema efekt stilleri](presentation-design_11.png)

## **Geçerli Tema Değerlerini Okuma**

Ham tema nesneleri belirli bir düzeyde tanımlananları gösterir. Geçerli değerler, kalıtım ve yerel geçersiz kılmalar çözüldükten sonra bir slayt veya şeklin gerçekte ne kullandığını gösterir. Bir slayt için [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/baseoverridethememanager/) çağırın. Bir arka plan için [Background.getEffective](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/background/), bir doldurma için ise [FillFormat.getEffective](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fillformat/) kullanın.

Aşağıdaki örnek, bir slayttan geçerli temayı, arka planı ve ilk şekil doldurmasını okur:

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

Raporlama, doğrulama ve karşılaştırma için geçerli verileri kullanın. Yalnızca [Presentation.getMasterTheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) incelerseniz, bir master, düzen, slayt veya şekil geçersiz kılmasının nihai görünümü değiştirdiğini kaçırabilirsiniz.

## **SSS**

**Bir slayta masterı değiştirmeden tema uygulayabilir miyim?**

Evet. Slaytın [SlideThemeManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slidethememanager/) kullanın ve geçersiz kılma temasını başlatın. Değişiklik yalnızca o slayta lokal olarak uygulanır; diğer slaytlar mevcut temalarını miras almaya devam eder.

**Bir temayı bir sunumdan diğerine taşırken en güvenli yol nedir?**

Slaytı taşırken ve kaynak görünümünü korurken, kaynak masterı hedefte [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterslidecollection/) ile klonlayın ve ardından slaytı o master ile birlikte [ISlideCollection.addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidecollection/) kullanarak klonlayın. Bu, masterı, düzenleri ve temayı birlikte tutar.

**Kalıtım ve geçersiz kılmalardan sonra geçerli değerleri nasıl görebilirim?**

Bir slayt veya düzen teması için [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/baseoverridethememanager/) ve format nesneleri için ilgili geçerli‑veri metodlarını ([Background.getEffective](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/background/) ve [FillFormat.getEffective](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fillformat/)) kullanın. Bu API’ler, kalıtım ve geçersiz kılmalar uygulandıktan sonraki çözümlenmiş değerleri döndürür.