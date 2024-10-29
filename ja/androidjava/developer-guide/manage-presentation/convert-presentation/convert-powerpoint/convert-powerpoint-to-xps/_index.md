---
title: PowerPointをXPSに変換
type: docs
weight: 70
url: /ja/androidjava/convert-powerpoint-to-xps/
keywords: "PPT, PPTX to XPS"
description: "JavaでPowerPoint PPT(X)をXPSに変換"
---

## **XPSについて**
マイクロソフトは[XPS](https://docs.fileformat.com/page-description-language/xps/)を[PDF](https://docs.fileformat.com/pdf/)の代替として開発しました。これにより、PDFに非常に似たファイルを出力することによってコンテンツを印刷できます。XPSフォーマットはXMLに基づいています。XPSファイルのレイアウトや構造は、すべてのオペレーティングシステムやプリンターで同じままです。

## Microsoft XPSフォーマットを使用するタイミング

{{% alert color="primary" %}} 

Aspose.SlidesがPPTまたはPPTXプレゼンテーションをXPSフォーマットに変換する方法を確認するには、[この無料オンラインコンバーターアプリ](https://products.aspose.app/slides/conversion)をチェックしてください。 

{{% /alert %}} 

ストレージコストを削減したい場合は、Microsoft PowerPointプレゼンテーションをXPSフォーマットに変換できます。これにより、ドキュメントを保存、共有、印刷するのが容易になります。

マイクロソフトはWindows（Windows 10でも）でXPSの強力なサポートを実装し続けているため、このフォーマットでファイルを保存することを検討するかもしれません。Windows 8.1、Windows 8、Windows 7、Windows Vistaを使用している場合、特定の操作においてXPSが最適なオプションとなるかもしれません。

- **Windows 8**はXPSファイルにOXPS（Open XPS）フォーマットを使用します。OXPSはオリジナルのXPSフォーマットの標準化されたバージョンです。Windows 8はXPSファイルに対してPDFファイルよりも優れたサポートを提供します。
  - **XPS:** ビルトインのXPSビューワー/リーダーとXPSへの印刷機能が利用可能。
  - **PDF**: PDFリーダーは利用可能ですが、PDFへの印刷機能はありません。

- **Windows 7とWindows Vista**はオリジナルのXPSフォーマットを使用します。これらのオペレーティングシステムもXPSファイルに対してPDFよりも優れたサポートを提供します。
  - **XPS**: ビルトインのXPSビューワーとXPSへの印刷機能が利用可能。
  - **PDF**: PDFリーダーはありません。PDFへの印刷機能もありません。

|<p>**入力PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**出力XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

マイクロソフトは最終的にWindows 10でのPrint to PDF機能を通じてPDFの印刷操作のサポートを実装しました。以前は、ユーザーはXPSフォーマットを通じてドキュメントを印刷することが期待されていました。

## Aspose.Slidesを使ったXPS変換

Java用の[**Aspose.Slides**](https://products.aspose.com/slides/androidjava/)では、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスによって公開されている[**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)メソッドを使用して、プレゼンテーション全体をXPS文書に変換できます。

プレゼンテーションをXPSに変換する際には、次のいずれかの設定を使用してプレゼンテーションを保存する必要があります：

- デフォルト設定（[**XPSOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xpsoptions)なし）
- カスタム設定（[**XPSOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xpsoptions)あり）

### **デフォルト設定を使用したプレゼンテーションのXPSへの変換**

このJavaのサンプルコードは、標準設定を使用してプレゼンテーションをXPSドキュメントに変換する方法を示しています：

```java
// プレゼンテーションファイルを表すプレゼンテーションオブジェクトをインスタンス化します
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // プレゼンテーションをXPS文書に保存する
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **カスタム設定を使用したプレゼンテーションのXPSへの変換**

このサンプルコードは、Javaでカスタム設定を使用してプレゼンテーションをXPSドキュメントに変換する方法を示しています：

```java
// プレゼンテーションファイルを表すプレゼンテーションオブジェクトをインスタンス化します
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // TiffOptionsクラスをインスタンス化します
    XpsOptions options = new XpsOptions();

    // メタファイルをPNGとして保存します
    options.setSaveMetafilesAsPng(true);

    // プレゼンテーションをXPS文書に保存する
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```