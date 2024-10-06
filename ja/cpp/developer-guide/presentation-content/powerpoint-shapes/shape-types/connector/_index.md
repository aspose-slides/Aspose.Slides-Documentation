---
title: 接続子
type: docs
weight: 10
url: /ja/cpp/connector/
keywords: "図形を接続, コネクタ, PowerPoint図形, PowerPointプレゼンテーション, C++, CPP, Aspose.Slides for C++"
description: "C++でPowerPoint図形を接続する"
---

PowerPointのコネクタは、2つの図形を接続またはリンクする特別な線であり、指定されたスライド上で図形が移動または再配置されても、図形に付着したままになります。

コネクタは通常、すべての図形にデフォルトで存在する*接続点*（緑の点）に接続されています。接続点は、カーソルが近づくと表示されます。

*調整点*（オレンジの点）は、特定のコネクタにのみ存在し、コネクタの位置や形状を変更するために使用されます。

## **コネクタの種類**

PowerPointでは、直線、肘（角度）および曲線コネクタを使用できます。

Aspose.Slidesは、以下のコネクタを提供します：

| コネクタ                         | 画像                                                          | 調整点の数               |
| ------------------------------- | ------------------------------------------------------------ | --------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                     |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                     |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                     |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                     |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                     |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                     |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                     |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                     |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                     |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                     |

## **コネクタを使用して図形を接続する**

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/)クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。
1. `Shapes`オブジェクトが公開する`AddAutoShape`メソッドを使用して、スライドに2つの[AutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape)を追加します。
1. コネクタの種類を定義して、`Shapes`オブジェクトが公開する`AddConnector`メソッドを使用してコネクタを追加します。
1. コネクタを使用して図形を接続します。 
1. 最短接続パスを適用するために`Reroute`メソッドを呼び出します。
1. プレゼンテーションを保存します。 

このC++コードは、2つの図形（楕円と長方形）の間にコネクタ（曲がったコネクタ）を追加する方法を示しています：

```c++
// ドキュメントディレクトリへのパス。
	const String outPath = u"../out/ConnectShapesUsingConnectors_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// 必要なプレゼンテーションを読み込みます。
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 最初のスライドにアクセスします。
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 特定のスライドの図形コレクションにアクセスします。
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// 楕円のオートシェイプを追加します。
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// 長方形のオートシェイプを追加します。
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);

	// スライドの図形コレクションにコネクタシェイプを追加します。
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

	// コネクタを使用して図形を接続します。
	connector->set_StartShapeConnectedTo ( ellipse);
	connector->set_EndShapeConnectedTo (rect);

	// 図形間の自動最短パスを設定するために再配線を呼び出します。
	connector->Reroute();
	
	// プレゼンテーションを保存します。
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="注意"  color="warning"   %}} 

`connector->Reroute`メソッドは、コネクタを再ルーティングし、図形間の最短経路を取るように強制します。その目的を達成するために、メソッドは`StartShapeConnectionSiteIndex`および`EndShapeConnectionSiteIndex`ポイントを変更する場合があります。 

{{% /alert %}} 

## **接続点を指定する**

特定の図形上の接続点を使用してコネクタで2つの図形をリンクさせたい場合は、この方法で好みの接続点を指定する必要があります：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/)クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。
1. `Shapes`オブジェクトが公開する`AddAutoShape`メソッドを使用して、スライドに2つの[AutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape)を追加します。
1. コネクタの種類を定義して、`Shapes`オブジェクトが公開する`AddConnector`メソッドを使用してコネクタを追加します。
1. コネクタを使用して図形を接続します。 
1. 図形上で希望する接続点を設定します。 
1. プレゼンテーションを保存します。

このC++コードは、希望する接続点が指定される操作を示しています：

```c++
// ドキュメントディレクトリへのパス。
	const String outPath = u"../out/ConnectShapeUsingConnectionSite_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// 必要なプレゼンテーションを読み込みます。
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 最初のスライドにアクセスします。
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 特定のスライドの図形コレクションにアクセスします。
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// 楕円のオートシェイプを追加します。
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// 長方形のオートシェイプを追加します。
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 100, 100);

	// スライドの図形コレクションにコネクタシェイプを追加します。
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

	// コネクタを使用して図形を接続します。
	connector->set_StartShapeConnectedTo(ellipse);
	connector->set_EndShapeConnectedTo(rect);

	// 楕円シェイプの希望の接続点インデックスを設定します。
	int wantedIndex = 6;

	// 希望のインデックスが最大サイトインデックスカウントより小さいかどうかを確認します。
	if (ellipse->get_ConnectionSiteCount() > wantedIndex)
	{
		// 楕円のオートシェイプで希望の接続点を設定します。
		connector->set_StartShapeConnectionSiteIndex ( wantedIndex);
	}

	// プレゼンテーションを保存します。
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **コネクタポイントの調整**

既存のコネクタは、その調整点を通じて調整できます。調整点を持つコネクタのみがこのように変更可能です。詳細は**[コネクタの種類](/slides/ja/cpp/connector/#types-of-connectors)**の下にある表を参照してください。

#### **単純なケース**

2つの図形（AとB）の間のコネクタが、3番目の図形（C）を通過するケースを考慮します：

![connector-obstruction](connector-obstruction.png)

コード：

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

3番目の図形を避けるために、コネクタを調整してその垂直線を左に移動させることができます：

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c++
auto adj2 = connector->get_Adjustments()->idx_get(1);
adj2->set_RawValue(adj2->get_RawValue() + 10000);
```

### **複雑なケース** 

より複雑な調整を行うには、以下の点を考慮する必要があります：

* コネクタの調整ポイントは、その位置を計算して決定する式に強く関連付けられています。したがって、ポイントの位置を変更すると、コネクタの形状が変わる場合があります。
* コネクタの調整ポイントは、厳密な順序で配列に定義されます。調整ポイントはコネクタの始点から終点へ番号付けされています。
* 調整ポイントの値は、コネクタ形状の幅/高さの割合を反映しています。 
  * 形状は、コネクタの始点と終点によって1000倍されます。 
  * 最初のポイント、2番目のポイント、および3番目のポイントは、それぞれ幅からの割合、高さからの割合、および再度幅からの割合を定義します。
* コネクタの調整ポイントの座標を決定する計算では、コネクタの回転とその反射を考慮する必要があります。**注意**：**[コネクタの種類](/slides/ja/cpp/connector/#types-of-connectors)**の下にあるすべてのコネクタの回転角度は0です。

#### **ケース 1**

テキストフレームオブジェクトがコネクタを通じて結合されているケースを考慮します：

![connector-shape-complex](connector-shape-complex.png)

コード：

```c++
// PPTXファイルを表すプレゼンテーションクラスをインスタンス化します
auto pres = System::MakeObject<Presentation>();
// プレゼンテーションの最初のスライドを取得します
auto slide = pres->get_Slides()->idx_get(0);
// 最初のスライドから図形を取得します
auto shapes = slide->get_Shapes();
// コネクタを介して結合される図形を追加します
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

// コネクタで図形を結びます
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

コネクタの調整ポイントの値を、幅と高さの割合をそれぞれ20％および200％増加させることで変更できます：

```c++
// 調整ポイントの値を変更します
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

結果：

![connector-adjusted-1](connector-adjusted-1.png)

コネクタの個々の部分の座標と形状を決定するモデルを定義するために、コネクタのconnector.Adjustments[0]ポイントに対応する形状を作成しましょう：

```c++
// コネクタの垂直コンポーネントを描画する
float x = connector->get_X() + connector->get_Width() * adjValue_0->get_RawValue() / 100000;
float y = connector->get_Y();
float height = connector->get_Height() * adjValue_1->get_RawValue() / 100000;
shapes->AddAutoShape(ShapeType::Rectangle, x, y, 0.0f, height);
```

結果：

![connector-adjusted-2](connector-adjusted-2.png)

#### **ケース 2**

**ケース 1**では、基本的な原則を用いた単純なコネクタ調整操作を示しました。通常の状況では、コネクタの回転とその表示（これはconnector.Rotation、connector.Frame.FlipH、およびconnector.Frame.FlipVによって設定されます）を考慮する必要があります。これからそのプロセスを示します。

まず、接続目的のために新しいテキストフレームオブジェクト（**To 1**）をスライドに追加し、既に作成したオブジェクトに接続する新しい（緑の）コネクタを作成します。

```c++
// 新しい結合オブジェクトを作成します
auto shapeTo_1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 400.0f, 60.0f, 25.0f);
shapeTo_1->get_TextFrame()->set_Text(u"To 1");
// 新しいコネクタを作成します
connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
lineFormat->set_Width(3);
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_MediumAquamarine());
// 新たに作成したコネクタを使用してオブジェクトを接続します
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

結果：

![connector-adjusted-3](connector-adjusted-3.png)

次に、新しいコネクタの調整ポイントconnector.Adjustments[0]を通過するコネクタの水平方向のコンポーネントに該当する形状を作成します。コネクタデータの値を使用し、connector.Rotation、connector.Frame.FlipH、およびconnector.Frame.FlipVから値を取得し、指定された点x0を中心に回転するための一般的な座標変換式を適用します：

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

私たちのケースでは、オブジェクトの回転角度は90度で、コネクタは垂直に表示されるため、対応するコードは次のとおりです：

```c++
// 特定のスライド座標に基づいてコネクタの調整ポイント値を設定するモデルを開発できます。
```

結果：

![connector-adjusted-4](connector-adjusted-4.png)

単純な調整や複雑な調整ポイント（回転角度を持つ調整ポイント）を含む計算を示しました。得られた知識を使って、`GraphicsPath`オブジェクトを取得したり、特定のスライド座標に基づいてコネクタの調整ポイント値を設定する自分のモデル（またはコード）を開発することができます。

## **コネクタ線の角度を求める**

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/)クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。
1. コネクタ線形状にアクセスします。
1. 線の幅、高さ、形状のフレームの高さ、および形状のフレームの幅を使用して角度を計算します。

このC++コードは、コネクタ線形状の角度を計算する操作を示しています：

```c++
void ConnectorLineAngle()
{

	// ドキュメントディレクトリへのパス。
	const String outPath = u"../out/ConnectorLineAngle_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// 必要なプレゼンテーションを読み込みます。
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// 最初のスライドにアクセスします。
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	for (int i = 0; i < slide->get_Shapes()->get_Count(); i++)
	{
		double dir = 0.0;
		// スライドの図形コレクションにアクセスします。
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