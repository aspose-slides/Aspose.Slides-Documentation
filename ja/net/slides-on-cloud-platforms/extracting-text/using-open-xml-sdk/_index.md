---
title: ".NET で Open XML SDK を使用して PPT、PPTX、ODP ファイルからテキストを抽出する方法"
linktitle: Open XML SDK
type: docs
weight: 20
url: /ja/net/extracting-text-on-cloud-platforms-using-open-xml-sdk/
keywords:
- クラウドプラットフォーム
- クラウド統合
- Open XML SDK
- PPTX テキスト抽出
- .NET スライド処理
- プレゼンテーションテキスト抽出
- マスタースライド
- スピーカーノート
- スライドからテキスト抽出
- C#
description: "Open XML SDK を使用して .NET で PPT、PPTX、ODP からテキストを抽出する方法を学びます。XML ベースのアクセス、パフォーマンスのヒント、クラウド アプリ向けの変換回避策が含まれます。"
---

## **Open XML SDK**

**Open XML SDK** は、特に Open XML 標準に準拠した **PPTX** からプレゼンテーション ファイルのテキストを抽出するための、非常に構造化され効率的な方法を提供します。基になる XML へ直接アクセスできるため、従来の方法に比べてスライド コンテンツの処理がより高速かつ柔軟になります。

## **Direct XML Access**

- **Analyze Text Directly**: Open XML SDK を使用すると、スライドをレンダリングせずに XML パーツからテキストを抽出できます。
- **Structured Elements**: テキストは明確に定義された XML タグに格納されているため、取得および処理が容易です。

### **Example: Extracting Text Directly from Slide XML Content**
```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    var slidePart = presentation.PresentationPart.SlideParts.FirstOrDefault();
    if (slidePart != null)
    {
        var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
        foreach (var text in textElements)
        {
            Console.WriteLine(text.Text);
        }
    }
}
```


## **Performance Advantages**

- **Faster Extraction**: PowerPoint やその他の高レベル API を開くオーバーヘッドを回避します。
- **Lower Memory Usage**: 関連する XML パーツだけにアクセスするため、リソース消費が削減されます。
- **No Microsoft PowerPoint Needed**: 追加のインストール要件が不要になります。

### **Example: Efficiently Extracting Text Without Loading the Entire Presentation**
```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    foreach (var slidePart in presentation.PresentationPart.SlideParts)
    {
        var texts = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>().Select(t => t.Text);
        Console.WriteLine(string.Join(" ", texts));
    }
}
```


## **Identifying Text Elements**

### **Specifics of Extracting Text from Presentations**

プレゼンテーションからテキストを抽出する際は、以下の点に注意してください。

- **Text May Reside in Different Sections**: 通常スライド、マスタースライド、レイアウト、またはスピーカーノートに存在する可能性があります。
- **Default Placeholders**: マスタースライドやレイアウトには、実際のプレゼンテーション コンテンツではないプレースホルダー（例: “Click to edit Master title style”）が含まれることがあります。
- **Filtering Empty or Hidden Text**: 空の要素や表示されないテキストが含まれることがあります。

### **Tags Containing Text**

**PPTX** ファイルでは、テキストは一般的に以下の要素に格納されます。

- `<a:t>` 要素（`<a:p>`（段落）内）
- `<a:r>` 要素（段落内のテキスト セグメント）

### **Example: Extracting All Text Elements from a Slide**
```csharp
var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
foreach (var text in textElements)
{
    Console.WriteLine(text.Text);
}
```


## **ODP and PPT**

### **Inability to Extract Text Directly**

- **PPTX** と異なり、**PPT**（バイナリ形式）および **ODP**（OpenDocument Presentation）は Open XML SDK では **サポートされていません**。
- **PPT** は閉鎖的なバイナリ形式でコンテンツを保存しているため、テキスト抽出が困難です。
- **ODP** は **OpenDocument XML** に依存しており、構造が PPTX と異なります。

### **Workaround: Converting to PPTX**

**PPT** または **ODP** からテキストを抽出する推奨手順は次のとおりです。

1. **Convert PPT → PPTX** を PowerPoint またはサードパーティ ツールで実行します。  
2. **Convert ODP → PPTX** を LibreOffice または PowerPoint で実行します。  
3. 新しい PPTX から Open XML SDK を使用してテキストを抽出します。

### **Example: Converting ODP to PPTX via LibreOffice Command Line**
```sh
soffice --headless --convert-to pptx presentation.odp
```


## **Supported Platforms and Frameworks**

- **Windows**: .NET Framework 4.6.1 以上、.NET Core 2.1 以降、.NET 5/6/7。  
- **Linux/macOS**: .NET Core 2.1 以降、.NET 5/6/7。  
- **Cloud Environments**: Microsoft Azure Functions、AWS Lambda（.NET Core）、Docker コンテナ。  
- **Compatibility with Office Applications**: Microsoft Office のインストールは不要です。  
- **Supported Programming Languages**: Open XML SDK は **C#**、**VB.NET**、**F#** など、.NET がサポートする言語で使用できます。

## **Conclusion**

**Open XML SDK** を利用した **PPTX テキスト抽出** は、効率と明快さの両方を提供します。一方、**PPT** および **ODP** はスムーズな処理のために最初に変換ステップが必要です。このアプローチを採用することで、**高性能**、**柔軟性**、そして最新の .NET アプリケーションとの **広範な互換性** が確保されます。