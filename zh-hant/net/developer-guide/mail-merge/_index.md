---
title: 自動化簡報個人化與合併列印
linktitle: 合併列印
type: docs
weight: 233
url: /zh-hant/net/mail-merge/
keywords:
- 合併列印
- 簡報個人化
- 簡報範本
- 文字佔位符
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
description: "了解如何在 Aspose.Slides for .NET 中使用合併列印，以資料填充簡報範本並從 CSV、Excel、JSON 與 XML 來源產生個人化的 PowerPoint 簡報。"
---
# PowerPoint 簡報的合併列印

Aspose.Slides for .NET 讓您可以使用範本和資料來源自動產生 PowerPoint 簡報。合併列印會將範本佔位符填入資料，並建立單一簡報（其中包含每個資料集重複的範本投影片）或為每個資料集建立獨立的簡報。

此功能適用於產生產品目錄、個人化簡報、報告、證書、提案書、價目表以及其他簡報結構相同但內容變化的文件。

![合併列印：前後對比](mail-merge-before-after.png)


## 合併列印的運作方式

合併列印使用 PowerPoint 簡報作為範本，並以資料來源的值取代佔位符。

![合併列印工作流程](mail-merge-workflow.png)

佔位符是以雙大括號括住的欄位名稱，例如 `{{title}}` 或 `{{price}}`。佔位符可以放在圖形文字、表格儲存格、群組圖形以及講者備註中。

例如，範本投影片可能包含以下文字：

- `Product: {{title}}`
- `Price: {{price}}`
- `Description: {{description}}`

當資料來源包含以下值時：

| 欄位 | 值 |
|---|---|
| title | Laptop X1 |
| price | $999 |
| description | 14 吋顯示器，16 GB 記憶體 |

合併列印會以相對應的值取代佔位符，產生包含實際產品資訊的投影片。

欄位名稱不區分大小寫，所以 `{{title}}` 與 `{{Title}}` 會指向同一欄位。

取代佔位符時會套用以下規則：

- 佔位符會在投影片上（包括群組圖形與表格儲存格）以及講者備註中取代。
- 主投影片和版面投影片上的佔位符不會被取代。
- 若資料集未包含佔位符所對應的欄位，佔位符會保留不變。
- 空的欄位值會以空字串取代其佔位符。
- 插入的文字會繼承佔位符第一個字元的格式。
- 值不得包含佔位符文字，因為插入的文字可能會再次被處理並被其他欄位取代。

合併操作不會修改原始範本簡報，且範本必須至少有一張投影片。

## 支援的資料來源

合併列印支援兩種提供資料的方式：

- 以 `IMailMergeDataSource` 程式設計方式建立資料來源。
- 從 CSV、XLSX、JSON 或 XML 檔案或串流讀取資料。

資料格式會依內容偵測，而非依檔案副檔名。也支援不支援搜尋（seeking）的串流。

資料來源必須至少包含一個資料集。每個資料集代表一份以其值填入的範本副本。

若資料內容無法辨識為支援的格式，會拋出 `NotSupportedException`。若內容雖被辨識但不符合格式要求，則拋出 `InvalidDataException`。例外訊息會包含錯誤在資料中的位置。

### JSON

JSON 資料來源必須有包含 `sets` 陣列的根物件。陣列中的每個元素代表一個資料集，且必須包含 `fields` 陣列。每個欄位必須有 `name` 與 `value` 兩個字串。

可選的 `version` 屬性必須為 `"1.0"`，欄位的可選 `type` 屬性必須為 `"text"`。屬性名稱區分大小寫。未知屬性會被忽略。

JSON 資料以 UTF-8 讀取，若資料以位元順序標記 (BOM) 開頭，則以 UTF-16 讀取。

以下範例包含兩個資料集：

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

XML 資料來源必須有 `template` 根元素，裡面包含 `sets` 元素。每個 `set` 元素包含 `field` 元素，每個 `field` 必須包含 `name` 與 `value` 元素。

空的 `value` 元素視為空字串。元素名稱區分大小寫。未知元素與註解會被忽略。編碼由 XML 宣告決定。不允許文件類型定義 (DTD)。

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

CSV 資料使用分號作為值分隔符。

第一列為欄位名稱，遇到第一個空欄位名稱即結束。之後的每列代表一個資料集。資料在第一個空列處結束。

適用的規則如下：

- 列尾缺少的值視為空字串。
- 超出已定義欄位名稱的值會被忽略。
- 如值中含有分號、引號或換行，必須以引號括住。
- 引號內的引號必須寫成雙引號。
- 資料以 UTF-8 讀取，若以 BOM 開頭則以 UTF-16 讀取。

範例：

```csv
title;price;description
Laptop X1;$999;"14"" display; 16 GB RAM"
Tablet S2;$499;
```

### XLSX

XLSX 資料從第一個工作表讀取。

工作表遵循與 CSV 相同的規則：

- 第一列為欄位名稱，遇到第一個空儲存格即結束。
- 之後的每列代表一個資料集。
- 資料在第一個空列處結束。
- 空儲存格視為空字串。
- 數值會使用不變文化 (InvariantCulture) 轉換為文字。

## 建立單一簡報

`MergeToSinglePresentation` 方法會建立一個簡報，內含每個資料集的範本投影片副本。每個副本會以對應的資料填入。

資料集的順序決定最終簡報中投影片群組的順序。

### 從檔案合併資料

以下範例載入範本與 JSON 資料檔，建立包含所有資料集投影片的單一簡報，並儲存結果。

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

資料也可以從串流讀取。串流會從目前位置開始讀取，且不會在合併列印操作中被關閉。

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

### 在程式碼中建立資料來源

您可以使用 `MailMergeDataSource` 與 `MailMergeDataSet` 以程式方式建立資料來源。為每筆記錄加入資料集，並使用 `AddText` 方法定義其欄位。

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

在此範例中，範本投影片會重複兩次：一次為筆記本電腦，一次為平板電腦。佔位符會以各自資料集定義的值填入。

## 建立多個簡報

若需要為每個資料集產生獨立的簡報，請使用 `MergeToMultiplePresentations` 方法。

此方法會逐筆處理資料集，從範本建立簡報、以目前資料填入，並將產生的簡報傳遞給處理程序。

處理程序會針對每個資料集依原始資料順序呼叫一次。

### 儲存每個簡報

以下範例從 CSV 檔案讀取資料，並將每個產生的簡報儲存為個別檔案。

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

`args.Index` 屬性提供目前資料集的零基索引。範例中使用它產生從 `product_1.pptx` 起的連續檔名。

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

### 使用資料集值為檔案命名

處理程序同時取得產生的簡報與用來建立它的資料集資訊。您可以使用資料集的值建立有意義的檔名。

以下程式碼示範以產品標題為檔名儲存每個簡報：

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

`DataSet` 屬性返回用於填充目前簡報的資料集。`GetText` 方法可取得指定欄位的值，若欄位不存在則返回 `null`。

這讓您能夠以資料值命名檔案、組織輸出，或在處理程序中執行其他處理。

## 處理產生的簡報

`MergeToMultiplePresentations` 透過 `MailMergedPresentationHandler` 委派處理每個產生的簡報。

處理程序會收到兩個參數：

- `presentation` — 由範本建立並以目前資料集填入的簡報。
- `args` — 包含產生的簡報資訊，例如資料集索引與資料集本身。

產生的簡報屬於合併列印操作所有，處理程序返回後會立即釋放。因此，必須在處理程序內自行儲存或複製所需資料。切勿在處理程序返回後保留其參考，亦不要自行釋放它。

處理程序在呼叫執行緒上逐一執行，每次只保留一個產生的簡報於記憶體中，適合在不將所有簡報同時載入記憶體的情況下處理大量資料來源。

若處理程序拋出例外，合併列印操作會停止，例外會原樣傳回給呼叫端。已處理的簡報不受影響，剩餘的資料集將不會被處理。

以下範例將產生的簡報儲存至特定目錄：

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

## 使用合併列印資料

`MailMergeDataSource` 類別代表一個有序的資料集集合。可用於程式碼中建立資料、檢查資料集數量，或依索引存取個別資料集。

### 取得資料集數量

`Count` 屬性返回來源中的資料集數量。

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine("Presentations to create: " + source.Count);
```

### 依索引存取資料集

`Item(int)` 屬性提供對指定零基索引之資料集的存取。

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine(source[1].GetText("title"));
```

此範例取得第二筆資料集的標題。

### 新增文字欄位

`AddText` 方法會為資料集新增具名文字欄位。欄位值會取代範本中所有相符的佔位符。

```csharp
MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet dataSet = source.AddDataSet();
dataSet.AddText("title", "Laptop X1");
dataSet.AddText("subtitle", string.Empty);
```

空值會從結果文字中移除相應的佔位符。若資料集中未加入該欄位，佔位符會保持不變。

### 讀取文字欄位

`GetText` 方法依名稱取得欄位的值。欄位名稱不區分大小寫。

```csharp
IMailMergeDataSet dataSet = source[0];

string title = dataSet.GetText("title");
string price = dataSet.GetText("price");
```

若欄位不存在或指定的欄位名稱為 `null`，`GetText` 會傳回 `null`。

## 小結

Aspose.Slides for .NET 的合併列印提供了一種便利的方式，從可重複使用的範本產生以資料驅動的簡報。

您可以使用它來：

- 以資料來源的值填充簡報範本。
- 產生包含多筆資料集重複範本投影片的單一簡報。
- 為每筆資料集建立獨立的簡報。
- 從 CSV、XLSX、JSON 與 XML 檔案或串流讀取資料。
- 直接在程式碼中建立資料來源。
- 以處理程序逐一處理並儲存產生的簡報。

透過結合可重用的範本與結構化資料，您可以在保持範本設計與資料處理邏輯分離的前提下，自動化大量簡報的產生。

## 常見問題

### 可以在範本中多次使用相同的佔位符嗎？

可以。所有與欄位名稱相符的佔位符都會被目前資料集中的對應值取代。

### 欄位名稱是否區分大小寫？

不會。佔位符與資料欄位名稱不區分大小寫。例如 `{{title}}`、`{{Title}}`、`{{TITLE}}` 都會指向相同的欄位。

### 若資料集中缺少某個欄位會發生什麼情況？

如果資料集未包含佔位符所參照的欄位，該佔位符在產生的簡報中會保持不變。

### 若欄位的值為空會發生什麼？

空的欄位值會將佔位符以空字串取代，佔位符文字會被移除，該位置不會留下任何文字。

### 替換佔位符時能保留原有格式嗎？

替換後的文字會繼承佔位符第一個字元的格式。請在合併之前於範本中為佔位符文字設定所需的格式。

### 合併列印會取代母版投影片或版面投影片上的佔位符嗎？

不會。合併列印只會取代簡報投影片（包括圖形、群組圖形、表格儲存格與講者備註）中支援的內容。母版與版面投影片上的佔位符不會被取代。

### 合併過程會修改範本簡報嗎？

不會。合併操作不會修改原始範本，您可以重複使用同一範本產生不同或相同資料來源的簡報。

### 可以為每個資料集產生獨立的簡報嗎？

可以。使用 `MergeToMultiplePresentations`，並在處理程序中儲存每個產生的簡報。

### 能否將所有資料集合併成一個簡報？

可以。使用 `MergeToSinglePresentation`，它會建立單一輸出簡報，內含每個資料集的範本投影片副本，順序依資料來源排列。

### 可以不將資料來源寫入檔案而直接使用嗎？

可以。您可以在程式碼中建立 `MailMergeDataSource`，加入資料集並以 `AddText` 填入欄位，適用於資料已在應用程式中可得的情況。

### 合併列印會依檔案副檔名偵測資料格式嗎？

不會。資料格式是依內容偵測的，只要是支援的資料來源即可，不必使用特定的副檔名。

### 能從不支援搜尋的串流讀取資料嗎？

可以。合併列印支援非可搜尋 (non‑seekable) 的串流。

### 若資料來源為空或沒有資料集會怎樣？

資料來源必須至少包含一個資料集。請確保在開始合併前已加入至少一筆記錄。

### 若資料來源格式不正確會怎樣？

若內容未被辨識為支援的資料格式，會拋出 `NotSupportedException`。若已辨識但格式不合，會拋出 `InvalidDataException`，例外訊息會包含錯誤位置的資訊。

### 合併列印完成後，我可以在處理程序返回後繼續使用簡報嗎？

傳遞給 `MergeToMultiplePresentations` 處理程序的簡報屬於合併列印所有，處理程序返回後會被釋放。必須在處理程序內自行儲存或複製所需內容，且不要自行保留或釋放該簡報。

### 處理程序會平行呼叫嗎？

不會。產生的簡報會依序、在呼叫執行緒上逐一處理，一次只在記憶體中保留一個簡報，適合處理大型資料來源而不會一次載入所有簡報。

### 若處理程序內拋出例外會發生什麼？

合併列印會停止，例外會原樣傳回給呼叫端。已處理的簡報不受影響，剩餘資料集將不會被處理。

### 可以使用欄位值產生輸出檔名嗎？

可以。處理程序的參數會提供目前的資料集，您可以使用 `GetText` 取得欄位值並組成檔名。請確保這些值在目標環境中是合法的檔名字元。