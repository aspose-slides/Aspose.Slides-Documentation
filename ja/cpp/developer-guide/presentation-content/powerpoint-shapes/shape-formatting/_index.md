---
title: シェイプのフォーマット
type: docs
weight: 20
url: /cpp/shape-formatting/
keywords: "シェイプのフォーマット, ラインのフォーマット, ジョインスタイルのフォーマット, グラデーション塗りつぶし, パターン塗りつぶし, 画像塗りつぶし, ソリッドカラー塗りつぶし, シェイプの回転, 3Dベベル効果, 3D回転効果, PowerPointプレゼンテーション, C++, Aspose.Slides for С++"
description: "C++におけるPowerPointプレゼンテーションのシェイプをフォーマットする"
---

PowerPointでは、スライドにシェイプを追加できます。シェイプは線から構成されているため、それらの構成要素である線を変更したり、特定の効果を適用したりすることでシェイプのフォーマットができます。さらに、シェイプの領域がどのように塗りつぶされるかを決定する設定を指定することで、シェイプをフォーマットすることもできます。

![format-shape-powerpoint](format-shape-powerpoint.png)


**Aspose.Slides for C++**は、PowerPointで知られているオプションに基づいてシェイプをフォーマットするためのインターフェースとプロパティを提供します。

## **ラインのフォーマット**

Aspose.Slidesを使用すると、シェイプに対して好みのラインスタイルを指定できます。以下はその手順です：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに[IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape)を追加します。
4. シェイプのラインの色を設定します。
5. シェイプのラインの幅を設定します。
6. シェイプのラインスタイルを設定します。[line style](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a837c78839bf6ebb16979455cd1de59e4)
7. シェイプのラインの[ダッシュスタイル](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a7eaad354a35a3b567a7327d625be3c6e)を設定します。
8. 修正されたプレゼンテーションをPPTXファイルとして書き出します。

以下のC++コードは、長方形の`AutoShape`をフォーマットする操作を示しています：

```cpp
// プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成します
auto pres = MakeObject<Presentation>();

// 最初のスライドを取得します
auto slide = pres->get_Slides()->idx_get(0);

// 長方形タイプのオートシェイプを追加します
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// 長方形シェイプの塗りつぶし色を設定します
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_White());

// 長方形のラインにいくつかのフォーマットを適用します
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// 長方形のラインの色を設定します
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// PPTXファイルをディスクに書き出します
pres->Save(u"RectShpLn_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **ジョインスタイルのフォーマット**
これらは3つのジョインタイプオプションです：

* ラウンド
* ミタ
* ベベル

デフォルトでは、PowerPointが2つの線を角度（またはシェイプのコーナー）で接続する際、**ラウンド**の設定を使用します。ただし、非常に鋭い角度のシェイプを描きたい場合は、**ミタ**を選択することをお勧めします。

![join-style-powerpoint](join-style-powerpoint.png)

以下のC++コードは、ミタ、ベベル、およびラウンドのジョインタイプ設定で作成された3つの長方形の処理を示しています（上記の画像）：

```cpp
// プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成します
auto pres = MakeObject<Presentation>();

// 最初のスライドを取得します
auto slide = pres->get_Slides()->idx_get(0);

// 3つの長方形オートシェイプを追加します
SharedPtr<IAutoShape> shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);
SharedPtr<IAutoShape> shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 300, 100, 150, 75);
SharedPtr<IAutoShape> shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 250, 150, 75);

// 長方形シェイプの塗りつぶし色を設定します
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// ラインの幅を設定します
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// 長方形のラインの色を設定します
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// ジョインスタイルを設定します
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// 各長方形にテキストを追加します
shape1->get_TextFrame()->set_Text(u"ミタジョインスタイル");
shape2->get_TextFrame()->set_Text(u"ベベルジョインスタイル");
shape3->get_TextFrame()->set_Text(u"ラウンドジョインスタイル");

// PPTXファイルをディスクに書き出します
pres->Save(u"RectShpLnJoin_out.pptx", Export::SaveFormat::Pptx);
```

## **グラデーション塗りつぶし**
PowerPointでは、グラデーション塗りつぶしは、シェイプに色の連続したブレンドを適用するためのフォーマットオプションです。たとえば、1つの色が徐々に別の色に変化する設定で、2色以上を適用することができます。

Aspose.Slidesを使用してシェイプにグラデーション塗りつぶしを適用する方法は次のとおりです：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape)をスライドに追加します。
4. シェイプの[FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a)を`Gradient`に設定します。
5. `GradientFormat`クラスに関連付けられた`GradientStops`コレクションの`Add`メソッドを使用して、位置が定義された好みの2色を追加します。
6. 修正されたプレゼンテーションをPPTXファイルとして書き出します。

以下のC++コードは、楕円形にグラデーション塗りつぶし効果を適用する操作を示しています：

```cpp
// プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成します
auto pres = MakeObject<Presentation>();

// 最初のスライドを取得します
auto slide = pres->get_Slides()->idx_get(0);
    
// 楕円形オートシェイプを追加します
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 150, 75, 150);

// 楕円形にグラデーションフォーマットを適用します
autoShape->get_FillFormat()->set_FillType(FillType::Gradient);
autoShape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// グラデーションの方向を設定します
autoShape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// 2つのグラデーションストップを追加します
autoShape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
autoShape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// PPTXファイルをディスクに書き出します
pres->Save(u"FillShapesGradient_out.pptx", Export::SaveFormat::Pptx);
```

## **パターン塗りつぶし**
PowerPointでは、パターン塗りつぶしは、点、ストライプ、クロスハッチ、またはチェックからなる2色のデザインをシェイプに適用するためのフォーマットオプションです。さらに、パターンの前景と背景の好みの色を選択できます。

Aspose.Slidesは、シェイプをフォーマットし、プレゼンテーションを豊かにするために使用できる45以上の定義済みスタイルを提供しています。定義済みパターンを選択した後でも、パターンが含むべき色を指定できます。

Aspose.Slidesを使用してシェイプにパターン塗りつぶしを適用する方法は次のとおりです：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape)をスライドに追加します。
4. シェイプの[FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a)を`Pattern`に設定します。
5. シェイプの好みのパターンスタイルを設定します。
6. [PatternFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.pattern_format)の[背景色](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_pattern_format#af55b6343b7bd80d0ad95070e96b8766e)を設定します。
7. [前景色](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_pattern_format#a4121d8c2233df4b90cbfd6ea4c312cbe)を[PatternFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.pattern_format)に設定します。
8. 修正されたプレゼンテーションをPPTXファイルとして書き出します。

以下のC++コードは、長方形を美化するためにパターン塗りつぶしを使用する操作を示しています：

```cpp
// プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成します
auto pres = MakeObject<Presentation>();

// 最初のスライドを取得します
auto slide = pres->get_Slides()->idx_get(0);

// 長方形オートシェイプを追加します
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);

// 塗りつぶしタイプをパターンに設定します
autoShape->get_FillFormat()->set_FillType(FillType::Pattern);

// パターンスタイルを設定します
autoShape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// パターンの背景色と前景色を設定します
autoShape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color ( Color::get_LightGray());
autoShape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// PPTXファイルをディスクに書き出します
pres->Save(u"RectShpPatt_out.pptx", Export::SaveFormat::Pptx);
```

## **画像塗りつぶし**
PowerPointでは、画像塗りつぶしは、シェイプの内部に画像を配置するためのフォーマットオプションです。基本的に、画像をシェイプの背景として使用することができます。

Aspose.Slidesを使用してシェイプを画像で塗りつぶす方法は次のとおりです：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape)をスライドに追加します。
4. シェイプの[FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a)を`Picture`に設定します。
5. 画像塗りつぶしモードをタイルに設定します。
6. シェイプを塗りつぶすために使用される画像を使用して`IPPImage`オブジェクトを作成します。
7. `PictureFillFormat`オブジェクトの`Picture.Image`プロパティに最近作成した`IPPImage`を設定します。
8. 修正されたプレゼンテーションをPPTXファイルとして書き出します。

以下のC++コードは、シェイプを画像で塗りつぶす方法を示しています：

```cpp
// プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成します
auto pres = MakeObject<Presentation>();

// 最初のスライドを取得します
auto slide = pres->get_Slides()->idx_get(0);

// 長方形オートシェイプを追加します
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);

// 塗りつぶしタイプを画像に設定します
autoShape->get_FillFormat()->set_FillType(FillType::Picture);

// 画像塗りつぶしモードを設定します
autoShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// 画像を設定します
auto img = Images::FromFile(u"Tulips.jpg");
auto imgx = pres->get_Images()->AddImage(img);
autoShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// PPTXファイルをディスクに書き出します
pres->Save(u"RectShpPic_out.pptx", Export::SaveFormat::Pptx);
```

## **ソリッドカラー塗りつぶし**
PowerPointでは、ソリッドカラー塗りつぶしは、シェイプを単一の色で塗りつぶすためのフォーマットオプションです。選択された色は通常、平面の色です。色は、シェイプの背景に適用され、特別な効果や変更が行われます。

Aspose.Slidesを使用してシェイプにソリッドカラー塗りつぶしを適用する方法は次のとおりです：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
2. インデックスを使ってスライドの参照を取得します。
3. [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape)をスライドに追加します。
4. シェイプの[FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a)を`Solid`に設定します。
5. シェイプの好みの色を設定します。
6. 修正されたプレゼンテーションをPPTXファイルとして書き出します。

上記の手順は、以下の例で実装されています。

```cpp
// プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成します
auto pres = MakeObject<Presentation>();

// 最初のスライドを取得します
auto slide = pres->get_Slides()->idx_get(0);

// 長方形オートシェイプを追加します
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);

// 塗りつぶしタイプを画像に設定します
autoShape->get_FillFormat()->set_FillType(FillType::Solid);

// 長方形の色を設定します
autoShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// PPTXファイルをディスクに書き出します
pres->Save(u"RectShpSolid_out.pptx", Export::SaveFormat::Pptx);
```

## **透明度を設定**

PowerPointでは、シェイプをソリッドカラー、グラデーション、画像、またはテクスチャで塗りつぶす場合、塗りつぶしの不透明度を定義する透明度レベルを指定できます。この方法により、たとえば、透明度レベルを低く設定すると、スライドオブジェクトや背景がそのシェイプ越しに見えるようになります。

Aspose.Slidesでは、次の方法でシェイプの透明度レベルを設定できます：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape)をスライドに追加します。
4. アルファ成分を設定して`Color.FromArgb`を使用します。
5. オブジェクトをPowerPointファイルとして保存します。

以下のC++コードは、プロセスを示しています：

```cpp
// プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成します
auto pres = MakeObject<Presentation>();

// 最初のスライドを取得します
auto slide = pres->get_Slides()->idx_get(0);

// ソリッドシェイプを追加します
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 75, 175, 75, 150);

// ソリッドシェイプの上に透明なシェイプを追加します
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(128, 204, 102, 0));
   
// PPTXファイルをディスクに書き出します
pres->Save(u"ShapeTransparentOverSolid_out.pptx", Export::SaveFormat::Pptx);
```

## **シェイプの回転**
Aspose.Slidesを使用すると、スライドに追加されたシェイプを次の方法で回転できます：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape)をスライドに追加します。
4. 必要な度数だけシェイプを回転します。
5. 修正されたプレゼンテーションをPPTXファイルとして書き出します。

以下のC++コードは、90度回転させるシェイプを示しています：

```cpp
// プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成します
auto pres = MakeObject<Presentation>();

// 最初のスライドを取得します
auto slide = pres->get_Slides()->idx_get(0);

// 長方形オートシェイプを追加します
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);

// シェイプを90度回転させます
autoShape->set_Rotation(90.f);

// PPTXファイルをディスクに書き出します
pres->Save(u"RectShpRot_out.pptx", Export::SaveFormat::Pptx);
```

## **3Dベベル効果を追加**
Aspose.Slidesを使用すると、次の方法でシェイプに3Dベベル効果を適用できます：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape)をスライドに追加します。
3. シェイプの[ThreeDFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format)プロパティに対して好みのパラメータを設定します。
4. プレゼンテーションをディスクに書き出します。

以下のC++コードは、シェイプに3Dベベル効果を追加する方法を示しています：

```cpp
// プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成します
auto pres = MakeObject<Presentation>();

// 最初のスライドを取得します
auto slide = pres->get_Slides()->idx_get(0);

// スライドにシェイプを追加します
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 30, 200, 200);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
auto format = shape->get_LineFormat()->get_FillFormat();
format->set_FillType(FillType::Solid);
format->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// シェイプのThreeDFormatプロパティを設定します
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// プレゼンテーションをPPTXファイルとして書き出します
pres->Save(u"Bavel_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **3D回転効果を追加**
Aspose.Slidesを使用すると、主に[ThreeDFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format)プロパティを修正することでシェイプに3D回転効果を適用できます：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape)をスライドに追加します。
3. [CameraType](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_camera#aea0717e8ef5f3199df99ed2cb2ea2dcb)と[LightType](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_light_rig#a2cd12029664967d0e2f93eee25a4963f)に対して好みのパラメータを指定します。
4. プレゼンテーションをディスクに書き出します。

以下のC++コードは、シェイプに3D回転効果を適用する方法を示しています：

```cpp
// プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成します
auto pres = MakeObject<Presentation>();

// 最初のスライドを取得します
auto slide = pres->get_Slides()->idx_get(0);
    
// スライドにシェイプを追加します
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 30, 200, 200);

// シェイプのThreeDFormatプロパティを設定します
shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// スライドにシェイプを追加します
shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 300, 200, 200);

// シェイプのThreeDFormatプロパティを設定します
shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(0, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// プレゼンテーションをPPTXファイルとして書き出します
pres->Save(u"Rotation_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **フォーマットをリセット**

以下のC++コードは、スライドでフォーマットをリセットし、[LayoutSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.layout_slide)にプレースホルダーのある各シェイプの位置、サイズ、フォーマットをデフォルトに戻す方法を示しています：

```c++
auto pres = System::MakeObject<Presentation>();

for (auto slide : pres->get_Slides())
{
    // レイアウト上にプレースホルダーのあるスライド上の各シェイプがリセットされます
    slide->Reset();
}
```