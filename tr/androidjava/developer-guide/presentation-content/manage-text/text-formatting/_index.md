---
title: Android'de Sunum Metnini Biçimlendir
linktitle: Metin Biçimlendirme
type: docs
weight: 50
url: /tr/androidjava/text-formatting/
keywords:
- paragraf hizalama
- metin stili
- metin arka planı
- metin şeffaflığı
- karakter aralığı
- yazı tipi özellikleri
- yazı tipi ailesi
- metin dönüşü
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java kullanarak PowerPoint ve OpenDocument sunumlarında metni biçimlendirin ve stil verin. Yazı tiplerini, renkleri, hizalamayı ve daha fazlasını özelleştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Android via Java kullanarak PowerPoint ve OpenDocument sunumlarında metni nasıl biçimlendireceğinizi gösterir. Arka plan renkleri, şeffaflık, karakter aralığı, yazı tipi özellikleri, dönüş, paragraf aralığı, otomatik sığdırma davranışı, metin sabitleme, sek durakları ve dil ayarlarını kapsar.

Aşağıdaki örneklerde, ilk slaytta aşağıdaki metni içeren tek bir metin kutusu bulunan "sample.pptx" adlı bir dosya kullanacağız:

![Örnek metin](sample_text.png)

Literal metinleri veya düzenli ifade eşleşmelerini bulup vurgulamak için, [Metin Arama ve Değiştirme](/slides/tr/androidjava/search-and-replace-text/) sayfasına bakın.

## **Metin Arka Plan Rengini Ayarla**

Bir paragraf için varsayılan vurgulama rengini ayarlamak üzere [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) kullanın veya tek tek metin bölümleri için [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) kullanın.

Aşağıdaki kod örneği, **tüm paragraf** için arka plan renginin nasıl ayarlanacağını gösterir:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Paragrafın tamamı için vurgulama rengini ayarla.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Gri paragraf](gray_paragraph.png)

Aşağıdaki kod örneği, **kalın yazı tipine sahip metin bölümleri** için arka plan renginin nasıl ayarlanacağını gösterir:

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
            // Metin bölümünün vurgulama rengini ayarla.
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

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) kullanarak bir metin çerçevesi içinde paragraf hizalamasını ayarlayın. Değer, ortalanmış, sola hizalı, sağa hizalı, iki yana yaslanmış vb. olabilir.

Aşağıdaki kod örneği, paragrafı **ortaya** hizalamanın yolunu gösterir:

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

## **Metin İçin Şeffaflığı Ayarla**

Metin şeffaflığı, [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--)'a atanan rengin alfa bileşeni aracılığıyla kontrol edilir. Aşağıdaki örneklerde, `alpha = 50` 0–255 ölçeğinde bir ARGB alfa kanalı değeridir, şeffaflık yüzdesi değildir.

Aşağıdaki kod örneği, **tüm paragraf** için şeffaflığın nasıl uygulanacağını gösterir:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Metnin dolgu rengini şeffaf renk olarak ayarla.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Şeffaf paragraf](transparent_paragraph.png)

Aşağıdaki kod örneği, **kalın yazı tipine sahip metin bölümleri** için şeffaflığın nasıl uygulanacağını gösterir:

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

## **Metin İçin Karakter Aralığını Ayarla**

[IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) kullanarak bir metin kutusundaki karakterler arasındaki aralığı genişletebilir veya daraltabilirsiniz.

Aşağıdaki Java kodu, **tüm paragrafta** karakter aralığını nasıl genişleteceğinizi gösterir:

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

Aşağıdaki kod örneği, **kalın yazı tipine sahip metin bölümlerinde** karakter aralığını nasıl genişleteceğinizi gösterir:

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

Bazı durumlarda, Aspose.Slides tarafından oluşturulan metin, PowerPoint'te gösterilen aynı metinden biraz daha sık görünebilir. Bunun nedeni, PowerPoint'in belirli bir yazı tipi için geçerli kerning bilgilerinin ve kerning'in PowerPoint ayarlarında etkin olmasına rağmen kerning verilerini görmezden gelmesidir.

Bu gibi durumlarda oluşturulan çıktıyı PowerPoint'e daha yakın hâle getirmek için, etkilenen yazı tipini kullanan metin bölümleri için kerning'i devre dışı bırakabilirsiniz. [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) değerini gerçek yazı tipi boyutundan önemli ölçüde daha büyük bir değere ayarlayın:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormat portionFormat = portion.getPortionFormat();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portionFormat.setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bu ayar, eşleşen metin bölümlerine kerning uygulanmasını engeller ve bu PowerPoint'e özgü davranıştan etkilenen yazı tipleri için Aspose.Slides oluşturmasını PowerPoint'in görsel çıktısıyla uyumlu hâle getirmeye yardımcı olur.

## **Metin Yazı Tipi Özelliklerini Yönet**

Yazı tipi özellikleri, paragraf düzeyinde [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) aracılığıyla veya tek tek bölümlerde [IPortionFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iportionformat/) aracılığıyla ayarlanabilir.

Aşağıdaki kod, tüm paragraf için yazı tipi ve metin stilini ayarlar: paragraftaki tüm bölümlere yazı tipi boyutu, kalın, italik, noktalı alt çizgi ve Times New Roman yazı tipini uygular.

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

Aşağıdaki kod örneği, **kalın yazı tipine sahip metin bölümlerine** benzer özellikleri uygular:

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

[ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) kullanarak bir şekil içinde önceden tanımlı bir metin yönü ayarlayın.

Aşağıdaki kod örneği, şekildeki metin yönünü [TextVerticalType.Vertical270](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textverticaltype/) olarak ayarlar; bu, metni **90 derece saat yönünün tersine** döndürür:

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

## **Metin Çerçeveleri İçin Özel Döndürmeyi Ayarla**

[ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) kullanarak bir [ITextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/) için özel bir döndürme açısı ayarlayın.

Aşağıdaki kod örneği, şekil içinde metin çerçevesini saat yönünde 3 derece döndürür:

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

Aspose.Slides, paragraf aralığını kontrol etmek için [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-), ve [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) sağlar. Bu özellikler şu şekilde kullanılır:

* Pozitif bir değer kullanarak satır aralığını satır yüksekliğinin yüzde olarak belirtin.
* Negatif bir değer kullanarak satır aralığını puan cinsinden belirtin.

Aşağıdaki kod örneği, paragraftaki satır aralığını nasıl belirteceğinizi gösterir:

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

## **Metin Çerçeveleri İçin Otomatik Sığdırma Türünü Ayarla**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) , metin konteynerinin sınırlarını aştığında metnin nasıl davranacağını belirler. Metnin küçülüp küçülmeyeceğini, taşma yapıp yapmayacağını veya şeklin otomatik olarak yeniden boyutlandırılıp boyutlandırılmayacağını kontrol etmek için kullanın.

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

## **Metin Çerçevelerinin Sabitlemesini Ayarla**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) , bir şekil içinde metnin dikey konumunu, örneğin üstte, ortada veya altta olacak şekilde tanımlar.

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

Bir paragrafta sek duraklarını yapılandırmak için [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) ve [IParagraphFormat.getTabs](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) kullanın.

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

## **Denetleme Dilini Ayarla**

Aspose.Slides, bir metin bölümü için denetleme dili ayarlamanıza olanak tanıyan [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) sağlar. Denetleme dili, PowerPoint'te yazım ve dilbilgisi denetiminde kullanılan dili belirler.

Aşağıdaki kod örneği, bir metin bölümü için denetleme dilinin nasıl ayarlanacağını gösterir:

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

    // Doğrulama dilinin Id'sini ayarla.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Varsayılan Dili Ayarla**

Bir sunumu yüklerken veya oluştururken oluşturulan metinler için varsayılan dili tanımlamak üzere [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) kullanın.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Yeni bir dikdörtgen şekil ekle ve metin ekle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // İlk bölümenin dilini kontrol et.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Varsayılan Metin Stili Ayarla**

Sunum seviyesinde varsayılan metin biçimlendirmesini uygulamak için [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--) kullanın.

Aşağıdaki kod örneği, yeni bir sunumda tüm slaytlardaki tüm metinler için 14 pt boyutunda varsayılan kalın bir yazı tipi ayarlamayı gösterir.

```java
import com.aspose.slides.*;

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

## **Tüm Büyük Harf Etkisiyle Metni Çıkar**

PowerPoint'te **All Caps** (Tüm Büyük Harf) yazı tipi efekti uygulandığında metin, slaytta küçük harfle girilmiş olsa bile büyük harf olarak gösterilir. Aspose.Slides ile böyle bir metin bölümü alındığında, kütüphane metni tam olarak girildiği şekilde döndürür. Görüntülenen metinle eşleşmesi için, değer [TextCapType.All](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textcaptype/) olduğunda döndürülen dizeyi büyük harfe dönüştürün.

sample2.pptx dosyasının ilk slaydında aşağıdaki metin kutusunun olduğunu varsayalım.

![Tüm Büyük Harf etkisi](all_caps_effect.png)

Aşağıdaki kod örneği, **All Caps** etkisi uygulanmış metni nasıl çıkaracağınızı gösterir:

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

**Bir slayttaki tablo içinde metni nasıl değiştirebilirim?**

Bir slayttaki bir tablo içinde metni değiştirmek için, [ITable](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itable/) kullanın. Hücreler arasında döngü yaparak her hücreyi [ICell.getTextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icell/#getTextFrame--) üzerinden güncelleyin ve paragraf biçimlendirmesini [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) aracılığıyla ayarlayın.

**PowerPoint slaytındaki metne degrade (gradient) renk nasıl uygulanır?**

Metne bir degrade renk uygulamak için, [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) kullanın. [IFillFormat.setFillType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) değerini [FillType.Gradient](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/filltype/) olarak ayarlayın ve degrade duraklarını, yönünü ve şeffaflığını yapılandırın.