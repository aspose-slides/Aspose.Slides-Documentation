---
title: Manage Text Fields in PowerPoint Presentations in Python
linktitle: Text Fields
type: docs
weight: 52
url: /python-net/text-fields/
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
- Aspose.Slides
description: "Create, inspect, modify, and remove text fields in PowerPoint presentations with Aspose.Slides for Python via .NET. Preserve formatting and verify saved PPTX and PPT files."
---

## **Overview**

A text paragraph consists of portions. An ordinary [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) contains literal text; a field portion also has a [Field](https://reference.aspose.com/slides/python-net/aspose.slides/field/) whose type identifies an automatically updated value, such as a slide number or date. Two portions can display the same characters while only one contains a field.

Use [Portion.field](https://reference.aspose.com/slides/python-net/aspose.slides/portion/field/) to distinguish them: it is `None` for ordinary text. [Portion.add_field](https://reference.aspose.com/slides/python-net/aspose.slides/portion/add_field/) converts an existing portion into a field. Keep a label and its dynamic value in separate portions so that converting the value does not also replace the label.

This guide covers fields inside text, their formatting, and saving them in PPTX and PPT. For text frames and paragraphs, see [Manage Text](/slides/python-net/manage-text/).

## **Create a Slide Number Field**

The following complete example creates a text box containing a literal `Slide ` label followed by an automatically updated number. It sets the number's size, weight, and color before adding the field, then reopens the saved presentation and checks the field type, text, and formatting. No input file is required.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 240, 50)
    shape.add_text_frame("Slide ")
    paragraph = shape.text_frame.paragraphs[0]

    number_portion = slides.Portion()
    number_portion.portion_format.font_height = 24
    number_portion.portion_format.font_bold = slides.NullableBool.TRUE
    number_portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    number_portion.portion_format.fill_format.solid_fill_color.color = draw.Color.dark_blue
    paragraph.portions.add(number_portion)
    number_portion.add_field(slides.FieldType.slide_number)

    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("slide_number.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_number = saved_shape.text_frame.paragraphs[0].portions[1]
    has_number_field = saved_number.field is not None and saved_number.field.type.internal_string == slides.FieldType.slide_number.internal_string
    portion_format = saved_number.portion_format
    formatting_preserved = portion_format.font_height == 24 and portion_format.font_bold == slides.NullableBool.TRUE
    formatting_preserved &= portion_format.fill_format.solid_fill_color.color.to_argb() == draw.Color.dark_blue.to_argb()

    print(f"Text: {saved_shape.text_frame.text}")
    print(f"Slide number field: {has_number_field}")
    print(f"Formatting preserved: {formatting_preserved}")
```

The new presentation starts with slide number 1, so the text is `Slide 1`, and both checks print `True`. The number remains a field after reopening; it is not a literal `1`. The indices in the verification refer to the shape and portions created by this example.

## **Choose a Field Type**

[FieldType](https://reference.aspose.com/slides/python-net/aspose.slides/fieldtype/) provides the following predefined values. Pass the appropriate value to [add_field](https://reference.aspose.com/slides/python-net/aspose.slides/portion/add_field/).

| Value | Purpose |
|---|---|
| [slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/fieldtype/slide_number/) | The current slide number. |
| [date_time](https://reference.aspose.com/slides/python-net/aspose.slides/fieldtype/date_time/) | Date/time in the rendering application's default format. |
| [date_time1](https://reference.aspose.com/slides/python-net/aspose.slides/fieldtype/date_time1/)–[date_time9](https://reference.aspose.com/slides/python-net/aspose.slides/fieldtype/date_time9/) | Predefined date or combined date/time formats. |
| [date_time10](https://reference.aspose.com/slides/python-net/aspose.slides/fieldtype/date_time10/)–[date_time13](https://reference.aspose.com/slides/python-net/aspose.slides/fieldtype/date_time13/) | Predefined time formats, with options for seconds and a 12-hour clock. |
| [header](https://reference.aspose.com/slides/python-net/aspose.slides/fieldtype/header/) | A header field; see the placeholder and format limitations below. |
| [footer](https://reference.aspose.com/slides/python-net/aspose.slides/fieldtype/footer/) | A footer field. |

For example, [date_time3](https://reference.aspose.com/slides/python-net/aspose.slides/fieldtype/date_time3/) represents a day, full month name, and year in English. These are predefined field formats, not arbitrary Python date-format strings. The portion's [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) and the application processing the presentation can affect the displayed result.

## **Create a Field from an Internal String**

The string overload of [add_field](https://reference.aspose.com/slides/python-net/aspose.slides/portion/add_field/) accepts an internal field identifier. Use it when preserving an identifier supplied by another application that has no predefined value. You can also construct a [FieldType](https://reference.aspose.com/slides/python-net/aspose.slides/fieldtype/__init__/) from the identifier. [FieldType.internal_string](https://reference.aspose.com/slides/python-net/aspose.slides/fieldtype/internal_string/) exposes that identifier for inspection.

This example stores an application-specific `custom-report-id` field with the fallback text `Report-042`. The identifier does not register a calculation: Aspose.Slides does not generate report IDs for an unknown type. The application that understands this identifier must supply its meaning and update its value.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 50)
    shape.add_text_frame("Report-042")
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.add_field("custom-report-id")

    presentation.save("custom_field.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom_field.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_portion = saved_shape.text_frame.paragraphs[0].portions[0]
    type_name = saved_portion.field.type.internal_string if saved_portion.field is not None else "ordinary text"
    print(f"Type: {type_name}")
    print(f"Text: {saved_portion.text}")
```

After this PPTX round trip, the type is `custom-report-id` and the text is `Report-042`. Passing a string such as `%Y-%m-%d` would name a field type; it would not configure a custom date format. For a fixed date in an arbitrary format, use ordinary text.

## **Inspect, Modify, and Remove Date/Time Fields**

Read and change an existing field through [Field.type](https://reference.aspose.com/slides/python-net/aspose.slides/field/type/). Check that the field exists before accessing its type. To stop automatic updates, call [Portion.remove_field](https://reference.aspose.com/slides/python-net/aspose.slides/portion/remove_field/). This keeps the portion and its current text while removing the field association. If you need a specific fixed value, assign that text after removing the field.

For the API setting associated with date/time field processing, see [Presentation.current_date_time](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/current_date_time/). The example below uses an explicit approval date when converting a field to ordinary text. An English month-name tuple keeps the fixed date independent of the system locale.

Download [sample.pptx](sample.pptx) and place it in the working directory. It contains two named text shapes, `UpdatedAt` and `ApprovedDate`, each with a date/time field, plus ordinary text labels. The following example walks top-level text shapes on regular slides. It changes date/time fields to a long-date format and makes them italic, while preserving their other formatting. Only fields in `ApprovedDate` become fixed text.

The sample recognizes the built-in internal identifiers `datetime` and `datetime1` through `datetime13`. Groups, tables, notes, layouts, and masters require traversal of their own text containers and are outside this example's scope.

```python
from datetime import date

import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    approval_date = date(2030, 4, 5)
    english_months = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    approval_text = f"{approval_date.day:02d} {english_months[approval_date.month - 1]} {approval_date.year}"
    date_time_types = {"datetime"} | {f"datetime{index}" for index in range(1, 14)}

    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    field = portion.field
                    if field is None:
                        continue

                    if field.type.internal_string not in date_time_types:
                        continue

                    field.type = slides.FieldType.date_time3
                    portion.portion_format.language_id = "en-US"
                    portion.portion_format.font_italic = slides.NullableBool.TRUE

                    if shape.name == "ApprovedDate":
                        portion.remove_field()
                        portion.text = approval_text

    presentation.save("updated_dates.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("updated_dates.pptx") as reopened:
    for shape in reopened.slides[0].shapes:
        if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
            continue
        if shape.name not in {"UpdatedAt", "ApprovedDate"}:
            continue

        portion = shape.text_frame.paragraphs[0].portions[0]
        type_name = portion.field.type.internal_string if portion.field is not None else "ordinary text"
        print(f"{shape.name}: {type_name}; {portion.text}")
        print(f"Italic: {portion.portion_format.font_italic == slides.NullableBool.TRUE}")
```

After reopening, `UpdatedAt` has type `datetime3` and remains dynamic. `ApprovedDate` has no field and contains `05 April 2030`. Both date portions are italic, and their original font size, bold setting, and color remain intact. The ordinary text labels are unchanged. The verification reads the first portion of the two known shapes in the supplied sample.

## **Preserve Text Formatting**

Work with the existing portion when adding a field, changing its type, or removing it. These operations retain that portion's formatting. Use [Portion.portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/portion/portion_format/) to change only the required properties, as the examples do for color or italics.

Avoid rebuilding an entire text frame just to update one field: doing so can lose the original portion boundaries and their individual formatting. Also distinguish explicitly set formatting from formatting inherited from the paragraph, layout, or theme. See [Text Formatting](/slides/python-net/text-formatting/) for broader formatting options.

## **Fields and Header/Footer Placeholders**

A field is part of a text portion. A placeholder is a shape with a presentation role, such as a footer or slide number. Adding a field to an ordinary text box does not turn that shape into a placeholder.

The header/footer managers control placeholder text and visibility on slides, layouts, and masters, including propagation to dependent slides. A number field in a custom text box can therefore be useful even when you are not using the slide-number placeholder. Conversely, changing placeholder visibility does not remove a field from an unrelated text box.

The predefined header and footer types do not create the corresponding placeholders or supply their content. In particular, a regular PowerPoint slide has no header placeholder; headers belong to notes pages and handouts. Do not assume that a header or footer field in an arbitrary shape will automatically obtain the text configured through a placeholder manager. For that workflow, see [Presentation Headers and Footers](/slides/python-net/presentation-header-and-footer/).

## **PPTX and PPT Limitations**

Check both the field type and its resulting text after saving and reopening. Preserving an identifier does not prove that an application can calculate or display its value.

| Format | Field behavior and limitations |
|---|---|
| PPTX | Stores internal field identifiers alongside field text. In round-trip checks, the predefined types and the custom identifier used above survived saving and reopening. The unknown custom type retained its fallback text; it did not acquire automatic calculation logic. Another application may treat unsupported identifiers differently. |
| PPT | Uses legacy field representations and has more limited compatibility. In round-trip checks, slide-number and predefined date/time fields survived saving and reopening. A custom field in an ordinary slide text box reopened with its identifier but with `*` as its text; a header field in the same context also produced `*`. Do not rely on custom fields or unsupported field contexts retaining their visible text. |

For portable, fixed output, convert unsupported fields to ordinary text and explicitly assign the value you want before saving. This preserves the chosen text but intentionally stops automatic updates. Test the target application as well when its own field recalculation is part of your workflow.

## **FAQ**

**How can I tell whether a displayed number or date is a field?**

Inspect [Portion.field](https://reference.aspose.com/slides/python-net/aspose.slides/portion/field/). A value other than `None` identifies a field; the displayed text alone cannot tell you.

**Does removing a field remove its text or formatting?**

No. [remove_field](https://reference.aspose.com/slides/python-net/aspose.slides/portion/remove_field/) converts the existing portion to ordinary text. Assign an explicit value afterward if you need a particular frozen date or fallback value.

**Can an internal string define a new date format or formula?**

No. It identifies a field type. An unknown identifier does not provide an evaluator or a Python date-format pattern. Use a supported predefined type or format a value yourself as ordinary text.

**Why check a presentation again after saving it?**

Field identifiers, calculated text, and formatting are separate things to verify. Format conversion can change the visible result even when the field identifier is still present.
