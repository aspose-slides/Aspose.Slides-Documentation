---
title: Aspose.SlidesをJava経由でNode.jsにインストールする際のトラブルシューティング
type: docs
weight: 75
url: /nodejs-java/troubleshooting-installation/
keySlides: "Aspose.Slidesをダウンロード, Aspose.Slidesのインストール, Aspose.Slidesトラブルシューティング, インストール, Windows, macOS, Linux, Javascript, Node.js"
description: "Windows、Linux、またはmacOSのJava経由でNode.js用Aspose.Slidesのインストールに関するトラブルシューティング"
---

`npm`を使用して[installing](/nodejs-java/installation/) `aspose.slides.via.java`を行う際、`java`および`node-gyp`モジュールのコンパイル中にエラーが発生する場合があります。これらのエラーを詳細に調査し、インストールされたプログラムとパッケージのバージョンに関する特定の要件を特定しました。

## **バージョン要件**

1. Node.js 12およびそれ以前:
   - Python 3.10を超えないこと。
   - Windowsの場合、2017年以降のVisual Studio Build Toolsをインストールすることを推奨。
   - npmのjavaパッケージバージョン: 0.12.1。

2. Node.js 13:
   - Node.js 12と同じ要件。

3. Node.js 14:
   - Python 3.10。
   - npmのjavaパッケージバージョン: 0.14.0。

4. Node.js 15:
   - Python 3.12。
   - npmのjavaパッケージバージョン: 0.14.0。

5. Node.js 16以降:
   - Python 3.12。
   - npmのjavaパッケージバージョン: 0.14.0。

**必要なプログラムをインストールするための手順に従ってください。**

### **Unixでのインストール**

- [Node.js](https://nodejs.org/en/download)をインストール。
- [Python](https://devguide.python.org/versions/)をインストール。
- Java（JDK 1.8）をインストール。
- [GCC](https://gcc.gnu.org)などの適切なC/C++コンパイラツールチェーンをインストール。

### **macOSでのインストール**

- [Node.js](https://nodejs.org/en/download)をインストール。
- [Python](https://devguide.python.org/versions/)をインストール。
- Java（JDK 1.8）をインストールし、/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist内のJVMCapabilitiesセクションをルート権限で変更します。jdk1.8.x_xxx.jdkはあなたのjdkバージョンに依存します。以下のようにします: 
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
- `xcode-select --install`を実行して`Xcode Command Line Tools`をスタンドアロンでインストールします。-- または、すでに[フルバージョンのXcode](https://developer.apple.com/xcode/download/)がインストールされている場合は、メニュー`Xcode -> Open Developer Tool -> More Developer Tools...`からCommand Line Toolsをインストールできます。

### **Windowsでのインストール**

- [Node.js](https://nodejs.org/en/download)をインストール。
- [Microsoft Store](https://apps.microsoft.com/store/search?publisher=Python+Software+Foundation)から[Python](https://devguide.python.org/versions/)をインストール。
- Java（JDK 1.8）をインストール。
- [Visual C++ Build Environment](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools)をインストール（VS2019より古いバージョンを使用している場合は「Visual C++ build tools」を使用、そうでなければ「C++によるデスクトップ開発」ワークロードまたは[Visual Studio Community](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community)の「C++によるデスクトップ開発」ワークロードを使用）。

Node.js、Python、およびJavaがPATH変数に追加されていることを確認してください。

## **Node.jsバージョン14以降のJava経由でのAspose.Slidesのインストール**

次のコマンドを使用します:
```
npm i aspose.slides.via.java
```

## **Node.jsバージョン12または13のJava経由でのAspose.Slidesのインストール**

Aspose.Slides for Node.js via Javaは手動でインストールする必要があります。次のコマンドを使用してください:

- Node.js 12の場合:
```
npm i java@0.12.1
```
- Node.js 13の場合: 
```
npm i java@0.13.0
```

その後、[aspose.slides.via.java](https://releases.aspose.com/slides/nodejs-java/)をダウンロードし、`node_modules/aspose.slides.via.java`フォルダーに展開します。

## **インストールの検証**

インストールを検証するために、プロジェクトのルートに`index.js`というファイルを作成し、以下の内容を記述します:

```javascript
var aspose = aspose || {};
var java = require('java');
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);
slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
presentation.save("lineShape.pptx", aspose.slides.SaveFormat.Pptx);
```

このファイルを`node index.js`コマンドで実行します。

## **追加情報**

この記事の範囲内で考えられるすべての問題をカバーすることは不可能です。`java`および`node-gyp`モジュールのコンパイルによって問題が発生するため、以下のリンクも参考になります:
- [java installation](https://www.npmjs.com/package/java#installation) 
- [node-gyp installation](https://www.npmjs.com/package/node-gyp#installation)