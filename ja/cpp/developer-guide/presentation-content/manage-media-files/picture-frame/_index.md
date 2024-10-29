---
title: ピクチャーフレーム
type: docs
weight: 10
url: /ja/cpp/picture-frame/
keywords: "ピクチャーフレームを追加, ピクチャーフレームを作成, 画像を追加, 画像を作成, 画像を抽出, StretchOffプロパティ, ピクチャーフレームのフォーマット, ピクチャーフレームのプロパティ, PowerPointプレゼンテーション, C++, CPP, Aspose.Slides for C++"
description: "C++でPowerPointプレゼンテーションにピクチャーフレームを追加"
---

ピクチャーフレームは画像を含む形状であり、フレームに入った写真のようなものです。

ピクチャーフレームを通じてスライドに画像を追加できます。この方法で、ピクチャーフレームのフォーマットを使って画像のフォーマットを行うことができます。

{{% alert title="ヒント" color="primary" %}}

Asposeは無料のコンバータを提供しています—[JPEGからPowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt)および[PNGからPowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—これにより、画像から迅速にプレゼンテーションを作成できます。

{{% /alert %}}

## **ピクチャーフレームの作成**

1. [Presentationクラス](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)のインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. プレゼンテーションオブジェクトに関連付けられた[IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection)に画像を追加することで[IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image)オブジェクトを作成します。これは形状を埋めるために使用されます。
4. 画像の幅と高さを指定します。
5. 参照されたスライドに関連付けられた形状オブジェクトによって公開されている`AddPictureFrame`メソッドを通じて、画像の幅と高さに基づいて[PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_frame)を作成します。
6. スライドにピクチャーフレーム（画像を含む）を追加します。
7. 修正されたプレゼンテーションをPPTXファイルとして書き出します。

このC++コードは、ピクチャーフレームを作成する方法を示しています：

```c++
// ドキュメントディレクトリへのパス
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// 希望するプレゼンテーションを読み込みます
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセスします
SharedPtr<ISlide> slide = pres->get_Slide(0);

// プレゼンテーションの画像コレクションに追加される画像を読み込みます
// 画像を取得します
auto image = Images::FromFile(filePath);

// プレゼンテーションの画像コレクションに画像を追加します
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// スライドにピクチャーフレームを追加します
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// 相対スケールの幅と高さを設定します
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// PictureFrameにいくつかのフォーマットを適用します
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width(20);
pf->set_Rotation(45);

// PPTXファイルをディスクに書き出します
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}}

ピクチャーフレームは、画像に基づいてプレゼンテーションスライドを迅速に作成することを可能にします。ピクチャーフレームとAspose.Slidesの保存オプションを組み合わせることで、入力/出力操作を操作し、他の形式から画像を変換することができます。これらのページを確認することをお勧めします：画像を[JPGに変換](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/)；[JPGを画像に変換](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/)；[JPGをPNGに変換](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/)、[PNGをJPGに変換](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/)；[PNGをSVGに変換](https://products.aspose.com/slides/cpp/conversion/png-to-svg/)、[SVGをPNGに変換](https://products.aspose.com/slides/cpp/conversion/svg-to-png/)。

{{% /alert %}}

## **相対スケールを用いたピクチャーフレームの作成**

画像の相対スケーリングを変更することで、より複雑なピクチャーフレームを作成できます。

1. [Presentationクラス](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)のインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. プレゼンテーションの画像コレクションに画像を追加します。
4. プレゼンテーションオブジェクトに関連付けられた[IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection)に画像を追加することで[IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image)オブジェクトを作成します。
5. ピクチャーフレームにおける画像の相対幅と高さを指定します。
6. 修正されたプレゼンテーションをPPTXファイルとして書き出します。

このC++コードは、相対スケールを使用してピクチャーフレームを作成する方法を示しています：

```c++
// ドキュメントディレクトリへのパス。
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// 希望するプレゼンテーションを読み込みます
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセスします
SharedPtr<ISlide> slide = pres->get_Slide(0);

// プレゼンテーションの画像コレクションに追加される画像を読み込みます
// 画像を取得します
auto image = Images::FromFile(filePath);

// プレゼンテーションの画像コレクションに画像を追加します
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// スライドにピクチャーフレームを追加します
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// 相対スケールの幅と高さを設定します
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);

// PPTXファイルをディスクに書き出します
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **ピクチャーフレームから画像を抽出**

[PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_frame)オブジェクトから画像を抽出し、PNG、JPG、その他の形式で保存できます。以下のコード例は、ドキュメント「sample.pptx」から画像を抽出してPNG形式で保存する方法を示しています。

```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstSlide = presentation->get_Slide(0);
auto firstShape = firstSlide->get_Shape(0);
    
if (ObjectExt::Is<IPictureFrame>(firstShape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(firstShape);
    auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SystemImage();

    image->Save(u"slide_1_shape_1.png", ImageFormat::get_Png());
}

presentation->Dispose();
```

## **画像の透明度を取得**

Aspose.Slidesを使用すると、画像の透明度を取得できます。このC++コードはその操作を示しています：

```c++
auto presentation = System::MakeObject<Presentation>(u"Test.pptx");
auto pictureFrame = System::ExplicitCast<IPictureFrame>(presentation->get_Slide(0)->get_Shape(0));
auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<IAlphaModulateFixed>(effect))
    {
        float transparencyValue = 100.0f - (System::ExplicitCast<IAlphaModulateFixed>(effect))->get_Amount();
        System::Console::WriteLine(System::String(u"画像の透明度: ") + transparencyValue);
    }
}
```

## **ピクチャーフレームのフォーマッティング**

Aspose.Slidesは、ピクチャーフレームに適用できる多くのフォーマットオプションを提供します。これらのオプションを使用して、ピクチャーフレームを特定の要件に合わせて変更できます。

1. [Presentationクラス](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)のインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. プレゼンテーションオブジェクトに関連付けられた[IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection)に画像を追加することで[IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image)オブジェクトを作成します。
4. 画像の幅と高さを指定します。
5. [IShapes](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection)オブジェクトに関連付けられた参照されたスライド用の[AddPictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9)メソッドを通じて、画像の幅と高さに基づいて`PictureFrame`を作成します。
6. スライドにピクチャーフレーム（画像を含む）を追加します。
7. ピクチャーフレームの線の色を設定します。
8. ピクチャーフレームの線の幅を設定します。
9. ピクチャーフレームを正または負の値を与えて回転させます。
   * 正の値は画像を時計回りに回転させます。 
   * 負の値は画像を反時計回りに回転させます。
10. スライドにピクチャーフレーム（画像を含む）を追加します。
11. 修正されたプレゼンテーションをPPTXファイルとして書き出します。

このC++コードは、ピクチャーフレームのフォーマッティングプロセスを示します：

```c++
// ドキュメントディレクトリへのパス。
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// 希望するプレゼンテーションを読み込みます
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセスします
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// プレゼンテーションの画像コレクションに追加される画像を読み込みます
// 画像を取得します
auto image = Images::FromFile(filePath);

// プレゼンテーションの画像コレクションに画像を追加します
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// スライドにピクチャーフレームを追加します
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// 相対スケールの幅と高さを設定します
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);

// PPTXファイルをディスクに書き出します
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="ヒント" color="primary" %}}

Asposeは最近、[無料のコラージュメーカー](https://products.aspose.app/slides/collage)を開発しました。JPG/JPEGを[統合](https://products.aspose.app/slides/collage/jpg)したり、写真から[グリッドを作成](https://products.aspose.app/slides/collage/photo-grid)する必要がある場合は、このサービスを利用できます。

{{% /alert %}}

## **リンクとして画像を追加**

大きなプレゼンテーションサイズを避けるために、画像（またはビデオ）をファイルをプレゼンテーションに直接埋め込むのではなく、リンクを通じて追加できます。このC++コードは、プレースホルダに画像とビデオを追加する方法を示しています：

```cpp
auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapesToRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IShape>>>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

for (auto& autoShape : shapes)
{
    if (autoShape->get_Placeholder() == nullptr)
        continue;

    switch (autoShape->get_Placeholder()->get_Type())
    {
        case Aspose::Slides::PlaceholderType::Picture:
        {
            auto pictureFrame = shapes->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), nullptr);
            pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            shapesToRemove->Add(autoShape);
            break;
        }

        case Aspose::Slides::PlaceholderType::Media:
        {
            auto videoFrame = shapes->AddVideoFrame(autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), u"");
            videoFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            videoFrame->set_LinkPathLong(u"https://youtu.be/t_1LYZ102RA");
            shapesToRemove->Add(autoShape);
            break;
        }
    }
}

for (auto& shape : shapesToRemove)
{
    shapes->Remove(shape);
}

presentation->Save(u"output.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **画像をトリミング**

このC++コードは、スライド上にある既存の画像をトリミングする方法を示しています：

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// 新しい画像オブジェクトを作成します
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// スライドにPictureFrameを追加します
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// 画像をトリミングします（パーセンテージ値）
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// 結果を保存します
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **トリミングされた領域を画像から削除**

フレーム内の画像のトリミングされた領域を削除したい場合は、[IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/)メソッドを使用できます。このメソッドは、トリミングされた画像またはトリミングが不要な場合は元の画像を返します。

このC++コードは、その操作を示しています：

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// 最初のスライドからPictureFrameを取得します
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// PictureFrame画像のトリミングされた領域を削除し、トリミングされた画像を返します
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// 結果を保存します
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="注意" color="warning" %}}

[IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/)メソッドは、トリミングされた画像をプレゼンテーション画像コレクションに追加します。画像が処理された[PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/)でのみ使用される場合、この設定はプレゼンテーションのサイズを減少させることができます。そうでない場合、結果のプレゼンテーション内の画像の数は増加します。

このメソッドは、クロッピング操作でWMF/EMFメタファイルをラスタPNG画像に変換します。

{{% /alert %}}

## **アスペクト比を固定**

画像を含む形状のアスペクト比を保持しながら画像の寸法を変更したい場合、[set_AspectRatioLocked()](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/)メソッドを使用して*アスペクト比のロック*設定を設定できます。

このC++コードは、形状のアスペクト比をロックする方法を示しています：

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// サイズ変更時にアスペクト比を保持するように形状を設定します
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="注意" color="warning" %}}

この*アスペクト比のロック*設定は、形状のアスペクト比のみを保持し、その中に含まれる画像を保持しません。

{{% /alert %}}

## **StretchOffプロパティを使用**

[StretchOffsetLeft](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471)、[StretchOffsetTop](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a)、[StretchOffsetRight](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127)および[StretchOffsetBottom](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39)プロパティを[IPictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_fill_format)インターフェースおよび[PictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format)クラスから使用することで、塗りつぶし矩形を指定できます。

画像のストレッチが指定されると、ソース矩形が指定された塗りつぶし矩形に合わせてスケールされます。塗りつぶし矩形の各辺は、形状の境界ボックスの対応する辺からのパーセントオフセットによって定義されます。正のパーセントはインセットを指定します。負のパーセントはアウトセットを指定します。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. 四角形`AutoShape`を追加します。 
4. 画像を作成します。
5. 形状の塗りつぶしタイプを設定します。
6. 形状の画像塗りつぶしモードを設定します。
7. 形状を塗りつぶすために設定された画像を追加します。
8. 形状の境界ボックスの対応する辺からの画像オフセットを指定します。
9. 修正されたプレゼンテーションをPPTXファイルとして書き出します。

このC++コードは、StretchOffプロパティを使用したプロセスを示しています：

```cpp
auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// 形状の各側から画像を引き伸ばします
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```