---
title: API の制限
type: docs
weight: 320
url: /ja/python-java/api-limitations/
keywords:
- API の制限
- エクスポート形式
- アプリケーション
- プロデューサー
- ドキュメントプロパティ
- メタデータ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java の制限事項を学びます: PPTX および PDF ファイルの固定された Application、Creator、Producer メタデータ。"
---
## **概要**

Aspose.Slidesでプレゼンテーションを作成またはエクスポートすると、特定の技術メタデータが出力ファイルに書き込まれます。このドキュメントでは、PPTX および PDF ファイルの `Application`、`Creator`、`Producer` メタデータ フィールドに関する制限事項について説明します。

## **アプリケーションとプロデューサー**

Aspose.Slides for Python via Javaでプレゼンテーションを作成またはエクスポートすると、いくつかの技術メタデータがファイルに書き込まれます。2 つのフィールドがしばしば質問の対象となります：

**Application** は **PPTX** プレゼンテーションを作成または最後に保存したプログラムを示します。Aspose.Slides for Python via Java では、この値は固定されており、アプリ名ではなくライブラリベンダーが表示されます。たとえ [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/#setnameofapplication) を使用しても同様です。

**Producer** はエクスポート時に最終ファイルを生成したレンダリングエンジンを示します。**PDF** エクスポートでは、メタデータは **Creator** と **Producer** フィールドを使用します。Aspose.Slides for Python via Java では、これら両方が固定されており、ライブラリとそのバージョンを示します。

## **制限事項**

上記の形式に対して、API を通じてこれらのフィールドを上書きすることはできません。**PPTX** の場合、Application プロパティは「Aspose.Slides for Java」として書き込まれます。**PDF** の場合、Creator および Producer プロパティは「Aspose.Slides for Java x.x.x.」として書き込まれます。この動作は設計上のものであり、ファイルの読み込みや保存方法に関係なく、また [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/#setnameofapplication) を使用して割り当てた値に関係なく適用されます。

## **よくある質問**

**PPTX ファイルの Application の値を自分のアプリ名に置き換えることはできますか？**

いいえ。この値は固定されており、たとえ [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/#setnameofapplication) を使用しても変更できません。

**PDF エクスポート時に Creator および Producer フィールドを上書きできますか？**

いいえ。両フィールドとも固定されており、ライブラリとそのバージョンを示します。プレゼンテーションの読み込みや保存方法に関係なく同様です。