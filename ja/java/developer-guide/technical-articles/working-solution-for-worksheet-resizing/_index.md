---
title: ワークシートサイズ変更のための作業ソリューション
type: docs
weight: 20
url: /ja/java/working-solution-for-worksheet-resizing/
---

{{% alert color="primary" %}} 

Asposeコンポーネントを使用してPowerPointプレゼンテーションにOLEとして埋め込まれたExcelワークシートが、最初のアクティベーション後に特定できないスケールにリサイズされることが観察されています。この動作は、チャートのアクティベーション前後のプレゼンテーションにかなりの視覚的な違いを生じさせます。この問題について詳細に調査し、この記事で取り上げられている解決策を見つけました。

{{% /alert %}} 
## **背景**
[OLEフレームの追加に関する記事]()では、Aspose.Slides for Javaを使用してPowerPointプレゼンテーションにOLEフレームを追加する方法を説明しました。[オブジェクト変更の問題](/slides/ja/java/object-changed-issue-when-adding-oleobjectframe/)に対処するために、選択した領域のワークシート画像をチャートOLEオブジェクトフレームに割り当てました。出力プレゼンテーションでは、ワークシート画像を表示するOLEオブジェクトフレームをダブルクリックすると、Excelチャートがアクティブになります。エンドユーザーは実際のExcelワークブックに望む変更を加え、その後アクティブ化されたExcelワークブックの外をクリックすることで関連するスライドに戻ることができます。スライドに戻ると、OLEオブジェクトフレームのサイズが変更されます。リサイズ係数は、OLEオブジェクトフレームと埋め込まれたExcelワークブックの異なるサイズによって異なります。
## **リサイズの原因**
Excelワークブックには独自のウィンドウサイズがあるため、最初のアクティベーション時に元のサイズを維持しようとします。一方、OLEオブジェクトフレームにも独自のサイズがあります。Microsoftによれば、Excelワークブックがアクティブになると、ExcelとPowerPointはサイズを交渉し、埋め込み操作の一環として正しい比率になるようにします。ExcelウィンドウのサイズとOLEオブジェクトフレームのサイズ/位置による違いに基づいてリサイズが行われます。
## **作業ソリューション**
リサイズ効果を回避するための2つの可能なソリューションがあります。* OLEフレームのサイズをPPT内で目的の行/列数の高さ/幅に合わせてスケールする* OLEフレームのサイズを一定に保ち、参加する行/列のサイズをスケールして選択されたOLEフレームサイズに合わせる
## **OLEフレームサイズをワークシートの選択された行/列サイズにスケールする**
このアプローチでは、埋め込まれたExcelワークブックのOLEフレームサイズをExcelワークシートの参加行および列の合計サイズに等しく設定する方法を学びます。
## **例**
テンプレートExcelシートが定義されており、それをOLEフレームとしてプレゼンテーションに追加したいとします。このシナリオでは、OLEオブジェクトフレームのサイズは、参加するワークブックの行および列の高さと幅の合計に基づいて最初に計算されます。その後、OLEフレームのサイズをその計算された値に設定します。PowerPointでOLEフレームに対する赤い**埋め込まれたオブジェクト**メッセージを回避するために、ワークブック内の望ましい行と列の部分の画像も取得し、それをOLEフレームの画像として設定します。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ResizeOLEFrameToWorksheetRowsColumns.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-AddOLEFrame.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-SetOleAccordingToSelectedRowsCloumns.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ScaleImage.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-SetWorkBookArea.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-PrintArea.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ExcelColumnLetter.java" >}}

## **OLEフレームサイズに応じてワークシートの行の高さと列の幅をスケールする**
このアプローチでは、カスタム設定されたOLEフレームサイズに従って参加行の高さと参加列の幅をスケールする方法を学びます。
## **例**
テンプレートExcelシートが定義されており、それをOLEフレームとしてプレゼンテーションに追加したいとします。このシナリオでは、OLEフレームのサイズを設定し、そのOLEフレームエリアに参加する行と列のサイズをスケールします。その後、変更を保存するためにワークブックをストリームに保存し、OLEフレームに追加するためにバイト配列に変換します。PowerPointでOLEフレームに対する赤い**埋め込まれたオブジェクト**メッセージを回避するために、ワークブック内の望ましい行と列の部分の画像も取得し、それをOLEフレームの画像として設定します。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-ResizeWorksheetRowColumnAccordingToOLEFrame.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-SetOleAccordingToCustomHeighWidth.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-AddOLEFrame.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-ScaleImage.java" >}}
## **結論**
{{% alert color="primary" %}} 

ワークシートのリサイズ問題を修正するための2つのアプローチがあります。適切なアプローチの選択は、要件とユースケースによります。どちらのアプローチも、テンプレートから作成されたプレゼンテーションでも、最初から作成されたプレゼンテーションでも同様に機能します。また、このソリューションにはOLEオブジェクトフレームのサイズに制限はありません。

{{% /alert %}}