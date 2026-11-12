---
title: เพิ่มสมการคณิตศาสตร์ในงานนำเสนอ PowerPoint ด้วย .NET
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
description: "แทรกและแก้ไขสมการคณิตศาสตร์ใน PowerPoint PPT และ PPTX ด้วย Aspose.Slides สำหรับ .NET รองรับ OMML, การควบคุมการจัดรูปแบบ และตัวอย่างโค้ด C# ที่ชัดเจน."
---
## **ภาพรวม**

PowerPoint จัดเก็บสมการเป็น Office Math Markup Language (OMML) ด้วย Aspose.Slides for .NET คุณสามารถสร้างเนื้อหาแบบคณิตศาสตร์เดียวกันแบบโปรแกรมได้: เศษส่วน, ราก, ฟังก์ชัน, ขีดจำกัด, ตัวดำเนินการ N-ary, เมทริกซ์, อาเรย์, และบล็อกคณิตศาสตร์ที่จัดรูปแบบ

ใน PowerPoint ผู้ใช้มักเพิ่มสมการจาก **Insert > Equation**:

![แท็บ Insert ของ PowerPoint พร้อมคำสั่ง Equation ที่เลือกไว้](powerpoint-math-equations_1.png)

ผลลัพธ์คือข้อความคณิตศาสตร์ที่แก้ไขได้บนสไลด์:

![สไลด์ PowerPoint ที่มีสมการคณิตศาสตร์ที่แก้ไขได้](powerpoint-math-equations_2.png)

Aspose.Slides สร้างข้อความคณิตศาสตร์นั้นผ่านวัตถุหลักสามตัว:

- รูปคณิตศาสตร์ที่สร้างด้วย [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) คือรูปร่างที่เก็บสมการ
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) เก็บเนื้อหาคณิตศาสตร์ภายในกรอบข้อความของรูปร่าง
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) มีหนึ่งหรือหลายอ็อบเจ็กต์ [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/)

ตัวอย่างส่วนใหญ่ด้านล่างใช้ [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) และเมธอด fluent จาก [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) เพื่อทำให้โค้ดสั้นและอ่านง่าย

สำหรับสถานการณ์การส่งออก MathML ดูที่ [Export Math Equations from Presentations in .NET](/slides/th/net/exporting-math-equations/)

## **สร้างสมการ**

ตัวอย่างนี้ใช้ [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) เพื่อสร้างรูปคณิตศาสตร์และเพิ่มทฤษฎีพีทากอรัส:

![สมการ c² = a² + b²](powerpoint-math-equations_3.png)

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

[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) สร้างรูปร่างที่มี MathParagraph อยู่แล้ว เข้าถึง [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) ตัวแรก, รับ [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/) ของมัน, แล้วเพิ่มบล็อกหรืออิลิเมนต์คณิตศาสตร์เข้าไป

{{% /alert %}}

## **เพิ่มเศษส่วน**

ใช้ [Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) เพื่อสร้างเศษส่วน คุณสามารถเลือกสไตล์ของเศษส่วนด้วย [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/)

![เศษส่วนเอียงที่แสดง 1 ÷ x](powerpoint-math-equations_4.png)

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

สำหรับเศษส่วนแบบซ้อน ใช้ [MathFractionTypes.Bar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/):

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **เพิ่มราก**

ใช้ [Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) เพื่อสร้างรากที่สอง, รากที่สาม หรือรากอื่น ๆ อิลิเมนต์ปัจจุบันกลายเป็นฐาน และอาร์กิวเมนต์กลายเป็นดีกรี

![นิพจน์รากที่ n‑th ที่มี x อยู่ใต้สัญลักษณ์ราก](powerpoint-math-equations_5.png)

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

![ขีดจำกัดของ x เมื่อ x เข้าหาอนันต์](powerpoint-math-equations_8.png)

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

สำหรับชื่อฟังก์ชันที่กำหนดเอง ให้ทำให้ชื่อฟังก์ชันเป็นอิลิเมนต์ปัจจุบันและเรียก [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) พร้อมอาร์กิวเมนต์ของมัน:

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **เพิ่มตัวดำเนินการ N‑ary และอินทิกรัล**

ใช้ [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) สำหรับผลบวก, ยูเนียน, อินเตอร์เซกชัน, และตัวดำเนินการขนาดใหญ่อื่น ๆ ใช้ [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) สำหรับอินทิกรัล ทั้งสองเมธอดให้คุณตั้งค่าขีดจำกัดบนและล่าง

![ผลบวกที่มีขีดจำกัดบนและล่าง](powerpoint-math-equations_7.png)

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

ตัวดำเนินการ N‑ary ใช้สำหรับตัวดำเนินการขนาดใหญ่ที่อาจมีขีดจำกัด ตัวดำเนินการธรรมดาเช่น `+`, `-`, และ `=` มักจะเพิ่มเป็น [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) แล้วต่อเข้ากับนิพจน์

สำหรับอินทิกรัล ให้ใช้ [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/):

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **เพิ่มเมทริกซ์**

ใช้ [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) สำหรับแถวและคอลัมน์ เมทริกซ์โดยปกติไม่รวมวงเล็บ หากต้องการวงเล็บ, วงกลม, หรือเครื่องหมายปีกกา ให้ครอบเมทริกซ์ด้วยสัญลักษณ์นั้นเอง

![เมทริกซ์คณิตศาสตร์สองแถวที่มีเซลล์ว่างหนึ่งช่อง](powerpoint-math-equations_10.png)

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

ใช้ [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) เมื่อคุณต้องการสมการที่จัดแนวกันหรือสแตกแนวตั้งของนิพจน์

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

ใช้ [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) เมื่ออาร์กิวเมนต์เป็นอิลิเมนต์ปัจจุบันและชื่อฟังก์ชันเป็นที่ทราบแล้ว

![ฟังก์ชันตรีโกณมิติ cos ที่ประยุกต์กับ 2x](powerpoint-math-equations_6.png)

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

## **เพิ่มตัวห้อยและตัวเล่น**

ใช้ตัวช่วยสำหรับตัวห้อยและตัวเล่นสำหรับดัชนีและพาวเวอร์ เมื่อดัชนีต้องอยู่ด้านซ้ายของฐาน ให้ใช้ [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/)

![อักษร Y ตัวพิมพ์ใหญ่ที่มีตัวห้อย 1 ด้านซ้ายและตัวเล่น n ด้านขวา](powerpoint-math-equations_9.png)

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

## **เพิ่มตัวคั่น**

ใช้ [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) เพื่อนำนิพจน์ใส่ในตัวคั่น คุณยังสามารถตั้งค่าตัวอักษรคั่นสำหรับนิพจน์ที่มีหลายอิลิเมนต์ได้

![นิพจน์ตัวคั่นที่ประกอบด้วย x, y, และ z คั่นด้วยเส้นตั้งแนวตั้ง](powerpoint-math-equations_13.png)

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

### **ขนาดและการจัดตำแหน่งตัวคั่น**

ตั้งค่า [GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) เป็น `true` เพื่อให้วงเล็บขยายตามความสูงของออเปอแรนด์, หรือเป็น `false` เพื่อคงขนาดปกติ [DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) มีค่าหนึ่งในสองค่าของ [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/) `Centered` จะทำให้วงเล็บอยู่กึ่งกลางแกนคณิตศาสตร์ ซึ่งผ่านกลางเครื่องหมายเท่ากับ `Match` จะจัดตำแหน่งให้ตรงกับเนื้อหาที่อยู่ภายใน ทั้งสองการตั้งค่าใช้ได้เฉพาะกับตัวคั่น ส่วนนิพจน์ภายในคงเดิม

ตัวอย่างวางเศษส่วนในเลขชี้กำลังของ `x` ทำให้นิพจน์ขยายออกเหนือเส้นฐานมากกว่าต่ำกว่า ทั้งสี่สมการใช้วงเล็บและการตั้งค่าแบบอักษรเดียวกัน

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

ใน PowerPoint ให้เปรียบเทียบแถวเพื่อดูผลของการขยาย ในแถวบนวงเล็บจะขยายเพื่อครอบเลขชี้กำลังและดูเหมือนกันสำหรับทั้งสองรูปร่าง ในแถวล่างการขยายถูกปิด วงเล็บที่เล็กกว่าด้านซ้าย (`Centered`) จะจัดให้ตรงกับเครื่องหมายเท่ากับ, ส่วนด้านขวา (`Match`) จะอยู่สูงกว่ารอบนิพจน์

![สี่สมการใน PowerPoint ที่เปิดและปิดการขยายตัวคั่น, โดยด้านซ้ายเป็น Centered และด้านขวาเป็น Match](delimiter-sizing.png)

## **เพิ่มกรอบขอบ**

ใช้ [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) เมื่อสมการเองต้องการกรอบ

![สมการที่มีกรอบแสดง a² = b² + c²](powerpoint-math-equations_12.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var boxedEquation = new MathematicalText("a")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("b").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("c").SetSuperscript("2"))
    .ToBorderBox();

mathParagraph.Add(new MathBlock(boxedEquation));

presentation.Save("border-box.pptx", SaveFormat.Pptx);
```

## **จัดกลุ่มเทอม**

ใช้ [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) เพื่อวางอักขระจัดกลุ่มเหนือหรือใต้นิพจน์ เพิ่มขีดจำกัดเพื่อทำเครื่องหมายเทอมที่จัดกลุ่ม

![นิพจน์ x + y ที่จัดกลุ่มโดยมีป้าย any text ด้านล่าง](powerpoint-math-equations_15.png)

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

## **จัดรูปแบบอิลิเมนต์คณิตศาสตร์**

ใช้ตัวช่วยจัดรูปแบบเฉพาะเมื่อช่วยให้สูตรอ่านง่าย ตัวอย่างเช่น [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) จะวางเส้นขอบเหนืออิลิเมนต์คณิตศาสตร์

![นิพจน์คณิตศาสตร์ ABC พร้อม overbar](powerpoint-math-equations_14.png)

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

### **จัดรูปแบบข้อความในสมการที่มีอยู่แล้ว**

เพื่อจัดรูปแบบข้อความทั่วทั้งสมการที่มีอยู่แล้ว ให้เดินทางผ่านต้นไม้ของอิลิเมนต์ในแต่ละบล็อกคณิตศาสตร์ [IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) จะคืนค่าเฉพาะลูกโดยตรง ดังนั้นจึงต้องเรียกแบบรีเคอร์ซีฟเพื่อเข้าถึงข้อความภายในเศษส่วน, ตัวห้อย, ราก และโครงสร้างซ้อนอื่น ๆ ตรวจสอบอิลิเมนต์ปัจจุบันพร้อมทั้งลูกเพื่อให้รวมอิลิเมนต์เริ่มต้นเมื่อเป็น [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/)

ตัวอย่างนี้สมมติว่าการนำเสนอมีสมการเช่น `z = xᵢ / ∛y` ที่มีเศษส่วนซึ่งตัวชี้บนมีตัวห้อยและตัวหารมีราก การประมวลผลเฉพาะอิลิเมนต์ระดับบนของบล็อกจะทำให้พลาดข้อความภายในเศษส่วน ตัวอย่างจะค้นหา Portion คณิตศาสตร์ในกรอบข้อความสไลด์, เข้าถึงบล็อกผ่าน [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/), แล้วตั้งค่า [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) เป็น 28 พอยต์ผ่านคุณสมบัติ [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/) ของแต่ละอิลิเมนต์ข้อความ

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

การบันทึกการนำเสนอจะมีการจัดรูปแบบข้อความที่อัปเดตในทุกระดับของแต่ละสมการที่ประมวลผล, พร้อมคงไว้ซึ่งเนื้อความและโครงสร้างคณิตศาสตร์เดิม

## **อ้างอิงด่วน**

| งาน | API หลัก |
| --- | --- |
| สร้างข้อความคณิตศาสตร์ | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| รวมอิลิเมนต์ | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| สร้างเศษส่วน | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| เพิ่มตัวเล่นหรือห้อย | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| เพิ่มฟังก์ชัน | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| เพิ่มราก | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| เพิ่มขีดจำกัด | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| เพิ่มตัวห้อยด้านซ้าย | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| เพิ่มผลบวกและอินทิกรัล | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| เพิ่มเมทริกซ์ | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| เพิ่มอาเรย์สมการ | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| เพิ่มตัวคั่น | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| เพิ่มบาร์และกรอบ | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| จัดกลุ่มเทอม | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **คำถามที่พบบ่อย**

**ฉันสามารถแก้ไขสมการ PowerPoint ที่มีอยู่ได้หรือไม่?**

ได้ โดยเปิดการนำเสนอ, ค้นหารูปร่างที่มี [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), ได้รับ [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/) ของมัน, แล้วอัปเดตบล็อกคณิตศาสตร์ในพารากราฟนั้น

**สมการถูกบันทึกเป็นคณิตศาสตร์ PowerPoint ที่แก้ไขได้หรือไม่?**

ได้ เมื่อบันทึกเป็น PPTX, Aspose.Slides จะเขียนสมการเป็นเนื้อหา Office Math ที่แก้ไขได้

**ฉันสามารถส่งออกสมการเป็น LaTeX ได้หรือไม่?**

ได้ ให้รับ [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) จาก [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) ของมัน, แล้วเรียก [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) เพื่อส่งออกโดยตรง ตัวอย่างเต็มดูที่ [Export Math Equations from Presentations in .NET](/slides/th/net/exporting-math-equations/#export-math-equations-to-latex)