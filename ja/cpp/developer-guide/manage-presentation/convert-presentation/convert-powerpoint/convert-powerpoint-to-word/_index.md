---
title: PowerPointをWordに変換
type: docs
weight: 110
url: /cpp/convert-powerpoint-to-word/
keywords: "PowerPointの変換, PPT, PPTX, プレゼンテーション, Word, DOCX, DOC, PPTXをDOCXに, PPTをDOCに, PPTXをDOCに, PPTをDOCXに, C++, Aspose.Slides"
description: "C++でPowerPointプレゼンテーションをWordに変換"
---

プレゼンテーション（PPTまたはPPTX）からテキストコンテンツまたは情報を新しい方法で使用する予定がある場合、プレゼンテーションをWord（DOCまたはDOCX）に変換することで利益を得ることができます。

* Microsoft PowerPointと比較して、Microsoft Wordアプリはコンテンツ用のツールや機能がより充実しています。
* Wordの編集機能に加えて、コラボレーション、印刷、共有機能の向上も期待できます。

{{% alert color="primary" %}}

スライドからのテキストコンテンツを扱うことで得られるものを確認するために、[**プレゼンテーションをWordにオンライン変換するツール**](https://products.aspose.app/slides/conversion/ppt-to-word)を試してみると良いでしょう。

{{% /alert %}}

### **Aspose.SlidesとAspose.Words**

PowerPointファイル（PPTXまたはPPT）をWord（DOCXまたはDOCX）に変換するには、[Aspose.Slides for C++](https://products.aspose.com/slides/cpp/)と[Aspose.Words for C++](https://products.aspose.com/words/cpp/)の両方が必要です。

スタンドアロンAPIとして、C++用の[Aspose.Slides](https://products.aspose.app/slides)は、プレゼンテーションからテキストを抽出するための機能を提供します。

[Aspose.Words](https://docs.aspose.com/words/cpp/)は、高度な文書処理APIで、アプリケーションがMicrosoft Wordを利用せずにファイルを生成、変更、変換、レンダリング、印刷し、文書に関する他のタスクを実行できるようにします。

## **PowerPointをWordに変換**

以下のコードスニペットを使用して、PowerPointをWordに変換します：

```cpp
auto presentation = MakeObject<Presentation>();
auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // スライド画像を生成して挿入
    auto image = slide->GetImage(1.0f, 1.0f);
    builder->InsertImage(image);

    // スライドのテキストを挿入
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