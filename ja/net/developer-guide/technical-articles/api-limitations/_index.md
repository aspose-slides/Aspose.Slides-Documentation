---
title: 出力メタデータの制限
type: docs
weight: 320
url: /ja/net/api-limitations/
keywords:
- API の制限
- エクスポート形式
- アプリケーション
- プロデューサー
- ドキュメント プロパティ
- メタデータ
- ジェネレーター
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET は、保存された PPTX、PDF、ODP ファイルに対して、設定したアプリケーション名に関係なく、固定された Application、Creator、Producer メタデータを書き込みます。"
---
## **概要**

Aspose.Slidesでプレゼンテーションを作成またはエクスポートすると、特定の技術メタデータが出力ファイルに書き込まれます。本記事では、PPTX、PDF、ODPファイルの `Application`、`Creator`、`Producer`、および generator メタデータ フィールドに関する制限について説明します。

## **Application と Producer**

Aspose.Slides for .NETを使用してプレゼンテーションを作成またはエクスポートすると、いくつかの技術メタデータがファイルに書き込まれます。2 つのフィールドはしばしば質問の対象となります：

**Application** は **PPTX** プレゼンテーションを作成または最後に保存したプログラムを識別します。Aspose.Slides for .NETでは、この値は固定されており、アプリ名ではなくライブラリ名が表示されます。たとえ [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/) を設定していても同様です。

**Producer** はエクスポート時に最終ファイルを生成したレンダリングエンジンを識別します。**PDF** エクスポートでは、メタデータは **Creator** と **Producer** フィールドを使用します。Aspose.Slides for .NET では、これらは固定されており、ライブラリとそのバージョンを示します。

**制限内容**

上記の形式については、API からこれらのフィールドを上書きすることはできません。**PPTX** の場合、Application プロパティは「Aspose.Slides for .NET」として書き込まれます。**PDF** の場合、Creator および Producer プロパティは「Aspose.Slides for .NET」にライブラリ バージョンが続く形で書き込まれます。**ODP** の場合、generator フィールドも「Aspose.Slides for .NET」にライブラリ バージョンが続く形で書き込まれます。この動作は設計上のものであり、ファイルの読み込みや保存方法、または [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/) に割り当てた値に関係なく適用されます。

この制限は **PPT** ファイルには適用されません。PPT ファイルでは、[DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/) に設定したアプリケーション名が保存されます。