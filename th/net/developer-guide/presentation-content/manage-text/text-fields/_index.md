---
title: จัดการฟิลด์ข้อความในงานนำเสนอ PowerPoint ด้วย .NET
linktitle: ฟิลด์ข้อความ
type: docs
weight: 52
url: /th/net/text-fields/
keywords:
- ฟิลด์ข้อความ
- ข้อความอัตโนมัติ
- หมายเลขสไลด์
- วันที่และเวลา
- ส่วนหัว
- ส่วนล่าง
- ส่วนข้อความ
- PowerPoint
- PPT
- PPTX
- C#
- Aspose.Slides
description: "สร้าง ตรวจสอบ แก้ไข และลบฟิลด์ข้อความในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ .NET. รักษาการจัดรูปแบบและตรวจสอบไฟล์ PPTX และ PPT ที่บันทึกไว้."
---
## **ภาพรวม**

ย่อหน้าข้อความประกอบด้วยส่วนต่าง ๆ ส่วนปกติ [IPortion](https://reference.aspose.com/slides/th/net/aspose.slides/iportion/) มีข้อความตัวอักษรจริง; ส่วนฟิลด์ยังมี [IField](https://reference.aspose.com/slides/th/net/aspose.slides/ifield/) ที่ประเภทของมันระบุมูลค่าที่อัปเดตโดยอัตโนมัติ เช่นหมายเลขสไลด์หรือวันที่ ส่วนสองส่วนอาจแสดงอักขระเดียวกันในขณะที่มีเพียงส่วนเดียวที่มีฟิลด์

ใช้ [IPortion.Field](https://reference.aspose.com/slides/th/net/aspose.slides/iportion/field/) เพื่อแยกแยะ: ค่าจะเป็น `null` สำหรับข้อความปกติ [IPortion.AddField](https://reference.aspose.com/slides/th/net/aspose.slides/iportion/addfield/) แปลงส่วนที่มีอยู่เป็นฟิลด์ เก็บป้ายชื่อและค่าที่เปลี่ยนแปลงได้ไว้ในส่วนแยกกันเพื่อไม่ให้การแปลงค่าทำให้ป้ายชื่อถูกแทนที่ด้วย

คู่มือนี้ครอบคลุมฟิลด์ภายในข้อความ การจัดรูปแบบของฟิลด์ และการบันทึกเป็น PPTX และ PPT สำหรับกรอบข้อความและย่อหน้า ดูที่ [Manage Text](/slides/th/net/manage-text/)

## **สร้างฟิลด์หมายเลขสไลด์**

ตัวอย่างเต็มต่อไปนี้สร้างกล่องข้อความที่มีป้าย `Slide ` ตัวอักษรจริงตามด้วยหมายเลขที่อัปเดตโดยอัตโนมัติ ตั้งขนาด น้ำหนัก และสีของหมายเลขก่อนเพิ่มฟิลด์ แล้วเปิดไฟล์พรีเซนเทชันที่บันทึกไว้ใหม่และตรวจสอบประเภทฟิลด์ ข้อความ และการจัดรูปแบบ ไม่ต้องใช้ไฟล์อินพุต

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
shape.AddTextFrame("Slide ");
var paragraph = shape.TextFrame.Paragraphs[0];

var numberPortion = new Portion();
numberPortion.PortionFormat.FontHeight = 24;
numberPortion.PortionFormat.FontBold = NullableBool.True;
numberPortion.PortionFormat.FillFormat.FillType = FillType.Solid;
numberPortion.PortionFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
paragraph.Portions.Add(numberPortion);
numberPortion.AddField(FieldType.SlideNumber);

presentation.Save("slide_number.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("slide_number.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedNumber = savedShape.TextFrame.Paragraphs[0].Portions[1];
var hasNumberField = savedNumber.Field?.Type.InternalString == FieldType.SlideNumber.InternalString;
var format = savedNumber.PortionFormat;
var formattingPreserved = format.FontHeight == 24 && format.FontBold == NullableBool.True;
formattingPreserved &= format.FillFormat.SolidFillColor.Color.ToArgb() == Color.DarkBlue.ToArgb();

Console.WriteLine($"Text: {savedShape.TextFrame.Text}");
Console.WriteLine($"Slide number field: {hasNumberField}");
Console.WriteLine($"Formatting preserved: {formattingPreserved}");
```

พรีเซนเทชันใหม่เริ่มด้วยหมายเลขสไลด์ 1 ดังนั้นข้อความจะเป็น `Slide 1` และการตรวจสอบทั้งสองจะแสดง `True` หมายเลขยังคงเป็นฟิลด์หลังจากเปิดใหม่; ไม่ใช่ข้อความ `1` ตัวแปลงและดัชนีในการตรวจสอบอ้างอิงถึงรูปร่างและส่วนที่สร้างโดยตัวอย่างนี้

## **เลือกประเภทฟิลด์**

[FieldType](https://reference.aspose.com/slides/th/net/aspose.slides/fieldtype/) implements [IFieldType](https://reference.aspose.com/slides/th/net/aspose.slides/ifieldtype/) and provides the following predefined values. Pass the appropriate value to [AddField](https://reference.aspose.com/slides/th/net/aspose.slides/iportion/addfield/).

| ค่า | วัตถุประสงค์ |
|---|---|
| [SlideNumber](https://reference.aspose.com/slides/th/net/aspose.slides/fieldtype/slidenumber/) | หมายเลขสไลด์ปัจจุบัน |
| [DateTime](https://reference.aspose.com/slides/th/net/aspose.slides/fieldtype/datetime/) | วันที่/เวลาในรูปแบบเริ่มต้นของแอปพลิเคชันที่แสดงผล |
| [DateTime1](https://reference.aspose.com/slides/th/net/aspose.slides/fieldtype/datetime1/)–[DateTime9](https://reference.aspose.com/slides/th/net/aspose.slides/fieldtype/datetime9/) | รูปแบบวันที่ที่กำหนดไว้ล่วงหน้าหรือรูปแบบวันที่/เวลาที่รวมกัน |
| [DateTime10](https://reference.aspose.com/slides/th/net/aspose.slides/fieldtype/datetime10/)–[DateTime13](https://reference.aspose.com/slides/th/net/aspose.slides/fieldtype/datetime13/) | รูปแบบเวลาที่กำหนดไว้ล่วงหน้า พร้อมตัวเลือกสำหรับวินาทีและนาฬิกา 12 ชั่วโมง |
| [Header](https://reference.aspose.com/slides/th/net/aspose.slides/fieldtype/header/) | ฟิลด์ส่วนหัว; ดูข้อจำกัดของตัวยึดตำแหน่งและรูปแบบด้านล่าง |
| [Footer](https://reference.aspose.com/slides/th/net/aspose.slides/fieldtype/footer/) | ฟิลด์ส่วนล่าง |

For example, [DateTime3](https://reference.aspose.com/slides/th/net/aspose.slides/fieldtype/datetime3/) represents a day, full month name, and year in English. These are predefined field formats, not arbitrary .NET date-format strings. The portion's [LanguageId](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseportionformat/languageid/) and the application processing the presentation can affect the displayed result.

## **สร้างฟิลด์จากสตริงภายใน**

The string overload of [AddField](https://reference.aspose.com/slides/th/net/aspose.slides/iportion/addfield/) accepts an internal field identifier. Use it when preserving an identifier supplied by another application that has no predefined value. You can also construct a [FieldType](https://reference.aspose.com/slides/th/net/aspose.slides/fieldtype/fieldtype/) from the identifier. [IFieldType.InternalString](https://reference.aspose.com/slides/th/net/aspose.slides/ifieldtype/internalstring/) exposes that identifier for inspection.

ตัวอย่างนี้เก็บฟิลด์ `custom-report-id` เฉพาะแอปพลิเคชันพร้อมข้อความสำรอง `Report-042` ตัวระบุไม่ทำการคำนวณ: Aspose.Slides ไม่สร้าง ID รายงานสำหรับประเภทที่ไม่รู้จัก แอปที่เข้าใจตัวระบุต้องให้ความหมายและอัปเดตค่า

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
shape.AddTextFrame("Report-042");
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.AddField("custom-report-id");

presentation.Save("custom_field.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom_field.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedPortion = savedShape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine($"Type: {savedPortion.Field?.Type.InternalString}");
Console.WriteLine($"Text: {savedPortion.Text}");
```

หลังจากรอบการเดินทาง PPTX นี้ ประเภทจะเป็น `custom-report-id` และข้อความเป็น `Report-042` การส่งสตริงเช่น `yyyy-MM-dd` จะตั้งชื่อประเภทฟิลด์; จะไม่กำหนดรูปแบบวันที่แบบกำหนดเอง สำหรับวันที่คงที่ในรูปแบบใด ๆ ให้ใช้ข้อความทั่วไป

## **ตรวจสอบ แก้ไข และลบฟิลด์วันที่/เวลา**

Read and change an existing field through [IField.Type](https://reference.aspose.com/slides/th/net/aspose.slides/ifield/type/). Check that the field exists before accessing its type. To stop automatic updates, call [IPortion.RemoveField](https://reference.aspose.com/slides/th/net/aspose.slides/iportion/removefield/). This keeps the portion and its current text while removing the field association. If you need a specific fixed value, assign that text after removing the field.

For the API setting associated with date/time field processing, see [Presentation.CurrentDateTime](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/currentdatetime/). The example below uses an explicit approval date when converting a field to ordinary text.

Download [sample.pptx](sample.pptx) and place it in the working directory. It contains two named text shapes, `UpdatedAt` and `ApprovedDate`, each with a date/time field, plus ordinary text labels. The following example walks top-level text shapes on regular slides. It changes date/time fields to a long-date format and makes them italic, while preserving their other formatting. Only fields in `ApprovedDate` become fixed text.

The sample recognizes the built-in internal identifiers `datetime` and `datetime1` through `datetime13`. Groups, tables, notes, layouts, and masters require traversal of their own text containers and are outside this example's scope.

```cs
using System;
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var approvalDate = new DateTime(2030, 4, 5);
var culture = CultureInfo.GetCultureInfo("en-US");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape textShape || textShape.TextFrame == null)
            continue;

        foreach (var paragraph in textShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                var field = portion.Field;
                if (field == null)
                    continue;

                var typeName = field.Type.InternalString;
                var isDateTime = typeName == "datetime";
                if (typeName.StartsWith("datetime", StringComparison.Ordinal))
                {
                    var hasFormatNumber = int.TryParse(typeName.Substring(8), out var formatNumber);
                    isDateTime |= hasFormatNumber && formatNumber >= 1 && formatNumber <= 13;
                }
                if (!isDateTime)
                    continue;

                field.Type = FieldType.DateTime3;
                portion.PortionFormat.LanguageId = "en-US";
                portion.PortionFormat.FontItalic = NullableBool.True;

                if (textShape.Name == "ApprovedDate")
                {
                    portion.RemoveField();
                    portion.Text = approvalDate.ToString("dd MMMM yyyy", culture);
                }
            }
        }
    }
}

presentation.Save("updated_dates.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("updated_dates.pptx");
foreach (var shape in reopened.Slides[0].Shapes)
{
    if (shape is not IAutoShape textShape || textShape.TextFrame == null)
        continue;
    if (textShape.Name != "UpdatedAt" && textShape.Name != "ApprovedDate")
        continue;

    var portion = textShape.TextFrame.Paragraphs[0].Portions[0];
    var typeName = portion.Field?.Type.InternalString ?? "ordinary text";
    Console.WriteLine($"{textShape.Name}: {typeName}; {portion.Text}");
    Console.WriteLine($"Italic: {portion.PortionFormat.FontItalic}");
}
```

After reopening, `UpdatedAt` has type `datetime3` and remains dynamic. `ApprovedDate` has no field and contains `05 April 2030`. Both date portions are italic, and their original font size, bold setting, and color remain intact. The ordinary text labels are unchanged. The verification reads the first portion of the two known shapes in the supplied sample.

## **รักษาการจัดรูปแบบข้อความ**

Work with the existing portion when adding a field, changing its type, or removing it. These operations retain that portion's formatting. Use [IPortion.PortionFormat](https://reference.aspose.com/slides/th/net/aspose.slides/iportion/portionformat/) to change only the required properties, as the examples do for color or italics.

Avoid rebuilding an entire text frame just to update one field: doing so can lose the original portion boundaries and their individual formatting. Also distinguish explicitly set formatting from formatting inherited from the paragraph, layout, or theme. See [Text Formatting](/slides/th/net/text-formatting/) for broader formatting options.

## **ฟิลด์และตัวยึดตำแหน่งส่วนหัว/ส่วนล่าง**

A field is part of a text portion. A placeholder is a shape with a presentation role, such as a footer or slide number. Adding a field to an ordinary text box does not turn that shape into a placeholder.

The header/footer managers control placeholder text and visibility on slides, layouts, and masters, including propagation to dependent slides. A number field in a custom text box can therefore be useful even when you are not using the slide-number placeholder. Conversely, changing placeholder visibility does not remove a field from an unrelated text box.

The predefined header and footer types do not create the corresponding placeholders or supply their content. In particular, a regular PowerPoint slide has no header placeholder; headers belong to notes pages and handouts. Do not assume that a header or footer field in an arbitrary shape will automatically obtain the text configured through a placeholder manager. For that workflow, see [Presentation Headers and Footers](/slides/th/net/presentation-header-and-footer/).

## **ข้อจำกัดของ PPTX และ PPT**

Check both the field type and its resulting text after saving and reopening. Preserving an identifier does not prove that an application can calculate or display its value.

| รูปแบบ | พฤติกรรมของฟิลด์และข้อจำกัด |
|---|---|
| PPTX | Stores internal field identifiers alongside field text. In round-trip checks, the predefined types and the custom identifier used above survived saving and reopening. The unknown custom type retained its fallback text; it did not acquire automatic calculation logic. Another application may treat unsupported identifiers differently. |
| PPT | Uses legacy field representations and has more limited compatibility. In round-trip checks, slide-number and predefined date/time fields survived saving and reopening. A custom field in an ordinary slide text box reopened with its identifier but with `*` as its text; a header field in the same context also produced `*`. Do not rely on custom fields or unsupported field contexts retaining their visible text. |

For portable, fixed output, convert unsupported fields to ordinary text and explicitly assign the value you want before saving. This preserves the chosen text but intentionally stops automatic updates. Test the target application as well when its own field recalculation is part of your workflow.

## **คำถามที่พบบ่อย**

**ฉันจะรู้ได้อย่างไรว่าตัวเลขหรือวันที่ที่แสดงเป็นฟิลด์หรือไม่?**  
Inspect [IPortion.Field](https://reference.aspose.com/slides/th/net/aspose.slides/iportion/field/). A non-null value identifies a field; the displayed text alone cannot tell you.

**การลบฟิลด์จะลบข้อความหรือการจัดรูปแบบของมันด้วยหรือไม่?**  
No. [RemoveField](https://reference.aspose.com/slides/th/net/aspose.slides/iportion/removefield/) converts the existing portion to ordinary text. Assign an explicit value afterward if you need a particular frozen date or fallback value.

**สตริงภายในสามารถกำหนดรูปแบบวันที่ใหม่หรือสูตรใหม่ได้หรือไม่?**  
No. It identifies a field type. An unknown identifier does not provide an evaluator or a .NET date-format pattern. Use a supported predefined type or format a value yourself as ordinary text.

**ทำไมต้องตรวจสอบพรีเซนเทชันอีกครั้งหลังจากบันทึก?**  
Field identifiers, calculated text, and formatting are separate things to verify. Format conversion can change the visible result even when the field identifier is still present.