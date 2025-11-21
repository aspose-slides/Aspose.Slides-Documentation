---
title: .NET で OpenDocument プレゼンテーションを変換
linktitle: OpenDocument を変換
type: docs
weight: 10
url: /ja/net/convert-openoffice-odp/
keywords:
- ODP を変換
- ODP を画像に変換
- ODP を GIF に変換
- ODP を HTML に変換
- ODP を JPG に変換
- ODP を MD に変換
- ODP を PDF に変換
- ODP を PNG に変換
- ODP を PPT に変換
- ODP を PPTX に変換
- ODP を TIFF に変換
- ODP を動画に変換
- ODP を Word に変換
- ODP を XPS に変換
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用すれば、ODP を PDF、HTML、画像形式に簡単に変換できます。高速で正確なプレゼンテーション変換で .NET アプリを強化しましょう。"
---

## **概要**

Aspose.Slides for .NET は、OpenDocument（ODP）プレゼンテーションをさまざまな形式に変換するための堅牢な API を提供します。PowerPoint（PPT および PPTX）ファイルで使用されるのと同様のアプローチに従い、開発者は ODP ドキュメントを HTML、PDF、TIFF、JPG、XPS などの形式に簡単にエクスポートできます。

これらの例は、ODP ドキュメントを他の形式に変換する方法を示しています（ソースを ODP ファイルに変更するだけです）。

- [ODP を HTML に変換](/slides/ja/net/convert-powerpoint-ppt-and-pptx-to-html/)
- [ODP を PDF に変換](/slides/ja/net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [ODP を TIFF に変換](/slides/ja/net/convert-powerpoint-to-tiff/)
- [ODP を SWF に変換](/slides/ja/net/convert-powerpoint-to-swf-flash/)
- [ODP を XPS に変換](/slides/ja/net/convert-powerpoint-to-xps/)
- [ノート付きで ODP を PDF に変換](/slides/ja/net/convert-powerpoint-to-pdf-with-notes/)
- [ノート付きで ODP を TIFF に変換](/slides/ja/net/convert-powerpoint-to-tiff-with-notes/)

たとえば、ODP プレゼンテーションを PDF に変換するには、C# で数行のコードだけが必要です：
```cs
using (Presentation presentation = new Presentation("presentation.odp"))
{
    presentation.Save("presentation.pdf", SaveFormat.Pdf);
}
```


## **さまざまなアプリケーションでの OpenDocument プレゼンテーション**

OpenDocument プレゼンテーション（ODP）ファイルを PowerPoint で開くと、作成元のアプリケーションの元の書式が保持されないことがあります。これは、OpenDocument プレゼンテーションアプリと PowerPoint アプリが提供する機能や描画動作が異なるためです。

主な違いは次のとおりです：

- PowerPoint では、テーブルは通常最後に描画され、ODP スライド上の順序に関係なく他の形状の上に重なることがあります。
- PowerPoint では ODP テーブルの画像塗りつぶしはサポートされていません。
- LibreOffice/OpenOffice Impress では、テキストの垂直回転（270°、スタック）や均等配置はサポートされていません。
- LibreOffice/OpenOffice Impress では、テキストの画像塗りつぶし、グラデーション塗りつぶし、パターン塗りつぶしはサポートされていません。

MS PowerPoint と LibreOffice/OpenOffice Impress はリストの扱いも異なります。PowerPoint で作成された ODP ファイルは LibreOffice/OpenOffice Impress で正しく表示されないことがあり、逆も同様です。

以下の画像は、LibreOffice Impress で作成されたリストの表示例を示しています：

![ODP リスト例](odp-list-example.png)

Aspose.Slides は ODP リストを保存し、LibreOffice/OpenOffice Impress で正しく表示されるようにします。

[OpenDocument 形式と PowerPoint の詳細情報](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **よくある質問**

**変換後に ODP ファイルの書式が変わった場合はどうすればよいですか？**

ODP と PowerPoint は異なるプレゼンテーションモデルを使用しているため、テーブルやカスタムフォント、塗りつぶしスタイルなどの一部の要素がまったく同じようにレンダリングされないことがあります。必要に応じて出力を確認し、コード内でレイアウトや書式を調整することをお勧めします。

**ODP 変換を使用するために OpenOffice または LibreOffice のインストールが必要ですか？**

いいえ、Aspose.Slides for .NET はスタンドアロンのライブラリであり、システムに OpenOffice や LibreOffice をインストールする必要はありません。

**ODP 変換中に出力形式をカスタマイズできますか（例：PDF オプションの設定など）？**

はい、Aspose.Slides は出力をカスタマイズするための豊富なオプションを提供します。たとえば、PDF に保存する際には、[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスを使用して圧縮、画像品質、テキスト描画などを制御できます。

**Aspose.Slides はサーバーサイドまたはクラウドベースの ODP 処理に適していますか？**

はい、確実に対応しています。Aspose.Slides for .NET はデスクトップ環境とサーバー環境の両方で動作するよう設計されており、Azure、AWS、Docker コンテナなどのクラウドベースのプラットフォームでも UI 依存なしで利用できます。