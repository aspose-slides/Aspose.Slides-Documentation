---
title: 使用邮件合并自动化演示文稿个性化
linktitle: 邮件合并
type: docs
weight: 233
url: /zh/net/mail-merge/
keywords:
- 邮件合并
- 演示文稿个性化
- 演示文稿模板
- 文本占位符
- 数据源
- CSV
- Excel
- XLSX
- JSON
- XML
- 合并数据
- 生成演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何在 Aspose.Slides for .NET 中使用邮件合并，通过数据填充演示文稿模板，并从 CSV、Excel、JSON 和 XML 来源生成个性化的 PowerPoint 演示文稿。"
---
# PowerPoint 演示文稿中的邮件合并

Aspose.Slides for .NET 允许您使用模板和数据源自动生成 PowerPoint 演示文稿。邮件合并将模板占位符填充为数据，并创建单个包含每个数据集的重复模板幻灯片的演示文稿，或为每个数据集创建单独的演示文稿。

此功能适用于生成产品目录、个性化演示、报告、证书、提案、价目表以及其他结构保持不变、内容可变的文档。

![邮件合并：前后对比](mail-merge-before-after.png)


## 邮件合并的工作原理

邮件合并使用 PowerPoint 演示文稿作为模板，并用数据源中的值替换占位符。

![邮件合并工作流](mail-merge-workflow.png)

占位符是用双大括号括起来的字段名，例如 `{{title}}` 或 `{{price}}`。占位符可以放置在形状文本、表格单元格、组合形状和演讲者备注中。

例如，模板幻灯片可能包含以下文本：

- `Product: {{title}}`
- `Price: {{price}}`
- `Description: {{description}}`

当数据源包含以下值时：

| 字段 | 值 |
|---|---|
| title | Laptop X1 |
| price | $999 |
| description | 14-inch display, 16 GB RAM |

邮件合并将占位符替换为相应的值，生成包含实际产品信息的幻灯片。

字段名不区分大小写，因此 `{{title}}` 和 `{{Title}}` 指的是同一字段。

替换占位符时适用以下规则：

- 替换发生在幻灯片上，包括组合形状和表格单元格，以及演讲者备注。
- 不会替换母版幻灯片和布局幻灯片上的占位符。
- 在数据集中未出现的字段对应的占位符保持不变。
- 空字段值会将其占位符替换为空字符串。
- 插入的文本继承占位符第一个字符的格式。
- 值中不得包含占位符文本，因为插入的文本可能再次被处理并被另一个字段替换。

合并操作期间不会修改原始模板演示文稿，模板必须至少包含一张幻灯片。

## 支持的数据源

邮件合并支持两种提供数据的方式：

- 使用 `IMailMergeDataSource` 编程方式创建数据源。
- 从 CSV、XLSX、JSON 或 XML 文件或流中读取数据。

数据格式通过内容而非文件扩展名进行检测。也支持不支持定位的流。

数据源必须至少包含一个数据集。每个数据集代表一份要用其值填充的模板副本。

如果数据内容无法识别为受支持的格式，将抛出 `NotSupportedException`。如果内容已识别但不符合格式要求，将抛出 `InvalidDataException`。异常消息中包含错误在数据中的位置。

### JSON

JSON 数据源必须有一个根对象，其中包含 `sets` 数组。数组的每个元素代表一个数据集，且必须包含 `fields` 数组。每个字段必须有 `name` 和 `value` 字符串。

可选的 `version` 属性必须为 `"1.0"`，字段的可选 `type` 属性必须为 `"text"`。属性名区分大小写。未知属性将被忽略。

JSON 数据以 UTF-8 读取，若数据以字节顺序标记 (BOM) 开头则以 UTF-16 读取。

以下示例包含两个数据集：

```json
{
  "version": "1.0",
  "sets": [
    {
      "fields": [
        { "name": "title", "value": "Laptop X1" },
        { "name": "price", "value": "$999" }
      ]
    },
    {
      "fields": [
        { "name": "title", "value": "Tablet S2" },
        { "name": "price", "value": "$499" }
      ]
    }
  ]
}
```

### XML

XML 数据源必须有一个 `template` 根元素，其中包含 `sets` 元素。每个 `set` 元素包含 `field` 元素，且每个字段必须包含 `name` 和 `value` 元素。

空的 `value` 元素视为空字符串。元素名称区分大小写。未知元素和注释将被忽略。编码由 XML 声明决定。文档类型定义 (DTD) 不被允许。

```xml
<?xml version="1.0" encoding="utf-8"?>
<template>
  <sets>
    <set>
      <field>
        <name>title</name>
        <value>Laptop X1</value>
      </field>
      <field>
        <name>price</name>
        <value>$999</value>
      </field>
    </set>
    <set>
      <field>
        <name>title</name>
        <value>Tablet S2</value>
      </field>
      <field>
        <name>price</name>
        <value>$499</value>
      </field>
    </set>
  </sets>
</template>
```

### CSV

CSV 数据使用分号作为值分隔符。

第一行包含字段名，遇到第一个空字段名即结束。随后每行代表一个数据集。数据在遇到第一行空行时结束。

适用规则：

- 行尾缺失的值视为空字符串。
- 超出已定义字段名的值将被忽略。
- 包含分号、引号或换行符的值必须用引号括起来。
- 引号内的引号必须写成双引号。
- 数据以 UTF-8 读取，若以 BOM 开头则以 UTF-16 读取。

示例：

```csv
title;price;description
Laptop X1;$999;"14"" display; 16 GB RAM"
Tablet S2;$499;
```

### XLSX

XLSX 数据从第一个工作表读取。

工作表遵循与 CSV 相同的规则：

- 第一行包含字段名，遇到第一个空单元格即结束。
- 随后每行代表一个数据集。
- 数据在遇到第一行空行时结束。
- 空单元格视为空字符串。
- 数值使用不变地区域信息转换为文本。

## 创建单个演示文稿

`MergeToSinglePresentation` 方法创建一个演示文稿，其中包含每个数据集对应的模板幻灯片副本。每个副本使用相应的数据进行填充。

数据集的顺序决定生成的演示文稿中幻灯片组的顺序。

### 从文件合并数据

以下示例加载模板和 JSON 数据文件，创建一个包含所有数据集幻灯片的单个演示文稿，并保存结果。

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, "products.json"))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

数据也可以从流中读取。流从其当前位置开始读取，邮件合并操作不会关闭该流。

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Stream data = File.OpenRead("products.xml"))
using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, data))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

### 在代码中创建数据源

您可以使用 `MailMergeDataSource` 和 `MailMergeDataSet` 编程方式构建数据源。为每条记录添加一个数据集，并使用 `AddText` 方法定义其字段。

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet laptop = source.AddDataSet();
laptop.AddText("title", "Laptop X1");
laptop.AddText("price", "$999");

IMailMergeDataSet tablet = source.AddDataSet();
tablet.AddText("title", "Tablet S2");
tablet.AddText("price", "$499");

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, source))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

在本示例中，模板幻灯片被重复两次：一次用于笔记本电脑，一次用于平板电脑。占位符使用每个数据集定义的值进行填充。

## 创建多个演示文稿

如果需要为每个数据集生成单独的演示文稿，请使用 `MergeToMultiplePresentations` 方法。

该方法逐个处理数据集，基于模板创建演示文稿，使用当前数据填充，并将生成的演示文稿传递给处理器。

处理器会针对每个数据集被调用一次，顺序与原始数据顺序相同。

### 保存每个演示文稿

以下示例从 CSV 文件读取数据，并将每个生成的演示文稿保存为单独的文件。

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.csv",
        (presentation, args) =>
        {
            presentation.Save(
                "product_" + (args.Index + 1) + ".pptx",
                SaveFormat.Pptx);
        });
}
```

`args.Index` 属性提供当前数据集的零基索引。在示例中，它用于生成从 `product_1.pptx` 开始的顺序文件名。

数据也可以从流中读取：

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Stream data = File.OpenRead("products.xlsx"))
using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        data,
        (presentation, args) =>
        {
            presentation.Save(
                "product_" + (args.Index + 1) + ".pptx",
                SaveFormat.Pptx);
        });
}
```

### 使用数据集值命名文件

处理器接收生成的演示文稿以及用于创建它的数据集信息。您可以使用数据集值构建有意义的文件名。

例如，以下代码使用产品标题保存每个演示文稿：

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.json",
        (presentation, args) =>
        {
            string title = args.DataSet.GetText("title");
            string fileName = title != null
                ? title
                : "product_" + (args.Index + 1);

            presentation.Save(fileName + ".pptx", SaveFormat.Pptx);
        });
}
```

`DataSet` 属性返回用于填充当前演示文稿的数据集。`GetText` 方法检索指定字段的值，如果字段不存在则返回 `null`。

这使您能够使用数据值命名文件、组织输出或在处理器中执行其他处理。

## 处理生成的演示文稿

`MergeToMultiplePresentations` 使用 `MailMergedPresentationHandler` 委托来处理每个生成的演示文稿。

处理器接收两个参数：

- `presentation` — 从模板创建并用当前数据集填充的演示文稿。
- `args` — 有关生成的演示文稿的信息，包括数据集索引和数据集本身。

生成的演示文稿归邮件合并操作所有，处理器返回后立即被释放。因此，您必须在处理器内部保存它或复制所需的数据。不要在处理器返回后保留对该演示文稿的引用，也不要自行释放它。

处理器在调用线程上执行，一次处理一个演示文稿，按数据集的顺序进行。一次只在内存中保留一个生成的演示文稿，这使得该方法适用于在不一次性将所有生成的演示文稿加载到内存中的情况下处理大型数据源。

如果处理器抛出异常，邮件合并操作将停止，异常原样传播给调用者。已处理的演示文稿不受影响，后续数据集将不再处理。

以下示例将生成的演示文稿保存到专用目录：

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

string outputFolder = "output";
Directory.CreateDirectory(outputFolder);

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.json",
        (presentation, args) =>
        {
            string path = Path.Combine(
                outputFolder,
                "product_" + (args.Index + 1) + ".pptx");

            presentation.Save(path, SaveFormat.Pptx);
        });
}
```

## 使用邮件合并数据

`MailMergeDataSource` 类表示有序的数据集集合。它可用于在代码中创建数据、检查数据集数量以及按索引访问单个数据集。

### 获取数据集数量

`Count` 属性返回源中数据集的数量。

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine("Presentations to create: " + source.Count);
```

### 按索引访问数据集

`Item(int)` 属性提供对指定零基索引处的数据集的访问。

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine(source[1].GetText("title"));
```

此示例检索第二个数据集的标题。

### 添加文本字段

`AddText` 方法向数据集添加具名文本字段。该字段的值会替换模板中所有匹配的占位符。

```csharp
MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet dataSet = source.AddDataSet();
dataSet.AddText("title", "Laptop X1");
dataSet.AddText("subtitle", string.Empty);
```

空值会从生成的文本中移除相应的占位符。如果未向数据集添加该字段，占位符保持不变。

### 读取文本字段

`GetText` 方法按名称检索字段的值。字段名不区分大小写。

```csharp
IMailMergeDataSet dataSet = source[0];

string title = dataSet.GetText("title");
string price = dataSet.GetText("price");
```

如果字段不存在或指定的字段名为 `null`，`GetText` 返回 `null`。

## 小结

Aspose.Slides for .NET 中的邮件合并提供了一种便捷的方法，从可重用的模板生成基于数据的演示文稿。

您可以使用它来：

- 使用数据源的值填充演示文稿模板。
- 为多个数据集生成包含重复模板幻灯片的单个演示文稿。
- 为每个数据集创建单独的演示文稿。
- 从 CSV、XLSX、JSON 和 XML 文件或流中读取数据。
- 直接在代码中构建数据源。
- 使用处理器顺序处理并保存生成的演示文稿。

通过将可重用的模板与结构化数据相结合，您可以在保持模板设计和数据处理逻辑分离的前提下，实现大批量演示文稿的自动化创建。

## 常见问题

### 可以在模板中多次使用相同的占位符吗？

可以。每个与字段名匹配的占位符出现位置都会被当前数据集中的相应值替换。

### 字段名是否区分大小写？

不区分。占位符和数据字段名不区分大小写。例如，`{{title}}`、`{{Title}}` 和 `{{TITLE}}` 指的是同一字段。

### 如果数据集中缺少某个字段会怎样？

如果数据集中不包含占位符引用的字段，该占位符将在生成的演示文稿中保持不变。

### 如果字段的值为空会怎样？

空字段值会将占位符替换为空字符串。占位符文本被删除，位置上不保留任何文本。

### 替换时能保留占位符的格式吗？

替换文本继承占位符第一个字符的格式。请在执行合并前对模板中的占位符文本应用所需的格式。

### 邮件合并会替换母版幻灯片或布局幻灯片上的占位符吗？

不会。邮件合并仅替换演示文稿幻灯片（包括形状、组合形状、表格单元格和演讲者备注）中受支持的内容。母版和布局幻灯片上的占位符不会被替换。

### 合并过程中模板演示文稿会被修改吗？

不会。原始模板在合并操作期间不会被修改。您可以重复使用它来生成来自相同或不同数据源的演示文稿。

### 能为每个数据集生成单独的演示文稿吗？

可以。使用 `MergeToMultiplePresentations` 并在处理器中保存每个生成的演示文稿。处理器会按顺序为每个数据集调用一次。

### 能否将所有数据集合并为一个演示文稿？

可以。使用 `MergeToSinglePresentation`。它会生成一个包含每个数据集对应的模板幻灯片副本的单一输出演示文稿，顺序与数据源中的顺序相同。

### 可以在不保存为文件的情况下使用数据源吗？

可以。您可以在代码中创建 `MailMergeDataSource`，添加数据集，并使用 `AddText` 填充字段。当数据已在应用程序中可用时，此方式非常实用。

### 邮件合并会根据文件扩展名检测数据格式吗？

不会。数据格式通过内容检测，因此受支持的数据源不必使用特定的文件扩展名。

### 能读取不支持定位的流吗？

可以。邮件合并支持非定位流。

### 如果数据源为空或不包含数据集会怎样？

数据源必须至少包含一个数据集。请确保在启动合并操作前已包含至少一条记录。

### 如果数据源格式无效会怎样？

如果内容未被识别为受支持的数据格式，将抛出 `NotSupportedException`。如果已被识别但格式错误，则抛出 `InvalidDataException`。异常消息中包含错误位置的相关信息。

### 处理器返回后还能使用生成的演示文稿吗？

传递给 `MergeToMultiplePresentations` 处理器的演示文稿归邮件合并所有，在处理器返回后会被释放。请在处理器内部保存或复制所需内容，且不要在处理器返回后保留或自行释放该演示稿。

### 处理器会并行调用吗？

不会。生成的演示文稿会按顺序、在调用者线程上逐个处理。一次只在内存中保留一个生成的演示文稿。

### 如果处理器内部抛出异常会怎样？

合并操作会停止，异常原样传播给调用者。已经处理的演示文稿不受影响，后续数据集将不再处理。

### 能使用字段值生成输出文件名吗？

可以。处理器通过其参数提供当前数据集。使用 `GetText` 检索字段并构建文件名。请确保这些值在目标环境中是合法的文件名字符。