---
title: API の制限
type: docs
weight: 320
url: /ja/cpp/api-limitations/
keywords:
- API の制限
- エクスポート形式
- アプリケーション
- プロデューサー
- ドキュメント プロパティ
- メタデータ
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ の制限を把握しましょう。エクスポートでは PPT、PPTX、ODP、PDF の Application/Producer メタデータが固定されるため、サプライズなしで統合計画を立てることができます。"
---

## **アプリケーションとプロデューサー**

Aspose.Slides for C++ を使用してプレゼンテーションを作成またはエクスポートすると、いくつかの技術的メタデータがファイルに書き込まれます。2 つのフィールドがしばしば質問されます。

**Application** は **PPTX** プレゼンテーションを作成または最後に保存したプログラムを識別します。Aspose.Slides for C++ では、この値は固定されており、アプリ名ではなくライブラリベンダーが表示されます。たとえ [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/cpp/aspose.slides/documentproperties/set_nameofapplication/) を使用しても同様です。

**Producer** はエクスポート時に最終ファイルを生成したレンダリングエンジンを識別します。**PDF** エクスポートでは、メタデータは **Creator** と **Producer** フィールドを使用します。Aspose.Slides for C++ では、これらは固定されており、ライブラリとそのバージョンを示します。

**制限事項**

上記の形式については、API を介してこれらのフィールドを上書きすることはできません。**PPTX** の場合、Application プロパティは「Aspose.Slides for C++」として書き込まれます。**PDF** の場合、Creator および Producer プロパティは「Aspose.Slides for C++ x.x.x」として書き込まれます。この動作は設計上のものであり、ファイルの読み込みや保存方法に関係なく、また [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/cpp/aspose.slides/documentproperties/set_nameofapplication/) で設定した値に関係なく適用されます。