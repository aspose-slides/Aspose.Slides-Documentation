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
- ODP をビデオに変換
- ODP を Word に変換
- ODP を XPS に変換
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET は、ODP を PDF、HTML、画像フォーマットに簡単に変換できます。高速で正確なプレゼンテーション変換により、.NET アプリケーションを強化しましょう。"
---

[**Aspose.Slides API**](https://products.aspose.com/slides/net/) は、OpenDocument（ODP）プレゼンテーションを多数の形式（HTML、PDF、TIFF、SWF、XPS など）に変換できます。ODP ファイルを他のドキュメント形式に変換するために使用する API は、PowerPoint（PPT および PPTX）変換操作で使用されるものと同じです。

例えば、ODP プレゼンテーションを PDF に変換する必要がある場合は、次のように実行できます:
```cs
using (Presentation presentation = new Presentation("presentation.odp"))
{
    presentation.Save("presentation.pdf", SaveFormat.Pdf);
}
```


## **さまざまなアプリケーションでの OpenDocument プレゼンテーション**

OpenDocument プレゼンテーション（ODP）ファイルを PowerPoint で開くと、作成元アプリケーションでの元の書式が保持されないことがあります。これは、OpenDocument プレゼンテーション アプリと PowerPoint アプリが提供する機能やレンダリングの動作が異なるためです。

主な違いは次のとおりです：

- PowerPoint では、テーブルは通常最後に描画され、ODP スライド上の順序に関係なく他の図形の上に重なることがあります。
- ODP テーブルの画像塗りつぶしは PowerPoint でサポートされていません。
- テキストの垂直回転（270°、スタック）および均等配置は LibreOffice/OpenOffice Impress でサポートされていません。
- テキストの画像塗りつぶし、グラデーション塗りつぶし、パターン塗りつぶしは LibreOffice/OpenOffice Impress でサポートされていません。

MS PowerPoint と LibreOffice/OpenOffice Impress はリストの処理方法も異なります。PowerPoint で作成した ODP ファイルは LibreOffice/OpenOffice Impress で正しく表示されないことがあり、逆も同様です。

以下の画像は、LibreOffice Impress で作成したリストがどのように表示されるかを示しています：

![ODP list example](odp-list-example.png)

Aspose.Slides は ODP リストを保存する際に、LibreOffice/OpenOffice Impress で正しく表示されるようにします。

[OpenDocument 形式と PowerPoint について詳しく読む](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **よくある質問**

**変換後に ODP ファイルの書式が変更された場合はどうすればよいですか？**

ODP と PowerPoint は異なるプレゼンテーション モデルを使用しているため、テーブルやカスタム フォント、塗りつぶしスタイルなどの一部の要素が完全に同じようにレンダリングされないことがあります。出力を確認し、必要に応じてコード内でレイアウトや書式を調整することをお勧めします。

**ODP 変換を使用するために OpenOffice または LibreOffice をインストールする必要がありますか？**

いいえ、Aspose.Slides for .NET はスタンドアロン ライブラリであり、システムに OpenOffice や LibreOffice をインストールする必要はありません。

**ODP 変換中に出力形式をカスタマイズできますか（例: PDF オプションを設定）？**

はい、Aspose.Slides は出力のカスタマイズに豊富なオプションを提供します。たとえば、PDF に保存する際は、[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスを使用して圧縮、画像品質、テキストレンダリングなどを制御できます。

**Aspose.Slides はサーバー側またはクラウドベースの ODP 処理に適していますか？**

もちろんです。Aspose.Slides for .NET はデスクトップ環境だけでなく、Azure、AWS、Docker コンテナなどのクラウドベース プラットフォームを含むサーバー環境でも UI 依存なしに動作するように設計されています。