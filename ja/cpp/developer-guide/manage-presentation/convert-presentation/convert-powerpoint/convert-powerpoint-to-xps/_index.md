---
title: PowerPointプレゼンテーションをC++でXPSに変換
linktitle: PowerPointからXPSへ
type: docs
weight: 70
url: /ja/cpp/convert-powerpoint-to-xps
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- スライドを変換
- PPTを変換
- PPTXを変換
- PowerPointからXPSへ
- プレゼンテーションをXPSへ
- スライドをXPSへ
- PPTをXPSへ
- PPTXをXPSへ
- PPTをXPSとして保存
- PPTXをXPSとして保存
- PPTをXPSにエクスポート
- PPTXをXPSにエクスポート
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slidesを使用してC++でPowerPoint PPT/PPTXを高品質でプラットフォームに依存しないXPSに変換します。ステップバイステップのガイドとサンプルコードを入手。"
---

## **XPS について**
Microsoft は、[PDF](https://docs.fileformat.com/pdf/) の代替として [XPS](https://docs.fileformat.com/page-description-language/xps/) を開発しました。PDF に非常に似たファイルを出力することでコンテンツを印刷できます。XPS 形式は XML に基づいており、XPS ファイルのレイアウトや構造はすべての OS やプリンターで同じです。 

## **Microsoft XPS 形式を使用すべきとき**

{{% alert color="primary" %}} 

Aspose.Slides が PPT または PPTX プレゼンテーションを XPS 形式に変換する方法を確認するには、[この無料オンラインコンバーター アプリ](https://products.aspose.app/slides/conversion)をご覧ください。 

{{% /alert %}} 

ストレージコストを削減したい場合は、Microsoft PowerPoint プレゼンテーションを XPS 形式に変換できます。これにより、ドキュメントの保存、共有、印刷が容易になります。 

Microsoft は Windows（Windows 10 でも）における XPS のサポートを引き続き強化しているため、ファイルをこの形式で保存することを検討した方がよいでしょう。Windows 8.1、Windows 8、Windows 7、Windows Vista を使用している場合、特定の操作では XPS が最適な選択肢になることがあります。 

- **Windows 8** は XPS ファイルに OXPS（Open XPS）形式を使用します。OXPS は元の XPS 形式の標準化バージョンです。Windows 8 は PDF ファイルよりも XPS ファイルのサポートが優れています。 
  - **XPS:** 組み込みの XPS ビューア/リーダーと XPS への印刷機能が利用可能です。 
  - **PDF**: PDF リーダーは利用可能ですが、PDF への印刷機能はありません。 

- **Windows 7 and Windows Vista** は元の XPS 形式を使用します。これらの OS も PDF より XPS ファイルのサポートが優れています。 
  - **XPS**: 組み込みの XPS ビューアと XPS への印刷機能が利用可能です。 
  - **PDF**: PDF リーダーはありません。PDF への印刷機能もありません。 

|<p>**入力 PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**出力 XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft は最終的に Windows 10 の「Print to PDF」機能を通じて PDF の印刷操作をサポートしました。以前は、ユーザーは XPS 形式を介して文書を印刷することが想定されていました。 

## **Aspose.Slides を使用した XPS 変換**

C++ 向けの [**Aspose.Slides**](https://products.aspose.com/slides/cpp/) では、[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスが提供する [**Save**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) メソッドを使用して、プレゼンテーション全体を XPS ドキュメントに変換できます。 

プレゼンテーションを XPS に変換する際は、以下のいずれかの設定で保存する必要があります: 

- デフォルト設定（[**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options) を使用しない） 
- カスタム設定（[**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options) を使用） 

### **デフォルト設定でプレゼンテーションを XPS に変換する**

この C++ のサンプルコードは、標準設定でプレゼンテーションを XPS ドキュメントに変換する方法を示しています:  
``` cpp
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// プレゼンテーションを XPS ドキュメントに保存します
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```


### **カスタム設定でプレゼンテーションを XPS に変換する**
この C++ のサンプルコードは、カスタム設定でプレゼンテーションを XPS ドキュメントに変換する方法を示しています:  
``` cpp
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// TiffOptions クラスをインスタンス化します
auto options = System::MakeObject<XpsOptions>();

// メタファイルを PNG として保存します
options->set_SaveMetafilesAsPng(true);

// プレゼンテーションを XPS ドキュメントに保存します
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```


## **よくある質問**

**ファイルではなくストリームに XPS を保存できますか？**

はい。Aspose.Slides はストリームに直接エクスポートできるため、Web API やサーバー側パイプライン、あるいはファイルシステムに触れずに XPS を送信したいあらゆるシナリオに最適です。  

**非表示スライドは XPS に含まれますか？除外できますか？**

デフォルトでは、通常の（表示されている）スライドのみがレンダリングされます。XPS に保存する前に [エクスポート設定](https://reference.aspose.com/slides/cpp/aspose.slides.export/xpsoptions/) で [非表示スライドの含める/除外する](https://reference.aspose.com/slides/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/)ことができ、出力に意図したページだけが含まれるようにできます。