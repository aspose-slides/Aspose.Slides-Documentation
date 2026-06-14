---
title: 使用 JavaScript 在簡報中管理 ActiveX 控制項
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
description: "了解 Aspose.Slides for Node.js via Java 如何利用 ActiveX 自動化並增強 PowerPoint 簡報，為開發人員提供對投影片的強大控制能力。"
---
## **簡介**

ActiveX 控制項在簡報中使用。Aspose.Slides for Node.js via Java 允許您新增和管理 ActiveX 控制項，但相較於一般簡報形狀，它們的管理稍嫌複雜。我們在 Aspose.Slides 中實作了新增 Media Player Active 控制項的支援。請注意，ActiveX 控制項不是形狀；它們不屬於簡報的 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapecollection/)。它們屬於另一個 [ControlCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/controlcollection/) 。在本主題中，我們將示範如何使用它們。

## **在投影片中新增 Media Player ActiveX 控制項**

若要新增 ActiveX Media Player 控制項，請依照下列步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 類別的實例，並產生一個空的簡報實例。
2. 在 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 中存取目標投影片。
3. 使用由 [ControlCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/controlcollection/) 提供的 [addControl](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ControlCollection#addControl-int-float-float-float-float-) 方法新增 Media Player ActiveX 控制項。
4. 存取 Media Player ActiveX 控制項，並使用其屬性設定影片路徑。
5. 將簡報儲存為 PPTX 檔案。

以下範例程式碼根據上述步驟說明如何在投影片中新增 Media Player ActiveX 控制項：

```javascript
// 建立空的簡報實例
var pres = new aspose.slides.Presentation();
try {
    // 新增 Media Player ActiveX 控制項
    pres.getSlides().get_Item(0).getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 100, 100, 400, 400);
    // 存取 Media Player ActiveX 控制項並設定影片路徑
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("java.net.URL", "Wildlife.wmv");
    // 儲存簡報
    pres.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **修改 ActiveX 控制項**

若要管理投影片上如文字方塊和簡易指令按鈕等簡單的 ActiveX 控制項，請依照下列步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 類別的實例，並載入含有 ActiveX 控制項的簡報。
2. 依索引取得投影片參照。
3. 透過存取 [ControlCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/controlcollection/) 來取得投影片中的 ActiveX 控制項。
4. 使用 [Control](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/control/) 物件存取 TextBox1 ActiveX 控制項。
5. 變更 TextBox1 ActiveX 控制項的屬性，包括文字、字型、字型高度與框架位置。
6. 存取名為 CommandButton1 的第二個控制項。
7. 變更按鈕的標題、字型與位置。
8. 調整 ActiveX 控制項框架的位置。
9. 將修改後的簡報寫入 PPTX 檔案。

以下範例程式碼根據上述步驟示範如何管理簡單的 ActiveX 控制項：

```javascript
const imageio = java.import("javax.imageio.ImageIO");
// 存取帶有 ActiveX 控制項的簡報
var pres = new aspose.slides.Presentation("ActiveX.pptm");
try {
    // 存取簡報中的第一張投影片
    var slide = pres.getSlides().get_Item(0);
    // 更改 TextBox 文字
    var control = slide.getControls().get_Item(0);
    if (control.getName().toUpperCase() === "TextBox1".toUpperCase() && (control.getProperties() != null)) {
        var newText = "Changed text";
        control.getProperties().set_Item("Value", newText);
        // 更換替代圖像。PowerPoint 會在 ActiveX 啟動期間取代此圖像，
        // 因此有時可以保持圖像不變。
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "window"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // 更改按鈕說明文字
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);
    if (control.getName().toUpperCase() === "CommandButton1".toUpperCase() && (control.getProperties() != null)) {
        var newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // 更換替代圖像
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "control"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        var metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, java.newFloat((image.getWidth() - metrics.stringWidth(newCaption)) / 2), 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // 向下移動 100 點
    for (let i = 0; i < pres.getSlides().get_Item(0).getControls().size(); i++) {
        let ctl = pres.getSlides().get_Item(0).getControls().get_Item(i);
        var frame = ctl.getFrame();
        ctl.setFrame(new aspose.slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), java.newByte(frame.getFlipH()), java.newByte(frame.getFlipV()), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", aspose.slides.SaveFormat.Pptm);
    // 移除控制項
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", aspose.slides.SaveFormat.Pptm);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**Aspose.Slides 在無法在 Python 執行環境中執行時，讀取並重新儲存時是否仍保留 ActiveX 控制項？**

是。Aspose.Slides 將它們視為簡報的一部份，能讀取/修改其屬性與框架；不需要執行控制項本身即可保留它們。

**ActiveX 控制項與簡報中的 OLE 物件有何不同？**

ActiveX 控制項是可互動的受管理控制項（按鈕、文字方塊、媒體播放器），而 [OLE](/slides/zh-hant/nodejs-java/manage-ole/) 指的是嵌入的應用程式物件（例如 Excel 工作表）。它們的存儲與處理方式不同，且具有不同的屬性模型。

**若檔案已由 Aspose.Slides 修改，ActiveX 事件與 VBA 巨集是否仍能運作？**

Aspose.Slides 會保留現有的標記與中繼資料；然而，事件與巨集僅在 Windows 上的 PowerPoint 且安全性允許時才會執行。此函式庫不會執行 VBA。