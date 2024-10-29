---
title: PowerPointをPNGに変換する
type: docs
weight: 30
url: /ja/cpp/convert-powerpoint-to-png/
keywords: PowerPointをPNGに, PPTをPNGに, PPTXをPNGに, C++, Aspose.Slides for C++
description: PowerPointプレゼンテーションをPNGに変換する
---

## **PowerPointからPNGへの変換について**

PNG（ポータブルネットワークグラフィックス）形式はJPEG（ジョイントフォトグラフィックエキスパートグループ）ほど一般的ではありませんが、非常に人気があります。

**使用ケース:** 複雑な画像があり、サイズが問題でない場合、PNGはJPEGよりも優れた画像形式です。

{{% alert title="ヒント" color="primary" %}} Asposeの無料**PowerPointからPNGへのコンバータ**をチェックしてみてください: [PPTXをPNGに](https://products.aspose.app/slides/conversion/pptx-to-png)および [PPTをPNGに](https://products.aspose.app/slides/conversion/ppt-to-png)。これらはこのページで説明されているプロセスの実装です。 {{% /alert %}}

## **PowerPointをPNGに変換する**

これらの手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
2. [ISlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide)インターフェイスの下の[Presentation::get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c)コレクションからスライドオブジェクトを取得します。
3. 各スライドのサムネイルを取得するために、[ISlide::GetImage()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage)メソッドを使用します。
4. スライドのサムネイルをPNG形式で保存するために、[IImage::Save(String, ImageFormatPtr)](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method)メソッドを使用します。

このC++コードは、PowerPointプレゼンテーションをPNGに変換する方法を示しています：

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage()->Save(fileName, ImageFormat::Png);
}
```

## **カスタム寸法でPowerPointをPNGに変換する**

特定のスケールに合わせたPNGファイルを取得したい場合は、結果のサムネイルの寸法を決定する`desiredX`および`desiredY`の値を設定できます。

このC++のコードは、説明された操作を示しています：

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

float scaleX = 2.f;
float scaleY = 2.f;
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(scaleX, scaleY)->Save(fileName, ImageFormat::Png);
}
```

## **カスタムサイズでPowerPointをPNGに変換する**

特定のサイズに合わせたPNGファイルを取得したい場合は、`ImageSize`に対して希望する`width`と`height`の引数を渡すことができます。

このコードは、画像のサイズを指定しながらPowerPointをPNGに変換する方法を示しています：

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
Size size(960, 720);
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(size)->Save(fileName, ImageFormat::Png);
}
```