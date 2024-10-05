---
title: 埋め込みフォント
type: docs
weight: 40
url: /cpp/embedded-font/
keywords: "フォント, 埋め込みフォント, フォントの追加, PowerPointプレゼンテーション C++, CPP, Aspose.Slides for C++"
description: "C++におけるPowerPointプレゼンテーションでの埋め込みフォントの使用"
---

**PowerPointの埋め込みフォント**は、どのシステムやデバイスで開いてもプレゼンテーションが正しく表示されるようにしたいときに便利です。クリエイティブな作業のためにサードパーティ製または非標準のフォントを使用した場合、フォントを埋め込む理由はさらに増えます。さもなければ（埋め込みフォントがない場合）、スライド上のテキストや数字、レイアウト、スタイルなどが変更されたり、混乱を招く長方形に変わったりする可能性があります。

[FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/)クラス、[FontData](https://reference.aspose.com/slides/cpp/aspose.slides/fontdata/)クラス、[Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)クラス、及びそれらのインターフェイスは、PowerPointプレゼンテーションで埋め込みフォントを扱うために必要なプロパティとメソッドのほとんどを含んでいます。

## **プレゼンテーションから埋め込みフォントを取得または削除する**

Aspose.Slidesは、プレゼンテーションに埋め込まれたフォントを取得（または確認する）ために、[GetEmbeddedFonts()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/getembeddedfonts/)メソッド（[FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/)クラスによって公開）を提供しています。フォントを削除するには、同じクラスによって公開された[RemoveEmbeddedFont()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/removeembeddedfont/)メソッドを使用します。

このC++コードは、プレゼンテーションから埋め込みフォントを取得し、削除する方法を示しています。

```c++
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
auto presentation = System::MakeObject<Presentation>(u"EmbeddedFonts.pptx");
// 埋め込まれた"FunSized"を使用するテキストフレームを含んだスライドをレンダリング
presentation->get_Slides()->idx_get(0)->GetImage(Size(960, 720))->Save(u"picture1_out.png", ImageFormat::Png);

auto fontsManager = presentation->get_FontsManager();

// すべての埋め込みフォントを取得
auto embeddedFonts = fontsManager->GetEmbeddedFonts();

std::function<bool(SharedPtr<IFontData>)> comparer = [](SharedPtr<IFontData> data) -> bool
{
    return data->get_FontName() == u"Calibri";
};

// "Calibri"フォントを見つける
auto funSizedEmbeddedFont = Array<SharedPtr<IFontData>>::Find(embeddedFonts, comparer);

// "Calibri"フォントを削除
fontsManager->RemoveEmbeddedFont(funSizedEmbeddedFont);

// プレゼンテーションをレンダリング; "Calibri"フォントは既存のフォントに置き換えられる
presentation->get_Slides()->idx_get(0)->GetImage(Size(960, 720))->Save(u"picture2_out.png", ImageFormat::Png);

// 埋め込まれた"Calibri"フォントなしのプレゼンテーションをディスクに保存
presentation->Save(u"WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
```

## **プレゼンテーションに埋め込みフォントを追加する**

[EmbedFontCharacters](https://reference.aspose.com/slides/cpp/aspose.slides.export/embedfontcharacters/)列挙型と[AddEmbeddedFont()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/addembeddedfont/)メソッドの二つのオーバーロードを使用して、プレゼンテーションにフォントを埋め込むための優先する（埋め込み）ルールを選択できます。このC++コードは、プレゼンテーションにフォントを埋め込み、追加する方法を示しています。

```c++
// プレゼンテーションをロード
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// 置き換えるソースフォントをロード
auto sourceFont = System::MakeObject<FontData>(u"Arial");

auto allFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (SharedPtr<IFontData> font : allFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&font](SharedPtr<IFontData> data) -> bool
    {
        return data == font;
    };

    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        presentation->get_FontsManager()->AddEmbeddedFont(font, EmbedFontCharacters::All);
    }
}

// プレゼンテーションをディスクに保存
presentation->Save(u"AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
```

## **埋め込みフォントを圧縮する**

プレゼンテーションに埋め込まれたフォントを圧縮し、ファイルサイズを削減するために、Aspose.Slidesは[CompressEmbeddedFonts()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/)メソッド（[Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)クラスによって公開）を提供しています。

このC++コードは、埋め込みPowerPointフォントを圧縮する方法を示しています。

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

Aspose::Slides::LowCode::Compress::CompressEmbeddedFonts(pres);
pres->Save(u"pres-out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```