---
title: Java で ODP を PPTX に変換
linktitle: ODP を PPTX に変換
type: docs
weight: 10
url: /ja/java/convert-odp-to-pptx/
keywords:
- OpenDocument を変換
- プレゼンテーションを変換
- スライドを変換
- ODP を変換
- OpenDocument から PPTX へ
- ODP から PPTX へ
- ODP を PPTX として保存
- ODP を PPTX にエクスポート
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して ODP を PPTX に変換します。クリーンな Java コード例、バッチのヒント、高品質な結果を提供し、PowerPoint は不要です。"
---

## **ODP を PPTX/PPT プレゼンテーションに変換**
Aspose.Slides for Java は、プレゼンテーション ファイルを表す [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスを提供します。 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスは、オブジェクトがインスタンス化されたときに、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#Presentation-java.lang.String-) コンストラクタを介して ODP にもアクセスできるようになりました。 以下の例は、ODP プレゼンテーションを PPTX プレゼンテーションに変換する方法を示しています。
```java
// ODP ファイルを開く
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// ODP プレゼンテーションを PPTX 形式で保存
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **ライブ例**
以下の Web アプリにアクセスできます。[**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) は **Aspose.Slides API** を使用して構築されています。このアプリは、ODP から PPTX への変換が Aspose.Slides API でどのように実装できるかを示しています。