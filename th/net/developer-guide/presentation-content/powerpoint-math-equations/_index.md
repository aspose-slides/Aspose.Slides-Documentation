---
title: เพิ่มสมการคณิตศาสตร์ไปยังการนำเสนอ PowerPoint ใน .NET
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
description: "แทรกและแก้ไขสมการคณิตศาสตร์ใน PowerPoint PPT และ PPTX ด้วย Aspose.Slides สำหรับ .NET รองรับ OMML, การควบคุมรูปแบบ, และตัวอย่างโค้ด C# ที่ชัดเจน."
---
## **ภาพรวม**

PowerPoint เก็บสมการเป็น Office Math Markup Language (OMML). ด้วย Aspose.Slides สำหรับ .NET คุณสามารถสร้างเนื้อหาคณิตศาสตร์ประเภทเดียวกันโดยเขียนโปรแกรม: เศษส่วน, ราดิกัล, ฟังก์ชัน, ขีดจำกัด, ตัวดำเนินการ N-ary, เมทริกซ์, อาร์เรย์, และบล็อกคณิตศาสตร์ที่จัดรูปแบบ

ใน PowerPoint ผู้ใช้ทั่วไปเพิ่มสมการจาก **Insert > Equation**:

![แท็บ Insert ของ PowerPoint ที่เลือกคำสั่ง Equation](powerpoint-math-equations_1.png)

ผลลัพธ์คือข้อความคณิตศาสตร์ที่แก้ไขได้บนสไลด์:

![สไลด์ PowerPoint ที่มีสมการคณิตศาสตร์ที่แก้ไขได้](powerpoint-math-equations_2.png)

- รูปร่างคณิตศาสตร์ที่สร้างด้วย [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/), คือรูปร่างที่บรรจุสมการ
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) เก็บเนื้อหาคณิตศาสตร์ภายในกรอบข้อความของรูปร่าง
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) มีหนึ่งหรือหลายวัตถุ [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/)

ตัวอย่างส่วนใหญ่ด้านล่างใช้ [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) และเมธอดเชิงไหลจาก [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) เพื่อให้โค้ดสั้นและอ่านง่าย

สำหรับสถานการณ์การส่งออก MathML ดูที่ [Export Math Equations from Presentations in .NET](/slides/th/net/exporting-math-equations/)

## **สร้างสมการ**

ตัวอย่างนี้ใช้ [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) เพื่อสร้างรูปร่างคณิตศาสตร์และเพิ่มสูตรพีธากอรัส:

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
[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) สร้างรูปร่างที่มี MathParagraph อยู่แล้ว เข้าถึง [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) ตัวแรก, ดึง [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/) ของมัน, แล้วเพิ่ม MathBlock หรือ MathElement เข้าไป
{{% /alert %}}

## **เพิ่มเศษส่วน**

ใช้ [Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) เพื่อสร้างเศษส่วน คุณสามารถเลือกสไตล์ของเศษส่วนด้วย [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/)

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

สำหรับเศษส่วนซ้อนกัน ให้ใช้ [MathFractionTypes.Bar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/):

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **เพิ่มราดิกัล**

ใช้ [Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) เพื่อสร้างรากกำลังสอง, รากกำลังสาม หรือรากอื่น ๆ อิลิเมนต์ปัจจุบันจะกลายเป็นฐาน และอาร์กิวเมนต์จะเป็นดีกรี

![นิพจน์ราดิกัลรากที่ n โดยมี x อยู่ใต้สัญลักษณ์ราก](powerpoint-math-equations_5.png)

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

### **แสดงหรือซ่อนดีกรีของรากกำลังสอง**

รากกำลังสองสามารถแสดงเลข 2 อย่างชัดเจนหรือใช้สัญลักษณ์ √x ตามปกติ คุณสมบัติ [HideDegree](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/hidedegree/) ของ [IMathRadical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/) ควบคุมรูปแบบที่แสดง ทั้งสองรูปแบบยังคงมีดีกรี 2 และราดิกันต์ x อยู่ในสมการที่แก้ไขได้

![รากกำลังสองเดียวกันที่ตั้งค่า HideDegree เป็น false ด้านซ้ายและ true ด้านขวา](square-root-degree.png)

ตัวอย่างบันทึกรากกำลังสองเดียวกันสองครั้ง ใน `visible-degree.pptx` ตัวเลข 2 ปรากฏอยู่ ใน `hidden-degree.pptx` ตัวเลข 2 ถูกซ่อน

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

ใช้ [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) หรือ [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) สำหรับฟังก์ชันเช่น `sin(x)`, `log(x)`, หรือชื่อฟังก์ชันกำหนดเอง สำหรับขีดจำกัด ใส่ `lim` ใน [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/) หรือใช้ [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/)

![ขีดจำกัดของ x เมื่อ x ใกล้เข้าอนันต์](powerpoint-math-equations_8.png)

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

สำหรับชื่อฟังก์ชันกำหนดเอง ทำให้ชื่อฟังก์ชันเป็นอิลิเมนต์ปัจจุบันและเรียก [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) พร้อมอาร์กิวเมนต์:

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **เพิ่มตัวดำเนินการ N-ary และอินเทกรัล**

ใช้ [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) สำหรับผลรวม, ยูเนียน, อินเตอร์เซกชัน และตัวดำเนินการใหญ่ ๆ อื่น ๆ ใช้ [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) สำหรับอินเทกรัล ทั้งสองเมธอดให้คุณตั้งค่าขีดจำกัดล่างและบน

![ผลรวมที่มีขีดจำกัดล่างและบน](powerpoint-math-equations_7.png)

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

ตัวดำเนินการ N-ary ใช้สำหรับตัวดำเนินการขนาดใหญ่พร้อมขีดจำกัดเลือกได้ ตัวดำเนินการแบบง่ายเช่น `+`, `-`, และ `=` ปกติจะเพิ่มเป็น [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) และรวมเข้ากับนิพจน์

สำหรับอินเทกรัล ให้ใช้ [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/):

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **เพิ่มเมทริกซ์**

ใช้ [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) สำหรับแถวและคอลัมน์ เมทริกซ์โดยปกติไม่รวมวงเล็บ ดังนั้นให้ใส่วงเล็บหรือวงเหลี่ยมเมื่อต้องการ

![เมทริกซ์คณิตศาสตร์สองแถวที่มีช่องว่างหนึ่งช่อง](powerpoint-math-equations_10.png)

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

สมมติว่าบทเรียนพีชคณิตเชิงเส้นเริ่มด้วยเมทริกซ์สัมประสิทธิ์ใน `matrix.pptx` ที่บันทึกโดยตัวอย่างก่อนหน้า สำหรับแบบฝึกหัดต่อไป ให้คงสมการแรกไว้, แทนที่สมการที่สองด้วยสองสมการใหม่, และปรับชุดตัวแปร เปิดเมทริกซ์ที่มีอยู่ผ่าน [IMathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/) เพื่อคงสัมประสิทธิ์ที่ยังใช้ได้

![เมทริกซ์สัมประสิทธิ์สองแถวต้นฉบับที่มีรายการ 1, x, และช่องว่างในแถวแรก; x, 2, และ y ในแถวสอง](matrix-before-edit.png)

ดัชนีแถวและคอลัมน์เริ่มนับจากศูนย์และอ้างอิงเมทริกซ์ตามสถานะ ณ ตอนที่เรียก การแทรกแถวก่อนดัชนี 1 จะเลื่อนแถวที่สองเดิมไปที่ดัชนี 2 การแทรกหลังดัชนี 2 จะเพิ่มแถวใหม่ การลบแถว 2 จะเอาสมการที่สองเดิมออกและเลื่อนแถวที่เพิ่มขึ้นขึ้นหนึ่งตำแหน่ง คอลัมน์ก็ย้ายเช่นกัน

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

[SetColumnAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnalignment/) จัดแนวคอลัมน์แรกซ้าย [SetColumnsAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnsalignment/) จัดแนวสามคอลัมน์ต่อเนื่องขวา ตั้งแต่ดัชนี 1 ใน `updated-matrix.pptx` เมทริกซ์มีสามสมการและสี่ตัวแปร สัมประสิทธิ์แถวแรกต้นฉบับ `1` และ `x` ปรากฏในคอลัมน์แรกและคอลัมน์ที่สาม

![เมทริกซ์สามแถวที่อัปเดตแสดงแถว 1, 0, x, 0; 12, 1, 0, 0; และ 0, 0, 10, 1](matrix-after-edit.png)

## **เพิ่มอาเรย์สมการ**

เมื่อคุณต้องการสมการจัดแนวหรือสแต็คแนวตั้งของนิพจน์ ให้ใช้ [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/)

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

### **จัดแนวอาเรย์กับอิลิเมนต์โดยรอบ**

[IMathArray.BaseJustification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/basejustification/) ควบคุมการจัดแนวแนวตั้งของอาเรย์เทียบกับอิลิเมนต์คณิตศาสตร์ข้างเคียง ตัวอย่างด้านล่างเปรียบเทียบการจัดแนวด้วยแถวแรก, ศูนย์กลางอาเรย์, และแถวสุดท้าย

ตัวอย่างต่อไปสร้างอาเรย์สามอันที่เหมือนกัน ทั้งแต่ละอาเรย์มีสามแถวและอิลิเมนต์เพื่อนบ้าน `A=` และ `=B` ข้อความคณิตศาสตร์ทั้งหมดใช้ Cambria Math ขนาด 24 จุด มีเพียงการจัดแนวอาเรย์ที่เปลี่ยน

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

การเปรียบเทียบต่อไปแสดงงานนำเสนอที่บันทึกใน PowerPoint สังเกตตำแหน่งของ `A=` และ `=B` อยู่ข้างแต่ละอาเรย์

![อาเรย์สมการใน PowerPoint พร้อมการจัดแนวบน, ศูนย์, และล่าง พร้อมอิลิเมนต์เพื่อนบ้านเดียวกัน](equation-array-alignment.png)

### **กำหนดระยะแถว**

[RowSpacingRule](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacingrule/) เลือกกฎการเว้นระยะสำหรับแถวภายในอาเรย์ [RowSpacing](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacing/) ให้ค่าตัวเลขสำหรับกฎเว้นระยะแบบระบุและจะถูกละเลยเมื่อใช้กฎตั้งต้น

สำหรับการเว้นระยะที่แน่นอน ค่าจะวัดเป็นจุด สำหรับการเว้นระยะแบบสัดส่วน ค่าจะวัดเป็นครึ่งบรรทัด: ค่า `3` ในตัวอย่างหมายถึง 1.5 บรรทัด ตั้งค่าทั้งสองคุณสมบัติโดยพร้อมกันเมื่อกำหนดค่าตัวเลขแบบชัดเจน; การเปลี่ยนค่าเชิงตัวเลขอย่างเดียวจะไม่เลือกกฎเว้นระยะ

ตัวอย่างต่อไปบันทึกงานนำเสนอห้าชุดที่มีสมการ, การจัดแนว, และการตั้งค่าฟอนต์เดียวกัน ชุดแรกสามชุดใช้กฎตั้งต้น; สองชุดสุดท้ายแสดงค่าที่ระบุโดยตรง

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

ระยะแถวของอาเรย์แตกต่างจากระยะของย่อหน้า [SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) และ [SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/) จะเพิ่มพื้นที่รอบย่อหน้าที่บรรจุอาเรย์ ไม่ได้เพิ่มระยะระหว่างแถวของอาเรย์ เช่นกัน [IMathParagraph.Justification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/justification/) กำหนดตำแหน่งแนวนอนของ MathParagraph ทั้งหมด; ไม่ได้แทนที่การตั้งค่าการจัดแนวแนวตั้งของอาเรย์

## **เพิ่มฟังก์ชันตรีโกณมิติ**

เมื่ออาร์กิวเมนต์เป็นอิลิเมนต์ปัจจุบันและชื่อฟังก์ชันทราบ ให้ใช้ [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/)

![ฟังก์ชันตรีโกณมิติ cos ที่นำมาประยุกต์กับ 2x](powerpoint-math-equations_6.png)

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

## **เพิ่มซับสคริปต์และซูเปอร์สคริปต์**

ใช้ตัวช่วยสำหรับซับสคริปต์และซูเปอร์สคริปต์สำหรับดัชนีและกำลัง เมื่อดัชนีต้องอยู่ด้านซ้ายของฐาน ให้ใช้ [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/)

![ตัวอักษร Y ตัวพิมพ์ใหญ่ที่มีซับสคริปต์ด้านซ้าย 1 และซูเปอร์สคริปต์ n](powerpoint-math-equations_9.png)

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

ใช้ [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) เพื่อใส่นิพจน์ไว้ในตัวคั่น คุณยังสามารถกำหนดอักขระคั่นสำหรับนิพจน์ที่มีหลายอิลิเมนต์

![นิพจน์ตัวคั่นที่มี x, y, และ z คั่นด้วยแนวตั้งบาร์](powerpoint-math-equations_13.png)

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

### **ขนาดและการจัดแนวตัวคั่น**

ตั้งค่า [GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) เป็น `true` เพื่อให้วงเล็บขยายตามออปเปอแรนด์ที่สูง, หรือเป็น `false` เพื่อคงขนาดปกติ [DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) รับค่าอย่างใดอย่างหนึ่งจาก [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/) `Centered` จะจัดศูนย์วงเล็บบนแกนคณิตศาสตร์ `Match` จะจัดให้ตรงกับเนื้อหาที่ล้อมรอบ ทั้งสองการตั้งค่าใช้กับตัวคั่นเท่านั้น เนื้อหาภายในคงเดิม

ตัวอย่างใส่เศษส่วนเป็นกำลังของ `x` ทำให้นิพจน์ยืดสูงกว่าค่า baseline ทั้งสี่สมาการใช้วงเล็บและการตั้งค่าแบบอักษรเดียวกัน

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

ใน PowerPoint เปรียบเทียบแถวเพื่อดูผลของการขยาย แถวบนวงเล็บขยายเพื่อครอบกำลังและดูเหมือนกันทั้งสองรูปแบบ แถวล่างการขยายปิด วงเล็บเล็กซ้าย (`Centered`) จัดกับสัญลักษณ์เท่ากับ, ส่วนขวา (`Match`) อยู่สูงกว่าตามนิพจน์

![สี่สมการใน PowerPoint พร้อมการขยายตัวคั่นที่เปิดด้านบนและปิดด้านล่าง, และ Centered ด้านซ้าย, Match ด้านขวา](delimiter-sizing.png)

## **เพิ่มกรอบขอบ**

เรียก [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) บนเศษส่วนเพื่อกรอบนิพจน์ทั้งหมด ผลลัพธ์ [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) แสดงสี่ด้านโดยปริยาย ใช้ [HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/), [HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/), [HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/), และ [HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/) เพื่อลบด้านแต่ละด้าน

ตัวอย่างวางสำเนาเศษส่วนเดียวกันหกครั้งบนสไลด์ เพื่อแสดงการยกเว้น ให้ซ่อนสี่ด้านและตั้งค่า [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/) เพื่อเส้นทแยงมาขึ้น (↗) หรือ [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/) เพื่อเส้นทแยงมาลง (↘) คุณยังสามารถใช้ [StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) หรือ [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/) ร่วมกับการตั้งค่าด้านที่มองเห็นได้ตามต้องการ

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

![หกเศษส่วนที่แก้ไขได้ใน PowerPoint. แถวบน: กรอบเต็ม, ด้านล่างและซ้าย, เส้นทแยงขึ้น. แถวล่าง: เส้นทแยงลง, เส้นตัดแนวนอน, เส้นตัดแนวตั้งพร้อมกรอบเต็ม](border-box-fractions.png)

บนเศษส่วนนี้ เส้นตัดแนวนอนทับบาร์ของเศษส่วน เส้นตัดแนวตั้งผ่านเศษส่วนและส่วนล่างในขณะที่กรอบรอบๆ ยังมองเห็นได้ เส้นเหล่านี้ตกแต่งนิพจน์ทั้งหมด ตัวอย่างการขีดเส้นปกติจะทำกับอักขระในไลบรารีข้อความ หลังเปิดงานนำเสนอใหม่ใน PowerPoint คุณยังคงแก้ไขเศษส่วนและส่วนล่างแยกกันได้

## **ควบคุมการมองเห็นและการจัดวางด้วย Phantom Elements**

ห่อหุ้มนิพจน์ด้วย [MathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathphantom/) เพื่อควบคุมการมองเห็นและพื้นที่ที่มันทำให้กับสมการโดยอิสระ คุณสมบัติของ [IMathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/) ควบคุมดังต่อไปนี้:

| คุณสมบัติ | ผล |
| --- | --- |
| [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) | ตั้งค่าเป็น `false` เพื่อซ่อนนิพจน์ มิติต่าง ๆ ยังมีผลต่อการจัดวางจนกว่าจะตั้งค่าคุณสมบัติด้านล่างเป็น `true` |
| [ZeroWidth](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerowidth/) | ถือความกว้างแนวนอนของนิพจน์เป็นศูนย์ ทำให้อิลิเมนต์ข้างเคียงเข้ามาใกล้กัน |
| [ZeroAsc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zeroasc/) | ถือความสูงส่วนที่ยกขึ้นเหนือ baseline เป็นศูนย์ ลดพื้นที่ที่สงวนไว้ด้านบนของอิลิเมนต์ข้างเคียง |
| [ZeroDesc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerodesc/) | ถือความลึกส่วนที่อยู่ต่ำกว่า baseline เป็นศูนย์ ทำให้บาร์ของเศษส่วนหรือเนื้อหาอื่น ๆ ใต้นิพจน์เข้าใกล้เพื่อนบ้านขึ้น |

Baseline คือเส้นอ้างอิงที่อักษรคณิตศาสตร์ตามปกติอยู่ การซ่อนเนื้อหาไม่ได้ลบมิติของมันออก และการถือมิติเป็นศูนย์ไม่ได้ลบนิพจน์ออก นิพจน์พื้นฐานยังคงเข้าถึงได้ผ่าน [Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/base/) ตั้งค่า [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) กลับเป็น `true` เพื่อแสดงอีกครั้ง มิติก็ยังคงตามเดิม

ตัวอย่างต่อไปสร้างห้าตัวแปรแบบข้างเคียง: เศษส่วนที่มองเห็นได้, เศษส่วนที่ซ่อนแต่ยังสงวนพื้นที่, และสามเศษส่วนที่ซ่อนพร้อมหนึ่งมิติจัดเป็นศูนย์ แต่ละแบบใช้ นิพจน์รอบข้างเดียวกันและ Cambria Math ขนาด 24 จุด ทุกรูปร่างสมการมีตำแหน่งบนเดียวกันที่แสดงด้วยไกด์สีเทา การใส่ Phantom ในส่วนบนของเศษส่วนภายนอกทำให้การเปลี่ยนแปลงการจัดวางแนวตั้งเห็นได้ง่ายขึ้น

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

![ห้าสมการใน PowerPoint เปรียบเทียบเศษส่วนที่มองเห็น, เศษส่วนที่ซ่อนแต่สงวนพื้นที่, และเศษส่วนที่ซ่อนพร้อม ZeroWidth, ZeroAsc, หรือ ZeroDesc เปิดใช้งาน](math-phantom.png)

## **จัดกลุ่มเทอม**

ใช้ [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) เพื่อวางอักขระจัดกลุ่มเหนือหรือใต้นิพจน์ เพิ่มขีดจำกัดเพื่อทำป้ายกำกับให้กับเทอมที่จัดกลุ่ม

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

## **จัดรูปแบบ Math Elements**

ใช้ตัวช่วยจัดรูปแบบเฉพาะที่ช่วยให้สูตรชัดเจน เช่น [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) วางบาร์เหนืออิลิเมนต์คณิตศาสตร์

![นิพจน์คณิตศาสตร์ ABC ที่มีเส้นบาร์เหนือข้อความ](powerpoint-math-equations_14.png)

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

เพื่อจัดรูปแบบข้อความทั่วทั้งสมการที่มีอยู่ ให้วนรอบต้นไม้อิลิเมนต์ของแต่ละ MathBlock [IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) จะคืนเฉพาะลูกตรง ดังนั้นเรียกแบบรีเคอร์ซีฟเพื่อเข้าถึงข้อความภายในเศษส่วน, สคริปต์, ราดิกัล, และโครงสร้างซ้อนอื่น ๆ ตรวจสอบอิลิเมนต์ปัจจุบันรวมถึงลูกเพื่อให้รวมอิลิเมนต์เริ่มต้นเมื่อเป็น [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/)

ตัวอย่างนี้สมมติว่ามีการนำเสนอที่มีสมการเช่น `z = xᵢ / ∛y` ที่มีเศษส่วนที่มีซับสคริปต์ในตัวเศษและราดิกัลในตัวส่วน การประมวลผลเฉพาะอิลิเมนต์ระดับบนของบล็อกจะพลาดข้อความภายในเศษส่วน ตัวอย่างค้นหา MathPortion ในกรอบข้อความสไลด์, เข้าถึงบล็อกผ่าน [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/), แล้วตั้งค่า [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) เป็น 28 จุดผ่านคุณสมบัติ [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/) ของแต่ละอิลิเมนต์ข้อความ

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

งานนำเสนอที่บันทึกมีการอัปเดตการจัดรูปแบบข้อความในทุกระดับของสมการที่ประมวลผล, พร้อมคงเนื้อหาและโครงสร้างคณิตศาสตร์เดิม

## **อ้างอิงอย่างรวดเร็ว**

| งาน | API หลัก |
| --- | --- |
| สร้างข้อความคณิตศาสตร์ | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| รวมอิลิเมนต์ | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| สร้างเศษส่วน | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| เพิ่มซูเปอร์สคริปต์หรือซับสคริปต์ | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| เพิ่มฟังก์ชัน | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| เพิ่มราดิกัล | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| เพิ่มขีดจำกัด | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| เพิ่มสคริปต์ด้านซ้าย | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| เพิ่มผลรวมและอินเทกรัล | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| เพิ่มเมทริกซ์ | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| เพิ่มอาเรย์สมการ | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| เพิ่มตัวคั่น | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| เพิ่มบาร์และกรอบ | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| จัดกลุ่มเทอม | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **คำถามที่พบบ่อย**

**ฉันสามารถแก้ไขสมการ PowerPoint ที่มีอยู่ได้หรือไม่?**

ได้ เปิดงานนำเสนอ, ค้นหารูปร่างที่มี [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), ดึง [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/) ของมัน, แล้วอัปเดต MathBlock ในย่อหนนนั้น

**สมการถูกบันทึกเป็น Math ของ PowerPoint ที่แก้ไขได้หรือไม่?**

ได้ เมื่อบันทึกเป็น PPTX, Aspose.Slides จะเขียนสมการเป็นเนื้อหา Office Math ที่แก้ไขได้

**ฉันสามารถส่งออกสมการเป็น LaTeX ได้หรือไม่?**

ได้ ดึง [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) ของสมการจาก [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), แล้วเรียก [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) เพื่อส่งออกโดยตรง สำหรับตัวอย่างเต็ม ดูที่ [Export Math Equations from Presentations in .NET](/slides/th/net/exporting-math-equations/#export-math-equations-to-latex)