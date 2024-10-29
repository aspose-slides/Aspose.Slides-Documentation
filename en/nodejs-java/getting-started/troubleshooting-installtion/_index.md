---
title: Troubleshooting installing Aspose.Slides for Node.js via Java
type: docs
weight: 75
url: /nodejs-java/troubleshooting-installation/
keySlides: "Download Aspose.Slides, Install Aspose.Slides, Aspose.Slides Troubleshooting installing, Windows, macOS, Linux, Javascript, Node.js"
description: "Troubleshooting installing Aspose.Slides for Node.js via Java in Windows, Linux or macOS"
---

When [installing](/nodejs-java/installation/) `aspose.slides.via.java` using `npm`, there are cases where errors occur during the compilation of `java` and `node-gyp` modules. We have investigated these errors in more detail and identified specific requirements for the versions of installed programs and packages. 

## **Version requirements**

1. For Node.js 12 and earlier:
   - Python not higher than 3.10.
   - For Windows, it is recommended to install Visual Studio Build Tools no newer than 2017.
   - npm java package version: 0.12.1.

2. For Node.js 13:
   - Same requirements as for Node.js 12.

3. For Node.js 14:
   - Python 3.10.
   - npm java package version: 0.14.0.

4. For Node.js 15:
   - Python 3.12.
   - npm java package version: 0.14.0.

5. For Node.js 16 and newer:
   - Python 3.12.
   - npm java package version: 0.14.0.

**Follow the instructions below to install the required programs.**

### **Installation on Unix**

- Install [Node.js](https://nodejs.org/en/download).
- Install [Python](https://devguide.python.org/versions/).
- Install Java (JDK 1.8).
- Install a proper C/C++ compiler toolchain, such as [GCC](https://gcc.gnu.org).

### **Installation on macOS**

- Install [Node.js](https://nodejs.org/en/download).
- Install [Python](https://devguide.python.org/versions/).
- Install Java (JDK 1.8) and modify JVMCapabilities section in /Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist with root privilege. jdk1.8.x_xxx.jdk depends on your jdk version. Make it look like this: 
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
- Install the `Xcode Command Line Tools` standalone by running `xcode-select --install`. -- OR -- Alternatively, if you already have the [full Xcode installed](https://developer.apple.com/xcode/download/), you can install the Command Line Tools under the menu `Xcode -> Open Developer Tool -> More Developer Tools...`.

### **Installation on Windows**

- Install [Node.js](https://nodejs.org/en/download).
- Install [Python](https://devguide.python.org/versions/) from the [Microsoft Store](https://apps.microsoft.com/store/search?publisher=Python+Software+Foundation).
- Install Java (JDK 1.8).
- Install [Visual C++ Build Environment](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools) (using "Visual C++ build tools" if using a version older than VS2019, otherwise use "Desktop development with C++" workload or [Visual Studio Community](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community) using the "Desktop development with C++" workload).


Ensure that Node.js, Python, and Java are added to the PATH variable.

## **Installation of Aspose.Slides for Node.js via Java on Node.js version 14 and newer**

Simply use the command:
```
npm i aspose.slides.via.java
```

## **Installation of Aspose.Slides for Node.js via Java on Node.js version 12 or 13**

Aspose.Slides for Node.js via Java needs to be installed manually. Use the following command:

- For Node.js 12:
```
npm i java@0.12.1
```
- For Node.js 13: 
```
npm i java@0.13.0
```

After that, download [aspose.slides.via.java](https://releases.aspose.com/slides/nodejs-java/) and extract it to the `node_modules/aspose.slides.via.java` folder.

## **Validation of installation**

To validate the installation, create a file `index.js` in the root of your project with the following content:

```javascript
var aspose = aspose || {};
var java = require('java');
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);
slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
presentation.save("lineShape.pptx", aspose.slides.SaveFormat.Pptx);
```

Execute this file using the command `node index.js`.

## **Additional Information**

It is not possible to cover all possible problems within the scope of this article. Since problems arise due to the compilation of `java` and `node-gyp` modules the following links will also be useful:
- [java installation](https://www.npmjs.com/package/java#installation) 
- [node-gyp installation](https://www.npmjs.com/package/node-gyp#installation)