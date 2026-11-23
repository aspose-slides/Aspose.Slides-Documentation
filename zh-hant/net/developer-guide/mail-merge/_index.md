---
title: 使用郵件合併自動化簡報個人化
linktitle: 郵件合併
type: docs
weight: 233
url: /zh-hant/net/mail-merge/
keywords:
- 郵件合併
- 簡報個人化
- 簡報範本
- 文字佔位元
- 資料來源
- CSV
- Excel
- XLSX
- JSON
- XML
- 合併資料
- 產生簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何在 Aspose.Slides for .NET 中使用郵件合併，以資料填充簡報範本，並從 CSV、Excel、JSON 和 XML 來源產生個人化的 PowerPoint 簡報。"
---
## **PowerPoint 簡報中的郵件合併**

Aspose.Slides for .NET 允許您使用範本和資料來源自動產生 PowerPoint 簡報。郵件合併會將範本佔位元填入資料，並建立一個包含每筆資料集重複範本投影片的單一簡報，或為每筆資料集建立一個獨立的簡報。

此功能適用於產生產品目錄、個人化簡報、報告、證書、提案、價目表以及其他簡報結構相同但內容變化的文件。

![郵件合併：前後比較](mail-merge-before-after.png)


## **郵件合併如何運作**

郵件合併使用 PowerPoint 簡報作為範本，並以資料來源的值取代佔位元。

![郵件合併工作流程](mail-merge-workflow.png)

佔位元是以雙大括號包住的欄位名稱，例如 `{{title}}` 或 `{{price}}`。佔位元可以放在圖形文字、表格儲存格、群組圖形以及投影片備註中。

例如，範本投影片可能包含以下文字：

- `Product: {{title}}`
- `Price: {{price}}`
- `Description: {{description}}`

當資料來源包含以下值時：

| 欄位 | 值 |
|---|---|
| title | Laptop X1 |
| price | $999 |
| description | 14-inch display, 16 GB RAM |

郵件合併會將佔位元替換為相對應的值，產生含實際產品資訊的投影片。

欄位名稱不分大小寫，因此 `{{title}}` 與 `{{Title}}` 代表相同欄位。

取代佔位元時適用以下規則：

- 佔位元會在投影片上（包括群組圖形與表格儲存格）以及投影片備註中被取代。
- 範本的母片投影片與佈局投影片上的佔位元不會被取代。
- 若資料集未包含某個欄位，該佔位元將保持不變。
- 空的欄位值會以空字串取代其佔位元。
- 插入的文字會繼承佔位元第一個字元的格式。
- 值不能包含佔位元文字，因為插入的文字可能再度被處理並被其他欄位取代。

合併操作期間不會修改原始範本簡報，且範本必須至少包含一張投影片。

## **支援的資料來源**

郵件合併支援兩種提供資料的方式：

- 以 `IMailMergeDataSource` 程式化建立資料來源。
- 從 CSV、XLSX、JSON 或 XML 檔案或串流讀取資料。

資料格式依內容偵測，而非檔案副檔名。也支援不支援 Seek 的串流。

資料來源必須至少包含一筆資料集。每筆資料集代表一個要填入其值的範本副本。

如果無法將資料內容辨識為支援的格式，會拋出 `NotSupportedException`。若內容已辨識但不符合格式要求，則拋出 `InvalidDataException`。例外訊息會包含錯誤發生的資料位置。

### **JSON**

JSON 資料來源必須有根物件，且包含 `sets` 陣列。陣列的每個元素代表一筆資料集，必須包含 `fields` 陣列。每個欄位必須有 `name` 與 `value` 兩個字串。

可選的 `version` 屬性必須為 `"1.0"`，欄位的可選 `type` 屬性必須為 `"text"`。屬性名稱區分大小寫。未知屬性會被忽略。

JSON 資料以 UTF-8 讀取，若資料以位元順序標記 (BOM) 開頭則以 UTF-16 讀取。

以下範例包含兩筆資料集：

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

XML 資料來源必須有 `template` 根元素，且包含 `sets` 元素。每個 `set` 元素內含多個 `field` 元素，且每個 `field` 必須包含 `name` 與 `value` 元素。

空的 `value` 元素會被視為空字串。元素名稱區分大小寫。未知元素與註解會被忽略。編碼由 XML 宣告決定。文件類型定義 (DTD) 不被允許。

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

CSV 資料使用分號作為值分隔符。

第一列為欄位名稱，遇到第一個空欄位名稱即結束。之後的每一列代表一筆資料集。資料在第一個空列處結束。

適用的規則：

- 列尾遺失的值視為空字串。
- 超出已定義欄位名稱的值會被忽略。
- 含有分號、引號或換行符的值必須以引號包住。
- 被引號包住的值內的引號必須寫成雙引號。
- 資料以 UTF-8 讀取，若以 BOM 開頭則以 UTF-16 讀取。

範例：

```csv
title;price;description
Laptop X1;$999;"14"" display; 16 GB RAM"
Tablet S2;$499;
```

### **XLSX**

XLSX 資料會從第一個工作表讀取。

工作表遵循與 CSV 相同的規則：

- 第一列為欄位名稱，遇到第一個空儲存格即結束。
- 之後的每一列代表一筆資料集。
- 資料在第一個空列處結束。
- 空儲存格視為空字串。
- 數值會以不變文化 (InvariantCulture) 轉換為文字。

## **建立單一簡報**

`MergeToSinglePresentation` 方法會建立一個簡報，該簡報包含每筆資料集對應的範本投影片副本。每個副本會被填入相對應的資料。

資料集的順序決定最終簡報中投影片群組的順序。

### **從檔案合併資料**

以下範例載入範本與 JSON 資料檔，建立包含所有資料集投影片的單一簡報，並將結果儲存。

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

資料也可以從串流讀取。串流會從其目前位置開始讀取，並且在郵件合併操作結束後不會被關閉。

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

### **在程式碼中建立資料來源**

您可以使用 `MailMergeDataSource` 與 `MailMergeDataSet` 以程式方式建立資料來源。為每筆記錄新增資料集，並使用 `AddText` 方法定義其欄位。

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

在此範例中，範本投影片會重複兩次：一次為筆電，一次為平板。佔位元會以各資料集定義的值填入。

## **建立多個簡報**

如果需要為每筆資料集產生獨立的簡報，請使用 `MergeToMultiplePresentations` 方法。

此方法會逐筆處理資料集，從範本建立簡報、填入目前資料，然後將產生的簡報傳遞給處理器。

處理器會對每筆資料集呼叫一次，且遵循原始資料的順序。

### **儲存每個簡報**

以下範例從 CSV 檔案讀取資料，並將每個產生的簡報儲存為獨立檔案。

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

`args.Index` 屬性提供目前資料集的零基索引。範例中利用它產生從 `product_1.pptx` 起始的連續檔名。

資料也可以從串流讀取：

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

### **使用資料集值命名檔案**

處理器同時取得產生的簡報與用來建立它的資料集資訊。您可以使用資料集的欄位值建立有意義的檔名。

以下程式碼示範以產品標題儲存每個簡報：

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

`DataSet` 屬性回傳用來填入目前簡報的資料集。`GetText` 方法會取得指定欄位的值，若欄位不存在則回傳 `null`。

這讓您可以使用資料值命名檔案、組織輸出，或在處理器內執行其他處理。

## **處理產生的簡報**

`MergeToMultiplePresentations` 會使用 `MailMergedPresentationHandler` 委派來處理每個產生的簡報。

處理器會接受兩個參數：

- `presentation` — 從範本建立且已填入目前資料集的簡報。
- `args` — 關於產生簡報的資訊，包括資料集索引與資料集本身。

產生的簡報由郵件合併操作擁有，並在處理器返回後即被釋放。因此，您必須在處理器內儲存它或複製所需的資料。切勿在處理器返回後保留其參考或自行釋放。

處理器在呼叫執行緒上以一次一個的方式執行，遵循資料集的順序。一次只會在記憶體中保留一個產生的簡報，因而適合在不將所有產生簡報同時載入記憶體的情況下處理大型資料來源。

如果處理器拋出例外，郵件合併操作會停止，例外會原樣傳回給呼叫端。已處理的簡報不受影響，剩餘的資料集將不會被處理。

以下範例將產生的簡報儲存到指定目錄：

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

## **使用郵件合併資料**

`MailMergeDataSource` 類別代表有序的資料集集合。可用於程式碼中建立資料、檢查資料集數量，以及依索引存取個別資料集。

### **取得資料集數量**

`Count` 屬性回傳來源中的資料集數量。

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine("Presentations to create: " + source.Count);
```

### **依索引存取資料集**

`Item(int)` 屬性提供對指定零基索引資料集的存取。

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine(source[1].GetText("title"));
```

此範例取得第二筆資料集的 `title`。

### **新增文字欄位**

`AddText` 方法會為資料集新增具名文字欄位。欄位值會取代範本中所有相符的佔位元。

```csharp
MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet dataSet = source.AddDataSet();
dataSet.AddText("title", "Laptop X1");
dataSet.AddText("subtitle", string.Empty);
```

空值會從結果文字中移除對應的佔位元。若資料集中未加入該欄位，佔位元將保持不變。

### **讀取文字欄位**

`GetText` 方法會依名稱取得欄位的值。欄位名稱不分大小寫。

```csharp
IMailMergeDataSet dataSet = source[0];

string title = dataSet.GetText("title");
string price = dataSet.GetText("price");
```

如果欄位不存在或傳入的欄位名稱為 `null`，`GetText` 會回傳 `null`。

## **摘要**

Aspose.Slides for .NET 的郵件合併提供了一種便利的方式，從可重用的範本產生資料驅動的簡報。

您可以使用它：

- 以資料來源的值填入簡報範本。
- 產生一個包含多筆資料集重複範本投影片的單一簡報。
- 為每筆資料集產生獨立的簡報。
- 從 CSV、XLSX、JSON 與 XML 檔案或串流讀取資料。
- 直接在程式碼中建構資料來源。
- 使用處理器逐一處理並儲存產生的簡報。

透過結合可重用的範本與結構化資料，您可以自動化大量簡報的建立，同時保持範本設計與資料處理邏輯的分離。

## **常見問題**

**可以在同一範本中多次使用相同的佔位元嗎？**

可以。每個與欄位名稱相符的佔位元都會被目前資料集的相應值取代。

**欄位名稱是否區分大小寫？**

不區分。佔位元與資料欄位名稱皆不區分大小寫。例如 `{{title}}`、`{{Title}}` 與 `{{TITLE}}` 皆代表同一欄位。

**如果資料集缺少某個欄位會發生什麼情況？**

若資料集未包含佔位元所參考的欄位，該佔位元會在產生的簡報中保持不變。

**如果欄位的值為空會怎樣？**

空的欄位值會將佔位元替換為空字串，佔位元文字會被移除，該位置不會留下任何文字。

**我可以保留佔位元的格式嗎？**

替換的文字會繼承佔位元第一個字元的格式。請在合併前於範本的佔位元文字上設定所需的格式。

**郵件合併會取代母片或佈局投影片上的佔位元嗎？**

不會。郵件合併只會取代簡報投影片（包括圖形、群組圖形、表格儲存格與備註）中的佔位元，母片與佈局投影片上的佔位元不會被取代。

**合併過程會修改範本簡報嗎？**

不會。原始範本在合併操作期間不會被修改，您可以在不同或相同的資料來源下重複使用它。

**我可以為每筆資料集產生獨立的簡報嗎？**

可以。使用 `MergeToMultiplePresentations`，並在處理器內儲存每個產生的簡報。

**我可以將所有資料集合併成一個簡報嗎？**

可以。使用 `MergeToSinglePresentation`，它會建立一個包含每筆資料集的範本投影片副本的單一輸出簡報，順序依資料來源的順序。

**我可以在不將資料寫入檔案的情況下使用資料來源嗎？**

可以。您可以在程式碼中建立 `MailMergeDataSource`、加入資料集，並使用 `AddText` 填入欄位。這在資料已在應用程式內可用時非常有用。

**郵件合併會依照檔案副檔名偵測資料格式嗎？**

不會。資料格式是從內容偵測，因此支援的資料來源不必使用特定的檔案副檔名。

**我可以從不支援 Seek 的串流讀取資料嗎？**

可以。郵件合併支援非 Seek 的串流。

**如果資料來源為空或不含資料集會怎樣？**

資料來源必須至少包含一筆資料集。請在開始合併操作前確保已加入至少一筆記錄。

**如果資料來源格式無效會怎樣？**

若內容未被辨識為支援的資料格式，會拋出 `NotSupportedException`。若已辨識但格式錯誤，則拋出 `InvalidDataException`。例外訊息會包含錯誤位置的資訊。

**我可以在處理器返回後繼續使用產生的簡報嗎？**

傳給 `MergeToMultiplePresentations` 處理器的簡報由郵件合併擁有，並在處理器返回後即被釋放。請在處理器內儲存或複製所需內容，且不要在處理器返回後保留或自行釋放該簡報。

**處理器會平行呼叫嗎？**

不會。產生的簡報會依序、在呼叫執行緒上逐一處理，一次只會在記憶體中保留一個產生的簡報，適合處理大量資料來源而不會同時佔用過多記憶體。

**如果處理器內拋出例外會怎樣？**

合併操作會停止，例外會原樣傳回給呼叫端。已處理的簡報不受影響，剩餘的資料集不會被處理。

**我可以使用欄位值產生輸出檔名嗎？**

可以。處理器會提供當前資料集的參數。使用 `GetText` 取得欄位值，並以此組成每個產生簡報的檔名。請確保這些值在目標環境中為合法的檔名。