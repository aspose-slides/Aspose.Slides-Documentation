---
title: PPTXでのチャートサイズ変更に対する実用的な解決策
type: docs
weight: 60
url: /ja/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- チャートサイズ変更
- Excelチャート
- OLEオブジェクト
- 埋め込みチャート
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して埋め込み Excel OLE オブジェクトを利用する際の PPTX における予期しないチャートサイズ変更を修正します。サイズを一貫させる 2 つの手法とコード例を学びましょう。"
---

## **背景**

Aspose コンポーネントを使用して PowerPoint プレゼンテーションに OLE オブジェクトとして埋め込まれた Excel グラフが、最初にアクティブ化された後に未指定のスケールにリサイズされることが観測されています。この動作により、グラフのアクティブ化前後でプレゼンテーションの見た目に顕著な違いが生じます。Aspose チームはこの問題を詳細に調査し、解決策を見つけました。本記事では問題の原因とそれに対する修正を説明します。

[前の記事](/slides/ja/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)では、Aspose.Cells for .NET で Excel グラフを作成し、Aspose.Slides for .NET を使用して PowerPoint プレゼンテーションに埋め込む方法を解説しました。[オブジェクト プレビューの問題](/slides/ja/net/object-preview-issue-when-adding-oleobjectframe/)に対処するため、グラフ画像を OLE オブジェクト フレームに割り当てました。出力されたプレゼンテーションで、グラフ画像を表示している OLE オブジェクト フレームをダブルクリックすると Excel グラフがアクティブ化されます。エンド ユーザーは基になる Excel ワークブックで任意の変更を行い、アクティブ化されたワークブックの外側をクリックすることで該当スライドに戻れます。ユーザーがスライドに戻ると OLE オブジェクト フレームのサイズが変わり、リサイズ率は OLE オブジェクト フレームと埋め込まれた Excel ワークブックの元のサイズに依存します。

## **サイズ変更の原因**

Excel ワークブックは独自のウィンドウサイズを持っており、最初のアクティブ化時に元のサイズを保持しようとします。一方、OLE オブジェクト フレームにも独自のサイズがあります。Microsoft によれば、Excel ワークブックがアクティブ化されると、Excel と PowerPoint がサイズを協議し、埋め込みプロセスの一部として正しい比率を保ちます。Excel のウィンドウサイズと OLE オブジェクト フレームのサイズまたは位置の違いに応じて、サイズ変更が発生します。

## **動作する解決策**

Aspose.Slides for .NET を使用して PowerPoint プレゼンテーションを作成するシナリオは 2 つあります。

**シナリオ 1:** 既存のテンプレートを基にプレゼンテーションを作成する。  
**シナリオ 2:** ゼロからプレゼンテーションを作成する。

ここで提示する解決策は両シナリオに適用できます。すべてのアプローチの基本は同じです：**埋め込まれた OLE オブジェクトのウィンドウサイズを PowerPoint スライド上の OLE オブジェクト フレームと一致させる**。以下で 2 つのアプローチを説明します。

## **アプローチ 1**

このアプローチでは、埋め込まれた Excel ワークブックのウィンドウサイズを PowerPoint スライド上の OLE オブジェクト フレームのサイズと一致させる方法を学びます。

**シナリオ 1**  

テンプレートを定義し、そのテンプレートに基づいてプレゼンテーションを作成したいとします。テンプレートのインデックス 2 に OLE フレーム（埋め込み Excel ワークブックを含む）を配置したいと想定します。このシナリオでは、OLE オブジェクト フレームのサイズは事前に決まっており、テンプレートのインデックス 2 のシェイプのサイズと一致します。必要なのは、ワークブックのウィンドウサイズをそのシェイプのサイズと同じに設定することだけです。以下のコード スニペットがその目的を果たします。
```cs
// ウィンドウを使用してチャートのサイズを設定します。 
chart.SizeWithWindow = true;

// ワークブックのウィンドウ幅をインチ単位で設定します（PowerPointは1インチあたり72ピクセルなので72で割ります）。
workbook.Worksheets.WindowWidthInch = slide.Shapes[2].Width / 72f;

// ワークブックのウィンドウ高さをインチ単位で設定します。
workbook.Worksheets.WindowHeightInch = slide.Shapes[2].Height / 72f;

// ワークブックをメモリストリームに保存します。
MemoryStream workbookStream = workbook.SaveToStream();

// 埋め込まれた Excel データで OLE オブジェクトフレームを作成します。
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


**シナリオ 2**  

ゼロからプレゼンテーションを作成し、任意のサイズの OLE オブジェクト フレームに埋め込み Excel ワークブックを含めたいとします。以下のコード スニペットでは、スライド上の x = 0.5 インチ、y = 1 インチの位置に高さ 4 インチ、幅 9.5 インチの OLE オブジェクト フレームを作成し、Excel ワークブックのウィンドウも同じサイズ（高さ 4 インチ、幅 9.5 インチ）に設定します。
```cs
// 目的の高さ。
int desiredHeight = 288; // 4 インチ (4 * 72)

// 目的の幅。
int desiredWidth = 684;//9.5 インチ (9.5 * 72)

// ウィンドウを使用してチャートのサイズを定義します。
chart.SizeWithWindow = true;

// ワークブックのウィンドウ幅をインチ単位で設定します。
workbook.Worksheets.WindowWidthInch = desiredWidth / 72f;

// ワークブックのウィンドウ高さをインチ単位で設定します。
workbook.Worksheets.WindowHeightInch = desiredHeight / 72f;

// ワークブックをメモリストリームに保存します。
MemoryStream workbookStream = workbook.SaveToStream();

// 埋め込まれた Excel データで OLE オブジェクトフレームを作成します。
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


## **アプローチ 2**

このアプローチでは、埋め込まれた Excel ワークブック内のチャートのサイズを PowerPoint スライド上の OLE オブジェクト フレームのサイズと一致させる方法を学びます。このアプローチは、チャートのサイズが事前に分かっていて変更されない場合に有効です。

**シナリオ 1**  

テンプレートを定義し、そのテンプレートに基づいてプレゼンテーションを作成したいとします。テンプレートのインデックス 2 に OLE フレーム（埋め込み Excel ワークブックを含む）を配置したいと想定します。このシナリオでは、OLE フレームのサイズは事前に決まっており、テンプレートのインデックス 2 のシェイプのサイズと一致します。必要なのは、ワークブック内のチャートサイズをそのシェイプのサイズと同じに設定することだけです。以下のコード スニペットがその目的を果たします。
```cs
// ウィンドウなしでチャートサイズを定義します。 
chart.SizeWithWindow = false;

// ピクセル単位でチャート幅を設定します（Excelはインチあたり96ピクセルを使用するため96倍します）。
chart.ChartObject.Width = (int)((slide.Shapes[2].Width / 72f) * 96f);

// ピクセル単位でチャートの高さを設定します。
chart.ChartObject.Height = (int)((slide.Shapes[2].Height / 72f) * 96f);

// チャートの印刷サイズを定義します。
chart.PrintSize = PrintSizeType.Custom;

// ワークブックをメモリストリームに保存します。
MemoryStream workbookStream = workbook.SaveToStream();

// 埋め込まれたExcelデータでOLEオブジェクトフレームを作成します。
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


**シナリオ 2**  

ゼロからプレゼンテーションを作成し、任意のサイズの OLE オブジェクト フレームに埋め込み Excel ワークブックを含めたいとします。以下のコード スニペットでは、スライド上の x = 0.5 インチ、y = 1 インチの位置に高さ 4 インチ、幅 9.5 インチの OLE オブジェクト フレームを作成し、対応するチャートサイズも同じ寸法（高さ 4 インチ、幅 9.5 インチ）に設定します。
```cs
 // 目的の高さ。
int desiredHeight = 288; // 4 インチ (4 * 576)

// 目的の幅。
int desiredWidth = 684; // 9.5 インチ (9.5 * 576)

// ウィンドウなしでチャートサイズを定義します。 
chart.SizeWithWindow = false;

// ピクセル単位でチャート幅を設定します。   
chart.ChartObject.Width = (int)((desiredWidth / 72f) * 96f);

// ピクセル単位でチャート高さを設定します。    
chart.ChartObject.Height = (int)((desiredHeight / 72f) * 96f);

// ワークブックをメモリストリームに保存します。
MemoryStream workbookStream = workbook.SaveToStream();

// 埋め込まれた Excel データで OLE オブジェクトフレームを作成します。
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


## **結論**

チャートのサイズ変更問題を解決する方法は 2 つあります。どちらのアプローチを選択するかは要件とユースケースに依存します。テンプレートから作成する場合でも、ゼロから作成する場合でも、両アプローチは同様に機能します。また、このソリューションでは OLE オブジェクト フレームのサイズに制限はありません。

## FAQ

**Q: なぜ PowerPoint で埋め込んだ Excel グラフはアクティブ化後にサイズが変わるのですか？**  
Excel は最初にアクティブ化されたときに元のウィンドウサイズを復元しようとしますが、PowerPoint の OLE オブジェクト フレームは独自の寸法を持っています。PowerPoint と Excel がサイズを協議してアスペクト比を維持するため、リサイズが発生します。

**Q: このリサイズ問題を完全に防ぐことはできますか？**  
はい。埋め込む前に Excel ワークブックのウィンドウサイズまたはチャートサイズを OLE オブジェクト フレームのサイズと一致させることで、サイズのずれを防げます。

**Q: ワークブックのウィンドウサイズを設定すべきか、チャートサイズを設定すべきか、どちらのアプローチを取るべきですか？**  
ワークブックのアスペクト比を保持し、後でリサイズを許可したい場合は **アプローチ 1（ウィンドウサイズ）** を使用してください。  
チャートの寸法が固定で埋め込み後に変更しない場合は **アプローチ 2（チャートサイズ）** を使用してください。

**Q: これらの方法はテンプレートベースのプレゼンテーションと新規作成の両方で機能しますか？**  
はい。両アプローチはテンプレートから作成したプレゼンテーションでも、ゼロから作成したプレゼンテーションでも同様に機能します。

**Q: OLE オブジェクト フレームのサイズに上限はありますか？**  
ありません。ワークブックまたはチャートのサイズに合わせて適切にスケーリングできる限り、任意のサイズを設定できます。

**Q: 他のスプレッドシート プログラムで作成したグラフにもこの方法は使えますか？**  
例は Aspose.Cells で作成した Excel グラフを対象としていますが、同様のサイズ指定オプションをサポートする OLE 互換のスプレッドシート プログラムでも原則は適用できます。

## **関連セクション**

- [Excel グラフを作成し、OLE オブジェクトとしてプレゼンテーションに埋め込む](/slides/ja/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [PowerPoint アドインを使用して OLE オブジェクトを自動的に更新する](/slides/ja/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)