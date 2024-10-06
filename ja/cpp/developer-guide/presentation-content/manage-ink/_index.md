---
title: インクの管理
type: docs
weight: 95
url: /ja/cpp/manage-ink/
keywords: "PowerPointのインク, インクツール, C++インク, PowerPointで描画, PowerPointプレゼンテーション, C++, CPP, Aspose.Slides for C++"
description: "インクツールを使用してPowerPoint C++でオブジェクトを描画します"
---

PowerPointはインク機能を提供しており、非標準の図形を描画して他のオブジェクトを強調表示したり、接続やプロセスを示したり、スライド上の特定の項目に注意を引くことができます。

Aspose.Slidesは、インクオブジェクトを作成および管理するために必要な型を含む[Aspose.Slides.Ink](https://reference.aspose.com/slides/cpp/aspose.slides.ink/)インターフェースを提供します。

## **通常のオブジェクトとインクオブジェクトの違い**

PowerPointスライド上のオブジェクトは通常、シェイプオブジェクトによって表されます。シェイプオブジェクトは、その最も単純な形であれば、オブジェクト自体（そのフレーム）の領域とそのプロパティを定義するコンテナです。後者には、コンテナ領域のサイズ、コンテナの形、コンテナの背景などが含まれます。詳細については、[Shape Layout Format](https://docs.aspose.com/slides/cpp/shape-manipulations/#access-layout-formats-for-shape)を参照してください。

しかし、PowerPointがインクオブジェクトを扱うとき、オブジェクトフレーム（コンテナ）のサイズを除くすべてのプロパティを無視します。コンテナ領域のサイズは、標準の`width`と`height`の値によって決まります：

![ink_powerpoint1](ink_powerpoint1.png)

## **インクシェイプのトレース**

トレースは、ユーザーがデジタルインクを書く際のペンの軌跡を記録するための基本要素または標準です。トレースは、接続されたポイントのシーケンスを記述する記録です。

エンコーディングの最も単純な形は、各サンプルポイントのXおよびY座標を指定します。すべての接続されたポイントが描画されると、次のような画像が生成されます：

![ink_powerpoint2](ink_powerpoint2.png)

## 描画のためのブラシプロパティ

トレース要素のポイントを接続するラインを描画するためにブラシを使用できます。ブラシには独自の色とサイズがあり、それぞれ`Brush.Color`および`Brush.Size`プロパティに対応しています。

### **インクブラシの色を設定する**

このC++コードは、ブラシの色を設定する方法を示しています：

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::Color brushColor = brush->get_Color();
brush->set_Color(System::Drawing::Color::get_Red());
```

### **インクブラシのサイズを設定する**

このC++コードは、ブラシのサイズを設定する方法を示しています：

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::SizeF brushSize = brush->get_Size();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));
```

一般に、ブラシの幅と高さは一致しないため、PowerPointはブラシサイズを表示しません（データセクションはグレーアウトされます）。しかし、ブラシの幅と高さが一致すると、PowerPointは次のようにサイズを表示します：

![ink_powerpoint3](ink_powerpoint3.png)

明確にするために、インクオブジェクトの高さを増やし、重要な寸法をレビューしましょう：

![ink_powerpoint4](ink_powerpoint4.png)

コンテナ（フレーム）はブラシのサイズを考慮せず、常に線の太さがゼロであると仮定します（最後の画像を参照）。

したがって、インクオブジェクト全体の可視領域を決定するには、トレースオブジェクトのブラシサイズを考慮する必要があります。ここで、ターゲットオブジェクト（手書きのテキストトレースオブジェクト）はコンテナ（フレーム）サイズにスケールされています。コンテナ（フレーム）のサイズが変わると、ブラシサイズは一定のままであり、その逆も然りです。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPointはテキストを扱う際に同じ動作を示します：

![ink_powerpoint6](ink_powerpoint6.png)

**さらなる読み物**

* シェイプに関する一般情報については、[PowerPoint Shapes](https://docs.aspose.com/slides/cpp/powerpoint-shapes/)セクションを参照してください。
* 効果的な値に関する詳細については、[Shape Effective Properties](https://docs.aspose.com/slides/cpp/shape-effective-properties/#get-effective-font-height-value)を参照してください。