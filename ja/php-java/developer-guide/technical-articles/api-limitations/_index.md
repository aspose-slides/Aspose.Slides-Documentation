---
title: API の制限
type: docs
weight: 320
url: /ja/php-java/api-limitations/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP の制限を把握しましょう: エクスポート時に PPT、PPTX、ODP、PDF の Application/Producer メタデータが固定されます—統合を計画する際に予期せぬ問題を防げます。"
---

## **Application と Producer**

Aspose.Slides for PHP via Java でプレゼンテーションを作成またはエクスポートすると、ファイルに技術メタデータが書き込まれます。2 つのフィールドがよく質問されます。

**Application** は **PPTX** プレゼンテーションを作成または最後に保存したプログラムを識別します。Aspose.Slides for PHP via Java では、この値は固定されており、アプリ名ではなくライブラリベンダーが表示されます。たとえ [DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setnameofapplication/) を使用しても同様です。

**Producer** はエクスポート時に最終ファイルを生成したレンダリングエンジンを識別します。**PDF** エクスポートでは、メタデータは **Creator** と **Producer** フィールドを使用します。Aspose.Slides for PHP via Java では、これらはともに固定されており、ライブラリとそのバージョンが反映されます。

**制限事項**

上記の形式に対しては、API を通じてこれらのフィールドを上書きすることはできません。**PPTX** の場合、Application プロパティは「Aspose.Slides for PHP via Java」として書き込まれます。**PDF** の場合、Creator と Producer のプロパティは「Aspose.Slides for PHP via Java x.x.x.」として書き込まれます。この動作は設計上のものであり、ファイルの読み込みや保存方法、または [DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setnameofapplication/) で設定した値に関係なく適用されます。