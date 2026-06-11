---
title: Exportera matematiska ekvationer från presentationer i C++
linktitle: Exportera ekvationer
type: docs
weight: 30
url: /sv/cpp/exporting-math-equations/
keywords:
- exportera matematiska ekvationer
- MathML
- LaTeX
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lås upp sömlös export av matematiska ekvationer från PowerPoint till MathML med Aspose.Slides för C++ — bevara formatering och öka kompatibiliteten."
---
## **Introduction**

Aspose.Slides för C++ gör att du kan exportera matematiska ekvationer från presentationer. Till exempel kan du behöva extrahera de matematiska ekvationerna på bilder (från en specifik presentation) och använda dem i ett annat program eller plattform. 

{{% alert color="primary" %}} 
Du kan exportera ekvationer till MathML, ett populärt format eller standard för matematiska ekvationer och liknande innehåll som ses på webben och i många applikationer. 
{{% /alert %}}

## **Save Math Equations as MathML**

Medan människor enkelt skriver koden för vissa ekvationsformat som LaTeX har de svårigheter att skriva koden för MathML eftersom det senare är avsett att genereras automatiskt av appar. Program läser och tolkar MathML enkelt eftersom koden är i XML, så MathML används ofta som ett output‑ och utskriftsformat i många områden. 

Detta exempel visar hur du exporterar en matematisk ekvation från en presentation till MathML:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 500.0f, 50.0f);
auto mathPortion = System::ExplicitCast<IMathPortion>(autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0));
auto mathParagraph = mathPortion->get_MathParagraph();

mathParagraph->Add(System::MakeObject<MathematicalText>(u"a")
        - >SetSuperscript(u"2")
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"b")
                - >SetSuperscript(u"2"))
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"c")
                - >SetSuperscript(u"2")));

SharedPtr<Stream> stream = System::MakeObject<FileStream>(u"mathml.xml", FileMode::Create);

mathParagraph->WriteAsMathMl(stream);
```

## **FAQ**

**Vad exakt exporteras till MathML—ett stycke eller ett enskilt formelblock?**

Du kan exportera antingen ett helt matematiskt stycke ([MathParagraph](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/mathparagraph/)) eller ett enskilt block ([MathBlock](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/mathblock/)) till MathML. Båda typerna tillhandahåller en metod för att skriva till MathML.

**Hur kan jag avgöra att ett objekt på en bild är en matematikformel snarare än vanlig text eller en bild?**

En formel finns i en [MathPortion](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/mathportion/) och har ett [MathParagraph](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/mathparagraph/). Bilder och vanliga textdelar utan ett [MathParagraph](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/mathparagraph/) är inte exportbara formler.

**Var kommer MathML i en presentation ifrån—är det PowerPoint‑specifikt eller en standard?**

Exporten riktar sig mot standard‑MathML (XML). Aspose använder Presentation MathML—presentationsdelmängden av standarden—vilken är allmänt använd i många applikationer och på webben.

**Stöds export av formler i tabeller, SmartArt, grupper osv.?**

Ja, om dessa objekt innehåller textdelar med ett [MathParagraph](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/mathparagraph/) (dvs. äkta PowerPoint‑formler) exporteras de. Om en formel är inbäddad som en bild exporteras den inte.

**Modifierar export till MathML den ursprungliga presentationen?**

Nej. Att skriva MathML är en serialisering av formelns innehåll; det ändrar inte presentationsfilen.