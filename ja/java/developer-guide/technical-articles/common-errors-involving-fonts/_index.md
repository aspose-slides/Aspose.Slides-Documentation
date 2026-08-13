---
title: Linux でのフォントに関する一般的な例外とエラー
type: docs
weight: 200
url: /ja/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "フォント例外, フォントエラー, Linux, Java, Aspose.Slides for Java"
description: "Linux 上のフォント例外とエラー"
---
## **概要**

Aspose.Slides を Linux で使用する場合、Java プロセスが必要なフォント フォルダーや一時ディレクトリへアクセスできない、システムにフォントがインストールされていない、または fontconfig や libfreetype といった必須システム ライブラリが欠如していると、フォントに関する問題が発生する可能性があります。

本記事では、Linux 上でのフォントに関する一般的なエラーと例外を紹介し、解決策を提示します。フォントおよび TEMP ディレクトリへのアクセス確認方法、必要なフォントとライブラリのインストール方法、`FontsLoader` を使用してシステム全体にインストールせずにフォントをロードする手順を解説します。

## **Linux でコードを実行した際のテキストまたは画像（EMF または WMF）の欠落**

この問題は、次のような制限がある環境で発生します。

1. フォントがインストールされていない、または Java プロセスがフォント フォルダーにアクセスできない場合
2. TEMP ディレクトリにアクセスできない場合

### **解決策**

TEMP ディレクトリとフォント フォルダーへのアクセスが許可されていることを確認してください。

{{% alert color="warning" %}}
環境やセキュリティ ポリシーの制限によりフォルダーへのアクセス権を付与できないことがあります。その場合は以下の回避策を試してください。
{{% /alert %}}

**回避策**

[FontsLoader](https://reference.aspose.com/slides/ja/java/com.aspose.slides/FontsLoader) を使用して、システムにインストールせずに必要なフォントをロードします。

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

TEMP ディレクトリにアクセスできない場合は、以下のコードで Java の TEMP を別ディレクトリに設定してください。
```
String newTempFolder = "pathToTmpFolder";
String oldValue = System.getProperty("java.io.tmpdir");
java.io.File file = new java.io.File(newTempFolder);
if (!file.exists())
    file.mkdir();
System.setProperty("java.io.tmpdir", newTempFolder);
try {

    FontsLoader.loadExternalFonts(pathToFontsFolders);

    Presentation pres = ...
    // ....

} finally {
    System.setProperty("java.io.tmpdir", oldValue);
}
```

## **例外: InvalidOperationException: システムにインストールされているフォントが見つかりません**

この例外は次の場合に発生します。

1. Java プロセスがフォント フォルダーにアクセスできない
2. フォントがインストールされていない

### **解決策**

1. Java プロセスがフォント フォルダーにアクセスできることを確認してください。

2. フォントをいくつかインストールするか、[FontsLoader](https://reference.aspose.com/slides/ja/java/com.aspose.slides/FontsLoader) を使用してください。

3. フォントをインストールします。

   * Ubuntu:

     ```
     sudo apt-get update
     sudo apt-get install -y fonts-dejavu-core
     fc-cache -fv
```

   * CentOS:

     ```
     sudo yum makecache
     sudo yum -y install dejavu-sans-fonts
     fc-cache -fv
     ```

   * [FontsLoader](https://reference.aspose.com/slides/ja/java/com.aspose.slides/FontsLoader) を使用する場合:

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **例外: NoClassDefFoundError: クラス com.aspose.slides.internal.ey.this の初期化に失敗しました**

この例外は、fontconfig とフォントが欠如している Linux システムで発生します。

### **解決策**

fontconfig をインストールしてください。

* Ubuntu:

  ```
  sudo apt-get update
  sudo apt-get -y install fontconfig
  ```

* CentOS:

  ```
  sudo yum makecache
  sudo yum -y install fontconfig
  ```

また、一部の open‑jdk バージョン（例: **alpine JDK**）でも **フォントのインストールが必要**です。

* Ubuntu:

  ```
  sudo apt-get install -y fonts-dejavu-core
  fc-cache -fv
```

* CentOS:

  ```
  sudo yum -y install dejavu-sans-fonts
  fc-cache -fv
  ```

## **例外: UnsatisfiedLinkError: libfreetype.so.6: 共有オブジェクト ファイルを開けません: そのようなファイルやディレクトリはありません**

この例外は、libfreetype ライブラリが欠如している Linux システムで発生します。

### **解決策**

libfreetype と fontconfig をインストールしてください。

* Ubuntu:

  ```
  sudo apt-get update
  sudo apt-get install libfreetype6
  sudo apt-get -y install fontconfig
  ```

* CentOS:

  ```
  sudo yum makecache
  sudo yum install libfreetype6
  sudo yum -y install fontconfig
  ```

{{% alert title="ヒント" color="info" %}}
フォントをインストールするか、FontsLoader を使用することを忘れないでください。
{{% /alert %}}