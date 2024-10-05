---
title: OpenOffice ODPを変換
type: docs
weight: 10
url: /cpp/convert-openoffice-odp/
keywords: "ODPをPDFに変換, ODPをHTMLに変換, ODPをTIFFに変換"
description: "Aspose.Slidesを使用してODPをPDF、ODPをPPT、ODPをPPTX、ODPをHTMLおよびその他の形式に変換します。"
---

[**Aspose.Slides API**](https://products.aspose.com/slides/cpp/) を使用すると、OpenOffice ODPプレゼンテーションをさまざまな形式に変換できます。ODPファイルを他のドキュメント形式に変換するために使用されるAPIは、PowerPoint（PPTおよびPPTX）変換操作にも使用される同じものです。

これらの例は、ソースODPファイルを変更するだけでODPドキュメントを他の形式に変換する方法を示しています。

- [ODPをHTMLに変換](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-html/)
- [ODPをPDFに変換](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [ODPをTIFFに変換](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-tiff/)
- [ODPをSWF Flashに変換](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-swf-flash/)
- [ODPをXPSに変換](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)
- [ノート付きでODPをPDFに変換](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-pdf-with-notes/)
- [ノート付きでODPをTIFFに変換](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)

例えば、ODPプレゼンテーションをPDFに変換する必要がある場合、次のように行うことができます：

``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"pres.odp");
pres->Save(u"pres.pdf", SaveFormat::Pdf);
```