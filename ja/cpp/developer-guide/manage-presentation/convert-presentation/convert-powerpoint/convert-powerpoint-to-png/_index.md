---
title: C++ で PowerPoint スライドを PNG に変換
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
description: "Aspose.Slides for C++ を使用して PowerPoint プレゼンテーションを高品質な PNG 画像に迅速に変換し、正確で自動化された結果を保証します。"
---

## **PowerPoint を PNG に変換するについて**

PNG（Portable Network Graphics）形式は JPEG（Joint Photographic Experts Group）ほど一般的ではありませんが、依然として非常に人気があります。

**使用例:** 画像が複雑でサイズが問題とならない場合、PNG は JPEG よりも適した画像形式です。

{{% alert title="Tip" color="primary" %}} Aspose の無料 **PowerPoint から PNG へのコンバータ** を確認してください: [PPTX を PNG に変換](https://products.aspose.app/slides/conversion/pptx-to-png) と [PPT を PNG に変換](https://products.aspose.app/slides/conversion/ppt-to-png)。これらは本ページで説明したプロセスの実装例です。 {{% /alert %}}

## **PowerPoint を PNG に変換する**

以下の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
2. [Presentation::get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) コレクションから、[ISlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide) インターフェイスのスライド オブジェクトを取得します。 
3. [ISlide::GetImage()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage) メソッドを使用して、各スライドのサムネイルを取得します。 
4. [IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method) メソッドを使用して、スライドのサムネイルを PNG 形式で保存します。 

この C++ コードは、PowerPoint プレゼンテーションを PNG に変換する方法を示しています:
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

特定のスケールで PNG ファイルを取得したい場合は、`desiredX` と `desiredY` の値を設定できます。これらは生成されるサムネイルの寸法を決定します。

この C++ コードは、上記の操作をデモンストレーションしています:
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

特定のサイズで PNG ファイルを取得したい場合は、`ImageSize` 用に希望の `width` と `height` 引数を渡すことができます。

このコードは、画像サイズを指定して PowerPoint を PNG に変換する方法を示しています: 
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

**スライド全体ではなく、特定の図形（例: グラフや画像）だけをエクスポートするにはどうすればよいですか？**

Aspose.Slides は、[個別の図形のサムネイル生成](/slides/ja/cpp/create-shape-thumbnails/) をサポートしており、図形を PNG 画像としてレンダリングできます。

**サーバー上で並列変換はサポートされていますか？**

はい、ただし [単一のプレゼンテーション インスタンスをスレッド間で共有しない](/slides/ja/cpp/multithreading/) ようにしてください。スレッドまたはプロセスごとに別々のインスタンスを使用します。

**PNG にエクスポートする際の試用版の制限は何ですか？**

評価モードでは出力画像に透かしが追加され、ライセンスが適用されるまで [その他の制限](/slides/ja/cpp/licensing/) が適用されます。