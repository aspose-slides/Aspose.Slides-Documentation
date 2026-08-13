---
title: C++ で PowerPoint プレゼンテーションを XPS に変換
linktitle: PowerPoint を XPS へ
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
description: "Aspose.Slides を使用して C++ で PowerPoint の PPT/PPTX を高品質かつプラットフォームに依存しない XPS に変換します。ステップバイステップのガイドとサンプルコードをご覧ください。"
---
## **概要**

Aspose.Slides を使用すると、PPT または PPTX ファイルを XPS 形式で保存することで PowerPoint プレゼンテーションを XPS に変換できます。この記事では、XPS 形式が役立つ場面を説明し、Aspose.Slides を使用してデフォルト設定またはカスタム [XpsOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/xpsoptions/) 設定で変換を実行する方法を示します。

## **XPS について**

Microsoft は [XPS](https://docs.fileformat.com/page-description-language/xps/) を [PDF](https://docs.fileformat.com/pdf/) の代替として開発しました。PDF に非常に似たファイルを出力することでコンテンツを印刷できます。XPS 形式は XML に基づいています。XPS ファイルのレイアウトや構造はすべてのオペレーティングシステムやプリンターで同じままです。

## **Microsoft XPS フォーマットを使用すべきとき**

{{% alert color="info" %}} 

Aspose.Slides が PPT または PPTX プレゼンテーションを XPS 形式に変換する方法を確認するには、[この無料オンライン変換アプリ](https://products.aspose.app/slides/ja/conversion)をご利用ください。

{{% /alert %}} 

ストレージコストを削減したい場合は、Microsoft PowerPoint プレゼンテーションを XPS 形式に変換できます。これにより、ドキュメントの保存、共有、印刷がより容易になります。

Microsoft は Windows（Windows 10 でも）で XPS のサポートを強化し続けているため、ファイルをこの形式で保存することを検討すべきです。Windows 8.1、Windows 8、Windows 7、Windows Vista を使用している場合、特定の操作において XPS が最適な選択肢になることがあります。

- **Windows 8** は XPS ファイルに OXPS (Open XPS) 形式を使用します。OXPS は元の XPS 形式の標準化バージョンです。Windows 8 は PDF ファイルよりも XPS ファイルのサポートが優れています。  
  - **XPS:** 組み込みの XPS ビューア/リーダーと XPS への印刷機能が利用可能です。  
  - **PDF:** PDF リーダーは利用可能ですが、PDF への印刷機能はありません。  

- **Windows 7 と Windows Vista** は元の XPS 形式を使用します。これらの OS も PDF より XPS のサポートが優れています。  
  - **XPS:** 組み込みの XPS ビューアと XPS への印刷機能が利用可能です。  
  - **PDF:** PDF リーダーなし。PDF への印刷機能なし。  

|<p>**入力 PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**出力 XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft は最終的に Windows 10 の「Print to PDF」機能を通じて PDF の印刷操作のサポートを実装しました。以前は、ユーザーは XPS 形式で文書を印刷することが期待されていました。

## **Aspose.Slides を使用した XPS 変換**

C++ 用の [**Aspose.Slides**](https://products.aspose.com/slides/ja/cpp/) では、[Presentation](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.presentation) クラスが提供する [**Save**](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) メソッドを使用して、プレゼンテーション全体を XPS ドキュメントに変換できます。

プレゼンテーションを XPS に変換する際は、次の設定のいずれかで保存する必要があります：

- デフォルト設定（[**XPSOptions**] を使用しない）
- カスタム設定（[**XPSOptions**] を使用）

### **デフォルト設定でプレゼンテーションを XPS に変換する**

C++ のサンプルコードは、標準設定を使用してプレゼンテーションを XPS ドキュメントに変換する方法を示しています：

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// プレゼンテーションを XPS ドキュメントに保存
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```

### **カスタム設定でプレゼンテーションを XPS に変換する**

C++ のカスタム設定を使用してプレゼンテーションを XPS ドキュメントに変換するサンプルコードを示します：

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Export/XpsOptions.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// TiffOptions クラスをインスタンス化
auto options = System::MakeObject<XpsOptions>();

// MetaFiles を PNG として保存
options->set_SaveMetafilesAsPng(true);

// プレゼンテーションを XPS ドキュメントに保存
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```

## **よくある質問**

### ファイルではなくストリームに XPS を保存できますか？

はい。Aspose.Slides はストリームへ直接エクスポートでき、Web API、サーバー側パイプライン、またはファイルシステムに触れずに XPS を送信したいあらゆるシナリオに最適です。

### 非表示スライドは XPS に含まれますか、除外できますか？

既定では、通常（表示）スライドのみがレンダリングされます。XPS に保存する前に、[エクスポート設定](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/xpsoptions/)で[非表示スライドの含める/除外する](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/)ことができ、出力に意図したページだけが含まれるようにできます。