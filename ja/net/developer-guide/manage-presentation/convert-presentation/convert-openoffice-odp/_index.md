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
description: "Aspose.Slides for .NET を使用すると、ODP を PDF、HTML、画像形式に簡単に変換できます。高速かつ正確なプレゼンテーション変換で .NET アプリを強化しましょう。"
---

## **概要**

Aspose.Slides for .NET は、OpenDocument（ODP）プレゼンテーションをさまざまな形式に変換するための堅牢な API を提供します。PowerPoint（PPT および PPTX）ファイルで使用されるのと同様のアプローチにより、開発者は ODP ドキュメントを HTML、PDF、TIFF、JPG、XPS などの形式に簡単にエクスポートできます。

以下の例は、ODP ドキュメントを他の形式に変換する方法を示しています（ソースを ODP ファイルに変更するだけです）:

- [Convert ODP to HTML](/slides/ja/net/convert-powerpoint-ppt-and-pptx-to-html/)
- [Convert ODP to PDF](/slides/ja/net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [Convert ODP to TIFF](/slides/ja/net/convert-powerpoint-to-tiff/)
- [Convert ODP to SWF](/slides/ja/net/convert-powerpoint-to-swf-flash/)
- [Convert ODP to XPS](/slides/ja/net/convert-powerpoint-to-xps/)
- [Convert ODP to PDF with Notes](/slides/ja/net/convert-powerpoint-to-pdf-with-notes/)
- [Convert ODP to TIFF with Notes](/slides/ja/net/convert-powerpoint-to-tiff-with-notes/)

たとえば、ODP プレゼンテーションを PDF に変換するには、C# で数行のコードを書くだけです:
```cs
using (Presentation presentation = new Presentation("presentation.odp"))
{
    presentation.Save("presentation.pdf", SaveFormat.Pdf);
}
```


## **さまざまなアプリケーションでの OpenDocument プレゼンテーション**

OpenDocument プレゼンテーション（ODP）ファイルを PowerPoint で開くと、作成元のアプリケーションでの元の書式設定が保持されないことがあります。これは、OpenDocument プレゼンテーション アプリと PowerPoint アプリが異なる機能と描画動作を提供しているためです。

主な違いは次のとおりです:

- PowerPoint では、テーブルは通常最後に描画され、ODP スライド上の順序に関係なく他のシェイプの上に重なることがあります。
- ODP テーブルの画像塗りつぶしは PowerPoint でサポートされていません。
- テキストの垂直回転（270°、スタック）や均等配置は LibreOffice/OpenOffice Impress でサポートされていません。
- テキストの画像塗りつぶし、グラデーション塗りつぶし、パターン塗りつぶしは LibreOffice/OpenOffice Impress でサポートされていません。

MS PowerPoint と LibreOffice/OpenOffice Impress はリストの扱いも異なります。PowerPoint で作成された ODP ファイルは LibreOffice/OpenOffice Impress で正しく表示されないことがあり、逆も同様です。

以下の画像は、LibreOffice Impress で作成したリストの表示例です:

![ODP list example](odp-list-example.png)

Aspose.Slides は ODP リストを LibreOffice/OpenOffice Impress で正しく表示できるように保存します。

[OpenDocument 形式と PowerPoint について詳しく見る](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **FAQ**

**変換後に ODP ファイルの書式が変わってしまった場合はどうすればよいですか？**

ODP と PowerPoint は異なるプレゼンテーション モデルを使用しているため、テーブルやカスタム フォント、塗りつぶしスタイルなどの要素が完全に同じように描画されないことがあります。出力を確認し、必要に応じてコード内でレイアウトや書式を調整することを推奨します。

**ODP 変換を使用するのに OpenOffice または LibreOffice をインストールする必要がありますか？**

いいえ、Aspose.Slides for .NET はスタンドアロン ライブラリであり、システムに OpenOffice や LibreOffice をインストールする必要はありません。

**ODP 変換時に出力形式をカスタマイズできますか（例: PDF のオプションを設定）？**

はい、Aspose.Slides は出力をカスタマイズするための豊富なオプションを提供します。たとえば、PDF に保存する際は、[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスを使用して圧縮、画像品質、テキスト描画などを制御できます。

**Aspose.Slides はサーバー側またはクラウドベースの ODP 処理に適していますか？**

もちろんです。Aspose.Slides for .NET はデスクトップ環境だけでなく、Azure、AWS、Docker コンテナなどのクラウドベースのプラットフォームを含むサーバー環境でも動作するよう設計されており、UI 依存はありません。