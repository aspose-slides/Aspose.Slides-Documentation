---
title: JavaScript'te Sunum Metnini Biçimlendir
linktitle: Metin Biçimlendirme
type: docs
weight: 50
url: /tr/nodejs-java/text-formatting/
keywords:
- paragraf hizala
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
- metin sekleme
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

Bu makale, Aspose.Slides for Node.js via Java kullanarak PowerPoint ve OpenDocument sunumlarında metni nasıl biçimlendireceğinizi gösterir. Arka plan renkleri, şeffaflık, karakter aralığı, yazı tipi özellikleri, döndürme, paragraf aralığı, otomatik sığdırma davranışı, metin sabitleme, sek durakları ve dil ayarları ele alınır.

Aksi belirtilmedikçe, örnekler [sample.pptx](sample.pptx) dosyasını kullanır. İlk slaytındaki ilk şekil bir metin kutusudur ve ilk paragrafı aşağıda gösterilen metni içerir. Slayt ve şekil indeksleri sıfır tabanlıdır. Kalın bölümleri seçen örnekler, kalıtılan kalın biçimlendirme dahil olmak üzere etkili biçimlendirme kullanır:

![Örnek metin](sample_text.png)

Gerçek metin veya düzenli ifadelerle eşleşmeleri bulmak ve vurgulamak için, [Metin Arama ve Değiştirme](/slides/tr/nodejs-java/search-and-replace-text/) adresine bakın.

## **Metin Arka Plan Rengini Ayarla**

Bir paragraf için varsayılan vurgulama rengini ayarlamak için [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) kullanın veya bireysel metin bölümleri için [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor--) kullanın.

Aşağıdaki örnek, ilk paragraf için varsayılan olarak açık gri bir vurgulama ayarlar. Bireysel bölümlerdeki açık vurgulama renkleri bu varsayılanın üzerine yazar:

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

Aşağıdaki kod örneği, **kalın yazı tipine sahip metin bölümleri** için arka plan renginin nasıl ayarlanacağını gösterir:

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

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) kullanarak bir metin çerçevesi içinde paragraf hizalamasını ayarlayın. Değer merkezlenmiş, sola hizalı, sağa hizalı, iki yana yaslanmış vb. olabilir.

Aşağıdaki kod örneği paragrafı **ortaya** hizalamanın yolunu gösterir:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Paragrafın hizalamasını ortaya ayarla.
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Hizalanmış paragraf](aligned_paragraph.png)

## **Satır İçinde Yazı Tiplerini Hizala**

[ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setFontAlignment-int-) kullanarak aynı satır içinde farklı yazı tipi boyutlarına sahip metin bölümlerini dikey olarak hizalayın. Bu ayar tüm paragrafı kapsar ve satırların içindeki hizalamayı kontrol eder.

Aşağıdaki bağımsız örnek, bir slaytta dört etiketli metin kutusu oluşturur. Her paragraf aynı metni 18, 36 ve 54 puan boyutlarında içerir ve farklı bir yazı tipi hizalaması kullanır. Arial kullanır, otomatik sığdırma ve satır sonu kaydırmayı devre dışı bırakır ve metin çerçevelerini tek satır için yeterince büyük tutar:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const alignments = [aspose.slides.FontAlignment.Baseline, aspose.slides.FontAlignment.Top, aspose.slides.FontAlignment.Center, aspose.slides.FontAlignment.Bottom];
    const alignmentNames = ["Baseline", "Top", "Center", "Bottom"];
    const fontSizes = [18, 36, 54];

    for (let i = 0; i < alignments.length; i++) {
        const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const textFrame = shape.getTextFrame();
        textFrame.getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Top));
        textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
        textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.False));

        const label = textFrame.getParagraphs().get_Item(0);
        label.setText(alignmentNames[i]);
        label.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new aspose.slides.FontData("Arial"));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

        const paragraph = new aspose.slides.Paragraph();
        paragraph.getParagraphFormat().setFontAlignment(alignments[i]);
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new aspose.slides.FontData("Arial"));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        for (const fontSize of fontSizes) {
            const portion = new aspose.slides.Portion("Ag ");
            portion.getPortionFormat().setFontHeight(fontSize);
            paragraph.getPortions().add(portion);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    presentation.save("font_alignment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Karışık yazı tipi boyutlarıyla Alt Çizgi, Üst, Orta ve Alt hizalama karşılaştırması](font_alignment.png)

Yazı tipi hizalaması, font metriklerini kullandığından, bireysel harflerin görünür kenarları mutlaka tam olarak hizalanmayabilir. Örnek, alt çizgi ile alt hizalama arasındaki farkı göstermek için hem büyük harf hem bir alt karakter içerir. Font bulunabilirliği ve yerine koyma, kullanılan karakterler ve font boyutları arasındaki fark sonuçları etkiler. Çerçeve boyutları, kenar boşlukları, satır aralığı, kaydırma ve otomatik sığdırma da düzeni etkiler; modları karşılaştırırken aynı fontları ve düzen ayarlarını kullanın.

Bu ayar, yatay paragraf hizalamasını kontrol eden [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) ve metin bloğunu şeklin içinde dikey konumlandıran [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) metodlarından farklıdır. [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setEscapement-float-) ile üst ve alt indis formatı, alt satır temelini değiştirerek bireysel bölümleri kaydırır; paragraf satırları için font hizalaması ayarlamaz.

## **Metin İçin Şeffaflığı Ayarla**

Metin şeffaflığı, [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--) üzerinden atanan rengin alfa bileşeni ile kontrol edilir. Aşağıdaki örneklerde `alpha = 50` 0–255 ölçeğinde bir ARGB alfa kanal değeri olup, şeffaflık yüzdesi değildir.

Aşağıdaki kod örneği, **tüm paragraf** için şeffaflığın nasıl uygulanacağını gösterir:

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

Aşağıdaki kod örneği, **kalın yazı tipine sahip metin bölümleri** için şeffaflığın nasıl uygulanacağını gösterir:

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

[BasePortionFormat.setSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) kullanarak bir metin kutusunda karakterler arasındaki aralığı genişletebilir veya daraltabilirsiniz. Örneklerde 3 puan aralık eklenir; negatif değerler metni sıkıştırır.

Aşağıdaki JavaScript kodu, **tüm paragraf** içinde karakter aralığını nasıl genişleteceğini gösterir:

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

Aşağıdaki kod örneği, **kalın yazı tipine sahip metin bölümleri** içinde karakter aralığını nasıl genişleteceğini gösterir:

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

Bazen Aspose.Slides tarafından oluşturulan metin, aynı metnin PowerPoint’teki görünümünden biraz daha sıkı görünebilir. Bu, PowerPoint’in belirli fontlar için kerning verilerini göz ardı etmesinden kaynaklanabilir; font geçerli kerning bilgisi içerse ve PowerPoint ayarlarında kerning açıksa bile.

Bu durumda çıktıyı PowerPoint’e daha yakın hâle getirmek için, ilgili fontu kullanan metin bölümlerinin kerning’ini devre dışı bırakabilirsiniz. [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) değerini gerçek font boyutundan daha büyük bir değere ayarlayın. Bu örnek, ilk slayttaki ilk şekil olarak bir metin kutusu içeren "presentation.pptx" gerektirir. Etkili font adlarını, kalıtılan fontlar dahil, kontrol eder ve Roboto kullanan bölümler için 100 puan eşik değeri ayarlar. Bu, 100 puan altındaki font boyutuna sahip eşleşen bölümler için kerning’i devre dışı bırakır:

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

Eşiğin altında kalan eşleşen metinler için bu ayar kerning’i önler ve PowerPoint’in bu spesifik davranıştan etkilenen fontlarda görsel çıktısını Aspose.Slides render’ı ile uyumlu hâle getirmeye yardımcı olur.

## **Metin Yazı Tipi Özelliklerini Yönet**

Yazı tipi özellikleri, paragraf düzeyinde [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) ile veya bireysel bölümlerde [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) ile ayarlanabilir.

Aşağıdaki örnek, ilk paragrafın varsayılan fontunu 12 puan Times New Roman, kalın, italik ve noktalı altı çizili olarak ayarlar. Bireysel bölümlerdeki açık biçimlendirme bu varsayılanların üzerine yazar:

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

Aşağıdaki örnek, etkili biçimlendirmesi kalın olan bölümlere 13 puan Times New Roman, italik ve noktalı altı çizili uygular:

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

[TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) kullanarak bir şekil içinde önceden tanımlanmış bir metin yönelimi ayarlayın.

Aşağıdaki kod örneği, şeklin içindeki metin yönelimini [TextVerticalType.Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textverticaltype/) olarak ayarlar; bu, metni **90 derece saat yönünün tersine** döndürür:

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

[TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) kullanarak bir [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) için özel bir döndürme açısı belirleyin.

Aşağıdaki kod örneği, şekil içinde metin çerçevesini 3 derece saat yönünde döndürür:

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

Aspose.Slides, paragraf aralığını kontrol etmek için [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-) ve [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) sağlar. Bu özellikler şu şekilde kullanılır:

* Pozitif bir değer kullanarak satır aralığını satır yüksekliğinin yüzdesi olarak belirtin.
* Negatif bir değer kullanarak satır aralığını puan cinsinden belirtin.

Aşağıdaki örnek, ilk paragraftaki aralığı satır yüksekliğinin %200’ü (çift satır aralığı) olarak ayarlar:

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

## **Satır Kesilmeyi Kontrol Et**

Paragraf satır kesme kuralları, dar metin blokları ve Latin ile Doğu Asya metinlerinin karıştığı sunumlar için yararlıdır. Aşağıdaki yöntemler [ParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/) sınıfına aittir ve bu yüzden tüm paragraf için geçerlidir:

- [setLatinLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setLatinLineBreak-byte-) Latin satır kesme kurallarını kontrol eder. Karışık metinlerde bunu değiştirmek, Doğu Asya metin ve noktalama işaretlerinin kaydırma yerini de etkileyebilir.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setEastAsianLineBreak-byte-) Doğu Asya satır kesme kurallarını kontrol eder; satır başı ve sonundaki karakter kısıtlamalarını içerir.

Bu kurallar, bir metin çerçevesi içinde otomatik kaydırmayı etkinleştiren [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setWrapText-byte-) metodunun yerini almaz. Kaydırma gerçekleştiğinde düzeni etkiler; satır sonu karakteri eklemezler. Açık bir satır sonu, mevcut genişlikten bağımsız olarak paragrafta yeni bir satır zorlar.

Aşağıdaki bağımsız örnek, Çince ve Latin metin içeren dar bir metin bloğu oluşturur. Her iki satır kesme seçeneğini açıkça ayarlar ve “line_breaking.pptx” olarak kaydeder. Her kuralı denemek için, diğer ayarları sabit tutarken ilgili değeri değiştirin. Örnekte 24 puan Arial ve SimSun, 160 puan çerçeve genişliği ve yatay kenar boşluğu sıfır olarak kullanılır. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) metodu, [TextAutofitType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textautofittype/) ile çağrılır; böylece metin boyutu ve çerçeve boyutları sabit kalır.

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

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setHangingPunctuation-byte-) uygun noktalama işaretlerinin metin satırının sağ kenarının ötesine uzanmasına izin verir; bir sonraki satırı işgal etmez. Bu, tüm paragraf için geçerlidir ve asılı girintiden farklıdır.

Aşağıdaki bağımsız örnek, 100 puan genişliğinde bir metin çerçevesinde asılı noktalama işaretlerini etkinleştirir ve “hanging_punctuation.pptx” olarak kaydeder. 24 puan Arial ve yatay kenar boşluğu sıfır ile, son nokta “sentence” kelimesinden sonra kalır ve sağ kenarın ötesine uzanır. Karşılaştırma için özelliği [NullableBool.False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) olarak ayarlayın; bu ayarlarla nokta ayrı bir satırda yer alır. Kaydırma etkin ve otomatik sığdırma devre dışı bırakılmıştır; böylece kullanılabilir genişlik sabit kalır.

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

Her noktalama işareti asılı olamaz. Yukarıda açıklanan [font ve düzen koşulları](#control-line-breaking) da bu karşılaştırmaya uygulanır; font, kullanılabilir genişlik, kenar boşlukları veya otomatik sığdırma ayarlarını değiştirerek görünür farkı ortadan kaldırabilirsiniz.

## **Metin Çerçeveleri İçin Otomatik Sığdırma Tipini Ayarla**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) bir metin kapsayıcısının sınırlarını aştığında metnin nasıl davranacağını belirler. Metnin küçülmesini, taşmasını veya şeklin otomatik olarak yeniden boyutlandırılmasını kontrol etmek için kullanın. Aşağıdaki örnek, şekli metnine göre yeniden boyutlandıracak şekilde yapılandırır ve sonucu “autofit_type.pptx” olarak kaydeder.

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

Otomatik kaydırma sonrası satırları saymak ve metin ya da şekil genişliğinin sonucu nasıl değiştirdiğini görmek için [Count Rendered Lines](/slides/tr/nodejs-java/manage-paragraph/) sayfasına bakın. Sadece satır sayısı, metnin kapsayıcısını aşıp aşmadığını göstermez.

## **Metin Çerçevelerinin Sabitlemesini Ayarla**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) bir şekil içinde metnin dikey konumunu tanımlar; örneğin üst, orta veya alt. Aşağıdaki örnek, metni ilk şeklin altına sabitler ve sonucu “text_anchor.pptx” olarak kaydeder.

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

## **Metin Sekmesini Ayarla**

[ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) ve [ParagraphFormat.getTabs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getTabs--) kullanarak bir paragrafta sek duraklarını yapılandırın. Aşağıdaki örnek, varsayılan sek aralığını 100 puan olarak ayarlar ve 30 puanda sol hizalı bir sek durak ekler. Bu ayarlar sek karakteri içeren metni etkiler.

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

## **Denetleme Dilini Ayarla**

Aspose.Slides, bir metin bölümünün denetleme dilini ayarlamanızı sağlayan [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) metodunu sunar. Denetleme dili, PowerPoint’te yazım ve dil bilgisi denetimi için kullanılan dili belirler.

Aşağıdaki örnek, ilk slayttaki ilk şekil olarak bir metin kutusu içeren “presentation.pptx” dosyasını gerektirir. İlk paragrafın içeriğini “1。” ile değiştirir, fontunu SimSun olarak ayarlar ve basitleştirilmiş Çince denetleme dilini (`zh-CN`) atar. Sonucu “proofing_language.pptx” olarak kaydeder:

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

    // Denetleme dilinin kimliğini ayarla.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Varsayılan Dili Ayarla**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) kullanarak bir sunum yüklenirken veya oluşturulurken oluşturulan metnin varsayılan dilini tanımlayın. Aşağıdaki örnek, varsayılan metin dili olarak ABD İngilizcesi kullanan bir sunum oluşturur, bir metin kutusu ekler ve ilk metin bölümü için `en-US` yazar.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // Metin içeren yeni bir dikdörtgen şekli ekle.
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // İlk bölüm dilini kontrol et.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Varsayılan Metin Stili Ayarla**

Sunum düzeyinde varsayılan metin biçimlendirmesini uygulamak için [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--) metodunu kullanın.

Aşağıdaki örnek, yeni bir sunumda üst düzey paragraflar için varsayılan olarak 14 puan kalın bir font ayarlar ve “default_text_style.pptx” olarak kaydeder. Metin, daha spesifik bir biçimlendirme üzerine yazılmadıkça bu varsayılanları miras alabilir.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    // Üst düzey paragraf biçimini al.
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

## **All-Caps Etkisiyle Metni Çıkar**

PowerPoint’te **All Caps** font etkisini uygulamak, metnin slaytta büyük harf olarak görünmesini sağlar; metin düşük harf olarak girilmiş olsa bile. Aspose.Slides ile böyle bir metin bölümü alındığında, kütüphane metni tam olarak girildiği gibi döndürür. Görünen metni eşleştirmek için [TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/) kontrol edin ve değer `All` ise döndürülen dizeyi büyük harfe çevirin.

Bu örnek, ilk slayttaki ilk şekil olarak bir metin kutusu içeren “sample2.pptx” dosyasını gerektirir. İlk paragrafın ilk bölümü, aşağıda gösterildiği gibi All Caps etkisi uygulanmış “Hello, Aspose!” içerir.

![All Caps etkisi](all_caps_effect.png)

Aşağıdaki kod örneği, **All Caps** etkisi uygulanmış şekilde metni nasıl çıkaracağınızı gösterir:

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

**Bir slayttaki tablo içindeki metni nasıl değiştiririm?**

Bir slayttaki tablo içinde metni değiştirmek için [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) kullanın. Hücreleri gezin ve her hücreyi [Cell.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame--) ile güncelleyin; paragraf biçimlendirmesini ise [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--) ile ayarlayın.

**PowerPoint slaytındaki metne nasıl bir degrade renk uygularım?**

Metne degrade renk uygulamak için [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--) kullanın. [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) değerini [FillType.Gradient](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) olarak ayarlayın ve degrade duraklarını, yönünü ve şeffaflığını yapılandırın.