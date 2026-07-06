---
title: C++ を使用したプレゼンテーションでの Picture Frame の管理
linktitle: ピクチャーフレーム
type: docs
weight: 10
url: /ja/cpp/picture-frame/
keywords:
- ピクチャーフレーム
- ピクチャーフレームの追加
- ピクチャーフレームの作成
- 画像の追加
- 画像の作成
- 画像の抽出
- ラスター画像
- ベクター画像
- 画像のトリミング
- トリミング領域
- StretchOff プロパティ
- ピクチャーフレームの書式設定
- ピクチャーフレームのプロパティ
- 相対スケール
- 画像エフェクト
- アスペクト比
- 画像の透明度
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint と OpenDocument のプレゼンテーションにピクチャーフレームを追加します。ワークフローを合理化し、スライドデザインを強化しましょう。"
---
## **導入**

Picture frame は画像を含む図形で、フレーム内の画像のようなものです。  

Picture frame を使用してスライドに画像を追加できます。この方法で、Picture frame の書式設定を行うことで画像の書式設定も行えます。

{{% alert  title="Tip" color="primary" %}} 
Aspose は無料のコンバータ―（[JPEG to PowerPoint](https://products.aspose.app/slides/ja/import/jpg-to-ppt) と [PNG to PowerPoint](https://products.aspose.app/slides/ja/import/png-to-ppt)）を提供しており、画像から迅速にプレゼンテーションを作成できます。 
{{% /alert %}} 

## **Picture Frame の作成**

1. [Presentation class](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.presentation) のインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. Presentation オブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_image_collection) に画像を追加して、[IPPImage](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_p_p_image) オブジェクトを作成します。この画像はシェイプの塗りつぶしに使用されます。  
4. 画像の幅と高さを指定します。  
5. 参照されたスライドに関連付けられたシェイプ オブジェクトが提供する `AddPictureFrame` メソッドを使用して、画像の幅と高さに基づく [PictureFrame](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.picture_frame) を作成します。  
6. スライドに Picture frame（画像を含む）を追加します。  
7. 変更されたプレゼンテーションを PPTX ファイルとして保存します。  

この C++ コードは Picture frame の作成方法を示しています:

```c++
// ドキュメントディレクトリへのパスです。
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// 目的のプレゼンテーションをロードします
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセスします
SharedPtr<ISlide> slide = pres->get_Slide(0);

// プレゼンテーションの画像コレクションに追加される画像をロードします
// 画像を取得します
auto image = Images::FromFile(filePath);

// プレゼンテーションの画像コレクションに画像を追加します
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// スライドにピクチャーフレームを追加します
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// 相対スケールの幅と高さを設定します
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// PictureFrame にいくつかの書式設定を適用します
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

// PPTX ファイルをディスクに保存します
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 
Picture frame を使用すると、画像ベースのプレゼンテーション スライドを迅速に作成できます。Picture frame と Aspose.Slides の保存オプションを組み合わせることで、画像の入出力操作を操作して形式変換が可能です。以下のページも参考になるでしょう: 変換 [image to JPG](https://products.aspose.com/slides/ja/cpp/conversion/image-to-jpg/); 変換 [JPG to image](https://products.aspose.com/slides/ja/cpp/conversion/jpg-to-image/); 変換 [JPG to PNG](https://products.aspose.com/slides/ja/cpp/conversion/jpg-to-png/), 変換 [PNG to JPG](https://products.aspose.com/slides/ja/cpp/conversion/png-to-jpg/); 変換 [PNG to SVG](https://products.aspose.com/slides/ja/cpp/conversion/png-to-svg/), 変換 [SVG to PNG](https://products.aspose.com/slides/ja/cpp/conversion/svg-to-png/)。 
{{% /alert %}}

## **相対スケールを使用した Picture Frame の作成**

画像の相対スケーリングを変更することで、より複雑な Picture frame を作成できます。  

1. [Presentation class](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.presentation) のインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーションの画像コレクションに画像を追加します。  
4. Presentation オブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_image_collection) に画像を追加して、[IPPImage](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_p_p_image) オブジェクトを作成します。  
5. Picture frame 内で画像の相対的な幅と高さを指定します。  
6. 変更されたプレゼンテーションを PPTX ファイルとして保存します。  

この C++ コードは相対スケールを使用した Picture frame の作成方法を示しています:

```c++
// ドキュメントディレクトリへのパスです。
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// 目的のプレゼンテーションをロードします
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセスします
SharedPtr<ISlide> slide = pres->get_Slide(0);

// プレゼンテーションの画像コレクションに追加される画像をロードします
// 画像を取得します
auto image = Images::FromFile(filePath);

// プレゼンテーションの画像コレクションに画像を追加します
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// スライドにピクチャーフレームを追加します
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// 相対スケールの幅と高さを設定します
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//PPTX ファイルをディスクに保存します
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Picture Frame からラスタ画像を抽出**

[PictureFrame](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.picture_frame) オブジェクトからラスタ画像を抽出し、PNG、JPG などの形式で保存できます。以下のコード例は、ドキュメント「sample.pptx」から画像を抽出し、PNG 形式で保存する方法を示しています。

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

## **Picture Frame から SVG 画像を抽出**

プレゼンテーションに [PictureFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/pictureframe/) 内に配置された SVG グラフィックが含まれている場合、Aspose.Slides for C++ は元のベクタ画像を完全な忠実度で取得できます。スライドのシェイプ コレクションを走査して各 [PictureFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/pictureframe/) を特定し、基になる [IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/) が SVG コンテンツを保持しているかチェックし、ネイティブ SVG 形式でディスクまたはストリームに保存できます。

以下のコード例は Picture frame から SVG 画像を抽出する方法を示しています:

```cpp
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

## **画像の透明度取得**

Aspose.Slides を使用すると、画像に適用された透明度効果を取得できます。この C++ コードはその操作を示しています:

```c++
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

{{% alert color="primary" %}} 
画像に適用されたすべてのエフェクトは [Aspose::Slides::Effects](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/) で確認できます。 
{{% /alert %}}

## **画像の明るさとコントラストの取得**

Aspose.Slides を使用すると、画像に適用された明るさとコントラストの効果を取得できます。[ILuminance](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/iluminance/) インターフェイスはこの画像変換エフェクトを表します。

この C++ コードは Picture frame から明るさとコントラストの設定を取得する方法を示しています:

```c++
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

Aspose.Slides は Picture frame に適用できる多くの書式設定オプションを提供します。これらのオプションを使用して、特定の要件に合わせて Picture frame を調整できます。  

1. [Presentation class](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.presentation) のインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. Presentation オブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_image_collection) に画像を追加して、[IPPImage](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_p_p_image) オブジェクトを作成します。  
4. 画像の幅と高さを指定します。  
5. 参照されたスライドに関連付けられた [IShapes](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_shape_collection) オブジェクトが提供する [AddPictureFrame](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) メソッドを使用して、画像の幅と高さに基づく `PictureFrame` を作成します。  
6. スライドに Picture frame（画像を含む）を追加します。  
7. Picture frame の線の色を設定します。  
8. 線の幅を設定します。  
9. 正または負の値を指定して Picture frame を回転させます。  
   * 正の値は画像を時計回りに回転させます。  
   * 負の値は画像を反時計回りに回転させます。  
10. スライドに Picture frame（画像を含む）を追加します。  
11. 変更されたプレゼンテーションを PPTX ファイルとして保存します。  

この C++ コードは Picture frame の書式設定プロセスを示しています:

```c++
// ドキュメントディレクトリへのパスです。
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// 目的のプレゼンテーションをロードします
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセスします
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// プレゼンテーションの画像コレクションに追加される画像をロードします
// 画像を取得します
auto image = Images::FromFile(filePath);

// プレゼンテーションの画像コレクションに画像を追加します
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// スライドにピクチャーフレームを追加します
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// 相対スケールの幅と高さを設定します
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// PPTX ファイルをディスクに保存します
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Tip" color="primary" %}}
Aspose は最近、無料の Collage Maker（[Collage Maker](https://products.aspose.app/slides/ja/collage)）を開発しました。JPG/JPEG や PNG 画像の結合、写真からのグリッド作成が必要な場合は、このサービスをご利用ください。 
{{% /alert %}}

## **画像をリンクとして追加**

プレゼンテーションのサイズが大きくなるのを防ぐため、ファイルを直接埋め込む代わりにリンクを使用して画像（または動画）を追加できます。この C++ コードはプレースホルダーに画像と動画を追加する方法を示しています:

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

## **画像のトリミング**

この C++ コードはスライド上の既存画像をトリミングする方法を示しています:

``` CPP
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// 新しい画像オブジェクトを作成します
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// スライドに PictureFrame を追加します
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// 画像をトリミングします（パーセンテージ値）
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// 結果を保存します
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Picture のトリミング領域を削除**

フレームに含まれる画像のトリミング領域を削除したい場合は、[IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) メソッドを使用できます。このメソッドはトリミングが不要な場合は元画像を返します。

この C++ コードはその操作を示しています:

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Gets the PictureFrame from the first slide
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Deletes cropped areas of the PictureFrame image and returns the cropped image
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// Saves the result
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="NOTE" color="warning" %}}
[IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) メソッドはトリミングされた画像をプレゼンテーションの画像コレクションに追加します。画像が処理された [PictureFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/pictureframe/) のみで使用されている場合、この設定はプレゼンテーションのサイズ削減につながります。そうでない場合、結果のプレゼンテーションに含まれる画像の数は増加します。

このメソッドはトリミング処理中に WMF/EMF メタファイルをラスタ PNG 画像に変換します。 
{{% /alert %}}

## **画像の圧縮**

[IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipicturefillformat/compressimage/) メソッドを使用して、プレゼンテーション内の画像を圧縮できます。このメソッドはシェイプのサイズと指定された解像度に基づいて画像サイズを縮小し、トリミング領域を削除するオプションも提供します。

PowerPoint の **Picture Format → Compress Pictures → Resolution** 機能と同様に、画像のサイズと解像度を調整します。

以下の C++ 例は、対象解像度を指定し、必要に応じてトリミング領域を削除してプレゼンテーション内の画像を圧縮する方法を示しています:

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Compress the image with a target resolution of 150 DPI (Web resolution) and remove cropped areas.
bool result = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);

// Check the result of the compression.
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

またはカスタム DPI 値を直接使用する例:

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// 画像を 150 DPI (ウェブ解像度) に圧縮し、トリミング領域を削除します。
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
このメソッドはシェイプのサイズと提供された DPI に基づいて画像を低解像度に変換します。トリミングされた領域も削除可能で、ファイルサイズを最適化します。画像がメタファイル（WMF/EMF）または SVG の場合、圧縮は適用されません。また、JPEG の品質は解像度に応じて維持またはやや低下します。 
{{% /alert %}}

## **アスペクト比のロック**

画像を含むシェイプの縦横比を、画像サイズを変更した後でも保持したい場合は、[set_AspectRatioLocked()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) メソッドを使用して *Lock Aspect Ratio* 設定を行います。  

この C++ コードはシェイプのアスペクト比をロックする方法を示しています:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// リサイズ時にアスペクト比を保持するようにシェイプを設定する
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="NOTE" color="warning" %}} 
この *Lock Aspect Ratio* 設定はシェイプの縦横比のみを保持し、シェイプに含まれる画像自体の縦横比は保持しません。 
{{% /alert %}}

## **StretchOff プロパティの使用**

[IPictureFillFormat](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_picture_fill_format) インターフェイスおよび [PictureFillFormat](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.picture_fill_format) クラスの [StretchOffsetLeft](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471)、[StretchOffsetTop](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a)、[StretchOffsetRight](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) および [StretchOffsetBottom](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) プロパティを使用すると、塗りつぶし矩形を指定できます。  

画像のストレッチが指定されると、ソース矩形は指定された塗りつぶし矩形に合わせてスケーリングされます。塗りつぶし矩形の各辺は、シェイプのバウンディング ボックスの対応する辺からのパーセンテージオフセットで定義されます。正のパーセンテージはインセット、負のパーセンテージはアウトセットを表します。  

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. 四角形 `AutoShape` を追加します。  
4. 画像を作成します。  
5. シェイプの塗りつぶしタイプを設定します。  
6. シェイプの画像塗りつぶしモードを設定します。  
7. シェイプを塗りつぶす画像を設定します。  
8. シェイプのバウンディング ボックスの対応する辺からの画像オフセットを指定します。  
9. 変更されたプレゼンテーションを PPTX ファイルとして保存します。  

この C++ コードは StretchOff プロパティを使用したプロセスを示しています:

```cpp
auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// 画像をシェイプ本体の各側から伸縮させる設定
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **FAQ**

**PictureFrame がサポートする画像形式を確認するにはどうすればよいですか？**  
Aspose.Slides は、[PictureFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/pictureframe/) に割り当てられる画像オブジェクトを介して、ラスタ画像（PNG、JPEG、BMP、GIF など）とベクタ画像（例: SVG）の両方をサポートします。サポートされる形式の一覧は、スライドおよび画像変換エンジンの機能と概ね一致します。

**多数の大きな画像を追加すると PPTX のサイズとパフォーマンスにどのような影響がありますか？**  
大きな画像を埋め込むとファイルサイズとメモリ使用量が増加します。画像をリンクとして追加するとプレゼンテーションのサイズを抑えることができますが、外部ファイルが常にアクセス可能である必要があります。Aspose.Slides はリンクによる画像追加機能を提供しており、ファイルサイズ削減に役立ちます。

**画像オブジェクトが誤って移動/サイズ変更されないようにロックするには？**  
[PictureFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/pictureframe/) 用の [shape locks](https://reference.aspose.com/slides/ja/cpp/aspose.slides/pictureframe/get_pictureframelock/) を使用して、移動やサイズ変更を無効化できます。ロック機構は別の記事「[プロテクションの適用](/slides/ja/cpp/applying-protection-to-presentation/)」で説明されており、PictureFrame を含むさまざまなシェイプタイプでサポートされています。

**プレゼンテーションを PDF や画像にエクスポートするとき、SVG ベクタの忠実度は保持されますか？**  
Aspose.Slides は [PictureFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/pictureframe/) から元のベクタ SVG を抽出でき、完全な忠実度が保たれます。[PDF にエクスポート](/slides/ja/cpp/convert-powerpoint-to-pdf/) や [ラスタ形式にエクスポート](/slides/ja/cpp/convert-powerpoint-to-png/) する際は、エクスポート設定に応じてラスタ化される可能性がありますが、抽出動作により SVG がベクタとして保持されていることが確認できます。