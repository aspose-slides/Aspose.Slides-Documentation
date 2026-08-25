---
title: C++ を使用したプレゼンテーションのピクチャーフレーム管理
linktitle: ピクチャーフレーム
type: docs
weight: 10
url: /ja/cpp/picture-frame/
keywords:
- ピクチャーフレーム
- ピクチャーフレームの追加
- ピクチャーフレームの作成
- 埋め込み画像
- リンク画像
- 画像の抽出
- ラスタ画像
- SVG 画像
- 画像のクロップ
- クロップされた領域の削除
- 画像の圧縮
- StretchOffset
- ピクチャーフレームの書式設定
- 相対スケール
- 画像エフェクト
- アスペクト比
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、プレゼンテーション内のピクチャーフレームを作成、書式設定、リンク、クロップ、抽出、圧縮します。"
---
## **概要**

ピクチャーフレームは画像を表示するスライド形状です。Aspose.Slides では、画像リソースとそれを表示する形状は別々のオブジェクトです。 [プレゼンテーション](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) は埋め込み画像リソースを [画像コレクション](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_images/) を通じて所有し、[IPictureFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipictureframe/) は画像の位置、サイズ、線の書式設定、回転、クロッピング、画像効果、その他フレームレベルの設定を制御します。

同じ画像を複数回表示する場合、この分離は便利です。画像をプレゼンテーションに一度だけ追加し、返された [IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/) を保持し、ピクチャーフレームを作成するときにその画像リソースを使用します。

ピクチャーフレームは PNG や JPEG などのラスタ画像や SVG などのベクター画像を含めることができます。また、画像バイトをプレゼンテーションに格納せずにリンク画像を参照することもできます。選択肢はポータビリティ、ファイルサイズ、抽出、エクスポート動作に影響するため、書式設定や最適化を適用する前に画像の保存方法を決定することが有用です。

## **埋め込み画像の追加と書式設定**

埋め込み画像の場合、画像データをプレゼンテーションに追加し、[IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/shapecollection/addpictureframe/) でピクチャーフレームを作成します。画像はプレゼンテーション パッケージの一部になるため、別のコンピュータに移動してもプレゼンテーションは自己完結型のままです。

次の例は JPEG 画像を追加し、画像の元の寸法でフレームを作成し、線の書式設定と回転を適用します。

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

ピクチャーフレームは表示されるジオメトリを制御します。フレームサイズを変更しても、埋め込み画像リソースに保存されている元のピクセル寸法は変わりません。この区別は、後で画像をクロップしたり圧縮したりする際に重要になります。

## **相対スケールの使用**

[IPictureFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipictureframe/) はフレームの相対幅と高さのスケーリングを公開します。`1.0` の値は元の画像サイズの 100% に相当します。相対スケールは、最終寸法を手動で計算する代わりに、ソース画像サイズとの関係を保持したいワークフローで便利です。

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

相対スケールはフレームのスケール設定を変更しますが、埋め込み画像を再サンプリングしたり圧縮したりはしません。

## **埋め込み画像とリンク画像**

埋め込み画像は画像データをプレゼンテーション内に格納するため、ポータビリティと予測可能なレンダリングに最も安全な選択です。リンク画像は [ISlidesPicture](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidespicture/) のリンク パスを介して外部位置を保存し、画像データを同じ方法で埋め込むことはありません。

リンク画像は PPTX に保存される画像データ量を削減できますが、外部依存性を導入します。リンク先ファイルはプレゼンテーションを開く・レンダリングするアプリケーションがアクセスできる状態である必要があります。パスが変更されたり、ファイルが移動されたり、リソースが利用できなくなると、リンク画像は期待通りに表示されない可能性があります。メールで送信したり、アーカイブしたり、隔離された環境でレンダリングする必要があるプレゼンテーションでは、埋め込み画像の方が通常は信頼性が高いです。

### **リンク画像の追加**

次の例はピクチャーフレームを作成し、ローカル画像ファイルを指すように設定します。この例は画像のリンクのみを扱い、動画のリンクは別のメディア ワークフローであり、意図的にこの例に混在させていません。

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

外部ファイル管理が意図的な場合にリンクを使用してください。単に圧縮の代替として使用しないでください。壊れた画像依存関係を抱える小さな PPTX は、サイズが大きい自己完結型プレゼンテーションよりも実用性が低いことが多いです。

## **ピクチャーフレームから画像を抽出する**

既存のプレゼンテーションから画像を抽出する前に、形状が実際に [IPictureFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipictureframe/) であり、埋め込み画像を含んでいるか確認してください。リンクされたピクチャーフレームは、同じ方法で抽出できる画像バイトを含んでいない場合があります。

### **ラスタ画像の抽出**

最新の画像 API は [IImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimage/) を直接使用します。次の例はスライド上の最初の埋め込みラスタ画像を見つけ、PNG として保存します。

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

[IImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimage/) を通して保存すると、抽出した画像が要求された出力形式に変換されます。プレゼンテーションに格納されているエンコード済みバイトが必要な場合は、変換されたラスタ ファイルではなく画像リソースのバイナリ データを使用してください。

### **SVG 画像の抽出**

SVG 画像の場合、[IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/) は [ISvgImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isvgimage/) オブジェクトを公開します。これにより、画像をラスタライズせずに SVG データを直接取得できます。

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

SVG コンテンツを SVG のまま保持すると、プレゼンテーション内にベクタ ソースが残ります。PNG や JPEG などのラスタ エクスポートはベクタ コンテンツをピクセルにレンダリングします。PDF や SVG へのスライドエクスポートもレンダリング操作であるため、エクスポートされたグラフィックは元の埋め込み SVG のバイト単位のコピーとはみなさず、元のベクタ リソースが必要なときは埋め込み [ISvgImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isvgimage/) データを使用してください。

## **画像のクロップ**

クロップはフレーム内で画像のどの部分が表示されるかを変更します。[IPictureFillFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipicturefillformat/) のクロップ値はソース画像寸法のパーセンテージです。クロップは最初は埋め込み画像から隠れたピクセルを削除せず、表示領域だけを変更します。

次の例はピクチャーフレームを安全に取得し、クロップ値を適用します。

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

隠れた画像データは依然として存在するため、後でクロップを変更しても元のピクセルは失われません。ファイルサイズが重要で、可逆性が不要な場合は、次節で説明するようにクロップ領域を物理的に削除できます。

## **クロップされた画像データの削除**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) は現在のクロップ矩形の外側にある画像データを削除し、結果として得られる画像リソースを返します。これによりファイルサイズを削減できますが、破壊的な最適化です。プレゼンテーションを保存した後は、削除されたピクセルは後でのアンクロップ操作で利用できなくなります。

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

このメソッドはプレゼンテーションに新しい画像リソースを追加する可能性があります。元の画像が他のピクチャーフレームでも使用されている場合、これらのフレームは既存のリソースを引き続き必要とするため、クロップ領域の削除が必ずしも画像総数を減らすわけではありません。このメソッドで WMF や EMF コンテンツをクロップすると、結果は PNG にラスタライズされます。

## **ラスタ画像の圧縮**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipicturefillformat/compressimage/) は、画像が表示されるサイズに対してラスタ画像の解像度を低減します。同時にクロップ領域を削除することもできます。メソッドは画像がリサイズまたはクロップされた場合に `true`、変更が不要だった場合に `false` を返します。

標準的なターゲット解像度で十分な場合は、事前定義された [PicturesCompression](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/picturescompression/) 値を使用してください。

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

特定のターゲットが必要なときは、列挙値の代わりにカスタムの正の DPI 値を渡すことも可能です。

圧縮はラスタ画像を対象としています。SVG やメタファイルのコンテンツはこのラスタ圧縮ワークフローでは縮小されません。また、解像度を下げてクロップ領域を削除した場合、最適化されたプレゼンテーションからは復元できないことを忘れないでください。最も大きく表示またはエクスポートされるサイズに基づいてターゲット解像度を選択し、全体的に最低 DPI を適用しないようにしてください。

## **画像変換エフェクトの管理**

明るさ、コントラスト、カラー変換、ぼかし、アルファ効果、順序付けられたチェーン、検査、除去、ラウンドトリップ検証を含む完全なワークフローについては、[画像変換エフェクト](/slides/ja/cpp/image-transform-effects/) を参照してください。

## **ピクチャーフレームのジオメトリをロックする**

[IPictureFrameLock](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipictureframelock/) 設定は、ピクチャーフレームに対してどの編集操作を無効にするかを制御します。たとえば、[アスペクト比ロック](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) はリサイズ時に形状の比例を保持します。

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

ロックはピクチャーフレーム形状に適用されます。ソース画像が再サンプリングされたり、同じアスペクト比に永久に変更されたりすることはありません。

## **StretchOffset 値の調整**

ピクチャー 塗りつぶしモードが stretch の場合、[IPictureFillFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipicturefillformat/) の stretch‑offset 値はピクチャーフレームのバウンディング ボックスに対する相対的な塗りつぶし矩形を定義します。正のパーセンテージはエッジからのインセットを作り、負のパーセンテージはアウトセットを作ります。

これはクロップとは異なります。クロップ値はソース画像のどの部分が表示されるかを選択しますが、stretch offset は表示される画像塗りつぶしが伸縮される矩形を変更します。

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

塗りつぶし位置を調整したいときは stretch offset を使用し、ソース画像の端を隠したいときはクロッププロパティを使用してください。

## **保存、ファイルサイズ、エクスポートに関する考慮事項**

画像の保存とピクチャーフレームの書式設定を別々に扱うと、主なトレードオフが管理しやすくなります。

- **埋め込み画像** はプレゼンテーションを自己完結型にし、共有やサーバー側レンダリングに最も信頼性がありますが、大きなラスタ画像は PPTX サイズとメモリ使用量を増加させます。
- **リンク画像** はパッケージを小さく保てますが、プレゼンテーションは外部ファイルが指定パスまたは場所に残っていることに依存します。
- **クロップ** は当初は非破壊的です。隠れたピクセルはクロップ領域が明示的に削除されるか圧縮時に除去されるまで埋め込まれたままです。
- **圧縮** はサイズが大きすぎるラスタ画像のファイルサイズを大幅に削減できますが、ソース解像度を犠牲にします。スライド上での実際の表示サイズが判明した後に適用すべきです。
- **SVG 画像** はベクトルの保存が重要な場合は SVG のままにしてください。ベクタ リソース自体が必要なときは埋め込み SVG を直接抽出します。ラスタ スライド エクスポートは常にレンダリングされたスライドをピクセルに変換します。
- **繰り返し使用される画像** は、可能な限り既存の [IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/) リソースを再利用し、同じファイルをプレゼンテーション ワークフローに何度も読み込むのを避けてください。

大規模なプレゼンテーションでは、画像最適化は選択的に実施すると最も効果的です。ロゴや図はベクタ コンテンツとして保持し、写真は実際の表示サイズに合わせて圧縮し、後で編集が不要な場合にのみクロップされたピクセルを削除し、外部リンクは依存性管理が展開設計の一部でない限り避けてください。

## **FAQ**

**ピクチャーフレームと画像リソースの違いは何ですか？**

[IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/) はプレゼンテーションに関連付けられた画像リソースを表します。 [IPictureFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipictureframe/) は画像を表示し、サイズ、回転、クロップ値、エフェクト、ロックなどフレームレベルのジオメトリと書式設定を保持するスライド上の形状です。

**画像は埋め込むべきかリンクすべきか？**

プレゼンテーションをポータブルに、アーカイブに、または外部リソースにアクセスせずにレンダリングする必要がある場合は埋め込み画像を使用してください。画像ファイルを PPTX の外に保持し、外部場所を確実に管理できる場合のみリンク画像を使用してください。

**クロップは PPTX のファイルサイズを削減しますか？**

単独では削減しません。通常のクロップ設定は画像の一部を非表示にしますが、基になるピクセルは保持されます。ピクセルを永続的に削除したい場合は [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) またはクロップ領域削除を伴う画像圧縮を使用してください。

**圧縮後に画像品質を復元できますか？**

できません。圧縮は保存されたラスタ解像度を下げ、クロップ領域の削除は画像データを破棄します。後で高解像度の編集が必要になる可能性がある場合は、元のソース画像をプレゼンテーションの外に保持してください。

**SVG 画像はどのように扱うべきですか？**

ベクタ の忠実度が重要な場合は SVG コンテンツを SVG のまま保持してください。埋め込み [ISvgImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isvgimage/) は直接抽出できます。PNG や JPEG などのラスタ形式にスライドをレンダリングすると、SVG はピクセルに変換されます。

**既存スライドを読むときに安全でないキャストを避けるには？**

ピクチャーフレーム固有のメンバーを使用する前に、形状タイプを [IPictureFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipictureframe/) でチェックしてください。ランタイムキャストを適用する前にローカル変数にキャスト結果を代入し、ピクチャーフレーム固有のメンバーにアクセスします。