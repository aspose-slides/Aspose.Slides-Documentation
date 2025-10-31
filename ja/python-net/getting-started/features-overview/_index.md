---
title: 機能概要
type: docs
weight: 20
url: /ja/python-net/features-overview/
keywords:
- 機能
- サポートプラットフォーム
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
description: "Aspose.Slides for Python via .NET を発見してください。PowerPoint および OpenDocument プレゼンテーションを効率的に作成、編集、自動化、変換できる強力な API です。"
---

## **サポートプラットフォーム**
Aspose.Slides for Python via .NET は、Windows x64 または x86、そして Python 3.5 以降がインストールされた幅広い Linux ディストリビューション上で使用できます。対象 Linux プラットフォームには追加要件があります:
- GCC-6 ランタイムライブラリ（以降のバージョン）
- .NET Core Runtime の依存関係。.NET Core Runtime 自体のインストールは不要です
- Python 3.5‑3.7 用: `pymalloc` ビルドの Python が必要です。`--with-pymalloc` ビルドオプションはデフォルトで有効です。通常、`pymalloc` ビルドはファイル名に `m` サフィックスが付きます
- `libpython` 共有 Python ライブラリ。`--enable-shared` ビルドオプションはデフォルトで無効になっており、一部の Python ディストリビューションには `libpython` 共有ライブラリが含まれていません。Linux プラットフォームによっては、パッケージマネージャで `libpython` 共有ライブラリをインストールできます（例: `sudo apt-get install libpython3.7`）。一般的な問題は、`libpython` ライブラリが標準の共有ライブラリパスとは異なる場所にインストールされることです。この問題は、Python のビルドオプションで代替ライブラリパスを指定するか、システム標準の共有ライブラリディレクトリにシンボリックリンクを作成することで解決できます。通常、Python 3.5‑3.7 の `libpython` 共有ライブラリファイル名は `libpythonX.Ym.so.1.0`、Python 3.8 以降は `libpythonX.Y.so.1.0`（例: `libpython3.7m.so.1.0`、`libpython3.9.so.1.0`）です。

より多くのプラットフォームのサポートが必要な場合は、Aspose.Slides for .NET または Aspose.Slides for Java の「ツインブラザー」製品を確認してください。


## **ファイル形式と変換**
Aspose.Slides for Python via .NET は、ほぼすべての PowerPoint ドキュメント形式をサポートします。また、組織が広く使用し相互にやり取りする一般的な形式へのエクスポートも可能です。以下の詳細をご確認ください:

|**機能**|**説明**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/ja/python-net/ppt-vs-pptx/)|Aspose.Slides for Python via .NET はこのプレゼンテーション形式の最速処理を提供します。|
|[PPT to PPTX conversion](/slides/ja/python-net/convert-ppt-to-pptx/)|Aspose.Slides for Python via .NET は PPT から PPTX への変換をサポートします。|
|[Portable Document Format (PDF)](/slides/ja/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|単一メソッドでサポートされているすべてのファイル形式を Adobe Portable Document Format (PDF) にエクスポートできます。|
|[XML Parser Specification (XPS)](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)|単一メソッドでサポートされているすべてのファイル形式を XML Parser Specification (XPS) にエクスポートできます。|
|[Tagged Image File Format (TIFF)](/slides/ja/python-net/convert-powerpoint-to-tiff/)|サポートされているすべてのプレゼンテーションファイル形式を Tagged Image File Format (TIFF) にエクスポートできます。|
|[PPTX To HTML Conversion](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)|Aspose.Slides for Python via .NET は PresentationEx を HTML 形式に変換することをサポートします。|

## **レンダリングと印刷**
Aspose.Slides for Python via .NET は、プレゼンテーションドキュメント内のスライドをさまざまなグラフィック形式へ高忠実度でレンダリングします。以下の詳細をご確認ください:

|**機能**|**説明**|
| :- | :- |
|.NET Supported Image Formats|Aspose.Slides for Python via .NET を使用すると、TIFF、PNG、BMP、JPEG、GIF、メタファイルなど、.NET がサポートするすべてのグラフィック形式でプレゼンテーションスライドやスライド上の画像をレンダリングできます。|
|SVG Format|Aspose.Slides for Python via .NET は、Scalable Vector Graphics (SVG) 形式へのエクスポートを行う組み込みメソッドも提供します。|
|Presentation Printing|最新バージョンの Aspose.Slides for Python via .NET には、さまざまなオプションを備えた組み込み印刷メソッドが用意されています。|

## **コンテンツ機能**
Aspose.Slides for Python via .NET を使用すると、プレゼンテーションドキュメントのほぼすべての項目やコンテンツにアクセス、変更、作成できます。以下の詳細をご確認ください:

|**機能**|**説明**|
| :- | :- |
|Master Slides|マスター スライドは標準スライドのレイアウトを定義します。Aspose.Slides for Python via .NET では、プレゼンテーションドキュメントのマスター スライドにアクセスし、変更できます。|
|Normal Slides|Aspose.Slides for Python via .NET を使用すると、さまざまなタイプの新規スライドを作成でき、既存のスライドにもアクセスして変更できます。|
|Cloning / Copying Slides|Aspose.Slides for Python via .NET が提供する組み込みメソッドにより、プレゼンテーション内の既存スライドをクローンまたはコピーできます。クローンやコピーしたスライドは、別のプレゼンテーションでも使用できます。スライドはマスター スライドからレイアウトを継承するため、組み込みのクローン メソッドはマスターを自動的にコピーします。|
|Managing Slides sections|プレゼンテーション内でスライドを異なるセクションに整理するメソッド|
|Place Holders and Text Holders|スライド内のプレースホルダーとテキストホルダーにアクセスできます。さらに、適切なメソッドを使用してテキストホルダー付きスライドをゼロから作成できます。|
|Header and Footers|Aspose.Slides for Python via .NET はスライドのヘッダー/フッターの取り扱いを容易にします。|
|Notes in Slides|Aspose.Slides for Python via .NET では、スライドに関連付けられたノートにアクセスし、変更したり新規ノートを追加したりできます。|
|Finding a Shape|代替テキストに基づいて、スライド内の特定のシェイプを検索できます。|
|Backgrounds|マスターまたは標準スライドに関連付けられた背景を扱うことができます。|
|Text Boxes|テキストボックスはゼロから作成可能です。既存のテキストボックスにもアクセスでき、元の書式を保持したままテキストを変更できます。|
|Rectangle Shapes|Aspose.Slides for Python via .NET で長方形シェイプを作成または変更できます。|
|Poly Line Shapes|Aspose.Slides for Python via .NET でポリラインシェイプを作成または変更できます。|
|Ellipse Shapes|Aspose.Slides for Python via .NET で楕円シェイプを作成または変更できます。|
|Group Shapes|Aspose.Slides for Python via .NET はグループ シェイプをサポートします|
|Auto Shapes|Aspose.Slides for Python via .NET はオート シェイプをサポートします|
|SmartArt|Aspose.Slides for Python via .NET は MS PowerPoint の SmartArt シェイプをサポートします|
|Charts|Aspose.Slides for Python via .NET は PowerPoint の MSO チャートをサポートします|
|Shapes Serialization|Aspose.Slides for Python via .NET は多数のシェイプをサポートします。サポートされていないシェイプがある場合は、シリアライズ手法を使用して既存スライドからそのシェイプをシリアライズし、必要に応じて再利用できます。|
|Picture Frames|Aspose.Slides for Python via .NET でピクチャーフレーム内の画像を管理できます。|
|Audio Frames|Aspose.Slides for Python via .NET でオーディオフレームにオーディオファイルをリンクまたは埋め込めます。|
|Video Frames|ビデオフレーム内のビデオファイルを扱えます。Aspose.Slides for Python via .NET はリンクビデオと埋め込みビデオの両方をサポートします|
|OLE Frame|Aspose.Slides for Python via .NET で OLE フレーム内の OLE オブジェクトを管理できます|
|Tables|Aspose.Slides for Python via .NET はスライド内のテーブルをサポートします|
|ActiveX Controls|ActiveX コントロールのサポート|
|VBA Macros|プレゼンテーション内の VBA マクロ管理のサポート|
|Text Frame|任意のシェイプに関連付けられたテキストフレームを介してテキストにアクセスできます|
|Text Scanning|組み込みのスキャンメソッドを使用して、プレゼンテーション全体またはスライド単位でテキストをスキャンできます。|
|Animations|シェイプにアニメーションを適用できます|
|Slide Shows|Aspose.Slides for Python via .NET はスライドショーとスライド遷移をサポートします|

## **書式設定機能**
Aspose.Slides for Python via .NET を使用すると、プレゼンテーションのスライド上のテキストやシェイプの書式設定が可能です。以下の詳細をご確認ください:

|**機能**|**説明**|
| :- | :- |
|Text Formatting|<p>Aspose.Slides for Python via .NET では、シェイプに関連付けられたテキストフレームを介してテキストを管理します。したがって、テキストフレームに含まれる段落と部分を使用してテキストをフォーマットできます。これらのテキスト要素は Aspose.Slides for Python via .NET でフォーマット可能です。</p><p>- フォント種別</p><p>- フォントサイズ</p><p>- フォントカラー</p><p>- フォントシェード</p><p>- 段落配置</p><p>- 段落箇条書き</p><p>- 段落方向</p>|
|Shape Formatting|<p>Aspose.Slides for Python via .NET では、スライドの基本要素はシェイプです。以下の項目でシェイプ要素をフォーマットできます。</p><p>- 位置</p><p>- サイズ</p><p>- 線</p><p>- 塗りつぶし（パターン、グラデーション、単色）</p><p>- テキスト</p><p>- 画像</p>|

## **FAQ**

**サーバー/PC に Microsoft PowerPoint をインストールする必要がありますか？**

いいえ。PowerPoint は不要です。Aspose.Slides はプレゼンテーションの作成、編集、変換、レンダリングのためのスタンドアロン エンジンです。

**マルチスレッドはどのように機能しますか？処理の並列化は可能ですか？**

異なるスレッドで別々のドキュメントを処理することは安全です。同一の [presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクトを [複数スレッド](/slides/ja/python-net/multithreading/) が同時に使用してはいけません。

**ファイルのパスワードや暗号化はサポートされていますか？**

はい。[こちら](/slides/ja/python-net/password-protected-presentation/) から暗号化されたプレゼンテーションを開き、開くパスワードや書き込みパスワードの設定・削除、保護状態の確認ができます。

**Linux コンテナ内のフォントパッケージに注意する必要がありますか？**

はい。一般的なフォントパッケージをインストールし、またはアプリケーションでフォントディレクトリを [明示的に指定](/slides/ja/python-net/custom-font/) することが推奨されます。これにより予期しないフォント置換を防げます。

**評価版に制限はありますか？**

[評価モード](/slides/ja/python-net/licensing/) では出力に透かしが追加され、いくつかの制限が適用されます。フル機能テスト用に [30 日間の一時ライセンス](https://purchase.aspose.com/temporary-license/) が利用可能です。

**外部フォーマット (PDF/HTML → PPTX) のインポートはサポートされていますか？**

はい。[PDF ページや HTML コンテンツ](/slides/ja/python-net/import-presentation/) をプレゼンテーションに追加し、スライドに変換できます。