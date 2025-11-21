---
title: Aspose.Slides for .NET 15.5.0 のパブリック API と下位互換性のない変更
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
description: "Aspose.Slides for .NET のパブリック API 更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---

{{% alert color="primary" %}} 

このページは、[追加](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) または [削除](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) されたクラス、メソッド、プロパティ等、および Aspose.Slides for .NET 15.5.0 APIで導入されたその他の変更をすべて一覧表示します。

{{% /alert %}} 
## **Public API の変更**
#### **CommonSlideViewProperties クラスと ICommonSlideViewProperties インターフェイスが追加されました**
Aspose.Slides.CommonSlideViewProperties クラスおよび Aspose.Slides.ICommonSlideViewProperties インターフェイスは、共通スライドビュー プロパティ（現在はビュー スケール オプション）を表します。
#### **IAxis.LabelOffset プロパティが追加されました**
IAxis.LabelOffset プロパティは、ラベルと軸との距離を指定します。カテゴリ軸または日付軸に適用されます。
#### **IChartTextBlockFormat.AutofitType プロパティが追加されました**
このプロパティを変更すると、次のチャート要素にのみ影響を与える場合があります：DataLabel と DataLabelFormat（PowerPoint 2013 では完全にサポートされますが、PowerPoint 2007 では描画に効果がありません）。
#### **IChartTextBlockFormat.WrapText プロパティが追加されました**
このプロパティを変更すると、次のチャート要素にのみ影響を与える場合があります：DataLabel と DataLabelFormat（PowerPoint 2007/2013 で完全にサポート）。
#### **IChartTextBlockFormat にマージン プロパティが追加されました**
このプロパティを変更すると、次のチャート要素にのみ影響を与える場合があります：DataLabel と DataLabelFormat（PowerPoint 2013 では完全にサポートされますが、PowerPoint 2007 では描画に効果がありません）。
#### **ViewProperties.NotesViewProperties プロパティが追加されました**
Aspose.Slides.ViewProperties.NotesViewProperties プロパティが追加されました。その目的は、ノートビュー モードに関連する共通ビュー プロパティを指定することです。
#### **ViewProperties.SlideViewProperties プロパティが追加されました**
Aspose.Slides.ViewProperties.SlideViewProperties プロパティが追加されました。その目的は、スライドビュー モードに関連する共通ビュー プロパティを指定することです。