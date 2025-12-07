---
title: C++ で PowerPoint プレゼンテーションを XPS に変換
linktitle: PowerPoint を XPS に変換
type: docs
weight: 70
url: /ja/cpp/convert-powerpoint-to-xps
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
- C++
- Aspose.Slides
description: "Aspose.Slides を使用して、C++ で PowerPoint PPT/PPTX を高品質かつプラットフォームに依存しない XPS に変換します。ステップバイステップのガイドとサンプルコードが提供されます。"
---

## **About XPS**
Microsoft は PDF の代替として XPS を開発しました。[XPS](https://docs.fileformat.com/page-description-language/xps/) は PDF に非常に似たファイルを出力することで、コンテンツを印刷できます。XPS 形式は XML をベースとしています。XPS ファイルのレイアウトや構造は、すべての OS およびプリンターで同じです。

## **When to Use Microsoft XPS Format**

{{% alert color="primary" %}} 
Aspose.Slides が PPT または PPTX プレゼンテーションを XPS 形式に変換する方法を確認するには、こちらの無料オンライン変換アプリをご覧ください。[this free online converter app](https://products.aspose.app/slides/conversion)。
{{% /alert %}} 

ストレージコストを削減したい場合は、Microsoft PowerPoint プレゼンテーションを XPS 形式に変換できます。これにより、ドキュメントの保存、共有、印刷が容易になります。

Microsoft は Windows（Windows 10 でも）で XPS のサポートを強化し続けているため、ファイルをこの形式で保存することを検討するとよいでしょう。Windows 8.1、Windows 8、Windows 7、Windows Vista を使用している場合、特定の操作では XPS が最適な選択肢となることがあります。

- **Windows 8** は XPS ファイルに OXPS（Open XPS）形式を使用します。OXPS は元の XPS 形式の標準化バージョンです。Windows 8 は PDF ファイルよりも XPS ファイルのサポートが優れています。
  - **XPS:** 組み込みの XPS ビューア/リーダーと XPS への印刷機能が利用可能です。
  - **PDF**: PDF リーダーは利用可能ですが、PDF への印刷機能はありません。

- **Windows 7** と **Windows Vista** は元の XPS 形式を使用します。これらの OS も PDF より XPS ファイルのサポートが優れています。
  - **XPS**: 組み込みの XPS ビューアと XPS への印刷機能が利用可能です。
  - **PDF**: PDF リーダーがありません。PDF への印刷機能もありません。

|<p>**入力 PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**出力 XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft は最終的に Windows 10 の Print to PDF 機能を通じて PDF の印刷操作のサポートを実装しました。以前は、ユーザーは XPS 形式を介して文書を印刷することが期待されていました。

## **XPS Conversion with Aspose.Slides**

C++ 用 **Aspose.Slides** では、[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスが提供する [**Save**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) メソッドを使用して、プレゼンテーション全体を XPS ドキュメントに変換できます。

プレゼンテーションを XPS に変換する際は、次のいずれかの設定で保存する必要があります：

- デフォルト設定（XPSOptions を使用しない）
- カスタム設定（XPSOptions 使用）

### **Convert Presentations to XPS Using Default Settings**

以下の C++ サンプルコードは、標準設定を使用してプレゼンテーションを XPS ドキュメントに変換する方法を示しています：
``` cpp
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// プレゼンテーションを XPS ドキュメントとして保存します
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```


### **Convert Presentations to XPS Using Custom Settings**
以下のサンプルコードは、C++ でカスタム設定を使用してプレゼンテーションを XPS ドキュメントに変換する方法を示しています：
``` cpp
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// TiffOptions クラスをインスタンス化します
auto options = System::MakeObject<XpsOptions>();

// メタファイルを PNG として保存します
options->set_SaveMetafilesAsPng(true);

// プレゼンテーションを XPS ドキュメントとして保存します
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```


## **FAQ**

**ファイルではなくストリームに XPS を保存できますか？**

はい。Aspose.Slides はストリームに直接エクスポートでき、Web API やサーバー側パイプライン、ファイルシステムに触れずに XPS を送信したいシナリオに最適です。

**非表示スライドは XPS に含まれますか？また、除外できますか？**

デフォルトでは、通常（可視）スライドのみがレンダリングされます。XPS に保存する前にエクスポート設定で[非表示スライドを含めるか除外する](https://reference.aspose.com/slides/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/)ことができ、[エクスポート設定](https://reference.aspose.com/slides/cpp/aspose.slides.export/xpsoptions/)により出力が意図したページだけになるよう制御できます。