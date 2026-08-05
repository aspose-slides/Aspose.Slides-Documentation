---
title: C++ でプレゼンテーションにフォントを埋め込む
linktitle: フォントの埋め込み
type: docs
weight: 40
url: /ja/cpp/embedded-font/
keywords:
- フォントを追加
- フォントを埋め込む
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
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument のプレゼンテーションに TrueType フォントを埋め込み、すべてのプラットフォームで正確なレンダリングを保証します。"
---
## **概要**

**PowerPoint の埋め込みフォント**は、プレゼンテーションを任意のシステムやデバイスで開いたときに、意図した外観を保つのに役立ちます。これは、ブランドやクリエイティブ目的でカスタムフォント、サードパーティ製フォント、非標準フォントを使用する場合に特に重要です。埋め込みフォントがないと、テキストが置き換えられ、レイアウトが崩れ、文字が読めない記号や四角形として表示され、全体のデザインが損なわれます。

Aspose.Slides for C++ は、埋め込みフォントをプログラムで管理するための強力な API を提供します。`[FontsManager](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsmanager/)` と `[FontData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontdata/)` クラスを使用して、プレゼンテーションファイル内の埋め込みフォントを検査、追加、削除できます。また、`[Compress](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/compress/)` クラスを使えば、品質や外観に影響を与えずにフォントデータを圧縮してファイルサイズを最適化できます。

これらのツールを使うことで、フォント埋め込みを完全に制御でき、必要に応じてファイルサイズを削減しながら、プラットフォーム間で一貫したタイポグラフィを維持できます。

## **プレゼンテーションから埋め込みフォントを取得する**

Aspose.Slides for C++ は、`[FontsManager](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsmanager/)` クラスの `GetEmbeddedFonts` メソッドを通じて、PowerPoint プレゼンテーションに埋め込まれたフォントの一覧を取得できます。これは、フォント使用状況の監査、ブランドガイドラインへの準拠確認、またはファイル共有前に必要なフォントがすべて正しく含まれているかを検証する際に便利です。

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

## **プレゼンテーションに埋め込みフォントを追加する**

Aspose.Slides for C++ は、`[AddEmbeddedFont](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsmanager/addembeddedfont/)` メソッドを使って PowerPoint プレゼンテーションにフォントを埋め込むことができます。このメソッドは柔軟な使用を可能にする 2 つのオーバーロードを提供します。`[EmbedFontCharacters](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/embedfontcharacters/)` 列挙型を使用して、埋め込む文字の範囲（使用された文字のみ、またはフォント全体など）を制御できます。この機能は、プレゼンテーションを共有または配布する際に、カスタムフォントや非標準フォントがすべてのシステムで正しく表示されるようにするのに特に有用です。

以下の C++ コードは、プレゼンテーションで使用されているすべてのフォントをチェックし、まだ埋め込まれていないフォントを埋め込む例です。

```cpp
// プレゼンテーション ファイルを読み込みます。
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

## **プレゼンテーションから埋め込みフォントを削除する**

Aspose.Slides for C++ は、`[FontsManager](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsmanager/)` クラスの `RemoveEmbeddedFont` メソッドを通じて、PowerPoint プレゼンテーションに埋め込まれた特定のフォントを削除できます。これにより、埋め込まれたフォントがもはや使用されていない場合や不要な場合に、全体のファイルサイズを削減できます。未使用フォントを削除すると、パフォーマンスが向上し、プレゼンテーションに必須のリソースだけが含まれるようになります。

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
        //        埋め込みフォントを削除します。
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

## **埋め込みフォントを圧縮する**

Aspose.Slides for C++ は、`[Compress](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/compress/)` クラスの `CompressEmbeddedFonts` メソッドを提供し、埋め込みフォントデータを最適化してプレゼンテーション全体のファイルサイズを削減できます。これは、サイズの大きいフォントや複数のフォントを含むプレゼンテーションを、共有、保存、オンライン使用のために軽量に保ちたい場合に特に有用で、コンテンツの視覚的忠実度を損なうことはありません。

以下の C++ コードは、PowerPoint プレゼンテーションの埋め込みフォントを圧縮する方法を示しています。

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**埋め込みが行われているにもかかわらず、特定のフォントが描画時に置き換えられるかどうかを確認する方法はありますか？**

フォントマネージャーの **[substitution information](/slides/ja/cpp/font-substitution/)** と **[fallback/substitution rules](/slides/ja/cpp/fallback-font/)** を確認してください。フォントが利用できない、または制限されている場合はフォールバックが使用されます。

**Arial や Calibri などの「システム」フォントを埋め込む価値はありますか？**

通常はありません。これらのフォントはほぼ常に利用可能です。ただし、Docker コンテナやフォントが事前にインストールされていない Linux サーバーなど、極限環境での完全なポータビリティが必要な場合は、システムフォントを埋め込むことで予期しない置き換えリスクを排除できます。