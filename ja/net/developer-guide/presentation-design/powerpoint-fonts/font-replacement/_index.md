---
title: フォント置き換え - PowerPoint C# API
linktitle: フォント置き換え
type: docs
weight: 60
url: /net/font-replacement/
keywords: "フォント, フォントを置き換える, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: C# PowerPoint APIを使用すると、プレゼンテーション内で別のフォントに明示的にフォントを置き換えることができます。
---

フォントの使用について考えを変えた場合、古いフォントを別のフォントに置き換えることができます。古いフォントのすべてのインスタンスが新しいフォントに置き換えられます。

Aspose.Slidesでは、次の方法でフォントを置き換えることができます：

1. 関連するプレゼンテーションをロードします。
2. 置き換えられるフォントをロードします。
3. 新しいフォントをロードします。
4. フォントを置き換えます。
5. 修正されたプレゼンテーションをPPTXファイルとして保存します。

このC#コードはフォント置き換えを示しています：

```c#
// プレゼンテーションを読み込む
Presentation presentation = new Presentation("Fonts.pptx");

// 置き換えられるソースフォントを読み込む
IFontData sourceFont = new FontData("Arial");

// 新しいフォントを読み込む
IFontData destFont = new FontData("Times New Roman");

// フォントを置き換える
presentation.FontsManager.ReplaceFont(sourceFont, destFont);

// プレゼンテーションを保存する
presentation.Save("UpdatedFont_out.pptx", SaveFormat.Pptx);
```

{{% alert title="注意" color="warning" %}} 

特定の条件（例えば、フォントにアクセスできない場合）で何が起こるかを決定するルールを設定するには、[**フォント置換**](/slides/net/font-substitution/)を参照してください。

{{% /alert %}}