---
title: C++ でプレゼンテーションを作成
linktitle: プレゼンテーションの作成
type: docs
weight: 10
url: /ja/cpp/create-presentation/
keywords:
- プレゼンテーションの作成
- 新しいプレゼンテーション
- PPT の作成
- 新しい PPT
- PPTX の作成
- 新しい PPTX
- ODP の作成
- 新しい ODP
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides を使用して C++ でプレゼンテーションを作成し、PPT、PPTX、ODP ファイルを生成し、OpenDocument のサポートを活用し、プログラムで保存して信頼性の高い結果を得られます。"
---

## **PowerPoint プレゼンテーションの作成**
プレゼンテーションの選択したスライドにシンプルな直線を追加するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. Shapes オブジェクトが提供する AddAutoShape メソッドを使用して、Line タイプの AutoShape を追加します。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

以下の例では、プレゼンテーションの最初のスライドに直線を追加しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateNewPresentation-CreateNewPresentation.cpp" >}}

## **よくある質問**

**新しいプレゼンテーションを保存できる形式は何ですか？**

以下のリンク先に保存できます: [PPTX, PPT, ODP](/slides/ja/cpp/save-presentation/)、および [PDF](/slides/ja/cpp/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/cpp/convert-powerpoint-to-xps/)、[HTML](/slides/ja/cpp/convert-powerpoint-to-html/)、[SVG](/slides/ja/cpp/convert-powerpoint-to-png/)、[images](/slides/ja/cpp/convert-powerpoint-to-png/) など。

**テンプレート (POTX/POTM) から開始し、通常の PPTX として保存できますか？**

はい。テンプレートをロードし、目的の形式で保存できます。POTX、POTM、PPTM などの形式は [サポートされています](/slides/ja/cpp/supported-file-formats/)。

**プレゼンテーション作成時にスライドサイズやアスペクト比を制御するには？**

[スライドサイズ](/slides/ja/cpp/slide-size/) を設定します（4:3 や 16:9 のプリセットやカスタム寸法を含む）。コンテンツのスケーリング方法も選択できます。

**サイズや座標はどの単位で測定されますか？**

ポイント単位です。1インチは 72 単位に相当します。

**多数のメディアファイルを含む非常に大きなプレゼンテーションのメモリ使用量を減らすにはどうすればよいですか？**

[BLOB 管理戦略](/slides/ja/cpp/manage-blob/) を使用し、テンポラリファイルを活用してメモリ内の保存を制限し、純粋なインメモリストリームよりもファイルベースのワークフローを優先してください。

**プレゼンテーションを並列で作成/保存できますか？**

同じ [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) インスタンスを [複数のスレッド](/slides/ja/cpp/multithreading/) から操作することはできません。スレッドまたはプロセスごとに個別のインスタンスを実行してください。

**トライアルの透かしと制限を除去するには？**

プロセスごとに一度だけ [ライセンスを適用](/slides/ja/cpp/licensing/) してください。ライセンス XML は変更せず、複数スレッドが関与する場合はライセンス設定を同期させる必要があります。

**作成した PPTX にデジタル署名できますか？**

はい。[デジタル署名](/slides/ja/cpp/digital-signature-in-powerpoint/)（追加と検証）がプレゼンテーションでサポートされています。

**作成したプレゼンテーションでマクロ（VBA）はサポートされていますか？**

はい。[VBA プロジェクトの作成/編集](/slides/ja/cpp/presentation-via-vba/) が可能で、PPTM や PPSM などのマクロ有効ファイルとして保存できます。