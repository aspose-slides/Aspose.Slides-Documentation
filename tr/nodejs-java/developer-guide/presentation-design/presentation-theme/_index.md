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
- tema değiştir
- tema yönet
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile JavaScript'te ana sunum temalarını oluşturun, özelleştirin ve tutarlı marka kimliğiyle PowerPoint dosyalarını dönüştürün."
---
## **Giriş**

Bir sunum teması, renkler, yazı tipleri, arka plan stilleri, dolgular, çizgiler ve efektlerden oluşan koordineli bir set tanımlar. Tema‑bilinçli nesneler, her görsel özelliği sabit bir değer olarak depolamak yerine bu ortak tanımlara başvurur; böylece bir tema değişikliği, birçok nesneyi bir anda güncelleyebilir.

Aspose.Slides içinde, sunum düzeyindeki tema [Presentation.getMasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmastertheme/) üzerinden elde edilebilir. Bir sunum ayrıca daha düşük seviyelerde tema geçersiz kılmalarını da içerebilir. Bir master, [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterthememanager/) aracılığıyla sunum temasını geçersiz kılabilir, bir yerleşim ya da bireysel slayt ise [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/) aracılığıyla devralınan temayı geçersiz kılabilir. Pratikte, bir slayt için etkili tema, şu kalıtım zinciri üzerinden çözümlenir: sunum teması, master geçersiz kılma, yerleşim geçersiz kılma ve slayt geçersiz kılma.

![Tema bileşenleri: renkler, yazı tipleri, arka plan stilleri ve efektler](theme-constituents.png)

Aşağıdaki bölümler en yaygın tema iş akışlarını gösterir: bir temayı inceleme, renk ve yazı tiplerini değiştirme, bir temayı kopyalama veya uygulama, arka plan ve efekt stillerini güncelleme ve kalıtım ve geçersiz kılmalar çözüldükten sonra etkili değerleri okuma.

## **Bir Temayı İnceleme**

[MasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/) nesnesi, tema’nın renk şemasını, yazı tipi şemasını ve biçim şemasını sırasıyla [MasterTheme.getColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/) ve [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/) aracılığıyla ortaya koyar. Bu koleksiyonları değiştirmeden önce incelemek, bir sunum harici bir kaynaktan geldiğinde özellikle faydalıdır; çünkü stil girişlerinin sayısı ve içeriği değişkenlik gösterebilir.

Aşağıdaki örnek, ana tema özelliklerini okur ve temada kaç tane arka plan, dolgu, çizgi ve efekt stilinin depolandığını raporlar:

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

Bir dosya birden çok master kullanıyorsa, her slaytın aynı etkili temaya sahip olduğunu varsaymayın. Slayt ile ilişkilendirilen master’ı inceleyin ve yerleşim veya slayt geçersiz kılmaları mevcut olduğunda bu makalenin ilerleyen kısmında gösterilen etkili tema iş akışını kullanın.

## **Tema Renklerini Değiştirme**

Tema‑bilinçli dolgular, çizgiler ve metinler, [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/) enum’undan mantıksal bir renge başvurabilir. [ColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorscheme/) içindeki ilgili girişi değiştirdiğinizde, hâlâ o tema rengini referans eden tüm nesneler yeni değere göre çözümlenir. Doğrudan RGB rengi kullanan nesneler bir tema rengi güncellemesiyle değişmez.

Aşağıdaki uçtan uca örnek, `Accent4` kullanan bir şekil oluşturur, temanın `Accent4` rengini kırmızıya değiştirir, sunumu kaydeder, yeniden açar ve etkili dolgu rengini yazdırır:

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

Dikdörtgen `Accent4` ile bağlı kaldığı için tema değiştirildiğinde görünür rengi kırmızı olur. Şekildeki şema rengini doğrudan bir renk ile değiştirirseniz, sonraki `Accent4` değişiklikleri artık o dolguyu etkilemez.

### **Ek Paletten Renk Kullanma**

PowerPoint, bir tema renginden daha açık ve daha koyu varyantlar oluşturmak için renk dönüşümleri uygular. Aspose.Slides bu dönüşümleri [ColorTransformOperation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colortransformoperation/) enum’u aracılığıyla sunar.

![Ana tema renkleri ve ek paletten üretilen daha açık ve daha koyu renkler](additional-palette-colors.png)

**1** - Ana tema renkleri.

**2** - Ana tema renklerinden üretilen daha açık ve daha koyu varyantlar.

Aşağıdaki örnek, `Accent4` temelli altı dikdörtgen oluşturur, beş tanesine ışıklandırma dönüşümleri uygular ve sonucu kaydeder:

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

[SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/) enum’u `Text1`, `Background1`, `Text2` ve `Background2` kullanırken, [ColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorscheme/) aynı tema yuvalarını `Dark1`, `Light1`, `Dark2` ve `Light2` olarak ortaya koyar. Eşleme sabittir:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Bunlar aynı tema yuvalarının alternatif adlarıdır; bir formdan diğerine dinamik olarak dönüştürülen değerler değildir.

## **Tema Yazı Tiplerini Değiştirme**

Bir tema yazı tipi şeması, başlıklar için büyük bir yazı tipi seti ve gövde metni için küçük bir yazı tipi seti içerir. [FontScheme.getMajor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontscheme/) ve [FontScheme.getMinor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontscheme/) metodları bu setleri ortaya koyar.

PowerPoint‑uyumlu tema yazı tipi tanımlayıcıları metin biçimlendirmesinde kullanılabilir:

* `+mn‑lt` - Body Font Latin (Küçük Latin Yazı Tipi)
* `+mj‑lt` - Heading Font Latin (Büyük Latin Yazı Tipi)
* `+mn‑ea` - Body Font East Asian (Küçük Doğu Asya Yazı Tipi)
* `+mj‑ea` - Heading Font East Asian (Büyük Doğu Asya Yazı Tipi)
* `+mn‑cs` - Body Font Complex Script (Küçük Karmaşık Betik Yazı Tipi)
* `+mj‑cs` - Heading Font Complex Script (Büyük Karmaşık Betik Yazı Tipi)

Aşağıdaki örnek, büyük Latin tema yazı tipini kullanan bir başlık ve küçük Latin tema yazı tipini kullanan bir gövde satırı oluşturur. Ardından tema yazı tiplerini değiştirir ve sonucu kaydeder:

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

Başlık büyük yazı tipini, gövde metni ise küçük yazı tipini takip eder. Açık bir yazı tipi adıyla belirtilen metin, tema yazı tipi şeması değiştiğinde otomatik olarak değişmez.

Büyük ve küçük yazı tipi koleksiyonları, Kiril, Arapça, Japonca, Gürcüce ve Thaana gibi bireysel yazı sistemleri için yazı tipi eşlemeleri de içerebilir. Bu eşlemeleri incelemek, eklemek, değiştirmek veya kaldırmak için [Script‑Specific Theme Fonts](/slides/tr/nodejs-java/script-specific-font-mappings/) bölümüne bakın.

{{% alert color="info" title="Tip" %}}
Sunum yazı tipleri hakkında daha fazla bilgi için [PowerPoint Fonts](/slides/tr/nodejs-java/powerpoint-fonts/) sayfasına bakın.
{{% /alert %}}

### **Tema Yazı Tipi Referanslarını Çözümleme**

Metni incelerken, [FontData.getFontName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/) tema referansı olarak `+mn‑lt` gibi bir değer döndürebilir. Bu referansı çözümlemek için ilgili etkili temayı kullanarak [FontData.getFontName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/) çağırın. `+mj` ve `+mn` önekleri büyük ve küçük yazı tipi setlerini, `-lt`, `-ea` ve `-cs` sonekleri ise sırasıyla Latin, Doğu Asya ve Karmaşık Betik yazı tiplerini seçer.

Tema uygulanan nesnedeki etkili temayı elde etmek için [Slide.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/) metodunu kullanın. Normal bir slayttaki metin için, bu metodu slayt üzerinde çağırın; böylece bağlam slaytın devralınan teması ve yerel geçersiz kılmaları içerir. Bir yerleşim ya da master’ı inceliyorsanız, kendi etkili temasını kullanın. İlk master’ın teması her slayta uygulanmış gibi varsaymayın.

Aşağıdaki örnek, küçük Latin yazı tipine açıkça başvuran bir metin bölümü oluşturur. [OverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) aracılığıyla bir slayt yazı tipi şeması başlatır ve büyük ve küçük Latin ailelerini `Arial` ve `Calibri` olarak ayarlar; böylece sonuç bir girdi dosyasına ihtiyaç duymadan tekrarlanabilir.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const theme = slide.getThemeManager().getOverrideTheme();
    theme.initFontSchemeFromInherited();
    theme.getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Arial"));
    theme.getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Calibri"));

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Text using the minor theme font");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    const font = portion.getPortionFormat().getLatinFont();
    const effectiveTheme = slide.createThemeEffective();
    console.log(font.getFontName() + " -> " + font.getFontName(effectiveTheme));

    const explicitFont = new aspose.slides.FontData("Verdana");
    console.log(explicitFont.getFontName() + " -> " + explicitFont.getFontName(effectiveTheme));
} finally {
    presentation.dispose();
}
```

Çıktı `+mn‑lt -> Calibri` ardından `Verdana -> Verdana` şeklindedir. Depolanan referans değişmeden kalır, explicit aile adı olduğu gibi döndürülür. Bölüm `+mj‑lt` kullansaydı, bu temada `Arial` olarak çözülürdü.

Tema referansını çözümlemek, tema tarafından belirlenen yazı tipi ailesini gösterir. Bu, yazı tipi kullanılabilirliğini kontrol etmez veya render sırasında oluşan yazı tipi dosyasını belirlemez. Bu adımlar için [Font Selection Sequence](/slides/tr/nodejs-java/font-selection-sequence/) ve [Font Substitution](/slides/tr/nodejs-java/font-substitution/) bölümlerine bakın.

## **Bir Temayı Kopyalama veya Uygulama**

Aşağıdaki iş akışları farklı tema‑il ilgili problemleri çözer.

### **Harici Bir Temayı Bir Master’a Bağlı Slaytlara Uygulama**

Bir PowerPoint tema dosyanız (`.thmx`) varsa ve belirli bir master’a bağlı tüm slaytların stilini değiştirmek istiyorsanız, [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) metodunu kullanın. [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) koleksiyonundan master’ı seçin; bu koleksiyon [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) ile temsil edilir ve tema dosyası yolunu metoda iletin.

Metod aşağıdaki işlemleri gerçekleştirir:

1. Seçilen master’a dayanarak yeni bir master slayt oluşturur.
1. Harici temayı yeni master’a uygular.
1. Daha önce seçilen master’a bağımlı olan tüm slaytlara yeni master’ı atar.
1. Yeni oluşturulan [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) nesnesini döndürür.

Aşağıdaki örnek, ilk master’a bağlı slaytlara harici bir tema uygular ve sunumu kaydeder:

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

Geçersiz, bozuk ya da desteklenmeyen bir tema, [PptxReadException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxreadexception/) oluşturabilir. Kullanıcıların sağladığı yolları doğrulayın, dosya sistemi erişim hatalarını yönetin ve temayı başarıyla uyguladıktan sonra sunumu kaydedin.

Yalnızca seçilen master’a bağımlı slaytlar yeniden atanır. Diğer master’lara bağlı slaytlar mevcut master ve temalarını korur. Tema‑bilinçli renkler, yazı tipleri, dolgular, çizgiler, arka planlar ve efektler harici temaya göre çözümlenir. Doğrudan atanmış renkler, yazı tipleri, dolgular ve diğer açık biçimlendirmeler değişmemiş olabilir. Yerleşim‑düzeyi ve slayt‑düzeyi geçersiz kılmalar da yeni master’dan devralınan değerlerin üzerine gelebilir.

Tema, çalışma zamanında mevcut olmayan yazı tiplerine başvurabilir. Tutarlı render ve dışa aktarma için gerekli yazı tiplerini kurun, [özelleştirilmiş yazı tipi kaynakları](/slides/tr/nodejs-java/custom-font/) aracılığıyla sağlayın ya da [yazı tipi ikamesi](/slides/tr/nodejs-java/font-substitution/) yapılandırın.

Bu doğrudan master‑düzeyi bir iş akışıdır: metod bir `.thmx` dosyasının yolunu alır ve slayt‑düzeyi veya yerleşim‑düzeyi tema geçersiz kılmaları elle oluşturmayı gerektirmez.

### **Çok‑Masterlı Bir Sunumda Farklı Harici Temalar Uygulama**

İlgili master önceden bilinmiyorsa, [Slide.getLayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/) ve [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/) aracılığıyla temsilî bir slayttan elde edin. Her temayı uygulamadan önce orijinal master referanslarını saklayın; çünkü her çağrı sunumda yeni bir master oluşturur.

Aşağıdaki örnek, iki bölümden gelen slaytların masterlarını bulur ve her grup için farklı bir harici tema uygular:

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

İlk çağrı yalnızca `firstGroupMaster`’a bağımlı slaytları etkiler, ikinci çağrı ise yalnızca `secondGroupMaster`’a bağımlı slaytları etkiler. Diğer master’lara bağlı slaytlar yeniden biçimlendirilmez.

### **Kaynak Temayı Slayt Taşıma Sırasında Korumak**

Bir slaytı başka bir sunuma taşımak ve özgün tasarımını korumak istiyorsanız, kaynak master’ı hedef sunuma [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) ile klonlayın, ardından slaytı klonlu master ile birlikte [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) ile klonlayın. Bu, master’ı, yerleşimlerini ve ilişkili temayı birlikte taşır.

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

Bu, kaynak slaytın hedefte aynı görünmesini istediğinizde tercih edilen iş akışıdır. İçeriği alakasız bir hedef master’a klonlamak, tema‑tabanlı renk, yazı tipi, arka plan ve efektlerin değişmesine yol açabilir.

### **Mevcut Bir Slayta Tema Değerleri Uygulama**

Hedef slayt mevcut master ve yerleşiminde kalmalıysa, kaynak temadan slayt‑düzeyi bir geçersiz kılma başlatın. [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) ve [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) metodları üç ana tema bileşenini geçersiz kılmaya kopyalar.

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

Bu, diğer slaytların devraldığı temayı değiştirmeden, yalnızca o slaytın kullandığı temayı değiştirir. Yerel geçersiz kılmayı kaldırıp devralınan değerlere dönmek için [OverrideTheme.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) metodunu çağırın.

### **Bir Yerleşime Tema Geçersiz Kılma Uygulama**

Yerleşim‑düzeyi bir geçersiz kılma, o yerleşimi kullanan slaytlara uygulanır; ancak belirli bir slayt kendi geçersiz kılmasını içeriyorsa bu üzerine yazılır. Aynı başlatma metodları [LayoutSlideThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslidethememanager/) üzerinden de kullanılabilir:

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

Çok sayıda yerleşim ve slayt aynı temel tasarımı paylaşmalıysa master ya da sunum‑düzeyi tema kullanın; bir yerleşim ailesi farklı bir stillendirme gerektiriyorsa yerleşim geçersiz kılmasını, yalnızca gerçek istisnalar için slayt geçersiz kılmasını tercih edin. Aşırı slayt‑düzeyi geçersiz kılmalar, sonraki global tema değişikliklerini tahmin etmeyi zorlaştırır.


<!-- visual-explanation:presentation-theme:start -->
[![Bir master tema iki yerleşimi besler; bir yerleşim geçersiz kılma, kendi daha yerel geçersiz kılması olmayan slaytlar hariç, slaytlarını etkiler.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*Bir yerleşim geçersiz kılma, o yerleşimi kullanan slaytlara uygulanır; bir slayt kendi geçersiz kılmasını sağlamıyorsa. Tema‑bazlı değerler çözümlenen şemalarını izler; doğrudan biçimlendirilmiş nesneler yerel görünümlerini koruyabilir. Geçersiz kılmaları, tasarım istisnasının kapsamına göre dar tutun.*
<!-- visual-explanation:presentation-theme:end -->

## **Tema Arka Plan Stillerini Güncelleme**

Temanın arka plan dolguları, [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/) içinde depolanır. PowerPoint, UI’da temadan temaya dolgu ve renk kombinasyonlarını birleştirebildiği için bu koleksiyonda fiziksel olarak depolanandan daha fazla arka plan seçeneği sunabilir.

![Sunum temasına ait PowerPoint arka plan stil galerisinin görüntüsü](presentation-design_8.png)

Bir arka plan stilini kullanmadan önce, depolanmış koleksiyonu ve geçerli [Background.getStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/) değerini inceleyin. `0` stil indeksi temalı bir dolgu olmadığını, pozitif değerlerin tema arka plan‑stil referansları olduğunu gösterir. Bu, JavaScript koleksiyonunu doğrudan indekslemeden farklıdır; burada `0` ilk depolanmış öğeyi gösterir. Her sunumun aynı sayıda arka plan dolgu stiline sahip olduğunu varsaymayın.

Aşağıdaki örnek, kullanılabilir arka plan dolgu sayısını raporlar, ilk master’a temalı bir arka plan referansı atar ve sunumu kaydeder:

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

Görünür sonuç, master’ın referans verdiği tema girişi ve yerleşim veya slayt düzeyindeki olası arka plan geçersiz kılmalarına bağlıdır. Bir slayt kendi arka planını kullanıyorsa, yalnızca master arka planını değiştirmek o slaytı etkilemez. Kalıtım uygulandıktan sonra nihai arka planı öğrenmek için [Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/) kullanın.

{{% alert color="warning" title="Uyarı" %}}
Stil indeksini sıfır‑tabanlı bir koleksiyon indeksi gibi değerlendirmeyin. Ayrıca bir dosyadan bir stil numarasını sabit kodlayıp başka bir dosyada aynı görünümü beklemekten kaçının; tema stil tanımları sunuma özeldir.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Doğrudan arka plan biçimlendirmesi ve arka plan kalıtımı için [Presentation Background](/slides/tr/nodejs-java/presentation-background/) bölümüne bakın.
{{% /alert %}}

## **Tema Efektlerini Güncelleme**

Bir tema biçim şeması, ayrı dolgu, çizgi ve efekt stil koleksiyonlarını [FormatScheme.getFillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/) ve [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/) aracılığıyla ortaya koyar. Tipik Office temaları genellikle görsel olarak ince, orta ve yoğun biçimlendirmelere karşılık gelen üç ana stil girişine sahiptir; ancak kod sabit bir sayıyı varsaymak yerine her koleksiyonu incelemelidir.

![Aynı şekle uygulanan ince, orta ve yoğun tema efektleri](presentation-design_10.png)

JavaScript’te bu koleksiyonlara eriştiğinizde, koleksiyon indeksi sıfır‑tabanlıdır: `0` ilk depolanmış stil, `2` üçüncü stildir. Bir şeklin stil‑referans indeksleri ayrı bir konsepttir ve [ShapeStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/) aracılığıyla ortaya konur. Bir tema stilini değiştirmek, o tema stiline başvuran şekilleri etkiler; doğrudan biçimlendirilmiş şekiller değişmeden kalabilir.

Aşağıdaki örnek, gerekli stil girişlerinin mevcut olduğunu kontrol eder, ilk çizgi stilini değiştirir, üçüncü dolgu stilini değiştirir, üçüncü efekt stilinde dış gölgeyi etkinleştirir ve sonucu kaydeder:

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

Bu yuvalara başvuran şekillerde, ilk tema çizgi stili kırmızı, üçüncü tema dolgu stili katı orman yeşili ve üçüncü efekt stili 10 puan mesafede dış gölge kazanır. Tam görsel sonuç, her şeklin hangi stil yuvalarına başvurduğuna ve doğrudan biçimlendirme tema değerlerini geçersiz kıldıysa ona bağlıdır.

![Satır, dolgu ve gölge ayarları değiştirildikten sonra tema efekt stilleri](presentation-design_11.png)

## **Bir Şekil İçin Tema Dolgu ve Çizgi Stillerini Seçme**

Bir şekil, doldurma ve konturunu bağımsız olarak [ShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/setfillstyleindex/) ve [ShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/setlinestyleindex/) metodlarıyla seçebilir. Her iki metod için, `1` indeks, ilgili tema koleksiyonundaki ilk girdiyi (`get_Item(0)`) seçer, `2` ise ikincisini (`get_Item(1)`) seçer.

Aşağıdaki örnek, yeni bir sunumun varsayılan temasında iki dolgu stili (altın ve gökyüzü mavisi) ve iki çizgi stili (6 pt’de koyu mavi ve 12 pt’de koyu kırmızı) ayarlar. Sonucu üç aşamada kaydeder, böylece PowerPoint’te karşılaştırabilirsiniz.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const styles = presentation.getMasterTheme().getFormatScheme();

    const goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    goldFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 215, 0));
    const blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    blueFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 135, 206, 235));

    const thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thinLine.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
    thinLine.setWidth(6);
    const thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thickLine.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 139, 0, 0));
    thickLine.setWidth(12);

    const shapes = presentation.getSlides().get_Item(0).getShapes();
    const left = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 205, 200, 130);
    const right = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 420, 205, 200, 130);
    left.getShapeStyle().setFillStyleIndex(java.newShort(1));
    right.getShapeStyle().setFillStyleIndex(java.newShort(2));
    left.getShapeStyle().setLineStyleIndex(1);
    right.getShapeStyle().setLineStyleIndex(1);
    presentation.save("01-initial.pptx", aspose.slides.SaveFormat.Pptx);

    right.getShapeStyle().setLineStyleIndex(2);
    presentation.save("02-line-changed.pptx", aspose.slides.SaveFormat.Pptx);

    goldFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 46, 139, 87));
    presentation.save("03-theme-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| İlk stiller | Sağ konturu değiştir | İlk tema dolgusunu düzenle |
|:---:|:---:|:---:|
| ![Altın ve gökyüzü mavisi dikdörtgenler, eşleşen ince koyu mavi konturlar](theme-style-initial.png) | ![Gökyüzü mavisi dikdörtgen artık kalın koyu kırmızı bir kontura sahip](theme-style-line-changed.png) | ![Sol dikdörtgen artık yeşil, her iki kontur da değişmemiş](theme-style-fill-changed.png) |

Farklı bir çizgi stili seçmek yalnızca sağ dikdörtgenin konturunu değiştirir. İlk tema dolgusunu düzenlemek, onu kullanan her şekli günceller. Burada yalnızca sol dikdörtgen yeşile döner.

Mevcut bir şekilde, yerel bir dolgu rengi, çizgi rengi veya çizgi kalınlığı, tema stilinin o bölümünü geçersiz kılabilir. Bir stil indeksini değiştirmenin görünür bir etkisi yoksa, şeklin [direct formatting](/slides/tr/nodejs-java/shape-formatting/) kısmını kontrol edin.

## **Etkili Katı Dolgunun Tema Rengi Kullanıp Kullanmadığını Belirleme**

Bir dolgu, doğrudan bir nesne üzerine depolanabilir ya da bir paragraf, yerleşim, master, tema stili ya da başka bir biçimlendirme seviyesinden devralınabilir. [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) çağırarak bu hiyerarşiyi değiştirilemez bir etkili‑dolgu anlık görüntüsüne dönüştürün. İlk olarak `getFillType` değerini kontrol edin. Yalnızca `FillType.Solid` olduğunda katı‑dolgu özelliklerini okuyun.

Katı bir dolgu için, `getSolidFillColor` kalıtım, tema araması ve renk dönüşümleri uygulandıktan sonra elde edilen son RGB değerini döndürür. `getSolidFillSchemeColor` yöntemi ise ilgili mantıksal [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/) yuvasını, örneğin `Text1` ya da `Accent6` gibi, verir. `SchemeColor.NotDefined` değeri, etkili katı dolgunun bir şema rengine dayalı olmadığını gösterir. Tema renkleri ya da doğrudan RGB renkleri kullanılan bir iş akışında, bu değer doğrudan RGB dolgu olduğunu gösterir.

Yerel olarak sadece [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/) değerine bakarak bir dolguyu sınıflandırmayın. Örneğin, bir metin bölümü yerel olarak tanımlı bir şema rengine sahip olmayabilir; bu durumda yerel değeri `NotDefined` olur, fakat etkili dolgu bir tema rengine devralınır ve `Text1` ya da `Accent6` gibi bir şemaya çözülür. Öte yandan, `getSolidFillSchemeColor` hangi mantıksal tema yuvasının etkili rengi ürettiğini söyler, ancak bu yuvanın nesneden, paragraftan, yerleşimden, master’dan ya da başka bir seviyeden geldiğini belirtmez.

Aşağıdaki örnek bir sunumu yükler, şekil dolgularını ve metin‑parça dolgularını denetler, her bir son RGB değerini ve ilişkili şema rengini yazar ve tema rengi değişikliklerini takip etmeyecek katı dolguları işaretler:

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

`NotDefined` dalı, tema rengi yuvalarındaki değişikliklere yanıt vermeyecek katı dolguların denetim listesini sağlar. Sunumun yeni bir marka paletine uyması gerektiğinde bu nesneleri gözden geçirin. Raporlanan RGB değeri hâlâ mevcut görünümü gösterirken, şema değeri bu görünümün tema ile bağlantılı olup olmadığını açıklar.

Etkili‑format nesneleri anlık görüntülerdir. Sunum temasını, bir tema geçersiz kılmasını veya herhangi bir devralınan biçimlendirmeyi değiştirdikten sonra, `getEffective` yeniden çağırılıp yeni bir etkili‑dolgu nesnesi okunmalı, ardından renkler karşılaştırılmalı ya da raporlanmalıdır.

## **Etkili Tema Değerlerini Okuma**

Ham tema nesneleri belirli bir seviyede neyin tanımlandığını gösterir. Etkili değerler, kalıtım ve yerel geçersiz kılmalar çözüldükten sonra bir slayt ya da şeklin gerçekte ne kullandığını söyler. Bir slayt için [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/) metodunu çağırın. Bir arka plan için [Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/), bir dolgu için ise [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) metodlarını kullanın.

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

Render teşhisleri, doğrulama ve karşılaştırmalar için etkili verileri kullanın. Yalnızca [Presentation.getMasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmastertheme/) incelerseniz, master, yerleşim, slayt veya şekil geçersiz kılmalarının final görünümünü kaçırabilirsiniz.

## **SSS**

**Harici bir tema uygulamak sunumdaki her slaytı etkiler mi?**

Hayır. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) yalnızca seçilen master’a bağımlı slaytları yeniden atar. Diğer master’ları kullanan slaytlar mevcut temalarını korur.

**Bir temayı tek bir slayta, master’ı değiştirmeden uygulayabilir miyim?**

Evet. Slaytın [SlideThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidethememanager/) aracılığıyla geçersiz kılma temasını başlatın. Değişiklik yalnızca o slayta yerel kalır; diğer slaytlar mevcut temalarını devralmaya devam eder.

**Bir temayı bir sunumdan diğerine taşımanın en güvenli yolu nedir?**

Bir slaytı taşırken ve kaynak görünümünü korurken, kaynak master’ı hedefe klonlayın ve o master ile birlikte slaytı [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) ve [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) kullanarak klonlayın. Böylece master, yerleşimler ve tema birlikte kalır.

**Kalıtım ve geçersiz kılmalardan sonra etkili değerleri nasıl görebilirim?**

Bir slayt veya yerleşim temasının etkili değerleri için [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/) metodunu, format nesneleri için ise [Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/) ve [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) gibi ilgili etkili‑veri metodlarını kullanın. Bu API’lar, kalıtım ve geçersiz kılmalar uygulandıktan sonra çözümlenen değerleri döndürür.