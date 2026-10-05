---
title: C++ でプレゼンテーションを HTML5 に変換
linktitle: プレゼンテーションを HTML5 に変換
type: docs
weight: 40
url: /ja/cpp/export-to-html5/
keywords:
- PowerPoint を HTML5 に変換
- OpenDocument を HTML5 に変換
- プレゼンテーションを HTML5 に変換
- スライドを HTML5 に変換
- PPT を HTML5 に変換
- PPTX を HTML5 に変換
- ODP を HTML5 に変換
- PPT を HTML5 として保存
- PPTX を HTML5 として保存
- ODP を HTML5 として保存
- PPT を HTML5 にエクスポート
- PPTX を HTML5 にエクスポート
- ODP を HTML5 にエクスポート
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument のプレゼンテーションをレスポンシブな HTML5 にエクスポートします。書式、アニメーション、インタラクティブ性を保持します。"
---
## **概要**

この記事では、Aspose.Slides for C++ を使用して PowerPoint プレゼンテーションを HTML5 に変換する方法を説明します。基本的なエクスポート、図形アニメーションおよびスライド遷移の制御、コメントレイアウトについてカバーしています。また、HTML5 出力と標準 HTML エクスポートの SVG ベース出力を比較しています。

## **PowerPoint を HTML5 にエクスポート**

以下の例では、作業ディレクトリからプレゼンテーションを読み込み、HTML5 形式で保存します。デフォルトのエクスポート設定を使用します。次の例では、アニメーションの再生を明示的に制御する方法を示しています。入力パスはご自身のプレゼンテーションのパスに置き換えてください。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html5);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
HTML ドキュメントに加えて、エクスポートはスライドのスタイリング、アニメーション、効果、ナビゲーション用の CSS および JavaScript ファイルも出力します。出力を移動または公開する際は、これらのファイルを HTML ドキュメントと一緒に保持してください。生成されたページはパブリック CDN から jQuery と Anime.js を読み込みます。これらがないと、スライドのナビゲーションやアニメーションは動作しません。
{{% /alert %}}

図形アニメーションやスライド遷移を再生せずにエクスポートするには、[Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) の [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) と [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) に `false` を渡します。これらの設定は互いに独立しているため、一方を有効にし、もう一方を無効にすることができます。例では、生成されたページで両方のアニメーションタイプを無効にした状態でプレゼンテーションをエクスポートしています。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(false);
html5Options->set_AnimateTransitions(false);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **PowerPoint を HTML にエクスポート**

標準の HTML エクスポートは異なるレンダリング手法を使用します。スライドの内容は HTML ページ内の SVG として表現されます。以下の例では、このレンダリング手法を用いてプレゼンテーションを HTML ドキュメントに変換します。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html);
presentation->Dispose();
```

以下の簡略化されたマークアップは、生成されたページの構造を示しています。SVG 要素にはレンダリングされたスライドコンテンツが含まれます。プレースホルダーのテキストはそのコンテンツを表すもので、実際のエクスポート出力ではありません。

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
SVG ベースのエクスポートは PowerPoint の図形を個別の HTML 要素として公開しません。本記事で示した図形アニメーションやスライド遷移のオプションが必要な場合は、HTML5 エクスポートを使用してください。
{{% /alert %}}

## **PowerPoint を HTML5 スライドビューにエクスポート**

HTML5 エクスポートは、ブラウザでプレゼンテーションのスライドを閲覧およびナビゲートするためのページを生成します。この例では、[set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) と [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) の両方に `true` を渡し、エクスポートされたスライドビューが元のプレゼンテーションのエフェクトを再生できるようにしています。

図形アニメーションやスライド遷移が既に含まれているプレゼンテーションを使用すると、これらの設定の効果を確認できます。これらを有効にしても、元々エフェクトがないスライドに新しい効果が追加されることはありません。エクスポート後、サポートファイルが揃った状態で生成された HTML5 ドキュメントをブラウザで開いてください。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **コメント付きでプレゼンテーションを HTML5 ドキュメントに変換**

HTML5 出力に既存のスライドコメントを含めることができ、読者はスライド内容と共にフィードバックを確認できます。本節の例では、下図のようにコメントが含まれたソースプレゼンテーションを前提としています。コメントはエクスポートされますが、新たに作成されることはありません。

![プレゼンテーションスライド上の 2 つのコメント](two_comments_pptx.png)

プレゼンテーションのスライドコメントを右側に配置するには、[Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) の [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) メソッドに [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) オブジェクトを渡します。そして、[CommentsPositions](https://reference.aspose.com/slides/cpp/aspose.slides.export/commentspositions/) 列挙体の `CommentsPositions::Right` を使用して [set_CommentsPosition](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/set_commentsposition/) を呼び出します。

以下の例では、このコメントレイアウトを使用してプレゼンテーションを HTML5 にエクスポートします。コメントがないプレゼンテーションでは、表示するコメントテキストはありません。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/CommentsPositions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutOptions);

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

下の画像は、スライド横にコメントが表示されたエクスポートされた HTML5 ドキュメントを示しています。

![出力された HTML5 ドキュメントのコメント](two_comments_html5.png)

## **エクスポート時に JavaScript ハイパーリンクを除外**

`hyperlinks.pptx` に `javascript:alert('Hello')` をターゲットとしたリンクテキストと通常の `https://example.com/` リンクが含まれているとします。エクスポート時に JavaScript ハイパーリンクを除外するには、[SaveOptions::set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) に `true` を渡して呼び出します。デフォルトは `false` で、オプションを有効にしない限りこれらのリンクはフィルタリングされません。

以下の例では、作業ディレクトリからプレゼンテーションを読み込み、[Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) を使用してエクスポートします。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SkipJavaScriptLinks(true);

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");
presentation->Save(u"filtered-html5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

エクスポートされたファイルは JavaScript ハイパーリンクを除外しつつ、テキストと通常の HTTPS リンクは保持します。ソースのプレゼンテーションは変更されません。

このオプションは JavaScript ハイパーリンクのみをフィルタリングし、すべてのスクリプトやその他のアクティブコンテンツを削除するわけでも、CSP 準拠を保証するわけでもありません。たとえば、HTML5 出力にはスライドのナビゲーションやアニメーション用のスクリプトが依然として含まれます。

## **よくある質問**

**HTML5 でオブジェクトのアニメーションやスライド遷移の再生を制御できますか？**

はい、HTML5 エクスポートには、[図形アニメーション](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) と [スライド遷移](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) を個別に有効または無効にするオプションが用意されています。

**コメントはサポートされていますか？ また、スライドに対してどこに配置できますか？**

はい、既存のコメントは HTML5 出力に含めることができ、ノートやコメントの[レイアウト設定](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/)で（例としてスライドの右側に）配置できます。

**セキュリティや CSP の観点で、JavaScript を呼び出すリンクをスキップできますか？**

はい、[set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) メソッドを使用すると、保存時に JavaScript 呼び出しを含むハイパーリンクをスキップできます。デフォルトは `false` です。[エクスポート時に JavaScript ハイパーリンクを除外](/slides/ja/cpp/export-to-html5/#exclude-javascript-hyperlinks-during-export) を参照すると、HTML5 エクスポートの例とフィルタの対象範囲がわかります。この設定は、HTML5 ビューアがナビゲーションやアニメーションに使用する JavaScript を削除するものではありません。