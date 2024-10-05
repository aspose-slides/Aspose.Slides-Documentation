---
title: PPTXにおけるチャートのリサイズのための作業ソリューション
type: docs
weight: 40
url: /php-java/working-solution-for-chart-resizing-in-pptx/
---

{{% alert color="primary" %}} 

Asposeコンポーネントを介してPowerPointプレゼンテーションにOLEとして埋め込まれたExcelチャートが、初回のアクティベーション後に特定できないスケールにリサイズされることが観察されています。この動作は、チャートのアクティベーション前と後でプレゼンテーションの視覚的な違いを大きく生じさせます。AsposeチームはMicrosoftチームの支援を受け、この問題を詳細に調査し、解決策を見つけました。この記事では、この問題の原因と解決策について説明します。

{{% /alert %}} 
## **背景**
[前回の記事](/slides/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) では、Aspose.Cells for Javaを使用してExcelチャートを作成し、その後Aspose.Slides for PHPを介してPowerPointプレゼンテーションにこのチャートを埋め込む方法を説明しました。[オブジェクト変更の問題](/slides/php-java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/) に対応するために、チャート画像をチャートOLEオブジェクトフレームに割り当てました。出力プレゼンテーションで、チャート画像を表示しているOLEオブジェクトフレームをダブルクリックすると、Excelチャートがアクティブ化されます。エンドユーザーは、実際のExcelワークブックに必要な変更を加え、その後、アクティブ化されたExcelワークブックの外側をクリックすることで関係するスライドに戻ることができます。ユーザーがスライドに戻ると、OLEオブジェクトフレームのサイズが変更されます。リサイズの係数は、OLEオブジェクトフレームと埋め込まれたExcelワークブックの異なるサイズに対して異なります。
## **リサイズの原因**
Excelワークブックには独自のウィンドウサイズがあるため、初回のアクティベーション時に元のサイズを保持しようとします。一方で、OLEオブジェクトフレームは独自のサイズを持ちます。Microsoftによれば、Excelワークブックがアクティブ化されると、ExcelとPowerPointはサイズを交渉し、埋め込み操作の一部として正しい比率になるようにします。ExcelウィンドウのサイズとOLEオブジェクトフレームのサイズ/位置の違いに基づいて、リサイズが行われます。
## **作業ソリューション**
Aspose.Slides for PHPを介してPowerPointプレゼンテーションを作成するための可能な2つのシナリオがあります。**シナリオ1:** 既存のテンプレートに基づいてプレゼンテーションを作成する**シナリオ2:** ゼロからプレゼンテーションを作成する。ここで提供する解決策は、両方のシナリオに有効です。すべての解決策アプローチの基本は同じです。つまり、**埋め込まれたOLEオブジェクトウィンドウのサイズは、PowerPointスライド内のOLEオブジェクトフレームのサイズと同じであるべきです。** それでは、解決策の2つのアプローチについて議論します。
## **最初のアプローチ**
このアプローチでは、埋め込まれたExcelワークブックのウィンドウサイズをPowerPointスライド内のOLEオブジェクトフレームのサイズに等しく設定する方法を学びます。**シナリオ1**テンプレートが定義されていて、このテンプレートに基づいてプレゼンテーションを作成したいとしましょう。例えば、テンプレートのインデックス2にOLEフレームを配置したい形状があると仮定します。このシナリオでは、OLEオブジェクトフレームのサイズは事前定義されているもの（テンプレートのインデックス2にある形状のサイズ）と見なされます。すべての操作として、ワークブックのウィンドウサイズを形状のサイズと等しく設定する必要があります。以下のコードスニペットがこの目的に役立ちます。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartWithExistingTemplate-ResizeChartWithExistingTemplate.java" >}}





**シナリオ2
**ゼロからプレゼンテーションを作成し、埋め込まれたExcelワークブックを持つ任意のサイズのOLEオブジェクトフレームを希望するとしましょう。以下のコードスニペットでは、x軸=0.5インチ、y軸=1インチで、高さ4インチ、幅9.5インチのOLEオブジェクトフレームをスライドに作成しました。さらに、等しいExcelワークブックのウィンドウサイズ、高さ4インチ、幅9.5インチを設定しました。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartFromScratch-ResizeChartFromScratch.java" >}}


## **第二のアプローチ**
このアプローチでは、埋め込まれたExcelワークブックに存在するチャートのサイズをPowerPointスライド内のOLEオブジェクトフレームのサイズに等しく設定する方法を学びます。このアプローチは、チャートのサイズが事前に知られていて、変更されることがない場合に役立ちます。**シナリオ1**テンプレートが定義されていて、このテンプレートに基づいてプレゼンテーションを作成したいとしましょう。例えば、テンプレートのインデックス2にOLEフレームを配置したい形状があると仮定します。このシナリオでは、OLEフレームのサイズは事前定義されているもの（テンプレートのインデックス2にある形状のサイズ）と見なされます。すべての操作として、ワークブック内のチャートのサイズを形状のサイズと等しく設定する必要があります。以下のコードスニペットがこの目的に役立ちます。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartWithExistingTemplateSecondApproach-ResizeChartWithExistingTemplateSecondApproach.java" >}}

**シナリオ2**ゼロからプレゼンテーションを作成し、埋め込まれたExcelワークブックを持つ任意のサイズのOLEオブジェクトフレームを希望するとしましょう。以下のコードスニペットでは、高さ4インチ、幅9.5インチのOLEオブジェクトフレームをスライドに作成しました。x軸=0.5インチ、y軸=1インチで、さらに、等しいチャートサイズ、高さ4インチ、幅9.5インチを設定しました。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartFromScratchSecondApproach-ResizeChartFromScratchSecondApproach.java" >}}
## **結論**
{{% alert color="primary" %}} 

チャートリサイズの問題を修正するための2つのアプローチがあります。適切なアプローチの選択は、要件とユースケースに依存します。どちらのアプローチも、テンプレートからプレゼンテーションを作成するか、ゼロから作成するかに関係なく、同じように機能します。また、解決策にはOLEオブジェクトフレームのサイズの制限はありません。

{{% /alert %}}