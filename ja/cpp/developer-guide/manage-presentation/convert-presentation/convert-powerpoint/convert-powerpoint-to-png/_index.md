---
title: C++でPowerPointスライドをPNGに変換
linktitle: PowerPoint を PNG に変換
type: docs
weight: 30
url: /ja/cpp/convert-powerpoint-to-png/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を PNG に変換
- プレゼンテーションを PNG に変換
- スライドを PNG に変換
- PPT を PNG に変換
- PPTX を PNG に変換
- PPT を PNG として保存
- PPTX を PNG として保存
- PPT を PNG にエクスポート
- PPTX を PNG にエクスポート
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint プレゼンテーションを高品質な PNG 画像に迅速に変換し、正確で自動化された結果を保証します。"
---

## **PowerPoint から PNG への変換について**

PNG（Portable Network Graphics）形式は JPEG（Joint Photographic Experts Group）ほど一般的ではありませんが、依然として非常に人気があります。

**使用例:** 複雑な画像でサイズが問題でない場合、PNG は JPEG よりも優れた画像形式です。

{{% alert title="Tip" color="primary" %}} Aspose の無料 **PowerPoint から PNG への変換ツール** を確認したいかもしれません: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) と [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png)。これらはこのページで説明したプロセスの実装例です。 {{% /alert %}}

## **PowerPoint を PNG に変換する**

次の手順を実行します。

1. Presentation クラス（[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)）のインスタンスを作成します。
2. [Presentation::get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) コレクションから、[ISlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide) インターフェイスのスライドオブジェクトを取得します。
3. 各スライドのサムネイルを取得するには、[ISlide::GetImage()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage) メソッドを使用します。
4. スライドのサムネイルを PNG 形式で保存するには、[IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method) ) メソッドを使用します。

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage()->Save(fileName, ImageFormat::Png);
}
```


## **カスタム寸法で PowerPoint を PNG に変換する**

特定のスケールの PNG ファイルを取得したい場合は、結果のサムネイルのサイズを決定する `desiredX` と `desiredY` の値を設定できます。

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


## **カスタムサイズで PowerPoint を PNG に変換する**

特定のサイズの PNG ファイルを取得したい場合は、`ImageSize` 用に希望の `width` と `height` 引数を渡すことができます。

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

**スライド全体ではなく、特定のシェイプ（例：チャートや画像）だけをエクスポートするにはどうすればよいですか？**  
Aspose.Slides は [個々のシェイプのサムネイル生成](/slides/ja/cpp/create-shape-thumbnails/) をサポートしています。シェイプを PNG 画像としてレンダリングできます。

**サーバー上での並列変換はサポートされていますか？**  
はい、ただしスレッド間で単一の Presentation インスタンスを [共有しない](/slides/ja/cpp/multithreading/) ようにしてください。スレッドまたはプロセスごとに別々のインスタンスを使用します。

**PNG へのエクスポート時の体験版の制限は何ですか？**  
評価モードでは出力画像に透かしが追加され、ライセンスが適用されるまで [その他の制限](/slides/ja/cpp/licensing/) が適用されます。