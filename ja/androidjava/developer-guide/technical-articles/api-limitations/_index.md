---
title: API の制限
type: docs
weight: 320
url: /ja/androidjava/api-limitations/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android の制限を把握しましょう。エクスポート時に PPT、PPTX、ODP、PDF で固定された Application/Producer メタデータが設定されるため、サプライズなく統合を計画できます。"
---

## **アプリケーションとプロデューサー**

Aspose.Slides for Android via Java を使用してプレゼンテーションを作成またはエクスポートすると、いくつかの技術メタデータがファイルに書き込まれます。2 つのフィールドがしばしば質問されます。

**Application** は、**PPTX** プレゼンテーションを作成または最後に保存したプログラムを識別します。Aspose.Slides for Android via Java では、この値は固定されており、アプリ名ではなくライブラリベンダーが表示されます。たとえ [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) を使用しても同様です。

**Producer** は、エクスポート時に最終ファイルを生成したレンダリングエンジンを識別します。**PDF** エクスポートでは、メタデータは **Creator** と **Producer** フィールドを使用します。Aspose.Slides for Android via Java では、これらは固定されており、ライブラリとそのバージョンを示します。

**What’s restricted**

これらのフィールドは、上記の形式に対して API から上書きできません。**PPTX** の場合、Application プロパティは「Aspose.Slides for Android via Java」として書き込まれます。**PDF** の場合、Creator と Producer のプロパティは「Aspose.Slides for Android via Java x.x.x.」として書き込まれます。この動作は設計上のものであり、ファイルの読み込みや保存方法に関係なく、また [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) で設定した値に関係なく適用されます。