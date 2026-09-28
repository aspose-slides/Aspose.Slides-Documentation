---
title: JavaScript'te Sunum Metnini Biçimlendir
linktitle: Metin Biçimlendirme
type: docs
weight: 50
url: /tr/nodejs-java/text-formatting/
keywords:
- paragraf hizalama
- metin stili
- metin arka planı
- metin şeffaflığı
- karakter aralığı
- yazı tipi özellikleri
- yazı tipi ailesi
- metin döndürmesi
- döndürme açısı
- metin çerçevesi
- satır aralığı
- otomatik sığdırma özelliği
- metin çerçevesi sabitlemesi
- metin sekmesi
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java kullanarak PowerPoint ve OpenDocument sunumlarında metni biçimlendirin ve stil verin. Yazı tiplerini, renkleri, hizalamayı ve daha fazlasını özelleştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Node.js via Java kullanarak PowerPoint ve OpenDocument sunumlarında metni nasıl biçimlendireceğinizi gösterir. Arka plan renkleri, şeffaflık, karakter aralığı, yazı tipi özellikleri, dönüş, paragraf aralığı, otomatik sığdırma davranışı, metin sabitleme, sek durakları ve dil ayarlarını kapsar.

Aksi belirtilmedikçe, örnekler [sample.pptx](sample.pptx) dosyasını kullanır. İlk slaytındaki ilk şekil bir metin kutusudur ve ilk paragrafı aşağıda gösterilen metni içerir. Slayt ve şekil indeksleri sıfır tabanlıdır. Kalın bölümleri seçen örnekler, kalıtsal kalın biçimlendirme dahil olmak üzere etkili biçimlendirmeyi kullanır:

![Örnek metin](sample_text.png)

Gerçek metni veya düzenli ifade eşleşmelerini bulmak ve vurgulamak için [Metin Arama ve Değiştirme](/slides/tr/nodejs-java/search-and-replace-text/) bölümüne bakın.

## **Metin Arka Plan Rengini Ayarla**

Bir paragraf için varsayılan vurgulama rengini ayarlamak için [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) kullanın veya bireysel metin bölümleri için [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor--) kullanın.

Aşağıdaki örnek, ilk paragraf için varsayılan olarak açık gri bir vurgulama ayarlar. Bireysel bölümlerde belirtilen vurgulama renkleri bu varsayılanın üzerine yazar:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Paragrafın tamamı için vurgulama rengini ayarla.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Gri paragraf](gray_paragraph.png)

Aşağıdaki kod örneği **kalın bir yazı tipine sahip metin bölümleri** için arka plan renginin nasıl ayarlanacağını gösterir:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Metin bölümü için vurgulama rengini ayarla.
            portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Gri metin bölümleri](gray_text_portions.png)

## **Metin Paragraflarını Hizala**

Bir metin çerçevesi içinde paragraf hizalamasını ayarlamak için [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) kullanın. Değer, ortalanmış, sola hizalı, sağa hizalı, iki yana yaslı vb. olabilir.

Aşağıdaki kod örneği paragrafı **ortaya** hizalamayı gösterir:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Paragraf hizalamasını ortaya ayarla.
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Hizalanmış paragraf](aligned_paragraph.png)

## **Metin İçin Şeffaflığı Ayarla**

Şeffaflık, [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--) ile atanan rengin alfa bileşeni üzerinden kontrol edilir. Aşağıdaki örneklerde `alpha = 50`, 0–255 ölçeğinde bir ARGB alfa kanalı değeridir, yüzde şeffaflık değildir.

Aşağıdaki kod örneği **tüm paragraf** için şeffaflığın nasıl uygulanacağını gösterir:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const fillFormat = paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat();

    // Metnin dolgu rengini şeffaf renk olarak ayarla.
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Şeffaf paragraf](transparent_paragraph.png)

Aşağıdaki kod örneği **kalın bir yazı tipine sahip metin bölümleri** için şeffaflığın nasıl uygulanacağını gösterir:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const fillFormat = portion.getPortionFormat().getFillFormat();

            // Metin bölümünün şeffaflığını ayarla.
            fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
            fillFormat.getSolidFillColor().setColor(transparentBlack);
        }
    }

    presentation.save("transparent_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Şeffaf metin bölümleri](transparent_text_portions.png)

## **Metin İçin Karakter Aralığını Ayarla**

Metin kutusundaki karakterler arasındaki aralığı genişletmek veya daraltmak için [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) kullanın. Örneklerde 3 puan aralık eklenir; negatif değerler metni sıkıştırır.

Aşağıdaki JavaScript kodu **tüm paragraf** içinde karakter aralığını nasıl genişleteceğinizi gösterir:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Not: Karakter aralığını sıkıştırmak için negatif değerler kullanın.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Karakter aralığını genişlet.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Paragraftaki karakter aralığı](character_spacing_in_paragraph.png)

Aşağıdaki kod örneği **kalın bir yazı tipine sahip metin bölümleri** içinde karakter aralığını nasıl genişleteceğinizi gösterir:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Not: Karakter aralığını sıkıştırmak için negatif değerler kullanın.
            portion.getPortionFormat().setSpacing(3); // Karakter aralığını genişlet.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Metin bölümlerindeki karakter aralığı](character_spacing_in_text_portions.png)

### **Belirli Yazı Tipleri İçin Kerning'i Devre Dışı Bırak**

Bazı durumlarda, Aspose.Slides tarafından render edilen metin, PowerPoint’teki aynı metinden biraz daha sık görünebilir. Bu, PowerPoint’in belirli yazı tipleri için kerning verisini göz ardı etmesinden kaynaklanabilir; hatta yazı tipi geçerli kerning bilgisine sahipse ve PowerPoint ayarlarında kerning açıksa bile.

Böyle durumlarda render edilen çıktıyı PowerPoint’e daha yakın hâle getirmek için, etkilenen yazı tipini kullanan metin bölümleri için kerning’i devre dışı bırakabilirsiniz. [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) değerini gerçek yazı tipi boyutundan büyük bir değere ayarlayın. Bu örnek, ilk slaydın ilk şekli olarak bir metin kutusu içeren "presentation.pptx" dosyasını gerektirir. Etkili yazı tipi adlarını, kalıtsal yazı tipleri dahil, kontrol eder ve Roboto kullanan bölümler için 100 puanlık bir eşik ayarlar. Bu, 100 puandan düşük boyuttaki eşleşen bölümler için kerning’i devre dışı bırakır:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraphs = autoShape.getTextFrame().getParagraphs();
    const paragraphCount = paragraphs.getCount();
    const targetFont = "Roboto";

    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const portions = paragraphs.get_Item(paragraphIndex).getPortions();
        const portionCount = portions.getCount();

        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const portionFormat = portion.getPortionFormat().getEffective();
            const latinFont = portionFormat.getLatinFont();
            const eastAsianFont = portionFormat.getEastAsianFont();
            const complexScriptFont = portionFormat.getComplexScriptFont();

            if ((latinFont !== null && latinFont.getFontName() === targetFont) ||
                (eastAsianFont !== null && eastAsianFont.getFontName() === targetFont) ||
                (complexScriptFont !== null && complexScriptFont.getFontName() === targetFont)) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Eşiğin altındaki eşleşen metinler için bu ayar kerning’i engeller ve bu PowerPoint’e özgü davranıştan etkilenen yazı tipleri için Aspose.Slides renderlamasını PowerPoint’in görsel çıktısına yaklaştırmaya yardımcı olabilir.

## **Metin Yazı Tipi Özelliklerini Yönet**

Yazı tipi özellikleri, paragraf düzeyinde [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) aracılığıyla veya bireysel bölümlerde [PortionFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portionformat/) aracılığıyla ayarlanabilir.

Aşağıdaki örnek, ilk paragrafın varsayılan yazı tipini 12 puan Times New Roman olarak, kalın, italik ve noktalı alt çizgi biçimlendirmesiyle ayarlar. Bireysel bölümlerde belirtilen biçimlendirme bu varsayılanların üzerine yazar:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // Paragraf için yazı tipi özelliklerini ayarla.
    defaultPortionFormat.setFontHeight(12);
    defaultPortionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
    defaultPortionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Paragraf için yazı tipi özellikleri](font_properties_for_paragraph.png)

Aşağıdaki örnek, etkili biçimlendirmesi kalın olan bölümlere 13 puan Times New Roman, italik biçimlendirme ve noktalı alt çizgi uygular:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const portionFormat = portion.getPortionFormat();

            // Metin bölümü için yazı tipi özelliklerini ayarla.
            portionFormat.setFontHeight(13);
            portionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
            portionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
            portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Metin bölümleri için yazı tipi özellikleri](font_properties_for_text_portions.png)

## **Metin Döndürmeyi Ayarla**

Bir şekil içinde önceden tanımlanmış bir metin yönelimi ayarlamak için [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) kullanın.

Aşağıdaki kod örneği, şeklin içinde metin yönelimini [TextVerticalType.Vertical270](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textverticaltype/) olarak ayarlar; bu, metni **90 derece saat yönünün tersine** döndürür:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Metin döndürmesi](text_rotation.png)

## **Metin Çerçeveleri İçin Özel Döndürmeyi Ayarla**

Bir [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) için özel bir döndürme açısı ayarlamak için [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) kullanın.

Aşağıdaki kod örneği, şekil içinde metin çerçevesini saat yönünde 3 derece döndürür:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Özel metin döndürmesi](custom_text_rotation.png)

## **Paragrafların Satır Aralığını Ayarla**

Aspose.Slides, paragraf aralığını kontrol etmek için [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-) ve [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) sağlar. Bu özellikler şu şekilde kullanılır:

* Pozitif bir değer, satır aralığını satır yüksekliğinin bir yüzdesi olarak belirtir.
* Negatif bir değer, satır aralığını puan olarak belirtir.

Aşağıdaki örnek, ilk paragraf içinde satır aralığını satır yüksekliğinin %200'ü (çift satır aralığı) olarak ayarlar:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Paragraftaki satır aralığı](line_spacing.png)

## **Satır Kesintisini Kontrol Et**

Paragraf satır kesme kuralları, dar metin bloklarında ve Latin ile Doğu Asya metinlerinin karıştığı sunumlarda kullanışlıdır. Aşağıdaki yöntemler [ParagraphFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/) içinde bulunur, bu yüzden tüm paragrafı etkiler:

- [setLatinLineBreak](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/#setLatinLineBreak-byte-) Latin satır kesme kurallarını denetler. Karışık metinlerde değiştirilmesi, bitişik Doğu Asya metni ve noktalama işaretlerinin nerede kayacağını da etkileyebilir.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/#setEastAsianLineBreak-byte-) Doğu Asya satır kesme kurallarını denetler; satır başı ve sonundaki karakter sınırlamalarını içerir.

Bu kurallar, bir metin çerçevesi içinde otomatik kaydırmayı etkinleştiren [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframeformat/#setWrapText-byte-) işlevinin yerine geçmez. Kaydırma gerçekleştiğinde düzeni etkiler; satır sonu karakteri eklemezler. Açık bir satır sonu, mevcut genişlikten bağımsız olarak paragraf içinde yeni bir satır oluşturur.

Aşağıdaki bağımsız örnek, Çince ve Latin metin içeren dar bir metin bloğu oluşturur. Her iki satır kesme seçeneği de açıkça ayarlanır ve "line_breaking.pptx" olarak kaydedilir. Her iki kuralı da denemek için, diğer ayarları sabit tutarak ilgili değeri değiştirin. Örnek 24 puan Arial ve SimSun, 160 puan çerçeve genişliği ve yatay metin çerçevesi kenar boşlukları sıfır olarak kullanır. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) [TextAutofitType.None](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textautofittype/) ile çağrılır, böylece metin boyutu ve çerçeve boyutları sabit kalır:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    const eastAsianFont = new aspose.slides.FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setLatinLineBreak(java.newByte(aspose.slides.NullableBool.False));
    format.setEastAsianLineBreak(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("line_breaking.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Asılı Noktalama İşaretlerini Kontrol Et**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/#setHangingPunctuation-byte-) uygun noktalama işaretlerinin metin satırının sağ kenarını aşarak bir sonraki satıra yerleşmek yerine uzamasına izin verir. Tüm paragrafı etkiler ve asılı girintiden farklıdır.

Aşağıdaki bağımsız örnek, 100 puan genişliğindeki bir metin çerçevesinde asılı noktalama işaretlerini etkinleştirir ve "hanging_punctuation.pptx" olarak kaydeder. 24 puan Arial ve yatay metin çerçevesi kenar boşlukları sıfır olduğunda, son nokta "cümle" kelimesinin ardından kalır ve sağ metin kenarını aşar. Özelliği [NullableBool.False](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/nullablebool/) olarak ayarlayarak karşılaştırabilirsiniz: bu ayarlarda nokta ayrı bir satırda yer alır. Kaydırma etkin ve otomatik sığdırma devre dışı bırakılmıştır, böylece kullanılabilir genişlik sabit kalır:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setHangingPunctuation(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("hanging_punctuation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Her noktalama işareti asılı olmayabilir. Görülen sonuç, yazı tipi mevcutluğu ve düzenine bağlıdır; yazı tipini, kullanılabilir genişliği, kenar boşluklarını veya otomatik sığdırma ayarlarını değiştirerek görünür fark ortadan kalkabilir.

## **Metin Çerçeveleri İçin Otomatik Sığdırma Türünü Ayarla**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) metnin, kapsayıcısının sınırlarını aştığında nasıl davranacağını belirler. Metnin küçülüp küçülmeyeceğini, taşma yapıp yapmayacağını veya şeklin otomatik olarak yeniden boyutlandırılıp boyutlandırılmayacağını kontrol etmek için kullanılır. Aşağıdaki örnek, şekli metnine uyacak şekilde yeniden boyutlandırır ve sonucu "autofit_type.pptx" olarak kaydeder:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));

    presentation.save("autofit_type.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Otomatik kaydırmadan sonra satırları saymak ve metin ya da şekil genişliğinin sonuca etkisini görmek için [Renderlanmış Satırları Sayma](/slides/tr/nodejs-java/manage-paragraph/) bölümüne bakın. Satır sayısı tek başına, metnin kapsayıcısını aşıp aşmadığını göstermez.

## **Metin Çerçevelerinin Sabitlemesini Ayarla**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) metnin bir şekil içinde dikey konumunu tanımlar; örneğin üst, orta veya altta. Aşağıdaki örnek, metni ilk şeklin alt kısmına sabitler ve sonucu "text_anchor.pptx" olarak kaydeder:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Bottom));

    presentation.save("text_anchor.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Metin Sekmelerini Ayarla**

Paragrafta sek duraklarını yapılandırmak için [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) ve [ParagraphFormat.getTabs](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/#getTabs--) kullanın. Aşağıdaki örnek, varsayılan sek aralığını 100 puan olarak ayarlar ve 30 puanda sol hizalı bir sek durak ekler. Bu ayarlar sek karakteri içeren metni etkiler:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, java.newByte(aspose.slides.TabAlignment.Left));

    presentation.save("paragraph_tabs.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Paragraf sekmeleri](paragraph_tabs.png)

## **Düzeltme Dilini Ayarla**

Aspose.Slides, bir metin bölümü için düzeltme dilini ayarlamanıza izin veren [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) sağlar. Düzeltme dili, PowerPoint’te imla ve dilbilgisi denetimleri için kullanılan dili belirler.

Aşağıdaki örnek, ilk slaydın ilk şekli olarak bir metin kutusu ve en az bir paragraf içeren "presentation.pptx" dosyasını gerektirir. İlk paragrafın içeriğini "1。" ile değiştirir, yazı tipini SimSun olarak ayarlar ve basitleştirilmiş Çince düzeltme dili (`zh-CN`) atar. Sonucu "proofing_language.pptx" olarak kaydeder:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const font = new aspose.slides.FontData("SimSun");
    const textPortion = new aspose.slides.Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Düzeltme dilinin kimliğini ayarla.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Varsayılan Dili Ayarla**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) bir sunum yüklenirken veya oluşturulurken oluşturulan metnin varsayılan dilini tanımlar. Aşağıdaki örnek, varsayılan metin dili olarak ABD İngilizcesi (en-US) kullanan bir sunum oluşturur, bir metin kutusu ekler ve ilk metin bölümünün dilini `en-US` olarak yazdırır:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // Yeni bir dikdörtgen şekil metin ile ekle.
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // İlk bölümün dilini kontrol et.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Varsayılan Metin Stili Ayarla**

Sunum seviyesinde varsayılan metin biçimlendirmesini uygulamak için [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--) kullanın.

Aşağıdaki örnek, yeni bir sunumda üst düzey paragraflar için varsayılan olarak 14 puan kalın bir yazı tipi ayarlar ve sonucu "default_text_style.pptx" olarak kaydeder. Metin, daha belirgin bir biçimlendirme olmadıkça bu varsayılanları devralır.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    // Üst seviye paragraf biçimini al.
    const paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat !== null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    }

    presentation.save("default_text_style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **All-Caps Efektiyle Metni Çıkar**

PowerPoint’te **All Caps** yazı tipi efekti uygulandığında, metin slaytta büyük harf olarak gösterilir, ancak aslında küçük harfle girilmiştir. Aspose.Slides ile böyle bir metin bölümü alındığında kütüphane metni tam olarak girildiği gibi döndürür. Görünen metni eşleştirmek için [TextCapType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textcaptype/) kontrol edin ve değer `All` olduğunda döndürülen dizeyi büyük harfe çevirin.

Bu örnek, ilk slaydın ilk şekli olarak bir metin kutusu içeren "sample2.pptx" dosyasını gerektirir. İlk paragrafın ilk bölümü, All Caps etkisi uygulanmış "Hello, Aspose!" metnini içerir, aşağıda gösterildiği gibi.

![All Caps Efekti](all_caps_effect.png)

Aşağıdaki kod örneği, **All Caps** etkisi uygulanmış metni nasıl çıkaracağınızı gösterir:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const autoShape = slide.getShapes().get_Item(0);
    const textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    console.log("Original text: " + textPortion.getText());

    const textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() === aspose.slides.TextCapType.All) {
        const text = textPortion.getText().toUpperCase();
        console.log("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```

Çıktı:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **SSS**

**Bir slayttaki tablo içinde metni nasıl değiştiririm?**

Bir slayttaki tablo içinde metni değiştirmek için [Table](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/table/) kullanın. Hücreler üzerinden döngü yapın ve her hücreyi [Cell.getTextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/cell/#getTextFrame--) ile güncelleyin; paragraf biçimlendirmesini ise [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--) ile yapın.

**PowerPoint slaytındaki metne nasıl bir degrade (gradient) renk uygularım?**

Metne degrade renk uygulamak için [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--) kullanın. [FillFormat.setFillType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) değerini [FillType.Gradient](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/filltype/) olarak ayarlayın ve degrade duraklarını, yönünü ve şeffaflığını yapılandırın.