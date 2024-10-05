---
title: PPTXにおけるチャートのリサイズのための作業ソリューション
type: docs
weight: 60
url: /net/working-solution-for-chart-resizing-in-pptx/
---

{{% alert color="primary" %}} 

Asposeコンポーネントを通じてPowerPointプレゼンテーションにOLEとして埋め込まれたExcelチャートが、初回のアクティベーション後に不明なスケールにリサイズされることが観察されています。この動作は、チャートのアクティベーション前後でプレゼンテーションにかなりの視覚的差異を生じさせます。AsposeチームはMicrosoftチームの協力を得て、この問題を詳細に調査し、解決策を見つけました。この記事では、この問題の理由と解決策を扱います。

{{% /alert %}} 
## **背景**
[前の記事](/slides/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)では、Aspose.Cells for .NETを使用してExcelチャートを作成し、さらにAspose.Slides for .NETを使用してこのチャートをPowerPointプレゼンテーションに埋め込む方法を説明しました。 [オブジェクトの変更の問題](/slides/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)に対応するために、チャート画像をチャートOLEオブジェクトフレームに割り当てました。出力プレゼンテーションでは、チャート画像を表示するOLEオブジェクトフレームをダブルクリックすると、Excelチャートがアクティベートされます。エンドユーザーは、実際のExcelワークブックで必要な変更を行い、アクティベートされたExcelワークブックの外をクリックして関係するスライドに戻ることができます。ユーザーがスライドに戻ると、OLEオブジェクトフレームのサイズが変わります。OLEオブジェクトフレームや埋め込まれたExcelワークブックのサイズによってリサイズの係数が異なります。 
## **リサイズの原因**
Excelワークブックには独自のウィンドウサイズがあるため、初回アクティベーション時に元のサイズを保持しようとします。一方、OLEオブジェクトフレームは独自のサイズを持っており、Microsoftによると、Excelワークブックがアクティベートされると、ExcelとPowerPointはサイズを交渉し、埋め込み操作の一環として正しい比率であることを確認します。ExcelウィンドウのサイズとOLEオブジェクトフレームのサイズ/位置の違いに基づいて、リサイズが行われます。 
## **作業ソリューション**
Aspose.Slides for .NETを使用してPowerPointプレゼンテーションを作成するための2つの可能なシナリオがあります。

**シナリオ1:** 既存のテンプレートに基づいてプレゼンテーションを作成する 

**シナリオ2:** ゼロからプレゼンテーションを作成する。 

ここで提供する解決策は、両方のシナリオに有効です。すべての解決策アプローチの基本は同じです。それは：**埋め込まれたOLEオブジェクトウィンドウのサイズは、PowerPointスライドのOLEオブジェクトフレームのサイズと同じである必要がある** ということです。さて、2つのアプローチの解決策について説明します。 
## **最初のアプローチ**
このアプローチでは、PowerPointスライドのOLEオブジェクトフレームのサイズと同等の埋め込まれたExcelワークブックのウィンドウサイズを設定する方法を学びます。

**シナリオ1** 

テンプレートを定義し、このテンプレートに基づいてプレゼンテーションを作成したいとします。テンプレートのインデックス2に何らかの形状があり、埋め込まれたExcelワークブックを含むOLEフレームを配置したいとします。このシナリオでは、OLEオブジェクトフレームのサイズは事前定義されたものと見なされます（これはテンプレートのインデックス2での形状のサイズです）。私たちがすべきことは、ワークブックのウィンドウサイズを形状のサイズと等しく設定することです。この目的には以下のコードスニペットが役立ちます：

```c#
//ウィンドウと連動したチャートサイズの定義 
chart.SizeWithWindow = true;

//ワークブックのウィンドウの幅をインチで設定（PowerPointは
//72ピクセル/インチを使用しているので72で割る）
wb.Worksheets.WindowWidthInch = slide.Shapes[2].Width / 72f;

//ワークブックのウィンドウの高さをインチで設定
wb.Worksheets.WindowHeightInch = slide.Shapes[2].Height / 72f;

//メモリストリームをインスタンス化
MemoryStream ms = wb.SaveToStream();

//埋め込まれたExcelを持つOLEオブジェクトフレームを作成
Aspose.Slides.OleObjectFrame objFrame = slide.Shapes.AddOleObjectFrame(
				slide.Shapes[2].X,
				slide.Shapes[2].Y,
				slide.Shapes[2].Width,
				slide.Shapes[2].Height, "Excel.Sheet.8", ms.ToArray());
```

**シナリオ2** 


ゼロからプレゼンテーションを作成し、埋め込まれたExcelワークブックを持つ任意のサイズのOLEオブジェクトフレームを希望するとします。以下のコードスニペットでは、スライドのx軸=0.5インチ、y軸=1インチの位置に高さ4インチ、幅9.5インチのOLEオブジェクトフレームを作成しました。さらに、同等のExcelワークブックのウィンドウサイズ、高さ4インチ、幅9.5インチを設定しました。

```c#
//私たちの望む高さ
int desiredHeight = 288;//4インチ（4 * 72）

//私たちの望む幅
int desiredWidth = 684;//9.5インチ（9.5 * 72）

//ウィンドウと連動したチャートサイズの定義
chart.SizeWithWindow = true;

//ワークブックのウィンドウの幅をインチで設定
wb.Worksheets.WindowWidthInch = desiredWidth / 72f;

//ワークブックのウィンドウの高さをインチで設定
wb.Worksheets.WindowHeightInch = desiredHeight / 72f;

//メモリストリームをインスタンス化
MemoryStream ms = wb.SaveToStream();

//埋め込まれたExcelを持つOLEオブジェクトフレームを作成
Aspose.Slides.OleObjectFrame objFrame = slide.Shapes.AddOleObjectFrame(
							36,
							72,
							desiredWidth,
							desiredHeight, "Excel.Sheet.8", ms.ToArray());
```



## **第二のアプローチ**
このアプローチでは、PowerPointスライドのOLEオブジェクトフレームのサイズと同等の埋め込まれたExcelワークブック内のチャートサイズを設定する方法を学びます。このアプローチは、チャートのサイズが事前に知られており、決して変わらない場合に有用です。 

**シナリオ1** 

テンプレートを定義し、このテンプレートに基づいてプレゼンテーションを作成したいとします。テンプレートのインデックス2に何らかの形状があり、埋め込まれたExcelワークブックを持つOLEフレームを配置したいとします。このシナリオでは、OLEフレームのサイズは事前定義されたものと見なされます（これはテンプレートのインデックス2での形状のサイズです）。私たちがすべきことは、ワークブック内のチャートのサイズを形状のサイズと等しく設定することです。この目的には以下のコードスニペットが役立ちます： 

```c#
//ウィンドウなしのチャートサイズの定義 
chart.SizeWithWindow = false;

//ピクセル単位でチャートの幅を設定（Excelは1インチあたり96ピクセルを使用するので96倍します）    
chart.ChartObject.Width = (int)((slide.Shapes[2].Width / 72f) * 96f);

//ピクセル単位でチャートの高さを設定
chart.ChartObject.Height = (int)((slide.Shapes[2].Height / 72f) * 96f);

//チャート印刷サイズの定義
chart.PrintSize = PrintSizeType.Custom;

//メモリストリームをインスタンス化
MemoryStream ms = wb.SaveToStream();

//埋め込まれたExcelを持つOLEオブジェクトフレームを作成
Aspose.Slides.OleObjectFrame objFrame = slide.Shapes.AddOleObjectFrame(
				slide.Shapes[2].X,
				slide.Shapes[2].Y,
				slide.Shapes[2].Width,
				slide.Shapes[2].Height, "Excel.Sheet.8", ms.ToArray());

```




**シナリオ2** 

ゼロからプレゼンテーションを作成し、埋め込まれたExcelワークブックを持つ任意のサイズのOLEオブジェクトフレームを希望するとします。以下のコードスニペットでは、スライドのx軸=0.5インチ、y軸=1インチの位置に高さ4インチ、幅9.5インチのOLEオブジェクトフレームを作成しました。さらに、同等のチャートのサイズ、高さ4インチ、幅9.5インチを設定しました。

```c#
//私たちの望む高さ
int desiredHeight = 288;//4インチ（4 * 576）

//私たちの望む幅
int desiredWidth = 684;//9.5インチ（9.5 * 576）

//ウィンドウなしのチャートサイズの定義 
chart.SizeWithWindow = false;

//ピクセル単位でチャートの幅を設定    
chart.ChartObject.Width = (int)((desiredWidth / 72f) * 96f);

//ピクセル単位でチャートの高さを設定    
chart.ChartObject.Height = (int)((desiredHeight / 72f) * 96f);

//メモリストリームをインスタンス化
MemoryStream ms = wb.SaveToStream();

//埋め込まれたExcelを持つOLEオブジェクトフレームを作成
Aspose.Slides.OleObjectFrame objFrame = slide.Shapes.AddOleObjectFrame(
							36,
							72,
							desiredWidth,
							desiredHeight, "Excel.Sheet.8", ms.ToArray());
```


## **結論**
{{% alert color="primary" %}} 

チャートのリサイズ問題を修正するためのアプローチは2つあります。適切なアプローチの選択は、要件とユースケースに依存します。両方のアプローチは、テンプレートからプレゼンテーションが作成される場合でも、ゼロから作成される場合でも同じように機能します。また、解決策においてOLEオブジェクトフレームのサイズに制限はありません。

{{% /alert %}} 
## **関連セクション**
[プレゼンテーションにExcelチャートをOLEオブジェクトとして作成および埋め込む](/slides/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[OLEオブジェクトを自動的に更新する](/slides/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)