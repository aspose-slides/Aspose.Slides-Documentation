---
title: Linux におけるフォントに関する共通の例外とエラー
type: docs
weight: 200
url: /ja/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "フォント例外, フォントエラー, Linux, Java, Aspose.Slides for Java"
description: "Linux におけるフォント例外とエラー"
---
## **概要**

Linux で Aspose.Slides を使用する際、Java プロセスが必要なフォント フォルダーや一時ディレクトリにアクセスできない場合、システムにフォントがインストールされていない場合、または fontconfig や libfreetype などの必要なシステム ライブラリが欠如している場合に、フォント関連の問題が発生する可能性があります。

本記事では、Linux 上のフォントに関する一般的なエラーと例外を説明し、解決策を提供します。フォントおよび TEMP ディレクトリへのアクセス確認方法、必要なフォントやライブラリのインストール方法、そして `FontsLoader` を使用してシステム全体にインストールせずにフォントをロードする方法について解説します。

## **Linux でコードを実行した際のテキストまたは画像（EMF または WMF）の欠落**

この問題は、次のような制限があるシステムで発生します：

1. フォントがインストールされていない、または Java プロセス用のフォント フォルダーにアクセスできない場合
2. TEMP ディレクトリにアクセスできない場合。

### **解決策**

TEMP ディレクトリとフォント フォルダーへのアクセスが許可されていることを確認してください。

{{% alert color="warning" %}}
環境やセキュリティ ポリシーによる制限のため、フォルダーへのアクセス権を付与できない場合があります。以下の回避策をお試しください：
{{% /alert %}}

**Workaround**

必要なフォントをインストールせずにロードするには、[FontsLoader](https://reference.aspose.com/slides/ja/java/com.aspose.slides/FontsLoader) を使用します：

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

TEMP ディレクトリにアクセスできない場合は、以下のコードを使用して Java の TEMP として別のディレクトリを指定してください：
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

## **例外: InvalidOperationException: システムにインストールされたフォントが見つかりません**

この例外は次の場合に発生します：

1) Java プロセスがフォント フォルダーにアクセスできない場合  
2) フォントがインストールされていない場合。

### **解決策**

1. Java プロセス用のフォント フォルダーへのアクセスが許可されていることを確認してください。

2. フォントをインストールするか、[FontsLoader](https://reference.aspose.com/slides/ja/java/com.aspose.slides/FontsLoader) を使用してください。

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

   * [FontsLoader](https://reference.aspose.com/slides/ja/java/com.aspose.slides/FontsLoader) を使用する場合：  

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **例外: NoClassDefFoundError: クラス com.aspose.slides.internal.ey.this を初期化できませんでした**

この例外は、fontconfig とフォントが不足している Linux システムで発生します。

### **解決策**

fontconfig をインストールしてください：

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

さらに、いくつかの OpenJDK バージョン（例: **alpine JDK**）でも **インストール済みのフォントが必要**です。

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

## **例外: UnsatisfiedLinkError: libfreetype.so.6: 共有オブジェクト ファイルを開けません: ファイルが存在しません**

この例外は、libfreetype ライブラリが欠如している Linux システムで発生します。

### **解決策**

libfreetype と fontconfig をインストールしてください：

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

{{% alert title="TIP" color="primary" %}} 
フォントのインストールまたは FontsLoader の使用を忘れないでください。
{{% /alert %}}