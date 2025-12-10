---
title: Linuxでのフォントに関する一般的な例外とエラー
type: docs
weight: 200
url: /ja/java/technical-articles/common-errors-involving-fonts
keywords: "フォント例外, フォントエラー, Linux, Java, Aspose.Slides for Java"
description: "Linux上のフォント例外とエラー"
---

## **Linux上でコードが実行されたときのテキストまたは画像（EMFまたはWMF）の欠落**

この問題は、次のような制限があるシステムで発生します。

1. フォントがインストールされていない場合、またはJavaプロセスのフォントフォルダーにアクセスできない場合
2. TEMPディレクトリにアクセスできない場合。

### **Solution**

TEMPディレクトリとフォントフォルダーへのアクセスが許可されていることを確認してください。 

{{% alert color="warning" %}}
環境やセキュリティポリシーによってフォルダーへのアクセスを許可できない場合があります。以下の回避策を試してください:
{{% /alert %}}

**Workaround**

インストールせずに必要なフォントをロードするには、[FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader)を使用します:
```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```


TEMPディレクトリにアクセスできない場合は、JavaのTEMPとして別のディレクトリを指定するためにこのコードを使用してください:
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
    // 省略

} finally {
    System.setProperty("java.io.tmpdir", oldValue);
}
```


## **Exception: InvalidOperationException: Cannot Find Any Fonts Installed on the System**

この例外は以下の場合に発生します

1) Javaプロセスがフォントフォルダーにアクセスできない  
2) フォントがインストールされていない。

### **Solution**

1. Javaプロセスのフォントフォルダーへのアクセスが許可されていることを確認してください。

2. フォントをいくつかインストールするか、[FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader)を使用してください。

3. フォントをインストールしてください。

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


   * [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader) を使用する場合: 
     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```


## **Exception: NoClassDefFoundError: Could Not Initialize Class com.aspose.slides.internal.ey.this**

フォント構成(fontconfig)とフォントがないLinuxシステムでこの例外が発生します。 

### **Solution**

fontconfig をインストールしてください:

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


また、一部の OpenJDK バージョン（例: **alpine JDK**）でも **インストールされたフォントが必要** です。

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


## **Exception: UnsatisfiedLinkError: libfreetype.so.6: Cannot Open Shared Object File: No Such File or Directory**

libfreetype ライブラリがない Linux システムでこの例外が発生します。 

### **Solution**

libfreetype と fontconfig をインストールしてください:

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
フォントをインストールするか、FontsLoader を使用することを忘れないでください。
{{% /alert %}}