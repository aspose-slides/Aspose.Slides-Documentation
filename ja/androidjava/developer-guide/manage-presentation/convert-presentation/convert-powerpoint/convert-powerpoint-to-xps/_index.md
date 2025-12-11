---
title: Android で PowerPoint プレゼンテーションを XPS に変換
linktitle: PowerPoint を XPS に変換
type: docs
weight: 70
url: /ja/androidjava/convert-powerpoint-to-xps/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して、Java で PowerPoint PPT/PPTX を高品質かつプラットフォームに依存しない XPS に変換します。ステップバイステップのガイドとサンプルコードをご覧ください。"
---

## **XPS について**
Microsoft は [XPS](https://docs.fileformat.com/page-description-language/xps/) を [PDF](https://docs.fileformat.com/pdf/) の代替として開発しました。PDF に非常に似たファイルを出力してコンテンツを印刷できるようにします。XPS 形式は XML に基づいています。XPS ファイルのレイアウトや構造は、すべてのオペレーティング システムとプリンターで同じままです。

## **Microsoft XPS 形式を使用すべきとき**

{{% alert color="primary" %}} 

Aspose.Slides が PPT または PPTX プレゼンテーションを XPS 形式に変換する方法は、[この無料オンライン変換アプリ](https://products.aspose.app/slides/conversion)で確認できます。 

{{% /alert %}} 

ストレージ コストを削減したい場合は、Microsoft PowerPoint プレゼンテーションを XPS 形式に変換できます。これにより、ドキュメントの保存、共有、印刷が容易になります。

Microsoft は Windows（Windows 10 でも）で XPS の強力なサポートを継続的に実装しているため、この形式でファイルを保存することを検討する価値があります。Windows 8.1、Windows 8、Windows 7、Windows Vista を使用している場合、特定の操作で XPS が最適な選択肢になることがあります。

- **Windows 8** は XPS ファイルに OXPS（Open XPS）形式を使用します。OXPS は元の XPS 形式の標準化バージョンです。Windows 8 は PDF ファイルよりも XPS ファイルのサポートが優れています。 
  - **XPS**: 組み込みの XPS ビューア/リーダーと XPS への印刷機能が利用可能。 
  - **PDF**: PDF リーダーは利用可能ですが、PDF への印刷機能はありません。 

- **Windows 7 と Windows Vista** は元の XPS 形式を使用します。これらの OS も PDF より XPS のサポートが優れています。 
  - **XPS**: 組み込みの XPS ビューアと XPS への印刷機能が利用可能。 
  - **PDF**: PDF リーダーがなく、PDF への印刷機能もありません。 

|<p>**入力 PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**出力 XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft は最終的に Windows 10 の「Print to PDF」機能を通じて PDF の印刷操作をサポートしました。以前はユーザーは XPS 形式で文書を印刷することが期待されていました。 

## **Aspose.Slides を使用した XPS 変換**

Java 用の [**Aspose.Slides**](https://products.aspose.com/slides/androidjava/) では、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスが提供する [**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) メソッドを使用して、プレゼンテーション全体を XPS ドキュメントに変換できます。

プレゼンテーションを XPS に変換する際は、次のいずれかの設定でプレゼンテーションを保存する必要があります。

- デフォルト設定（[**XPSOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xpsoptions) を使用しない）
- カスタム設定（[**XPSOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xpsoptions) を使用）

### **デフォルト設定でプレゼンテーションを XPS に変換する**

以下の Java サンプルコードは、標準設定を使用してプレゼンテーションを XPS ドキュメントに変換する方法を示しています:
```java
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // プレゼンテーションを XPS ドキュメントとして保存
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```


### **カスタム設定でプレゼンテーションを XPS に変換する**
以下のサンプルコードは、カスタム設定を使用して Java でプレゼンテーションを XPS ドキュメントに変換する方法を示しています:
```java
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // TiffOptions クラスをインスタンス化します
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

**XPS をファイルではなくストリームに保存できますか？**

はい。Aspose.Slides はストリームに直接エクスポートできるため、Web API、サーバー側パイプライン、またはファイルシステムに触れずに XPS を送信したいシナリオに最適です。

**非表示スライドは XPS に含まれますか？除外できますか？**

デフォルトでは、通常の（表示されている）スライドのみがレンダリングされます。[export settings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xpsoptions/) を使用して、[hidden slides を含めるか除外するか](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) を XPS に保存する前に設定でき、出力に必要なページだけを含めることができます。