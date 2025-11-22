---
title: C# で OpenDocument プレゼンテーション (ODP) を変換
linktitle: OpenDocument を変換
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
description: "Aspose.Slides for .NET を使用すると、ODP を PDF、HTML、画像形式に簡単に変換できます。高速で正確なプレゼンテーション変換により、.NET アプリを強化しましょう。"
---

## **概要**

Aspose.Slides for .NET は、OpenDocument (ODP) プレゼンテーションをさまざまな形式に変換するための堅牢な API を提供します。PowerPoint (PPT および PPTX) ファイルで使用されるのと同様のアプローチに従い、開発者は ODP ドキュメントを HTML、PDF、TIFF、JPG、XPS などの形式に簡単にエクスポートできます。

以下の例は、ODP ドキュメントを他の形式に変換する方法を示しています（ソースを ODP ファイルに変更するだけです）。

- [ODP を HTML に変換](/slides/ja/net/convert-powerpoint-ppt-and-pptx-to-html/)
- [ODP を PDF に変換](/slides/ja/net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [ODP を TIFF に変換](/slides/ja/net/convert-powerpoint-to-tiff/)
- [ODP を SWF に変換](/slides/ja/net/convert-powerpoint-to-swf-flash/)
- [ODP を XPS に変換](/slides/ja/net/convert-powerpoint-to-xps/)
- [ノート付きで ODP を PDF に変換](/slides/ja/net/convert-powerpoint-to-pdf-with-notes/)
- [ノート付きで ODP を TIFF に変換](/slides/ja/net/convert-powerpoint-to-tiff-with-notes/)

たとえば、ODP プレゼンテーションを PDF に変換するには、C# で数行のコードを書くだけです。
```cs
using (Presentation presentation = new Presentation("presentation.odp"))
{
    presentation.Save("presentation.pdf", SaveFormat.Pdf);
}
```


## **さまざまなアプリケーションでの OpenDocument プレゼンテーション**

OpenDocument プレゼンテーション (ODP) ファイルを PowerPoint で開くと、作成したアプリケーションの元の書式が保持されないことがあります。これは、OpenDocument プレゼンテーション アプリと PowerPoint アプリが提供する機能やレンダリング動作が異なるためです。

違いの例を以下に示します。

- PowerPoint では、テーブルは通常最後にレンダリングされ、ODP スライド上の順序に関係なく他の図形の上に重なることがあります。
- PowerPoint では ODP テーブルの画像塗りつぶしはサポートされていません。
- LibreOffice/OpenOffice Impress では、テキストの垂直回転（270°、スタック）や均等配置はサポートされていません。
- LibreOffice/OpenOffice Impress では、テキストの画像塗りつぶし、グラデーション塗りつぶし、パターン塗りつぶしはサポートされていません。

MS PowerPoint と LibreOffice/OpenOffice Impress はリストの処理方法も異なります。PowerPoint で作成した ODP ファイルは LibreOffice/OpenOffice Impress で正しく表示されないことがあり、逆も同様です。

以下の画像は、LibreOffice Impressで作成したリストがどのように表示されるかを示しています。
![ODP リスト例](odp-list-example.png)

Aspose.Slides は ODP リストを保存する際に、LibreOffice/OpenOffice Impress で正しく表示されるように処理します。

[OpenDocument フォーマットと PowerPoint について詳しく知る](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **よくある質問**

**変換後に ODP ファイルの書式が変わってしまったらどうすればよいですか？**

ODP と PowerPoint は異なるプレゼンテーションモデルを使用しており、テーブル、カスタムフォント、塗りつぶしスタイルなどの一部要素は完全に同じようにレンダリングされない場合があります。必要に応じて出力を確認し、コードでレイアウトや書式を調整することをおすすめします。

**ODP 変換を使用するために OpenOffice または LibreOffice をインストールする必要がありますか？**

いいえ、Aspose.Slides for .NET はスタンドアロンのライブラリであり、システムに OpenOffice や LibreOffice をインストールする必要はありません。

**ODP 変換中に出力形式をカスタマイズできますか（例: PDF オプションを設定）？**

はい、Aspose.Slides では出力をカスタマイズするための豊富なオプションが提供されています。たとえば、PDF に保存する際は、[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスを使用して圧縮、画像品質、テキストのレンダリングなどを制御できます。

**Aspose.Slides はサーバーサイドまたはクラウドベースの ODP 処理に適していますか？**

はい。Aspose.Slides for .NET はデスクトップとサーバーの両環境で動作するよう設計されており、Azure、AWS、Docker コンテナなどのクラウドプラットフォームでも UI 依存なしで使用できます。