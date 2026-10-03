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
description: "在安裝 Aspose.Slides for Java 之前，先檢查其需求：支援的 Java 版本與作業系統，以及 Linux 所需的字型庫與字型。"
---
## **簡介**

Aspose.Slides for Java 是一個獨立的函式庫：它不需要 Microsoft PowerPoint 或 Microsoft Office。它是一個單一的 JAR 檔案，發布於 Aspose 的 Maven 儲存庫。該 JAR 檔案僅包含 Java 類別與資源，沒有本機函式庫，且不宣告對其他函式庫的相依性。因此，只要有支援的 Java 執行環境，該檔案就能在所有作業系統與處理器上執行。

本文列出支援的 Java 版本與作業系統、Linux 所需的字型庫與字型，最後提供一個簡短程式檢查您的設定。要將函式庫加入專案，請參閱 [Installation](/slides/zh-hant/java/installation/)。

## **支援的 Java 版本**

Aspose.Slides for Java 可在 Java 8 或更新版本上執行，無論是 JDK 或 JRE。包含長期支援的 Java 8、11、17、21、25 以及後續版本，如 Java 26、Java 27。Java 執行環境可以來自任何供應商，例如 Eclipse Temurin、Amazon Corretto、Oracle，或 Linux 發行版的 OpenJDK 套件。

Aspose.Slides 在這些版本上不需要任何 JVM 選項，例如 `--add-opens`。在 Java 11 上，JVM 會顯示以「WARNING: An illegal reflective access operation has occurred」開頭的警告；此警告不會影響結果。

{{% alert color="warning" title="Warning" %}}
Java 6 與 Java 7 已被棄用。Aspose.Slides for Java 26.9 仍可在其上執行，但會顯示棄用警告。從 26.10 版開始，最低支援版本為 Java 8，Java 6 與 Java 7 不再支援。
{{% /alert %}}

Maven 專案以及 [Installation](/slides/zh-hant/java/installation/) 中的指令需要 JDK 11 或更新版本。使用 Java 8 時，請參照 [Check Your Setup](#check-your-setup) 進行編譯與執行。

## **支援的作業系統**

由於 JAR 檔案不包含本機程式碼，Aspose.Slides for Java 可在 Windows、Linux 與 macOS 上執行，支援任何 Java 執行環境所支援的處理器架構，例如 x64 與 ARM64。Windows 上唯一需求是 Java 執行環境。Linux 上則額外需要在 [Linux](#linux) 中描述的字型庫與字型。

## **Linux**

Aspose.Slides for Java 依賴 Java 執行環境的字型支援來排版與繪製文字。在 Linux 上，這項支援需要 fontconfig 函式庫以及至少一種已安裝的字型。官方的 Linux 發行版容器映像通常兩者皆無。若缺少，則在 [Create Presentations](/slides/zh-hant/java/create-presentation/) 中的第一個範例於儲存簡報時會失敗，產生空檔案並報告以下錯誤：

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

官方的 `eclipse-temurin` 容器映像（Ubuntu 與 Alpine Linux）已內建 fontconfig 與 DejaVu 字型，無需額外安裝。在其他系統上，請安裝下列套件。Debian、Ubuntu 與 Red Hat 的指令使用 `sudo`；在 Dockerfile 中，請在 `RUN` 指令內直接執行且不加 `sudo`。DejaVu 字型足以讓 Aspose.Slides 正常執行；簡報使用的字型說明請參閱 [Fonts](#fonts)。

### **Debian 與 Ubuntu**

如果您依照 [Installation](/slides/zh-hant/java/installation/#linux) 中的指令，使用 Debian 或 Ubuntu 的預設 `apt-get` 設定安裝 Java，Java 套件也會安裝 fontconfig 函式庫、DejaVu 字型與這些 Java 套件所需的 HarfBuzz 函式庫，無需額外操作。

若使用其他來源的 Java 執行環境（例如 Eclipse Temurin 壓縮檔），請安裝 fontconfig 與 DejaVu 字型：

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

在 Dockerfile 中常會以 `--no-install-recommends` 參數安裝 Debian 或 Ubuntu 的 Java 套件（如 `openjdk-21-jdk-headless` 或 `default-jdk-headless`），此參數會跳過上述三項。請使用前述指令安裝 fontconfig 與 DejaVu 字型，並同時安裝 HarfBuzz：

```bash
sudo apt-get install -y libharfbuzz0b
```

若缺少 HarfBuzz，這些 Java 套件會顯示 `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless`，且儲存時會因 `UnsatisfiedLinkError` 而失敗，訊息指出無法開啟 `libharfbuzz.so.0`。

### **Red Hat Enterprise Linux**

Red Hat Enterprise Linux 的 `java-<version>-openjdk-headless` 套件不會安裝 fontconf​ig 函式庫。請同時安裝 fontconfig 與 DejaVu 字型：

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

完整的 `java-<version>-openjdk` 套件會將 fontconfig 與字型作為相依性安裝，Amazon Linux 2023 的 Amazon Corretto 套件（如 `java-21-amazon-corretto-headless`）亦同。

### **Alpine Linux**

在基於 Alpine Linux 的 Dockerfile 中，安裝 fontconfig 與 DejaVu 字型：

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

在目前的 Alpine 發行版中，`ttf-dejavu` 會安裝 `font-dejavu` 套件。請以 `openjdk<version>-jre` 或 `openjdk<version>-jdk`（例如 `openjdk25-jdk`）安裝 Java。Alpine Linux 的 `openjdk<version>-jre-headless` 套件不含 Java 的字型函式庫，使用此套件時，即使已安裝字型，程式亦會因 `UnsatisfiedLinkError: no fontmanager in system library path` 而失敗。

### **字型**

為了讓文字以正確的字型與度量呈現，您簡報所使用的字型（或適當的替代字型）必須安裝於系統或由應用程式載入。請參閱 [Deploy Fonts](/slides/zh-hant/java/deploy-fonts/)、[Font Substitution](/slides/zh-hant/java/font-substitution/) 與 [Custom Fonts](/slides/zh-hant/java/custom-font/)。

## **檢查設定**

為了驗證函式庫與其需求已正確配置，請執行一段會儲存簡報並將投影片渲染為影像的程式。儲存與渲染皆使用 Java 執行環境的字型支援，這正是上述 Linux 要求所提供的功能。

將以下程式碼存為 *CheckSetup.java*，放置於含有 Aspose.Slides JAR 檔案的資料夾中。欲下載 JAR 檔案，請參閱 [Use the JAR File without Maven](/slides/zh-hant/java/installation/#use-the-jar-file-without-maven)。

```java
import com.aspose.slides.*;

public class CheckSetup {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            // 在第一張投影片上加入帶文字的矩形，並儲存簡報。
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello, Aspose.Slides!");
            presentation.save("hello.pptx", SaveFormat.Pptx);

            // 以每點一像素的比例渲染投影片，並儲存影像。
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

使用 JDK 11 或更新版本，在該資料夾內執行下列指令。如果您的 JAR 檔案名稱不同，請相應調整指令中的名稱。

```bash
java -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
```

使用 Java 8，或系統僅有 JRE 時，請先以 JDK 的 `javac` 編譯程式，再執行已編譯的類別。在 Linux 與 macOS 上執行：

```bash
javac -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
java -cp aspose-slides-26.9-jdk16.jar:. CheckSetup
```

在 Windows 上執行相同的 `javac` 指令，然後以分號作為類別路徑分隔符執行類別。請保留引號，以免 PowerShell 將分號視為指令結束：`java -cp "aspose-slides-26.9-jdk16.jar;." CheckSetup`.

此程式會在第一張投影片加入帶文字的矩形，並以 [save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 方法將簡報儲存為 *hello.pptx*。接著使用 [getImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slide/#getImage-float-float-) 渲染投影片，並以 [IImage.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimage/#save-java.lang.String-int-) 以 [ImageFormat.Png](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imageformat/) 格式儲存為 *hello.png*。比例係數 1 代表每點對應一個像素，因此預設 720 × 540 點的投影片會產生 720 × 540 像素的影像，文字可見於矩形內。未授權時，兩個檔案皆會加上評估水印；請參閱 [Licensing](/slides/zh-hant/java/licensing/)。若缺少任何需求，程式會依 [Linux](#linux) 中描述的錯誤訊息停止執行。

## **開發工具**

您可以使用任何支援的 Java 版本的 JDK 來建置使用 Aspose.Slides 的應用程式。依照 [Installation](/slides/zh-hant/java/installation/) 中的說明，使用 Apache Maven 連結至 Aspose 的 Maven 儲存庫，或使用任何能使用 Maven 儲存庫的建置工具。您亦可自行將 JAR 檔案加入 IDE 或建置工具的類別路徑。

## **常見問題**

**我需要安裝 Microsoft PowerPoint 來執行轉換和渲染嗎？**

不需要，PowerPoint 並非必備。Aspose.Slides 是一個獨立的引擎，用於 [creating](/slides/zh-hant/java/create-presentation/)、修改、[converting](/slides/zh-hant/java/convert-presentation/) 與 [rendering](/slides/zh-hant/java/convert-powerpoint-to-png/) 簡報。

**Aspose.Slides for Java 在 Linux 伺服器上是否需要顯示器或桌面環境？**

不需要。Aspose.Slides 不依賴 X 伺服器或顯示器，因此可在伺服器與容器中執行。Linux 上僅需前述的字型庫與字型（參見 [Linux](#linux)）。

**需要哪些字型才能正確渲染？**

必須提供簡報使用的字型，或適當的 [substitutes](/slides/zh-hant/java/font-substitution/)。在 Linux 與 macOS 上，請安裝簡報所需的字型套件，以確保渲染一致。

**為何自訂字型在 Linux 上會顯示為備用字型或缺少文字？**

如果字型檔的 name-table 資料不一致或受損，Linux 的字型匹配堆疊（FreeType/fontconfig）可能會選取無效記錄，導致字型無法解析。使用修正過 name-table 記錄的字型版本或安裝一致的替代字型即可解決此問題。