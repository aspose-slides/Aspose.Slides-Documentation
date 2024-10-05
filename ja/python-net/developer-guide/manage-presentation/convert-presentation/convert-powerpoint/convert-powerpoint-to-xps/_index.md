---
title: PowerPointをXPSに変換
type: docs
weight: 70
url: /python-net/convert-powerpoint-to-xps
keywords: "PowerPointプレゼンテーションの変換, PowerPointからXPS, PPTからXPS, PPTXからXPS, 変換, Python, Aspose.Slides"
description: "PythonでPowerPointプレゼンテーションをXPSに変換します。"
---

## **XPSについて**
Microsoftは、[XPS](https://docs.fileformat.com/page-description-language/xps/)を[PDF](https://docs.fileformat.com/pdf/)の代替として開発しました。これにより、PDFに非常によく似たファイルを出力することでコンテンツを印刷できます。XPS形式はXMLに基づいています。XPSファイルのレイアウトや構造は、すべてのオペレーティングシステムやプリンターで同じままです。

## Microsoft XPS形式を使用するタイミング

{{% alert color="primary" %}} 

Aspose.SlidesがPPTまたはPPTXプレゼンテーションをXPS形式に変換する方法を確認するには、[この無料オンラインコンバーターアプリ](https://products.aspose.app/slides/conversion)をチェックしてください。 

{{% /alert %}} 

ストレージコストを削減したい場合、Microsoft PowerPointプレゼンテーションをXPS形式に変換できます。これにより、ドキュメントの保存、共有、および印刷が容易になります。

MicrosoftはWindows（Windows 10でも）でXPSの強力なサポートを実装し続けているため、この形式でファイルを保存することを検討する価値があります。Windows 8.1、Windows 8、Windows 7、及びWindows Vistaを使用している場合、特定の操作にはXPSが最適な選択肢となるかもしれません。

- **Windows 8**は、XPSファイルに対してOXPS（Open XPS）形式を使用します。OXPSはオリジナルのXPS形式の標準化されたバージョンです。Windows 8はXPSファイルに対してPDFファイルよりも良いサポートを提供します。
  - **XPS:** ビルトインのXPSビューワ/リーダーおよびXPS印刷機能が使用可能。
  - **PDF**: PDFリーダーは使用可能ですが、PDF印刷機能はありません。

-  **Windows 7およびWindows Vista**はオリジナルのXPS形式を使用します。これらのオペレーティングシステムもXPSファイルに対してPDFより良いサポートを提供します。
  - **XPS**: ビルトインのXPSビューワとXPS印刷機能が使用可能。
  - **PDF**: PDFリーダーはありません。PDF印刷機能はありません。

|<p>**入力PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**出力XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoftは最終的にWindows 10のPDF機能を通じて PDFへの印刷操作のサポートを実装しました。それ以前は、ユーザーはXPS形式を介してドキュメントを印刷することを期待されていました。

## Aspose.Slidesを使用したXPS変換

.NET用の[**Aspose.Slides**](https://products.aspose.com/slides/python-net/)では、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスによって公開されている[**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)メソッドを使用して、プレゼンテーション全体をXPSドキュメントに変換できます。

プレゼンテーションをXPSに変換するときは、以下のいずれかの設定を使用してプレゼンテーションを保存する必要があります。

- デフォルト設定（[**XPSOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/)なし）
- カスタム設定（[**XPSOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/)あり）

### **デフォルト設定を使用したプレゼンテーションのXPSへの変換**

このPythonのサンプルコードは、標準設定を使用してプレゼンテーションをXPSドキュメントに変換する方法を示しています：

```py
import aspose.slides as slides

# プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
pres = slides.Presentation("Convert_XPS.pptx")

# プレゼンテーションをXPSドキュメントに保存
pres.save("XPS_Output_Without_XPSOption_out.xps", slides.export.SaveFormat.XPS)
```

### **カスタム設定を使用したプレゼンテーションのXPSへの変換**
このサンプルコードは、カスタム設定を使用してプレゼンテーションをXPSドキュメントに変換する方法を示しています：

```py
import aspose.slides as slides

# プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
pres = slides.Presentation("Convert_XPS_Options.pptx")

# TiffOptionsクラスをインスタンス化
options = slides.export.XpsOptions()

# メタファイルをPNGとして保存
options.save_metafiles_as_png = True

# プレゼンテーションをXPSドキュメントに保存
pres.save("XPS_With_Options_out.xps", slides.export.SaveFormat.XPS, options)
```