---
title: C++でPowerPointプレゼンテーションをMarkdownに変換する
linktitle: PowerPointからMarkdownへ
type: docs
weight: 140
url: /ja/cpp/convert-powerpoint-to-markdown/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- スライドを変換
- PPTを変換
- PPTXを変換
- PowerPointからMDへ
- プレゼンテーションからMDへ
- スライドからMDへ
- PPTからMDへ
- PPTXからMDへ
- PowerPointをMarkdownとして保存
- プレゼンテーションをMarkdownとして保存
- スライドをMarkdownとして保存
- PPTをMDとして保存
- PPTXをMDとして保存
- PPTをMDにエクスポート
- PPTXをMDにエクスポート
- PowerPoint
- プレゼンテーション
- Markdown
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint スライド（PPT、PPTX）をクリーンな Markdown に変換し、ドキュメントの自動化と書式の保持を実現します。"
---

{{% alert color="info" %}} 
PowerPoint から markdown への変換サポートは [Aspose.Slides 23.7](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-23-7-release-notes/) に実装されました。
{{% /alert %}} 
{{% alert color="warning" %}} 
PowerPoint から markdown へのエクスポートはデフォルトで **画像なし** です。画像を含む PowerPoint ドキュメントをエクスポートしたい場合は、`SaveOptions::MarkdownExportType::Visual)` を設定し、markdown ドキュメントで参照される画像の保存先となる `BasePath` も設定する必要があります。
{{% /alert %}} 
## **PowerPoint を Markdown に変換**
1. プレゼンテーションオブジェクトを表すために、[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. オブジェクトを markdown ファイルとして保存するために、[Save ](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method)method を使用します。
この C++ コードは PowerPoint を markdown に変換する方法を示しています。
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```

## **PowerPoint を Markdown フレーバーに変換**
Aspose.Slides を使用すると、PowerPoint を markdown（基本構文を含む）、CommonMark、GitHub Flavored Markdown、Trello、XWiki、GitLab、その他 17 の markdown フレーバーに変換できます。
この C++ コードは PowerPoint を CommonMark に変換する方法を示しています。 
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```

サポートされている 23 の markdown フレーバーは、[Flavor 列挙](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) に一覧されており、[MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) クラスから取得できます。
## **画像を含むプレゼンテーションを Markdown に変換**
[MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) クラスは、結果の markdown ファイルに対して使用できるプロパティや列挙体を提供します。例えば、[MarkdownExportType](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) 列挙体は、画像のレンダリングや処理方法を決定する `Sequential`、`TextOnly`、`Visual` などの値に設定できます。
### **画像を順次変換**
画像を結果の markdown で個別に順番に表示したい場合は、sequential オプションを選択する必要があります。この C++ コードは画像を含むプレゼンテーションを markdown に変換する方法を示しています。
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

### **画像をビジュアルに変換**
画像を結果の markdown で一括して表示したい場合は、visual オプションを選択する必要があります。この場合、画像はアプリケーションの現在のディレクトリに保存され（markdown ドキュメント内で相対パスが構築されます）、または任意のパスとフォルダー名を指定することもできます。
この C++ コードは操作を示しています。 
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
**ハイパーリンクは Markdown へのエクスポートで保持されますか？**
はい。テキスト [hyperlinks](/slides/ja/cpp/manage-hyperlinks/) は標準的な Markdown リンクとして保持されます。スライドの [transitions](/slides/ja/cpp/slide-transition/) と [animations](/slides/ja/cpp/powerpoint-animation/) は変換されません。
**