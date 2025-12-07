---
title: C++でPowerPointプレゼンテーションをXPSに変換する
linktitle: PowerPointからXPSへ
type: docs
weight: 70
url: /ja/cpp/convert-powerpoint-to-xps
keywords:
- PowerPoint変換
- プレゼンテーション変換
- スライド変換
- PPT変換
- PPTX変換
- PowerPointからXPSへ
- プレゼンテーションからXPSへ
- スライドからXPSへ
- PPTからXPSへ
- PPTXからXPSへ
- PPTをXPSとして保存
- PPTXをXPSとして保存
- PPTをXPSにエクスポート
- PPTXをXPSにエクスポート
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slidesを使用して、C++でPowerPointのPPT/PPTXを高品質かつプラットフォームに依存しないXPSに変換します。ステップバイステップのガイドとサンプルコードをご覧ください。"
---

## **XPS について**
Microsoft は [XPS](https://docs.fileformat.com/page-description-language/xps/) を [PDF](https://docs.fileformat.com/pdf/) の代替として開発しました。PDF に非常に似たファイルを出力することでコンテンツを印刷できます。XPS フォーマットは XML に基づいています。XPS ファイルのレイアウトや構造はすべての OS とプリンターで同じです。 

## **Microsoft XPS フォーマットを使用すべき時**

{{% alert color="primary" %}} 
Aspose.Slides が PPT または PPTX プレゼンテーションを XPS フォーマットに変換する方法を見るには、[この無料オンラインコンバータアプリ](https://products.aspose.app/slides/conversion) を確認してください。 
{{% /alert %}} 

ストレージコストを削減したい場合は、Microsoft PowerPoint プレゼンテーションを XPS フォーマットに変換できます。これにより、ドキュメントの保存、共有、印刷が簡単になります。 

Microsoft は Windows（Windows 10 でも）で XPS のサポートを強化し続けているため、ファイルをこのフォーマットで保存することを検討するとよいでしょう。Windows 8.1、Windows 8、Windows 7、Windows Vista を使用している場合、特定の操作で XPS が最適なオプションになることがあります。 

- **Windows 8** は XPS ファイルに OXPS（Open XPS）フォーマットを使用します。OXPS は元の XPS フォーマットの標準化バージョンです。Windows 8 は PDF ファイルよりも XPS ファイルのサポートが優れています。 
  - **XPS**：組み込み XPS ビューア/リーダーと XPS への印刷機能が利用可能。 
  - **PDF**：PDF リーダーは利用可能ですが、PDF への印刷機能はありません。 

- **Windows 7 と Windows Vista** は元の XPS フォーマットを使用します。これらの OS も PDF より XPS のサポートが優れています。 
  - **XPS**：組み込み XPS ビューアと XPS への印刷機能が利用可能。 
  - **PDF**：PDF リーダーがなく、PDF への印刷機能もありません。 

|<p>**入力 PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**出力 XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft は最終的に Windows 10 の「Print to PDF」機能を通じて PDF の印刷操作サポートを実装しました。それ以前は XPS フォーマットを介してドキュメントを印刷することが想定されていました。 

## **Aspose.Slides を使用した XPS 変換**

[C++] 用の [**Aspose.Slides**](https://products.aspose.com/slides/cpp/) では、[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスが提供する [**Save**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) メソッドを使用して、プレゼンテーション全体を XPS ドキュメントに変換できます。 

プレゼンテーションを XPS に変換する際は、以下のいずれかの設定で保存する必要があります。

- デフォルト設定（[**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options) なし）
- カスタム設定（[**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options) 使用）

### **デフォルト設定を使用してプレゼンテーションを XPS に変換**

以下の C++ サンプルコードは、標準設定を使用してプレゼンテーションを XPS ドキュメントに変換する方法を示しています：
``` cpp
// プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化する
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// プレゼンテーションを XPS ドキュメントとして保存する
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```


### **カスタム設定を使用してプレゼンテーションを XPS に変換**
以下のサンプルコードは、カスタム設定を使用してプレゼンテーションを XPS ドキュメントに変換する方法を C++ で示しています：
``` cpp
// プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化する
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// TiffOptions クラスをインスタンス化する
auto options = System::MakeObject<XpsOptions>();

// メタファイルを PNG として保存する
options->set_SaveMetafilesAsPng(true);

// プレゼンテーションを XPS ドキュメントとして保存する
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```


## **よくある質問**

**ファイルではなくストリームに XPS を保存できますか？**

はい。Aspose.Slides はストリームへの直接エクスポートをサポートしており、Web API、サーバー側パイプライン、またはファイルシステムに触れずに XPS を送信したいシナリオに最適です。 

**非表示スライドは XPS に含まれますか、除外できますか？**

デフォルトでは、通常（表示）スライドのみがレンダリングされます。保存前に[非表示スライドを含めるまたは除外する](https://reference.aspose.com/slides/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/)ことができ、[エクスポート設定](https://reference.aspose.com/slides/cpp/aspose.slides.export/xpsoptions/)で出力に含めるページを正確に制御できます。