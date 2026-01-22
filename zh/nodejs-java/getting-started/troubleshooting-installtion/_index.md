---
title: 通过 Java 的 Aspose.Slides for Node.js 安装故障排除
linktitle: 故障排除安装
type: docs
weight: 75
url: /zh/nodejs-java/troubleshooting-installation/
keywords:
- 下载 Aspose.Slides
- 安装 Aspose.Slides
- 故障排除安装
- 版本要求
- Windows
- macOS
- Linux
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "故障排除通过 Java 的 Aspose.Slides for Node.js 安装问题，修复常见错误和依赖，并确保 PPT、PPTX 和 ODP 的顺畅使用。"
---

当使用 `npm` [安装](/slides/zh/nodejs-java/installation/) `aspose.slides.via.java` 时，`java` 和 `node-gyp` 模块的编译过程中可能会出现错误。我们对这些错误进行了更深入的调查，并确定了已安装程序和包的版本的具体要求。

## **版本要求**

1. 针对 Node.js 12 及更早版本：
   - Python 版本不高于 3.10。
   - 在 Windows 上，建议安装不高于 2017 年的 Visual Studio Build Tools。
   - npm java 包版本：0.12.1。

2. 针对 Node.js 13：
   - 要求与 Node.js 12 相同。

3. 针对 Node.js 14：
   - Python 3.10。
   - npm java 包版本：0.14.0。

4. 针对 Node.js 15：
   - Python 3.12。
   - npm java 包版本：0.14.0。

5. 针对 Node.js 16 及更高版本：
   - Python 3.12。
   - npm java 包版本：0.14.0。

**请按照以下说明安装所需的程序。**

### **在 Unix 上的安装**

- 安装 [Node.js](https://nodejs.org/en/download)。
- 安装 [Python](https://devguide.python.org/versions/)。
- 安装 Java (JDK 1.8)。
- 安装适当的 C/C++ 编译器工具链，例如 [GCC](https://gcc.gnu.org)。

### **在 macOS 上的安装**

- 安装 [Node.js](https://nodejs.org/en/download)。
- 安装 [Python](https://devguide.python.org/versions/)。
- 安装 Java (JDK 1.8) 并使用根权限修改 `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` 中的 JVMCapabilities 部分。`jdk1.8.x_xxx.jdk` 根据您的 JDK 版本而定。使其看起来像下面这样： 
```
<key>JavaVM</key>
    <dict>
        <key>JVMCapabilities</key>
        <array>
                <string>JNI</string>
                <string>BundledApp</string>
                <string>CommandLine</string>
        </array>
```

- 通过运行 `xcode-select --install` 安装 `Xcode Command Line Tools`。-- 或者 -- 如果您已经安装了 [完整的 Xcode](https://developer.apple.com/xcode/download/)，也可以在菜单 `Xcode -> Open Developer Tool -> More Developer Tools...` 中安装命令行工具。

### **在 Windows 上的安装**

- 安装 [Node.js](https://nodejs.org/en/download)。
- 从 [Microsoft Store](https://apps.microsoft.com/store/search?publisher=Python+Software+Foundation) 安装 [Python](https://devguide.python.org/versions/)。
- 安装 Java (JDK 1.8)。
- 安装 [Visual C++ Build Environment](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools)（如果使用早于 VS2019 的版本，请选择 “Visual C++ build tools”，否则请使用 “Desktop development with C++” 工作负载，或使用带有 “Desktop development with C++” 工作负载的 [Visual Studio Community](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community)）。

确保 Node.js、Python 和 Java 已添加到 PATH 变量中。

## **在 Node.js 14 及更高版本上通过 Java 安装 Aspose.Slides for Node.js**

只需使用以下命令：
```
npm i aspose.slides.via.java
```


## **在 Node.js 12 或 13 上通过 Java 安装 Aspose.Slides for Node.js**

需要手动安装 Aspose.Slides for Node.js via Java。使用以下命令：

- 针对 Node.js 12：
```
npm i java@0.12.1
```

- 针对 Node.js 13：
```
npm i java@0.13.0
```


随后，从 [aspose.slides.via.java](https://releases.aspose.com/slides/nodejs-java/) 下载并解压至 `node_modules/aspose.slides.via.java` 文件夹。

## **验证安装**

要验证安装，请在项目根目录创建一个名为 `index.js` 的文件，内容如下：
```javascript
var aspose = aspose || {};
var java = require('java');
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);
slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
presentation.save("lineShape.pptx", aspose.slides.SaveFormat.Pptx);
```


使用命令 `node index.js` 执行此文件。

## **其他信息**

本文无法覆盖所有可能的问题。由于问题是由 `java` 和 `node-gyp` 模块的编译引起的，以下链接也很有帮助：
- [java 安装](https://www.npmjs.com/package/java#installation) 
- [node-gyp 安装](https://www.npmjs.com/package/node-gyp#installation)