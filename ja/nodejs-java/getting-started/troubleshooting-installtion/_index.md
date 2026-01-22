---
title: Aspose.Slides for Node.js via Java のインストールのトラブルシューティング
linktitle: インストールのトラブルシューティング
type: docs
weight: 75
url: /ja/nodejs-java/troubleshooting-installation/
keywords:
- Aspose.Slides のダウンロード
- Aspose.Slides のインストール
- インストールのトラブルシューティング
- バージョン要件
- Windows
- macOS
- Linux
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java のインストール問題をトラブルシュートし、一般的なエラーや依存関係を修正して、PPT、PPTX、ODP をスムーズに扱えるようにします。"
---

npm を使用して `aspose.slides.via.java` を[インストール](/slides/ja/nodejs-java/installation/)する際、`java` および `node-gyp` モジュールのコンパイル中にエラーが発生する場合があります。これらのエラーを詳しく調査し、インストールされたプログラムおよびパッケージのバージョンに対する具体的な要件を特定しました。

## **バージョン要件**

1. Node.js 12 以前の場合：
   - Python は 3.10 以下であること。
   - Windows の場合、2017 年以前の Visual Studio Build Tools のインストールが推奨されます。
   - npm java パッケージのバージョン: 0.12.1。

2. Node.js 13 の場合：
   - Node.js 12 と同じ要件です。

3. Node.js 14 の場合：
   - Python 3.10。
   - npm java パッケージのバージョン: 0.14.0。

4. Node.js 15 の場合：
   - Python 3.12。
   - npm java パッケージのバージョン: 0.14.0。

5. Node.js 16 以降の場合：
   - Python 3.12。
   - npm java パッケージのバージョン: 0.14.0。

**以下の手順に従って必要なプログラムをインストールしてください。**

### **Unix へのインストール**

- [Node.js](https://nodejs.org/en/download) をインストール。
- [Python](https://devguide.python.org/versions/) をインストール。
- Java (JDK 1.8) をインストール。
- [GCC](https://gcc.gnu.org) などの適切な C/C++ コンパイラツールチェーンをインストール。

### **macOS へのインストール**

- [Node.js](https://nodejs.org/en/download) をインストール。
- [Python](https://devguide.python.org/versions/) をインストール。
- Java (JDK 1.8) をインストールし、ルート権限で /Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist の JVMCapabilities セクションを変更します。jdk1.8.x_xxx.jdk は使用している JDK バージョンに依存します。以下のように設定してください：
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

- `xcode-select --install` を実行して `Xcode Command Line Tools` を単独でインストールします。-- OR -- あるいは、[フル Xcode がインストール済み](https://developer.apple.com/xcode/download/)の場合は、メニュー `Xcode -> Open Developer Tool -> More Developer Tools...` から Command Line Tools をインストールできます。

### **Windows へのインストール**

- [Node.js](https://nodejs.org/en/download) をインストール。
- [Microsoft Store](https://apps.microsoft.com/store/search?publisher=Python+Software+Foundation) から [Python](https://devguide.python.org/versions/) をインストール。
- Java (JDK 1.8) をインストール。
- [Visual C++ Build Environment](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools) をインストールします（VS2019 より古いバージョンを使用している場合は "Visual C++ build tools"、それ以外の場合は "Desktop development with C++" ワークロード、または [Visual Studio Community](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community) の "Desktop development with C++" ワークロードを使用）。
  
Node.js、Python、Java が PATH 環境変数に追加されていることを確認してください。

## **Node.js バージョン 14 以降での Aspose.Slides for Node.js via Java のインストール**

以下のコマンドを実行するだけです：
```
npm i aspose.slides.via.java
```


## **Node.js バージョン 12 または 13 での Aspose.Slides for Node.js via Java のインストール**

Aspose.Slides for Node.js via Java は手動でインストールする必要があります。以下のコマンドを使用してください：

- Node.js 12 用:
```
npm i java@0.12.1
```

- Node.js 13 用:
```
npm i java@0.13.0
```


その後、[aspose.slides.via.java](https://releases.aspose.com/slides/nodejs-java/) をダウンロードし、`node_modules/aspose.slides.via.java` フォルダーに展開してください。

## **インストールの検証**

インストールを検証するには、プロジェクトのルートに `index.js` ファイルを作成し、以下の内容を記述します：
```javascript
var aspose = aspose || {};
var java = require('java');
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);
slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
presentation.save("lineShape.pptx", aspose.slides.SaveFormat.Pptx);
```


`node index.js` コマンドでこのファイルを実行します。

## **追加情報**

この記事の範囲内ですべての可能な問題を網羅することはできません。`java` および `node-gyp` モジュールのコンパイルに起因する問題があるため、以下のリンクも有用です：

- [java インストール](https://www.npmjs.com/package/java#installation) 
- [node-gyp インストール](https://www.npmjs.com/package/node-gyp#installation)