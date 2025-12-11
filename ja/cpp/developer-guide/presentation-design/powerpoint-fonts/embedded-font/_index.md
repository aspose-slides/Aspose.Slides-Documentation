---
title: C++ を使用したプレゼンテーションへのフォント埋め込み
linktitle: フォントの埋め込み
type: docs
weight: 40
url: /ja/cpp/embedded-font/
keywords:
- フォントを追加
- フォントを埋め込み
- フォント埋め込み
- 埋め込みフォントを取得
- 埋め込みフォントを追加
- 埋め込みフォントを削除
- 埋め込みフォントを圧縮
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument プレゼンテーションに TrueType フォントを埋め込み、すべてのプラットフォームで正確にレンダリングされるようにします。"
---

## **概要**

**PowerPoint の埋め込みフォント**は、任意のシステムやデバイスでプレゼンテーションを開いたときに、意図した外観が維持されるようにします。これは、ブランドやクリエイティブ目的でカスタム、サードパーティ、または非標準フォントを使用する場合に特に重要です。埋め込みフォントがないと、テキストが置換され、レイアウトが崩れ、文字が読めない記号や四角形として表示され、全体的なデザインが損なわれます。

Aspose.Slides for C++ は、埋め込みフォントをプログラムで管理するための強力な API を提供します。`[FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/)` と `[FontData](https://reference.aspose.com/slides/cpp/aspose.slides/fontdata/)` クラスを使用して、プレゼンテーション ファイル内の埋め込みフォントを検査、追加、削除できます。また、`[Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)` クラスを使用すると、品質や外観に影響を与えることなくフォント データを圧縮してファイル サイズを最適化できます。

これらのツールにより、フォント埋め込みを完全に制御でき、プラットフォーム間で一貫したタイポグラフィを維持しながら、必要に応じてファイル サイズを削減できます。

## **プレゼンテーションからの埋め込みフォントの取得**

Aspose.Slides for C++ は、`[FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/)` クラスを通じて `GetEmbeddedFonts` メソッドを提供し、PowerPoint プレゼンテーションに埋め込まれたフォントの一覧を取得できます。これは、フォント使用状況の監査、ブランド ガイドラインへの準拠確認、またはファイル共有前に必要なフォントがすべて正しく含まれているかを検証する際に便利です。

以下の C++ コードは、プレゼンテーション ファイルから埋め込みフォントを取得する方法を示しています。
```cpp
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// すべての埋め込みフォントを取得します。
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// 埋め込みフォントの名前を出力します。
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```


## **プレゼンテーションへの埋め込みフォントの追加**

Aspose.Slides for C++ は、`[AddEmbeddedFont](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/addembeddedfont/)` メソッドを使用して PowerPoint プレゼンテーションにフォントを埋め込むことができます。このメソッドは柔軟な使用のために 2 つのオーバーロードが用意されています。`[EmbedFontCharacters](https://reference.aspose.com/slides/cpp/aspose.slides.export/embedfontcharacters/)` 列挙体を使用して、使用された文字だけを埋め込むかフォント全体を埋め込むかを制御できます。この機能は、プレゼンテーションを共有または配布する際に特に有用で、カスタムまたは非標準フォントがインストールされていないシステムでも正しく表示されるようにします。

以下の C++ コードは、プレゼンテーションで使用されているすべてのフォントをチェックし、まだ埋め込まれていないフォントを埋め込みます。
```cpp
// プレゼンテーション ファイルをロードします。
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto usedFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : usedFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&fontData](SharedPtr<IFontData> data) -> bool
        {
            return data == fontData;
        };

    // フォントがすでに埋め込まれているか確認します。
    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        // フォントをプレゼンテーションに埋め込みます。
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// プレゼンテーションをディスクに保存します。
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **プレゼンテーションからの埋め込みフォントの削除**

Aspose.Slides for C++ は、`[FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/)` クラスを通じて `RemoveEmbeddedFont` メソッドを提供し、PowerPoint プレゼンテーションに埋め込まれた特定のフォントを削除できます。これにより、埋め込まれたフォントがもはや使用されていない、または不要な場合に、全体のファイル サイズを削減できます。未使用フォントの削除は、パフォーマンスの向上と、プレゼンテーションに必須のリソースだけが含まれることを保証するのにも役立ちます。

以下の C++ コードは、プレゼンテーションから埋め込みフォントを削除する方法を示しています。
```cpp
auto fontName = u"Calibri";

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// すべての埋め込みフォントを取得します。
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // 埋め込みフォントを削除します。
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```


## **埋め込みフォントの圧縮**

Aspose.Slides for C++ は、`[Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)` クラスを通じて `CompressEmbeddedFonts` メソッドを提供し、埋め込みフォント データを最適化してプレゼンテーションの全体的なファイル サイズを削減できます。これは、プレゼンテーションに大きなフォントや複数のフォントが含まれている場合に特に有用で、共有、保存、オンライン使用のためにファイルを軽量に保ちつつ、コンテンツの視覚的忠実度を損なうことなく実現できます。

以下の C++ コードは、PowerPoint プレゼンテーションで埋め込みフォントを圧縮する方法を示しています。
```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **よくある質問**

**プレゼンテーション内の特定のフォントが埋め込みにもかかわらず描画時に置換される可能性があるかどうか、どのように確認できますか？**

`[フォント置換情報](/slides/ja/cpp/font-substitution/)` と `[フォールバック/置換ルール](/slides/ja/cpp/fallback-font/)` をフォント マネージャで確認してください。フォントが利用できない、または制限されている場合はフォールバックが使用されます。

**Arial や Calibri といった「システム」フォントを埋め込む価値はありますか？**

通常はありません—これらのフォントはほぼ常に利用可能です。ただし、「薄い」環境（Docker、フォントが事前にインストールされていない Linux サーバーなど）での完全な移植性が必要な場合は、システム フォントを埋め込むことで予期しない置換のリスクを排除できます。