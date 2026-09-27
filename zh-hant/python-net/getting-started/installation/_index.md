---
title: 安裝
type: docs
weight: 70
url: /zh-hant/python-net/installation/
keywords:
- 下載 Aspose.Slides
- 安裝 Aspose.Slides
- 使用 Aspose.Slides
- Aspose.Slides 安裝
- pip
- PyPI
- Windows
- Linux
- macOS
- Python
description: "在 Windows、Linux 與 macOS 上，透過 .NET 從 PyPI 使用 pip 安裝 Aspose.Slides for Python，並安裝 Linux 與 macOS 所需的原生函式庫。"
---
## **概觀**

本文說明如何在 Windows、Linux 與 macOS 上透過 .NET 安裝 Aspose.Slides for Python。此套件發佈於 [PyPI](https://pypi.org/project/aspose.slides/)，並以 pip 安裝。它已內含所使用的 .NET 執行時，因此不需要另外安裝 .NET。於 Linux 與 macOS 上，執行時需要作業系統未必提供的原生函式庫；以下段落會列出這些函式庫。

Aspose.Slides for Python via .NET 支援 Python 3.5 至 3.14。PyPI 提供 Windows（32 位元與 64 位元）、Linux（x86_64 與 ARM64）與 macOS（Intel 與 Apple silicon）之套件。

## **Windows**

在 Windows 上，使用 pip 安裝套件。不需要其他函式庫。

```bash
pip install aspose.slides
```

## **Linux**

在 Linux 上，套件內含的 .NET 執行時需要兩個函式庫：

- **libgdiplus**，Windows GDI+ 圖形 API 的實作。若缺少此函式庫，儲存簡報時會出現錯誤 `The type initializer for 'Gdip' threw an exception`。
- **ICU**（International Components for Unicode）。若缺少此函式庫，Python 程序在第一次呼叫 Aspose.Slides 時會終止，顯示訊息 `Couldn't find a valid ICU package installed on the system`。

在 Debian 與 Ubuntu 上，使用 apt 安裝兩者：

```bash
sudo apt-get update && sudo apt-get install -y libgdiplus libicu76
```

ICU 套件名稱包含版本號：`libicu76` 為 Debian 13 的套件。Debian 12 使用 `libicu72`，Ubuntu 24.04 使用 `libicu74`。若要查詢系統上的套件名稱，可執行：

```bash
apt-cache search --names-only '^libicu[0-9]+$'
```

接著在虛擬環境中安裝套件。於目前的 Debian 與 Ubuntu 發行版，系統 Python 不允許在非虛擬環境下執行 `pip install`，會因 `externally-managed-environment` 錯誤而停止。

```bash
sudo apt-get install -y python3-venv
python3 -m venv .venv
. .venv/bin/activate
pip install aspose.slides
```

以已啟用相同虛擬環境的方式執行腳本。若使用發行版未管理的 Python（例如官方 `python` Docker 映像），也可在沒有虛擬環境的情況下執行 `pip install aspose.slides`。

必須在系統中安裝簡報使用的字型或相容的替代字型，才能在將投影片轉為 PDF 或圖片時正確呈現文字。

## **macOS**

我們尚未驗證 macOS 上的安裝。於 macOS 上，Aspose.Slides 需要以下前置條件：

- **Python with shared libraries**，即以 `--enable-shared` 設定選項編譯的 Python。若使用 [pyenv](https://github.com/pyenv/pyenv#homebrew-in-macos) 安裝 Python，請在安裝特定 Python 版本時將環境變數 `PYTHON_CONFIGURE_OPTS` 設為 `--enable-shared`。
- **系統函式庫目錄中的 libpython 函式庫**。使用 pyenv 安裝的 Python 會將其 libpython 函式庫（如 *libpython3.9.dylib*）放在 *~/.pyenv/versions* 下；請在 */usr/local/lib* 中建立指向該檔案的符號連結。
- **libgdiplus**，Windows GDI+ 圖形 API 的實作。Homebrew 以 `mono-libgdiplus` 套件提供。

之後使用 pip 安裝套件。

## **檢查安裝**

要檢查安裝是否成功，請將 [建立簡報](/slides/zh-hant/python-net/create-presentation/) 中的第一個範例存為 *hello.py*，並執行 `python hello.py`。它會在目前目錄中產生 *new_presentation.pptx*。

## **升級**

若要將現有安裝升級至最新版本，請在安裝套件的環境中執行以下指令：

```bash
pip install --upgrade aspose.slides
```

## **常見問題**

**我可以在虛擬環境中安裝 Aspose.Slides 嗎？**

可以。您可以在任何 Python 虛擬環境中使用 pip 安裝。Linux 與 macOS 所需的原生函式庫會安裝在系統上，而非虛擬環境內。

**我可以在 Docker 容器中使用 Aspose.Slides 嗎？**

可以。映像必須包含與 Linux 系統相同的原生函式庫——libgdiplus 與 ICU——以及簡報所使用的字型。

**是否有免費版或試用限制？**

有。未提供授權時，Aspose.Slides 會以評估模式執行：會在每張儲存的投影片上加上評估浮水印，且會截斷從簡報讀取的文字。若要移除這些限制，請套用有效的 [授權](/slides/zh-hant/python-net/licensing/)。