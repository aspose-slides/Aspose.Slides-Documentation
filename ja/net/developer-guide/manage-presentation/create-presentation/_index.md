---
title: .NET でプレゼンテーションを作成
linktitle: プレゼンテーションの作成
type: docs
weight: 10
url: /ja/net/create-presentation/
keywords: "PowerPoint の作成, PPTX, PPT, プレゼンテーションの作成, プレゼンテーションの初期化, C#, .NET"
description: "C# で PowerPoint プレゼンテーションをプログラム的に作成 (例: PPT, PPTX, ODP など)"
---

## **PowerPoint プレゼンテーションの作成**
プレゼンテーションの選択されたスライドにシンプルな直線を追加するには、以下の手順に従ってください。

1. Presentation クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. Shapes オブジェクトが提供する AddAutoShape メソッドを使用して、Line タイプの AutoShape を追加します。
4. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、プレゼンテーションの最初のスライドに直線を追加しています。
```c#
 // プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
 using (Presentation presentation = new Presentation())
 {
     // 最初のスライドを取得します
     ISlide slide = presentation.Slides[0];

     // ラインタイプのオートシェイプを追加します
     slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
     presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
 }
```


## **プレゼンテーションの作成と保存**

<a name="csharp-create-save-presentation"><strong>手順: C# でプレゼンテーションを作成して保存</strong></a>

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. _Presentation_ を [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) がサポートする任意の形式で保存します。
```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **プレゼンテーションの開くと保存**

<a name="csharp-open-save-presentation"><strong>手順: C# でプレゼンテーションを開くと保存</strong></a>

1. 任意の形式（PPT、PPTX、ODP など）で [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. _Presentation_ を [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) がサポートする任意の形式で保存します。
```c#
// Presentation でサポートされている任意のファイルを読み込みます（例：ppt、pptx、odp など）
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **よくある質問**

**新しいプレゼンテーションをどの形式で保存できますか？**

次のリンク先の形式で保存できます: [PPTX、PPT、ODP](/slides/ja/net/save-presentation/)、また、[PDF](/slides/ja/net/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/net/convert-powerpoint-to-xps/)、[HTML](/slides/ja/net/convert-powerpoint-to-html/)、[SVG](/slides/ja/net/convert-powerpoint-to-png/)、および [images](/slides/ja/net/convert-powerpoint-to-png/) などにエクスポートできます。

**テンプレート（POTX/POTM）から開始し、通常の PPTX として保存できますか？**

はい。テンプレートを読み込み、目的の形式で保存できます。POTX、POTM、PPTM などの形式は [サポートされています](/slides/ja/net/supported-file-formats/)。

**プレゼンテーション作成時にスライドサイズ/アスペクト比を制御するにはどうすればよいですか？**

[スライドサイズ](/slides/ja/net/slide-size/) を設定します（4:3 や 16:9 などのプリセットまたはカスタム寸法を含む）。コンテンツのスケール方法を選択します。

**サイズと座標はどの単位で測定されますか？**

ポイント単位です。1 インチは 72 ユニットに相当します。

**多数のメディアファイルを含む非常に大きなプレゼンテーションのメモリ使用量を削減するにはどうすればよいですか？**

[BLOB 管理戦略](/slides/ja/net/manage-blob/) を使用し、一時ファイルを活用してメモリ内保存を制限し、純粋なインメモリ ストリームよりもファイルベースのワークフローを優先します。

**プレゼンテーションを並行して作成/保存できますか？**

同じ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) インスタンスを [複数のスレッド](/slides/ja/net/multithreading/) から操作することはできません。スレッドまたはプロセスごとに別々の、分離されたインスタンスを実行してください。

**トライアルの透かしと制限を削除するにはどうすればよいですか？**

プロセスごとに一度、[ライセンスを適用](/slides/ja/net/licensing/)してください。ライセンス XML は変更せず、複数スレッドが関与する場合はライセンス設定を同期させる必要があります。

**作成した PPTX にデジタル署名できますか？**

はい。プレゼンテーションは [デジタル署名](/slides/ja/net/digital-signature-in-powerpoint/)（追加と検証）がサポートされています。

**作成したプレゼンテーションでマクロ（VBA）はサポートされていますか？**

はい。VBA プロジェクトの [作成/編集](/slides/ja/net/presentation-via-vba/) が可能で、PPTM/PPSM などのマクロ有効ファイルとして保存できます。