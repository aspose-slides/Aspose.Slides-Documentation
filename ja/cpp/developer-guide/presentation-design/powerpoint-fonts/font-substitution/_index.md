---
title: フォントの置き換え
type: docs
weight: 70
url: /ja/cpp/font-substitution/
keywords: "フォント, 置き換えフォント, PowerPoint プレゼンテーション, C++, CPP, Aspose.Slides for C++"
description: "C++ における PowerPoint のフォントの置き換え"
---

Aspose.Slides を使用すると、特定の条件（例えば、フォントにアクセスできない場合）で何をすべきかを決定するフォントのルールを設定できます。

1. 関連するプレゼンテーションを読み込みます。
2. 置き換えられるフォントを読み込みます。
3. 新しいフォントを読み込みます。
4. 置き換えのルールを追加します。
5. ルールをプレゼンテーションのフォント置き換えルールコレクションに追加します。
6. スライド画像を生成してその効果を確認します。

この C++ コードはフォント置き換えプロセスを示しています：

```c++
// ドキュメントディレクトリへのパス。
const String outPath = u"../out/RuleBasedFontsReplacement_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// プレゼンテーションを読み込む
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// 置き換えられるフォントと新しいフォントを定義
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
// フォント置き換えのためのルールを追加
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// 置き換えのルールをフォント置き換えルールコレクションに追加
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// フォントルールコレクションをルールリストに追加
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// PPTX をディスクに保存
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="注意"  color="warning"   %}} 

[**フォント置き換え**](/slides/ja/cpp/font-replacement/)を参照することをお勧めします。

{{% /alert %}}