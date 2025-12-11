---
title: Android でプレゼンテーションを作成する
linktitle: プレゼンテーションの作成
type: docs
weight: 10
url: /ja/androidjava/create-presentation/
keywords:
- プレゼンテーションを作成
- 新しいプレゼンテーション
- PPT を作成
- 新しい PPT
- PPTX を作成
- 新しい PPTX
- ODP を作成
- 新しい ODP
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Android 用 Aspose.Slides for Java でプレゼンテーションを作成—PPT、PPTX、ODP ファイルを生成し、OpenDocument のサポートを活かし、プログラムで信頼性の高い結果を得るために保存します。"
---

## **PowerPoint プレゼンテーションの作成**
プレゼンテーションの選択したスライドにシンプルな直線を追加するには、以下の手順に従ってください。

1. Presentation クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. Shapes オブジェクトが提供するaddAutoShape メソッドを使用して、Line タイプの AutoShape を追加します。
1. 変更されたプレゼンテーションを PPTX ファイルとして書き込みます。

以下の例では、プレゼンテーションの最初のスライドに直線を追加しています。
```java
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);

    // タイプ line のオートシェイプを追加
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **よくある質問**

**新しいプレゼンテーションを保存できる形式は何ですか？**

PPTX、PPT、および ODP に[保存](/slides/ja/androidjava/save-presentation/)でき、[PDF](/slides/ja/androidjava/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/androidjava/convert-powerpoint-to-xps/)、[HTML](/slides/ja/androidjava/convert-powerpoint-to-html/)、[SVG](/slides/ja/androidjava/convert-powerpoint-to-png/)、および[画像](/slides/ja/androidjava/convert-powerpoint-to-png/)にエクスポートできます。

**テンプレート (POTX/POTM) から開始して、通常の PPTX として保存できますか？**

はい。テンプレートを読み込み、目的の形式で保存できます。POTX/POTM/PPTM などの形式は[サポートされています](/slides/ja/androidjava/supported-file-formats/)。

**プレゼンテーション作成時にスライドのサイズ/アスペクト比を制御するにはどうすればよいですか？**

[スライドサイズ](/slides/ja/androidjava/slide-size/) を設定します（4:3 や 16:9 などのプリセット、またはカスタム寸法を含む）。コンテンツのスケーリング方法も選択できます。

**サイズと座標はどの単位で測定されますか？**

ポイント単位です。1 インチは 72 単位に相当します。

**メディアファイルが多数ある非常に大きなプレゼンテーションのメモリ使用量を削減するにはどうすればよいですか？**

[BLOB 管理戦略](/slides/ja/androidjava/manage-blob/) を使用し、一時ファイルを活用してメモリ内ストレージを制限し、純粋なインメモリ ストリームよりもファイルベースのワークフローを優先してください。

**プレゼンテーションを並列で作成/保存できますか？**

同じ[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)インスタンスを[複数のスレッド](/slides/ja/androidjava/multithreading/)から操作することはできません。スレッドまたはプロセスごとに別々の独立したインスタンスを実行してください。

**体験版の透かしと制限を削除するにはどうすればよいですか？**

プロセスごとに一度だけ[ライセンスを適用](/slides/ja/androidjava/licensing/)してください。ライセンス XML は変更せずに保持し、複数スレッドが関与する場合はライセンス設定を同期させる必要があります。

**作成した PPTX にデジタル署名できますか？**

はい。[デジタル署名](/slides/ja/androidjava/digital-signature-in-powerpoint/)（追加および検証）がプレゼンテーションでサポートされています。

**作成したプレゼンテーションでマクロ (VBA) はサポートされていますか？**

はい。[VBA プロジェクトの作成/編集](/slides/ja/androidjava/presentation-via-vba/) が可能で、PPTM/PPSM などのマクロ対応ファイルとして保存できます。