---
title: Aspose.Slides for Java 15.5.0 の公開 API と後方互換性のない変更
type: docs
weight: 130
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
---

{{% alert color="primary" %}} 

このページには、Aspose.Slides for Java 15.5.0 API に導入されたすべての [追加された](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/)クラス、メソッド、プロパティ、その他の新しい制限や [変更](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) がリストされています。

{{% /alert %}} 
## **公開 API の変更**
### **CommonSlideViewProperties クラスと ICommonSlideViewProperties インターフェイスが追加されました**
com.aspose.slides.CommonSlideViewProperties クラス（およびそのインターフェイス com.aspose.slides.ICommonSlideViewProperties）は、共通のスライド表示プロパティ（現在は表示倍率オプション）を表します。
### **IAxis.getLabelOffset()、setLabelOffset(int) メソッドが追加されました**
IAxis.getLabelOffset()、setLabelOffset(int) メソッドは、軸からのラベルの距離を取得および指定することを可能にします。カテゴリまたは日付軸に適用されます。
### **IChartTextBlockFormat.getAutofitType()、setAutofitType(byte) メソッドが追加されました**
getAutofitType()、setAutofitType(/**TextAutofitType**/byte) メソッドが com.aspose.slides.IChartTextBlockFormat インターフェイスに追加されました。
この値の変更は、特定のチャート部分（DataLabel および DataLabelFormat）にのみ影響を及ぼす可能性があります（PowerPoint 2013 で完全にサポートされ、PowerPoint 2007 ではレンダリングに影響を与えません）。
### **IChartTextBlockFormat.getWrapText()、setWrapText(byte) メソッドが追加されました**
getWrapText()、setWrapText(/**NullableBool**/byte) メソッドが com.aspose.slides.IChartTextBlockFormat インターフェイスに追加されました。
この値の変更は、特定のチャート部分（DataLabel および DataLabelFormat）にのみ影響を及ぼす可能性があります（PowerPoint 2007/2013 で完全にサポートされます）。
### **IChartTextBlockFormat にマージンを管理するメソッドが追加されました**
getMarginLeft()、setMarginLeft(double)、getMarginRight()、setMarginRight(double)、getMarginTop()、setMarginTop(double)、getMarginBottom()、setMarginBottom(double) メソッドが com.aspose.slides.IChartTextBlockFormat インターフェイスに追加されました。
これらの値の変更は、特定のチャート部分（DataLabel および DataLabelFormat）にのみ影響を及ぼす可能性があります（PowerPoint 2013 で完全にサポートされ、PowerPoint 2007 ではレンダリングに影響を与えません）。
### **ViewProperties.getNotesViewProperties() メソッドが追加されました**
com.aspose.slides.ViewProperties.getNotesViewProperties() プロパティが追加されました。ノート表示モードに関連付けられた共通の表示プロパティを取得します。
### **ViewProperties.getSlideViewProperties() メソッドが追加されました**
com.aspose.slides.ViewProperties.getSlideViewProperties() メソッドが追加されました。スライド表示モードに関連付けられた共通の表示プロパティを取得します。