---
title: "Matematikai egyenletek hozzáadása PowerPoint prezentációkhoz C++-ban"
linktitle: "PowerPoint Matematikai Egyenletek"
type: docs
weight: 80
url: /hu/cpp/powerpoint-math-equations/
keywords:
- matematikai egyenlet
- matematikai szimbólum
- matematikai képlet
- matematikai szöveg
- matematikai egyenlet hozzáadása
- matematikai szimbólum hozzáadása
- matematikai képlet hozzáadása
- matematikai szöveg hozzáadása
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Matematikai egyenletek beszúrása és szerkesztése PowerPoint PPT és PPTX fájlokban az Aspose.Slides for C++ segítségével, OMML támogatással, formázási vezérlőkkel és áttekinthető C++ kódpéldákkal."
---
## **Áttekintés**

A PowerPoint az egyenleteket Office Math Markup Language (OMML) formátumban tárolja. Az Aspose.Slides for C++ segítségével programozottan létrehozhatja ugyanazt a típusú matematikai tartalmat: törtek, gyökök, függvények, határértékek, N-áris operátorok, mátrixok, tömbök és formázott matematikai blokkok.

PowerPointben a felhasználók általában a **Beszúrás > Egyenlet** menüpontból adnak hozzá egyenleteket:

![PowerPoint Beszúrás lap az Egyenlet parancs kiválasztva](powerpoint-math-equations_1.png)

Az eredmény egy szerkeszthető matematikai szöveg a dián:

![Egy PowerPoint dia, amely szerkeszthető matematikai egyenletet tartalmaz](powerpoint-math-equations_2.png)

Az Aspose.Slides ezt a matematikai szöveget három fő objektumon keresztül építi fel:

- Egy matematikai alakzat, amelyet az [AddMathShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shapecollection/) hívásával hozunk létre, az az alakzat, amely az egyenletet tartalmazza.
- [MathPortion](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/mathportion/) tárolja a matematikai tartalmat az alakzat szövegkeretében.
- [MathParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/mathparagraph/) tartalmaz egy vagy több [MathBlock](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/mathblock/) objektumot.

Az alábbi legtöbb példa a [MathematicalText](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/mathematicaltext/) és az [IMathElement](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/imathelement/) folyékony metódusait használja a kód rövid és áttekinthető tartásához.

MathML export esetén lásd a [Export Math Equations from Presentations in C++](/slides/hu/cpp/exporting-math-equations/) oldalt.

## **Egyenlet létrehozása**

Ez a példa egy matematikai alakzatot hoz létre, és hozzáadja a Pitagorasz-tételt:

![Az egyenlet c² = a² + b²](powerpoint-math-equations_3.png)

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
`AddMathShape` egy olyan alakzatot hoz létre, amely már tartalmaz egy matematikai bekezdést. Az első `MathPortion`‑hez férünk hozzá, lekérjük annak `MathParagraph`‑ját, és hozzáadunk matematikai blokkokat vagy elemeket.
{{% /alert %}}

## **Törtek hozzáadása**

A `Divide` használatával hozhatunk létre egy törtet. A tört stílusát a [MathFractionTypes](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/mathfractiontypes/) segítségével választhatja ki.

![Egy ferde matematikai tört, amelyben 1 osztva x-szel](powerpoint-math-equations_4.png)

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

Halmozott tört esetén használja a `MathFractionTypes::Bar`-t:

```cpp
auto stackedFraction = System::MakeObject<MathematicalText>(u"x + 1")->Divide(u"y - 1", MathFractionTypes::Bar);
```

## **Gyökök hozzáadása**

A `Radical` használatával hozhat létre négyzetgyököt, köbgyököt vagy egyéb gyököt. Az aktuális elem lesz a kitevő, a paraméter pedig a gyök fokszáma.

![Egy n-dik gyök kifejezés, ahol az x a gyökjel alatt](powerpoint-math-equations_5.png)

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

## **Függvények és határértékek hozzáadása**

Függvényekhez, például `sin(x)`, `log(x)` vagy saját függvénynevekhez használja az `AsArgumentOfFunction` vagy `Function` metódusokat. Határértékekhez helyezze a `lim`-et egy [MathLimit](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/mathlimit/)-ba, vagy használja a `SetLowerLimit`‑et.

![x határértéke, amikor x a végtelen felé tart](powerpoint-math-equations_8.png)

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

Egy egyéni függvénynévhez tegye a függvénynevet az aktuális elemként:

```cpp
auto customFunction = System::MakeObject<MathematicalText>(u"f")->Function(u"x + 1");
```

## **N-áris operátorok és integrálok hozzáadása**

Összegzésekhez, uniókhoz, metszetekhez és egyéb nagy operátorokhoz használja a `Nary`‑t. Integrálokhoz a `Integral`‑t. Mindkét metódus lehetővé teszi a felső és alsó határok beállítását.

![Egy összegzés alsó és felső határokkal](powerpoint-math-equations_7.png)

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

Az N-áris operátorok nagy operátorok opcionális határokkal. Egyszerű operátorok, mint a `+`, `-` és `=` általában `MathematicalText`‑ként kerülnek hozzáadásra, és a kifejezésbe illesztésre.

Integrálhoz használja a `Integral`‑t:

```cpp
auto integralBase = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = integralBase->Integral(MathIntegralTypes::Simple, u"0", u"1");
```

## **Mátrixok hozzáadása**

Használja a [MathMatrix](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/mathmatrix/)‑t sorok és oszlopok definiálásához. A mátrixok alapértelmezés szerint nem tartalmaznak zárójeleket, ezért szükség esetén zárójelek, szögletes vagy kapcsos zárójelek közé kell helyezni őket.

![Két soros matematikai mátrix egy üres cellával](powerpoint-math-equations_10.png)

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

## **Egyenlet tömbök hozzáadása**

Használja a `ToMathArray`‑t, ha igazított egyenletekre vagy függőleges kifejezéscsoportra van szüksége.

![Függőleges matematikai tömb, ahol x a y felett helyezkedik el](powerpoint-math-equations_11.png)

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

## **Trigonometrikus függvények hozzáadása**

Használja az `AsArgumentOfFunction`‑t, amikor az argumentum az aktuális elem, és a függvény neve ismert.

![A trigonometrikus cos függvény alkalmazva 2x-re](powerpoint-math-equations_6.png)

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

## **Alsó és felső indexek hozzáadása**

Használja az alsó‑ és felső‑index segédfüggvényeket indexek és hatványok kezelésére. Ha az indexeknek a bázis bal oldalán kell megjelenniük, használja a `SetSubSuperscriptOnTheLeft`‑t.

![Nagy Y betű baloldali alsó indexszel 1 és felső indexszel n](powerpoint-math-equations_9.png)

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

## **Határoló jelek hozzáadása**

Használja az `Enclose`‑t kifejezések határoló jelek közé helyezéséhez. Több elemet tartalmazó határoló kifejezéseknél beállíthat egy elválasztó karaktert is.

![Egy határoló kifejezés, amely x, y és z-t függőleges vonalakkal választja el](powerpoint-math-equations_13.png)

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

## **Keretdoboz hozzáadása**

Használja a `ToBorderBox`‑t, ha magát az egyenletet be szeretné keretezni.

![Egy keretezett egyenlet, amely a² = b² + c²](powerpoint-math-equations_12.png)

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

## **Tagok csoportosítása**

Használja a `Group`‑ot, hogy egy csoportosító karaktert helyezzen a kifejezés fölé vagy alá. A csoportosított tagok megcímkézéséhez hozzáadhat egy határértéket.

![Az x + y kifejezés csoportosítva, alatta a „bármilyen szöveg” címkével](powerpoint-math-equations_15.png)

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

## **Matematikai elemek formázása**

Csak ott használjon formázó segédfüggvényeket, ahol az egyszerűsíti a képletet. Például az `Overbar` egy vonalat helyez egy elem fölé.

![Egy ABC matematikai kifejezés felülvonallal](powerpoint-math-equations_14.png)

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

## **Gyors referencia**

| Feladat | Fő API |
| --- | --- |
| Matematikai szöveg létrehozása | [MathematicalText](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/mathematicaltext/) |
| Elemek egyesítése | [IMathElement.Join](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/imathelement/join/) |
| Törtek létrehozása | [IMathElement.Divide](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/imathelement/divide/) |
| Felső vagy alsó index hozzáadása | [SetSuperscript](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/imathelement/setsubscript/) |
| Függvények hozzáadása | [Function](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Gyökök hozzáadása | [IMathElement.Radical](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/imathelement/radical/) |
| Határértékek hozzáadása | [SetLowerLimit](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Baloldali indexek hozzáadása | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Összegzések és integrálok hozzáadása | [Nary](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/imathelement/integral/) |
| Mátrixok hozzáadása | [MathMatrix](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/mathmatrix/) |
| Egyenlet tömbök hozzáadása | [ToMathArray](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/imathelement/tomatharray/) |
| Határoló jelek hozzáadása | [Enclose](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/imathelement/enclose/) |
| Vonalak és keretek hozzáadása | [Overbar](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/imathelement/toborderbox/) |
| Tagok csoportosítása | [Group](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/imathelement/group/) |

## **GYIK**

**Szerkeszthetek meglévő PowerPoint egyenletet?**

Igen. Nyissa meg a prezentációt, keresse meg azt az alakzatot, amely `MathPortion`‑t tartalmaz, szerezze meg a `MathParagraph`‑ját, és frissítse a bekezdésben lévő matematikai blokkokat.

**Az egyenletek szerkeszthető PowerPoint matematikaként vannak mentve?**

Igen. PPTX mentésekor az Aspose.Slides az egyenletet szerkeszthető Office matematikai tartalomként írja ki.

**Exportálhatok egyenleteket LaTeX‑be?**

Az Aspose.Slides a matematikai egyenleteket MathML‑be exportálja. Ha LaTeX‑ra van szüksége, először exportálja MathML‑be, majd egy olyan eszközzel konvertálja, amely támogatja a kívánt LaTeX‑dialektust.