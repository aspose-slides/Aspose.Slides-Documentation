---
title: Java で PowerPoint プレゼンテーションを XPS に変換
linktitle: PowerPoint から XPS へ
type: docs
weight: 70
url: /ja/java/convert-powerpoint-to-xps/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を XPS に変換
- プレゼンテーションを XPS に変換
- スライドを XPS に変換
- PPT を XPS に変換
- PPTX を XPS に変換
- PPT を XPS として保存
- PPTX を XPS として保存
- PPT を XPS にエクスポート
- PPTX を XPS にエクスポート
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して、Java で PowerPoint の PPT/PPTX を高品質かつプラットフォームに依存しない XPS に変換します。ステップバイステップのガイドとサンプルコードをご覧ください。"
---
## **概要**

Aspose.Slides は、PPT または PPTX ファイルを XPS 形式で保存することで PowerPoint プレゼンテーションを XPS に変換できます。この記事では、XPS 形式が有用となるケースを説明し、Aspose.Slides を使用して既定の設定またはカスタム [XpsOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/xpsoptions/) 設定で変換を実行する方法を示します。

## **XPS について**

Microsoft は [XPS](https://docs.fileformat.com/page-description-language/xps/) を [PDF](https://docs.fileformat.com/pdf/) の代替として開発しました。PDF に非常に似たファイルを出力することでコンテンツを印刷できるようになります。XPS 形式は XML に基づいており、XPS ファイルのレイアウトや構造はすべての OS やプリンターで同一です。

## **Microsoft XPS 形式を使用すべき時**

{{% alert color="info" %}} 

Aspose.Slides が PPT または PPTX プレゼンテーションを XPS 形式に変換する様子は、[この無料オンラインコンバーター アプリ](https://products.aspose.app/slides/ja/conversion)で確認できます。

{{% /alert %}} 

ストレージコストを削減したい場合、Microsoft PowerPoint プレゼンテーションを XPS 形式に変換すると、保存、共有、印刷が容易になります。

Microsoft は Windows（Windows 10 でも）で XPS のサポートを強化し続けているため、この形式でファイルを保存することを検討するとよいでしょう。Windows 8.1、Windows 8、Windows 7、Windows Vista を使用している場合、特定の操作では XPS が最適な選択肢になることがあります。

- **Windows 8** は XPS ファイルに OXPS（Open XPS）形式を使用します。OXPS は元の XPS 形式の標準化版です。Windows 8 は PDF ファイルよりも XPS ファイルのサポートが優れています。 
  - **XPS:** 組み込み XPS ビューア/リーダーと XPS への印刷機能が利用可能。 
  - **PDF:** PDF リーダーは利用可能だが、PDF への印刷機能はなし。 

- **Windows 7 および Windows Vista** は元の XPS 形式を使用します。これらの OS も PDF より XPS ファイルのサポートが優れています。 
  - **XPS:** 組み込み XPS ビューアと XPS への印刷機能が利用可能。 
  - **PDF:** PDF リーダーなし。PDF への印刷機能なし。 

|<p>**入力 PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**出力 XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft は最終的に Windows 10 の「Print to PDF」機能で PDF への印刷をサポートしましたが、以前は XPS 形式を介して印刷することが想定されていました。

## **Aspose.Slides を使用した XPS 変換**

Java 用の[**Aspose.Slides**](https://products.aspose.com/slides/ja/java/)では、[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation) クラスが提供する [**Save**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) メソッドを使用して、プレゼンテーション全体を XPS ドキュメントに変換できます。

プレゼンテーションを XPS に変換する際は、以下のいずれかの設定で保存する必要があります。

- 既定の設定（[**XPSOptions**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/xpsoptions) を使用しない）
- カスタム設定（[**XPSOptions**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/xpsoptions) を使用）

### **既定の設定でプレゼンテーションを XPS に変換**

この Java のサンプルコードは、標準設定を使用してプレゼンテーションを XPS ドキュメントに変換する方法を示します。

```java
import com.aspose.slides.*;

// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // プレゼンテーションを XPS ドキュメントに保存する
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **カスタム設定でプレゼンテーションを XPS に変換**

このサンプルコードは、カスタム設定を使用してプレゼンテーションを XPS ドキュメントに変換する方法を示します。

```java
import com.aspose.slides.*;

// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // XpsOptions クラスをインスタンス化します
    XpsOptions options = new XpsOptions();

    // メタファイルを PNG として保存します
    options.setSaveMetafilesAsPng(true);

    // プレゼンテーションを XPS ドキュメントに保存します
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **よくある質問**

### ファイルではなくストリームに XPS を保存できますか？

はい。Aspose.Slides はストリームへ直接エクスポートできるため、Web API やサーバーサイドのパイプライン、ファイルシステムに触れずに XPS を送信したいシナリオに最適です。

### 非表示スライドは XPS に含まれますか、除外できますか？

既定では可視スライドのみがレンダリングされます。非表示スライドの [include or exclude hidden slides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) は、[export settings](https://reference.aspose.com/slides/ja/java/com.aspose.slides/xpsoptions/) で設定でき、必要なページだけを XPS に出力できます。