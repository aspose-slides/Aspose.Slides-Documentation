---
title: गणितीय टेक्स्ट
type: docs
weight: 160
url: /hi/cpp/examples/elements/math-text/
keywords:
- कोड उदाहरण
- गणितीय टेक्स्ट
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ गणितीय टेक्स्ट उदाहरणों का अन्वेषण करें: C++ में PPT, PPTX, और ODP प्रस्तुतियों में समीकरण, अंश, मैट्रिक्स, और चिह्न बनाएं और फ़ॉर्मेट करें."
---
यह लेख **Aspose.Slides for C++** का उपयोग करके गणितीय टेक्स्ट आकारों के साथ काम करने और समीकरणों को फ़ॉर्मेट करने का प्रदर्शन करता है।

## **गणितीय टेक्स्ट जोड़ें**

एक गणितीय आकार बनाएं जिसमें अंश और पाइथागोरस सूत्र शामिल हो।

```cpp
static void AddMathText()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // स्लाइड में एक गणितीय आकार जोड़ें।
    auto mathShape = slide->get_Shapes()->AddMathShape(0, 0, 720, 150);

    // गणितीय पैराग्राफ तक पहुँचें।
    auto paragraph = mathShape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    auto mathParagraph = ExplicitCast<MathPortion>(textPortion)->get_MathParagraph();

    // एक सरल अंश जोड़ें: x / y।
    auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");
    mathParagraph->Add(MakeObject<MathBlock>(fraction));

    // समीकरण जोड़ें: c² = a² + b²।
    auto mathBlock = MakeObject<MathematicalText>(u"c")
        - >SetSuperscript(u"2")
        - >Join(u"=")
        - >Join(MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
        - >Join(u"+")
        - >Join(MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));
    mathParagraph->Add(mathBlock);

    presentation->Dispose();
}
```

## **गणितीय टेक्स्ट तक पहुँचें**

स्लाइड पर वह आकार खोजें जिसमें गणितीय पैराग्राफ हो।

```cpp
static void AccessMathText()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    // पहला आकार खोजें जिसमें गणितीय पैराग्राफ हो।
    auto mathShape = SharedPtr<IAutoShape>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto textFrame = autoShape->get_TextFrame();
            auto hasMath = false;
            for (auto&& paragraph : textFrame->get_Paragraphs())
            {
                for (auto&& textPortion : paragraph->get_Portions())
                {
                    if (ObjectExt::Is<MathPortion>(textPortion))
                    {
                        hasMath = true;
                        break;
                    }
                }
                if (hasMath) break;
            }
            if (hasMath)
            {
                mathShape = autoShape;
                break;
            }
        }
    }

    if (mathShape != nullptr)
    {
        auto paragraph = mathShape->get_TextFrame()->get_Paragraph(0);
        auto textPortion = paragraph->get_Portion(0);
        auto mathParagraph = ExplicitCast<MathPortion>(textPortion)->get_MathParagraph();

        // उदाहरण: एक अंश बनाएँ (यहाँ नहीं जोड़ा गया)।
        auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");

        // Use mathParagraph or fraction as needed...
    }

    presentation->Dispose();
}
```

## **गणितीय टेक्स्ट हटाएँ**

स्लाइड से एक गणितीय आकार हटाएँ।

```cpp
static void RemoveMathText()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto mathShape = slide->get_Shapes()->AddMathShape(50, 50, 100, 50);

    auto paragraph = mathShape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    auto mathParagraph = ExplicitCast<MathPortion>(textPortion)->get_MathParagraph();
    auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");
    mathParagraph->Add(MakeObject<MathBlock>(fraction));

    // गणितीय आकार हटाएँ।
    slide->get_Shapes()->Remove(mathShape);

    presentation->Dispose();
}
```

## **गणितीय टेक्स्ट को फ़ॉर्मेट करें**

गणितीय भाग के फ़ॉन्ट गुण सेट करें।

```cpp
static void FormatMathText()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto mathShape = slide->get_Shapes()->AddMathShape(50, 50, 100, 50);
    auto paragraph = mathShape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    auto mathParagraph = ExplicitCast<MathPortion>(textPortion)->get_MathParagraph();
    auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");
    mathParagraph->Add(MakeObject<MathBlock>(fraction));

    textPortion->get_PortionFormat()->set_FontHeight(20);

    presentation->Dispose();
}
```