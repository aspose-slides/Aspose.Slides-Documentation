---
title: Excelチャートの作成とOLEオブジェクトとしてプレゼンテーションに埋め込む
type: docs
weight: 30
url: /ja/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
---

{{% alert color="primary" %}} 

PowerPointのスライドでは、データのグラフィカル表示のために編集可能なチャートを使用することは一般的な活動です。Asposeは、Aspose.Cells for Javaを使用してExcelチャートを作成するサポートを提供しており、さらにこれらのチャートはAspose.Slides for Javaを通じてPowerPointスライドにOLEオブジェクトとして埋め込むことができます。この記事では、Aspose.Cells for JavaとAspose.Slides for Javaを使用して、PowerPointプレゼンテーションにOLEオブジェクトとしてMS Excelチャートを作成し埋め込むための必要なステップと実装を説明します。

{{% /alert %}} 
## **必要なステップ**
ExcelチャートをOLEオブジェクトとしてPowerPointスライドに埋め込むためには以下の手順が必要です:# Aspose.Cells for Javaを使用してExcelチャートを作成します。# Aspose.Cells for Javaを使用してExcelチャートのOLEサイズを設定します。# Aspose.Cells for Javaを使用してExcelチャートの画像を取得します。# Aspose.Slides for Javaを使用してPPTXプレゼンテーション内にExcelチャートをOLEオブジェクトとして埋め込みます。# ステップ3で得られた画像でオブジェクト変更された画像を置き換えてオブジェクト変更問題に対応します。# 出力プレゼンテーションをPPTX形式でディスクに保存します。
## **必要なステップの実装**
上記の手順の実装は以下の通りです：

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}

{{% alert color="primary" %}} 

上記の方法で作成されたプレゼンテーションは、OLEオブジェクトフレームをダブルクリックすることでアクティブにできるExcelチャートをOLEオブジェクトとして持ちます。

{{% /alert %}} 
## **結論**
{{% alert color="primary" %}} 

Aspose.Cells for JavaとAspose.Slides for Javaを使用することで、Aspose.Cells for Javaでサポートされている任意のExcelチャートを作成し、作成したチャートをPowerPointスライドにOLEオブジェクトとして埋め込むことができます。ExcelチャートのOLEサイズも定義できます。最終ユーザーは他のOLEオブジェクトと同様にExcelチャートをさらに編集できます。

{{% /alert %}} 
## **関連セクション**
[チャートリサイズのための作業ソリューション](/slides/ja/java/working-solution-for-chart-resizing-in-pptx/)

[オブジェクト変更問題](/slides/ja/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)