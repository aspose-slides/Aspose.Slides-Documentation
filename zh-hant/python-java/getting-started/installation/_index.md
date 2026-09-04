---
title: 安裝
type: docs
weight: 70
url: /zh-hant/python-java/installation/
keywords:
- 下載 Aspose.Slides
- 安裝 Aspose.Slides
- Aspose.Slides 安裝
- Python
- Java
- JPype
- Windows
- macOS
- Linux
description: "在 Windows、Linux 或 macOS 上安裝 Aspose.Slides for Python via Java，設定 Java 和 JPype，並使用可執行範例驗證設定。"
---
Aspose.Slides for Python via Java 在 Windows、Linux 和 macOS 上執行。它使用 JPype 從 Python 存取 Java 函式庫。不需要 Microsoft PowerPoint。

## **先決條件**

在安裝 Python 套件之前，請先安裝符合[System Requirements](/slides/zh-hant/python-java/system-requirements/) 的 Python 與 JDK。該頁面列出相容的版本、架構需求，以及建置 JPype 所需的任何相依性。

將 `JAVA_HOME` 設為 JDK 安裝目錄（而非其 `bin` 子目錄），並將 JDK 的 `bin` 目錄加入 `PATH`。變更環境變數後請開啟新終端機。

## **從 PyPI 安裝**

在終端機中執行以下指令，而非在 Python 互動式提示字元下。建立專案資料夾與虛擬環境，以將套件與其他專案隔離。

### **Windows**

確保您選擇的 Python 直譯器可在 `PATH` 中以 `python` 呼叫，然後在命令提示字元執行以下指令：

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux and macOS**

確保您選擇的 Python 版本可在 `PATH` 中以 `python3` 呼叫，然後在 Bash 或 zsh 執行以下指令：

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

在 Debian 或 Ubuntu 上，如果建立環境失敗且 `ensurepip` 不可用，請使用 `sudo apt-get install python3-venv` 安裝 `python3-venv` 套件，然後再次執行建立環境的指令。若使用的是另外安裝的 Python 版本，可能需要對應版本的 `venv` 套件。

### **安裝套件**

啟動虛擬環境後，安裝 JPype 與 Aspose.Slides：

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

使用 `python -m pip` 可確保套件安裝於執行您應用程式的該直譯器。

若要更新已安裝的 Aspose.Slides，請在相同環境中執行 `python -m pip install --upgrade aspose-slides-java`。

## **從 ZIP 壓縮檔安裝**

您也可以從[Aspose.Slides 下載頁面](https://releases.aspose.com/slides/zh-hant/python-java/)取得庫：

1. 如[先決條件](#先決條件)所述安裝 Python 與 Java。
2. 依照上方說明建立並啟動虛擬環境。
3. 使用 `python -m pip install JPype1` 安裝 JPype。
4. 下載並解壓 Aspose.Slides for Python via Java 的 ZIP 壓縮檔。
5. 找到解壓後的 `asposeslides` 套件目錄，保留其內容，包括 `lib` 目錄與 JAR 檔。
6. 將下一節的 `example.py` 放置於 `asposeslides` 目錄旁，使 Python 能匯入該套件。

## **驗證安裝**

將以下程式碼儲存為 `example.py`。它會建立一個包含文字方塊的簡報，並將檔案儲存為目前工作目錄下的 `out.pptx`。

```python
import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Presentation, SaveFormat, ShapeType

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 500, 80)
        shape.getTextFrame().setText("Aspose.Slides is ready!")
        presentation.save("out.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    jpype.shutdownJVM()
```

啟動虛擬環境後，於含有 `example.py` 的目錄執行範例：

```sh
python example.py
```

`asposeslides` 匯入會在 JVM 啟動前註冊捆綁的 Java 函式庫。啟動 JVM 後再匯入 `asposeslides.api`，並在關閉 JVM 前釋放簡報資源。

{{% alert color="info" title="Note" %}}
未取得授權時，輸出會包含評估水印。請參閱[Evaluate Aspose.Slides](/slides/zh-hant/python-java/evaluate-aspose-slides/)以了解評估限制與臨時授權資訊。
{{% /alert %}}

## **常見問答**

**為何 Python 報告找不到或無法載入 JVM？**

請確認 `JAVA_HOME` 指向與您的 Python 及 JPype 安裝相容的 JDK，詳情請參閱[System Requirements](/slides/zh-hant/python-java/system-requirements/)。另可參考[JPype 安裝疑難排解指南](https://jpype.readthedocs.io/en/latest/install.html)進行其他檢查。

**為何安裝後 Python 顯示找不到 `asposeslides`？**

可能是套件安裝在了不同的 Python 直譯器。請啟動安裝時使用的虛擬環境，然後執行 `python -m pip show aspose-slides-java`。若使用 ZIP 安裝，請確保 `asposeslides` 目錄與您的腳本同層，或已加入 Python 的模組搜尋路徑。

**我可以在 notebook 中重複執行範例嗎？**

此範例設計為單次執行的獨立 Python 程序。若要在 notebook 中多次執行，請先參閱[限制與 API 差異](/slides/zh-hant/python-java/limitations-and-api-differences/#import-the-library)了解 JVM 生命週期與 notebook 的使用指引。

**為何 pip 失敗並顯示 `CERTIFICATE_VERIFY_FAILED`？**

如果您的網路使用 HTTPS 檢查代理，pip 必須信任該代理的憑證授權機構。請使用 pip 的 `--cert` 選項或 `PIP_CERT` 環境變數設定受信任的 CA 捆綁檔，參考[pip HTTPS 憑證說明](https://pip.pypa.io/en/stable/topics/https-certificates/)。具體設定取決於您的網路環境與 pip 版本。