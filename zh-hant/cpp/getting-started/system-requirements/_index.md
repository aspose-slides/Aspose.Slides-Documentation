---
title: 系統需求
type: docs
weight: 80
url: /zh-hant/cpp/system-requirements/
keywords:
- 系統需求
- 作業系統
- 安裝
- 相依性
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "了解 Aspose.Slides for C++ 的系統需求。確保在 Windows、Linux 與 macOS 上順暢支援 PowerPoint 與 OpenDocument。"
---
## **簡介**

Aspose.Slides 不需要安裝 Microsoft PowerPoint，因為 Aspose.Slides 是一個獨立的 Microsoft PowerPoint 文件建立、轉換、頁面布局與轉譯引擎。

## **支援的作業系統**
Aspose.Slides for C++ 是原生 C++ 函式庫。Aspose.Slides for C++ 支援以下 64 位元與 32 位元作業系統與平台：

### **Windows**
- Microsoft Windows Server 2008 (x64, x86)
- Microsoft Windows Server 2012 (x64, x86)
- Microsoft Windows Server 2012 R2 (x64, x86)
- Microsoft Windows Server 2016 (x64, x86)
- Microsoft Windows Server 2019 (x64, x86)
- Microsoft Windows XP (x64, x86)
- Microsoft Windows 7 (x64, x86)
- Microsoft Windows 8, 8.1 (x64, x86)
- Microsoft Windows 10 (x64, x86)

### **Linux**
- OS Ubuntu 16.04 或更新版本。
- CentOS 8 或更新版本。
- Fedora 24 或更新版本。
- 以及其他使用 glibc 2.23 或更新版本的 Linux x86_64。

### **macOS**
- macOS Monterey 12.1 或更新版本。

## **開發環境**
您可以在 Windows、Linux 或 macOS 上使用 Aspose.Slides for C++ 開發應用程式。

### **Windows**
- Microsoft Visual Studio 2017 或更新版本。
- CMake 3.18 或更新版本。

### **Linux**
- Clang 3.9 或更新版本。
- GCC 6.1 或更新版本。
- CMake 3.18 或更新版本。

### **macOS**
- Xcode 13.4 或更新版本。

## **常見問題**

**我需要安裝 Microsoft PowerPoint 來進行轉換和轉譯嗎？**

不需要，PowerPoint 並非必要；Aspose.Slides 是一個獨立的引擎，可用於[建立](/slides/zh-hant/cpp/create-presentation/)、修改、[轉換](/slides/zh-hant/cpp/convert-presentation/)以及[轉譯](/slides/zh-hant/cpp/convert-powerpoint-to-png/)簡報。

**正確轉譯需要哪些字型？**

實務上，簡報中使用的字型或適當的[替代字型](/slides/zh-hant/cpp/font-substitution/) 必須可用。為確保在 Linux/macOS 上的轉譯一致性，建議安裝常見的字型套件。

**為何自訂字型在 Linux 上顯示為備用或缺少的文字？**

如果字型檔案的名稱表條目不一致或受損，Linux 的字型匹配堆疊（FreeType/fontconfig）可能會選取無效記錄，導致字型無法解析。使用已修正名稱表的字型版本或安裝一致的替代字型即可解決此問題。