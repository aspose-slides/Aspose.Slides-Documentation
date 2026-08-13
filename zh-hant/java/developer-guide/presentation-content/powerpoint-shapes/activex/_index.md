---
title: 使用 Java 管理簡報中的 ActiveX 控制項
linktitle: ActiveX
type: docs
weight: 80
url: /zh-hant/java/activex/
keywords:
- ActiveX
- ActiveX 控制項
- 管理 ActiveX
- 新增 ActiveX
- 修改 ActiveX
- 媒體播放器
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Java 如何利用 ActiveX 自動化與加強 PowerPoint 簡報，為開發人員提供對投影片的強大控制功能。"
---
## **簡介**

ActiveX 控制項在簡報中使用。Aspose.Slides for Java 允許您新增和管理 ActiveX 控制項，但相較於一般的簡報圖形，其管理稍微複雜。我們在 Aspose.Slides 中實作了加入 Media Player Active 控制項的支援。請注意，ActiveX 控制項不是圖形；它們不屬於簡報的 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapecollection/)。它們屬於獨立的 [IControlCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icontrolcollection/)。在本主題中，我們將示範如何使用它們。 

## **將 Media Player ActiveX 控制項新增至投影片**
要新增 Media Player ActiveX 控制項，請執行以下動作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 類別的實例，並產生一個空的簡報實例。  
2. 在 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 中存取目標投影片。  
3. 使用由 [IControlCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icontrolcollection/) 所提供的 [addControl](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) 方法加入 Media Player ActiveX 控制項。  
4. 取得 Media Player ActiveX 控制項，並使用其屬性設定影片路徑。  
5. 將簡報儲存為 PPTX 檔案。

此範例程式碼依照上述步驟說明如何將 Media Player ActiveX 控制項新增至投影片：

```java
import com.aspose.slides.*;

// 建立空的簡報實例
Presentation pres = new Presentation();
try {
    // 新增 Media Player ActiveX 控制項
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // 取得 Media Player ActiveX 控制項並設定影片路徑
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // 儲存簡報
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **修改 ActiveX 控制項**
{{% alert color="info" %}} 

Aspose.Slides for Java 7.1.0 及更新版本提供了管理 ActiveX 控制項的元件。您可以存取簡報中已加入的 ActiveX 控制項，並透過其屬性進行修改或刪除。

{{% /alert %}} 

要在投影片上管理類似文字方塊和簡易指令按鈕的 ActiveX 控制項，請執行以下動作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 類別的實例，並載入已包含 ActiveX 控制項的簡報。  
2. 依索引取得投影片參考。  
3. 透過存取 [IControlCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icontrolcollection/) 取得投影片中的 ActiveX 控制項。  
4. 使用 [IControl](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icontrol/) 物件取得 TextBox1 ActiveX 控制項。  
5. 變更 TextBox1 ActiveX 控制項的屬性，包括文字、字型、字型高度與框架位置。  
6. 存取第二個名為 CommandButton1 的控制項。  
7. 變更按鈕的標題、字型與位置。  
8. 移動 ActiveX 控制項框架的位置。  
9. 將修改後的簡報寫入 PPTX 檔案。

此範例程式碼依照上述步驟說明如何管理簡單的 ActiveX 控制項：

```java
import com.aspose.slides.*;
import java.awt.FontMetrics;
import java.awt.SystemColor;
import java.awt.image.BufferedImage;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import javax.imageio.ImageIO;

// 取得含 ActiveX 控制項的簡報
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // 取得簡報中的第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);

    // 更改 TextBox 文字
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // 變更替代圖片。PowerPoint 會在 ActiveX 啟用期間取代此圖片，
        // 所以有時保留圖片不變也是可以的。
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);

        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.window);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlDkShadow);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

        graphics.dispose();

        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        ImageIO.write(image, "PNG", baos);

        control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
    }

    // 更改按鈕標題
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // 變更替代圖片
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);
        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.control);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        FontMetrics metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, (image.getWidth() - metrics.stringWidth(newCaption)) / 2, 20);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlDkShadow);
                graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
                graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

                graphics.dispose();

                ByteArrayOutputStream baos = new ByteArrayOutputStream();
                ImageIO.write(image, "PNG", baos);

                control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
            }

            // 向下移動 100 點
            for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
                IShapeFrame frame = ctl.getFrame();
                ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                        frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
            }
            pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

            // 移除控制項
            pres.getSlides().get_Item(0).getControls().clear();
            pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
        } catch(IOException e) {
        } finally {
            if (pres != null) pres.dispose();
        }
```

## **常見問題**

### Aspose.Slides 在讀取並重新儲存時，若在 Java 執行環境中無法執行，是否仍會保留 ActiveX 控制項？

是。Aspose.Slides 視它們為簡報的一部份，能讀取/修改其屬性與框架；不需要執行控制項本身即可保留它們。

### ActiveX 控制項與簡報中的 OLE 物件有何不同？

ActiveX 控制項是可互動的受控元件（按鈕、文字方塊、媒體播放器），而 [OLE](/slides/zh-hant/java/manage-ole/) 指的是嵌入式的應用程式物件（例如 Excel 工作表）。它們的儲存與處理方式不同，且擁有不同的屬性模型。

### 如果檔案已由 Aspose.Slides 修改，ActiveX 事件與 VBA 巨集是否仍可運作？

Aspose.Slides 會保留現有的標記與中繼資料；然而，事件與巨集僅在 Windows 上的 PowerPoint 且安全性允許時才會執行。此函式庫不會執行 VBA。