---
title: 出力メタデータの制限
type: docs
weight: 320
url: /ja/java/api-limitations/
keywords:
  - API の制限
  - エクスポート形式
  - アプリケーション
  - プロデューサー
  - 文書プロパティ
  - メタデータ
  - ジェネレーター
  - PowerPoint
  - OpenDocument
  - プレゼンテーション
  - Java
  - Aspose.Slides
description: "Aspose.Slides for Java は、設定したアプリケーション名にかかわらず、保存された PPTX、PDF、ODP ファイルに固定された application、creator、producer メタデータを書き込みます。"
---
## **概要**

Aspose.Slides でプレゼンテーションを作成またはエクスポートすると、特定の技術メタデータが出力ファイルに書き込まれます。本記事では、PPTX、PDF、ODP ファイルの `Application`、`Creator`、`Producer`、および generator メタデータ フィールドに関連する制限について説明します。

## **Application と Producer**

Aspose.Slides for Java でプレゼンテーションを作成またはエクスポートすると、いくつかの技術メタデータがファイルに書き込まれます。2 つのフィールドはしばしば質問を呼びます。

**Application** は、**PPTX** プレゼンテーションを作成または最後に保存したプログラムを識別します。Aspose.Slides for Java では、この値は固定されており、[DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/ja/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) を使用した場合でもアプリ名ではなくライブラリ名が表示されます。

**Producer** は、エクスポート時に最終ファイルを生成したレンダリング エンジンを識別します。**PDF** エクスポートでは、メタデータは **Creator** と **Producer** フィールドを使用します。Aspose.Slides for Java では、これらの両方が固定されており、ライブラリとそのバージョンを示します。

## **制限事項**

上記の形式では、API を介してこれらのフィールドを上書きすることはできません。**PPTX** の場合、Application プロパティは「Aspose.Slides for Java」として書き込まれます。**PDF** の場合、Creator および Producer プロパティは「Aspose.Slides for Java」にライブラリ バージョンが続く形で書き込まれます。**ODP** の場合、generator フィールドは「Aspose.Slides for Java」にライブラリ バージョンが続く形で書き込まれます。この動作は設計上のものであり、ファイルの読み込みや保存方法にかかわらず、[DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/ja/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) で設定した値にかかわらず適用されます。

この制限は **PPT** ファイルには適用されません。PPT ファイルでは、[DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/ja/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) で設定したアプリケーション名が保存されます。