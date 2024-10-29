---
title: 通过 Java 安装 Aspose.Slides for Node.js 的故障排除
type: docs
weight: 75
url: /zh/nodejs-java/troubleshooting-installation/
keySlides: "下载 Aspose.Slides，安装 Aspose.Slides，Aspose.Slides 故障排除，Windows，macOS，Linux，Javascript，Node.js"
description: "在 Windows、Linux 或 macOS 上通过 Java 安装 Aspose.Slides for Node.js 的故障排除"
---

在使用 `npm` 安装 `aspose.slides.via.java` 时，可能会出现 `java` 和 `node-gyp` 模块编译错误的情况。我们对这些错误进行了更详细的调查，并确定了已安装程序和包的版本要求。

## **版本要求**

1. 对于 Node.js 12 及以前版本：
   - Python 不高于 3.10。
   - 对于 Windows，建议安装不晚于 2017 的 Visual Studio Build Tools。
   - npm java 包版本：0.12.1。

2. 对于 Node.js 13：
   - 与 Node.js 12 相同的要求。

3. 对于 Node.js 14：
   - Python 3.10。
   - npm java 包版本：0.14.0。

4. 对于 Node.js 15：
   - Python 3.12。
   - npm java 包版本：0.14.0。

5. 对于 Node.js 16 及更高版本：
   - Python 3.12。
   - npm java 包版本：0.14.0。

**请按照以下说明安装所需的程序。**

### **在 Unix 上安装**

- 安装 [Node.js](https://nodejs.org/en/download)。
- 安装 [Python](https://devguide.python.org/versions/)。
- 安装 Java (JDK 1.8)。
- 安装适当的 C/C++ 编译器工具链，例如 [GCC](https://gcc.gnu.org)。

### **在 macOS 上安装**

- 安装 [Node.js](https://nodejs.org/en/download)。
- 安装 [Python](https://devguide.python.org/versions/)。
- 安装 Java (JDK 1.8)，并以 root 权限修改 /Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist 中的 JVMCapabilities 部分。jdk1.8.x_xxx.jdk 依赖于您的 jdk 版本。使其看起来像这样：
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
- 通过运行 `xcode-select --install` 安装独立的 `Xcode Command Line Tools`。-- 或 -- 如果您已经安装了 [完整的 Xcode](https://developer.apple.com/xcode/download/)，则可以在菜单 `Xcode -> Open Developer Tool -> More Developer Tools...` 下安装命令行工具。

### **在 Windows 上安装**

- 安装 [Node.js](https://nodejs.org/en/download)。
- 从 [Microsoft Store](https://apps.microsoft.com/store/search?publisher=Python+Software+Foundation) 安装 [Python](https://devguide.python.org/versions/)。
- 安装 Java (JDK 1.8)。
- 安装 [Visual C++ Build Environment](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools)（如果使用低于 VS2019 的版本，使用“Visual C++ build tools”，否则选择“带 C++ 的桌面开发”工作负载或使用“带 C++ 的桌面开发”工作负载的 [Visual Studio Community](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community)）。

确保将 Node.js、Python 和 Java 添加到 PATH 环境变量中。

## **在 Node.js 版本 14 及更高版本上通过 Java 安装 Aspose.Slides for Node.js**

只需使用命令：
```
npm i aspose.slides.via.java
```

## **在 Node.js 版本 12 或 13 上通过 Java 安装 Aspose.Slides for Node.js**

Aspose.Slides for Node.js via Java 需要手动安装。请使用以下命令：

- 对于 Node.js 12：
```
npm i java@0.12.1
```
- 对于 Node.js 13：
```
npm i java@0.13.0
```

之后，下载 [aspose.slides.via.java](https://releases.aspose.com/slides/nodejs-java/) 并将其解压到 `node_modules/aspose.slides.via.java` 文件夹中。

## **安装验证**

要验证安装，请在项目根目录中创建一个名为 `index.js` 的文件，内容如下：

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

## **附加信息**

在此文章的范围内无法覆盖所有可能的问题。由于问题的出现与 `java` 和 `node-gyp` 模块的编译有关，以下链接也将有用：
- [java 安装](https://www.npmjs.com/package/java#installation) 
- [node-gyp 安装](https://www.npmjs.com/package/node-gyp#installation)