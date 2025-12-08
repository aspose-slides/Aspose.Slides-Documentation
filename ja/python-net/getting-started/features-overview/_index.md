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
- 印刷
- 書式設定
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を発見：PowerPoint および OpenDocument プレゼンテーションを効率的に作成、編集、操作、変換できる強力な API です。"
---

## **サポートされているプラットフォーム**
Aspose.Slides for Python via .NET が使用できるプラットフォームは、Windows x64 または x86 と、Python 3.5 以降がインストールされた幅広い Linux ディストリビューションです。ターゲット Linux プラットフォームには以下の追加要件があります：
- GCC-6 ランタイム ライブラリ（またはそれ以降）
- .NET Core Runtime の依存関係。.NET Core Runtime 自体のインストールは不要です
- Python 3.5‑3.7 用: `pymalloc` ビルドの Python が必要です。`--with-pymalloc` ビルド オプションはデフォルトで有効になっています。通常、`pymalloc` ビルドはファイル名に `m` サフィックスが付きます
- `libpython` 共有 Python ライブラリ。`--enable-shared` ビルド オプションはデフォルトで無効になっており、一部の Python ディストリビューションには `libpython` 共有ライブラリが含まれていません。一部の Linux プラットフォームではパッケージ マネージャーで `libpython` 共有ライブラリをインストールできます（例: `sudo apt-get install libpython3.7`）。一般的な問題は、`libpython` ライブラリが標準の共有ライブラリのシステム ロケーションとは異なる場所にインストールされていることです。この問題は、Python をコンパイルする際にビルド オプションで代替ライブラリ パスを設定するか、システムの標準共有ライブラリ ロケーションに `libpython` ライブラリへのシンボリック リンクを作成することで解決できます。通常、`libpython` 共有ライブラリのファイル名は Python 3.5‑3.7 の場合 `libpythonX.Ym.so.1.0`、Python 3.8 以降の場合は `libpythonX.Y.so.1.0`（例: `libpython3.7m.so.1.0`、`libpython3.9.so.1.0`）です。

より多くのプラットフォームのサポートが必要な場合は、Aspose.Slides for .NET または Aspose.Slides for Java の「ツインブラザー」製品をご確認ください。

## **ファイル形式と変換**
Aspose.Slides for Python via .NET は、ほとんどの PowerPoint ドキュメント形式をサポートします。また、組織が広く使用し相互に交換する人気フォーマットへのエクスポートも可能です。詳細は以下をご覧ください：

|**機能**|**説明**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/ja/python-net/ppt-vs-pptx/)|Aspose.Slides for Python via .NET はこのプレゼンテーション ドキュメント形式の最速処理を提供します。|
|[PPT から PPTX への変換](/slides/ja/python-net/convert-ppt-to-pptx/)|Aspose.Slides for Python via .NET は PPT から PPTX への変換をサポートします。|
|[Portable Document Format (PDF)](/slides/ja/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|単一のメソッドで、サポートされているすべてのファイル形式を Adobe Portable Document Format (PDF) にエクスポートできます。|
|[XML Parser Specification (XPS)](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)|単一のメソッドで、サポートされているすべてのファイル形式を XML Parser Specification (XPS) にエクスポートできます。|
|[Tagged Image File Format (TIFF)](/slides/ja/python-net/convert-powerpoint-to-tiff/)|サポートされているプレゼンテーション ファイル形式を Tagged Image File Format (TIFF) にエクスポートできます。|
|[PPTX から HTML への変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)|Aspose.Slides for Python via .NET は PresentationEx を HTML 形式に変換することをサポートします。|

## **レンダリングと印刷**
Aspose.Slides for Python via .NET は、プレゼンテーション ドキュメント内のスライドをさまざまなグラフィック形式に高忠実度でレンダリングできます。詳細は以下をご覧ください：

|**機能**|**説明**|
| :- | :- |
|.NET がサポートする画像形式|Aspose.Slides for Python via .NET を使用すると、TIFF、PNG、BMP、JPEG、GIF、メタファイルなど、.NET がサポートするすべての画像形式にプレゼンテーション スライドやスライド上の画像をレンダリングできます。|
|SVG 形式|Aspose.Slides for Python via .NET は、Scalable Vector Graphics (SVG) 形式へのスライドエクスポート用組み込みメソッドも提供します。|
|プレゼンテーションの印刷|最新バージョンの Aspose.Slides for Python via .NET は、さまざまなオプションを備えた組み込み印刷メソッドを提供します。|

## **コンテンツ機能**
Aspose.Slides for Python via .NET は、プレゼンテーション ドキュメントのほぼすべての項目やコンテンツにアクセス、変更、作成することを可能にします。詳細は以下をご覧ください：

|**機能**|**説明**|
| :- | :- |
|マスタースライド|マスタースライドは通常スライドのレイアウトを定義します。Aspose.Slides for Python via .NET では、プレゼンテーションのマスタースライドにアクセスし変更できます。|
|通常スライド|Aspose.Slides for Python via .NET を使用すると、さまざまなタイプの新しいスライドを作成でき、既存のスライドにもアクセスして変更できます。|
|スライドのクローン / コピー|Aspose.Slides for Python via .NET が提供する組み込みメソッドにより、プレゼンテーション内の既存スライドをクローンまたはコピーできます。クローンやコピーしたスライドを別のプレゼンテーションに使用することも可能です。スライドはマスタースライドからレイアウトを継承するため、クローン時にマスターも自動的にコピーされます。|
|スライド セクションの管理|プレゼンテーション内でスライドを異なるセクションに整理するメソッドがあります。|
|プレースホルダーとテキストプレースホルダー|スライド内のプレースホルダーとテキストプレースホルダーにアクセスできます。また、適切なメソッドを使ってテキストプレースホルダーだけのスライドをゼロから作成できます。|
|ヘッダーとフッター|Aspose.Slides for Python via .NET は、スライドのヘッダー/フッターの処理を容易にします。|
|スライドのノート|Aspose.Slides for Python via .NET を使用すると、スライドに関連付けられたノートにアクセス・変更でき、また新しいノートを追加できます。|
|シェイプの検索|シェイプに設定された代替テキストを使用して、スライド内の特定シェイプを検索できます。|
|背景|マスターまたは通常スライドに関連付けられた背景を操作できます。|
|テキスト ボックス|テキスト ボックスはゼロから作成でき、既存のテキスト ボックスにアクセスして、元の書式を保持したままテキストを変更できます。|
|矩形シェイプ|矩形シェイプを作成または変更できます。|
|ポリライン シェイプ|ポリライン シェイプを作成または変更できます。|
|楕円シェイプ|楕円シェイプを作成または変更できます。|
|グループ シェイプ|Aspose.Slides for Python via .NET はグループ シェイプをサポートします。|
|オート シェイプ|Aspose.Slides for Python via .NET はオート シェイプをサポートします。|
|SmartArt|Aspose.Slides for Python via .NET は MS PowerPoint の SmartArt シェイプをサポートします。|
|チャート|Aspose.Slides for Python via .NET は PowerPoint の MSO チャートをサポートします。|
|シェイプ シリアライズ|Aspose.Slides for Python via .NET は多数のシェイプをサポートします。サポートされていないシェイプがある場合は、既存スライドからシェイプをシリアライズする方法を使用して取得し、必要に応じて再利用できます。|
|画像フレーム|画像フレーム内の画像を管理できます。|
|オーディオ フレーム|スライド上のオーディオ フレームにオーディオ ファイルをリンクまたは埋め込むことができます。|
|ビデオ フレーム|ビデオ フレーム内のビデオ ファイルを処理できます。Aspose.Slides for Python via .NET はリンクおよび埋め込みビデオもサポートします。|
|OLE フレーム|OLE フレーム内の OLE オブジェクトを管理できます。|
|テーブル|スライド内のテーブルをサポートします。|
|ActiveX コントロール|ActiveX コントロールをサポートします。|
|VBA マクロ|プレゼンテーション内の VBA マクロの管理をサポートします。|
|テキスト フレーム|任意のシェイプに関連付けられたテキスト フレームを介してテキストにアクセスできます。|
|テキスト スキャン|組み込みスキャン メソッドを使用して、プレゼンテーション全体またはスライド単位でテキストを走査できます。|
|アニメーション|シェイプにアニメーションを適用できます。|
|スライドショー|Aspose.Slides for Python via .NET はスライドショーとスライド遷移をサポートします。|

## **書式設定機能**
Aspose.Slides for Python via .NET を使用すると、プレゼンテーション内のスライド上のテキストやシェイプの書式設定が可能です。詳細は以下をご覧ください：

|**機能**|**説明**|
| :- | :- |
|テキスト書式設定|<p>Aspose.Slides for Python via .NET では、シェイプに紐付くテキスト フレームを通じてテキストを管理できます。そのため、テキスト フレームに含まれる段落や部分を使用してテキストを書式設定できます。これらのテキスト要素は Aspose.Slides for Python via .NET で書式設定可能です。</p><p>- フォント種別</p><p>- フォントサイズ</p><p>- フォント色</p><p>- フォントの陰影</p><p>- 段落揃え</p><p>- 段落の箇条書き</p><p>- 段落の方向</p>|
|シェイプ書式設定|<p>Aspose.Slides for Python via .NET におけるスライドの基本要素はシェイプです。これらのシェイプ要素は次のプロパティで書式設定できます。</p><p>- 位置</p><p>- サイズ</p><p>- 線</p><p>- 塗りつぶし（パターン、グラデーション、単色）</p><p>- テキスト</p><p>- 画像</p>|

## **FAQ**

**サーバー/PC に Microsoft PowerPoint をインストールする必要がありますか？**

いいえ。PowerPoint は必要ありません。Aspose.Slides はプレゼンテーションの作成、編集、変換、レンダリング用のスタンドアロン エンジンです。

**マルチスレッドはどのように機能しますか？処理は並列化できますか？**

異なるスレッドで別々のドキュメントを処理するのは安全です。同じ [presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクトを [複数のスレッド](/slides/ja/python-net/multithreading/) で同時に使用しないでください。

**ファイルのパスワードや暗号化はサポートされていますか？**

はい。[暗号化されたプレゼンテーション](/slides/ja/python-net/password-protected-presentation/) を開くことができ、開くパスワードや書き込みパスワードの設定・削除、保護ステータスの確認が可能です。

**Linux コンテナでフォント パッケージに注意する必要がありますか？**

はい。一般的なフォント パッケージをインストールするか、アプリケーションで明示的に [フォントディレクトリを指定](/slides/ja/python-net/custom-font/) することが推奨されます。これにより予期しない置き換えを防げます。

**評価版に制限はありますか？**

[評価モード](/slides/ja/python-net/licensing/) では出力に透かしが追加され、いくつかの制限が適用されます。フル機能のテスト用に [30 日間の一時ライセンス](https://purchase.aspose.com/temporary-license/) が利用可能です。

**外部形式（PDF/HTML → PPTX）のインポートはサポートされていますか？**

はい。[PDF ページや HTML コンテンツ](/slides/ja/python-net/import-presentation/) をプレゼンテーションに追加し、スライドに変換できます。