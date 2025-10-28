---
title: 機能概要
type: docs
weight: 20
url: /ja/python-net/features-overview/
keywords:
- 機能
- サポート対象プラットフォーム
- ファイル形式
- 変換
- レンダリング
- 印刷
- 書式設定
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET のご紹介: PowerPoint と OpenDocument のプレゼンテーションを効率的に作成、編集、Automation、変換できる強力な API。"
---

## **サポート対象プラットフォーム**
Aspose.Slides for Python via .NET は、Windows x64 または x86、そして Python 3.5 以降がインストールされた幅広い Linux ディストリビューション上で使用できます。対象の Linux プラットフォームには追加の要件があります。
- GCC-6 ランタイムライブラリ（またはそれ以降）
- .NET Core Runtime の依存関係。 .NET Core Runtime 自体のインストールは不要です。
- Python 3.5‑3.7 の場合: `pymalloc` ビルドの Python が必要です。`--with-pymalloc` ビルドオプションはデフォルトで有効です。通常、`pymalloc` ビルドの Python はファイル名に `m` サフィックスが付いています。
- `libpython` 共有 Python ライブラリ。`--enable-shared` ビルドオプションはデフォルトで無効になっており、一部の Python ディストリビューションには `libpython` 共有ライブラリが含まれていません。Linux のいくつかのプラットフォームでは、パッケージマネージャで `libpython` 共有ライブラリをインストールできます（例: `sudo apt-get install libpython3.7`）。一般的な問題は、`libpython` ライブラリが標準の共有ライブラリディレクトリとは別の場所にインストールされることです。Python をコンパイルする際にビルドオプションで代替ライブラリパスを設定するか、システム標準の共有ライブラリディレクトリにシンボリックリンクを作成することで解決できます。通常、Python 3.5‑3.7 の `libpython` 共有ライブラリ名は `libpythonX.Ym.so.1.0`、Python 3.8 以降は `libpythonX.Y.so.1.0`（例: `libpython3.7m.so.1.0`、`libpython3.9.so.1.0`）です。

さらに多くのプラットフォームをサポートする必要がある場合は、Aspose.Slides for .NET または Aspose.Slides for Java という「ツインブラザー」製品をご覧ください。

## **ファイル形式と変換**
Aspose.Slides for Python via .NET は、ほとんどの PowerPoint ドキュメント形式をサポートします。また、組織が広く使用し交換している一般的な形式へエクスポートすることも可能です。以下の詳細をご確認ください。

|機能|説明|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/ja/python-net/ppt-vs-pptx/)|Aspose.Slides for Python via .NET はこのプレゼンテーション ドキュメント形式の最速処理を提供します。|
|[PPT to PPTX conversion](/slides/ja/python-net/convert-ppt-to-pptx/)|Aspose.Slides for Python via .NET は PPT から PPTX への変換をサポートします。|
|[Portable Document Format (PDF)](/slides/ja/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|単一のメソッドで、サポート対象すべてのファイル形式を Adobe Portable Document Format (PDF) にエクスポートできます。|
|[XML Parser Specification (XPS)](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)|単一のメソッドで、サポート対象すべてのファイル形式を XML Parser Specification (XPS) にエクスポートできます。|
|[Tagged Image File Format (TIFF)](/slides/ja/python-net/convert-powerpoint-to-tiff/)|サポート対象のプレゼンテーション ファイル形式をすべて Tagged Image File Format (TIFF) にエクスポートできます。|
|[PPTX To HTML Conversion](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)|Aspose.Slides for Python via .NET は PresentationEx を HTML 形式に変換することをサポートします。|

## **レンダリングと印刷**
Aspose.Slides for Python via .NET は、プレゼンテーション ドキュメント内のスライドを高忠実度でさまざまな画像形式にレンダリングできます。以下の詳細をご確認ください。

|機能|説明|
| :- | :- |
|.NET Supported Image Formats|Aspose.Slides for Python via .NET を使用すると、TIFF、PNG、BMP、JPEG、GIF、メタファイルなど、.NET がサポートするすべての画像形式でプレゼンテーション スライドおよびスライド上の画像をレンダリングできます。|
|SVG Format|Aspose.Slides for Python via .NET は、スライドを Scalable Vector Graphics (SVG) 形式にエクスポートする組み込みメソッドも提供します。|
|Presentation Printing|最新バージョンの Aspose.Slides for Python via .NET では、さまざまなオプションを備えた組み込み印刷メソッドが提供されています。|

## **コンテンツ機能**
Aspose.Slides for Python via .NET を使用すると、プレゼンテーション ドキュメント内のほぼすべての項目やコンテンツにアクセス、変更、作成できます。以下の詳細をご確認ください。

|機能|説明|
| :- | :- |
|Master Slides|マスタ スライドは通常のスライドのレイアウトを定義します。Aspose.Slides for Python via .NET ではマスタ スライドにアクセスし、変更できます。|
|Normal Slides|Aspose.Slides for Python via .NET を使用して、さまざまなタイプの新しいスライドを作成でき、既存のスライドにアクセスして変更することもできます。|
|Cloning / Copying Slides|Aspose.Slides for Python via .NET が提供する組み込みメソッドにより、プレゼンテーション内の既存スライドをクローンまたはコピーできます。クローンやコピーしたスライドは別のプレゼンテーションにも使用可能です。スライドはマスタ スライドからレイアウトを継承するため、クローン時にマスタも自動的にコピーされます。|
|Managing Slides sections|プレゼンテーション内でスライドを異なるセクションに整理するメソッド。|
|Place Holders and Text Holders|スライド内のプレースホルダーとテキストホルダーにアクセスできます。また、適切なメソッドを使用してテキストホルダー付きのスライドをゼロから作成できます。|
|Header and Footers|Aspose.Slides for Python via .NET はスライドのヘッダー/フッターの操作を容易にします。|
|Notes in Slides|スライドに関連付けられたノートにアクセス・変更でき、また新しいノートを追加できます。|
|Finding a Shape|シェイプに割り当てられた代替テキストを使用して、スライド内の特定のシェイプを検索できます。|
|Backgrounds|マスタまたは通常スライドに関連付けられた背景を操作できます。|
|Text Boxes|テキストボックスはゼロから作成でき、既存のテキストボックスにアクセスして、元の書式を保持したままテキストを変更できます。|
|Rectangle Shapes|Aspose.Slides for Python via .NET で矩形シェイプを作成または変更できます。|
|Poly Line Shapes|Aspose.Slides for Python via .NET でポリラインシェイプを作成または変更できます。|
|Ellipse Shapes|Aspose.Slides for Python via .NET で楕円シェイプを作成または変更できます。|
|Group Shapes|Aspose.Slides for Python via .NET はグループ シェイプをサポートします。|
|Auto Shapes|Aspose.Slides for Python via .NET はオート シェイプをサポートします。|
|SmartArt|Aspose.Slides for Python via .NET は MS PowerPoint の SmartArt シェイプをサポートします。|
|Charts|Aspose.Slides for Python via .NET は PowerPoint の MSO チャートをサポートします。|
|Shapes Serialization|Aspose.Slides for Python via .NET は多数のシェイプをサポートしていますが、サポート外のシェイプはシリアライズ機能を使って既存スライドからシェイプをシリアライズし、必要に応じて再利用できます。|
|Picture Frames|Aspose.Slides for Python via .NET でピクチャ フレーム内の画像を管理できます。|
|Audio Frames|Aspose.Slides for Python via .NET でオーディオ フレームに音声ファイルをリンクまたは埋め込めます。|
|Video Frames|ビデオ フレーム内の動画ファイルを扱えます。Aspose.Slides for Python via .NET はリンク動画と埋め込み動画の両方をサポートします。|
|OLE Frame|Aspose.Slides for Python via .NET で OLE フレーム内の OLE オブジェクトを管理できます。|
|Tables|Aspose.Slides for Python via .NET はスライド内のテーブルをサポートします。|
|ActiveX Controls|ActiveX コントロールのサポート。|
|VBA Macros|プレゼンテーション内の VBA マクロの管理をサポートします。|
|Text Frame|任意のシェイプに関連付けられたテキスト フレームを通じてテキストにアクセスできます。|
|Text Scanning|組み込みスキャン メソッドにより、プレゼンテーションまたはスライド単位でテキストをスキャンできます。|
|Animations|シェイプにアニメーションを適用できます。|
|Slide Shows|Aspose.Slides for Python via .NET はスライドショーとスライド遷移をサポートします。|

## **書式設定機能**
Aspose.Slides for Python via .NET を使用すると、プレゼンテーションのスライド上のテキストやシェイプの書式設定が可能です。以下の詳細をご確認ください。

|機能|説明|
| :- | :- |
|Text Formatting|<p>Aspose.Slides for Python via .NET では、シェイプに関連付けられたテキスト フレームを介してテキストを管理できます。そのため、テキスト フレームの段落と部分を使用してテキストの書式設定が可能です。これらのテキスト要素は Aspose.Slides for Python via .NET で書式設定できます。</p><p>- フォント種別</p><p>- フォントサイズ</p><p>- フォントカラー</p><p>- フォントの陰影</p><p>- 段落の配置</p><p>- 段落の箇条書き</p><p>- 段落の方向</p>|
|Shape Formatting|<p>Aspose.Slides for Python via .NET では、スライドの基本要素はシェイプです。以下の属性を使用してシェイプの書式設定が可能です。</p><p>- 位置</p><p>- サイズ</p><p>- 線</p><p>- 塗りつぶし（パターン、グラデーション、単色）</p><p>- テキスト</p><p>- 画像</p>|

## **FAQ**

**Do I need to install Microsoft PowerPoint on the server/PC for the library to work?**

No. PowerPoint is not required; Aspose.Slides is a standalone engine for creating, editing, converting, and rendering presentations.

**How does multithreading work? Can processing be parallelized?**

It is safe to process different documents in different threads; the same [presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) object must not be used by [multiple threads](/slides/ja/python-net/multithreading/) at the same time.

**Are file passwords and encryption supported?**

Yes. [You can](/slides/ja/python-net/password-protected-presentation/) open encrypted presentations, set or remove an open and write password, and check the protection status.

**Do I need to care about font packages in Linux containers?**

Yes. It is recommended to install common font packages and/or explicitly [specify font directories](/slides/ja/python-net/custom-font/) in your application to avoid unexpected substitutions.

**Are there limitations in the evaluation version?**

In [evaluation mode](/slides/ja/python-net/licensing/), a watermark is added to the output and certain limitations apply; a [30-day temporary license](https://purchase.aspose.com/temporary-license/) is available for full-feature testing.

**Is importing external formats into a presentation (PDF/HTML → PPTX) supported?**

Yes. You can add [PDF pages and HTML content](/slides/ja/python-net/import-presentation/) to a presentation, turning them into slides.