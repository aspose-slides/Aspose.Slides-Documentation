---
title: Aspose.Slides for .NET 15.5.0 の公開 API と後方互換性のない変更
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
description: "Aspose.Slides for .NET の公開 API の更新と破壊的変更を確認し、PowerPoint PPT、PPTX、ODP のプレゼンテーション ソリューションを円滑に移行できるようにします。"
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 15.5.0 APIで導入された、[追加された](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) または [削除された](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) クラス、メソッド、プロパティ等、およびその他の変更を一覧表示します。

{{% /alert %}} 
## **Public API Changes**
#### **CommonSlideViewProperties class and ICommonSlideViewProperties interface have been added**
Aspose.Slides.CommonSlideViewProperties クラスと Aspose.Slides.ICommonSlideViewProperties インターフェイスは、共通のスライド表示プロパティ（現在は表示スケールオプション）を表します。
#### **IAxis.LabelOffset property has been added**
IAxis.LabelOffset プロパティは、ラベルと軸との距離を指定します。カテゴリ軸または日付軸に適用されます。
#### **IChartTextBlockFormat.AutofitType property has been added**
このプロパティを変更すると、次のチャート部分にのみ影響があります: DataLabel と DataLabelFormat（PowerPoint 2013 では完全にサポートされますが、PowerPoint 2007 では描画に効果がありません）。
#### **IChartTextBlockFormat.WrapText property has been added**
このプロパティを変更すると、次のチャート部分にのみ影響があります: DataLabel と DataLabelFormat（PowerPoint 2007/2013 で完全にサポート）。
#### **Margin properties have been added to IChartTextBlockFormat**
このプロパティを変更すると、次のチャート部分にのみ影響があります: DataLabel と DataLabelFormat（PowerPoint 2013 では完全にサポートされますが、PowerPoint 2007 では描画に効果がありません）。
#### **ViewProperties.NotesViewProperties property has been added**
Aspose.Slides.ViewProperties.NotesViewProperties プロパティが追加されました。これは、ノート表示モードに関連する共通の表示プロパティを指定します。
#### **ViewProperties.SlideViewProperties property has been added**
Aspose.Slides.ViewProperties.SlideViewProperties プロパティが追加されました。これは、スライド表示モードに関連する共通の表示プロパティを指定します。