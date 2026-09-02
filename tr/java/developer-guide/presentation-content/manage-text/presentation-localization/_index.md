---
title: Java'da Sunum Yerelleştirmesini Otomatikleştir
linktitle: Sunum Yerelleştirme
type: docs
weight: 100
url: /tr/java/presentation-localization/
keywords:
- dil değişikliği
- yazım denetimi
- yazım denetimini bastır
- düzeltme dili
- dil kimliği
- çok dilli metin
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides ile Java'da PowerPoint ve OpenDocument sunum metni için düzeltme dillerini ayarlayın, varsayılanlar ve çok dilli paragraflar dahil."
---
## **Genel Bakış**

Aspose.Slides for Java, metnin bireysel bölümleri için düzeltme üst verisini yapılandırmanıza olanak tanır. Düzeltme dilini belirlemek için [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) , yazım denetimini açmak veya kapatmak için [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) ve daha geniş “düzeltme yapılmasın” durumunu kontrol etmek için [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) kullanın. Bu ayarlar bölüm seviyesinde uygulandığı için bir paragrafta birden çok dil ve farklı düzeltme kuralları bulunabilir.

Bu makale, belirli bir metne dil atamayı, yeni metin için varsayılan dili [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) ile ayarlamayı, çok dilli paragraflar oluşturmayı, `SpellCheck` ile `ProofDisabled` arasında seçim yapmayı ve [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) kullanılırken istenen ayarların korunmasını açıklar. Bu özellikler sunum uygulamaları için üst veri depolar; metni çevirmez, sözlük tabanlı yazım denetimi yapmaz veya hatalı sözcükleri döndürmez.

## **Metin İçin Düzeltme Dilini Ayarlama**

Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) oluşturun veya yükleyin, gerekli metin bölümüne [IPortion.getPortionFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iportion/#getPortionFormat--) aracılığıyla erişin ve dil tanımlayıcısını atayın. Aşağıdaki örnek bir şekil oluşturur, İngiliz İngilizcesini düzeltme dili olarak ayarlar ve sonucu [Presentation.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#save-java.lang.String-int-) ile kaydeder:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IPortion;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Yeni Metin İçin Varsayılan Dili Ayarlama**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) kullanarak Aspose.Slides’in yeni oluşturulan metne atayacağı düzeltme dilini belirleyin. Bu ayar, bir sunumdaki yeni metnin büyük çoğunluğunun aynı dili kullanacağı durumlarda kullanışlıdır. Zaten açık bir dili olan metnin üst verisini değiştirmez.

Aşağıdaki örnek, yeni metnin Almanca düzeltme kurallarını kullandığı bir sunum oluşturur:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tek Paragrafta Birden Çok Dil Kullanma**

Bir [IParagraph](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraph/) metin bölümlerinin bir koleksiyonunu içerir. Her dil için ayrı bir [Portion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/portion/) oluşturun ve `LanguageId` öğesini bağımsız olarak ayarlayın.

Bu örnek, İngilizce ve Fransızca bölümler içeren bir paragraf oluşturur:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion englishPortion = new Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    Portion frenchPortion = new Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bireysel Bölümler İçin Yazım Denetimini Etkinleştirme veya Bastırma**

[IPortionFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iportionformat/) , [IBasePortionFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibaseportionformat/) tarafından tanımlanan ortak metin özelliklerini devralır. Bir bölümün biçimine [IPortion.getPortionFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iportion/#getPortionFormat--) üzerinden erişin ve [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) kullanarak bir sunum uygulamasının o bölüm için yazım denetimi yapıp yapmayacağını kontrol edin. Varsayılan değer `false` tır: `true` yazım denetimine izin verir, `false` ise bastırır.

Ayar, bireysel metin bölümlerine uygulanır. Aynı paragraftaki farklı bölümler farklı değerler kullanabilir. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) ve `setSpellCheck` tamamlayıcı amaçlar taşır: `setLanguageId` düzeltme dilini tanımlar, `setSpellCheck` ise bölüme yazım denetiminin izin verilip verilmediğini belirler.

[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) da düzeltmeyi kontrol eder, ancak daha geniş “düzeltme yapılmasın” durumunu bir [NullableBool](https://reference.aspose.com/slides/tr/java/com.aspose.slides/nullablebool/) olarak temsil eder. Yazım denetimi için doğrudan bir Boolean anahtarı gerektiğinde `setSpellCheck` kullanın. Sunumun “düzeltme yapılmasın” üst verisini, `NotDefined` durumunu da içerecek şekilde korumak veya açıkça kontrol etmek istediğinizde `setProofDisabled` kullanın. Her iki özelliği de ayarlıyorsanız, değerlerin tutarlı olmasına dikkat edin; `setSpellCheck(true)` ile `setProofDisabled(NullableBool.True)` kombinasyonunu kullanmayın.

Bu özellikler, PowerPoint ve diğer sunum uygulamaları tarafından kullanılan düzeltme üst verisini yapılandırır. Aspose.Slides, bu verileri sözlük tabanlı yazım denetimi yürütmek veya hatalı sözcük listesi döndürmek için kullanmaz.

Aşağıdaki tam örnek, bir giriş sunumu oluşturur, yükler, aynı paragraftaki iki bölüm için farklı yazım denetimi ayarları ve düzeltme dilleri atar, sonucu kaydeder, yeniden açar ve kaydedilen değerleri doğrular:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.IPortion;
import com.aspose.slides.IPortionCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

String inputFile = "spell_check_input.pptx";
String outputFile = "spell_check_settings.pptx";

Presentation sourcePresentation = new Presentation();
try {
    ISlide sourceSlide = sourcePresentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    Portion sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    Portion sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

Presentation presentation = new Presentation(inputFile);
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    IPortion checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    IPortion suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation(outputFile);
try {
    IAutoShape reopenedShape = (IAutoShape) reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    boolean firstPortionStored = storedPortions.getCount() == 2 && 
            "en-US".equals(storedPortions.get_Item(0).getPortionFormat().getLanguageId()) && 
            storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    boolean secondPortionStored = storedPortions.getCount() == 2 && 
            "fr-FR".equals(storedPortions.get_Item(1).getPortionFormat().getLanguageId()) && 
            !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        System.out.println("The proofing settings were stored correctly.");
    } else {
        System.out.println("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) aynı biçime sahip yan yana bölümleri birleştirir. Yalnızca `SpellCheck` farkı, bu bölümlerin ayrı kalmasını sağlamaz; birleştirildikten sonra ortaya çıkan bölüm, ilk bölümün `SpellCheck` değerini korur. Bölümlerin farklı yazım denetimi ayarları gerekiyorsa, bu ayarları atamadan önce `joinPortionsWithSameFormatting` çağırın veya sonuç bölüm sınırlarını inceleyip ayarları sonradan yeniden uygulayın. `LanguageId` değerleri farklı olan bölümler, düzeltme‑dili biçimlendirmeleri farklı olduğu için ayrı kalır.

## **SSS**

**Bir dil kimliği metni çevirir mi?**

Hayır. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) yazım ve dil bilgisi için düzeltme üst verisini depolar; metin içeriğini değiştirmez. Metni ayrı olarak çevirin ve ardından her çevrilmiş bölüm için uygun dil tanımlayıcısını ayarlayın.

**Düzeltme dili fontları, bölünmeleri veya satır kaydırmayı kontrol eder mi?**

Hayır. Dil tanımlayıcısı yalnızca düzeltme içindir. Metin render’ı ve yerleşimi esas olarak mevcut [fontlar](/slides/tr/java/powerpoint-fonts/), yazı sistemi ve metin‑çerçeve ayarlarına bağlıdır. Güvenilir render için gerekli fontları sağlayın, [font ikamesi](/slides/tr/java/font-substitution/) yapılandırın veya sunuma [font gömme](/slides/tr/java/embedded-font/) ekleyin.

**Bir paragrafta birkaç düzeltme dili kullanılabilir mi?**

Evet. Çok dilli paragraf örneğinde gösterildiği gibi her dili ayrı bir bölüme atayın.

**`setDefaultTextLanguage` mu yoksa `setLanguageId` mi kullanmalıyım?**

Yeni oluşturulan metin için bir varsayılan istiyorsanız [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) kullanın. Belirli bir bölümün açıkça bir düzeltme dili gerektirdiği veya bir paragrafta birden fazla dil bulunduğu durumlarda ise [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) kullanın.