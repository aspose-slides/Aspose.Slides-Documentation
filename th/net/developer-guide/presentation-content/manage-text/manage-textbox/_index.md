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
- เพิ่มไฮเปอร์ลิงก์
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ทำให้การสร้าง แก้ไข และคัดลอกกล่องข้อความในไฟล์ PowerPoint และ OpenDocument เป็นเรื่องง่าย ช่วยเพิ่มประสิทธิภาพการทำงานอัตโนมัติของงานนำเสนอของคุณ"
---
## **บทนำ**

ข้อความบนสไลด์โดยทั่วไปจะอยู่ในกล่องข้อความหรือรูปร่าง ดังนั้นเพื่อเพิ่มข้อความลงในสไลด์ คุณต้องเพิ่มกล่องข้อความก่อนแล้วจึงใส่ข้อความบางส่วนลงในกล่องข้อความ  

เพื่อให้คุณเพิ่มรูปร่างที่สามารถเก็บข้อความได้ Aspose.Slides for .NET มีอินเทอร์เฟซ [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape)  

{{% alert title="Note" color="warning" %}} 

Aspose.Slides ยังมีอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishape) เพื่อให้คุณเพิ่มรูปร่างลงในสไลด์ได้ อย่างไรก็ตาม ไม่ใช่รูปร่างทั้งหมดที่เพิ่มผ่านอินเทอร์เฟซ `IShape` จะเก็บข้อความได้ รูปร่างที่เพิ่มผ่านอินเทอร์เฟซ [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape) มักจะมีข้อความอยู่  

{{% /alert %}}

ดังนั้น เมื่อทำงานกับรูปร่างที่มีอยู่ที่คุณต้องการเพิ่มข้อความ คุณอาจต้องตรวจสอบและยืนยันว่ามันถูกแปลงผ่านอินเทอร์เฟซ `IAutoShape` เท่านั้นจึงจะสามารถทำงานกับ [TextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/properties/textframe) ซึ่งเป็นคุณสมบัติของ `IAutoShape` ดูส่วน [Update Text](https://docs.aspose.com/slides/th/net/manage-textbox/#update-text) ในหน้านี้  

## **สร้างกล่องข้อความบนสไลด์**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
2. รับการอ้างอิงสไลด์แรกผ่านดัชนีของมัน  
3. เพิ่มอ็อบเจกต์ [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape) ที่มี [ShapeType](https://reference.aspose.com/slides/th/net/aspose.slides/igeometryshape/properties/shapetype) ตั้งค่าเป็น `Rectangle` ที่ตำแหน่งที่ระบุบนสไลด์และรับการอ้างอิงของอ็อบเจกต์ `IAutoShape` ที่เพิ่งเพิ่มใหม่  
4. เพิ่มคุณสมบัติ `TextFrame` ให้กับอ็อบเจกต์ `IAutoShape` เพื่อเก็บข้อความ ในตัวอย่างด้านล่าง เราได้เพิ่มข้อความนี้: *Aspose TextBox*  
5. สุดท้าย เขียนไฟล์ PPTX ผ่านอ็อบเจกต์ `Presentation`  

โค้ด C# นี้—การดำเนินการตามขั้นตอนข้างต้น—แสดงวิธีการเพิ่มข้อความลงในสไลด์:

```c#
using Aspose.Slides;

// สร้างอินสแตนซ์ของ PresentationEx
using (Presentation pres = new Presentation())
{

    // ดึงสไลด์แรกในงานนำเสนอ
    ISlide sld = pres.Slides[0];

    // เพิ่ม AutoShape ที่กำหนดประเภทเป็น Rectangle
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // เพิ่ม TextFrame ไปยัง Rectangle
    ashp.AddTextFrame(" ");

    // เข้าถึง TextFrame
    ITextFrame txtFrame = ashp.TextFrame;

    // สร้างอ็อบเจกต์ Paragraph สำหรับ TextFrame
    IParagraph para = txtFrame.Paragraphs[0];

    // สร้างอ็อบเจกต์ Portion สำหรับ Paragraph
    IPortion portion = para.Portions[0];

    // ตั้งค่าข้อความ
    portion.Text = "Aspose TextBox";

    // บันทึกงานนำเสนอลงดิสก์
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **ตรวจสอบว่าเป็นรูปร่างกล่องข้อความหรือไม่**

Aspose.Slides มีคุณสมบัติ [IsTextBox](https://reference.aspose.com/slides/th/net/aspose.slides/autoshape/istextbox/) จากอินเทอร์เฟซ [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ให้คุณตรวจสอบรูปร่างและระบุว่ามันเป็นกล่องข้อความหรือไม่  

![กล่องข้อความและรูปร่าง](istextbox.png)

โค้ด C# นี้แสดงวิธีการตรวจสอบว่ารูปร่างถูกสร้างเป็นกล่องข้อความหรือไม่:

```c#
using Aspose.Slides;

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

โปรดทราบว่า หากคุณเพียงเพิ่มออโต้เชปโดยใช้เมธอด `AddAutoShape` จากอินเทอร์เฟซ [IShapeCollection](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/) คุณสมบัติ `IsTextBox` ของออโต้เชปจะคืนค่า `false` อย่างไรก็ตาม หลังจากที่คุณเพิ่มข้อความให้กับออโต้เชปโดยใช้เมธอด `AddTextFrame` หรือคุณสมบัติ `Text` คุณสมบัติ `IsTextBox` จะคืนค่า `true`

```cs
using Aspose.Slides;

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

## **ค้นหารูปร่างที่เป็นเจ้าของ Text Frame**

ในโค้ดการประมวลผลข้อความทั่วไป คุณอาจได้รับอ็อบเจกต์ [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) โดยยังไม่รู้ว่า presentation ใดเป็นเจ้าของ ใช้คุณสมบัติ [ITextFrame.ParentShape](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/parentshape/) เพื่อกลับไปยัง [IShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/) ที่เป็นเจ้าของ  

สำหรับ Text Frame ที่เป็นของ [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) หรือรูปร่างอื่นที่บรรจุปข้อความ คุณสมบัติ [ITextFrame.ParentShape](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/parentshape/) จะถูกตั้งค่าและ [ITextFrame.ParentCell](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/parentcell/) จะเป็น `null` ทั้งสองคุณสมบัตินี้เป็นคุณสมบัติแบบอ่านอย่างเดียว ดังนั้นการอ่านจะไม่เปลี่ยนแปลงความเป็นเจ้าของ ตรวจสอบค่า `null` ก่อนเข้าถึงรูปร่างเสมอ  

สำหรับตัวอย่างสมบูรณ์ที่ระบุเจ้าของรูปร่างและเซลล์ตาราง รวมถึงรูปร่างที่เชื่อมโยงกับโนด SmartArt ดู [Search and Replace Text](/slides/th/net/search-and-replace-text/)

## **เพิ่มคอลัมน์ลงในกล่องข้อความ**

Aspose.Slides มีคุณสมบัติ [ColumnCount](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat/properties/columncount) และ [ColumnSpacing](https://reference.aspose.com/slides/th/net/aspose.slides/textframeformat/properties/columnspacing) (จากอินเทอร์เฟซ [ITextFrameFormat](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat) และคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/net/aspose.slides/textframeformat)) เพื่อให้คุณเพิ่มคอลัมน์ลงในกล่องข้อความ คุณสามารถระบุจำนวนคอลัมน์ในกล่องข้อความและกำหนดระยะห่างเป็นพอยต์ระหว่างคอลัมน์  

โค้ด C# นี้แสดงการดำเนินการที่อธิบายไว้:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
	// รับสไลด์แรกในงานนำเสนอ
	ISlide slide = presentation.Slides[0];

	// เพิ่ม AutoShape ที่กำหนดประเภทเป็น Rectangle
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// เพิ่ม TextFrame ไปยัง Rectangle
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// รับรูปแบบข้อความของ TextFrame
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// ระบุจำนวนคอลัมน์ใน TextFrame
	format.ColumnCount = 3;

	// ระบุระยะห่างระหว่างคอลัมน์
	format.ColumnSpacing = 10;

	// บันทึกงานนำเสนอ
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```

## **เพิ่มคอลัมน์ลงใน Text Frame**

Aspose.Slides for .NET มีคุณสมบัติ [ColumnCount](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat/properties/columncount) (จากอินเทอร์เฟซ [ITextFrameFormat](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat)) ที่ให้คุณเพิ่มคอลัมน์ใน Text Frame ผ่านคุณสมบัตินี้ คุณสามารถกำหนดจำนวนคอลัมน์ที่ต้องการใน Text Frame  

โค้ด C# นี้แสดงวิธีการเพิ่มคอลัมน์ภายใน Text Frame:

```c#
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;

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
        Debug.Assert(double.IsNaN(((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing));
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

Aspose.Slides ให้คุณเปลี่ยนหรืออัปเดตข้อความที่อยู่ในกล่องข้อความหรือข้อความทั้งหมดใน presentation  

โค้ด C# นี้แสดงการดำเนินการที่อัปเดตหรือเปลี่ยนข้อความทั้งหมดใน presentation:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //ตรวจสอบว่ารูปร่างรองรับกรอบข้อความ (IAutoShape) หรือไม่.
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //วนผ่านย่อหน้าในกรอบข้อความ
               {
                   foreach (IPortion portion in paragraph.Portions) //วนผ่านแต่ละส่วนในย่อหน้า
                   {
                       portion.Text = portion.Text.Replace("years", "months"); //เปลี่ยนข้อความ
                       portion.PortionFormat.FontBold = NullableBool.True; //เปลี่ยนรูปแบบ
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

คุณสามารถแทรกลิงก์ภายในกล่องข้อความ เมื่อคลิกกล่องข้อความ ผู้ใช้จะถูกนำไปเปิดลิงก์  

1. สร้างอินสแตนซ์ของคลาส `Presentation`  
2. รับการอ้างอิงสไลด์แรกผ่านดัชนีของมัน  
3. เพิ่มอ็อบเจกต์ `AutoShape` ที่มี `ShapeType` ตั้งค่าเป็น `Rectangle` ที่ตำแหน่งที่ระบุบนสไลด์และรับการอ้างอิงของอ็อบเจกต์ AutoShape ที่เพิ่งเพิ่มใหม่  
4. เพิ่ม `TextFrame` ให้กับอ็อบเจกต์ `AutoShape` ที่มีข้อความเริ่มต้นเป็น *Aspose TextBox*  
5. สร้างอินสแตนซ์ของคลาส `IHyperlinkManager`  
6. กำหนดอ็อบเจกต์ `IHyperlinkManager` ให้กับคุณสมบัติ [HyperlinkClick](https://reference.aspose.com/slides/th/net/aspose.slides/shape/properties/hyperlinkclick) ที่เชื่อมโยงกับส่วนที่คุณต้องการของ `TextFrame`  
7. สุดท้าย เขียนไฟล์ PPTX ผ่านอ็อบเจกต์ `Presentation`  

โค้ด C# นี้—การดำเนินการตามขั้นตอนข้างต้น—แสดงวิธีการเพิ่มกล่องข้อความพร้อมลิงก์ไปยังสไลด์:

```c#
using Aspose.Slides;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pptxPresentation = new Presentation();

// ดึงสไลด์แรกในงานนำเสนอ
ISlide slide = pptxPresentation.Slides[0];

// เพิ่มอ็อบเจกต์ AutoShape โดยกำหนดประเภทเป็น Rectangle
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// แปลงรูปร่างเป็น AutoShape
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// เข้าถึงคุณสมบัติ ITextFrame ที่เชื่อมโยงกับ AutoShape
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// เพิ่มข้อความบางส่วนลงในกรอบ
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// ตั้งค่า Hyperlink สำหรับข้อความส่วน
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// บันทึกงานนำเสนอ PPTX
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **FAQ**

**ความแตกต่างระหว่างกล่องข้อความและ placeholder ของข้อความเมื่อทำงานกับมาสเตอร์สไลด์คืออะไร?**

[placeholder](/slides/th/net/manage-placeholder/) จะสืบทอดสไตล์/ตำแหน่งจาก [master](https://reference.aspose.com/slides/th/net/aspose.slides/masterslide/) และสามารถถูกเขียนทับบน [layouts](https://reference.aspose.com/slides/th/net/aspose.slides/layoutslide/) ในขณะที่กล่องข้อความปกติเป็นอ็อบเจกต์อิสระบนสไลด์เฉพาะและไม่ได้เปลี่ยนแปลงเมื่อคุณสลับเลย์เอาต์  

**ฉันจะทำการแทนที่ข้อความจำนวนมากทั่วทั้ง presentation ได้อย่างไรโดยไม่กระทบข้อความในแผนภูมิ ตาราง หรือ SmartArt?**

จำกัดการวนลูปของคุณให้กับออโต้เชปที่มี Text Frame เท่านั้นและละเว้นอ็อบเจกต์ที่ฝังอยู่ ([charts](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/th/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/th/net/aspose.slides.smartart/smartart/)) โดยแยกการเดินทางในคอลเลกชันของพวกมันหรือข้ามประเภทอ็อบเจกต์เหล่านั้น