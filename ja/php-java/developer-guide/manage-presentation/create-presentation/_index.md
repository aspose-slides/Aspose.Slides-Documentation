---
title: PHPでプレゼンテーションを作成
linktitle: プレゼンテーションの作成
type: docs
weight: 10
url: /ja/php-java/create-presentation/
keywords:
- プレゼンテーション作成
- 新しいプレゼンテーション
- PPT作成
- 新しいPPT
- PPTX作成
- 新しいPPTX
- ODP作成
- 新しいODP
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用してプレゼンテーションを作成します。PPT、PPTX、ODP ファイルを生成し、信頼できる結果を得るためにプログラムで保存します。"
---

## **プレゼンテーションの作成**

プレゼンテーションの選択したスライドにシンプルな直線を追加するには、以下の手順に従ってください。

1. Presentation クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. Shapes オブジェクトが提供する addAutoShape メソッドを使用して、Line タイプの AutoShape を追加します。
1. 変更したプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、プレゼンテーションの最初のスライドに直線を追加しています。
```php
  # プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化する
  $pres = new Presentation();
  try {
    # 最初のスライドを取得する
    $slide = $pres->getSlides()->get_Item(0);
    # タイプがラインのオートシェイプを追加する
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**新しいプレゼンテーションはどの形式で保存できますか？**

以下のリンク先に示すように [PPTX、PPT、および ODP](/slides/ja/php-java/save-presentation/) 形式で保存でき、[PDF](/slides/ja/php-java/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/php-java/convert-powerpoint-to-xps/)、[HTML](/slides/ja/php-java/convert-powerpoint-to-html/)、[SVG](/slides/ja/php-java/convert-powerpoint-to-png/)、[画像](/slides/ja/php-java/convert-powerpoint-to-png/) などにエクスポートできます。

**テンプレート（POTX/POTM）から開始し、通常の PPTX として保存できますか？**

はい。テンプレートをロードし、目的の形式で保存できます。POTX、POTM、PPTM などの形式は [サポートされています](/slides/ja/php-java/supported-file-formats/)。

**プレゼンテーション作成時にスライドのサイズやアスペクト比を制御するには？**

スライドサイズ（4:3 や 16:9 などのプリセット、またはカスタム寸法）を [スライドサイズ](/slides/ja/php-java/slide-size/) で設定し、コンテンツのスケーリング方法を選択します。

**サイズや座標はどの単位で測定されますか？**

ポイント単位です。1 インチは 72 ユニットに相当します。

**多数のメディアファイルを含む非常に大きなプレゼンテーションのメモリ使用量を削減するには？**

[BLOB 管理戦略](/slides/ja/php-java/manage-blob/) を使用し、一時ファイルを活用してメモリ内ストレージを制限し、純粋なメモリストリームよりもファイルベースのワークフローを優先します。

**プレゼンテーションを並行して作成/保存できますか？**

同じ [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) インスタンスを [複数のスレッド](/slides/ja/php-java/multithreading/) から操作することはできません。スレッドまたはプロセスごとに別々の、独立したインスタンスを実行してください。

**トライアルの透かしと制限を削除するには？**

プロセスごとに一度 [ライセンスを適用](/slides/ja/php-java/licensing/) してください。ライセンス XML は変更せず、複数のスレッドが関与する場合はライセンス設定を同期させる必要があります。

**作成した PPTX にデジタル署名できますか？**

はい。プレゼンテーションでは [デジタル署名](/slides/ja/php-java/digital-signature-in-powerpoint/)（追加および検証）がサポートされています。

**作成したプレゼンテーションでマクロ（VBA）はサポートされていますか？**

はい。[VBA プロジェクトの作成/編集](/slides/ja/php-java/presentation-via-vba/) が可能で、PPTM や PPSM などのマクロ有効ファイルとして保存できます。