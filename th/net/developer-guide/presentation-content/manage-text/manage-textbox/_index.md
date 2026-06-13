---
title: จัดการกล่องข้อความในงานนำเสนอด้วย .NET
linktitle: จัดการกล่องข้อความ
type: docs
weight: 20
url: /th/net/manage-textbox/
keywords:
- กล่องข้อความ
- กรอบข้อความ
- เพิ่มข้อความ
- อัปเดตข้อความ
- สร้างกล่องข้อความ
- ตรวจสอบกล่องข้อความ
- เพิ่มคอลัมน์ข้อความ
- เพิ่มลิงก์
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ทำให้การสร้าง, แก้ไข, และคัดลอกกล่องข้อความในไฟล์ PowerPoint และ OpenDocument เป็นเรื่องง่าย, ช่วยเสริมการทำงานอัตโนมัติของงานนำเสนอของคุณ."
---
## **บทนำ**

ข้อความบนสไลด์มักอยู่ในกล่องข้อความหรือรูปร่าง ดังนั้นเพื่อเพิ่มข้อความไปยังสไลด์ คุณต้องเพิ่มกล่องข้อความก่อนแล้วจึงใส่ข้อความลงในกล่องข้อความ

เพื่อให้คุณสามารถเพิ่มรูปร่างที่สามารถบรรจุข้อความได้ Aspose.Slides for .NET มีอินเทอร์เฟซ [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape) ให้

{{% alert title="Note" color="warning" %}} 

Aspose.Slides ยังให้บริการอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishape) เพื่อให้คุณเพิ่มรูปร่างไปยังสไลด์ได้ อย่างไรก็ตาม ไม่ใช่ทุกรูปร่างที่เพิ่มผ่านอินเทอร์เฟซ `IShape` สามารถบรรจุข้อความได้ รูปร่างที่เพิ่มผ่านอินเทอร์เฟซ [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape) มักจะมีข้อความ

ดังนั้นเมื่อทำงานกับรูปร่างที่มีอยู่แล้วซึ่งคุณต้องการใส่ข้อความ คุณอาจต้องตรวจสอบและยืนยันว่ามันถูกแคสต์ผ่านอินเทอร์เฟซ `IAutoShape` เท่านั้นจึงจะสามารถทำงานกับ [TextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/properties/textframe) ซึ่งเป็นคุณสมบัติของ `IAutoShape` ได้ ดูส่วน [Update Text](https://docs.aspose.com/slides/th/net/manage-textbox/#update-text) ในหน้านี้

{{% /alert %}}

## **สร้างกล่องข้อความบนสไลด์**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
2. ดึงอ้างอิงของสไลด์แรกผ่านดัชนีของมัน  
3. เพิ่มอ็อบเจ็กต์ [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape) ที่มี [ShapeType](https://reference.aspose.com/slides/th/net/aspose.slides/igeometryshape/properties/shapetype) ตั้งค่าเป็น `Rectangle` ในตำแหน่งที่ระบุบนสไลด์และรับอ้างอิงของอ็อบเจ็กต์ `IAutoShape` ที่เพิ่มใหม่  
4. เพิ่มคุณสมบัติ `TextFrame` ให้กับอ็อบเจ็กต์ `IAutoShape` ที่จะบรรจุข้อความ ในตัวอย่างด้านล่าง เราได้เพิ่มข้อความนี้: *Aspose TextBox*  
5. สุดท้าย เขียนไฟล์ PPTX ผ่านอ็อบเจ็กต์ `Presentation`  

โค้ด C# นี้—การนำขั้นตอนข้างต้นไปใช้งาน—แสดงวิธีการเพิ่มข้อความไปยังสไลด์:

```c#
    // สร้างอินสแตนซ์ PresentationEx
    using (Presentation pres = new Presentation())
    {

        // ดึงสไลด์แรกในงานนำเสนอ
        ISlide sld = pres.Slides[0];

        // เพิ่ม AutoShape โดยตั้งค่าประเภทเป็น Rectangle
        IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

        // เพิ่ม TextFrame ไปยัง Rectangle
        ashp.AddTextFrame(" ");

        // เข้าถึง text frame
        ITextFrame txtFrame = ashp.TextFrame;

        // สร้างอ็อบเจ็กต์ Paragraph สำหรับ text frame
        IParagraph para = txtFrame.Paragraphs[0];

        // สร้างอ็อบเจ็กต์ Portion สำหรับ paragraph
        IPortion portion = para.Portions[0];

        // ตั้งค่าข้อความ
        portion.Text = "Aspose TextBox";

        // บันทึกงานนำเสนอไปยังดิสก์
        pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
```

## **ตรวจสอบรูปทรงกล่องข้อความ**

Aspose.Slides มีคุณสมบัติ [IsTextBox](https://reference.aspose.com/slides/th/net/aspose.slides/autoshape/istextbox/) จากอินเทอร์เฟซ [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ให้คุณตรวจสอบรูปร่างและระบุว่ามันเป็นกล่องข้อความหรือไม่

![Text box and shape](istextbox.png)

โค้ด C# นี้แสดงวิธีการตรวจสอบว่ารูปร่างถูกสร้างเป็นกล่องข้อความหรือไม่:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    Aspose.Slides.LowCode.ForEach.Shape(presentation, (shape, slide, index) =>
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "shape is a text box" : "shape is not a text box");
        }
    });
}
```

โปรดทราบว่าหากคุณเพียงเพิ่มออโต้เชปโดยใช้เมธอด `AddAutoShape` จากอินเทอร์เฟซ [IShapeCollection](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/) คุณสมบัติ `IsTextBox` ของออโต้เชปจะคืนค่า `false` อย่างไรก็ตาม หลังจากที่คุณเพิ่มข้อความลงในออโต้เชปโดยใช้เมธอด `AddTextFrame` หรือคุณสมบัติ `Text` คุณสมบัติ `IsTextBox` จะคืนค่า `true`

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    // shape1.IsTextBox เป็น false
    shape1.AddTextFrame("shape 1");
    // shape1.IsTextBox เป็น true

    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
    // shape2.IsTextBox เป็น false
    shape2.TextFrame.Text = "shape 2";
    // shape2.IsTextBox เป็น true

    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
    // shape3.IsTextBox เป็น false
    shape3.AddTextFrame("");
    // shape3.IsTextBox เป็น false

    IAutoShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
    // shape4.IsTextBox เป็น false
    shape4.TextFrame.Text = "";
    // shape4.IsTextBox เป็น false
}
```

## **เพิ่มคอลัมน์ให้กับกล่องข้อความ**

Aspose.Slides มีคุณสมบัติ [ColumnCount](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat/properties/columncount) และ [ColumnSpacing](https://reference.aspose.com/slides/th/net/aspose.slides/textframeformat/properties/columnspacing) (จากอินเทอร์เฟซ [ITextFrameFormat](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat) และคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/net/aspose.slides/textframeformat)) เพื่อให้คุณสามารถเพิ่มคอลัมน์ให้กับกล่องข้อความได้ คุณสามารถระบุจำนวนคอลัมน์ในกล่องข้อความและกำหนดระยะห่างเป็นจุดระหว่างคอลัมน์

โค้ดนี้ใน C# แสดงการดำเนินการที่อธิบายไว้:

```c#
using (Presentation presentation = new Presentation())
{
	// ดึงสไลด์แรกในงานนำเสนอ
	ISlide slide = presentation.Slides[0];

	// เพิ่ม AutoShape โดยตั้งค่าประเภทเป็น Rectangle
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// เพิ่ม TextFrame ไปยัง Rectangle
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// ดึงรูปแบบข้อความของ TextFrame
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// ระบุจำนวนคอลัมน์ใน TextFrame
	format.ColumnCount = 3;

	// ระบุระยะห่างระหว่างคอลัมน์
	format.ColumnSpacing = 10;

	// บันทึกงานนำเสนอ
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```

## **เพิ่มคอลัมน์ให้กับ Text Frame**

Aspose.Slides for .NET มีคุณสมบัติ [ColumnCount](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat/properties/columncount) (จากอินเทอร์เฟซ [ITextFrameFormat](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat)) ที่ช่วยให้คุณเพิ่มคอลัมน์ใน Text Frame ได้ ผ่านคุณสมบัตินี้คุณสามารถระบุจำนวนคอลัมน์ที่ต้องการใน Text Frame

โค้ด C# นี้แสดงวิธีการเพิ่มคอลัมน์ภายใน Text Frame:

```c#
string outPptxFileName = "ColumnsTest.pptx";
using (Presentation pres = new Presentation())
{
    IAutoShape shape1 = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.TextFrame.TextFrameFormat;

    format.ColumnCount = 2;
    shape1.TextFrame.Text = "All these columns are forced to stay within a single text container -- " +
                                "you can add or delete text - and the new or remaining text automatically adjusts " +
                                "itself to stay within the container. You cannot have text spill over from one container " +
                                "to other, though -- because PowerPoint's column options for text are limited!";
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(double.NaN == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }

    format.ColumnSpacing = 20;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(20 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }

    format.ColumnCount = 3;
    format.ColumnSpacing = 15;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(3 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(15 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }
}
```

## **อัปเดตข้อความ**

Aspose.Slides ให้คุณเปลี่ยนแปลงหรืออัปเดตข้อความที่อยู่ในกล่องข้อความหรือข้อความทั้งหมดที่อยู่ในงานนำเสนอ

โค้ด C# นี้แสดงการดำเนินการที่อัปเดตหรือเปลี่ยนแปลงข้อความทั้งหมดในงานนำเสนอ:

```c#
using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //ตรวจสอบว่ารูปร่างรองรับ text frame (IAutoShape) หรือไม่.
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //วนรอบผ่านย่อหน้าต่างใน text frame
               {
                   foreach (IPortion portion in paragraph.Portions) //วนรอบผ่านแต่ละ portion ในย่อหน้า
                   {
                       portion.Text = portion.Text.Replace("years", "months"); //เปลี่ยนข้อความ
                       portion.PortionFormat.FontBold = NullableBool.True; //เปลี่ยนการจัดรูปแบบ
                   }
               }
           }
       }
   }
  
   //บันทึกงานนำเสนอที่แก้ไขแล้ว
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```

## **เพิ่มกล่องข้อความพร้อมลิงก์**

คุณสามารถแทรกลิงก์ภายในกล่องข้อความได้ เมื่อคลิกที่กล่องข้อความ ผู้ใช้จะถูกนำไปเปิดลิงก์นั้น

1. สร้างอินสแตนซ์ของคลาส `Presentation`  
2. ดึงอ้างอิงของสไลด์แรกผ่านดัชนีของมัน  
3. เพิ่มอ็อบเจ็กต์ `AutoShape` ที่มี `ShapeType` ตั้งค่าเป็น `Rectangle` ในตำแหน่งที่ระบุบนสไลด์และรับอ้างอิงของอ็อบเจ็กต์ AutoShape ที่เพิ่มใหม่  
4. เพิ่ม `TextFrame` ให้กับอ็อบเจ็กต์ `AutoShape` ที่มีข้อความเริ่มต้นเป็น *Aspose TextBox*  
5. สร้างอินสแตนซ์ของคลาส `IHyperlinkManager`  
6. กำหนดอ็อบเจ็กต์ `IHyperlinkManager` ให้กับคุณสมบัติ [HyperlinkClick](https://reference.aspose.com/slides/th/net/aspose.slides/shape/properties/hyperlinkclick) ที่เชื่อมกับส่วนที่คุณต้องการของ `TextFrame`  
7. สุดท้าย เขียนไฟล์ PPTX ผ่านอ็อบเจ็กต์ `Presentation`  

โค้ด C# นี้—การนำขั้นตอนข้างต้นไปใช้งาน—แสดงวิธีการเพิ่มกล่องข้อความพร้อมลิงก์ไปยังสไลด์:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PPTX
Presentation pptxPresentation = new Presentation();

// ดึงสไลด์แรกในงานนำเสนอ
ISlide slide = pptxPresentation.Slides[0];

// เพิ่มอ็อบเจ็กต์ AutoShape โดยตั้งค่าประเภทเป็น Rectangle
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// แคสต์รูปร่างเป็น AutoShape
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// เข้าถึงคุณสมบัติ ITextFrame ที่เชื่อมกับ AutoShape
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// เพิ่มข้อความบางส่วนลงในเฟรม
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// ตั้งค่า Hyperlink ให้กับข้อความ portion
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// บันทึกงานนำเสนอ PPTX
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างกล่องข้อความและตัวรอข้อความเมื่อทำงานกับมาสเตอร์สไลด์คืออะไร?**

[placeholder](/slides/th/net/manage-placeholder/) สืบทอดสไตล์/ตำแหน่งจาก [master](https://reference.aspose.com/slides/th/net/aspose.slides/masterslide/) และสามารถถูกเขียนทับได้บน [layouts](https://reference.aspose.com/slides/th/net/aspose.slides/layoutslide/) ในขณะที่กล่องข้อความทั่วไปเป็นอ็อบเจ็กต์อิสระบนสไลด์เฉพาะและจะไม่เปลี่ยนแปลงเมื่อคุณสลับเลย์เอาต์

**ฉันจะทำการแทนที่ข้อความจำนวนมากในงานนำเสนอโดยไม่กระทบข้อความภายในแผนภูมิ ตาราง และ SmartArt อย่างไร?**

จำกัดการวนซ้ำของคุณให้กับออโต้เชปที่มี Text Frame เท่านั้นและยกเว้นอ็อบเจ็กต์ที่ฝังอยู่ ([charts](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/th/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/th/net/aspose.slides.smartart/smartart/)) โดยทำการเดินทางผ่านคอลเลกชันของพวกมันแยกกันหรือข้ามประเภทอ็อบเจ็กต์ดังกล่าว