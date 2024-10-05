---
title: Linuxにおけるフォントに関する一般的な例外とエラー
type: docs
weight: 200
url: /java/technical-articles/common-errors-involving-fonts
keywords: "フォント例外, フォントエラー, Linux, Java, Aspose.Slides for Java"
description: "Linux上のフォントに関する例外とエラー"
---

## **Linuxでコードを実行した際にテキストや画像（emfまたはwmf）が欠落する**

この問題は、以下のケースで制限があるシステムで発生します：

1. インストールされているフォントがない、またはJavaプロセスのフォルダにアクセスできない場合
2. TEMPディレクトリにアクセスできない場合。

### 解決策

TEMPディレクトリとフォントフォルダへのアクセスが許可されていることを確認してください。

{{% alert color="warning" %}}

場合によっては、環境やセキュリティポリシーによる制限のためにフォルダへのアクセスを許可できないことがあります。以下の回避策を試してください：

{{% /alert %}}

**回避策**

[FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader)を使用して、必要なフォントをインストールせずに読み込みます：

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

TEMPディレクトリにアクセスできない場合は、以下のコードを使用して別のディレクトリをJavaのTEMPとして指定します：
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

この例外は、以下の条件で発生します：

1) Javaプロセスがフォントフォルダにアクセスできない
2) フォントがインストールされていない。

### 解決策

1. Javaプロセスのフォントフォルダへのアクセスが許可されていることを確認してください。

2. フォントをいくつかインストールするか、[FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader)を使用してください。

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

   * [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader)を使用する場合： 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **例外: NoClassDefFoundError: クラス com.aspose.slides.internal.ey.this を初期化できませんでした**

この例外は、フォントコンフィグとフォントが不足しているLinuxシステムで発生します。

### 解決策：

フォントコンフィグをインストールしてください：

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

さらに、一部のopen-jdkバージョン（例えば、**alpine JDK**）も**インストールされたフォントが必要**です。

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

## **例外: UnsatisfiedLinkError: libfreetype.so.6: 共有ライブラリファイルを開けません: そのようなファイルやディレクトリはありません**

この例外は、libfreetypeライブラリが不足しているLinuxシステムで発生します。

### 解決策：

libfreetypeとフォントコンフィグをインストールしてください：

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

フォントをインストールするか、FontsLoaderを使用するのを忘れないでください。

{{% /alert %}}  