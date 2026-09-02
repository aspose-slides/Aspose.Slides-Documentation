---
title: JavaScript'te Sunum Yerelleştirmesini Otomatikleştir
linktitle: Sunum Yerelleştirmesi
type: docs
weight: 100
url: /tr/nodejs-java/presentation-localization/
keywords:
- dil değişikliği
- yazım denetimi
- yazım denetimini devre dışı bırak
- kanıtlama dili
- dil kimliği
- çok dilli metin
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: Aspose.Slides ile JavaScript'te PowerPoint ve OpenDocument sunum metinleri için kanıtlama dillerini ayarlayın; varsayılanlar ve çok dilli paragraflar dahil.
---
## **Genel Bakış**

Aspose.Slides for Node.js via Java, bireysel metin bölümleri için proofing üst verilerini yapılandırmanıza olanak tanır. Proofing dilini belirlemek için [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-), yazım denetimini izin vermek ya da engellemek için [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-), daha geniş bir “proof” durumu kontrolü için ise [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) yöntemlerini kullanın. Bu ayarlar bölüm seviyesinde uygulandığından, tek bir paragrafta birden fazla dil ve farklı proofing kuralları bulunabilir.

Bu makale, belirli bir metne dil atama, yeni metin için varsayılan dili [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) ile ayarlama, çok dilli paragraflar oluşturma, `SpellCheck` ile `ProofDisabled` arasında seçim yapma ve [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--) kullanılırken istenen ayarların korunmasını açıklar. Bu özellikler sunum uygulamaları için üst veri depolar; metni çevirmez, sözlük tabanlı yazım denetimi yapmaz ya da hatalı yazılmış kelimeleri döndürmez.

## **Metin İçin Proofing Dilini Ayarlama**

Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) oluşturun ya da yükleyin, gerekli metin bölümüne [Portion.getPortionFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/#getPortionFormat--) aracılığıyla erişin ve dil tanımlayıcısını atayın. Aşağıdaki örnek bir şekil oluşturur, proofing dili olarak Britanya İngilizcesi ayarlar ve sonucu [Presentation.save](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) ile kaydeder:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Yeni Metin İçin Varsayılan Dili Ayarlama**

Yeni oluşturulan metinlere Aspose.Slides'in atayacağı proofing dilini belirtmek için [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) yöntemini kullanın. Bu ayar, bir sunumdaki yeni metnin büyük çoğunluğunun aynı dili kullanması durumunda faydalıdır. Açıkça bir dil atanan metnin dil üst verisini değiştirmez.

Aşağıdaki örnek, yeni metnin Almanca proofing kurallarını kullandığı bir sunum oluşturur:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tek Bir Paragrafa Birden Çok Dil Kullanma**

Bir [Paragraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/) metin bölümlerinin koleksiyonunu içerir. Her dil için ayrı bir [Portion](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/) oluşturun ve `LanguageId` değerini bağımsız olarak ayarlayın.

Bu örnek, İngilizce ve Fransızca bölümlerinden oluşan tek bir paragraf oluşturur:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const englishPortion = new aspose.slides.Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    const frenchPortion = new aspose.slides.Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bireysel Bölümler İçin Yazım Denetimini Etkinleştirme veya Devre Dışı Bırakma**

[PortionFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portionformat/) , [BasePortionFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseportionformat/) tarafından tanımlanan ortak metin özelliklerini devralır. Bir bölümün biçimine [Portion.getPortionFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/#getPortionFormat--) üzerinden erişin ve [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) ile sunum uygulamasının o bölüm için yazım denetimi yapıp yapmayacağını kontrol edin. Varsayılan değer `false`’tır: `true` yazım denetimine izin verir, `false` ise engeller.

Ayar, bireysel metin bölümlerine uygulanır. Aynı paragraftaki farklı bölümler bu sayede farklı değerler kullanabilir. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) ve `setSpellCheck` birbirini tamamlayıcı amaçlar taşır: `setLanguageId` proofing dilini belirler, `setSpellCheck` ise o bölüm için yazım denetiminin izin verilip verilmeyeceğini belirler.

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) da proofing’i kontrol eder, ancak daha geniş bir “do not proof” durumunu bir [NullableBool](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/nullablebool/) olarak temsil eder. Yalnızca yazım denetimi için doğrudan bir Boolean anahtarına ihtiyacınız varsa `setSpellCheck` kullanın. Sunumun “no‑proof” üst verisini, `NotDefined` durumunu da içerecek şekilde korumak veya açıkça kontrol etmek istiyorsanız `setProofDisabled` kullanın. Her iki özelliği de aynı anda ayarlarsanız, değerlerin tutarlı olmasına dikkat edin; `setSpellCheck(true)` ile `setProofDisabled(NullableBool.True)` kombinasyonunu kullanmayın.

Bu özellikler, PowerPoint ve diğer sunum uygulamaları tarafından kullanılan proofing üst verisini yapılandırır. Aspose.Slides, bunları sözlük tabanlı yazım denetimi gerçekleştirmek ya da hatalı yazılmış kelimelerin bir listesini döndürmek için kullanmaz.

Aşağıdaki tam örnek, bir giriş sunumu oluşturur, yükler, aynı paragraftaki iki bölüme farklı yazım denetimi ayarları ve proofing dilleri atar, sonucu kaydeder, yeniden açar ve kaydedilen değerleri doğrular:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const inputFile = "spell_check_input.pptx";
const outputFile = "spell_check_settings.pptx";

const sourcePresentation = new aspose.slides.Presentation();
try {
    const sourceSlide = sourcePresentation.getSlides().get_Item(0);
    const sourceShape = sourceSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    const sourceEnglishPortion = new aspose.slides.Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    const sourceFrenchPortion = new aspose.slides.Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

const presentation = new aspose.slides.Presentation(inputFile);
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    const suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const firstPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(0).getPortionFormat().getLanguageId() === "en-US" && 
        storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    const secondPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(1).getPortionFormat().getLanguageId() === "fr-FR" && 
        !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        console.log("The proofing settings were stored correctly.");
    } else {
        console.log("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--) aynı biçimlendirmeye sahip bitişik bölümleri birleştirir. Yalnızca `SpellCheck` farkı, bu bölümlerin ayrı kalmasını sağlamaz; birleştirildikten sonra oluşan bölüm, ilk bölümün `SpellCheck` değerini korur. Bölümlerin farklı yazım denetimi ayarlarına ihtiyacı varsa, bu ayarları atamadan önce `joinPortionsWithSameFormatting` çağırın veya sonuç bölüm sınırlarını inceleyip ayarları sonradan yeniden uygulayın. `LanguageId` değeri farklı olan bölümler, proofing‑dili biçimlendirmesi farklı olduğu için ayrı kalır.

## **SSS**

**Bir dil kimliği metni çevirir mi?**

Hayır. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) yazım ve dilbilgisi için proofing üst verilerini depolar; metin içeriğini değiştirmez. Metni ayrı olarak çevirin ve ardından her çevrilmiş bölüm için uygun dil tanımlayıcısını ayarlayın.

**Proofing dili, yazı tiplerini, hecelemeyi ya da satır kaydırmayı kontrol eder mi?**

Hayır. Dil tanımlayıcısı yalnızca proofing içindir. Metin render’ı ve yerleşimi öncelikle mevcut [fonts](/slides/tr/nodejs-java/powerpoint-fonts/), yazı sistemi ve metin‑çerçeve ayarlarına bağlıdır. Güvenilir render için gerekli yazı tiplerini sağlayın, [font substitution](/slides/tr/nodejs-java/font-substitution/) yapılandırın ya da sunuma [embed fonts](/slides/tr/nodejs-java/embedded-font/) ekleyin.

**Bir paragraf birden fazla proofing dili kullanabilir mi?**

Evet. Çok dilli paragraf örneğinde gösterildiği gibi her dili ayrı bir bölüme atayın.

**`setDefaultTextLanguage` mı yoksa `setLanguageId` mi kullanmalıyım?**

Yeni oluşturulan metin için varsayılan bir dil istiyorsanız [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) kullanın. Belirli bir bölüm için açık bir proofing dili atamanız gerekiyorsa ya da bir paragrafta birden fazla dil bulunuyorsa [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) kullanın.