---
title: Aspose.Slides for .NET 15.5.0 のパブリック API と後方互換性のない変更
linktitle: Aspose.Slides for .NET 15.5.0
type: docs
weight: 160
url: /ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/
keywords:
- 移行
- レガシーコード
- モダンコード
- レガシーアプローチ
- モダンアプローチ
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET のパブリック API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX および ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 15.5.0 APIで導入された、[added](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) または [removed](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) クラス、メソッド、プロパティなど、その他の変更を一覧表示します。

{{% /alert %}} 
## **パブリック API の変更**
#### **CommonSlideViewProperties クラスと ICommonSlideViewProperties インターフェイスが追加されました**
Aspose.Slides.CommonSlideViewProperties クラスと Aspose.Slides.ICommonSlideViewProperties インターフェイスは、共通のスライド表示プロパティ（現在は表示スケール オプション）を表します。
#### **IAxis.LabelOffset プロパティが追加されました**
IAxis.LabelOffset プロパティは、ラベルと軸との距離を指定します。カテゴリ軸または日付軸に適用されます。
#### **IChartTextBlockFormat.AutofitType プロパティが追加されました**
このプロパティを変更すると、次のチャート部分にのみ特定の影響を与える可能性があります：DataLabel と DataLabelFormat（PowerPoint 2013 で完全にサポートされますが、PowerPoint 2007 では描画に影響はありません）。
#### **IChartTextBlockFormat.WrapText プロパティが追加されました**
このプロパティを変更すると、次のチャート部分にのみ特定の影響を与える可能性があります：DataLabel と DataLabelFormat（PowerPoint 2007/2013 で完全にサポート）。
#### **IChartTextBlockFormat にマージン プロパティが追加されました**
これらのプロパティを変更すると、次のチャート部分にのみ特定の影響を与える可能性があります：DataLabel と DataLabelFormat（PowerPoint 2013 で完全にサポートされますが、PowerPoint 2007 では描画に影響はありません）。
#### **ViewProperties.NotesViewProperties プロパティが追加されました**
Aspose.Slides.ViewProperties.NotesViewProperties プロパティが追加されました。これは、ノート表示モードに関連する共通の表示プロパティを指定します。
#### **ViewProperties.SlideViewProperties プロパティが追加されました**
Aspose.Slides.ViewProperties.SlideViewProperties プロパティが追加されました。これは、スライド表示モードに関連する共通の表示プロパティを指定します。