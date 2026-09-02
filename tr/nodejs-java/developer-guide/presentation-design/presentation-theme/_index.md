---
title: JavaScript'te Sunum Temalarını Yönetme
linktitle: Sunum Teması
type: docs
weight: 10
url: /tr/nodejs-java/presentation-theme/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile JavaScript'te ana sunum temalarını yöneterek, PowerPoint dosyalarını tutarlı bir marka ile oluşturun, özelleştirin ve dönüştürün."
---
## **Giriş**

Bir sunum teması, koordineli bir renk, yazı tipi, arka plan stili, dolgu, çizgi ve efekt kümesi tanımlar. Tema farkında nesneler, her görsel özelliği sabit bir değer olarak depolamak yerine bu ortak tanımlara başvurur, bu sayede bir tema değişikliği bir kerede birçok nesneyi güncelleyebilir.

Aspose.Slides içinde, sunum düzeyindeki tema, [Presentation.getMasterTheme](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/getmastertheme/) aracılığıyla kullanılabilir. Bir sunum ayrıca alt seviyelerde tema geçersiz kılmalarını içerebilir. Bir master, [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterthememanager/) ile sunum temasını geçersiz kılabilir, bir düzen veya bireysel slayt ise [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseoverridethememanager/) ile kalıtılan temasını geçersiz kılabilir. Pratikte, bir slaydın etkili teması şu kalıtım zinciri üzerinden çözülür: sunum teması, master geçersiz kılma, düzen geçersiz kılma ve slayd geçersiz kılma.

![Tema bileşenleri: renkler, yazı tipleri, arka plan stilleri ve efektler](theme-constituents.png)

Aşağıdaki bölümler en yaygın tema iş akışlarını gösterir: bir temayı inceleme, renk ve yazı tiplerini değiştirme, bir temayı kopyalama veya uygulama, arka plan ve efekt stillerini güncelleme ve kalıtım ve geçersiz kılmalar çözüldükten sonra etkili değerleri okuma.

## **Bir Temayı İnceleme**

[MasterTheme](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mastertheme/) nesnesi, temanın renk şemasını, yazı tipi şemasını ve format şemasını sırasıyla [MasterTheme.getColorScheme](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mastertheme/) ve [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mastertheme/) aracılığıyla ortaya çıkar. Değiştirmeden önce bu koleksiyonları incelemek, bir sunum harici bir kaynaktan geldiğinde stil girişlerinin sayısı ve içeriği değişebileceği için özellikle yararlıdır.

Aşağıdaki örnek ana tema özelliklerini okur ve temada kaç adet arka plan, dolgu, çizgi ve efekt stilinin depolandığını raporlar:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const theme = presentation.getMasterTheme();
    console.log("Theme name: " + theme.getName());
    console.log("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    console.log("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    console.log("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    console.log("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    console.log("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

Bir dosya birden çok master kullanıyorsa, her slaydın aynı etkili temaya sahip olduğunu varsaymayın. Slayt ile ilişkili masterı inceleyin ve düzen veya slayt geçersiz kılmaları mevcut olduğunda bu makalenin ilerleyen bölümünde gösterilen etkili tema iş akışını kullanın.

## **Tema Renklerini Değiştirme**

Tema farkında dolgu, çizgi ve metin, [SchemeColor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/schemecolor/) enum'undan mantıksal bir renge başvurabilir. [ColorScheme](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/colorscheme/) içindeki ilgili girişi değiştirdiğinizde, hâlâ o tema rengini referanslayan tüm nesneler yeni değere göre çözülür. Doğrudan RGB rengi kullanan nesneler tema rengi güncellemesinden etkilenmez.

Aşağıdaki uçtan uca örnek `Accent4` kullanan bir şekil oluşturur, temanın `Accent4` rengini kırmızıya değiştirir, sunumu kaydeder, yeniden açar ve etkili dolgu rengini yazdırır:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("theme-color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new aspose.slides.Presentation("theme-color.pptx");
try {
    const savedSlide = savedPresentation.getSlides().get_Item(0);
    const savedShape = savedSlide.getShapes().get_Item(0);
    const effectiveFill = savedShape.getFillFormat().getEffective();
    console.log("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

Dikdörtgen `Accent4`e bağlı kalmaya devam ettiğinden, tema değiştirildiğinde görünen rengi kırmızı olur. Şekildeki şema rengini doğrudan bir renkle değiştirirseniz, sonraki `Accent4` değişiklikleri bu doldurmayı etkilemez.

### **Ek Paletten Renk Kullanma**

PowerPoint, bir tema renginden daha açık ve daha koyu varyantlar türetmek için renk dönüşümleri uygular. Aspose.Slides bu dönüşümleri [ColorTransformOperation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/colortransformoperation/) enum'ı aracılığıyla sunar.

![Ana tema renkleri ve ek paletten üretilen daha açık ve daha koyu renkler](additional-palette-colors.png)

**1** - Ana tema renkleri.

**2** - Ana tema renklerinden üretilen daha açık ve daha koyu varyantlar.

Aşağıdaki örnek `Accent4` temelinde altı dikdörtgen oluşturur, beş tanesine parlaklık dönüşümleri uygular ve sonucu kaydeder:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.2));
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.8));

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.4));
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.6));

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.6));
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.4));

    const shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.75));

    const shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.5));

    presentation.save("theme-color-palette.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bu varyantlar tema rengine dayanır. `Accent4` daha sonra değişirse, dönüştürülmüş renkler yeni `Accent4` değerinden yeniden hesaplanır.

### **`SchemeColor` Değerlerini `ColorScheme` Yuvalarına Eşleme**

[SchemeColor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/schemecolor/) enum'ı `Text1`, `Background1`, `Text2` ve `Background2` kullanırken, [ColorScheme](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/colorscheme/) aynı tema yuvalarını `Dark1`, `Light1`, `Dark2` ve `Light2` olarak sunar. Eşleme sabittir:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Bunlar aynı tema yuvalarının alternatif adlarıdır; bir formdan diğerine dinamik olarak dönüştürülen değerler değildir.

## **Tema Yazı Tiplerini Değiştirme**

Bir tema yazı tipi şeması, başlıklar için bir ana (major) yazı tipi seti ve gövde metni için bir yan (minor) yazı tipi seti içerir. [FontScheme.getMajor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontscheme/) ve [FontScheme.getMinor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontscheme/) metodları bu setleri ortaya çıkarır.

PowerPoint uyumlu tema yazı tipi tanımlayıcıları metin biçimlendirmede kullanılabilir:

* `+mn-lt` - Gövde Yazı Tipi Latin (Minor Latin Font)
* `+mj-lt` - Başlık Yazı Tipi Latin (Major Latin Font)
* `+mn-ea` - Gövde Yazı Tipi Doğu Asya (Minor East Asian Font)
* `+mj-ea` - Başlık Yazı Tipi Doğu Asya (Major East Asian Font)

Aşağıdaki örnek bir başlık oluşturur; bu başlık ana Latin tema yazı tipini, bir gövde satırı ise yan Latin tema yazı tipini kullanır. Ardından tema yazı tiplerini değiştirir ve sonucu kaydeder:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const heading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mj-lt"));

    const body = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
    presentation.save("theme-fonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Başlık ana yazı tipini, gövde metni ise yan yazı tipini izler. Açıkça bir yazı tipi adıyla belirtilmiş metin, tema yazı tipi şeması değiştiğinde otomatik olarak değişmez.

Ana ve yan yazı tipi koleksiyonları ayrıca Kiril, Arapça, Japonca, Gürcüce ve Thaana gibi bireysel yazı sistemleri için yazı tipi eşlemeleri içerebilir. Bu eşlemeleri incelemek, eklemek, değiştirmek veya kaldırmak için [Script-Specific Theme Fonts](/slides/tr/nodejs-java/script-specific-font-mappings/) bölümüne bakın.

{{% alert color="info" title="İpucu" %}}

Sunum yazı tipleri hakkında daha fazla bilgi için [PowerPoint Yazı Tipleri](/slides/tr/nodejs-java/powerpoint-fonts/) sayfasına bakın.

{{% /alert %}}

## **Bir Temayı Kopyalama veya Uygulama**

Aşağıdaki iş akışları farklı tema ile ilgili problemleri çözer.

### **Harici Bir Temayı Bir Mastera Bağlı Slaytlara Uygulama**

Bir PowerPoint tema dosyanız (`.thmx`) varsa ve belirli bir mastera bağlı tüm slaytların stilini değiştirmek istiyorsanız [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterslide/) kullanın. Masterı, [Presentation.getMasters](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) koleksiyonundan seçin; bu koleksiyon [MasterSlideCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterslidecollection/) tarafından temsil edilir ve yöntem çağrısına tema dosyasının yolunu aktarın.

Yöntem şu işlemleri gerçekleştirir:

1. Seçilen mastera dayanarak yeni bir master slayt oluşturur.
1. Harici temayı yeni mastera uygular.
1. Daha önce seçilen mastera bağımlı tüm slaytlara yeni masterı atar.
1. Yeni oluşturulan [MasterSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterslide/) nesnesini döndürür.

Aşağıdaki örnek dış temayı ilk mastera bağımlı slaytlara uygular ve sunumu kaydeder:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const selectedMaster = presentation.getMasters().get_Item(0);
    const themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    console.log("Created master: " + themedMaster.getName());
    presentation.save("presentation-with-external-theme.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Geçersiz, bozuk veya desteklenmeyen bir tema, [PptxReadException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pptxreadexception/) oluşturabilir. Kullanıcı tarafından sağlanan yolları doğrulayın, dosya sistemi erişim hatalarını yönetin ve temayı başarıyla uyguladıktan sonra sunumu kaydedin.

Yalnızca seçilen mastera bağımlı slaytlar yeniden atanır. Diğer masterlarla ilişkili slaytlar mevcut master ve temalarını korur. Tema farkında renkler, yazı tipleri, dolgular, çizgiler, arka planlar ve efektler harici temaya göre çözülür. Doğrudan atanmış renkler, yazı tipleri, dolgular ve diğer açık biçimlendirmeler değişmeden kalabilir. Düzen düzeyindeki ve slayt düzeyindeki geçersiz kılmalar da yeni masterdan kalıtılan değerlerin üzerine geçebilir.

Tema, çalışma zamanında mevcut olmayan yazı tiplerine referans verebilir. Tutarlı render ve dışa aktarma için gerekli yazı tiplerini kurun, [özel yazı tipi kaynakları](/slides/tr/nodejs-java/custom-font/) aracılığıyla temin edin veya [yazı tipi ikamesi](/slides/tr/nodejs-java/font-substitution/) yapılandırın.

Bu doğrudan master‑düzeyi bir iş akışıdır: yöntem bir `.thmx` dosya yolu alır ve slayt‑düzeyi veya düzen‑düzeyi tema geçersiz kılmaları manuel olarak oluşturmayı gerektirmez.

### **Çok‑Masterlı Bir Sunumda Farklı Harici Temalar Uygulama**

İlgili master önceden bilinmiyorsa, onu bir temsilci slayttan [Slide.getLayoutSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/) ve [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutslide/) aracılığıyla elde edin. Her çağrı sunuma yeni bir master eklediği için temaları uygulamadan önce orijinal master referanslarını saklayın.

Aşağıdaki örnek iki bölümden slaytları kullanarak masterlarını bulur ve her grup için farklı bir harici tema uygular:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        console.log("The presentation does not contain the expected representative slides.");
    } else {
        const firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        const secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() === secondGroupMaster.getSlideId()) {
            console.log("The representative slides use the same master.");
        } else {
            const firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            const secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            console.log("First themed master: " + firstThemedMaster.getName());
            console.log("Second themed master: " + secondThemedMaster.getName());
            presentation.save("multi-master-with-external-themes.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

İlk çağrı yalnızca `firstGroupMaster`e bağımlı slaytlara etki eder, ikinci çağrı yalnızca `secondGroupMaster`e bağımlı slaytlara etki eder. Başka bir mastera ait slaytlar yeniden stilize edilmez.

### **Slaytları Taşırken Kaynak Temasını Koruma**

Bir slaytı başka bir sunuma taşımak ve orijinal tasarımını korumak istiyorsanız, [MasterSlideCollection.addClone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterslidecollection/) ile kaynak masterı hedef sunuma klonlayın, ardından [SlideCollection.addClone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidecollection/) ile slaytı ve klonlanmış masterı klonlayın. Böylece master, düzenleri ve ilişkili tema birlikte taşınır.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceSlide = source.getSlides().get_Item(0);
        const clonedMaster = target.getMasters().addClone(sourceSlide.getLayoutSlide().getMasterSlide());
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Bu, kaynak slaytın hedefte aynı görünmesini istediğinizde tercih edilen iş akışıdır. İçeriği alakasız bir hedef mastera klonlamak tema‑türü renkler, yazı tipleri, arka planlar ve efektlerde değişikliklere yol açabilir.

### **Mevcut Bir Slayta Tema Değerlerini Uygulama**

Hedef slayt mevcut master ve düzeninde kalmalıysa, kaynağının temasından bir slayt‑düzeyi geçersiz kılma başlatın. [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/overridetheme/) ve [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/overridetheme/) metodları üç ana tema bileşenini geçersiz kılmaya kopyalar.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Bu, diğer slaytların kalıtım temasını değiştirmeden o slaydın temasını değiştirir. Yerel geçersiz kılmayı kaldırmak ve kalıtılan değerlere dönmek için [OverrideTheme.clear](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/overridetheme/) çağırın.

### **Bir Düzen İçin Tema Geçersiz Kılma Uygulama**

Düzen‑düzeyi bir geçersiz kılma, o düzeni kullanan slaytlara uygulanır; ancak belirli bir slaytın kendi geçersiz kılması varsa bu üstlenir. Aynı başlatma metodları [LayoutSlideThemeManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutslidethememanager/) üzerinden kullanılabilir:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getLayoutSlide().getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-layout.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Birçok düzen ve slayt aynı temel tasarımı paylaşmalıysa master veya sunum‑düzeyi temayı kullanın; bir düzen ailesinin farklı stil gerekmesi durumunda düzen geçersiz kılmasını; sadece gerçek istisnalar için slayt geçersiz kılmasını tercih edin. Aşırı slayt‑düzeyi geçersiz kılmalar, sonraki küresel tema değişikliklerini öngörmeyi zorlaştırır.

## **Tema Arka Plan Stillerini Güncelleme**

Temanın arka plan dolguları, [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/formatscheme/) içinde depolanır. PowerPoint, UI’da temanın dolgu tanımlarını tema renkleri ve diğer stil referanslarıyla birleştirerek, bu koleksiyonda fiziksel olarak mevcut olan dolgu tanımlarından daha fazla arka plan seçeneği sunabilir.

![Sunum temasının arka plan stil galerisinde PowerPoint](presentation-design_8.png)

Bir arka plan stilini kullanmadan önce, depolanan koleksiyonu ve mevcut [Background.getStyleIndex](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/background/) değerini inceleyin. `0` stil indeksi, temalı bir dolgu olmadığını gösterir; pozitif değerler tema arka plan‑stil referanslarıdır. Bu, JavaScript koleksiyonunu doğrudan indekslerken `0`ın ilk öğeyi temsil ettiği durumdan farklıdır. Her sunumun aynı sayıda arka plan dolgu stiline sahip olduğunu varsaymayın.

Aşağıdaki örnek kullanılabilir arka plan dolgu sayısını raporlar, ilk mastera temalı bir arka plan referansı atar ve sunumu kaydeder:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    console.log("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() === 0) {
        throw new Error("The presentation theme does not contain background fill styles.");
    }

    const masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.Themed));
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Görünür sonuç, master tarafından referans verilen tema girdisine ve düzen ya da slayt seviyesindeki herhangi bir arka plan geçersiz kılmasına bağlıdır. Bir slayt kendi arka planını kullanıyorsa, yalnızca master arka planını değiştirmek o slaytı etkilemez. Kalıtım uygulandıktan sonra son arka planı bilmeniz gerektiğinde [Background.getEffective](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/background/) kullanın.

{{% alert color="warning" title="Uyarı" %}}

Stil indeksini sıfır tabanlı bir koleksiyon indeksi olarak değerlendirmeyin. Ayrıca bir dosyadan stil numarasını sabit kodlayıp başka bir dosyada aynı görünüme sahip olacağını varsaymayın; tema stil tanımları sunuma özgüdür.

{{% /alert %}}

{{% alert color="info" title="İpucu" %}}

Doğrudan arka plan biçimlendirme ve arka plan kalıtımı için [Presentation Background](/slides/tr/nodejs-java/presentation-background/) bölümüne bakın.

{{% /alert %}}

## **Tema Efektlerini Güncelleme**

Bir tema format şeması, [FormatScheme.getFillStyles](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/formatscheme/) ve [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/formatscheme/) aracılığıyla sunulan ayrı dolgu, çizgi ve efekt stil koleksiyonlarını içerir. Tipik Office temaları görsel olarak ince, orta ve yoğun biçimlendirmelere karşılık gelen üç temel stil girişi içerir, ancak kod sabit bir sayıyı varsaymak yerine her koleksiyonu denetlemelidir.

![Aynı şekle uygulanan ince, orta ve yoğun tema efektleri](presentation-design_10.png)

JavaScript’te bu koleksiyonlara erişirken koleksiyon indeksi sıfır tabanlıdır: `0` ilk depolanan stil, `2` ise üçüncüsüdür. Bir şeklin stil‑referans indeksleri farklı bir kavramdır ve [ShapeStyle](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapestyle/) aracılığıyla ortaya çıkar. Bir tema stilini değiştirmek, o tema stiline referans veren şekilleri etkiler; doğrudan biçimlendirilmiş şekiller değişmeden kalabilir.

Aşağıdaki örnek gerekli stil girişlerinin mevcut olduğunu doğrular, ilk çizgi stilini, üçüncü dolgu stilini değiştirir, üçüncü efekt stilinde dış gölgeyi etkinleştirir ve sonucu kaydeder:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    const formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new Error("The theme does not contain the style entries required by this example.");
    }

    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    formatScheme.getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 34, 139, 34));
    const effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10);
    presentation.save("theme-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bu yuvalara referans veren şekillerde, ilk tema çizgi stili kırmızı, üçüncü tema dolgu stili katı orman yeşili ve üçüncü efekt stili 10 puan uzaklıkta bir dış gölge alır. Tam görsel sonuç hâlâ her şeklin hangi yuvalara başvurduğuna ve doğrudan biçimlendirme tema stilini geçersiz kılıp kılmadığına bağlıdır.

![Satır, dolgu ve gölge ayarları değiştirildikten sonra tema efekt stilleri](presentation-design_11.png)

## **Etkili Düz Kat Dolgunun Tema Rengi Kullanıp Kullanmadığını Belirleme**

Bir dolgu, nesne üzerinde doğrudan depolanabilir veya paragraf, düzen, master, tema stili veya başka bir biçimlendirme seviyesinden kalıtılabilir. Bu hiyerarşiyi değişmez bir etkili‑dolgu anlık görüntüsüne dönüştürmek için [FillFormat.getEffective](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fillformat/) çağırın. İlk olarak `getFillType` değerini kontrol edin. Yalnızca `FillType.Solid` olduğunda katı‑dolgu özelliklerini okuyun.

Katı bir dolgu için `getSolidFillColor`, kalıtım, tema araması ve renk dönüşümleri uygulandıktan sonraki nihai RGB değerini döndürür. `getSolidFillSchemeColor` yöntemi, örneğin `Text1` veya `Accent6` gibi ilgili mantıksal [SchemeColor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/schemecolor/) yuvasını döndürür. `SchemeColor.NotDefined` değeri, etkili katı dolgunun bir şema rengine dayalı olmadığını gösterir. Tema renkleri veya doğrudan RGB renkleri arasında seçim yapılan bir iş akışında bu değer, doğrudan RGB dolgu olduğunu belirtir.

Yerel [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/colorformat/) değerine yalnızca bakarak bir dolgu sınıflandırmayın. Örneğin bir metin bölümü yerel olarak bir şema rengi tanımlamamış olabilir; bu durumda yerel değer `NotDefined` iken, etkili dolgu bir tema rengine kalıtılmış ve `Text1` ya da `Accent6` olarak çözülmüş olabilir. Öte yandan `getSolidFillSchemeColor`, etkili rengin hangi mantıksal tema yuvasından üretildiğini gösterir, ancak bu yuvanın nesneden, paragraftan, düzenden, masterdan ya da başka bir seviyeden geldiğini söylemez.

Aşağıdaki örnek bir sunumu yükler, şekil dolgularını ve metin‑parça dolgularını denetler, her bir nihai RGB değerini ve ilişkili şema rengini yazdırır ve tema rengi değişikliklerini takip etmeyecek katı dolguları işaretler:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function toHexColor(color) {
    const red = color.getRed().toString(16).padStart(2, "0");
    const green = color.getGreen().toString(16).padStart(2, "0");
    const blue = color.getBlue().toString(16).padStart(2, "0");
    return `#${red}${green}${blue}`.toUpperCase();
}

function auditFill(objectName, localFill) {
    const effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() !== aspose.slides.FillType.Solid) {
        console.log(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    const rgb = effectiveFill.getSolidFillColor();
    const effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    const localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    console.log(objectName + ": RGB = " + toHexColor(rgb));
    console.log(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor === aspose.slides.SchemeColor.NotDefined) {
        console.log(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        console.log(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
}

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        const shapeCount = slide.getShapes().size();
        for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            const shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill(shapeName, shape.getFillFormat());

            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const paragraphCount = shape.getTextFrame().getParagraphs().getCount();
                for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    const portionCount = paragraph.getPortions().getCount();
                    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        const portion = paragraph.getPortions().get_Item(portionIndex);
                        const portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

`NotDefined` dalları, tema rengi yuvalarındaki değişikliklere yanıt vermeyecek katı dolguların denetim listesini sağlar. Bu nesneleri yeni bir marka paleti uygulandığında gözden geçirin. Raporlanan RGB değeri hâlâ mevcut görünümü gösterir, şema değeri ise bu görünümün tema ile bağlantılı olup olmadığını açıklar.

Etkili‑format nesneleri anlık görüntülerdir. Sunum temasını, bir tema geçersiz kılmasını veya herhangi bir kalıtım biçimlendirmesini değiştirdikten sonra `getEffective` yeniden çağırın ve renkleri karşılaştırmadan veya raporlamadan önce yeni bir etkili‑dolgu nesnesi alın.

## **Etkili Tema Değerlerini Okuma**

Ham tema nesneleri, belirli bir seviyede neyin tanımlandığını gösterir. Etkili değerler, bir slayt veya şeklin kalıtım ve yerel geçersiz kılmalar çözüldükten sonra gerçekte neyi kullandığını gösterir. Bir slayt için [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseoverridethememanager/) çağırın. Bir arka plan için [Background.getEffective](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/background/), bir dolgu için ise [FillFormat.getEffective](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fillformat/) kullanın.

Aşağıdaki örnek bir slayttan etkili temayı, arka planı ve ilk şekil dolgusunu okur:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const effectiveTheme = slide.getThemeManager().createThemeEffective();
    const effectiveBackground = slide.getBackground().getEffective();
    console.log("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        const effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        console.log("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() === aspose.slides.FillType.Solid) {
            console.log("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

Etkili verileri render tanısı, doğrulama ve karşılaştırmalar için kullanın. Yalnızca [Presentation.getMasterTheme](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/getmastertheme/) incelerseniz, master, düzen, slayt veya şekil geçersiz kılmalarının final görünümü değiştirdiğini kaçırabilirsiniz.

## **SSS**

**Harici bir tema uygulamak sunumdaki tüm slaytları etkiler mi?**

Hayır. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterslide/) yalnızca seçilen mastera bağımlı slaytları yeniden atar. Diğer masterları kullanan slaytlar mevcut temalarını korur.

**Masterı değiştirmeden tek bir slayta tema uygulayabilir miyim?**

Evet. Slaydın [SlideThemeManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidethememanager/) kullanın ve geçersiz kılma temasını başlatın. Değişiklik sadece o slayda yerel kalır; diğer slaytlar mevcut temalarını miras almaya devam eder.

**Bir temayı bir sunumdan diğerine taşırken en güvenli yol nedir?**

Bir slaytı taşırken ve kaynağın görünümünü korurken, kaynağın masterını hedefe klonlayın ve ardından slaytı bu masterla birlikte [MasterSlideCollection.addClone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterslidecollection/) ve [SlideCollection.addClone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidecollection/) ile klonlayın. Böylece master, düzenler ve tema birlikte taşınır.

**Kalıtım ve geçersiz kılmalardan sonra etkili değerleri nasıl görebilirim?**

Bir slayt veya düzen teması için [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseoverridethememanager/) ve format nesneleri (ör. [Background.getEffective](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/background/) ve [FillFormat.getEffective](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fillformat/)) için ilgili etkili‑veri metodlarını kullanın. Bu API’ler, kalıtım ve geçersiz kılmalar uygulandıktan sonraki çözümlenmiş değerleri döndürür.