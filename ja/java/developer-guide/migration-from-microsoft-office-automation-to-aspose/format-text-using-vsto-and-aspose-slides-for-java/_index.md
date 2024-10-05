---
title: VSTOとAspose.Slides for Javaを使用したテキストのフォーマット
type: docs
weight: 30
url: /java/format-text-using-vsto-and-aspose-slides-for-java/
---

{{% alert color="primary" %}} 

時には、スライドのテキストをプログラム的にフォーマットする必要があります。この記事では、[VSTO](/slides/java/format-text-using-vsto-and-aspose-slides-for-java/)と[Aspose.Slides for Java](/slides/java/format-text-using-vsto-and-aspose-slides-for-java/)のいずれかを使用して、最初のスライドにあるテキストを含むサンプルプレゼンテーションを読む方法を示します。このコードは、スライドの3つ目のテキストボックスのテキストを、最後のテキストボックスのテキストのように見えるようにフォーマットします。

{{% /alert %}} 
## **テキストのフォーマット**
VSTOとAspose.Slidesの両方の方法は、次の手順を実行します。

1. ソースプレゼンテーションを開く。
1. 最初のスライドにアクセスする。
1. 3つ目のテキストボックスにアクセスする。
1. 3つ目のテキストボックスのテキストのフォーマットを変更する。
1. プレゼンテーションをディスクに保存する。

以下のスクリーンショットは、VSTOとAspose.Slides for Javaコードの実行前後のサンプルスライドを示しています。

**入力プレゼンテーション** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **VSTOコードの例**
以下のコードは、VSTOを使用してスライド上のテキストを再フォーマットする方法を示しています。

**VSTOで再フォーマットされたテキスト** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}


### **Aspose.Slides for Javaの例**
Aspose.Slidesを使用してテキストをフォーマットするには、テキストをフォーマットする前にフォントを追加します。

**Aspose.Slidesで作成された出力プレゼンテーション** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}