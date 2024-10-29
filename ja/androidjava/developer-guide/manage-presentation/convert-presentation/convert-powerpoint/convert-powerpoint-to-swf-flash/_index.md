---
title: PowerPointをSWF Flashに変換
type: docs
weight: 80
url: /ja/androidjava/convert-powerpoint-to-swf-flash/
keywords: "PPT, PPTX to SWF"
description: "JavaでPowerPoint PPT、PPTXをSWFに変換"
---

## **PPT(X)をSWFに変換**
[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)クラスが公開する[Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)メソッドを使用して、プレゼンテーション全体を**SWF**ドキュメントに変換できます。以下の例は、[**SWFOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SwfOptions)クラスが提供するオプションを使用して、プレゼンテーションを**SWF**ドキュメントに変換する方法を示しています。また、[**ISWFOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISwfOptions)クラスおよび[**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions)インターフェースを使用して、生成されたSWFにコメントを含めることもできます。

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    // プレゼンテーションを保存
    pres.save("Sample.swf", SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```