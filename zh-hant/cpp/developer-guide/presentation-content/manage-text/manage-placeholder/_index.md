---
title: 在 C++ 中管理簡報佔位符
linktitle: 管理佔位符
type: docs
weight: 10
url: /zh-hant/cpp/manage-placeholder/
keywords:
- 佔位符
- 文字佔位符
- 圖片佔位符
- 圖表佔位符
- 提示文字
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中輕鬆管理佔位符：替換文字、客製化提示並在 PowerPoint 與 OpenDocument 中設定圖片透明度。"
---
## **概觀**

Aspose.Slides 允許您以程式方式管理簡報的佔位符。本文說明如何在投影片上尋找佔位符並變更其文字、為佔位符版面設定自訂提示文字，以及調整用作佔位符背景的圖片透明度。文章還包括簡短 FAQ，說明基礎佔位符與本地形狀的差異、如何透過版面或母片套用佔位符變更，以及指向頁首與頁尾佔位符的管理。

## **變更佔位符中的文字**
使用 [Aspose.Slides for C++](/slides/zh-hant/cpp/)，您可以在簡報的投影片上尋找並修改佔位符。Aspose.Slides 允許您變更佔位符中的文字。

**先決條件**：您需要一個包含佔位符的簡報。您可以使用標準的 Microsoft PowerPoint 應用程式建立此類簡報。

1. 實例化 [`Presentation`](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation/) 類別，並將簡報作為參數傳入。  
2. 透過索引取得投影片參考。  
3. 迭代形狀以尋找佔位符。  
4. 將佔位符形狀型別轉換為 [`AutoShape`](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.auto_shape/)，並使用與該 [`AutoShape`](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.auto_shape/) 相關聯的 [`TextFrame`](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.text_frame/) 變更文字。  
5. 儲存已修改的簡報。

以下 C++ 程式碼示範如何變更佔位符中的文字：

```c++
// 文件目錄的路徑。
const String outPath = u"../out/ReplacingText_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// 載入所需的簡報
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// 取得第一張投影片
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// 取得投影片中第一與第二個佔位符，並將其型別轉換為 AutoShape
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);
SharedPtr<AutoShape> ashp = ExplicitCast<Aspose::Slides::AutoShape>(shape);

SharedPtr<ITextFrame> textframe = ashp->get_TextFrame();

textframe->set_Text(u"This is Placeholder");
	
// 將簡報儲存至磁碟
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **設定佔位符的提示文字**
標準及預建的版面包含像 ***Click to add a title*** 或 ***Click to add a subtitle*** 這樣的佔位符提示文字。使用 Aspose.Slides，您可以將自訂的提示文字插入佔位符版面中。

以下 C++ 程式碼示範如何在佔位符中設定提示文字：

```c++
const System::String templatePath = u"../templates/Presentation2.pptx";
    
auto pres = System::MakeObject<Presentation>(templatePath);
auto slide = pres->get_Slides()->idx_get(0);

for (auto& shape : slide->get_Shapes())
{
    if (shape->get_Placeholder() != NULL)
    {
        System::String text = u"";
        if (shape->get_Placeholder()->get_Type() == PlaceholderType::CenteredTitle) // 當其中沒有文字時，PowerPoint 會顯示「點擊以新增標題」。
        {
            text = u"Click to add title";
        }
        else if (shape->get_Placeholder()->get_Type() == PlaceholderType::Subtitle) // 對副標題執行相同操作。
        {
            text = u"Click to add subtitle";
        }
        System::Console::WriteLine(u"Placeholder : {0}", text);
    }
}

pres->Save(u"../out/Placeholders_PromptText.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **設定佔位符圖片的透明度**
Aspose.Slides 允許您設定文字佔位符背景圖片的透明度。透過調整此框架中圖片的透明度，您可以使文字或圖片更為突出（取決於文字與圖片的顏色）。

以下 C++ 程式碼示範如何為圖片背景（在形狀內）設定透明度：

```c++
auto presentation = System::MakeObject<Presentation>();
    
auto autoShape = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
    
auto fillFormat = autoShape->get_FillFormat();
fillFormat->set_FillType(Aspose::Slides::FillType::Picture);
fillFormat->get_PictureFillFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png")));

auto pictureFillFormat = fillFormat->get_PictureFillFormat();
pictureFillFormat->set_PictureFillMode(Aspose::Slides::PictureFillMode::Stretch);
pictureFillFormat->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(75.0f);
```

## **常見問題**

**什麼是基礎佔位符，且它與投影片上的本地形狀有何不同？**

基礎佔位符是版面或母片上原始的形狀，投影片的形狀會從它繼承——類型、位置以及部分格式皆來源於此。本地形狀則是獨立的；若沒有基礎佔位符，則不會套用繼承。

**如何在不遍歷每張投影片的情況下更新整個簡報的所有標題或說明文字？**

在版面或母片上編輯相應的佔位符。基於這些版面/母片的投影片將自動繼承此變更。

**我要如何控制標準的頁首/頁尾佔位符—日期與時間、投影片編號以及頁腳文字？**

在適當的範圍（普通投影片、版面、母片、備註/講義）使用 HeaderFooter 管理員，開啟或關閉這些佔位符，並設定其內容。