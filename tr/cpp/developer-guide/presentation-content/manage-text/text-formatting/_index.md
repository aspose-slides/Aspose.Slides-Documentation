---
title: "C++'ta Sunum Metnini Biçimlendirme"
linktitle: "Metin Biçimlendirme"
type: docs
weight: 50
url: /tr/cpp/text-formatting/
keywords:
- "metni vurgulama"
- "düzenli ifade"
- "paragraf hizalama"
- "metin stili"
- "metin arka planı"
- "metin şeffaflığı"
- "karakter aralığı"
- "yazı tipi özellikleri"
- "yazı tipi ailesi"
- "metin döndürmesi"
- "döndürme açısı"
- "metin çerçevesi"
- "satır aralığı"
- "otomatik sığdırma özelliği"
- "metin çerçevesi bağlantı noktası"
- "metin sekmeleri"
- "varsayılan dil"
- "PowerPoint"
- "OpenDocument"
- "sunum"
- "C++"
- "Aspose.Slides"
description: "Aspose.Slides for C++ kullanarak PowerPoint ve OpenDocument sunumlarında metni biçimlendirin ve stil verin. Yazı tiplerini, renkleri, hizalamayı ve daha fazlasını özelleştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for C++ kullanarak PowerPoint ve OpenDocument sunumlarındaki metni biçimlendirmeyi gösterir. Vurgulama, arka plan renkleri, şeffaflık, karakter aralığı, yazı tipi özellikleri, döndürme, paragraf aralığı, otomatik sığdırma davranışı, metin yerleştirme, sekme durakları ve dil ayarları ele alınmaktadır.

Aşağıdaki örneklerde, ilk slaytta tek bir metin kutusu içeren ve aşağıdaki metni barındıran "sample.pptx" adlı dosyayı kullanacağız:

![Örnek metin](sample_text.png)

## **Metni Vurgulama**

Belirli bir örnekle eşleşen metni vurgulamanız gerektiğinde [ITextFrame.HighlightText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/highlighttext/) yöntemini kullanın. Bu yöntem eşleşen metin parçalarına vurgulama rengi uygular ve yalnızca tam kelimelerle eşleşmek gibi arama davranışını kontrol etmek için [ITextSearchOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextsearchoptions/) ile birlikte kullanılabilir.

Aşağıdaki kod örneği, **"try"** karakterlerinin tüm görünümlerini vurgular ve ardından yalnızca tam **"to"** kelimesini vurgular.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

// İlk slayttan ilk şekli al.
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Şekilde "try" kelimesini vurgula.
shape->get_TextFrame()->HighlightText(u"try", System::Drawing::Color::get_LightBlue());

auto searchOptions = System::MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);

// Şekilde "to" kelimesini vurgula.
shape->get_TextFrame()->HighlightText(u"to", System::Drawing::Color::get_Violet(), searchOptions, nullptr);

presentation->Save(u"highlighted_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Vurgulanan metin](highlighted_text.png)

## **Düzenli İfadelerle Metni Vurgulama**

[ITextFrame.HighlightRegex](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/highlightregex/) yöntemi, bir düzenli ifade tarafından bulunan metin eşleşmelerini vurgular. C++'ta bu API, [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) üzerinde sunulur.

Aşağıdaki kod örneği, **yedi veya daha fazla karakter içeren** tüm kelimeleri vurgular:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

auto regex = System::MakeObject<System::Text::RegularExpressions::Regex>(u"\\b[^\\s]{7,}\\b");

// Yedi veya daha fazla karakter içeren tüm kelimeleri vurgula.
shape->get_TextFrame()->HighlightRegex(regex, System::Drawing::Color::get_Yellow(), nullptr);

presentation->Save(u"highlighted_text_using_regex.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Düzenli ifade kullanılarak vurgulanan metin](highlighted_text_using_regex.png)

## **Metin Arka Plan Rengini Ayarlama**

Paragraf için varsayılan vurgulama rengini ayarlamak üzere [IParagraphFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat`'ı, tek tek metin bölümleri için ise [IPortionFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportionformat/)`.HighlightColor`'ı kullanın.

Aşağıdaki kod örneği, **tüm paragraf** için arka plan rengini nasıl ayarlayacağınızı gösterir:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Tüm paragraf için vurgulama rengini ayarla.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Gri paragraf](gray_paragraph.png)

Aşağıdaki kod örneği, **kalın bir yazı tipine sahip metin bölümleri** için arka plan rengini nasıl ayarlayacağınızı gösterir:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // Metin bölümü için vurgulama rengini ayarla.
        portion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Gri metin bölümleri](gray_text_portions.png)

## **Metin Paragraflarını Hizalama**

Metin çerçevesi içinde paragraf hizalamasını ayarlamak için [IParagraphFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/)`.Alignment` kullanın. Değer; ortalanmış, sola hizalanmış, sağa hizalanmış, iki yana yaslanmış vb. olabilir.

Aşağıdaki kod örneği, paragrafı **ortaya** hizalamayı gösterir:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Paragrafın hizalamasını ortaya ayarla.
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Hizalanmış paragraf](aligned_paragraph.png)

## **Metin Şeffaflığını Ayarlama**

Metin şeffaflığı, [IPortionFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportionformat/)`.FillFormat`'a atanmış rengin alfa bileşeni aracılığıyla kontrol edilir. Aşağıdaki örneklerde, `alpha = 50` 0‑255 ölçeğinde bir ARGB alfa kanalı değeridir, yüzde şeffaflık değildir.

Aşağıdaki kod örneği, **tüm paragraf** için şeffaflık uygulamayı gösterir:

```cpp
int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Metnin doldurma rengini şeffaf renk olarak ayarla.
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Şeffaf paragraf](transparent_paragraph.png)

Aşağıdaki kod örneği, **kalın bir yazı tipine sahip metin bölümleri** için şeffaflık uygulamayı gösterir:

```cpp
int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // Metin bölümünün şeffaflığını ayarla.
        portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
        portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Şeffaf metin bölümleri](transparent_text_portions.png)

## **Metin İçin Karakter Aralığını Ayarlama**

Metin kutusundaki karakterler arasındaki aralığı genişletmek veya daraltmak için [IBasePortionFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseportionformat/)`.Spacing` kullanın.

Aşağıdaki C++ kodu, **tüm paragraf** için karakter aralığını nasıl genişleteceğinizi gösterir:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Not: Karakter aralığını sıkıştırmak için negatif değerler kullanın.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f);

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Paragraftaki karakter aralığı](character_spacing_in_paragraph.png)

Aşağıdaki kod örneği, **kalın bir yazı tipine sahip metin bölümleri** için karakter aralığını nasıl genişleteceğinizi gösterir:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // Not: Karakter aralığını sıkıştırmak için negatif değerler kullanın.
        portion->get_PortionFormat()->set_Spacing(3.0f);
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Metin bölümlerindeki karakter aralığı](character_spacing_in_text_portions.png)

### **Belirli Yazı Tipleri İçin Kerning'i Devre Dışı Bırakma**

Bazı durumlarda, Aspose.Slides tarafından render edilen metin, PowerPoint'te aynı metinden biraz daha sıkı görünebilir. Bu, PowerPoint'in belirli yazı tipleri için kerning verilerini yok saymasından kaynaklanabilir; hatta yazı tipi geçerli kerning bilgisine sahip olsa ve PowerPoint ayarlarında kerning etkin olsa bile.

Bu gibi durumlarda render çıktısını PowerPoint'e daha yakın hale getirmek için, etkilenen yazı tipini kullanan metin bölümleri için kerning'i devre dışı bırakabilirsiniz. [IPortionFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportionformat/)`.KerningMinimalSize` değerini gerçek yazı tipi boyutundan çok daha büyük bir değere ayarlayın:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
System::String targetFont = u"Roboto";
auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
int paragraphCount = paragraphs->get_Count();

for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = paragraphs->idx_get(paragraphIndex);
    auto portions = paragraph->get_Portions();
    int portionCount = portions->get_Count();

    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = portions->idx_get(portionIndex);
        auto portionFormat = portion->get_PortionFormat();
        auto latinFont = portionFormat->get_LatinFont();
        auto eastAsianFont = portionFormat->get_EastAsianFont();
        auto complexScriptFont = portionFormat->get_ComplexScriptFont();

        bool isLatinFont = latinFont != nullptr && latinFont->get_FontName() == targetFont;
        bool isEastAsianFont = eastAsianFont != nullptr && eastAsianFont->get_FontName() == targetFont;
        bool isComplexScriptFont = complexScriptFont != nullptr && complexScriptFont->get_FontName() == targetFont;

        if (isLatinFont || isEastAsianFont || isComplexScriptFont)
        {
            portionFormat->set_KerningMinimalSize(100.0f);
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Bu ayar, eşleşen metin bölümlerine kerning uygulanmasını engeller ve PowerPoint'e özgü bu davranıştan etkilenen yazı tipleri için Aspose.Slides render'ını PowerPoint'in görsel çıktısıyla hizalamaya yardımcı olur.

## **Metin Yazı Tipi Özelliklerini Yönetme**

Yazı tipi özellikleri, [IParagraphFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat` aracılığıyla paragraf düzeyinde veya bireysel bölümler için [IPortionFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportionformat/) kullanılarak ayarlanabilir.

Aşağıdaki kod, **tüm paragraf** için yazı tipini ve metin stilini ayarlar: font boyutu, kalın, italik, noktalı alt çizgi ve Times New Roman tüm bölümlere uygulanır.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Paragraf için yazı tipi özelliklerini ayarla.
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
defaultPortionFormat->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Paragrafın yazı tipi özellikleri](font_properties_for_paragraph.png)

Aşağıdaki kod örneği, **kalın bir yazı tipine sahip metin bölümleri** için benzer özellikleri uygular:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // Metin bölümü için yazı tipi özelliklerini ayarla.
        portion->get_PortionFormat()->set_FontHeight(13.0f);
        portion->get_PortionFormat()->set_FontItalic(NullableBool::True);
        portion->get_PortionFormat()->set_FontUnderline(TextUnderlineType::Dotted);
        portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));
    }
}

presentation->Save(u"font_properties_for_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Metin bölümlerinin yazı tipi özellikleri](font_properties_for_text_portions.png)

## **Metin Döndürmeyi Ayarlama**

Şekil içinde önceden tanımlı bir metin yönelimi ayarlamak için [ITextFrameFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframeformat/)`.TextVerticalType` kullanın.

Aşağıdaki kod örneği, şekildeki metin yönelimini `Vertical270` olarak ayarlar; bu, metni **90 derece saat yönünün tersine** döndürür:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Metin döndürme](text_rotation.png)

## **Metin Çerçeveleri İçin Özel Döndürme Ayarlama**

[ITextFrameFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframeformat/)`.RotationAngle` kullanarak bir [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) için özel bir döndürme açısı belirleyin.

Aşağıdaki kod örneği, şekil içinde metin çerçevesini saat yönünde 3 derece döndürür:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_RotationAngle(3.0f);

presentation->Save(u"custom_text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Özel metin döndürme](custom_text_rotation.png)

## **Paragrafların Satır Aralığını Ayarlama**

Aspose.Slides, paragraf aralığını kontrol etmek için [IParagraphFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/)`.SpaceAfter`, `IParagraphFormat.SpaceBefore` ve `IParagraphFormat.SpaceWithin` sağlar. Bu özellikler şu şekilde kullanılır:

* Satır aralığını satır yüksekliğinin bir yüzdesi olarak belirtmek için pozitif bir değer kullanın.
* Satır aralığını puan cinsinden belirtmek için negatif bir değer kullanın.

Aşağıdaki kod örneği, paragraftaki satır aralığını nasıl belirteceğinizi gösterir:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_SpaceWithin(200.0f);

presentation->Save(u"line_spacing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Paragraftaki satır aralığı](line_spacing.png)

## **Metin Çerçeveleri İçin Otomatik Sığdırma Türünü Ayarlama**

[ITextFrameFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframeformat/)`.AutofitType` metnin kapsayıcısının sınırlarını aştığında nasıl davranacağını belirler. Metnin küçülmesi, taşması veya şeklin otomatik olarak yeniden boyutlandırılması gibi davranışları kontrol etmek için kullanın.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);

presentation->Save(u"autofit_type.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Metin Çerçevelerinin Bağlantı Noktasını Ayarlama**

[ITextFrameFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframeformat/)`.AnchoringType` metnin bir şekil içinde dikey olarak nasıl konumlandırılacağını tanımlar; örneğin üst, orta veya alt.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Bottom);

presentation->Save(u"text_anchor.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Metin Sekmeleri Ayarlama**

Paragrafta sekme duraklarını yapılandırmak için [IParagraphFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/)`.DefaultTabSize` ve `IParagraphFormat.Tabs` kullanın.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_DefaultTabSize(100.0f);
paragraph->get_ParagraphFormat()->get_Tabs()->Add(30.0f, TabAlignment::Left);

presentation->Save(u"paragraph_tabs.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Paragraf sekmeleri](paragraph_tabs.png)

## **Düzeltme Dili Ayarlama**

Aspose.Slides, bir metin bölümü için düzeltme dili ayarlamanıza olanak tanıyan [IPortionFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportionformat/)`.LanguageId` sağlar. Düzeltme dili, PowerPoint'teki yazım ve dilbilgisi denetimlerinde kullanılan dili belirler.

Aşağıdaki kod örneği, bir metin bölümü için düzeltme dilini nasıl ayarlayacağınızı gösterir:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto font = System::MakeObject<FontData>(u"SimSun");

auto textPortion = System::MakeObject<Portion>();
textPortion->get_PortionFormat()->set_ComplexScriptFont(font);
textPortion->get_PortionFormat()->set_EastAsianFont(font);
textPortion->get_PortionFormat()->set_LatinFont(font);

// Düzeltme dili kimliğini ayarla.
textPortion->get_PortionFormat()->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1.");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Varsayılan Dili Ayarlama**

[ILoadOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iloadoptions/)`.DefaultTextLanguage` kullanarak bir sunum yüklenirken veya oluşturulurken oluşturulan metin için varsayılan dili tanımlayın.

```cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);

// Yeni bir dikdörtgen şekil ekleyip metin belirleyin.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// İlk bölüm dilini kontrol edin.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
System::Console::WriteLine(portion->get_PortionFormat()->get_LanguageId());

presentation->Dispose();
```

## **Varsayılan Metin Stilini Ayarlama**

Sunum düzeyinde varsayılan metin biçimlendirmesi uygulamak için [IPresentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/)`.DefaultTextStyle` kullanın.

Aşağıdaki kod örneği, yeni bir sunumdaki tüm slaytlarda tüm metin için 14 pt boyutunda ve kalın bir varsayılan yazı tipi ayarlamayı gösterir.

```cpp
auto presentation = System::MakeObject<Presentation>();

// Üst düzey paragraf biçimini al.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != nullptr)
{
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14.0f);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"default_text_style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Büyük Harf Efektiyle Metin Çıkarma**

PowerPoint'te **All Caps** (Tüm Büyük Harfler) yazı tipi efekti uygulandığında, metin slaytta büyük harf olarak görünür, ancak aslen küçük harfle yazılmıştır. Aspose.Slides ile böyle bir metin bölümü alındığında, kütüphane metni tam olarak girildiği gibi döndürür. Görünen metinle eşleşmesi için [TextCapType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/textcaptype/) kontrol edin ve değer `All` olduğunda döndürülen dizeyi büyük harfe çevirin.

Örnek olarak, sample2.pptx dosyasının ilk slaytındaki aşağıdaki metin kutusunu ele alalım.

![All Caps efekti](all_caps_effect.png)

Aşağıdaki kod örneği, **All Caps** efekti uygulanmış metni nasıl çıkaracağınızı gösterir:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample2.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto textPortion = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);

System::Console::WriteLine(u"Original text: " + textPortion->get_Text());

auto textFormat = textPortion->get_PortionFormat()->GetEffective();
if (textFormat->get_TextCapType() == TextCapType::All)
{
    auto text = textPortion->get_Text().ToUpper();
    System::Console::WriteLine(u"All-Caps effect: " + text);
}

presentation->Dispose();
```

Çıktı:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **SSS**

**Bir slayttaki tabloda metni nasıl değiştiririm?**

Bir slayttaki tabloda metni değiştirmek için [ITable](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itable/) kullanın. Hücreleri dolaşın ve her hücreyi [ICell](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icell/)`.TextFrame` ve paragraf biçimlendirmesini [IParagraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraph/)`.ParagraphFormat` aracılığıyla güncelleyin.

**PowerPoint slaytındaki metne nasıl degrade (gradient) renk uygularım?**

Metne degrade renk uygulamak için [IPortionFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportionformat/)`.FillFormat` kullanın. [IFillFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifillformat/)`.FillType` değerini [FillType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/filltype/)`.Gradient` olarak ayarlayın ve degrade duraklarını, yönünü ve şeffaflığını yapılandırın.