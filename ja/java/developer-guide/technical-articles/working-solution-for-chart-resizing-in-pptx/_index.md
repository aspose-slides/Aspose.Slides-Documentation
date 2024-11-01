---
title: PPTXにおけるチャートのリサイズのための作業ソリューション
type: docs
weight: 40
url: /ja/java/working-solution-for-chart-resizing-in-pptx/
---

{{% alert color="primary" %}} 

Asposeコンポーネントを介してPowerPointプレゼンテーションにOLEとして埋め込まれたExcelチャートが、初回アクティベーション後に未特定のスケールにリサイズされることが観察されました。この動作は、プレゼンテーションのアクティベーション前後で大きな視覚的違いを生じさせます。AsposeチームはMicrosoftチームの協力により、この問題を詳細に調査し、解決策を見つけました。この記事では、この問題の原因と解決策について説明します。

{{% /alert %}} 
## **背景**
[前の記事](/slides/ja/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) では、Aspose.Cells for Javaを使用してExcelチャートを作成する方法と、そのチャートをAspose.Slides for Javaを使用してPowerPointプレゼンテーションに埋め込む方法について説明しました。[オブジェクト変更問題](/slides/ja/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/) に対処するために、チャート画像をチャートOLEオブジェクトフレームに割り当てました。出力プレゼンテーションでは、チャート画像を表示しているOLEオブジェクトフレームをダブルクリックすると、Excelチャートがアクティブになります。エンドユーザーは、実際のExcelワークブックで必要な変更を行い、アクティブ化されたExcelワークブックの外をクリックすることで関係するスライドに戻ります。ユーザーがスライドに戻ると、OLEオブジェクトフレームのサイズが変更されます。リサイズの要因は、OLEオブジェクトフレームのサイズと埋め込まれたExcelワークブックのサイズによって異なります。
## **リサイズの原因**
Excelワークブックは独自のウィンドウサイズを持っているため、初回アクティベーション時に元のサイズを保持しようとします。一方で、OLEオブジェクトフレームは独自のサイズを持ちます。Microsoftによれば、Excelワークブックがアクティベートされると、ExcelとPowerPointがサイズを交渉し、埋め込み操作の一部として正しい比率になっていることを確認します。ExcelウィンドウのサイズとOLEオブジェクトフレームのサイズ/位置の違いに基づいて、リサイズが発生します。
## **作業ソリューション**
Aspose.Slides for Javaを使用してPowerPointプレゼンテーションを作成するための2つのシナリオがあります。**シナリオ1:** 既存のテンプレートに基づいてプレゼンテーションを作成する。**シナリオ2:** ゼロからプレゼンテーションを作成する。ここで提供する解決策は、どちらのシナリオにも適用可能です。すべての解決策アプローチの基本は同じです。すなわち、**埋め込まれたOLEオブジェクトウィンドウのサイズは、PowerPointスライドのOLEオブジェクトフレームのサイズと同じであるべきです**。ここでは、解決策の2つのアプローチについて説明します。
## **最初のアプローチ**
このアプローチでは、埋め込まれたExcelワークブックのウィンドウサイズをPowerPointスライドのOLEオブジェクトフレームのサイズに等しく設定する方法を学びます。**シナリオ1** テンプレートを定義し、そのテンプレートに基づいてプレゼンテーションを作成したいと仮定します。テンプレートのインデックス2にOLEフレームを配置したい形状があるとします。このシナリオでは、OLEオブジェクトフレームのサイズは事前に定義されたものと見なされます（これはテンプレートのインデックス2にある形状のサイズです）。私たちが行うべきことは、ワークブックのウィンドウサイズを形状のサイズと等しく設定することです。次のコードスニペットがこの目的を果たします。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartWithExistingTemplate-ResizeChartWithExistingTemplate.java" >}}

**シナリオ2** 
ゼロからプレゼンテーションを作成し、埋め込まれたExcelワークブックを持つ任意のサイズのOLEオブジェクトフレームを希望するとしましょう。次のコードスニペットでは、スライドのx軸=0.5インチ、y軸=1インチに4インチの高さと9.5インチの幅を持つOLEオブジェクトフレームを作成しました。さらに、Excelワークブックのウィンドウサイズを、すなわち高さ4インチ、幅9.5インチに設定しました。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartFromScratch-ResizeChartFromScratch.java" >}}


## **第二のアプローチ**
このアプローチでは、埋め込まれたExcelワークブックに存在するチャートのサイズをPowerPointスライドのOLEオブジェクトフレームのサイズに等しく設定する方法を学びます。このアプローチは、チャートのサイズが事前に知られており、決して変更されない場合に有用です。**シナリオ1** テンプレートを定義し、そのテンプレートに基づいてプレゼンテーションを作成したいと仮定します。テンプレートのインデックス2にOLEフレームを配置したい形状があるとします。このシナリオでは、OLEフレームのサイズは事前に定義されたものと見なされます（これはテンプレートのインデックス2にある形状のサイズです）。私たちが行うべきことは、ワークブック内のチャートのサイズを形状のサイズと等しく設定することです。次のコードスニペットがこの目的を果たします。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartWithExistingTemplateSecondApproach-ResizeChartWithExistingTemplateSecondApproach.java" >}}

**シナリオ2**: ゼロからプレゼンテーションを作成し、埋め込まれたExcelワークブックを持つ任意のサイズのOLEオブジェクトフレームを希望するとしましょう。次のコードスニペットでは、スライドのx軸=0.5インチ、y軸=1インチに4インチの高さと9.5インチの幅を持つOLEオブジェクトフレームを作成しました。さらに、等しいチャートのサイズ、すなわち高さ4インチと幅9.5インチを設定しました。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartFromScratchSecondApproach-ResizeChartFromScratchSecondApproach.java" >}}
## **結論**
{{% alert color="primary" %}} 

チャートリサイズの問題を修正するためのアプローチが2つあります。適切なアプローチの選択は、要件とユースケースに依存します。どちらのアプローチも、プレゼンテーションがテンプレートから作成された場合でも、ゼロから作成された場合でも同様に機能します。また、解決策においてOLEオブジェクトフレームのサイズに制限はありません。

{{% /alert %}}