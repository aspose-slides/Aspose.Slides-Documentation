---
title: إضافة معادلات رياضية إلى عروض PowerPoint التقديمية في C++
linktitle: معادلات رياضية في PowerPoint
type: docs
weight: 80
url: /ar/cpp/powerpoint-math-equations/
keywords:
- معادلة رياضية
- رمز رياضي
- صيغة رياضية
- نص رياضي
- إضافة معادلة رياضية
- إضافة رمز رياضي
- إضافة صيغة رياضية
- إضافة نص رياضي
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "إدراج وتحرير المعادلات الرياضية في PowerPoint بصيغ PPT و PPTX باستخدام Aspose.Slides لـ C++، مع دعم OMML، أدوات تنسيق، وعينات كود C++ واضحة."
---
## **نظرة عامة**

PowerPoint يخزن المعادلات كـ Office Math Markup Language (OMML). باستخدام Aspose.Slides لـ C++، يمكنك إنشاء نفس نوع المحتوى الرياضي برمجيًا: الكسور، الجذور، الدوال، الحدود، عوامل N-ary، المصفوفات، المصفوفات المتعددة، والكتل الرياضية المنسقة.

في PowerPoint، يقوم المستخدمون عادةً بإضافة المعادلات من **Insert > Equation**:

![علامة تبويب إدراج في PowerPoint مع الأمر Equation محدد](powerpoint-math-equations_1.png)

النتيجة هي نص رياضي قابل للتحرير على الشريحة:

![شريحة PowerPoint تحتوي على معادلة رياضية قابلة للتحرير](powerpoint-math-equations_2.png)

Aspose.Slides يبني ذلك النص الرياضي من خلال ثلاثة كائنات رئيسية:

- شكل رياضي، يتم إنشاؤه باستخدام [AddMathShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/shapecollection/)، هو الشكل الذي يحتوي على المعادلة.
- [MathPortion](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/mathportion/) يخزن المحتوى الرياضي داخل إطار نص الشكل.
- [MathParagraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/mathparagraph/) يحتوي على واحد أو أكثر من كائنات [MathBlock](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/mathblock/).

معظم الأمثلة أدناه تستخدم [MathematicalText](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/mathematicaltext/) والطرق المتسلسلة من [IMathElement](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/imathelement/) لتقليل حجم الشيفرة وجعلها قابلة للقراءة.

لإصدارات MathML، راجع [Export Math Equations from Presentations in C++](/slides/ar/cpp/exporting-math-equations/).

## **إنشاء معادلة**

هذا المثال ينشئ شكلًا رياضيًا ويضيف مبرهنة فيثاغورس:

![المعادلة c تربيع تساوي a تربيع زائد b تربيع](powerpoint-math-equations_3.png)

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

`AddMathShape` ينشئ شكلاً يحتوي بالفعل على فقرة رياضية. قم بالوصول إلى أول `MathPortion`، احصل على `MathParagraph` الخاص به، وأضف كتلًا رياضية أو عناصر رياضية إليه.

{{% /alert %}}

## **إضافة كسور**

استخدم `Divide` لإنشاء كسر. يمكنك اختيار نمط الكسر باستخدام [MathFractionTypes](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/mathfractiontypes/).

![كسر رياضي مائل يُظهر 1 مقسومًا على x](powerpoint-math-equations_4.png)

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

لإنشاء كسر مكدس، استخدم `MathFractionTypes::Bar`:

```cpp
auto stackedFraction = System::MakeObject<MathematicalText>(u"x + 1")->Divide(u"y - 1", MathFractionTypes::Bar);
```

## **إضافة جذور**

استخدم `Radical` لإنشاء جذر تربيعي، جذر مكعب، أو جذر آخر. العنصر الحالي يصبح القاعدة، والحجة تصبح الدرجة.

![تعبير جذري من الدرجة n مع x تحت علامة الجذر](powerpoint-math-equations_5.png)

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

## **إضافة دوال وحدود**

استخدم `AsArgumentOfFunction` أو `Function` للدوال مثل `sin(x)`, `log(x)`, أو أسماء دوال مخصصة. للحدود، ضع `lim` داخل [MathLimit](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/mathlimit/) أو استخدم `SetLowerLimit`.

![حد x عندما يقترب x من اللانهاية](powerpoint-math-equations_8.png)

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

لإضافة اسم دالة مخصص، اجعل اسم الدالة هو العنصر الحالي:

```cpp
auto customFunction = System::MakeObject<MathematicalText>(u"f")->Function(u"x + 1");
```

## **إضافة عوامل N-ary وتكاملات**

استخدم `Nary` للجمعيات، الاتحاد، التقاطع، وغيرها من العوامل الكبيرة. استخدم `Integral` للتكاملات. كلا الطريقتين يتيحان تعيين الحدود السفلية والعلوية.

![جمع مع حدود سفلية وعليا](powerpoint-math-equations_7.png)

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

العوامل N-ary مخصصة للعوامل الكبيرة مع حدود اختيارية. العوامل البسيطة مثل `+`, `-`, و`=` عادةً ما تُضاف كـ `MathematicalText` وتُدمج في التعبير.

لإنشاء تكامل، استخدم `Integral`:

```cpp
auto integralBase = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = integralBase->Integral(MathIntegralTypes::Simple, u"0", u"1");
```

## **إضافة مصفوفات**

استخدم [MathMatrix](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/mathmatrix/) للصفوف والأعمدة. المصفوفات لا تشمل الأقواس بشكل افتراضي، لذا أغلق المصفوفة بأقواس أو أقواس مربعة أو معقوفة حسب الحاجة.

![مصفوفة رياضية ذات صفين وخلية فارغة واحدة](powerpoint-math-equations_10.png)

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

## **إضافة مصفوفات معادلات**

استخدم `ToMathArray` عندما تحتاج إلى معادلات محاذية أو مجموعة رأسية من التعابير.

![مصفوفة رياضية عمودية مع x فوق y](powerpoint-math-equations_11.png)

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

## **إضافة الدوال المثلثية**

استخدم `AsArgumentOfFunction` عندما يكون الوسيط هو العنصر الحالي ويكون اسم الدالة معروفًا.

![الدالة المثلثية cos مطبقة على 2x](powerpoint-math-equations_6.png)

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

## **إضافة مؤشرات سفلية وفوقية**

استخدم المساعدات للمؤشرات السفلية والعلوية للمؤشرات والقوى. عندما يجب أن تظهر المؤشرات على الجانب الأيسر للقاعدة، استخدم `SetSubSuperscriptOnTheLeft`.

![حرف Y كبير مع مؤشر سفلي 1 ومؤشر علوي n على الجانب الأيسر](powerpoint-math-equations_9.png)

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

## **إضافة محددات**

استخدم `Enclose` لوضع تعبير داخل محددات. يمكنك أيضًا تعيين حرف فاصل لتعبيرات المحددات التي تحتوي على عدة عناصر.

![تعبير محدد يحتوي على x، y، وz مفصول بأشرطة رأسية](powerpoint-math-equations_13.png)

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

## **إضافة صندوق حدود**

استخدم `ToBorderBox` عندما يجب أن تكون المعادلة نفسها مؤطرة.

![معادلة في صندوق تُظهر a تربيع يساوي b تربيع زائد c تربيع](powerpoint-math-equations_12.png)

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

## **تجميع المصطلحات**

استخدم `Group` لوضع حرف تجميع أعلى أو أسفل تعبير. أضف حدًا لتسمية المصطلحات المجمعة.

![التعبير x زائد y مُجمع مع تسمية أي نص أسفله](powerpoint-math-equations_15.png)

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

## **تنسيق عناصر الرياضيات**

استخدم مساعدات التنسيق فقط حيث توضح الصيغة. على سبيل المثال، `Overbar` يضع شريطًا فوق عنصر رياضي.

![تعبير رياضي ABC مع خط فوقه](powerpoint-math-equations_14.png)

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

## **مرجع سريع**

| المهمة | واجهة برمجة التطبيقات الأساسية |
| --- | --- |
| إنشاء نص رياضي | [MathematicalText](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/mathematicaltext/) |
| دمج العناصر | [IMathElement.Join](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/imathelement/join/) |
| إنشاء كسور | [IMathElement.Divide](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/imathelement/divide/) |
| إضافة أس فوقية أو سفلية | [SetSuperscript](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/imathelement/setsubscript/) |
| إضافة دوال | [Function](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| إضافة جذور | [IMathElement.Radical](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/imathelement/radical/) |
| إضافة حدود | [SetLowerLimit](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/imathelement/setupperlimit/) |
| إضافة سكريبتات على الجانب الأيسر | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| إضافة جمع وتكاملات | [Nary](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/imathelement/integral/) |
| إضافة مصفوفات | [MathMatrix](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/mathmatrix/) |
| إضافة مصفوفات معادلات | [ToMathArray](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/imathelement/tomatharray/) |
| إضافة محددات | [Enclose](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/imathelement/enclose/) |
| إضافة أشرطة وحدود | [Overbar](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/imathelement/toborderbox/) |
| تجميع المصطلحات | [Group](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/imathelement/group/) |

## **الأسئلة المتكررة**

**هل يمكنني تعديل معادلة PowerPoint موجودة؟**

نعم. افتح العرض التقديمي، ابحث عن الشكل الذي يحتوي على `MathPortion`، احصل على `MathParagraph` الخاص به، وحدث كتل الرياضيات في تلك الفقرة.

**هل يتم حفظ المعادلات كرياضيات PowerPoint قابلة للتحرير؟**

نعم. عند حفظ الملف بصيغة PPTX، تقوم Aspose.Slides بكتابة المعادلة كالمحتوى الرياضي القابل للتحرير في Office.

**هل يمكنني تصدير المعادلات إلى LaTeX؟**

نعم. احصل على [IMathParagraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/imathparagraph/) للمعادلة من [IMathPortion](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/imathportion/)، ثم استدعِ [IMathParagraph::ToLatex](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/imathparagraph/tolatex/) لتصديره مباشرة. لمثال كامل، راجع [Export Math Equations from Presentations in C++](/slides/ar/cpp/exporting-math-equations/#export-math-equations-to-latex).