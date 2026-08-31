---
title: 機能概要
type: docs
weight: 20
url: /ja/python-net/features-overview/
keywords:
- 機能
- サポートされているプラットフォーム
- ファイル形式
- 変換
- レンダリング
- 書式設定
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET：PowerPoint および OpenDocument プレゼンテーションを効率的に作成、編集、自動化、変換できる強力な API をご紹介します。"
---
## **サポートされているプラットフォーム**
Aspose.Slides for Python via .NET が使用できるプラットフォームは、Windows x64 または x86、そして Python 3.5 以降がインストールされたさまざまな Linux ディストリビューションです。ターゲットとなる Linux プラットフォームには以下の追加要件があります。
- GCC-6 ランタイム ライブラリ（またはそれ以降）
- .NET Core Runtime の依存関係。.NET Core Runtime 自体のインストールは **不要** です
- Python 3.5‑3.7 の場合: `pymalloc` ビルドの Python が必要です。`--with-pymalloc` ビルド オプションはデフォルトで有効になっています。通常、`pymalloc` ビルドはファイル名に `m` サフィックスが付いています
- `libpython` 共有 Python ライブラリ。`--enable-shared` ビルド オプションはデフォルトで無効になっているため、一部の Python ディストリビューションには `libpython` 共有ライブラリが含まれていません。Linux の一部プラットフォームでは、パッケージ マネージャーで `libpython` 共有ライブラリをインストールできます（例: `sudo apt-get install libpython3.7`）。一般的な問題は、`libpython` ライブラリが標準の共有ライブラリ用ディレクトリとは別の場所にインストールされることです。この問題は、Python をコンパイルするときにビルド オプションで代替ライブラリ パスを設定するか、システムの標準ディレクトリに `libpython` ライブラリ ファイルへのシンボリック リンクを作成することで解決できます。通常、Python 3.5‑3.7 の場合は `libpythonX.Ym.so.1.0`、Python 3.8 以降は `libpythonX.Y.so.1.0` という名前です（例: `libpython3.7m.so.1.0`、`libpython3.9.so.1.0`）。

より多くのプラットフォームをサポートしたい場合は、"twin brother" 製品である Aspose.Slides for .NET または Aspose.Slides for Java をご確認ください。

## **ファイル形式と変換**
Aspose.Slides for Python via .NET は、ほとんどの PowerPoint ドキュメント形式をサポートし、組織で幅広く使用・交換されている一般的な形式へのエクスポートも可能です。詳細は以下をご覧ください。

|**機能**|**説明**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/ja/python-net/ppt-vs-pptx/)|Aspose.Slides for Python via .NET は、このプレゼンテーション ドキュメント形式の処理速度が最速です。|
|[PPT to PPTX conversion](/slides/ja/python-net/convert-ppt-to-pptx/)|Aspose.Slides for Python via .NET は PPT から PPTX への変換をサポートします。|
|[Portable Document Format (PDF)](/slides/ja/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|単一のメソッドで、サポートされているすべてのファイル形式を Adobe Portable Document Format (PDF) にエクスポートできます。|
|[XML Parser Specification (XPS)](https://docs.aspose.com/slides/ja/python-net/convert-powerpoint-to-xps/)|単一のメソッドで、サポートされているすべてのファイル形式を XML Parser Specification (XPS) ドキュメントにエクスポートできます。|
|[Tagged Image File Format (TIFF)](/slides/ja/python-net/convert-powerpoint-to-tiff/)|サポートされているすべてのプレゼンテーション ファイル形式を Tagged Image File Format (TIFF) にエクスポートできます。|
|[PPTX To HTML Conversion](https://docs.aspose.com/slides/ja/python-net/convert-powerpoint-to-html/)|Aspose.Slides for Python via .NET は PresentationEx を HTML 形式に変換することをサポートします。|

## **プレゼンテーションのレンダリング**
Aspose.Slides for Python via .NET は、プレゼンテーション ドキュメント内のスライドをさまざまな画像形式に高忠実度でレンダリングできます。詳細は以下をご覧ください。

|**機能**|**説明**|
| :- | :- |
|.NET 対応画像形式|Aspose.Slides for Python via .NET を使用すると、TIFF、PNG、BMP、JPEG、GIF、メタファイルなど、.NET がサポートするすべての画像形式にプレゼンテーション スライドやスライド上の画像をレンダリングできます。|
|SVG 形式|Aspose.Slides for Python via .NET は、Scalable Vector Graphics (SVG) 形式へのエクスポートを行う組み込みメソッドも提供します。|

## **コンテンツ機能**
Aspose.Slides for Python via .NET を使用すると、プレゼンテーション ドキュメントのほぼすべてのアイテムやコンテンツにアクセス、変更、作成できます。詳細は以下をご覧ください。

|**機能**|**説明**|
| :- | :- |
|マスタースライド|マスタースライドは通常スライドのレイアウトを定義します。Aspose.Slides for Python via .NET はプレゼンテーション ドキュメントのマスタースライドへのアクセスと変更を可能にします。|
|ノーマルスライド|Aspose.Slides for Python via .NET では、さまざまなタイプの新規スライドを作成でき、既存のスライドにもアクセスして変更できます。|
|スライドのクローン/コピー|Aspose.Slides for Python via .NET が提供する組み込みメソッドを使用すると、プレゼンテーション内の既存スライドをクローンまたはコピーできます。コピーまたはクローンしたスライドを別のプレゼンテーションへも利用可能です。スライドはマスタースライドからレイアウトを継承するため、クローン時にマスターが自動的にコピーされます。|
|スライド セクションの管理|プレゼンテーション内でスライドを異なるセクションに整理するためのメソッド。|
|プレースホルダーとテキストホルダー|スライド内のプレースホルダーとテキストホルダーにアクセスできます。また、適切なメソッドを使用してテキストホルダー付きのスライドをゼロから作成できます。|
|ヘッダーとフッター|Aspose.Slides for Python via .NET はスライドのヘッダー/フッターの操作を支援します。|
|スライド ノート|スライドに関連付けられたノートにアクセス・変更でき、さらに新規ノートの追加も可能です。|
|シェイプの検索|シェイプに設定された代替テキストを使用して、特定のシェイプを検索できます。|
|背景|マスターまたはノーマルスライドに関連付けられた背景を操作できます。|
|テキスト ボックス|テキスト ボックスはゼロから作成でき、既存のテキスト ボックスにもアクセス可能です。元のテキスト形式を保持したままテキストを変更できます。|
|矩形シェイプ|Aspose.Slides for Python via .NET で矩形シェイプの作成または変更が可能です。|
|ポリライン シェイプ|Aspose.Slides for Python via .NET でポリライン シェイプの作成または変更が可能です。|
|楕円シェイプ|Aspose.Slides for Python via .NET で楕円シェイプの作成または変更が可能です。|
|グループ シェイプ|Aspose.Slides for Python via .NET はグループ シェイプをサポートします。|
|オート シェイプ|Aspose.Slides for Python via .NET はオート シェイプをサポートします。|
|SmartArt|Aspose.Slides for Python via .NET は MS PowerPoint の SmartArt シェイプをサポートします。|
|チャート|Aspose.Slides for Python via .NET は PowerPoint の MSO チャートをサポートします。|
|シェイプのシリアライズ|Aspose.Slides for Python via .NET は多数のシェイプをサポートします。サポートされていないシェイプがある場合は、シリアライズ メソッドを使用して既存スライドからシェイプをシリアライズし、以降の要件に合わせて利用できます。|
|ピクチャ フレーム|Aspose.Slides for Python via .NET でピクチャ フレーム内の画像を管理できます。|
|オーディオ フレーム|Aspose.Slides for Python via .NET でオーディオ フレームに音声ファイルをリンクまたは埋め込むことができます。|
|ビデオ フレーム|ビデオ フレーム内のビデオ ファイルの操作が可能です。Aspose.Slides for Python via .NET はリンク ビデオと埋め込みビデオの両方をサポートします。|
|OLE フレーム|Aspose.Slides for Python via .NET で OLE フレーム内の OLE オブジェクトを管理できます。|
|テーブル|Aspose.Slides for Python via .NET はスライド内のテーブルをサポートします。|
|ActiveX コントロール|ActiveX コントロールのサポート|
|VBA マクロ|プレゼンテーション内の VBA マクロ管理をサポートします。|
|テキスト フレーム|任意のシェイプに関連付けられたテキスト フレームを通じてテキストにアクセスできます。|
|テキスト スキャン|組み込みのスキャン メソッドを使用して、プレゼンテーション全体またはスライド単位でテキストをスキャンできます。|
|アニメーション|シェイプにアニメーションを適用できます。|
|スライドショー|Aspose.Slides for Python via .NET はスライドショーとスライド遷移をサポートします。|

## **書式設定機能**
Aspose.Slides for Python via .NET を使用すると、プレゼンテーション内のスライド上のテキストとシェイプの書式設定が可能です。詳細は以下をご覧ください。

|**機能**|**説明**|
| :- | :- |
|テキスト書式設定|<p>Aspose.Slides for Python via .NET では、シェイプに関連付けられたテキスト フレームを通じてテキストを管理できます。そのため、テキスト フレームの段落や部分を使用してテキストを書式設定できます。これらのテキスト要素は Aspose.Slides for Python via .NET で書式設定可能です。</p><p>- フォント タイプ</p><p>- フォント サイズ</p><p>- フォント 色</p><p>- フォント 影</p><p>- 段落 配置</p><p>- 段落 箇条書き</p><p>- 段落 向き</p>|
|シェイプ書式設定|<p>Aspose.Slides for Python via .NET では、スライドの基本要素であるシェイプを次のように書式設定できます。</p><p>- 位置</p><p>- サイズ</p><p>- 線</p><p>- 塗りつぶし（パターン、グラデーション、単色を含む）</p><p>- テキスト</p><p>- 画像</p>|

## **FAQ**

### ライブラリの使用にサーバー/PC に Microsoft PowerPoint のインストールは必要ですか？

いいえ。PowerPoint は不要です。Aspose.Slides は、プレゼンテーションの作成、編集、変換、レンダリングを行うスタンドアロン エンジンです。

### マルチスレッドはどのように機能しますか？処理の並列化は可能ですか？

異なるスレッドで別々のドキュメントを処理するのは安全です。同一の [presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) オブジェクトを [複数のスレッド](/slides/ja/python-net/multithreading/) から同時に使用しないでください。

### ファイル パスワードや暗号化はサポートされていますか？

はい。[暗号化されたプレゼンテーション](/slides/ja/python-net/password-protected-presentation/) を開くことができ、開くパスワードや書き込みパスワードの設定・削除、保護状態のチェックが可能です。

### Linux コンテナでフォント パッケージの管理は必要ですか？

はい。一般的なフォント パッケージをインストールするか、アプリケーションで明示的に [フォント ディレクトリを指定](/slides/ja/python-net/custom-font/) することを推奨します。これにより予期せぬフォント代替を防げます。

### 評価版には制限がありますか？

[評価モード](/slides/ja/python-net/licensing/) では、出力に透かしが付加され、いくつかの制限が適用されます。フル機能のテスト用に [30 日間の一時ライセンス](https://purchase.aspose.com/temporary-license/) が利用可能です。

### 外部形式（PDF/HTML → PPTX）をプレゼンテーションにインポートすることはサポートされていますか？

はい。[PDF ページや HTML コンテンツ](/slides/ja/python-net/import-presentation/) をプレゼンテーションに追加し、スライドとして扱うことができます。