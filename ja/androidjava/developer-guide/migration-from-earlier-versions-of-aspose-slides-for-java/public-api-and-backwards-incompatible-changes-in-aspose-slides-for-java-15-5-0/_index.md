---
title: Aspose.Slides for Java 15.5.0における公開APIおよび後方互換性のない変更
type: docs
weight: 130
url: /ja/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for Java 15.5.0 APIで追加されたすべての[class](/slides/ja/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/)クラス、メソッド、プロパティなど、新しい制限やその他の[changes](/slides/ja/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/)をリストします。

{{% /alert %}} 
## **公開APIの変更**
### **CommonSlideViewPropertiesクラスとICommonSlideViewPropertiesインターフェイスが追加されました**
com.aspose.slides.CommonSlideViewPropertiesクラス（およびそのインターフェイスcom.aspose.slides.ICommonSlideViewProperties）は、一般的なスライドビューのプロパティ（現在のビュー倍率オプション）を表します。
### **IAxis.getLabelOffset()およびsetLabelOffset(int)メソッドが追加されました**
IAxis.getLabelOffset()、setLabelOffset(int)メソッドは、軸からラベルまでの距離を取得および指定することを可能にします。カテゴリまたは日付軸に適用されます。
### **IChartTextBlockFormat.getAutofitType()およびsetAutofitType(byte)メソッドが追加されました**
メソッドgetAutofitType()、setAutofitType(/**TextAutofitType**/byte)がcom.aspose.slides.IChartTextBlockFormatインターフェイスに追加されました。
この値の変更は、次のチャート部分にのみ影響を与える可能性があります：DataLabelおよびDataLabelFormat（PowerPoint 2013で完全サポート; PowerPoint 2007ではレンダリングに影響はありません）。
### **IChartTextBlockFormatにテキストの折り返しを管理するメソッドが追加されました**
メソッドgetWrapText()、setWrapText(/**NullableBool**/byte)がcom.aspose.slides.IChartTextBlockFormatインターフェイスに追加されました。
この値の変更は、次のチャート部分にのみ影響を与える可能性があります：DataLabelおよびDataLabelFormat（PowerPoint 2007/2013で完全サポート）。
### **IChartTextBlockFormatにマージンを管理するメソッドが追加されました**
getMarginLeft()、setMarginLeft(double)、getMarginRight()、setMarginRight(double)、getMarginTop()、setMarginTop(double)、getMarginBottom()およびsetMarginBottom(double)メソッドがcom.aspose.slides.IChartTextBlockFormatインターフェイスに追加されました。
この値の変更は、次のチャート部分にのみ影響を与える可能性があります：DataLabelおよびDataLabelFormat（PowerPoint 2013で完全サポート; PowerPoint 2007ではレンダリングに影響はありません）。
### **ViewProperties.getNotesViewProperties()メソッドが追加されました**
com.aspose.slides.ViewProperties.getNotesViewProperties()プロパティが追加されました。これは、ノートビュー モードに関連する一般的なビュー プロパティを取得します。
### **ViewProperties.getSlideViewProperties()メソッドが追加されました**
com.aspose.slides.ViewProperties.getSlideViewProperties()メソッドが追加されました。これは、スライド ビュー モードに関連する一般的なビュー プロパティを取得します。