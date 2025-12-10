---
title: PPTX のチャートリサイズに関する実装ソリューション
type: docs
weight: 40
url: /ja/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- チャート リサイズ
- Excel チャート
- OLE オブジェクト
- 埋め込みチャート
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して埋め込み Excel OLE オブジェクトを利用する際に、PPTX で発生する予期しないチャートリサイズを修正します。サイズを一貫させるためのコード付き 2 つの方法を学びましょう。"
---

## **背景**

Aspose コンポーネントを介して PowerPoint プレゼンテーションに OLE オブジェクトとして埋め込まれた Excel チャートは、最初にアクティブ化された後、未指定のスケールにリサイズされることが確認されています。この動作により、チャートのアクティブ化前と後でプレゼンテーションの見た目に顕著な違いが生じます。Aspose チームは問題を詳細に調査し、解決策を見つけました。本記事では問題の原因と対応する修正方法を説明します。

[前回の記事](/slides/ja/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)では、Aspose.Cells for Java を使用して Excel チャートを作成し、Aspose.Slides for Java で PowerPoint プレゼンテーションに埋め込む方法を説明しました。[オブジェクト プレビューの問題](/slides/ja/java/object-preview-issue-when-adding-oleobjectframe/)に対処するため、チャート画像をチャートの OLE オブジェクト フレームに割り当てました。出力されたプレゼンテーションで、チャート画像を表示している OLE オブジェクト フレームをダブルクリックすると、Excel チャートがアクティブ化されます。エンドユーザーは基になる Excel ワークブックで任意の変更を行い、アクティブ化されたワークブックの外側をクリックして対応するスライドに戻ります。ユーザーがスライドに戻ると OLE オブジェクト フレームのサイズが変わり、リサイズ率は OLE オブジェクト フレームと埋め込まれた Excel ワークブックの元のサイズに依存します。

## **リサイズの原因**

Excel ワークブックは独自のウィンドウサイズを持つため、最初のアクティブ化時に元のサイズを保持しようとします。一方、OLE オブジェクト フレームにも独自のサイズがあります。Microsoft によれば、Excel ワークブックがアクティブ化されると、Excel と PowerPoint がサイズを協議し、埋め込みプロセスの一環として正しい比率を維持します。Excel ウィンドウサイズと OLE オブジェクト フレームのサイズまたは位置の差に応じて、リサイズが発生します。

## **実装ソリューション**

PowerPoint プレゼンテーションを作成する際のシナリオは 2 つあります。

**シナリオ 1:** 既存のテンプレートを基にプレゼンテーションを作成する。  
**シナリオ 2:** ゼロからプレゼンテーションを作成する。

ここで提示するソリューションは両シナリオに適用できます。すべてのアプローチの根本は同じで、**埋め込まれた OLE オブジェクトのウィンドウサイズを PowerPoint スライド上の OLE オブジェクト フレームのサイズに合わせる**ことです。以下で 2 つのアプローチを説明します。

## **アプローチ 1**

このアプローチでは、埋め込まれた Excel ワークブックのウィンドウサイズを PowerPoint スライド上の OLE オブジェクト フレームのサイズに合わせる方法を学びます。

**シナリオ 1**

テンプレートが定義されており、そのテンプレートに基づいてプレゼンテーションを作成したいとします。テンプレートのインデックス 2 にあるシェイプに埋め込み Excel ワークブックを含む OLE フレームを配置したいと想定します。このシナリオでは OLE オブジェクト フレームのサイズは事前に決まっており、テンプレートのインデックス 2 のシェイプのサイズと一致します。行うべきことは、ワークブックのウィンドウサイズをそのシェイプのサイズに設定することだけです。以下のコードスニペットがその目的を果たします:
```java
// ワークブックのウィンドウ幅をインチ単位で設定します（PowerPointは1インチあたり576ピクセルを使用するため576で除算します）。
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// ワークブックのウィンドウ高さをインチ単位で設定します。
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// ワークブックをメモリストリームに保存します。
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// 埋め込まれたExcelデータでOLEオブジェクトフレームを作成します。
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```


**シナリオ 2**

ゼロからプレゼンテーションを作成し、任意のサイズの OLE オブジェクト フレームに埋め込み Excel ワークブックを含めたいとします。次のコードスニペットでは、スライド上の x = 0.5 インチ、y = 1 インチの位置に高さ 4 インチ、幅 9.5 インチの OLE オブジェクト フレームを作成し、Excel ワークブックのウィンドウも同じ高さ 4 インチ、幅 9.5 インチに設定します。
```java
// 目的の高さ。
int desiredHeight = 288; // 4 インチ (4 * 72)
 
// 目的の幅。
int desiredWidth = 684; // 9.5 インチ (9.5 * 72)
 
// ウィンドウでチャートサイズを定義します。
chart.setSizeWithWindow(true);
 
// ワークブックのウィンドウ幅をインチ単位で設定します（PowerPoint は 1 インチあたり 576 ピクセルを使用するため 576 で除算）。
workbook.getSettings().setWindowWidthInch(desiredHeight / 72f);
 
// ワークブックのウィンドウ高さをインチ単位で設定します。
workbook.getSettings().setWindowHeightInch(desiredWidth / 72f);
 
// ワークブックをメモリストリームに保存します。
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// 埋め込まれた Excel データで OLE オブジェクトフレームを作成します。
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```


## **アプローチ 2**

このアプローチでは、埋め込まれた Excel ワークブック内のチャートサイズを PowerPoint スライド上の OLE オブジェクト フレームのサイズに合わせる方法を学びます。このアプローチは、チャートサイズが事前に分かっており、以後変更されない場合に有効です。

**シナリオ 1**

テンプレートが定義されており、そのテンプレートに基づいてプレゼンテーションを作成したいとします。テンプレートのインデックス 2 にあるシェイプに埋め込み Excel ワークブックを含む OLE フレームを配置したいと想定します。このシナリオでは OLE フレームのサイズは事前に決まっており、テンプレートのインデックス 2 のシェイプのサイズと一致します。行うべきことは、ワークブック内のチャートサイズをそのシェイプのサイズに設定することだけです。以下のコードスニペットがその目的を果たします:
```java
// ウィンドウなしでチャートサイズを定義します。
chart.setSizeWithWindow(false);
 
// チャートの幅をピクセル単位で設定します（Excelは1インチあたり96ピクセルを使用するため96倍します）。
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// チャートの高さをピクセル単位で設定します。
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// チャートの印刷サイズを定義します。
chart.setPrintSize(PrintSizeType.CUSTOM);
 
// ワークブックをメモリストリームに保存します。
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// 埋め込まれた Excel データで OLE オブジェクトフレームを作成します。
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```


**シナリオ 2:**

ゼロからプレゼンテーションを作成し、任意のサイズの OLE オブジェクト フレームに埋め込み Excel ワークブックを含めたいとします。次のコードスニペットでは、スライド上の x = 0.5 インチ、y = 1 インチの位置に高さ 4 インチ、幅 9.5 インチの OLE オブジェクト フレームを作成し、同じ寸法（高さ 4 インチ、幅 9.5 インチ）のチャートサイズを設定します。
```java
// 目的の高さ。
int desiredHeight = 288; // 4 インチ (4 * 72)
 
// 目的の幅。
int desiredWidth = 684; // 9.5 インチ (9.5 * 72)
 
// ウィンドウなしでチャートサイズを定義します。
chart.setSizeWithWindow(false);
 
// ピクセル単位でチャート幅を設定します（Excelは1インチあたり96ピクセルを使用するため96倍します）。
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 576f) * 96f));
 
// ピクセル単位でチャート高さを設定します。
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 576f) * 96f));
 
// ワークブックをメモリストリームに保存します。
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// 埋め込まれた Excel データで OLE オブジェクトフレームを作成します。
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```


## **結論**

チャートのリサイズ問題を修正するには 2 つのアプローチがあります。どちらのアプローチを選択するかは要件やユースケースに依存します。テンプレートから作成する場合でもゼロから作成する場合でも、両アプローチは同様に機能します。また、このソリューションでは OLE オブジェクト フレームのサイズに上限はありません。

## **FAQ**

**埋め込んだ Excel チャートは PowerPoint でアクティブ化した後にサイズが変わるのはなぜですか？**  
Excel は最初にアクティブ化されたときに元のウィンドウサイズを復元しようとしますが、PowerPoint の OLE オブジェクト フレームは独自の寸法を持っています。PowerPoint と Excel がサイズを協議してアスペクト比を維持する際にリサイズが発生します。

**このリサイズ問題を完全に防ぐことは可能ですか？**  
はい。埋め込む前に Excel ワークブックのウィンドウサイズまたはチャートサイズを OLE オブジェクト フレームのサイズに合わせることで、サイズの不一致を防げます。

**ウィンドウサイズを合わせる方法とチャートサイズを合わせる方法、どちらを選ぶべきですか？**  
ワークブックのアスペクト比を保持し、後でリサイズを許可したい場合は **アプローチ 1（ウィンドウ サイズ）** を使用してください。チャートの寸法が固定で埋め込み後に変更しない場合は **アプローチ 2（チャート サイズ）** を使用してください。

**これらの方法はテンプレートベースのプレゼンテーションと新規プレゼンテーションの両方で機能しますか？**  
はい。どちらのシナリオでも同じように機能します。

**OLE オブジェクト フレームのサイズに制限はありますか？**  
ありません。ワークブックまたはチャートのサイズに合わせて適切にスケーリングできる限り、任意のサイズに設定できます。

**他のスプレッドシート プログラムで作成したチャートでも使用できますか？**  
例は Aspose.Cells で作成した Excel チャートを対象としていますが、同様のサイズ指定オプションをサポートする OLE 互換のスプレッドシート プログラムでも同様の原則が適用可能です。

## **関連項目**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/ja/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Update OLE Objects Automatically Using a PowerPoint Add-In](/slides/ja/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)