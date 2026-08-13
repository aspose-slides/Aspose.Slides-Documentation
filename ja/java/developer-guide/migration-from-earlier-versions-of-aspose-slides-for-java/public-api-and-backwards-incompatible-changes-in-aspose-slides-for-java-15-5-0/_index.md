---
title: Aspose.Slides for Java 15.5.0 のパブリック API と下位互換性のない変更
linktitle: Aspose.Slides for Java 15.5.0
type: docs
weight: 130
url: /ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
keywords:
- 移行
- レガシーコード
- モダンコード
- レガシーアプローチ
- モダンアプローチ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java のパブリック API 更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---
{{% alert color="info" %}} 
このページでは、Aspose.Slides for Java 15.5.0 APIで導入された、[追加](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/)されたクラス、メソッド、プロパティなど、すべての新しい制限やその他の[変更](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/)を一覧表示します。
{{% /alert %}} 
## **パブリックAPIの変更**
### **CommonSlideViewProperties クラスおよび ICommonSlideViewProperties インターフェイスが追加されました**
com.aspose.slides.CommonSlideViewProperties クラス（およびそのインターフェイス com.aspose.slides.ICommonSlideViewProperties）は、共通スライドビュー属性（現在はビューのスケールオプション）を表します。
### **IAxis.getLabelOffset()、setLabelOffset(int) メソッドが追加されました**
IAxis.getLabelOffset()、setLabelOffset(int) メソッドは、ラベルと軸との距離を取得および指定できるようにします。カテゴリ軸または日付軸に適用されます。
### **IChartTextBlockFormat.getAutofitType()、setAutofitType(byte) メソッドが追加されました**
メソッド getAutofitType()、setAutofitType(/**TextAutofitType**/byte) が com.aspose.slides.IChartTextBlockFormat インターフェイスに追加されました。この値を変更すると、以下のチャート部品にのみ影響があります: DataLabel と DataLabelFormat（PowerPoint 2013 では完全にサポート、PowerPoint 2007 では描画に影響なし）。
### **IChartTextBlockFormat.getWrapText()、setWrapText(byte) メソッドが追加されました**
メソッド getWrapText()、setWrapText(/**NullableBool**/byte) が com.aspose.slides.IChartTextBlockFormat インターフェイスに追加されました。この値を変更すると、以下のチャート部品にのみ影響があります: DataLabel と DataLabelFormat（PowerPoint 2007/2013 で完全にサポート）。
### **IChartTextBlockFormat にマージン管理用メソッドが追加されました**
メソッド getMarginLeft()、setMarginLeft(double)、getMarginRight()、setMarginRight(double)、getMarginTop()、setMarginTop(double)、getMarginBottom()、setMarginBottom(double) が com.aspose.slides.IChartTextBlockFormat インターフェイスに追加されました。これらの値を変更すると、以下のチャート部品にのみ影響があります: DataLabel と DataLabelFormat（PowerPoint 2013 では完全にサポート、PowerPoint 2007 では描画に影響なし）。
### **ViewProperties.getNotesViewProperties() メソッドが追加されました**
com.aspose.slides.ViewProperties.getNotesViewProperties() プロパティが追加されました。ノートビュー モードに関連付けられた共通ビュー属性を取得します。
### **ViewProperties.getSlideViewProperties() メソッドが追加されました**
com.aspose.slides.ViewProperties.getSlideViewProperties() メソッドが追加されました。スライドビュー モードに関連付けられた共通ビュー属性を取得します。