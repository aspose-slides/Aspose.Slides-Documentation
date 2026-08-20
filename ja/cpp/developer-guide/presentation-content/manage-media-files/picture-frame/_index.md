---
title: C++ を使用したプレゼンテーションでの画像フレームの管理
linktitle: 画像フレーム
type: docs
weight: 10
url: /ja/cpp/picture-frame/
keywords:
- 画像フレーム
- 画像フレームの追加
- 画像フレームの作成
- 埋め込み画像
- リンク画像
- 画像の抽出
- ラスター画像
- SVG 画像
- 画像のクロップ
- クロップ領域の削除
- 画像の圧縮
- StretchOffset
- 画像フレームの書式設定
- 相対スケール
- 画像効果
- アスペクト比
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、プレゼンテーション内の画像フレームを作成、書式設定、リンク、クロップ、抽出、圧縮します。"
---
## **概要**

画像フレームは画像を表示するスライドのシェイプです。Aspose.Slides では、画像リソースとそれを表示するシェイプは別々のオブジェクトです。 a [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) は埋め込み画像リソースをその [画像コレクション](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_images/) を介して所有し、[IPictureFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipictureframe/) は画像の位置、サイズ、線の書式設定、回転、クロップ、画像効果、その他フレームレベルの設定を制御します。

同じ画像を複数回表示する場合にこの分離は便利です。画像をプレゼンテーションに一度だけ追加し、返される [IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/) を保持し、画像フレームを作成する際にその画像リソースを使用します。

画像フレームは PNG や JPEG などのラスター画像と SVG などのベクター画像の両方を含めることができます。また、画像バイトをプレゼンテーションに保存せずにリンク画像を参照することもできます。この選択は移植性、ファイルサイズ、抽出、エクスポートの挙動に影響するため、書式設定や最適化を適用する前に画像の保存方法を決めておくことが有用です。

## **埋め込み画像の追加と書式設定**

埋め込み画像の場合、画像データをプレゼンテーションに追加し、[IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/shapecollection/addpictureframe/) で画像フレームを作成します。画像はプレゼンテーション パッケージの一部になるため、プレゼンテーションを別のコンピュータに移動しても自己完結した状態が保たれます。

次の例は JPEG 画像を追加し、画像のネイティブサイズでフレームを作成し、線の書式設定と回転を適用します：

```cpp
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
#include <IImage.h>
#include <Util/Images.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pictureFrame->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pictureFrame->get_LineFormat()->set_Width(3.0);
pictureFrame->set_Rotation(15.0f);

presentation->Save(u"picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

画像フレームは表示されるジオメトリを制御します。フレームサイズを変更しても、埋め込み画像リソースに保存されている元のピクセル寸法は変更されません。この違いは、後で画像をクロップしたり圧縮したりする際に重要になります。

## **相対スケールの使用**

[IPictureFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipictureframe/) はフレームの相対的な幅と高さのスケーリングを提供します。`1.0` の値は元の画像サイズの 100% に相当します。相対スケールは、最終寸法を手動で計算する代わりに、元画像サイズとの関係を保持したいワークフローで便利です。

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, image);
pictureFrame->set_RelativeScaleWidth(1.35f);
pictureFrame->set_RelativeScaleHeight(0.8f);

presentation->Save(u"relative-scale.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

相対スケールはフレームのスケール設定を変更しますが、埋め込み画像をリサンプリングしたり圧縮したりはしません。

## **埋め込み画像とリンク画像**

埋め込み画像は画像データをプレゼンテーション内部に保存するため、移植性と予測可能なレンダリングに最も安全です。リンク画像は [ISlidesPicture](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidespicture/) のリンクパスを通じて外部ロケーションを参照し、画像データを同様に埋め込むことはありません。

リンク画像は PPTX 内の画像データ量を削減できますが、外部依存が発生します。リンク先ファイルがアクセス可能である必要があり、パスが変更されたりファイルが移動したりリソースが利用できなくなると、期待通りに表示されません。メールで送付したり、アーカイブしたり、隔離された環境でレンダリングする必要があるプレゼンテーションでは、埋め込み画像の方が一般に信頼性が高いです。

### **リンク画像の追加**

次の例は画像フレームを作成し、ローカル画像ファイルを指すように設定します。画像リンクのみを扱い、動画リンクは別のメディアワークフローであり、この例には混在させていません。

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, nullptr);
auto linkPath = Path::GetFullPath(u"linked-image.jpg");
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(linkPath);

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

外部ファイル管理が意図的な場合にリンクを使用してください。圧縮の代替として使用しないでください。壊れた画像依存関係を持つ小さな PPTX は、自己完結した大きなプレゼンテーションよりも実用的でないことが多いです。

## **画像フレームからの画像抽出**

既存のプレゼンテーションから画像を抽出する前に、シェイプが実際に [IPictureFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipictureframe/) であり、埋め込み画像を含んでいることを確認してください。リンクされた画像フレームは同様に抽出できるバイトを保持していない場合があります。

### **ラスター画像の抽出**

最新の画像 API は [IImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimage/) を直接使用します。次の例はスライド上の最初の埋め込みラスター画像を見つけ、PNG として保存します。

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr || embeddedImage->get_SvgImage() != nullptr)
    {
        continue;
    }

    auto rasterImage = embeddedImage->get_Image();
    rasterImage->Save(u"extracted-image.png", ImageFormat::Png);
    break;
}

presentation->Dispose();
```

[IImage] を介した保存は抽出された画像を要求された出力形式に変換します。プレゼンテーションに保存されているエンコード済みバイトが必要な場合は、画像リソースのバイナリ データを使用してください。

### **SVG 画像の抽出**

SVG 画像の場合、[IPPImage] は [ISvgImage] オブジェクトを公開します。これにより、画像を先にラスタライズせずに SVG データを直接取得できます。

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
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

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr)
    {
        continue;
    }

    auto svgImage = embeddedImage->get_SvgImage();
    if (svgImage == nullptr)
    {
        continue;
    }

    File::WriteAllBytes(u"extracted-image.svg", svgImage->get_SvgData());
    break;
}

presentation->Dispose();
```

SVG コンテンツを SVG のまま保持すると、プレゼンテーション内にベクター ソースが残ります。PNG や JPEG などのラスターエクスポートはベクター コンテンツをピクセルにレンダリングします。PDF や SVG スライドエクスポートもレンダリング操作であるため、エクスポートされたグラフィックは元の埋め込み SVG のバイト単位のコピーとして扱うべきではありません。元のベクター リソースが必要な場合は、埋め込み [ISvgImage] データを使用してください。

## **画像のクロップ**

クロップはフレーム内で画像のどの部分が表示されるかを変更します。[IPictureFillFormat] のクロップ値はソース画像寸法のパーセンテージです。クロップは最初は埋め込み画像から隠れたピクセルを削除せず、表示領域だけを変更します。

次の例は安全に画像フレームを取得し、クロップ値を適用します：

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    pictureFrame->get_PictureFormat()->set_CropLeft(23.6f);
    pictureFrame->get_PictureFormat()->set_CropRight(21.5f);
    pictureFrame->get_PictureFormat()->set_CropTop(3.0f);
    pictureFrame->get_PictureFormat()->set_CropBottom(31.0f);
    presentation->Save(u"cropped-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

隠れた画像データはまだ存在するため、後から元のピクセルを失うことなくクロップを変更できます。ファイルサイズが重要で、可逆性が不要な場合は、次のセクションで説明するようにクロップ領域を物理的に削除できます。

## **クロップされた画像データの削除**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) は現在のクロップ矩形外の画像データを削除し、結果として得られる画像リソースを返します。これによりファイルサイズが削減できますが、破壊的な最適化です。プレゼンテーションを保存した後は、削除されたピクセルは元に戻せなくなります。

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"cropped-image.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto croppedImage = pictureFrame->get_PictureFormat()->DeletePictureCroppedAreas();
    if (croppedImage != nullptr)
    {
        presentation->Save(u"cropped-data-removed.pptx", SaveFormat::Pptx);
    }
}

presentation->Dispose();
```

このメソッドはプレゼンテーションに新しい画像リソースを追加する可能性があります。元の画像が他の画像フレームでも使用されている場合、これらのフレームは既存のリソースを引き続き必要とするため、画像総数が必ずしも減少するわけではありません。WMF や EMF コンテンツに対してこのメソッドを使用すると、クロップ結果が PNG にラスタライズされます。

## **ラスター画像の圧縮**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipicturefillformat/compressimage/) は画像が表示されるサイズに対してラスター画像の解像度を削減します。同時にクロップ領域を削除することも可能です。画像がサイズ変更またはクロップされた場合は `true` を、変更が不要だった場合は `false` を返します。

標準的な対象解像度で十分な場合は、事前定義された [PicturesCompression](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/picturescompression/) 値を使用してください：

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto compressed = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);
    Console::WriteLine(compressed ? String(u"The image was compressed.") : String(u"No compression was necessary."));
    presentation->Save(u"compressed-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

特定の目標が必要な場合は、列挙値の代わりにカスタムの正の DPI 値を渡すことができます。

圧縮はラスター画像を対象としています。SVG やメタファイルのコンテンツはこのラスター圧縮ワークフローでは縮小されません。また、解像度を下げたりクロップ領域を削除したりした画像は最適化されたプレゼンテーションから復元できないことを覚えておいてください。対象解像度は、実際に画像が閲覧またはエクスポートされる最大サイズに基づいて選択し、全体的に最も低い DPI を適用するのは避けてください。

## **画像効果の検査**

画像効果はフレームで使用される画像に格納されます。画像変換コレクションは、透明度のための固定アルファ変調や明るさ・コントラストのための輝度などの効果を含むことができます。以下の例はスライド上の最初の画像フレームから両方の効果を安全に読み取ります：

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();

    for (auto&& effect : imageTransform)
    {
        if (ObjectExt::Is<IAlphaModulateFixed>(effect))
        {
            auto alphaModulateFixed = ExplicitCast<IAlphaModulateFixed>(effect);
            auto transparency = 100.0f - alphaModulateFixed->get_Amount();
            Console::WriteLine(String(u"Transparency: ") + transparency);
        }

        if (ObjectExt::Is<ILuminance>(effect))
        {
            auto luminanceEffect = ExplicitCast<ILuminance>(effect);
            auto luminance = luminanceEffect->GetEffective();
            Console::WriteLine(String(u"Brightness: ") + luminance->get_Brightness());
            Console::WriteLine(String(u"Contrast: ") + luminance->get_Contrast());
        }
    }
}

presentation->Dispose();
```

これらの効果はフレーム内での画像の描画方法を変更しますが、元の埋め込み画像バイトを書き換えることはありません。

## **画像フレームジオメトリのロック**

[IPictureFrameLock](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipictureframelock/) 設定は画像フレームに対して無効化する編集操作を制御します。たとえば、[aspect-ratio lock](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) はリサイズ時にシェイプの比率を保持します。

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);

presentation->Save(u"locked-picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ロックは画像フレームシェイプに適用されます。ソース画像がリサンプリングされたり、永続的に同じアスペクト比に変更されたりすることはありません。

## **StretchOffset 値の調整**

画像の塗りつぶしモードが stretch の場合、[IPictureFillFormat] の stretch‑offset 値は画像フレームのバウンディング ボックスに対する塗りつぶし矩形を定義します。正のパーセンテージはエッジからのインセットを作り、負のパーセンテージはアウトセットを作ります。

これはクロップとは異なります。クロップ値はソース画像のどの部分が表示されるかを選択しますが、stretch offset は表示された画像塗りつぶしが伸びる矩形を変更します。

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.png");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, image);
pictureFrame->get_PictureFormat()->set_PictureFillMode(PictureFillMode::Stretch);
pictureFrame->get_PictureFormat()->set_StretchOffsetLeft(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetRight(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetTop(8.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetBottom(8.0f);

presentation->Save(u"stretch-offsets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

塗りつぶし位置を調整する場合は stretch offset を使用し、ソース画像の端を隠したい場合はクロッププロパティを使用してください。

## **ストレージ、ファイルサイズ、エクスポート上の考慮事項**

画像の保存方法と画像フレームの書式設定を別々に扱うと、次のようなトレードオフが管理しやすくなります。

- **埋め込み画像** はプレゼンテーションを自己完結させ、共有やサーバー側レンダリングに最も信頼性がありますが、大きなラスター画像は PPTX のサイズとメモリ使用量を増加させます。
- **リンク画像** はパッケージを小さく保てますが、プレゼンテーションは外部ファイルが指定されたパスやロケーションに存在することに依存します。
- **クロップ** は最初は非破壊的です。隠れたピクセルは、クロップ領域が明示的に削除されるか圧縮時に除去されるまで埋め込まれたままです。
- **圧縮** は過大なラスター画像のファイルサイズを大幅に削減できますが、ソース解像度を犠牲にします。スライド上での実際の表示サイズが分かってから適用すべきです。
- **SVG 画像** はベクターの保持が重要なときは SVG のまま残すべきです。ベクター リソース自体が必要なときは埋め込み [ISvgImage] を直接抽出してください。ラスター形式へのスライドエクスポートは常にレンダリングされたスライドをピクセルに変換します。
- **繰り返し使用される画像** は、可能な限り同じ [IPPImage] リソースを再利用し、同一ファイルを何度もプレゼンテーションにロードするのを避けてください。

大規模なプレゼンテーションでは、画像最適化は選択的に行うのが最も効果的です。ロゴや図はベクター コンテンツとして保持し、写真は実際の表示サイズに合わせて圧縮し、後で編集が不要な場合にのみクロップされたピクセルを除去し、外部リンクは依存管理がデプロイ設計の一部である場合にのみ使用してください。

## **FAQ**

**画像フレームと画像リソースの違いは何ですか？**

[IPPImage] はプレゼンテーションに関連付けられた画像リソースを表します。[IPictureFrame] はスライド上のシェイプで、画像を表示し、サイズ、回転、クロップ値、効果、ロックなどフレームレベルのジオメトリと書式設定を保持します。

**画像は埋め込むべきですか、リンクすべきですか？**

プレゼンテーションを移植可能に、アーカイブ可能に、外部リソースなしでレンダリングできる必要がある場合は埋め込み画像を使用してください。画像ファイルを PPTX の外に置くことが意図的で、外部ロケーションを信頼できる場合にのみリンク画像を使用してください。

**クロップは PPTX のファイルサイズを削減しますか？**

単独では削減しません。通常のクロップ設定は画像の一部を非表示にしますが、基になるピクセルは保持されます。隠れたピクセルを完全に削除したい場合は、[IPictureFillFormat::DeletePictureCroppedAreas] を使用するか、クロップ領域削除を伴う画像圧縮を行ってください。

**圧縮後に画像品質を復元できますか？**

できません。圧縮は保存されたラスター解像度を低下させ、クロップ領域の削除は画像データを捨てます。後で高解像度で編集する可能性がある場合は、元のソース画像をプレゼンテーションの外に保持してください。

**SVG 画像はどのように扱うべきですか？**

ベクターの忠実度が重要な場合は、SVG コンテンツを SVG のまま保持してください。埋め込み [ISvgImage] は直接抽出できます。PNG や JPEG などのラスター形式へのスライドレンダリングは、SVG をピクセルにラスタライズします。

**既存のスライドを読むときに安全でないキャストを回避するには？**

シェイプの種類を使用する前に必ず確認してください。[IPictureFrame] であることをテストし、ランタイムキャストを行った後はローカル変数に結果を代入してからフレーム固有のメンバーにアクセスしてください。