---
title: インストール
type: docs
weight: 70
url: /ja/nodejs-java/installation/
keySlides: "Aspose.Slidesのダウンロード, Aspose.Slidesのインストール, Aspose.Slidesのインストール, Windows, macOS, Linux, Javascript, Node.js"
description: "Windows、Linux、またはmacOSでJava経由でNode.js用のAspose.Slidesをインストールします"
---

Java経由のNode.js用Aspose.Slidesはプラットフォームに依存しないAPIであり、`Node.js`と[`java`](https://www.npmjs.com/package/java)ブリッジがインストールされている任意のプラットフォーム（Windows、Linux、MacOS）で使用できます。

## **NPMからインストール**

[NPM](https://www.npmjs.com/)からJava経由でNode.js用のAspose.Slidesを簡単にインストールできます。

新しいフォルダを作成し、次のコマンドを使用して新しいプロジェクトを開始します:
```
$ npm init
```
タイトルとバージョンフィールドに記入してください（残りのフィールドはデフォルト値のままにします）。

次のコマンドを使用してJava経由でNode.js用のAspose.Slidesをインストールします:
```
$ npm install aspose.slides.via.java
```

インストール中に問題が発生した場合は、この[記事](/nodejs-java/troubleshooting-installation/)を参照してください。

## **ZIPアーカイブからのインストール**

ZIPアーカイブからJava経由でNode.js用のAspose.Slidesをインストールして使用するには、次の手順に従ってください。

### **Windows**

1. JDK8をインストールし、`JAVA_HOME`環境変数を設定します。
1. Node.jsをインストールし（https://nodejs.org/en/download/）、node.exeを`PATH`に追加します。
1. node-gypをインストールします。
1. Windows Build Toolsをインストールします。
1. [`java`](https://www.npmjs.com/package/java)ブリッジをインストールし、管理者としてコマンドプロンプトで次のコマンドを実行します:
```
$ mkdir aspose.slides.nodejs

$ cd aspose.slides.nodejs

$ npm install -g node-gyp

$ npm install --global --production windows-build-tools

$ npm install java
```
6. [Java経由でNode.js用のAspose.Slidesをダウンロード](https://releases.aspose.com/slides/nodejs-java/)し、`aspose.slides.nodejs/node_modules/aspose.slides.via.java`に抽出します。
7. 次のサンプルコードを使用して`aspose.slides.nodejs`フォルダに`hello.js`という名前のファイルを作成します:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("スライドタイトル見出し");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("完了");
```

8. コマンドプロンプトで`node hello.js`を実行して実行します。

### **Linux**

1. Node.jsをインストールします（https://nodejs.org/en/download/）。
1. Linux用のJDK8をインストールし、`JAVA_HOME`環境変数を設定します。
1. python 2.xをインストールします。
1. [`java`](https://www.npmjs.com/package/java)ブリッジをインストールします。ターミナルで次のコマンドを実行できます:
```
$ mkdir aspose.slides.nodejs

$ cd aspose.slides.nodejs

$ npm install java
```
5. [Java経由でNode.js用のAspose.Slidesをダウンロード](https://releases.aspose.com/slides/nodejs-java/)し、`aspose.slides.nodejs/node_modules/aspose.slides.via.java`に抽出します。
6. 次のサンプルコードを使用して`aspose.slides.nodejs`フォルダに`hello.js`という名前のテストファイルを作成します:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("スライドタイトル見出し");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("完了");
```
7. コマンドプロンプトで`node hello.js`を実行して実行します。

### **Mac**

1. Node.jsをインストールします（https://nodejs.org/en/download/）。
1. Mac用のJDK8をインストールし、`JAVA_HOME`環境変数を設定します。
1. `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist`のJVMCapabilitiesセクションをルート特権で変更します。`jdk1.8.x_xxx.jdk`はjdkのバージョンによって異なります。以下のように設定します:
```xml
<key>JavaVM</key>
    <dict>
        <key>JVMCapabilities</key>
        <array>
                <string>JNI</string>
                <string>BundledApp</string>
                <string>CommandLine</string>
        </array>
```
4. python 2.xをインストールします（インストールされていない場合）。
5. Xcodeコマンドラインツールをインストールします。
6. [`java`](https://www.npmjs.com/package/java)ブリッジをインストールします。ターミナルで次のコマンドを実行できます:
```
$ mkdir aspose.slides.nodejs
 
$ cd aspose.slides.nodejs
 
$ npm install java
```
7. Java経由でNode.js用のAspose.Slidesをダウンロードし、`aspose.slides.nodejs/node_modules/aspose.slides.via.java`に抽出します。
8. 次のサンプルコードを使用して`aspose.slides.nodejs`フォルダに`hello.js`という名前のテストファイルを作成します:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("スライドタイトル見出し");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("完了");
```
9. コマンドプロンプトで`node hello.js`を実行して実行します。


{{% alert color="primary" %}}

インストール中にコンパイルエラーが発生した場合は、以下の[記事](https://docs.aspose.com/slides/nodejs-java/troubleshooting-installation/)を参照してください。

{{% /alert %}}