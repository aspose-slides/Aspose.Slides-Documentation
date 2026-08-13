---
title: Android で PowerPoint プレゼンテーションを XPS に変換
linktitle: PowerPoint から XPS へ
type: docs
weight: 70
url: /ja/androidjava/convert-powerpoint-to-xps/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint から XPS へ
- プレゼンテーションを XPS へ
- スライドを XPS へ
- PPT を XPS へ
- PPTX を XPS へ
- PPT を XPS として保存
- PPTX を XPS として保存
- PPT を XPS にエクスポート
- PPTX を XPS にエクスポート
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して、Java で PowerPoint PPT/PPTX を高品質かつプラットフォーム非依存の XPS に変換します。ステップバイステップのガイドとサンプルコードをご覧ください。"
---
## **概要**

Aspose.Slides は、PPT または PPTX ファイルを XPS 形式で保存することで、PowerPoint プレゼンテーションを XPS に変換できます。本記事では、XPS 形式が有用となるケースを説明し、デフォルト設定またはカスタム [XpsOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/xpsoptions/) 設定を使用して Aspose.Slides で変換を実行する方法を示します。

## **XPS について**
Microsoft は [XPS](https://docs.fileformat.com/page-description-language/xps/) を [PDF](https://docs.fileformat.com/pdf/) の代替として開発しました。PDF に非常に似たファイルを出力することでコンテンツを印刷でき、XPS 形式は XML を基盤としています。XPS ファイルのレイアウトや構造はすべての OS やプリンターで同一です。

## **Microsoft XPS 形式を使用すべき場面**

{{% alert color="info" %}} 

Aspose.Slides が PPT または PPTX プレゼンテーションを XPS 形式に変換する方法を確認したい場合は、[この無料オンライン変換アプリ](https://products.aspose.app/slides/ja/conversion)をご利用ください。

{{% /alert %}} 

ストレージコストを削減したい場合は、Microsoft PowerPoint プレゼンテーションを XPS 形式に変換できます。これにより、ドキュメントの保存・共有・印刷が容易になります。

Microsoft は Windows（Windows 10 でも）で XPS のサポートを強化し続けているため、この形式でファイルを保存することを検討するとよいでしょう。Windows 8.1、Windows 8、Windows 7、Windows Vista を使用している場合、特定の操作で XPS が最適な選択肢になることがあります。

- **Windows 8** は XPS ファイルに OXPS（Open XPS）形式を使用します。OXPS は元の XPS 形式の標準化バージョンで、Windows 8 は PDF ファイルよりも XPS ファイルのサポートが優れています。 
  - **XPS:** 組み込み XPS ビューア/リーダーと XPS への印刷機能が利用可能。 
  - **PDF:** PDF リーダーは利用可能だが、PDF への印刷機能はなし。 

- **Windows 7 および Windows Vista** は元の XPS 形式を使用します。これらの OS も PDF より XPS のサポートが優れています。 
  - **XPS:** 組み込み XPS ビューアと XPS への印刷機能が利用可能。 
  - **PDF:** PDF リーダーがなく、PDF への印刷機能もなし。 

|<p>**入力 PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**出力 XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft は最終的に Windows 10 の「Print to PDF」機能で PDF への印刷操作をサポートしましたが、以前はユーザーは XPS 形式を介して文書を印刷することが想定されていました。

## **Aspose.Slides を使用した XPS 変換**

Java 用の [**Aspose.Slides**](https://products.aspose.com/slides/ja/androidjava/) では、[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスが提供する [**Save**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) メソッドを使用して、プレゼンテーション全体を XPS ドキュメントに変換できます。

プレゼンテーションを XPS に変換する際は、以下のいずれかの設定で保存する必要があります。

- デフォルト設定（[**XPSOptions**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/xpsoptions) なし）
- カスタム設定（[**XPSOptions**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/xpsoptions) 使用）

### **デフォルト設定でプレゼンテーションを XPS に変換する**

以下の Java サンプルコードは、標準設定でプレゼンテーションを XPS ドキュメントに変換する方法を示しています。

```java
import com.aspose.slides.*;

// プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // プレゼンテーションを XPS ドキュメントとして保存します
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **カスタム設定でプレゼンテーションを XPS に変換する**
以下のサンプルコードは、Java でカスタム設定を使用してプレゼンテーションを XPS ドキュメントに変換する方法を示しています。

```java
import com.aspose.slides.*;

// プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // XpsOptions クラスをインスタンス化します
    XpsOptions options = new XpsOptions();

    // メタファイルを PNG として保存します
    options.setSaveMetafilesAsPng(true);

    // プレゼンテーションを XPS ドキュメントとして保存します
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### ストリームに保存できますか？ ファイルではなく。

はい。Aspose.Slides はストリームへ直接エクスポートでき、Web API、サーバー側パイプライン、またはファイルシステムに触れずに XPS を送信したいシナリオに最適です。

### 非表示スライドは XPS に含まれますか？ 除外できますか？

デフォルトでは、通常（表示）スライドのみがレンダリングされます。保存前に [エクスポート設定](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/xpsoptions/) で [非表示スライドの表示/非表示を設定](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) でき、必要なページだけを XPS に含めることが可能です。