---
title: Microsoft PowerPointプレゼンテーションにチャートを作成する
type: docs
weight: 70
url: /ja/androidjava/create-a-chart-in-a-microsoft-powerpoint-presentation/
---

{{% alert color="primary" %}} 

 チャートはデータの視覚的表現であり、プレゼンテーションで広く使用されています。この記事では、[VSTO](/slides/ja/androidjava/create-a-chart-in-a-microsoft-powerpoint-presentation/) と [Aspose.Slides for Android via Java](/slides/ja/androidjava/create-a-chart-in-a-microsoft-powerpoint-presentation/) を使用して、Microsoft PowerPointでプログラム的にチャートを作成するコードを示します。

{{% /alert %}} 
## **チャートの作成**
以下のコード例は、VSTOを使用してシンプルな3Dクラスタカラムチャートを追加するプロセスを説明しています。プレゼンテーションインスタンスを作成し、デフォルトのチャートを追加します。その後、Microsoft Excelワークブックを使用して、チャートデータにアクセスし、チャートプロパティを設定します。最後に、プレゼンテーションを保存します。
### **VSTOの例**
VSTOを使用して、以下の手順が実行されます：

1. Microsoft PowerPointプレゼンテーションのインスタンスを作成します。
1. プレゼンテーションに空白のスライドを追加します。
1. **3Dクラスタカラム**チャートを追加し、それにアクセスします。
1. 新しいMicrosoft Excelワークブックインスタンスを作成し、チャートデータをロードします。
1. Microsoft Excelワークブックインスタンスを使用してチャートデータワークシートにアクセスします。
1. ワークシートでチャート範囲を設定し、シリーズ2と3をチャートから削除します。
1. チャートデータワークシートでチャートカテゴリデータを変更します。
1. チャートデータワークシートでチャートシリーズ1のデータを変更します。
1. それから、チャートタイトルにアクセスし、フォント関連プロパティを設定します。
1. チャート値軸にアクセスし、主要単位、小単位、最大値、および最小値を設定します。
1. チャートの深さまたはシリーズ軸にアクセスし、この例では1つのシリーズしか使用されないため、それを削除します。
1. それから、XおよびY方向のチャート回転角度を設定します。
1. プレゼンテーションを保存します。
1. Microsoft ExcelおよびPowerPointのインスタンスを閉じます。

**VSTOで作成された出力プレゼンテーション** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **Aspose.Slides for Android via Javaの例**
Aspose.Slides for Android via Javaを使用して、以下の手順が実行されます：

1. Microsoft PowerPointプレゼンテーションのインスタンスを作成します。
1. プレゼンテーションに空白のスライドを追加します。
1. **3Dクラスタカラム**チャートを追加し、それにアクセスします。
1. Microsoft Excelワークブックインスタンスを使用してチャートデータワークシートにアクセスします。
1. 未使用のシリーズ2と3を削除します。
1. チャートカテゴリにアクセスし、ラベルを変更します。
1. シリーズ1にアクセスし、シリーズ値を変更します。
1. それから、チャートタイトルにアクセスし、フォントプロパティを設定します。
1. チャート値軸にアクセスし、主要単位、小単位、最大値、および最小値を設定します。
1. それから、XおよびY方向のチャート回転角度を設定します。
1. プレゼンテーションをPPTX形式で保存します。

**Aspose.Slidesで作成された出力プレゼンテーション** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}