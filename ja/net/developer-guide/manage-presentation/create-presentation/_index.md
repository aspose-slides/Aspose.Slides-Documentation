---
title: .NETでプレゼンテーションを作成
linktitle: プレゼンテーションの作成
type: docs
weight: 10
url: /ja/net/create-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して .NET でプレゼンテーションを作成します—PPT、PPTX、ODP ファイルを生成し、OpenDocument のサポートを活用し、プログラムで保存して確実な結果を得られます。"
---
## **概要**

この記事では、Aspose.Slidesでプレゼンテーションを作成し、最初のスライドにテキストボックスを追加してファイルとして保存する方法を示します。また、空のプレゼンテーションを作成して保存する方法、サポートされている形式の既存プレゼンテーションを開いて別の形式で保存する方法も紹介します。最後の短いFAQでは、形式、テンプレート、スライドサイズ、単位、メモリ使用量、スレッド処理、ライセンス、デジタル署名、VBAサポートに関するよくある質問を取り上げています。

始める前に、NuGetからAspose.Slidesをプロジェクトに追加してください。[Installation](/slides/ja/net/installation/)をご覧ください。

## **PowerPoint プレゼンテーションの作成**

プレゼンテーションを作成し、最初のスライドにテキストボックスを配置するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスのインスタンスを作成します。新しいプレゼンテーションには既に空のスライドが1枚含まれています。
2. [Slides](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/slides/ja/) コレクションからインデックス0でそのスライドを取得します。
3. [AddAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/addautoshape/) メソッドで矩形を追加し、その [text](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/text/) を設定します。
4. [Save](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/save/) メソッドを使用してプレゼンテーションを PPTX ファイルとして保存します。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

矩形の左上隅はスライドの左端から50ポイント、上端から50ポイントの位置にあり、幅が400ポイント、高さが100ポイントです。保存されたファイルにはその矩形とテキストを含むスライドが1枚含まれます。ライセンスがない場合、Aspose.Slides は保存するすべてのスライドに評価用の透かしを追加します；[Licensing](/slides/ja/net/licensing/)をご覧ください。

## **プレゼンテーションの作成と保存**

<a name="csharp-create-save-presentation"></a>

空のプレゼンテーションを作成して保存するには、[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスのインスタンスを作成し、[SaveFormat](https://reference.aspose.com/slides/ja/net/aspose.slides.export/saveformat/) 列挙体の任意の形式で保存します。結果は空のスライドが1枚含まれるプレゼンテーションになります。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **プレゼンテーションの開くと保存**

<a name="csharp-open-save-presentation"></a>

プレゼンテーションを別の形式に変換するには、パスを [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/presentation/) コンストラクタに渡して開き、目的の形式で保存します。Aspose.Slides はファイル自体から入力形式（PPT、PPTX、ODP など）を検出します。

以下の例は、作業ディレクトリに *Sample.odp* という名前の OpenDocument プレゼンテーションがあることを想定し、PPTX として保存します。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.odp");
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **FAQ**

### 新しいプレゼンテーションを保存できる形式は何ですか？

[PPTX、PPT、ODP](/slides/ja/net/save-presentation/) に保存でき、[PDF](/slides/ja/net/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/net/convert-powerpoint-to-xps/)、[HTML](/slides/ja/net/convert-powerpoint-to-html/)、[SVG](/slides/ja/net/render-a-slide-as-an-svg-image/)、および[画像](/slides/ja/net/convert-powerpoint-to-png/) などにエクスポートできます。

### テンプレート（POTX/POTM）から開始し、通常の PPTX として保存できますか？

はい。テンプレートを読み込み、目的の形式で保存します。POTX、POTM、PPTM などの形式は[サポートされています](/slides/ja/net/supported-file-formats/)。

### プレゼンテーション作成時にスライドサイズ／アスペクト比を制御するにはどうすればよいですか？

[スライドサイズ](/slides/ja/net/slide-size/) を設定します（4:3 や 16:9 といったプリセットやカスタム寸法を含む）そしてコンテンツのスケーリング方法を選択します。

### サイズや座標はどの単位で測定されますか？

ポイントで測定されます。1 インチは 72 ユニットです。

### メディアファイルが多数ある非常に大きなプレゼンテーションのメモリ使用量を削減するにはどうすればよいですか？

[BLOB 管理戦略](/slides/ja/net/manage-blob/) を使用し、一時ファイルを活用してメモリ内ストレージを制限し、純粋にメモリ内ストリームよりもファイルベースのワークフローを優先します。

### プレゼンテーションを並列で作成/保存できますか？

同じ [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) インスタンスを[複数のスレッド](/slides/ja/net/multithreading/) から操作することはできません。スレッドまたはプロセスごとに別々の、隔離されたインスタンスを実行してください。

### 評価版の透かしと制限を削除するにはどうすればよいですか？

プロセスごとに1回[ライセンスを適用](/slides/ja/net/licensing/)します。ライセンス XML は変更せずに残す必要があり、複数スレッドが関与する場合はライセンス設定を同期させる必要があります。

### 作成した PPTX にデジタル署名できますか？

はい。[デジタル署名](/slides/ja/net/digital-signature-in-powerpoint/)（追加および検証）はプレゼンテーションでサポートされています。

### 作成したプレゼンテーションでマクロ（VBA）はサポートされていますか？

はい。[VBA プロジェクトの作成/編集](/slides/ja/net/presentation-via-vba/) が可能で、PPTM や PPSM などのマクロ有効ファイルとして保存できます。