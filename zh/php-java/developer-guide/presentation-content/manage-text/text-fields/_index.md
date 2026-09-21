---
title: 在 PHP 中管理 PowerPoint 演示文稿的文本字段
linktitle: 文本字段
type: docs
weight: 52
url: /zh/php-java/text-fields/
keywords:
- 文本字段
- 自动文本
- 幻灯片编号
- 日期和时间
- 页眉
- 页脚
- 文本段落
- PowerPoint
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "使用通过 Java 的 Aspose.Slides for PHP 在 PowerPoint 演示文稿中创建、检查、修改和删除文本字段。保留格式并验证保存的 PPTX 和 PPT 文件。"
---
## **概述**

文本段落由多个 Portion 组成。普通的 [Portion](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portion/) 包含字面文本；字段 Portion 还拥有一个 [Field](https://reference.aspose.com/slides/zh/php-java/aspose.slides/field/)，其类型标识自动更新的值，例如幻灯片编号或日期。两个 Portion 可以显示相同的字符，但只有一个包含字段。

使用 [Portion::getField](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portion/#getField) 区分它们：普通文本返回 `null`。[Portion::addField](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portion/#addField) 可将已有的 Portion 转换为字段。将标签及其动态值放在不同的 Portion 中，这样在转换值时不会同时替换标签。

本指南涵盖文本中的字段、字段的格式设置以及在 PPTX 和 PPT 中的保存方式。有关文本框和段落的内容，请参阅 [Manage Text](/slides/zh/php-java/manage-text/)。

## **创建幻灯片编号字段**

以下完整示例创建一个文本框，包含字面 `Slide ` 标签，后跟自动更新的编号。示例先设置编号的大小、粗细和颜色，然后添加字段，随后重新打开保存的演示文稿并检查字段类型、文本及格式。无需输入文件。

```php
use aspose\slides\FieldType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
    $shape->addTextFrame("Slide ");
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);

    $numberPortion = new Portion();
    $numberColor = new Java("java.awt.Color", 0, 0, 139);
    $numberPortion->getPortionFormat()->setFontHeight(24);
    $numberPortion->getPortionFormat()->setFontBold(NullableBool::True);
    $numberPortion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $numberPortion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($numberColor);
    $paragraph->getPortions()->add($numberPortion);
    $numberPortion->addField(FieldType::getSlideNumber());

    $presentation->save("slide_number.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("slide_number.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedNumber = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1);
        $savedField = $savedNumber->getField();
        $hasNumberField = !java_is_null($savedField) && java_values(FieldType::getSlideNumber()->getInternalString()) === java_values($savedField->getType()->getInternalString());
        $format = $savedNumber->getPortionFormat();
        $formattingPreserved = java_values($format->getFontHeight()) == 24 && java_values($format->getFontBold()) == NullableBool::True;
        $formattingPreserved = $formattingPreserved && java_values($format->getFillFormat()->getSolidFillColor()->getColor()->getRGB()) == java_values($numberColor->getRGB());

        echo "Text: " . $savedShape->getTextFrame()->getText() . PHP_EOL;
        echo "Slide number field: " . ($hasNumberField ? "true" : "false") . PHP_EOL;
        echo "Formatting preserved: " . ($formattingPreserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

新演示文稿从幻灯片编号 1 开始，因此文本为 `Slide 1`，两项检查均返回 `true`。重新打开后编号仍是字段，而不是字面 `1`。验证中的索引对应本示例创建的形状和 Portion。

## **选择字段类型**

[FieldType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fieldtype/) 提供以下方法获取预定义值。将相应的值传递给 [addField](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portion/#addField)。

| 方法 | 目的 |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fieldtype/#getSlideNumber) | 当前幻灯片编号。 |
| [getDateTime](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fieldtype/#getDateTime) | 使用渲染应用程序默认格式的日期/时间。 |
| [getDateTime1](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fieldtype/#getDateTime9) | 预定义的日期或组合日期/时间格式。 |
| [getDateTime10](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fieldtype/#getDateTime13) | 预定义的时间格式，可包含秒和 12 小时制。 |
| [getHeader](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fieldtype/#getHeader) | 页眉字段；请参阅下文的占位符和格式限制。 |
| [getFooter](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fieldtype/#getFooter) | 页脚字段。 |

例如，[getDateTime3](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fieldtype/#getDateTime3) 表示英文的“日　完整月份名　年”。这些是预定义的字段格式，而不是任意的 PHP 日期格式字符串。使用 [setLanguageId](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseportionformat/#setLanguageId) 设置的语言以及处理演示文稿的应用程序都可能影响显示结果。

## **从内部字符串创建字段**

[addField](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portion/#addField) 的字符串重载接受内部字段标识符。当需要保留另一应用程序提供的标识符且该标识符没有预定义值时使用它。也可以通过标识符构造一个 [FieldType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fieldtype/#FieldType)。[FieldType::getInternalString](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fieldtype/#getInternalString) 可公开该标识符以供检查。

本示例在文本中存储了应用程序特定的 `custom-report-id` 字段，回退文本为 `Report-042`。该标识符不会触发计算：Aspose.Slides 不会为未知类型生成报告 ID。必须由了解该标识符的应用程序自行提供含义并更新其值。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
    $shape->addTextFrame("Report-042");
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->addField("custom-report-id");

    $presentation->save("custom_field.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom_field.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedPortion = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $savedField = $savedPortion->getField();
        $typeName = java_is_null($savedField) ? "ordinary text" : java_values($savedField->getType()->getInternalString());
        echo "Type: " . $typeName . PHP_EOL;
        echo "Text: " . $savedPortion->getText() . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

经过 PPTX 循环后，类型为 `custom-report-id`，文本为 `Report-042`。如果传入 `Y-m-d` 之类的字符串，它会被视为字段类型，而不是自定义日期格式。若需要固定的任意格式日期，请使用普通文本。

## **检查、修改和删除日期/时间字段**

通过 [Field::setType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/field/#setType) 更改已有字段。访问字段类型前请先确认字段存在。要停止自动更新，调用 [Portion::removeField](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portion/#removeField)。此操作会保留 Portion 及其当前文本，同时移除字段关联。如果需要特定的固定值，请在移除字段后手动赋予该文本。

有关日期/时间字段处理的 API 设置，请参阅 [Presentation::setCurrentDateTime](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#setCurrentDateTime)。下面的示例在将字段转换为普通文本时使用了显式的批准日期。

下载 [sample.pptx](sample.pptx) 并放置到 JavaBridge 工作目录，或将其绝对路径传递给演示文稿构造函数。该文件包含两个已命名的文本形状 `UpdatedAt` 和 `ApprovedDate`，每个形状都有日期/时间字段以及普通文本标签。以下示例遍历普通幻灯片中的顶层文本形状。它将日期/时间字段转换为长日期格式并设为斜体，同时保留其他格式。仅 `ApprovedDate` 中的字段会变为固定文本。

示例识别内置的内部标识符 `datetime` 以及 `datetime1` 到 `datetime13`。组、表格、备注页、版式和母版需要自行遍历其文本容器，超出本示例范围。

```php
use aspose\slides\FieldType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $approvalDate = new DateTimeImmutable("2030-04-05");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {

        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textShape->getTextFrame()->getParagraphs()->getCount()); $paragraphIndex++) {

                $paragraph = $textShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    $field = $portion->getField();
                    if (java_is_null($field)) {
                        continue;
                    }

                    $typeName = java_values($field->getType()->getInternalString());
                    $isDateTime = $typeName != null && preg_match("/\Adatetime([1-9]|1[0-3])?\z/", $typeName) === 1;
                    if (!$isDateTime) {
                        continue;
                    }

                    $field->setType(FieldType::getDateTime3());
                    $portion->getPortionFormat()->setLanguageId("en-US");
                    $portion->getPortionFormat()->setFontItalic(NullableBool::True);

                    if (java_values($textShape->getName()) === "ApprovedDate") {
                        $portion->removeField();
                        $fixedDate = $approvalDate->format("d F Y");
                        $portion->setText($fixedDate);
                    }
                }
            }
        }
    }

    $presentation->save("updated_dates.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("updated_dates.pptx");
    try {
        for ($shapeIndex = 0; $shapeIndex < java_values($reopened->getSlides()->get_Item(0)->getShapes()->size()); $shapeIndex++) {
            $shape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }
            if (java_values($textShape->getName()) !== "UpdatedAt" && java_values($textShape->getName()) !== "ApprovedDate") {
                continue;
            }

            $portion = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
            $field = $portion->getField();
            $typeName = java_is_null($field) ? "ordinary text" : java_values($field->getType()->getInternalString());
            echo $textShape->getName() . ": " . $typeName . "; " . $portion->getText() . PHP_EOL;
            echo "Italic: " . $portion->getPortionFormat()->getFontItalic() . PHP_EOL;
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

重新打开后，`UpdatedAt` 的类型为 `datetime3`，仍保持动态。`ApprovedDate` 没有字段，文本为 `05 April 2030`。两段日期文本均为斜体，原始的字体大小、粗体设置和颜色保持不变。普通文本标签保持原样。验证读取了示例文件中两个已知形状的第一段 Portion。

## **保持文本格式**

在添加字段、修改类型或移除字段时，请使用现有的 Portion。这些操作会保留该 Portion 的格式。使用 [Portion::getPortionFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portion/#getPortionFormat) 仅更改所需属性，示例中即对颜色或斜体如此操作。

避免为更新单个字段而重建整个文本框：这样可能会丢失原有 Portion 边界及其各自的格式。还要区分显式设置的格式与从段落、版式或主题继承的格式。有关更广泛的格式选项，请参阅 [Text Formatting](/slides/zh/php-java/text-formatting/)。

## **字段与页眉/页脚占位符**

字段是文本 Portion 的一部分。占位符是具有演示文稿角色（如页脚或幻灯片编号）的形状。向普通文本框添加字段不会使该形状变为占位符。

页眉/页脚管理器控制占位符文本及其在幻灯片、版式和母版上的可见性，包括向从属幻灯片的传播。自定义文本框中的编号字段因此在未使用幻灯片编号占位符时仍可能有用。相反，改变占位符的可见性并不会移除与无关文本框中的字段。

预定义的页眉和页脚类型并不创建对应的占位符，也不提供其内容。特别是普通 PowerPoint 幻灯片没有页眉占位符；页眉属于备注页和讲义页。不要以为任意形状中的页眉或页脚字段会自动获得占位符管理器配置的文本。有关此工作流，请参阅 [Presentation Headers and Footers](/slides/zh/php-java/presentation-header-and-footer/)。

## **PPTX 与 PPT 限制**

保存并重新打开后请检查字段类型及其产生的文本。保留标识符并不意味着应用程序能够计算或显示其值。

| 格式 | 字段行为与限制 |
|---|---|
| PPTX | 在字段文本旁存储内部字段标识符。循环检查时，预定义类型和上述自定义标识符均在保存并重新打开后保留。未知的自定义类型保留其回退文本；不会获得自动计算逻辑。其他应用程序可能对不支持的标识符有不同处理方式。 |
| PPT | 使用旧版字段表示，兼容性更受限。循环检查时，幻灯片编号和预定义日期/时间字段在保存并重新打开后仍然保留。普通幻灯片文本框中的自定义字段重新打开时仍带有标识符，但其文本为 `*`；同上下文的页眉字段也产生 `*`。不要依赖自定义字段或不受支持的字段上下文保留其可见文本。 |

若需可移植的固定输出，请在保存前将不受支持的字段转换为普通文本并显式赋予所需值。这会保留所选文本，同时刻意停止自动更新。若目标应用程序本身会重新计算字段，也请对其进行测试。

## **常见问题**

**如何判断显示的数字或日期是否为字段？**  
检查 [Portion::getField](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portion/#getField)。返回非 `null` 即表明是字段；仅凭显示的文本无法判断。

**移除字段会删除其文本或格式吗？**  
不会。`removeField` 将现有 Portion 转为普通文本。如需特定的冻结日期或回退值，请在移除后手动赋值。

**内部字符串能定义新的日期格式或公式吗？**  
不能。它仅用于标识字段类型。未知标识符不会提供求值器或 PHP 日期格式模式。请使用受支持的预定义类型，或自行将值格式化为普通文本。

**为什么在保存后要再次检查演示文稿？**  
字段标识符、计算得到的文本和格式是需要分别验证的对象。格式转换可能会改变可见结果，即使字段标识符仍然存在。