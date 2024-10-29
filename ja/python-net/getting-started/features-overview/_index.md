---
title: 機能概要
type: docs
weight: 20
url: /ja/python-net/features-overview/
---

## **サポートされているプラットフォーム**
Aspose.Slides for Python via .NETは、Windows x64またはx86上で、Python 3.5以降がインストールされた広範なLinuxディストリビューションで使用できます。ターゲットLinuxプラットフォームには追加の要件があります：
- GCC-6ランタイムライブラリ（またはそれ以降）
- .NET Coreランタイムの依存関係。 .NET Coreランタイム自体のインストールは必要ありません
- Python 3.5-3.7用：`pymalloc`ビルドのPythonが必要です。デフォルトで`--with-pymalloc` Pythonビルドオプションが有効です。通常、Pythonの`pymalloc`ビルドはファイル名に`m`サフィックスが付いています。
- `libpython`共有Pythonライブラリ。デフォルトで`--enable-shared` Pythonビルドオプションは無効になっており、一部のPythonディストリビューションには`libpython`共有ライブラリが含まれていません。一部のLinuxプラットフォームでは、パッケージマネージャーを使用して`libpython`共有ライブラリをインストールできます。例えば：`sudo apt-get install libpython3.7`。一般的な問題は、`libpython`ライブラリが共有ライブラリの標準システムロケーションとは異なる場所にインストールされることです。この問題は、Pythonをコンパイルする際に代替ライブラリパスを設定するためにPythonビルドオプションを使用するか、共有ライブラリのシステム標準ロケーションに`libpython`ライブラリファイルへのシンボリックリンクを作成することで修正できます。通常、Python 3.5-3.7の`libpython`共有ライブラリファイル名は`libpythonX.Ym.so.1.0`、Python 3.8以降の場合は`libpythonX.Y.so.1.0`（例えば：`libpython3.7m.so.1.0`、`libpython3.9.so.1.0`）です。

より多くのプラットフォームをサポートする必要がある場合は、「双子兄弟」製品であるAspose.Slides for .NETまたはAspose.Slides for Javaを探してください。


## **ファイル形式と変換**
Aspose.Slides for Python via .NETは、ほとんどのPowerPointドキュメント形式をサポートしています。また、組織が広く使用し相互に交換している一般的な形式にエクスポートすることもできます。これらの詳細をご覧ください：

|**機能**|**説明**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/ja/python-net/ppt-vs-pptx/)|Aspose.Slides for Python via .NETは、このプレゼンテーションドキュメント形式の最速の処理を提供します。|
|[PPTからPPTXへの変換](/slides/ja/python-net/convert-ppt-to-pptx/)|Aspose.Slides for Python via .NETは、PPTからPPTXへの変換をサポートしています。|
|[Portable Document Format (PDF)](/slides/ja/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|すべてのサポートされるファイル形式を、単一のメソッドでAdobe Portable Document Format (PDF)ドキュメントにエクスポートできます。|
|[XML Parser Specification (XPS)](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)|すべてのサポートされるファイル形式を、単一のメソッドでXML Parser Specification (XPS)ドキュメントにエクスポートできます。|
|[Tagged Image File Format (TIFF)](/slides/ja/python-net/convert-powerpoint-to-tiff/)|すべてのサポートされるプレゼンテーションファイル形式をTagged Image File Format (TIFF)にエクスポートできます。|
|[PPTXからHTMLへの変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)|Aspose.Slides for Python via .NETは、PresentationExをHTML形式に変換することをサポートしています。|

## **レンダリングと印刷**
Aspose.Slides for Python via .NETは、プレゼンテーションドキュメント内のスライドをさまざまなグラフィック形式に高忠実度でレンダリングすることをサポートしています。これらの詳細をご覧ください：

|**機能**|**説明**|
| :- | :- |
|.NETサポートの画像形式|Aspose.Slides for Python via .NETを使用すると、プレゼンテーションスライドとスライド上の画像をTIFF、PNG、BMP、JPEG、GIF、メタファイルなどのすべての.NETサポートのグラフィック形式にレンダリングすることができます。|
|SVG形式|Aspose.Slides for Python via .NETは、プレゼンテーションスライドをスケーラブルベクターグラフィックス（SVG）形式にエクスポートするための組み込みメソッドも提供しています。|
|プレゼンテーション印刷|Aspose.Slides for Python via .NETの最新バージョンは、異なるオプションを持つ組み込み印刷メソッドを提供します。|
## **コンテンツ機能**
Aspose.Slides for Python via .NETを使用すると、プレゼンテーションドキュメント内のほぼすべてのアイテムやコンテンツにアクセス、変更、または作成できるようになります。これらの詳細をご覧ください：

|**機能**|**説明**|
| :- | :- |
|マスタースライド|マスタースライドは、通常のスライドのレイアウトを定義します。Aspose.Slides for Python via .NETを使用すると、プレゼンテーションドキュメントのマスタースライドにアクセスして変更できます。|
|通常のスライド|Aspose.Slides for Python via .NETでは、さまざまなタイプの新しいスライドを作成できます。また、プレゼンテーション内の既存のスライドにアクセスして変更できます。|
|スライドのクローン/コピー|Aspose.Slides for Python via .NETでは、プレゼンテーション内の既存のスライドをクローンまたはコピーできる組み込みメソッドが提供されています。また、コピーされたスライドやクローンされたスライドを別のプレゼンテーション間で使用することもできます。スライドはマスタースライドからレイアウトを継承するため、組み込みのクローンメソッドはクローン時に自動的にマスターをコピーします。|
|スライドセクションの管理|プレゼンテーション内の異なるセクションにスライドを整理するためのメソッド|
|プレースホルダーとテキストホルダー|スライド内のプレースホルダーとテキストホルダーにアクセスできます。さらに、適切なメソッドを使用して、テキストホルダーのあるスライドをゼロから作成できます。|
|ヘッダーとフッター|Aspose.Slides for Python via .NETは、スライド内のヘッダー/フッターの処理を容易にします。|
|スライドのノート|Aspose.Slides for Python via .NETを使用すると、スライドに関連付けられたノートにアクセスして変更し、新しいノートを追加することができます。|
|シェイプの検索|シェイプに関連付けられた代替テキストを使用して、スライドから特定のシェイプを見つけることもできます。|
|背景|Aspose.Slides for Python via .NETを使用すると、プレゼンテーション内のマスターまたは通常のスライドに関連付けられた背景を操作できます。|
|テキストボックス|テキストボックスはゼロから作成できます。既存のテキストボックスにアクセスすることもできます。また、元のテキスト形式を失うことなく、そのテキストを変更できます。|
|長方形シェイプ|Aspose.Slides for Python via .NETを使用して、長方形のシェイプを作成または変更できます。|
|ポリラインシェイプ|Aspose.Slides for Python via .NETを使用して、ポリラインシェイプを作成または変更できます。|
|楕円形シェイプ|Aspose.Slides for Python via .NETを使用して、楕円形のシェイプを作成または変更できます。|
|グループシェイプ|Aspose.Slides for Python via .NETは、グループシェイプをサポートしています。|
|自動シェイプ|Aspose.Slides for Python via .NETは、自動シェイプをサポートしています。|
|SmartArt|Aspose.Slides for Python via .NETは、MS PowerPoint内のSmartArtシェイプをサポートしています。|
|チャート|Aspose.Slides for Python via .NETは、PowerPointのMSOチャートをサポートしています。|
|シェイプのシリアライズ|Aspose.Slides for Python via .NETは、多くのシェイプをサポートしています。Aspose.Slides for Python via .NETがシェイプをサポートしていない場合は、既存のスライドからそのシェイプをシリアライズする方法を使用することができます。この方法を使うことで、要求に応じてシェイプをさらに使用できます。|
|画像フレーム|Aspose.Slides for Python via .NETを使用して、画像フレーム内の画像を管理できます。|
|オーディオフレーム|Aspose.Slides for Python via .NETを使用して、スライド内のオーディオフレームにオーディオファイルをリンクまたは埋め込むことができます。|
|ビデオフレーム|ビデオフレーム内のビデオファイルを処理できます。Aspose.Slides for Python via .NETは、リンクされたビデオや埋め込まれたビデオもサポートしています。|
|OLEフレーム|Aspose.Slides for Python via .NETを使用して、OLEフレーム内のOLEオブジェクトを管理できます。|
|テーブル|Aspose.Slides for Python via .NETは、スライド内のテーブルをサポートしています。|
|ActiveXコントロール|ActiveXコントロールのサポート|
|VBAマクロ|プレゼンテーション内のVBAマクロを管理するためのサポート。|
|テキストフレーム|シェイプに関連付けられたテキストフレームを通じて、任意のシェイプのテキストにアクセスできます。|
|テキストスキャン|組み込みスキャンメソッドを通じて、プレゼンテーションのプレゼンテーションレベルまたはスライドレベルでテキストをスキャンできます。|
|アニメーション|シェイプにアニメーションを適用できます。|
|スライドショー|Aspose.Slides for Python via .NETは、スライドショーとスライドのトランジションをサポートしています。|

## **フォーマット機能**
Aspose.Slides for Python via .NETを使用すると、プレゼンテーションのスライド上のテキストやシェイプをフォーマットできます。これらの詳細をご覧ください：

|**機能**|**説明**|
| :- | :- |
|テキストフォーマット|<p>Aspose.Slides for Python via .NETでは、シェイプに関連付けられたテキストフレームを使用してテキストを管理できます。したがって、テキストフレームに関連付けられた段落や部分を使用してテキストをフォーマットできます。これらのテキスト要素は、Aspose.Slides for Python via .NETを通じてフォーマットできます。</p><p>- フォントタイプ</p><p>- フォントサイズ</p><p>- フォントカラー</p><p>- フォントのシェード</p><p>- 段落の整列</p><p>- 段落の箇条書き</p><p>- 段落の配置</p>|
|シェイプフォーマット|<p>Aspose.Slides for Python via .NETでは、スライドの基本要素はシェイプです。これらのシェイプ要素をAspose.Slides for Python via .NETを使用してフォーマットできます：</p><p>- 位置</p><p>- サイズ</p><p>- ライン</p><p>- 塗りつぶし（パターン、グラデーション、ソリッドを含む）</p><p>- テキスト</p><p>- 画像</p>|