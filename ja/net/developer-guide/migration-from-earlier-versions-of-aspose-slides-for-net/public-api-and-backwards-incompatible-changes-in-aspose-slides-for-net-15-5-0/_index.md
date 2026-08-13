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
description: "Aspose.Slides for .NET のパブリック API の更新と破壊的変更を確認し、PowerPoint PPT、PPTX、ODP プレゼンテーション ソリューションを円滑に移行できるようにします。"
---
{{% alert color="info" %}} 

このページは、Aspose.Slides for .NET 15.5.0 APIで導入された、[追加](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) または [削除](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) クラス、メソッド、プロパティなど、その他の変更を一覧します。

{{% /alert %}} 
## **パブリック API の変更**
#### **CommonSlideViewProperties クラスと ICommonSlideViewProperties インターフェイスが追加されました**
Aspose.Slides.CommonSlideViewProperties クラスおよび Aspose.Slides.ICommonSlideViewProperties インターフェイスは、共通のスライド表示プロパティ（現在は表示スケール オプション）を表します。
#### **IAxis.LabelOffset プロパティが追加されました**
IAxis.LabelOffset プロパティは、ラベルと軸との距離を指定します。カテゴリ軸または日付軸に適用されます。
#### **IChartTextBlockFormat.AutofitType プロパティが追加されました**
このプロパティを変更すると、以下のチャート部分にのみ特定の影響を与える可能性があります：DataLabel と DataLabelFormat（PowerPoint 2013 で完全にサポート、PowerPoint 2007 では描画に効果がありません）。
#### **IChartTextBlockFormat.WrapText プロパティが追加されました**
このプロパティを変更すると、以下のチャート部分にのみ特定の影響を与える可能性があります：DataLabel と DataLabelFormat（PowerPoint 2007/2013 で完全にサポート）。
#### **IChartTextBlockFormat にマージン プロパティが追加されました**
これらのプロパティを変更すると、以下のチャート部分にのみ特定の影響を与える可能性があります：DataLabel と DataLabelFormat（PowerPoint 2013 で完全にサポート、PowerPoint 2007 では描画に効果がありません）。
#### **ViewProperties.NotesViewProperties プロパティが追加されました**
Aspose.Slides.ViewProperties.NotesViewProperties プロパティが追加されました。これは、ノート表示モードに関連付けられた共通の表示プロパティを指定します。
#### **ViewProperties.SlideViewProperties プロパティが追加されました**
Aspose.Slides.ViewProperties.SlideViewProperties プロパティが追加されました。これは、スライド表示モードに関連付けられた共通の表示プロパティを指定します。