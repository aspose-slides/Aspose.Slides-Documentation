---
title: PowerPointをXPSに変換
type: docs
weight: 70
url: /php-java/convert-powerpoint-to-xps/
keywords: "PPT, PPTX to XPS"
description: "PowerPoint PPT(X)をXPSに変換"
---

## **XPSについて**
Microsoftは[XPS](https://docs.fileformat.com/page-description-language/xps/)を[PDF](https://docs.fileformat.com/pdf/)の代替として開発しました。これは、PDFに非常に似たファイルを出力することにより、コンテンツを印刷できるようにします。XPS形式はXMLに基づいています。XPSファイルのレイアウトや構造は、すべてのオペレーティングシステムやプリンターで同じままです。

## Microsoft XPS形式を使用するタイミング

{{% alert color="primary" %}} 

Aspose.SlidesがPPTまたはPPTXプレゼンテーションをXPS形式に変換する方法を確認するには、[この無料のオンラインコンバーターアプリ](https://products.aspose.app/slides/conversion)をチェックしてください。

{{% /alert %}} 

ストレージコストを削減したい場合は、Microsoft PowerPointプレゼンテーションをXPS形式に変換できます。これにより、ドキュメントの保存、共有、印刷が容易になります。

Microsoftは、Windows（Windows 10でも）でXPSの強力なサポートを引き続き実装しているため、この形式でファイルを保存することを検討したいかもしれません。Windows 8.1、Windows 8、Windows 7、Windows Vistaを使用している場合、特定の操作においてXPSが最善の選択肢になるかもしれません。

- **Windows 8**はXPSファイルにOXPS（Open XPS）形式を使用します。OXPSは、元のXPS形式の標準化されたバージョンです。Windows 8はPDFファイルよりもXPSファイルのサポートが優れています。
  - **XPS:** 内蔵のXPSビューワ/リーダーおよびXPSへの印刷機能が利用可能です。
  - **PDF**: PDFリーダーは利用できますが、PDFへの印刷機能はありません。

- **Windows 7およびWindows Vista**は元のXPS形式を使用しています。これらのオペレーティングシステムもPDFよりもXPSファイルをよりよくサポートしています。
  - **XPS**: 内蔵のXPSビューワおよびXPSへの印刷機能が利用可能です。
  - **PDF**: PDFリーダーはありません。PDFへの印刷機能はありません。

|<p>**入力PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**出力XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoftは最終的にWindows 10のPDFへの印刷機能を通じてPDFでの印刷操作をサポートしました。それ以前は、ユーザーはXPS形式を介してドキュメントを印刷することが期待されていました。

## Aspose.Slidesを使用したXPS変換

[**Aspose.Slides**](https://products.aspose.com/slides/php-java/) for Javaでは、[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスが公開する[**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)メソッドを使用して、プレゼンテーション全体をXPSドキュメントに変換できます。

プレゼンテーションをXPSに変換する際は、次の設定のいずれかを使用してプレゼンテーションを保存する必要があります。

- デフォルト設定（[**XPSOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions)なし）
- カスタム設定（[**XPSOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions)あり）

### **デフォルト設定を使用したプレゼンテーションのXPSへの変換**

このサンプルコードは、標準設定を使用してプレゼンテーションをXPSドキュメントに変換する方法を示しています：

```php
  # プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
  $pres = new Presentation("Convert_XPS.pptx");
  try {
    # プレゼンテーションをXPSドキュメントに保存
    $pres->save("XPS_Output_Without_XPSOption.xps", SaveFormat::Xps);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **カスタム設定を使用したプレゼンテーションのXPSへの変換**
このサンプルコードは、カスタム設定を使用してプレゼンテーションをXPSドキュメントに変換する方法を示しています：

```php
  # プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
  $pres = new Presentation("Convert_XPS_Options.pptx");
  try {
    # TiffOptionsクラスをインスタンス化
    $options = new XpsOptions();
    # メタファイルをPNGとして保存
    $options->setSaveMetafilesAsPng(true);
    # プレゼンテーションをXPSドキュメントに保存
    $pres->save("XPS_Output_With_Options.xps", SaveFormat::Xps, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```