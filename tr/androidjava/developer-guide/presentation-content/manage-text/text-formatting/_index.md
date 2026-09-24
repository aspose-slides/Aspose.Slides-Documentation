---
title: Android'de Sunum Metnini Biçimlendirme
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
- metin döndürme
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
description: "Aspose.Slides for Android via Java kullanarak PowerPoint ve OpenDocument sunumlarındaki metni biçimlendirin ve stil verin. Yazı tiplerini, renkleri, hizalamayı ve daha fazlasını özelleştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Android via Java kullanarak PowerPoint ve OpenDocument sunumlarındaki metni biçimlendirmeyi gösterir. Arka plan renkleri, şeffaflık, karakter aralığı, yazı tipi özellikleri, döndürme, paragraf aralığı, otomatik sığdırma davranışı, metin sabitlemesi, sekme durakları ve dil ayarlarını kapsar.

Aşağıdaki örneklerde, ilk slaytta tek bir metin kutusu içeren ve aşağıdaki metni barındıran "sample.pptx" adlı dosyayı kullanacağız:

![Örnek metin](sample_text.png)

Gerçekteki metni veya düzenli ifade eşleşmelerini bulmak ve vurgulamak için [Metin Arama ve Değiştirme](/slides/tr/androidjava/search-and-replace-text/) bölümüne bakın.

## **Metin Arka Plan Rengini Ayarlama**

Bir paragraf için varsayılan vurgulama rengini ayarlamak için [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) kullanın veya bireysel metin bölümleri için [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) kullanın.

Aşağıdaki kod örneği **tüm paragrafın** arka plan rengini nasıl ayarlayacağını gösterir:

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

Aşağıdaki kod örneği **kalın bir yazı tipine sahip metin bölümleri** için arka plan rengini nasıl ayarlayacağını gösterir:

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

## **Metin Paragraflarını Hizalama**

Bir metin çerçevesi içinde paragraf hizalamasını ayarlamak için [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) kullanın. Değerler ortalanmış, sola hizalı, sağa hizalı, iki yana yaslı vb. olabilir.

Aşağıdaki kod örneği paragrafı **ortaya** hizalamayı gösterir:

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

## **Metin İçin Şeffaflığı Ayarlama**

Metin şeffaflığı, [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) aracılığıyla atanan rengin alfa bileşeni üzerinden kontrol edilir. Aşağıdaki örneklerde `alpha = 50`, 0–255 ölçeğinde bir ARGB alfa kanalı değeridir, yüzde şeffaflık değildir.

Aşağıdaki kod örneği **tüm paragrafta** şeffaflığı nasıl uygulayacağını gösterir:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Metnin doldurma rengini şeffaf renk olarak ayarla.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Şeffaf paragraf](transparent_paragraph.png)

Aşağıdaki kod örneği **kalın bir yazı tipine sahip metin bölümlerinde** şeffaflığı nasıl uygulayacağını gösterir:

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

## **Metin İçin Karakter Aralığını Ayarlama**

Bir metin kutusundaki karakterler arasındaki aralığı genişletmek veya sıkıştırmak için [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) kullanın.

Aşağıdaki Java kodu **tüm paragrafta** karakter aralığını nasıl genişleteceğinizi gösterir:

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

Aşağıdaki kod örneği **kalın bir yazı tipine sahip metin bölümlerinde** karakter aralığını nasıl genişleteceğinizi gösterir:

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

### **Belirli Yazı Tipleri İçin Kerning'i Devre Dışı Bırakma**

Bazı durumlarda Aspose.Slides tarafından oluşturulan metin, aynı metnin PowerPoint’teki görünümünden biraz daha sıkı görünebilir. Bu, PowerPoint’in bazı yazı tipleri için kerning verisini yok saymasından kaynaklanabilir; yazı tipinde geçerli kerning bilgileri bulunsa ve PowerPoint ayarlarında kerning etkin olsa bile.

Bu gibi durumlarda, etkilenen yazı tipini kullanan metin bölümlerinde kerning’i devre dışı bırakabilirsiniz. [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) değerini gerçek yazı tipi boyutundan belirgin şekilde büyük bir değere ayarlayın:

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

Bu ayar, eşleşen metin bölümlerine kerning uygulanmasını önler ve bu PowerPoint’e özgü davranıştan etkilenen yazı tiplerinin görsel çıktısını Aspose.Slides ile daha uyumlu hâle getirebilir.

## **Metin Yazı Tipi Özelliklerini Yönetme**

Yazı tipi özellikleri, [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) aracılığıyla paragraf seviyesinde veya [IPortionFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iportionformat/) üzerinden bireysel bölümlerde ayarlanabilir.

Aşağıdaki kod, tüm paragrafta yazı tipini ve metin stilini ayarlar: yazı tipi boyutu, kalın, italik, noktalı alt çizgi ve Times New Roman tüm bölümlere uygulanır.

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

![Paragrafın yazı tipi özellikleri](font_properties_for_paragraph.png)

Aşağıdaki kod örneği **kalın bir yazı tipine sahip metin bölümlerine** benzer özellikleri uygular:

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

![Metin bölümlerinin yazı tipi özellikleri](font_properties_for_text_portions.png)

## **Metin Döndürmeyi Ayarlama**

Bir şekil içinde önceden tanımlı bir metin yönelimini ayarlamak için [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) kullanın.

Aşağıdaki kod örneği metin yönelimini [TextVerticalType.Vertical270](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textverticaltype/) olarak ayarlar; bu, metni **90 derece saat yönünün tersine** döndürür:

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

## **Metin Çerçeveleri İçin Özel Döndürmeyi Ayarlama**

[ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) kullanarak bir [ITextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/) için özel bir döndürme açısı ayarlayabilirsiniz.

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

## **Paragrafların Satır Aralığını Ayarlama**

Aspose.Slides, paragraf aralığını kontrol etmek için [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) ve [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) sağlar. Bu özellikler şu şekilde kullanılır:

* Pozitif bir değer, satır aralığını satır yüksekliğinin yüzde olarak belirtir.
* Negatif bir değer, satır aralığını puan cinsinden belirtir.

Aşağıdaki kod örneği, paragraf içindeki satır aralığını nasıl belirleyeceğinizi gösterir:

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

## **Metin Çerçeveleri İçin Otomatik Sığdırma Türünü Ayarlama**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) metin, kapsayıcısının sınırlarını aştığında nasıl davranacağını belirler. Metnin şekli otomatik olarak küçülüp taşması ya da şeklin yeniden boyutlandırılması gibi durumları kontrol etmek için kullanın.

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

Otomatik kaydırma sonrası satır sayısını ve metin ya da şekil genişliğinin sonucu nasıl etkilediğini görmek için [Render Edilen Satırları Sayma](/slides/tr/androidjava/manage-paragraph/) bölümüne bakın. Satır sayısı yalnızca metnin kapsayıcısını aşıp aşmadığını göstermez.

## **Metin Çerçevelerinin Sabitlemesini Ayarlama**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) metnin bir şekil içinde dikey olarak nerede konumlandırılacağını tanımlar; örneğin üstte, ortada ya da altta.

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

## **Metin Sekme Ayarını Belirleme**

Paragrafta sekme duraklarını yapılandırmak için [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) ve [IParagraphFormat.getTabs](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) kullanın.

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

## **Denetleme Diline Ayarlama**

Aspose.Slides, bir metin bölümü için denetleme dili ayarlamanızı sağlayan [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) metodunu sunar. Denetleme dili, PowerPoint’te yazım ve dilbilgisi denetimi için kullanılan dili belirler.

Aşağıdaki kod örneği, bir metin bölümü için denetleme dilini nasıl ayarlayacağınızı gösterir:

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

Sunum yüklenirken veya oluşturulurken yeni oluşturulan metinlerin varsayılan dilini tanımlamak için [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) kullanın.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Metin ile yeni bir dikdörtgen şekil ekle.
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

Sunum düzeyinde varsayılan metin biçimlendirmesini uygulamak için [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--) kullanın.

Aşağıdaki kod örneği, yeni bir sunumda tüm slaytlardaki tüm metinler için 14 pt boyutunda kalın bir varsayılan yazı tipini ayarlar.

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

## **Büyük Harf Efekti ile Metni Çıkarma**

PowerPoint’te **All Caps** (Tam Büyük Harf) yazı tipi efekti uygulandığında, metin slaytta büyük harf olarak görünür, ancak aslen küçük harfle girilmiş olabilir. Aspose.Slides ile böyle bir metin bölümü alındığında, kütüphane metni tam olarak girildiği gibi döndürür. Görüntülenen metinle eşleşmesi için, değer [TextCapType.All](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textcaptype/) olduğunda döndürülen dizeyi büyük harfe çevirin.

Örneğin sample2.pptx dosyasının ilk slaytındaki aşağıdaki metin kutusunu ele alalım.

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

**Bir slayttaki tabloda metni nasıl değiştiririm?**

Tablodaki metni değiştirmek için [ITable](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itable/) kullanın. Hücreler üzerinde dolaşın ve her hücreyi [ICell.getTextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icell/#getTextFrame--) ile güncelleyerek, paragraf biçimlendirmesini ise [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) ile ayarlayın.

**PowerPoint slaytındaki metne degrade rengi nasıl uygularım?**

Metne degrade rengi uygulamak için [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) kullanın. [IFillFormat.setFillType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) değerini [FillType.Gradient](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/filltype/) olarak ayarlayın ve degrade duraklarını, yönünü ve şeffaflığını yapılandırın.