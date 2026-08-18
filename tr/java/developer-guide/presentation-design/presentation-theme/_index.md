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
- temayı ayarla
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da tutarlı kurumsal kimlikle PowerPoint dosyaları oluşturmak, özelleştirmek ve dönüştürmek için ana sunum temaları."
---
## **Giriş**

Bir sunum teması, renkler, yazı tipleri, arka plan stilleri, doldurulmalar, çizgiler ve efektlerden oluşan koordineli bir set tanımlar. Tema‑bilgili nesneler, her görsel özelliği sabit bir değer olarak saklamak yerine bu ortak tanımlara başvurur, böylece bir tema değişikliği birçok nesneyi bir anda güncelleyebilir.

Aspose.Slides içinde, sunum‑seviyesindeki tema [Presentation.getMasterTheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) aracılığıyla kullanılabilir. Bir sunum ayrıca daha düşük seviyelerde tema geçersiz kılmalarını içerebilir. Bir master, temayı [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/masterthememanager/) ile geçersiz kılabilir, bir düzen veya bireysel bir slayt ise devralınan temayı [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/baseoverridethememanager/) ile geçersiz kılabilir. Pratikte, bir slayt için etkili tema şu miras zinciri üzerinden çözülür: sunum teması, master geçersiz kılma, düzen geçersiz kılma ve slayt geçersiz kılma.

![Tema bileşenleri: renkler, yazı tipleri, arka plan stilleri ve efektler](theme-constituents.png)

Aşağıdaki bölümler en yaygın tema iş akışlarını gösterir: bir temayı inceleme, renk ve yazı tiplerini değiştirme, bir temayı kopyalama veya uygulama, arka plan ve efekt stillerini güncelleme ve miras ve geçersiz kılmalar çözülerek elde edilen etkili değerleri okuma.

## **Temayı İncele**

[MasterTheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/mastertheme/) nesnesi, temanın renk şemasını, yazı tipi şemasını ve biçim şemasını sırasıyla [MasterTheme.getColorScheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/mastertheme/) ve [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/mastertheme/) aracılığıyla açığa çıkarır. Bu koleksiyonları değiştirmeden önce incelemek, özellikle bir sunum dış bir kaynaktan geldiğinde stil girişlerinin sayısı ve içeriği değişebileceği için yararlıdır.

Aşağıdaki örnek ana tema özelliklerini okur ve temada kaç adet arka plan, dolgu, çizgi ve efekt stilinin saklandığını raporlar:

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

Bir dosya birden çok master kullanıyorsa, her slaytın aynı etkili temaya sahip olduğunu varsamamalısınız. Slayt ile ilişkili masterı inceleyin ve düzen veya slayt geçersiz kılmaları mevcut olduğunda bu makalenin ilerleyen kısmında gösterilen etkili‑tema iş akışını kullanın.

## **Tema Renklerini Değiştir**

Tema‑bilgili dolgu, çizgi ve metinler, [SchemeColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/schemecolor/) enumarasyonundan mantıksal bir renge başvurabilir. [IColorScheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icolorscheme/) içindeki ilgili girdiyi değiştirdiğinizde, hala bu tema rengini başvuran tüm nesneler yeni değere göre çözülür. Doğrudan bir RGB rengi kullanan nesneler tema‑rengi güncellemesinden etkilenmez.

Aşağıdaki uçtan‑uza örnek, `Accent4` kullanan bir şekil oluşturur, temanın `Accent4` rengini kırmızıya değiştirir, sunumu kaydeder, tekrar açar ve etkili dolgu rengini yazdırır:

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

Dikdörtgen `Accent4` ile bağlantılı kalmaya devam ettiğinden, tema değiştirildiğinde görünen rengi kırmızı olur. Şeklin üzerindeki şema rengini doğrudan bir renkle değiştirirseniz, sonraki `Accent4` değişiklikleri bu dolguyu etkilemez.

### **Ek Paletten Renk Kullanma**

PowerPoint, bir tema renginden daha açık ve daha koyu varyantlar türetmek için renk dönüşümleri uygular. Aspose.Slides bu dönüşümleri [ColorTransformOperation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/colortransformoperation/) enumarasyonu aracılığıyla sunar.

![Ana tema renkleri ve ek paletten oluşturulan daha açık ve daha koyu renkler](additional-palette-colors.png)

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

Bu varyantlar tema rengine dayanır. `Accent4` daha sonra değişirse, dönüştürülmüş renkler yeni `Accent4` değerinden yeniden hesaplanır.

### **`SchemeColor` Değerlerini `IColorScheme` Yuvalarına Haritalama**

[SchemeColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/schemecolor/) enumarasyonu `Text1`, `Background1`, `Text2` ve `Background2` kullanırken, [IColorScheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icolorscheme/) aynı tema yuvalarını `Dark1`, `Light1`, `Dark2` ve `Light2` olarak sunar. Haritalama sabittir:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Bunlar aynı tema yuvalarının alternatif adlarıdır; bir formdan diğerine dinamik olarak dönüştürülen değerler değildir.

## **Tema Yazı Tiplerini Değiştir**

Bir tema yazı tipi şeması, başlıklar için bir ana (major) yazı tipi seti ve gövde metni için bir yan (minor) yazı tipi seti içerir. [IFontScheme.getMajor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontscheme/) ve [IFontScheme.getMinor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontscheme/) yöntemleri bu setleri açığa çıkarır.

PowerPoint‑uyumlu tema yazı tipi tanımlayıcıları metin biçimlendirmede kullanılabilir:

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

Başlık ana yazı tipini, gövde metni ise yan yazı tipini izler. Açıkça bir yazı tipi adı belirtilen metin, tema yazı tipi şeması değiştiğinde otomatik olarak değişmez.

{{% alert color="info" title="Tip" %}}Sunum yazı tipleri hakkında daha fazla bilgi için [PowerPoint Fonts](/slides/tr/java/powerpoint-fonts/) sayfasına bakın.{{% /alert %}}

## **Bir Temayı Kopyala veya Uygula**

İki yaygın iş akışı vardır ve farklı problemleri çözer.

### **Kaynak Temayı Slayt Taşırken Koruma**

Bir slaytı başka bir sunuma taşımak ve özgün tasarımını korumak istiyorsanız, kaynak masterı [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterslidecollection/) ile hedef sunuma klonlayın, ardından slaytı [ISlideCollection.addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidecollection/) ve klonlanmış master ile klonlayın. Bu, masterı, düzenlerini ve ilişkili temayı birlikte taşır.

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

Bu iş akışı, kaynak slaytın hedefte aynı görünmesi gerektiğinde tercih edilir. İçeriği bağımsız bir hedef master üzerine klonlamak tema‑sürücü renkleri, yazı tiplerini, arka planları ve efektleri değiştirebilir.

### **Mevcut Bir Slayta Tema Değerlerini Uygula**

Hedef slayt mevcut master ve düzeninde kalmalıysa, kaynak temadan bir slayt‑seviyesi geçersiz kılma başlatın. [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/tr/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/tr/java/com.aspose.slides/overridetheme/) ve [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/tr/java/com.aspose.slides/overridetheme/) yöntemleri üç ana tema bileşenini geçersiz kılamaya kopyalar.

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

Bu, diğer slaytların devraldığı temayı etkilemeden sadece o slaytın kullandığı temayı değiştirir. Yerel geçersiz kılmayı kaldırıp devralınan değerlere dönmek için [OverrideTheme.clear](https://reference.aspose.com/slides/tr/java/com.aspose.slides/overridetheme/) çağırın.

### **Bir Düzen İçin Tema Geçersiz Kılma Uygula**

Düzen‑seviyesi bir geçersiz kılma, o düzeni kullanan slaytlara uygulanır; belirli bir slayt kendi geçersiz kılamasını içermiyorsa. Aynı başlatma yöntemleri [LayoutSlideThemeManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/layoutslidethememanager/) üzerinden kullanılabilir:

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

Birçok düzen ve slayt aynı temel tasarımı paylaşmalıysa master veya sunum‑seviyesi temayı, bir düzen ailesi farklı stil gerektiriyorsa düzen geçersiz kılmasını ve yalnızca gerçek istisnalar için slayt geçersiz kılmasını kullanın. Aşırı slayt‑seviyesi geçersiz kılmalar, sonraki global tema değişikliklerini tahmin etmeyi zorlaştırır.

## **Tema Arka Plan Stilini Güncelle**

Temanın arka plan dolgu stilleri [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iformatscheme/) içinde saklanır. PowerPoint, UI’da temalarla dolgu, tema renkleri ve diğer stil referanslarını birleştirerek bu koleksiyonda fiziksel olarak tanımlı doldurma sayısından daha fazla arka plan seçeneği sunabilir.

![Sunum temasına ait PowerPoint arka plan stil galerisi](presentation-design_8.png)

Bir arka plan stilini kullanmadan önce saklanan koleksiyonu ve mevcut [Background.getStyleIndex](https://reference.aspose.com/slides/tr/java/com.aspose.slides/background/) değerini inceleyin. `0` stil indeksi temalı bir dolgu olmadığını; pozitif değerler tema arka plan‑stil referansları olduğunu gösterir. Bu, Java koleksiyonuna doğrudan indeksleme yaparken (`get_Item(0)` ilk saklı öğe demektir) farklı bir kavramdır. Her sunumun aynı sayıda arka plan dolgu stiline sahip olduğunu varsaymayın.

Aşağıdaki örnek mevcut arka plan dolgu sayısını raporlar, ilk mastera temalı bir arka plan referansı atar ve sunumu kaydeder:

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

Görünür sonuç, masterın referans verdiği tema girdisine ve düzen ya da slayt seviyesindeki olası arka plan geçersiz kılamalarına bağlıdır. Sadece master arka planını değiştirirseniz, kendi arka planını kullanan bir slayt etkilenmeyebilir. Miras uygulandıktan sonraki son arka planı öğrenmek için [Background.getEffective](https://reference.aspose.com/slides/tr/java/com.aspose.slides/background/) kullanın.

{{% alert color="warning" title="Uyarı" %}}Stil indeksini sıfır‑tabanlı bir koleksiyon indeksi olarak yorumlamayın. Ayrıca bir dosyadan stil numarasını sabit kodlamaktan ve başka bir dosyada aynı görünüme sahip olacağını varsayımladan kaçının; tema stil tanımları sunuma özgüdür.{{% /alert %}}

{{% alert color="info" title="Tip" %}}Doğrudan arka plan biçimlendirmesi ve arka plan mirası hakkında bilgi için [Presentation Background](/slides/tr/java/presentation-background/) sayfasına bakın.{{% /alert %}}

## **Tema Efektlerini Güncelle**

Bir tema biçim şeması, ayrı dolgu, çizgi ve efekt stil koleksiyonlarını [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iformatscheme/) ve [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iformatscheme/) aracılığıyla açığa çıkarır. Tipik Office temaları, görsel olarak ince, orta ve yoğun biçimlendirmeye karşılık gelen üç ana stil girdisi içerir; ancak kod, sabit bir sayıya dayanmak yerine her koleksiyonu incelemelidir.

![Aynı şekle uygulanan ince, orta ve yoğun tema efektleri](presentation-design_10.png)

Java’da bu koleksiyonlara eriştiğinizde koleksiyon indeksi sıfır‑tabanlıdır: `get_Item(0)` ilk saklı stildir, `get_Item(2)` üçüncüsüdür. Bir şeklin stil‑referans indeksleri ayrı bir kavramdır ve [IShapeStyle](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapestyle/) aracılığıyla açığa çıkar. Bir tema stilini değiştirmek, o temayı başvuran şekilleri etkiler; doğrudan biçimlendirilmiş şekiller değişmeden kalabilir.

Aşağıdaki örnek gerekli stil girdilerinin mevcut olduğunu doğrular, ilk çizgi stilini değiştirir, üçüncü dolgu stilini değiştirir, üçüncü efekt stilinde dış gölgeyi 10 puan uzaklıkta etkinleştirir ve sonucu kaydeder:

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

Bu yuvalara başvuran şekiller için ilk tema çizgi stili kırmızı, üçüncü tema dolgu stili katı orman yeşili ve üçüncü efekt stili dış gölgeye 10 puan uzaklıkla sahip olur. Kesin görsel sonuç hâlâ hangi stil yuvalarının her şekil tarafından başvurulduğuna ve doğrudan biçimlendirmenin temayı geçersiz kılıp kılmadığına bağlıdır.

![Tema efekt stilleri, çizgi, dolgu ve gölge ayarları değiştirildikten sonraki hali](presentation-design_11.png)

## **Etkili Tema Değerlerini Oku**

Ham tema nesneleri belirli bir seviyede tanımlananları gösterir. Etkili değerler, miras ve yerel geçersiz kılmalar çözüldükten sonra bir slayt veya şeklin gerçekte ne kullandığını söyler. Bir slayt için [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/tr/java/com.aspose.slides/baseoverridethememanager/) çağırın. Bir arka plan için [Background.getEffective](https://reference.aspose.com/slides/tr/java/com.aspose.slides/background/), bir dolgu için ise [FillFormat.getEffective](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fillformat/) kullanın.

Aşağıdaki örnek bir slayttan etkili temayı, arka planı ve ilk şekil dolgusunu okur:

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

Rendring teşhisleri, doğrulama ve karşılaştırmalar için etkili verileri kullanın. Yalnızca [Presentation.getMasterTheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) incelerseniz, master, düzen, slayt veya şekil geçersiz kılmalarının final görünümünü değiştirdiğini gözden kaçırabilirsiniz.

## **SSS**

**Bir slayda masterı değiştirmeden tema uygulayabilir miyim?**

Evet. Slaytın [SlideThemeManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slidethememanager/) kullanın ve geçersiz kılma temasını başlatın. Değişiklik sadece o slayta yerel kalır; diğer slaytlar mevcut temalarını miras etmeye devam eder.

**Bir temayı bir sunumdan diğerine taşımanın en güvenli yolu nedir?**

Slaytı taşırken ve kaynak görünümünü korurken, kaynak masterı hedefe klonlayın ve slaytı o master ile birlikte [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterslidecollection/) ve [ISlideCollection.addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidecollection/) kullanarak klonlayın. Bu, master, düzenler ve temayı birlikte tutar.

**Miras ve geçersiz kılmalardan sonra etkili değerleri nasıl görebilirim?**

Bir slayt veya düzen teması için [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/tr/java/com.aspose.slides/baseoverridethememanager/) ve [Background.getEffective](https://reference.aspose.com/slides/tr/java/com.aspose.slides/background/) ile [FillFormat.getEffective](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fillformat/) gibi ilgili etkili‑veri yöntemlerini kullanın. Bu API’ler miras ve geçersiz kılmalar uygulandıktan sonra çözülmüş değerleri döndürür.