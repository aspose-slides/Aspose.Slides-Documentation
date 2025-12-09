---
title: ".NET で OpenDocument プレゼンテーションを変換する"
linktitle: "OpenDocument の変換"
type: docs
weight: 10
url: /ja/net/convert-openoffice-odp/
keywords:
- ODP を変換
- ODP から画像へ
- ODP から GIF へ
- ODP から HTML へ
- ODP から JPG へ
- ODP から MD へ
- ODP から PDF へ
- ODP から PNG へ
- ODP から PPT へ
- ODP から PPTX へ
- ODP から TIFF へ
- ODP からビデオへ
- ODP から Word へ
- ODP から XPS へ
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用すると、ODP を PDF、HTML、画像形式に簡単に変換できます。高速かつ正確なプレゼンテーション変換で .NET アプリを強化しましょう。"
---

## **概要**

Aspose.Slides for .NET は、OpenDocument（ODP）プレゼンテーションをさまざまな形式に変換するための堅牢な API を提供します。PowerPoint（PPT および PPTX）ファイルで使用されるのと同様のアプローチにより、開発者は ODP ドキュメントを HTML、PDF、TIFF、JPG、XPS などの形式へ簡単にエクスポートできます。

以下の例は、ODP ドキュメントを他の形式に変換する方法を示しています（ソースを ODP ファイルに変更するだけです）:

- [ODP を HTML に変換](/slides/ja/net/convert-powerpoint-ppt-and-pptx-to-html/)
- [ODP を PDF に変換](/slides/ja/net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [ODP を TIFF に変換](/slides/ja/net/convert-powerpoint-to-tiff/)
- [ODP を SWF に変換](/slides/ja/net/convert-powerpoint-to-swf-flash/)
- [ODP を XPS に変換](/slides/ja/net/convert-powerpoint-to-xps/)
- [ODP をノート付き PDF に変換](/slides/ja/net/convert-powerpoint-to-pdf-with-notes/)
- [ODP をノート付き TIFF に変換](/slides/ja/net/convert-powerpoint-to-tiff-with-notes/)

たとえば、ODP プレゼンテーションを PDF に変換するには、C# で数行のコードを書くだけです:
```cs
using (Presentation presentation = new Presentation("presentation.odp"))
{
    presentation.Save("presentation.pdf", SaveFormat.Pdf);
}
```


## **さまざまなアプリケーションでの OpenDocument プレゼンテーション**

OpenDocument プレゼンテーション（ODP）ファイルを PowerPoint で開くと、作成元のアプリケーションでの書式が保持されないことがあります。これは、OpenDocument プレゼンテーション アプリと PowerPoint アプリが提供する機能や描画動作が異なるためです。

主な違いの例は次のとおりです:

- PowerPoint では、テーブルは通常最後に描画され、ODP スライド上の順序に関係なく他のシェイプの上に重なることがあります。
- ODP テーブルの画像塗りは PowerPoint でサポートされていません。
- テキストの垂直回転（270°、スタック）や均等配置は LibreOffice/OpenOffice Impress でサポートされていません。
- テキストの画像塗り、グラデーション塗り、パターン塗りは LibreOffice/OpenOffice Impress でサポートされていません。

MS PowerPoint と LibreOffice/OpenOffice Impress はリストの扱いも異なります。PowerPoint で作成された ODP ファイルは LibreOffice/OpenOffice Impress で正しく表示されないことがあり、その逆も同様です。

以下の画像は、LibreOffice Impress で作成したリストがどのように表示されるかを示しています:

![ODP リスト例](odp-list-example.png)

Aspose.Slides は ODP のリストを保存する際に、LibreOffice/OpenOffice Impress で正しく表示されるように処理します。

[OpenDocument フォーマットと PowerPoint の詳細情報](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **よくある質問**

**変換後に ODP ファイルの書式が変わった場合はどうすればよいですか？**

ODP と PowerPoint は異なるプレゼンテーションモデルを使用しているため、テーブル、カスタムフォント、塗りつぶしスタイルなどの一部要素が完全に同一に描画されないことがあります。出力を確認し、必要に応じてコードでレイアウトや書式を調整することを推奨します。

**ODP 変換を使用するために OpenOffice または LibreOffice をインストールする必要がありますか？**

いいえ、Aspose.Slides for .NET はスタンドアロンのライブラリであり、システムに OpenOffice や LibreOffice をインストールする必要はありません。

**ODP 変換時に出力形式をカスタマイズできますか（例: PDF オプションの設定）？**

はい、Aspose.Slides は出力のカスタマイズに豊富なオプションを提供します。たとえば PDF に保存する際は、[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスを使用して圧縮、画像品質、テキスト描画などを制御できます。

**Aspose.Slides はサーバーサイドやクラウドベースの ODP 処理に適していますか？**

もちろんです。Aspose.Slides for .NET はデスクトップ環境だけでなく、Azure、AWS、Docker コンテナなどのクラウドプラットフォームを含むサーバー環境でも UI 依存なしに動作するよう設計されています。