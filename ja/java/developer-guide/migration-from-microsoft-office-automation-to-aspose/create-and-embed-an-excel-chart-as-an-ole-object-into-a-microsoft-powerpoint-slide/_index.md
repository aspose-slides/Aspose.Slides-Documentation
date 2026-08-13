---
title: VSTO と Aspose.Slides for Java を使用して Excel チャートを OLE オブジェクトとして作成および埋め込み
linktitle: VSTO と Aspose.Slides for Java を使用して Excel チャートを OLE オブジェクトとして作成および埋め込み
type: docs
weight: 60
url: /ja/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- チャートを作成
- Excel チャートを埋め込む
- OLE オブジェクト
- 移行
- VSTO
- Office 自動化
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Microsoft Office の自動化から Aspose.Slides for Java に移行し、Java で Excel チャートを OLE オブジェクトとして PowerPoint (PPT, PPTX) スライドに埋め込みます。"
---
{{% alert color="info" %}} 
チャートはデータの視覚的表現であり、プレゼンテーションスライドで広く使用されています。本記事では、[VSTO](/slides/ja/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) と [Aspose.Slides for Java](/slides/ja/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) を使用して、Excel チャートを OLE オブジェクトとして PowerPoint スライドにプログラムで作成および埋め込むコードを示します。
{{% /alert %}} 
## **Excelチャートの作成と埋め込み**
以下の 2 つのコード例は、説明しているタスクが複雑なため長く詳細になっています。まず Microsoft Excel のワークブックを作成し、チャートを作成してから、チャートを埋め込む Microsoft PowerPoint プレゼンテーションを作成します。OLE オブジェクトは元のドキュメントへのリンクを保持しているため、埋め込まれたファイルをダブルクリックしたユーザーはそのファイルとアプリケーションを起動できます。
### **VSTO の例**
VSTO を使用して、次の手順を実行します。

1. Microsoft Excel ApplicationClass オブジェクトのインスタンスを作成します。
1. 1 シートだけの新しいワークブックを作成します。
1. シートにチャートを追加します。
1. ワークブックを保存します。
1. チャート データがあるワークシートを含む Excel ワークブックを開きます。
1. シートの ChartObjects コレクションを取得します。
1. コピーするチャートを取得します。
1. Microsoft PowerPoint プレゼンテーションを作成します。
1. プレゼンテーションに空白スライドを追加します。
1. Excel ワークシートからチャートをクリップボードにコピーします。
1. チャートを PowerPoint プレゼンテーションに貼り付けます。
1. スライド上にチャートの位置を設定します。
1. プレゼンテーションを保存します。

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Aspose.Slides for Java の例**
Aspose.Slides for .NET を使用して、次の手順を実行します。

1. Aspose.Cells for Java を使用してワークブックを作成します。
1. Microsoft Excel チャートを作成します。
1. Excel チャートの OLE サイズを設定します。
1. チャートの画像を取得します。
1. Aspose.Slides for Java を使用して、Excel チャートを PPTX プレゼンテーション内の OLE オブジェクトとして埋め込みます。
1. オブジェクト変更問題に対処するため、ステップ 3 で取得した画像でオブジェクトの変更画像を置き換えます。
1. 出力プレゼンテーションを PPTX 形式でディスクに書き込みます。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}