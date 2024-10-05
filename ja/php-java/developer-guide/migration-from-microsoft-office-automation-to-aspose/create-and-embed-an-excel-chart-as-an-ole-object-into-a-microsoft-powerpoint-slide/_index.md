---
title: Microsoft PowerPoint スライドに OLE オブジェクトとして Excel チャートを作成および埋め込む
type: docs
weight: 60
url: /php-java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
---

{{% alert color="primary" %}} 

 チャートはデータの視覚的表現であり、プレゼンテーション スライドで広く使用されています。この記事では、[VSTO](/slides/php-java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) と [Aspose.Slides for PHP via Java](/slides/php-java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) を使用して、Excel チャートを OLE オブジェクトとして PowerPoint スライドにプログラムmatically 埋め込むコードを示します。

{{% /alert %}} 
## **Excel チャートの作成と埋め込み**
以下の 2 つのコード例は、説明するタスクが複雑であるため、長く詳細です。Microsoft Excel ワークブックを作成し、チャートを作成し、次にそのチャートを埋め込む Microsoft PowerPoint プレゼンテーションを作成します。OLE オブジェクトには元のドキュメントへのリンクが含まれているため、埋め込まれたファイルをダブルクリックするユーザーは、そのファイルとアプリケーションが起動します。
### **VSTO 例**
VSTO を使用して、以下の手順が実行されます：

1. Microsoft Excel ApplicationClass オブジェクトのインスタンスを作成します。
1. 1 つのシートを含む新しいワークブックを作成します。
1. シートにチャートを追加します。
1. ワークブックを保存します。
1. チャート データを含むワークシートのある Excel ワークブックを開きます。
1. シートの ChartObjects コレクションを取得します。
1. コピーするチャートを取得します。
1. Microsoft PowerPoint プレゼンテーションを作成します。
1. プレゼンテーションに空白のスライドを追加します。
1. Excel ワークシートからクリップボードにチャートをコピーします。
1. PowerPoint プレゼンテーションにチャートを貼り付けます。
1. スライド上にチャートを配置します。
1. プレゼンテーションを保存します。



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Aspose.Slides for PHP via Java 例**
Aspose.Slides for .NET を使用して、以下の手順が実行されます：

1. Aspose.Cells for Java を使用してワークブックを作成します。
1. Microsoft Excel チャートを作成します。
1. Excel チャートの OLE サイズを設定します。
1. チャートの画像を取得します。
1. Aspose.Slides for PHP via Java を使用して PPTX プレゼンテーション内に Excel チャートを OLE オブジェクトとして埋め込みます。
1. ステップ 3 で取得した画像でオブジェクト変更の画像を置き換え、オブジェクト変更の問題に対処します。
1. 出力プレゼンテーションを PPTX 形式でディスクに書き込みます。



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}