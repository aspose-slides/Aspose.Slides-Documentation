---
title: .NET で PowerPoint プレゼンテーションを XPS に変換する
linktitle: PowerPoint から XPS へ
type: docs
weight: 70
url: /ja/net/convert-powerpoint-to-xps/
keywords:
- PowerPoint 変換
- プレゼンテーション変換
- スライド変換
- PPT 変換
- PPTX 変換
- PowerPoint から XPS
- プレゼンテーションから XPS
- スライドから XPS
- PPT から XPS
- PPTX から XPS
- PPT を XPS として保存
- PPTX を XPS として保存
- PPT を XPS にエクスポート
- PPTX を XPS にエクスポート
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して、.NET で PowerPoint の PPT/PPTX を高品質かつプラットフォーム非依存の XPS に変換します。ステップバイステップのガイドとサンプル C# コードをご覧ください。"
---

## **XPS について**
Microsoft は [XPS](https://docs.fileformat.com/page-description-language/xps/) を [PDF](https://docs.fileformat.com/pdf/) の代替として開発しました。PDF に非常に似たファイルを出力することでコンテンツを印刷できます。XPS フォーマットは XML をベースにしています。XPS ファイルのレイアウトや構造はすべての OS とプリンターで同じままです。

## **Microsoft XPS フォーマットを使用すべき時**
{{% alert color="primary" %}} 
Aspose.Slides が PPT または PPTX プレゼンテーションを XPS フォーマットに変換する方法を確認するには、[この無料オンラインコンバータ アプリ](https://products.aspose.app/slides/conversion) をご覧ください。 
{{% /alert %}} 

ストレージコストを削減したい場合は、Microsoft PowerPoint プレゼンテーションを XPS フォーマットに変換できます。これにより、ドキュメントの保存、共有、印刷がより簡単になります。

Microsoft は Windows（Windows 10 でも）に対する XPS のサポートを引き続き強化しているため、このフォーマットでファイルを保存することを検討した方が良いでしょう。Windows 8.1、Windows 8、Windows 7、Windows Vista を使用している場合、特定の操作では XPS が最適な選択肢になる可能性があります。

- **Windows 8** は XPS ファイルに OXPS（Open XPS）フォーマットを使用します。OXPS は元の XPS フォーマットの標準化バージョンです。Windows 8 は PDF ファイルよりも XPS ファイルのサポートが優れています。  
  - **XPS:** 組み込みの XPS ビューア/リーダーと XPS への印刷機能が利用可能。  
  - **PDF**: PDF リーダーは利用可能ですが、PDF への印刷機能はありません。  

- **Windows 7 と Windows Vista** は元の XPS フォーマットを使用します。これらの OS も PDF より XPS ファイルのサポートが優れています。  
  - **XPS**: 組み込みの XPS ビューアと XPS への印刷機能が利用可能。  
  - **PDF**: PDF リーダーがありません。PDF への印刷機能もありません。  

|<p>**入力 PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**出力 XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft は最終的に Windows 10 の「Print to PDF」機能を通じて PDF の印刷操作サポートを実装しました。以前は、ユーザーは XPS フォーマットを介して文書を印刷することが想定されていました。

## **Aspose.Slides を使用した XPS 変換**
.NET 用の [**Aspose.Slides**](https://products.aspose.com/slides/net/) では、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスが提供する [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) メソッドを使用して、プレゼンテーション全体を XPS ドキュメントに変換できます。

プレゼンテーションを XPS に変換する際は、以下の設定のいずれかでプレゼンテーションを保存する必要があります。

- デフォルト設定（[**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions) なし）
- カスタム設定（[**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions) 使用）

### **デフォルト設定でプレゼンテーションを XPS に変換**
C# のサンプルコードは、標準設定を使用してプレゼンテーションを XPS ドキュメントに変換する方法を示しています:
```c#
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // プレゼンテーションを XPS ドキュメントとして保存します
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```


### **カスタム設定でプレゼンテーションを XPS に変換**
C# のサンプルコードは、カスタム設定を使用してプレゼンテーションを XPS ドキュメントに変換する方法を示しています:
```c#
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // TiffOptions クラスをインスタンス化します
    XpsOptions options = new XpsOptions();

    // MetaFiles を PNG として保存します
    options.SaveMetafilesAsPng = true;

    // プレゼンテーションを XPS ドキュメントとして保存します
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```


## **FAQ**

**ファイルではなくストリームに XPS を保存できますか？**

はい。Aspose.Slides はストリームへ直接エクスポートできるため、Web API やサーバー側パイプライン、またはファイルシステムに触れずに XPS を送信したいあらゆるシナリオに最適です。

**非表示スライドは XPS に含まれますか？また、除外できますか？**

デフォルトでは、通常（表示）スライドのみがレンダリングされます。XPS に保存する前に、[エクスポート設定](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/)で [非表示スライドを含めるか除外するか](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/showhiddenslides/) を指定でき、出力に意図したページだけが含まれるようにできます。