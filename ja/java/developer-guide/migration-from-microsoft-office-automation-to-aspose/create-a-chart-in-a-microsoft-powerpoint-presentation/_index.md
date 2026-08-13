---
title: VSTO と Aspose.Slides for Java を使用したチャート作成
linktitle: チャート作成
type: docs
weight: 70
url: /ja/java/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- チャート作成
- 移行
- VSTO
- Office 自動化
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Java で PowerPoint のチャート作成を自動化する方法を学びます。このステップバイステップ ガイドでは、Aspose.Slides for Java が Microsoft.Office.Interop よりも高速で、より強力な代替手段である理由を示します。"
---
{{% alert color="info" %}} 

チャートはデータの視覚的表現で、プレゼンテーションで広く使用されています。このガイドでは、[VSTO](/slides/ja/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) と [Aspose.Slides for Java](/slides/ja/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) を使用して、Microsoft PowerPoint にプログラムでチャートを作成するコードを示します。

{{% /alert %}} 
## **チャートの作成**
以下のコード例は、VSTO を使用してシンプルな 3D クラスタ化縦棒グラフを追加する手順を示しています。プレゼンテーションのインスタンスを作成し、デフォルトのチャートを追加します。その後、Microsoft Excel ワークブックを使用してチャート データにアクセスし、変更するとともにチャート プロパティを設定します。最後に、プレゼンテーションを保存します。
### **VSTO の例**
VSTO を使用して、以下の手順が実行されます：

1. Microsoft PowerPoint プレゼンテーションのインスタンスを作成します。
1. プレゼンテーションに空白スライドを追加します。
1. **3D clustered column** のチャートを追加し、アクセスします。
1. 新しい Microsoft Excel Workbook のインスタンスを作成し、チャート データをロードします。
1. Microsoft Excel Workbook instancefromworkbook を使用して、チャート データ ワークシートにアクセスします。
1. ワークシートでチャート範囲を設定し、チャートからシリーズ 2 と 3 を削除します。
1. チャート データ ワークシート内のカテゴリ データを変更します。
1. チャート データ ワークシート内のシリーズ 1 データを変更します。
1. 次に、チャート タイトルにアクセスし、setthefontrelatedproperties を設定します。
1. チャートの値軸にアクセスし、主要単位、補助単位、最大値、最小値を設定します。
1. この例では、チャートの深度またはシリーズ軸にアクセスし、onlyoneserieisused のようにそれを削除します。
1. 次に、X および Y 方向のチャート回転角度を設定します。
1. プレゼンテーションを保存します。
1. Microsoft Excel と PowerPoint のインスタンスを閉じます。

**VSTO で作成された出力プレゼンテーション** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **Aspose.Slides for Java の例**
Aspose.Slides for Java を使用して、以下の手順が実行されます：

1. Microsoft PowerPoint プレゼンテーションのインスタンスを作成します。
1. プレゼンテーションに空白スライドを追加します。
1. **3D clustered column** のチャートを追加し、それにアクセスします。
1. Microsoft Excel Workbook instancefromworkbook を使用して、チャート データ ワークシートにアクセスします。
1. 未使用のシリーズ 2 と 3 を削除します。
1. チャート カテゴリにアクセスし、ラベルを変更します。
1. Accesseries1 にアクセスし、シリーズの値を変更します。
1. 次に、チャート タイトルにアクセスし、フォント プロパティを設定します。
1. チャートの値軸にアクセスし、主要単位、補助単位、最大値、最小値を設定します。
1. 次に、X および Y 方向のチャート回転角度を設定します。
1. プレゼンテーションを PPTX 形式で保存します。

**Aspose.Slides で作成された出力プレゼンテーション** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}

## **よくある質問**

### Aspose.Slides で円グラフ、折れ線グラフ、棒グラフなどの他の種類のチャートを作成できますか？

はい。Aspose.Slides は、円グラフ、折れ線グラフ、棒グラフ、散布図、バブル チャートなど、幅広い [chart types](/slides/ja/java/create-chart/) をサポートしています。チャートを追加する際に、[ChartType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/charttype/) クラスを使用して目的のチャートタイプを指定できます。

### チャートにカスタム スタイルやテーマを適用できますか？

はい。色、フォント、塗りつぶし、輪郭、グリッド線、レイアウトなど、チャートの外観を完全にカスタマイズできます。ただし、PowerPoint に表示される Office テーマをそのまま適用するには、個々のスタイルを手動で設定する必要があります。

### スライドとは別にチャートを画像としてエクスポートできますか？

はい、Aspose.Slides を使用すると、チャートを含む任意のシェイプを、チャート [shape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/shape/) の `getImage` メソッドを利用して、PNG や JPEG などの別個の画像としてエクスポートできます。