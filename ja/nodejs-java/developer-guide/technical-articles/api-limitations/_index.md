---
title: API 制限
type: docs
weight: 320
url: /ja/nodejs-java/api-limitations/
keywords:
- API 制限
- エクスポート形式
- アプリケーション
- プロデューサー
- ドキュメント プロパティ
- メタデータ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js の制限を把握しましょう: エクスポート時に PPT、PPTX、ODP、PDF の Application/Producer メタデータが固定されます—サプライズのない統合計画に役立ちます。"
---

## **アプリケーションとプロデューサー**

Aspose.Slides for Node.js via Javaでプレゼンテーションを作成またはエクスポートすると、ファイルにいくつかの技術的メタデータが書き込まれます。以下の2つのフィールドはしばしば質問の対象となります。

**Application** は、**PPTX** プレゼンテーションを作成した、または最後に保存したプログラムを識別します。Aspose.Slides for Node.js via Javaでは、この値は固定されており、ライブラリベンダーが表示されます。たとえ [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties/setnameofapplication/) を使用しても、アプリ名にはなりません。

**Producer** は、エクスポート時に最終ファイルを生成したレンダリングエンジンを識別します。**PDF** エクスポートでは、メタデータは **Creator** と **Producer** フィールドを使用します。Aspose.Slides for Node.js via Javaでは、これらも固定されており、ライブラリとそのバージョンが反映されます。

**制限事項**

上記の形式について、APIからこれらのフィールドを上書きすることはできません。**PPTX** の場合、Application プロパティは「Aspose.Slides for Node.js via Java」として書き込まれます。**PDF** の場合、Creator および Producer プロパティは「Aspose.Slides for Node.js via Java x.x.x.」として書き込まれます。この動作は設計上のものであり、ファイルの読み込みや保存方法、あるいは [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties/setnameofapplication/) で設定した値に関係なく適用されます。