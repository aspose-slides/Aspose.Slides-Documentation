---
title: 在 C++ 中轉換 OpenDocument 簡報
linktitle: 轉換 OpenDocument
type: docs
weight: 10
url: /zh-hant/cpp/convert-openoffice-odp/
keywords:
- 轉換 ODP
- ODP 轉圖像
- ODP 轉 GIF
- ODP 轉 HTML
- ODP 轉 JPG
- ODP 轉 MD
- ODP 轉 PDF
- ODP 轉 PNG
- ODP 轉 PPT
- ODP 轉 PPTX
- ODP 轉 TIFF
- ODP 轉影片
- ODP 轉 Word
- ODP 轉 XPS
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ 讓您輕鬆將 ODP 轉換為 PDF、HTML 和圖像格式。透過快速且精確的簡報轉換，提升您的 C++ 應用程式效能。"
---
[**Aspose.Slides API**](https://products.aspose.com/slides/zh-hant/cpp/) 允許您將 OpenDocument (ODP) 簡報轉換為多種格式 (HTML、PDF、TIFF、SWF、XPS 等)。用於將 ODP 檔案轉換為其他文件格式的 API 與用於 PowerPoint (PPT 和 PPTX) 轉換操作的 API 相同。

例如，若您需要將 ODP 簡報轉換為 PDF，您可以按以下方式操作：

```cpp
auto pres = MakeObject<Presentation>(u"pres.odp");
pres->Save(u"pres.pdf", SaveFormat::Pdf);
pres->Dispose();
```