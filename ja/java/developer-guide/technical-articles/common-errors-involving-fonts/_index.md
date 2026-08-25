---
title: Linux におけるフォントに関する一般的な例外とエラー
type: docs
weight: 200
url: /ja/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "フォント例外, フォントエラー, Linux, Java, Aspose.Slides for Java"
description: "Linux 上のフォント例外とエラー"
---
## **概要**

Aspose.Slides を Linux で使用する場合、Java プロセスが必要なフォント フォルダーや一時ディレクトリにアクセスできない、システムにフォントがインストールされていない、または fontconfig や libfreetype といった必須のシステム ライブラリが欠如していると、フォントに関する問題が発生する可能性があります。

本記事では、Linux 上のフォントに関連する一般的なエラーと例外を説明し、解決策を提示します。フォントおよび TEMP ディレクトリへのアクセス確認方法、必要なフォントとライブラリのインストール手順、そして `FontsLoader` を使用してシステム全体にインストールせずにフォントを読み込む方法を解説します。

## **Linux でコードを実行した際のテキストまたは画像 (EMF または WMF) の欠落**

この問題は、次のいずれかの制限があるシステムで発生します。

1. フォントがインストールされていない、または Java プロセス用のフォント フォルダーにアクセスできない場合  
2. TEMP ディレクトリにアクセスできない場合

### **解決策**

TEMP ディレクトリとフォント フォルダーへのアクセスが許可されていることを確認してください。

{{% alert color="warning" %}}
環境やセキュリティ ポリシーによってフォルダーへのアクセス権を付与できない場合があります。そのような場合は以下の回避策をお試しください。
{{% /alert %}}

**回避策**

[FontsLoader](https://reference.aspose.com/slides/ja/java/com.aspose.slides/FontsLoader) を使用して、フォントをシステム全体にインストールせずに必要なフォントを読み込みます。

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

TEMP ディレクトリにアクセスできない場合は、以下のコードで Java 用の別のディレクトリを TEMP として指定してください。
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

この例外は、次の場合に発生します。

1. Java プロセスがフォント フォルダーにアクセスできない  
2. フォントがインストールされていない

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

   * [FontsLoader](https://reference.aspose.com/slides/ja/java/com.aspose.slides/FontsLoader) を使用する場合:

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **例外: InternalError: InvocationTargetException**

Linux で PPTX ファイルを PDF に変換する際、`java.lang.InternalError: java.lang.reflect.InvocationTargetException` が発生して変換に失敗することがあります。根本的なエラーが `Cannot load from short array because "sun.awt.FontConfiguration.head" is null` と表示された場合、Linux のフォント設定が利用できないか、キャッシュが初期化されていません。

### **解決策**

fontconfig をインストールし、フォント キャッシュを再構築してください。

```bash
sudo yum install -y fontconfig
sudo fc-cache --force
```

## **例外: NoClassDefFoundError: Could Not Initialize Class com.aspose.slides.internal.ey.this**

この例外は、fontconfig およびフォントが不足している Linux システムで発生します。

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

さらに、一部の OpenJDK バージョン（例: **alpine JDK**）でも **フォントのインストールが必要** です。

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

## **例外: UnsatisfiedLinkError: libfreetype.so.6: Cannot Open Shared Object File: No Such File or Directory**

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

{{% alert title="TIP" color="info" %}} 
フォントのインストールまたは FontsLoader の使用を忘れないでください。
{{% /alert %}}