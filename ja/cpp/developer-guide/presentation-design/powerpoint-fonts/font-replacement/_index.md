---
title: フォント置換
type: docs
weight: 60
url: /cpp/font-replacement/
keywords: "フォント, フォントを置き換える, PowerPointプレゼンテーション, C++, CPP, Aspose.Slides for C++"
description: "C++でPowerPointのフォントを明示的に置き換える"
---

フォントの使用を変更する場合は、そのフォントを別のフォントに置き換えることができます。旧フォントのすべてのインスタンスは新フォントに置き換えられます。

Aspose.Slidesを使用すると、このようにフォントを置き換えることができます：

1. 関連するプレゼンテーションをロードします。
2. 置き換えられるソースフォントをロードします。
3. 新しいフォントをロードします。
4. フォントを置き換えます。
5. 修正されたプレゼンテーションをPPTXファイルとして保存します。

このC++コードはフォント置換を示しています：

``` cpp
// プレゼンテーションをロードします
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// 置き換えられるソースフォントをロードします
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// 新しいフォントをロードします
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// フォントを置き換えます
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// プレゼンテーションを保存します
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```

{{% alert title="注意" color="warning" %}} 

特定の条件下で何が起こるかを決定するルールを設定するには（例えば、フォントにアクセスできない場合など）、[**フォント置換**](/slides/cpp/font-substitution/)を参照してください。

{{% /alert %}}