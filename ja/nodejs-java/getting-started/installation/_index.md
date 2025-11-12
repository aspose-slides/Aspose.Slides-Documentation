---
title: インストール
type: docs
weight: 70
url: /ja/nodejs-java/installation/
keywords:
- Aspose.Slides をダウンロード
- Aspose.Slides をインストール
- Aspose.Slides のインストール
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Windows、Linux、macOS で Java 経由の Node.js 用 Aspose.Slides をインストールする"
---

Java 経由の Node.js 用 Aspose.Slides はプラットフォームに依存しない API であり、`Node.js` と [`java`](https://www.npmjs.com/package/java) ブリッジがインストールされている任意のプラットフォーム（Windows、Linux、macOS）で使用できます。

## **NPM からインストール**

[NPM](https://www.npmjs.com/) から簡単に Java 経由の Node.js 用 Aspose.Slides をインストールできます。

1. 新しいフォルダーを作成し、次のコマンドで新しいプロジェクトを開始します：
	```
	$ npm init
	```
	
2. タイトルとバージョンのフィールドに入力します（残りのフィールドはデフォルト値のままにしてください）。

3. 次のコマンドで Java 経由の Node.js 用 Aspose.Slides をインストールします：
	```
	$ npm install aspose.slides.via.java
	```

インストール中に問題が発生した場合は、こちらの[記事](/nodejs-java/troubleshooting-installation/)をご参照ください。

**使用例**：

プロジェクトフォルダーに `hello.js` という名前のファイルを作成し、以下のサンプルコードを追加します：

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Done");
```

## **ZIP アーカイブからインストール**

ZIP アーカイブから Java 経由の Node.js 用 Aspose.Slides をインストールして使用するには、代わりに以下の手順に従ってください：

### **Windows**

1. JDK8 をインストールし、`JAVA_HOME` 環境変数を設定します。
1. Node.js (https://nodejs.org/en/download/) をインストールし、node.exe を `PATH` に追加します。
1. node-gyp をインストールします。
1. Windows Build Tools をインストールします。
1. [`java`](https://www.npmjs.com/package/java) ブリッジをインストールし、管理者としてコマンドプロンプトで以下のコマンドを実行します：
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install -g node-gyp

	$ npm install --global --production windows-build-tools

	$ npm install java
	```
6. [Java 経由の Node.js 用 Aspose.Slides をダウンロード](https://releases.aspose.com/slides/nodejs-java/)し、`aspose.slides.nodejs/node_modules/aspose.slides.via.java` に展開します。
7. `aspose.slides.nodejs` フォルダーに `hello.js` という名前のファイルを作成し、以下のサンプルコードを使用します：

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```

8. コマンドプロンプトで `node hello.js` を実行します。

### **Linux**

1. Node.js (https://nodejs.org/en/download/) をインストールします。
1. Linux 用 JDK8 をインストールし、`JAVA_HOME` 環境変数を設定します。
1. python 2.x をインストールします。
1. [`java`](https://www.npmjs.com/package/java) ブリッジをインストールします。端末で以下のコマンドを実行できます：
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install java
	```
5. [Java 経由の Node.js 用 Aspose.Slides をダウンロード](https://releases.aspose.com/slides/nodejs-java/)し、`aspose.slides.nodejs/node_modules/aspose.slides.via.java` に展開します。
6. `aspose.slides.nodejs` フォルダーに `hello.js` という名前のテストファイルを作成し、以下のサンプルコードを使用します：

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
7. コマンドプロンプトで `node hello.js` を実行します。

### **Mac**

1. Node.js (https://nodejs.org/en/download/) をインストールします。
1. Mac 用 JDK8 をインストールし、`JAVA_HOME` 環境変数を設定します。
1. `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` の JVMCapabilities セクションを管理者権限で修正します。`jdk1.8.x_xxx.jdk` はご使用の JDK バージョンに合わせてください。以下のようにします：
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
4. python 2.x がインストールされていない場合はインストールします。
5. Xcode Command Line Tools をインストールします。
6. [`java`](https://www.npmjs.com/package/java) ブリッジをインストールします。端末で以下のコマンドを実行できます：
	```bash
	$ mkdir aspose.slides.nodejs
	 
	$ cd aspose.slides.nodejs
	 
	$ npm install java
	```
7. Java 経由の Node.js 用 Aspose.Slides をダウンロードし、`aspose.slides.nodejs/node_modules/aspose.slides.via.java` に展開します。
8. `aspose.slides.nodejs` フォルダーに `hello.js` という名前のテストファイルを作成し、以下のサンプルコードを使用します：

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
9. コマンドプロンプトで `node hello.js` を実行します。

{{% alert color="primary" %}}
Java 経由の Node.js 用 Aspose.Slides のインストール中にコンパイル エラーが発生した場合は、次の[記事]を使用してください。
{{% /alert %}}

## **FAQ**

**無料版や試用期間の制限はありますか？**

はい、デフォルトでは Aspose.Slides は評価モードで実行され、透かしが付加され、他の制限がある場合があります。制限を解除するには、有効な[ライセンス](/slides/ja/nodejs-java/licensing/)を適用する必要があります。