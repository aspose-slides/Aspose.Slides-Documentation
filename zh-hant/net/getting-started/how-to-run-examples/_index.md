---
title: 如何執行範例
type: docs
weight: 130
url: /zh-hant/net/how-to-run-examples/
keywords:
- 範例
- 軟體需求
- NuGet
- GitHub
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "快速執行 Aspose.Slides for .NET 範例：克隆倉庫、還原套件，然後建置並測試 PPT、PPTX 與 ODP 的功能。"
---
## **軟體需求**
在下載並執行範例之前，請檢查並確認您的環境符合以下需求：

- Visual Studio 2010 或更新版本。
- 在 Visual Studio 中安裝 NuGet 套件管理員。請確認已安裝最新的 NuGet API 版本。

有關安裝 NuGet 套件管理員的說明，請前往此頁面： https://docs.microsoft.com/en-us/nuget/install-nuget-client-tools

1. 前往 **Tools** > **Options** > **NuGet Package Manager**。

1. 展開 **NuGet Package Manager**（雙擊即可），然後選取 **Package Sources**。

1. 檢查並確認已選取 nuget.org 參數。

   此範例專案使用 NuGet 自動套件還原功能，因此您需要具備可用的網際網路連線。

   如果欲執行範例的機器未連線網際網路，請參閱[Installation](https://docs.aspose.com/slides/zh-hant/net/installation/)並手動在範例專案中加入 Aspose.Slides.dll 的參考。
## **從 GitHub 下載 Aspose.Slides**
所有 Aspose.Slides for .NET 的範例均託管於 [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET)。

您可以使用喜愛的 GitHub 用戶端克隆儲存庫，或是點擊[此處](https://github.com/aspose-slides/Aspose.Slides-for-.NET/archive/master.zip)下載 ZIP 壓縮檔。

1. 如果下載 ZIP 檔案，必須將其內容解壓縮至電腦上的資料夾。

所有範例均存放於 **Examples** 資料夾中。

此專案包含 C# Visual Studio 解決方案檔案。雖然專案建立於 Visual Studio 2013，但解決方案檔相容於 Visual Studio 2010 SP1 及以上版本。

2. 在 Visual Studio 中開啟解決方案檔並建置專案。

   首次執行時，會透過 NuGet 自動下載相依性。

**Examples** 根目錄中的 **Data** 資料夾內含 C# 範例所使用的輸入檔案。您需要將 **Data** 資料夾與範例專案一起下載。

3. 開啟 RunExamples.cs 檔案。所有範例皆由此呼叫。

4. 取消註解您想要執行的範例程式碼。

如果在設定或執行範例時遇到問題，歡迎透過我們的論壇與我們聯繫。
## **貢獻**
您可以透過新增或改進範例為專案貢獻。儲存庫中的所有範例與展示專案皆為開源，您（以及其他人）都可以自由在應用程式中使用它們。

若欲貢獻，請先 Fork 此儲存庫、編輯原始碼並建立 Pull Request。我們會審查您的變更，若其有用，將會合併至儲存庫。