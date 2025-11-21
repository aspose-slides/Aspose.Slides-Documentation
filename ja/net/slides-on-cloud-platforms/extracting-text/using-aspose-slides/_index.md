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
- "テキスト抽出"
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
description: "Aspose.Slides API を使用して、人気のあるクラウドプラットフォーム上のプレゼンテーションからテキストを抽出し、PPT、PPTX、ODP の検索、分析、エクスポートを自動化します。"
---

# PPT、PPTX、ODP からテキストを抽出 – Slides

Aspose.Slides は **強力でハイレベルな API** を提供し、**PPT、PPTX、ODP** のプレゼンテーション ファイルからテキストを抽出できます。PPTX のみをサポートし、XML の複雑な解析が必要な Open XML SDK とは異なり、Aspose.Slides はテキスト抽出をシンプルにし、抽出したコンテンツをワークフローに統合することに集中できます。

## PresentationFactory.Instance.GetPresentationText による高速テキスト抽出

プレゼンテーションからテキストを抽出するには、**Aspose.Slides API** の静的メソッド `PresentationFactory.Instance.GetPresentationText` を使用します。プレゼンテーション ファイルまたはデータ ストリームで動作するオーバーロードが複数用意されており、**スライド、マスタースライド、レイアウト、ノート、コメント** からテキストを取得します。抽出されたテキストは `IPresentationText` インターフェイスを通じてアクセスできます。

使用例:
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


## GetPresentationText の動作モード

`PresentationFactory` の `GetPresentationText` メソッドは、`TextExtractionArrangingMode` パラメータでテキスト抽出の方式を細かく調整できます。これにより、出力内でのテキストの配置方法を制御できます。

### 利用可能なモード:

- **TextExtractionArrangingMode.Unarranged** – 元のスライド レイアウトを無視し、自由形式でテキストを抽出します。  
- **TextExtractionArrangingMode.Arranged** – 各スライド上の配置順序に従ってテキストの順序を保持します。

使用例:
```csharp
TextExtractionArrangingMode mode = TextExtractionArrangingMode.Arranged;
IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText("presentation.pptx", mode);
ISlideText[] slideTexts = presentationText.SlidesText;

foreach (var slideText in slideTexts)
{
    Console.WriteLine("Slide Text (preserving order): " + slideText.Text);
}
```


## PresentationFactory メソッドの主な利点

- **プレゼンテーション全体を読み込む必要なし**: メモリ消費を最小限に抑え、処理速度を向上させます。  
- **大容量ファイルに最適化**: 大規模なプレゼンテーションでも高速にテキストを抽出できます。  
- **ノートとコメントも取得**: ユーザー注釈を含め、コンテンツの網羅的な取得が可能です。  
- **インデックス作成とコンテンツ分析に最適**: 自動処理やデータ強化を必要とする企業システムに適しています。  
- **Office 非依存**: Microsoft PowerPoint がインストールされていなくても動作し、完全にスタンドアロンです。  
- **マルチフォーマット対応**: **PPT、PPTX、ODP** をシームレスに処理します。  
- **柔軟で強力な API**: 構造化されたテキスト抽出のための多彩なメソッドを提供します。  
- **スライド全体をカバー**: **レイアウト、マスタースライド、標準スライド、背景、スピーカーノート、コメント** からテキストを抽出します。  
- **クロスプラットフォーム互換性**: **Windows、Linux、macOS** およびクラウド環境で動作します。  
- **高性能かつスケーラブル**: **SaaS アプリケーション** や大規模エンタープライズ展開に適しています。

## サポートされているオペレーティングシステム

Aspose.Slides はさまざまなオペレーティング システムで動作します。

- **Windows**（例: Windows 7、8、10、11、およびサーバー エディション）  
- **Linux**（Ubuntu、Debian、Fedora、CentOS など、各種ディストリビューション）  
- **macOS**（10.15 Catalina 以降の最新バージョン）  

## サポートされているプログラミング言語

Aspose.Slides は複数のプラットフォームと連携します。

- **C#** – 主に Aspose.Slides for .NET でサポート。  
- **Java** – Aspose.Slides for Java によるフル機能 API。  
- **C++** – パフォーマンス重視の C++ アプリケーション向けに提供。  
- **Python via .NET** – .NET 相互運用性を利用して Aspose.Slides 機能を組み込めます。  
- **その他の .NET 対応言語** – .NET がサポートする任意の環境でライブラリを利用可能。  

## 結論

Aspose.Slides は PowerPoint と OpenDocument のプレゼンテーション向けに **包括的なテキスト抽出** を実現し、**多様なファイル形式、直感的なテキスト構造化、そして Open XML SDK と比較した簡単な実装** を提供します。**スライドやノートからテンプレート コンテンツまで**、**Aspose.Slides** はテキスト抽出と管理のための高効率・機能豊富なソリューションです。