---
title: Matematika egyenletek hozzáadása PowerPoint prezentációkhoz C++-ban
linktitle: PowerPoint matematikai egyenletek
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
description: "Matematikai egyenletek beszúrása és szerkesztése PowerPoint PPT és PPTX fájlokban az Aspose.Slides for C++ segítségével, támogatva az OMML-t, a formázási vezérléseket és világos C++ kódpéldákat."
---
## **Áttekintés**

A PowerPoint egyenleteket Office Math Markup Language (OMML) formátumban tárolja. Az Aspose.Slides for C++ segítségével programozottan hozhat létre ugyanilyen matematikai tartalmakat: törtöket, gyököket, függvényeket, határokat, N‑áris operátorokat, mátrixokat, tömböket és formázott matematikai blokkokat.

PowerPointban a felhasználók általában az **Insert > Equation** menüpontból adnak hozzá egyenleteket:

![PowerPoint beillesztés fül a Képlet parancs kiválasztva](powerpoint-math-equations_1.png)

Az eredmény egy szerkeszthető matematikai szöveg a dián:

![PowerPoint dia szerkeszthető matematikai egyenlettel](powerpoint-math-equations_2.png)

Az Aspose.Slides a matematikai szöveget három fő objektumon keresztül építi fel:

- Egy matematikai alakzat, amelyet a [AddMathShape](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/) segítségével hozunk létre, az az alakzat, amely az egyenletet tartalmazza.
- A [MathPortion](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/) tárolja a matematikai tartalmat az alakzat szövegkeretében.
- A [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) egy vagy több [MathBlock](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/) objektumot tartalmaz.

Az alábbi legtöbb példa a [MathematicalText](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathematicaltext/) és az [IMathElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/) folyékony metódusait használja, hogy a kód rövid és olvasható legyen.

MathML export szituációkhoz lásd a [Export Math Equations from Presentations in C++](/slides/hu/cpp/exporting-math-equations/) cikket.

## **Egyenlet létrehozása**

Ez a példa a [AddMathShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addmathshape/) segítségével hoz létre egy matematikai alakzatot, és a pitagóré-tételt adja hozzá:

![c² = a² + b² képlet](powerpoint-math-equations_3.png)

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathBlock.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/IMathSuperscriptElement.h>
#include <DOM/MathText/MathPortion.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

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

{{% alert color="info" title="Note" %}}
[AddMathShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addmathshape/) egy olyan alakzatot hoz létre, amely már tartalmaz egy matematikai bekezdést. Hozzáférhet az első [MathPortion](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/)-hoz, meghívja a [get_MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/get_mathparagraph/)-t, és hozzáadhat matematikai blokkokat vagy elemeket.
{{% /alert %}}

## **Törtek hozzáadása**

Használja a [Divide](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/divide/) metódust törtként való létrehozáshoz. A törttípus kiválasztható a [MathFractionTypes](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfractiontypes/) segítségével.

![Egy ferde törtkép, amelyben az 1 osztva x‑szel látható](powerpoint-math-equations_4.png)

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/MathBlock.h>
#include <DOM/MathText/MathFractionTypes.h>
#include <DOM/MathText/MathPortion.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

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

Összeállított törthöz használja a [MathFractionTypes::Bar](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfractiontypes/) elemet:

```cpp
#include <DOM/MathText/MathFractionTypes.h>
#include <DOM/MathText/MathematicalText.h>
using namespace Aspose::Slides::MathText;

auto stackedFraction = System::MakeObject<MathematicalText>(u"x + 1")->Divide(u"y - 1", MathFractionTypes::Bar);
```

## **Gyökök hozzáadása**

Használja a [Radical](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/radical/) metódust négyzetgyök, köbgyök vagy egyéb gyök létrehozásához. A jelenlegi elem a gyök alapja, a paraméter pedig a gyök fokszáma lesz.

![Egy n‑edik gyök kifejezés, ahol az x a gyökjel alá van helyezve](powerpoint-math-equations_5.png)

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/MathBlock.h>
#include <DOM/MathText/MathPortion.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

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

### **A négyzetgyök fokszámának megjelenítése vagy elrejtése**

A négyzetgyök megjelenítheti a kifejezett 2‑t, vagy használhatja a hagyományos √x jelölést. Az [IMathRadical::set_HideDegree](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathradical/set_hidedegree/) segítségével válthat a két forma között. Mindkettő megőrzi a 2 fokszámot és a radikandus x‑et a szerkeszthető egyenletben.

![Ugyanaz a négyzetgyök, bal oldalon a fokszám látható, jobb oldalon elrejtett](square-root-degree.png)

A példa kétszer menti ugyanazt a négyzetgyököt. A `visible-degree.pptx` fájlban a 2 látható, a `hidden-degree.pptx` fájlban el van rejtve.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathRadical.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/MathBlock.h>
#include <DOM/MathText/MathPortion.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto radicand = System::MakeObject<MathematicalText>(u"x");
auto radical = radicand->Radical(u"2");
auto block = System::MakeObject<MathBlock>(radical);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 200.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();
mathParagraph->Add(block);

radical->set_HideDegree(false);
presentation->Save(u"visible-degree.pptx", SaveFormat::Pptx);

radical->set_HideDegree(true);
presentation->Save(u"hidden-degree.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Függvények és határok hozzáadása**

Használja az [AsArgumentOfFunction](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/) vagy a [Function](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/function/) metódust olyan függvényekhez, mint a `sin(x)`, `log(x)` vagy egyedi függvénynevek. Határokhoz helyezze a `lim` kifejezést egy [MathLimit](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathlimit/) belsejébe, vagy használja a [SetLowerLimit](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setlowerlimit/)‑t.

![Az x határa, amikor x a végtelenhez tart](powerpoint-math-equations_8.png)

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathLimit.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/MathBlock.h>
#include <DOM/MathText/MathPortion.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

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

Egyedi függvénynév esetén a függvény neve legyen a jelenlegi elem, majd hívja a [Function](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/function/)‑t a paraméterével:

```cpp
#include <DOM/MathText/MathematicalText.h>
using namespace Aspose::Slides::MathText;

auto customFunction = System::MakeObject<MathematicalText>(u"f")->Function(u"x + 1");
```

## **N‑áris operátorok és integrálok hozzáadása**

Használja a [Nary](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/nary/) metódust összegeknél, unióknál, metszetknél és egyéb nagy operátoroknál. Az integrálokhoz használja a [Integral](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/)‑t. Mindkét módszer lehetővé teszi az alsó és felső határ megadását.

![Összegzés alsó és felső határral](powerpoint-math-equations_7.png)

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/IMathSuperscriptElement.h>
#include <DOM/MathText/MathBlock.h>
#include <DOM/MathText/MathNaryOperatorTypes.h>
#include <DOM/MathText/MathPortion.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

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

Az N‑áris operátorok nagy operátorok opcionális határokkal. Egyszerű operátorok, mint a `+`, `-` és `=` általában a [MathematicalText](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathematicaltext/)‑el kerülnek beillesztésre, majd a kifejezésbe fűzve.

Integrálhoz használja a [Integral](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/)‑t:

```cpp
#include <DOM/MathText/IMathBlock.h>
#include <DOM/MathText/IMathBox.h>
#include <DOM/MathText/IMathElement.h>
#include <DOM/MathText/MathIntegralTypes.h>
#include <DOM/MathText/MathematicalText.h>

using namespace Aspose::Slides::MathText;

auto integralBase = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = integralBase->Integral(MathIntegralTypes::Simple, u"0", u"1");
```

## **Mátrixok hozzáadása**

Használja a [MathMatrix](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathmatrix/)‑t sorok és oszlopok definiálásához. A mátrixok alapértelmezésben nem tartalmaznak zárójeleket, ezért szükség esetén zárójelek, szögletes zárójelek vagy kapcsos zárójelek közé kell helyezni őket.

![Két soros matematikai mátrix egy üres cellával](powerpoint-math-equations_10.png)

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathBlock.h>
#include <DOM/MathText/IMathElement.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/MathBlock.h>
#include <DOM/MathText/MathMatrix.h>
#include <DOM/MathText/MathPortion.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

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

### **Meglévő mátrix szerkesztése**

Tegyük fel, hogy egy lineáris algebra óra a `matrix.pptx` fájlban lévő koefficiens mátrixszal kezdődik, amelyet az előző példa mentett. A következő feladatnál meg akarja tartani az első egyenletet, a másodikat két újra cserélni, és a változók halmazát módosítani. Nyissa meg a meglévő mátrixot az [IMathMatrix](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathmatrix/) segítségével, hogy megtartsa a még alkalmazható koefficienseket.

![Eredeti két soros koefficiens mátrix 1, x, üres cella az első sorban és x, 2, y a második sorban](matrix-before-edit.png)

A sor‑ és oszlopindexek nulláról indulnak, és a mátrix aktuális állapotára vonatkoznak minden hívásnál. Sor beszúrása az 1‑es index előtt az eredeti második sort a 2‑es indexre helyezi. Beszúrás az 2‑es index után új sort ad hozzá. A 2‑es sor törlése eltávolítja az eredeti második egyenletet, és a hozzáadott sort egy hellyel feljebb mozgatja. Az oszlopok ugyanígy eltolódnak.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathBlock.h>
#include <DOM/MathText/IMathElement.h>
#include <DOM/MathText/IMathMatrix.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/IMathPortion.h>
#include <DOM/MathText/MathHorizontalAlignment.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

auto presentation = System::MakeObject<Presentation>(u"matrix.pptx");

auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto portion = System::ExplicitCast<IMathPortion>(shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto block = portion->get_MathParagraph()->idx_get(0);
auto matrix = System::ExplicitCast<IMathMatrix>(block->idx_get(0));

matrix->InsertRowBefore(1);
matrix->InsertRowAfter(2);
matrix->DeleteRow(2);

matrix->InsertColumnBefore(1);
matrix->InsertColumnAfter(3);
matrix->DeleteColumn(3);

// Az új cellák kezdetben null értékűek. Először állítsa be a nemnulla együtthatókat.
matrix->idx_set(1, 0, System::MakeObject<MathematicalText>(u"12"));
matrix->idx_set(1, 1, System::MakeObject<MathematicalText>(u"1"));
matrix->idx_set(2, 2, System::MakeObject<MathematicalText>(u"10"));
matrix->idx_set(2, 3, System::MakeObject<MathematicalText>(u"1"));
for (auto row = 0; row < matrix->get_RowCount(); ++row)
{
    for (auto column = 0; column < matrix->get_ColumnCount(); ++column)
    {
        if (matrix->idx_get(row, column) == nullptr)
            matrix->idx_set(row, column, System::MakeObject<MathematicalText>(u"0"));
    }
}

matrix->SetColumnAlignment(0, MathHorizontalAlignment::Left);
matrix->SetColumnsAlignment(1, 3, MathHorizontalAlignment::Right);

presentation->Save(u"updated-matrix.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[SetColumnAlignment](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathmatrix/setcolumnalignment/) balra igazítja az első oszlopot. [SetColumnsAlignment](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathmatrix/setcolumnsalignment/) három egymást követő oszlopot jobbra igazít index 1‑től kezdve. A `updated-matrix.pptx` fájlban a mátrix három egyenletet és négy változót tartalmaz. Az eredeti első sor koefficiensei, a `1` és az `x`, most az első és a harmadik oszlopban jelennek meg.

![Frissített három soros mátrix, sorok: 1, 0, x, 0; 12, 1, 0, 0; és 0, 0, 10, 1](matrix-after-edit.png)

## **Egyenlet tömbök hozzáadása**

Használja a [ToMathArray](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/tomatharray/)‑t, ha egymáshoz igazított egyenletekre vagy függőleges kifejezéskörre van szüksége.

![Függőleges matematikai tömb, x felül, y alul](powerpoint-math-equations_11.png)

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/MathBlock.h>
#include <DOM/MathText/MathPortion.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

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

### **Tömb igazítása a környező elemekkel**

[IMathArray::set_BaseJustification](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imatharray/set_basejustification/) szabályozza a tömb függőleges igazítását a mellette lévő matematikai elemekhez képest. Az alábbi példa összehasonlítja az igazítást az első sor, a tömb közepe és az utolsó sor szerint.

A következő példa három azonos tömböt hoz létre, mindegyik három soros, és a szomszédos elemek `A=` és `=B`. Minden matematikai szöveg a Cambria Math betűtípussal, 24 pont mérettel jelenik meg. Csak a tömb igazítása változik.

```cpp
#include <system/array.h>
#include <system/console.h>
#include <drawing/color.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/MathArray.h>
#include <DOM/MathText/MathBlock.h>
#include <DOM/MathText/MathJustification.h>
#include <DOM/MathText/MathPortion.h>
#include <DOM/MathText/MathVerticalAlignment.h>
#include <DOM/MathText/MathRowSpacingRule.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/ISlideSize.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/TextAnchorType.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

auto createText = [](System::String value)
{
    auto text = System::MakeObject<MathematicalText>(value);
    text->get_Format()->set_FontHeight(24);
    auto font = System::MakeObject<FontData>(u"Cambria Math");
    text->get_Format()->set_LatinFont(font);
    return text;
};

auto presentation = System::MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(780, 200, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

MathVerticalAlignment alignments[] = {MathVerticalAlignment::Top, MathVerticalAlignment::Center, MathVerticalAlignment::Bottom};
System::String labels[] = {u"Top", u"Center", u"Bottom"};

for (auto i = 0; i < 3; i++)
{
    auto label = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20 + i * 260, 10, 240, 30);
    label->get_FillFormat()->set_FillType(FillType::NoFill);
    label->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
    label->get_TextFrame()->set_Text(labels[i]);
    auto labelFormat = label->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
    labelFormat->set_FontHeight(16);
    labelFormat->get_FillFormat()->set_FillType(FillType::Solid);
    labelFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

    auto mathShape = slide->get_Shapes()->AddMathShape(20 + i * 260, 60, 240, 130);
    mathShape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Top);
    auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
    auto mathParagraph = mathPortion->get_MathParagraph();
    mathParagraph->set_Justification(MathJustification::LeftJustified);

    auto rows = System::MakeArray<System::SharedPtr<IMathElement>>({createText(u"x+y=3"), createText(u"x-y=1"), createText(u"x=2")});
    auto equationArray = System::MakeObject<MathArray>(rows);
    equationArray->set_BaseJustification(alignments[i]);
    auto leftText = createText(u"A=");
    auto rightText = createText(u"=B");
    auto equation = System::MakeObject<MathBlock>(leftText)->Join(equationArray)->Join(rightText);
    mathParagraph->Add(equation);
}

presentation->Save(u"equation-array-alignment.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az alábbi összehasonlítás a PowerPointban mentett prezentációt mutatja. Figyelje meg az `A=` és `=B` pozícióját minden tömb mellett.

![Egyenlet tömbök PowerPointban felső, középső és alsó igazítással, azonos szomszédos elemekkel](equation-array-alignment.png)

### **Sorok távolságának beállítása**

[set_RowSpacingRule](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imatharray/set_rowspacingrule/) kiválasztja a sorok közti távolság szabályát a tömbön belül. [set_RowSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imatharray/set_rowspacing/) numerikus értéket ad egy kifejezett távolságszabálynak, és a beépített szabályok figyelmen kívül hagyják.

A pontos távolság pontban van megadva. Az arányos távolság fél sorban van mérve: a példában a `3` érték 1,5 sort jelent. Mindkét beállítót hívja meg kifejezett érték megadásakor; csak a numerikus érték módosítása nem választ szabályt.

Az alábbi példa öt prezentációt ment azonos egyenletekkel, igazítással és betűtípusbeállítással. Az első három beépített szabályt használ, az utolsó kettő kifejezett értékeket mutat.

```cpp
#include <system/array.h>
#include <system/console.h>
#include <drawing/color.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/MathArray.h>
#include <DOM/MathText/MathBlock.h>
#include <DOM/MathText/MathJustification.h>
#include <DOM/MathText/MathPortion.h>
#include <DOM/MathText/MathVerticalAlignment.h>
#include <DOM/MathText/MathRowSpacingRule.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

auto createText = [](System::String value)
{
    auto text = System::MakeObject<MathematicalText>(value);
    text->get_Format()->set_FontHeight(24);
    auto font = System::MakeObject<FontData>(u"Cambria Math");
    text->get_Format()->set_LatinFont(font);
    return text;
};

struct ArraySettings
{
    MathRowSpacingRule rule;
    uint32_t spacing;
    System::String name;
};

ArraySettings settings[] =
{
    {MathRowSpacingRule::SingleLineGap, 0, u"SingleLineGap"},
    {MathRowSpacingRule::OneAndAHalfLineGap, 0, u"OneAndAHalfLineGap"},
    {MathRowSpacingRule::TwoLineGap, 0, u"TwoLineGap"},
    {MathRowSpacingRule::Exactly, 20, u"Exactly"},
    {MathRowSpacingRule::Multiple, 3, u"Multiple"}
};

for (const auto& setting : settings)
{
    auto fileName = u"equation-array-" + setting.name + u".pptx";
    auto presentation = System::MakeObject<Presentation>();
    auto mathShape = presentation->get_Slide(0)->get_Shapes()->AddMathShape(20, 20, 600, 300);
    auto paragraph = mathShape->get_TextFrame()->get_Paragraph(0);
    paragraph->get_ParagraphFormat()->set_SpaceBefore(0);
    paragraph->get_ParagraphFormat()->set_SpaceAfter(0);
    auto mathPortion = System::ExplicitCast<MathPortion>(paragraph->get_Portion(0));
    auto mathParagraph = mathPortion->get_MathParagraph();
    mathParagraph->set_Justification(MathJustification::LeftJustified);

    auto rows = System::MakeArray<System::SharedPtr<IMathElement>>({createText(u"x+y=3"), createText(u"x-y=1"), createText(u"x=2")});
    auto equationArray = System::MakeObject<MathArray>(rows);
    equationArray->set_BaseJustification(MathVerticalAlignment::Center);
    equationArray->set_RowSpacingRule(setting.rule);
    equationArray->set_RowSpacing(setting.spacing);
    auto leftText = createText(u"A=");
    auto rightText = createText(u"=B");
    auto equation = System::MakeObject<MathBlock>(leftText)->Join(equationArray)->Join(rightText);
    mathParagraph->Add(equation);

    presentation->Save(fileName, SaveFormat::Pptx);
    presentation->Dispose();
}
```

A tömb sorok közti távolsága különbözik a bekezdés távolságától. A [set_SpaceBefore](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spacebefore/) és a [set_SpaceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spaceafter/) a tartalmazó bekezdés körül adnak helyet, nem a tömb sorai között. Hasonlóképpen az [IMathParagraph::set_Justification](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathparagraph/set_justification/) a teljes matematikai bekezdést igazítja vízszintesen; nem helyettesíti a tömb függőleges igazítási beállítását.

## **Trigonometrikus függvények hozzáadása**

Használja az [AsArgumentOfFunction](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/)‑t, ha az argumentum a jelenlegi elem, és a függvény neve ismert.

![A cos trigonometrikus függvény alkalmazva 2x‑re](powerpoint-math-equations_6.png)

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/MathBlock.h>
#include <DOM/MathText/MathFunctionsOfOneArgument.h>
#include <DOM/MathText/MathPortion.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

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

## **Alsó- és felső indexek hozzáadása**

Használja az alsó‑ és felső index segédfüggvényeit indexekhez és hatványokhoz. Ha az indexeknek bal oldalon kell megjelenniük, használja a [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/)‑t.

![Nagy Y betű baloldali alsó indexszel 1 és felső indexszel n](powerpoint-math-equations_9.png)

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/MathBlock.h>
#include <DOM/MathText/MathPortion.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

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

## **Zárójelek hozzáadása**

Használja a [Enclose](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/enclose/)‑t egy kifejezés zárójelek közé helyezéséhez. Több elemet tartalmazó kifejezésekhez elválasztó karakter is beállítható.

![Zárójelek közé helyezett kifejezés, amely x, y és z‑t tartalmaz, függőleges vonalakkal elválasztva](powerpoint-math-equations_13.png)

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/MathBlock.h>
#include <DOM/MathText/MathPortion.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

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

### **Zárójelek mérete és igazítása**

Adja át a `true` értéket a [set_GrowToMatchOperandHeight](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathdelimiter/set_growtomatchoperandheight/) metódusnak, hogy a zárójelek a magas operandus köré növekedjenek, vagy `false`‑t, ha a normál méretet szeretné megtartani. A [set_DelimiterShape](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathdelimiter/set_delimitershape/) a [MathDelimiterShape](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathdelimitershape/) két értékének egyikét várja. A `Centered` a zárójeleket a matematikai tengely közepére helyezi, amely a egyenlőségjel középső részén halad. A `Match` a zárójeleket a tartalomhoz igazítja. Mindkét beállítás csak a zárójelekre hat, a kifejezés belseje változatlan marad.

A példa egy törtet helyez a `x` kitevőjébe, így a kifejezés a görögvonal fölött nagyobb, mint alatta. Mind a négy egyenlet ugyanazt a zárójelet és betűtípust használja.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/IPortionFormat.h>
#include <DOM/MathText/IMathBlock.h>
#include <DOM/MathText/IMathDelimiter.h>
#include <DOM/MathText/IMathFraction.h>
#include <DOM/MathText/IMathSuperscriptElement.h>
#include <DOM/MathText/MathDelimiterShape.h>
#include <DOM/MathText/MathPortion.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto addExpression = [slide](float left, float top, bool grow, MathDelimiterShape shape)
{
    auto fraction = System::MakeObject<MathematicalText>(u"a + b")->Divide(u"c + d");
    auto power = System::MakeObject<MathematicalText>(u"x")->SetSuperscript(fraction);
    auto delimiter = power->Enclose(u'(', u')');
    delimiter->set_GrowToMatchOperandHeight(grow);
    delimiter->set_DelimiterShape(shape);

    auto mathShape = slide->get_Shapes()->AddMathShape(left, top, 300, 100);
    auto portion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
    portion->get_PortionFormat()->set_FontHeight(32);
    auto equation = System::MakeObject<MathematicalText>(u"y = ")->Join(delimiter);
    portion->get_MathParagraph()->Add(equation);
};

addExpression(20, 20, true, MathDelimiterShape::Centered);
addExpression(350, 20, true, MathDelimiterShape::Match);
addExpression(20, 140, false, MathDelimiterShape::Centered);
addExpression(350, 140, false, MathDelimiterShape::Match);

presentation->Save(u"delimiter-sizing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

PowerPointban hasonlítsa össze a sorokat a növekedés hatását. A felső sorban a zárójelek növekednek, hogy befoglalják a kitevőt, és mindkét alakzat egyformán néz ki. Az alsó sorban a növekedés ki van kapcsolva. A baloldali kisebb zárójelek (`Centered`) a egyenlőségjelhez igazodnak, míg a jobboldali (`Match`) magasabban helyezkednek a kifejezés körül.

![Négy egyenlet PowerPointban, a zárójelek növekedése felül engedélyezve, alul letiltva, bal oldalon Centered, jobb oldalon Match](delimiter-sizing.png)

## **Szegélydoboz hozzáadása**

Hívja meg a [ToBorderBox](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/toborderbox/)‑t egy törtön, hogy az egész kifejezést keretezze. A visszakapott [IMathBorderBox](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathborderbox/) alapértelmezés szerint négy oldalát megjeleníti. Használja a [set_HideTop](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathborderbox/set_hidetop/), [set_HideBottom](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathborderbox/set_hidebottom/), [set_HideLeft](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathborderbox/set_hideleft/) és [set_HideRight](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathborderbox/set_hideright/) metódusokat egyes oldalak eltávolításához.

A példa hat példányt helyez el ugyanazon törtből egy dián. A törlés bemutatásához rejtse el mind a négy oldalt, és állítsa be a [set_StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathborderbox/set_strikethroughbottomlefttotopright/)‑t egy emelkedő átló (↗) vagy a [set_StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathborderbox/set_strikethroughtoplefttobottomright/)‑t egy süllyedő átló (↘) esetén. Használhatja a [set_StrikethroughHorizontal](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathborderbox/set_strikethroughhorizontal/) vagy a [set_StrikethroughVertical](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathborderbox/set_strikethroughvertical/) metódusokat is bármely kombinációban a látható oldalakkal.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathBorderBox.h>
#include <DOM/MathText/IMathFraction.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/MathBlock.h>
#include <DOM/MathText/MathPortion.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

auto presentation = System::MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(540, 220, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

auto addFraction = [slide](float x, float y, bool hideBorder = false)
{
    auto fraction = System::MakeObject<MathematicalText>(u"x+1")->Divide(u"y+2");
    auto box = fraction->ToBorderBox();
    box->set_HideTop(hideBorder);
    box->set_HideBottom(hideBorder);
    box->set_HideLeft(hideBorder);
    box->set_HideRight(hideBorder);

    auto shape = slide->get_Shapes()->AddMathShape(x, y, 160, 90);
    auto portion = System::ExplicitCast<MathPortion>(shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
    portion->get_PortionFormat()->set_FontHeight(28);
    auto mathBlock = System::MakeObject<MathBlock>(box);
    portion->get_MathParagraph()->Add(mathBlock);
    return box;
};

addFraction(10, 10);

auto partial = addFraction(190, 10);
partial->set_HideTop(true);
partial->set_HideRight(true);

addFraction(370, 10, true)->set_StrikethroughBottomLeftToTopRight(true);
addFraction(10, 120, true)->set_StrikethroughTopLeftToBottomRight(true);
addFraction(190, 120, true)->set_StrikethroughHorizontal(true);
addFraction(370, 120)->set_StrikethroughVertical(true);

presentation->Save(u"border-box.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Hat szerkeszthető tört PowerPointban. Felső sor: teljes szegély, alsó és bal oldal, emelkedő átló. Alsó sor: süllyedő átló, vízszintes áthúzás, függőleges áthúzás teljes szegéllyel](border-box-fractions.png)

Ezen tört esetén a vízszintes áthúzás átfedi a törtvonalat. A függőleges áthúzás mind a számlálót, mind a nevezőt átszeli, miközben a környező szegély látható marad. Ezek a vonalak az egész kifejezést díszítik. A szokásos szövegátvágás csak a szövegfutam karaktereire vonatkozik. A prezentáció PowerPointban való újbóli megnyitása után a számláló és a nevező továbbra is önállóan szerkeszthető.

## **Láthatóság és elrendezés vezérlése phantom elemekkel**

Tegye a kifejezést egy [MathPhantom](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathphantom/)‑ba, hogy önállóan szabályozza a láthatóságát és az egyenlethez járuló helyet. Az [IMathPhantom](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathphantom/) beállító metódusai a következőket vezérlik:

| Method | Effect |
| --- | --- |
| [set_Show](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathphantom/set_show/) | `false` megadása elrejti a kifejezést. Méretei továbbra is hozzájárulnak az elrendezéshez, hacsak az alább felsorolt beállítások nem `true`. |
| [set_ZeroWidth](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathphantom/set_zerowidth/) | A kifejezés vízszintes szélességét nulla‑ként kezeli, így a szomszédos elemek közelebb kerülhetnek egymáshoz. |
| [set_ZeroAsc](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathphantom/set_zeroasc/) | A felmenetét (a vonal feletti magasságot) nullának tekinti, ez csökkentheti a szomszédos elemek feletti helyet. |
| [set_ZeroDesc](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathphantom/set_zerodesc/) | A lemenetét (a vonal alatti mélységet) nullának tekinti, ez közelebb hozhatja a törtvonalat vagy más tartalmat a kifejezés alá. |

Az alapisvonal az a referencia vonal, amelyen a hagyományos matematikai betűk elhelyezkednek. A tartalom elrejtése nem távolítja el a méreteket, a méret nullára állítása pedig nem törli a kifejezést. Az alapkifejezés továbbra is elérhető a [get_Base](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathphantom/get_base/)‑on keresztül. `true` megadása a [set_Show](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathphantom/set_show/)‑nek újra megjeleníti a kifejezést; a dimenzió beállítások változatlanok maradnak.

Az alábbi példa öt egymás mellé helyezett változatot hoz létre: egy látható tört, egy rejtett tört, amely helyet tart, valamint három rejtett tört, amelynél egy dimenzió nulla. Minden változat ugyanazt a környező kifejezést és Cambria Math 24‑pont betűtípust használja. Minden egyenlet alakzat ugyanazt a felső pozíciót kapja, amit a szürke segédvonal jelöl. A phantom elhelyezése a külső tört számlálójában megkönnyíti a függőleges elrendezés változásainak észlelését.

```cpp
#include <array>
#include <drawing/color.h>
#include <DOM/FillType.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/MathBlock.h>
#include <DOM/MathText/MathFraction.h>
#include <DOM/MathText/MathPhantom.h>
#include <DOM/MathText/MathPortion.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/TextAnchorType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

auto createText = [](System::String value)
{
    auto text = System::MakeObject<MathematicalText>(value);
    text->get_Format()->set_FontHeight(24);
    auto font = System::MakeObject<FontData>(u"Cambria Math");
    text->get_Format()->set_LatinFont(font);
    return text;
};

auto presentation = System::MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(1000, 180, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

std::array<System::String, 5> labels = {u"Visible", u"Hidden: reserves space", u"Hidden: ZeroWidth", u"Hidden: ZeroAsc", u"Hidden: ZeroDesc"};

auto guide = slide->get_Shapes()->AddAutoShape(ShapeType::Line, 10, 60, 980, 0);
guide->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
guide->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_LightGray());

for (auto i = 0; i < labels.size(); i++)
{
    auto left = 10 + i * 200;

    auto label = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, left, 10, 190, 30);
    label->get_FillFormat()->set_FillType(FillType::NoFill);
    label->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
    label->get_TextFrame()->set_Text(labels[i]);

    auto labelFormat = label->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
    labelFormat->set_FontHeight(14);
    labelFormat->get_FillFormat()->set_FillType(FillType::Solid);
    labelFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

    auto fractionNumerator = createText(u"a+b");
    auto fractionDenominator = createText(u"c+d");
    auto fraction = System::MakeObject<MathFraction>(fractionNumerator, fractionDenominator);
    auto phantom = System::MakeObject<MathPhantom>(fraction);
    phantom->set_Show(i == 0);
    phantom->set_ZeroWidth(i == 2);
    phantom->set_ZeroAsc(i == 3);
    phantom->set_ZeroDesc(i == 4);

    auto leadingText = createText(u"x+");
    auto trailingText = createText(u"+y");
    auto numeratorBlock = System::MakeObject<MathBlock>(leadingText);
    auto numerator = numeratorBlock->Join(phantom)->Join(trailingText);
    auto denominator = createText(u"z");
    auto equation = System::MakeObject<MathFraction>(numerator, denominator);

    auto shape = slide->get_Shapes()->AddMathShape(left, 60, 190, 100);
    shape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Top);

    auto mathPortion = System::ExplicitCast<MathPortion>(shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
    auto mathParagraph = mathPortion->get_MathParagraph();
    auto mathBlock = System::MakeObject<MathBlock>(equation);
    mathParagraph->Add(mathBlock);
}

presentation->Save(u"math-phantom.pptx", SaveFormat::Pptx);
presentation->Dispose();

```

![Öt egyenlet PowerPointban, összehasonlítva látható tört, helyet fenntartó rejtett tört és ZeroWidth, ZeroAsc, vagy ZeroDesc engedélyezett rejtett törtek](math-phantom.png)


## **Kifejezések csoportosítása**

Használja a [Group](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/group/)‑t, hogy egy csoportosító karaktert helyezzen az expresszió fölé vagy alá. Hozzáadhat egy határt, hogy megcímkézze a csoportosított tagokat.

![Az x + y kifejezés csoportosítva, alatta „bármilyen szöveg” felirattal](powerpoint-math-equations_15.png)

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathGroupingCharacter.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/MathBlock.h>
#include <DOM/MathText/MathPortion.h>
#include <DOM/MathText/MathTopBotPositions.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

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

Használjon formázó segédfüggvényeket csak ott, ahol a képlet érthetőbbé válik. Például a [Overbar](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/overbar/) egy sort tesz a matematikai elem fölé.

![ABC matematikai kifejezés Overbar‑ral](powerpoint-math-equations_14.png)

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/MathBlock.h>
#include <DOM/MathText/MathPortion.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

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

### **Szöveg formázása egy meglévő egyenletben**

A meglévő egyenlet szövegének formázásához járja be az egyes matematikai blokkok elemes fát. Az [IMathElement::GetChildren](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/getchildren/) csak a közvetlen gyermekeket adja vissza, ezért rekurzívan kell hívni, hogy elérje a törtek, szkriptek, gyökök és egyéb beágyazott struktúrák belsejében lévő szöveget. Ellenőrizze a jelenlegi elemet és annak gyermekeit is, hogy a kiindulási elem is belekerüljön, ha az [MathematicalText](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathematicaltext/) típusú.

Ez a példa azt feltételezi, hogy a prezentáció egy olyan egyenletet tartalmaz, mint például `z = xᵢ / ∛y`, ahol a tört számlálójában alsó index, a nevezőben gyök található. Ha csak a blokk legfelső szintű elemeit dolgozná fel, a törtben lévő szöveget figyelmen kívül hagyná. A példa megtalálja a matematikai részeket a diák szövegkereteiben, a blokkokhoz a [IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/)-on keresztül fér hozzá, és a betűmagasságot 28 pontra állítja a [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/)-del, a formázást pedig minden szövegelem [get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathematicaltext/get_format/)-metódusával végzi.

```cpp
#include <functional>
#include <system/array.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathBlock.h>
#include <DOM/MathText/IMathElement.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/IMathPortion.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::MathText;

std::function<void(System::SharedPtr<IMathElement>)> formatMathText;
formatMathText = [&formatMathText](System::SharedPtr<IMathElement> element)
{
    auto text = System::DynamicCast<MathematicalText>(element);
    if (text != nullptr)
        text->get_Format()->set_FontHeight(28.0f);

    for (auto child : element->GetChildren())
        formatMathText(child);
};

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

for (auto slide : presentation->get_Slides())
{
    for (auto shape : slide->get_Shapes())
    {
        auto autoShape = System::DynamicCast<IAutoShape>(shape);
        if (autoShape == nullptr || autoShape->get_TextFrame() == nullptr)
            continue;

        for (auto paragraph : autoShape->get_TextFrame()->get_Paragraphs())
        {
            for (auto portion : paragraph->get_Portions())
            {
                auto mathPortion = System::DynamicCast<IMathPortion>(portion);
                if (mathPortion != nullptr)
                {
                    for (auto block : mathPortion->get_MathParagraph())
                        formatMathText(block);
                }
            }
        }
    }
}

presentation->Save(u"formatted-equations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

A mentett prezentáció minden szintjén frissített szövegformázást tartalmaz, miközben megőrzi a szöveg tartalmát és a matematikai struktúrát.

## **Gyors referencia**

| Task | Main API |
| --- | --- |
| Matematikai szöveg létrehozása | [MathematicalText](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathematicaltext/) |
| Elemek kombinálása | [IMathElement.Join](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/join/) |
| Törtek létrehozása | [IMathElement.Divide](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/divide/) |
| Felső vagy alsó index hozzáadása | [SetSuperscript](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubscript/) |
| Függvények hozzáadása | [Function](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Gyökök hozzáadása | [IMathElement.Radical](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/radical/) |
| Határok hozzáadása | [SetLowerLimit](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Baloldali szkriptek hozzáadása | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Összegek és integrálok | [Nary](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/) |
| Mátrixok hozzáadása | [MathMatrix](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathmatrix/) |
| Egyenlet tömbök hozzáadása | [ToMathArray](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/tomatharray/) |
| Zárójelek hozzáadása | [Enclose](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/enclose/) |
| Fölé/Alá vonalak és szegélyek | [Overbar](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/toborderbox/) |
| Kifejezések csoportosítása | [Group](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/group/) |

## **GYIK**

**Szerkeszthetek egy már meglévő PowerPoint‑egyenletet?**

Igen. Nyissa meg a prezentációt, keresse meg azt az alakzatot, amely [MathPortion](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/)-t tartalmaz, hívja meg a [get_MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/get_mathparagraph/)-t, és frissítse a bekezdésben lévő matematikai blokkokat.

**Az egyenletek szerkeszthető PowerPoint‑matematikaként kerülnek mentésre?**

Igen. PPTX mentésekor az Aspose.Slides az egyenletet szerkeszthető Office‑matematikai tartalomként írja ki.

**Exportálhatok egyenleteket LaTeX‑be?**

Igen. Szerezze meg az egyenlet [IMathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathparagraph/)-ját az [IMathPortion](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathportion/)-ból, majd hívja meg az [IMathParagraph::ToLatex](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathparagraph/tolatex/)‑t a közvetlen exportáláshoz. Komplett példa: [Export Math Equations from Presentations in C++](/slides/hu/cpp/exporting-math-equations/#export-math-equations-to-latex).