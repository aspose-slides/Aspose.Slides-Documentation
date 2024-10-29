---
title: Aspose.Slides for PHP via Java 15.5.0における公開APIと後方互換性のない変更
type: docs
weight: 130
url: /ja/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for PHP via Java 15.5.0 APIで追加されたすべての[class](/slides/ja/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/)クラス、メソッド、プロパティなど、新しい制限や他の[変更](/slides/ja/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/)について一覧表示します。

{{% /alert %}} 
## **公開APIの変更**
### **CommonSlideViewPropertiesクラスとICommonSlideViewPropertiesインターフェースが追加されました**
com.aspose.slides.CommonSlideViewPropertiesクラス（およびそのインターフェースcom.aspose.slides.ICommonSlideViewProperties）は、一般的なスライド表示プロパティ（現在の表示スケールオプション）を表します。
### **IAxis.getLabelOffset()、setLabelOffset(int)メソッドが追加されました**
IAxis.getLabelOffset()、setLabelOffset(int)メソッドは、軸からラベルまでの距離を取得および指定することができます。カテゴリ軸または日付軸に適用されます。
### **IChartTextBlockFormat.getAutofitType()、setAutofitType(byte)メソッドが追加されました**
メソッドgetAutofitType()、setAutofitType(/**TextAutofitType**/byte)がcom.aspose.slides.IChartTextBlockFormatインターフェースに追加されました。
この値の変更は、次のチャート部分に対してのみ特定の影響を与える可能性があります：DataLabelとDataLabelFormat（PowerPoint 2013で完全サポート; PowerPoint 2007ではレンダリングには影響なし）。
### **IChartTextBlockFormat.getWrapText()、setWrapText(byte)メソッドが追加されました**
メソッドgetWrapText()、setWrapText(/**NullableBool**/byte)がcom.aspose.slides.IChartTextBlockFormatインターフェースに追加されました。
この値の変更は、次のチャート部分に対してのみ特定の影響を与える可能性があります：DataLabelとDataLabelFormat（PowerPoint 2007/2013で完全サポート）。
### **IChartTextBlockFormatにマージン管理メソッドが追加されました**
getMarginLeft()、setMarginLeft(double)、getMarginRight()、setMarginRight(double)、getMarginTop()、setMarginTop(double)、getMarginBottom()およびsetMarginBottom(double)メソッドがcom.aspose.slides.IChartTextBlockFormatインターフェースに追加されました。
これらの値の変更は、次のチャート部分に対してのみ特定の影響を与える可能性があります：DataLabelとDataLabelFormat（PowerPoint 2013で完全サポート; PowerPoint 2007ではレンダリングには影響なし）。
### **ViewProperties.getNotesViewProperties()メソッドが追加されました**
com.aspose.slides.ViewProperties.getNotesViewProperties()プロパティが追加されました。これは、ノート表示モードに関連する一般的な表示プロパティを取得します。
### **ViewProperties.getSlideViewProperties()メソッドが追加されました**
com.aspose.slides.ViewProperties.getSlideViewProperties()メソッドが追加されました。これは、スライド表示モードに関連する一般的な表示プロパティを取得します。