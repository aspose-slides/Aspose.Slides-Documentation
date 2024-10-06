---
title: Microsoft PowerPointプレゼンテーションにチャートを作成する
type: docs
weight: 70
url: /ja/php-java/create-a-chart-in-a-microsoft-powerpoint-presentation/
---

{{% alert color="primary" %}} 

 チャートはデータの視覚的表現であり、プレゼンテーションで広く使用されています。本記事では、[VSTO](/slides/ja/php-java/create-a-chart-in-a-microsoft-powerpoint-presentation/)および[Aspose.Slides for PHP via Java](/slides/ja/php-java/create-a-chart-in-a-microsoft-powerpoint-presentation/)を使用して、Microsoft PowerPointでプログラム的にチャートを作成するためのコードを示します。

{{% /alert %}} 
## **チャートの作成**
以下のコード例は、VSTOを使用してシンプルな3Dクラスタ型カラムチャートを追加するプロセスを説明しています。プレゼンテーションのインスタンスを作成し、デフォルトのチャートを追加します。その後、Microsoft Excelワークブックを使用してチャートデータにアクセスし、チャートプロパティを設定します。最後に、プレゼンテーションを保存します。
### **VSTOの例**
VSTOを使用して、以下の手順が実行されます：

1. Microsoft PowerPointプレゼンテーションのインスタンスを作成します。
1. プレゼンテーションに空白のスライドを追加します。
1. **3Dクラスタ型カラム**チャートを追加し、それにアクセスします。
1. 新しいMicrosoft Excelワークブックインスタンスを作成し、チャートデータを読み込みます。
1. Microsoft Excelワークブックインスタンスからチャートデータワークシートにアクセスします。
1. ワークシート内のチャート範囲を設定し、チャートからシリーズ2および3を削除します。
1. チャートデータワークシート内のチャートカテゴリデータを修正します。
1. チャートデータワークシート内のチャートシリーズ1データを修正します。
1. チャートタイトルにアクセスし、フォント関連のプロパティを設定します。
1. チャート値軸にアクセスし、主単位、従単位、最大値および最小値を設定します。
1. チャートの深さまたはシリーズ軸にアクセスし、この例のように1つの系列のみが使用されているため、それを削除します。
1. XおよびY方向のチャート回転角度を設定します。
1. プレゼンテーションを保存します。
1. Microsoft ExcelおよびPowerPointのインスタンスを閉じます。

**VSTOで作成された出力プレゼンテーション** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **Aspose.Slides for PHP via Javaの例**
Aspose.Slides for PHP via Javaを使用して、以下の手順が実行されます：

1. Microsoft PowerPointプレゼンテーションのインスタンスを作成します。
1. プレゼンテーションに空白のスライドを追加します。
1. **3Dクラスタ型カラム**チャートを追加し、それにアクセスします。
1. Microsoft Excelワークブックインスタンスからチャートデータワークシートにアクセスします。
1. 使用されていないシリーズ2および3を削除します。
1. チャートのカテゴリにアクセスし、ラベルを修正します。
1. シリーズ1にアクセスし、シリーズの値を修正します。
1. チャートタイトルにアクセスし、フォントプロパティを設定します。
1. チャート値軸にアクセスし、主単位、従単位、最大値および最小値を設定します。
1. XおよびY方向のチャート回転角度を設定します。
1. プレゼンテーションをPPTX形式で保存します。

**Aspose.Slidesで作成された出力プレゼンテーション** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}