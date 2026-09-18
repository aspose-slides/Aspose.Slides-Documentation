---
title: Manage Text Fields in PowerPoint Presentations in Java
linktitle: Text Fields
type: docs
weight: 52
url: /java/text-fields/
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
- Java
- Aspose.Slides
description: "Create, inspect, modify, and remove text fields in PowerPoint presentations with Aspose.Slides for Java. Preserve formatting and verify saved PPTX and PPT files."
---

## **Overview**

A text paragraph consists of portions. An ordinary [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) contains literal text; a field portion also has an [IField](https://reference.aspose.com/slides/java/com.aspose.slides/ifield/) whose type identifies an automatically updated value, such as a slide number or date. Two portions can display the same characters while only one contains a field.

Use [IPortion.getField](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getField--) to distinguish them: it is `null` for ordinary text. [IPortion.addField](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) converts an existing portion into a field. Keep a label and its dynamic value in separate portions so that converting the value does not also replace the label.

This guide covers fields inside text, their formatting, and saving them in PPTX and PPT. For text frames and paragraphs, see [Manage Text](/slides/java/manage-text/).

## **Create a Slide Number Field**

The following complete example creates a text box containing a literal `Slide ` label followed by an automatically updated number. It sets the number's size, weight, and color before adding the field, then reopens the saved presentation and checks the field type, text, and formatting. No input file is required.

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    Color numberColor = new Color(0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(NullableBool.True);
    numberPortion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("slide_number.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        IField savedField = savedNumber.getField();
        boolean hasNumberField = savedField != null && FieldType.getSlideNumber().getInternalString().equals(savedField.getType().getInternalString());
        IPortionFormat format = savedNumber.getPortionFormat();
        boolean formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == NullableBool.True;
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

        System.out.println("Text: " + savedShape.getTextFrame().getText());
        System.out.println("Slide number field: " + hasNumberField);
        System.out.println("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

The new presentation starts with slide number 1, so the text is `Slide 1`, and both checks print `true`. The number remains a field after reopening; it is not a literal `1`. The casts and indices in the verification refer to the shape and portions created by this example.

## **Choose a Field Type**

[FieldType](https://reference.aspose.com/slides/java/com.aspose.slides/fieldtype/) implements [IFieldType](https://reference.aspose.com/slides/java/com.aspose.slides/ifieldtype/) and provides the following methods for obtaining predefined values. Pass the appropriate value to [addField](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-).

| Method | Purpose |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/fieldtype/#getSlideNumber--) | The current slide number. |
| [getDateTime](https://reference.aspose.com/slides/java/com.aspose.slides/fieldtype/#getDateTime--) | Date/time in the rendering application's default format. |
| [getDateTime1](https://reference.aspose.com/slides/java/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/java/com.aspose.slides/fieldtype/#getDateTime9--) | Predefined date or combined date/time formats. |
| [getDateTime10](https://reference.aspose.com/slides/java/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/java/com.aspose.slides/fieldtype/#getDateTime13--) | Predefined time formats, with options for seconds and a 12-hour clock. |
| [getHeader](https://reference.aspose.com/slides/java/com.aspose.slides/fieldtype/#getHeader--) | A header field; see the placeholder and format limitations below. |
| [getFooter](https://reference.aspose.com/slides/java/com.aspose.slides/fieldtype/#getFooter--) | A footer field. |

For example, [getDateTime3](https://reference.aspose.com/slides/java/com.aspose.slides/fieldtype/#getDateTime3--) represents a day, full month name, and year in English. These are predefined field formats, not arbitrary Java date-format strings. The language set with [setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) and the application processing the presentation can affect the displayed result.

## **Create a Field from an Internal String**

The string overload of [addField](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#addField-java.lang.String-) accepts an internal field identifier. Use it when preserving an identifier supplied by another application that has no predefined value. You can also construct a [FieldType](https://reference.aspose.com/slides/java/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) from the identifier. [IFieldType.getInternalString](https://reference.aspose.com/slides/java/com.aspose.slides/ifieldtype/#getInternalString--) exposes that identifier for inspection.

This example stores an application-specific `custom-report-id` field with the fallback text `Report-042`. The identifier does not register a calculation: Aspose.Slides does not generate report IDs for an unknown type. The application that understands this identifier must supply its meaning and update its value.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom_field.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        IField savedField = savedPortion.getField();
        String typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        System.out.println("Type: " + typeName);
        System.out.println("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

After this PPTX round trip, the type is `custom-report-id` and the text is `Report-042`. Passing a string such as `yyyy-MM-dd` would name a field type; it would not configure a custom date format. For a fixed date in an arbitrary format, use ordinary text.

## **Inspect, Modify, and Remove Date/Time Fields**

Change an existing field through [IField.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-). Check that the field exists before accessing its type. To stop automatic updates, call [IPortion.removeField](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#removeField--). This keeps the portion and its current text while removing the field association. If you need a specific fixed value, assign that text after removing the field.

For the API setting associated with date/time field processing, see [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-). The example below uses an explicit approval date when converting a field to ordinary text.

Download [sample.pptx](sample.pptx) and place it in the working directory. It contains two named text shapes, `UpdatedAt` and `ApprovedDate`, each with a date/time field, plus ordinary text labels. The following example walks top-level text shapes on regular slides. It changes date/time fields to a long-date format and makes them italic, while preserving their other formatting. Only fields in `ApprovedDate` become fixed text.

The sample recognizes the built-in internal identifiers `datetime` and `datetime1` through `datetime13`. Groups, tables, notes, layouts, and masters require traversal of their own text containers and are outside this example's scope.

```java
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Locale;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    LocalDate approvalDate = LocalDate.of(2030, 4, 5);
    DateTimeFormatter dateFormat = DateTimeFormatter.ofPattern("dd MMMM yyyy", Locale.US);

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }

            for (IParagraph paragraph : textShape.getTextFrame().getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    IField field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    String typeName = field.getType().getInternalString();
                    boolean isDateTime = typeName != null && typeName.matches("datetime([1-9]|1[0-3])?");
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(NullableBool.True);

                    if ("ApprovedDate".equals(textShape.getName())) {
                        portion.removeField();
                        String fixedDate = approvalDate.format(dateFormat);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("updated_dates.pptx");
    try {
        for (IShape shape : reopened.getSlides().get_Item(0).getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }
            if (!"UpdatedAt".equals(textShape.getName()) && !"ApprovedDate".equals(textShape.getName())) {
                continue;
            }

            IPortion portion = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            IField field = portion.getField();
            String typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            System.out.println(textShape.getName() + ": " + typeName + "; " + portion.getText());
            System.out.println("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

After reopening, `UpdatedAt` has type `datetime3` and remains dynamic. `ApprovedDate` has no field and contains `05 April 2030`. Both date portions are italic, and their original font size, bold setting, and color remain intact. The ordinary text labels are unchanged. The verification reads the first portion of the two known shapes in the supplied sample.

## **Preserve Text Formatting**

Work with the existing portion when adding a field, changing its type, or removing it. These operations retain that portion's formatting. Use [IPortion.getPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getPortionFormat--) to change only the required properties, as the examples do for color or italics.

Avoid rebuilding an entire text frame just to update one field: doing so can lose the original portion boundaries and their individual formatting. Also distinguish explicitly set formatting from formatting inherited from the paragraph, layout, or theme. See [Text Formatting](/slides/java/text-formatting/) for broader formatting options.

## **Fields and Header/Footer Placeholders**

A field is part of a text portion. A placeholder is a shape with a presentation role, such as a footer or slide number. Adding a field to an ordinary text box does not turn that shape into a placeholder.

The header/footer managers control placeholder text and visibility on slides, layouts, and masters, including propagation to dependent slides. A number field in a custom text box can therefore be useful even when you are not using the slide-number placeholder. Conversely, changing placeholder visibility does not remove a field from an unrelated text box.

The predefined header and footer types do not create the corresponding placeholders or supply their content. In particular, a regular PowerPoint slide has no header placeholder; headers belong to notes pages and handouts. Do not assume that a header or footer field in an arbitrary shape will automatically obtain the text configured through a placeholder manager. For that workflow, see [Presentation Headers and Footers](/slides/java/presentation-header-and-footer/).

## **PPTX and PPT Limitations**

Check both the field type and its resulting text after saving and reopening. Preserving an identifier does not prove that an application can calculate or display its value.

| Format | Field behavior and limitations |
|---|---|
| PPTX | Stores internal field identifiers alongside field text. In round-trip checks, the predefined types and the custom identifier used above survived saving and reopening. The unknown custom type retained its fallback text; it did not acquire automatic calculation logic. Another application may treat unsupported identifiers differently. |
| PPT | Uses legacy field representations and has more limited compatibility. In round-trip checks, slide-number and predefined date/time fields survived saving and reopening. A custom field in an ordinary slide text box reopened with its identifier but with `*` as its text; a header field in the same context also produced `*`. Do not rely on custom fields or unsupported field contexts retaining their visible text. |

For portable, fixed output, convert unsupported fields to ordinary text and explicitly assign the value you want before saving. This preserves the chosen text but intentionally stops automatic updates. Test the target application as well when its own field recalculation is part of your workflow.

## **FAQ**

**How can I tell whether a displayed number or date is a field?**

Inspect [IPortion.getField](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getField--). A non-null value identifies a field; the displayed text alone cannot tell you.

**Does removing a field remove its text or formatting?**

No. [removeField](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#removeField--) converts the existing portion to ordinary text. Assign an explicit value afterward if you need a particular frozen date or fallback value.

**Can an internal string define a new date format or formula?**

No. It identifies a field type. An unknown identifier does not provide an evaluator or a Java date-format pattern. Use a supported predefined type or format a value yourself as ordinary text.

**Why check a presentation again after saving it?**

Field identifiers, calculated text, and formatting are separate things to verify. Format conversion can change the visible result even when the field identifier is still present.
