---
title: Přidání matematických rovnic do prezentací PowerPoint v C++
linktitle: Matematické rovnice PowerPoint
type: docs
weight: 80
url: /cs/cpp/powerpoint-math-equations/
keywords:
- matematická rovnice
- matematický symbol
- matematický vzorec
- matematický text
- přidat matematickou rovnici
- přidat matematický symbol
- přidat matematický vzorec
- přidat matematický text
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Vkládejte a upravujte matematické rovnice v PowerPoint PPT a PPTX pomocí Aspose.Slides pro C++, s podporou OMML, ovládacích prvků formátování a přehlednými ukázkami kódu v C++."
---
## **Přehled**

PowerPoint uchovává rovnice jako Office Math Markup Language (OMML). S Aspose.Slides pro C++ můžete programově vytvářet stejný typ matematického obsahu: zlomky, odmocniny, funkce, limity, n‑aritmetické operátory, matice, pole a formátované matematické bloky.

V PowerPointu uživatelé obvykle přidávají rovnice z **Insert > Equation**:

![Karta Vložení v PowerPointu s vybraným příkazem Rovnice](powerpoint-math-equations_1.png)

Výsledkem je editovatelný matematický text na snímku:

![Snímek PowerPointu obsahující editovatelnou matematickou rovnici](powerpoint-math-equations_2.png)

Aspose.Slides vytváří tento matematický text pomocí tří hlavních objektů:

- Matematický tvar, vytvořený pomocí [AddMathShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shapecollection/), je tvar, který obsahuje rovnici.
- [MathPortion](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/mathportion/) ukládá matematický obsah uvnitř textového rámce tvaru.
- [MathParagraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/mathparagraph/) obsahuje jeden nebo více objektů [MathBlock](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/mathblock/).

Většina příkladů níže používá [MathematicalText](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/mathematicaltext/) a řetězené metody z [IMathElement](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/imathelement/) pro stručnost a čitelnost kódu.

Pro scénáře exportu MathML viz [Exportovat matematické rovnice z prezentací v C++](/slides/cs/cpp/exporting-math-equations/).

## **Vytvořit rovnici**

Tento příklad vytvoří matematický tvar a přidá Pythagorovu větu:

![Rovnice c na druhou rovná se a na druhou plus b na druhou](powerpoint-math-equations_3.png)

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
`AddMathShape` vytváří tvar, který již obsahuje matematický odstavec. Získejte první `MathPortion`, jeho `MathParagraph` a přidejte do něj matematické bloky nebo matematické elementy.
{{% /alert %}}

## **Přidat zlomky**

Použijte `Divide` k vytvoření zlomku. Můžete zvolit styl zlomku pomocí [MathFractionTypes](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/mathfractiontypes/).

![Zkosený matematický zlomek zobrazující 1 děleno x](powerpoint-math-equations_4.png)

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

Pro skladaný zlomek použijte `MathFractionTypes::Bar`:

```cpp
auto stackedFraction = System::MakeObject<MathematicalText>(u"x + 1")->Divide(u"y - 1", MathFractionTypes::Bar);
```

## **Přidat odmocniny**

Použijte `Radical` k vytvoření druhé odmocniny, třetí odmocniny nebo jiné odmocniny. Aktuální element se stane základem a argument představuje stupeň.

![Výraz n‑tá odmocnina s x pod znakem odmocniny](powerpoint-math-equations_5.png)

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

## **Přidat funkce a limity**

Použijte `AsArgumentOfFunction` nebo `Function` pro funkce jako `sin(x)`, `log(x)` nebo vlastní názvy funkcí. Pro limity umístěte `lim` do [MathLimit](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/mathlimit/) nebo použijte `SetLowerLimit`.

![Limit x, když x směřuje k nekonečnu](powerpoint-math-equations_8.png)

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

Pro vlastní název funkce nastavte název funkce jako aktuální element:

```cpp
auto customFunction = System::MakeObject<MathematicalText>(u"f")->Function(u"x + 1");
```

## **Přidat N‑aritmetické operátory a integrály**

Použijte `Nary` pro součty, sjednocení, průniky a další velké operátory. Použijte `Integral` pro integrály. Obě metody umožňují nastavit dolní a horní limity.

![Součet s dolní a horní limitou](powerpoint-math-equations_7.png)

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

N‑aritmetické operátory slouží pro velké operátory s volitelnými limity. Jednoduché operátory jako `+`, `-` a `=` se obvykle přidávají jako `MathematicalText` a spojují do výrazu.

Pro integrál použijte `Integral`:

```cpp
auto integralBase = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = integralBase->Integral(MathIntegralTypes::Simple, u"0", u"1");
```

## **Přidat matice**

Použijte [MathMatrix](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/mathmatrix/) pro řádky a sloupce. Matice ve výchozím nastavení neobsahují závorky, proto je obalte, když potřebujete závorky, hranaté závorky nebo složené závorky.

![Matematická matice se dvěma řádky a jednou prázdnou buňkou](powerpoint-math-equations_10.png)

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

## **Přidat pole rovnic**

Použijte `ToMathArray`, když potřebujete zarovnané rovnice nebo svislý zásobník výrazů.

![Svislé matematické pole s x nad y](powerpoint-math-equations_11.png)

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

## **Přidat trigonometrické funkce**

Použijte `AsArgumentOfFunction`, když je argument aktuální element a název funkce je znám.

![Trigonometrická funkce cos aplikovaná na 2x](powerpoint-math-equations_6.png)

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

## **Přidat dolní a horní indexy**

Použijte pomocníky pro dolní a horní indexy pro indexy a mocniny. Když se indexy musí zobrazit na levé straně základu, použijte `SetSubSuperscriptOnTheLeft`.

![Velké Y s levým dolním indexem 1 a horním indexem n](powerpoint-math-equations_9.png)

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

## **Přidat ohraničovače**

Použijte `Enclose` k umístění výrazu do ohraničovačů. Můžete také nastavit znak oddělovače pro výrazy s ohraničovači, které obsahují několik elementů.

![Výraz ohraničovače obsahující x, y a z oddělené svislými pruhy](powerpoint-math-equations_13.png)

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

## **Přidat rámeček**

Použijte `ToBorderBox`, když má být samotná rovnice ohraničena rámečkem.

![Rovnice v rámečku zobrazující a na druhou rovná se b na druhou plus c na druhou](powerpoint-math-equations_12.png)

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

## **Seskupit termíny**

Použijte `Group` k umístění seskupovacího znaku nad nebo pod výraz. Přidejte limit pro popisek seskupených termínů.

![Výraz x plus y seskupený s popiskem libovolného textu pod ním](powerpoint-math-equations_15.png)

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

## **Formátovat matematické elementy**

Používejte pomocníky formátování jen tam, kde objasňují vzorec. Například `Overbar` umístí čáru nad matematický element.

![Matematický výraz ABC s nadčarou](powerpoint-math-equations_14.png)

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

## **Rychlý odkaz**

| Úkol | Hlavní API |
| --- | --- |
| Vytvořit matematický text | [MathematicalText](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/mathematicaltext/) |
| Kombinovat elementy | [IMathElement.Join](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/imathelement/join/) |
| Vytvořit zlomky | [IMathElement.Divide](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/imathelement/divide/) |
| Přidat horní nebo dolní index | [SetSuperscript](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/imathelement/setsubscript/) |
| Přidat funkce | [Function](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Přidat odmocniny | [IMathElement.Radical](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/imathelement/radical/) |
| Přidat limity | [SetLowerLimit](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Přidat levé indexy | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Přidat součty a integrály | [Nary](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/imathelement/integral/) |
| Přidat matice | [MathMatrix](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/mathmatrix/) |
| Přidat pole rovnic | [ToMathArray](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/imathelement/tomatharray/) |
| Přidat ohraničovače | [Enclose](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/imathelement/enclose/) |
| Přidat čáry a rámečky | [Overbar](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/imathelement/toborderbox/) |
| Seskupit termíny | [Group](https://reference.aspose.com/slides/cs/cpp/aspose.slides.mathtext/imathelement/group/) |

## **Často kladené otázky**

**Mohu upravit existující rovnici v PowerPointu?**

Ano. Otevřete prezentaci, najděte tvar, který obsahuje `MathPortion`, získejte jeho `MathParagraph` a aktualizujte matematické bloky v tomto odstavci.

**Ukládají se rovnice jako editovatelná matematika v PowerPointu?**

Ano. Při ukládání do PPTX Aspose.Slides zapisuje rovnici jako editovatelný obsah Office math.

**Mohu exportovat rovnice do LaTeXu?**

Aspose.Slides exportuje matematické rovnice do MathML. Pokud potřebujete LaTeX, nejprve exportujte do MathML a poté jej převěďte pomocí nástroje, který podporuje požadovaný LaTeX dialekt.