---
title: "Lấy Thuộc tính Hiệu lực của Hình từ Bản trình bày trong PHP"
linktitle: "Thuộc tính Hiệu lực"
type: docs
weight: 50
url: /vi/php-java/shape-effective-properties/
keywords:
- "thuộc tính hình"
- "thuộc tính camera"
- "bộ ánh sáng"
- "hình dạng bevel"
- "khung văn bản"
- "kiểu văn bản"
- "độ cao phông chữ"
- "định dạng tô"
- "PowerPoint"
- "bản trình bày"
- "PHP"
- "Aspose.Slides"
description: "Tìm hiểu cách sử dụng Aspose.Slides cho PHP thông qua Java để phân biệt định dạng hình cục bộ, kế thừa và hiệu lực trong các bản trình bày PowerPoint."
---
## **Hiểu Thuộc tính Cục bộ, Kế thừa và Hiệu lực**

PowerPoint formatting can come from several places. The value stored directly on an object is its **local value**. If that value is not set, PowerPoint looks at parent formatting sources, such as a paragraph default, a text style, a layout or master slide, a theme, or presentation-level defaults. Those values are **inherited values**. The value that remains after the entire hierarchy is resolved is the **effective value**—the value used to render the object.

For example, a text portion may not define its own font height. Its local [getFontHeight](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseportionformat/) value is then `NAN`, which means "not set here." The portion can inherit a height from its paragraph, the presentation's default text style, or another applicable source. Calling [getEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portionformat/geteffective/) on the portion format returns the final resolved height.

Use the two kinds of formatting data for different purposes:

- Đọc hoặc thay đổi một đối tượng định dạng cục bộ, chẳng hạn như [PortionFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portionformat/), khi bạn cần kiểm soát nơi một giá trị được xác định.
- Đọc một đối tượng dữ liệu hiệu lực, chẳng hạn như [data returned by PortionFormat.getEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portionformat/geteffective/), khi bạn cần kết quả cuối cùng đã được render. Dữ liệu hiệu lực chỉ đọc.

Before running the examples, [cài đặt Aspose.Slides cho PHP thông qua Java](/slides/vi/php-java/installation/).

## **So sánh Giá trị Cục bộ, Kế thừa và Hiệu lực**

The following complete example creates a shape and applies font heights at the presentation, paragraph, and portion levels. Each step prints the values defined at those levels and the resulting effective value for the same text portion. It also demonstrates why effective data must be read again after formatting changes.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function formatLocalValue($value)
{
    return $value === null || is_nan($value) ? "<not set>" : (string)$value;
}

function printFontHeights($caption, $presentation, $paragraph, $portion)
{
    $presentationValue = java_values($presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->getFontHeight());
    $paragraphValue = java_values($paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFontHeight());
    $localValue = java_values($portion->getPortionFormat()->getFontHeight());

    // Đọc dữ liệu hiệu lực sau các thay đổi trước đó.
    $effectiveValue = java_values($portion->getPortionFormat()->getEffective()->getFontHeight());

    echo $caption . PHP_EOL;
    echo "  Presentation default: " . formatLocalValue($presentationValue) . PHP_EOL;
    echo "  Paragraph default:    " . formatLocalValue($paragraphValue) . PHP_EOL;
    echo "  Portion local:        " . formatLocalValue($localValue) . PHP_EOL;
    echo "  Portion effective:    " . $effectiveValue . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 80, false);
    $textFrame = $shape->addTextFrame("Effective formatting");
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    // Xác định các giá trị kế thừa ở hai mức độ khác nhau.
    $presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", $presentation, $paragraph, $portion);

    // Giá trị cục bộ trên phần sẽ ghi đè cả các giá trị kế thừa.
    $portion->getPortionFormat()->setFontHeight(36);
    printFontHeights("A local value overrides inherited values", $presentation, $paragraph, $portion);

    // Thay đổi giá trị kế thừa không ghi đè giá trị cục bộ hiện có.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(30);
    printFontHeights("The local value still has priority", $presentation, $paragraph, $portion);

    // Xóa giá trị cục bộ. Phần hiện nay sẽ kế thừa lại từ đoạn văn.
    $portion->getPortionFormat()->setFontHeight(NAN);
    printFontHeights("The local value is cleared", $presentation, $paragraph, $portion);

    // Xóa giá trị đoạn văn. Giá trị mặc định của bản trình bày sẽ cung cấp kết quả.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(NAN);
    printFontHeights("The paragraph value is cleared", $presentation, $paragraph, $portion);

    $presentation->save("effective-properties.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

The priority in this example is portion local formatting, then paragraph formatting, then the presentation default. Other objects can have different inheritance chains, but the principle is the same: a more specific explicit value wins, and [getEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portionformat/geteffective/) returns the final result.

## **Lấy Thuộc tính Văn bản Hiệu lực**

Text formatting is split across several objects:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/geteffective/) resolves text-frame properties such as margins, anchoring, autofit, and vertical text direction.
- [TextStyle.getEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textstyle/geteffective/) resolves paragraph formatting for each text style level.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/geteffective/) resolves paragraph properties such as alignment, indentation, and bullets.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portionformat/geteffective/) resolves character properties such as font height, typeface, color, bold, and italic.

For the next example, `text-formatting.pptx` must contain at least one slide and one [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) with a non-empty text frame. The AutoShape can appear at any position in the shape collection; the code searches for a suitable object and validates it before use.

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    if ($value === null) {
        return "<not set>";
    }
    if (is_bool($value)) {
        return $value ? "true" : "false";
    }
    return (string)$value;
}

function hasNonEmptyText($shape)
{
    $textFrame = $shape->getTextFrame();
    if (java_is_null($textFrame)) {
        return false;
    }
    if (java_values($textFrame->getParagraphs()->getCount()) === 0) {
        return false;
    }
    return java_values($textFrame->getParagraphs()->get_Item(0)->getPortions()->getCount()) > 0;
}

function findAutoShapeWithText($slide)
{
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $candidate = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($candidate, $autoShapeClass) && hasNonEmptyText($candidate)) {
            return $candidate;
        }
    }
    return null;
}

$presentation = new Presentation("text-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $shape = findAutoShapeWithText($presentation->getSlides()->get_Item(0));
    if ($shape === null) {
        throw new RuntimeException("The first slide must contain an AutoShape with non-empty text.");
    }

    $textFrame = $shape->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $textFrameEffective = $textFrame->getTextFrameFormat()->getEffective();
    $paragraphEffective = $paragraph->getParagraphFormat()->getEffective();
    $portionEffective = $portion->getPortionFormat()->getEffective();

    echo "Text frame margins:" . PHP_EOL;
    echo "  Left: " . formatEffectiveValue($textFrameEffective->getMarginLeft()) . PHP_EOL;
    echo "  Top: " . formatEffectiveValue($textFrameEffective->getMarginTop()) . PHP_EOL;
    echo "  Right: " . formatEffectiveValue($textFrameEffective->getMarginRight()) . PHP_EOL;
    echo "  Bottom: " . formatEffectiveValue($textFrameEffective->getMarginBottom()) . PHP_EOL;
    echo "Paragraph alignment: " . formatEffectiveValue($paragraphEffective->getAlignment()) . PHP_EOL;
    echo "Font height: " . formatEffectiveValue($portionEffective->getFontHeight()) . PHP_EOL;
    echo "Bold: " . formatEffectiveValue($portionEffective->getFontBold()) . PHP_EOL;

    $effectiveTextStyle = $textFrame->getTextFrameFormat()->getTextStyle()->getEffective();
    for ($level = 0; $level < 9; $level++) {
        $levelEffective = $effectiveTextStyle->getLevel($level);
        echo "Level " . $level . " indent: " . formatEffectiveValue($levelEffective->getIndent()) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Lấy Thuộc tính 3D Hiệu lực**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/geteffective/) returns one effective data object that groups all resolved 3D settings. Its [getCamera](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/geteffective/), [getLightRig](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/geteffective/), [getBevelTop](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/geteffective/), and [getBevelBottom](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/geteffective/) methods expose the corresponding effective data. Reading these related settings together makes it easier to understand the final 3D appearance of a shape.

For this example, `shape-3d.pptx` must contain at least one shape on its first slide. Apply 3D camera, lighting, or bevel settings to that shape if you want the output to contain values other than the defaults.

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    return $value === null ? "<not set>" : (string)$value;
}

$presentation = new Presentation("shape-3d.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0 || java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) === 0) {
        throw new RuntimeException("The first slide must contain a shape.");
    }

    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $threeDEffective = $shape->getThreeDFormat()->getEffective();

    echo "Camera:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getCamera()->getCameraType()) . PHP_EOL;
    echo "  Field of view: " . formatEffectiveValue($threeDEffective->getCamera()->getFieldOfViewAngle()) . PHP_EOL;
    echo "  Zoom: " . formatEffectiveValue($threeDEffective->getCamera()->getZoom()) . PHP_EOL;

    echo "Light rig:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getLightRig()->getLightType()) . PHP_EOL;
    echo "  Direction: " . formatEffectiveValue($threeDEffective->getLightRig()->getDirection()) . PHP_EOL;

    echo "Top bevel:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getBevelTop()->getBevelType()) . PHP_EOL;
    echo "  Width: " . formatEffectiveValue($threeDEffective->getBevelTop()->getWidth()) . PHP_EOL;
    echo "  Height: " . formatEffectiveValue($threeDEffective->getBevelTop()->getHeight()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Lấy Định dạng Bảng Hiệu lực**

Table formatting can come from the table style and from formats applied to the whole table, a column, a row, or an individual cell. For conflicts among explicitly defined fills, the priority is cell, row, column, and then whole table. The effective format of a cell is the final format used to draw that cell.

For this example, `table-formatting.pptx` must contain at least one table on its first slide. The table must have at least one row and one column. The code searches for a [Table](https://reference.aspose.com/slides/vi/php-java/aspose.slides/table/) instead of assuming that `getShapes()->get_Item(0)` is a table.

```php
use aspose\slides\Presentation;

function findTable($slide)
{
    $tableClass = new JavaClass("com.aspose.slides.Table");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            return $shape;
        }
    }
    return null;
}

$presentation = new Presentation("table-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $table = findTable($presentation->getSlides()->get_Item(0));
    if ($table === null) {
        throw new RuntimeException("The first slide must contain a table.");
    }
    if (java_values($table->getRows()->size()) === 0 || java_values($table->getColumns()->size()) === 0) {
        throw new RuntimeException("The table must contain at least one cell.");
    }

    $tableEffective = $table->getTableFormat()->getEffective();
    $rowEffective = $table->getRows()->get_Item(0)->getRowFormat()->getEffective();
    $columnEffective = $table->getColumns()->get_Item(0)->getColumnFormat()->getEffective();
    $cellEffective = $table->get_Item(0, 0)->getCellFormat()->getEffective();

    echo "Table fill: " . java_values($tableEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Row fill: " . java_values($rowEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Column fill: " . java_values($columnEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Final cell fill: " . java_values($cellEffective->getFillFormat()->getFillType()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

If you need the color rather than only the fill type, first check the effective [getFillType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fillformat/geteffective/) value, and then read the method that applies to that type—for example, [getSolidFillColor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fillformat/geteffective/) for a solid fill.

## **Đọc lại Dữ liệu Hiệu lực Sau khi Thay đổi**

Effective data describes the formatting hierarchy at the time it is resolved. Call `getEffective` again after changing anything that can participate in that hierarchy, including:

- the object's local formatting;
- paragraph or text-frame defaults;
- a table style, table, column, row, or cell format;
- layout or master slide formatting;
- theme data or presentation-level defaults;
- the layout or master assigned to a slide.

Do not keep an effective data object as a permanent snapshot. Aspose.Slides may cache some effective data internally, and a later `getEffective` call can refresh that data. If you need to compare values before and after a change, copy the scalar values you need—such as a font height, color, alignment, or bevel width—into your own variables before making the change.

To change a value, update the appropriate local format object and then call `getEffective` to verify the result. Effective data objects themselves are read-only.

## **Câu hỏi thường gặp**

**Làm sao tôi có thể biết mức nào đã cung cấp một giá trị hiệu lực?**

Effective data contains the final value, not its source. Inspect the applicable local objects from the most specific level outward. For text, this can include the portion, paragraph, text frame, layout, master, theme, and presentation defaults. Undefined values such as `NAN` or `null` indicate that the search continues to another level.

**Điều gì xảy ra khi không có mức nào định nghĩa một thuộc tính?**

Aspose.Slides resolves the appropriate PowerPoint or library default. That resolved value appears in the effective data even though no local object explicitly defines it.

**Tại sao một giá trị hiệu lực đôi khi bằng với giá trị cục bộ?**

The local value won the inheritance calculation. This is expected when the property is explicitly set on the object and no more specific rule overrides it.

**Khi nào tôi nên sử dụng dữ liệu cục bộ thay vì dữ liệu hiệu lực?**

Use local data to inspect or edit a specific formatting level. Use effective data when you need the final appearance after inheritance, theme rules, and applicable styles have been resolved. The [complete comparison example](#compare-local-inherited-and-effective-values) demonstrates both in the same workflow.