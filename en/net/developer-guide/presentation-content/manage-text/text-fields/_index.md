---
title: Manage Text Fields in PowerPoint Presentations in .NET
linktitle: Text Fields
type: docs
weight: 52
url: /net/text-fields/
keywords:
- text field
- automatic text
- slide number
- date and time
- header
- footer
- text portion
- PowerPoint
- PPT
- PPTX
- C#
- Aspose.Slides
description: "Create, inspect, modify, and remove text fields in PowerPoint presentations with Aspose.Slides for .NET. Preserve formatting and verify saved PPTX and PPT files."
---

## **Overview**

A text paragraph consists of portions. An ordinary [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) contains literal text; a field portion also has an [IField](https://reference.aspose.com/slides/net/aspose.slides/ifield/) whose type identifies an automatically updated value, such as a slide number or date. Two portions can display the same characters while only one contains a field.

Use [IPortion.Field](https://reference.aspose.com/slides/net/aspose.slides/iportion/field/) to distinguish them: it is `null` for ordinary text. [IPortion.AddField](https://reference.aspose.com/slides/net/aspose.slides/iportion/addfield/) converts an existing portion into a field. Keep a label and its dynamic value in separate portions so that converting the value does not also replace the label.

This guide covers fields inside text, their formatting, and saving them in PPTX and PPT. For text frames and paragraphs, see [Manage Text](/slides/net/manage-text/).

## **Create a Slide Number Field**

The following complete example creates a text box containing a literal `Slide ` label followed by an automatically updated number. It sets the number's size, weight, and color before adding the field, then reopens the saved presentation and checks the field type, text, and formatting. No input file is required.

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

The new presentation starts with slide number 1, so the text is `Slide 1`, and both checks print `True`. The number remains a field after reopening; it is not a literal `1`. The casts and indices in the verification refer to the shape and portions created by this example.

## **Choose a Field Type**

[FieldType](https://reference.aspose.com/slides/net/aspose.slides/fieldtype/) implements [IFieldType](https://reference.aspose.com/slides/net/aspose.slides/ifieldtype/) and provides the following predefined values. Pass the appropriate value to [AddField](https://reference.aspose.com/slides/net/aspose.slides/iportion/addfield/).

| Value | Purpose |
|---|---|
| [SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/fieldtype/slidenumber/) | The current slide number. |
| [DateTime](https://reference.aspose.com/slides/net/aspose.slides/fieldtype/datetime/) | Date/time in the rendering application's default format. |
| [DateTime1](https://reference.aspose.com/slides/net/aspose.slides/fieldtype/datetime1/)–[DateTime9](https://reference.aspose.com/slides/net/aspose.slides/fieldtype/datetime9/) | Predefined date or combined date/time formats. |
| [DateTime10](https://reference.aspose.com/slides/net/aspose.slides/fieldtype/datetime10/)–[DateTime13](https://reference.aspose.com/slides/net/aspose.slides/fieldtype/datetime13/) | Predefined time formats, with options for seconds and a 12-hour clock. |
| [Header](https://reference.aspose.com/slides/net/aspose.slides/fieldtype/header/) | A header field; see the placeholder and format limitations below. |
| [Footer](https://reference.aspose.com/slides/net/aspose.slides/fieldtype/footer/) | A footer field. |

For example, [DateTime3](https://reference.aspose.com/slides/net/aspose.slides/fieldtype/datetime3/) represents a day, full month name, and year in English. These are predefined field formats, not arbitrary .NET date-format strings. The portion's [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) and the application processing the presentation can affect the displayed result.

## **Create a Field from an Internal String**

The string overload of [AddField](https://reference.aspose.com/slides/net/aspose.slides/iportion/addfield/) accepts an internal field identifier. Use it when preserving an identifier supplied by another application that has no predefined value. You can also construct a [FieldType](https://reference.aspose.com/slides/net/aspose.slides/fieldtype/fieldtype/) from the identifier. [IFieldType.InternalString](https://reference.aspose.com/slides/net/aspose.slides/ifieldtype/internalstring/) exposes that identifier for inspection.

This example stores an application-specific `custom-report-id` field with the fallback text `Report-042`. The identifier does not register a calculation: Aspose.Slides does not generate report IDs for an unknown type. The application that understands this identifier must supply its meaning and update its value.

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

After this PPTX round trip, the type is `custom-report-id` and the text is `Report-042`. Passing a string such as `yyyy-MM-dd` would name a field type; it would not configure a custom date format. For a fixed date in an arbitrary format, use ordinary text.

## **Inspect, Modify, and Remove Date/Time Fields**

Read and change an existing field through [IField.Type](https://reference.aspose.com/slides/net/aspose.slides/ifield/type/). Check that the field exists before accessing its type. To stop automatic updates, call [IPortion.RemoveField](https://reference.aspose.com/slides/net/aspose.slides/iportion/removefield/). This keeps the portion and its current text while removing the field association. If you need a specific fixed value, assign that text after removing the field.

For the API setting associated with date/time field processing, see [Presentation.CurrentDateTime](https://reference.aspose.com/slides/net/aspose.slides/presentation/currentdatetime/). The example below uses an explicit approval date when converting a field to ordinary text.

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

## **Preserve Text Formatting**

Work with the existing portion when adding a field, changing its type, or removing it. These operations retain that portion's formatting. Use [IPortion.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportion/portionformat/) to change only the required properties, as the examples do for color or italics.

Avoid rebuilding an entire text frame just to update one field: doing so can lose the original portion boundaries and their individual formatting. Also distinguish explicitly set formatting from formatting inherited from the paragraph, layout, or theme. See [Text Formatting](/slides/net/text-formatting/) for broader formatting options.

## **Fields and Header/Footer Placeholders**

A field is part of a text portion. A placeholder is a shape with a presentation role, such as a footer or slide number. Adding a field to an ordinary text box does not turn that shape into a placeholder.

The header/footer managers control placeholder text and visibility on slides, layouts, and masters, including propagation to dependent slides. A number field in a custom text box can therefore be useful even when you are not using the slide-number placeholder. Conversely, changing placeholder visibility does not remove a field from an unrelated text box.

The predefined header and footer types do not create the corresponding placeholders or supply their content. In particular, a regular PowerPoint slide has no header placeholder; headers belong to notes pages and handouts. Do not assume that a header or footer field in an arbitrary shape will automatically obtain the text configured through a placeholder manager. For that workflow, see [Presentation Headers and Footers](/slides/net/presentation-header-and-footer/).

## **PPTX and PPT Limitations**

Check both the field type and its resulting text after saving and reopening. Preserving an identifier does not prove that an application can calculate or display its value.

| Format | Field behavior and limitations |
|---|---|
| PPTX | Stores internal field identifiers alongside field text. In round-trip checks, the predefined types and the custom identifier used above survived saving and reopening. The unknown custom type retained its fallback text; it did not acquire automatic calculation logic. Another application may treat unsupported identifiers differently. |
| PPT | Uses legacy field representations and has more limited compatibility. In round-trip checks, slide-number and predefined date/time fields survived saving and reopening. A custom field in an ordinary slide text box reopened with its identifier but with `*` as its text; a header field in the same context also produced `*`. Do not rely on custom fields or unsupported field contexts retaining their visible text. |

For portable, fixed output, convert unsupported fields to ordinary text and explicitly assign the value you want before saving. This preserves the chosen text but intentionally stops automatic updates. Test the target application as well when its own field recalculation is part of your workflow.

## **FAQ**

**How can I tell whether a displayed number or date is a field?**

Inspect [IPortion.Field](https://reference.aspose.com/slides/net/aspose.slides/iportion/field/). A non-null value identifies a field; the displayed text alone cannot tell you.

**Does removing a field remove its text or formatting?**

No. [RemoveField](https://reference.aspose.com/slides/net/aspose.slides/iportion/removefield/) converts the existing portion to ordinary text. Assign an explicit value afterward if you need a particular frozen date or fallback value.

**Can an internal string define a new date format or formula?**

No. It identifies a field type. An unknown identifier does not provide an evaluator or a .NET date-format pattern. Use a supported predefined type or format a value yourself as ordinary text.

**Why check a presentation again after saving it?**

Field identifiers, calculated text, and formatting are separate things to verify. Format conversion can change the visible result even when the field identifier is still present.
