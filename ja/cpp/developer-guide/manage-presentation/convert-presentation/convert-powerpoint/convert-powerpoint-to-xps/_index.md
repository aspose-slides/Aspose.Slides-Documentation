---
title: PowerPointをXPSに変換
type: docs
weight: 70
url: /ja/cpp/convert-powerpoint-to-xps
keywords: "変換, PowerPointからXPSへ, 変換, PPTからXPSへ, PPTXからXPSへ"
description: "Aspose.Slides APIを使用してPowerPoint PPT、PPTXをXPS文書に変換します。"
---

## **XPSについて**
Microsoftは、[XPS](https://docs.fileformat.com/page-description-language/xps/)を[PDF](https://docs.fileformat.com/pdf/)の代替として開発しました。これは、PDFに非常に似たファイルを出力することでコンテンツを印刷できるようにします。XPSフォーマットはXMLに基づいています。XPSファイルのレイアウトまたは構造は、すべてのオペレーティングシステムおよびプリンターで同じです。

## Microsoft XPSフォーマットを使用するタイミング

{{% alert color="primary" %}} 

Aspose.SlidesがPPTまたはPPTXプレゼンテーションをXPSフォーマットに変換する方法を確認するには、[この無料のオンライン変換アプリ](https://products.aspose.app/slides/conversion)をチェックできます。 

{{% /alert %}} 

ストレージコストを削減したい場合は、Microsoft PowerPointプレゼンテーションをXPSフォーマットに変換することができます。これにより、文書の保存、共有、印刷が容易になります。

MicrosoftはWindows（Windows 10でも）でXPSの強力なサポートを実装し続けているため、このフォーマットにファイルを保存することを検討する価値があります。Windows 8.1、Windows 8、Windows 7、およびWindows Vistaを使用している場合、特定の操作においてXPSが最良の選択肢になるかもしれません。

- **Windows 8**はXPSファイルにOXPS（Open XPS）フォーマットを使用します。OXPSは、元のXPSフォーマットの標準化されたバージョンです。Windows 8はXPSファイルに対してPDFファイルよりも優れたサポートを提供します。
  - **XPS:** 組み込みのXPSビューア/リーダーとXPSへの印刷機能が利用可能です。
  - **PDF:** PDFリーダーは利用可能ですが、PDFへの印刷機能はありません。

- **Windows 7およびWindows Vista**は元のXPSフォーマットを使用します。これらのオペレーティングシステムは、PDFよりもXPSファイルに対して優れたサポートを提供します。
  - **XPS:** 組み込みのXPSビューアとXPSへの印刷機能が利用可能です。
  - **PDF:** PDFリーダーはありません。PDFへの印刷機能はありません。

|<p>**入力PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**出力XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |


Microsoftは最終的にWindows 10でPDFへの印刷操作をサポートするPrint to PDF機能を実装しました。以前は、ユーザーはXPSフォーマットを通じて文書を印刷することが期待されていました。

## Aspose.Slidesを使用したXPS変換

C++用の[**Aspose.Slides**](https://products.aspose.com/slides/cpp/)では、[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスによって公開されている[**Save**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e)メソッドを使用して、プレゼンテーション全体をXPS文書に変換できます。

プレゼンテーションをXPSに変換する際には、次のいずれかの設定を使用してプレゼンテーションを保存する必要があります。

- デフォルト設定（[**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options)なし）
- カスタム設定（[**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options)あり）

### **デフォルト設定を使用したプレゼンテーションのXPSへの変換**

このC++のサンプルコードは、標準設定を使用してプレゼンテーションをXPS文書に変換する方法を示しています：

``` cpp
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// プレゼンテーションをXPS文書として保存
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```


### **カスタム設定を使用したプレゼンテーションのXPSへの変換**
このサンプルコードは、C++でカスタム設定を使用してプレゼンテーションをXPS文書に変換する方法を示しています：

``` cpp
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// TiffOptionsクラスをインスタンス化
auto options = System::MakeObject<XpsOptions>();

// MetaFilesをPNGとして保存
options->set_SaveMetafilesAsPng(true);

// プレゼンテーションをXPS文書として保存
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```