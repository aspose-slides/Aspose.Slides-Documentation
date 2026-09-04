---
title: 系統需求
type: docs
weight: 60
url: /zh-hant/python-java/system-requirements/
keywords:
- 系統需求
- Python
- Java
- JPype
- Windows
- Linux
- macOS
- Aspose.Slides
description: "檢查在 Windows、Linux 與 macOS 上執行 Aspose.Slides for Python via Java 所需的作業系統、Python、Java 與 JPype 要求。"
---
## **概述**

Aspose.Slides for Python via Java 可在未安裝 Microsoft PowerPoint 的情況下建立、修改、轉換與呈現簡報。它使用 JPype 從 Python 存取 Java 程式庫，因此環境必須同時支援 Python、Java 與 JPype。

## **支援的作業系統**

[Aspose.Slides 套件](https://pypi.org/project/aspose-slides-java/) 支援以下作業系統族群：

- Windows
- Linux
- macOS

選擇與您所使用的 Python、Java 與 JPype 版本相容的作業系統版本。僅有 Java 可用並不足以保證與 Python 套件及其橋接層的相容性。

## **Python、Java 與 JPype 要求**

| Component | Requirement |
| --- | --- |
| Python | Aspose.Slides 套件宣告支援 Python 3.7 至 3.14。選擇的 JPype 版本必須支援相同的 Python 版本；例如，[JPype1 1.7.1](https://pypi.org/project/jpype1/1.7.1/) 需要 Python 3.8 以上。 |
| Java | 安裝與選擇的 JPype 版本相容的 Java 執行環境或 JDK。目前的 [JPype 前置條件](https://jpype.readthedocs.io/en/latest/userguide.html#prerequisites) 指定 Java 11 或更新版本。Java 8 無法執行 JPype1 1.7.1。 |
| JPype | 為您的 Python 直譯器、作業系統與 CPU 架構安裝 JPype1 套件。 |
| CPU architecture | Python 與 Java 虛擬機器 (JVM) 必須使用相同的架構。例如，64 位元的 Python 直譯器需要相容的 64 位元 JVM。 |

在 Apple Silicon 上，Python 與 Java 必須同時使用 ARM64 或同時使用 x64。即使獨立執行的 JVM 架構與 Python 不同，也會因 JPype 無法載入而失敗。

對於新環境，Python 3.12、JDK 17 與 JPype1 1.7.1 是合適的起點。此組合已在 Windows 上使用 Aspose.Slides for Python via Java 26.6.0 進行驗證。其他組合必須同時符合三個元件的需求。

有關環境設定與可行驗證範例，請參閱 [Installation](/slides/zh-hant/python-java/installation/)。

## **其他相依性**

相容的預建 JPype 輪檔不需要 C++ 編譯器。如果必須自行從原始碼建置 JPype，請安裝相容的 C++ 編譯器以及平台所需的 Python 開發檔案。請參考 [JPype 安裝說明](https://jpype.readthedocs.io/en/latest/install.html) 了解建置需求與故障排除。

## **常見問題**

**我需要安裝 Microsoft PowerPoint 嗎？**

不需要。Aspose.Slides 可在不依賴 PowerPoint 的情況下處理簡報。仍然需要 Python、Java 與 JPype。

**我可以使用 Python 3.7 搭配任何 JPype 版本嗎？**

不能。雖然 Aspose.Slides 套件宣告支援 Python 3.7，但 JPype1 1.7.1 需要 Python 3.8 以上。請選擇需求重疊的版本。

**我可以將 32 位元 Python 與 64 位元 Java 混用嗎？**

不能。JPype 會將 JVM 載入 Python 行程中，因此 Python 與 Java 必須使用相同的架構。相同的要求亦適用於 macOS 上的 ARM64 與 x64。