---
title: C++ を使用したプレゼンテーションでの画像フレーム管理
linktitle: 画像フレーム
type: docs
weight: 10
url: /ja/cpp/picture-frame/
keywords:
- 画像フレーム
- 画像フレームを追加
- 画像フレームを作成
- 画像を追加
- 画像を作成
- 画像を抽出
- ラスター画像
- ベクター画像
- 画像をトリミング
- トリミング領域
- StretchOff プロパティ
- 画像フレームの書式設定
- 画像フレームのプロパティ
- 相対スケール
- 画像効果
- アスペクト比
- 画像の透明度
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PowerPoint および OpenDocument のプレゼンテーションに画像フレームを追加します。ワークフローを効率化し、スライドデザインを向上させましょう。"
---
## **概要**

Picture Frame は画像を含むシェイプです。フレーム内の画像と同様のイメージです。

スライドに画像を追加するには Picture Frame を使用します。これにより、Picture Frame を書式設定することで画像の書式設定が可能になります。

{{% alert  title="Tip" color="info" %}} 
Aspose は無料コンバータ―—[JPEG to PowerPoint](https://products.aspose.app/slides/ja/import/jpg-to-ppt) と [PNG to PowerPoint](https://products.aspose.app/slides/ja/import/png-to-ppt)—を提供しており、画像から素早くプレゼンテーションを作成できます。 
{{% /alert %}} 

## **Picture Frame の作成**

1. [Presentation クラス](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.presentation) のインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。 
3. プレゼンテーション オブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_image_collection) に画像を追加し、[IPPImage](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_p_p_image) オブジェクトを作成します。この画像がシェイプの塗りつぶしに使用されます。
4. 画像の幅と高さを指定します。
5. 参照スライドに関連付けられたシェイプ オブジェクトの `AddPictureFrame` メソッドを使用して、画像の幅と高さに基づく [PictureFrame](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.picture_frame) を作成します。
6. スライドにピクチャーフレーム（画像を含む）を追加します。
7. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この C++ コードは Picture Frame の作成方法を示しています:

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
#include <drawing/color.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// ドキュメント ディレクトリへのパス。
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// 目的のプレゼンテーションをロードする
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセスする
SharedPtr<ISlide> slide = pres->get_Slide(0);

// プレゼンテーションの画像コレクションに追加される画像をロードする
// 画像を取得する
auto image = Images::FromFile(filePath);

// プレゼンテーションの画像コレクションに画像を追加する
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// スライドに画像フレームを追加する
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// 相対スケールの幅と高さを設定する
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// PictureFrame にいくつかの書式設定を適用する
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

//PPTX ファイルをディスクに書き込む
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 
Picture Frame を使用すると、画像ベースのプレゼンテーション スライドをすばやく作成できます。Picture Frame と Aspose.Slides の保存オプションを組み合わせることで、画像の入力/出力操作を操作し、フォーマット間の変換が可能です。以下のページもご参照ください: 画像を [JPG に変換](https://products.aspose.com/slides/ja/cpp/conversion/image-to-jpg/); [JPG から画像に変換](https://products.aspose.com/slides/ja/cpp/conversion/jpg-to-image/); [JPG から PNG に変換](https://products.aspose.com/slides/ja/cpp/conversion/jpg-to-png/)、[PNG から JPG に変換](https://products.aspose.com/slides/ja/cpp/conversion/png-to-jpg/); [PNG から SVG に変換](https://products.aspose.com/slides/ja/cpp/conversion/png-to-svg/)、[SVG から PNG に変換](https://products.aspose.com/slides/ja/cpp/conversion/svg-to-png/)。 
{{% /alert %}}

## **相対スケールを使用した Picture Frame の作成**

画像の相対スケーリングを変更すると、より複雑な Picture Frame を作成できます。 

1. [Presentation クラス](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.presentation) のインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。 
3. プレゼンテーションの画像コレクションに画像を追加します。
4. プレゼンテーション オブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_image_collection) に画像を追加し、[IPPImage](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_p_p_image) オブジェクトを作成します。
5. ピクチャーフレーム内で画像の相対幅と高さを指定します。
6. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この C++ コードは相対スケールを使用した Picture Frame の作成方法を示しています:

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// ドキュメント ディレクトリへのパス。
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// 目的のプレゼンテーションをロードする
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセスする
SharedPtr<ISlide> slide = pres->get_Slide(0);

// プレゼンテーションの画像コレクションに追加される画像をロードする
// 画像を取得する
auto image = Images::FromFile(filePath);

// プレゼンテーションの画像コレクションに画像を追加する
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// スライドに画像フレームを追加する
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// 相対スケールの幅と高さを設定する
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//PPTX ファイルをディスクに書き込む
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Picture Frame からラスタ画像を抽出する**

[PictureFrame](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.picture_frame) オブジェクトからラスタ画像を抽出し、PNG、JPG などの形式で保存できます。以下のコード例は、ドキュメント「sample.pptx」から画像を抽出し、PNG 形式で保存する方法を示しています。

```c++
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstSlide = presentation->get_Slide(0);
auto firstShape = firstSlide->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(firstShape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(firstShape);
    auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_Image();

    image->Save(u"slide_1_shape_1.png", ImageFormat::Png);
}

presentation->Dispose();
```

## **Picture Frame から SVG 画像を抽出する**

プレゼンテーションに SVG グラフィックが [PictureFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/pictureframe/) シェイプ内に配置されている場合、Aspose.Slides for C++ は元のベクター画像を完全に忠実に取得できます。スライドのシェイプ コレクションを走査し、各 [PictureFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/pictureframe/) を特定し、基になる [IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/) が SVG コンテンツを保持しているか確認し、必要に応じてその画像をディスクまたはストリームにネイティブ SVG 形式で保存します。

以下のコード例は Picture Frame から SVG 画像を抽出する方法を示しています:

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(shape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto svgImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SvgImage();
    if (svgImage != nullptr)
    {
        File::WriteAllText(u"output.svg", svgImage->get_SvgContent());
    }
}

presentation->Dispose();
```

## **画像の透明度を取得する**

Aspose.Slides を使用すると、画像に適用された透明度効果を取得できます。この C++ コードはその操作を示しています:

```c++
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"Test.pptx");
auto pictureFrame = System::ExplicitCast<IPictureFrame>(presentation->get_Slide(0)->get_Shape(0));
auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<IAlphaModulateFixed>(effect))
    {
        float transparencyValue = 100.0f - (System::ExplicitCast<IAlphaModulateFixed>(effect))->get_Amount();
        System::Console::WriteLine(System::String(u"Picture transparency: ") + transparencyValue);
    }
}
```

{{% alert color="info" %}} 
画像に適用されたすべての効果は [Aspose::Slides::Effects](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/) で確認できます。 
{{% /alert %}}

## **画像の明るさとコントラストを取得する**

Aspose.Slides を使用すると、画像に適用された明るさとコントラストの効果を取得できます。これらの画像変換効果は [ILuminance](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/iluminance/) インターフェイスで表現されます。

この C++ コードは Picture Frame から明るさとコントラスト設定を取得する方法を示しています:

```c++
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shape(0);
auto pictureFrame = System::ExplicitCast<IPictureFrame>(shape);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<ILuminance>(effect))
    {
        auto luminance = System::ExplicitCast<ILuminance>(effect)->GetEffective();
        auto brightness = luminance->get_Brightness();
        auto contrast = luminance->get_Contrast();

        Console::WriteLine(System::String(u"Brightness: ") + brightness);
        Console::WriteLine(System::String(u"Contrast: ") + contrast);
    }
}

presentation->Dispose();
```

## **Picture Frame の書式設定**

Aspose.Slides は Picture Frame に適用できる多数の書式設定オプションを提供します。これらのオプションを使用すると、特定の要件に合わせて Picture Frame を変更できます。

1. [Presentation クラス](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.presentation) のインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。 
3. プレゼンテーション オブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_image_collection) に画像を追加し、[IPPImage](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_p_p_image) オブジェクトを作成します。
4. 画像の幅と高さを指定します。
5. 参照スライドに関連付けられた [IShapes](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_shape_collection) オブジェクトの [AddPictureFrame](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) メソッドを使用して、画像の幅と高さに基づく `PictureFrame` を作成します。
6. スライドにピクチャーフレーム（画像を含む）を追加します。
7. ピクチャーフレームの線の色を設定します。
8. ピクチャーフレームの線幅を設定します。
9. 正の値または負の値を指定してピクチャーフレームを回転させます。
   * 正の値は時計回りに回転します。 
   * 負の値は反時計回りに回転します。
10. ピクチャーフレーム（画像を含む）をスライドに再度追加します。
11. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この C++ コードは Picture Frame の書式設定プロセスを示しています:

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// ドキュメント ディレクトリへのパス。
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// 目的のプレゼンテーションをロードする
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセスする
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// プレゼンテーションの画像コレクションに追加される画像をロードする
// 画像を取得する
auto image = Images::FromFile(filePath);

// プレゼンテーションの画像コレクションに画像を追加する
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// スライドに画像フレームを追加する
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// 相対スケールの幅と高さを設定する
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//PPTX ファイルをディスクに書き込む
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Tip" color="info" %}}

Aspose は最近、無料の [Collage Maker](https://products.aspose.app/slides/ja/collage) を提供開始しました。JPG/JPEG や PNG 画像を [結合](https://products.aspose.app/slides/ja/collage/jpg) したり、[写真からグリッドを作成](https://products.aspose.app/slides/ja/collage/photo-grid) したい場合にご利用ください。 
{{% /alert %}}

## **画像をリンクとして追加する**

プレゼンテーションのサイズが大きくなるのを防ぐため、ファイルを直接埋め込む代わりにリンク経由で画像（または動画）を追加できます。この C++ コードはプレースホルダーに画像と動画を追加する方法を示しています:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IVideoFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/collections/list.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

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

## **画像のトリミング**

この C++ コードはスライド上の既存画像をトリミングする方法を示しています: 

```CPP
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
// 新しい画像オブジェクトを作成します
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(u"image.png"));

// スライドに PictureFrame を追加します
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// 画像をトリミングします（パーセンテージ値）
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// 結果を保存します
presentation->Save(u"cropped.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Picture Frame のトリミング領域を削除する**

フレーム内に含まれる画像のトリミング領域を削除したい場合は、[IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) メソッドを使用できます。このメソッドはトリミングされた画像またはトリミングが不要な場合は元の画像を返します。

この C++ コードはその操作を示しています: 

```c++
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// 最初のスライドから PictureFrame を取得します
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// PictureFrame 画像のトリミング領域を削除し、トリミングされた画像を返します
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// 結果を保存します
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="NOTE" color="warning" %}} 
[IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) メソッドはトリミングされた画像をプレゼンテーションの画像コレクションに追加します。画像が処理された [PictureFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/pictureframe/) のみで使用されている場合、プレゼンテーションのサイズを削減できます。そうでない場合、結果として生成されるプレゼンテーションの画像数が増加します。

このメソッドはトリミング操作中に WMF/EMF メタファイルをラスタ PNG 画像に変換します。 
{{% /alert %}}

## **画像の圧縮**

[IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipicturefillformat/compressimage/) メソッドを使用して、プレゼンテーション内の画像を圧縮できます。このメソッドはシェイプのサイズと指定された解像度に基づいて画像サイズを縮小し、トリミング領域を削除するオプションも提供します。

PowerPoint の **Picture Format → Compress Pictures → Resolution** 機能と同様に、画像のサイズと解像度を調整します。

以下の C++ 例は、目標解像度を指定し、必要に応じてトリミング領域を削除してプレゼンテーション内の画像を圧縮する方法を示しています:

```c++
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// 画像を目標解像度 150 DPI（Web 解像度）で圧縮し、トリミング領域を削除します。
bool result = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);

// 圧縮の結果を確認します。
if (result)
{
    System::Console::WriteLine(u"Image successfully compressed.");
}
else
{
    System::Console::WriteLine(u"Image compression failed or no changes were necessary.");
}

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

またはカスタム DPI 値を直接使用する場合:

```c++
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// 画像を 150 DPI（ウェブ解像度）に圧縮し、トリミング領域を削除します。
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}

このメソッドはシェイプのサイズと提供された DPI に基づいて画像を低解像度に変換します。トリミング領域も削除でき、ファイルサイズを最適化します。画像がメタファイル (WMF/EMF) または SVG の場合、圧縮は適用されません。また、JPEG の品質は解像度に応じて維持または若干低下します（PowerPoint の動作と同様）。 
{{% /alert %}}

## **アスペクト比をロックする**

画像を含むシェイプのサイズを変更したときにアスペクト比を保持したい場合は、[set_AspectRatioLocked()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) メソッドを使用して *Lock Aspect Ratio* 設定を有効にします。 

この C++ コードはシェイプのアスペクト比をロックする方法を示しています:

```c++
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// set shape to have to preserve aspect ratio on resizing
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="NOTE" color="warning" %}} 
*Lock Aspect Ratio* 設定はシェイプ自体のアスペクト比のみを保持し、シェイプに含まれる画像の比率は保持しません。 
{{% /alert %}}

## **StretchOff プロパティの使用**

[IPictureFillFormat](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_picture_fill_format) インターフェイスと [PictureFillFormat](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.picture_fill_format) クラスの [StretchOffsetLeft](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471)、[StretchOffsetTop](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a)、[StretchOffsetRight](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) および [StretchOffsetBottom](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) プロパティを使用すると、塗りつぶし矩形を指定できます。 

画像のストレッチが指定されると、ソース矩形が指定された塗りつぶし矩形に合わせてスケーリングされます。塗りつぶし矩形の各辺は、シェイプのバウンディングボックスの対応する辺からのパーセンテージオフセットで定義されます。正のパーセンテージはインセット、負のパーセンテージはアウトセットを表します。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. 四角形 `AutoShape` を追加します。 
4. 画像を作成します。
5. シェイプの塗りつぶしタイプを設定します。
6. シェイプの画像塗りつぶしモードを設定します。
7. シェイプを塗りつぶす画像を設定します。
8. 画像のオフセットをシェイプのバウンディングボックスの対応する辺から指定します。
9. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この C++ コードは StretchOff プロパティを使用したプロセスを示しています:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// 画像をシェイプ本体の各側から伸張するように設定します
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **FAQ**

### PictureFrame がサポートする画像フォーマットはどのように確認できますか？

Aspose.Slides は、[PictureFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/pictureframe/) に割り当てられる画像オブジェクトを通じて、ラスタ画像（PNG、JPEG、BMP、GIF など）とベクター画像（たとえば SVG）の両方をサポートします。サポートされるフォーマットの一覧は、スライドおよび画像変換エンジンの機能と概ね一致します。

### 大量の高解像度画像を追加すると PPTX のサイズとパフォーマンスにどのような影響がありますか？

画像を埋め込むとファイルサイズとメモリ使用量が増加します。画像をリンクとして追加するとプレゼンテーションのサイズを抑えられますが、外部ファイルが常にアクセス可能である必要があります。Aspose.Slides はリンクで画像を追加する機能を提供し、ファイルサイズを削減します。

### 画像オブジェクトが誤って移動・サイズ変更されるのを防ぐには？

[PictureFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/pictureframe/) の [shape locks](https://reference.aspose.com/slides/ja/cpp/aspose.slides/pictureframe/get_pictureframelock/) を使用します（例: 移動やサイズ変更の無効化）。ロック機構は別の記事の [保護に関する記事](/slides/ja/cpp/applying-protection-to-presentation/) で説明されており、PictureFrame を含むさまざまなシェイプタイプでサポートされています。

### SVG ベクターの忠実度は PDF や画像へのエクスポート時に保持されますか？

Aspose.Slides は [PictureFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/pictureframe/) から SVG を元のベクターとして抽出できます。PDF (/slides/ja/cpp/convert-powerpoint-to-pdf/) やラスタ形式 (/slides/ja/cpp/convert-powerpoint-to-png/) にエクスポートする際の設定次第で、結果がラスタ化される場合がありますが、抽出時にベクターデータが保持されていることが確認できます。