---
title: ワークシートリサイズの作業ソリューション
type: docs
weight: 20
url: /ja/php-java/working-solution-for-worksheet-resizing/
---

{{% alert color="primary" %}} 

Asposeコンポーネントを介してPowerPointプレゼンテーションにOLEとして埋め込まれたExcelワークシートが、初回アクティベーション後に識別不能なスケールにリサイズされることが観察されました。この動作は、チャートのアクティベーション前後でプレゼンテーションにかなりの視覚的差異を生じさせます。この問題を詳細に調査し、この記事でカバーされている解決策を見つけました。

{{% /alert %}} 
## **背景**
[OLEフレームを追加する記事]()では、Aspose.Slides for PHPをJava経由で使用してPowerPointプレゼンテーションにOLEフレームを追加する方法を説明しました。[オブジェクトが変更された問題](/slides/ja/php-java/object-changed-issue-when-adding-oleobjectframe/)を解決するために、選択された領域のワークシート画像をチャートOLEオブジェクトフレームに割り当てました。出力プレゼンテーションでは、ワークシート画像を表示しているOLEオブジェクトフレームをダブルクリックすると、Excelチャートがアクティベートされます。エンドユーザーは、実際のExcelワークブックに希望の変更を加えた後、アクティブなExcelワークブックの外をクリックすることで関係するスライドに戻ることができます。ユーザーがスライドに戻ると、OLEオブジェクトフレームのサイズが変わります。リサイズ係数は、異なるサイズのOLEオブジェクトフレームおよび埋め込まれたExcelワークブックごとに異なります。
## **リサイズの原因**
Excelワークブックには独自のウィンドウサイズがあるため、初回アクティベーション時に元のサイズを維持しようとします。一方、OLEオブジェクトフレームには独自のサイズがあります。Microsoftによると、Excelワークブックのアクティベーション時に、ExcelとPowerPointはサイズを交渉し、埋め込み操作の一部として正しい比率であることを保証します。ExcelウィンドウのサイズとOLEオブジェクトフレームのサイズ/位置の違いに基づいて、リサイズが行われます。
## **作業ソリューション**
リサイズ効果を回避するための2つの可能な解決策があります。* PPTのOLEフレームサイズを目的の行/列数の高さ/幅に合わせてスケール* OLEフレームサイズを一定に保ち、参加する行/列のサイズをスケールして選択したOLEフレームサイズにフィットさせる
## **OLEフレームサイズをワークシートの選択行/列サイズにスケール**
このアプローチでは、埋め込まれたExcelワークブックのOLEフレームサイズを、Excelワークシートの参加する行と列の累積サイズと等しく設定する方法を学びます。
## **例**
テンプレートExcelシートを定義し、それをOLEフレームとしてプレゼンテーションに追加したいとします。このシナリオにおいて、OLEオブジェクトフレームのサイズは、参加するワークブックの行と列の累積高さおよび幅に基づいて最初に計算されます。そして、OLEフレームのサイズをその計算された値に設定します。PowerPointでOLEフレーム用の赤い**埋め込みオブジェクト**メッセージを回避するために、ワークブック内の希望する行と列の部分の画像も取得し、それをOLEフレームの画像として設定します。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ResizeOLEFrameToWorksheetRowsColumns.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-AddOLEFrame.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-SetOleAccordingToSelectedRowsCloumns.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ScaleImage.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-SetWorkBookArea.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-PrintArea.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ExcelColumnLetter.java" >}}

## **OLEフレームサイズに従ってワークシートの行の高さと列の幅をスケール**
このアプローチでは、カスタム設定されたOLEフレームサイズに従って、参加する行の高さと参加する列の幅をスケールする方法を学びます。
## **例**
テンプレートExcelシートを定義し、それをOLEフレームとしてプレゼンテーションに追加したいとします。このシナリオでは、OLEフレームのサイズを設定し、OLEフレームエリアに参加する行と列のサイズをスケールします。そして、変更を保存するためにワークブックをストリームに保存し、それをOLEフレームに追加するためにバイト配列に変換します。PowerPointでOLEフレーム用の赤い**埋め込みオブジェクト**メッセージを回避するために、ワークブック内の希望する行と列の部分の画像も取得し、それをOLEフレームの画像として設定します。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-ResizeWorksheetRowColumnAccordingToOLEFrame.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-SetOleAccordingToCustomHeighWidth.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-AddOLEFrame.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-ScaleImage.java" >}}
## **結論**
{{% alert color="primary" %}} 

ワークシートリサイズの問題を修正するための2つのアプローチがあります。適切なアプローチの選択は、要件とユースケースの依存します。テンプレートから作成されたプレゼンテーションでも、ゼロから作成されたプレゼンテーションでも、どちらのアプローチも同じように機能します。また、このソリューションにはOLEオブジェクトフレームサイズに関する制限はありません。

{{% /alert %}}