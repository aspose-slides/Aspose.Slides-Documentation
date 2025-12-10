---
title: C++ で PowerPoint プレゼンテーションを Word 文書に変換
linktitle: PowerPoint を Word に変換
type: docs
weight: 110
url: /ja/cpp/convert-powerpoint-to-word/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を Word に変換
- プレゼンテーションを Word に変換
- スライドを Word に変換
- PPT を Word に変換
- PPTX を Word に変換
- PowerPoint を DOCX に変換
- プレゼンテーションを DOCX に変換
- スライドを DOCX に変換
- PPT を DOCX に変換
- PPTX を DOCX に変換
- PowerPoint を DOC に変換
- プレゼンテーションを DOC に変換
- スライドを DOC に変換
- PPT を DOC に変換
- PPTX を DOC に変換
- PPT を DOCX として保存
- PPTX を DOCX として保存
- PPT を DOCX にエクスポート
- PPTX を DOCX にエクスポート
- C++
- Aspose.Slides
description: "C++ で Aspose.Slides を使用して、PowerPoint の PPT および PPTX スライドを編集可能な Word 文書に変換し、レイアウト、画像、書式設定を正確に保持します。"
---

プレゼンテーション（PPT または PPTX）からテキストコンテンツや情報を新しい方法で使用する予定がある場合、プレゼンテーションを Word（DOC または DOCX）に変換すると利点があります。

* Microsoft PowerPoint と比較すると、Microsoft Word アプリはコンテンツ向けのツールや機能がより充実しています。
* Word の編集機能に加えて、コラボレーション、印刷、共有機能も強化されています。

{{% alert color="primary" %}}
スライドのテキストコンテンツを活用して得られるメリットを確認するために、当社の[**Presentation to Word Online Converter**](https://products.aspose.app/slides/conversion/ppt-to-word) を試してみてください。
{{% /alert %}}

## **Aspose.Slides と Aspose.Words**

PowerPoint ファイル（PPTX または PPT）を Word（DOCX または DOC）に変換するには、[Aspose.Slides for C++](https://products.aspose.com/slides/cpp/) と [Aspose.Words for C++](https://products.aspose.com/words/cpp/) の両方が必要です。

単独 API としての [Aspose.Slides](https://products.aspose.app/slides) for C++ は、プレゼンテーションからテキストを抽出する機能を提供します。

[Aspose.Words](https://docs.aspose.com/words/cpp/) は高度な文書処理 API で、アプリケーションが Microsoft Word を使用せずに、文書の生成、変更、変換、レンダリング、印刷、その他のタスクを実行できます。

## **PowerPoint プレゼンテーションを Word 文書に変換**

PowerPoint を Word に変換するには、以下のコードスニペットを使用してください。
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

**PowerPoint と OpenDocument プレゼンテーションを Word 文書に変換するためにインストールが必要なコンポーネントは何ですか？**

プロジェクトに [Aspose.Slides for C++](https://releases.aspose.com/slides/cpp/) と [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) の各パッケージを追加するだけです。両ライブラリは単独 API として動作し、Microsoft Office をインストールする必要はありません。

**すべての PowerPoint および OpenDocument プレゼンテーション形式がサポートされていますか？**

Aspose.Slides は [すべてのプレゼンテーション形式](/slides/ja/cpp/supported-file-formats/) をサポートしており、PPT、PPTX、ODP などの一般的なファイルタイプが含まれます。これにより、さまざまなバージョンの Microsoft PowerPoint で作成されたプレゼンテーションを扱うことができます。