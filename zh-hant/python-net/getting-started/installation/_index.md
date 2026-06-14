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
- Windows
- macOS
- Python
description: "了解如何快速安裝 Aspose.Slides for Python via .NET。逐步指南、系統需求與程式碼範例 — 今天就開始使用 PowerPoint 簡報！"
---
## **概觀**

Aspose.Slides for Python via .NET 套件已將所有必要的 .NET 函式庫捆綁，這意味著無需另外安裝 .NET。此方式簡化了設定流程，開發人員可立即開始處理簡報。然而，請留意依據您的作業系統或環境，仍可能需要安裝 .NET 所需的特定平台相依性。此外，必須滿足某些系統需求，以確保套件的完整相容性與正常運作。

## **Windows**

**系統需求**

檢查並確認您的機器規格符合或超過[系統需求](/slides/zh-hant/python-net/system-requirements/)。

### **安裝 Aspose.Slides**

`pip` 是在 Windows 上下載與安裝[Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) 的最簡方式。

要安裝 Aspose.Slides，請執行以下指令：

```sh
pip install aspose-slides
```

**使用 Aspose.Slides**

執行下列程式碼以建立 PowerPoint 簡報，測試您的 Aspose.Slides 安裝是否成功：

```python
# 匯入 Aspose.Slides for Python via .NET 模組。
import aspose.slides as slides

# 建立代表簡報檔案的 Presentation 類別實例。
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **macOS**

**系統需求**

檢查並確認您的機器規格符合或超過[系統需求](/slides/zh-hant/python-net/system-requirements/)。

### **前置條件**

**含共享函式庫的 Python**

macOS 上有多種安裝 Python 的方式，但我們強烈建議使用[pyenv 工具](https://github.com/pyenv/pyenv#homebrew-in-macos)。

安裝並設定 **pyenv** 後，請在 Terminal 應用程式中執行以下指令以安裝含共享函式庫的 Python：

1. 安裝 Python：

```sh
env PYTHON_CONFIGURE_OPTS="--enable-shared" pyenv install --verbose 3.9.13
```

2. 將其設為全域 Python 版本：

```sh
pyenv global 3.9.13
```

3. 將其設為 Shell 專屬 Python 版本：

```sh
pyenv shell 3.9.13
```

4. 在系統函式庫目錄中為 libpython 函式庫建立符號連結：

```sh
ln -s /Users/<username>/.pyenv/versions/3.9.13/lib/libpython3.9.dylib /usr/local/lib/libpython3.9.dylib
```

注意：需要 Python 3.5 或更高版本。此處以 3.9.13 為範例。

**安裝 libgdiplus 函式庫**

**libgdiplus** 函式庫是 .NET 在 macOS 與 Linux 上使用的 Windows GDI+ 實作，提供圖形功能。若要在 macOS 上安裝此函式庫，請執行以下指令：

```sh
brew install mono-libgdiplus
```

### **安裝 Aspose.Slides**

`pip` 是在 macOS 上下載與安裝[Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) 的最簡方式。

要安裝 Aspose.Slides，請執行以下指令：

```sh
pip install aspose-slides
```

**使用 Aspose.Slides**

執行下列程式碼以建立 PowerPoint 簡報，測試您的 Aspose.Slides 安裝是否成功：

```python
# 匯入 Aspose.Slides for Python via .NET 模組。
import aspose.slides as slides

# 建立代表簡報檔案的 Presentation 類別實例。
with slides.Presentation() as presentation:    
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**我可以在虛擬環境中安裝 Aspose.Slides 嗎？**

可以，您可以在任何 Python 虛擬環境中使用 `pip` 安裝。只要確保該環境可取得依作業系統需求的原生相依性即可。

**我可以在 Docker 容器中使用 Aspose.Slides 嗎？**

可以，但必須確保您的 Docker 映像檔已包含所需的原生函式庫（**libgdiplus**、字型套件等）以及正確版本的 Python。

**是否有免費版或試用限制？**

有，預設情況下 Aspose.Slides 以評估模式執行，會加上浮水印且可能有其他限制。若要解除這些限制，需套用有效的[授權](/slides/zh-hant/python-net/licensing/)。