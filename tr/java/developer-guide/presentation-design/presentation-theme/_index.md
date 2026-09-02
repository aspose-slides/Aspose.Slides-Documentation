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
- tema değiştir
- tema yönet
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
description: "Tutarlı markalama ile PowerPoint dosyalarını oluşturmak, özelleştirmek ve dönüştürmek için Aspose.Slides for Java'da ana sunum temalarını yönetin."
---
## **Giriş**

Bir sunum teması, renkler, yazı tipleri, arka plan stilleri, doldurmalar, çizgiler ve efektler gibi koordine bir set tanımlar. Tema farkında olan nesneler, her görsel özelliği sabit bir değer olarak depolamak yerine bu ortak tanımlara referans verir, böylece bir tema değişikliği birçok nesneyi bir anda güncelleyebilir.

Aspose.Slides içinde, sunum düzeyindeki tema [Presentation.getMasterTheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) aracılığıyla elde edilebilir. Bir sunum ayrıca daha düşük seviyelerde tema geçersiz kılmalarını içerebilir. Bir master, temayı [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/masterthememanager/) ile geçersiz kılabilir, bir düzen veya tek bir slayt ise kalıtılmış temayı [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/baseoverridethememanager/) ile geçersiz kılabilir. Pratikte, bir slayt için etkili tema bu kalıtım zinciri aracılığıyla çözülür: sunum teması, master geçersiz kılma, düzen geçersiz kılma ve slayt geçersiz kılma.

![Tema bileşenleri: renkler, yazı tipleri, arka plan stilleri ve efektler](theme-constituents.png)

Aşağıdaki bölümler en yaygın tema iş akışlarını gösterir: bir temayı inceleme, renk ve yazı tiplerini değiştirme, bir temayı kopyalama veya uygulama, arka plan ve efekt stillerini güncelleme ve kalıtım ile geçersiz kılmalar çözüldükten sonra etkili değerleri okuma.

## **Temayı İnceleme**

[MasterTheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/mastertheme/) nesnesi, temanın renk şemasını, yazı tipi şemasını ve biçim şemasını sırasıyla [MasterTheme.getColorScheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/mastertheme/) ve [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/mastertheme/) aracılığıyla ortaya koyar. Bu koleksiyonları değiştirmeden önce incelemek, özellikle dış bir kaynaktan gelen bir sunumda stil girdilerinin sayısı ve içeriği değişebileceği için faydalıdır.

Aşağıdaki örnek, ana tema özelliklerini okur ve temada kaç tane arka plan, doldurma, çizgi ve efekt stilinin depolandığını raporlar:

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

Bir dosya birden fazla master kullandıysa, her slaytın aynı etkili temaya sahip olduğunu varsamamalısınız. Slayt ile ilişkili master’ı inceleyin ve düzen ya da slayt geçersiz kılmaları mevcut olduğunda bu makalede daha sonra gösterilen etkili‑tema iş akışını kullanın.

## **Tema Renklerini Değiştirme**

Tema farkında olan doldurmalar, çizgiler ve metinler, [SchemeColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/schemecolor/) enum‘undan mantıksal bir renge referans verebilir. [IColorScheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icolorscheme/) içindeki ilgili girişi değiştirdiğinizde, hâlâ o tema rengini referans eden tüm nesneler yeni değerle çözülür. Doğrudan RGB rengi kullanan nesneler tema rengi güncellemesinden etkilenmez.

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

Dikdörtgen `Accent4`e bağlı kaldığı için, tema değiştirildiğinde görünen rengi kırmızı olur. Şekildeki şema rengini doğrudan bir renkle değiştirirseniz, sonraki `Accent4` değişiklikleri o doldurmayı etkilemez.

### **Ek Paletten Renk Kullanma**

PowerPoint, bir tema renginden daha açık ve daha koyu varyantlar türetmek için renk dönüşümleri uygular. Aspose.Slides bu dönüşümleri [ColorTransformOperation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/colortransformoperation/) enum‘u aracılığıyla sunar.

![Ana tema renkleri ve ek paletten üretilen daha açık ve daha koyu renkler](additional-palette-colors.png)

**1** - Ana tema renkleri.

**2** - Ana tema renklerinden üretilen daha açık ve daha koyu varyantlar.

Aşağıdaki örnek, `Accent4` tabanlı altı dikdörtgen oluşturur, beşine parlaklık dönüşümleri uygular ve sonucu kaydeder:

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

[SchemeColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/schemecolor/) enum‘u `Text1`, `Background1`, `Text2` ve `Background2` değerlerini kullanırken, [IColorScheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icolorscheme/) aynı tema yuvalarını `Dark1`, `Light1`, `Dark2` ve `Light2` olarak sunar. Eşleme sabittir:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Bunlar aynı tema yuvalarının alternatif adlarıdır; bir biçimden diğerine dinamik olarak dönüştürülen değerler değildir.

## **Tema Yazı Tiplerini Değiştirme**

Bir tema yazı tipi şeması, başlıklar için büyük bir yazı tipi kümesi ve gövde metni için küçük bir yazı tipi kümesi içerir. [IFontScheme.getMajor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontscheme/) ve [IFontScheme.getMinor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontscheme/) yöntemleri bu kümeleri ortaya koyar.

PowerPoint uyumlu tema yazı tipi tanımlayıcıları metin biçimlendirmesinde kullanılabilir:

* `+mn-lt` - Gövde Yazı Tipi Latin (Küçük Latin Yazı Tipi)
* `+mj-lt` - Başlık Yazı Tipi Latin (Büyük Latin Yazı Tipi)
* `+mn-ea` - Gövde Yazı Tipi Doğu Asya (Küçük Doğu Asya Yazı Tipi)
* `+mj-ea` - Başlık Yazı Tipi Doğu Asya (Büyük Doğu Asya Yazı Tipi)

Aşağıdaki örnek, büyük Latin tema yazı tipini kullanan bir başlık ve küçük Latin tema yazı tipini kullanan bir gövde satırı oluşturur, ardından tema yazı tiplerini değiştirir ve sonucu kaydeder:

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

Başlık büyük yazı tipini, gövde metni ise küçük yazı tipini izler. Tema tanımlayıcısı yerine açıkça bir yazı tipi adı verilmiş metin, tema yazı tipi şeması değiştiğinde otomatik olarak geçiş yapmaz.

Büyük ve küçük yazı tipi koleksiyonları, Kiril, Arapça, Japonca, Gürcüce ve Thaana gibi bireysel yazı sistemleri için yazı tipi eşlemeleri de içerebilir. Bu eşlemeleri incelemek, eklemek, değiştirmek veya kaldırmak için [Script-Özel Tema Yazı Tipleri](/slides/tr/java/script-specific-font-mappings/) bölümüne bakın.

{{% alert color="info" title="İpucu" %}}
Sunum yazı tipleri hakkında daha fazla bilgi için [PowerPoint Yazı Tipleri](/slides/tr/java/powerpoint-fonts/) sayfasına bakın.
{{% /alert %}}

## **Bir Temayı Kopyalama veya Uygulama**

İki yaygın iş akışı vardır ve farklı sorunları çözerler.

### **Kaynak Temasını Slaytları Taşırken Korumak**

Bir slaytı başka bir sunuma taşımak ve orijinal tasarımını korumak istiyorsanız, kaynak master’ı hedef sunuma [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterslidecollection/) ile klonlayın, ardından slaytı ve klonlanan master’ı [ISlideCollection.addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidecollection/) ile klonlayın. Bu, master’ı, düzenlerini ve ilişkili temayı birlikte taşır.

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

Bu, kaynak slaytın hedefte aynı görünmesini sağlamak istediğinizde tercih edilen iş akışıdır. İçerikleri bağımsız bir hedef master’a klonlamak tema‑türetilen renkleri, yazı tiplerini, arka planları ve efektleri değiştirebilir.

### **Mevcut Bir Slayta Tema Değerlerini Uygulama**

Hedef slayt mevcut master ve düzeni üzerinde kalmalıysa, kaynak temadan bir slayt‑düzeyi geçersiz kılma başlatın. [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/tr/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/tr/java/com.aspose.slides/overridetheme/) ve [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/tr/java/com.aspose.slides/overridetheme/) yöntemleri üç ana tema bileşenini geçersiz kılmaya kopyalar.

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

Bu, diğer slaytların kalıtım temalarını değiştirmeden o slaytın kullandığı temayı değiştirir. Yerel geçersiz kılmayı kaldırıp kalıtım değerlere dönmek için [OverrideTheme.clear](https://reference.aspose.com/slides/tr/java/com.aspose.slides/overridetheme/) metodunu çağırın.

### **Bir Düzeni Tema Geçersiz Kılma ile Uygulama**

Düzen‑düzeyi geçersiz kılma, o düzeni kullanan slaytlara uygulanır; belirli bir slayt kendi geçersiz kılmasını yapmadıkça. Aynı başlatma metodları [LayoutSlideThemeManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/layoutslidethememanager/) aracılığıyla kullanılabilir:

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

Bir master veya sunum‑düzeyi tema, birçok düzen ve slayt aynı temel tasarımı paylaşmalıysa tercih edilir; bir düzen geçersiz kılma, tek bir düzen ailesinin farklı bir stil ihtiyacı olduğu durumlar için uygundur; slayt geçersiz kılma yalnızca gerçek istisnalar için kullanılmalıdır. Aşırı slayt‑düzeyi geçersiz kılmalar, sonraki küresel tema değişikliklerini tahmin etmeyi zorlaştırır.

## **Tema Arka Plan Stillerini Güncelleme**

Temanın arka plan doldurmaları, [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iformatscheme/) içinde depolanır. PowerPoint, UI’da tema doldurmalarını tema renkleri ve diğer stil referanslarıyla birleştirerek, bu koleksiyonda fiziksel olarak tanımlı doldurma sayısından daha fazla arka plan seçeneği sunabilir.

![Bir sunum teması için PowerPoint arka plan stil galerisisi](presentation-design_8.png)

Bir arka plan stilini kullanmadan önce, saklanan koleksiyonu ve geçerli [Background.getStyleIndex](https://reference.aspose.com/slides/tr/java/com.aspose.slides/background/) değerini inceleyin. `0` değeri temalı doldurma olmadığını, pozitif değerler ise tema arka plan‑stil referanslarını gösterir. Bu, Java koleksiyonunu doğrudan indekslemeden (`get_Item(0)` ilk saklanan öğeyi gösterir) farklıdır. Her sunumun aynı sayıda arka plan doldurma stiline sahip olduğunu varsamamalısınız.

Aşağıdaki örnek mevcut arka plan doldurma sayısını raporlar, ilk master’a temalı bir arka plan referansı atar ve sunumu kaydeder:

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

Görünür sonuç, master’ın referans verdiği tema girişine ve düzen ya da slayt düzeyindeki olası arka plan geçersiz kılmalarına bağlıdır. Bir slayt kendi arka planını kullanıyorsa, yalnızca master arka planını değiştirmek o slaytı etkilemeyebilir. Kalıtım uygulandıktan sonra nihai arka planı öğrenmek için [Background.getEffective](https://reference.aspose.com/slides/tr/java/com.aspose.slides/background/) kullanın.

{{% alert color="warning" title="Uyarı" %}}
Stil indeksini sıfır‑tabanlı bir koleksiyon indeksi olarak değerlendirmeyin. Ayrıca bir dosyadan stil numarasını sabit kodlayıp başka bir dosyada aynı görünümü beklemeyin; tema stil tanımlamaları sunuma özgüdür.
{{% /alert %}}

{{% alert color="info" title="İpucu" %}}
Doğrudan arka plan biçimlendirme ve arka plan kalıtımı için [Sunum Arka Planı](/slides/tr/java/presentation-background/) bölümüne bakın.
{{% /alert %}}

## **Tema Efektlerini Güncelleme**

Bir tema biçim şeması, ayrı doldurma, çizgi ve efekt stil koleksiyonlarını [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iformatscheme/) ve [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iformatscheme/) aracılığıyla ortaya koyar. Tipik Office temaları genellikle görsel olarak hafif, orta ve yoğun biçimlendirmeye karşılık gelen üç ana stil girdisi içerir, ancak kod sabit bir sayıyı varsaymak yerine her koleksiyonu incelemelidir.

![Aynı şekle uygulanan hafif, orta ve yoğun tema efektleri](presentation-design_10.png)

Java’da bu koleksiyonlara eriştiğinizde, koleksiyon indeksi sıfır‑tabanlıdır: `get_Item(0)` ilk saklanan stili, `get_Item(2)` ise üçüncüyü gösterir. Bir şeklin stil‑referans indeksleri ayrı bir kavramdır ve [IShapeStyle](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapestyle/) aracılığıyla ortaya konur. Bir tema stilini değiştirmek o temayı referanslayan şekilleri etkiler; doğrudan biçimlendirme kullanan şekiller değişmeden kalabilir.

Aşağıdaki örnek, gerekli stil girdilerinin varlığını kontrol eder, ilk çizgi stilini değiştirir, üçüncü doldurma stilini değiştirir, üçüncü efekt stilinde dış gölgeyi 10 puan mesafeyle etkinleştirir ve sonucu kaydeder:

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

Bu yuvaları referanslayan şekiller için, ilk tema çizgi stili kırmızı, üçüncü tema doldurma stili katı orman yeşili ve üçüncü efekt stili 10 puan uzaklıkta bir dış gölge kazanır. Tam görsel sonuç, her şeklin hangi stil yuvalarını referansladığına ve doğrudan biçimlendirmenin temayı geçersiz kılıp kılmadığına bağlıdır.

![Satır, doldurma ve gölge ayarları değiştirildikten sonra tema efekt stilleri](presentation-design_11.png)

## **Etkili Tema Değerlerini Okuma**

Ham tema nesneleri belirli bir seviyede tanımlı olanı gösterir. Etkili değerler, kalıtım ve yerel geçersiz kılmalar çözüldükten sonra bir slayt veya şeklin gerçekte ne kullandığını gösterir. Bir slayt için [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/tr/java/com.aspose.slides/baseoverridethememanager/) çağırın. Bir arka plan için [Background.getEffective](https://reference.aspose.com/slides/tr/java/com.aspose.slides/background/), bir doldurma için ise [FillFormat.getEffective](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fillformat/) kullanın.

Aşağıdaki örnek, bir slayttan etkili temayı, arka planı ve ilk şekil doldurmasını okur:

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

Render diagnostikleri, doğrulama ve karşılaştırmalar için etkili verileri kullanın. Yalnızca [Presentation.getMasterTheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) incelemek, final görünümü değiştiren bir master, düzen, slayt veya şekil geçersiz kılmasını kaçırmanıza neden olabilir.

## **SSS**

**Bir temayı master’ı değiştirmeden tek bir slayta uygulayabilir miyim?**

Evet. Slaytın [SlideThemeManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slidethememanager/) kullanın ve geçersiz kılma temasını başlatın. Değişiklik yalnızca o slayta uygulanır; diğer slaytlar mevcut temalarını kalıtımsal olarak almaya devam eder.

**Bir temayı bir sunumdan diğerine taşımanın en güvenli yolu nedir?**

Bir slaytı taşırken ve kaynak görünümünü korurken, kaynak master’ı hedefe klonlayın ve ardından slaytı o master ile birlikte [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterslidecollection/) ve [ISlideCollection.addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidecollection/) kullanarak klonlayın. Bu, master, düzenler ve temayı bir arada tutar.

**Kalıtım ve geçersiz kılmalardan sonra etkili değerleri nasıl görebilirim?**

Bir slayt veya düzen teması için [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/tr/java/com.aspose.slides/baseoverridethememanager/) ve [Background.getEffective](https://reference.aspose.com/slides/tr/java/com.aspose.slides/background/) ile [FillFormat.getEffective](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fillformat/) gibi format nesneleri için ilgili etkili‑veri yöntemlerini kullanın. Bu API’ler, kalıtım ve geçersiz kılmalar uygulandıktan sonraki çözümlenmiş değerleri döndürür.