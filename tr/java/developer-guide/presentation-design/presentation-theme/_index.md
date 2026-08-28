---
title: Java'da Sunum Temalarını Yönetme
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
- Java
- Aspose.Slides
description: "Java için Aspose.Slides'te ana sunum temaları, PowerPoint dosyalarını tutarlı bir marka kimliğiyle oluşturmak, özelleştirmek ve dönüştürmek için kullanılır."
---
## **Giriş**

Bir sunum teması, renkler, yazı tipleri, arka plan stilleri, doldurmalar, çizgiler ve efektler gibi uyumlu bir küme tanımlar. Tema farkındalığına sahip nesneler, her görsel özelliği sabit bir değer olarak depolamak yerine bu ortak tanımlara başvurur; böylece bir tema değişikliği bir kerede birçok nesneyi güncelleyebilir.

Aspose.Slides içinde, sunum‑seviyesi tema, [Presentation.getMasterTheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) aracılığıyla kullanılabilir. Bir sunum ayrıca alt seviyelerde tema geçersiz kılmaları içerebilir. Bir master, [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/masterthememanager/) üzerinden sunum temasını geçersiz kılabilir, bir düzen ya da tek bir slayt ise [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/baseoverridethememanager/) aracılığıyla kalıtılan temasını geçersiz kılabilir. Pratikte, bir slayt için geçerli tema, şu kalıtım zinciri üzerinden çözülür: sunum teması, master geçersiz kılma, düzen geçersiz kılma ve slayt geçersiz kılma.

![Tema bileşenleri: renkler, yazı tipleri, arka plan stilleri ve efektler](theme-constituents.png)

Aşağıdaki bölümler en yaygın tema iş akışlarını gösterir: bir temayı inceleme, renk ve yazı tiplerini değiştirme, bir temayı kopyalama ya da uygulama, arka plan ve efekt stillerini güncelleme ve kalıtım ve geçersiz kılmalar çözüldükten sonra geçerli değerleri okuma.

## **Temayı İnceleme**

[MasterTheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/mastertheme/) nesnesi, tema renk şemasını, yazı tipi şemasını ve biçim şemasını sırasıyla [MasterTheme.getColorScheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/mastertheme/) ve [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/mastertheme/) aracılığıyla ortaya çıkar. Bu koleksiyonları değiştirmeden önce incelemek, özellikle bir sunum dış kaynaktan geldiğinde stil girişlerinin sayısı ve içeriği değişebileceği için faydalıdır.

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

Bir dosya birden fazla master kullanıyorsa, her slaytın aynı geçerli temaya sahip olduğunu varsaymayın. Slayt ile ilişkili master’ı inceleyin ve düzen ya da slayt geçersiz kılmalarının mevcut olabileceği durumlarda bu makalenin ilerleyen kısmında gösterilen geçerli‑tema iş akışını kullanın.

## **Tema Renklerini Değiştirme**

Tema‑farkındalığına sahip doldurmalar, çizgiler ve metin, [SchemeColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/schemecolor/) dışsalından mantıksal bir renge başvurabilir. [IColorScheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icolorscheme/) içindeki ilgili girişi değiştirdiğinizde, hâlâ bu tema rengini başvuran tüm nesneler yeni değere göre çözülür. Doğrudan bir RGB rengi kullanan nesneler tema‑rengi güncellemesinden etkilenmez.

Aşağıdaki uçtan‑uyağa örnek, `Accent4` kullanan bir şekil oluşturur, temadaki `Accent4` rengini kırmızıya değiştirir, sunumu kaydeder, yeniden açar ve geçerli doldurma rengini yazdırır:

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

Dikdörtgen hâlâ `Accent4` ile bağlantılı olduğundan, tema değiştirildiğinde görünen rengi kırmızı olur. Şekildeki şema rengini doğrudan bir renkle değiştirirseniz, sonraki `Accent4` değişiklikleri artık bu doldurmayı etkilemez.

### **Ek Paletten Renk Kullanma**

PowerPoint, bir tema renginden daha açık ve daha koyu varyantlar üretmek için renk dönüşümleri uygular. Aspose.Slides, bu dönüşümleri [ColorTransformOperation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/colortransformoperation/) dışsalı aracılığıyla ortaya çıkarır.

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

Bu varyantlar tema rengine dayalı kalır. `Accent4` daha sonra değişirse, dönüştürülmüş renkler yeni `Accent4` değerinden yeniden hesaplanır.

### **`SchemeColor` Değerlerini `IColorScheme` Yuvalarına Eşleme**

[SchemeColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/schemecolor/) dışsalı `Text1`, `Background1`, `Text2` ve `Background2` kullanırken, [IColorScheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icolorscheme/) aynı tema yuvalarını `Dark1`, `Light1`, `Dark2` ve `Light2` olarak ortaya çıkarır. Eşleme sabittir:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Bunlar aynı tema yuvalarının farklı adlarıdır; bir formdan diğerine dinamik olarak dönüştürülen değerler değildir.

## **Tema Yazı Tiplerini Değiştirme**

Bir tema yazı tipi şeması, başlıklar için bir ana yazı tip seti ve gövde metni için bir alt yazı tip seti içerir. [IFontScheme.getMajor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontscheme/) ve [IFontScheme.getMinor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontscheme/) metodları bu setleri ortaya çıkarır.

PowerPoint‑uyumlu tema yazı tipi tanımlayıcıları metin biçimlendirmesinde kullanılabilir:

* `+mn-lt` - Gövde Yazı Tipi Latin (Minor Latin Font)
* `+mj-lt` - Başlık Yazı Tipi Latin (Major Latin Font)
* `+mn-ea` - Gövde Yazı Tipi Doğu Asya (Minor East Asian Font)
* `+mj-ea` - Başlık Yazı Tipi Doğu Asya (Major East Asian Font)

Aşağıdaki örnek, ana Latin tema yazı tipini kullanan bir başlık ve alt Latin tema yazı tipini kullanan bir gövde satırı oluşturur. Ardından tema yazı tiplerini değiştirir ve sonucu kaydeder:

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

Başlık ana yazı tipini, gövde metni ise alt yazı tipini takip eder. Açıkça bir yazı tipi adı içeren metin, tema yazı tipi şeması değiştiğinde otomatik olarak değişmez.

Ana ve alt yazı tipi koleksiyonları ayrıca Kiril, Arapça, Japonca, Gürcüce ve Thaana gibi bireysel yazı sistemleri için yazı tipi eşlemeleri içerebilir. Bu eşlemeleri incelemek, eklemek, değiştirmek ya da kaldırmak için [Script‑Specific Theme Fonts](/slides/tr/java/script-specific-font-mappings/) bölümüne bakın.

{{% alert color="info" title="Tip" %}}

Sunum yazı tipleri hakkında daha fazla bilgi için [PowerPoint Fonts](/slides/tr/java/powerpoint-fonts/) sayfasına bakın.

{{% /alert %}}

## **Tema Kopyalama veya Uygulama**

Aşağıdaki iş akışları farklı tema ilgili sorunları çözer.

### **Bir Master’ın Bağımlı Slaytlarına Dış Tema Uygulama**

Bir PowerPoint tema dosyanız (.thmx) var ve belirli bir master’a bağlı tüm slaytların stilini değiştirmek istiyorsanız, [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterslide/) kullanın. [Presentation.getMasters](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) koleksiyonundan master’ı seçin (bu koleksiyon [IMasterSlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterslidecollection/) uygular) ve tema dosyasının yolunu metoda iletin.

Metod şu işlemleri yapar:

1. Seçilen master’a dayanarak yeni bir master slayt oluşturur.
1. Dış temayı yeni master’a uygular.
1. Daha önce seçilen master’a bağlı tüm slaytlara yeni master’ı atar.
1. Yeni oluşturulan [IMasterSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterslide/) nesnesini döndürür.

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

Geçersiz, bozuk veya desteklenmeyen bir tema, [PptxReadException](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pptxreadexception/) oluşturabilir. Kullanıcıların sağladığı yolları doğrulayın, dosya sistemi erişim hatalarını yönetin ve temayı başarıyla uyguladıktan sonra sunumu kaydedin.

Yalnızca seçilen master’a bağlı slaytlar yeniden atanır. Diğer master’lara bağlı slaytlar mevcut master ve temalarını korur. Tema‑farkındalığına sahip renkler, yazı tipleri, doldurmalar, çizgiler, arka planlar ve efektler dış tema doğrultusunda çözülür. Doğrudan atanmış renkler, yazı tipleri, doldurmalar ve diğer açık biçimlendirmeler değişmemiş kalabilir. Düzen‑seviyesi ve slayt‑seviyesi geçersiz kılmalar da yeni master’dan kalıtılan değerler üzerinde öncelik kazanabilir.

Tema, çalışma zamanında bulunmayan yazı tiplerine referans verebilir. Tutarlı render ve dışa aktarma için gerekli yazı tiplerini kurun, [özel yazı tipi kaynakları](/slides/tr/java/custom-font/) aracılığıyla sağlayın veya [yazı tipi ikamesi](/slides/tr/java/font-substitution/) yapılandırın.

Bu, doğrudan master‑seviyesi bir iş akışıdır: Metod bir `.thmx` dosya yolunu kabul eder ve slayt‑seviyesi ya da düzen‑seviyesi tema geçersiz kılmaları manuel olarak oluşturmayı gerektirmez.

### **Çok‑Masterlı Sunumda Farklı Dış Temalar Uygulama**

İlgili master önceden bilinmiyorsa, onu bir temsilci slayttan [ISlide.getLayoutSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islide/) ve [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutslide/) aracılığıyla alın. Tema uygulamadan önce orijinal master referanslarını saklayın; çünkü her çağrı sunumda yeni bir master oluşturur.

Aşağıdaki örnek, iki bölümden slaytları alır, master’larını bulur ve her grup için farklı bir dış tema uygular:

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

İlk çağrı yalnızca `firstGroupMaster`‑a bağlı slaytları etkiler, ikinci çağrı yalnızca `secondGroupMaster`‑a bağlı slaytları etkiler. Başka herhangi bir master’a bağlı slaytlar yeniden stil almaz.

### **Slayt Taşırken Kaynak Temasını Koru**

Bir slaytı başka bir sunuma taşımak ve özgün tasarımını korumak istiyorsanız, kaynak master’ı hedef sunuma [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterslidecollection/) ile klonlayın, ardından slaytı ve klonlanmış master’ı [ISlideCollection.addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidecollection/) ile klonlayın. Böylece master, onun düzenleri ve ilişkili tema birlikte taşınır.

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

Bu, kaynak slaytın hedefte aynı görünmesi gerektiğinde tercih edilen iş akışıdır. İçeriği bağımsız bir hedef master’a klonlamak tema‑türevi renkleri, yazı tiplerini, arka planları ve efektleri değiştirebilir.

### **Mevcut Bir Slayta Tema Değerleri Uygulama**

Hedef slayt mevcut master ve düzeninde kalmalıysa, kaynağın temasından slayt‑seviyesi bir geçersiz kılma başlatın. [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/tr/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/tr/java/com.aspose.slides/overridetheme/) ve [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/tr/java/com.aspose.slides/overridetheme/) metodları üç ana tema bileşenini geçersiz kılmaya kopyalar.

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

Bu, o slaytın temasını diğer slaytların kalıtım temasını etkilemeden değiştirir. Yerel geçersiz kılmayı kaldırıp kalıtılan değerlere dönmek için [OverrideTheme.clear](https://reference.aspose.com/slides/tr/java/com.aspose.slides/overridetheme/) çağırın.

### **Bir Düzeni Tema Geçersiz Kılmasına Uygulama**

Düzen‑seviyesi bir geçersiz kılma, o düzeni kullanan slaytlara uygulanır; fakat belirli bir slaytın kendi geçersiz kılması varsa o geçerli olur. Aynı başlatma metodları [LayoutSlideThemeManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/layoutslidethememanager/) üzerinden kullanılabilir:

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

Birden çok düzen ve slayt aynı temel tasarımı paylaşmalıysa master ya da sunum‑seviyesi tema kullanın; bir düzen ailesi farklı bir stil gerektiriyorsa düzen geçersiz kılmasını, yalnızca gerçek istisnalar için slayt geçersiz kılmasını kullanın. Aşırı slayt‑seviyesi geçersiz kılmalar, ilerideki genel tema değişikliklerini öngörmeyi zorlaştırır.

## **Tema Arka Plan Stillerini Güncelleme**

Temanın arka plan doldurmaları, [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iformatscheme/) üzerinden depolanır. PowerPoint, UI’da temaya ait doldurmaları tema renkleri ve diğer stil referanslarıyla birleştirerek, fiziksel olarak bu koleksiyonda depolanan doldurma tanım sayısından daha fazla arka plan seçeneği sunabilir.

![Sunum temasına ait PowerPoint arka plan stil galerisini gösterir](presentation-design_8.png)

Bir arka plan stilini kullanmadan önce depolanmış koleksiyonu ve geçerli [Background.getStyleIndex](https://reference.aspose.com/slides/tr/java/com.aspose.slides/background/) değerini inceleyin. `0` stil indeksi temalı bir doldurma olmadığını, pozitif değerlerin tema arka plan‑stil referansı olduğunu gösterir. Bu, Java koleksiyonuna doğrudan indeksleme (`get_Item(0)` ilk depolanmış öğe demektir) ile aynı değildir. Her sunumun aynı sayıda arka plan doldurma stiline sahip olduğunu varsaymayın.

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

Görünür sonuç, master’ın referans verdiği tema girişine ve düzen ya da slayt seviyesindeki olası arka plan geçersiz kılmalarına bağlıdır. Bir slayt kendi arka planını kullanıyorsa, yalnızca master arka planını değiştirmek o slaytı etkilemeyebilir. Kalıtım uygulandıktan sonra nihai arka planı öğrenmek için [Background.getEffective](https://reference.aspose.com/slides/tr/java/com.aspose.slides/background/) kullanın.

{{% alert color="warning" title="Uyarı" %}}

Stil indeksini sıfır‑tabanlı bir koleksiyon indeksi gibi işlemeyin. Ayrıca bir dosyadan alınan stil numarasını doğrudan kodlamak ve başka bir dosyada aynı görünüme sahip olacağını varsaymak da hatalıdır; tema stil tanımları sunuma özeldir.

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

Doğrudan arka plan biçimlendirmesi ve arka plan kalıtımı için [Presentation Background](/slides/tr/java/presentation-background/) bölümüne bakın.

{{% /alert %}}

## **Tema Efektlerini Güncelleme**

Bir tema biçim şeması, ayrı doldurma, çizgi ve efekt stil koleksiyonları içerir; bunlar sırasıyla [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iformatscheme/) ve [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iformatscheme/) aracılığıyla ortaya çıkar. Tipik Office temaları görsel olarak hafif, orta ve yoğun biçimlendirmelere karşılık gelen üç ana stil girişi içerir, ancak kod sabit bir sayıya dayanmak yerine her koleksiyonu denetlemelidir.

![Aynı şekle uygulanmış hafif, orta ve yoğun tema efektleri](presentation-design_10.png)

Java’da bu koleksiyonlara eriştiğinizde, koleksiyon indeksi sıfır‑tabanlıdır: `get_Item(0)` ilk depolanmış stil, `get_Item(2)` üçüncü stildir. Bir şeklin stil‑referans indeksleri ayrı bir kavramdır ve [IShapeStyle](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapestyle/) aracılığıyla ortaya çıkar. Bir tema stilini değiştirmek, o tema stiline başvuran şekilleri etkiler; doğrudan biçimlendirilmiş şekiller değişmeden kalabilir.

Aşağıdaki örnek, gerekli stil girişlerinin mevcut olduğunu doğrular, ilk çizgi stilini, üçüncü doldurma stilini değiştirir, üçüncü efekt stilinde dış gölgeyi etkinleştirir ve sonucu kaydeder:

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

Bu yuvalara başvuran şekillerde, ilk tema çizgi stili kırmızı, üçüncü tema doldurma stili katı orman yeşili ve üçüncü efekt stili 10 puan mesafede bir dış gölge alır. Tam görsel sonuç, her şeklin hangi stil yuvasına başvurduğuna ve doğrudan biçimlendirme tema stilini geçersiz kılıp kılmadığına bağlıdır.

![Satır, doldurma ve gölge ayarları değiştirildikten sonra tema efekt stilleri](presentation-design_11.png)

## **Geçerli Katı Doldurmanın Tema Rengi Kullanıp Kullandığını Belirleme**

Bir doldurma doğrudan bir nesneye atanmış ya da bir paragraf, düzen, master, tema stili ya da başka bir biçimlendirme seviyesinden kalıtılmış olabilir. Bu hiyerarşiyi değişmez bir [IFillFormatEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifillformateffectivedata/) nesnesine dönüştürmek için [IFillFormat.getEffective](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifillformat/) çağırın. İlk olarak [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifillformateffectivedata/) kontrol edin. Yalnızca değer `FillType.Solid` olduğunda katı‑doldurma özelliklerini okuyun.

Katı doldurma için, [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifillformateffectivedata/) kalıtım, tema araması ve renk dönüşümleri uygulandıktan sonraki nihai RGB değerini döndürür. [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifillformateffectivedata/) ilgili mantıksal [SchemeColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/schemecolor/) yuvasını, örneğin `Text1` ya da `Accent6`, verir. `SchemeColor.NotDefined` değeri, geçerli katı doldurmanın bir şema rengine dayanmadığını gösterir. Tema renkleri ya da doğrudan RGB renkleri kullanan bir iş akışında bu değer, doğrudan RGB doldurmayı tanımlar.

Yerel [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icolorformat/) değerine yalnızca bakarak bir doldurmayı sınıflandırmayın. Örneğin, bir metin parçası yerel olarak şema rengi tanımlamamış olabilir, bu yüzden yerel değeri `NotDefined` olur; ancak geçerli doldurması bir tema rengine kalıtılmış ve `Text1` ya da `Accent6` olarak çözülür. Öte yandan, `getSolidFillSchemeColor` hangi mantıksal tema yuvasının geçerli rengi ürettiğini söyler, ancak bu yuvanın nesneden, paragraftan, düzenden, master’dan ya da biçimlendirme hiyerarşisinin başka bir seviyesinden geldiğini göstermez.

Aşağıdaki örnek bir sunumu yükler, hem şekil doldurmalarını hem de metin‑parçası doldurmalarını denetler, her bir nihai RGB değerini ve ilişkili şema rengini yazar ve tema rengi değişikliklerini takip etmeyecek katı doldurmaları işaretler:

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

`NotDefined` dalı, tema rengi yuvalarındaki değişikliklere yanıt vermeyecek katı doldurmalara ait bir denetim listesi sağlar. Sunum yeni bir marka paleti izlemeliyse bu nesneleri gözden geçirin. Raporlanan RGB değeri hâlâ mevcut görünümü gösterirken, şema değeri bu görünümün tema ile bağlantılı olup olmadığını açıklar.

Geçerli‑format nesneleri anlık görüntülerdir. Sunum temasını, bir tema geçersiz kılmasını ya da herhangi bir kalıtılmış biçimlendirmeyi değiştirdikten sonra `getEffective` tekrar çağırın ve renkleri karşılaştırmadan ya da raporlamadan önce yeni bir `IFillFormatEffectiveData` nesnesi okuyun.

## **Geçerli Tema Değerlerini Okuma**

Ham tema nesneleri belirli bir seviyede tanımlı olanı gösterir. Geçerli değerler, kalıtım ve yerel geçersiz kılmalar çözüldükten sonra bir slayt ya da şeklin gerçekte ne kullandığını gösterir. Bir slayt için [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/tr/java/com.aspose.slides/baseoverridethememanager/) çağırın. Arka plan için [Background.getEffective](https://reference.aspose.com/slides/tr/java/com.aspose.slides/background/), doldurma için ise [FillFormat.getEffective](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fillformat/) kullanın.

Aşağıdaki örnek bir slayttan geçerli tema, arka plan ve ilk şekil doldurmasını okur:

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

Render teşhisleri, doğrulama ve karşılaştırmalar için geçerli verileri kullanın. Yalnızca [Presentation.getMasterTheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) incelerseniz, master, düzen, slayt ya da şekil geçersiz kılmalarının nihai görünümü değiştirdiğini kaçırabilirsiniz.

## **SSS**

**Harici bir tema uygulaması, sunumdaki her slaytı etkiler mi?**

Hayır. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterslide/) yalnızca seçilen master’a bağlı slaytları yeniden atar. Diğer master’ları kullanan slaytlar mevcut temalarını korur.

**Bir slayta master değiştirmeden tema uygulayabilir miyim?**

Evet. Slaytın [SlideThemeManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slidethememanager/) kullanın ve geçersiz kılma temasını başlatın. Değişiklik yalnızca o slayta yerel olur; diğer slaytlar mevcut temalarını miras almaya devam eder.

**Bir temayı bir sunumdan diğerine en güvenli şekilde nasıl taşıyabilirim?**

Bir slaytı taşırken ve kaynağın görünümünü korurken, kaynak master’ı hedefe klonlayın ve ardından slaytı o master ile birlikte [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterslidecollection/) ve [ISlideCollection.addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidecollection/) kullanarak klonlayın. Böylece master, düzenler ve tema birlikte kalır.

**Kalıtım ve geçersiz kılmalardan sonra geçerli değerleri nasıl görebilirim?**

Bir slayt ya da düzen teması için [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/tr/java/com.aspose.slides/baseoverridethememanager/) ve [Background.getEffective](https://reference.aspose.com/slides/tr/java/com.aspose.slides/background/), [FillFormat.getEffective](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fillformat/) gibi ilgili geçerli‑veri metodlarını kullanın. Bu API’ler, kalıtım ve geçersiz kılmalar uygulandıktan sonra çözülmüş değerleri döndürür.