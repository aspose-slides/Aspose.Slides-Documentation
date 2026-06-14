---
title: Aspose.Slides for .NET 15.5.0 的公開 API 與不相容的變更
linktitle: Aspose.Slides for .NET 15.5.0
type: docs
weight: 160
url: /zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/
keywords:
- 遷移
- 傳統程式碼
- 現代程式碼
- 傳統方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "檢閱 Aspose.Slides for .NET 的公開 API 更新與破壞性變更，順利遷移您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="primary" %}} 

此頁面列出所有已新增或已移除的類別、方法、屬性等，以及隨 Aspose.Slides for .NET 15.5.0 API 引入的其他變更。

{{% /alert %}} 
## **公開 API 變更**
#### **已新增 CommonSlideViewProperties 類別和 ICommonSlideViewProperties 介面**
Aspose.Slides.CommonSlideViewProperties 類別與 Aspose.Slides.ICommonSlideViewProperties 介面代表通用投影片檢視屬性（目前為檢視縮放選項）。
#### **已新增 IAxis.LabelOffset 屬性**
IAxis.LabelOffset 屬性指定標籤與坐標軸之間的距離。適用於類別或日期坐標軸。
#### **已新增 IChartTextBlockFormat.AutofitType 屬性**
變更此屬性僅會對以下圖表部份產生影響：DataLabel 與 DataLabelFormat（在 PowerPoint 2013 中完整支援；在 PowerPoint 2007 中對呈現無影響）。
#### **已新增 IChartTextBlockFormat.WrapText 屬性**
變更此屬性僅會對以下圖表部份產生影響：DataLabel 與 DataLabelFormat（在 PowerPoint 2007/2013 中完整支援）。
#### **已於 IChartTextBlockFormat 新增 Margin 屬性**
變更這些屬性僅會對以下圖表部份產生影響：DataLabel 與 DataLabelFormat（在 PowerPoint 2013 中完整支援；在 PowerPoint 2007 中對呈現無影響）。
#### **已新增 ViewProperties.NotesViewProperties 屬性**
已新增 Aspose.Slides.ViewProperties.NotesViewProperties 屬性。它指定與註解檢視模式相關的通用檢視屬性。
#### **已新增 ViewProperties.SlideViewProperties 屬性**
已新增 Aspose.Slides.ViewProperties.SlideViewProperties 屬性。它指定與投影片檢視模式相關的通用檢視屬性。