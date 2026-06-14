---
title: 使用 VSTO 和 Aspose.Slides for Java 格式化文字
linktitle: 格式化文字
type: docs
weight: 30
url: /zh-hant/java/format-text-using-vsto-and-aspose-slides-for-java/
keywords:
- 格式化文字
- 遷移
- VSTO
- Office 自動化
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "從 Microsoft Office 自動化遷移至 Aspose.Slides for Java，並以精確的控制在 PowerPoint（PPT、PPTX）簡報中格式化文字。"
---
{{% alert color="primary" %}} 
有時，您需要以程式方式格式化投影片中的文字。本文章說明如何使用 [VSTO](/slides/zh-hant/java/format-text-using-vsto-and-aspose-slides-for-java/) 或 [Aspose.Slides for Java](/slides/zh-hant/java/format-text-using-vsto-and-aspose-slides-for-java/) 讀取第一張投影片包含文字的範例簡報。程式碼會將投影片中第三個文字方塊的文字格式化，使其看起來與最後一個文字方塊的文字相同。
{{% /alert %}} 
## **格式化文字**
VSTO 與 Aspose.Slides 方法皆遵循以下步驟：

1. 開啟來源簡報。
1. 存取第一張投影片。
1. 存取第三個文字方塊。
1. 變更第三個文字方塊中文本的格式。
1. 將簡報儲存至磁碟。

以下螢幕擷取圖顯示執行 VSTO 與 Aspose.Slides for Java 程式碼前後的範例投影片。

**輸入簡報** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **VSTO 程式碼範例**
以下程式碼示範如何使用 VSTO 重新格式化投影片上的文字。

**使用 VSTO 重新格式化的文字** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}

### **Aspose.Slides for Java 範例**
若要使用 Aspose.Slides 格式化文字，請先加入字型再進行文字格式化。

**使用 Aspose.Slides 建立的輸出簡報** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}