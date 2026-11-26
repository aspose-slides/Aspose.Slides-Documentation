---
title: 在 .NET 中管理簡報的 ActiveX 控制項
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
description: "編輯 ActiveX 文字方塊與按鈕，更新控制項預覽，並在 PowerPoint 簡報中使用 Aspose.Slides for .NET 重新利用 Windows Media Player 控制項。"
---
## **介紹**

ActiveX 控制項為 PowerPoint 投影片提供可互動的元素，例如文字方塊、指令按鈕和媒體播放器。Aspose.Slides for .NET 透過 [IBaseSlide.Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/controls/) 將投影片的控制項公開。使用此集合可編輯控制項、在投影片上移動或將其移除。

## **列出 ActiveX 控制項及其儲存的屬性**

若要檢查不熟悉的範本，請以唯讀模式開啟並遍歷每張投影片上的控制項。範例會報告投影片編號、控制項名稱、[ClassId](https://reference.aspose.com/slides/net/aspose.slides/icontrol/classid/)，以及在[Properties](https://reference.aspose.com/slides/net/aspose.slides/icontrol/#properties) 中的每個鍵值對。它會在不啟動控制項、觸發事件或巨集、變更值或儲存檔案的情況下讀取簡報。

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("ActiveX.pptm");

for (var i = 0; i < presentation.Slides.Count; i++)
{
    foreach (var control in presentation.Slides[i].Controls)
    {
        Console.WriteLine($"Slide {i + 1} | {control.Name} | {control.ClassId}");
        var properties = control.Properties;

        if (properties == null)
        {
            Console.WriteLine("  Properties unavailable");
            continue;
        }

        if (properties.Count == 0)
            Console.WriteLine("  []");

        foreach (var property in properties)
            Console.WriteLine($"  {property.Key} = {property.Value}");
    }
}
```

從 `ActiveX.pptm` 取得的選取輸出顯示一個文字方塊和一個指令按鈕。

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

空的屬性集合會顯示為 `[]`。對於使用二進位儲存的控制項，`Properties` 可能會返回 `null`，顯示為 `Properties unavailable`。如果只需要名稱，可在檢查為 null 後使用 [NamesOfProperties](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/namesofproperties/)。報告列出簡報中可用的屬性。控制項在執行時可能支援額外的屬性。

## **修改 ActiveX 控制項**

範例假設第一張投影片上有一個名為 `TextBox1` 的文字方塊和一個名為 `CommandButton1` 的指令按鈕，且簡報已啟用巨集。它使用[控制屬性集合](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) 變更文字方塊的值與按鈕的標題。每個控制項亦有 PowerPoint 在啟動前可顯示的靜態預覽。提供每個控制項的 PNG，顯示更新後的文字與外觀。範例透過[IControl.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/icontrol/substitutepictureformat/) 指派這些影像。

範例透過變更其[Frame](https://reference.aspose.com/slides/net/aspose.slides/icontrol/frame/)，將第一張投影片上的所有控制項向下移動 100 點。它以 PPTM 格式儲存編輯後的簡報，然後使用[IControlCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icontrolcollection/clear/) 產生第二份副本，該副本已從該投影片移除所有 ActiveX 控制項。

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ActiveX.pptm");

var controls = presentation.Slides[0].Controls;
var textBox = controls.FirstOrDefault(control => control.Name == "TextBox1");
var button = controls.FirstOrDefault(control => control.Name == "CommandButton1");

if (textBox?.Properties == null || button?.Properties == null)
{
    Console.WriteLine("The first slide must contain both named controls with editable properties.");
    return;
}

if (!File.Exists("text-box-preview.png") || !File.Exists("button-preview.png"))
{
    Console.WriteLine("Supply both preview images before updating the controls.");
    return;
}

textBox.Properties["Value"] = "Changed text";
button.Properties["Caption"] = "Show message";

using var textBoxPreview = File.OpenRead("text-box-preview.png");
using var buttonPreview = File.OpenRead("button-preview.png");
textBox.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(textBoxPreview);
button.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(buttonPreview);

foreach (var control in controls)
{
    var frame = control.Frame;
    control.Frame = new ShapeFrame(frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

presentation.Save("edited-controls.pptm", SaveFormat.Pptm);

controls.Clear();
presentation.Save("removed-controls.pptm", SaveFormat.Pptm);
```

## **新增 ActiveX 媒體播放器控制項**

若要重複使用已配置的 Windows Media Player 控制項，請從第一張投影片包含名為 `WindowsMediaPlayer1` 的播放器的範本開始。[ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) 會將整張投影片複製到新簡報。範例在其[屬性集合](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) 中設定播放器的 `URL`，並將複製的投影片儲存為輸出唯一的投影片。影片保持外部，請選擇播放器在播放時能存取的路徑。

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var template = new Presentation("template.pptx");
using var presentation = new Presentation();

var slide = presentation.Slides.AddClone(template.Slides[0]);
var player = slide.Controls.FirstOrDefault(control => control.Name == "WindowsMediaPlayer1");

if (player?.Properties == null)
{
    Console.WriteLine("The template slide must contain a named media player with editable properties.");
    return;
}

player.Properties["URL"] = "Wildlife.mp4";

presentation.Slides.RemoveAt(0);
presentation.Save("linked-video.pptx", SaveFormat.Pptx);
```

## **常見問題**

**Aspose.Slides 能在不執行的情況下保留 ActiveX 控制項嗎？**

可以。Aspose.Slides 能讀取並儲存控制項，包括其屬性與位置，且不會啟動它們。

**ActiveX 控制項與 OLE 物件有何不同？**

ActiveX 控制項允許使用者與投影片互動，例如填寫文字或點擊按鈕。[OLE 物件](/slides/zh-hant/net/manage-ole/) 允許投影片包含或鏈結至由其他應用程式管理的內容，例如 Excel 工作表。

**在使用 Aspose.Slides 儲存簡報後，ActiveX 事件仍會觸發 VBA 巨集嗎？**

將簡報儲存為支援巨集的格式（例如 PPTM）即可保留 VBA 專案。當 Windows 版 PowerPoint 的安全性設定同時允許 ActiveX 控制項與巨集時，便能執行既有的事件處理程式。