---
title: C++ で OpenDocument プレゼンテーションを変換
linktitle: OpenDocument を変換
type: docs
weight: 10
url: /ja/cpp/convert-openoffice-odp/
keywords:
- ODP を変換
- ODP から画像へ
- ODP から GIF へ
- ODP から HTML へ
- ODP から JPG へ
- ODP から MD へ
- ODP から PDF へ
- ODP から PNG へ
- ODP から PPT へ
- ODP から PPTX へ
- ODP から TIFF へ
- ODP からビデオへ
- ODP から Word へ
- ODP から XPS へ
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ は、ODP を PDF、HTML、画像形式に簡単に変換できます。高速かつ正確なプレゼンテーション変換で C++ アプリを強化しましょう。"
---

[**Aspose.Slides API**](https://products.aspose.com/slides/cpp/) は、OpenDocument（ODP）プレゼンテーションを多数の形式（HTML、PDF、TIFF、SWF、XPS など）に変換できます。ODP ファイルを他のドキュメント形式に変換するために使用される API は、PowerPoint（PPT および PPTX）変換操作で使用されるものと同じです。

たとえば、ODP プレゼンテーションを PDF に変換する必要がある場合、以下のように実行できます：
```cpp
auto pres = MakeObject<Presentation>(u"pres.odp");
pres->Save(u"pres.pdf", SaveFormat::Pdf);
pres->Dispose();
```
