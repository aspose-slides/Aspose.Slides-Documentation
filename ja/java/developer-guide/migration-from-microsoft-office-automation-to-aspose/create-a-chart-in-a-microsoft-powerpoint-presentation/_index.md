---
title: Microsoft PowerPoint プレゼンテーションにチャートを作成する
type: docs
weight: 70
url: /java/create-a-chart-in-a-microsoft-powerpoint-presentation/
---

{{% alert color="primary" %}} 

 チャートは、プレゼンテーションで広く使用されるデータの視覚的表現です。この記事では、[VSTO](/slides/java/create-a-chart-in-a-microsoft-powerpoint-presentation/)と[Aspose.Slides for Java](/slides/java/create-a-chart-in-a-microsoft-powerpoint-presentation/)を使用して、Microsoft PowerPointでプログラム的にチャートを作成するためのコードを示します。

{{% /alert %}} 
## **チャートの作成**
以下のコード例は、VSTOを使用してシンプルな3Dクラスター型カラムチャートを追加するプロセスを説明しています。プレゼンテーションインスタンスを作成し、デフォルトのチャートを追加します。次に、Microsoft Excelワークブックを使用してチャートデータにアクセスし、チャートプロパティを設定します。最後に、プレゼンテーションを保存します。
### **VSTOの例**
VSTOを使用して、以下の手順を実行します：

1. Microsoft PowerPointプレゼンテーションのインスタンスを作成します。
1. プレゼンテーションに空白のスライドを追加します。
1. **3Dクラスター型カラム**チャートを追加し、それにアクセスします。
1. 新しいMicrosoft Excel Workbookインスタンスを作成し、チャートデータを読み込みます。
1. Microsoft Excel Workbookインスタンスを使用してチャートデータワークシートにアクセスします。
1. ワークシートのチャート範囲を設定し、シリーズ2と3をチャートから削除します。
1. チャートデータワークシートのチャートカテゴリーデータを変更します。
1. チャートデータワークシートのチャートシリーズ1データを変更します。
1. さて、チャートタイトルにアクセスし、フォント関連のプロパティを設定します。
1. チャート値軸にアクセスし、主要単位、補助単位、最大値と最小値を設定します。
1. チャートの深さまたはシリーズ軸にアクセスし、例のようにその軸を削除します。ここでは1つのシリーズのみが使用されます。
1. さて、X軸およびY軸のチャート回転角度を設定します。
1. プレゼンテーションを保存します。
1. Microsoft ExcelおよびPowerPointのインスタンスを閉じます。

**VSTOで作成した出力プレゼンテーション** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **Aspose.Slides for Javaの例**
Aspose.Slides for Javaを使用して、以下の手順を実行します：

1. Microsoft PowerPointプレゼンテーションのインスタンスを作成します。
1. プレゼンテーションに空白のスライドを追加します。
1. **3Dクラスター型カラム**チャートを追加し、それにアクセスします。
1. Microsoft Excel Workbookインスタンスを使用してチャートデータワークシートにアクセスします。
1. 使用されていないシリーズ2と3を削除します。
1. チャートのカテゴリにアクセスし、ラベルを変更します。
1. シリーズ1にアクセスして、シリーズの値を変更します。
1. さて、チャートタイトルにアクセスし、フォントプロパティを設定します。
1. チャート値軸にアクセスし、主要単位、補助単位、最大値と最小値を設定します。
1. さて、X軸およびY軸のチャート回転角度を設定します。
1. プレゼンテーションをPPTX形式で保存します。

**Aspose.Slidesで作成した出力プレゼンテーション** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}