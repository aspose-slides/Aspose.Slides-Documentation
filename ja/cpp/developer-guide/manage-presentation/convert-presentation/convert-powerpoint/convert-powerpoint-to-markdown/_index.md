---
title: PowerPointをC++でMarkdownに変換する
type: docs
weight: 140
url: /ja/cpp/convert-powerpoint-to-markdown/
keywords: "PowerPointをMarkdownに変換, pptをmdに変換, PowerPoint, PPT, PPTX, プレゼンテーション, Markdown, C++, CPP, Aspose.Slides for C++"
description: "C++でPowerPointをMarkdownに変換する"
---

{{% alert color="info" %}} 

PowerPointからMarkdownへの変換サポートは、[Aspose.Slides 23.7](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-23-7-release-notes/)に実装されました。

{{% /alert %}} 

{{% alert color="warning" %}} 

PowerPointからMarkdownへのエクスポートは、デフォルトで**画像なし**となっています。画像を含むPowerPoint文書をエクスポートしたい場合は、`SaveOptions::MarkdownExportType::Visual)`を設定し、Markdown文書内で参照される画像が保存される`BasePath`も設定する必要があります。

{{% /alert %}} 

## **PowerPointをMarkdownに変換する**

1. プレゼンテーションオブジェクトを表すために[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method)メソッドを使用して、オブジェクトをMarkdownファイルとして保存します。

このC++コードは、PowerPointをMarkdownに変換する方法を示しています：

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```

## PowerPointをMarkdownフレーバーに変換する

Aspose.Slidesは、PowerPointをMarkdown（基本構文を含む）、CommonMark、GitHubフレーバーのMarkdown、Trello、XWiki、GitLab、その他17のMarkdownフレーバーに変換することを可能にします。

このC++コードは、PowerPointをCommonMarkに変換する方法を示しています：

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```

サポートされている23のMarkdownフレーバーは、[Flavor列挙型](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/)の下に[MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/)クラスからリストされています。

## **画像を含むプレゼンテーションをMarkdownに変換する**

[MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/)クラスは、結果のMarkdownファイルに対して特定のオプションまたは設定を使用できるプロパティや列挙型を提供します。たとえば、[MarkdownExportType](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/)列挙型は、画像がどのようにレンダリングまたは処理されるかを決定する値に設定できます：`Sequential`、`TextOnly`、`Visual`。

### **画像を順次変換する**

結果のMarkdownに画像を個別に1つずつ表示したい場合は、順次オプションを選択する必要があります。このC++コードは、画像を含むプレゼンテーションをMarkdownに変換する方法を示しています：

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

### **画像を視覚的に変換する**

結果のMarkdownに画像を一緒に表示したい場合は、視覚的オプションを選択する必要があります。この場合、画像はアプリケーションの現在のディレクトリに保存され（Markdown文書内に相対パスが構築されます）、好みのパスとフォルダ名を指定することもできます。

このC++コードは、操作を示しています：

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
const System::String outPath = u"x:\\documents";
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_ExportType(Aspose::Slides::DOM::Export::Markdown::SaveOptions::MarkdownExportType::Visual);
opt->set_ImagesSaveFolderName(u"md-images");
opt->set_BasePath(outPath);
pres->Save(System::IO::Path::Combine(outPath, u"pres.md"), Aspose::Slides::Export::SaveFormat::Md, opt);
```