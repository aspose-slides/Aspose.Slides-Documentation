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
- PowerPoint から XPS へ
- プレゼンテーションから XPS へ
- スライドから XPS へ
- PPT から XPS へ
- PPTX から XPS へ
- PPT を XPS として保存
- PPTX を XPS として保存
- PPT を XPS にエクスポート
- PPTX を XPS にエクスポート
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して、Java で PowerPoint の PPT/PPTX を高品質でプラットフォームに依存しない XPS に変換します。ステップバイステップのガイドとサンプルコードをご覧ください。"
---

## **XPS について**
Microsoft は [XPS](https://docs.fileformat.com/page-description-language/xps/) を [PDF](https://docs.fileformat.com/pdf/) の代替として開発しました。PDF に非常に似たファイルを出力することでコンテンツを印刷できます。XPS フォーマットは XML に基づいています。XPS ファイルのレイアウトや構造はすべての OS やプリンターで同じです。

## **Microsoft XPS フォーマットを使用すべき時**
{{% alert color="primary" %}} 
Aspose.Slides が PPT または PPTX プレゼンテーションを XPS フォーマットに変換する方法を確認するには、[この無料オンラインコンバータ アプリ](https://products.aspose.app/slides/conversion)をご覧ください。 
{{% /alert %}} 

ストレージコストを削減したい場合は、Microsoft PowerPoint プレゼンテーションを XPS フォーマットに変換できます。これにより、ドキュメントの保存、共有、印刷が簡単になります。

Microsoft は Windows（Windows 10 でも）で XPS のサポートを強化し続けているため、ファイルをこのフォーマットで保存することを検討するとよいでしょう。Windows 8.1、Windows 8、Windows 7、Windows Vista を使用している場合、特定の操作で XPS が最適な選択肢になることがあります。

- **Windows 8** は XPS ファイルに OXPS（Open XPS）フォーマットを使用します。OXPS は元の XPS フォーマットの標準化バージョンです。Windows 8 は PDF ファイルよりも XPS ファイルのサポートが優れています。
  - **XPS:** 組み込みの XPS ビューア/リーダーと XPS への印刷機能が利用可能です。 
  - **PDF**：PDF リーダーは利用可能ですが、PDF への印刷機能はありません。 

- **Windows 7 および Windows Vista** は元の XPS フォーマットを使用します。これらの OS も PDF より XPS ファイルのサポートが優れています。
  - **XPS**：組み込みの XPS ビューアと XPS への印刷機能が利用可能です。 
  - **PDF**：PDF リーダーがなく、PDF への印刷機能もありません。 

|<p>**入力 PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**出力 XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft は最終的に Windows 10 の Print to PDF 機能を通じて PDF の印刷操作をサポートしました。それ以前は、ユーザーは XPS フォーマットを介して文書を印刷することが想定されていました。

## **Aspose.Slides を使用した XPS 変換**
Java 用の [**Aspose.Slides**](https://products.aspose.com/slides/java/) では、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスが提供する [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) メソッドを使用して、プレゼンテーション全体を XPS ドキュメントに変換できます。

プレゼンテーションを XPS に変換する際は、以下の設定のいずれかで保存する必要があります。

- デフォルト設定（[**XPSOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/xpsoptions) を使用しない）
- カスタム設定（[**XPSOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/xpsoptions) を使用）

### **デフォルト設定でプレゼンテーションを XPS に変換**
この Java のサンプルコードは、標準設定を使用してプレゼンテーションを XPS ドキュメントに変換する方法を示しています：
```java
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // プレゼンテーションを XPS ドキュメントとして保存します
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```


### **カスタム設定でプレゼンテーションを XPS に変換**
このサンプルコードは、Java でカスタム設定を使用してプレゼンテーションを XPS ドキュメントに変換する方法を示しています：
```java
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // TiffOptions クラスをインスタンス化します
    XpsOptions options = new XpsOptions();

    // MetaFiles を PNG として保存します
    options.setSaveMetafilesAsPng(true);

    // プレゼンテーションを XPS ドキュメントとして保存します
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**ファイルではなくストリームに XPS を保存できますか？**

はい。Aspose.Slides を使用すると、直接ストリームにエクスポートでき、Web API、サーバー側パイプライン、またはファイルシステムに触れずに XPS を送信したいあらゆるシナリオに最適です。

**非表示スライドは XPS に含まれますか？除外できますか？**

デフォルトでは、通常（表示）スライドのみがレンダリングされます。XPS に保存する前に、[エクスポート設定](https://reference.aspose.com/slides/java/com.aspose.slides/xpsoptions/)で[非表示スライドの含める・除外する](https://reference.aspose.com/slides/java/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-)ことができ、出力が意図したページだけになるよう制御できます。