---
title: 使用 C++ 在簡報中管理 ActiveX 控制項
linktitle: ActiveX
type: docs
weight: 80
url: /zh-hant/cpp/activex/
keywords:
- ActiveX
- ActiveX 控制項
- 管理 ActiveX
- 新增 ActiveX
- 修改 ActiveX
- 媒體播放器
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解 Aspose.Slides for C++ 如何利用 ActiveX 自動化並強化 PowerPoint 簡報，為開發人員提供對投影片的強大控制能力。"
---
## **簡介**

ActiveX 控制項在簡報中使用。Aspose.Slides for C++ 讓您管理 ActiveX 控制項，但其管理方式較為複雜，且不同於一般簡報圖形。從 Aspose.Slides for C++ 18.1 起，該元件支援管理 ActiveX 控制項。目前，您可以透過其各種屬性存取簡報中已加入的 ActiveX 控制項，並對其進行修改或刪除。請記住，ActiveX 控制項不是圖形，也不屬於簡報的 IShapeCollection，而是屬於獨立的 IControlCollection。本章節說明如何使用它們。

## **修改 ActiveX 控制項**
要在投影片上管理簡單的 ActiveX 控制項（例如文字方塊與簡易指令按鈕）：

1. 建立 Presentation 類別的實例，並載入其中包含 ActiveX 控制項的簡報。
1. 依索引取得投影片參考。
1. 透過 IControlCollection 取得投影片中的 ActiveX 控制項。
1. 使用 ControlEx 物件存取 TextBox1 ActiveX 控制項。
1. 修改 TextBox1 ActiveX 控制項的各種屬性，包括文字、字型、字型高度與框架位置。
1. 存取名為 CommandButton1 的第二個控制項。
1. 變更按鈕的標題、字型與位置。
1. 調整 ActiveX 控制項框架的位置。
1. 將修改後的簡報寫入 PPTX 檔案。

以下程式碼段會更新簡報投影片上的 ActiveX 控制項，如下所示。

``` cpp
// 取得包含 ActiveX 控制項的簡報
auto presentation = System::MakeObject<Presentation>(u"ActiveX.pptm");

// 取得簡報的第一張投影片
auto slide = presentation->get_Slides()->idx_get(0);

// 變更文字方塊文字
auto control = slide->get_Controls()->idx_get(0);

if (control->get_Name() == u"TextBox1" && control->get_Properties() != nullptr)
{
    String newText = u"Changed text";
    control->get_Properties()->idx_set(u"Value", newText);

    // 變更替代影像。PowerPoint 會在 ActiveX 啟動時取代此影像，因此有時可以保留影像不變。
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Window));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    graphics->DrawString(newText, font, brush, 10.0f, 4.0f);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);

    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// 變更按鈕標題
control = slide->get_Controls()->idx_get(1);

if (control->get_Name() == u"CommandButton1" && control->get_Properties() != nullptr)
{
    String newCaption = u"MessageBox";
    control->get_Properties()->idx_set(u"Caption", newCaption);

    // 變更替代影像
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Control));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    SizeF textSize = graphics->MeasureString(newCaption, font, std::numeric_limits<int32_t>::max());
    graphics->DrawString(newCaption, font, brush, (image->get_Width() - textSize.get_Width()) / 2, (image->get_Height() - textSize.get_Height()) / 2);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// 將 ActiveX 框架向下移動 100 點
for (const auto& ctl : System::IterateOver<Control>(slide->get_Controls()))
{
    SharedPtr<IShapeFrame> frame = control->get_Frame();
    control->set_Frame(System::MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation()));
}

// 儲存已編輯 ActiveX 控制項的簡報
presentation->Save(u"withActiveX-edited_out.pptm", SaveFormat::Pptm);

// 現在移除控制項
slide->get_Controls()->Clear();

// 儲存已清除 ActiveX 控制項的簡報
presentation->Save(u"withActiveX.cleared_out.pptm", SaveFormat::Pptm);
```

## **新增 Media Player ActiveX 控制項**
ActiveX 控制項在簡報中使用。Aspose.Slides for C++ 讓您新增與管理 ActiveX 控制項，但其管理方式較為複雜，且不同於一般簡報圖形。自 Aspose.Slides for C++ 18.1 起，已在 Aspose.Slides 中加入對 Media Player ActiveX 控制項的支援。請記住，ActiveX 控制項不是圖形，也不屬於簡報的 IShapeCollection，而是獨立的 IControlExCollection。本章節說明如何使用它們。若要管理 Media Player ActiveX 控制項，請依照以下步驟操作：

1. 建立 Presentation 類別的實例，並載入包含 Media Player ActiveX 控制項的範例簡報。
1. 建立目標 Presentation 類別的實例，產生空白簡報。
1. 將範本簡報中含有 Media Player ActiveX 控制項的投影片複製至目標 Presentation。
1. 在目標 Presentation 中存取已複製的投影片。
1. 透過 IControlCollection 取得投影片中的 ActiveX 控制項。
1. 存取 Media Player ActiveX 控制項，並使用其屬性設定影片路徑。
1. 將簡報儲存為 PPTX 檔案。

``` cpp
// 實例化代表 PPTX 檔案的 Presentation 類別
auto presentation = System::MakeObject<Presentation>(u"template.pptx");

// 建立空白簡報實例
auto newPresentation = System::MakeObject<Presentation>();

// 移除預設投影片
newPresentation->get_Slides()->RemoveAt(0);

// 複製含 Media Player ActiveX 控制項的投影片
newPresentation->get_Slides()->InsertClone(0, presentation->get_Slides()->idx_get(0));

// 存取 Media Player ActiveX 控制項並設定影片路徑
newPresentation->get_Slides()->idx_get(0)->get_Controls()->idx_get(0)->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

// 儲存簡報
newPresentation->Save(u"LinkingVideoActiveXControl_out.pptx", SaveFormat::Pptx);
```

## **常見問題**

**Aspose.Slides 在讀取並重新保存檔案時，若無法在 C++ 執行環境中執行 ActiveX 控制項，是否仍會保留它們？**

是。Aspose.Slides 將它們視為簡報的一部份，能讀取與修改其屬性與框架；不需要執行控制項本身即可保留它們。

**ActiveX 控制項與簡報中的 OLE 物件有何不同？**

ActiveX 控制項是可互動的受管理控制項（例如按鈕、文字方塊、媒體播放器），而 [OLE](/slides/zh-hant/cpp/manage-ole/) 指的是內嵌的應用程式物件（例如 Excel 工作表）。它們的儲存與處理方式不同，且擁有不同的屬性模型。

**如果檔案已由 Aspose.Slides 修改，ActiveX 事件和 VBA 巨集是否仍會運作？**

Aspose.Slides 會保留現有的標記與中繼資料；然而，事件與巨集僅在 Windows 上的 PowerPoint 且安全性允許時才能執行。此函式庫不會執行 VBA。