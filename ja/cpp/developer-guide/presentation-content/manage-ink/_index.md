---
title: C++ でプレゼンテーションのインクオブジェクトを管理
linktitle: インクを管理
type: docs
weight: 95
url: /ja/cpp/manage-ink/
keywords:
- インク
- インクオブジェクト
- インクトレース
- インクの管理
- インクの描画
- 描画
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "PowerPoint のインクオブジェクトを管理します—Aspose.Slides for C++ を使用してデジタルインクを作成、編集、スタイル設定できます。トレース、ブラシの色とサイズに関するコードサンプルをご覧ください。"
---

PowerPointは、標準的でない図形を描くためのインク機能を提供しており、他のオブジェクトを強調したり、接続やプロセスを示したり、スライド上の特定の項目に注意を引くために使用できます。

Aspose.Slidesは、インク オブジェクトを作成および管理するために必要な型を含む [Aspose.Slides.Ink](https://reference.aspose.com/slides/cpp/aspose.slides.ink/) インターフェイスを提供します。

## **通常オブジェクトとインクオブジェクトの違い**

PowerPointスライド上のオブジェクトは通常、シェイプオブジェクトとして表されます。シェイプオブジェクトは、最も単純な形では、オブジェクト自体（フレーム）の領域とそのプロパティを定義するコンテナです。後者には、コンテナ領域のサイズ、コンテナの形状、コンテナの背景などが含まれます。詳細については、[Shape Layout Format](https://docs.aspose.com/slides/cpp/shape-manipulations/#access-layout-formats-for-shape) を参照してください。

ただし、PowerPointがインクオブジェクトを扱う場合、サイズ以外のフレーム（コンテナ）プロパティはすべて無視されます。コンテナ領域のサイズは、標準の `width` と `height` 値で決まります：

![ink_powerpoint1](ink_powerpoint1.png)

## **インクシェイプのトレース**

トレースは、ユーザーがデジタルインクで書く際のペンの軌跡を記録するための基本要素または標準です。トレースは、接続されたポイントのシーケンスを記述する記録です。

エンコーディングの最も単純な形式は、各サンプルポイントの X と Y 座標を指定します。すべての接続ポイントが描画されると、次のような画像が生成されます：

![ink_powerpoint2](ink_powerpoint2.png)

## **描画用ブラシのプロパティ**

トレース要素のポイントを結ぶ線を描くためにブラシを使用できます。ブラシは `Brush.Color` と `Brush.Size` プロパティに対応する独自の色とサイズを持ちます。

### **インク ブラシの色の設定**

この C++ コードは、ブラシの色を設定する方法を示しています:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::Color brushColor = brush->get_Color();
brush->set_Color(System::Drawing::Color::get_Red());
```


### **インク ブラシのサイズの設定**

この C++ コードは、ブラシのサイズを設定する方法を示しています:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::SizeF brushSize = brush->get_Size();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));
```


一般に、ブラシの幅と高さは一致しないため、PowerPoint はブラシサイズを表示しません（データ セクションはグレー表示）。しかし、ブラシの幅と高さが一致する場合、PowerPoint は次のようにサイズを表示します：

![ink_powerpoint3](ink_powerpoint3.png)

分かりやすくするために、インクオブジェクトの高さを増やし、重要な寸法を確認しましょう：

![ink_powerpoint4](ink_powerpoint4.png)

コンテナ（フレーム）はブラシのサイズを考慮せず、常に線の太さはゼロと見なします（最後の画像参照）。

したがって、インクオブジェクト全体の可視領域を決定するには、トレースオブジェクトのブラシサイズを考慮する必要があります。ここでは、対象オブジェクト（手書きテキストのトレースオブジェクト）がコンテナ（フレーム）サイズにスケーリングされています。コンテナ（フレーム）のサイズが変わると、ブラシサイズは一定のままであり、逆も同様です：

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint はテキストを扱う場合も同様の動作を示します：

![ink_powerpoint6](ink_powerpoint6.png)

**さらに読む**

* 形状全般については、[PowerPoint Shapes](https://docs.aspose.com/slides/cpp/powerpoint-shapes/) セクションをご参照ください。  
* 有効な値に関する詳細は、[Shape Effective Properties](https://docs.aspose.com/slides/cpp/shape-effective-properties/#get-effective-font-height-value) をご覧ください。