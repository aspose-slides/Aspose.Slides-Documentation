---
title: เพิ่มสมการคณิตศาสตร์ลงในงานนำเสนอ PowerPoint ด้วย .NET
linktitle: สมการคณิตศาสตร์ PowerPoint
type: docs
weight: 80
url: /th/net/powerpoint-math-equations/
keywords:
- สมการคณิตศาสตร์
- สัญลักษณ์คณิตศาสตร์
- สูตรคณิตศาสตร์
- ข้อความคณิตศาสตร์
- เพิ่มสมการคณิตศาสตร์
- เพิ่มสัญลักษณ์คณิตศาสตร์
- เพิ่มสูตรคณิตศาสตร์
- เพิ่มข้อความคณิตศาสตร์
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "แทรกและแก้ไขสมการคณิตศาสตร์ใน PowerPoint PPT และ PPTX ด้วย Aspose.Slides สำหรับ .NET รองรับ OMML การควบคุมการจัดรูปแบบ และตัวอย่างโค้ด C# ที่ชัดเจน."
---
## **ภาพรวม**

PowerPoint จัดเก็บสมการเป็น Office Math Markup Language (OMML). ด้วย Aspose.Slides for .NET, คุณสามารถสร้างเนื้อหาคณิตศาสตร์แบบเดียวกันด้วยโปรแกรม: เศษส่วน, ราก, ฟังก์ชัน, ขีดจำกัด, ตัวดำเนินการ N‑ary, เมทริกซ์, แถว, และบล็อกคณิตศาสตร์ที่จัดรูปแบบ

ใน PowerPoint, ผู้ใช้มักเพิ่มสมการโดยเลือก **Insert > Equation**:

![แท็บ Insert ของ PowerPoint พร้อมคำสั่ง Equation ที่เลือก](powerpoint-math-equations_1.png)

ผลลัพธ์คือข้อความคณิตศาสตร์ที่แก้ไขได้บนสไลด์:

![สไลด์ PowerPoint ที่มีสมการคณิตศาสตร์ที่แก้ไขได้](powerpoint-math-equations_2.png)

Aspose.Slides สร้างข้อความคณิตศาสตร์นั้นผ่านสามออบเจ็กต์หลัก:

- รูปร่างคณิตศาสตร์ที่สร้างด้วย [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/), คือรูปร่างที่บรรจุสมการ
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) เก็บเนื้อหาคณิตศาสตร์ภายในกรอบข้อความของรูปร่าง
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) มี [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/) หนึ่งออบเจ็กต์หรือมากกว่า

ตัวอย่างส่วนใหญ่ด้านล่างใช้ [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) และเมธอดแบบ fluent จาก [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) เพื่อทำให้โค้ดสั้นและอ่านง่าย

สำหรับกรณีการส่งออก MathML ดูที่ [ส่งออกสมการคณิตศาสตร์จากงานนำเสนอใน .NET](/slides/th/net/exporting-math-equations/)

## **สร้างสมการ**

ตัวอย่างนี้ใช้ [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) เพื่อสร้างรูปร่างคณิตศาสตร์และเพิ่มทฤษฎีพีธากอรัส:

![สมการ c กำลังสองเท่ากับ a กำลังสองบวก b กำลังสอง](powerpoint-math-equations_3.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var equation = new MathematicalText("c")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("a").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("b").SetSuperscript("2"));

mathParagraph.Add(equation);

presentation.Save("pythagorean-theorem.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) สร้างรูปร่างที่มี MathParagraph อยู่แล้ว เข้าถึง [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) ตัวแรก, รับ [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), และเพิ่ม MathBlock หรือ MathElement เข้าไป
{{% /alert %}}

## **เพิ่มเศษส่วน**

ใช้ [Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) เพื่อสร้างเศษส่วน คุณสามารถเลือกสไตล์ของเศษส่วนได้ด้วย [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/)

![เศษส่วนคณิตศาสตร์เอียงที่แสดงหนึ่งหารด้วย x](powerpoint-math-equations_4.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var fraction = new MathematicalText("1")
    .Divide("x", MathFractionTypes.Skewed);

mathParagraph.Add(new MathBlock(fraction));

presentation.Save("fraction.pptx", SaveFormat.Pptx);
```

สำหรับเศษส่วนแบบซ้อนกัน ให้ใช้ [MathFractionTypes.Bar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/):

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **เพิ่มราก**

ใช้ [Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) เพื่อสร้างรากที่สอง, รากที่สาม หรือรากอื่น ๆ องค์ประกอบปัจจุบันจะเป็นฐานและอาร์กิวเมนต์จะเป็นดีกรี

![นิพจน์ราก n‑th ที่มี x อยู่ใต้สัญลักษณ์ราก](powerpoint-math-equations_5.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var radical = new MathematicalText("x")
    .Radical("n");

mathParagraph.Add(new MathBlock(radical));

presentation.Save("radical.pptx", SaveFormat.Pptx);
```

## **เพิ่มฟังก์ชันและขีดจำกัด**

ใช้ [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) หรือ [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) สำหรับฟังก์ชันเช่น `sin(x)`, `log(x)` หรือชื่อฟังก์ชันที่กำหนดเอง สำหรับขีดจำกัด ให้ใส่ `lim` ใน [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/) หรือใช้ [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/)

![ขีดจำกัดของ x เมื่อ x เข้าใกล้อนันต์](powerpoint-math-equations_8.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var limit = new MathematicalText("lim")
    .SetLowerLimit("x→∞")
    .Function("x");

mathParagraph.Add(new MathBlock(limit));

presentation.Save("functions-and-limits.pptx", SaveFormat.Pptx);
```

สำหรับชื่อฟังก์ชันที่กำหนดเอง ให้ทำให้ชื่อฟังก์ชันเป็นองค์ประกอบปัจจุบันและเรียก [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) พร้อมอาร์กิวเมนต์:

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **เพิ่มตัวดำเนินการ N‑ary และอินทิกรัล**

ใช้ [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) สำหรับการบวก, ยูเนียน, อินเตอร์เซกชัน, และตัวดำเนินการขนาดใหญ่อื่น ๆ ใช้ [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) สำหรับอินทิกรัล ทั้งสองเมธอดให้คุณตั้งค่าขีดจำกัดล่างและบน

![ผลบวกที่มีขีดจำกัดล่างและบน](powerpoint-math-equations_7.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var summationBase = new MathematicalText("x")
    .SetSuperscript("k")
    .Join(new MathematicalText("a").SetSuperscript("n-k"));

var summation = summationBase.Nary(MathNaryOperatorTypes.Summation, "k=0", "n");

mathParagraph.Add(new MathBlock(summation));

presentation.Save("nary-operators.pptx", SaveFormat.Pptx);
```

ตัวดำเนินการ N‑ary ใช้สำหรับตัวดำเนินการขนาดใหญ่ที่มีขีดจำกัดเป็นตัวเลือก ตัวดำเนินการง่ายเช่น `+`, `-`, และ `=` มักจะเพิ่มเป็น [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) และเชื่อมเข้ากับนิพจน์

สำหรับอินทิกรัล ให้ใช้ [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/):

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **เพิ่มเมทริกซ์**

ใช้ [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) สำหรับแถวและคอลัมน์ เมทริกซ์โดยปกติจะไม่มีวงเล็บ จึงควรล้อมเมทริกซ์ด้วยวงเล็บ, กำหนดวงเล็บสี่เหลี่ยมหรือวงโค้งเมื่อต้องการ

![เมทริกซ์คณิตศาสตร์สองแถวที่มีเซลล์ว่างหนึ่งเซลล์](powerpoint-math-equations_10.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var matrix = new MathMatrix(2, 3);
matrix[0, 0] = new MathematicalText("1");
matrix[0, 1] = new MathematicalText("x");
matrix[1, 0] = new MathematicalText("x");
matrix[1, 1] = new MathematicalText("2");
matrix[1, 2] = new MathematicalText("y");

mathParagraph.Add(new MathBlock(matrix));

presentation.Save("matrix.pptx", SaveFormat.Pptx);
```

## **เพิ่มอาเรย์สมการ**

ใช้ [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) เมื่อคุณต้องการสมการที่จัดแนวหรืออาเรย์แนวตั้งของนิพจน์

![อาเรย์คณิตศาสตร์แนวตั้งที่มี x อยู่เหนือ y](powerpoint-math-equations_11.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 140);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var equationArray = new MathematicalText("x")
    .Join("y")
    .ToMathArray();

mathParagraph.Add(new MathBlock(equationArray));

presentation.Save("equation-array.pptx", SaveFormat.Pptx);
```

## **เพิ่มฟังก์ชันตรีโกณมิติ**

ใช้ [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) เมื่ออาร์กิวเมนต์เป็นองค์ประกอบปัจจุบันและชื่อฟังก์ชันเป็นที่ทราบ

![ฟังก์ชันตรีโกณมิติ cos ที่ใช้กับ 2x](powerpoint-math-equations_6.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var cosine = new MathematicalText("2x")
    .AsArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

mathParagraph.Add(new MathBlock(cosine));

presentation.Save("trigonometric-function.pptx", SaveFormat.Pptx);
```

## **เพิ่มตัวห้อยและตัวเชิง**

ใช้ตัวช่วยสำหรับตัวห้อยและตัวเชิงสำหรับดัชนีและกำลัง เมื่อดัชนีต้องแสดงทางด้านซ้ายของฐาน ให้ใช้ [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/)

![อักษร Y ตัวพิมพ์ใหญ่ที่มีตัวห้อย 1 ด้านซ้ายและตัวเชิง n ด้านขวา](powerpoint-math-equations_9.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var scripts = new MathematicalText("Y")
    .SetSubSuperscriptOnTheLeft("1", "n");

mathParagraph.Add(new MathBlock(scripts));

presentation.Save("subscript-superscript.pptx", SaveFormat.Pptx);
```

## **เพิ่มเครื่องหมายกำหนด**

ใช้ [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) เพื่อใส่นิพจน์ภายในเครื่องหมายกำหนด คุณยังสามารถตั้งอักขระตัวคั่นสำหรับนิพจน์ที่มีหลายองค์ประกอบ

![นิพจน์เครื่องหมายกำหนดที่มี x, y, และ z คั่นด้วยเส้นแนวตั้ง](powerpoint-math-equations_13.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var delimiter = new MathematicalText("x")
    .Join("y")
    .Join("z")
    .Enclose('<', '>');
delimiter.SeparatorCharacter = '|';

mathParagraph.Add(new MathBlock(delimiter));

presentation.Save("delimiters.pptx", SaveFormat.Pptx);
```

### **ขนาดและการจัดตำแหน่งเครื่องหมายกำหนด**

ตั้งค่า [GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) เป็น `true` เพื่อให้วงเล็บขยายตามความสูงของออปอเรนด์ที่สูง, หรือเป็น `false` เพื่อคงขนาดปกติ [DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) มีค่าอย่างใดอย่างหนึ่งจากสองค่า [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/) `Centered` จัดตำแหน่งวงเล็บให้อยู่กึ่งกลางแกนคณิตศาสตร์ซึ่งผ่านศูนย์ของเครื่องหมายเท่ากับ. `Match` จัดให้ตรงกับเนื้อหาที่อยู่ภายใน. การตั้งค่าสองค่ามีผลต่อเครื่องหมายกำหนดเท่านั้น นิพจน์ภายในคงเดิม

ตัวอย่างนี้ใส่เศษส่วนในส่วนย่อยของ `x` ทำให้นิพจน์ยืดออกเหนือเส้นฐานมากกว่าส่วนล่าง ทั้งสี่สมการใช้วงเล็บและการตั้งค่าฟอนต์เดียวกัน

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

void AddExpression(float left, float top, bool grow, MathDelimiterShape shape)
{
    var fraction = new MathematicalText("a + b").Divide("c + d");
    var power = new MathematicalText("x").SetSuperscript(fraction);
    var delimiter = power.Enclose('(', ')');
    delimiter.GrowToMatchOperandHeight = grow;
    delimiter.DelimiterShape = shape;

    var mathShape = slide.Shapes.AddMathShape(left, top, 300, 100);
    var portion = (MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FontHeight = 32;
    var equation = new MathematicalText("y = ").Join(delimiter);
    portion.MathParagraph.Add(equation);
}

AddExpression(20, 20, true, MathDelimiterShape.Centered);
AddExpression(350, 20, true, MathDelimiterShape.Match);
AddExpression(20, 140, false, MathDelimiterShape.Centered);
AddExpression(350, 140, false, MathDelimiterShape.Match);

presentation.Save("delimiter-sizing.pptx", SaveFormat.Pptx);
```

ใน PowerPoint ให้เปรียบเทียบแถวเพื่อดูผลของการขยาย ในแถวบน วงเล็บจะขยายเพื่อล้อมส่วนย่อยและดูเหมือนกันสำหรับรูปร่างทั้งสอง ในแถวล่าง การขยายปิด ดวงเวียนเล็กลงทางซ้าย (`Centered`) จัดให้ตรงกับเครื่องหมายเท่ากับ, ส่วนขวา (`Match`) อยู่สูงกว่าตรงรอบนิพจน์

![สี่สมการใน PowerPoint ที่เปิดใช้งานการขยายเครื่องหมายกำหนดด้านบนและปิดด้านล่าง, และ Centered ด้านซ้าย, Match ด้านขวา](delimiter-sizing.png)

## **เพิ่มกล่องขอบ**

เรียก [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) บนเศษส่วนเพื่อกรอบนิพจน์ทั้งหมด [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) ที่คืนค่าจะสี่ด้านโดยค่าเริ่มต้น ใช้ [HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/), [HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/), [HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/), และ [HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/) เพื่อลบด้านที่ต้องการ

ตัวอย่างวางเศษส่วนเดียวกันหกครั้งบนสไลด์หนึ่ง เพื่อแสดงการยกเลิก ให้ซ่อนทุกด้านและตั้งค่า [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/) สำหรับเส้นทแยงขึ้น (↗) หรือ [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/) สำหรับเส้นทแยงลง (↘) คุณยังสามารถใช้ [StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) หรือ [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/) พร้อมการผสมของด้านที่แสดง

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(540, 220, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

IMathBorderBox AddFraction(float x, float y, bool hideBorder = false)
{
    var fraction = new MathematicalText("x+1").Divide("y+2");
    var box = fraction.ToBorderBox();
    box.HideTop = box.HideBottom = box.HideLeft = box.HideRight = hideBorder;

    var shape = slide.Shapes.AddMathShape(x, y, 160, 90);
    var portion = (MathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FontHeight = 28;
    portion.MathParagraph.Add(new MathBlock(box));
    return box;
}

AddFraction(10, 10);

var partial = AddFraction(190, 10);
partial.HideTop = true;
partial.HideRight = true;

AddFraction(370, 10, hideBorder: true).StrikethroughBottomLeftToTopRight = true;
AddFraction(10, 120, hideBorder: true).StrikethroughTopLeftToBottomRight = true;
AddFraction(190, 120, hideBorder: true).StrikethroughHorizontal = true;
AddFraction(370, 120).StrikethroughVertical = true;

presentation.Save("border-box.pptx", SaveFormat.Pptx);
```

![หกเศษส่วนที่แก้ไขได้ใน PowerPoint. แถวบน: กรอบเต็ม, ด้านล่างและซ้าย, เส้นทแยงขึ้น. แถวล่าง: เส้นทแยงลง, เส้นขวาง, เส้นแนวตั้งพร้อมกรอบเต็ม](border-box-fractions.png)

บนเศษส่วนนี้ เส้นขวางทับบาร์ของเศษส่วน เส้นแนวตั้งตัดผ่านตัวเศษและตัวส่วนในขณะกรอบโดยรอบยังคงแสดง เส้นเหล่านี้เป็นการตกแต่งทั้งนิพจน์ การขีดฆ่าแบบข้อความปกติใช้กับอักขระในรันข้อความ หลังจากเปิดไฟล์งานนำเสนอใหม่ใน PowerPoint คุณยังคงแก้ไขตัวเศษและตัวส่วนแยกกัน

## **จัดกลุ่มเทอม**

ใช้ [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) เพื่อวางอักขระจัดกลุ่มเหนือหรือต่ำกว่านิพจน์ เพิ่มขีดจำกัดเพื่อระบุเทอมที่จัดกลุ่ม

![นิพจน์ x บวก y ที่จัดกลุ่มพร้อมป้ายกำกับข้อความใด ๆ ด้านล่าง](powerpoint-math-equations_15.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var grouped = new MathematicalText("x + y")
    .Group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top)
    .SetLowerLimit("any text");

mathParagraph.Add(new MathBlock(grouped));

presentation.Save("grouped-terms.pptx", SaveFormat.Pptx);
```

## **จัดรูปแบบองค์ประกอบคณิตศาสตร์**

ใช้ตัวช่วยจัดรูปแบบเฉพาะที่ทำให้สูตรชัดเจนเท่านั้น ตัวอย่างเช่น [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) วางแถบเหนือองค์ประกอบคณิตศาสตร์

![นิพจน์คณิตศาสตร์ ABC พร้อมแถบเหนือ](powerpoint-math-equations_14.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var overbar = new MathematicalText("ABC").Overbar();

mathParagraph.Add(new MathBlock(overbar));

presentation.Save("overbar.pptx", SaveFormat.Pptx);
```

### **รูปแบบข้อความในสมการที่มีอยู่**

เพื่อจัดรูปแบบข้อความทั่วสมการที่มีอยู่ ให้เดินผ่านต้นไม้ขององค์ประกอบในแต่ละ MathBlock. [IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) คืนค่าเฉพาะลูกโดยตรง, ดังนั้นเรียกซ้ำเพื่อเข้าถึงข้อความภายในเศษส่วน, ตัวห้อย/เชิง, ราก, และโครงสร้างซ้อนอื่น ๆ ตรวจสอบองค์ประกอบปัจจุบันและลูกของมันเพื่อรวมองค์ประกอบเริ่มต้นเมื่อเป็น [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/)

ตัวอย่างนี้สมมติว่าการนำเสนอมีสมการเช่น `z = xᵢ / ∛y` โดยมีเศษส่วนที่มีตัวห้อยในตัวเศษและรากในตัวส่วน การประมวลผลเพียงองค์ประกอบระดับบนของบล็อกจะพลาดข้อความภายในเศษส่วน ตัวอย่างนี้ค้นหาส่วนคณิตศาสตร์ในกรอบข้อความของสไลด์, เข้าถึงบล็อกผ่าน [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/), และตั้งค่า [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) เป็น 28 จุดผ่านพร็อพเพอร์ตี้ [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/) ของแต่ละองค์ประกอบข้อความ

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape autoShape || autoShape.TextFrame == null)
            continue;

        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is IMathPortion mathPortion)
                {
                    foreach (var block in mathPortion.MathParagraph)
                        FormatMathText(block);
                }
            }
        }
    }
}

presentation.Save("formatted-equations.pptx", SaveFormat.Pptx);

void FormatMathText(IMathElement element)
{
    if (element is MathematicalText text)
        text.Format.FontHeight = 28;

    foreach (var child in element.GetChildren())
        FormatMathText(child);
}
```

ไฟล์งานนำเสนอที่บันทึกแล้วจะมีการจัดรูปแบบข้อความที่อัปเดตในทุกระดับของแต่ละสมการที่ประมวลผล, พร้อมคงเนื้อหาและโครงสร้างคณิตศาสตร์เดิม

## **Quick Reference**

| Task | Main API |
| --- | --- |
| สร้างข้อความคณิตศาสตร์ | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| รวมองค์ประกอบ | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| สร้างเศษส่วน | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| เพิ่มตัวเชิงหรือห้อย | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| เพิ่มฟังก์ชัน | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| เพิ่มราก | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| เพิ่มขีดจำกัด | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| เพิ่มสคริปต์ด้านซ้าย | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| เพิ่มผลบวกและอินทิกรัล | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| เพิ่มเมทริกซ์ | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| เพิ่มอาเรย์สมการ | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| เพิ่มเครื่องหมายกำหนด | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| เพิ่มแถบและขอบ | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| จัดกลุ่มเทอม | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **คำถามที่พบบ่อย**

**ฉันสามารถแก้ไขสมการ PowerPoint ที่มีอยู่ได้หรือไม่?**

ใช่. เปิดงานนำเสนอ, ค้นหารูปร่างที่มี [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), รับ [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), และอัปเดต MathBlock ในย่อหน้านั้น.

**สมการถูกบันทึกเป็นคณิตศาสตร์ PowerPoint ที่แก้ไขได้หรือไม่?**

ใช่. เมื่อคุณบันทึกเป็น PPTX, Aspose.Slides จะเขียนสมการเป็นเนื้อหา Office Math ที่แก้ไขได้.

**ฉันสามารถส่งออกสมการเป็น LaTeX ได้หรือไม่?**

ใช่. รับ [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) ของสมการจาก [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), และเรียก [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) เพื่อส่งออกโดยตรง สำหรับตัวอย่างครบถ้วน ดูที่ [ส่งออกสมการคณิตศาสตร์จากงานนำเสนอใน .NET](/slides/th/net/exporting-math-equations/#export-math-equations-to-latex)