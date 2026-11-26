---
title: 使用 JavaScript 管理簡報中的 ActiveX 控制項
linktitle: ActiveX
type: docs
weight: 80
url: /zh-hant/nodejs-java/activex/
keywords:
- ActiveX
- ActiveX 控制項
- 管理 ActiveX
- 新增 ActiveX
- 修改 ActiveX
- 媒體播放器
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "編輯 ActiveX 文字方塊與按鈕、更新控制項預覽，並在 PowerPoint 簡報中使用 Aspose.Slides for Node.js via Java 重新利用 Windows Media Player 控制項。"
---
## **簡介**

ActiveX 控制項為 PowerPoint 投影片提供互動元素，例如文字方塊、指令按鈕和媒體播放器。Aspose.Slides for Node.js via Java 透過 [BaseSlide.getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getControls) 讓您存取投影片的控制項。使用此集合即可編輯控制項、在投影片上移動它或將其移除。

## **列出 ActiveX 控制項及其儲存的屬性**

若要檢查不熟悉的範本，請以唯讀模式開啟並遍歷每張投影片上的控制項。此範例會報告投影片編號、控制項名稱、[getClassId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getClassId) 以及 [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties) 中的每個鍵值對。它會在不啟動控制項、觸發事件或巨集、變更值或儲存檔案的情況下讀取簡報。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ActiveX.pptm");
try {
    const slideList = presentation.getSlides();
    for (let i = 0; i < slideList.size(); i++) {
        const controls = slideList.get_Item(i).getControls();
        for (let j = 0; j < controls.size(); j++) {
            const control = controls.get_Item(j);
            console.log(`Slide ${i + 1} | ${control.getName()} | ${control.getClassId()}`);
            const properties = control.getProperties();
            if (properties == null) {
                console.log("  Properties unavailable");
                continue;
            }
            if (properties.getCount() === 0) {
                console.log("  []");
            }
            const names = properties.getNamesOfProperties().iterator();
            while (names.hasNext()) {
                const name = names.next();
                console.log(`  ${name} = ${properties.get_Item(name)}`);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

從 `ActiveX.pptm` 取得的選取輸出顯示文字方塊和指令按鈕。

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

空的屬性集合會顯示為 `[]`。對於使用二進位儲存的控制項，[getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties) 可能會傳回 `null`，此時會顯示為 `Properties unavailable`。如果只需要屬性名稱，請在檢查為 null 後使用 [getNamesOfProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties)。報告列出簡報中可用的屬性。控制項在執行時可能支援其他屬性。

## **修改 ActiveX 控制項**

此範例假設簡報已啟用巨集，且第一張投影片上有名稱為 `TextBox1` 的文字方塊和名稱為 `CommandButton1` 的指令按鈕。它使用[控制項屬性集合](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) 變更文字方塊的值與按鈕的標題。每個控制項亦有 PowerPoint 在啟動前可顯示的靜態預覽圖。請提供 PNG 圖片，以顯示更新後的文字與外觀。範例透過 [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getSubstitutePictureFormat) 指派這些圖片。

範例將第一張投影片上所有控制項的框架向下移動 100 點，方法是使用 [Control.setFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#setFrame) 設定其框架。然後將編輯後的簡報以 PPTM 格式儲存，接著使用 [ControlCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/#clear) 移除該投影片上所有 ActiveX 控制項，並另存為第二個副本。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function addPreview(presentation, path) {
    const image = slides.Images.fromFile(path);
    try {
        return presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
}

function editControls() {
    const presentation = new slides.Presentation("ActiveX.pptm");
    try {
        const controls = presentation.getSlides().get_Item(0).getControls();
        let textBox;
        let button;
        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            if (control.getName() === "TextBox1") {
                textBox = control;
            } else if (control.getName() === "CommandButton1") {
                button = control;
            }
        }
        if (!textBox || !button || textBox.getProperties() == null || button.getProperties() == null) {
            console.log("The first slide must contain both named controls with editable properties.");
            return;
        }

        const textBoxPreview = addPreview(presentation, "text-box-preview.png");
        const buttonPreview = addPreview(presentation, "button-preview.png");
        textBox.getProperties().set_Item("Value", "Changed text");
        button.getProperties().set_Item("Caption", "Show message");
        textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
        button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            const frame = control.getFrame();
            const flipH = java.newByte(frame.getFlipH());
            const flipV = java.newByte(frame.getFlipV());
            const moved = new slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), flipH, flipV, frame.getRotation());
            control.setFrame(moved);
        }
        presentation.save("edited-controls.pptm", slides.SaveFormat.Pptm);

        controls.clear();
        presentation.save("removed-controls.pptm", slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}

editControls();
```

## **新增 ActiveX 媒體播放器控制項**

若要重複使用已配置好的 Windows Media Player 控制項，請以第一張投影片包含名稱為 `WindowsMediaPlayer1` 的播放器的範本作為起點。[SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone) 會將整個投影片複製到新簡報中。範例在其[屬性集合](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) 中設定播放器的 `URL`，並將複製的投影片儲存為輸出檔案唯一的投影片。影片保持外部連結，請選擇播放器在播放時可以存取的路徑。

```javascript
const slides = require("aspose.slides.via.java");

function addMediaPlayer() {
    const template = new slides.Presentation("template.pptx");
    try {
        const presentation = new slides.Presentation();
        try {
            const templateSlide = template.getSlides().get_Item(0);
            const slide = presentation.getSlides().addClone(templateSlide);
            const controls = slide.getControls();
            let player;
            for (let i = 0; i < controls.size(); i++) {
                const control = controls.get_Item(i);
                if (control.getName() === "WindowsMediaPlayer1") {
                    player = control;
                    break;
                }
            }
            if (!player || player.getProperties() == null) {
                console.log("The template slide must contain a named media player with editable properties.");
                return;
            }
            player.getProperties().set_Item("URL", "Wildlife.mp4");
            
            presentation.getSlides().removeAt(0);
            presentation.save("linked-video.pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        template.dispose();
    }
}

addMediaPlayer();
```

## **常見問題**

**Aspose.Slides 能在不執行的情況下保留 ActiveX 控制項嗎？**

可以。Aspose.Slides 能讀取並儲存控制項，包括其屬性與位置，而不會啟動它們。

**ActiveX 控制項與 OLE 物件有何不同？**

ActiveX 控制項允許使用者與投影片互動，例如輸入文字或點擊按鈕。而 [OLE 物件](/slides/zh-hant/nodejs-java/manage-ole/) 讓投影片包含或連結到由其他應用程式管理的內容，例如 Excel 工作表。

**在使用 Aspose.Slides 儲存簡報後，ActiveX 事件仍會觸發 VBA 巨集嗎？**

將簡報儲存為支援巨集的格式（例如 PPTM），即可保留其 VBA 專案。當 PowerPoint for Windows 的安全性設定允許同時使用 ActiveX 控制項與巨集時，既有的事件處理常式即可執行。