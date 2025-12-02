---
title: API 制限
type: docs
weight: 320
url: /ja/net/api-limitations/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET の制限を把握しましょう: エクスポート時に PPT、PPTX、ODP、PDF の Application/Producer メタデータが固定されます—サプライズなしで統合計画を立てるのに役立ちます。"
---

## **アプリケーションとプロデューサー**

Aspose.Slides for .NET を使用してプレゼンテーションを作成またはエクスポートすると、いくつかの技術メタデータがファイルに書き込まれます。2つのフィールドがしばしば質問されます：

**Application** は、**PPTX** プレゼンテーションを作成または最後に保存したプログラムを示します。Aspose.Slides for .NET では、この値は固定されており、アプリ名を設定した場合でもライブラリベンダーが表示されます。たとえば[DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/) を設定しても同様です。

**Producer** は、エクスポート時に最終ファイルを生成したレンダリングエンジンを示します。**PDF** エクスポートでは、メタデータは **Creator** および **Producer** フィールドを使用します。Aspose.Slides for .NET では、これらは固定されており、ライブラリとそのバージョンを示します。

**制限事項**

上記の形式に対して、API を介してこれらのフィールドを上書きすることはできません。**PPTX** の場合、Application プロパティは "Aspose.Slides for .NET" として書き込まれます。**PDF** の場合、Creator および Producer プロパティは "Aspose.Slides for .NET x.x.x" として書き込まれます。この動作は設計上のもので、ファイルの読み込みや保存方法、または[DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/) に設定した値に関係なく適用されます。