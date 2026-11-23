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
description: "了解如何在 Aspose.Slides for .NET 中使用邮件合并，通过数据填充演示文稿模板，并从 CSV、Excel、JSON 和 XML 源生成个性化的 PowerPoint 演示文稿。"
---
## **PowerPoint 演示文稿中的邮件合并**

Aspose.Slides for .NET 允许您使用模板和数据源自动生成 PowerPoint 演示文稿。邮件合并会用数据填充模板占位符，并创建单个包含每个数据集重复模板幻灯片的演示文稿，或为每个数据集创建单独的演示文稿。

此功能适用于生成产品目录、个性化演示、报告、证书、提案、价目表以及其他演示结构保持不变而内容变化的文档。

![Mail Merge: before and after](mail-merge-before-after.png)


## **邮件合并的工作原理**

邮件合并使用 PowerPoint 演示文稿作为模板，并用来自数据源的值替换占位符。

![Mail Merge workflow](mail-merge-workflow.png)

占位符是用双大括号括起来的字段名，例如 `{{title}}` 或 `{{price}}`。占位符可以放在形状文本、表格单元格、组合形状和演讲备注中。

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

邮件合并会用相应的值替换占位符，生成包含实际产品信息的幻灯片。

字段名不区分大小写，所以 `{{title}}` 和 `{{Title}}` 指向同一字段。

替换占位符时遵循以下规则：

- 在幻灯片上（包括组合形状和表格单元格）以及演讲备注中替换占位符。
- 不会替换母版幻灯片和布局幻灯片上的占位符。
- 数据集中不存在的字段对应的占位符保持不变。
- 空字段值会把占位符替换为空字符串。
- 插入的文本继承占位符第一个字符的格式。
- 值不能包含占位符文本，因为插入的文本可能再次被处理并被另一个字段替换。

合并操作期间不会修改原始模板演示文稿，且模板必须至少包含一张幻灯片。

## **支持的数据源**

邮件合并支持两种提供数据的方式：

- 使用 `IMailMergeDataSource` 编程方式创建数据源。
- 从 CSV、XLSX、JSON 或 XML 文件或流中读取数据。

数据格式通过内容检测，而不是通过文件扩展名。也支持不支持定位的流。

数据源必须至少包含一个数据集。每个数据集代表要用其值填充的模板副本。

如果数据内容无法识别为受支持的格式，将抛出 `NotSupportedException`。如果内容已被识别但不符合格式要求，将抛出 `InvalidDataException`。异常消息包含数据中的错误位置。

### **JSON**

JSON 数据源必须有一个根对象，其中包含 `sets` 数组。数组的每个元素代表一个数据集，并且必须包含 `fields` 数组。每个字段必须有 `name` 和 `value` 字符串。

可选的 `version` 属性必须为 `"1.0"`，字段的可选 `type` 属性必须为 `"text"`。属性名区分大小写。未知属性会被忽略。

JSON 数据以 UTF‑8 读取，若数据以字节顺序标记 (BOM) 开头则以 UTF‑16 读取。

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

### **XML**

XML 数据源必须有一个 `template` 根元素，其中包含 `sets` 元素。每个 `set` 元素包含若干 `field` 元素，并且每个字段必须包含 `name` 和 `value` 元素。

空的 `value` 元素视为空字符串。元素名区分大小写。未知元素和注释会被忽略。编码由 XML 声明决定。不允许使用文档类型定义 (DTD)。

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

### **CSV**

CSV 数据使用分号作为值分隔符。

第一行包含字段名，遇到第一个空字段名即结束。随后的每一行代表一个数据集。数据在第一行空行处结束。

遵循以下规则：

- 行尾缺失的值视为空字符串。
- 超出已定义字段名的值会被忽略。
- 包含分号、引号或换行符的值必须用引号括起。
- 引号内部的引号必须加倍。
- 数据以 UTF‑8 读取，若以 BOM 开头则以 UTF‑16 读取。

示例：

```csv
title;price;description
Laptop X1;$999;"14"" display; 16 GB RAM"
Tablet S2;$499;
```

### **XLSX**

XLSX 数据从第一个工作表读取。

工作表遵循与 CSV 相同的规则：

- 第一行包含字段名，遇到第一个空单元格即结束。
- 随后的每一行代表一个数据集。
- 数据在第一行空行处结束。
- 空单元格视为空字符串。
- 数值会使用不变区域性转换为文本。

## **创建单个演示文稿**

`MergeToSinglePresentation` 方法创建一个演示文稿，其中为每个数据集复制模板幻灯片，并用相应的数据填充每个副本。

数据集的顺序决定了生成演示文稿中幻灯片组的顺序。

### **从文件合并数据**

以下示例加载模板和 JSON 数据文件，创建包含所有数据集幻灯片的单个演示文稿并保存结果。

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

数据也可以从流中读取。流从其当前定位开始读取，邮件合并操作不会关闭该流。

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

### **在代码中创建数据源**

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

在此示例中，模板幻灯片重复两次：一次用于笔记本电脑，一次用于平板电脑。占位符使用每个数据集定义的值进行填充。

## **创建多个演示文稿**

如果需要为每个数据集生成单独的演示文稿，请使用 `MergeToMultiplePresentations` 方法。

该方法逐个处理数据集，从模板创建演示文稿，填充当前数据，然后将生成的演示文稿传递给处理程序。

处理程序会为每个数据集调用一次，顺序与原始数据顺序相同。

### **保存每个演示文稿**

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

`args.Index` 属性提供当前数据集的零基索引。示例中使用它生成从 `product_1.pptx` 开始的顺序文件名。

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

### **使用数据集值命名文件**

处理程序同时收到生成的演示文稿和用于创建它的数据集信息。您可以使用数据集值构建有意义的文件名。

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

这使您能够使用数据值命名文件、组织输出或在处理程序中进行额外处理。

## **处理生成的演示文稿**

`MergeToMultiplePresentations` 使用 `MailMergedPresentationHandler` 委托来处理每个生成的演示文稿。

处理程序接受两个参数：

- `presentation` — 从模板创建并填充当前数据集的演示文稿。
- `args` — 有关生成的演示文稿的信息，包括数据集索引和数据集本身。

生成的演示文稿由邮件合并操作拥有，处理程序返回后会立即释放。因此，必须在处理程序内部保存它或复制所需的数据。不要在处理程序返回后保留对其的引用，也不要自行释放它。

处理程序在调用线程上执行，一次处理一个演示文稿，按数据集顺序进行。一次只在内存中保留一个生成的演示文稿，这使得该方法适用于在不将所有生成的演示文稿同时加载到内存中的情况下处理大数据源。

如果处理程序抛出异常，邮件合并操作会停止，异常会原样传播给调用者。已处理的演示文稿不受影响，后续数据集将不再处理。

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

## **使用邮件合并数据**

`MailMergeDataSource` 类表示有序的数据集集合。它可用于在代码中创建数据、检查数据集数量以及按索引访问单个数据集。

### **获取数据集数量**

`Count` 属性返回源中数据集的数量。

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine("Presentations to create: " + source.Count);
```

### **按索引访问数据集**

`Item(int)` 属性提供对指定零基索引处数据集的访问。

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine(source[1].GetText("title"));
```

此示例检索第二个数据集的标题。

### **添加文本字段**

`AddText` 方法向数据集添加具名文本字段。字段值会替换模板中所有匹配的占位符。

```csharp
MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet dataSet = source.AddDataSet();
dataSet.AddText("title", "Laptop X1");
dataSet.AddText("subtitle", string.Empty);
```

空值会从生成的文本中删除相应的占位符。如果数据集中未添加该字段，占位符保持不变。

### **读取文本字段**

`GetText` 方法按名称检索字段的值。字段名不区分大小写。

```csharp
IMailMergeDataSet dataSet = source[0];

string title = dataSet.GetText("title");
string price = dataSet.GetText("price");
```

如果字段不存在或指定的字段名为 `null`，`GetText` 返回 `null`。

## **摘要**

Aspose.Slides for .NET 中的邮件合并提供了一种便捷方式，使用可重用的模板从结构化数据生成演示文稿。

您可以使用它：

- 用数据源的值填充演示文稿模板。
- 为多个数据集生成包含重复模板幻灯片的单个演示文稿。
- 为每个数据集创建单独的演示文稿。
- 从 CSV、XLSX、JSON 和 XML 文件或流中读取数据。
- 直接在代码中构建数据源。
- 使用处理程序顺序处理并保存生成的演示文稿。

通过将可重用的模板与结构化数据相结合，您可以在保持模板设计和数据处理逻辑分离的同时，实现大量演示文稿的自动化创建。

## **常见问题**

**可以在模板中多次使用同一个占位符吗？**

可以。每个匹配字段名的占位符都会被当前数据集中的相应值替换。

**字段名是否区分大小写？**

不区分。占位符和数据字段名不区分大小写。例如 `{{title}}`、`{{Title}}` 和 `{{TITLE}}` 指向同一字段。

**如果数据集中缺少某个字段会怎样？**

如果数据集不包含占位符引用的字段，该占位符将在生成的演示文稿中保持不变。

**如果字段的值为空会怎样？**

空字段值会将占位符替换为空字符串，占位符文本被删除，位置上不留下任何文字。

**可以在替换时保留占位符的格式吗？**

替换文本会继承占位符第一个字符的格式。请在执行合并前在模板中为占位符文本设置所需的格式。

**邮件合并会在母版幻灯片或布局幻灯片上替换占位符吗？**

不会。邮件合并只在演示文稿幻灯片的支持内容（形状、组合形状、表格单元格和演讲备注）中替换占位符，母版和布局幻灯片上的占位符不会被替换。

**模板演示文稿在合并期间会被修改吗？**

不会。原始模板在合并操作中保持不变，您可以重复使用它来生成来自相同或不同数据源的演示文稿。

**可以为每个数据集生成单独的演示文稿吗？**

可以。使用 `MergeToMultiplePresentations` 并在处理程序中保存每个生成的演示文稿。处理程序会为每个数据集顺序调用一次。

**可以将所有数据集合并到一个演示文稿吗？**

可以。使用 `MergeToSinglePresentation`。它会创建一个包含每个数据集模板幻灯片副本的单一输出演示文稿，顺序按照数据源顺序。

**可以在不保存为文件的情况下使用数据源吗？**

可以。您可以在代码中创建 `MailMergeDataSource`，添加数据集并使用 `AddText` 填充字段。当数据已经在应用程序中可用时，这非常有用。

**邮件合并会根据文件扩展名检测数据格式吗？**

不会。数据格式是通过内容检测的，因此受支持的数据源不必使用特定的文件扩展名。

**可以读取不支持定位的流吗？**

可以。邮件合并支持非定位流。

**如果数据源为空或不包含数据集会怎样？**

数据源必须至少包含一个数据集。请确保在开始合并操作之前至少有一条记录。

**如果数据源格式无效会怎样？**

如果内容未被识别为受支持的数据格式，会抛出 `NotSupportedException`。如果已识别但格式错误，会抛出 `InvalidDataException`。异常消息会包含错误位置的信息。

**可以在处理程序返回后使用生成的演示文稿吗？**

传递给 `MergeToMultiplePresentations` 处理程序的演示文稿由邮件合并拥有，处理程序返回后会被释放。请在处理程序内部保存或复制所需内容，切勿在处理程序返回后保留或自行释放该演示文稿。

**处理程序会并行调用吗？**

不会。生成的演示文稿按顺序在调用线程上处理。一次只在内存中保留一个生成的演示文稿。

**如果处理程序内部抛出异常会怎样？**

合并操作会停止，异常会原样传播给调用者。已处理的演示文稿不受影响，后续数据集将不再处理。

**可以使用字段值生成输出文件名吗？**

可以。处理程序通过其参数提供当前数据集。使用 `GetText` 获取字段并为每个生成的演示文稿构建文件名。请确保这些值在目标环境中是有效的文件名。