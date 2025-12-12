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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して、Java で PowerPoint PPT/PPTX を高品質かつプラットフォーム非依存の XPS に変換します。ステップバイステップのガイドとサンプルコードが入手できます。"
---

## **XPS について**
Microsoft は PDF の代替として XPS を開発しました。XPS は PDF に非常に似たファイルを出力することでコンテンツを印刷できるようにします。XPS 形式は XML をベースにしています。XPS ファイルのレイアウトや構造は、すべてのオペレーティングシステムやプリンターで同じです。 

## **Microsoft XPS 形式を使用する場面**

{{% alert color="primary" %}} 

Aspose.Slides が PPT や PPTX プレゼンテーションを XPS 形式に変換する方法を確認するには、[この無料オンラインコンバータアプリ](https://products.aspose.app/slides/conversion)をご覧ください。 

{{% /alert %}} 

ストレージコストを削減したい場合は、Microsoft PowerPoint プレゼンテーションを XPS 形式に変換できます。これにより、ドキュメントの保存、共有、印刷がより簡単になります。 

Microsoft は Windows (Windows 10 でも) で XPS の強力なサポートを継続的に実装しているため、この形式でファイルを保存することを検討した方がよいでしょう。Windows 8.1、Windows 8、Windows 7、Windows Vista を使用している場合、特定の操作では XPS が最適な選択肢になることがあります。 

- **Windows 8** は XPS ファイルに OXPS (Open XPS) 形式を使用します。OXPS は元の XPS 形式の標準化バージョンです。Windows 8 は PDF ファイルよりも XPS ファイルのサポートが優れています。 
  - **XPS:** 組み込みの XPS ビューア/リーダーと XPS への印刷機能が利用可能です。 
  - **PDF:** PDF リーダーは利用可能ですが、PDF への印刷機能はありません。 

- **Windows 7 と Windows Vista** は元の XPS 形式を使用します。これらの OS も PDF より XPS のサポートが優れています。 
  - **XPS:** 組み込みの XPS ビューアと XPS への印刷機能が利用可能です。 
  - **PDF:** PDF リーダーがありません。PDF への印刷機能もありません。 

|<p>**入力 PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**出力 XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft は最終的に Windows 10 の「印刷先 PDF」機能を通じて PDF の印刷操作のサポートを実装しました。それ以前は、ユーザーは XPS 形式で文書を印刷することが期待されていました。 

## **Aspose.Slides を使用した XPS 変換**

Java 用 Aspose.Slides では、Presentation クラスが提供する Save メソッドを使用して、プレゼンテーション全体を XPS ドキュメントに変換できます。

プレゼンテーションを XPS に変換する際は、次のいずれかの設定で保存する必要があります。

- デフォルト設定 (XPSOptions なし)
- カスタム設定 (XPSOptions 使用)

### **デフォルト設定でプレゼンテーションを XPS に変換**

この Java のサンプルコードは、標準設定を使用してプレゼンテーションを XPS ドキュメントに変換する方法を示しています:
```java
// プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化する
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // プレゼンテーションを XPS ドキュメントに保存する
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```


### **カスタム設定でプレゼンテーションを XPS に変換**

このサンプルコードは、Java でカスタム設定を使用してプレゼンテーションを XPS ドキュメントに変換する方法を示しています:
```java
// プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化する
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // TiffOptions クラスをインスタンス化する
    XpsOptions options = new XpsOptions();

    // MetaFiles を PNG として保存する
    options.setSaveMetafilesAsPng(true);

    // プレゼンテーションを XPS ドキュメントに保存する
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```


## **よくある質問**

**ストリームに XPS を保存できますか（ファイルではなく）？**

はい。Aspose.Slides はストリームへ直接エクスポートでき、Web API、サーバー側パイプライン、またはファイルシステムに触れずに XPS を送信したいあらゆるシナリオに最適です。

**非表示スライドは XPS に含まれますか、除外できますか？**

デフォルトでは、通常（表示）スライドのみがレンダリングされます。[非表示スライドを含めるか除外するか](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) は、XPS に保存する前の[エクスポート設定](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xpsoptions/)で指定できます。これにより、出力に意図したページだけが含まれます。