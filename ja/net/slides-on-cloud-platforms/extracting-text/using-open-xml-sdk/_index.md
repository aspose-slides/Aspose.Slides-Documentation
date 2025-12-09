---
title: "Open XML SDK を使用して .NET で PPT、PPTX、ODP ファイルからテキストを抽出する方法"
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
- スライドからテキストを抽出
- C#
description: "Open XML SDK を使用して .NET で PPT、PPTX、ODP からテキストを抽出する方法を学びます。XML ベースのアクセス、パフォーマンスに関するヒント、クラウドアプリ向けの変換回避策も紹介します。"
---

# Open XML SDK を使用した PPT、PPTX、ODP からのテキスト抽出

## Open XML SDK

**Open XML SDK** は、プレゼンテーション ファイル（特に Open XML 標準に準拠した **PPTX**）からテキストを抽出するための、非常に構造化され効率的な手段を提供します。基礎となる XML へ直接アクセスできるため、従来の方法と比べてスライド コンテンツの処理がより高速かつ柔軟になります。

## 直接 XML アクセス

- **テキストを直接解析**: Open XML SDK を使用すると、スライドをレンダリングせずに XML パーツからテキストを抽出できます。
- **構造化された要素**: テキストは明確に定義された XML タグに保存されているため、取得と処理がシンプルになります。

### 例: スライド XML コンテンツからテキストを直接抽出
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


## パフォーマンス上の利点

- **高速な抽出**: PowerPoint やその他の高レベル API を開くオーバーヘッドを回避します。
- **低メモリ使用量**: 関連する XML パーツだけにアクセスするため、リソース消費が削減されます。
- **Microsoft PowerPoint 不要**: 追加インストールの要件が不要になります。

### 例: プレゼンテーション全体をロードせずに効率的にテキストを抽出
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


## テキスト要素の特定

### プレゼンテーションからテキストを抽出する際の詳細

プレゼンテーションからテキストを抽出する際は、以下の点を考慮してください。

- **テキストはさまざまなセクションに存在する可能性**: 通常のスライド、マスタースライド、レイアウト、またはスピーカーノート。
- **デフォルトのプレースホルダー**: マスタースライドやレイアウトには、実際のプレゼンテーション コンテンツではないプレースホルダー（例: “Click to edit Master title style”）が含まれることがあります。
- **空または非表示テキストのフィルタリング**: 一部の要素は空であるか、表示を意図していない場合があります。

### テキストを含むタグ

**PPTX** ファイルでは、テキストは通常次の場所に保存されます。

- `<a:p>`（段落）内の `<a:t>` 要素
- `<a:r>` 要素（段落内のテキスト セグメント）

### 例: スライドからすべてのテキスト要素を抽出
```csharp
var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
foreach (var text in textElements)
{
    Console.WriteLine(text.Text);
}
```


## ODP と PPT

### テキストを直接抽出できない理由

- **PPTX** とは異なり、**PPT**（バイナリ形式）および **ODP**（OpenDocument Presentation）は Open XML SDK で **サポートされていません**。
- **PPT** はクローズド バイナリ形式でコンテンツを保存しているため、テキスト抽出が複雑になります。
- **ODP** は **OpenDocument XML** に依存しており、構造が PPTX と異なります。

### 回避策: PPTX への変換

**PPT** または **ODP** からテキストを抽出するには、以下の手順が推奨されます。

1. PowerPoint またはサードパーティ製ツールを使用して **PPT → PPTX** に変換します。
2. LibreOffice または PowerPoint を使用して **ODP → PPTX** に変換します。
3. 変換後の PPTX から Open XML SDK を使って **テキストを抽出** します。

### 例: LibreOffice のコマンドラインで ODP を PPTX に変換
```sh
soffice --headless --convert-to pptx presentation.odp
```


## サポートされているプラットフォームとフレームワーク

- **Windows**: .NET Framework 4.6.1 以降、.NET Core 2.1 以降、.NET 5/6/7。
- **Linux/macOS**: .NET Core 2.1 以降、.NET 5/6/7。
- **クラウド環境**: Microsoft Azure Functions、AWS Lambda（.NET Core）、Docker コンテナ。
- **Office アプリケーションとの互換性**: Microsoft Office のインストールは不要です。
- **サポートされているプログラミング言語**: Open XML SDK は **C#**、**VB.NET**、**F#**、その他 .NET 対応言語で使用可能です。

## 結論

**Open XML SDK** を活用した **PPTX テキスト抽出** は、効率性と明快さの両方を提供します。一方、**PPT と ODP** ではスムーズな処理のために最初に変換ステップが必要です。このアプローチを採用することで、**高いパフォーマンス**、**柔軟性**、そして最新の .NET アプリケーションとの **幅広い互換性** が確保されます。