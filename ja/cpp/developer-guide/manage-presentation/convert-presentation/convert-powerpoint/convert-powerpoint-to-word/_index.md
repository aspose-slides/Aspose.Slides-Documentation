---
title: C++ で PowerPoint プレゼンテーションを Word ドキュメントに変換
linktitle: PowerPoint から Word へ
type: docs
weight: 110
url: /ja/cpp/convert-powerpoint-to-word/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint から Word へ
- プレゼンテーションから Word へ
- スライドから Word へ
- PPT から Word へ
- PPTX から Word へ
- PowerPoint から DOCX へ
- プレゼンテーションから DOCX へ
- スライドから DOCX へ
- PPT から DOCX へ
- PPTX から DOCX へ
- PowerPoint から DOC へ
- プレゼンテーションから DOC へ
- スライドから DOC へ
- PPT から DOC へ
- PPTX から DOC へ
- PPT を DOCX として保存
- PPTX を DOCX として保存
- PPT を DOCX にエクスポート
- PPTX を DOCX にエクスポート
- C++
- Aspose.Slides
description: Aspose.Slides を使用して、C++ で PowerPoint の PPT および PPTX スライドを編集可能な Word ドキュメントに変換し、正確なレイアウト、画像、書式設定を保持します。
---
## **概要**

プレゼンテーション（PPTまたはPPTX）からテキストコンテンツや情報を新しい方法で使用することを検討している場合、プレゼンテーションをWord（DOCまたはDOCX）に変換するとメリットがあります。

* Microsoft PowerPoint と比較すると、Microsoft Word アプリはコンテンツ向けのツールや機能がより充実しています。
* Word の編集機能に加えて、コラボレーション、印刷、共有機能の向上も利用できます。

{{% alert color="info" %}} 

スライドのテキストコンテンツを操作することで得られるメリットを確認するために、[**スライドからWordへのオンライン変換ツール**](https://products.aspose.app/slides/ja/conversion/ppt-to-word)を試してみてください。

{{% /alert %}} 

## **Aspose.Slides と Aspose.Words**

PowerPoint ファイル（PPTX または PPT）を Word（DOCX または DOC）に変換するには、[Aspose.Slides for C++](https://products.aspose.com/slides/ja/cpp/) と [Aspose.Words for C++](https://products.aspose.com/words/cpp/) の両方が必要です。

スタンドアロン API として、C++ 用の [Aspose.Slides](https://products.aspose.app/slides) は、プレゼンテーションからテキストを抽出する機能を提供します。

[Aspose.Words](https://docs.aspose.com/words/cpp/) は、Microsoft Word を使用せずに、アプリケーションが文書を生成、変更、変換、レンダリング、印刷し、その他の処理を行える高度なドキュメント処理 API です。

## **PowerPoint プレゼンテーションを Word ドキュメントへ変換**

以下のコードスニペットを使用して、PowerPoint を Word に変換します。

```cpp
#include <Aspose.Words.Cpp/BreakType.h>
#include <Aspose.Words.Cpp/Document.h>
#include <Aspose.Words.Cpp/DocumentBuilder.h>
#include <DOM/AutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // スライド画像をバイト配列ストリームとして生成します
    auto image = slide->GetImage(1.0f, 1.0f);
    auto imageStream = MakeObject<System::IO::MemoryStream>();
    image->Save(imageStream, Aspose::Slides::ImageFormat::Png);
    image->Dispose();

    builder->InsertImage(imageStream->ToArray());

    // スライドのテキストを挿入します
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<AutoShape>(shape))
        {
            auto autoShape = System::AsCast<AutoShape>(shape);
            builder->Writeln(autoShape->get_TextFrame()->get_Text());
        }
    }

    builder->InsertBreak(Aspose::Words::BreakType::PageBreak);
}

doc->Save(u"output.docx");
presentation->Dispose();
```

## **FAQ**

### PowerPoint および OpenDocument プレゼンテーションを Word ドキュメントに変換するために必要なコンポーネントは何ですか？

プロジェクトに [Aspose.Slides for C++](https://releases.aspose.com/slides/ja/cpp/) と [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) の各パッケージを追加するだけで済みます。両ライブラリはスタンドアロン API として動作し、Microsoft Office をインストールする必要はありません。

### すべての PowerPoint および OpenDocument プレゼンテーション形式がサポートされていますか？

Aspose.Slides は、PPT、PPTX、ODP、その他の一般的なファイル形式を含むすべてのプレゼンテーション形式を[すべてのプレゼンテーション形式をサポート](/slides/ja/cpp/supported-file-formats/)しています。これにより、さまざまなバージョンの Microsoft PowerPoint で作成されたプレゼンテーションを扱うことができます。