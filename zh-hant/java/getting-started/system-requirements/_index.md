---
title: 系統需求
type: docs
weight: 60
url: /zh-hant/java/system-requirements/
keywords:
- 系統需求
- 支援平台
- Java 版本
- JDK
- JRE
- fontconfig
- 字型
- Docker
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "檢查在安裝 Aspose.Slides for Java 之前需要的項目：支援的 Java 版本與作業系統，以及 Linux 所需的字型函式庫與字型。"
---
## **簡介**

Aspose.Slides for Java 是一個獨立的函式庫：它不需要 Microsoft PowerPoint 或 Microsoft Office。它是一個單一的 JAR 檔案，發佈於 Aspose 的 Maven 套件庫中。此 JAR 檔案僅包含 Java 類別與資源，沒有本機程式庫，亦未宣告對其他函式庫的相依性。因此，只要有支援的 Java 執行環境，該檔案即可在任何作業系統與處理器上執行。

本文列出支援的 Java 版本與作業系統、Linux 所需的字型函式庫與字型，最後提供一段簡短程式以檢查您的環境。若要將函式庫加入專案，請參閱[Installation](/slides/zh-hant/java/installation/)。

## **支援的 Java 版本**

Aspose.Slides for Java 可在 Java 8 以上執行，使用 JDK 或 JRE。這包括長期支援的 Java 8、11、17、21、25，以及更高版本如 Java 26、Java 27。Java 執行環境可來自任何供應商，例如 Eclipse Temurin、Amazon Corretto、Oracle，或 Linux 發行版的 OpenJDK 套件。

Aspose.Slides 在上述版本中不需要任何 JVM 選項，例如 `--add-opens`。在 Java 11 中，JVM 會印出以「WARNING: An illegal reflective access operation has occurred」開頭的警告；此警告不會影響結果。

{{% alert color="warning" title="Warning" %}}
Java 6 與 Java 7 已棄用。Aspose.Slides for Java 26.9 仍可在它們上執行，但會顯示棄用警告。自 26.10 版起，最低需求為 Java 8，Java 6 與 Java 7 不再受支援。
{{% /alert %}}

Maven 專案以及[Installation](/slides/zh-hant/java/installation/)中的指令需要 JDK 11 或以上。若使用 Java 8，請依照[Check Your Setup](#check-your-setup)中的說明編譯與執行程式。

## **支援的作業系統**

由於 JAR 檔案不含本機程式碼，Aspose.Slides for Java 可在 Windows、Linux 與 macOS 上執行，支援任何 Java 執行環境所支援的處理器架構，例如 x64 與 ARM64。Windows 只需要 Java 執行環境。Linux 上，Java 的字型支援還需要[Linux](#linux) 中描述的字型函式庫與字型。

## **Linux**

Aspose.Slides for Java 依賴 Java 執行環境的字型支援來排版與繪製文字。在 Linux 上，這需要 fontconfig 函式庫以及至少一套已安裝的字型。官方的 Linux 發行版容器映像通常沒有這些。若缺少，它會在[Create Presentations](/slides/zh-hant/java/create-presentation/)的第一個範例儲存簡報時失敗，留下空檔案，並回報以下錯誤：

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

官方的 `eclipse-temurin` 容器映像（Ubuntu 與 Alpine Linux）已包含 fontconfig 與 DejaVu 字型，無需額外安裝。其他系統請安裝下列套件。Debian、Ubuntu 與 Red Hat 的指令使用 `sudo`；在 Dockerfile 中，請在 `RUN` 指令內執行且不加 `sudo`。DejaVu 字型已足以讓 Aspose.Slides 執行；簡報所使用的字型請參閱[Fonts](#fonts)。

### **Debian 與 Ubuntu**

若使用 Debian 或 Ubuntu 套件的預設 `apt-get` 設定安裝 Java（如[Installation](/slides/zh-hant/java/installation/#linux)中的指令），Java 套件會同時安裝 fontconfig 函式庫、DejaVu 字型與這些 Java 套件所需的 HarfBuzz 函式庫，無需其他操作。

若使用其他來源的 Java 執行環境，例如 Eclipse Temurin 壓縮檔，請安裝 fontconfig 與 DejaVu 字型：

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

Dockerfile 常會以 `--no-install-recommends` 選項安裝 Debian 或 Ubuntu 的 Java 套件（如 `openjdk-21-jdk-headless` 或 `default-jdk-headless`），此選項會跳過上述三項。使用上述指令安裝 fontconfig 與 DejaVu 字型，並同時安裝 HarfBuzz：

```bash
sudo apt-get install -y libharfbuzz0b
```

若未安裝 HarfBuzz，這些 Java 套件會印出 `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless`，且儲存時會因 `UnsatisfiedLinkError` 且找不到 `libharfbuzz.so.0` 而失敗。

### **Red Hat Enterprise Linux**

Red Hat Enterprise Linux 的 `java-<version>-openjdk-headless` 套件不會安裝 fontconfig 函式庫。請同時安裝 fontconfig 與 DejaVu 字型：

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

完整的 `java-<version>-openjdk` 套件會將 fontconfig 與字型列為相依性，同樣適用於 Amazon Linux 2023 的 Amazon Corretto 套件，例如 `java-21-amazon-corretto-headless`。

### **Alpine Linux**

在基於 Alpine Linux 的 Dockerfile 中，請安裝 fontconfig 與 DejaVu 字型：

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

在目前的 Alpine 發行版中，`ttf-dejavu` 會安裝 `font-dejavu` 套件。請以 `openjdk<version>-jre` 或 `openjdk<version>-jdk` 套件（例如 `openjdk25-jdk`）安裝 Java。Alpine Linux 的 `openjdk<version>-jre-headless` 套件不含 Java 的字型函式庫，使用此套件時，即使已安裝字型，程式仍會因 `UnsatisfiedLinkError: no fontmanager in system library path` 而失敗。

### **Fonts**

為了正確呈現文字與度量，簡報使用的字型（或相容的替代字型）必須安裝於系統或由應用程式載入。請參閱[Deploy Fonts](/slides/zh-hant/java/deploy-fonts/)、[Font Substitution](/slides/zh-hant/java/font-substitution/)與[Custom Fonts](/slides/zh-hant/java/custom-font/)。

## **Check Your Setup**

為了驗證函式庫與其前置需求已正確配置，請執行一段會儲存簡報並將投影片渲染為圖像的程式。儲存與渲染皆使用 Java 執行環境的字型支援，亦即前述 Linux 的需求。

將下列程式碼儲存為 *CheckSetup.java*，放在包含 Aspose.Slides JAR 檔案的資料夾中。欲下載 JAR 檔案，請參閱[Use the JAR File without Maven](/slides/zh-hant/java/installation/#use-the-jar-file-without-maven)。

```java
import com.aspose.slides.*;

public class CheckSetup {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            // 在第一張投影片新增帶文字的矩形並儲存簡報。
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello, Aspose.Slides!");
            presentation.save("hello.pptx", SaveFormat.Pptx);

            // 以每點一像素的比例渲染投影片並儲存圖像。
            IImage image = slide.getImage(1f, 1f);
            try {
                image.save("hello.png", ImageFormat.Png);
            } finally {
                image.dispose();
            }
        } finally {
            presentation.dispose();
        }
    }
}
```

使用 JDK 11 或以上，在該資料夾內以以下指令執行程式。若您的 JAR 檔案名稱不同，請自行更改指令中的名稱。

```bash
java -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
```

若使用 Java 8，或系統上只有 JRE，請以 JDK 的 `javac` 編譯程式後再執行編譯後的類別。於 Linux 與 macOS 上執行：

```bash
javac -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
java -cp aspose-slides-26.10-jdk8.jar:. CheckSetup
```

於 Windows 上執行相同的 `javac` 指令，然後以分號作為類別路徑分隔符執行類別。請保留引號，以免 PowerShell 將分號視為指令結束：`java -cp "aspose-slides-26.10-jdk8.jar;." CheckSetup`。

程式會在第一張投影片加上一個帶文字的矩形，並以 [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 方法儲存為 *hello.pptx*。接著以 [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#getImage-float-float-) 渲染投影片，並以 [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) 於 [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/) 格式儲存為 *hello.png*。比例因子為 1 時，每點會對應一個像素，因此預設 720 × 540 點的投影片會變成 720 × 540 像素的圖像，且文字會顯示於矩形內。若未授權，兩個檔案皆會帶有評估水印；請參閱[Licensing](/slides/zh-hant/java/licensing/)。若缺少任何需求，程式會依據[Linux](#linux) 中描述的錯誤訊息停止執行。

## **Development Tools**

您可以使用任何支援的 Java 版本的 JDK 來建立使用 Aspose.Slides 的應用程式。依照[Installation](/slides/zh-hant/java/installation/)的說明，使用 Apache Maven 連接 Aspose 的 Maven 套件庫，或使用任何可使用 Maven 套件庫的建置工具。您也可以自行將 JAR 檔案加入 IDE 或建置工具的類別路徑。

## **FAQ**

**是否需要安裝 Microsoft PowerPoint 來執行轉換與渲染？**

不，需要。PowerPoint 並非必要。Aspose.Slides 是一套獨立的引擎，用於[creating](/slides/zh-hant/java/create-presentation/)、修改、[converting](/slides/zh-hant/java/convert-presentation/)、以及[rendering](/slides/zh-hant/java/convert-powerpoint-to-png/)簡報。

**Aspose.Slides for Java 在 Linux 伺服器上是否需要顯示器或桌面環境？**

不需要。Aspose.Slides 不需要 X 伺服器或顯示器，因而可在伺服器與容器中執行。於 Linux 上，它僅需[Linux](#linux) 中描述的字型函式庫與字型。

**需要哪些字型才能正確渲染？**

簡報使用的字型或相容的[substitutes](/slides/zh-hant/java/font-substitution/)必須可取得。於 Linux 與 macOS，請安裝簡報所需的字型套件，以確保渲染一致。

**為何自訂字型在 Linux 上會呈現為備援或缺少文字？**

若字型檔的 name-table 條目不一致或已損毀，Linux 的字型匹配堆疊（FreeType/fontconfig）可能會選取無效記錄，導致字型無法解析。使用已修正 name-table 的字型版本或安裝一致的替代字型即可解決此問題。