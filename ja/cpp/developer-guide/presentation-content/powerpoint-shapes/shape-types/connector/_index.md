---
title: C++ を使用したプレゼンテーションでのコネクタ管理
linktitle: コネクタ
type: docs
weight: 10
url: /ja/cpp/connector/
keywords:
- コネクタ
- コネクタの種類
- コネクタのポイント
- コネクタ線
- コネクタ角度
- 図形を接続
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "C++ アプリに PowerPoint スライド上で線を描画し、接続し、自動ルーティングする機能を提供し、直線、エルボー、曲線コネクタを完全に制御できます。"
---

PowerPoint のコネクタは、2 つの図形を接続またはリンクする特殊な線で、スライド上で図形が移動または位置変更されても図形に付着したままになります。

コネクタは通常、*接続点*（緑色の点）に接続されます。接続点はすべての図形にデフォルトで存在し、カーソルが近づくと表示されます。

*調整点*（オレンジ色の点）は特定のコネクタにのみ存在し、コネクタの位置や形状を変更するために使用されます。

## **コネクタの種類**

PowerPoint では、直線、エルボー（角度付き）、曲線のコネクタを使用できます。

Aspose.Slides は次のコネクタを提供します:

| コネクタ | 画像 | 調整点の数 |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **コネクタを使用して図形を接続する**

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. `Shapes` オブジェクトが提供する `AddAutoShape` メソッドを使用して、スライドに 2 つの [AutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape) を追加します。
1. コネクタのタイプを指定して、`Shapes` オブジェクトが提供する `AddConnector` メソッドでコネクタを追加します。
1. コネクタを使用して図形を接続します。
1. `Reroute` メソッドを呼び出して、最短接続パスを適用します。
1. プレゼンテーションを保存します。

この C++ コードは、2 つの図形（楕円と矩形）の間にコネクタ（曲げコネクタ）を追加する方法を示しています:
```c++
 // ドキュメントディレクトリへのパス。
	const String outPath = u"../out/ConnectShapesUsingConnectors_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// 指定したプレゼンテーションを読み込みます
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 最初のスライドにアクセス
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 特定のスライドのシェイプコレクションにアクセス
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// 楕円のオートシェイプを追加
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// 四角形のオートシェイプを追加
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);

	// スライドのシェイプコレクションにコネクタシェイプを追加
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

	// コネクタを使用してシェイプを接続
	connector->set_StartShapeConnectedTo ( ellipse);
	connector->set_EndShapeConnectedTo (rect);

	// シェイプ間の最短パスを自動設定する reroute を呼び出す
	connector->Reroute();
	
	// プレゼンテーションを保存
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


{{%  alert title="NOTE"  color="warning"   %}} 
`connector->Reroute` メソッドはコネクタのルートを再計算し、図形間の最短パスを取らせます。この目的を達成するために、メソッドは `StartShapeConnectionSiteIndex` と `EndShapeConnectionSiteIndex` のポイントを変更する場合があります。 
{{% /alert %}} 

## **接続点の指定**

コネクタが図形上の特定の点を使用して 2 つの図形をリンクさせたい場合は、以下の手順で希望する接続点を指定します:

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. `Shapes` オブジェクトが提供する `AddAutoShape` メソッドを使用して、スライドに 2 つの [AutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape) を追加します。
1. コネクタのタイプを指定して、`Shapes` オブジェクトが提供する `AddConnector` メソッドでコネクタを追加します。
1. コネクタを使用して図形を接続します。
1. 図形上の希望する接続点を設定します。
1. プレゼンテーションを保存します。

この C++ コードは、希望する接続点を指定した操作を示しています:
```c++
	// ドキュメントディレクトリへのパス。
	const String outPath = u"../out/ConnectShapeUsingConnectionSite_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// 目的のプレゼンテーションを読み込みます
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 最初のスライドにアクセス
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 特定のスライドのシェイプコレクションにアクセス
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// 楕円のオートシェイプを追加
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// 矩形のオートシェイプを追加
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 100, 100);

	// スライドのシェイプコレクションにコネクタシェイプを追加
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

	// コネクタを使用してシェイプを接続
	connector->set_StartShapeConnectedTo(ellipse);
	connector->set_EndShapeConnectedTo(rect);


	// 楕円シェイプの優先接続ドットインデックスを設定
	int wantedIndex = 6;

	// 優先インデックスが最大サイトインデックス数未満かを確認
	if (ellipse->get_ConnectionSiteCount() > wantedIndex)
	{
		// 楕円オートシェイプに優先接続ドットを設定
		connector->set_StartShapeConnectionSiteIndex ( wantedIndex);
	}

	// プレゼンテーションを保存
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **コネクタのポイントを調整する**

既存のコネクタは調整点を使用して調整できます。調整点を持つコネクタのみがこの方法で変更可能です。**[コネクタの種類](/slides/ja/cpp/connector/#types-of-connectors)** の表を参照してください。

### **シンプルケース**

2 つの図形（A と B）をつなぐコネクタが、3 番目の図形（C）を通過するケースを考えてみましょう:

![connector-obstruction](connector-obstruction.png)

Code:
```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shapes = slide->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 300.0f, 150.0f, 150.0f, 75.0f);
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 400.0f, 100.0f, 50.0f);
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 70.0f, 30.0f);

auto connector = shapes->AddConnector(ShapeType::BentConnector5, 20.0f, 20.0f, 400.0f, 300.0f);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_StartShapeConnectionSiteIndex(2);
```


3 番目の図形を回避または迂回するために、次のように垂直線を左に移動させてコネクタを調整できます:

![connector-obstruction-fixed](connector-obstruction-fixed.png)
```c++
auto adj2 = connector->get_Adjustments()->idx_get(1);
adj2->set_RawValue(adj2->get_RawValue() + 10000);
```


### **複雑なケース**

より複雑な調整を行うには、以下の点に留意する必要があります:

* コネクタの調整ポイントは、その位置を計算・決定する数式と強く結びついています。そのため、ポイントの位置を変更するとコネクタの形状が変わる可能性があります。
* コネクタの調整点は配列内で厳密な順序で定義されます。調整点はコネクタの開始点から終了点へと番号付けされます。
* 調整点の値はコネクタ形状の幅／高さの百分率を表します。  
  * 形状はコネクタの開始点と終了点に 1000 を掛けた範囲で制限されます。  
  * 最初のポイントは幅の百分率、2 番目のポイントは高さの百分率、3 番目のポイントは再び幅の百分率を表します。
* コネクタの調整点の座標を算出する際には、コネクタの回転と反転を考慮する必要があります。**注**：**[コネクタの種類](/slides/ja/cpp/connector/#types-of-connectors)** に示されたすべてのコネクタの回転角度は 0 です。

#### **ケース 1**

2 つのテキストフレームオブジェクトがコネクタで結ばれているケースを考えてみましょう:

![connector-shape-complex](connector-shape-complex.png)

Code:
```c++
// PPTX ファイルを表すプレゼンテーション クラスのインスタンスを作成します
auto pres = System::MakeObject<Presentation>();
// プレゼンテーションの最初のスライドを取得します
auto slide = pres->get_Slides()->idx_get(0);
// 最初のスライドからシェイプを取得します
auto shapes = slide->get_Shapes();
// コネクタで結合されるシェイプを追加します
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 60.0f, 25.0f);
shapeFrom->get_TextFrame()->set_Text(u"From");
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 100.0f, 60.0f, 25.0f);
shapeTo->get_TextFrame()->set_Text(u"To");
// コネクタを追加します
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
auto lineFormat = connector->get_LineFormat();
// コネクタの方向を指定します
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
// コネクタの線の太さを指定します
lineFormat->set_Width(3);
// コネクタの色を指定します
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Crimson());

// コネクタでシェイプ同士をリンクします
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_EndShapeConnectionSiteIndex(2);

// コネクタの調整ポイントを取得します
auto adjustments = connector->get_Adjustments();
auto adjValue_0 = adjustments->idx_get(0);
auto adjValue_1 = adjustments->idx_get(1);
```


**調整**

対応する幅と高さの百分率をそれぞれ 20% と 200% 増加させて、コネクタの調整点の値を変更できます:
```c++
// 調整ポイントの値を変更します
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```


結果:

![connector-adjusted-1](connector-adjusted-1.png)

コネクタの個々の部品の座標と形状を決定できるモデルを定義するために、`connector.Adjustments[0]` のポイントに対応する水平コンポーネントの形状を作成します:
```c++
// コネクタの垂直成分を描画
float x = connector->get_X() + connector->get_Width() * adjValue_0->get_RawValue() / 100000;
float y = connector->get_Y();
float height = connector->get_Height() * adjValue_1->get_RawValue() / 100000;
shapes->AddAutoShape(ShapeType::Rectangle, x, y, 0.0f, height);
```


結果:

![connector-adjusted-2](connector-adjusted-2.png)

#### **ケース 2**

**ケース 1** では、基本原理を用いたシンプルなコネクタ調整操作を示しました。通常の状況では、`connector.Rotation`、`connector.Frame.FlipH`、`connector.Frame.FlipV` が設定するコネクタの回転と表示を考慮する必要があります。以下でプロセスを示します。

まず、スライドに新しいテキストフレームオブジェクト（**To 1**）を追加し（接続用）、既存オブジェクトに接続する新しい（緑色）コネクタを作成します。
```c++
// 新しいバインディングオブジェクトを作成します
auto shapeTo_1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 400.0f, 60.0f, 25.0f);
shapeTo_1->get_TextFrame()->set_Text(u"To 1");
// 新しいコネクタを作成します
connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
lineFormat->set_Width(3);
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_MediumAquamarine());
// 新しく作成したコネクタを使用してオブジェクトを接続します
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(shapeTo_1);
connector->set_EndShapeConnectionSiteIndex(3);
// コネクタの調整ポイントを取得します
adjValue_0 = adjustments->idx_get(0);
adjValue_1 = adjustments->idx_get(1);
// 調整ポイントの値を変更します
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```


結果:

![connector-adjusted-3](connector-adjusted-3.png)

次に、新しいコネクタの調整点 `connector.Adjustments[0]` を通過する水平コンポーネントに対応する形状を作成します。`connector.Rotation`、`connector.Frame.FlipH`、`connector.Frame.FlipV` の値を使用し、点 x0 周りの回転座標変換式を適用します:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

今回、オブジェクトの回転角は 90 度でコネクタは縦向きに表示されるため、対応するコードは次のとおりです:
```c++

```


結果:

![connector-adjusted-4](connector-adjusted-4.png)

シンプルな調整と回転角を伴う複雑な調整点の計算を示しました。得られた知識を活用して、`GraphicsPath` オブジェクトを取得したり、特定のスライド座標に基づいてコネクタの調整点の値を設定したりする独自のモデル（またはコード）を作成できます。

## **コネクタ線の角度を求める**

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. コネクタの線形状にアクセスします。
1. 線の幅・高さ、形状フレームの高さ・幅を使用して角度を計算します。

この C++ コードは、コネクタ線形状の角度を計算する操作を示しています:
```c++
void ConnectorLineAngle()
{

	// ドキュメントディレクトリへのパス。
	const String outPath = u"../out/ConnectorLineAngle_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// 目的のプレゼンテーションを読み込みます
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// 最初のスライドにアクセスします
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	for (int i = 0; i < slide->get_Shapes()->get_Count(); i++)
	{
		double dir = 0.0;
		// スライドのシェイプコレクションにアクセスします
		System::SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(i);

		if (System::ObjectExt::Is<AutoShape>(shape))
		{
			SharedPtr<AutoShape> aShape = ExplicitCast<Aspose::Slides::AutoShape>(shape);
			if (aShape->get_ShapeType() == ShapeType::Line)
			{
//				dir = getDirection(aShape->get_Width(), aShape->get_Height(), Convert::ToBoolean(aShape->get_Frame()->get_FlipH()), Convert::ToBoolean(aShape->get_Frame()->get_FlipV()));
				dir = getDirection(aShape->get_Width(), aShape->get_Height(), aShape->get_Frame()->get_FlipH(), aShape->get_Frame()->get_FlipV());

			}
		}

		else if (System::ObjectExt::Is<Connector>(shape))
		{
				SharedPtr<Connector> aShape = ExplicitCast<Aspose::Slides::Connector>(shape);
//				dir = getDirection(aShape->get_Width(), aShape->get_Height(), Convert::ToBoolean(aShape->get_Frame()->get_FlipH()), Convert::ToBoolean(aShape->get_Frame()->get_FlipV()));
				dir = getDirection(aShape->get_Width(), aShape->get_Height(), aShape->get_Frame()->get_FlipH(),aShape->get_Frame()->get_FlipV());
		}

		Console::WriteLine(dir);
	
	}


}
//double ConnectorLineAngle::getDirection(float w, float h, NullableBool flipH, NullableBool flipV)
double getDirection(float w, float h, Aspose::Slides::NullableBool flipH, Aspose::Slides::NullableBool flipV)
{
	float endLineX = w;

	if (flipH == NullableBool::True)
		endLineX= endLineX * -1;
	else
		endLineX=endLineX *  1;
	//float endLineX = w * (flipH ? -1 : 1);
	float endLineY = h;
	if (flipV == NullableBool::True)
		endLineY = endLineY * -1;
	else
		endLineY = endLineY *  1;
//	float endLineY = h * (flipV ? -1 : 1);
	float endYAxisX = 0;
	float endYAxisY = h;
	double angle = (Math::Atan2(endYAxisY, endYAxisX) - Math::Atan2(endLineY, endLineX));
	if (angle < 0) angle += 2 * Math::PI;
	return angle * 180.0 / Math::PI;
}
```


## **FAQ**

**コネクタが特定の図形に「貼り付け」可能かどうかはどうやって判断できますか？**

図形が [connection sites](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_connectionsitecount/) を公開しているか確認してください。存在しない、またはカウントが 0 の場合は貼り付けは利用できません。その場合は自由端点を使用し、手動で位置を設定します。接続前にサイト数を確認することが賢明です。

**接続された図形の一つを削除すると、コネクタはどうなりますか？**

コネクタの端は切り離され、スライド上には自由な開始/終了点を持つ普通の線として残ります。削除するか、接続を再割り当てして、必要に応じて [reroute](https://reference.aspose.com/slides/cpp/aspose.slides/connector/reroute/) してください。

**スライドを別のプレゼンテーションにコピーしたとき、コネクタのバインディングは保持されますか？**

一般的に保持されますが、対象の図形も同様にコピーされている必要があります。接続された図形が含まれない状態でスライドを別ファイルに挿入した場合、端は自由端点となり、再度接続し直す必要があります。