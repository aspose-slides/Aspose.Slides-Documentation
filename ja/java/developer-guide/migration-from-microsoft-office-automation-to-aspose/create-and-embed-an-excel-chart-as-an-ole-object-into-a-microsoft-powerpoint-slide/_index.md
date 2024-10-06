---
title: ExcelチャートをOLEオブジェクトとしてMicrosoft PowerPointスライドに作成および埋め込む
type: docs
weight: 60
url: /ja/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
---

{{% alert color="primary" %}} 

 チャートはデータの視覚的表現であり、プレゼンテーションスライドに広く使用されています。この文書では、[VSTO](/slides/ja/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/)と[Aspose.Slides for Java](/slides/ja/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/)を使用して、ExcelチャートをOLEオブジェクトとしてPowerPointスライドにプログラムで作成し埋め込むためのコードを示します。

{{% /alert %}} 
## **Excelチャートの作成と埋め込み**
以下の2つのコード例は、説明しているタスクが複雑なため、長く詳細になっています。Microsoft Excelワークブックを作成し、チャートを作成し、その後、チャートを埋め込むMicrosoft PowerPointプレゼンテーションを作成します。OLEオブジェクトには元のドキュメントへのリンクが含まれているため、埋め込まれたファイルをダブルクリックすると、そのファイルとそのアプリケーションが起動します。
### **VSTOの例**
VSTOを使用して、以下のステップが実行されます：

1. Microsoft Excel ApplicationClassオブジェクトのインスタンスを作成します。
1. 1シートの新しいワークブックを作成します。
1. シートにチャートを追加します。
1. ワークブックを保存します。
1. チャートデータを含むワークシートを持つExcelワークブックを開きます。
1. シートのChartObjectsコレクションを取得します。
1. コピーするチャートを取得します。
1. Microsoft PowerPointプレゼンテーションを作成します。
1. プレゼンテーションに空白のスライドを追加します。
1. Excelワークシートからクリップボードにチャートをコピーします。
1. チャートをPowerPointプレゼンテーションに貼り付けます。
1. スライド上にチャートを配置します。
1. プレゼンテーションを保存します。



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Aspose.Slides for Javaの例**
Aspose.Slides for .NETを使用して、以下のステップが実行されます：

1. Aspose.Cells for Javaを使用してワークブックを作成します。
1. Microsoft Excelチャートを作成します。
1. ExcelチャートのOLEサイズを設定します。
1. チャートの画像を取得します。
1. Aspose.Slides for Javaを使用してPPTXプレゼンテーション内にExcelチャートをOLEオブジェクトとして埋め込みます。
1. オブジェクトが変更された問題に対応するために、ステップ3で取得した画像で変更されたオブジェクトの画像を置き換えます。
1. 出力プレゼンテーションをPPTX形式でディスクに書き込みます。



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}