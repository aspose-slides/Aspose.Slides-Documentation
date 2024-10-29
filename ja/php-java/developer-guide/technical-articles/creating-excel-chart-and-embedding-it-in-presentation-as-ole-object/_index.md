---
title: Excelチャートを作成し、OLEオブジェクトとしてプレゼンテーションに埋め込む
type: docs
weight: 30
url: /ja/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
---

{{% alert color="primary" %}} 

PowerPointスライドでは、データのグラフィカル表示のために編集可能なチャートを使用することは一般的な活動です。Asposeは、Aspose.Cells for Javaを使用してExcelチャートを作成するサポートを提供しており、さらにこれらのチャートはAspose.Slides for PHPを通じてJavaでPowerPointスライドにOLEオブジェクトとして埋め込むことができます。この記事では、Aspose.Cells for JavaとAspose.Slides for PHPを使用して、MS ExcelチャートをOLEオブジェクトとしてPowerPointプレゼンテーションに作成し埋め込むための必要な手順および実装を説明します。

{{% /alert %}} 
## **必要な手順**
ExcelチャートをOLEオブジェクトとしてPowerPointスライドに作成し埋め込むための手順は次のとおりです：# Aspose.Cells for Javaを使用してExcelチャートを作成します。# Aspose.Cells for Javaを使用してExcelチャートのOLEサイズを設定します。# Aspose.Cells for Javaを使用してExcelチャートの画像を取得します。# Aspose.Slides for PHPを通じてJavaでPPTXプレゼンテーションの中にExcelチャートをOLEオブジェクトとして埋め込みます。# オブジェクト変更の問題に対処するため、ステップ3で取得した画像でオブジェクト変更画像を置き換えます。# 出力プレゼンテーションをPPTX形式でディスクに保存します。
## **必要な手順の実装**
上記手順の実装は次のとおりです：

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}

{{% alert color="primary" %}} 

上記の方法で作成されたプレゼンテーションは、OLEオブジェクトフレームをダブルクリックすることでアクティブ化できるExcelチャートをOLEオブジェクトとして持ちます。

{{% /alert %}} 
## **結論**
{{% alert color="primary" %}} 

Aspose.Cells for JavaとAspose.Slides for PHPをJava経由で使用することで、Aspose.Cells for Javaがサポートする任意のExcelチャートを作成し、作成したチャートをPowerPointスライドにOLEオブジェクトとして埋め込むことができます。ExcelチャートのOLEサイズも定義できます。エンドユーザーは他のOLEオブジェクトと同様にExcelチャートを編集できます。

{{% /alert %}} 
## **関連セクション**
[チャートのリサイズに関する作業ソリューション](/slides/ja/php-java/working-solution-for-chart-resizing-in-pptx/)

[オブジェクト変更の問題](/slides/ja/php-java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)