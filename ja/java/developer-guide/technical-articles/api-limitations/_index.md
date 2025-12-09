---
title: API の制限
type: docs
weight: 320
url: /ja/java/api-limitations/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java の制限を把握しましょう：エクスポート時に PPT、PPTX、ODP、PDF で固定された Application/Producer メタデータが設定されます。これにより、予期せぬ問題なく統合を計画できます。"
---

## **Application and Producer**

Aspose.Slides for Java を使用してプレゼンテーションを作成またはエクスポートすると、ファイルにいくつかの技術的メタデータが書き込まれます。2 つのフィールドはしばしば質問の対象となります。

**Application** は、**PPTX** プレゼンテーションを作成または最後に保存したプログラムを識別します。Aspose.Slides for Java では、この値は固定されており、アプリ名ではなくライブラリのベンダーが表示されます。たとえ[DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-)を使用しても同様です。

**Producer** は、エクスポート時に最終ファイルを生成したレンダリングエンジンを識別します。**PDF** エクスポートでは、メタデータは **Creator** と **Producer** フィールドを使用します。Aspose.Slides for Java では、これらはどちらも固定されており、ライブラリとそのバージョンを示します。

**What’s restricted**

上記の形式に対しては、API を通じてこれらのフィールドを上書きすることはできません。**PPTX** の場合、Application プロパティは「Aspose.Slides for Java」として書き込まれます。**PDF** の場合、Creator および Producer プロパティは「Aspose.Slides for Java x.x.x.」として書き込まれます。この動作は設計上のもので、ファイルの読み込みや保存方法にかかわらず、また[DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-)で設定した値に関係なく適用されます。