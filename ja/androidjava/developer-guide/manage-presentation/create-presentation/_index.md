---
title: Androidでプレゼンテーションを作成
linktitle: プレゼンテーションの作成
type: docs
weight: 10
url: /ja/androidjava/create-presentation/
keywords:
- プレゼンテーションの作成
- 新しいプレゼンテーション
- PPTの作成
- 新しいPPT
- PPTXの作成
- 新しいPPTX
- ODPの作成
- 新しいODP
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して Java でプレゼンテーションを作成し、PPT、PPTX、ODP ファイルを生成し、OpenDocument のサポートを活用し、プログラムで保存して確実な結果を得られます。"
---

## **PowerPoint プレゼンテーションの作成**
プレゼンテーションの選択したスライドにシンプルな直線を追加するには、以下の手順に従ってください。

1. Presentation クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. Shapes オブジェクトが提供する addAutoShape メソッドを使用して、Line タイプの AutoShape を追加します。
1. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、プレゼンテーションの最初のスライドに直線を追加しています。
```java
// プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化する
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得する
    ISlide slide = pres.getSlides().get_Item(0);

    // タイプ line のオートシェイプを追加する
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**新しいプレゼンテーションはどの形式で保存できますか？**

次の形式で保存できます: [PPTX, PPT, and ODP](/slides/ja/androidjava/save-presentation/)、また、[PDF](/slides/ja/androidjava/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/androidjava/convert-powerpoint-to-xps/)、[HTML](/slides/ja/androidjava/convert-powerpoint-to-html/)、[SVG](/slides/ja/androidjava/convert-powerpoint-to-png/)、および[images](/slides/ja/androidjava/convert-powerpoint-to-png/) などにエクスポートできます。

**テンプレート（POTX/POTM）から開始し、通常の PPTX として保存できますか？**

はい。テンプレートを読み込み、目的の形式で保存します。POTX、POTM、PPTM などの形式は[are supported](/slides/ja/androidjava/supported-file-formats/)。

**プレゼンテーション作成時にスライドサイズ/アスペクト比をどのように制御しますか？**

[slide size](/slides/ja/androidjava/slide-size/) を設定します（4:3 や 16:9 などのプリセットやカスタム寸法を含む）。コンテンツのスケーリング方法も選択できます。

**サイズや座標はどの単位で測定されますか？**

ポイント単位です。1 インチは 72 ユニットに相当します。

**メディアファイルが多数含まれる非常に大きなプレゼンテーションのメモリ使用量を削減するにはどうすればよいですか？**

[BLOB management strategies](/slides/ja/androidjava/manage-blob/) を使用し、一時ファイルを活用してメモリ内の保存を制限し、純粋なメモリストリームよりもファイルベースのワークフローを優先します。

**プレゼンテーションを並列に作成/保存できますか？**

同一の[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) インスタンスを[multiple threads](/slides/ja/androidjava/multithreading/)から操作することはできません。スレッドまたはプロセスごとに別々の、分離されたインスタンスを実行してください。

**試用版の透かしや制限を削除するにはどうすればよいですか？**

[Apply a license](/slides/ja/androidjava/licensing/) をプロセスごとに一度実行します。ライセンス XML は変更せず、その設定は複数スレッドが関与する場合は同期させる必要があります。

**作成した PPTX にデジタル署名を付けることができますか？**

はい。[Digital signatures](/slides/ja/androidjava/digital-signature-in-powerpoint/) （追加および検証）はプレゼンテーションでサポートされています。

**作成したプレゼンテーションでマクロ（VBA）はサポートされていますか？**

はい。[create/edit VBA projects](/slides/ja/androidjava/presentation-via-vba/) が可能で、PPTM/PPSM などのマクロ対応ファイルとして保存できます。