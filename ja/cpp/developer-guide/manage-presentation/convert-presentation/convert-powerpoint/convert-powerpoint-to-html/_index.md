---
title: C++ で PowerPoint プレゼンテーションを HTML に変換する
linktitle: PowerPoint を HTML に変換
type: docs
weight: 30
url: /ja/cpp/convert-powerpoint-to-html/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を HTML に変換
- プレゼンテーションを HTML に変換
- スライドを HTML に変換
- PPT を HTML に変換
- PPTX を HTML に変換
- PowerPoint を HTML として保存
- プレゼンテーションを HTML として保存
- スライドを HTML として保存
- PPT を HTML として保存
- PPTX を HTML として保存
- PPT を HTML にエクスポート
- PPTX を HTML にエクスポート
- C++
- Aspose.Slides
description: "C++ で PowerPoint プレゼンテーションを HTML に変換します。Aspose.Slides を使用して PPT および PPTX ファイル、選択したスライド、ノート、フォント、画像、SVG、メディアをエクスポートできます。"
---
## **概要**

Aspose.Slides for C++ は Microsoft PowerPoint を使用せずに PowerPoint プレゼンテーションを HTML として保存できます。基本的な変換は単一の [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) のロードと、[SaveFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/saveformat/) を使用した `Save` 呼び出しです。エクスポートされたレイアウト、フォント、画像、ノート、コメント、SVG 出力、またはリンクされたリソースを制御する必要がある場合は、[HtmlOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/htmloptions/) を使用します。

このガイドでは、実用的な HTML エクスポートシナリオに焦点を当てます。

- プレゼンテーション全体または選択したスライドをエクスポートする。
- 固定レイアウト、レスポンシブ、または SVG ベースの HTML を生成する。
- スピーカーノートとコメントを含める。
- 画像品質と切り抜かれた画像データを制御する。
- フォントを埋め込むか、フォントファイルを別々に保存する。
- 外部リソースとメディアファイルの書き込みおよび参照方法を選択する。

既定では、HTML エクスポートはほとんどのリソースが埋め込まれた単一の HTML ドキュメントを生成します。これは 1 つのファイルで共有するのに便利ですが、出力サイズが大きくなる可能性があります。Web 公開の場合は、外部リソースの使用、画像 DPI の低減、ターゲット環境で確実に利用できないフォントのみを埋め込むことを検討してください。

## **プレゼンテーションを HTML に変換する**

プレゼンテーションを HTML にエクスポートするには、[Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) でロードし、`SaveFormat::Html` で保存します。

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->Save(u"presentation.html", SaveFormat::Html);

presentation->Dispose();
```

この例は 1 つの HTML ファイルを書き出します。`Dispose` の呼び出しは、エクスポート後にファイルハンドルとレンダリングリソースを解放します。

## **HtmlOptions の使用**

[HtmlOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/htmloptions/) は HTML エクスポート用の主要な構成クラスです。一般的な設定は以下のとおりです。

- `SlidesLayoutOptions`: ノート、コメント、配布資料、その他のレイアウト情報を追加します。
- `HtmlFormatter`: HTML ドキュメント構造を変更したり、フォーマッティングをコントローラに委譲したりします。
- `SlideImageFormat`: スライドの表現方法を変更します。例: SVG として。
- `PicturesCompression`: 画像の DPI と出力サイズを制御します。
- `DeletePicturesCroppedAreas`: 切り抜かれた画像データを保持または削除します。
- `SvgResponsiveLayout`: エクスポートされた SVG コンテンツがコンテナに適応するようにします。
- `ShowHiddenSlides`: 必要に応じて非表示スライドを含めます。

以下のセクションでは、最も一般的なオプションを個別に示すので、ワークフローで必要なものだけを組み合わせて使用できます。

## **選択したスライドを HTML に変換する**

`Presentation::Save` のスライド番号を受け取るオーバーロードは 1 から始まるスライド位置を使用します。以下のループは各スライドを個別の HTML ファイルとして保存します。

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slideNumber = slideIndex + 1;
    auto slideNumbers = System::MakeArray<int>({ slideNumber });
    auto htmlFileName = System::String::Format(u"slide-{0}.html", slideNumber);

    presentation->Save(htmlFileName, slideNumbers, SaveFormat::Html);
}

presentation->Dispose();
```

ウェブサイトやアプリケーションでスライドごとに 1 つの HTML ページが必要な場合にこのパターンを使用します。各スライドが同じレイアウトであるべき場合は、1 つの [HtmlOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/htmloptions/) インスタンスを作成し、各 `Save` 呼び出しに渡します。

## **レスポンシブ HTML を作成する**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/responsivehtmlcontroller/) は [HtmlFormatter](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/htmlformatter/) を通じてレスポンシブ HTML 出力を提供します。エクスポートされたページがブラウザの幅により適切に適応する必要がある場合に使用します。

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

SVG ベースのレスポンシブレイアウトの場合は、[HtmlOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/htmloptions/) の `SvgResponsiveLayout` を設定します。スライド内容がスケーラブルな SVG マークアップとしてエクスポートされる場合に便利です。

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SvgResponsiveLayout(true);

presentation->Save(u"presentation-svg-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **スピーカーノートとコメントを含める**

`HtmlOptions.SlidesLayoutOptions` を介して [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/notescommentslayoutingoptions/) を使用し、スピーカーノートまたはコメントを含めます。ノートとコメントはデフォルトで非表示で、位置を指定しない限り表示されません。

元のプレゼンテーションにスピーカーノートが含まれているとします。

![PowerPoint のスライド（スピーカーノート付き）](slide_with_notes.png)

以下のコードは、スライドコンテンツの下にスピーカーノートを付けてエクスポートします。

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomFull);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SlidesLayoutOptions(layoutOptions);

presentation->Save(u"presentation-with-notes.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

![スライドとスピーカーノートを含む HTML 出力](HTML_with_notes.png)

コメントをエクスポートするには、`CommentsPosition` を設定します。例として `CommentsPositions::Right` または `CommentsPositions::Bottom` があります。コメントだけが必要な場合は `NotesPosition` を省略します。ノートとコメントの両方が必要な場合は、両方のプロパティを設定します。

## **画像品質と切り抜き領域の制御**

HTML エクスポートはスライド画像を圧縮して出力サイズを削減できます。より高い画像品質が必要な場合は、[PicturesCompression](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/picturescompression/) から値を選んで `PicturesCompression` を設定します。

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_PicturesCompression(PicturesCompression::Dpi150);

presentation->Save(u"presentation-dpi-150.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

既定では、画像の切り抜き領域はエクスポート出力から削除される可能性があります。ユーザーが隠された画像部分を復元または検査できる必要がある場合のみ、切り抜きデータを保持してください。保持すると HTML サイズが増加することがあります。

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_DeletePicturesCroppedAreas(false);

presentation->Save(u"presentation-with-cropped-areas.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **CSS の追加**

シンプルなスタイリングの場合は、CSS 文字列を `HtmlFormatter::CreateDocumentFormatter` に渡します。これにより、Aspose.Slides がスライドコンテンツのレンダリングを続行しながら、周囲の HTML ドキュメントが変更されます。

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto cssRules = u"body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
auto formatter = HtmlFormatter::CreateDocumentFormatter(cssRules, true);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-styled.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

カスタムのドキュメントヘッダー、リンクされた CSS ファイル、またはスライドやシェイプ周りのカスタムマークアップが必要な場合は、[IHtmlFormattingController](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/ihtmlformattingcontroller/) を実装し、`CreateCustomFormatter` と共に [HtmlFormatter](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/htmlformatter/) に渡します。

## **フォントの埋め込み**

ターゲット環境にプレゼンテーションのフォントがインストールされていない可能性がある場合は、[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/embedallfontshtmlcontroller/) を使用して HTML にフォントを埋め込みます。埋め込みにより視覚的忠実度は向上しますが、出力サイズが増加します。

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto fontNamesToExclude = System::MakeArray<System::String>({ u"Arial" });
auto fontController = System::MakeObject<EmbedAllFontsHtmlController>(fontNamesToExclude);
auto formatter = HtmlFormatter::CreateCustomFormatter(fontController);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-embedded-fonts.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

対象のブラウザやシステムがすでにフォントを提供していると確信できる場合にのみ、フォントを除外してください。ブランドフォントや一般的でないフォントの場合、埋め込みの方が通常は安全です。

## **フォントを埋め込む代わりにフォントファイルをリンクする**

HTML ファイルのサイズを削減するために、フォントデータを別々の WOFF ファイルに書き出し、HTML に `@font-face` ルールを追加できます。以下のヘルパーは [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/embedallfontshtmlcontroller/) を拡張し、`WriteFont` をオーバーライドします。

```cpp
class LinkedFontsHtmlController : public EmbedAllFontsHtmlController
{
public:
    LinkedFontsHtmlController(
        System::String fontOutputDirectory,
        System::String fontUrlPrefix)
        : EmbedAllFontsHtmlController(System::MakeArray<System::String>(0)),
          m_fontOutputDirectory(fontOutputDirectory),
          m_fontUrlPrefix(fontUrlPrefix.TrimEnd(u'/') + u"/")
    {
        System::IO::Directory::CreateDirectory_(m_fontOutputDirectory);
    }

    void WriteFont(
        System::SharedPtr<IHtmlGenerator> generator,
        System::SharedPtr<IFontData> originalFont,
        System::SharedPtr<IFontData> substitutedFont,
        System::String fontStyle,
        System::String fontWeight,
        System::ArrayPtr<uint8_t> fontData) override
    {
        auto font = substitutedFont == nullptr ? originalFont : substitutedFont;
        auto safeFontName = MakeSafeFileName(font->get_FontName());
        auto safeFontStyle = System::String::IsNullOrWhiteSpace(fontStyle) ? u"normal" : fontStyle;
        auto safeFontWeight = System::String::IsNullOrWhiteSpace(fontWeight) ? u"normal" : fontWeight;
        auto fontFileName = System::String::Format(u"{0}-{1}-{2}.woff", safeFontName, safeFontStyle, safeFontWeight);
        auto fontFilePath = System::IO::Path::Combine(m_fontOutputDirectory, fontFileName);

        System::IO::File::WriteAllBytes(fontFilePath, fontData);

        auto fontUrl = m_fontUrlPrefix + System::Uri::EscapeDataString(fontFileName);
        auto fontFamily = font->get_FontName().Replace(u"\\", u"\\\\").Replace(u"'", u"\\'");

        generator->AddHtml(u"<style>");
        generator->AddHtml(u"@font-face {");
        generator->AddHtml(System::String::Format(u"font-family: '{0}';", fontFamily));
        generator->AddHtml(System::String::Format(u"font-style: {0};", safeFontStyle));
        generator->AddHtml(System::String::Format(u"font-weight: {0};", safeFontWeight));
        generator->AddHtml(System::String::Format(u"src: url('{0}') format('woff');", fontUrl));
        generator->AddHtml(u"}");
        generator->AddHtml(u"</style>");
    }

private:
    System::String m_fontOutputDirectory;
    System::String m_fontUrlPrefix;

    System::String MakeSafeFileName(System::String fileName)
    {
        auto invalidCharacters = System::IO::Path::GetInvalidFileNameChars();
        auto safeCharacters = fileName.ToCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters->get_Length(); characterIndex++)
        {
            if (System::Array<int16_t>::IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = u'_';
            }
        }

        return System::String(safeCharacters);
    }
};

auto outputDirectory = System::IO::Path::Combine(System::Environment::get_CurrentDirectory(), u"html-output");
auto fontsDirectory = System::IO::Path::Combine(outputDirectory, u"fonts");
System::IO::Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto fontController = System::MakeObject<LinkedFontsHtmlController>(fontsDirectory, u"fonts");
auto formatter = HtmlFormatter::CreateCustomFormatter(fontController);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

auto htmlFilePath = System::IO::Path::Combine(outputDirectory, u"presentation.html");
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

この例では、フォントファイルは `html-output/fonts` に保存され、HTML は `fonts/BrandFont-normal-400.woff` のような URL で参照します。HTML ファイルとフォントが別の場所にデプロイされる場合は、`fontUrlPrefix` を選択してデプロイされた URL パスと一致させます。

## **リソースを外部に保存する**

自己完結型 HTML は移動が容易ですが、埋め込まれた Base64 リソースによりファイルが大きくなることがあります。アプリケーションで外部画像ファイルが必要な場合は、[ILinkEmbedController](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/ilinkembedcontroller/) を実装し、[HtmlOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/htmloptions/) コンストラクタに渡します。

リソースを外部化する際は、次の 2 つのパスを注意深く選択します。

- ファイルシステムの出力パス。アプリケーションが生成した画像、フォント、音声、動画を書き込む場所。
- URL パス。ブラウザが HTML ドキュメントからそれらのファイルをロードする際に使用するパス。

## **メディアファイルのエクスポート**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/videoplayerhtmlcontroller/) はビデオおよびオーディオファイルをエクスポートし、ブラウザで再生できる HTML を生成します。そのコンストラクタは次のパラメータを受け取ります：

- `path`: 生成されたメディアファイルを書き込むディレクトリ。
- `fileName`: 生成中の HTML ファイル名。
- `baseUri`: メディアファイルへの HTML リンクで使用される絶対 URI プレフィックス。

HTML ファイルが `html-output/presentation.html` で、メディアファイルが `html-output/media` に保存されている場合、`path` はディスク上のメディアディレクトリを指し、`baseUri` はブラウザ側から見た同じディレクトリを指す必要があります。ローカルプレビューの場合は、メディアディレクトリから `file:///` URI を構築できます。デプロイされたアプリケーションでは、公開されたメディアディレクトリの絶対 URL を使用します。

```cpp
auto outputDirectory = System::IO::Path::Combine(System::Environment::get_CurrentDirectory(), u"html-output");
auto mediaDirectory = System::IO::Path::Combine(outputDirectory, u"media");
System::IO::Directory::CreateDirectory_(outputDirectory);
System::IO::Directory::CreateDirectory_(mediaDirectory);

auto htmlFileName = u"presentation.html";
auto mediaBaseUri = System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri();

auto presentation = System::MakeObject<Presentation>();
auto videoStream = System::MakeObject<System::IO::FileStream>(u"intro.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);

auto video = presentation->get_Videos()->AddVideo(videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddVideoFrame(20.0f, 20.0f, 480.0f, 270.0f, video);

auto controller = System::MakeObject<VideoPlayerHtmlController>(mediaDirectory, htmlFileName, mediaBaseUri);
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);
auto svgOptions = System::MakeObject<SVGOptions>(controller);
auto slideImageFormat = SlideImageFormat::Svg(svgOptions);

auto htmlOptions = System::MakeObject<HtmlOptions>(controller);
htmlOptions->set_HtmlFormatter(formatter);
htmlOptions->set_SlideImageFormat(slideImageFormat);

auto htmlFilePath = System::IO::Path::Combine(outputDirectory, htmlFileName);
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);

videoStream->Dispose();
presentation->Dispose();
```

特にサーバーアプリケーションでは、エクスポートジョブごとに固有の出力ディレクトリを使用してください。共有出力パスを使用すると、異なる変換のファイルが上書きされる恐れがあります。

## **パフォーマンスとリソース管理**

HTML 変換はレンダリング操作であるため、処理時間とメモリ使用量はスライド数、画像解像度、フォント、エフェクト、チャート、埋め込みメディアに依存します。`PicturesCompression` の DPI 値を高くしたり、フォントを埋め込んだり、SVG 出力や切り抜き画像領域を保持したりすると忠実度は向上しますが、通常は出力サイズが増加します。

バッチ変換の場合：

- `Presentation` インスタンスは速やかに `Dispose` してください。
- ジョブごとに別々の出力ディレクトリを使用します。
- 忠実度が必要でない限り、一般的なフォントの埋め込みは避けます。
- HTML がプレビューやサムネイル用の場合は、画像 DPI を下げます。
- デプロイパスが確定するまで、元のプレゼンテーション、生成された HTML、外部リソースを一緒に保管します。

## **FAQ**

**HTML 出力でハイパーリンクは保持されますか？**

はい。プレゼンテーションのハイパーリンクは HTML にエクスポートされ、対象 URL が有効な場合はクリック可能なままです。

**プレゼンテーションを並行して HTML に変換できますか？**

はい、ただしスレッド間で同じ [Presentation] インスタンスを共有しないでください。異なるファイルは別々のプレゼンテーションインスタンス、別々のストリーム、別々の出力ディレクトリで処理します。詳細は [マルチスレッドガイダンス](/slides/ja/cpp/multithreading/) を参照してください。

**Presentation オブジェクトはスレッドセーフですか？**

いいえ。単一の [Presentation] インスタンスは、1 つのスレッド上でロード、変更、保存、および破棄する必要があります。並列作業の場合は、スレッドまたはプロセスごとに独立したインスタンスを作成してください。

**生成された HTML ファイルが大きいのはなぜですか？**

既定のエクスポートはリソースを直接 HTML に埋め込むため、ファイルサイズが大きくなることがあります。埋め込まれたフォント、高 DPI 画像、メディア、SVG コンテンツ、切り抜き画像領域の保持もサイズ増加の要因です。出力サイズを小さくすることが最大忠実度より重要な場合は、外部リソースの使用、共通フォントの埋め込み除外、`PicturesCompression` の低減を行ってください。

**メディアエクスポートの baseUri はどのように選択すべきですか？**

`baseUri` はブラウザ側の視点から選択し、絶対 URI として渡してください。ローカルプレビューの場合は、`System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri()` で出力ディレクトリから派生させることができます。デプロイ時は、公開されたメディアディレクトリの絶対 URL を使用します。ファイルシステムの `path` とブラウザの `baseUri` は同じ文字列である必要はありませんが、同一のリソース位置を指し示す必要があります。

**非表示スライドを含めることはできますか？**

はい。非表示スライドをエクスポートする必要がある場合は、[HtmlOptions] の `ShowHiddenSlides` を `true` に設定してください。