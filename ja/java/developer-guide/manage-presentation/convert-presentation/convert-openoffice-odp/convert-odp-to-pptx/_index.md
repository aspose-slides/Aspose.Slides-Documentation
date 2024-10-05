---
title: ODPをPPTXに変換
type: docs
weight: 10
url: /java/convert-odp-to-pptx/
---

## **ODPをPPTX/PPTプレゼンテーションに変換**
Aspose.Slides for Javaは、プレゼンテーションファイルを表す[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスを提供します。[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスは、オブジェクトがインスタンス化されるときに[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#Presentation-java.lang.String-)コンストラクターを介してODPにアクセスすることもできます。以下の例は、ODPプレゼンテーションをPPTXプレゼンテーションに変換する方法を示しています。

```java
// ODPファイルを開く
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// ODPプレゼンテーションをPPTX形式で保存
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ライブ例**
[**Aspose.Slides変換**](https://products.aspose.app/slides/conversion/)のウェブアプリにアクセスできます。このアプリは、**Aspose.Slides API**を使用して構築されています。このアプリは、Aspose.Slides APIを使用してODPをPPTXに変換する方法を示しています。