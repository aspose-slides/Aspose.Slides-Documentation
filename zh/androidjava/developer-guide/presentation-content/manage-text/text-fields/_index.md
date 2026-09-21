---
title: 在 Android 上管理 PowerPoint 演示文稿的文本字段
linktitle: 文本字段
type: docs
weight: 52
url: /zh/androidjava/text-fields/
keywords:
- 文本字段
- 自动文本
- 幻灯片编号
- 日期和时间
- 页眉
- 页脚
- 文本部分
- PowerPoint
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android（Java）在 PowerPoint 演示文稿中创建、检查、修改和移除文本字段。保留格式并验证已保存的 PPTX 和 PPT 文件。"
---
## **概述**

文本段落由多个部分组成。普通的 [IPortion](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iportion/) 包含文字字面；字段部分还拥有一个 [IField](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifield/)，其类型标识会自动更新的值，例如幻灯片编号或日期。两个部分可以显示相同的字符，但仅有一个包含字段。

使用 [IPortion.getField](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iportion/#getField--) 来区分它们：普通文本返回 `null`。[IPortion.addField](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) 可将已有部分转换为字段。请将标签及其动态值放在不同的部分中，以免在转换值时同时替换标签。

本指南介绍文本中的字段、字段的格式以及在 PPTX 和 PPT 中的保存方式。有关文本框和段落的更多信息，请参阅 [Manage Text](/slides/zh/androidjava/manage-text/)。

## **创建幻灯片编号字段**

下面的完整示例创建一个文本框，其中包含文字 `Slide ` 标签，后跟自动更新的编号。示例在添加字段之前设置编号的大小、粗细和颜色，然后重新打开已保存的演示文稿并检查字段类型、文本及格式。无需输入文件。

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    int numberColor = Color.rgb(0, 0, 139);
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
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor() == numberColor;

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

新演示文稿从幻灯片编号 1 开始，因此文本为 `Slide 1`，两项检查均返回 `true`。重新打开后编号仍然是字段，而不是文字 `1`。验证中的强制转换和索引对应本示例创建的形状和部分。

## **选择字段类型**

[FieldType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/fieldtype/) 实现 [IFieldType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifieldtype/) 并提供以下方法以获取预定义值。将合适的值传递给 [addField](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-)。

| 方法 | 用途 |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/fieldtype/#getSlideNumber--) | 当前幻灯片编号。 |
| [getDateTime](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/fieldtype/#getDateTime--) | 以渲染应用程序默认格式显示日期/时间。 |
| [getDateTime1](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/fieldtype/#getDateTime9--) | 预定义的日期或组合日期/时间格式。 |
| [getDateTime10](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/fieldtype/#getDateTime13--) | 预定义的时间格式，包含秒以及 12 小时制选项。 |
| [getHeader](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/fieldtype/#getHeader--) | 页眉字段；请参阅下文的占位符和格式限制。 |
| [getFooter](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/fieldtype/#getFooter--) | 页脚字段。 |

例如，[getDateTime3](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/fieldtype/#getDateTime3--) 表示英文的“日 月全称 年”。这些是预定义的字段格式，而非任意的 Java 日期格式字符串。使用 [setLanguageId](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) 设置的语言以及处理演示文稿的应用程序都可能影响显示结果。

## **从内部字符串创建字段**

[addField](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iportion/#addField-java.lang.String-) 的字符串重载接受内部字段标识符。当需要保留其他应用程序提供的标识符且该标识符没有预定义值时使用它。也可以通过标识符构造 [FieldType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/fieldtype/#FieldType-java.lang.String-)。[IFieldType.getInternalString](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifieldtype/#getInternalString--) 可公开该标识符供检查。

本例将一个特定于应用程序的 `custom-report-id` 字段与后备文本 `Report-042` 一起存储。该标识符不会触发计算：Aspose.Slides 不会为未知类型生成报告 ID。必须由能够识别此标识符的应用程序提供其含义并更新其值。

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

此 PPTX 循环后，类型为 `custom-report-id`，文本为 `Report-042`。如果传入类似 `yyyy-MM-dd` 的字符串，则会创建一个字段类型，而不是配置自定义日期格式。若需固定日期且采用任意格式，请使用普通文字。

## **检查、修改和移除日期/时间字段**

通过 [IField.setType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-) 更改已有字段。在访问其类型之前请先确认字段存在。若要停止自动更新，请调用 [IPortion.removeField](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iportion/#removeField--)。此操作保留该部分及其当前文字，同时移除字段关联。如果需要特定的固定值，请在移除字段后为其赋予相应文字。

有关日期/时间字段处理的 API 设置，请参阅 [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-)。下面的示例在将字段转换为普通文字时使用了明确的批准日期。

下载 [sample.pptx](sample.pptx) 并放置在工作目录中。文件包含两个已命名的文本形状 `UpdatedAt` 和 `ApprovedDate`，每个形状都有日期/时间字段以及普通文字标签。以下示例遍历普通幻灯片上的顶层文本形状。它将日期/时间字段转换为长日期格式并设为斜体，同时保留其他格式。只有 `ApprovedDate` 中的字段会变为固定文字。

示例识别内置的内部标识符 `datetime` 以及 `datetime1` 到 `datetime13`。组、表格、备注、布局和母版需要遍历各自的文本容器，超出本示例范围。

```java
import java.util.Calendar;
import java.text.SimpleDateFormat;
import java.util.Locale;
import java.util.Date;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    Calendar approvalDate = Calendar.getInstance();
    approvalDate.clear();
    approvalDate.set(2030, Calendar.APRIL, 5);
    SimpleDateFormat dateFormat = new SimpleDateFormat("dd MMMM yyyy", Locale.US);

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
                        Date dateValue = approvalDate.getTime();
                        String fixedDate = dateFormat.format(dateValue);
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

重新打开后，`UpdatedAt` 的类型为 `datetime3`，仍为动态字段。`ApprovedDate` 已无字段，文本为 `05 April 2030`。两段日期文字均为斜体，且保持原始的字体大小、粗体设置和颜色不变。普通文字标签保持不变。验证代码读取提供的样本中两个已知形状的第一段文字。

## **保留文本格式**

在添加字段、修改其类型或移除字段时，请对已有部分进行操作。这些操作会保留该部分的格式。使用 [IPortion.getPortionFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iportion/#getPortionFormat--) 仅更改所需属性，正如示例对颜色或斜体所做的那样。

避免为更新单个字段而重新构建整个文本框：这样可能会丢失原始部分的边界及其各自的格式。还要区分显式设置的格式与从段落、布局或主题继承的格式。更多格式选项请参阅 [Text Formatting](/slides/zh/androidjava/text-formatting/)。

## **字段与页眉/页脚占位符**

字段是文本部分的一部分。占位符是具有演示文稿角色（例如页脚或幻灯片编号）的形状。向普通文本框添加字段并不会使该形状变为占位符。

页眉/页脚管理器控制占位符文本及其在幻灯片、布局和母版上的可见性，并会向从属幻灯片传播。自定义文本框中的编号字段因此在未使用幻灯片编号占位符的情况下仍然有用。相反，修改占位符的可见性不会移除与其他文本框无关的字段。

预定义的页眉和页脚类型不会创建相应的占位符或提供其内容。特别是，普通 PowerPoint 幻灯片没有页眉占位符；页眉属于备注页和讲义页。不要假设任意形状中的页眉或页脚字段会自动获取通过占位符管理器配置的文本。有关此工作流，请参阅 [Presentation Headers and Footers](/slides/zh/androidjava/presentation-header-and-footer/)。

## **PPTX 和 PPT 的限制**

在保存并重新打开后，请同时检查字段类型及其生成的文本。保留标识符并不意味着应用程序能够计算或显示其值。

| 格式 | 字段行为与限制 |
|---|---|
| PPTX | 在字段文本旁存储内部字段标识符。循环检查时，预定义类型和上文使用的自定义标识符均能在保存后保持。未知的自定义类型保留其后备文本；不会获得自动计算逻辑。其他应用程序可能对不支持的标识符有不同处理。 |
| PPT | 使用旧版字段表示方式，兼容性更受限。循环检查时，幻灯片编号和预定义日期/时间字段能够在保存后保持。普通幻灯片文本框中的自定义字段重新打开时仍保留标识符，但其文本显示为 `*`；同上下文中的页眉字段也会产生 `*`。不要依赖自定义字段或不支持的字段上下文保留可见文本。 |

若需可移植的固定输出，请在保存前将不受支持的字段转换为普通文字并显式赋予所需值。这样可保留所选文本，同时有意停止自动更新。若目标应用程序本身会重新计算字段，也请对其进行测试。

## **常见问题**

**如何判断显示的数字或日期是否为字段？**

检查 [IPortion.getField](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iportion/#getField--)。非空值表明是字段；仅凭显示的文字无法判断。

**移除字段会删除其文字或格式吗？**

不会。[removeField](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iportion/#removeField--) 会将已有部分转换为普通文字。若需要特定的冻结日期或后备值，请在移除后手动赋值。

**内部字符串能定义新的日期格式或公式吗？**

不能。它仅标识字段类型。未知标识符不会提供求值器或 Java 日期格式模式。请使用受支持的预定义类型，或自行将值格式化为普通文字。

**为什么在保存后再次检查演示文稿？**

字段标识符、计算得到的文字以及格式是需要分别验证的事项。格式转换即使在标识符仍在的情况下，也可能改变可见结果。