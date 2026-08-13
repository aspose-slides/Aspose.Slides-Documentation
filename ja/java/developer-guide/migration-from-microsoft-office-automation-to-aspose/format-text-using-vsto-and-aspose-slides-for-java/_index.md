---
title: VSTO と Aspose.Slides for Java を使用したテキストの書式設定
linktitle: テキストの書式設定
type: docs
weight: 30
url: /ja/java/format-text-using-vsto-and-aspose-slides-for-java/
keywords:
- テキストの書式設定
- 移行
- VSTO
- Office 自動化
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Microsoft Office の自動化から Aspose.Slides for Java に移行し、PowerPoint (PPT、PPTX) プレゼンテーション内のテキストを正確に制御して書式設定します。"
---
{{% alert color="info" %}}

時々、スライド上のテキストをプログラムで書式設定する必要があります。本記事では、[VSTO](/slides/ja/java/format-text-using-vsto-and-aspose-slides-for-java/) と [Aspose.Slides for Java](/slides/ja/java/format-text-using-vsto-and-aspose-slides-for-java/) のいずれかを使用して、最初のスライドにテキストが含まれるサンプル プレゼンテーションを読み取る方法を示します。コードは、スライド上の3番目のテキストボックスのテキストを書式設定し、最後のテキストボックスのテキストと同じように見えるようにします。

{{% /alert %}}
## **テキストの書式設定**
VSTO と Aspose.Slides の両方のメソッドは、次の手順を実行します。

1. ソース プレゼンテーションを開く。
1. 最初のスライドにアクセスする。
1. 3番目のテキスト ボックスにアクセスする。
1. 3番目のテキスト ボックス内のテキストの書式設定を変更する。
1. プレゼンテーションをディスクに保存する。

以下のスクリーンショットは、VSTO および Aspose.Slides for Java のコード実行前後のサンプル スライドを示しています。

**入力プレゼンテーション**

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **VSTO コード例**
以下のコードは、VSTO を使用してスライド上のテキストを書式設定し直す方法を示しています。

**VSTO で書式設定されたテキスト**

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}

### **Aspose.Slides for Java の例**
Aspose.Slides でテキストをフォーマットするには、テキストの書式設定の前にフォントを追加します。

**Aspose.Slides で作成された出力プレゼンテーション**

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}