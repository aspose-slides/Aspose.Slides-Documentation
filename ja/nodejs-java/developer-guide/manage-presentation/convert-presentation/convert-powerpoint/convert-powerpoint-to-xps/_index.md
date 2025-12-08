---
title: PowerPoint を XPS に変換
type: docs
weight: 70
url: /ja/nodejs-java/convert-powerpoint-to-xps/
keywords: "PPT, PPTX を XPS に"
description: "JavaScript で PowerPoint PPT(X) を XPS に変換"
---

## **XPS について**

Microsoft は [XPS](https://docs.fileformat.com/page-description-language/xps/) を [PDF](https://docs.fileformat.com/pdf/) の代替として開発しました。PDF に非常に似たファイルを出力することでコンテンツを印刷できます。XPS 形式は XML に基づいています。XPS ファイルのレイアウトや構造は、すべての OS やプリンターで同一です。

## **Microsoft XPS フォーマットの使用時期**

{{% alert color="primary" %}} 
Microsoft PowerPoint の PPT または PPTX プレゼンテーションを XPS 形式に変換する方法は、[この無料オンライン変換アプリ](https://products.aspose.app/slides/conversion) で確認できます。 
{{% /alert %}} 

ストレージ コストを削減したい場合、PowerPoint プレゼンテーションを XPS 形式に変換できます。これにより、ドキュメントの保存・共有・印刷が容易になります。  

Microsoft は Windows (Windows 10 でも) で XPS の強力なサポートを継続的に実装していますので、ファイルをこの形式で保存することを検討してください。Windows 8.1、Windows 8、Windows 7、Windows Vista を使用している場合、特定の操作において XPS が最適な選択肢になることがあります。  

- **Windows 8** は XPS ファイルに OXPS (Open XPS) 形式を使用します。OXPS は元の XPS 形式の標準化バージョンです。Windows 8 は PDF ファイルよりも XPS ファイルのサポートが優れています。  
  - **XPS**: 組み込み XPS ビューア/リーダーと XPS への印刷機能が利用可能。  
  - **PDF**: PDF リーダーは利用可能ですが、PDF への印刷機能はありません。  

- **Windows 7 と Windows Vista** は元の XPS 形式を使用します。これらの OS も PDF より XPS のサポートが優れています。  
  - **XPS**: 組み込み XPS ビューアと XPS への印刷機能が利用可能。  
  - **PDF**: PDF リーダーはなし。PDF への印刷機能はなし。  

|<p>**入力 PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**出力 XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft は最終的に Windows 10 の「Print to PDF」機能を通じて PDF の印刷操作サポートを実装しました。以前はユーザーは XPS 形式を介してドキュメントを印刷することが想定されていました。  

## **Aspose.Slides による XPS 変換**

[**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/) では、[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスが提供する [**save**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) メソッドを使用して、プレゼンテーション全体を XPS ドキュメントに変換できます。

プレゼンテーションを XPS に変換する場合、次のいずれかの設定で保存する必要があります。

- デフォルト設定 ( **XPSOptions** なし )
- カスタム設定 ( **XPSOptions** あり )

### **デフォルト設定でプレゼンテーションを XPS に変換する**

次の JavaScript サンプルコードは、標準設定を使用してプレゼンテーションを XPS ドキュメントに変換する方法を示しています。
```javascript
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
var pres = new aspose.slides.Presentation("Convert_XPS.pptx");
try {
    // プレゼンテーションを XPS ドキュメントに保存します
    pres.save("XPS_Output_Without_XPSOption.xps", aspose.slides.SaveFormat.Xps);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **カスタム設定でプレゼンテーションを XPS に変換する**

次のサンプルコードは、カスタム設定を使用してプレゼンテーションを XPS ドキュメントに変換する方法を JavaScript で示しています。
```javascript
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
var pres = new aspose.slides.Presentation("Convert_XPS_Options.pptx");
try {
    // TiffOptions クラスをインスタンス化します
    var options = new aspose.slides.XpsOptions();
    // メタファイルを PNG として保存します
    options.setSaveMetafilesAsPng(true);
    // プレゼンテーションを XPS ドキュメントに保存します
    pres.save("XPS_Output_With_Options.xps", aspose.slides.SaveFormat.Xps, options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**ストリームに保存して XPS を取得できますか？**

はい。Aspose.Slides はストリームへの直接エクスポートをサポートしており、Web API、サーバー側パイプライン、またはファイルシステムに触れずに XPS を送信したいシナリオに最適です。

**非表示スライドは XPS に含まれますか？除外できますか？**

デフォルトでは、通常の（可視）スライドのみがレンダリングされます。保存前に [export settings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions/) で [非表示スライドの含める/除外する設定](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions/setshowhiddenslides/) を使用でき、出力に意図したページだけを含めることができます。