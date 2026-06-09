---
title: Android'de Sunum Metnini Biçimlendirme
linktitle: Metin Biçimlendirme
type: docs
weight: 50
url: /tr/androidjava/text-formatting/
keywords:
- metni vurgulama
- düzenli ifade
- paragraf hizalama
- metin stili
- metin arka planı
- metin şeffaflığı
- karakter aralığı
- yazı tipi özellikleri
- yazı tipi ailesi
- metin döndürme
- döndürme açısı
- metin çerçevesi
- satır aralığı
- otomatik sığdırma özelliği
- metin çerçevesi bağlantı noktası
- metin sekleme
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'i Java aracılığıyla kullanarak PowerPoint ve OpenDocument sunumlarında metni biçimlendirin ve stil verin. Yazı tiplerini, renkleri, hizalamayı ve daha fazlasını özelleştirin."
---
## **Genel Bakış**

Bu makale, Java üzerinden Aspose.Slides for Android kullanarak PowerPoint ve OpenDocument sunumlarında metni nasıl biçimlendireceğinizi gösterir. Vurgulama, arka plan renkleri, şeffaflık, karakter aralığı, yazı tipi özellikleri, döndürme, paragraf aralığı, otomatik sığdırma davranışı, metin bağlama, sek durakları ve dil ayarları gibi konuları kapsar.

Aşağıdaki örneklerde, ilk slaytta aşağıdaki metni içeren tek bir metin kutusu bulunan "sample.pptx" adlı bir dosya kullanacağız:

![Örnek metin](sample_text.png)

## **Metni Vurgulama**

Bir metin çerçevesi içinde belirli bir örnekle eşleşen metni vurgulamanız gerektiğinde [ITextFrame.highlightText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.lang.Integer-) metodunu kullanın. Metod, eşleşen metin parçalarına vurgulama rengi uygular ve aramanın nasıl gerçekleştirileceğini kontrol etmek için, örneğin yalnızca tam kelimeleri eşleştirmek gibi, [ITextSearchOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ITextSearchOptions) ile kullanılabilir.

Aşağıdaki kod örneği, **"try"** karakterlerinin tüm görünümlerini vurgular ve ardından yalnızca tam kelime **"to"**'yu vurgular.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // İlk slayttan ilk şekli al.
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Şekilde "try" kelimesini vurgula.
    shape.getTextFrame().highlightText("try", Color.rgb(173, 216, 230));

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // Şekilde "to" kelimesini vurgula.
    int violetColor = Color.rgb(238, 130, 238);
    shape.getTextFrame().highlightText("to", violetColor, searchOptions, null);

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Vurgulanan metin](highlighted_text.png)

## **Düzenli İfadeler Kullanarak Metni Vurgulama**

[ITextFrame.highlightRegex](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ITextFrame#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) metodu, bir düzenli ifade tarafından bulunan metin eşleşmelerini vurgular.

Aşağıdaki kod örneği, **yedi veya daha fazla karakter içeren** tüm kelimeleri vurgular:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    java.util.regex.Pattern regex = java.util.regex.Pattern.compile("\\b[^\\s]{7,}\\b");

    // Yedi veya daha fazla karakter içeren tüm kelimeleri vurgula.
    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, null);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Düzenli ifade kullanarak vurgulanan metin](highlighted_text_using_regex.png)

## **Metin Arka Plan Rengini Ayarlama**

[İParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IParagraphFormat#getDefaultPortionFormat--) metodunu bir paragraf için varsayılan vurgulama rengini ayarlamak için, veya tek tek metin bölümleri için [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IBasePortionFormat#getHighlightColor--) metodunu kullanın.

İşte aşağıdaki kod örneği, **tüm paragraf** için arka plan rengini nasıl ayarlayacağınızı gösterir:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Paragrafın tamamı için vurgulama rengini ayarla.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Gri paragraf](gray_paragraph.png)

Aşağıdaki kod örneği, **kalın bir yazı tipine sahip metin bölümleri** için arka plan rengini nasıl ayarlayacağınızı gösterir:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Metin bölümü için vurgulama rengini ayarla.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LTGRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Gri metin bölümleri](gray_text_portions.png)

## **Metin Paragraflarını Hizalama**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IParagraphFormat#setAlignment-byte-) metodunu bir metin çerçevesi içinde paragraf hizalamasını ayarlamak için kullanın. Değerler ortalanmış, sola hizalı, sağa hizalı, iki yana yaslanmış vb. olabilir.

Aşağıdaki kod örneği, paragrafı **ortaya** hizalamanın nasıl yapılacağını gösterir:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Paragrafın hizalamasını ortaya ayarla.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Hizalanmış paragraf](aligned_paragraph.png)

## **Metin Şeffaflığını Ayarlama**

Metin şeffaflığı, [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--) metoduna atanan rengin alfa bileşeni aracılığıyla kontrol edilir. Aşağıdaki örneklerde `alpha = 50`, % 0-255 ölçeğinde bir ARGB alfa kanalı değeridir, yüzde şeffaflık değildir.

Aşağıdaki kod örneği, **tüm paragraf** için şeffaflığın nasıl uygulanacağını gösterir:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Metnin dolgu rengini şeffaf renge ayarla.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Şeffaf paragraf](transparent_paragraph.png)

Aşağıdaki kod örneği, **kalın bir yazı tipine sahip metin bölümleri** için şeffaflığın nasıl uygulanacağını gösterir:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Metin bölümünün şeffaflığını ayarla.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Şeffaf metin bölümleri](transparent_text_portions.png)

## **Metin Karakter Aralığını Ayarlama**

[IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IBasePortionFormat#setSpacing-float-) metodunu bir metin kutusundaki karakterler arasındaki boşluğu genişletmek veya daraltmak için kullanın.

Aşağıdaki Java kodu, **tüm paragrafta** karakter aralığını nasıl genişleteceğinizi gösterir:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Not: Karakter aralığını sıkıştırmak için negatif değerleri kullanın.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Karakter aralığını genişlet.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Paragraftaki karakter aralığı](character_spacing_in_paragraph.png)

Aşağıdaki kod örneği, **kalın bir yazı tipine sahip metin bölümlerinde** karakter aralığını nasıl genişleteceğinizi gösterir:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Not: Karakter aralığını sıkıştırmak için negatif değerleri kullanın.
            portion.getPortionFormat().setSpacing(3); // Karakter aralığını genişlet.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Metin bölümlerindeki karakter aralığı](character_spacing_in_text_portions.png)

### **Belirli Yazı Tipleri İçin Kerning'i Devre Dışı Bırakma**

Bazı durumlarda, Aspose.Slides tarafından renderlanan metin, PowerPoint'te gösterilen aynı metinden biraz daha sık görünebilir. Bu, PowerPoint'in belirli yazı tipleri için kerning verilerini görmezden gelmesi durumunda gerçekleşebilir; hatta yazı tipi geçerli kerning bilgileri içeriyor ve PowerPoint ayarlarında kerning etkin olsa bile.

Bu gibi durumlarda renderlenen çıktıyı PowerPoint'e daha yakın hâle getirmek için, etkilenen yazı tipini kullanan metin bölümleri için kerning'i devre dışı bırakabilirsiniz. [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IBasePortionFormat#setKerningMinimalSize-float-) değerini gerçek yazı tipi boyutundan önemli ölçüde daha büyük bir değere ayarlayın:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (int paragraphIndex = 0; paragraphIndex < autoShape.getTextFrame().getParagraphs().getCount(); paragraphIndex++) {
        IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

        for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            IFontData latinFont = portion.getPortionFormat().getLatinFont();
            IFontData eastAsianFont = portion.getPortionFormat().getEastAsianFont();
            IFontData complexScriptFont = portion.getPortionFormat().getComplexScriptFont();

            boolean usesTargetFont =
                    latinFont != null && targetFont.equals(latinFont.getFontName()) ||
                    eastAsianFont != null && targetFont.equals(eastAsianFont.getFontName()) ||
                    complexScriptFont != null && targetFont.equals(complexScriptFont.getFontName());

            if (usesTargetFont) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bu ayar, eşleşen metin bölümlerine kerning uygulanmasını önler ve bu PowerPoint'e özgü davranıştan etkilenen yazı tipleri için Aspose.Slides render'ını PowerPoint'in görsel çıktısıyla hizalamaya yardımcı olabilir.

## **Metin Yazı Tipi Özelliklerini Yönetme**

Yazı tipi özellikleri, [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IParagraphFormat#getDefaultPortionFormat--) aracılığıyla paragraf düzeyinde veya tek tek bölümler için [IPortionFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPortionFormat) aracılığıyla ayarlanabilir.

Aşağıdaki kod, tüm paragraf için yazı tipi ve metin stilini ayarlar: yazı tipi boyutu, kalın, italik, noktalı alt çizgi ve Times New Roman yazı tipini paragraftaki tüm bölümlere uygular.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Paragraf için yazı tipi özelliklerini ayarla.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Paragraf için yazı tipi özellikleri](font_properties_for_paragraph.png)

Aşağıdaki kod örneği, **kalın bir yazı tipine sahip metin bölümlerine** benzer özellikler uygular:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Metin bölümü için yazı tipi özelliklerini ayarla.
            portion.getPortionFormat().setFontHeight(13);
            portion.getPortionFormat().setFontItalic(NullableBool.True);
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
            portion.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Metin bölümleri için yazı tipi özellikleri](font_properties_for_text_portions.png)

## **Metin Döndürmeyi Ayarlama**

[ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-) metodunu bir şekil içinde önceden tanımlı bir metin yönelimi ayarlamak için kullanın.

Aşağıdaki kod örneği, şeklin içindeki metin yönelimini `Vertical270` olarak ayarlar; bu, metni **90 derece saat yönünün tersine** döndürür:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Metin döndürmesi](text_rotation.png)

## **Metin Çerçeveleri İçin Özel Döndürmeyi Ayarlama**

[ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) metodunu bir [ITextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ITextFrame) için özel bir döndürme açısı ayarlamak için kullanın.

Aşağıdaki kod örneği, şekil içinde metin çerçevesini 3 derece saat yönünde döndürür:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Özel metin döndürmesi](custom_text_rotation.png)

## **Paragrafların Satır Aralığını Ayarlama**

Aspose.Slides, paragraf aralığını kontrol etmek için [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IParagraphFormat#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IParagraphFormat#setSpaceBefore-float-), ve [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IParagraphFormat#setSpaceWithin-float-) metodlarını sağlar. Bu özellikler aşağıdaki gibi kullanılır:

* Satır yüksekliğinin yüzde olarak satır aralığını belirtmek için pozitif bir değer kullanın.
* Satır aralığını puan (point) cinsinden belirtmek için negatif bir değer kullanın.

Aşağıdaki kod örneği, paragraftaki satır aralığını nasıl belirteceğinizi gösterir:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Paragraftaki satır aralığı](line_spacing.png)

## **Metin Çerçeveleri İçin Otomatik Sığdırma Tipini Ayarlama**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) metnin, kapsayıcısının sınırlarını aştığında nasıl davranacağını belirler. Metnin küçülüp küçülmeyeceğini, taşacak mı yoksa şekli otomatik olarak yeniden boyutlandırıp boyutlandırmayacağını kontrol etmek için kullanın.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Metin Çerçevelerinin Bağlantı Noktasını Ayarlama**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) bir şekil içinde metnin dikey olarak nasıl konumlandırılacağını tanımlar; örneğin üstte, ortada veya altta.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Metin Sekme Ayarlarını Yapma**

Bir paragrafta sek duraklarını yapılandırmak için [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IParagraphFormat#setDefaultTabSize-float-) ve [IParagraphFormat.getTabs](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IParagraphFormat#getTabs--) metodlarını kullanın.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left);

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Paragraf sekmeleri](paragraph_tabs.png)

## **Denetleme Dilini Ayarlama**

Aspose.Slides, bir metin bölümü için denetleme dilini ayarlamanızı sağlayan [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) metodunu sağlar. Denetleme dili, PowerPoint'te yazım ve dil bilgisi denetimlerinde kullanılan dili belirler.

Aşağıdaki kod örneği, bir metin bölümü için denetleme dilinin nasıl ayarlanacağını gösterir:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Denetleme dilinin kimliğini ayarla.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Varsayılan Dili Ayarlama**

Bir sunum yüklenirken veya oluşturulurken üretilen metin için varsayılan dili tanımlamak üzere [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/LoadOptions#setDefaultTextLanguage-java.lang.String-) metodunu kullanın.

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Yeni bir dikdörtgen şekil ekleyip içine metin ekle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // İlk bölümün dilini kontrol et.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Varsayılan Metin Stilini Ayarlama**

Sunum düzeyinde varsayılan metin biçimlendirmesi uygulamak için [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPresentation#getDefaultTextStyle--) metodunu kullanın.

Aşağıdaki kod örneği, yeni bir sunumda tüm slaytlardaki metin için 14 pt boyutunda varsayılan kalın bir yazı tipi nasıl ayarlanacağını gösterir:

```java
Presentation presentation = new Presentation();
try {
    // Üst seviye paragraf biçimini al.
    IParagraphFormat paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(NullableBool.True);
    }

    presentation.save("default_text_style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tüm Büyük Harf Efektiyle Metni Çıkarma**

PowerPoint'te **All Caps** (Tam Büyük Harf) yazı tipi etkisini uyguladığınızda, metin orijinal olarak küçük harfle yazılmış olsa bile slaytta büyük harfle görüntülenir. Aspose.Slides ile böyle bir metin bölümü aldığınızda, kütüphane metni tam olarak girildiği gibi döndürür. Görüntülenen metinle eşleşmesi için, [TextCapType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/TextCapType) kontrol edin ve değer `All` olduğunda döndürülen dizeyi büyük harfe çevirin.

Örneğin, sample2.pptx dosyasının ilk slaydında aşağıdaki metin kutusunun olduğunu düşünelim.

![All Caps efekti](all_caps_effect.png)

Aşağıdaki kod örneği, **All Caps** etkisi uygulanmış metni nasıl çıkaracağınızı gösterir:

```java
Presentation presentation = new Presentation("sample2.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortion textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    System.out.println("Original text: " + textPortion.getText());

    IPortionFormatEffectiveData textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == TextCapType.All) {
        String text = textPortion.getText().toUpperCase();
        System.out.println("All-Caps effect: " + text);
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

**Bir slayttaki tabloda metni nasıl değiştirebilirim?**

Bir slayttaki tabloda metni değiştirmek için [ITable](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ITable) kullanın. Hücreler üzerinde döngü yaparak her hücreyi [ICell.getTextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICell#getTextFrame--) aracılığıyla güncelleyin ve paragraf biçimlendirmesini [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IParagraph#getParagraphFormat--) ile ayarlayın.

**PowerPoint slaydındaki metne nasıl degrade (gradient) renk uygulayabilirim?**

Metne degrade renk uygulamak için [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--) metodunu kullanın. [IFillFormat.setFillType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IFillFormat#setFillType-int-) metodunu [FillType.Gradient](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FillType) olarak ayarlayın ve degrade duraklarını, yönünü ve şeffaflığını yapılandırın.