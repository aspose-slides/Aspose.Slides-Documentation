---
title: "Aspose.Slides を使用した PPT、PPTX、ODP からのテキスト抽出方法"
linktitle: "スライド"
type: docs
weight: 30
url: /ja/net/extracting-text-on-cloud-platforms-using-aspose-slides/
keywords:
- "クラウドプラットフォーム"
- "クラウド統合"
- "テキスト抽出"
- "テキストの抽出"
- "PPT"
- "PPTX"
- "ODP"
- "プレゼンテーション ファイル"
- "クロスプラットフォーム"
- "Office 非依存"
- "ノートとコメント"
- "企業向けインデックス作成"
- "データ強化"
- ".NET"
- "Aspose.Slides"
description: "Aspose.Slides API を使用して、一般的なクラウドプラットフォーム上のプレゼンテーションからテキストを抽出し、PPT、PPTX、ODP の検索、分析、エクスポートを自動化します。"
---

## **はじめに**

Aspose.Slides は **強力でハイレベルな API** を提供し、**PPT、PPTX、ODP** を含むプレゼンテーション ファイルからテキストを抽出できます。PPTX のみをサポートし、複雑な XML パースが必要な Open XML SDK とは異なり、Aspose.Slides はテキスト抽出をシンプルにし、抽出したコンテンツをワークフローに統合することに集中できるようにします。

## **PresentationFactory.Instance.GetPresentationText を使った高速テキスト抽出**

プレゼンテーションからテキストを抽出するには、**Aspose.Slides API** が静的メソッド `PresentationFactory.Instance.GetPresentationText` を提供しています。このメソッドにはプレゼンテーション ファイルまたはデータ ストリームで操作するための複数のオーバーロードがあり、**スライド、マスタースライド、レイアウト、ノート、コメント** からテキストを取得します。抽出されたテキストは `IPresentationText` インターフェイスを通じてアクセスできます。

```csharp
string filePath = "presentation.pptx";
TextExtractionArrangingMode mode = TextExtractionArrangingMode.Unarranged;

IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(filePath, mode);
ISlideText[] slideTexts = presentationText.SlidesText;

foreach (var slideText in slideTexts)
{
    Console.WriteLine("Slide Text: " + slideText.Text);
    Console.WriteLine("Notes Text: " + slideText.NotesText);
    Console.WriteLine("Comments Text: " + slideText.CommentsText);
}
```


## **GetPresentationText の動作モード**

`PresentationFactory` の `GetPresentationText` メソッドは、出力テキストの配置方法を制御する `TextExtractionArrangingMode` パラメータを使用して、テキスト抽出を細かく調整できます。

### **利用可能なモード**

- **TextExtractionArrangingMode.Unarranged** – 元のスライド レイアウトを無視し、自由形式でテキストを抽出します。  
- **TextExtractionArrangingMode.Arranged** – 各スライド上の配置順にテキストの順序を保持します。  

```csharp
TextExtractionArrangingMode mode = TextExtractionArrangingMode.Arranged;
IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText("presentation.pptx", mode);
ISlideText[] slideTexts = presentationText.SlidesText;

foreach (var slideText in slideTexts)
{
    Console.WriteLine("Slide Text (preserving order): " + slideText.Text);
}
```


## **PresentationFactory メソッドの主な利点**

- **プレゼンテーション全体をロードする必要なし**: メモリ使用量を最小化し、処理速度を向上させます。  
- **大容量ファイルに最適化**: 大規模なプレゼンテーションでも効率的に処理し、テキストを迅速に抽出します。  
- **ノートとコメントを取得**: ユーザーの注釈を含め、コンテンツを網羅的にカバーします。  
- **インデックス作成とコンテンツ分析に最適**: 自動処理とデータ強化が必要な企業システムに最適です。  
- **Office 非依存**: Microsoft PowerPoint がインストールされていなくても動作し、完全にスタンドアロンなソリューションを提供します。  
- **マルチフォーマット対応**: **PPT、PPTX、ODP** とシームレスに連携します。  
- **柔軟で強力な API**: 構造化テキスト抽出のための多彩なメソッドを提供します。  
- **スライド全体を網羅**: **レイアウト、マスタースライド、標準スライド、背景、スピーカーノート、コメント** からテキストを抽出します。  
- **クロスプラットフォーム互換性**: **Windows、Linux、macOS** およびクラウド環境で動作します。  
- **高性能・スケーラビリティ**: **SaaS アプリケーション** や大規模エンタープライズ展開に適しています。  

## **サポートされているオペレーティング システム**

Aspose.Slides はさまざまなオペレーティング システムで動作します。

- **Windows**（例: Windows 7、8、10、11、Server エディション）  
- **Linux**（Ubuntu、Debian、Fedora、CentOS など、さまざまなディストリビューション）  
- **macOS**（10.15 Catalina 以降の最新バージョンを含む）  

## **サポートされているプログラミング言語**

Aspose.Slides は複数のプラットフォームとプログラミング言語と統合できます。

- **C#** – 主に Aspose.Slides for .NET でサポートされています。  
- **Java** – Aspose.Slides for Java でフル機能の API が利用可能です。  
- **C++** – パフォーマンスが重要な C++ アプリケーションで Aspose.Slides を活用できます。  
- **Python via .NET** – .NET 相互運用性を通じて Aspose.Slides の機能を組み込めます。  
- **その他の .NET 互換言語** – .NET がサポートする環境であれば、ライブラリを利用できます。  

## **結論**

Aspose.Slides は PowerPoint および OpenDocument プレゼンテーション向けに **包括的なテキスト抽出** を提供し、**多様なファイル形式、直感的なテキスト構造化、シンプルな実装** をサポートします（Open XML SDK と比較して）。**スライドやノートからテンプレートコンテンツまで**、**Aspose.Slides** はプレゼンテーション テキストの抽出と管理のための高効率で機能が豊富なソリューションです。