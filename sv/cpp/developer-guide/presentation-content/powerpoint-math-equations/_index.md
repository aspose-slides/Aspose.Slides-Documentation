---
title: Lägg till matematiska ekvationer i PowerPoint-presentationer i C++
linktitle: PowerPoint-matematiska ekvationer
type: docs
weight: 80
url: /sv/cpp/powerpoint-math-equations/
keywords:
- matematisk ekvation
- matematisk symbol
- matematisk formel
- matematisk text
- lägg till matematisk ekvation
- lägg till matematisk symbol
- lägg till matematisk formel
- lägg till matematisk text
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Infoga och redigera matematiska ekvationer i PowerPoint PPT och PPTX med Aspose.Slides för C++, med stöd för OMML, formateringskontroller och tydliga C++-kodexempel."
---
## **Översikt**

PowerPoint lagrar ekvationer som Office Math Markup Language (OMML). Med Aspose.Slides för C++ kan du skapa samma typ av matematiskt innehåll programvarumässigt: bråktal, radikaler, funktioner, gränsvärden, N-ary‑operatorer, matriser, arrayer och formaterade matematikblock.

I PowerPoint lägger användare normalt till ekvationer från **Insert > Equation**:

![PowerPoint fliken Infoga med kommandot Ekvation markerat](powerpoint-math-equations_1.png)

Resultatet är redigerbar matematisk text på bilden:

![En PowerPoint‑bild som innehåller en redigerbar matematisk ekvation](powerpoint-math-equations_2.png)

Aspose.Slides bygger den matematiska texten genom tre huvudobjekt:

- En math shape, skapad med [AddMathShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shapecollection/), är formen som innehåller ekvationen.
- [MathPortion](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/mathportion/) lagrar matematikinnehåll i formens textruta.
- [MathParagraph](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/mathparagraph/) innehåller ett eller flera [MathBlock](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/mathblock/)-objekt.

De flesta exempel nedan använder [MathematicalText](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/mathematicaltext/) och de flytande metoderna från [IMathElement](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/imathelement/) för att hålla koden kort och läsbar.

För MathML‑exportscenarier, se [Export Math Equations from Presentations in C++](/slides/sv/cpp/exporting-math-equations/).

## **Skapa en ekvation**

Detta exempel skapar en math shape och lägger till Pythagoras sats:

![Ekvationen c kvadrat lika med a kvadrat plus b kvadrat](powerpoint-math-equations_3.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto equation = System::MakeObject<MathematicalText>(u"c")
        - >SetSuperscript(u"2")
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));

mathParagraph->Add(equation);

presentation->Save(u"pythagorean-theorem.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="primary" %}}
`AddMathShape` skapar en form som redan innehåller ett math paragraph. Åtkomst till den första `MathPortion`, hämta dess `MathParagraph` och lägg till matematikblock eller matteelement i den.
{{% /alert %}}

## **Lägg till bråktal**

Använd `Divide` för att skapa ett bråk. Du kan välja en bråktyp med [MathFractionTypes](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/mathfractiontypes/).

![Ett snedställt matematiskt bråk som visar en delat med x](powerpoint-math-equations_4.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto fraction = System::MakeObject<MathematicalText>(u"1")
        - >Divide(u"x", MathFractionTypes::Skewed);

mathParagraph->Add(System::MakeObject<MathBlock>(fraction));

presentation->Save(u"fraction.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

För ett staplat bråk, använd `MathFractionTypes::Bar`:

```cpp
auto stackedFraction = System::MakeObject<MathematicalText>(u"x + 1")->Divide(u"y - 1", MathFractionTypes::Bar);
```

## **Lägg till radikaler**

Använd `Radical` för att skapa en kvadratrot, kubrot eller annan rot. Det aktuella elementet blir basen och argumentet blir graden.

![Ett n‑te rotuttryck med x under radikaltecknet](powerpoint-math-equations_5.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto radical = System::MakeObject<MathematicalText>(u"x")
        - >Radical(u"n");

mathParagraph->Add(System::MakeObject<MathBlock>(radical));

presentation->Save(u"radical.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Lägg till funktioner och gränsvärden**

Använd `AsArgumentOfFunction` eller `Function` för funktioner som `sin(x)`, `log(x)` eller egna funktionsnamn. För gränsvärden, placera `lim` i en [MathLimit](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/mathlimit/) eller använd `SetLowerLimit`.

![Gränsvärdet för x när x närmar sig oändligheten](powerpoint-math-equations_8.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto limit = System::MakeObject<MathematicalText>(u"lim")
        - >SetLowerLimit(u"x→∞")
        - >Function(u"x");

mathParagraph->Add(System::MakeObject<MathBlock>(limit));

presentation->Save(u"functions-and-limits.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

För ett eget funktionsnamn, gör funktionsnamnet till det aktuella elementet:

```cpp
auto customFunction = System::MakeObject<MathematicalText>(u"f")->Function(u"x + 1");
```

## **Lägg till N-ary‑operatorer och integraler**

Använd `Nary` för summationer, unioner, snitt och andra stora operatorer. Använd `Integral` för integraler. Båda metoderna låter dig ange lägre och övre gränser.

![En summation med lägre och övre gränser](powerpoint-math-equations_7.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto summationBase = System::MakeObject<MathematicalText>(u"x")
        - >SetSuperscript(u"k")
        - >Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"n-k"));

auto summation = summationBase->Nary(MathNaryOperatorTypes::Summation, u"k=0", u"n");

mathParagraph->Add(System::MakeObject<MathBlock>(summation));

presentation->Save(u"nary-operators.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

N‑ary‑operatorer är för stora operatorer med valfria gränser. Enkla operatorer som `+`, `-` och `=` läggs vanligtvis till som `MathematicalText` och sammanfogas i uttrycket.

För en integral, använd `Integral`:

```cpp
auto integralBase = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = integralBase->Integral(MathIntegralTypes::Simple, u"0", u"1");
```

## **Lägg till matriser**

Använd [MathMatrix](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/mathmatrix/) för rader och kolumner. Matriser innehåller inte hakparenteser som standard, så omge matrixen när du behöver parenteser, hakparenteser eller klammerparenteser.

![En två‑radig matematikmatris med en tom cell](powerpoint-math-equations_10.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto matrix = System::MakeObject<MathMatrix>(2, 3);
matrix->idx_set(0, 0, System::MakeObject<MathematicalText>(u"1"));
matrix->idx_set(0, 1, System::MakeObject<MathematicalText>(u"x"));
matrix->idx_set(1, 0, System::MakeObject<MathematicalText>(u"x"));
matrix->idx_set(1, 1, System::MakeObject<MathematicalText>(u"2"));
matrix->idx_set(1, 2, System::MakeObject<MathematicalText>(u"y"));

mathParagraph->Add(System::MakeObject<MathBlock>(matrix));

presentation->Save(u"matrix.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Lägg till ekvationsarrayer**

Använd `ToMathArray` när du behöver justerade ekvationer eller en vertikal stapel av uttryck.

![En vertikal matematisk array med x ovanför y](powerpoint-math-equations_11.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 140.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto equationArray = System::MakeObject<MathematicalText>(u"x")
        - >Join(u"y")
        - >ToMathArray();

mathParagraph->Add(System::MakeObject<MathBlock>(equationArray));

presentation->Save(u"equation-array.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Lägg till trigonometriska funktioner**

Använd `AsArgumentOfFunction` när argumentet är det aktuella elementet och funktionsnamnet är känt.

![Den trigonometriska funktionen cos tillämpad på 2x](powerpoint-math-equations_6.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto cosine = System::MakeObject<MathematicalText>(u"2x")
        - >AsArgumentOfFunction(MathFunctionsOfOneArgument::Cos);

mathParagraph->Add(System::MakeObject<MathBlock>(cosine));

presentation->Save(u"trigonometric-function.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Lägg till nedsatta och upphöjda index**

Använd hjälparfunktionerna för nedsatta och upphöjda index för index och potenser. När indexen måste visas på vänster sida av basen, använd `SetSubSuperscriptOnTheLeft`.

![En versal Y med vänster‑sida nedsatt index 1 och upphöjt index n](powerpoint-math-equations_9.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto scripts = System::MakeObject<MathematicalText>(u"Y")
        - >SetSubSuperscriptOnTheLeft(u"1", u"n");

mathParagraph->Add(System::MakeObject<MathBlock>(scripts));

presentation->Save(u"subscript-superscript.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Lägg till avgränsare**

Använd `Enclose` för att placera ett uttryck inom avgränsare. Du kan också ange ett separator‑tecken för avgränsade uttryck som innehåller flera element.

![Ett avgränsning‑uttryck som innehåller x, y och z separerade med vertikala streck](powerpoint-math-equations_13.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto delimiter = System::MakeObject<MathematicalText>(u"x")
        - >Join(u"y")
        - >Join(u"z")
        - >Enclose(u'<', u'>', u'|');

mathParagraph->Add(System::MakeObject<MathBlock>(delimiter));

presentation->Save(u"delimiters.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Lägg till en kantlåda**

Använd `ToBorderBox` när ekvationen själv ska ramas in.

![En inramad ekvation som visar a kvadrat lika med b kvadrat plus c kvadrat](powerpoint-math-equations_12.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto boxedEquation = System::MakeObject<MathematicalText>(u"a")
        - >SetSuperscript(u"2")
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"))
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"c")->SetSuperscript(u"2"))
        - >ToBorderBox();

mathParagraph->Add(System::MakeObject<MathBlock>(boxedEquation));

presentation->Save(u"border-box.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Gruppera termer**

Använd `Group` för att placera ett grupperingstecken över eller under ett uttryck. Lägg till en gräns för att märka de grupperade termerna.

![Uttrycket x plus y grupperat med etiketten någon text under det](powerpoint-math-equations_15.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto grouped = System::MakeObject<MathematicalText>(u"x + y")
        - >Group(u'\u23DF', MathTopBotPositions::Bottom, MathTopBotPositions::Top)
        - >SetLowerLimit(u"any text");

mathParagraph->Add(System::MakeObject<MathBlock>(grouped));

presentation->Save(u"grouped-terms.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Formatera matteelement**

Använd formateringshjälpmedel endast där de förtydligar formeln. Till exempel placerar `Overbar` ett streck ovanför ett matteelement.

![Ett matematiskt uttryck ABC med ett överstreck](powerpoint-math-equations_14.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto overbar = System::MakeObject<MathematicalText>(u"ABC")->Overbar();

mathParagraph->Add(System::MakeObject<MathBlock>(overbar));

presentation->Save(u"overbar.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Snabbreferens**

| Uppgift | Huvud‑API |
| --- | --- |
| Skapa matematiktext | [MathematicalText](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/mathematicaltext/) |
| Kombinera element | [IMathElement.Join](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/imathelement/join/) |
| Skapa bråk | [IMathElement.Divide](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/imathelement/divide/) |
| Lägg till upphöjt eller nedsatt index | [SetSuperscript](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/imathelement/setsubscript/) |
| Lägg till funktioner | [Function](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Lägg till radikaler | [IMathElement.Radical](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/imathelement/radical/) |
| Lägg till gränsvärden | [SetLowerLimit](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Lägg till skript på vänster sida | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Lägg till summationer och integraler | [Nary](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/imathelement/integral/) |
| Lägg till matriser | [MathMatrix](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/mathmatrix/) |
| Lägg till ekvationsarrayer | [ToMathArray](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/imathelement/tomatharray/) |
| Lägg till avgränsare | [Enclose](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/imathelement/enclose/) |
| Lägg till streck och ramar | [Overbar](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/imathelement/toborderbox/) |
| Gruppera termer | [Group](https://reference.aspose.com/slides/sv/cpp/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**Kan jag redigera en befintlig PowerPoint‑ekvation?**

Ja. Öppna presentationen, hitta formen som innehåller en `MathPortion`, hämta dess `MathParagraph` och uppdatera math‑blocken i det paragrafen.

**Sparas ekvationer som redigerbar PowerPoint‑matematik?**

Ja. När du sparar till PPTX skriver Aspose.Slides ekvationen som redigerbart Office‑math‑innehåll.

**Kan jag exportera ekvationer till LaTeX?**

Aspose.Slides exporterar matematiska ekvationer till MathML. Om du behöver LaTeX, exportera först till MathML och konvertera sedan MathML med ett verktyg som stöder ditt mål‑LaTeX‑dialekt.