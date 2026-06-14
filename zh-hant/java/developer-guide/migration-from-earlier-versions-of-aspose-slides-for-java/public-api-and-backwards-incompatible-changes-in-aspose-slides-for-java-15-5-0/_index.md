---
title: Aspose.Slides for Java 15.5.0 的公共 API 以及向後相容性破壞變更
linktitle: Aspose.Slides for Java 15.5.0
type: docs
weight: 130
url: /zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
keywords:
- 遷移
- 舊版程式碼
- 現代程式碼
- 舊版方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "檢視 Aspose.Slides for Java 中的公共 API 更新與破壞性變更，以順利遷移您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="primary" %}} 

此頁面列出所有 [added](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) 類別、方法、屬性等，任何新的限制與其他 [changes](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) ，均是隨 Aspose.Slides for Java 15.5.0 API 引入的。

{{% /alert %}} 
## **公共 API 變更**
### **已新增 CommonSlideViewProperties 類別 和 ICommonSlideViewProperties 介面**
com.aspose.slides.CommonSlideViewProperties 類別（以及其介面 com.aspose.slides.ICommonSlideViewProperties）表示一般投影片檢視屬性（目前為檢視比例選項）。
### **已新增 IAxis.getLabelOffset()、setLabelOffset(int) 方法**
IAxis.getLabelOffset()、setLabelOffset(int) 方法允許取得與設定標籤與座標軸之間的距離。適用於類別或日期座標軸。
### **已新增 IChartTextBlockFormat.getAutofitType()、setAutofitType(byte) 方法**
已在 com.aspose.slides.IChartTextBlockFormat 介面中新增 getAutofitType()、setAutofitType(/**TextAutofitType**/byte) 方法。變更此值僅會對以下圖表部分產生影響：DataLabel 與 DataLabelFormat（在 PowerPoint 2013 中完全支援；在 PowerPoint 2007 中不會影響呈現）。
### **已新增 IChartTextBlockFormat.getWrapText()、setWrapText(byte) 方法**
已在介面 com.aspose.slides.IChartTextBlockFormat 中新增 getWrapText()、setWrapText(/**NullableBool**/byte) 方法。變更此值僅會對以下圖表部分產生影響：DataLabel 與 DataLabelFormat（在 PowerPoint 2007/2013 中完全支援）。
### **已在 IChartTextBlockFormat 中新增管理邊距的方法**
已在介面 com.aspose.slides.IChartTextBlockFormat 中新增 getMarginLeft()、setMarginLeft(double)、getMarginRight()、setMarginRight(double)、getMarginTop()、setMarginTop(double)、getMarginBottom() 以及 setMarginBottom(double) 方法。變更這些值僅會對以下圖表部分產生影響：DataLabel 與 DataLabelFormat（在 PowerPoint 2013 中完全支援；在 PowerPoint 2007 中不會影響呈現）。
### **已新增 ViewProperties.getNotesViewProperties() 方法**
已新增 com.aspose.slides.ViewProperties.getNotesViewProperties() 屬性。它取得與備註檢視模式相關的通用檢視屬性。
### **已新增 ViewProperties.getSlideViewProperties() 方法**
已新增 com.aspose.slides.ViewProperties.getSlideViewProperties() 方法。它取得與投影片檢視模式相關的通用檢視屬性。