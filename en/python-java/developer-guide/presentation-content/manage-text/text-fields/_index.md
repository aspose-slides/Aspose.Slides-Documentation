---
title: Manage Text Fields in PowerPoint Presentations in Python via Java
linktitle: Text Fields
type: docs
weight: 52
url: /python-java/text-fields/
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
- Python
- Java
- Aspose.Slides
description: "Create, inspect, modify, and remove text fields in PowerPoint presentations with Aspose.Slides for Python via Java. Preserve formatting and verify saved PPTX and PPT files."
---

## **Overview**

A text paragraph consists of portions. An ordinary [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) contains literal text; a field portion also has a [Field](https://reference.aspose.com/slides/python-java/aspose.slides/field/) whose type identifies an automatically updated value, such as a slide number or date. Two portions can display the same characters while only one contains a field.

Use [Portion.getField](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getField) to distinguish them: it is `None` for ordinary text. [Portion.addField](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#addField) converts an existing portion into a field. Keep a label and its dynamic value in separate portions so that converting the value does not also replace the label.

This guide covers fields inside text, their formatting, and saving them in PPTX and PPT. For text frames and paragraphs, see [Manage Text](/slides/python-java/manage-text/).

## **Create a Slide Number Field**

The following complete example creates a text box containing a literal `Slide ` label followed by an automatically updated number. It sets the number's size, weight, and color before adding the field, then reopens the saved presentation and checks the field type, text, and formatting. No input file is required.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, ShapeType, NullableBool, FillType, FieldType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50)
    shape.addTextFrame("Slide ")
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)

    number_portion = Portion()
    number_color = Color(0, 0, 139)
    number_portion.getPortionFormat().setFontHeight(24)
    number_portion.getPortionFormat().setFontBold(NullableBool.True_)
    number_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    number_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(number_color)
    paragraph.getPortions().add(number_portion)
    number_portion.addField(FieldType.getSlideNumber())

    presentation.save("slide_number.pptx", SaveFormat.Pptx)

    reopened = Presentation("slide_number.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_number = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1)
        saved_field = saved_number.getField()
        has_number_field = saved_field is not None and saved_field.getType().getInternalString() == FieldType.getSlideNumber().getInternalString()
        portion_format = saved_number.getPortionFormat()
        formatting_preserved = portion_format.getFontHeight() == 24 and portion_format.getFontBold() == NullableBool.True_
        formatting_preserved = formatting_preserved and portion_format.getFillFormat().getSolidFillColor().getColor().getRGB() == number_color.getRGB()

        print(f"Text: {saved_shape.getTextFrame().getText()}")
        print(f"Slide number field: {has_number_field}")
        print(f"Formatting preserved: {formatting_preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

The new presentation starts with slide number 1, so the text is `Slide 1`, and both checks print `True`. The number remains a field after reopening; it is not a literal `1`. The indices in the verification refer to the shape and portions created by this example.

## **Choose a Field Type**

[FieldType](https://reference.aspose.com/slides/python-java/aspose.slides/fieldtype/) provides the following methods for obtaining predefined values. Pass the appropriate value to [addField](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#addField).

| Method | Purpose |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/fieldtype/#getSlideNumber) | The current slide number. |
| [getDateTime](https://reference.aspose.com/slides/python-java/aspose.slides/fieldtype/#getDateTime) | Date/time in the rendering application's default format. |
| [getDateTime1](https://reference.aspose.com/slides/python-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/python-java/aspose.slides/fieldtype/#getDateTime9) | Predefined date or combined date/time formats. |
| [getDateTime10](https://reference.aspose.com/slides/python-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/python-java/aspose.slides/fieldtype/#getDateTime13) | Predefined time formats, with options for seconds and a 12-hour clock. |
| [getHeader](https://reference.aspose.com/slides/python-java/aspose.slides/fieldtype/#getHeader) | A header field; see the placeholder and format limitations below. |
| [getFooter](https://reference.aspose.com/slides/python-java/aspose.slides/fieldtype/#getFooter) | A footer field. |

For example, [getDateTime3](https://reference.aspose.com/slides/python-java/aspose.slides/fieldtype/#getDateTime3) represents a day, full month name, and year in English. These are predefined field formats, not arbitrary Python date-format strings. The language set with [setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId) and the application processing the presentation can affect the displayed result.

## **Create a Field from an Internal String**

The string overload of [addField](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#addField) accepts an internal field identifier. Use it when preserving an identifier supplied by another application that has no predefined value. You can also construct a [FieldType](https://reference.aspose.com/slides/python-java/aspose.slides/fieldtype/#FieldType) from the identifier. [FieldType.getInternalString](https://reference.aspose.com/slides/python-java/aspose.slides/fieldtype/#getInternalString) exposes that identifier for inspection.

This example stores an application-specific `custom-report-id` field with the fallback text `Report-042`. The identifier does not register a calculation: Aspose.Slides does not generate report IDs for an unknown type. The application that understands this identifier must supply its meaning and update its value.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50)
    shape.addTextFrame("Report-042")
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.addField("custom-report-id")

    presentation.save("custom_field.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom_field.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_portion = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        saved_field = saved_portion.getField()
        type_name = "ordinary text" if saved_field is None else saved_field.getType().getInternalString()
        print(f"Type: {type_name}")
        print(f"Text: {saved_portion.getText()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

After this PPTX round trip, the type is `custom-report-id` and the text is `Report-042`. Passing a string such as `yyyy-MM-dd` would name a field type; it would not configure a custom date format. For a fixed date in an arbitrary format, use ordinary text.

## **Inspect, Modify, and Remove Date/Time Fields**

Change an existing field through [Field.setType](https://reference.aspose.com/slides/python-java/aspose.slides/field/#setType). Check that the field exists before accessing its type. To stop automatic updates, call [Portion.removeField](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#removeField). This keeps the portion and its current text while removing the field association. If you need a specific fixed value, assign that text after removing the field.

For the API setting associated with date/time field processing, see [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#setCurrentDateTime). The example below uses an explicit approval date when converting a field to ordinary text.

Download [sample.pptx](sample.pptx) and place it in the working directory. It contains two named text shapes, `UpdatedAt` and `ApprovedDate`, each with a date/time field, plus ordinary text labels. The following example walks top-level text shapes on regular slides. It changes date/time fields to a long-date format and makes them italic, while preserving their other formatting. Only fields in `ApprovedDate` become fixed text.

The sample recognizes the built-in internal identifiers `datetime` and `datetime1` through `datetime13`. Groups, tables, notes, layouts, and masters require traversal of their own text containers and are outside this example's scope.

```python
import re
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, FieldType, NullableBool, SaveFormat

presentation = Presentation("sample.pptx")
try:
    approval_date = date(2030, 4, 5)
    # Use English month names independently of the system locale.
    month_names = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    fixed_date = f"{approval_date.day:02d} {month_names[approval_date.month - 1]} {approval_date.year}"

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue

            for paragraph in shape.getTextFrame().getParagraphs():
                for portion in paragraph.getPortions():
                    field = portion.getField()
                    if field is None:
                        continue

                    type_name = field.getType().getInternalString()
                    is_date_time = type_name is not None and re.fullmatch(r"datetime([1-9]|1[0-3])?", str(type_name)) is not None
                    if not is_date_time:
                        continue

                    field.setType(FieldType.getDateTime3())
                    portion.getPortionFormat().setLanguageId("en-US")
                    portion.getPortionFormat().setFontItalic(NullableBool.True_)

                    if shape.getName() == "ApprovedDate":
                        portion.removeField()
                        portion.setText(fixed_date)

    presentation.save("updated_dates.pptx", SaveFormat.Pptx)

    reopened = Presentation("updated_dates.pptx")
    try:
        for shape in reopened.getSlides().get_Item(0).getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue
            if shape.getName() not in ("UpdatedAt", "ApprovedDate"):
                continue

            portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
            field = portion.getField()
            type_name = "ordinary text" if field is None else field.getType().getInternalString()
            print(f"{shape.getName()}: {type_name}; {portion.getText()}")
            print(f"Italic: {portion.getPortionFormat().getFontItalic()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

After reopening, `UpdatedAt` has type `datetime3` and remains dynamic. `ApprovedDate` has no field and contains `05 April 2030`. Both date portions are italic, and their original font size, bold setting, and color remain intact. The ordinary text labels are unchanged. The verification reads the first portion of the two known shapes in the supplied sample.

## **Preserve Text Formatting**

Work with the existing portion when adding a field, changing its type, or removing it. These operations retain that portion's formatting. Use [Portion.getPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getPortionFormat) to change only the required properties, as the examples do for color or italics.

Avoid rebuilding an entire text frame just to update one field: doing so can lose the original portion boundaries and their individual formatting. Also distinguish explicitly set formatting from formatting inherited from the paragraph, layout, or theme. See [Text Formatting](/slides/python-java/text-formatting/) for broader formatting options.

## **Fields and Header/Footer Placeholders**

A field is part of a text portion. A placeholder is a shape with a presentation role, such as a footer or slide number. Adding a field to an ordinary text box does not turn that shape into a placeholder.

The header/footer managers control placeholder text and visibility on slides, layouts, and masters, including propagation to dependent slides. A number field in a custom text box can therefore be useful even when you are not using the slide-number placeholder. Conversely, changing placeholder visibility does not remove a field from an unrelated text box.

The predefined header and footer types do not create the corresponding placeholders or supply their content. In particular, a regular PowerPoint slide has no header placeholder; headers belong to notes pages and handouts. Do not assume that a header or footer field in an arbitrary shape will automatically obtain the text configured through a placeholder manager. For that workflow, see [Presentation Headers and Footers](/slides/python-java/presentation-header-and-footer/).

## **PPTX and PPT Limitations**

Check both the field type and its resulting text after saving and reopening. Preserving an identifier does not prove that an application can calculate or display its value.

| Format | Field behavior and limitations |
|---|---|
| PPTX | Stores internal field identifiers alongside field text. In round-trip checks, the predefined types and the custom identifier used above survived saving and reopening. The unknown custom type retained its fallback text; it did not acquire automatic calculation logic. Another application may treat unsupported identifiers differently. |
| PPT | Uses legacy field representations and has more limited compatibility. In round-trip checks, slide-number and predefined date/time fields survived saving and reopening. A custom field in an ordinary slide text box reopened with its identifier but with `*` as its text; a header field in the same context also produced `*`. Do not rely on custom fields or unsupported field contexts retaining their visible text. |

For portable, fixed output, convert unsupported fields to ordinary text and explicitly assign the value you want before saving. This preserves the chosen text but intentionally stops automatic updates. Test the target application as well when its own field recalculation is part of your workflow.

## **FAQ**

**How can I tell whether a displayed number or date is a field?**

Inspect [Portion.getField](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getField). A value other than `None` identifies a field; the displayed text alone cannot tell you.

**Does removing a field remove its text or formatting?**

No. [removeField](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#removeField) converts the existing portion to ordinary text. Assign an explicit value afterward if you need a particular frozen date or fallback value.

**Can an internal string define a new date format or formula?**

No. It identifies a field type. An unknown identifier does not provide an evaluator or a Python date-format pattern. Use a supported predefined type or format a value yourself as ordinary text.

**Why check a presentation again after saving it?**

Field identifiers, calculated text, and formatting are separate things to verify. Format conversion can change the visible result even when the field identifier is still present.
