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
description: "แทรกและแก้ไขสมการคณิตศาสตร์ใน PowerPoint PPT และ PPTX ด้วย Aspose.Slides สำหรับ .NET รองรับ OMML การควบคุมการจัดรูปแบบ และตัวอย่างโค้ด C# ที่ชัดเจน."
---
## **ภาพรวม**

PowerPoint จัดเก็บสมการเป็น Office Math Markup Language (OMML). ด้วย Aspose.Slides สำหรับ .NET คุณสามารถสร้างเนื้อหาคณิตศาสตร์ประเภทเดียวกันโดยใช้โปรแกรมได้: เศษส่วน, ราก, ฟังก์ชัน, ขีดจำกัด, ตัวดำเนินการ N-ary, เมทริกซ์, อาร์เรย์, และบล็อกคณิตศาสตร์ที่จัดรูปแบบ.

ใน PowerPoint ผู้ใช้มักเพิ่มสมการโดยใช้ **Insert > Equation**:

![แท็บ Insert ของ PowerPoint ที่เลือกคำสั่ง Equation](powerpoint-math-equations_1.png)

ผลลัพธ์คือข้อความคณิตศาสตร์ที่สามารถแก้ไขได้บนสไลด์:

![สไลด์ PowerPoint ที่มีสมการคณิตศาสตร์ที่แก้ไขได้](powerpoint-math-equations_2.png)

Aspose.Slides สร้างข้อความคณิตศาสตร์นั้นผ่านสามอ็อบเจ็กต์หลัก:

- รูปร่างคณิตศาสตร์ที่สร้างด้วย [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/), เป็นรูปร่างที่บรรจุสมการ.
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) เก็บเนื้อหาคณิตศาสตร์ภายในกรอบข้อความของรูปร่าง.
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) มีหนึ่งหรือหลายอ็อบเจ็กต์ [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/).

ตัวอย่างส่วนใหญ่ด้านล่างใช้ [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) และเมธอดเชิงลำดับจาก [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) เพื่อทำให้โค้ดสั้นและอ่านง่าย.

สำหรับสถานการณ์การส่งออก MathML ดูที่ [ส่งออกสมการคณิตย์ศาสตร์จากงานนำเสนอใน .NET](/slides/th/net/exporting-math-equations/).

## **สร้างสมการ**

ตัวอย่างนี้ใช้ [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) เพื่อสร้างรูปร่างคณิตศาสตร์และเพิ่มทฤษฎีบทพีทาโกรัส:

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
[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) สร้างรูปร่างที่มีย่อหน้าคณิตศาสตร์อยู่แล้ว เข้าถึง [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) แรก, รับ [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), และเพิ่มบล็อกคณิตศาสตร์หรืออิลิเมนต์คณิตศาสตร์เข้าไป.
{{% /alert %}}

### **รวมบล็อกคณิตศาสตร์**

เมื่อส่วนของสมการถูกสร้างแยกกันเป็นอ็อบเจ็กต์ [IMathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathblock/) ใช้ [JoinBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathblock/joinblock/) เพื่อรวมเข้าด้วยกัน ตัวอย่างสร้าง `c² =` ในบล็อกซ้ายและ `a² + b²` ในบล็อกขวา. [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/) สร้างซูเปอร์สคริปต์คณิตศาสตร์ที่แก้ไขได้สำหรับทั้งสามพาวเวอร์.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddMathShape(20, 20, 600, 100);
var mathParagraph = ((IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var leftBlock = new MathBlock();
leftBlock.Add(new MathematicalText("c").SetSuperscript("2"));
leftBlock.Add(new MathematicalText("="));

var rightBlock = new MathBlock();
rightBlock.Add(new MathematicalText("a").SetSuperscript("2"));
rightBlock.Add(new MathematicalText("+"));
rightBlock.Add(new MathematicalText("b").SetSuperscript("2"));

var combinedBlock = leftBlock.JoinBlock(rightBlock);
mathParagraph.Add(combinedBlock);

presentation.Save("equation.pptx", SaveFormat.Pptx);
```

[JoinBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathblock/joinblock/) คืนค่า `leftBlock` ตัวเอง ตอนนี้บรรจุส่วนทั้งสองตามลำดับและทำให้ `rightBlock` ว่าง. เพิ่มบล็อกที่รวมแล้วไปที่ [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) เพียงครั้งเดียว. หลังจากเปิดไฟล์ `equation.pptx` ใหม่ ย่อหน้าจะมีบล็อกเดียวที่แสดง `c² = a² + b²` พร้อมกับตัวยกกำลังทั้งสามที่คงเป็นซูเปอร์สคริปต์คณิตศาสตร์.

การเรียก [Add](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelementcollection/add/) เป็น `leftBlock.Add(rightBlock)` จะพยายามใส่บล็อกหนึ่งภายในอีกบล็อกหนึ่งโดยตรงและจะทำให้เกิด `InvalidOperationException`.

## **เพิ่มเศษส่วน**

ใช้ [Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) เพื่อสร้างเศษส่วน คุณสามารถเลือกสไตล์ของเศษส่วนด้วย [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/).

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

สำหรับเศษส่วนแบบซ้อนกัน, ใช้ [MathFractionTypes.Bar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/):

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **เพิ่มราก**

ใช้ [Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) เพื่อสร้างรากที่สอง, รากที่สาม, หรือรากอื่น ๆ โดยอิลิเมนต์ปัจจุบันจะเป็นฐานและอาร์กิวเมนต์จะเป็นดีกรี.

![นิพจน์ราก n-th ที่มี x อยู่ภายใต้สัญลักษณ์ราก](powerpoint-math-equations_5.png)

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

### **แสดงหรือซ่อนดีกรีของรากที่สอง**

รากที่สองสามารถแสดงเลข 2 อย่างชัดเจนหรือใช้สัญลักษณ์ √x แบบทั่วไป. คุณสมบัติ [HideDegree](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/hidedegree/) ของ [IMathRadical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/) ควบคุมรูปแบบที่แสดง. ทั้งสองรูปแบบยังคงเก็บดีกรี 2 และราก x ไว้ในสมการที่แก้ไขได้.

![รากที่สองเดียวกันโดยตั้ง HideDegree เป็น false ทางซ้ายและ true ทางขวา](square-root-degree.png)

ตัวอย่างบันทึกรากที่สองเดียวกันสองครั้ง. ใน `visible-degree.pptx` เลข 2 จะมองเห็นได้. ใน `hidden-degree.pptx` จะถูกซ่อน.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var radical = new MathematicalText("x").Radical("2");

var shape = slide.Shapes.AddMathShape(20, 20, 200, 100);
var portion = (IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
portion.MathParagraph.Add(new MathBlock(radical));

radical.HideDegree = false;
presentation.Save("visible-degree.pptx", SaveFormat.Pptx);

radical.HideDegree = true;
presentation.Save("hidden-degree.pptx", SaveFormat.Pptx);
```

## **เพิ่มฟังก์ชันและขีดจำกัด**

ใช้ [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) หรือ [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) สำหรับฟังก์ชันเช่น `sin(x)`, `log(x)`, หรือชื่อฟังก์ชันที่กำหนดเอง. สำหรับขีดจำกัด ให้ใส่ `lim` ใน [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/) หรือใช้ [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/).

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

สำหรับชื่อฟังก์ชันที่กำหนดเอง ทำให้ชื่อฟังก์ชันเป็นอิลิเมนต์ปัจจุบันและเรียก [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) พร้อมอาร์กิวเมนต์:

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **เพิ่มตัวดำเนินการ N-ary และอินทิกรัล**

ใช้ [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) สำหรับผลบวก, ยูเนียน, อินเตอร์เซคชัน, และตัวดำเนินการใหญ่อื่น ๆ. ใช้ [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) สำหรับอินทิกรัล. ทั้งสองวิธีให้คุณตั้งค่าขีดจำกัดล่างและบน.

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

ตัวดำเนินการ N-ary ใช้สำหรับตัวดำเนินการใหญ่ที่มีขีดจำกัดเป็นตัวเลือก. ตัวดำเนินการง่ายเช่น `+`, `-`, และ `=` มักจะเพิ่มเป็น [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) แล้วรวมเข้าไปในนิพจน์.

สำหรับอินทิกรัล, ใช้ [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/):

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **เพิ่มเมทริกซ์**

ใช้ [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) สำหรับแถวและคอลัมน์. เมทริกซ์โดยปกติไม่มีวงเล็บ, ดังนั้นให้ใส่วงเล็บหรือวงหุ้มเมื่อจำเป็น.

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

### **แก้ไขเมทริกซ์ที่มีอยู่**

สมมติว่าในบทเรียนพีชคณิตเชิงเส้นเริ่มต้นด้วยเมทริกซ์สัมประสิทธิ์ใน `matrix.pptx` ที่บันทึกจากตัวอย่างก่อนหน้า. สำหรับแบบฝึกหัดต่อไป ให้เก็บสมการแรก, แทนที่สมการที่สองด้วยสมการใหม่สองสมการ, และแก้ไขชุดตัวแปร. เปิดเมทริกซ์ที่มีอยู่ผ่าน [IMathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/) เพื่อเก็บค่าสัมประสิทธิ์ที่ยังใช้ได้.

![เมทริกซ์สัมประสิทธิ์สองแถวต้นฉบับที่มีค่า 1, x, และเซลล์ว่างในแถวแรก และ x, 2, และ y ในแถวที่สอง](matrix-before-edit.png)

ดัชนีแถวและคอลัมน์เริ่มต้นที่ศูนย์และอ้างอิงเมทริกซ์ตามสภาพในแต่ละการเรียก. การแทรกแถวก่อนดัชนี 1 จะย้ายแถวที่สองเดิมไปที่ดัชนี 2. การแทรกหลังดัชนี 2 จะเพิ่มแถวต่อไป. การลบแถว 2 จะลบสมการที่สองเดิมและย้ายแถวที่เพิ่มขึ้นขึ้นหนึ่งตำแหน่ง. คอลัมน์ก็เลื่อนในลักษณะเดียวกัน.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation("matrix.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var portion = (IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
var matrix = (IMathMatrix)portion.MathParagraph[0][0];

matrix.InsertRowBefore(1);
matrix.InsertRowAfter(2);
matrix.DeleteRow(2);

matrix.InsertColumnBefore(1);
matrix.InsertColumnAfter(3);
matrix.DeleteColumn(3);

// เซลล์ใหม่เริ่มต้นเป็น null. ตั้งค่าสัมประสิทธิ์ที่ไม่เป็นศูนย์ก่อน.
matrix[1, 0] = new MathematicalText("12");
matrix[1, 1] = new MathematicalText("1");
matrix[2, 2] = new MathematicalText("10");
matrix[2, 3] = new MathematicalText("1");
for (var row = 0; row < matrix.RowCount; row++)
{
    for (var column = 0; column < matrix.ColumnCount; column++)
    {
        matrix[row, column] ??= new MathematicalText("0");
    }
}

matrix.SetColumnAlignment(0, MathHorizontalAlignment.Left);
matrix.SetColumnsAlignment(1, 3, MathHorizontalAlignment.Right);

presentation.Save("updated-matrix.pptx", SaveFormat.Pptx);
```

[SetColumnAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnalignment/) จัดแนวคอลัมน์แรกไปด้านซ้าย. [SetColumnsAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnsalignment/) จัดแนวคอลัมน์ต่อเนื่องสามคอลัมน์ไปด้านขวา, เริ่มจากดัชนี 1. ใน `updated-matrix.pptx`, เมทริกซ์มีสามสมการและสี่ตัวแปร. สัมประสิทธิ์แถวแรกเดิม `1` และ `x` ปรากฏในคอลัมน์แรกและคอลัมน์ที่สามแล้ว.

![เมทริกซ์สามแถวที่อัปเดตแสดงแถว 1, 0, x, 0; 12, 1, 0, 0; และ 0, 0, 10, 1](matrix-after-edit.png)

## **เพิ่มอาร์เรย์สมการ**

ใช้ [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) เมื่อคุณต้องการสมการที่จัดแนวหรือสแต็คแนวตั้งของนิพจน์.

![อาร์เรย์คณิตศาสตร์แนวตั้งที่มี x อยู่เหนือ y](powerpoint-math-equations_11.png)

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

### **จัดตำแหน่งอาร์เรย์กับอิลิเมนต์โดยรอบ**

[IMathArray.BaseJustification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/basejustification/) ควบคุมการจัดแนวแนวตั้งของอาร์เรย์เทียบกับอิลิเมนต์คณิตศาสตร์ข้างเคียง. ตัวอย่างด้านล่างเปรียบเทียบการจัดแนวกับแถวแรก, ศูนย์ของอาร์เรย์, และแถวสุดท้าย.

ตัวอย่างต่อไปนี้สร้างอาร์เรย์สามชุดที่เหมือนกัน, แต่ละชุดมีสามแถวและอิลิเมนต์ใกล้เคียง `A=` และ `=B`. ข้อความคณิตศาสตร์ทั้งหมดใช้ Cambria Math ขนาด 24 จุด. มีเพียงการจัดแนวอาร์เรย์ที่แตกต่าง.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(780, 200, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var alignments = new[] { MathVerticalAlignment.Top, MathVerticalAlignment.Center, MathVerticalAlignment.Bottom };

for (int i = 0; i < alignments.Length; i++)
{
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20 + i * 260, 10, 240, 30);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;
    label.TextFrame.Text = alignments[i].ToString();
    var labelFormat = label.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    labelFormat.FontHeight = 16;
    labelFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var mathShape = slide.Shapes.AddMathShape(20 + i * 260, 60, 240, 130);
    mathShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    var mathParagraph = ((IMathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    mathParagraph.Justification = MathJustification.LeftJustified;

    var rows = new IMathElement[] { CreateText("x+y=3"), CreateText("x-y=1"), CreateText("x=2") };
    var equationArray = new MathArray(rows);
    equationArray.BaseJustification = alignments[i];
    var equation = new MathBlock(CreateText("A=")).Join(equationArray).Join(CreateText("=B"));
    mathParagraph.Add(equation);
}

presentation.Save("equation-array-alignment.pptx", SaveFormat.Pptx);

MathematicalText CreateText(string value)
{
    var text = new MathematicalText(value);
    text.Format.FontHeight = 24;
    text.Format.LatinFont = new FontData("Cambria Math");
    return text;
}
```

การเปรียบเทียบต่อไปนี้แสดงการบันทึกงานนำเสนอใน PowerPoint. สังเกตตำแหน่งของ `A=` และ `=B` ใกล้ๆ แต่ละอาร์เรย์.

![อาร์เรย์สมการใน PowerPoint ที่จัดแนวบน, กลาง, และล่าง พร้อมอิลิเมนต์โดยรอบที่เหมือนกัน](equation-array-alignment.png)

### **กำหนดระยะห่างแถว**

[RowSpacingRule](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacingrule/) เลือกกฎการเว้นระยะห่างสำหรับแถวภายในอาร์เรย์. [RowSpacing](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacing/) ให้ค่าตัวเลขสำหรับกฎการเว้นระยะห่างโดยตรงและจะถูกละเลยเมื่อใช้กฎสำเร็จรูป.

สำหรับการเว้นระยะห่างที่แม่นยำ ค่าเป็นหน่วยจุด. สำหรับการเว้นระยะห่างแบบสัดส่วน จะใช้หน่วยครึ่งบรรทัด: ค่า `3` ในตัวอย่างหมายถึง 1.5 บรรทัด. ตั้งค่าทั้งสองคุณสมบัติโดยระบุค่าตัวเลขโดยตรง; การเปลี่ยนค่าตัวเลขอย่างเดียวจะไม่เลือกกฎการเว้นระยะห่าง.

ตัวอย่างต่อไปนี้บันทึกงานนำเสนอห้าฉบับที่มีสมการ, การจัดแนว, และการตั้งค่าฟอนต์เดียวกัน. สามฉบับแรกใช้ค่าพรีเซ็ต; สองฉบับสุดท้ายแสดงค่าที่ระบุโดยตรง.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

var settings = new (MathRowSpacingRule Rule, uint Spacing)[]
{
    (MathRowSpacingRule.SingleLineGap, 0),
    (MathRowSpacingRule.OneAndAHalfLineGap, 0),
    (MathRowSpacingRule.TwoLineGap, 0),
    (MathRowSpacingRule.Exactly, 20),
    (MathRowSpacingRule.Multiple, 3)
};

foreach (var setting in settings)
{
    var fileName = $"equation-array-{setting.Rule}.pptx";
    using (var presentation = new Presentation())
    {
        var mathShape = presentation.Slides[0].Shapes.AddMathShape(20, 20, 600, 300);
        var paragraph = mathShape.TextFrame.Paragraphs[0];
        paragraph.ParagraphFormat.SpaceBefore = 0;
        paragraph.ParagraphFormat.SpaceAfter = 0;
        var mathParagraph = ((IMathPortion)paragraph.Portions[0]).MathParagraph;
        mathParagraph.Justification = MathJustification.LeftJustified;

        var rows = new IMathElement[] { CreateText("x+y=3"), CreateText("x-y=1"), CreateText("x=2") };
        var equationArray = new MathArray(rows);
        equationArray.BaseJustification = MathVerticalAlignment.Center;
        equationArray.RowSpacingRule = setting.Rule;
        equationArray.RowSpacing = setting.Spacing;
        var equation = new MathBlock(CreateText("A=")).Join(equationArray).Join(CreateText("=B"));
        mathParagraph.Add(equation);

        presentation.Save(fileName, SaveFormat.Pptx);
    }

}

MathematicalText CreateText(string value)
{
    var text = new MathematicalText(value);
    text.Format.FontHeight = 24;
    text.Format.LatinFont = new FontData("Cambria Math");
    return text;
}
```

การเว้นระยะห่างของแถวอาร์เรย์แยกจากการเว้นระยะห่างของย่อหน้า. [SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) และ [SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/) เพิ่มระยะห่างรอบย่อหน้าที่บรรจุ, ไม่ได้เพิ่มระยะห่างระหว่างแถวอาร์เรย์. เช่นเดียวกับนี้, [IMathParagraph.Justification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/justification/) กำหนดตำแหน่งแนวนอนของย่อหน้าคณิตศาสตร์ทั้งหมด; ไม่ได้แทนที่การตั้งค่าการจัดแนวแนวตั้งของอาร์เรย์.

## **เพิ่มฟังก์ชันตรีโกณมิติ**

ใช้ [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) เมื่ออาร์กิวเมนต์เป็นอิลิเมนต์ปัจจุบันและชื่อฟังก์ชันทราบแล้ว.

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

## **เพิ่มตัวห้อยและตัวยก**

ใช้ตัวช่วยห้อยและยกสำหรับดัชนีและพลัง. เมื่อดัชนีต้องแสดงทางด้านซ้ายของฐาน, ใช้ [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/).

![อักษร Y ตัวพิมพ์ใหญ่ที่มีตัวห้อย 1 ด้านซ้ายและตัวยก n ด้านบน](powerpoint-math-equations_9.png)

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

### **จัดตำแหน่งตัวห้อยและตัวยกทางขวา**

เมื่อสคริปต์ทั้งสองอ้างอิงฐานเดียวกัน ให้ใช้ [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathrightsubsuperscriptelement/). คุณสมบัติ [AlignScripts](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathrightsubsuperscriptelement/alignscripts/) ควบคุมตำแหน่งแนวนอนของสคริปต์: `false` (ค่าเริ่มต้น) ทำให้สคริปต์ตามลักษณะของฐาน, ส่วน `true` ทำให้สคริปต์จัดแนวนอนกัน.

ตัวอย่างนี้วางสำเนาสมการที่แก้ไขได้สองชุดข้างกัน. ทั้งสองใช้อักษรเอียงคณิตศาสตร์ f (U+1D453), ตัวห้อยล่าง 1, ตัวยกบน 2, และ Cambria Math ขนาด 72 จุด. ฐานที่เอียงทำให้เห็นความแตกต่างใน PowerPoint. ติดตั้ง Cambria Math ก่อนรันตัวอย่าง.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(900, 250, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var format = new PortionFormat
{
    FontHeight = 72,
    LatinFont = new FontData("Cambria Math")
};

for (var i = 0; i < 2; i++)
{
    var left = 40 + i * 440;
    var shape = slide.Shapes.AddMathShape(left, 75, 380, 150);

    var baseText = new MathematicalText("\U0001D453", format);
    var subscript = new MathematicalText("1", format);
    var superscript = new MathematicalText("2", format);
    var scripts = new MathRightSubSuperscriptElement(baseText, subscript, superscript);
    scripts.AlignScripts = i == 1;

    var portion = (MathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FontHeight = format.FontHeight;
    portion.PortionFormat.LatinFont = format.LatinFont;
    portion.MathParagraph.Add(new MathBlock(scripts));
}

presentation.Save("aligned-scripts.pptx", SaveFormat.Pptx);
```

![สองนิพจน์ที่แก้ไขได้ใน PowerPoint ที่ AlignScripts ตั้งค่าเป็น false ทางซ้ายและ true ทางขวา](aligned-scripts.png)

ด้านซ้าย, ตัวห้อยล่างเริ่มอยู่ซ้ายกว่าตัวยกบนตามลักษณะฐาน. ด้านขวา, สคริปต์ทั้งสองจัดแนวนอนกัน.

## **เพิ่มตัวจำกัด**

ใช้ [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) เพื่อใส่นิพจน์ภายในเครื่องหมายจำกัด. คุณยังสามารถตั้งอักขระคั่นสำหรับนิพจน์จำกัดที่มีหลายองค์ประกอบได้.

![นิพจน์จำกัดที่มี x, y, และ z แยกด้วยแถบแนวตั้ง](powerpoint-math-equations_13.png)

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

### **ขนาดและจัดตำแหน่งตัวจำกัด**

ตั้งค่า [GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) เป็น `true` ให้วงเล็บขยายรอบออปอเรนด์สูง, หรือเป็น `false` ให้คงขนาดเดิม. [DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) รับค่าใดค่าหนึ่งจากสองค่าใน [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/). `Centered` จัดศูนย์วงเล็บบนแกนคณิตศาสตร์ที่วิ่งผ่านกลางเครื่องหมายเท่ากับ. `Match` จัดตำแหน่งให้ตรงกับเนื้อหาที่อยู่ภายใน. ทั้งสองการตั้งค่าส่งผลต่อเพียงตัวจำกัด. นิพจน์ภายในคงเดิม.

ตัวอย่างนี้ใส่เศษส่วนเข้าไปในเลขชี้กำลังของ `x` ทำให้นิพจน์ขยายสูงกว่าพื้นฐาน. สมการสี่สมการใช้วงเล็บและการตั้งค่าฟอนต์เดียวกัน.

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

ใน PowerPoint, เปรียบเทียบแถวเพื่อดูผลของการขยาย. แถวบน, วงเล็บขยายเพื่อครอบเลขชี้กำลังและดูเหมือนกันสำหรับสองรูปร่าง. แถวล่าง, การขยายปิด. วงเล็บเล็กกว่าด้านซ้าย (`Centered`) จัดตำแหน่งกับเครื่องหมายเท่ากัน, ส่วนด้านขวา (`Match`) อยู่สูงกว่ารอบนิพจน์.

![สี่สมการใน PowerPoint ที่เปิดใช้งานการขยายตัวจำกัดด้านบนและปิดด้านล่าง, และ Centered ด้านซ้ายและ Match ด้านขวา](delimiter-sizing.png)

## **เพิ่มกล่องขอบ**

เรียก [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) บนเศษส่วนเพื่อกรอบนิพจน์ทั้งหมด. [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) ที่คืนค่าจะแสดงสี่ด้านโดยค่าเริ่มต้น. ใช้ [HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/), [HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/), [HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/), และ [HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/) เพื่อลบแต่ละด้าน.

ตัวอย่างนี้วางเศษส่วนเดียวกันหกชุดบนสไลด์เดียว. เพื่อแสดงการยกเลิก, ซ่อนสี่ด้านทั้งหมดและตั้งค่า [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/) สำหรับเส้นทแยงขึ้น (↗) หรือ [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/) สำหรับเส้นทแยงลง (↘). คุณยังสามารถใช้ [StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) หรือ [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/) ร่วมกับการแสดงด้านใดด้านหนึ่งได้.

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

![หกเศษส่วนที่แก้ไขได้ใน PowerPoint. แถวบน: กรอบเต็ม, ด้านล่างและซ้าย, เส้นเฉียงขึ้น. แถวล่าง: เส้นเฉียงลง, เส้นแนวนอน, เส้นแนวตั้งกับกรอบเต็ม](border-box-fractions.png)

บนเศษส่วนนี้, เส้นขีดแนวนอนทับแถบเศษส่วน. เส้นขีดแนวตั้งตัดทั้งเศษส่วนบนและล่างขณะที่กรอบรอบข้างยังมองเห็นได้. เส้นเหล่านี้ตกแต่งนิพจน์ทั้งหมด. การขีดเส้นกลางในข้อความทั่วไปจะใช้กับอักขระในรันข้อความ. หลังจากเปิดงานนำเสนอใหม่ใน PowerPoint, คุณยังคงแก้ไขเศษส่วนบนและล่างแยกกันได้.

## **ควบคุมการมองเห็นและการจัดวางด้วย Phantom Elements**

ห่อหุ้มนิพจน์ด้วย [MathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathphantom/) เพื่อควบคุมการมองเห็นและพื้นที่ที่มันก่อให้เกิดในสมการอย่างอิสระ. คุณสมบัติของ [IMathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/) ควบคุมดังต่อไปนี้:

| Property | Effect |
| --- | --- |
| [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) | ตั้งค่าเป็น `false` เพื่อซ่อนนิพจน์. มิติของมันยังคงมีผลต่อการจัดวาง เว้นแต่คุณสมบัติที่เกี่ยวข้องด้านล่างจะเป็น `true`. |
| [ZeroWidth](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerowidth/) | ถือว่าความกว้างแนวนอนของนิพจน์เป็นศูนย์, ทำให้องค์ประกอบใกล้เคียงเคลื่อนที่เข้าหากันได้. |
| [ZeroAsc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zeroasc/) | ถือว่าการยกขึ้น (ascent) ของมันเป็นศูนย์, ซึ่งสามารถลดพื้นที่ที่สงวนไว้เหนือองค์ประกอบใกล้เคียง. |
| [ZeroDesc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerodesc/) | ถือว่าการลงล่าง (descent) ของมันเป็นศูนย์, ซึ่งสามารถย้ายแถบเศษส่วนหรือเนื้อหาอื่น ๆ ใต้นิพจน์ให้ใกล้กับเพื่อนบ้านมากขึ้น. |

Baseline คือเส้นอ้างอิงที่อักษรคณิตศาสตร์ทั่วไปวางอยู่. การซ่อนเนื้อหาไม่ทำให้มิติหายไป, และการถือมิติเป็นศูนย์ไม่ทำให้นิพจน์หายไป. นิพจน์พื้นฐานยังคงเข้าถึงได้ผ่าน [Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/base/). ตั้งค่า [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) กลับเป็น `true` เพื่อแสดงอีกครั้ง; การตั้งค่ามิติจะคงเดิม.

ตัวอย่างด้านล่างสร้างห้ารูปแบบข้างกัน: เศษส่วนที่มองเห็น, เศษส่วนที่ซ่อนแต่สงวนพื้นที่, และเศษส่วนที่ซ่อนพร้อมหนึ่งมิติเป็นศูนย์. แต่ละรูปแบบใช้นิพจน์โดยรอบเดียวกันและ Cambria Math ขนาด 24 จุด. รูปสมการทั้งหมดมีตำแหน่งบนเดียวกัน, ทำเครื่องหมายด้วยไกด์สีเทา. การวาง phantom ในเศษส่วนบนสุดทำให้เห็นการเปลี่ยนแปลงการจัดวางแนวตั้งได้ง่ายขึ้น.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(1000, 180, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var labels = new[] { "Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc" };

var guide = slide.Shapes.AddAutoShape(ShapeType.Line, 10, 60, 980, 0);
guide.LineFormat.FillFormat.FillType = FillType.Solid;
guide.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightGray;

for (var i = 0; i < labels.Length; i++)
{
    var left = 10 + i * 200;
    
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, left, 10, 190, 30);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;
    label.TextFrame.Text = labels[i];

    var labelFormat = label.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    labelFormat.FontHeight = 14;
    labelFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var fraction = new MathFraction(CreateText("a+b"), CreateText("c+d"));
    var phantom = new MathPhantom(fraction);
    phantom.Show = i == 0;
    phantom.ZeroWidth = i == 2;
    phantom.ZeroAsc = i == 3;
    phantom.ZeroDesc = i == 4;

    var numerator = new MathBlock(CreateText("x+")).Join(phantom).Join(CreateText("+y"));
    var equation = new MathFraction(numerator, CreateText("z"));

    var shape = slide.Shapes.AddMathShape(left, 60, 190, 100);
    shape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;

    var mathParagraph = ((IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    mathParagraph.Add(new MathBlock(equation));
}

presentation.Save("math-phantom.pptx", SaveFormat.Pptx);

MathematicalText CreateText(string value)
{
    var text = new MathematicalText(value);
    text.Format.FontHeight = 24;
    text.Format.LatinFont = new FontData("Cambria Math");
    return text;
}
```

![ห้าสมการใน PowerPoint ที่เปรียบเทียบเศษส่วนที่มองเห็น, เศษส่วนที่ซ่อนแต่สงวนพื้นที่, และเศษส่วนที่ซ่อนพร้อม ZeroWidth, ZeroAsc หรือ ZeroDesc เปิดใช้งาน](math-phantom.png)

## **จัดกลุ่มเงื่อนไข**

ใช้ [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) เพื่อวางอักขระการจัดกลุ่มเหนือหรือใต้นิพจน์. เพิ่มขีดจำกัดเพื่อระบุกลุ่มเงื่อนไข.

![นิพจน์ x + y ที่จัดกลุ่มพร้อมป้าย any text ด้านล่าง](powerpoint-math-equations_15.png)

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

ใช้ตัวช่วยการจัดรูปแบบเฉพาะเมื่อช่วยให้สูตรชัดเจน. ตัวอย่างเช่น, [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) ใส่แถบเหนืออิลิเมนต์คณิตศาสตร์.

![นิพจน์คณิตศาสตร์ ABC ที่มีเส้นขีดเหนือ](powerpoint-math-equations_14.png)

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

### **จัดรูปแบบข้อความในสมการที่มีอยู่**

เพื่อจัดรูปแบบข้อความทั่วทั้งสมการที่มีอยู่, ให้เดินทางผ่านต้นไม้ของอิลิเมนต์แต่ละบล็อกคณิตศาสตร์. [IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) ส่งคืนเฉพาะบุตรที่อยู่ตรงต่อ, ดังนั้นต้องเรียกซ้ำเพื่อเข้าถึงข้อความในเศษส่วน, สคริปต์, ราก, และโครงสร้างซ้อนอื่น ๆ. ตรวจสอบอิลิเมนต์ปัจจุบันและบุตรของมันเพื่อรวมอิลิเมนต์เริ่มต้นเมื่อเป็น [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/).

ตัวอย่างนี้สมมติว่าการนำเสนอมีสมการเช่น `z = xᵢ / ∛y`, โดยเศษส่วนมีตัวห้อยในเศษส่วนบนและรากในส่วนล่าง. การประมวลผลเฉพาะอิลิเมนต์ระดับบนของบล็อกจะทำให้พลาดข้อความในเศษส่วน. ตัวอย่างค้นหาบทคณิตศาสตร์ในกรอบข้อความสไลด์, เข้าถึงบล็อกผ่าน [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/), และตั้งค่า [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) เป็น 28 จุดผ่านคุณสมบัติ [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/) ของอิลิเมนต์ข้อความแต่ละตัว.

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

งานนำเสนอที่บันทึกแล้วมีการจัดรูปแบบข้อความที่อัปเดตในทุกระดับของสมการที่ประมวลผล, พร้อมการรักษาเนื้อความและโครงสร้างคณิตศาสตร์เดิม.

## **อ้างอิงด่วน**

| งาน | API หลัก |
| --- | --- |
| สร้างข้อความคณิตศาสตร์ | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| รวมอิลิเมนต์ | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| สร้างเศษส่วน | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| เพิ่มตัวยกหรือห้อย | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| เพิ่มฟังก์ชัน | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| เพิ่มราก | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| เพิ่มขีดจำกัด | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| เพิ่มสคริปต์ด้านซ้าย | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| เพิ่มผลบวกและอินทิกรัล | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| เพิ่มเมทริกซ์ | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| เพิ่มอาร์เรย์สมการ | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| เพิ่มตัวจำกัด | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| เพิ่มแถบและขอบ | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| จัดกลุ่มเงื่อนไข | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **คำถามที่พบบ่อย**

**ฉันสามารถแก้ไขสมการ PowerPoint ที่มีอยู่ได้หรือไม่?**

ใช่. เปิดงานนำเสนอ, ค้นหารูปร่างที่บรรจุ [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), รับ [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), และอัปเดตบล็อกคณิตศาสตร์ในย่อหน้านั้น.

**สมการถูกบันทึกเป็นคณิตศาสตร์ PowerPoint ที่แก้ไขได้หรือไม่?**

ใช่. เมื่อบันทึกเป็น PPTX, Aspose.Slides จะเขียนสมการเป็นคอนเทนต์ Office Math ที่แก้ไขได้.

**ฉันสามารถส่งออกสมการเป็น LaTeX ได้หรือไม่?**

ใช่. รับ [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) ของสมการจาก [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), แล้วเรียก [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) เพื่อส่งออกโดยตรง. สำหรับตัวอย่างครบถ้วน, ดูที่ [ส่งออกสมการคณิตย์ศาสตร์จากงานนำเสนอใน .NET](/slides/th/net/exporting-math-equations/#export-math-equations-to-latex).