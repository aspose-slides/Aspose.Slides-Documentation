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
description: Aspose.Slides を使用して、PowerPoint の PPT/PPTX を高品質でプラットフォーム非依存の XPS に .NET で変換します。ステップバイステップのガイドとサンプル C# コードを取得できます。
---

## **XPS について**
Microsoft は [XPS](https://docs.fileformat.com/page-description-language/xps/) を [PDF](https://docs.fileformat.com/pdf/) の代替として開発しました。PDF に非常に似たファイルを出力することでコンテンツの印刷が可能です。XPS 形式は XML をベースにしています。XPS ファイルのレイアウトや構造はすべての OS やプリンターで同一です。

## **Microsoft XPS 形式を使用すべきとき**

{{% alert color="primary" %}} 
Aspose.Slides が PPT または PPTX プレゼンテーションを XPS 形式に変換する方法を見るには、[この無料オンラインコンバータアプリ](https://products.aspose.app/slides/conversion) をご確認ください。 
{{% /alert %}} 

ストレージコストを削減したい場合は、Microsoft PowerPoint プレゼンテーションを XPS 形式に変換できます。これにより、ドキュメントの保存、共有、印刷が容易になります。

Microsoft は Windows（Windows 10 でも）で XPS のサポートを強化し続けているため、ファイルをこの形式で保存することを検討してください。Windows 8.1、Windows 8、Windows 7、Windows Vista を使用している場合、特定の操作では XPS が最適な選択肢になることがあります。

- **Windows 8** は XPS ファイルに OXPS（Open XPS）形式を使用します。OXPS は元の XPS 形式の標準化バージョンです。Windows 8 は PDF よりも XPS ファイルのサポートが優れています。  
  - **XPS**：組み込みの XPS ビューア/リーダーと XPS への印刷機能が利用可能。  
  - **PDF**：PDF リーダーは利用できるが、PDF への印刷機能はなし。  

- **Windows 7 と Windows Vista** は元の XPS 形式を使用します。これらの OS も PDF より XPS ファイルのサポートが優れています。  
  - **XPS**：組み込みの XPS ビューアと XPS への印刷機能が利用可能。  
  - **PDF**：PDF リーダーなし。PDF への印刷機能なし。  

|<p>**入力 PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**出力 XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft は最終的に Windows 10 の「Print to PDF」機能を通じて PDF の印刷操作をサポートしました。以前は XPS 形式での印刷が想定されていました。

## **Aspose.Slides を使用した XPS 変換**

.NET 用の [**Aspose.Slides**](https://products.aspose.com/slides/net/) では、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスが提供する [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) メソッドを使用して、プレゼンテーション全体を XPS ドキュメントに変換できます。

プレゼンテーションを XPS に変換する際は、以下の設定のいずれかで保存する必要があります。

- デフォルト設定（[**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions) なし）  
- カスタム設定（[**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions) 使用）

### **デフォルト設定でプレゼンテーションを XPS に変換する**

この C# のサンプルコードは、標準設定でプレゼンテーションを XPS ドキュメントに変換する方法を示しています:
```c#
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // プレゼンテーションを XPS ドキュメントとして保存します
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```


### **カスタム設定でプレゼンテーションを XPS に変換する**

このサンプルコードは、C# でカスタム設定を使用してプレゼンテーションを XPS ドキュメントに変換する方法を示しています:
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


## **よくある質問**

**ファイルではなくストリームに XPS を保存できますか？**

はい。Aspose.Slides はストリームへの直接エクスポートをサポートしており、Web API、サーバー側パイプライン、またはファイルシステムを介さずに XPS を送信したいシナリオに最適です。

**非表示スライドは XPS に引き継がれますか？除外できますか？**

デフォルトでは表示スライドのみがレンダリングされます。[エクスポート設定](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/)で [非表示スライドの表示/非表示を切り替える](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/showhiddenslides/)ことができ、必要なページだけを XPS に含めることができます。