---
title: PPTX のチャートリサイズに対する実用的な解決策
type: docs
weight: 40
url: /ja/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- チャート リサイズ
- Excel チャート
- OLE オブジェクト
- チャート 埋め込み
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して埋め込み Excel OLE オブジェクトを利用する際の、PPTX における予期しないチャートリサイズを修正します。サイズを一貫させるための 2 つのコード付き手法をご紹介します。"
---
## **背景**

Aspose コンポーネントを使用して PowerPoint プレゼンテーションに OLE オブジェクトとして埋め込まれた Excel グラフが、最初にアクティブ化された後に不特定のスケールにリサイズされることが確認されています。この挙動により、グラフのアクティブ化前後でプレゼンテーションの見た目に顕著な違いが生じます。Aspose チームはこの問題を詳細に調査し、解決策を見つけました。本記事では問題の原因と対応策を説明します。

前回の記事[/slides/ja/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/](前回の記事)では、Aspose.Cells for Java を使用して Excel グラフを作成し、Aspose.Slides for Java で PowerPoint プレゼンテーションに埋め込む方法を解説しました。[オブジェクト プレビューの問題](/slides/ja/java/object-preview-issue-when-adding-oleobjectframe/)に対処するため、グラフ画像をグラフの OLE オブジェクト フレームに割り当てました。出力されたプレゼンテーションで、グラフ画像を表示している OLE オブジェクト フレームをダブルクリックすると Excel グラフがアクティブ化されます。エンド ユーザーは基になる Excel ワークブックで任意の変更を行い、アクティブ化されたワークブックの外側をクリックすると対応するスライドに戻ります。ユーザーがスライドに戻ったときに OLE オブジェクト フレームのサイズが変わり、リサイズ率は OLE オブジェクト フレームと埋め込まれた Excel ワークブックの元のサイズに依存します。

## **リサイズの原因**

Excel ワークブックは独自のウィンドウサイズを持っており、最初のアクティブ化時に元のサイズを保持しようとします。一方、OLE オブジェクト フレームは独自のサイズを持っています。Microsoft によると、Excel ワークブックがアクティブ化されると、Excel と PowerPoint がサイズを協議し、埋め込みプロセスの一部として正しい比率を維持します。Excel ウィンドウのサイズと OLE オブジェクト フレームのサイズまたは位置の違いに応じて、リサイズが発生します。

## **実装可能な解決策**

Aspose.Slides for Java を使用して PowerPoint プレゼンテーションを作成するシナリオは 2 つあります。

**シナリオ 1:** 既存のテンプレートを基にプレゼンテーションを作成する。

**シナリオ 2:** ゼロからプレゼンテーションを作成する。

ここで提示する解決策は両シナリオに適用できます。すべての解決策の基本は同じです：**埋め込まれた OLE オブジェクトのウィンドウサイズを PowerPoint スライド上の OLE オブジェクト フレームと一致させる**。以下で 2 つのアプローチを説明します。

## **アプローチ 1**

このアプローチでは、埋め込まれた Excel ワークブックのウィンドウサイズを PowerPoint スライド上の OLE オブジェクト フレームのサイズに合わせる方法を学びます。

**シナリオ 1**

テンプレートを定義し、それに基づいてプレゼンテーションを作成したいとします。テンプレートのインデックス 2 にあるシェイプに埋め込み Excel ワークブックを含む OLE フレームを配置したいと想定します。このシナリオでは、OLE オブジェクト フレームのサイズは事前に決まっており、テンプレートのインデックス 2 のシェイプのサイズと一致します。必要なのは、ワークブックのウィンドウサイズをそのシェイプのサイズと同じに設定することだけです。以下のコードスニペットがその目的を果たします。

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// ワークブックのウィンドウ幅をインチ単位で設定します（PowerPoint は 1 インチあたり 72 ポイントを使用するため、72 で除算します）。
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// ワークブックのウィンドウ高さをインチ単位で設定します。
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// ワークブックをメモリ ストリームに保存します。
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// 埋め込み Excel データで OLE オブジェクト フレームを作成します。
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**シナリオ 2**

ゼロからプレゼンテーションを作成し、任意のサイズの OLE オブジェクト フレームに埋め込み Excel ワークブックを含めたいとします。以下のコードスニペットでは、スライド上の x=0.5 インチ、y=1 インチの位置に高さ 4 インチ、幅 9.5 インチの OLE オブジェクト フレームを作成し、Excel ワークブックのウィンドウも同じサイズ（高さ 4 インチ、幅 9.5 インチ）に設定します。

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// 希望する高さです。
int desiredHeight = 288; // 4 インチ (4 * 72)
 
// 希望する幅です。
int desiredWidth = 684; // 9.5 インチ (9.5 * 72)
 
// ウィンドウ付きでチャートサイズを定義します。
chart.setSizeWithWindow(true);
 
// ワークブックのウィンドウ幅をインチ単位で設定します（PowerPoint は 1 インチあたり 72 ポイントを使用するため、72 で除算します）。
workbook.getSettings().setWindowWidthInch(desiredWidth / 72f);
 
// ワークブックのウィンドウ高さをインチ単位で設定します。
workbook.getSettings().setWindowHeightInch(desiredHeight / 72f);
 
// ワークブックをメモリ ストリームに保存します。
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// 埋め込み Excel データで OLE オブジェクト フレームを作成します。
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0.5 インチ (0.5 * 72)
    72,  // y = 1 インチ (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **アプローチ 2**

このアプローチでは、埋め込まれた Excel ワークブック内のグラフのサイズを PowerPoint スライド上の OLE オブジェクト フレームのサイズに合わせる方法を学びます。このアプローチは、グラフのサイズが事前に分かっていて変更されない場合に有効です。

**シナリオ 1**

テンプレートを定義し、それに基づいてプレゼンテーションを作成したいとします。テンプレートのインデックス 2 にあるシェイプに埋め込み Excel ワークブックを含む OLE フレームを配置したいと想定します。このシナリオでは、OLE フレームのサイズは事前に決まっており、テンプレートのインデックス 2 のシェイプのサイズと一致します。必要なのは、ワークブック内のグラフサイズをそのシェイプのサイズと同じに設定することだけです。以下のコードスニペットがその目的を果たします。

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// ウィンドウなしでチャートサイズを定義します。
chart.setSizeWithWindow(false);
 
// ピクセル単位でチャート幅を設定します（Excel は 1 インチあたり 96 ピクセルを使用するため 96 倍します）。
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// ピクセル単位でチャート高さを設定します。
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// チャートの印刷サイズを定義します。
chart.setPrintSize(com.aspose.cells.PrintSizeType.CUSTOM);
 
// ワークブックをメモリ ストリームに保存します。
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// 埋め込み Excel データで OLE オブジェクト フレームを作成します。
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**シナリオ 2**:

ゼロからプレゼンテーションを作成し、任意のサイズの OLE オブジェクト フレームに埋め込み Excel ワークブックを含めたいとします。以下のコードスニペットでは、スライド上の x=0.5 インチ、y=1 インチの位置に高さ 4 インチ、幅 9.5 インチの OLE オブジェクト フレームを作成し、対応するグラフサイズも同じ寸法（高さ 4 インチ、幅 9.5 インチ）に設定します。

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// 希望する高さです。
int desiredHeight = 288; // 4 インチ (4 * 72)
 
// 希望する幅です。
int desiredWidth = 684; // 9.5 インチ (9.5 * 72)
 
// ウィンドウなしでチャートサイズを定義します。
chart.setSizeWithWindow(false);
 
// ピクセル単位でチャート幅を設定します（72 で除算してインチに変換し、Excel は 1 インチあたり 96 ピクセルを使用するため 96 倍します）。
chart.getChartObject().setWidth((int)((desiredWidth / 72f) * 96f));
 
// ピクセル単位でチャート高さを設定します。
chart.getChartObject().setHeight((int)((desiredHeight / 72f) * 96f));
 
// ワークブックをメモリ ストリームに保存します。
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// 埋め込み Excel データで OLE オブジェクト フレームを作成します。
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0.5 インチ (0.5 * 72)
    72,  // y = 1 インチ (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **結論**

グラフのリサイズ問題を解決するには 2 つのアプローチがあります。どちらのアプローチを選択するかは要件とユースケースに依存します。テンプレートベースでもゼロから作成したプレゼンテーションでも、両アプローチは同様に機能します。また、このソリューションでは OLE オブジェクト フレームのサイズに上限はありません。

## **FAQ**

### 埋め込んだ Excel グラフは、PowerPoint でアクティブ化するとサイズが変わるのはなぜですか？

Excel は最初にアクティブ化されたときに元のウィンドウサイズを復元しようとしますが、PowerPoint の OLE オブジェクト フレームは独自の寸法を持っています。PowerPoint と Excel がサイズを協議してアスペクト比を維持するため、リサイズが発生します。

### このリサイズ問題を完全に防ぐことはできますか？

はい。埋め込む前に Excel ワークブックのウィンドウサイズまたはグラフサイズを OLE オブジェクト フレームのサイズと一致させることで、グラフサイズを一定に保つことができます。

### ワークブックのウィンドウサイズを設定すべきか、グラフサイズを設定すべきか、どちらのアプローチを選ぶべきですか？

**アプローチ 1（ウィンドウサイズ）** は、ワークブックのアスペクト比を維持し、後でリサイズを許可したい場合に使用します。  
**アプローチ 2（グラフサイズ）** は、グラフの寸法が固定されており、埋め込み後に変更しない場合に使用します。

### これらの方法はテンプレートベースのプレゼンテーションと新規プレゼンテーションの両方で機能しますか？

はい。両アプローチはテンプレートから作成したプレゼンテーションでも、ゼロから作成したプレゼンテーションでも同様に機能します。

### OLE オブジェクト フレームのサイズに制限はありますか？

いいえ。ワークブックまたはグラフのサイズに合わせて適切にスケールできる限り、任意のサイズに設定できます。

### 他のスプレッドシート プログラムで作成したグラフにもこの方法は使えますか？

例は Aspose.Cells で作成した Excel グラフを対象としていますが、同様のサイズ設定オプションをサポートする OLE 互換のスプレッドシート プログラムでも原理は適用可能です。

## **関連セクション**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/ja/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)