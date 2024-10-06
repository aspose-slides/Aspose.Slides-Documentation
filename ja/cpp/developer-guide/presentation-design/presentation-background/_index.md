---
title: プレゼンテーションの背景
type: docs
weight: 20
url: /ja/cpp/presentation-background/
keywords: "PowerPoint 背景, 背景設定"
description: "CPP で PowerPoint プレゼンテーションの背景を設定する"
---

スライドの背景画像には、単色、グラデーションカラー、画像がよく使用されます。背景は**通常のスライド**（単一スライド）または**マスタースライド**（複数スライドを同時に）に設定できます。

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **通常スライドの背景に単色を設定する**

Aspose.Slides を使用すると、プレゼンテーションの特定のスライドの背景として単色を設定できます（たとえそのプレゼンテーションにマスタースライドが含まれていても）。背景変更は選択したスライドのみに影響します。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
2. スライドの [BackgroundType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a811de442ed9b0c175aa4dce66d0ba246) 列挙型を `OwnBackground` に設定します。
3. スライド背景の [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) 列挙型を `Solid` に設定します。
4. [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format) によって公開されている [SolidFillColor](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a13c48eebf434d92f4c0058796ea15810) プロパティを使用して、背景としての単色を指定します。
5. 変更したプレゼンテーションを保存します。

この C++ コードは、通常スライドの背景に単色（青）を設定する方法を示しています：

```c++
// ドキュメント ディレクトリへのパス。

	const String OutPath = L"../out/SetSlideBackgroundNormal_out.pptx";

	// Presentation クラスのインスタンスを作成
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 最初の ISlide の背景色を青に設定
	pres->get_Slides()->idx_get(0)->get_Background()->set_Type(BackgroundType::OwnBackground);
	pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
	pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	// プレゼンテーションをディスクに書き込む
	pres->Save(OutPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **マスタースライドの背景に単色を設定する**

Aspose.Slides を使用すると、プレゼンテーションのマスタースライドの背景として単色を設定できます。マスタースライドは、すべてのスライドのフォーマット設定を含み、制御するテンプレートとして機能します。したがって、マスタースライドの背景として単色を選択すると、その新しい背景がすべてのスライドに使用されます。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
2. マスタースライド（`Masters`）の [BackgroundType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a811de442ed9b0c175aa4dce66d0ba246) 列挙型を `OwnBackground` に設定します。
3. マスタースライド背景の [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) 列挙型を `Solid` に設定します。
4. [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format) によって公開されている [SolidFillColor](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a13c48eebf434d92f4c0058796ea15810) プロパティを使用して、背景としての単色を指定します。
5. 変更したプレゼンテーションを保存します。

この C++ コードは、プレゼンテーションのマスタースライドの背景に単色（フォレストグリーン）を設定する方法を示しています：

```c++
	// ドキュメント ディレクトリへのパス。

	const String OutPath = L"../out/SetSlideBackgroundMaster_out.pptx";

	// Presentation クラスのインスタンスを作成
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// マスタ ISlide の背景色をフォレストグリーンに設定
	pres->get_Masters()->idx_get(0)->get_Background()->set_Type(BackgroundType::OwnBackground);
	pres->get_Masters()->idx_get(0)->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
	pres->get_Masters()->idx_get(0)->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_ForestGreen());

	// プレゼンテーションをディスクに書き込む
	pres->Save(OutPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **スライドの背景にグラデーションカラーを設定する**

グラデーションは、色の段階的な変化に基づくグラフィカルエフェクトです。スライドの背景としてグラデーションカラーを使用すると、プレゼンテーションが芸術的でプロフェッショナルに見えます。Aspose.Slidesを使用すると、プレゼンテーションのスライドの背景としてグラデーションカラーを設定できます。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
2. スライドの [BackgroundType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a811de442ed9b0c175aa4dce66d0ba246) 列挙型を `OwnBackground` に設定します。
3. マスタースライド背景の [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) 列挙型を `Gradient` に設定します。
4. [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format) によって公開されている [GradientFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#aa686ab9c84e7e20e65dfe73458f1a823) プロパティを使用して、お好みのグラデーション設定を指定します。
5. 変更したプレゼンテーションを保存します。

この C++ コードは、スライドの背景にグラデーションカラーを設定する方法を示しています：

```c++
// Presentation クラスのインスタンスを作成
auto pres = System::MakeObject<Presentation>(u"SetBackgroundToGradient.pptx");

// 背景にグラデーション効果を適用
pres->get_Slides()->idx_get(0)->get_Background()->set_Type(BackgroundType::OwnBackground);
pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// プレゼンテーションをディスクに書き込む
pres->Save(u"ContentBG_Grad_out.pptx", SaveFormat::Pptx);
```

## **スライドの背景に画像を設定する**

単色やグラデーションカラーの他に、Aspose.Slidesは、プレゼンテーションのスライドの背景として画像を設定することもできます。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
2. スライドの [BackgroundType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a811de442ed9b0c175aa4dce66d0ba246) 列挙型を `OwnBackground` に設定します。
3. マスタースライド背景の [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) 列挙型を `Picture` に設定します。
4. スライドの背景として使用したい画像を読み込みます。
5. 画像をプレゼンテーションの画像コレクションに追加します。
6. [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format) によって公開されている [PictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a7f2b7e6afce822667cecd3e80336bfae) プロパティを使用して、画像を背景として設定します。
7. 変更したプレゼンテーションを保存します。

この C++ コードは、スライドの背景に画像を設定する方法を示しています：

```c++
// ドキュメント ディレクトリへのパス。

const String templatePath = L"../templates/SetImageAsBackground.pptx";
const String imagePath = L"../templates/Tulips.jpg";
const String outPath = L"../out/ContentBG_Img_out.pptx";

// Presentation クラスのインスタンスを作成
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 背景画像の条件を設定
pres->get_Slides()->idx_get(0)->get_Background()->set_Type(BackgroundType::OwnBackground);
pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// 画像を読み込む
auto image = Images::FromFile(imagePath);

// 画像をプレゼンテーションの画像コレクションに追加
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// プレゼンテーションをディスクに書き込む
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

### **背景画像の透明度を変更する**

スライドの背景画像の透明度を調整して、スライドの内容を目立たせたい場合があります。この C++ コードは、スライド背景画像の透明度を変更する方法を示しています：

```c++
int32_t transparencyValue = 30;
// たとえば
// 画像変換操作のコレクションを取得
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();
// 固定パーセンテージの透明度効果を見つける。
System::SharedPtr<AlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (System::ObjectExt::Is<AlphaModulateFixed>(operation))
    {
        transparencyOperation = System::ExplicitCast<AlphaModulateFixed>(operation);
        break;
    }
}
// 新しい透明度値を設定します。
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}
```

## **スライド背景の値を取得する**

Aspose.Slides は、スライド背景の効果的な値を取得するために [IBackgroundEffectiveData](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_background_effective_data/) インターフェースを提供します。このインターフェースには、効果的な [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_background_effective_data#a097ba368423bf4a9ab7a6a61870bfc8e) と効果的な [EffectFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_background_effective_data#a446676281ac4195cb7eb989e4a8110f8) に関する情報が含まれています。

[BaseSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.base_slide/) クラスの [Background](https://reference.aspose.com/slides/cpp/class/aspose.slides.base_slide#ac12d4a7683bf6fa20b3eef387219cf16) プロパティを使用して、スライド背景の効果的な値を取得できます。

この C++ コードは、スライドの効果的な背景値を取得する方法を示しています：

```c++
// Presentation クラスのインスタンスを作成
const String templatePath = u"../templates/SamplePresentation.pptx";
	

	auto pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<IBackgroundEffectiveData> effBackground = pres->get_Slides()->idx_get(0)->CreateBackgroundEffective();
	if (effBackground->get_FillFormat()->get_FillType() == Aspose::Slides::FillType::Solid)
	{
		System::Console::WriteLine(System::String(u"塗りつぶし色: ") + effBackground->get_FillFormat()->get_SolidFillColor());
	}
	else
	{
		System::Console::WriteLine(System::String(u"塗りつぶしタイプ: ") + System::ObjectExt::ToString(effBackground->get_FillFormat()->get_FillType()));
	}
```