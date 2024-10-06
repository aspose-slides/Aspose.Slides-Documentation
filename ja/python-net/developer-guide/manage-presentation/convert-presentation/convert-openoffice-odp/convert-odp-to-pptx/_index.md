---
title: ODPをPPTXに変換
type: docs
weight: 10
url: /ja/python-net/convert-odp-to-pptx/
keywords: "OpenOfficeプレゼンテーションの変換, ODP, ODPをPPTXに, Python"
description: "PythonでOpenOffice ODPをPowerPointプレゼンテーションPPTXに変換"
---

Aspose.Slides for Python via .NETは、プレゼンテーションファイルを表すPresentationクラスを提供します。[**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスは、オブジェクトがインスタンス化されるときにPresentationコンストラクタを介してODPにアクセスすることも可能です。以下の例は、ODPプレゼンテーションをPPTXプレゼンテーションに変換する方法を示しています。

```py
# Aspose.Slides for Python via .NETモジュールのインポート
import aspose.slides as slides

# ODPファイルを開く
pres = slides.Presentation("AccessOpenDoc.odp")

# ODPプレゼンテーションをPPTX形式で保存
pres.save("AccessOpenDoc_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ライブ例**
[**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/)ウェブアプリにアクセスできます。このアプリは、**Aspose.Slides API**を使用して構築されています。このアプリは、Aspose.Slides APIを使用してODPからPPTXへの変換がどのように実装できるかを示しています。