---
title: C++ で PowerPoint プレゼンテーションを Markdown に変換
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
- プレゼンテーションから MD へ
- スライドから MD へ
- PPT から MD へ
- PPTX から MD へ
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
description: "Aspose.Slides for C++ を使用して、PowerPoint スライド（PPT、PPTX）をクリーンな Markdown に変換し、ドキュメントを自動化し、書式を保持します。"
---

{{% alert color="info" %}} 

PowerPoint から Markdown への変換サポートは、[Aspose.Slides 23.7](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-23-7-release-notes/) に実装されました。

{{% /alert %}} 

{{% alert color="warning" %}} 

PowerPoint から Markdown へのエクスポートはデフォルトで **画像なし** です。画像を含む PowerPoint ドキュメントをエクスポートしたい場合は、`SaveOptions::MarkdownExportType::Visual)` を設定し、さらに Markdown ドキュメントで参照される画像が保存される `BasePath` を設定する必要があります。

{{% /alert %}} 

## **PowerPoint を Markdown に変換**

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーション オブジェクトを表します。
2. [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method) メソッドを使用してオブジェクトを Markdown ファイルとして保存します。

この C++ コードは、PowerPoint を Markdown に変換する方法を示しています:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```


## **PowerPoint を Markdown フレーバーに変換**

Aspose.Slides を使用すると、PowerPoint を markdown（基本構文を含む）、CommonMark、GitHub フレーバー markdown、Trello、XWiki、GitLab、その他 17 の markdown フレーバーに変換できます。

この C++ コードは、PowerPoint を CommonMark に変換する方法を示しています: 
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```


サポートされている 23 の markdown フレーバーは、[MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) クラスの [Flavor 列挙体](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) に一覧されています。

## **画像を含むプレゼンテーションを Markdown に変換**

[MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) クラスは、生成される markdown ファイルに対して特定のオプションや設定を使用できるプロパティと列挙体を提供します。たとえば、[MarkdownExportType](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) 列挙体は、画像のレンダリングや処理方法を決定する値（`Sequential`、`TextOnly`、`Visual`）に設定できます。

### **画像を順次に変換**

結果の markdown で画像を個別に順番に表示したい場合は、Sequential オプションを選択する必要があります。この C++ コードは、画像を含むプレゼンテーションを markdown に変換する方法を示しています:
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


### **画像を視覚的に変換**

結果の markdown で画像を一緒に表示したい場合は、Visual オプションを選択する必要があります。この場合、画像はアプリケーションの現在のディレクトリに保存され（markdown ドキュメントでは相対パスが生成されます）、または任意のパスとフォルダー名を指定できます。

この C++ コードは操作の例を示しています: 
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
const System::String outPath = u"x:\\documents";
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_ExportType(Aspose::Slides::DOM::Export::Markdown::SaveOptions::MarkdownExportType::Visual);
opt->set_ImagesSaveFolderName(u"md-images");
opt->set_BasePath(outPath);
pres->Save(System::IO::Path::Combine(outPath, u"pres.md"), Aspose::Slides::Export::SaveFormat::Md, opt);
```


## **よくある質問**

**ハイパーリンクは Markdown へのエクスポートで保持されますか？**

はい。テキストの [hyperlinks](/slides/ja/cpp/manage-hyperlinks/) は標準的な Markdown リンクとして保持されます。スライドの [transitions](/slides/ja/cpp/slide-transition/) と [animations](/slides/ja/cpp/powerpoint-animation/) は変換されません。

**