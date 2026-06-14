---
title: 在 C++ 中將 PowerPoint 簡報轉換為 Markdown
linktitle: PowerPoint 轉 Markdown
type: docs
weight: 140
url: /zh-hant/cpp/convert-powerpoint-to-markdown/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 MD
- 簡報轉 MD
- 投影片轉 MD
- PPT 轉 MD
- PPTX 轉 MD
- 將 PowerPoint 儲存為 Markdown
- 將簡報儲存為 Markdown
- 將投影片儲存為 Markdown
- 將 PPT 儲存為 MD
- 將 PPTX 儲存為 MD
- 匯出 PPT 為 MD
- 匯出 PPTX 為 MD
- PowerPoint
- 簡報
- Markdown
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 將 PowerPoint 投影片（PPT、PPTX）轉換為純淨的 Markdown，自動化文件編寫並保持格式。"
---
## **簡介**

Aspose.Slides 允許您將 PowerPoint 簡報轉換為 Markdown，這對於文件編寫工作流程、靜態網站產生、內容遷移以及版本控制的文字出版都很有用。API 支援直接將 PPT 和 PPTX 簡報匯出為 MD 檔，並提供額外選項以控制投影片內容在最終 Markdown 文件中的呈現方式。

您可以將簡報匯出為純文字 Markdown，選擇多種 Markdown 風格（如 CommonMark 與 GitHub Flavored Markdown），並設定匯出時圖像的處理方式。對於包含視覺內容的簡報，Aspose.Slides 亦支援將圖像儲存至單獨資料夾，並在產生的 Markdown 檔中引用這些圖像。

{{% alert color="warning" %}} 
PowerPoint 轉 Markdown 匯出預設 **不包含圖像**。若要匯出包含圖像的 PowerPoint 文件，必須設定 `SaveOptions::MarkdownExportType::Visual)`，同時設定 `BasePath` 以指定 Markdown 文件中引用的圖像儲存位置。 
{{% /alert %}} 

## **將 PowerPoint 轉換為 Markdown**

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例，以代表簡報物件。  
2. 使用 [Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method) 方法將物件儲存為 markdown 檔。

以下 C++ 程式碼示範如何將 PowerPoint 轉換為 markdown：

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```

## **將 PowerPoint 轉換為特定 Markdown 風格**

Aspose.Slides 允許您將 PowerPoint 轉換為 markdown（包含基礎語法）、CommonMark、GitHub Flavored Markdown、Trello、XWiki、GitLab 以及其他 17 種 markdown 風格。

以下 C++ 程式碼示範如何將 PowerPoint 轉換為 CommonMark：

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```

支援的 23 種 markdown 風格列於 [Flavor 列舉](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) 中，可於 [MarkdownSaveOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 類別取得。

## **將含圖像的簡報匯出為 Markdown**

[MarkdownSaveOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 類別提供屬性與列舉，讓您為最終的 markdown 檔案使用特定選項或設定。例如，可設定 [MarkdownExportType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) 列舉為 `Sequential`、`TextOnly`、`Visual` 以決定圖像的呈現方式。

### **逐一匯出圖像**

若希望圖像在產生的 markdown 中逐一呈現，請選擇 sequential（順序）選項。以下 C++ 程式碼示範如何將含圖像的簡報轉換為 markdown：

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

### **視覺化匯出圖像**

若希望圖像在產生的 markdown 中一起呈現，請選擇 visual（視覺）選項。此情況下，圖像會儲存於應用程式的當前目錄（並在 markdown 文件中建立相對路徑），或您可以自行指定路徑與資料夾名稱。

以下 C++ 程式碼示範此操作：

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
const System::String outPath = u"x:\\documents";
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_ExportType(Aspose::Slides::DOM::Export::Markdown::SaveOptions::MarkdownExportType::Visual);
opt->set_ImagesSaveFolderName(u"md-images");
opt->set_BasePath(outPath);
pres->Save(System::IO::Path::Combine(outPath, u"pres.md"), Aspose::Slides::Export::SaveFormat::Md, opt);
```

## **常見問題**

**超連結在匯出為 Markdown 後會保留嗎？**  

是的。文字 [hyperlinks](/slides/zh-hant/cpp/manage-hyperlinks/) 會以標準 Markdown 連結形式保留。投影片 [transitions](/slides/zh-hant/cpp/slide-transition/) 與 [animations](/slides/zh-hant/cpp/powerpoint-animation/) 則不會被轉換。

**可以透過多執行緒加速轉換嗎？**  

您可以針對不同檔案並行處理，但請勿在多執行緒間共享同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 實例。每個檔案使用獨立的實例或行程，以避免競爭。

**圖像會怎麼處理——儲存位置與路徑是否為相對路徑？**  

[Images](/slides/zh-hant/cpp/image/) 會匯出至專屬資料夾，Markdown 檔預設以相對路徑引用它們。您可以設定基礎輸出路徑與資產資料夾名稱，以維持可預測的倉儲結構。