---
title: 安装
type: docs
weight: 70
url: /zh/cpp/installation/
keywords: "下载 Aspose.Slides, 安装 Aspose.Slides, Aspose.Slides 安装, Windows, C++"
description: "在 Windows 中为 C++ 安装 Aspose.Slides"
---

## **Windows**
NuGet 为在 PC 上下载和安装 C++ 的 Aspose API 提供了最简单的路径。

### **选项一：通过 NuGet 包管理器安装或更新 Aspose.Slides for C++**

1. 打开 Microsoft Visual Studio。
2. 创建一个简单的控制台应用程序，或者你可以打开你喜欢的项目。
3. 依次点击 **工具** > **NuGet 包管理器**。
4. 在 **浏览** 中，在文本框中输入 *Aspose.Slides.Cpp*。

![todo:image_alt_text](installation_1.png)

3. 点击你需要的版本 **Aspose.Slides.Cpp**，然后点击 **安装**。
   * 如果你想更新 Aspose.Slides——意味着你已经安装了它——请点击 **更新**。

所选 API 被下载并在你的项目中被引用。

### **选项二：通过包管理控制台安装或更新 Aspose.Slides**

要通过包管理控制台引用 [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.Cpp/)，请按以下步骤操作：

1. 在 Visual Studio 中打开你的解决方案/项目。

1. 依次点击 **工具** > **NuGet 包管理器** > **包管理控制台**。

   包管理控制台打开。

![todo:image_alt_text](installation_2.png)

4. 输入该命令：`Install-Package Aspose.Slides.Cpp` 
> 如果你想安装 x86 版本，请使用 Aspose.Slides.Cpp.x86 包：`Install-Package Aspose.Slides.Cpp.x86`

5. 按下回车键。

   最新的完整版本将被安装到你的应用程序中。

   * 另外，你可以在命令后添加 `-prerelease` 后缀以指定也必须安装最新版本（包括热修复）。

![todo:image_alt_text](installation_3.png)

一旦下载完成，你应该会看到一些确认消息。

![todo:image_alt_text](installation_4.png)

如果你不熟悉 [Aspose EULA](https://about.aspose.com/legal/eula)，你可能想阅读 URL 中引用的许可证。

在包管理控制台中，你可以运行 `Update-Package Aspose.Slides.Cpp` 命令以检查 Aspose.Slides 包的更新。系统会自动安装发现的更新。你也可以使用 `-prerelease` 后缀来更新最新版本。

### 使用 Include 和 lib 文件夹
1. [下载](https://downloads.aspose.com/slides/cpp) 最新的 Aspose.Slides for C++ 版本。
1. 将文件夹解压到生产环境。
1. 要使用 Aspose.Slides for C++，在你的项目中引用 Include 和 lib 文件夹。