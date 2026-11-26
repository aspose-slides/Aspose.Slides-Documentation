---
title: 管理 Android 簡報中的 ActiveX 控制項
linktitle: ActiveX
type: docs
weight: 80
url: /zh-hant/androidjava/activex/
keywords:
- ActiveX
- ActiveX 控制項
- 管理 ActiveX
- 新增 ActiveX
- 修改 ActiveX
- 媒體播放器
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "編輯 ActiveX 文字方塊與按鈕、更新控制項預覽，並在 PowerPoint 簡報中使用 Aspose.Slides for Android via Java 重複使用 Windows Media Player 控制項。"
---
## **簡介**

ActiveX 控制項為 PowerPoint 投影片提供互動元素，例如文字方塊、指令按鈕和媒體播放器。Aspose.Slides for Android via Java 透過 [IBaseSlide.getControls](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getControls--) 讓投影片的控制項可被存取。使用此集合可以編輯控制項、在投影片上移動它，或將其移除。在下列範例中，請使用 Android 應用程式可讀取的檔案路徑，並為每個輸出簡報選擇可寫入的位置。

## **列出 ActiveX 控制項及其儲存屬性**

若要檢查不熟悉的範本，請以讀取模式開啟並遍歷每張投影片上的控制項。範例會回報投影片編號、控制項名稱、[getClassId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getClassId--)，以及 [getProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getProperties--) 中的每個鍵值對。它會在不啟動控制項、觸發事件或巨集、變更值或儲存檔案的情況下讀取簡報。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    for (int i = 0; i < presentation.getSlides().size(); i++) {
        for (IControl control : presentation.getSlides().get_Item(i).getControls()) {
            System.out.printf("Slide %d | %s | %s%n", i + 1, control.getName(), control.getClassId());
            IControlPropertiesCollection properties = control.getProperties();
            if (properties == null) {
                System.out.println("  Properties unavailable");
                continue;
            }
            if (properties.getCount() == 0) {
                System.out.println("  []");
            }
            for (String name : properties.getNamesOfProperties()) {
                System.out.printf("  %s = %s%n", name, properties.get_Item(name));
            }
        }
    }
} finally {
    presentation.dispose();
}
```

從 `ActiveX.pptm` 取得的選取輸出顯示文字方塊與指令按鈕。

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

空的屬性集合會顯示為 `[]`。對於使用二進位儲存的控制項，[getProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getProperties--) 可能回傳 `null`，顯示為 `Properties unavailable`。如果只需要屬性名稱，可在檢查 null 之後使用 [getNamesOfProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/#getNamesOfProperties--)。此報告列出簡報中可取得的屬性。控制項在執行期間可能支援其他屬性。

## **修改 ActiveX 控制項**

此範例假設在第一張投影片上有一個名為 `TextBox1` 的文字方塊與一個名為 `CommandButton1` 的指令按鈕，且簡報為支援巨集的格式。它使用 [控制項屬性集合](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/) 變更文字方塊的值與按鈕的標題。每個控制項亦具備 PowerPoint 在啟動前可顯示的靜態預覽。請提供 PNG 圖檔以顯示每個控制項更新後的文字與外觀。範例透過 [IControl.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getSubstitutePictureFormat--) 指定這些圖像。

此範例透過 [IControl.setFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#setFrame-com.aspose.slides.IShapeFrame-) 將第一張投影片上的所有控制項向下移動 100 點。它以 PPTM 格式儲存編輯後的簡報，然後使用 [IControlCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolcollection/#clear--) 再儲存一份已移除該投影片上所有 ActiveX 控制項的副本。

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.FileInputStream;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    IControlCollection controls = presentation.getSlides().get_Item(0).getControls();
    IControl textBox = null;
    IControl button = null;
    for (IControl control : controls) {
        if ("TextBox1".equals(control.getName())) {
            textBox = control;
        } else if ("CommandButton1".equals(control.getName())) {
            button = control;
        }
    }
    if (textBox == null || button == null || textBox.getProperties() == null || button.getProperties() == null) {
        System.out.println("The first slide must contain both named controls with editable properties.");
        return;
    }

    IPPImage textBoxPreview;
    IPPImage buttonPreview;
    try (FileInputStream textBoxStream = new FileInputStream("text-box-preview.png");
         FileInputStream buttonStream = new FileInputStream("button-preview.png")) {
        textBoxPreview = presentation.getImages().addImage(textBoxStream);
        buttonPreview = presentation.getImages().addImage(buttonStream);
    }
    textBox.getProperties().set_Item("Value", "Changed text");
    button.getProperties().set_Item("Caption", "Show message");
    textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
    button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

    for (IControl control : controls) {
        IShapeFrame frame = control.getFrame();
        ShapeFrame moved = new ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation());
        control.setFrame(moved);
    }
    presentation.save("edited-controls.pptm", SaveFormat.Pptm);

    controls.clear();
    presentation.save("removed-controls.pptm", SaveFormat.Pptm);
} catch (IOException e) {
    System.out.println("Could not read a control preview: " + e.getMessage());
} finally {
    presentation.dispose();
}
```

## **新增 ActiveX 媒體播放器控制項**

若要重新使用已設定的 Windows Media Player 控制項，請以第一張投影片包含名為 `WindowsMediaPlayer1` 的播放器的範本為起點。[ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) 會將整張投影片複製到新簡報中。範例在其 [屬性集合](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/) 中設定播放器的 `URL`，並將複製的投影片保存為輸出的唯一投影片。影片保留為外部檔案，請選擇播放器在播放期間可存取的路徑。

```java
import com.aspose.slides.*;

Presentation template = new Presentation("template.pptx");
try {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().addClone(template.getSlides().get_Item(0));
        IControl player = null;
        for (IControl control : slide.getControls()) {
            if ("WindowsMediaPlayer1".equals(control.getName())) {
                player = control;
                break;
            }
        }
        if (player == null || player.getProperties() == null) {
            System.out.println("The template slide must contain a named media player with editable properties.");
            return;
        }
        player.getProperties().set_Item("URL", "Wildlife.mp4");

        presentation.getSlides().removeAt(0);
        presentation.save("linked-video.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    template.dispose();
}
```

## **常見問題**

**Aspose.Slides 能在不執行 ActiveX 控制項的情況下保留它們嗎？**

是。Aspose.Slides 可在不啟動控制項的情況下讀取並儲存控制項，包括其屬性與位置。

**ActiveX 控制項與 OLE 物件有何不同？**

ActiveX 控制項讓使用者與投影片互動，例如輸入文字或點擊按鈕。 [OLE 物件](/slides/zh-hant/androidjava/manage-ole/) 讓投影片包含或鏈結至其他應用程式管理的內容，例如 Excel 工作表。

**在使用 Aspose.Slides 儲存簡報後，ActiveX 事件仍會觸發 VBA 巨集嗎？**

請將簡報存為支援巨集的格式（如 PPTM）以保留 VBA 專案。當 Windows 版 PowerPoint 的安全性設定允許 ActiveX 控制項與巨集時，即可執行現有的事件處理常式。