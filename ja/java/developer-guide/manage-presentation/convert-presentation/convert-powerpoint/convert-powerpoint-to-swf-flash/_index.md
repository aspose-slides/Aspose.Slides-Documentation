---
title: PowerPointをSWF Flashに変換
type: docs
weight: 80
url: /ja/java/convert-powerpoint-to-swf-flash/
keywords: "PPT, PPTX to SWF"
description: "JavaでPowerPoint PPT, PPTXをSWFに変換"
---

## **PPT(X)をSWFに変換**
[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)クラスによって公開されている[Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)メソッドを使用して、全体のプレゼンテーションを**SWF**文書に変換できます。以下の例は、[**SWFOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/SwfOptions)クラスが提供するオプションを使用して、プレゼンテーションを**SWF**文書に変換する方法を示しています。また、生成されたSWFにコメントを含めることもでき、[**ISWFOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/ISwfOptions)クラスと[**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions)インターフェースを使用できます。

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    // プレゼンテーションの保存
    pres.save("Sample.swf", SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```