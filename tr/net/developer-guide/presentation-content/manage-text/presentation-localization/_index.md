---
title: ".NET'te Sunum Yerelleştirmesini Otomatikleştir"
linktitle: "Sunum Yerelleştirme"
type: docs
weight: 100
url: /tr/net/presentation-localization/
keywords:
- "dil değişikliği"
- "imla denetimi"
- "imla denetimini devre dışı bırak"
- "doğrulama dili"
- "dil kimliği"
- "çok dilli metin"
- "PowerPoint"
- "sunum"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides ile .NET'te PowerPoint ve OpenDocument sunum metinleri için doğrulama dillerini ayarlayın; varsayılanları ve çok dilli paragrafları içerir."
---
## **Genel Bakış**

Aspose.Slides for .NET, bireysel metin bölümleri için doğrulama meta verilerini yapılandırmanıza olanak tanır. Doğrulama dilini belirlemek için [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseportionformat/languageid/) kullanın, imla denetimlerini etkinleştirmek veya devre dışı bırakmak için [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/tr/net/aspose.slides/baseportionformat/spellcheck/) ve daha geniş “doğrulama yapılmasın” durumunu kontrol etmek için [BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/tr/net/aspose.slides/baseportionformat/proofdisabled/) kullanın. Bu ayarlar bölüm seviyesinde uygulandığından, bir paragraf birden çok dil ve farklı doğrulama kuralları içerebilir.

Bu makale, belirli bir metne nasıl dil atanacağını, yeni metin için varsayılan dili [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/defaulttextlanguage/) ile nasıl ayarlayacağınızı, çok dilli paragraflar oluşturmayı, `SpellCheck` ve `ProofDisabled` arasında seçim yapmayı ve [Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/joinportionswithsameformatting/) kullanırken istenen ayarların korunmasını açıklar. Bu özellikler, sunum uygulamaları için meta veri depolar; metni çevirmez, sözlüğe dayalı imla denetimi yapmaz veya hatalı yazılmış kelimeleri döndürmez.

## **Metin için Doğrulama Dilini Ayarlama**

Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) oluşturun veya yükleyin, gerekli metin bölümüne [IPortion.PortionFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/iportion/portionformat/) aracılığıyla erişin ve dil tanımlayıcısını atayın. Aşağıdaki örnek bir şekil oluşturur, İngiliz İngilizcesini doğrulama dili olarak ayarlar ve sonucu [Presentation.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/save/) ile kaydeder:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Set the proofing language for this text.";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LanguageId = "en-GB";

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **Yeni Metin için Varsayılan Dili Ayarlama**

[LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/defaulttextlanguage/) kullanarak Aspose.Slides'in yeni oluşturulan metne atadığı doğrulama dilini belirtebilirsiniz. Bu ayar, bir sunumdaki yeni metnin çoğu veya tamamı aynı dili kullandığında faydalıdır. Halihazırda açık bir dil tanımlı metnin dil meta verisini değiştirmez.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DefaultTextLanguage = "de-DE"
};

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Willkommen zur Präsentation";

presentation.Save("default_text_language.pptx", SaveFormat.Pptx);
```

## **Tek Bir Paragrafta Birden Fazla Dil Kullanma**

Bir [IParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph/) metin bölümlerinin bir koleksiyonunu içerir. Her dil için ayrı bir [Portion](https://reference.aspose.com/slides/tr/net/aspose.slides/portion/) oluşturun ve `LanguageId` değerini bağımsız olarak ayarlayın.

Bu örnek İngilizce ve Fransızca bölümler içeren bir paragraf oluşturur:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var englishPortion = new Portion("Welcome");
englishPortion.PortionFormat.LanguageId = "en-US";
paragraph.Portions.Add(englishPortion);

var frenchPortion = new Portion(" — Bienvenue");
frenchPortion.PortionFormat.LanguageId = "fr-FR";
paragraph.Portions.Add(frenchPortion);

presentation.Save("multilingual_text.pptx", SaveFormat.Pptx);
```

## **Bireysel Bölümler İçin İmla Denetimini Etkinleştirme veya Devre Dışı Bırakma**

[IPortionFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/iportionformat/) [IBasePortionFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseportionformat/) tarafından tanımlanan ortak metin özelliklerini devralır. Bir bölümün biçimine [IPortion.PortionFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/iportion/portionformat/) üzerinden erişin ve [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/tr/net/aspose.slides/baseportionformat/spellcheck/) değerini ayarlayarak sunum uygulamasının o bölümde imla denetimi yapıp yapmayacağını kontrol edin. Varsayılan değer false'tur: true imla denetimine izin verir, false ise devre dışı bırakır.

Ayar bireysel metin bölümlerine uygulanır. Aynı paragraftaki farklı bölümler bu nedenle farklı değerler kullanabilir. [BasePortionFormat.LanguageId](https://reference.aspose.com/slides/tr/net/aspose.slides/baseportionformat/languageid/) ve `SpellCheck` birbirini tamamlayıcı amaçlar taşır: `LanguageId` doğrulama dilini belirler, `SpellCheck` ise bölümde imla denetiminin izinli olup olmadığını belirler.

[BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/tr/net/aspose.slides/baseportionformat/proofdisabled/) da doğrulama kontrol eder, ancak daha geniş “doğrulama yapılmasın” durumunu bir [NullableBool](https://reference.aspose.com/slides/tr/net/aspose.slides/nullablebool/) olarak temsil eder. Yalnızca imla denetimi için doğrudan bir Boolean anahtarı gerektiğinde `SpellCheck` kullanın. Sunumun doğrulama yapılmayan meta verisini, `NotDefined` durumunu da içerecek şekilde korumak veya açıkça kontrol etmek istediğinizde `ProofDisabled` kullanın. Her iki özelliği de ayarlarsanız, değerlerini tutarlı tutun; `SpellCheck = true` ile `ProofDisabled = NullableBool.True` kombinasyonunu yapmayın.

Bu özellikler, PowerPoint ve diğer sunum uygulamaları tarafından kullanılan doğrulama meta verilerini yapılandırır. Aspose.Slides, bunları sözlüğe dayalı imla denetimi çalıştırmak veya hatalı yazılmış kelimelerin bir listesini döndürmek için kullanmaz.

Aşağıdaki tam örnek bir giriş sunumu oluşturur, yükler, aynı paragraftaki iki bölüme farklı imla denetim ayarları ve doğrulama dilleri atar, sonucu kaydeder, tekrar açar ve saklanan değerleri doğrular:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputFile = "spell_check_input.pptx";
const string outputFile = "spell_check_settings.pptx";

using (var sourcePresentation = new Presentation())
{
    var sourceSlide = sourcePresentation.Slides[0];
    var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    var sourceParagraph = sourceShape.TextFrame.Paragraphs[0];
    sourceParagraph.Portions.Clear();

    var sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.PortionFormat.LanguageId = "en-US";
    sourceParagraph.Portions.Add(sourceEnglishPortion);

    var sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.PortionFormat.LanguageId = "fr-FR";
    sourceParagraph.Portions.Add(sourceFrenchPortion);

    sourcePresentation.Save(inputFile, SaveFormat.Pptx);
}

using (var presentation = new Presentation(inputFile))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var portions = shape.TextFrame.Paragraphs[0].Portions;

    var checkedPortion = portions[0];
    checkedPortion.PortionFormat.LanguageId = "en-US";
    checkedPortion.PortionFormat.SpellCheck = true;

    var suppressedPortion = portions[1];
    suppressedPortion.PortionFormat.LanguageId = "fr-FR";
    suppressedPortion.PortionFormat.SpellCheck = false;

    presentation.Save(outputFile, SaveFormat.Pptx);
}

using var reopenedPresentation = new Presentation(outputFile);
var reopenedShape = (IAutoShape)reopenedPresentation.Slides[0].Shapes[0];
var storedPortions = reopenedShape.TextFrame.Paragraphs[0].Portions;

var firstPortionStored = storedPortions.Count == 2 &&
    storedPortions[0].PortionFormat.LanguageId == "en-US" &&
    storedPortions[0].PortionFormat.SpellCheck;

var secondPortionStored = storedPortions.Count == 2 &&
    storedPortions[1].PortionFormat.LanguageId == "fr-FR" &&
    !storedPortions[1].PortionFormat.SpellCheck;

if (firstPortionStored && secondPortionStored)
{
    Console.WriteLine("The proofing settings were stored correctly.");
}
else
{
    Console.WriteLine("The proofing settings could not be verified.");
}
```

[Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/joinportionswithsameformatting/) aynı biçime sahip yan yana bölümleri birleştirir. Yalnızca `SpellCheck` farkı bu bölümlerin ayrı kalmasını sağlamaz; birleştirildikten sonra oluşan bölüm, ilk bölümün `SpellCheck` değerini korur. Bölümlerin farklı imla denetim ayarlarına ihtiyacı varsa, bu ayarları atamadan önce `JoinPortionsWithSameFormatting` çağırın veya oluşan bölüm sınırlarını inceleyip daha sonra ayarları yeniden uygulayın. Farklı `LanguageId` değerlerine sahip bölümler, doğrulama dili biçimleri farklı olduğu için ayrı kalır.

## **FAQ**

**Bir dil kimliği metni çevirir mi?**

Hayır. [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseportionformat/languageid/) imla ve dil bilgisi için doğrulama meta verilerini depolar; metin içeriğini değiştirmez. Metni ayrı olarak çevirin ve ardından çevrilen her bölüm için uygun dil tanımlayıcısını ayarlayın.

**Doğrulama dili fontları, tireleme veya satır kaydırmayı kontrol eder mi?**

Hayır. Dil tanımlayıcısı doğrulama içindir. Metin gösterimi ve düzeni öncelikle mevcut [fonts](/slides/tr/net/powerpoint-fonts/), yazı sistemi ve metin çerçevesi ayarlarına bağlıdır. Güvenilir gösterim için gerekli fontları sağlayın, [font substitution](/slides/tr/net/font-substitution/) yapılandırın veya [embed fonts](/slides/tr/net/embedded-font/) sunuma ekleyin.

**Bir paragraf birden fazla doğrulama dili kullanabilir mi?**

Evet. Her dili ayrı bir bölüme atayın, çok dilli paragraf örneğinde gösterildiği gibi.

**`DefaultTextLanguage` mı yoksa `LanguageId` mi kullanmalıyım?**

[LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/defaulttextlanguage/) yeni oluşturulan metin için varsayılan bir dil istediğinizde kullanın. [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseportionformat/languageid/) belirli bir bölümün açık bir doğrulama diline ihtiyacı olduğunda veya bir paragrafta birden çok dil olduğunda kullanın.