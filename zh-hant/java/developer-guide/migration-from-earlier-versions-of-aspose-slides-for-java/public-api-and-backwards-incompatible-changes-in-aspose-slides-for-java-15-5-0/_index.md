---
title: Aspose.Slides for Java 15.5.0 公共 API 與向後不相容變更
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
description: "檢視 Aspose.Slides for Java 的公共 API 更新與破壞性變更，以順利遷移您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="info" %}} 

此頁面列出所有 [已新增](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) 類別、方法、屬性等，以及 Aspose.Slides for Java 15.5.0 API 所帶來的任何新限制與其他 [變更](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/)。

{{% /alert %}} 
## **Public API Changes**
### **CommonSlideViewProperties class and ICommonSlideViewProperties interface have been added**
com.aspose.slides.CommonSlideViewProperties 類別（以及其介面 com.aspose.slides.ICommonSlideViewProperties）表示通用投影片檢視屬性（目前為檢視比例選項）。 
### **IAxis.getLabelOffset(), setLabelOffset(int) methods have been added**
IAxis.getLabelOffset()、setLabelOffset(int) 方法可取得及設定標籤與座標軸之間的距離。適用於類別或日期座標軸。 
### **IChartTextBlockFormat.getAutofitType(), setAutofitType(byte) methods have been added**
已在 com.aspose.slides.IChartTextBlockFormat 介面中加入 getAutofitType()、setAutofitType(/**TextAutofitType**/byte) 方法。變更此值僅會對以下圖表部件產生影響：DataLabel 與 DataLabelFormat（在 PowerPoint 2013 中完全支援；PowerPoint 2007 中不會影響呈現）。 
### **Methods IChartTextBlockFormat.getWrapText(), setWrapText(byte) have been added**
已在 com.aspose.slides.IChartTextBlockFormat 介面中加入 getWrapText()、setWrapText(/**NullableBool**/byte) 方法。變更此值僅會對以下圖表部件產生影響：DataLabel 與 DataLabelFormat（在 PowerPoint 2007/2013 中完全支援）。 
### **The methods to manage margins have been added to IChartTextBlockFormat**
已在 com.aspose.slides.IChartTextBlockFormat 介面中加入 getMarginLeft()、setMarginLeft(double)、getMarginRight()、setMarginRight(double)、getMarginTop()、setMarginTop(double)、getMarginBottom()、setMarginBottom(double) 方法。變更這些值僅會對以下圖表部件產生影響：DataLabel 與 DataLabelFormat（在 PowerPoint 2013 中完全支援；PowerPoint 2007 中不會影響呈現）。 
### **ViewProperties.getNotesViewProperties() method have been added**
已新增 com.aspose.slides.ViewProperties.getNotesViewProperties() 屬性。它取得與註解檢視模式相關的通用檢視屬性。 
### **ViewProperties.getSlideViewProperties() method has been added**
已新增 com.aspose.slides.ViewProperties.getSlideViewProperties() 方法。它取得與投影片檢視模式相關的通用檢視屬性。