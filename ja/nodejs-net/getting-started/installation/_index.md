---
title: インストール
type: docs
weight: 70
url: /nodejs-net/installation/
keySlides: "Aspose.Slidesをダウンロード, Aspose.Slidesをインストール, Aspose.Slidesのインストール, Windows, macOS, Linux, Javascript, Node.js"
description: "Windows、Linux、macOSで.NET経由でNode.js用のAspose.Slidesをインストール"
---

.NET経由のNode.js用Aspose.Slidesはプラットフォームに依存しないAPIであり、`Node.js`と`edge-js`ブリッジがインストールされている任意のプラットフォーム（Windows、Linux、MacOS）で使用できます。

## **NPMからインストール**

次のコマンドを通じて、NPMから.NET経由のNode.js用Aspose.Slidesを簡単にインストールできます：
```
$ npm install aspose.slides.via.net
```
インストールプロセス中に問題が発生した場合は、https://www.npmjs.com/package/edge-jsを参照してください。

## **ZIPアーカイブからインストール**

ZIPアーカイブから.NET経由のNode.js用Aspose.Slidesをインストールして使用するには、次の手順に従ってください：

### **Windows**

1. .NET6以上をインストールします。
1. Node.jsをインストールします（https://nodejs.org/en/download/）し、node.exeを`PATH`に追加します。
1. edge-jsをインストールします。
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install -g edge-js
```
6. [.NET経由のNode.js用Aspose.Slidesをダウンロード](https://releases.aspose.com/slides/nodejs-net/)し、`aspose.slides.nodejs/node_modules/aspose.slides.via.net`に解凍します。
7. `aspose.slides.nodejs.net`フォルダー内に、次のサンプルコードを使用して`hello.js`という名前のファイルを作成します：

```javascript
// PowerPointファイル操作のためにAspose.Slidesモジュールをインポート
const asposeSlides = require('aspose.slides.via.net');

// asposeSlidesから必要なクラスを追加
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// 基本機能を示すために空のプレゼンテーションを作成して保存
function createEmptyPresentation() {
	
    // 新しい空のプレゼンテーションを初期化
    var emptyPresentation = new Presentation();
    
    // 空のプレゼンテーションをPPTX形式で保存
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // プレゼンテーションに関連するリソースを解放
    emptyPresentation.dispose();
}

createEmptyPresentation(); // 空のプレゼンテーションを作成するために関数を実行
```

8. コマンドプロンプトで`node hello.js`を実行して実行します。

### **Linux**

1. .NET6以上をインストールします。
1. Node.jsをインストールします（https://nodejs.org/en/download/）し、node.exeを`PATH`に追加します。
1. edge-jsをインストールします。
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install edge-js
```
5. [Java経由のNode.js用Aspose.Slidesをダウンロード](https://releases.aspose.com/slides/nodejs-net/)し、`aspose.slides.nodejs/node_modules/aspose.slides.via.net`に解凍します。
6. `aspose.slides.nodejs.net`フォルダー内に、このサンプルコードを使用して`hello.js`というテストファイルを作成します：

```javascript
// PowerPointファイル操作のためにAspose.Slidesモジュールをインポート
const asposeSlides = require('aspose.slides.via.net');

// asposeSlidesから必要なクラスを追加
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// 基本機能を示すために空のプレゼンテーションを作成して保存
function createEmptyPresentation() {
	
    // 新しい空のプレゼンテーションを初期化
    var emptyPresentation = new Presentation();
    
    // 空のプレゼンテーションをPPTX形式で保存
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // プレゼンテーションに関連するリソースを解放
    emptyPresentation.dispose();
}

createEmptyPresentation(); // 空のプレゼンテーションを作成するために関数を実行
```
7. コマンドプロンプトで`node hello.js`を実行して実行します。

### **Mac**

1. .NET6以上をインストールします。
1. Node.jsをインストールします（https://nodejs.org/en/download/）し、node.exeを`PATH`に追加します。
1. edge-jsをインストールします。

```
$ mkdir aspose.slides.nodejs.net
 
$ cd aspose.slides.nodejs.net
 
$ npm install edge-js
```

```javascript
// PowerPointファイル操作のためにAspose.Slidesモジュールをインポート
const asposeSlides = require('aspose.slides.via.net');

// asposeSlidesから必要なクラスを追加
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// 基本機能を示すために空のプレゼンテーションを作成して保存
function createEmptyPresentation() {
	
    // 新しい空のプレゼンテーションを初期化
    var emptyPresentation = new Presentation();
    
    // 空のプレゼンテーションをPPTX形式で保存
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // プレゼンテーションに関連するリソースを解放
    emptyPresentation.dispose();
}

createEmptyPresentation(); // 空のプレゼンテーションを作成するために関数を実行
```
9. コマンドプロンプトで`node hello.js`を実行して実行します。