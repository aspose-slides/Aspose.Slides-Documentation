---
title: ODPをPPTXに変換
type: docs
weight: 10
url: /ja/cpp/convert-odp-to-pptx/
---

Aspose.Slides for .NETはプレゼンテーションファイルを表すPresentationクラスを提供します。[**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスは、オブジェクトがインスタンス化されるときにPresentationコンストラクターを通じてODPにアクセスすることもできます。以下の例は、ODPプレゼンテーションをPPTXプレゼンテーションに変換する方法を示しています。

``` cpp
// ドキュメントディレクトリのパス。
String dataDir = GetDataPath();

// ODPファイルを開く
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// ODPプレゼンテーションをPPTX形式で保存
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```



## **ライブ例**
[**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/)ウェブアプリにアクセスできます。これは、**Aspose.Slides API**を使用して構築されています。このアプリは、Aspose.Slides APIを使用してODPをPPTXに変換する方法を示しています。