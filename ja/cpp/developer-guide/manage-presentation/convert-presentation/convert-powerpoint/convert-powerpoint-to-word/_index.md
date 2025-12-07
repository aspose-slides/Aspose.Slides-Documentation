---
title: "C++ で PowerPoint プレゼンテーションを Word 文書に変換"
linktitle: "PowerPoint から Word へ"
type: docs
weight: 110
url: /ja/cpp/convert-powerpoint-to-word/
keywords:
- "PowerPoint を変換"
- "プレゼンテーションを変換"
- "スライドを変換"
- "PPT を変換"
- "PPTX を変換"
- "PowerPoint から Word へ"
- "プレゼンテーションを Word に"
- "スライドを Word に"
- "PPT を Word に"
- "PPTX を Word に"
- "PowerPoint を DOCX に"
- "プレゼンテーションを DOCX に"
- "スライドを DOCX に"
- "PPT を DOCX に"
- "PPTX を DOCX に"
- "PowerPoint を DOC に"
- "プレゼンテーションを DOC に"
- "スライドを DOC に"
- "PPT を DOC に"
- "PPTX を DOC に"
- "PPT を DOCX として保存"
- "PPTX を DOCX として保存"
- "PPT を DOCX にエクスポート"
- "PPTX を DOCX にエクスポート"
- "C++"
- "Aspose.Slides"
description: "Aspose.Slides を使用し、C++ で PowerPoint の PPT および PPTX スライドを編集可能な Word 文書に変換し、レイアウト、画像、書式設定を正確に保持します。"
---

もしプレゼンテーション（PPT または PPTX）からテキストコンテンツや情報を新しい方法で使用する予定がある場合、プレゼンテーションを Word（DOC または DOCX）に変換すると便利です。

* Microsoft PowerPoint と比較すると、Microsoft Word アプリはコンテンツ向けのツールや機能がより充実しています。
* Word の編集機能に加えて、コラボレーション、印刷、共有機能も強化されています。

{{% alert color="primary" %}} 
スライドのテキストコンテンツを活用した際に得られるメリットを確認するために、[**プレゼンテーションからWordへのオンラインコンバータ**](https://products.aspose.app/slides/conversion/ppt-to-word) をお試しください。 
{{% /alert %}} 

## **Aspose.Slides と Aspose.Words**

PowerPoint ファイル（PPTX または PPT）を Word（DOCX または DOCX）に変換するには、[Aspose.Slides for C++](https://products.aspose.com/slides/cpp/) と [Aspose.Words for C++](https://products.aspose.com/words/cpp/) の両方が必要です。

スタンドアロン API として、[Aspose.Slides](https://products.aspose.app/slides) for C++ はプレゼンテーションからテキストを抽出する機能を提供します。

[Aspose.Words](https://docs.aspose.com/words/cpp/) は高度な文書処理 API で、アプリケーションが Microsoft Word を使用せずに、文書の生成、変更、変換、レンダリング、印刷、その他のタスクを行うことを可能にします。

## **PowerPoint プレゼンテーションを Word ドキュメントに変換**

Use this code snippet to convert the PowerPoint to Word:
```cpp
auto presentation = MakeObject<Presentation>();
auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // スライド画像を生成して挿入します
    auto image = slide->GetImage(1.0f, 1.0f);
    builder->InsertImage(image);

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
```


## **FAQ**

**PowerPoint および OpenDocument プレゼンテーションを Word ドキュメントに変換するためにインストールが必要なコンポーネントは何ですか？**

プロジェクトに [Aspose.Slides for C++](https://releases.aspose.com/slides/cpp/) と [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) の各パッケージを追加するだけで済みます。両ライブラリはスタンドアロン API として動作し、Microsoft Office のインストールは不要です。

**すべての PowerPoint および OpenDocument プレゼンテーション形式がサポートされていますか？**

Aspose.Slides は [すべてのプレゼンテーション形式をサポート](/slides/ja/cpp/supported-file-formats/) しており、PPT、PPTX、ODP などの一般的なファイルタイプをすべてサポートしています。これにより、さまざまなバージョンの Microsoft PowerPoint で作成されたプレゼンテーションを扱うことができます。