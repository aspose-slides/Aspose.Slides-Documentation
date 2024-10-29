---
title: ODPをPPTXに変換
type: docs
weight: 10
url: /ja/php-java/convert-odp-to-pptx/
---

## **ODPをPPTX/PPTプレゼンテーションに変換**
Aspose.Slides for PHP via Javaは、プレゼンテーションファイルを表す[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスを提供します。[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスは、オブジェクトがインスタンス化されたときに[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#Presentation-java.lang.String-)コンストラクタを通じてODPにもアクセスできるようになりました。以下の例は、ODPプレゼンテーションをPPTXプレゼンテーションに変換する方法を示しています。

```php
// ODPファイルを開く
  $pres = new Presentation("AccessOpenDoc.odp");
  try {
  } finally {
  }
  # ODPプレゼンテーションをPPTX形式で保存する
  $pres->save("AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```

## **ライブ例**
[**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/)のウェブアプリにアクセスできます。このアプリは、**Aspose.Slides API**で構築されています。このアプリは、Aspose.Slides APIを使用したODPからPPTXへの変換がどのように実装できるかを示しています。