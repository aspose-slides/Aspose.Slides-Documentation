---
title: PowerPointをXPSに変換
type: docs
weight: 70
url: /ja/java/convert-powerpoint-to-xps/
keywords: "PPT, PPTXをXPSに"
description: "JavaでPowerPoint PPT(X)をXPSに変換"
---

## **XPSについて**
マイクロソフトは[XPS](https://docs.fileformat.com/page-description-language/xps/)を[PDF](https://docs.fileformat.com/pdf/)の代替として開発しました。これは、PDFに非常に類似したファイルを出力することでコンテンツを印刷することを可能にします。XPSフォーマットはXMLに基づいています。XPSファイルのレイアウトや構造は、すべてのオペレーティングシステムやプリンターで同じになります。 

## Microsoft XPSフォーマットを使用するタイミング

{{% alert color="primary" %}} 

Aspose.SlidesがPPTまたはPPTXプレゼンテーションをXPSフォーマットに変換する方法を確認するには、[この無料のオンラインコンバーターアプリ](https://products.aspose.app/slides/conversion)をチェックできます。 

{{% /alert %}} 

ストレージコストを削減したい場合、Microsoft PowerPointプレゼンテーションをXPSフォーマットに変換できます。これにより、ドキュメントを保存、共有、印刷するのが簡単になります。 

マイクロソフトはWindows（特にWindows 10）でXPSの強力なサポートを実装し続けているため、このフォーマットにファイルを保存することを検討する価値があります。Windows 8.1、Windows 8、Windows 7、およびWindows Vistaを使用している場合、XPSは特定の操作において実際に最良の選択肢かもしれません。 

- **Windows 8**はXPSファイル用にOXPS（Open XPS）フォーマットを使用します。OXPSは元のXPSフォーマットの標準化バージョンです。Windows 8はPDFファイルよりもXPSファイルに対して優れたサポートを提供します。 
  - **XPS:** ビルトインのXPSビューア/リーダーとXPSへの印刷機能が利用可能。 
  - **PDF**: PDFリーダーは利用可能ですが、PDFへの印刷機能はありません。 

- **Windows 7およびWindows Vista**は元のXPSフォーマットを使用します。これらのオペレーティングシステムもPDFよりもXPSファイルに対して優れたサポートを提供します。 
  - **XPS**: ビルトインのXPSビューアとXPSへの印刷機能が利用可能。 
  - **PDF**: PDFリーダーはありません。PDFへの印刷機能もありません。 

|<p>**入力PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**出力XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



マイクロソフトは最終的にWindows 10のPDFへの印刷機能を通じてPDFの印刷操作をサポートしました。それ以前は、ユーザーはXPSフォーマットを通じてドキュメントを印刷することを期待されていました。 

## Aspose.SlidesによるXPS変換

Java用の[**Aspose.Slides**](https://products.aspose.com/slides/java/)では、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスが公開する[**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)メソッドを使用して、プレゼンテーション全体をXPSドキュメントに変換できます。 

プレゼンテーションをXPSに変換する際には、次のいずれかの設定を使用してプレゼンテーションを保存する必要があります。

- デフォルト設定（[**XPSOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/xpsoptions)なし）
- カスタム設定（[**XPSOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/xpsoptions)あり）

### **デフォルト設定を使用したプレゼンテーションのXPSへの変換**

以下のJavaサンプルコードは、標準設定を使用してプレゼンテーションをXPSドキュメントに変換する方法を示しています：

```java
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // プレゼンテーションをXPSドキュメントに保存
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```


### **カスタム設定を使用したプレゼンテーションのXPSへの変換**
以下のサンプルコードは、カスタム設定を使用してプレゼンテーションをXPSドキュメントに変換する方法を示しています：

```java
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // TiffOptionsクラスをインスタンス化
    XpsOptions options = new XpsOptions();

    // メタファイルをPNGとして保存
    options.setSaveMetafilesAsPng(true);

    // プレゼンテーションをXPSドキュメントに保存
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```