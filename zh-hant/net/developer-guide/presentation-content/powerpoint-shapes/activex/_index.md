---
title: 管理 .NET 環境下簡報的 ActiveX 控制項
linktitle: ActiveX
type: docs
weight: 80
url: /zh-hant/net/activex/
keywords:
- ActiveX
- ActiveX 控制項
- 管理 ActiveX
- 新增 ActiveX
- 修改 ActiveX
- 媒體播放器
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解 Aspose.Slides for .NET 如何利用 ActiveX 自動化與增強 PowerPoint 簡報，為開發者提供對投影片的強大控制。"
---
## **簡介**

ActiveX 控制項在簡報中被使用。Aspose.Slides for .NET 允許您管理 ActiveX 控制項，但其管理方式較為複雜，且不同於一般的簡報形狀。從 Aspose.Slides for .NET 6.9.0 起，該元件支援管理 ActiveX 控制項。目前，您可以存取簡報中已加入的 ActiveX 控制項，並透過其各種屬性進行修改或刪除。請記住，ActiveX 控制項不是形狀，亦不屬於簡報的 IShapeCollection，而是屬於獨立的 IControlCollection。本文將說明如何使用它們。

## **修改 ActiveX 控制項**

要在投影片上管理簡單的 ActiveX 控制項，例如文字方塊與簡單的指令按鈕：

1. 建立 Presentation 類別的實例，並載入已包含 ActiveX 控制項的簡報。
2. 依索引取得投影片參考。
3. 透過 IControlCollection 存取投影片中的 ActiveX 控制項。
4. 使用 ControlEx 物件存取 TextBox1 ActiveX 控制項。
5. 變更 TextBox1 ActiveX 控制項的各種屬性，包括文字、字型、字型高度與框架位置。
6. 存取名為 CommandButton1 的第二個控制項。
7. 變更按鈕的標題、字型與位置。
8. 調整 ActiveX 控制項框架的位置。
9. 將修改後的簡報寫入 PPTX 檔案。

以下程式碼片段會將簡報投影片上的 ActiveX 控制項更新為下圖所示的樣子。

```c#
// 存取含有  ActiveX 控制項的簡報
Presentation presentation = new Presentation("ActiveX.pptm");

// 存取簡報中的第一張投影片
ISlide slide = presentation.Slides[0];

// 更改 TextBox 文字
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Changed text";
    control.Properties["Value"] = newText;

    // 更改替代圖像。PowerPoint 會在 ActiveX 啟動期間替換此圖像，因此有時可以保持圖像不變。

    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Window));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    graphics.DrawString(newText, font, brush, 10, 4);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(
        pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);

    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[]
    {
            new System.Drawing.Point(1, image.Height - 1), new System.Drawing.Point(image.Width - 1, image.Height - 1),
            new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// 更改按鈕標題
control = slide.Controls[1];

if (control.Name == "CommandButton1" && control.Properties != null)
{
    String newCaption = "MessageBox";
    control.Properties["Caption"] = newCaption;

    // 更改替代圖像
    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Control));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    SizeF textSize = graphics.MeasureString(newCaption, font, int.MaxValue);
    graphics.DrawString(newCaption, font, brush, (image.Width - textSize.Width) / 2, (image.Height - textSize.Height) / 2);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[]
    {
        new System.Drawing.Point(1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// 將 ActiveX 框架向下移動 100 點
foreach (Control ctl in slide.Controls)
{
    IShapeFrame frame = control.Frame;
    control.Frame = new ShapeFrame(
        frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

// 儲存已編輯 ActiveX 控制項的簡報
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// 現在移除控制項
slide.Controls.Clear();

// 儲存已清除 ActiveX 控制項的簡報
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```

## **加入 ActiveX Media Player 控制項**

若要加入 ActiveX Media Player 控制項，請執行以下步驟：

1. 建立 Presentation 類別的實例，並載入已包含 Media Player ActiveX 控制項的範例簡報。
2. 建立目標 Presentation 類別的實例，產生空白簡報實例。
3. 將範本簡報中含有 Media Player ActiveX 控制項的投影片複製到目標 Presentation。
4. 在目標 Presentation 中存取已複製的投影片。
5. 透過 IControlCollection 存取投影片中的 ActiveX 控制項。
6. 存取 Media Player ActiveX 控制項，並使用其屬性設定影片路徑。
7. 將簡報儲存為 PPTX 檔案。

```c#
// 建立代表 PPTX 檔案的 Presentation 類別實例
Presentation presentation = new Presentation("template.pptx");

// 建立空白簡報實例
Presentation newPresentation = new Presentation();

// 移除預設投影片
newPresentation.Slides.RemoveAt(0);

// 複製含有 Media Player ActiveX 控制項的投影片
newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

// 存取 Media Player ActiveX 控制項並設定影片路徑
newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

// 儲存簡報
newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **常見問題**

**Aspose.Slides 在讀取並重新儲存時，若無法在 .NET 執行環境中執行，是否仍會保留 ActiveX 控制項？**

是的。Aspose.Slides 會將它們視為簡報的一部份，並能讀取/修改其屬性與框架；不需要執行控制項本身即可保留它們。

**ActiveX 控制項與簡報中的 OLE 物件有何不同？**

ActiveX 控制項是可互動的受管理控制項（例如按鈕、文字方塊、Media Player），而 [OLE](/slides/zh-hant/net/manage-ole/) 則指嵌入的應用程式物件（例如 Excel 工作表）。它們的存儲與處理方式不同，且具有不同的屬性模型。

**如果檔案已被 Aspose.Slides 修改，ActiveX 事件與 VBA 巨集仍會運作嗎？**

Aspose.Slides 會保留現有的標記與中繼資料；然而，事件與巨集僅在 Windows 上的 PowerPoint 並且安全性允許的情況下才能執行。此函式庫不會執行 VBA。