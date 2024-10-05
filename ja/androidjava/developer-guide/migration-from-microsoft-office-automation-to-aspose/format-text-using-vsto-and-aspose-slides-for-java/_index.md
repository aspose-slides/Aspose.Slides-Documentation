---
title: VSTOおよびJava経由でのAspose.Slidesを使用したテキストのフォーマット
type: docs
weight: 30
url: /androidjava/format-text-using-vsto-and-aspose-slides-for-java/
---

{{% alert color="primary" %}} 

時には、スライド上のテキストをプログラム的にフォーマットする必要があります。この記事では、[VSTO](/slides/androidjava/format-text-using-vsto-and-aspose-slides-for-java/)および[Aspose.Slides for Android via Java](/slides/androidjava/format-text-using-vsto-and-aspose-slides-for-java/)を使用して、最初のスライドにいくつかのテキストがあるサンプルプレゼンテーションを読み込む方法を示します。このコードは、スライドの第三のテキストボックスのテキストを最後のテキストボックスのテキストのように見えるようにフォーマットします。

{{% /alert %}} 
## **テキストのフォーマット**
VSTOおよびAspose.Slidesの両方のメソッドは、次のステップを実行します：

1. ソースプレゼンテーションを開く。
1. 最初のスライドにアクセスする。
1. 第三のテキストボックスにアクセスする。
1. 第三のテキストボックス内のテキストのフォーマットを変更する。
1. プレゼンテーションをディスクに保存する。

以下のスクリーンショットは、VSTOおよびJava経由のAspose.Slidesのコードを実行する前後のサンプルスライドを示しています。

**入力プレゼンテーション** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **VSTOコード例**
以下のコードは、VSTOを使用してスライド上のテキストを再フォーマットする方法を示しています。

**VSTOで再フォーマットしたテキスト** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}


### **Java経由のAspose.Slidesの例**
Aspose.Slidesでテキストをフォーマットするには、テキストのフォーマットを行う前にフォントを追加します。

**Aspose.Slidesで作成された出力プレゼンテーション** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}