---
title: PPTX におけるチャートリサイズの実装ソリューション
type: docs
weight: 60
url: /ja/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- チャートリサイズ
- Excel チャート
- OLE オブジェクト
- チャートを埋め込む
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET の埋め込み Excel OLE オブジェクトを使用した際に、PPTX の予期しないチャートリサイズを修正します。サイズを一貫させるためのコード付き二つの方法を学びましょう。"
---

## **背景**

Aspose コンポーネントを使用して PowerPoint プレゼンテーションに OLE オブジェクトとして埋め込まれた Excel チャートは、最初にアクティブ化された後、未指定のスケールにリサイズされることが確認されています。この動作により、チャートのアクティブ化前後でプレゼンテーションの見た目に顕著な違いが生じます。Aspose チームはこの問題を詳細に調査し、解決策を見つけました。本稿では問題の原因とそれに対応する修正について説明します。

前の記事](/slides/ja/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)では、Aspose.Cells for .NET を使用して Excel チャートを作成し、Aspose.Slides for .NET を使用して PowerPoint プレゼンテーションに埋め込む方法を説明しました。[オブジェクト プレビューの問題](/slides/ja/net/object-preview-issue-when-adding-oleobjectframe/)に対処するため、チャート画像をチャートの OLE オブジェクト フレームに割り当てました。出力されたプレゼンテーションでは、チャート画像を表示する OLE オブジェクト フレームをダブルクリックすると Excel チャートがアクティブ化されます。エンドユーザーは基になる Excel ワークブックで任意の変更を行い、アクティブ化されたワークブックの外側をクリックすることで該当スライドに戻ります。ユーザーがスライドに戻ると OLE オブジェクト フレームのサイズが変わり、リサイズ率は OLE オブジェクト フレームと埋め込まれた Excel ワークブックの元のサイズに依存します。

## **リサイズの原因**

Excel ワークブックには独自のウィンドウサイズがあるため、最初にアクティブ化された際に元のサイズを保持しようとします。一方、OLE オブジェクト フレームにも独自のサイズがあります。Microsoft の説明によると、Excel ワークブックがアクティブ化されると、Excel と PowerPoint がサイズを協議し、埋め込みプロセスの一環として正しいアスペクト比を維持します。Excel のウィンドウサイズと OLE オブジェクト フレームのサイズまたは位置の差に応じて、リサイズが発生します。

## **実装ソリューション**

Aspose.Slides for .NET を使用して PowerPoint プレゼンテーションを作成する場合、2 つのシナリオが考えられます。

**Scenario 1:** 既存のテンプレートを基にプレゼンテーションを作成する。

**Scenario 2:** ゼロからプレゼンテーションを作成する。

ここで提示するソリューションは両シナリオに適用できます。すべてのアプローチの基本は同じで、**埋め込まれた OLE オブジェクトのウィンドウサイズを PowerPoint スライドの OLE オブジェクト フレームと一致させる**ことです。以下でこのソリューションの 2 つのアプローチについて説明します。

## **最初のアプローチ**

このアプローチでは、埋め込まれた Excel ワークブックのウィンドウサイズを PowerPoint スライドの OLE オブジェクト フレームのサイズと一致させる方法を学びます。

**シナリオ 1**

テンプレートを定義済みで、そこからプレゼンテーションを作成したいとします。テンプレートのインデックス 2 に OLE フレーム（埋め込まれた Excel ワークブックを含む）を配置したいシェイプがあると想定します。このシナリオでは、OLE オブジェクト フレームのサイズは事前に決まっており、テンプレートのインデックス 2 のシェイプのサイズと一致しています。やるべきことは、ワークブックのウィンドウサイズをそのシェイプのサイズと同じに設定することだけです。以下のコードスニペットがその目的を果たします：
```cs
// ウィンドウでチャートのサイズを定義します。
chart.SizeWithWindow = true;

// ワークブックのウィンドウ幅をインチ単位で設定します（PowerPoint は 1 インチあたり 72 ピクセルを使用するため、72 で除算します）。
workbook.Worksheets.WindowWidthInch = slide.Shapes[2].Width / 72f;

// ワークブックのウィンドウ高さをインチ単位で設定します。
workbook.Worksheets.WindowHeightInch = slide.Shapes[2].Height / 72f;

// ワークブックをメモリストリームに保存します。
MemoryStream workbookStream = workbook.SaveToStream();

// 埋め込み Excel データで OLE オブジェクトフレームを作成します。
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


**シナリオ 2**

ゼロからプレゼンテーションを作成し、任意のサイズの OLE オブジェクト フレームに埋め込まれた Excel ワークブックを含めたいとします。以下のコードスニペットでは、スライド上の x = 0.5 インチ、y = 1 インチの位置に高さ 4 インチ、幅 9.5 インチの OLE オブジェクト フレームを作成します。その後、Excel ワークブックのウィンドウを同じサイズ（高さ 4 インチ、幅 9.5 インチ）に設定します。
```cs
// 任意の高さです。
int desiredHeight = 288; // 4 インチ (4 * 72)

// 任意の幅です。
int desiredWidth = 684; // 9.5 インチ (9.5 * 72)

// ウィンドウでチャートのサイズを定義します。
chart.SizeWithWindow = true;

// ワークブックのウィンドウ幅をインチ単位で設定します。
workbook.Worksheets.WindowWidthInch = desiredWidth / 72f;

// ワークブックのウィンドウ高さをインチ単位で設定します。
workbook.Worksheets.WindowHeightInch = desiredHeight / 72f;

// ワークブックをメモリストリームに保存します。
MemoryStream workbookStream = workbook.SaveToStream();

// 埋め込み Excel データで OLE オブジェクトフレームを作成します。
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


## **第二のアプローチ**

このアプローチでは、埋め込まれた Excel ワークブック内のチャートのサイズを PowerPoint スライドの OLE オブジェクト フレームのサイズと一致させる方法を学びます。チャートのサイズが事前に分かっており、変更されない場合に有用です。

**シナリオ 1**

テンプレートを定義し、そこからプレゼンテーションを作成したいとします。テンプレートのインデックス 2 に埋め込まれた Excel ワークブックを含む OLE フレームを配置するシェイプがあると想定します。このシナリオでは、OLE フレームのサイズは事前に決まっており、テンプレートのインデックス 2 のシェイプのサイズと一致しています。必要なのは、ワークブック内のチャートサイズをそのシェイプのサイズと同じに設定することだけです。以下のコードスニペットがその目的を果たします：
```cs
// ウィンドウなしでチャートのサイズを定義します。
chart.SizeWithWindow = false;

// ピクセル単位でチャートの幅を設定します（Excel はインチあたり 96 ピクセルを使用するため 96 倍します）。
chart.ChartObject.Width = (int)((slide.Shapes[2].Width / 72f) * 96f);

// ピクセル単位でチャートの高さを設定します。
chart.ChartObject.Height = (int)((slide.Shapes[2].Height / 72f) * 96f;

// チャートの印刷サイズを定義します。
chart.PrintSize = PrintSizeType.Custom;

// ワークブックをメモリストリームに保存します。
MemoryStream workbookStream = workbook.SaveToStream();

// 埋め込み Excel データで OLE オブジェクトフレームを作成します。
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


**シナリオ 2**

ゼロからプレゼンテーションを作成し、任意のサイズの OLE オブジェクト フレームに埋め込まれた Excel ワークブックを含めたいとします。以下のコードスニペットでは、スライド上の x = 0.5 インチ、y = 1 インチの位置に高さ 4 インチ、幅 9.5 インチの OLE オブジェクト フレームを作成します。また、対応するチャートサイズも同じ寸法（高さ 4 インチ、幅 9.5 インチ）に設定します。
```cs
 // 目的の高さです。
int desiredHeight = 288; // 4 インチ (4 * 576)

// 目的の幅です。
int desiredWidth = 684; // 9.5 インチ (9.5 * 576)

// ウィンドウなしでチャートのサイズを定義します。 
chart.SizeWithWindow = false;

// ピクセル単位でチャートの幅を設定します。   
chart.ChartObject.Width = (int)((desiredWidth / 72f) * 96f);

// ピクセル単位でチャートの高さを設定します。    
chart.ChartObject.Height = (int)((desiredHeight / 72f) * 96f);

// ワークブックをメモリストリームに保存します。
MemoryStream workbookStream = workbook.SaveToStream();

// 埋め込みExcelデータでOLEオブジェクトフレームを作成します。
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream ToArray());
```


## **結論**

チャートリサイズ問題を解決するためのアプローチは 2 つあります。どのアプローチを選択するかは要件やユースケースに依存します。どちらのアプローチも、テンプレートから作成する場合でもゼロから作成する場合でも同様に機能します。また、このソリューションでは OLE オブジェクト フレームのサイズに制限はありません。

## **よくある質問**

**PowerPoint で埋め込んだ Excel チャートをアクティブ化するとサイズが変わるのはなぜですか？**  
これは、Excel が最初にアクティブ化されたときに元のウィンドウサイズを復元しようとし、一方 PowerPoint の OLE オブジェクト フレームは独自のサイズを持っているために起こります。PowerPoint と Excel がサイズを協議してアスペクト比を維持する際に、リサイズが発生することがあります。

**このリサイズ問題を完全に防ぐことはできますか？**  
はい。埋め込む前に Excel ワークブックのウィンドウサイズまたはチャートサイズを OLE オブジェクト フレームのサイズと一致させることで、チャートのサイズを一貫させることができます。

**どちらのアプローチを取るべきですか？ワークブックのウィンドウサイズを設定するか、チャートサイズを設定するか？**  
チャートのアスペクト比を保持し、後でリサイズできる可能性がある場合は **アプローチ 1（ウィンドウサイズ）** を使用してください。チャートのサイズが固定で埋め込み後に変更しない場合は **アプローチ 2（チャートサイズ）** を使用してください。

**これらの方法はテンプレートベースのプレゼンテーションと新規プレゼンテーションの両方で機能しますか？**  
はい。どちらのアプローチもテンプレートから作成したプレゼンテーションとゼロから作成したプレゼンテーションの両方で同様に機能します。

**OLE オブジェクト フレームのサイズに制限はありますか？**  
いいえ。OLE フレームは、ワークブックやチャートのサイズに合わせて適切にスケーリングできる限り、任意のサイズに設定できます。

**他のスプレッドシートプログラムで作成したチャートにもこれらの方法を使用できますか？**  
例は Aspose.Cells で作成した Excel チャートを対象としていますが、同様のサイズ設定オプションをサポートする OLE 互換のスプレッドシートプログラムであれば、同様の原則が適用できます。

## **関連セクション**

- [プレゼンテーションに Excel チャートを作成して OLE オブジェクトとして埋め込む](/slides/ja/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [PowerPoint アドインを使用して OLE オブジェクトを自動的に更新する](/slides/ja/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)