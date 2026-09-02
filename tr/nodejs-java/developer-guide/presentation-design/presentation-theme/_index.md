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
description: "Aspose.Slides for Node.js ile JavaScript'te master sunum temalarını yöneterek PowerPoint dosyalarını tutarlı marka kimliğiyle oluşturun, özelleştirin ve dönüştürün."
---
## **Giriş**

Bir sunum teması, koordineli bir renk, yazı tipi, arka plan stili, dolgu, çizgi ve efekt seti tanımlar. Tema‑bilinçli nesneler, her görsel özelliği sabit bir değer olarak depolamak yerine bu ortak tanımlara başvurur, bu sayede bir tema değişikliği birden çok nesneyi aynı anda güncelleyebilir.

Aspose.Slides içinde, sunum‑seviyesi tema, [Presentation.getMasterTheme](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/getmastertheme/) üzerinden erişilebilir. Bir sunum ayrıca daha alt seviyelerde tema geçersiz kılmalarına da sahip olabilir. Bir master, tema geçersiz kılmasını [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterthememanager/) ile, bir layout ya da tek bir slayt ise [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseoverridethememanager/) ile gerçekleştirebilir. Pratikte, bir slayt için geçerli tema, şu kalıtım zinciri üzerinden çözülür: sunum teması → master geçersiz kılma → layout geçersiz kılma → slayt geçersiz kılma.

![Tema bileşenleri: renkler, yazı tipleri, arka plan stilleri ve efektler](theme-constituents.png)

Aşağıdaki bölümler, en yaygın tema iş akışlarını gösterir: bir temayı incelemek, renk ve yazı tiplerini değiştirmek, temayı kopyalamak veya uygulamak, arka plan ve efekt stillerini güncellemek ve kalıtım ve geçersiz kılmalar çözüldükten sonra etkili değerleri okumak.

## **Bir Temayı İnceleme**

[MasterTheme](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mastertheme/) nesnesi, tema’nın renk şemasını, yazı tipi şemasını ve format şemasını sırasıyla [MasterTheme.getColorScheme](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mastertheme/) ve [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mastertheme/) aracılığıyla ortaya çıkar. Bu koleksiyonları değiştirmeden önce incelemek, dış bir kaynaktan gelen bir sunumun stil girişlerinin sayısı ve içeriği değişebileceği için özellikle faydalıdır.

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

Bir dosya birden çok master kullanıyorsa, her slaytın aynı etkili temaya sahip olduğunu varsaymayın. Slaytla ilişkili master’ı inceleyin ve layout veya slayt geçersiz kılmaları mevcut olduğunda bu makalede daha sonra gösterilen etkili‑tema iş akışını kullanın.

## **Tema Renklerini Değiştirme**

Tema‑bilinçli dolgular, çizgiler ve metinler, [SchemeColor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/schemecolor/) enum’undan mantıksal bir renge başvurabilir. [ColorScheme](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/colorscheme/) içinde ilgili girdiyi değiştirirseniz, hâlâ o tema rengine başvuran tüm nesneler yeni değere göre çözülür. Doğrudan RGB rengi kullanan nesneler, tema‑rengi güncellemesinden etkilenmez.

Aşağıdaki uçtan‑uca örnek, `Accent4` kullanan bir şekil oluşturur, temadaki `Accent4` rengini kırmızıya değiştirir, sunumu kaydeder, yeniden açar ve etkili dolgu rengini yazdırır:

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

Dikdörtgen hâlâ `Accent4` ile bağlı olduğundan, tema değiştirildiğinde görünür rengi kırmızı olur. Şekilde şema rengini doğrudan bir renk ile değiştirirseniz, sonraki `Accent4` değişiklikleri bu dolguyu etkilemez.

### **Ek Paletten Renk Kullanma**

PowerPoint, bir tema renginden daha açık ve daha koyu varyantlar oluşturmak için renk dönüşümleri uygular. Aspose.Slides bu dönüşümleri [ColorTransformOperation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/colortransformoperation/) enum’u aracılığıyla sunar.

![Ana tema renkleri ve ek paletten üretilen daha açık ve daha koyu renkler](additional-palette-colors.png)

**1** – Ana tema renkleri.

**2** – Ana tema renklerinden üretilen daha açık ve daha koyu varyantlar.

Aşağıdaki örnek, `Accent4` temelinde altı dikdörtgen oluşturur, beş tanesine parlaklık dönüşümleri uygular ve sonucu kaydeder:

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

[SchemeColor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/schemecolor/) enum’u `Text1`, `Background1`, `Text2` ve `Background2` kullanırken, [ColorScheme](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/colorscheme/) aynı tema yuvalarını `Dark1`, `Light1`, `Dark2` ve `Light2` olarak sunar. Eşleme sabittir:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Bunlar aynı tema yuvalarının alternatif adlarıdır; bir formdan diğerine dinamik olarak dönüştürülen değerler değildir.

## **Tema Yazı Tiplerini Değiştirme**

Bir tema yazı tipi şeması, başlıklar için bir ana (major) yazı tipi kümesi ve gövde metni için bir yardımcı (minor) yazı tipi kümesi içerir. [FontScheme.getMajor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontscheme/) ve [FontScheme.getMinor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontscheme/) yöntemleri bu kümeleri ortaya çıkarır.

PowerPoint‑uyumlu tema yazı tipi tanımlayıcıları metin biçimlendirmesinde kullanılabilir:

* `+mn-lt` – Gövde Yazı Tipi Latin (Minor Latin Font)
* `+mj-lt` – Başlık Yazı Tipi Latin (Major Latin Font)
* `+mn-ea` – Gövde Yazı Tipi Doğu Asya (Minor East Asian Font)
* `+mj-ea` – Başlık Yazı Tipi Doğu Asya (Major East Asian Font)

Aşağıdaki örnek, ana Latin tema yazı tipini kullanan bir başlık ve yardımcı Latin tema yazı tipini kullanan bir gövde satırı oluşturur. Ardından tema yazı tiplerini değiştirir ve sonucu kaydeder:

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

Başlık ana yazı tipini, gövde metni ise yardımcı yazı tipini izler. Tema yazı tipi şeması değiştiğinde, açıkça bir yazı tipi adı belirtilen metin otomatik olarak değişmez.

Ana ve yardımcı yazı tipi koleksiyonları, Kiril, Arapça, Japonca, Gürcüce ve Thaana gibi bireysel yazı sistemleri için yazı tipi eşlemeleri de içerebilir. Bu eşlemeleri incelemek, eklemek, değiştirmek veya kaldırmak için [Senaryo‑Özel Tema Yazı Tipleri](/slides/tr/nodejs-java/script-specific-font-mappings/) bölümüne bakın.

{{% alert color="info" title="İpucu" %}}
Daha fazla bilgi için sunum yazı tiplerine bakın: [PowerPoint Yazı Tipleri](/slides/tr/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **Bir Temayı Kopyalama veya Uygulama**

Aşağıdaki iş akışları farklı tema‑ilişkili problemleri çözer.

### **Harici Bir Temayı Bir Master’a Bağlı Slaytlara Uygulama**

Bir PowerPoint tema dosyanız (`.thmx`) varsa ve belirli bir master’a bağlı tüm slaytların stilini yeniden uygulamak istiyorsanız, [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterslide/) kullanın. [Presentation.getMasters](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) koleksiyonundan, [MasterSlideCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterslidecollection/) tarafından temsil edilen master’ı seçin ve tema dosyasının yolunu metoda iletin.

Metod şu işlemleri gerçekleştirir:

1. Seçilen master’a dayalı yeni bir master slayt oluşturur.
1. Harici temayı yeni master’a uygular.
1. Yeni master’ı, daha önce seçilen master’a bağlı olan tüm slaytlara atar.
1. Yeni oluşturulan [MasterSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterslide/) nesnesini döndürür.

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

Geçersiz, bozuk veya desteklenmeyen bir tema, [PptxReadException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pptxreadexception/) oluşturabilir. Kullanıcıların sağladığı yolları doğrulayın, dosya sistemi erişim hatalarını ele alın ve tema başarıyla uygulandıktan sonra sunumu kaydedin.

Yalnızca seçilen master’a bağımlı slaytlar yeniden atanır. Diğer master’larla ilişkili slaytlar mevcut master ve temalarını korur. Tema‑bilinçli renkler, yazı tipleri, dolgular, çizgiler, arka planlar ve efektler harici temaya göre çözülür. Doğrudan atanmış renkler, yazı tipleri, dolgular ve diğer açık biçimlendirmeler değişmeden kalabilir. Layout‑seviyesi ve slayt‑seviyesi geçersiz kılmalar da yeni master’dan kalıtılan değerlerin üzerine yazabilir.

Tema, çalışma zamanında bulunmayan yazı tiplerine başvurabilir. Tutarlı render ve dışa aktarma için gerekli yazı tiplerini kurun, [özel yazı tipi kaynakları](/slides/tr/nodejs-java/custom-font/) aracılığıyla sağlayın veya [yazı tipi ikamesi](/slides/tr/nodejs-java/font-substitution/) yapılandırın.

Bu, doğrudan master‑seviyesi bir iş akışıdır: metod bir `.thmx` dosya yolunu kabul eder ve slayt‑seviyesi veya layout‑seviyesi tema geçersiz kılmaları manuel olarak oluşturmayı gerektirmez.

### **Çok‑Masterlı Bir Sunumda Farklı Harici Temalar Uygulama**

İlgili master önceden bilinmiyorsa, onu temsilci bir slayttan [Slide.getLayoutSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/) ve [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutslide/) ile elde edin. Her tema uygulamasının sunumda yeni bir master oluşturduğunu aklınızda tutarak, orijinal master referanslarını tema uygulamadan önce saklayın.

Aşağıdaki örnek, iki bölümden slaytları kullanarak master’larını bulur ve her gruba farklı bir harici tema uygular:

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

İlk çağrı yalnızca `firstGroupMaster`a bağımlı slaytları etkiler, ikinci çağrı ise yalnızca `secondGroupMaster`a bağımlı slaytları etkiler. Diğer master’a bağlı slaytlar yeniden stil almaz.

### **Slaytları Taşıdığınızda Kaynak Temayı Korumak**

Bir slaytı başka bir sunuma taşırken orijinal tasarımını korumak istiyorsanız, kaynak master’ı hedef sunuma [MasterSlideCollection.addClone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterslidecollection/) ile klonlayın, ardından slaytı klonlanmış master ile birlikte [SlideCollection.addClone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidecollection/) ile klonlayın. Bu, master’ı, layout’larını ve ilişkili temayı birlikte taşır.

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

Bu, kaynak slaytın hedefte aynı görünmesini sağlayan tercih edilen iş akışıdır. İçeriği bağımsız bir hedef master’a klonlamak, tema‑tabanlı renk, yazı tipi, arka plan ve efektlerin değişmesine neden olabilir.

### **Mevcut Bir Slayta Tema Değerleri Uygulama**

Hedef slayt mevcut master ve layout’da kalmalıysa, kaynak temadan bir slayt‑seviyesi geçersiz kılma başlatın. [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/overridetheme/) ve [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/overridetheme/) yöntemleri, üç ana tema bileşenini geçersiz kılmaya kopyalar.

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

Bu, diğer slaytların kalıtım aldığı temayı değiştirmeden sadece bu slaytın temasını değiştirir. Yerel geçersiz kılmayı kaldırmak ve kalıtım değerlerine dönmek için [OverrideTheme.clear](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/overridetheme/) çağırın.

### **Bir Layout’a Tema Geçersiz Kılma Uygulama**

Layout‑seviyesi bir geçersiz kılma, o layout’ı kullanan slaytlara uygulanır; yalnızca belirli bir slayt kendi geçersiz kılmasını yapmamışsa. Aynı başlatma yöntemleri, [LayoutSlideThemeManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutslidethememanager/) üzerinden kullanılabilir:

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

Birden çok layout ve slayt aynı temel tasarımı paylaşmalıysa master veya sunum‑seviyesi tema kullanın; bir layout ailesi farklı stil gerektiriyorsa layout geçersiz kılmasını; yalnızca gerçek istisnalar için slayt geçersiz kılmasını tercih edin. Aşırı slayt‑seviyesi geçersiz kılmalar, daha sonraki global tema değişikliklerini öngörmeyi zorlaştırır.

## **Tema Arka Plan Stillerini Güncelleme**

Temanın arka plan dolguları, [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/formatscheme/) içinde depolanır. PowerPoint, UI’da temalı dolgu, tema renkleri ve diğer stil referanslarını birleştirerek fiziksel olarak bu koleksiyonda saklanan dolgu tanımlarından daha fazla arka plan seçeneği sunabilir.

![Sunum temasına ait PowerPoint arka plan stili galerisi](presentation-design_8.png)

Bir arka plan stilini kullanmadan önce, depolanmış koleksiyonu ve geçerli [Background.getStyleIndex](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/background/) değerini inceleyin. `0` stil indeksi temalı bir dolgu olmadığını, pozitif değerlerin tema arka plan‑stil referansı olduğunu gösterir. Bu, JavaScript koleksiyonunu doğrudan indekslemeden farklıdır; burada `0` ilk depolanmış öğeyi gösterir. Her sunumun aynı sayıda arka plan dolgu stiline sahip olduğunu varsaymayın.

Aşağıdaki örnek, mevcut arka plan dolgu sayısını raporlar, ilk master’a temalı bir arka plan referansı atar ve sunumu kaydeder:

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

Görünür sonuç, master’ın başvurduğu tema girdisine ve layout ya da slayt seviyesindeki olası arka plan geçersiz kılmalarına bağlıdır. Bir slayt kendi arka planını kullanıyorsa, yalnızca master arka planını değiştirmek o slaytı etkilemez. Kalıtım sonrası nihai arka planı öğrenmek için [Background.getEffective](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/background/) kullanın.

{{% alert color="warning" title="Uyarı" %}}
Stil indeksini sıfır‑tabanlı bir koleksiyon indeksi gibi yorumlamayın. Ayrıca bir dosyadan bir stil numarasını sabitleyip başka bir dosyada aynı görünümü beklemeyin; tema stil tanımları sunuma özgüdür.
{{% /alert %}}

{{% alert color="info" title="İpucu" %}}
Doğrudan arka plan biçimlendirme ve arka plan kalıtımı için [Sunum Arka Planı](/slides/tr/nodejs-java/presentation-background/) bölümüne bakın.
{{% /alert %}}

## **Tema Efektlerini Güncelleme**

Bir tema format şeması, ayrı dolgu, çizgi ve efekt stil koleksiyonlarını [FormatScheme.getFillStyles](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/formatscheme/) ve [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/formatscheme/) aracılığıyla açığa çıkarır. Tipik Office temaları genellikle görsel olarak ince, orta ve yoğun biçimlendirmeye karşılık gelen üç ana stil girdisi içerir, ancak kod sabit bir sayıyı varsaymak yerine her koleksiyonu incelemelidir.

![Aynı şekle uygulanan ince, orta ve yoğun tema efektleri](presentation-design_10.png)

JavaScript’te bu koleksiyonlara eriştiğinizde, koleksiyon indeksi sıfır‑tabanlıdır: `0` ilk depolanmış stili, `2` üçüncüsü gösterir. Bir şeklin stil‑referans indeksleri ayrı bir kavramdır ve [ShapeStyle](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapestyle/) aracılığıyla ortaya çıkar. Bir tema stilini değiştirmek, o tema stiline başvuran şekilleri etkiler; doğrudan biçimlendirilmiş şekiller değişmeden kalabilir.

Aşağıdaki örnek, gerekli stil girdilerinin varlığını kontrol eder, ilk çizgi stilini, üçüncü dolgu stilini değiştirir, üçüncü efekt stilinde dış gölgeyi etkinleştirir ve sonucu kaydeder:

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

Bu yuvalara başvuran şekiller için, ilk tema çizgi stili kırmızı, üçüncü tema dolgu stili katı orman yeşili ve üçüncü efekt stili 10 puan mesafeli bir dış gölge kazanır. Tam görsel sonuç hâlâ hangi stil yuvalarının her şekil tarafından referans alındığına ve doğrudan biçimlendirmenin temayı geçersiz kılıp kılmadığına bağlıdır.

![Çizgi, dolgu ve gölge ayarları değiştirildikten sonraki tema efekt stilleri](presentation-design_11.png)

## **Etkili Tema Değerlerini Okuma**

Ham tema nesneleri, belirli bir seviyede tanımlanan değerleri gösterir. Etkili değerler ise kalıtım ve yerel geçersiz kılmalar çözüldükten sonra bir slaytın veya şeklin gerçekte ne kullandığını gösterir. Bir slayt için, [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseoverridethememanager/) çağırın. Bir arka plan için [Background.getEffective](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/background/), bir dolgu için ise [FillFormat.getEffective](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fillformat/) kullanın.

Aşağıdaki örnek, bir slayttan etkili temayı, arka planı ve ilk şekil dolgusu okur:

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

Etkili verileri, render tanılama, doğrulama ve karşılaştırmalar için kullanın. Yalnızca [Presentation.getMasterTheme](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/getmastertheme/) incelerseniz, final görünümü değiştiren bir master, layout, slayt veya şekil geçersiz kılmasını kaçırabilirsiniz.

## **SSS**

**Harici bir tema uygulamak sunumdaki her slaytı etkiler mi?**

Hayır. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterslide/) yalnızca seçilen master’a bağımlı slaytları yeniden atar. Diğer master kullanan slaytlar mevcut temalarını korur.

**Bir master’ı değiştirmeden tek bir slayta tema uygulayabilir miyim?**

Evet. Slaytın [SlideThemeManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidethememanager/) kullanın ve geçersiz kılma temasını başlatın. Değişiklik sadece o slayta yerel kalır; diğer slaytlar mevcut temalarını miras alır.

**Bir temayı bir sunumdan diğerine taşırken en güvenli yol nedir?**

Bir slaytı taşırken ve kaynak görünümünü korurken, kaynak master’ı hedefe [MasterSlideCollection.addClone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterslidecollection/) ile klonlayın ve ardından slaytı o master ile birlikte [SlideCollection.addClone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidecollection/) ile klonlayın. Bu, master, layout’ları ve temayı birlikte tutar.

**Kalıtım ve geçersiz kılmalardan sonra etkili değerleri nasıl görebilirim?**

Bir slayt veya layout teması için [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseoverridethememanager/) kullanın ve format nesneleri için ilgili etkili‑veri yöntemlerini (ör. [Background.getEffective](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/background/) ve [FillFormat.getEffective](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fillformat/)) çağırın. Bu API’ler, kalıtım ve geçersiz kılmalar uygulandıktan sonraki çözümlenmiş değerleri döndürür.