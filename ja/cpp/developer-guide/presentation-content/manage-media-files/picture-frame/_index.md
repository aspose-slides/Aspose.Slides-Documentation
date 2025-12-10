---
title: C++ を使用してプレゼンテーションのピクチャーフレームを管理
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
- ラスタ画像
- ベクタ画像
- 画像の切り抜き
- 切り抜き領域
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
description: "Aspose.Slides for C++ を使用して PowerPoint と OpenDocument のプレゼンテーションにピクチャーフレームを追加します。ワークフローを効率化し、スライドデザインを強化します。"
---

ピクチャーフレームは画像を含むシェイプで、フレーム内の写真のようなものです。  

スライドに画像をピクチャーフレームを介して追加できます。この方法では、ピクチャーフレームをフォーマットすることで画像をフォーマットできます。  

{{% alert  title="Tip" color="primary" %}} 

Aspose は無料コンバータ―[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) と [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)―を提供しており、画像から迅速にプレゼンテーションを作成できます。 

{{% /alert %}} 

## **ピクチャーフレームの作成**

1. [Presentation class](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) のインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーションオブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) に画像を追加して、シェイプの塗りつぶしに使用する [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) オブジェクトを作成します。  
4. 画像の幅と高さを指定します。  
5. 参照されたスライドに関連付けられたシェイプオブジェクトが提供する `AddPictureFrame` メソッドを使用して、画像の幅と高さに基づく [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_frame) を作成します。  
6. スライドにピクチャーフレーム（画像を含む）を追加します。  
7. 変更されたプレゼンテーションを PPTX ファイルとして保存します。  

この C++ コードはピクチャーフレームの作成方法を示しています:  
```c++
// ドキュメントディレクトリへのパスです。
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// 対象のプレゼンテーションをロードする
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセスする
SharedPtr<ISlide> slide = pres->get_Slide(0);

// プレゼンテーションの画像コレクションに追加される画像をロードする
// 画像を取得する
auto image = Images::FromFile(filePath);

// プレゼンテーションの画像コレクションに画像を追加する
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// スライドにピクチャーフレームを追加する
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// 相対スケールの幅と高さを設定する
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// ピクチャーフレームにいくつかの書式設定を適用する
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

// PPTX ファイルをディスクに保存する
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


{{% alert color="warning" %}} 

ピクチャーフレームを使用すると、画像に基づくプレゼンテーションスライドを迅速に作成できます。ピクチャーフレームと Aspose.Slides の保存オプションを組み合わせることで、画像の形式変換などの入出力操作を操作できます。以下のページもご覧ください：変換 [image to JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/); 変換 [JPG to image](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/); 変換 [JPG to PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/), 変換 [PNG to JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/); 変換 [PNG to SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/), 変換 [SVG to PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/). 

{{% /alert %}}

## **相対スケールでピクチャーフレームを作成**

画像の相対スケーリングを変更することで、より複雑なピクチャーフレームを作成できます。  

1. [Presentation class](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) のインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーションの画像コレクションに画像を追加します。  
4. プレゼンテーションオブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) に画像を追加して、シェイプの塗りつぶしに使用する [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) オブジェクトを作成します。  
5. ピクチャーフレーム内で画像の相対的な幅と高さを指定します。  
6. 変更されたプレゼンテーションを PPTX ファイルとして保存します。  

この C++ コードは相対スケールでピクチャーフレームを作成する方法を示しています:  
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

// PPTX ファイルをディスクに保存します
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **ピクチャーフレームからラスター画像を抽出**

[PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_frame) オブジェクトからラスター画像を抽出し、PNG、JPG などの形式で保存できます。以下のコード例は、ドキュメント "sample.pptx" から画像を抽出し、PNG 形式で保存する方法を示しています。  
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


## **ピクチャーフレームから SVG 画像を抽出**

プレゼンテーションに [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) シェイプ内に配置された SVG グラフィックが含まれる場合、Aspose.Slides for C++ は元のベクター画像を完全な忠実度で取得できます。スライドのシェイプコレクションを走査することで、各 [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) を特定し、基になる [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) が SVG コンテンツを保持しているか確認し、そしてその画像をディスクまたはストリームにネイティブ SVG 形式で保存できます。  

次のコード例は、ピクチャーフレームから SVG 画像を抽出する方法を示しています:  
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

Aspose.Slides を使用すると、画像に適用された透明効果を取得できます。この C++ コードはその操作を示しています:  
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


{{% alert title="NOTE" color="primary" %}} 
画像に適用されたすべてのエフェクトは [Aspose::Slides::Effects](https://reference.aspose.com/slides/cpp/aspose.slides.effects/) で確認できます。 
{{% /alert %}}

## **ピクチャーフレームの書式設定**

Aspose.Slides はピクチャーフレームに適用できる多くの書式設定オプションを提供します。これらのオプションを使用して、ピクチャーフレームを特定の要件に合わせて変更できます。  

1. [Presentation class](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) のインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーションオブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) に画像を追加して、シェイプの塗りつぶしに使用する [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) オブジェクトを作成します。  
4. 画像の幅と高さを指定します。  
5. 参照されたスライドに関連付けられた [IShapes](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) オブジェクトが提供する [AddPictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) メソッドを使用して、画像の幅と高さに基づく `PictureFrame` を作成します。  
6. ピクチャーフレーム（画像を含む）をスライドに追加します。  
7. ピクチャーフレームの線の色を設定します。  
8. ピクチャーフレームの線の幅を設定します。  
9. 正または負の値を指定してピクチャーフレームを回転させます。  
   * 正の値は画像を時計回りに回転させます。  
   * 負の値は画像を反時計回りに回転させます。  
10. ピクチャーフレーム（画像を含む）をスライドに追加します。  
11. 変更されたプレゼンテーションを PPTX ファイルとして保存します。  

この C++ コードはピクチャーフレームの書式設定プロセスを示しています:  
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

Aspose は最近、[無料 Collage Maker](https://products.aspose.app/slides/collage) を開発しました。JPG/JPEG や PNG 画像を [マージ]https://products.aspose.app/slides/collage/jpg) したり、[写真からグリッドを作成]https://products.aspose.app/slides/collage/photo-grid) したい場合は、このサービスを利用できます。 

{{% /alert %}}

## **画像をリンクとして追加**

プレゼンテーションのサイズが大きくなるのを防ぐため、ファイルを直接埋め込む代わりにリンクを介して画像（または動画）を追加できます。この C++ コードはプレースホルダーに画像と動画を追加する方法を示しています:  
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


## **画像の切り抜き**

この C++ コードはスライド上の既存画像を切り抜く方法を示しています:  
```CPP
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// 新しい画像オブジェクトを作成します
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// スライドに PictureFrame を追加します
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// 画像をクロップします（パーセンテージ値）
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// 結果を保存します
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **画像の切り抜き領域を削除**

フレーム内の画像の切り抜き領域を削除したい場合は、[IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) メソッドを使用できます。このメソッドは、切り抜きが不要な場合は元画像を、切り抜かれた画像を返します。  

この C++ コードはその操作を示しています:  
```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// 最初のスライドから PictureFrame を取得します
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// PictureFrame の画像の切り抜き領域を削除し、切り抜かれた画像を返します
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// 結果を保存します
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```


{{% alert title="NOTE" color="warning" %}} 

[IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) メソッドは切り抜かれた画像をプレゼンテーションの画像コレクションに追加します。画像が処理された [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) のみで使用されている場合、この設定はプレゼンテーションのサイズを縮小できます。そうでない場合、結果として得られるプレゼンテーションの画像数が増加します。  

このメソッドは、切り抜き操作で WMF/EMF メタファイルをラスター PNG 画像に変換します。 

{{% /alert %}}

## **アスペクト比をロック**

画像を含むシェイプのサイズを変更してもアスペクト比を保持したい場合は、[set_AspectRatioLocked()](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) メソッドを使用して *Lock Aspect Ratio* 設定を行うことができます。  

この C++ コードはシェイプのアスペクト比をロックする方法を示しています:  
```c++
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

この *Lock Aspect Ratio* 設定はシェイプのアスペクト比のみを保持し、含まれる画像のアスペクト比は保持しません。 
{{% /alert %}}

## **StretchOff プロパティの使用**

[StretchOffsetLeft](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471)、[StretchOffsetTop](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a)、[StretchOffsetRight](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) および [StretchOffsetBottom](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) プロパティを [IPictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_fill_format) インターフェイスおよび [PictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format) クラスから使用すると、塗りつぶし矩形を指定できます。  

画像の伸縮が指定されると、ソース矩形は指定された塗りつぶし矩形に合わせてスケーリングされます。塗りつぶし矩形の各辺は、シェイプのバウンディングボックスの対応する辺からのパーセンテージオフセットで定義されます。正のパーセンテージはインセットを示し、負のパーセンテージはアウトセットを示します。  

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. `AutoShape` の矩形を追加します。  
4. 画像を作成します。  
5. シェイプの塗りつぶしタイプを設定します。  
6. シェイプの画像塗りつぶしモードを設定します。  
7. シェイプを塗りつぶす画像を設定して追加します。  
8. シェイプのバウンディングボックスの対応する辺からの画像オフセットを指定します。  
9. 変更されたプレゼンテーションを PPTX ファイルとして保存します。  

この C++ コードは StretchOff プロパティを使用したプロセスを示しています:  
```cpp
auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// Sets the image stretched from each side in the shape body
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```


## **FAQ**

**PictureFrame にサポートされている画像形式を確認する方法は？**  
Aspose.Slides は、[PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) に割り当てられる画像オブジェクトを通じて、ラスタ画像（PNG、JPEG、BMP、GIF など）とベクタ画像（例: SVG）の両方をサポートしています。サポートされている形式の一覧は、スライドおよび画像変換エンジンの機能と概ね重なります。  

**多数の大きな画像を追加すると、PPTX のサイズとパフォーマンスにどのような影響がありますか？**  
大きな画像を埋め込むとファイルサイズとメモリ使用量が増加します。画像をリンクとして追加するとプレゼンテーションのサイズを抑えることができますが、外部ファイルがアクセス可能である必要があります。Aspose.Slides はリンクによる画像追加機能を提供し、ファイルサイズの削減が可能です。  

**画像オブジェクトが誤って移動・サイズ変更されないようにロックするには？**  
[shape locks](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/get_pictureframelock/) を [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) に適用して（例: 移動やサイズ変更を無効化）ロックできます。このロック機構は、別記事の [保護に関する記事](/slides/ja/cpp/applying-protection-to-presentation/) でシェイプ向けに説明されており、[PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) を含む様々なシェイプタイプでサポートされています。  

**プレゼンテーションを PDF や画像にエクスポートするとき、SVG のベクタ忠実度は保持されますか？**  
Aspose.Slides は、[PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) から元のベクタとして SVG を抽出することを可能にします。[PDF にエクスポート](/slides/ja/cpp/convert-powerpoint-to-pdf/) や [ラスター形式へのエクスポート](/slides/ja/cpp/convert-powerpoint-to-png/) 時は、エクスポート設定により結果がラスタライズされる場合がありますが、抽出動作により元の SVG がベクタとして保持されていることが確認できます。