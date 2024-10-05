---
title: シェイプの効果的プロパティ
type: docs
weight: 50
url: /cpp/shape-effective-properties/
---

このトピックでは、**効果的**および**ローカル**プロパティについて説明します。これらのレベルで値を直接設定する場合、

1. ポーションのスライド上のポーションプロパティ。
1. レイアウトまたはマスタースライドのプロトタイプシェイプテキストスタイル（ポーションのテキストフレームシェイプがある場合）。
1. プレゼンテーションのグローバルテキスト設定。

これらの値は**ローカル**値と呼ばれます。いかなるレベルでも、**ローカル**値を定義したり、省略したりできます。しかし、最終的にアプリケーションがポーションがどのように見えるべきかを知る必要があるとき、**効果的**値を使用します。ローカルフォーマットから**GetEffective()**メソッドを使用して効果的値を取得できます。

以下の例は、効果的値の取得方法を示しています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetEffectiveValues-GetEffectiveValues.cpp" >}}

## **カメラの効果的プロパティを取得する**
Aspose.Slides for C++では、開発者がカメラの効果的プロパティを取得できるようにします。この目的のために、Aspose.Slidesに**CameraEffectiveData**クラスが追加されました。CameraEffectiveDataクラスは、効果的なカメラプロパティを含む不変オブジェクトを表します。**CameraEffectiveData**クラスのインスタンスは、ThreeDFormatクラスの効果的な値のペアである**ThreeDFormatEffectiveData**クラスの一部として使用されます。

以下のコードサンプルは、カメラの効果的プロパティを取得する方法を示しています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetCameraEffectiveData-GetCameraEffectiveData.cpp" >}}

## **ライトリグの効果的プロパティを取得する**
Aspose.Slides for C++では、開発者がライトリグの効果的プロパティを取得できるようにします。この目的のために、Aspose.Slidesに**LightRigEffectiveData**クラスが追加されました。LightRigEffectiveDataクラスは、効果的なライトリグプロパティを含む不変オブジェクトを表します。**LightRigEffectiveData**クラスのインスタンスは、ThreeDFormatクラスの効果的な値のペアである**ThreeDFormatEffectiveData**クラスの一部として使用されます。

以下のコードサンプルは、ライトリグの効果的プロパティを取得する方法を示しています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetLightRigEffectiveData-GetLightRigEffectiveData.cpp" >}}

## **ベベルシェイプの効果的プロパティを取得する**
Aspose.Slides for C++では、開発者がベベルシェイプの効果的プロパティを取得できるようにします。この目的のために、Aspose.Slidesに**ShapeBevelEffectiveData**クラスが追加されました。ShapeBevelEffectiveDataクラスは、効果的なシェイプのフェイスレリーフプロパティを含む不変オブジェクトを表します。**ShapeBevelEffectiveData**クラスのインスタンスは、ThreeDFormatクラスの効果的な値のペアである**ThreeDFormatEffectiveData**クラスの一部として使用されます。

以下のコードサンプルは、ベベルシェイプの効果的プロパティを取得する方法を示しています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetShapeBevelEffectiveData-GetShapeBevelEffectiveData.cpp" >}}

## **テキストフレームの効果的プロパティを取得する**
Aspose.Slides for C++を使用すると、テキストフレームの効果的プロパティを取得できます。この目的のために、効果的なテキストフレーム書式プロパティを含む**TextFrameFormatEffectiveData**クラスがAspose.Slidesに追加されました。

以下のコードサンプルは、効果的なテキストフレーム書式プロパティを取得する方法を示しています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetTextFrameFormatEffectiveData-GetTextFrameFormatEffectiveData.cpp" >}}

## **テキストスタイルの効果的プロパティを取得する**
Aspose.Slides for C++を使用すると、テキストスタイルの効果的プロパティを取得できます。この目的のために、効果的なテキストスタイルプロパティを含む**TextStyleEffectiveData**クラスがAspose.Slidesに追加されました。

以下のコードサンプルは、効果的なテキストスタイルプロパティを取得する方法を示しています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetTextStyleEffectiveData-GetTextStyleEffectiveData.cpp" >}}

## **効果的なフォント高さ値を取得する**
Aspose.Slides for C++を使用すると、フォントの高さの効果的プロパティを取得できます。ここでは、異なるプレゼンテーション構造レベルでローカルフォント高さ値を設定した後の、ポーションの効果的フォント高さ値の変更を示すコードです。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLocalFontHeightValues-SetLocalFontHeightValues.cpp" >}}

## **テーブルの効果的な塗りつぶしフォーマットを取得する**
Aspose.Slides for C++を使用すると、異なるテーブル論理部分のための効果的な塗りつぶしフォーマットを取得できます。この目的のために、効果的な塗りつぶし書式プロパティを含む**IFillFormatEffectiveData**インターフェイスがAspose.Slidesに追加されました。セルの書式設定は常に行の書式設定よりも優先され、行は列よりも優先され、列は全体のテーブルよりも優先されます。

したがって、最終的に**CellFormatEffectiveData**プロパティが常にテーブル描画に使用されます。以下のコードサンプルは、異なるテーブル論理部分のための効果的な塗りつぶしフォーマットを取得する方法を示しています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetEffectiveValuesOfTable-GetEffectiveValuesOfTable.cpp" >}}