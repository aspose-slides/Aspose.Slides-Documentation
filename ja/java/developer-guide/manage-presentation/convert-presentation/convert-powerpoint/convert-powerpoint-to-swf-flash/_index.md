---
title: JavaでPowerPointプレゼンテーションをSWF Flashに変換
linktitle: PowerPointからSWFへ
type: docs
weight: 80
url: /ja/java/convert-powerpoint-to-swf-flash/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- スライドを変換
- PPTを変換
- PPTXを変換
- PowerPointからSWFへ
- プレゼンテーションからSWFへ
- スライドからSWFへ
- PPTからSWFへ
- PPTXからSWFへ
- PowerPointからFlashへ
- プレゼンテーションからFlashへ
- スライドからFlashへ
- PPTからFlashへ
- PPTXからFlashへ
- PPTをSWFとして保存
- PPTXをSWFとして保存
- PPTをSWFにエクスポート
- PPTXをSWFにエクスポート
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して、JavaでPowerPoint（PPT/PPTX）をSWF Flashに変換します。ステップバイステップのコードサンプル、迅速で高品質な出力、PowerPoint の自動化不要。"
---

## **PPT(X) を SWF に変換**
[Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) メソッドは、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスで公開されており、プレゼンテーション全体を **SWF** ドキュメントに変換するために使用できます。以下の例は、[**SWFOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/SwfOptions) クラスが提供するオプションを使用して、プレゼンテーションを **SWF** ドキュメントに変換する方法を示しています。生成された SWF にコメントを含めるには、[**ISWFOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/ISwfOptions) クラスと[**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions) インターフェイスを使用することもできます。
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
