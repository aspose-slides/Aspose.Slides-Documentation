---
title: Android'de Sunum Metnini Biçimlendir
linktitle: Metin Biçimlendirme
type: docs
weight: 50
url: /tr/androidjava/text-formatting/
keywords:
- paragraf hizala
- metin stili
- metin arka planı
- metin şeffaflığı
- karakter aralığı
- yazı tipi özellikleri
- yazı tipi ailesi
- metin dönüşü
- dönme açısı
- metin çerçevesi
- satır aralığı
- otomatik sığdırma özelliği
- metin çerçevesi sabitlemesi
- metin sekmesi
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java kullanarak PowerPoint ve OpenDocument sunumlarında metni biçimlendirin ve stil verin. Yazı tiplerini, renkleri, hizalamayı ve daha fazlasını özelleştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Android via Java kullanarak PowerPoint ve OpenDocument sunumlarında metni nasıl biçimlendireceğinizi gösterir. Arka plan renkleri, şeffaflık, karakter aralığı, yazı tipi özellikleri, dönüş, paragraf aralığı, otomatik sığdırma davranışı, metin sabitleme, sekme durakları ve dil ayarlarını kapsar.

Aksi belirtilmedikçe, örnekler [sample.pptx](sample.pptx) dosyasını kullanır. İlk slaytındaki ilk şekil bir metin kutusudur ve ilk paragrafı aşağıda gösterilen metni içerir. Slayt ve şekil indeksleri sıfır‑tabanlıdır. Kalın bölümleri seçen örnekler, kalıtılmış kalın biçimlendirme dahil, etkili biçimlendirmeyi kullanır:

![Örnek metin](sample_text.png)

Gerçekteki metni veya düzenli ifade eşleşmelerini bulmak ve vurgulamak için [Search and Replace Text](/slides/tr/androidjava/search-and-replace-text/) bölümüne bakın.

## **Metin Arka Plan Rengini Ayarla**

[IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) metodunu kullanarak bir paragraf için varsayılan vurgulama rengini ayarlayabilir veya [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) metodunu kullanarak tek tek metin bölümleri için vurgulama rengini ayarlayabilirsiniz.

Aşağıdaki örnek, ilk paragraf için varsayılan olarak açık gri bir vurgulama ayarlar. Tek tek bölümlerde belirtilen vurgulama renkleri bu varsayılanın üzerine yazar:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Tüm paragraf için vurgulama rengini ayarla.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Gri paragraf](gray_paragraph.png)

Aşağıdaki kod örneği, **kalın bir yazı tipine sahip metin bölümleri** için arka plan renginin nasıl ayarlanacağını gösterir:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
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

Sonuç:

![Gri metin bölümleri](gray_text_portions.png)

## **Metin Paragraflarını Hizala**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) metodunu kullanarak bir metin çerçevesindeki paragraf hizalamasını ayarlayabilirsiniz. Değer, ortalanmış, sola hizalanmış, sağa hizalanmış, iki yana yaslanmış vb. olabilir.

Aşağıdaki kod örneği, paragrafı **ortaya** hizalamayı gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Paragrafın hizalamasını ortaya ayarla.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Hizalanmış paragraf](aligned_paragraph.png)

## **Metin Şeffaflığını Ayarla**

Metin şeffaflığı, [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) metoduna atanan rengin alfa bileşeni üzerinden kontrol edilir. Aşağıdaki örneklerde `alpha = 50`, 0‑255 aralığında bir ARGB alfa kanalı değeridir, yüzde şeffaflık değildir.

Aşağıdaki kod örneği, **tüm paragraf** için şeffaflık uygulamayı gösterir:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Metnin dolgu rengini şeffaf renge ayarla.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Şeffaf paragraf](transparent_paragraph.png)

Aşağıdaki kod örneği, **kalın bir yazı tipine sahip metin bölümleri** için şeffaflık uygulamayı gösterir:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
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

Sonuç:

![Şeffaf metin bölümleri](transparent_text_portions.png)

## **Metin Karakter Aralığını Ayarla**

[IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) metodunu kullanarak bir metin kutusundaki karakterler arasındaki aralığı genişletebilir veya daraltabilirsiniz. Örnekler 3 puanluk boşluk ekler; negatif değerler metni sıkıştırır.

Aşağıdaki Java kodu, **tüm paragraf** için karakter aralığını nasıl genişleteceğini gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Not: Karakter aralığını sıkıştırmak için negatif değerler kullanın.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Karakter aralığını genişlet.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Paragraftaki karakter aralığı](character_spacing_in_paragraph.png)

Aşağıdaki kod örneği, **kalın bir yazı tipine sahip metin bölümleri** için karakter aralığını nasıl genişleteceğini gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Not: Karakter aralığını sıkıştırmak için negatif değerler kullanın.
            portion.getPortionFormat().setSpacing(3); // Karakter aralığını genişlet.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Metin bölümlerindeki karakter aralığı](character_spacing_in_text_portions.png)

### **Belirli Yazı Tipleri İçin Kerning'i Devre Dışı Bırak**

Bazı durumlarda, Aspose.Slides tarafından oluşturulan metin, PowerPoint'te aynı metinden biraz daha sık görünebilir. Bu, PowerPoint'in bazı yazı tipleri için kerning verisini görmezden gelmesi durumunda gerçekleşir; yazı tipinde geçerli kerning bilgisi olsa bile ve PowerPoint ayarlarında kerning etkin olsa bile.

Bu durumlarda, etkilenen yazı tipini kullanan metin bölümleri için kerning'i devre dışı bırakarak çıktıyı PowerPoint'e daha yakın hâle getirebilirsiniz. [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) değerini gerçek yazı tipi boyutundan büyük bir değere ayarlayın. Bu örnek, ilk slaydın ilk şekli olarak bir metin kutusu içeren "presentation.pptx" dosyasını gerektirir. Etkili yazı tipi adlarını, kalıtılmış yazı tipleri dahil, kontrol eder ve Roboto kullanan bölümler için 100 puanlık bir eşik ayarlar. Bu, 100 puandan küçük boyutta kullanılan bölümler için kerning'i devre dışı bırakır:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormatEffectiveData portionFormat = portion.getPortionFormat().getEffective();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Eşik altındaki eşleşen metinler için bu ayar kerning'i önler ve bu PowerPoint'e özgü davranıştan etkilenen yazı tipleri için Aspose.Slides render çıktısını PowerPoint'in görsel çıktısına yaklaştırabilir.

## **Metin Yazı Tipi Özelliklerini Yönet**

Yazı tipi özellikleri, [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) üzerinden paragraf seviyesinde veya tek tek bölümler için [IPortionFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iportionformat/) üzerinden ayarlanabilir.

Aşağıdaki örnek, ilk paragrafın varsayılan yazı tipini 12 puan Times New Roman, kalın, italik ve noktalı alt çizgi biçimi ile ayarlar. Tek tek bölümlerde belirtilen biçimlendirme bu varsayılanların üzerine yazar:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

Sonuç:

![Paragraf için yazı tipi özellikleri](font_properties_for_paragraph.png)

Aşağıdaki örnek, etkili biçimlendirmesi kalın olan bölümlere 13 puan Times New Roman, italik ve noktalı alt çizgi uygular:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
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

Sonuç:

![Metin bölümleri için yazı tipi özellikleri](font_properties_for_text_portions.png)

## **Metin Döndürmeyi Ayarla**

[ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) metodunu kullanarak bir şekil içinde önceden tanımlı bir metin yönelimi ayarlayabilirsiniz.

Aşağıdaki kod örneği, şeklin içinde metin yönelimini [TextVerticalType.Vertical270](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textverticaltype/) olarak ayarlar; bu, metni **90 derece saat yönünün tersine** döndürür:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Metin döndürme](text_rotation.png)

## **Metin Çerçeveleri İçin Özel Döndürme Ayarla**

[ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) metodunu kullanarak bir [ITextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/) için özel bir döndürme açısı ayarlayabilirsiniz.

Aşağıdaki kod örneği, şekil içinde metin çerçevesini 3 derece saat yönünde döndürür:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Özel metin döndürme](custom_text_rotation.png)

## **Paragrafların Satır Aralığını Ayarla**

Aspose.Slides, paragraf aralığını kontrol etmek için [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) ve [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) metodlarını sunar. Bu özellikler şu şekilde kullanılır:

* Pozitif bir değer, satır aralığını satır yüksekliğinin yüzdesi olarak belirtir.
* Negatif bir değer, satır aralığını puan cinsinden belirtir.

Aşağıdaki örnek, ilk paragraftaki satır aralığını satır yüksekliğinin %200'ü (çift satır aralığı) olarak ayarlar:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Paragraftaki satır aralığı](line_spacing.png)

## **Satır Kesintisini Kontrol Et**

Paragraf satır kesintisi kuralları, dar metin blokları ve Latin ile Doğu Asya metinlerini karıştıran sunumlar için kullanışlıdır. Aşağıdaki yöntemler [IParagraphFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/) sınıfına aittir, dolayısıyla tüm paragraf için uygulanır:

- [setLatinLineBreak](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) Latin satır kesintisi kurallarını kontrol eder. Karışık metinlerde, bunu değiştirmek, Doğu Asya metni ve noktalama işaretlerinin nerede kayacağını da etkileyebilir.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) Doğu Asya satır kesintisi kurallarını kontrol eder; satırın başlangıcı ve sonundaki karakterlere yönelik kısıtlamaları içerir.

Bu kurallar, bir metin çerçevesi içinde otomatik sarmalamayı etkinleştiren [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) metodunun yerini almaz. Sarmalama gerçekleştiğinde yerleşimi etkiler; satır sonu karakterleri eklemezler. Açık bir satır sonu, mevcut genişliğe bakılmaksızın paragrafta yeni bir satır başlatır.

Aşağıdaki bağımsız örnek, Çince ve Latin metin içeren dar bir metin bloğu oluşturur. Her iki satır kesintisi seçeneğini de açıkça ayarlar ve "line_breaking.pptx" olarak kaydeder. Her iki kuralı denemek için, diğer ayarı sabit tutarak ilgili değeri değiştirin. Örnek, 24 puan Arial ve SimSun yazı tiplerini, 160 puan çerçeve genişliğini ve sıfır yatay metin çerçevesi kenar boşluğunu kullanır. [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) metodu, [TextAutofitType.None](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textautofittype/) ile çağrılır; böylece metin boyutu ve çerçeve boyutları sabit kalır.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    FontData eastAsianFont = new FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setLatinLineBreak(NullableBool.False);
    format.setEastAsianLineBreak(NullableBool.True);

    presentation.save("line_breaking.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Asılı Noktalama İşaretlerini Kontrol Et**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) uygun noktalama işaretlerinin metin satırının sağ kenarının ötesine uzanmasına izin verir; böylece bir sonraki satırı işgal etmez. Tüm paragraf için geçerlidir ve asılı girintiden farklıdır.

Aşağıdaki bağımsız örnek, 100 puan genişliğinde bir metin çerçevesinde asılı noktalama işaretlerini etkinleştirir ve "hanging_punctuation.pptx" olarak kaydeder. 24 puan Arial ve sıfır yatay metin çerçevesi kenar boşluğu kullanıldığında, son nokta "sentence" kelimesinin ardından kalır ve metin kenarının ötesine uzanır. Özelliği [NullableBool.False](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/nullablebool/) olarak ayarlayarak karşılaştırın: bu ayarlarda nokta ayrı bir satırda yer alır. Sarmalama etkin ve otomatik sığdırma devre dışı bırakılmıştır; böylece kullanılabilir genişlik sabit kalır.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setHangingPunctuation(NullableBool.True);

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Her noktalama işareti asılı olamaz. Görünür sonuç, yazı tipi bulunabilirliğine ve yerleşime bağlıdır; yazı tipini, kullanılabilir genişliği, kenar boşluklarını veya otomatik sığdırma ayarlarını değiştirerek görünür fark ortadan kalkabilir.

## **Metin Çerçeveleri İçin Otomatik Sığdırma Türünü Ayarla**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) metodu, metin kapsayıcısının sınırlarını aştığında metnin nasıl davranacağını belirler. Metnin küçülmesi, taşması veya şeklin otomatik olarak yeniden boyutlandırılması gibi davranışları kontrol etmek için kullanın. Aşağıdaki örnek, şeklin metnine göre yeniden boyutlandırılmasını yapılandırır ve sonucu "autofit_type.pptx" olarak kaydeder.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Otomatik sarmalamadan sonra satır sayısını ve metin ya da şekil genişliğinin sonucu nasıl etkilediğini görmek için [Count Rendered Lines](/slides/tr/androidjava/manage-paragraph/) bölümüne bakın. Satır sayısı yalnızca metnin kapsayıcısını aşması hakkında bilgi vermez.

## **Metin Çerçevelerinin Sabitlemesini Ayarla**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) metodu, metnin bir şekil içinde dikey olarak nasıl konumlandırılacağını tanımlar; örneğin en üst, ortada veya en altta. Aşağıdaki örnek, metni ilk şeklin altına sabitler ve sonucu "text_anchor.pptx" olarak kaydeder.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Metin Sekmelerini Ayarla**

[IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) ve [IParagraphFormat.getTabs](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) metodlarını kullanarak bir paragrafta sekme duraklarını yapılandırabilirsiniz. Aşağıdaki örnek, varsayılan sekme aralığını 100 puan olarak ayarlar ve 30 puanda sol hizalı bir sekme durakları ekler. Bu ayarlar sekme karakteri içeren metinleri etkiler.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left);

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Paragraf sekmeleri](paragraph_tabs.png)

## **Düzeltme Dilini Ayarla**

Aspose.Slides, bir metin bölümü için düzeltme dilini ayarlamanıza izin veren [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) metodunu sağlar. Düzeltme dili, PowerPoint'te imla ve dil bilgisi denetimlerinde kullanılan dili belirler.

Aşağıdaki örnek, ilk slaydın ilk şekli olarak bir metin kutusu içeren "presentation.pptx" dosyasını gerektirir ve en az bir paragraf içerir. İlk paragrafın içeriğini "1。" ile değiştirir, SimSun'u yazı tipi olarak ayarlar ve Basitleştirilmiş Çince düzeltme dili (`zh-CN`) atar. Sonucu "proofing_language.pptx" olarak kaydeder:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Düzeltme dilinin kimliğini ayarla.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Varsayılan Dili Ayarla**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) metodunu kullanarak bir sunum yüklenirken veya oluşturulurken oluşturulan metin için varsayılan dili tanımlayabilirsiniz. Aşağıdaki örnek, metin dili olarak ABD İngilizcesi (`en-US`) varsayılan olarak ayarlanmış bir sunum oluşturur, bir metin kutusu ekler ve ilk metin bölümünün dili olarak `en-US` yazdırır.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Metin içeren yeni bir dikdörtgen şekil ekle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // İlk bölümün dilini kontrol et.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Varsayılan Metin Stili Ayarla**

Sunum düzeyinde varsayılan metin biçimlendirmesini uygulamak için [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--) metodunu kullanın.

Aşağıdaki örnek, yeni bir sunumda üst‑seviye paragraflar için 14 puan kalın bir yazı tipini varsayılan olarak ayarlar ve "default_text_style.pptx" olarak kaydeder. Metin, daha spesifik bir biçimlendirme tarafından geçersiz kılınmadıkça bu varsayılanları devralabilir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Üst düzey paragraf formatını al.
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

## **Büyük Harf Etkisiyle Metin Çıkar**

PowerPoint'te **All Caps** (Tümü Büyük Harf) yazı tipi efekti, metnin slaytta büyük harf olarak görünmesini sağlar, ancak metin orijinal olarak küçük harfle girilmiştir. Aspose.Slides ile böyle bir metin bölümünü aldığınızda, kütüphane metni tam olarak girildiği gibi döndürür. Görüntülenen metne uymak için [TextCapType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textcaptype/) kontrol edin ve değer `All` olduğunda dönen dizeyi büyük harfe çevirin.

Bu örnek, ilk slaydın ilk şekli olarak bir metin kutusu içeren "sample2.pptx" dosyasını gerektirir. İlk paragrafın ilk bölümü "Hello, Aspose!" metnini **All Caps** efektiyle içerir, aşağıda gösterildiği gibi.

![All Caps efekti](all_caps_effect.png)

Aşağıdaki kod örneği, **All Caps** efekti uygulanmış metni nasıl çıkaracağınızı gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

**Bir slayttaki tablo içinde metni nasıl değiştiririm?**

Bir slayttaki tablo içindeki metni değiştirmek için [ITable](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itable/) kullanın. Hücreleri döngüye alarak her hücreyi [ICell.getTextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icell/#getTextFrame--) ve paragraf biçimlendirmesini [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) ile güncelleyin.

**Bir PowerPoint slaytında metne bir gradient (renk geçişi) nasıl uygulanır?**

Bir metne gradient renk uygulamak için [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) metod