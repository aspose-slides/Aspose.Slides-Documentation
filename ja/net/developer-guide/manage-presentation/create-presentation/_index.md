---
title: .NETでプレゼンテーションを作成
linktitle: プレゼンテーションの作成
type: docs
weight: 10
url: /ja/net/create-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して .NET でプレゼンテーションを作成し、PPT、PPTX、ODP ファイルを生成し、OpenDocument のサポートを活用し、プログラムで保存して信頼できる結果を得ることができます。"
---

## **PowerPoint プレゼンテーションの作成**
プレゼンテーションの選択されたスライドにシンプルな直線を追加するには、以下の手順に従ってください:

1. Presentation クラスのインスタンスを作成します。
1. スライドのインデックスを使用してスライドの参照を取得します。
1. Shapes オブジェクトが提供する AddAutoShape メソッドを使用して、Line タイプの AutoShape を追加します。
1. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、プレゼンテーションの最初のスライドに直線を追加しています。
```c#
// プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します
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
<a name="csharp-create-save-presentation"><strong>手順: C# でプレゼンテーションを作成および保存</strong></a>

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. _Presentation_ を [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) がサポートする任意の形式で保存します。
```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **プレゼンテーションの開閉と保存**
<a name="csharp-open-save-presentation"><strong>手順: C# でプレゼンテーションを開いて保存</strong></a>

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを任意の形式（例: PPT、PPTX、ODP など）で作成します。
2. _Presentation_ を [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) がサポートする任意の形式で保存します。
```c#
// Presentation でサポートされている任意のファイル（例: ppt、pptx、odp など）をロードします。
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **よくある質問**

**新しいプレゼンテーションを保存できる形式は何ですか？**

以下に保存できます: [PPTX, PPT, and ODP](/slides/ja/net/save-presentation/)、また、[PDF](/slides/ja/net/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/net/convert-powerpoint-to-xps/)、[HTML](/slides/ja/net/convert-powerpoint-to-html/)、[SVG](/slides/ja/net/convert-powerpoint-to-png/)、および [images](/slides/ja/net/convert-powerpoint-to-png/) などにエクスポートできます。

**テンプレート (POTX/POTM) から開始し、通常の PPTX として保存できますか？**

はい。テンプレートをロードし、目的の形式で保存します。POTX/POTM/PPTM などの形式は[サポートされています](/slides/ja/net/supported-file-formats/)。

**プレゼンテーション作成時にスライドサイズ/アスペクト比を制御するにはどうすればよいですか？**

[slide size](/slides/ja/net/slide-size/) を設定します（4:3 や 16:9 などのプリセットやカスタム寸法を含む）し、コンテンツのスケーリング方法を選択します。

**サイズや座標はどの単位で測定されますか？**

ポイント単位です。1 インチは 72 ユニットです。

**メディアファイルが多数ある非常に大きなプレゼンテーションのメモリ使用量を削減するにはどうすればよいですか？**

[BLOB management strategies](/slides/ja/net/manage-blob/) を使用し、テンポラリファイルを活用してメモリ内ストレージを制限し、純粋にメモリ内ストリームよりもファイルベースのワークフローを優先します。

**プレゼンテーションを並列で作成/保存できますか？**

同じ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) インスタンスを [multiple threads](/slides/ja/net/multithreading/) から操作することはできません。スレッドまたはプロセスごとに別々の独立したインスタンスを実行してください。

**試用版の透かしと制限を削除するにはどうすればよいですか？**

プロセスごとに一度[Apply a license](/slides/ja/net/licensing/) を適用します。ライセンス XML は変更せずに保持し、複数スレッドが関与する場合はライセンス設定を同期させる必要があります。

**作成した PPTX にデジタル署名を付けられますか？**

はい。プレゼンテーションでは[Digital signatures](/slides/ja/net/digital-signature-in-powerpoint/)（追加と検証）がサポートされています。

**作成したプレゼンテーションでマクロ (VBA) はサポートされていますか？**

はい。[create/edit VBA projects](/slides/ja/net/presentation-via-vba/) が可能で、PPTM/PPSM などのマクロ有効ファイルとして保存できます。