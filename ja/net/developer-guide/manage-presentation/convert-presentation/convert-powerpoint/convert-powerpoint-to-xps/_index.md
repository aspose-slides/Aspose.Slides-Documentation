---
title: PowerPointをXPSに変換
type: docs
weight: 70
url: /ja/net/convert-powerpoint-to-xps
keywords: "PowerPointプレゼンテーションの変換, PowerPointからXPSへ, PPTからXPSへ, PPTXからXPSへ, 変換, C#, Csharp, .NET, Aspose.Slides"
description: "C#または.NETでPowerPointプレゼンテーションをXPSに変換します。"
---

## **XPS について**
Microsoft は [XPS](https://docs.fileformat.com/page-description-language/xps/) を [PDF](https://docs.fileformat.com/pdf/) の代替として開発しました。 PDF に非常に似たファイルを出力することでコンテンツを印刷できるようになります。 XPS フォーマットは XML に基づいています。 XPS ファイルのレイアウトや構造は、すべてのオペレーティングシステムやプリンターで同じままです。

## **Microsoft XPS フォーマットを使用すべきとき**

{{% alert color="primary" %}} 

Microsoft PowerPoint の PPT または PPTX プレゼンテーションが XPS フォーマットにどのように変換されるかを確認したい場合は、[この無料オンライン変換アプリ](https://products.aspose.app/slides/conversion) をご利用ください。 

{{% /alert %}} 

ストレージコストを削減したい場合は、Microsoft PowerPoint プレゼンテーションを XPS フォーマットに変換できます。これにより、ドキュメントの保存、共有、印刷が容易になります。 

Microsoft は Windows（Windows 10 でも）で XPS のサポートを強化し続けているため、このフォーマットでファイルを保存することを検討すべきです。Windows 8.1、Windows 8、Windows 7、Windows Vista を使用している場合、特定の操作では XPS が最適な選択肢になることがあります。 

- **Windows 8** は XPS ファイルに OXPS（Open XPS）形式を使用します。 OXPS は元の XPS フォーマットの標準化バージョンです。Windows 8 は PDF ファイルよりも XPS ファイルのサポートが優れています。 
  - **XPS:** 組み込みの XPS ビューア/リーダーと XPS への印刷機能が利用可能。 
  - **PDF:** PDF リーダーは利用可能だが、PDF への印刷機能はなし。 

- **Windows 7 と Windows Vista** は元の XPS フォーマットを使用します。これらの OS も PDF より XPS ファイルのサポートが優れています。 
  - **XPS:** 組み込みの XPS ビューアと XPS への印刷機能が利用可能。 
  - **PDF:** PDF リーダーなし。PDF への印刷機能なし。 

|<p>**入力 PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**出力 XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft は最終的に Windows 10 の「Print to PDF」機能を通じて PDF の印刷操作サポートを実装しました。以前はユーザーは XPS フォーマットを介して文書を印刷することが想定されていました。 

## **Aspose.Slides を使用した XPS 変換**

.NET 用の [**Aspose.Slides**](https://products.aspose.com/slides/net/) では、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスが提供する [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) メソッドを使用して、プレゼンテーション全体を XPS ドキュメントに変換できます。 

プレゼンテーションを XPS に変換する際は、以下のいずれかの設定でプレゼンテーションを保存する必要があります。

- デフォルト設定（[**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions) なし） 
- カスタム設定（[**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions) あり） 

### **既定設定を使用してプレゼンテーションを XPS に変換する**

この C# サンプルコードは、標準設定を使用してプレゼンテーションを XPS ドキュメントに変換する方法を示しています。 
```c#
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // プレゼンテーションを XPS ドキュメントとして保存します
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```


### **カスタム設定を使用してプレゼンテーションを XPS に変換する**
このサンプルコードは、C# でカスタム設定を使用してプレゼンテーションを XPS ドキュメントに変換する方法を示しています。 
```c#
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // TiffOptions クラスをインスタンス化します
    XpsOptions options = new XpsOptions();

    // メタファイルを PNG として保存します
    options.SaveMetafilesAsPng = true;

    // プレゼンテーションを XPS ドキュメントとして保存します
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```


## **FAQ**

**XPS をファイルではなくストリームに保存できますか？**

はい。Aspose.Slides はストリームへ直接エクスポートできるため、Web API、サーバー側パイプライン、ファイルシステムに触れずに XPS を送信したいシナリオに最適です。

**非表示スライドは XPS に含まれますか？除外できますか？**

既定では通常（表示）スライドのみがレンダリングされます。保存前に [エクスポート設定](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/) を使用して、[非表示スライドの含める・除外する](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/showhiddenslides/)ことができます。これにより、出力に意図したページだけが含まれます。