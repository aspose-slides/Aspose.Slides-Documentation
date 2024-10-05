---
title: VSTO および Java を介した Aspose.Slides for PHP を使用してテキストをフォーマットする
type: docs
weight: 30
url: /php-java/format-text-using-vsto-and-aspose-slides-for-java/
---

{{% alert color="primary" %}} 

場合によっては、スライド上のテキストをプログラムでフォーマットする必要があります。この記事では、[VSTO](/slides/php-java/format-text-using-vsto-and-aspose-slides-for-java/) および [Aspose.Slides for PHP via Java](/slides/php-java/format-text-using-vsto-and-aspose-slides-for-java/) を使用して、最初のスライドにあるいくつかのテキストを含むサンプルプレゼンテーションを読み取る方法を示します。コードは、スライドの3番目のテキストボックスのテキストを最後のテキストボックスのテキストのように見えるようにフォーマットします。

{{% /alert %}} 
## **テキストのフォーマット**
VSTO と Aspose.Slides の両方の方法は、次の手順を踏みます：

1. ソースプレゼンテーションを開く。
1. 最初のスライドにアクセスする。
1. 3番目のテキストボックスにアクセスする。
1. 3番目のテキストボックスのテキストのフォーマットを変更する。
1. プレゼンテーションをディスクに保存する。

以下のスクリーンショットは、VSTO と PHP を介した Aspose.Slides の実行前後のサンプルスライドを示しています。

**入力プレゼンテーション**

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **VSTO コード例**
以下のコードは、VSTO を使用してスライド上のテキストを再フォーマットする方法を示しています。

**VSTO で再フォーマットされたテキスト**

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}


### **Java を介した Aspose.Slides for PHP の例**
Aspose.Slides でテキストをフォーマットするには、テキストをフォーマットする前にフォントを追加します。

**Aspose.Slides で作成された出力プレゼンテーション**

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}