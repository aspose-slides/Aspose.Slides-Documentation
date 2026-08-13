---
title: .NET で PowerPoint プレゼンテーションを XPS に変換
linktitle: PowerPoint を XPS に変換
type: docs
weight: 70
url: /ja/net/convert-powerpoint-to-xps/
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
  - .NET
  - C#
  - Aspose.Slides
description: "Aspose.Slides を使用して、.NET で PowerPoint の PPT/PPTX を高品質かつプラットフォーム非依存の XPS に変換します。ステップバイステップのガイドと C# のサンプルコードをご覧ください。"
---
## **概要**

Aspose.Slides を使用すると、PowerPoint プレゼンテーションを PPT または PPTX ファイルを XPS 形式で保存することで XPS に変換できます。本記事では、XPS 形式が有用となるケースを説明し、Aspose.Slides を使用してデフォルト設定またはカスタム [XpsOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/xpsoptions/) 設定で変換する方法を示します。

## **XPS について**

Microsoft は [XPS](https://docs.fileformat.com/page-description-language/xps/) を [PDF](https://docs.fileformat.com/pdf/) の代替として開発しました。PDF に非常に似たファイルを出力することでコンテンツを印刷できます。XPS 形式は XML に基づいています。XPS ファイルのレイアウトや構造は、すべてのオペレーティングシステムやプリンターで同じままです。

## **Microsoft XPS 形式を使用すべき時**

{{% alert color="info" %}} 

Aspose.Slides が PPT または PPTX プレゼンテーションを XPS 形式に変換する方法をご覧になるには、[この無料のオンライン変換アプリ](https://products.aspose.app/slides/ja/conversion) をチェックしてください。 

{{% /alert %}} 

ストレージコストを削減したい場合は、Microsoft PowerPoint プレゼンテーションを XPS 形式に変換できます。これにより、ドキュメントの保存、共有、印刷がより簡単になります。  

Microsoft は Windows（Windows 10 でも）で XPS のサポートを強化し続けているため、ファイルをこの形式で保存することを検討した方が良いでしょう。Windows 8.1、Windows 8、Windows 7、Windows Vista を使用している場合、特定の操作では XPS が最適なオプションになることがあります。  

- **Windows 8** は XPS ファイルに OXPS (Open XPS) 形式を使用します。OXPS は元の XPS 形式の標準化バージョンです。Windows 8 は PDF ファイルよりも XPS ファイルのサポートが優れています。  
  - **XPS:** 組み込みの XPS ビューア/リーダーと XPS への印刷機能が利用可能。  
  - **PDF:** PDF リーダーは利用可能ですが、PDF への印刷機能はありません。  

- **Windows 7 と Windows Vista** は元の XPS 形式を使用します。これらの OS も PDF より XPS のサポートが優れています。  
  - **XPS:** 組み込みの XPS ビューアと XPS への印刷機能が利用可能。  
  - **PDF:** PDF リーダーがなく、PDF への印刷機能もありません。  

|<p>**入力 PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**出力 XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft は最終的に Windows 10 の「Print to PDF」機能で PDF の印刷操作をサポートしました。以前はユーザーは XPS 形式を通じて文書を印刷することが想定されていました。

## **Aspose.Slides を使用した XPS 変換**

.NET 用の [**Aspose.Slides**](https://products.aspose.com/slides/ja/net/) では、[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスが提供する [**Save**](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/methods/save/index) メソッドを使用して、プレゼンテーション全体を XPS ドキュメントに変換できます。  

プレゼンテーションを XPS に変換する際は、以下の設定のいずれかで保存する必要があります：  

- デフォルト設定（[**XPSOptions**](https://reference.aspose.com/slides/ja/net/aspose.slides.export/xpsoptions) なし）  
- カスタム設定（[**XPSOptions**](https://reference.aspose.com/slides/ja/net/aspose.slides.export/xpsoptions) 使用）  

### **デフォルト設定でプレゼンテーションを XPS に変換**

この C# のサンプルコードは、標準設定でプレゼンテーションを XPS ドキュメントに変換する方法を示しています：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // プレゼンテーションを XPS ドキュメントに保存します
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```

### **カスタム設定でプレゼンテーションを XPS に変換**

このサンプルコードは、C# でカスタム設定を使用してプレゼンテーションを XPS ドキュメントに変換する方法を示しています：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // TiffOptions クラスをインスタンス化します
    XpsOptions options = new XpsOptions();

    // メタファイルを PNG として保存します
    options.SaveMetafilesAsPng = true;

    // プレゼンテーションを XPS ドキュメントに保存します
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```

## **よくある質問**

### ファイルではなくストリームに XPS を保存できますか？

はい—Aspose.Slides はストリームへ直接エクスポートでき、Web API、サーバー側パイプライン、またはファイルシステムに触れずに XPS を送信したいあらゆるシナリオに最適です。

### 非表示スライドは XPS に含まれますか？除外できますか？

デフォルトでは、通常の（表示中の）スライドのみがレンダリングされます。[非表示スライドの含める/除外](https://reference.aspose.com/slides/ja/net/aspose.slides.export/xpsoptions/showhiddenslides/) を [エクスポート設定](https://reference.aspose.com/slides/ja/net/aspose.slides.export/xpsoptions/) で指定でき、保存時に出力に含めるページを正確に制御できます。