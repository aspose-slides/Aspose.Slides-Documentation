---
title: Linuxにおけるフォントに関する一般的な例外とエラー
type: docs
weight: 200
url: /php-java/technical-articles/common-errors-involving-fonts
keywords: "フォント例外, フォントエラー, Linux, Java, Aspose.Slides for PHP via Java"
description: "Linuxにおけるフォントの例外とエラー"
---

## **Linuxでコードを実行した際のテキストまたは画像（emfまたはwmf）が欠落している問題**

この問題は、以下のケースに制限があるシステムで発生します：

1. フォントがインストールされていない場合、またはJavaプロセスのフォントフォルダーにアクセスできない場合
2. TEMPディレクトリにアクセスできない場合。

### 解決策

TEMPディレクトリおよびフォントフォルダーへのアクセスが許可されていることを確認してください。 

{{% alert color="warning" %}}

場合によっては、環境やセキュリティポリシーによってフォルダーへのアクセスを許可できないことがあります。これらの代替手段を試してみてください： 

{{% /alert %}}

**代替策**

[FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader)を使用して、必要なフォントをインストールせずにロードします：

```php

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```php

```

TEMPディレクトリにアクセスできない場合は、次のコードを使用してJavaのTEMPとして別のディレクトリを指定します：
```php

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
    # ....

} finally {
    System.setProperty("java.io.tmpdir", oldValue);
}
```php

```

## **例外: InvalidOperationException: システムにインストールされているフォントが見つかりません**

この例外は次のときに発生します

1) Javaプロセスがフォントフォルダーにアクセスできない場合
2) フォントがインストールされていない場合。

### 解決策

1. Javaプロセスのフォントフォルダーへのアクセスが許可されていることを確認してください。

2. フォントをいくつかインストールするか、[FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader)を使用します。

3. フォントをインストールします。

   * Ubuntu: 

```php

     ```
     sudo apt-get update
     sudo apt-get install -y fonts-dejavu-core
     fc-cache -fv
```php

     ```

   * CentOS: 

```php

     ```
     sudo yum makecache
     sudo yum -y install dejavu-sans-fonts
     fc-cache -fv
```php

     ```

   * [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader)を使用する場合：

```php

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
```php

     ```

## **例外: NoClassDefFoundError: クラスcom.aspose.slides.internal.ey.thisを初期化できませんでした**

この例外はフォントコンフィグとフォントが不足しているLinuxシステムで発生します。

### 解決策：

fontconfigをインストールします：

* Ubuntu:

```php

  ```
  sudo apt-get update
  sudo apt-get -y install fontconfig
```php

  ```

* CentOS:

```php

  ```
  sudo yum makecache
  sudo yum -y install fontconfig
```php

  ```

また、一部のopen-jdkバージョン（例えば、**alpine JDK**）は、**インストールされたフォント**が必要です。

* Ubuntu:

```php

  ```
  sudo apt-get install -y fonts-dejavu-core
  fc-cache -fv
```php

  ```

* CentOS:

```php

  ```
  sudo yum -y install dejavu-sans-fonts
  fc-cache -fv
```php

  ```

## **例外: UnsatisfiedLinkError: libfreetype.so.6: 共有オブジェクトファイルを開けません: そのようなファイルやディレクトリはありません**

この例外はlibfreetypeライブラリが不足しているLinuxシステムで発生します。

### 解決策：

libfreetypeおよびfontconfigをインストールします：

* Ubuntu: 

```php

  ```
  sudo apt-get update
  sudo apt-get install libfreetype6
  sudo apt-get -y install fontconfig
```php

  ```

* CentOS: 

```php

  ```
  sudo yum makecache
  sudo yum install libfreetype6
  sudo yum -y install fontconfig
```php

  ```

{{% alert title="ヒント" color="primary" %}} 

フォントをインストールするか、FontsLoaderを使用するのを忘れないでください。

{{% /alert %}}  