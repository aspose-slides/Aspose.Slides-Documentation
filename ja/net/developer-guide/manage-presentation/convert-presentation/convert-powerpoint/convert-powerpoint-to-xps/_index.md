---
title: .NET で PowerPoint プレゼンテーションを XPS に変換
linktitle: PowerPoint から XPS へ
type: docs
weight: 70
url: /ja/net/convert-powerpoint-to-xps/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して .NET で PowerPoint PPT/PPTX を高品質かつプラットフォームに依存しない XPS に変換します。ステップバイステップのガイドとサンプル C# コードを取得できます。"
---

## **XPS の概要**
Microsoft は [XPS](https://docs.fileformat.com/page-description-language/xps/) を [PDF](https://docs.fileformat.com/pdf/) の代替として開発しました。PDF に非常に似たファイルを出力することでコンテンツを印刷できます。XPS 形式は XML をベースにしています。XPS ファイルのレイアウトや構造はすべてのオペレーティングシステムやプリンターで同じままです。

## **Microsoft XPS 形式を使用すべき時**

{{% alert color="primary" %}} 

Aspose.Slides が PPT または PPTX プレゼンテーションを XPS 形式に変換する方法を見るには、[この無料オンラインコンバーター アプリ](https://products.aspose.app/slides/conversion) をご覧ください。 

{{% /alert %}} 

ストレージ コストを削減したい場合は、Microsoft PowerPoint プレゼンテーションを XPS 形式に変換できます。これにより、ドキュメントの保存、共有、印刷がより簡単になります。 

Microsoft は Windows（Windows 10 でも）で XPS の強力なサポートを継続的に実装しているため、この形式でファイルを保存することを検討した方が良いかもしれません。Windows 8.1、Windows 8、Windows 7、Windows Vista を使用している場合、特定の操作では XPS が最適な選択肢になることがあります。 

- **Windows 8** は XPS ファイルに OXPS (Open XPS) 形式を使用します。OXPS は元の XPS 形式の標準化バージョンです。Windows 8 は PDF ファイルよりも XPS ファイルのサポートが優れています。 
  - **XPS**: 組み込みの XPS ビューア/リーダーと XPS への印刷機能が利用可能です。 
  - **PDF**: PDF リーダーは利用可能ですが、PDF への印刷機能はありません。 

- **Windows 7** および **Windows Vista** は元の XPS 形式を使用します。これらのオペレーティング システムも PDF より XPS ファイルのサポートが優れています。 
  - **XPS**: 組み込みの XPS ビューアと XPS への印刷機能が利用可能です。 
  - **PDF**: PDF リーダーはありません。PDF への印刷機能もありません。 

|<p>**入力 PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**出力 XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft は最終的に Windows 10 の Print to PDF 機能を通じて PDF での印刷操作のサポートを実装しました。それ以前は、ユーザーは XPS 形式を使用してドキュメントを印刷することが想定されていました。

## **Aspose.Slides を使用した XPS 変換**

.NET 用の [**Aspose.Slides**](https://products.aspose.com/slides/net/) では、[**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) メソッド（[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスで公開）を使用して、プレゼンテーション全体を XPS ドキュメントに変換できます。 

プレゼンテーションを XPS に変換する際は、以下のいずれかの設定でプレゼンテーションを保存する必要があります：

- デフォルト設定（[**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions) なし）
- カスタム設定（[**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions) 使用）

### **デフォルト設定を使用したプレゼンテーションの XPS 変換**

この C# のサンプルコードは、標準設定を使用してプレゼンテーションを XPS ドキュメントに変換する方法を示しています：
```c#
// プレゼンテーション ファイルを表す Presentation オブジェクトを作成します
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // プレゼンテーションを XPS ドキュメントに保存します
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```


### **カスタム設定を使用したプレゼンテーションの XPS 変換**

この C# のサンプルコードは、カスタム設定を使用してプレゼンテーションを XPS ドキュメントに変換する方法を示しています：
```c#
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // TiffOptions クラスをインスタンス化します
    XpsOptions options = new XpsOptions();

    // MetaFiles を PNG として保存します
    options.SaveMetafilesAsPng = true;

    // プレゼンテーションを XPS ドキュメントに保存します
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```


## **よくある質問**

**ファイルではなくストリームに XPS を保存できますか？**

はい。Aspose.Slides を使用すると、ストリームに直接エクスポートでき、Web API、サーバー側パイプライン、またはファイルシステムに触れずに XPS を送信したいあらゆるシナリオに最適です。

**非表示スライドは XPS に転送されますか、また除外できますか？**

デフォルトでは、通常（表示）スライドのみがレンダリングされます。XPS に保存する前に、[エクスポート設定](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/) で [非表示スライドを含めるまたは除外する](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/showhiddenslides/)ことができ、出力に意図したページだけが含まれるようにできます。