---
title: 機能概要
type: docs
weight: 94
url: /ja/net/features-overview/
keywords:
- 機能
- サポートされているプラットフォーム
- ファイル形式
- 変換
- レンダリング
- プレゼンテーション コンテンツ
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "評価する前に、Aspose.Slides for .NET がカバーする内容を確認してください：サポートされているプラットフォーム、ファイル形式、スライドのレンダリング、および作成・編集できるコンテンツです。"
---
## **概要**

Aspose.Slides for .NET は、PowerPoint および OpenDocument プレゼンテーションの作成、読み取り、編集、変換、レンダリングを行うクラス ライブラリです。独自のユーザー インターフェイスはなく、Microsoft PowerPoint や Office を必要としないため、コンソール アプリケーション、Windows Forms などのデスクトップ アプリケーション、Web アプリケーション、Web サービスで使用できます。本記事ではライブラリがカバーする領域をまとめ、各領域を説明する記事へのリンクを示します。

## **サポートされるプラットフォーム**

Aspose.Slides for .NET は、同一の API を持つ 2 つの NuGet パッケージとして配布されています。

|**パッケージ**|**パッケージに含まれるビルド**|**オペレーティングシステム**|
| :- | :- | :- |
|[Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/)|.NET Framework 4.6.2、.NET Standard 2.0、.NET 6。 .NET Framework 4.6.2 以降、または .NET 6 以降で使用できます。|Windows。`libgdiplus` ライブラリと `System.Drawing.EnableUnixSupport` スイッチを使用した Linux と macOS。|
|[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/)|.NET 6。 .NET 6 以降で使用できます。|Windows (x86、x64)、Linux (glibc 2.23 以降の x64、glibc 2.39 以降の ARM64)、macOS (x64、ARM64)。|

[インストール](/slides/ja/net/installation/) では、どのパッケージを選択すべきか、Linux で必要なものは何かを説明しています。[システム要件](/slides/ja/net/system-requirements/) には、サポートされるプラットフォームの詳細が掲載されています。

## **ファイル形式と変換**

Aspose.Slides は PPT、PPTX、PPS、POT、PPSX、POTX、PPTM、PPSM、POTM、ODP、OTP、FODP、PowerPoint XML プレゼンテーションを開いたり保存したりできます。PDF と HTML のコンテンツをスライドにインポートでき、プレゼンテーションを PDF、XPS、HTML、HTML5、TIFF、アニメーション GIF、SWF、Markdown、XAML として保存できます。[サポートされるファイル形式](/slides/ja/net/supported-file-formats/) には、各形式を読み書きする API が一覧化されています。

|**機能**|**説明**|
| :- | :- |
|[PPT と PPTX](/slides/ja/net/ppt-vs-pptx/)|バイナリ形式の PowerPoint 97-2003 と Office Open XML の両方を読み書きできます。|
|[PPT から PPTX への変換](/slides/ja/net/convert-ppt-to-pptx/)|レガシー PPT プレゼンテーションを PPTX に変換します。|
|[PDF](/slides/ja/net/convert-powerpoint-to-pdf/)|PDF、PDF/A、PDF/UA ドキュメントとしてエクスポートします。|
|[XPS](/slides/ja/net/convert-powerpoint-to-xps/)|XPS ドキュメントとしてエクスポートします。|
|[TIFF](/slides/ja/net/convert-powerpoint-to-tiff/)|TIFF 画像としてエクスポートします。|
|[HTML](/slides/ja/net/convert-powerpoint-to-html/)|HTML と HTML5 としてエクスポートします。|
|[PDF と HTML のインポート](/slides/ja/net/import-presentation/)|PDF ページや HTML コンテンツからスライドを作成します。|

## **プレゼンテーションのレンダリング**

Aspose.Slides はスライドや個々の図形を PNG、JPEG、BMP、GIF、TIFF、SVG 画像として、スライドを EMF メタファイルとしてレンダリングします。[スライドを画像に変換](/slides/ja/net/convert-slide/)、[スライドを SVG 画像としてレンダリング](/slides/ja/net/render-a-slide-as-an-svg-image/)、[図形のサムネイルを作成](/slides/ja/net/create-shape-thumbnails/) を参照してください。

## **コンテンツ機能**

Aspose.Slides を使用すると、プレゼンテーションのほぼすべてのコンテンツを作成、読み取り、変更できます。

|**領域**|**できること**|
| :- | :- |
|[スライド](/slides/ja/net/presentation-slide/)|スライドの追加、クローン、順序変更、削除、レイアウトとマスタの適用、セクションへの整理、サイズ変更が可能です。|
|[デザイン](/slides/ja/net/presentation-design/)|背景、テーマカラー、ヘッダーとフッター、フォントを設定できます。|
|[テキスト](/slides/ja/net/manage-text/)|テキスト フレーム、段落、文字列を作成・編集し、フォント、色、箇条書き、配置を設定し、検索・置換が可能です。|
|[図形](/slides/ja/net/powerpoint-shapes/)|オートシェイプ、線、コネクタ、グループ化図形、画像フレームを作成し、位置、サイズ、線、単色・グラデーション・パターン塗りを設定し、代替テキストで図形を検索できます。|
|[テーブル](/slides/ja/net/powerpoint-table/)、[チャート](/slides/ja/net/powerpoint-charts/)、および[SmartArt](/slides/ja/net/powerpoint-smartart/)|テーブル、Microsoft Office のチャート、SmartArt 図を作成・編集できます。|
|[メディア](/slides/ja/net/manage-media-files/)、[OLE オブジェクト](/slides/ja/net/manage-ole/)、および[ActiveX コントロール](/slides/ja/net/activex/)|埋め込みまたはリンクされたオーディオ・ビデオ フレームを追加し、OLE オブジェクトを埋め込み、ActiveX コントロールを追加・修正・削除できます。|
|[ノート](/slides/ja/net/presentation-notes/) と[コメント](/slides/ja/net/presentation-comments/)|スピーカーノートとレビュー コメントを追加、読み取り、編集できます。|
|[アニメーション](/slides/ja/net/powerpoint-animation/) と[スライド トランジション](/slides/ja/net/slide-transition/)|図形にアニメーション効果を適用し、スライド トランジションを設定し、スライドショーの設定を構成できます。|
|[セキュリティ](/slides/ja/net/presentation-security/)|プレゼンテーションにパスワードで暗号化し、書き込み保護を設定し、デジタル署名を操作できます。|
|[VBA マクロ](/slides/ja/net/presentation-via-vba/)|マクロ有効プレゼンテーションの VBA モジュールを追加、抽出、削除できます。|
|[プロパティ](/slides/ja/net/presentation-properties/)|ドキュメント プロパティを読み取り、編集できます。|

## **FAQ**

**サーバーまたは PC に Microsoft PowerPoint をインストールする必要がありますか？**

いいえ。PowerPoint は必要ありません。Aspose.Slides はプレゼンテーションの作成、編集、変換、レンダリングを行うスタンドアロン エンジンです。

**マルチスレッドはどのように機能しますか？処理を並列化できますか？**

異なるスレッドで別々のドキュメントを処理することは安全です。同じ[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/)オブジェクトを[複数のスレッド](/slides/ja/net/multithreading/)で同時に使用してはいけません。

**ファイル パスワードと暗号化はサポートされていますか？**

はい。[ここ](/slides/ja/net/password-protected-presentation/)で暗号化されたプレゼンテーションを開くことができ、開くパスワードと書き込みパスワードの設定・解除、保護状態の確認が行えます。

**Linux コンテナーでフォントに注意する必要がありますか？**

はい。プレゼンテーションで使用するフォント、または適切な代替フォントをシステムにインストールしておく必要があります。アプリケーションで[フォント ディレクトリを指定](/slides/ja/net/custom-font/)することも可能です。[インストール](/slides/ja/net/installation/) に各パッケージの Linux 前提条件が記載されています。

**評価版に制限はありますか？**

はい。ライセンスがない場合、Aspose.Slides は保存するすべてのスライドに評価ウォーターマークを付加し、プレゼンテーションから読み取ったテキストを切り詰めます。フル機能のテスト用に[30 日間の一時ライセンス](https://purchase.aspose.com/temporary-license/)が用意されています。

**プレゼンテーションへの外部形式のインポート (PDF や HTML から PPTX) はサポートされていますか？**

はい。[PDF ページと HTML コンテンツ](/slides/ja/net/import-presentation/)をプレゼンテーションに追加し、スライドに変換できます。