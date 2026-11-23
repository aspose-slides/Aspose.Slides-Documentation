---
title: Automate Presentation Personalization with Mail Merge
linktitle: Mail Merge
type: docs
weight: 233
url: /net/mail-merge/
keywords:
- Mail Merge
- presentation personalization
- presentation template
- text placeholders
- data source
- CSV
- Excel
- XLSX
- JSON
- XML
- merge data
- generate presentations
- .NET
- C#
- Aspose.Slides
description: "Learn how to use Mail Merge in Aspose.Slides for .NET to populate presentation templates with data and generate personalized PowerPoint presentations from CSV, Excel, JSON, and XML sources."
---

## **Mail Merge in PowerPoint Presentations**

Aspose.Slides for .NET allows you to automatically generate PowerPoint presentations using a template and a data source. Mail Merge fills template placeholders with data and creates either a single presentation containing repeated template slides for every data set or a separate presentation for every data set.

This functionality is useful for generating product catalogs, personalized presentations, reports, certificates, proposals, price lists, and other documents where the presentation structure remains the same while the content varies.

![Mail Merge: before and after](mail-merge-before-after.png)


## **How Mail Merge Works**

Mail Merge uses a PowerPoint presentation as a template and replaces placeholders with values from a data source.

![Mail Merge workflow](mail-merge-workflow.png)

A placeholder is a field name enclosed in double curly braces, such as `{{title}}` or `{{price}}`. Placeholders can be placed in text in shapes, table cells, grouped shapes, and speaker notes.

For example, a template slide may contain the following text:

- `Product: {{title}}`
- `Price: {{price}}`
- `Description: {{description}}`

When the data source contains the following values:

| Field | Value |
|---|---|
| title | Laptop X1 |
| price | $999 |
| description | 14-inch display, 16 GB RAM |

Mail Merge replaces the placeholders with the corresponding values, producing a slide with the actual product information.

Field names are case-insensitive, so `{{title}}` and `{{Title}}` refer to the same field.

The following rules apply when replacing placeholders:

- Placeholders are replaced on slides, including grouped shapes and table cells, and in speaker notes.
- Placeholders on master slides and layout slides are not replaced.
- A placeholder whose field is not present in the data set remains unchanged.
- An empty field value replaces its placeholder with an empty string.
- The inserted text inherits the formatting of the first character of the placeholder.
- Values must not contain placeholder text, because the inserted text may be processed again and replaced by another field.

The original template presentation is not modified during the merge operation and must contain at least one slide.

## **Supported Data Sources**

Mail Merge supports two ways of supplying data:

- Create a data source programmatically using `IMailMergeDataSource`.
- Read data from a CSV, XLSX, JSON, or XML file or stream.

The data format is detected by its content, not by the file extension. Streams that do not support seeking are also supported.

The data source must contain at least one data set. Each data set represents one copy of the template to be filled with its values.

If the data content cannot be recognized as a supported format, `NotSupportedException` is thrown. If the content is recognized but does not comply with the format requirements, `InvalidDataException` is thrown. The exception message contains the location of the error in the data.

### **JSON**

The JSON data source must have a root object containing a `sets` array. Each element of the array represents a data set and must contain a `fields` array. Each field must have a `name` and a `value` string.

The optional `version` property must be `"1.0"`, and the optional `type` property of a field must be `"text"`. Property names are case-sensitive. Unknown properties are ignored.

JSON data is read as UTF-8, or as UTF-16 when the data starts with a byte order mark (BOM).

The following example contains two data sets:

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

The XML data source must have a `template` root element containing the `sets` element. Every `set` element contains `field` elements, and every field must contain `name` and `value` elements.

An empty `value` element is treated as an empty string. Element names are case-sensitive. Unknown elements and comments are ignored. The encoding is determined by the XML declaration. Document type definitions (DTD) are not allowed.

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

CSV data uses semicolons as value separators.

The first row contains field names and ends at the first empty field name. Each subsequent row represents one data set. Data ends at the first empty row.

The following rules apply:

- Missing values at the end of a row are treated as empty strings.
- Values beyond the defined field names are ignored.
- A value containing a semicolon, quotation mark, or line break must be enclosed in quotation marks.
- Quotation marks inside a quoted value must be doubled.
- Data is read as UTF-8, or as UTF-16 when it starts with a byte order mark (BOM).

Example:

```csv
title;price;description
Laptop X1;$999;"14"" display; 16 GB RAM"
Tablet S2;$499;
```

### **XLSX**

XLSX data is read from the first worksheet.

The worksheet follows the same rules as CSV:

- The first row contains field names and ends at the first empty cell.
- Each subsequent row represents one data set.
- Data ends at the first empty row.
- Empty cells are treated as empty strings.
- Numeric values are converted to text using the invariant culture.

## **Creating a Single Presentation**

The `MergeToSinglePresentation` method creates one presentation containing a copy of the template slides for every data set. Each copy is filled with the corresponding data.

The order of data sets determines the order of the slide groups in the resulting presentation.

### **Merging Data from a File**

The following example loads a template and a JSON data file, creates a single presentation containing the slides for all data sets, and saves the result.

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

The data can also be read from a stream. The stream is read starting from its current position and is not closed by the Mail Merge operation.

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

### **Creating a Data Source in Code**

You can build a data source programmatically using `MailMergeDataSource` and `MailMergeDataSet`. Add a data set for every record and define its fields using the `AddText` method.

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

In this example, the template slides are repeated twice: once for the laptop and once for the tablet. The placeholders are filled using the values defined in each data set.

## **Creating Multiple Presentations**

If you need a separate presentation for each data set, use the `MergeToMultiplePresentations` method.

This method processes the data sets one by one, creates a presentation from the template, fills it with the current data, and passes the resulting presentation to a handler.

The handler is invoked once for every data set, in the original data order.

### **Saving Each Presentation**

The following example reads data from a CSV file and saves each generated presentation as a separate file.

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

The `args.Index` property provides the zero-based index of the current data set. In the example, it is used to generate sequential file names starting from `product_1.pptx`.

The data can also be read from a stream:

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

### **Using Data Set Values to Name Files**

The handler receives both the generated presentation and information about the data set used to create it. You can use the data set values to build meaningful file names.

For example, the following code saves each presentation using the product title:

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

The `DataSet` property returns the data set used to fill the current presentation. The `GetText` method retrieves the value of a specified field, or `null` if the field is not present.

This allows you to use data values for naming files, organizing output, or applying additional processing in the handler.

## **Handling Generated Presentations**

`MergeToMultiplePresentations` uses the `MailMergedPresentationHandler` delegate to process each generated presentation.

The handler receives two arguments:

- `presentation` — the presentation created from the template and filled with the current data set.
- `args` — information about the generated presentation, including the data set index and the data set itself.

The generated presentation is owned by the Mail Merge operation and is disposed immediately after the handler returns. Therefore, you must save it or copy any required data inside the handler. Do not retain a reference to it after the handler returns or dispose it manually.

The handler is executed on the calling thread, one presentation at a time, in the order of the data sets. Only one generated presentation is kept in memory at a time, making this approach suitable for processing large data sources without keeping all generated presentations in memory simultaneously.

If the handler throws an exception, the Mail Merge operation stops and the exception is propagated to the caller unchanged. Presentations already processed remain unaffected, and the remaining data sets are not processed.

The following example saves generated presentations to a dedicated directory:

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

## **Working with Mail Merge Data**

The `MailMergeDataSource` class represents an ordered collection of data sets. It can be used to create data in code, inspect the number of data sets, and access individual data sets by index.

### **Getting the Number of Data Sets**

The `Count` property returns the number of data sets in the source.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine("Presentations to create: " + source.Count);
```

### **Accessing a Data Set by Index**

The `Item(int)` property provides access to a data set at the specified zero-based index.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine(source[1].GetText("title"));
```

This example retrieves the title of the second data set.

### **Adding Text Fields**

The `AddText` method adds a named text field to a data set. The field value replaces all matching placeholders in the template.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet dataSet = source.AddDataSet();
dataSet.AddText("title", "Laptop X1");
dataSet.AddText("subtitle", string.Empty);
```

An empty value removes the corresponding placeholder from the resulting text. If the field is not added to the data set, the placeholder remains unchanged.

### **Reading Text Fields**

The `GetText` method retrieves the value of a field by name. Field names are case-insensitive.

```csharp
IMailMergeDataSet dataSet = source[0];

string title = dataSet.GetText("title");
string price = dataSet.GetText("price");
```

If the field does not exist or the specified field name is `null`, `GetText` returns `null`.

## **Summary**

Mail Merge in Aspose.Slides for .NET provides a convenient way to generate data-driven presentations from a reusable template.

You can use it to:

- Populate presentation templates with values from data sources.
- Generate a single presentation containing repeated template slides for multiple data sets.
- Create a separate presentation for every data set.
- Read data from CSV, XLSX, JSON, and XML files or streams.
- Build data sources directly in code.
- Process and save generated presentations sequentially using a handler.

By combining reusable templates with structured data, you can automate the creation of large numbers of presentations while keeping the template design and data processing logic separate.

## **Frequently Asked Questions**

**Can I use the same placeholder multiple times in a template?**

Yes. Every occurrence of a placeholder with a matching field name is replaced with the corresponding value from the current data set.

**Are field names case-sensitive?**

No. Placeholder and data field names are case-insensitive. For example, `{{title}}`, `{{Title}}`, and `{{TITLE}}` refer to the same field.

**What happens if a field is missing from a data set?**

If the data set does not contain a field referenced by a placeholder, that placeholder remains unchanged in the generated presentation.

**What happens if a field has an empty value?**

An empty field value replaces the placeholder with an empty string. The placeholder text is removed, leaving no text in its place.

**Can I preserve the formatting of a placeholder when replacing it?**

The replacement text inherits the formatting of the first character of the placeholder. Apply the desired formatting to the placeholder text in the template before performing the merge.

**Does Mail Merge replace placeholders on master slides or layout slides?**

No. Mail Merge replaces placeholders in supported content on presentation slides, including shapes, grouped shapes, table cells, and speaker notes. Placeholders on master and layout slides are not replaced.

**Is the template presentation modified during the merge?**

No. The original template is not modified by the merge operation. You can reuse it to generate presentations from the same or different data sources.

**Can I generate a separate presentation for each data set?**

Yes. Use `MergeToMultiplePresentations` and save each generated presentation inside the handler. The handler is called sequentially for each data set.

**Can I combine all data sets into one presentation?**

Yes. Use `MergeToSinglePresentation`. It creates a single output presentation containing a copy of the template slides for each data set, in data-source order.

**Can I use a data source without saving it to a file?**

Yes. You can create a `MailMergeDataSource` in code, add data sets, and populate fields using `AddText`. This is useful when your data is already available in your application.

**Does Mail Merge detect the data format from the file extension?**

No. The data format is detected from the content, so a supported data source does not have to use a particular file extension.

**Can I read data from a stream that does not support seeking?**

Yes. Mail Merge supports non-seekable streams.

**What happens if the data source is empty or contains no data sets?**

The data source must contain at least one data set. Ensure it includes at least one record before starting the merge operation.

**What happens if the data source has an invalid format?**

If the content is not recognized as one of the supported data formats, `NotSupportedException` is thrown. If it is recognized but malformed, `InvalidDataException` is thrown. The exception message includes information about the error location.

**Can I use the generated presentation after the handler returns?**

The presentation passed to the `MergeToMultiplePresentations` handler is owned by Mail Merge and is disposed after the handler returns. Save it or copy the content you need inside the handler, and do not retain or dispose that presentation yourself.

**Is the handler called in parallel?**

No. Generated presentations are processed sequentially, on the caller's thread. Only one generated presentation is held in memory at a time by this operation.

**What happens if an exception occurs inside the handler?**

The merge operation stops, and the exception is propagated to the caller unchanged. Presentations already processed are not affected, and subsequent data sets are not processed.

**Can I use field values to generate output file names?**

Yes. The handler provides the current data set through its arguments. Use `GetText` to retrieve fields and build a file name for each generated presentation. Make sure the values are valid for file names in your target environment.
