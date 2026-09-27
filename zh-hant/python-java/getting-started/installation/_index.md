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
description: "在 Windows、Linux 或 macOS 上安裝 Aspose.Slides for Python via Java，設定 Java 和 JPype，並使用可運作的範例驗證設定。"
---
Aspose.Slides for Python via Java 可在 Windows、Linux 和 macOS 上執行。它使用 JPype 從 Python 存取 Java 函式庫。無需 Microsoft PowerPoint。

## **先決條件**

在安裝 Python 套件之前，請安裝符合[系統需求](/slides/zh-hant/python-java/system-requirements/)的 Python 與 JDK。該頁面列出了相容的版本、架構需求以及建置 JPype 所需的任何相依性。

將 `JAVA_HOME` 設為 JDK 的安裝目錄（而非其 `bin` 子目錄），並將 JDK 的 `bin` 目錄加入 `PATH`。變更環境變數後，請開啟新終端機。

## **從 PyPI 安裝**

在終端機中執行以下指令，而不是在 Python 交互式提示字元下。建立專案目錄與虛擬環境，以使套件與其他專案相互隔離。

### **Windows**

若您選擇的 Python 直譯器已在 `PATH` 中以 `python` 提供，請在命令提示字元中執行以下指令：

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux 和 macOS**

若您選擇的 Python 版本已以 `python3` 提供，請在 Bash 或 zsh 中執行以下指令：

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

在 Debian 或 Ubuntu 上，若建立環境時因 `ensurepip` 不可用而失敗，請使用 `sudo apt-get install python3-venv` 安裝 `python3-venv` 套件，然後重新執行環境建立指令。另行安裝的 Python 版本可能需要相對應的版本專屬 `venv` 套件。

### **安裝套件**

在啟用虛擬環境後，安裝 JPype 與 Aspose.Slides：

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

使用 `python -m pip` 可確保套件安裝於執行應用程式的直譯器上。

若要更新已安裝的 Aspose.Slides，請在相同環境中執行 `python -m pip install --upgrade aspose-slides-java`。

## **從 ZIP 壓縮檔安裝**

您也可以從 [Aspose.Slides 下載頁面](https://releases.aspose.com/slides/zh-hant/python-java/) 使用此函式庫：

1. 依照[先決條件](#prerequisites)說明安裝 Python 與 Java。
2. 使用上述說明建立並啟用虛擬環境。
3. 使用 `python -m pip install JPype1` 安裝 JPype。
4. 下載並解壓縮 Aspose.Slides for Python via Java 的 ZIP 壓縮檔。
5. 找到解壓縮後的 `asposeslides` 套件目錄。保留其內容，包括 `lib` 目錄與 JAR 檔案，保持在同一位置。
6. 將下一節的 `example.py` 放置於 `asposeslides` 目錄旁，使 Python 能匯入該套件。壓縮檔中已包含一個位於 `asposeslides` 旁的 `example.py`；請以以下內容取代它。

## **驗證安裝**

將以下程式碼儲存為 `example.py`。它會建立一個包含文字方塊的簡報，並將其儲存為目前工作目錄下的 `out.pptx`。

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

在啟用虛擬環境後，於包含 `example.py` 的目錄執行範例：

```sh
python example.py
```

`asposeslides` 的匯入會在 JVM 啟動前註冊捆綁的 Java 函式庫。JVM 啟動後再匯入 `asposeslides.api`，並在關閉 JVM 前釋放簡報資源。

{{% alert color="info" title="Note" %}}
若未取得授權，輸出內容會包含評估水印。請參閱[評估 Aspose.Slides](/slides/zh-hant/python-java/evaluate-aspose-slides/)以了解評估限制與暫時授權資訊。
{{% /alert %}}

## **常見問題**

**為何 Python 會報告找不到或無法載入 JVM？**  
請確認 `JAVA_HOME` 指向與您的 Python 與 JPype 安裝相容的 JDK，如[系統需求](/slides/zh-hant/python-java/system-requirements/)所述。更多檢查請參閱[JPype 安裝疑難排解指南](https://jpype.readthedocs.io/en/latest/install.html)。

**為何 Python 會報告 `asposeslides` 缺少於安裝後？**  
該套件可能安裝在不同的 Python 直譯器上。請啟動安裝時使用的虛擬環境，並執行 `python -m pip show aspose-slides-java`。若是 ZIP 安裝，請確保 `asposeslides` 目錄與您的腳本位於同一位置，或已在 Python 的模組搜尋路徑中。

**我可以在筆記本中重複執行範例嗎？**  
此範例設計用於獨立的 Python 行程。若要在筆記本中重複執行，請先參閱[限制與 API 差異](/slides/zh-hant/python-java/limitations-and-api-differences/#import-the-library)以了解 JVM 生命週期與筆記本的相關指導。

**為何 pip 失敗並顯示 `CERTIFICATE_VERIFY_FAILED`？**  
若您的網路使用 HTTPS 檢查代理，pip 必須信任其憑證機構。請依照[pip HTTPS 憑證說明](https://pip.pypa.io/en/stable/topics/https-certificates/)使用 pip 的 `--cert` 選項或 `PIP_CERT` 環境變數設定受信任的 CA 捆綁檔。所需的設定取決於您的網路與 pip 版本。