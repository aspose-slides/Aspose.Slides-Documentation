---
title: API の制限
type: docs
weight: 210
url: /ja/python-net/api-limitations/
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
- Python
- Aspose.Slides
description: "Aspose.Slides for Python の制限を把握しましょう。エクスポート時に PPT、PPTX、ODP、PDF で固定された Application/Producer メタデータが設定されるため、サプライズなく統合計画が立てられます。"
---

## **アプリケーションとプロデューサー**

Aspose.Slides for Python via .NET でプレゼンテーションを作成またはエクスポートすると、いくつかの技術メタデータがファイルに書き込まれます。よく質問されるフィールドが 2 つあります。

**Application** は、**PPTX** プレゼンテーションを作成または最後に保存したプログラムを識別します。Aspose.Slides for Python via .NET では、この値は固定されており、ライブラリベンダーが表示されます。たとえ [DocumentProperties.name_of_application](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/name_of_application/) を設定しても、アプリ名にはなりません。

**Producer** は、エクスポート時に最終ファイルを生成したレンダリングエンジンを識別します。**PDF** エクスポートでは、メタデータは **Creator** と **Producer** フィールドを使用します。Aspose.Slides for Python via .NET では、これらは固定されており、ライブラリとそのバージョンが反映されます。

**制限事項**

上記の形式については、API を介してこれらのフィールドを上書きすることはできません。**PPTX** の場合、Application プロパティは「Aspose.Slides for Python via .NET」として書き込まれます。**PDF** の場合、Creator および Producer プロパティは「Aspose.Slides for Python via .NET x.x.x」として書き込まれます。この動作は設計上のものであり、ファイルの読み込みや保存方法、または [DocumentProperties.name_of_application](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/name_of_application/) に割り当てた値に関係なく適用されます。