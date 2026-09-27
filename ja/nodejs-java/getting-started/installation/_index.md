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
description: "Windows、Linux、macOS の npm から Java 経由で Aspose.Slides for Node.js をインストールする方法、必要な JDK、Python、C++ ビルドツール、npm コマンド、およびインストールを確認する最初のスクリプト。"
---
## **概要**

この記事では、Windows、Linux、macOS 上で Java 経由で Aspose.Slides for Node.js をインストールする方法と、インストールが正常に動作するか確認する方法について説明します。

Aspose.Slides for Node.js via Java は npm 上で `aspose.slides.via.java` パッケージとして配布されています。インストール時に npm がコンピューター上でコンパイルするネイティブ Node.js アドオンである [`java`](https://github.com/joeferner/node-java) パッケージを介して、Java 仮想マシン内で Aspose.Slides を実行します。そのため、インストールには Node.js に加えて以下が必要です：

- **JDK 8 以降の Java Development Kit (JDK)。** Java ランタイムだけでは不十分です。ビルドには JDK のヘッダーファイルが必要です。
- **Python 3**、ビルドツール [node-gyp](https://github.com/nodejs/node-gyp) が使用します。
- **OS 用の C++ ビルドツールチェーン**。

## **前提条件のインストール**

### **Windows**

1. [Node.js](https://nodejs.org/en/download) 20 以上をインストールします。
2. 例として [Eclipse Temurin](https://adoptium.net/) などの JDK をインストールし、`JAVA_HOME` 環境変数をそのインストールフォルダーに設定します。ビルドは `JAVA_HOME` が指す JDK を使用します。
3. [Python 3](https://www.python.org/downloads/) をインストールします。
4. **Desktop development with C++** ワークロードを含む [Build Tools for Visual Studio 2022](https://aka.ms/vs/17/release/vs_BuildTools.exe) をインストールします。ワークロードのデフォルトコンポーネント（**MSVC v143 - VS 2022 C++ x64/x86 build tools** と **Windows 11 SDK** を含む）をそのまま保持してください。Visual Studio 2026 は動作しません：`java` パッケージのコンパイルに使用される node-gyp のバージョンがそれを認識しないためです。

### **Linux**

Node.js 20 以上を [nodejs.org](https://nodejs.org/en/download) またはディストリビューションのパッケージソースからインストールします。その後、JDK、Python 3、C++ ビルドツールをインストールします。Debian および Ubuntu の場合：

```bash
sudo apt-get update
sudo apt-get install -y default-jdk python3 build-essential
```

Linux では、追加設定なしでビルドがインストール済みの JDK を検出します。複数の JDK がインストールされている場合は、使用したい JDK のディレクトリを `JAVA_HOME` に設定してください。

### **macOS**

Node.js 20 以上、JDK、そして Python 3 と C++ コンパイラを含む Xcode Command Line Tools をインストールします。macOS 固有の注意点については [Troubleshooting Installation](/slides/ja/nodejs-java/troubleshooting-installation/) を参照してください。

## **npm からのインストール**

プロジェクトフォルダーを作成し、パッケージをインストールします：

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

npm は Aspose.Slides をダウンロードし、`java` ブリッジをコンパイルします。これには数分かかることがあります。コンパイルに失敗した場合は、[Troubleshooting Installation](/slides/ja/nodejs-java/troubleshooting-installation/) を参照してください。

## **インストールの確認**

プロジェクトフォルダーに *hello.js* という名前のファイルを作成し、以下のコードを記述します。このコードはプレゼンテーションを作成し、最初のスライドにテキストボックスを追加し、結果を *hello.pptx* として保存します：

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides は Node.js の実行を保持する Java 仮想マシンで動作するため、プロセスを明示的に終了させます。
process.exit(0);
```

スクリプトを実行します：

```bash
node hello.js
```

*hello.pptx* がプロジェクトフォルダーに作成されていれば、インストールは成功です。Aspose.Slides を実行する Java 仮想マシンが Node.js の終了を妨げるため、スクリプトは `process.exit(0)` で終了します。[Create Presentations](/slides/ja/nodejs-java/create-presentation/) でコードの説明があります。

## **ZIP アーカイブからのインストール**

このパッケージは npm パッケージと同じ内容の ZIP アーカイブとしても提供されています。アーカイブからインストールする手順は次のとおりです：

1. 上記の通り、使用している OS の前提条件をインストールします。
2. [Aspose.Slides for Node.js via Java ダウンロードページ](https://releases.aspose.com/slides/ja/nodejs-java/) からアーカイブをダウンロードします。
3. プロジェクトフォルダーを作成します：

    ```bash
    mkdir hello-slides
    cd hello-slides
    npm init -y
    ```

4. アーカイブをプロジェクトフォルダー内の *aspose.slides.via.java* というサブフォルダーに展開し、アーカイブの *package.json* が *hello-slides/aspose.slides.via.java/package.json* に配置されるようにします。
5. そのフォルダーからパッケージをインストールします：

    ```bash
    npm install ./aspose.slides.via.java
    ```

    npm はパッケージが依存する `java` ブリッジをインストールし、npm パッケージと同様にコンパイルします。
6. [インストールの確認](#check-the-installation) に記載の手順でインストールを確認します。

## **FAQ**

**無料版や体験版の制限はありますか？**

はい。ライセンスがない場合、Aspose.Slides は評価モードで動作し、保存するすべてのスライドに評価用の透かしが追加され、プレゼンテーションから読み取ったテキストが切り詰められます。これらの制限を解除するには、有効な [license](/slides/ja/nodejs-java/licensing/) を適用してください。

**スクリプトが終了後に終了しないのはなぜですか？**

`java` パッケージは Node.js プロセス内に Java 仮想マシンを起動し、その仮想マシンがプロセスの実行を継続させます。スクリプトの作業が完了したら `process.exit` を呼び出してください。