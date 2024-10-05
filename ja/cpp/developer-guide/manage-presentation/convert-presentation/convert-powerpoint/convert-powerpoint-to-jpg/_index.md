---
title: Powerpoint PPTをJPGに変換
type: docs
weight: 60
url: /cpp/convert-powerpoint-to-jpg/
keywords:
- PowerPointプレゼンテーションを変換
- JPG
- JPEG
- PowerPointからJPGへ
- PowerPointからJPEGへ
- PPTからJPGへ
- PPTXからJPGへ
- PPTからJPEGへ
- PPTXからJPEGへ
- C++
- Aspose.Slides
description: "PowerPointをJPGに変換: PPTをJPGに、PPTXをJPGにC++で"
---

## **プレゼンテーションを画像のセットに変換**

場合によっては、全体のプレゼンテーションを画像のセットに変換する必要があります。
これはPowerPointが許可していることと同様です。C++コードは、プレゼンテーションをJPG画像に変換する方法を示しています：

```c++
auto imageScale = 1.0f;

auto pres = System::MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : pres->get_Slides())
{
    // フルスケールの画像を作成
    System::SharedPtr<IImage> image = slide->GetImage(imageScale, imageScale);

    // JPEG形式で画像をディスクに保存
    auto imageFileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(imageFileName, ImageFormat::Jpeg);

    image->Dispose();
}

pres->Dispose();
```

{{% alert color="primary" %}} 

Aspose.SlidesがPowerPointをJPG画像に変換する方法を見るには、これらの無料オンラインコンバーターを試してみると良いでしょう：PowerPoint [PPTXをJPGへ](https://products.aspose.app/slides/conversion/pptx-to-jpg) と [PPTをJPGへ](https://products.aspose.app/slides/conversion/ppt-to-jpg)。 

{{% /alert %}} 

## **カスタム寸法でPowerPoint PPT/PPTXをJPGに変換**

生成されるサムネイルとJPG画像の寸法を変更するには、 *ScaleX* と *ScaleY* の値を `float scaleX, float Y` に渡して設定できます。[**ISlide::GetImage()**](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/#islidegetimagefloat-float-method) メソッド：

```c++
auto pres = System::MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

// 寸法を定義
int32_t desiredX = 1200, desiredY = 800;

// XとYのスケール値を取得
float scaleX = (float)(1.0 / pres->get_SlideSize()->get_Size().get_Width()) * desiredX;
float scaleY = (float)(1.0 / pres->get_SlideSize()->get_Size().get_Height()) * desiredY;

for (auto&& slide : pres->get_Slides())
{
    // フルスケールの画像を作成
    System::SharedPtr<IImage> image = slide->GetImage(scaleX, scaleY);

    // JPEG形式で画像をディスクに保存
    auto imageFileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(imageFileName, ImageFormat::Jpeg);

    image->Dispose();
}

pres->Dispose();
```

{{% alert title="ヒント" color="primary" %}}

Asposeは[無料のコラージュWebアプリ](https://products.aspose.app/slides/collage)を提供しています。このオンラインサービスを使用すると、[JPGからJPG](https://products.aspose.app/slides/collage/jpg)またはPNGからPNGの画像を結合し、[フォトグリッド](https://products.aspose.app/slides/collage/photo-grid)を作成することができます。 

この記事で説明したのと同じ原則を使用して、画像をある形式から別の形式に変換できます。詳しくは、これらのページをご覧ください：[画像をJPGに変換](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/) ; [JPGを画像に変換](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/) ; [JPGをPNGに変換](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/) ; [PNGをJPGに変換](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/) ; [PNGをSVGに変換](https://products.aspose.com/slides/cpp/conversion/png-to-svg/) ; [SVGをPNGに変換](https://products.aspose.com/slides/cpp/conversion/svg-to-png/)。

{{% /alert %}}

## **こちらもご覧ください**

PPT/PPTXを画像に変換する他のオプションを確認してください：

- [PPT/PPTXをSVGに変換](/slides/cpp/render-a-slide-as-an-svg-image/)