---
title: PowerPoint プレゼンテーションを C++ で Markdown に変換
linktitle: PowerPoint から Markdown へ
type: docs
weight: 140
url: /ja/cpp/convert-powerpoint-to-markdown/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint から MD へ
- プレゼンテーションを MD に
- スライドを MD に
- PPT を MD に
- PPTX を MD に
- PowerPoint を Markdown として保存
- プレゼンテーションを Markdown として保存
- スライドを Markdown として保存
- PPT を MD として保存
- PPTX を MD として保存
- PPT を MD にエクスポート
- PPTX を MD にエクスポート
- PowerPoint
- プレゼンテーション
- Markdown
- C++
- Aspose.Slides
description: "PowerPoint のスライド（PPT、PPTX）を Aspose.Slides for C++ でクリーンな Markdown に変換し、ドキュメント自動化と書式保持を実現します。"
---

{{% alert color="info" %}} 

PowerPoint から markdown への変換サポートは [Aspose.Slides 23.7](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-23-7-release-notes/) で実装されました。

{{% /alert %}} 

{{% alert color="warning" %}} 

PowerPoint から markdown へのエクスポートはデフォルトで **画像なし** です。画像を含む PowerPoint ドキュメントをエクスポートしたい場合は、`SaveOptions::MarkdownExportType::Visual)` を設定し、Markdown ドキュメントで参照される画像の保存先となる `BasePath` も指定する必要があります。

{{% /alert %}} 

## **PowerPoint を Markdown に変換する**

1. プレゼンテーションオブジェクトを表すために [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. Save メソッドを使用してオブジェクトを markdown ファイルとして保存します。

この C++ コードは PowerPoint を markdown に変換する方法を示します:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```


## **PowerPoint を Markdown のフレーバーに変換する**

Aspose.Slides を使用すると、PowerPoint を markdown（基本構文を含む）、CommonMark、GitHub フレーバーの markdown、Trello、XWiki、GitLab、その他 17 種類の markdown フレーバーに変換できます。

この C++ コードは PowerPoint を CommonMark に変換する方法を示します: 
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```


サポートされている 23 の markdown フレーバーは、[MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) クラスの [Flavor 列挙体](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) に一覧されています。

## **画像を含むプレゼンテーションを Markdown に変換する**

[MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) クラスは、生成される markdown ファイルに対して特定のオプションや設定を使用できるプロパティと列挙体を提供します。たとえば、[MarkdownExportType](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) 列挙体は、画像のレンダリングや処理方法を決定する `Sequential`、`TextOnly`、`Visual` の値に設定できます。

### **画像を順次変換する**

画像を結果の markdown に個別に一つずつ表示させたい場合は、Sequential オプションを選択する必要があります。この C++ コードは、画像を含むプレゼンテーションを markdown に変換する方法を示します:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<MarkdownSaveOptions> markdownSaveOptions = System::MakeObject<MarkdownSaveOptions>();

markdownSaveOptions->set_ShowHiddenSlides(true);
markdownSaveOptions->set_ShowSlideNumber(true);
markdownSaveOptions->set_Flavor(Flavor::Github);
markdownSaveOptions->set_ExportType(MarkdownExportType::Sequential);
markdownSaveOptions->set_NewLineType(NewLineType::Windows);

pres->Save(u"doc.md", System::MakeArray<int32_t>({1, 2, 3, 4, 5, 6, 7, 8, 9}), SaveFormat::Md, markdownSaveOptions);
```


### **画像をビジュアルに変換する**

画像を結果の markdown にまとめて表示させたい場合は、Visual オプションを選択する必要があります。この場合、画像はアプリケーションの現在のディレクトリに保存され（markdown ドキュメント内には相対パスが作成されます）、もしくは任意のパスとフォルダー名を指定することも可能です。

この C++ コードは操作を示しています: 
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
const System::String outPath = u"x:\\documents";
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_ExportType(Aspose::Slides::DOM::Export::Markdown::SaveOptions::MarkdownExportType::Visual);
opt->set_ImagesSaveFolderName(u"md-images");
opt->set_BasePath(outPath);
pres->Save(System::IO::Path::Combine(outPath, u"pres.md"), Aspose::Slides::Export::SaveFormat::Md, opt);
```


## **FAQ**

**ハイパーリンクは Markdown へのエクスポート後も残りますか？**

はい。テキスト [hyperlinks](/slides/ja/cpp/manage-hyperlinks/) は標準的な Markdown リンクとして保持されます。スライドの [transitions](/slides/ja/cpp/slide-transition/) や [animations](/slides/ja/cpp/powerpoint-animation/) は変換されません。

**複数スレッドで実行して変換速度を上げられますか？**

ファイル単位で並列化は可能ですが、同じ [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) インスタンスをスレッド間で共有しないでください。スレッドごとに別々のインスタンスまたはプロセスを使用して競合を回避します。

**画像はどう扱われますか—どこに保存され、パスは相対ですか？**

[Images](/slides/ja/cpp/image/) は専用フォルダーにエクスポートされ、Markdown ファイルはデフォルトで相対パスで参照します。ベース出力パスとアセットフォルダー名を設定すれば、リポジトリ構造を予測可能に保てます。