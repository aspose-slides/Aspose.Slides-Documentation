---
title: インストール
type: docs
weight: 70
url: /ja/nodejs-java/installation/
keywords:
- Aspose.Slides をインストール
- Aspose.Slides をダウンロード
- Aspose.Slides を使用
- Aspose.Slides のインストール
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides をすばやくインストールする方法を学びます。ステップバイステップのガイド、システム要件、コードサンプル — 今日から PowerPoint プレゼンテーションの作成を始めましょう！"
---

Aspose.Slides for Node.js via Java はプラットフォームに依存しない API であり、`Node.js` と [`java`](https://www.npmjs.com/package/java) ブリッジがインストールされている任意のプラットフォーム（Windows、Linux、MacOS）で使用できます。

## **NPM からインストール**

Aspose.Slides for Node.js via Java は [NPM](https://www.npmjs.com/) から簡単にインストールできます。

1. 新しいフォルダーを作成し、以下のコマンドで新しいプロジェクトを開始します：
	```
	$ npm init
	```

	
2. タイトルとバージョンのフィールドに入力します（残りのフィールドはデフォルト値のままにします）。

3. 以下のコマンドで Aspose.Slides for Node.js via Java をインストールします：
```
$ npm install aspose.slides.via.java
```


インストール中に問題が発生した場合は、この[記事](/slides/ja/nodejs-java/troubleshooting-installation/)を参照してください。

**使用例**：

プロジェクト フォルダーに `hello.js` という名前のファイルを作成し、以下のサンプルコードを追加します：
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

ZIP アーカイブから Aspose.Slides for Node.js via Java をインストールして使用するには、代わりに以下の手順に従ってください：

### **Windows**

1. JDK8 をインストールし、`JAVA_HOME` 環境変数を設定します。
1. Node.js (https://nodejs.org/en/download/) をインストールし、node.exe を `PATH` に追加します。
1. node-gyp をインストールします。
1. Windows Build Tools をインストールします。
1. [`java`](https://www.npmjs.com/package/java) ブリッジをインストールし、管理者としてコマンド プロンプトで以下のコマンドを実行します：
```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install -g node-gyp

	$ npm install --global --production windows-build-tools

	$ npm install java
```

6. [Aspose.Slides for Node.js via Java をダウンロード](https://releases.aspose.com/slides/nodejs-java/)し、`aspose.slides.nodejs/node_modules/aspose.slides.via.java` に展開します。
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


8. 次にコマンド プロンプトで `node hello.js` を実行して実行します。

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

5. [Aspose.Slides for Node.js via Java をダウンロード](https://releases.aspose.com/slides/nodejs-java/)し、`aspose.slides.nodejs/node_modules/aspose.slides.via.java` に展開します。
6. `aspose.slides.nodejs` フォルダーにこのサンプルコードを使用して `hello.js` というテストファイルを作成します：
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```

7. 次にコマンド プロンプトで `node hello.js` を実行して実行します。

### **Mac**

1. Node.js (https://nodejs.org/en/download/) をインストールします。
1. Mac 用 JDK8 をインストールし、`JAVA_HOME` 環境変数を設定します。
1. root 権限で `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` の JVMCapabilities セクションを修正します。`jdk1.8.x_xxx.jdk` は使用している JDK バージョンに依存します。以下のようにします：
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

4. python 2.x をインストールします（未インストールの場合）。
5. Xcode Command Line Tools をインストールします。
6. [`java`](https://www.npmjs.com/package/java) ブリッジをインストールします。端末で以下のコマンドを実行できます：
	```bash
	$ mkdir aspose.slides.nodejs
	 
	$ cd aspose.slides.nodejs
	 
	$ npm install java
	```

7. Aspose.Slides for Node.js via Java をダウンロードし、`aspose.slides.nodejs/node_modules/aspose.slides.via.java` に展開します。
8. `aspose.slides.nodejs` フォルダーにこのサンプルコードを使用して `hello.js` というテストファイルを作成します：
```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Done");
```

9. 次にコマンド プロンプトで `node hello.js` を実行して実行します。

{{% alert color="primary" %}}
インストール中にコンパイル エラーが発生した場合は、以下の[記事](https://docs.aspose.com/slides/nodejs-java/troubleshooting-installation/)をご利用ください。
{{% /alert %}}

## **FAQ**

**無料版または試用版の制限はありますか？**

はい、デフォルトでは Aspose.Slides は評価モードで実行され、透かしが入る他、いくつかの制限があります。制限を解除するには、有効な[ライセンス](/slides/ja/nodejs-java/licensing/)を適用する必要があります。