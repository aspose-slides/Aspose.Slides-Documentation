---
title: C++ のプレゼンテーションからシェイプの有効プロパティを取得
linktitle: 有効プロパティ
type: docs
weight: 50
url: /ja/cpp/shape-effective-properties/
keywords:
- シェイプ プロパティ
- カメラ プロパティ
- ライト リグ
- ベベル シェイプ
- テキスト フレーム
- テキスト スタイル
- フォント 高さ
- 塗りつぶし 形式
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ が、正確な PowerPoint 表示のためにシェイプの有効プロパティをどのように計算し適用するかを学びましょう。"
---

このトピックでは、**effective** と **local** のプロパティについて説明します。これらのレベルで値を直接設定した場合

1. スライド上の部分のプロパティ。
1. レイアウトまたはマスタースライド上のプロトタイプシェイプ テキストスタイル（該当する場合は部分のテキストフレーム シェイプにあります）。
1. プレゼンテーション全体のテキスト設定。

これらの値は **local** 値と呼ばれます。任意のレベルで **local** 値は定義されても、定義されなくてもかまいません。しかし、最終的にアプリケーションが部分の表示方法を知る必要があるときは **effective** 値が使用されます。**effective** 値はローカル形式から **GetEffective()** メソッドを使用して取得できます。

以下の例は、**effective** 値の取得方法を示しています。



{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetEffectiveValues-GetEffectiveValues.cpp" >}}


## **Get Effective Properties of a Camera**
Aspose.Slides for C++ では、カメラの **effective** プロパティを取得できます。この目的のために **CameraEffectiveData** クラスが Aspose.Slides に追加されました。CameraEffectiveData クラスは、効果的なカメラ プロパティを保持する不変オブジェクトを表します。**CameraEffectiveData** クラスのインスタンスは、ThreeDFormat クラスの **effective** 値ペアである **ThreeDFormatEffectiveData** クラスの一部として使用されます。

次のコードサンプルは、カメラの **effective** プロパティを取得する方法を示しています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetCameraEffectiveData-GetCameraEffectiveData.cpp" >}}

## **Get Effective Properties of a Light Rig**
Aspose.Slides for C++ では、Light Rig の **effective** プロパティを取得できます。この目的のために **LightRigEffectiveData** クラスが Aspose.Slides に追加されました。LightRigEffectiveData クラスは、効果的なライト リグ プロパティを保持する不変オブジェクトを表します。**LightRigEffectiveData** クラスのインスタンスは、ThreeDFormat クラスの **effective** 値ペアである **ThreeDFormatEffectiveData** クラスの一部として使用されます。

次のコードサンプルは、Light Rig の **effective** プロパティを取得する方法を示しています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetLightRigEffectiveData-GetLightRigEffectiveData.cpp" >}}

## **Get Effective Properties of a Bevel Shape**
Aspose.Slides for C++ では、ベベル シェイプの **effective** プロパティを取得できます。この目的のために **ShapeBevelEffectiveData** クラスが Aspose.Slides に追加されました。ShapeBevelEffectiveData クラスは、シェイプのフェイス リリーフ プロパティを保持する不変オブジェクトを表します。**ShapeBevelEffectiveData** クラスのインスタンスは、ThreeDFormat クラスの **effective** 値ペアである **ThreeDFormatEffectiveData** クラスの一部として使用されます。

次のコードサンプルは、ベベル シェイプの **effective** プロパティを取得する方法を示しています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetShapeBevelEffectiveData-GetShapeBevelEffectiveData.cpp" >}}

## **Get Effective Properties of a Text Frame**
Aspose.Slides for C++ を使用すると、テキスト フレームの **effective** プロパティを取得できます。この目的のために **TextFrameFormatEffectiveData** クラスが Aspose.Slides に追加され、効果的なテキスト フレームの書式設定プロパティを保持します。

次のコードサンプルは、テキスト フレームの書式設定 **effective** プロパティを取得する方法を示しています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetTextFrameFormatEffectiveData-GetTextFrameFormatEffectiveData.cpp" >}}

## **Get Effective Properties of a Text Style**
Aspose.Slides for C++ を使用すると、テキスト スタイルの **effective** プロパティを取得できます。この目的のために **TextStyleEffectiveData** クラスが Aspose.Slides に追加され、効果的なテキスト スタイル プロパティを保持します。

次のコードサンプルは、テキスト スタイルの **effective** プロパティを取得する方法を示しています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetTextStyleEffectiveData-GetTextStyleEffectiveData.cpp" >}}

## **Get the Effective Font Height Value**
Aspose.Slides for C++ を使用すると、フォントの高さの **effective** プロパティを取得できます。以下のコードは、プレゼンテーション構造のさまざまなレベルでローカル フォント 高さを設定した後に、部分の **effective** フォント 高さがどのように変化するかを示しています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLocalFontHeightValues-SetLocalFontHeightValues.cpp" >}}

## **Get the Effective Fill Format for a Table**
Aspose.Slides for C++ を使用すると、テーブルのさまざまな論理パーツの **effective** 塗りつぶし書式を取得できます。この目的のために **IFillFormatEffectiveData** インターフェイスが Aspose.Slides に追加され、効果的な塗りつぶし書式プロパティを保持します。セルの書式設定は常に行の書式設定より優先され、行は列より優先され、列はテーブル全体より優先されることに注意してください。

最終的に **CellFormatEffectiveData** のプロパティがテーブルの描画に使用されます。次のコードサンプルは、テーブルのさまざまな論理パーツの **effective** 塗りつぶし書式を取得する方法を示しています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetEffectiveValuesOfTable-GetEffectiveValuesOfTable.cpp" >}}

## **FAQ**

**「スナップショット」と「ライブ オブジェクト」の違いはどう判断し、いつ再度 effective プロパティを読み取るべきですか？**

EffectiveData オブジェクトは呼び出し時点で計算された値の不変スナップショットです。シェイプのローカルまたは継承設定を変更した場合は、再度 EffectiveData を取得して更新された値を取得してください。

**レイアウト/マスタースライドを変更すると、すでに取得した effective プロパティに影響しますか？**

はい、ただし再取得したときにのみ反映されます。既に取得した EffectiveData オブジェクトは自動的に更新されません。レイアウトやマスターを変更した後に再度リクエストしてください。

**EffectiveData を介して値を変更できますか？**

できません。EffectiveData は読み取り専用です。ローカルの書式オブジェクト（シェイプ/テキスト/3D など）を変更し、必要に応じて再度 effective 値を取得してください。

**シェイプレベルでもレイアウト/マスターでもグローバル設定でもプロパティが設定されていない場合はどうなりますか？**

effective 値はデフォルトのメカニズム（PowerPoint/Aspose.Slides のデフォルト）によって決定されます。その解決された値が EffectiveData スナップショットに含まれます。

**effective フォント値から、どのレベルがサイズやフォント名を提供したか判断できますか？**

直接は判断できません。EffectiveData は最終的な値を返すだけです。ソースを特定するには、portion/paragraph/text frame のローカル値や、レイアウト/マスター/プレゼンテーションのテキストスタイルを確認し、最初に明示的に定義された場所を探してください。

**EffectiveData の値がローカルと同じに見えるのはなぜですか？**

ローカル値が最終的な値となり、上位レベルからの継承が不要だった場合です。このような場合、effective 値はローカル値と一致します。

**effective プロパティを使用すべきタイミングと、ローカルのみで作業すべきタイミングは？**

すべての継承が適用された「実際に描画される」結果が必要なときは EffectiveData を使用します（例：色やインデント、サイズの整合）。特定のレベルで書式を変更したい場合はローカルプロパティを操作し、必要に応じて EffectiveData を再取得して結果を確認してください。