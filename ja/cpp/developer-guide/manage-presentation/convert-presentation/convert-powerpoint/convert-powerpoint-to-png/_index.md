---
title: C++でPowerPointスライドをPNGに変換
linktitle: PowerPointをPNGに変換
type: docs
weight: 30
url: /ja/cpp/convert-powerpoint-to-png/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- スライドを変換
- PPTを変換
- PPTXを変換
- PowerPointをPNGに変換
- プレゼンテーションをPNGに変換
- スライドをPNGに変換
- PPTをPNGに変換
- PPTXをPNGに変換
- PPTをPNGとして保存
- PPTXをPNGとして保存
- PPTをPNGにエクスポート
- PPTXをPNGにエクスポート
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint プレゼンテーションを高品質な PNG 画像に迅速に変換し、正確で自動化された結果を確保します。"
---

## **PowerPoint から PNG への変換について**

PNG（Portable Network Graphics）形式は JPEG（Joint Photographic Experts Group）ほど普及していませんが、依然として非常に人気があります。

**Use case:** 複雑な画像でサイズが問題とならない場合、PNG は JPEG よりも優れた画像形式です。

{{% alert title="Tip" color="primary" %}} Aspose の無料 **PowerPoint to PNG コンバータ** を確認したいかもしれません: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) と [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png)。これらはこのページで説明したプロセスの実装例です。 {{% /alert %}}

## **PowerPoint を PNG に変換**

以下の手順を実行してください。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
2. [ISlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide) インターフェイスの下にある [Presentation::get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) コレクションからスライドオブジェクトを取得します。
3. 各スライドのサムネイルを取得するために、[ISlide::GetImage()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage) メソッドを使用します。
4. スライドのサムネイルを PNG 形式で保存するために、[IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method) メソッドを使用します。

この C++ コードは PowerPoint プレゼンテーションを PNG に変換する方法を示しています。
```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage()->Save(fileName, ImageFormat::Png);
}
```


## **カスタム寸法で PowerPoint を PNG に変換**

特定のスケールの PNG ファイルを取得したい場合、結果のサムネイルの寸法を決定する `desiredX` と `desiredY` の値を設定できます。

この C++ のコードは上記の操作を実演しています。
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


## **カスタムサイズで PowerPoint を PNG に変換**

特定のサイズの PNG ファイルを取得したい場合、`ImageSize` に対して希望する `width` と `height` の引数を渡すことができます。

このコードは、画像サイズを指定しながら PowerPoint を PNG に変換する方法を示しています。
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


## **FAQ**

**スライド全体ではなく、特定の形状（例: グラフや画像）だけをエクスポートするにはどうすればよいですか？**  
Aspose.Slides は [個々の形状のサムネイル生成](/slides/ja/cpp/create-shape-thumbnails/) をサポートしています。形状を PNG 画像としてレンダリングできます。

**サーバーでの並列変換はサポートされていますか？**  
はい。ただし、スレッド間で単一のプレゼンテーション インスタンスを共有しないでください。スレッドまたはプロセスごとに別々のインスタンスを使用してください。

**PNG へのエクスポート時の試用版の制限は何ですか？**  
評価モードでは出力画像に透かしが追加され、ライセンスが適用されるまで [その他の制限](/slides/ja/cpp/licensing/) が課せられます。